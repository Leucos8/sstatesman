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
Public NotInheritable Class frmAbout

#Region "Form"
    Private Sub frmAbout_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.pnlWindowTop.Controls.Add(Me.flpTab)
        Me.flpTab.Dock = DockStyle.Bottom
        Me.flpWindowBottom.Controls.Add(Me.OKButton)

        Me.lblVersionMain.Text = My.Application.Info.Version.ToString
        Me.lblVersionChannel.Text = My.Settings.SStatesMan_Channel

        Me.llbAuthor.Text = My.Application.Info.CompanyName
        Me.lblCopyright.Text = My.Application.Info.Copyright

        Me.pnlTab0.Dock = DockStyle.Fill
        Me.pnlTab1.Dock = DockStyle.Fill
        Me.pnlTab2.Dock = DockStyle.Fill

        Me.pnlTab0.Visible = Me.optTabHeader0.Checked
        Me.pnlTab1.Visible = Me.optTabHeader1.Checked
        Me.pnlTab2.Visible = Me.optTabHeader2.Checked

    End Sub

    Private Sub llbAuthor_LinkClicked(sender As Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llbAuthor.LinkClicked
        System.Diagnostics.Process.Start("http://forums.pcsx2.net/User-Leucos")
    End Sub

    Private Sub llbPCSX2Forum_LinkClicked(sender As Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llbPCSX2Forum.LinkClicked
        System.Diagnostics.Process.Start("http://forums.pcsx2.net/Thread-SStatesMan-a-savestates-managing-tool-for-PCSX2")
    End Sub

    Private Sub llbPCSX2net_LinkClicked(sender As Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llbPCSX2net.LinkClicked
        System.Diagnostics.Process.Start("http://pcsx2.net/download/viewcategory/43-frontends.html")
    End Sub
#End Region

#Region "Form - Tabs"
    'This common event is fired AFTER the other specific events.
    Private Sub optTabHeader_CheckedChanged(sender As Object, e As EventArgs) Handles optTabHeader0.CheckedChanged, optTabHeader1.CheckedChanged, optTabHeader2.CheckedChanged
        'CheckedChanged event is fired during initialization, the IsHandleCreated property check allows to know 
        'whether the control is shown (form is loaded and every object has an handle) or not (an handle is not yet assigned).
        If CType(sender, RadioButton).IsHandleCreated Then
            If CType(sender, RadioButton).Checked Then
                Me.optTabHeader0.FlatAppearance.MouseDownBackColor = Color.White
                Me.optTabHeader1.FlatAppearance.MouseDownBackColor = Color.White
                Me.optTabHeader2.FlatAppearance.MouseDownBackColor = Color.White
                CType(sender, RadioButton).FlatAppearance.MouseDownBackColor = Color.WhiteSmoke

                Me.pnlTab0.Visible = Me.optTabHeader0.Checked
                Me.pnlTab1.Visible = Me.optTabHeader1.Checked
                Me.pnlTab2.Visible = Me.optTabHeader2.Checked

            End If
        End If
    End Sub
#End Region

#Region "UI paint"
    Private Sub optTabHeader_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles optTabHeader0.Paint, optTabHeader1.Paint, optTabHeader2.Paint
        If CType(sender, RadioButton).Checked Then
            e.Graphics.DrawLine(Pens.DimGray, 0, 0, CType(sender, RadioButton).Width, 0)
            e.Graphics.DrawLine(Pens.DimGray, 0, 0, 0, CType(sender, RadioButton).Height)
            e.Graphics.DrawLine(Pens.DimGray, CType(sender, RadioButton).Width - 1, 0, CType(sender, RadioButton).Width - 1, CType(sender, RadioButton).Height)
        End If
    End Sub

#End Region

End Class
