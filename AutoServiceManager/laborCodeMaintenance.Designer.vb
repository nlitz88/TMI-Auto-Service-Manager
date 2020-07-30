<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class laborCodeMaintenance
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
        Me.Description_Value = New System.Windows.Forms.Label()
        Me.DescriptionLabel = New System.Windows.Forms.Label()
        Me.Description_Textbox = New System.Windows.Forms.TextBox()
        Me.Hours_Textbox = New System.Windows.Forms.TextBox()
        Me.HoursLabel = New System.Windows.Forms.Label()
        Me.Hours_Value = New System.Windows.Forms.Label()
        Me.Rate_Textbox = New System.Windows.Forms.TextBox()
        Me.RateLabel = New System.Windows.Forms.Label()
        Me.Rate_Value = New System.Windows.Forms.Label()
        Me.deleteButton = New System.Windows.Forms.Button()
        Me.PartNbr_Textbox = New System.Windows.Forms.TextBox()
        Me.LaborCode_Value = New System.Windows.Forms.Label()
        Me.LaborCodeLabel = New System.Windows.Forms.Label()
        Me.LaborCodeComboLabel = New System.Windows.Forms.Label()
        Me.LCComboBox = New System.Windows.Forms.ComboBox()
        Me.laborCodeMaintenanceLabel = New System.Windows.Forms.Label()
        Me.editButton = New System.Windows.Forms.Button()
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.addButton = New System.Windows.Forms.Button()
        Me.Amount_Textbox = New System.Windows.Forms.TextBox()
        Me.AmountLabel = New System.Windows.Forms.Label()
        Me.Amount_Value = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'nav
        '
        Me.nav.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nav.Location = New System.Drawing.Point(0, 0)
        Me.nav.Name = "nav"
        Me.nav.Size = New System.Drawing.Size(982, 28)
        Me.nav.TabIndex = 50
        '
        'Description_Value
        '
        Me.Description_Value.AutoSize = True
        Me.Description_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Description_Value.ForeColor = System.Drawing.Color.Black
        Me.Description_Value.Location = New System.Drawing.Point(190, 311)
        Me.Description_Value.Name = "Description_Value"
        Me.Description_Value.Size = New System.Drawing.Size(0, 20)
        Me.Description_Value.TabIndex = 132
        Me.Description_Value.Tag = "dataViewingControl"
        '
        'DescriptionLabel
        '
        Me.DescriptionLabel.AutoSize = True
        Me.DescriptionLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.DescriptionLabel.Location = New System.Drawing.Point(97, 314)
        Me.DescriptionLabel.Name = "DescriptionLabel"
        Me.DescriptionLabel.Size = New System.Drawing.Size(87, 17)
        Me.DescriptionLabel.TabIndex = 131
        Me.DescriptionLabel.Tag = "dataLabel"
        Me.DescriptionLabel.Text = "Description :"
        '
        'Description_Textbox
        '
        Me.Description_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Description_Textbox.Location = New System.Drawing.Point(190, 308)
        Me.Description_Textbox.MaxLength = 100
        Me.Description_Textbox.Name = "Description_Textbox"
        Me.Description_Textbox.Size = New System.Drawing.Size(662, 27)
        Me.Description_Textbox.TabIndex = 115
        Me.Description_Textbox.Tag = "dataEditingControl"
        '
        'Hours_Textbox
        '
        Me.Hours_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Hours_Textbox.Location = New System.Drawing.Point(333, 358)
        Me.Hours_Textbox.MaxLength = 19
        Me.Hours_Textbox.Name = "Hours_Textbox"
        Me.Hours_Textbox.Size = New System.Drawing.Size(105, 27)
        Me.Hours_Textbox.TabIndex = 117
        Me.Hours_Textbox.Tag = "dataEditingControl"
        '
        'HoursLabel
        '
        Me.HoursLabel.AutoSize = True
        Me.HoursLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.HoursLabel.Location = New System.Drawing.Point(273, 364)
        Me.HoursLabel.Name = "HoursLabel"
        Me.HoursLabel.Size = New System.Drawing.Size(54, 17)
        Me.HoursLabel.TabIndex = 130
        Me.HoursLabel.Tag = "dataLabel"
        Me.HoursLabel.Text = "Hours :"
        '
        'Hours_Value
        '
        Me.Hours_Value.AutoSize = True
        Me.Hours_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Hours_Value.ForeColor = System.Drawing.Color.Black
        Me.Hours_Value.Location = New System.Drawing.Point(333, 361)
        Me.Hours_Value.Name = "Hours_Value"
        Me.Hours_Value.Size = New System.Drawing.Size(0, 20)
        Me.Hours_Value.TabIndex = 129
        Me.Hours_Value.Tag = "dataViewingControl"
        '
        'Rate_Textbox
        '
        Me.Rate_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rate_Textbox.Location = New System.Drawing.Point(149, 358)
        Me.Rate_Textbox.Name = "Rate_Textbox"
        Me.Rate_Textbox.Size = New System.Drawing.Size(105, 27)
        Me.Rate_Textbox.TabIndex = 116
        Me.Rate_Textbox.Tag = "dataEditingControl"
        '
        'RateLabel
        '
        Me.RateLabel.AutoSize = True
        Me.RateLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.RateLabel.Location = New System.Drawing.Point(97, 364)
        Me.RateLabel.Name = "RateLabel"
        Me.RateLabel.Size = New System.Drawing.Size(46, 17)
        Me.RateLabel.TabIndex = 128
        Me.RateLabel.Tag = "dataLabel"
        Me.RateLabel.Text = "Rate :"
        '
        'Rate_Value
        '
        Me.Rate_Value.AutoSize = True
        Me.Rate_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rate_Value.ForeColor = System.Drawing.Color.Black
        Me.Rate_Value.Location = New System.Drawing.Point(149, 361)
        Me.Rate_Value.Name = "Rate_Value"
        Me.Rate_Value.Size = New System.Drawing.Size(0, 20)
        Me.Rate_Value.TabIndex = 127
        Me.Rate_Value.Tag = "dataViewingControl"
        '
        'deleteButton
        '
        Me.deleteButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.deleteButton.Enabled = False
        Me.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.deleteButton.ForeColor = System.Drawing.Color.White
        Me.deleteButton.Location = New System.Drawing.Point(217, 120)
        Me.deleteButton.Name = "deleteButton"
        Me.deleteButton.Size = New System.Drawing.Size(110, 30)
        Me.deleteButton.TabIndex = 119
        Me.deleteButton.Text = "Delete"
        Me.deleteButton.UseVisualStyleBackColor = False
        '
        'PartNbr_Textbox
        '
        Me.PartNbr_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartNbr_Textbox.Location = New System.Drawing.Point(193, 258)
        Me.PartNbr_Textbox.MaxLength = 15
        Me.PartNbr_Textbox.Name = "PartNbr_Textbox"
        Me.PartNbr_Textbox.Size = New System.Drawing.Size(270, 27)
        Me.PartNbr_Textbox.TabIndex = 114
        Me.PartNbr_Textbox.Tag = "dataEditingControl"
        '
        'LaborCode_Value
        '
        Me.LaborCode_Value.AutoSize = True
        Me.LaborCode_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LaborCode_Value.ForeColor = System.Drawing.Color.Black
        Me.LaborCode_Value.Location = New System.Drawing.Point(193, 261)
        Me.LaborCode_Value.Name = "LaborCode_Value"
        Me.LaborCode_Value.Size = New System.Drawing.Size(0, 20)
        Me.LaborCode_Value.TabIndex = 126
        Me.LaborCode_Value.Tag = "dataViewingControl"
        '
        'LaborCodeLabel
        '
        Me.LaborCodeLabel.AutoSize = True
        Me.LaborCodeLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.LaborCodeLabel.Location = New System.Drawing.Point(97, 264)
        Me.LaborCodeLabel.Name = "LaborCodeLabel"
        Me.LaborCodeLabel.Size = New System.Drawing.Size(90, 17)
        Me.LaborCodeLabel.TabIndex = 125
        Me.LaborCodeLabel.Tag = "dataLabel"
        Me.LaborCodeLabel.Text = "Labor Code :"
        '
        'LaborCodeComboLabel
        '
        Me.LaborCodeComboLabel.AutoSize = True
        Me.LaborCodeComboLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.LaborCodeComboLabel.Location = New System.Drawing.Point(97, 200)
        Me.LaborCodeComboLabel.Name = "LaborCodeComboLabel"
        Me.LaborCodeComboLabel.Size = New System.Drawing.Size(90, 17)
        Me.LaborCodeComboLabel.TabIndex = 124
        Me.LaborCodeComboLabel.Text = "Labor Code :"
        '
        'LCComboBox
        '
        Me.LCComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.LCComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.LCComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.LCComboBox.FormattingEnabled = True
        Me.LCComboBox.Location = New System.Drawing.Point(193, 194)
        Me.LCComboBox.Name = "LCComboBox"
        Me.LCComboBox.Size = New System.Drawing.Size(482, 28)
        Me.LCComboBox.TabIndex = 113
        '
        'laborCodeMaintenanceLabel
        '
        Me.laborCodeMaintenanceLabel.AutoSize = True
        Me.laborCodeMaintenanceLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.laborCodeMaintenanceLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.laborCodeMaintenanceLabel.Location = New System.Drawing.Point(94, 73)
        Me.laborCodeMaintenanceLabel.Name = "laborCodeMaintenanceLabel"
        Me.laborCodeMaintenanceLabel.Size = New System.Drawing.Size(188, 32)
        Me.laborCodeMaintenanceLabel.TabIndex = 123
        Me.laborCodeMaintenanceLabel.Text = "Labor Codes"
        '
        'editButton
        '
        Me.editButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.editButton.Enabled = False
        Me.editButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.editButton.ForeColor = System.Drawing.Color.White
        Me.editButton.Location = New System.Drawing.Point(333, 120)
        Me.editButton.Name = "editButton"
        Me.editButton.Size = New System.Drawing.Size(110, 30)
        Me.editButton.TabIndex = 120
        Me.editButton.Text = "Edit"
        Me.editButton.UseVisualStyleBackColor = False
        '
        'cancelButton
        '
        Me.cancelButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.cancelButton.Enabled = False
        Me.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cancelButton.ForeColor = System.Drawing.Color.White
        Me.cancelButton.Location = New System.Drawing.Point(565, 120)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(110, 30)
        Me.cancelButton.TabIndex = 122
        Me.cancelButton.Text = "Cancel"
        Me.cancelButton.UseVisualStyleBackColor = False
        '
        'saveButton
        '
        Me.saveButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.saveButton.Enabled = False
        Me.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.saveButton.ForeColor = System.Drawing.Color.White
        Me.saveButton.Location = New System.Drawing.Point(449, 120)
        Me.saveButton.Name = "saveButton"
        Me.saveButton.Size = New System.Drawing.Size(110, 30)
        Me.saveButton.TabIndex = 121
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
        Me.addButton.TabIndex = 118
        Me.addButton.Text = "Add"
        Me.addButton.UseVisualStyleBackColor = False
        '
        'Amount_Textbox
        '
        Me.Amount_Textbox.Enabled = False
        Me.Amount_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Amount_Textbox.Location = New System.Drawing.Point(534, 358)
        Me.Amount_Textbox.Name = "Amount_Textbox"
        Me.Amount_Textbox.Size = New System.Drawing.Size(105, 27)
        Me.Amount_Textbox.TabIndex = 133
        Me.Amount_Textbox.Tag = "dataEditingControl"
        '
        'AmountLabel
        '
        Me.AmountLabel.AutoSize = True
        Me.AmountLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.AmountLabel.Location = New System.Drawing.Point(464, 364)
        Me.AmountLabel.Name = "AmountLabel"
        Me.AmountLabel.Size = New System.Drawing.Size(64, 17)
        Me.AmountLabel.TabIndex = 135
        Me.AmountLabel.Tag = "dataLabel"
        Me.AmountLabel.Text = "Amount :"
        '
        'Amount_Value
        '
        Me.Amount_Value.AutoSize = True
        Me.Amount_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Amount_Value.ForeColor = System.Drawing.Color.Black
        Me.Amount_Value.Location = New System.Drawing.Point(534, 361)
        Me.Amount_Value.Name = "Amount_Value"
        Me.Amount_Value.Size = New System.Drawing.Size(0, 20)
        Me.Amount_Value.TabIndex = 134
        Me.Amount_Value.Tag = "dataViewingControl"
        '
        'laborCodeMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(982, 753)
        Me.Controls.Add(Me.Amount_Textbox)
        Me.Controls.Add(Me.AmountLabel)
        Me.Controls.Add(Me.Amount_Value)
        Me.Controls.Add(Me.Description_Value)
        Me.Controls.Add(Me.DescriptionLabel)
        Me.Controls.Add(Me.Description_Textbox)
        Me.Controls.Add(Me.Hours_Textbox)
        Me.Controls.Add(Me.HoursLabel)
        Me.Controls.Add(Me.Hours_Value)
        Me.Controls.Add(Me.Rate_Textbox)
        Me.Controls.Add(Me.RateLabel)
        Me.Controls.Add(Me.Rate_Value)
        Me.Controls.Add(Me.deleteButton)
        Me.Controls.Add(Me.PartNbr_Textbox)
        Me.Controls.Add(Me.LaborCode_Value)
        Me.Controls.Add(Me.LaborCodeLabel)
        Me.Controls.Add(Me.LaborCodeComboLabel)
        Me.Controls.Add(Me.LCComboBox)
        Me.Controls.Add(Me.laborCodeMaintenanceLabel)
        Me.Controls.Add(Me.editButton)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.addButton)
        Me.Controls.Add(Me.nav)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "laborCodeMaintenance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Labor Codes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents nav As navigation
    Friend WithEvents Description_Value As Label
    Friend WithEvents DescriptionLabel As Label
    Friend WithEvents Description_Textbox As TextBox
    Friend WithEvents Hours_Textbox As TextBox
    Friend WithEvents HoursLabel As Label
    Friend WithEvents Hours_Value As Label
    Friend WithEvents Rate_Textbox As TextBox
    Friend WithEvents RateLabel As Label
    Friend WithEvents Rate_Value As Label
    Friend WithEvents deleteButton As Button
    Friend WithEvents PartNbr_Textbox As TextBox
    Friend WithEvents LaborCode_Value As Label
    Friend WithEvents LaborCodeLabel As Label
    Friend WithEvents LaborCodeComboLabel As Label
    Friend WithEvents LCComboBox As ComboBox
    Friend WithEvents laborCodeMaintenanceLabel As Label
    Friend WithEvents editButton As Button
    Friend WithEvents cancelButton As Button
    Friend WithEvents saveButton As Button
    Friend WithEvents addButton As Button
    Friend WithEvents Amount_Textbox As TextBox
    Friend WithEvents AmountLabel As Label
    Friend WithEvents Amount_Value As Label
End Class
