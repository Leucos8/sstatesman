'   SStatesMan - Savestate Manager for PCSX2 0.9.8
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

    'Constants (will be deleted or moved)
    Const FileGameDb_FieldSep As System.String = "="        'Field separator in the database
    Const FileGameDb_CommentStyle1 As System.String = "--"  'Visual C++ comment style 1 (usually the start of the line)
    Const FileGameDb_CommentStyle2 As System.String = "//"  'Visual C++ comment style 2 (usually in the line)
    Const FileGameDb_CommentStyle3 As System.String = ";"   'Visual C++ comment style 3 (not used yet)

    Const FileGameDb_FieldName1 As System.String = "Serial" 'Database first field name, also the index
    Const FileGameDb_FieldName2 As System.String = "Name"   'Database second field name
    Const FileGameDb_FieldName3 As System.String = "Region" 'Database third field name
    Const FileGameDb_FieldName4 As System.String = "Compat" 'Database fourth field name

    'Record
    Public Structure rGameDb                'Type definition of a record in GameIndex.dbf, only the info needed.
        Friend Serial As System.String      'Executable code of the game, normally in the (4 letter)-(5 digits), there are exceptions though (I'm looking at you GTA III)
        Friend Name As System.String        'Currently the longest one is 150 char or so...
        Friend Region As System.String      'I have to yet determine the longest region code (maybe some PAL combo?)
        Friend Compat As System.Byte        'Compatibility status
        Friend RStatus As System.Byte       'The record status see below for infos
    End Structure                               'int    bin     desc
    Const rGameDb_RStatus0 As System.Byte = 0   '   0   (000)   nothing
    Const rGameDb_RStatus1 As System.Byte = 1   '   1   (001)   serial
    Const rGameDb_RStatus2 As System.Byte = 2   '   2   (010)           name
    Const rGameDb_RStatus3 As System.Byte = 3   '   3   (011)   serial  name
    Const rGameDb_RStatus4 As System.Byte = 4   '   4   (100)                   region
    Const rGameDb_RStatus5 As System.Byte = 5   '   5   (101)   serial          region
    Const rGameDb_RStatus6 As System.Byte = 6   '   6   (110)           name    region
    Const rGameDb_RStatus7 As System.Byte = 7   '   7   (111)   serial  name    region

    Public GameDb() As MdlGameDb.rGameDb    'The array that store the game infos read from the file. Size is variable to conserve memory, use "Redim" to set the start size and then "Redim Preserve" to resize
    Public GameDb_Pos As System.Int64       'Currently there are around 9000 games in the file, it should be safe to use an integer here, but is better to use a Long (since UBound and other functions give longs as results)
    Public GameDb_Len As System.Int64       'Occupied record in the array

    Public Function FileGameDb_Convert(ByVal pFileGameDb_Loc As System.String, _
                                       ByVal pFileGameDb_Win_Loc As System.String _
                                       ) As System.Int32
        'Obsolete. Converts PCSX2 GameIndex.dbf: it changes the endline character from Unix to DOS/Windows. (try to open the two files in Note Pad and you'll see the difference)
        '   ByVal   pFileGameDb_Loc         Path and file name of the input database,
        '   ByVal   pFileGameDb_Win_Loc     Path and file name of the output database (converted).
        'Return value: 0 = no errors, >0 error code

        Dim sTmp1 As System.String  'It can contain around 2 billions of character and PCSX2 database is currently above 1 MiB of size.

        sTmp1 = Microsoft.VisualBasic.FileIO.FileSystem.ReadAllText(pFileGameDb_Loc)
        sTmp1 = Replace(sTmp1, vbLf, vbNewLine)       'The endline character is replaced in all of the occurence with vbnewline
        Microsoft.VisualBasic.FileIO.FileSystem.WriteAllText(pFileGameDb_Win_Loc, sTmp1, False)
        FileGameDb_Convert = 0   'Useless
    End Function

    Public Function GameDb_Load1(ByVal pFileGameDb_Loc As System.String, _
                                 ByRef pGameDb() As MdlGameDb.rGameDb, _
                                 ByRef pGameDb_Pos As System.Int64 _
                                 ) As System.Int64
        'Creates the array from the converted GameDB. Return Value: array status/lenght
        '   ByVal   pFileGameDb_Loc             Path and file name of input database (converted),
        '   ByRef   pGameDb                     The dinamic array of the GameDB
        '   ByRef   pGamedb_Pos                 Position index of the array

        Dim FileGameDb_Line As System.String        'Line read from FileGameDatabaseTmp

        Dim sTmp1 As System.String                  'Temp string #1

        Dim rGameDbTmp As MdlGameDb.rGameDb         'Record reconstructed from the file
        Dim FileGameDb_Line_SepPos As System.Int32  'Position of the record separator, "=".
        Dim FileGameDb_Line_ComPos As System.Int32  'Start position of comments.

        'Variables initialization
        MdlGameDb.GameDb_Unload(pGameDb, pGameDb_Pos)   'The array is cleared/initialized
        With rGameDbTmp                                 'Temp record initialization
            .Serial = ""
            .Name = ""
            .Region = ""
            .Compat = 0
            .RStatus = 0
        End With

        'Gotta need a better error handler here...
        FileSystem.FileOpen(1, pFileGameDb_Loc, OpenMode.Input, OpenAccess.Read, OpenShare.LockRead)    'Opens the converted GameIndex (GameIndexTmp.dbf)
        Do Until FileSystem.EOF(1)
            FileGameDb_Line = FileSystem.LineInput(1)

            FileGameDb_Line = Trim(FileGameDb_Line)
            FileGameDb_Line_SepPos = InStr(1, FileGameDb_Line, FileGameDb_FieldSep) 'Position of the value separator "="
            FileGameDb_Line_ComPos = CheckComments(FileGameDb_Line)                 'Start position of the first comment identifier found "--" or "//"

            If (FileGameDb_Line_SepPos > 0) And Not (FileGameDb_Line_ComPos = 0) Then
                sTmp1 = Left(FileGameDb_Line, FileGameDb_Line_SepPos - 1)
                Select Case Trim(sTmp1)
                    Case FileGameDb_FieldName1                                      'First check: the serial because it's the DB index
                        sTmp1 = Trim(Mid(FileGameDb_Line, FileGameDb_Line_SepPos + 1, FileGameDb_Line_ComPos - FileGameDb_Line_SepPos))

                        If (rGameDbTmp.RStatus = rGameDb_RStatus1) And (Not (Trim(rGameDbTmp.Serial) = sTmp1)) Then     'Is there a serial in the record? If yes, it is stored in the DB array (a new serial means a new record) and then the temporary record is updated with the new value

                            If (UBound(pGameDb) - pGameDb_Pos) <= 2 Then            'Resize of the array. But not too often
                                ReDim Preserve pGameDb(0 To UBound(pGameDb) + 4)
                            End If

                            If Not (Trim(rGameDbTmp.Name) = "") Then
                                rGameDbTmp.RStatus = rGameDbTmp.RStatus + rGameDb_RStatus2
                            End If

                            If Not (rGameDbTmp.Region = "") Then
                                rGameDbTmp.RStatus = rGameDbTmp.RStatus + rGameDb_RStatus4
                            End If

                            pGameDb(pGameDb_Pos) = rGameDbTmp   'Store the values in the array
                            pGameDb_Pos = pGameDb_Pos + 1       'increment for the next empty position (it starts with 0)
                            With rGameDbTmp                     'reset the temporary record
                                .Serial = ""
                                .Name = ""
                                .Region = ""
                                .RStatus = 0
                            End With
                        End If
                        rGameDbTmp.Serial = sTmp1               'Store the next serial
                        rGameDbTmp.RStatus = rGameDb_RStatus1   'Status 1 is set because a new serial has been found
                    Case FileGameDb_FieldName2                  'Second check: the name
                        rGameDbTmp.Name = Trim(Mid(FileGameDb_Line, FileGameDb_Line_SepPos + 1, FileGameDb_Line_ComPos - FileGameDb_Line_SepPos))   'The trimmed part after the "=" and before a comment

                    Case FileGameDb_FieldName3                  'Third check: the region
                        rGameDbTmp.Region = Trim(Mid(FileGameDb_Line, FileGameDb_Line_SepPos + 1, FileGameDb_Line_ComPos - FileGameDb_Line_SepPos)) 'The trimmed part after the "=" and before a comment

                    Case FileGameDb_FieldName4                  'Fourth check: the compatibility
                        rGameDbTmp.Compat = CByte(Trim(Mid(FileGameDb_Line, FileGameDb_Line_SepPos + 1, FileGameDb_Line_ComPos - FileGameDb_Line_SepPos)))  'The trimmed part after the "=" and before a comment
                End Select
            End If
        Loop
        FileSystem.FileClose(1)

        If Not (pGameDb_Pos <= 0) Then          'If the GameIndex.dbf file is not empty (no record info)
            If Not (rGameDbTmp.Name = "") Then
                rGameDbTmp.RStatus = rGameDbTmp.RStatus + rGameDb_RStatus2
            End If
            If Not (rGameDbTmp.Region = "") Then
                rGameDbTmp.RStatus = rGameDbTmp.RStatus + rGameDb_RStatus4
            End If
            pGameDb(pGameDb_Pos) = rGameDbTmp   'Store The Last Record (why the heck Square Enix didn't do a game with this name? :P)
            GameDb_Load1 = pGameDb_Pos          'GameDb lenght = GameDb position (result)
            pGameDb_Pos = 0                     'Reset the position
        Else
            GameDb_Load1 = 0                    'GameDb empty (result)
        End If
    End Function

    Public Function GameDb_Load2(ByVal pFileGameDb_Loc As System.String, _
                                 ByRef pGameDb() As MdlGameDb.rGameDb, _
                                 ByRef pGameDb_Pos As System.Int64 _
                                 ) As System.Int64
        'Creates the array from the converted GameDB, lite version. Return Value: array status/lenght
        '   ByVal   pFileGameDb_Loc             Path and file name of input database
        '   ByRef   pGameDb                     The dinamic array of the GameDB
        '   ByRef   pGamedb_Pos                 Position index of the array

        Dim sFileGameDbLine As System.String    'Line read from FileGameDatabaseTmp
        Dim sTmp1 As System.String              'Temp string #1
        Dim rGameDbTmp As MdlGameDb.rGameDb     'Record reconstructed from the file

        'Variables initialization
        MdlGameDb.GameDb_Unload(pGameDb, pGameDb_Pos)   'The array is cleared/initialized
        With rGameDbTmp                                 'Temp record initialization
            .Serial = ""
            .Name = ""
            .Region = ""
            .RStatus = 0
        End With

        FileSystem.FileOpen(1, pFileGameDb_Loc, OpenMode.Input, OpenAccess.Read, OpenShare.LockRead)
        Do Until FileSystem.EOF(1)
            sFileGameDbLine = FileSystem.LineInput(1)
            sTmp1 = Left(sFileGameDbLine, 6)
            Select Case Trim(sTmp1)
                Case FileGameDb_FieldName1                                  'First check: the serial because it's the DB index
                    sTmp1 = Trim(Mid(sFileGameDbLine, 9, 12))
                    If Not (Trim(rGameDbTmp.Serial) = sTmp1) Then           'Is there a serial in the record? If yes, it is stored in the DB array (a new serial means a new record) and then the temporary record is updated with the new value
                        If (UBound(pGameDb) - pGameDb_Pos) <= 2 Then        'Resize of the array. But not too often
                            ReDim Preserve pGameDb(0 To UBound(pGameDb) + 4)
                        End If
                        pGameDb(pGameDb_Pos) = rGameDbTmp                   'Store the values in the array
                        pGameDb_Pos = pGameDb_Pos + 1                       'increment for the next empty position (it starts with 0)
                        With rGameDbTmp                                     'reset the temporary record
                            .Serial = ""
                            .Name = ""
                            .Region = ""
                            .Compat = 0
                            .RStatus = 0
                        End With
                    End If
                    rGameDbTmp.Serial = sTmp1                               'Store the next serial
                Case FileGameDb_FieldName2                                  'Second check: the name
                    rGameDbTmp.Name = Mid(sFileGameDbLine, 9, 160)
                Case FileGameDb_FieldName3                                  'Third check: the region
                    rGameDbTmp.Region = Mid(sFileGameDbLine, 9, 16)
                Case FileGameDb_FieldName4                                  'Fourth check: the compatibility
                    rGameDbTmp.Compat = CByte(Mid(sFileGameDbLine, 9, 10))
            End Select
        Loop
        FileSystem.FileClose(1)

        If Not (pGameDb_Pos <= 0) Then          'If the GameIndex.dbf file is not empty (no record info)
            pGameDb_Pos = pGameDb_Pos + 1       'increment for the next empty position
            pGameDb(pGameDb_Pos) = rGameDbTmp   'Store The Last Record (why the heck Square Enix didn't do a game with this name? :P)
            GameDb_Load2 = pGameDb_Pos          'GameDb lenght = GameDb position (result)
            pGameDb_Pos = 0                     'Reset the position
        Else
            GameDb_Load2 = 0                    'GameDb empty (result)
        End If
    End Function

    Public Function GameDb_Load3(ByVal pFileGameDb_Loc As System.String, _
                                 ByRef pGameDb() As MdlGameDb.rGameDb, _
                                 ByRef pGameDb_Pos As System.Int64 _
                                 ) As System.Int64
        'Creates the array from the converted GameDB. Return Value: array status/lenght
        '   ByVal   pFileGameDb_Loc             Path and file name of input database (converted),
        '   ByRef   pGameDb                     The dinamic array of the GameDB
        '   ByRef   pGamedb_Pos                 Position index of the array

        Dim sTmp1 As System.String()                    'Temp string #1
        MdlGameDb.GameDb_Unload(pGameDb, pGameDb_Pos)   'The array is cleared/initialized

        Using FileGameDb_Reader = My.Computer.FileSystem.OpenTextFieldParser(pFileGameDb_Loc)
            FileGameDb_Reader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited
            FileGameDb_Reader.Delimiters = {FileGameDb_FieldSep, FileGameDb_CommentStyle1, FileGameDb_CommentStyle2, FileGameDb_CommentStyle3}
            While Not FileGameDb_Reader.EndOfData
                Try
                    sTmp1 = FileGameDb_Reader.ReadFields()
                    Select Case sTmp1(0)
                        Case FileGameDb_FieldName1
                            If pGameDb_Pos <= 0 Then
                                pGameDb(pGameDb_Pos).Serial = sTmp1(1)
                                pGameDb(pGameDb_Pos).RStatus = rGameDb_RStatus1
                                pGameDb_Pos = pGameDb_Pos + 1
                            ElseIf Not (pGameDb(pGameDb_Pos - 1).Serial = sTmp1(1)) Then
                                pGameDb(pGameDb_Pos).Serial = sTmp1(1)
                                pGameDb(pGameDb_Pos).RStatus = rGameDb_RStatus1
                                pGameDb_Pos = pGameDb_Pos + 1
                                If (pGameDb.GetUpperBound(0) - pGameDb_Pos) <= 2 Then            'Resize of the array. But not too often
                                    ReDim Preserve pGameDb(0 To pGameDb.GetUpperBound(0) + 4)
                                End If
                            End If
                        Case FileGameDb_FieldName2
                            pGameDb(pGameDb_Pos - 1).Name = sTmp1(1)
                            pGameDb(pGameDb_Pos - 1).RStatus = pGameDb(pGameDb_Pos - 1).RStatus + rGameDb_RStatus2
                        Case FileGameDb_FieldName3
                            pGameDb(pGameDb_Pos - 1).Region = sTmp1(1)
                            pGameDb(pGameDb_Pos - 1).RStatus = pGameDb(pGameDb_Pos - 1).RStatus + rGameDb_RStatus4
                        Case FileGameDb_FieldName4
                            pGameDb(pGameDb_Pos - 1).Compat = CByte(sTmp1(1))
                    End Select
                Catch ex As Exception
                    'MsgBox("Ehi, riga corrotta!")
                End Try
            End While
        End Using
        pGameDb_Pos = pGameDb_Pos - 1
        GameDb_Load3 = pGameDb_Pos
        pGameDb_Pos = 0
    End Function

    Public Function GameDb_Unload(ByRef pGameDb() As MdlGameDb.rGameDb, _
                                  ByRef pGameDb_Pos As System.Int64 _
                                  ) As System.Int64
        'Return Value: array status/lenght
        '   ByRef   pGameDb()               The dinamic array of the GameDB
        '   ByRef   pGamedb_Pos             Position index of the array

        ReDim pGameDb(0 To 4)   'Array start size of pagamedb set to 4
        pGameDb_Pos = 0         'Array position index starts to 0
        GameDb_Unload = -1
    End Function

    Public Function GameDb_SearchSerial(ByVal pSerial As System.String, _
                                        ByVal pGameDb() As MdlGameDb.rGameDb, _
                                        ByRef pGameDb_Pos As System.Int64, _
                                        ByVal pGameDb_Len As System.Int64 _
                                        ) As MdlGameDb.rGameDb
        'Search the array for a serial only, return the first value (a serial should be unique). Return Value: the record o the result
        '   ByVal   pSerial                     Serial to search
        '   Byval   paGameDb                    The dinamic array of the GameDB to search in
        '   ByRef   pGamedb_Pos                 Position index of the array
        '   ByVal   pGamedb_Len                 Lenght of the array

        GameDb_SearchSerial.Serial = pSerial
        GameDb_SearchSerial.Region = "(unk)"
        GameDb_SearchSerial.RStatus = 1

        If pGameDb_Len >= 0 Then
            GameDb_SearchSerial.Name = "(unknown - not in GameDB)"
            pSerial = UCase(Trim(pSerial))
            For pGameDb_Pos = pGameDb_Len To 1 Step -1
                If Trim(pGameDb(pGameDb_Pos).Serial) Like pSerial Then
                    GameDb_SearchSerial = pGameDb(pGameDb_Pos)
                    Exit For
                End If
            Next pGameDb_Pos
        Else
            GameDb_SearchSerial.Name = "(unknown - GameDB is not loaded)"
        End If
    End Function

    Public Function GameDb_Export_TsvTxt1(ByVal pFileGameDb_Tab_Loc As System.String, _
                                         ByVal pGameDb() As MdlGameDb.rGameDb, _
                                         ByRef pGameDb_Pos As System.Int64, _
                                         ByVal pGameDb_Len As System.Int64 _
                                         ) As System.Int64
        'Export the array to a tab separated Values text file (you could import in Excel and Access)
        '   ByVal   pFileGameDb_Tab_Loc         Path and file name of the saved file
        '   ByRef   pGameDb                     The dinamic array of the GameDB to search in
        '   ByRef   pGamedb_Pos                 Position index of the array
        '   ByVal   pGamedb_Len                 Lenght of the array
        'Return Value:
        '   0 = array empty, export not needed
        '   Array lenght

        If pGameDb_Len >= 0 Then

            FileSystem.FileOpen(1, pFileGameDb_Tab_Loc, OpenMode.Output, OpenAccess.Write, OpenShare.LockWrite)
            FileSystem.PrintLine(1, "RStatus" & vbTab & "Compat" & vbTab & " Serial" & vbTab & "Region" & vbTab & "Name")  'First line: headers
            For pGameDb_Pos = 0 To pGameDb_Len
                FileSystem.PrintLine(1, pGameDb(pGameDb_Pos).RStatus & vbTab & _
                                     pGameDb(pGameDb_Pos).Compat & vbTab & _
                                     Trim(pGameDb(pGameDb_Pos).Serial) & vbTab & _
                                     Trim(pGameDb(pGameDb_Pos).Region) & vbTab & _
                                     Trim(pGameDb(pGameDb_Pos).Name))
            Next pGameDb_Pos
            FileSystem.FileClose(1)
        End If
        GameDb_Export_TsvTxt1 = 0

    End Function

    Public Function GameDb_ExportTxt2(ByVal pGameDbExport_Loc As System.String, _
                                      ByVal pSepStyle As System.String, _
                                      ByVal pGameDb() As mdlGameDb.rGameDb, _
                                      ByRef pGameDb_Pos As System.Int64, _
                                      ByVal pGameDb_Len As System.Int64 _
                                      ) As System.Int64
        'Export the array to a text file (you could import in Excel and Access)
        '   ByVal   pFileGameDb_Tab_Loc         Path and file name of the saved file
        '   ByVal   pSepStyle                   Separator character to be use in the export
        '   ByRef   pGameDb                     The dinamic array of the GameDB to search in
        '   ByRef   pGamedb_Pos                 Position index of the array
        '   ByVal   pGamedb_Len                 Lenght of the array

        If pGameDb_Len >= 0 Then
            Using FileGameDb_Tab_Writer = My.Computer.FileSystem.OpenTextFileWriter(pGameDbExport_Loc, False)
                FileGameDb_Tab_Writer.WriteLine("RStatus" & pSepStyle & "Compat" & pSepStyle & " Serial" & pSepStyle & "Region" & pSepStyle & "Name")
                For pGameDb_Pos = 0 To pGameDb_Len
                    FileGameDb_Tab_Writer.WriteLine(pGameDb(pGameDb_Pos).RStatus & pSepStyle & _
                                                    pGameDb(pGameDb_Pos).Compat & pSepStyle & _
                                                    Trim(pGameDb(pGameDb_Pos).Serial) & pSepStyle & _
                                                    Trim(pGameDb(pGameDb_Pos).Region) & pSepStyle & _
                                                    Trim(pGameDb(pGameDb_Pos).Name))
                Next pGameDb_Pos
            End Using
        End If
        GameDb_ExportTxt2 = 0

    End Function

    Private Function CheckComments(ByVal str As System.String) As System.Int32
        Dim position1 As System.Int32
        Dim position2 As System.Int32
        position1 = InStr(1, str, FileGameDb_CommentStyle1)
        position2 = InStr(1, str, FileGameDb_CommentStyle2)
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
