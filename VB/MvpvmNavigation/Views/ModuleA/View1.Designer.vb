Namespace MvpvmNavigation.Views
    Partial Public Class View1
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

        #Region "Component Designer generated code"

        ''' <summary> 
        ''' Required method for Designer support - do not modify 
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(View1))
            Me.labelControl1 = New DevExpress.XtraEditors.LabelControl()
            Me.formAssistant1 = New DevExpress.XtraBars.FormAssistant()
            Me.ribbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
            Me.buttonShow = New DevExpress.XtraBars.BarButtonItem()
            Me.ribbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
            Me.ribbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
            Me.ribbonStatusBar1 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
            DirectCast(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' labelControl1
            ' 
            Me.labelControl1.Appearance.BackColor = System.Drawing.Color.LightSkyBlue
            Me.labelControl1.Appearance.Font = New System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold)
            Me.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
            Me.labelControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.labelControl1.Location = New System.Drawing.Point(0, 140)
            Me.labelControl1.Name = "labelControl1"
            Me.labelControl1.Size = New System.Drawing.Size(348, 131)
            Me.labelControl1.TabIndex = 0
            Me.labelControl1.Text = "Module A"
            ' 
            ' ribbonControl1
            ' 
            Me.ribbonControl1.ExpandCollapseItem.Id = 0
            Me.ribbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() { Me.ribbonControl1.ExpandCollapseItem, Me.buttonShow})
            Me.ribbonControl1.Location = New System.Drawing.Point(0, 0)
            Me.ribbonControl1.MaxItemId = 2
            Me.ribbonControl1.Name = "ribbonControl1"
            Me.ribbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() { Me.ribbonPage1})
            Me.ribbonControl1.Size = New System.Drawing.Size(348, 140)
            Me.ribbonControl1.StatusBar = Me.ribbonStatusBar1
            ' 
            ' buttonShow
            ' 
            Me.buttonShow.Caption = "Show Edit Form"
            Me.buttonShow.CategoryGuid = New System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537")
            Me.buttonShow.Glyph = (DirectCast(resources.GetObject("buttonShow.Glyph"), System.Drawing.Image))
            Me.buttonShow.Id = 1
            Me.buttonShow.LargeGlyph = (DirectCast(resources.GetObject("buttonShow.LargeGlyph"), System.Drawing.Image))
            Me.buttonShow.Name = "buttonShow"
            ' 
            ' ribbonPage1
            ' 
            Me.ribbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() { Me.ribbonPageGroup1})
            Me.ribbonPage1.Name = "ribbonPage1"
            Me.ribbonPage1.Text = "Module A"
            ' 
            ' ribbonPageGroup1
            ' 
            Me.ribbonPageGroup1.AllowTextClipping = False
            Me.ribbonPageGroup1.ItemLinks.Add(Me.buttonShow)
            Me.ribbonPageGroup1.Name = "ribbonPageGroup1"
            Me.ribbonPageGroup1.Text = "Actions"
            ' 
            ' ribbonStatusBar1
            ' 
            Me.ribbonStatusBar1.Location = New System.Drawing.Point(0, 271)
            Me.ribbonStatusBar1.Name = "ribbonStatusBar1"
            Me.ribbonStatusBar1.Ribbon = Me.ribbonControl1
            Me.ribbonStatusBar1.Size = New System.Drawing.Size(348, 28)
            ' 
            ' View1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.labelControl1)
            Me.Controls.Add(Me.ribbonStatusBar1)
            Me.Controls.Add(Me.ribbonControl1)
            Me.Name = "View1"
            Me.Size = New System.Drawing.Size(348, 299)
            DirectCast(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub

        #End Region

        Private labelControl1 As DevExpress.XtraEditors.LabelControl
        Private formAssistant1 As DevExpress.XtraBars.FormAssistant
        Private ribbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
        Private ribbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
        Private ribbonStatusBar1 As DevExpress.XtraBars.Ribbon.RibbonStatusBar
        Private buttonShow As DevExpress.XtraBars.BarButtonItem
        Private ribbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup

    End Class
End Namespace
