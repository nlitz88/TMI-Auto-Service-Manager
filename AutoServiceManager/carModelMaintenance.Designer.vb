<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class carModelMaintenance
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
        Me.AutoModel_Value = New System.Windows.Forms.Label()
        Me.ModelNameLabel = New System.Windows.Forms.Label()
        Me.AutoModel_Textbox = New System.Windows.Forms.TextBox()
        Me.deleteButton = New System.Windows.Forms.Button()
        Me.AutoMakeComboLabel = New System.Windows.Forms.Label()
        Me.AutoMakeComboBox = New System.Windows.Forms.ComboBox()
        Me.carModelMaintenanceLabel = New System.Windows.Forms.Label()
        Me.editButton = New System.Windows.Forms.Button()
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.addButton = New System.Windows.Forms.Button()
        Me.ModelLabel = New System.Windows.Forms.Label()
        Me.CarModelComboBox = New System.Windows.Forms.ComboBox()
        Me.nav = New AutoServiceManager.navigation()
        Me.SuspendLayout()
        '
        'AutoModel_Value
        '
        Me.AutoModel_Value.AutoSize = True
        Me.AutoModel_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AutoModel_Value.ForeColor = System.Drawing.Color.Black
        Me.AutoModel_Value.Location = New System.Drawing.Point(198, 317)
        Me.AutoModel_Value.Name = "AutoModel_Value"
        Me.AutoModel_Value.Size = New System.Drawing.Size(0, 20)
        Me.AutoModel_Value.TabIndex = 11
        Me.AutoModel_Value.Tag = "dataViewingControl"
        Me.AutoModel_Value.Visible = False
        '
        'ModelNameLabel
        '
        Me.ModelNameLabel.AutoSize = True
        Me.ModelNameLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ModelNameLabel.Location = New System.Drawing.Point(97, 320)
        Me.ModelNameLabel.Name = "ModelNameLabel"
        Me.ModelNameLabel.Size = New System.Drawing.Size(95, 17)
        Me.ModelNameLabel.TabIndex = 131
        Me.ModelNameLabel.Tag = "dataLabel"
        Me.ModelNameLabel.Text = "Model Name :"
        Me.ModelNameLabel.Visible = False
        '
        'AutoModel_Textbox
        '
        Me.AutoModel_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AutoModel_Textbox.Location = New System.Drawing.Point(198, 314)
        Me.AutoModel_Textbox.MaxLength = 50
        Me.AutoModel_Textbox.Name = "AutoModel_Textbox"
        Me.AutoModel_Textbox.Size = New System.Drawing.Size(221, 27)
        Me.AutoModel_Textbox.TabIndex = 2
        Me.AutoModel_Textbox.Tag = "dataEditingControl"
        Me.AutoModel_Textbox.Visible = False
        '
        'deleteButton
        '
        Me.deleteButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.deleteButton.Enabled = False
        Me.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.deleteButton.ForeColor = System.Drawing.Color.White
        Me.deleteButton.Location = New System.Drawing.Point(217, 120)
        Me.deleteButton.Name = "deleteButton"
        Me.deleteButton.Size = New System.Drawing.Size(110, 30)
        Me.deleteButton.TabIndex = 4
        Me.deleteButton.Text = "Delete"
        Me.deleteButton.UseVisualStyleBackColor = False
        '
        'AutoMakeComboLabel
        '
        Me.AutoMakeComboLabel.AutoSize = True
        Me.AutoMakeComboLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.AutoMakeComboLabel.Location = New System.Drawing.Point(97, 200)
        Me.AutoMakeComboLabel.Name = "AutoMakeComboLabel"
        Me.AutoMakeComboLabel.Size = New System.Drawing.Size(100, 17)
        Me.AutoMakeComboLabel.TabIndex = 124
        Me.AutoMakeComboLabel.Text = "Manufacturer :"
        '
        'AutoMakeComboBox
        '
        Me.AutoMakeComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.AutoMakeComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.AutoMakeComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.AutoMakeComboBox.FormattingEnabled = True
        Me.AutoMakeComboBox.Location = New System.Drawing.Point(203, 194)
        Me.AutoMakeComboBox.Name = "AutoMakeComboBox"
        Me.AutoMakeComboBox.Size = New System.Drawing.Size(240, 28)
        Me.AutoMakeComboBox.TabIndex = 0
        '
        'carModelMaintenanceLabel
        '
        Me.carModelMaintenanceLabel.AutoSize = True
        Me.carModelMaintenanceLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.carModelMaintenanceLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.carModelMaintenanceLabel.Location = New System.Drawing.Point(94, 73)
        Me.carModelMaintenanceLabel.Name = "carModelMaintenanceLabel"
        Me.carModelMaintenanceLabel.Size = New System.Drawing.Size(169, 32)
        Me.carModelMaintenanceLabel.TabIndex = 123
        Me.carModelMaintenanceLabel.Text = "Car Models"
        '
        'editButton
        '
        Me.editButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.editButton.Enabled = False
        Me.editButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.editButton.ForeColor = System.Drawing.Color.White
        Me.editButton.Location = New System.Drawing.Point(333, 120)
        Me.editButton.Name = "editButton"
        Me.editButton.Size = New System.Drawing.Size(110, 30)
        Me.editButton.TabIndex = 5
        Me.editButton.Text = "Edit"
        Me.editButton.UseVisualStyleBackColor = False
        '
        'cancelButton
        '
        Me.cancelButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.cancelButton.Enabled = False
        Me.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cancelButton.ForeColor = System.Drawing.Color.White
        Me.cancelButton.Location = New System.Drawing.Point(565, 120)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(110, 30)
        Me.cancelButton.TabIndex = 7
        Me.cancelButton.Text = "Cancel"
        Me.cancelButton.UseVisualStyleBackColor = False
        '
        'saveButton
        '
        Me.saveButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.saveButton.Enabled = False
        Me.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.saveButton.ForeColor = System.Drawing.Color.White
        Me.saveButton.Location = New System.Drawing.Point(449, 120)
        Me.saveButton.Name = "saveButton"
        Me.saveButton.Size = New System.Drawing.Size(110, 30)
        Me.saveButton.TabIndex = 6
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
        Me.addButton.TabIndex = 3
        Me.addButton.Text = "Add"
        Me.addButton.UseVisualStyleBackColor = False
        '
        'ModelLabel
        '
        Me.ModelLabel.AutoSize = True
        Me.ModelLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ModelLabel.Location = New System.Drawing.Point(97, 256)
        Me.ModelLabel.Name = "ModelLabel"
        Me.ModelLabel.Size = New System.Drawing.Size(54, 17)
        Me.ModelLabel.TabIndex = 135
        Me.ModelLabel.Text = "Model :"
        '
        'CarModelComboBox
        '
        Me.CarModelComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.CarModelComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CarModelComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.CarModelComboBox.FormattingEnabled = True
        Me.CarModelComboBox.Location = New System.Drawing.Point(157, 250)
        Me.CarModelComboBox.Name = "CarModelComboBox"
        Me.CarModelComboBox.Size = New System.Drawing.Size(240, 28)
        Me.CarModelComboBox.TabIndex = 1
        '
        'nav
        '
        Me.nav.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nav.Location = New System.Drawing.Point(0, 0)
        Me.nav.Name = "nav"
        Me.nav.Size = New System.Drawing.Size(982, 28)
        Me.nav.TabIndex = 133
        '
        'carModelMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(982, 753)
        Me.Controls.Add(Me.ModelLabel)
        Me.Controls.Add(Me.CarModelComboBox)
        Me.Controls.Add(Me.nav)
        Me.Controls.Add(Me.AutoModel_Value)
        Me.Controls.Add(Me.ModelNameLabel)
        Me.Controls.Add(Me.AutoModel_Textbox)
        Me.Controls.Add(Me.deleteButton)
        Me.Controls.Add(Me.AutoMakeComboLabel)
        Me.Controls.Add(Me.AutoMakeComboBox)
        Me.Controls.Add(Me.carModelMaintenanceLabel)
        Me.Controls.Add(Me.editButton)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.addButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "carModelMaintenance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Car Models"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents AutoModel_Value As Label
    Friend WithEvents ModelNameLabel As Label
    Friend WithEvents AutoModel_Textbox As TextBox
    Friend WithEvents deleteButton As Button
    Friend WithEvents AutoMakeComboLabel As Label
    Friend WithEvents AutoMakeComboBox As ComboBox
    Friend WithEvents carModelMaintenanceLabel As Label
    Friend WithEvents editButton As Button
    Friend WithEvents cancelButton As Button
    Friend WithEvents saveButton As Button
    Friend WithEvents addButton As Button
    Friend WithEvents nav As navigation
    Friend WithEvents ModelLabel As Label
    Friend WithEvents CarModelComboBox As ComboBox
End Class
