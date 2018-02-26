Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.POCO

Namespace MvpvmNavigation.Views
    Partial Public Class BaseModuleControl
        Inherits UserControl
        Implements ISupportViewModel

        #Region "ctor for DesignTime"
        Private Sub New()
        End Sub
        #End Region

        #Region "ViewModel injection"
        Private viewModelCore As Object
        Protected Sub New(ByVal viewModelInjector As Func(Of Object))
            Me.viewModelCore = viewModelInjector()
            InitServices()
        End Sub

        Private Sub InitServices()
            Dim serviceContainer = GetServiceContainer()
            If serviceContainer IsNot Nothing Then
                OnInitServices(serviceContainer)
            End If

        End Sub

        Protected Shared Function CreateViewModel(Of TViewModel As {Class, New})() As TViewModel
            Return ViewModelSource.Create(Of TViewModel)()

        End Function
        #End Region ' ViewModel injection
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If viewModelCore IsNot Nothing Then
                    ReleaseModule()
                    OnDisposing()
                End If
                viewModelCore = Nothing
            End If
            MyBase.Dispose(disposing)
        End Sub
        Private Sub ReleaseModule()
            Dim locator = GetService(Of Services.IModuleLocator)()
            If locator IsNot Nothing Then
                locator.ReleaseModule(Me)
            End If
        End Sub
        Protected Overridable Sub OnInitServices(ByVal serviceContainer As IServiceContainer)
        End Sub
        Protected Overridable Sub OnDisposing()
        End Sub
        Protected Function GetViewModel(Of TViewModel)() As TViewModel
            Return DirectCast(viewModelCore, TViewModel)
        End Function

        Private Function GetServiceContainer() As IServiceContainer
            If Not(TypeOf viewModelCore Is ISupportServices) Then
                Return Nothing
            End If
            Return DirectCast(viewModelCore, ISupportServices).ServiceContainer
        End Function
        Protected Overloads Function GetService(Of TService As Class)() As TService
            Dim serviceContainer = GetServiceContainer()
            Return If(serviceContainer IsNot Nothing, serviceContainer.GetService(Of TService)(), Nothing)
        End Function
        Private ReadOnly Property ISupportViewModel_ViewModel() As Object Implements ISupportViewModel.ViewModel
            Get
                Return viewModelCore
            End Get
        End Property
    End Class
End Namespace
