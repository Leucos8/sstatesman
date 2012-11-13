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

Module mdlFileList
    Public Class Savestate
        Public Property Name As String
        Public Property Extension As String
        Public Property Length As Long
        Public Property LastWriteTime As DateTime
        Public Property Slot As String
        Public Property Backup As Boolean
        Public Property Version As String

        Public Function GetSerial() As String
            Dim SpacePosition As Int32 = Name.IndexOf(" "c, 0)
            If SpacePosition > 0 Then
                Return Name.Remove(SpacePosition)
            Else
                Return Name
            End If
        End Function

        Public Shared Function GetSerial(ByVal pFilename As String) As String
            Dim tmpSavestate As New Savestate With {.Name = pFilename}
            Return tmpSavestate.GetSerial
        End Function


        Public Function GetSlot() As Integer
            GetSlot = -1
            If Integer.TryParse(Name.Substring(Name.IndexOf("."c, 0) + 1, 2), GetSlot) Then
                Return GetSlot
            End If
            Return -1
        End Function

        Public Function GetTypeB() As Boolean
            If Extension = My.Settings.PCSX2_SStateExtBackup Then
                Return True
            Else
                Return False
            End If
        End Function

    End Class

    Public Class Snapshot
        Public Property Name As String
        Public Property Extension As String
        Public Property Length As Long
        Public Property LastWriteTime As DateTime

        Public Function GetSerial() As String
            'Dim SpacePosition As Int32 = Name.IndexOf(" "c, 0)
            'If Name.ToLower.StartsWith("gsdx") Then
            '    Return "GSdX"
            If PCSX2GameDb.Records.ContainsKey(Name) Then
                Return Name
            Else
                Return "Screenshots"
            End If
        End Function

        Public Shared Function GetSerial(ByVal pFilename As String) As String
            Dim tmpSnapshot As New Snapshot With {.Name = pFilename}
            Return tmpSnapshot.GetSerial
        End Function
    End Class

    Public Class GamesList_Item
        Public Property Savestates As New Dictionary(Of String, Savestate)
        'Public Property Savestates_Count As Integer = 0
        Public Property Savestates_SizeTot As Long = 0
        'Public Property Savestates_Backup As New Dictionary(Of String, Savestate)
        'Public Property SavestatesBackup_Count As Integer = 0
        Public Property SavestatesBackup_SizeTot As Long = 0
        Public Property Snapshots As New Dictionary(Of String, Snapshot)
        Public Property Snapshots_SizeTot As Long = 0
    End Class

    Public GamesList As New Dictionary(Of String, GamesList_Item)
    Public GamesList_Status As mdlMain.LoadStatus = LoadStatus.StatusNotLoaded
    Public GameList_LoadTime As Long
    Public SStates_FolderLastModified As DateTime
    'Public SStatesStored_FolderLastModified As DateTime
    Public Snaps_FolderLastModified As DateTime

    Public Function GamesList_LoadAll(ByVal pSStatesPath As String,
                                      ByVal pSnapsPath As String,
                                      ByRef pGamesList As Dictionary(Of String, GamesList_Item)
                                      ) As LoadStatus

        Dim sw As New Stopwatch
        sw.Start()

        pGamesList.Clear()



        Dim tmpDirectoryInfo As New DirectoryInfo(pSStatesPath)
        SStatesList_Load(tmpDirectoryInfo, pGamesList)
        tmpDirectoryInfo = New DirectoryInfo(pSnapsPath)
        SnapsList_Load(tmpDirectoryInfo, pGamesList)

        sw.Stop()
        GameList_LoadTime = sw.ElapsedTicks
        If pGamesList.Count = 0 Then
            mdlMain.AppendToLog("FilesList", "LoadAll", "No games, the list is empty.", GameList_LoadTime)
            Return LoadStatus.StatusEmpty
        Else
            Dim SStates_Count As Integer = GamesList.Sum(Function(item) item.Value.Savestates.Count)
            Dim Snaps_Count As Integer = GamesList.Sum(Function(item) item.Value.Snapshots.Count)
            mdlMain.AppendToLog("FilesList", "LoadAll", String.Format("{0:N0} games > {1:N0} savestates - {2:N0} screenshots.", pGamesList.Count, SStates_Count, Snaps_Count), GameList_LoadTime)
            Return LoadStatus.StatusLoadedOK
        End If
    End Function

    Public Sub SStatesList_Load(ByVal pDirectory As DirectoryInfo,
                                ByRef pGamesList As Dictionary(Of String, GamesList_Item))


        Dim PCSX2_VersionDB As New VersionDB
        PCSX2_VersionDB.Load()

        SStates_FolderLastModified = pDirectory.LastWriteTime

        Dim tmpSStates_GroupedBySerial As IEnumerable(Of IGrouping(Of String, FileInfo)) = pDirectory.EnumerateFiles().Where(
            Function(item) {My.Settings.PCSX2_SStateExt, My.Settings.PCSX2_SStateExtBackup}.Contains(item.Extension.ToLower)
                ).GroupBy(Function(item) Savestate.GetSerial(item.Name))


        'Raggruppo le FileInfo sui savestates, che ottengo con GetFiles, per seriale utilizzando LINQ GroupBy

        For Each GroupedBySerial_Item In tmpSStates_GroupedBySerial
            'Creo una lista temporanea di FileInfo partendo dai FileInfo del gruppo, perché non posso fare conversione diretta
            Dim tmpSStatesList As New Dictionary(Of String, Savestate)
            For Each tmpFileInfo As FileInfo In GroupedBySerial_Item
                Dim tmpItem As New Savestate With {
                    .Name = tmpFileInfo.Name,
                    .Extension = tmpFileInfo.Extension,
                    .Length = tmpFileInfo.Length,
                    .LastWriteTime = tmpFileInfo.LastWriteTime}
                tmpItem.Slot = tmpItem.GetSlot().ToString
                tmpItem.Backup = tmpItem.GetTypeB()

                If My.Settings.SStatesMan_SStatesVersionExtract Then
                    tmpItem.Version = mdlSimpleZipExtractor.ExtractFirstFile(tmpFileInfo)
                    For i As Integer = 0 To PCSX2_VersionDB.DB.Count - 1
                        If PCSX2_VersionDB.DB(i).version.ToUpper = tmpItem.Version.ToUpper Then
                            If i > 0 Then
                                tmpItem.Version &= " (r" & PCSX2_VersionDB.DB(i).minrevision.ToString & ">" & (PCSX2_VersionDB.DB(i - 1).minrevision - 1).ToString & ")"
                            Else
                                tmpItem.Version &= " (r" & PCSX2_VersionDB.DB(i).minrevision.ToString & ">current)"
                            End If
                        End If
                    Next
                Else : tmpItem.Version = "-"
                End If
                tmpSStatesList.Add(tmpFileInfo.Name, tmpItem)

            Next

            Dim tmpCurrentGame As New GamesList_Item
            'Per ogni oggetto nel gruppo devo controllare se il seriale è già presente nella GamesList
            If pGamesList.TryGetValue(GroupedBySerial_Item.Key, tmpCurrentGame) Then
                'Se la FileList per quel tipo di file è già presente allora posso assegnare direttamente la lista di FileInfo temporanea creata precedentemente
                tmpCurrentGame.Savestates = tmpSStatesList


            Else
                'Se il seriale non è presente significa che devo creare una nuova voce ed assegnarla alla gameslist
                tmpCurrentGame = New GamesList_Item
                tmpCurrentGame.Savestates = tmpSStatesList
                pGamesList.Add(GroupedBySerial_Item.Key, tmpCurrentGame)

            End If
            'Operazione comune ai due bracci dell'If precedente
            tmpCurrentGame.Savestates_SizeTot = tmpCurrentGame.Savestates.Where(Function(item) item.Value.Extension.Contains(My.Settings.PCSX2_SStateExt)).Sum(Function(item) item.Value.Length)
            tmpCurrentGame.SavestatesBackup_SizeTot = tmpCurrentGame.Savestates.Where(Function(item) item.Value.Extension.Contains(My.Settings.PCSX2_SStateExtBackup)).Sum(Function(item) item.Value.Length)
        Next

    End Sub

    Public Sub SnapsList_Load(ByVal pDirectory As DirectoryInfo,
                              ByRef pGamesList As Dictionary(Of String, GamesList_Item))

        Snaps_FolderLastModified = pDirectory.LastWriteTime

        Dim tmpSnaps_GroupedBySerial As IEnumerable(Of IGrouping(Of String, FileInfo)) = pDirectory.EnumerateFiles().Where(
            Function(item) {".bmp", ".jpg", ".png"}.Contains(item.Extension.ToLower)
                ).GroupBy(Function(item) Snapshot.GetSerial(item.Name))

        'Raggruppo le FileInfo sui savestates, che ottengo con GetFiles, per seriale utilizzando LINQ GroupBy

        For Each GroupedBySerial_Item In tmpSnaps_GroupedBySerial
            'Creo una lista temporanea di FileInfo partendo dai FileInfo del gruppo, perché non posso fare conversione diretta
            Dim tmpSnapsList As New Dictionary(Of String, Snapshot)
            For Each tmpFileInfo As FileInfo In GroupedBySerial_Item
                Dim tmpItem As New Snapshot With {.Name = tmpFileInfo.Name, .Extension = tmpFileInfo.Extension, .Length = tmpFileInfo.Length, .LastWriteTime = tmpFileInfo.LastWriteTime}
                tmpSnapsList.Add(tmpFileInfo.Name, tmpItem)

            Next

            Dim tmpCurrentGame As New GamesList_Item
            'Per ogni oggetto nel gruppo devo controllare se il seriale è già presente nella GamesList
            If pGamesList.TryGetValue(GroupedBySerial_Item.Key, tmpCurrentGame) Then
                'Se la FileList per quel tipo di file è già presente allora posso assegnare direttamente la lista di FileInfo temporanea creata precedentemente
                tmpCurrentGame.Snapshots = tmpSnapsList


            Else
                'Se il seriale non è presente significa che devo creare una nuova voce ed assegnarla alla gameslist
                tmpCurrentGame = New GamesList_Item
                tmpCurrentGame.Snapshots = tmpSnapsList
                pGamesList.Add(GroupedBySerial_Item.Key, tmpCurrentGame)

            End If
            'Operazione comune ai due bracci dell'If precedente
            tmpCurrentGame.Snapshots_SizeTot = tmpCurrentGame.Snapshots.Sum(Function(Lengthsum) Lengthsum.Value.Length)
        Next

    End Sub

    Private Class VersionDB

        Friend Structure rVersion
            Friend version As String
            Friend minrevision As Integer
        End Structure
        Public Property DB As New List(Of rVersion)

        Public Sub Load()
            If File.Exists(Path.Combine(Application.StartupPath, "Data\ssversion.txt")) Then
                Using tmpStreamReader As New StreamReader(Path.Combine(Application.StartupPath, "Data\ssversion.txt"), System.Text.Encoding.Default)
                    While Not tmpStreamReader.EndOfStream
                        Dim tmpLine As String = tmpStreamReader.ReadLine
                        If Not (tmpLine.StartsWith("'"c)) Then
                            Dim tmpSplittedString As String() = tmpLine.Split(Char.Parse(vbTab))
                            If tmpSplittedString.Count > 1 Then
                                Dim tmpItem As New rVersion With {.version = tmpSplittedString(0)}
                                If Integer.TryParse(tmpSplittedString(1), tmpItem.minrevision) Then
                                    DB.Add(tmpItem)
                                End If
                            End If
                        End If
                    End While

                End Using
            End If
        End Sub
    End Class

End Module
