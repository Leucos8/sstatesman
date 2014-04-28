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

Friend Class WinAPI
#Region "Structures"
    ''' <summary>http://msdn.microsoft.com/en-us/library/windows/desktop/bb773244(v=vs.85).aspx</summary>
    <StructLayout(LayoutKind.Sequential)> _
    Friend Structure MARGINS
        Friend cxLeftWidth As Integer
        Friend cxRightWidth As Integer
        Friend cyTopHeight As Integer
        Friend cyBottomHeight As Integer
        Friend Sub New(Left As Integer, Top As Integer, Right As Integer, Bottom As Integer)
            cxLeftWidth = Left
            cxRightWidth = Right
            cyTopHeight = Top
            cyBottomHeight = Bottom
        End Sub
    End Structure
    ''' <summary>http://msdn.microsoft.com/en-us/library/windows/desktop/ms632606(v=vs.85).aspx</summary>
    <StructLayout(LayoutKind.Sequential)> _
    Friend Structure NCCALCSIZE_PARAMS
        Friend rect0 As RECT
        Friend rect1 As RECT
        Friend rect2 As RECT
        Friend lppos As IntPtr
    End Structure
    ''' <summary>http://msdn.microsoft.com/en-us/library/windows/desktop/dd162897(v=vs.85).aspx</summary>
    <StructLayout(LayoutKind.Sequential)> _
    Friend Structure RECT
        Friend left As Integer
        Friend top As Integer
        Friend right As Integer
        Friend bottom As Integer
    End Structure
    ''' <summary>http://msdn.microsoft.com/en-us/library/windows/desktop/ms632612(v=vs.85).aspx</summary>
    <StructLayout(LayoutKind.Sequential)> _
    Friend Structure WINDOWPOS
        Friend hwnd As IntPtr
        Friend hwndInsertAfter As IntPtr
        Friend x As Integer
        Friend y As Integer
        Friend cx As Integer
        Friend cy As Integer
        Friend flags As UInteger
    End Structure
#End Region

#Region "Other"
    ''' <summary>http://msdn.microsoft.com/en-us/library/windows/desktop/ms645618(v=vs.85).aspx</summary>
    Enum HitTest As Integer
        HTERROR = -2
        HTTRANSPARENT = -1
        HTNOWHERE = 0
        HTCLIENT = 1
        HTCAPTION = 2
        HTSYSMENU = 3
        HTGROWBOX = 4
        HTSIZE = 4
        HTMENU = 5
        HTHSCROLL = 6
        HTVSCROLL = 7
        HTMINBUTTON = 8
        HTMAXBUTTON = 9
        HTLEFT = 10
        HTRIGHT = 11
        HTTOP = 12
        HTTOPLEFT = 13
        HTTOPRIGHT = 14
        HTBOTTOM = 15
        HTBOTTOMLEFT = 16
        HTBOTTOMRIGHT = 17
        HTBORDER = 18
        HTCLOSE = 20
        HTHELP = 21
    End Enum
    ''' <summary>
    ''' Releases the mouse capture. 
    ''' http://msdn.microsoft.com/en-us/library/windows/desktop/ms646261(v=vs.85).aspx
    ''' </summary>
    ''' <returns>Zero if the function fails, non-zero if the fuction succedes.</returns>
    <DllImport("user32.dll")> _
    Public Shared Function ReleaseCapture() As Integer
    End Function
#End Region

