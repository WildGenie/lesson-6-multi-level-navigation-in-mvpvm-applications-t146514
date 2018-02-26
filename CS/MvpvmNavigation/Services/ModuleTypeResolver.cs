using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvpvmNavigation.Model;

namespace MvpvmNavigation.Services {
    public interface IModuleTypesResolver {
        string GetName(ModuleType moduleType);
        string GetCaption(ModuleType moduleType);
        string GetTypeName(ModuleType moduleType);
    }
    class ModuleTypesResolver : IModuleTypesResolver {
        public string GetName(ModuleType moduleType) {
            if (moduleType == ModuleType.None)
                return null;
            return moduleType.ToString();
        }
        public string GetCaption(ModuleType moduleType) {
            if (moduleType == ModuleType.None)
                return null;
            return DevExpress.XtraEditors.EnumDisplayTextHelper.GetDisplayText(moduleType);
        }
        public string GetTypeName(ModuleType moduleType) {
            if (moduleType == ModuleType.None)
                return null;
            switch (moduleType) {
                case ModuleType.ModuleA:
                    return "View1";
                case ModuleType.ModuleB:
                    return "View2";
                case ModuleType.ModuleA_EditForm:
                    return "View1EditForm";
                case ModuleType.ModuleB_EditForm:
                    return "View2EditForm";
            }
            throw new NotSupportedException();
        }
    }
}
