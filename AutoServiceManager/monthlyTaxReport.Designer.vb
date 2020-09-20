<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class monthlyTaxReport
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
        Me.MonthLabel = New System.Windows.Forms.Label()
        Me.previewReportButton = New System.Windows.Forms.Button()
        Me.UnpaidInvoicesReportLabel = New System.Windows.Forms.Label()
        Me.makeYear_Value = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.YearTextbox = New System.Windows.Forms.TextBox()
        Me.MonthTextbox = New System.Windows.Forms.TextBox()
        Me.nav = New AutoServiceManager.navigation()
        Me.SuspendLayout()
        '
        'MonthLabel
        '
        Me.MonthLabel.AutoSize = True
        Me.MonthLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.MonthLabel.Location = New System.Drawing.Point(97, 144)
        Me.MonthLabel.Name = "MonthLabel"
        Me.MonthLabel.Size = New System.Drawing.Size(55, 17)
        Me.MonthLabel.TabIndex = 299
        Me.MonthLabel.Tag = ""
        Me.MonthLabel.Text = "Month :"
        '
        'previewReportButton
        '
        Me.previewReportButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.previewReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.previewReportButton.ForeColor = System.Drawing.Color.White
        Me.previewReportButton.Location = New System.Drawing.Point(364, 137)
        Me.previewReportButton.Name = "previewReportButton"
        Me.previewReportButton.Size = New System.Drawing.Size(183, 30)
        Me.previewReportButton.TabIndex = 2
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
        Me.UnpaidInvoicesReportLabel.Size = New System.Drawing.Size(262, 32)
        Me.UnpaidInvoicesReportLabel.TabIndex = 296
        Me.UnpaidInvoicesReportLabel.Text = "Montly Tax Report"
        '
        'makeYear_Value
        '
        Me.makeYear_Value.AutoSize = True
        Me.makeYear_Value.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.makeYear_Value.ForeColor = System.Drawing.Color.Black
        Me.makeYear_Value.Location = New System.Drawing.Point(266, 141)
        Me.makeYear_Value.Name = "makeYear_Value"
        Me.makeYear_Value.Size = New System.Drawing.Size(0, 20)
        Me.makeYear_Value.TabIndex = 303
        Me.makeYear_Value.Tag = "dataViewingControl"
        Me.makeYear_Value.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(214, 144)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 17)
        Me.Label1.TabIndex = 302
        Me.Label1.Tag = ""
        Me.Label1.Text = "Year :"
        '
        'YearTextbox
        '
        Me.YearTextbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.YearTextbox.Location = New System.Drawing.Point(266, 138)
        Me.YearTextbox.MaxLength = 14
        Me.YearTextbox.Name = "YearTextbox"
        Me.YearTextbox.Size = New System.Drawing.Size(92, 27)
        Me.YearTextbox.TabIndex = 1
        Me.YearTextbox.Tag = "dataEditingControl"
        '
        'MonthTextbox
        '
        Me.MonthTextbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MonthTextbox.Location = New System.Drawing.Point(158, 138)
        Me.MonthTextbox.MaxLength = 2
        Me.MonthTextbox.Name = "MonthTextbox"
        Me.MonthTextbox.Size = New System.Drawing.Size(50, 27)
        Me.MonthTextbox.TabIndex = 0
        Me.MonthTextbox.Tag = "dataEditingControl"
        '
        'nav
        '
        Me.nav.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.nav.Location = New System.Drawing.Point(0, 0)
        Me.nav.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.nav.Name = "nav"
        Me.nav.Size = New System.Drawing.Size(982, 28)
        Me.nav.TabIndex = 304
        '
        'monthlyTaxReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(982, 753)
        Me.Controls.Add(Me.nav)
        Me.Controls.Add(Me.MonthTextbox)
        Me.Controls.Add(Me.makeYear_Value)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.YearTextbox)
        Me.Controls.Add(Me.MonthLabel)
        Me.Controls.Add(Me.previewReportButton)
        Me.Controls.Add(Me.UnpaidInvoicesReportLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "monthlyTaxReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Montly Tax Report"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MonthLabel As Label
    Friend WithEvents previewReportButton As Button
    Friend WithEvents UnpaidInvoicesReportLabel As Label
    Friend WithEvents makeYear_Value As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents YearTextbox As TextBox
    Friend WithEvents MonthTextbox As TextBox
    Friend WithEvents nav As navigation
End Class
