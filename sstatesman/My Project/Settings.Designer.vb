﻿'   SStatesMan - a savestate managing tool for PCSX2
'   Copyright (C) 2011-2012 - Leucos
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
'     Versione runtime:4.0.30319.269
'
'     Le modifiche apportate a questo file possono provocare un comportamento non corretto e andranno perse se
'     il codice viene rigenerato.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0"),  _
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
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Not detected")>  _
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
         Global.System.Configuration.DefaultSettingValueAttribute("Not detected")>  _
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
         Global.System.Configuration.DefaultSettingValueAttribute("Not detected")>  _
        Public Property PCSX2_PathSState() As String
            Get
                Return CType(Me("PCSX2_PathSState"),String)
            End Get
            Set
                Me("PCSX2_PathSState") = value
            End Set
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
         Global.System.Configuration.DefaultSettingValueAttribute("SStates")>  _
        Public ReadOnly Property PCSX2_SStateFolder() As String
            Get
                Return CType(Me("PCSX2_SStateFolder"),String)
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property SStatesMan_FirstRun2() As Boolean
            Get
                Return CType(Me("SStatesMan_FirstRun2"),Boolean)
            End Get
            Set
                Me("SStatesMan_FirstRun2") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("True")>  _
        Public Property SStatesMan_SStateTrash() As Boolean
            Get
                Return CType(Me("SStatesMan_SStateTrash"),Boolean)
            End Get
            Set
                Me("SStatesMan_SStateTrash") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Not set")>  _
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
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property SStatesMan_ThemeGradientEnabled() As Boolean
            Get
                Return CType(Me("SStatesMan_ThemeGradientEnabled"),Boolean)
            End Get
            Set
                Me("SStatesMan_ThemeGradientEnabled") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property PCSX2_PathBinSet() As Boolean
            Get
                Return CType(Me("PCSX2_PathBinSet"),Boolean)
            End Get
            Set
                Me("PCSX2_PathBinSet") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property PCSX2_PathInisSet() As Boolean
            Get
                Return CType(Me("PCSX2_PathInisSet"),Boolean)
            End Get
            Set
                Me("PCSX2_PathInisSet") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("False")>  _
        Public Property PCSX2_PathSStatesSet() As Boolean
            Get
                Return CType(Me("PCSX2_PathSStatesSet"),Boolean)
            End Get
            Set
                Me("PCSX2_PathSStatesSet") = value
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
         Global.System.Configuration.DefaultSettingValueAttribute("1")>  _
        Public Property SStatesMan_Theme() As Byte
            Get
                Return CType(Me("SStatesMan_Theme"),Byte)
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
         Global.System.Configuration.DefaultSettingValueAttribute("20, 20")>  _
        Public Property frmMain_WindowPosition() As Global.System.Drawing.Point
            Get
                Return CType(Me("frmMain_WindowPosition"),Global.System.Drawing.Point)
            End Get
            Set
                Me("frmMain_WindowPosition") = value
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
         Global.System.Configuration.DefaultSettingValueAttribute("220")>  _
        Public Property frmMain_glvw_cGameTitle() As Integer
            Get
                Return CType(Me("frmMain_glvw_cGameTitle"),Integer)
            End Get
            Set
                Me("frmMain_glvw_cGameTitle") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("80")>  _
        Public Property frmMain_glvw_cSerial() As Integer
            Get
                Return CType(Me("frmMain_glvw_cSerial"),Integer)
            End Get
            Set
                Me("frmMain_glvw_cSerial") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("60")>  _
        Public Property frmMain_glvw_cRegion() As Integer
            Get
                Return CType(Me("frmMain_glvw_cRegion"),Integer)
            End Get
            Set
                Me("frmMain_glvw_cRegion") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("110")>  _
        Public Property frmMain_glvw_cStInfo() As Integer
            Get
                Return CType(Me("frmMain_glvw_cStInfo"),Integer)
            End Get
            Set
                Me("frmMain_glvw_cStInfo") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("110")>  _
        Public Property frmMain_glvw_cSbInfo() As Integer
            Get
                Return CType(Me("frmMain_glvw_cSbInfo"),Integer)
            End Get
            Set
                Me("frmMain_glvw_cSbInfo") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("220")>  _
        Public Property frmMain_slvw_cFileName() As Integer
            Get
                Return CType(Me("frmMain_slvw_cFileName"),Integer)
            End Get
            Set
                Me("frmMain_slvw_cFileName") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("40")>  _
        Public Property frmMain_slvw_cSlot() As Integer
            Get
                Return CType(Me("frmMain_slvw_cSlot"),Integer)
            End Get
            Set
                Me("frmMain_slvw_cSlot") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("40")>  _
        Public Property frmMain_slvw_cBackup() As Integer
            Get
                Return CType(Me("frmMain_slvw_cBackup"),Integer)
            End Get
            Set
                Me("frmMain_slvw_cBackup") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("80")>  _
        Public Property frmMain_slvw_cVersion() As Integer
            Get
                Return CType(Me("frmMain_slvw_cVersion"),Integer)
            End Get
            Set
                Me("frmMain_slvw_cVersion") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("120")>  _
        Public Property frmMain_slvw_cDateLW() As Integer
            Get
                Return CType(Me("frmMain_slvw_cDateLW"),Integer)
            End Get
            Set
                Me("frmMain_slvw_cDateLW") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("80")>  _
        Public Property frmMain_slvw_cSize() As Integer
            Get
                Return CType(Me("frmMain_slvw_cSize"),Integer)
            End Get
            Set
                Me("frmMain_slvw_cSize") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("240")>  _
        Public Property frmDel_slvw_cFileName() As Integer
            Get
                Return CType(Me("frmDel_slvw_cFileName"),Integer)
            End Get
            Set
                Me("frmDel_slvw_cFileName") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("40")>  _
        Public Property frmDel_slvw_cSlot() As Integer
            Get
                Return CType(Me("frmDel_slvw_cSlot"),Integer)
            End Get
            Set
                Me("frmDel_slvw_cSlot") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("80")>  _
        Public Property frmDel_slvw_cVersion() As Integer
            Get
                Return CType(Me("frmDel_slvw_cVersion"),Integer)
            End Get
            Set
                Me("frmDel_slvw_cVersion") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("100")>  _
        Public Property frmDel_slvw_cSize() As Integer
            Get
                Return CType(Me("frmDel_slvw_cSize"),Integer)
            End Get
            Set
                Me("frmDel_slvw_cSize") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("120")>  _
        Public Property frmDel_slvw_cStatus() As Integer
            Get
                Return CType(Me("frmDel_slvw_cStatus"),Integer)
            End Get
            Set
                Me("frmDel_slvw_cStatus") = value
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
         Global.System.Configuration.DefaultSettingValueAttribute("20, 40")>  _
        Public Property frmDel_WindowLocation() As Global.System.Drawing.Point
            Get
                Return CType(Me("frmDel_WindowLocation"),Global.System.Drawing.Point)
            End Get
            Set
                Me("frmDel_WindowLocation") = value
            End Set
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
