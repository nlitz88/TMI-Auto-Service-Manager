﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class masterTaskMaintenance
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
        Me.masterTaskMaintenanceLabel = New System.Windows.Forms.Label()
        Me.editButton = New System.Windows.Forms.Button()
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.addButton = New System.Windows.Forms.Button()
        Me.TaskComboLabel = New System.Windows.Forms.Label()
        Me.TaskComboBox = New System.Windows.Forms.ComboBox()
        Me.TaskDescription_Value = New System.Windows.Forms.Label()
        Me.DescriptionLabel = New System.Windows.Forms.Label()
        Me.TaskDescription_Textbox = New System.Windows.Forms.TextBox()
        Me.Instructions_Value = New System.Windows.Forms.Label()
        Me.InstructionsLabel = New System.Windows.Forms.Label()
        Me.Instructions_Textbox = New System.Windows.Forms.TextBox()
        Me.TaskType_ComboBox = New System.Windows.Forms.ComboBox()
        Me.TaskType_Value = New System.Windows.Forms.Label()
        Me.TaskTypeLabel = New System.Windows.Forms.Label()
        Me.TaskLabor_Textbox = New System.Windows.Forms.TextBox()
        Me.TotalLaborCostLabel = New System.Windows.Forms.Label()
        Me.TaskLabor_Value = New System.Windows.Forms.Label()
        Me.TaskParts_Textbox = New System.Windows.Forms.TextBox()
        Me.TotalPartsCostLabel = New System.Windows.Forms.Label()
        Me.TaskParts_Value = New System.Windows.Forms.Label()
        Me.TotalTask_Textbox = New System.Windows.Forms.TextBox()
        Me.TotalCostLabel = New System.Windows.Forms.Label()
        Me.TotalTask_Value = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'nav
        '
        Me.nav.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nav.Location = New System.Drawing.Point(0, 0)
        Me.nav.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.nav.Name = "nav"
        Me.nav.Size = New System.Drawing.Size(982, 28)
        Me.nav.TabIndex = 51
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
        Me.deleteButton.TabIndex = 125
        Me.deleteButton.Text = "Delete"
        Me.deleteButton.UseVisualStyleBackColor = False
        '
        'masterTaskMaintenanceLabel
        '
        Me.masterTaskMaintenanceLabel.AutoSize = True
        Me.masterTaskMaintenanceLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.masterTaskMaintenanceLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.masterTaskMaintenanceLabel.Location = New System.Drawing.Point(94, 73)
        Me.masterTaskMaintenanceLabel.Name = "masterTaskMaintenanceLabel"
        Me.masterTaskMaintenanceLabel.Size = New System.Drawing.Size(237, 32)
        Me.masterTaskMaintenanceLabel.TabIndex = 129
        Me.masterTaskMaintenanceLabel.Text = "Master Task List"
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
        Me.editButton.TabIndex = 126
        Me.editButton.Text = "Edit"
        Me.editButton.UseVisualStyleBackColor = False
        '
        'cancelButton
        '
        Me.cancelButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.cancelButton.Enabled = False
        Me.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cancelButton.ForeColor = System.Drawing.Color.White
        Me.cancelButton.Location = New System.Drawing.Point(563, 120)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(110, 30)
        Me.cancelButton.TabIndex = 128
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
        Me.saveButton.TabIndex = 127
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
        Me.addButton.TabIndex = 124
        Me.addButton.Text = "Add"
        Me.addButton.UseVisualStyleBackColor = False
        '
        'TaskComboLabel
        '
        Me.TaskComboLabel.AutoSize = True
        Me.TaskComboLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TaskComboLabel.Location = New System.Drawing.Point(97, 200)
        Me.TaskComboLabel.Name = "TaskComboLabel"
        Me.TaskComboLabel.Size = New System.Drawing.Size(47, 17)
        Me.TaskComboLabel.TabIndex = 131
        Me.TaskComboLabel.Text = "Task :"
        '
        'TaskComboBox
        '
        Me.TaskComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TaskComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TaskComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.TaskComboBox.FormattingEnabled = True
        Me.TaskComboBox.Location = New System.Drawing.Point(150, 194)
        Me.TaskComboBox.Name = "TaskComboBox"
        Me.TaskComboBox.Size = New System.Drawing.Size(408, 28)
        Me.TaskComboBox.TabIndex = 130
        '
        'TaskDescription_Value
        '
        Me.TaskDescription_Value.AutoSize = True
        Me.TaskDescription_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TaskDescription_Value.ForeColor = System.Drawing.Color.Black
        Me.TaskDescription_Value.Location = New System.Drawing.Point(190, 261)
        Me.TaskDescription_Value.Name = "TaskDescription_Value"
        Me.TaskDescription_Value.Size = New System.Drawing.Size(0, 20)
        Me.TaskDescription_Value.TabIndex = 135
        Me.TaskDescription_Value.Tag = "dataViewingControl"
        '
        'DescriptionLabel
        '
        Me.DescriptionLabel.AutoSize = True
        Me.DescriptionLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.DescriptionLabel.Location = New System.Drawing.Point(97, 264)
        Me.DescriptionLabel.Name = "DescriptionLabel"
        Me.DescriptionLabel.Size = New System.Drawing.Size(87, 17)
        Me.DescriptionLabel.TabIndex = 134
        Me.DescriptionLabel.Tag = "dataLabel"
        Me.DescriptionLabel.Text = "Description :"
        '
        'TaskDescription_Textbox
        '
        Me.TaskDescription_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TaskDescription_Textbox.Location = New System.Drawing.Point(190, 258)
        Me.TaskDescription_Textbox.MaxLength = 20
        Me.TaskDescription_Textbox.Name = "TaskDescription_Textbox"
        Me.TaskDescription_Textbox.Size = New System.Drawing.Size(408, 27)
        Me.TaskDescription_Textbox.TabIndex = 133
        Me.TaskDescription_Textbox.Tag = "dataEditingControl"
        Me.TaskDescription_Textbox.Visible = False
        '
        'Instructions_Value
        '
        Me.Instructions_Value.AutoSize = True
        Me.Instructions_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Instructions_Value.ForeColor = System.Drawing.Color.Black
        Me.Instructions_Value.Location = New System.Drawing.Point(191, 307)
        Me.Instructions_Value.Name = "Instructions_Value"
        Me.Instructions_Value.Size = New System.Drawing.Size(0, 20)
        Me.Instructions_Value.TabIndex = 138
        Me.Instructions_Value.Tag = "dataViewingControl"
        '
        'InstructionsLabel
        '
        Me.InstructionsLabel.AutoSize = True
        Me.InstructionsLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.InstructionsLabel.Location = New System.Drawing.Point(97, 310)
        Me.InstructionsLabel.Name = "InstructionsLabel"
        Me.InstructionsLabel.Size = New System.Drawing.Size(88, 17)
        Me.InstructionsLabel.TabIndex = 137
        Me.InstructionsLabel.Tag = "dataLabel"
        Me.InstructionsLabel.Text = "Instructions :"
        '
        'Instructions_Textbox
        '
        Me.Instructions_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Instructions_Textbox.Location = New System.Drawing.Point(191, 304)
        Me.Instructions_Textbox.MaxLength = 20
        Me.Instructions_Textbox.Name = "Instructions_Textbox"
        Me.Instructions_Textbox.Size = New System.Drawing.Size(641, 27)
        Me.Instructions_Textbox.TabIndex = 136
        Me.Instructions_Textbox.Tag = "dataEditingControl"
        Me.Instructions_Textbox.Visible = False
        '
        'TaskType_ComboBox
        '
        Me.TaskType_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TaskType_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TaskType_ComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TaskType_ComboBox.FormattingEnabled = True
        Me.TaskType_ComboBox.Location = New System.Drawing.Point(186, 350)
        Me.TaskType_ComboBox.MaxLength = 20
        Me.TaskType_ComboBox.Name = "TaskType_ComboBox"
        Me.TaskType_ComboBox.Size = New System.Drawing.Size(195, 28)
        Me.TaskType_ComboBox.TabIndex = 218
        Me.TaskType_ComboBox.Tag = "dataEditingControl"
        Me.TaskType_ComboBox.Visible = False
        '
        'TaskType_Value
        '
        Me.TaskType_Value.AutoSize = True
        Me.TaskType_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TaskType_Value.ForeColor = System.Drawing.Color.Black
        Me.TaskType_Value.Location = New System.Drawing.Point(186, 353)
        Me.TaskType_Value.Name = "TaskType_Value"
        Me.TaskType_Value.Size = New System.Drawing.Size(0, 20)
        Me.TaskType_Value.TabIndex = 220
        Me.TaskType_Value.Tag = "dataViewingControl"
        Me.TaskType_Value.Visible = False
        '
        'TaskTypeLabel
        '
        Me.TaskTypeLabel.AutoSize = True
        Me.TaskTypeLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TaskTypeLabel.Location = New System.Drawing.Point(97, 356)
        Me.TaskTypeLabel.Name = "TaskTypeLabel"
        Me.TaskTypeLabel.Size = New System.Drawing.Size(83, 17)
        Me.TaskTypeLabel.TabIndex = 219
        Me.TaskTypeLabel.Tag = "dataLabel"
        Me.TaskTypeLabel.Text = "Task Type :"
        Me.TaskTypeLabel.Visible = False
        '
        'TaskLabor_Textbox
        '
        Me.TaskLabor_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TaskLabor_Textbox.Location = New System.Drawing.Point(224, 398)
        Me.TaskLabor_Textbox.Name = "TaskLabor_Textbox"
        Me.TaskLabor_Textbox.Size = New System.Drawing.Size(105, 27)
        Me.TaskLabor_Textbox.TabIndex = 221
        Me.TaskLabor_Textbox.Tag = "dataEditingControl"
        '
        'TotalLaborCostLabel
        '
        Me.TotalLaborCostLabel.AutoSize = True
        Me.TotalLaborCostLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TotalLaborCostLabel.Location = New System.Drawing.Point(97, 404)
        Me.TotalLaborCostLabel.Name = "TotalLaborCostLabel"
        Me.TotalLaborCostLabel.Size = New System.Drawing.Size(121, 17)
        Me.TotalLaborCostLabel.TabIndex = 223
        Me.TotalLaborCostLabel.Tag = "dataLabel"
        Me.TotalLaborCostLabel.Text = "Total Labor Cost :"
        '
        'TaskLabor_Value
        '
        Me.TaskLabor_Value.AutoSize = True
        Me.TaskLabor_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TaskLabor_Value.ForeColor = System.Drawing.Color.Black
        Me.TaskLabor_Value.Location = New System.Drawing.Point(224, 401)
        Me.TaskLabor_Value.Name = "TaskLabor_Value"
        Me.TaskLabor_Value.Size = New System.Drawing.Size(0, 20)
        Me.TaskLabor_Value.TabIndex = 222
        Me.TaskLabor_Value.Tag = "dataViewingControl"
        '
        'TaskParts_Textbox
        '
        Me.TaskParts_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TaskParts_Textbox.Location = New System.Drawing.Point(472, 398)
        Me.TaskParts_Textbox.Name = "TaskParts_Textbox"
        Me.TaskParts_Textbox.Size = New System.Drawing.Size(105, 27)
        Me.TaskParts_Textbox.TabIndex = 224
        Me.TaskParts_Textbox.Tag = "dataEditingControl"
        '
        'TotalPartsCostLabel
        '
        Me.TotalPartsCostLabel.AutoSize = True
        Me.TotalPartsCostLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TotalPartsCostLabel.Location = New System.Drawing.Point(349, 404)
        Me.TotalPartsCostLabel.Name = "TotalPartsCostLabel"
        Me.TotalPartsCostLabel.Size = New System.Drawing.Size(117, 17)
        Me.TotalPartsCostLabel.TabIndex = 226
        Me.TotalPartsCostLabel.Tag = "dataLabel"
        Me.TotalPartsCostLabel.Text = "Total Parts Cost :"
        '
        'TaskParts_Value
        '
        Me.TaskParts_Value.AutoSize = True
        Me.TaskParts_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TaskParts_Value.ForeColor = System.Drawing.Color.Black
        Me.TaskParts_Value.Location = New System.Drawing.Point(472, 401)
        Me.TaskParts_Value.Name = "TaskParts_Value"
        Me.TaskParts_Value.Size = New System.Drawing.Size(0, 20)
        Me.TaskParts_Value.TabIndex = 225
        Me.TaskParts_Value.Tag = "dataViewingControl"
        '
        'TotalTask_Textbox
        '
        Me.TotalTask_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalTask_Textbox.Location = New System.Drawing.Point(684, 398)
        Me.TotalTask_Textbox.Name = "TotalTask_Textbox"
        Me.TotalTask_Textbox.Size = New System.Drawing.Size(105, 27)
        Me.TotalTask_Textbox.TabIndex = 227
        Me.TotalTask_Textbox.Tag = "dataEditingControl"
        '
        'TotalCostLabel
        '
        Me.TotalCostLabel.AutoSize = True
        Me.TotalCostLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TotalCostLabel.Location = New System.Drawing.Point(598, 404)
        Me.TotalCostLabel.Name = "TotalCostLabel"
        Me.TotalCostLabel.Size = New System.Drawing.Size(80, 17)
        Me.TotalCostLabel.TabIndex = 229
        Me.TotalCostLabel.Tag = "dataLabel"
        Me.TotalCostLabel.Text = "Total Cost :"
        '
        'TotalTask_Value
        '
        Me.TotalTask_Value.AutoSize = True
        Me.TotalTask_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalTask_Value.ForeColor = System.Drawing.Color.Black
        Me.TotalTask_Value.Location = New System.Drawing.Point(684, 401)
        Me.TotalTask_Value.Name = "TotalTask_Value"
        Me.TotalTask_Value.Size = New System.Drawing.Size(0, 20)
        Me.TotalTask_Value.TabIndex = 228
        Me.TotalTask_Value.Tag = "dataViewingControl"
        '
        'masterTaskMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(982, 753)
        Me.Controls.Add(Me.TotalTask_Textbox)
        Me.Controls.Add(Me.TotalCostLabel)
        Me.Controls.Add(Me.TotalTask_Value)
        Me.Controls.Add(Me.TaskParts_Textbox)
        Me.Controls.Add(Me.TotalPartsCostLabel)
        Me.Controls.Add(Me.TaskParts_Value)
        Me.Controls.Add(Me.TaskLabor_Textbox)
        Me.Controls.Add(Me.TotalLaborCostLabel)
        Me.Controls.Add(Me.TaskLabor_Value)
        Me.Controls.Add(Me.TaskType_ComboBox)
        Me.Controls.Add(Me.TaskType_Value)
        Me.Controls.Add(Me.TaskTypeLabel)
        Me.Controls.Add(Me.Instructions_Value)
        Me.Controls.Add(Me.InstructionsLabel)
        Me.Controls.Add(Me.Instructions_Textbox)
        Me.Controls.Add(Me.TaskDescription_Value)
        Me.Controls.Add(Me.DescriptionLabel)
        Me.Controls.Add(Me.TaskDescription_Textbox)
        Me.Controls.Add(Me.TaskComboLabel)
        Me.Controls.Add(Me.TaskComboBox)
        Me.Controls.Add(Me.deleteButton)
        Me.Controls.Add(Me.masterTaskMaintenanceLabel)
        Me.Controls.Add(Me.editButton)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.addButton)
        Me.Controls.Add(Me.nav)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "masterTaskMaintenance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Master Task List"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents nav As navigation
    Friend WithEvents deleteButton As Button
    Friend WithEvents masterTaskMaintenanceLabel As Label
    Friend WithEvents editButton As Button
    Friend WithEvents cancelButton As Button
    Friend WithEvents saveButton As Button
    Friend WithEvents addButton As Button
    Friend WithEvents TaskComboLabel As Label
    Friend WithEvents TaskComboBox As ComboBox
    Friend WithEvents TaskDescription_Value As Label
    Friend WithEvents DescriptionLabel As Label
    Friend WithEvents TaskDescription_Textbox As TextBox
    Friend WithEvents Instructions_Value As Label
    Friend WithEvents InstructionsLabel As Label
    Friend WithEvents Instructions_Textbox As TextBox
    Friend WithEvents TaskType_ComboBox As ComboBox
    Friend WithEvents TaskType_Value As Label
    Friend WithEvents TaskTypeLabel As Label
    Friend WithEvents TaskLabor_Textbox As TextBox
    Friend WithEvents TotalLaborCostLabel As Label
    Friend WithEvents TaskLabor_Value As Label
    Friend WithEvents TaskParts_Textbox As TextBox
    Friend WithEvents TotalPartsCostLabel As Label
    Friend WithEvents TaskParts_Value As Label
    Friend WithEvents TotalTask_Textbox As TextBox
    Friend WithEvents TotalCostLabel As Label
    Friend WithEvents TotalTask_Value As Label
End Class
