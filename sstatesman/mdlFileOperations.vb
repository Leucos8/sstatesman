'   SStatesMan - a small frontend for PCSX2
'   Copyright (C) 2011-2014 - Leucos
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

Module mdlFileOperations
    Friend Enum FileStatus
        FreeSlot        'No savestate
        Idle            'Current file name matches new name
        RenamePending   'Current file name is different from new name
        Renamed         'The file has been renamed succesfully
        FileNotFound    'The file has not been found when renaming
        FileAlreadyExist 'A file with the target name already exist
        OtherError      'Another error has been encountered
    End Enum


#Region "Files Operation Rename/Move"
    ''' <summary>Safely move (rename) multiple files.</summary>
    ''' <param name="pSourceFileName">List of the original filenames.</param>
    ''' <param name="pDestFileName">List of the target filenames.</param>
    ''' <param name="pSourcePath">Path where input files are located.</param>
    ''' <param name="pDestPath">Path where output files will be located.</param>
    ''' <param name="pResults">List of results status flag.</param>
    ''' <param name="pResultMessages">List of message detailing the result of the operation.</param>
    ''' <param name="pOverwrite">Specifies how should be handled already existing target files</param>
    Friend Sub FileOp_MoveFiles(pSourceFilename As List(Of String), pDestFilename As List(Of String), _
                                pSourcePath As String, pDestPath As String, _
                                ByRef pResults As List(Of FileStatus), ByRef pResultMessages As List(Of String), _
                                Optional pOverwrite As Boolean = False)
        'Two For Each loops that renames the files.
        'The first loop simply adds the ".tmp" extension to the file that needs to be renamed.
        'The second loop rename the files with their proper target filename.
        'Me.OperationDone = True means that all files have been renamed (reorder button is disabled).
        If pSourceFilename.Count > 0 AndAlso _
            pDestFilename.Count > 0 AndAlso _
            pSourceFilename.Count = pDestFilename.Count Then

            Dim tmpResult As FileStatus = FileStatus.RenamePending
            Dim tmpResultMessage As String = String.Empty
            pResults = New List(Of FileStatus)
            pResultMessages = New List(Of String)

            For i As Integer = 0 To pDestFilename.Count - 1
                FileOp_MoveFile(pSourceFilename(i), AddTmpExtension(pDestFilename(i)), _
                                pSourcePath, pDestPath, tmpResult, tmpResultMessage, pOverwrite)
                pResults.Add(tmpResult)
                pResultMessages.Add(tmpResultMessage)
            Next i

            For i As Integer = 0 To pDestFilename.Count - 1
                If pResults(i) = FileStatus.Renamed Then
                    FileOp_MoveFile(AddTmpExtension(pDestFilename(i)), pDestFilename(i), _
                                    pDestPath, pDestPath, pResults(i), pResultMessages(i), pOverwrite)
                End If
            Next
        End If
    End Sub

    ''' <summary>Safely move (rename) a file.</summary>
    ''' <param name="pSourceFileName">Original file name.</param>
    ''' <param name="pDestFileName">Target file name.</param>
    ''' <param name="pSourcePath">Path where the input file is located.</param>
    ''' <param name="pDestPath">Path where the output file will be located.</param>
    ''' <param name="pResult">Result status flag.</param>
    ''' <param name="pResultMessage">Message detailing the result of the operation.</param>
    ''' <param name="pOverwrite">Specifies how should be handled already existing target files</param>
    Private Sub FileOp_MoveFile(pSourceFileName As String, pDestFileName As String, _
                                pSourcePath As String, pDestPath As String, _
                                ByRef pResult As FileStatus, ByRef pResultMessage As String, _
                                Optional pOverwrite As Boolean = False)
        Try
            Dim tmpSourceFileFullPath As String = Path.Combine(pSourcePath, pSourceFileName)
            Dim tmpDestFileFullPath As String = Path.Combine(pDestPath, pDestFileName)

            If File.Exists(tmpSourceFileFullPath) Then
                If Not (File.Exists(tmpDestFileFullPath)) Or pOverwrite Then
                    If File.Exists(tmpDestFileFullPath) Then
                        My.Computer.FileSystem.DeleteFile(tmpDestFileFullPath, _
                                                          FileIO.UIOption.OnlyErrorDialogs, _
                                                          FileIO.RecycleOption.SendToRecycleBin)
                    End If

                    File.Move(tmpSourceFileFullPath, tmpDestFileFullPath)
                    pResult = FileStatus.Renamed
                    pResultMessage = String.Format("File renamed successfully to {0}.", pDestFileName)
                    SSMAppLog.Append(eType.LogInformation, eSrc.ReorderWindow, eSrcMethod.Rename, _
                                     String.Format("File {0} renamed to {1}.", tmpSourceFileFullPath, tmpDestFileFullPath))
                Else
                    pResult = FileStatus.FileAlreadyExist
                    pResultMessage = String.Format("Target file {0} already exist. Renaming skipped.", pDestFileName)
                    SSMAppLog.Append(eType.LogWarning, eSrc.ReorderWindow, eSrcMethod.Rename, _
                                     String.Format("Renaming of {0} skipped. Target file {1} already exist.", tmpSourceFileFullPath, tmpDestFileFullPath))
                End If
            Else
                pResult = FileStatus.FileNotFound
                pResultMessage = String.Format("File {0} not found.", pSourceFileName)
                SSMAppLog.Append(eType.LogError, eSrc.ReorderWindow, eSrcMethod.Rename, _
                                 String.Format("File {1} not found.", tmpSourceFileFullPath))
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            pResult = FileStatus.OtherError
            pResultMessage = String.Format("Error renaming {0} to {1}. {2}", pSourceFileName, pDestFileName, ex.Message)
            SSMAppLog.Append(eType.LogError, eSrc.ReorderWindow, eSrcMethod.Rename, _
                             String.Format("Error renaming {0} to {1}. {2}", pSourceFileName, pDestFileName, ex.Message))
        End Try
    End Sub

    Private Function AddTmpExtension(pFilename As String) As String
        Const tmpExtension As String = ".tmp"
        Return pFilename & tmpExtension
    End Function
#End Region

End Module
