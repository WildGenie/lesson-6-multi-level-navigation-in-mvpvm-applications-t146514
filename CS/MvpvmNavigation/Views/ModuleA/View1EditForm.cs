using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MvpvmNavigation.ViewModels;

namespace MvpvmNavigation.Views {
    public partial class View1EditForm : BaseModuleControl {
        public View1EditForm()
            : base(CreateViewModel<ModuleAEditFormViewModel>) {
            InitializeComponent();
            BindCommands();
        }

        void BindCommands() {
            buttonOK.BindCommand(() => ViewModel.OK(), ViewModel);
            buttonCancel.BindCommand(() => ViewModel.Cancel(), ViewModel);
        }

        public ModuleAEditFormViewModel ViewModel {
            get { return GetViewModel<ModuleAEditFormViewModel>(); }
        }
    }
}
