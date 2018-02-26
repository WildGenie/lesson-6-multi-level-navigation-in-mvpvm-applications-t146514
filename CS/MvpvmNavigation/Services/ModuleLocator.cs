using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using MvpvmNavigation.Model;

namespace MvpvmNavigation.Services {
    public interface IModuleLocator {
        bool IsModuleLoaded(ModuleType moduleType);
        object GetModule(ModuleType moduleType);
        void ReleaseModule(object module);
    }
    //
    class ModuleLocator : IModuleLocator {
        IServiceContainer serviceContainer;
        IDictionary<ModuleType, WeakReference> modulesCache;
        public ModuleLocator(DevExpress.Mvvm.IServiceContainer serviceContainer) {
            this.serviceContainer = serviceContainer;
            this.modulesCache = new Dictionary<ModuleType, WeakReference>();
        }
        public bool IsModuleLoaded(ModuleType moduleType) {
            return modulesCache.ContainsKey(moduleType);
        }
        public object GetModule(ModuleType moduleType) {
            if(moduleType == ModuleType.None)
                return null;
            WeakReference moduleReference;
            if(!modulesCache.TryGetValue(moduleType, out moduleReference) || moduleReference.Target == null) {
                var resolver = serviceContainer.GetService<IModuleTypesResolver>();
                string moduleTypeName = resolver.GetTypeName(moduleType);
                var activator = serviceContainer.GetService<IModuleActivator>();
                var module = activator.CreateModule(moduleTypeName);
                if(moduleReference == null) {
                    moduleReference = new WeakReference(module);
                    modulesCache.Add(moduleType, moduleReference);
                }
                else moduleReference.Target = module;
            }
            return moduleReference.Target;
        }
        public void ReleaseModule(object module) {
            ModuleType key = ModuleType.None;
            foreach(var item in modulesCache) {
                if(!object.Equals(item.Value.Target, module)) continue;
                key = item.Key;
                break;
            }
            modulesCache.Remove(key);
        }
    }
}
