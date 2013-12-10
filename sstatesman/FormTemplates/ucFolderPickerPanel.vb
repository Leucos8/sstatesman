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

Friend Class ucFolderPickerPanel

    Public Overrides Property Text() As String
        Get
            Return Me.txtPath.Text
        End Get
        Set(ByVal value As String)
            Me.txtPath.Text = value
        End Set
    End Property


    Public Property InfoTextInfo As String = "InfoText"
    Public Property InfoTextWarning As String = "WarningText"
    Public Property InfoTextError As String = "ErrorText"

    Public Property BrowserTip As String = "BrowserTip"
    Public Property BrowserDefaultLocation As Environment.SpecialFolder = Environment.SpecialFolder.MyDocuments
    Public Property BrowserShowNewFolder As Boolean = True

    Private _detectAllowed As Boolean = False
    Public Property ShowDetectButton() As Boolean
        Get
            _detectAllowed = Me.cmdDetect.Visible
            Return _detectAllowed
        End Get
        Set(ByVal value As Boolean)
            Me.cmdDetect.Enabled = value
            Me.cmdDetect.Visible = value
            _detectAllowed = value
        End Set
    End Property

    Private _settingStatus As eSettingStatus = eSettingStatus.StatusInfo
    Public Property SettingStatus As eSettingStatus
        Get
            Me.SettingCheck()
            Return _settingStatus
        End Get
        Set(value As eSettingStatus)
            _settingStatus = value
        End Set
    End Property

    Friend Enum eSettingStatus
        StatusInfo
        StatusWarning
        StatusError
    End Enum


    Public Event Detect(sender As Object, e As EventArgs)
    Public Event Check(sender As Object, e As EventArgs)

    Public Sub UpdateStatus()
        Select Case _settingStatus
            Case eSettingStatus.StatusInfo
                Me.tlpWrapper.BackColor = Me.BackColor
                'Me.imgStatus.Image = My.Resources.InfoIcon_Information
                Me.imgStatus.Visible = False
                Me.lblStatus.Text = Me.InfoTextInfo
            Case eSettingStatus.StatusWarning
                Me.tlpWrapper.BackColor = Color.FromArgb(255, 255, 192)
                Me.imgStatus.Image = My.Resources.InfoIcon_Exclamation
                Me.imgStatus.Visible = True
                Me.lblStatus.Text = Me.InfoTextWarning
            Case eSettingStatus.StatusError
                Me.tlpWrapper.BackColor = Color.FromArgb(255, 192, 192)
                Me.imgStatus.Image = My.Resources.InfoIcon_Error
                Me.imgStatus.Visible = True
                Me.lblStatus.Text = Me.InfoTextError
        End Select
        Me.cmdOpen.Enabled = Directory.Exists(Me.txtPath.Text)
    End Sub

    Private Sub SettingCheck()
        Me.txtPath.Text = mdlMain.TrimBadPathChars(Me.txtPath.Text)

        Me.tmrCheck.Stop()
        Me.tmrCheck.Enabled = False

        RaiseEvent Check(Me, Nothing)

        UpdateStatus()
    End Sub

    Private Sub cmdBrowse_Click(sender As Object, e As EventArgs) Handles cmdBrowse.Click
        Using tmpFBDlg As New FolderBrowserDialog With {.Description = BrowserTip, .ShowNewFolderButton = BrowserShowNewFolder}
            If Me.SettingStatus = eSettingStatus.StatusInfo Then
                tmpFBDlg.SelectedPath = Me.txtPath.Text
            Else : tmpFBDlg.SelectedPath = Environment.GetFolderPath(Me.BrowserDefaultLocation)
            End If
            If tmpFBDlg.ShowDialog(Me) = DialogResult.OK Then
                Me.txtPath.Text = tmpFBDlg.SelectedPath
            End If
        End Using
        Me.SettingCheck()
    End Sub

    Private Sub cmdOpen_Click(sender As Object, e As EventArgs) Handles cmdOpen.Click
        If Directory.Exists(Me.txtPath.Text) Then
            System.Diagnostics.Process.Start(Me.txtPath.Text)
        Else
            Me.SettingCheck()
        End If
    End Sub

    Private Sub cmdDetect_Click(sender As Object, e As EventArgs) Handles cmdDetect.Click
        Me.cmdDetect.Visible = Me._detectAllowed
        Me.cmdDetect.Enabled = Me._detectAllowed
        If Not (Me._detectAllowed) Then
            MessageBox.Show("Detect button should be disabled, something is wrong here!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            SSMAppLog.Append(eType.LogError, eSrc.Settings, eSrcMethod.Detect, "Detect Button was supposed to be disabled here!")
        Else
            RaiseEvent Detect(Me, e)
            Me.SettingCheck()
        End If
    End Sub

    Private Sub txtPath_TextChanged(sender As Object, e As EventArgs) Handles txtPath.TextChanged
        Me.tmrCheck.Enabled = True
        Me.tmrCheck.Stop()
        Me.tmrCheck.Start()
    End Sub

    Private Sub tmrCheck_Tick(sender As Object, e As EventArgs) Handles tmrCheck.Tick
        Me.SettingCheck()
    End Sub

    Private Sub txtPath_Leave(sender As Object, e As EventArgs) Handles txtPath.Leave
        Me.SettingCheck()
    End Sub
End Class
