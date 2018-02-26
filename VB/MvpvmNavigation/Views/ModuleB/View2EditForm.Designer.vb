Namespace MvpvmNavigation.Views
    Partial Public Class View2EditForm
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
            Me.panelControl1 = New DevExpress.XtraEditors.PanelControl()
            Me.labelControl1 = New DevExpress.XtraEditors.LabelControl()
            Me.buttonCancel = New DevExpress.XtraEditors.SimpleButton()
            Me.buttonOK = New DevExpress.XtraEditors.SimpleButton()
            DirectCast(Me.panelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panelControl1.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' panelControl1
            ' 
            Me.panelControl1.Appearance.BackColor = System.Drawing.Color.DarkGoldenrod
            Me.panelControl1.Appearance.Options.UseBackColor = True
            Me.panelControl1.Controls.Add(Me.buttonOK)
            Me.panelControl1.Controls.Add(Me.buttonCancel)
            Me.panelControl1.Controls.Add(Me.labelControl1)
            Me.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.panelControl1.Location = New System.Drawing.Point(0, 0)
            Me.panelControl1.Name = "panelControl1"
            Me.panelControl1.Size = New System.Drawing.Size(397, 259)
            Me.panelControl1.TabIndex = 0
            ' 
            ' labelControl1
            ' 
            Me.labelControl1.Appearance.BackColor = System.Drawing.Color.Khaki
            Me.labelControl1.Appearance.Font = New System.Drawing.Font("Segoe UI", 25F)
            Me.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            Me.labelControl1.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
            Me.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
            Me.labelControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.labelControl1.Location = New System.Drawing.Point(2, 2)
            Me.labelControl1.Name = "labelControl1"
            Me.labelControl1.Size = New System.Drawing.Size(393, 255)
            Me.labelControl1.TabIndex = 0
            Me.labelControl1.Text = "Module B Edit Form"
            ' 
            ' buttonCancel
            ' 
            Me.buttonCancel.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
            Me.buttonCancel.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25F)
            Me.buttonCancel.Appearance.Options.UseFont = True
            Me.buttonCancel.Location = New System.Drawing.Point(310, 226)
            Me.buttonCancel.Name = "buttonCancel"
            Me.buttonCancel.Size = New System.Drawing.Size(75, 23)
            Me.buttonCancel.TabIndex = 1
            Me.buttonCancel.Text = "Cancel"
            ' 
            ' buttonOK
            ' 
            Me.buttonOK.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
            Me.buttonOK.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25F)
            Me.buttonOK.Appearance.Options.UseFont = True
            Me.buttonOK.Location = New System.Drawing.Point(229, 226)
            Me.buttonOK.Name = "buttonOK"
            Me.buttonOK.Size = New System.Drawing.Size(75, 23)
            Me.buttonOK.TabIndex = 2
            Me.buttonOK.Text = "OK"
            ' 
            ' View2EditForm
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.panelControl1)
            Me.Name = "View2EditForm"
            Me.Size = New System.Drawing.Size(397, 259)
            DirectCast(Me.panelControl1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.panelControl1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        #End Region

        Private panelControl1 As DevExpress.XtraEditors.PanelControl
        Private buttonOK As DevExpress.XtraEditors.SimpleButton
        Private buttonCancel As DevExpress.XtraEditors.SimpleButton
        Private labelControl1 As DevExpress.XtraEditors.LabelControl
    End Class
End Namespace
