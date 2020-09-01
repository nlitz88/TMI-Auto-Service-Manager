<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class invoicePayments
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
        Me.deleteButton = New System.Windows.Forms.Button()
        Me.invPaymentsLabel = New System.Windows.Forms.Label()
        Me.editButton = New System.Windows.Forms.Button()
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.addButton = New System.Windows.Forms.Button()
        Me.InvoiceLabel = New System.Windows.Forms.Label()
        Me.InvoiceValue = New System.Windows.Forms.Label()
        Me.BalanceValue = New System.Windows.Forms.Label()
        Me.BalanceLabel = New System.Windows.Forms.Label()
        Me.PaymentComboLabel = New System.Windows.Forms.Label()
        Me.PaymentComboBox = New System.Windows.Forms.ComboBox()
        Me.PayDate_Textbox = New System.Windows.Forms.MaskedTextBox()
        Me.PayDate_Value = New System.Windows.Forms.Label()
        Me.PaymentDateLabel = New System.Windows.Forms.Label()
        Me.PaymentTypeLabel = New System.Windows.Forms.Label()
        Me.PayType_ComboBox = New System.Windows.Forms.ComboBox()
        Me.PayAmount_Textbox = New System.Windows.Forms.TextBox()
        Me.AmountLabel = New System.Windows.Forms.Label()
        Me.PayAmount_Value = New System.Windows.Forms.Label()
        Me.PaymentNotes_Textbox = New System.Windows.Forms.TextBox()
        Me.PaymentNotes_Value = New System.Windows.Forms.Label()
        Me.PaymentNotesLabel = New System.Windows.Forms.Label()
        Me.CreditCardTypeLabel = New System.Windows.Forms.Label()
        Me.CreditCardType_ComboBox = New System.Windows.Forms.ComboBox()
        Me.CreditCardType_Value = New System.Windows.Forms.Label()
        Me.CheckNumber_Textbox = New System.Windows.Forms.TextBox()
        Me.CheckNumberLabel = New System.Windows.Forms.Label()
        Me.CheckNumber_Value = New System.Windows.Forms.Label()
        Me.PayType_Value = New System.Windows.Forms.Label()
        Me.returnButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
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
        'invPaymentsLabel
        '
        Me.invPaymentsLabel.AutoSize = True
        Me.invPaymentsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.invPaymentsLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.invPaymentsLabel.Location = New System.Drawing.Point(94, 73)
        Me.invPaymentsLabel.Name = "invPaymentsLabel"
        Me.invPaymentsLabel.Size = New System.Drawing.Size(254, 32)
        Me.invPaymentsLabel.TabIndex = 129
        Me.invPaymentsLabel.Text = "Invoice Payments"
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
        Me.cancelButton.Location = New System.Drawing.Point(564, 120)
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
        'InvoiceLabel
        '
        Me.InvoiceLabel.AutoSize = True
        Me.InvoiceLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.InvoiceLabel.Location = New System.Drawing.Point(97, 202)
        Me.InvoiceLabel.Name = "InvoiceLabel"
        Me.InvoiceLabel.Size = New System.Drawing.Size(60, 17)
        Me.InvoiceLabel.TabIndex = 234
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
        Me.InvoiceValue.TabIndex = 233
        Me.InvoiceValue.Tag = ""
        '
        'BalanceValue
        '
        Me.BalanceValue.AutoSize = True
        Me.BalanceValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BalanceValue.ForeColor = System.Drawing.Color.Black
        Me.BalanceValue.Location = New System.Drawing.Point(170, 244)
        Me.BalanceValue.Name = "BalanceValue"
        Me.BalanceValue.Size = New System.Drawing.Size(0, 20)
        Me.BalanceValue.TabIndex = 236
        Me.BalanceValue.Tag = ""
        '
        'BalanceLabel
        '
        Me.BalanceLabel.AutoSize = True
        Me.BalanceLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BalanceLabel.Location = New System.Drawing.Point(97, 247)
        Me.BalanceLabel.Name = "BalanceLabel"
        Me.BalanceLabel.Size = New System.Drawing.Size(67, 17)
        Me.BalanceLabel.TabIndex = 235
        Me.BalanceLabel.Text = "Balance :"
        '
        'PaymentComboLabel
        '
        Me.PaymentComboLabel.AutoSize = True
        Me.PaymentComboLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.PaymentComboLabel.Location = New System.Drawing.Point(97, 305)
        Me.PaymentComboLabel.Name = "PaymentComboLabel"
        Me.PaymentComboLabel.Size = New System.Drawing.Size(71, 17)
        Me.PaymentComboLabel.TabIndex = 238
        Me.PaymentComboLabel.Text = "Payment :"
        '
        'PaymentComboBox
        '
        Me.PaymentComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.PaymentComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.PaymentComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.PaymentComboBox.FormattingEnabled = True
        Me.PaymentComboBox.Location = New System.Drawing.Point(174, 299)
        Me.PaymentComboBox.Name = "PaymentComboBox"
        Me.PaymentComboBox.Size = New System.Drawing.Size(362, 28)
        Me.PaymentComboBox.TabIndex = 237
        '
        'PayDate_Textbox
        '
        Me.PayDate_Textbox.AllowPromptAsInput = False
        Me.PayDate_Textbox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.PayDate_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.PayDate_Textbox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert
        Me.PayDate_Textbox.Location = New System.Drawing.Point(216, 362)
        Me.PayDate_Textbox.Mask = "00/00/0000"
        Me.PayDate_Textbox.Name = "PayDate_Textbox"
        Me.PayDate_Textbox.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.PayDate_Textbox.Size = New System.Drawing.Size(132, 27)
        Me.PayDate_Textbox.TabIndex = 278
        Me.PayDate_Textbox.Tag = "dataEditingControl"
        Me.PayDate_Textbox.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.PayDate_Textbox.ValidatingType = GetType(Date)
        '
        'PayDate_Value
        '
        Me.PayDate_Value.AutoSize = True
        Me.PayDate_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PayDate_Value.ForeColor = System.Drawing.Color.Black
        Me.PayDate_Value.Location = New System.Drawing.Point(215, 365)
        Me.PayDate_Value.Name = "PayDate_Value"
        Me.PayDate_Value.Size = New System.Drawing.Size(0, 20)
        Me.PayDate_Value.TabIndex = 280
        Me.PayDate_Value.Tag = "dataViewingControl"
        '
        'PaymentDateLabel
        '
        Me.PaymentDateLabel.AutoSize = True
        Me.PaymentDateLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.PaymentDateLabel.Location = New System.Drawing.Point(97, 368)
        Me.PaymentDateLabel.Name = "PaymentDateLabel"
        Me.PaymentDateLabel.Size = New System.Drawing.Size(105, 17)
        Me.PaymentDateLabel.TabIndex = 279
        Me.PaymentDateLabel.Tag = "dataLabel"
        Me.PaymentDateLabel.Text = "Payment Date :"
        '
        'PaymentTypeLabel
        '
        Me.PaymentTypeLabel.AutoSize = True
        Me.PaymentTypeLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.PaymentTypeLabel.Location = New System.Drawing.Point(97, 414)
        Me.PaymentTypeLabel.Name = "PaymentTypeLabel"
        Me.PaymentTypeLabel.Size = New System.Drawing.Size(107, 17)
        Me.PaymentTypeLabel.TabIndex = 282
        Me.PaymentTypeLabel.Tag = "dataLabel"
        Me.PaymentTypeLabel.Text = "Payment Type :"
        '
        'PayType_ComboBox
        '
        Me.PayType_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.PayType_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.PayType_ComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.PayType_ComboBox.FormattingEnabled = True
        Me.PayType_ComboBox.Location = New System.Drawing.Point(210, 408)
        Me.PayType_ComboBox.Name = "PayType_ComboBox"
        Me.PayType_ComboBox.Size = New System.Drawing.Size(138, 28)
        Me.PayType_ComboBox.TabIndex = 281
        Me.PayType_ComboBox.Tag = "dataEditingControl"
        '
        'PayAmount_Textbox
        '
        Me.PayAmount_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PayAmount_Textbox.Location = New System.Drawing.Point(167, 454)
        Me.PayAmount_Textbox.Name = "PayAmount_Textbox"
        Me.PayAmount_Textbox.Size = New System.Drawing.Size(138, 27)
        Me.PayAmount_Textbox.TabIndex = 283
        Me.PayAmount_Textbox.Tag = "dataEditingControl"
        '
        'AmountLabel
        '
        Me.AmountLabel.AutoSize = True
        Me.AmountLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.AmountLabel.Location = New System.Drawing.Point(97, 460)
        Me.AmountLabel.Name = "AmountLabel"
        Me.AmountLabel.Size = New System.Drawing.Size(64, 17)
        Me.AmountLabel.TabIndex = 285
        Me.AmountLabel.Tag = "dataLabel"
        Me.AmountLabel.Text = "Amount :"
        '
        'PayAmount_Value
        '
        Me.PayAmount_Value.AutoSize = True
        Me.PayAmount_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PayAmount_Value.ForeColor = System.Drawing.Color.Black
        Me.PayAmount_Value.Location = New System.Drawing.Point(167, 457)
        Me.PayAmount_Value.Name = "PayAmount_Value"
        Me.PayAmount_Value.Size = New System.Drawing.Size(0, 20)
        Me.PayAmount_Value.TabIndex = 284
        Me.PayAmount_Value.Tag = "dataViewingControl"
        '
        'PaymentNotes_Textbox
        '
        Me.PaymentNotes_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaymentNotes_Textbox.Location = New System.Drawing.Point(215, 499)
        Me.PaymentNotes_Textbox.MaxLength = 255
        Me.PaymentNotes_Textbox.Multiline = True
        Me.PaymentNotes_Textbox.Name = "PaymentNotes_Textbox"
        Me.PaymentNotes_Textbox.Size = New System.Drawing.Size(459, 105)
        Me.PaymentNotes_Textbox.TabIndex = 305
        Me.PaymentNotes_Textbox.Tag = "dataEditingControl"
        '
        'PaymentNotes_Value
        '
        Me.PaymentNotes_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaymentNotes_Value.ForeColor = System.Drawing.Color.Black
        Me.PaymentNotes_Value.Location = New System.Drawing.Point(215, 502)
        Me.PaymentNotes_Value.Name = "PaymentNotes_Value"
        Me.PaymentNotes_Value.Size = New System.Drawing.Size(459, 101)
        Me.PaymentNotes_Value.TabIndex = 307
        Me.PaymentNotes_Value.Tag = "dataViewingControl"
        '
        'PaymentNotesLabel
        '
        Me.PaymentNotesLabel.AutoSize = True
        Me.PaymentNotesLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.PaymentNotesLabel.Location = New System.Drawing.Point(97, 505)
        Me.PaymentNotesLabel.Name = "PaymentNotesLabel"
        Me.PaymentNotesLabel.Size = New System.Drawing.Size(112, 17)
        Me.PaymentNotesLabel.TabIndex = 306
        Me.PaymentNotesLabel.Tag = "dataLabel"
        Me.PaymentNotesLabel.Text = "Payment Notes :"
        '
        'CreditCardTypeLabel
        '
        Me.CreditCardTypeLabel.AutoSize = True
        Me.CreditCardTypeLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.CreditCardTypeLabel.Location = New System.Drawing.Point(379, 414)
        Me.CreditCardTypeLabel.Name = "CreditCardTypeLabel"
        Me.CreditCardTypeLabel.Size = New System.Drawing.Size(87, 17)
        Me.CreditCardTypeLabel.TabIndex = 309
        Me.CreditCardTypeLabel.Tag = "dataLabel"
        Me.CreditCardTypeLabel.Text = "Credit Card :"
        Me.CreditCardTypeLabel.Visible = False
        '
        'CreditCardType_ComboBox
        '
        Me.CreditCardType_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CreditCardType_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CreditCardType_ComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.CreditCardType_ComboBox.FormattingEnabled = True
        Me.CreditCardType_ComboBox.Location = New System.Drawing.Point(472, 408)
        Me.CreditCardType_ComboBox.Name = "CreditCardType_ComboBox"
        Me.CreditCardType_ComboBox.Size = New System.Drawing.Size(138, 28)
        Me.CreditCardType_ComboBox.TabIndex = 308
        Me.CreditCardType_ComboBox.Tag = "dataEditingControl"
        Me.CreditCardType_ComboBox.Visible = False
        '
        'CreditCardType_Value
        '
        Me.CreditCardType_Value.AutoSize = True
        Me.CreditCardType_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CreditCardType_Value.ForeColor = System.Drawing.Color.Black
        Me.CreditCardType_Value.Location = New System.Drawing.Point(472, 411)
        Me.CreditCardType_Value.Name = "CreditCardType_Value"
        Me.CreditCardType_Value.Size = New System.Drawing.Size(0, 20)
        Me.CreditCardType_Value.TabIndex = 310
        Me.CreditCardType_Value.Tag = "dataViewingControl"
        Me.CreditCardType_Value.Visible = False
        '
        'CheckNumber_Textbox
        '
        Me.CheckNumber_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckNumber_Textbox.Location = New System.Drawing.Point(494, 408)
        Me.CheckNumber_Textbox.Name = "CheckNumber_Textbox"
        Me.CheckNumber_Textbox.Size = New System.Drawing.Size(138, 27)
        Me.CheckNumber_Textbox.TabIndex = 311
        Me.CheckNumber_Textbox.Tag = "dataEditingControl"
        Me.CheckNumber_Textbox.Visible = False
        '
        'CheckNumberLabel
        '
        Me.CheckNumberLabel.AutoSize = True
        Me.CheckNumberLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.CheckNumberLabel.Location = New System.Drawing.Point(379, 414)
        Me.CheckNumberLabel.Name = "CheckNumberLabel"
        Me.CheckNumberLabel.Size = New System.Drawing.Size(109, 17)
        Me.CheckNumberLabel.TabIndex = 313
        Me.CheckNumberLabel.Tag = "dataLabel"
        Me.CheckNumberLabel.Text = "Check Number :"
        Me.CheckNumberLabel.Visible = False
        '
        'CheckNumber_Value
        '
        Me.CheckNumber_Value.AutoSize = True
        Me.CheckNumber_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckNumber_Value.ForeColor = System.Drawing.Color.Black
        Me.CheckNumber_Value.Location = New System.Drawing.Point(494, 411)
        Me.CheckNumber_Value.Name = "CheckNumber_Value"
        Me.CheckNumber_Value.Size = New System.Drawing.Size(0, 20)
        Me.CheckNumber_Value.TabIndex = 312
        Me.CheckNumber_Value.Tag = "dataViewingControl"
        Me.CheckNumber_Value.Visible = False
        '
        'PayType_Value
        '
        Me.PayType_Value.AutoSize = True
        Me.PayType_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PayType_Value.ForeColor = System.Drawing.Color.Black
        Me.PayType_Value.Location = New System.Drawing.Point(210, 411)
        Me.PayType_Value.Name = "PayType_Value"
        Me.PayType_Value.Size = New System.Drawing.Size(0, 20)
        Me.PayType_Value.TabIndex = 314
        Me.PayType_Value.Tag = "dataViewingControl"
        '
        'returnButton
        '
        Me.returnButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.returnButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.returnButton.ForeColor = System.Drawing.Color.White
        Me.returnButton.Location = New System.Drawing.Point(680, 120)
        Me.returnButton.Name = "returnButton"
        Me.returnButton.Size = New System.Drawing.Size(197, 30)
        Me.returnButton.TabIndex = 315
        Me.returnButton.Text = "Return To Invoice"
        Me.returnButton.UseVisualStyleBackColor = False
        '
        'invoicePayments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(982, 753)
        Me.Controls.Add(Me.returnButton)
        Me.Controls.Add(Me.PayType_Value)
        Me.Controls.Add(Me.CheckNumber_Textbox)
        Me.Controls.Add(Me.CheckNumberLabel)
        Me.Controls.Add(Me.CheckNumber_Value)
        Me.Controls.Add(Me.CreditCardType_Value)
        Me.Controls.Add(Me.CreditCardTypeLabel)
        Me.Controls.Add(Me.CreditCardType_ComboBox)
        Me.Controls.Add(Me.PaymentNotes_Textbox)
        Me.Controls.Add(Me.PaymentNotes_Value)
        Me.Controls.Add(Me.PaymentNotesLabel)
        Me.Controls.Add(Me.PayAmount_Textbox)
        Me.Controls.Add(Me.AmountLabel)
        Me.Controls.Add(Me.PayAmount_Value)
        Me.Controls.Add(Me.PaymentTypeLabel)
        Me.Controls.Add(Me.PayType_ComboBox)
        Me.Controls.Add(Me.PayDate_Textbox)
        Me.Controls.Add(Me.PayDate_Value)
        Me.Controls.Add(Me.PaymentDateLabel)
        Me.Controls.Add(Me.PaymentComboLabel)
        Me.Controls.Add(Me.PaymentComboBox)
        Me.Controls.Add(Me.BalanceValue)
        Me.Controls.Add(Me.BalanceLabel)
        Me.Controls.Add(Me.InvoiceLabel)
        Me.Controls.Add(Me.InvoiceValue)
        Me.Controls.Add(Me.deleteButton)
        Me.Controls.Add(Me.invPaymentsLabel)
        Me.Controls.Add(Me.editButton)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.addButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "invoicePayments"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Invoice Payments"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents deleteButton As Button
    Friend WithEvents invPaymentsLabel As Label
    Friend WithEvents editButton As Button
    Friend WithEvents cancelButton As Button
    Friend WithEvents saveButton As Button
    Friend WithEvents addButton As Button
    Friend WithEvents InvoiceLabel As Label
    Friend WithEvents InvoiceValue As Label
    Friend WithEvents BalanceValue As Label
    Friend WithEvents BalanceLabel As Label
    Friend WithEvents PaymentComboLabel As Label
    Friend WithEvents PaymentComboBox As ComboBox
    Friend WithEvents PayDate_Textbox As MaskedTextBox
    Friend WithEvents PayDate_Value As Label
    Friend WithEvents PaymentDateLabel As Label
    Friend WithEvents PaymentTypeLabel As Label
    Friend WithEvents PayType_ComboBox As ComboBox
    Friend WithEvents PayAmount_Textbox As TextBox
    Friend WithEvents AmountLabel As Label
    Friend WithEvents PayAmount_Value As Label
    Friend WithEvents PaymentNotes_Textbox As TextBox
    Friend WithEvents PaymentNotes_Value As Label
    Friend WithEvents PaymentNotesLabel As Label
    Friend WithEvents CreditCardTypeLabel As Label
    Friend WithEvents CreditCardType_ComboBox As ComboBox
    Friend WithEvents CreditCardType_Value As Label
    Friend WithEvents CheckNumber_Textbox As TextBox
    Friend WithEvents CheckNumberLabel As Label
    Friend WithEvents CheckNumber_Value As Label
    Friend WithEvents PayType_Value As Label
    Friend WithEvents returnButton As Button
End Class
