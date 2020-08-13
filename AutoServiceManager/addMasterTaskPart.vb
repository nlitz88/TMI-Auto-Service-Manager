Public Class addMasterTaskPart



    Private Sub addMasterTaskPart_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub newPartButton_Click(sender As Object, e As EventArgs) Handles newPartButton.Click

        previousScreen = Me
        changeScreen(inventoryMaintenance, Me)

    End Sub


End Class