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
        Me.ListPrice_Textbox = New System.Windows.Forms.TextBox()
        Me.ListPriceLabel = New System.Windows.Forms.Label()
        Me.ListPrice_Value = New System.Windows.Forms.Label()
        Me.PartPrice_Textbox = New System.Windows.Forms.TextBox()
        Me.PriceLabel = New System.Windows.Forms.Label()
        Me.PartPrice_Value = New System.Windows.Forms.Label()
        Me.deleteButton = New System.Windows.Forms.Button()
        Me.CustomerId_Value = New System.Windows.Forms.Label()
        Me.PartNumberLabel = New System.Windows.Forms.Label()
        Me.CustomerComboLabel = New System.Windows.Forms.Label()
        Me.CustomerComboBox = New System.Windows.Forms.ComboBox()
        Me.inventoryMaintenanceLabel = New System.Windows.Forms.Label()
        Me.editButton = New System.Windows.Forms.Button()
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.addButton = New System.Windows.Forms.Button()
        Me.FirstName_Value = New System.Windows.Forms.Label()
        Me.FirstNameLabel = New System.Windows.Forms.Label()
        Me.FirstName_Textbox = New System.Windows.Forms.TextBox()
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
        'ListPrice_Textbox
        '
        Me.ListPrice_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListPrice_Textbox.Location = New System.Drawing.Point(400, 449)
        Me.ListPrice_Textbox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ListPrice_Textbox.Name = "ListPrice_Textbox"
        Me.ListPrice_Textbox.Size = New System.Drawing.Size(118, 31)
        Me.ListPrice_Textbox.TabIndex = 117
        Me.ListPrice_Textbox.Tag = "dataEditingControl"
        '
        'ListPriceLabel
        '
        Me.ListPriceLabel.AutoSize = True
        Me.ListPriceLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ListPriceLabel.Location = New System.Drawing.Point(310, 456)
        Me.ListPriceLabel.Name = "ListPriceLabel"
        Me.ListPriceLabel.Size = New System.Drawing.Size(81, 20)
        Me.ListPriceLabel.TabIndex = 130
        Me.ListPriceLabel.Tag = "dataLabel"
        Me.ListPriceLabel.Text = "List Price :"
        '
        'ListPrice_Value
        '
        Me.ListPrice_Value.AutoSize = True
        Me.ListPrice_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListPrice_Value.ForeColor = System.Drawing.Color.Black
        Me.ListPrice_Value.Location = New System.Drawing.Point(400, 452)
        Me.ListPrice_Value.Name = "ListPrice_Value"
        Me.ListPrice_Value.Size = New System.Drawing.Size(0, 25)
        Me.ListPrice_Value.TabIndex = 129
        Me.ListPrice_Value.Tag = "dataViewingControl"
        '
        'PartPrice_Textbox
        '
        Me.PartPrice_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartPrice_Textbox.Location = New System.Drawing.Point(167, 449)
        Me.PartPrice_Textbox.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PartPrice_Textbox.Name = "PartPrice_Textbox"
        Me.PartPrice_Textbox.Size = New System.Drawing.Size(118, 31)
        Me.PartPrice_Textbox.TabIndex = 116
        Me.PartPrice_Textbox.Tag = "dataEditingControl"
        '
        'PriceLabel
        '
        Me.PriceLabel.AutoSize = True
        Me.PriceLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.PriceLabel.Location = New System.Drawing.Point(106, 456)
        Me.PriceLabel.Name = "PriceLabel"
        Me.PriceLabel.Size = New System.Drawing.Size(52, 20)
        Me.PriceLabel.TabIndex = 128
        Me.PriceLabel.Tag = "dataLabel"
        Me.PriceLabel.Text = "Price :"
        '
        'PartPrice_Value
        '
        Me.PartPrice_Value.AutoSize = True
        Me.PartPrice_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PartPrice_Value.ForeColor = System.Drawing.Color.Black
        Me.PartPrice_Value.Location = New System.Drawing.Point(167, 452)
        Me.PartPrice_Value.Name = "PartPrice_Value"
        Me.PartPrice_Value.Size = New System.Drawing.Size(0, 25)
        Me.PartPrice_Value.TabIndex = 127
        Me.PartPrice_Value.Tag = "dataViewingControl"
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
        'inventoryMaintenanceLabel
        '
        Me.inventoryMaintenanceLabel.AutoSize = True
        Me.inventoryMaintenanceLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.inventoryMaintenanceLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.inventoryMaintenanceLabel.Location = New System.Drawing.Point(106, 91)
        Me.inventoryMaintenanceLabel.Name = "inventoryMaintenanceLabel"
        Me.inventoryMaintenanceLabel.Size = New System.Drawing.Size(160, 38)
        Me.inventoryMaintenanceLabel.TabIndex = 123
        Me.inventoryMaintenanceLabel.Text = "Inventory"
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
        'customerMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1105, 941)
        Me.Controls.Add(Me.FirstName_Value)
        Me.Controls.Add(Me.FirstNameLabel)
        Me.Controls.Add(Me.FirstName_Textbox)
        Me.Controls.Add(Me.LastName_Value)
        Me.Controls.Add(Me.LastNameLabel)
        Me.Controls.Add(Me.LastName_Textbox)
        Me.Controls.Add(Me.ListPrice_Textbox)
        Me.Controls.Add(Me.ListPriceLabel)
        Me.Controls.Add(Me.ListPrice_Value)
        Me.Controls.Add(Me.PartPrice_Textbox)
        Me.Controls.Add(Me.PriceLabel)
        Me.Controls.Add(Me.PartPrice_Value)
        Me.Controls.Add(Me.deleteButton)
        Me.Controls.Add(Me.CustomerId_Value)
        Me.Controls.Add(Me.PartNumberLabel)
        Me.Controls.Add(Me.CustomerComboLabel)
        Me.Controls.Add(Me.CustomerComboBox)
        Me.Controls.Add(Me.inventoryMaintenanceLabel)
        Me.Controls.Add(Me.editButton)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.addButton)
        Me.Controls.Add(Me.nav)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "customerMaintenance"
        Me.Text = "Customers"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents nav As navigation
    Friend WithEvents LastName_Value As Label
    Friend WithEvents LastNameLabel As Label
    Friend WithEvents LastName_Textbox As TextBox
    Friend WithEvents ListPrice_Textbox As TextBox
    Friend WithEvents ListPriceLabel As Label
    Friend WithEvents ListPrice_Value As Label
    Friend WithEvents PartPrice_Textbox As TextBox
    Friend WithEvents PriceLabel As Label
    Friend WithEvents PartPrice_Value As Label
    Friend WithEvents deleteButton As Button
    Friend WithEvents CustomerId_Value As Label
    Friend WithEvents PartNumberLabel As Label
    Friend WithEvents CustomerComboLabel As Label
    Friend WithEvents CustomerComboBox As ComboBox
    Friend WithEvents inventoryMaintenanceLabel As Label
    Friend WithEvents editButton As Button
    Friend WithEvents cancelButton As Button
    Friend WithEvents saveButton As Button
    Friend WithEvents addButton As Button
    Friend WithEvents FirstName_Value As Label
    Friend WithEvents FirstNameLabel As Label
    Friend WithEvents FirstName_Textbox As TextBox
End Class
