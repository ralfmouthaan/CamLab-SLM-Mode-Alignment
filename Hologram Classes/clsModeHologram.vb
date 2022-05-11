' Ralf Mouthaan
' University of Cambridge
' February 2020
'
' Class to hold a single hologram for a mode

Option Explicit On
Option Strict On

Public Class clsModeHologram
    Inherits clsHologram

    Public Sub New()
        Call MyBase.New
        bolHologramLoaded = False
    End Sub

    Public Property l As Integer
    Public Property m As Integer
    Public Property PropagationConstant As Double
    Public Property HologramEfficiency As Double

#Region "Class Overrides"

    'Width and height are mustoverride so must set them to something.
    'These normally relate to the hologram width and height.
    'In this class I would prefer to distinguish between hologram width + height and mode width + height.
    'So I have defined HologramWidth, HologramHeight, ModeWidth and ModeHeight
    'But the mustoverrides mean that these width and height parameters must still be defined - they are required by the SLM class.

    Public Overrides Property arrRawHologram As Double(,)
        Get
            Return _arrLoadedHologram
        End Get
        Set(value As Double(,))
            Call Err.Raise(-1, "Loaded Hologram Class", "Cannot set pixel values")
        End Set
    End Property
    Public Overrides Property arrRawHologram(i As Integer, j As Integer) As Double
        Get

            If i > _arrLoadedHologram.GetLength(0) - 1 Then Call Err.Raise(-1, "Mode Hologram Class", "index beyond array dimensions")
            If j > _arrLoadedHologram.GetLength(1) - 1 Then Call Err.Raise(-1, "Mode Hologram Class", "index beyond array dimensions")

            Return _arrLoadedHologram(i, j)

        End Get
        Set(value As Double)
            Call Err.Raise(-1, "Loaded Hologram Class", "Cannot set pixel values")
        End Set
    End Property
    Public Overrides Property RawWidth As Integer
        Get
            Return HologramWidth
        End Get
        Set(value As Integer)
            HologramWidth = value
        End Set
    End Property
    Public Overrides Property RawHeight As Integer
        Get
            Return HologramHeight
        End Get
        Set(value As Integer)
            HologramHeight = value
        End Set
    End Property
#End Region

