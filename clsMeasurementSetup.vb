' Ralf Mouthaan
' University of Cambridge
' February 2020
'
' Measurement setup class

Option Explicit On
Option Strict On

Public Module Globals
    Public MeasurementSetup As clsMeasurementSetup
End Module

Public Class clsMeasurementSetup

    Public TxHolo As clsListModeHologram
    Public SLM As clsSLM
    Public Camera As clsThorlabsCamDC

    Private _Polarisation As Integer
    Public Property Polarisation As Integer
        Get
            Return _Polarisation
        End Get
        Set(value As Integer)
            If value < 1 Or value > 2 Then
                Call Err.Raise(-1, "Polarisation", "Polarisation must be 1 or 2")
            End If
            _Polarisation = value
        End Set
    End Property
    Public Sub New()

        SLM = New clsSLM
        Camera = New clsThorlabsCamDC

        SLM.intScreenNo = 1

    End Sub

#Region "Startup, Shutdown"
    Public Sub StartUp()

        If TxHolo.HologramCount = 0 Then
            Call Err.Raise(-1, "Measurement Setup Startup", "Need to load holograms")
        End If

        If SLM.bolConnectionOpen = False Then
            SLM.StartUp()
            TxHolo.RedefineLUTs()
        End If
        If Camera.bolActive = True Then Camera.Startup()

    End Sub
    Public Sub Shutdown()

        SLM.ShutDown()
        Camera.Shutdown()

    End Sub
#End Region

#Region "Load Holograms, Zernikes, Cameras"
    Public Sub LoadHolograms(ByVal strMetaDataFile As String)

        If IO.File.Exists(strMetaDataFile) = False Then
            Call Err.Raise(-1, "Load Holograms Function", "Could not find metadata file")
        End If

        TxHolo = New clsListModeHologram

        Dim reader As New IO.StreamReader(strMetaDataFile)
        Dim splitstr() As String
        Dim Holo As clsModeHologram

        Dim strPath As String = System.IO.Path.GetDirectoryName(strMetaDataFile) + "\"

        reader.ReadLine()

        While reader.EndOfStream = False

            Holo = TxHolo.CreateHologram

            splitstr = Split(reader.ReadLine, vbTab)
            Holo.l = CInt(splitstr(0))
            Holo.m = CInt(splitstr(1))
            Holo.PropagationConstant = CDbl(splitstr(2))
            Holo.LoadHologram(strPath + splitstr(3))
            Holo.LoadMode(strPath + splitstr(4))
            Holo.HologramEfficiency = CDbl(splitstr(5))

        End While

        reader.Close()

        SLM.lstHolograms.Add(TxHolo)

    End Sub
    Public Sub LoadZernikes()

        If Polarisation = 1 Then
            TxHolo.LoadZernikes("D:\RPM Data Files\Tx1 Zernikes.txt")
        ElseIf Polarisation = 2 Then
            TxHolo.LoadZernikes("D:\RPM Data Files\Tx2 Zernikes.txt")
        Else
            Call Err.Raise(-1, "Load Camera", "Polarisation must be 1 or 2")
        End If

    End Sub
    Public Sub LoadCamera()

        Dim strCameraFile As String

        If Polarisation = 1 Then
            strCameraFile = "D:\RPM Data Files\Output Camera Pol 1.txt"
        ElseIf Polarisation = 2 Then
            strCameraFile = "D:\RPM Data Files\Output Camera Pol 2.txt"
        Else
            strCameraFile = ""
            Call Err.Raise(-1, "Load Camera", "Polarisation must be 1 or 2")
        End If

        If IO.File.Exists(strCameraFile) Then
            Camera.Load(strCameraFile)
        Else
            Camera = New clsThorlabsCamDC
        End If

    End Sub
#End Region

