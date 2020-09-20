<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dailyReceiptsReport
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
        Me.DailyReceiptsLabel = New System.Windows.Forms.Label()
        Me.nav = New AutoServiceManager.navigation()
        Me.previewReportButton = New System.Windows.Forms.Button()
        Me.ReportDateTextbox = New System.Windows.Forms.MaskedTextBox()
        Me.WorkDate_Value = New System.Windows.Forms.Label()
        Me.ReportDateLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'DailyReceiptsLabel
        '
        Me.DailyReceiptsLabel.AutoSize = True
        Me.DailyReceiptsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DailyReceiptsLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.DailyReceiptsLabel.Location = New System.Drawing.Point(94, 73)
        Me.DailyReceiptsLabel.Name = "DailyReceiptsLabel"
        Me.DailyReceiptsLabel.Size = New System.Drawing.Size(211, 32)
        Me.DailyReceiptsLabel.TabIndex = 124
        Me.DailyReceiptsLabel.Text = "Daily Receipts"
        '
        'nav
        '
        Me.nav.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nav.Location = New System.Drawing.Point(0, 0)
        Me.nav.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.nav.Name = "nav"
        Me.nav.Size = New System.Drawing.Size(982, 28)
        Me.nav.TabIndex = 125
        '
        'previewReportButton
        '
        Me.previewReportButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.previewReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.previewReportButton.ForeColor = System.Drawing.Color.White
        Me.previewReportButton.Location = New System.Drawing.Point(334, 137)
        Me.previewReportButton.Name = "previewReportButton"
        Me.previewReportButton.Size = New System.Drawing.Size(183, 30)
        Me.previewReportButton.TabIndex = 126
        Me.previewReportButton.Text = "Preview Report"
        Me.previewReportButton.UseVisualStyleBackColor = False
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
        Me.ReportDateTextbox.TabIndex = 0
        Me.ReportDateTextbox.Tag = "dataEditingControl"
        Me.ReportDateTextbox.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals
        Me.ReportDateTextbox.ValidatingType = GetType(Date)
        '
        'WorkDate_Value
        '
        Me.WorkDate_Value.AutoSize = True
        Me.WorkDate_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WorkDate_Value.ForeColor = System.Drawing.Color.Black
        Me.WorkDate_Value.Location = New System.Drawing.Point(185, 141)
        Me.WorkDate_Value.Name = "WorkDate_Value"
        Me.WorkDate_Value.Size = New System.Drawing.Size(0, 20)
        Me.WorkDate_Value.TabIndex = 280
        Me.WorkDate_Value.Tag = "dataViewingControl"
        '
        'ReportDateLabel
        '
        Me.ReportDateLabel.AutoSize = True
        Me.ReportDateLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ReportDateLabel.Location = New System.Drawing.Point(97, 144)
        Me.ReportDateLabel.Name = "ReportDateLabel"
        Me.ReportDateLabel.Size = New System.Drawing.Size(93, 17)
        Me.ReportDateLabel.TabIndex = 279
        Me.ReportDateLabel.Tag = "dataLabel"
        Me.ReportDateLabel.Text = "Report Date :"
        '
        'dailyReceiptsReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(982, 753)
        Me.Controls.Add(Me.ReportDateTextbox)
        Me.Controls.Add(Me.WorkDate_Value)
        Me.Controls.Add(Me.ReportDateLabel)
        Me.Controls.Add(Me.previewReportButton)
        Me.Controls.Add(Me.nav)
        Me.Controls.Add(Me.DailyReceiptsLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "dailyReceiptsReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Daily Receipts"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DailyReceiptsLabel As Label
    Friend WithEvents nav As navigation
    Friend WithEvents previewReportButton As Button
    Friend WithEvents ReportDateTextbox As MaskedTextBox
    Friend WithEvents WorkDate_Value As Label
    Friend WithEvents ReportDateLabel As Label
End Class
