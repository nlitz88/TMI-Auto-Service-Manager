<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class invoiceTasks
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.deleteButton = New System.Windows.Forms.Button()
        Me.invoiceTasksLabel = New System.Windows.Forms.Label()
        Me.editButton = New System.Windows.Forms.Button()
        Me.cancelButton = New System.Windows.Forms.Button()
        Me.saveButton = New System.Windows.Forms.Button()
        Me.addButton = New System.Windows.Forms.Button()
        Me.InvTaskComboLabel = New System.Windows.Forms.Label()
        Me.InvTaskComboBox = New System.Windows.Forms.ComboBox()
        Me.InvoiceLabel = New System.Windows.Forms.Label()
        Me.InvoiceValue = New System.Windows.Forms.Label()
        Me.InvTotalTaskTextbox = New System.Windows.Forms.TextBox()
        Me.TotalCostLabel = New System.Windows.Forms.Label()
        Me.InvTotalTaskValue = New System.Windows.Forms.Label()
        Me.InvTaskParts_Textbox = New System.Windows.Forms.TextBox()
        Me.TotalPartsCostLabel = New System.Windows.Forms.Label()
        Me.InvTaskParts_Value = New System.Windows.Forms.Label()
        Me.InvTaskLabor_Textbox = New System.Windows.Forms.TextBox()
        Me.TotalLaborCostLabel = New System.Windows.Forms.Label()
        Me.InvTaskLabor_Value = New System.Windows.Forms.Label()
        Me.Instructions_Value = New System.Windows.Forms.Label()
        Me.InstructionsLabel = New System.Windows.Forms.Label()
        Me.Instructions_Textbox = New System.Windows.Forms.TextBox()
        Me.TaskDescription_Value = New System.Windows.Forms.Label()
        Me.DescriptionLabel = New System.Windows.Forms.Label()
        Me.TaskDescription_Textbox = New System.Windows.Forms.TextBox()
        Me.InvTaskPartsGridView = New System.Windows.Forms.DataGridView()
        Me.TaskPartsLabel = New System.Windows.Forms.Label()
        Me.TaskLaborLabel = New System.Windows.Forms.Label()
        Me.tpDeleteButton = New System.Windows.Forms.Button()
        Me.tpEditButton = New System.Windows.Forms.Button()
        Me.tpAddButton = New System.Windows.Forms.Button()
        Me.tlDeleteButton = New System.Windows.Forms.Button()
        Me.tlEditButton = New System.Windows.Forms.Button()
        Me.tlAddButton = New System.Windows.Forms.Button()
        Me.InvTaskLaborGridView = New System.Windows.Forms.DataGridView()
        Me.returnButton = New System.Windows.Forms.Button()
        CType(Me.InvTaskPartsGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvTaskLaborGridView, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.deleteButton.TabIndex = 131
        Me.deleteButton.Text = "Delete"
        Me.deleteButton.UseVisualStyleBackColor = False
        '
        'invoiceTasksLabel
        '
        Me.invoiceTasksLabel.AutoSize = True
        Me.invoiceTasksLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.invoiceTasksLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.invoiceTasksLabel.Location = New System.Drawing.Point(94, 73)
        Me.invoiceTasksLabel.Name = "invoiceTasksLabel"
        Me.invoiceTasksLabel.Size = New System.Drawing.Size(200, 32)
        Me.invoiceTasksLabel.TabIndex = 135
        Me.invoiceTasksLabel.Text = "Invoice Tasks"
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
        Me.editButton.TabIndex = 132
        Me.editButton.Text = "Edit"
        Me.editButton.UseVisualStyleBackColor = False
        '
        'cancelButton
        '
        Me.cancelButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.cancelButton.Enabled = False
        Me.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cancelButton.ForeColor = System.Drawing.Color.White
        Me.cancelButton.Location = New System.Drawing.Point(563, 120)
        Me.cancelButton.Name = "cancelButton"
        Me.cancelButton.Size = New System.Drawing.Size(110, 30)
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
        Me.saveButton.Location = New System.Drawing.Point(448, 120)
        Me.saveButton.Name = "saveButton"
        Me.saveButton.Size = New System.Drawing.Size(110, 30)
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
        Me.addButton.Size = New System.Drawing.Size(110, 30)
        Me.addButton.TabIndex = 130
        Me.addButton.Tag = ""
        Me.addButton.Text = "Add"
        Me.addButton.UseVisualStyleBackColor = False
        '
        'InvTaskComboLabel
        '
        Me.InvTaskComboLabel.AutoSize = True
        Me.InvTaskComboLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.InvTaskComboLabel.Location = New System.Drawing.Point(97, 240)
        Me.InvTaskComboLabel.Name = "InvTaskComboLabel"
        Me.InvTaskComboLabel.Size = New System.Drawing.Size(95, 17)
        Me.InvTaskComboLabel.TabIndex = 137
        Me.InvTaskComboLabel.Text = "Invoice Task :"
        '
        'InvTaskComboBox
        '
        Me.InvTaskComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.InvTaskComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.InvTaskComboBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.InvTaskComboBox.FormattingEnabled = True
        Me.InvTaskComboBox.Location = New System.Drawing.Point(198, 234)
        Me.InvTaskComboBox.Name = "InvTaskComboBox"
        Me.InvTaskComboBox.Size = New System.Drawing.Size(408, 28)
        Me.InvTaskComboBox.TabIndex = 136
        '
        'InvoiceLabel
        '
        Me.InvoiceLabel.AutoSize = True
        Me.InvoiceLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.InvoiceLabel.Location = New System.Drawing.Point(97, 186)
        Me.InvoiceLabel.Name = "InvoiceLabel"
        Me.InvoiceLabel.Size = New System.Drawing.Size(60, 17)
        Me.InvoiceLabel.TabIndex = 226
        Me.InvoiceLabel.Tag = "dataLabel"
        Me.InvoiceLabel.Text = "Invoice :"
        '
        'InvoiceValue
        '
        Me.InvoiceValue.AutoSize = True
        Me.InvoiceValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InvoiceValue.ForeColor = System.Drawing.Color.Black
        Me.InvoiceValue.Location = New System.Drawing.Point(163, 183)
        Me.InvoiceValue.Name = "InvoiceValue"
        Me.InvoiceValue.Size = New System.Drawing.Size(0, 20)
        Me.InvoiceValue.TabIndex = 225
        Me.InvoiceValue.Tag = ""
        '
        'InvTotalTaskTextbox
        '
        Me.InvTotalTaskTextbox.Enabled = False
        Me.InvTotalTaskTextbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InvTotalTaskTextbox.Location = New System.Drawing.Point(681, 380)
        Me.InvTotalTaskTextbox.Name = "InvTotalTaskTextbox"
        Me.InvTotalTaskTextbox.Size = New System.Drawing.Size(105, 27)
        Me.InvTotalTaskTextbox.TabIndex = 242
        Me.InvTotalTaskTextbox.Tag = "dataEditingControl"
        '
        'TotalCostLabel
        '
        Me.TotalCostLabel.AutoSize = True
        Me.TotalCostLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TotalCostLabel.Location = New System.Drawing.Point(595, 386)
        Me.TotalCostLabel.Name = "TotalCostLabel"
        Me.TotalCostLabel.Size = New System.Drawing.Size(80, 17)
        Me.TotalCostLabel.TabIndex = 244
        Me.TotalCostLabel.Tag = "dataLabel"
        Me.TotalCostLabel.Text = "Total Cost :"
        '
        'InvTotalTaskValue
        '
        Me.InvTotalTaskValue.AutoSize = True
        Me.InvTotalTaskValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InvTotalTaskValue.ForeColor = System.Drawing.Color.Black
        Me.InvTotalTaskValue.Location = New System.Drawing.Point(681, 383)
        Me.InvTotalTaskValue.Name = "InvTotalTaskValue"
        Me.InvTotalTaskValue.Size = New System.Drawing.Size(0, 20)
        Me.InvTotalTaskValue.TabIndex = 243
        Me.InvTotalTaskValue.Tag = "dataViewingControl"
        '
        'InvTaskParts_Textbox
        '
        Me.InvTaskParts_Textbox.Enabled = False
        Me.InvTaskParts_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InvTaskParts_Textbox.Location = New System.Drawing.Point(469, 380)
        Me.InvTaskParts_Textbox.Name = "InvTaskParts_Textbox"
        Me.InvTaskParts_Textbox.Size = New System.Drawing.Size(105, 27)
        Me.InvTaskParts_Textbox.TabIndex = 239
        Me.InvTaskParts_Textbox.Tag = "dataEditingControl"
        '
        'TotalPartsCostLabel
        '
        Me.TotalPartsCostLabel.AutoSize = True
        Me.TotalPartsCostLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TotalPartsCostLabel.Location = New System.Drawing.Point(346, 386)
        Me.TotalPartsCostLabel.Name = "TotalPartsCostLabel"
        Me.TotalPartsCostLabel.Size = New System.Drawing.Size(117, 17)
        Me.TotalPartsCostLabel.TabIndex = 241
        Me.TotalPartsCostLabel.Tag = "dataLabel"
        Me.TotalPartsCostLabel.Text = "Total Parts Cost :"
        '
        'InvTaskParts_Value
        '
        Me.InvTaskParts_Value.AutoSize = True
        Me.InvTaskParts_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InvTaskParts_Value.ForeColor = System.Drawing.Color.Black
        Me.InvTaskParts_Value.Location = New System.Drawing.Point(469, 383)
        Me.InvTaskParts_Value.Name = "InvTaskParts_Value"
        Me.InvTaskParts_Value.Size = New System.Drawing.Size(0, 20)
        Me.InvTaskParts_Value.TabIndex = 240
        Me.InvTaskParts_Value.Tag = "dataViewingControl"
        '
        'InvTaskLabor_Textbox
        '
        Me.InvTaskLabor_Textbox.Enabled = False
        Me.InvTaskLabor_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InvTaskLabor_Textbox.Location = New System.Drawing.Point(221, 380)
        Me.InvTaskLabor_Textbox.Name = "InvTaskLabor_Textbox"
        Me.InvTaskLabor_Textbox.Size = New System.Drawing.Size(105, 27)
        Me.InvTaskLabor_Textbox.TabIndex = 236
        Me.InvTaskLabor_Textbox.Tag = "dataEditingControl"
        '
        'TotalLaborCostLabel
        '
        Me.TotalLaborCostLabel.AutoSize = True
        Me.TotalLaborCostLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TotalLaborCostLabel.Location = New System.Drawing.Point(97, 386)
        Me.TotalLaborCostLabel.Name = "TotalLaborCostLabel"
        Me.TotalLaborCostLabel.Size = New System.Drawing.Size(121, 17)
        Me.TotalLaborCostLabel.TabIndex = 238
        Me.TotalLaborCostLabel.Tag = "dataLabel"
        Me.TotalLaborCostLabel.Text = "Total Labor Cost :"
        '
        'InvTaskLabor_Value
        '
        Me.InvTaskLabor_Value.AutoSize = True
        Me.InvTaskLabor_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InvTaskLabor_Value.ForeColor = System.Drawing.Color.Black
        Me.InvTaskLabor_Value.Location = New System.Drawing.Point(221, 383)
        Me.InvTaskLabor_Value.Name = "InvTaskLabor_Value"
        Me.InvTaskLabor_Value.Size = New System.Drawing.Size(0, 20)
        Me.InvTaskLabor_Value.TabIndex = 237
        Me.InvTaskLabor_Value.Tag = "dataViewingControl"
        '
        'Instructions_Value
        '
        Me.Instructions_Value.AutoSize = True
        Me.Instructions_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Instructions_Value.ForeColor = System.Drawing.Color.Black
        Me.Instructions_Value.Location = New System.Drawing.Point(191, 341)
        Me.Instructions_Value.Name = "Instructions_Value"
        Me.Instructions_Value.Size = New System.Drawing.Size(0, 20)
        Me.Instructions_Value.TabIndex = 235
        Me.Instructions_Value.Tag = "dataViewingControl"
        '
        'InstructionsLabel
        '
        Me.InstructionsLabel.AutoSize = True
        Me.InstructionsLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.InstructionsLabel.Location = New System.Drawing.Point(97, 344)
        Me.InstructionsLabel.Name = "InstructionsLabel"
        Me.InstructionsLabel.Size = New System.Drawing.Size(88, 17)
        Me.InstructionsLabel.TabIndex = 234
        Me.InstructionsLabel.Tag = "dataLabel"
        Me.InstructionsLabel.Text = "Instructions :"
        '
        'Instructions_Textbox
        '
        Me.Instructions_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Instructions_Textbox.Location = New System.Drawing.Point(191, 338)
        Me.Instructions_Textbox.MaxLength = 255
        Me.Instructions_Textbox.Name = "Instructions_Textbox"
        Me.Instructions_Textbox.Size = New System.Drawing.Size(641, 27)
        Me.Instructions_Textbox.TabIndex = 231
        Me.Instructions_Textbox.Tag = "dataEditingControl"
        Me.Instructions_Textbox.Visible = False
        '
        'TaskDescription_Value
        '
        Me.TaskDescription_Value.AutoSize = True
        Me.TaskDescription_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TaskDescription_Value.ForeColor = System.Drawing.Color.Black
        Me.TaskDescription_Value.Location = New System.Drawing.Point(190, 300)
        Me.TaskDescription_Value.Name = "TaskDescription_Value"
        Me.TaskDescription_Value.Size = New System.Drawing.Size(0, 20)
        Me.TaskDescription_Value.TabIndex = 233
        Me.TaskDescription_Value.Tag = "dataViewingControl"
        '
        'DescriptionLabel
        '
        Me.DescriptionLabel.AutoSize = True
        Me.DescriptionLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.DescriptionLabel.Location = New System.Drawing.Point(97, 303)
        Me.DescriptionLabel.Name = "DescriptionLabel"
        Me.DescriptionLabel.Size = New System.Drawing.Size(87, 17)
        Me.DescriptionLabel.TabIndex = 232
        Me.DescriptionLabel.Tag = "dataLabel"
        Me.DescriptionLabel.Text = "Description :"
        '
        'TaskDescription_Textbox
        '
        Me.TaskDescription_Textbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TaskDescription_Textbox.Location = New System.Drawing.Point(190, 297)
        Me.TaskDescription_Textbox.MaxLength = 50
        Me.TaskDescription_Textbox.Name = "TaskDescription_Textbox"
        Me.TaskDescription_Textbox.Size = New System.Drawing.Size(408, 27)
        Me.TaskDescription_Textbox.TabIndex = 230
        Me.TaskDescription_Textbox.Tag = "dataEditingControl"
        Me.TaskDescription_Textbox.Visible = False
        '
        'InvTaskPartsGridView
        '
        Me.InvTaskPartsGridView.AllowUserToAddRows = False
        Me.InvTaskPartsGridView.AllowUserToDeleteRows = False
        Me.InvTaskPartsGridView.AllowUserToResizeColumns = False
        Me.InvTaskPartsGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.InvTaskPartsGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.InvTaskPartsGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.InvTaskPartsGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.InvTaskPartsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.InvTaskPartsGridView.DefaultCellStyle = DataGridViewCellStyle6
        Me.InvTaskPartsGridView.Location = New System.Drawing.Point(509, 482)
        Me.InvTaskPartsGridView.MultiSelect = False
        Me.InvTaskPartsGridView.Name = "InvTaskPartsGridView"
        Me.InvTaskPartsGridView.ReadOnly = True
        Me.InvTaskPartsGridView.RowHeadersVisible = False
        Me.InvTaskPartsGridView.RowHeadersWidth = 51
        Me.InvTaskPartsGridView.RowTemplate.Height = 24
        Me.InvTaskPartsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.InvTaskPartsGridView.ShowEditingIcon = False
        Me.InvTaskPartsGridView.Size = New System.Drawing.Size(369, 200)
        Me.InvTaskPartsGridView.TabIndex = 254
        Me.InvTaskPartsGridView.Tag = "subTaskEditingControl"
        '
        'TaskPartsLabel
        '
        Me.TaskPartsLabel.AutoSize = True
        Me.TaskPartsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TaskPartsLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TaskPartsLabel.Location = New System.Drawing.Point(504, 440)
        Me.TaskPartsLabel.Name = "TaskPartsLabel"
        Me.TaskPartsLabel.Size = New System.Drawing.Size(137, 29)
        Me.TaskPartsLabel.TabIndex = 253
        Me.TaskPartsLabel.Tag = "dataLabel"
        Me.TaskPartsLabel.Text = "Task Parts"
        '
        'TaskLaborLabel
        '
        Me.TaskLaborLabel.AutoSize = True
        Me.TaskLaborLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TaskLaborLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.TaskLaborLabel.Location = New System.Drawing.Point(95, 440)
        Me.TaskLaborLabel.Name = "TaskLaborLabel"
        Me.TaskLaborLabel.Size = New System.Drawing.Size(144, 29)
        Me.TaskLaborLabel.TabIndex = 252
        Me.TaskLaborLabel.Tag = "dataLabel"
        Me.TaskLaborLabel.Text = "Task Labor"
        '
        'tpDeleteButton
        '
        Me.tpDeleteButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.tpDeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.tpDeleteButton.ForeColor = System.Drawing.Color.White
        Me.tpDeleteButton.Location = New System.Drawing.Point(742, 439)
        Me.tpDeleteButton.Name = "tpDeleteButton"
        Me.tpDeleteButton.Size = New System.Drawing.Size(65, 30)
        Me.tpDeleteButton.TabIndex = 249
        Me.tpDeleteButton.Tag = "subTaskEditingControl"
        Me.tpDeleteButton.Text = "Delete"
        Me.tpDeleteButton.UseVisualStyleBackColor = False
        '
        'tpEditButton
        '
        Me.tpEditButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.tpEditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.tpEditButton.ForeColor = System.Drawing.Color.White
        Me.tpEditButton.Location = New System.Drawing.Point(813, 439)
        Me.tpEditButton.Name = "tpEditButton"
        Me.tpEditButton.Size = New System.Drawing.Size(65, 30)
        Me.tpEditButton.TabIndex = 250
        Me.tpEditButton.Tag = "subTaskEditingControl"
        Me.tpEditButton.Text = "Edit"
        Me.tpEditButton.UseVisualStyleBackColor = False
        '
        'tpAddButton
        '
        Me.tpAddButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.tpAddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.tpAddButton.ForeColor = System.Drawing.Color.White
        Me.tpAddButton.Location = New System.Drawing.Point(671, 439)
        Me.tpAddButton.Name = "tpAddButton"
        Me.tpAddButton.Size = New System.Drawing.Size(65, 30)
        Me.tpAddButton.TabIndex = 248
        Me.tpAddButton.Tag = "subTaskEditingControl"
        Me.tpAddButton.Text = "Add"
        Me.tpAddButton.UseVisualStyleBackColor = False
        '
        'tlDeleteButton
        '
        Me.tlDeleteButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.tlDeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.tlDeleteButton.ForeColor = System.Drawing.Color.White
        Me.tlDeleteButton.Location = New System.Drawing.Point(331, 440)
        Me.tlDeleteButton.Name = "tlDeleteButton"
        Me.tlDeleteButton.Size = New System.Drawing.Size(66, 30)
        Me.tlDeleteButton.TabIndex = 246
        Me.tlDeleteButton.Tag = "subTaskEditingControl"
        Me.tlDeleteButton.Text = "Delete"
        Me.tlDeleteButton.UseVisualStyleBackColor = False
        '
        'tlEditButton
        '
        Me.tlEditButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.tlEditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.tlEditButton.ForeColor = System.Drawing.Color.White
        Me.tlEditButton.Location = New System.Drawing.Point(403, 440)
        Me.tlEditButton.Name = "tlEditButton"
        Me.tlEditButton.Size = New System.Drawing.Size(66, 30)
        Me.tlEditButton.TabIndex = 247
        Me.tlEditButton.Tag = "subTaskEditingControl"
        Me.tlEditButton.Text = "Edit"
        Me.tlEditButton.UseVisualStyleBackColor = False
        '
        'tlAddButton
        '
        Me.tlAddButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.tlAddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.tlAddButton.ForeColor = System.Drawing.Color.White
        Me.tlAddButton.Location = New System.Drawing.Point(259, 440)
        Me.tlAddButton.Name = "tlAddButton"
        Me.tlAddButton.Size = New System.Drawing.Size(66, 30)
        Me.tlAddButton.TabIndex = 245
        Me.tlAddButton.Tag = "subTaskEditingControl"
        Me.tlAddButton.Text = "Add"
        Me.tlAddButton.UseVisualStyleBackColor = False
        '
        'InvTaskLaborGridView
        '
        Me.InvTaskLaborGridView.AllowUserToAddRows = False
        Me.InvTaskLaborGridView.AllowUserToDeleteRows = False
        Me.InvTaskLaborGridView.AllowUserToResizeColumns = False
        Me.InvTaskLaborGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.InvTaskLaborGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.InvTaskLaborGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.InvTaskLaborGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.InvTaskLaborGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.InvTaskLaborGridView.DefaultCellStyle = DataGridViewCellStyle8
        Me.InvTaskLaborGridView.Location = New System.Drawing.Point(100, 482)
        Me.InvTaskLaborGridView.MultiSelect = False
        Me.InvTaskLaborGridView.Name = "InvTaskLaborGridView"
        Me.InvTaskLaborGridView.ReadOnly = True
        Me.InvTaskLaborGridView.RowHeadersVisible = False
        Me.InvTaskLaborGridView.RowHeadersWidth = 51
        Me.InvTaskLaborGridView.RowTemplate.Height = 24
        Me.InvTaskLaborGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.InvTaskLaborGridView.ShowEditingIcon = False
        Me.InvTaskLaborGridView.Size = New System.Drawing.Size(369, 200)
        Me.InvTaskLaborGridView.TabIndex = 251
        Me.InvTaskLaborGridView.Tag = "subTaskEditingControl"
        '
        'returnButton
        '
        Me.returnButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.returnButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.returnButton.ForeColor = System.Drawing.Color.White
        Me.returnButton.Location = New System.Drawing.Point(681, 120)
        Me.returnButton.Name = "returnButton"
        Me.returnButton.Size = New System.Drawing.Size(197, 30)
        Me.returnButton.TabIndex = 255
        Me.returnButton.Text = "Return To Invoice"
        Me.returnButton.UseVisualStyleBackColor = False
        '
        'invoiceTasks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(982, 753)
        Me.Controls.Add(Me.returnButton)
        Me.Controls.Add(Me.InvTaskPartsGridView)
        Me.Controls.Add(Me.TaskPartsLabel)
        Me.Controls.Add(Me.TaskLaborLabel)
        Me.Controls.Add(Me.tpDeleteButton)
        Me.Controls.Add(Me.tpEditButton)
        Me.Controls.Add(Me.tpAddButton)
        Me.Controls.Add(Me.tlDeleteButton)
        Me.Controls.Add(Me.tlEditButton)
        Me.Controls.Add(Me.tlAddButton)
        Me.Controls.Add(Me.InvTaskLaborGridView)
        Me.Controls.Add(Me.InvTotalTaskTextbox)
        Me.Controls.Add(Me.TotalCostLabel)
        Me.Controls.Add(Me.InvTotalTaskValue)
        Me.Controls.Add(Me.InvTaskParts_Textbox)
        Me.Controls.Add(Me.TotalPartsCostLabel)
        Me.Controls.Add(Me.InvTaskParts_Value)
        Me.Controls.Add(Me.InvTaskLabor_Textbox)
        Me.Controls.Add(Me.TotalLaborCostLabel)
        Me.Controls.Add(Me.InvTaskLabor_Value)
        Me.Controls.Add(Me.Instructions_Value)
        Me.Controls.Add(Me.InstructionsLabel)
        Me.Controls.Add(Me.Instructions_Textbox)
        Me.Controls.Add(Me.TaskDescription_Value)
        Me.Controls.Add(Me.DescriptionLabel)
        Me.Controls.Add(Me.TaskDescription_Textbox)
        Me.Controls.Add(Me.InvoiceLabel)
        Me.Controls.Add(Me.InvoiceValue)
        Me.Controls.Add(Me.InvTaskComboLabel)
        Me.Controls.Add(Me.InvTaskComboBox)
        Me.Controls.Add(Me.deleteButton)
        Me.Controls.Add(Me.invoiceTasksLabel)
        Me.Controls.Add(Me.editButton)
        Me.Controls.Add(Me.cancelButton)
        Me.Controls.Add(Me.saveButton)
        Me.Controls.Add(Me.addButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "invoiceTasks"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Invoice Tasks"
        CType(Me.InvTaskPartsGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InvTaskLaborGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents deleteButton As Button
    Friend WithEvents invoiceTasksLabel As Label
    Friend WithEvents editButton As Button
    Friend WithEvents cancelButton As Button
    Friend WithEvents saveButton As Button
    Friend WithEvents addButton As Button
    Friend WithEvents InvTaskComboLabel As Label
    Friend WithEvents InvTaskComboBox As ComboBox
    Friend WithEvents InvoiceLabel As Label
    Friend WithEvents InvoiceValue As Label
    Friend WithEvents InvTotalTaskTextbox As TextBox
    Friend WithEvents TotalCostLabel As Label
    Friend WithEvents InvTotalTaskValue As Label
    Friend WithEvents InvTaskParts_Textbox As TextBox
    Friend WithEvents TotalPartsCostLabel As Label
    Friend WithEvents InvTaskParts_Value As Label
    Friend WithEvents InvTaskLabor_Textbox As TextBox
    Friend WithEvents TotalLaborCostLabel As Label
    Friend WithEvents InvTaskLabor_Value As Label
    Friend WithEvents Instructions_Value As Label
    Friend WithEvents InstructionsLabel As Label
    Friend WithEvents Instructions_Textbox As TextBox
    Friend WithEvents TaskDescription_Value As Label
    Friend WithEvents DescriptionLabel As Label
    Friend WithEvents TaskDescription_Textbox As TextBox
    Friend WithEvents InvTaskPartsGridView As DataGridView
    Friend WithEvents TaskPartsLabel As Label
    Friend WithEvents TaskLaborLabel As Label
    Friend WithEvents tpDeleteButton As Button
    Friend WithEvents tpEditButton As Button
    Friend WithEvents tpAddButton As Button
    Friend WithEvents tlDeleteButton As Button
    Friend WithEvents tlEditButton As Button
    Friend WithEvents tlAddButton As Button
    Friend WithEvents InvTaskLaborGridView As DataGridView
    Friend WithEvents returnButton As Button
End Class
