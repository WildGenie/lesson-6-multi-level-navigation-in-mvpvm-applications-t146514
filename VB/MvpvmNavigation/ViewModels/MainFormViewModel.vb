Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports DevExpress.Mvvm.DataAnnotations
Imports MvpvmNavigation.Model
Imports MvpvmNavigation.Services
Imports DevExpress.Mvvm.POCO
Imports DevExpress.Mvvm

Namespace MvpvmNavigation.ViewModels
    Public Class MainFormViewModel
        #Region "static"
        Shared Sub New()
            RegisterServices()
        End Sub
        Private Shared Sub RegisterServices()
            DevExpress.Mvvm.ServiceContainer.Default.RegisterService(New Services.ModuleTypesResolver())
        End Sub
        Private Shared Sub RegisterServices(ByVal serviceContainer As IServiceContainer)
            serviceContainer.RegisterService(New Services.ModuleActivator(GetType(Form1).Assembly, GetType(Form1).Namespace & ".Views"))
            serviceContainer.RegisterService(New Services.ModuleLocator(serviceContainer))
        End Sub
        Private Shared Sub RegisterServices(ByVal serviceContainer As IServiceContainer, ByVal mainForm As Object)
            serviceContainer.RegisterService(New Services.TransitionService(TryCast(mainForm, ISupportTransitions)))
        End Sub
        #End Region ' static
        Public Sub New()
            RegisterServices((TryCast(Me, ISupportServices)).ServiceContainer)
        End Sub

        Public Sub RegisterServices(ByVal mainForm As Object)
            RegisterServices((TryCast(Me, ISupportServices)).ServiceContainer, mainForm)
        End Sub

        #Region "Properties"
        Public Overridable Property SelectedModuleType() As ModuleType

        Private transitionBatch As IDisposable

        Protected Overridable Sub OnSelectedModuleTypeChanging(ByVal newValue As ModuleType)
            Dim transitionService = GetService(Of Services.ITransitionService)()
            Dim effective As Boolean = (SelectedModuleType <> ModuleType.None) AndAlso (newValue <> ModuleType.None)
            Dim waitParameter As Object = If((Not IsModuleLoaded(newValue)), DirectCast(newValue, Object), Nothing)
            transitionBatch = transitionService.EnterTransition(effective, (CInt(newValue) > CInt(SelectedModuleType)), waitParameter)

        End Sub

        Protected Overridable Sub OnSelectedModuleTypeChanged()
            Me.RaiseCanExecuteChanged(Sub(x) x.SelectModule(ModuleType.None))
            RaiseSelectedModuleTypeChanged()
            transitionBatch.Dispose()
        End Sub
        #End Region ' Properties

        #Region "Commands"
        <Command(UseCommandManager := False)>
        Public Sub SelectModule(ByVal type As ModuleType)
            SelectedModuleType = type
        End Sub
        Public Function CanSelectModule(ByVal type As ModuleType) As Boolean
            Return type <> SelectedModuleType
        End Function
        #End Region ' Commands
        Public Event SelectedModuleTypeChanged As EventHandler
        Private Sub RaiseSelectedModuleTypeChanged()
            Dim handler = SelectedModuleTypeChangedEvent
            If handler IsNot Nothing Then
                handler(Me, EventArgs.Empty)
            End If
        End Sub
        Private Function GetService(Of TService As Class)() As TService
            Return DirectCast(Me, ISupportServices).ServiceContainer.GetService(Of TService)()
        End Function
        Public Function IsModuleLoaded(ByVal parameter As ModuleType) As Boolean
            Return GetService(Of Services.IModuleLocator)().IsModuleLoaded(parameter)
        End Function
        Public Function GetModule(ByVal parameter As ModuleType) As Object
            Return GetService(Of Services.IModuleLocator)().GetModule(parameter)
        End Function
        Public Function GetName(ByVal parameter As ModuleType) As String
            Return GetService(Of Services.IModuleTypesResolver)().GetName(parameter)
        End Function
        Public Function GetCaption(ByVal parameter As ModuleType) As String
            Return GetService(Of Services.IModuleTypesResolver)().GetCaption(parameter)
        End Function
    End Class
End Namespace
