<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class loginPage
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
        Me.userIDLabel = New System.Windows.Forms.Label()
        Me.passwordLabel = New System.Windows.Forms.Label()
        Me.userIDTextbox = New System.Windows.Forms.TextBox()
        Me.passwordTextbox = New System.Windows.Forms.TextBox()
        Me.programInfoLabel = New System.Windows.Forms.Label()
        Me.loginButton = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'userIDLabel
        '
        Me.userIDLabel.AutoSize = True
        Me.userIDLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.userIDLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.userIDLabel.Location = New System.Drawing.Point(600, 161)
        Me.userIDLabel.Name = "userIDLabel"
        Me.userIDLabel.Size = New System.Drawing.Size(77, 20)
        Me.userIDLabel.TabIndex = 0
        Me.userIDLabel.Text = "USER ID"
        '
        'passwordLabel
        '
        Me.passwordLabel.AutoSize = True
        Me.passwordLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.passwordLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.passwordLabel.Location = New System.Drawing.Point(600, 225)
        Me.passwordLabel.Name = "passwordLabel"
        Me.passwordLabel.Size = New System.Drawing.Size(107, 20)
        Me.passwordLabel.TabIndex = 1
        Me.passwordLabel.Text = "PASSWORD"
        '
        'userIDTextbox
        '
        Me.userIDTextbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.userIDTextbox.Location = New System.Drawing.Point(603, 184)
        Me.userIDTextbox.Name = "userIDTextbox"
        Me.userIDTextbox.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.userIDTextbox.Size = New System.Drawing.Size(250, 27)
        Me.userIDTextbox.TabIndex = 2
        '
        'passwordTextbox
        '
        Me.passwordTextbox.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.passwordTextbox.Location = New System.Drawing.Point(604, 248)
        Me.passwordTextbox.Name = "passwordTextbox"
        Me.passwordTextbox.Size = New System.Drawing.Size(249, 27)
        Me.passwordTextbox.TabIndex = 3
        Me.passwordTextbox.UseSystemPasswordChar = True
        '
        'programInfoLabel
        '
        Me.programInfoLabel.AutoSize = True
        Me.programInfoLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.programInfoLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.programInfoLabel.Location = New System.Drawing.Point(95, 496)
        Me.programInfoLabel.Name = "programInfoLabel"
        Me.programInfoLabel.Size = New System.Drawing.Size(302, 17)
        Me.programInfoLabel.TabIndex = 4
        Me.programInfoLabel.Text = "Auto Service Manager by TMI Consulting"
        '
        'loginButton
        '
        Me.loginButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(138, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.loginButton.Enabled = False
        Me.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.loginButton.ForeColor = System.Drawing.Color.White
        Me.loginButton.Location = New System.Drawing.Point(604, 291)
        Me.loginButton.Name = "loginButton"
        Me.loginButton.Size = New System.Drawing.Size(249, 33)
        Me.loginButton.TabIndex = 5
        Me.loginButton.Text = "LOGIN"
        Me.loginButton.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.AutoServiceManager.My.Resources.Resources.SchweikarthsLogo
        Me.PictureBox1.Location = New System.Drawing.Point(98, 99)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(360, 301)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'loginPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(982, 553)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.loginButton)
        Me.Controls.Add(Me.programInfoLabel)
        Me.Controls.Add(Me.passwordTextbox)
        Me.Controls.Add(Me.userIDTextbox)
        Me.Controls.Add(Me.passwordLabel)
        Me.Controls.Add(Me.userIDLabel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "loginPage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents userIDLabel As Label
    Friend WithEvents passwordLabel As Label
    Friend WithEvents userIDTextbox As TextBox
    Friend WithEvents passwordTextbox As TextBox
    Friend WithEvents programInfoLabel As Label
    Friend WithEvents loginButton As Button
    Friend WithEvents PictureBox1 As PictureBox
End Class
