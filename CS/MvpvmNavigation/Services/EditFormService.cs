using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Mvvm;
using MvpvmNavigation.Model;

namespace MvpvmNavigation.Services {
    class EditFormService : DialogDocumentManagerService {
        readonly ModuleType viewModuleType;
        public EditFormService(ModuleType viewModuleType) {
            this.viewModuleType = viewModuleType;
        }

        protected override IDocument CreateDocumentCore(string documentType, object viewModel, object parentViewModel, object parameter) {
            var moduleLocator = GetService<Services.IModuleLocator>(parentViewModel);
            object view = moduleLocator.GetModule(viewModuleType);
            viewModel = EnsureViewModel(viewModel, parameter, parentViewModel, view);
            return RegisterDocument(view, (form) => new DialogDocument(this, form, viewModel), () => new EditForm(documentType));
        }

        class EditForm : Form {
            public EditForm(string text) {
                Text = text;
                StartPosition = FormStartPosition.CenterParent;
            }
        }
    }
}
