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
                Try
                    If File.Exists(Path.Combine(pDirectory, mdlMain.TrimBadPathChars(pSerial) & ".jpg")) Then
                        Return True
                    Else
                        Return False
                    End If
                Catch ex As Exception
                    Return False
                End Try
            End Get
        End Property
        Friend Property GameCRC As String = ""
        Friend Property GameIso As String = ""

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
        Friend Folder() As String = {"", "", ""}
        Friend FolderLastWrite() As DateTime = {DateTime.MinValue, DateTime.MinValue, DateTime.MinValue}

        Friend Sub Load(ByVal pSStatesPath As String, _
                        ByVal pSStatesStoredPath As String, _
                        ByVal pSnapsPath As String)

            Dim sw As Stopwatch = Stopwatch.StartNew

            Folder = {pSStatesPath, pSStatesStoredPath, pSnapsPath}
            Files_Count = {0, 0, 0}

            Games.Clear()

            LoadFiles(Of Savestate)(ListMode.Savestates, {My.Settings.PCSX2_SStateExt, My.Settings.PCSX2_SStateExtBackup}, pSStatesPath)

            LoadIso(My.Settings.SStatesMan_IsoExts, My.Settings.SStatesMan_PathIso)

            LoadFiles(Of Savestate)(ListMode.Stored, {My.Settings.SStatesMan_StoredExt}, pSStatesStoredPath)

            LoadFiles(Of Snapshot)(ListMode.Snapshots, My.Settings.SStatesMan_ScreenshotExts, pSnapsPath)


            sw.Stop()
            LoadTime = sw.ElapsedTicks
            If Games.Count = 0 Then
                SSMAppLog.Append(eType.LogWarning, eSrc.FileList, eSrcMethod.File_LoadAll, "No games, the list is empty.", LoadTime)
            Else
                SSMAppLog.Append(eType.LogInformation, eSrc.FileList, eSrcMethod.File_LoadAll, String.Format("{0:N0} games > {1:N0} sstates - {2:N0} stored - {3:N0} screenshots.", Games.Count, Files_Count(ListMode.Savestates), Files_Count(ListMode.Stored), Files_Count(ListMode.Snapshots)), LoadTime)
            End If
        End Sub

        Friend Sub LoadFiles(Of T As {New, PCSX2File})(pListMode As ListMode, pExts() As String, pDirectory As String)
            Dim sw As Stopwatch = Stopwatch.StartNew
            Try

                'DirectoryInfo object for retrieving files via EnumerateFiles() and accessing LastWriteTime.
                Dim tmpDI As New DirectoryInfo(pDirectory)
                FolderLastWrite(pListMode) = tmpDI.LastWriteTime

                Dim tmpFIs As IEnumerable(Of FileInfo) = tmpDI.EnumerateFiles().Where(Function(item) pExts.Contains(item.Extension.ToLower))

                If tmpFIs.Count > 0 Then

                    'Number of files that matched the extension given by pExts
                    Files_Count(pListMode) += tmpFIs.Count

                    'Load FileInfo into PCSX2File class
                    For Each tmpFI As FileInfo In tmpFIs
                        Dim tmpPF As New T With {.Name = tmpFI.Name, .Length = tmpFI.Length, .LastWriteTime = tmpFI.LastWriteTime}

                        tmpPF.GetExtraInfo(pDirectory)

                        Dim tmpSerial As String = tmpPF.GetGameSerial()

                        'If the game is not present is added to the dictionary of GameListItem in GameList
                        If Not (Games.ContainsKey(tmpSerial)) Then
                            Games.Add(tmpSerial, New GameListItem With {.GameCRC = tmpPF.GetGameCRC})
                        End If
                        'If the FileList type is not present yet is added to the GameListItem
                        If Not (Games(tmpSerial).GameFiles.ContainsKey(pListMode)) Then
                            Games(tmpSerial).GameFiles.Add(pListMode, New GameListItem.GameFileList(Of PCSX2File))
                        End If

                        'Adds the files loaded from the directory.
                        Games(tmpSerial).GameFiles(pListMode).Files.Add(tmpPF.Name, tmpPF)

                    Next

                End If

            Catch ex As Exception
                SSMAppLog.Append(eType.LogError, eSrc.FileList, eSrcMethod.List, String.Format("Error retrieving {0}." & Environment.NewLine & " {1}", pListMode.ToString, ex.Message))
            Finally
                sw.Stop()
                LoadTime = sw.ElapsedTicks
                SSMAppLog.Append(eType.LogInformation, eSrc.FileList, eSrcMethod.File_LoadAll, String.Format("Loaded {0:N0} {1} from ""{2}"".", Files_Count(pListMode), pListMode.ToString, pDirectory), LoadTime)
            End Try
        End Sub

        Friend Sub LoadIso(pExts() As String, pDirectory As String)
            Dim sw As Stopwatch = Stopwatch.StartNew
            Dim isoCount As Integer = 0
            Try
                Dim tmpDI As New DirectoryInfo(pDirectory)

                Dim tmpFIs As IEnumerable(Of FileInfo) = tmpDI.EnumerateFiles().Where(Function(item) pExts.Contains(item.Extension.ToLower))
                If tmpFIs.Count > 0 Then
                    'Load FileInfo into PCSX2File class
                    For Each tmpFI As FileInfo In tmpFIs
                        Dim tmpSerial As String = tmpFI.Name.Remove(tmpFI.Name.Length - tmpFI.Extension.Length)
                        Dim tmpString As String = tmpSerial
                        Dim ParOPosition As Integer = 0
                        Dim ParCPosition As Integer = 0
                        Do

                            If PCSX2GameDb.Records.ContainsKey(tmpSerial) Then
                                If Not Games.ContainsKey(tmpSerial) Then
                                    Games.Add(tmpSerial, New GameListItem With {.GameCRC = "00000000", .GameIso = tmpFI.Name})
                                Else
                                    Games(tmpSerial).GameIso = tmpFI.Name
                                End If
                                isoCount += 1
                                Exit Do
                            Else
                                ParOPosition = tmpString.IndexOf("["c, 0)
                                ParCPosition = tmpString.IndexOf("]"c, 0)
                                If (ParOPosition >= 0) AndAlso (ParCPosition > ParOPosition) Then
                                    tmpSerial = tmpString.Substring(ParOPosition + 1, ParCPosition - ParOPosition - 1)
                                    tmpString = tmpString.Substring(ParOPosition + 1, tmpString.Length - ParOPosition - 1)
                                Else
                                    tmpString = tmpString.Substring(ParCPosition + 1, tmpString.Length - ParCPosition - 1)
                                    tmpSerial = tmpString
                                End If
                            End If
                        Loop While ParOPosition >= 0


                    Next

                End If

            Catch ex As Exception
                SSMAppLog.Append(eType.LogError, eSrc.FileList, eSrcMethod.List, String.Format("Error retrieving iso files." & Environment.NewLine & " {0}", ex.Message))

            Finally
                sw.Stop()
                LoadTime = sw.ElapsedTicks
                SSMAppLog.Append(eType.LogInformation, eSrc.FileList, eSrcMethod.File_LoadAll, String.Format("Loaded {0:N0} iso images from ""{1}"".", isoCount, pDirectory), LoadTime)
            End Try

        End Sub
    End Class
End Module