<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class vehicleMaintenance
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
        Me.deleteButton = New System.Windows.Forms.Button()
        Me.vehicleMaintenanceLabel = New System.Windows.Forms.Label()
        Me.editButton = New System.Windows.Forms.Button()
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.addButton = New System.Windows.Forms.Button()
        Me.VehicleLabel = New System.Windows.Forms.Label()
        Me.VehicleComboBox = New System.Windows.Forms.ComboBox()
        Me.CustomerComboLabel = New System.Windows.Forms.Label()
        Me.CustomerComboBox = New System.Windows.Forms.ComboBox()
        Me.Alarm_CheckBox = New System.Windows.Forms.CheckBox()
        Me.AlarmLabel = New System.Windows.Forms.Label()
        Me.VIN_Value = New System.Windows.Forms.Label()
        Me.VINLabel = New System.Windows.Forms.Label()
        Me.VIN_Textbox = New System.Windows.Forms.TextBox()
        Me.Make_Value = New System.Windows.Forms.Label()
        Me.ManufacturerLabel = New System.Windows.Forms.Label()
        Me.Model_Value = New System.Windows.Forms.Label()
        Me.ModelLabel = New System.Windows.Forms.Label()
        Me.Make_ComboBox = New System.Windows.Forms.ComboBox()
        Me.Model_ComboBox = New System.Windows.Forms.ComboBox()
        Me.makeYear_Value = New System.Windows.Forms.Label()
        Me.YearLabel = New System.Windows.Forms.Label()
        Me.makeYear_Textbox = New System.Windows.Forms.TextBox()
        Me.Color_ComboBox = New System.Windows.Forms.ComboBox()
        Me.Color_Value = New System.Windows.Forms.Label()
        Me.ColorLabel = New System.Windows.Forms.Label()
        Me.LicenseState_ComboBox = New System.Windows.Forms.ComboBox()
        Me.LicenseState_Value = New System.Windows.Forms.Label()
        Me.LicenseStateLabel = New System.Windows.Forms.Label()
        Me.LicensePlate_Value = New System.Windows.Forms.Label()
        Me.LicensePlateLabel = New System.Windows.Forms.Label()
        Me.LicensePlate_Textbox = New System.Windows.Forms.TextBox()
        Me.InspectionMonth_ComboBox = New System.Windows.Forms.ComboBox()
        Me.InspectionMonth_Value = New System.Windows.Forms.Label()
        Me.InspectionMonthLabel = New System.Windows.Forms.Label()
        Me.InsuranceCompany_ComboBox = New System.Windows.Forms.ComboBox()
        Me.InsuranceCompany_Value = New System.Windows.Forms.Label()
        Me.InsuranceCompanyLabel = New System.Windows.Forms.Label()
        Me.InspectionStickerNbr_Value = New System.Windows.Forms.Label()
        Me.InspectionStickerNbrLabel = New System.Windows.Forms.Label()
        Me.InspectionStickerNbr_Textbox = New System.Windows.Forms.TextBox()
        Me.PolicyNumber_Value = New System.Windows.Forms.Label()
        Me.PolicyNumberLabel = New System.Windows.Forms.Label()
        Me.PolicyNumber_Textbox = New System.Windows.Forms.TextBox()
        Me.ExpirationDate_Value = New System.Windows.Forms.Label()
        Me.ExpirationDateLabel = New System.Windows.Forms.Label()
        Me.ExpirationDate_Textbox = New System.Windows.Forms.MaskedTextBox()
        Me.ABS_CheckBox = New System.Windows.Forms.CheckBox()
        Me.ABSLabel = New System.Windows.Forms.Label()
        Me.AirBags_CheckBox = New System.Windows.Forms.CheckBox()
        Me.AirbagsLabel = New System.Windows.Forms.Label()
        Me.AC_CheckBox = New System.Windows.Forms.CheckBox()
        Me.ACLabel = New System.Windows.Forms.Label()
        Me.Engine_Value = New System.Windows.Forms.Label()
        Me.EngineLabel = New System.Windows.Forms.Label()
        Me.Engine_Textbox = New System.Windows.Forms.TextBox()
        Me.Notes_Value = New System.Windows.Forms.Label()
        Me.NotesLabel = New System.Windows.Forms.Label()
        Me.Notes_Textbox = New System.Windows.Forms.TextBox()
        Me.nav = New AutoServiceManager.navigation()
        Me.Alarm_Value = New System.Windows.Forms.CheckBox()
        Me.ABS_Value = New System.Windows.Forms.CheckBox()
        Me.AirBags_Value = New System.Windows.Forms.CheckBox()
        Me.AC_Value = New System.Windows.Forms.CheckBox()
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
        Me.deleteButton.TabIndex = 21
        Me.deleteButton.Text = "Delete"
        Me.deleteButton.UseVisualStyleBackColor = False
        '
        'vehicleMaintenanceLabel
        '
        Me.vehicleMaintenanceLabel.AutoSize = True
        Me.vehicleMaintenanceLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.vehicleMaintenanceLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.vehicleMaintenanceLabel.Location = New System.Drawing.Point(94, 73)
        Me.vehicleMaintenanceLabel.Name = "vehicleMaintenanceLabel"
        Me.vehicleMaintenanceLabel.Size = New System.Drawing.Size(132, 32)
        Me.vehicleMaintenanceLabel.TabIndex = 129
        Me.vehicleMaintenanceLabel.Text = "Vehicles"
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
        Me.editButton.TabIndex = 22
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
        Me.cancelButton.TabIndex = 24
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
        Me.saveButton.TabIndex = 23
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
        Me.addButton.TabIndex = 20
        Me.addButton.Text = "Add"
        Me.addButton.UseVisualStyleBackColor = False
        '
        'VehicleLabel
        '
        Me.VehicleLabel.AutoSize = True
        Me.VehicleLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.VehicleLabel.Location = New System.Drawing.Point(97, 256)
        Me.VehicleLabel.Name = "VehicleLabel"
        Me.VehicleLabel.Size = New System.Drawing.Size(62, 17)
        Me.VehicleLabel.TabIndex = 139
        Me.VehicleLabel.Text = "Vehicle :"
        '
        'VehicleComboBox
        '
        Me.VehicleComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.VehicleComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.VehicleComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.VehicleComboBox.FormattingEnabled = True
        Me.VehicleComboBox.Location = New System.Drawing.Point(165, 250)
        Me.VehicleComboBox.Name = "VehicleComboBox"
        Me.VehicleComboBox.Size = New System.Drawing.Size(509, 28)
        Me.VehicleComboBox.TabIndex = 1
        '
        'CustomerComboLabel
        '
        Me.CustomerComboLabel.AutoSize = True
        Me.CustomerComboLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.CustomerComboLabel.Location = New System.Drawing.Point(97, 200)
        Me.CustomerComboLabel.Name = "CustomerComboLabel"
        Me.CustomerComboLabel.Size = New System.Drawing.Size(76, 17)
        Me.CustomerComboLabel.TabIndex = 138
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
        Me.CustomerComboBox.Size = New System.Drawing.Size(508, 28)
        Me.CustomerComboBox.TabIndex = 0
        '
        'Alarm_CheckBox
        '
        Me.Alarm_CheckBox.AutoSize = True
        Me.Alarm_CheckBox.Location = New System.Drawing.Point(206, 585)
        Me.Alarm_CheckBox.Name = "Alarm_CheckBox"
        Me.Alarm_CheckBox.Size = New System.Drawing.Size(18, 17)
        Me.Alarm_CheckBox.TabIndex = 206
        Me.Alarm_CheckBox.Tag = "dataEditingControl"
        Me.Alarm_CheckBox.UseVisualStyleBackColor = True
        Me.Alarm_CheckBox.Visible = False
        '
        'AlarmLabel
        '
        Me.AlarmLabel.AutoSize = True
        Me.AlarmLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.AlarmLabel.Location = New System.Drawing.Point(98, 584)
        Me.AlarmLabel.Name = "AlarmLabel"
        Me.AlarmLabel.Size = New System.Drawing.Size(102, 17)
        Me.AlarmLabel.TabIndex = 205
        Me.AlarmLabel.Tag = "dataLabel"
        Me.AlarmLabel.Text = "Alarm System :"
        Me.AlarmLabel.Visible = False
        '
        'VIN_Value
        '
        Me.VIN_Value.AutoSize = True
        Me.VIN_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VIN_Value.ForeColor = System.Drawing.Color.Black
        Me.VIN_Value.Location = New System.Drawing.Point(141, 404)
        Me.VIN_Value.Name = "VIN_Value"
        Me.VIN_Value.Size = New System.Drawing.Size(0, 20)
        Me.VIN_Value.TabIndex = 188
        Me.VIN_Value.Tag = "dataViewingControl"
        Me.VIN_Value.Visible = False
        '
        'VINLabel
        '
        Me.VINLabel.AutoSize = True
        Me.VINLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.VINLabel.Location = New System.Drawing.Point(97, 407)
        Me.VINLabel.Name = "VINLabel"
        Me.VINLabel.Size = New System.Drawing.Size(38, 17)
        Me.VINLabel.TabIndex = 187
        Me.VINLabel.Tag = "dataLabel"
        Me.VINLabel.Text = "VIN :"
        Me.VINLabel.Visible = False
        '
        'VIN_Textbox
        '
        Me.VIN_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VIN_Textbox.Location = New System.Drawing.Point(141, 401)
        Me.VIN_Textbox.MaxLength = 20
        Me.VIN_Textbox.Name = "VIN_Textbox"
        Me.VIN_Textbox.Size = New System.Drawing.Size(315, 27)
        Me.VIN_Textbox.TabIndex = 8
        Me.VIN_Textbox.Tag = "dataEditingControl"
        Me.VIN_Textbox.Visible = False
        '
        'Make_Value
        '
        Me.Make_Value.AutoSize = True
        Me.Make_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Make_Value.ForeColor = System.Drawing.Color.Black
        Me.Make_Value.Location = New System.Drawing.Point(203, 312)
        Me.Make_Value.Name = "Make_Value"
        Me.Make_Value.Size = New System.Drawing.Size(0, 20)
        Me.Make_Value.TabIndex = 180
        Me.Make_Value.Tag = "dataViewingControl"
        Me.Make_Value.Visible = False
        '
        'ManufacturerLabel
        '
        Me.ManufacturerLabel.AutoSize = True
        Me.ManufacturerLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ManufacturerLabel.Location = New System.Drawing.Point(97, 315)
        Me.ManufacturerLabel.Name = "ManufacturerLabel"
        Me.ManufacturerLabel.Size = New System.Drawing.Size(100, 17)
        Me.ManufacturerLabel.TabIndex = 179
        Me.ManufacturerLabel.Tag = "dataLabel"
        Me.ManufacturerLabel.Text = "Manufacturer :"
        Me.ManufacturerLabel.Visible = False
        '
        'Model_Value
        '
        Me.Model_Value.AutoSize = True
        Me.Model_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Model_Value.ForeColor = System.Drawing.Color.Black
        Me.Model_Value.Location = New System.Drawing.Point(473, 312)
        Me.Model_Value.Name = "Model_Value"
        Me.Model_Value.Size = New System.Drawing.Size(0, 20)
        Me.Model_Value.TabIndex = 209
        Me.Model_Value.Tag = "dataViewingControl"
        Me.Model_Value.Visible = False
        '
        'ModelLabel
        '
        Me.ModelLabel.AutoSize = True
        Me.ModelLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ModelLabel.Location = New System.Drawing.Point(413, 315)
        Me.ModelLabel.Name = "ModelLabel"
        Me.ModelLabel.Size = New System.Drawing.Size(54, 17)
        Me.ModelLabel.TabIndex = 208
        Me.ModelLabel.Tag = "dataLabel"
        Me.ModelLabel.Text = "Model :"
        Me.ModelLabel.Visible = False
        '
        'Make_ComboBox
        '
        Me.Make_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Make_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Make_ComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Make_ComboBox.FormattingEnabled = True
        Me.Make_ComboBox.Location = New System.Drawing.Point(203, 309)
        Me.Make_ComboBox.MaxLength = 20
        Me.Make_ComboBox.Name = "Make_ComboBox"
        Me.Make_ComboBox.Size = New System.Drawing.Size(204, 28)
        Me.Make_ComboBox.TabIndex = 2
        Me.Make_ComboBox.Tag = "dataEditingControl"
        Me.Make_ComboBox.Visible = False
        '
        'Model_ComboBox
        '
        Me.Model_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Model_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Model_ComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Model_ComboBox.FormattingEnabled = True
        Me.Model_ComboBox.Location = New System.Drawing.Point(473, 309)
        Me.Model_ComboBox.MaxLength = 20
        Me.Model_ComboBox.Name = "Model_ComboBox"
        Me.Model_ComboBox.Size = New System.Drawing.Size(204, 28)
        Me.Model_ComboBox.TabIndex = 3
        Me.Model_ComboBox.Tag = "dataEditingControl"
        Me.Model_ComboBox.Visible = False
        '
        'makeYear_Value
        '
        Me.makeYear_Value.AutoSize = True
        Me.makeYear_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.makeYear_Value.ForeColor = System.Drawing.Color.Black
        Me.makeYear_Value.Location = New System.Drawing.Point(735, 312)
        Me.makeYear_Value.Name = "makeYear_Value"
        Me.makeYear_Value.Size = New System.Drawing.Size(0, 20)
        Me.makeYear_Value.TabIndex = 215
        Me.makeYear_Value.Tag = "dataViewingControl"
        Me.makeYear_Value.Visible = False
        '
        'YearLabel
        '
        Me.YearLabel.AutoSize = True
        Me.YearLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.YearLabel.Location = New System.Drawing.Point(683, 315)
        Me.YearLabel.Name = "YearLabel"
        Me.YearLabel.Size = New System.Drawing.Size(46, 17)
        Me.YearLabel.TabIndex = 214
        Me.YearLabel.Tag = "dataLabel"
        Me.YearLabel.Text = "Year :"
        Me.YearLabel.Visible = False
        '
        'makeYear_Textbox
        '
        Me.makeYear_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.makeYear_Textbox.Location = New System.Drawing.Point(735, 309)
        Me.makeYear_Textbox.MaxLength = 14
        Me.makeYear_Textbox.Name = "makeYear_Textbox"
        Me.makeYear_Textbox.Size = New System.Drawing.Size(92, 27)
        Me.makeYear_Textbox.TabIndex = 4
        Me.makeYear_Textbox.Tag = "dataEditingControl"
        Me.makeYear_Textbox.Visible = False
        '
        'Color_ComboBox
        '
        Me.Color_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Color_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Color_ComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Color_ComboBox.FormattingEnabled = True
        Me.Color_ComboBox.Location = New System.Drawing.Point(152, 355)
        Me.Color_ComboBox.MaxLength = 20
        Me.Color_ComboBox.Name = "Color_ComboBox"
        Me.Color_ComboBox.Size = New System.Drawing.Size(147, 28)
        Me.Color_ComboBox.TabIndex = 5
        Me.Color_ComboBox.Tag = "dataEditingControl"
        Me.Color_ComboBox.Visible = False
        '
        'Color_Value
        '
        Me.Color_Value.AutoSize = True
        Me.Color_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Color_Value.ForeColor = System.Drawing.Color.Black
        Me.Color_Value.Location = New System.Drawing.Point(152, 358)
        Me.Color_Value.Name = "Color_Value"
        Me.Color_Value.Size = New System.Drawing.Size(0, 20)
        Me.Color_Value.TabIndex = 217
        Me.Color_Value.Tag = "dataViewingControl"
        Me.Color_Value.Visible = False
        '
        'ColorLabel
        '
        Me.ColorLabel.AutoSize = True
        Me.ColorLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ColorLabel.Location = New System.Drawing.Point(97, 361)
        Me.ColorLabel.Name = "ColorLabel"
        Me.ColorLabel.Size = New System.Drawing.Size(49, 17)
        Me.ColorLabel.TabIndex = 216
        Me.ColorLabel.Tag = "dataLabel"
        Me.ColorLabel.Text = "Color :"
        Me.ColorLabel.Visible = False
        '
        'LicenseState_ComboBox
        '
        Me.LicenseState_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.LicenseState_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.LicenseState_ComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LicenseState_ComboBox.FormattingEnabled = True
        Me.LicenseState_ComboBox.Location = New System.Drawing.Point(413, 355)
        Me.LicenseState_ComboBox.MaxLength = 2
        Me.LicenseState_ComboBox.Name = "LicenseState_ComboBox"
        Me.LicenseState_ComboBox.Size = New System.Drawing.Size(205, 28)
        Me.LicenseState_ComboBox.TabIndex = 6
        Me.LicenseState_ComboBox.Tag = "dataEditingControl"
        Me.LicenseState_ComboBox.Visible = False
        '
        'LicenseState_Value
        '
        Me.LicenseState_Value.AutoSize = True
        Me.LicenseState_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LicenseState_Value.ForeColor = System.Drawing.Color.Black
        Me.LicenseState_Value.Location = New System.Drawing.Point(413, 358)
        Me.LicenseState_Value.Name = "LicenseState_Value"
        Me.LicenseState_Value.Size = New System.Drawing.Size(0, 20)
        Me.LicenseState_Value.TabIndex = 220
        Me.LicenseState_Value.Tag = "dataViewingControl"
        Me.LicenseState_Value.Visible = False
        '
        'LicenseStateLabel
        '
        Me.LicenseStateLabel.AutoSize = True
        Me.LicenseStateLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.LicenseStateLabel.Location = New System.Drawing.Point(305, 361)
        Me.LicenseStateLabel.Name = "LicenseStateLabel"
        Me.LicenseStateLabel.Size = New System.Drawing.Size(102, 17)
        Me.LicenseStateLabel.TabIndex = 219
        Me.LicenseStateLabel.Tag = "dataLabel"
        Me.LicenseStateLabel.Text = "License State :"
        Me.LicenseStateLabel.Visible = False
        '
        'LicensePlate_Value
        '
        Me.LicensePlate_Value.AutoSize = True
        Me.LicensePlate_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LicensePlate_Value.ForeColor = System.Drawing.Color.Black
        Me.LicensePlate_Value.Location = New System.Drawing.Point(731, 358)
        Me.LicensePlate_Value.Name = "LicensePlate_Value"
        Me.LicensePlate_Value.Size = New System.Drawing.Size(0, 20)
        Me.LicensePlate_Value.TabIndex = 224
        Me.LicensePlate_Value.Tag = "dataViewingControl"
        Me.LicensePlate_Value.Visible = False
        '
        'LicensePlateLabel
        '
        Me.LicensePlateLabel.AutoSize = True
        Me.LicensePlateLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.LicensePlateLabel.Location = New System.Drawing.Point(624, 361)
        Me.LicensePlateLabel.Name = "LicensePlateLabel"
        Me.LicensePlateLabel.Size = New System.Drawing.Size(101, 17)
        Me.LicensePlateLabel.TabIndex = 223
        Me.LicensePlateLabel.Tag = "dataLabel"
        Me.LicensePlateLabel.Text = "License Plate :"
        Me.LicensePlateLabel.Visible = False
        '
        'LicensePlate_Textbox
        '
        Me.LicensePlate_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LicensePlate_Textbox.Location = New System.Drawing.Point(731, 355)
        Me.LicensePlate_Textbox.MaxLength = 10
        Me.LicensePlate_Textbox.Name = "LicensePlate_Textbox"
        Me.LicensePlate_Textbox.Size = New System.Drawing.Size(126, 27)
        Me.LicensePlate_Textbox.TabIndex = 7
        Me.LicensePlate_Textbox.Tag = "dataEditingControl"
        Me.LicensePlate_Textbox.Visible = False
        '
        'InspectionMonth_ComboBox
        '
        Me.InspectionMonth_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.InspectionMonth_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.InspectionMonth_ComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InspectionMonth_ComboBox.FormattingEnabled = True
        Me.InspectionMonth_ComboBox.Location = New System.Drawing.Point(226, 445)
        Me.InspectionMonth_ComboBox.MaxLength = 3
        Me.InspectionMonth_ComboBox.Name = "InspectionMonth_ComboBox"
        Me.InspectionMonth_ComboBox.Size = New System.Drawing.Size(73, 28)
        Me.InspectionMonth_ComboBox.TabIndex = 9
        Me.InspectionMonth_ComboBox.Tag = "dataEditingControl"
        Me.InspectionMonth_ComboBox.Visible = False
        '
        'InspectionMonth_Value
        '
        Me.InspectionMonth_Value.AutoSize = True
        Me.InspectionMonth_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InspectionMonth_Value.ForeColor = System.Drawing.Color.Black
        Me.InspectionMonth_Value.Location = New System.Drawing.Point(226, 448)
        Me.InspectionMonth_Value.Name = "InspectionMonth_Value"
        Me.InspectionMonth_Value.Size = New System.Drawing.Size(0, 20)
        Me.InspectionMonth_Value.TabIndex = 226
        Me.InspectionMonth_Value.Tag = "dataViewingControl"
        Me.InspectionMonth_Value.Visible = False
        '
        'InspectionMonthLabel
        '
        Me.InspectionMonthLabel.AutoSize = True
        Me.InspectionMonthLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.InspectionMonthLabel.Location = New System.Drawing.Point(97, 451)
        Me.InspectionMonthLabel.Name = "InspectionMonthLabel"
        Me.InspectionMonthLabel.Size = New System.Drawing.Size(123, 17)
        Me.InspectionMonthLabel.TabIndex = 225
        Me.InspectionMonthLabel.Tag = "dataLabel"
        Me.InspectionMonthLabel.Text = "Inspection Month :"
        Me.InspectionMonthLabel.Visible = False
        '
        'InsuranceCompany_ComboBox
        '
        Me.InsuranceCompany_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.InsuranceCompany_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.InsuranceCompany_ComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InsuranceCompany_ComboBox.FormattingEnabled = True
        Me.InsuranceCompany_ComboBox.Location = New System.Drawing.Point(244, 489)
        Me.InsuranceCompany_ComboBox.MaxLength = 100
        Me.InsuranceCompany_ComboBox.Name = "InsuranceCompany_ComboBox"
        Me.InsuranceCompany_ComboBox.Size = New System.Drawing.Size(305, 28)
        Me.InsuranceCompany_ComboBox.TabIndex = 11
        Me.InsuranceCompany_ComboBox.Tag = "dataEditingControl"
        Me.InsuranceCompany_ComboBox.Visible = False
        '
        'InsuranceCompany_Value
        '
        Me.InsuranceCompany_Value.AutoSize = True
        Me.InsuranceCompany_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InsuranceCompany_Value.ForeColor = System.Drawing.Color.Black
        Me.InsuranceCompany_Value.Location = New System.Drawing.Point(244, 492)
        Me.InsuranceCompany_Value.Name = "InsuranceCompany_Value"
        Me.InsuranceCompany_Value.Size = New System.Drawing.Size(0, 20)
        Me.InsuranceCompany_Value.TabIndex = 229
        Me.InsuranceCompany_Value.Tag = "dataViewingControl"
        Me.InsuranceCompany_Value.Visible = False
        '
        'InsuranceCompanyLabel
        '
        Me.InsuranceCompanyLabel.AutoSize = True
        Me.InsuranceCompanyLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.InsuranceCompanyLabel.Location = New System.Drawing.Point(97, 495)
        Me.InsuranceCompanyLabel.Name = "InsuranceCompanyLabel"
        Me.InsuranceCompanyLabel.Size = New System.Drawing.Size(141, 17)
        Me.InsuranceCompanyLabel.TabIndex = 228
        Me.InsuranceCompanyLabel.Tag = "dataLabel"
        Me.InsuranceCompanyLabel.Text = "Insurance Company :"
        Me.InsuranceCompanyLabel.Visible = False
        '
        'InspectionStickerNbr_Value
        '
        Me.InspectionStickerNbr_Value.AutoSize = True
        Me.InspectionStickerNbr_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InspectionStickerNbr_Value.ForeColor = System.Drawing.Color.Black
        Me.InspectionStickerNbr_Value.Location = New System.Drawing.Point(507, 448)
        Me.InspectionStickerNbr_Value.Name = "InspectionStickerNbr_Value"
        Me.InspectionStickerNbr_Value.Size = New System.Drawing.Size(0, 20)
        Me.InspectionStickerNbr_Value.TabIndex = 233
        Me.InspectionStickerNbr_Value.Tag = "dataViewingControl"
        Me.InspectionStickerNbr_Value.Visible = False
        '
        'InspectionStickerNbrLabel
        '
        Me.InspectionStickerNbrLabel.AutoSize = True
        Me.InspectionStickerNbrLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.InspectionStickerNbrLabel.Location = New System.Drawing.Point(320, 451)
        Me.InspectionStickerNbrLabel.Name = "InspectionStickerNbrLabel"
        Me.InspectionStickerNbrLabel.Size = New System.Drawing.Size(181, 17)
        Me.InspectionStickerNbrLabel.TabIndex = 232
        Me.InspectionStickerNbrLabel.Tag = "dataLabel"
        Me.InspectionStickerNbrLabel.Text = "Inspection Sticker Number :"
        Me.InspectionStickerNbrLabel.Visible = False
        '
        'InspectionStickerNbr_Textbox
        '
        Me.InspectionStickerNbr_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InspectionStickerNbr_Textbox.Location = New System.Drawing.Point(507, 445)
        Me.InspectionStickerNbr_Textbox.MaxLength = 15
        Me.InspectionStickerNbr_Textbox.Name = "InspectionStickerNbr_Textbox"
        Me.InspectionStickerNbr_Textbox.Size = New System.Drawing.Size(229, 27)
        Me.InspectionStickerNbr_Textbox.TabIndex = 10
        Me.InspectionStickerNbr_Textbox.Tag = "dataEditingControl"
        Me.InspectionStickerNbr_Textbox.Visible = False
        '
        'PolicyNumber_Value
        '
        Me.PolicyNumber_Value.AutoSize = True
        Me.PolicyNumber_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PolicyNumber_Value.ForeColor = System.Drawing.Color.Black
        Me.PolicyNumber_Value.Location = New System.Drawing.Point(210, 536)
        Me.PolicyNumber_Value.Name = "PolicyNumber_Value"
        Me.PolicyNumber_Value.Size = New System.Drawing.Size(0, 20)
        Me.PolicyNumber_Value.TabIndex = 236
        Me.PolicyNumber_Value.Tag = "dataViewingControl"
        Me.PolicyNumber_Value.Visible = False
        '
        'PolicyNumberLabel
        '
        Me.PolicyNumberLabel.AutoSize = True
        Me.PolicyNumberLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.PolicyNumberLabel.Location = New System.Drawing.Point(97, 539)
        Me.PolicyNumberLabel.Name = "PolicyNumberLabel"
        Me.PolicyNumberLabel.Size = New System.Drawing.Size(107, 17)
        Me.PolicyNumberLabel.TabIndex = 235
        Me.PolicyNumberLabel.Tag = "dataLabel"
        Me.PolicyNumberLabel.Text = "Policy Number :"
        Me.PolicyNumberLabel.Visible = False
        '
        'PolicyNumber_Textbox
        '
        Me.PolicyNumber_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PolicyNumber_Textbox.Location = New System.Drawing.Point(210, 533)
        Me.PolicyNumber_Textbox.MaxLength = 20
        Me.PolicyNumber_Textbox.Name = "PolicyNumber_Textbox"
        Me.PolicyNumber_Textbox.Size = New System.Drawing.Size(186, 27)
        Me.PolicyNumber_Textbox.TabIndex = 12
        Me.PolicyNumber_Textbox.Tag = "dataEditingControl"
        Me.PolicyNumber_Textbox.Visible = False
        '
        'ExpirationDate_Value
        '
        Me.ExpirationDate_Value.AutoSize = True
        Me.ExpirationDate_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExpirationDate_Value.ForeColor = System.Drawing.Color.Black
        Me.ExpirationDate_Value.Location = New System.Drawing.Point(529, 536)
        Me.ExpirationDate_Value.Name = "ExpirationDate_Value"
        Me.ExpirationDate_Value.Size = New System.Drawing.Size(0, 20)
        Me.ExpirationDate_Value.TabIndex = 239
        Me.ExpirationDate_Value.Tag = "dataViewingControl"
        Me.ExpirationDate_Value.Visible = False
        '
        'ExpirationDateLabel
        '
        Me.ExpirationDateLabel.AutoSize = True
        Me.ExpirationDateLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ExpirationDateLabel.Location = New System.Drawing.Point(411, 539)
        Me.ExpirationDateLabel.Name = "ExpirationDateLabel"
        Me.ExpirationDateLabel.Size = New System.Drawing.Size(112, 17)
        Me.ExpirationDateLabel.TabIndex = 238
        Me.ExpirationDateLabel.Tag = "dataLabel"
        Me.ExpirationDateLabel.Text = "Expiration Date :"
        Me.ExpirationDateLabel.Visible = False
        '
        'ExpirationDate_Textbox
        '
        Me.ExpirationDate_Textbox.AllowPromptAsInput = False
        Me.ExpirationDate_Textbox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.ExpirationDate_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.ExpirationDate_Textbox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert
        Me.ExpirationDate_Textbox.Location = New System.Drawing.Point(530, 533)
        Me.ExpirationDate_Textbox.Mask = "00/00/0000"
        Me.ExpirationDate_Textbox.Name = "ExpirationDate_Textbox"
        Me.ExpirationDate_Textbox.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.ExpirationDate_Textbox.Size = New System.Drawing.Size(181, 27)
        Me.ExpirationDate_Textbox.TabIndex = 13
        Me.ExpirationDate_Textbox.Tag = "dataEditingControl"
        Me.ExpirationDate_Textbox.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.ExpirationDate_Textbox.ValidatingType = GetType(Date)
        Me.ExpirationDate_Textbox.Visible = False
        '
        'ABS_CheckBox
        '
        Me.ABS_CheckBox.AutoSize = True
        Me.ABS_CheckBox.Location = New System.Drawing.Point(394, 585)
        Me.ABS_CheckBox.Name = "ABS_CheckBox"
        Me.ABS_CheckBox.Size = New System.Drawing.Size(18, 17)
        Me.ABS_CheckBox.TabIndex = 244
        Me.ABS_CheckBox.Tag = "dataEditingControl"
        Me.ABS_CheckBox.UseVisualStyleBackColor = True
        Me.ABS_CheckBox.Visible = False
        '
        'ABSLabel
        '
        Me.ABSLabel.AutoSize = True
        Me.ABSLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ABSLabel.Location = New System.Drawing.Point(297, 584)
        Me.ABSLabel.Name = "ABSLabel"
        Me.ABSLabel.Size = New System.Drawing.Size(91, 17)
        Me.ABSLabel.TabIndex = 243
        Me.ABSLabel.Tag = "dataLabel"
        Me.ABSLabel.Text = "ABS Brakes :"
        Me.ABSLabel.Visible = False
        '
        'AirBags_CheckBox
        '
        Me.AirBags_CheckBox.AutoSize = True
        Me.AirBags_CheckBox.Location = New System.Drawing.Point(556, 585)
        Me.AirBags_CheckBox.Name = "AirBags_CheckBox"
        Me.AirBags_CheckBox.Size = New System.Drawing.Size(18, 17)
        Me.AirBags_CheckBox.TabIndex = 247
        Me.AirBags_CheckBox.Tag = "dataEditingControl"
        Me.AirBags_CheckBox.UseVisualStyleBackColor = True
        Me.AirBags_CheckBox.Visible = False
        '
        'AirbagsLabel
        '
        Me.AirbagsLabel.AutoSize = True
        Me.AirbagsLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.AirbagsLabel.Location = New System.Drawing.Point(485, 584)
        Me.AirbagsLabel.Name = "AirbagsLabel"
        Me.AirbagsLabel.Size = New System.Drawing.Size(65, 17)
        Me.AirbagsLabel.TabIndex = 246
        Me.AirbagsLabel.Tag = "dataLabel"
        Me.AirbagsLabel.Text = "AirBags :"
        Me.AirbagsLabel.Visible = False
        '
        'AC_CheckBox
        '
        Me.AC_CheckBox.AutoSize = True
        Me.AC_CheckBox.Location = New System.Drawing.Point(691, 586)
        Me.AC_CheckBox.Name = "AC_CheckBox"
        Me.AC_CheckBox.Size = New System.Drawing.Size(18, 17)
        Me.AC_CheckBox.TabIndex = 250
        Me.AC_CheckBox.Tag = "dataEditingControl"
        Me.AC_CheckBox.UseVisualStyleBackColor = True
        Me.AC_CheckBox.Visible = False
        '
        'ACLabel
        '
        Me.ACLabel.AutoSize = True
        Me.ACLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ACLabel.Location = New System.Drawing.Point(647, 585)
        Me.ACLabel.Name = "ACLabel"
        Me.ACLabel.Size = New System.Drawing.Size(38, 17)
        Me.ACLabel.TabIndex = 249
        Me.ACLabel.Tag = "dataLabel"
        Me.ACLabel.Text = "A/C :"
        Me.ACLabel.Visible = False
        '
        'Engine_Value
        '
        Me.Engine_Value.AutoSize = True
        Me.Engine_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Engine_Value.ForeColor = System.Drawing.Color.Black
        Me.Engine_Value.Location = New System.Drawing.Point(163, 626)
        Me.Engine_Value.Name = "Engine_Value"
        Me.Engine_Value.Size = New System.Drawing.Size(0, 20)
        Me.Engine_Value.TabIndex = 253
        Me.Engine_Value.Tag = "dataViewingControl"
        Me.Engine_Value.Visible = False
        '
        'EngineLabel
        '
        Me.EngineLabel.AutoSize = True
        Me.EngineLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.EngineLabel.Location = New System.Drawing.Point(97, 629)
        Me.EngineLabel.Name = "EngineLabel"
        Me.EngineLabel.Size = New System.Drawing.Size(60, 17)
        Me.EngineLabel.TabIndex = 252
        Me.EngineLabel.Tag = "dataLabel"
        Me.EngineLabel.Text = "Engine :"
        Me.EngineLabel.Visible = False
        '
        'Engine_Textbox
        '
        Me.Engine_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Engine_Textbox.Location = New System.Drawing.Point(163, 623)
        Me.Engine_Textbox.MaxLength = 20
        Me.Engine_Textbox.Name = "Engine_Textbox"
        Me.Engine_Textbox.Size = New System.Drawing.Size(163, 27)
        Me.Engine_Textbox.TabIndex = 18
        Me.Engine_Textbox.Tag = "dataEditingControl"
        Me.Engine_Textbox.Visible = False
        '
        'Notes_Value
        '
        Me.Notes_Value.AutoSize = True
        Me.Notes_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Notes_Value.ForeColor = System.Drawing.Color.Black
        Me.Notes_Value.Location = New System.Drawing.Point(156, 667)
        Me.Notes_Value.Name = "Notes_Value"
        Me.Notes_Value.Size = New System.Drawing.Size(0, 20)
        Me.Notes_Value.TabIndex = 256
        Me.Notes_Value.Tag = "dataViewingControl"
        Me.Notes_Value.Visible = False
        '
        'NotesLabel
        '
        Me.NotesLabel.AutoSize = True
        Me.NotesLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.NotesLabel.Location = New System.Drawing.Point(97, 670)
        Me.NotesLabel.Name = "NotesLabel"
        Me.NotesLabel.Size = New System.Drawing.Size(53, 17)
        Me.NotesLabel.TabIndex = 255
        Me.NotesLabel.Tag = "dataLabel"
        Me.NotesLabel.Text = "Notes :"
        Me.NotesLabel.Visible = False
        '
        'Notes_Textbox
        '
        Me.Notes_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Notes_Textbox.Location = New System.Drawing.Point(156, 664)
        Me.Notes_Textbox.MaxLength = 255
        Me.Notes_Textbox.Name = "Notes_Textbox"
        Me.Notes_Textbox.Size = New System.Drawing.Size(622, 27)
        Me.Notes_Textbox.TabIndex = 19
        Me.Notes_Textbox.Tag = "dataEditingControl"
        Me.Notes_Textbox.Visible = False
        '
        'nav
        '
        Me.nav.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nav.Location = New System.Drawing.Point(0, 0)
        Me.nav.Name = "nav"
        Me.nav.Size = New System.Drawing.Size(982, 28)
        Me.nav.TabIndex = 257
        '
        'Alarm_Value
        '
        Me.Alarm_Value.AutoCheck = False
        Me.Alarm_Value.AutoSize = True
        Me.Alarm_Value.Location = New System.Drawing.Point(206, 585)
        Me.Alarm_Value.Name = "Alarm_Value"
        Me.Alarm_Value.Size = New System.Drawing.Size(18, 17)
        Me.Alarm_Value.TabIndex = 322
        Me.Alarm_Value.Tag = "dataViewingControl"
        Me.Alarm_Value.UseVisualStyleBackColor = True
        Me.Alarm_Value.Visible = False
        '
        'ABS_Value
        '
        Me.ABS_Value.AutoCheck = False
        Me.ABS_Value.AutoSize = True
        Me.ABS_Value.Location = New System.Drawing.Point(394, 585)
        Me.ABS_Value.Name = "ABS_Value"
        Me.ABS_Value.Size = New System.Drawing.Size(18, 17)
        Me.ABS_Value.TabIndex = 323
        Me.ABS_Value.Tag = "dataViewingControl"
        Me.ABS_Value.UseVisualStyleBackColor = True
        Me.ABS_Value.Visible = False
        '
        'AirBags_Value
        '
        Me.AirBags_Value.AutoCheck = False
        Me.AirBags_Value.AutoSize = True
        Me.AirBags_Value.Location = New System.Drawing.Point(556, 585)
        Me.AirBags_Value.Name = "AirBags_Value"
        Me.AirBags_Value.Size = New System.Drawing.Size(18, 17)
        Me.AirBags_Value.TabIndex = 324
        Me.AirBags_Value.Tag = "dataViewingControl"
        Me.AirBags_Value.UseVisualStyleBackColor = True
        Me.AirBags_Value.Visible = False
        '
        'AC_Value
        '
        Me.AC_Value.AutoCheck = False
        Me.AC_Value.AutoSize = True
        Me.AC_Value.Location = New System.Drawing.Point(691, 586)
        Me.AC_Value.Name = "AC_Value"
        Me.AC_Value.Size = New System.Drawing.Size(18, 17)
        Me.AC_Value.TabIndex = 325
        Me.AC_Value.Tag = "dataViewingControl"
        Me.AC_Value.UseVisualStyleBackColor = True
        Me.AC_Value.Visible = False
        '
        'returnButton
        '
        Me.returnButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.returnButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.returnButton.ForeColor = System.Drawing.Color.White
        Me.returnButton.Location = New System.Drawing.Point(680, 120)
        Me.returnButton.Name = "returnButton"
        Me.returnButton.Size = New System.Drawing.Size(199, 30)
        Me.returnButton.TabIndex = 326
        Me.returnButton.Text = "Return To Invoice"
        Me.returnButton.UseVisualStyleBackColor = False
        '
        'vehicleMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(982, 753)
        Me.Controls.Add(Me.returnButton)
        Me.Controls.Add(Me.AC_Value)
        Me.Controls.Add(Me.AirBags_Value)
        Me.Controls.Add(Me.ABS_Value)
        Me.Controls.Add(Me.Alarm_Value)
        Me.Controls.Add(Me.nav)
        Me.Controls.Add(Me.Notes_Value)
        Me.Controls.Add(Me.NotesLabel)
        Me.Controls.Add(Me.Notes_Textbox)
        Me.Controls.Add(Me.Engine_Value)
        Me.Controls.Add(Me.EngineLabel)
        Me.Controls.Add(Me.Engine_Textbox)
        Me.Controls.Add(Me.AC_CheckBox)
        Me.Controls.Add(Me.ACLabel)
        Me.Controls.Add(Me.AirBags_CheckBox)
        Me.Controls.Add(Me.AirbagsLabel)
        Me.Controls.Add(Me.ABS_CheckBox)
        Me.Controls.Add(Me.ABSLabel)
        Me.Controls.Add(Me.ExpirationDate_Textbox)
        Me.Controls.Add(Me.ExpirationDate_Value)
        Me.Controls.Add(Me.ExpirationDateLabel)
        Me.Controls.Add(Me.PolicyNumber_Value)
        Me.Controls.Add(Me.PolicyNumberLabel)
        Me.Controls.Add(Me.PolicyNumber_Textbox)
        Me.Controls.Add(Me.InspectionStickerNbr_Value)
        Me.Controls.Add(Me.InspectionStickerNbrLabel)
        Me.Controls.Add(Me.InspectionStickerNbr_Textbox)
        Me.Controls.Add(Me.InsuranceCompany_ComboBox)
        Me.Controls.Add(Me.InsuranceCompany_Value)
        Me.Controls.Add(Me.InsuranceCompanyLabel)
        Me.Controls.Add(Me.InspectionMonth_ComboBox)
        Me.Controls.Add(Me.InspectionMonth_Value)
        Me.Controls.Add(Me.InspectionMonthLabel)
        Me.Controls.Add(Me.LicensePlate_Value)
        Me.Controls.Add(Me.LicensePlateLabel)
        Me.Controls.Add(Me.LicensePlate_Textbox)
        Me.Controls.Add(Me.LicenseState_ComboBox)
        Me.Controls.Add(Me.LicenseState_Value)
        Me.Controls.Add(Me.LicenseStateLabel)
        Me.Controls.Add(Me.Color_ComboBox)
        Me.Controls.Add(Me.Color_Value)
        Me.Controls.Add(Me.ColorLabel)
        Me.Controls.Add(Me.makeYear_Value)
        Me.Controls.Add(Me.YearLabel)
        Me.Controls.Add(Me.makeYear_Textbox)
        Me.Controls.Add(Me.Model_ComboBox)
        Me.Controls.Add(Me.Make_ComboBox)
        Me.Controls.Add(Me.Model_Value)
        Me.Controls.Add(Me.ModelLabel)
        Me.Controls.Add(Me.Alarm_CheckBox)
        Me.Controls.Add(Me.AlarmLabel)
        Me.Controls.Add(Me.VIN_Value)
        Me.Controls.Add(Me.VINLabel)
        Me.Controls.Add(Me.VIN_Textbox)
        Me.Controls.Add(Me.Make_Value)
        Me.Controls.Add(Me.ManufacturerLabel)
        Me.Controls.Add(Me.CustomerComboBox)
        Me.Controls.Add(Me.VehicleLabel)
        Me.Controls.Add(Me.VehicleComboBox)
        Me.Controls.Add(Me.CustomerComboLabel)
        Me.Controls.Add(Me.deleteButton)
        Me.Controls.Add(Me.vehicleMaintenanceLabel)
        Me.Controls.Add(Me.editButton)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.addButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "vehicleMaintenance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Vehicles"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents deleteButton As Button
    Friend WithEvents vehicleMaintenanceLabel As Label
    Friend WithEvents editButton As Button
    Friend WithEvents cancelButton As Button
    Friend WithEvents saveButton As Button
    Friend WithEvents addButton As Button
    Friend WithEvents VehicleLabel As Label
    Friend WithEvents VehicleComboBox As ComboBox
    Friend WithEvents CustomerComboLabel As Label
    Friend WithEvents CustomerComboBox As ComboBox
    Friend WithEvents Alarm_CheckBox As CheckBox
    Friend WithEvents AlarmLabel As Label
    Friend WithEvents VIN_Value As Label
    Friend WithEvents VINLabel As Label
    Friend WithEvents VIN_Textbox As TextBox
    Friend WithEvents Make_Value As Label
    Friend WithEvents ManufacturerLabel As Label
    Friend WithEvents Model_Value As Label
    Friend WithEvents ModelLabel As Label
    Friend WithEvents Make_ComboBox As ComboBox
    Friend WithEvents Model_ComboBox As ComboBox
    Friend WithEvents makeYear_Value As Label
    Friend WithEvents YearLabel As Label
    Friend WithEvents makeYear_Textbox As TextBox
    Friend WithEvents Color_ComboBox As ComboBox
    Friend WithEvents Color_Value As Label
    Friend WithEvents ColorLabel As Label
    Friend WithEvents LicenseState_ComboBox As ComboBox
    Friend WithEvents LicenseState_Value As Label
    Friend WithEvents LicenseStateLabel As Label
    Friend WithEvents LicensePlate_Value As Label
    Friend WithEvents LicensePlateLabel As Label
    Friend WithEvents LicensePlate_Textbox As TextBox
    Friend WithEvents InspectionMonth_ComboBox As ComboBox
    Friend WithEvents InspectionMonth_Value As Label
    Friend WithEvents InspectionMonthLabel As Label
    Friend WithEvents InsuranceCompany_ComboBox As ComboBox
    Friend WithEvents InsuranceCompany_Value As Label
    Friend WithEvents InsuranceCompanyLabel As Label
    Friend WithEvents InspectionStickerNbr_Value As Label
    Friend WithEvents InspectionStickerNbrLabel As Label
    Friend WithEvents InspectionStickerNbr_Textbox As TextBox
    Friend WithEvents PolicyNumber_Value As Label
    Friend WithEvents PolicyNumberLabel As Label
    Friend WithEvents PolicyNumber_Textbox As TextBox
    Friend WithEvents ExpirationDate_Value As Label
    Friend WithEvents ExpirationDateLabel As Label
    Friend WithEvents ExpirationDate_Textbox As MaskedTextBox
    Friend WithEvents ABS_CheckBox As CheckBox
    Friend WithEvents ABSLabel As Label
    Friend WithEvents AirBags_CheckBox As CheckBox
    Friend WithEvents AirbagsLabel As Label
    Friend WithEvents AC_CheckBox As CheckBox
    Friend WithEvents ACLabel As Label
    Friend WithEvents Engine_Value As Label
    Friend WithEvents EngineLabel As Label
    Friend WithEvents Engine_Textbox As TextBox
    Friend WithEvents Notes_Value As Label
    Friend WithEvents NotesLabel As Label
    Friend WithEvents Notes_Textbox As TextBox
    Friend WithEvents nav As navigation
    Friend WithEvents Alarm_Value As CheckBox
    Friend WithEvents ABS_Value As CheckBox
    Friend WithEvents AirBags_Value As CheckBox
    Friend WithEvents AC_Value As CheckBox
    Friend WithEvents returnButton As Button
End Class
