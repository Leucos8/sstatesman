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
Partial Class frmFileOperationsReorder
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
        Me.ckbSStatesManReorderBackup = New System.Windows.Forms.CheckBox()
        Me.cmdSortReset = New System.Windows.Forms.Button()
        '
        'flpFileListCommandsFiles
        '
        Me.flpFileListCommandsFiles.Controls.Add(Me.cmdSortReset)
        '
        'cmdSortReset
        '
        Me.cmdSortReset.AutoSize = True
        Me.cmdSortReset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cmdSortReset.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmdSortReset.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.cmdSortReset.FlatAppearance.BorderSize = 0
        Me.cmdSortReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.cmdSortReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmdSortReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSortReset.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Bold)
        Me.cmdSortReset.Location = New System.Drawing.Point(0, 0)
        Me.cmdSortReset.Margin = New System.Windows.Forms.Padding(0)
        Me.cmdSortReset.Name = "cmdSortReset"
        Me.cmdSortReset.Size = New System.Drawing.Size(41, 22)
        Me.cmdSortReset.TabIndex = 40
        Me.cmdSortReset.Text = "&RESET"
        Me.cmdSortReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        '
        'pnlFormContent
        '
        Me.pnlFormContent.Controls.Add(Me.ckbSStatesManReorderBackup)
        '
        'ckbSStatesManReorderBackup
        '
        Me.ckbSStatesManReorderBackup.AutoSize = True
        Me.ckbSStatesManReorderBackup.Checked = Global.sstatesman.My.MySettings.Default.SStatesMan_SStateReorderBackup
        Me.ckbSStatesManReorderBackup.DataBindings.Add(New System.Windows.Forms.Binding("Checked", Global.sstatesman.My.MySettings.Default, "SStatesMan_SStateReorderBackup", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.ckbSStatesManReorderBackup.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ckbSStatesManReorderBackup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke
        Me.ckbSStatesManReorderBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ckbSStatesManReorderBackup.Name = "ckbSStatesManReorderBackup"
        Me.ckbSStatesManReorderBackup.Padding = New System.Windows.Forms.Padding(0, 2, 0, 2)
        Me.ckbSStatesManReorderBackup.TabIndex = 41
        Me.ckbSStatesManReorderBackup.Text = "Reorder savestates together with their backup."
        Me.ckbSStatesManReorderBackup.UseVisualStyleBackColor = False
        '
        'cmdOperation
        '
        Me.cmdOperation.Text = "Reorder".ToUpper
        '
        'cmdMoveUp
        '
        Me.cmdMoveUp = Me.cmdCommand2
        Me.cmdMoveUp.Text = "UP"
        Me.cmdMoveUp.Image = My.Resources.Icon_OrderUp
        Me.cmdMoveUp.Visible = True
        '
        'cmdMoveDown
        '
        Me.cmdMoveDown = Me.cmdCommand3
        Me.cmdMoveDown.Text = "DOWN"
        Me.cmdMoveDown.Image = My.Resources.Icon_OrderDown
        Me.cmdMoveDown.Visible = True
        '
        'cmdMoveFirst
        '
        Me.cmdMoveFirst = Me.cmdCommand1
        Me.cmdMoveFirst.Text = "FIRST"
        Me.cmdMoveFirst.Image = My.Resources.Icon_OrderFirst
        Me.cmdMoveFirst.Visible = True
        '
        'cmdMoveLast
        '
        Me.cmdMoveLast = Me.cmdCommand4
        Me.cmdMoveLast.Text = "LAST"
        Me.cmdMoveLast.Image = My.Resources.Icon_OrderLast
        Me.cmdMoveFirst.Visible = True
        '
        'lblAction
        '
        Me.lblAction.Text = "move checked"
        '
        'lblStatus3
        '
        Me.lblStatus3.Visible = False
        '
        'frmFileOperationsDelete
        '
        Me.SuspendLayout()
        Me.Name = "frmFileOperationsReorder"
        Me.Text = "Reorder savestates"
        Me.FormDescription = "use the move buttons to reorder the list and click ""reorder"" to confirm."
        Me.ResumeLayout(False)
        Me.PerformLayout()



    End Sub

    Private WithEvents ckbSStatesManReorderBackup As System.Windows.Forms.CheckBox
    Private WithEvents cmdSortReset As System.Windows.Forms.Button
    Private WithEvents cmdMoveFirst As Button
    Private WithEvents cmdMoveUp As Button
    Private WithEvents cmdMoveDown As Button
    Private WithEvents cmdMoveLast As Button

End Class
