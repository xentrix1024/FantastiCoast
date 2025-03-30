<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialog1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dialog1))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.NumericUpDownSeaDepth = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NumericUpDownMinSlope = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDownMaxSlope = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ButtonReset = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.NumericUpDownSeaDepth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownMinSlope, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownMaxSlope, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(26, 114)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        Me.OK_Button.UseVisualStyleBackColor = False
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        Me.Cancel_Button.UseVisualStyleBackColor = False
        '
        'NumericUpDownSeaDepth
        '
        Me.NumericUpDownSeaDepth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NumericUpDownSeaDepth.Location = New System.Drawing.Point(114, 7)
        Me.NumericUpDownSeaDepth.Maximum = New Decimal(New Integer() {250, 0, 0, 0})
        Me.NumericUpDownSeaDepth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDownSeaDepth.Name = "NumericUpDownSeaDepth"
        Me.NumericUpDownSeaDepth.Size = New System.Drawing.Size(55, 20)
        Me.NumericUpDownSeaDepth.TabIndex = 2
        Me.NumericUpDownSeaDepth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.NumericUpDownSeaDepth, "The depth of the sea bottom relative to ground" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "level, in metres. Maximum depth i" & _
                "s 250 m.")
        Me.NumericUpDownSeaDepth.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 13)
        Me.Label1.TabIndex = 100
        Me.Label1.Text = "Sea bottom (m)"
        Me.ToolTip1.SetToolTip(Me.Label1, "The depth of the sea bottom relative to ground" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "level, in metres. Maximum depth i" & _
                "s 250 m.")
        '
        'NumericUpDownMinSlope
        '
        Me.NumericUpDownMinSlope.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NumericUpDownMinSlope.DecimalPlaces = 1
        Me.NumericUpDownMinSlope.Location = New System.Drawing.Point(114, 33)
        Me.NumericUpDownMinSlope.Maximum = New Decimal(New Integer() {9999, 0, 0, 65536})
        Me.NumericUpDownMinSlope.Minimum = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.NumericUpDownMinSlope.Name = "NumericUpDownMinSlope"
        Me.NumericUpDownMinSlope.Size = New System.Drawing.Size(55, 20)
        Me.NumericUpDownMinSlope.TabIndex = 3
        Me.NumericUpDownMinSlope.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.NumericUpDownMinSlope, resources.GetString("NumericUpDownMinSlope.ToolTip"))
        Me.NumericUpDownMinSlope.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'NumericUpDownMaxSlope
        '
        Me.NumericUpDownMaxSlope.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NumericUpDownMaxSlope.DecimalPlaces = 1
        Me.NumericUpDownMaxSlope.Location = New System.Drawing.Point(114, 59)
        Me.NumericUpDownMaxSlope.Maximum = New Decimal(New Integer() {9999, 0, 0, 65536})
        Me.NumericUpDownMaxSlope.Minimum = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.NumericUpDownMaxSlope.Name = "NumericUpDownMaxSlope"
        Me.NumericUpDownMaxSlope.Size = New System.Drawing.Size(55, 20)
        Me.NumericUpDownMaxSlope.TabIndex = 4
        Me.NumericUpDownMaxSlope.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ToolTip1.SetToolTip(Me.NumericUpDownMaxSlope, resources.GetString("NumericUpDownMaxSlope.ToolTip"))
        Me.NumericUpDownMaxSlope.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(12, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 13)
        Me.Label2.TabIndex = 101
        Me.Label2.Text = "Minimum slope (m)"
        Me.ToolTip1.SetToolTip(Me.Label2, resources.GetString("Label2.ToolTip"))
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 13)
        Me.Label3.TabIndex = 102
        Me.Label3.Text = "Maximum slope (m)"
        Me.ToolTip1.SetToolTip(Me.Label3, resources.GetString("Label3.ToolTip"))
        '
        'ButtonReset
        '
        Me.ButtonReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonReset.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ButtonReset.Location = New System.Drawing.Point(102, 85)
        Me.ButtonReset.Name = "ButtonReset"
        Me.ButtonReset.Size = New System.Drawing.Size(67, 23)
        Me.ButtonReset.TabIndex = 17
        Me.ButtonReset.Text = "Reset"
        Me.ButtonReset.UseVisualStyleBackColor = False
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 20000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.IsBalloon = True
        Me.ToolTip1.ReshowDelay = 100
        '
        'Dialog1
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(181, 152)
        Me.Controls.Add(Me.ButtonReset)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.NumericUpDownMaxSlope)
        Me.Controls.Add(Me.NumericUpDownMinSlope)
        Me.Controls.Add(Me.NumericUpDownSeaDepth)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Dialog1"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Configuration"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.NumericUpDownSeaDepth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownMinSlope, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownMaxSlope, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents NumericUpDownSeaDepth As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDownMinSlope As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDownMaxSlope As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ButtonReset As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip

End Class
