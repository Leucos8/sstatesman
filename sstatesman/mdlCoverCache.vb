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

Module mdlCoverCache

    'Default sizes for the cover image
    Friend ReadOnly imgCover_SizeReduced As New Size(32, 46)
    Friend ReadOnly imgCover_SizeExpanded As New Size(120, 170)
    'Cover image collection
    Friend Structure sCoverInfo
        Friend CacheTime As Date
        Friend CoverLarge As Image
        Friend CoverSmall As Image
    End Structure
    Friend CoverInfoCache As New Dictionary(Of String, sCoverInfo)

    ''' <summary>
    ''' Creates a collage Image from multiple files
    ''' </summary>
    ''' <param name="pSerial">List of serials.</param>
    ''' <param name="pPath">Folder containing the image files.</param>
    ''' <param name="pDestWidth">Width of the resulting image.</param>
    ''' <param name="pDestHeight">Height of the resulting image.</param>
    ''' <returns>Collage image from multiple files</returns>
    Friend Function Cover_Get(ByVal pSerial As List(Of String), ByVal pPath As String, _
                              ByVal pDestWidth As Integer, ByVal pDestHeight As Integer) As Image

        'Maximum number of cover thumbnail that will be added to the result image
        Dim maxThumbnail As Integer = 4
        'Distance between the images
        Dim pStepWidth As Integer = pDestWidth \ 7
        'Adjusting maximum thumbnail number
        If pSerial.Count < maxThumbnail Then
            maxThumbnail = pSerial.Count
        End If

        'The drawing surface will be based on an empty image
        Cover_Get = New Bitmap(pDestHeight, pDestHeight)
        'The image is referenced to a graphics object for editing
        Dim endCover As Graphics = Graphics.FromImage(Cover_Get)


        For i As Integer = 0 To maxThumbnail - 1
            Try
                'The cover will be added to the graphic object using DrawImage
                endCover.DrawImage(Cover_Get(pSerial(i), pPath, 0, pDestHeight, True), i * pStepWidth, 0)
                'Adds a line for the next cover
                endCover.DrawLine(Pens.DimGray, i * pStepWidth - 1, 0, i * pStepWidth - 1, pDestHeight)
                'Adds a shade for the next cover
                Dim tmpShade As New Drawing2D.LinearGradientBrush(New Rectangle(i * pStepWidth - 4, 0, 6, pDestHeight), Color.Transparent, Color.Black, 0)
                endCover.FillRectangle(tmpShade, i * pStepWidth - 4, 0, 3, pDestHeight)
            Catch ex As Exception
                'No cover image found or file is corrupted
                SSMAppLog.Append("Cover", "MultipleCover", String.Concat("Error: ", ex.Message))
            End Try
        Next
        'The graphics object update the image object
        endCover.DrawImage(Cover_Get, pDestWidth, pDestHeight)
        Return Cover_Get
    End Function

    ''' <summary>
    ''' Retrieves a cover image from the specified serial and resize it.
    ''' </summary>
    ''' <param name="pSerial">The serial (name) used to get the image name.</param>
    ''' <param name="pPath">Folder containing the image file.</param>
    ''' <param name="pThumbWidth">Width of the resulting image.</param>
    ''' <param name="pThumbHeight">Height of the resulting image.</param>
    ''' <param name="pForced">Specifies if the height must be respected.</param>
    ''' <returns>Cover thumbnail</returns>
    ''' <remarks></remarks>
    Friend Function Cover_Get(ByVal pSerial As String, ByVal pPath As String, _
                              ByRef pThumbWidth As Integer, ByRef pThumbHeight As Integer, _
                              Optional ByVal pForced As Boolean = False) As Image
        If pSerial.ToLower = "screenshots" Then
            Return Cover_Resize(My.Resources.Icon_Screenshot_256x192, pThumbWidth, pThumbHeight, pForced)
        Else
            If SSMGameList.Games(pSerial).HasCoverFile Then
                Try
                    If Not (CoverInfoCache.ContainsKey(pSerial)) Then
                        Dim tmpImage As Image = Image.FromFile(Path.Combine(pPath, pSerial & ".jpg"))
                        CoverInfoCache.Add(pSerial, New sCoverInfo With {.CoverLarge = Cover_Resize(tmpImage, pThumbWidth, pThumbHeight, pForced), .CacheTime = Now})
                    End If
                    Return CoverInfoCache(pSerial).CoverLarge
                Catch ex As Exception
                    'No cover image found or file is corrupted
                    SSMAppLog.Append("Cover", "GetCover", String.Concat("Error: ", ex.Message))
                    Return Cover_Resize(My.Resources.Extra_Nocover_120x170, pThumbWidth, pThumbHeight, pForced)
                End Try
            Else
                Return Cover_Resize(My.Resources.Extra_Nocover_120x170, pThumbWidth, pThumbHeight, pForced)
            End If
        End If
    End Function

    ''' <summary>
    ''' Resize the input image using the specified parameters.
    ''' </summary>
    ''' <param name="pInputImage"></param>
    ''' <param name="pThumbWidth">Width of the resulting image.</param>
    ''' <param name="pThumbHeight">Height of the resulting image.</param>
    ''' <param name="pForced">Specifies if the height must be respected.</param>
    ''' <returns>Cover thumbnail</returns>
    ''' <remarks></remarks>
    Friend Function Cover_Resize(ByVal pInputImage As Image, _
                                 ByRef pThumbWidth As Integer, ByRef pThumbHeight As Integer, _
                                 Optional ByVal pForced As Boolean = False) As Image
        Try
            If pThumbWidth = 0 Then
                'ThumbWidth must be computed
                If (pInputImage.Height > pInputImage.Width) Or pForced Then
                    'If it's a vertical (tall) image or ThumbHeight must be respected (HeightEnforced = true) then ThumbWidth will be computed
                    pThumbWidth = pThumbHeight * pInputImage.Width \ pInputImage.Height
                Else
                    'Else it's a wide image, then ThumbHeight will be considered as the maximum width applicable and thus ThumbHeight will be re-computed
                    pThumbWidth = pThumbHeight
                    pThumbHeight = pThumbWidth * pInputImage.Height \ pInputImage.Width
                End If
            ElseIf pThumbHeight = 0 Then
                'ThumbHeight must be computed
                pThumbHeight = pThumbWidth * pInputImage.Height \ pInputImage.Width
            Else
                pThumbWidth = 16
                pThumbHeight = 16
            End If
            Dim tmpThumbnail As Image = New Bitmap(pInputImage.GetThumbnailImage(pThumbWidth, pThumbHeight, Nothing, Nothing))
            Return tmpThumbnail
        Catch ex As Exception
            'No cover image found or file is corrupted
            SSMAppLog.Append("Main window", "ResizeCover", String.Concat("Error: ", ex.Message))
            Return My.Resources.Extra_Nocover_120x170
        End Try

    End Function

End Module
