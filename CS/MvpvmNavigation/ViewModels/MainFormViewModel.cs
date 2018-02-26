using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm.DataAnnotations;
using MvpvmNavigation.Model;
using MvpvmNavigation.Services;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm;

namespace MvpvmNavigation.ViewModels {
    public class MainFormViewModel {
        #region static
        static MainFormViewModel() {
            RegisterServices();
        }
        static void RegisterServices() {
            DevExpress.Mvvm.ServiceContainer.Default.RegisterService(new Services.ModuleTypesResolver());
        }
        static void RegisterServices(IServiceContainer serviceContainer) {
            serviceContainer.RegisterService(new Services.ModuleActivator(
               typeof(Form1).Assembly, typeof(Form1).Namespace + ".Views"));
            serviceContainer.RegisterService(new Services.ModuleLocator(serviceContainer));
        }
        static void RegisterServices(IServiceContainer serviceContainer, object mainForm) {
            serviceContainer.RegisterService(new Services.TransitionService(mainForm as ISupportTransitions));
        }
        #endregion static
        public MainFormViewModel() {
            RegisterServices((this as ISupportServices).ServiceContainer);
        }

        public void RegisterServices(object mainForm) {
            RegisterServices((this as ISupportServices).ServiceContainer, mainForm);
        }

        #region Properties
        public virtual ModuleType SelectedModuleType {
            get;
            set;
        }

        IDisposable transitionBatch;

        protected virtual void OnSelectedModuleTypeChanging(ModuleType newValue) {
            var transitionService = GetService<Services.ITransitionService>();
            bool effective = (SelectedModuleType != ModuleType.None) && (newValue != ModuleType.None);
            object waitParameter = !IsModuleLoaded(newValue) ? (object)newValue : null;
            transitionBatch = transitionService.EnterTransition(effective, ((int)newValue > (int)SelectedModuleType), waitParameter);

        }

        protected virtual void OnSelectedModuleTypeChanged() {
            this.RaiseCanExecuteChanged(x => x.SelectModule(ModuleType.None));
            RaiseSelectedModuleTypeChanged();
            transitionBatch.Dispose();
        }
        #endregion Properties

        #region Commands
        [Command(UseCommandManager = false)]
        public void SelectModule(ModuleType type) {
            SelectedModuleType = type;
        }
        public bool CanSelectModule(ModuleType type) {
            return type != SelectedModuleType;
        }
        #endregion Commands
        public event EventHandler SelectedModuleTypeChanged;
        void RaiseSelectedModuleTypeChanged() {
            var handler = SelectedModuleTypeChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }
        TService GetService<TService>() where TService : class {
            return ((ISupportServices)this).ServiceContainer.GetService<TService>();
        }
        public bool IsModuleLoaded(ModuleType parameter) {
            return GetService<Services.IModuleLocator>().IsModuleLoaded(parameter);
        }
        public object GetModule(ModuleType parameter) {
            return GetService<Services.IModuleLocator>().GetModule(parameter);
        }
        public string GetName(ModuleType parameter) {
            return GetService<Services.IModuleTypesResolver>().GetName(parameter);
        }
        public string GetCaption(ModuleType parameter) {
            return GetService<Services.IModuleTypesResolver>().GetCaption(parameter);
        }
    }
}
