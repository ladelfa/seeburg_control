<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
    Me.cmdQuit = New System.Windows.Forms.Button()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.cboDevices = New System.Windows.Forms.ComboBox()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.cmdRelayMomentary_1 = New System.Windows.Forms.Button()
    Me.chkRelayStatus1 = New System.Windows.Forms.CheckBox()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.cmdRelayMomentary_2 = New System.Windows.Forms.Button()
    Me.chkRelayStatus2 = New System.Windows.Forms.CheckBox()
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.chkAutoStartHTTP = New System.Windows.Forms.CheckBox()
    Me.lnkClearHTTPLog = New System.Windows.Forms.LinkLabel()
    Me.chkShowHTTPLog = New System.Windows.Forms.CheckBox()
    Me.txtHTTPLog = New System.Windows.Forms.TextBox()
    Me.cmdTestHTTP = New System.Windows.Forms.Button()
    Me.txtHTTPPort = New System.Windows.Forms.TextBox()
    Me.txtTestHTTP = New System.Windows.Forms.TextBox()
    Me.cmdStartHTTP = New System.Windows.Forms.Button()
    Me.cmdStopHTTP = New System.Windows.Forms.Button()
    Me.GroupBox5 = New System.Windows.Forms.GroupBox()
    Me.cmdPowerDownNow = New System.Windows.Forms.Button()
    Me.cmdPowerDown = New System.Windows.Forms.Button()
    Me.cmdPowerUp = New System.Windows.Forms.Button()
    Me.chkEnablePlayTimer = New System.Windows.Forms.CheckBox()
    Me.txtMinutesToAdd = New System.Windows.Forms.TextBox()
    Me.lblMinutesLeft = New System.Windows.Forms.Label()
    Me.cmdAddMinutes = New System.Windows.Forms.Button()
    Me.timerRefreshPowerControl = New System.Windows.Forms.Timer(Me.components)
    Me.GroupBox6 = New System.Windows.Forms.GroupBox()
    Me.txtStatusCgiResponse = New System.Windows.Forms.TextBox()
    Me.cmdStatusCgiSend = New System.Windows.Forms.Button()
    Me.cboStatusCgiStates = New System.Windows.Forms.ComboBox()
    Me.txtStatusCgiUrl = New System.Windows.Forms.TextBox()
    Me.grboxState = New System.Windows.Forms.GroupBox()
    Me.chkSetStandbyAtLaunch = New System.Windows.Forms.CheckBox()
    Me.cmdStateOffNow = New System.Windows.Forms.Button()
    Me.cmdStatePublicUnlimited = New System.Windows.Forms.Button()
    Me.lblCurrentState = New System.Windows.Forms.Label()
    Me.cmdStateHomePlay = New System.Windows.Forms.Button()
    Me.cmdStateStandby = New System.Windows.Forms.Button()
    Me.cmdStateOff = New System.Windows.Forms.Button()
    Me.cmdStatePublic30 = New System.Windows.Forms.Button()
    Me.lblNeedleTime = New System.Windows.Forms.Label()
    Me.GroupBox7 = New System.Windows.Forms.GroupBox()
    Me.lblConnectionLastSeenAt = New System.Windows.Forms.Label()
    Me.chkPowerDownWhenNoConnections = New System.Windows.Forms.CheckBox()
    Me.lblAudioConnectionsCount = New System.Windows.Forms.Label()
    Me.txtAudioConnections = New System.Windows.Forms.TextBox()
    Me.txtAudioPort = New System.Windows.Forms.TextBox()
    Me.chkUpdateNeedleTime = New System.Windows.Forms.CheckBox()
    Me.GroupBox8 = New System.Windows.Forms.GroupBox()
    Me.chkUseRunoutSaver = New System.Windows.Forms.CheckBox()
    Me.CheckBox1 = New System.Windows.Forms.CheckBox()
    Me.timerRunoutSaver = New System.Windows.Forms.Timer(Me.components)
    Me.GroupBox3.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox4.SuspendLayout()
    Me.GroupBox5.SuspendLayout()
    Me.GroupBox6.SuspendLayout()
    Me.grboxState.SuspendLayout()
    Me.GroupBox7.SuspendLayout()
    Me.GroupBox8.SuspendLayout()
    Me.SuspendLayout()
    '
    'cmdQuit
    '
    Me.cmdQuit.Location = New System.Drawing.Point(758, 495)
    Me.cmdQuit.Name = "cmdQuit"
    Me.cmdQuit.Size = New System.Drawing.Size(77, 24)
    Me.cmdQuit.TabIndex = 11
    Me.cmdQuit.Text = "&Quit"
    Me.cmdQuit.UseVisualStyleBackColor = True
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.cboDevices)
    Me.GroupBox3.Controls.Add(Me.GroupBox1)
    Me.GroupBox3.Controls.Add(Me.GroupBox2)
    Me.GroupBox3.Location = New System.Drawing.Point(426, 12)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(223, 195)
    Me.GroupBox3.TabIndex = 16
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "USB Relay Device"
    '
    'cboDevices
    '
    Me.cboDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.cboDevices.FormattingEnabled = True
    Me.cboDevices.Location = New System.Drawing.Point(15, 19)
    Me.cboDevices.Name = "cboDevices"
    Me.cboDevices.Size = New System.Drawing.Size(99, 21)
    Me.cboDevices.TabIndex = 23
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.cmdRelayMomentary_1)
    Me.GroupBox1.Controls.Add(Me.chkRelayStatus1)
    Me.GroupBox1.Location = New System.Drawing.Point(15, 54)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(194, 57)
    Me.GroupBox1.TabIndex = 21
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Relay 1 (Reject/Scan)"
    '
    'cmdRelayMomentary_1
    '
    Me.cmdRelayMomentary_1.Location = New System.Drawing.Point(88, 19)
    Me.cmdRelayMomentary_1.Name = "cmdRelayMomentary_1"
    Me.cmdRelayMomentary_1.Size = New System.Drawing.Size(75, 23)
    Me.cmdRelayMomentary_1.TabIndex = 13
    Me.cmdRelayMomentary_1.Tag = "1"
    Me.cmdRelayMomentary_1.Text = "Momentary"
    Me.cmdRelayMomentary_1.UseVisualStyleBackColor = True
    '
    'chkRelayStatus1
    '
    Me.chkRelayStatus1.AutoSize = True
    Me.chkRelayStatus1.Location = New System.Drawing.Point(26, 23)
    Me.chkRelayStatus1.Name = "chkRelayStatus1"
    Me.chkRelayStatus1.Size = New System.Drawing.Size(56, 17)
    Me.chkRelayStatus1.TabIndex = 0
    Me.chkRelayStatus1.Text = "Status"
    Me.chkRelayStatus1.UseVisualStyleBackColor = True
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.cmdRelayMomentary_2)
    Me.GroupBox2.Controls.Add(Me.chkRelayStatus2)
    Me.GroupBox2.Location = New System.Drawing.Point(15, 117)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(194, 57)
    Me.GroupBox2.TabIndex = 22
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Relay 2 (Power)"
    '
    'cmdRelayMomentary_2
    '
    Me.cmdRelayMomentary_2.Location = New System.Drawing.Point(89, 19)
    Me.cmdRelayMomentary_2.Name = "cmdRelayMomentary_2"
    Me.cmdRelayMomentary_2.Size = New System.Drawing.Size(75, 23)
    Me.cmdRelayMomentary_2.TabIndex = 13
    Me.cmdRelayMomentary_2.Tag = "2"
    Me.cmdRelayMomentary_2.Text = "Momentary"
    Me.cmdRelayMomentary_2.UseVisualStyleBackColor = True
    '
    'chkRelayStatus2
    '
    Me.chkRelayStatus2.AutoSize = True
    Me.chkRelayStatus2.Location = New System.Drawing.Point(26, 23)
    Me.chkRelayStatus2.Name = "chkRelayStatus2"
    Me.chkRelayStatus2.Size = New System.Drawing.Size(56, 17)
    Me.chkRelayStatus2.TabIndex = 0
    Me.chkRelayStatus2.Text = "Status"
    Me.chkRelayStatus2.UseVisualStyleBackColor = True
    '
    'GroupBox4
    '
    Me.GroupBox4.Controls.Add(Me.chkAutoStartHTTP)
    Me.GroupBox4.Controls.Add(Me.lnkClearHTTPLog)
    Me.GroupBox4.Controls.Add(Me.chkShowHTTPLog)
    Me.GroupBox4.Controls.Add(Me.txtHTTPLog)
    Me.GroupBox4.Controls.Add(Me.cmdTestHTTP)
    Me.GroupBox4.Controls.Add(Me.txtHTTPPort)
    Me.GroupBox4.Controls.Add(Me.txtTestHTTP)
    Me.GroupBox4.Controls.Add(Me.cmdStartHTTP)
    Me.GroupBox4.Controls.Add(Me.cmdStopHTTP)
    Me.GroupBox4.Location = New System.Drawing.Point(15, 12)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(391, 263)
    Me.GroupBox4.TabIndex = 17
    Me.GroupBox4.TabStop = False
    Me.GroupBox4.Text = "Web Server"
    '
    'chkAutoStartHTTP
    '
    Me.chkAutoStartHTTP.AutoSize = True
    Me.chkAutoStartHTTP.Checked = True
    Me.chkAutoStartHTTP.CheckState = System.Windows.Forms.CheckState.Checked
    Me.chkAutoStartHTTP.Location = New System.Drawing.Point(289, 155)
    Me.chkAutoStartHTTP.Name = "chkAutoStartHTTP"
    Me.chkAutoStartHTTP.Size = New System.Drawing.Size(73, 17)
    Me.chkAutoStartHTTP.TabIndex = 28
    Me.chkAutoStartHTTP.Text = "Auto Start"
    Me.chkAutoStartHTTP.UseVisualStyleBackColor = True
    '
    'lnkClearHTTPLog
    '
    Me.lnkClearHTTPLog.AutoSize = True
    Me.lnkClearHTTPLog.Location = New System.Drawing.Point(241, 202)
    Me.lnkClearHTTPLog.Name = "lnkClearHTTPLog"
    Me.lnkClearHTTPLog.Size = New System.Drawing.Size(31, 13)
    Me.lnkClearHTTPLog.TabIndex = 27
    Me.lnkClearHTTPLog.TabStop = True
    Me.lnkClearHTTPLog.Text = "Clear"
    '
    'chkShowHTTPLog
    '
    Me.chkShowHTTPLog.AutoSize = True
    Me.chkShowHTTPLog.Checked = True
    Me.chkShowHTTPLog.CheckState = System.Windows.Forms.CheckState.Checked
    Me.chkShowHTTPLog.Location = New System.Drawing.Point(25, 201)
    Me.chkShowHTTPLog.Name = "chkShowHTTPLog"
    Me.chkShowHTTPLog.Size = New System.Drawing.Size(74, 17)
    Me.chkShowHTTPLog.TabIndex = 26
    Me.chkShowHTTPLog.Text = "Show Log"
    Me.chkShowHTTPLog.UseVisualStyleBackColor = True
    '
    'txtHTTPLog
    '
    Me.txtHTTPLog.Location = New System.Drawing.Point(25, 30)
    Me.txtHTTPLog.Multiline = True
    Me.txtHTTPLog.Name = "txtHTTPLog"
    Me.txtHTTPLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.txtHTTPLog.Size = New System.Drawing.Size(247, 165)
    Me.txtHTTPLog.TabIndex = 19
    '
    'cmdTestHTTP
    '
    Me.cmdTestHTTP.Location = New System.Drawing.Point(228, 224)
    Me.cmdTestHTTP.Name = "cmdTestHTTP"
    Me.cmdTestHTTP.Size = New System.Drawing.Size(42, 21)
    Me.cmdTestHTTP.TabIndex = 24
    Me.cmdTestHTTP.Text = "Go"
    Me.cmdTestHTTP.UseVisualStyleBackColor = True
    '
    'txtHTTPPort
    '
    Me.txtHTTPPort.Location = New System.Drawing.Point(289, 30)
    Me.txtHTTPPort.Name = "txtHTTPPort"
    Me.txtHTTPPort.Size = New System.Drawing.Size(78, 20)
    Me.txtHTTPPort.TabIndex = 23
    Me.txtHTTPPort.Text = "81"
    '
    'txtTestHTTP
    '
    Me.txtTestHTTP.Location = New System.Drawing.Point(25, 224)
    Me.txtTestHTTP.Name = "txtTestHTTP"
    Me.txtTestHTTP.Size = New System.Drawing.Size(197, 20)
    Me.txtTestHTTP.TabIndex = 23
    Me.txtTestHTTP.Text = "/test"
    '
    'cmdStartHTTP
    '
    Me.cmdStartHTTP.Location = New System.Drawing.Point(289, 70)
    Me.cmdStartHTTP.Name = "cmdStartHTTP"
    Me.cmdStartHTTP.Size = New System.Drawing.Size(80, 24)
    Me.cmdStartHTTP.TabIndex = 17
    Me.cmdStartHTTP.Text = "Start"
    Me.cmdStartHTTP.UseVisualStyleBackColor = True
    '
    'cmdStopHTTP
    '
    Me.cmdStopHTTP.Enabled = False
    Me.cmdStopHTTP.Location = New System.Drawing.Point(288, 111)
    Me.cmdStopHTTP.Name = "cmdStopHTTP"
    Me.cmdStopHTTP.Size = New System.Drawing.Size(81, 23)
    Me.cmdStopHTTP.TabIndex = 18
    Me.cmdStopHTTP.Text = "Stop"
    Me.cmdStopHTTP.UseVisualStyleBackColor = True
    '
    'GroupBox5
    '
    Me.GroupBox5.Controls.Add(Me.cmdPowerDownNow)
    Me.GroupBox5.Controls.Add(Me.cmdPowerDown)
    Me.GroupBox5.Controls.Add(Me.cmdPowerUp)
    Me.GroupBox5.Controls.Add(Me.chkEnablePlayTimer)
    Me.GroupBox5.Controls.Add(Me.txtMinutesToAdd)
    Me.GroupBox5.Controls.Add(Me.lblMinutesLeft)
    Me.GroupBox5.Controls.Add(Me.cmdAddMinutes)
    Me.GroupBox5.Location = New System.Drawing.Point(15, 286)
    Me.GroupBox5.Name = "GroupBox5"
    Me.GroupBox5.Size = New System.Drawing.Size(391, 100)
    Me.GroupBox5.TabIndex = 18
    Me.GroupBox5.TabStop = False
    Me.GroupBox5.Text = "Power Control"
    '
    'cmdPowerDownNow
    '
    Me.cmdPowerDownNow.Location = New System.Drawing.Point(272, 59)
    Me.cmdPowerDownNow.Name = "cmdPowerDownNow"
    Me.cmdPowerDownNow.Size = New System.Drawing.Size(107, 24)
    Me.cmdPowerDownNow.TabIndex = 22
    Me.cmdPowerDownNow.Text = "Power Down Now"
    Me.cmdPowerDownNow.UseVisualStyleBackColor = True
    '
    'cmdPowerDown
    '
    Me.cmdPowerDown.Location = New System.Drawing.Point(110, 59)
    Me.cmdPowerDown.Name = "cmdPowerDown"
    Me.cmdPowerDown.Size = New System.Drawing.Size(151, 24)
    Me.cmdPowerDown.TabIndex = 21
    Me.cmdPowerDown.Text = "Power Down After Current"
    Me.cmdPowerDown.UseVisualStyleBackColor = True
    '
    'cmdPowerUp
    '
    Me.cmdPowerUp.Location = New System.Drawing.Point(19, 59)
    Me.cmdPowerUp.Name = "cmdPowerUp"
    Me.cmdPowerUp.Size = New System.Drawing.Size(80, 24)
    Me.cmdPowerUp.TabIndex = 20
    Me.cmdPowerUp.Text = "Power Up"
    Me.cmdPowerUp.UseVisualStyleBackColor = True
    '
    'chkEnablePlayTimer
    '
    Me.chkEnablePlayTimer.AutoSize = True
    Me.chkEnablePlayTimer.Location = New System.Drawing.Point(25, 25)
    Me.chkEnablePlayTimer.Name = "chkEnablePlayTimer"
    Me.chkEnablePlayTimer.Size = New System.Drawing.Size(124, 17)
    Me.chkEnablePlayTimer.TabIndex = 19
    Me.chkEnablePlayTimer.Text = "Enable Timer Control"
    Me.chkEnablePlayTimer.UseVisualStyleBackColor = True
    '
    'txtMinutesToAdd
    '
    Me.txtMinutesToAdd.Location = New System.Drawing.Point(155, 23)
    Me.txtMinutesToAdd.Name = "txtMinutesToAdd"
    Me.txtMinutesToAdd.Size = New System.Drawing.Size(37, 20)
    Me.txtMinutesToAdd.TabIndex = 2
    Me.txtMinutesToAdd.Text = "10"
    Me.txtMinutesToAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'lblMinutesLeft
    '
    Me.lblMinutesLeft.AutoSize = True
    Me.lblMinutesLeft.Location = New System.Drawing.Point(285, 26)
    Me.lblMinutesLeft.Name = "lblMinutesLeft"
    Me.lblMinutesLeft.Size = New System.Drawing.Size(57, 13)
    Me.lblMinutesLeft.TabIndex = 1
    Me.lblMinutesLeft.Text = "Loading ..."
    '
    'cmdAddMinutes
    '
    Me.cmdAddMinutes.Location = New System.Drawing.Point(199, 22)
    Me.cmdAddMinutes.Name = "cmdAddMinutes"
    Me.cmdAddMinutes.Size = New System.Drawing.Size(80, 20)
    Me.cmdAddMinutes.TabIndex = 0
    Me.cmdAddMinutes.Text = "Add Minutes"
    Me.cmdAddMinutes.UseVisualStyleBackColor = True
    '
    'timerRefreshPowerControl
    '
    Me.timerRefreshPowerControl.Interval = 1000
    '
    'GroupBox6
    '
    Me.GroupBox6.Controls.Add(Me.txtStatusCgiResponse)
    Me.GroupBox6.Controls.Add(Me.cmdStatusCgiSend)
    Me.GroupBox6.Controls.Add(Me.cboStatusCgiStates)
    Me.GroupBox6.Controls.Add(Me.txtStatusCgiUrl)
    Me.GroupBox6.Location = New System.Drawing.Point(15, 397)
    Me.GroupBox6.Name = "GroupBox6"
    Me.GroupBox6.Size = New System.Drawing.Size(391, 127)
    Me.GroupBox6.TabIndex = 19
    Me.GroupBox6.TabStop = False
    Me.GroupBox6.Text = "Status CGI"
    '
    'txtStatusCgiResponse
    '
    Me.txtStatusCgiResponse.Location = New System.Drawing.Point(19, 53)
    Me.txtStatusCgiResponse.Multiline = True
    Me.txtStatusCgiResponse.Name = "txtStatusCgiResponse"
    Me.txtStatusCgiResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.txtStatusCgiResponse.Size = New System.Drawing.Size(360, 58)
    Me.txtStatusCgiResponse.TabIndex = 20
    '
    'cmdStatusCgiSend
    '
    Me.cmdStatusCgiSend.Location = New System.Drawing.Point(314, 18)
    Me.cmdStatusCgiSend.Name = "cmdStatusCgiSend"
    Me.cmdStatusCgiSend.Size = New System.Drawing.Size(65, 22)
    Me.cmdStatusCgiSend.TabIndex = 2
    Me.cmdStatusCgiSend.Text = "Send"
    Me.cmdStatusCgiSend.UseVisualStyleBackColor = True
    '
    'cboStatusCgiStates
    '
    Me.cboStatusCgiStates.FormattingEnabled = True
    Me.cboStatusCgiStates.Location = New System.Drawing.Point(142, 20)
    Me.cboStatusCgiStates.Name = "cboStatusCgiStates"
    Me.cboStatusCgiStates.Size = New System.Drawing.Size(166, 21)
    Me.cboStatusCgiStates.TabIndex = 1
    '
    'txtStatusCgiUrl
    '
    Me.txtStatusCgiUrl.Location = New System.Drawing.Point(19, 20)
    Me.txtStatusCgiUrl.Name = "txtStatusCgiUrl"
    Me.txtStatusCgiUrl.Size = New System.Drawing.Size(114, 20)
    Me.txtStatusCgiUrl.TabIndex = 0
    '
    'grboxState
    '
    Me.grboxState.Controls.Add(Me.chkSetStandbyAtLaunch)
    Me.grboxState.Controls.Add(Me.cmdStateOffNow)
    Me.grboxState.Controls.Add(Me.cmdStatePublicUnlimited)
    Me.grboxState.Controls.Add(Me.lblCurrentState)
    Me.grboxState.Controls.Add(Me.cmdStateHomePlay)
    Me.grboxState.Controls.Add(Me.cmdStateStandby)
    Me.grboxState.Controls.Add(Me.cmdStateOff)
    Me.grboxState.Controls.Add(Me.cmdStatePublic30)
    Me.grboxState.Location = New System.Drawing.Point(426, 397)
    Me.grboxState.Name = "grboxState"
    Me.grboxState.Size = New System.Drawing.Size(409, 83)
    Me.grboxState.TabIndex = 20
    Me.grboxState.TabStop = False
    Me.grboxState.Text = "State"
    '
    'chkSetStandbyAtLaunch
    '
    Me.chkSetStandbyAtLaunch.AutoSize = True
    Me.chkSetStandbyAtLaunch.Checked = True
    Me.chkSetStandbyAtLaunch.CheckState = System.Windows.Forms.CheckState.Checked
    Me.chkSetStandbyAtLaunch.Location = New System.Drawing.Point(242, 60)
    Me.chkSetStandbyAtLaunch.Name = "chkSetStandbyAtLaunch"
    Me.chkSetStandbyAtLaunch.Size = New System.Drawing.Size(143, 17)
    Me.chkSetStandbyAtLaunch.TabIndex = 26
    Me.chkSetStandbyAtLaunch.Text = "Set to Standby at launch"
    Me.chkSetStandbyAtLaunch.UseVisualStyleBackColor = True
    '
    'cmdStateOffNow
    '
    Me.cmdStateOffNow.Location = New System.Drawing.Point(15, 19)
    Me.cmdStateOffNow.Name = "cmdStateOffNow"
    Me.cmdStateOffNow.Size = New System.Drawing.Size(45, 27)
    Me.cmdStateOffNow.TabIndex = 25
    Me.cmdStateOffNow.Text = "Off !"
    Me.cmdStateOffNow.UseVisualStyleBackColor = True
    '
    'cmdStatePublicUnlimited
    '
    Me.cmdStatePublicUnlimited.Location = New System.Drawing.Point(247, 19)
    Me.cmdStatePublicUnlimited.Name = "cmdStatePublicUnlimited"
    Me.cmdStatePublicUnlimited.Size = New System.Drawing.Size(73, 27)
    Me.cmdStatePublicUnlimited.TabIndex = 24
    Me.cmdStatePublicUnlimited.Text = "Public Unlim"
    Me.cmdStatePublicUnlimited.UseVisualStyleBackColor = True
    '
    'lblCurrentState
    '
    Me.lblCurrentState.AutoSize = True
    Me.lblCurrentState.Location = New System.Drawing.Point(18, 56)
    Me.lblCurrentState.Name = "lblCurrentState"
    Me.lblCurrentState.Size = New System.Drawing.Size(57, 13)
    Me.lblCurrentState.TabIndex = 23
    Me.lblCurrentState.Text = "Loading ..."
    '
    'cmdStateHomePlay
    '
    Me.cmdStateHomePlay.Location = New System.Drawing.Point(326, 19)
    Me.cmdStateHomePlay.Name = "cmdStateHomePlay"
    Me.cmdStateHomePlay.Size = New System.Drawing.Size(47, 27)
    Me.cmdStateHomePlay.TabIndex = 22
    Me.cmdStateHomePlay.Text = "Home"
    Me.cmdStateHomePlay.UseVisualStyleBackColor = True
    '
    'cmdStateStandby
    '
    Me.cmdStateStandby.Location = New System.Drawing.Point(104, 19)
    Me.cmdStateStandby.Name = "cmdStateStandby"
    Me.cmdStateStandby.Size = New System.Drawing.Size(63, 27)
    Me.cmdStateStandby.TabIndex = 21
    Me.cmdStateStandby.Text = "Standby"
    Me.cmdStateStandby.UseVisualStyleBackColor = True
    '
    'cmdStateOff
    '
    Me.cmdStateOff.Location = New System.Drawing.Point(66, 19)
    Me.cmdStateOff.Name = "cmdStateOff"
    Me.cmdStateOff.Size = New System.Drawing.Size(32, 27)
    Me.cmdStateOff.TabIndex = 20
    Me.cmdStateOff.Text = "Off"
    Me.cmdStateOff.UseVisualStyleBackColor = True
    '
    'cmdStatePublic30
    '
    Me.cmdStatePublic30.Location = New System.Drawing.Point(173, 19)
    Me.cmdStatePublic30.Name = "cmdStatePublic30"
    Me.cmdStatePublic30.Size = New System.Drawing.Size(68, 27)
    Me.cmdStatePublic30.TabIndex = 0
    Me.cmdStatePublic30.Text = "Public :30"
    Me.cmdStatePublic30.UseVisualStyleBackColor = True
    '
    'lblNeedleTime
    '
    Me.lblNeedleTime.AutoSize = True
    Me.lblNeedleTime.Location = New System.Drawing.Point(428, 495)
    Me.lblNeedleTime.Name = "lblNeedleTime"
    Me.lblNeedleTime.Size = New System.Drawing.Size(57, 13)
    Me.lblNeedleTime.TabIndex = 21
    Me.lblNeedleTime.Text = "Loading ..."
    '
    'GroupBox7
    '
    Me.GroupBox7.Controls.Add(Me.lblConnectionLastSeenAt)
    Me.GroupBox7.Controls.Add(Me.chkPowerDownWhenNoConnections)
    Me.GroupBox7.Controls.Add(Me.lblAudioConnectionsCount)
    Me.GroupBox7.Controls.Add(Me.txtAudioConnections)
    Me.GroupBox7.Controls.Add(Me.txtAudioPort)
    Me.GroupBox7.Location = New System.Drawing.Point(668, 12)
    Me.GroupBox7.Name = "GroupBox7"
    Me.GroupBox7.Size = New System.Drawing.Size(167, 374)
    Me.GroupBox7.TabIndex = 22
    Me.GroupBox7.TabStop = False
    Me.GroupBox7.Text = "Audio Traffic"
    '
    'lblConnectionLastSeenAt
    '
    Me.lblConnectionLastSeenAt.AutoSize = True
    Me.lblConnectionLastSeenAt.Location = New System.Drawing.Point(16, 324)
    Me.lblConnectionLastSeenAt.Name = "lblConnectionLastSeenAt"
    Me.lblConnectionLastSeenAt.Size = New System.Drawing.Size(57, 13)
    Me.lblConnectionLastSeenAt.TabIndex = 28
    Me.lblConnectionLastSeenAt.Text = "Loading ..."
    '
    'chkPowerDownWhenNoConnections
    '
    Me.chkPowerDownWhenNoConnections.AutoSize = True
    Me.chkPowerDownWhenNoConnections.Checked = True
    Me.chkPowerDownWhenNoConnections.CheckState = System.Windows.Forms.CheckState.Checked
    Me.chkPowerDownWhenNoConnections.Location = New System.Drawing.Point(19, 344)
    Me.chkPowerDownWhenNoConnections.Name = "chkPowerDownWhenNoConnections"
    Me.chkPowerDownWhenNoConnections.Size = New System.Drawing.Size(119, 17)
    Me.chkPowerDownWhenNoConnections.TabIndex = 27
    Me.chkPowerDownWhenNoConnections.Text = "Require connection"
    Me.chkPowerDownWhenNoConnections.UseVisualStyleBackColor = True
    '
    'lblAudioConnectionsCount
    '
    Me.lblAudioConnectionsCount.AutoSize = True
    Me.lblAudioConnectionsCount.Location = New System.Drawing.Point(16, 304)
    Me.lblAudioConnectionsCount.Name = "lblAudioConnectionsCount"
    Me.lblAudioConnectionsCount.Size = New System.Drawing.Size(57, 13)
    Me.lblAudioConnectionsCount.TabIndex = 22
    Me.lblAudioConnectionsCount.Text = "Loading ..."
    '
    'txtAudioConnections
    '
    Me.txtAudioConnections.Location = New System.Drawing.Point(19, 70)
    Me.txtAudioConnections.Multiline = True
    Me.txtAudioConnections.Name = "txtAudioConnections"
    Me.txtAudioConnections.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.txtAudioConnections.Size = New System.Drawing.Size(133, 223)
    Me.txtAudioConnections.TabIndex = 20
    '
    'txtAudioPort
    '
    Me.txtAudioPort.Location = New System.Drawing.Point(19, 30)
    Me.txtAudioPort.Name = "txtAudioPort"
    Me.txtAudioPort.Size = New System.Drawing.Size(64, 20)
    Me.txtAudioPort.TabIndex = 0
    Me.txtAudioPort.Text = "8080"
    '
    'chkUpdateNeedleTime
    '
    Me.chkUpdateNeedleTime.AutoSize = True
    Me.chkUpdateNeedleTime.Checked = True
    Me.chkUpdateNeedleTime.CheckState = System.Windows.Forms.CheckState.Checked
    Me.chkUpdateNeedleTime.Location = New System.Drawing.Point(582, 494)
    Me.chkUpdateNeedleTime.Name = "chkUpdateNeedleTime"
    Me.chkUpdateNeedleTime.Size = New System.Drawing.Size(95, 17)
    Me.chkUpdateNeedleTime.TabIndex = 23
    Me.chkUpdateNeedleTime.Text = "Keep Updated"
    Me.chkUpdateNeedleTime.UseVisualStyleBackColor = True
    '
    'GroupBox8
    '
    Me.GroupBox8.Controls.Add(Me.chkUseRunoutSaver)
    Me.GroupBox8.Controls.Add(Me.CheckBox1)
    Me.GroupBox8.Location = New System.Drawing.Point(431, 222)
    Me.GroupBox8.Name = "GroupBox8"
    Me.GroupBox8.Size = New System.Drawing.Size(223, 83)
    Me.GroupBox8.TabIndex = 24
    Me.GroupBox8.TabStop = False
    Me.GroupBox8.Text = "Other"
    '
    'chkUseRunoutSaver
    '
    Me.chkUseRunoutSaver.AutoSize = True
    Me.chkUseRunoutSaver.Checked = True
    Me.chkUseRunoutSaver.CheckState = System.Windows.Forms.CheckState.Checked
    Me.chkUseRunoutSaver.Location = New System.Drawing.Point(7, 52)
    Me.chkUseRunoutSaver.Name = "chkUseRunoutSaver"
    Me.chkUseRunoutSaver.Size = New System.Drawing.Size(149, 17)
    Me.chkUseRunoutSaver.TabIndex = 27
    Me.chkUseRunoutSaver.Text = "Locked-groove Protection"
    Me.chkUseRunoutSaver.UseVisualStyleBackColor = True
    '
    'CheckBox1
    '
    Me.CheckBox1.AutoSize = True
    Me.CheckBox1.Checked = True
    Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
    Me.CheckBox1.Location = New System.Drawing.Point(7, 24)
    Me.CheckBox1.Name = "CheckBox1"
    Me.CheckBox1.Size = New System.Drawing.Size(156, 17)
    Me.CheckBox1.TabIndex = 26
    Me.CheckBox1.Text = "Aggresively pursue network"
    Me.CheckBox1.UseVisualStyleBackColor = True
    '
    'timerRunoutSaver
    '
    '
    'frmMain
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(858, 535)
    Me.Controls.Add(Me.GroupBox8)
    Me.Controls.Add(Me.chkUpdateNeedleTime)
    Me.Controls.Add(Me.GroupBox7)
    Me.Controls.Add(Me.lblNeedleTime)
    Me.Controls.Add(Me.grboxState)
    Me.Controls.Add(Me.GroupBox6)
    Me.Controls.Add(Me.GroupBox5)
    Me.Controls.Add(Me.GroupBox4)
    Me.Controls.Add(Me.GroupBox3)
    Me.Controls.Add(Me.cmdQuit)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.MaximizeBox = False
    Me.Name = "frmMain"
    Me.Text = "SeeburgControl"
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.GroupBox4.ResumeLayout(False)
    Me.GroupBox4.PerformLayout()
    Me.GroupBox5.ResumeLayout(False)
    Me.GroupBox5.PerformLayout()
    Me.GroupBox6.ResumeLayout(False)
    Me.GroupBox6.PerformLayout()
    Me.grboxState.ResumeLayout(False)
    Me.grboxState.PerformLayout()
    Me.GroupBox7.ResumeLayout(False)
    Me.GroupBox7.PerformLayout()
    Me.GroupBox8.ResumeLayout(False)
    Me.GroupBox8.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents cmdQuit As System.Windows.Forms.Button
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents cmdRelayMomentary_1 As System.Windows.Forms.Button
  Friend WithEvents chkRelayStatus1 As System.Windows.Forms.CheckBox
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents cmdRelayMomentary_2 As System.Windows.Forms.Button
  Friend WithEvents chkRelayStatus2 As System.Windows.Forms.CheckBox
  Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
  Friend WithEvents txtHTTPLog As System.Windows.Forms.TextBox
  Friend WithEvents cmdTestHTTP As System.Windows.Forms.Button
  Friend WithEvents txtHTTPPort As System.Windows.Forms.TextBox
  Friend WithEvents txtTestHTTP As System.Windows.Forms.TextBox
  Friend WithEvents cmdStartHTTP As System.Windows.Forms.Button
  Friend WithEvents cmdStopHTTP As System.Windows.Forms.Button
  Friend WithEvents chkShowHTTPLog As System.Windows.Forms.CheckBox
  Friend WithEvents lnkClearHTTPLog As System.Windows.Forms.LinkLabel
  Friend WithEvents chkAutoStartHTTP As System.Windows.Forms.CheckBox
  Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
  Friend WithEvents txtMinutesToAdd As System.Windows.Forms.TextBox
  Friend WithEvents lblMinutesLeft As System.Windows.Forms.Label
  Friend WithEvents cmdAddMinutes As System.Windows.Forms.Button
  Friend WithEvents timerRefreshPowerControl As System.Windows.Forms.Timer
  Friend WithEvents chkEnablePlayTimer As System.Windows.Forms.CheckBox
  Friend WithEvents cmdPowerDown As System.Windows.Forms.Button
  Friend WithEvents cmdPowerUp As System.Windows.Forms.Button
  Friend WithEvents cmdPowerDownNow As System.Windows.Forms.Button
  Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
  Friend WithEvents cmdStatusCgiSend As System.Windows.Forms.Button
  Friend WithEvents cboStatusCgiStates As System.Windows.Forms.ComboBox
  Friend WithEvents txtStatusCgiUrl As System.Windows.Forms.TextBox
  Friend WithEvents txtStatusCgiResponse As System.Windows.Forms.TextBox
  Friend WithEvents grboxState As System.Windows.Forms.GroupBox
  Friend WithEvents lblCurrentState As System.Windows.Forms.Label
  Friend WithEvents cmdStateHomePlay As System.Windows.Forms.Button
  Friend WithEvents cmdStateStandby As System.Windows.Forms.Button
  Friend WithEvents cmdStateOff As System.Windows.Forms.Button
  Friend WithEvents cmdStatePublic30 As System.Windows.Forms.Button
  Friend WithEvents cmdStatePublicUnlimited As System.Windows.Forms.Button
  Friend WithEvents cmdStateOffNow As System.Windows.Forms.Button
  Friend WithEvents lblNeedleTime As System.Windows.Forms.Label
  Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
  Friend WithEvents txtAudioConnections As System.Windows.Forms.TextBox
  Friend WithEvents txtAudioPort As System.Windows.Forms.TextBox
  Friend WithEvents lblAudioConnectionsCount As System.Windows.Forms.Label
  Friend WithEvents chkUpdateNeedleTime As System.Windows.Forms.CheckBox
  Friend WithEvents chkSetStandbyAtLaunch As System.Windows.Forms.CheckBox
  Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
  Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
  Friend WithEvents chkPowerDownWhenNoConnections As System.Windows.Forms.CheckBox
  Friend WithEvents lblConnectionLastSeenAt As System.Windows.Forms.Label
  Friend WithEvents timerRunoutSaver As System.Windows.Forms.Timer
  Friend WithEvents chkUseRunoutSaver As System.Windows.Forms.CheckBox
  Friend WithEvents cboDevices As ComboBox
End Class
