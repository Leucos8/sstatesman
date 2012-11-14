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
Imports System.IO
Public Class frmChooseVersion


    Private Sub PCSX2EXE_list()
        ListBox1.BeginUpdate()
        ListBox1.Items.Clear()
        If Directory.Exists(My.Settings.PCSX2_PathBin) Then
            Dim tmpDirectory As New DirectoryInfo(My.Settings.PCSX2_PathBin)
            Dim PCSX2_files As FileInfo() = tmpDirectory.GetFiles("PCSX2*.exe")
            If PCSX2_files.Length > 0 Then
                For i = 0 To PCSX2_files.Length - 1
                    ListBox1.Items.Add(PCSX2_files(i).Name)
                Next
                Me.ListBox1.SetSelected(0, True)
                If PCSX2_files.Length = 1 Then
                    Me.OKButton_Click(Nothing, Nothing)
                End If
            Else
                ListBox1.Items.Add("No PCSX2 executables found")
                Me.OKButton.Enabled = False
            End If
        Else
            ListBox1.Items.Add("The specified path does not exist")
            Me.OKButton.Enabled = False
        End If
        ListBox1.EndUpdate()
    End Sub

    Private Sub frmChooseVersion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.applyTheme()
        Me.PCSX2EXE_list()
    End Sub

#Region "UI paint"
    Private Sub panelWindowTitle_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles panelWindowTitle.Paint
        Dim recToolbar As New Rectangle(CInt(8 * DPIxScale), 0, CInt(127 * DPIxScale) + 1, CInt(7 * DPIyScale) + 1)
        Dim linGrBrushToolbar As New Drawing2D.LinearGradientBrush(recToolbar, currentTheme.AccentColor, currentTheme.AccentColorDark, 0)
        e.Graphics.FillRectangle(linGrBrushToolbar, recToolbar)
        If (panelWindowTitle.Height > 4 * CInt(DPIyScale) + 1) And (panelWindowTitle.Width > 0) Then
            If My.Settings.SStatesMan_ThemeGradientEnabled Then
                recToolbar = New Rectangle(0, panelWindowTitle.Height - CInt(4 * DPIyScale), panelWindowTitle.Width, CInt(3 * DPIyScale) + 1)
                linGrBrushToolbar = New Drawing2D.LinearGradientBrush(recToolbar, Color.Transparent, Color.DarkGray, 90)
                recToolbar.Y += 1
                e.Graphics.FillRectangle(linGrBrushToolbar, recToolbar)
            End If
            e.Graphics.DrawLine(Pens.DimGray, 0, panelWindowTitle.Height - 1, panelWindowTitle.Width, panelWindowTitle.Height - 1)
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
        Me.panelWindowTitle.BackColor = currentTheme.BgColorTop
        Me.flpWindowBottom.BackColor = currentTheme.BgColorBottom
        If My.Settings.SStatesMan_ThemeImageEnabled Then
            Me.panelWindowTitle.BackgroundImage = currentTheme.BgImageTop
            Me.panelWindowTitle.BackgroundImageLayout = currentTheme.BgImageTopStyle
            Me.flpWindowBottom.BackgroundImage = currentTheme.BgImageBottom
            Me.flpWindowBottom.BackgroundImageLayout = currentTheme.BgImageBottomStyle
        Else
            Me.panelWindowTitle.BackgroundImage = Nothing
            Me.flpWindowBottom.BackgroundImage = Nothing
        End If
        Me.Refresh()
    End Sub
#End Region

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles OKButton.Click
        Dim tmpPath As String = Path.Combine(My.Settings.PCSX2_PathBin, Me.ListBox1.Text)
        If File.Exists(tmpPath) Then
            Diagnostics.Process.Start(tmpPath)
            Me.Close()
        Else
            MessageBox.Show("The file specified does not exist. " & tmpPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub PCSX2EXE_scan()
        Throw New NotImplementedException
    End Sub

End Class