#Region "Optimisation Parameters"
    Private _arrbolOptimise() As Boolean
    Public Property arrParameters() As Double()
        Get

            Dim RetVal(16) As Double

            RetVal(0) = TxHolo.dblScale
            RetVal(1) = TxHolo.dblRotation
            RetVal(2) = TxHolo.intOffsetx
            RetVal(3) = TxHolo.intOffsety
            RetVal(4) = TxHolo.dblTiltx
            RetVal(5) = TxHolo.dblTilty
            RetVal(6) = TxHolo.dblFocus
            RetVal(7) = TxHolo.dblAstigmatismx
            RetVal(8) = TxHolo.dblAstigmatismy

            RetVal(9) = Camera.OffAxisImageViewport.X
            RetVal(10) = Camera.OffAxisImageViewport.Y
            RetVal(11) = Camera.OffAxisImageViewport.Width
            RetVal(12) = Camera.OffAxisImageViewport.Height

            RetVal(13) = Camera.OffAxisImageViewport.X
            RetVal(14) = Camera.OffAxisImageViewport.Y
            RetVal(15) = Camera.OffAxisImageViewport.Width
            RetVal(16) = Camera.OffAxisImageViewport.Height

            Return RetVal

        End Get
        Set(value As Double())

            If value.Count <> 16 Then Call Err.Raise(-1, "Measurement Setup Parameters", "Expect a differently sized parameters array")

            TxHolo.dblScale = value(0)
            TxHolo.dblRotation = value(1)
            TxHolo.intOffsetx = CInt(value(2))
            TxHolo.intOffsety = CInt(value(3))
            TxHolo.dblTiltx = value(4)
            TxHolo.dblTilty = value(5)
            TxHolo.dblFocus = value(6)
            TxHolo.dblAstigmatismx = value(7)
            TxHolo.dblAstigmatismy = value(8)

            Camera.OffAxisImageViewport.X = CInt(value(9))
            Camera.OffAxisImageViewport.Y = CInt(value(10))
            Camera.OffAxisImageViewport.Width = CInt(Math.Round(value(11) / 2) * 2)
            Camera.OffAxisImageViewport.Height = CInt(Math.Round(value(12) / 2) * 2)

            Camera.OffAxisFFTViewport.X = CInt(value(13))
            Camera.OffAxisFFTViewport.Y = CInt(value(14))
            Camera.OffAxisFFTViewport.Width = CInt(Math.Round(value(15) / 2) * 2)
            Camera.OffAxisFFTViewport.Height = CInt(Math.Round(value(16) / 2) * 2)

        End Set
    End Property
    Public Property arrParameters(idx As Integer) As Double
        Get

            If idx = 0 Then Return TxHolo.dblScale
            If idx = 1 Then Return TxHolo.dblRotation
            If idx = 2 Then Return TxHolo.intOffsetx
            If idx = 3 Then Return TxHolo.intOffsety
            If idx = 4 Then Return TxHolo.dblTiltx
            If idx = 5 Then Return TxHolo.dblTilty
            If idx = 6 Then Return TxHolo.dblFocus
            If idx = 7 Then Return TxHolo.dblAstigmatismx
            If idx = 8 Then Return TxHolo.dblAstigmatismy
            If idx = 9 Then Return Camera.OffAxisImageViewport.X
            If idx = 10 Then Return Camera.OffAxisImageViewport.Y
            If idx = 11 Then Return Camera.OffAxisImageViewport.Width
            If idx = 12 Then Return Camera.OffAxisImageViewport.Height
            If idx = 13 Then Return Camera.OffAxisFFTViewport.X
            If idx = 14 Then Return Camera.OffAxisFFTViewport.Y
            If idx = 15 Then Return Camera.OffAxisFFTViewport.Width
            If idx = 16 Then Return Camera.OffAxisFFTViewport.Height

            If idx < 0 Then Call Err.Raise(-1, "Measurement Setup Parameters", "Expect idx >= 0")
            If idx > 16 Then Call Err.Raise(-1, "Measurement Setup Parameters", "Expect idx < 15")
            Return Nothing

        End Get
        Set(value As Double)

            If idx = 0 Then TxHolo.dblScale = value
            If idx = 1 Then TxHolo.dblRotation = value
            If idx = 2 Then TxHolo.intOffsetx = CInt(value)
            If idx = 3 Then TxHolo.intOffsety = CInt(value)
            If idx = 4 Then TxHolo.dblTiltx = value
            If idx = 5 Then TxHolo.dblTilty = value
            If idx = 6 Then TxHolo.dblFocus = value
            If idx = 7 Then TxHolo.dblAstigmatismx = value
            If idx = 8 Then TxHolo.dblAstigmatismy = value
            If idx = 9 Then Camera.OffAxisImageViewport.X = CInt(value)
            If idx = 10 Then Camera.OffAxisImageViewport.Y = CInt(value)
            If idx = 11 Then Camera.OffAxisImageViewport.Width = CInt(Math.Round(value / 2) * 2)
            If idx = 12 Then Camera.OffAxisImageViewport.Height = CInt(Math.Round(value / 2) * 2)
            If idx = 13 Then Camera.OffAxisFFTViewport.X = CInt(value)
            If idx = 14 Then Camera.OffAxisFFTViewport.Y = CInt(value)
            If idx = 15 Then Camera.OffAxisFFTViewport.Width = CInt(Math.Round(value / 2) * 2)
            If idx = 16 Then Camera.OffAxisFFTViewport.Height = CInt(Math.Round(value / 2) * 2)

            If idx < 0 Then Call Err.Raise(-1, "Measurement Setup Parameters", "Expect idx >= 0")
            If idx > 16 Then Call Err.Raise(-1, "Measurement Setup Parameters", "Expect idx < 15")

        End Set
    End Property
    Public Property arrbolOptimise As Boolean()
        Get
            Return _arrbolOptimise
        End Get
        Set(value As Boolean())
            If value.Count <> 17 Then Call Err.Raise(-1, "Measurement Setup Parameters", "Expect a differently sized array")
            _arrbolOptimise = value
        End Set
    End Property
    Public Property arrbolOptimise(ByVal idx As Integer) As Boolean
        Get
            If idx < 0 Or idx > 16 Then Call Err.Raise(-1, "Measurement Setup Parameters", "Expect an idx between 0 and 15")
            Return _arrbolOptimise(idx)
        End Get
        Set(value As Boolean)
            If idx < 0 Or idx > 16 Then Call Err.Raise(-1, "Measurement Setup Parameters", "Expect an idx between 0 and 15")
            If _arrbolOptimise Is Nothing Then ReDim _arrbolOptimise(16)
            If _arrbolOptimise.Count <> 17 Then ReDim _arrbolOptimise(16)
            _arrbolOptimise(idx) = value
        End Set
    End Property
    Public Property arrOptimisationParameters() As Double()
        Get

            Dim retval(arrOptimisationParametersCount - 1) As Double

            Dim j As Integer = 0

            For i = 0 To arrParameters.Count - 1
                If arrbolOptimise(i) = True Then
                    retval(j) = arrOptimisationParameters(i)
                    j = j + 1
                End If
            Next

            Return retval

        End Get
        Set(value() As Double)

            If value.Count <> arrOptimisationParametersCount Then
                Call Err.Raise(-1, "Measurement Parameters Setup", "Array is of unexpected length")
            End If

            Dim j As Integer = 0

            For i = 0 To arrParameters.Count - 1
                If arrbolOptimise(i) = True Then
                    arrParameters(i) = value(j)
                    j += 1
                End If
            Next

        End Set
    End Property
    Public Property arrOptimisationParameters(ByVal idx As Integer) As Double
        Get

            Dim j As Integer
            j = -1

            For i = 0 To arrbolOptimise.Count - 1
                If arrbolOptimise(i) = True Then j += 1
                If j = idx Then Return arrParameters(i)
            Next

            Return Nothing

        End Get
        Set(value As Double)

            Dim j As Integer
            j = -1

            For i = 0 To arrbolOptimise.Count - 1
                If arrbolOptimise(i) = True Then j += 1
                If j = idx Then
                    arrParameters(i) = value
                    Exit Property
                End If
            Next

        End Set
    End Property
    Public ReadOnly Property arrOptimisationParametersCount As Integer
        Get
            Dim Count As Integer
            Count = 0
            For i = 0 To arrbolOptimise.Count - 1
                If arrbolOptimise(i) = True Then Count += 1
            Next
            Return Count
        End Get
    End Property
