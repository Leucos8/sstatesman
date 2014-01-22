﻿'   SStatesMan - a savestate managing tool for PCSX2
'   Copyright (C) 2011-2013 - Leucos
'
'   SStatesMan is free software: you can redistribute it and/or modify it under
'   the terms of the GNU Lesser General Public License as published by the Free
'   Software Foundation, either version 3 of the License, or (at your option) any
'   later version.
'
'   SStatesMan is distributed in the hope that it will be useful, but WITHOUT ANY
'   WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A
'   PARTICULAR PURPOSE. See the GNU General Public License for more details.
'
'   You should have received a copy of the GNU General Public License along with 
'   SStatesMan. If not, see <http://www.gnu.org/licenses/>.

'------------------------------------------------------------------------------
' <auto-generated>
'     Il codice è stato generato da uno strumento.
'     Versione runtime:4.0.30319.34003
'
'     Le modifiche apportate a questo file possono provocare un comportamento non corretto e andranno perse se
'     il codice viene rigenerato.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0"),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Partial Friend NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()),MySettings)
        
#Region "Funzionalità di salvataggio automatico My.Settings"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(ByVal sender As Global.System.Object, ByVal e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
        
        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
                Return defaultInstance
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute(".p2s")>  _
        Public ReadOnly Property PCSX2_SStateExt() As String
            Get
                Return CType(Me("PCSX2_SStateExt"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute(".backup")>  _
        Public ReadOnly Property PCSX2_SStateExtBackup() As String
            Get
                Return CType(Me("PCSX2_SStateExtBackup"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("GameIndex.dbf")>  _
        Public ReadOnly Property PCSX2_GameDbFilename() As String
            Get
                Return CType(Me("PCSX2_GameDbFilename"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("alpha")>  _
        Public ReadOnly Property SStatesMan_Channel() As String
            Get
                Return CType(Me("SStatesMan_Channel"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Software\PCSX2")>  _
        Public ReadOnly Property PCSX2_PathRegKey() As String
            Get
                Return CType(Me("PCSX2_PathRegKey"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Install_Dir")>  _
        Public ReadOnly Property PCSX2_PathBinReg() As String
            Get
                Return CType(Me("PCSX2_PathBinReg"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("SettingsFolder")>  _
        Public ReadOnly Property PCSX2_PathInisReg() As String
            Get
                Return CType(Me("PCSX2_PathInisReg"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("sstates")>  _
        Public ReadOnly Property PCSX2_SStateFolder() As String
            Get
                Return CType(Me("PCSX2_SStateFolder"),String)
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property SStatesMan_FirstRun() As Boolean
            Get
                Return CType(Me("SStatesMan_FirstRun"),Boolean)
            End Get
            Set
                Me("SStatesMan_FirstRun") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property SStatesMan_FileTrash() As Boolean
            Get
                Return CType(Me("SStatesMan_FileTrash"),Boolean)
            End Get
            Set
                Me("SStatesMan_FileTrash") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property SStatesMan_PathPics() As String
            Get
                Return CType(Me("SStatesMan_PathPics"),String)
            End Get
            Set
                Me("SStatesMan_PathPics") = value
            End Set
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("coverpics")>  _
        Public ReadOnly Property SStatesMan_PicsFolder() As String
            Get
                Return CType(Me("SStatesMan_PicsFolder"),String)
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property SStatesMan_ThemeGradientEnabled() As Boolean
            Get
                Return CType(Me("SStatesMan_ThemeGradientEnabled"),Boolean)
            End Get
            Set
                Me("SStatesMan_ThemeGradientEnabled") = value
            End Set
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("PCSX2_ui.ini")>  _
        Public ReadOnly Property PCSX2_PCSX2_uiFilename() As String
            Get
                Return CType(Me("PCSX2_PCSX2_uiFilename"),String)
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property SStatesMan_SStatesListAutoRefresh() As Boolean
            Get
                Return CType(Me("SStatesMan_SStatesListAutoRefresh"),Boolean)
            End Get
            Set
                Me("SStatesMan_SStatesListAutoRefresh") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property SStatesMan_SStatesListShowOnly() As Boolean
            Get
                Return CType(Me("SStatesMan_SStatesListShowOnly"),Boolean)
            End Get
            Set
                Me("SStatesMan_SStatesListShowOnly") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("squares")>  _
        Public Property SStatesMan_Theme() As String
            Get
                Return CType(Me("SStatesMan_Theme"),String)
            End Get
            Set
                Me("SStatesMan_Theme") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property SStatesMan_SStatesVersionExtract() As Boolean
            Get
                Return CType(Me("SStatesMan_SStatesVersionExtract"),Boolean)
            End Get
            Set
                Me("SStatesMan_SStatesVersionExtract") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property SStatesMan_ThemeImageEnabled() As Boolean
            Get
                Return CType(Me("SStatesMan_ThemeImageEnabled"),Boolean)
            End Get
            Set
                Me("SStatesMan_ThemeImageEnabled") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("624, 442")>  _
        Public Property frmMain_WindowSize() As Global.System.Drawing.Size
            Get
                Return CType(Me("frmMain_WindowSize"),Global.System.Drawing.Size)
            End Get
            Set
                Me("frmMain_WindowSize") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Normal")>  _
        Public Property frmMain_WindowState() As Global.System.Windows.Forms.FormWindowState
            Get
                Return CType(Me("frmMain_WindowState"),Global.System.Windows.Forms.FormWindowState)
            End Get
            Set
                Me("frmMain_WindowState") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("128, 64")>  _
        Public Property frmMain_WindowLocation() As Global.System.Drawing.Point
            Get
                Return CType(Me("frmMain_WindowLocation"),Global.System.Drawing.Point)
            End Get
            Set
                Me("frmMain_WindowLocation") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("200")>  _
        Public Property frmMain_SplitterDistance() As Integer
            Get
                Return CType(Me("frmMain_SplitterDistance"),Integer)
            End Get
            Set
                Me("frmMain_SplitterDistance") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("640, 360")>  _
        Public Property frmDel_WindowSize() As Global.System.Drawing.Size
            Get
                Return CType(Me("frmDel_WindowSize"),Global.System.Drawing.Size)
            End Get
            Set
                Me("frmDel_WindowSize") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Normal")>  _
        Public Property frmDel_WindowState() As Global.System.Windows.Forms.FormWindowState
            Get
                Return CType(Me("frmDel_WindowState"),Global.System.Windows.Forms.FormWindowState)
            End Get
            Set
                Me("frmDel_WindowState") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property frmMain_CoverExpanded() As Boolean
            Get
                Return CType(Me("frmMain_CoverExpanded"),Boolean)
            End Get
            Set
                Me("frmMain_CoverExpanded") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("128, 72")>  _
        Public Property frmDel_WindowLocation() As Global.System.Drawing.Point
            Get
                Return CType(Me("frmDel_WindowLocation"),Global.System.Drawing.Point)
            End Get
            Set
                Me("frmDel_WindowLocation") = value
            End Set
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("snaps")>  _
        Public ReadOnly Property PCSX2_SnapsFolder() As String
            Get
                Return CType(Me("PCSX2_SnapsFolder"),String)
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property SStatesMan_SettingsOK() As Boolean
            Get
                Return CType(Me("SStatesMan_SettingsOK"),Boolean)
            End Get
            Set
                Me("SStatesMan_SettingsOK") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property PCSX2_PathInis() As String
            Get
                Return CType(Me("PCSX2_PathInis"),String)
            End Get
            Set
                Me("PCSX2_PathInis") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property PCSX2_PathSState() As String
            Get
                Return CType(Me("PCSX2_PathSState"),String)
            End Get
            Set
                Me("PCSX2_PathSState") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property PCSX2_PathBin() As String
            Get
                Return CType(Me("PCSX2_PathBin"),String)
            End Get
            Set
                Me("PCSX2_PathBin") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property PCSX2_PathSnaps() As String
            Get
                Return CType(Me("PCSX2_PathSnaps"),String)
            End Get
            Set
                Me("PCSX2_PathSnaps") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property frmMain_glvw_columnwidth() As Integer()
            Get
                Return CType(Me("frmMain_glvw_columnwidth"),Integer())
            End Get
            Set
                Me("frmMain_glvw_columnwidth") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property frmMain_flvw_columnwidth() As Integer()
            Get
                Return CType(Me("frmMain_flvw_columnwidth"),Integer())
            End Get
            Set
                Me("frmMain_flvw_columnwidth") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute()>  _
        Public Property frmDel_flvw_columnwidth() As Integer()
            Get
                Return CType(Me("frmDel_flvw_columnwidth"),Integer())
            End Get
            Set
                Me("frmDel_flvw_columnwidth") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property SStatesMan_SStateReorderBackup() As Boolean
            Get
                Return CType(Me("SStatesMan_SStateReorderBackup"),Boolean)
            End Get
            Set
                Me("SStatesMan_SStateReorderBackup") = value
            End Set
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("0")>  _
        Public ReadOnly Property PCSX2_SStateSlotLowerBound() As Integer
            Get
                Return CType(Me("PCSX2_SStateSlotLowerBound"),Integer)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("9")>  _
        Public ReadOnly Property PCSX2_SStateSlotUpperBound() As Integer
            Get
                Return CType(Me("PCSX2_SStateSlotUpperBound"),Integer)
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property SStatesMan_PathStored() As String
            Get
                Return CType(Me("SStatesMan_PathStored"),String)
            End Get
            Set
                Me("SStatesMan_PathStored") = value
            End Set
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(), _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), _
         Global.System.Configuration.DefaultSettingValueAttribute("<?xml version=""1.0"" encoding=""utf-16""?>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<ArrayOfString xmlns:xsi=""http://www.w3." & _
            "org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  <s" & _
            "tring>.bmp</string>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  <string>.png</string>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  <string>.jpg</string>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  <string" & _
            ">.jpeg</string>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  <string>.jpe</string>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "  <string>.gif</string>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "</ArrayOfStri" & _
            "ng>")> _
        Public ReadOnly Property SStatesMan_ScreenshotExts() As String()
            Get
                Return CType(Me("SStatesMan_ScreenshotExts"), String())
            End Get
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.sstatesman.My.MySettings
            Get
                Return Global.sstatesman.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace
