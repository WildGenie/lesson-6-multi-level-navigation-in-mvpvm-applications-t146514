Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports MvpvmNavigation.Model
Imports DevExpress.Mvvm
Imports DevExpress.XtraNavBar
Imports DevExpress.Mvvm.POCO
Imports MvpvmNavigation.ViewModels
Imports MvpvmNavigation.Presenter
Imports DevExpress.XtraBars.Navigation
Imports DevExpress.XtraBars
Imports DevExpress.Utils
Imports DevExpress.Utils.Animation


Namespace MvpvmNavigation
    Partial Public Class Form1
        Inherits DevExpress.XtraBars.Ribbon.RibbonForm
        Implements ISupportTransitions

        Public Sub New()
            InitializeComponent()
            Me.viewModelCore = ViewModelSource.Create(Of MainFormViewModel)()
            Me.presenterCore = CreatePresenter()
            ViewModel.RegisterServices(Me)
        End Sub
        Private viewModelCore As MainFormViewModel
        Public ReadOnly Property ViewModel() As MainFormViewModel
            Get
                Return viewModelCore
            End Get
        End Property
        Private presenterCore As MainFormPresenter
        Public ReadOnly Property Presenter() As MainFormPresenter
            Get
                Return presenterCore
            End Get
        End Property
        Protected Overridable Function CreatePresenter() As MainFormPresenter
            Return New MainFormPresenter(panelControl1, ViewModel)
        End Function
        Protected Overrides Sub OnClosed(ByVal e As EventArgs)
            Presenter.Dispose()
            MyBase.OnClosed(e)
        End Sub
        Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
            MyBase.OnLoad(e)
            Dim modules() As ModuleType = { ModuleType.ModuleA, ModuleType.ModuleB }
            ViewModel.SelectedModuleType = modules(0)
            RegisterNavigationItems(navBarControl1, modules)
            RegisterNavigationMenuItems(barSubItem1, modules)
        End Sub
        Private Sub RegisterNavigationItems(ByVal navBar As NavBarControl, ByVal modules() As ModuleType)
            Dim groups(modules.Length - 1) As NavBarGroup
            For i As Integer = 0 To modules.Length - 1
                Dim moduleType As ModuleType = modules(i)
                Dim navGroup As New NavBarGroup()
                navGroup.Tag = modules(i)
                navGroup.Name = "navGroup" & ViewModel.GetName(moduleType)
                navGroup.Caption = ViewModel.GetCaption(moduleType)
                groups(i) = navGroup
            Next i
            navBar.Groups.AddRange(groups)
        End Sub
        Private Sub RegisterNavigationMenuItems(ByVal menuItem As BarLinkContainerItem, ByVal modules() As ModuleType)
            Dim items(modules.Length - 1) As BarItem
            For i As Integer = 0 To modules.Length - 1
                Dim moduleType As ModuleType = modules(i)
                Dim biModule As New BarCheckItem()
                biModule.Caption = ViewModel.GetCaption(moduleType)
                biModule.Name = "biModule" & ViewModel.GetName(moduleType)
                biModule.GroupIndex = 1
                biModule.BindCommand(Sub(t) ViewModel.SelectModule(t), ViewModel, Function() moduleType)
                items(i) = biModule
            Next i
            menuItem.AddItems(items)
        End Sub
        Private Sub officeNavigationBar1_RegisterItem(ByVal sender As Object, ByVal e As NavigationBarNavigationClientItemEventArgs) Handles officeNavigationBar1.RegisterItem
            Dim navGroup As NavBarGroup = CType(e.NavigationItem, NavBarGroup)
            Dim moduleType As ModuleType = DirectCast(navGroup.Tag, ModuleType)
            e.Item.Tag = moduleType
            e.Item.Text = ViewModel.GetCaption(moduleType)
            e.Item.Name = "navItem" & ViewModel.GetName(moduleType)
            e.Item.BindCommand(Sub(t) ViewModel.SelectModule(t), ViewModel, Function() moduleType)
        End Sub

        #Region "ISupportTransitions Members"
        Private Sub ISupportTransitions_StartTransition(ByVal forward As Boolean, ByVal waitParameter As Object) Implements ISupportTransitions.StartTransition
            Dim transition = transitionManager1.Transitions(panelControl1)
            Dim animator = TryCast(transition.TransitionType, DevExpress.Utils.Animation.SlideFadeTransition)
            animator.Parameters.EffectOptions = If(forward, PushEffectOptions.FromRight, PushEffectOptions.FromLeft)
            If waitParameter Is Nothing Then
                transition.ShowWaitingIndicator = DefaultBoolean.False
            Else
                transition.ShowWaitingIndicator = DefaultBoolean.True
                transition.WaitingIndicatorProperties.Caption = ViewModel.GetCaption(DirectCast(waitParameter, ModuleType))
                transition.WaitingIndicatorProperties.Description = "Loading..."
                transition.WaitingIndicatorProperties.ContentMinSize = New System.Drawing.Size(160, 0)
            End If
            transitionManager1.StartTransition(panelControl1)
        End Sub
        Private Sub ISupportTransitions_EndTransition() Implements ISupportTransitions.EndTransition
            transitionManager1.EndTransition()
        End Sub
        #End Region
    End Class
End Namespace
