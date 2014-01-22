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
Imports System.IO

Public Class frmSStateList
    Dim populationTime As Long = 0
    Private Enum DTListMode
        Games
        Savestates
        Stored
        Snapshots
        CoverCache
    End Enum
    Dim CurrentListMode As DTListMode = DTListMode.Games

    Private Sub frmSStateList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ico As Icon = Icon.FromHandle(My.Resources.Icon_Tools.GetHicon())
        Me.Icon = ico
        'ShowStatus()
        Me.ToolStripStatusLabel1.Text = String.Format("GameDB loaded in {0:N2}ms.", PCSX2GameDb.LoadTime / Stopwatch.Frequency * 1000)
        Me.ToolStripStatusLabel2.Text = String.Format("Files scanned in {0:N2}ms.", SSMGameList.LoadTime / Stopwatch.Frequency * 1000)
        Me.ToolStripStatusLabel3.Text = ""
    End Sub

    Private Sub ShowStatus()
        Me.ToolStripStatusLabel1.Text = String.Format("Showing {0}.", Me.CurrentListMode)
        Me.ToolStripStatusLabel3.Text = System.String.Format("List created in {0:N2}ms.", Me.populationTime / Stopwatch.Frequency * 1000)
    End Sub

    Private Sub AddHeader()
        Me.lvwDT.BeginUpdate()
        Me.lvwDT.Items.Clear()
        Me.lvwDT.Columns.Clear()
        Select Case Me.CurrentListMode
            Case DTListMode.Games
                Me.lvwDT.Columns.AddRange({New ColumnHeader With {.Text = "Game name", .Width = 220},
                                               New ColumnHeader With {.Text = "Serial", .Width = 80},
                                               New ColumnHeader With {.Text = "Region", .Width = 60},
                                               New ColumnHeader With {.Text = "Compat", .Width = 60},
                                               New ColumnHeader With {.Text = "CRC", .Width = 80},
                                               New ColumnHeader With {.Text = "Cover", .Width = 40},
                                               New ColumnHeader With {.Text = "Savestates", .Width = 40},
                                               New ColumnHeader With {.Text = "Stored", .Width = 40},
                                               New ColumnHeader With {.Text = "Snapshots", .Width = 40}
                                              })
            Case DTListMode.Savestates, DTListMode.Stored, DTListMode.Snapshots
                Me.lvwDT.Columns.AddRange({New ColumnHeader With {.Text = "Serial", .Width = 80},
                                               New ColumnHeader With {.Text = "File name", .Width = 220},
                                               New ColumnHeader With {.Text = "Number", .Width = 40, .TextAlign = HorizontalAlignment.Left},
                                               New ColumnHeader With {.Text = "Extension", .Width = 60},
                                               New ColumnHeader With {.Text = "ExtraInfo", .Width = 120},
                                               New ColumnHeader With {.Text = "Modify Date", .Width = 120},
                                               New ColumnHeader With {.Text = "Size", .Width = 80, .TextAlign = HorizontalAlignment.Right}
                                              })
            Case DTListMode.CoverCache
                Me.lvwDT.Columns.AddRange({New ColumnHeader With {.Text = "Serial", .Width = 80},
                                               New ColumnHeader With {.Text = "Game name", .Width = 220},
                                               New ColumnHeader With {.Text = "Cover", .Width = 60},
                                               New ColumnHeader With {.Text = "Cached", .Width = 60},
                                               New ColumnHeader With {.Text = "Cache last hit", .Width = 120}
                                              })
        End Select
        Me.lvwDT.EndUpdate()
    End Sub

