'   SStatesMan - a savestate managing tool for PCSX2
'   Copyright (C) 2011-2013 - Leucos
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
    Friend Enum ListMode
        Savestates
        Stored
        Snapshots
    End Enum

    Dim Files_Count() As Integer = {0, 0, 0}

    Friend Class GameListItem
        Friend ReadOnly Property HasCoverFile(pDirectory As String, pSerial As String) As Boolean
            Get
                If File.Exists(Path.Combine(pDirectory, mdlMain.TrimBadPathChars(pSerial) & ".jpg")) Then
                    Return True
                Else
                    Return False
                End If
            End Get
        End Property
        'Friend ReadOnly Property HasIsoFile
        Friend Property GameCRC As String = ""

        Friend GameFiles As New Dictionary(Of Integer, GameFileList(Of PCSX2File))

        Friend Class GameFileList(Of T As PCSX2File)
            Friend Files As New Dictionary(Of String, T)
            Friend ReadOnly Property SizeTot(ByVal pExts() As String) As Long
                Get
                    If Files IsNot Nothing AndAlso Files.Count > 0 Then
                        If pExts Is Nothing Then
                            Return Files.Sum(Function(item) item.Value.Length)
                        Else
                            Return Files.Where(Function(item) pExts.Contains(item.Value.Extension)).Sum(Function(item) item.Value.Length)
                        End If
                    Else
                        Return 0
                    End If
                End Get
            End Property
        End Class

    End Class

    Friend Class GamesList
        Friend Games As New Dictionary(Of String, GameListItem)
        Friend LoadTime As Long
        Friend SStatesFolder_LastModified As DateTime
        Friend SStatesStored_FolderLastModified As DateTime
        Friend SnapsFolder_LastModified As DateTime

        Friend Sub Load(ByVal pSStatesPath As String, _
                        ByVal pSStatesStoredPath As String, _
                        ByVal pSnapsPath As String)

            Dim sw As Stopwatch = Stopwatch.StartNew

            Files_Count = {0, 0, 0}

            Games.Clear()

            LoadFiles(Of Savestate)(pSStatesPath, {My.Settings.PCSX2_SStateExt, My.Settings.PCSX2_SStateExtBackup}, ListMode.Savestates, SStatesFolder_LastModified)

            LoadFiles(Of Savestate)(pSStatesStoredPath, {My.Settings.PCSX2_SStateExt}, ListMode.Stored, SStatesStored_FolderLastModified)

            LoadFiles(Of Snapshot)(pSnapsPath, My.Settings.SStatesMan_ScreenshotExts, ListMode.Snapshots, SnapsFolder_LastModified)


            sw.Stop()
            LoadTime = sw.ElapsedTicks
            If Games.Count = 0 Then
                SSMAppLog.Append(eType.LogWarning, eSrc.FileList, eSrcMethod.File_LoadAll, "No games, the list is empty.", LoadTime)
            Else
                SSMAppLog.Append(eType.LogInformation, eSrc.FileList, eSrcMethod.File_LoadAll, String.Format("{0:N0} games > {1:N0} sstates - {2:N0} stored - {3:N0} screenshots.", Games.Count, Files_Count(ListMode.Savestates), Files_Count(ListMode.Stored), Files_Count(ListMode.Snapshots)), LoadTime)
            End If
        End Sub

        Friend Sub LoadFiles(Of T As {New, PCSX2File})(pDirectory As String, pExts() As String, pListKey As ListMode, ByRef pLastWriteTime As Date)
            Try
                Dim tmpDirectoryInfo As New DirectoryInfo(pDirectory)
                pLastWriteTime = tmpDirectoryInfo.LastWriteTime

                Dim tmpFileInfos As IEnumerable(Of FileInfo) = tmpDirectoryInfo.EnumerateFiles().Where(Function(item) pExts.Contains(item.Extension.ToLower))

                If tmpFileInfos.Count > 0 Then

                    Files_Count(pListKey) += tmpFileInfos.Count

                    For Each tmpFileInfo As FileInfo In tmpFileInfos
                        Dim tmpFile As New T With {.Name = tmpFileInfo.Name, .Length = tmpFileInfo.Length, .LastWriteTime = tmpFileInfo.LastWriteTime}

                        tmpFile.GetExtraInfo(pDirectory)

                        Dim tmpSerial As String = tmpFile.GetGameSerial()

                        If Not (Games.ContainsKey(tmpSerial)) Then
                            Games.Add(tmpSerial, New GameListItem With {.GameCRC = tmpFile.GetGameCRC})
                        End If

                        If Not (Games(tmpSerial).GameFiles.ContainsKey(pListKey)) Then
                            Games(tmpSerial).GameFiles.Add(pListKey, New GameListItem.GameFileList(Of PCSX2File))
                        End If

                        Games(tmpSerial).GameFiles(pListKey).Files.Add(tmpFile.Name, tmpFile)

                    Next

                End If

            Catch ex As Exception
                SSMAppLog.Append(eType.LogError, eSrc.FileList, eSrcMethod.List, String.Format("Error retrieving {0}." & Environment.NewLine & " {1}", pListKey.ToString, ex.Message))
            End Try
        End Sub

    End Class
End Module