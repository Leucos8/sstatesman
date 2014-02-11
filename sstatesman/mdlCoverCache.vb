'   SStatesMan - a small frontend for PCSX2
'   Copyright (C) 2011-2014 - Leucos
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
    'Maximum number of cover that will be cache, after that the oldest cover will be discarded.
    Const maxCachedCover As Integer = 8
    'Maximum number of cover thumbnail that will be added to the result image
    Const maxThumbnail As Integer = 4
    '"Serial" used for when there is no cover file.
    Const noCoverSerial As String = "*nocover*"

    'Constant for the sizes of small cover and large cover.
    Friend ReadOnly CoverThumb_SizeLarge As New Size(256, 256)
    Friend ReadOnly CoverThumb_SizeSmall As New Size(48, 48)

    ''' <summary>Cover cache structure, two images object and a date.</summary>
    Friend Class sCoverInfo
        Friend CoverThumb_Large As Image    'Large cover image with maximum size defined in CoverThumb_SizeLarge.
        Friend CoverThumb_Small As Image    'Small cover image with maximum size defined in CoverThumb_SizeSmall.
        Friend LastHit As Date              'Last cache hit time.
    End Class
    ''' <summary>Dictionary of the cover cache.</summary>
    Friend CoverCache As New Dictionary(Of String, sCoverInfo)

    ''' <summary>Add a cover to the cache and checks if a cleanup of older covers is needed.</summary>
    ''' <param name="pSerial">Serial of the game to add.</param>
    ''' <param name="pCoverInfo">Cover to add to the cache.</param>
    Friend Sub CacheCover(ByVal pSerial As String, ByVal pCoverInfo As sCoverInfo)
        If Not (CoverCache.ContainsKey(pSerial)) Then
            CacheResize(maxCachedCover)
            CoverCache.Add(pSerial, pCoverInfo)
            SSMAppLog.Append(eType.LogInformation, eSrc.CoverCache, eSrcMethod.Cache_Add, String.Format("Cover for {0} cached ({1}/{2}).", pSerial, CoverCache.Count, mdlCoverCache.maxCachedCover))
        Else
            SSMAppLog.Append(eType.LogWarning, eSrc.CoverCache, eSrcMethod.Cache_Add, String.Format("Cover for {0} already cached, addition ignored.", pSerial))
        End If
    End Sub

    ''' <summary>Removes the oldest used cover from the cache when it reaches the maximum item count.</summary>
    ''' <param name="pMaxCachedCover">Maximum cached items allowed.</param>
    Friend Sub CacheResize(ByVal pMaxCachedCover As Long)
        If CoverCache.Count >= pMaxCachedCover Then
            Dim tmpSerial As String = ""
            Dim tmpDate As Date = Now
            For Each tmpCoverInfo As KeyValuePair(Of String, sCoverInfo) In CoverCache
                If tmpDate >= tmpCoverInfo.Value.LastHit Then
                    tmpSerial = tmpCoverInfo.Key
                End If
            Next
            If CoverCache.ContainsKey(tmpSerial) Then
                CoverCache.Remove(tmpSerial)
                SSMAppLog.Append(eType.LogInformation, eSrc.CoverCache, eSrcMethod.Cache_Resize, String.Format("Cover for {0} removed from cache.", tmpSerial))
            Else
                SSMAppLog.Append(eType.LogWarning, eSrc.CoverCache, eSrcMethod.Cache_Resize, String.Format("Cover for {0} not found in cache, removal ignored.", tmpSerial))
            End If
        End If
    End Sub

    ''' <summary>Clears the cover cache.</summary>
    Private Sub CacheClear()
        SSMAppLog.Append(eType.LogInformation, eSrc.CoverCache, eSrcMethod.Cache_Clear, String.Format("{0} items removed from cache.", CoverCache.Count))
        CoverCache.Clear()
    End Sub

    ''' <summary>Creates a collage Image from multiple files.</summary>
    ''' <param name="pSerial">List of serials.</param>
    ''' <param name="pPath">Folder containing the image files.</param>
    ''' <param name="pDestWidth">Width of the resulting image.</param>
    ''' <param name="pDestHeight">Height of the resulting image.</param>
    ''' <param name="pExpanded">Specifies if the height must be respected.</param>
    ''' <returns>Collage image from multiple files</returns>
    Friend Function FetchCover(ByVal pSerial As List(Of String), ByVal pPath As String, _
                               ByVal pDestWidth As Integer, ByVal pDestHeight As Integer, _
                               ByVal pExpanded As Boolean) As Image
        Dim sw As Stopwatch = Stopwatch.StartNew

        'Distance between the images
        Dim pStepWidth As Integer = pDestWidth \ (maxThumbnail * 2 - 1)
        'Adjusting maximum thumbnail number
        Dim tmpMaxThumbnail As Integer = maxThumbnail
        If pSerial.Count < maxThumbnail Then
            tmpMaxThumbnail = pSerial.Count
        End If

        'The drawing surface will be based on an empty image
        FetchCover = New Bitmap(pDestWidth, pDestHeight)
        'The image is referenced to a graphics object for editing
        Dim endCover As Graphics = Graphics.FromImage(FetchCover)


        For i As Integer = 0 To tmpMaxThumbnail - 1
            Try
                'The cover will be added to the graphic object using DrawImage
                Dim tmpCover As Image = FetchCover(pSerial(i), pPath, pExpanded)
                endCover.DrawImage(tmpCover, i * pStepWidth, 0, tmpCover.Width * pDestHeight \ tmpCover.Height, pDestHeight)
                'Adds a line for the current cover
                endCover.DrawLine(Pens.DimGray, i * pStepWidth - 1, 0, i * pStepWidth - 1, pDestHeight)
                'Adds a shade for the current cover
                Dim tmpShade As New Drawing2D.LinearGradientBrush(New Rectangle(i * pStepWidth - 4, 0, 6, pDestHeight), Color.Transparent, Color.Black, 0)
                endCover.FillRectangle(tmpShade, i * pStepWidth - 4, 0, 3, pDestHeight)
            Catch ex As Exception
                'No cover image found or file is corrupted
                SSMAppLog.Append(eType.LogError, eSrc.CoverCache, eSrcMethod.Cover_Fetch, "Multiple cover. " & ex.Message)
            End Try
        Next

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.CoverCache, eSrcMethod.Cover_Fetch, "Cover served for multiple games.", sw.ElapsedTicks)

        Return FetchCover
    End Function

    ''' <summary>Retrieves a cover image from the specified serial from the cache, if it's not in the cache the cover is loaded from file.</summary>
    ''' <param name="pSerial">The serial (name) used to get the image name.</param>
    ''' <param name="pPath">Folder containing the image file.</param>
    ''' <param name="pExpanded">Specifies if the height must be respected.</param>
    ''' <returns>Cover thumbnail</returns>
    ''' <remarks></remarks>
    Friend Function FetchCover(ByVal pSerial As String, ByVal pPath As String, ByVal pExpanded As Boolean) As Image
        Dim sw As Stopwatch = Stopwatch.StartNew

        Dim tmpImage As Image = New Bitmap(1, 1)

        If Not (CoverCache.ContainsKey(pSerial)) Then
            If pSerial.ToLower = "screenshots" Then
                tmpImage = My.Resources.Icon_Screenshot_256x192
            ElseIf SSMGameList.Games(pSerial).HasCoverFile(pPath, pSerial) Then
                Try
                    tmpImage = Image.FromFile(Path.Combine(pPath, mdlMain.TrimBadPathChars(pSerial) & ".jpg"))
                Catch ex As Exception
                    'No cover image found or file is corrupted
                    SSMAppLog.Append(eType.LogError, eSrc.CoverCache, eSrcMethod.Cover_Fetch, String.Format("Failed for game {0}: {1}", pSerial, ex.Message))
                    'If SSMGameList.Games.ContainsKey(pSerial) Then
                    '    SSMGameList.Games(pSerial).HasCoverFile = False
                    'End If
                    pSerial = noCoverSerial
                    If Not (CoverCache.ContainsKey(pSerial)) Then
                        tmpImage = My.Resources.Extra_Nocover_120x170
                    End If
                End Try
            Else
                pSerial = noCoverSerial
                If Not (CoverCache.ContainsKey(pSerial)) Then
                    tmpImage = My.Resources.Extra_Nocover_120x170
                End If
            End If
        End If

        If Not (CoverCache.ContainsKey(pSerial)) Then
            CacheCover(pSerial, New sCoverInfo With {.CoverThumb_Large = ResizeCover(tmpImage, CoverThumb_SizeLarge.Width, CoverThumb_SizeLarge.Height), _
                                                     .CoverThumb_Small = ResizeCover(tmpImage, CoverThumb_SizeSmall.Width, CoverThumb_SizeSmall.Height)})
        End If
        CoverCache(pSerial).LastHit = Now

        sw.Stop()
        SSMAppLog.Append(eType.LogInformation, eSrc.CoverCache, eSrcMethod.Cover_Fetch, String.Format("Cover for {0} served.", pSerial), sw.ElapsedTicks)

        If pExpanded Then
            Return CoverCache(pSerial).CoverThumb_Large
        Else
            Return CoverCache(pSerial).CoverThumb_Small
        End If
    End Function

    ''' <summary>Resize the input image using the specified parameters.</summary>
    ''' <param name="pInputImage"></param>
    ''' <param name="pThumbWidth">Width of the resulting image.</param>
    ''' <param name="pThumbHeight">Height of the resulting image.</param>
    ''' <returns>Cover thumbnail</returns>
    ''' <remarks></remarks>
    Friend Function ResizeCover(ByVal pInputImage As Image, _
                                ByVal pThumbWidth As Integer, pThumbHeight As Integer) As Image
        Try
            If (pInputImage.Height > pInputImage.Width) Then
                'If it's a vertical (tall) image then ThumbWidth will be computed
                pThumbWidth = pThumbHeight * pInputImage.Width \ pInputImage.Height
            Else
                'Else it's a wide image, then ThumbHeight will be considered as the maximum width applicable and thus ThumbHeight will be re-computed
                pThumbHeight = pThumbWidth * pInputImage.Height \ pInputImage.Width
            End If
            Dim tmpThumbnail As Image = New Bitmap(pInputImage.GetThumbnailImage(pThumbWidth, pThumbHeight, Nothing, Nothing))
            Return tmpThumbnail
        Catch ex As Exception
            'No cover image found or file is corrupted
            SSMAppLog.Append(eType.LogInformation, eSrc.CoverCache, eSrcMethod.Cover_Resize, ex.Message)
            Return My.Resources.Extra_Nocover_120x170
        End Try

    End Function

End Module
