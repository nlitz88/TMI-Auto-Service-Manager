﻿Public Class customerMaintenance

    ' New Database control instances for Customers and ZipCodes datatable
    Private CustomerDbController As New DbControl()
    Private ZipCodesDbController As New DbControl()
    ' New Database control instance for updating, inserting, and deleting
    Private CRUD As New DbControl()

    ' Initialize new lists to store certain row values of datatables (easily sorted and BINARY SEARCHED FOR SPEED)
    Private CustomerList As List(Of Object)
    Private zipCodesList As List(Of Object)

    ' Initialize instance(s) of initialValues class
    Private InitialCustomerValues As New InitialValues()

    'Variable to keep track of whether form fully loaded or not
    Private valuesInitialized As Boolean = True

    ' Row index variables used for DataTable lookups
    Private CustomerRow As Integer
    Private zcRow As Integer
    Private lastSelected As String

    ' Keeps track of whether or not user in "editing" or "adding" mode
    Private mode As String

    ' Variable that allows certain keystrokes through restricted fields
    Private allowedKeystroke As Boolean = False




    ' ***************** INITIALIZATION AND CONFIGURATION SUBS *****************


    ' Sub that will contain calls to all of the instances of the database controller class that loads data from the database into DataTables
    Private Function loadDataTablesFromDatabase() As Boolean

        CustomerDbController.ExecQuery("SELECT c.LastName + ', ' + c.FirstName as CLF, " &
            "c.CustomerId, c.FirstName, c.LastName, c.Address, c.City, c.State, c.ZipCode, c.HomePhone, c.WorkPhone, c.CellPhone1, c.CellPhone2, c.TaxExempt, c.EmailAddress " &
            "FROM Customer c " &
            "WHERE c.LastName IS NOT NULL AND c.FirstName IS NOT NULL " &
            "ORDER BY c.LastName ASC")
        If CustomerDbController.HasException() Then Return False

        ZipCodesDbController.ExecQuery("Select zc.Zipcode, zc.city as City, zc.State from ZipCodes zc")
        If ZipCodesDbController.HasException() Then Return False

        ' Also, populate respective lists with data
        zipCodesList = getListFromDataTable(ZipCodesDbController.DbDataTable, "Zipcode")

        Return True

    End Function


    ' Sub that initializes all dataEditingcontrols corresponding with values from the Customer datatable
    Private Sub InitializeCustomerDataEditingControls()

        initializeControlsFromRow(CustomerDbController.DbDataTable, CustomerRow, "dataEditingControl", "_", Me)

    End Sub

    ' Sub that initializes all dataViewingControls corresponding with values from the Customer datatable
    Private Sub InitializeCustomerDataViewingControls()


        initializeControlsFromRow(CustomerDbController.DbDataTable, CustomerRow, "dataViewingControl", "_", Me)

    End Sub

    ' Sub that initializes Customer ComboBox
    Private Sub InitializeCustomerComboBox()

        CustomerComboBox.Items.Clear()
        CustomerComboBox.BeginUpdate()
        CustomerComboBox.Items.Add("Select One")
        For Each row In CustomerDbController.DbDataTable.Rows
            If row("LastName") <> "" Then CustomerComboBox.Items.Add(row("CLF"))
        Next
        CustomerComboBox.EndUpdate()

    End Sub


    ' Sub that initializes the DataEditingControls corresponding with the values from the ZipCodes datatable
    Private Sub InitializeZipCodeDataEditingControls()
        ' Because city and state (dependent on zip) are stored in customer table, we don't need to initialize any dataViewingControls based on Zip.

        Try

            Dim ZipCode As String = ZipCode_ComboBox.Text
            Dim ZipCodeRows() As DataRow = ZipCodesDbController.DbDataTable.Select("Zipcode = '" & ZipCode & "'")

            If ZipCodeRows.Count = 0 Then Exit Sub     ' If not found, exit
            ' Otherwise, get row number that corresponds with that value from that row
            zcRow = ZipCodesDbController.DbDataTable.Rows.IndexOf(ZipCodeRows(0))

            initializeControlsFromRow(ZipCodesDbController.DbDataTable, zcRow, "dataEditingControl", "_", Me)

        Catch ex As Exception

        End Try


    End Sub

    ' Sub that initializes the DataEditingControls corresponding with the values from the ZipCodes datatable
    Private Sub InitializeZipCodeDataViewingControls()
        ' Because city and state (dependent on zip) are stored in customer table, we don't need to initialize any dataViewingControls based on Zip.

        Try

            Dim ZipCode As String = ZipCode_Value.Text
            Dim ZipCodeRows() As DataRow = ZipCodesDbController.DbDataTable.Select("Zipcode = '" & ZipCode & "'")

            If ZipCodeRows.Count = 0 Then Exit Sub     ' If not found, exit
            ' Otherwise, get row number that corresponds with that value from that row
            zcRow = ZipCodesDbController.DbDataTable.Rows.IndexOf(ZipCodeRows(0))

            initializeControlsFromRow(ZipCodesDbController.DbDataTable, zcRow, "dataViewingControl", "_", Me)

        Catch ex As Exception

        End Try


    End Sub

    ' Sub that initializes ZipCode combobox
    Private Sub InitializeZipCodeComboBox()

        ZipCode_ComboBox.Items.Clear()
        ZipCode_ComboBox.BeginUpdate()
        ' If mode = "adding" Then ZipCode_ComboBox.Items.Add("Select One")
        For Each row In ZipCodesDbController.DbDataTable.Rows
            ZipCode_ComboBox.Items.Add(row("Zipcode"))
        Next
        ZipCode_ComboBox.EndUpdate()

    End Sub


    ' Sub that calls all individual dataEditingControl initialization subs in one (These can be used individually if desired)
    Private Sub InitializeAllDataEditingControls()

        ' Initialize ZipCode ComboBox (this way, it's value can be assigned properly)
        InitializeZipCodeComboBox()
        ' Automated initializations
        InitializeCustomerDataEditingControls()
        ' Initialization of Editing controls dependent on zip code
        InitializeZipCodeDataEditingControls()
        ' Set forecolor if not already initially default
        setForeColor(getAllControlsWithTag("dataEditingControl", Me), DefaultForeColor)

    End Sub

    ' Sub that calls all individual dataEditingControl initialization subs in one (These can be used individually if desired)
    Private Sub InitializeAllDataViewingControls()

        ' Automated initializations
        InitializeCustomerDataViewingControls()
        ' Initialization of viewing controls dependent on zip code
        InitializeZipCodeDataViewingControls()

    End Sub


    '' ADD FORMATTING FUNCTIONS HERE, THEN IMPLEMENT THEM INTO THE INITIALIZATION FUNCTIONS
    '' ADD FORMAT STRIPPING FUNCTIONS HERE IF NECESSARRY (Don't think so)


    ' Function that makes updateTable calls for all relevant DataTables that need updated based on changes
    Private Function updateAll() As Boolean

        ' Lookup CustomerId (primary key) based on selected CLF in ComboBox
        Dim customerId As Integer = CustomerDbController.DbDataTable.Rows(CustomerRow)("CustomerId")
        ' Using CustomerID as key, update customer row
        updateTable(CRUD, CustomerDbController.DbDataTable, "Customer", customerId, "CustomerId", "_", "dataEditingControl", Me)
        ' Then, return exception status of CRUD controller. Do this after each call
        If CRUD.HasException() Then Return False

        ' Otherwise, return true
        Return True

    End Function


    ' Function that makes insertRow calls for all relevant DataTables
    Private Function insertAll() As Boolean

        ' Then, make calls to insertRow to all relevant tables
        insertRow(CRUD, CustomerDbController.DbDataTable, "Customer", "_", "dataEditingControl", Me)
        ' Then, return exception status of CRUD controller. Do this after each call
        If CRUD.HasException() Then Return False

        ' Otherwise, return true
        Return True

    End Function


    ' Function that makes deleteRow calls for all relevant DataTables
    Private Function deleteAll() As Boolean

        ' Lookup CustomerId (primary key) based on selected CLF in ComboBox
        Dim customerId As Integer = CustomerDbController.DbDataTable.Rows(CustomerRow)("CustomerId")
        deleteRow(CRUD, "Customer", customerId, "CustomerId")
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


        '' Part Number (KEY)(REQUIRED)(MUST BE UNIQUE)
        'If Not isValidLength("Part Number", True, PartNbr_Textbox.Text, 30, errorMessage) Then
        '    PartNbr_Textbox.ForeColor = Color.Red
        'Else
        '    If mode = "editing" Then
        '        Dim initial As String = IPDbController.DbDataTable.Rows(IPRow)("PartNbr").ToString().ToLower()
        '        If PartNbr_Textbox.Text.ToLower() <> initial Then
        '            If isDuplicate("Part Number", PartNbr_Textbox.Text.ToLower(), errorMessage, IPList) Then
        '                PartNbr_Textbox.ForeColor = Color.Red
        '            End If
        '        End If
        '    ElseIf mode = "adding" Then
        '        If isDuplicate("Part Number", PartNbr_Textbox.Text.ToLower(), errorMessage, IPList) Then
        '            PartNbr_Textbox.ForeColor = Color.Red
        '        End If
        '    End If
        'End If

        '' Part Description (REQUIRED)
        'If Not isValidLength("Part Description", True, PartDescription_Textbox.Text, 50, errorMessage) Then
        '    PartDescription_Textbox.ForeColor = Color.Red
        'End If

        '' Part Price (REQUIRED)
        'If Not validCurrency("Part Price", True, PartPrice_Textbox.Text, errorMessage) Then PartPrice_Textbox.ForeColor = Color.Red

        '' Part List Price (REQUIRED)
        'If Not validCurrency("List Price", True, ListPrice_Textbox.Text, errorMessage) Then ListPrice_Textbox.ForeColor = Color.Red


        ' Check if any invalid input has been found
        If Not String.IsNullOrEmpty(errorMessage) Then

            MessageBox.Show(errorMessage, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False

        End If

        Return True

    End Function


    Private Sub customerMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

        InitializeCustomerComboBox()
        CustomerComboBox.SelectedIndex = 0

    End Sub




    ' **************** CONTROL SUBS ****************


    Private Sub CustomerComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CustomerComboBox.SelectedIndexChanged, CustomerComboBox.TextChanged

        ' First, Lookup newly changed value in respective dataTable to see if the selected value exists And Is valid
        CustomerRow = getDataTableRow(CustomerDbController.DbDataTable, "CLF", CustomerComboBox.Text)

        If CustomerRow <> -1 Then

            ' Initialize corresponding controls from DataTable values
            valuesInitialized = False
            InitializeAllDataViewingControls()
            valuesInitialized = True

            ' Show labels and corresponding values
            showHide(getAllControlsWithTag("dataViewingControl", Me), 1)
            showHide(getAllControlsWithTag("dataLabel", Me), 1)
            showHide(getAllControlsWithTag("dataEditingControl", Me), 0)

            ' Enable editing and deleting button
            editButton.Enabled = True
            deleteButton.Enabled = True

            'If it does = -1, that means that value Is either "Select one" Or some other anomoly
        Else

            ' Have all labels and corresponding values hidden
            showHide(getAllControlsWithTag("dataViewingControl", Me), 0)
            showHide(getAllControlsWithTag("dataLabel", Me), 0)
            showHide(getAllControlsWithTag("dataEditingControl", Me), 0)
            ' Disable editing button
            editButton.Enabled = False
            deleteButton.Enabled = False

        End If

    End Sub


    Private Sub addButton_Click(sender As Object, e As EventArgs) Handles addButton.Click

        mode = "adding"

        ' Initialize values for dataEditingControls
        clearControls(getAllControlsWithTag("dataEditingControl", Me))
        ' Establish initial values. Doing this here, as unless changes are about to be made, we don't need to set initial values
        InitialCustomerValues.SetInitialValues(getAllControlsWithTag("dataEditingControl", Me))

        ' First, disable editButton, addButton, enable cancelButton, and disable nav
        editButton.Enabled = False
        addButton.Enabled = False
        cancelButton.Enabled = True
        nav.DisableAll()
        CustomerComboBox.Enabled = False

        ' Set ComboBox to "Select One"
        lastSelected = CustomerComboBox.Text
        CustomerComboBox.SelectedIndex = 0

        ' Set CustomerId to ID of new entry (this value will not actually be used, but it's based on the number of rows currently in the table)
        ' Lookup ID of last user in table in database. Can't use datatable here, as it's already sorted
        CRUD.ExecQuery("SELECT CustomerId FROM Customer WHERE CustomerId=(SELECT max(CustomerId) FROM Customer)")
        CustomerId_Textbox.Text = (CRUD.DbDataTable.Rows(0)("CustomerId") + 1).ToString()

        ' Hide/Show the dataViewingControls and dataEditingControls, respectively
        showHide(getAllControlsWithTag("dataViewingControl", Me), 0)
        showHide(getAllControlsWithTag("dataEditingControl", Me), 1)
        showHide(getAllControlsWithTag("dataLabel", Me), 1)

    End Sub


    Private Sub deleteButton_Click(sender As Object, e As EventArgs) Handles deleteButton.Click

        Dim decision As DialogResult = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        Select Case decision
            Case DialogResult.Yes

                ' 1.) Delete value from database
                If Not deleteAll() Then
                    MessageBox.Show("Delete unsuccessful; Changes not saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show("Successfully deleted " & CustomerComboBox.Text & " from Customers")
                End If

                ' 2.) RELOAD DATATABLES FROM DATABASE
                If Not loadDataTablesFromDatabase() Then
                    MessageBox.Show("Loading updated information failed; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                ' 3.) REINITIALIZE CONTROLS (Based on the selected index)
                InitializeCustomerComboBox()
                CustomerComboBox.SelectedIndex = 0

                ' 4.) RESTORE USER CONTROLS TO NON-EDITING/SELECTING STATE
                CustomerComboBox.Enabled = True
                addButton.Enabled = True
                cancelButton.Enabled = False
                saveButton.Enabled = False
                nav.EnableAll()
                ' Show/Hide the dataViewingControls and dataEditingControls, respectively
                ' This will be done by changing the selectedIndex to 0. May have to fire event here manually.

            Case DialogResult.No

        End Select

    End Sub


    Private Sub editButton_Click(sender As Object, e As EventArgs) Handles editButton.Click

        mode = "editing"

        ' Initialize values for dataEditingControls
        InitializeAllDataEditingControls()
        ' Establish initial values. Doing this here, as unless changes are about to be made, we don't need to set initial values
        InitialCustomerValues.SetInitialValues(getAllControlsWithTag("dataEditingControl", Me))

        ' Store the last selected item in the ComboBox (in case update fails and it must revert)
        lastSelected = CustomerComboBox.Text

        ' Disable editButton, disable addButton, enable cancel button, disable navigation, and disable main selection combobox
        editButton.Enabled = False
        addButton.Enabled = False
        cancelButton.Enabled = True
        nav.DisableAll()
        CustomerComboBox.Enabled = False

        ' Hide/Show the dataViewingControls and dataEditingControls, respectively
        showHide(getAllControlsWithTag("dataViewingControl", Me), 0)
        showHide(getAllControlsWithTag("dataEditingControl", Me), 1)

    End Sub


    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click

        ' Check for changes before cancelling. Don't need function here that calls all, as only working with one datatable's values
        If InitialCustomerValues.CtrlValuesChanged() Then

            Dim decision As DialogResult = MessageBox.Show("Cancel without saving changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            ' If changes have been made, and the user selected that they don't want to cancel, then exit here.
            If decision = DialogResult.No Then Exit Sub

        End If

        ' Otherwise, continue cancelling
        If mode = "editing" Then

            ' RESTORE USER CONTROLS TO NON-EDITING STATE
            editButton.Enabled = True
            addButton.Enabled = True
            cancelButton.Enabled = False
            saveButton.Enabled = False
            nav.EnableAll()
            CustomerComboBox.Enabled = True

            ' Show/Hide the dataViewingControls and dataEditingControls, respectively
            showHide(getAllControlsWithTag("dataViewingControl", Me), 1)
            showHide(getAllControlsWithTag("dataEditingControl", Me), 0)

        ElseIf mode = "adding" Then

            ' 1.) SET PartComboBox BACKK TO LAST SELECTED ITEM/INDEX
            CustomerComboBox.SelectedIndex = CustomerComboBox.Items.IndexOf(lastSelected)

            ' 2.) IF LAST SELECTED WAS "SELECT ONE", Then simulate functionality from combobox text/selectedIndex changed
            If lastSelected = "Select One" Then
                CustomerComboBox_SelectedIndexChanged(CustomerComboBox, New EventArgs())
            End If

            ' 3.) RESTORE USER CONTROLS TO NON-ADDING STATE (only those that are controlled by "adding")
            CustomerComboBox.Enabled = True
            addButton.Enabled = True
            cancelButton.Enabled = False
            saveButton.Enabled = False
            nav.EnableAll()

        End If

    End Sub


End Class