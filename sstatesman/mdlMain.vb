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
Module mdlMain
    Public PCSX2_BinPath As System.String = ""
    Public PCSX2_UserPath As System.String = ""

    Public Const FileGameDb As System.String = "GameIndex.dbf"

    Public Const PCSX2_SStateDir As System.String = "SStates\"
    Public Const SState_Ext As System.String = ".p2s"
    Public Const SState_ExtBackup As System.String = ".backup"
End Module