#Region "Games"
    Private Sub tsGamesAll_Click(sender As Object, e As EventArgs) Handles tsGames.ButtonClick, tsGamesAll.Click
        Dim sw As New Stopwatch
        sw.Start()

        Dim tmpTotals() As Long = {0, 0}

        Me.lvwDT.BeginUpdate()
        Me.CurrentListMode = DTListMode.Games
        AddHeader()

        For Each tmpGamesListKey As String In SSMGameList.Games.Keys
            Dim tmpGame As GameInfo = PCSX2GameDb.Extract(tmpGamesListKey)
            Dim tmpListViewItem As New ListViewItem With {.Text = tmpGame.Name, .Name = tmpGame.Serial}
            tmpListViewItem.SubItems.AddRange({tmpGame.Serial, tmpGame.Region, tmpGame.CompatToText, _
                                               SSMGameList.Games(tmpGamesListKey).GameCRC, _
                                               SSMGameList.Games(tmpGamesListKey).HasCoverFile(My.Settings.SStatesMan_PathPics, tmpGamesListKey).ToString, _
                                               SSMGameList.Games(tmpGamesListKey).GameFiles.ContainsKey(ListMode.Savestates).ToString, _
                                               SSMGameList.Games(tmpGamesListKey).GameFiles.ContainsKey(ListMode.Stored).ToString, _
                                               SSMGameList.Games(tmpGamesListKey).GameFiles.ContainsKey(ListMode.Snapshots).ToString})
            If frmMain.checkedGames.Contains(tmpGame.Serial) Then
                tmpListViewItem.BackColor = mdlTheme.currentTheme.AccentColor
                tmpTotals(1) += 1
            End If
            Me.lvwDT.Items.Add(tmpListViewItem)
            tmpTotals(0) += 1
        Next

        Me.lvwDT.EndUpdate()

        sw.Stop()
        Me.populationTime = sw.ElapsedTicks
        Me.ToolStripStatusLabel2.Text = String.Format("{0:N0} total, {1:N0} checked.", tmpTotals(0), tmpTotals(1))
        ShowStatus()
    End Sub

    Private Sub tsGamesChecked_Click(sender As Object, e As EventArgs) Handles tsGamesChecked.Click
        Dim sw As New Stopwatch
        sw.Start()
        Dim tmpTotals() As Long = {0, 0}

        Me.lvwDT.BeginUpdate()
        Me.CurrentListMode = DTListMode.Games
        AddHeader()

        For Each tmpCheckedSerial As String In frmMain.checkedGames
            Dim tmpGame As GameInfo = PCSX2GameDb.Extract(tmpCheckedSerial)
            Dim tmpListViewItem As New ListViewItem With {.Text = tmpGame.Name, .Name = tmpGame.Serial, .BackColor = mdlTheme.currentTheme.AccentColor}
            tmpListViewItem.SubItems.AddRange({tmpGame.Serial, tmpGame.Region, tmpGame.CompatToText})
            Dim tmpGamesListItem As New mdlFileList.GameListItem
            If SSMGameList.Games.TryGetValue(tmpGame.Serial, tmpGamesListItem) Then
                tmpListViewItem.SubItems.AddRange({SSMGameList.Games(tmpCheckedSerial).GameCRC, _
                                                   SSMGameList.Games(tmpCheckedSerial).HasCoverFile(My.Settings.SStatesMan_PathPics, tmpCheckedSerial).ToString, _
                                                   SSMGameList.Games(tmpCheckedSerial).GameFiles.ContainsKey(ListMode.Savestates).ToString, _
                                                   SSMGameList.Games(tmpCheckedSerial).GameFiles.ContainsKey(ListMode.Stored).ToString, _
                                                   SSMGameList.Games(tmpCheckedSerial).GameFiles.ContainsKey(ListMode.Snapshots).ToString})
            Else
                tmpListViewItem.BackColor = Color.FromArgb(255, 255, 192, 192)       'red
                tmpTotals(1) += 1
            End If
            Me.lvwDT.Items.Add(tmpListViewItem)
            tmpTotals(0) += 1
        Next

        Me.lvwDT.EndUpdate()

        sw.Stop()
        Me.populationTime = sw.ElapsedTicks
        Me.ToolStripStatusLabel2.Text = String.Format("{0:N0} total, {1:N0} not found.", tmpTotals(0), tmpTotals(1))
        ShowStatus()
    End Sub
#End Region

