<Serializable()> Public Class clsSettings
  Public Port_HTTP As Integer = 8081
  Public ShowLogs_HTTP As Boolean = True
  Public ShowLogs_Com As Boolean = True
  Public EnablePlayTimer As Boolean = False
  Public StartHTTPAtStartup As Boolean = False
  Public StatusCgiUrl As String = "http://www.seeburgremote.net/set_jukebox_status.rb?jukebox=seeburg&status="
  Public Port_Audio As Integer = 8080
    Public SetStatusToStandbyAtStartup As Boolean = False ' was True
    Public PowerDownWhenNoConnections = False ' was True
    Public PowerDownWhenNoConnectionsAfterNnMinutes = 1
  Public DefaultMinutesToAddViaButton = 20
End Class
