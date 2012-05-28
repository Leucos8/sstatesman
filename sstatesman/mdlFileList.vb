Imports System.IO

Module mdlFileList
    Public Class rFileList
        Friend Property InfoList As Dictionary(Of String, FileInfo)
        Friend Property SizeTot As Int64 = 0
    End Class

    Public GamesList As New Dictionary(Of String, Dictionary(Of ListKeys, rFileList))

    Public Enum ListKeys As Int32
        Savestates
        Savestates_Backup
        Savestates_Stored
        Screenshots
    End Enum

    Public GamesList_Status As mdlMain.LoadStatus = LoadStatus.StatusNotLoaded
    Public SStates_FolderLastModified As DateTime
    Public SStatesStored_FolderLastModified As DateTime
    Public SShots_FolderLastModified As DateTime

    Public Function GamesList_LoadAll(ByVal pPath As String,
                                      ByRef pGamesList As Dictionary(Of String, Dictionary(Of ListKeys, rFileList))
                                      ) As LoadStatus

        pGamesList.Clear()

        Dim sstates_DirectoryInfo As New DirectoryInfo(pPath)

        FileList_Load(sstates_DirectoryInfo,
                      ListKeys.Savestates,
                      String.Concat("*", My.Settings.PCSX2_SStateExt),
                      pGamesList)

        FileList_Load(sstates_DirectoryInfo,
                      ListKeys.Savestates_Backup,
                      String.Concat("*", My.Settings.PCSX2_SStateExtBackup),
                      pGamesList)
        If pGamesList.Count = 0 Then
            mdlMain.WriteToConsole("GamesList", "LoadAll", "Load complete. Loaded 0 records. The array is empty")
            Return LoadStatus.StatusEmpty
        Else
            mdlMain.WriteToConsole("GamesList", "LoadAll", String.Format("Load complete. Loaded {0:#,##0} records.", pGamesList.Count))
            Return LoadStatus.StatusLoadedOK
        End If
    End Function

    Public Sub FileList_Load(ByVal pDirectory As DirectoryInfo,
                             ByVal pFileType As ListKeys,
                             ByVal pSearchPattern As String,
                             ByRef pGamesList As Dictionary(Of String, Dictionary(Of ListKeys, rFileList))
                             )

        Dim mySStates_GroupedBySerial = pDirectory.GetFiles(
            pSearchPattern).GroupBy(
            Function(aws) SStates_GetSerial(aws.Name))

        'Raggruppo le FileInfo sui savestates, che ottengo con GetFiles, per seriale utilizzando LINQ GroupBy

        For Each GroupItem In mySStates_GroupedBySerial

            'Creo una lista temporanea di FileInfo partendo dai FileInfo del gruppo, perché non posso fare conversione diretta
            Dim myTmpFileList As New Dictionary(Of String, FileInfo)
            For Each FileInformation As FileInfo In GroupItem
                myTmpFileList.Add(FileInformation.Name, FileInformation)
            Next

            Dim myCurrentGame As New Dictionary(Of ListKeys, rFileList)
            'Per ogni oggetto nel gruppo devo controllare se il seriale è già presente nella GameList
            If pGamesList.TryGetValue(GroupItem.Key, myCurrentGame) Then
                'Se il seriale è già presente devo controllare se è già presente una FileList del tipo di file a cui sono interessato, in questo caso i normali salvataggi di stato
                Dim myCurrentFileList As New rFileList
                If myCurrentGame.TryGetValue(pFileType, myCurrentFileList) Then
                    'Se la FileList per quel tipo di file è già presente allora posso assegnare direttamente la lista di FileInfo temporanea creata precedentemente
                    myCurrentFileList.InfoList = myTmpFileList
                Else
                    'Altrimenti devo creare un nuovo record rFileList per il tipo a cui sono interessato e assegno la lista di FileInfo temporanea
                    myCurrentFileList = New rFileList With {.InfoList = myTmpFileList}
                    myCurrentGame.Add(pFileType, myCurrentFileList)
                End If
                'Operazione comune ai due bracci dell'If precedente
                myCurrentFileList.SizeTot = myCurrentFileList.InfoList.Sum(Function(fInfo) fInfo.Value.Length)

            Else
                'Se il seriale non è presente significa che non ho neanche problemi per rFileList (che viene creata in questo momento), procedo quindi all'aggiunta e assegnazione
                myCurrentGame = New Dictionary(Of ListKeys, rFileList)
                myCurrentGame.Add(pFileType,
                                  New rFileList With {.InfoList = myTmpFileList,
                                                      .SizeTot = .InfoList.Sum(Function(fInfo) fInfo.Value.Length)})
                pGamesList.Add(GroupItem.Key, myCurrentGame)

            End If
        Next

    End Sub

    Public Function SStates_GetSerial(ByVal pFileName As String) As String
        SStates_GetSerial = pFileName.Remove(pFileName.IndexOf(" ", 0))
    End Function

    Public Function SStates_GetSlot(ByVal pFileName As String) As Int32
        SStates_GetSlot = -1
        If Int32.TryParse(pFileName.Substring(pFileName.IndexOf(".", 0) + 1, 2), SStates_GetSlot) Then
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
