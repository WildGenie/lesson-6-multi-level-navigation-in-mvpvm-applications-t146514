Imports System
Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations
Imports MvpvmNavigation.ViewModels

Namespace MvpvmNavigation.ViewModels
    Public Class ModuleBViewModel
        <ServiceProperty>
        Public Overridable ReadOnly Property DocumentManagerService() As IDocumentManagerService
            Get
                Throw New NotImplementedException()
            End Get
        End Property
        <Command>
        Public Sub ShowEditForm()
            Dim document = DocumentManagerService.CreateDocument("EditForm", Nothing, Me)
            If document IsNot Nothing Then
                Dim viewModel As EditFormViewModel = TryCast(document.Content, EditFormViewModel)
                If viewModel IsNot Nothing Then
                    viewModel.Document = document
                End If
                document.Show()
            End If
        End Sub
    End Class
End Namespace