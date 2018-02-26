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
    Partial Public Class View2EditForm
        Inherits BaseModuleControl

        Public Sub New()
            MyBase.New(AddressOf CreateViewModel(Of ModuleBEditFormViewModel))
            InitializeComponent()
            BindCommands()
        End Sub

        Private Sub BindCommands()
            buttonOK.BindCommand(Sub() ViewModel.OK(), ViewModel)
            buttonCancel.BindCommand(Sub() ViewModel.Cancel(), ViewModel)
        End Sub

        Public ReadOnly Overloads Property ViewModel() As ModuleBEditFormViewModel
            Get
                Return GetViewModel(Of ModuleBEditFormViewModel)()
            End Get
        End Property
    End Class
End Namespace
