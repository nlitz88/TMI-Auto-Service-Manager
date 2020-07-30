Imports System.ComponentModel

Public Class laborCodeMaintenance

    ' New Database control instances for insurance companies datatable
    Private LCDbController As New DbControl()
    ' New Database control instance for updating, inserting, and deleting
    Private CRUD As New DbControl()

    ' Initialize new lists to store certain row values of datatables (easily sorted and BINARY SEARCHED FOR SPEED)
    Private LCList As List(Of Object)

    ' Initialize instance(s) of initialValues class
    Private InitialLCValues As New InitialValues()

    'Variable to keep track of whether form fully loaded or not
    Private valuesInitialized As Boolean = True

    ' Row index variables used for DataTable lookups
    Private LCRow As Integer
    Private lastSelected As String

    ' Keeps track of whether or not user in "editing" or "adding" mode
    Private mode As String

    ' Variable that allows certain keystrokes through restricted fields
    Private allowedKeystroke As Boolean = False




    ' ***************** INITIALIZATION AND CONFIGURATION SUBS *****************


    ' Sub that will contain calls to all of the instances of the database controller class that loads data from the database into DataTables
    Private Function loadDataTablesFromDatabase() As Boolean

        LCDbController.ExecQuery("SELECT lc.Description + ' - ' + lc.LaborCode as LDLC, lc.LaborCode, lc.Description, lc.Rate, lc.Hours, lc.Amount FROM LaborCodes lc ORDER BY lc.Description ASC")
        If LCDbController.HasException() Then Return False

        ' Also, populate respective lists with data
        LCList = getListFromDataTable(LCDbController.DbDataTable, "LaborCode")
        For i As Integer = 0 To LCList.Count - 1
            LCList(i) = LCList(i).ToString().ToLower()
        Next

        Return True

    End Function


    ' Sub that initializes all dataEditingcontrols corresponding with values from the LaborCodes datatable
    Private Sub InitializeLCDataEditingControls()

        initializeControlsFromRow(LCDbController.DbDataTable, LCRow, "dataEditingControl", "_", Me)

    End Sub

    ' Sub that initializes all dataViewingControls corresponding with values from the LaborCodes datatable
    Private Sub InitializeLCDataViewingControls()


        initializeControlsFromRow(LCDbController.DbDataTable, LCRow, "dataViewingControl", "_", Me)

    End Sub


    ' Sub that calls all individual dataEditingControl initialization subs in one (These can be used individually if desired)
    Private Sub InitializeAllDataEditingControls()

        ' Automated initializations
        InitializeLCDataEditingControls()
        ' Then, format dataEditingControls
        formatDataEditingControls()
        ' Set forecolor if not already initially default
        setForeColor(getAllControlsWithTag("dataEditingControl", Me), DefaultForeColor)

    End Sub

    ' Sub that calls all individual dataEditingControl initialization subs in one (These can be used individually if desired)
    Private Sub InitializeAllDataViewingControls()

        ' Automated initializations
        InitializeLCDataViewingControls()
        ' Format dataviewingcontrols
        formatDataViewingControls()

    End Sub


    ' Sub that will call formatting functions to add respective formats to already INITIALIZED DATAVIEWINGCONTROLS (i.e. phone numbers, currency, etc.).
    Private Sub formatDataViewingControls()

        'PartPrice_Value.Text = FormatCurrency(LCDbController.DbDataTable.Rows(LCRow)("PartPrice"))
        'ListPrice_Value.Text = FormatCurrency(LCDbController.DbDataTable.Rows(LCRow)("ListPrice"))

    End Sub

    ' Sub that will call formatting functions to add respective formats to already INITIALIZED DATAEDITINGCONTROLS (i.e. phone numbers, currency, etc.).
    Private Sub formatDataEditingControls()

        'PartPrice_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(LCDbController.DbDataTable.Rows(LCRow)("PartPrice")))
        'ListPrice_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(LCDbController.DbDataTable.Rows(LCRow)("ListPrice")))

    End Sub

    ' Sub that will remove all necessary formatting taht was added (used before updating values)
    Private Sub stripDataEditingControlsFormatting()

    End Sub


    ' Function that makes updateTable calls for all relevant DataTables that need updated based on changes
    Private Function updateAll() As Boolean

        ' First, remove any formatting that was added (specific to the controls on this form)
        ' stripDataEditingControlsFormatting()

        ' Then, update all relevant tables that COUDLD have experienced changes
        Dim initialValueAsKey As String = LCDbController.DbDataTable.Rows(LCRow)("LaborCode")
        updateTable(CRUD, LCDbController.DbDataTable, "LaborCodes", initialValueAsKey, "LaborCode", "_", "dataEditingControl", Me)
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
        ' stripDataEditingControlsFormatting()

        ' Then, make calls to insertRow to all relevant tables
        insertRow(CRUD, LCDbController.DbDataTable, "LaborCodes", "_", "dataEditingControl", Me)
        ' Then, return exception status of CRUD controller. Do this after each call
        If CRUD.HasException() Then Return False

        ' Otherwise, return true
        Return True

    End Function


    ' Function that makes deleteRow calls for all relevant DataTables
    Private Function deleteAll() As Boolean

        ' Then, make calls to insertRow to all relevant tables
        Dim valueAsKey As String = LCDbController.DbDataTable.Rows(LCRow)("LaborCode")
        deleteRow(CRUD, "LaborCodes", valueAsKey, "LaborCode")
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


        ' Labor Code (KEY)(REQUIRED)(MUST BE UNIQUE)
        If Not isValidLength("Labor Code", True, LaborCode_Textbox.Text, 15, errorMessage) Then
            LaborCode_Textbox.ForeColor = Color.Red
        Else
            If mode = "editing" Then
                Dim initial As String = LCDbController.DbDataTable.Rows(LCRow)("LaborCode").ToString().ToLower()
                If LaborCode_Textbox.Text.ToLower() <> initial Then
                    If isDuplicate("Labor Code", LaborCode_Textbox.Text.ToLower(), errorMessage, LCList) Then
                        LaborCode_Textbox.ForeColor = Color.Red
                    End If
                End If
            ElseIf mode = "adding" Then
                If isDuplicate("Labor Code", LaborCode_Textbox.Text.ToLower(), errorMessage, LCList) Then
                    LaborCode_Textbox.ForeColor = Color.Red
                End If
            End If
        End If

        ' Description (REQUIRED)
        If Not isValidLength("Description", True, Description_Textbox.Text, 100, errorMessage) Then Description_Textbox.ForeColor = Color.Red

        ' Rate (REQUIRED)
        If Not validCurrency("Rate", True, Rate_Textbox.Text, errorMessage) Then Rate_Textbox.ForeColor = Color.Red

        ' Hours (REQUIRED)
        If Not isValidLength("Hours", True, Hours_Textbox.Text, 19, errorMessage) Then Hours_Textbox.ForeColor = Color.Red

        ' Amount (REQUIRED) (DOESN'T NEED VALIDATION)


        ' Check if any invalid input has been found
        If Not String.IsNullOrEmpty(errorMessage) Then

            MessageBox.Show(errorMessage, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False

        End If

        Return True

    End Function


    Private Sub laborCodeMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' TEST DATABASE CONNECTION FIRST
        If Not checkDbConn() Then
            MessageBox.Show("Failed to connect to database; Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' LOAD DATATABLES FROM DATABASE INITIALLY
        If Not loadDataTablesFromDatabase() Then
            MessageBox.Show("Failed to connect to database; Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If


        ' SETUP CONTROLS HERE
        LCComboBox.Items.Add("Select One")
        For Each row In LCDbController.DbDataTable.Rows
            LCComboBox.Items.Add(row("LDLC"))
        Next
        LCComboBox.SelectedIndex = 0

    End Sub




    ' **************** CONTROL SUBS ****************


    ' Main eventhandler that handles most of the initialization for all subsequent elements/controls.
    Private Sub LCCombobox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LCComboBox.SelectedIndexChanged, LCComboBox.TextChanged

        ' Rewrite this if structure so that these don't go first (we still need to take action if select one is selected)
        If LCComboBox.Text = "Select One" Or LCComboBox.SelectedIndex = 0 Then

            ' Have all labels and corresponding values hidden
            showHide(getAllControlsWithTag("dataViewingControl", Me), 0)
            showHide(getAllControlsWithTag("dataLabel", Me), 0)
            showHide(getAllControlsWithTag("dataEditingControl", Me), 0)
            ' Disable editing button
            editButton.Enabled = False
            deleteButton.Enabled = False

        Else

            ' Lookup LCROW to define it for the entire class and to change selected index of ComboBox
            LCRow = getDataTableRow(LCDbController.DbDataTable, "LDLC", LCComboBox.Text)
            Dim LaborCode As Object = getRowValue(LCDbController.DbDataTable, LCRow, "LaborCode")

            ' If the input in the combobox matches an entry in the table that it represents
            If LaborCode <> Nothing And LCList.BinarySearch(LaborCode.ToLower()) >= 0 Then
                ' Initialize corresponding controls from DataTable values
                valuesInitialized = False
                InitializeAllDataViewingControls()
                valuesInitialized = True

                ' Show labels and corresponding values
                showHide(getAllControlsWithTag("dataViewingControl", Me), 1)
                showHide(getAllControlsWithTag("dataLabel", Me), 1)
                showHide(getAllControlsWithTag("dataEditingControl", Me), 0)
                ' Enable editing button
                editButton.Enabled = True
                deleteButton.Enabled = True

            Else ' THIS SHOULD ONLY EVER EXECUTE IF AN ENTRY IN COMBOBOX IS NOT SELECT ONE AND NOT IN THE DATATABLE

                ' Have all labels and corresponding values hidden
                showHide(getAllControlsWithTag("dataViewingControl", Me), 0)
                showHide(getAllControlsWithTag("dataLabel", Me), 0)
                showHide(getAllControlsWithTag("dataEditingControl", Me), 0)
                ' Disable editing button
                editButton.Enabled = False
                deleteButton.Enabled = False

            End If

        End If


    End Sub


End Class