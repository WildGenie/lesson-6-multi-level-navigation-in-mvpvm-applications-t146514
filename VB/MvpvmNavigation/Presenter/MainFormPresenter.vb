Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports DevExpress.XtraEditors
Imports MvpvmNavigation.ViewModels
Imports DevExpress.Mvvm
Imports MvpvmNavigation.Model
Imports System.Windows.Forms
Imports DevExpress.XtraBars.Ribbon

Namespace MvpvmNavigation.Presenter
    Public Class MainFormPresenter
        Implements IDisposable

        Private modulesPanel As PanelControl
        Private viewModelCore As MainFormViewModel
        Public Sub New(ByVal modulesPanel As PanelControl, ByVal viewModel As MainFormViewModel)
            Me.modulesPanel = modulesPanel
            Me.viewModelCore = viewModel
            AddHandler Me.ViewModel.SelectedModuleTypeChanged, AddressOf ViewModel_SelectedModuleTypeChanged
        End Sub
        Public Sub Dispose() Implements IDisposable.Dispose
            RemoveHandler ViewModel.SelectedModuleTypeChanged, AddressOf ViewModel_SelectedModuleTypeChanged
        End Sub
        Public ReadOnly Property ViewModel() As MainFormViewModel
            Get
                Return viewModelCore
            End Get
        End Property
        Private Sub ViewModel_SelectedModuleTypeChanged(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim mainForm As RibbonForm = TryCast(modulesPanel.FindForm(), RibbonForm)
            If mainForm IsNot Nothing Then
                mainForm.Ribbon.UnMergeRibbon()
                If mainForm.Ribbon.StatusBar IsNot Nothing Then
                    mainForm.Ribbon.StatusBar.UnMergeStatusBar()
                End If
            End If
            modulesPanel.Controls.Clear()
            Dim [module] As Control = TryCast(ViewModel.GetModule(ViewModel.SelectedModuleType), Control)
            ViewModelHelper.EnsureModuleViewModel([module], ViewModel)
            If [module] IsNot Nothing Then
                [module].Dock = DockStyle.Fill
                modulesPanel.Controls.Add([module])
            End If
            If mainForm IsNot Nothing Then
                Dim ribbonModule As IRibbonModule = TryCast([module], IRibbonModule)
                If ribbonModule IsNot Nothing Then
                    mainForm.Ribbon.MergeRibbon(ribbonModule.Ribbon)
                    If mainForm.Ribbon.StatusBar IsNot Nothing Then
                        mainForm.Ribbon.StatusBar.MergeStatusBar(ribbonModule.Ribbon.StatusBar)
                    End If
                End If
            End If
        End Sub
    End Class
End Namespace
