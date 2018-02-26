using System;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using MvpvmNavigation.ViewModels;

namespace MvpvmNavigation.ViewModels {
    public class ModuleBViewModel {
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