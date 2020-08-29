<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class editInvTaskLabor
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
        Me.Amount_Textbox = New System.Windows.Forms.TextBox()
        Me.AmountLabel = New System.Windows.Forms.Label()
        Me.Amount_Value = New System.Windows.Forms.Label()
        Me.Description_Value = New System.Windows.Forms.Label()
        Me.DescriptionLabel = New System.Windows.Forms.Label()
        Me.Description_Textbox = New System.Windows.Forms.TextBox()
        Me.Hours_Textbox = New System.Windows.Forms.TextBox()
        Me.HoursLabel = New System.Windows.Forms.Label()
        Me.Hours_Value = New System.Windows.Forms.Label()
        Me.Rate_Textbox = New System.Windows.Forms.TextBox()
        Me.RateLabel = New System.Windows.Forms.Label()
        Me.Rate_Value = New System.Windows.Forms.Label()
        Me.LaborCode_Textbox = New System.Windows.Forms.TextBox()
        Me.LaborCode_Value = New System.Windows.Forms.Label()
        Me.LaborCodeLabel = New System.Windows.Forms.Label()
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.editInvTaskLaborLabel = New System.Windows.Forms.Label()
        Me.TaskValue = New System.Windows.Forms.Label()
        Me.TaskNameLabel = New System.Windows.Forms.Label()
        Me.InvoiceLabel = New System.Windows.Forms.Label()
        Me.InvoiceValue = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Amount_Textbox
        '
        Me.Amount_Textbox.Enabled = False
        Me.Amount_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Amount_Textbox.Location = New System.Drawing.Point(518, 414)
        Me.Amount_Textbox.Name = "Amount_Textbox"
        Me.Amount_Textbox.Size = New System.Drawing.Size(105, 27)
        Me.Amount_Textbox.TabIndex = 215
        Me.Amount_Textbox.Tag = "dataEditingControl"
        '
        'AmountLabel
        '
        Me.AmountLabel.AutoSize = True
        Me.AmountLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.AmountLabel.Location = New System.Drawing.Point(464, 420)
        Me.AmountLabel.Name = "AmountLabel"
        Me.AmountLabel.Size = New System.Drawing.Size(48, 17)
        Me.AmountLabel.TabIndex = 217
        Me.AmountLabel.Tag = "dataLabel"
        Me.AmountLabel.Text = "Total :"
        '
        'Amount_Value
        '
        Me.Amount_Value.AutoSize = True
        Me.Amount_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Amount_Value.ForeColor = System.Drawing.Color.Black
        Me.Amount_Value.Location = New System.Drawing.Point(518, 417)
        Me.Amount_Value.Name = "Amount_Value"
        Me.Amount_Value.Size = New System.Drawing.Size(0, 20)
        Me.Amount_Value.TabIndex = 216
        Me.Amount_Value.Tag = "dataViewingControl"
        '
        'Description_Value
        '
        Me.Description_Value.AutoSize = True
        Me.Description_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Description_Value.ForeColor = System.Drawing.Color.Black
        Me.Description_Value.Location = New System.Drawing.Point(190, 367)
        Me.Description_Value.Name = "Description_Value"
        Me.Description_Value.Size = New System.Drawing.Size(0, 20)
        Me.Description_Value.TabIndex = 214
        Me.Description_Value.Tag = "dataViewingControl"
        '
        'DescriptionLabel
        '
        Me.DescriptionLabel.AutoSize = True
        Me.DescriptionLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.DescriptionLabel.Location = New System.Drawing.Point(97, 370)
        Me.DescriptionLabel.Name = "DescriptionLabel"
        Me.DescriptionLabel.Size = New System.Drawing.Size(87, 17)
        Me.DescriptionLabel.TabIndex = 213
        Me.DescriptionLabel.Tag = "dataLabel"
        Me.DescriptionLabel.Text = "Description :"
        '
        'Description_Textbox
        '
        Me.Description_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Description_Textbox.Location = New System.Drawing.Point(190, 364)
        Me.Description_Textbox.MaxLength = 100
        Me.Description_Textbox.Name = "Description_Textbox"
        Me.Description_Textbox.Size = New System.Drawing.Size(662, 27)
        Me.Description_Textbox.TabIndex = 204
        Me.Description_Textbox.Tag = "dataEditingControl"
        '
        'Hours_Textbox
        '
        Me.Hours_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Hours_Textbox.Location = New System.Drawing.Point(333, 414)
        Me.Hours_Textbox.MaxLength = 14
        Me.Hours_Textbox.Name = "Hours_Textbox"
        Me.Hours_Textbox.Size = New System.Drawing.Size(105, 27)
        Me.Hours_Textbox.TabIndex = 206
        Me.Hours_Textbox.Tag = "dataEditingControl"
        '
        'HoursLabel
        '
        Me.HoursLabel.AutoSize = True
        Me.HoursLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.HoursLabel.Location = New System.Drawing.Point(273, 420)
        Me.HoursLabel.Name = "HoursLabel"
        Me.HoursLabel.Size = New System.Drawing.Size(54, 17)
        Me.HoursLabel.TabIndex = 212
        Me.HoursLabel.Tag = "dataLabel"
        Me.HoursLabel.Text = "Hours :"
        '
        'Hours_Value
        '
        Me.Hours_Value.AutoSize = True
        Me.Hours_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Hours_Value.ForeColor = System.Drawing.Color.Black
        Me.Hours_Value.Location = New System.Drawing.Point(333, 417)
        Me.Hours_Value.Name = "Hours_Value"
        Me.Hours_Value.Size = New System.Drawing.Size(0, 20)
        Me.Hours_Value.TabIndex = 211
        Me.Hours_Value.Tag = "dataViewingControl"
        '
        'Rate_Textbox
        '
        Me.Rate_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rate_Textbox.Location = New System.Drawing.Point(149, 414)
        Me.Rate_Textbox.Name = "Rate_Textbox"
        Me.Rate_Textbox.Size = New System.Drawing.Size(105, 27)
        Me.Rate_Textbox.TabIndex = 205
        Me.Rate_Textbox.Tag = "dataEditingControl"
        '
        'RateLabel
        '
        Me.RateLabel.AutoSize = True
        Me.RateLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.RateLabel.Location = New System.Drawing.Point(97, 420)
        Me.RateLabel.Name = "RateLabel"
        Me.RateLabel.Size = New System.Drawing.Size(46, 17)
        Me.RateLabel.TabIndex = 210
        Me.RateLabel.Tag = "dataLabel"
        Me.RateLabel.Text = "Rate :"
        '
        'Rate_Value
        '
        Me.Rate_Value.AutoSize = True
        Me.Rate_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rate_Value.ForeColor = System.Drawing.Color.Black
        Me.Rate_Value.Location = New System.Drawing.Point(149, 417)
        Me.Rate_Value.Name = "Rate_Value"
        Me.Rate_Value.Size = New System.Drawing.Size(0, 20)
        Me.Rate_Value.TabIndex = 209
        Me.Rate_Value.Tag = "dataViewingControl"
        '
        'LaborCode_Textbox
        '
        Me.LaborCode_Textbox.Enabled = False
        Me.LaborCode_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LaborCode_Textbox.Location = New System.Drawing.Point(193, 314)
        Me.LaborCode_Textbox.MaxLength = 15
        Me.LaborCode_Textbox.Name = "LaborCode_Textbox"
        Me.LaborCode_Textbox.Size = New System.Drawing.Size(270, 27)
        Me.LaborCode_Textbox.TabIndex = 203
        Me.LaborCode_Textbox.Tag = "dataEditingControl"
        '
        'LaborCode_Value
        '
        Me.LaborCode_Value.AutoSize = True
        Me.LaborCode_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LaborCode_Value.ForeColor = System.Drawing.Color.Black
        Me.LaborCode_Value.Location = New System.Drawing.Point(193, 317)
        Me.LaborCode_Value.Name = "LaborCode_Value"
        Me.LaborCode_Value.Size = New System.Drawing.Size(0, 20)
        Me.LaborCode_Value.TabIndex = 208
        Me.LaborCode_Value.Tag = "dataViewingControl"
        '
        'LaborCodeLabel
        '
        Me.LaborCodeLabel.AutoSize = True
        Me.LaborCodeLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.LaborCodeLabel.Location = New System.Drawing.Point(97, 320)
        Me.LaborCodeLabel.Name = "LaborCodeLabel"
        Me.LaborCodeLabel.Size = New System.Drawing.Size(90, 17)
        Me.LaborCodeLabel.TabIndex = 207
        Me.LaborCodeLabel.Tag = "dataLabel"
        Me.LaborCodeLabel.Text = "Labor Code :"
        '
        'cancelButton
        '
        Me.cancelButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cancelButton.ForeColor = System.Drawing.Color.White
        Me.cancelButton.Location = New System.Drawing.Point(216, 120)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(110, 30)
        Me.cancelButton.TabIndex = 198
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
        Me.saveButton.TabIndex = 199
        Me.saveButton.Text = "Save"
        Me.saveButton.UseVisualStyleBackColor = False
        '
        'editInvTaskLaborLabel
        '
        Me.editInvTaskLaborLabel.AutoSize = True
        Me.editInvTaskLaborLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.editInvTaskLaborLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.editInvTaskLaborLabel.Location = New System.Drawing.Point(94, 73)
        Me.editInvTaskLaborLabel.Name = "editInvTaskLaborLabel"
        Me.editInvTaskLaborLabel.Size = New System.Drawing.Size(228, 32)
        Me.editInvTaskLaborLabel.TabIndex = 200
        Me.editInvTaskLaborLabel.Text = "Edit Task Labor"
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
        'editInvTaskLabor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(982, 753)
        Me.Controls.Add(Me.TaskValue)
        Me.Controls.Add(Me.TaskNameLabel)
        Me.Controls.Add(Me.InvoiceLabel)
        Me.Controls.Add(Me.InvoiceValue)
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
        Me.Controls.Add(Me.LaborCode_Textbox)
        Me.Controls.Add(Me.LaborCode_Value)
        Me.Controls.Add(Me.LaborCodeLabel)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.editInvTaskLaborLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "editInvTaskLabor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Edit Invoice Task Labor"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Amount_Textbox As TextBox
    Friend WithEvents AmountLabel As Label
    Friend WithEvents Amount_Value As Label
    Friend WithEvents Description_Value As Label
    Friend WithEvents DescriptionLabel As Label
    Friend WithEvents Description_Textbox As TextBox
    Friend WithEvents Hours_Textbox As TextBox
    Friend WithEvents HoursLabel As Label
    Friend WithEvents Hours_Value As Label
    Friend WithEvents Rate_Textbox As TextBox
    Friend WithEvents RateLabel As Label
    Friend WithEvents Rate_Value As Label
    Friend WithEvents LaborCode_Textbox As TextBox
    Friend WithEvents LaborCode_Value As Label
    Friend WithEvents LaborCodeLabel As Label
    Friend WithEvents cancelButton As Button
    Friend WithEvents saveButton As Button
    Friend WithEvents editInvTaskLaborLabel As Label
    Friend WithEvents TaskValue As Label
    Friend WithEvents TaskNameLabel As Label
    Friend WithEvents InvoiceLabel As Label
    Friend WithEvents InvoiceValue As Label
End Class
