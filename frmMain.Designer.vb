<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.grpbxTx1 = New System.Windows.Forms.GroupBox()
        Me.chkTx1Rotation = New System.Windows.Forms.CheckBox()
        Me.lblTx1Rotation = New System.Windows.Forms.Label()
        Me.chkTx1Scale = New System.Windows.Forms.CheckBox()
        Me.lblTx1Scale = New System.Windows.Forms.Label()
        Me.chkTx1Astigmatismy = New System.Windows.Forms.CheckBox()
        Me.chkTx1Astigmatismx = New System.Windows.Forms.CheckBox()
        Me.chkTx1Defocus = New System.Windows.Forms.CheckBox()
        Me.chkTx1Tilty = New System.Windows.Forms.CheckBox()
        Me.chkTx1Tiltx = New System.Windows.Forms.CheckBox()
        Me.chkTx1Offsety = New System.Windows.Forms.CheckBox()
        Me.chkTx1Offsetx = New System.Windows.Forms.CheckBox()
        Me.lblTx1Astigmatismy = New System.Windows.Forms.Label()
        Me.lblTx1Astigmatismx = New System.Windows.Forms.Label()
        Me.lblTx1Focus = New System.Windows.Forms.Label()
        Me.lblTx1Tilty = New System.Windows.Forms.Label()
        Me.lblTx1Tiltx = New System.Windows.Forms.Label()
        Me.lblTx1Offsety = New System.Windows.Forms.Label()
        Me.lblTx1Offsetx = New System.Windows.Forms.Label()
        Me.cmdOptimisation = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.cmdOverlapMatrix = New System.Windows.Forms.Button()
        Me.cmdLoad = New System.Windows.Forms.Button()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.StatusStripLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.grpbxRx1 = New System.Windows.Forms.GroupBox()
        Me.chkRx1Imagex = New System.Windows.Forms.CheckBox()
        Me.lblRx1Imagex = New System.Windows.Forms.Label()
        Me.chkRx1FFTHeight = New System.Windows.Forms.CheckBox()
        Me.chkRx1FFTWidth = New System.Windows.Forms.CheckBox()
        Me.chkRx1FFTy = New System.Windows.Forms.CheckBox()
        Me.chkRx1FFTx = New System.Windows.Forms.CheckBox()
        Me.chkRx1ImageHeight = New System.Windows.Forms.CheckBox()
        Me.chkRx1ImageWidth = New System.Windows.Forms.CheckBox()
        Me.chkRx1Imagey = New System.Windows.Forms.CheckBox()
        Me.lblRx1FFTHeight = New System.Windows.Forms.Label()
        Me.lblRx1FFTWidth = New System.Windows.Forms.Label()
        Me.lblRx1FFTy = New System.Windows.Forms.Label()
        Me.lblRx1FFTx = New System.Windows.Forms.Label()
        Me.lblRx1ImageHeight = New System.Windows.Forms.Label()
        Me.lblRx1ImageWidth = New System.Windows.Forms.Label()
        Me.lblRx1Imagey = New System.Windows.Forms.Label()
        Me.lblPolarisation = New System.Windows.Forms.Label()
        Me.cmbPolarisation = New System.Windows.Forms.ComboBox()
        Me.lblMinMode = New System.Windows.Forms.Label()
        Me.nudMinMode = New System.Windows.Forms.NumericUpDown()
        Me.lblMultiplier = New System.Windows.Forms.Label()
        Me.nudMultiplier = New System.Windows.Forms.NumericUpDown()
        Me.lblAlignmentMetric = New System.Windows.Forms.Label()
        Me.cmbAlignmentMetric = New System.Windows.Forms.ComboBox()
        Me.nudMaxMode = New System.Windows.Forms.NumericUpDown()
        Me.lblMaxMode = New System.Windows.Forms.Label()
        Me.cmdAlignCameraCrop = New System.Windows.Forms.Button()
        Me.cmdAlignFFTCrop = New System.Windows.Forms.Button()
        Me.cmdSaveModes = New System.Windows.Forms.Button()
        Me.cmdLinPolCircPol = New System.Windows.Forms.Button()
        Me.grpbxTx1.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.grpbxRx1.SuspendLayout()
        CType(Me.nudMinMode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMultiplier, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMaxMode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpbxTx1
        '
        Me.grpbxTx1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpbxTx1.Controls.Add(Me.chkTx1Rotation)
        Me.grpbxTx1.Controls.Add(Me.lblTx1Rotation)
        Me.grpbxTx1.Controls.Add(Me.chkTx1Scale)
        Me.grpbxTx1.Controls.Add(Me.lblTx1Scale)
        Me.grpbxTx1.Controls.Add(Me.chkTx1Astigmatismy)
        Me.grpbxTx1.Controls.Add(Me.chkTx1Astigmatismx)
        Me.grpbxTx1.Controls.Add(Me.chkTx1Defocus)
        Me.grpbxTx1.Controls.Add(Me.chkTx1Tilty)
        Me.grpbxTx1.Controls.Add(Me.chkTx1Tiltx)
        Me.grpbxTx1.Controls.Add(Me.chkTx1Offsety)
        Me.grpbxTx1.Controls.Add(Me.chkTx1Offsetx)
        Me.grpbxTx1.Controls.Add(Me.lblTx1Astigmatismy)
        Me.grpbxTx1.Controls.Add(Me.lblTx1Astigmatismx)
        Me.grpbxTx1.Controls.Add(Me.lblTx1Focus)
        Me.grpbxTx1.Controls.Add(Me.lblTx1Tilty)
        Me.grpbxTx1.Controls.Add(Me.lblTx1Tiltx)
        Me.grpbxTx1.Controls.Add(Me.lblTx1Offsety)
        Me.grpbxTx1.Controls.Add(Me.lblTx1Offsetx)
        Me.grpbxTx1.Location = New System.Drawing.Point(13, 91)
        Me.grpbxTx1.Name = "grpbxTx1"
        Me.grpbxTx1.Size = New System.Drawing.Size(165, 254)
        Me.grpbxTx1.TabIndex = 33
        Me.grpbxTx1.TabStop = False
        Me.grpbxTx1.Text = "Tx 1"
        '
        'chkTx1Rotation
        '
        Me.chkTx1Rotation.AutoSize = True
        Me.chkTx1Rotation.Location = New System.Drawing.Point(144, 36)
        Me.chkTx1Rotation.Name = "chkTx1Rotation"
        Me.chkTx1Rotation.Size = New System.Drawing.Size(15, 14)
        Me.chkTx1Rotation.TabIndex = 48
        Me.chkTx1Rotation.UseVisualStyleBackColor = True
        '
        'lblTx1Rotation
        '
        Me.lblTx1Rotation.AutoSize = True
        Me.lblTx1Rotation.Location = New System.Drawing.Point(37, 38)
        Me.lblTx1Rotation.Name = "lblTx1Rotation"
        Me.lblTx1Rotation.Size = New System.Drawing.Size(47, 13)
        Me.lblTx1Rotation.TabIndex = 47
        Me.lblTx1Rotation.Text = "Rotation"
        '
        'chkTx1Scale
        '
        Me.chkTx1Scale.AutoSize = True
        Me.chkTx1Scale.Location = New System.Drawing.Point(144, 13)
        Me.chkTx1Scale.Name = "chkTx1Scale"
        Me.chkTx1Scale.Size = New System.Drawing.Size(15, 14)
        Me.chkTx1Scale.TabIndex = 46
        Me.chkTx1Scale.UseVisualStyleBackColor = True
        '
        'lblTx1Scale
        '
        Me.lblTx1Scale.AutoSize = True
        Me.lblTx1Scale.Location = New System.Drawing.Point(42, 13)
        Me.lblTx1Scale.Name = "lblTx1Scale"
        Me.lblTx1Scale.Size = New System.Drawing.Size(34, 13)
        Me.lblTx1Scale.TabIndex = 45
        Me.lblTx1Scale.Text = "Scale"
        '
        'chkTx1Astigmatismy
        '
        Me.chkTx1Astigmatismy.AutoSize = True
        Me.chkTx1Astigmatismy.Location = New System.Drawing.Point(144, 219)
        Me.chkTx1Astigmatismy.Name = "chkTx1Astigmatismy"
        Me.chkTx1Astigmatismy.Size = New System.Drawing.Size(15, 14)
        Me.chkTx1Astigmatismy.TabIndex = 43
        Me.chkTx1Astigmatismy.UseVisualStyleBackColor = True
        '
        'chkTx1Astigmatismx
        '
        Me.chkTx1Astigmatismx.AutoSize = True
        Me.chkTx1Astigmatismx.Location = New System.Drawing.Point(144, 193)
        Me.chkTx1Astigmatismx.Name = "chkTx1Astigmatismx"
        Me.chkTx1Astigmatismx.Size = New System.Drawing.Size(15, 14)
        Me.chkTx1Astigmatismx.TabIndex = 42
        Me.chkTx1Astigmatismx.UseVisualStyleBackColor = True
        '
        'chkTx1Defocus
        '
        Me.chkTx1Defocus.AutoSize = True
        Me.chkTx1Defocus.Location = New System.Drawing.Point(144, 167)
        Me.chkTx1Defocus.Name = "chkTx1Defocus"
        Me.chkTx1Defocus.Size = New System.Drawing.Size(15, 14)
        Me.chkTx1Defocus.TabIndex = 41
        Me.chkTx1Defocus.UseVisualStyleBackColor = True
        '
        'chkTx1Tilty
        '
        Me.chkTx1Tilty.AutoSize = True
        Me.chkTx1Tilty.Location = New System.Drawing.Point(144, 141)
        Me.chkTx1Tilty.Name = "chkTx1Tilty"
        Me.chkTx1Tilty.Size = New System.Drawing.Size(15, 14)
        Me.chkTx1Tilty.TabIndex = 40
        Me.chkTx1Tilty.UseVisualStyleBackColor = True
        '
        'chkTx1Tiltx
        '
        Me.chkTx1Tiltx.AutoSize = True
        Me.chkTx1Tiltx.Location = New System.Drawing.Point(144, 113)
        Me.chkTx1Tiltx.Name = "chkTx1Tiltx"
        Me.chkTx1Tiltx.Size = New System.Drawing.Size(15, 14)
        Me.chkTx1Tiltx.TabIndex = 39
        Me.chkTx1Tiltx.UseVisualStyleBackColor = True
        '
        'chkTx1Offsety
        '
        Me.chkTx1Offsety.AutoSize = True
        Me.chkTx1Offsety.Location = New System.Drawing.Point(144, 87)
        Me.chkTx1Offsety.Name = "chkTx1Offsety"
        Me.chkTx1Offsety.Size = New System.Drawing.Size(15, 14)
        Me.chkTx1Offsety.TabIndex = 38
        Me.chkTx1Offsety.UseVisualStyleBackColor = True
        '
        'chkTx1Offsetx
        '
        Me.chkTx1Offsetx.AutoSize = True
        Me.chkTx1Offsetx.Location = New System.Drawing.Point(144, 61)
        Me.chkTx1Offsetx.Name = "chkTx1Offsetx"
        Me.chkTx1Offsetx.Size = New System.Drawing.Size(15, 14)
        Me.chkTx1Offsetx.TabIndex = 37
        Me.chkTx1Offsetx.UseVisualStyleBackColor = True
        '
        'lblTx1Astigmatismy
        '
        Me.lblTx1Astigmatismy.AutoSize = True
        Me.lblTx1Astigmatismy.Location = New System.Drawing.Point(6, 219)
        Me.lblTx1Astigmatismy.Name = "lblTx1Astigmatismy"
        Me.lblTx1Astigmatismy.Size = New System.Drawing.Size(70, 13)
        Me.lblTx1Astigmatismy.TabIndex = 19
        Me.lblTx1Astigmatismy.Text = "Astigmatism y"
        '
        'lblTx1Astigmatismx
        '
        Me.lblTx1Astigmatismx.AutoSize = True
        Me.lblTx1Astigmatismx.Location = New System.Drawing.Point(6, 193)
        Me.lblTx1Astigmatismx.Name = "lblTx1Astigmatismx"
        Me.lblTx1Astigmatismx.Size = New System.Drawing.Size(70, 13)
        Me.lblTx1Astigmatismx.TabIndex = 17
        Me.lblTx1Astigmatismx.Text = "Astigmatism x"
        '
        'lblTx1Focus
        '
        Me.lblTx1Focus.AutoSize = True
        Me.lblTx1Focus.Location = New System.Drawing.Point(40, 167)
        Me.lblTx1Focus.Name = "lblTx1Focus"
        Me.lblTx1Focus.Size = New System.Drawing.Size(36, 13)
        Me.lblTx1Focus.TabIndex = 13
        Me.lblTx1Focus.Text = "Focus"
        '
        'lblTx1Tilty
        '
        Me.lblTx1Tilty.AutoSize = True
        Me.lblTx1Tilty.Location = New System.Drawing.Point(47, 141)
        Me.lblTx1Tilty.Name = "lblTx1Tilty"
        Me.lblTx1Tilty.Size = New System.Drawing.Size(29, 13)
        Me.lblTx1Tilty.TabIndex = 10
        Me.lblTx1Tilty.Text = "Tilt y"
        '
        'lblTx1Tiltx
        '
        Me.lblTx1Tiltx.AutoSize = True
        Me.lblTx1Tiltx.Location = New System.Drawing.Point(47, 113)
        Me.lblTx1Tiltx.Name = "lblTx1Tiltx"
        Me.lblTx1Tiltx.Size = New System.Drawing.Size(29, 13)
        Me.lblTx1Tiltx.TabIndex = 7
        Me.lblTx1Tiltx.Text = "Tilt x"
        '
        'lblTx1Offsety
        '
        Me.lblTx1Offsety.AutoSize = True
        Me.lblTx1Offsety.Location = New System.Drawing.Point(33, 87)
        Me.lblTx1Offsety.Name = "lblTx1Offsety"
        Me.lblTx1Offsety.Size = New System.Drawing.Size(43, 13)
        Me.lblTx1Offsety.TabIndex = 4
        Me.lblTx1Offsety.Text = "Offset y"
        '
        'lblTx1Offsetx
        '
        Me.lblTx1Offsetx.AutoSize = True
        Me.lblTx1Offsetx.Location = New System.Drawing.Point(33, 61)
        Me.lblTx1Offsetx.Name = "lblTx1Offsetx"
        Me.lblTx1Offsetx.Size = New System.Drawing.Size(43, 13)
        Me.lblTx1Offsetx.TabIndex = 0
        Me.lblTx1Offsetx.Text = "Offset x"
        '
        'cmdOptimisation
        '
        Me.cmdOptimisation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOptimisation.Enabled = False
        Me.cmdOptimisation.Location = New System.Drawing.Point(13, 459)
        Me.cmdOptimisation.Name = "cmdOptimisation"
        Me.cmdOptimisation.Size = New System.Drawing.Size(377, 30)
        Me.cmdOptimisation.TabIndex = 35
        Me.cmdOptimisation.Text = "Start Custom Optimisation"
        Me.cmdOptimisation.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Enabled = False
        Me.cmdSave.Location = New System.Drawing.Point(14, 495)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(377, 30)
        Me.cmdSave.TabIndex = 36
        Me.cmdSave.Text = "Save Zernikes and Cameras"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdOverlapMatrix
        '
        Me.cmdOverlapMatrix.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOverlapMatrix.Enabled = False
        Me.cmdOverlapMatrix.Location = New System.Drawing.Point(14, 531)
        Me.cmdOverlapMatrix.Name = "cmdOverlapMatrix"
        Me.cmdOverlapMatrix.Size = New System.Drawing.Size(377, 30)
        Me.cmdOverlapMatrix.TabIndex = 37
        Me.cmdOverlapMatrix.Text = "Measure Overlap Matrix"
        Me.cmdOverlapMatrix.UseVisualStyleBackColor = True
        '
        'cmdLoad
        '
        Me.cmdLoad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdLoad.Location = New System.Drawing.Point(12, 351)
        Me.cmdLoad.Name = "cmdLoad"
        Me.cmdLoad.Size = New System.Drawing.Size(377, 30)
        Me.cmdLoad.TabIndex = 38
        Me.cmdLoad.Text = "Load Holograms, Zernikes and Cameras"
        Me.cmdLoad.UseVisualStyleBackColor = True
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusStripLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 648)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(402, 22)
        Me.StatusStrip.TabIndex = 39
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'StatusStripLabel
        '
        Me.StatusStripLabel.Name = "StatusStripLabel"
        Me.StatusStripLabel.Size = New System.Drawing.Size(0, 17)
        '
        'grpbxRx1
        '
        Me.grpbxRx1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpbxRx1.Controls.Add(Me.chkRx1Imagex)
        Me.grpbxRx1.Controls.Add(Me.lblRx1Imagex)
        Me.grpbxRx1.Controls.Add(Me.chkRx1FFTHeight)
        Me.grpbxRx1.Controls.Add(Me.chkRx1FFTWidth)
        Me.grpbxRx1.Controls.Add(Me.chkRx1FFTy)
        Me.grpbxRx1.Controls.Add(Me.chkRx1FFTx)
        Me.grpbxRx1.Controls.Add(Me.chkRx1ImageHeight)
        Me.grpbxRx1.Controls.Add(Me.chkRx1ImageWidth)
        Me.grpbxRx1.Controls.Add(Me.chkRx1Imagey)
        Me.grpbxRx1.Controls.Add(Me.lblRx1FFTHeight)
        Me.grpbxRx1.Controls.Add(Me.lblRx1FFTWidth)
        Me.grpbxRx1.Controls.Add(Me.lblRx1FFTy)
        Me.grpbxRx1.Controls.Add(Me.lblRx1FFTx)
        Me.grpbxRx1.Controls.Add(Me.lblRx1ImageHeight)
        Me.grpbxRx1.Controls.Add(Me.lblRx1ImageWidth)
        Me.grpbxRx1.Controls.Add(Me.lblRx1Imagey)
        Me.grpbxRx1.Location = New System.Drawing.Point(212, 91)
        Me.grpbxRx1.Name = "grpbxRx1"
        Me.grpbxRx1.Size = New System.Drawing.Size(165, 247)
        Me.grpbxRx1.TabIndex = 40
        Me.grpbxRx1.TabStop = False
        Me.grpbxRx1.Text = "Rx 1"
        '
        'chkRx1Imagex
        '
        Me.chkRx1Imagex.AutoSize = True
        Me.chkRx1Imagex.Location = New System.Drawing.Point(144, 14)
        Me.chkRx1Imagex.Name = "chkRx1Imagex"
        Me.chkRx1Imagex.Size = New System.Drawing.Size(15, 14)
        Me.chkRx1Imagex.TabIndex = 70
        Me.chkRx1Imagex.UseVisualStyleBackColor = True
        '
        'lblRx1Imagex
        '
        Me.lblRx1Imagex.AutoSize = True
        Me.lblRx1Imagex.Location = New System.Drawing.Point(30, 14)
        Me.lblRx1Imagex.Name = "lblRx1Imagex"
        Me.lblRx1Imagex.Size = New System.Drawing.Size(44, 13)
        Me.lblRx1Imagex.TabIndex = 69
        Me.lblRx1Imagex.Text = "Image x"
        '
        'chkRx1FFTHeight
        '
        Me.chkRx1FFTHeight.AutoSize = True
        Me.chkRx1FFTHeight.Location = New System.Drawing.Point(144, 194)
        Me.chkRx1FFTHeight.Name = "chkRx1FFTHeight"
        Me.chkRx1FFTHeight.Size = New System.Drawing.Size(15, 14)
        Me.chkRx1FFTHeight.TabIndex = 68
        Me.chkRx1FFTHeight.UseVisualStyleBackColor = True
        '
        'chkRx1FFTWidth
        '
        Me.chkRx1FFTWidth.AutoSize = True
        Me.chkRx1FFTWidth.Location = New System.Drawing.Point(144, 168)
        Me.chkRx1FFTWidth.Name = "chkRx1FFTWidth"
        Me.chkRx1FFTWidth.Size = New System.Drawing.Size(15, 14)
        Me.chkRx1FFTWidth.TabIndex = 67
        Me.chkRx1FFTWidth.UseVisualStyleBackColor = True
        '
        'chkRx1FFTy
        '
        Me.chkRx1FFTy.AutoSize = True
        Me.chkRx1FFTy.Location = New System.Drawing.Point(144, 142)
        Me.chkRx1FFTy.Name = "chkRx1FFTy"
        Me.chkRx1FFTy.Size = New System.Drawing.Size(15, 14)
        Me.chkRx1FFTy.TabIndex = 66
        Me.chkRx1FFTy.UseVisualStyleBackColor = True
        '
        'chkRx1FFTx
        '
        Me.chkRx1FFTx.AutoSize = True
        Me.chkRx1FFTx.Location = New System.Drawing.Point(144, 116)
        Me.chkRx1FFTx.Name = "chkRx1FFTx"
        Me.chkRx1FFTx.Size = New System.Drawing.Size(15, 14)
        Me.chkRx1FFTx.TabIndex = 65
        Me.chkRx1FFTx.UseVisualStyleBackColor = True
        '
        'chkRx1ImageHeight
        '
        Me.chkRx1ImageHeight.AutoSize = True
        Me.chkRx1ImageHeight.Location = New System.Drawing.Point(144, 88)
        Me.chkRx1ImageHeight.Name = "chkRx1ImageHeight"
        Me.chkRx1ImageHeight.Size = New System.Drawing.Size(15, 14)
        Me.chkRx1ImageHeight.TabIndex = 64
        Me.chkRx1ImageHeight.UseVisualStyleBackColor = True
        '
        'chkRx1ImageWidth
        '
        Me.chkRx1ImageWidth.AutoSize = True
        Me.chkRx1ImageWidth.Location = New System.Drawing.Point(144, 62)
        Me.chkRx1ImageWidth.Name = "chkRx1ImageWidth"
        Me.chkRx1ImageWidth.Size = New System.Drawing.Size(15, 14)
        Me.chkRx1ImageWidth.TabIndex = 63
        Me.chkRx1ImageWidth.UseVisualStyleBackColor = True
        '
        'chkRx1Imagey
        '
        Me.chkRx1Imagey.AutoSize = True
        Me.chkRx1Imagey.Location = New System.Drawing.Point(144, 36)
        Me.chkRx1Imagey.Name = "chkRx1Imagey"
        Me.chkRx1Imagey.Size = New System.Drawing.Size(15, 14)
        Me.chkRx1Imagey.TabIndex = 62
        Me.chkRx1Imagey.UseVisualStyleBackColor = True
        '
        'lblRx1FFTHeight
        '
        Me.lblRx1FFTHeight.AutoSize = True
        Me.lblRx1FFTHeight.Location = New System.Drawing.Point(14, 194)
        Me.lblRx1FFTHeight.Name = "lblRx1FFTHeight"
        Me.lblRx1FFTHeight.Size = New System.Drawing.Size(60, 13)
        Me.lblRx1FFTHeight.TabIndex = 61
        Me.lblRx1FFTHeight.Text = "FFT Height"
        '
        'lblRx1FFTWidth
        '
        Me.lblRx1FFTWidth.AutoSize = True
        Me.lblRx1FFTWidth.Location = New System.Drawing.Point(17, 169)
        Me.lblRx1FFTWidth.Name = "lblRx1FFTWidth"
        Me.lblRx1FFTWidth.Size = New System.Drawing.Size(57, 13)
        Me.lblRx1FFTWidth.TabIndex = 60
        Me.lblRx1FFTWidth.Text = "FFT Width"
        '
        'lblRx1FFTy
        '
        Me.lblRx1FFTy.AutoSize = True
        Me.lblRx1FFTy.Location = New System.Drawing.Point(40, 142)
        Me.lblRx1FFTy.Name = "lblRx1FFTy"
        Me.lblRx1FFTy.Size = New System.Drawing.Size(34, 13)
        Me.lblRx1FFTy.TabIndex = 59
        Me.lblRx1FFTy.Text = "FFT y"
        '
        'lblRx1FFTx
        '
        Me.lblRx1FFTx.AutoSize = True
        Me.lblRx1FFTx.Location = New System.Drawing.Point(40, 116)
        Me.lblRx1FFTx.Name = "lblRx1FFTx"
        Me.lblRx1FFTx.Size = New System.Drawing.Size(34, 13)
        Me.lblRx1FFTx.TabIndex = 58
        Me.lblRx1FFTx.Text = "FFT x"
        '
        'lblRx1ImageHeight
        '
        Me.lblRx1ImageHeight.AutoSize = True
        Me.lblRx1ImageHeight.Location = New System.Drawing.Point(7, 88)
        Me.lblRx1ImageHeight.Name = "lblRx1ImageHeight"
        Me.lblRx1ImageHeight.Size = New System.Drawing.Size(70, 13)
        Me.lblRx1ImageHeight.TabIndex = 57
        Me.lblRx1ImageHeight.Text = "Image Height"
        '
        'lblRx1ImageWidth
        '
        Me.lblRx1ImageWidth.AutoSize = True
        Me.lblRx1ImageWidth.Location = New System.Drawing.Point(10, 62)
        Me.lblRx1ImageWidth.Name = "lblRx1ImageWidth"
        Me.lblRx1ImageWidth.Size = New System.Drawing.Size(67, 13)
        Me.lblRx1ImageWidth.TabIndex = 56
        Me.lblRx1ImageWidth.Text = "Image Width"
        '
        'lblRx1Imagey
        '
        Me.lblRx1Imagey.AutoSize = True
        Me.lblRx1Imagey.Location = New System.Drawing.Point(30, 36)
        Me.lblRx1Imagey.Name = "lblRx1Imagey"
        Me.lblRx1Imagey.Size = New System.Drawing.Size(44, 13)
        Me.lblRx1Imagey.TabIndex = 55
        Me.lblRx1Imagey.Text = "Image y"
        '
        'lblPolarisation
        '
        Me.lblPolarisation.AutoSize = True
        Me.lblPolarisation.Location = New System.Drawing.Point(3, 9)
        Me.lblPolarisation.Name = "lblPolarisation"
        Me.lblPolarisation.Size = New System.Drawing.Size(64, 13)
        Me.lblPolarisation.TabIndex = 41
        Me.lblPolarisation.Text = "Polarisation:"
        '
        'cmbPolarisation
        '
        Me.cmbPolarisation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPolarisation.FormattingEnabled = True
        Me.cmbPolarisation.Items.AddRange(New Object() {"Horizontal", "Vertical"})
        Me.cmbPolarisation.Location = New System.Drawing.Point(74, 6)
        Me.cmbPolarisation.Name = "cmbPolarisation"
        Me.cmbPolarisation.Size = New System.Drawing.Size(95, 21)
        Me.cmbPolarisation.TabIndex = 42
        '
        'lblMinMode
        '
        Me.lblMinMode.AutoSize = True
        Me.lblMinMode.Location = New System.Drawing.Point(10, 40)
        Me.lblMinMode.Name = "lblMinMode"
        Me.lblMinMode.Size = New System.Drawing.Size(57, 13)
        Me.lblMinMode.TabIndex = 43
        Me.lblMinMode.Text = "Min Mode:"
        '
        'nudMinMode
        '
        Me.nudMinMode.Location = New System.Drawing.Point(74, 38)
        Me.nudMinMode.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nudMinMode.Name = "nudMinMode"
        Me.nudMinMode.Size = New System.Drawing.Size(95, 20)
        Me.nudMinMode.TabIndex = 44
        '
        'lblMultiplier
        '
        Me.lblMultiplier.AutoSize = True
        Me.lblMultiplier.Location = New System.Drawing.Point(219, 14)
        Me.lblMultiplier.Name = "lblMultiplier"
        Me.lblMultiplier.Size = New System.Drawing.Size(48, 13)
        Me.lblMultiplier.TabIndex = 45
        Me.lblMultiplier.Text = "Multiplier"
        '
        'nudMultiplier
        '
        Me.nudMultiplier.DecimalPlaces = 2
        Me.nudMultiplier.Location = New System.Drawing.Point(276, 12)
        Me.nudMultiplier.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudMultiplier.Minimum = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.nudMultiplier.Name = "nudMultiplier"
        Me.nudMultiplier.Size = New System.Drawing.Size(91, 20)
        Me.nudMultiplier.TabIndex = 46
        Me.nudMultiplier.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblAlignmentMetric
        '
        Me.lblAlignmentMetric.AutoSize = True
        Me.lblAlignmentMetric.Location = New System.Drawing.Point(182, 67)
        Me.lblAlignmentMetric.Name = "lblAlignmentMetric"
        Me.lblAlignmentMetric.Size = New System.Drawing.Size(88, 13)
        Me.lblAlignmentMetric.TabIndex = 47
        Me.lblAlignmentMetric.Text = "Alignment Metric:"
        '
        'cmbAlignmentMetric
        '
        Me.cmbAlignmentMetric.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAlignmentMetric.FormattingEnabled = True
        Me.cmbAlignmentMetric.Location = New System.Drawing.Point(276, 64)
        Me.cmbAlignmentMetric.Name = "cmbAlignmentMetric"
        Me.cmbAlignmentMetric.Size = New System.Drawing.Size(91, 21)
        Me.cmbAlignmentMetric.TabIndex = 48
        '
        'nudMaxMode
        '
        Me.nudMaxMode.Location = New System.Drawing.Point(276, 38)
        Me.nudMaxMode.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nudMaxMode.Name = "nudMaxMode"
        Me.nudMaxMode.Size = New System.Drawing.Size(91, 20)
        Me.nudMaxMode.TabIndex = 50
        Me.nudMaxMode.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'lblMaxMode
        '
        Me.lblMaxMode.AutoSize = True
        Me.lblMaxMode.Location = New System.Drawing.Point(209, 40)
        Me.lblMaxMode.Name = "lblMaxMode"
        Me.lblMaxMode.Size = New System.Drawing.Size(60, 13)
        Me.lblMaxMode.TabIndex = 49
        Me.lblMaxMode.Text = "Max Mode:"
        '
        'cmdAlignCameraCrop
        '
        Me.cmdAlignCameraCrop.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAlignCameraCrop.Enabled = False
        Me.cmdAlignCameraCrop.Location = New System.Drawing.Point(12, 387)
        Me.cmdAlignCameraCrop.Name = "cmdAlignCameraCrop"
        Me.cmdAlignCameraCrop.Size = New System.Drawing.Size(377, 30)
        Me.cmdAlignCameraCrop.TabIndex = 51
        Me.cmdAlignCameraCrop.Text = "Align Camera Crop"
        Me.cmdAlignCameraCrop.UseVisualStyleBackColor = True
        '
        'cmdAlignFFTCrop
        '
        Me.cmdAlignFFTCrop.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAlignFFTCrop.Enabled = False
        Me.cmdAlignFFTCrop.Location = New System.Drawing.Point(12, 423)
        Me.cmdAlignFFTCrop.Name = "cmdAlignFFTCrop"
        Me.cmdAlignFFTCrop.Size = New System.Drawing.Size(377, 30)
        Me.cmdAlignFFTCrop.TabIndex = 52
        Me.cmdAlignFFTCrop.Text = "Align FFT Crop"
        Me.cmdAlignFFTCrop.UseVisualStyleBackColor = True
        '
        'cmdSaveModes
        '
        Me.cmdSaveModes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSaveModes.Enabled = False
        Me.cmdSaveModes.Location = New System.Drawing.Point(13, 567)
        Me.cmdSaveModes.Name = "cmdSaveModes"
        Me.cmdSaveModes.Size = New System.Drawing.Size(377, 30)
        Me.cmdSaveModes.TabIndex = 53
        Me.cmdSaveModes.Text = "Save All Modes"
        Me.cmdSaveModes.UseVisualStyleBackColor = True
        '
        'cmdLinPolCircPol
        '
        Me.cmdLinPolCircPol.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdLinPolCircPol.Enabled = False
        Me.cmdLinPolCircPol.Location = New System.Drawing.Point(14, 603)
        Me.cmdLinPolCircPol.Name = "cmdLinPolCircPol"
        Me.cmdLinPolCircPol.Size = New System.Drawing.Size(377, 30)
        Me.cmdLinPolCircPol.TabIndex = 54
        Me.cmdLinPolCircPol.Text = "Save Lin Pol, Circ Pol"
        Me.cmdLinPolCircPol.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(402, 670)
        Me.Controls.Add(Me.cmdLinPolCircPol)
        Me.Controls.Add(Me.cmdSaveModes)
        Me.Controls.Add(Me.cmdAlignFFTCrop)
        Me.Controls.Add(Me.cmdAlignCameraCrop)
        Me.Controls.Add(Me.nudMaxMode)
        Me.Controls.Add(Me.lblMaxMode)
        Me.Controls.Add(Me.cmbAlignmentMetric)
        Me.Controls.Add(Me.lblAlignmentMetric)
        Me.Controls.Add(Me.nudMultiplier)
        Me.Controls.Add(Me.lblMultiplier)
        Me.Controls.Add(Me.nudMinMode)
        Me.Controls.Add(Me.lblMinMode)
        Me.Controls.Add(Me.cmbPolarisation)
        Me.Controls.Add(Me.lblPolarisation)
        Me.Controls.Add(Me.grpbxRx1)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.cmdLoad)
        Me.Controls.Add(Me.cmdOverlapMatrix)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.cmdOptimisation)
        Me.Controls.Add(Me.grpbxTx1)
        Me.Name = "frmMain"
        Me.Text = "Main"
        Me.grpbxTx1.ResumeLayout(False)
        Me.grpbxTx1.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.grpbxRx1.ResumeLayout(False)
        Me.grpbxRx1.PerformLayout()
        CType(Me.nudMinMode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMultiplier, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMaxMode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpbxTx1 As GroupBox
    Friend WithEvents chkTx1Astigmatismy As CheckBox
    Friend WithEvents chkTx1Astigmatismx As CheckBox
    Friend WithEvents chkTx1Defocus As CheckBox
    Friend WithEvents chkTx1Tilty As CheckBox
    Friend WithEvents chkTx1Tiltx As CheckBox
    Friend WithEvents chkTx1Offsety As CheckBox
    Friend WithEvents chkTx1Offsetx As CheckBox
    Friend WithEvents lblTx1Astigmatismy As Label
    Friend WithEvents lblTx1Astigmatismx As Label
    Friend WithEvents lblTx1Focus As Label
    Friend WithEvents lblTx1Tilty As Label
    Friend WithEvents lblTx1Tiltx As Label
    Friend WithEvents lblTx1Offsety As Label
    Friend WithEvents lblTx1Offsetx As Label
    Friend WithEvents cmdOptimisation As Button
    Friend WithEvents cmdSave As Button
    Friend WithEvents cmdOverlapMatrix As Button
    Friend WithEvents cmdLoad As Button
    Friend WithEvents StatusStrip As StatusStrip
    Friend WithEvents chkTx1Scale As CheckBox
    Friend WithEvents lblTx1Scale As Label
    Friend WithEvents grpbxRx1 As GroupBox
    Friend WithEvents chkRx1Imagex As CheckBox
    Friend WithEvents lblRx1Imagex As Label
    Friend WithEvents chkRx1FFTHeight As CheckBox
    Friend WithEvents chkRx1FFTWidth As CheckBox
    Friend WithEvents chkRx1FFTy As CheckBox
    Friend WithEvents chkRx1FFTx As CheckBox
    Friend WithEvents chkRx1ImageHeight As CheckBox
    Friend WithEvents chkRx1ImageWidth As CheckBox
    Friend WithEvents chkRx1Imagey As CheckBox
    Friend WithEvents lblRx1FFTHeight As Label
    Friend WithEvents lblRx1FFTWidth As Label
    Friend WithEvents lblRx1FFTy As Label
    Friend WithEvents lblRx1FFTx As Label
    Friend WithEvents lblRx1ImageHeight As Label
    Friend WithEvents lblRx1ImageWidth As Label
    Friend WithEvents lblRx1Imagey As Label
    Friend WithEvents lblPolarisation As Label
    Friend WithEvents cmbPolarisation As ComboBox
    Friend WithEvents lblMinMode As Label
    Friend WithEvents nudMinMode As NumericUpDown
    Friend WithEvents StatusStripLabel As ToolStripStatusLabel
    Friend WithEvents lblMultiplier As Label
    Friend WithEvents nudMultiplier As NumericUpDown
    Friend WithEvents lblAlignmentMetric As Label
    Friend WithEvents cmbAlignmentMetric As ComboBox
    Friend WithEvents nudMaxMode As NumericUpDown
    Friend WithEvents lblMaxMode As Label
    Friend WithEvents cmdAlignCameraCrop As Button
    Friend WithEvents cmdAlignFFTCrop As Button
    Friend WithEvents chkTx1Rotation As CheckBox
    Friend WithEvents lblTx1Rotation As Label
    Friend WithEvents cmdSaveModes As Button
    Friend WithEvents cmdLinPolCircPol As Button
End Class
