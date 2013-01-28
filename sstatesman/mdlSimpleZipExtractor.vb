'   SStatesMan - a savestate managing tool for PCSX2
'   Copyright (C) 2011-2013 - Leucos
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

Module mdlSimpleZipExtractor
#Region "ZipHeader"
    Private Const ZipH_Sign_Const As Integer = &H4034B50          'Signature at the start of a Zip File
    Private Const ZipH_Sign_Len As Byte = 4                 ' 0
    Private Const ZipH_Version_Len As Byte = 2              ' 4
    Private Const ZipH_GenFlag_Len As Byte = 2              ' 6
    Private Const ZipH_ComprMethod_Len As Byte = 2          ' 8
    Private Const ZipH_LastModTime_Len As Byte = 2          '10
    Private Const ZipH_LastModDate_Len As Byte = 2          '12
    Private Const ZipH_crc32_Len As Byte = 4                '14
    Private Const ZipH_ComprSize_Len As Byte = 4            '18
    Private Const ZipH_UncomSize_Len As Byte = 4            '22
    Private Const ZipH_FilenameLength_Len As Byte = 2       '26
    Private Const ZipH_ExtraFieldLength_Len As Byte = 2     '28
    '                                                        30
#End Region


    Public Function ExtractFirstFile(ByVal pFile As FileInfo) As String

        Dim ZipH_Sign As Integer = 0                        '0x04034b50   Signature at the start of a Zip File
        Dim ZipH_ComprSize As Integer = 0                   'Compressed size of the first file
        'Dim ZipH_ComprMethod As Short = 0S                 'Compression method flag
        'Private ZipH_UncomSize As Integer = 0              'Uncomrpessed size of the first file
        Dim ZipH_FileNameLength As Short = 0S               'Length of the name of the compressed file
        'Private ZipH_ExtraFieldLength As Integer = 0
        Dim ZipH_Filename As String = ""                    'String name of the first file

        Try

            If pFile.Length > 60 Then
                '60 bytes is the minimun Length that of a file that contains only the savestate version information
                Using FileReader As FileStream = pFile.OpenRead()
                    Dim ZipHeader(29) As Byte
                    FileReader.Read(ZipHeader, CInt(FileReader.Position), ZipH_Sign_Len)
                    'Check if the signature is present
                    'ZipH_Sign = BitConverter.ToInt32(ZipHeader, 0)
                    ZipH_Sign = CInt(ZipHeader(0)) Or (CInt(ZipHeader(1)) << 8) Or (CInt(ZipHeader(2)) << 16) Or (CInt(ZipHeader(3)) << 24)

                    If ZipH_Sign_Const = ZipH_Sign Then
                        'We've got a zip! Maybe...
                        FileReader.Read(ZipHeader, CInt(FileReader.Position), 26)
                        'check for the compression method
                        If (CShort(ZipHeader(8)) Or (CShort(ZipHeader(9)) << 8)) = 0S Then
                            'If BitConverter.ToInt16(ZipHeader, 8) = 0 Then
                            'If (ZipHeader(8) Or ZipHeader(9) * 256) = 0 Then
                            'compressionmethod = 0 is "Store", so no compression

                            'ZipH_ComprSize = BitConverter.ToInt32(ZipHeader, 18)
                            ZipH_ComprSize = CInt(ZipHeader(18)) Or (CInt(ZipHeader(19)) << 8) Or (CInt(ZipHeader(20)) << 16) Or (CInt(ZipHeader(21)) << 24)

                            'reads filename Length
                            ZipH_FileNameLength = (CShort(ZipHeader(26)) Or (CShort(ZipHeader(27)) << 8))

                            'reads filename
                            Dim myFilename(ZipH_FileNameLength - 1) As Byte
                            FileReader.Read(myFilename, 0, ZipH_FileNameLength)
                            'convert filename to a meaningful string
                            For i As Integer = 0 To ZipH_FileNameLength - 1
                                ZipH_Filename &= Convert.ToChar(myFilename(i))
                            Next
                            'check if it is the correct file
                            If ZipH_Filename = "PCSX2 Savestate Version.id" Then
                                Dim ZipContent(ZipH_ComprSize - 1) As Byte
                                'reads the content of the file
                                FileReader.Read(ZipContent, 0, ZipH_ComprSize)
                                'converts the content to a meaningful string
                                Dim tmpContent As Integer = ZipContent(0)
                                For i As Integer = 1 To ZipH_ComprSize - 1
                                    tmpContent = tmpContent Or (CInt(ZipContent(i)) << 8 * i)
                                Next
                                Return "0x" & tmpContent.ToString("x")
                            Else
                                Return "Version file not found!"
                            End If

                        Else
                            Return "Unsupported compression method!"
                        End If
                    Else
                        Return "PK signature not found. Not a valid zip file!"
                    End If

                End Using
            Else
                Return "This file might be truncated or corrupted."
            End If
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

End Module