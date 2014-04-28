'   ModernUIForm - Small class library for creating borderless windows
'   Copyright (C) 2014 - Leucos
'
'   ModernUIForm is free software: you can redistribute it and/or modify it under
'   the terms of the GNU Lesser General Public License as published by the Free
'   Software Foundation, either version 3 of the License, or (at your option) any
'   later version.
'
'   ModernUIForm is distributed in the hope that it will be useful, but WITHOUT ANY
'   WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A
'   PARTICULAR PURPOSE. See the GNU General Public License for more details.
'
'   You should have received a copy of the GNU General Public License along with 
'   ModernUIForm. If not, see <http://www.gnu.org/licenses/>.

Imports System.Runtime.InteropServices
Imports ModernUIForm.WinAPI

Friend Class DWM
    ''' <summary>
    ''' http://msdn.microsoft.com/en-us/library/windows/desktop/aa969507(v=vs.85).aspx
    ''' </summary>
    ''' <param name="hwnd">Handle to the window.</param>
    ''' <param name="msg">Message.</param>
    ''' <param name="wParam">Parameter, value depending on Msg.</param>
    ''' <param name="lParam">Additional parameter, value depending on Msg.</param>
    ''' <param name="plResult">Return result value.</param>
    ''' <returns>TRUE if DwmDefWindowProc handled the message, else FALSE.</returns>
    <DllImport("dwmapi.dll")> _
    Friend Shared Function DwmDefWindowProc(<[In]> ByVal hwnd As IntPtr, ByVal msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr, <Out> ByRef plResult As IntPtr) As <MarshalAs(UnmanagedType.I1)> Boolean
    End Function

    ''' <summary>
    ''' Extends the window frame into the client area.
    ''' http://msdn.microsoft.com/en-us/library/windows/desktop/aa969512(v=vs.85).aspx
    ''' </summary>
    ''' <param name="hWnd">Handle to the window.</param>
    ''' <param name="marInset">Pointer to a MARGINS structure that contains the values for extending the frame.</param>
    ''' <returns>S_OK or HRESULT error code.</returns>
    <DllImport("dwmapi.dll")> _
    Friend Shared Function DwmExtendFrameIntoClientArea(ByVal hWnd As IntPtr, <[In]> ByRef marInset As MARGINS) As Integer
    End Function
    ''' <summary>
    ''' Indicates if the DWM is enabled
    ''' http://msdn.microsoft.com/en-us/library/windows/desktop/aa969518(v=vs.85).aspx
    ''' </summary>
    ''' <param name="pfEnabled">Return value, TRUE if DWM is enable, FALSE if not. </param>
    <DllImport("dwmapi.dll")> _
    Friend Shared Function DwmIsCompositionEnabled(<MarshalAs(UnmanagedType.I1), Out> ByRef pfEnabled As Boolean) As Integer
    End Function


    Friend Shared Function IsDwmEnabled() As Boolean
        If Environment.OSVersion.Version.Major < 6 Then
            Return False
        End If
        Dim isGlassSupported As Boolean = False
        DWM.DwmIsCompositionEnabled(isGlassSupported)
        Return isGlassSupported
    End Function

End Class