#Region "Mode"

    Private _arrMode(,) As Double
    Public bolModeLoaded As Boolean

    Public ReadOnly Property ModeWidth As Integer
        Get
            Return arrMode.GetLength(0)
        End Get
    End Property
    Public ReadOnly Property ModeHeight As Integer
        Get
            Return arrMode.GetLength(1)
        End Get
    End Property

    Public Property arrMode As Double(,)
        Get
            Return _arrMode
        End Get
        Set(value As Double(,))
            _arrMode = value
        End Set
    End Property
    Public Property arrMode(ByVal i As Integer, ByVal j As Integer) As Double
        Get
            Return _arrMode(i, j)
        End Get
        Set(value As Double)
            _arrMode(i, j) = value
        End Set
    End Property

    Public Sub LoadMode(ByVal Filename As String)

        If IO.File.Exists(Filename) = False Then Call Err.Raise(-1, "Mode Hologram Class", "File not found")

        If Filename.ToLower.EndsWith(".txt") Then
            Call LoadModeTXT(Filename)
        ElseIf Filename.EndsWith(".csv") Then
            Call LoadModeCSV(Filename)
        ElseIf Filename.ToLower.EndsWith(".bmp") Then
            Call LoadModeBMP(Filename)
        End If

    End Sub

    Private Sub LoadModeTXT(ByVal Filename As String)

        If Filename.EndsWith(".txt") = False Then Call Err.Raise(-1, "Mode Hologram Class", "File must be a text file")

        Dim reader As IO.StreamReader
        Dim splitstr() As String

        reader = New IO.StreamReader(Filename)

        'First line
        splitstr = Split(reader.ReadLine, vbTab)
        If splitstr.Length Mod 2 = 0 Then
            ReDim _arrMode(splitstr.Length - 1, splitstr.Length - 1)
        Else
            ReDim _arrMode(splitstr.Length - 2, splitstr.Length - 2)
        End If
        For i = 0 To _arrMode.GetLength(0) - 1
            _arrMode(i, 0) = CDbl(splitstr(i))
        Next

        For j = 1 To _arrMode.GetLength(1) - 1
            If reader.EndOfStream = True Then Call Err.Raise(-1, "Mode Hologram Class", "Hologram does not seem to be square")
            splitstr = Split(reader.ReadLine, vbTab)
            For i = 0 To _arrMode.GetLength(0) - 1
                _arrMode(i, j) = CDbl(splitstr(i))
            Next
        Next

        reader.Close()

        bolModeLoaded = True

    End Sub
    Private Sub LoadModeCSV(ByVal Filename As String)

        If Filename.EndsWith(".csv") = False Then Call Err.Raise(-1, "Mode Hologram Class", "File must be a csv file")

        Dim reader As IO.StreamReader
        Dim splitstr() As String

        reader = New IO.StreamReader(Filename)

        'First line
        splitstr = Split(reader.ReadLine, ",")
        If splitstr.Length Mod 2 = 0 Then
            ReDim _arrMode(splitstr.Length - 1, splitstr.Length - 1)
        Else
            ReDim _arrMode(splitstr.Length - 2, splitstr.Length - 2)
        End If
        For i = 0 To _arrMode.GetLength(0) - 1
            _arrMode(i, 0) = CDbl(splitstr(i))
        Next

        For j = 1 To _arrMode.GetLength(1) - 1
            If reader.EndOfStream = True Then Call Err.Raise(-1, "Mode Hologram Class", "Hologram does not seem to be square")
            splitstr = Split(reader.ReadLine, ",")
            For i = 0 To _arrMode.GetLength(0) - 1
                _arrMode(i, j) = CDbl(splitstr(i))
            Next
        Next

        reader.Close()

        bolModeLoaded = True

    End Sub
    Private Sub LoadModeBMP(ByVal Filename As String)

        Dim bm As New Bitmap(Filename)

        If bm.Width Mod 2 = 0 Then
            ReDim _arrMode(bm.Width - 1, bm.Height - 1)
        Else
            ReDim _arrMode(bm.Width - 2, bm.Height - 2)
        End If

        For i = 0 To _arrMode.GetLength(0) - 1
            For j = 0 To arrMode.GetLength(1) - 1
                _arrMode(i, j) = bm.GetPixel(i, j).R / 255 * 2 * Math.PI
            Next
        Next

        bolModeLoaded = True

        'Dim bData As Imaging.BitmapData = bm.LockBits(New Rectangle(0, 0, bm.Width, bm.Height), Imaging.ImageLockMode.ReadOnly, bm.PixelFormat)

    End Sub

#End Region

