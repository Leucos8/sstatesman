﻿'   SStatesMan - a savestate managing tool for PCSX2
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
Imports System.Drawing

Module mdlTheme
    Friend imlLvwCheckboxes As ImageList
    Friend imlLvwItemIcons As ImageList

    Friend Enum eTheme As Byte
        none = 0
        squares = 1
        noise = 2
        stripes_dark = 3
        stripes_light = 4
        brushedmetal = 5
        hexagons = 6
        PCSX2 = 11
    End Enum

    Friend Structure sTheme
        Friend AccentColor As Color
        Friend AccentColorLight As Color
        Friend AccentColorDark As Color
        Friend BgColor As Color
        Friend BgColorTop As Color
        Friend BgColorBottom As Color
        Friend BgImageTop As Image
        Friend BgImageTopStyle As ImageLayout
        Friend BgImageBottom As Image
        Friend BgImageBottomStyle As ImageLayout
    End Structure

    Public currentTheme As New sTheme With {.AccentColor = Color.FromArgb(255, 130, 150, 200), _
                                            .AccentColorLight = Color.WhiteSmoke, _
                                            .AccentColorDark = Color.FromArgb(255, 65, 74, 100), _
                                            .BgColor = Color.WhiteSmoke, _
                                            .BgColorTop = Color.Gainsboro, _
                                            .BgColorBottom = Color.Gainsboro, _
                                            .BgImageTop = My.Resources.BgSquares, _
                                            .BgImageTopStyle = ImageLayout.None, _
                                            .BgImageBottom = Nothing, _
                                            .BgImageBottomStyle = ImageLayout.None}

    Public Function LoadTheme(ByVal pTheme As eTheme) As sTheme

        'ImageList for custom checkboxes (listview statelist)
        imlLvwCheckboxes = New ImageList With {.ImageSize = New Size( _
                CInt((My.Resources.Checkbox_Unchecked_22x22.Width \ 2 - 1) * DPIxScale + 1), _
                CInt((My.Resources.Checkbox_Unchecked_22x22.Height \ 2 - 1) * DPIyScale) + 1)}
        imlLvwCheckboxes.Images.AddRange({My.Resources.Checkbox_Unchecked_22x22, _
                                          My.Resources.Checkbox_Checked_22x22})

        'List view items icons
        imlLvwItemIcons = New ImageList With {.ImageSize = New Size( _
                      CInt((My.Resources.Icon_Savestate_16x16.Width - 1) * DPIxScale) + 1, _
                      CInt((My.Resources.Icon_Savestate_16x16.Height - 1) * DPIyScale) + 1)}
        imlLvwItemIcons.Images.AddRange({My.Resources.Icon_Savestate_16x16, _
                                         My.Resources.Icon_SavestateBackup_16x16, _
                                         My.Resources.Icon_Screenshot_16x16, _
                                         My.Resources.InfoIcon_Information_16x16, _
                                         My.Resources.InfoIcon_Warning_16x16, _
                                         My.Resources.InfoIcon_Exclamation_16x16, _
                                         My.Resources.InfoIcon_Error_16x16})

        Select Case My.Settings.SStatesMan_Theme
            Case eTheme.squares
                With LoadTheme
                    .AccentColor = Color.FromArgb(255, 130, 150, 200)
                    .AccentColorLight = Color.FromArgb(215, 220, 255)
                    .AccentColorDark = Color.FromArgb(255, 65, 74, 100)
                    .BgColor = Color.WhiteSmoke
                    .BgColorTop = Color.Gainsboro
                    .BgColorBottom = Color.Gainsboro
                    .BgImageTop = My.Resources.BgSquares
                    .BgImageTopStyle = ImageLayout.None
                    .BgImageBottom = Nothing
                    .BgImageBottomStyle = ImageLayout.None
                End With
            Case eTheme.noise
                With LoadTheme
                    .AccentColor = Color.FromArgb(255, 130, 150, 200)
                    .AccentColorLight = Color.FromArgb(215, 220, 255)
                    .AccentColorDark = Color.FromArgb(255, 65, 74, 100)
                    .BgColor = Color.WhiteSmoke
                    .BgColorTop = Color.Gainsboro
                    .BgColorBottom = Color.Gainsboro
                    .BgImageTop = My.Resources.BgNoise
                    .BgImageTopStyle = ImageLayout.Tile
                    .BgImageBottom = My.Resources.BgNoise
                    .BgImageBottomStyle = ImageLayout.Tile
                End With
            Case eTheme.stripes_dark
                With LoadTheme
                    .AccentColor = Color.FromArgb(255, 130, 150, 200)
                    .AccentColorLight = Color.FromArgb(215, 220, 255)
                    .AccentColorDark = Color.FromArgb(255, 65, 74, 100)
                    .BgColor = Color.WhiteSmoke
                    .BgColorTop = Color.Gainsboro
                    .BgColorBottom = Color.Gainsboro
                    .BgImageTop = My.Resources.BgStripesDark
                    .BgImageTopStyle = ImageLayout.Tile
                    .BgImageBottom = My.Resources.BgStripesDark
                    .BgImageBottomStyle = ImageLayout.Tile
                End With
            Case eTheme.stripes_light
                With LoadTheme
                    .AccentColor = Color.FromArgb(255, 130, 150, 200)
                    .AccentColorLight = Color.FromArgb(215, 220, 255)
                    .AccentColorDark = Color.FromArgb(255, 65, 74, 100)
                    .BgColor = Color.WhiteSmoke
                    .BgColorTop = Color.Gainsboro
                    .BgColorBottom = Color.Gainsboro
                    .BgImageTop = My.Resources.BgStripesLight
                    .BgImageTopStyle = ImageLayout.Tile
                    .BgImageBottom = My.Resources.BgStripesLight
                    .BgImageBottomStyle = ImageLayout.Tile
                End With
            Case eTheme.brushedmetal
                With LoadTheme
                    .AccentColor = Color.FromArgb(255, 130, 150, 200)
                    .AccentColorLight = Color.FromArgb(215, 220, 255)
                    .AccentColorDark = Color.FromArgb(255, 65, 74, 100)
                    .BgColor = Color.WhiteSmoke
                    .BgColorTop = Color.Gainsboro
                    .BgColorBottom = Color.Gainsboro
                    .BgImageTop = My.Resources.BgMetalBrush
                    .BgImageTopStyle = ImageLayout.Tile
                    .BgImageBottom = My.Resources.BgMetalBrush
                    .BgImageBottomStyle = ImageLayout.Tile
                End With
            Case eTheme.hexagons
                With LoadTheme
                    .AccentColor = Color.FromArgb(255, 130, 150, 200)
                    .AccentColorLight = Color.FromArgb(215, 220, 255)
                    .AccentColorDark = Color.FromArgb(255, 65, 74, 100)
                    .BgColor = Color.WhiteSmoke
                    .BgColorTop = Color.Silver
                    .BgColorBottom = Color.Silver
                    .BgImageTop = My.Resources.BgHex
                    .BgImageTopStyle = ImageLayout.None
                    .BgImageBottom = Nothing
                    .BgImageBottomStyle = ImageLayout.None
                End With
            Case eTheme.PCSX2
                With LoadTheme
                    .AccentColor = Color.Gainsboro
                    .AccentColorLight = Color.WhiteSmoke
                    .AccentColorDark = Color.Silver
                    .BgColor = Color.WhiteSmoke
                    .BgColorTop = Color.FromArgb(&HFF82DDF8)
                    .BgColorBottom = Color.FromArgb(&HFF1EBAFB)
                    .BgImageTop = My.Resources.BgPCSX2
                    .BgImageTopStyle = ImageLayout.Stretch
                    .BgImageBottom = My.Resources.BgPCSX2
                    .BgImageBottomStyle = ImageLayout.Stretch
                End With
            Case Else
                My.Settings.SStatesMan_Theme = eTheme.squares
                With LoadTheme
                    .AccentColor = Color.FromArgb(255, 130, 150, 200)
                    .AccentColorLight = Color.WhiteSmoke
                    .AccentColorDark = Color.FromArgb(255, 65, 74, 100)
                    .BgColor = Color.WhiteSmoke
                    .BgColorTop = Color.Gainsboro
                    .BgColorBottom = Color.Gainsboro
                    .BgImageTop = My.Resources.BgSquares
                    .BgImageTopStyle = ImageLayout.None
                    .BgImageBottom = Nothing
                    .BgImageBottomStyle = ImageLayout.None
                End With
        End Select
    End Function

    Public Sub ListAlternateColors(ByRef pListView As ListView)
        If pListView IsNot Nothing Then
            Dim colorswitch As Boolean = True
            For i As Integer = 0 To pListView.Items.Count - 1
                If Not pListView.Items(i).BackColor = Color.Transparent Then
                    If colorswitch Then
                        pListView.Items(i).BackColor = Color.Transparent
                    Else
                        pListView.Items(i).BackColor = Color.Gainsboro
                    End If
                End If
                colorswitch = Not colorswitch
            Next
        End If
    End Sub
End Module
