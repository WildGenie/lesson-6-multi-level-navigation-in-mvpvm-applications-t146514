using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using MvpvmNavigation.ViewModels.Module_A;
using DevExpress.Mvvm;

namespace MvpvmNavigation.Views {
    public partial class View1 : BaseModuleControl, IRibbonModule {
        public View1()
            : base(CreateViewModel<ModuleAViewModel>) {
            InitializeComponent();
            BindCommands();
            System.Threading.Thread.Sleep(1000);
        }
        RibbonControl IRibbonModule.Ribbon {
            get { return ribbonControl1; }
        }
        public ModuleAViewModel ViewModel {
            get { return GetViewModel<ModuleAViewModel>(); }
        }

        void BindCommands() {
            buttonShow.BindCommand(() => ViewModel.ShowEditForm(), ViewModel);
        }

        protected override void OnInitServices(IServiceContainer serviceContainer) {
            serviceContainer.RegisterService(new Services.EditFormService(Model.ModuleType.ModuleA_EditForm));
        }
    }
}
