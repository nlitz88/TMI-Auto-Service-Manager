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
        Me.CustomerComboBox = New System.Windows.Forms.ComboBox()
        Me.invoiceNumLabel = New System.Windows.Forms.Label()
        Me.invoiceNumComboBox = New System.Windows.Forms.ComboBox()
        Me.CustomerComboLabel = New System.Windows.Forms.Label()
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
        'CustomerComboBox
        '
        Me.CustomerComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CustomerComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CustomerComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.CustomerComboBox.FormattingEnabled = True
        Me.CustomerComboBox.Location = New System.Drawing.Point(179, 194)
        Me.CustomerComboBox.Name = "CustomerComboBox"
        Me.CustomerComboBox.Size = New System.Drawing.Size(437, 28)
        Me.CustomerComboBox.TabIndex = 140
        '
        'invoiceNumLabel
        '
        Me.invoiceNumLabel.AutoSize = True
        Me.invoiceNumLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.invoiceNumLabel.Location = New System.Drawing.Point(97, 245)
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
        Me.invoiceNumComboBox.Location = New System.Drawing.Point(175, 239)
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
        'invoices
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(982, 753)
        Me.Controls.Add(Me.CustomerComboBox)
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
    Friend WithEvents CustomerComboBox As ComboBox
    Friend WithEvents invoiceNumLabel As Label
    Friend WithEvents invoiceNumComboBox As ComboBox
    Friend WithEvents CustomerComboLabel As Label
End Class
