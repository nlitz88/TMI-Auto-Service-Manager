Imports System.ComponentModel

Public Class taskMaintenance

    ' New Database control instances for insurance companies datatable
    Private TTDbController As New DbControl()
    ' New Database control instance for updating, inserting, and deleting
    Private CRUD As New DbControl()

    ' Initialize new lists to store certain row values of datatables (easily sorted and BINARY SEARCHED FOR SPEED)
    Private TTList As List(Of Object)

    ' Initialize instance(s) of initialValues class
    Private InitialTTValues As New InitialValues()

    'Variable to keep track of whether form fully loaded or not
    Private valuesInitialized As Boolean = True

    ' Row index variables used for DataTable lookups
    Private TTRow As Integer
    Private lastSelected As String

    ' Keeps track of whether or not user in "editing" or "adding" mode
    Private mode As String




    ' ***************** INITIALIZATION AND CONFIGURATION SUBS *****************


    ' Sub that will contain calls to all of the instances of the database controller class that loads data from the database into DataTables
    Private Function loadDataTablesFromDatabase() As Boolean

        TTDbController.ExecQuery("SELECT tt.TaskType, tt.TaskDescription FROM TaskTypes tt ORDER BY tt.TaskType ASC")
        If TTDbController.HasException() Then Return False

        ' Also, populate respective lists with data
        TTList = getListFromDataTable(TTDbController.DbDataTable, "TaskType")
        For i As Integer = 0 To TTList.Count - 1
            TTList(i) = TTList(i).ToString().ToLower()
        Next

        Return True

    End Function


    ' Sub that initializes all dataEditingcontrols corresponding with values from the TaskTypes datatable
    Private Sub InitializeTTDataEditingControls()

        ' Lookup and set current TTRow index based on selectedIndex of TaskType ComboBox
        Dim escapedText As String = escapeLikeValues(TTComboBox.Text)
        Dim TTDataRow As DataRow = TTDbController.DbDataTable.Select("TaskType LIKE '" & escapedText & "'")(0)
        TTRow = TTDbController.DbDataTable.Rows.IndexOf(TTDataRow)

        initializeControlsFromRow(TTDbController.DbDataTable, TTRow, "dataEditingControl", "_", Me)

    End Sub

    ' Sub that initializes all dataViewingControls corresponding with values from the TaskTypes datatable
    Private Sub InitializeTTDataViewingControls()

        ' Lookup and set current TTRow index based on selectedIndex of TaskType ComboBox
        Dim escapedText As String = escapeLikeValues(TTComboBox.Text)   ' removes/handles escape characters that cause errors
        Dim TTDataRow As DataRow = TTDbController.DbDataTable.Select("TaskType LIKE '" & escapedText & "'")(0)
        TTRow = TTDbController.DbDataTable.Rows.IndexOf(TTDataRow)

        initializeControlsFromRow(TTDbController.DbDataTable, TTRow, "dataViewingControl", "_", Me)

    End Sub


    ' Sub that calls all individual dataEditingControl initialization subs in one (These can be used individually if desired)
    Private Sub InitializeAllDataEditingControls()

        ' Automated initializations
        InitializeTTDataEditingControls()
        ' Then, add formatting
        ' addFormatting()
        ' Set forecolor if not already initially default
        setForeColor(getAllControlsWithTag("dataEditingControl", Me), DefaultForeColor)

    End Sub

    ' Sub that calls all individual dataEditingControl initialization subs in one (These can be used individually if desired)
    Private Sub InitializeAllDataViewingControls()

        ' Automated initializations
        InitializeTTDataViewingControls()

    End Sub


    ' Function that makes updateTable calls for all relevant DataTables that need updated based on changes
    Private Function updateAll() As Boolean

        ' First, remove any formatting that was added (specific to the controls on this form)
        'stripFormatting()

        ' Then, update all relevant tables that COUDLD have experienced changes
        Dim initialValueAsKey As String = TTDbController.DbDataTable.Rows(TTRow)("TaskType")
        updateTable(CRUD, TTDbController.DbDataTable, "TaskTypes", initialValueAsKey, "TaskType", "_", "dataEditingControl", Me)
        ' I could use a simple, standalone sql query here, as it would allow me to freely change the updateTable overloads in globals.vb.
        ' For now, though, I will try to implement these wherever I can for uniformity/consistency

        ' Then, return exception status of CRUD controller. Do this after each call
        If CRUD.HasException() Then Return False

        ' Otherwise, return true
        Return True

    End Function


    ' Function that makes insertRow calls for all relevant DataTables
    Private Function insertAll() As Boolean

        ' First, remove any formatting that was added (specific to the controls on this form)
        'stripFormatting()

        ' Then, make calls to insertRow to all relevant tables
        insertRow(CRUD, TTDbController.DbDataTable, "TaskTypes", "_", "dataEditingControl", Me)
        ' Then, return exception status of CRUD controller. Do this after each call
        If CRUD.HasException() Then Return False

        ' Otherwise, return true
        Return True

    End Function


    ' Function that makes deleteRow calls for all relevant DataTables
    Private Function deleteAll() As Boolean

        ' Then, make calls to insertRow to all relevant tables
        Dim valueAsKey As String = TTDbController.DbDataTable.Rows(TTRow)("TaskType")
        deleteRow(CRUD, "TaskTypes", valueAsKey, "TaskType")
        ' Then, return exception status of CRUD controller. Do this after each call
        If CRUD.HasException() Then Return False

        ' Otherwise, return true
        Return True

    End Function




    ' **************** VALIDATION SUBS ****************


    ' Sub that runs validation for all form controls. Also handles error reporting
    Private Function controlsValid() As Boolean

        Dim errorMessage As String = String.Empty

        ' Use "Required" parameter to control whether or not a Null string value will cause an error to be reported


        ' Task Type Symbol (REQUIRED)(MUST BE UNIQUE)
        If isEmpty("Task Type Symbol", True, TaskType_Textbox.Text, errorMessage) Then
            TaskType_Textbox.ForeColor = Color.Red
        ElseIf isDuplicate("Payment Type Symbol", TaskType_Textbox.Text.ToLower(), errorMessage, TTList) Then
            TaskType_Textbox.ForeColor = Color.Red
        End If


        ' Check if any invalid input has been found
        If Not String.IsNullOrEmpty(errorMessage) Then

            MessageBox.Show(errorMessage, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False

        End If

        Return True

    End Function


    Private Sub taskMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load



    End Sub

    Private Sub taskMaintenance_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        End
    End Sub

End Class