#Region "Hologram"

    Private _arrLoadedHologram(,) As Double
    Public bolHologramLoaded As Boolean

    Public Property HologramWidth As Integer
        Get
            Return _arrLoadedHologram.GetLength(0)
        End Get
        Set(value As Integer)
            Call Err.Raise(-1, "Mode Hologram Class", "Cannot set hologram width")
        End Set
    End Property
    Public Property HologramHeight As Integer
        Get
            Return _arrLoadedHologram.GetLength(1)
        End Get
        Set(value As Integer)
            Call Err.Raise(-1, "Mode Hologram Class", "Cannot set hologram height")
        End Set
    End Property

    Public Sub LoadHologram(ByVal Filename As String)

        If IO.File.Exists(Filename) = False Then Call Err.Raise(-1, "Mode Hologram Class", "File not found")

        If Filename.ToLower.EndsWith(".txt") Then
            Call LoadHologramTXT(Filename)
        ElseIf Filename.EndsWith(".csv") Then
            Call LoadBinHologramCSV(Filename)
        ElseIf Filename.ToLower.EndsWith(".bmp") Then
            Call LoadHologramBMP(Filename)
        End If

    End Sub

    Private Sub LoadHologramTXT(ByVal Filename As String)

        If Filename.EndsWith(".txt") = False Then Call Err.Raise(-1, "Mode Hologram Class", "File must be a text file")

        Dim reader As IO.StreamReader
        Dim splitstr() As String

        reader = New IO.StreamReader(Filename)

        'First line
        splitstr = Split(reader.ReadLine, vbTab)
        ReDim _arrLoadedHologram(splitstr.Length - 1, splitstr.Length - 1)
        For i = 0 To splitstr.Length - 1
            _arrLoadedHologram(i, 0) = CDbl(splitstr(i))
        Next


        For j = 1 To _arrLoadedHologram.GetLength(1) - 1
            If reader.EndOfStream = True Then Call Err.Raise(-1, "Mode Hologram Class", "Hologram does not seem to be square")
            splitstr = Split(reader.ReadLine, vbTab)
            For i = 0 To _arrLoadedHologram.GetLength(0) - 1
                _arrLoadedHologram(i, j) = CDbl(splitstr(i))
            Next
        Next

        reader.Close()

        bolHologramLoaded = True

    End Sub
    Private Sub LoadBinHologramCSV(ByVal Filename As String)

        'Assumes hologram is binary with data stored as +1s and -1s

        If Filename.EndsWith(".csv") = False Then Call Err.Raise(-1, "Loaded Hologram Class", "File must be a csv file")

        Dim reader As IO.StreamReader
        Dim splitstr() As String

        reader = New IO.StreamReader(Filename)

        'First line
        splitstr = Split(reader.ReadLine, ",")
        ReDim _arrLoadedHologram(splitstr.Length - 1, splitstr.Length - 1)
        For i = 0 To splitstr.Length - 1
            _arrLoadedHologram(i, 0) = CDbl(splitstr(i)) / 2 * Math.PI
        Next


        For j = 1 To _arrLoadedHologram.GetLength(1) - 1
            If reader.EndOfStream = True Then Call Err.Raise(-1, "Loaded Hologram Class", "Hologram does not seem to be square")
            splitstr = Split(reader.ReadLine, ",")
            For i = 0 To _arrLoadedHologram.GetLength(0) - 1
                _arrLoadedHologram(i, j) = CDbl(splitstr(i)) / 2 * Math.PI
            Next
        Next

        reader.Close()

        bolHologramLoaded = True

    End Sub
    Private Sub LoadPhaseHologramCSV(ByVal Filename As String)

        If Filename.EndsWith(".csv") = False Then Call Err.Raise(-1, "Mode Hologram Class", "File must be a csv file")

        Dim reader As IO.StreamReader
        Dim splitstr() As String

        reader = New IO.StreamReader(Filename)

        'First line
        splitstr = Split(reader.ReadLine, ",")
        ReDim _arrLoadedHologram(splitstr.Length - 1, splitstr.Length - 1)
        For i = 0 To splitstr.Length - 1
            _arrLoadedHologram(i, 0) = CDbl(splitstr(i))
        Next


        For j = 1 To _arrLoadedHologram.GetLength(1) - 1
            If reader.EndOfStream = True Then Call Err.Raise(-1, "Mode Hologram Class", "Hologram does not seem to be square")
            splitstr = Split(reader.ReadLine, ",")
            For i = 0 To _arrLoadedHologram.GetLength(0) - 1
                _arrLoadedHologram(i, j) = CDbl(splitstr(i))
            Next
        Next

        reader.Close()

        bolHologramLoaded = True

    End Sub
    Private Sub LoadHologramBMP(ByVal Filename As String)

        Dim bm As New Bitmap(Filename)
        ReDim _arrLoadedHologram(bm.Width - 1, bm.Height - 1)

        For i = 0 To bm.Height - 1
            For j = 0 To bm.Width - 1
                _arrLoadedHologram(i, j) = bm.GetPixel(i, j).R / 255 * 2 * Math.PI
            Next
        Next

        bolHologramLoaded = True

        'Dim bData As Imaging.BitmapData = bm.LockBits(New Rectangle(0, 0, bm.Width, bm.Height), Imaging.ImageLockMode.ReadOnly, bm.PixelFormat)

    End Sub
#End Region

End Class
