<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class addMasterTaskPart
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
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.addMasterTaskPartLabel = New System.Windows.Forms.Label()
        Me.PartNumberComboLabel = New System.Windows.Forms.Label()
        Me.PartComboBox = New System.Windows.Forms.ComboBox()
        Me.TaskTextbox = New System.Windows.Forms.TextBox()
        Me.TaskNameLabel = New System.Windows.Forms.Label()
        Me.PartAmount_Textbox = New System.Windows.Forms.TextBox()
        Me.TotalLabel = New System.Windows.Forms.Label()
        Me.PartAmount_Value = New System.Windows.Forms.Label()
        Me.Qty_Textbox = New System.Windows.Forms.TextBox()
        Me.QuantityLabel = New System.Windows.Forms.Label()
        Me.Qty_Value = New System.Windows.Forms.Label()
        Me.PartDescription_Value = New System.Windows.Forms.Label()
        Me.PartDescriptionLabel = New System.Windows.Forms.Label()
        Me.PartDescription_Textbox = New System.Windows.Forms.TextBox()
        Me.ListPrice_Textbox = New System.Windows.Forms.TextBox()
        Me.ListPriceLabel = New System.Windows.Forms.Label()
        Me.ListPrice_Value = New System.Windows.Forms.Label()
        Me.PartPrice_Textbox = New System.Windows.Forms.TextBox()
        Me.UnitPriceLabel = New System.Windows.Forms.Label()
        Me.PartPrice_Value = New System.Windows.Forms.Label()
        Me.newPartButton = New System.Windows.Forms.Button()
        Me.orLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cancelButton
        '
        Me.cancelButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cancelButton.ForeColor = System.Drawing.Color.White
        Me.cancelButton.Location = New System.Drawing.Point(216, 120)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(110, 30)
        Me.cancelButton.TabIndex = 131
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
        Me.saveButton.TabIndex = 132
        Me.saveButton.Text = "Save"
        Me.saveButton.UseVisualStyleBackColor = False
        '
        'addMasterTaskPartLabel
        '
        Me.addMasterTaskPartLabel.AutoSize = True
        Me.addMasterTaskPartLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addMasterTaskPartLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.addMasterTaskPartLabel.Location = New System.Drawing.Point(94, 73)
        Me.addMasterTaskPartLabel.Name = "addMasterTaskPartLabel"
        Me.addMasterTaskPartLabel.Size = New System.Drawing.Size(206, 32)
        Me.addMasterTaskPartLabel.TabIndex = 133
        Me.addMasterTaskPartLabel.Text = "Add Task Part"
        '
        'PartNumberComboLabel
        '
        Me.PartNumberComboLabel.AutoSize = True
        Me.PartNumberComboLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.PartNumberComboLabel.Location = New System.Drawing.Point(97, 264)
        Me.PartNumberComboLabel.Name = "PartNumberComboLabel"
        Me.PartNumberComboLabel.Size = New System.Drawing.Size(96, 17)
        Me.PartNumberComboLabel.TabIndex = 135
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
        Me.PartComboBox.TabIndex = 134
        '
        'TaskTextbox
        '
        Me.TaskTextbox.Enabled = False
        Me.TaskTextbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TaskTextbox.Location = New System.Drawing.Point(150, 196)
        Me.TaskTextbox.MaxLength = 50
        Me.TaskTextbox.Name = "TaskTextbox"
        Me.TaskTextbox.Size = New System.Drawing.Size(253, 27)
        Me.TaskTextbox.TabIndex = 146
        Me.TaskTextbox.Tag = "dataEditingControl"
        '
        'TaskNameLabel
        '
        Me.TaskNameLabel.AutoSize = True
        Me.TaskNameLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TaskNameLabel.Location = New System.Drawing.Point(97, 202)
        Me.TaskNameLabel.Name = "TaskNameLabel"
        Me.TaskNameLabel.Size = New System.Drawing.Size(47, 17)
        Me.TaskNameLabel.TabIndex = 145
        Me.TaskNameLabel.Text = "Task :"
        '
        'PartAmount_Textbox
        '
        Me.PartAmount_Textbox.Enabled = False
        Me.PartAmount_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartAmount_Textbox.Location = New System.Drawing.Point(554, 374)
        Me.PartAmount_Textbox.Name = "PartAmount_Textbox"
        Me.PartAmount_Textbox.Size = New System.Drawing.Size(105, 27)
        Me.PartAmount_Textbox.TabIndex = 172
        Me.PartAmount_Textbox.Tag = "dataEditingControl"
        '
        'TotalLabel
        '
        Me.TotalLabel.AutoSize = True
        Me.TotalLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TotalLabel.Location = New System.Drawing.Point(500, 380)
        Me.TotalLabel.Name = "TotalLabel"
        Me.TotalLabel.Size = New System.Drawing.Size(48, 17)
        Me.TotalLabel.TabIndex = 174
        Me.TotalLabel.Tag = "dataLabel"
        Me.TotalLabel.Text = "Total :"
        '
        'PartAmount_Value
        '
        Me.PartAmount_Value.AutoSize = True
        Me.PartAmount_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartAmount_Value.ForeColor = System.Drawing.Color.Black
        Me.PartAmount_Value.Location = New System.Drawing.Point(554, 377)
        Me.PartAmount_Value.Name = "PartAmount_Value"
        Me.PartAmount_Value.Size = New System.Drawing.Size(0, 20)
        Me.PartAmount_Value.TabIndex = 173
        Me.PartAmount_Value.Tag = "dataViewingControl"
        '
        'Qty_Textbox
        '
        Me.Qty_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Qty_Textbox.Location = New System.Drawing.Point(172, 374)
        Me.Qty_Textbox.MaxLength = 14
        Me.Qty_Textbox.Name = "Qty_Textbox"
        Me.Qty_Textbox.Size = New System.Drawing.Size(105, 27)
        Me.Qty_Textbox.TabIndex = 162
        Me.Qty_Textbox.Tag = "dataEditingControl"
        '
        'QuantityLabel
        '
        Me.QuantityLabel.AutoSize = True
        Me.QuantityLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.QuantityLabel.Location = New System.Drawing.Point(97, 380)
        Me.QuantityLabel.Name = "QuantityLabel"
        Me.QuantityLabel.Size = New System.Drawing.Size(69, 17)
        Me.QuantityLabel.TabIndex = 171
        Me.QuantityLabel.Tag = "dataLabel"
        Me.QuantityLabel.Text = "Quantity :"
        '
        'Qty_Value
        '
        Me.Qty_Value.AutoSize = True
        Me.Qty_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Qty_Value.ForeColor = System.Drawing.Color.Black
        Me.Qty_Value.Location = New System.Drawing.Point(172, 377)
        Me.Qty_Value.Name = "Qty_Value"
        Me.Qty_Value.Size = New System.Drawing.Size(0, 20)
        Me.Qty_Value.TabIndex = 170
        Me.Qty_Value.Tag = "dataViewingControl"
        '
        'PartDescription_Value
        '
        Me.PartDescription_Value.AutoSize = True
        Me.PartDescription_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartDescription_Value.ForeColor = System.Drawing.Color.Black
        Me.PartDescription_Value.Location = New System.Drawing.Point(220, 327)
        Me.PartDescription_Value.Name = "PartDescription_Value"
        Me.PartDescription_Value.Size = New System.Drawing.Size(0, 20)
        Me.PartDescription_Value.TabIndex = 169
        Me.PartDescription_Value.Tag = "dataViewingControl"
        '
        'PartDescriptionLabel
        '
        Me.PartDescriptionLabel.AutoSize = True
        Me.PartDescriptionLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.PartDescriptionLabel.Location = New System.Drawing.Point(97, 330)
        Me.PartDescriptionLabel.Name = "PartDescriptionLabel"
        Me.PartDescriptionLabel.Size = New System.Drawing.Size(117, 17)
        Me.PartDescriptionLabel.TabIndex = 168
        Me.PartDescriptionLabel.Tag = "dataLabel"
        Me.PartDescriptionLabel.Text = "Part Description :"
        '
        'PartDescription_Textbox
        '
        Me.PartDescription_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartDescription_Textbox.Location = New System.Drawing.Point(220, 324)
        Me.PartDescription_Textbox.MaxLength = 50
        Me.PartDescription_Textbox.Name = "PartDescription_Textbox"
        Me.PartDescription_Textbox.Size = New System.Drawing.Size(297, 27)
        Me.PartDescription_Textbox.TabIndex = 160
        Me.PartDescription_Textbox.Tag = "dataEditingControl"
        '
        'ListPrice_Textbox
        '
        Me.ListPrice_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListPrice_Textbox.Location = New System.Drawing.Point(618, 324)
        Me.ListPrice_Textbox.Name = "ListPrice_Textbox"
        Me.ListPrice_Textbox.Size = New System.Drawing.Size(105, 27)
        Me.ListPrice_Textbox.TabIndex = 161
        Me.ListPrice_Textbox.Tag = "dataEditingControl"
        '
        'ListPriceLabel
        '
        Me.ListPriceLabel.AutoSize = True
        Me.ListPriceLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ListPriceLabel.Location = New System.Drawing.Point(538, 330)
        Me.ListPriceLabel.Name = "ListPriceLabel"
        Me.ListPriceLabel.Size = New System.Drawing.Size(74, 17)
        Me.ListPriceLabel.TabIndex = 167
        Me.ListPriceLabel.Tag = "dataLabel"
        Me.ListPriceLabel.Text = "List Price :"
        '
        'ListPrice_Value
        '
        Me.ListPrice_Value.AutoSize = True
        Me.ListPrice_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListPrice_Value.ForeColor = System.Drawing.Color.Black
        Me.ListPrice_Value.Location = New System.Drawing.Point(618, 327)
        Me.ListPrice_Value.Name = "ListPrice_Value"
        Me.ListPrice_Value.Size = New System.Drawing.Size(0, 20)
        Me.ListPrice_Value.TabIndex = 166
        Me.ListPrice_Value.Tag = "dataViewingControl"
        '
        'PartPrice_Textbox
        '
        Me.PartPrice_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartPrice_Textbox.Location = New System.Drawing.Point(377, 374)
        Me.PartPrice_Textbox.Name = "PartPrice_Textbox"
        Me.PartPrice_Textbox.Size = New System.Drawing.Size(105, 27)
        Me.PartPrice_Textbox.TabIndex = 163
        Me.PartPrice_Textbox.Tag = "dataEditingControl"
        '
        'UnitPriceLabel
        '
        Me.UnitPriceLabel.AutoSize = True
        Me.UnitPriceLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.UnitPriceLabel.Location = New System.Drawing.Point(294, 380)
        Me.UnitPriceLabel.Name = "UnitPriceLabel"
        Me.UnitPriceLabel.Size = New System.Drawing.Size(77, 17)
        Me.UnitPriceLabel.TabIndex = 165
        Me.UnitPriceLabel.Tag = "dataLabel"
        Me.UnitPriceLabel.Text = "Unit Price :"
        '
        'PartPrice_Value
        '
        Me.PartPrice_Value.AutoSize = True
        Me.PartPrice_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartPrice_Value.ForeColor = System.Drawing.Color.Black
        Me.PartPrice_Value.Location = New System.Drawing.Point(377, 377)
        Me.PartPrice_Value.Name = "PartPrice_Value"
        Me.PartPrice_Value.Size = New System.Drawing.Size(0, 20)
        Me.PartPrice_Value.TabIndex = 164
        Me.PartPrice_Value.Tag = "dataViewingControl"
        '
        'newPartButton
        '
        Me.newPartButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.newPartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.newPartButton.ForeColor = System.Drawing.Color.White
        Me.newPartButton.Location = New System.Drawing.Point(554, 257)
        Me.newPartButton.Name = "newPartButton"
        Me.newPartButton.Size = New System.Drawing.Size(225, 30)
        Me.newPartButton.TabIndex = 175
        Me.newPartButton.Text = "Add New Inventory Part"
        Me.newPartButton.UseVisualStyleBackColor = False
        '
        'orLabel
        '
        Me.orLabel.AutoSize = True
        Me.orLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.orLabel.Location = New System.Drawing.Point(501, 264)
        Me.orLabel.Name = "orLabel"
        Me.orLabel.Size = New System.Drawing.Size(47, 17)
        Me.orLabel.TabIndex = 176
        Me.orLabel.Text = "- OR -"
        '
        'addMasterTaskPart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(982, 753)
        Me.Controls.Add(Me.orLabel)
        Me.Controls.Add(Me.newPartButton)
        Me.Controls.Add(Me.PartAmount_Textbox)
        Me.Controls.Add(Me.TotalLabel)
        Me.Controls.Add(Me.PartAmount_Value)
        Me.Controls.Add(Me.Qty_Textbox)
        Me.Controls.Add(Me.QuantityLabel)
        Me.Controls.Add(Me.Qty_Value)
        Me.Controls.Add(Me.PartDescription_Value)
        Me.Controls.Add(Me.PartDescriptionLabel)
        Me.Controls.Add(Me.PartDescription_Textbox)
        Me.Controls.Add(Me.ListPrice_Textbox)
        Me.Controls.Add(Me.ListPriceLabel)
        Me.Controls.Add(Me.ListPrice_Value)
        Me.Controls.Add(Me.PartPrice_Textbox)
        Me.Controls.Add(Me.UnitPriceLabel)
        Me.Controls.Add(Me.PartPrice_Value)
        Me.Controls.Add(Me.TaskTextbox)
        Me.Controls.Add(Me.TaskNameLabel)
        Me.Controls.Add(Me.PartNumberComboLabel)
        Me.Controls.Add(Me.PartComboBox)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.addMasterTaskPartLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "addMasterTaskPart"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Add Task Part"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cancelButton As Button
    Friend WithEvents saveButton As Button
    Friend WithEvents addMasterTaskPartLabel As Label
    Friend WithEvents PartNumberComboLabel As Label
    Friend WithEvents PartComboBox As ComboBox
    Friend WithEvents TaskTextbox As TextBox
    Friend WithEvents TaskNameLabel As Label
    Friend WithEvents PartAmount_Textbox As TextBox
    Friend WithEvents TotalLabel As Label
    Friend WithEvents PartAmount_Value As Label
    Friend WithEvents Qty_Textbox As TextBox
    Friend WithEvents QuantityLabel As Label
    Friend WithEvents Qty_Value As Label
    Friend WithEvents PartDescription_Value As Label
    Friend WithEvents PartDescriptionLabel As Label
    Friend WithEvents PartDescription_Textbox As TextBox
    Friend WithEvents ListPrice_Textbox As TextBox
    Friend WithEvents ListPriceLabel As Label
    Friend WithEvents ListPrice_Value As Label
    Friend WithEvents PartPrice_Textbox As TextBox
    Friend WithEvents UnitPriceLabel As Label
    Friend WithEvents PartPrice_Value As Label
    Friend WithEvents newPartButton As Button
    Friend WithEvents orLabel As Label
End Class
