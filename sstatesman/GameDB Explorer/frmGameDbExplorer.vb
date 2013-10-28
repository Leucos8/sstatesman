'   SStatesMan - a savestate managing tool for PCSX2
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
Public NotInheritable Class frmGameDbExplorer
    Dim CurrentSerial As String = ""
    Dim CurrentGame As New GameInfo With {.Serial = "", .Name = "", .Region = "", .Compat = "0"}
    Dim populationTime As Long


    Friend SearchResultRef As New List(Of String)
    Friend SearchIsActive As Boolean = False

    Private Sub UI_Updater()

        Me.tsListShow.Enabled = False
        Me.tsListShow.Visible = False
        Me.tsCmdSearch.Enabled = False
        Me.tsTxtSearchSerial.Enabled = False
        Me.tsExport.Enabled = False

        Me.txtGameList_Title.Text = ""
        Me.txtGameList_Serial.Text = ""
        Me.txtGameList_Region.Text = ""
        Me.txtGameList_Compat.Text = ""
        Me.imgFlag.Image = My.Resources.Extra_ClearImage_30x20

        Me.ToolStripStatusLabel1.Text = ""
        Me.ToolStripStatusLabel3.Text = ""

        Select Case PCSX2GameDb.Status
            Case LoadStatus.StatusLoadedOK
                Me.CurrentGame = PCSX2GameDb.Extract(Me.CurrentSerial)
                Me.ToolStripStatusLabel2.Text = String.Format("GameDB loaded in {0:N2}ms.", PCSX2GameDb.LoadTime / Stopwatch.Frequency * 1000)
                Me.ToolStripStatusLabel3.Text = String.Format("List created in {0:N2}ms.", Me.populationTime / Stopwatch.Frequency * 1000)
                If Not (SearchIsActive) Then
                    Me.ToolStripStatusLabel1.Text = String.Format("{0} games.", PCSX2GameDb.Records.Count.ToString("N0"))
                Else
                    Select Case Me.SearchResultRef.Count
                        Case Is > 0
                            Me.ToolStripStatusLabel1.Text = String.Format("Found {0:N0} in {1:N0} games.", Me.SearchResultRef.Count, PCSX2GameDb.Records.Count.ToString)
                            Me.tsListShow.Enabled = True
                            Me.tsListShow.Visible = True
                        Case 0
                            Me.ToolStripStatusLabel1.Text = String.Format("No result found in {1:N0} games.", Me.SearchResultRef.Count, PCSX2GameDb.Records.Count.ToString)
                            Me.tsListShow.Enabled = True
                            Me.tsListShow.Visible = True
                    End Select
                End If

                Me.tsCmdSearch.Enabled = True
                Me.tsTxtSearchSerial.Enabled = True
                Me.tsExport.Enabled = True



                Me.txtGameList_Title.Text = CurrentGame.Name
                Me.txtGameList_Serial.Text = CurrentGame.Serial
                Me.txtGameList_Region.Text = CurrentGame.Region
                Me.txtGameList_Compat.Text = CurrentGame.CompatToText
                Me.imgFlag.Image = mdlMain.assignFlag(CurrentGame.Region, CurrentGame.Serial)


            Case LoadStatus.StatusNotLoaded
                Me.ToolStripStatusLabel2.Text = "GameDB not loaded."
            Case LoadStatus.StatusError
                Me.ToolStripStatusLabel2.Text = "Error loading GameDB."
            Case LoadStatus.StatusEmpty
                Me.ToolStripStatusLabel2.Text = "GameDB has no records."
        End Select

        SSMAppLog.Append(eType.LogInformation, eSrc.GameDB_Explorer, eSrcMethod.UI_Update, "Refreshed UI status.")


    End Sub

    Private Sub LoadGameDB(ByVal pPath As String)
        PCSX2GameDb.Load(pPath)

        Me.CurrentSerial = ""
        Me.SearchResultRef.Clear()
        Me.SearchIsActive = False

        Me.PopulateList(PCSX2GameDb.Records)

        Me.UI_Updater()
    End Sub

    Private Sub frmGameDb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.CurrentSerial = ""
        Me.SearchResultRef.Clear()
        Me.SearchIsActive = False

        Me.PopulateList(PCSX2GameDb.Records)

        Me.UI_Updater()
    End Sub

    Private Sub tsGameDbLoad_ButtonClick(sender As System.Object, e As System.EventArgs) Handles tsGameDbLoad.ButtonClick
        Me.tsLoadFromFileTool_Click(sender, e)
    End Sub

    Private Sub tsLoadDefaultGameDB_Click(sender As System.Object, e As System.EventArgs) Handles tsLoadDefaultGameDB.Click
        LoadGameDB(IO.Path.Combine(My.Settings.PCSX2_PathBin, My.Settings.PCSX2_GameDbFilename))
    End Sub

    Private Sub tsLoadFromFileTool_Click(sender As System.Object, e As System.EventArgs) Handles tsLoadFromFileTool.Click
        Using openDialog As New OpenFileDialog
            With openDialog
                .AddExtension = True
                .CheckFileExists = True
                .CheckPathExists = True
                .DefaultExt = ".dbf"
                .Filter = "PCSX2 Game database|*.dbf|Text file|*.txt|All files|*.*"
                .InitialDirectory = My.Settings.PCSX2_PathBin
                .ValidateNames = True
                .FileName = "GameIndex"
            End With
            If openDialog.ShowDialog(Me) = DialogResult.OK Then
                LoadGameDB(openDialog.FileName)
            End If
        End Using
    End Sub

    Private Sub tsListShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsListShow.Click

        Me.SearchResultRef.Clear()
        Me.SearchIsActive = False

        Me.PopulateList(PCSX2GameDb.Records)

        Me.UI_Updater()

    End Sub

    Private Sub tsExportTSVTxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsExportTSVTxt.Click
        Using SaveDialog As New System.Windows.Forms.SaveFileDialog
            With SaveDialog
                .AddExtension = True
                .CheckFileExists = False
                .CheckPathExists = True
                .DefaultExt = ".txt"
                .Filter = "Text file|*.txt|All files|*.*"
                .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                .OverwritePrompt = True
                .ValidateNames = True
            End With

            If Me.SearchResultRef.Count > 0 Then
                With SaveDialog
                    .FileName = "GameDB search results"
                    .Title = "Save found records to..."
                End With
                If SaveDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    Dim GameDbExtract As New Dictionary(Of String, GameInfo)
                    Dim GameDbExtract_ArrayStatus As Byte = LoadStatus.StatusNotLoaded

                    GameDbExtract_ArrayStatus = PCSX2GameDb.Extract(SearchResultRef, GameDbExtract)
                    GameDB.ExportTxt(SaveDialog.FileName, vbTab, GameDbExtract)
                End If
            Else
                With SaveDialog
                    .FileName = "GameDB"
                    .Title = "Save records to..."
                End With
                If SaveDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    PCSX2GameDb.ExportTxt(SaveDialog.FileName, vbTab)
                End If
            End If
        End Using
    End Sub

    Private Sub tsExportCSVTxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsExportCSVTxt.Click
        Using SaveDialog As New System.Windows.Forms.SaveFileDialog
            With SaveDialog
                .AddExtension = True
                .CheckFileExists = False
                .CheckPathExists = True
                .Filter = "Comma-separated value file|*.csv|Text file|*.txt|All files|*.*"
                .DefaultExt = ".csv"
                .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                .OverwritePrompt = True
                .ValidateNames = True
            End With

            If Me.SearchResultRef.Count > 0 Then
                With SaveDialog
                    .FileName = "GameDB search results"
                    .Title = "Save found records list to..."
                End With
                If SaveDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    If SaveDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                        Dim GameDbExtract As New Dictionary(Of String, GameInfo)
                        Dim GameDbExtract_ArrayStatus As Byte = LoadStatus.StatusNotLoaded

                        GameDbExtract_ArrayStatus = PCSX2GameDb.Extract(SearchResultRef, GameDbExtract)
                        GameDB.ExportTxt(SaveDialog.FileName, Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator, GameDbExtract)
                    End If
                End If
            Else
                With SaveDialog
                    .FileName = "GameDB"
                    .Title = "Save records to..."
                End With
                If SaveDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                    PCSX2GameDb.ExportTxt(SaveDialog.FileName, ";")
                End If
            End If
        End Using
    End Sub

    Private Sub tsTxtSearchSerial_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsTxtSearchSerial.GotFocus
        If Me.tsTxtSearchSerial.Text = "Serial" Then
            Me.tsTxtSearchSerial.Text = ""
        End If
    End Sub

    Private Sub tsTxtSearchSerial_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsTxtSearchSerial.LostFocus
        If Me.tsTxtSearchSerial.Text = "" Then
            Me.tsTxtSearchSerial.Text = "Serial"
        End If
    End Sub

    Private Sub lvwGameDBList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvwGameDBList.SelectedIndexChanged
        Try
            If lvwGameDBList.SelectedItems.Count > 0 Then
                Me.CurrentSerial = Me.lvwGameDBList.SelectedItems(0).SubItems(1).Text
                Me.UI_Updater()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub tsCmdSearch_Click(sender As System.Object, e As System.EventArgs) Handles tsCmdSearch.Click
        If frmGDESearch.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Dim SearchGameDb As New Dictionary(Of String, GameInfo)
            PCSX2GameDb.Extract(Me.SearchResultRef, SearchGameDb)
            Me.PopulateList(SearchGameDb)

            Me.UI_Updater()
        End If
    End Sub

    Private Sub PopulateList(ByVal pList As Dictionary(Of String, GameInfo))
        Dim sw As New Stopwatch
        sw.Start()
        Me.lvwGameDBList.Items.Clear()
        Dim myLvwItems As New List(Of ListViewItem)
        For Each myTmpGame As KeyValuePair(Of String, GameInfo) In pList
            Dim myTmpItem As New ListViewItem With {.Text = myTmpGame.Value.Name}
            myTmpItem.SubItems.AddRange({myTmpGame.Key,
                                         myTmpGame.Value.Region,
                                         myTmpGame.Value.CompatToText})
            myLvwItems.Add(myTmpItem)
        Next
        mdlTheme.ListAlternateColors(myLvwItems)
        Me.lvwGameDBList.Items.AddRange(myLvwItems.ToArray)
        sw.Stop()
        Me.populationTime = sw.ElapsedTicks

    End Sub

    Private Sub tsTxtSearchSerial_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles tsTxtSearchSerial.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If Not (Me.tsTxtSearchSerial.Text = "Serial") Then
                Me.tsTxtSearchSerial.Text = Me.tsTxtSearchSerial.Text.ToUpper
                CurrentSerial = Me.tsTxtSearchSerial.Text
                Me.UI_Updater()
            End If
        End If
    End Sub

End Class