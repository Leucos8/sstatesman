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
Option Explicit On
Module mdlSStateList

    Public Structure rSStateList                    'Record declaration
        Friend FileInfo As System.IO.FileInfo       'Information about the file: size, date, extension, etc.
        Friend SStateSlot As System.Byte            'Savestate slot number
        Friend SStateBackup As System.Boolean       'True if the savestate is a backup (it has the My.Settings.SState_ExtBackup extension)
        Friend SStateSerial As System.String        'The game serial extracted from the savestate name (left(FileInfo.Name), InStr(FileInfo.Name, " "))
        Friend isDeleted As System.Boolean          'True if the file is deleted (it will be skipped when the data is presented)
        Friend GameIndexRef As System.Int32         'Reference to the game index array
    End Structure
    Public SStateList() As rSStateList             'Array with the savestate information
    Public SStateList_Pos As System.Int32 = 0       'Position index of the array
    Public SStateList_Len As System.Int32 = 0       'Occupied records of the array
    Public Const SStateList_ReDimFactor As System.Int32 = 32

    Public Structure rSStateGameIndex               'Record declaration
        Friend GameInfo As rGameDb                  'Game information from the GameDb array
        Friend SStates_SizeTotal As System.Int64    'Total size in bytes of the savestate files
        Friend SStatesBackup_SizeTotal As System.Int64  'Total size in bytes of the savestate backup files
        Friend SStateList_Start As System.Int32     'Start position in SStateList() of the records of this game
        Friend SStateList_End As System.Int32       'End position in SStateList() of the record of this game
        Friend SStateList_Count As System.Int32
        Friend SStateListBackup_Count As System.Int32
    End Structure
    Public SStateGameIndex() As rSStateGameIndex   'Array with the games with found savestates
    Public SStateGameIndex_Pos As System.Int32 = 0  'Position index of the array
    Public SStateGameIndex_Len As System.Int32 = 0  'Occupied records of the array
    Public Const SStateGameIndex_ReDimFactor As System.Int32 = 16

    Public Function SStateList_Load(ByVal pPath As System.String, _
                                  ByRef pSStateList() As rSStateList, _
                                  ByRef pSStateList_Pos As System.Int32 _
                                  ) As System.Int32
        'Creates the array from the scanned folder
        '   ByVal   pPath                       Path to search in
        '   ByRef   pFindFile()                 The dinamic array of the files
        '   ByVal   pFindFileDbPos              Index used in the array
        'Return Value: array status/lenght

        pSStateList_Pos = SStateList_Unload(pSStateList, pSStateList_Pos, True)   'The array is cleared
        Try
            For Each FileFound As System.String In My.Computer.FileSystem.GetFiles(pPath)   'FileFound the complete address (path and filename) obtained from GetFiles(path), wich returns an array of strings
                Dim FileTmp As System.IO.FileInfo       'The temp record where the file info are stored
                FileTmp = My.Computer.FileSystem.GetFileInfo(FileFound)
                If FileTmp.Extension = My.Settings.PCSX2_SStateExt Or FileTmp.Extension = My.Settings.PCSX2_SStateExtBackup Then
                    If (pSStateList.GetUpperBound(0) - pSStateList_Pos) <= 2 Then   'Resize of the array. But not too often
                        ReDim Preserve pSStateList(pSStateList.GetUpperBound(0) + SStateList_ReDimFactor)
                    End If

                    pSStateList(pSStateList_Pos).FileInfo = My.Computer.FileSystem.GetFileInfo(FileFound)

                    pSStateList(pSStateList_Pos).SStateSerial = pSStateList(pSStateList_Pos).FileInfo.Name.Remove(pSStateList(pSStateList_Pos).FileInfo.Name.IndexOf(" ", 0))    'Stores the serial
                    pSStateList(pSStateList_Pos).isDeleted = False                   'The underlying file is not deleted
                    Select Case pSStateList(pSStateList_Pos).FileInfo.Extension
                        Case My.Settings.PCSX2_SStateExt
                            pSStateList(pSStateList_Pos).SStateBackup = False
                        Case My.Settings.PCSX2_SStateExtBackup
                            pSStateList(pSStateList_Pos).SStateBackup = True
                    End Select
                    pSStateList(pSStateList_Pos).GameIndexRef = 0
                    Try
                        pSStateList(pSStateList_Pos).SStateSlot = CInt(Mid(pSStateList(pSStateList_Pos).FileInfo.Name, _
                                                                           InStr(pSStateList(pSStateList_Pos).FileInfo.Name, ".") + 1, 2))   'Stores the slot value

                        pSStateList_Pos = pSStateList_Pos + 1
                    Catch Slot_Ex As Exception
                        MsgBox(System.String.Format("A '{0}' file is being skipped, unable to determine the saveslot number: {1}", _
                                                    My.Settings.PCSX2_SStateExt, _
                                                    pSStateList(pSStateList_Pos).FileInfo.Name), _
                                vbCritical, "Error")
                        'pSStateList_Pos = pSStateList_Pos - 1
                    End Try
                End If
            Next
        Catch Path_ex As Exception
            System.Windows.Forms.MessageBox.Show(System.String.Format("Some kinda failure while scanning Savestate folder." & vbCrLf & vbCrLf & "Path scanned: {0}", Path_ex.Message), _
                                                 "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error)
        End Try
        ReDim Preserve pSStateList(pSStateList_Pos - 1)
        SStateList_Load = pSStateList_Pos - 1
        pSStateList_Pos = 0
    End Function


    Public Function SStateList_Unload(ByRef pSStateList() As mdlSStateList.rSStateList, _
                                      ByRef pSStateList_Pos As System.Int32, _
                                      Optional ByRef pWillBeUsed As System.Boolean = False _
                                      ) As System.Int32
        'Clears the array
        '   ByRef   pSStateList()               The dinamic array of the SStateList
        '   ByRef   pSStateList_Pos             Index used in the array
        '   ByRef   pWillBeUsed                 Specifies if the array will be used after being cleared
        'Return Value: array status/lenght

        If pWillBeUsed Then
            ReDim pSStateList(SStateList_ReDimFactor)
        Else
            ReDim pSStateList(-1)
        End If
        pSStateList_Pos = 0                    'Array position index starts to 0
        SStateList_Unload = pSStateList_Pos
    End Function

    Public Function SStateList_ExportTxt(ByVal pSStateListExport_Loc As System.String, _
                                       ByVal pSepStyle As System.String, _
                                       ByRef pSStateList() As mdlSStateList.rSStateList, _
                                       ByVal pSStateList_Pos As System.Int32, _
                                       ByVal pSStateList_Len As System.Int32 _
                                       ) As System.Int32
        'Export the array to a text file (you could import in Excel and Access)
        '   ByVal   pSStateListExport_Loc       Path and file name of the saved file
        '   ByVal   pSepStyle                   Separator character to be use in the export
        '   ByRef   pSStateList()               The dinamic array of the GameDB to search in
        '   ByRef   pSStateList_Pos             Index used in the array
        '   byval   pSStateList_Len             Lenght/status of the array

        If pSStateList_Len >= 0 Then
            Using FileSStateList_Tab_Writer = My.Computer.FileSystem.OpenTextFileWriter(pSStateListExport_Loc, False)
                FileSStateList_Tab_Writer.WriteLine(System.String.Concat("Serial", pSepStyle, "Slot", pSepStyle, "Backup", pSepStyle, "Filename", pSepStyle, "Size", pSepStyle, "Created", pSepStyle, "Modified", pSepStyle, "Accessed", pSepStyle, "Attributes"))
                For pSStateList_Pos = 0 To pSStateList_Len
                    FileSStateList_Tab_Writer.WriteLine(System.String.Concat(pSStateList(pSStateList_Pos).SStateSerial, pSepStyle, _
                                                        pSStateList(pSStateList_Pos).SStateSlot, pSepStyle, _
                                                        pSStateList(pSStateList_Pos).SStateBackup, pSepStyle, _
                                                        pSStateList(pSStateList_Pos).FileInfo.Name, pSepStyle, _
                                                        pSStateList(pSStateList_Pos).FileInfo.Length, pSepStyle, _
                                                        pSStateList(pSStateList_Pos).FileInfo.CreationTime, pSepStyle, _
                                                        pSStateList(pSStateList_Pos).FileInfo.LastWriteTime, pSepStyle, _
                                                        pSStateList(pSStateList_Pos).FileInfo.LastAccessTime, pSepStyle, _
                                                        pSStateList(pSStateList_Pos).FileInfo.Attributes))
                Next pSStateList_Pos
            End Using
        End If
        SStateList_ExportTxt = 0
    End Function

    Public Function SStateList_ExtractBySerial(ByRef pSerial As System.String, _
                                               ByRef pSStateList() As mdlSStateList.rSStateList, _
                                               ByRef pSStateList_Pos As System.Int32, _
                                               ByVal pSStateList_Len As System.Int32, _
                                               ByRef pSStateListExtract() As mdlSStateList.rSStateList, _
                                               ByRef pSStateListExtract_Pos As System.Int32 _
                                               ) As System.Int32
        'Extract from the input array an array with the savestates that matches the serial
        '   ByRef   pSerial                     Serial to search
        '   ByRef   pSStateList()               The dinamic array of the SStateList to search in (input)
        '   ByVal   pSStateList_Pos             Index used in the array (input)
        '   ByVal   pSStateList_Len             Lenght/status of the array (input)
        '   ByRef   pSStateListExtract()        The array extracted (output)
        '   ByRef   pSStateListExtract_Pos      Index used in the array (output)
        'Return Value: Array status/lenght

        If Not (pSerial = "") And Not (pSStateList_Len = 0) Then
            SStateList_Unload(pSStateListExtract, pSStateListExtract_Pos, True)
            For pSStateList_Pos = 0 To pSStateList_Len
                If pSStateList(pSStateList_Pos).SStateSerial Like pSerial Then
                    pSStateListExtract_Pos = pSStateListExtract_Pos + 1
                    If (UBound(pSStateListExtract) - pSStateListExtract_Pos) <= SStateList_ReDimFactor Then           'Resize the array when needed
                        ReDim Preserve pSStateListExtract(0 To UBound(pSStateListExtract) + SStateList_ReDimFactor)
                    End If
                    pSStateListExtract(pSStateListExtract_Pos) = pSStateList(pSStateList_Pos)
                End If
            Next pSStateList_Pos
            ReDim Preserve pSStateListExtract(0 To pSStateListExtract_Pos)
            SStateList_ExtractBySerial = pSStateListExtract_Pos
            pSStateListExtract_Pos = 0
        Else
            SStateList_ExtractBySerial = 0
        End If
    End Function

    Public Function SStateGameIndex_Load(ByRef pSStateList() As mdlSStateList.rSStateList, _
                                           ByVal pSStateList_Pos As System.Int32, _
                                           ByVal pSStateList_Len As System.Int32, _
                                           ByRef pGameDb() As mdlGameDb.rGameDb, _
                                           ByRef pGameDb_Pos As System.Int32, _
                                           ByVal pGameDb_Len As System.Int32, _
                                           ByRef pSStateGameIndex() As mdlSStateList.rSStateGameIndex, _
                                           ByRef pSStateGameIndex_Pos As System.Int32 _
                                           ) As System.Int32
        If pSStateList_Len > 0 Then
            pSStateGameIndex_Pos = mdlSStateList.SStateGameIndex_Unload(pSStateGameIndex, pSStateGameIndex_Pos, True) 'Clears the array
            pSStateGameIndex_Pos = 0        'Position 0
            pSStateGameIndex(0).GameInfo.Serial = "*"
            pSStateGameIndex(0).GameInfo.Name = "(all games)"
            pSStateGameIndex(0).GameInfo.Region = "*"
            pSStateGameIndex(0).GameInfo.RStatus = "0"
            pSStateGameIndex(0).SStateList_Start = "0"
            pSStateGameIndex(0).SStateList_End = pSStateList_Len

            For pSStateList_Pos = 0 To pSStateList_Len
                If Not (pSStateGameIndex(pSStateGameIndex_Pos).GameInfo.Serial Like pSStateList(pSStateList_Pos).SStateSerial) Then
                    pSStateGameIndex(pSStateGameIndex_Pos).SStateList_End = pSStateList_Pos - 1

                    If (pSStateGameIndex.GetUpperBound(0) - pSStateGameIndex_Pos) <= 2 Then 'Resize the array when needed
                        ReDim Preserve pSStateGameIndex(pSStateGameIndex.GetUpperBound(0) + SStateGameIndex_ReDimFactor)
                    End If

                    pSStateGameIndex_Pos = pSStateGameIndex_Pos + 1

                    pSStateGameIndex(pSStateGameIndex_Pos).SStateList_Start = pSStateList_Pos

                    pSStateGameIndex(pSStateGameIndex_Pos).GameInfo = mdlGameDb.GameDb_SearchSerial(pSStateList(pSStateList_Pos).SStateSerial, _
                                                                                       pGameDb, pGameDb_Pos, pGameDb_Len)

                    pSStateGameIndex(pSStateGameIndex_Pos).SStateList_Count = 0
                    pSStateGameIndex(pSStateGameIndex_Pos).SStateListBackup_Count = 0
                    pSStateGameIndex(pSStateGameIndex_Pos).SStates_SizeTotal = 0
                    pSStateGameIndex(pSStateGameIndex_Pos).SStatesBackup_SizeTotal = 0

                End If
                pSStateList(pSStateList_Pos).GameIndexRef = pSStateGameIndex_Pos

                If pSStateList(pSStateList_Pos).SStateBackup = False Then
                    pSStateGameIndex(pSStateGameIndex_Pos).SStates_SizeTotal = pSStateGameIndex(pSStateGameIndex_Pos).SStates_SizeTotal + pSStateList(pSStateList_Pos).FileInfo.Length
                    pSStateGameIndex(0).SStates_SizeTotal = pSStateGameIndex(0).SStates_SizeTotal + pSStateList(pSStateList_Pos).FileInfo.Length
                    pSStateGameIndex(pSStateGameIndex_Pos).SStateList_Count = pSStateGameIndex(pSStateGameIndex_Pos).SStateList_Count + 1
                    pSStateGameIndex(0).SStateList_Count = pSStateGameIndex(0).SStateList_Count + 1
                Else
                    pSStateGameIndex(pSStateGameIndex_Pos).SStatesBackup_SizeTotal = pSStateGameIndex(pSStateGameIndex_Pos).SStatesBackup_SizeTotal + pSStateList(pSStateList_Pos).FileInfo.Length
                    pSStateGameIndex(0).SStatesBackup_SizeTotal = pSStateGameIndex(0).SStatesBackup_SizeTotal + pSStateList(pSStateList_Pos).FileInfo.Length
                    pSStateGameIndex(pSStateGameIndex_Pos).SStateListBackup_Count = pSStateGameIndex(pSStateGameIndex_Pos).SStateListBackup_Count + 1
                    pSStateGameIndex(0).SStateListBackup_Count = pSStateGameIndex(0).SStateListBackup_Count + 1
                End If

            Next pSStateList_Pos

            pSStateGameIndex(0).SStateList_End = pSStateList_Len

            pSStateGameIndex(pSStateGameIndex_Pos).SStateList_End = pSStateList_Len

            ReDim Preserve pSStateGameIndex(pSStateGameIndex_Pos)
            SStateGameIndex_Load = pSStateGameIndex_Pos
        Else
            SStateGameIndex_Load = 0

        End If
    End Function

    Public Function SStateGameIndex_Unload(ByRef pSStateGameIndex() As mdlSStateList.rSStateGameIndex, _
                                           ByRef SStateGameIndex_Pos As System.Int32, _
                                           Optional ByRef pWillBeUsed As System.Boolean = False _
                                           ) As System.Int32
        'Clears the array
        '   ByRef   pSStateList()           The dinamic array of the SStateList
        '   ByRef   pSStateList_Pos         Index used in the array
        '   ByRef   pWillBeUsed             Specifies if the array will be used after being cleared
        'Return Value: array status/lenght

        If pWillBeUsed Then
            ReDim pSStateGameIndex(SStateGameIndex_ReDimFactor)
        Else
            ReDim pSStateGameIndex(-1)
        End If
        SStateGameIndex_Pos = -1                    'Array position index starts to 0
        SStateGameIndex_Unload = SStateGameIndex_Pos
    End Function
End Module
