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
Imports System.IO

Module mdlGameDb
    Public Class GameInfo
        ''' <summary>Executable code of the game.</summary>
        ''' <value>normally in the (4 letter)-(5 digits). There are exceptions, though (I'm looking at you GTA III)</value>
        Public Property Serial As String
        ''' <summary>Name of the game.</summary>
        ''' <value>Currently the longest one is 150 char or so...</value>
        Public Property Name As String
        ''' <summary>
        ''' Game Region, nuff said
        ''' </summary>
        ''' <value>PAL, NTSC, etc.</value>
        Public Property Region As String
        ''' <summary>Compatibility status, it should be a byte, but CByte causes overhead and exceptions.</summary>
        ''' <value>Hopefully values from 0 to 6, if not an empty string.</value>
        Public Property Compat As String      '

        Public Overrides Function ToString() As String
            Return String.Format("{0} ({1}) [{2}]", Name, Region, Serial)
        End Function

        Public Function CompatToText() As String
            Select Case Compat
                Case "0" : Return "Unknown"
                Case "1" : Return "Nothing"
                Case "2" : Return "Intro"
                Case "3" : Return "Menus"
                Case "4" : Return "in-Game"
                Case "5" : Return "Playable"
                Case "6" : Return "Perfect"
                Case "" : Return "Missing"
                Case Else : Return "Undetected"
            End Select
        End Function

        Public Shared Function CompatToText(ByVal pCompat As String) As String
            Dim tmpGameInfo As New GameInfo With {.Compat = pCompat}
            Return tmpGameInfo.CompatToText()
        End Function

        Public Function CompatToColor(ByVal pBGcolor As Color) As Color
            Select Case Compat
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

        Public Shared Function CompatToColor(ByVal pBGcolor As Color, ByVal pCompat As String) As Color
            Dim tmpGameInfo As New GameInfo With {.Compat = pCompat}
            Return tmpGameInfo.CompatToColor(pBGcolor)
        End Function
    End Class

    ''' <summary>Object that will be used to contain the PCSX2 GameDB used by SStatesMan.</summary>
    Public PCSX2GameDb As New GameDB

    ''' <summary>Supplies the methods to access records contained in a PCSX2 GameDB.</summary>
    Public Class GameDB
        ''' <summary>Dictionary of <c>GameInfo</c> records.</summary>
        ''' <value>Contains all the records in the GameDB</value>
        Public Property Records As New Dictionary(Of String, GameInfo)
        ''' <summary>Status of the GameDB.</summary>
        ''' <value>Returns if the GameDB, is not loaded, empty or if an error has occurred.</value>
        Public Property Status As mdlMain.LoadStatus = mdlMain.LoadStatus.StatusNotLoaded
        ''' <summary>Load time of the GameDB.</summary>
        ''' <value>Load time in milliseconds.</value>
        Public Property LoadTime As Long = 0

        'Constants
        Const FileGameDb_FieldSep As Char = "="c         'Field separator in the database
        Const FileGameDb_CommentStyle1 As String = "--"  'C++ comment style 1 (usually the start of the line)
        Const FileGameDb_CommentStyle2 As String = "//"  'C++ comment style 2 (usually in the line)
        Const FileGameDb_CommentStyle3 As Char = ";"c    'C++ comment style 3 (not used yet)

        Const FileGameDb_FieldName1 As String = "Serial" 'Database first field name, also the index
        Const FileGameDb_FieldName2 As String = "Name"   'Database second field name
        Const FileGameDb_FieldName3 As String = "Region" 'Database third field name
        Const FileGameDb_FieldName4 As String = "Compat" 'Database fourth field name

        ''' <summary>Loads the GameDB from the given file.</summary>
        ''' <param name="pFileGameDb_Loc">Path and file name of input database.</param>
        Public Sub Load(ByVal pFileGameDb_Loc As String)

            mdlMain.AppendToLog("GameDB", "Load", String.Format("Open DB: ""{0}"".", pFileGameDb_Loc))
            Try
                Dim sw As New Stopwatch
                sw.Start()

                If Not (Status = LoadStatus.StatusNotLoaded) Then
                    Unload()
                End If

                Dim tmpCurrentSerial As String = ""

                Using FileGameDb_Reader As New StreamReader(pFileGameDb_Loc, System.Text.Encoding.Default)
                    While Not FileGameDb_Reader.EndOfStream

                        Dim myLine As String = FileGameDb_Reader.ReadLine()

                        If myLine.Length >= 2 Then
                            If Not ((myLine.Substring(0, FileGameDb_CommentStyle1.Length) = FileGameDb_CommentStyle1) Or
                                    (myLine.Substring(0, 1) = vbTab)) Then

                                Dim mySplittedLine As System.String() = myLine.Split({FileGameDb_FieldSep})

                                If mySplittedLine.Length > 1 Then

                                    mySplittedLine(0) = mySplittedLine(0).Trim
                                    mySplittedLine(1) = mySplittedLine(1).Trim

                                    Select Case mySplittedLine(0)
                                        Case FileGameDb_FieldName1

                                            If Not (tmpCurrentSerial = mySplittedLine(1)) Then
                                                tmpCurrentSerial = mySplittedLine(1)
                                                If Not (Records.ContainsKey(tmpCurrentSerial)) Then
                                                    Dim myCurrentRecord As New GameInfo With {.Serial = tmpCurrentSerial, .Name = "", .Region = "", .Compat = ""}
                                                    Records.Add(tmpCurrentSerial, myCurrentRecord)
                                                End If
                                            End If
                                        Case FileGameDb_FieldName2
                                            If Records.ContainsKey(tmpCurrentSerial) Then
                                                Records(tmpCurrentSerial).Name = mySplittedLine(1)
                                            End If
                                        Case FileGameDb_FieldName3
                                            If Records.ContainsKey(tmpCurrentSerial) Then
                                                Records(tmpCurrentSerial).Region = mySplittedLine(1)
                                            End If
                                        Case FileGameDb_FieldName4
                                            If Records.ContainsKey(tmpCurrentSerial) Then
                                                Records(tmpCurrentSerial).Compat = mySplittedLine(1).Substring(0, 1)
                                            End If
                                    End Select

                                End If
                            End If
                        End If
                    End While
                    FileGameDb_Reader.Close()
                End Using
                LoadTime = sw.ElapsedTicks
                If Records.Count = 0 Then
                    mdlMain.AppendToLog("GameDB", "Load", "No records found.", LoadTime)
                    Status = LoadStatus.StatusEmpty
                Else
                    mdlMain.AppendToLog("GameDB", "Load", String.Format("Loaded {0:N0} records.", Records.Count), LoadTime)
                    Status = LoadStatus.StatusLoadedOK
                End If

            Catch ex As Exception
                mdlMain.AppendToLog("GameDB", "Load", String.Concat("Some kinda GameDB loading failure. ", ex.Message))
                Records.Clear()
                Status = LoadStatus.StatusError
            End Try
        End Sub

        Public Sub Unload()
            Records.Clear()
            Status = LoadStatus.StatusNotLoaded
            LoadTime = 0
        End Sub

        Public Function RecordExtract(ByVal pSerial As System.String) As GameInfo
            pSerial = pSerial.ToUpper

            Dim myGameDb_RecordExtract As New GameInfo With {.Serial = pSerial, .Name = "", .Region = "", .Compat = "0"}


            If Status = LoadStatus.StatusEmpty Or Status = LoadStatus.StatusLoadedOK Then
                Select Case pSerial
                    'Case "SCREENSHOTS"
                    '    myGameDb_RecordExtract.Serial = "Screenshots"
                    '    myGameDb_RecordExtract.Name = "(Screenshots)"
                    '    myGameDb_RecordExtract.Region = "unk"
                    '    myGameDb_RecordExtract.Compat = "0"
                    'Case "GSDX"
                    '    myGameDb_RecordExtract.Serial = "GSdX"
                    '    myGameDb_RecordExtract.Name = "(GSdX screenshots)"
                    '    myGameDb_RecordExtract.Region = "unk"
                    '    myGameDb_RecordExtract.Compat = "0"
                    Case "BIOS"
                        myGameDb_RecordExtract.Serial = "BIOS"
                        myGameDb_RecordExtract.Name = "(PS2 BIOS)"
                        myGameDb_RecordExtract.Region = "unk"
                        myGameDb_RecordExtract.Compat = "5"
                    Case Else

                        If Not (Records.TryGetValue(pSerial, myGameDb_RecordExtract)) Then
                            myGameDb_RecordExtract = New GameInfo With {.Serial = pSerial,
                                                                        .Name = "(Not found in GameDB)",
                                                                        .Region = "unk",
                                                                        .Compat = "0"}
                        End If
                End Select
                'mdlMain.WriteToConsole("GameDB", "RecordExtract", System.String.Format("from serial ""{0}"" > ""{1}"".", pSerial, myGameDb_RecordExtract.Name))
            ElseIf Status = LoadStatus.StatusNotLoaded Then
                myGameDb_RecordExtract.Serial = pSerial
                myGameDb_RecordExtract.Name = "(GameDB not loaded)"
                myGameDb_RecordExtract.Region = ""
                myGameDb_RecordExtract.Compat = "0"
                mdlMain.AppendToLog("GameDB", "RecordExtract", "Failed, GameDB is not loaded.")
            ElseIf Status = LoadStatus.StatusError Then
                myGameDb_RecordExtract.Serial = pSerial
                myGameDb_RecordExtract.Name = "(GameDB error)"
                myGameDb_RecordExtract.Region = ""
                myGameDb_RecordExtract.Compat = "0"
                mdlMain.AppendToLog("GameDB", "RecordExtract", "Failed, GameDB is not loaded because an error occurred.")
            Else
                mdlMain.AppendToLog("GameDB", "RecordExtract", "Failed, Status is set to " & Status.ToString)
            End If
            Return myGameDb_RecordExtract
        End Function

        Public Function RecordExtract(ByVal pSerial As List(Of System.String),
                                      ByRef pExtractedGameDb As Dictionary(Of System.String, GameInfo)
                                      ) As mdlMain.LoadStatus

            If Status = LoadStatus.StatusLoadedOK Or Status = LoadStatus.StatusEmpty Then

                pExtractedGameDb.Clear()

                For Each tmpSerial As System.String In pSerial

                    'tmpSerial = tmpSerial.ToUpper

                    'Dim tmpRecordExtract As New GameInfo With {.Serial = tmpSerial, .Name = "(Not found in GameDB)", .Region = "unk", .Compat = "0"}

                    'Select Case tmpSerial
                    '    Case "BIOS"
                    '        tmpRecordExtract.Serial = "BIOS"
                    '        tmpRecordExtract.Name = "(PS2 BIOS)"
                    '        tmpRecordExtract.Region = "unk"
                    '        tmpRecordExtract.Compat = "5"
                    '    Case Else
                    '        If Not (Records.TryGetValue(tmpSerial, tmpRecordExtract)) Then
                    '            With tmpRecordExtract
                    '                .Serial = tmpSerial
                    '                .Name = "(Not found in GameDB)"
                    '                .Region = "unk"
                    '                .Compat = "0"
                    '            End With
                    '        End If
                    'End Select

                    pExtractedGameDb.Add(RecordExtract(tmpSerial).Serial, RecordExtract(tmpSerial))

                Next

                If pExtractedGameDb.Count > 0 Then
                    Return LoadStatus.StatusLoadedOK
                Else
                    Return LoadStatus.StatusEmpty
                End If

                mdlMain.AppendToLog("GameDB", "RecordExtract", "From multiple serials.")
            ElseIf Status = LoadStatus.StatusNotLoaded Then
                Return LoadStatus.StatusNotLoaded
                mdlMain.AppendToLog("GameDB", "RecordExtract", "Failed, GameDB was not loaded.")
            ElseIf Status = LoadStatus.StatusError Then
                Return LoadStatus.StatusNotLoaded
                mdlMain.AppendToLog("GameDB", "RecordExtract", "Failed, GameDB was not loaded because an error occurred.")
            Else
                Return LoadStatus.StatusError
                mdlMain.AppendToLog("GameDB", "RecordExtract", "Failed, Status is set to " & Status.ToString)
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
        Public Function Search(ByRef pSearchResult As List(Of String),
                               ByVal pSerial As String,
                               ByVal pGameTitle As String,
                               ByVal pGameRegion As String,
                               ByVal pGameCompat As String,
                               ByVal pSearchType As Byte) As mdlMain.LoadStatus

            Dim sw As New Stopwatch
            sw.Start()

            pSearchResult.Clear()
            Dim myRecords As IEnumerable(Of KeyValuePair(Of String, GameInfo)) = Nothing
            'And
            If pSearchType = 0 Then
                myRecords = From tmpGameInfo As KeyValuePair(Of String, GameInfo) In Records
                            Where (tmpGameInfo.Key.ToUpper.Contains(pSerial) And
                                   tmpGameInfo.Value.Name.ToUpper.Contains(pGameTitle.ToUpper) And
                                   tmpGameInfo.Value.Region.ToUpper.Contains(pGameRegion.ToUpper) And
                                   tmpGameInfo.Value.Compat.Contains(pGameCompat)
                                   )
                            Select tmpGameInfo

                'Or
            ElseIf pSearchType = 1 Then
                myRecords = From tmpGameInfo As KeyValuePair(Of String, GameInfo) In Records
                            Where ((Not (pSerial.Length = 0) And tmpGameInfo.Key.ToUpper.Contains(pSerial)) Or
                                   (Not (pGameTitle.Length = 0) And tmpGameInfo.Value.Name.ToUpper.Contains(pGameTitle.ToUpper)) Or
                                   (Not (pGameRegion.Length = 0) And tmpGameInfo.Value.Region.ToUpper.Contains(pGameRegion.ToUpper)) Or
                                   (Not (pGameCompat.Length = 0) And tmpGameInfo.Value.Compat.Contains(pGameCompat))
                                   )
                            Select tmpGameInfo
            End If

            If (myRecords IsNot Nothing) Then
                For Each tmpGame In myRecords
                    pSearchResult.Add(tmpGame.Key)
                Next
                sw.Stop()
                mdlMain.AppendToLog("GameDB", "Search", String.Format("Found {0:N0} records.", pSearchResult.Count), sw.ElapsedTicks)
                Return LoadStatus.StatusLoadedOK
            Else
                sw.Stop()
                mdlMain.AppendToLog("GameDB", "Search", String.Format("No records found.", pSearchResult.Count), sw.ElapsedTicks)
                Return LoadStatus.StatusEmpty
            End If
        End Function

        ''' <summary>Export the gamedb to a text file (it can be imported in Excel and Access).</summary>
        ''' <param name="pGameDbExport_Loc">Path and file name of the saved file.</param>
        ''' <param name="pSep">Separator character to be used in the exported file.</param>
        Public Sub ExporTxt(ByVal pGameDbExport_Loc As String, ByVal pSep As String)
            GameDB.ExportTxt(pGameDbExport_Loc, pSep, Records)
        End Sub

        ''' <summary>Export the gamedb to a text file (it can be imported in Excel and Access). Shared method.</summary>
        ''' <param name="pGameDbExport_Loc">Path and file name of the saved file.</param>
        ''' <param name="pSep">Separator character to be used in the exported file.</param>
        ''' <param name="pRecords">Records list that will be saved in the file.</param>
        Public Shared Sub ExportTxt(ByVal pGameDbExport_Loc As String,
                                    ByVal pSep As String,
                                    ByVal pRecords As Dictionary(Of String, GameInfo))

            If pRecords.Count > 0 Then
                Using FileGameDb_Tab_Writer As New StreamWriter(pGameDbExport_Loc, False)
                    'Headers
                    FileGameDb_Tab_Writer.WriteLine(String.Concat("Serial", pSep, "Name", pSep, "Region", pSep, "Compat"))

                    For Each myTmpGame As KeyValuePair(Of String, GameInfo) In pRecords

                        FileGameDb_Tab_Writer.WriteLine(String.Concat(myTmpGame.Key, pSep,
                                                                      myTmpGame.Value.Name, pSep,
                                                                      myTmpGame.Value.Region, pSep,
                                                                      myTmpGame.Value.Compat))
                    Next
                    FileGameDb_Tab_Writer.Close()
                End Using
            End If
        End Sub

    End Class

End Module
