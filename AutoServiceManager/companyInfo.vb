Public Class companyInfo

    Private Sub companyInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        companyInfoLabel.Left = (Me.ClientSize.Width / 2) - (companyInfoLabel.Width / 2) ' ????

        ' Data modification controls
        cancelButton.Hide()
        saveButton.Hide()

    End Sub

    Private Sub editButton_Click(sender As Object, e As EventArgs) Handles editButton.Click

        editButton.Hide()
        cancelButton.Show()
        saveButton.Show()

    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click

        cancelButton.Hide()
        saveButton.Hide()
        editButton.Show()

    End Sub

    Private Sub saveButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click

        Dim decision As DialogResult = MessageBox.Show("Save Changes?", "Confirm Changes", MessageBoxButtons.YesNo)

        Select Case decision
            Case DialogResult.Yes
                ' Write changes to database
                ' Switch back to labels with updated data from database (reload the form essentially)
                ' Go back to showing edit button
            Case DialogResult.No
                ' Continue making changes or cancel editing
        End Select

    End Sub

End Class