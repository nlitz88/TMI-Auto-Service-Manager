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
        Me.InvoicesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileMaintenanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompanySetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutomobileManufacturersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutoColorsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InsuranceCompaniesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreditCardsAcceptedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PaymentTypesAcceptedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TaskTypesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InventoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LaborCodesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CarModelsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomerVehiclesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MasterTaskListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UnpaidInvoicesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DailyReceiptsReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MonthlyTaxReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IncompleteInvoicesReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompleteInvoiceReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mainMs.SuspendLayout()
        Me.SuspendLayout()
        '
        'mainMs
        '
        Me.mainMs.BackColor = System.Drawing.Color.White
        Me.mainMs.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.mainMs.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InvoicesToolStripMenuItem, Me.FileMaintenanceToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.LogoutToolStripMenuItem})
        Me.mainMs.Location = New System.Drawing.Point(0, 0)
        Me.mainMs.Name = "mainMs"
        Me.mainMs.Size = New System.Drawing.Size(1000, 28)
        Me.mainMs.TabIndex = 46
        Me.mainMs.Text = "MenuStrip1"
        '
        'InvoicesToolStripMenuItem
        '
        Me.InvoicesToolStripMenuItem.Name = "InvoicesToolStripMenuItem"
        Me.InvoicesToolStripMenuItem.Size = New System.Drawing.Size(76, 24)
        Me.InvoicesToolStripMenuItem.Text = "Invoices"
        '
        'FileMaintenanceToolStripMenuItem
        '
        Me.FileMaintenanceToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CompanySetupToolStripMenuItem, Me.AutomobileManufacturersToolStripMenuItem, Me.AutoColorsToolStripMenuItem, Me.InsuranceCompaniesToolStripMenuItem, Me.CreditCardsAcceptedToolStripMenuItem, Me.PaymentTypesAcceptedToolStripMenuItem, Me.TaskTypesToolStripMenuItem, Me.InventoryToolStripMenuItem, Me.LaborCodesToolStripMenuItem, Me.CarModelsToolStripMenuItem, Me.CustomersToolStripMenuItem, Me.CustomerVehiclesToolStripMenuItem, Me.MasterTaskListToolStripMenuItem})
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
        'LaborCodesToolStripMenuItem
        '
        Me.LaborCodesToolStripMenuItem.Name = "LaborCodesToolStripMenuItem"
        Me.LaborCodesToolStripMenuItem.Size = New System.Drawing.Size(256, 26)
        Me.LaborCodesToolStripMenuItem.Text = "Labor Codes"
        '
        'CarModelsToolStripMenuItem
        '
        Me.CarModelsToolStripMenuItem.Name = "CarModelsToolStripMenuItem"
        Me.CarModelsToolStripMenuItem.Size = New System.Drawing.Size(256, 26)
        Me.CarModelsToolStripMenuItem.Text = "Car Models"
        '
        'CustomersToolStripMenuItem
        '
        Me.CustomersToolStripMenuItem.Name = "CustomersToolStripMenuItem"
        Me.CustomersToolStripMenuItem.Size = New System.Drawing.Size(256, 26)
        Me.CustomersToolStripMenuItem.Text = "Customers"
        '
        'CustomerVehiclesToolStripMenuItem
        '
        Me.CustomerVehiclesToolStripMenuItem.Name = "CustomerVehiclesToolStripMenuItem"
        Me.CustomerVehiclesToolStripMenuItem.Size = New System.Drawing.Size(256, 26)
        Me.CustomerVehiclesToolStripMenuItem.Text = "Customer Vehicles"
        '
        'MasterTaskListToolStripMenuItem
        '
        Me.MasterTaskListToolStripMenuItem.Name = "MasterTaskListToolStripMenuItem"
        Me.MasterTaskListToolStripMenuItem.Size = New System.Drawing.Size(256, 26)
        Me.MasterTaskListToolStripMenuItem.Text = "Master Task List"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UnpaidInvoicesToolStripMenuItem, Me.DailyReceiptsReportToolStripMenuItem, Me.MonthlyTaxReportToolStripMenuItem, Me.IncompleteInvoicesReportToolStripMenuItem, Me.CompleteInvoiceReportToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(74, 24)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'UnpaidInvoicesToolStripMenuItem
        '
        Me.UnpaidInvoicesToolStripMenuItem.Name = "UnpaidInvoicesToolStripMenuItem"
        Me.UnpaidInvoicesToolStripMenuItem.Size = New System.Drawing.Size(273, 26)
        Me.UnpaidInvoicesToolStripMenuItem.Text = "Unpaid Invoices Report"
        '
        'DailyReceiptsReportToolStripMenuItem
        '
        Me.DailyReceiptsReportToolStripMenuItem.Name = "DailyReceiptsReportToolStripMenuItem"
        Me.DailyReceiptsReportToolStripMenuItem.Size = New System.Drawing.Size(273, 26)
        Me.DailyReceiptsReportToolStripMenuItem.Text = "Daily Receipts Report"
        '
        'MonthlyTaxReportToolStripMenuItem
        '
        Me.MonthlyTaxReportToolStripMenuItem.Name = "MonthlyTaxReportToolStripMenuItem"
        Me.MonthlyTaxReportToolStripMenuItem.Size = New System.Drawing.Size(273, 26)
        Me.MonthlyTaxReportToolStripMenuItem.Text = "Monthly Tax Report"
        '
        'IncompleteInvoicesReportToolStripMenuItem
        '
        Me.IncompleteInvoicesReportToolStripMenuItem.Name = "IncompleteInvoicesReportToolStripMenuItem"
        Me.IncompleteInvoicesReportToolStripMenuItem.Size = New System.Drawing.Size(273, 26)
        Me.IncompleteInvoicesReportToolStripMenuItem.Text = "Incomplete Invoices Report"
        '
        'LogoutToolStripMenuItem
        '
        Me.LogoutToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem"
        Me.LogoutToolStripMenuItem.Size = New System.Drawing.Size(70, 24)
        Me.LogoutToolStripMenuItem.Text = "Logout"
        '
        'CompleteInvoiceReportToolStripMenuItem
        '
        Me.CompleteInvoiceReportToolStripMenuItem.Name = "CompleteInvoiceReportToolStripMenuItem"
        Me.CompleteInvoiceReportToolStripMenuItem.Size = New System.Drawing.Size(273, 26)
        Me.CompleteInvoiceReportToolStripMenuItem.Text = "Completed Invoices Report"
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
    Friend WithEvents InvoicesToolStripMenuItem As ToolStripMenuItem
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
    Friend WithEvents LaborCodesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CarModelsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CustomersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CustomerVehiclesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MasterTaskListToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LogoutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UnpaidInvoicesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DailyReceiptsReportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MonthlyTaxReportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents IncompleteInvoicesReportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CompleteInvoiceReportToolStripMenuItem As ToolStripMenuItem
End Class
