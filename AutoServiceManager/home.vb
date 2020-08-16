Imports System.ComponentModel

Public Class home

    Private Sub home_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Add event handler for when the application exits.
        AddHandler Application.ApplicationExit, AddressOf OnApplicationExit

    End Sub


    Private Sub OnApplicationExit(ByVal sender As Object, ByVal e As EventArgs)

        ' Before the application closes, backup current database and prune existing backups
        backupDb()

    End Sub

End Class