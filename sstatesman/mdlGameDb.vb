'   SStatesMan - a savestate managing tool for PCSX2
'   Copyright (C) 2011 - Leucos
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
        Friend Serial As System.String      'Executable code of the game, normally in the (4 letter)-(5 digits), there are exceptions though (I'm looking at you GTA III)
        Friend Name As System.String        'Currently the longest one is 150 char or so...
        Friend Region As System.String      'Game Region, nuff said
        Friend Compat As System.String      'Compatibility status, it should be a byte, but CByte causes overhead and exceptions
        Friend RStatus As System.Byte       'The record status see below for infos
    End Structure                               'int    bin     desc
    Const rGameDb_RStatus0 As System.Byte = 0   '   0   (0000)  nothing
    Const rGameDb_RStatus1 As System.Byte = 1   '   1   (0001)                          serial
    Const rGameDb_RStatus2 As System.Byte = 2   '   2   (0010)                  name
    Const rGameDb_RStatus3 As System.Byte = 3   '   3   (0011)                  name    serial
    Const rGameDb_RStatus4 As System.Byte = 4   '   4   (0100)          region
    Const rGameDb_RStatus5 As System.Byte = 5   '   5   (0101)          region          serial
    Const rGameDb_RStatus6 As System.Byte = 6   '   6   (0110)          region  name
    Const rGameDb_RStatus7 As System.Byte = 7   '   7   (0111)          region  name    serial
    Const rGameDb_RStatus8 As System.Byte = 8   '   8   (1000)  compat
    Const rGameDb_RStatus9 As System.Byte = 9   '   9   (1001)  compat                  serial
    Const rGameDb_RStatus10 As System.Byte = 10 '  10   (1010)  compat          name
    Const rGameDb_RStatus11 As System.Byte = 11 '  11   (1011)  compat          name    serial
    Const rGameDb_RStatus12 As System.Byte = 12 '  12   (1100)  compat  region
    Const rGameDb_RStatus13 As System.Byte = 13 '  13   (1101)  compat  region          serial
    Const rGameDb_RStatus14 As System.Byte = 14 '  12   (1110)  compat  region  name
    Const rGameDb_RStatus15 As System.Byte = 15 '  15   (1111)  compat  region  name    serial





    Public GameDb() As mdlGameDb.rGameDb    'The array that store the game infos read from the file. Size is variable to conserve memory, use "Redim" to set the start size and then "Redim Preserve" to resize
    Public GameDb_Pos As System.Int32 = 0   'Currently there are around 9000 games in the file, it should be safe to use an integer here, but is better to use a Long (since UBound and other functions give longs as results)
    Public GameDb_Len As System.Int32 = 0   'Occupied record in the array
    Public Const GameDb_ReDimFactor As System.Int32 = 4096

    Public Function GameDb_Load1(ByVal pFileGameDb_Loc As System.String, _
                                 ByRef pGameDb() As mdlGameDb.rGameDb, _
                                 ByRef pGameDb_Pos As System.Int32 _
                                 ) As System.Int32
        'Creates the array from the converted GameDB. Return Value: array status/lenght
        '   ByVal   pFileGameDb_Loc             Path and file name of input database (converted),
        '   ByRef   pGameDb                     The dinamic array of the GameDB
        '   ByRef   pGamedb_Pos                 Position index of the array

        Dim FileGameDb_Line As System.String        'Line read from FileGameDatabaseTmp

        Dim sTmp1 As System.String                  'Temp string #1

        Dim rGameDbTmp As mdlGameDb.rGameDb         'Record reconstructed from the file
        Dim FileGameDb_Line_SepPos As System.Int32  'Position of the record separator, "=".
        Dim FileGameDb_Line_ComPos As System.Int32  'Start position of comments.

        'Variables initialization
        mdlGameDb.GameDb_Unload(pGameDb, pGameDb_Pos, True)   'The array is cleared/initialized
        With rGameDbTmp                                 'Temp record initialization
            .Serial = ""
            .Name = ""
            .Region = ""
            .Compat = ""
            .RStatus = 0
        End With

        'Gotta need a better error handler here...
        If My.Computer.FileSystem.FileExists(pFileGameDb_Loc) Then
            Microsoft.VisualBasic.FileSystem.FileOpen(1, pFileGameDb_Loc, OpenMode.Input, OpenAccess.Read, OpenShare.LockRead)    'Opens the converted GameIndex (GameIndexTmp.dbf)
            Do Until Microsoft.VisualBasic.FileSystem.EOF(1)
                FileGameDb_Line = Microsoft.VisualBasic.FileSystem.LineInput(1)

                FileGameDb_Line = Microsoft.VisualBasic.Strings.Trim(FileGameDb_Line)
                FileGameDb_Line_SepPos = Microsoft.VisualBasic.Strings.InStr(1, FileGameDb_Line, FileGameDb_FieldSep) 'Position of the value separator "="
                FileGameDb_Line_ComPos = mdlGameDb.CheckComments(FileGameDb_Line)                 'Start position of the first comment identifier found "--" or "//"

                If (FileGameDb_Line_SepPos > 0) And Not (FileGameDb_Line_ComPos = 0) Then
                    sTmp1 = Microsoft.VisualBasic.Strings.Left(FileGameDb_Line, FileGameDb_Line_SepPos - 1)
                    Select Case Microsoft.VisualBasic.Strings.Trim(sTmp1)
                        Case FileGameDb_FieldName1                                      'First check: the serial because it's the DB index
                            sTmp1 = Microsoft.VisualBasic.Strings.Trim(Microsoft.VisualBasic.Strings.Mid(FileGameDb_Line, FileGameDb_Line_SepPos + 1, _
                                                                                                         FileGameDb_Line_ComPos - FileGameDb_Line_SepPos))

                            If (rGameDbTmp.RStatus >= rGameDb_RStatus1) And (Not (Trim(rGameDbTmp.Serial) = sTmp1)) Then     'Is there a serial in the record? If yes, it is stored in the DB array (a new serial means a new record) and then the temporary record is updated with the new value

                                If (Microsoft.VisualBasic.UBound(pGameDb) - pGameDb_Pos) <= GameDb_ReDimFactor Then            'Resize of the array. But not too often
                                    ReDim Preserve pGameDb(Microsoft.VisualBasic.UBound(pGameDb) + GameDb_ReDimFactor)
                                End If

                                pGameDb(pGameDb_Pos) = rGameDbTmp   'Store the values in the array
                                pGameDb_Pos = pGameDb_Pos + 1       'increment for the next empty position (it starts with 0)
                                With rGameDbTmp                     'reset the temporary record
                                    .Serial = ""
                                    .Name = ""
                                    .Region = ""
                                    .RStatus = 0
                                    .Compat = ""
                                End With
                            End If
                            rGameDbTmp.Serial = sTmp1               'Store the next serial
                            rGameDbTmp.RStatus = rGameDb_RStatus1   'Status 1 is set because a new serial has been found
                        Case FileGameDb_FieldName2                  'Second check: the name
                            rGameDbTmp.Name = Microsoft.VisualBasic.Strings.Trim(Microsoft.VisualBasic.Strings.Mid(FileGameDb_Line, FileGameDb_Line_SepPos + 1, _
                                                                                                                   FileGameDb_Line_ComPos - FileGameDb_Line_SepPos))   'The trimmed part after the "=" and before a comment
                            rGameDbTmp.RStatus = rGameDbTmp.RStatus + rGameDb_RStatus2

                        Case FileGameDb_FieldName3                  'Third check: the region
                            rGameDbTmp.Region = Microsoft.VisualBasic.Strings.Trim(Microsoft.VisualBasic.Strings.Mid(FileGameDb_Line, FileGameDb_Line_SepPos + 1, _
                                                                                                                     FileGameDb_Line_ComPos - FileGameDb_Line_SepPos)) 'The trimmed part after the "=" and before a comment
                            rGameDbTmp.RStatus = rGameDbTmp.RStatus + rGameDb_RStatus4

                        Case FileGameDb_FieldName4                  'Fourth check: the compatibility
                            rGameDbTmp.Compat = Microsoft.VisualBasic.Strings.Trim(Microsoft.VisualBasic.Strings.Mid(FileGameDb_Line, FileGameDb_Line_SepPos + 1, _
                                                                                                                     FileGameDb_Line_ComPos - FileGameDb_Line_SepPos))  'The trimmed part after the "=" and before a comment
                            rGameDbTmp.RStatus = rGameDbTmp.RStatus + rGameDb_RStatus8
                    End Select
                End If
            Loop
            Microsoft.VisualBasic.FileSystem.FileClose(1)
        Else
            System.Windows.Forms.MessageBox.Show("Some kinda failure during GameDB loading. File not found or inaccessible in the configured path.", _
                                                 "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error)
            pGameDb_Pos = -1
        End If

        If Not (pGameDb_Pos = 0) Then          'If the GameIndex.dbf file is not empty (no record info)
            pGameDb(pGameDb_Pos) = rGameDbTmp   'Store The Last Record (why the heck Square Enix didn't do a game with this name? :P)
            ReDim Preserve pGameDb(0 To pGameDb_Pos)
            GameDb_Load1 = pGameDb_Pos          'GameDb lenght = GameDb position (result)
        Else
            GameDb_Load1 = 0                    'GameDb empty (result)
        End If
    End Function

    Public Function GameDb_Load2(ByVal pFileGameDb_Loc As System.String, _
                                 ByRef pGameDb() As mdlGameDb.rGameDb, _
                                 ByRef pGameDb_Pos As System.Int32 _
                                 ) As System.Int32
        'Creates the array from the converted GameDB. Return Value: array status/lenght
        '   ByVal   pFileGameDb_Loc             Path and file name of input database (converted),
        '   ByRef   pGameDb                     The dinamic array of the GameDB
        '   ByRef   pGamedb_Pos                 Position index of the array

        Dim sTmp1 As System.String()                    'Temp string #1
        If My.Computer.FileSystem.FileExists(pFileGameDb_Loc) Then
            mdlGameDb.GameDb_Unload(pGameDb, pGameDb_Pos, True)   'The array is cleared/initialized
            Using FileGameDb_Reader = My.Computer.FileSystem.OpenTextFieldParser(pFileGameDb_Loc)
                FileGameDb_Reader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited
                FileGameDb_Reader.Delimiters = {FileGameDb_FieldSep}
                While Not FileGameDb_Reader.EndOfData
                    'Try
                    sTmp1 = FileGameDb_Reader.ReadFields()
                    Select Case sTmp1(0)
                        Case FileGameDb_FieldName1
                            If Not (pGameDb(pGameDb_Pos).Serial = sTmp1(1) Or pGameDb(pGameDb_Pos).Serial = "") Then
                                pGameDb_Pos = pGameDb_Pos + 1
                                If (pGameDb.GetUpperBound(0) - pGameDb_Pos) <= GameDb_ReDimFactor Then            'Resize of the array. But not too often
                                    ReDim Preserve pGameDb(pGameDb.GetUpperBound(0) + GameDb_ReDimFactor)
                                End If
                            End If
                            pGameDb(pGameDb_Pos).Serial = sTmp1(1)
                            pGameDb(pGameDb_Pos).RStatus = rGameDb_RStatus1
                            pGameDb(pGameDb_Pos).Name = ""
                            pGameDb(pGameDb_Pos).Region = ""
                            pGameDb(pGameDb_Pos).Compat = ""
                        Case FileGameDb_FieldName2
                            pGameDb(pGameDb_Pos).Name = sTmp1(1)
                            pGameDb(pGameDb_Pos).RStatus = pGameDb(pGameDb_Pos).RStatus + rGameDb_RStatus2
                        Case FileGameDb_FieldName3
                            pGameDb(pGameDb_Pos).Region = sTmp1(1)
                            pGameDb(pGameDb_Pos).RStatus = pGameDb(pGameDb_Pos).RStatus + rGameDb_RStatus4
                        Case FileGameDb_FieldName4
                            pGameDb(pGameDb_Pos).Compat = sTmp1(1)
                            pGameDb(pGameDb_Pos).RStatus = pGameDb(pGameDb_Pos).RStatus + rGameDb_RStatus8
                    End Select
                    'Catch ex As Exception
                    'MsgBox("Ehi, riga corrotta!")
                    'End Try
                End While
                FileGameDb_Reader.Close()
            End Using
            ReDim Preserve pGameDb(0 To pGameDb_Pos)
        Else
            System.Windows.Forms.MessageBox.Show("Some kinda failure during GameDB loading. File not found or inaccessible in the configured path.", _
                                                 "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error)
            GameDb_Pos = -1
        End If
        GameDb_Load2 = pGameDb_Pos
    End Function

    Public Function GameDb_Load3(ByVal pFileGameDb_Loc As System.String, _
                                 ByRef pGameDb() As mdlGameDb.rGameDb, _
                                 ByRef pGameDb_Pos As System.Int32 _
                                 ) As System.Int32
        'Creates the array from the converted GameDB. Return Value: array status/lenght
        '   ByVal   pFileGameDb_Loc             Path and file name of input database (converted),
        '   ByRef   pGameDb                     The dinamic array of the GameDB
        '   ByRef   pGamedb_Pos                 Position index of the array
        If My.Computer.FileSystem.FileExists(pFileGameDb_Loc) Then
            mdlGameDb.GameDb_Unload(pGameDb, pGameDb_Pos, True)   'The array is cleared/initialized, position to 0
            Using FileGameDb_Reader = My.Computer.FileSystem.OpenTextFileReader(pFileGameDb_Loc, System.Text.Encoding.Default)
                While Not FileGameDb_Reader.EndOfStream
                    Dim sTmp1 As System.String = FileGameDb_Reader.ReadLine()
                    'If Not (sTmp1.StartsWith(FileGameDb_CommentStyle1) Or _
                    '        sTmp1.StartsWith(FileGameDb_CommentStyle2) Or _
                    '        sTmp1.StartsWith(FileGameDb_CommentStyle3) Or _
                    '        sTmp1.Length = 0) Then
                    If Not (sTmp1.StartsWith(FileGameDb_CommentStyle1) Or _
                            sTmp1.Length = 0) Then
                        Dim sTmp2 As System.String() = sTmp1.Split({FileGameDb_FieldSep, FileGameDb_CommentStyle2}, StringSplitOptions.None)
                        'Dim sTmp2 As System.String() = sTmp1.Split({FileGameDb_FieldSep(0)})
                        If sTmp2.Length > 1 Then
                            sTmp2(0) = sTmp2(0).Trim
                            sTmp2(1) = sTmp2(1).Trim

                            Select Case sTmp2(0)
                                Case FileGameDb_FieldName1
                                    If Not (pGameDb(pGameDb_Pos).Serial = sTmp2(1) Or pGameDb(pGameDb_Pos).Serial = "") Then
                                        pGameDb_Pos = pGameDb_Pos + 1
                                        If (pGameDb.Length - pGameDb_Pos) <= 2 Then   'Resize of the array. But not too often
                                            ReDim Preserve pGameDb(pGameDb.Length + GameDb_ReDimFactor)
                                        End If
                                    End If
                                    pGameDb(pGameDb_Pos).Serial = sTmp2(1)
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
                                    pGameDb(pGameDb_Pos).Compat = sTmp2(1)
                                    pGameDb(pGameDb_Pos).RStatus = pGameDb(pGameDb_Pos).RStatus + rGameDb_RStatus8
                            End Select
                        End If
                    End If

                End While
                FileGameDb_Reader.Close()
            End Using
            ReDim Preserve pGameDb(0 To pGameDb_Pos)
        Else
            System.Windows.Forms.MessageBox.Show("Some kinda failure during GameDB loading. File not found or inaccessible in the configured path.", _
                                                 "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error)
            pGameDb_Pos = -1
        End If
        GameDb_Load3 = pGameDb_Pos
    End Function

    Public Function GameDb_Unload(ByRef pGameDb() As mdlGameDb.rGameDb, _
                                  ByRef pGameDb_Pos As System.Int32, _
                                  Optional ByRef pWillBeUsed As System.Boolean = False _
                                  ) As System.Int32
        'Return Value: array status/lenght
        '   ByRef   pGameDb()               The dinamic array of the GameDB
        '   ByRef   pGamedb_Pos             Position index of the array
        '   ByRef   pWillBeUsed             Specifies if the array will be used after being cleared

        If pWillBeUsed Then
            ReDim pGameDb(GameDb_ReDimFactor)
        Else
            ReDim pGameDb(-1)
        End If
        pGameDb_Pos = 0         'Array position index starts to 0
        GameDb_Unload = -1
    End Function

    Public Function GameDb_SearchSerial(ByVal pSerial As System.String, _
                                        ByVal pGameDb() As mdlGameDb.rGameDb, _
                                        ByRef pGameDb_Pos As System.Int32, _
                                        ByVal pGameDb_Len As System.Int32 _
                                        ) As mdlGameDb.rGameDb
        'Search the array for a serial only, return the first value (a serial should be unique). Return Value: the record o the result
        '   ByVal   pSerial                     Serial to search
        '   Byval   paGameDb                    The dinamic array of the GameDB to search in
        '   ByRef   pGamedb_Pos                 Position index of the array
        '   ByVal   pGamedb_Len                 Lenght of the array
        With GameDb_SearchSerial
            .Serial = pSerial
            .Region = ""
            .RStatus = 1
            .Compat = ""
        End With

        pSerial.Trim()
        If pSerial Like "BIOS" Then
            GameDb_SearchSerial.Name = "(PS2 BIOS)"
            GameDb_SearchSerial.Region = ""
            GameDb_SearchSerial.Compat = "5"
        ElseIf pGameDb_Len >= 0 Then
            GameDb_SearchSerial.Name = "(unknown - no match in GameDB)"
            For pGameDb_Pos = pGameDb_Len To 1 Step -1
                If pGameDb(pGameDb_Pos).Serial Like pSerial Then
                    GameDb_SearchSerial = pGameDb(pGameDb_Pos)
                    Exit For
                End If
            Next pGameDb_Pos
        Else : GameDb_SearchSerial.Name = "GameDB is not loaded or is empty!"
        End If
    End Function

    Public Function GameDb_ExportTxt2(ByVal pGameDbExport_Loc As System.String, _
                                      ByVal pSepStyle As System.String, _
                                      ByVal pGameDb() As mdlGameDb.rGameDb, _
                                      ByRef pGameDb_Pos As System.Int32, _
                                      ByVal pGameDb_Len As System.Int32 _
                                      ) As System.Int32
        'Export the array to a text file (you could import in Excel and Access)
        '   ByVal   pFileGameDb_Tab_Loc         Path and file name of the saved file
        '   ByVal   pSepStyle                   Separator character to be use in the export
        '   ByRef   pGameDb                     The dinamic array of the GameDB to search in
        '   ByRef   pGamedb_Pos                 Position index of the array
        '   ByVal   pGamedb_Len                 Lenght of the array

        If pGameDb_Len >= 0 Then
            Using FileGameDb_Tab_Writer = My.Computer.FileSystem.OpenTextFileWriter(pGameDbExport_Loc, False)
                FileGameDb_Tab_Writer.WriteLine(System.String.Concat("RStatus", pSepStyle, "Compat", pSepStyle, " Serial", pSepStyle, "Region", pSepStyle, "Name"))
                For pGameDb_Pos = 0 To pGameDb_Len
                    FileGameDb_Tab_Writer.WriteLine(System.String.Concat(pGameDb(pGameDb_Pos).RStatus.ToString, pSepStyle, _
                                                                         pGameDb(pGameDb_Pos).Compat, pSepStyle, _
                                                                         pGameDb(pGameDb_Pos).Serial, pSepStyle, _
                                                                         pGameDb(pGameDb_Pos).Region, pSepStyle, _
                                                                         pGameDb(pGameDb_Pos).Name))
                Next pGameDb_Pos
                FileGameDb_Tab_Writer.Close()
            End Using
        End If
        GameDb_ExportTxt2 = 0

    End Function

    Private Function CheckComments(ByVal str As System.String) As System.Int32
        Dim position1 As System.Int32
        Dim position2 As System.Int32
        position1 = Microsoft.VisualBasic.Strings.InStr(1, str, FileGameDb_CommentStyle1)
        position2 = Microsoft.VisualBasic.Strings.InStr(1, str, FileGameDb_CommentStyle2)
        If (position1 + position2) = 0 Then
            CheckComments = Len(Trim(str))
        ElseIf position1 = 0 Then
            CheckComments = position2 - 1
        ElseIf position2 = 0 Then
            CheckComments = position1 - 1
        Else
            If position1 <= position2 Then
                CheckComments = position1 - 1
            Else
                CheckComments = position2 - 1
            End If
        End If
    End Function

End Module
