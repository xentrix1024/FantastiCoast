<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.ThePic = New System.Windows.Forms.PictureBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabelStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelWidth = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabelHeight = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ButtonOpen = New System.Windows.Forms.ToolStripButton()
        Me.ButtonLaunch = New System.Windows.Forms.ToolStripButton()
        Me.ButtonCancel = New System.Windows.Forms.ToolStripButton()
        Me.ButtonSave = New System.Windows.Forms.ToolStripButton()
        Me.ButtonConfig = New System.Windows.Forms.ToolStripButton()
        Me.ButtonAbout = New System.Windows.Forms.ToolStripButton()
        CType(Me.ThePic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ThePic
        '
        Me.ThePic.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ThePic.Location = New System.Drawing.Point(0, 25)
        Me.ThePic.Name = "ThePic"
        Me.ThePic.Size = New System.Drawing.Size(492, 441)
        Me.ThePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ThePic.TabIndex = 0
        Me.ThePic.TabStop = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "FantastiCoast compatible files (*.bmp; *.png; *.asc)|*.bmp; *.png; *.asc|Bitmap f" &
    "iles (*.bmp)|*.bmp|Portable Network Graphics files (*.png)|*.png|ASCII DEM data " &
    "(*.asc)|*.asc"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(166, Byte), Integer), CType(CType(197, Byte), Integer), CType(CType(239, Byte), Integer))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabelStatus, Me.ToolStripStatusLabel3, Me.ToolStripStatusLabelWidth, Me.ToolStripStatusLabelHeight})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 444)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(492, 22)
        Me.StatusStrip1.TabIndex = 12
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabelStatus
        '
        Me.ToolStripStatusLabelStatus.AutoSize = False
        Me.ToolStripStatusLabelStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripStatusLabelStatus.Name = "ToolStripStatusLabelStatus"
        Me.ToolStripStatusLabelStatus.Size = New System.Drawing.Size(120, 17)
        Me.ToolStripStatusLabelStatus.Text = "Idle"
        Me.ToolStripStatusLabelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(357, 17)
        Me.ToolStripStatusLabel3.Spring = True
        '
        'ToolStripStatusLabelWidth
        '
        Me.ToolStripStatusLabelWidth.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripStatusLabelWidth.Name = "ToolStripStatusLabelWidth"
        Me.ToolStripStatusLabelWidth.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripStatusLabelHeight
        '
        Me.ToolStripStatusLabelHeight.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStripStatusLabelHeight.Name = "ToolStripStatusLabelHeight"
        Me.ToolStripStatusLabelHeight.Size = New System.Drawing.Size(0, 17)
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "Bitmap picture (*.bmp)|*.bmp|Portable network graphics (*.png)|*.png"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButtonOpen, Me.ButtonLaunch, Me.ButtonCancel, Me.ButtonSave, Me.ButtonConfig, Me.ButtonAbout})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(492, 25)
        Me.ToolStrip1.TabIndex = 14
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ButtonOpen
        '
        Me.ButtonOpen.AutoToolTip = False
        Me.ButtonOpen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonOpen.Image = CType(resources.GetObject("ButtonOpen.Image"), System.Drawing.Image)
        Me.ButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonOpen.Margin = New System.Windows.Forms.Padding(0, 1, 5, 2)
        Me.ButtonOpen.Name = "ButtonOpen"
        Me.ButtonOpen.Size = New System.Drawing.Size(57, 22)
        Me.ButtonOpen.Text = "&Open"
        '
        'ButtonLaunch
        '
        Me.ButtonLaunch.AutoToolTip = False
        Me.ButtonLaunch.Enabled = False
        Me.ButtonLaunch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonLaunch.Image = CType(resources.GetObject("ButtonLaunch.Image"), System.Drawing.Image)
        Me.ButtonLaunch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonLaunch.Margin = New System.Windows.Forms.Padding(0, 1, 5, 2)
        Me.ButtonLaunch.Name = "ButtonLaunch"
        Me.ButtonLaunch.Size = New System.Drawing.Size(69, 22)
        Me.ButtonLaunch.Text = "&Launch"
        '
        'ButtonCancel
        '
        Me.ButtonCancel.AutoToolTip = False
        Me.ButtonCancel.Enabled = False
        Me.ButtonCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonCancel.Image = CType(resources.GetObject("ButtonCancel.Image"), System.Drawing.Image)
        Me.ButtonCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonCancel.Margin = New System.Windows.Forms.Padding(0, 1, 5, 2)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(66, 22)
        Me.ButtonCancel.Text = "&Cancel"
        '
        'ButtonSave
        '
        Me.ButtonSave.AutoToolTip = False
        Me.ButtonSave.Enabled = False
        Me.ButtonSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonSave.Image = CType(resources.GetObject("ButtonSave.Image"), System.Drawing.Image)
        Me.ButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonSave.Margin = New System.Windows.Forms.Padding(0, 1, 5, 2)
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.Size = New System.Drawing.Size(56, 22)
        Me.ButtonSave.Text = "&Save"
        '
        'ButtonConfig
        '
        Me.ButtonConfig.AutoToolTip = False
        Me.ButtonConfig.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonConfig.Image = CType(resources.GetObject("ButtonConfig.Image"), System.Drawing.Image)
        Me.ButtonConfig.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonConfig.Margin = New System.Windows.Forms.Padding(0, 1, 5, 2)
        Me.ButtonConfig.Name = "ButtonConfig"
        Me.ButtonConfig.Size = New System.Drawing.Size(63, 22)
        Me.ButtonConfig.Text = "Confi&g"
        '
        'ButtonAbout
        '
        Me.ButtonAbout.AutoToolTip = False
        Me.ButtonAbout.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonAbout.Image = CType(resources.GetObject("ButtonAbout.Image"), System.Drawing.Image)
        Me.ButtonAbout.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonAbout.Margin = New System.Windows.Forms.Padding(0, 1, 5, 2)
        Me.ButtonAbout.Name = "ButtonAbout"
        Me.ButtonAbout.Size = New System.Drawing.Size(60, 22)
        Me.ButtonAbout.Text = "&About"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Bisque
        Me.ClientSize = New System.Drawing.Size(492, 466)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ThePic)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(500, 300)
        Me.Name = "Form1"
        Me.Text = "FantastiCoast"
        CType(Me.ThePic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ThePic As System.Windows.Forms.PictureBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabelStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabelWidth As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabelHeight As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ButtonOpen As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonLaunch As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonConfig As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonAbout As System.Windows.Forms.ToolStripButton
    Friend WithEvents ButtonCancel As System.Windows.Forms.ToolStripButton

End Class
