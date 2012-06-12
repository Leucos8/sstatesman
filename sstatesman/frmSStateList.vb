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
    Private Sub ShowStatus()

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
                Me.ListView1.Columns.AddRange({New ColumnHeader With {.Text = "File name", .Width = 240},
                                               New ColumnHeader With {.Text = "Slot", .Width = 40, .TextAlign = HorizontalAlignment.Left},
                                               New ColumnHeader With {.Text = "Extension", .Width = 60},
                                               New ColumnHeader With {.Text = "Version", .Width = 80},
                                               New ColumnHeader With {.Text = "Modify Date", .Width = 120},
                                               New ColumnHeader With {.Text = "Size", .Width = 80, .TextAlign = HorizontalAlignment.Right}
                                              })
        End Select
        Me.ListView1.EndUpdate()
    End Sub

    Private Sub tsShowGameList_Click(sender As System.Object, e As System.EventArgs) Handles tsShowGameList.Click
        Me.ListView1.BeginUpdate()
        AddHeader(0)
        For Each tmpGamesListKey As String In mdlFileList.GamesList.Keys
            Dim tmpGame As GameTitle = mdlGameDb.GameDb_RecordExtract(tmpGamesListKey, mdlGameDb.GameDb, mdlGameDb.GameDb_Status)
            Dim tmpListViewItem As New ListViewItem With {.Text = tmpGame.Name, .ImageKey = tmpGame.Serial}
            tmpListViewItem.SubItems.AddRange({tmpGame.Serial, tmpGame.Region, mdlMain.assignCompatText(tmpGame.Compat)})
            If checkedGames.Contains(tmpGame.Serial) Then
                tmpListViewItem.BackColor = Color.FromArgb(130, 150, 200)
            End If
            Me.ListView1.Items.Add(tmpListViewItem)
        Next
        Me.ListView1.EndUpdate()
    End Sub

    Private Sub tsShowGameChecked_Click(sender As System.Object, e As System.EventArgs) Handles tsShowGameChecked.Click
        Me.ListView1.BeginUpdate()
        AddHeader(0)
        For Each tmpChGSerial As String In mdlMain.checkedGames
            Dim tmpGame As GameTitle = mdlGameDb.GameDb_RecordExtract(tmpChGSerial, mdlGameDb.GameDb, mdlGameDb.GameDb_Status)
            Dim tmpListViewItem As New ListViewItem With {.Text = tmpGame.Name, .ImageKey = tmpGame.Serial}
            tmpListViewItem.SubItems.AddRange({tmpGame.Serial, tmpGame.Region, mdlMain.assignCompatText(tmpGame.Compat)})
            Dim tmpGamesListItem As New mdlFileList.GamesList_Item
            If Not (mdlFileList.GamesList.TryGetValue(tmpGame.Serial, tmpGamesListItem)) Then
                tmpListViewItem.BackColor = Color.FromArgb(255, 255, 192, 192)       'red
            End If
            Me.ListView1.Items.Add(tmpListViewItem)
        Next
        Me.ListView1.EndUpdate()
    End Sub

    Private Sub tsShowSavestatesAll_Click(sender As System.Object, e As System.EventArgs) Handles tsShowSavestatesAll.Click
        Me.ListView1.BeginUpdate()
        AddHeader(1)
        For Each tmpGamesListItem As KeyValuePair(Of String, mdlFileList.GamesList_Item) In mdlFileList.GamesList
            For Each tmpSavestate As KeyValuePair(Of String, mdlFileList.Savestate) In tmpGamesListItem.Value.Savestates
                Dim tmpListViewItem As New ListViewItem With {.Text = tmpSavestate.Value.Name, .ImageKey = tmpSavestate.Value.Name}
                tmpListViewItem.SubItems.AddRange({tmpSavestate.Value.Slot, tmpSavestate.Value.Extension, tmpSavestate.Value.Version, tmpSavestate.Value.LastWriteTime, (tmpSavestate.Value.Lenght / 1024 ^ 2).ToString("#,##0.00 MB")})
                If currentFiles.Contains(tmpSavestate.Value.Name) Then
                    tmpListViewItem.BackColor = Color.FromArgb(215, 220, 255)
                ElseIf checkedFiles.Contains(tmpSavestate.Value.Name) Then
                    tmpListViewItem.BackColor = Color.FromArgb(130, 150, 200)
                End If
                Me.ListView1.Items.Add(tmpListViewItem)

            Next
        Next
        Me.ListView1.EndUpdate()
    End Sub

    Private Sub tsShowSavestatesCurrent_Click(sender As System.Object, e As System.EventArgs) Handles tsShowSavestatesCurrent.Click
        Me.ListView1.BeginUpdate()
        AddHeader(1)
        For Each tmpSavestateName As String In currentFiles
            Dim tmpListViewItem As New ListViewItem With {.Text = tmpSavestateName, .ImageKey = tmpSavestateName}
            Dim tmpGamesListItem As New GamesList_Item
            If checkedFiles.Contains(tmpSavestateName) Then
                tmpListViewItem.BackColor = Color.FromArgb(130, 150, 200)
            End If
            If GamesList.TryGetValue(mdlFileList.SStates_GetSerial(tmpSavestateName), tmpGamesListItem) Then
                Dim tmpSavestate As New Savestate
                If tmpGamesListItem.Savestates.TryGetValue(tmpSavestateName, tmpSavestate) Then
                    tmpListViewItem.SubItems.AddRange({tmpSavestate.Slot, tmpSavestate.Extension, tmpSavestate.Version, tmpSavestate.LastWriteTime, (tmpSavestate.Lenght / 1024 ^ 2).ToString("#,##0.00 MB")})
                Else : tmpListViewItem.BackColor = Color.FromArgb(255, 255, 224, 192)   'orange
                End If
            Else : tmpListViewItem.BackColor = Color.FromArgb(255, 255, 192, 192)       'red
            End If
            Me.ListView1.Items.Add(tmpListViewItem)
        Next
        Me.ListView1.EndUpdate()
    End Sub

    Private Sub tsShowSavestatesChecked_Click(sender As System.Object, e As System.EventArgs) Handles tsShowSavestatesChecked.Click
        Me.ListView1.BeginUpdate()
        AddHeader(1)
        For Each tmpSavestateName As String In checkedFiles
            Dim tmpListViewItem As New ListViewItem With {.Text = tmpSavestateName, .ImageKey = tmpSavestateName}
            Dim tmpGamesListItem As New GamesList_Item
            If GamesList.TryGetValue(mdlFileList.SStates_GetSerial(tmpSavestateName), tmpGamesListItem) Then
                Dim tmpSavestate As New Savestate
                If tmpGamesListItem.Savestates.TryGetValue(tmpSavestateName, tmpSavestate) Then
                    tmpListViewItem.SubItems.AddRange({tmpSavestate.Slot, tmpSavestate.Extension, tmpSavestate.Version, tmpSavestate.LastWriteTime, (tmpSavestate.Lenght / 1024 ^ 2).ToString("#,##0.00 MB")})
                Else : tmpListViewItem.BackColor = Color.FromArgb(255, 255, 224, 192)   'orange
                End If
            Else : tmpListViewItem.BackColor = Color.FromArgb(255, 255, 192, 192)       'red
            End If
            Me.ListView1.Items.Add(tmpListViewItem)
        Next
        Me.ListView1.EndUpdate()
    End Sub
End Class