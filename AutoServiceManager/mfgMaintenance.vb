Imports System.ComponentModel

Public Class mfgMaintenance

    ' New Database control instances for manufacturer datatable
    Private AutoManufacturersDbController As New DbControl()

    ' Initialize new lists to store certain row values of datatables (easily sorted and BINARY SEARCHED FOR SPEED)
    Private AutoManufacturersList As List(Of Object)

    ' Initialize instance(s) of initialValues class
    Private InitialValues As New InitialValues()

    'Variable to keep track of whether form fully loaded or not
    Private valuesInitialized As Boolean = False

    ' Row index variables used for DataTable lookups
    Private amRow As Integer


    ' ***************** INITIALIZATION AND CONFIGURATION SUBS *****************


    ' Sub that will contain calls to all of the instances of the database controller class that loads data from the database into DataTables
    Private Function loadDataTablesFromDatabase() As Boolean

        AutoManufacturersDbController.ExecQuery("SELECT am.AutoMake FROM AutoManufacturers as am")
        If AutoManufacturersDbController.HasException() Then Return False

        ' Also, populate respective lists with data
        AutoManufacturersList = getListFromDataTable(AutoManufacturersDbController.DbDataTable, "AutoMake")
        For i As Integer = 0 To AutoManufacturersList.Count - 1
            AutoManufacturersList(i) = AutoManufacturersList(i).ToString().ToLower()
        Next

        Return True

    End Function


    ' Sub that initializes all controls corresponding with values from the automanufacturer datatable
    Private Sub InitializeAutoManufacturersControls()

        ' Lookup and set current amRow index based on selectedIndex of AutoMake ComboBox
        Dim amDataRow As DataRow = AutoManufacturersDbController.DbDataTable.Select("AutoMake = '" & AutoMakeComboBox.Text & "'")(0)
        amRow = AutoManufacturersDbController.DbDataTable.Rows.IndexOf(amDataRow)

        initializeControlsFromRow(AutoManufacturersDbController.DbDataTable, amRow, "_", Me)

    End Sub




    Private Sub mfgMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' LOAD DATATABLES FROM DATABASE INITIALLY
        If Not loadDataTablesFromDatabase() Then
            MessageBox.Show("Loading unsuccessful; Please restart and try again")
            Exit Sub
        End If


        ' ONE-TIME CONTROL SETUP HERE
        'AutoMakeComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        AutoMakeComboBox.Items.Add("Select One")
        For Each row In AutoManufacturersDbController.DbDataTable.Rows
            AutoMakeComboBox.Items.Add(row("AutoMake"))
        Next
        AutoMakeComboBox.SelectedIndex = 0


        ' THIS STUFF DOESN'T HAPPEN UNTIL USER SELECTS AN ENTRY FROM THE COMBOBOX
        '' INITIALIZE + FORMAT CONTROL VALUES
        'valuesInitialized = False

        '' Initialize All Control Values (in this case, just one function)


        '' store initial control values
        'InitialValues.SetInitialValues(getAllControlsWithTag("dataEditingControl", Me))

        'valuesInitialized = True

    End Sub

    Private Sub mfgMaintenance_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        End
    End Sub

    Private Sub AutoMake_ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AutoMakeComboBox.SelectedIndexChanged, AutoMakeComboBox.TextChanged

        Dim input As String = AutoMakeComboBox.Text.ToLower()

        If AutoManufacturersList.BinarySearch(input) > 0 Then

            ' Initialize corresponding controls from DataTable values
            InitializeAutoManufacturersControls()

            ' Show labels and corresponding values
            showHide(getAllControlsWithTag("dataViewingControl", Me), 1)
            showHide(getAllControlsWithTag("dataLabel", Me), 1)
            ' Enable editing button
            editButton.Enabled = True

        Else

            ' Have all labels and corresponding values hidden
            showHide(getAllControlsWithTag("dataViewingControl", Me), 0)
            showHide(getAllControlsWithTag("dataLabel", Me), 0)
            ' Disable editing button
            editButton.Enabled = False

        End If

    End Sub
End Class