<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class invoices
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
        Me.invoiceMaintenanceLabel = New System.Windows.Forms.Label()
        Me.editButton = New System.Windows.Forms.Button()
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.addButton = New System.Windows.Forms.Button()
        Me.invoiceNumLabel = New System.Windows.Forms.Label()
        Me.invoiceNumComboBox = New System.Windows.Forms.ComboBox()
        Me.CustomerComboLabel = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.invDate_Textbox = New System.Windows.Forms.MaskedTextBox()
        Me.invDate_Value = New System.Windows.Forms.Label()
        Me.InvoiceDateLabel = New System.Windows.Forms.Label()
        Me.invNbr_Value = New System.Windows.Forms.Label()
        Me.InvoiceNumberLabel = New System.Windows.Forms.Label()
        Me.invNbr_Textbox = New System.Windows.Forms.TextBox()
        Me.Complete_Value = New System.Windows.Forms.Label()
        Me.Complete_CheckBox = New System.Windows.Forms.CheckBox()
        Me.CompleteLabel = New System.Windows.Forms.Label()
        Me.ContactName_Value = New System.Windows.Forms.Label()
        Me.ContactLabel = New System.Windows.Forms.Label()
        Me.ContactName_Textbox = New System.Windows.Forms.TextBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Phone1Label = New System.Windows.Forms.Label()
        Me.ContactPhone1_ComboBox = New System.Windows.Forms.ComboBox()
        Me.ContactPhone1_Value = New System.Windows.Forms.Label()
        Me.ContactPhone2_Value = New System.Windows.Forms.Label()
        Me.Phone2Label = New System.Windows.Forms.Label()
        Me.ContactPhone2_ComboBox = New System.Windows.Forms.ComboBox()
        Me.VehicleLabel = New System.Windows.Forms.Label()
        Me.VehicleComboBox = New System.Windows.Forms.ComboBox()
        Me.nav = New AutoServiceManager.navigation()
        Me.Mileage_Value = New System.Windows.Forms.Label()
        Me.MileageLabel = New System.Windows.Forms.Label()
        Me.Mileage_Textbox = New System.Windows.Forms.TextBox()
        Me.vehicleHistoryButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'deleteButton
        '
        Me.deleteButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.deleteButton.Enabled = False
        Me.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.deleteButton.ForeColor = System.Drawing.Color.White
        Me.deleteButton.Location = New System.Drawing.Point(376, 120)
        Me.deleteButton.Name = "deleteButton"
        Me.deleteButton.Size = New System.Drawing.Size(132, 30)
        Me.deleteButton.TabIndex = 131
        Me.deleteButton.Text = "Delete Invoice"
        Me.deleteButton.UseVisualStyleBackColor = False
        '
        'invoiceMaintenanceLabel
        '
        Me.invoiceMaintenanceLabel.AutoSize = True
        Me.invoiceMaintenanceLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.invoiceMaintenanceLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.invoiceMaintenanceLabel.Location = New System.Drawing.Point(94, 73)
        Me.invoiceMaintenanceLabel.Name = "invoiceMaintenanceLabel"
        Me.invoiceMaintenanceLabel.Size = New System.Drawing.Size(127, 32)
        Me.invoiceMaintenanceLabel.TabIndex = 135
        Me.invoiceMaintenanceLabel.Text = "Invoices"
        '
        'editButton
        '
        Me.editButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.editButton.Enabled = False
        Me.editButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.editButton.ForeColor = System.Drawing.Color.White
        Me.editButton.Location = New System.Drawing.Point(238, 120)
        Me.editButton.Name = "editButton"
        Me.editButton.Size = New System.Drawing.Size(132, 30)
        Me.editButton.TabIndex = 132
        Me.editButton.Text = "Modify Invoice"
        Me.editButton.UseVisualStyleBackColor = False
        '
        'cancelButton
        '
        Me.cancelButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.cancelButton.Enabled = False
        Me.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cancelButton.ForeColor = System.Drawing.Color.White
        Me.cancelButton.Location = New System.Drawing.Point(652, 120)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(132, 30)
        Me.cancelButton.TabIndex = 134
        Me.cancelButton.Text = "Cancel"
        Me.cancelButton.UseVisualStyleBackColor = False
        '
        'saveButton
        '
        Me.saveButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.saveButton.Enabled = False
        Me.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.saveButton.ForeColor = System.Drawing.Color.White
        Me.saveButton.Location = New System.Drawing.Point(514, 120)
        Me.saveButton.Name = "saveButton"
        Me.saveButton.Size = New System.Drawing.Size(132, 30)
        Me.saveButton.TabIndex = 133
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
        Me.addButton.Size = New System.Drawing.Size(132, 30)
        Me.addButton.TabIndex = 130
        Me.addButton.Text = "New Invoice"
        Me.addButton.UseVisualStyleBackColor = False
        '
        'invoiceNumLabel
        '
        Me.invoiceNumLabel.AutoSize = True
        Me.invoiceNumLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.invoiceNumLabel.Location = New System.Drawing.Point(97, 240)
        Me.invoiceNumLabel.Name = "invoiceNumLabel"
        Me.invoiceNumLabel.Size = New System.Drawing.Size(72, 17)
        Me.invoiceNumLabel.TabIndex = 143
        Me.invoiceNumLabel.Text = "Invoice # :"
        '
        'invoiceNumComboBox
        '
        Me.invoiceNumComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.invoiceNumComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.invoiceNumComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.invoiceNumComboBox.FormattingEnabled = True
        Me.invoiceNumComboBox.Location = New System.Drawing.Point(175, 234)
        Me.invoiceNumComboBox.Name = "invoiceNumComboBox"
        Me.invoiceNumComboBox.Size = New System.Drawing.Size(213, 28)
        Me.invoiceNumComboBox.TabIndex = 141
        '
        'CustomerComboLabel
        '
        Me.CustomerComboLabel.AutoSize = True
        Me.CustomerComboLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.CustomerComboLabel.Location = New System.Drawing.Point(97, 200)
        Me.CustomerComboLabel.Name = "CustomerComboLabel"
        Me.CustomerComboLabel.Size = New System.Drawing.Size(76, 17)
        Me.CustomerComboLabel.TabIndex = 142
        Me.CustomerComboLabel.Text = "Customer :"
        '
        'ComboBox1
        '
        Me.ComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(179, 194)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(508, 28)
        Me.ComboBox1.TabIndex = 144
        '
        'invDate_Textbox
        '
        Me.invDate_Textbox.AllowPromptAsInput = False
        Me.invDate_Textbox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.invDate_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.invDate_Textbox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert
        Me.invDate_Textbox.Location = New System.Drawing.Point(461, 305)
        Me.invDate_Textbox.Mask = "00/00/0000"
        Me.invDate_Textbox.Name = "invDate_Textbox"
        Me.invDate_Textbox.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.invDate_Textbox.Size = New System.Drawing.Size(181, 27)
        Me.invDate_Textbox.TabIndex = 240
        Me.invDate_Textbox.Tag = "dataEditingControl"
        Me.invDate_Textbox.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.invDate_Textbox.ValidatingType = GetType(Date)
        '
        'invDate_Value
        '
        Me.invDate_Value.AutoSize = True
        Me.invDate_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.invDate_Value.ForeColor = System.Drawing.Color.Black
        Me.invDate_Value.Location = New System.Drawing.Point(460, 308)
        Me.invDate_Value.Name = "invDate_Value"
        Me.invDate_Value.Size = New System.Drawing.Size(0, 20)
        Me.invDate_Value.TabIndex = 242
        Me.invDate_Value.Tag = "dataViewingControl"
        '
        'InvoiceDateLabel
        '
        Me.InvoiceDateLabel.AutoSize = True
        Me.InvoiceDateLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.InvoiceDateLabel.Location = New System.Drawing.Point(361, 311)
        Me.InvoiceDateLabel.Name = "InvoiceDateLabel"
        Me.InvoiceDateLabel.Size = New System.Drawing.Size(94, 17)
        Me.InvoiceDateLabel.TabIndex = 241
        Me.InvoiceDateLabel.Tag = "dataLabel"
        Me.InvoiceDateLabel.Text = "Invoice Date :"
        '
        'invNbr_Value
        '
        Me.invNbr_Value.AutoSize = True
        Me.invNbr_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.invNbr_Value.ForeColor = System.Drawing.Color.Black
        Me.invNbr_Value.Location = New System.Drawing.Point(217, 308)
        Me.invNbr_Value.Name = "invNbr_Value"
        Me.invNbr_Value.Size = New System.Drawing.Size(0, 20)
        Me.invNbr_Value.TabIndex = 247
        Me.invNbr_Value.Tag = "dataViewingControl"
        '
        'InvoiceNumberLabel
        '
        Me.InvoiceNumberLabel.AutoSize = True
        Me.InvoiceNumberLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.InvoiceNumberLabel.Location = New System.Drawing.Point(97, 311)
        Me.InvoiceNumberLabel.Name = "InvoiceNumberLabel"
        Me.InvoiceNumberLabel.Size = New System.Drawing.Size(114, 17)
        Me.InvoiceNumberLabel.TabIndex = 246
        Me.InvoiceNumberLabel.Tag = "dataLabel"
        Me.InvoiceNumberLabel.Text = "Invoice Number :"
        '
        'invNbr_Textbox
        '
        Me.invNbr_Textbox.Enabled = False
        Me.invNbr_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.invNbr_Textbox.Location = New System.Drawing.Point(217, 305)
        Me.invNbr_Textbox.MaxLength = 10
        Me.invNbr_Textbox.Name = "invNbr_Textbox"
        Me.invNbr_Textbox.Size = New System.Drawing.Size(126, 27)
        Me.invNbr_Textbox.TabIndex = 245
        Me.invNbr_Textbox.Tag = "dataEditingControl"
        '
        'Complete_Value
        '
        Me.Complete_Value.AutoSize = True
        Me.Complete_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Complete_Value.ForeColor = System.Drawing.Color.Black
        Me.Complete_Value.Location = New System.Drawing.Point(741, 308)
        Me.Complete_Value.Name = "Complete_Value"
        Me.Complete_Value.Size = New System.Drawing.Size(0, 20)
        Me.Complete_Value.TabIndex = 251
        Me.Complete_Value.Tag = "dataViewingControl"
        '
        'Complete_CheckBox
        '
        Me.Complete_CheckBox.AutoSize = True
        Me.Complete_CheckBox.Location = New System.Drawing.Point(741, 312)
        Me.Complete_CheckBox.Name = "Complete_CheckBox"
        Me.Complete_CheckBox.Size = New System.Drawing.Size(18, 17)
        Me.Complete_CheckBox.TabIndex = 253
        Me.Complete_CheckBox.Tag = "dataEditingControl"
        Me.Complete_CheckBox.UseVisualStyleBackColor = True
        '
        'CompleteLabel
        '
        Me.CompleteLabel.AutoSize = True
        Me.CompleteLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.CompleteLabel.Location = New System.Drawing.Point(660, 311)
        Me.CompleteLabel.Name = "CompleteLabel"
        Me.CompleteLabel.Size = New System.Drawing.Size(75, 17)
        Me.CompleteLabel.TabIndex = 252
        Me.CompleteLabel.Tag = "dataLabel"
        Me.CompleteLabel.Text = "Complete :"
        '
        'ContactName_Value
        '
        Me.ContactName_Value.AutoSize = True
        Me.ContactName_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContactName_Value.ForeColor = System.Drawing.Color.Black
        Me.ContactName_Value.Location = New System.Drawing.Point(167, 393)
        Me.ContactName_Value.Name = "ContactName_Value"
        Me.ContactName_Value.Size = New System.Drawing.Size(0, 20)
        Me.ContactName_Value.TabIndex = 256
        Me.ContactName_Value.Tag = "dataViewingControl"
        '
        'ContactLabel
        '
        Me.ContactLabel.AutoSize = True
        Me.ContactLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ContactLabel.Location = New System.Drawing.Point(97, 396)
        Me.ContactLabel.Name = "ContactLabel"
        Me.ContactLabel.Size = New System.Drawing.Size(64, 17)
        Me.ContactLabel.TabIndex = 255
        Me.ContactLabel.Tag = "dataLabel"
        Me.ContactLabel.Text = "Contact :"
        '
        'ContactName_Textbox
        '
        Me.ContactName_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContactName_Textbox.Location = New System.Drawing.Point(167, 390)
        Me.ContactName_Textbox.MaxLength = 20
        Me.ContactName_Textbox.Name = "ContactName_Textbox"
        Me.ContactName_Textbox.Size = New System.Drawing.Size(315, 27)
        Me.ContactName_Textbox.TabIndex = 254
        Me.ContactName_Textbox.Tag = "dataEditingControl"
        '
        'ComboBox2
        '
        Me.ComboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(179, 347)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(508, 28)
        Me.ComboBox2.TabIndex = 258
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(97, 353)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 17)
        Me.Label1.TabIndex = 257
        Me.Label1.Text = "Customer :"
        '
        'Phone1Label
        '
        Me.Phone1Label.AutoSize = True
        Me.Phone1Label.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Phone1Label.Location = New System.Drawing.Point(501, 396)
        Me.Phone1Label.Name = "Phone1Label"
        Me.Phone1Label.Size = New System.Drawing.Size(69, 17)
        Me.Phone1Label.TabIndex = 260
        Me.Phone1Label.Text = "Phone 1 :"
        '
        'ContactPhone1_ComboBox
        '
        Me.ContactPhone1_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ContactPhone1_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ContactPhone1_ComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.ContactPhone1_ComboBox.FormattingEnabled = True
        Me.ContactPhone1_ComboBox.Location = New System.Drawing.Point(576, 390)
        Me.ContactPhone1_ComboBox.Name = "ContactPhone1_ComboBox"
        Me.ContactPhone1_ComboBox.Size = New System.Drawing.Size(181, 28)
        Me.ContactPhone1_ComboBox.TabIndex = 259
        '
        'ContactPhone1_Value
        '
        Me.ContactPhone1_Value.AutoSize = True
        Me.ContactPhone1_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContactPhone1_Value.ForeColor = System.Drawing.Color.Black
        Me.ContactPhone1_Value.Location = New System.Drawing.Point(576, 393)
        Me.ContactPhone1_Value.Name = "ContactPhone1_Value"
        Me.ContactPhone1_Value.Size = New System.Drawing.Size(0, 20)
        Me.ContactPhone1_Value.TabIndex = 261
        Me.ContactPhone1_Value.Tag = "dataViewingControl"
        Me.ContactPhone1_Value.Visible = False
        '
        'ContactPhone2_Value
        '
        Me.ContactPhone2_Value.AutoSize = True
        Me.ContactPhone2_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContactPhone2_Value.ForeColor = System.Drawing.Color.Black
        Me.ContactPhone2_Value.Location = New System.Drawing.Point(852, 393)
        Me.ContactPhone2_Value.Name = "ContactPhone2_Value"
        Me.ContactPhone2_Value.Size = New System.Drawing.Size(0, 20)
        Me.ContactPhone2_Value.TabIndex = 264
        Me.ContactPhone2_Value.Tag = "dataViewingControl"
        Me.ContactPhone2_Value.Visible = False
        '
        'Phone2Label
        '
        Me.Phone2Label.AutoSize = True
        Me.Phone2Label.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Phone2Label.Location = New System.Drawing.Point(777, 396)
        Me.Phone2Label.Name = "Phone2Label"
        Me.Phone2Label.Size = New System.Drawing.Size(69, 17)
        Me.Phone2Label.TabIndex = 263
        Me.Phone2Label.Text = "Phone 2 :"
        '
        'ContactPhone2_ComboBox
        '
        Me.ContactPhone2_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ContactPhone2_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ContactPhone2_ComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.ContactPhone2_ComboBox.FormattingEnabled = True
        Me.ContactPhone2_ComboBox.Location = New System.Drawing.Point(852, 390)
        Me.ContactPhone2_ComboBox.Name = "ContactPhone2_ComboBox"
        Me.ContactPhone2_ComboBox.Size = New System.Drawing.Size(181, 28)
        Me.ContactPhone2_ComboBox.TabIndex = 262
        '
        'VehicleLabel
        '
        Me.VehicleLabel.AutoSize = True
        Me.VehicleLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.VehicleLabel.Location = New System.Drawing.Point(97, 439)
        Me.VehicleLabel.Name = "VehicleLabel"
        Me.VehicleLabel.Size = New System.Drawing.Size(62, 17)
        Me.VehicleLabel.TabIndex = 266
        Me.VehicleLabel.Text = "Vehicle :"
        '
        'VehicleComboBox
        '
        Me.VehicleComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.VehicleComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.VehicleComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.VehicleComboBox.FormattingEnabled = True
        Me.VehicleComboBox.Location = New System.Drawing.Point(165, 433)
        Me.VehicleComboBox.Name = "VehicleComboBox"
        Me.VehicleComboBox.Size = New System.Drawing.Size(352, 28)
        Me.VehicleComboBox.TabIndex = 265
        '
        'nav
        '
        Me.nav.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nav.Location = New System.Drawing.Point(0, 0)
        Me.nav.Name = "nav"
        Me.nav.Size = New System.Drawing.Size(1182, 28)
        Me.nav.TabIndex = 267
        '
        'Mileage_Value
        '
        Me.Mileage_Value.AutoSize = True
        Me.Mileage_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mileage_Value.ForeColor = System.Drawing.Color.Black
        Me.Mileage_Value.Location = New System.Drawing.Point(611, 436)
        Me.Mileage_Value.Name = "Mileage_Value"
        Me.Mileage_Value.Size = New System.Drawing.Size(0, 20)
        Me.Mileage_Value.TabIndex = 270
        Me.Mileage_Value.Tag = "dataViewingControl"
        '
        'MileageLabel
        '
        Me.MileageLabel.AutoSize = True
        Me.MileageLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.MileageLabel.Location = New System.Drawing.Point(540, 439)
        Me.MileageLabel.Name = "MileageLabel"
        Me.MileageLabel.Size = New System.Drawing.Size(65, 17)
        Me.MileageLabel.TabIndex = 269
        Me.MileageLabel.Tag = "dataLabel"
        Me.MileageLabel.Text = "Mileage :"
        '
        'Mileage_Textbox
        '
        Me.Mileage_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mileage_Textbox.Location = New System.Drawing.Point(611, 433)
        Me.Mileage_Textbox.MaxLength = 14
        Me.Mileage_Textbox.Name = "Mileage_Textbox"
        Me.Mileage_Textbox.Size = New System.Drawing.Size(146, 27)
        Me.Mileage_Textbox.TabIndex = 268
        Me.Mileage_Textbox.Tag = "dataEditingControl"
        '
        'vehicleHistoryButton
        '
        Me.vehicleHistoryButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.vehicleHistoryButton.Enabled = False
        Me.vehicleHistoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.vehicleHistoryButton.ForeColor = System.Drawing.Color.White
        Me.vehicleHistoryButton.Location = New System.Drawing.Point(780, 432)
        Me.vehicleHistoryButton.Name = "vehicleHistoryButton"
        Me.vehicleHistoryButton.Size = New System.Drawing.Size(182, 30)
        Me.vehicleHistoryButton.TabIndex = 271
        Me.vehicleHistoryButton.Text = "Vehicle History"
        Me.vehicleHistoryButton.UseVisualStyleBackColor = False
        '
        'invoices
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1182, 853)
        Me.Controls.Add(Me.vehicleHistoryButton)
        Me.Controls.Add(Me.Mileage_Value)
        Me.Controls.Add(Me.MileageLabel)
        Me.Controls.Add(Me.Mileage_Textbox)
        Me.Controls.Add(Me.nav)
        Me.Controls.Add(Me.VehicleLabel)
        Me.Controls.Add(Me.VehicleComboBox)
        Me.Controls.Add(Me.ContactPhone2_Value)
        Me.Controls.Add(Me.Phone2Label)
        Me.Controls.Add(Me.ContactPhone2_ComboBox)
        Me.Controls.Add(Me.ContactPhone1_Value)
        Me.Controls.Add(Me.Phone1Label)
        Me.Controls.Add(Me.ContactPhone1_ComboBox)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ContactName_Value)
        Me.Controls.Add(Me.ContactLabel)
        Me.Controls.Add(Me.ContactName_Textbox)
        Me.Controls.Add(Me.Complete_Value)
        Me.Controls.Add(Me.Complete_CheckBox)
        Me.Controls.Add(Me.CompleteLabel)
        Me.Controls.Add(Me.invNbr_Value)
        Me.Controls.Add(Me.InvoiceNumberLabel)
        Me.Controls.Add(Me.invNbr_Textbox)
        Me.Controls.Add(Me.invDate_Textbox)
        Me.Controls.Add(Me.invDate_Value)
        Me.Controls.Add(Me.InvoiceDateLabel)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.invoiceNumLabel)
        Me.Controls.Add(Me.invoiceNumComboBox)
        Me.Controls.Add(Me.CustomerComboLabel)
        Me.Controls.Add(Me.deleteButton)
        Me.Controls.Add(Me.invoiceMaintenanceLabel)
        Me.Controls.Add(Me.editButton)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.addButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "invoices"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Invoices"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents deleteButton As Button
    Friend WithEvents invoiceMaintenanceLabel As Label
    Friend WithEvents editButton As Button
    Friend WithEvents cancelButton As Button
    Friend WithEvents saveButton As Button
    Friend WithEvents addButton As Button
    Friend WithEvents invoiceNumLabel As Label
    Friend WithEvents invoiceNumComboBox As ComboBox
    Friend WithEvents CustomerComboLabel As Label
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents invDate_Textbox As MaskedTextBox
    Friend WithEvents invDate_Value As Label
    Friend WithEvents InvoiceDateLabel As Label
    Friend WithEvents invNbr_Value As Label
    Friend WithEvents InvoiceNumberLabel As Label
    Friend WithEvents invNbr_Textbox As TextBox
    Friend WithEvents Complete_Value As Label
    Friend WithEvents Complete_CheckBox As CheckBox
    Friend WithEvents CompleteLabel As Label
    Friend WithEvents ContactName_Value As Label
    Friend WithEvents ContactLabel As Label
    Friend WithEvents ContactName_Textbox As TextBox
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Phone1Label As Label
    Friend WithEvents ContactPhone1_ComboBox As ComboBox
    Friend WithEvents ContactPhone1_Value As Label
    Friend WithEvents ContactPhone2_Value As Label
    Friend WithEvents Phone2Label As Label
    Friend WithEvents ContactPhone2_ComboBox As ComboBox
    Friend WithEvents VehicleLabel As Label
    Friend WithEvents VehicleComboBox As ComboBox
    Friend WithEvents nav As navigation
    Friend WithEvents Mileage_Value As Label
    Friend WithEvents MileageLabel As Label
    Friend WithEvents Mileage_Textbox As TextBox
    Friend WithEvents vehicleHistoryButton As Button
End Class
