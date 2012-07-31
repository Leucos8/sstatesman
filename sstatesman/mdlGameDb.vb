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
    Public Class GameTitle
        Public Property Serial As String      'Executable code of the game, normally in the (4 letter)-(5 digits). There are exceptions, though (I'm looking at you GTA III)
        Public Property Name As String        'Currently the longest one is 150 char or so...
        Public Property Region As String      'Game Region, nuff said
        Public Property Compat As String      'Compatibility status, it should be a byte, but CByte causes overhead and exceptions
    End Class

    'Constants
    Const FileGameDb_FieldSep As Char = "="c         'Field separator in the database
    Const FileGameDb_CommentStyle1 As String = "--"  'C++ comment style 1 (usually the start of the line)
    Const FileGameDb_CommentStyle2 As String = "//"  'C++ comment style 2 (usually in the line)
    Const FileGameDb_CommentStyle3 As Char = ";"c    'C++ comment style 3 (not used yet)

    Const FileGameDb_FieldName1 As String = "Serial" 'Database first field name, also the index
    Const FileGameDb_FieldName2 As String = "Name"   'Database second field name
    Const FileGameDb_FieldName3 As String = "Region" 'Database third field name
    Const FileGameDb_FieldName4 As String = "Compat" 'Database fourth field name

    Public GameDb As New Dictionary(Of String, GameTitle)
    Public GameDb_Status As mdlMain.LoadStatus = mdlMain.LoadStatus.StatusNotLoaded
    Public GameDb_LoadTime As Long

    Public Function GameDb_Load(ByVal pFileGameDb_Loc As String,
                                ByRef pGameDb As Dictionary(Of String, GameTitle)
                                ) As mdlMain.LoadStatus
        'Creates the array from the converted GameDB. Return Value: array status
        '   ByVal   pFileGameDb_Loc             Path and file name of input database (converted),
        '   ByRef   pGameDb                     The dinamic array of the GameDB


        mdlMain.AppendToLog("GameDB", "Load", String.Format("Open DB: ""{0}"".", pFileGameDb_Loc))
        Try
            Dim sw As New Stopwatch
            sw.Start()

            pGameDb.Clear()

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
                                            If Not (pGameDb.ContainsKey(myCurrentSerial)) Then
                                                Dim myCurrentRecord As New GameTitle With {.Serial = myCurrentSerial, .Name = "", .Region = "", .Compat = ""}
                                                pGameDb.Add(myCurrentSerial, myCurrentRecord)
                                            End If
                                        End If
                                    Case FileGameDb_FieldName2
                                        If pGameDb.ContainsKey(myCurrentSerial) Then
                                            pGameDb(myCurrentSerial).Name = mySplittedLine(1)
                                        End If
                                    Case FileGameDb_FieldName3
                                        If pGameDb.ContainsKey(myCurrentSerial) Then
                                            pGameDb(myCurrentSerial).Region = mySplittedLine(1)
                                        End If
                                    Case FileGameDb_FieldName4
                                        If pGameDb.ContainsKey(myCurrentSerial) Then
                                            pGameDb(myCurrentSerial).Compat = mySplittedLine(1).Substring(0, 1)
                                        End If
                                End Select

                            End If
                        End If
                    End If
                End While
                FileGameDb_Reader.Close()
            End Using
            GameDb_LoadTime = sw.ElapsedMilliseconds
            If pGameDb.Count = 0 Then
                mdlMain.AppendToLog("GameDB", "Load", "No records found.", GameDb_LoadTime)
                GameDb_Load = LoadStatus.StatusEmpty
            Else
                mdlMain.AppendToLog("GameDB", "Load", String.Format("Loaded {0:N0} records.", pGameDb.Count), GameDb_LoadTime)
                GameDb_Load = LoadStatus.StatusLoadedOK
            End If

        Catch ex As Exception
            mdlMain.AppendToLog("GameDB", "Load", String.Concat("Some kinda GameDB loading failure. ", ex.Message))
            pGameDb.Clear()
            GameDb_Load = LoadStatus.StatusError
        End Try
    End Function

    Public Function GameDb_RecordExtract(ByVal pSerial As System.String,
                                         ByVal pGameDb As Dictionary(Of System.String, GameTitle),
                                         ByVal pArrayStatus As mdlMain.LoadStatus
                                         ) As GameTitle
        pSerial = pSerial.ToUpper

        Dim myGameDb_RecordExtract As New GameTitle With {.Serial = pSerial, .Name = "", .Region = "", .Compat = "0"}


        If pArrayStatus = LoadStatus.StatusEmpty Or pArrayStatus = LoadStatus.StatusLoadedOK Then
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

                    If Not (pGameDb.TryGetValue(pSerial, myGameDb_RecordExtract)) Then
                        myGameDb_RecordExtract = New GameTitle
                        With myGameDb_RecordExtract
                            .Serial = pSerial
                            .Name = "(Not found in GameDB)"
                            .Region = "unk"
                            .Compat = "0"
                        End With
                    End If
            End Select
            'mdlMain.WriteToConsole("GameDB", "RecordExtract", System.String.Format("from serial ""{0}"" > ""{1}"".", pSerial, myGameDb_RecordExtract.Name))
        ElseIf pArrayStatus = LoadStatus.StatusNotLoaded Then
            With myGameDb_RecordExtract
                .Serial = pSerial
                .Name = "(GameDB not loaded)"
                .Region = ""
                .Compat = "0"
            End With
            mdlMain.AppendToLog("GameDB", "RecordExtract", "Failed, GameDB is not loaded.")
        ElseIf pArrayStatus = LoadStatus.StatusError Then
            With myGameDb_RecordExtract
                .Serial = pSerial
                .Name = "(GameDB error)"
                .Region = ""
                .Compat = "0"
            End With
            mdlMain.AppendToLog("GameDB", "RecordExtract", "Failed, GameDB is not loaded because an error occurred.")
        Else
            mdlMain.AppendToLog("GameDB", "RecordExtract", "Failed, something is wrong you shouldn't get this O.o")
        End If
        Return myGameDb_RecordExtract
    End Function

    Public Function GameDb_RecordExtract(ByVal pSerial As List(Of System.String),
                                         ByVal pGameDb As Dictionary(Of System.String, GameTitle),
                                         ByVal pArrayStatus As mdlMain.LoadStatus,
                                         ByRef pExtractedGameDb As Dictionary(Of System.String, GameTitle)
                                         ) As mdlMain.LoadStatus

        If pArrayStatus = LoadStatus.StatusLoadedOK Or pArrayStatus = LoadStatus.StatusEmpty Then

            pExtractedGameDb.Clear()

            For Each myTmpSerial As System.String In pSerial

                myTmpSerial = myTmpSerial.ToUpper

                Dim myRecordExtract As New GameTitle With {.Serial = myTmpSerial, .Name = "(Not found in GameDB)", .Region = "unk", .Compat = "0"}

                Select Case myTmpSerial
                    Case "BIOS"
                        With myRecordExtract
                            .Serial = "BIOS"
                            .Name = "(PS2 BIOS)"
                            .Region = "unk"
                            .Compat = "5"
                        End With
                    Case Else
                        If Not (pGameDb.TryGetValue(myTmpSerial, myRecordExtract)) Then
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
                GameDb_RecordExtract = LoadStatus.StatusLoadedOK
            Else
                GameDb_RecordExtract = LoadStatus.StatusEmpty
            End If

            mdlMain.AppendToLog("GameDB", "RecordExtract", "From multiple serials.")
        ElseIf pArrayStatus = LoadStatus.StatusNotLoaded Then
            GameDb_RecordExtract = LoadStatus.StatusNotLoaded
            mdlMain.AppendToLog("GameDB", "RecordExtract", "Failed, GameDB was not loaded.")
        ElseIf pArrayStatus = LoadStatus.StatusError Then
            GameDb_RecordExtract = LoadStatus.StatusNotLoaded
            mdlMain.AppendToLog("GameDB", "RecordExtract", "Failed, GameDB was not loaded because an error occurred.")
        Else
            GameDb_RecordExtract = LoadStatus.StatusError
            mdlMain.AppendToLog("GameDB", "RecordExtract", "Failed, something is wrong you shouldn't get this O.o")
        End If

    End Function

    Public Function GameDb_Search(ByVal pGameDb As Dictionary(Of System.String, GameTitle),
                                  ByRef pGameDbSearch As List(Of System.String),
                                  ByVal pSerial As System.String, ByVal pSearchBySerial As System.Boolean,
                                  ByVal pGameTitle As System.String, ByVal pSearchByGameTitle As System.Boolean,
                                  ByVal pGameRegion As System.String, ByVal pSearchByGameRegion As System.Boolean,
                                  ByVal pGameCompat As System.String, ByVal pSearchByGameCompat As System.Boolean,
                                  ByVal pSearchType As System.Byte) As mdlMain.LoadStatus
        'Returns an array of integers which are the position of the records found in the GameDb. Return value: Length of the integer array.
        'ByVal  pGameDb                 The GameDb to search in
        'ByRef  pGameDbSearch           The integer array where the references will be stored
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

        For Each myTmpGame As KeyValuePair(Of System.String, GameTitle) In pGameDb

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
                If (SerialFound Or Not (pSearchBySerial)) And _
                   (GameTitleFound Or Not (pSearchByGameTitle)) And _
                   (GameRegionFound Or Not (pSearchByGameRegion)) And _
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
            GameDb_Search = LoadStatus.StatusLoadedOK
        Else
            GameDb_Search = LoadStatus.StatusEmpty
        End If
    End Function

    Public Sub GameDb_ExportTxt(ByVal pGameDbExport_Loc As System.String,
                                ByVal pSep As System.String,
                                ByVal pGameDb As Dictionary(Of System.String, GameTitle))
        'Export the array to a text file (you could import in Excel and Access)
        '   ByVal   pGameDbExport_Loc           Path and file name of the saved file
        '   ByVal   pSepStyle                   Separator character to be use in the export
        '   ByRef   pGameDb                     The dinamic array of the GameDB to search in

        If pGameDb.Count > 0 Then
            Using FileGameDb_Tab_Writer As New StreamWriter(pGameDbExport_Loc, False)
                FileGameDb_Tab_Writer.WriteLine(System.String.Concat("Serial", pSep, "Name", pSep, "Region", pSep, "Compat"))
                For Each myTmpGame As KeyValuePair(Of System.String, GameTitle) In pGameDb

                    FileGameDb_Tab_Writer.WriteLine(System.String.Concat(myTmpGame.Key, pSep, myTmpGame.Value.Name, pSep,
                                                                         myTmpGame.Value.Region, pSep, myTmpGame.Value.Compat))
                Next
                FileGameDb_Tab_Writer.Close()
            End Using
        End If
    End Sub

End Module
