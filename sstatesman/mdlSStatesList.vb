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
Option Explicit On
Module mdlSStatesList

    Public Structure rSStatesList                   'Record declaration
        Friend FileInfo As System.IO.FileInfo       'Information about the file: size, date, extension, etc.
        Friend Slot As System.Byte                  'Savestate slot number
        Friend isBackup As System.Boolean           'True if the savestate is a backup (it has the My.Settings.SState_ExtBackup extension)
        Friend isDeleted As System.Boolean          'True if the file is deleted, logical deletion flag
        Friend GameIndexRef As System.Int32         'Reference to the game index array
        Friend SStateSerial As System.String        'The game serial extracted from the savestate name (left(FileInfo.Name), InStr(FileInfo.Name, " "))
    End Structure
    Public SStatesList() As rSStatesList            'Array with the savestate information
    Public SStatesList_Pos As System.Int32 = 0      'Position index of the array
    Public SStatesList_Len As System.Int32 = 0      'Occupied records of the array
    Public Const SStatesList_ReDimFactor As System.Int32 = 32

    Public SStates_FolderLastModified As System.DateTime


    Public Function SStatesList_Load(ByVal pPath As System.String, _
                                     ByRef pSStatesList() As mdlSStatesList.rSStatesList, _
                                     ByRef pSStatesList_Pos As System.Int32 _
                                     ) As System.Int32
        'Creates the array from the scanned folder
        '   ByVal   pPath                       Path to search in
        '   ByRef   pSStatesList()              The dinamic array of the files
        '   ByVal   pSStatesList_Pos            Index used in the array
        'Return Value: array status/lenght

        If My.Computer.FileSystem.DirectoryExists(pPath) Then
            SStates_FolderLastModified = My.Computer.FileSystem.GetDirectoryInfo(pPath).LastWriteTime
            pSStatesList_Pos = SStatesList_Unload(pSStatesList, pSStatesList_Pos, SStatesList_ReDimFactor)   'The array is cleared
            Try
                For Each FileFound As System.String In My.Computer.FileSystem.GetFiles(pPath)   'FileFound the complete address (path and filename) obtained from GetFiles(path), wich returns an array of strings
                    Dim FileTmp As System.IO.FileInfo = My.Computer.FileSystem.GetFileInfo(FileFound)
                    If FileTmp.Extension = My.Settings.PCSX2_SStateExt Or FileTmp.Extension = My.Settings.PCSX2_SStateExtBackup Then
                        If (pSStatesList.GetUpperBound(0) - pSStatesList_Pos) <= 2 Then   'Resize of the array. But not too often
                            ReDim Preserve pSStatesList(pSStatesList.GetUpperBound(0) + SStatesList_ReDimFactor)
                        End If

                        pSStatesList(pSStatesList_Pos).FileInfo = My.Computer.FileSystem.GetFileInfo(FileFound)

                        pSStatesList(pSStatesList_Pos).SStateSerial = pSStatesList(pSStatesList_Pos).FileInfo.Name.Remove(pSStatesList(pSStatesList_Pos).FileInfo.Name.IndexOf(" ", 0))    'Stores the serial
                        pSStatesList(pSStatesList_Pos).isDeleted = False
                        Select Case pSStatesList(pSStatesList_Pos).FileInfo.Extension
                            Case My.Settings.PCSX2_SStateExt
                                pSStatesList(pSStatesList_Pos).isBackup = False
                            Case My.Settings.PCSX2_SStateExtBackup
                                pSStatesList(pSStatesList_Pos).isBackup = True
                        End Select
                        pSStatesList(pSStatesList_Pos).GameIndexRef = 0
                        'pSStatesList(pSStatesList_Pos).Slot = pSStatesList(pSStatesList_Pos).FileInfo.Name.Substring(pSStatesList(pSStatesList_Pos).FileInfo.Name.IndexOf(".", 0) + 1, 2)
                        'pSStatesList_Pos += 1
                        Try
                            pSStatesList(pSStatesList_Pos).Slot = CInt(pSStatesList(pSStatesList_Pos).FileInfo.Name.Substring(pSStatesList(pSStatesList_Pos).FileInfo.Name.IndexOf(".", 0) + 1, 2))   'Stores the slot value

                            pSStatesList_Pos += 1
                        Catch Slot_Ex As Exception
                            System.Windows.Forms.MessageBox.Show(System.String.Format("A '{0}' file is being skipped, unable to determine the saveslot number: {1}", _
                                                                                      My.Settings.PCSX2_SStateExt, _
                                                                                      pSStatesList(pSStatesList_Pos).FileInfo.Name), _
                                                                                      "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            'pSStateList_Pos -= 1
                        End Try
                    End If
                Next
            Catch Path_ex As Exception
                System.Windows.Forms.MessageBox.Show(System.String.Format("Some kinda failure while scanning Savestate folder." & vbCrLf & vbCrLf & "Path scanned: {0}", Path_ex.Message), _
                                                     "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error)
            End Try
        End If
        SStatesList_Load = pSStatesList_Pos - 1
        ReDim Preserve pSStatesList(pSStatesList_Pos)
        pSStatesList_Pos = 0
    End Function

    Public Function SStatesList_Load2(ByVal pPath As System.String, _
                                     ByRef pSStatesList() As mdlSStatesList.rSStatesList, _
                                     ByRef pSStatesList_Pos As System.Int32 _
                                     ) As System.Int32
        'Creates the array from the scanned folder
        '   ByVal   pPath                       Path to search in
        '   ByRef   pSStatesList()              The dinamic array of the files
        '   ByVal   pSStatesList_Pos            Index used in the array
        'Return Value: array status/lenght

        Dim sstates_DirectoryInfo As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(pPath)
        SStates_FolderLastModified = sstates_DirectoryInfo.LastWriteTime
        pSStatesList_Pos = SStatesList_Unload(pSStatesList, pSStatesList_Pos, SStatesList_ReDimFactor)   'The array is cleared
        For Each filefound As System.IO.FileInfo In sstates_DirectoryInfo.GetFiles
            If filefound.Extension = My.Settings.PCSX2_SStateExt Or filefound.Extension = My.Settings.PCSX2_SStateExtBackup Then
                If (pSStatesList.GetUpperBound(0) - pSStatesList_Pos) <= 2 Then   'Resize of the array. But not too often
                    ReDim Preserve pSStatesList(pSStatesList.GetUpperBound(0) + SStatesList_ReDimFactor)
                End If

                pSStatesList(pSStatesList_Pos).FileInfo = filefound

                pSStatesList(pSStatesList_Pos).SStateSerial = pSStatesList(pSStatesList_Pos).FileInfo.Name.Remove(pSStatesList(pSStatesList_Pos).FileInfo.Name.IndexOf(" ", 0))    'Stores the serial
                pSStatesList(pSStatesList_Pos).isDeleted = False
                Select Case pSStatesList(pSStatesList_Pos).FileInfo.Extension
                    Case My.Settings.PCSX2_SStateExt
                        pSStatesList(pSStatesList_Pos).isBackup = False
                    Case My.Settings.PCSX2_SStateExtBackup
                        pSStatesList(pSStatesList_Pos).isBackup = True
                End Select
                pSStatesList(pSStatesList_Pos).GameIndexRef = -1
                'pSStatesList(pSStatesList_Pos).Slot = pSStatesList(pSStatesList_Pos).FileInfo.Name.Substring(pSStatesList(pSStatesList_Pos).FileInfo.Name.IndexOf(".", 0) + 1, 2)
                'pSStatesList_Pos += 1

                If System.Byte.TryParse(pSStatesList(pSStatesList_Pos).FileInfo.Name.Substring(pSStatesList(pSStatesList_Pos).FileInfo.Name.IndexOf(".", 0) + 1, 2), pSStatesList(pSStatesList_Pos).Slot) Then  'Stores the slot value

                    pSStatesList_Pos += 1
                Else
                    System.Windows.Forms.MessageBox.Show(System.String.Format("A '{0}' file is being skipped, unable to determine the saveslot number: {1}", _
                                                                              My.Settings.PCSX2_SStateExt, _
                                                                              pSStatesList(pSStatesList_Pos).FileInfo.Name), _
                                                                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'pSStateList_Pos -= 1
                End If

            End If
        Next

        SStatesList_Load2 = pSStatesList_Pos - 1
        ReDim Preserve pSStatesList(pSStatesList_Pos)
        pSStatesList_Pos = 0
    End Function

    Public Function SStatesList_Unload(ByRef pSStatesList() As mdlSStatesList.rSStatesList, _
                                       ByRef pSStatesList_Pos As System.Int32 _
                                       ) As System.Int32
        'Clears the array
        '   ByRef   pSStatesList()              The dinamic array of the SStateList
        '   ByRef   pSStatesList_Pos            Index used in the array
        'Return Value: array status/lenght

        ReDim pSStatesList(-1)
        pSStatesList_Pos = -1                    'Array position index starts to 0
        Return 0
    End Function

    Public Function SStatesList_Unload(ByRef pSStatesList() As mdlSStatesList.rSStatesList, _
                                       ByRef pSStatesList_Pos As System.Int32, _
                                       ByVal pRedimFactor As System.Int32 _
                                       ) As System.Int32
        'Clears the array
        '   ByRef   pSStatesList()              The dinamic array of the SStateList
        '   ByRef   pSStatesList_Pos            Index used in the array
        '   ByVal   pRedimFactor                Specifies the starting size of the array
        'Return Value: array status/lenght

        ReDim pSStatesList(pRedimFactor)
        pSStatesList_Pos = 0                    'Array position index starts to 0
        Return 0
    End Function

    Public Function SStatesList_ExportTxt(ByVal pSStatesListExport_Loc As System.String, _
                                          ByVal pSepStyle As System.String, _
                                          ByRef pSStatesList() As mdlSStatesList.rSStatesList, _
                                          ByVal pSStatesList_Pos As System.Int32, _
                                          ByVal pSStatesList_Len As System.Int32 _
                                          ) As System.Int32
        'Export the array to a text file (you could import in Excel and Access)
        '   ByVal   pSStatesListExport_Loc      Path and file name of the saved file
        '   ByVal   pSepStyle                   Separator character to be use in the export
        '   ByRef   pSStatesList()              The dinamic array of the GameDB to search in
        '   ByRef   pSStatesList_Pos            Index used in the array
        '   ByVal   pSStatesList_Len            Lenght/status of the array

        If pSStatesList_Len >= 0 Then
            Using FileSStateList_Tab_Writer As New System.IO.StreamWriter(pSStatesListExport_Loc, False)
                FileSStateList_Tab_Writer.WriteLine(System.String.Concat("Serial", pSepStyle, "Slot", pSepStyle, "Backup", pSepStyle, "Filename", pSepStyle, "Size", pSepStyle, "Created", pSepStyle, "Modified", pSepStyle, "Accessed", pSepStyle, "Attributes"))
                For pSStatesList_Pos = 0 To pSStatesList_Len
                    FileSStateList_Tab_Writer.WriteLine(System.String.Concat(pSStatesList(pSStatesList_Pos).SStateSerial, pSepStyle, _
                                                        pSStatesList(pSStatesList_Pos).Slot, pSepStyle, _
                                                        pSStatesList(pSStatesList_Pos).isBackup, pSepStyle, _
                                                        pSStatesList(pSStatesList_Pos).FileInfo.Name, pSepStyle, _
                                                        pSStatesList(pSStatesList_Pos).FileInfo.Length, pSepStyle, _
                                                        pSStatesList(pSStatesList_Pos).FileInfo.CreationTime, pSepStyle, _
                                                        pSStatesList(pSStatesList_Pos).FileInfo.LastWriteTime, pSepStyle, _
                                                        pSStatesList(pSStatesList_Pos).FileInfo.LastAccessTime, pSepStyle, _
                                                        pSStatesList(pSStatesList_Pos).FileInfo.Attributes))
                Next pSStatesList_Pos
            End Using
        End If
        SStatesList_ExportTxt = 0
    End Function

    'Public Function SStatesList_ExtractBySerial(ByRef pSerial As System.String, _
    '                                            ByRef pSStatesList() As mdlSStateList.rSStatesList, _
    '                                            ByRef pSStatesList_Pos As System.Int32, _
    '                                            ByVal pSStatesList_Len As System.Int32, _
    '                                            ByRef pSStatesListExtract() As mdlSStateList.rSStatesList, _
    '                                            ByRef pSStatesListExtract_Pos As System.Int32 _
    '                                            ) As System.Int32
    '    'Extract from the input array an array with the savestates that matches the serial
    '    '   ByRef   pSerial                     Serial to search
    '    '   ByRef   pSStatesList()              The dinamic array of the SStatesList to search in (input)
    '    '   ByVal   pSStatesList_Pos            Index used in the array (input)
    '    '   ByVal   pSStatesList_Len            Lenght/status of the array (input)
    '    '   ByRef   pSStatesListExtract()       The array extracted (output)
    '    '   ByRef   pSStatesListExtract_Pos     Index used in the array (output)
    '    'Return Value: Array status/lenght

    '    If Not (pSerial = "") And Not (pSStatesList_Len = 0) Then
    '        SStatesList_Unload(pSStatesListExtract, pSStatesListExtract_Pos, True)
    '        For pSStatesList_Pos = 0 To pSStatesList_Len
    '            If pSStatesList(pSStatesList_Pos).SStateSerial Like pSerial Then
    '                pSStatesListExtract_Pos += 1
    '                If (UBound(pSStatesListExtract) - pSStatesListExtract_Pos) <= SStatesList_ReDimFactor Then           'Resize the array when needed
    '                    ReDim Preserve pSStatesListExtract(0 To UBound(pSStatesListExtract) + SStatesList_ReDimFactor)
    '                End If
    '                pSStatesListExtract(pSStatesListExtract_Pos) = pSStatesList(pSStatesList_Pos)
    '            End If
    '        Next pSStatesList_Pos
    '        ReDim Preserve pSStatesListExtract(0 To pSStatesListExtract_Pos)
    '        SStatesList_ExtractBySerial = pSStatesListExtract_Pos
    '        pSStatesListExtract_Pos = 0
    '    Else
    '        SStatesList_ExtractBySerial = 0
    '    End If
    'End Function
End Module