#Region "Windows Messaging API"
    ''' <summary>http://msdn.microsoft.com/en-us/library/windows/desktop/ms644927(v=vs.85).aspx#system_defined</summary>
    Friend Enum Win32Messages As Integer
        ''' <summary>http://msdn.microsoft.com/en-us/library/windows/desktop/ms647592(v=vs.85).aspx</summary>
        WM_CONTEXTMENU = &H7B
        ''' <summary>http://msdn.microsoft.com/en-us/library/windows/desktop/ms632634(v=vs.85).aspx</summary>
        WM_NCCALCSIZE = &H83
        ''' <summary>http://msdn.microsoft.com/en-us/library/windows/desktop/ms645618(v=vs.85).aspx</summary>
        WM_NCHITTEST = &H84
        ''' <summary>http://msdn.microsoft.com/en-us/library/windows/desktop/ms645620(v=vs.85).aspx</summary>
        WM_NCLBUTTONDOWN = &HA1
        ''' <summary>http://msdn.microsoft.com/en-us/library/windows/desktop/ms645619(v=vs.85).aspx</summary>
        WM_NCLBUTTONDBLCLK = &HA3
        ''' <summary>http://msdn.microsoft.com/en-us/library/windows/desktop/ms645629(v=vs.85).aspx</summary>
        WM_NCRBUTTONDOWN = &HA4
        ''' <summary>http://msdn.microsoft.com/en-us/library/windows/desktop/ms645630(v=vs.85).aspx</summary>
        WM_NCRBUTTONUP = &HA5
        ''' <summary>http://msdn.microsoft.com/en-us/library/windows/desktop/ms646360(v=vs.85).aspx</summary>
        WM_SYSCOMMAND = &H112
    End Enum
    ''' <summary>
    ''' Sends the specified message to a window or windows.
    ''' http://msdn.microsoft.com/en-us/library/windows/desktop/ms644950(v=vs.85).aspx
    ''' </summary>
    ''' <param name="hWnd">Handle to the window that will receive the message.</param>
    ''' <param name="Msg">The message to be sent.</param>
    ''' <param name="wParam">Additional message-specific information.</param>
    ''' <param name="lParam">Additional message-specific information.</param>
    ''' <returns>Return value depends on Msg.</returns>
    <DllImport("user32.dll")> _
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function
    ''' <summary>
    ''' Sends the specified message to the message queue of a window.
    ''' http://msdn.microsoft.com/en-us/library/windows/desktop/ms644944(v=vs.85).aspx
    ''' </summary>
    ''' <param name="hWnd">Handle to the window that will receive the message.</param>
    ''' <param name="Msg">The message to be sent.</param>
    ''' <param name="wParam">Additional message-specific information.</param>
    ''' <param name="lParam">Additional message-specific information.</param>
    ''' <returns>Return value depends on Msg.</returns>
    <DllImport("user32.dll")> _
    Public Shared Function PostMessage(ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    End Function
#End Region

#Region "Menu API"
    ''' <summary>http://msdn.microsoft.com/en-us/library/windows/desktop/ms646360(v=vs.85).aspx</summary>
    Enum SysCommand As Integer
        SC_CLOSE = &HF060
        SC_CONTEXTHELP = &HF180
        SC_DEFAULT = &HF160
        SC_HOTKEY = &HF150
        SC_HSCROLL = &HF080
        SCF_ISSECURE = &H1
        SC_KEYMENU = &HF100
        SC_MAXIMIZE = &HF030
        SC_MINIMIZE = &HF020
        SC_MONITORPOWER = &HF170
        SC_MOUSEMENU = &HF090
        SC_MOVE = &HF010
        SC_NEXTWINDOW = &HF040
        SC_PREVWINDOW = &HF050
        SC_RESTORE = &HF120
        SC_SCREENSAVE = &HF140
        SC_SIZE = &HF000
        SC_TASKLIST = &HF130
        SC_VSCROLL = &HF070
    End Enum
    ''' <summary>http://msdn.microsoft.com/en-us/library/windows/desktop/ms648002(v=vs.85).aspx</summary>
    Enum TPM As Integer
        'Horizontal align
        TPM_CENTERALIGN = &H4
        TPM_LEFTALIGN = &H0
        TPM_RIGHTALIGN = &H8
        'Vertical align
        TPM_BOTTOMALIGN = &H20
        TPM_TOPALINN = &H0
        TPM_VCENTERALIGN = &H10
        'Return value
        TPM_NONOTIFY = &H80
        TPM_RETURNCMD = &H100
        'Mouse button tracked
        TPM_LEFTBUTTON = &H0
        TPM_RIGHTBUTTON = &H2
        'Animations
        TPM_HORNEGANIMATION = &H800
        TPM_HORPOSANIMATION = &H400
        TPM_NOANIMATION = &H4000
        TPM_VERNEGANIMATION = &H2000
        TPM_VERPOSANIMATION = &H1000
    End Enum
    ''' <summary>
    ''' Get the handle of the application menu.
    ''' http://msdn.microsoft.com/en-us/library/windows/desktop/ms647985(v=vs.85).aspx
    ''' </summary>
    ''' <param name="hWnd">Handle of the window.</param>
    ''' <param name="bRevert">False, the result is a pointer to an editable copy of the system menu; True, the system menu is reset.</param>
    ''' <returns>bRevert = False, the result is a pointer to an editable copy of the system menu; True,  return null.</returns>
    ''' <remarks></remarks>
    <DllImport("user32.dll")> _
    Public Shared Function GetSystemMenu(hWnd As IntPtr, <MarshalAs(UnmanagedType.I1)> bRevert As Boolean) As IntPtr
    End Function
    ''' <summary>
    ''' Display the shortcut menu at the specified location with the specified option and allows its tracking.
    ''' http://msdn.microsoft.com/en-us/library/windows/desktop/ms648002(v=vs.85).aspx
    ''' </summary>
    ''' <param name="hMenu">Handle of the shortcut menu.</param>
    ''' <param name="wFlags">A combination of flags that defines the behaviour of the menu (e.g. opening animation, alignment).</param>
    ''' <param name="x">X screen coordinate where the menu will be shown.</param>
    ''' <param name="y">Y screen coordinate where the menu will be shown.</param>
    ''' <param name="nReserved">Reserved, must be zero.</param>
    ''' <param name="hwnd">Owner window handle.</param>
    ''' <param name="lprc">Ignored.</param>
    ''' <returns>If TPM_RETURNCMD is specified in wFlags returns the identifier to the menu item selected by the user, 0 if the user closed the menu; 
    ''' if not, return non-zero if the function succeded, zero in case of errors.</returns>
    ''' <remarks></remarks>
    <DllImport("user32.dll")>
    Public Shared Function TrackPopupMenu(hMenu As IntPtr, wFlags As Integer, x As Integer, y As Integer, nReserved As Integer, hwnd As IntPtr, ByRef lprc As RECT) As Integer
    End Function
#End Region

End Class
