<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class invoices
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
        Me.deleteInvButton = New System.Windows.Forms.Button()
        Me.invoiceMaintenanceLabel = New System.Windows.Forms.Label()
        Me.modifyInvButton = New System.Windows.Forms.Button()
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.newInvButton = New System.Windows.Forms.Button()
        Me.invoiceNumLabel = New System.Windows.Forms.Label()
        Me.InvoiceNumComboBox = New System.Windows.Forms.ComboBox()
        Me.CustomerComboLabel = New System.Windows.Forms.Label()
        Me.CustomerComboBox = New System.Windows.Forms.ComboBox()
        Me.InvDate_Textbox = New System.Windows.Forms.MaskedTextBox()
        Me.InvDate_Value = New System.Windows.Forms.Label()
        Me.InvoiceDateLabel = New System.Windows.Forms.Label()
        Me.InvNbr_Value = New System.Windows.Forms.Label()
        Me.InvoiceNumberLabel = New System.Windows.Forms.Label()
        Me.InvNbr_Textbox = New System.Windows.Forms.TextBox()
        Me.Complete_Value = New System.Windows.Forms.Label()
        Me.Complete_CheckBox = New System.Windows.Forms.CheckBox()
        Me.CompleteLabel = New System.Windows.Forms.Label()
        Me.ContactName_Value = New System.Windows.Forms.Label()
        Me.ContactLabel = New System.Windows.Forms.Label()
        Me.ContactName_Textbox = New System.Windows.Forms.TextBox()
        Me.Phone1Label = New System.Windows.Forms.Label()
        Me.ContactPhone1_ComboBox = New System.Windows.Forms.ComboBox()
        Me.ContactPhone1_Value = New System.Windows.Forms.Label()
        Me.ContactPhone2_Value = New System.Windows.Forms.Label()
        Me.Phone2Label = New System.Windows.Forms.Label()
        Me.ContactPhone2_ComboBox = New System.Windows.Forms.ComboBox()
        Me.VehicleLabel = New System.Windows.Forms.Label()
        Me.VehicleComboBox = New System.Windows.Forms.ComboBox()
        Me.Mileage_Value = New System.Windows.Forms.Label()
        Me.MileageLabel = New System.Windows.Forms.Label()
        Me.Mileage_Textbox = New System.Windows.Forms.TextBox()
        Me.vehicleHistoryButton = New System.Windows.Forms.Button()
        Me.ApptDate_Textbox = New System.Windows.Forms.MaskedTextBox()
        Me.ApptDate_Value = New System.Windows.Forms.Label()
        Me.AppointmentDate_Label = New System.Windows.Forms.Label()
        Me.WorkDate_Textbox = New System.Windows.Forms.MaskedTextBox()
        Me.WorkDate_Value = New System.Windows.Forms.Label()
        Me.WorkDateLabel = New System.Windows.Forms.Label()
        Me.NbrTasks_Value = New System.Windows.Forms.Label()
        Me.NbrTasksLabel = New System.Windows.Forms.Label()
        Me.InspectionSticker_Value = New System.Windows.Forms.Label()
        Me.InspectionStickerLabel = New System.Windows.Forms.Label()
        Me.InspectionSticker_Textbox = New System.Windows.Forms.TextBox()
        Me.InspectionMonth_ComboBox = New System.Windows.Forms.ComboBox()
        Me.InspectionMonth_Value = New System.Windows.Forms.Label()
        Me.InspectionMonthLabel = New System.Windows.Forms.Label()
        Me.licensePlateSearchButton = New System.Windows.Forms.Button()
        Me.tasksButton = New System.Windows.Forms.Button()
        Me.paymentsButton = New System.Windows.Forms.Button()
        Me.PayDate_Value = New System.Windows.Forms.Label()
        Me.PayDateLabel = New System.Windows.Forms.Label()
        Me.TotalPaid_Value = New System.Windows.Forms.Label()
        Me.TotalPaidLabel = New System.Windows.Forms.Label()
        Me.NbrTasks_Textbox = New System.Windows.Forms.TextBox()
        Me.PayDate_Textbox = New System.Windows.Forms.MaskedTextBox()
        Me.TotalPaid_Textbox = New System.Windows.Forms.TextBox()
        Me.BalanceTextbox = New System.Windows.Forms.TextBox()
        Me.BalanceValue = New System.Windows.Forms.Label()
        Me.BalanceLabel = New System.Windows.Forms.Label()
        Me.Notes_Value = New System.Windows.Forms.Label()
        Me.NotesLabel = New System.Windows.Forms.Label()
        Me.Notes_Textbox = New System.Windows.Forms.TextBox()
        Me.ShopSupplies_Value = New System.Windows.Forms.Label()
        Me.ShopSupplies_CheckBox = New System.Windows.Forms.CheckBox()
        Me.ShopSuppliesLabel = New System.Windows.Forms.Label()
        Me.TaxExempt_Value = New System.Windows.Forms.Label()
        Me.TaxExempt_CheckBox = New System.Windows.Forms.CheckBox()
        Me.TaxExemptLabel = New System.Windows.Forms.Label()
        Me.printInvButton = New System.Windows.Forms.Button()
        Me.CostTableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.TotalPanel = New System.Windows.Forms.Panel()
        Me.InvTotal_Textbox = New System.Windows.Forms.TextBox()
        Me.InvTotal_Value = New System.Windows.Forms.Label()
        Me.TaxPanel = New System.Windows.Forms.Panel()
        Me.Tax_Textbox = New System.Windows.Forms.TextBox()
        Me.Tax_Value = New System.Windows.Forms.Label()
        Me.SubTotalPanel = New System.Windows.Forms.Panel()
        Me.SubTotalTextbox = New System.Windows.Forms.TextBox()
        Me.SubTotalValue = New System.Windows.Forms.Label()
        Me.PartsPanel = New System.Windows.Forms.Panel()
        Me.TotalParts_Textbox = New System.Windows.Forms.TextBox()
        Me.TotalParts_Value = New System.Windows.Forms.Label()
        Me.LaborPanel = New System.Windows.Forms.Panel()
        Me.TotalLabor_Textbox = New System.Windows.Forms.TextBox()
        Me.TotalLabor_Value = New System.Windows.Forms.Label()
        Me.ShopChargesPanel = New System.Windows.Forms.Panel()
        Me.ShopCharges_Textbox = New System.Windows.Forms.TextBox()
        Me.ShopCharges_Value = New System.Windows.Forms.Label()
        Me.TowingPanel = New System.Windows.Forms.Panel()
        Me.Towing_Textbox = New System.Windows.Forms.TextBox()
        Me.Towing_Value = New System.Windows.Forms.Label()
        Me.GasPanel = New System.Windows.Forms.Panel()
        Me.Gas_Textbox = New System.Windows.Forms.TextBox()
        Me.Gas_Value = New System.Windows.Forms.Label()
        Me.TotalLabel = New System.Windows.Forms.Label()
        Me.TowingLabel = New System.Windows.Forms.Label()
        Me.GasLabel = New System.Windows.Forms.Label()
        Me.TaxLabel = New System.Windows.Forms.Label()
        Me.SubTotalLabel = New System.Windows.Forms.Label()
        Me.PartsLabel = New System.Windows.Forms.Label()
        Me.LaborLabel = New System.Windows.Forms.Label()
        Me.ShopChargesLabel = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.LicenseStateComboBox = New System.Windows.Forms.ComboBox()
        Me.LicenseState_Value = New System.Windows.Forms.Label()
        Me.LicenseStateLabel = New System.Windows.Forms.Label()
        Me.LicensePlateLabel = New System.Windows.Forms.Label()
        Me.LicensePlateTextbox = New System.Windows.Forms.TextBox()
        Me.nav = New AutoServiceManager.navigation()
        Me.CostTableLayoutPanel.SuspendLayout()
        Me.TotalPanel.SuspendLayout()
        Me.TaxPanel.SuspendLayout()
        Me.SubTotalPanel.SuspendLayout()
        Me.PartsPanel.SuspendLayout()
        Me.LaborPanel.SuspendLayout()
        Me.ShopChargesPanel.SuspendLayout()
        Me.TowingPanel.SuspendLayout()
        Me.GasPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'deleteInvButton
        '
        Me.deleteInvButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.deleteInvButton.Enabled = False
        Me.deleteInvButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.deleteInvButton.ForeColor = System.Drawing.Color.White
        Me.deleteInvButton.Location = New System.Drawing.Point(376, 120)
        Me.deleteInvButton.Name = "deleteInvButton"
        Me.deleteInvButton.Size = New System.Drawing.Size(132, 30)
        Me.deleteInvButton.TabIndex = 20
        Me.deleteInvButton.Text = "Delete Invoice"
        Me.deleteInvButton.UseVisualStyleBackColor = False
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
        'modifyInvButton
        '
        Me.modifyInvButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.modifyInvButton.Enabled = False
        Me.modifyInvButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.modifyInvButton.ForeColor = System.Drawing.Color.White
        Me.modifyInvButton.Location = New System.Drawing.Point(238, 120)
        Me.modifyInvButton.Name = "modifyInvButton"
        Me.modifyInvButton.Size = New System.Drawing.Size(132, 30)
        Me.modifyInvButton.TabIndex = 19
        Me.modifyInvButton.Text = "Modify Invoice"
        Me.modifyInvButton.UseVisualStyleBackColor = False
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
        Me.cancelButton.TabIndex = 22
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
        Me.saveButton.TabIndex = 21
        Me.saveButton.Text = "Save"
        Me.saveButton.UseVisualStyleBackColor = False
        '
        'newInvButton
        '
        Me.newInvButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.newInvButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.newInvButton.ForeColor = System.Drawing.Color.White
        Me.newInvButton.Location = New System.Drawing.Point(100, 120)
        Me.newInvButton.Name = "newInvButton"
        Me.newInvButton.Size = New System.Drawing.Size(132, 30)
        Me.newInvButton.TabIndex = 18
        Me.newInvButton.Text = "New Invoice"
        Me.newInvButton.UseVisualStyleBackColor = False
        '
        'invoiceNumLabel
        '
        Me.invoiceNumLabel.AutoSize = True
        Me.invoiceNumLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.invoiceNumLabel.Location = New System.Drawing.Point(97, 285)
        Me.invoiceNumLabel.Name = "invoiceNumLabel"
        Me.invoiceNumLabel.Size = New System.Drawing.Size(72, 17)
        Me.invoiceNumLabel.TabIndex = 143
        Me.invoiceNumLabel.Text = "Invoice # :"
        '
        'InvoiceNumComboBox
        '
        Me.InvoiceNumComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.InvoiceNumComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.InvoiceNumComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.InvoiceNumComboBox.FormattingEnabled = True
        Me.InvoiceNumComboBox.Location = New System.Drawing.Point(175, 279)
        Me.InvoiceNumComboBox.Name = "InvoiceNumComboBox"
        Me.InvoiceNumComboBox.Size = New System.Drawing.Size(213, 28)
        Me.InvoiceNumComboBox.TabIndex = 2
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
        'InvDate_Textbox
        '
        Me.InvDate_Textbox.AllowPromptAsInput = False
        Me.InvDate_Textbox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.InvDate_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.InvDate_Textbox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert
        Me.InvDate_Textbox.Location = New System.Drawing.Point(461, 340)
        Me.InvDate_Textbox.Mask = "00/00/0000"
        Me.InvDate_Textbox.Name = "InvDate_Textbox"
        Me.InvDate_Textbox.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.InvDate_Textbox.Size = New System.Drawing.Size(181, 27)
        Me.InvDate_Textbox.TabIndex = 4
        Me.InvDate_Textbox.Tag = "dataEditingControl"
        Me.InvDate_Textbox.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.InvDate_Textbox.ValidatingType = GetType(Date)
        '
        'InvDate_Value
        '
        Me.InvDate_Value.AutoSize = True
        Me.InvDate_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InvDate_Value.ForeColor = System.Drawing.Color.Black
        Me.InvDate_Value.Location = New System.Drawing.Point(460, 343)
        Me.InvDate_Value.Name = "InvDate_Value"
        Me.InvDate_Value.Size = New System.Drawing.Size(0, 20)
        Me.InvDate_Value.TabIndex = 242
        Me.InvDate_Value.Tag = "dataViewingControl"
        '
        'InvoiceDateLabel
        '
        Me.InvoiceDateLabel.AutoSize = True
        Me.InvoiceDateLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.InvoiceDateLabel.Location = New System.Drawing.Point(361, 346)
        Me.InvoiceDateLabel.Name = "InvoiceDateLabel"
        Me.InvoiceDateLabel.Size = New System.Drawing.Size(94, 17)
        Me.InvoiceDateLabel.TabIndex = 241
        Me.InvoiceDateLabel.Tag = "dataLabel"
        Me.InvoiceDateLabel.Text = "Invoice Date :"
        '
        'InvNbr_Value
        '
        Me.InvNbr_Value.AutoSize = True
        Me.InvNbr_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InvNbr_Value.ForeColor = System.Drawing.Color.Black
        Me.InvNbr_Value.Location = New System.Drawing.Point(217, 343)
        Me.InvNbr_Value.Name = "InvNbr_Value"
        Me.InvNbr_Value.Size = New System.Drawing.Size(0, 20)
        Me.InvNbr_Value.TabIndex = 247
        Me.InvNbr_Value.Tag = "dataViewingControl"
        '
        'InvoiceNumberLabel
        '
        Me.InvoiceNumberLabel.AutoSize = True
        Me.InvoiceNumberLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.InvoiceNumberLabel.Location = New System.Drawing.Point(97, 346)
        Me.InvoiceNumberLabel.Name = "InvoiceNumberLabel"
        Me.InvoiceNumberLabel.Size = New System.Drawing.Size(114, 17)
        Me.InvoiceNumberLabel.TabIndex = 246
        Me.InvoiceNumberLabel.Tag = "dataLabel"
        Me.InvoiceNumberLabel.Text = "Invoice Number :"
        '
        'InvNbr_Textbox
        '
        Me.InvNbr_Textbox.Enabled = False
        Me.InvNbr_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InvNbr_Textbox.Location = New System.Drawing.Point(217, 340)
        Me.InvNbr_Textbox.MaxLength = 10
        Me.InvNbr_Textbox.Name = "InvNbr_Textbox"
        Me.InvNbr_Textbox.Size = New System.Drawing.Size(126, 27)
        Me.InvNbr_Textbox.TabIndex = 3
        Me.InvNbr_Textbox.Tag = "dataEditingControl"
        '
        'Complete_Value
        '
        Me.Complete_Value.AutoSize = True
        Me.Complete_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Complete_Value.ForeColor = System.Drawing.Color.Black
        Me.Complete_Value.Location = New System.Drawing.Point(741, 343)
        Me.Complete_Value.Name = "Complete_Value"
        Me.Complete_Value.Size = New System.Drawing.Size(0, 20)
        Me.Complete_Value.TabIndex = 5
        Me.Complete_Value.Tag = "dataViewingControl"
        '
        'Complete_CheckBox
        '
        Me.Complete_CheckBox.AutoSize = True
        Me.Complete_CheckBox.Location = New System.Drawing.Point(741, 347)
        Me.Complete_CheckBox.Name = "Complete_CheckBox"
        Me.Complete_CheckBox.Size = New System.Drawing.Size(18, 17)
        Me.Complete_CheckBox.TabIndex = 5
        Me.Complete_CheckBox.Tag = "dataEditingControl"
        Me.Complete_CheckBox.UseVisualStyleBackColor = True
        '
        'CompleteLabel
        '
        Me.CompleteLabel.AutoSize = True
        Me.CompleteLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.CompleteLabel.Location = New System.Drawing.Point(660, 346)
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
        Me.ContactName_Value.Location = New System.Drawing.Point(167, 388)
        Me.ContactName_Value.Name = "ContactName_Value"
        Me.ContactName_Value.Size = New System.Drawing.Size(0, 20)
        Me.ContactName_Value.TabIndex = 256
        Me.ContactName_Value.Tag = "dataViewingControl"
        '
        'ContactLabel
        '
        Me.ContactLabel.AutoSize = True
        Me.ContactLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ContactLabel.Location = New System.Drawing.Point(97, 391)
        Me.ContactLabel.Name = "ContactLabel"
        Me.ContactLabel.Size = New System.Drawing.Size(64, 17)
        Me.ContactLabel.TabIndex = 255
        Me.ContactLabel.Tag = "dataLabel"
        Me.ContactLabel.Text = "Contact :"
        '
        'ContactName_Textbox
        '
        Me.ContactName_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContactName_Textbox.Location = New System.Drawing.Point(167, 385)
        Me.ContactName_Textbox.MaxLength = 20
        Me.ContactName_Textbox.Name = "ContactName_Textbox"
        Me.ContactName_Textbox.Size = New System.Drawing.Size(315, 27)
        Me.ContactName_Textbox.TabIndex = 6
        Me.ContactName_Textbox.Tag = "dataEditingControl"
        '
        'Phone1Label
        '
        Me.Phone1Label.AutoSize = True
        Me.Phone1Label.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Phone1Label.Location = New System.Drawing.Point(501, 391)
        Me.Phone1Label.Name = "Phone1Label"
        Me.Phone1Label.Size = New System.Drawing.Size(69, 17)
        Me.Phone1Label.TabIndex = 260
        Me.Phone1Label.Tag = "dataLabel"
        Me.Phone1Label.Text = "Phone 1 :"
        '
        'ContactPhone1_ComboBox
        '
        Me.ContactPhone1_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ContactPhone1_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ContactPhone1_ComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.ContactPhone1_ComboBox.FormattingEnabled = True
        Me.ContactPhone1_ComboBox.Location = New System.Drawing.Point(576, 385)
        Me.ContactPhone1_ComboBox.Name = "ContactPhone1_ComboBox"
        Me.ContactPhone1_ComboBox.Size = New System.Drawing.Size(181, 28)
        Me.ContactPhone1_ComboBox.TabIndex = 7
        Me.ContactPhone1_ComboBox.Tag = "dataEditingControl"
        '
        'ContactPhone1_Value
        '
        Me.ContactPhone1_Value.AutoSize = True
        Me.ContactPhone1_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContactPhone1_Value.ForeColor = System.Drawing.Color.Black
        Me.ContactPhone1_Value.Location = New System.Drawing.Point(576, 388)
        Me.ContactPhone1_Value.Name = "ContactPhone1_Value"
        Me.ContactPhone1_Value.Size = New System.Drawing.Size(0, 20)
        Me.ContactPhone1_Value.TabIndex = 261
        Me.ContactPhone1_Value.Tag = "dataViewingControl"
        '
        'ContactPhone2_Value
        '
        Me.ContactPhone2_Value.AutoSize = True
        Me.ContactPhone2_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContactPhone2_Value.ForeColor = System.Drawing.Color.Black
        Me.ContactPhone2_Value.Location = New System.Drawing.Point(852, 388)
        Me.ContactPhone2_Value.Name = "ContactPhone2_Value"
        Me.ContactPhone2_Value.Size = New System.Drawing.Size(0, 20)
        Me.ContactPhone2_Value.TabIndex = 264
        Me.ContactPhone2_Value.Tag = "dataViewingControl"
        '
        'Phone2Label
        '
        Me.Phone2Label.AutoSize = True
        Me.Phone2Label.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Phone2Label.Location = New System.Drawing.Point(777, 391)
        Me.Phone2Label.Name = "Phone2Label"
        Me.Phone2Label.Size = New System.Drawing.Size(69, 17)
        Me.Phone2Label.TabIndex = 263
        Me.Phone2Label.Tag = "dataLabel"
        Me.Phone2Label.Text = "Phone 2 :"
        '
        'ContactPhone2_ComboBox
        '
        Me.ContactPhone2_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ContactPhone2_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ContactPhone2_ComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.ContactPhone2_ComboBox.FormattingEnabled = True
        Me.ContactPhone2_ComboBox.Location = New System.Drawing.Point(852, 385)
        Me.ContactPhone2_ComboBox.Name = "ContactPhone2_ComboBox"
        Me.ContactPhone2_ComboBox.Size = New System.Drawing.Size(181, 28)
        Me.ContactPhone2_ComboBox.TabIndex = 8
        Me.ContactPhone2_ComboBox.Tag = "dataEditingControl"
        '
        'VehicleLabel
        '
        Me.VehicleLabel.AutoSize = True
        Me.VehicleLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.VehicleLabel.Location = New System.Drawing.Point(97, 242)
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
        Me.VehicleComboBox.Location = New System.Drawing.Point(165, 236)
        Me.VehicleComboBox.Name = "VehicleComboBox"
        Me.VehicleComboBox.Size = New System.Drawing.Size(352, 28)
        Me.VehicleComboBox.TabIndex = 1
        '
        'Mileage_Value
        '
        Me.Mileage_Value.AutoSize = True
        Me.Mileage_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mileage_Value.ForeColor = System.Drawing.Color.Black
        Me.Mileage_Value.Location = New System.Drawing.Point(763, 433)
        Me.Mileage_Value.Name = "Mileage_Value"
        Me.Mileage_Value.Size = New System.Drawing.Size(0, 20)
        Me.Mileage_Value.TabIndex = 270
        Me.Mileage_Value.Tag = "dataViewingControl"
        '
        'MileageLabel
        '
        Me.MileageLabel.AutoSize = True
        Me.MileageLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.MileageLabel.Location = New System.Drawing.Point(692, 436)
        Me.MileageLabel.Name = "MileageLabel"
        Me.MileageLabel.Size = New System.Drawing.Size(65, 17)
        Me.MileageLabel.TabIndex = 269
        Me.MileageLabel.Tag = "dataLabel"
        Me.MileageLabel.Text = "Mileage :"
        '
        'Mileage_Textbox
        '
        Me.Mileage_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Mileage_Textbox.Location = New System.Drawing.Point(763, 430)
        Me.Mileage_Textbox.MaxLength = 14
        Me.Mileage_Textbox.Name = "Mileage_Textbox"
        Me.Mileage_Textbox.Size = New System.Drawing.Size(146, 27)
        Me.Mileage_Textbox.TabIndex = 11
        Me.Mileage_Textbox.Tag = "dataEditingControl"
        '
        'vehicleHistoryButton
        '
        Me.vehicleHistoryButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.vehicleHistoryButton.Enabled = False
        Me.vehicleHistoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.vehicleHistoryButton.ForeColor = System.Drawing.Color.White
        Me.vehicleHistoryButton.Location = New System.Drawing.Point(924, 429)
        Me.vehicleHistoryButton.Name = "vehicleHistoryButton"
        Me.vehicleHistoryButton.Size = New System.Drawing.Size(138, 30)
        Me.vehicleHistoryButton.TabIndex = 12
        Me.vehicleHistoryButton.Tag = "dataLabel"
        Me.vehicleHistoryButton.Text = "Vehicle History"
        Me.vehicleHistoryButton.UseVisualStyleBackColor = False
        '
        'ApptDate_Textbox
        '
        Me.ApptDate_Textbox.AllowPromptAsInput = False
        Me.ApptDate_Textbox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.ApptDate_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.ApptDate_Textbox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert
        Me.ApptDate_Textbox.Location = New System.Drawing.Point(232, 499)
        Me.ApptDate_Textbox.Mask = "00/00/0000"
        Me.ApptDate_Textbox.Name = "ApptDate_Textbox"
        Me.ApptDate_Textbox.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.ApptDate_Textbox.Size = New System.Drawing.Size(111, 27)
        Me.ApptDate_Textbox.TabIndex = 13
        Me.ApptDate_Textbox.Tag = "dataEditingControl"
        Me.ApptDate_Textbox.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.ApptDate_Textbox.ValidatingType = GetType(Date)
        '
        'ApptDate_Value
        '
        Me.ApptDate_Value.AutoSize = True
        Me.ApptDate_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ApptDate_Value.ForeColor = System.Drawing.Color.Black
        Me.ApptDate_Value.Location = New System.Drawing.Point(231, 502)
        Me.ApptDate_Value.Name = "ApptDate_Value"
        Me.ApptDate_Value.Size = New System.Drawing.Size(0, 20)
        Me.ApptDate_Value.TabIndex = 274
        Me.ApptDate_Value.Tag = "dataViewingControl"
        '
        'AppointmentDate_Label
        '
        Me.AppointmentDate_Label.AutoSize = True
        Me.AppointmentDate_Label.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.AppointmentDate_Label.Location = New System.Drawing.Point(97, 505)
        Me.AppointmentDate_Label.Name = "AppointmentDate_Label"
        Me.AppointmentDate_Label.Size = New System.Drawing.Size(129, 17)
        Me.AppointmentDate_Label.TabIndex = 273
        Me.AppointmentDate_Label.Tag = "dataLabel"
        Me.AppointmentDate_Label.Text = "Appointment Date :"
        '
        'WorkDate_Textbox
        '
        Me.WorkDate_Textbox.AllowPromptAsInput = False
        Me.WorkDate_Textbox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.WorkDate_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.WorkDate_Textbox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert
        Me.WorkDate_Textbox.Location = New System.Drawing.Point(450, 499)
        Me.WorkDate_Textbox.Mask = "00/00/0000"
        Me.WorkDate_Textbox.Name = "WorkDate_Textbox"
        Me.WorkDate_Textbox.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.WorkDate_Textbox.Size = New System.Drawing.Size(111, 27)
        Me.WorkDate_Textbox.TabIndex = 14
        Me.WorkDate_Textbox.Tag = "dataEditingControl"
        Me.WorkDate_Textbox.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.WorkDate_Textbox.ValidatingType = GetType(Date)
        '
        'WorkDate_Value
        '
        Me.WorkDate_Value.AutoSize = True
        Me.WorkDate_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WorkDate_Value.ForeColor = System.Drawing.Color.Black
        Me.WorkDate_Value.Location = New System.Drawing.Point(449, 502)
        Me.WorkDate_Value.Name = "WorkDate_Value"
        Me.WorkDate_Value.Size = New System.Drawing.Size(0, 20)
        Me.WorkDate_Value.TabIndex = 277
        Me.WorkDate_Value.Tag = "dataViewingControl"
        '
        'WorkDateLabel
        '
        Me.WorkDateLabel.AutoSize = True
        Me.WorkDateLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.WorkDateLabel.Location = New System.Drawing.Point(361, 505)
        Me.WorkDateLabel.Name = "WorkDateLabel"
        Me.WorkDateLabel.Size = New System.Drawing.Size(83, 17)
        Me.WorkDateLabel.TabIndex = 276
        Me.WorkDateLabel.Tag = "dataLabel"
        Me.WorkDateLabel.Text = "Work Date :"
        '
        'NbrTasks_Value
        '
        Me.NbrTasks_Value.AutoSize = True
        Me.NbrTasks_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NbrTasks_Value.ForeColor = System.Drawing.Color.Black
        Me.NbrTasks_Value.Location = New System.Drawing.Point(768, 539)
        Me.NbrTasks_Value.Name = "NbrTasks_Value"
        Me.NbrTasks_Value.Size = New System.Drawing.Size(0, 20)
        Me.NbrTasks_Value.TabIndex = 280
        Me.NbrTasks_Value.Tag = "dataViewingControl"
        '
        'NbrTasksLabel
        '
        Me.NbrTasksLabel.AutoSize = True
        Me.NbrTasksLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.NbrTasksLabel.Location = New System.Drawing.Point(638, 542)
        Me.NbrTasksLabel.Name = "NbrTasksLabel"
        Me.NbrTasksLabel.Size = New System.Drawing.Size(124, 17)
        Me.NbrTasksLabel.TabIndex = 279
        Me.NbrTasksLabel.Tag = "dataLabel"
        Me.NbrTasksLabel.Text = "Number of Tasks :"
        '
        'InspectionSticker_Value
        '
        Me.InspectionSticker_Value.AutoSize = True
        Me.InspectionSticker_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InspectionSticker_Value.ForeColor = System.Drawing.Color.Black
        Me.InspectionSticker_Value.Location = New System.Drawing.Point(450, 433)
        Me.InspectionSticker_Value.Name = "InspectionSticker_Value"
        Me.InspectionSticker_Value.Size = New System.Drawing.Size(0, 20)
        Me.InspectionSticker_Value.TabIndex = 283
        Me.InspectionSticker_Value.Tag = "dataViewingControl"
        '
        'InspectionStickerLabel
        '
        Me.InspectionStickerLabel.AutoSize = True
        Me.InspectionStickerLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.InspectionStickerLabel.Location = New System.Drawing.Point(317, 436)
        Me.InspectionStickerLabel.Name = "InspectionStickerLabel"
        Me.InspectionStickerLabel.Size = New System.Drawing.Size(127, 17)
        Me.InspectionStickerLabel.TabIndex = 282
        Me.InspectionStickerLabel.Tag = "dataLabel"
        Me.InspectionStickerLabel.Text = "Inspection Sticker :"
        '
        'InspectionSticker_Textbox
        '
        Me.InspectionSticker_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InspectionSticker_Textbox.Location = New System.Drawing.Point(450, 430)
        Me.InspectionSticker_Textbox.MaxLength = 15
        Me.InspectionSticker_Textbox.Name = "InspectionSticker_Textbox"
        Me.InspectionSticker_Textbox.Size = New System.Drawing.Size(229, 27)
        Me.InspectionSticker_Textbox.TabIndex = 10
        Me.InspectionSticker_Textbox.Tag = "dataEditingControl"
        '
        'InspectionMonth_ComboBox
        '
        Me.InspectionMonth_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.InspectionMonth_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.InspectionMonth_ComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InspectionMonth_ComboBox.FormattingEnabled = True
        Me.InspectionMonth_ComboBox.Location = New System.Drawing.Point(226, 430)
        Me.InspectionMonth_ComboBox.MaxLength = 3
        Me.InspectionMonth_ComboBox.Name = "InspectionMonth_ComboBox"
        Me.InspectionMonth_ComboBox.Size = New System.Drawing.Size(73, 28)
        Me.InspectionMonth_ComboBox.TabIndex = 9
        Me.InspectionMonth_ComboBox.Tag = "dataEditingControl"
        '
        'InspectionMonth_Value
        '
        Me.InspectionMonth_Value.AutoSize = True
        Me.InspectionMonth_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InspectionMonth_Value.ForeColor = System.Drawing.Color.Black
        Me.InspectionMonth_Value.Location = New System.Drawing.Point(226, 433)
        Me.InspectionMonth_Value.Name = "InspectionMonth_Value"
        Me.InspectionMonth_Value.Size = New System.Drawing.Size(0, 20)
        Me.InspectionMonth_Value.TabIndex = 286
        Me.InspectionMonth_Value.Tag = "dataViewingControl"
        '
        'InspectionMonthLabel
        '
        Me.InspectionMonthLabel.AutoSize = True
        Me.InspectionMonthLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.InspectionMonthLabel.Location = New System.Drawing.Point(97, 436)
        Me.InspectionMonthLabel.Name = "InspectionMonthLabel"
        Me.InspectionMonthLabel.Size = New System.Drawing.Size(123, 17)
        Me.InspectionMonthLabel.TabIndex = 285
        Me.InspectionMonthLabel.Tag = "dataLabel"
        Me.InspectionMonthLabel.Text = "Inspection Month :"
        '
        'licensePlateSearchButton
        '
        Me.licensePlateSearchButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.licensePlateSearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.licensePlateSearchButton.ForeColor = System.Drawing.Color.White
        Me.licensePlateSearchButton.Location = New System.Drawing.Point(780, 193)
        Me.licensePlateSearchButton.Name = "licensePlateSearchButton"
        Me.licensePlateSearchButton.Size = New System.Drawing.Size(282, 30)
        Me.licensePlateSearchButton.TabIndex = 289
        Me.licensePlateSearchButton.Tag = "licensePlateSearchControl"
        Me.licensePlateSearchButton.Text = "License Plate Search"
        Me.licensePlateSearchButton.UseVisualStyleBackColor = False
        '
        'tasksButton
        '
        Me.tasksButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.tasksButton.Enabled = False
        Me.tasksButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.tasksButton.ForeColor = System.Drawing.Color.White
        Me.tasksButton.Location = New System.Drawing.Point(637, 498)
        Me.tasksButton.Name = "tasksButton"
        Me.tasksButton.Size = New System.Drawing.Size(189, 30)
        Me.tasksButton.TabIndex = 15
        Me.tasksButton.Tag = "dataLabel"
        Me.tasksButton.Text = "Tasks"
        Me.tasksButton.UseVisualStyleBackColor = False
        '
        'paymentsButton
        '
        Me.paymentsButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.paymentsButton.Enabled = False
        Me.paymentsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.paymentsButton.ForeColor = System.Drawing.Color.White
        Me.paymentsButton.Location = New System.Drawing.Point(873, 498)
        Me.paymentsButton.Name = "paymentsButton"
        Me.paymentsButton.Size = New System.Drawing.Size(189, 30)
        Me.paymentsButton.TabIndex = 16
        Me.paymentsButton.Tag = "dataLabel"
        Me.paymentsButton.Text = "Payments"
        Me.paymentsButton.UseVisualStyleBackColor = False
        '
        'PayDate_Value
        '
        Me.PayDate_Value.AutoSize = True
        Me.PayDate_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PayDate_Value.ForeColor = System.Drawing.Color.Black
        Me.PayDate_Value.Location = New System.Drawing.Point(950, 539)
        Me.PayDate_Value.Name = "PayDate_Value"
        Me.PayDate_Value.Size = New System.Drawing.Size(0, 20)
        Me.PayDate_Value.TabIndex = 293
        Me.PayDate_Value.Tag = "dataViewingControl"
        '
        'PayDateLabel
        '
        Me.PayDateLabel.AutoSize = True
        Me.PayDateLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.PayDateLabel.Location = New System.Drawing.Point(870, 542)
        Me.PayDateLabel.Name = "PayDateLabel"
        Me.PayDateLabel.Size = New System.Drawing.Size(74, 17)
        Me.PayDateLabel.TabIndex = 292
        Me.PayDateLabel.Tag = "dataLabel"
        Me.PayDateLabel.Text = "Pay Date :"
        '
        'TotalPaid_Value
        '
        Me.TotalPaid_Value.AutoSize = True
        Me.TotalPaid_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalPaid_Value.ForeColor = System.Drawing.Color.Black
        Me.TotalPaid_Value.Location = New System.Drawing.Point(950, 574)
        Me.TotalPaid_Value.Name = "TotalPaid_Value"
        Me.TotalPaid_Value.Size = New System.Drawing.Size(0, 20)
        Me.TotalPaid_Value.TabIndex = 295
        Me.TotalPaid_Value.Tag = "dataViewingControl"
        '
        'TotalPaidLabel
        '
        Me.TotalPaidLabel.AutoSize = True
        Me.TotalPaidLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TotalPaidLabel.Location = New System.Drawing.Point(870, 577)
        Me.TotalPaidLabel.Name = "TotalPaidLabel"
        Me.TotalPaidLabel.Size = New System.Drawing.Size(80, 17)
        Me.TotalPaidLabel.TabIndex = 294
        Me.TotalPaidLabel.Tag = "dataLabel"
        Me.TotalPaidLabel.Text = "Total Paid :"
        '
        'NbrTasks_Textbox
        '
        Me.NbrTasks_Textbox.Enabled = False
        Me.NbrTasks_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NbrTasks_Textbox.Location = New System.Drawing.Point(768, 536)
        Me.NbrTasks_Textbox.MaxLength = 14
        Me.NbrTasks_Textbox.Name = "NbrTasks_Textbox"
        Me.NbrTasks_Textbox.Size = New System.Drawing.Size(58, 27)
        Me.NbrTasks_Textbox.TabIndex = 296
        Me.NbrTasks_Textbox.Tag = "dataEditingControl"
        '
        'PayDate_Textbox
        '
        Me.PayDate_Textbox.AllowPromptAsInput = False
        Me.PayDate_Textbox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.PayDate_Textbox.Enabled = False
        Me.PayDate_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.PayDate_Textbox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert
        Me.PayDate_Textbox.Location = New System.Drawing.Point(950, 536)
        Me.PayDate_Textbox.Mask = "00/00/0000"
        Me.PayDate_Textbox.Name = "PayDate_Textbox"
        Me.PayDate_Textbox.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.PayDate_Textbox.Size = New System.Drawing.Size(112, 27)
        Me.PayDate_Textbox.TabIndex = 297
        Me.PayDate_Textbox.Tag = "dataEditingControl"
        Me.PayDate_Textbox.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.PayDate_Textbox.ValidatingType = GetType(Date)
        '
        'TotalPaid_Textbox
        '
        Me.TotalPaid_Textbox.Enabled = False
        Me.TotalPaid_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalPaid_Textbox.Location = New System.Drawing.Point(956, 571)
        Me.TotalPaid_Textbox.MaxLength = 14
        Me.TotalPaid_Textbox.Name = "TotalPaid_Textbox"
        Me.TotalPaid_Textbox.Size = New System.Drawing.Size(106, 27)
        Me.TotalPaid_Textbox.TabIndex = 298
        Me.TotalPaid_Textbox.Tag = "dataEditingControl"
        '
        'BalanceTextbox
        '
        Me.BalanceTextbox.Enabled = False
        Me.BalanceTextbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BalanceTextbox.Location = New System.Drawing.Point(943, 606)
        Me.BalanceTextbox.MaxLength = 14
        Me.BalanceTextbox.Name = "BalanceTextbox"
        Me.BalanceTextbox.Size = New System.Drawing.Size(119, 27)
        Me.BalanceTextbox.TabIndex = 301
        Me.BalanceTextbox.Tag = "dataEditingControl"
        '
        'BalanceValue
        '
        Me.BalanceValue.AutoSize = True
        Me.BalanceValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BalanceValue.ForeColor = System.Drawing.Color.Black
        Me.BalanceValue.Location = New System.Drawing.Point(943, 609)
        Me.BalanceValue.Name = "BalanceValue"
        Me.BalanceValue.Size = New System.Drawing.Size(0, 20)
        Me.BalanceValue.TabIndex = 300
        Me.BalanceValue.Tag = "dataViewingControl"
        '
        'BalanceLabel
        '
        Me.BalanceLabel.AutoSize = True
        Me.BalanceLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BalanceLabel.Location = New System.Drawing.Point(870, 612)
        Me.BalanceLabel.Name = "BalanceLabel"
        Me.BalanceLabel.Size = New System.Drawing.Size(67, 17)
        Me.BalanceLabel.TabIndex = 299
        Me.BalanceLabel.Tag = "dataLabel"
        Me.BalanceLabel.Text = "Balance :"
        '
        'Notes_Value
        '
        Me.Notes_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Notes_Value.ForeColor = System.Drawing.Color.Black
        Me.Notes_Value.Location = New System.Drawing.Point(697, 658)
        Me.Notes_Value.Name = "Notes_Value"
        Me.Notes_Value.Size = New System.Drawing.Size(365, 165)
        Me.Notes_Value.TabIndex = 304
        Me.Notes_Value.Tag = "dataViewingControl"
        '
        'NotesLabel
        '
        Me.NotesLabel.AutoSize = True
        Me.NotesLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.NotesLabel.Location = New System.Drawing.Point(638, 661)
        Me.NotesLabel.Name = "NotesLabel"
        Me.NotesLabel.Size = New System.Drawing.Size(53, 17)
        Me.NotesLabel.TabIndex = 303
        Me.NotesLabel.Tag = "dataLabel"
        Me.NotesLabel.Text = "Notes :"
        '
        'Notes_Textbox
        '
        Me.Notes_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Notes_Textbox.Location = New System.Drawing.Point(697, 658)
        Me.Notes_Textbox.MaxLength = 255
        Me.Notes_Textbox.Multiline = True
        Me.Notes_Textbox.Name = "Notes_Textbox"
        Me.Notes_Textbox.Size = New System.Drawing.Size(365, 165)
        Me.Notes_Textbox.TabIndex = 302
        Me.Notes_Textbox.Tag = "dataEditingControl"
        '
        'ShopSupplies_Value
        '
        Me.ShopSupplies_Value.AutoSize = True
        Me.ShopSupplies_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShopSupplies_Value.ForeColor = System.Drawing.Color.Black
        Me.ShopSupplies_Value.Location = New System.Drawing.Point(514, 651)
        Me.ShopSupplies_Value.Name = "ShopSupplies_Value"
        Me.ShopSupplies_Value.Size = New System.Drawing.Size(0, 20)
        Me.ShopSupplies_Value.TabIndex = 17
        Me.ShopSupplies_Value.Tag = "dataViewingControl"
        '
        'ShopSupplies_CheckBox
        '
        Me.ShopSupplies_CheckBox.AutoSize = True
        Me.ShopSupplies_CheckBox.Location = New System.Drawing.Point(514, 655)
        Me.ShopSupplies_CheckBox.Name = "ShopSupplies_CheckBox"
        Me.ShopSupplies_CheckBox.Size = New System.Drawing.Size(18, 17)
        Me.ShopSupplies_CheckBox.TabIndex = 307
        Me.ShopSupplies_CheckBox.Tag = "dataEditingControl"
        Me.ShopSupplies_CheckBox.UseVisualStyleBackColor = True
        '
        'ShopSuppliesLabel
        '
        Me.ShopSuppliesLabel.AutoSize = True
        Me.ShopSuppliesLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ShopSuppliesLabel.Location = New System.Drawing.Point(401, 654)
        Me.ShopSuppliesLabel.Name = "ShopSuppliesLabel"
        Me.ShopSuppliesLabel.Size = New System.Drawing.Size(107, 17)
        Me.ShopSuppliesLabel.TabIndex = 306
        Me.ShopSuppliesLabel.Tag = "dataLabel"
        Me.ShopSuppliesLabel.Text = "Shop Supplies :"
        '
        'TaxExempt_Value
        '
        Me.TaxExempt_Value.AutoSize = True
        Me.TaxExempt_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TaxExempt_Value.ForeColor = System.Drawing.Color.Black
        Me.TaxExempt_Value.Location = New System.Drawing.Point(496, 710)
        Me.TaxExempt_Value.Name = "TaxExempt_Value"
        Me.TaxExempt_Value.Size = New System.Drawing.Size(0, 20)
        Me.TaxExempt_Value.TabIndex = 18
        Me.TaxExempt_Value.Tag = "dataViewingControl"
        '
        'TaxExempt_CheckBox
        '
        Me.TaxExempt_CheckBox.AutoSize = True
        Me.TaxExempt_CheckBox.Enabled = False
        Me.TaxExempt_CheckBox.Location = New System.Drawing.Point(496, 714)
        Me.TaxExempt_CheckBox.Name = "TaxExempt_CheckBox"
        Me.TaxExempt_CheckBox.Size = New System.Drawing.Size(18, 17)
        Me.TaxExempt_CheckBox.TabIndex = 310
        Me.TaxExempt_CheckBox.Tag = "dataEditingControl"
        Me.TaxExempt_CheckBox.UseVisualStyleBackColor = True
        '
        'TaxExemptLabel
        '
        Me.TaxExemptLabel.AutoSize = True
        Me.TaxExemptLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TaxExemptLabel.Location = New System.Drawing.Point(401, 713)
        Me.TaxExemptLabel.Name = "TaxExemptLabel"
        Me.TaxExemptLabel.Size = New System.Drawing.Size(89, 17)
        Me.TaxExemptLabel.TabIndex = 309
        Me.TaxExemptLabel.Tag = "dataLabel"
        Me.TaxExemptLabel.Text = "Tax Exempt :"
        '
        'printInvButton
        '
        Me.printInvButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.printInvButton.Enabled = False
        Me.printInvButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.printInvButton.ForeColor = System.Drawing.Color.White
        Me.printInvButton.Location = New System.Drawing.Point(790, 120)
        Me.printInvButton.Name = "printInvButton"
        Me.printInvButton.Size = New System.Drawing.Size(132, 30)
        Me.printInvButton.TabIndex = 23
        Me.printInvButton.Text = "Print Invoice"
        Me.printInvButton.UseVisualStyleBackColor = False
        '
        'CostTableLayoutPanel
        '
        Me.CostTableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.CostTableLayoutPanel.ColumnCount = 2
        Me.CostTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.CostTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.CostTableLayoutPanel.Controls.Add(Me.TotalPanel, 1, 7)
        Me.CostTableLayoutPanel.Controls.Add(Me.TaxPanel, 1, 4)
        Me.CostTableLayoutPanel.Controls.Add(Me.SubTotalPanel, 1, 3)
        Me.CostTableLayoutPanel.Controls.Add(Me.PartsPanel, 1, 1)
        Me.CostTableLayoutPanel.Controls.Add(Me.LaborPanel, 1, 0)
        Me.CostTableLayoutPanel.Controls.Add(Me.ShopChargesPanel, 1, 2)
        Me.CostTableLayoutPanel.Controls.Add(Me.TowingPanel, 1, 6)
        Me.CostTableLayoutPanel.Controls.Add(Me.GasPanel, 1, 5)
        Me.CostTableLayoutPanel.Controls.Add(Me.TotalLabel, 0, 7)
        Me.CostTableLayoutPanel.Controls.Add(Me.TowingLabel, 0, 6)
        Me.CostTableLayoutPanel.Controls.Add(Me.GasLabel, 0, 5)
        Me.CostTableLayoutPanel.Controls.Add(Me.TaxLabel, 0, 4)
        Me.CostTableLayoutPanel.Controls.Add(Me.SubTotalLabel, 0, 3)
        Me.CostTableLayoutPanel.Controls.Add(Me.PartsLabel, 0, 1)
        Me.CostTableLayoutPanel.Controls.Add(Me.LaborLabel, 0, 0)
        Me.CostTableLayoutPanel.Controls.Add(Me.ShopChargesLabel, 0, 2)
        Me.CostTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize
        Me.CostTableLayoutPanel.Location = New System.Drawing.Point(100, 589)
        Me.CostTableLayoutPanel.Name = "CostTableLayoutPanel"
        Me.CostTableLayoutPanel.RowCount = 8
        Me.CostTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.CostTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.CostTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.CostTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.CostTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.CostTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.CostTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.CostTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5!))
        Me.CostTableLayoutPanel.Size = New System.Drawing.Size(288, 235)
        Me.CostTableLayoutPanel.TabIndex = 313
        Me.CostTableLayoutPanel.Tag = "dataLabel"
        '
        'TotalPanel
        '
        Me.TotalPanel.AutoSize = True
        Me.TotalPanel.Controls.Add(Me.InvTotal_Textbox)
        Me.TotalPanel.Controls.Add(Me.InvTotal_Value)
        Me.TotalPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TotalPanel.Location = New System.Drawing.Point(144, 204)
        Me.TotalPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.TotalPanel.Name = "TotalPanel"
        Me.TotalPanel.Size = New System.Drawing.Size(143, 30)
        Me.TotalPanel.TabIndex = 320
        '
        'InvTotal_Textbox
        '
        Me.InvTotal_Textbox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.InvTotal_Textbox.Enabled = False
        Me.InvTotal_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InvTotal_Textbox.Location = New System.Drawing.Point(0, 0)
        Me.InvTotal_Textbox.Margin = New System.Windows.Forms.Padding(0)
        Me.InvTotal_Textbox.Name = "InvTotal_Textbox"
        Me.InvTotal_Textbox.Size = New System.Drawing.Size(143, 27)
        Me.InvTotal_Textbox.TabIndex = 0
        Me.InvTotal_Textbox.Tag = "dataEditingControl"
        Me.InvTotal_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'InvTotal_Value
        '
        Me.InvTotal_Value.Dock = System.Windows.Forms.DockStyle.Fill
        Me.InvTotal_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InvTotal_Value.ForeColor = System.Drawing.Color.Black
        Me.InvTotal_Value.Location = New System.Drawing.Point(0, 0)
        Me.InvTotal_Value.Margin = New System.Windows.Forms.Padding(0)
        Me.InvTotal_Value.Name = "InvTotal_Value"
        Me.InvTotal_Value.Size = New System.Drawing.Size(143, 30)
        Me.InvTotal_Value.TabIndex = 318
        Me.InvTotal_Value.Tag = "dataViewingControl"
        Me.InvTotal_Value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TaxPanel
        '
        Me.TaxPanel.AutoSize = True
        Me.TaxPanel.Controls.Add(Me.Tax_Textbox)
        Me.TaxPanel.Controls.Add(Me.Tax_Value)
        Me.TaxPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TaxPanel.Location = New System.Drawing.Point(144, 117)
        Me.TaxPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.TaxPanel.Name = "TaxPanel"
        Me.TaxPanel.Size = New System.Drawing.Size(143, 28)
        Me.TaxPanel.TabIndex = 320
        '
        'Tax_Textbox
        '
        Me.Tax_Textbox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tax_Textbox.Enabled = False
        Me.Tax_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tax_Textbox.Location = New System.Drawing.Point(0, 0)
        Me.Tax_Textbox.Margin = New System.Windows.Forms.Padding(0)
        Me.Tax_Textbox.Name = "Tax_Textbox"
        Me.Tax_Textbox.Size = New System.Drawing.Size(143, 27)
        Me.Tax_Textbox.TabIndex = 0
        Me.Tax_Textbox.Tag = "dataEditingControl"
        Me.Tax_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Tax_Value
        '
        Me.Tax_Value.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tax_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tax_Value.ForeColor = System.Drawing.Color.Black
        Me.Tax_Value.Location = New System.Drawing.Point(0, 0)
        Me.Tax_Value.Margin = New System.Windows.Forms.Padding(0)
        Me.Tax_Value.Name = "Tax_Value"
        Me.Tax_Value.Size = New System.Drawing.Size(143, 28)
        Me.Tax_Value.TabIndex = 318
        Me.Tax_Value.Tag = "dataViewingControl"
        Me.Tax_Value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SubTotalPanel
        '
        Me.SubTotalPanel.AutoSize = True
        Me.SubTotalPanel.Controls.Add(Me.SubTotalTextbox)
        Me.SubTotalPanel.Controls.Add(Me.SubTotalValue)
        Me.SubTotalPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SubTotalPanel.Location = New System.Drawing.Point(144, 88)
        Me.SubTotalPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.SubTotalPanel.Name = "SubTotalPanel"
        Me.SubTotalPanel.Size = New System.Drawing.Size(143, 28)
        Me.SubTotalPanel.TabIndex = 320
        '
        'SubTotalTextbox
        '
        Me.SubTotalTextbox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SubTotalTextbox.Enabled = False
        Me.SubTotalTextbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SubTotalTextbox.Location = New System.Drawing.Point(0, 0)
        Me.SubTotalTextbox.Margin = New System.Windows.Forms.Padding(0)
        Me.SubTotalTextbox.Name = "SubTotalTextbox"
        Me.SubTotalTextbox.Size = New System.Drawing.Size(143, 27)
        Me.SubTotalTextbox.TabIndex = 0
        Me.SubTotalTextbox.Tag = "dataEditingControl"
        Me.SubTotalTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SubTotalValue
        '
        Me.SubTotalValue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SubTotalValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SubTotalValue.ForeColor = System.Drawing.Color.Black
        Me.SubTotalValue.Location = New System.Drawing.Point(0, 0)
        Me.SubTotalValue.Margin = New System.Windows.Forms.Padding(0)
        Me.SubTotalValue.Name = "SubTotalValue"
        Me.SubTotalValue.Size = New System.Drawing.Size(143, 28)
        Me.SubTotalValue.TabIndex = 318
        Me.SubTotalValue.Tag = "dataViewingControl"
        Me.SubTotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PartsPanel
        '
        Me.PartsPanel.AutoSize = True
        Me.PartsPanel.Controls.Add(Me.TotalParts_Textbox)
        Me.PartsPanel.Controls.Add(Me.TotalParts_Value)
        Me.PartsPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PartsPanel.Location = New System.Drawing.Point(144, 30)
        Me.PartsPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.PartsPanel.Name = "PartsPanel"
        Me.PartsPanel.Size = New System.Drawing.Size(143, 28)
        Me.PartsPanel.TabIndex = 320
        '
        'TotalParts_Textbox
        '
        Me.TotalParts_Textbox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TotalParts_Textbox.Enabled = False
        Me.TotalParts_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalParts_Textbox.Location = New System.Drawing.Point(0, 0)
        Me.TotalParts_Textbox.Margin = New System.Windows.Forms.Padding(0)
        Me.TotalParts_Textbox.Name = "TotalParts_Textbox"
        Me.TotalParts_Textbox.Size = New System.Drawing.Size(143, 27)
        Me.TotalParts_Textbox.TabIndex = 0
        Me.TotalParts_Textbox.Tag = "dataEditingControl"
        Me.TotalParts_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TotalParts_Value
        '
        Me.TotalParts_Value.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TotalParts_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalParts_Value.ForeColor = System.Drawing.Color.Black
        Me.TotalParts_Value.Location = New System.Drawing.Point(0, 0)
        Me.TotalParts_Value.Margin = New System.Windows.Forms.Padding(0)
        Me.TotalParts_Value.Name = "TotalParts_Value"
        Me.TotalParts_Value.Size = New System.Drawing.Size(143, 28)
        Me.TotalParts_Value.TabIndex = 318
        Me.TotalParts_Value.Tag = "dataViewingControl"
        Me.TotalParts_Value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LaborPanel
        '
        Me.LaborPanel.AutoSize = True
        Me.LaborPanel.Controls.Add(Me.TotalLabor_Textbox)
        Me.LaborPanel.Controls.Add(Me.TotalLabor_Value)
        Me.LaborPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LaborPanel.Location = New System.Drawing.Point(144, 1)
        Me.LaborPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.LaborPanel.Name = "LaborPanel"
        Me.LaborPanel.Size = New System.Drawing.Size(143, 28)
        Me.LaborPanel.TabIndex = 320
        '
        'TotalLabor_Textbox
        '
        Me.TotalLabor_Textbox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TotalLabor_Textbox.Enabled = False
        Me.TotalLabor_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalLabor_Textbox.Location = New System.Drawing.Point(0, 0)
        Me.TotalLabor_Textbox.Margin = New System.Windows.Forms.Padding(0)
        Me.TotalLabor_Textbox.Name = "TotalLabor_Textbox"
        Me.TotalLabor_Textbox.Size = New System.Drawing.Size(143, 27)
        Me.TotalLabor_Textbox.TabIndex = 0
        Me.TotalLabor_Textbox.Tag = "dataEditingControl"
        Me.TotalLabor_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TotalLabor_Value
        '
        Me.TotalLabor_Value.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TotalLabor_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalLabor_Value.ForeColor = System.Drawing.Color.Black
        Me.TotalLabor_Value.Location = New System.Drawing.Point(0, 0)
        Me.TotalLabor_Value.Margin = New System.Windows.Forms.Padding(0)
        Me.TotalLabor_Value.Name = "TotalLabor_Value"
        Me.TotalLabor_Value.Size = New System.Drawing.Size(143, 28)
        Me.TotalLabor_Value.TabIndex = 318
        Me.TotalLabor_Value.Tag = "dataViewingControl"
        Me.TotalLabor_Value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ShopChargesPanel
        '
        Me.ShopChargesPanel.AutoSize = True
        Me.ShopChargesPanel.Controls.Add(Me.ShopCharges_Textbox)
        Me.ShopChargesPanel.Controls.Add(Me.ShopCharges_Value)
        Me.ShopChargesPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ShopChargesPanel.Location = New System.Drawing.Point(144, 59)
        Me.ShopChargesPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.ShopChargesPanel.Name = "ShopChargesPanel"
        Me.ShopChargesPanel.Size = New System.Drawing.Size(143, 28)
        Me.ShopChargesPanel.TabIndex = 314
        '
        'ShopCharges_Textbox
        '
        Me.ShopCharges_Textbox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ShopCharges_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShopCharges_Textbox.Location = New System.Drawing.Point(0, 0)
        Me.ShopCharges_Textbox.Margin = New System.Windows.Forms.Padding(0)
        Me.ShopCharges_Textbox.Name = "ShopCharges_Textbox"
        Me.ShopCharges_Textbox.Size = New System.Drawing.Size(143, 27)
        Me.ShopCharges_Textbox.TabIndex = 0
        Me.ShopCharges_Textbox.Tag = "dataEditingControl"
        Me.ShopCharges_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ShopCharges_Value
        '
        Me.ShopCharges_Value.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ShopCharges_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ShopCharges_Value.ForeColor = System.Drawing.Color.Black
        Me.ShopCharges_Value.Location = New System.Drawing.Point(0, 0)
        Me.ShopCharges_Value.Margin = New System.Windows.Forms.Padding(0)
        Me.ShopCharges_Value.Name = "ShopCharges_Value"
        Me.ShopCharges_Value.Size = New System.Drawing.Size(143, 28)
        Me.ShopCharges_Value.TabIndex = 318
        Me.ShopCharges_Value.Tag = "dataViewingControl"
        Me.ShopCharges_Value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TowingPanel
        '
        Me.TowingPanel.AutoSize = True
        Me.TowingPanel.Controls.Add(Me.Towing_Textbox)
        Me.TowingPanel.Controls.Add(Me.Towing_Value)
        Me.TowingPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TowingPanel.Location = New System.Drawing.Point(144, 175)
        Me.TowingPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.TowingPanel.Name = "TowingPanel"
        Me.TowingPanel.Size = New System.Drawing.Size(143, 28)
        Me.TowingPanel.TabIndex = 321
        '
        'Towing_Textbox
        '
        Me.Towing_Textbox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Towing_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Towing_Textbox.Location = New System.Drawing.Point(0, 0)
        Me.Towing_Textbox.Margin = New System.Windows.Forms.Padding(0)
        Me.Towing_Textbox.Name = "Towing_Textbox"
        Me.Towing_Textbox.Size = New System.Drawing.Size(143, 27)
        Me.Towing_Textbox.TabIndex = 0
        Me.Towing_Textbox.Tag = "dataEditingControl"
        Me.Towing_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Towing_Value
        '
        Me.Towing_Value.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Towing_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Towing_Value.ForeColor = System.Drawing.Color.Black
        Me.Towing_Value.Location = New System.Drawing.Point(0, 0)
        Me.Towing_Value.Margin = New System.Windows.Forms.Padding(0)
        Me.Towing_Value.Name = "Towing_Value"
        Me.Towing_Value.Size = New System.Drawing.Size(143, 28)
        Me.Towing_Value.TabIndex = 318
        Me.Towing_Value.Tag = "dataViewingControl"
        Me.Towing_Value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GasPanel
        '
        Me.GasPanel.AutoSize = True
        Me.GasPanel.Controls.Add(Me.Gas_Textbox)
        Me.GasPanel.Controls.Add(Me.Gas_Value)
        Me.GasPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GasPanel.Location = New System.Drawing.Point(144, 146)
        Me.GasPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.GasPanel.Name = "GasPanel"
        Me.GasPanel.Size = New System.Drawing.Size(143, 28)
        Me.GasPanel.TabIndex = 320
        '
        'Gas_Textbox
        '
        Me.Gas_Textbox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Gas_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Gas_Textbox.Location = New System.Drawing.Point(0, 0)
        Me.Gas_Textbox.Margin = New System.Windows.Forms.Padding(0)
        Me.Gas_Textbox.Name = "Gas_Textbox"
        Me.Gas_Textbox.Size = New System.Drawing.Size(143, 27)
        Me.Gas_Textbox.TabIndex = 0
        Me.Gas_Textbox.Tag = "dataEditingControl"
        Me.Gas_Textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Gas_Value
        '
        Me.Gas_Value.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Gas_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Gas_Value.ForeColor = System.Drawing.Color.Black
        Me.Gas_Value.Location = New System.Drawing.Point(0, 0)
        Me.Gas_Value.Margin = New System.Windows.Forms.Padding(0)
        Me.Gas_Value.Name = "Gas_Value"
        Me.Gas_Value.Size = New System.Drawing.Size(143, 28)
        Me.Gas_Value.TabIndex = 318
        Me.Gas_Value.Tag = "dataViewingControl"
        Me.Gas_Value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TotalLabel
        '
        Me.TotalLabel.AutoSize = True
        Me.TotalLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TotalLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TotalLabel.Location = New System.Drawing.Point(4, 204)
        Me.TotalLabel.Name = "TotalLabel"
        Me.TotalLabel.Size = New System.Drawing.Size(136, 30)
        Me.TotalLabel.TabIndex = 322
        Me.TotalLabel.Tag = "dataLabel"
        Me.TotalLabel.Text = "Total"
        Me.TotalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TowingLabel
        '
        Me.TowingLabel.AutoSize = True
        Me.TowingLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TowingLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TowingLabel.Location = New System.Drawing.Point(4, 175)
        Me.TowingLabel.Name = "TowingLabel"
        Me.TowingLabel.Size = New System.Drawing.Size(136, 28)
        Me.TowingLabel.TabIndex = 321
        Me.TowingLabel.Tag = "dataLabel"
        Me.TowingLabel.Text = "Towing"
        Me.TowingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GasLabel
        '
        Me.GasLabel.AutoSize = True
        Me.GasLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GasLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.GasLabel.Location = New System.Drawing.Point(4, 146)
        Me.GasLabel.Name = "GasLabel"
        Me.GasLabel.Size = New System.Drawing.Size(136, 28)
        Me.GasLabel.TabIndex = 320
        Me.GasLabel.Tag = "dataLabel"
        Me.GasLabel.Text = "Gas"
        Me.GasLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TaxLabel
        '
        Me.TaxLabel.AutoSize = True
        Me.TaxLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TaxLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TaxLabel.Location = New System.Drawing.Point(4, 117)
        Me.TaxLabel.Name = "TaxLabel"
        Me.TaxLabel.Size = New System.Drawing.Size(136, 28)
        Me.TaxLabel.TabIndex = 319
        Me.TaxLabel.Tag = "dataLabel"
        Me.TaxLabel.Text = "Tax"
        Me.TaxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SubTotalLabel
        '
        Me.SubTotalLabel.AutoSize = True
        Me.SubTotalLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SubTotalLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.SubTotalLabel.Location = New System.Drawing.Point(4, 88)
        Me.SubTotalLabel.Name = "SubTotalLabel"
        Me.SubTotalLabel.Size = New System.Drawing.Size(136, 28)
        Me.SubTotalLabel.TabIndex = 318
        Me.SubTotalLabel.Tag = "dataLabel"
        Me.SubTotalLabel.Text = "SubTotal"
        Me.SubTotalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PartsLabel
        '
        Me.PartsLabel.AutoSize = True
        Me.PartsLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PartsLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.PartsLabel.Location = New System.Drawing.Point(4, 30)
        Me.PartsLabel.Name = "PartsLabel"
        Me.PartsLabel.Size = New System.Drawing.Size(136, 28)
        Me.PartsLabel.TabIndex = 316
        Me.PartsLabel.Tag = "dataLabel"
        Me.PartsLabel.Text = "Parts"
        Me.PartsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LaborLabel
        '
        Me.LaborLabel.AutoSize = True
        Me.LaborLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LaborLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.LaborLabel.Location = New System.Drawing.Point(4, 1)
        Me.LaborLabel.Name = "LaborLabel"
        Me.LaborLabel.Size = New System.Drawing.Size(136, 28)
        Me.LaborLabel.TabIndex = 315
        Me.LaborLabel.Tag = "dataLabel"
        Me.LaborLabel.Text = "Labor"
        Me.LaborLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ShopChargesLabel
        '
        Me.ShopChargesLabel.AutoSize = True
        Me.ShopChargesLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ShopChargesLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ShopChargesLabel.Location = New System.Drawing.Point(4, 59)
        Me.ShopChargesLabel.Name = "ShopChargesLabel"
        Me.ShopChargesLabel.Size = New System.Drawing.Size(136, 28)
        Me.ShopChargesLabel.TabIndex = 314
        Me.ShopChargesLabel.Tag = "dataLabel"
        Me.ShopChargesLabel.Text = "Shop Charges"
        Me.ShopChargesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(697, 655)
        Me.TextBox1.MaxLength = 255
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(365, 169)
        Me.TextBox1.TabIndex = 19
        Me.TextBox1.Tag = "dataEditingControl"
        '
        'LicenseStateComboBox
        '
        Me.LicenseStateComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.LicenseStateComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.LicenseStateComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LicenseStateComboBox.FormattingEnabled = True
        Me.LicenseStateComboBox.Location = New System.Drawing.Point(885, 236)
        Me.LicenseStateComboBox.MaxLength = 2
        Me.LicenseStateComboBox.Name = "LicenseStateComboBox"
        Me.LicenseStateComboBox.Size = New System.Drawing.Size(177, 28)
        Me.LicenseStateComboBox.TabIndex = 24
        Me.LicenseStateComboBox.Tag = "licensePlateSearchControl"
        '
        'LicenseState_Value
        '
        Me.LicenseState_Value.AutoSize = True
        Me.LicenseState_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LicenseState_Value.ForeColor = System.Drawing.Color.Black
        Me.LicenseState_Value.Location = New System.Drawing.Point(885, 239)
        Me.LicenseState_Value.Name = "LicenseState_Value"
        Me.LicenseState_Value.Size = New System.Drawing.Size(0, 20)
        Me.LicenseState_Value.TabIndex = 318
        Me.LicenseState_Value.Tag = "licensePlateSearchControl"
        '
        'LicenseStateLabel
        '
        Me.LicenseStateLabel.AutoSize = True
        Me.LicenseStateLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.LicenseStateLabel.Location = New System.Drawing.Point(777, 242)
        Me.LicenseStateLabel.Name = "LicenseStateLabel"
        Me.LicenseStateLabel.Size = New System.Drawing.Size(102, 17)
        Me.LicenseStateLabel.TabIndex = 317
        Me.LicenseStateLabel.Tag = ""
        Me.LicenseStateLabel.Text = "License State :"
        '
        'LicensePlateLabel
        '
        Me.LicensePlateLabel.AutoSize = True
        Me.LicensePlateLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.LicensePlateLabel.Location = New System.Drawing.Point(777, 285)
        Me.LicensePlateLabel.Name = "LicensePlateLabel"
        Me.LicensePlateLabel.Size = New System.Drawing.Size(101, 17)
        Me.LicensePlateLabel.TabIndex = 320
        Me.LicensePlateLabel.Tag = ""
        Me.LicensePlateLabel.Text = "License Plate :"
        '
        'LicensePlateTextbox
        '
        Me.LicensePlateTextbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LicensePlateTextbox.Location = New System.Drawing.Point(884, 279)
        Me.LicensePlateTextbox.MaxLength = 10
        Me.LicensePlateTextbox.Name = "LicensePlateTextbox"
        Me.LicensePlateTextbox.Size = New System.Drawing.Size(178, 27)
        Me.LicensePlateTextbox.TabIndex = 25
        Me.LicensePlateTextbox.Tag = "licensePlateSearchControl"
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
        'invoices
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1182, 903)
        Me.Controls.Add(Me.LicensePlateLabel)
        Me.Controls.Add(Me.LicensePlateTextbox)
        Me.Controls.Add(Me.LicenseStateComboBox)
        Me.Controls.Add(Me.LicenseState_Value)
        Me.Controls.Add(Me.LicenseStateLabel)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.CostTableLayoutPanel)
        Me.Controls.Add(Me.printInvButton)
        Me.Controls.Add(Me.TaxExempt_Value)
        Me.Controls.Add(Me.TaxExempt_CheckBox)
        Me.Controls.Add(Me.TaxExemptLabel)
        Me.Controls.Add(Me.ShopSupplies_Value)
        Me.Controls.Add(Me.ShopSupplies_CheckBox)
        Me.Controls.Add(Me.ShopSuppliesLabel)
        Me.Controls.Add(Me.Notes_Value)
        Me.Controls.Add(Me.NotesLabel)
        Me.Controls.Add(Me.Notes_Textbox)
        Me.Controls.Add(Me.BalanceTextbox)
        Me.Controls.Add(Me.BalanceValue)
        Me.Controls.Add(Me.BalanceLabel)
        Me.Controls.Add(Me.TotalPaid_Textbox)
        Me.Controls.Add(Me.PayDate_Textbox)
        Me.Controls.Add(Me.NbrTasks_Textbox)
        Me.Controls.Add(Me.TotalPaid_Value)
        Me.Controls.Add(Me.TotalPaidLabel)
        Me.Controls.Add(Me.PayDate_Value)
        Me.Controls.Add(Me.PayDateLabel)
        Me.Controls.Add(Me.paymentsButton)
        Me.Controls.Add(Me.tasksButton)
        Me.Controls.Add(Me.licensePlateSearchButton)
        Me.Controls.Add(Me.InspectionMonth_ComboBox)
        Me.Controls.Add(Me.InspectionMonth_Value)
        Me.Controls.Add(Me.InspectionMonthLabel)
        Me.Controls.Add(Me.InspectionSticker_Value)
        Me.Controls.Add(Me.InspectionStickerLabel)
        Me.Controls.Add(Me.InspectionSticker_Textbox)
        Me.Controls.Add(Me.NbrTasks_Value)
        Me.Controls.Add(Me.NbrTasksLabel)
        Me.Controls.Add(Me.WorkDate_Textbox)
        Me.Controls.Add(Me.WorkDate_Value)
        Me.Controls.Add(Me.WorkDateLabel)
        Me.Controls.Add(Me.ApptDate_Textbox)
        Me.Controls.Add(Me.ApptDate_Value)
        Me.Controls.Add(Me.AppointmentDate_Label)
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
        Me.Controls.Add(Me.ContactName_Value)
        Me.Controls.Add(Me.ContactLabel)
        Me.Controls.Add(Me.ContactName_Textbox)
        Me.Controls.Add(Me.Complete_Value)
        Me.Controls.Add(Me.Complete_CheckBox)
        Me.Controls.Add(Me.CompleteLabel)
        Me.Controls.Add(Me.InvNbr_Value)
        Me.Controls.Add(Me.InvoiceNumberLabel)
        Me.Controls.Add(Me.InvNbr_Textbox)
        Me.Controls.Add(Me.InvDate_Textbox)
        Me.Controls.Add(Me.InvDate_Value)
        Me.Controls.Add(Me.InvoiceDateLabel)
        Me.Controls.Add(Me.CustomerComboBox)
        Me.Controls.Add(Me.invoiceNumLabel)
        Me.Controls.Add(Me.InvoiceNumComboBox)
        Me.Controls.Add(Me.CustomerComboLabel)
        Me.Controls.Add(Me.deleteInvButton)
        Me.Controls.Add(Me.invoiceMaintenanceLabel)
        Me.Controls.Add(Me.modifyInvButton)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.newInvButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "invoices"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Invoices"
        Me.CostTableLayoutPanel.ResumeLayout(False)
        Me.CostTableLayoutPanel.PerformLayout()
        Me.TotalPanel.ResumeLayout(False)
        Me.TotalPanel.PerformLayout()
        Me.TaxPanel.ResumeLayout(False)
        Me.TaxPanel.PerformLayout()
        Me.SubTotalPanel.ResumeLayout(False)
        Me.SubTotalPanel.PerformLayout()
        Me.PartsPanel.ResumeLayout(False)
        Me.PartsPanel.PerformLayout()
        Me.LaborPanel.ResumeLayout(False)
        Me.LaborPanel.PerformLayout()
        Me.ShopChargesPanel.ResumeLayout(False)
        Me.ShopChargesPanel.PerformLayout()
        Me.TowingPanel.ResumeLayout(False)
        Me.TowingPanel.PerformLayout()
        Me.GasPanel.ResumeLayout(False)
        Me.GasPanel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents deleteInvButton As Button
    Friend WithEvents invoiceMaintenanceLabel As Label
    Friend WithEvents modifyInvButton As Button
    Friend WithEvents cancelButton As Button
    Friend WithEvents saveButton As Button
    Friend WithEvents newInvButton As Button
    Friend WithEvents invoiceNumLabel As Label
    Friend WithEvents InvoiceNumComboBox As ComboBox
    Friend WithEvents CustomerComboLabel As Label
    Friend WithEvents CustomerComboBox As ComboBox
    Friend WithEvents InvDate_Textbox As MaskedTextBox
    Friend WithEvents InvDate_Value As Label
    Friend WithEvents InvoiceDateLabel As Label
    Friend WithEvents InvNbr_Value As Label
    Friend WithEvents InvoiceNumberLabel As Label
    Friend WithEvents InvNbr_Textbox As TextBox
    Friend WithEvents Complete_Value As Label
    Friend WithEvents Complete_CheckBox As CheckBox
    Friend WithEvents CompleteLabel As Label
    Friend WithEvents ContactName_Value As Label
    Friend WithEvents ContactLabel As Label
    Friend WithEvents ContactName_Textbox As TextBox
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
    Friend WithEvents ApptDate_Textbox As MaskedTextBox
    Friend WithEvents ApptDate_Value As Label
    Friend WithEvents AppointmentDate_Label As Label
    Friend WithEvents WorkDate_Textbox As MaskedTextBox
    Friend WithEvents WorkDate_Value As Label
    Friend WithEvents WorkDateLabel As Label
    Friend WithEvents NbrTasks_Value As Label
    Friend WithEvents NbrTasksLabel As Label
    Friend WithEvents InspectionSticker_Value As Label
    Friend WithEvents InspectionStickerLabel As Label
    Friend WithEvents InspectionSticker_Textbox As TextBox
    Friend WithEvents InspectionMonth_ComboBox As ComboBox
    Friend WithEvents InspectionMonth_Value As Label
    Friend WithEvents InspectionMonthLabel As Label
    Friend WithEvents licensePlateSearchButton As Button
    Friend WithEvents tasksButton As Button
    Friend WithEvents paymentsButton As Button
    Friend WithEvents PayDate_Value As Label
    Friend WithEvents PayDateLabel As Label
    Friend WithEvents TotalPaid_Value As Label
    Friend WithEvents TotalPaidLabel As Label
    Friend WithEvents NbrTasks_Textbox As TextBox
    Friend WithEvents PayDate_Textbox As MaskedTextBox
    Friend WithEvents TotalPaid_Textbox As TextBox
    Friend WithEvents BalanceTextbox As TextBox
    Friend WithEvents BalanceValue As Label
    Friend WithEvents BalanceLabel As Label
    Friend WithEvents Notes_Value As Label
    Friend WithEvents NotesLabel As Label
    Friend WithEvents Notes_Textbox As TextBox
    Friend WithEvents ShopSupplies_Value As Label
    Friend WithEvents ShopSupplies_CheckBox As CheckBox
    Friend WithEvents ShopSuppliesLabel As Label
    Friend WithEvents TaxExempt_Value As Label
    Friend WithEvents TaxExempt_CheckBox As CheckBox
    Friend WithEvents TaxExemptLabel As Label
    Friend WithEvents printInvButton As Button
    Friend WithEvents CostTableLayoutPanel As TableLayoutPanel
    Friend WithEvents ShopChargesLabel As Label
    Friend WithEvents PartsLabel As Label
    Friend WithEvents LaborLabel As Label
    Friend WithEvents TaxLabel As Label
    Friend WithEvents SubTotalLabel As Label
    Friend WithEvents TotalLabel As Label
    Friend WithEvents TowingLabel As Label
    Friend WithEvents GasLabel As Label
    Friend WithEvents ShopChargesPanel As Panel
    Friend WithEvents ShopCharges_Value As Label
    Friend WithEvents ShopCharges_Textbox As TextBox
    Friend WithEvents GasPanel As Panel
    Friend WithEvents Gas_Textbox As TextBox
    Friend WithEvents Gas_Value As Label
    Friend WithEvents TowingPanel As Panel
    Friend WithEvents Towing_Textbox As TextBox
    Friend WithEvents Towing_Value As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents LicenseStateComboBox As ComboBox
    Friend WithEvents LicenseState_Value As Label
    Friend WithEvents LicenseStateLabel As Label
    Friend WithEvents LicensePlateLabel As Label
    Friend WithEvents LicensePlateTextbox As TextBox
    Friend WithEvents LaborPanel As Panel
    Friend WithEvents TotalLabor_Textbox As TextBox
    Friend WithEvents TotalLabor_Value As Label
    Friend WithEvents PartsPanel As Panel
    Friend WithEvents TotalParts_Textbox As TextBox
    Friend WithEvents TotalParts_Value As Label
    Friend WithEvents SubTotalPanel As Panel
    Friend WithEvents SubTotalTextbox As TextBox
    Friend WithEvents SubTotalValue As Label
    Friend WithEvents TaxPanel As Panel
    Friend WithEvents Tax_Textbox As TextBox
    Friend WithEvents Tax_Value As Label
    Friend WithEvents TotalPanel As Panel
    Friend WithEvents InvTotal_Textbox As TextBox
    Friend WithEvents InvTotal_Value As Label
End Class
