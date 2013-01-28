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
    Dim populationTime As Long

    Private Sub ShowStatus()
        Me.ToolStripStatusLabel1.Text = String.Format("Savestates scanned in {0:N2}ms.", mdlFileList.GameList_LoadTime / Stopwatch.Frequency * 1000)
        Me.ToolStripStatusLabel2.Text = System.String.Format("List created in {0:N2}ms.", Me.populationTime / Stopwatch.Frequency * 1000)
    End Sub

    Private Sub AddHeader(ByVal Type As Byte)
        Me.ListView1.BeginUpdate()
        Me.ListView1.Items.Clear()
        Me.ListView1.Columns.Clear()
        Select Case Type
            Case 0
                Me.ListView1.Columns.AddRange({New ColumnHeader With {.Text = "Game name", .Width = 240},
                                               New ColumnHeader With {.Text = "Serial", .Width = 80},
                                               New ColumnHeader With {.Text = "Region", .Width = 60},
                                               New ColumnHeader With {.Text = "Compat", .Width = 60}
                                              })
            Case 1
                Me.ListView1.Columns.AddRange({New ColumnHeader With {.Text = "Serial", .Width = 80},
                                               New ColumnHeader With {.Text = "File name", .Width = 240},
                                               New ColumnHeader With {.Text = "Slot", .Width = 40, .TextAlign = HorizontalAlignment.Left},
                                               New ColumnHeader With {.Text = "Extension", .Width = 60},
                                               New ColumnHeader With {.Text = "Version", .Width = 80},
                                               New ColumnHeader With {.Text = "Modify Date", .Width = 120},
                                               New ColumnHeader With {.Text = "Size", .Width = 80, .TextAlign = HorizontalAlignment.Right}
                                              })
        End Select
        Me.ListView1.EndUpdate()
    End Sub

    Private Sub tsGamesAll_Click(sender As System.Object, e As System.EventArgs) Handles tsGames.ButtonClick, tsGamesAll.Click
        Dim sw As New Stopwatch
        sw.Start()

        Me.ListView1.BeginUpdate()
        AddHeader(0)

        For Each tmpGamesListKey As String In mdlFileList.GamesList.Keys
            Dim tmpGame As GameInfo = PCSX2GameDb.RecordExtract(tmpGamesListKey)
            Dim tmpListViewItem As New ListViewItem With {.Text = tmpGame.Name, .Name = tmpGame.Serial}
            tmpListViewItem.SubItems.AddRange({tmpGame.Serial, tmpGame.Region, tmpGame.CompatToText})
            If checkedGames.Contains(tmpGame.Serial) Then
                tmpListViewItem.BackColor = Color.FromArgb(130, 150, 200)
            End If
            Me.ListView1.Items.Add(tmpListViewItem)
        Next

        Me.ListView1.EndUpdate()

        sw.Stop()
        Me.populationTime = sw.ElapsedTicks

        ShowStatus()
    End Sub

    Private Sub tsGamesChecked_Click(sender As System.Object, e As System.EventArgs) Handles tsGamesChecked.Click
        Dim sw As New Stopwatch
        sw.Start()

        Me.ListView1.BeginUpdate()
        AddHeader(0)

        For Each tmpChGSerial As String In mdlMain.checkedGames
            Dim tmpGame As GameInfo = PCSX2GameDb.RecordExtract(tmpChGSerial)
            Dim tmpListViewItem As New ListViewItem With {.Text = tmpGame.Name, .Name = tmpGame.Serial, .BackColor = Color.FromArgb(130, 150, 200)}
            tmpListViewItem.SubItems.AddRange({tmpGame.Serial, tmpGame.Region, tmpGame.CompatToText})
            Dim tmpGamesListItem As New mdlFileList.GamesList_Item
            If Not (mdlFileList.GamesList.TryGetValue(tmpGame.Serial, tmpGamesListItem)) Then
                tmpListViewItem.BackColor = Color.FromArgb(255, 255, 192, 192)       'red
            End If
            Me.ListView1.Items.Add(tmpListViewItem)
        Next

        Me.ListView1.EndUpdate()

        sw.Stop()
        Me.populationTime = sw.ElapsedTicks

        ShowStatus()
    End Sub

    Private Sub tsSavestatesAll_Click(sender As System.Object, e As System.EventArgs) Handles tsSavestates.ButtonClick, tsSavestatesAll.Click
        Dim sw As New Stopwatch
        sw.Start()

        Me.ListView1.BeginUpdate()
        AddHeader(1)

        For Each tmpGamesListItem As KeyValuePair(Of String, mdlFileList.GamesList_Item) In mdlFileList.GamesList
            For Each tmpSavestate As KeyValuePair(Of String, mdlFileList.Savestate) In tmpGamesListItem.Value.Savestates
                Dim tmpListViewItem As New ListViewItem With {.Text = tmpSavestate.Value.GetSerial, .Name = tmpSavestate.Value.Name}
                tmpListViewItem.SubItems.AddRange({tmpSavestate.Value.Name, tmpSavestate.Value.Slot, tmpSavestate.Value.Extension, tmpSavestate.Value.Version, tmpSavestate.Value.LastWriteTime.ToString, (tmpSavestate.Value.Length / 1024 ^ 2).ToString("#,##0.00 MB")})
                If checkedGames.Contains(tmpGamesListItem.Key) Then
                    tmpListViewItem.BackColor = Color.FromArgb(215, 220, 255)
                End If
                If checkedSavestates.Contains(tmpSavestate.Value.Name) Then
                    tmpListViewItem.BackColor = Color.FromArgb(130, 150, 200)
                End If
                Me.ListView1.Items.Add(tmpListViewItem)

            Next
        Next

        Me.ListView1.EndUpdate()

        sw.Stop()
        Me.populationTime = sw.ElapsedTicks

        ShowStatus()
    End Sub

    Private Sub tsSavestatesCurrent_Click(sender As System.Object, e As System.EventArgs) Handles tsSavestatesCurrent.Click
        Dim sw As New Stopwatch
        sw.Start()

        Me.ListView1.BeginUpdate()
        AddHeader(1)

        For Each tmpCheckedGame As String In checkedGames
            Dim tmpGame As GamesList_Item = mdlFileList.GamesList(tmpCheckedGame)
            For Each tmpSavestate As KeyValuePair(Of String, Savestate) In tmpGame.Savestates
                Dim tmpListViewItem As New ListViewItem With {.Text = tmpSavestate.Value.GetSerial, .Name = tmpSavestate.Key, .BackColor = Color.FromArgb(215, 220, 255)}
                tmpListViewItem.SubItems.AddRange({tmpSavestate.Key, tmpSavestate.Value.Slot, tmpSavestate.Value.Extension, tmpSavestate.Value.Version, tmpSavestate.Value.LastWriteTime.ToString, (tmpSavestate.Value.Length / 1024 ^ 2).ToString("#,##0.00 MB")})
                If checkedSavestates.Contains(tmpSavestate.Key) Then
                    tmpListViewItem.BackColor = Color.FromArgb(130, 150, 200)
                End If
                Me.ListView1.Items.Add(tmpListViewItem)
            Next
        Next

        Me.ListView1.EndUpdate()

        sw.Stop()
        Me.populationTime = sw.ElapsedTicks

        ShowStatus()
    End Sub

    Private Sub tsSavestatesChecked_Click(sender As System.Object, e As System.EventArgs) Handles tsSavestatesChecked.Click
        Dim sw As New Stopwatch
        sw.Start()

        Me.ListView1.BeginUpdate()
        AddHeader(1)

        For Each tmpSavestateName As String In checkedSavestates
            Dim tmpListViewItem As New ListViewItem With {.Text = Savestate.GetSerial(tmpSavestateName), .Name = tmpSavestateName, .BackColor = Color.FromArgb(130, 150, 200)}
            Dim tmpGamesListItem As New GamesList_Item
            If GamesList.TryGetValue(Savestate.GetSerial(tmpSavestateName), tmpGamesListItem) Then
                Dim tmpSavestate As New Savestate
                If tmpGamesListItem.Savestates.TryGetValue(tmpSavestateName, tmpSavestate) Then
                    tmpListViewItem.SubItems.AddRange({tmpSavestateName, tmpSavestate.Slot, tmpSavestate.Extension, tmpSavestate.Version, tmpSavestate.LastWriteTime.ToString, (tmpSavestate.Length / 1024 ^ 2).ToString("#,##0.00 MB")})
                Else : tmpListViewItem.BackColor = Color.FromArgb(255, 255, 224, 192)   'orange
                End If
            Else : tmpListViewItem.BackColor = Color.FromArgb(255, 255, 192, 192)       'red
            End If
            Me.ListView1.Items.Add(tmpListViewItem)
        Next

        Me.ListView1.EndUpdate()

        sw.Stop()
        Me.populationTime = sw.ElapsedTicks

        ShowStatus()
    End Sub

    Private Sub frmSStateList_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim ico As Icon = Icon.FromHandle(My.Resources.Icon_Tools_16x16.GetHicon())
        Me.Icon = ico
        ShowStatus()
    End Sub

    Private Sub tsSnapsAll_Click(sender As System.Object, e As System.EventArgs) Handles tsSnapsAll.Click, tsSnaps.ButtonClick
        Dim sw As New Stopwatch
        sw.Start()

        Me.ListView1.BeginUpdate()
        AddHeader(1)

        For Each tmpGamesListItem As KeyValuePair(Of String, mdlFileList.GamesList_Item) In mdlFileList.GamesList
            For Each tmpSnaps As KeyValuePair(Of String, Snapshot) In tmpGamesListItem.Value.Snapshots
                Dim tmpListViewItem As New ListViewItem With {.Text = Snapshot.GetSerial(tmpSnaps.Value.Name), .Name = tmpSnaps.Value.Name}
                tmpListViewItem.SubItems.AddRange({tmpSnaps.Key, "", tmpSnaps.Value.Extension, "", tmpSnaps.Value.LastWriteTime.ToString, (tmpSnaps.Value.Length / 1024 ^ 2).ToString("#,##0.00 MB")})
                If checkedGames.Contains(tmpGamesListItem.Key) Then
                    tmpListViewItem.BackColor = Color.FromArgb(215, 220, 255)
                End If
                'If checkedSavestates.Contains(tmpSavestate.Value.Name) Then
                '    tmpListViewItem.BackColor = Color.FromArgb(130, 150, 200)
                'End If
                Me.ListView1.Items.Add(tmpListViewItem)

            Next
        Next

        Me.ListView1.EndUpdate()

        sw.Stop()
        Me.populationTime = sw.ElapsedTicks

        ShowStatus()

    End Sub
End Class