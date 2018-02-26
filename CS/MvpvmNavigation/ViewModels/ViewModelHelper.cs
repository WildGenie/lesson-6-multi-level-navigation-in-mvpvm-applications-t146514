using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;

namespace MvpvmNavigation.ViewModels {
    public static class ViewModelHelper {
        public static void EnsureModuleViewModel(object view, object parentViewModel, object parameter = null) {
            ISupportViewModel viewModelSupport = view as ISupportViewModel;
            if (viewModelSupport != null)
                EnsureViewModel(viewModelSupport.ViewModel, parentViewModel, parameter);
        }
        public static void EnsureViewModel(object viewModel, object parentViewModel, object parameter = null) {
            ISupportParentViewModel parentViewModelSupport = viewModel as ISupportParentViewModel;
            if (parentViewModelSupport != null)
                parentViewModelSupport.ParentViewModel = parentViewModel;
            ISupportParameter parameterSupport = viewModel as ISupportParameter;
            if (parameterSupport != null && parameter != null)
                parameterSupport.Parameter = parameter;
        }
    }
}
