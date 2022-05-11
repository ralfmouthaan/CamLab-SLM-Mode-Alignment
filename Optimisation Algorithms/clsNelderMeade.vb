' Ralf Mouthaan
' University of Cambridge
' April 2018
'
' Nelder-Meade algorithm
' Based on Ch. 10.5 of NR

Option Explicit On
Option Strict On

Imports System.ComponentModel

Public Class clsNelderMeade
    Inherits clsOptimisationAlgorithm

    Private tol As Double = 1.0E-20

    Public arrDelta() As Double

    Public Sub New()
        _strAlgorithmName = "Nelder-Meade"
    End Sub

    Protected Overrides Sub DoWork(sender As Object, e As DoWorkEventArgs)

        Dim arrInitialGuess As Double()
        Dim arrBestZernikes() As Double

        Dim NoDims As Integer = MeasurementSetup.arrOptimisationParametersCount
        Dim NoVertices As Integer = NoDims + 1
        Dim lstVertices As New List(Of Double())
        Dim arrVertex() As Double
        Dim y() As Double
        Dim ytemp As Double, ytemp2 As Double
        Dim psum() As Double
        Dim indHi1 As Integer, indHi2 As Integer, indLo As Integer

        ReDim arrInitialGuess(NoDims - 1)
        For i = 0 To NoDims - 1
            arrInitialGuess(i) = MeasurementSetup.arrOptimisationParameters(i)
        Next

        'Set arrDelta if necessary
        If arrDelta Is Nothing Then
            ReDim arrDelta(arrInitialGuess.Count - 1)
            For i = 0 To arrDelta.Count - 1
                If Math.Abs(arrInitialGuess(i)) < 1 Then
                    arrDelta(i) = 0.1 / NoDims * dblMultiplier
                Else
                    arrDelta(i) = 2 * dblMultiplier
                End If
            Next
        End If

        'Initial guess starts out as best guess
        ReDim arrBestZernikes(NoDims - 1)
        For i = 0 To arrInitialGuess.Count - 1
            arrBestZernikes(i) = arrInitialGuess(i)
        Next

        'Create empty vertex and value arrays.
        'These will be populated within the loop
        ReDim y(NoVertices - 1)
        For i = 0 To NoVertices - 1
            ReDim arrVertex(NoDims - 1)
            lstVertices.Add(arrVertex)
        Next

        'MAIN LOOP
        Do

            'Check if cancellation is pending
            If bw.CancellationPending Then
                MeasurementSetup.ShutDown()
                For i = 0 To arrBestZernikes.Count - 1
                    MeasurementSetup.arrOptimisationParameters(i) = arrBestZernikes(i)
                Next
                Return
            End If

            'Find highest two and lowest vertices
            indLo = 0
            If y(0) > y(1) Then
                indHi1 = 0 : indHi2 = 1
            Else
                indHi1 = 1 : indHi2 = 0
            End If
            For i = 0 To NoVertices - 1
                If y(i) <= y(indLo) Then indLo = i
                If y(i) > y(indHi1) Then
                    indHi2 = indHi1
                    indHi1 = i
                ElseIf y(i) > y(indHi2) And i <> indHi1 Then
                    indHi2 = i
                End If
            Next

            'If vertices are too similar, reinitialise
            'Create initial simplex and evaluate at each vertex
            If 2 * Math.Abs(y(indHi1) - y(indLo)) / Math.Abs(y(indHi1) + y(indLo) + tol) < 0.05 Then

                'First entry is the best guess so far
                For i = 0 To arrBestZernikes.Count - 1
                    lstVertices(0)(i) = arrBestZernikes(i)
                Next
                y(0) = funEvaluateObjective(lstVertices(0))
                dblBestValue = y(0)

                'Further entries are perturbations of the best guess
                For i = 0 To NoDims - 1
                    ReDim arrVertex(NoDims - 1)
                    For j = 0 To NoDims - 1
                        arrVertex(j) = arrBestZernikes(j)
                        arrVertex(j) += arrDelta(j) * (Rnd() * 2 - 1)
                    Next
                    lstVertices(i + 1) = arrVertex
                    y(i + 1) = funEvaluateObjective(arrVertex)
                    If y(i + 1) < dblBestValue Then
                        dblBestValue = y(i + 1)
                        arrBestZernikes = arrVertex
                    End If
                Next

                bw.ReportProgress(0)
                Continue Do

            End If

            'Compute psum
            'Note, this is the sum of the ith element of all vertices, not the sum of all elements of a vertex.
            ReDim psum(0 To NoDims - 1)
            For i = 0 To NoDims - 1
                For j = 0 To NoVertices - 1
                    psum(i) += lstVertices(j)(i)
                Next
            Next

            'Find a new trial point, evaluate, check if new point is an improvement
            ReDim arrVertex(NoDims - 1)
            For i = 0 To NoDims - 1
                arrVertex(i) = psum(i) * 2 / NoDims - lstVertices(indHi1)(i) * (1 + 2 / NoDims)
            Next
            ytemp = funEvaluateObjective(arrVertex)
            If ytemp < y(indHi1) Then
                lstVertices(indHi1) = arrVertex
                y(indHi1) = ytemp
            End If

            ' If new point is better than best point, continue moving in this direction
            If ytemp <= y(indLo) Then
                ReDim arrVertex(NoDims - 1)
                For i = 0 To NoDims - 1
                    arrVertex(i) = -psum(i) / NoDims + lstVertices(indHi1)(i) * (1 / NoDims + 2)
                Next
                ytemp2 = funEvaluateObjective(arrVertex)
                If ytemp2 < y(indHi1) Then
                    lstVertices(indHi1) = arrVertex
                    y(indHi1) = ytemp2
                End If
            End If

            ' New point is still worse than second-worst point.
            If ytemp >= y(indHi2) Then

                'Try a one-dimensional contraction
                ReDim arrVertex(NoDims - 1)
                For i = 0 To NoDims - 1
                    arrVertex(i) = psum(i) * 0.5 / NoDims - lstVertices(indHi2)(i) * (0.5 / NoDims - 0.5)
                Next
                ytemp2 = funEvaluateObjective(arrVertex)
                If ytemp2 < y(indHi1) Then
                    lstVertices(indHi1) = arrVertex
                    y(indHi1) = ytemp2
                End If

                'Still no improvement - contract around lowest point
                If ytemp2 >= y(indHi1) Then
                    For i = 0 To NoVertices - 1
                        If i <> indLo Then
                            For j = 0 To NoDims - 1
                                lstVertices(i)(j) = (lstVertices(i)(j) + lstVertices(indLo)(j)) / 2
                            Next
                            y(i) = funEvaluateObjective(lstVertices(i))
                            If y(i) < dblBestValue Then
                                arrBestZernikes = lstVertices(i)
                                dblBestValue = y(i)
                                bw.ReportProgress(0)
                            End If
                        End If
                    Next
                End If

            End If

            If y(indHi1) < dblBestValue Then
                arrBestZernikes = lstVertices(indHi1)
                dblBestValue = y(indHi1)
                bw.ReportProgress(0)
            End If

        Loop Until False

    End Sub

End Class
