using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

namespace MvpvmNavigation.Views {
    public partial class BaseModuleControl : UserControl, ISupportViewModel {
        #region ctor for DesignTime
        BaseModuleControl() { }
        #endregion

        #region ViewModel injection
        object viewModelCore;
        protected BaseModuleControl(Func<object> viewModelInjector) {
            this.viewModelCore = viewModelInjector();
            InitServices();
        }

        void InitServices() {
            var serviceContainer = GetServiceContainer();
            if (serviceContainer != null)
                OnInitServices(serviceContainer);

        }

        protected static TViewModel CreateViewModel<TViewModel>()
            where TViewModel : class, new() {
            return ViewModelSource.Create<TViewModel>();

        }
        #endregion ViewModel injection
        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (viewModelCore != null) {
                    ReleaseModule();
                    OnDisposing();
                }
                viewModelCore = null;
            }
            base.Dispose(disposing);
        }
        void ReleaseModule() {
            var locator = GetService<Services.IModuleLocator>();
            if (locator != null)
                locator.ReleaseModule(this);
        }
        protected virtual void OnInitServices(IServiceContainer serviceContainer) { }
        protected virtual void OnDisposing() { }
        protected TViewModel GetViewModel<TViewModel>() {
            return (TViewModel)viewModelCore;
        }

        IServiceContainer GetServiceContainer() {
            if (!(viewModelCore is ISupportServices)) return null;
            return ((ISupportServices)viewModelCore).ServiceContainer;
        }
        protected TService GetService<TService>() where TService : class {
            var serviceContainer = GetServiceContainer();
            return (serviceContainer != null) ? serviceContainer.GetService<TService>() : null;
        }
        object ISupportViewModel.ViewModel { get { return viewModelCore; } }
    }
}