#Region "File List"
    Private Sub Files_ListAll(pDTListMode As DTListMode, pFileListMode As ListMode)
        Dim sw As New Stopwatch
        sw.Start()
        Dim tmpTotals() As Long = {0, 0, 0}

        Me.lvwDT.BeginUpdate()
        Me.CurrentListMode = pDTListMode
        AddHeader()

        For Each tmpGamesListItem As KeyValuePair(Of String, mdlFileList.GameListItem) In SSMGameList.Games
            If tmpGamesListItem.Value.GameFiles.ContainsKey(pFileListMode) Then
                For Each tmpFile As KeyValuePair(Of String, PCSX2File) In tmpGamesListItem.Value.GameFiles(pFileListMode).Files
                    Dim tmpListViewItem As New ListViewItem With {.Text = tmpFile.Value.GetGameSerial, .Name = tmpFile.Value.Name}
                    tmpListViewItem.SubItems.AddRange({tmpFile.Value.Name, tmpFile.Value.Number.ToString, tmpFile.Value.Extension, tmpFile.Value.ExtraInfo, tmpFile.Value.LastWriteTime.ToString, (tmpFile.Value.Length / 1024 ^ 2).ToString("#,##0.00 MB")})
                    If frmMain.checkedGames.Contains(tmpGamesListItem.Key) Then
                        tmpListViewItem.BackColor = mdlTheme.currentTheme.AccentColorLight
                        tmpTotals(1) += 1
                    End If
                    If frmMain.checkedFiles(frmMain.currentListMode).Contains(tmpFile.Value.Name) Then
                        tmpListViewItem.BackColor = mdlTheme.currentTheme.AccentColor
                        tmpTotals(2) += 1
                    End If
                    Me.lvwDT.Items.Add(tmpListViewItem)
                    tmpTotals(0) += 1
                Next
            End If
        Next

        Me.lvwDT.EndUpdate()

        sw.Stop()
        Me.populationTime = sw.ElapsedTicks
        Me.ToolStripStatusLabel2.Text = String.Format("{0:N0} total, {1:N0} displayed, {2:N0} checked.", tmpTotals(0), tmpTotals(1), tmpTotals(2))
        ShowStatus()
    End Sub

    Private Sub Files_ListCurrent(pDTListMode As DTListMode, pFileListMode As ListMode)
        Dim sw As New Stopwatch
        sw.Start()
        Dim tmpTotals() As Long = {0, 0}

        Me.lvwDT.BeginUpdate()
        Me.CurrentListMode = pDTListMode
        AddHeader()

        For Each tmpCheckedGame As String In frmMain.checkedGames
            Dim tmpGame As New GameListItem
            If SSMGameList.Games.TryGetValue(tmpCheckedGame, tmpGame) Then
                If tmpGame.GameFiles.ContainsKey(pFileListMode) Then
                    For Each tmpSavestate As KeyValuePair(Of String, PCSX2File) In tmpGame.GameFiles(pFileListMode).Files
                        Dim tmpListViewItem As New ListViewItem With {.Text = tmpSavestate.Value.GetGameSerial, .Name = tmpSavestate.Key, .BackColor = mdlTheme.currentTheme.AccentColorLight}
                        tmpListViewItem.SubItems.AddRange({tmpSavestate.Key, tmpSavestate.Value.Number.ToString, tmpSavestate.Value.Extension, tmpSavestate.Value.ExtraInfo, tmpSavestate.Value.LastWriteTime.ToString, (tmpSavestate.Value.Length / 1024 ^ 2).ToString("#,##0.00 MB")})
                        If frmMain.checkedFiles(frmMain.currentListMode).Contains(tmpSavestate.Key) Then
                            tmpListViewItem.BackColor = mdlTheme.currentTheme.AccentColor
                            tmpTotals(1) += 1
                        End If
                        Me.lvwDT.Items.Add(tmpListViewItem)
                        tmpTotals(0) += 1
                    Next
                End If
            End If
        Next

        Me.lvwDT.EndUpdate()

        sw.Stop()
        Me.populationTime = sw.ElapsedTicks
        Me.ToolStripStatusLabel2.Text = String.Format("{0:N0} displayed, {1:N0} checked.", tmpTotals(0), tmpTotals(1))
        ShowStatus()
    End Sub

    Private Sub Files_ListChecked(pDTListMode As DTListMode, pFileListMode As ListMode)
        Dim sw As New Stopwatch
        sw.Start()
        Dim tmpTotals() As Long = {0, 0}

        Me.lvwDT.BeginUpdate()
        Me.CurrentListMode = pDTListMode
        AddHeader()

        For Each tmpSavestateName As String In frmMain.checkedFiles(frmMain.currentListMode)
            Dim tmpListViewItem As New ListViewItem With {.Text = Savestate.GetGameSerial(tmpSavestateName), .Name = tmpSavestateName, .BackColor = mdlTheme.currentTheme.AccentColor}
            Dim tmpGamesListItem As New GameListItem
            If SSMGameList.Games.TryGetValue(Savestate.GetGameSerial(tmpSavestateName), tmpGamesListItem) AndAlso tmpGamesListItem.GameFiles.ContainsKey(pFileListMode) Then
                If tmpGamesListItem.GameFiles(pFileListMode).Files.ContainsKey(tmpSavestateName) Then
                    Dim tmpSavestate As PCSX2File = tmpGamesListItem.GameFiles(pFileListMode).Files(tmpSavestateName)
                    tmpListViewItem.SubItems.AddRange({tmpSavestateName, tmpSavestate.Number.ToString, tmpSavestate.Extension, tmpSavestate.ExtraInfo, tmpSavestate.LastWriteTime.ToString, (tmpSavestate.Length / 1024 ^ 2).ToString("#,##0.00 MB")})
                Else
                    tmpListViewItem.BackColor = Color.FromArgb(255, 255, 224, 192)   'orange
                    tmpTotals(1) += 1
                End If
            Else
                tmpListViewItem.BackColor = Color.FromArgb(255, 255, 192, 192)       'red
                tmpTotals(1) += 1
            End If
            Me.lvwDT.Items.Add(tmpListViewItem)
            tmpTotals(0) += 1
        Next

        Me.lvwDT.EndUpdate()

        sw.Stop()
        Me.populationTime = sw.ElapsedTicks
        Me.ToolStripStatusLabel2.Text = String.Format("{0:N0} checked, {1:N0} not found.", tmpTotals(0), tmpTotals(1))
        ShowStatus()
    End Sub
