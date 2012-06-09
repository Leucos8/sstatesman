'   SStatesMan - a savestate managing tool for PCSX2
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
Imports System.IO

Public Class frmSStateList
    Dim SStatesList_Pos As Int32 = 0
    Dim mySStatesListRecord As FileInfo = Nothing
    Private Sub ShowStatus()

        Me.mySStatesListRecord = Nothing

        Me.LblSearchResults.Text = ""

        Me.ToolStripStatusLabel2.Text = ""

        Select Case mdlFileList.GamesList_Status
            Case LoadStatus.StatusLoadedOK
                'Me.mySStatesListRecord = mdlSStatesList.SStatesList(Me.SStatesList_Pos)
                '        Me.ToolStripStatusLabel1.Text = System.String.Format("Position: {0}", Me.SStatesList_Pos.ToString("#,##0"))
                '        Me.ToolStripStatusLabel2.Text = System.String.Format("Records: {0}", mdlSStatesList.SStatesList.GetLength(0).ToString("#,##0"))
                '        If Me.SStatesList_Pos > mdlSStatesList.SStatesList.GetLowerBound(0) Then
                '            Me.tsRecordPrevious.Enabled = True
                '            Me.tsRecordFirst.Enabled = True
                '        End If
                '        If Me.SStatesList_Pos < mdlSStatesList.SStatesList.GetUpperBound(0) Then
                '            Me.tsRecordNext.Enabled = True
                '            Me.tsRecordLast.Enabled = True
                '        End If
                '        Me.tsSStateListUnload.Enabled = True
                '        Me.tsExport.Enabled = True

                '        Me.LblSearchResults.Text = "Serial   = " & SStatesList(SStatesList_Pos).SStateSerial & System.Environment.NewLine & _
                '                                   "Slot     = " & SStatesList(SStatesList_Pos).Slot & System.Environment.NewLine & _
                '                                   "Filename = " & SStatesList(SStatesList_Pos).FileInfo.Name & System.Environment.NewLine & _
                '                                   "Size     = " & (SStatesList(SStatesList_Pos).FileInfo.Length / 1024 / 1024).ToString("#,##0.00 MB") & System.Environment.NewLine & _
                '                                   "Created  = " & SStatesList(SStatesList_Pos).FileInfo.LastWriteTime
                '    Case LoadStatus.StatusNotLoaded
                '        Me.ToolStripStatusLabel1.Text = "SStatesList not loaded."
                '    Case LoadStatus.StatusError
                '        Me.ToolStripStatusLabel1.Text = "Error loading SStatesList."
                '    Case LoadStatus.StatusEmpty
                '        Me.ToolStripStatusLabel1.Text = "SStatesList has no records."
        End Select
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        Me.SStatesList_Pos = Me.ListBox1.SelectedIndex
        Me.ShowStatus()
    End Sub

    Private Sub frmSStateList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ListBox1.BeginUpdate()
        Me.ListBox1.Items.Clear()
        'For Each myCurrentGame As KeyValuePair(Of String, mdlSStatesList.rSStatesIndex) In mdlSStatesList.SStatesIndex
        '    For Each myCurrentSState As FileInfo In myCurrentGame.Value.SStates_List
        '        ListBox1.Items.Add(String.Format("{0,-12}|{1,2}|{2,-6}|{3,-36}|{4,12:#,##0.00 MB}|{5,20}|{6}", _
        '                                         mdlSStatesList.SStates_GetSerial(myCurrentSState.Name), _
        '                                         mdlSStatesList.SStates_GetSlot(myCurrentSState.Name).ToString, _
        '                                         mdlSStatesList.SStates_GetType(myCurrentSState.Name).ToString, _
        '                                         myCurrentSState.Name, _
        '                                         myCurrentSState.Length / 1024 ^ 2, _
        '                                         myCurrentSState.LastWriteTime.ToString, _
        '                                         myCurrentSState.Attributes.ToString))
        '    Next
        'Next
        Me.ListBox1.EndUpdate()
        Me.SStatesList_Pos = 0
        ShowStatus()
    End Sub

    Private Sub tsShowGameList_Click(sender As System.Object, e As System.EventArgs) Handles tsShowGameList.Click
        Me.ListBox1.BeginUpdate()
        Me.ListBox1.Items.Clear()
        'For Each mySerial As String In mdlFileList.GamesList.Keys
        '    Dim myRecord As GameTitle = mdlGameDb.GameDb_RecordExtract(mySerial,
        '                                                               mdlGameDb.GameDb,
        '                                                               mdlGameDb.GameDb_Status)
        '    Me.ListBox1.Items.Add(String.Concat(myRecord.Name, vbTab,
        '                                        myRecord.Serial, vbTab,
        '                                        myRecord.Region, vbTab,
        '                                        myRecord.Compat))
        'Next
        Me.ListBox1.EndUpdate()
    End Sub

    Private Sub tsShowSavestatesAll_Click(sender As System.Object, e As System.EventArgs) Handles tsShowSavestatesAll.Click
        'Me.ListFiles(mdlFileList.GamesList, ListKeys.Savestates)
    End Sub

    Private Sub tsShowBackupsAll_Click(sender As System.Object, e As System.EventArgs) Handles tsShowBackupsAll.Click
        'Me.ListFiles(mdlFileList.GamesList, ListKeys.Savestates_Backup)
    End Sub

    Private Sub tsShowSavestatesUIList_Click(sender As System.Object, e As System.EventArgs) Handles tsShowSavestatesUIList.Click
        Me.ListBox1.BeginUpdate()
        Me.ListBox1.Items.Clear()
        For Each myFile As FileInfo In mdlMain.currentFiles
            ListBox1.Items.Add(String.Format("{0,-12}|{1,3}|{2,-6}|{3,-36}|{4,12:#,##0.00 MB}|{5,20}|{6}",
                                             mdlFileList.SStates_GetSerial(myFile.Name),
                                             mdlFileList.SStates_GetSlot(myFile.Name).ToString,
                                             mdlFileList.SStates_GetType(myFile.Name).ToString,
                                             myFile.Name,
                                             myFile.Length / 1024 ^ 2,
                                             myFile.LastWriteTime.ToString,
                                             myFile.Attributes.ToString))

        Next
        Me.ListBox1.EndUpdate()
    End Sub

    Private Sub tsShowSavestatesUIListChecked_Click(sender As System.Object, e As System.EventArgs) Handles tsShowSavestatesUIListChecked.Click
        'Me.ListBox1.BeginUpdate()
        'Me.ListBox1.Items.Clear()
        'For Each myFile As FileInfo In mdlMain.checkedFiles
        '    ListBox1.Items.Add(String.Format("{0,-12}|{1,3}|{2,-6}|{3,-36}|{4,12:#,##0.00 MB}|{5,20}|{6}",
        '                                     mdlFileList.SStates_GetSerial(myFile.Name),
        '                                     mdlFileList.SStates_GetSlot(myFile.Name).ToString,
        '                                     mdlFileList.SStates_GetType(myFile.Name).ToString,
        '                                     myFile.Name,
        '                                     myFile.Length / 1024 ^ 2,
        '                                     myFile.LastWriteTime.ToString,
        '                                     myFile.Attributes.ToString))
        'Next
        'Me.ListBox1.EndUpdate()
    End Sub

    'Private Sub ListFiles(ByVal pGameList As Dictionary(Of String, Dictionary(Of mdlFileList.ListKeys, mdlFileList.rFileList)),
    '                      ByVal pFileType As mdlFileList.ListKeys)
    '    Me.ListBox1.BeginUpdate()
    '    Me.ListBox1.Items.Clear()
    '    For Each myGame As KeyValuePair(Of String, Dictionary(Of mdlFileList.ListKeys, mdlFileList.rFileList)) In pGameList
    '        Dim myFileList As New mdlFileList.rFileList
    '        If myGame.Value.TryGetValue(pFileType, myFileList) Then
    '            For Each myFile As KeyValuePair(Of String, FileInfo) In myFileList.InfoList
    '                ListBox1.Items.Add(String.Format("{0,-12}|{1,3}|{2,-6}|{3,-36}|{4,12:#,##0.00 MB}|{5,20}|{6}",
    '                                                 mdlFileList.SStates_GetSerial(myFile.Value.Name),
    '                                                 mdlFileList.SStates_GetSlot(myFile.Value.Name).ToString,
    '                                                 mdlFileList.SStates_GetType(myFile.Value.Name).ToString,
    '                                                 myFile.Value.Name,
    '                                                 myFile.Value.Length / 1024 ^ 2,
    '                                                 myFile.Value.LastWriteTime.ToString,
    '                                                 myFile.Value.Attributes.ToString))
    '            Next
    '        End If
    '    Next
    '    Me.ListBox1.EndUpdate()
    'End Sub
End Class