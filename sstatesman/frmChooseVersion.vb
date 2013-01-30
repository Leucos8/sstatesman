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
Public Class frmChooseVersion
    Dim PCSX2exe_files As List(Of FileInfo)

    Private Sub PCSX2EXE_ListCreate(ByVal pPCSX2_PathBin As String)
        lbPCSX2exe.BeginUpdate()
        lbPCSX2exe.Items.Clear()
        If Directory.Exists(pPCSX2_PathBin) Then
            Dim tmpDirectory As New DirectoryInfo(My.Settings.PCSX2_PathBin)
            Dim PCSX2exe_files As FileInfo() = tmpDirectory.GetFiles("PCSX2*.exe")
            If PCSX2exe_files.Length > 0 Then
                For i = 0 To PCSX2exe_files.Length - 1
                    lbPCSX2exe.Items.Add(PCSX2exe_files(i).Name)
                Next
                Me.lbPCSX2exe.SetSelected(0, True)
                If PCSX2exe_files.Count = 1 Then
                    PCSX2EXE_start(pPCSX2_PathBin, Me.lbPCSX2exe.Text)
                    Me.Close()
                Else
                    Me.cmdOk.Enabled = True
                End If
            Else
                lbPCSX2exe.Items.Add("No PCSX2 executables found")
                Me.cmdOk.Enabled = False
            End If
        Else
            lbPCSX2exe.Items.Add("The specified path does not exist")
            Me.cmdOk.Enabled = False
        End If
        lbPCSX2exe.EndUpdate()
    End Sub

    Private Sub PCSX2EXE_start(ByVal pPCSX2_PathBin As String, ByVal pPCSX2_ExeName As String)
        Dim tmpPath As String = Path.Combine(pPCSX2_PathBin, pPCSX2_ExeName)
        If File.Exists(tmpPath) Then
            Diagnostics.Process.Start(tmpPath)
        Else
            MessageBox.Show("The specified executable does not exist. Please close this window and try again to refresh the list." & tmpPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub frmChooseVersion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.applyTheme()
        Me.PCSX2EXE_ListCreate(My.Settings.PCSX2_PathBin)
    End Sub

#Region "UI paint"
    Private Sub pnlWindowTitle_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles pnlWindowTitle.Paint
        Dim recToolbar As New Rectangle(CInt(8 * DPIxScale), 0, CInt(127 * DPIxScale) + 1, CInt(7 * DPIyScale) + 1)
        Dim linGrBrushToolbar As New Drawing2D.LinearGradientBrush(recToolbar, currentTheme.AccentColor, currentTheme.AccentColorDark, 0)
        e.Graphics.FillRectangle(linGrBrushToolbar, recToolbar)
        If (pnlWindowTitle.Height > 4 * CInt(DPIyScale) + 1) And (pnlWindowTitle.Width > 0) Then
            If My.Settings.SStatesMan_ThemeGradientEnabled Then
                recToolbar = New Rectangle(0, pnlWindowTitle.Height - CInt(4 * DPIyScale), pnlWindowTitle.Width, CInt(3 * DPIyScale) + 1)
                linGrBrushToolbar = New Drawing2D.LinearGradientBrush(recToolbar, Color.Transparent, Color.DarkGray, 90)
                recToolbar.Y += 1
                e.Graphics.FillRectangle(linGrBrushToolbar, recToolbar)
            End If
            e.Graphics.DrawLine(Pens.DimGray, 0, pnlWindowTitle.Height - 1, pnlWindowTitle.Width, pnlWindowTitle.Height - 1)
        End If
    End Sub

    Private Sub flpWindowBottom_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles flpWindowBottom.Paint
        If flpWindowBottom.Height > CInt(4 * DPIyScale) Then
            If My.Settings.SStatesMan_ThemeGradientEnabled Then
                Dim recToolbar As New Rectangle(0, 0, flpWindowBottom.Width + 1, CInt(3 * DPIyScale) + 1)
                Dim linGrBrushToolbar As New Drawing2D.LinearGradientBrush(recToolbar, Color.DarkGray, Color.Transparent, 90)
                e.Graphics.FillRectangle(linGrBrushToolbar, recToolbar)
            End If
            e.Graphics.DrawLine(Pens.DimGray, 0, 0, flpWindowBottom.Width, 0)
        End If
    End Sub

    Private Sub applyTheme()
        Me.BackColor = currentTheme.BgColor
        Me.pnlWindowTitle.BackColor = currentTheme.BgColorTop
        Me.flpWindowBottom.BackColor = currentTheme.BgColorBottom
        If My.Settings.SStatesMan_ThemeImageEnabled Then
            Me.pnlWindowTitle.BackgroundImage = currentTheme.BgImageTop
            Me.pnlWindowTitle.BackgroundImageLayout = currentTheme.BgImageTopStyle
            Me.flpWindowBottom.BackgroundImage = currentTheme.BgImageBottom
            Me.flpWindowBottom.BackgroundImageLayout = currentTheme.BgImageBottomStyle
        Else
            Me.pnlWindowTitle.BackgroundImage = Nothing
            Me.flpWindowBottom.BackgroundImage = Nothing
        End If
        Me.Refresh()
    End Sub
#End Region

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdOk_Click(sender As Object, e As EventArgs) Handles cmdOk.Click
        Me.PCSX2EXE_start(My.Settings.PCSX2_PathBin, Me.lbPCSX2exe.Text)
        Me.Close()
    End Sub
End Class