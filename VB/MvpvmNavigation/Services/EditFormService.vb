Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports DevExpress.Mvvm
Imports MvpvmNavigation.Model

Namespace MvpvmNavigation.Services
    Friend Class EditFormService
        Inherits DialogDocumentManagerService

        Private ReadOnly viewModuleType As ModuleType
        Public Sub New(ByVal viewModuleType As ModuleType)
            Me.viewModuleType = viewModuleType
        End Sub

        Protected Overrides Function CreateDocumentCore(ByVal documentType As String, ByVal viewModel As Object, ByVal parentViewModel As Object, ByVal parameter As Object) As IDocument
            Dim moduleLocator = GetService(Of Services.IModuleLocator)(parentViewModel)
            Dim view As Object = moduleLocator.GetModule(viewModuleType)
            viewModel = EnsureViewModel(viewModel, parameter, parentViewModel, view)
            Return RegisterDocument(view, Function(form) New DialogDocument(Me, form, viewModel), Function() New EditForm(documentType))
        End Function

        Private Class EditForm
            Inherits Form

            Public Sub New(ByVal text As String)
                Me.Text = text
                StartPosition = FormStartPosition.CenterParent
            End Sub
        End Class
    End Class
End Namespace
