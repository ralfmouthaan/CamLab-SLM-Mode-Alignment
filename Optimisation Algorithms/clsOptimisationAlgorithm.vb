' Ralf Mouthaan
' University of Cambridge
' April 2018
' 
' Template class for optimisation algorithm classes
' User sets:
'   * intNoVariableZernikes - the number of Zernikes to be varied
'   * funEvaluateObjective - the evaluation function must be of type delEvaluateObjective
'   * DoWork - the optimisation function
' Once work is completed, or has been stopped using StopExecution(), the event ExecutionFinished() is raised and arrBestZernikes contains the best obtained results.

Option Explicit On
Option Strict On

Public MustInherit Class clsOptimisationAlgorithm

    Protected bw As ComponentModel.BackgroundWorker
    Public dblBestValue As Double

    Public Delegate Function delEvaluateObjective(ByVal arrTrialZernikes() As Double) As Double
    Public funEvaluateObjective As delEvaluateObjective
    Public dblMultiplier As Double

    Protected _strAlgorithmName As String
    Public ReadOnly Property strAlgorithmName As String
        Get
            Return _strAlgorithmName
        End Get
    End Property

    Public Event ImprovementFound()
    Public Event ExecutionFinished()

    Public Overridable Sub StartExecution()
        bw = New ComponentModel.BackgroundWorker
        AddHandler bw.DoWork, AddressOf DoWork
        AddHandler bw.RunWorkerCompleted, AddressOf OnWorkComplete
        AddHandler bw.ProgressChanged, AddressOf OnProgressChanged
        bw.WorkerSupportsCancellation = True
        bw.WorkerReportsProgress = True
        bw.RunWorkerAsync()
    End Sub
    Public Overridable Sub StopExecution()

        bw.CancelAsync()
        Do
            Application.DoEvents()
        Loop Until bw.IsBusy = False

    End Sub

    Protected MustOverride Sub DoWork(sender As Object, e As ComponentModel.DoWorkEventArgs)
    Protected Overridable Sub OnWorkComplete(sender As Object, e As ComponentModel.RunWorkerCompletedEventArgs)
        RaiseEvent ExecutionFinished()
    End Sub
    Protected Overridable Sub OnProgressChanged(sender As Object, e As ComponentModel.ProgressChangedEventArgs)
        RaiseEvent ImprovementFound()
    End Sub

End Class
