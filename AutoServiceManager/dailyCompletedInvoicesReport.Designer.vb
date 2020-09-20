<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dailyCompletedInvoicesReport
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
        Me.previewReportButton = New System.Windows.Forms.Button()
        Me.UnpaidInvoicesReportLabel = New System.Windows.Forms.Label()
        Me.nav = New AutoServiceManager.navigation()
        Me.ReportDateTextbox = New System.Windows.Forms.MaskedTextBox()
        Me.ReportDateLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'previewReportButton
        '
        Me.previewReportButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.previewReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.previewReportButton.ForeColor = System.Drawing.Color.White
        Me.previewReportButton.Location = New System.Drawing.Point(334, 137)
        Me.previewReportButton.Name = "previewReportButton"
        Me.previewReportButton.Size = New System.Drawing.Size(183, 30)
        Me.previewReportButton.TabIndex = 291
        Me.previewReportButton.Text = "Preview Report"
        Me.previewReportButton.UseVisualStyleBackColor = False
        '
        'UnpaidInvoicesReportLabel
        '
        Me.UnpaidInvoicesReportLabel.AutoSize = True
        Me.UnpaidInvoicesReportLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UnpaidInvoicesReportLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.UnpaidInvoicesReportLabel.Location = New System.Drawing.Point(94, 73)
        Me.UnpaidInvoicesReportLabel.Name = "UnpaidInvoicesReportLabel"
        Me.UnpaidInvoicesReportLabel.Size = New System.Drawing.Size(458, 32)
        Me.UnpaidInvoicesReportLabel.TabIndex = 290
        Me.UnpaidInvoicesReportLabel.Text = "Daily Completed Invoices Report"
        '
        'nav
        '
        Me.nav.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nav.Location = New System.Drawing.Point(0, 0)
        Me.nav.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.nav.Name = "nav"
        Me.nav.Size = New System.Drawing.Size(982, 28)
        Me.nav.TabIndex = 293
        '
        'ReportDateTextbox
        '
        Me.ReportDateTextbox.AllowPromptAsInput = False
        Me.ReportDateTextbox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.ReportDateTextbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.ReportDateTextbox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert
        Me.ReportDateTextbox.Location = New System.Drawing.Point(196, 138)
        Me.ReportDateTextbox.Mask = "00/00/0000"
        Me.ReportDateTextbox.Name = "ReportDateTextbox"
        Me.ReportDateTextbox.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.ReportDateTextbox.Size = New System.Drawing.Size(132, 27)
        Me.ReportDateTextbox.TabIndex = 294
        Me.ReportDateTextbox.Tag = "dataEditingControl"
        Me.ReportDateTextbox.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.ReportDateTextbox.ValidatingType = GetType(Date)
        '
        'ReportDateLabel
        '
        Me.ReportDateLabel.AutoSize = True
        Me.ReportDateLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ReportDateLabel.Location = New System.Drawing.Point(97, 144)
        Me.ReportDateLabel.Name = "ReportDateLabel"
        Me.ReportDateLabel.Size = New System.Drawing.Size(93, 17)
        Me.ReportDateLabel.TabIndex = 295
        Me.ReportDateLabel.Tag = "dataLabel"
        Me.ReportDateLabel.Text = "Report Date :"
        '
        'completedInvoicesReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(982, 753)
        Me.Controls.Add(Me.ReportDateTextbox)
        Me.Controls.Add(Me.ReportDateLabel)
        Me.Controls.Add(Me.nav)
        Me.Controls.Add(Me.previewReportButton)
        Me.Controls.Add(Me.UnpaidInvoicesReportLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "completedInvoicesReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Daily Completed Invoices Report"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents previewReportButton As Button
    Friend WithEvents UnpaidInvoicesReportLabel As Label
    Friend WithEvents nav As navigation
    Friend WithEvents ReportDateTextbox As MaskedTextBox
    Friend WithEvents ReportDateLabel As Label
End Class