#End Region

#Region "Savestates buttons"
    Private Sub tsSavestatesAll_Click(sender As Object, e As EventArgs) Handles tsSavestates.ButtonClick, tsSavestatesAll.Click
        Me.Files_ListAll(DTListMode.Savestates, ListMode.Savestates)
    End Sub

    Private Sub tsSavestatesCurrent_Click(sender As Object, e As EventArgs) Handles tsSavestatesCurrent.Click
        Me.Files_ListCurrent(DTListMode.Savestates, ListMode.Savestates)
    End Sub

    Private Sub tsSavestatesChecked_Click(sender As Object, e As EventArgs) Handles tsSavestatesChecked.Click
        Me.Files_ListChecked(DTListMode.Savestates, ListMode.Savestates)
    End Sub
#End Region

#Region "Stored buttons"
    Private Sub tsStoredAll_Click(sender As Object, e As EventArgs) Handles tsStored.ButtonClick, tsStoredAll.Click
        Me.Files_ListAll(DTListMode.Stored, ListMode.Stored)
    End Sub

    Private Sub tsStoredCurrent_Click(sender As Object, e As EventArgs) Handles tsStoredCurrent.Click
        Me.Files_ListCurrent(DTListMode.Stored, ListMode.Stored)
    End Sub

    Private Sub tsStoredChecked_Click(sender As Object, e As EventArgs) Handles tsStoredChecked.Click
        Me.Files_ListChecked(DTListMode.Stored, ListMode.Stored)
    End Sub
#End Region

#Region "Snapshots button"
    Private Sub tsSnapsAll_Click(sender As Object, e As EventArgs) Handles tsSnapsAll.Click, tsSnaps.ButtonClick
        Me.Files_ListAll(DTListMode.Snapshots, ListMode.Snapshots)
    End Sub

    Private Sub tsSnapsCurrent_Click(sender As Object, e As EventArgs) Handles tsSnapsCurrent.Click
        Me.Files_ListCurrent(DTListMode.Snapshots, ListMode.Snapshots)
    End Sub

    Private Sub tsSnapsSelected_Click(sender As Object, e As EventArgs) Handles tsSnapsSelected.Click
        Me.Files_ListChecked(DTListMode.Snapshots, ListMode.Snapshots)
    End Sub
#End Region

    Private Sub tsCoverCache_Click(sender As Object, e As EventArgs) Handles tsCoverCache.Click
        Dim sw As New Stopwatch
        sw.Start()
        Dim tmpTotals() As Long = {0, 0}

        Me.lvwDT.BeginUpdate()
        Me.CurrentListMode = DTListMode.CoverCache
        AddHeader()

        If CoverCache.ContainsKey("*nocover*") Then
            Me.lvwDT.Items.Add(New ListViewItem With {.Text = "*nocover*", .Name = "*nocover*"})
            Me.lvwDT.Items("*nocover*").SubItems.AddRange({"For games that have no cover file", "False", "True", CoverCache("*nocover*").LastHit.ToString})
            tmpTotals(0) += 1
            tmpTotals(1) += 1
        End If

        If CoverCache.ContainsKey("screenshot") Then
            Me.lvwDT.Items.Add(New ListViewItem With {.Text = "screenshot", .Name = "screenshot"})
            Me.lvwDT.Items("screenshot").SubItems.AddRange({"Screnshot cover image", "True", "True", CoverCache("screenshot").LastHit.ToString})
            tmpTotals(0) += 1
            tmpTotals(1) += 1
        End If

        For Each tmpGame As KeyValuePair(Of String, GameListItem) In SSMGameList.Games
            Dim tmpListViewItem As New ListViewItem With {.Text = tmpGame.Key, .Name = tmpGame.Key}
            tmpListViewItem.SubItems.AddRange({PCSX2GameDb.Extract(tmpGame.Key).Name, tmpGame.Value.HasCoverFile(My.Settings.SStatesMan_PathPics, tmpGame.Key).ToString})
            If CoverCache.ContainsKey(tmpGame.Key) Then
                tmpListViewItem.SubItems.AddRange({"True", CoverCache(tmpGame.Key).LastHit.ToString})
                tmpListViewItem.BackColor = currentTheme.AccentColor
                tmpTotals(1) += 1
            Else
                tmpListViewItem.SubItems.AddRange({"False", ""})
            End If
            Me.lvwDT.Items.Add(tmpListViewItem)
            tmpTotals(0) += 1
        Next

        Me.lvwDT.EndUpdate()
        Me.ToolStripStatusLabel2.Text = String.Format("{0:N0} total, {1:N0}/8 cached.", tmpTotals(0), tmpTotals(1))
        sw.Stop()
        Me.populationTime = sw.ElapsedTicks
        Me.ShowStatus()
    End Sub
End Class