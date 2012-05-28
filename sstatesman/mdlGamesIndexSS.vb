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
        Friend GameInfo As rGameDb                  'Game information from the GameDb array
        Friend SStatesList_StartPos As System.Int32 'Start position in SStatesList() of the records of this game
        Friend SStatesList_EndPos As System.Int32   'End position in SStatesList() of the record of this game
        Friend SStates_Count As System.Int32
        Friend SStates_Bck_Count As System.Int32
        Friend SStates_SizeTot As System.UInt64     'Total size in bytes of the savestate files
        Friend SStates_Bck_SizeTot As System.UInt64 'Total size in bytes of the savestate backup files
    End Structure
    Public GamesIndexSS() As rGamesIndexSStates     'Array with the games with found savestates
    Public GamesIndexSS_Pos As System.Int32 = 0     'Position index of the array
    Public GamesIndexSS_Len As System.Int32 = 0     'Occupied records of the array
    Public Const GamesIndexSS_ReDimFactor As System.Int32 = 16

    Public Function GameIndexSS_Load(ByRef pSStatesList() As mdlSStatesList.rSStatesList, _
                                     ByVal pSStatesList_Pos As System.Int32, _
                                     ByVal pSStatesList_Len As System.Int32, _
                                     ByRef pGameDb() As mdlGameDb.rGameDb, _
                                     ByRef pGameDb_Pos As System.Int32, _
                                     ByVal pGameDb_Len As System.Int32, _
                                     ByRef pGameIndexSS() As mdlGamesIndexSS.rGamesIndexSStates, _
                                     ByRef pGameIndexSS_Pos As System.Int32 _
                                     ) As System.Int32
        If pSStatesList_Len > 0 Then
            pGameIndexSS_Pos = mdlGamesIndexSS.GameIndexSS_Unload(pGameIndexSS, pGameIndexSS_Pos, GamesIndexSS_ReDimFactor) 'Clears the array
            pGameIndexSS_Pos = 0        'Position 0
            pGameIndexSS(0).GameInfo.Serial = "*"
            pGameIndexSS(0).GameInfo.Name = "(all games)"
            pGameIndexSS(0).GameInfo.Region = "*"
            pGameIndexSS(0).GameInfo.Compat = "0"
            pGameIndexSS(0).GameInfo.RStatus = 0
            pGameIndexSS(0).SStatesList_StartPos = 0
            pGameIndexSS(0).SStatesList_EndPos = pSStatesList_Len

            For pSStatesList_Pos = 0 To pSStatesList_Len
                If Not (pGameIndexSS(pGameIndexSS_Pos).GameInfo.Serial Like pSStatesList(pSStatesList_Pos).SStateSerial) Then
                    pGameIndexSS(pGameIndexSS_Pos).SStatesList_EndPos = pSStatesList_Pos - 1

                    If (pGameIndexSS.GetUpperBound(0) - pGameIndexSS_Pos) <= 2 Then 'Resize the array when needed
                        ReDim Preserve pGameIndexSS(pGameIndexSS.GetUpperBound(0) + GamesIndexSS_ReDimFactor)
                    End If

                    pGameIndexSS_Pos += 1

                    pGameIndexSS(pGameIndexSS_Pos).SStatesList_StartPos = pSStatesList_Pos

                    pGameIndexSS(pGameIndexSS_Pos).GameInfo = mdlGameDb.GameDb_ExtractBySerial(pSStatesList(pSStatesList_Pos).SStateSerial, _
                                                                                       pGameDb, pGameDb_Pos, pGameDb_Len)

                    pGameIndexSS(pGameIndexSS_Pos).SStates_Count = 0
                    pGameIndexSS(pGameIndexSS_Pos).SStates_Bck_Count = 0
                    pGameIndexSS(pGameIndexSS_Pos).SStates_SizeTot = 0
                    pGameIndexSS(pGameIndexSS_Pos).SStates_Bck_SizeTot = 0

                End If
                pSStatesList(pSStatesList_Pos).GameIndexRef = pGameIndexSS_Pos

                If pSStatesList(pSStatesList_Pos).isBackup = False Then
                    pGameIndexSS(pGameIndexSS_Pos).SStates_SizeTot = pGameIndexSS(pGameIndexSS_Pos).SStates_SizeTot + pSStatesList(pSStatesList_Pos).FileInfo.Length
                    pGameIndexSS(0).SStates_SizeTot = pGameIndexSS(0).SStates_SizeTot + pSStatesList(pSStatesList_Pos).FileInfo.Length
                    pGameIndexSS(pGameIndexSS_Pos).SStates_Count += 1
                    pGameIndexSS(0).SStates_Count += 1
                Else
                    pGameIndexSS(pGameIndexSS_Pos).SStates_Bck_SizeTot = pGameIndexSS(pGameIndexSS_Pos).SStates_Bck_SizeTot + pSStatesList(pSStatesList_Pos).FileInfo.Length
                    pGameIndexSS(0).SStates_Bck_SizeTot = pGameIndexSS(0).SStates_Bck_SizeTot + pSStatesList(pSStatesList_Pos).FileInfo.Length
                    pGameIndexSS(pGameIndexSS_Pos).SStates_Bck_Count += 1
                    pGameIndexSS(0).SStates_Bck_Count += 1
                End If

            Next pSStatesList_Pos

            pGameIndexSS(0).SStatesList_EndPos = pSStatesList_Len

            pGameIndexSS(pGameIndexSS_Pos).SStatesList_EndPos = pSStatesList_Len

            ReDim Preserve pGameIndexSS(pGameIndexSS_Pos)
            GameIndexSS_Load = pGameIndexSS_Pos
        Else
            GameIndexSS_Load = 0

        End If
    End Function

    Public Function GameIndexSS_Unload(ByRef pGameIndexSS() As mdlGamesIndexSS.rGamesIndexSStates, _
                                       ByRef pGameIndexSS_Pos As System.Int32 _
                                       ) As System.Int32
        'Clears the array
        '   ByRef   pGameIndexSS()          The dinamic array of the Index
        '   ByRef   GameIndexSS_Pos         Index used in the array
        '   ByRef   pWillBeUsed             Specifies if the array will be used after being cleared
        'Return Value: array status/lenght

        ReDim pGameIndexSS(-1)
        pGameIndexSS_Pos = -1                    'Array position index starts to 0
        Return pGameIndexSS_Pos
    End Function

    Public Function GameIndexSS_Unload(ByRef pGameIndexSS() As mdlGamesIndexSS.rGamesIndexSStates, _
                                       ByRef pGameIndexSS_Pos As System.Int32, _
                                       ByVal pRedimFactor As System.Int32 _
                                       ) As System.Int32
        'Clears the array
        '   ByRef   pGameIndexSS()          The dinamic array of the Index
        '   ByRef   GameIndexSS_Pos         Index used in the array
        '   ByVal   pRedimFactor            Specifies if the array will be used after being cleared
        'Return Value: array status/lenght

        ReDim pGameIndexSS(pRedimFactor)
        pGameIndexSS_Pos = -1                    'Array position index starts to 0
        Return pGameIndexSS_Pos
    End Function

End Module
