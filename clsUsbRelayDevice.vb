Imports System.Runtime.InteropServices

Public Class clsUsbRelayDevice
  Public Shared Function Init() As Boolean
    Return modUsbRelayDeviceLib.Init = 0
  End Function

  Public Shared Function Destroy() As Boolean
    Return modUsbRelayDeviceLib.Destroy = 0
  End Function

  Public Shared Function LibVersion() As Integer
    Return modUsbRelayDeviceLib.LibVersion()
  End Function

  Public Shared Function GetSerialNumbers() As List(Of String)
    Dim serials As New List(Of String)

    Dim device_list As IntPtr = modUsbRelayDeviceLib.Enumerate()
    Dim next_device As IntPtr = device_list
    Do
      Dim loop_device As UsbRelayDeviceInfo
      loop_device = Marshal.PtrToStructure(next_device, GetType(UsbRelayDeviceInfo))
      serials.Add(loop_device.serial_number)
      next_device = loop_device._next
    Loop While (next_device <> 0)
    modUsbRelayDeviceLib.FreeEnumerate(device_list)
    Return serials
  End Function

  Public Handle As IntPtr
  Public SerialNumber As String
  Public RelayCount As Integer

  Public Sub New(serial As String)
    Handle = modUsbRelayDeviceLib.OpenWithSerialNumber(serial, serial.Length)
    If Handle <> 0 Then
      SerialNumber = modUsbRelayDeviceLib.GetIdString(Handle)
      RelayCount = modUsbRelayDeviceLib.GetNumRelays(Handle)
    End If
  End Sub

  Public Function RelayStates() As BitArray
    Dim statusInt As Integer = modUsbRelayDeviceLib.GetStatusBitmap(Handle)
    Dim bits As New BitArray(System.BitConverter.GetBytes(statusInt))
    Return bits
  End Function

  Public Function Status(Optional OnState As Char = "Y"c, Optional OffState As Char = "N"c) As String
    Dim states As BitArray = RelayStates()

    Dim chars(RelayCount - 1) As Char
    For i = 0 To RelayCount - 1
      chars(i) = IIf(states(i), OnState, OffState)
    Next
    Return New String(chars)
  End Function

  Public Function RelayIsOn(Index As Integer) As Boolean
    Return RelayStates()(Index - 1)
  End Function

  Public Function RelayIsOff(Index As Integer) As Boolean
    Return Not RelayIsOn(Index)
  End Function

  Public Function TurnOnRelay(index As Integer) As Boolean
    Return (modUsbRelayDeviceLib.OpenOneRelayChannel(Handle, index) = 0)
  End Function

  Public Function TurnOffRelay(index As Integer) As Boolean
    Return (modUsbRelayDeviceLib.CloseOneRelayChannel(Handle, index) = 0)
  End Function

  Public Function SetRelay(index As Integer, turned_on As Boolean) As Boolean
    If turned_on Then
      Return TurnOnRelay(index)
    Else
      Return TurnOffRelay(index)
    End If
  End Function

  Public Function SetAllRelays(turned_on As Boolean) As Boolean
    Return IIf(turned_on, TurnOnAllRelays, TurnOffAllRelays)
  End Function


  Public Function TurnOnAllRelays() As Boolean
    Return (modUsbRelayDeviceLib.OpenAllRelayChannel(Handle) = 0)
  End Function

  Public Function TurnOffAllRelays() As Boolean
    Return (modUsbRelayDeviceLib.CloseAllRelayChannel(Handle) = 0)
  End Function

  Protected Overrides Sub Finalize()
    modUsbRelayDeviceLib.Close(Handle)
    MyBase.Finalize()
  End Sub
End Class
