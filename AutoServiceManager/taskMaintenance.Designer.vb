<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class taskMaintenance
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
        Me.nav = New AutoServiceManager.navigation()
        Me.deleteButton = New System.Windows.Forms.Button()
        Me.TaskType_Textbox = New System.Windows.Forms.TextBox()
        Me.TaskType_Value = New System.Windows.Forms.Label()
        Me.TTSLabel = New System.Windows.Forms.Label()
        Me.TTLabel = New System.Windows.Forms.Label()
        Me.TTComboBox = New System.Windows.Forms.ComboBox()
        Me.taskMaintenanceLabel = New System.Windows.Forms.Label()
        Me.editButton = New System.Windows.Forms.Button()
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.addButton = New System.Windows.Forms.Button()
        Me.TaskDescription_Value = New System.Windows.Forms.Label()
        Me.TTDLabel = New System.Windows.Forms.Label()
        Me.TaskDescription_Textbox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'nav
        '
        Me.nav.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nav.Location = New System.Drawing.Point(0, 0)
        Me.nav.Name = "nav"
        Me.nav.Size = New System.Drawing.Size(982, 28)
        Me.nav.TabIndex = 48
        '
        'deleteButton
        '
        Me.deleteButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.deleteButton.Enabled = False
        Me.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.deleteButton.ForeColor = System.Drawing.Color.White
        Me.deleteButton.Location = New System.Drawing.Point(216, 120)
        Me.deleteButton.Name = "deleteButton"
        Me.deleteButton.Size = New System.Drawing.Size(110, 30)
        Me.deleteButton.TabIndex = 89
        Me.deleteButton.Text = "Delete"
        Me.deleteButton.UseVisualStyleBackColor = False
        '
        'TaskType_Textbox
        '
        Me.TaskType_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TaskType_Textbox.Location = New System.Drawing.Point(236, 258)
        Me.TaskType_Textbox.Name = "TaskType_Textbox"
        Me.TaskType_Textbox.Size = New System.Drawing.Size(63, 27)
        Me.TaskType_Textbox.TabIndex = 88
        Me.TaskType_Textbox.Tag = "dataEditingControl"
        '
        'TaskType_Value
        '
        Me.TaskType_Value.AutoSize = True
        Me.TaskType_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TaskType_Value.ForeColor = System.Drawing.Color.Black
        Me.TaskType_Value.Location = New System.Drawing.Point(227, 261)
        Me.TaskType_Value.Name = "TaskType_Value"
        Me.TaskType_Value.Size = New System.Drawing.Size(0, 20)
        Me.TaskType_Value.TabIndex = 87
        Me.TaskType_Value.Tag = "dataViewingControl"
        '
        'TTSLabel
        '
        Me.TTSLabel.AutoSize = True
        Me.TTSLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TTSLabel.Location = New System.Drawing.Point(97, 264)
        Me.TTSLabel.Name = "TTSLabel"
        Me.TTSLabel.Size = New System.Drawing.Size(133, 17)
        Me.TTSLabel.TabIndex = 86
        Me.TTSLabel.Tag = "dataLabel"
        Me.TTSLabel.Text = "Task Type Symbol :"
        '
        'TTLabel
        '
        Me.TTLabel.AutoSize = True
        Me.TTLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TTLabel.Location = New System.Drawing.Point(97, 200)
        Me.TTLabel.Name = "TTLabel"
        Me.TTLabel.Size = New System.Drawing.Size(83, 17)
        Me.TTLabel.TabIndex = 85
        Me.TTLabel.Text = "Task Type :"
        '
        'TTComboBox
        '
        Me.TTComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TTComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TTComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.TTComboBox.FormattingEnabled = True
        Me.TTComboBox.Location = New System.Drawing.Point(186, 194)
        Me.TTComboBox.Name = "TTComboBox"
        Me.TTComboBox.Size = New System.Drawing.Size(229, 28)
        Me.TTComboBox.TabIndex = 84
        '
        'taskMaintenanceLabel
        '
        Me.taskMaintenanceLabel.AutoSize = True
        Me.taskMaintenanceLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.taskMaintenanceLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.taskMaintenanceLabel.Location = New System.Drawing.Point(94, 73)
        Me.taskMaintenanceLabel.Name = "taskMaintenanceLabel"
        Me.taskMaintenanceLabel.Size = New System.Drawing.Size(170, 32)
        Me.taskMaintenanceLabel.TabIndex = 83
        Me.taskMaintenanceLabel.Text = "Task Types"
        '
        'editButton
        '
        Me.editButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.editButton.Enabled = False
        Me.editButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.editButton.ForeColor = System.Drawing.Color.White
        Me.editButton.Location = New System.Drawing.Point(332, 120)
        Me.editButton.Name = "editButton"
        Me.editButton.Size = New System.Drawing.Size(110, 30)
        Me.editButton.TabIndex = 82
        Me.editButton.Text = "Edit"
        Me.editButton.UseVisualStyleBackColor = False
        '
        'cancelButton
        '
        Me.cancelButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.cancelButton.Enabled = False
        Me.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cancelButton.ForeColor = System.Drawing.Color.White
        Me.cancelButton.Location = New System.Drawing.Point(564, 120)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(110, 30)
        Me.cancelButton.TabIndex = 81
        Me.cancelButton.Text = "Cancel"
        Me.cancelButton.UseVisualStyleBackColor = False
        '
        'saveButton
        '
        Me.saveButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.saveButton.Enabled = False
        Me.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.saveButton.ForeColor = System.Drawing.Color.White
        Me.saveButton.Location = New System.Drawing.Point(448, 120)
        Me.saveButton.Name = "saveButton"
        Me.saveButton.Size = New System.Drawing.Size(110, 30)
        Me.saveButton.TabIndex = 80
        Me.saveButton.Text = "Save"
        Me.saveButton.UseVisualStyleBackColor = False
        '
        'addButton
        '
        Me.addButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.addButton.ForeColor = System.Drawing.Color.White
        Me.addButton.Location = New System.Drawing.Point(100, 120)
        Me.addButton.Name = "addButton"
        Me.addButton.Size = New System.Drawing.Size(110, 30)
        Me.addButton.TabIndex = 79
        Me.addButton.Text = "Add"
        Me.addButton.UseVisualStyleBackColor = False
        '
        'TaskDescription_Value
        '
        Me.TaskDescription_Value.AutoSize = True
        Me.TaskDescription_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TaskDescription_Value.ForeColor = System.Drawing.Color.Black
        Me.TaskDescription_Value.Location = New System.Drawing.Point(448, 261)
        Me.TaskDescription_Value.Name = "TaskDescription_Value"
        Me.TaskDescription_Value.Size = New System.Drawing.Size(0, 20)
        Me.TaskDescription_Value.TabIndex = 90
        Me.TaskDescription_Value.Tag = "dataViewingControl"
        '
        'TTDLabel
        '
        Me.TTDLabel.AutoSize = True
        Me.TTDLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TTDLabel.Location = New System.Drawing.Point(309, 264)
        Me.TTDLabel.Name = "TTDLabel"
        Me.TTDLabel.Size = New System.Drawing.Size(133, 17)
        Me.TTDLabel.TabIndex = 91
        Me.TTDLabel.Tag = "dataLabel"
        Me.TTDLabel.Text = "Task Type Symbol :"
        '
        'TaskDescription_Textbox
        '
        Me.TaskDescription_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TaskDescription_Textbox.Location = New System.Drawing.Point(448, 258)
        Me.TaskDescription_Textbox.Name = "TaskDescription_Textbox"
        Me.TaskDescription_Textbox.Size = New System.Drawing.Size(167, 27)
        Me.TaskDescription_Textbox.TabIndex = 92
        Me.TaskDescription_Textbox.Tag = "dataEditingControl"
        '
        'taskMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(982, 753)
        Me.Controls.Add(Me.TaskDescription_Textbox)
        Me.Controls.Add(Me.TTDLabel)
        Me.Controls.Add(Me.TaskDescription_Value)
        Me.Controls.Add(Me.deleteButton)
        Me.Controls.Add(Me.TaskType_Textbox)
        Me.Controls.Add(Me.TaskType_Value)
        Me.Controls.Add(Me.TTSLabel)
        Me.Controls.Add(Me.TTLabel)
        Me.Controls.Add(Me.TTComboBox)
        Me.Controls.Add(Me.taskMaintenanceLabel)
        Me.Controls.Add(Me.editButton)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.addButton)
        Me.Controls.Add(Me.nav)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "taskMaintenance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Task Types"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents nav As navigation
    Friend WithEvents deleteButton As Button
    Friend WithEvents TaskType_Textbox As TextBox
    Friend WithEvents TaskType_Value As Label
    Friend WithEvents TTSLabel As Label
    Friend WithEvents TTLabel As Label
    Friend WithEvents TTComboBox As ComboBox
    Friend WithEvents taskMaintenanceLabel As Label
    Friend WithEvents editButton As Button
    Friend WithEvents cancelButton As Button
    Friend WithEvents saveButton As Button
    Friend WithEvents addButton As Button
    Friend WithEvents TaskDescription_Value As Label
    Friend WithEvents TTDLabel As Label
    Friend WithEvents TaskDescription_Textbox As TextBox
End Class
