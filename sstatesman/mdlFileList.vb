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


        Public Function GetSlot() As Int32
            GetSlot = -1
            If Int32.TryParse(Name.Substring(Name.IndexOf("."c, 0) + 1, 2), GetSlot) Then
                Return GetSlot
            End If
            Return -1
        End Function

        Public Function Get_Type() As System.Boolean
            If Extension = My.Settings.PCSX2_SStateExtBackup Then
                Return True
            Else
                Return False
            End If
        End Function

    End Class

    Public Class Snapshot
        Public Property Name As String

        Public Function GetSerial() As String
            Dim SpacePosition As Int32 = Name.IndexOf(" "c, 0)
            If Name.ToLower.StartsWith("gsdx") Then
                Return "GSdX"
            ElseIf SpacePosition > 0 Then
                Return Name.Remove(SpacePosition)
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
        Public Property Snapshots As New Dictionary(Of String, FileInfo)
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

        SStates_FolderLastModified = pDirectory.LastWriteTime

        Dim mySStates_GroupedBySerial = pDirectory.EnumerateFiles().Where(
            Function(item) {My.Settings.PCSX2_SStateExt, My.Settings.PCSX2_SStateExtBackup}.Contains(item.Extension.ToLower)
                ).GroupBy(Function(item) Savestate.GetSerial(item.Name))

        'Raggruppo le FileInfo sui savestates, che ottengo con GetFiles, per seriale utilizzando LINQ GroupBy

        For Each GroupedBySerial_Item In mySStates_GroupedBySerial
            'Creo una lista temporanea di FileInfo partendo dai FileInfo del gruppo, perché non posso fare conversione diretta
            Dim myTmpSStatesList As New Dictionary(Of String, Savestate)
            For Each FileInformation As FileInfo In GroupedBySerial_Item
                Dim newItem As New Savestate With {
                    .Name = FileInformation.Name,
                    .Extension = FileInformation.Extension,
                    .Length = FileInformation.Length,
                    .LastWriteTime = FileInformation.LastWriteTime}
                newItem.Slot = newItem.GetSlot().ToString
                newItem.Backup = newItem.Get_Type()

                If My.Settings.SStatesMan_SStatesVersionExtract Then
                    newItem.Version = mdlSimpleZipExtractor.ExtractFirstFile(FileInformation)
                Else : newItem.Version = "-"
                End If
                myTmpSStatesList.Add(FileInformation.Name, newItem)

            Next

            Dim myCurrentGame As New GamesList_Item
            'Per ogni oggetto nel gruppo devo controllare se il seriale è già presente nella GamesList
            If pGamesList.TryGetValue(GroupedBySerial_Item.Key, myCurrentGame) Then
                'Se la FileList per quel tipo di file è già presente allora posso assegnare direttamente la lista di FileInfo temporanea creata precedentemente
                myCurrentGame.Savestates = myTmpSStatesList


            Else
                'Se il seriale non è presente significa che devo creare una nuova voce ed assegnarla alla gameslist
                myCurrentGame = New GamesList_Item
                myCurrentGame.Savestates = myTmpSStatesList
                pGamesList.Add(GroupedBySerial_Item.Key, myCurrentGame)

            End If
            'Operazione comune ai due bracci dell'If precedente
            myCurrentGame.Savestates_SizeTot = myCurrentGame.Savestates.Where(Function(item) item.Value.Extension.Contains(My.Settings.PCSX2_SStateExt)).Sum(Function(item) item.Value.Length)
            myCurrentGame.SavestatesBackup_SizeTot = myCurrentGame.Savestates.Where(Function(item) item.Value.Extension.Contains(My.Settings.PCSX2_SStateExtBackup)).Sum(Function(item) item.Value.Length)
        Next

    End Sub

    Public Sub SnapsList_Load(ByVal pDirectory As DirectoryInfo,
                              ByRef pGamesList As Dictionary(Of String, GamesList_Item))

        Snaps_FolderLastModified = pDirectory.LastWriteTime

        Dim mySnaps_GroupedBySerial = pDirectory.EnumerateFiles().Where(
            Function(item) {".bmp", ".jpg", ".png"}.Contains(item.Extension.ToLower)
                ).GroupBy(Function(item) Snapshot.GetSerial(item.Name))

        'Raggruppo le FileInfo sui savestates, che ottengo con GetFiles, per seriale utilizzando LINQ GroupBy

        For Each GroupedBySerial_Item In mySnaps_GroupedBySerial
            'Creo una lista temporanea di FileInfo partendo dai FileInfo del gruppo, perché non posso fare conversione diretta
            Dim myTmpSStatesList As New Dictionary(Of String, FileInfo)
            For Each FileInformation As FileInfo In GroupedBySerial_Item
                'Dim tmpPicture As Image = Image.FromStream(New FileStream(FileInformation.FullName, FileMode.Open, FileAccess.Read, FileShare.Read))

                myTmpSStatesList.Add(FileInformation.Name, FileInformation)

            Next

            Dim myCurrentGame As New GamesList_Item
            'Per ogni oggetto nel gruppo devo controllare se il seriale è già presente nella GamesList
            If pGamesList.TryGetValue(GroupedBySerial_Item.Key, myCurrentGame) Then
                'Se la FileList per quel tipo di file è già presente allora posso assegnare direttamente la lista di FileInfo temporanea creata precedentemente
                myCurrentGame.Snapshots = myTmpSStatesList


            Else
                'Se il seriale non è presente significa che devo creare una nuova voce ed assegnarla alla gameslist
                myCurrentGame = New GamesList_Item
                myCurrentGame.Snapshots = myTmpSStatesList
                pGamesList.Add(GroupedBySerial_Item.Key, myCurrentGame)

            End If
            'Operazione comune ai due bracci dell'If precedente
            myCurrentGame.Snapshots_SizeTot = myCurrentGame.Snapshots.Sum(Function(Lengthsum) Lengthsum.Value.Length)
        Next

    End Sub

End Module
