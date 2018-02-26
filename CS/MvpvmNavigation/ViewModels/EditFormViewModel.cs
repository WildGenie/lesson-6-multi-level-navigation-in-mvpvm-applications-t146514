using System.ComponentModel;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;

namespace MvpvmNavigation.ViewModels {
    public class EditFormViewModel : IDocumentContent {
        public IDocument Document { get; set; }
        public bool? Result { get; private set; }
        [Command]
        public void OK() {
            Result = true;
            Document.Close();
        }
        [Command]
        public void Cancel() {
            Result = false;
            Document.Close();
        }

        #region IDocumentContent
        object IDocumentContent.Title {
            get { return "Edit Form"; }
        }
        void IDocumentContent.OnClose(CancelEventArgs e) {
            e.Cancel = false;
            //processing
        }
        void IDocumentContent.OnDestroy() {
            //cleanup
        }
        IDocumentOwner IDocumentContent.DocumentOwner {
            get;
            set;
        }
        #endregion
    }
}