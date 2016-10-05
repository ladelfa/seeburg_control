Imports System.IO
Imports System.Threading
Imports System.ComponentModel
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Runtime.Serialization.Formatters.Soap

Public Class frmMain
  Private WithEvents m_oComBoard As clsComBoard
  Private WithEvents m_oWebServer As clsWebServer
  Private WithEvents m_oPlayTimer As clsPlayTimer
  Private WithEvents m_oNeedleTimeCounter As New clsNeedleTimeCounter

  Private m_tCurrentState As String
  Private m_bLastStateIO5 As Boolean
  Private m_dLastAudioConnectionSeenAt As Date

  Private Settings As New clsSettings

  '**************************************************************
  'Form Load
  '*************************************************************
  Private Sub MyBase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    If File.Exists("settings.xml") Then
      Dim myFileStream As Stream = File.OpenRead("settings.xml")
      Dim deserializer As New SoapFormatter()
      Try
        Settings = CType(deserializer.Deserialize(myFileStream), clsSettings)
      Catch
        Settings = New clsSettings
      End Try

      myFileStream.Close()
    End If

    With Settings
      txtHTTPPort.Text = .Port_HTTP
      chkShowHTTPLog.Checked = .ShowLogs_HTTP
      chkShowComLog.Checked = .ShowLogs_Com
      chkAutoStartHTTP.Checked = .StartHTTPAtStartup
      chkEnablePlayTimer.Checked = .EnablePlayTimer
      txtStatusCgiUrl.Text = .StatusCgiUrl
      txtAudioPort.Text = .Port_Audio
      chkSetStandbyAtLaunch.Checked = .SetStatusToStandbyAtStartup
      chkPowerDownWhenNoConnections.Checked = .PowerDownWhenNoConnections
      txtMinutesToAdd.Text = .DefaultMinutesToAddViaButton
    End With

    m_oComBoard = New clsComBoard
    txtComPort.Text = m_oComBoard.PortName

    m_oWebServer = New clsWebServer
    m_oPlayTimer = New clsPlayTimer

    m_dLastAudioConnectionSeenAt = Now

    timerRefreshPowerControl.Interval = 1000
    timerRefreshPowerControl.Start()

    timerScanIO.Interval = 10
    timerScanIO.Start()

    timerRunoutSaver.Enabled = False

    If chkAutoStartHTTP.Checked Then cmdStartHTTP.PerformClick()
    If chkSetStandbyAtLaunch.Checked Then cmdStateStandby.PerformClick()

    With cboStatusCgiStates
      .Items.Clear()
      .Items.AddRange({"off", "standby", "public_play", "home_play", "maintenance"})
      .SelectedIndex = 0
    End With
    UpdateRelayStatuses()
    GetStateFromRemote()
  End Sub


  Private Sub MyBase_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
    With Settings
      .Port_HTTP = CInt(txtHTTPPort.Text)
      .ShowLogs_Com = chkShowComLog.Checked
      .ShowLogs_HTTP = chkShowHTTPLog.Checked
      .StartHTTPAtStartup = chkAutoStartHTTP.Checked
      .EnablePlayTimer = chkEnablePlayTimer.Checked
      .StatusCgiUrl = txtStatusCgiUrl.Text
      .Port_Audio = CInt(txtAudioPort.Text)
      .SetStatusToStandbyAtStartup = chkSetStandbyAtLaunch.Checked
      .PowerDownWhenNoConnections = chkPowerDownWhenNoConnections.Checked
      .DefaultMinutesToAddViaButton = txtMinutesToAdd.Text
    End With

    Dim myFileStream As Stream = File.Create("settings.xml")
    Dim serializer As New SoapFormatter()
    serializer.Serialize(myFileStream, Settings)
    myFileStream.Close()
  End Sub


  Private Sub Relay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    m_oComBoard.RelayTest()
  End Sub

  Private Sub CloseRelayMomentarily(ByVal iWhichRelay As Integer, Optional ByVal lLength As Integer = 300)
    If m_oComBoard.SetRelay(iWhichRelay, True) Then UpdateRelayStatuses()
    Threading.Thread.Sleep(lLength)
    If m_oComBoard.SetRelay(iWhichRelay, False) Then UpdateRelayStatuses()
  End Sub

  Private Sub UpdateRelayStatuses()
    chkRelayStatus1.Checked = m_oComBoard.RelayIsClosed(1)
    chkRelayStatus2.Checked = m_oComBoard.RelayIsClosed(2)
  End Sub

  Private Sub ComOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComOpen.Click
    Dim isOpen As Boolean = m_oComBoard.OpenPort()
    Relay.Enabled = isOpen      ' "Relay" button
    ComClose.Enabled = isOpen   ' "Close Port" button
  End Sub

  Private Sub ComClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComClose.Click
    Dim isClosed As Boolean = m_oComBoard.ClosePort()
    Relay.Enabled = Not isClosed      ' "Relay" button
    ComClose.Enabled = Not isClosed   ' "Close Port" button
  End Sub

  Private Sub cmdRelayMomentary_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRelayMomentary_1.Click
    CloseRelayMomentarily(1)
  End Sub

  Private Sub cmdRelayMomentary_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRelayMomentary_2.Click
    CloseRelayMomentarily(2)
  End Sub

  Private Sub chkRelayStatus1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRelayStatus1.CheckedChanged
    m_oComBoard.SetRelay(1, chkRelayStatus1.Checked)
  End Sub

  Private Sub chkRelayStatus2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRelayStatus2.CheckedChanged
    m_oComBoard.SetRelay(2, chkRelayStatus2.Checked)
  End Sub

  Private Sub cmdQuery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdQuery.Click
    m_oComBoard.GetResponse(txtQuery.Text)
  End Sub

  Private Sub cmdQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdQuit.Click
    m_oComBoard.ClosePort()
    Me.Close()
  End Sub

  Private Sub lnkClearComLog_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkClearComLog.LinkClicked
    txtComLog.Clear()
  End Sub

  Private Sub txtQuery_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQuery.KeyDown
    If e.KeyCode = Keys.Enter Then
      cmdQuery.PerformClick()
    End If
  End Sub


  Private Sub cmdStartHTTP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStartHTTP.Click
    m_oWebServer.StartListening(CInt(txtHTTPPort.Text))
    cmdStartHTTP.Enabled = False
    cmdStopHTTP.Enabled = True
  End Sub

  Private Sub cmdStopHTTP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdStopHTTP.Click
    m_oWebServer.StopListening()
    cmdStartHTTP.Enabled = True
    cmdStopHTTP.Enabled = False
  End Sub

  Private Sub txtTestHTTP_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTestHTTP.KeyDown
    If e.KeyCode = Keys.Enter Then
      cmdTestHTTP.PerformClick()
    End If
  End Sub
  Private Sub lnkClearHTTPLog_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkClearHTTPLog.LinkClicked
    txtHTTPLog.Clear()
  End Sub

  Private Sub m_oComBoard_DebugStatement(ByVal t As String) Handles m_oComBoard.DebugStatement
    If chkShowComLog.Checked Then txtComLog.AppendText(t & vbCrLf)
  End Sub

  Private Sub cmdVersion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVersion.Click
    m_oComBoard.GetResponse("vers")
  End Sub

  Private Sub m_oWebServer_DebugStatement(ByVal t As String) Handles m_oWebServer.DebugStatement
    If chkShowHTTPLog.Checked Then txtHTTPLog.AppendText(t & vbCrLf)
  End Sub

  Private Sub m_oWebServer_HandleRequest(ByVal tRequest As String, ByRef tResponse As String) Handles m_oWebServer.HandleRequest
    tResponse = HandleRequest(tRequest)
  End Sub

  ' This is where we decide what to do when a given URL comes in.
  Function HandleRequest(ByVal tRequest As String) As String
    Dim tResponse As String
    ' Permittd requests: reject test version powerup powerdown_now powerdown_delayed add_time get_minutes_remaining
    Dim bMachineIsControllable As Boolean
    bMachineIsControllable = (m_tCurrentState = "public_play" Or m_tCurrentState = "standby")

    Select Case tRequest
      Case "/reject"
        If bMachineIsControllable Then
          tResponse = "Rejecting record."
          RejectRecord()
        Else
          tResponse = "Machine cannot be controlled at this time."
        End If

      Case "/powerup"
        If bMachineIsControllable Then
          tResponse = "Powering up and disabling play timer."
          PowerUpAndDisableTimer()
        Else
          tResponse = "Machine cannot be controlled at this time."
        End If

      Case "/powerdown_delayed"
        If bMachineIsControllable Then
          tResponse = "Powering down after current record finishes."
          PowerDownAfterCurrentRecord()
        Else
          tResponse = "Machine cannot be controlled at this time."
        End If

      Case "/powerdown_now"
        If bMachineIsControllable Then
          tResponse = "Powering down immediately."
          PowerDownImmediately()
        Else
          tResponse = "Machine cannot be controlled at this time."
        End If

      Case "/test", "/version"
        tResponse = m_oComBoard.GetResponse("vers")
        m_oComBoard.ClosePort()

      Case "/add_time"
        If bMachineIsControllable Then
          tResponse = "Enabling play timer and adding 10 minutes of play time."
          AddTime(10)
        Else
          tResponse = "Machine cannot be controlled at this time."
        End If

      Case "/get_minutes_remaining"
        tResponse = m_oPlayTimer.MinutesLeft

      Case "/get_current_audio_connections"
        tResponse = String.Join(vbCrLf, CurrentAudioConnections(CInt(txtAudioPort.Text)))

      Case "/drop_audio_connections_to"
        tResponse = ""

      Case "/get_current_audio_connection_count"
        tResponse = CurrentAudioConnections(CInt(txtAudioPort.Text)).Count

      Case Else
        tResponse = "Unsupported command."
    End Select

    Return tResponse
  End Function

  Private Sub AddTime(ByVal iMinutes As Integer)
    m_oPlayTimer.AddTime(iMinutes)
    chkEnablePlayTimer.Checked = True
    If chkPowerDownWhenNoConnections.Checked Then
      ' Reset this now so that user has at least minute to establish an audio connection.
      m_dLastAudioConnectionSeenAt = Now
    End If
    PowerUp()
    SetState("public_play")
  End Sub

  Private Sub GoToStandbyMode()
    PowerDownAfterCurrentRecord()
    m_oPlayTimer.ClearTime()
    SetState("standby")
  End Sub

  Private Sub RejectRecord()
    CloseRelayMomentarily(1) ' Reject record
    m_oComBoard.ClosePort()
  End Sub

  Private Sub PowerUp()
    m_oComBoard.SetRelay(2, True) 'Power up
    UpdateRelayStatuses()
    m_oComBoard.ClosePort()
  End Sub

  Private Sub PowerUpAndDisableTimer()
    PowerUp()
    m_oPlayTimer.ClearTime()
    chkEnablePlayTimer.Checked = False
  End Sub

  Private Sub PowerDownAfterCurrentRecord()
    m_oComBoard.SetRelay(2, False) ' Power down 
    UpdateRelayStatuses()
    m_oComBoard.ClosePort()
    m_oPlayTimer.ClearTime()
    EngageRunoutSaver()
  End Sub

  Private Sub PowerDownImmediately()
    m_oComBoard.SetRelay(1, True)  ' Reject record
    m_oComBoard.SetRelay(2, False) ' Power down
    UpdateRelayStatuses()
    Threading.Thread.Sleep(2000)   ' Wait 2 seconds
    m_oComBoard.SetRelay(1, False) ' Release relay
    UpdateRelayStatuses()
    m_oComBoard.ClosePort()
    m_oPlayTimer.ClearTime()
  End Sub

  Private Sub cmdTestHTTP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTestHTTP.Click
    txtHTTPLog.AppendText(HandleRequest(txtTestHTTP.Text) & vbCrLf)
  End Sub

  Private Sub cmdAddMinutes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddMinutes.Click
    AddTime(CInt(txtMinutesToAdd.Text))
  End Sub

  Private Sub lblMinutesLeft_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblMinutesLeft.Click
    If m_oPlayTimer.IsPlaying Then
      lblMinutesLeft.Text = m_oPlayTimer.MinutesLeft & " minutes left"
    Else
      lblMinutesLeft.Text = "Not playing"
    End If
  End Sub

  Private Sub timerRefreshPowerControl_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerRefreshPowerControl.Tick
    If chkEnablePlayTimer.Checked Then
      If m_oPlayTimer.IsPlaying Then
        lblMinutesLeft.Text = m_oPlayTimer.MinutesLeft & " minutes left"
      Else
        lblMinutesLeft.Text = "Not playing"
      End If
    Else
      lblMinutesLeft.Text = "Disabled"
    End If

    If chkUpdateNeedleTime.Checked Then UpdateNeedleTimeCounter()

    UpdateAudioTraffic()

    If SecondsSinceLastAudioConnection() > 0 Then
      lblConnectionLastSeenAt.Text = TimeSpan.FromSeconds(SecondsSinceLastAudioConnection).ToString & " without conn"
    Else
      lblConnectionLastSeenAt.Text = ""
    End If

    If m_oPlayTimer.IsPlaying And _
        chkPowerDownWhenNoConnections.Checked And _
        SecondsSinceLastAudioConnection() >= 60 Then
      GoToStandbyMode()
    End If
  End Sub
  ' Keeps track of the total number of minutes the 
  Private Sub UpdateNeedleTimeCounter()
    If m_oComBoard.RelayIsClosed(2) Then
      m_oNeedleTimeCounter.CurrentlyOn()
    Else
      m_oNeedleTimeCounter.CurrentlyOff()
    End If
    lblNeedleTime.Text = "Needle Time: " & m_oNeedleTimeCounter.TotalNeedleTimeString
  End Sub

  Private Sub m_oPlayTimer_TurnOffNow() Handles m_oPlayTimer.TurnOffNow
    If chkEnablePlayTimer.Checked Then
      GoToStandbyMode()
    End If
  End Sub

  Private Sub cmdPowerDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPowerDown.Click
    PowerDownAfterCurrentRecord()
  End Sub

  Private Sub cmdPowerUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPowerUp.Click
    PowerUpAndDisableTimer()
  End Sub

  Private Sub cmdPowerDownNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPowerDownNow.Click
    PowerDownImmediately()
  End Sub

  Private Sub cmdStatusCgiSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStatusCgiSend.Click
    txtStatusCgiResponse.Text = (SendStatusCgi(cboStatusCgiStates.SelectedItem))
  End Sub

  Private Function URLToString(ByVal tURL As String) As String
    Dim tResponse As String = ""
    Try
      Dim oRequest As HttpWebRequest
      Dim oResponse As HttpWebResponse
      Dim targetURI As New System.Uri(tURL)

      oRequest = DirectCast(HttpWebRequest.Create(targetURI), System.Net.HttpWebRequest)
      oResponse = oRequest.GetResponse

      If (oResponse.ContentLength > 0) Then
        Dim oStrReader As New System.IO.StreamReader(oResponse.GetResponseStream())
        tResponse = oStrReader.ReadToEnd()
        oStrReader.Close()
      End If
    Catch ex As System.Net.WebException
      'Error in accessing the resource, handle it
      tResponse = ex.Message
    End Try
    Return tResponse
  End Function

  Private Function SendStatusCgi(ByVal tState As String) As String
    Dim tCgiURL = txtStatusCgiUrl.Text
    Return URLToString(tCgiURL & tState)
  End Function

  Private Sub SetState(ByVal tState)
    lblCurrentState.Text = "Setting state ..."

    grboxState.Refresh()
    Threading.Thread.Sleep(1)

    m_tCurrentState = tState
    SendStatusCgi(tState)
    Select Case tState
      Case "off"

      Case "standby"

      Case "public_play"
      Case "home_play"
      Case "maintenance"
      Case Else

    End Select
    Threading.Thread.Sleep(10)   ' Wait .01 seconds

    GetStateFromRemote()
  End Sub

  Private Function GetStateFromRemote() As String
    lblCurrentState.Text = "Updating ..."
    grboxState.Refresh()
    Threading.Thread.Sleep(1)

    Dim tState As String
    tState = URLToString("http://www.seeburgremote.net/get_jukebox_status.rb?format=code")
    m_tCurrentState = tState
    lblCurrentState.Text = "Current state on server: " & tState
    cboStatusCgiStates.SelectedItem = tState
    Return tState
  End Function


  Private Sub cmdStateOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStateOff.Click
    PowerDownAfterCurrentRecord()
    SetState("off")
  End Sub

  Private Sub cmdStateOffNow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStateOffNow.Click
    PowerDownImmediately()
    SetState("off")
  End Sub

  Private Sub cmdStateStandby_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStateStandby.Click
    GoToStandbyMode()
  End Sub

  Private Sub cmdStatePublic30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStatePublic30.Click
    AddTime(30)
  End Sub

  Private Sub cmdStateHomePlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStateHomePlay.Click
    SetState("home_play")
    PowerUpAndDisableTimer()
  End Sub

  Private Sub cmdStatePublicUnlimited_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStatePublicUnlimited.Click
    SetState("public_play")
    PowerUpAndDisableTimer()
  End Sub

  Private Sub lblCurrentState_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCurrentState.Click
    GetStateFromRemote()
  End Sub

  Private Sub UpdateAudioTraffic()
    Dim iAudioPort As Integer = CInt(txtAudioPort.Text)
    Dim ttCurrentConnections As List(Of String) = CurrentAudioConnections(iAudioPort)

    txtAudioConnections.Text = String.Join(vbCrLf, ttCurrentConnections)
    lblAudioConnectionsCount.Text = ttCurrentConnections.Count & " conn(s) on port " & iAudioPort
    If ttCurrentConnections.Count > 0 Then
      m_dLastAudioConnectionSeenAt = Now()
    End If
  End Sub

  Private Function CurrentAudioConnections(ByVal iAudioPort) As List(Of String)
    CurrentAudioConnections = New List(Of String)

    Dim properties As IPGlobalProperties = IPGlobalProperties.GetIPGlobalProperties()
    Dim connections As TcpConnectionInformation() = properties.GetActiveTcpConnections()

    Dim c As TcpConnectionInformation
    For Each c In connections
      If c.LocalEndPoint.Port = iAudioPort And c.State = TcpState.Established Then
        CurrentAudioConnections.Add(c.RemoteEndPoint.Address.ToString)
      End If
    Next c
  End Function

  Private Sub cmdRefreshAudioTraffic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    UpdateAudioTraffic()
  End Sub

  Private Function SecondsSinceLastAudioConnection()
    Return DateDiff(DateInterval.Second, m_dLastAudioConnectionSeenAt, Now)
  End Function

  Private Sub timerScanIO_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles timerScanIO.Tick
    If chkKeepIOsUpdated.Checked Then UpdateIOs()
  End Sub

  Private Sub UpdateIOs()
    With m_oComBoard
      radIO_4.Checked = .IOState(4)
      radIO_5.Checked = .IOState(5)
      '      chkIO_6.Checked = .IOState(6) ' If you read port 6, you freeze the counter.
      chkIO_7.Checked = .IOState(7)
      txtCounter.Text = .CounterValue

      If .IOState(5) Then
        If Not m_bLastStateIO5 Then
          m_bLastStateIO5 = True
          cmdAddMinutes.PerformClick()
        End If
      Else
        m_bLastStateIO5 = False
      End If

    End With

  End Sub

  Private Sub lnkResetCounter_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkResetCounter.LinkClicked
    m_oComBoard.ResetCounter()
  End Sub

  Private Sub txtCounter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCounter.Click
    txtCounter.Text = m_oComBoard.CounterValue
  End Sub


  Private Sub chkIO_6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIO_6.Click
    m_oComBoard.SetIOState(6, chkIO_6.Checked)
  End Sub

  Private Sub chkIO_7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIO_7.Click
    m_oComBoard.SetIOState(7, chkIO_7.Checked)
  End Sub

  Private Sub EngageRunoutSaver()
    ' Prevents a record that won't auto-reject (locked groove, too wide a runout, etc.) from playing
    ' forever. Forces a powerdown 10 minutes after the timer runs out.
    If chkUseRunoutSaver.Checked Then
      timerRunoutSaver.Interval = 600000
      timerRunoutSaver.Start()
    End If
  End Sub

  Private Sub timerRunoutSaver_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles timerRunoutSaver.Tick
    If Not m_oPlayTimer.IsPlaying Then
      PowerDownImmediately()
    End If
    timerRunoutSaver.Stop()
    timerRunoutSaver.Enabled = False
  End Sub
End Class