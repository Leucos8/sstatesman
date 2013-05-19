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
Module mdlGameDb
    Friend Class GameInfo
        ''' <summary>Executable code of the game.</summary>
        Friend Serial As String = ""
        ''' <summary>Name of the game.</summary>
        Friend Name As String = ""
        ''' <summary>Game Region.</summary>
        Friend Region As String = ""
        ''' <summary>Compatibility status, it should be a byte, but CByte causes overhead and exceptions.</summary>
        Friend Compat As String = ""

        ''' <summary>Converts GameInfo to string.</summary>
        ''' <returns>Return GameInfo as string using the format "Name (Region) [Serial].</returns>
        ''' <remarks></remarks>
        Public Overrides Function ToString() As String
            Return String.Format("{0} ({1}) [{2}]", Name, Region, Serial)
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
        Friend Function CompatToText() As String
            Return CompatToText(Compat)
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
        Friend Shared Function CompatToText(ByVal pCompat As String) As String
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
        Friend Function CompatToColor(ByVal pBGcolor As Color) As Color
            CompatToColor(pBGcolor, Compat)
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
        Friend Shared Function CompatToColor(ByVal pBGcolor As Color, ByVal pCompat As String) As Color
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
        Friend Records As Dictionary(Of String, GameInfo)
        ''' <summary>Status of the GameDB.</summary>
        Friend Status As LoadStatus
        ''' <summary>Load time of the GameDB.</summary>
        Friend LoadTime As Long
        ''' <summary>Path of the file loaded.</summary>
        Friend Path As String

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
        ''' <param name="pLocation">Path and file name of input database.</param>
        Friend Sub Load(ByVal pLocation As String)

            SSMAppLog.Append(LogEventType.tInformation, "GameDB", "Load", String.Format("Opening DB from ""{0}"".", pLocation))
            Try
                Dim sw As New Stopwatch
                sw.Start()

                'Initialization
                Records = New Dictionary(Of String, GameInfo)
                Status = LoadStatus.StatusNotLoaded
                LoadTime = 0
                Path = pLocation

                Dim tmpCurSerial As String = ""

                Using FileGameDb_Reader As New StreamReader(pLocation, System.Text.Encoding.Default)
                    While Not FileGameDb_Reader.EndOfStream

                        Dim tmpCurLine As String = FileGameDb_Reader.ReadLine()

                        If tmpCurLine.Length >= 2 Then
                            If Not (tmpCurLine.Substring(0, FileGameDb_CommentStyle1.Length) = FileGameDb_CommentStyle1) Then

                                Dim tmpCurLineSplitted As String() = tmpCurLine.Split({FileGameDb_FieldSep})

                                If tmpCurLineSplitted.Length > 1 Then

                                    tmpCurLineSplitted(0) = tmpCurLineSplitted(0).Trim
                                    If tmpCurLineSplitted(1).Contains(FileGameDb_CommentStyle2) Then
                                        tmpCurLineSplitted(1) = tmpCurLineSplitted(1).Remove(tmpCurLineSplitted(1).IndexOf(FileGameDb_CommentStyle2))
                                    End If
                                    tmpCurLineSplitted(1) = tmpCurLineSplitted(1).Trim

                                    If tmpCurLineSplitted(0) = FileGameDb_FieldName1 Then
                                        If Not (Records.ContainsKey(tmpCurLineSplitted(1))) Then
                                            tmpCurSerial = tmpCurLineSplitted(1)
                                            Dim tmpNewRecord As New GameInfo With {.Serial = tmpCurSerial, .Name = "", .Region = "", .Compat = ""}
                                            Records.Add(tmpCurSerial, tmpNewRecord)
                                        End If
                                    Else
                                        If Records.ContainsKey(tmpCurSerial) Then
                                            Select Case tmpCurLineSplitted(0)
                                                Case FileGameDb_FieldName2
                                                    Records(tmpCurSerial).Name = tmpCurLineSplitted(1)
                                                Case FileGameDb_FieldName3
                                                    Records(tmpCurSerial).Region = tmpCurLineSplitted(1)
                                                Case FileGameDb_FieldName4
                                                    Records(tmpCurSerial).Compat = tmpCurLineSplitted(1)
                                            End Select
                                        End If
                                    End If

                                End If
                            End If
                        End If
                    End While
                    FileGameDb_Reader.Close()
                End Using
                LoadTime = sw.ElapsedTicks
                Path = pLocation
                If Records.Count = 0 Then
                    SSMAppLog.Append(LogEventType.tWarning, "GameDB", "Load", "No records found.", LoadTime)
                    Status = LoadStatus.StatusEmpty
                Else
                    SSMAppLog.Append(LogEventType.tInformation, "GameDB", "Load", String.Format("Loaded {0:N0} records.", Records.Count), LoadTime)
                    Status = LoadStatus.StatusLoadedOK
                End If

            Catch ex As Exception
                SSMAppLog.Append(LogEventType.tCritical, "GameDB", "Load", String.Concat("Some GameDB loading failure. ", ex.Message), LoadTime)
                Status = LoadStatus.StatusError
            End Try
        End Sub

        ''' <summary>Extract a record from the database.</summary>
        ''' <param name="pSerial">The input serial.</param>
        ''' <returns>A GameInfo of the requested serial.</returns>
        ''' <remarks>
        ''' Please note that:
        ''' BIOS is a virtual record.
        ''' Error records are returned if the record is not found or the GameDB is not loaded.
        ''' </remarks>
        Friend Function Extract(ByVal pSerial As String) As GameInfo
            Dim myGameDb_RecordExtract As New GameInfo With {.Serial = pSerial, .Name = "", .Region = "", .Compat = "0"}

            If Status = LoadStatus.StatusEmpty Or Status = LoadStatus.StatusLoadedOK Then
                If pSerial.ToUpper = "BIOS" Then
                    Extract = New GameInfo With {.Serial = "BIOS", .Name = "(PS2 BIOS)", .Region = "unk", .Compat = "5"}
                ElseIf Records.ContainsKey(pSerial) Then
                    Extract = Records(pSerial)
                Else
                    Extract = New GameInfo With {.Serial = pSerial, .Name = "(Not found in GameDB)", .Region = "unk", .Compat = "0"}
                End If
                'SSMAppLog.Append(LogEventType.tInformation, "GameDB", "RecordExtract", String.Format("{0} > ""{1}"".", pSerial, Extract.Name))
            ElseIf Status = LoadStatus.StatusNotLoaded Then
                Extract = New GameInfo With {.Serial = pSerial, .Name = "(GameDB not loaded)", .Region = "", .Compat = "0"}
                SSMAppLog.Append(LogEventType.tWarning, "GameDB", "RecordExtract", String.Format("Failed for {0}, GameDB is not loaded.", pSerial))
            ElseIf Status = LoadStatus.StatusError Then
                Extract = New GameInfo With {.Serial = pSerial, .Name = "(GameDB error)", .Region = "", .Compat = "0"}
                SSMAppLog.Append(LogEventType.tWarning, "GameDB", "RecordExtract", String.Format("Failed for {0}, GameDB was not loaded because of an error.", pSerial))
            Else
                Extract = New GameInfo With {.Serial = pSerial, .Name = "(GameDB error)", .Region = "", .Compat = "0"}
                SSMAppLog.Append(LogEventType.tCritical, "GameDB", "RecordExtract", String.Format("Failed for {0}, DB status is {1}", pSerial, Status.ToString))
            End If

            Return Extract
        End Function
        ''' <summary>Extract multiple records based on a list of serials (strings).</summary>
        ''' <param name="pSerial">The list of serials.</param>
        ''' <param name="pExtractedGameDb">The GameDB structure that will contain the extracted records.</param>
        ''' <returns>The LoadStatus of pExtractedGameDb.</returns>
        Friend Function Extract(ByVal pSerial As List(Of String), _
                                ByRef pExtractedGameDb As Dictionary(Of String, GameInfo) _
                                ) As mdlMain.LoadStatus
            Dim sw As Stopwatch = Stopwatch.StartNew

            If Status = LoadStatus.StatusLoadedOK Or Status = LoadStatus.StatusEmpty Then

                For Each tmpSerial As String In pSerial
                    pExtractedGameDb.Add(Extract(tmpSerial).Serial, Extract(tmpSerial))
                Next

                If pExtractedGameDb.Count > 0 Then
                    Return LoadStatus.StatusLoadedOK
                Else
                    Return LoadStatus.StatusEmpty
                End If

                sw.Stop()
                SSMAppLog.Append(LogEventType.tInformation, "GameDB", "RecordExtract", "From multiple serials.", sw.ElapsedTicks)
            ElseIf Status = LoadStatus.StatusNotLoaded Then
                sw.Stop()
                SSMAppLog.Append(LogEventType.tWarning, "GameDB", "RecordExtract", "Failed for multiple serials, GameDB was not loaded.", sw.ElapsedTicks)
                Return LoadStatus.StatusNotLoaded
            ElseIf Status = LoadStatus.StatusError Then
                sw.Stop()
                SSMAppLog.Append(LogEventType.tWarning, "GameDB", "RecordExtract", "Failed for multiple serials, GameDB was not loaded because of an error.", sw.ElapsedTicks)
                Return LoadStatus.StatusNotLoaded
            Else
                sw.Stop()
                SSMAppLog.Append(LogEventType.tCritical, "GameDB", "RecordExtract", "Failed for multiple serials, Status is set to " & Status.ToString, sw.ElapsedTicks)
                Return LoadStatus.StatusError
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
                               ByVal pSerial As String, _
                               ByVal pGameTitle As String, _
                               ByVal pGameRegion As String, _
                               ByVal pGameCompat As String, _
                               ByVal pSearchType As Byte) As mdlMain.LoadStatus

            Dim sw As New Stopwatch
            sw.Start()

            pSearchResult.Clear()
            Dim myRecords As IEnumerable(Of KeyValuePair(Of String, GameInfo)) = Nothing
            If pSearchType = 0 Then
                'And
                myRecords = From tmpGameInfo As KeyValuePair(Of String, GameInfo) In Records _
                            Where (tmpGameInfo.Key.ToUpper.Contains(pSerial) And _
                                   tmpGameInfo.Value.Name.ToUpper.Contains(pGameTitle.ToUpper) And _
                                   tmpGameInfo.Value.Region.ToUpper.Contains(pGameRegion.ToUpper) And _
                                   tmpGameInfo.Value.Compat.Contains(pGameCompat)) _
                            Select tmpGameInfo

            ElseIf pSearchType = 1 Then
                'Or
                myRecords = From tmpGameInfo As KeyValuePair(Of String, GameInfo) In Records _
                            Where ((Not (pSerial.Length = 0) And tmpGameInfo.Key.ToUpper.Contains(pSerial)) Or _
                                   (Not (pGameTitle.Length = 0) And tmpGameInfo.Value.Name.ToUpper.Contains(pGameTitle.ToUpper)) Or _
                                   (Not (pGameRegion.Length = 0) And tmpGameInfo.Value.Region.ToUpper.Contains(pGameRegion.ToUpper)) Or _
                                   (Not (pGameCompat.Length = 0) And tmpGameInfo.Value.Compat.Contains(pGameCompat))) _
                            Select tmpGameInfo
            End If

            If (myRecords IsNot Nothing) Then
                For Each tmpGame In myRecords
                    pSearchResult.Add(tmpGame.Key)
                Next
                sw.Stop()
                SSMAppLog.Append(LogEventType.tInformation, "GameDB", "Search", String.Format("Found {0:N0} records.", pSearchResult.Count), sw.ElapsedTicks)
                Return LoadStatus.StatusLoadedOK
            Else
                sw.Stop()
                SSMAppLog.Append(LogEventType.tInformation, "GameDB", "Search", String.Format("No records found.", pSearchResult.Count), sw.ElapsedTicks)
                Return LoadStatus.StatusEmpty
            End If
        End Function

        ''' <summary>Export the gamedb to a text file (it can be imported in Excel and Access).</summary>
        ''' <param name="pExportLocation">Path and file name of the saved file.</param>
        ''' <param name="pSep">Separator character to be used in the exported file.</param>
        Friend Sub ExportTxt(ByVal pExportLocation As String, ByVal pSep As String)
            GameDB.ExportTxt(pExportLocation, pSep, Records)
        End Sub

        ''' <summary>Export the gamedb to a text file (it can be imported in Excel and Access). Shared method.</summary>
        ''' <param name="pExportLocation">Path and file name of the saved file.</param>
        ''' <param name="pSep">Separator character to be used in the exported file.</param>
        ''' <param name="pRecords">Records list that will be saved in the file.</param>
        Friend Shared Sub ExportTxt(ByVal pExportLocation As String, _
                                    ByVal pSep As String, _
                                    ByVal pRecords As Dictionary(Of String, GameInfo))

            If pRecords.Count > 0 Then
                Using FileGameDb_Tab_Writer As New StreamWriter(pExportLocation, False)
                    'Headers
                    FileGameDb_Tab_Writer.WriteLine(String.Concat("Serial", pSep, "Name", pSep, "Region", pSep, "Compat"))

                    For Each myTmpGame As KeyValuePair(Of String, GameInfo) In pRecords

                        FileGameDb_Tab_Writer.WriteLine(String.Concat(myTmpGame.Key, pSep, _
                                                                      myTmpGame.Value.Name, pSep, _
                                                                      myTmpGame.Value.Region, pSep, _
                                                                      myTmpGame.Value.Compat))
                    Next
                    FileGameDb_Tab_Writer.Close()
                End Using
            End If
        End Sub

    End Structure

End Module