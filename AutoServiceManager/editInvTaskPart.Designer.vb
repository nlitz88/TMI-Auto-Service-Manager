<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class editInvTaskPart
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
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.PartNbr_Textbox = New System.Windows.Forms.TextBox()
        Me.PartNbr_Value = New System.Windows.Forms.Label()
        Me.PartNumberLabel = New System.Windows.Forms.Label()
        Me.editInvTaskPartLabel = New System.Windows.Forms.Label()
        Me.TaskValue = New System.Windows.Forms.Label()
        Me.TaskNameLabel = New System.Windows.Forms.Label()
        Me.InvoiceLabel = New System.Windows.Forms.Label()
        Me.InvoiceValue = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'PartAmount_Textbox
        '
        Me.PartAmount_Textbox.Enabled = False
        Me.PartAmount_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartAmount_Textbox.Location = New System.Drawing.Point(554, 412)
        Me.PartAmount_Textbox.Name = "PartAmount_Textbox"
        Me.PartAmount_Textbox.Size = New System.Drawing.Size(105, 27)
        Me.PartAmount_Textbox.TabIndex = 180
        Me.PartAmount_Textbox.Tag = "dataEditingControl"
        '
        'TotalLabel
        '
        Me.TotalLabel.AutoSize = True
        Me.TotalLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TotalLabel.Location = New System.Drawing.Point(500, 418)
        Me.TotalLabel.Name = "TotalLabel"
        Me.TotalLabel.Size = New System.Drawing.Size(48, 17)
        Me.TotalLabel.TabIndex = 182
        Me.TotalLabel.Tag = "dataLabel"
        Me.TotalLabel.Text = "Total :"
        '
        'PartAmount_Value
        '
        Me.PartAmount_Value.AutoSize = True
        Me.PartAmount_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartAmount_Value.ForeColor = System.Drawing.Color.Black
        Me.PartAmount_Value.Location = New System.Drawing.Point(554, 415)
        Me.PartAmount_Value.Name = "PartAmount_Value"
        Me.PartAmount_Value.Size = New System.Drawing.Size(0, 20)
        Me.PartAmount_Value.TabIndex = 181
        Me.PartAmount_Value.Tag = "dataViewingControl"
        '
        'Qty_Textbox
        '
        Me.Qty_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Qty_Textbox.Location = New System.Drawing.Point(172, 412)
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
        Me.QuantityLabel.Location = New System.Drawing.Point(97, 418)
        Me.QuantityLabel.Name = "QuantityLabel"
        Me.QuantityLabel.Size = New System.Drawing.Size(69, 17)
        Me.QuantityLabel.TabIndex = 179
        Me.QuantityLabel.Tag = "dataLabel"
        Me.QuantityLabel.Text = "Quantity :"
        '
        'Qty_Value
        '
        Me.Qty_Value.AutoSize = True
        Me.Qty_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Qty_Value.ForeColor = System.Drawing.Color.Black
        Me.Qty_Value.Location = New System.Drawing.Point(172, 415)
        Me.Qty_Value.Name = "Qty_Value"
        Me.Qty_Value.Size = New System.Drawing.Size(0, 20)
        Me.Qty_Value.TabIndex = 178
        Me.Qty_Value.Tag = "dataViewingControl"
        '
        'PartDescription_Value
        '
        Me.PartDescription_Value.AutoSize = True
        Me.PartDescription_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartDescription_Value.ForeColor = System.Drawing.Color.Black
        Me.PartDescription_Value.Location = New System.Drawing.Point(220, 365)
        Me.PartDescription_Value.Name = "PartDescription_Value"
        Me.PartDescription_Value.Size = New System.Drawing.Size(0, 20)
        Me.PartDescription_Value.TabIndex = 177
        Me.PartDescription_Value.Tag = "dataViewingControl"
        '
        'PartDescriptionLabel
        '
        Me.PartDescriptionLabel.AutoSize = True
        Me.PartDescriptionLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.PartDescriptionLabel.Location = New System.Drawing.Point(97, 368)
        Me.PartDescriptionLabel.Name = "PartDescriptionLabel"
        Me.PartDescriptionLabel.Size = New System.Drawing.Size(117, 17)
        Me.PartDescriptionLabel.TabIndex = 176
        Me.PartDescriptionLabel.Tag = "dataLabel"
        Me.PartDescriptionLabel.Text = "Part Description :"
        '
        'PartDescription_Textbox
        '
        Me.PartDescription_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartDescription_Textbox.Location = New System.Drawing.Point(220, 362)
        Me.PartDescription_Textbox.MaxLength = 50
        Me.PartDescription_Textbox.Name = "PartDescription_Textbox"
        Me.PartDescription_Textbox.Size = New System.Drawing.Size(297, 27)
        Me.PartDescription_Textbox.TabIndex = 160
        Me.PartDescription_Textbox.Tag = "dataEditingControl"
        '
        'ListPrice_Textbox
        '
        Me.ListPrice_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListPrice_Textbox.Location = New System.Drawing.Point(618, 362)
        Me.ListPrice_Textbox.Name = "ListPrice_Textbox"
        Me.ListPrice_Textbox.Size = New System.Drawing.Size(105, 27)
        Me.ListPrice_Textbox.TabIndex = 161
        Me.ListPrice_Textbox.Tag = "dataEditingControl"
        '
        'ListPriceLabel
        '
        Me.ListPriceLabel.AutoSize = True
        Me.ListPriceLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ListPriceLabel.Location = New System.Drawing.Point(538, 368)
        Me.ListPriceLabel.Name = "ListPriceLabel"
        Me.ListPriceLabel.Size = New System.Drawing.Size(74, 17)
        Me.ListPriceLabel.TabIndex = 175
        Me.ListPriceLabel.Tag = "dataLabel"
        Me.ListPriceLabel.Text = "List Price :"
        '
        'ListPrice_Value
        '
        Me.ListPrice_Value.AutoSize = True
        Me.ListPrice_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListPrice_Value.ForeColor = System.Drawing.Color.Black
        Me.ListPrice_Value.Location = New System.Drawing.Point(618, 365)
        Me.ListPrice_Value.Name = "ListPrice_Value"
        Me.ListPrice_Value.Size = New System.Drawing.Size(0, 20)
        Me.ListPrice_Value.TabIndex = 174
        Me.ListPrice_Value.Tag = "dataViewingControl"
        '
        'PartPrice_Textbox
        '
        Me.PartPrice_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartPrice_Textbox.Location = New System.Drawing.Point(377, 412)
        Me.PartPrice_Textbox.Name = "PartPrice_Textbox"
        Me.PartPrice_Textbox.Size = New System.Drawing.Size(105, 27)
        Me.PartPrice_Textbox.TabIndex = 163
        Me.PartPrice_Textbox.Tag = "dataEditingControl"
        '
        'UnitPriceLabel
        '
        Me.UnitPriceLabel.AutoSize = True
        Me.UnitPriceLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.UnitPriceLabel.Location = New System.Drawing.Point(294, 418)
        Me.UnitPriceLabel.Name = "UnitPriceLabel"
        Me.UnitPriceLabel.Size = New System.Drawing.Size(77, 17)
        Me.UnitPriceLabel.TabIndex = 173
        Me.UnitPriceLabel.Tag = "dataLabel"
        Me.UnitPriceLabel.Text = "Unit Price :"
        '
        'PartPrice_Value
        '
        Me.PartPrice_Value.AutoSize = True
        Me.PartPrice_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartPrice_Value.ForeColor = System.Drawing.Color.Black
        Me.PartPrice_Value.Location = New System.Drawing.Point(377, 415)
        Me.PartPrice_Value.Name = "PartPrice_Value"
        Me.PartPrice_Value.Size = New System.Drawing.Size(0, 20)
        Me.PartPrice_Value.TabIndex = 172
        Me.PartPrice_Value.Tag = "dataViewingControl"
        '
        'cancelButton
        '
        Me.cancelButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cancelButton.ForeColor = System.Drawing.Color.White
        Me.cancelButton.Location = New System.Drawing.Point(216, 120)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(110, 30)
        Me.cancelButton.TabIndex = 164
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
        Me.saveButton.TabIndex = 165
        Me.saveButton.Text = "Save"
        Me.saveButton.UseVisualStyleBackColor = False
        '
        'PartNbr_Textbox
        '
        Me.PartNbr_Textbox.Enabled = False
        Me.PartNbr_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartNbr_Textbox.Location = New System.Drawing.Point(199, 312)
        Me.PartNbr_Textbox.MaxLength = 30
        Me.PartNbr_Textbox.Name = "PartNbr_Textbox"
        Me.PartNbr_Textbox.Size = New System.Drawing.Size(270, 27)
        Me.PartNbr_Textbox.TabIndex = 168
        Me.PartNbr_Textbox.Tag = "dataEditingControl"
        '
        'PartNbr_Value
        '
        Me.PartNbr_Value.AutoSize = True
        Me.PartNbr_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartNbr_Value.ForeColor = System.Drawing.Color.Black
        Me.PartNbr_Value.Location = New System.Drawing.Point(199, 315)
        Me.PartNbr_Value.Name = "PartNbr_Value"
        Me.PartNbr_Value.Size = New System.Drawing.Size(0, 20)
        Me.PartNbr_Value.TabIndex = 170
        Me.PartNbr_Value.Tag = "dataViewingControl"
        '
        'PartNumberLabel
        '
        Me.PartNumberLabel.AutoSize = True
        Me.PartNumberLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.PartNumberLabel.Location = New System.Drawing.Point(97, 318)
        Me.PartNumberLabel.Name = "PartNumberLabel"
        Me.PartNumberLabel.Size = New System.Drawing.Size(96, 17)
        Me.PartNumberLabel.TabIndex = 169
        Me.PartNumberLabel.Tag = "dataLabel"
        Me.PartNumberLabel.Text = "Part Number :"
        '
        'editInvTaskPartLabel
        '
        Me.editInvTaskPartLabel.AutoSize = True
        Me.editInvTaskPartLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.editInvTaskPartLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.editInvTaskPartLabel.Location = New System.Drawing.Point(94, 73)
        Me.editInvTaskPartLabel.Name = "editInvTaskPartLabel"
        Me.editInvTaskPartLabel.Size = New System.Drawing.Size(311, 32)
        Me.editInvTaskPartLabel.TabIndex = 166
        Me.editInvTaskPartLabel.Text = "Edit Invoice Task Part"
        '
        'TaskValue
        '
        Me.TaskValue.AutoSize = True
        Me.TaskValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TaskValue.ForeColor = System.Drawing.Color.Black
        Me.TaskValue.Location = New System.Drawing.Point(150, 244)
        Me.TaskValue.Name = "TaskValue"
        Me.TaskValue.Size = New System.Drawing.Size(0, 20)
        Me.TaskValue.TabIndex = 238
        Me.TaskValue.Tag = ""
        '
        'TaskNameLabel
        '
        Me.TaskNameLabel.AutoSize = True
        Me.TaskNameLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TaskNameLabel.Location = New System.Drawing.Point(97, 247)
        Me.TaskNameLabel.Name = "TaskNameLabel"
        Me.TaskNameLabel.Size = New System.Drawing.Size(47, 17)
        Me.TaskNameLabel.TabIndex = 237
        Me.TaskNameLabel.Text = "Task :"
        '
        'InvoiceLabel
        '
        Me.InvoiceLabel.AutoSize = True
        Me.InvoiceLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.InvoiceLabel.Location = New System.Drawing.Point(97, 202)
        Me.InvoiceLabel.Name = "InvoiceLabel"
        Me.InvoiceLabel.Size = New System.Drawing.Size(60, 17)
        Me.InvoiceLabel.TabIndex = 236
        Me.InvoiceLabel.Tag = ""
        Me.InvoiceLabel.Text = "Invoice :"
        '
        'InvoiceValue
        '
        Me.InvoiceValue.AutoSize = True
        Me.InvoiceValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InvoiceValue.ForeColor = System.Drawing.Color.Black
        Me.InvoiceValue.Location = New System.Drawing.Point(163, 199)
        Me.InvoiceValue.Name = "InvoiceValue"
        Me.InvoiceValue.Size = New System.Drawing.Size(0, 20)
        Me.InvoiceValue.TabIndex = 235
        Me.InvoiceValue.Tag = ""
        '
        'editInvTaskPart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(982, 753)
        Me.Controls.Add(Me.TaskValue)
        Me.Controls.Add(Me.TaskNameLabel)
        Me.Controls.Add(Me.InvoiceLabel)
        Me.Controls.Add(Me.InvoiceValue)
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
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.PartNbr_Textbox)
        Me.Controls.Add(Me.PartNbr_Value)
        Me.Controls.Add(Me.PartNumberLabel)
        Me.Controls.Add(Me.editInvTaskPartLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "editInvTaskPart"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Edit Invoice Task Part"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

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
    Friend WithEvents cancelButton As Button
    Friend WithEvents saveButton As Button
    Friend WithEvents PartNbr_Textbox As TextBox
    Friend WithEvents PartNbr_Value As Label
    Friend WithEvents PartNumberLabel As Label
    Friend WithEvents editInvTaskPartLabel As Label
    Friend WithEvents TaskValue As Label
    Friend WithEvents TaskNameLabel As Label
    Friend WithEvents InvoiceLabel As Label
    Friend WithEvents InvoiceValue As Label
End Class
