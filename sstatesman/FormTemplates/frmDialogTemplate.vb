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
Public Class frmDialogTemplate

#Region "Form"

#End Region

#Region "Theme"
    Protected Friend Overrides Sub ApplyThemeAccent(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles pnlWindowTop.Paint
        Dim tmpRect As New Rectangle(Me.flpTitleBar.Padding.Left, 0, _
                                     CInt(159 * DPIxScale) + 1, Me.flpTitleBar.Padding.Top)
        Dim tmpSBrush As New SolidBrush(currentTheme.AccentColor)
        e.Graphics.FillRectangle(tmpSBrush, tmpRect)
    End Sub
#End Region

End Class
