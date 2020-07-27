Imports System.ComponentModel

Public Class mfgMaintenance

    ' New Database control instances for manufacturer datatable
    Private AutoManufacturersDbController As New DbControl()

    ' Initialize new lists to store certain row values of datatables (easily sorted and binary searched)
    Private AutoManufacturersList As List(Of Object)



    ' ***************** INITIALIZATION AND CONFIGURATION SUBS *****************


    ' Sub that will contain calls to all of the instances of the database controller class that loads data from the database into DataTables
    Private Function loadDataTablesFromDatabase() As Boolean

        AutoManufacturersDbController.ExecQuery("SELECT am.AutoMake FROM AutoManufacturers as am")
        If AutoManufacturersDbController.HasException() Then Return False

        ' Also, populate respective lists with data
        AutoManufacturersList = getListFromDataTable(AutoManufacturersDbController.DbDataTable, "AutoMake")

        Return True

    End Function



    Private Sub mfgMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Load datatables from database
        If Not loadDataTablesFromDatabase() Then
            MessageBox.Show("Loading unsuccessful; Please restart and try again")
            Exit Sub
        End If

        ' SETUP CONTROLS HERE
        AutoMakeComboBox.Items.Add("Select one")
        For Each row In AutoManufacturersDbController.DbDataTable.Rows
            AutoMakeComboBox.Items.Add(row("AutoMake"))
        Next
        AutoMakeComboBox.SelectedIndex = 0

    End Sub

    Private Sub mfgMaintenance_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        End
    End Sub

    Private Sub AutoMake_ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AutoMakeComboBox.SelectedIndexChanged

        Console.WriteLine("Selected Index: " & AutoMakeComboBox.SelectedIndex & " | Lookup index: " & AutoMakeComboBox.Items.IndexOf(AutoMakeComboBox.SelectedItem))

    End Sub
End Class