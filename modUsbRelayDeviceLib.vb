Imports System.Runtime.InteropServices

Module modUsbRelayDeviceLib

  <DllImport("usb_relay_device.dll", EntryPoint:="usb_relay_device_lib_version")>
  Public Function LibVersion() As Integer
  End Function

  <DllImport("usb_relay_device.dll", EntryPoint:="usb_relay_init")>
  Public Function Init() As Integer
  End Function

  <DllImport("usb_relay_device.dll", EntryPoint:="usb_relay_exit")>
  Public Function Destroy() As Integer
  End Function

  Public Enum UsbRelayDeviceType As Integer
    USB_RELAY_DEVICE_ONE_CHANNEL = 1
    USB_RELAY_DEVICE_TWO_CHANNEL = 2
    USB_RELAY_DEVICE_FOUR_CHANNEL = 4
    USB_RELAY_DEVICE_EIGHT_CHANNEL = 8
  End Enum

  <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)>
  Public Structure UsbRelayDeviceInfo
    Public serial_number As String
    Public device_path As String
    Public _type As UsbRelayDeviceType
    Public _next As IntPtr
  End Structure

  <DllImport("usb_relay_device.dll", EntryPoint:="usb_relay_device_enumerate")>
  Public Function Enumerate() As IntPtr
  End Function

  <DllImport("usb_relay_device.dll", EntryPoint:="usb_relay_device_free_enumerate", CallingConvention:=CallingConvention.Cdecl)>
  Public Sub FreeEnumerate(list As IntPtr)
  End Sub

  ' intptr_t USBRL_API usb_relay_device_open_with_serial_number(const char *serial_number, unsigned len);
  <DllImport("usb_relay_device.dll", EntryPoint:="usb_relay_device_open_with_serial_number", CallingConvention:=CallingConvention.Cdecl)>
  Public Function OpenWithSerialNumber(ByVal serial As String, ByVal len As UInteger) As IntPtr
  End Function


  ' intptr_t USBRL_API usb_relay_device_open(struct usb_relay_device_info *device_info);
  <DllImport("usb_relay_device.dll", EntryPoint:="usb_relay_device_open", CallingConvention:=CallingConvention.Cdecl)>
  Public Function Open(ByRef dev As UsbRelayDeviceInfo) As IntPtr
  End Function

  ' void USBRL_API usb_relay_device_close(intptr_t hHandle);
  <DllImport("usb_relay_device.dll", EntryPoint:="usb_relay_device_close", CallingConvention:=CallingConvention.Cdecl)>
  Public Sub Close(ByVal hHandle As IntPtr)
  End Sub

  'int USBRL_API usb_relay_device_get_num_relays(intptr_t ptr_usb_relay_device_info);
  <DllImport("usb_relay_device.dll", EntryPoint:="usb_relay_device_get_num_relays", CallingConvention:=CallingConvention.Cdecl)>
  Public Function GetNumRelays(ByVal hHandle As IntPtr) As Integer
  End Function

  ' intptr_t USBRL_API usb_relay_device_get_id_string(intptr_t ptr_usb_relay_device_info);
  <DllImport("usb_relay_device.dll", EntryPoint:="usb_relay_device_get_id_string", CallingConvention:=CallingConvention.Cdecl)>
  Private Function GetIdStringPointer(ByVal hHandle As IntPtr) As IntPtr
  End Function

  Public Function GetIdString(ByVal hHandle As IntPtr) As String
    Return Marshal.PtrToStringAnsi(GetIdStringPointer(hHandle))
  End Function

  ' int USBRL_API usb_relay_device_open_one_relay_channel(intptr_t hHandle, int index);
  <DllImport("usb_relay_device.dll", EntryPoint:="usb_relay_device_open_one_relay_channel", CallingConvention:=CallingConvention.Cdecl)>
  Public Function OpenOneRelayChannel(ByVal hHandle As IntPtr, ByVal index As Integer) As Integer
  End Function

  ' int USBRL_API usb_relay_device_close_one_relay_channel(intptr_t hHandle, int index);
  <DllImport("usb_relay_device.dll", EntryPoint:="usb_relay_device_close_one_relay_channel", CallingConvention:=CallingConvention.Cdecl)>
  Public Function CloseOneRelayChannel(ByVal hHandle As IntPtr, ByVal index As Integer) As Integer
  End Function

  ' int USBRL_API usb_relay_device_open_all_relay_channel(intptr_t hHandle);
  <DllImport("usb_relay_device.dll", EntryPoint:="usb_relay_device_open_all_relay_channel", CallingConvention:=CallingConvention.Cdecl)>
  Public Function OpenAllRelayChannel(ByVal hHandle As IntPtr) As Integer
  End Function

  ' int USBRL_API usb_relay_device_close_all_relay_channel(intptr_t hHandle);
  <DllImport("usb_relay_device.dll", EntryPoint:="usb_relay_device_close_all_relay_channel", CallingConvention:=CallingConvention.Cdecl)>
  Public Function CloseAllRelayChannel(ByVal hHandle As IntPtr) As Integer
  End Function


  ' int USBRL_API usb_relay_device_get_status(intptr_t hHandle, unsigned int *status);

  ' int USBRL_API usb_relay_device_get_status_bitmap(intptr_t hHandle);
  <DllImport("usb_relay_device.dll", EntryPoint:="usb_relay_device_get_status_bitmap", CallingConvention:=CallingConvention.Cdecl)>
  Public Function GetStatusBitmap(ByVal hHandle As IntPtr) As Integer
  End Function

End Module
