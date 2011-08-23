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
Module mdlFileList

    Public FileList() As System.IO.FileInfo 'The array contanins a list of filenames
    Public FileList_Pos As System.Int64     'Array public index
    Public FileList_Len As System.Int64     'Array lenght (occupied records)

    Public Function FileList_Load(ByVal pPath As System.String, _
                                  ByRef pFileList() As System.IO.FileInfo, _
                                  ByRef pFileList_Pos As System.Int64 _
                                  ) As System.Int64
        'Creates the array from the scanned folder
        '   ByVal   pPath                       Path to search in
        '   ByRef   pFindFile()                 The dinamic array of the files
        '   ByVal   pFindFileDbPos              Index used in the array

        'Return Value: array status/lenght
        Dim FileTmp As System.IO.FileInfo
        FileList_Unload(pFileList, pFileList_Pos)

        For Each FileFound As System.String In My.Computer.FileSystem.GetFiles(pPath)
            FileTmp = My.Computer.FileSystem.GetFileInfo(FileFound)
            If FileTmp.Extension = SState_Ext Or FileTmp.Extension = SState_ExtBackup Then
                If (pFileList.GetUpperBound(0) - pFileList_Pos) <= 2 Then            'Resize of the array. But not too often
                    ReDim Preserve pFileList(0 To pFileList.GetUpperBound(0) + 4)
                End If

                pFileList_Pos = pFileList_Pos + 1
                pFileList(pFileList_Pos) = My.Computer.FileSystem.GetFileInfo(FileFound)
            End If
        Next
        FileList_Load = pFileList_Pos
        pFileList_Pos = 0
    End Function

    Public Function FileList_Unload(ByRef pFileList() As System.IO.FileInfo, _
                                    ByRef pFileList_Pos As Int64 _
                                    ) As Int64
        'Clears the array
        '   ByRef   paFileList()                The dinamic array of the files
        '   ByRef   plaFileListPos              Index used in the array
        'Return Value: array status/lenght

        ReDim pFileList(0 To 4)             'Array start size of pagamedb set to 4
        pFileList_Pos = -1                  'Array position index starts to 0
        FileList_Unload = pFileList_Pos
    End Function

    Public Function FileList_ExportTxt(ByVal pFileListExport_Loc As System.String, _
                                       ByVal pSepStyle As System.String, _
                                       ByRef pFileList() As System.IO.FileInfo, _
                                       ByVal pFileList_Pos As System.Int64, _
                                       ByVal pFileList_Len As System.Int64 _
                                       ) As System.Int64
        'Export the array to a text file (you could import in Excel and Access)
        '   ByVal   psFileFileFindConvLoc       Path and file name of the saved file
        '   ByVal   pSepStyle                   Separator character to be use in the export
        '   ByRef   paFileList()                The dinamic array of the GameDB to search in
        '   ByRef   plaFileListPos              Index used in the array
        '   byval   plaFileListLen              Lenght/status of the array

        If pFileList_Len >= 0 Then
            Using FileFileList_Tab_Writer = My.Computer.FileSystem.OpenTextFileWriter(pFileListExport_Loc, False)
                FileFileList_Tab_Writer.WriteLine("Filename" & pSepStyle & "Size" & pSepStyle & "Created" & pSepStyle & "Modified" & pSepStyle & "Accessed" & pSepStyle & "Attributes")
                For pFileList_Pos = 0 To pFileList_Len
                    FileFileList_Tab_Writer.WriteLine(pFileList(pFileList_Pos).Name & pSepStyle & _
                                                      pFileList(pFileList_Pos).Length & pSepStyle & _
                                                      pFileList(pFileList_Pos).CreationTime & pSepStyle & _
                                                      pFileList(pFileList_Pos).LastWriteTime & pSepStyle & _
                                                      pFileList(pFileList_Pos).LastAccessTime & pSepStyle & _
                                                      pFileList(pFileList_Pos).Attributes)
                Next pFileList_Pos
            End Using
        End If
        FileList_ExportTxt = 0
    End Function
End Module
