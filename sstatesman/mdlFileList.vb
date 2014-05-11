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

    Friend Class GamesList
        Friend Games As New Dictionary(Of String, GameListItem)
        Friend LoadTimeTicks As Long = -1
        Friend Folders([Enum].GetNames(GetType(ListMode)).Length - 1) As String
        Friend FoldersLastWrite([Enum].GetNames(GetType(ListMode)).Length - 1) As DateTime
        Friend Files_Count([Enum].GetNames(GetType(ListMode)).Length - 1) As Integer

        Friend Class GameListItem
            Private _hasCoverFile As Boolean = True
            Friend ReadOnly Property HasCoverFile(pDirectory As String, pSerial As String) As Boolean
                Get
                    If _hasCoverFile AndAlso mdlMain.SafeExistFile(Path.Combine(pDirectory, Me.GetCoverFileName(pSerial))) Then
                        _hasCoverFile = True
                    Else
                        _hasCoverFile = False
                    End If
                    Return _hasCoverFile
                End Get
            End Property
            Friend ReadOnly Property GetCoverFileName(pSerial As String) As String
                Get
                    Return mdlMain.ReplaceChars(pSerial, Path.GetInvalidFileNameChars) & ".jpg"
                End Get
            End Property
            Friend GameCRC As String = String.Empty
            Friend GameIso As String = String.Empty

            Friend GameFiles As New Dictionary(Of Integer, Dictionary(Of String, PCSX2File))

            Friend Function GetFilesLenght(pListMode As ListMode, Optional pExts() As String = Nothing) As Long
                If Me.GameFiles(pListMode) IsNot Nothing AndAlso Me.GameFiles(pListMode).Count > 0 Then
                    If pExts Is Nothing Then
                        Return Me.GameFiles(pListMode).Sum(Function(item) item.Value.Length)
                    Else
                        Return Me.GameFiles(pListMode).Where(Function(item) pExts.Contains(item.Value.Extension)).Sum(Function(item) item.Value.Length)
                    End If
                Else
                    Return 0
                End If
            End Function
        End Class

        Friend Function GetFilesLenght(pListMode As ListMode, Optional pExts() As String = Nothing) As Long
            If Me.Games IsNot Nothing AndAlso Me.Games.Count > 0 Then
                Dim tmpTotal As Long = 0
                For Each tmpGame As GameListItem In Games.Values
                    tmpTotal += tmpGame.GetFilesLenght(pListMode, pExts)
                Next
                Return tmpTotal
            Else
                Return 0
            End If
        End Function

        Friend Sub New()
            For i As Integer = 0 To [Enum].GetNames(GetType(ListMode)).Length - 1
                Me.Folders(i) = String.Empty
                Me.FoldersLastWrite(i) = DateTime.MinValue
                Me.Files_Count(i) = 0
            Next i
        End Sub

        ''' <summary>Loads all the files while adding games in the GameList.</summary>
        ''' <param name="pSStatesPath">Savestates folder path.</param>
        ''' <param name="pSStatesStoredPath">Stored savestates folder path.</param>
        ''' <param name="pSnapsPath">Screenshots path.</param>
        ''' <param name="pIsoPath">Disk image path.</param>
        ''' <remarks></remarks>
        Friend Sub Load(pSStatesPath As String, _
                        pSStatesStoredPath As String, _
                        pSnapsPath As String, _
                        pIsoPath As String)

            Dim sw As Stopwatch = Stopwatch.StartNew

            Me.Folders = {pSStatesPath, pSStatesStoredPath, pSnapsPath}
            Me.Files_Count = {0, 0, 0}

            Me.Games.Clear()

            Me.LoadFiles(Of Savestate)(ListMode.Savestates, {My.Settings.PCSX2_SStateExt, My.Settings.PCSX2_SStateExtBackup}, pSStatesPath)

            Me.LoadFiles(Of Savestate)(ListMode.Stored, {My.Settings.SStatesMan_StoredExt}, pSStatesStoredPath)

            Me.LoadFiles(Of Snapshot)(ListMode.Snapshots, My.Settings.SStatesMan_ScreenshotExts, pSnapsPath)

            Me.LoadIso(My.Settings.SStatesMan_IsoExts, pIsoPath)


            sw.Stop()
            Me.LoadTimeTicks = sw.ElapsedTicks
            If Games.Count = 0 Then
                SSMAppLog.Append(eType.LogWarning, eSrc.FileList, eSrcMethod.File_LoadAll, "No games, the list is empty.", LoadTimeTicks)
            Else
                SSMAppLog.Append(eType.LogInformation, eSrc.FileList, eSrcMethod.File_LoadAll, String.Format("{0:N0} games > {1:N0} sstates - {2:N0} stored - {3:N0} screenshots.", Games.Count, Files_Count(ListMode.Savestates), Files_Count(ListMode.Stored), Files_Count(ListMode.Snapshots)), LoadTimeTicks)
            End If
        End Sub

        Private Sub LoadFiles(Of T As {New, PCSX2File})(pListMode As ListMode, pExts() As String, pDirectory As String)
            Dim sw As Stopwatch = Stopwatch.StartNew
            Try

                'DirectoryInfo object for retrieving files via EnumerateFiles() and accessing LastWriteTime.
                Dim tmpDI As New DirectoryInfo(pDirectory)
                Me.FoldersLastWrite(pListMode) = tmpDI.LastWriteTime

                Dim tmpFIs As IEnumerable(Of FileInfo) = tmpDI.EnumerateFiles().Where(Function(item) pExts.Contains(item.Extension.ToLower))

                If tmpFIs.Count > 0 Then

                    'Number of files that matched the extension given by pExts
                    Me.Files_Count(pListMode) += tmpFIs.Count

                    'Load FileInfo into PCSX2File class
                    For Each tmpFI As FileInfo In tmpFIs
                        Dim tmpPF As New T With {.Name = tmpFI.Name, .Length = tmpFI.Length, .LastWriteTime = tmpFI.LastWriteTime}

                        tmpPF.GetExtraInfo(pDirectory)

                        Dim tmpSerial As String = tmpPF.GetGameSerial()

                        'If the game is not present is added to the dictionary of GameListItem in GameList
                        Dim tmpGLI As GameListItem = Nothing
                        If Not (Me.Games.TryGetValue(tmpSerial, tmpGLI)) Then
                            tmpGLI = New GameListItem With {.GameCRC = tmpPF.GetGameCRC}
                            Me.Games.Add(tmpSerial, tmpGLI)
                        End If
                        'If the FileList type is not present yet is added to the GameListItem
                        Dim tmpGF As Dictionary(Of String, PCSX2File) = Nothing
                        If Not (tmpGLI.GameFiles.TryGetValue(pListMode, tmpGF)) Then
                            tmpGF = New Dictionary(Of String, PCSX2File)
                            tmpGLI.GameFiles.Add(pListMode, tmpGF)
                        End If

                        'Adds the files loaded from the directory.
                        tmpGF.Add(tmpPF.Name, tmpPF)

                    Next

                End If

            Catch ex As Exception
                SSMAppLog.Append(eType.LogError, eSrc.FileList, eSrcMethod.List, String.Format("Error retrieving {0}." & Environment.NewLine & " {1}", pListMode.ToString, ex.Message))
            Finally
                sw.Stop()
                LoadTimeTicks = sw.ElapsedTicks
                SSMAppLog.Append(eType.LogInformation, eSrc.FileList, eSrcMethod.File_LoadAll, String.Format("Loaded {0:N0} {1} from ""{2}"".", Files_Count(pListMode), pListMode.ToString, pDirectory), LoadTimeTicks)
            End Try
        End Sub

        Private Sub LoadIso(pExts() As String, pDirectory As String)
            Dim sw As Stopwatch = Stopwatch.StartNew
            Dim isoCount As Integer = 0
            Try
                Dim tmpIsoDI As New DirectoryInfo(pDirectory)

                Dim tmpFIs As IEnumerable(Of FileInfo) = tmpIsoDI.EnumerateFiles().Where(Function(item) pExts.Contains(item.Extension.ToLower))
                If tmpFIs.Count > 0 Then
                    'Load FileInfo into PCSX2File class
                    For Each tmpFI As FileInfo In tmpFIs
                        Dim tmpSerial As String = tmpFI.Name.Remove(tmpFI.Name.Length - tmpFI.Extension.Length)
                        Dim tmpString As String = tmpSerial
                        Dim ParOPosition As Integer = 0
                        Dim ParCPosition As Integer = 0

                        Do
                            'If tmpSerial is already in Games
                            If Me.Games.ContainsKey(tmpSerial) Then
                                'GameIso is updated
                                Me.Games(tmpSerial).GameIso = tmpFI.Name
                                isoCount += 1
                                Exit Do
                                'If tmpSerial is matched in GameDB
                            ElseIf PCSX2GameDb.ContainsGame(tmpSerial) Then
                                'New game is added
                                Me.Games.Add(tmpSerial, New GameListItem With {.GameCRC = "00000000", .GameIso = tmpFI.Name})
                                isoCount += 1
                                Exit Do
                            Else
                                ParOPosition = tmpString.IndexOf("["c, 0)
                                ParCPosition = tmpString.IndexOf("]"c, 0)
                                'If there is '[' and there is a ']' after '[' then
                                If (ParOPosition >= 0) AndAlso (ParCPosition > ParOPosition) Then
                                    'tmpSerial = 'part removed [' 'part kept' '] part also removed'
                                    tmpSerial = tmpString.Substring(ParOPosition + 1, ParCPosition - ParOPosition - 1)
                                    'tmpString = 'part already analyzed [' 'part kept'
                                    tmpString = tmpString.Substring(ParOPosition + 1, tmpString.Length - ParOPosition - 1)
                                Else
                                    'tmpString = 'partRemoved ]' 'part kept'
                                    tmpString = tmpString.Substring(ParCPosition + 1, tmpString.Length - ParCPosition - 1)
                                    tmpSerial = tmpString
                                End If
                            End If
                            'Loop exit when there are no more '['
                        Loop While ParOPosition >= 0


                    Next

                End If

            Catch ex As Exception
                SSMAppLog.Append(eType.LogError, eSrc.FileList, eSrcMethod.List, String.Format("Error retrieving iso files." & Environment.NewLine & " {0}", ex.Message))

            Finally
                sw.Stop()
                LoadTimeTicks = sw.ElapsedTicks
                SSMAppLog.Append(eType.LogInformation, eSrc.FileList, eSrcMethod.File_LoadAll, String.Format("Loaded {0:N0} iso images from ""{1}"".", isoCount, pDirectory), LoadTimeTicks)
            End Try

        End Sub
    End Class
End Module