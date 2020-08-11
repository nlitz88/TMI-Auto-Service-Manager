<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class editMasterTaskPart
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.masterTaskPartsMaintenanceLabel = New System.Windows.Forms.Label()
        Me.TaskNameLabel = New System.Windows.Forms.Label()
        Me.PartNumberComboLabel = New System.Windows.Forms.Label()
        Me.PartComboBox = New System.Windows.Forms.ComboBox()
        Me.TaskValue = New System.Windows.Forms.Label()
        Me.PartNbr_Textbox = New System.Windows.Forms.TextBox()
        Me.PartNbr_Value = New System.Windows.Forms.Label()
        Me.PartNumberLabel = New System.Windows.Forms.Label()
        Me.addButton = New System.Windows.Forms.Button()
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'masterTaskPartsMaintenanceLabel
        '
        Me.masterTaskPartsMaintenanceLabel.AutoSize = True
        Me.masterTaskPartsMaintenanceLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.masterTaskPartsMaintenanceLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.masterTaskPartsMaintenanceLabel.Location = New System.Drawing.Point(94, 73)
        Me.masterTaskPartsMaintenanceLabel.Name = "masterTaskPartsMaintenanceLabel"
        Me.masterTaskPartsMaintenanceLabel.Size = New System.Drawing.Size(206, 32)
        Me.masterTaskPartsMaintenanceLabel.TabIndex = 130
        Me.masterTaskPartsMaintenanceLabel.Text = "Edit Task Part"
        '
        'TaskNameLabel
        '
        Me.TaskNameLabel.AutoSize = True
        Me.TaskNameLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TaskNameLabel.Location = New System.Drawing.Point(97, 202)
        Me.TaskNameLabel.Name = "TaskNameLabel"
        Me.TaskNameLabel.Size = New System.Drawing.Size(47, 17)
        Me.TaskNameLabel.TabIndex = 133
        Me.TaskNameLabel.Text = "Task :"
        '
        'PartNumberComboLabel
        '
        Me.PartNumberComboLabel.AutoSize = True
        Me.PartNumberComboLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.PartNumberComboLabel.Location = New System.Drawing.Point(97, 323)
        Me.PartNumberComboLabel.Name = "PartNumberComboLabel"
        Me.PartNumberComboLabel.Size = New System.Drawing.Size(42, 17)
        Me.PartNumberComboLabel.TabIndex = 135
        Me.PartNumberComboLabel.Text = "Part :"
        '
        'PartComboBox
        '
        Me.PartComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.PartComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.PartComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.PartComboBox.FormattingEnabled = True
        Me.PartComboBox.Location = New System.Drawing.Point(145, 317)
        Me.PartComboBox.Name = "PartComboBox"
        Me.PartComboBox.Size = New System.Drawing.Size(297, 28)
        Me.PartComboBox.TabIndex = 134
        '
        'TaskValue
        '
        Me.TaskValue.AutoSize = True
        Me.TaskValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TaskValue.ForeColor = System.Drawing.Color.Black
        Me.TaskValue.Location = New System.Drawing.Point(150, 199)
        Me.TaskValue.Name = "TaskValue"
        Me.TaskValue.Size = New System.Drawing.Size(0, 20)
        Me.TaskValue.TabIndex = 138
        Me.TaskValue.Tag = "dataViewingControl"
        '
        'PartNbr_Textbox
        '
        Me.PartNbr_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartNbr_Textbox.Location = New System.Drawing.Point(199, 371)
        Me.PartNbr_Textbox.MaxLength = 30
        Me.PartNbr_Textbox.Name = "PartNbr_Textbox"
        Me.PartNbr_Textbox.Size = New System.Drawing.Size(270, 27)
        Me.PartNbr_Textbox.TabIndex = 139
        Me.PartNbr_Textbox.Tag = "dataEditingControl"
        '
        'PartNbr_Value
        '
        Me.PartNbr_Value.AutoSize = True
        Me.PartNbr_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartNbr_Value.ForeColor = System.Drawing.Color.Black
        Me.PartNbr_Value.Location = New System.Drawing.Point(199, 374)
        Me.PartNbr_Value.Name = "PartNbr_Value"
        Me.PartNbr_Value.Size = New System.Drawing.Size(0, 20)
        Me.PartNbr_Value.TabIndex = 141
        Me.PartNbr_Value.Tag = "dataViewingControl"
        '
        'PartNumberLabel
        '
        Me.PartNumberLabel.AutoSize = True
        Me.PartNumberLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.PartNumberLabel.Location = New System.Drawing.Point(97, 377)
        Me.PartNumberLabel.Name = "PartNumberLabel"
        Me.PartNumberLabel.Size = New System.Drawing.Size(96, 17)
        Me.PartNumberLabel.TabIndex = 140
        Me.PartNumberLabel.Tag = "dataLabel"
        Me.PartNumberLabel.Text = "Part Number :"
        '
        'addButton
        '
        Me.addButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.addButton.ForeColor = System.Drawing.Color.White
        Me.addButton.Location = New System.Drawing.Point(216, 120)
        Me.addButton.Name = "addButton"
        Me.addButton.Size = New System.Drawing.Size(110, 30)
        Me.addButton.TabIndex = 142
        Me.addButton.Text = "Apply"
        Me.addButton.UseVisualStyleBackColor = False
        '
        'cancelButton
        '
        Me.cancelButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cancelButton.ForeColor = System.Drawing.Color.White
        Me.cancelButton.Location = New System.Drawing.Point(100, 120)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(110, 30)
        Me.cancelButton.TabIndex = 143
        Me.cancelButton.Text = "Back"
        Me.cancelButton.UseVisualStyleBackColor = False
        '
        'editMasterTaskPart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(982, 753)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.addButton)
        Me.Controls.Add(Me.PartNbr_Textbox)
        Me.Controls.Add(Me.PartNbr_Value)
        Me.Controls.Add(Me.PartNumberLabel)
        Me.Controls.Add(Me.TaskValue)
        Me.Controls.Add(Me.PartNumberComboLabel)
        Me.Controls.Add(Me.PartComboBox)
        Me.Controls.Add(Me.TaskNameLabel)
        Me.Controls.Add(Me.masterTaskPartsMaintenanceLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "editMasterTaskPart"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Task Parts"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents masterTaskPartsMaintenanceLabel As Label
    Friend WithEvents TaskNameLabel As Label
    Friend WithEvents PartNumberComboLabel As Label
    Friend WithEvents PartComboBox As ComboBox
    Friend WithEvents TaskValue As Label
    Friend WithEvents PartNbr_Textbox As TextBox
    Friend WithEvents PartNbr_Value As Label
    Friend WithEvents PartNumberLabel As Label
    Friend WithEvents addButton As Button
    Friend WithEvents cancelButton As Button
End Class
