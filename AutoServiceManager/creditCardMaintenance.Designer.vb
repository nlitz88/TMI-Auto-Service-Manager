<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class creditCardMaintenance
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
        Me.CreditCard_Textbox = New System.Windows.Forms.TextBox()
        Me.CreditCard_Value = New System.Windows.Forms.Label()
        Me.CCNameLabel = New System.Windows.Forms.Label()
        Me.CCLabel = New System.Windows.Forms.Label()
        Me.CCComboBox = New System.Windows.Forms.ComboBox()
        Me.creditCardMaintenanceLabel = New System.Windows.Forms.Label()
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
        Me.nav.TabIndex = 46
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
        Me.deleteButton.TabIndex = 67
        Me.deleteButton.Text = "Delete"
        Me.deleteButton.UseVisualStyleBackColor = False
        '
        'CreditCard_Textbox
        '
        Me.CreditCard_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CreditCard_Textbox.Location = New System.Drawing.Point(229, 258)
        Me.CreditCard_Textbox.Name = "CreditCard_Textbox"
        Me.CreditCard_Textbox.Size = New System.Drawing.Size(210, 27)
        Me.CreditCard_Textbox.TabIndex = 66
        Me.CreditCard_Textbox.Tag = "dataEditingControl"
        '
        'CreditCard_Value
        '
        Me.CreditCard_Value.AutoSize = True
        Me.CreditCard_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CreditCard_Value.ForeColor = System.Drawing.Color.Black
        Me.CreditCard_Value.Location = New System.Drawing.Point(231, 261)
        Me.CreditCard_Value.Name = "CreditCard_Value"
        Me.CreditCard_Value.Size = New System.Drawing.Size(0, 20)
        Me.CreditCard_Value.TabIndex = 65
        Me.CreditCard_Value.Tag = "dataViewingControl"
        '
        'CCNameLabel
        '
        Me.CCNameLabel.AutoSize = True
        Me.CCNameLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.CCNameLabel.Location = New System.Drawing.Point(97, 264)
        Me.CCNameLabel.Name = "CCNameLabel"
        Me.CCNameLabel.Size = New System.Drawing.Size(128, 17)
        Me.CCNameLabel.TabIndex = 64
        Me.CCNameLabel.Tag = "dataLabel"
        Me.CCNameLabel.Text = "Credit Card Name :"
        '
        'CCLabel
        '
        Me.CCLabel.AutoSize = True
        Me.CCLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.CCLabel.Location = New System.Drawing.Point(97, 200)
        Me.CCLabel.Name = "CCLabel"
        Me.CCLabel.Size = New System.Drawing.Size(87, 17)
        Me.CCLabel.TabIndex = 63
        Me.CCLabel.Text = "Credit Card :"
        '
        'CCComboBox
        '
        Me.CCComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CCComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CCComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.CCComboBox.FormattingEnabled = True
        Me.CCComboBox.Location = New System.Drawing.Point(190, 194)
        Me.CCComboBox.Name = "CCComboBox"
        Me.CCComboBox.Size = New System.Drawing.Size(210, 28)
        Me.CCComboBox.TabIndex = 62
        '
        'creditCardMaintenanceLabel
        '
        Me.creditCardMaintenanceLabel.AutoSize = True
        Me.creditCardMaintenanceLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.creditCardMaintenanceLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.creditCardMaintenanceLabel.Location = New System.Drawing.Point(94, 73)
        Me.creditCardMaintenanceLabel.Name = "creditCardMaintenanceLabel"
        Me.creditCardMaintenanceLabel.Size = New System.Drawing.Size(320, 32)
        Me.creditCardMaintenanceLabel.TabIndex = 61
        Me.creditCardMaintenanceLabel.Text = "Credit Cards Accepted"
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
        Me.editButton.TabIndex = 60
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
        Me.cancelButton.TabIndex = 59
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
        Me.saveButton.TabIndex = 58
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
        Me.addButton.TabIndex = 57
        Me.addButton.Text = "Add"
        Me.addButton.UseVisualStyleBackColor = False
        '
        'creditCardMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(982, 753)
        Me.Controls.Add(Me.deleteButton)
        Me.Controls.Add(Me.CreditCard_Textbox)
        Me.Controls.Add(Me.CreditCard_Value)
        Me.Controls.Add(Me.CCNameLabel)
        Me.Controls.Add(Me.CCLabel)
        Me.Controls.Add(Me.CCComboBox)
        Me.Controls.Add(Me.creditCardMaintenanceLabel)
        Me.Controls.Add(Me.editButton)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.addButton)
        Me.Controls.Add(Me.nav)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "creditCardMaintenance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Credit Cards Accepted"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents nav As navigation
    Friend WithEvents deleteButton As Button
    Friend WithEvents CreditCard_Textbox As TextBox
    Friend WithEvents CreditCard_Value As Label
    Friend WithEvents CCNameLabel As Label
    Friend WithEvents CCLabel As Label
    Friend WithEvents CCComboBox As ComboBox
    Friend WithEvents creditCardMaintenanceLabel As Label
    Friend WithEvents editButton As Button
    Friend WithEvents cancelButton As Button
    Friend WithEvents saveButton As Button
    Friend WithEvents addButton As Button
End Class
