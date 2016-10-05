Imports System.Threading
Imports System.ComponentModel

Public Class clsPlayTimer
  Private WithEvents m_oBgrdClockWatcher As BackgroundWorker

  Private m_dTurnOffAt As Date
  Private m_bPlaying As Boolean
  Public Event TurnOffNow()

  Private Const km_iMaxMinutesOn As Integer = 120

  Public Sub New()
    m_dTurnOffAt = Now
    m_bPlaying = False
    m_oBgrdClockWatcher = New BackgroundWorker
    With m_oBgrdClockWatcher
      .WorkerReportsProgress = True
      .WorkerSupportsCancellation = True
      .RunWorkerAsync()
    End With

  End Sub

  Protected Overrides Sub Finalize()
    m_oBgrdClockWatcher.CancelAsync()
    MyBase.Finalize()
  End Sub

  Public Sub ClearTime()
    m_dTurnOffAt = Now
    m_bPlaying = False
  End Sub

  Public Sub AddTime(ByVal iMinutesToAdd As Integer)
    Dim iMinutesLeft As Integer
    If m_bPlaying Then
      iMinutesLeft = MinutesLeft() + iMinutesToAdd
    Else
      iMinutesLeft = iMinutesToAdd
      m_bPlaying = True
    End If
    If iMinutesLeft > km_iMaxMinutesOn Then iMinutesLeft = km_iMaxMinutesOn

    m_dTurnOffAt = DateAdd(DateInterval.Minute, iMinutesLeft, Now)
  End Sub

  Public Function MinutesLeft() As Integer
    Dim iMinutesLeft As Integer

    If m_bPlaying Then
      iMinutesLeft = DateDiff(DateInterval.Minute, Now, m_dTurnOffAt) + 1
      If iMinutesLeft < 0 Then iMinutesLeft = 0
    Else
      iMinutesLeft = 0
    End If

    Return iMinutesLeft
  End Function


  Public Function IsPlaying() As Boolean
    Return m_bPlaying
  End Function


  Private Sub m_oBgrdClockWatcher_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles m_oBgrdClockWatcher.DoWork
    Do Until m_oBgrdClockWatcher.CancellationPending
      If m_bPlaying Then
        If m_dTurnOffAt < Now Then
          m_oBgrdClockWatcher.ReportProgress(0)
          m_bPlaying = False
        End If
      End If
      Threading.Thread.Sleep(1000)
    Loop

  End Sub

  Private Sub m_oBgrdClockWatcher_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles m_oBgrdClockWatcher.ProgressChanged
    RaiseEvent TurnOffNow()
  End Sub
End Class
