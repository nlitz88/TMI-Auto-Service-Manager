Imports System.ComponentModel

Public Class home

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' Add event handler for when the application exits.
        ' However, must first check if this event has already been handled using global flag.
        If Not ApplicationExitHandled Then
            AddHandler Application.ApplicationExit, AddressOf OnApplicationExit
            ApplicationExitHandled = True
        End If

    End Sub

    Private Sub home_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub OnApplicationExit(ByVal sender As Object, ByVal e As EventArgs)

        ' Before the application closes, backup current database and prune existing backups
        backupDb()

    End Sub

End Class