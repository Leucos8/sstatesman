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
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFileOperationsDelete
    Inherits frmFileOperations

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ckbSStatesManMoveToTrash = New System.Windows.Forms.CheckBox()
        '
        'pnlFormContent
        '
        Me.pnlFormContent.Controls.Add(Me.ckbSStatesManMoveToTrash)
        '
        'ckbSStatesManMoveToTrash
        '
        Me.ckbSStatesManMoveToTrash.AutoSize = True
        Me.ckbSStatesManMoveToTrash.Checked = Global.sstatesman.My.MySettings.Default.SStatesMan_FileTrash
        Me.ckbSStatesManMoveToTrash.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckbSStatesManMoveToTrash.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.sstatesman.My.MySettings.Default, "SStatesMan_FileTrash", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.ckbSStatesManMoveToTrash.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ckbSStatesManMoveToTrash.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.ckbSStatesManMoveToTrash.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ckbSStatesManMoveToTrash.Name = "ckbSStatesManMoveToTrash"
        Me.ckbSStatesManMoveToTrash.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.ckbSStatesManMoveToTrash.Text = "Send files to the Windows Recycle Bin instead of permanently deleting them."
        Me.ckbSStatesManMoveToTrash.UseVisualStyleBackColor = False
        '
        'cmdDeleteCheckAll
        '
        Me.cmdDeleteCheckAll = Me.cmdCommand2
        Me.cmdDeleteCheckAll.Text = "ALL"
        Me.cmdDeleteCheckAll.Image = My.Resources.Icon_CheckAll
        '
        'cmdDeleteCheckNone
        '
        Me.cmdDeleteCheckNone = Me.cmdCommand3
        Me.cmdDeleteCheckNone.Text = "NONE"
        Me.cmdDeleteCheckNone.Image = My.Resources.Icon_CheckNone
        '
        'cmdDeleteCheckInvert
        '
        Me.cmdDeleteCheckInvert = Me.cmdCommand4
        Me.cmdDeleteCheckInvert.Text = "INVERT"
        Me.cmdDeleteCheckInvert.Image = My.Resources.Icon_CheckInvert
        '
        'cmdDeleteCheckBackup
        '
        Me.cmdDeleteCheckBackup = Me.cmdCommand1
        Me.cmdDeleteCheckBackup.Text = "BACKUP"
        Me.cmdDeleteCheckBackup.Image = My.Resources.Icon_CheckBackup
        '
        'cmdOperation
        '
        Me.cmdOperation.Text = "Delete checked".ToUpper
        '
        'frmFileOperationsDelete
        '
        Me.SuspendLayout()
        Me.Name = "frmFileOperationsStore"
        Me.Text = "Delete confirmation"
        Me.FormDescription = "check the files you really want to delete and press ""delete checked"" to confirm."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents ckbSStatesManMoveToTrash As System.Windows.Forms.CheckBox
    Private WithEvents cmdDeleteCheckAll As Button
    Private WithEvents cmdDeleteCheckNone As Button
    Private WithEvents cmdDeleteCheckInvert As Button
    Private WithEvents cmdDeleteCheckBackup As Button

End Class
