﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.Alarm_Value = New System.Windows.Forms.Label()
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
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.ABS_Value = New System.Windows.Forms.Label()
        Me.ABS_CheckBox = New System.Windows.Forms.CheckBox()
        Me.ABSLabel = New System.Windows.Forms.Label()
        Me.AirBags_Value = New System.Windows.Forms.Label()
        Me.AirBags_CheckBox = New System.Windows.Forms.CheckBox()
        Me.AirbagsLabel = New System.Windows.Forms.Label()
        Me.AC_Value = New System.Windows.Forms.Label()
        Me.AC_CheckBox = New System.Windows.Forms.CheckBox()
        Me.ACLabel = New System.Windows.Forms.Label()
        Me.Engine_Value = New System.Windows.Forms.Label()
        Me.EngineLabel = New System.Windows.Forms.Label()
        Me.Engine_Textbox = New System.Windows.Forms.TextBox()
        Me.Notes_Value = New System.Windows.Forms.Label()
        Me.NotesLabel = New System.Windows.Forms.Label()
        Me.Notes_Textbox = New System.Windows.Forms.TextBox()
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
        Me.VehicleComboBox.Size = New System.Drawing.Size(339, 28)
        Me.VehicleComboBox.TabIndex = 137
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
        Me.CustomerComboBox.Size = New System.Drawing.Size(362, 28)
        Me.CustomerComboBox.TabIndex = 0
        '
        'Alarm_Value
        '
        Me.Alarm_Value.AutoSize = True
        Me.Alarm_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Alarm_Value.ForeColor = System.Drawing.Color.Black
        Me.Alarm_Value.Location = New System.Drawing.Point(203, 580)
        Me.Alarm_Value.Name = "Alarm_Value"
        Me.Alarm_Value.Size = New System.Drawing.Size(0, 20)
        Me.Alarm_Value.TabIndex = 178
        Me.Alarm_Value.Tag = "dataViewingControl"
        '
        'Alarm_CheckBox
        '
        Me.Alarm_CheckBox.AutoSize = True
        Me.Alarm_CheckBox.Location = New System.Drawing.Point(203, 584)
        Me.Alarm_CheckBox.Name = "Alarm_CheckBox"
        Me.Alarm_CheckBox.Size = New System.Drawing.Size(18, 17)
        Me.Alarm_CheckBox.TabIndex = 206
        Me.Alarm_CheckBox.Tag = "dataEditingControl"
        Me.Alarm_CheckBox.UseVisualStyleBackColor = True
        '
        'AlarmLabel
        '
        Me.AlarmLabel.AutoSize = True
        Me.AlarmLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.AlarmLabel.Location = New System.Drawing.Point(95, 583)
        Me.AlarmLabel.Name = "AlarmLabel"
        Me.AlarmLabel.Size = New System.Drawing.Size(102, 17)
        Me.AlarmLabel.TabIndex = 205
        Me.AlarmLabel.Tag = "dataLabel"
        Me.AlarmLabel.Text = "Alarm System :"
        '
        'VIN_Value
        '
        Me.VIN_Value.AutoSize = True
        Me.VIN_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VIN_Value.ForeColor = System.Drawing.Color.Black
        Me.VIN_Value.Location = New System.Drawing.Point(138, 403)
        Me.VIN_Value.Name = "VIN_Value"
        Me.VIN_Value.Size = New System.Drawing.Size(0, 20)
        Me.VIN_Value.TabIndex = 188
        Me.VIN_Value.Tag = "dataViewingControl"
        '
        'VINLabel
        '
        Me.VINLabel.AutoSize = True
        Me.VINLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.VINLabel.Location = New System.Drawing.Point(94, 406)
        Me.VINLabel.Name = "VINLabel"
        Me.VINLabel.Size = New System.Drawing.Size(38, 17)
        Me.VINLabel.TabIndex = 187
        Me.VINLabel.Tag = "dataLabel"
        Me.VINLabel.Text = "VIN :"
        '
        'VIN_Textbox
        '
        Me.VIN_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VIN_Textbox.Location = New System.Drawing.Point(138, 400)
        Me.VIN_Textbox.MaxLength = 50
        Me.VIN_Textbox.Name = "VIN_Textbox"
        Me.VIN_Textbox.Size = New System.Drawing.Size(315, 27)
        Me.VIN_Textbox.TabIndex = 171
        Me.VIN_Textbox.Tag = "dataEditingControl"
        Me.VIN_Textbox.Visible = False
        '
        'Make_Value
        '
        Me.Make_Value.AutoSize = True
        Me.Make_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Make_Value.ForeColor = System.Drawing.Color.Black
        Me.Make_Value.Location = New System.Drawing.Point(200, 311)
        Me.Make_Value.Name = "Make_Value"
        Me.Make_Value.Size = New System.Drawing.Size(0, 20)
        Me.Make_Value.TabIndex = 180
        Me.Make_Value.Tag = "dataViewingControl"
        '
        'ManufacturerLabel
        '
        Me.ManufacturerLabel.AutoSize = True
        Me.ManufacturerLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ManufacturerLabel.Location = New System.Drawing.Point(94, 314)
        Me.ManufacturerLabel.Name = "ManufacturerLabel"
        Me.ManufacturerLabel.Size = New System.Drawing.Size(100, 17)
        Me.ManufacturerLabel.TabIndex = 179
        Me.ManufacturerLabel.Tag = "dataLabel"
        Me.ManufacturerLabel.Text = "Manufacturer :"
        '
        'Model_Value
        '
        Me.Model_Value.AutoSize = True
        Me.Model_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Model_Value.ForeColor = System.Drawing.Color.Black
        Me.Model_Value.Location = New System.Drawing.Point(470, 311)
        Me.Model_Value.Name = "Model_Value"
        Me.Model_Value.Size = New System.Drawing.Size(0, 20)
        Me.Model_Value.TabIndex = 209
        Me.Model_Value.Tag = "dataViewingControl"
        '
        'ModelLabel
        '
        Me.ModelLabel.AutoSize = True
        Me.ModelLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ModelLabel.Location = New System.Drawing.Point(410, 314)
        Me.ModelLabel.Name = "ModelLabel"
        Me.ModelLabel.Size = New System.Drawing.Size(54, 17)
        Me.ModelLabel.TabIndex = 208
        Me.ModelLabel.Tag = "dataLabel"
        Me.ModelLabel.Text = "Model :"
        '
        'Make_ComboBox
        '
        Me.Make_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Make_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Make_ComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Make_ComboBox.FormattingEnabled = True
        Me.Make_ComboBox.Location = New System.Drawing.Point(200, 308)
        Me.Make_ComboBox.MaxLength = 5
        Me.Make_ComboBox.Name = "Make_ComboBox"
        Me.Make_ComboBox.Size = New System.Drawing.Size(204, 28)
        Me.Make_ComboBox.TabIndex = 211
        Me.Make_ComboBox.Tag = "dataEditingControl"
        Me.Make_ComboBox.Visible = False
        '
        'Model_ComboBox
        '
        Me.Model_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Model_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Model_ComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Model_ComboBox.FormattingEnabled = True
        Me.Model_ComboBox.Location = New System.Drawing.Point(470, 308)
        Me.Model_ComboBox.MaxLength = 5
        Me.Model_ComboBox.Name = "Model_ComboBox"
        Me.Model_ComboBox.Size = New System.Drawing.Size(204, 28)
        Me.Model_ComboBox.TabIndex = 212
        Me.Model_ComboBox.Tag = "dataEditingControl"
        Me.Model_ComboBox.Visible = False
        '
        'makeYear_Value
        '
        Me.makeYear_Value.AutoSize = True
        Me.makeYear_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.makeYear_Value.ForeColor = System.Drawing.Color.Black
        Me.makeYear_Value.Location = New System.Drawing.Point(732, 311)
        Me.makeYear_Value.Name = "makeYear_Value"
        Me.makeYear_Value.Size = New System.Drawing.Size(0, 20)
        Me.makeYear_Value.TabIndex = 215
        Me.makeYear_Value.Tag = "dataViewingControl"
        '
        'YearLabel
        '
        Me.YearLabel.AutoSize = True
        Me.YearLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.YearLabel.Location = New System.Drawing.Point(680, 314)
        Me.YearLabel.Name = "YearLabel"
        Me.YearLabel.Size = New System.Drawing.Size(46, 17)
        Me.YearLabel.TabIndex = 214
        Me.YearLabel.Tag = "dataLabel"
        Me.YearLabel.Text = "Year :"
        '
        'makeYear_Textbox
        '
        Me.makeYear_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.makeYear_Textbox.Location = New System.Drawing.Point(732, 308)
        Me.makeYear_Textbox.MaxLength = 20
        Me.makeYear_Textbox.Name = "makeYear_Textbox"
        Me.makeYear_Textbox.Size = New System.Drawing.Size(92, 27)
        Me.makeYear_Textbox.TabIndex = 213
        Me.makeYear_Textbox.Tag = "dataEditingControl"
        Me.makeYear_Textbox.Visible = False
        '
        'Color_ComboBox
        '
        Me.Color_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.Color_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.Color_ComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Color_ComboBox.FormattingEnabled = True
        Me.Color_ComboBox.Location = New System.Drawing.Point(149, 354)
        Me.Color_ComboBox.MaxLength = 5
        Me.Color_ComboBox.Name = "Color_ComboBox"
        Me.Color_ComboBox.Size = New System.Drawing.Size(147, 28)
        Me.Color_ComboBox.TabIndex = 218
        Me.Color_ComboBox.Tag = "dataEditingControl"
        Me.Color_ComboBox.Visible = False
        '
        'Color_Value
        '
        Me.Color_Value.AutoSize = True
        Me.Color_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Color_Value.ForeColor = System.Drawing.Color.Black
        Me.Color_Value.Location = New System.Drawing.Point(149, 357)
        Me.Color_Value.Name = "Color_Value"
        Me.Color_Value.Size = New System.Drawing.Size(0, 20)
        Me.Color_Value.TabIndex = 217
        Me.Color_Value.Tag = "dataViewingControl"
        '
        'ColorLabel
        '
        Me.ColorLabel.AutoSize = True
        Me.ColorLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ColorLabel.Location = New System.Drawing.Point(94, 360)
        Me.ColorLabel.Name = "ColorLabel"
        Me.ColorLabel.Size = New System.Drawing.Size(49, 17)
        Me.ColorLabel.TabIndex = 216
        Me.ColorLabel.Tag = "dataLabel"
        Me.ColorLabel.Text = "Color :"
        '
        'LicenseState_ComboBox
        '
        Me.LicenseState_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.LicenseState_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.LicenseState_ComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LicenseState_ComboBox.FormattingEnabled = True
        Me.LicenseState_ComboBox.Location = New System.Drawing.Point(410, 354)
        Me.LicenseState_ComboBox.MaxLength = 5
        Me.LicenseState_ComboBox.Name = "LicenseState_ComboBox"
        Me.LicenseState_ComboBox.Size = New System.Drawing.Size(205, 28)
        Me.LicenseState_ComboBox.TabIndex = 221
        Me.LicenseState_ComboBox.Tag = "dataEditingControl"
        Me.LicenseState_ComboBox.Visible = False
        '
        'LicenseState_Value
        '
        Me.LicenseState_Value.AutoSize = True
        Me.LicenseState_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LicenseState_Value.ForeColor = System.Drawing.Color.Black
        Me.LicenseState_Value.Location = New System.Drawing.Point(410, 357)
        Me.LicenseState_Value.Name = "LicenseState_Value"
        Me.LicenseState_Value.Size = New System.Drawing.Size(0, 20)
        Me.LicenseState_Value.TabIndex = 220
        Me.LicenseState_Value.Tag = "dataViewingControl"
        '
        'LicenseStateLabel
        '
        Me.LicenseStateLabel.AutoSize = True
        Me.LicenseStateLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.LicenseStateLabel.Location = New System.Drawing.Point(302, 360)
        Me.LicenseStateLabel.Name = "LicenseStateLabel"
        Me.LicenseStateLabel.Size = New System.Drawing.Size(102, 17)
        Me.LicenseStateLabel.TabIndex = 219
        Me.LicenseStateLabel.Tag = "dataLabel"
        Me.LicenseStateLabel.Text = "License State :"
        '
        'LicensePlate_Value
        '
        Me.LicensePlate_Value.AutoSize = True
        Me.LicensePlate_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LicensePlate_Value.ForeColor = System.Drawing.Color.Black
        Me.LicensePlate_Value.Location = New System.Drawing.Point(728, 357)
        Me.LicensePlate_Value.Name = "LicensePlate_Value"
        Me.LicensePlate_Value.Size = New System.Drawing.Size(0, 20)
        Me.LicensePlate_Value.TabIndex = 224
        Me.LicensePlate_Value.Tag = "dataViewingControl"
        '
        'LicensePlateLabel
        '
        Me.LicensePlateLabel.AutoSize = True
        Me.LicensePlateLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.LicensePlateLabel.Location = New System.Drawing.Point(621, 360)
        Me.LicensePlateLabel.Name = "LicensePlateLabel"
        Me.LicensePlateLabel.Size = New System.Drawing.Size(101, 17)
        Me.LicensePlateLabel.TabIndex = 223
        Me.LicensePlateLabel.Tag = "dataLabel"
        Me.LicensePlateLabel.Text = "License Plate :"
        '
        'LicensePlate_Textbox
        '
        Me.LicensePlate_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LicensePlate_Textbox.Location = New System.Drawing.Point(728, 354)
        Me.LicensePlate_Textbox.MaxLength = 20
        Me.LicensePlate_Textbox.Name = "LicensePlate_Textbox"
        Me.LicensePlate_Textbox.Size = New System.Drawing.Size(126, 27)
        Me.LicensePlate_Textbox.TabIndex = 222
        Me.LicensePlate_Textbox.Tag = "dataEditingControl"
        Me.LicensePlate_Textbox.Visible = False
        '
        'InspectionMonth_ComboBox
        '
        Me.InspectionMonth_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.InspectionMonth_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.InspectionMonth_ComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InspectionMonth_ComboBox.FormattingEnabled = True
        Me.InspectionMonth_ComboBox.Location = New System.Drawing.Point(223, 444)
        Me.InspectionMonth_ComboBox.MaxLength = 5
        Me.InspectionMonth_ComboBox.Name = "InspectionMonth_ComboBox"
        Me.InspectionMonth_ComboBox.Size = New System.Drawing.Size(73, 28)
        Me.InspectionMonth_ComboBox.TabIndex = 227
        Me.InspectionMonth_ComboBox.Tag = "dataEditingControl"
        Me.InspectionMonth_ComboBox.Visible = False
        '
        'InspectionMonth_Value
        '
        Me.InspectionMonth_Value.AutoSize = True
        Me.InspectionMonth_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InspectionMonth_Value.ForeColor = System.Drawing.Color.Black
        Me.InspectionMonth_Value.Location = New System.Drawing.Point(223, 447)
        Me.InspectionMonth_Value.Name = "InspectionMonth_Value"
        Me.InspectionMonth_Value.Size = New System.Drawing.Size(0, 20)
        Me.InspectionMonth_Value.TabIndex = 226
        Me.InspectionMonth_Value.Tag = "dataViewingControl"
        '
        'InspectionMonthLabel
        '
        Me.InspectionMonthLabel.AutoSize = True
        Me.InspectionMonthLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.InspectionMonthLabel.Location = New System.Drawing.Point(94, 450)
        Me.InspectionMonthLabel.Name = "InspectionMonthLabel"
        Me.InspectionMonthLabel.Size = New System.Drawing.Size(123, 17)
        Me.InspectionMonthLabel.TabIndex = 225
        Me.InspectionMonthLabel.Tag = "dataLabel"
        Me.InspectionMonthLabel.Text = "Inspection Month :"
        '
        'InsuranceCompany_ComboBox
        '
        Me.InsuranceCompany_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.InsuranceCompany_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.InsuranceCompany_ComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InsuranceCompany_ComboBox.FormattingEnabled = True
        Me.InsuranceCompany_ComboBox.Location = New System.Drawing.Point(241, 488)
        Me.InsuranceCompany_ComboBox.MaxLength = 5
        Me.InsuranceCompany_ComboBox.Name = "InsuranceCompany_ComboBox"
        Me.InsuranceCompany_ComboBox.Size = New System.Drawing.Size(305, 28)
        Me.InsuranceCompany_ComboBox.TabIndex = 230
        Me.InsuranceCompany_ComboBox.Tag = "dataEditingControl"
        Me.InsuranceCompany_ComboBox.Visible = False
        '
        'InsuranceCompany_Value
        '
        Me.InsuranceCompany_Value.AutoSize = True
        Me.InsuranceCompany_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InsuranceCompany_Value.ForeColor = System.Drawing.Color.Black
        Me.InsuranceCompany_Value.Location = New System.Drawing.Point(241, 491)
        Me.InsuranceCompany_Value.Name = "InsuranceCompany_Value"
        Me.InsuranceCompany_Value.Size = New System.Drawing.Size(0, 20)
        Me.InsuranceCompany_Value.TabIndex = 229
        Me.InsuranceCompany_Value.Tag = "dataViewingControl"
        '
        'InsuranceCompanyLabel
        '
        Me.InsuranceCompanyLabel.AutoSize = True
        Me.InsuranceCompanyLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.InsuranceCompanyLabel.Location = New System.Drawing.Point(94, 494)
        Me.InsuranceCompanyLabel.Name = "InsuranceCompanyLabel"
        Me.InsuranceCompanyLabel.Size = New System.Drawing.Size(141, 17)
        Me.InsuranceCompanyLabel.TabIndex = 228
        Me.InsuranceCompanyLabel.Tag = "dataLabel"
        Me.InsuranceCompanyLabel.Text = "Insurance Company :"
        '
        'InspectionStickerNbr_Value
        '
        Me.InspectionStickerNbr_Value.AutoSize = True
        Me.InspectionStickerNbr_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InspectionStickerNbr_Value.ForeColor = System.Drawing.Color.Black
        Me.InspectionStickerNbr_Value.Location = New System.Drawing.Point(504, 447)
        Me.InspectionStickerNbr_Value.Name = "InspectionStickerNbr_Value"
        Me.InspectionStickerNbr_Value.Size = New System.Drawing.Size(0, 20)
        Me.InspectionStickerNbr_Value.TabIndex = 233
        Me.InspectionStickerNbr_Value.Tag = "dataViewingControl"
        '
        'InspectionStickerNbrLabel
        '
        Me.InspectionStickerNbrLabel.AutoSize = True
        Me.InspectionStickerNbrLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.InspectionStickerNbrLabel.Location = New System.Drawing.Point(317, 450)
        Me.InspectionStickerNbrLabel.Name = "InspectionStickerNbrLabel"
        Me.InspectionStickerNbrLabel.Size = New System.Drawing.Size(181, 17)
        Me.InspectionStickerNbrLabel.TabIndex = 232
        Me.InspectionStickerNbrLabel.Tag = "dataLabel"
        Me.InspectionStickerNbrLabel.Text = "Inspection Sticker Number :"
        '
        'InspectionStickerNbr_Textbox
        '
        Me.InspectionStickerNbr_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InspectionStickerNbr_Textbox.Location = New System.Drawing.Point(504, 444)
        Me.InspectionStickerNbr_Textbox.MaxLength = 20
        Me.InspectionStickerNbr_Textbox.Name = "InspectionStickerNbr_Textbox"
        Me.InspectionStickerNbr_Textbox.Size = New System.Drawing.Size(229, 27)
        Me.InspectionStickerNbr_Textbox.TabIndex = 231
        Me.InspectionStickerNbr_Textbox.Tag = "dataEditingControl"
        Me.InspectionStickerNbr_Textbox.Visible = False
        '
        'PolicyNumber_Value
        '
        Me.PolicyNumber_Value.AutoSize = True
        Me.PolicyNumber_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PolicyNumber_Value.ForeColor = System.Drawing.Color.Black
        Me.PolicyNumber_Value.Location = New System.Drawing.Point(207, 535)
        Me.PolicyNumber_Value.Name = "PolicyNumber_Value"
        Me.PolicyNumber_Value.Size = New System.Drawing.Size(0, 20)
        Me.PolicyNumber_Value.TabIndex = 236
        Me.PolicyNumber_Value.Tag = "dataViewingControl"
        '
        'PolicyNumberLabel
        '
        Me.PolicyNumberLabel.AutoSize = True
        Me.PolicyNumberLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.PolicyNumberLabel.Location = New System.Drawing.Point(94, 538)
        Me.PolicyNumberLabel.Name = "PolicyNumberLabel"
        Me.PolicyNumberLabel.Size = New System.Drawing.Size(107, 17)
        Me.PolicyNumberLabel.TabIndex = 235
        Me.PolicyNumberLabel.Tag = "dataLabel"
        Me.PolicyNumberLabel.Text = "Policy Number :"
        '
        'PolicyNumber_Textbox
        '
        Me.PolicyNumber_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PolicyNumber_Textbox.Location = New System.Drawing.Point(207, 532)
        Me.PolicyNumber_Textbox.MaxLength = 20
        Me.PolicyNumber_Textbox.Name = "PolicyNumber_Textbox"
        Me.PolicyNumber_Textbox.Size = New System.Drawing.Size(186, 27)
        Me.PolicyNumber_Textbox.TabIndex = 234
        Me.PolicyNumber_Textbox.Tag = "dataEditingControl"
        Me.PolicyNumber_Textbox.Visible = False
        '
        'ExpirationDate_Value
        '
        Me.ExpirationDate_Value.AutoSize = True
        Me.ExpirationDate_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExpirationDate_Value.ForeColor = System.Drawing.Color.Black
        Me.ExpirationDate_Value.Location = New System.Drawing.Point(526, 535)
        Me.ExpirationDate_Value.Name = "ExpirationDate_Value"
        Me.ExpirationDate_Value.Size = New System.Drawing.Size(0, 20)
        Me.ExpirationDate_Value.TabIndex = 239
        Me.ExpirationDate_Value.Tag = "dataViewingControl"
        '
        'ExpirationDateLabel
        '
        Me.ExpirationDateLabel.AutoSize = True
        Me.ExpirationDateLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ExpirationDateLabel.Location = New System.Drawing.Point(408, 538)
        Me.ExpirationDateLabel.Name = "ExpirationDateLabel"
        Me.ExpirationDateLabel.Size = New System.Drawing.Size(112, 17)
        Me.ExpirationDateLabel.TabIndex = 238
        Me.ExpirationDateLabel.Tag = "dataLabel"
        Me.ExpirationDateLabel.Text = "Expiration Date :"
        '
        'ExpirationDate_Textbox
        '
        Me.ExpirationDate_Textbox.AllowPromptAsInput = False
        Me.ExpirationDate_Textbox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.ExpirationDate_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.ExpirationDate_Textbox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert
        Me.ExpirationDate_Textbox.Location = New System.Drawing.Point(527, 532)
        Me.ExpirationDate_Textbox.Mask = "00/00/0000"
        Me.ExpirationDate_Textbox.Name = "ExpirationDate_Textbox"
        Me.ExpirationDate_Textbox.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.ExpirationDate_Textbox.Size = New System.Drawing.Size(181, 27)
        Me.ExpirationDate_Textbox.TabIndex = 240
        Me.ExpirationDate_Textbox.Tag = "dataEditingControl"
        Me.ExpirationDate_Textbox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.ExpirationDate_Textbox.ValidatingType = GetType(Date)
        Me.ExpirationDate_Textbox.Visible = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(714, 535)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(200, 22)
        Me.DateTimePicker1.TabIndex = 241
        '
        'ABS_Value
        '
        Me.ABS_Value.AutoSize = True
        Me.ABS_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ABS_Value.ForeColor = System.Drawing.Color.Black
        Me.ABS_Value.Location = New System.Drawing.Point(357, 580)
        Me.ABS_Value.Name = "ABS_Value"
        Me.ABS_Value.Size = New System.Drawing.Size(0, 20)
        Me.ABS_Value.TabIndex = 242
        Me.ABS_Value.Tag = "dataViewingControl"
        '
        'ABS_CheckBox
        '
        Me.ABS_CheckBox.AutoSize = True
        Me.ABS_CheckBox.Location = New System.Drawing.Point(357, 584)
        Me.ABS_CheckBox.Name = "ABS_CheckBox"
        Me.ABS_CheckBox.Size = New System.Drawing.Size(18, 17)
        Me.ABS_CheckBox.TabIndex = 244
        Me.ABS_CheckBox.Tag = "dataEditingControl"
        Me.ABS_CheckBox.UseVisualStyleBackColor = True
        '
        'ABSLabel
        '
        Me.ABSLabel.AutoSize = True
        Me.ABSLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ABSLabel.Location = New System.Drawing.Point(260, 583)
        Me.ABSLabel.Name = "ABSLabel"
        Me.ABSLabel.Size = New System.Drawing.Size(91, 17)
        Me.ABSLabel.TabIndex = 243
        Me.ABSLabel.Tag = "dataLabel"
        Me.ABSLabel.Text = "ABS Brakes :"
        '
        'AirBags_Value
        '
        Me.AirBags_Value.AutoSize = True
        Me.AirBags_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AirBags_Value.ForeColor = System.Drawing.Color.Black
        Me.AirBags_Value.Location = New System.Drawing.Point(485, 580)
        Me.AirBags_Value.Name = "AirBags_Value"
        Me.AirBags_Value.Size = New System.Drawing.Size(0, 20)
        Me.AirBags_Value.TabIndex = 245
        Me.AirBags_Value.Tag = "dataViewingControl"
        '
        'AirBags_CheckBox
        '
        Me.AirBags_CheckBox.AutoSize = True
        Me.AirBags_CheckBox.Location = New System.Drawing.Point(485, 584)
        Me.AirBags_CheckBox.Name = "AirBags_CheckBox"
        Me.AirBags_CheckBox.Size = New System.Drawing.Size(18, 17)
        Me.AirBags_CheckBox.TabIndex = 247
        Me.AirBags_CheckBox.Tag = "dataEditingControl"
        Me.AirBags_CheckBox.UseVisualStyleBackColor = True
        '
        'AirbagsLabel
        '
        Me.AirbagsLabel.AutoSize = True
        Me.AirbagsLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.AirbagsLabel.Location = New System.Drawing.Point(414, 583)
        Me.AirbagsLabel.Name = "AirbagsLabel"
        Me.AirbagsLabel.Size = New System.Drawing.Size(65, 17)
        Me.AirbagsLabel.TabIndex = 246
        Me.AirbagsLabel.Tag = "dataLabel"
        Me.AirbagsLabel.Text = "AirBags :"
        '
        'AC_Value
        '
        Me.AC_Value.AutoSize = True
        Me.AC_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AC_Value.ForeColor = System.Drawing.Color.Black
        Me.AC_Value.Location = New System.Drawing.Point(586, 580)
        Me.AC_Value.Name = "AC_Value"
        Me.AC_Value.Size = New System.Drawing.Size(0, 20)
        Me.AC_Value.TabIndex = 248
        Me.AC_Value.Tag = "dataViewingControl"
        '
        'AC_CheckBox
        '
        Me.AC_CheckBox.AutoSize = True
        Me.AC_CheckBox.Location = New System.Drawing.Point(586, 584)
        Me.AC_CheckBox.Name = "AC_CheckBox"
        Me.AC_CheckBox.Size = New System.Drawing.Size(18, 17)
        Me.AC_CheckBox.TabIndex = 250
        Me.AC_CheckBox.Tag = "dataEditingControl"
        Me.AC_CheckBox.UseVisualStyleBackColor = True
        '
        'ACLabel
        '
        Me.ACLabel.AutoSize = True
        Me.ACLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ACLabel.Location = New System.Drawing.Point(542, 583)
        Me.ACLabel.Name = "ACLabel"
        Me.ACLabel.Size = New System.Drawing.Size(38, 17)
        Me.ACLabel.TabIndex = 249
        Me.ACLabel.Tag = "dataLabel"
        Me.ACLabel.Text = "A/C :"
        '
        'Engine_Value
        '
        Me.Engine_Value.AutoSize = True
        Me.Engine_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Engine_Value.ForeColor = System.Drawing.Color.Black
        Me.Engine_Value.Location = New System.Drawing.Point(160, 625)
        Me.Engine_Value.Name = "Engine_Value"
        Me.Engine_Value.Size = New System.Drawing.Size(0, 20)
        Me.Engine_Value.TabIndex = 253
        Me.Engine_Value.Tag = "dataViewingControl"
        '
        'EngineLabel
        '
        Me.EngineLabel.AutoSize = True
        Me.EngineLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.EngineLabel.Location = New System.Drawing.Point(94, 628)
        Me.EngineLabel.Name = "EngineLabel"
        Me.EngineLabel.Size = New System.Drawing.Size(60, 17)
        Me.EngineLabel.TabIndex = 252
        Me.EngineLabel.Tag = "dataLabel"
        Me.EngineLabel.Text = "Engine :"
        '
        'Engine_Textbox
        '
        Me.Engine_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Engine_Textbox.Location = New System.Drawing.Point(160, 622)
        Me.Engine_Textbox.MaxLength = 20
        Me.Engine_Textbox.Name = "Engine_Textbox"
        Me.Engine_Textbox.Size = New System.Drawing.Size(163, 27)
        Me.Engine_Textbox.TabIndex = 251
        Me.Engine_Textbox.Tag = "dataEditingControl"
        Me.Engine_Textbox.Visible = False
        '
        'Notes_Value
        '
        Me.Notes_Value.AutoSize = True
        Me.Notes_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Notes_Value.ForeColor = System.Drawing.Color.Black
        Me.Notes_Value.Location = New System.Drawing.Point(153, 666)
        Me.Notes_Value.Name = "Notes_Value"
        Me.Notes_Value.Size = New System.Drawing.Size(0, 20)
        Me.Notes_Value.TabIndex = 256
        Me.Notes_Value.Tag = "dataViewingControl"
        '
        'NotesLabel
        '
        Me.NotesLabel.AutoSize = True
        Me.NotesLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.NotesLabel.Location = New System.Drawing.Point(94, 669)
        Me.NotesLabel.Name = "NotesLabel"
        Me.NotesLabel.Size = New System.Drawing.Size(53, 17)
        Me.NotesLabel.TabIndex = 255
        Me.NotesLabel.Tag = "dataLabel"
        Me.NotesLabel.Text = "Notes :"
        '
        'Notes_Textbox
        '
        Me.Notes_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Notes_Textbox.Location = New System.Drawing.Point(153, 663)
        Me.Notes_Textbox.MaxLength = 20
        Me.Notes_Textbox.Name = "Notes_Textbox"
        Me.Notes_Textbox.Size = New System.Drawing.Size(622, 27)
        Me.Notes_Textbox.TabIndex = 254
        Me.Notes_Textbox.Tag = "dataEditingControl"
        Me.Notes_Textbox.Visible = False
        '
        'vehicleMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(982, 753)
        Me.Controls.Add(Me.Notes_Value)
        Me.Controls.Add(Me.NotesLabel)
        Me.Controls.Add(Me.Notes_Textbox)
        Me.Controls.Add(Me.Engine_Value)
        Me.Controls.Add(Me.EngineLabel)
        Me.Controls.Add(Me.Engine_Textbox)
        Me.Controls.Add(Me.AC_Value)
        Me.Controls.Add(Me.AC_CheckBox)
        Me.Controls.Add(Me.ACLabel)
        Me.Controls.Add(Me.AirBags_Value)
        Me.Controls.Add(Me.AirBags_CheckBox)
        Me.Controls.Add(Me.AirbagsLabel)
        Me.Controls.Add(Me.ABS_Value)
        Me.Controls.Add(Me.ABS_CheckBox)
        Me.Controls.Add(Me.ABSLabel)
        Me.Controls.Add(Me.DateTimePicker1)
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
        Me.Controls.Add(Me.Alarm_Value)
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
    Friend WithEvents Alarm_Value As Label
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
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents ABS_Value As Label
    Friend WithEvents ABS_CheckBox As CheckBox
    Friend WithEvents ABSLabel As Label
    Friend WithEvents AirBags_Value As Label
    Friend WithEvents AirBags_CheckBox As CheckBox
    Friend WithEvents AirbagsLabel As Label
    Friend WithEvents AC_Value As Label
    Friend WithEvents AC_CheckBox As CheckBox
    Friend WithEvents ACLabel As Label
    Friend WithEvents Engine_Value As Label
    Friend WithEvents EngineLabel As Label
    Friend WithEvents Engine_Textbox As TextBox
    Friend WithEvents Notes_Value As Label
    Friend WithEvents NotesLabel As Label
    Friend WithEvents Notes_Textbox As TextBox
End Class
