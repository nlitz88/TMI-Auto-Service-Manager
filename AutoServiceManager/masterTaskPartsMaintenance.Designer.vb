<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class masterTaskPartsMaintenance
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
        Me.masterTaskPartsMaintenanceLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'masterTaskPartsMaintenanceLabel
        '
        Me.masterTaskPartsMaintenanceLabel.AutoSize = True
        Me.masterTaskPartsMaintenanceLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.masterTaskPartsMaintenanceLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.masterTaskPartsMaintenanceLabel.Location = New System.Drawing.Point(94, 73)
        Me.masterTaskPartsMaintenanceLabel.Name = "masterTaskPartsMaintenanceLabel"
        Me.masterTaskPartsMaintenanceLabel.Size = New System.Drawing.Size(0, 32)
        Me.masterTaskPartsMaintenanceLabel.TabIndex = 130
        '
        'masterTaskPartsMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(982, 753)
        Me.Controls.Add(Me.masterTaskPartsMaintenanceLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "masterTaskPartsMaintenance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Task Parts"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents masterTaskPartsMaintenanceLabel As Label
End Class
