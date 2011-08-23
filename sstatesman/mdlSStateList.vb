'   SStatesMan - Savestate Manager for PCSX2 0.9.8
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
Option Explicit On
Module mdlSStateList

    Public Const cSStateListFileTab = "\SStateListTmp.txt"  'Converted GameIndex (with DOS/Win endline) location e filename (tab separated value)

    Public Structure rSStateList
        Friend FileInfo As System.IO.FileInfo
        Friend SStateSlot As System.Byte
        Friend SStateBackup As System.Boolean
        Friend SStateSerial As System.String
        Friend FDeleted As System.Boolean
        Friend arrayPosition As System.Int64
    End Structure
    Public SStateList() As rSStateList
    Public SStateList_Pos As System.Int64
    Public SStateList_Len As System.Int64

    Public SStateListExtract() As rSStateList
    Public SStateListExtract_Pos As System.Int64
    Public SStateListExtract_Len As System.Int64

    Public Structure rSStateGameIndex
        Friend GameInfo As rGameDb
        Friend SStatesTotalSize As System.Int64
        Friend SStatesBackupTotalSize As System.Int64
    End Structure
    Public SStateGameIndex() As rSStateGameIndex
    Public SStateGameIndex_Pos As System.Int64
    Public SStateGameIndex_Len As System.Int64

    Public Function SStateList_Load1(ByRef pFileList() As System.IO.FileInfo, _
                                    ByVal pFileList_Pos As System.Int64, _
                                    ByVal pFileList_Len As System.Int64, _
                                    ByRef pSStateList() As rSStateList, _
                                    ByRef pSStateList_Pos As System.Int64 _
                                    ) As System.Int64
        'Creates the array from the array of found files (aFileList)
        '   ByVal   pFileList()                The array that contains the list of files found in the SStates folder (input array)
        '   ByVal   pFileList_Pos              Index of the input array
        '   ByVal   pFileList_Len              Occupied records of the input array
        '   ByRef   pSStateList()                The dinamic array, list of the file found (output array)
        '   ByRef   pSStateList_Pos              Index used in the output array
        'Return Value: array status/lenght

        pSStateList_Pos = mdlSStateList.SStateList_Unload(pSStateList, pSStateList_Pos)
        pSStateList_Pos = -1

        For pFileList_Pos = 0 To pFileList_Len
            If (pFileList(pFileList_Pos).Extension = mdlMain.SState_Ext) Or _
               (pFileList(pFileList_Pos).Extension = mdlMain.SState_ExtBackup) Then

                pSStateList_Pos = pSStateList_Pos + 1

                pSStateList(pSStateList_Pos).SStateSlot = CInt(Mid(pFileList(pFileList_Pos).Name, _
                                                                   InStr(pFileList(pFileList_Pos).Name, ".") + 1, 2))   'Stores the slot value
                If Err.Number = 13 Or (Not (pSStateList(pSStateList_Pos).SStateSlot >= 0) _
                                       And (pSStateList(pSStateList_Pos).SStateSlot <= 9)) Then     'Invalid parameter
                    MsgBox("A " & mdlMain.SState_Ext & " file is being skipped, unable to determine the saveslot number: " _
                           & pFileList(pFileList_Pos).Name & vbCrLf & Err.Number & " " & Err.Description, vbCritical, "Errore")
                    Err.Clear()
                    pSStateList_Pos = pSStateList_Pos - 1
                    GoTo Purge
                End If
                pSStateList(pSStateList_Pos).FileInfo = pFileList(pFileList_Pos)    'Stores the fileinfo
                pSStateList(pSStateList_Pos).SStateSerial = Left(pSStateList(pSStateList_Pos).FileInfo.Name, _
                                                                 InStr(pSStateList(pSStateList_Pos).FileInfo.Name, " ") - 1)    'Stores the serial

                pSStateList(pSStateList_Pos).FDeleted = False                   'The underlying file is not deleted
                pSStateList(pSStateList_Pos).arrayPosition = pSStateList_Pos    'Array position, for reference after the extraction
                Select Case pSStateList(pSStateList_Pos).FileInfo.Extension
                    Case mdlMain.SState_Ext
                        pSStateList(pSStateList_Pos).SStateBackup = False
                    Case mdlMain.SState_ExtBackup
                        pSStateList(pSStateList_Pos).SStateBackup = True
                End Select

                If (UBound(pSStateList) - pSStateList_Pos) <= 2 Then            'Resize the array when needed
                    ReDim Preserve pSStateList(0 To UBound(pSStateList) + 4)
                End If
            End If
