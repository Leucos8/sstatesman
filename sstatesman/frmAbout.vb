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
Public NotInheritable Class frmAbout

    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Imposta il titolo del form.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("About {0}", ApplicationTitle)
        ' Inizializza tutto il testo visualizzato nella finestra di dialogo Informazioni su.
        ' TODO: Personalizzare le informazioni sull'assembly dell'applicazione nel riquadro "Applicazione" 
        '    della finestra delle proprietà del progetto (accessibile dal menu "Progetto").
        'Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format("Version {0} {1}", My.Application.Info.Version.ToString, My.Settings.SStateMan_Channel)
        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.LabelCompanyName.Text = My.Application.Info.CompanyName
        'Me.TextBoxDescription.Text = My.Application.Info.Description
    End Sub

    Private Sub frmSettings_About(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        If My.Settings.SStateMan_BGEnable Then
            Dim linGrBrush As New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, 0), New Point(0, 150), Color.Gainsboro, Color.White)
            Dim linGrBrush2 As New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, Me.ClientSize.Height - 150), New Point(0, Me.ClientSize.Height), Color.White, Color.Gainsboro)
            Dim linGrBrush3 As New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, Me.panelWindowTitle.Height), New Point(0, Me.panelWindowTitle.Height + 12), Color.Gainsboro, Color.Transparent)
            Dim linGrBrush4 As New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, Me.ClientSize.Height - 46), New Point(0, Me.ClientSize.Height - 34), Color.LightGray, Color.Transparent)
            'Dim linGrBrush5 As New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, Me.SplitContainer1.Location.Y + Me.SplitContainer1.SplitterDistance), New Point(0, SplitContainer1.Location.Y + Me.SplitContainer1.SplitterDistance + 12), Color.Gainsboro, Color.Transparent)

            e.Graphics.FillRectangle(linGrBrush, 0, 0, Me.ClientSize.Width, 150)
            e.Graphics.FillRectangle(linGrBrush2, 0, CInt(Me.ClientSize.Height - 150), Me.ClientSize.Width, 150)
            e.Graphics.FillRectangle(linGrBrush3, 0, Me.panelWindowTitle.Height, Me.ClientSize.Width, 12)
            e.Graphics.FillRectangle(linGrBrush4, 0, Me.ClientSize.Height - 46, Me.ClientSize.Width, 12)
            e.Graphics.DrawLine(Pens.Gainsboro, 0, Me.panelWindowTitle.Height, Me.ClientSize.Width, Me.panelWindowTitle.Height)
            e.Graphics.DrawLine(Pens.DarkGray, 0, Me.ClientSize.Height - 46, Me.ClientSize.Width, Me.ClientSize.Height - 46)
            'e.Graphics.FillRectangle(linGrBrush5, 0, Me.SplitContainer1.Location.Y + Me.SplitContainer1.SplitterDistance, Me.ClientSize.Width, 12)

        End If
        'e.Graphics.DrawLine(Pens.DarkGray, 0, 0, 0, Me.ClientSize.Height)
        'e.Graphics.DrawLine(Pens.DarkGray, 0, 0, Me.ClientSize.Width, 0)
        'e.Graphics.DrawLine(Pens.DarkGray, Me.ClientSize.Width - 1, 0, Me.ClientSize.Width - 1, Me.ClientSize.Height)
        'e.Graphics.DrawLine(Pens.DarkGray, 0, Me.ClientSize.Height - 1, Me.ClientSize.Width, Me.ClientSize.Height - 1)
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub optStettingTab1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optStettingTab1.CheckedChanged
        If optStettingTab1.Checked = True Then
            Me.TextBoxDescription.Visible = False
            Me.TableLayoutPanel.Visible = True
        End If
    End Sub

    Private Sub optStettingTab2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles optStettingTab2.CheckedChanged
        If optStettingTab2.Checked = True Then
            Me.TableLayoutPanel.Visible = False
            Me.TextBoxDescription.Visible = True
        End If
    End Sub
End Class
