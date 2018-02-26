Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports MvpvmNavigation.ViewModels

Namespace MvpvmNavigation.Views
    Partial Public Class View1EditForm
        Inherits BaseModuleControl

        Public Sub New()
            MyBase.New(AddressOf CreateViewModel(Of ModuleAEditFormViewModel))
            InitializeComponent()
            BindCommands()
        End Sub

        Private Sub BindCommands()
            buttonOK.BindCommand(Sub() ViewModel.OK(), ViewModel)
            buttonCancel.BindCommand(Sub() ViewModel.Cancel(), ViewModel)
        End Sub

        Public ReadOnly Overloads Property ViewModel() As ModuleAEditFormViewModel
            Get
                Return GetViewModel(Of ModuleAEditFormViewModel)()
            End Get
        End Property
    End Class
End Namespace
