Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports DevExpress.Mvvm

Namespace MvpvmNavigation.Services
    Public MustInherit Class DocumentManagerServiceBase
        Implements IDocumentManagerService, IDocumentOwner

        Private documentsCore As IList(Of IDocument)
        Public Sub New()
            Me.documentsCore = New List(Of IDocument)()
        End Sub
        Protected Function RegisterDocument(ByVal view As Object, ByVal createDocument As Func(Of Form, IDocument), ByVal createContainer As Func(Of Form), Optional ByVal id As Object = Nothing) As IDocument
            Dim container As Form = Nothing
            If createContainer IsNot Nothing Then
                container = createContainer()
                If container IsNot Nothing Then
                    container.Owner = Application.OpenForms(0)
                    container.Icon = container.Owner.Icon
                End If
            End If
            Dim document As IDocument = createDocument(container)
            document.Id = id
            documentsCore.Add(document)
            If view IsNot Nothing Then
                container.ClientSize = DirectCast(view, Control).Size
                DirectCast(view, Control).Dock = DockStyle.Fill
                DirectCast(view, Control).Parent = container
                DirectCast(view, Control).BringToFront()
            End If
            Return document
        End Function
        Protected Function EnsureViewModel(ByVal viewModel As Object, ByVal parameter As Object, ByVal parentViewModel As Object, ByVal view As Object) As Object
            If viewModel Is Nothing Then
                If TypeOf view Is ISupportViewModel Then
                    viewModel = DirectCast(view, ISupportViewModel).ViewModel
                End If
            End If
            ViewModels.ViewModelHelper.EnsureViewModel(viewModel, parentViewModel, parameter)
            Dim documentContent As IDocumentContent = TryCast(viewModel, IDocumentContent)
            If documentContent IsNot Nothing Then
                documentContent.DocumentOwner = Me
            End If
            Return viewModel
        End Function
        Protected Friend Sub RemoveDocument(ByVal document As IDocument)
            documentsCore.Remove(document)
        End Sub
        Protected Function GetService(Of TService As Class)(ByVal viewModel As Object) As TService
            Return DirectCast(viewModel, ISupportServices).ServiceContainer.GetService(Of TService)()
        End Function
        #Region "IDocumentManagerService"
        Private Function IDocumentManagerService_CreateDocument(ByVal documentType As String, ByVal viewModel As Object, ByVal parameter As Object, ByVal parentViewModel As Object) As IDocument Implements IDocumentManagerService.CreateDocument
            Return CreateDocumentCore(documentType, viewModel, parentViewModel, parameter)
        End Function
        Private ReadOnly Property IDocumentManagerService_Documents() As IEnumerable(Of IDocument) Implements IDocumentManagerService.Documents
            Get
                Return documentsCore
            End Get
        End Property
        Private Property IDocumentManagerService_ActiveDocument() As IDocument Implements IDocumentManagerService.ActiveDocument
            Get
                Throw New NotImplementedException()
            End Get
            Set(ByVal value As IDocument)
                Throw New NotImplementedException()
            End Set
        End Property
        Private Custom Event ActiveDocumentChanged As ActiveDocumentChangedEventHandler Implements IDocumentManagerService.ActiveDocumentChanged
            AddHandler(ByVal value As ActiveDocumentChangedEventHandler)
            End AddHandler
            RemoveHandler(ByVal value As ActiveDocumentChangedEventHandler)
            End RemoveHandler
            RaiseEvent(ByVal sender As System.Object, ByVal e As DevExpress.Mvvm.ActiveDocumentChangedEventArgs)
            End RaiseEvent
        End Event
        #End Region ' IDocumentManagerService
        Private Sub IDocumentOwner_Close(ByVal documentContent As IDocumentContent, Optional ByVal force As Boolean = true) Implements IDocumentOwner.Close
            Dim document = documentsCore.FirstOrDefault(Function(d) Object.Equals(d.Content, documentContent))
            If document IsNot Nothing Then
                document.Close(force)
            End If
        End Sub
        Protected MustOverride Function CreateDocumentCore(ByVal documentType As String, ByVal viewModel As Object, ByVal parentViewModel As Object, ByVal parameter As Object) As IDocument
    End Class
    Public MustInherit Class DialogDocumentManagerService
        Inherits DocumentManagerServiceBase

        #Region "Document"
        Protected Class DialogDocument
            Implements IDocument

            Private ReadOnly contentCore As Object
            Private ReadOnly formCore As Form
            Private ReadOnly owner As DialogDocumentManagerService
            Public Sub New(ByVal owner As DialogDocumentManagerService, ByVal form As Form, ByVal content As Object)
                Me.owner = owner
                Me.formCore = form
                Me.contentCore = content
                AddHandler form.Closed, AddressOf form_Closed
                AddHandler form.Closing, AddressOf form_Closing
            End Sub
            Private Sub form_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
                Dim documentContent = GetContent(Of IDocumentContent)()
                If documentContent IsNot Nothing Then
                    documentContent.OnClose(e)
                End If
            End Sub
            Private Sub form_Closed(ByVal sender As Object, ByVal e As EventArgs)
                owner.RemoveDocument(Me)
                RemoveHandler formCore.Closing, AddressOf form_Closing
                RemoveHandler formCore.Closed, AddressOf form_Closed
                Dim documentContent = GetContent(Of IDocumentContent)()
                If documentContent IsNot Nothing Then
                    documentContent.OnDestroy()
                End If
                owner.RemoveDocument(Me)
            End Sub
            Private Sub IDocument_Show() Implements IDocument.Show
                Using formCore
                    formCore.ShowDialog()
                End Using
            End Sub
            Private Sub IDocument_Hide() Implements IDocument.Hide
                formCore.Close()
            End Sub
            Private Sub IDocument_Close(Optional ByVal force As Boolean = true) Implements IDocument.Close
                formCore.Close()
            End Sub
            Private Property IDocument_DestroyOnClose() As Boolean Implements IDocument.DestroyOnClose
                Get
                    Return True
                End Get
                Set(ByVal value As Boolean)
                End Set
            End Property
            Private Property IDocument_Id() As Object Implements IDocument.Id
            Private Property IDocument_Title() As Object Implements IDocument.Title
                Get
                    Return formCore.Text
                End Get
                Set(ByVal value As Object)
                    formCore.Text = Convert.ToString(value)
                End Set
            End Property
            Private ReadOnly Property IDocument_Content() As Object Implements IDocument.Content
                Get
                    Return contentCore
                End Get
            End Property
            Private Function GetContent(Of TContent As Class)() As TContent
                Return TryCast(contentCore, TContent)
            End Function
        End Class
        #End Region ' Document
    End Class
End Namespace
