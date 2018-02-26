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
using DevExpress.Mvvm;
using MvpvmNavigation.ViewModels;

namespace MvpvmNavigation.Views {
    public partial class View2 : BaseModuleControl, IRibbonModule {
        public View2()
            : base(CreateViewModel<ModuleBViewModel>) {
            InitializeComponent();
            BindCommands();
            System.Threading.Thread.Sleep(1000);
        }
        protected override void OnInitServices(IServiceContainer serviceContainer) {
            serviceContainer.RegisterService(new Services.EditFormService(Model.ModuleType.ModuleB_EditForm));
        }
        void BindCommands() {
            buttonShow.BindCommand(() => ViewModel.ShowEditForm(), ViewModel);
        }
        public ModuleBViewModel ViewModel {
            get { return GetViewModel<ModuleBViewModel>(); }
        }
        RibbonControl IRibbonModule.Ribbon {
            get { return ribbonControl1; }
        }
    }
}
