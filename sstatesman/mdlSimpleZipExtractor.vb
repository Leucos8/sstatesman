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
Module mdlSimpleZipExtractor
#Region "ZipHeader"
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


    Public Function ExtractFirstFile(ByVal pFile As System.IO.FileInfo) As String
        Dim ZipH_Sign() As Byte = {80, 75, 3, 4}        '0x04034b50   Signature at the start of a Zip File
        Dim ZipH_ComprSize As UInteger = 0              'Compressed size of the first file
        'Private ZipH_UncomSize As UInteger = 0         'Uncomrpessed size of the first file
        Dim ZipH_FileNameLength As UInteger = 0         'Lenght of the name of the compressed file
        'Private ZipH_ExtraFieldLegth As UInteger = 0
        Dim ZipH_Filename As String = ""                'String name of the first file

        Try

            If pFile.Length > 60 Then
                '60 is the minimun lenght that of a file that contains only the savestate version information
                Using FileReader As System.IO.FileStream = pFile.OpenRead
                    Dim myChars(29) As Byte
                    FileReader.Read(myChars, FileReader.Position, ZipH_Sign_Len)
                    'Check if the signature is present
                    Dim Equal As Boolean = True
                    For i As Byte = 0 To 3
                        If Not (ZipH_Sign(i).Equals(myChars(i))) Then
                            Equal = False
                            Exit For
                        End If
                    Next
                    If Equal = True Then
                        'We've got a zip! Maybe...
                        FileReader.Seek(4, IO.SeekOrigin.Current)
                        'advance  4 bytes to skip Version and General Flag
                        'FileReader.Seek(ZipH_Version_Len + ZipH_GenFlag_Len, IO.SeekOrigin.Current)
                        FileReader.Read(myChars, FileReader.Position, ZipH_ComprMethod_Len)
                        'check for the compression method
                        If myChars(8) = 0 And myChars(9) = 0 Then
                            'compressionmethod = 0 is "Store", so no compression
                            FileReader.Seek(8, IO.SeekOrigin.Current)
                            'advance 8 byte to skip date and time information
                            FileReader.Read(myChars, FileReader.Position, 10)
                            'reads compressed and uncompressed size
                            ZipH_ComprSize = UInteger.Parse(String.Concat(myChars(21).ToString("x2"),
                                                                          myChars(20).ToString("x2"),
                                                                          myChars(19).ToString("x2"),
                                                                          myChars(18).ToString("x2")
                                                                          ), System.Globalization.NumberStyles.HexNumber)
                            'reads filename lenght
                            ZipH_FileNameLength = UInteger.Parse(String.Concat(myChars(27).ToString("x2"),
                                                                               myChars(26).ToString("x2")
                                                                               ), System.Globalization.NumberStyles.HexNumber)
                            FileReader.Seek(2, IO.SeekOrigin.Current)
                            'advance 2 bytes to skip extra field lenght
                            'reads filename
                            Dim myFilename(ZipH_FileNameLength - 1) As Byte
                            FileReader.Read(myFilename, 0, ZipH_FileNameLength)
                            'convert filename to a meaningful string
                            For i As UInteger = 0 To ZipH_FileNameLength - 1
                                ZipH_Filename = String.Concat(ZipH_Filename, ChrW(myFilename(i)))
                            Next
                            'check if it is the correct file
                            If ZipH_Filename = "PCSX2 Savestate Version.id" Then
                                Dim myContent(ZipH_ComprSize - 1) As Byte
                                FileReader.Read(myContent, 0, ZipH_ComprSize)
                                'reads the content of the file
                                Dim myString As String = ""
                                'Converts the content to a meaningful string
                                For i As UInteger = 0 To ZipH_ComprSize - 1
                                    myString = String.Concat(myContent(i).ToString("x2"), myString)
                                Next
                                ExtractFirstFile = ""
                                ExtractFirstFile = String.Concat("0x", myString)
                            Else : ExtractFirstFile = "Version file not found!"
                            End If

                        Else : ExtractFirstFile = "Unsupported compression method!"
                        End If
                    Else : ExtractFirstFile = "Signature not found. Not a valid zip file!"
                    End If

                End Using
            Else : ExtractFirstFile = "This file might be truncated"
            End If
        Catch ex As Exception
            ExtractFirstFile = ex.Message
        End Try
    End Function

End Module
