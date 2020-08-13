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
        Me.editMasterTaskPartLabel = New System.Windows.Forms.Label()
        Me.TaskNameLabel = New System.Windows.Forms.Label()
        Me.PartNbr_Textbox = New System.Windows.Forms.TextBox()
        Me.PartNbr_Value = New System.Windows.Forms.Label()
        Me.PartNumberLabel = New System.Windows.Forms.Label()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.TaskTextbox = New System.Windows.Forms.TextBox()
        Me.PartDescription_Value = New System.Windows.Forms.Label()
        Me.PartDescriptionLabel = New System.Windows.Forms.Label()
        Me.PartDescription_Textbox = New System.Windows.Forms.TextBox()
        Me.ListPrice_Textbox = New System.Windows.Forms.TextBox()
        Me.ListPriceLabel = New System.Windows.Forms.Label()
        Me.ListPrice_Value = New System.Windows.Forms.Label()
        Me.PartPrice_Textbox = New System.Windows.Forms.TextBox()
        Me.UnitPriceLabel = New System.Windows.Forms.Label()
        Me.PartPrice_Value = New System.Windows.Forms.Label()
        Me.Qty_Textbox = New System.Windows.Forms.TextBox()
        Me.QuantityLabel = New System.Windows.Forms.Label()
        Me.Qty_Value = New System.Windows.Forms.Label()
        Me.PartAmount_Textbox = New System.Windows.Forms.TextBox()
        Me.TotalLabel = New System.Windows.Forms.Label()
        Me.PartAmount_Value = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'editMasterTaskPartLabel
        '
        Me.editMasterTaskPartLabel.AutoSize = True
        Me.editMasterTaskPartLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.editMasterTaskPartLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.editMasterTaskPartLabel.Location = New System.Drawing.Point(94, 73)
        Me.editMasterTaskPartLabel.Name = "editMasterTaskPartLabel"
        Me.editMasterTaskPartLabel.Size = New System.Drawing.Size(206, 32)
        Me.editMasterTaskPartLabel.TabIndex = 130
        Me.editMasterTaskPartLabel.Text = "Edit Task Part"
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
        'PartNbr_Textbox
        '
        Me.PartNbr_Textbox.Enabled = False
        Me.PartNbr_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartNbr_Textbox.Location = New System.Drawing.Point(199, 258)
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
        Me.PartNbr_Value.Location = New System.Drawing.Point(199, 261)
        Me.PartNbr_Value.Name = "PartNbr_Value"
        Me.PartNbr_Value.Size = New System.Drawing.Size(0, 20)
        Me.PartNbr_Value.TabIndex = 141
        Me.PartNbr_Value.Tag = "dataViewingControl"
        '
        'PartNumberLabel
        '
        Me.PartNumberLabel.AutoSize = True
        Me.PartNumberLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.PartNumberLabel.Location = New System.Drawing.Point(97, 264)
        Me.PartNumberLabel.Name = "PartNumberLabel"
        Me.PartNumberLabel.Size = New System.Drawing.Size(96, 17)
        Me.PartNumberLabel.TabIndex = 140
        Me.PartNumberLabel.Tag = "dataLabel"
        Me.PartNumberLabel.Text = "Part Number :"
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
        Me.saveButton.TabIndex = 5
        Me.saveButton.Text = "Save"
        Me.saveButton.UseVisualStyleBackColor = False
        '
        'cancelButton
        '
        Me.cancelButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cancelButton.ForeColor = System.Drawing.Color.White
        Me.cancelButton.Location = New System.Drawing.Point(216, 120)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(110, 30)
        Me.cancelButton.TabIndex = 4
        Me.cancelButton.Text = "Cancel"
        Me.cancelButton.UseVisualStyleBackColor = False
        '
        'TaskTextbox
        '
        Me.TaskTextbox.Enabled = False
        Me.TaskTextbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TaskTextbox.Location = New System.Drawing.Point(145, 196)
        Me.TaskTextbox.MaxLength = 50
        Me.TaskTextbox.Name = "TaskTextbox"
        Me.TaskTextbox.Size = New System.Drawing.Size(253, 27)
        Me.TaskTextbox.TabIndex = 144
        Me.TaskTextbox.Tag = ""
        '
        'PartDescription_Value
        '
        Me.PartDescription_Value.AutoSize = True
        Me.PartDescription_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartDescription_Value.ForeColor = System.Drawing.Color.Black
        Me.PartDescription_Value.Location = New System.Drawing.Point(220, 311)
        Me.PartDescription_Value.Name = "PartDescription_Value"
        Me.PartDescription_Value.Size = New System.Drawing.Size(0, 20)
        Me.PartDescription_Value.TabIndex = 153
        Me.PartDescription_Value.Tag = "dataViewingControl"
        '
        'PartDescriptionLabel
        '
        Me.PartDescriptionLabel.AutoSize = True
        Me.PartDescriptionLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.PartDescriptionLabel.Location = New System.Drawing.Point(97, 314)
        Me.PartDescriptionLabel.Name = "PartDescriptionLabel"
        Me.PartDescriptionLabel.Size = New System.Drawing.Size(117, 17)
        Me.PartDescriptionLabel.TabIndex = 152
        Me.PartDescriptionLabel.Tag = "dataLabel"
        Me.PartDescriptionLabel.Text = "Part Description :"
        '
        'PartDescription_Textbox
        '
        Me.PartDescription_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartDescription_Textbox.Location = New System.Drawing.Point(220, 308)
        Me.PartDescription_Textbox.MaxLength = 50
        Me.PartDescription_Textbox.Name = "PartDescription_Textbox"
        Me.PartDescription_Textbox.Size = New System.Drawing.Size(297, 27)
        Me.PartDescription_Textbox.TabIndex = 0
        Me.PartDescription_Textbox.Tag = "dataEditingControl"
        '
        'ListPrice_Textbox
        '
        Me.ListPrice_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListPrice_Textbox.Location = New System.Drawing.Point(618, 308)
        Me.ListPrice_Textbox.Name = "ListPrice_Textbox"
        Me.ListPrice_Textbox.Size = New System.Drawing.Size(105, 27)
        Me.ListPrice_Textbox.TabIndex = 1
        Me.ListPrice_Textbox.Tag = "dataEditingControl"
        '
        'ListPriceLabel
        '
        Me.ListPriceLabel.AutoSize = True
        Me.ListPriceLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ListPriceLabel.Location = New System.Drawing.Point(538, 314)
        Me.ListPriceLabel.Name = "ListPriceLabel"
        Me.ListPriceLabel.Size = New System.Drawing.Size(74, 17)
        Me.ListPriceLabel.TabIndex = 151
        Me.ListPriceLabel.Tag = "dataLabel"
        Me.ListPriceLabel.Text = "List Price :"
        '
        'ListPrice_Value
        '
        Me.ListPrice_Value.AutoSize = True
        Me.ListPrice_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListPrice_Value.ForeColor = System.Drawing.Color.Black
        Me.ListPrice_Value.Location = New System.Drawing.Point(618, 311)
        Me.ListPrice_Value.Name = "ListPrice_Value"
        Me.ListPrice_Value.Size = New System.Drawing.Size(0, 20)
        Me.ListPrice_Value.TabIndex = 150
        Me.ListPrice_Value.Tag = "dataViewingControl"
        '
        'PartPrice_Textbox
        '
        Me.PartPrice_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartPrice_Textbox.Location = New System.Drawing.Point(377, 358)
        Me.PartPrice_Textbox.Name = "PartPrice_Textbox"
        Me.PartPrice_Textbox.Size = New System.Drawing.Size(105, 27)
        Me.PartPrice_Textbox.TabIndex = 3
        Me.PartPrice_Textbox.Tag = "dataEditingControl"
        '
        'UnitPriceLabel
        '
        Me.UnitPriceLabel.AutoSize = True
        Me.UnitPriceLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.UnitPriceLabel.Location = New System.Drawing.Point(294, 364)
        Me.UnitPriceLabel.Name = "UnitPriceLabel"
        Me.UnitPriceLabel.Size = New System.Drawing.Size(77, 17)
        Me.UnitPriceLabel.TabIndex = 149
        Me.UnitPriceLabel.Tag = "dataLabel"
        Me.UnitPriceLabel.Text = "Unit Price :"
        '
        'PartPrice_Value
        '
        Me.PartPrice_Value.AutoSize = True
        Me.PartPrice_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartPrice_Value.ForeColor = System.Drawing.Color.Black
        Me.PartPrice_Value.Location = New System.Drawing.Point(377, 361)
        Me.PartPrice_Value.Name = "PartPrice_Value"
        Me.PartPrice_Value.Size = New System.Drawing.Size(0, 20)
        Me.PartPrice_Value.TabIndex = 148
        Me.PartPrice_Value.Tag = "dataViewingControl"
        '
        'Qty_Textbox
        '
        Me.Qty_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Qty_Textbox.Location = New System.Drawing.Point(172, 358)
        Me.Qty_Textbox.MaxLength = 14
        Me.Qty_Textbox.Name = "Qty_Textbox"
        Me.Qty_Textbox.Size = New System.Drawing.Size(105, 27)
        Me.Qty_Textbox.TabIndex = 2
        Me.Qty_Textbox.Tag = "dataEditingControl"
        '
        'QuantityLabel
        '
        Me.QuantityLabel.AutoSize = True
        Me.QuantityLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.QuantityLabel.Location = New System.Drawing.Point(97, 364)
        Me.QuantityLabel.Name = "QuantityLabel"
        Me.QuantityLabel.Size = New System.Drawing.Size(69, 17)
        Me.QuantityLabel.TabIndex = 156
        Me.QuantityLabel.Tag = "dataLabel"
        Me.QuantityLabel.Text = "Quantity :"
        '
        'Qty_Value
        '
        Me.Qty_Value.AutoSize = True
        Me.Qty_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Qty_Value.ForeColor = System.Drawing.Color.Black
        Me.Qty_Value.Location = New System.Drawing.Point(172, 361)
        Me.Qty_Value.Name = "Qty_Value"
        Me.Qty_Value.Size = New System.Drawing.Size(0, 20)
        Me.Qty_Value.TabIndex = 155
        Me.Qty_Value.Tag = "dataViewingControl"
        '
        'PartAmount_Textbox
        '
        Me.PartAmount_Textbox.Enabled = False
        Me.PartAmount_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartAmount_Textbox.Location = New System.Drawing.Point(554, 358)
        Me.PartAmount_Textbox.Name = "PartAmount_Textbox"
        Me.PartAmount_Textbox.Size = New System.Drawing.Size(105, 27)
        Me.PartAmount_Textbox.TabIndex = 157
        Me.PartAmount_Textbox.Tag = "dataEditingControl"
        '
        'TotalLabel
        '
        Me.TotalLabel.AutoSize = True
        Me.TotalLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TotalLabel.Location = New System.Drawing.Point(500, 364)
        Me.TotalLabel.Name = "TotalLabel"
        Me.TotalLabel.Size = New System.Drawing.Size(48, 17)
        Me.TotalLabel.TabIndex = 159
        Me.TotalLabel.Tag = "dataLabel"
        Me.TotalLabel.Text = "Total :"
        '
        'PartAmount_Value
        '
        Me.PartAmount_Value.AutoSize = True
        Me.PartAmount_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartAmount_Value.ForeColor = System.Drawing.Color.Black
        Me.PartAmount_Value.Location = New System.Drawing.Point(554, 361)
        Me.PartAmount_Value.Name = "PartAmount_Value"
        Me.PartAmount_Value.Size = New System.Drawing.Size(0, 20)
        Me.PartAmount_Value.TabIndex = 158
        Me.PartAmount_Value.Tag = "dataViewingControl"
        '
        'editMasterTaskPart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(982, 753)
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
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.PartNbr_Textbox)
        Me.Controls.Add(Me.PartNbr_Value)
        Me.Controls.Add(Me.PartNumberLabel)
        Me.Controls.Add(Me.TaskNameLabel)
        Me.Controls.Add(Me.editMasterTaskPartLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "editMasterTaskPart"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Edit Task Part"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents editMasterTaskPartLabel As Label
    Friend WithEvents TaskNameLabel As Label
    Friend WithEvents PartNbr_Textbox As TextBox
    Friend WithEvents PartNbr_Value As Label
    Friend WithEvents PartNumberLabel As Label
    Friend WithEvents saveButton As Button
    Friend WithEvents cancelButton As Button
    Friend WithEvents TaskTextbox As TextBox
    Friend WithEvents PartDescription_Value As Label
    Friend WithEvents PartDescriptionLabel As Label
    Friend WithEvents PartDescription_Textbox As TextBox
    Friend WithEvents ListPrice_Textbox As TextBox
    Friend WithEvents ListPriceLabel As Label
    Friend WithEvents ListPrice_Value As Label
    Friend WithEvents PartPrice_Textbox As TextBox
    Friend WithEvents UnitPriceLabel As Label
    Friend WithEvents PartPrice_Value As Label
    Friend WithEvents Qty_Textbox As TextBox
    Friend WithEvents QuantityLabel As Label
    Friend WithEvents Qty_Value As Label
    Friend WithEvents PartAmount_Textbox As TextBox
    Friend WithEvents TotalLabel As Label
    Friend WithEvents PartAmount_Value As Label
End Class
