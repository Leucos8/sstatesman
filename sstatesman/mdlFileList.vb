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
    Public Class GamesList_Item
        Public Property Savestates As New Dictionary(Of String, Savestate)
        Private _savestates_sizetot As Long
        Public ReadOnly Property Savestates_SizeTot() As Long
            Get
                If Not (IsNothing(Savestates)) Then
                    If Savestates.Count > 0 Then
                        _savestates_sizetot = Savestates.Where(Function(item) item.Value.Extension.Contains(My.Settings.PCSX2_SStateExt)).Sum(Function(item) item.Value.Length)
                    Else
                        _savestates_sizetot = 0
                    End If
                Else
                    _savestates_sizetot = 0
                End If
                Return _savestates_sizetot
            End Get
        End Property
        Private _savestatebackup_sizetot As Long
        Public ReadOnly Property SavestatesBackup_SizeTot() As Long
            Get
                If Not (IsNothing(Savestates)) Then
                    If Savestates.Count > 0 Then
                        _savestatebackup_sizetot = Savestates.Where(Function(item) item.Value.Extension.Contains(My.Settings.PCSX2_SStateExt)).Sum(Function(item) item.Value.Length)
                    Else
                        _savestatebackup_sizetot = 0
                    End If
                Else
                    _savestatebackup_sizetot = 0
                End If
                Return _savestates_sizetot
            End Get
        End Property
        Public Property Snapshots As New Dictionary(Of String, Snapshot)
        Private _snapshots_sizetot As Long
        Public ReadOnly Property Snapshots_SizeTot() As Long
            Get
                If Not (IsNothing(Snapshots)) Then
                    If Snapshots.Count > 0 Then
                        _snapshots_sizetot = Snapshots.Sum(Function(item) item.Value.Length)
                    Else
                        _snapshots_sizetot = 0
                    End If
                Else
                    _snapshots_sizetot = 0
                End If
                Return _snapshots_sizetot
            End Get
        End Property
        'Public Property Snapshots_SizeTot As Long = 0
        Public Property CRC As String
    End Class

    Public Class GamesList
        Public Property Games As New Dictionary(Of String, GamesList_Item)
        Public Property Status As mdlMain.LoadStatus = LoadStatus.StatusNotLoaded
        Public Property LoadTime As Long
        Public Property SStatesFolder_LastModified As DateTime
        'Public Property SStatesStored_FolderLastModified As DateTime
        Public Property SnapsFolder_LastModified As DateTime

        Public Sub LoadAll(ByVal pSStatesPath As String,
                           ByVal pSnapsPath As String
                           )

            Dim sw As New Stopwatch
            sw.Start()

            Games.Clear()



            Dim tmpDirectoryInfo As New DirectoryInfo(pSStatesPath)
            LoadSavestates(tmpDirectoryInfo)
            tmpDirectoryInfo = New DirectoryInfo(pSnapsPath)
            SnapsList_Load(tmpDirectoryInfo)

            sw.Stop()
            LoadTime = sw.ElapsedTicks
            If Games.Count = 0 Then
                mdlApplicationLog.AppendToLog("FilesList", "LoadAll", "No games, the list is empty.", LoadTime)
                Status = LoadStatus.StatusEmpty
            Else
                Dim SStates_Count As Integer = Games.Sum(Function(item) item.Value.Savestates.Count)
                Dim Snaps_Count As Integer = Games.Sum(Function(item) item.Value.Snapshots.Count)
                mdlApplicationLog.AppendToLog("FilesList", "LoadAll", String.Format("{0:N0} games > {1:N0} savestates - {2:N0} screenshots.", Games.Count, SStates_Count, Snaps_Count), LoadTime)
                Status = LoadStatus.StatusLoadedOK
            End If
        End Sub

        Public Sub LoadSavestates(ByVal pDirectory As DirectoryInfo)

            'Version DB
            Dim PCSX2_VersionDB As New ssVersionDB
            PCSX2_VersionDB.Load(My.Resources.ssversion)

            SStatesFolder_LastModified = pDirectory.LastWriteTime

            Dim tmpSStateFileInfos As IEnumerable(Of FileInfo) = pDirectory.EnumerateFiles().Where(Function(item) {My.Settings.PCSX2_SStateExt, My.Settings.PCSX2_SStateExtBackup}.Contains(item.Extension.ToLower))

            For Each tmpFileInfo As FileInfo In tmpSStateFileInfos
                'A temporary of Savestates is created
                Dim tmpSavestate As New Savestate With {.Name = tmpFileInfo.Name, .Length = tmpFileInfo.Length, .LastWriteTime = tmpFileInfo.LastWriteTime}
                If My.Settings.SStatesMan_SStatesVersionExtract Then
                    tmpSavestate.Version = mdlSimpleZipExtractor.ExtractFirstFile(tmpFileInfo)
                    tmpSavestate.Version &= " " & PCSX2_VersionDB.GetRevisions(tmpSavestate.Version)
                Else : tmpSavestate.Version = "-"
                End If
                Dim tmpSerial As String = tmpSavestate.GetSerial()
                If Games.ContainsKey(tmpSerial) Then
                    Games(tmpSerial).Savestates.Add(tmpSavestate.Name, tmpSavestate)
                Else
                    Dim tmpNewGame As New GamesList_Item With {.CRC = tmpSavestate.GetCRC}
                    tmpNewGame.Savestates.Add(tmpSavestate.Name, tmpSavestate)
                    Games.Add(tmpSerial, tmpNewGame)
                End If
            Next
        End Sub

        Public Sub SnapsList_Load(ByVal pDirectory As DirectoryInfo)

            SnapsFolder_LastModified = pDirectory.LastWriteTime

            Dim tmpSnapsFileInfos As IEnumerable(Of FileInfo) = pDirectory.EnumerateFiles().Where(Function(item) {".bmp", ".jpg", ".png"}.Contains(item.Extension.ToLower))


            For Each tmpFileInfo As FileInfo In tmpSnapsFileInfos
                'Creo una lista temporanea di FileInfo partendo dai FileInfo del gruppo, perché non posso fare conversione diretta
                Dim tmpSnap As New Snapshot With {.Name = tmpFileInfo.Name, .Extension = tmpFileInfo.Extension, .Length = tmpFileInfo.Length, .LastWriteTime = tmpFileInfo.LastWriteTime}
                Dim tmpSerial As String = tmpSnap.GetSerial()
                If Games.ContainsKey(tmpSerial) Then
                    Games(tmpSerial).Snapshots.Add(tmpSnap.Name, tmpSnap)
                Else
                    Dim tmpNewGame As New GamesList_Item
                    tmpNewGame.Snapshots.Add(tmpSnap.Name, tmpSnap)
                    Games.Add(tmpSerial, tmpNewGame)
                End If
            Next
        End Sub

    End Class
End Module
