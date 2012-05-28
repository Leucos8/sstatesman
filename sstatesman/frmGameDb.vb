'   SStatesMan - a savestate managing tool for PCSX2
'   Copyright (C) 2011 - Leucos
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

    Friend GameDbSearch() As mdlGameDb.rGameDb
    Friend GameDbSearch_Pos As System.Int32 = 0
    Friend GameDbSearch_Len As System.Int32 = 0

    Private Sub ShowStatus()
        If Me.WindowSearchActive = False Then
            Me.StatusStrip1.Items.Item(0).Text = mdlGameDb.GameDb_Pos.ToString("Position: #,##0")
            Me.StatusStrip1.Items.Item(1).Text = (mdlGameDb.GameDb_Len + 1).ToString("Records: #,##0")
            If mdlGameDb.GameDb_Len < 0 Then
                Me.StatusStrip1.Items.Item(2).Text = "GameDB not loaded!"
            End If

            If mdlGameDb.GameDb_Len >= 0 Then
                Me.txtGameList_Title.Text = mdlGameDb.GameDb(mdlGameDb.GameDb_Pos).Name
                Me.txtGameList_Serial.Text = mdlGameDb.GameDb(mdlGameDb.GameDb_Pos).Serial
                Me.txtGameList_Region.Text = mdlGameDb.GameDb(mdlGameDb.GameDb_Pos).Region
                Me.txtGameList_Compat.Text = assignCompatText(mdlGameDb.GameDb(mdlGameDb.GameDb_Pos).Compat)
                Me.imgFlag.Visible = True
                Me.imgFlag.Image = Me.assignFlag(mdlGameDb.GameDb(mdlGameDb.GameDb_Pos).Region, mdlGameDb.GameDb(mdlGameDb.GameDb_Pos).Serial)

                Me.tsGameDbUnload.Enabled = True
                Me.tsListShow.Enabled = True
                Me.tsTxtSearchSerial.Enabled = True
                Me.tsCmdSearchSerial.Enabled = True
                Me.tsExport.Enabled = True
                Me.tsCmdSearch.Enabled = True
                If (mdlGameDb.GameDb_Pos > 0) And (mdlGameDb.GameDb_Pos < mdlGameDb.GameDb_Len) Then
                    Me.tsRecordNext.Enabled = True
                    Me.tsRecordLast.Enabled = True
                    Me.tsRecordPrevious.Enabled = True
                    Me.tsRecordFirst.Enabled = True
                ElseIf mdlGameDb.GameDb_Pos <= 0 Then
                    Me.tsRecordNext.Enabled = True
                    Me.tsRecordLast.Enabled = True
                    Me.tsRecordPrevious.Enabled = False
                    Me.tsRecordFirst.Enabled = False
                ElseIf mdlGameDb.GameDb_Pos >= mdlGameDb.GameDb_Len Then
                    Me.tsRecordNext.Enabled = False
                    Me.tsRecordLast.Enabled = False
                    Me.tsRecordPrevious.Enabled = True
                    Me.tsRecordFirst.Enabled = True
                End If
            Else
                Me.txtGameList_Title.Text = ""
                Me.txtGameList_Serial.Text = ""
                Me.txtGameList_Region.Text = ""
                Me.txtGameList_Compat.Text = ""
                Me.imgFlag.Image = My.Resources.Flag_0Null_30x20

                Me.tsRecordNext.Enabled = False
                Me.tsRecordLast.Enabled = False
                Me.tsRecordPrevious.Enabled = False
                Me.tsRecordFirst.Enabled = False
                Me.tsGameDbUnload.Enabled = False
                Me.tsListShow.Enabled = False
                Me.tsTxtSearchSerial.Enabled = False
                Me.tsCmdSearchSerial.Enabled = False
                Me.tsExport.Enabled = False
                Me.tsCmdSearch.Enabled = False
            End If

        Else

            Me.StatusStrip1.Items.Item(0).Text = System.String.Format("Position: {0:#,##0}", (GameDbSearch_Pos))
            Me.StatusStrip1.Items.Item(1).Text = System.String.Format("Found: {0:#,##0}/{1:#,##0}", (GameDbSearch_Len + 1), (mdlGameDb.GameDb_Len + 1))

            If GameDbSearch_Len >= 0 Then
                Me.txtGameList_Title.Text = GameDbSearch(GameDbSearch_Pos).Name
                Me.txtGameList_Serial.Text = GameDbSearch(GameDbSearch_Pos).Serial
                Me.txtGameList_Region.Text = GameDbSearch(GameDbSearch_Pos).Region
                Me.txtGameList_Compat.Text = assignCompatText(GameDbSearch(GameDbSearch_Pos).Compat)
                Me.imgFlag.Visible = True
                Me.imgFlag.Image = Me.assignFlag(GameDbSearch(GameDbSearch_Pos).Region, GameDbSearch(GameDbSearch_Pos).Serial)

                Me.tsExport.Enabled = True
                If (GameDbSearch_Pos > 0) And (GameDbSearch_Pos < GameDbSearch_Len) Then
                    Me.tsRecordNext.Enabled = True
                    Me.tsRecordLast.Enabled = True
                    Me.tsRecordPrevious.Enabled = True
                    Me.tsRecordFirst.Enabled = True
                ElseIf GameDbSearch_Pos <= 0 Then
                    Me.tsRecordNext.Enabled = True
                    Me.tsRecordLast.Enabled = True
                    Me.tsRecordPrevious.Enabled = False
                    Me.tsRecordFirst.Enabled = False
                ElseIf GameDbSearch_Pos >= GameDbSearch_Len Then
                    Me.tsRecordNext.Enabled = False
                    Me.tsRecordLast.Enabled = False
                    Me.tsRecordPrevious.Enabled = True
                    Me.tsRecordFirst.Enabled = True
                End If
            Else
                Me.txtGameList_Title.Text = ""
                Me.txtGameList_Serial.Text = ""
                Me.txtGameList_Region.Text = ""
                Me.txtGameList_Compat.Text = ""
                Me.imgFlag.Image = My.Resources.Flag_0Null_30x20

                Me.tsRecordNext.Enabled = False
                Me.tsRecordLast.Enabled = False
                Me.tsRecordPrevious.Enabled = False
                Me.tsRecordFirst.Enabled = False
                Me.tsExport.Enabled = False
            End If

        End If
    End Sub

    Private Sub frmGameDb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mdlGameDb.GameDb_Pos = 0
        ShowStatus()
        Me.lvwGameDBList.SuspendLayout()
        Me.lvwGameDBList.Items.Clear()
        Me.lvwGameDBList.Visible = False

        For mdlGameDb.GameDb_Pos = 0 To GameDb_Len
            Dim ListItemTmp As New System.Windows.Forms.ListViewItem
            ListItemTmp.Text = GameDb(GameDb_Pos).Name
            With ListItemTmp.SubItems
                .Add(GameDb(GameDb_Pos).Serial)
                .Add(GameDb(GameDb_Pos).Region)
                .Add(Me.assignCompatText(GameDb(GameDb_Pos).Compat))
                .Add(GameDb(GameDb_Pos).RStatus.ToString)
                .Add(GameDb_Pos.ToString("#,##0"))
            End With
            ListItemTmp.UseItemStyleForSubItems = False
            ListItemTmp.SubItems(3).BackColor = Me.assignCompatColor(GameDb(GameDb_Pos).Compat, Color.Transparent)
            Me.lvwGameDBList.Items.Add(ListItemTmp)
        Next GameDb_Pos

        mdlGameDb.GameDb_Pos = 0

        Me.lvwGameDBList.ResumeLayout()
        Me.lvwGameDBList.Visible = True
    End Sub

    Private Sub tsGameDbLoad_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsGameDbLoad.ButtonClick
        Me.lvwGameDBList.Items.Clear()
        Dim tmp As System.DateTime = Now
        GameDb_Len = mdlGameDb.GameDb_Load3(My.Computer.FileSystem.CombinePath(My.Settings.PCSX2_PathBin, My.Settings.PCSX2_GameDbFilename), GameDb, GameDb_Pos)
        Me.ToolStripStatusLabel3.Text = System.String.Concat("Load time: ", ((Now.Subtract(tmp).Seconds * 1000) + Now.Subtract(tmp).Milliseconds).ToString("#,##0 ms"))
        Erase Me.GameDbSearch
        ReDim Me.GameDbSearch(0 To 3)
        GameDbSearch_Pos = 0
        GameDbSearch_Len = -1
        WindowSearchActive = False
        ShowStatus()
    End Sub

    Private Sub LoadV1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadV1ToolStripMenuItem.Click
        Me.lvwGameDBList.Items.Clear()
        Dim tmp As System.DateTime = Now
        GameDb_Len = mdlGameDb.GameDb_Load1(My.Computer.FileSystem.CombinePath(My.Settings.PCSX2_PathBin, My.Settings.PCSX2_GameDbFilename), GameDb, GameDb_Pos)
        Me.ToolStripStatusLabel3.Text = System.String.Concat("Load time: ", ((Now.Subtract(tmp).Seconds * 1000) + Now.Subtract(tmp).Milliseconds).ToString("#,##0 ms"))
        Erase Me.GameDbSearch
        ReDim Me.GameDbSearch(0 To 3)
        GameDbSearch_Pos = 0
        GameDbSearch_Len = -1
        WindowSearchActive = False
        ShowStatus()
    End Sub

    Private Sub LoadV2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadV2ToolStripMenuItem.Click
        Me.lvwGameDBList.Items.Clear()
        Dim tmp As System.DateTime = Now
        GameDb_Len = mdlGameDb.GameDb_Load2(My.Computer.FileSystem.CombinePath(My.Settings.PCSX2_PathBin, My.Settings.PCSX2_GameDbFilename), GameDb, GameDb_Pos)
        Me.ToolStripStatusLabel3.Text = System.String.Concat("Load time: ", ((Now.Subtract(tmp).Seconds * 1000) + Now.Subtract(tmp).Milliseconds).ToString("#,##0 ms"))
        Erase Me.GameDbSearch
        ReDim Me.GameDbSearch(0 To 3)
        GameDbSearch_Pos = 0
        GameDbSearch_Len = -1
        WindowSearchActive = False
        ShowStatus()
    End Sub

    Private Sub LoadV3ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadV3ToolStripMenuItem.Click
        Me.lvwGameDBList.Items.Clear()
        Dim tmp As System.DateTime = Now
        GameDb_Len = mdlGameDb.GameDb_Load3(My.Computer.FileSystem.CombinePath(My.Settings.PCSX2_PathBin, My.Settings.PCSX2_GameDbFilename), GameDb, GameDb_Pos)
        Me.ToolStripStatusLabel3.Text = System.String.Concat("Load time: ", ((Now.Subtract(tmp).Seconds * 1000) + Now.Subtract(tmp).Milliseconds).ToString("#,##0 ms"))
        Erase Me.GameDbSearch
        ReDim Me.GameDbSearch(0 To 3)
        GameDbSearch_Pos = 0
        GameDbSearch_Len = -1
        WindowSearchActive = False
        ShowStatus()
    End Sub

    Private Sub tsGameDbUnload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsGameDbUnload.Click

        If Microsoft.VisualBasic.MsgBox("Warning, unloading the GameDB could lead to undesired effects." & vbCrLf & "Be sure to load it again before closing GameDB util." & vbCrLf & "Do you wish to continue?", MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, "Confirmation") = MsgBoxResult.Yes Then
            Me.lvwGameDBList.Items.Clear()
            GameDb_Len = mdlGameDb.GameDb_Unload(GameDb, GameDb_Pos)
            Erase Me.GameDbSearch
            ReDim Me.GameDbSearch(0 To 3)
            GameDbSearch_Pos = 0
            GameDbSearch_Len = -1
            WindowSearchActive = False
        End If
        ShowStatus()
    End Sub

    Private Sub tsListShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsListShow.Click

        Me.lvwGameDBList.SuspendLayout()
        Me.lvwGameDBList.Items.Clear()
        Me.lvwGameDBList.Visible = False
        Me.WindowSearchActive = False

        For mdlGameDb.GameDb_Pos = 0 To GameDb_Len
            Dim ListItemTmp As New System.Windows.Forms.ListViewItem
            ListItemTmp.Text = GameDb(GameDb_Pos).Name
            With ListItemTmp.SubItems
                .Add(GameDb(GameDb_Pos).Serial)
                .Add(GameDb(GameDb_Pos).Region)
                .Add(Me.assignCompatText(GameDb(GameDb_Pos).Compat))
                .Add(GameDb(GameDb_Pos).RStatus.ToString)
                .Add(GameDb_Pos.ToString("#,##0"))
            End With
            ListItemTmp.UseItemStyleForSubItems = False
            ListItemTmp.SubItems(3).BackColor = Me.assignCompatColor(GameDb(GameDb_Pos).Compat, Color.Transparent)
            Me.lvwGameDBList.Items.Add(ListItemTmp)
        Next GameDb_Pos

        mdlGameDb.GameDb_Pos = 0

        Me.lvwGameDBList.ResumeLayout()
        Me.lvwGameDBList.Visible = True

        ShowStatus()

    End Sub

    Private Sub tsExportTSVTxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsExportTSVTxt.Click
        Dim SaveDialog As New System.Windows.Forms.SaveFileDialog
        With SaveDialog
            .AddExtension = True
            .CheckFileExists = False
            .CheckPathExists = True
            .DefaultExt = ".txt"
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            .OverwritePrompt = True
            .ValidateNames = True
        End With

        If Me.WindowSearchActive Then
            With SaveDialog
                .FileName = "GameIndexExtracted"
                .Title = "Save search records to..."
            End With
            If SaveDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Call mdlGameDb.GameDb_ExportTxt(SaveDialog.FileName, _
                                     vbTab, _
                                     GameDbSearch, _
                                     GameDbSearch_Pos, _
                                     GameDbSearch_Len)
            End If
        Else
            With SaveDialog
                .FileName = "GameIndex"
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
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            .OverwritePrompt = True
            .ValidateNames = True
        End With

        If Me.WindowSearchActive Then
            With SaveDialog
                .FileName = "GameIndexExtracted"
                .Title = "Save search records to..."
            End With
            If SaveDialog.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then

                Call mdlGameDb.GameDb_ExportTxt(SaveDialog.FileName, _
                                     ";", _
                                     GameDbSearch, _
                                     GameDbSearch_Pos, _
                                     GameDbSearch_Len)
            End If
        Else
            With SaveDialog
                .FileName = "GameIndex"
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
            Me.tsTxtSearchSerial.Text = UCase(Me.tsTxtSearchSerial.Text)
            tmp = mdlGameDb.GameDb_SearchSerial(tsTxtSearchSerial.Text, GameDb, GameDb_Pos, GameDb_Len)
            ShowStatus()
            Me.txtGameList_Title.Text = tmp.Name
            Me.txtGameList_Serial.Text = tmp.Serial
            Me.txtGameList_Region.Text = tmp.Region
            Me.txtGameList_Compat.Text = assignCompatText(tmp.Compat)
            Me.imgFlag.Visible = True
            Me.imgFlag.Image = Me.assignFlag(tmp.Region)
        End If
    End Sub


    Private Sub tsRecordFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRecordFirst.Click
        If Me.WindowSearchActive Then
            GameDbSearch_Pos = 0
        Else
            mdlGameDb.GameDb_Pos = 0
        End If
        ShowStatus()
    End Sub

    Private Sub tsRecordPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRecordPrevious.Click
        If Me.WindowSearchActive Then
            If GameDbSearch_Pos > 0 Then
                GameDbSearch_Pos = GameDbSearch_Pos - 1
            End If
        Else
            If mdlGameDb.GameDb_Pos > 0 Then
                mdlGameDb.GameDb_Pos = mdlGameDb.GameDb_Pos - 1
            End If
        End If
        ShowStatus()
    End Sub

    Private Sub tsRecordNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRecordNext.Click
        If Me.WindowSearchActive Then
            If GameDbSearch_Pos < GameDbSearch_Len Then
                GameDbSearch_Pos = GameDbSearch_Pos + 1
            End If
        Else
            If mdlGameDb.GameDb_Pos < mdlGameDb.GameDb_Len Then
                mdlGameDb.GameDb_Pos = mdlGameDb.GameDb_Pos + 1
            End If
        End If
        ShowStatus()
    End Sub

    Private Sub tsRecordLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRecordLast.Click
        If Me.WindowSearchActive Then
            GameDbSearch_Pos = GameDbSearch_Len
        Else
            mdlGameDb.GameDb_Pos = mdlGameDb.GameDb_Len
        End If
        ShowStatus()
    End Sub

    Public Function assignFlag(ByVal pRegionToCheck As System.String, Optional ByVal pSerialToCheck As System.String = "") As System.Drawing.Bitmap
        assignFlag = My.Resources.Flag_0Null_30x20
        If pRegionToCheck IsNot Nothing And pSerialToCheck IsNot Nothing Then
            pRegionToCheck = pRegionToCheck.ToUpper
            If pRegionToCheck.StartsWith("PAL") Then
                If pRegionToCheck.StartsWith("PAL-I") Then
                    assignFlag = My.Resources.Flag_Italy_30x20
                ElseIf pRegionToCheck.StartsWith("PAL-F") Then
                    assignFlag = My.Resources.Flag_France_30x20
                ElseIf pRegionToCheck.StartsWith("PAL-GR") Then
                    assignFlag = My.Resources.Flag_Greece_30x20
                ElseIf pRegionToCheck.StartsWith("PAL-G") Or pRegionToCheck.StartsWith("PAL-D") Then
                    If System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName = "AUT" Then
                        assignFlag = My.Resources.Flag_Austria_30x20
                    Else : assignFlag = My.Resources.Flag_Germany_30x20
                    End If
                    'ElseIf pRegionToCheck.StartsWith("PAL-SW") Then
                    '    assignFlag = My.Resources.Flag_Switzerland_30x20
                ElseIf pRegionToCheck.StartsWith("PAL-S") Then
                    assignFlag = My.Resources.Flag_Spain_30x20
                ElseIf pRegionToCheck.StartsWith("PAL-E") Then
                    If System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName = "AUS" Then
                        assignFlag = My.Resources.Flag_Australia_30x20
                    Else : assignFlag = My.Resources.Flag_UK_30x20
                    End If
                ElseIf pRegionToCheck.StartsWith("PAL-P") Then
                    assignFlag = My.Resources.Flag_Poland_30x20
                ElseIf pRegionToCheck.StartsWith("PAL-R") Then
                    assignFlag = My.Resources.Flag_Russia_30x20
                ElseIf pRegionToCheck.StartsWith("PAL-N") Then
                    assignFlag = My.Resources.Flag_Netherlands_30x20
                Else
                    If System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName = "AUS" Then
                        assignFlag = My.Resources.Flag_Australia_30x20
                    Else : assignFlag = My.Resources.Flag_Europe_Union_30x20
                    End If
                End If
            ElseIf pRegionToCheck.StartsWith("NTSC") Then
                If pRegionToCheck.StartsWith("NTSC-CH") Then
                    assignFlag = My.Resources.Flag_China_30x20
                ElseIf pRegionToCheck.StartsWith("NTSC-K") Or _
                    pSerialToCheck.StartsWith("SCKA") Or _
                    pSerialToCheck.StartsWith("SLKA") Then
                    assignFlag = My.Resources.Flag_South_Korea_30x20
                ElseIf pRegionToCheck.StartsWith("NTSC-J") Or _
                    pSerialToCheck.StartsWith("SCPS") Or _
                    pSerialToCheck.StartsWith("SLPM") Or _
                    pSerialToCheck.StartsWith("SLPS") Then
                    assignFlag = My.Resources.Flag_Japan_30x20
                ElseIf ((Not (pRegionToCheck = "NTSC-UNK")) And pRegionToCheck.StartsWith("NTSC-U")) Or _
                    pSerialToCheck.StartsWith("SCUS") Or _
                    pSerialToCheck.StartsWith("SLUS") Then
                    If System.Globalization.CultureInfo.CurrentCulture.ThreeLetterISOLanguageName = "CAN" Then
                        assignFlag = My.Resources.Flag_Canada_30x20
                    Else : assignFlag = My.Resources.Flag_US_30x20
                    End If
                End If
            End If
        End If
    End Function

    Public Function assignCompatText(ByVal pCompat As System.String) As System.String
        Select Case pCompat
            Case "0" : assignCompatText = "Unknown"
            Case "1" : assignCompatText = "Nothing"
            Case "2" : assignCompatText = "Intro"
            Case "3" : assignCompatText = "Menus"
            Case "4" : assignCompatText = "in-Game"
            Case "5" : assignCompatText = "Playable"
            Case "6" : assignCompatText = "Perfect"
            Case "" : assignCompatText = "Missing"
            Case Else : assignCompatText = "Undetected"
        End Select
    End Function

    Public Function assignCompatColor(ByVal pCompat As System.String, ByVal pBGcolor As System.Drawing.Color) As System.Drawing.Color
        Select Case pCompat
            Case "0" : assignCompatColor = pBGcolor  'Unknown
            Case "1" : assignCompatColor = Color.FromArgb(255, 255, 192, 192)  'Nothing:    Red
            Case "2" : assignCompatColor = Color.FromArgb(255, 255, 224, 192)  'Intro:      Orange
            Case "3" : assignCompatColor = Color.FromArgb(255, 255, 255, 192)  'Menus:      Yellow
            Case "4" : assignCompatColor = Color.FromArgb(255, 255, 192, 255)  'in-Game:    Purple
            Case "5" : assignCompatColor = Color.FromArgb(255, 192, 255, 192)  'Playable:   Green
            Case "6" : assignCompatColor = Color.FromArgb(255, 192, 192, 255)  'Perfect:    Blue
            Case Else : assignCompatColor = pBGcolor
        End Select
    End Function

    Private Sub lvwGameDBList_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvwGameDBList.SelectedIndexChanged
        If lvwGameDBList.SelectedItems.Count > 0 Then
            If WindowSearchActive Then
                Me.GameDbSearch_Pos = CInt(Me.lvwGameDBList.SelectedItems(0).SubItems(5).Text)
            Else : mdlGameDb.GameDb_Pos = CInt(Me.lvwGameDBList.SelectedItems(0).SubItems(5).Text)
            End If
            ShowStatus()
        End If
    End Sub

    Friend Function GameDb_Search(ByVal pSerial As System.String, ByVal pSearchBySerial As System.Boolean, _
                                  ByVal pGameTitle As System.String, ByVal pSearchByGameTitle As System.Boolean, _
                                  ByRef pGameRegion As System.String, ByVal pSearchByGameRegion As System.Boolean, _
                                  ByRef pGameCompat As System.String, ByVal pSearchByGameCompat As System.Boolean, _
                                  ByRef pSearchType As System.Byte) As System.Int32
        Dim SerialFound As System.Boolean = False
        Dim GameTitleFound As System.Boolean = False
        Dim GameRegionFound As System.Boolean = False
        Dim GameCompatFound As System.Boolean = False

        GameDbSearch_Pos = -1
        GameDbSearch_Len = 0
        Erase GameDbSearch
        ReDim GameDbSearch(mdlGameDb.GameDb_Len)

        For mdlGameDb.GameDb_Pos = 0 To mdlGameDb.GameDb_Len
            'Resize not needed as it is resized to the GameDb_Len

            If pSearchBySerial Then

                If GameDb(GameDb_Pos).Serial.ToUpper.Contains(pSerial.ToUpper) Then
                    SerialFound = True
                End If
            End If

            If pSearchByGameTitle Then
                If GameDb(GameDb_Pos).Name IsNot Nothing Then
                    If GameDb(GameDb_Pos).Name.ToUpper.Contains(pGameTitle.ToUpper) Then
                        GameTitleFound = True
                    End If
                End If
            End If

            If pSearchByGameRegion Then
                If GameDb(GameDb_Pos).Name IsNot Nothing Then
                    If GameDb(GameDb_Pos).Region.ToUpper.Contains(pGameRegion.ToUpper) Then
                        GameRegionFound = True
                    End If
                End If
            End If

            If pSearchByGameCompat Then
                If GameDb(GameDb_Pos).Compat = pGameCompat Then
                    GameCompatFound = True
                End If
            End If

            If pSearchType = 0 Then
                If (SerialFound Or Not (pSearchBySerial)) And _
                   (GameTitleFound Or Not (pSearchByGameTitle)) And _
                   (GameRegionFound Or Not (pSearchByGameRegion)) And _
                   (GameCompatFound Or Not (pSearchByGameCompat)) Then
                    GameDbSearch_Pos += 1
                    GameDbSearch(GameDbSearch_Pos) = mdlGameDb.GameDb(mdlGameDb.GameDb_Pos)
                End If
            ElseIf pSearchType = 1 Then
                If SerialFound Or GameTitleFound Or GameRegionFound Or GameCompatFound Then
                    GameDbSearch_Pos += 1
                    GameDbSearch(GameDbSearch_Pos) = mdlGameDb.GameDb(mdlGameDb.GameDb_Pos)
                End If
            End If
            SerialFound = False
            GameTitleFound = False
            GameRegionFound = False
            GameCompatFound = False

        Next
        ReDim Preserve GameDbSearch(GameDbSearch_Pos)
        GameDb_Search = GameDbSearch_Pos
    End Function

    Private Sub tsCmdSearch_Click(sender As System.Object, e As System.EventArgs) Handles tsCmdSearch.Click
        If frmGameDbSearchForm.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            WindowSearchActive = True
            Me.lvwGameDBList.SuspendLayout()
            Me.lvwGameDBList.Items.Clear()
            Me.lvwGameDBList.Visible = False

            For Me.GameDbSearch_Pos = 0 To GameDbSearch_Len
                Dim ListItemTmp As New System.Windows.Forms.ListViewItem
                ListItemTmp.Text = GameDbSearch(GameDbSearch_Pos).Name
                With ListItemTmp.SubItems
                    .Add(GameDbSearch(GameDbSearch_Pos).Serial)
                    .Add(GameDbSearch(GameDbSearch_Pos).Region)
                    .Add(Me.assignCompatText(GameDbSearch(GameDbSearch_Pos).Compat))
                    .Add(GameDbSearch(GameDbSearch_Pos).RStatus)
                    .Add(GameDbSearch_Pos.ToString("#,##0"))
                End With
                ListItemTmp.UseItemStyleForSubItems = False
                ListItemTmp.SubItems(3).BackColor = Me.assignCompatColor(GameDbSearch(GameDbSearch_Pos).Compat, Color.Transparent)
                Me.lvwGameDBList.Items.Add(ListItemTmp)
            Next GameDbSearch_Pos

            GameDbSearch_Pos = 0

            Me.lvwGameDBList.ResumeLayout()
            Me.lvwGameDBList.Visible = True

            ShowStatus()
        End If
    End Sub
End Class