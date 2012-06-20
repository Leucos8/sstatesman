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
    Dim CurrentSerial As System.String = ""
    Dim CurrentGame As New GameTitle With {.Serial = "", .Name = "", .Region = "", .Compat = "0"}
    Dim populationTime As System.TimeSpan


    Friend SearchResultRef As New List(Of System.String)
    Friend SearchResultRef_ArrayStatus As LoadStatus = LoadStatus.StatusNotLoaded
    Dim SearchResultRef_Pos As System.String

    Private Sub ShowStatus()

        mdlMain.WriteToConsole("GameDB_Util", "ShowStatus", "Refreshed status")

        'With myGameDbRecord
        '    .Name = ""
        '    .Serial = ""
        '    .Region = ""
        '    .Compat = ""
        '    '.RStatus = rGameDb_RStatus.RStatus0
        'End With

        Me.tsGameDbUnload.Enabled = False
        Me.tsListShow.Enabled = False
        Me.tsListShow.Visible = False
        Me.tsCmdSearch.Enabled = False
        Me.tsTxtSearchSerial.Enabled = False
        Me.tsExport.Enabled = False

        Me.txtGameList_Title.Text = ""
        Me.txtGameList_Serial.Text = ""
        Me.txtGameList_Region.Text = ""
        Me.txtGameList_Compat.Text = ""
        Me.imgFlag.Image = My.Resources.Flag_0Null_30x20

        Me.ToolStripStatusLabel1.Text = ""
        Me.ToolStripStatusLabel3.Text = ""

        Select Case mdlGameDb.GameDb_Status
            Case LoadStatus.StatusLoadedOK
                Me.CurrentGame = mdlGameDb.GameDb_RecordExtract(Me.CurrentSerial, mdlGameDb.GameDb, mdlGameDb.GameDb_Status)
                Me.ToolStripStatusLabel2.Text = System.String.Format("GameDB loaded in {0:N1}ms.", mdlGameDb.GameDb_LoadTime.TotalMilliseconds)
                Me.ToolStripStatusLabel3.Text = System.String.Format("List created in {0:N1}ms.", Me.populationTime.TotalMilliseconds)
                Select Case Me.SearchResultRef_ArrayStatus
                    Case LoadStatus.StatusNotLoaded
                        Me.ToolStripStatusLabel1.Text = System.String.Format("{0} games.", mdlGameDb.GameDb.Count.ToString("N0"))
                    Case LoadStatus.StatusLoadedOK
                        Me.ToolStripStatusLabel1.Text = System.String.Format("Found {0:N0} in {1:N0} games.", Me.SearchResultRef.Count, mdlGameDb.GameDb.Count)
                        Me.tsListShow.Enabled = True
                        Me.tsListShow.Visible = True
                    Case LoadStatus.StatusEmpty
                        Me.ToolStripStatusLabel1.Text = System.String.Format("No result found. {1:N0} games.", Me.SearchResultRef.Count, mdlGameDb.GameDb.Count)
                        Me.tsListShow.Enabled = True
                        Me.tsListShow.Visible = True
                End Select

                Me.tsGameDbUnload.Enabled = True
                'Me.tsListShow.Enabled = True
                Me.tsCmdSearch.Enabled = True
                Me.tsTxtSearchSerial.Enabled = True
                Me.tsExport.Enabled = True



                Me.txtGameList_Title.Text = CurrentGame.Name
                Me.txtGameList_Serial.Text = CurrentGame.Serial
                Me.txtGameList_Region.Text = CurrentGame.Region
                Me.txtGameList_Compat.Text = mdlMain.assignCompatText(CurrentGame.Compat)
                Me.imgFlag.Image = mdlMain.assignFlag(CurrentGame.Region, CurrentGame.Serial)


            Case LoadStatus.StatusNotLoaded
                Me.ToolStripStatusLabel2.Text = "GameDB not loaded."
            Case LoadStatus.StatusError
                Me.ToolStripStatusLabel2.Text = "Error loading GameDB."
            Case LoadStatus.StatusEmpty
                Me.ToolStripStatusLabel2.Text = "GameDB has no records."
        End Select
    End Sub

    Private Sub frmGameDb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.CurrentSerial = ""
        Me.SearchResultRef.Clear()
        Me.SearchResultRef_ArrayStatus = LoadStatus.StatusNotLoaded

        Me.PopulateList(mdlGameDb.GameDb)

        Me.ShowStatus()

    End Sub

    Private Sub tsGameDbLoad_Click(sender As System.Object, e As System.EventArgs) Handles tsGameDbLoad.Click
        mdlGameDb.GameDb_Status = mdlGameDb.GameDb_Load(System.IO.Path.Combine(My.Settings.PCSX2_PathBin, My.Settings.PCSX2_GameDbFilename), GameDb)

        Me.CurrentSerial = ""
        Me.SearchResultRef.Clear()
        Me.SearchResultRef_ArrayStatus = LoadStatus.StatusNotLoaded

        Me.PopulateList(mdlGameDb.GameDb)

        Me.ShowStatus()
    End Sub

    Private Sub tsGameDbUnload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsGameDbUnload.Click

        If System.Windows.Forms.MessageBox.Show("Warning, clearing the GameDB could lead to undesired effects." & System.Environment.NewLine & "Be sure to load it again before closing GameDB util." & System.Environment.NewLine & "Do you wish to continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then
            Me.lvwGameDBList.Items.Clear()

            mdlGameDb.GameDb.Clear()
            mdlGameDb.GameDb_Status = LoadStatus.StatusNotLoaded

            Me.CurrentSerial = ""
            Me.SearchResultRef.Clear()
            Me.SearchResultRef_ArrayStatus = LoadStatus.StatusNotLoaded

            Me.ShowStatus()
        End If

    End Sub

    Private Sub tsListShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsListShow.Click

        Me.SearchResultRef.Clear()
        Me.SearchResultRef_ArrayStatus = LoadStatus.StatusNotLoaded

        Me.PopulateList(mdlGameDb.GameDb)

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

        If Me.SearchResultRef_ArrayStatus = LoadStatus.StatusLoadedOK Then
            With SaveDialog
                .FileName = "GameDB search results"
                .Title = "Save found records to..."
            End With
            If SaveDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim GameDbExtract As New Dictionary(Of System.String, GameTitle)
                Dim GameDbExtract_ArrayStatus As System.Byte = LoadStatus.StatusNotLoaded

                GameDbExtract_ArrayStatus = mdlGameDb.GameDb_RecordExtract(SearchResultRef,
                                                                           mdlGameDb.GameDb,
                                                                           mdlGameDb.GameDb_Status,
                                                                           GameDbExtract)
                Call mdlGameDb.GameDb_ExportTxt(SaveDialog.FileName,
                                                vbTab,
                                                GameDbExtract)
            End If
        Else
            With SaveDialog
                .FileName = "GameDB"
                .Title = "Save records to..."
            End With
            If SaveDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then

                Call mdlGameDb.GameDb_ExportTxt(SaveDialog.FileName,
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

        If Me.SearchResultRef_ArrayStatus = LoadStatus.StatusLoadedOK Then
            With SaveDialog
                .FileName = "GameDB search results"
                .Title = "Save found records list to..."
            End With
            If SaveDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                If SaveDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    Dim GameDbExtract As New Dictionary(Of System.String, GameTitle)
                    Dim GameDbExtract_ArrayStatus As System.Byte = LoadStatus.StatusNotLoaded

                    GameDbExtract_ArrayStatus = mdlGameDb.GameDb_RecordExtract(SearchResultRef,
                                                                               mdlGameDb.GameDb,
                                                                               mdlGameDb.GameDb_Status,
                                                                               GameDbExtract)
                    Call mdlGameDb.GameDb_ExportTxt(SaveDialog.FileName,
                                                    ";",
                                                    GameDbExtract)
                End If
            End If
        Else
            With SaveDialog
                .FileName = "GameDB"
                .Title = "Save records to..."
            End With
            If SaveDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Call mdlGameDb.GameDb_ExportTxt(SaveDialog.FileName,
                                                ";",
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

    Private Sub lvwGameDBList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvwGameDBList.SelectedIndexChanged
        Try
            If lvwGameDBList.SelectedItems.Count > 0 Then
                Me.CurrentSerial = Me.lvwGameDBList.SelectedItems(0).SubItems(1).Text
                Me.ShowStatus()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub tsCmdSearch_Click(sender As System.Object, e As System.EventArgs) Handles tsCmdSearch.Click
        If frmGameDbSearchForm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Dim SearchGameDb As New Dictionary(Of System.String, GameTitle)
            mdlGameDb.GameDb_RecordExtract(Me.SearchResultRef,
                                           mdlGameDb.GameDb,
                                           mdlGameDb.GameDb_Status,
                                           SearchGameDb)
            Me.PopulateList(SearchGameDb)

            Me.ShowStatus()
        End If
    End Sub

    Private Sub PopulateList(ByVal pList As Dictionary(Of System.String, GameTitle))
        Dim startTime As System.DateTime = Now
        Me.lvwGameDBList.Items.Clear()
        Dim myLvwItems As New List(Of System.Windows.Forms.ListViewItem)
        For Each myTmpGame As KeyValuePair(Of System.String, GameTitle) In pList
            Dim myTmpItem As New System.Windows.Forms.ListViewItem With {.Text = myTmpGame.Value.Name}
            myTmpItem.SubItems.AddRange({myTmpGame.Key,
                                         myTmpGame.Value.Region,
                                         mdlMain.assignCompatText(myTmpGame.Value.Compat)})
            myLvwItems.Add(myTmpItem)
        Next
        Me.lvwGameDBList.Items.AddRange(myLvwItems.ToArray)
        Me.populationTime = Now.Subtract(startTime)

    End Sub

    Private Sub tsTxtSearchSerial_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles tsTxtSearchSerial.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If Not (Me.tsTxtSearchSerial.Text = "Serial") Then
                Me.tsTxtSearchSerial.Text = Me.tsTxtSearchSerial.Text.ToUpper
                CurrentSerial = Me.tsTxtSearchSerial.Text
                Me.ShowStatus()
            End If
        End If
    End Sub
End Class