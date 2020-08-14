<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class addMasterTaskLabor
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
        Me.PartNbr_Textbox = New System.Windows.Forms.TextBox()
        Me.PartNumberLabel = New System.Windows.Forms.Label()
        Me.orLabel = New System.Windows.Forms.Label()
        Me.newLaborButton = New System.Windows.Forms.Button()
        Me.PartAmount_Textbox = New System.Windows.Forms.TextBox()
        Me.TotalLabel = New System.Windows.Forms.Label()
        Me.Qty_Textbox = New System.Windows.Forms.TextBox()
        Me.QuantityLabel = New System.Windows.Forms.Label()
        Me.PartDescriptionLabel = New System.Windows.Forms.Label()
        Me.PartDescription_Textbox = New System.Windows.Forms.TextBox()
        Me.ListPrice_Textbox = New System.Windows.Forms.TextBox()
        Me.ListPriceLabel = New System.Windows.Forms.Label()
        Me.PartPrice_Textbox = New System.Windows.Forms.TextBox()
        Me.UnitPriceLabel = New System.Windows.Forms.Label()
        Me.TaskTextbox = New System.Windows.Forms.TextBox()
        Me.TaskNameLabel = New System.Windows.Forms.Label()
        Me.PartNumberComboLabel = New System.Windows.Forms.Label()
        Me.PartComboBox = New System.Windows.Forms.ComboBox()
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.addMasterTaskLaborLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'PartNbr_Textbox
        '
        Me.PartNbr_Textbox.Enabled = False
        Me.PartNbr_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartNbr_Textbox.Location = New System.Drawing.Point(199, 324)
        Me.PartNbr_Textbox.MaxLength = 30
        Me.PartNbr_Textbox.Name = "PartNbr_Textbox"
        Me.PartNbr_Textbox.Size = New System.Drawing.Size(270, 27)
        Me.PartNbr_Textbox.TabIndex = 198
        Me.PartNbr_Textbox.Tag = "dataEditingControl"
        '
        'PartNumberLabel
        '
        Me.PartNumberLabel.AutoSize = True
        Me.PartNumberLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.PartNumberLabel.Location = New System.Drawing.Point(97, 330)
        Me.PartNumberLabel.Name = "PartNumberLabel"
        Me.PartNumberLabel.Size = New System.Drawing.Size(96, 17)
        Me.PartNumberLabel.TabIndex = 199
        Me.PartNumberLabel.Tag = "dataLabel"
        Me.PartNumberLabel.Text = "Part Number :"
        '
        'orLabel
        '
        Me.orLabel.AutoSize = True
        Me.orLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.orLabel.Location = New System.Drawing.Point(501, 264)
        Me.orLabel.Name = "orLabel"
        Me.orLabel.Size = New System.Drawing.Size(47, 17)
        Me.orLabel.TabIndex = 197
        Me.orLabel.Text = "- OR -"
        '
        'newLaborButton
        '
        Me.newLaborButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.newLaborButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.newLaborButton.ForeColor = System.Drawing.Color.White
        Me.newLaborButton.Location = New System.Drawing.Point(554, 257)
        Me.newLaborButton.Name = "newLaborButton"
        Me.newLaborButton.Size = New System.Drawing.Size(225, 30)
        Me.newLaborButton.TabIndex = 186
        Me.newLaborButton.Text = "Add New Labor Code"
        Me.newLaborButton.UseVisualStyleBackColor = False
        '
        'PartAmount_Textbox
        '
        Me.PartAmount_Textbox.Enabled = False
        Me.PartAmount_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartAmount_Textbox.Location = New System.Drawing.Point(554, 425)
        Me.PartAmount_Textbox.Name = "PartAmount_Textbox"
        Me.PartAmount_Textbox.Size = New System.Drawing.Size(105, 27)
        Me.PartAmount_Textbox.TabIndex = 195
        Me.PartAmount_Textbox.Tag = "dataEditingControl"
        '
        'TotalLabel
        '
        Me.TotalLabel.AutoSize = True
        Me.TotalLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TotalLabel.Location = New System.Drawing.Point(500, 431)
        Me.TotalLabel.Name = "TotalLabel"
        Me.TotalLabel.Size = New System.Drawing.Size(48, 17)
        Me.TotalLabel.TabIndex = 196
        Me.TotalLabel.Tag = "dataLabel"
        Me.TotalLabel.Text = "Total :"
        '
        'Qty_Textbox
        '
        Me.Qty_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Qty_Textbox.Location = New System.Drawing.Point(172, 425)
        Me.Qty_Textbox.MaxLength = 14
        Me.Qty_Textbox.Name = "Qty_Textbox"
        Me.Qty_Textbox.Size = New System.Drawing.Size(105, 27)
        Me.Qty_Textbox.TabIndex = 182
        Me.Qty_Textbox.Tag = "dataEditingControl"
        '
        'QuantityLabel
        '
        Me.QuantityLabel.AutoSize = True
        Me.QuantityLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.QuantityLabel.Location = New System.Drawing.Point(97, 431)
        Me.QuantityLabel.Name = "QuantityLabel"
        Me.QuantityLabel.Size = New System.Drawing.Size(69, 17)
        Me.QuantityLabel.TabIndex = 194
        Me.QuantityLabel.Tag = "dataLabel"
        Me.QuantityLabel.Text = "Quantity :"
        '
        'PartDescriptionLabel
        '
        Me.PartDescriptionLabel.AutoSize = True
        Me.PartDescriptionLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.PartDescriptionLabel.Location = New System.Drawing.Point(97, 381)
        Me.PartDescriptionLabel.Name = "PartDescriptionLabel"
        Me.PartDescriptionLabel.Size = New System.Drawing.Size(117, 17)
        Me.PartDescriptionLabel.TabIndex = 193
        Me.PartDescriptionLabel.Tag = "dataLabel"
        Me.PartDescriptionLabel.Text = "Part Description :"
        '
        'PartDescription_Textbox
        '
        Me.PartDescription_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartDescription_Textbox.Location = New System.Drawing.Point(220, 375)
        Me.PartDescription_Textbox.MaxLength = 50
        Me.PartDescription_Textbox.Name = "PartDescription_Textbox"
        Me.PartDescription_Textbox.Size = New System.Drawing.Size(297, 27)
        Me.PartDescription_Textbox.TabIndex = 180
        Me.PartDescription_Textbox.Tag = "dataEditingControl"
        '
        'ListPrice_Textbox
        '
        Me.ListPrice_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListPrice_Textbox.Location = New System.Drawing.Point(618, 375)
        Me.ListPrice_Textbox.Name = "ListPrice_Textbox"
        Me.ListPrice_Textbox.Size = New System.Drawing.Size(105, 27)
        Me.ListPrice_Textbox.TabIndex = 181
        Me.ListPrice_Textbox.Tag = "dataEditingControl"
        '
        'ListPriceLabel
        '
        Me.ListPriceLabel.AutoSize = True
        Me.ListPriceLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ListPriceLabel.Location = New System.Drawing.Point(538, 381)
        Me.ListPriceLabel.Name = "ListPriceLabel"
        Me.ListPriceLabel.Size = New System.Drawing.Size(74, 17)
        Me.ListPriceLabel.TabIndex = 192
        Me.ListPriceLabel.Tag = "dataLabel"
        Me.ListPriceLabel.Text = "List Price :"
        '
        'PartPrice_Textbox
        '
        Me.PartPrice_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartPrice_Textbox.Location = New System.Drawing.Point(377, 425)
        Me.PartPrice_Textbox.Name = "PartPrice_Textbox"
        Me.PartPrice_Textbox.Size = New System.Drawing.Size(105, 27)
        Me.PartPrice_Textbox.TabIndex = 183
        Me.PartPrice_Textbox.Tag = "dataEditingControl"
        '
        'UnitPriceLabel
        '
        Me.UnitPriceLabel.AutoSize = True
        Me.UnitPriceLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.UnitPriceLabel.Location = New System.Drawing.Point(294, 431)
        Me.UnitPriceLabel.Name = "UnitPriceLabel"
        Me.UnitPriceLabel.Size = New System.Drawing.Size(77, 17)
        Me.UnitPriceLabel.TabIndex = 191
        Me.UnitPriceLabel.Tag = "dataLabel"
        Me.UnitPriceLabel.Text = "Unit Price :"
        '
        'TaskTextbox
        '
        Me.TaskTextbox.Enabled = False
        Me.TaskTextbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TaskTextbox.Location = New System.Drawing.Point(150, 196)
        Me.TaskTextbox.MaxLength = 50
        Me.TaskTextbox.Name = "TaskTextbox"
        Me.TaskTextbox.Size = New System.Drawing.Size(253, 27)
        Me.TaskTextbox.TabIndex = 190
        Me.TaskTextbox.Tag = ""
        '
        'TaskNameLabel
        '
        Me.TaskNameLabel.AutoSize = True
        Me.TaskNameLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TaskNameLabel.Location = New System.Drawing.Point(97, 202)
        Me.TaskNameLabel.Name = "TaskNameLabel"
        Me.TaskNameLabel.Size = New System.Drawing.Size(47, 17)
        Me.TaskNameLabel.TabIndex = 189
        Me.TaskNameLabel.Text = "Task :"
        '
        'PartNumberComboLabel
        '
        Me.PartNumberComboLabel.AutoSize = True
        Me.PartNumberComboLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.PartNumberComboLabel.Location = New System.Drawing.Point(97, 264)
        Me.PartNumberComboLabel.Name = "PartNumberComboLabel"
        Me.PartNumberComboLabel.Size = New System.Drawing.Size(96, 17)
        Me.PartNumberComboLabel.TabIndex = 188
        Me.PartNumberComboLabel.Text = "Part Number :"
        '
        'PartComboBox
        '
        Me.PartComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.PartComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.PartComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.PartComboBox.FormattingEnabled = True
        Me.PartComboBox.Location = New System.Drawing.Point(199, 258)
        Me.PartComboBox.Name = "PartComboBox"
        Me.PartComboBox.Size = New System.Drawing.Size(297, 28)
        Me.PartComboBox.TabIndex = 179
        '
        'cancelButton
        '
        Me.cancelButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cancelButton.ForeColor = System.Drawing.Color.White
        Me.cancelButton.Location = New System.Drawing.Point(216, 120)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(110, 30)
        Me.cancelButton.TabIndex = 185
        Me.cancelButton.Text = "Cancel"
        Me.cancelButton.UseVisualStyleBackColor = False
        '
        'saveButton
        '
        Me.saveButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.saveButton.Enabled = False
        Me.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.saveButton.ForeColor = System.Drawing.Color.White
        Me.saveButton.Location = New System.Drawing.Point(100, 120)
        Me.saveButton.Name = "saveButton"
        Me.saveButton.Size = New System.Drawing.Size(110, 30)
        Me.saveButton.TabIndex = 184
        Me.saveButton.Text = "Save"
        Me.saveButton.UseVisualStyleBackColor = False
        '
        'addMasterTaskLaborLabel
        '
        Me.addMasterTaskLaborLabel.AutoSize = True
        Me.addMasterTaskLaborLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addMasterTaskLaborLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.addMasterTaskLaborLabel.Location = New System.Drawing.Point(94, 73)
        Me.addMasterTaskLaborLabel.Name = "addMasterTaskLaborLabel"
        Me.addMasterTaskLaborLabel.Size = New System.Drawing.Size(228, 32)
        Me.addMasterTaskLaborLabel.TabIndex = 187
        Me.addMasterTaskLaborLabel.Text = "Add Task Labor"
        '
        'addMasterTaskLabor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(982, 753)
        Me.Controls.Add(Me.PartNbr_Textbox)
        Me.Controls.Add(Me.PartNumberLabel)
        Me.Controls.Add(Me.orLabel)
        Me.Controls.Add(Me.newLaborButton)
        Me.Controls.Add(Me.PartAmount_Textbox)
        Me.Controls.Add(Me.TotalLabel)
        Me.Controls.Add(Me.Qty_Textbox)
        Me.Controls.Add(Me.QuantityLabel)
        Me.Controls.Add(Me.PartDescriptionLabel)
        Me.Controls.Add(Me.PartDescription_Textbox)
        Me.Controls.Add(Me.ListPrice_Textbox)
        Me.Controls.Add(Me.ListPriceLabel)
        Me.Controls.Add(Me.PartPrice_Textbox)
        Me.Controls.Add(Me.UnitPriceLabel)
        Me.Controls.Add(Me.TaskTextbox)
        Me.Controls.Add(Me.TaskNameLabel)
        Me.Controls.Add(Me.PartNumberComboLabel)
        Me.Controls.Add(Me.PartComboBox)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.addMasterTaskLaborLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "addMasterTaskLabor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Add Task Labor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PartNbr_Textbox As TextBox
    Friend WithEvents PartNumberLabel As Label
    Friend WithEvents orLabel As Label
    Friend WithEvents newLaborButton As Button
    Friend WithEvents PartAmount_Textbox As TextBox
    Friend WithEvents TotalLabel As Label
    Friend WithEvents Qty_Textbox As TextBox
    Friend WithEvents QuantityLabel As Label
    Friend WithEvents PartDescriptionLabel As Label
    Friend WithEvents PartDescription_Textbox As TextBox
    Friend WithEvents ListPrice_Textbox As TextBox
    Friend WithEvents ListPriceLabel As Label
    Friend WithEvents PartPrice_Textbox As TextBox
    Friend WithEvents UnitPriceLabel As Label
    Friend WithEvents TaskTextbox As TextBox
    Friend WithEvents TaskNameLabel As Label
    Friend WithEvents PartNumberComboLabel As Label
    Friend WithEvents PartComboBox As ComboBox
    Friend WithEvents cancelButton As Button
    Friend WithEvents saveButton As Button
    Friend WithEvents addMasterTaskLaborLabel As Label
End Class
