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
    Dim WindowSearchActive As System.Boolean = False

    Friend SearchResultRef() As System.Int32
    Friend SearchResultRef_Pos As System.Int32 = 0
    Friend SearchResultRef_Len As System.Int32 = 0

    Private Sub ShowStatus()
        Me.ToolStripStatusLabel1.Text = "GameDB not loaded!"
        Me.ToolStripStatusLabel2.Text = ""

        Me.txtGameList_Title.Text = ""
        Me.txtGameList_Serial.Text = ""
        Me.txtGameList_Region.Text = ""
        Me.txtGameList_Compat.Text = ""
        Me.imgFlag.Image = My.Resources.Flag_0Null_30x20

        Me.tsRecordPrevious.Enabled = False
        Me.tsRecordFirst.Enabled = False
        Me.tsRecordNext.Enabled = False
        Me.tsRecordLast.Enabled = False

        Me.tsGameDbUnload.Enabled = False
        Me.tsListShow.Enabled = False
        Me.tsTxtSearchSerial.Enabled = False
        Me.tsCmdSearchSerial.Enabled = False
        Me.tsExport.Enabled = False
        Me.tsCmdSearch.Enabled = False

        If mdlGameDb.GameDb_Len >= 0 Then

            Me.tsGameDbUnload.Enabled = True
            Me.tsListShow.Enabled = True
            Me.tsCmdSearch.Enabled = True

            Me.tsRecordNext.Enabled = False
            Me.tsRecordLast.Enabled = False
            Me.tsRecordPrevious.Enabled = False
            Me.tsRecordFirst.Enabled = False

            If Me.WindowSearchActive = False Then
                Me.ToolStripStatusLabel1.Text = mdlGameDb.GameDb_Pos.ToString("Position: #,##0")
                Me.ToolStripStatusLabel2.Text = (mdlGameDb.GameDb_Len + 1).ToString("Records: #,##0")

                Me.tsTxtSearchSerial.Enabled = True
                Me.tsCmdSearchSerial.Enabled = True
                Me.tsExport.Enabled = True

                If mdlGameDb.GameDb_Pos > 0 Then
                    Me.tsRecordPrevious.Enabled = True
                    Me.tsRecordFirst.Enabled = True
                End If
                If mdlGameDb.GameDb_Pos < mdlGameDb.GameDb_Len Then
                    Me.tsRecordNext.Enabled = True
                    Me.tsRecordLast.Enabled = True
                End If

                Me.txtGameList_Title.Text = mdlGameDb.GameDb(mdlGameDb.GameDb_Pos).Name
                Me.txtGameList_Serial.Text = mdlGameDb.GameDb(mdlGameDb.GameDb_Pos).Serial
                Me.txtGameList_Region.Text = mdlGameDb.GameDb(mdlGameDb.GameDb_Pos).Region
                Me.txtGameList_Compat.Text = mdlMain.assignCompatText(mdlGameDb.GameDb(mdlGameDb.GameDb_Pos).Compat)
                Me.imgFlag.Image = mdlMain.assignFlag(mdlGameDb.GameDb(mdlGameDb.GameDb_Pos).Region, mdlGameDb.GameDb(mdlGameDb.GameDb_Pos).Serial)
            Else

                Me.ToolStripStatusLabel1.Text = System.String.Format("No result found", (Me.SearchResultRef_Pos))
                Me.ToolStripStatusLabel2.Text = System.String.Format("Found: {0:#,##0}/{1:#,##0}", (Me.SearchResultRef_Len + 1), (mdlGameDb.GameDb_Len + 1))

                If Me.SearchResultRef_Len >= 0 Then

                    Me.ToolStripStatusLabel1.Text = System.String.Format("Position: {0:#,##0}", (Me.SearchResultRef_Pos))

                    mdlGameDb.GameDb_Pos = Me.SearchResultRef(SearchResultRef_Pos)

                    Me.tsExport.Enabled = True

                    If Me.SearchResultRef_Len >= 0 Then
                        If Me.SearchResultRef_Pos > 0 Then
                            Me.tsRecordPrevious.Enabled = True
                            Me.tsRecordFirst.Enabled = True
                        End If
                        If Me.SearchResultRef_Pos < Me.SearchResultRef_Len Then
                            Me.tsRecordNext.Enabled = True
                            Me.tsRecordLast.Enabled = True
                        End If
                    End If
                    Me.txtGameList_Title.Text = mdlGameDb.GameDb(mdlGameDb.GameDb_Pos).Name
                    Me.txtGameList_Serial.Text = mdlGameDb.GameDb(mdlGameDb.GameDb_Pos).Serial
                    Me.txtGameList_Region.Text = mdlGameDb.GameDb(mdlGameDb.GameDb_Pos).Region
                    Me.txtGameList_Compat.Text = mdlMain.assignCompatText(mdlGameDb.GameDb(mdlGameDb.GameDb_Pos).Compat)
                    Me.imgFlag.Image = mdlMain.assignFlag(mdlGameDb.GameDb(mdlGameDb.GameDb_Pos).Region, mdlGameDb.GameDb(mdlGameDb.GameDb_Pos).Serial)

                End If
            End If

        End If
    End Sub

    Private Sub frmGameDb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlGameDb.GameDb_Pos = 0

        Me.ShowStatus()

        Me.lvwGameDBList.SuspendLayout()
        Me.lvwGameDBList.Items.Clear()
        Me.lvwGameDBList.Visible = False

        For mdlGameDb.GameDb_Pos = 0 To GameDb_Len
            Dim ListItemTmp As New System.Windows.Forms.ListViewItem
            ListItemTmp.Text = GameDb(GameDb_Pos).Name
            With ListItemTmp.SubItems
                .Add(GameDb(GameDb_Pos).Serial)
                .Add(GameDb(GameDb_Pos).Region)
                .Add(mdlMain.assignCompatText(GameDb(GameDb_Pos).Compat))
                .Add(GameDb(GameDb_Pos).RStatus.ToString)
                .Add(GameDb_Pos.ToString("#,##0"))
            End With
            ListItemTmp.UseItemStyleForSubItems = False
            ListItemTmp.SubItems(3).BackColor = mdlMain.assignCompatColor(GameDb(GameDb_Pos).Compat, Color.Transparent)
            Me.lvwGameDBList.Items.Add(ListItemTmp)
        Next GameDb_Pos

        mdlGameDb.GameDb_Pos = 0

        Me.lvwGameDBList.ResumeLayout()
        Me.lvwGameDBList.Visible = True
    End Sub

    Private Sub tsGameDbLoad_Click(sender As System.Object, e As System.EventArgs) Handles tsGameDbLoad.Click
        Me.lvwGameDBList.Items.Clear()

        Dim tmp As System.DateTime = Now
        mdlGameDb.GameDb_Len = mdlGameDb.GameDb_Load3(My.Computer.FileSystem.CombinePath(My.Settings.PCSX2_PathBin, My.Settings.PCSX2_GameDbFilename), GameDb, GameDb_Pos)
        Me.ToolStripStatusLabel3.Text = System.String.Concat("Load time: ", Now.Subtract(tmp).TotalMilliseconds.ToString("#,##0 ms"))

        ReDim Me.SearchResultRef(0)
        'SearchResultRef_Pos = 0
        'SearchResultRef_Len = -1
        Me.WindowSearchActive = False

        Me.ShowStatus()
    End Sub

    Private Sub tsGameDbUnload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsGameDbUnload.Click

        If System.Windows.Forms.MessageBox.Show("Warning, unloading the GameDB could lead to undesired effects." & vbCrLf & "Be sure to load it again before closing GameDB util." & vbCrLf & "Do you wish to continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
            Me.lvwGameDBList.Items.Clear()
            mdlGameDb.GameDb_Len = mdlGameDb.GameDb_Unload(GameDb, GameDb_Pos)

            ReDim Me.SearchResultRef(0)
            'SearchResultRef_Pos = 0
            'SearchResultRef_Len = -1
            Me.WindowSearchActive = False
            Me.ShowStatus()
        End If
    End Sub

    Private Sub tsListShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsListShow.Click

        Me.lvwGameDBList.SuspendLayout()
        Me.lvwGameDBList.Items.Clear()
        Me.lvwGameDBList.Visible = False
        Me.WindowSearchActive = False

        For mdlGameDb.GameDb_Pos = 0 To GameDb_Len
            Dim ListItemTmp As New System.Windows.Forms.ListViewItem
            ListItemTmp.Text = mdlGameDb.GameDb(GameDb_Pos).Name
            With ListItemTmp.SubItems
                .Add(mdlGameDb.GameDb(mdlGameDb.GameDb_Pos).Serial)
                .Add(mdlGameDb.GameDb(mdlGameDb.GameDb_Pos).Region)
                .Add(mdlMain.assignCompatText(mdlGameDb.GameDb(mdlGameDb.GameDb_Pos).Compat))
                .Add(mdlGameDb.GameDb(mdlGameDb.GameDb_Pos).RStatus.ToString)
                .Add(mdlGameDb.GameDb_Pos.ToString("#,##0"))
            End With
            ListItemTmp.UseItemStyleForSubItems = False
            ListItemTmp.SubItems(3).BackColor = mdlMain.assignCompatColor(mdlGameDb.GameDb(mdlGameDb.GameDb_Pos).Compat, Color.Transparent)
            Me.lvwGameDBList.Items.Add(ListItemTmp)
        Next mdlGameDb.GameDb_Pos

        mdlGameDb.GameDb_Pos = 0

        Me.lvwGameDBList.ResumeLayout()
        Me.lvwGameDBList.Visible = True

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

        If Me.WindowSearchActive Then
            With SaveDialog
                .FileName = "GameDB search results"
                .Title = "Save found records to..."
            End With
            If SaveDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim GameDbExtract(0) As mdlGameDb.rGameDb
                Dim GameDbExtract_Pos As System.Int32 = 0
                Dim GameDbExtract_Len As System.Int32 = 0

                GameDbExtract_Len = mdlGameDb.GameDb_ExtractByRefs(SearchResultRef, GameDbExtract, GameDbExtract_Pos, mdlGameDb.GameDb, mdlGameDb.GameDb_Pos, mdlGameDb.GameDb_Len)
                Call mdlGameDb.GameDb_ExportTxt(SaveDialog.FileName, _
                                     Microsoft.VisualBasic.vbTab, _
                                     GameDbExtract, _
                                     GameDbExtract_Pos, _
                                     GameDbExtract_Len)
            End If
        Else
            With SaveDialog
                .FileName = "GameDB"
                .Title = "Save records to..."
            End With
            If SaveDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then

                Call mdlGameDb.GameDb_ExportTxt(SaveDialog.FileName, _
                                                 vbTab, _
                                                 GameDb, _
                                                 GameDb_Pos, _
                                                 GameDb_Len)
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

        If Me.WindowSearchActive Then
            With SaveDialog
                .FileName = "GameDB search results"
                .Title = "Save found records list to..."
            End With
            If SaveDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim GameDbExtract(0) As mdlGameDb.rGameDb
                Dim GameDbExtract_Pos As System.Int32 = 0
                Dim GameDbExtract_Len As System.Int32 = 0

                GameDbExtract_Len = mdlGameDb.GameDb_ExtractByRefs(SearchResultRef, GameDbExtract, GameDbExtract_Pos, mdlGameDb.GameDb, mdlGameDb.GameDb_Pos, mdlGameDb.GameDb_Len)
                Call mdlGameDb.GameDb_ExportTxt(SaveDialog.FileName, _
                                     ";", _
                                     GameDbExtract, _
                                     GameDbExtract_Pos, _
                                     GameDbExtract_Len)
            End If
        Else
            With SaveDialog
                .FileName = "GameDB"
                .Title = "Save records to..."
            End With
            If SaveDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Call mdlGameDb.GameDb_ExportTxt(SaveDialog.FileName, _
                                                  ";", _
                                                  GameDb, _
                                                  GameDb_Pos, _
                                                  GameDb_Len)
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
        Dim tmp As mdlGameDb.rGameDb
        If Not (Me.tsTxtSearchSerial.Text = "Serial") Then
            Me.tsTxtSearchSerial.Text = Me.tsTxtSearchSerial.Text.ToUpper
            tmp = mdlGameDb.GameDb_ExtractBySerial(tsTxtSearchSerial.Text, GameDb, GameDb_Pos, GameDb_Len)
            Me.ShowStatus()
            Me.txtGameList_Title.Text = tmp.Name
            Me.txtGameList_Serial.Text = tmp.Serial
            Me.txtGameList_Region.Text = tmp.Region
            Me.txtGameList_Compat.Text = assignCompatText(tmp.Compat)
            Me.imgFlag.Visible = True
            Me.imgFlag.Image = mdlMain.assignFlag(tmp.Region)
        End If
    End Sub


    Private Sub tsRecordFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRecordFirst.Click
        If Me.WindowSearchActive Then
            Me.SearchResultRef_Pos = 0
            mdlGameDb.GameDb_Pos = Me.SearchResultRef(Me.SearchResultRef_Pos)
        Else
            mdlGameDb.GameDb_Pos = 0
        End If
        Me.ShowStatus()
    End Sub

    Private Sub tsRecordPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRecordPrevious.Click
        If Me.WindowSearchActive Then
            If SearchResultRef_Pos > 0 Then
                Me.SearchResultRef_Pos -= 1
                mdlGameDb.GameDb_Pos = SearchResultRef(SearchResultRef_Pos)
            End If
        Else
            If mdlGameDb.GameDb_Pos > 0 Then
                mdlGameDb.GameDb_Pos -= 1
            End If
        End If
        Me.ShowStatus()
    End Sub

    Private Sub tsRecordNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRecordNext.Click
        If Me.WindowSearchActive Then
            If SearchResultRef_Pos < SearchResultRef_Len Then
                Me.SearchResultRef_Pos += 1
                mdlGameDb.GameDb_Pos = SearchResultRef(SearchResultRef_Pos)
            End If
        Else
            If mdlGameDb.GameDb_Pos < mdlGameDb.GameDb_Len Then
                mdlGameDb.GameDb_Pos += 1
            End If
        End If
        Me.ShowStatus()
    End Sub

    Private Sub tsRecordLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRecordLast.Click
        If Me.WindowSearchActive Then
            Me.SearchResultRef_Pos = SearchResultRef_Len
            mdlGameDb.GameDb_Pos = SearchResultRef(SearchResultRef_Pos)
        Else
            mdlGameDb.GameDb_Pos = mdlGameDb.GameDb_Len
        End If
        Me.ShowStatus()
    End Sub

    Private Sub lvwGameDBList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvwGameDBList.SelectedIndexChanged
        Try
            If lvwGameDBList.SelectedItems.Count > 0 Then
                If Me.WindowSearchActive Then
                    Me.SearchResultRef_Pos = CInt(Me.lvwGameDBList.SelectedItems(0).SubItems(5).Text)
                    mdlGameDb.GameDb_Pos = Me.SearchResultRef(Me.SearchResultRef_Pos)
                Else : mdlGameDb.GameDb_Pos = CInt(Me.lvwGameDBList.SelectedItems(0).SubItems(5).Text)
                End If
                Me.ShowStatus()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub tsCmdSearch_Click(sender As System.Object, e As System.EventArgs) Handles tsCmdSearch.Click
        If frmGameDbSearchForm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Me.WindowSearchActive = True
            Me.lvwGameDBList.SuspendLayout()
            Me.lvwGameDBList.Items.Clear()
            Me.lvwGameDBList.Visible = False

            For Me.SearchResultRef_Pos = 0 To Me.SearchResultRef_Len
                Dim ListItemTmp As New System.Windows.Forms.ListViewItem
                ListItemTmp.Text = mdlGameDb.GameDb(Me.SearchResultRef(Me.SearchResultRef_Pos)).Name
                With ListItemTmp.SubItems
                    .Add(mdlGameDb.GameDb(Me.SearchResultRef(Me.SearchResultRef_Pos)).Serial)
                    .Add(mdlGameDb.GameDb(Me.SearchResultRef(Me.SearchResultRef_Pos)).Region)
                    .Add(mdlMain.assignCompatText(mdlGameDb.GameDb(Me.SearchResultRef(Me.SearchResultRef_Pos)).Compat))
                    .Add(mdlGameDb.GameDb(Me.SearchResultRef(Me.SearchResultRef_Pos)).RStatus)
                    .Add(Me.SearchResultRef_Pos.ToString("#,##0"))
                End With
                ListItemTmp.UseItemStyleForSubItems = False
                ListItemTmp.SubItems(3).BackColor = mdlMain.assignCompatColor(mdlGameDb.GameDb(Me.SearchResultRef(Me.SearchResultRef_Pos)).Compat, Color.Transparent)
                Me.lvwGameDBList.Items.Add(ListItemTmp)
            Next Me.SearchResultRef_Pos

            Me.SearchResultRef_Pos = 0
            'mdlGameDb.GameDb_Pos = SearchResultRef(SearchResultRef_Pos)

            Me.lvwGameDBList.ResumeLayout()
            Me.lvwGameDBList.Visible = True

            Me.ShowStatus()
        End If
    End Sub

End Class