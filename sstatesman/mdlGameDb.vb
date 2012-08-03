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
        Public Property Serial As String      'Executable code of the game, normally in the (4 letter)-(5 digits). There are exceptions, though (I'm looking at you GTA III)
        Public Property Name As String        'Currently the longest one is 150 char or so...
        Public Property Region As String      'Game Region, nuff said
        Public Property Compat As String      'Compatibility status, it should be a byte, but CByte causes overhead and exceptions

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
                Case "0" : Return pBGcolor  'Unknown
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

    Public PCSX2GameDb As New GameDB
    Public Class GameDB
        Public Property Records As New Dictionary(Of String, GameInfo)
        Public Property Status As mdlMain.LoadStatus = mdlMain.LoadStatus.StatusNotLoaded
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

        Public Sub Load(ByVal pFileGameDb_Loc As String)
            'Loads the GameDB from the given file. Return Value: status
            '   ByVal   pFileGameDb_Loc             Path and file name of input database.

            mdlMain.AppendToLog("GameDB", "Load", String.Format("Open DB: ""{0}"".", pFileGameDb_Loc))
            Try
                Dim sw As New Stopwatch
                sw.Start()

                Unload()

                Dim myCurrentSerial As String = ""

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

                                            If Not (myCurrentSerial = mySplittedLine(1)) Then
                                                myCurrentSerial = mySplittedLine(1)
                                                If Not (Records.ContainsKey(myCurrentSerial)) Then
                                                    Dim myCurrentRecord As New GameInfo With {.Serial = myCurrentSerial, .Name = "", .Region = "", .Compat = ""}
                                                    Records.Add(myCurrentSerial, myCurrentRecord)
                                                End If
                                            End If
                                        Case FileGameDb_FieldName2
                                            If Records.ContainsKey(myCurrentSerial) Then
                                                Records(myCurrentSerial).Name = mySplittedLine(1)
                                            End If
                                        Case FileGameDb_FieldName3
                                            If Records.ContainsKey(myCurrentSerial) Then
                                                Records(myCurrentSerial).Region = mySplittedLine(1)
                                            End If
                                        Case FileGameDb_FieldName4
                                            If Records.ContainsKey(myCurrentSerial) Then
                                                Records(myCurrentSerial).Compat = mySplittedLine(1).Substring(0, 1)
                                            End If
                                    End Select

                                End If
                            End If
                        End If
                    End While
                    FileGameDb_Reader.Close()
                End Using
                LoadTime = sw.ElapsedMilliseconds
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
                    Case "BIOS"
                        With myGameDb_RecordExtract
                            .Serial = "BIOS"
                            .Name = "(PS2 BIOS)"
                            .Region = "unk"
                            .Compat = "5"
                        End With
                    Case ""
                        With myGameDb_RecordExtract
                            .Serial = pSerial
                            .Name = ""
                            .Region = ""
                            .Compat = "0"
                        End With
                    Case Else

                        If Not (Records.TryGetValue(pSerial, myGameDb_RecordExtract)) Then
                            myGameDb_RecordExtract = New GameInfo
                            With myGameDb_RecordExtract
                                .Serial = pSerial
                                .Name = "(Not found in GameDB)"
                                .Region = "unk"
                                .Compat = "0"
                            End With
                        End If
                End Select
                'mdlMain.WriteToConsole("GameDB", "RecordExtract", System.String.Format("from serial ""{0}"" > ""{1}"".", pSerial, myGameDb_RecordExtract.Name))
            ElseIf Status = LoadStatus.StatusNotLoaded Then
                With myGameDb_RecordExtract
                    .Serial = pSerial
                    .Name = "(GameDB not loaded)"
                    .Region = ""
                    .Compat = "0"
                End With
                mdlMain.AppendToLog("GameDB", "RecordExtract", "Failed, GameDB is not loaded.")
            ElseIf Status = LoadStatus.StatusError Then
                With myGameDb_RecordExtract
                    .Serial = pSerial
                    .Name = "(GameDB error)"
                    .Region = ""
                    .Compat = "0"
                End With
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

                For Each myTmpSerial As System.String In pSerial

                    myTmpSerial = myTmpSerial.ToUpper

                    Dim myRecordExtract As New GameInfo With {.Serial = myTmpSerial, .Name = "(Not found in GameDB)", .Region = "unk", .Compat = "0"}

                    Select Case myTmpSerial
                        Case "BIOS"
                            With myRecordExtract
                                .Serial = "BIOS"
                                .Name = "(PS2 BIOS)"
                                .Region = "unk"
                                .Compat = "5"
                            End With
                        Case Else
                            If Not (Records.TryGetValue(myTmpSerial, myRecordExtract)) Then
                                With myRecordExtract
                                    .Serial = myTmpSerial
                                    .Name = "(Not found in GameDB)"
                                    .Region = "unk"
                                    .Compat = "0"
                                End With
                            End If
                    End Select
                    pExtractedGameDb.Add(myRecordExtract.Serial, myRecordExtract)

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

        Public Function Search(ByRef pGameDbSearch As List(Of String),
                               ByVal pSerial As String, ByVal pSearchBySerial As Boolean,
                               ByVal pGameTitle As String, ByVal pSearchByGameTitle As Boolean,
                               ByVal pGameRegion As String, ByVal pSearchByGameRegion As Boolean,
                               ByVal pGameCompat As String, ByVal pSearchByGameCompat As Boolean,
                               ByVal pSearchType As Byte) As mdlMain.LoadStatus
            'Returns an array of integers which are the position of the records found in the GameDb. Return value: Length of the integer array.
            'ByRef  pGameDbSearch           The string array where the serials will be stored
            'ByVal  pSerial                 Serial to search
            'ByVal  pSearchBySerial         Determines if the search by serial will be performed
            'ByVal  pGameTitle              Game title to search
            'ByVal  pSearchByGameTitle      Determines if the search by game title will be performed
            'ByVal  pGameRegion             Game region to search
            'ByVal  pSearchByGameRegion     Determines if the search by game region will be performed
            'ByVal  pGameCompat             Game compat to search
            'ByVal  pSearchByGameCompat     Determines if the search by compat will be performed
            'ByVal  pSearchType             Determines if the search will use the "And" or "Or" criteria
            Dim SerialFound As System.Boolean = False
            Dim GameTitleFound As System.Boolean = False
            Dim GameRegionFound As System.Boolean = False
            Dim GameCompatFound As System.Boolean = False

            pGameDbSearch.Clear()

            For Each myTmpGame As KeyValuePair(Of System.String, GameInfo) In Records

                If pSearchBySerial Then
                    If myTmpGame.Key.ToUpper.Contains(pSerial.ToUpper) Then
                        SerialFound = True
                    End If
                End If

                If pSearchByGameTitle Then
                    If myTmpGame.Value.Name.ToUpper.Contains(pGameTitle.ToUpper) Then
                        GameTitleFound = True
                    End If
                End If

                If pSearchByGameRegion Then
                    If myTmpGame.Value.Region.ToUpper.Contains(pGameRegion.ToUpper) Then
                        GameRegionFound = True
                    End If
                End If

                If pSearchByGameCompat Then
                    If myTmpGame.Value.Compat = pGameCompat Then
                        GameCompatFound = True
                    End If
                End If

                If pSearchType = 0 Then
                    If (SerialFound Or Not (pSearchBySerial)) And
                       (GameTitleFound Or Not (pSearchByGameTitle)) And
                       (GameRegionFound Or Not (pSearchByGameRegion)) And
                       (GameCompatFound Or Not (pSearchByGameCompat)) Then
                        pGameDbSearch.Add(myTmpGame.Key)
                    End If
                ElseIf pSearchType = 1 Then
                    If SerialFound Or GameTitleFound Or GameRegionFound Or GameCompatFound Then
                        pGameDbSearch.Add(myTmpGame.Key)
                    End If
                End If
                SerialFound = False
                GameTitleFound = False
                GameRegionFound = False
                GameCompatFound = False

            Next
            If pGameDbSearch.Count > 0 Then
                Return LoadStatus.StatusLoadedOK
            Else
                Return LoadStatus.StatusEmpty
            End If
        End Function

        Public Sub ExporTxt(ByVal pGameDbExport_Loc As String, ByVal pSep As String)
            GameDB.ExportTxt(pGameDbExport_Loc, pSep, Records)
        End Sub

        Public Shared Sub ExportTxt(ByVal pGameDbExport_Loc As String,
                                    ByVal pSep As String,
                                    ByVal pGameDb As Dictionary(Of String, GameInfo))
            'Export the array to a text file (you could import in Excel and Access)
            '   ByVal   pGameDbExport_Loc           Path and file name of the saved file
            '   ByVal   pSepStyle                   Separator character to be use in the export
            '   ByRef   pGameDb                     The dinamic array of the GameDB to search in

            If pGameDb.Count > 0 Then
                Using FileGameDb_Tab_Writer As New StreamWriter(pGameDbExport_Loc, False)
                    FileGameDb_Tab_Writer.WriteLine(String.Concat("Serial", pSep, "Name", pSep, "Region", pSep, "Compat"))
                    For Each myTmpGame As KeyValuePair(Of String, GameInfo) In pGameDb

                        FileGameDb_Tab_Writer.WriteLine(String.Concat(myTmpGame.Key, pSep, myTmpGame.Value.Name, pSep,
                                                                      myTmpGame.Value.Region, pSep, myTmpGame.Value.Compat))
                    Next
                    FileGameDb_Tab_Writer.Close()
                End Using
            End If
        End Sub

    End Class

    'Public Sub GameDb_ExportTxt(ByVal pGameDbExport_Loc As System.String,
    '                            ByVal pSep As System.String,
    '                            ByVal pGameDb As Dictionary(Of System.String, GameInfo))
    '    'Export the array to a text file (you could import in Excel and Access)
    '    '   ByVal   pGameDbExport_Loc           Path and file name of the saved file
    '    '   ByVal   pSepStyle                   Separator character to be use in the export
    '    '   ByRef   pGameDb                     The dinamic array of the GameDB to search in

    '    If pGameDb.Count > 0 Then
    '        Using FileGameDb_Tab_Writer As New StreamWriter(pGameDbExport_Loc, False)
    '            FileGameDb_Tab_Writer.WriteLine(System.String.Concat("Serial", pSep, "Name", pSep, "Region", pSep, "Compat"))
    '            For Each myTmpGame As KeyValuePair(Of System.String, GameInfo) In pGameDb

    '                FileGameDb_Tab_Writer.WriteLine(System.String.Concat(myTmpGame.Key, pSep, myTmpGame.Value.Name, pSep,
    '                                                                     myTmpGame.Value.Region, pSep, myTmpGame.Value.Compat))
    '            Next
    '            FileGameDb_Tab_Writer.Close()
    '        End Using
    '    End If
    'End Sub

End Module
