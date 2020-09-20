<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class unpaidInvoicesReport
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
        Me.ReportDateTextbox = New System.Windows.Forms.MaskedTextBox()
        Me.ReportDateLabel = New System.Windows.Forms.Label()
        Me.previewReportButton = New System.Windows.Forms.Button()
        Me.UnpaidInvoicesReportLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ReportDateTextbox
        '
        Me.ReportDateTextbox.AllowPromptAsInput = False
        Me.ReportDateTextbox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.ReportDateTextbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!)
        Me.ReportDateTextbox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert
        Me.ReportDateTextbox.Location = New System.Drawing.Point(269, 138)
        Me.ReportDateTextbox.Mask = "00/00/0000"
        Me.ReportDateTextbox.Name = "ReportDateTextbox"
        Me.ReportDateTextbox.PromptChar = Global.Microsoft.VisualBasic.ChrW(32)
        Me.ReportDateTextbox.Size = New System.Drawing.Size(132, 27)
        Me.ReportDateTextbox.TabIndex = 281
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
        Me.ReportDateLabel.Size = New System.Drawing.Size(166, 17)
        Me.ReportDateLabel.TabIndex = 284
        Me.ReportDateLabel.Tag = "dataLabel"
        Me.ReportDateLabel.Text = "Report in Invoices since :"
        '
        'previewReportButton
        '
        Me.previewReportButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.previewReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.previewReportButton.ForeColor = System.Drawing.Color.White
        Me.previewReportButton.Location = New System.Drawing.Point(407, 137)
        Me.previewReportButton.Name = "previewReportButton"
        Me.previewReportButton.Size = New System.Drawing.Size(183, 30)
        Me.previewReportButton.TabIndex = 283
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
        Me.UnpaidInvoicesReportLabel.Size = New System.Drawing.Size(331, 32)
        Me.UnpaidInvoicesReportLabel.TabIndex = 282
        Me.UnpaidInvoicesReportLabel.Text = "Unpaid Invoices Report"
        '
        'unpaidInvoicesReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(982, 753)
        Me.Controls.Add(Me.ReportDateTextbox)
        Me.Controls.Add(Me.ReportDateLabel)
        Me.Controls.Add(Me.previewReportButton)
        Me.Controls.Add(Me.UnpaidInvoicesReportLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "unpaidInvoicesReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Unpaid Invoices Report"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ReportDateTextbox As MaskedTextBox
    Friend WithEvents ReportDateLabel As Label
    Friend WithEvents previewReportButton As Button
    Friend WithEvents UnpaidInvoicesReportLabel As Label
End Class