Purge:
        Next pFileList_Pos
        SStateList_Load1 = pSStateList_Pos

    End Function

    Public Function SStateList_Load2(ByVal pPath As System.String, _
                                  ByRef pSStateList() As rSStateList, _
                                  ByRef pSStateList_Pos As System.Int64 _
                                  ) As System.Int64
        'Creates the array from the scanned folder
        '   ByVal   pPath                       Path to search in
        '   ByRef   pFindFile()                 The dinamic array of the files
        '   ByVal   pFindFileDbPos              Index used in the array

        'Return Value: array status/lenght
        Dim FileTmp As System.IO.FileInfo
        pSStateList_Pos = SStateList_Unload(pSStateList, pSStateList_Pos)

        For Each FileFound As System.String In My.Computer.FileSystem.GetFiles(pPath)
            FileTmp = My.Computer.FileSystem.GetFileInfo(FileFound)
            If FileTmp.Extension = mdlMain.SState_Ext Or FileTmp.Extension = mdlMain.SState_ExtBackup Then
                If (pSStateList.GetUpperBound(0) - pSStateList_Pos) <= 2 Then            'Resize of the array. But not too often
                    ReDim Preserve pSStateList(0 To pSStateList.GetUpperBound(0) + 4)
                End If

                pSStateList_Pos = pSStateList_Pos + 1
                pSStateList(pSStateList_Pos).FileInfo = My.Computer.FileSystem.GetFileInfo(FileFound)


                pSStateList(pSStateList_Pos).SStateSlot = CInt(Mid(pSStateList(pSStateList_Pos).FileInfo.Name, _
                                                                   InStr(pSStateList(pSStateList_Pos).FileInfo.Name, ".") + 1, 2))   'Stores the slot value
                If Err.Number = 13 Or (Not (pSStateList(pSStateList_Pos).SStateSlot >= 0) _
                                       And (pSStateList(pSStateList_Pos).SStateSlot <= 9)) Then     'Invalid parameter
                    MsgBox("A " & mdlMain.SState_Ext & " file is being skipped, unable to determine the saveslot number: " _
                           & pSStateList(pSStateList_Pos).FileInfo.Name & vbCrLf & Err.Number & " " & Err.Description, vbCritical, "Errore")
                    Err.Clear()
                    pSStateList_Pos = pSStateList_Pos - 1
                    GoTo Purge
                End If
                pSStateList(pSStateList_Pos).SStateSerial = Left(pSStateList(pSStateList_Pos).FileInfo.Name, _
                                                                 InStr(pSStateList(pSStateList_Pos).FileInfo.Name, " ") - 1)    'Stores the serial

                pSStateList(pSStateList_Pos).FDeleted = False                   'The underlying file is not deleted
                pSStateList(pSStateList_Pos).arrayPosition = pSStateList_Pos    'Array position, for reference after the extraction
                Select Case pSStateList(pSStateList_Pos).FileInfo.Extension
                    Case mdlMain.SState_Ext
                        pSStateList(pSStateList_Pos).SStateBackup = False
                    Case mdlMain.SState_ExtBackup
                        pSStateList(pSStateList_Pos).SStateBackup = True
                End Select

            End If
