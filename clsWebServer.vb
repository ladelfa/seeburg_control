Imports System.Net
Imports System.Threading
Imports System.ComponentModel

Public Class clsWebServer
  Private WithEvents m_oBgrdWrkrWebServer As BackgroundWorker
  Private m_oHTTPListener As System.Net.HttpListener

  Public Event HandleRequest(ByVal tRequest As String, ByRef tResponse As String)
  Public Event DebugStatement(ByVal t As String)
  Private m_tLastResponse As String

  Public Sub New()
    m_oBgrdWrkrWebServer = New BackgroundWorker
    m_oHTTPListener = New System.Net.HttpListener
    m_tLastResponse = ""
  End Sub

  Public Sub StartListening(Optional ByVal iPort As Integer = 80)
    RaiseEvent DebugStatement("Web Server Starting")

    m_oHTTPListener.Prefixes.Clear()
    m_oHTTPListener.Prefixes.Add("http://+:" & iPort & "/")
    Try
      m_oHTTPListener.Start()
    Catch ex As Exception
      MsgBox(ex.ToString)
      Exit Sub
    End Try

    RaiseEvent DebugStatement("Web Server Started")
    RaiseEvent DebugStatement("Listening on Port " & iPort)

    With m_oBgrdWrkrWebServer
      .WorkerReportsProgress = True
      .WorkerSupportsCancellation = True
      .RunWorkerAsync(iPort)
    End With
  End Sub

  Public Sub StopListening()
    m_oBgrdWrkrWebServer.CancelAsync()
    m_oHTTPListener.Stop()
    RaiseEvent DebugStatement("Web Server Stopped")
  End Sub

  Private Sub m_oBgrdWrkrWebServer_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles m_oBgrdWrkrWebServer.DoWork
  
    Dim context As System.Net.HttpListenerContext

    Do Until m_oBgrdWrkrWebServer.CancellationPending
      Try
        context = m_oHTTPListener.GetContext ' This blocks until a request comes in.

        ' Pass context to the foreground so it can be handled, responded to, and closed.
        m_oBgrdWrkrWebServer.ReportProgress(0, context)
      Catch ex As Exception
      End Try

      Threading.Thread.Sleep(0)
    Loop
  End Sub

  Private Sub ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles m_oBgrdWrkrWebServer.ProgressChanged
    Dim context As HttpListenerContext = CType(e.UserState, HttpListenerContext)
    
    Dim tRequest As String = context.Request.RawUrl

    Dim tRequestLogMessage As String = ">> Received """ & tRequest & """ from " & context.Request.RemoteEndPoint.Address.ToString
    RaiseEvent DebugStatement(tRequestLogMessage)

    Dim bNoBody As Boolean
    bNoBody = context.Request.HttpMethod = "HEAD"

    Dim tResponse As String = ""
    RaiseEvent HandleRequest(tRequest, tResponse)

    Try
      Dim buffer() As Byte = System.Text.Encoding.UTF8.GetBytes(tResponse)

      Dim oResponse As HttpListenerResponse = context.Response
      oResponse.ContentLength64 = buffer.Length

      If bNoBody Then
      Else
        oResponse.OutputStream.Write(buffer, 0, buffer.Length)
        oResponse.OutputStream.Close()
      End If
      oResponse.Close()

    Catch ex As Exception
      tResponse = ex.Message
    End Try

    RaiseEvent DebugStatement("=>  " & tResponse)

  End Sub


End Class
