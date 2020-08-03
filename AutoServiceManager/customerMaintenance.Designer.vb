<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class customerMaintenance
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
        Me.LastName_Value = New System.Windows.Forms.Label()
        Me.LastNameLabel = New System.Windows.Forms.Label()
        Me.LastName_Textbox = New System.Windows.Forms.TextBox()
        Me.EmailAddress_Textbox = New System.Windows.Forms.TextBox()
        Me.PriceLabel = New System.Windows.Forms.Label()
        Me.EmailAddress_Value = New System.Windows.Forms.Label()
        Me.deleteButton = New System.Windows.Forms.Button()
        Me.CustomerId_Value = New System.Windows.Forms.Label()
        Me.PartNumberLabel = New System.Windows.Forms.Label()
        Me.CustomerComboLabel = New System.Windows.Forms.Label()
        Me.CustomerComboBox = New System.Windows.Forms.ComboBox()
        Me.customerMaintenanceLabel = New System.Windows.Forms.Label()
        Me.editButton = New System.Windows.Forms.Button()
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.addButton = New System.Windows.Forms.Button()
        Me.FirstName_Value = New System.Windows.Forms.Label()
        Me.FirstNameLabel = New System.Windows.Forms.Label()
        Me.FirstName_Textbox = New System.Windows.Forms.TextBox()
        Me.Address_Value = New System.Windows.Forms.Label()
        Me.AddressLabel = New System.Windows.Forms.Label()
        Me.Address_Textbox = New System.Windows.Forms.TextBox()
        Me.ZipCode_ComboBox = New System.Windows.Forms.ComboBox()
        Me.State_Value = New System.Windows.Forms.Label()
        Me.city_Value = New System.Windows.Forms.Label()
        Me.ZipCode_Value = New System.Windows.Forms.Label()
        Me.stateLabel = New System.Windows.Forms.Label()
        Me.cityLabel = New System.Windows.Forms.Label()
        Me.zipCodeLabel = New System.Windows.Forms.Label()
        Me.State_Textbox = New System.Windows.Forms.TextBox()
        Me.city_Textbox = New System.Windows.Forms.TextBox()
        Me.CellPhone1_Textbox = New System.Windows.Forms.MaskedTextBox()
        Me.HomePhone_Textbox = New System.Windows.Forms.MaskedTextBox()
        Me.CellPhone1_Value = New System.Windows.Forms.Label()
        Me.HomePhone_Value = New System.Windows.Forms.Label()
        Me.CellPhone1Label = New System.Windows.Forms.Label()
        Me.HomePhoneLabel = New System.Windows.Forms.Label()
        Me.CellPhone2_Textbox = New System.Windows.Forms.MaskedTextBox()
        Me.WorkPhone_Textbox = New System.Windows.Forms.MaskedTextBox()
        Me.CellPhone2_Value = New System.Windows.Forms.Label()
        Me.WorkPhone_Value = New System.Windows.Forms.Label()
        Me.CellPhone2Label = New System.Windows.Forms.Label()
        Me.WorkPhoneLabel = New System.Windows.Forms.Label()
        Me.TaxExemptLabel = New System.Windows.Forms.Label()
        Me.TaxExempt_CheckBox = New System.Windows.Forms.CheckBox()
        Me.CustomerId_Textbox = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'nav
        '
        Me.nav.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nav.Location = New System.Drawing.Point(0, 0)
        Me.nav.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.nav.Name = "nav"
        Me.nav.Size = New System.Drawing.Size(982, 22)
        Me.nav.TabIndex = 50
        '
        'LastName_Value
        '
        Me.LastName_Value.AutoSize = True
        Me.LastName_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LastName_Value.ForeColor = System.Drawing.Color.Black
        Me.LastName_Value.Location = New System.Drawing.Point(183, 312)
        Me.LastName_Value.Name = "LastName_Value"
        Me.LastName_Value.Size = New System.Drawing.Size(0, 20)
        Me.LastName_Value.TabIndex = 132
        Me.LastName_Value.Tag = "dataViewingControl"
        '
        'LastNameLabel
        '
        Me.LastNameLabel.AutoSize = True
        Me.LastNameLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.LastNameLabel.Location = New System.Drawing.Point(94, 314)
        Me.LastNameLabel.Name = "LastNameLabel"
        Me.LastNameLabel.Size = New System.Drawing.Size(84, 17)
        Me.LastNameLabel.TabIndex = 131
        Me.LastNameLabel.Tag = "dataLabel"
        Me.LastNameLabel.Text = "Last Name :"
        '
        'LastName_Textbox
        '
        Me.LastName_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LastName_Textbox.Location = New System.Drawing.Point(183, 309)
        Me.LastName_Textbox.MaxLength = 50
        Me.LastName_Textbox.Name = "LastName_Textbox"
        Me.LastName_Textbox.Size = New System.Drawing.Size(297, 27)
        Me.LastName_Textbox.TabIndex = 115
        Me.LastName_Textbox.Tag = "dataEditingControl"
        Me.LastName_Textbox.Visible = False
        '
        'EmailAddress_Textbox
        '
        Me.EmailAddress_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmailAddress_Textbox.Location = New System.Drawing.Point(148, 567)
        Me.EmailAddress_Textbox.Name = "EmailAddress_Textbox"
        Me.EmailAddress_Textbox.Size = New System.Drawing.Size(308, 27)
        Me.EmailAddress_Textbox.TabIndex = 116
        Me.EmailAddress_Textbox.Tag = "dataEditingControl"
        Me.EmailAddress_Textbox.Visible = False
        '
        'PriceLabel
        '
        Me.PriceLabel.AutoSize = True
        Me.PriceLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.PriceLabel.Location = New System.Drawing.Point(94, 573)
        Me.PriceLabel.Name = "PriceLabel"
        Me.PriceLabel.Size = New System.Drawing.Size(50, 17)
        Me.PriceLabel.TabIndex = 128
        Me.PriceLabel.Tag = "dataLabel"
        Me.PriceLabel.Text = "Email :"
        '
        'EmailAddress_Value
        '
        Me.EmailAddress_Value.AutoSize = True
        Me.EmailAddress_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmailAddress_Value.ForeColor = System.Drawing.Color.Black
        Me.EmailAddress_Value.Location = New System.Drawing.Point(148, 570)
        Me.EmailAddress_Value.Name = "EmailAddress_Value"
        Me.EmailAddress_Value.Size = New System.Drawing.Size(0, 20)
        Me.EmailAddress_Value.TabIndex = 127
        Me.EmailAddress_Value.Tag = "dataViewingControl"
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
        'CustomerId_Value
        '
        Me.CustomerId_Value.AutoSize = True
        Me.CustomerId_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomerId_Value.ForeColor = System.Drawing.Color.Black
        Me.CustomerId_Value.Location = New System.Drawing.Point(196, 262)
        Me.CustomerId_Value.Name = "CustomerId_Value"
        Me.CustomerId_Value.Size = New System.Drawing.Size(0, 20)
        Me.CustomerId_Value.TabIndex = 126
        Me.CustomerId_Value.Tag = "dataViewingControl"
        '
        'PartNumberLabel
        '
        Me.PartNumberLabel.AutoSize = True
        Me.PartNumberLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.PartNumberLabel.Location = New System.Drawing.Point(97, 264)
        Me.PartNumberLabel.Name = "PartNumberLabel"
        Me.PartNumberLabel.Size = New System.Drawing.Size(93, 17)
        Me.PartNumberLabel.TabIndex = 125
        Me.PartNumberLabel.Tag = "dataLabel"
        Me.PartNumberLabel.Text = "Customer ID :"
        '
        'CustomerComboLabel
        '
        Me.CustomerComboLabel.AutoSize = True
        Me.CustomerComboLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.CustomerComboLabel.Location = New System.Drawing.Point(97, 200)
        Me.CustomerComboLabel.Name = "CustomerComboLabel"
        Me.CustomerComboLabel.Size = New System.Drawing.Size(76, 17)
        Me.CustomerComboLabel.TabIndex = 124
        Me.CustomerComboLabel.Text = "Customer :"
        '
        'CustomerComboBox
        '
        Me.CustomerComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CustomerComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CustomerComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.CustomerComboBox.FormattingEnabled = True
        Me.CustomerComboBox.Location = New System.Drawing.Point(179, 194)
        Me.CustomerComboBox.Name = "CustomerComboBox"
        Me.CustomerComboBox.Size = New System.Drawing.Size(362, 28)
        Me.CustomerComboBox.TabIndex = 113
        '
        'customerMaintenanceLabel
        '
        Me.customerMaintenanceLabel.AutoSize = True
        Me.customerMaintenanceLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.customerMaintenanceLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.customerMaintenanceLabel.Location = New System.Drawing.Point(94, 73)
        Me.customerMaintenanceLabel.Name = "customerMaintenanceLabel"
        Me.customerMaintenanceLabel.Size = New System.Drawing.Size(160, 32)
        Me.customerMaintenanceLabel.TabIndex = 123
        Me.customerMaintenanceLabel.Text = "Customers"
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
        Me.cancelButton.Location = New System.Drawing.Point(564, 120)
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
        'FirstName_Value
        '
        Me.FirstName_Value.AutoSize = True
        Me.FirstName_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FirstName_Value.ForeColor = System.Drawing.Color.Black
        Me.FirstName_Value.Location = New System.Drawing.Point(590, 313)
        Me.FirstName_Value.Name = "FirstName_Value"
        Me.FirstName_Value.Size = New System.Drawing.Size(0, 20)
        Me.FirstName_Value.TabIndex = 135
        Me.FirstName_Value.Tag = "dataViewingControl"
        '
        'FirstNameLabel
        '
        Me.FirstNameLabel.AutoSize = True
        Me.FirstNameLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.FirstNameLabel.Location = New System.Drawing.Point(501, 315)
        Me.FirstNameLabel.Name = "FirstNameLabel"
        Me.FirstNameLabel.Size = New System.Drawing.Size(84, 17)
        Me.FirstNameLabel.TabIndex = 134
        Me.FirstNameLabel.Tag = "dataLabel"
        Me.FirstNameLabel.Text = "First Name :"
        '
        'FirstName_Textbox
        '
        Me.FirstName_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FirstName_Textbox.Location = New System.Drawing.Point(590, 310)
        Me.FirstName_Textbox.MaxLength = 50
        Me.FirstName_Textbox.Name = "FirstName_Textbox"
        Me.FirstName_Textbox.Size = New System.Drawing.Size(297, 27)
        Me.FirstName_Textbox.TabIndex = 133
        Me.FirstName_Textbox.Tag = "dataEditingControl"
        Me.FirstName_Textbox.Visible = False
        '
        'Address_Value
        '
        Me.Address_Value.AutoSize = True
        Me.Address_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Address_Value.ForeColor = System.Drawing.Color.Black
        Me.Address_Value.Location = New System.Drawing.Point(212, 353)
        Me.Address_Value.Name = "Address_Value"
        Me.Address_Value.Size = New System.Drawing.Size(0, 20)
        Me.Address_Value.TabIndex = 138
        Me.Address_Value.Tag = "dataViewingControl"
        '
        'AddressLabel
        '
        Me.AddressLabel.AutoSize = True
        Me.AddressLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.AddressLabel.Location = New System.Drawing.Point(96, 356)
        Me.AddressLabel.Name = "AddressLabel"
        Me.AddressLabel.Size = New System.Drawing.Size(110, 17)
        Me.AddressLabel.TabIndex = 137
        Me.AddressLabel.Tag = "dataLabel"
        Me.AddressLabel.Text = "Street Address :"
        '
        'Address_Textbox
        '
        Me.Address_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Address_Textbox.Location = New System.Drawing.Point(212, 350)
        Me.Address_Textbox.MaxLength = 50
        Me.Address_Textbox.Name = "Address_Textbox"
        Me.Address_Textbox.Size = New System.Drawing.Size(421, 27)
        Me.Address_Textbox.TabIndex = 136
        Me.Address_Textbox.Tag = "dataEditingControl"
        Me.Address_Textbox.Visible = False
        '
        'ZipCode_ComboBox
        '
        Me.ZipCode_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ZipCode_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ZipCode_ComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ZipCode_ComboBox.FormattingEnabled = True
        Me.ZipCode_ComboBox.Location = New System.Drawing.Point(172, 392)
        Me.ZipCode_ComboBox.MaxLength = 5
        Me.ZipCode_ComboBox.Name = "ZipCode_ComboBox"
        Me.ZipCode_ComboBox.Size = New System.Drawing.Size(150, 28)
        Me.ZipCode_ComboBox.TabIndex = 139
        Me.ZipCode_ComboBox.Tag = "dataEditingControl"
        Me.ZipCode_ComboBox.Visible = False
        '
        'State_Value
        '
        Me.State_Value.AutoSize = True
        Me.State_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.State_Value.ForeColor = System.Drawing.Color.Black
        Me.State_Value.Location = New System.Drawing.Point(399, 437)
        Me.State_Value.Name = "State_Value"
        Me.State_Value.Size = New System.Drawing.Size(0, 20)
        Me.State_Value.TabIndex = 147
        Me.State_Value.Tag = "dataViewingControl"
        '
        'city_Value
        '
        Me.city_Value.AutoSize = True
        Me.city_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.city_Value.ForeColor = System.Drawing.Color.Black
        Me.city_Value.Location = New System.Drawing.Point(140, 437)
        Me.city_Value.Name = "city_Value"
        Me.city_Value.Size = New System.Drawing.Size(0, 20)
        Me.city_Value.TabIndex = 146
        Me.city_Value.Tag = "dataViewingControl"
        '
        'ZipCode_Value
        '
        Me.ZipCode_Value.AutoSize = True
        Me.ZipCode_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ZipCode_Value.ForeColor = System.Drawing.Color.Black
        Me.ZipCode_Value.Location = New System.Drawing.Point(173, 392)
        Me.ZipCode_Value.Name = "ZipCode_Value"
        Me.ZipCode_Value.Size = New System.Drawing.Size(0, 20)
        Me.ZipCode_Value.TabIndex = 145
        Me.ZipCode_Value.Tag = "dataViewingControl"
        '
        'stateLabel
        '
        Me.stateLabel.AutoSize = True
        Me.stateLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.stateLabel.Location = New System.Drawing.Point(344, 439)
        Me.stateLabel.Name = "stateLabel"
        Me.stateLabel.Size = New System.Drawing.Size(49, 17)
        Me.stateLabel.TabIndex = 143
        Me.stateLabel.Text = "State :"
        '
        'cityLabel
        '
        Me.cityLabel.AutoSize = True
        Me.cityLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.cityLabel.Location = New System.Drawing.Point(94, 439)
        Me.cityLabel.Name = "cityLabel"
        Me.cityLabel.Size = New System.Drawing.Size(39, 17)
        Me.cityLabel.TabIndex = 141
        Me.cityLabel.Text = "City :"
        '
        'zipCodeLabel
        '
        Me.zipCodeLabel.AutoSize = True
        Me.zipCodeLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.zipCodeLabel.Location = New System.Drawing.Point(94, 398)
        Me.zipCodeLabel.Name = "zipCodeLabel"
        Me.zipCodeLabel.Size = New System.Drawing.Size(73, 17)
        Me.zipCodeLabel.TabIndex = 140
        Me.zipCodeLabel.Text = "Zip Code :"
        '
        'State_Textbox
        '
        Me.State_Textbox.Enabled = False
        Me.State_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.State_Textbox.Location = New System.Drawing.Point(399, 434)
        Me.State_Textbox.Name = "State_Textbox"
        Me.State_Textbox.Size = New System.Drawing.Size(110, 27)
        Me.State_Textbox.TabIndex = 144
        Me.State_Textbox.Tag = "dataEditingControl"
        Me.State_Textbox.Visible = False
        '
        'city_Textbox
        '
        Me.city_Textbox.Enabled = False
        Me.city_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.city_Textbox.Location = New System.Drawing.Point(140, 434)
        Me.city_Textbox.Name = "city_Textbox"
        Me.city_Textbox.Size = New System.Drawing.Size(184, 27)
        Me.city_Textbox.TabIndex = 142
        Me.city_Textbox.Tag = "dataEditingControl"
        Me.city_Textbox.Visible = False
        '
        'CellPhone1_Textbox
        '
        Me.CellPhone1_Textbox.AllowPromptAsInput = False
        Me.CellPhone1_Textbox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.CellPhone1_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.CellPhone1_Textbox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert
        Me.CellPhone1_Textbox.Location = New System.Drawing.Point(194, 522)
        Me.CellPhone1_Textbox.Mask = "(999) 000-0000"
        Me.CellPhone1_Textbox.Name = "CellPhone1_Textbox"
        Me.CellPhone1_Textbox.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.CellPhone1_Textbox.Size = New System.Drawing.Size(181, 27)
        Me.CellPhone1_Textbox.TabIndex = 155
        Me.CellPhone1_Textbox.Tag = "dataEditingControl"
        Me.CellPhone1_Textbox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.CellPhone1_Textbox.Visible = False
        '
        'HomePhone_Textbox
        '
        Me.HomePhone_Textbox.AllowPromptAsInput = False
        Me.HomePhone_Textbox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.HomePhone_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.HomePhone_Textbox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert
        Me.HomePhone_Textbox.Location = New System.Drawing.Point(197, 478)
        Me.HomePhone_Textbox.Mask = "(999) 000-0000"
        Me.HomePhone_Textbox.Name = "HomePhone_Textbox"
        Me.HomePhone_Textbox.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.HomePhone_Textbox.Size = New System.Drawing.Size(181, 27)
        Me.HomePhone_Textbox.TabIndex = 154
        Me.HomePhone_Textbox.Tag = "dataEditingControl"
        Me.HomePhone_Textbox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.HomePhone_Textbox.Visible = False
        '
        'CellPhone1_Value
        '
        Me.CellPhone1_Value.AutoSize = True
        Me.CellPhone1_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CellPhone1_Value.ForeColor = System.Drawing.Color.Black
        Me.CellPhone1_Value.Location = New System.Drawing.Point(194, 525)
        Me.CellPhone1_Value.Name = "CellPhone1_Value"
        Me.CellPhone1_Value.Size = New System.Drawing.Size(0, 20)
        Me.CellPhone1_Value.TabIndex = 159
        Me.CellPhone1_Value.Tag = "dataViewingControl"
        '
        'HomePhone_Value
        '
        Me.HomePhone_Value.AutoSize = True
        Me.HomePhone_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HomePhone_Value.ForeColor = System.Drawing.Color.Black
        Me.HomePhone_Value.Location = New System.Drawing.Point(197, 480)
        Me.HomePhone_Value.Name = "HomePhone_Value"
        Me.HomePhone_Value.Size = New System.Drawing.Size(0, 20)
        Me.HomePhone_Value.TabIndex = 158
        Me.HomePhone_Value.Tag = "dataViewingControl"
        '
        'CellPhone1Label
        '
        Me.CellPhone1Label.AutoSize = True
        Me.CellPhone1Label.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.CellPhone1Label.Location = New System.Drawing.Point(94, 527)
        Me.CellPhone1Label.Name = "CellPhone1Label"
        Me.CellPhone1Label.Size = New System.Drawing.Size(96, 17)
        Me.CellPhone1Label.TabIndex = 157
        Me.CellPhone1Label.Text = "Cell Phone 1 :"
        '
        'HomePhoneLabel
        '
        Me.HomePhoneLabel.AutoSize = True
        Me.HomePhoneLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.HomePhoneLabel.Location = New System.Drawing.Point(94, 483)
        Me.HomePhoneLabel.Name = "HomePhoneLabel"
        Me.HomePhoneLabel.Size = New System.Drawing.Size(98, 17)
        Me.HomePhoneLabel.TabIndex = 156
        Me.HomePhoneLabel.Text = "Home Phone :"
        '
        'CellPhone2_Textbox
        '
        Me.CellPhone2_Textbox.AllowPromptAsInput = False
        Me.CellPhone2_Textbox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.CellPhone2_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.CellPhone2_Textbox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert
        Me.CellPhone2_Textbox.Location = New System.Drawing.Point(500, 522)
        Me.CellPhone2_Textbox.Mask = "(999) 000-0000"
        Me.CellPhone2_Textbox.Name = "CellPhone2_Textbox"
        Me.CellPhone2_Textbox.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.CellPhone2_Textbox.Size = New System.Drawing.Size(181, 27)
        Me.CellPhone2_Textbox.TabIndex = 161
        Me.CellPhone2_Textbox.Tag = "dataEditingControl"
        Me.CellPhone2_Textbox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.CellPhone2_Textbox.Visible = False
        '
        'WorkPhone_Textbox
        '
        Me.WorkPhone_Textbox.AllowPromptAsInput = False
        Me.WorkPhone_Textbox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.WorkPhone_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.WorkPhone_Textbox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert
        Me.WorkPhone_Textbox.Location = New System.Drawing.Point(498, 478)
        Me.WorkPhone_Textbox.Mask = "(999) 000-0000"
        Me.WorkPhone_Textbox.Name = "WorkPhone_Textbox"
        Me.WorkPhone_Textbox.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.WorkPhone_Textbox.Size = New System.Drawing.Size(181, 27)
        Me.WorkPhone_Textbox.TabIndex = 160
        Me.WorkPhone_Textbox.Tag = "dataEditingControl"
        Me.WorkPhone_Textbox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.WorkPhone_Textbox.Visible = False
        '
        'CellPhone2_Value
        '
        Me.CellPhone2_Value.AutoSize = True
        Me.CellPhone2_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CellPhone2_Value.ForeColor = System.Drawing.Color.Black
        Me.CellPhone2_Value.Location = New System.Drawing.Point(500, 526)
        Me.CellPhone2_Value.Name = "CellPhone2_Value"
        Me.CellPhone2_Value.Size = New System.Drawing.Size(0, 20)
        Me.CellPhone2_Value.TabIndex = 165
        Me.CellPhone2_Value.Tag = "dataViewingControl"
        '
        'WorkPhone_Value
        '
        Me.WorkPhone_Value.AutoSize = True
        Me.WorkPhone_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WorkPhone_Value.ForeColor = System.Drawing.Color.Black
        Me.WorkPhone_Value.Location = New System.Drawing.Point(498, 480)
        Me.WorkPhone_Value.Name = "WorkPhone_Value"
        Me.WorkPhone_Value.Size = New System.Drawing.Size(0, 20)
        Me.WorkPhone_Value.TabIndex = 164
        Me.WorkPhone_Value.Tag = "dataViewingControl"
        '
        'CellPhone2Label
        '
        Me.CellPhone2Label.AutoSize = True
        Me.CellPhone2Label.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.CellPhone2Label.Location = New System.Drawing.Point(400, 527)
        Me.CellPhone2Label.Name = "CellPhone2Label"
        Me.CellPhone2Label.Size = New System.Drawing.Size(96, 17)
        Me.CellPhone2Label.TabIndex = 163
        Me.CellPhone2Label.Text = "Cell Phone 2 :"
        '
        'WorkPhoneLabel
        '
        Me.WorkPhoneLabel.AutoSize = True
        Me.WorkPhoneLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.WorkPhoneLabel.Location = New System.Drawing.Point(400, 483)
        Me.WorkPhoneLabel.Name = "WorkPhoneLabel"
        Me.WorkPhoneLabel.Size = New System.Drawing.Size(94, 17)
        Me.WorkPhoneLabel.TabIndex = 162
        Me.WorkPhoneLabel.Text = "Work Phone :"
        '
        'TaxExemptLabel
        '
        Me.TaxExemptLabel.AutoSize = True
        Me.TaxExemptLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TaxExemptLabel.Location = New System.Drawing.Point(487, 573)
        Me.TaxExemptLabel.Name = "TaxExemptLabel"
        Me.TaxExemptLabel.Size = New System.Drawing.Size(89, 17)
        Me.TaxExemptLabel.TabIndex = 166
        Me.TaxExemptLabel.Text = "Tax Exempt :"
        '
        'TaxExempt_CheckBox
        '
        Me.TaxExempt_CheckBox.AutoSize = True
        Me.TaxExempt_CheckBox.Location = New System.Drawing.Point(582, 574)
        Me.TaxExempt_CheckBox.Name = "TaxExempt_CheckBox"
        Me.TaxExempt_CheckBox.Size = New System.Drawing.Size(18, 17)
        Me.TaxExempt_CheckBox.TabIndex = 167
        Me.TaxExempt_CheckBox.UseVisualStyleBackColor = True
        '
        'CustomerId_Textbox
        '
        Me.CustomerId_Textbox.Enabled = False
        Me.CustomerId_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomerId_Textbox.Location = New System.Drawing.Point(196, 258)
        Me.CustomerId_Textbox.Name = "CustomerId_Textbox"
        Me.CustomerId_Textbox.Size = New System.Drawing.Size(126, 27)
        Me.CustomerId_Textbox.TabIndex = 168
        Me.CustomerId_Textbox.Tag = "dataEditingControl"
        Me.CustomerId_Textbox.Visible = False
        '
        'customerMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(982, 753)
        Me.Controls.Add(Me.CustomerId_Textbox)
        Me.Controls.Add(Me.TaxExempt_CheckBox)
        Me.Controls.Add(Me.TaxExemptLabel)
        Me.Controls.Add(Me.CellPhone2_Textbox)
        Me.Controls.Add(Me.WorkPhone_Textbox)
        Me.Controls.Add(Me.CellPhone2_Value)
        Me.Controls.Add(Me.WorkPhone_Value)
        Me.Controls.Add(Me.CellPhone2Label)
        Me.Controls.Add(Me.WorkPhoneLabel)
        Me.Controls.Add(Me.CellPhone1_Textbox)
        Me.Controls.Add(Me.HomePhone_Textbox)
        Me.Controls.Add(Me.CellPhone1_Value)
        Me.Controls.Add(Me.HomePhone_Value)
        Me.Controls.Add(Me.CellPhone1Label)
        Me.Controls.Add(Me.HomePhoneLabel)
        Me.Controls.Add(Me.ZipCode_ComboBox)
        Me.Controls.Add(Me.State_Value)
        Me.Controls.Add(Me.city_Value)
        Me.Controls.Add(Me.ZipCode_Value)
        Me.Controls.Add(Me.stateLabel)
        Me.Controls.Add(Me.cityLabel)
        Me.Controls.Add(Me.zipCodeLabel)
        Me.Controls.Add(Me.State_Textbox)
        Me.Controls.Add(Me.city_Textbox)
        Me.Controls.Add(Me.Address_Value)
        Me.Controls.Add(Me.AddressLabel)
        Me.Controls.Add(Me.Address_Textbox)
        Me.Controls.Add(Me.FirstName_Value)
        Me.Controls.Add(Me.FirstNameLabel)
        Me.Controls.Add(Me.FirstName_Textbox)
        Me.Controls.Add(Me.LastName_Value)
        Me.Controls.Add(Me.LastNameLabel)
        Me.Controls.Add(Me.LastName_Textbox)
        Me.Controls.Add(Me.EmailAddress_Textbox)
        Me.Controls.Add(Me.PriceLabel)
        Me.Controls.Add(Me.EmailAddress_Value)
        Me.Controls.Add(Me.deleteButton)
        Me.Controls.Add(Me.CustomerId_Value)
        Me.Controls.Add(Me.PartNumberLabel)
        Me.Controls.Add(Me.CustomerComboLabel)
        Me.Controls.Add(Me.CustomerComboBox)
        Me.Controls.Add(Me.customerMaintenanceLabel)
        Me.Controls.Add(Me.editButton)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.addButton)
        Me.Controls.Add(Me.nav)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.Name = "customerMaintenance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Customers"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents nav As navigation
    Friend WithEvents LastName_Value As Label
    Friend WithEvents LastNameLabel As Label
    Friend WithEvents LastName_Textbox As TextBox
    Friend WithEvents EmailAddress_Textbox As TextBox
    Friend WithEvents PriceLabel As Label
    Friend WithEvents EmailAddress_Value As Label
    Friend WithEvents deleteButton As Button
    Friend WithEvents CustomerId_Value As Label
    Friend WithEvents PartNumberLabel As Label
    Friend WithEvents CustomerComboLabel As Label
    Friend WithEvents CustomerComboBox As ComboBox
    Friend WithEvents customerMaintenanceLabel As Label
    Friend WithEvents editButton As Button
    Friend WithEvents cancelButton As Button
    Friend WithEvents saveButton As Button
    Friend WithEvents addButton As Button
    Friend WithEvents FirstName_Value As Label
    Friend WithEvents FirstNameLabel As Label
    Friend WithEvents FirstName_Textbox As TextBox
    Friend WithEvents Address_Value As Label
    Friend WithEvents AddressLabel As Label
    Friend WithEvents Address_Textbox As TextBox
    Friend WithEvents ZipCode_ComboBox As ComboBox
    Friend WithEvents State_Value As Label
    Friend WithEvents city_Value As Label
    Friend WithEvents ZipCode_Value As Label
    Friend WithEvents stateLabel As Label
    Friend WithEvents cityLabel As Label
    Friend WithEvents zipCodeLabel As Label
    Friend WithEvents State_Textbox As TextBox
    Friend WithEvents city_Textbox As TextBox
    Friend WithEvents CellPhone1_Textbox As MaskedTextBox
    Friend WithEvents HomePhone_Textbox As MaskedTextBox
    Friend WithEvents CellPhone1_Value As Label
    Friend WithEvents HomePhone_Value As Label
    Friend WithEvents CellPhone1Label As Label
    Friend WithEvents HomePhoneLabel As Label
    Friend WithEvents CellPhone2_Textbox As MaskedTextBox
    Friend WithEvents WorkPhone_Textbox As MaskedTextBox
    Friend WithEvents CellPhone2_Value As Label
    Friend WithEvents WorkPhone_Value As Label
    Friend WithEvents CellPhone2Label As Label
    Friend WithEvents WorkPhoneLabel As Label
    Friend WithEvents TaxExemptLabel As Label
    Friend WithEvents TaxExempt_CheckBox As CheckBox
    Friend WithEvents CustomerId_Textbox As TextBox
End Class
