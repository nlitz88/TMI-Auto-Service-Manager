Imports System.ComponentModel

Public Class home

    Private Sub home_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub home_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        backupDb()
    End Sub

End Class