Public Class loginPage
    Private Sub userIDTextbox_TextChanged(sender As Object, e As EventArgs) Handles userIDTextbox.TextChanged, passwordTextbox.TextChanged

        ' Temp validation
        'If Not String.IsNullOrEmpty(userIDTextbox.Text) And Not String.IsNullOrEmpty(passwordTextbox.Text) Then
        '    loginButton.Enabled = True
        'Else
        '    loginButton.Enabled = False
        'End If






    End Sub

    Private Sub loginButton_Click(sender As Object, e As EventArgs) Handles loginButton.Click


        Try

            Dim UserName As String = readINI("AutoServiceManagerParams.ini", "USERNAME=")
            Dim Password As String = readINI("AutoServiceManagerParams.ini", "PASSWORD=")

            If userIDTextbox.Text <> UserName Or passwordTextbox.Text <> Password Then

                MessageBox.Show("Invalid Login. Please try again.", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub

            End If

        Catch ex As Exception

            MessageBox.Show("Unable to verify credentials. Please ensure ini file configured correctly.", "Credential Verification Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End Try


        ' CHECK DATABASE CONNECTION BEFORE PROCEEDING
        If Not checkDbConn() Then Exit Sub
        loginButton.Text = "Logging you in..."

        changeScreen(invoices, Me)

    End Sub

End Class
