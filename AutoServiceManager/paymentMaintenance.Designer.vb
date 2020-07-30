<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class paymentMaintenance
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
        Me.deleteButton = New System.Windows.Forms.Button()
        Me.PaymentType_Textbox = New System.Windows.Forms.TextBox()
        Me.PaymentType_Value = New System.Windows.Forms.Label()
        Me.PTNameLabel = New System.Windows.Forms.Label()
        Me.PTLabel = New System.Windows.Forms.Label()
        Me.PTComboBox = New System.Windows.Forms.ComboBox()
        Me.paymentMaintenanceLabel = New System.Windows.Forms.Label()
        Me.editButton = New System.Windows.Forms.Button()
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.addButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'nav
        '
        Me.nav.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nav.Location = New System.Drawing.Point(0, 0)
        Me.nav.Name = "nav"
        Me.nav.Size = New System.Drawing.Size(982, 28)
        Me.nav.TabIndex = 47
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
        Me.deleteButton.TabIndex = 78
        Me.deleteButton.Text = "Delete"
        Me.deleteButton.UseVisualStyleBackColor = False
        '
        'PaymentType_Textbox
        '
        Me.PaymentType_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaymentType_Textbox.Location = New System.Drawing.Point(251, 258)
        Me.PaymentType_Textbox.Name = "PaymentType_Textbox"
        Me.PaymentType_Textbox.Size = New System.Drawing.Size(210, 27)
        Me.PaymentType_Textbox.TabIndex = 77
        Me.PaymentType_Textbox.Tag = "dataEditingControl"
        '
        'PaymentType_Value
        '
        Me.PaymentType_Value.AutoSize = True
        Me.PaymentType_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PaymentType_Value.ForeColor = System.Drawing.Color.Black
        Me.PaymentType_Value.Location = New System.Drawing.Point(251, 261)
        Me.PaymentType_Value.Name = "PaymentType_Value"
        Me.PaymentType_Value.Size = New System.Drawing.Size(0, 20)
        Me.PaymentType_Value.TabIndex = 76
        Me.PaymentType_Value.Tag = "dataViewingControl"
        '
        'PTNameLabel
        '
        Me.PTNameLabel.AutoSize = True
        Me.PTNameLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.PTNameLabel.Location = New System.Drawing.Point(97, 264)
        Me.PTNameLabel.Name = "PTNameLabel"
        Me.PTNameLabel.Size = New System.Drawing.Size(148, 17)
        Me.PTNameLabel.TabIndex = 75
        Me.PTNameLabel.Tag = "dataLabel"
        Me.PTNameLabel.Text = "Payment Type Name :"
        '
        'PTLabel
        '
        Me.PTLabel.AutoSize = True
        Me.PTLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.PTLabel.Location = New System.Drawing.Point(97, 200)
        Me.PTLabel.Name = "PTLabel"
        Me.PTLabel.Size = New System.Drawing.Size(107, 17)
        Me.PTLabel.TabIndex = 74
        Me.PTLabel.Text = "Payment Type :"
        '
        'PTComboBox
        '
        Me.PTComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.PTComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.PTComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.PTComboBox.FormattingEnabled = True
        Me.PTComboBox.Location = New System.Drawing.Point(210, 194)
        Me.PTComboBox.Name = "PTComboBox"
        Me.PTComboBox.Size = New System.Drawing.Size(210, 28)
        Me.PTComboBox.TabIndex = 73
        '
        'paymentMaintenanceLabel
        '
        Me.paymentMaintenanceLabel.AutoSize = True
        Me.paymentMaintenanceLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.paymentMaintenanceLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.paymentMaintenanceLabel.Location = New System.Drawing.Point(94, 73)
        Me.paymentMaintenanceLabel.Name = "paymentMaintenanceLabel"
        Me.paymentMaintenanceLabel.Size = New System.Drawing.Size(359, 32)
        Me.paymentMaintenanceLabel.TabIndex = 72
        Me.paymentMaintenanceLabel.Text = "Payment Types Accepted"
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
        Me.editButton.TabIndex = 71
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
        Me.cancelButton.TabIndex = 70
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
        Me.saveButton.TabIndex = 69
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
        Me.addButton.TabIndex = 68
        Me.addButton.Text = "Add"
        Me.addButton.UseVisualStyleBackColor = False
        '
        'paymentMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(982, 753)
        Me.Controls.Add(Me.deleteButton)
        Me.Controls.Add(Me.PaymentType_Textbox)
        Me.Controls.Add(Me.PaymentType_Value)
        Me.Controls.Add(Me.PTNameLabel)
        Me.Controls.Add(Me.PTLabel)
        Me.Controls.Add(Me.PTComboBox)
        Me.Controls.Add(Me.paymentMaintenanceLabel)
        Me.Controls.Add(Me.editButton)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.addButton)
        Me.Controls.Add(Me.nav)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "paymentMaintenance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Payment Types Accepted"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents nav As navigation
    Friend WithEvents deleteButton As Button
    Friend WithEvents PaymentType_Textbox As TextBox
    Friend WithEvents PaymentType_Value As Label
    Friend WithEvents PTNameLabel As Label
    Friend WithEvents PTLabel As Label
    Friend WithEvents PTComboBox As ComboBox
    Friend WithEvents paymentMaintenanceLabel As Label
    Friend WithEvents editButton As Button
    Friend WithEvents cancelButton As Button
    Friend WithEvents saveButton As Button
    Friend WithEvents addButton As Button
End Class
