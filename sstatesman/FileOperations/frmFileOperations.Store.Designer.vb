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
Partial Class frmFileOperationsStore
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
        Me.ckbSStatesStoreCopy = New System.Windows.Forms.CheckBox()
        '
        'pnlFormContent
        '
        Me.pnlFormContent.Controls.Add(Me.ckbSStatesStoreCopy)
        '
        'ckbSStatesStoreCopy
        '
        Me.ckbSStatesStoreCopy.AutoSize = True
        Me.ckbSStatesStoreCopy.Checked = Global.sstatesman.My.MySettings.Default.SStatesMan_MoveStoredInsteadOfCopy
        Me.ckbSStatesStoreCopy.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.sstatesman.My.MySettings.Default, "SStatesMan_MoveStoredInsteadOfCopy", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.ckbSStatesStoreCopy.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ckbSStatesStoreCopy.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.ckbSStatesStoreCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ckbSStatesStoreCopy.Name = "ckbSStatesStoreCopy"
        Me.ckbSStatesStoreCopy.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.ckbSStatesStoreCopy.Text = "Move the savestates instead of copying them when storing/restoring."
        Me.ckbSStatesStoreCopy.UseVisualStyleBackColor = False
        '
        'cmdOperation
        '
        Me.cmdOperation.Text = "Reorder".ToUpper
        '
        'cmdDeleteCheckAll
        '
        Me.cmdStoreCheckAll = Me.cmdCommand2
        Me.cmdStoreCheckAll.Text = "ALL"
        Me.cmdStoreCheckAll.Image = My.Resources.Icon_CheckAll
        '
        'cmdStoreCheckNone
        '
        Me.cmdStoreCheckNone = Me.cmdCommand3
        Me.cmdStoreCheckNone.Text = "NONE"
        Me.cmdStoreCheckNone.Image = My.Resources.Icon_CheckNone
        '
        'cmdStoreCheckInvert
        '
        Me.cmdStoreCheckInvert = Me.cmdCommand4
        Me.cmdStoreCheckInvert.Text = "INVERT"
        Me.cmdStoreCheckInvert.Image = My.Resources.Icon_CheckInvert
        '
        'cmdStoreCheckBackup
        '
        Me.cmdStoreCheckBackup = Me.cmdCommand1
        Me.cmdStoreCheckBackup.Text = "BACKUP"
        Me.cmdStoreCheckBackup.Image = My.Resources.Icon_CheckBackup
        Me.cmdStoreCheckBackup.Visible = False
        '
        'lblStatus3
        '
        Me.lblStatus3.Visible = False
        '
        'frmFileOperationsDelete
        '
        Me.SuspendLayout()
        Me.Name = "frmFileOperationsStore"
        Me.ResumeLayout(False)
        Me.PerformLayout()



    End Sub

    Private WithEvents ckbSStatesStoreCopy As System.Windows.Forms.CheckBox
    Private WithEvents cmdStoreCheckAll As Button
    Private WithEvents cmdStoreCheckNone As Button
    Private WithEvents cmdStoreCheckInvert As Button
    Private WithEvents cmdStoreCheckBackup As Button

End Class
