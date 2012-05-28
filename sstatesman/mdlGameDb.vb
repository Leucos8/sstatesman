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
    Const FileGameDb_FieldSep As System.String = "="          'Field separator in the database
    Const FileGameDb_CommentStyle1 As System.String = "--"  'Visual C++ comment style 1 (usually the start of the line)
    Const FileGameDb_CommentStyle2 As System.String = "//"  'Visual C++ comment style 2 (usually in the line)
    Const FileGameDb_CommentStyle3 As System.String = ";"     'Visual C++ comment style 3 (not used yet)

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
        Friend RStatus As System.Byte       'The record status see below for infos
    End Structure                           'int    bin     desc
    Const rGameDb_RStatus0 As System.Byte = 0       '(0000)
    Const rGameDb_RStatus1 As System.Byte = 1       '(0001)                          serial
    Const rGameDb_RStatus2 As System.Byte = 2       '(0010)                  name
    Const rGameDb_RStatus3 As System.Byte = 3       '(0011)                  name    serial
    Const rGameDb_RStatus4 As System.Byte = 4       '(0100)          region
    Const rGameDb_RStatus5 As System.Byte = 5       '(0101)          region          serial
    Const rGameDb_RStatus6 As System.Byte = 6       '(0110)          region  name
    Const rGameDb_RStatus7 As System.Byte = 7       '(0111)          region  name    serial
    Const rGameDb_RStatus8 As System.Byte = 8       '(1000)  compat
    Const rGameDb_RStatus9 As System.Byte = 9       '(1001)  compat                  serial
    Const rGameDb_RStatus10 As System.Byte = 10     '(1010)  compat          name
    Const rGameDb_RStatus11 As System.Byte = 11     '(1011)  compat          name    serial
    Const rGameDb_RStatus12 As System.Byte = 12     '(1100)  compat  region
    Const rGameDb_RStatus13 As System.Byte = 13     '(1101)  compat  region          serial
    Const rGameDb_RStatus14 As System.Byte = 14     '(1110)  compat  region  name
    Const rGameDb_RStatus15 As System.Byte = 15     '(1111)  compat  region  name    serial

    Public GameDb() As mdlGameDb.rGameDb    'The array that store the game infos read from the file. Size is variable to conserve memory, use "Redim" to set the start size and then "Redim Preserve" to resize
    Public GameDb_Pos As System.Int32 = 0   'Currently there are around 9000 games in the file, it should be safe to use an integer here.
    Public GameDb_Len As System.Int32 = 0   'Occupied record in the array
    Public Const GameDb_ReDimFactor As System.Int32 = 4096  'Redim instruction causes a lot of overhead, the factor is the step at which the array is resized during loading.

    Public Function GameDb_Load3(ByVal pFileGameDb_Loc As System.String, _
                                 ByRef pGameDb() As mdlGameDb.rGameDb, _
                                 ByRef pGameDb_Pos As System.Int32 _
                                 ) As System.Int32
        'Creates the array from the converted GameDB. Return Value: array status/lenght
        '   ByVal   pFileGameDb_Loc             Path and file name of input database (converted),
        '   ByRef   pGameDb                     The dinamic array of the GameDB
        '   ByRef   pGamedb_Pos                 Position index of the array
        Try
            mdlGameDb.GameDb_Unload(pGameDb, pGameDb_Pos, GameDb_ReDimFactor)   'The array is cleared/initialized, position to 0
            Using FileGameDb_Reader As New System.IO.StreamReader(pFileGameDb_Loc, System.Text.Encoding.Default)
                While Not FileGameDb_Reader.EndOfStream
                    Dim sTmp1 As System.String = FileGameDb_Reader.ReadLine()
                    If sTmp1.Length >= 2 Then
                        'If Not ((sTmp1.Substring(0, 2) = FileGameDb_CommentStyle1) Or _
                        '        (sTmp1.Substring(0, 2) = FileGameDb_CommentStyle2) Or _
                        '        (sTmp1.Substring(0, 2) = FileGameDb_CommentStyle3) Or _
                        '        (sTmp1.Substring(0, 1) = Microsoft.VisualBasic.vbTab)) Then
                        If Not ((sTmp1.Substring(0, FileGameDb_CommentStyle1.Length) = FileGameDb_CommentStyle1) Or _
                                (sTmp1.Substring(0, 1) = Microsoft.VisualBasic.vbTab)) Then
                            'Dim sTmp2 As System.String() = sTmp1.Split({FileGameDb_FieldSep, FileGameDb_CommentStyle2}, StringSplitOptions.None)
                            Dim sTmp2 As System.String() = sTmp1.Split({FileGameDb_FieldSep(0)})
                            If sTmp2.Length > 1 Then
                                sTmp2(0) = sTmp2(0).Trim
                                sTmp2(1) = sTmp2(1).Trim
                                Select Case sTmp2(0)
                                    Case FileGameDb_FieldName1
                                        If Not (pGameDb(pGameDb_Pos).Serial Like sTmp2(1) Or pGameDb(pGameDb_Pos).Serial Like "") Then
                                            pGameDb_Pos += 1
                                            If (pGameDb.Length - pGameDb_Pos) <= 2 Then   'Resize of the array. But not too often
                                                ReDim Preserve pGameDb(pGameDb.Length + GameDb_ReDimFactor)
                                            End If
                                        End If
                                        pGameDb(pGameDb_Pos).Serial = sTmp2(1)          'Array initialization, to avoid potential exceptions (The value are set here because the GameDB is loaded only one time, but is read often later and I don't want to spam isNothing checks everywhere).
                                        pGameDb(pGameDb_Pos).RStatus = rGameDb_RStatus1
                                        pGameDb(pGameDb_Pos).Name = ""
                                        pGameDb(pGameDb_Pos).Region = ""
                                        pGameDb(pGameDb_Pos).Compat = ""
                                    Case FileGameDb_FieldName2
                                        pGameDb(pGameDb_Pos).Name = sTmp2(1)
                                        pGameDb(pGameDb_Pos).RStatus = pGameDb(pGameDb_Pos).RStatus + rGameDb_RStatus2
                                    Case FileGameDb_FieldName3
                                        pGameDb(pGameDb_Pos).Region = sTmp2(1)
                                        pGameDb(pGameDb_Pos).RStatus = pGameDb(pGameDb_Pos).RStatus + rGameDb_RStatus4
                                    Case FileGameDb_FieldName4
                                        pGameDb(pGameDb_Pos).Compat = sTmp2(1).Substring(0, 1)
                                        pGameDb(pGameDb_Pos).RStatus = pGameDb(pGameDb_Pos).RStatus + rGameDb_RStatus8
                                End Select
                            End If
                        End If
                    End If
                End While
                FileGameDb_Reader.Close()
            End Using
            ReDim Preserve pGameDb(0 To pGameDb_Pos)
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show("Some kinda failure during GameDB loading. Please report to the developer." & vbCrLf & ex.Message, _
                                                 "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error)
            pGameDb_Pos = -1
        Finally
            GameDb_Load3 = pGameDb_Pos
        End Try
    End Function

    Public Function GameDb_Unload(ByRef pGameDb() As mdlGameDb.rGameDb, _
                                  ByRef pGameDb_Pos As System.Int32
                                  ) As System.Int32
        'Return Value: array status/lenght
        '   ByRef   pGameDb()               The dinamic array of the GameDB
        '   ByRef   pGamedb_Pos             Position index of the array

        ReDim pGameDb(-1)
        pGameDb_Pos = 0         'Array position index starts to 0
        Return -1
    End Function

    Public Function GameDb_Unload(ByRef pGameDb() As mdlGameDb.rGameDb, _
                                  ByRef pGameDb_Pos As System.Int32, _
                                  ByVal pRedimFactor As System.Int32 _
                                  ) As System.Int32
        'Return Value: array status/lenght
        '   ByRef   pGameDb()               The dinamic array of the GameDB
        '   ByRef   pGamedb_Pos             Position index of the array
        '   ByRef   pRedimFactor            Specifies if the array will be used after being cleared

        ReDim pGameDb(pRedimFactor)
        pGameDb_Pos = 0         'Array position index starts to 0
        Return -1
    End Function



    Public Function GameDb_ExtractBySerial(ByVal pSerial As System.String, _
                                           ByVal pGameDb() As mdlGameDb.rGameDb, _
                                           ByRef pGameDb_Pos As System.Int32, _
                                           ByVal pGameDb_Len As System.Int32 _
                                           ) As mdlGameDb.rGameDb
        'Search the array for a serial only, return the first value (a serial should be unique). Return Value: the record o the result
        '   ByVal   pSerial                     Serial to search
        '   Byval   paGameDb                    The dinamic array of the GameDB to search in
        '   ByRef   pGamedb_Pos                 Position index of the array
        '   ByVal   pGamedb_Len                 Lenght of the array
        With GameDb_ExtractBySerial
            .Serial = pSerial
            .Region = ""
            .RStatus = 1
            .Compat = ""
        End With

        pSerial.Trim()
        If pSerial Like "BIOS" Then
            GameDb_ExtractBySerial.Name = "(PS2 BIOS)"
            GameDb_ExtractBySerial.Region = ""
            GameDb_ExtractBySerial.Compat = "5"
        ElseIf pGameDb_Len >= 0 Then
            GameDb_ExtractBySerial.Name = "(unknown - no match in GameDB)"
            For pGameDb_Pos = pGameDb_Len To 1 Step -1
                If pGameDb(pGameDb_Pos).Serial Like pSerial Then
                    GameDb_ExtractBySerial = pGameDb(pGameDb_Pos)
                    Exit For
                End If
            Next pGameDb_Pos
        Else : GameDb_ExtractBySerial.Name = "GameDB is not loaded or is empty!"
        End If
    End Function

    Public Function GameDb_ExtractByRefs(ByVal pRefs() As System.Int32, _
                                         ByRef pExtractGameDb() As mdlGameDb.rGameDb, _
                                         ByRef pExtractGameDb_Pos As System.Int32, _
                                         ByVal pGameDb() As mdlGameDb.rGameDb, _
                                         ByRef pGameDb_Pos As System.Int32, _
                                         ByVal pGameDb_Len As System.Int32 _
                                         ) As System.Int32
        ReDim pExtractGameDb(pGameDb_Len)
        pExtractGameDb_Pos = 0
        For Each tmpPos As System.Int32 In pRefs
            pExtractGameDb(pExtractGameDb_Pos) = pGameDb(pGameDb_Pos)
            pExtractGameDb_Pos += 1
        Next
        pExtractGameDb_Pos -= 1
        ReDim Preserve pExtractGameDb(pExtractGameDb_Pos)
        GameDb_ExtractByRefs = pExtractGameDb_Pos
    End Function

    Public Function GameDb_Search(ByVal pGameDb() As mdlGameDb.rGameDb, ByVal pGameDb_Pos As System.Int32, ByVal pGameDb_Len As System.Int32, _
                             ByRef pGameDbSearch() As System.Int32, ByRef pGameDbSearch_Pos As System.Int32, _
                             ByVal pSerial As System.String, ByVal pSearchBySerial As System.Boolean, _
                             ByVal pGameTitle As System.String, ByVal pSearchByGameTitle As System.Boolean, _
                             ByRef pGameRegion As System.String, ByVal pSearchByGameRegion As System.Boolean, _
                             ByRef pGameCompat As System.String, ByVal pSearchByGameCompat As System.Boolean, _
                             ByRef pSearchType As System.Byte) As System.Int32
        Dim SerialFound As System.Boolean = False
        Dim GameTitleFound As System.Boolean = False
        Dim GameRegionFound As System.Boolean = False
        Dim GameCompatFound As System.Boolean = False

        pGameDbSearch_Pos = -1
        ReDim pGameDbSearch(pGameDb_Len)

        For pGameDb_Pos = 0 To pGameDb_Len
            'Resize not needed as it is resized to the GameDb_Len

            If pSearchBySerial Then
                If pGameDb(pGameDb_Pos).Serial.ToUpper.Contains(pSerial.ToUpper) Then
                    SerialFound = True
                End If
            End If

            If pSearchByGameTitle Then
                If pGameDb(pGameDb_Pos).Name.ToUpper.Contains(pGameTitle.ToUpper) Then
                    GameTitleFound = True
                End If
            End If

            If pSearchByGameRegion Then
                If pGameDb(pGameDb_Pos).Region.ToUpper.Contains(pGameRegion.ToUpper) Then
                    GameRegionFound = True
                End If
            End If

            If pSearchByGameCompat Then
                If pGameDb(pGameDb_Pos).Compat = pGameCompat Then
                    GameCompatFound = True
                End If
            End If

            If pSearchType = 0 Then
                If (SerialFound Or Not (pSearchBySerial)) And _
                   (GameTitleFound Or Not (pSearchByGameTitle)) And _
                   (GameRegionFound Or Not (pSearchByGameRegion)) And _
                   (GameCompatFound Or Not (pSearchByGameCompat)) Then
                    pGameDbSearch_Pos += 1
                    pGameDbSearch(pGameDbSearch_Pos) = pGameDb_Pos
                End If
            ElseIf pSearchType = 1 Then
                If SerialFound Or GameTitleFound Or GameRegionFound Or GameCompatFound Then
                    pGameDbSearch_Pos += 1
                    pGameDbSearch(pGameDbSearch_Pos) = pGameDb_Pos
                End If
            End If
            SerialFound = False
            GameTitleFound = False
            GameRegionFound = False
            GameCompatFound = False

        Next
        ReDim Preserve pGameDbSearch(pGameDbSearch_Pos)
        GameDb_Search = pGameDbSearch_Pos
    End Function

    Public Sub GameDb_ExportTxt(ByVal pGameDbExport_Loc As System.String, _
                                       ByVal pSepStyle As System.String, _
                                       ByVal pGameDb() As mdlGameDb.rGameDb, _
                                       ByRef pGameDb_Pos As System.Int32, _
                                       ByVal pGameDb_Len As System.Int32 _
                                       )
        'Export the array to a text file (you could import in Excel and Access)
        '   ByVal   pFileGameDb_Tab_Loc         Path and file name of the saved file
        '   ByVal   pSepStyle                   Separator character to be use in the export
        '   ByRef   pGameDb                     The dinamic array of the GameDB to search in
        '   ByRef   pGamedb_Pos                 Position index of the array
        '   ByVal   pGamedb_Len                 Lenght of the array

        If pGameDb_Len >= 0 Then
            Using FileGameDb_Tab_Writer As New System.IO.StreamWriter(pGameDbExport_Loc, False)
                FileGameDb_Tab_Writer.WriteLine(System.String.Concat("#", pSepStyle, "Serial", pSepStyle, "Name", pSepStyle, "Region", pSepStyle, "Compat", pSepStyle, "Record status"))
                For pGameDb_Pos = 0 To pGameDb_Len
                    FileGameDb_Tab_Writer.WriteLine(System.String.Concat(pGameDb_Pos.ToString, _
                                                                         pGameDb(pGameDb_Pos).Serial, pSepStyle, _
                                                                         pGameDb(pGameDb_Pos).Name, pSepStyle, _
                                                                         pGameDb(pGameDb_Pos).Region, pSepStyle, _
                                                                         pGameDb(pGameDb_Pos).Compat, pSepStyle, _
                                                                         pGameDb(pGameDb_Pos).RStatus.ToString))
                Next pGameDb_Pos
                FileGameDb_Tab_Writer.Close()
            End Using
        End If
    End Sub

End Module
