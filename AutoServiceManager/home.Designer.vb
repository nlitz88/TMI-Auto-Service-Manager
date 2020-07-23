<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class home
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
        Me.mainMs = New System.Windows.Forms.MenuStrip()
        Me.HomeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewInvoiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InvoiceMaintenanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FileMaintenanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompanySetupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mainMs.SuspendLayout()
        Me.SuspendLayout()
        '
        'mainMs
        '
        Me.mainMs.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.mainMs.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HomeToolStripMenuItem, Me.NewInvoiceToolStripMenuItem, Me.InvoiceMaintenanceToolStripMenuItem, Me.FileMaintenanceToolStripMenuItem, Me.ReportsToolStripMenuItem})
        Me.mainMs.Location = New System.Drawing.Point(0, 0)
        Me.mainMs.Name = "mainMs"
        Me.mainMs.Size = New System.Drawing.Size(982, 28)
        Me.mainMs.TabIndex = 45
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
        Me.FileMaintenanceToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CompanySetupToolStripMenuItem})
        Me.FileMaintenanceToolStripMenuItem.Name = "FileMaintenanceToolStripMenuItem"
        Me.FileMaintenanceToolStripMenuItem.Size = New System.Drawing.Size(135, 24)
        Me.FileMaintenanceToolStripMenuItem.Text = "File Maintenance"
        '
        'CompanySetupToolStripMenuItem
        '
        Me.CompanySetupToolStripMenuItem.Name = "CompanySetupToolStripMenuItem"
        Me.CompanySetupToolStripMenuItem.Size = New System.Drawing.Size(197, 26)
        Me.CompanySetupToolStripMenuItem.Text = "Company Setup"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(74, 24)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'home
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(982, 753)
        Me.Controls.Add(Me.mainMs)
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Name = "home"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Home"
        Me.mainMs.ResumeLayout(False)
        Me.mainMs.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents mainMs As MenuStrip
    Friend WithEvents NewInvoiceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents InvoiceMaintenanceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FileMaintenanceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CompanySetupToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HomeToolStripMenuItem As ToolStripMenuItem
End Class
