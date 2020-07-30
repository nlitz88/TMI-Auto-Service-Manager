<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class colorMaintenance
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
        Me.Color_Textbox = New System.Windows.Forms.TextBox()
        Me.Color_Value = New System.Windows.Forms.Label()
        Me.ACNameLabel = New System.Windows.Forms.Label()
        Me.ACLabel = New System.Windows.Forms.Label()
        Me.ACComboBox = New System.Windows.Forms.ComboBox()
        Me.colorMaintenanceLabel = New System.Windows.Forms.Label()
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
        'Color_Textbox
        '
        Me.Color_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Color_Textbox.Location = New System.Drawing.Point(193, 258)
        Me.Color_Textbox.MaxLength = 20
        Me.Color_Textbox.Name = "Color_Textbox"
        Me.Color_Textbox.Size = New System.Drawing.Size(179, 27)
        Me.Color_Textbox.TabIndex = 77
        Me.Color_Textbox.Tag = "dataEditingControl"
        '
        'Color_Value
        '
        Me.Color_Value.AutoSize = True
        Me.Color_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Color_Value.ForeColor = System.Drawing.Color.Black
        Me.Color_Value.Location = New System.Drawing.Point(193, 261)
        Me.Color_Value.Name = "Color_Value"
        Me.Color_Value.Size = New System.Drawing.Size(0, 20)
        Me.Color_Value.TabIndex = 76
        Me.Color_Value.Tag = "dataViewingControl"
        '
        'ACNameLabel
        '
        Me.ACNameLabel.AutoSize = True
        Me.ACNameLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ACNameLabel.Location = New System.Drawing.Point(97, 264)
        Me.ACNameLabel.Name = "ACNameLabel"
        Me.ACNameLabel.Size = New System.Drawing.Size(90, 17)
        Me.ACNameLabel.TabIndex = 75
        Me.ACNameLabel.Tag = "dataLabel"
        Me.ACNameLabel.Text = "Color Name :"
        '
        'ACLabel
        '
        Me.ACLabel.AutoSize = True
        Me.ACLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ACLabel.Location = New System.Drawing.Point(97, 200)
        Me.ACLabel.Name = "ACLabel"
        Me.ACLabel.Size = New System.Drawing.Size(49, 17)
        Me.ACLabel.TabIndex = 74
        Me.ACLabel.Text = "Color :"
        '
        'ACComboBox
        '
        Me.ACComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ACComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ACComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.ACComboBox.FormattingEnabled = True
        Me.ACComboBox.Location = New System.Drawing.Point(152, 194)
        Me.ACComboBox.Name = "ACComboBox"
        Me.ACComboBox.Size = New System.Drawing.Size(179, 28)
        Me.ACComboBox.TabIndex = 73
        '
        'colorMaintenanceLabel
        '
        Me.colorMaintenanceLabel.AutoSize = True
        Me.colorMaintenanceLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colorMaintenanceLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.colorMaintenanceLabel.Location = New System.Drawing.Point(94, 73)
        Me.colorMaintenanceLabel.Name = "colorMaintenanceLabel"
        Me.colorMaintenanceLabel.Size = New System.Drawing.Size(174, 32)
        Me.colorMaintenanceLabel.TabIndex = 72
        Me.colorMaintenanceLabel.Text = "Auto Colors"
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
        'colorMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(982, 753)
        Me.Controls.Add(Me.deleteButton)
        Me.Controls.Add(Me.Color_Textbox)
        Me.Controls.Add(Me.Color_Value)
        Me.Controls.Add(Me.ACNameLabel)
        Me.Controls.Add(Me.ACLabel)
        Me.Controls.Add(Me.ACComboBox)
        Me.Controls.Add(Me.colorMaintenanceLabel)
        Me.Controls.Add(Me.editButton)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.addButton)
        Me.Controls.Add(Me.nav)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "colorMaintenance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Auto Colors"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents nav As navigation
    Friend WithEvents deleteButton As Button
    Friend WithEvents Color_Textbox As TextBox
    Friend WithEvents Color_Value As Label
    Friend WithEvents ACNameLabel As Label
    Friend WithEvents ACLabel As Label
    Friend WithEvents ACComboBox As ComboBox
    Friend WithEvents colorMaintenanceLabel As Label
    Friend WithEvents editButton As Button
    Friend WithEvents cancelButton As Button
    Friend WithEvents saveButton As Button
    Friend WithEvents addButton As Button
End Class
