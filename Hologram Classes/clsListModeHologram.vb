' Ralf Mouthaan
' University of Cambridge
' February 2020
'
' List hologram class.

Option Strict On
Option Explicit On

Public Class clsListModeHologram
    Inherits clsHologram

    Private _HoloIndex As Integer 'Hologram shown at this moment
    Private _lstHologram As List(Of clsModeHologram)

    Public Sub New()
        Call MyBase.New
        _lstHologram = New List(Of clsModeHologram)
    End Sub

    Public ReadOnly Property lstHologram As List(Of clsModeHologram)
        Get
            Return _lstHologram
        End Get
    End Property
    Public ReadOnly Property HologramCount As Integer
        Get
            Return _lstHologram.Count
        End Get
    End Property
    Public Sub AddHologram(ByRef Holo As clsModeHologram)
        _lstHologram.Add(Holo)
    End Sub
    Public Function CreateHologram() As clsModeHologram
        Dim Holo As New clsModeHologram
        _lstHologram.Add(Holo)
        Return Holo
    End Function
    Public Function CurrentHologram() As clsModeHologram
        Return _lstHologram(_HoloIndex)
    End Function
    Public Property HoloIndex As Integer
        Get
            Return _HoloIndex
        End Get
        Set(value As Integer)
            If value > _lstHologram.Count - 1 Then
                Call Err.Raise(-1, "List Hologram", "HoloIndex is out of bounds")
            End If
            _HoloIndex = value
        End Set
    End Property

    Public Overrides Property RawWidth As Integer
        Get
            If _lstHologram.Count = 0 Then Call Err.Raise(-1, "List Hologram", "Hologram list is empty")
            Return _lstHologram(0).RawWidth
        End Get
        Set(value As Integer)
            Call Err.Raise(-1, "List Hologram", "Need to set width of holograms in list")
        End Set
    End Property
    Public Overrides Property RawHeight As Integer
        Get
            If _lstHologram.Count = 0 Then Call Err.Raise(-1, "List Hologram", "Hologram list is empty")
            Return _lstHologram(0).RawWidth
        End Get
        Set(value As Integer)
            Call Err.Raise(-1, "List Hologram", "Need to set height of holograms in list")
        End Set
    End Property

    Public Overrides Property arrRawHologram As Double(,)
        Get
            Return lstHologram(HoloIndex).arrRawHologram
        End Get
        Set(value As Double(,))
            Call Err.Raise(-1, "List Hologram", "Need to add hologram using AddHologram()")
        End Set
    End Property
    Public Overrides Property arrRawHologram(i As Integer, j As Integer) As Double
        Get
            Return _lstHologram(HoloIndex).arrRawHologram(i, j)
        End Get
        Set(value As Double)
            Call Err.Raise(-1, "List Hologram", "Need to add hologram using AddHologram()")
        End Set
    End Property

End Class