#End Region

#Region "Alignment Metrics"
    Private _MinMode As Integer
    Private _MaxMode As Integer
    Public Property MinMode As Integer
        Get
            Return _MinMode
        End Get
        Set(value As Integer)
            If value > TxHolo.HologramCount - 1 Then Call Err.Raise(-1, "Min Mode", "Min Mode for overlap matrix > Number of Loaded Modes")
            _MinMode = value
        End Set
    End Property
    Public Property MaxMode As Integer
        Get
            Return _MaxMode
        End Get
        Set(value As Integer)
            If value > TxHolo.HologramCount - 1 Then Call Err.Raise(-1, "Max Mode", "Max Mode for overlap matrix > Number of Loaded Modes")
            _MaxMode = value
        End Set
    End Property
    Public ReadOnly Property NoModes As Integer
        Get
            Return _MaxMode - MinMode + 1
        End Get
    End Property

    Public Function OverlapIntegralMatrix() As Double(,)

        Dim RetVal(NoModes - 1, NoModes - 1) As Double
        Dim x(,) As Numerics.Complex
        Dim Width As Integer = TxHolo.CurrentHologram.ModeWidth

        Camera.FFTPaddedWidth = Width
        TxHolo.bolVisible = True

        StartUp()

        For i = MinMode To MaxMode

            TxHolo.HoloIndex = i
            SLM.Refresh()
            x = Camera.GetOffAxisComplexImage

            For j = MinMode To MaxMode
                ImageProcessing.OverlapIntegral(x, TxHolo.lstHologram(j).arrMode, True, RetVal(i - MinMode, j - MinMode))
            Next

        Next

        Return RetVal

    End Function
    Public Function MagnitudeOverlapMatrix() As Double(,)

        Dim RetVal(NoModes - 1, NoModes - 1) As Double
        Dim x(,) As Numerics.Complex
        Dim Width As Integer = TxHolo.CurrentHologram.ModeWidth

        Camera.FFTPaddedWidth = Width
        TxHolo.bolVisible = True

        StartUp()

        For i = MinMode To MaxMode

            TxHolo.HoloIndex = i
            SLM.Refresh()
            x = Camera.GetOffAxisComplexImage()

            For j = MinMode To MaxMode
                ImageProcessing.MagnitudeOverlap(x, TxHolo.lstHologram(j).arrMode, RetVal(i - MinMode, j - MinMode))
            Next

        Next

        Return RetVal

    End Function
    Public Function OverlapIntegralMetric(ByVal arr() As Double) As Double

        If arr.Count <> arrOptimisationParametersCount Then Call Err.Raise(-1, "Alignment Metric", "Vector of wrong length")
        arrOptimisationParameters = arr

        Dim _OverlapMatrix(,) As Double = OverlapIntegralMatrix()
        Dim RetVal As Double

        For i = 0 To _OverlapMatrix.GetLength(0) - 1
            For j = 0 To _OverlapMatrix.GetLength(1) - 1
                If Math.Abs(TxHolo.lstHologram(i).PropagationConstant - TxHolo.lstHologram(j).PropagationConstant) < 0.1 Then
                    RetVal += _OverlapMatrix(i, j)
                Else
                    If _OverlapMatrix(i, j) > 0.2 Then ' We have some level of background noise that means we always have some overlap.
                        RetVal -= _OverlapMatrix(i, j)
                    End If
                End If
            Next
        Next

        Dim str As String = ""
        For i = 0 To arr.Count - 1
            str = str & arr(i).ToString & "  "
        Next
        str = str & (-RetVal / NoModes).ToString
        Console.WriteLine(str)

        Return -RetVal / NoModes

    End Function
    Public Function MagnitudeOverlapMetric(ByVal arr() As Double) As Double

        If arr.Count <> arrOptimisationParametersCount Then Call Err.Raise(-1, "Alignment Metric", "Vector of wrong length")
        arrOptimisationParameters = arr

        Camera.OffAxisFFTViewport.Width = Camera.FFTPaddedWidth
        Camera.OffAxisFFTViewport.Height = Camera.FFTPaddedWidth
        Camera.OffAxisFFTViewport.X = CInt(Camera.OffAxisImageViewport.Width / 2 - Camera.OffAxisFFTViewport.Width / 2)
        Camera.OffAxisFFTViewport.Y = CInt(Camera.OffAxisImageViewport.Height / 2 - Camera.OffAxisFFTViewport.Width / 2)

        Dim _OverlapMatrix(,) As Double = MagnitudeOverlapMatrix()
        Dim RetVal As Double

        For i = 0 To _OverlapMatrix.GetLength(0) - 1
            For j = 0 To _OverlapMatrix.GetLength(1) - 1
                If i = j Then
                    RetVal += _OverlapMatrix(i, j)
                Else
                    'RetVal -= _OverlapMatrix(i, j)
                End If
            Next
        Next

        Dim str As String = ""
        For i = 0 To arr.Count - 1
            str = str & arr(i).ToString & "  "
        Next
        str = str & (RetVal / NoModes).ToString
        Console.WriteLine(str)

        Return RetVal / NoModes

    End Function
#End Region

End Class