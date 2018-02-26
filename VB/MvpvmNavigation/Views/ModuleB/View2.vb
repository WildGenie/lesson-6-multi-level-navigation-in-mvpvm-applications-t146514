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
Imports DevExpress.Mvvm
Imports MvpvmNavigation.ViewModels

Namespace MvpvmNavigation.Views
    Partial Public Class View2
        Inherits BaseModuleControl
        Implements IRibbonModule

        Public Sub New()
            MyBase.New(AddressOf CreateViewModel(Of ModuleBViewModel))
            InitializeComponent()
            BindCommands()
            System.Threading.Thread.Sleep(1000)
        End Sub
        Protected Overrides Sub OnInitServices(ByVal serviceContainer As IServiceContainer)
            serviceContainer.RegisterService(New Services.EditFormService(Model.ModuleType.ModuleB_EditForm))
        End Sub
        Private Sub BindCommands()
            buttonShow.BindCommand(Sub() ViewModel.ShowEditForm(), ViewModel)
        End Sub
        Public ReadOnly Overloads Property ViewModel() As ModuleBViewModel
            Get
                Return GetViewModel(Of ModuleBViewModel)()
            End Get
        End Property
        Private ReadOnly Property IRibbonModule_Ribbon() As RibbonControl Implements IRibbonModule.Ribbon
            Get
                Return ribbonControl1
            End Get
        End Property
    End Class
End Namespace
