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
Module mdlGameDb

    'Constants
    Const FileGameDb_FieldSep As System.Char = "="          'Field separator in the database
    Const FileGameDb_CommentStyle1 As System.String = "--"  'Visual C++ comment style 1 (usually the start of the line)
    Const FileGameDb_CommentStyle2 As System.String = "//"  'Visual C++ comment style 2 (usually in the line)
    Const FileGameDb_CommentStyle3 As System.Char = ";"     'Visual C++ comment style 3 (not used yet)

    Const FileGameDb_FieldName1 As System.String = "Serial" 'Database first field name, also the index
    Const FileGameDb_FieldName2 As System.String = "Name"   'Database second field name
    Const FileGameDb_FieldName3 As System.String = "Region" 'Database third field name
    Const FileGameDb_FieldName4 As System.String = "Compat" 'Database fourth field name

    'Record
    Public Structure rGameDb                'Type definition of a record in GameIndex.dbf, only the info needed.
        Friend Serial As System.String      'Executable code of the game, normally in the (4 letter)-(5 digits). There are exceptions, though (I'm looking at you GTA III)
        Friend Name As System.String        'Currently the longest one is 150 char or so...
        Friend Region As System.String      'Game Region, nuff said
        Friend Compat As System.String      'Compatibility status, it should be a byte, but CByte causes overhead and exceptions
        Friend RStatus As rGameDb_RStatus   'The record status see below for infos
        'Friend GameIndexSS_Ref As System.Int32 'Position in GameIndex_SS, "-1" when not used
    End Structure

    Public Enum rGameDb_RStatus As System.Byte
        '            bin     description
        RStatus0    '(0000)
        RStatus1    '(0001)                          serial
        RStatus2    '(0010)                  name
        RStatus3    '(0011)                  name    serial
        RStatus4    '(0100)          region
        RStatus5    '(0101)          region          serial
        RStatus6    '(0110)          region  name
        RStatus7    '(0111)          region  name    serial
        RStatus8    '(1000)  compat
        RStatus9    '(1001)  compat                  serial
        RStatus10   '(1010)  compat          name
        RStatus11   '(1011)  compat          name    serial
        RStatus12   '(1100)  compat  region
        RStatus13   '(1101)  compat  region          serial
        RStatus14   '(1110)  compat  region  name
        RStatus15   '(1111)  compat  region  name    serial
    End Enum

    Public GameDb() As mdlGameDb.rGameDb    'The array that store the game infos read from the file. Size is variable to conserve memory, use "Redim" to set the start size and then "Redim Preserve" to resize
    Public GameDb_ArrayStatus As mdlMain.ArrayStatus = mdlMain.ArrayStatus.ArrayNotLoaded
    Public GameDb_LoadTime As System.TimeSpan
    Public Const GameDb_ReDimFactor As System.Int32 = 4096  'Redim instruction causes a lot of overhead, the factor is the step at which the array is resized during loading.

    Public Function GameDb_Load3(ByVal pFileGameDb_Loc As System.String, _
                                 ByRef pGameDb() As mdlGameDb.rGameDb
                                 ) As mdlMain.ArrayStatus
        'Creates the array from the converted GameDB. Return Value: array status
        '   ByVal   pFileGameDb_Loc             Path and file name of input database (converted),
        '   ByRef   pGameDb                     The dinamic array of the GameDB


        mdlMain.WriteToConsole("GameDB", "GameDb_Load3", System.String.Format("Opening database file from location ""{0}"".", pFileGameDb_Loc))
        Try
            Dim GameDb_Pos As System.Int32 = 0
            Dim startTime As System.DateTime = Now

            mdlGameDb.GameDb_Unload(pGameDb, GameDb_ReDimFactor)   'The array is cleared/initialized, position to 0
            Using FileGameDb_Reader As New System.IO.StreamReader(pFileGameDb_Loc, System.Text.Encoding.Default)

                While Not FileGameDb_Reader.EndOfStream
                    Dim myLine As System.String = FileGameDb_Reader.ReadLine()
                    If myLine.Length >= 2 Then
                        'If Not ((myLine.Substring(0, 2) = FileGameDb_CommentStyle1) Or (myLine.Substring(0, 2) = FileGameDb_CommentStyle2) Or (myLine.Substring(0, 2) = FileGameDb_CommentStyle3.ToString) Or (myLine.Substring(0, 1) = Microsoft.VisualBasic.vbTab)) Then
                        If Not ((myLine.Substring(0, FileGameDb_CommentStyle1.Length) = FileGameDb_CommentStyle1) Or _
                                (myLine.Substring(0, 1) = vbTab)) Then
                            'Dim mySplittedLine As System.String() = myLine.Split({FileGameDb_FieldSep.ToString, FileGameDb_CommentStyle2}, StringSplitOptions.None)
                            Dim mySplittedLine As System.String() = myLine.Split({FileGameDb_FieldSep})
                            If mySplittedLine.Length > 1 Then
                                mySplittedLine(0) = mySplittedLine(0).Trim
                                mySplittedLine(1) = mySplittedLine(1).Trim
                                Select Case mySplittedLine(0)
                                    Case FileGameDb_FieldName1
                                        If Not (pGameDb(GameDb_Pos).Serial Like mySplittedLine(1) Or pGameDb(GameDb_Pos).Serial Like "") Then
                                            GameDb_Pos += 1
                                            If (pGameDb.GetUpperBound(0) - GameDb_Pos) <= 2 Then   'Resize of the array. But not too often
                                                ReDim Preserve pGameDb(pGameDb.Length + GameDb_ReDimFactor)
                                                mdlMain.WriteToConsole("GameDB", "GameDB_Load3", System.String.Format("Array resized to {0} records.", pGameDb.GetUpperBound(0)))
                                            End If
                                        End If
                                        With pGameDb(GameDb_Pos)   'Array initialization, to avoid potential exceptions (The value are set here because the GameDB is loaded only one time, but is read often later and I don't want to spam isNothing checks everywhere).
                                            .Serial = mySplittedLine(1)
                                            .RStatus = rGameDb_RStatus.RStatus1
                                            .Name = ""
                                            .Region = ""
                                            .Compat = ""
                                            '.GameIndexSS_Ref = -1
                                        End With
                                    Case FileGameDb_FieldName2
                                        With pGameDb(GameDb_Pos)
                                            .Name = mySplittedLine(1)
                                            .RStatus = pGameDb(GameDb_Pos).RStatus + rGameDb_RStatus.RStatus2
                                        End With
                                    Case FileGameDb_FieldName3
                                        With pGameDb(GameDb_Pos)
                                            .Region = mySplittedLine(1)
                                            .RStatus = pGameDb(GameDb_Pos).RStatus + rGameDb_RStatus.RStatus4
                                        End With
                                    Case FileGameDb_FieldName4
                                        With pGameDb(GameDb_Pos)
                                            .Compat = mySplittedLine(1).Substring(0, 1)
                                            .RStatus = pGameDb(GameDb_Pos).RStatus + rGameDb_RStatus.RStatus8
                                        End With
                                End Select
                            End If
                        End If
                    End If
                End While
                FileGameDb_Reader.Close()
            End Using
            ReDim Preserve pGameDb(0 To GameDb_Pos)
            GameDb_LoadTime = Now.Subtract(startTime)
            If GameDb_Pos = 0 And pGameDb(GameDb_Pos).Serial = "" Then
                mdlMain.WriteToConsole("GameDB", "GameDB_Load3", System.String.Format("Complete. Loaded 0 records in {0:#,##0}ms. The array is empty", GameDb_LoadTime.TotalMilliseconds))
                GameDb_Load3 = ArrayStatus.ArrayEmpty
            Else
                mdlMain.WriteToConsole("GameDB", "GameDB_Load3", System.String.Format("Complete. Loaded {0:#,##0} records in {1:#,##0}ms.", pGameDb.GetLength(0), GameDb_LoadTime.TotalMilliseconds))
                GameDb_Load3 = ArrayStatus.ArrayLoadedOK
            End If

        Catch ex As Exception
            mdlMain.WriteToConsole("GameDB", "GameDB_Load3", System.String.Concat("Some kinda failure during GameDB loading. ", ex.Message))
            mdlGameDb.GameDb_Unload(pGameDb)
            GameDb_Load3 = ArrayStatus.ErrorOccurred
        End Try
    End Function

    Public Function GameDb_Unload(ByRef pGameDb() As mdlGameDb.rGameDb, _
                                  Optional ByVal pRedimFactor As System.Int32 = -1 _
                                  ) As mdlMain.ArrayStatus
        'Return Value: array status
        '   ByRef   pGameDb()               The dinamic array of the GameDB
        '   ByRef   pRedimFactor            Specifies if the array will be used after being cleared

        ReDim pGameDb(pRedimFactor)
        mdlMain.WriteToConsole("GameDB", "GameDB_Unload", System.String.Format("Array prepared with {0} empty records.", pRedimFactor))
        Return ArrayStatus.ArrayEmpty
    End Function

    Public Function GameDb_RecordExtract(ByVal pRef As System.Int32, _
                                         ByVal pGameDb() As mdlGameDb.rGameDb, _
                                         Optional ByRef pArrayStatus As mdlMain.ArrayStatus = ArrayStatus.ArrayLoadedOK
                                         ) As mdlGameDb.rGameDb


        With GameDb_RecordExtract
            .Serial = ""
            .Name = ""
            .Region = ""
            .RStatus = rGameDb_RStatus.RStatus1
            .Compat = ""
        End With

        If pRef >= pGameDb.GetLowerBound(0) And pRef <= pGameDb.GetUpperBound(0) Then
            GameDb_RecordExtract = pGameDb(pRef)
        ElseIf pRef = -1 Then
            With GameDb_RecordExtract
                .Serial = "BIOS"
                .Name = "(PS2 BIOS)"
                .Region = "unk"
                .RStatus = rGameDb_RStatus.RStatus15
                .Compat = "5"
            End With
        ElseIf pRef = -2 Then
            With GameDb_RecordExtract
                .Serial = "(Unknown)"
                .Name = "(Unknown - Not in GameDb)"
                .Region = "unk"
                .RStatus = rGameDb_RStatus.RStatus1
                .Compat = "0"
            End With
        End If

        mdlMain.WriteToConsole("GameDB", "GameDB_RecordExtract", System.String.Format("Requested record extraction from index reference ""{0}"".", pRef))
    End Function

    Public Function GameDb_RecordExtract(ByVal pSerial As System.String, _
                                         ByVal pGameDb() As mdlGameDb.rGameDb, _
                                         Optional ByRef pArrayStatus As mdlMain.ArrayStatus = ArrayStatus.ArrayLoadedOK
                                         ) As mdlGameDb.rGameDb


        With GameDb_RecordExtract
            .Serial = ""
            .Name = ""
            .Region = ""
            .RStatus = rGameDb_RStatus.RStatus1
            .Compat = ""
        End With
        Dim pRef As System.Int32 = mdlGameDb.GameDb_RefExtract(pSerial, pGameDb)

        If pRef >= pGameDb.GetLowerBound(0) And pRef <= pGameDb.GetUpperBound(0) Then
            GameDb_RecordExtract = pGameDb(pRef)
        ElseIf pRef = -1 Then
            With GameDb_RecordExtract
                .Serial = "BIOS"
                .Name = "(PS2 BIOS)"
                .Region = "unk"
                .RStatus = rGameDb_RStatus.RStatus15
                .Compat = "5"
            End With
        ElseIf pRef = -2 Then
            With GameDb_RecordExtract
                .Serial = "(Unknown)"
                .Name = "(Unknown - Not in GameDb)"
                .Region = "unk"
                .RStatus = rGameDb_RStatus.RStatus1
                .Compat = "0"
            End With
        End If

        mdlMain.WriteToConsole("GameDB", "GameDB_RecordExtract", System.String.Format("Requested record extraction from serial ""{0}""", pSerial))
    End Function


    Public Function GameDb_RefExtract(ByVal pSerial As System.String, _
                                      ByVal pGameDb() As mdlGameDb.rGameDb, _
                                      Optional ByRef pArrayStatus As mdlMain.ArrayStatus = ArrayStatus.ArrayLoadedOK
                                      ) As System.Int32
        'Search the array for a serial only, return the first value (a serial should be unique). Return Value: the record o the result
        '   ByVal   pSerial                     Serial to search
        '   Byval   paGameDb                    The dinamic array of the GameDB to search in


        pSerial.Trim().ToUpper()
        GameDb_RefExtract = -2
        If pSerial Like "BIOS" Then

            GameDb_RefExtract = -1

        ElseIf (pGameDb.GetLength(0) - 1) >= 0 Then

            For GameDb_Pos As System.Int32 = (pGameDb.GetLength(0) - 1) To 1 Step -1
                If pGameDb(GameDb_Pos).Serial Like pSerial Then
                    GameDb_RefExtract = GameDb_Pos
                    Exit For
                End If
            Next GameDb_Pos
        End If
        mdlMain.WriteToConsole("GameDB", "GameDB_RefExtract", System.String.Format("Requested reference extraction for serial ""{0}""", pSerial))
    End Function

    Public Function GameDb_RefExtract(ByVal pRefs() As System.Int32, _
                                      ByRef pExtractGameDb() As mdlGameDb.rGameDb, _
                                      ByVal pGameDb() As mdlGameDb.rGameDb, _
                                      Optional ByRef pArrayStatus As mdlMain.ArrayStatus = ArrayStatus.ArrayLoadedOK
                                      ) As mdlMain.ArrayStatus
        'Creates an extracted copy of GameDb records using an integer array as reference.

        ReDim pExtractGameDb(pRefs.GetLength(0) - 1)
        Dim ExtractGameDb_Pos As System.Int32 = 0

        For Each tmpPos As System.Int32 In pRefs
            If tmpPos >= pGameDb.GetLowerBound(0) And tmpPos <= pGameDb.GetUpperBound(0) Then
                pExtractGameDb(ExtractGameDb_Pos) = pGameDb(tmpPos)
                ExtractGameDb_Pos += 1
            End If
        Next

        ReDim Preserve pExtractGameDb(ExtractGameDb_Pos - 1)

        If ExtractGameDb_Pos > 0 Then
            GameDb_RefExtract = ArrayStatus.ArrayLoadedOK
        Else
            GameDb_RefExtract = ArrayStatus.ArrayEmpty
        End If
        mdlMain.WriteToConsole("GameDB", "GameDB_RefExtract", System.String.Format("Requested reference extraction for multiple records"))
    End Function

    Public Function GameDb_Search(ByVal pGameDb() As mdlGameDb.rGameDb, _
                                  ByRef pGameDbSearch() As System.Int32, _
                                  ByVal pSerial As System.String, ByVal pSearchBySerial As System.Boolean, _
                                  ByVal pGameTitle As System.String, ByVal pSearchByGameTitle As System.Boolean, _
                                  ByRef pGameRegion As System.String, ByVal pSearchByGameRegion As System.Boolean, _
                                  ByRef pGameCompat As System.String, ByVal pSearchByGameCompat As System.Boolean, _
                                  ByRef pSearchType As System.Byte) As mdlMain.ArrayStatus
        'Returns an array of integers which are the position of the records found in the GameDb. Return value: lenght of the integer array.
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

        Dim GameDbSearch_Pos As System.Int32 = -1
        ReDim pGameDbSearch(pGameDb.GetLength(0) - 1)

        For GameDb_Pos As System.Int32 = 0 To (pGameDb.GetLength(0) - 1)
            'Resize not needed as it is resized to the GameDb_Len

            If pSearchBySerial Then
                If pGameDb(GameDb_Pos).Serial.ToUpper.Contains(pSerial.ToUpper) Then
                    SerialFound = True
                End If
            End If

            If pSearchByGameTitle Then
                If pGameDb(GameDb_Pos).Name.ToUpper.Contains(pGameTitle.ToUpper) Then
                    GameTitleFound = True
                End If
            End If

            If pSearchByGameRegion Then
                If pGameDb(GameDb_Pos).Region.ToUpper.Contains(pGameRegion.ToUpper) Then
                    GameRegionFound = True
                End If
            End If

            If pSearchByGameCompat Then
                If pGameDb(GameDb_Pos).Compat = pGameCompat Then
                    GameCompatFound = True
                End If
            End If

            If pSearchType = 0 Then
                If (SerialFound Or Not (pSearchBySerial)) And _
                   (GameTitleFound Or Not (pSearchByGameTitle)) And _
                   (GameRegionFound Or Not (pSearchByGameRegion)) And _
                   (GameCompatFound Or Not (pSearchByGameCompat)) Then
                    GameDbSearch_Pos += 1
                    pGameDbSearch(GameDbSearch_Pos) = GameDb_Pos
                End If
            ElseIf pSearchType = 1 Then
                If SerialFound Or GameTitleFound Or GameRegionFound Or GameCompatFound Then
                    GameDbSearch_Pos += 1
                    pGameDbSearch(GameDbSearch_Pos) = GameDb_Pos
                End If
            End If
            SerialFound = False
            GameTitleFound = False
            GameRegionFound = False
            GameCompatFound = False

        Next
        ReDim Preserve pGameDbSearch(GameDbSearch_Pos)
        If GameDbSearch_Pos > -1 Then
            GameDb_Search = ArrayStatus.ArrayLoadedOK
        Else
            GameDb_Search = ArrayStatus.ArrayEmpty

        End If
    End Function

    Public Sub GameDb_ExportTxt(ByVal pGameDbExport_Loc As System.String, _
                                       ByVal pSepStyle As System.String, _
                                       ByVal pGameDb() As mdlGameDb.rGameDb)
        'Export the array to a text file (you could import in Excel and Access)
        '   ByVal   pFileGameDb_Tab_Loc         Path and file name of the saved file
        '   ByVal   pSepStyle                   Separator character to be use in the export
        '   ByRef   pGameDb                     The dinamic array of the GameDB to search in

        If pGameDb.GetLength(0) > 0 Then
            Using FileGameDb_Tab_Writer As New System.IO.StreamWriter(pGameDbExport_Loc, False)
                FileGameDb_Tab_Writer.WriteLine(System.String.Concat("#", pSepStyle, "Serial", pSepStyle, "Name", pSepStyle, "Region", pSepStyle, "Compat", pSepStyle, "Record status"))
                For GameDb_Pos As System.Int32 = 0 To (pGameDb.GetUpperBound(0))
                    FileGameDb_Tab_Writer.WriteLine(System.String.Concat(GameDb_Pos.ToString, pSepStyle, _
                                                                         pGameDb(GameDb_Pos).Serial, pSepStyle, _
                                                                         pGameDb(GameDb_Pos).Name, pSepStyle, _
                                                                         pGameDb(GameDb_Pos).Region, pSepStyle, _
                                                                         pGameDb(GameDb_Pos).Compat, pSepStyle, _
                                                                         pGameDb(GameDb_Pos).RStatus.ToString))
                Next GameDb_Pos
                FileGameDb_Tab_Writer.Close()
            End Using
        End If
    End Sub

End Module
