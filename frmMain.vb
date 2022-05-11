' Ralf Mouthaan
' University of Cambridge
' February 2020
'
' Nelder-Meade Simplex optimisation is used to optimise Zernikes to obtain best possible modes.

Option Explicit On
Option Strict On

Public Class frmMain

#Region "Form Events"
    Private Sub frmMain_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

        MeasurementSetup = New clsMeasurementSetup
        cmbPolarisation.SelectedIndex = 0
        cmbAlignmentMetric.Items.Add("Overlap Integral")
        cmbAlignmentMetric.Items.Add("Magnitude Overlap")
        cmbAlignmentMetric.SelectedIndex = 0

    End Sub
    Private Sub cmdOverlapMatrix_Click(sender As Object, e As EventArgs) Handles cmdOverlapMatrix.Click

        DisableControls()

        MeasurementSetup.MinMode = CInt(nudMinMode.Value)
        MeasurementSetup.MaxMode = CInt(nudMaxMode.Value)

        ' Get overlap matrix
        Dim _OverlapMatrix(,) As Double
        MeasurementSetup.StartUp()
        _OverlapMatrix = MeasurementSetup.OverlapIntegralMatrix()

        'Save overlap matrix to file
        Dim writer As New IO.StreamWriter("Overlap Matrix.csv")

        For i = 0 To _OverlapMatrix.GetLength(0) - 1
            For j = 0 To _OverlapMatrix.GetLength(1) - 1

                writer.Write(_OverlapMatrix(i, j).ToString)
                If j < _OverlapMatrix.GetLength(1) - 1 Then writer.Write(",")

            Next

            If i < _OverlapMatrix.GetLength(0) - 1 Then writer.WriteLine()

        Next

        writer.Close()

        EnableControls()

    End Sub
    Private Sub cmdSaveZernikes_Click(sender As Object, e As EventArgs) Handles cmdSave.Click

        ' Save camera parameters
        If MeasurementSetup.Polarisation = 1 Then
            MeasurementSetup.Camera.Save("D:\RPM Data Files\Output Camera Pol 1.txt")
            MeasurementSetup.TxHolo.SaveZernikes("D:\RPM Data Files\Tx1 Zernikes.txt")
        ElseIf MeasurementSetup.Polarisation = 2 Then
            MeasurementSetup.Camera.Save("D:\RPM Data Files\Output Camera Pol 2.txt")
            MeasurementSetup.TxHolo.SaveZernikes("D:\RPM Data Files\Tx2 Zernikes.txt")
        End If

    End Sub
    Private Sub cmdLoadHolograms_Click(sender As Object, e As EventArgs) Handles cmdLoad.Click

        Dim dlg As New OpenFileDialog

        dlg.Title = "Please select Metadata file"
        dlg.Filter = "Text files (*.txt)|*.txt"

        If dlg.ShowDialog = vbCancel Then
            Exit Sub
        End If

        If dlg.FileName = "" Then Exit Sub

        StatusStripLabel.Text = "Loading Holograms, Zernikes, Cameras..."
        DisableControls()
        Application.DoEvents()

        MeasurementSetup.Polarisation = cmbPolarisation.SelectedIndex + 1
        Call MeasurementSetup.LoadHolograms(dlg.FileName)
        Call MeasurementSetup.LoadZernikes()
        Call MeasurementSetup.LoadCamera()
        MeasurementSetup.Camera.FFTPaddedWidth = MeasurementSetup.TxHolo.lstHologram(0).ModeWidth
        UpdateFormParameters()

        StatusStripLabel.Text = ""
        EnableControls()

    End Sub
#End Region

