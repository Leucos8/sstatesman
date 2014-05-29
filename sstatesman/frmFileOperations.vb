'   SStatesMan - a small frontend for PCSX2
'   Copyright (C) 2011-2014 - Leucos
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
Imports System.IO
Public Class frmFileOperations
    Friend currentOperationMode As FileOperations = FileOperations.Reorder

    Protected Friend SourcePath As String = String.Empty
    Protected Friend DestPath As String = String.Empty
    Protected Friend SourceFileNames As List(Of String)
    Protected Friend DestFileNames As List(Of String)
    Friend OperationResults As List(Of mdlFileOperations.FileStatus)
    Protected Friend OperationResultMessages As List(Of String)
    Protected Friend OperationDone As Boolean = False

    Enum FileOperations
        Delete          'The files are deleted
        Reorder         'The savestates are renamed depending on their order
        Store           'The savestates are stored to a different directory
        Restore         'The savestates are restored in their original directory
        Assign          'The screenshots are assigned (renamed) to a game
    End Enum

    Enum FileListColumns
        Number = 0
        OldName = 1
        NewName = 2
        Status = 3
    End Enum

    Private Sub frmFileOperations_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sw As Stopwatch = Stopwatch.StartNew
        Dim tmpTicks As Long = 0

        SSMAppLog.Append(eType.LogInformation, eSrc.ReorderWindow, eSrcMethod.Load, "Form load start.")

        '==================
        'Window preparation
        '==================
        If Not (Me.IsShown) Then
            Me.flpWindowBottom.Controls.AddRange({Me.cmdCancel, Me.cmdOperation})
            Me.pnlFormContent.Dock = DockStyle.Fill

            'Savestates, backup, and screenshot icons
            Me.lvwFileList.SmallImageList = mdlTheme.imlLvwItemIcons
        End If
        'Checked state icons
        Me.lvwFileList.StateImageList = New ImageList With {.ImageSize = mdlTheme.imlLvwCheckboxes.ImageSize}        'Cannot use imlLvwCheckboxes directly because of a bug that makes checkboxes disappear.
        Me.lvwFileList.StateImageList.Images.AddRange({mdlTheme.imlLvwCheckboxes.Images(0), mdlTheme.imlLvwCheckboxes.Images(1)})

        SSMAppLog.Append(eType.LogInformation, eSrc.ReorderWindow, eSrcMethod.Load, "1/3 Layout & resources.", sw.ElapsedTicks - tmpTicks)
        tmpTicks = sw.ElapsedTicks

        '---------------
        'Window settings
        '---------------

        'Main window location, size and state
        'Me.Location = My.Settings.frmDel_WindowLocation
        Me.Size = My.Settings.frmFileOps_WindowSize
        If My.Settings.frmFileOps_WindowState = FormWindowState.Minimized Then
            My.Settings.frmFileOps_WindowState = FormWindowState.Normal
        End If
        Me.WindowState = My.Settings.frmFileOps_WindowState

        SSMAppLog.Append(eType.LogInformation, eSrc.DeleteWindow, eSrcMethod.Load, "2/3 Saved window sizes applied.", sw.ElapsedTicks - tmpTicks)
        tmpTicks = sw.ElapsedTicks

        '===============================
        'Post file load form preparation
        '===============================
        Me.OperationLoad()



        SSMAppLog.Append(eType.LogInformation, eSrc.ReorderWindow, eSrcMethod.Load, "3/3 Post load done.", sw.ElapsedTicks - tmpTicks)
        'tmpTicks = sw.ElapsedTicks

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.ReorderWindow, eSrcMethod.Load, "Load complete.", sw.ElapsedTicks)
    End Sub

    Private Sub frmFileOperations_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim sw As Stopwatch = Stopwatch.StartNew

        Me.OperationUnload()


        '======================
        'Saving window settings
        '======================

        'State, location, and size
        My.Settings.frmFileOps_WindowState = Me.WindowState
        If Me.WindowState = FormWindowState.Normal Then
            'Location and size saved only when windowstate is normal
            'My.Settings.frmDel_WindowLocation = Me.Location
            My.Settings.frmFileOps_WindowSize = Me.Size
        End If

        'Column widths
        'My.Settings.frmDel_flvw_columnwidth = New Integer() {Me.chFileName.Width, Me.chSlot.Width, _
        '                                                     Me.chVersion.Width, Me.chModified.Width, _
        '                                                     Me.chSize.Width, Me.chStatus.Width}

        Me.lvwFileList.Items.Clear()
        Me.lvwFileList.Groups.Clear()
        Me.lvwFileList.Columns.Clear()

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.DeleteWindow, eSrcMethod.Close, "Form closed.", sw.ElapsedTicks)

        '====================
        'Refreshing all lists
        '====================
        frmMain.GameList_Refresh()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Protected Overridable Sub OperationLoad()
        Debug.Print(DateTime.Now & " " & New StackFrame(1).GetMethod.Name & " > " & System.Reflection.MethodBase.GetCurrentMethod().Name)

    End Sub

    Protected Overridable Sub OperationUnload()
        Debug.Print(DateTime.Now & " " & New StackFrame(1).GetMethod.Name & " > " & System.Reflection.MethodBase.GetCurrentMethod().Name)
        Me.OperationDone = False

        'Select Case Me.currentOperationMode
        '    Case FileOperations.Delete : Me.DeleteList_FormUnload()
        '    Case FileOperations.Reorder : Me.ReorderList_FormUnload()
        '    Case FileOperations.Store, FileOperations.Restore : Me.StoreList_FormUnload()
        '        'Case FileOperations.Assign
        'End Select
    End Sub

    Protected Overridable Sub OperationListFiles()
        Debug.Print(DateTime.Now & " " & New StackFrame(1).GetMethod.Name & " > " & System.Reflection.MethodBase.GetCurrentMethod().Name)

    End Sub

    Protected Overridable Sub OperationListPreview()
        Debug.Print(DateTime.Now & " " & New StackFrame(1).GetMethod.Name & " > " & System.Reflection.MethodBase.GetCurrentMethod().Name)

    End Sub

    Protected Overridable Sub OperationUpdateUI()
        Debug.Print(DateTime.Now & " " & New StackFrame(1).GetMethod.Name & " > " & System.Reflection.MethodBase.GetCurrentMethod().Name)

    End Sub

    Private Sub frmMain_ThemeApplied(sender As Object, e As EventArgs) Handles MyBase.ThemeApplied
        Me.tlpFileListStatus.BackColor = Me.BorderColorActive
    End Sub

End Class