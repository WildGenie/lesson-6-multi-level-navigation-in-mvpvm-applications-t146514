using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvpvmNavigation.Model {
    public enum ModuleType {
        None,
        [Display(Name = "Module A")]
        ModuleA,
        [Display(Name = "Module B")]
        ModuleB,
        [Display(Name = "Module A Edit Form")]
        ModuleA_EditForm,
        [Display(Name = "Module B Edit Form")]
        ModuleB_EditForm
    }
}
