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
        Me.SuspendLayout()
        '
        'nav
        '
        Me.nav.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nav.Location = New System.Drawing.Point(0, 0)
        Me.nav.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.nav.Name = "nav"
        Me.nav.Size = New System.Drawing.Size(1105, 28)
        Me.nav.TabIndex = 50
        '
        'LastName_Value
        '
        Me.LastName_Value.AutoSize = True
        Me.LastName_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LastName_Value.ForeColor = System.Drawing.Color.Black
        Me.LastName_Value.Location = New System.Drawing.Point(206, 390)
        Me.LastName_Value.Name = "LastName_Value"
        Me.LastName_Value.Size = New System.Drawing.Size(0, 25)
        Me.LastName_Value.TabIndex = 132
        Me.LastName_Value.Tag = "dataViewingControl"
        '
        'LastNameLabel
        '
        Me.LastNameLabel.AutoSize = True
        Me.LastNameLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.LastNameLabel.Location = New System.Drawing.Point(106, 393)
        Me.LastNameLabel.Name = "LastNameLabel"
        Me.LastNameLabel.Size = New System.Drawing.Size(94, 20)
        Me.LastNameLabel.TabIndex = 131
        Me.LastNameLabel.Tag = "dataLabel"
        Me.LastNameLabel.Text = "Last Name :"
        '
        'LastName_Textbox
        '
        Me.LastName_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LastName_Textbox.Location = New System.Drawing.Point(206, 386)
        Me.LastName_Textbox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LastName_Textbox.MaxLength = 50
        Me.LastName_Textbox.Name = "LastName_Textbox"
        Me.LastName_Textbox.Size = New System.Drawing.Size(334, 31)
        Me.LastName_Textbox.TabIndex = 115
        Me.LastName_Textbox.Tag = "dataEditingControl"
        '
        'EmailAddress_Textbox
        '
        Me.EmailAddress_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmailAddress_Textbox.Location = New System.Drawing.Point(170, 709)
        Me.EmailAddress_Textbox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.EmailAddress_Textbox.Name = "EmailAddress_Textbox"
        Me.EmailAddress_Textbox.Size = New System.Drawing.Size(346, 31)
        Me.EmailAddress_Textbox.TabIndex = 116
        Me.EmailAddress_Textbox.Tag = "dataEditingControl"
        '
        'PriceLabel
        '
        Me.PriceLabel.AutoSize = True
        Me.PriceLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.PriceLabel.Location = New System.Drawing.Point(109, 716)
        Me.PriceLabel.Name = "PriceLabel"
        Me.PriceLabel.Size = New System.Drawing.Size(56, 20)
        Me.PriceLabel.TabIndex = 128
        Me.PriceLabel.Tag = "dataLabel"
        Me.PriceLabel.Text = "Email :"
        '
        'EmailAddress_Value
        '
        Me.EmailAddress_Value.AutoSize = True
        Me.EmailAddress_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmailAddress_Value.ForeColor = System.Drawing.Color.Black
        Me.EmailAddress_Value.Location = New System.Drawing.Point(170, 712)
        Me.EmailAddress_Value.Name = "EmailAddress_Value"
        Me.EmailAddress_Value.Size = New System.Drawing.Size(0, 25)
        Me.EmailAddress_Value.TabIndex = 127
        Me.EmailAddress_Value.Tag = "dataViewingControl"
        '
        'deleteButton
        '
        Me.deleteButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.deleteButton.Enabled = False
        Me.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.deleteButton.ForeColor = System.Drawing.Color.White
        Me.deleteButton.Location = New System.Drawing.Point(244, 150)
        Me.deleteButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.deleteButton.Name = "deleteButton"
        Me.deleteButton.Size = New System.Drawing.Size(124, 38)
        Me.deleteButton.TabIndex = 119
        Me.deleteButton.Text = "Delete"
        Me.deleteButton.UseVisualStyleBackColor = False
        '
        'CustomerId_Value
        '
        Me.CustomerId_Value.AutoSize = True
        Me.CustomerId_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomerId_Value.ForeColor = System.Drawing.Color.Black
        Me.CustomerId_Value.Location = New System.Drawing.Point(221, 327)
        Me.CustomerId_Value.Name = "CustomerId_Value"
        Me.CustomerId_Value.Size = New System.Drawing.Size(0, 25)
        Me.CustomerId_Value.TabIndex = 126
        Me.CustomerId_Value.Tag = "dataViewingControl"
        '
        'PartNumberLabel
        '
        Me.PartNumberLabel.AutoSize = True
        Me.PartNumberLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.PartNumberLabel.Location = New System.Drawing.Point(109, 330)
        Me.PartNumberLabel.Name = "PartNumberLabel"
        Me.PartNumberLabel.Size = New System.Drawing.Size(107, 20)
        Me.PartNumberLabel.TabIndex = 125
        Me.PartNumberLabel.Tag = "dataLabel"
        Me.PartNumberLabel.Text = "Customer ID :"
        '
        'CustomerComboLabel
        '
        Me.CustomerComboLabel.AutoSize = True
        Me.CustomerComboLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.CustomerComboLabel.Location = New System.Drawing.Point(109, 250)
        Me.CustomerComboLabel.Name = "CustomerComboLabel"
        Me.CustomerComboLabel.Size = New System.Drawing.Size(86, 20)
        Me.CustomerComboLabel.TabIndex = 124
        Me.CustomerComboLabel.Text = "Customer :"
        '
        'CustomerComboBox
        '
        Me.CustomerComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CustomerComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CustomerComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.CustomerComboBox.FormattingEnabled = True
        Me.CustomerComboBox.Location = New System.Drawing.Point(201, 243)
        Me.CustomerComboBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CustomerComboBox.Name = "CustomerComboBox"
        Me.CustomerComboBox.Size = New System.Drawing.Size(334, 33)
        Me.CustomerComboBox.TabIndex = 113
        '
        'customerMaintenanceLabel
        '
        Me.customerMaintenanceLabel.AutoSize = True
        Me.customerMaintenanceLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.customerMaintenanceLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.customerMaintenanceLabel.Location = New System.Drawing.Point(106, 91)
        Me.customerMaintenanceLabel.Name = "customerMaintenanceLabel"
        Me.customerMaintenanceLabel.Size = New System.Drawing.Size(185, 38)
        Me.customerMaintenanceLabel.TabIndex = 123
        Me.customerMaintenanceLabel.Text = "Customers"
        '
        'editButton
        '
        Me.editButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.editButton.Enabled = False
        Me.editButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.editButton.ForeColor = System.Drawing.Color.White
        Me.editButton.Location = New System.Drawing.Point(375, 150)
        Me.editButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.editButton.Name = "editButton"
        Me.editButton.Size = New System.Drawing.Size(124, 38)
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
        Me.cancelButton.Location = New System.Drawing.Point(635, 150)
        Me.cancelButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(124, 38)
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
        Me.saveButton.Location = New System.Drawing.Point(505, 150)
        Me.saveButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.saveButton.Name = "saveButton"
        Me.saveButton.Size = New System.Drawing.Size(124, 38)
        Me.saveButton.TabIndex = 121
        Me.saveButton.Text = "Save"
        Me.saveButton.UseVisualStyleBackColor = False
        '
        'addButton
        '
        Me.addButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.addButton.ForeColor = System.Drawing.Color.White
        Me.addButton.Location = New System.Drawing.Point(112, 150)
        Me.addButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.addButton.Name = "addButton"
        Me.addButton.Size = New System.Drawing.Size(124, 38)
        Me.addButton.TabIndex = 118
        Me.addButton.Text = "Add"
        Me.addButton.UseVisualStyleBackColor = False
        '
        'FirstName_Value
        '
        Me.FirstName_Value.AutoSize = True
        Me.FirstName_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FirstName_Value.ForeColor = System.Drawing.Color.Black
        Me.FirstName_Value.Location = New System.Drawing.Point(664, 391)
        Me.FirstName_Value.Name = "FirstName_Value"
        Me.FirstName_Value.Size = New System.Drawing.Size(0, 25)
        Me.FirstName_Value.TabIndex = 135
        Me.FirstName_Value.Tag = "dataViewingControl"
        '
        'FirstNameLabel
        '
        Me.FirstNameLabel.AutoSize = True
        Me.FirstNameLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.FirstNameLabel.Location = New System.Drawing.Point(564, 394)
        Me.FirstNameLabel.Name = "FirstNameLabel"
        Me.FirstNameLabel.Size = New System.Drawing.Size(94, 20)
        Me.FirstNameLabel.TabIndex = 134
        Me.FirstNameLabel.Tag = "dataLabel"
        Me.FirstNameLabel.Text = "First Name :"
        '
        'FirstName_Textbox
        '
        Me.FirstName_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FirstName_Textbox.Location = New System.Drawing.Point(664, 387)
        Me.FirstName_Textbox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.FirstName_Textbox.MaxLength = 50
        Me.FirstName_Textbox.Name = "FirstName_Textbox"
        Me.FirstName_Textbox.Size = New System.Drawing.Size(334, 31)
        Me.FirstName_Textbox.TabIndex = 133
        Me.FirstName_Textbox.Tag = "dataEditingControl"
        '
        'Address_Value
        '
        Me.Address_Value.AutoSize = True
        Me.Address_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Address_Value.ForeColor = System.Drawing.Color.Black
        Me.Address_Value.Location = New System.Drawing.Point(238, 441)
        Me.Address_Value.Name = "Address_Value"
        Me.Address_Value.Size = New System.Drawing.Size(0, 25)
        Me.Address_Value.TabIndex = 138
        Me.Address_Value.Tag = "dataViewingControl"
        '
        'AddressLabel
        '
        Me.AddressLabel.AutoSize = True
        Me.AddressLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.AddressLabel.Location = New System.Drawing.Point(108, 445)
        Me.AddressLabel.Name = "AddressLabel"
        Me.AddressLabel.Size = New System.Drawing.Size(124, 20)
        Me.AddressLabel.TabIndex = 137
        Me.AddressLabel.Tag = "dataLabel"
        Me.AddressLabel.Text = "Street Address :"
        '
        'Address_Textbox
        '
        Me.Address_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Address_Textbox.Location = New System.Drawing.Point(238, 437)
        Me.Address_Textbox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Address_Textbox.MaxLength = 50
        Me.Address_Textbox.Name = "Address_Textbox"
        Me.Address_Textbox.Size = New System.Drawing.Size(473, 31)
        Me.Address_Textbox.TabIndex = 136
        Me.Address_Textbox.Tag = "dataEditingControl"
        '
        'ZipCode_ComboBox
        '
        Me.ZipCode_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ZipCode_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ZipCode_ComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ZipCode_ComboBox.FormattingEnabled = True
        Me.ZipCode_ComboBox.Location = New System.Drawing.Point(193, 490)
        Me.ZipCode_ComboBox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ZipCode_ComboBox.MaxLength = 5
        Me.ZipCode_ComboBox.Name = "ZipCode_ComboBox"
        Me.ZipCode_ComboBox.Size = New System.Drawing.Size(168, 33)
        Me.ZipCode_ComboBox.TabIndex = 139
        Me.ZipCode_ComboBox.Tag = "dataEditingControl"
        Me.ZipCode_ComboBox.Visible = False
        '
        'State_Value
        '
        Me.State_Value.AutoSize = True
        Me.State_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.State_Value.ForeColor = System.Drawing.Color.Black
        Me.State_Value.Location = New System.Drawing.Point(449, 546)
        Me.State_Value.Name = "State_Value"
        Me.State_Value.Size = New System.Drawing.Size(0, 25)
        Me.State_Value.TabIndex = 147
        Me.State_Value.Tag = "dataViewingControl"
        '
        'city_Value
        '
        Me.city_Value.AutoSize = True
        Me.city_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.city_Value.ForeColor = System.Drawing.Color.Black
        Me.city_Value.Location = New System.Drawing.Point(157, 546)
        Me.city_Value.Name = "city_Value"
        Me.city_Value.Size = New System.Drawing.Size(0, 25)
        Me.city_Value.TabIndex = 146
        Me.city_Value.Tag = "dataViewingControl"
        '
        'ZipCode_Value
        '
        Me.ZipCode_Value.AutoSize = True
        Me.ZipCode_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ZipCode_Value.ForeColor = System.Drawing.Color.Black
        Me.ZipCode_Value.Location = New System.Drawing.Point(195, 490)
        Me.ZipCode_Value.Name = "ZipCode_Value"
        Me.ZipCode_Value.Size = New System.Drawing.Size(0, 25)
        Me.ZipCode_Value.TabIndex = 145
        Me.ZipCode_Value.Tag = "dataViewingControl"
        '
        'stateLabel
        '
        Me.stateLabel.AutoSize = True
        Me.stateLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.stateLabel.Location = New System.Drawing.Point(387, 549)
        Me.stateLabel.Name = "stateLabel"
        Me.stateLabel.Size = New System.Drawing.Size(56, 20)
        Me.stateLabel.TabIndex = 143
        Me.stateLabel.Text = "State :"
        '
        'cityLabel
        '
        Me.cityLabel.AutoSize = True
        Me.cityLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.cityLabel.Location = New System.Drawing.Point(106, 549)
        Me.cityLabel.Name = "cityLabel"
        Me.cityLabel.Size = New System.Drawing.Size(43, 20)
        Me.cityLabel.TabIndex = 141
        Me.cityLabel.Text = "City :"
        '
        'zipCodeLabel
        '
        Me.zipCodeLabel.AutoSize = True
        Me.zipCodeLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.zipCodeLabel.Location = New System.Drawing.Point(106, 497)
        Me.zipCodeLabel.Name = "zipCodeLabel"
        Me.zipCodeLabel.Size = New System.Drawing.Size(81, 20)
        Me.zipCodeLabel.TabIndex = 140
        Me.zipCodeLabel.Text = "Zip Code :"
        '
        'State_Textbox
        '
        Me.State_Textbox.Enabled = False
        Me.State_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.State_Textbox.Location = New System.Drawing.Point(449, 542)
        Me.State_Textbox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.State_Textbox.Name = "State_Textbox"
        Me.State_Textbox.Size = New System.Drawing.Size(123, 31)
        Me.State_Textbox.TabIndex = 144
        Me.State_Textbox.Tag = "dataEditingControl"
        Me.State_Textbox.Visible = False
        '
        'city_Textbox
        '
        Me.city_Textbox.Enabled = False
        Me.city_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.city_Textbox.Location = New System.Drawing.Point(157, 542)
        Me.city_Textbox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.city_Textbox.Name = "city_Textbox"
        Me.city_Textbox.Size = New System.Drawing.Size(206, 31)
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
        Me.CellPhone1_Textbox.Location = New System.Drawing.Point(218, 652)
        Me.CellPhone1_Textbox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CellPhone1_Textbox.Mask = "(999) 000-0000"
        Me.CellPhone1_Textbox.Name = "CellPhone1_Textbox"
        Me.CellPhone1_Textbox.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.CellPhone1_Textbox.Size = New System.Drawing.Size(203, 31)
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
        Me.HomePhone_Textbox.Location = New System.Drawing.Point(222, 597)
        Me.HomePhone_Textbox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.HomePhone_Textbox.Mask = "(999) 000-0000"
        Me.HomePhone_Textbox.Name = "HomePhone_Textbox"
        Me.HomePhone_Textbox.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.HomePhone_Textbox.Size = New System.Drawing.Size(203, 31)
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
        Me.CellPhone1_Value.Location = New System.Drawing.Point(218, 656)
        Me.CellPhone1_Value.Name = "CellPhone1_Value"
        Me.CellPhone1_Value.Size = New System.Drawing.Size(0, 25)
        Me.CellPhone1_Value.TabIndex = 159
        Me.CellPhone1_Value.Tag = "dataViewingControl"
        '
        'HomePhone_Value
        '
        Me.HomePhone_Value.AutoSize = True
        Me.HomePhone_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HomePhone_Value.ForeColor = System.Drawing.Color.Black
        Me.HomePhone_Value.Location = New System.Drawing.Point(222, 600)
        Me.HomePhone_Value.Name = "HomePhone_Value"
        Me.HomePhone_Value.Size = New System.Drawing.Size(0, 25)
        Me.HomePhone_Value.TabIndex = 158
        Me.HomePhone_Value.Tag = "dataViewingControl"
        '
        'CellPhone1Label
        '
        Me.CellPhone1Label.AutoSize = True
        Me.CellPhone1Label.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.CellPhone1Label.Location = New System.Drawing.Point(106, 659)
        Me.CellPhone1Label.Name = "CellPhone1Label"
        Me.CellPhone1Label.Size = New System.Drawing.Size(106, 20)
        Me.CellPhone1Label.TabIndex = 157
        Me.CellPhone1Label.Text = "Cell Phone 1 :"
        '
        'HomePhoneLabel
        '
        Me.HomePhoneLabel.AutoSize = True
        Me.HomePhoneLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.HomePhoneLabel.Location = New System.Drawing.Point(106, 604)
        Me.HomePhoneLabel.Name = "HomePhoneLabel"
        Me.HomePhoneLabel.Size = New System.Drawing.Size(110, 20)
        Me.HomePhoneLabel.TabIndex = 156
        Me.HomePhoneLabel.Text = "Home Phone :"
        '
        'CellPhone2_Textbox
        '
        Me.CellPhone2_Textbox.AllowPromptAsInput = False
        Me.CellPhone2_Textbox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.CellPhone2_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.CellPhone2_Textbox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert
        Me.CellPhone2_Textbox.Location = New System.Drawing.Point(562, 653)
        Me.CellPhone2_Textbox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CellPhone2_Textbox.Mask = "(999) 000-0000"
        Me.CellPhone2_Textbox.Name = "CellPhone2_Textbox"
        Me.CellPhone2_Textbox.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.CellPhone2_Textbox.Size = New System.Drawing.Size(203, 31)
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
        Me.WorkPhone_Textbox.Location = New System.Drawing.Point(560, 597)
        Me.WorkPhone_Textbox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.WorkPhone_Textbox.Mask = "(999) 000-0000"
        Me.WorkPhone_Textbox.Name = "WorkPhone_Textbox"
        Me.WorkPhone_Textbox.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.WorkPhone_Textbox.Size = New System.Drawing.Size(203, 31)
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
        Me.CellPhone2_Value.Location = New System.Drawing.Point(562, 657)
        Me.CellPhone2_Value.Name = "CellPhone2_Value"
        Me.CellPhone2_Value.Size = New System.Drawing.Size(0, 25)
        Me.CellPhone2_Value.TabIndex = 165
        Me.CellPhone2_Value.Tag = "dataViewingControl"
        '
        'WorkPhone_Value
        '
        Me.WorkPhone_Value.AutoSize = True
        Me.WorkPhone_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WorkPhone_Value.ForeColor = System.Drawing.Color.Black
        Me.WorkPhone_Value.Location = New System.Drawing.Point(560, 600)
        Me.WorkPhone_Value.Name = "WorkPhone_Value"
        Me.WorkPhone_Value.Size = New System.Drawing.Size(0, 25)
        Me.WorkPhone_Value.TabIndex = 164
        Me.WorkPhone_Value.Tag = "dataViewingControl"
        '
        'CellPhone2Label
        '
        Me.CellPhone2Label.AutoSize = True
        Me.CellPhone2Label.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.CellPhone2Label.Location = New System.Drawing.Point(450, 659)
        Me.CellPhone2Label.Name = "CellPhone2Label"
        Me.CellPhone2Label.Size = New System.Drawing.Size(106, 20)
        Me.CellPhone2Label.TabIndex = 163
        Me.CellPhone2Label.Text = "Cell Phone 2 :"
        '
        'WorkPhoneLabel
        '
        Me.WorkPhoneLabel.AutoSize = True
        Me.WorkPhoneLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.WorkPhoneLabel.Location = New System.Drawing.Point(450, 604)
        Me.WorkPhoneLabel.Name = "WorkPhoneLabel"
        Me.WorkPhoneLabel.Size = New System.Drawing.Size(104, 20)
        Me.WorkPhoneLabel.TabIndex = 162
        Me.WorkPhoneLabel.Text = "Work Phone :"
        '
        'customerMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1105, 941)
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
End Class
