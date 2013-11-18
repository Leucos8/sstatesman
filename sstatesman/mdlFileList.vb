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

Module mdlFileList
    Friend Class GamesList_Item
        Friend ReadOnly Property HasCoverFile(pDirectory As String, pSerial As String) As Boolean
            Get
                If File.Exists(Path.Combine(pDirectory, mdlMain.TrimBadPathChars(pSerial) & ".jpg")) Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property

        Friend Savestates As New Dictionary(Of String, Savestate)
        Friend ReadOnly Property Savestates_SizeTot() As Long
            Get
                If Savestates IsNot Nothing AndAlso Savestates.Count > 0 Then
                    Return Savestates.Where(Function(item) item.Value.Extension.Equals(My.Settings.PCSX2_SStateExt)).Sum(Function(item) item.Value.Length)
                Else
                    Return 0
                End If
            End Get
        End Property
        Friend ReadOnly Property SavestatesBackup_SizeTot() As Long
            Get
                If Not (IsNothing(Savestates)) AndAlso Savestates.Count > 0 Then
                    Return Savestates.Where(Function(item) item.Value.Extension.Equals(My.Settings.PCSX2_SStateExtBackup)).Sum(Function(item) item.Value.Length)
                Else
                    Return 0
                End If
            End Get
        End Property
        Friend Snapshots As New Dictionary(Of String, Snapshot)
        Friend ReadOnly Property Snapshots_SizeTot() As Long
            Get
                If Snapshots IsNot Nothing AndAlso Snapshots.Count > 0 Then
                    Return Snapshots.Sum(Function(item) item.Value.Length)
                Else
                    Return 0
                End If
            End Get
        End Property
        Friend CRC As String = ""
    End Class

    Friend Class GamesList
        Friend Games As New Dictionary(Of String, GamesList_Item)
        Friend Status As mdlMain.LoadStatus = LoadStatus.StatusNotLoaded
        Friend LoadTime As Long
        Friend SStatesFolder_LastModified As DateTime
        'Friend SStatesStored_FolderLastModified As DateTime
        Friend SnapsFolder_LastModified As DateTime

        Friend Sub LoadAll(ByVal pSStatesPath As String, _
                           ByVal pSnapsPath As String)

            Dim sw As New Stopwatch
            sw.Start()

            Games.Clear()

            Dim tmpDirectoryInfo As New DirectoryInfo(pSStatesPath)
            Savestates_Load(tmpDirectoryInfo)
            tmpDirectoryInfo = New DirectoryInfo(pSnapsPath)
            SnapsList_Load(tmpDirectoryInfo)

            sw.Stop()
            LoadTime = sw.ElapsedTicks
            If Games.Count = 0 Then
                SSMAppLog.Append(eType.LogWarning, eSrc.FileList, eSrcMethod.File_LoadAll, "No games, the list is empty.", LoadTime)
                Status = LoadStatus.StatusEmpty
            Else
                Dim SStates_Count As Integer = Games.Sum(Function(item) item.Value.Savestates.Count)
                Dim Snaps_Count As Integer = Games.Sum(Function(item) item.Value.Snapshots.Count)
                SSMAppLog.Append(eType.LogInformation, eSrc.FileList, eSrcMethod.File_LoadAll, String.Format("{0:N0} games > {1:N0} savestates - {2:N0} screenshots.", Games.Count, SStates_Count, Snaps_Count), LoadTime)
                Status = LoadStatus.StatusLoadedOK
            End If
        End Sub

        Friend Sub Savestates_Load(ByVal pDirectory As DirectoryInfo)

            'Version DB
            Dim PCSX2_VersionDB As New ssVersionDB
            PCSX2_VersionDB.Load(My.Resources.ssversion)

            SStatesFolder_LastModified = pDirectory.LastWriteTime

            Dim tmpSStateFileInfos As IEnumerable(Of FileInfo) = pDirectory.EnumerateFiles().Where(Function(item) {My.Settings.PCSX2_SStateExt, My.Settings.PCSX2_SStateExtBackup}.Contains(item.Extension.ToLower))

            For Each tmpFileInfo As FileInfo In tmpSStateFileInfos
                'A temporary of Savestates is created
                Dim tmpSavestate As New Savestate With {.Name = tmpFileInfo.Name, .Length = tmpFileInfo.Length, .LastWriteTime = tmpFileInfo.LastWriteTime}
                If My.Settings.SStatesMan_SStatesVersionExtract Then
                    tmpSavestate.ExtraInfo = mdlSimpleZipExtractor.ExtractFirstFile(tmpFileInfo)
                    tmpSavestate.ExtraInfo &= " " & PCSX2_VersionDB.GetRevisions(tmpSavestate.ExtraInfo)
                Else : tmpSavestate.ExtraInfo = "-"
                End If
                Dim tmpSerial As String = tmpSavestate.GetSerial()
                If Not (Games.ContainsKey(tmpSerial)) Then
                    'Savestates are loaded first, so we get the CRC here. If a game is added during screenshots loading it means there are no savestates (and no crc)
                    Games.Add(tmpSerial, New GamesList_Item With {.CRC = tmpSavestate.GetCRC})
                End If
                Games(tmpSerial).Savestates.Add(tmpSavestate.Name, tmpSavestate)
            Next
        End Sub

        Friend Sub SnapsList_Load(ByVal pDirectory As DirectoryInfo)

            SnapsFolder_LastModified = pDirectory.LastWriteTime

            Dim tmpSnapsFileInfos As IEnumerable(Of FileInfo) = pDirectory.EnumerateFiles().Where(Function(item) {".bmp", ".jpg", ".png"}.Contains(item.Extension.ToLower))


            For Each tmpFileInfo As FileInfo In tmpSnapsFileInfos
                'A temporary of Savestates is created
                Dim tmpSnap As New Snapshot With {.Name = tmpFileInfo.Name, .Length = tmpFileInfo.Length, .LastWriteTime = tmpFileInfo.LastWriteTime}
                Dim tmpSerial As String = tmpSnap.GetSerial()
                If Not (Games.ContainsKey(tmpSerial)) Then
                    Games.Add(tmpSerial, New GamesList_Item)
                End If
                Games(tmpSerial).Snapshots.Add(tmpSnap.Name, tmpSnap)
            Next
        End Sub
    End Class
End Module