#Region "Zernikes Save / Load / Display"
    Private Sub UpdateUpdateFlags()

        MeasurementSetup.arrbolOptimise(0) = chkTx1Scale.Checked
        MeasurementSetup.arrbolOptimise(1) = chkTx1Rotation.Checked
        MeasurementSetup.arrbolOptimise(2) = chkTx1Offsetx.Checked
        MeasurementSetup.arrbolOptimise(3) = chkTx1Offsety.Checked
        MeasurementSetup.arrbolOptimise(4) = chkTx1Tiltx.Checked
        MeasurementSetup.arrbolOptimise(5) = chkTx1Tilty.Checked
        MeasurementSetup.arrbolOptimise(6) = chkTx1Defocus.Checked
        MeasurementSetup.arrbolOptimise(7) = chkTx1Astigmatismx.Checked
        MeasurementSetup.arrbolOptimise(8) = chkTx1Astigmatismy.Checked

        MeasurementSetup.arrbolOptimise(9) = chkRx1Imagex.Checked
        MeasurementSetup.arrbolOptimise(10) = chkRx1Imagey.Checked
        MeasurementSetup.arrbolOptimise(11) = chkRx1ImageWidth.Checked
        MeasurementSetup.arrbolOptimise(12) = chkRx1ImageHeight.Checked

        MeasurementSetup.arrbolOptimise(13) = chkRx1FFTx.Checked
        MeasurementSetup.arrbolOptimise(14) = chkRx1FFTy.Checked
        MeasurementSetup.arrbolOptimise(15) = chkRx1FFTWidth.Checked
        MeasurementSetup.arrbolOptimise(16) = chkRx1FFTHeight.Checked

    End Sub
    Private Sub UpdateFormParameters()

        lblTx1Scale.Text = "Scale: " + MeasurementSetup.TxHolo.dblScale.ToString("F2")
        lblTx1Rotation.Text = "Rotation: " + MeasurementSetup.TxHolo.dblRotation.ToString("F2")
        lblTx1Offsetx.Text = "Offset x: " + CStr(MeasurementSetup.TxHolo.intOffsetx)
        lblTx1Offsety.Text = "Offset y: " + CStr(MeasurementSetup.TxHolo.intOffsety)
        lblTx1Tiltx.Text = "Tilt x: " + MeasurementSetup.TxHolo.dblTiltx.ToString("F2")
        lblTx1Tilty.Text = "Tilt y: " + MeasurementSetup.TxHolo.dblTilty.ToString("F2")
        lblTx1Focus.Text = "Focus: " + MeasurementSetup.TxHolo.dblFocus.ToString("F2")
        lblTx1Astigmatismx.Text = "Astigmatism x: " + MeasurementSetup.TxHolo.dblAstigmatismx.ToString("F2")
        lblTx1Astigmatismy.Text = "Astigmatism y: " + MeasurementSetup.TxHolo.dblAstigmatismy.ToString("F2")

        lblRx1Imagex.Text = "Image x: " + CStr(MeasurementSetup.Camera.OffAxisImageViewport.X)
        lblRx1Imagey.Text = "Image y: " + CStr(MeasurementSetup.Camera.OffAxisImageViewport.Y)
        lblRx1ImageWidth.Text = "Image Width: " + CStr(MeasurementSetup.Camera.OffAxisImageViewport.Width)
        lblRx1ImageHeight.Text = "Image Height: " + CStr(MeasurementSetup.Camera.OffAxisImageViewport.Height)

        lblRx1FFTx.Text = "FFT x: " + CStr(MeasurementSetup.Camera.OffAxisFFTViewport.X)
        lblRx1FFTy.Text = "FFT y: " + CStr(MeasurementSetup.Camera.OffAxisFFTViewport.Y)
        lblRx1FFTWidth.Text = "FFT Width: " + CStr(MeasurementSetup.Camera.OffAxisFFTViewport.Width)
        lblRx1FFTHeight.Text = "FFT Height: " + CStr(MeasurementSetup.Camera.OffAxisFFTViewport.Height)

    End Sub
#End Region

#Region "Enable / Disable Controls"

    Public Sub EnableControls()

        For Each ctrl In Me.Controls
            If TypeOf (ctrl) Is Button Then
                CType(ctrl, Button).Enabled = True
            End If
            If TypeOf (ctrl) Is CheckBox Then
                CType(ctrl, CheckBox).Enabled = True
            End If
        Next

    End Sub
    Public Sub DisableControls()

        For Each ctrl In Me.Controls
            If TypeOf (ctrl) Is Button Then
                CType(ctrl, Button).Enabled = False
            End If
            If TypeOf (ctrl) Is CheckBox Then
                CType(ctrl, CheckBox).Enabled = False
            End If
        Next

    End Sub