Purge:
        Next
        SStateList_Load2 = pSStateList_Pos
        pSStateList_Pos = 0
    End Function


    Public Function SStateList_Unload(ByRef pSStateList() As mdlSStateList.rSStateList, _
                                      ByRef pSStateList_Pos As System.Int64 _
                                      ) As System.Int64
        'Clears the array
        '   ByRef   pSStateList()                The dinamic array of the SStateList
        '   ByRef   pSStateList_Pos              Index used in the array
        'Return Value: array status/lenght

        ReDim pSStateList(0 To 4)               'Array start size of pSStateList set to 4
        pSStateList_Pos = -1                    'Array position index starts to 0
        SStateList_Unload = pSStateList_Pos
    End Function

    Public Function SStateList_ExportTxt(ByVal pSStateListExport_Loc As System.String, _
                                       ByVal pSepStyle As System.String, _
                                       ByRef pSStateList() As mdlSStateList.rSStateList, _
                                       ByVal pSStateList_Pos As System.Int64, _
                                       ByVal pSStateList_Len As System.Int64 _
                                       ) As System.Int64
        'Export the array to a text file (you could import in Excel and Access)
        '   ByVal   pSStateListExport_Loc       Path and file name of the saved file
        '   ByVal   pSepStyle                   Separator character to be use in the export
        '   ByRef   pSStateList()               The dinamic array of the GameDB to search in
        '   ByRef   pSStateList_Pos             Index used in the array
        '   byval   pSStateList_Len             Lenght/status of the array

        If pSStateList_Len >= 0 Then
            Using FileSStateList_Tab_Writer = My.Computer.FileSystem.OpenTextFileWriter(pSStateListExport_Loc, False)
                FileSStateList_Tab_Writer.WriteLine("Serial" & pSepStyle & "Slot" & pSepStyle & "Backup" & pSepStyle & "Filename" & pSepStyle & "Size" & pSepStyle & "Created" & pSepStyle & "Modified" & pSepStyle & "Accessed" & pSepStyle & "Attributes")
                For pSStateList_Pos = 0 To pSStateList_Len
                    FileSStateList_Tab_Writer.WriteLine(pSStateList(pSStateList_Pos).SStateSerial & pSepStyle & _
                                                        pSStateList(pSStateList_Pos).SStateSlot & pSepStyle & _
                                                        pSStateList(pSStateList_Pos).SStateBackup & pSepStyle & _
                                                        pSStateList(pSStateList_Pos).FileInfo.Name & pSepStyle & _
                                                        pSStateList(pSStateList_Pos).FileInfo.Length & pSepStyle & _
                                                        pSStateList(pSStateList_Pos).FileInfo.CreationTime & pSepStyle & _
                                                        pSStateList(pSStateList_Pos).FileInfo.LastWriteTime & pSepStyle & _
                                                        pSStateList(pSStateList_Pos).FileInfo.LastAccessTime & pSepStyle & _
                                                        pSStateList(pSStateList_Pos).FileInfo.Attributes)
                Next pSStateList_Pos
            End Using
        End If
        SStateList_ExportTxt = 0
    End Function

    Public Function SStateList_ExtractBySerial(ByRef pSerial As System.String, _
                                               ByRef pSStateList() As mdlSStateList.rSStateList, _
                                               ByRef pSStateList_Pos As System.Int64, _
                                               ByVal pSStateList_Len As System.Int64, _
                                               ByRef pSStateListExtract() As mdlSStateList.rSStateList, _
                                               ByRef pSStateListExtract_Pos As System.Int64 _
                                               ) As System.Int64
        'Extract from the input array an array with the savestates that matches the serial
        '   ByRef   pSerial                     Serial to search
        '   ByRef   pSStateList()               The dinamic array of the SStateList to search in (input)
        '   ByVal   pSStateList_Pos             Index used in the array (input)
        '   ByVal   pSStateList_Len             Lenght/status of the array (input)
        '   ByRef   pSStateListExtract()        The array extracted (output)
        '   ByRef   pSStateListExtract_Pos      Index used in the array (output)
        'Return Value: Array status/lenght

        If Not (pSerial = "") And Not (pSStateList_Len = 0) Then
            SStateList_Unload(pSStateListExtract, pSStateListExtract_Pos)
            For pSStateList_Pos = 0 To pSStateList_Len
                If pSStateList(pSStateList_Pos).SStateSerial Like pSerial Then
                    pSStateListExtract_Pos = pSStateListExtract_Pos + 1
                    If (UBound(pSStateListExtract) - pSStateListExtract_Pos) <= 2 Then           'Resize the array when needed
                        ReDim Preserve pSStateListExtract(0 To UBound(pSStateListExtract) + 4)
                    End If
                    pSStateListExtract(pSStateListExtract_Pos) = pSStateList(pSStateList_Pos)
                End If
            Next pSStateList_Pos
            SStateList_ExtractBySerial = pSStateListExtract_Pos
            pSStateListExtract_Pos = 0
        Else
            SStateList_ExtractBySerial = 0
        End If
    End Function

    Public Function SStateGameIndex_Load(ByRef pSStateList() As mdlSStateList.rSStateList, _
                                           ByVal pSStateList_Pos As System.Int64, _
                                           ByVal pSStateList_Len As System.Int64, _
                                           ByRef pGameDb() As mdlGameDb.rGameDb, _
                                           ByRef pGameDb_Pos As System.Int64, _
                                           ByVal pGameDb_Len As System.Int64, _
                                           ByRef pSStateGameIndex() As mdlSStateList.rSStateGameIndex, _
                                           ByRef pSStateGameIndex_Pos As System.Int64 _
                                           ) As System.Int64
        If pSStateList_Len > 0 Then
            pSStateGameIndex_Pos = mdlSStateList.SStateGameIndex_Unload(pSStateGameIndex, pSStateGameIndex_Pos) 'Clears the array
            pSStateGameIndex_Pos = 0        'Position 0
            pSStateGameIndex(pSStateGameIndex_Pos).GameInfo.Serial = "*"
            pSStateGameIndex(pSStateGameIndex_Pos).GameInfo.Name = "(all games)"
            pSStateGameIndex(pSStateGameIndex_Pos).GameInfo.Region = "*"
            pSStateGameIndex(pSStateGameIndex_Pos).GameInfo.RStatus = "0"

            For pSStateList_Pos = 0 To pSStateList_Len
                If Not (pSStateGameIndex(pSStateGameIndex_Pos).GameInfo.Serial Like pSStateList(pSStateList_Pos).SStateSerial) Then
                    If (UBound(pSStateGameIndex) - pSStateGameIndex_Pos) <= 2 Then            'Resize the array when needed
                        ReDim Preserve pSStateGameIndex(0 To UBound(pSStateGameIndex) + 4)
                    End If
                    pSStateGameIndex_Pos = pSStateGameIndex_Pos + 1
                    pSStateGameIndex(pSStateGameIndex_Pos).GameInfo = mdlGameDb.GameDb_SearchSerial(pSStateList(pSStateList_Pos).SStateSerial, _
                                                                                       pGameDb, pGameDb_Pos, pGameDb_Len)

                End If
                If pSStateList(pSStateList_Pos).SStateBackup = False Then
                    pSStateGameIndex(pSStateGameIndex_Pos).SStatesTotalSize = pSStateGameIndex(pSStateGameIndex_Pos).SStatesTotalSize + pSStateList(pSStateList_Pos).FileInfo.Length
                    pSStateGameIndex(0).SStatesTotalSize = pSStateGameIndex(0).SStatesTotalSize + pSStateList(pSStateList_Pos).FileInfo.Length
                Else
                    pSStateGameIndex(pSStateGameIndex_Pos).SStatesBackupTotalSize = pSStateGameIndex(pSStateGameIndex_Pos).SStatesBackupTotalSize + pSStateList(pSStateList_Pos).FileInfo.Length
                    pSStateGameIndex(0).SStatesBackupTotalSize = pSStateGameIndex(0).SStatesBackupTotalSize + pSStateList(pSStateList_Pos).FileInfo.Length
                End If
            Next pSStateList_Pos
            SStateGameIndex_Load = pSStateGameIndex_Pos
        Else
            SStateGameIndex_Load = 0

        End If
    End Function

    Public Function SStateGameIndex_Unload(ByRef pSStateGameIndex() As mdlSStateList.rSStateGameIndex, _
                                               ByRef SStateGameIndex_Pos As System.Int64 _
                                      ) As System.Int64
        'Clears the array
        '   ByRef   pSStateList()                The dinamic array of the SStateList
        '   ByRef   pSStateList_Pos              Index used in the array
        'Return Value: array status/lenght

        ReDim pSStateGameIndex(0 To 4)               'Array start size of pSStateList set to 4
        SStateGameIndex_Pos = -1                    'Array position index starts to 0
        SStateGameIndex_Unload = SStateGameIndex_Pos
    End Function
End Module
