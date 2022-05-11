' Ralf Mouthaan
' University of Cambridge
' April 2019
'
' A module with some data type conversions relevant to complex number data manipulation

Namespace TypeConversions
    Module modTypeConversions

        Public Function ComplexToComplexString(ByVal Input As Numerics.Complex) As String

            Dim Output As String

            Output = Input.Real.ToString("F3")
            If Input.Imaginary.ToString("F3").StartsWith("-") = False Then
                Output += "+"
            End If
            Output += Input.Imaginary.ToString("F3") + "i"

            Return Output

        End Function
        Public Function ComplexStringToComplex(ByVal Input As String) As Numerics.Complex

            ' Assumes:
            ' Input is of the form a + bi
            ' Assumes a and b are always given, even if one is zero.

            Dim bolRealNegative As Boolean
            Dim bolImagNegative As Boolean
            Dim splitstr() As String
            Dim Real As Double, Imag As Double

            If Input = "NaN" Then Return 0

            If Input.Contains("i") = False Then
                Return New Numerics.Complex(CDbl(Input), 0)
            End If
            Input = Input.Replace("i", "")

            If Input.StartsWith("-") Then
                bolRealNegative = True
                Input = Input.Substring(1)
            Else
                bolRealNegative = False
            End If

            If Input.Contains("-") Then
                bolImagNegative = True
                splitstr = Split(Input, "-")
            Else
                bolImagNegative = False
                splitstr = Split(Input, "+")
            End If

            Real = CDbl(splitstr(0))
            If bolRealNegative = True Then Real = -Real
            Imag = CDbl(splitstr(1))
            If bolImagNegative = True Then Imag = -Imag

            Return New Numerics.Complex(Real, Imag)

        End Function
        Public Function AngleToComplexString(ByVal Input As Double) As String

            Dim Output As String

            If Double.IsNaN(Input) Then Return "0"

            Output = Math.Cos(Input).ToString("F3")
            If Math.Sin(Input).ToString("F3").StartsWith("-") = False Then
                Output += "+"
            End If
            Output += Math.Sin(Input).ToString("F3")
            Output += "i"

            Return Output

        End Function
        Public Sub RealToComplex(ByRef Input(,) As Integer, ByRef Output As Numerics.Complex(,))

            ReDim Output(UBound(Input, 1), UBound(Input, 2))

            For i = 0 To UBound(Input, 1)
                For j = 0 To UBound(Input, 2)
                    Output(i, j) = New Numerics.Complex(Input(i, j), 0)
                Next
            Next

        End Sub
        Public Sub RealToComplex(ByRef Input(,) As Double, ByRef Output As Numerics.Complex(,))

            ReDim Output(UBound(Input, 1), UBound(Input, 2))

            For i = 0 To UBound(Input, 1)
                For j = 0 To UBound(Input, 2)
                    Output(i, j) = New Numerics.Complex(Input(i, j), 0)
                Next
            Next

        End Sub
        Public Sub ImageListToImage(ByVal lst As List(Of Integer(,)), ByRef Output As Double(,))

            'This routine accepts a list of integer images, and averages to obtain a double image output.

            'Error check
            If lst.Count = 0 Then
                Call Err.Raise(-1, "", "List is empty")
            End If

            'Declarations
            Dim Img As Integer(,)
            Dim NoImages As Integer

            'Initialisation
            Img = lst(0)
            NoImages = lst.Count
            ReDim Output(UBound(Img, 1), UBound(Img, 2))

            'Summation loop
            For z = 0 To NoImages - 1

                Img = lst(z)

                For i = 0 To UBound(Img, 1)
                    For j = 0 To UBound(Img, 2)
                        Output(i, j) += Img(i, j) / NoImages
                    Next
                Next

            Next

        End Sub

        Public Sub ImageListToImage(ByVal lst As List(Of Numerics.Complex(,)), ByRef Output As Numerics.Complex(,))

            'This routine accepts a list of complex images, and averages to obtain a complex image output

            If lst.Count = 0 Then
                Call Err.Raise(-1, "", "List is empty")
            End If

            Dim Img As Numerics.Complex(,)
            Dim NoImages As Integer

            Img = lst(0)
            NoImages = lst.Count
            ReDim Output(UBound(Img, 1), UBound(Img, 2))

            'Summation loop
            For z = 0 To NoImages - 1

                Img = lst(z)

                For i = 0 To UBound(Img, 1)
                    For j = 0 To UBound(Img, 2)
                        Output(i, j) += Img(i, j) / NoImages
                    Next
                Next

            Next


        End Sub

        Public Function MeanOfAngles(ByVal Angle1Radians As Double, ByVal Angle2Radians As Double) As Double

            Dim Real As Double
            Dim Imag As Double
            Dim RetVal As Double

            Real = Math.Cos(Angle1Radians) + Math.Cos(Angle2Radians)
            Imag = Math.Sin(Angle1Radians) + Math.Sin(Angle2Radians)

            RetVal = Math.Atan2(Imag, Real)

            Return RetVal

        End Function

    End Module
End Namespace