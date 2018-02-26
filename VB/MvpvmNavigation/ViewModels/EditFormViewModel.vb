Imports System.ComponentModel
Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations

Namespace MvpvmNavigation.ViewModels
    Public Class EditFormViewModel
        Implements IDocumentContent

        Public Property Document() As IDocument
        Private privateResult? As Boolean
        Public Property Result() As Boolean?
            Get
                Return privateResult
            End Get
            Private Set(ByVal value? As Boolean)
                privateResult = value
            End Set
        End Property
        <Command>
        Public Sub OK()
            Result = True
            Document.Close()
        End Sub
        <Command>
        Public Sub Cancel()
            Result = False
            Document.Close()
        End Sub

        #Region "IDocumentContent"
        Private ReadOnly Property IDocumentContent_Title() As Object Implements IDocumentContent.Title
            Get
                Return "Edit Form"
            End Get
        End Property
        Private Sub IDocumentContent_OnClose(ByVal e As CancelEventArgs) Implements IDocumentContent.OnClose
            e.Cancel = False
            'processing
        End Sub
        Private Sub IDocumentContent_OnDestroy() Implements IDocumentContent.OnDestroy
            'cleanup
        End Sub
        Private Property IDocumentContent_DocumentOwner() As IDocumentOwner Implements IDocumentContent.DocumentOwner
        #End Region
    End Class
End Namespace