﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class companyInfo
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.companyNameLabel = New System.Windows.Forms.Label()
        Me.companyNameLabel2 = New System.Windows.Forms.Label()
        Me.addressLine1Label = New System.Windows.Forms.Label()
        Me.addressLine2Label = New System.Windows.Forms.Label()
        Me.zipCodeLabel = New System.Windows.Forms.Label()
        Me.cityLabel = New System.Windows.Forms.Label()
        Me.shopSupplyChargeLabel = New System.Windows.Forms.Label()
        Me.companyInfoLabel = New System.Windows.Forms.Label()
        Me.CompanyName1_Textbox = New System.Windows.Forms.TextBox()
        Me.CompanyName2_Textbox = New System.Windows.Forms.TextBox()
        Me.Address1_Textbox = New System.Windows.Forms.TextBox()
        Me.Address2_Textbox = New System.Windows.Forms.TextBox()
        Me.city_Textbox = New System.Windows.Forms.TextBox()
        Me.ShopSupplyCharge_Textbox = New System.Windows.Forms.TextBox()
        Me.LaborRate_Textbox = New System.Windows.Forms.TextBox()
        Me.TaxRate_Textbox = New System.Windows.Forms.TextBox()
        Me.phone1Label = New System.Windows.Forms.Label()
        Me.phone2Label = New System.Windows.Forms.Label()
        Me.taxRateLabel = New System.Windows.Forms.Label()
        Me.laborRateLabel = New System.Windows.Forms.Label()
        Me.editButton = New System.Windows.Forms.Button()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.stateLabel = New System.Windows.Forms.Label()
        Me.State_Textbox = New System.Windows.Forms.TextBox()
        Me.CompanyName1_Value = New System.Windows.Forms.Label()
        Me.CompanyName2_Value = New System.Windows.Forms.Label()
        Me.Address1_Value = New System.Windows.Forms.Label()
        Me.Address2_Value = New System.Windows.Forms.Label()
        Me.ZipCode_Value = New System.Windows.Forms.Label()
        Me.city_Value = New System.Windows.Forms.Label()
        Me.State_Value = New System.Windows.Forms.Label()
        Me.TaxRate_Value = New System.Windows.Forms.Label()
        Me.Phone1_Value = New System.Windows.Forms.Label()
        Me.Phone2_Value = New System.Windows.Forms.Label()
        Me.ShopSupplyCharge_Value = New System.Windows.Forms.Label()
        Me.LaborRate_Value = New System.Windows.Forms.Label()
        Me.ZipCode_ComboBox = New System.Windows.Forms.ComboBox()
        Me.Phone1_Textbox = New System.Windows.Forms.MaskedTextBox()
        Me.Phone2_Textbox = New System.Windows.Forms.MaskedTextBox()
        Me.nav = New AutoServiceManager.navigation()
        Me.SuspendLayout()
        '
        'companyNameLabel
        '
        Me.companyNameLabel.AutoSize = True
        Me.companyNameLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.companyNameLabel.Location = New System.Drawing.Point(97, 200)
        Me.companyNameLabel.Name = "companyNameLabel"
        Me.companyNameLabel.Size = New System.Drawing.Size(172, 17)
        Me.companyNameLabel.TabIndex = 0
        Me.companyNameLabel.Text = "Company Name - Line 1 : "
        '
        'companyNameLabel2
        '
        Me.companyNameLabel2.AutoSize = True
        Me.companyNameLabel2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.companyNameLabel2.Location = New System.Drawing.Point(97, 237)
        Me.companyNameLabel2.Name = "companyNameLabel2"
        Me.companyNameLabel2.Size = New System.Drawing.Size(172, 17)
        Me.companyNameLabel2.TabIndex = 1
        Me.companyNameLabel2.Text = "Company Name - Line 2 : "
        '
        'addressLine1Label
        '
        Me.addressLine1Label.AutoSize = True
        Me.addressLine1Label.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.addressLine1Label.Location = New System.Drawing.Point(97, 292)
        Me.addressLine1Label.Name = "addressLine1Label"
        Me.addressLine1Label.Size = New System.Drawing.Size(120, 17)
        Me.addressLine1Label.TabIndex = 2
        Me.addressLine1Label.Text = "Address - Line 1 :"
        '
        'addressLine2Label
        '
        Me.addressLine2Label.AutoSize = True
        Me.addressLine2Label.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.addressLine2Label.Location = New System.Drawing.Point(97, 336)
        Me.addressLine2Label.Name = "addressLine2Label"
        Me.addressLine2Label.Size = New System.Drawing.Size(120, 17)
        Me.addressLine2Label.TabIndex = 3
        Me.addressLine2Label.Text = "Address - Line 2 :"
        '
        'zipCodeLabel
        '
        Me.zipCodeLabel.AutoSize = True
        Me.zipCodeLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.zipCodeLabel.Location = New System.Drawing.Point(97, 389)
        Me.zipCodeLabel.Name = "zipCodeLabel"
        Me.zipCodeLabel.Size = New System.Drawing.Size(73, 17)
        Me.zipCodeLabel.TabIndex = 4
        Me.zipCodeLabel.Text = "Zip Code :"
        '
        'cityLabel
        '
        Me.cityLabel.AutoSize = True
        Me.cityLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.cityLabel.Location = New System.Drawing.Point(97, 433)
        Me.cityLabel.Name = "cityLabel"
        Me.cityLabel.Size = New System.Drawing.Size(39, 17)
        Me.cityLabel.TabIndex = 5
        Me.cityLabel.Text = "City :"
        '
        'shopSupplyChargeLabel
        '
        Me.shopSupplyChargeLabel.AutoSize = True
        Me.shopSupplyChargeLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.shopSupplyChargeLabel.Location = New System.Drawing.Point(97, 531)
        Me.shopSupplyChargeLabel.Name = "shopSupplyChargeLabel"
        Me.shopSupplyChargeLabel.Size = New System.Drawing.Size(146, 17)
        Me.shopSupplyChargeLabel.TabIndex = 6
        Me.shopSupplyChargeLabel.Text = "Shop Supply Charge :"
        '
        'companyInfoLabel
        '
        Me.companyInfoLabel.AutoSize = True
        Me.companyInfoLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold)
        Me.companyInfoLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.companyInfoLabel.Location = New System.Drawing.Point(94, 73)
        Me.companyInfoLabel.Name = "companyInfoLabel"
        Me.companyInfoLabel.Size = New System.Drawing.Size(304, 32)
        Me.companyInfoLabel.TabIndex = 7
        Me.companyInfoLabel.Text = "Company Information"
        '
        'CompanyName1_Textbox
        '
        Me.CompanyName1_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CompanyName1_Textbox.Location = New System.Drawing.Point(275, 194)
        Me.CompanyName1_Textbox.MaxLength = 50
        Me.CompanyName1_Textbox.Name = "CompanyName1_Textbox"
        Me.CompanyName1_Textbox.Size = New System.Drawing.Size(560, 27)
        Me.CompanyName1_Textbox.TabIndex = 0
        Me.CompanyName1_Textbox.Tag = "dataEditingControl"
        Me.CompanyName1_Textbox.Visible = False
        Me.CompanyName1_Textbox.WordWrap = False
        '
        'CompanyName2_Textbox
        '
        Me.CompanyName2_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CompanyName2_Textbox.Location = New System.Drawing.Point(275, 231)
        Me.CompanyName2_Textbox.MaxLength = 50
        Me.CompanyName2_Textbox.Name = "CompanyName2_Textbox"
        Me.CompanyName2_Textbox.Size = New System.Drawing.Size(560, 27)
        Me.CompanyName2_Textbox.TabIndex = 1
        Me.CompanyName2_Textbox.Tag = "dataEditingControl"
        Me.CompanyName2_Textbox.Visible = False
        '
        'Address1_Textbox
        '
        Me.Address1_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Address1_Textbox.Location = New System.Drawing.Point(223, 286)
        Me.Address1_Textbox.MaxLength = 50
        Me.Address1_Textbox.Name = "Address1_Textbox"
        Me.Address1_Textbox.Size = New System.Drawing.Size(289, 27)
        Me.Address1_Textbox.TabIndex = 2
        Me.Address1_Textbox.Tag = "dataEditingControl"
        Me.Address1_Textbox.Visible = False
        '
        'Address2_Textbox
        '
        Me.Address2_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Address2_Textbox.Location = New System.Drawing.Point(223, 330)
        Me.Address2_Textbox.MaxLength = 50
        Me.Address2_Textbox.Name = "Address2_Textbox"
        Me.Address2_Textbox.Size = New System.Drawing.Size(289, 27)
        Me.Address2_Textbox.TabIndex = 3
        Me.Address2_Textbox.Tag = "dataEditingControl"
        Me.Address2_Textbox.Visible = False
        '
        'city_Textbox
        '
        Me.city_Textbox.Enabled = False
        Me.city_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.city_Textbox.Location = New System.Drawing.Point(142, 427)
        Me.city_Textbox.Name = "city_Textbox"
        Me.city_Textbox.Size = New System.Drawing.Size(184, 27)
        Me.city_Textbox.TabIndex = 13
        Me.city_Textbox.Tag = "dataEditingControl"
        Me.city_Textbox.Visible = False
        '
        'ShopSupplyCharge_Textbox
        '
        Me.ShopSupplyCharge_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShopSupplyCharge_Textbox.Location = New System.Drawing.Point(249, 525)
        Me.ShopSupplyCharge_Textbox.Name = "ShopSupplyCharge_Textbox"
        Me.ShopSupplyCharge_Textbox.Size = New System.Drawing.Size(82, 27)
        Me.ShopSupplyCharge_Textbox.TabIndex = 8
        Me.ShopSupplyCharge_Textbox.Tag = "dataEditingControl"
        Me.ShopSupplyCharge_Textbox.Visible = False
        '
        'LaborRate_Textbox
        '
        Me.LaborRate_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LaborRate_Textbox.Location = New System.Drawing.Point(443, 525)
        Me.LaborRate_Textbox.Name = "LaborRate_Textbox"
        Me.LaborRate_Textbox.Size = New System.Drawing.Size(69, 27)
        Me.LaborRate_Textbox.TabIndex = 9
        Me.LaborRate_Textbox.Tag = "dataEditingControl"
        Me.LaborRate_Textbox.Visible = False
        '
        'TaxRate_Textbox
        '
        Me.TaxRate_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TaxRate_Textbox.Location = New System.Drawing.Point(649, 427)
        Me.TaxRate_Textbox.Name = "TaxRate_Textbox"
        Me.TaxRate_Textbox.Size = New System.Drawing.Size(81, 27)
        Me.TaxRate_Textbox.TabIndex = 7
        Me.TaxRate_Textbox.Tag = "dataEditingControl"
        Me.TaxRate_Textbox.Visible = False
        '
        'phone1Label
        '
        Me.phone1Label.AutoSize = True
        Me.phone1Label.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.phone1Label.Location = New System.Drawing.Point(570, 292)
        Me.phone1Label.Name = "phone1Label"
        Me.phone1Label.Size = New System.Drawing.Size(78, 17)
        Me.phone1Label.TabIndex = 19
        Me.phone1Label.Text = "Phone - 1 :"
        '
        'phone2Label
        '
        Me.phone2Label.AutoSize = True
        Me.phone2Label.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.phone2Label.Location = New System.Drawing.Point(570, 342)
        Me.phone2Label.Name = "phone2Label"
        Me.phone2Label.Size = New System.Drawing.Size(78, 17)
        Me.phone2Label.TabIndex = 20
        Me.phone2Label.Text = "Phone - 2 :"
        '
        'taxRateLabel
        '
        Me.taxRateLabel.AutoSize = True
        Me.taxRateLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.taxRateLabel.Location = New System.Drawing.Point(570, 433)
        Me.taxRateLabel.Name = "taxRateLabel"
        Me.taxRateLabel.Size = New System.Drawing.Size(73, 17)
        Me.taxRateLabel.TabIndex = 21
        Me.taxRateLabel.Text = "Tax Rate :"
        '
        'laborRateLabel
        '
        Me.laborRateLabel.AutoSize = True
        Me.laborRateLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.laborRateLabel.Location = New System.Drawing.Point(350, 531)
        Me.laborRateLabel.Name = "laborRateLabel"
        Me.laborRateLabel.Size = New System.Drawing.Size(87, 17)
        Me.laborRateLabel.TabIndex = 22
        Me.laborRateLabel.Text = "Labor Rate :"
        '
        'editButton
        '
        Me.editButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.editButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.editButton.ForeColor = System.Drawing.Color.White
        Me.editButton.Location = New System.Drawing.Point(100, 120)
        Me.editButton.Name = "editButton"
        Me.editButton.Size = New System.Drawing.Size(110, 30)
        Me.editButton.TabIndex = 10
        Me.editButton.Text = "Edit"
        Me.editButton.UseVisualStyleBackColor = False
        '
        'saveButton
        '
        Me.saveButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.saveButton.Enabled = False
        Me.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.saveButton.ForeColor = System.Drawing.Color.White
        Me.saveButton.Location = New System.Drawing.Point(216, 120)
        Me.saveButton.Name = "saveButton"
        Me.saveButton.Size = New System.Drawing.Size(110, 30)
        Me.saveButton.TabIndex = 11
        Me.saveButton.Text = "Save"
        Me.saveButton.UseVisualStyleBackColor = False
        '
        'cancelButton
        '
        Me.cancelButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.cancelButton.Enabled = False
        Me.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cancelButton.ForeColor = System.Drawing.Color.White
        Me.cancelButton.Location = New System.Drawing.Point(333, 120)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(110, 30)
        Me.cancelButton.TabIndex = 12
        Me.cancelButton.Text = "Cancel"
        Me.cancelButton.UseVisualStyleBackColor = False
        '
        'stateLabel
        '
        Me.stateLabel.AutoSize = True
        Me.stateLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.stateLabel.Location = New System.Drawing.Point(347, 433)
        Me.stateLabel.Name = "stateLabel"
        Me.stateLabel.Size = New System.Drawing.Size(49, 17)
        Me.stateLabel.TabIndex = 27
        Me.stateLabel.Text = "State :"
        '
        'State_Textbox
        '
        Me.State_Textbox.Enabled = False
        Me.State_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.State_Textbox.Location = New System.Drawing.Point(402, 427)
        Me.State_Textbox.Name = "State_Textbox"
        Me.State_Textbox.Size = New System.Drawing.Size(110, 27)
        Me.State_Textbox.TabIndex = 28
        Me.State_Textbox.Tag = "dataEditingControl"
        Me.State_Textbox.Visible = False
        '
        'CompanyName1_Value
        '
        Me.CompanyName1_Value.AutoSize = True
        Me.CompanyName1_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CompanyName1_Value.ForeColor = System.Drawing.Color.Black
        Me.CompanyName1_Value.Location = New System.Drawing.Point(275, 197)
        Me.CompanyName1_Value.Name = "CompanyName1_Value"
        Me.CompanyName1_Value.Size = New System.Drawing.Size(0, 20)
        Me.CompanyName1_Value.TabIndex = 29
        Me.CompanyName1_Value.Tag = "dataViewingControl"
        '
        'CompanyName2_Value
        '
        Me.CompanyName2_Value.AutoSize = True
        Me.CompanyName2_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CompanyName2_Value.ForeColor = System.Drawing.Color.Black
        Me.CompanyName2_Value.Location = New System.Drawing.Point(275, 234)
        Me.CompanyName2_Value.Name = "CompanyName2_Value"
        Me.CompanyName2_Value.Size = New System.Drawing.Size(0, 20)
        Me.CompanyName2_Value.TabIndex = 30
        Me.CompanyName2_Value.Tag = "dataViewingControl"
        '
        'Address1_Value
        '
        Me.Address1_Value.AutoSize = True
        Me.Address1_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Address1_Value.ForeColor = System.Drawing.Color.Black
        Me.Address1_Value.Location = New System.Drawing.Point(223, 289)
        Me.Address1_Value.Name = "Address1_Value"
        Me.Address1_Value.Size = New System.Drawing.Size(0, 20)
        Me.Address1_Value.TabIndex = 31
        Me.Address1_Value.Tag = "dataViewingControl"
        '
        'Address2_Value
        '
        Me.Address2_Value.AutoSize = True
        Me.Address2_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Address2_Value.ForeColor = System.Drawing.Color.Black
        Me.Address2_Value.Location = New System.Drawing.Point(223, 333)
        Me.Address2_Value.Name = "Address2_Value"
        Me.Address2_Value.Size = New System.Drawing.Size(0, 20)
        Me.Address2_Value.TabIndex = 32
        Me.Address2_Value.Tag = "dataViewingControl"
        '
        'ZipCode_Value
        '
        Me.ZipCode_Value.AutoSize = True
        Me.ZipCode_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ZipCode_Value.ForeColor = System.Drawing.Color.Black
        Me.ZipCode_Value.Location = New System.Drawing.Point(176, 386)
        Me.ZipCode_Value.Name = "ZipCode_Value"
        Me.ZipCode_Value.Size = New System.Drawing.Size(0, 20)
        Me.ZipCode_Value.TabIndex = 33
        Me.ZipCode_Value.Tag = "dataViewingControl"
        '
        'city_Value
        '
        Me.city_Value.AutoSize = True
        Me.city_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.city_Value.ForeColor = System.Drawing.Color.Black
        Me.city_Value.Location = New System.Drawing.Point(142, 430)
        Me.city_Value.Name = "city_Value"
        Me.city_Value.Size = New System.Drawing.Size(0, 20)
        Me.city_Value.TabIndex = 34
        Me.city_Value.Tag = "dataViewingControl"
        '
        'State_Value
        '
        Me.State_Value.AutoSize = True
        Me.State_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.State_Value.ForeColor = System.Drawing.Color.Black
        Me.State_Value.Location = New System.Drawing.Point(402, 430)
        Me.State_Value.Name = "State_Value"
        Me.State_Value.Size = New System.Drawing.Size(0, 20)
        Me.State_Value.TabIndex = 35
        Me.State_Value.Tag = "dataViewingControl"
        '
        'TaxRate_Value
        '
        Me.TaxRate_Value.AutoSize = True
        Me.TaxRate_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TaxRate_Value.ForeColor = System.Drawing.Color.Black
        Me.TaxRate_Value.Location = New System.Drawing.Point(654, 430)
        Me.TaxRate_Value.Name = "TaxRate_Value"
        Me.TaxRate_Value.Size = New System.Drawing.Size(0, 20)
        Me.TaxRate_Value.TabIndex = 36
        Me.TaxRate_Value.Tag = "dataViewingControl"
        '
        'Phone1_Value
        '
        Me.Phone1_Value.AutoSize = True
        Me.Phone1_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Phone1_Value.ForeColor = System.Drawing.Color.Black
        Me.Phone1_Value.Location = New System.Drawing.Point(654, 294)
        Me.Phone1_Value.Name = "Phone1_Value"
        Me.Phone1_Value.Size = New System.Drawing.Size(0, 20)
        Me.Phone1_Value.TabIndex = 37
        Me.Phone1_Value.Tag = "dataViewingControl"
        '
        'Phone2_Value
        '
        Me.Phone2_Value.AutoSize = True
        Me.Phone2_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Phone2_Value.ForeColor = System.Drawing.Color.Black
        Me.Phone2_Value.Location = New System.Drawing.Point(654, 339)
        Me.Phone2_Value.Name = "Phone2_Value"
        Me.Phone2_Value.Size = New System.Drawing.Size(0, 20)
        Me.Phone2_Value.TabIndex = 38
        Me.Phone2_Value.Tag = "dataViewingControl"
        '
        'ShopSupplyCharge_Value
        '
        Me.ShopSupplyCharge_Value.AutoSize = True
        Me.ShopSupplyCharge_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShopSupplyCharge_Value.ForeColor = System.Drawing.Color.Black
        Me.ShopSupplyCharge_Value.Location = New System.Drawing.Point(249, 528)
        Me.ShopSupplyCharge_Value.Name = "ShopSupplyCharge_Value"
        Me.ShopSupplyCharge_Value.Size = New System.Drawing.Size(0, 20)
        Me.ShopSupplyCharge_Value.TabIndex = 39
        Me.ShopSupplyCharge_Value.Tag = "dataViewingControl"
        '
        'LaborRate_Value
        '
        Me.LaborRate_Value.AutoSize = True
        Me.LaborRate_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LaborRate_Value.ForeColor = System.Drawing.Color.Black
        Me.LaborRate_Value.Location = New System.Drawing.Point(443, 528)
        Me.LaborRate_Value.Name = "LaborRate_Value"
        Me.LaborRate_Value.Size = New System.Drawing.Size(0, 20)
        Me.LaborRate_Value.TabIndex = 40
        Me.LaborRate_Value.Tag = "dataViewingControl"
        '
        'ZipCode_ComboBox
        '
        Me.ZipCode_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ZipCode_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ZipCode_ComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ZipCode_ComboBox.FormattingEnabled = True
        Me.ZipCode_ComboBox.Location = New System.Drawing.Point(176, 383)
        Me.ZipCode_ComboBox.MaxLength = 5
        Me.ZipCode_ComboBox.Name = "ZipCode_ComboBox"
        Me.ZipCode_ComboBox.Size = New System.Drawing.Size(150, 28)
        Me.ZipCode_ComboBox.TabIndex = 4
        Me.ZipCode_ComboBox.Tag = "dataEditingControl"
        Me.ZipCode_ComboBox.Visible = False
        '
        'Phone1_Textbox
        '
        Me.Phone1_Textbox.AllowPromptAsInput = False
        Me.Phone1_Textbox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.Phone1_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.Phone1_Textbox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert
        Me.Phone1_Textbox.Location = New System.Drawing.Point(654, 286)
        Me.Phone1_Textbox.Mask = "(999) 000-0000"
        Me.Phone1_Textbox.Name = "Phone1_Textbox"
        Me.Phone1_Textbox.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.Phone1_Textbox.Size = New System.Drawing.Size(181, 27)
        Me.Phone1_Textbox.TabIndex = 5
        Me.Phone1_Textbox.Tag = "dataEditingControl"
        Me.Phone1_Textbox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.Phone1_Textbox.Visible = False
        '
        'Phone2_Textbox
        '
        Me.Phone2_Textbox.AllowPromptAsInput = False
        Me.Phone2_Textbox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.Phone2_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.Phone2_Textbox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert
        Me.Phone2_Textbox.Location = New System.Drawing.Point(654, 336)
        Me.Phone2_Textbox.Mask = "(999) 000-0000"
        Me.Phone2_Textbox.Name = "Phone2_Textbox"
        Me.Phone2_Textbox.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.Phone2_Textbox.Size = New System.Drawing.Size(181, 27)
        Me.Phone2_Textbox.TabIndex = 6
        Me.Phone2_Textbox.Tag = "dataEditingControl"
        Me.Phone2_Textbox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.Phone2_Textbox.Visible = False
        '
        'nav
        '
        Me.nav.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nav.Location = New System.Drawing.Point(0, 0)
        Me.nav.Name = "nav"
        Me.nav.Size = New System.Drawing.Size(982, 28)
        Me.nav.TabIndex = 44
        '
        'companyInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(982, 753)
        Me.Controls.Add(Me.nav)
        Me.Controls.Add(Me.Phone2_Textbox)
        Me.Controls.Add(Me.Phone1_Textbox)
        Me.Controls.Add(Me.ZipCode_ComboBox)
        Me.Controls.Add(Me.LaborRate_Value)
        Me.Controls.Add(Me.ShopSupplyCharge_Value)
        Me.Controls.Add(Me.Phone2_Value)
        Me.Controls.Add(Me.Phone1_Value)
        Me.Controls.Add(Me.TaxRate_Value)
        Me.Controls.Add(Me.State_Value)
        Me.Controls.Add(Me.city_Value)
        Me.Controls.Add(Me.ZipCode_Value)
        Me.Controls.Add(Me.Address2_Value)
        Me.Controls.Add(Me.Address1_Value)
        Me.Controls.Add(Me.CompanyName2_Value)
        Me.Controls.Add(Me.CompanyName1_Value)
        Me.Controls.Add(Me.stateLabel)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.editButton)
        Me.Controls.Add(Me.laborRateLabel)
        Me.Controls.Add(Me.taxRateLabel)
        Me.Controls.Add(Me.phone2Label)
        Me.Controls.Add(Me.phone1Label)
        Me.Controls.Add(Me.companyInfoLabel)
        Me.Controls.Add(Me.shopSupplyChargeLabel)
        Me.Controls.Add(Me.cityLabel)
        Me.Controls.Add(Me.zipCodeLabel)
        Me.Controls.Add(Me.addressLine2Label)
        Me.Controls.Add(Me.addressLine1Label)
        Me.Controls.Add(Me.companyNameLabel2)
        Me.Controls.Add(Me.companyNameLabel)
        Me.Controls.Add(Me.TaxRate_Textbox)
        Me.Controls.Add(Me.State_Textbox)
        Me.Controls.Add(Me.LaborRate_Textbox)
        Me.Controls.Add(Me.Address2_Textbox)
        Me.Controls.Add(Me.Address1_Textbox)
        Me.Controls.Add(Me.ShopSupplyCharge_Textbox)
        Me.Controls.Add(Me.city_Textbox)
        Me.Controls.Add(Me.CompanyName2_Textbox)
        Me.Controls.Add(Me.CompanyName1_Textbox)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "companyInfo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Company Setup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents companyNameLabel As Label
    Friend WithEvents companyNameLabel2 As Label
    Friend WithEvents addressLine1Label As Label
    Friend WithEvents addressLine2Label As Label
    Friend WithEvents zipCodeLabel As Label
    Friend WithEvents cityLabel As Label
    Friend WithEvents shopSupplyChargeLabel As Label
    Friend WithEvents companyInfoLabel As Label
    Friend WithEvents CompanyName1_Textbox As TextBox
    Friend WithEvents CompanyName2_Textbox As TextBox
    Friend WithEvents Address1_Textbox As TextBox
    Friend WithEvents Address2_Textbox As TextBox
    Friend WithEvents city_Textbox As TextBox
    Friend WithEvents ShopSupplyCharge_Textbox As TextBox
    Friend WithEvents TaxRate_Textbox As TextBox
    Friend WithEvents phone1Label As Label
    Friend WithEvents phone2Label As Label
    Friend WithEvents taxRateLabel As Label
    Friend WithEvents laborRateLabel As Label
    Friend WithEvents editButton As Button
    Friend WithEvents saveButton As Button
    Friend WithEvents cancelButton As Button
    Friend WithEvents stateLabel As Label
    Friend WithEvents State_Textbox As TextBox
    Friend WithEvents CompanyName1_Value As Label
    Friend WithEvents CompanyName2_Value As Label
    Friend WithEvents Address1_Value As Label
    Friend WithEvents Address2_Value As Label
    Friend WithEvents ZipCode_Value As Label
    Friend WithEvents city_Value As Label
    Friend WithEvents State_Value As Label
    Friend WithEvents TaxRate_Value As Label
    Friend WithEvents Phone1_Value As Label
    Friend WithEvents Phone2_Value As Label
    Friend WithEvents ShopSupplyCharge_Value As Label
    Friend WithEvents LaborRate_Value As Label
    Friend WithEvents ZipCode_ComboBox As ComboBox
    Friend WithEvents Phone1_Textbox As MaskedTextBox
    Friend WithEvents Phone2_Textbox As MaskedTextBox
    Friend WithEvents LaborRate_Textbox As TextBox
    Friend WithEvents nav As navigation
End Class
