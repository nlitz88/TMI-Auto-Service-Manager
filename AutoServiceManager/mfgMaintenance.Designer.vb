<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class mfgMaintenance
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
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.addButton = New System.Windows.Forms.Button()
        Me.editButton = New System.Windows.Forms.Button()
        Me.mfgMaintenanceLabel = New System.Windows.Forms.Label()
        Me.AutoMakeComboBox = New System.Windows.Forms.ComboBox()
        Me.mfgLabel = New System.Windows.Forms.Label()
        Me.mfgNameLabel = New System.Windows.Forms.Label()
        Me.AutoMake_Value = New System.Windows.Forms.Label()
        Me.nav = New AutoServiceManager.navigation()
        Me.AutoMake_Textbox = New System.Windows.Forms.TextBox()
        Me.deleteButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
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
        Me.cancelButton.TabIndex = 48
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
        Me.saveButton.TabIndex = 47
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
        Me.addButton.TabIndex = 46
        Me.addButton.Text = "Add"
        Me.addButton.UseVisualStyleBackColor = False
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
        Me.editButton.TabIndex = 49
        Me.editButton.Text = "Edit"
        Me.editButton.UseVisualStyleBackColor = False
        '
        'mfgMaintenanceLabel
        '
        Me.mfgMaintenanceLabel.AutoSize = True
        Me.mfgMaintenanceLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mfgMaintenanceLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.mfgMaintenanceLabel.Location = New System.Drawing.Point(94, 73)
        Me.mfgMaintenanceLabel.Name = "mfgMaintenanceLabel"
        Me.mfgMaintenanceLabel.Size = New System.Drawing.Size(280, 32)
        Me.mfgMaintenanceLabel.TabIndex = 50
        Me.mfgMaintenanceLabel.Text = "Auto Manufacturers"
        '
        'AutoMakeComboBox
        '
        Me.AutoMakeComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.AutoMakeComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.AutoMakeComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.AutoMakeComboBox.FormattingEnabled = True
        Me.AutoMakeComboBox.Location = New System.Drawing.Point(203, 194)
        Me.AutoMakeComboBox.Name = "AutoMakeComboBox"
        Me.AutoMakeComboBox.Size = New System.Drawing.Size(210, 28)
        Me.AutoMakeComboBox.TabIndex = 51
        '
        'mfgLabel
        '
        Me.mfgLabel.AutoSize = True
        Me.mfgLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.mfgLabel.Location = New System.Drawing.Point(97, 200)
        Me.mfgLabel.Name = "mfgLabel"
        Me.mfgLabel.Size = New System.Drawing.Size(100, 17)
        Me.mfgLabel.TabIndex = 52
        Me.mfgLabel.Text = "Manufacturer :"
        '
        'mfgNameLabel
        '
        Me.mfgNameLabel.AutoSize = True
        Me.mfgNameLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.mfgNameLabel.Location = New System.Drawing.Point(97, 264)
        Me.mfgNameLabel.Name = "mfgNameLabel"
        Me.mfgNameLabel.Size = New System.Drawing.Size(141, 17)
        Me.mfgNameLabel.TabIndex = 53
        Me.mfgNameLabel.Tag = "dataLabel"
        Me.mfgNameLabel.Text = "Manufacturer Name :"
        '
        'AutoMake_Value
        '
        Me.AutoMake_Value.AutoSize = True
        Me.AutoMake_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AutoMake_Value.ForeColor = System.Drawing.Color.Black
        Me.AutoMake_Value.Location = New System.Drawing.Point(244, 261)
        Me.AutoMake_Value.Name = "AutoMake_Value"
        Me.AutoMake_Value.Size = New System.Drawing.Size(0, 20)
        Me.AutoMake_Value.TabIndex = 54
        Me.AutoMake_Value.Tag = "dataViewingControl"
        '
        'nav
        '
        Me.nav.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nav.Location = New System.Drawing.Point(0, 0)
        Me.nav.Name = "nav"
        Me.nav.Size = New System.Drawing.Size(982, 28)
        Me.nav.TabIndex = 45
        '
        'AutoMake_Textbox
        '
        Me.AutoMake_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AutoMake_Textbox.Location = New System.Drawing.Point(244, 258)
        Me.AutoMake_Textbox.Name = "AutoMake_Textbox"
        Me.AutoMake_Textbox.Size = New System.Drawing.Size(210, 27)
        Me.AutoMake_Textbox.TabIndex = 55
        Me.AutoMake_Textbox.Tag = "dataEditingControl"
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
        Me.deleteButton.TabIndex = 56
        Me.deleteButton.Text = "Delete"
        Me.deleteButton.UseVisualStyleBackColor = False
        '
        'mfgMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(982, 753)
        Me.Controls.Add(Me.deleteButton)
        Me.Controls.Add(Me.AutoMake_Textbox)
        Me.Controls.Add(Me.AutoMake_Value)
        Me.Controls.Add(Me.mfgNameLabel)
        Me.Controls.Add(Me.mfgLabel)
        Me.Controls.Add(Me.AutoMakeComboBox)
        Me.Controls.Add(Me.mfgMaintenanceLabel)
        Me.Controls.Add(Me.editButton)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.addButton)
        Me.Controls.Add(Me.nav)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "mfgMaintenance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "List of Auto Manufacturers"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents nav As navigation
    Friend WithEvents cancelButton As Button
    Friend WithEvents saveButton As Button
    Friend WithEvents addButton As Button
    Friend WithEvents editButton As Button
    Friend WithEvents mfgMaintenanceLabel As Label
    Friend WithEvents AutoMakeComboBox As ComboBox
    Friend WithEvents mfgLabel As Label
    Friend WithEvents mfgNameLabel As Label
    Friend WithEvents AutoMake_Value As Label
    Friend WithEvents AutoMake_Textbox As TextBox
    Friend WithEvents deleteButton As Button
End Class
