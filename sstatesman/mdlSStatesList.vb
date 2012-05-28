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
    'Public SStatesList_Pos As System.Int32 = 0      'Position index of the array
    'Public _Len As System.Int32 = 0      'Occupied records of the array
    Public SStatesList_ArrayStatus As mdlMain.ArrayStatus = ArrayStatus.ArrayNotLoaded
    Public Const SStatesList_ReDimFactor As System.Int32 = 64
    Public SStates_FolderLastModified As System.DateTime

    Public Function SStatesList_Load(ByVal pPath As System.String, _
                                     ByRef pSStatesList() As mdlSStatesList.rSStatesList
                                     ) As mdlMain.ArrayStatus
        'Creates the array from the scanned folder
        '   ByVal   pPath                       Path to search in
        '   ByRef   pSStatesList()              The dinamic array of the files
        '   ByVal   pSStatesList_Pos            Index used in the array
        'Return Value: array status/lenght

        Try
            mdlMain.WriteToConsole("SStatesList", "SStatesList_Load", System.String.Format("Scanning files in ""{0}"".", pPath))

            Dim SStatesList_Pos As System.Int32 = 0

            Dim sstates_DirectoryInfo As System.IO.DirectoryInfo = New System.IO.DirectoryInfo(pPath)
            SStates_FolderLastModified = sstates_DirectoryInfo.LastWriteTime

            mdlSStatesList.SStatesList_Unload(pSStatesList, SStatesList_ReDimFactor)   'The array is cleared
            For Each myFileFound As System.IO.FileInfo In sstates_DirectoryInfo.GetFiles
                If myFileFound.Extension = My.Settings.PCSX2_SStateExt Or myFileFound.Extension = My.Settings.PCSX2_SStateExtBackup Then
                    If (pSStatesList.GetUpperBound(0) - SStatesList_Pos) <= 2 Then   'Resize of the array. But not too often
                        ReDim Preserve pSStatesList(pSStatesList.GetUpperBound(0) + SStatesList_ReDimFactor)
                        mdlMain.WriteToConsole("SStatesList", "SStatesList_Load", System.String.Format("Array resized to {0} records.", pSStatesList.GetUpperBound(0)))
                    End If

                    pSStatesList(SStatesList_Pos).FileInfo = myFileFound

                    If System.Byte.TryParse(pSStatesList(SStatesList_Pos).FileInfo.Name.Substring(pSStatesList(SStatesList_Pos).FileInfo.Name.IndexOf(".", 0) + 1, 2), pSStatesList(SStatesList_Pos).Slot) Then  'Stores the slot value
                        pSStatesList(SStatesList_Pos).SStateSerial = pSStatesList(SStatesList_Pos).FileInfo.Name.Remove(pSStatesList(SStatesList_Pos).FileInfo.Name.IndexOf(" ", 0))    'Stores the serial

                        pSStatesList(SStatesList_Pos).isDeleted = False

                        Select Case pSStatesList(SStatesList_Pos).FileInfo.Extension
                            Case My.Settings.PCSX2_SStateExt
                                pSStatesList(SStatesList_Pos).isBackup = False
                            Case My.Settings.PCSX2_SStateExtBackup
                                pSStatesList(SStatesList_Pos).isBackup = True
                        End Select

                        pSStatesList(SStatesList_Pos).GameIndexRef = -1
                        SStatesList_Pos += 1
                    Else
                        mdlMain.WriteToConsole("SStatesList", "SStatesList_Load", _
                                               System.String.Format("A '{0}' file is being skipped, unable to determine the saveslot number: {1}", _
                                                                    My.Settings.PCSX2_SStateExt, _
                                                                    pSStatesList(SStatesList_Pos).FileInfo.Name))
                        'pSStateList_Pos -= 1
                    End If


                    'pSStatesList(pSStatesList_Pos).Slot = pSStatesList(pSStatesList_Pos).FileInfo.Name.Substring(pSStatesList(pSStatesList_Pos).FileInfo.Name.IndexOf(".", 0) + 1, 2)
                    'pSStatesList_Pos += 1



                End If
            Next
            SStatesList_Pos = SStatesList_Pos - 1
            ReDim Preserve pSStatesList(SStatesList_Pos)
            If SStatesList_Pos < 0 Then
                mdlMain.WriteToConsole("SStatesList", "SStatesList_Load", "Load complete. Loaded 0 records. The array is empty")
                SStatesList_Load = ArrayStatus.ArrayEmpty
            Else
                mdlMain.WriteToConsole("SStatesList", "SStatesList_Load", System.String.Format("Load complete. Loaded {0:#,##0} records.", pSStatesList.GetLength(0)))
                SStatesList_Load = ArrayStatus.ArrayLoadedOK
            End If
        Catch ex As Exception
            mdlMain.WriteToConsole("SStatesList", "SStatesList_Load", System.String.Concat("Some kinda failure while scanning files. ", ex.Message))
            SStatesList_Load = ArrayStatus.ErrorOccurred
        End Try
    End Function

    Public Function SStatesList_Unload(ByRef pSStatesList() As mdlSStatesList.rSStatesList, _
                                       Optional ByVal pRedimFactor As System.Int32 = -1 _
                                       ) As mdlMain.ArrayStatus
        'Clears the array
        '   ByRef   pSStatesList()              The dinamic array of the SStateList
        '   ByVal   pRedimFactor                Specifies the starting size of the array
        'Return Value: array status

        ReDim pSStatesList(pRedimFactor)
        mdlMain.WriteToConsole("SStatesList", "SStatesList_Unload", System.String.Format("Array prepared with {0} empty records.", pRedimFactor))
        Return ArrayStatus.ArrayEmpty
    End Function

    Public Sub SStatesList_ExportTxt(ByVal pSStatesListExport_Loc As System.String, _
                                     ByVal pSepStyle As System.String, _
                                     ByRef pSStatesList() As mdlSStatesList.rSStatesList)
        'Export the array to a text file (you could import in Excel and Access)
        '   ByVal   pSStatesListExport_Loc      Path and file name of the saved file
        '   ByVal   pSepStyle                   Separator character to be use in the export
        '   ByRef   pSStatesList()              The dinamic array of the GameDB to search in

        If pSStatesList.GetLength(0) > 0 Then
            Using FileSStatesList_Tab_Writer As New System.IO.StreamWriter(pSStatesListExport_Loc, False)
                FileSStatesList_Tab_Writer.WriteLine(System.String.Concat("Serial", pSepStyle, "Slot", pSepStyle, "Backup", pSepStyle, "Filename", pSepStyle, "Size", pSepStyle, "Created", pSepStyle, "Modified", pSepStyle, "Accessed", pSepStyle, "Attributes"))
                For SStatesList_Pos As System.Int32 = 0 To pSStatesList.GetUpperBound(0)
                    FileSStatesList_Tab_Writer.WriteLine(System.String.Concat(pSStatesList(SStatesList_Pos).SStateSerial, pSepStyle, _
                                                         pSStatesList(SStatesList_Pos).Slot, pSepStyle, _
                                                         pSStatesList(SStatesList_Pos).isBackup, pSepStyle, _
                                                         pSStatesList(SStatesList_Pos).FileInfo.Name, pSepStyle, _
                                                         pSStatesList(SStatesList_Pos).FileInfo.Length, pSepStyle, _
                                                         pSStatesList(SStatesList_Pos).FileInfo.CreationTime, pSepStyle, _
                                                         pSStatesList(SStatesList_Pos).FileInfo.LastWriteTime, pSepStyle, _
                                                         pSStatesList(SStatesList_Pos).FileInfo.LastAccessTime, pSepStyle, _
                                                         pSStatesList(SStatesList_Pos).FileInfo.Attributes))
                Next SStatesList_Pos
                FileSStatesList_Tab_Writer.Close()
            End Using
        End If
    End Sub

End Module
