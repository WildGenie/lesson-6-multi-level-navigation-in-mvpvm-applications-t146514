Namespace MvpvmNavigation
    Partial Public Class Form1
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(Form1))
            Dim transition1 As New DevExpress.Utils.Animation.Transition()
            Dim slideFadeTransition1 As New DevExpress.Utils.Animation.SlideFadeTransition()
            Me.panelControl1 = New DevExpress.XtraEditors.PanelControl()
            Me.defaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
            Me.navBarControl1 = New DevExpress.XtraNavBar.NavBarControl()
            Me.officeNavigationBar1 = New DevExpress.XtraBars.Navigation.OfficeNavigationBar()
            Me.formAssistant1 = New DevExpress.XtraBars.FormAssistant()
            Me.ribbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
            Me.barSubItem1 = New DevExpress.XtraBars.BarSubItem()
            Me.ribbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
            Me.ribbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
            Me.ribbonStatusBar1 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
            Me.transitionManager1 = New DevExpress.Utils.Animation.TransitionManager()
            DirectCast(Me.panelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.navBarControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.officeNavigationBar1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' panelControl1
            ' 
            Me.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.panelControl1.Location = New System.Drawing.Point(140, 147)
            Me.panelControl1.Name = "panelControl1"
            Me.panelControl1.Size = New System.Drawing.Size(528, 180)
            Me.panelControl1.TabIndex = 2
            ' 
            ' defaultLookAndFeel1
            ' 
            Me.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2013"
            ' 
            ' navBarControl1
            ' 
            Me.navBarControl1.ActiveGroup = Nothing
            Me.navBarControl1.Dock = System.Windows.Forms.DockStyle.Left
            Me.navBarControl1.Location = New System.Drawing.Point(0, 147)
            Me.navBarControl1.Name = "navBarControl1"
            Me.navBarControl1.OptionsNavPane.ExpandedWidth = 140
            Me.navBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane
            Me.navBarControl1.Size = New System.Drawing.Size(140, 180)
            Me.navBarControl1.TabIndex = 0
            Me.navBarControl1.Text = "navBarControl1"
            ' 
            ' officeNavigationBar1
            ' 
            Me.officeNavigationBar1.AutoSize = False
            Me.officeNavigationBar1.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.officeNavigationBar1.Location = New System.Drawing.Point(0, 327)
            Me.officeNavigationBar1.Name = "officeNavigationBar1"
            Me.officeNavigationBar1.NavigationClient = Me.navBarControl1
            Me.officeNavigationBar1.Size = New System.Drawing.Size(668, 45)
            Me.officeNavigationBar1.TabIndex = 1
            Me.officeNavigationBar1.Text = "officeNavigationBar1"
            ' 
            ' ribbonControl1
            ' 
            Me.ribbonControl1.ExpandCollapseItem.Id = 0
            Me.ribbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() { Me.ribbonControl1.ExpandCollapseItem, Me.barSubItem1})
            Me.ribbonControl1.Location = New System.Drawing.Point(0, 0)
            Me.ribbonControl1.MaxItemId = 3
            Me.ribbonControl1.Name = "ribbonControl1"
            Me.ribbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() { Me.ribbonPage1})
            Me.ribbonControl1.Size = New System.Drawing.Size(668, 147)
            Me.ribbonControl1.StatusBar = Me.ribbonStatusBar1
            ' 
            ' barSubItem1
            ' 
            Me.barSubItem1.Caption = "Modules"
            Me.barSubItem1.Glyph = (DirectCast(resources.GetObject("barSubItem1.Glyph"), System.Drawing.Image))
            Me.barSubItem1.Id = 2
            Me.barSubItem1.Name = "barSubItem1"
            Me.barSubItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
            ' 
            ' ribbonPage1
            ' 
            Me.ribbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() { Me.ribbonPageGroup1})
            Me.ribbonPage1.Name = "ribbonPage1"
            Me.ribbonPage1.Text = "Views"
            ' 
            ' ribbonPageGroup1
            ' 
            Me.ribbonPageGroup1.AllowTextClipping = False
            Me.ribbonPageGroup1.ItemLinks.Add(Me.barSubItem1)
            Me.ribbonPageGroup1.Name = "ribbonPageGroup1"
            Me.ribbonPageGroup1.Text = "Navigation"
            ' 
            ' ribbonStatusBar1
            ' 
            Me.ribbonStatusBar1.Location = New System.Drawing.Point(0, 372)
            Me.ribbonStatusBar1.Name = "ribbonStatusBar1"
            Me.ribbonStatusBar1.Ribbon = Me.ribbonControl1
            Me.ribbonStatusBar1.Size = New System.Drawing.Size(668, 23)
            ' 
            ' transitionManager1
            ' 
            transition1.Control = Me.panelControl1
            slideFadeTransition1.Parameters.Background = System.Drawing.Color.Empty
            transition1.TransitionType = slideFadeTransition1
            Me.transitionManager1.Transitions.Add(transition1)
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(668, 395)
            Me.Controls.Add(Me.panelControl1)
            Me.Controls.Add(Me.navBarControl1)
            Me.Controls.Add(Me.officeNavigationBar1)
            Me.Controls.Add(Me.ribbonStatusBar1)
            Me.Controls.Add(Me.ribbonControl1)
            Me.Name = "Form1"
            Me.Ribbon = Me.ribbonControl1
            Me.StatusBar = Me.ribbonStatusBar1
            Me.Text = "Form1"
            DirectCast(Me.panelControl1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.navBarControl1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.officeNavigationBar1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        #End Region

        Private defaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
        Private navBarControl1 As DevExpress.XtraNavBar.NavBarControl
        Private WithEvents officeNavigationBar1 As DevExpress.XtraBars.Navigation.OfficeNavigationBar
        Private panelControl1 As DevExpress.XtraEditors.PanelControl
        Private formAssistant1 As DevExpress.XtraBars.FormAssistant
        Private ribbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
        Private ribbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
        Private ribbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
        Private barSubItem1 As DevExpress.XtraBars.BarSubItem
        Private ribbonStatusBar1 As DevExpress.XtraBars.Ribbon.RibbonStatusBar
        Private transitionManager1 As DevExpress.Utils.Animation.TransitionManager
    End Class
End Namespace

