using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MvpvmNavigation.Services {
    public interface IModuleActivator {
        object CreateModule(string moduleTypeName);
    }
    //
    class ModuleActivator : IModuleActivator {
        Assembly moduleAssembly;
        string rootNamespace;
        public ModuleActivator(Assembly moduleAssembly, string rootNamespace) {
            this.moduleAssembly = moduleAssembly;
            this.rootNamespace = rootNamespace;
        }
        public object CreateModule(string moduleTypeName) {
            return Activator.CreateInstance(moduleAssembly.GetType(rootNamespace + '.' + moduleTypeName));
        }
    }
}
