Public Class loginPage
    Private Sub userIDTextbox_TextChanged(sender As Object, e As EventArgs) Handles userIDTextbox.TextChanged, passwordTextbox.TextChanged

        ' Temp validation
        If Not String.IsNullOrEmpty(userIDTextbox.Text) And Not String.IsNullOrEmpty(passwordTextbox.Text) Then
            loginButton.Enabled = True
        Else
            loginButton.Enabled = False
        End If

    End Sub

    Private Sub loginButton_Click(sender As Object, e As EventArgs) Handles loginButton.Click

        changeScreen(home, Me)

    End Sub

End Class
