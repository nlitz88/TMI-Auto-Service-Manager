<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class navigation
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.mainMs = New System.Windows.Forms.MenuStrip()
        Me.HomeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewInvoiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InvoiceMaintenanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileMaintenanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompanySetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutomobileManufacturersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutoColorsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InsuranceCompaniesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreditCardsAcceptedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PaymentTypesAcceptedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TaskTypesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InventoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mainMs.SuspendLayout()
        Me.SuspendLayout()
        '
        'mainMs
        '
        Me.mainMs.BackColor = System.Drawing.Color.White
        Me.mainMs.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.mainMs.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HomeToolStripMenuItem, Me.NewInvoiceToolStripMenuItem, Me.InvoiceMaintenanceToolStripMenuItem, Me.FileMaintenanceToolStripMenuItem, Me.ReportsToolStripMenuItem})
        Me.mainMs.Location = New System.Drawing.Point(0, 0)
        Me.mainMs.Name = "mainMs"
        Me.mainMs.Size = New System.Drawing.Size(1000, 28)
        Me.mainMs.TabIndex = 46
        Me.mainMs.Text = "MenuStrip1"
        '
        'HomeToolStripMenuItem
        '
        Me.HomeToolStripMenuItem.Name = "HomeToolStripMenuItem"
        Me.HomeToolStripMenuItem.Size = New System.Drawing.Size(64, 24)
        Me.HomeToolStripMenuItem.Text = "Home"
        '
        'NewInvoiceToolStripMenuItem
        '
        Me.NewInvoiceToolStripMenuItem.Name = "NewInvoiceToolStripMenuItem"
        Me.NewInvoiceToolStripMenuItem.Size = New System.Drawing.Size(104, 24)
        Me.NewInvoiceToolStripMenuItem.Text = "New Invoice"
        '
        'InvoiceMaintenanceToolStripMenuItem
        '
        Me.InvoiceMaintenanceToolStripMenuItem.Name = "InvoiceMaintenanceToolStripMenuItem"
        Me.InvoiceMaintenanceToolStripMenuItem.Size = New System.Drawing.Size(159, 24)
        Me.InvoiceMaintenanceToolStripMenuItem.Text = "Invoice Maintenance"
        '
        'FileMaintenanceToolStripMenuItem
        '
        Me.FileMaintenanceToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CompanySetupToolStripMenuItem, Me.AutomobileManufacturersToolStripMenuItem, Me.AutoColorsToolStripMenuItem, Me.InsuranceCompaniesToolStripMenuItem, Me.CreditCardsAcceptedToolStripMenuItem, Me.PaymentTypesAcceptedToolStripMenuItem, Me.TaskTypesToolStripMenuItem, Me.InventoryToolStripMenuItem})
        Me.FileMaintenanceToolStripMenuItem.Name = "FileMaintenanceToolStripMenuItem"
        Me.FileMaintenanceToolStripMenuItem.Size = New System.Drawing.Size(135, 24)
        Me.FileMaintenanceToolStripMenuItem.Text = "File Maintenance"
        '
        'CompanySetupToolStripMenuItem
        '
        Me.CompanySetupToolStripMenuItem.Name = "CompanySetupToolStripMenuItem"
        Me.CompanySetupToolStripMenuItem.Size = New System.Drawing.Size(256, 26)
        Me.CompanySetupToolStripMenuItem.Text = "Company Setup"
        '
        'AutomobileManufacturersToolStripMenuItem
        '
        Me.AutomobileManufacturersToolStripMenuItem.Name = "AutomobileManufacturersToolStripMenuItem"
        Me.AutomobileManufacturersToolStripMenuItem.Size = New System.Drawing.Size(256, 26)
        Me.AutomobileManufacturersToolStripMenuItem.Text = "Auto Manufacturers"
        '
        'AutoColorsToolStripMenuItem
        '
        Me.AutoColorsToolStripMenuItem.Name = "AutoColorsToolStripMenuItem"
        Me.AutoColorsToolStripMenuItem.Size = New System.Drawing.Size(256, 26)
        Me.AutoColorsToolStripMenuItem.Text = "Auto Colors"
        '
        'InsuranceCompaniesToolStripMenuItem
        '
        Me.InsuranceCompaniesToolStripMenuItem.Name = "InsuranceCompaniesToolStripMenuItem"
        Me.InsuranceCompaniesToolStripMenuItem.Size = New System.Drawing.Size(256, 26)
        Me.InsuranceCompaniesToolStripMenuItem.Text = "Insurance Companies"
        '
        'CreditCardsAcceptedToolStripMenuItem
        '
        Me.CreditCardsAcceptedToolStripMenuItem.Name = "CreditCardsAcceptedToolStripMenuItem"
        Me.CreditCardsAcceptedToolStripMenuItem.Size = New System.Drawing.Size(256, 26)
        Me.CreditCardsAcceptedToolStripMenuItem.Text = "Credit Cards Accepted"
        '
        'PaymentTypesAcceptedToolStripMenuItem
        '
        Me.PaymentTypesAcceptedToolStripMenuItem.Name = "PaymentTypesAcceptedToolStripMenuItem"
        Me.PaymentTypesAcceptedToolStripMenuItem.Size = New System.Drawing.Size(256, 26)
        Me.PaymentTypesAcceptedToolStripMenuItem.Text = "Payment Types Accepted"
        '
        'TaskTypesToolStripMenuItem
        '
        Me.TaskTypesToolStripMenuItem.Name = "TaskTypesToolStripMenuItem"
        Me.TaskTypesToolStripMenuItem.Size = New System.Drawing.Size(256, 26)
        Me.TaskTypesToolStripMenuItem.Text = "Task Types"
        '
        'InventoryToolStripMenuItem
        '
        Me.InventoryToolStripMenuItem.Name = "InventoryToolStripMenuItem"
        Me.InventoryToolStripMenuItem.Size = New System.Drawing.Size(256, 26)
        Me.InventoryToolStripMenuItem.Text = "Inventory"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(74, 24)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'navigation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.mainMs)
        Me.Name = "navigation"
        Me.Size = New System.Drawing.Size(1000, 28)
        Me.mainMs.ResumeLayout(False)
        Me.mainMs.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents mainMs As MenuStrip
    Friend WithEvents HomeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewInvoiceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InvoiceMaintenanceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FileMaintenanceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CompanySetupToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AutomobileManufacturersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InsuranceCompaniesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CreditCardsAcceptedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AutoColorsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PaymentTypesAcceptedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TaskTypesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InventoryToolStripMenuItem As ToolStripMenuItem
End Class
