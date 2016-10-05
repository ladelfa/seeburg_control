Imports System.Text.RegularExpressions
Imports System.IO.Ports

Public Class clsComBoard
  Private m_oRS232 As IO.Ports.SerialPort
  Public PortName As String
  Public Event DebugStatement(ByVal t As String)

  Public Sub New()
    Dim mBaudRate As Integer = 115200
    Dim mParity As Parity = Parity.None
    Dim mDataBit As Integer = 8
    Dim mStopbit As StopBits = StopBits.One
    PortName = SerialPort.GetPortNames().First

    m_oRS232 = New SerialPort(PortName, mBaudRate, mParity, mDataBit, mStopbit)
  End Sub

  Protected Overrides Sub Finalize()
    ClosePort()
    MyBase.Finalize()
  End Sub

  Public Function GetResponse(ByVal tQuery As String) As String
    putCommand(tQuery)
    Dim tResponse As String = ""
    Dim dTimeout As Date = DateAdd(DateInterval.Second, 1, Now)
    Do While tResponse = "" And Now < dTimeout
      tResponse = getMessage()
    Loop
    LogDebug("=> " & tResponse)
    Return tResponse
  End Function

  Private Sub putCommand(ByVal tQuery As String)
    OpenPort()

    LogDebug(">> " & tQuery)
    getMessage() ' To clear buffer
    Try
      m_oRS232.Write("~" & tQuery.ToLower & "~")
    Catch ex As Exception
      LogException(ex.Message)
    End Try
  End Sub

  Private Function getMessage() As String
    OpenPort()

    Dim InByte() As Byte, ReadCount As Integer, k As Integer
    Dim tMessage As String = ""

    If m_oRS232.BytesToRead > 0 Then
      ReDim InByte(m_oRS232.BytesToRead - 1)
      ReadCount = m_oRS232.Read(InByte, 0, m_oRS232.BytesToRead)

      For k = 0 To ReadCount - 1
        tMessage += Chr(InByte(k))
      Next
    End If

    Dim oRegex = New Regex("~(.*)~")
    Dim tTrimmedMessage As String = ""
    If oRegex.IsMatch(tMessage) Then
      tTrimmedMessage = oRegex.Split(tMessage.Trim)(1)
    End If
    Return tTrimmedMessage
  End Function

  Public Function OpenPort()
    If Not m_oRS232.IsOpen Then      ' is not open SerialPort?
      Try
        m_oRS232.Open()              '
      Catch ex As Exception
        LogException(ex.Message)
      End Try
    End If
    Return (m_oRS232.IsOpen)
  End Function

  Public Function ClosePort()
    If m_oRS232.IsOpen Then           'is not open SerialPort?
      m_oRS232.Close()              '  Close SerialPort
    End If
    Return Not (m_oRS232.IsOpen)
  End Function

  Public Sub RelayTest()
    Dim i As Integer

    With m_oRS232
      .Write("~out8=0~")
      .Write("~out9=0~")

      For i = 0 To 5
        .Write("~out8=1~")
        Threading.Thread.Sleep(300)  'delay time
        .Write("~out8=0~")
        Threading.Thread.Sleep(300)  'delay time
        .Write("~out9=1~")
        Threading.Thread.Sleep(300)  'delay time
        .Write("~out9=0~")
        Threading.Thread.Sleep(300)  'delay time
      Next

      .Write("~out8=0~")
      .Write("~out9=0~")
    End With
  End Sub

  Private Function IOPortFromRelayNumber(ByVal iRelayNumber As Integer) As Integer
    Select Case iRelayNumber
      Case 1
        Return 9
      Case 2
        Return 8
      Case Else
        Return vbNull
    End Select
  End Function

  ' Returns True if the relay is closed
  Public Function RelayIsClosed(ByVal iRelayNumber As Integer) As Boolean
    Dim iIOPort As Integer = IOPortFromRelayNumber(iRelayNumber)

    Dim tCommand As String = "osta" & iIOPort
    Dim tResponse As String = GetResponse(tCommand)

    Select Case tResponse
      Case "OUTES" & iIOPort & "=1"
        Return True
      Case "OUTES" & iIOPort & "=0"
        Return False
      Case Else
        LogException("Unexpected response to " & tCommand & ": " & tResponse)
        Return False
    End Select
  End Function

  ' Returns True if the state is correctly set.
  Public Function SetRelay(ByVal iRelayNumber As Integer, ByVal bState As Boolean) As Boolean
    SetIOState(IOPortFromRelayNumber(iRelayNumber), bState)
    Return (RelayIsClosed(iRelayNumber) = bState)
  End Function

  Public Sub SetIOState(ByVal iIOPort As Integer, ByVal bState As Boolean)
    Dim tCommand As String = "out" & iIOPort & "=" & IIf(bState, 1, 0)
    Dim tResponse As String = GetResponse(tCommand)
  End Sub

  Public Function IOState(ByVal iIOPort As Integer) As Boolean
    Dim tCommand As String = "in" & iIOPort
    Dim tResponse As String = GetResponse(tCommand)

    Select Case tResponse
      Case "in" & iIOPort & "=1"
        Return True
      Case "in" & iIOPort & "=0"
        Return False
      Case Else
        LogException("Unexpected response to " & tCommand & ": " & tResponse)
        Return False
    End Select
  End Function

  Public Function CounterValue() As Integer
    Dim tCommand As String = "crd0"
    Dim tResponse As String = GetResponse(tCommand)
    If Left(tResponse, 3) = "C0=" Then
      Return CInt(Mid(tResponse, 4))
    Else
      LogException("Unexpected response to " & tCommand & ": " & tResponse)
      Return -1
    End If
  End Function

  Public Sub ResetCounter()
    GetResponse("out6=0")
    putCommand("ct0h") ' This command generates no response.
  End Sub

  Private Sub LogException(ByVal msg As String)
    MsgBox(msg)
    ' also, write to error log file.
  End Sub

  Private Sub LogDebug(ByVal msg As String)
    RaiseEvent DebugStatement(msg)
    ' also, write to debug log file
  End Sub

End Class
