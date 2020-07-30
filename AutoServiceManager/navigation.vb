Public Class navigation
    Private Sub navigation_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Size = New Size(Me.ParentForm.ClientSize.Width, 28)
        Me.Location = New Point(0, 0)

        Me.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right

    End Sub


    Public Sub DisableAll()
        For Each btn In Me.Controls
            btn.Enabled = False
        Next
    End Sub

    Public Sub EnableAll()
        For Each btn In Me.Controls
            btn.Enabled = True
        Next
    End Sub


    Private Sub HomeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HomeToolStripMenuItem.Click
        If Me.ParentForm Is home Then Exit Sub
        changeScreen(home, Me.ParentForm)
    End Sub

    Private Sub CompanySetupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompanySetupToolStripMenuItem.Click
        If Me.ParentForm Is companyInfo Then Exit Sub ' Dont change if already on this screen
        changeScreen(companyInfo, Me.ParentForm)
    End Sub

    Private Sub AutomobileManufacturersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutomobileManufacturersToolStripMenuItem.Click
        If Me.ParentForm Is mfgMaintenance Then Exit Sub
        changeScreen(mfgMaintenance, Me.ParentForm)
    End Sub

    Private Sub InsuranceCompaniesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InsuranceCompaniesToolStripMenuItem.Click
        If Me.ParentForm Is insuranceMaintenance Then Exit Sub
        changeScreen(insuranceMaintenance, Me.ParentForm)
    End Sub

    Private Sub CreditCardsAcceptedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreditCardsAcceptedToolStripMenuItem.Click
        If Me.ParentForm Is creditCardMaintenance Then Exit Sub
        changeScreen(creditCardMaintenance, Me.ParentForm)
    End Sub

    Private Sub AutoColorsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutoColorsToolStripMenuItem.Click
        If Me.ParentForm Is colorMaintenance Then Exit Sub
        changeScreen(colorMaintenance, Me.ParentForm)
    End Sub

    Private Sub PaymentTypesAcceptedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PaymentTypesAcceptedToolStripMenuItem.Click
        If Me.ParentForm Is paymentMaintenance Then Exit Sub
        changeScreen(paymentMaintenance, Me.ParentForm)
    End Sub

    Private Sub TaskTypesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TaskTypesToolStripMenuItem.Click
        If Me.ParentForm Is taskMaintenance Then Exit Sub
        changeScreen(taskMaintenance, Me.ParentForm)
    End Sub

    Private Sub InventoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InventoryToolStripMenuItem.Click
        If Me.ParentForm Is inventoryMaintenance Then Exit Sub
        changeScreen(inventoryMaintenance, Me.ParentForm)
    End Sub

    Private Sub LaborCodesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaborCodesToolStripMenuItem.Click
        If Me.ParentForm Is laborCodeMaintenance Then Exit Sub
        changeScreen(laborCodeMaintenance, Me.ParentForm)
    End Sub

End Class
