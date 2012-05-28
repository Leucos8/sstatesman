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

Module mdlSStatesList

    'Public Class rSStatesIndex                  'Record declaration
    '    Friend Property SStates_List As List(Of FileInfo)
    '    Friend Property SStates_SizeTot As Int64      'Total size in bytes of the savestate files
    '    Friend Property SStatesBck_List As List(Of FileInfo)
    '    Friend Property SStatesBck_SizeTot As Int64  'Total size in bytes of the savestate backup files
    '    Friend Property SStatesStored_List As List(Of FileInfo)
    '    Friend Property SStatesStored_SizeTot As Int64
    'End Class

    'Public SStatesIndex As New Dictionary(Of String, mdlSStatesList.rSStatesIndex)

    'Public SStatesList_Status As mdlMain.LoadStatus = LoadStatus.StatusNotLoaded
    'Public SStates_FolderLastModified As DateTime

    'Public Function SStatesList_Load(ByVal pPath As String,
    '                                 ByRef pSStatesIndex As Dictionary(Of String, mdlSStatesList.rSStatesIndex)
    '                                 ) As mdlMain.LoadStatus
    '    'Creates the array from the scanned folder
    '    '   ByVal   pPath                       Path to search in
    '    '   ByRef   pSStatesIndex               The dinamic array of the files
    '    'Return Value: array status/lenght

    '    mdlMain.WriteToConsole("SStatesList", "Load", String.Format("Scanning files in ""{0}"".", pPath))

    '    pSStatesIndex.Clear()

    '    Dim sstates_DirectoryInfo As New DirectoryInfo(pPath)
    '    SStates_FolderLastModified = sstates_DirectoryInfo.LastWriteTime


    '    Dim myCurrentSerial As String = ""

    '    For Each myFileFound As FileInfo In sstates_DirectoryInfo.GetFiles

    '        Dim myCurrentRecord As New mdlSStatesList.rSStatesIndex

    '        If myFileFound.Extension = My.Settings.PCSX2_SStateExt Or myFileFound.Extension = My.Settings.PCSX2_SStateExtBackup Then
    '            If SStates_GetSlot(myFileFound.Name) >= 0 Then
    '                If Not (pSStatesIndex.TryGetValue(SStates_GetSerial(myFileFound.Name), myCurrentRecord)) Then

    '                    myCurrentRecord = New mdlSStatesList.rSStatesIndex With {.SStates_List = New List(Of FileInfo)(10),
    '                                                                            .SStates_SizeTot = 0,
    '                                                                            .SStatesBck_List = New List(Of FileInfo)(10),
    '                                                                            .SStatesBck_SizeTot = 0,
    '                                                                            .SStatesStored_List = New List(Of FileInfo)(20),
    '                                                                            .SStatesStored_SizeTot = 0}

    '                    If pSStatesIndex.Count > 0 Then
    '                        With pSStatesIndex(myCurrentSerial)
    '                            .SStates_List.TrimExcess()
    '                            .SStatesBck_List.TrimExcess()
    '                            .SStatesStored_List.TrimExcess()
    '                            .SStates_SizeTot = .SStates_List.Sum(Function(info As FileInfo) info.Length)
    '                            .SStatesBck_SizeTot = .SStatesBck_List.Sum(Function(info As FileInfo) info.Length)
    '                        End With


    '                        mdlMain.WriteToConsole("SStatesList", "Load", String.Format(
    '                                               "Added game ""{0}"", with {1}/{2} savestates, {3}/{4} backups, {5}/{6} stored.",
    '                                               myCurrentSerial,
    '                                               pSStatesIndex(myCurrentSerial).SStates_List.Count, pSStatesIndex(myCurrentSerial).SStates_List.Capacity,
    '                                               pSStatesIndex(myCurrentSerial).SStatesBck_List.Count, pSStatesIndex(myCurrentSerial).SStatesBck_List.Capacity,
    '                                               pSStatesIndex(myCurrentSerial).SStatesStored_List.Count, pSStatesIndex(myCurrentSerial).SStatesStored_List.Capacity))
    '                    End If



    '                    myCurrentSerial = SStates_GetSerial(myFileFound.Name)
    '                    pSStatesIndex.Add(myCurrentSerial, myCurrentRecord)

    '                End If

    '                If Not (SStates_GetType(myFileFound.Extension)) Then
    '                    myCurrentRecord.SStates_List.Add(myFileFound)
    '                    'mdlMain.WriteToConsole("SStatesList", "Load", String.Format("Added sstates ""{0}""", myFileFound.Name))
    '                Else
    '                    myCurrentRecord.SStatesBck_List.Add(myFileFound)
    '                    'mdlMain.WriteToConsole("SStatesList", "Load", String.Format("Added backup ""{0}""", myFileFound.Name))
    '                End If
    '            End If

    '        Else
    '            mdlMain.WriteToConsole("SStatesList", "Load",
    '                                   String.Format("A '{0}' file is being skipped, unable to determine the saveslot number: {1}",
    '                                                 myFileFound.Extension,
    '                                                 myFileFound.Name))
    '        End If

    '    Next
    '    If pSStatesIndex.Count = 0 Then
    '        mdlMain.WriteToConsole("SStatesList", "SStatesList_Load", "Load complete. Loaded 0 records. The array is empty")
    '        SStatesList_Load = LoadStatus.StatusEmpty
    '    Else
    '        mdlMain.WriteToConsole("SStatesList", "SStatesList_Load", String.Format("Load complete. Loaded {0:#,##0} records.", pSStatesIndex.Count))
    '        SStatesList_Load = LoadStatus.StatusLoadedOK
    '    End If
    'End Function

    'Public Function SStatesList_LoadAll(ByVal pPath As String,
    '                                    ByRef pSStatesIndex As Dictionary(Of String, mdlSStatesList.rSStatesIndex)
    '                                    ) As mdlMain.LoadStatus
    '    pSStatesIndex.Clear()
    '    Dim sstates_DirectoryInfo As New DirectoryInfo(pPath)
    '    SStates_FolderLastModified = sstates_DirectoryInfo.LastWriteTime


    '    Dim mySerial = sstates_DirectoryInfo.GetFiles(String.Concat("*", My.Settings.PCSX2_SStateExt)).GroupBy(Function(aws) SStates_GetSerial(aws.Name))

    '    For Each serial In mySerial
    '        Dim myTmpRecord As New rSStatesIndex
    '        If pSStatesIndex.TryGetValue(serial.Key, myTmpRecord) Then
    '            myTmpRecord.SStates_List = serial
    '        End If

    '        mdlMain.WriteToConsole("myAws", "Load", serial.Key)
    '    Next



    '    Return LoadStatus.StatusLoadedOK
    'End Function

    'Public Function SStatesList_Load2(ByVal pPath As DirectoryInfo, ByVal pSearchPattern As String,
    '                                ByRef pSStatesIndex As Dictionary(Of String, mdlSStatesList.rSStatesIndex),
    '                                ByVal pListToAdd As Int32
    '                                ) As mdlMain.LoadStatus
    '    'Creates the array from the scanned folder
    '    '   ByVal   pPath                       Path to search in
    '    '   ByVal   pSearchPattern              Specifies which files will be considered
    '    '   ByRef   pSStatesIndex               The dinamic array of the files
    '    'Return Value: array status/lenght

    '    mdlMain.WriteToConsole("SStatesList", "Load", String.Format("Searching files ""{0}"" in ""{1}"".", pSearchPattern, pPath))

    '    Dim myCurrentSerial As String = ""

    '    For Each myFileFound As FileInfo In pPath.GetFiles(pSearchPattern)

    '        Dim myCurrentRecord As New rSStatesIndex

    '        If SStates_GetSlot(myFileFound.Name) >= 0 Then
    '            'myCurrentSerial = 
    '            If Not (pSStatesIndex.TryGetValue(SStates_GetSerial(myFileFound.Name), myCurrentRecord)) Then

    '                myCurrentRecord = New rSStatesIndex With {.SStates_List = New List(Of FileInfo),
    '                                                          .SStates_SizeTot = 0,
    '                                                          .SStatesBck_List = New List(Of FileInfo),
    '                                                          .SStatesBck_SizeTot = 0,
    '                                                          .SStatesStored_List = New List(Of FileInfo),
    '                                                          .SStatesStored_SizeTot = 0}

    '                If pSStatesIndex.Count > 0 Then
    '                    With pSStatesIndex(myCurrentSerial)
    '                        .SStates_SizeTot = pSStatesIndex(myCurrentSerial).SStates_List.Sum(Function(info As FileInfo) info.Length)
    '                        .SStatesBck_List.Sum(Function(info As FileInfo) info.Length)
    '                    End With


    '                    mdlMain.WriteToConsole("SStatesList", "Load", String.Format(
    '                                           "Added game ""{0}"", with {1} savestates, {2} backups, {3} stored.",
    '                                           myCurrentSerial,
    '                                           pSStatesIndex(myCurrentSerial).SStates_List.Count,
    '                                           pSStatesIndex(myCurrentSerial).SStatesBck_List.Count,
    '                                           pSStatesIndex(myCurrentSerial).SStatesStored_List.Count))
    '                End If
    '                myCurrentSerial = SStates_GetSerial(myFileFound.Name)
    '                pSStatesIndex.Add(myCurrentSerial, myCurrentRecord)




    '            End If

    '            pSStatesIndex(myCurrentSerial).SStates_List.Add(myFileFound)
    '            'mdlMain.WriteToConsole("SStatesList", "Load", String.Format("Added sstates ""{0}""", myFileFound.Name))

    '        Else
    '            mdlMain.WriteToConsole("SStatesList", "Load",
    '                                   String.Format("A '{0}' file is being skipped, unable to determine the saveslot number: {1}",
    '                                                 myFileFound.Extension,
    '                                                 myFileFound.Name))
    '        End If

    '    Next
    '    If pSStatesIndex.Count = 0 Then
    '        mdlMain.WriteToConsole("SStatesList", "SStatesList_Load", "Load complete. Loaded 0 records. The array is empty")
    '        SStatesList_Load2 = LoadStatus.StatusEmpty
    '    Else
    '        mdlMain.WriteToConsole("SStatesList", "SStatesList_Load", String.Format("Load complete. Loaded {0:#,##0} records.", pSStatesIndex.Count))
    '        SStatesList_Load2 = LoadStatus.StatusLoadedOK
    '    End If
    'End Function


    'Public Function SStates_GetSerial(ByVal pFileName As String) As String
    '    SStates_GetSerial = pFileName.Remove(pFileName.IndexOf(" ", 0))
    'End Function

    'Public Function SStates_GetSlot(ByVal pFileName As String) As Int32
    '    SStates_GetSlot = -1
    '    If Int32.TryParse(pFileName.Substring(pFileName.IndexOf(".", 0) + 1, 2), SStates_GetSlot) Then
    '        Return SStates_GetSlot
    '    End If
    'End Function

    'Public Function SStates_GetType(ByVal pExtension As System.String) As System.Boolean
    '    If pExtension = My.Settings.PCSX2_SStateExtBackup Then
    '        Return True
    '    Else
    '        Return False
    '    End If
    'End Function


    'Public Sub SStatesList_ExportTxt(ByVal pSStatesListExport_Loc As String, _
    '                                 ByVal pSepStyle As String, _
    '                                 ByRef pSStatesList As Dictionary(Of String, mdlSStatesList.rSStatesIndex))
    '    'Export the array to a text file (you could import in Excel and Access)
    '    '   ByVal   pSStatesListExport_Loc      Path and file name of the saved file
    '    '   ByVal   pSepStyle                   Separator character to be use in the export
    '    '   ByRef   pSStatesList()              The dinamic array of the GameDB to search in

    '    If pSStatesList.Count > 0 Then
    '        Using FileSStatesList_Tab_Writer As New StreamWriter(pSStatesListExport_Loc, False)
    '            FileSStatesList_Tab_Writer.WriteLine(String.Concat("Serial", pSepStyle, "Slot", pSepStyle, "Backup", pSepStyle, "Filename", pSepStyle, "Size", pSepStyle, "Created", pSepStyle, "Modified", pSepStyle, "Accessed", pSepStyle, "Attributes"))
    '            For Each SStatesGame As KeyValuePair(Of String, mdlSStatesList.rSStatesIndex) In pSStatesList
    '                For Each SStatesFile As FileInfo In SStatesGame.Value.SStates_List
    '                    FileSStatesList_Tab_Writer.WriteLine(String.Concat(SStates_GetSerial(SStatesFile.Name), pSepStyle,
    '                                                                       SStates_GetSlot(SStatesFile.Name).ToString, pSepStyle,
    '                                                                       SStates_GetType(SStatesFile.Name).ToString, pSepStyle,
    '                                                                       SStatesFile.Name, pSepStyle,
    '                                                                       SStatesFile.Length.ToString, pSepStyle,
    '                                                                       SStatesFile.CreationTime.ToString, pSepStyle,
    '                                                                       SStatesFile.LastWriteTime.ToString, pSepStyle,
    '                                                                       SStatesFile.LastAccessTime.ToString, pSepStyle,
    '                                                                       SStatesFile.Attributes.ToString))
    '                Next
    '            Next
    '            FileSStatesList_Tab_Writer.Close()
    '        End Using
    '    End If
    'End Sub

End Module
