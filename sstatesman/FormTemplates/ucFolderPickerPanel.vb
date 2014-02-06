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
            Me.CheckState()
        End Set
    End Property

    Public Property DescriptionInfo As String = "Info"
    Public Property DescriptionWarning As String = "Warning"
    Public Property DescriptionError As String = "Error"

    Public Property FBDDescription As String = "FolderBrowserDescription"
    Public Property FBDDefaultPath As Environment.SpecialFolder = Environment.SpecialFolder.MyDocuments
    Public Property FBDShowNewFolderButton As Boolean = True

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

    Private _state As eDescState = eDescState.StateIdle
    Public Property State As eDescState
        Get
            If Me.tmrCheck.Enabled Then
                Me.CheckState()
            End If
            Return _state
        End Get
        Set(value As eDescState)
            If Not (value = _state) Then
                _state = value
                Me.OnValidated(Nothing)
            End If
        End Set
    End Property

    Friend Enum eDescState
        StateIdle
        StateWarning
        StateError
    End Enum


    Public Event DetectFolder(sender As Object, e As EventArgs)

    Public Sub UI_Update()
        Select Case _state
            Case eDescState.StateIdle
                Me.tlpWrapper.BackColor = Me.BackColor
                'Me.imgStatus.Image = My.Resources.InfoIcon_Information
                Me.imgStatus.Visible = False
                Me.lblStatus.Text = Me.DescriptionInfo
            Case eDescState.StateWarning
                Me.tlpWrapper.BackColor = Color.FromArgb(255, 255, 192)
                Me.imgStatus.Image = My.Resources.InfoIcon_Exclamation
                Me.imgStatus.Visible = True
                Me.lblStatus.Text = Me.DescriptionWarning
            Case eDescState.StateError
                Me.tlpWrapper.BackColor = Color.FromArgb(255, 192, 192)
                Me.imgStatus.Image = My.Resources.InfoIcon_Error
                Me.imgStatus.Visible = True
                Me.lblStatus.Text = Me.DescriptionError
        End Select
        Me.cmdOpen.Enabled = Directory.Exists(Me.txtPath.Text)
    End Sub

    Private Sub CheckState()
        Me.txtPath.Text = mdlMain.TrimBadPathChars(Me.txtPath.Text)

        Me.tmrCheck.Stop()
        Me.tmrCheck.Enabled = False

        Me.OnValidating(Nothing)

        UI_Update()
    End Sub

    Private Sub cmdBrowse_Click(sender As Object, e As EventArgs) Handles cmdBrowse.Click
        Using tmpFBDlg As New FolderBrowserDialog With {.Description = FBDDescription, .ShowNewFolderButton = FBDShowNewFolderButton}
            If Me.State = eDescState.StateIdle Then
                tmpFBDlg.SelectedPath = Me.txtPath.Text
            Else : tmpFBDlg.SelectedPath = Environment.GetFolderPath(Me.FBDDefaultPath)
            End If
            If tmpFBDlg.ShowDialog(Me) = DialogResult.OK Then
                Me.txtPath.Text = tmpFBDlg.SelectedPath
            End If
        End Using
        Me.CheckState()
    End Sub

    Private Sub cmdOpen_Click(sender As Object, e As EventArgs) Handles cmdOpen.Click
        Try
            If Directory.Exists(Me.txtPath.Text) Then
                Diagnostics.Process.Start(Me.txtPath.Text)
            Else
                MessageBox.Show(String.Format("The folder ""{0}"" does not exist, please reconfigure. ", Me.txtPath.Text), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(String.Format("The folder ""{0}"" is not accessible, please reconfigure. {1}", Me.txtPath.Text, ex.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmdDetect_Click(sender As Object, e As EventArgs) Handles cmdDetect.Click
        Me.cmdDetect.Visible = Me._detectAllowed
        Me.cmdDetect.Enabled = Me._detectAllowed
        If Not (Me._detectAllowed) Then
            SSMAppLog.Append(eType.LogError, eSrc.Settings, eSrcMethod.Detect, "Detect Button was supposed to be disabled!")
        Else
            RaiseEvent DetectFolder(Me, e)
            Me.CheckState()
        End If
    End Sub

    Private Sub txtPath_TextChanged(sender As Object, e As EventArgs) Handles txtPath.TextChanged
        Me.tmrCheck.Enabled = True
        Me.tmrCheck.Stop()
        Me.tmrCheck.Start()
    End Sub

    Private Sub tmrCheck_Tick(sender As Object, e As EventArgs) Handles tmrCheck.Tick
        Me.CheckState()
    End Sub
End Class
