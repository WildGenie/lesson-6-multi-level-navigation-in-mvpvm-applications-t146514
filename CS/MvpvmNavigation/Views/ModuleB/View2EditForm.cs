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
    public partial class View2EditForm : BaseModuleControl {
        public View2EditForm()
            : base(CreateViewModel<ModuleBEditFormViewModel>) {
            InitializeComponent();
            BindCommands();
        }

        void BindCommands() {
            buttonOK.BindCommand(() => ViewModel.OK(), ViewModel);
            buttonCancel.BindCommand(() => ViewModel.Cancel(), ViewModel);
        }

        public ModuleBEditFormViewModel ViewModel {
            get { return GetViewModel<ModuleBEditFormViewModel>(); }
        }
    }
}
