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
Public Class frmGameDb
    'Dim WindowSearchActive As System.Boolean = False
    Dim GameDb_Pos As System.Int32 = 0
    Dim myGameDbRecord As mdlGameDb.rGameDb
    Dim populationTime As System.TimeSpan


    Friend SearchResultRef() As System.Int32
    Friend SearchResultRef_Pos As System.Int32 = 0
    Friend SearchResultRef_ArrayStatus As ArrayStatus = ArrayStatus.ArrayNotLoaded

    Private Sub ShowStatus()

        With Me.myGameDbRecord
            .Name = ""
            .Serial = ""
            .Region = ""
            .Compat = ""
            .RStatus = rGameDb_RStatus.RStatus0
        End With

        Me.tsGameDbUnload.Enabled = False
        Me.tsListShow.Enabled = False
        Me.tsCmdSearch.Enabled = False
        Me.tsTxtSearchSerial.Enabled = False
        Me.tsCmdSearchSerial.Enabled = False
        Me.tsExport.Enabled = False

        Me.tsRecordPrevious.Enabled = False
        Me.tsRecordFirst.Enabled = False
        Me.tsRecordNext.Enabled = False
        Me.tsRecordLast.Enabled = False

        Me.txtGameList_Title.Text = ""
        Me.txtGameList_Serial.Text = ""
        Me.txtGameList_Region.Text = ""
        Me.txtGameList_Compat.Text = ""
        Me.imgFlag.Image = My.Resources.Flag_0Null_30x20

        Me.ToolStripStatusLabel2.Text = ""

        Select Case mdlGameDb.GameDb_ArrayStatus
            Case ArrayStatus.ArrayLoadedOK
                Select Case Me.SearchResultRef_ArrayStatus
                    Case ArrayStatus.ArrayNotLoaded
                        Me.myGameDbRecord = mdlGameDb.GameDb_RecordExtract(Me.GameDb_Pos, mdlGameDb.GameDb)
                        Me.ToolStripStatusLabel1.Text = System.String.Format("Position: {0}", Me.GameDb_Pos.ToString("#,##0"))
                        Me.ToolStripStatusLabel2.Text = System.String.Format("Records: {0}", mdlGameDb.GameDb.GetLength(0).ToString("#,##0"))
                        Me.ToolStripStatusLabel3.Text = System.String.Format("Load time: {0:#,##0}ms (list {1:#,##0}ms)", mdlGameDb.GameDb_LoadTime.TotalMilliseconds, Me.populationTime.TotalMilliseconds)
                        If Me.GameDb_Pos > mdlGameDb.GameDb.GetLowerBound(0) Then
                            Me.tsRecordPrevious.Enabled = True
                            Me.tsRecordFirst.Enabled = True
                        End If
                        If Me.GameDb_Pos < (mdlGameDb.GameDb.GetUpperBound(0)) Then
                            Me.tsRecordNext.Enabled = True
                            Me.tsRecordLast.Enabled = True
                        End If
                    Case ArrayStatus.ArrayLoadedOK
                        Me.GameDb_Pos = Me.SearchResultRef(Me.SearchResultRef_Pos)
                        'Me.GameDb_Pos = mdlGameDb.GameDb_RefExtract(Me.SearchResultRef(Me.SearchResultRef_Pos), mdlGameDb.GameDb)
                        myGameDbRecord = mdlGameDb.GameDb_RecordExtract(Me.GameDb_Pos, mdlGameDb.GameDb)
                        Me.ToolStripStatusLabel1.Text = System.String.Format("Position: {0:#,##0}/{1:#,##0}", Me.SearchResultRef_Pos, Me.GameDb_Pos)
                        Me.ToolStripStatusLabel2.Text = System.String.Format("Found: {0:#,##0}/{1:#,##0}", Me.SearchResultRef.GetLength(0), mdlGameDb.GameDb.GetLength(0))

                        Me.tsListShow.Enabled = True

                        If Me.SearchResultRef_Pos > Me.SearchResultRef.GetLowerBound(0) Then
                            Me.tsRecordPrevious.Enabled = True
                            Me.tsRecordFirst.Enabled = True
                        End If
                        If Me.SearchResultRef_Pos < (Me.SearchResultRef.GetUpperBound(0)) Then
                            Me.tsRecordNext.Enabled = True
                            Me.tsRecordLast.Enabled = True
                        End If
                    Case ArrayStatus.ArrayEmpty
                        Me.ToolStripStatusLabel1.Text = System.String.Format("No result found", (Me.SearchResultRef_Pos))
                        Me.ToolStripStatusLabel2.Text = System.String.Format("Found: {0:#,##0}/{1:#,##0}", Me.SearchResultRef.GetLength(0), mdlGameDb.GameDb.GetLength(0))
                End Select

                Me.tsGameDbUnload.Enabled = True
                'Me.tsListShow.Enabled = True
                Me.tsCmdSearch.Enabled = True
                Me.tsTxtSearchSerial.Enabled = True
                Me.tsCmdSearchSerial.Enabled = True
                Me.tsExport.Enabled = True



                Me.txtGameList_Title.Text = myGameDbRecord.Name
                Me.txtGameList_Serial.Text = myGameDbRecord.Serial
                Me.txtGameList_Region.Text = myGameDbRecord.Region
                Me.txtGameList_Compat.Text = mdlMain.assignCompatText(myGameDbRecord.Compat)
                Me.imgFlag.Image = mdlMain.assignFlag(myGameDbRecord.Region, myGameDbRecord.Serial)


            Case ArrayStatus.ArrayNotLoaded
                Me.ToolStripStatusLabel1.Text = "GameDB not loaded."
            Case ArrayStatus.ErrorOccurred
                Me.ToolStripStatusLabel1.Text = "Error loading GameDB."
            Case ArrayStatus.ArrayEmpty
                Me.ToolStripStatusLabel1.Text = "GameDB has no records."
        End Select
    End Sub

    Private Sub frmGameDb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.tsListShow_Click(Nothing, Nothing)
    End Sub

    Private Sub tsGameDbLoad_Click(sender As System.Object, e As System.EventArgs) Handles tsGameDbLoad.Click

        'If System.Windows.Forms.MessageBox.Show("Warning, re-loading the GameDB could lead to undesired effects." & System.Environment.NewLine & "Do you wish to continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then

        mdlGameDb.GameDb_ArrayStatus = mdlGameDb.GameDb_Load3(System.IO.Path.Combine(My.Settings.PCSX2_PathBin, My.Settings.PCSX2_GameDbFilename), GameDb)

        ReDim Me.SearchResultRef(-1)
        Me.SearchResultRef_ArrayStatus = ArrayStatus.ArrayNotLoaded

        Me.tsListShow_Click(Nothing, Nothing)

        Me.ShowStatus()
        'End If

    End Sub

    Private Sub tsGameDbUnload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsGameDbUnload.Click

        If System.Windows.Forms.MessageBox.Show("Warning, clearing the GameDB could lead to undesired effects." & System.Environment.NewLine & "Be sure to load it again before closing GameDB util." & System.Environment.NewLine & "Do you wish to continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
            Me.lvwGameDBList.Items.Clear()
            mdlGameDb.GameDb_ArrayStatus = mdlGameDb.GameDb_Unload(GameDb)

            ReDim Me.SearchResultRef(-1)
            Me.SearchResultRef_ArrayStatus = ArrayStatus.ArrayNotLoaded

            Me.ShowStatus()
        End If

    End Sub

    Private Sub tsListShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsListShow.Click

        ReDim Me.SearchResultRef(-1)
        Me.SearchResultRef_ArrayStatus = ArrayStatus.ArrayNotLoaded

        Me.lvwGameDBList.BeginUpdate()
        Me.lvwGameDBList.Items.Clear()
        Dim startTime As System.DateTime = Now

        Dim myLvwItems(mdlGameDb.GameDb.GetUpperBound(0)) As System.Windows.Forms.ListViewItem
        For Me.GameDb_Pos = 0 To mdlGameDb.GameDb.GetUpperBound(0)
            Dim myTmpItem As New System.Windows.Forms.ListViewItem(mdlGameDb.GameDb(GameDb_Pos).Name)
            myTmpItem.SubItems.AddRange({mdlGameDb.GameDb(GameDb_Pos).Serial,
                                    mdlGameDb.GameDb(GameDb_Pos).Region,
                                    mdlMain.assignCompatText(mdlGameDb.GameDb(GameDb_Pos).Compat),
                                    mdlGameDb.GameDb(GameDb_Pos).RStatus.ToString,
                                    GameDb_Pos.ToString("#,##0")})
            myLvwItems(GameDb_Pos) = myTmpItem
        Next Me.GameDb_Pos
        Me.lvwGameDBList.Items.AddRange(myLvwItems)

        Me.populationTime = Now.Subtract(startTime)

        Me.GameDb_Pos = 0

        Me.lvwGameDBList.EndUpdate()

        Me.ShowStatus()

    End Sub

    Private Sub tsExportTSVTxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsExportTSVTxt.Click
        Dim SaveDialog As New System.Windows.Forms.SaveFileDialog
        With SaveDialog
            .AddExtension = True
            .CheckFileExists = False
            .CheckPathExists = True
            .DefaultExt = ".txt"
            .InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            .OverwritePrompt = True
            .ValidateNames = True
        End With

        If Me.SearchResultRef_ArrayStatus = ArrayStatus.ArrayLoadedOK Then
            With SaveDialog
                .FileName = "GameDB search results"
                .Title = "Save found records to..."
            End With
            If SaveDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim GameDbExtract(0) As mdlGameDb.rGameDb
                Dim GameDbExtract_ArrayStatus As System.Byte = ArrayStatus.ArrayNotLoaded

                GameDbExtract_ArrayStatus = mdlGameDb.GameDb_RefExtract(SearchResultRef, GameDbExtract, mdlGameDb.GameDb)
                Call mdlGameDb.GameDb_ExportTxt(SaveDialog.FileName, _
                                     Microsoft.VisualBasic.vbTab, _
                                     GameDbExtract)
            End If
        Else
            With SaveDialog
                .FileName = "GameDB"
                .Title = "Save records to..."
            End With
            If SaveDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then

                Call mdlGameDb.GameDb_ExportTxt(SaveDialog.FileName, _
                                                 vbTab, _
                                                 GameDb)
            End If
        End If
        SaveDialog.Dispose()
    End Sub

    Private Sub tsExportCSVTxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsExportCSVTxt.Click
        Dim SaveDialog As New System.Windows.Forms.SaveFileDialog
        With SaveDialog
            .AddExtension = True
            .CheckFileExists = False
            .CheckPathExists = True
            .DefaultExt = ".csv"
            .InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            .OverwritePrompt = True
            .ValidateNames = True
        End With

        If Me.SearchResultRef_ArrayStatus = ArrayStatus.ArrayLoadedOK Then
            With SaveDialog
                .FileName = "GameDB search results"
                .Title = "Save found records list to..."
            End With
            If SaveDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim GameDbExtract(0) As mdlGameDb.rGameDb
                Dim GameDbExtract_ArrayStatus As System.Byte = ArrayStatus.ArrayNotLoaded

                GameDbExtract_ArrayStatus = mdlGameDb.GameDb_RefExtract(SearchResultRef, GameDbExtract, mdlGameDb.GameDb)
                Call mdlGameDb.GameDb_ExportTxt(SaveDialog.FileName, _
                                     ";", _
                                     GameDbExtract)
            End If
        Else
            With SaveDialog
                .FileName = "GameDB"
                .Title = "Save records to..."
            End With
            If SaveDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Call mdlGameDb.GameDb_ExportTxt(SaveDialog.FileName, _
                                                  ";", _
                                                  GameDb)
            End If
        End If
        SaveDialog.Dispose()
    End Sub

    Private Sub tsTxtSearchSerial_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsTxtSearchSerial.GotFocus
        If Me.tsTxtSearchSerial.Text = "Serial" Then
            Me.tsTxtSearchSerial.Text = ""
        End If
    End Sub

    Private Sub tsTxtSearchSerial_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsTxtSearchSerial.LostFocus
        If Me.tsTxtSearchSerial.Text = "" Then
            Me.tsTxtSearchSerial.Text = "Serial"
        End If
    End Sub

    Private Sub tsCmdSearchSerial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsCmdSearchSerial.Click
        If Not (Me.tsTxtSearchSerial.Text = "Serial") Then
            Me.tsTxtSearchSerial.Text = Me.tsTxtSearchSerial.Text.ToUpper
            GameDb_Pos = mdlGameDb.GameDb_RefExtract(tsTxtSearchSerial.Text, mdlGameDb.GameDb)
            Me.ShowStatus()
        End If
    End Sub


    Private Sub tsRecordFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRecordFirst.Click
        If Me.SearchResultRef_ArrayStatus = ArrayStatus.ArrayLoadedOK Then
            Me.SearchResultRef_Pos = 0
            GameDb_Pos = Me.SearchResultRef(Me.SearchResultRef_Pos)
        ElseIf mdlGameDb.GameDb_ArrayStatus = ArrayStatus.ArrayLoadedOK Then
            GameDb_Pos = 0
        End If
        Me.ShowStatus()
    End Sub

    Private Sub tsRecordPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRecordPrevious.Click
        If Me.SearchResultRef_ArrayStatus = ArrayStatus.ArrayLoadedOK Then
            If SearchResultRef_Pos > 0 Then
                Me.SearchResultRef_Pos -= 1
                GameDb_Pos = SearchResultRef(SearchResultRef_Pos)
            End If
        ElseIf mdlGameDb.GameDb_ArrayStatus = ArrayStatus.ArrayLoadedOK Then
            If GameDb_Pos > 0 Then
                GameDb_Pos -= 1
            End If
        End If
        Me.ShowStatus()
    End Sub

    Private Sub tsRecordNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRecordNext.Click
        If Me.SearchResultRef_ArrayStatus = ArrayStatus.ArrayLoadedOK Then
            If SearchResultRef_Pos < SearchResultRef.GetUpperBound(0) Then
                Me.SearchResultRef_Pos += 1
                GameDb_Pos = SearchResultRef(SearchResultRef_Pos)
            End If
        ElseIf mdlGameDb.GameDb_ArrayStatus = ArrayStatus.ArrayLoadedOK Then
            If GameDb_Pos < mdlGameDb.GameDb.GetUpperBound(0) Then
                GameDb_Pos += 1
            End If
        End If
        Me.ShowStatus()
    End Sub

    Private Sub tsRecordLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRecordLast.Click
        If Me.SearchResultRef_ArrayStatus = ArrayStatus.ArrayLoadedOK Then
            Me.SearchResultRef_Pos = SearchResultRef.GetUpperBound(0)
            GameDb_Pos = SearchResultRef(SearchResultRef_Pos)
        ElseIf mdlGameDb.GameDb_ArrayStatus = ArrayStatus.ArrayLoadedOK Then
            GameDb_Pos = mdlGameDb.GameDb.GetUpperBound(0)
        End If
        Me.ShowStatus()
    End Sub

    Private Sub lvwGameDBList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvwGameDBList.SelectedIndexChanged
        Try
            If lvwGameDBList.SelectedItems.Count > 0 Then
                If Me.SearchResultRef_ArrayStatus = ArrayStatus.ArrayLoadedOK Then
                    Me.SearchResultRef_Pos = Me.lvwGameDBList.SelectedItems(0).Index
                    'GameDb_Pos = Me.SearchResultRef(Me.SearchResultRef_Pos)
                ElseIf mdlGameDb.GameDb_ArrayStatus = ArrayStatus.ArrayLoadedOK Then
                    GameDb_Pos = Me.lvwGameDBList.SelectedItems(0).Index
                End If
                Me.ShowStatus()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub tsCmdSearch_Click(sender As System.Object, e As System.EventArgs) Handles tsCmdSearch.Click
        If frmGameDbSearchForm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Me.lvwGameDBList.BeginUpdate()
            Me.lvwGameDBList.Items.Clear()

            For Me.SearchResultRef_Pos = 0 To Me.SearchResultRef.GetUpperBound(0)
                Dim ListItemTmp As New System.Windows.Forms.ListViewItem
                ListItemTmp.Text = mdlGameDb.GameDb(Me.SearchResultRef(Me.SearchResultRef_Pos)).Name
                With ListItemTmp.SubItems
                    .Add(mdlGameDb.GameDb(Me.SearchResultRef(Me.SearchResultRef_Pos)).Serial)
                    .Add(mdlGameDb.GameDb(Me.SearchResultRef(Me.SearchResultRef_Pos)).Region)
                    .Add(mdlMain.assignCompatText(mdlGameDb.GameDb(Me.SearchResultRef(Me.SearchResultRef_Pos)).Compat))
                    .Add(mdlGameDb.GameDb(Me.SearchResultRef(Me.SearchResultRef_Pos)).RStatus.ToString)
                    .Add(Me.SearchResultRef_Pos.ToString("#,##0"))
                End With
                ListItemTmp.UseItemStyleForSubItems = False
                ListItemTmp.SubItems(3).BackColor = mdlMain.assignCompatColor(mdlGameDb.GameDb(Me.SearchResultRef(Me.SearchResultRef_Pos)).Compat, Color.Transparent)
                Me.lvwGameDBList.Items.Add(ListItemTmp)
            Next Me.SearchResultRef_Pos

            Me.SearchResultRef_Pos = 0
            'mdlGameDb.GameDb_Pos = SearchResultRef(SearchResultRef_Pos)

            Me.lvwGameDBList.EndUpdate()

            Me.ShowStatus()
        End If
    End Sub

End Class