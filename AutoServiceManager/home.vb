Imports System.ComponentModel

Public Class home




    ' ************************ MENU STRIP ************************


    Private Sub CompanySetupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompanySetupToolStripMenuItem.Click
        changeScreen(companyInfo, Me)
        ' alternative:
        '   
    End Sub

    Private Sub home_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        End
    End Sub

End Class