using System;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;

namespace MvpvmNavigation.ViewModels.Module_A {
    public class ModuleAViewModel {
        [ServiceProperty]
        public virtual IDocumentManagerService DocumentManagerService {
            get { throw new NotImplementedException(); }
        }
        [Command]
        public void ShowEditForm() {
            var document = DocumentManagerService.CreateDocument("EditForm", null, this);
            if (document != null) {
                EditFormViewModel viewModel = document.Content as EditFormViewModel;
                if (viewModel != null)
                    viewModel.Document = document;
                document.Show();
            }
        }
    }
}
