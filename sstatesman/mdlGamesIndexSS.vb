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
Module mdlGamesIndexSS
    Public Structure rGamesIndexSStates             'Record declaration
        'Friend GameInfo As rGameDb                  'Game information from the GameDb array
        Friend GameDb_Ref As System.Int32           'GameDb reference
        Friend SStatesList_StartPos As System.Int32 'Start position in SStatesList() of the records of this game
        Friend SStatesList_EndPos As System.Int32   'End position in SStatesList() of the record of this game
        Friend SStates_Count As System.Int32
        Friend SStates_Bck_Count As System.Int32
        Friend SStates_SizeTot As System.Int64     'Total size in bytes of the savestate files
        Friend SStates_Bck_SizeTot As System.Int64 'Total size in bytes of the savestate backup files
    End Structure
    Public GamesIndexSS() As rGamesIndexSStates     'Array with the games with found savestates
    'Public GamesIndexSS_Pos As System.Int32 = 0     'Position index of the array
    'Public GamesIndexSS_Len As System.Int32 = 0     'Occupied records of the array
    Public GamesIndexSS_ArrayStatus As mdlMain.ArrayStatus = mdlMain.ArrayStatus.ArrayNotLoaded
    Public Const GamesIndexSS_ReDimFactor As System.Int32 = 8

    Public Function GameIndexSS_Load(ByRef pSStatesList() As mdlSStatesList.rSStatesList, _
                                     ByRef pGameDb() As mdlGameDb.rGameDb, _
                                     ByRef pGameIndexSS() As mdlGamesIndexSS.rGamesIndexSStates _
                                     ) As mdlMain.ArrayStatus

        Dim GameIndexSS_Pos As System.Int32 = 0

        If pSStatesList.GetLength(0) > 0 Then
            GameIndexSS_Pos = mdlGamesIndexSS.GameIndexSS_Unload(pGameIndexSS, GamesIndexSS_ReDimFactor) 'Clears the array
            With pGameIndexSS(GameIndexSS_Pos)
                '.GameInfo.Serial = "*"                   'The first record show all games
                '.GameInfo.Name = "(all games)"
                '.GameInfo.Region = "*"
                '.GameInfo.Compat = "0"
                '.GameInfo.RStatus = 0
                .GameDb_Ref = -3                         'GameDb reference for "(all games)" is set to -3
                .SStatesList_StartPos = 0
                .SStatesList_EndPos = pSStatesList.GetUpperBound(0)
            End With

            Dim myCurrentSerial As System.String = ""

            For SStatesList_Pos As System.Int32 = 0 To pSStatesList.GetUpperBound(0)
                If Not (myCurrentSerial Like pSStatesList(SStatesList_Pos).SStateSerial) Then
                    pGameIndexSS(GameIndexSS_Pos).SStatesList_EndPos = SStatesList_Pos - 1

                    myCurrentSerial = pSStatesList(SStatesList_Pos).SStateSerial

                    If (pGameIndexSS.GetUpperBound(0) - GameIndexSS_Pos) <= 2 Then 'Resize the array when needed
                        ReDim Preserve pGameIndexSS(pGameIndexSS.GetUpperBound(0) + GamesIndexSS_ReDimFactor)
                    End If

                    GameIndexSS_Pos += 1

                    With pGameIndexSS(GameIndexSS_Pos)
                        .SStatesList_StartPos = SStatesList_Pos
                        '.GameInfo = mdlGameDb.GameDb_RecordExtract(pSStatesList(pSStatesList_Pos).SStateSerial, mdlGameDb.GameDb)
                        '.GameInfo.Serial = pSStatesList(pSStatesList_Pos).SStateSerial
                        .GameDb_Ref = mdlGameDb.GameDb_RefExtract(myCurrentSerial, mdlGameDb.GameDb)

                        .SStates_Count = 0
                        .SStates_Bck_Count = 0
                        .SStates_SizeTot = 0
                        .SStates_Bck_SizeTot = 0

                    End With

                    'On Error Resume Next
                    'pGameDb(pGameIndexSS(pGameIndexSS_Pos).GameDb_Ref).GameIndexSS_Ref = pGameIndexSS_Pos
                End If
                pSStatesList(SStatesList_Pos).GameIndexRef = GameIndexSS_Pos

                If pSStatesList(SStatesList_Pos).isBackup = False Then
                    pGameIndexSS(GameIndexSS_Pos).SStates_SizeTot = pGameIndexSS(GameIndexSS_Pos).SStates_SizeTot + pSStatesList(SStatesList_Pos).FileInfo.Length
                    pGameIndexSS(0).SStates_SizeTot = pGameIndexSS(0).SStates_SizeTot + pSStatesList(SStatesList_Pos).FileInfo.Length
                    pGameIndexSS(GameIndexSS_Pos).SStates_Count += 1
                    pGameIndexSS(0).SStates_Count += 1
                Else
                    pGameIndexSS(GameIndexSS_Pos).SStates_Bck_SizeTot = pGameIndexSS(GameIndexSS_Pos).SStates_Bck_SizeTot + pSStatesList(SStatesList_Pos).FileInfo.Length
                    pGameIndexSS(0).SStates_Bck_SizeTot = pGameIndexSS(0).SStates_Bck_SizeTot + pSStatesList(SStatesList_Pos).FileInfo.Length
                    pGameIndexSS(GameIndexSS_Pos).SStates_Bck_Count += 1
                    pGameIndexSS(0).SStates_Bck_Count += 1
                End If

            Next SStatesList_Pos

            pGameIndexSS(0).SStatesList_EndPos = pSStatesList.GetUpperBound(0)

            pGameIndexSS(GameIndexSS_Pos).SStatesList_EndPos = pSStatesList.GetUpperBound(0)

            ReDim Preserve pGameIndexSS(GameIndexSS_Pos)

            GameIndexSS_Load = ArrayStatus.ArrayLoadedOK
        Else
            GameIndexSS_Load = ArrayStatus.ArrayEmpty
        End If
    End Function

    Public Function GameIndexSS_Unload(ByRef pGameIndexSS() As mdlGamesIndexSS.rGamesIndexSStates, _
                                       Optional ByVal pRedimFactor As System.Int32 = -1 _
                                       ) As mdlMain.ArrayStatus
        'Clears the array
        '   ByRef   pGameIndexSS()          The dinamic array of the Index
        '   ByVal   pRedimFactor            Specifies if the array will be used after being cleared
        'Return Value: array status/lenght

        ReDim pGameIndexSS(pRedimFactor)
        Return ArrayStatus.ArrayEmpty
    End Function

End Module
