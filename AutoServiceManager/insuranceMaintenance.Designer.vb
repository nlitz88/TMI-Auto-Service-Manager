<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class insuranceMaintenance
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
        Me.Navigation1 = New AutoServiceManager.navigation()
        Me.insuranceMaintenanceLabel = New System.Windows.Forms.Label()
        Me.deleteButton = New System.Windows.Forms.Button()
        Me.editButton = New System.Windows.Forms.Button()
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.addButton = New System.Windows.Forms.Button()
        Me.icLabel = New System.Windows.Forms.Label()
        Me.icCombobox = New System.Windows.Forms.ComboBox()
        Me.COmpanyName_Textbox = New System.Windows.Forms.TextBox()
        Me.AutoMake_Value = New System.Windows.Forms.Label()
        Me.icNameLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Navigation1
        '
        Me.Navigation1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Navigation1.Location = New System.Drawing.Point(0, 0)
        Me.Navigation1.Name = "Navigation1"
        Me.Navigation1.Size = New System.Drawing.Size(982, 28)
        Me.Navigation1.TabIndex = 57
        '
        'insuranceMaintenanceLabel
        '
        Me.insuranceMaintenanceLabel.AutoSize = True
        Me.insuranceMaintenanceLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.insuranceMaintenanceLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.insuranceMaintenanceLabel.Location = New System.Drawing.Point(94, 73)
        Me.insuranceMaintenanceLabel.Name = "insuranceMaintenanceLabel"
        Me.insuranceMaintenanceLabel.Size = New System.Drawing.Size(309, 32)
        Me.insuranceMaintenanceLabel.TabIndex = 58
        Me.insuranceMaintenanceLabel.Text = "Insurance Companies"
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
        Me.deleteButton.TabIndex = 63
        Me.deleteButton.Text = "Delete"
        Me.deleteButton.UseVisualStyleBackColor = False
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
        Me.editButton.TabIndex = 62
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
        Me.cancelButton.TabIndex = 61
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
        Me.saveButton.TabIndex = 60
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
        Me.addButton.TabIndex = 59
        Me.addButton.Text = "Add"
        Me.addButton.UseVisualStyleBackColor = False
        '
        'icLabel
        '
        Me.icLabel.AutoSize = True
        Me.icLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.icLabel.Location = New System.Drawing.Point(97, 200)
        Me.icLabel.Name = "icLabel"
        Me.icLabel.Size = New System.Drawing.Size(141, 17)
        Me.icLabel.TabIndex = 65
        Me.icLabel.Text = "Insurance Company :"
        '
        'icCombobox
        '
        Me.icCombobox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.icCombobox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.icCombobox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.icCombobox.FormattingEnabled = True
        Me.icCombobox.Location = New System.Drawing.Point(244, 194)
        Me.icCombobox.Name = "icCombobox"
        Me.icCombobox.Size = New System.Drawing.Size(430, 28)
        Me.icCombobox.TabIndex = 64
        '
        'COmpanyName_Textbox
        '
        Me.COmpanyName_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.COmpanyName_Textbox.Location = New System.Drawing.Point(285, 258)
        Me.COmpanyName_Textbox.Name = "COmpanyName_Textbox"
        Me.COmpanyName_Textbox.Size = New System.Drawing.Size(430, 27)
        Me.COmpanyName_Textbox.TabIndex = 68
        Me.COmpanyName_Textbox.Tag = "dataEditingControl"
        Me.COmpanyName_Textbox.Visible = False
        '
        'AutoMake_Value
        '
        Me.AutoMake_Value.AutoSize = True
        Me.AutoMake_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AutoMake_Value.ForeColor = System.Drawing.Color.Black
        Me.AutoMake_Value.Location = New System.Drawing.Point(244, 257)
        Me.AutoMake_Value.Name = "AutoMake_Value"
        Me.AutoMake_Value.Size = New System.Drawing.Size(0, 20)
        Me.AutoMake_Value.TabIndex = 67
        Me.AutoMake_Value.Tag = "dataViewingControl"
        '
        'icNameLabel
        '
        Me.icNameLabel.AutoSize = True
        Me.icNameLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.icNameLabel.Location = New System.Drawing.Point(97, 264)
        Me.icNameLabel.Name = "icNameLabel"
        Me.icNameLabel.Size = New System.Drawing.Size(182, 17)
        Me.icNameLabel.TabIndex = 66
        Me.icNameLabel.Tag = "dataLabel"
        Me.icNameLabel.Text = "Insurance Company Name :"
        '
        'insuranceMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(982, 753)
        Me.Controls.Add(Me.COmpanyName_Textbox)
        Me.Controls.Add(Me.AutoMake_Value)
        Me.Controls.Add(Me.icNameLabel)
        Me.Controls.Add(Me.icLabel)
        Me.Controls.Add(Me.icCombobox)
        Me.Controls.Add(Me.deleteButton)
        Me.Controls.Add(Me.editButton)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.addButton)
        Me.Controls.Add(Me.insuranceMaintenanceLabel)
        Me.Controls.Add(Me.Navigation1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "insuranceMaintenance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Insurance Companies"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Navigation1 As navigation
    Friend WithEvents insuranceMaintenanceLabel As Label
    Friend WithEvents deleteButton As Button
    Friend WithEvents editButton As Button
    Friend WithEvents cancelButton As Button
    Friend WithEvents saveButton As Button
    Friend WithEvents addButton As Button
    Friend WithEvents icLabel As Label
    Friend WithEvents icCombobox As ComboBox
    Friend WithEvents COmpanyName_Textbox As TextBox
    Friend WithEvents AutoMake_Value As Label
    Friend WithEvents icNameLabel As Label
End Class
