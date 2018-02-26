Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports DevExpress.XtraBars.Ribbon
Imports MvpvmNavigation.ViewModels.Module_A
Imports DevExpress.Mvvm

Namespace MvpvmNavigation.Views
    Partial Public Class View1
        Inherits BaseModuleControl
        Implements IRibbonModule

        Public Sub New()
            MyBase.New(AddressOf CreateViewModel(Of ModuleAViewModel))
            InitializeComponent()
            BindCommands()
            System.Threading.Thread.Sleep(1000)
        End Sub
        Private ReadOnly Property IRibbonModule_Ribbon() As RibbonControl Implements IRibbonModule.Ribbon
            Get
                Return ribbonControl1
            End Get
        End Property
        Public ReadOnly Overloads Property ViewModel() As ModuleAViewModel
            Get
                Return GetViewModel(Of ModuleAViewModel)()
            End Get
        End Property

        Private Sub BindCommands()
            buttonShow.BindCommand(Sub() ViewModel.ShowEditForm(), ViewModel)
        End Sub

        Protected Overrides Sub OnInitServices(ByVal serviceContainer As IServiceContainer)
            serviceContainer.RegisterService(New Services.EditFormService(Model.ModuleType.ModuleA_EditForm))
        End Sub
    End Class
End Namespace