#End Region

    Private OptimisationAlgorithm As clsOptimisationAlgorithm

    Private Sub cmdCustomOptimisation_Click(sender As Object, e As EventArgs) Handles cmdOptimisation.Click

        ' If an optimisation routine is already running, then kill it.
        If cmdOptimisation.Text = "Stop" Then
            If OptimisationAlgorithm Is Nothing Then Exit Sub
            OptimisationAlgorithm.StopExecution()
            cmdOptimisation.Text = "Start"
            Return
        End If

        ' Turn off controls
        DisableControls()
        cmdOptimisation.Enabled = True

        ' Define optimisation algorithm (others available)
        Dim Algo As New clsNelderMeade
        OptimisationAlgorithm = Algo
        OptimisationAlgorithm.dblMultiplier = nudMultiplier.Value
        StatusStripLabel.Text = OptimisationAlgorithm.strAlgorithmName

        'Set some parameters
        MeasurementSetup.MinMode = CInt(nudMinMode.Value)
        MeasurementSetup.MaxMode = CInt(nudMaxMode.Value)
        If cmbAlignmentMetric.SelectedIndex = 0 Then
            OptimisationAlgorithm.funEvaluateObjective = AddressOf MeasurementSetup.OverlapIntegralMetric
        ElseIf cmbAlignmentMetric.SelectedIndex = 1 Then
            OptimisationAlgorithm.funEvaluateObjective = AddressOf MeasurementSetup.MagnitudeOverlapMetric
        End If
        UpdateUpdateFlags()
        MeasurementSetup.TxHolo.bolVisible = True

        If MeasurementSetup.arrOptimisationParametersCount = 0 Then Call Err.Raise(-1, "", "You have not selected any parameters to optimise")

        'Handle improvement found event
        AddHandler OptimisationAlgorithm.ImprovementFound,
            Sub()
                StatusStripLabel.Text = OptimisationAlgorithm.strAlgorithmName & " " & (-OptimisationAlgorithm.dblBestValue).ToString("F5")
            End Sub

        ' Handle execution finished event
        AddHandler OptimisationAlgorithm.ExecutionFinished,
            Sub()
                'MeasurementSetup.Shutdown()bbc

                UpdateFormParameters()
                StatusStripLabel.Text = ""
                EnableControls()
            End Sub

        ' Start Execution
        OptimisationAlgorithm.StartExecution()
        cmdOptimisation.Text = "Stop"

    End Sub

    Private Sub cmdAlignCameraCrop_Click(sender As Object, e As EventArgs) Handles cmdAlignCameraCrop.Click

        'ASSUMES WHITE LIGHT ILLUMINATION

        Dim Img(,) As Integer
        Dim xNumerator, yNumerator, Denominator As Integer
        Dim xCentroid As Integer, yCentroid As Integer
        Dim xRadius As Integer, yRadius As Integer

        DisableControls()

        MeasurementSetup.Camera.Startup()
        Img = MeasurementSetup.Camera.GetOffAxisCroppedImage
        MeasurementSetup.Camera.Shutdown()

        ' Find Centre
        xNumerator = 0
        yNumerator = 0
        Denominator = 0
        For i = 0 To Img.GetLength(0) - 1
            For j = 0 To Img.GetLength(1) - 1
                xNumerator += i * Img(i, j)
                yNumerator += j * Img(i, j)
                Denominator += Img(i, j)
            Next
        Next

        xCentroid = CInt(Math.Round(xNumerator / Denominator))
        yCentroid = CInt(Math.Round(yNumerator / Denominator))

        ' Find radii
        xRadius = 0
        While (Img(xCentroid + xRadius, yCentroid) + Img(xCentroid - xRadius, yCentroid)) / 2 > Img(xCentroid, yCentroid) / 2
            xRadius += 1
        End While
        yRadius = 0
        While (Img(xCentroid, yCentroid + yRadius) + Img(xCentroid - yRadius, yCentroid)) / 2 > Img(xCentroid, yCentroid) / 2
            yRadius += 1
        End While

        MeasurementSetup.Camera.OffAxisImageViewport.Width = 2 * xRadius
        MeasurementSetup.Camera.OffAxisImageViewport.Height = 2 * yRadius

        MeasurementSetup.Camera.OffAxisImageViewport.X += xCentroid - xRadius
        MeasurementSetup.Camera.OffAxisImageViewport.Y += yCentroid - yRadius

        UpdateFormParameters()
        EnableControls()

    End Sub

    Private Sub cmdAlignFFTCrop_Click(sender As Object, e As EventArgs) Handles cmdAlignFFTCrop.Click

        Dim Img(,) As Numerics.Complex
        Dim xNumerator, yNumerator, Denominator As Double
        Dim xCentroid, yCentroid As Integer
        Dim xRadius, yRadius As Integer
        Dim max As Double

        DisableControls()

        MeasurementSetup.Camera.Startup()
        Img = MeasurementSetup.Camera.GetOffAxisCroppedFFTImage
        MeasurementSetup.Camera.Shutdown()

        ' Find max
        max = 0
        For i = 0 To Img.GetLength(0) - 1
            For j = 0 To Img.GetLength(1) - 1
                If Img(i, j).Magnitude > max Then max = Img(i, j).Magnitude
            Next
        Next

        ' Find Centre
        xNumerator = 0
        yNumerator = 0
        Denominator = 0
        For i = 0 To Img.GetLength(0) - 1
            For j = 0 To Img.GetLength(1) - 1
                If Img(i, j).Magnitude > max * 0.4 Then
                    xNumerator += i
                    yNumerator += j
                    Denominator += 1
                End If
            Next
        Next

        xCentroid = CInt(Math.Round(xNumerator / Denominator))
        yCentroid = CInt(Math.Round(yNumerator / Denominator))

        ' Find radii
        xRadius = 0
        While (Img(xCentroid + xRadius, yCentroid).Magnitude + Img(xCentroid - xRadius, yCentroid).Magnitude) / 2 > Img(xCentroid, yCentroid).Magnitude / 2
            xRadius += 1
        End While
        yRadius = 0
        While (Img(xCentroid, yCentroid + yRadius).Magnitude + Img(xCentroid - yRadius, yCentroid).Magnitude) / 2 > Img(xCentroid, yCentroid).Magnitude / 2
            yRadius += 1
        End While

        xRadius = Math.Max(2 * xRadius, 15)
        yRadius = Math.Max(2 * yRadius, 15)

        MeasurementSetup.Camera.OffAxisFFTViewport.Width = 2 * xRadius
        MeasurementSetup.Camera.OffAxisFFTViewport.Height = 2 * yRadius

        MeasurementSetup.Camera.OffAxisFFTViewport.X += xCentroid - xRadius
        MeasurementSetup.Camera.OffAxisFFTViewport.Y += yCentroid - yRadius

        UpdateFormParameters()
        EnableControls()

    End Sub

    Private Sub cmdSaveModes_Click(sender As Object, e As EventArgs) Handles cmdSaveModes.Click

        Dim MinMode As Integer = CInt(nudMinMode.Value)
        Dim maxmode As Integer = CInt(nudMaxMode.Value)

        Dim x(,) As Numerics.Complex
        Dim Width As Integer = MeasurementSetup.TxHolo.CurrentHologram.ModeWidth

        MeasurementSetup.Camera.FFTPaddedWidth = Width
        MeasurementSetup.TxHolo.bolVisible = True

        MeasurementSetup.StartUp()

        For i = MinMode To maxmode

            MeasurementSetup.TxHolo.HoloIndex = i
            MeasurementSetup.SLM.Refresh()
            x = MeasurementSetup.Camera.GetOffAxisComplexImage

            ImageProcessing.SaveImgToFile(x, i.ToString + ".txt")

        Next

    End Sub

End Class
