﻿'   SStatesMan - a savestate managing tool for PCSX2
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
    End Class

    Public Class GamesList_Item
        Public Property Savestates As New Dictionary(Of String, Savestate)
        'Public Property Savestates_Count As Int32 = 0
        Public Property Savestates_SizeTot As UInt64 = 0
        'Public Property Savestates_Backup As New Dictionary(Of String, Savestate)
        'Public Property SavestatesBackup_Count As Int32 = 0
        Public Property SavestatesBackup_SizeTot As UInt64 = 0
    End Class

    Public GamesList As New Dictionary(Of String, GamesList_Item)
    Public GamesList_Status As mdlMain.LoadStatus = LoadStatus.StatusNotLoaded
    Public GameList_LoadTime As Long
    Public SStates_FolderLastModified As DateTime
    'Public SStatesStored_FolderLastModified As DateTime
    'Public SShots_FolderLastModified As DateTime

    Public Function GamesList_LoadAll(ByVal pPath As String,
                                      ByRef pGamesList As Dictionary(Of String, GamesList_Item)
                                      ) As LoadStatus

        Dim sw As New Stopwatch
        sw.Start()

        pGamesList.Clear()

        Dim sstates_DirectoryInfo As New DirectoryInfo(pPath)

        SStatesList_Load(sstates_DirectoryInfo,
                         pGamesList)

        sw.Stop()
        GameList_LoadTime = sw.ElapsedMilliseconds
        If pGamesList.Count = 0 Then
            mdlMain.AppendToLog("FilesList", "LoadAll", "No games, the list is empty.", GameList_LoadTime)
            Return LoadStatus.StatusEmpty
        Else
            mdlMain.AppendToLog("FilesList", "LoadAll", String.Format("Loaded {0:N0} games.", pGamesList.Count), GameList_LoadTime)
            Return LoadStatus.StatusLoadedOK
        End If
    End Function

    Public Sub SStatesList_Load(ByVal pDirectory As DirectoryInfo,
                                ByRef pGamesList As Dictionary(Of String, GamesList_Item))

        SStates_FolderLastModified = pDirectory.LastWriteTime

        Dim mySStates_GroupedBySerial = pDirectory.EnumerateFiles().Where(
            Function(extfilter) {My.Settings.PCSX2_SStateExt, My.Settings.PCSX2_SStateExtBackup}.Contains(extfilter.Extension.ToLower)
                ).GroupBy(Function(aws) SStates_GetSerial(aws.Name))

        'Raggruppo le FileInfo sui savestates, che ottengo con GetFiles, per seriale utilizzando LINQ GroupBy

        For Each GroupedBySerial_Item In mySStates_GroupedBySerial
            'Creo una lista temporanea di FileInfo partendo dai FileInfo del gruppo, perché non posso fare conversione diretta
            Dim myTmpSStatesList As New Dictionary(Of String, Savestate)
            For Each FileInformation As FileInfo In GroupedBySerial_Item
                Dim newItem As New Savestate With {
                    .Name = FileInformation.Name,
                    .Extension = FileInformation.Extension,
                    .Length = FileInformation.Length,
                    .LastWriteTime = FileInformation.LastWriteTime,
                    .Slot = SStates_GetSlot(FileInformation.Name).ToString,
                    .Backup = SStates_GetType(FileInformation.Extension)}
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
            'myCurrentGame.Savestates_Count = myCurrentGame.Savestates.Where(Function(filter) filter.Value.Extension.Contains(My.Settings.PCSX2_SStateExt)).Count
            myCurrentGame.Savestates_SizeTot = myCurrentGame.Savestates.Where(Function(filter) filter.Value.Extension.Contains(My.Settings.PCSX2_SStateExt)).Sum(Function(Lengthsum) Lengthsum.Value.Length)
            'myCurrentGame.SavestatesBackup_Count = myCurrentGame.Savestates.Where(Function(filter) filter.Value.Extension.Contains(My.Settings.PCSX2_SStateExtBackup)).Count
            myCurrentGame.SavestatesBackup_SizeTot = myCurrentGame.Savestates.Where(Function(filter) filter.Value.Extension.Contains(My.Settings.PCSX2_SStateExtBackup)).Sum(Function(Lengthsum) Lengthsum.Value.Length)
        Next

    End Sub

    Public Function SStates_GetSerial(ByVal pFileName As String) As String
        Dim SpacePosition As Int32 = pFileName.IndexOf(" "c, 0)
        If SpacePosition > 0 Then
            SStates_GetSerial = pFileName.Remove(SpacePosition)
        Else
            SStates_GetSerial = pFileName
        End If
    End Function

    Public Function SStates_GetSlot(ByVal pFileName As String) As Int32
        SStates_GetSlot = -1
        If Int32.TryParse(pFileName.Substring(pFileName.IndexOf("."c, 0) + 1, 2), SStates_GetSlot) Then
            Return SStates_GetSlot
        End If
    End Function

    Public Function SStates_GetType(ByVal pExtension As System.String) As System.Boolean
        If pExtension = My.Settings.PCSX2_SStateExtBackup Then
            Return True
        Else
            Return False
        End If
    End Function

End Module
