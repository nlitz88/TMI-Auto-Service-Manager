Public Class navigation
    Private Sub navigation_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Size = New Size(Me.ParentForm.ClientSize.Width, 28)
        Me.Location = New Point(0, 0)

        Me.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right

    End Sub

    Private Sub CompanySetupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompanySetupToolStripMenuItem.Click
        If Me.ParentForm Is companyInfo Then Exit Sub ' Dont change if already on this screen
        changeScreen(companyInfo, Me.ParentForm)
    End Sub

    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HomeToolStripMenuItem.Click
        If Me.ParentForm Is home Then Exit Sub
        changeScreen(home, Me.ParentForm)
    End Sub
End Class
