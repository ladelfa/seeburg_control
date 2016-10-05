Imports System.IO


Public Class clsNeedleTimeCounter
  Const NEEDLE_TIME_LOG_FILE = "NeedleTime.txt"
  Const WRITE_LOG_EVERY_NN_MINUTES = 5

  Private m_bCurrentlyOn As Boolean
  Private m_dLastComputedAt As Date
  Private m_lTotalNeedleTime As Long
  Private m_dLastLogAccess As Date

  Public Sub New()
    m_bCurrentlyOn = False
    m_lTotalNeedleTime = ReadTotalTimeFromFile()
    m_dLastComputedAt = Date.Now
    m_dLastLogAccess = Date.Now
  End Sub

  Protected Overrides Sub Finalize()
    LogToFileNow()
    MyBase.Finalize()
  End Sub

  Public Sub CurrentlyOn()
    If Not m_bCurrentlyOn Then
      ' Was off, is on
      m_bCurrentlyOn = True
      m_dLastComputedAt = Date.Now
    Else
      ' Was on, is still on
      UpdateTimeSinceLast()
    End If
  End Sub

  Public Sub CurrentlyOff()
    If m_bCurrentlyOn Then
      ' Was on, is off
      UpdateTimeSinceLast()
      m_bCurrentlyOn = False
    Else
      ' Was off, is still off
    End If
  End Sub

  Public Function TotalNeedleTime() As TimeSpan
    Return TimeSpan.FromSeconds(m_lTotalNeedleTime)
  End Function

  Public Function TotalNeedleTimeString() As String
    Dim span As TimeSpan = TotalNeedleTime()
    Return CInt(span.TotalHours) & span.ToString("\:mm\:ss")
  End Function

  Private Sub UpdateTimeSinceLast()
    Dim lElapsedSeconds As Long = DateDiff(DateInterval.Second, m_dLastComputedAt, Now)
    m_dLastComputedAt = Now
    m_lTotalNeedleTime = m_lTotalNeedleTime + lElapsedSeconds
    PeriodicallyLogToFile()
  End Sub

  Private Function ReadTotalTimeFromFile() As Long
    Dim lSeconds As Long = 0
    If File.Exists(NEEDLE_TIME_LOG_FILE) Then
      lSeconds = CLng(File.ReadAllText(NEEDLE_TIME_LOG_FILE))
    End If
    m_dLastLogAccess = Now
    Return lSeconds
  End Function

  Private Sub PeriodicallyLogToFile()
    If DateDiff(DateInterval.Minute, m_dLastLogAccess, Now) >= WRITE_LOG_EVERY_NN_MINUTES Then
      LogToFileNow()
    End If
  End Sub

  Private Sub LogToFileNow()
    File.WriteAllText(NEEDLE_TIME_LOG_FILE, m_lTotalNeedleTime)
    m_dLastLogAccess = Now
  End Sub

End Class
