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
Module mdlGameDb
    Friend Class GameInfo
        ''' <summary>Executable code of the game.</summary>
        Friend Serial As String = String.Empty
        ''' <summary>Name of the game.</summary>
        Friend Name As String = String.Empty
        ''' <summary>Game Region.</summary>
        Friend Region As String = String.Empty
        ''' <summary>Compatibility status, it should be a byte, but CByte causes overhead and exceptions.</summary>
        Friend Compat As String = String.Empty

        ''' <summary>Converts GameInfo to string.</summary>
        ''' <returns>Return GameInfo as string using the format "Name (Region) [Serial].</returns>
        ''' <remarks></remarks>
        Public Overrides Function ToString() As String
            Return String.Format("{0} ({1}) [{2}]", Me.Name, Me.Region, Me.Serial)
        End Function

        ''' <summary>Converts Compat to a meaningful string.</summary>
        ''' <returns>
        ''' Return the following values:
        ''' "Unknwon" for 0
        ''' "Nothing" for 1
        ''' "Intro" for 2
        ''' "Menus" for 3
        ''' "in-Game" for 4
        ''' "Playable" for 5
        ''' "Perfect" for 6
        ''' "Missing" for everything else.
        ''' </returns>
        ''' <remarks>This is the class function.</remarks>
        Friend Function CompatText() As String
            Return GameInfo.CompatText(Me.Compat)
        End Function
        ''' <summary>Converts Compat to a meaningful string.</summary>
        ''' <param name="pCompat">The input compat value.</param>
        ''' <returns>
        ''' Return the following values:
        ''' "Unknwon" for 0
        ''' "Nothing" for 1
        ''' "Intro" for 2
        ''' "Menus" for 3
        ''' "in-Game" for 4
        ''' "Playable" for 5
        ''' "Perfect" for 6
        ''' "Missing" for everything else.
        ''' </returns>
        ''' <remarks>This is the shared function.</remarks>
        Friend Shared Function CompatText(pCompat As String) As String
            Select Case pCompat
                Case "0" : Return "Unknown"
                Case "1" : Return "Nothing"
                Case "2" : Return "Intro"
                Case "3" : Return "Menus"
                Case "4" : Return "in-Game"
                Case "5" : Return "Playable"
                Case "6" : Return "Perfect"
                Case Else : Return "Missing"
            End Select
        End Function

        ''' <summary>Converts Compat to a color.</summary>
        ''' <param name="pBGcolor">Default returned color if a match is not found.</param>
        ''' <returns>
        ''' Return the following values:
        ''' BgColor for 0
        ''' Red for 1
        ''' Orange for 2
        ''' Yellow for 3
        ''' Purple for 4
        ''' Green for 5
        ''' Blue for 6
        ''' BgColor for everything else.
        ''' </returns>
        ''' <remarks>This is the class function.</remarks>
        Friend Function CompatColor(pBGcolor As Color) As Color
            Return GameInfo.CompatColor(pBGcolor, Me.Compat)
        End Function
        ''' <summary>Converts Compat to a color.</summary>
        ''' <param name="pBGcolor">Default returned color if a match is not found.</param>
        ''' <param name="pCompat">Input Compat value.</param>
        ''' <returns>
        ''' Return the following values:
        ''' BgColor for 0
        ''' Red for 1
        ''' Orange for 2
        ''' Yellow for 3
        ''' Purple for 4
        ''' Green for 5
        ''' Blue for 6
        ''' BgColor for everything else.
        ''' </returns>
        ''' <remarks>This is the shared function.</remarks>
        Friend Shared Function CompatColor(pBGcolor As Color, pCompat As String) As Color
            Select Case pCompat
                Case "0" : Return pBGcolor                              'Unknown
                Case "1" : Return Color.FromArgb(255, 255, 192, 192)    'Nothing:    Red
                Case "2" : Return Color.FromArgb(255, 255, 224, 192)    'Intro:      Orange
                Case "3" : Return Color.FromArgb(255, 255, 255, 192)    'Menus:      Yellow
                Case "4" : Return Color.FromArgb(255, 255, 192, 255)    'in-Game:    Purple
                Case "5" : Return Color.FromArgb(255, 192, 255, 192)    'Playable:   Green
                Case "6" : Return Color.FromArgb(255, 192, 192, 255)    'Perfect:    Blue
                Case Else : Return pBGcolor
            End Select
        End Function
    End Class

    ''' <summary>Supplies the methods to access records contained in a PCSX2 GameDB.</summary>
    Friend Structure GameDB
        ''' <summary>Dictionary of <c>GameInfo</c> records.</summary>
        Private _records As Dictionary(Of String, GameInfo)
        Friend ReadOnly Property Records As List(Of GameInfo)
            Get
                Return Me._records.Values.ToList
            End Get
        End Property

        ''' <summary>Count of records in db</summary>
        Friend ReadOnly Property Count() As Integer
            Get
                If (Me._records IsNot Nothing) AndAlso (Me.DBState <= LoadStatus.StatusLoadedOK) Then
                    Return Me._records.Count
                Else
                    Return 0
                End If
            End Get
        End Property

        ''' <summary>Status of the GameDB.</summary>
        Private _DBState As LoadStatus
        Friend ReadOnly Property DBState() As LoadStatus
            Get
                Return _DBState
            End Get
        End Property
        ''' <summary>Load time of the GameDB.</summary>
        Private _loadTimeTicks As Long
        Friend ReadOnly Property LoadTimeTicks() As Long
            Get
                Return _loadTimeTicks
            End Get
        End Property
        ''' <summary>Path of the file loaded.</summary>
        Private _path As String
        Friend ReadOnly Property Path() As String
            Get
                Return _path
            End Get
        End Property


        'Constants
        Private Const FileGameDb_FieldSep As Char = "="c         'Field separator in the database
        Private Const FileGameDb_CommentStyle1 As String = "--"  'C++ comment style 1 (usually the start of the line)
        Private Const FileGameDb_CommentStyle2 As String = "//"  'C++ comment style 2 (usually in the line)
        Private Const FileGameDb_CommentStyle3 As Char = ";"c    'C++ comment style 3 (not used yet)

        Private Const FileGameDb_FieldName1 As String = "Serial" 'Database first field name, also the index
        Private Const FileGameDb_FieldName2 As String = "Name"   'Database second field name
        Private Const FileGameDb_FieldName3 As String = "Region" 'Database third field name
        Private Const FileGameDb_FieldName4 As String = "Compat" 'Database fourth field name

        ''' <summary>Loads the GameDB from the given file.</summary>
        ''' <param name="pDBPath">Path and file name of input database.</param>
        Friend Sub LoadDB(pDBPath As String)

            SSMAppLog.Append(eType.LogInformation, eSrc.GameDB, eSrcMethod.Load, String.Format("Opening DB from ""{0}"".", pDBPath))
            Try
                Dim sw As New Stopwatch
                sw.Start()

                'Initialization
                Me.ClearDB()
                Me._path = pDBPath

                Dim tmpSerial As String = String.Empty

                Using GameDBFileReader As New StreamReader(pDBPath, System.Text.Encoding.Default)

                    While Not GameDBFileReader.EndOfStream

                        Dim tmpLine As String = GameDBFileReader.ReadLine()

                        'String.StartsWith() is slow.
                        If (tmpLine.Length >= 2) AndAlso _
                            (Not (tmpLine.Substring(0, FileGameDb_CommentStyle1.Length) = FileGameDb_CommentStyle1)) Then

                            Dim tmpLineSplitted As String() = tmpLine.Split({FileGameDb_FieldSep}, 2)

                            If (tmpLineSplitted IsNot Nothing) AndAlso (tmpLineSplitted.Length > 1) Then

                                tmpLineSplitted(0) = tmpLineSplitted(0).Trim
                                If tmpLineSplitted(1).Contains(FileGameDb_CommentStyle2) Then
                                    tmpLineSplitted(1) = tmpLineSplitted(1).Remove(tmpLineSplitted(1).IndexOf(FileGameDb_CommentStyle2))
                                End If
                                tmpLineSplitted(1) = tmpLineSplitted(1).Trim

                                'Serial field
                                If (tmpLineSplitted(0) = FileGameDb_FieldName1) AndAlso (Not (Me._records.ContainsKey(tmpLineSplitted(1)))) Then
                                    tmpSerial = tmpLineSplitted(1)
                                    Me._records.Add(tmpSerial, New GameInfo With {.Serial = tmpSerial, .Name = String.Empty, .Region = String.Empty, .Compat = String.Empty})
                                Else
                                    If Me._records.ContainsKey(tmpSerial) Then
                                        Select Case tmpLineSplitted(0)
                                            Case FileGameDb_FieldName2
                                                Me._records(tmpSerial).Name = tmpLineSplitted(1)
                                            Case FileGameDb_FieldName3
                                                Me._records(tmpSerial).Region = tmpLineSplitted(1)
                                            Case FileGameDb_FieldName4
                                                Me._records(tmpSerial).Compat = tmpLineSplitted(1)
                                        End Select
                                    End If
                                End If

                            End If
                        End If
                    End While
                    GameDBFileReader.Close()
                End Using
                Me._loadTimeTicks = sw.ElapsedTicks
                If _records.Count = 0 Then
                    SSMAppLog.Append(eType.LogWarning, eSrc.GameDB, eSrcMethod.Load, "No records found.", LoadTimeTicks)
                    Me._DBState = LoadStatus.StatusEmpty
                Else
                    SSMAppLog.Append(eType.LogInformation, eSrc.GameDB, eSrcMethod.Load, String.Format("Loaded {0:N0} records.", _records.Count), LoadTimeTicks)
                    Me._DBState = LoadStatus.StatusLoadedOK
                End If

            Catch ex As Exception
                SSMAppLog.Append(eType.LogCritical, eSrc.GameDB, eSrcMethod.Load, String.Concat("Some GameDB loading failure. ", ex.Message), LoadTimeTicks)
                Me._DBState = LoadStatus.StatusError
            End Try
        End Sub

        ''' <summary>Initialize GameDB</summary>
        Friend Sub ClearDB()
            Me._records = New Dictionary(Of String, GameInfo)
            Me._DBState = LoadStatus.StatusNotLoaded
            Me._loadTimeTicks = 0
            Me._path = String.Empty
        End Sub

        ''' <summary>Extract a record from the database.</summary>
        ''' <param name="pSerial">The input serial.</param>
        ''' <returns>The output record.</returns>
        ''' <remarks>
        ''' Please note that:
        ''' BIOS is a virtual record.
        ''' Error records are returned if the record is not found or the GameDB is not loaded.
        ''' </remarks>
        Friend Function GetGameInfo(pSerial As String) As GameInfo
            If (Me.DBState = LoadStatus.StatusEmpty) OrElse (Me.DBState = LoadStatus.StatusLoadedOK) Then
                If pSerial.ToUpper = "BIOS" Then
                    Return New GameInfo With {.Serial = "BIOS", .Name = "(PS2 BIOS)", .Region = "unk", .Compat = "5"}
                ElseIf _records.ContainsKey(pSerial) Then
                    Return _records(pSerial)
                Else
                    Return New GameInfo With {.Serial = pSerial, .Name = "(Not found in GameDB)", .Region = "unk", .Compat = "0"}
                End If
                'SSMAppLog.Append(LogEventType.tInformation, eSrc.GameDB, eSrcMethod.Extract, String.Format("{0} > ""{1}"".", pSerial, Extract.Name))
            ElseIf Me.DBState = LoadStatus.StatusNotLoaded Then
                SSMAppLog.Append(eType.LogWarning, eSrc.GameDB, eSrcMethod.Extract, String.Format("Failed for {0}, GameDB is not loaded.", pSerial))
                Return New GameInfo With {.Serial = pSerial, .Name = "(GameDB not loaded)", .Region = String.Empty, .Compat = "0"}
            ElseIf Me.DBState = LoadStatus.StatusError Then
                SSMAppLog.Append(eType.LogWarning, eSrc.GameDB, eSrcMethod.Extract, String.Format("Failed for {0}, GameDB was not loaded because of an error.", pSerial))
                Return New GameInfo With {.Serial = pSerial, .Name = "(GameDB error)", .Region = String.Empty, .Compat = "0"}
            Else
                SSMAppLog.Append(eType.LogCritical, eSrc.GameDB, eSrcMethod.Extract, String.Format("Failed for {0}, DB status is {1}", pSerial, Me.DBState.ToString))
                Return New GameInfo With {.Serial = pSerial, .Name = "(GameDB error)", .Region = String.Empty, .Compat = "0"}
            End If
        End Function
        ''' <summary>Extract multiple records based on a list of serials (strings).</summary>
        ''' <param name="pSerial">The list of serials.</param>
        ''' <param name="pExtractedRecords">The GameDB structure that will contain the extracted records.</param>
        ''' <returns>The LoadStatus of pExtractedGameDb.</returns>
        Friend Function GetGameInfo(pSerial As List(Of String), _
                                    ByRef pExtractedRecords As List(Of GameInfo) _
                                    ) As mdlMain.LoadStatus
            Dim sw As Stopwatch = Stopwatch.StartNew

            If Me.DBState = LoadStatus.StatusLoadedOK Or Me.DBState = LoadStatus.StatusEmpty Then

                For Each tmpSerial As String In pSerial
                    Dim tmpGI As New GameInfo
                    If Me._records.TryGetValue(tmpSerial, tmpGI) Then
                        pExtractedRecords.Add(tmpGI)
                    End If
                Next

                If pExtractedRecords.Count > 0 Then
                    Return LoadStatus.StatusLoadedOK
                Else
                    Return LoadStatus.StatusEmpty
                End If

                sw.Stop()
                SSMAppLog.Append(eType.LogInformation, eSrc.GameDB, eSrcMethod.Extract, "From multiple serials.", sw.ElapsedTicks)
            ElseIf DBState = LoadStatus.StatusNotLoaded Then
                sw.Stop()
                SSMAppLog.Append(eType.LogWarning, eSrc.GameDB, eSrcMethod.Extract, "Failed for multiple serials, GameDB was not loaded.", sw.ElapsedTicks)
                Return LoadStatus.StatusNotLoaded
            ElseIf DBState = LoadStatus.StatusError Then
                sw.Stop()
                SSMAppLog.Append(eType.LogWarning, eSrc.GameDB, eSrcMethod.Extract, "Failed for multiple serials, GameDB was not loaded because of an error.", sw.ElapsedTicks)
                Return LoadStatus.StatusNotLoaded
            Else
                sw.Stop()
                SSMAppLog.Append(eType.LogCritical, eSrc.GameDB, eSrcMethod.Extract, "Failed for multiple serials, Status is set to " & DBState.ToString, sw.ElapsedTicks)
                Return LoadStatus.StatusError
            End If

        End Function

        ''' <summary>Returns if the serial is contained in the DB.</summary>
        ''' <param name="pSerial">Serial to search.</param>
        ''' <returns>True if the record is found, false if not.</returns>
        Friend Function ContainsGame(pSerial As String) As Boolean
            If (Me._records IsNot Nothing) AndAlso (Me._records.Count > 0) Then
                Return Me._records.ContainsKey(pSerial)
            Else
                Return False
            End If
        End Function

        ''' <summary>Returns a list of strings which are the dictionary keys (serials) of the records found in the GameDb.</summary>
        ''' <param name="pSearchResult">The string list where the serials will be stored.</param>
        ''' <param name="pSerial">Serial to search.</param>
        ''' <param name="pGameTitle">Game title to search.</param>
        ''' <param name="pGameRegion">Game region to search.</param>
        ''' <param name="pGameCompat">Game compat to search.</param>
        ''' <param name="pSearchType">Determines if the search will use the <c>And</c> or <c>Or</c> criteria</param>
        ''' <returns>LoadStatus (<c>MdlMain.LoadStatus</c>)</returns>
        Friend Function Search(ByRef pSearchResult As List(Of String), _
                               pSerial As String, _
                               pGameTitle As String, _
                               pGameRegion As String, _
                               pGameCompat As String, _
                               pSearchType As Byte) As mdlMain.LoadStatus

            Dim sw As New Stopwatch
            sw.Start()

            pSearchResult.Clear()
            Dim myRecords As IEnumerable(Of KeyValuePair(Of String, GameInfo)) = Nothing
            If pSearchType = 0 Then
                'And
                myRecords = From tmpGameInfo As KeyValuePair(Of String, GameInfo) In _records _
                            Where (tmpGameInfo.Key.ToUpper.Contains(pSerial) AndAlso _
                                   tmpGameInfo.Value.Name.ToUpper.Contains(pGameTitle.ToUpper) AndAlso _
                                   tmpGameInfo.Value.Region.ToUpper.Contains(pGameRegion.ToUpper) AndAlso _
                                   tmpGameInfo.Value.Compat.Contains(pGameCompat)) _
                            Select tmpGameInfo

            ElseIf pSearchType = 1 Then
                'Or
                myRecords = From tmpGameInfo As KeyValuePair(Of String, GameInfo) In _records _
                            Where ((Not (pSerial.Length = 0) AndAlso tmpGameInfo.Key.ToUpper.Contains(pSerial)) Or _
                                   (Not (pGameTitle.Length = 0) AndAlso tmpGameInfo.Value.Name.ToUpper.Contains(pGameTitle.ToUpper)) Or _
                                   (Not (pGameRegion.Length = 0) AndAlso tmpGameInfo.Value.Region.ToUpper.Contains(pGameRegion.ToUpper)) Or _
                                   (Not (pGameCompat.Length = 0) AndAlso tmpGameInfo.Value.Compat.Contains(pGameCompat))) _
                            Select tmpGameInfo
            End If

            If (myRecords IsNot Nothing) Then
                For Each tmpGame As KeyValuePair(Of String, GameInfo) In myRecords
                    pSearchResult.Add(tmpGame.Key)
                Next
                sw.Stop()
                SSMAppLog.Append(eType.LogInformation, eSrc.GameDB, eSrcMethod.Search, String.Format("Found {0:N0} records.", pSearchResult.Count), sw.ElapsedTicks)
                Return LoadStatus.StatusLoadedOK
            Else
                sw.Stop()
                SSMAppLog.Append(eType.LogInformation, eSrc.GameDB, eSrcMethod.Search, String.Format("No records found.", pSearchResult.Count), sw.ElapsedTicks)
                Return LoadStatus.StatusEmpty
            End If
        End Function

        ''' <summary>Export the gamedb to a text file (it can be imported in Excel and Access).</summary>
        ''' <param name="pExportFile">Path and file name of the saved file.</param>
        ''' <param name="pSep">Separator character to be used in the exported file.</param>
        Friend Sub SaveTxt(pExportFile As String, pSep As String)
            GameDB.SaveTxt(pExportFile, pSep, Me.Records)
        End Sub

        ''' <summary>Export the gamedb to a text file (it can be imported in Excel and Access). Shared method.</summary>
        ''' <param name="pExportFile">Path and file name of the saved file.</param>
        ''' <param name="pSep">Separator character to be used in the exported file.</param>
        ''' <param name="pRecords">Records list that will be saved in the file.</param>
        Friend Shared Sub SaveTxt(pExportFile As String, _
                                  pSep As String, _
                                  pRecords As List(Of GameInfo))

            If pRecords.Count > 0 Then
                Using FileGameDb_Tab_Writer As New StreamWriter(pExportFile, False)
                    'Headers
                    FileGameDb_Tab_Writer.WriteLine(String.Concat("Serial", pSep, "Name", pSep, "Region", pSep, "Compat"))

                    For Each myTmpGame As GameInfo In pRecords

                        FileGameDb_Tab_Writer.WriteLine(String.Concat(myTmpGame.Serial, pSep, _
                                                                      myTmpGame.Name, pSep, _
                                                                      myTmpGame.Region, pSep, _
                                                                      myTmpGame.Compat))
                    Next
                    FileGameDb_Tab_Writer.Close()
                End Using
            End If
        End Sub

    End Structure

End Module