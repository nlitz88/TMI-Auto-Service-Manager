﻿Imports System.ComponentModel

Public Class paymentMaintenance

    ' New Database control instances for insurance companies datatable
    Private PTDbController As New DbControl()
    ' New Database control instance for updating, inserting, and deleting
    Private CRUD As New DbControl()

    ' Initialize new lists to store certain row values of datatables (easily sorted and BINARY SEARCHED FOR SPEED)
    Private PTList As List(Of Object)

    ' Initialize instance(s) of initialValues class
    Private InitialPTValues As New InitialValues()

    'Variable to keep track of whether form fully loaded or not
    Private valuesInitialized As Boolean = True

    ' Row index variables used for DataTable lookups
    Private PTRow As Integer
    Private lastSelected As String

    ' Keeps track of whether or not user in "editing" or "adding" mode
    Private mode As String




    ' ***************** INITIALIZATION AND CONFIGURATION SUBS *****************


    ' Sub that will contain calls to all of the instances of the database controller class that loads data from the database into DataTables
    Private Function loadDataTablesFromDatabase() As Boolean

        PTDbController.ExecQuery("SELECT pt.PaymentType FROM PaymentTypes pt ORDER BY pt.PaymentType ASC")
        If PTDbController.HasException() Then Return False

        ' Also, populate respective lists with data
        PTList = getListFromDataTable(PTDbController.DbDataTable, "PaymentType")
        For i As Integer = 0 To PTList.Count - 1
            PTList(i) = PTList(i).ToString().ToLower()
        Next

        Return True

    End Function


    ' Sub that initializes all dataEditingcontrols corresponding with values from the PaymentTypes datatable
    Private Sub InitializePTDataEditingControls()

        ' Lookup and set current PTRow index based on selectedIndex of PaymentType ComboBox
        Dim escapedText As String = escapeLikeValues(PTComboBox.Text)
        Dim PTDataRow As DataRow = PTDbController.DbDataTable.Select("PaymentType LIKE '" & escapedText & "'")(0)
        PTRow = PTDbController.DbDataTable.Rows.IndexOf(PTDataRow)

        initializeControlsFromRow(PTDbController.DbDataTable, PTRow, "dataEditingControl", "_", Me)

    End Sub

    ' Sub that initializes all dataViewingControls corresponding with values from the PaymentTypes datatable
    Private Sub InitializePTDataViewingControls()

        ' Lookup and set current PTRow index based on selectedIndex of PaymentType ComboBox
        Dim escapedText As String = escapeLikeValues(PTComboBox.Text)   ' removes/handles escape characters that cause errors
        Dim PTDataRow As DataRow = PTDbController.DbDataTable.Select("PaymentType LIKE '" & escapedText & "'")(0)
        PTRow = PTDbController.DbDataTable.Rows.IndexOf(PTDataRow)

        initializeControlsFromRow(PTDbController.DbDataTable, PTRow, "dataViewingControl", "_", Me)

    End Sub


    ' Sub that calls all individual dataEditingControl initialization subs in one (These can be used individually if desired)
    Private Sub InitializeAllDataEditingControls()

        ' Automated initializations
        InitializePTDataEditingControls()
        ' Then, add formatting
        ' addFormatting()
        ' Set forecolor if not already initially default
        setForeColor(getAllControlsWithTag("dataEditingControl", Me), DefaultForeColor)

    End Sub

    ' Sub that calls all individual dataEditingControl initialization subs in one (These can be used individually if desired)
    Private Sub InitializeAllDataViewingControls()

        ' Automated initializations
        InitializePTDataViewingControls()

    End Sub


    ' Function that makes updateTable calls for all relevant DataTables that need updated based on changes
    Private Function updateAll() As Boolean

        ' First, remove any formatting that was added (specific to the controls on this form)
        'stripFormatting()

        ' Then, update all relevant tables that COUDLD have experienced changes
        Dim initialValueAsKey As String = PTDbController.DbDataTable.Rows(PTRow)("PaymentType")
        updateTable(CRUD, PTDbController.DbDataTable, "PaymentTypes", initialValueAsKey, "PaymentType", "_", "dataEditingControl", Me)
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
        insertRow(CRUD, PTDbController.DbDataTable, "PaymentTypes", "_", "dataEditingControl", Me)
        ' Then, return exception status of CRUD controller. Do this after each call
        If CRUD.HasException() Then Return False

        ' Otherwise, return true
        Return True

    End Function


    ' Function that makes deleteRow calls for all relevant DataTables
    Private Function deleteAll() As Boolean

        ' Then, make calls to insertRow to all relevant tables
        Dim valueAsKey As String = PTDbController.DbDataTable.Rows(PTRow)("PaymentType")
        deleteRow(CRUD, "PaymentTypes", valueAsKey, "PaymentType")
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


        ' Payment Type Name (REQUIRED)(MUST BE UNIQUE)
        If Not isValidLength("Payment Type Name", True, PaymentType_Textbox.Text, 50, errorMessage) Then
            PaymentType_Textbox.ForeColor = Color.Red
        Else
            If mode = "editing" Then
                Dim initial As String = PTDbController.DbDataTable.Rows(PTRow)("PaymentType").ToString()
                If PaymentType_Textbox.Text.ToLower() <> initial.ToLower() Then
                    If isDuplicate("Payment Type Name", PaymentType_Textbox.Text.ToLower(), errorMessage, PTList) Then
                        PaymentType_Textbox.ForeColor = Color.Red
                    End If
                End If
            ElseIf mode = "adding" Then
                If isDuplicate("Payment Type Name", PaymentType_Textbox.Text.ToLower(), errorMessage, PTList) Then
                    PaymentType_Textbox.ForeColor = Color.Red
                End If
            End If
        End If


        ' Check if any invalid input has been found
        If Not String.IsNullOrEmpty(errorMessage) Then

            MessageBox.Show(errorMessage, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False

        End If

        Return True

    End Function


    Private Sub paymentMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
        PTComboBox.Items.Add("Select One")
        For Each row In PTDbController.DbDataTable.Rows
            PTComboBox.Items.Add(row("PaymentType"))
        Next
        PTComboBox.SelectedIndex = 0

    End Sub




    ' **************** CONTROL SUBS ****************


    ' Main eventhandler that handles most of the initialization for all subsequent elements/controls.
    Private Sub PTCombobox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PTComboBox.SelectedIndexChanged, PTComboBox.TextChanged

        ' If the input in the combobox matches an entry in the table that it represents
        If PTList.BinarySearch(PTComboBox.Text.ToLower()) >= 0 Then

            ' Initialize corresponding controls from DataTable values
            valuesInitialized = False
            InitializePTDataViewingControls()
            valuesInitialized = True

            ' Show labels and corresponding values
            showHide(getAllControlsWithTag("dataViewingControl", Me), 1)
            showHide(getAllControlsWithTag("dataLabel", Me), 1)
            showHide(getAllControlsWithTag("dataEditingControl", Me), 0)
            ' Enable editing button
            editButton.Enabled = True
            deleteButton.Enabled = True

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
        InitialPTValues.SetInitialValues(getAllControlsWithTag("dataEditingControl", Me))

        ' First, disable editButton, addButton, enable cancelButton, and disable nav
        editButton.Enabled = False
        addButton.Enabled = False
        cancelButton.Enabled = True
        nav.DisableAll()
        PTComboBox.Enabled = False


        lastSelected = PTComboBox.Text
        PTComboBox.SelectedIndex = 0

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
                    MessageBox.Show("Successfully deleted " & PTComboBox.Text & " from Payment Types")
                End If

                ' 2.) RELOAD DATATABLES FROM DATABASE
                If Not loadDataTablesFromDatabase() Then
                    MessageBox.Show("Loading updated information failed; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                ' 3.) REINITIALIZE CONTROLS FROM THIS POINT (still from selection index, however)
                PTComboBox.Items.Clear()
                PTComboBox.Items.Add("Select One")
                For Each row In PTDbController.DbDataTable.Rows
                    PTComboBox.Items.Add(row("PaymentType"))
                Next
                PTComboBox.SelectedIndex = 0

                ' 4.) RESTORE USER CONTROLS TO NON-EDITING/SELECTING STATE
                PTComboBox.Enabled = True
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
        InitializePTDataEditingControls()
        ' Establish initial values. Doing this here, as unless changes are about to be made, we don't need to set initial values
        InitialPTValues.SetInitialValues(getAllControlsWithTag("dataEditingControl", Me))

        ' Disable editButton, disable addButton, enable cancel button, disable navigation, and disable main selection combobox
        editButton.Enabled = False
        addButton.Enabled = False
        cancelButton.Enabled = True
        nav.DisableAll()
        PTComboBox.Enabled = False

        ' Hide/Show the dataViewingControls and dataEditingControls, respectively
        showHide(getAllControlsWithTag("dataViewingControl", Me), 0)
        showHide(getAllControlsWithTag("dataEditingControl", Me), 1)

    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click

        ' Check for changes before cancelling. Don't need function here that calls all, as only working with one datatable
        If InitialPTValues.CtrlValuesChanged() Then

            Dim decision As DialogResult = MessageBox.Show("Cancel without saving changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            Select Case decision
                Case DialogResult.Yes

                    If mode = "editing" Then

                        ' REINITIALIZE ALL CONTROL VALUES (as unwanted changes have been made)
                        valuesInitialized = False
                        InitializeAllDataEditingControls()
                        valuesInitialized = True

                        ' RESTORE USER CONTROLS TO NON-EDITING STATE
                        editButton.Enabled = True
                        addButton.Enabled = True
                        cancelButton.Enabled = False
                        saveButton.Enabled = False
                        nav.EnableAll()
                        PTComboBox.Enabled = True
                        ' Show/Hide the dataViewingControls and dataEditingControls, respectively
                        showHide(getAllControlsWithTag("dataViewingControl", Me), 1)
                        showHide(getAllControlsWithTag("dataEditingControl", Me), 0)

                    ElseIf mode = "adding" Then

                        ' 1.) CLEAR DATA EDITING CONTROLS
                        clearControls(getAllControlsWithTag("dataEditingControl", Me))
                        'showHide(getAllControlsWithTag("dataEditingControl", Me), 0)

                        ' 2.) SET PTComboBox BPTK TO LAST SELECTED ITEM/INDEX
                        PTComboBox.SelectedIndex = PTComboBox.Items.IndexOf(lastSelected)
                        ' If this is not select one, because it changed from the orig to select one, and now back to orig,
                        ' the .textChanged event for the combo box will take care of reinitializing and showing the dataViewingControls

                        ' 3.) IF LAST SELECTED WAS "SELECT ONE", Then simulate functionality from combobox text/selectedIndex changed
                        If lastSelected = "Select One" Then
                            PTCombobox_SelectedIndexChanged(PTComboBox, New EventArgs())
                        End If

                        ' 4.) RESTORE USER CONTROLS TO NON-ADDING STATE (only those that are controlled by "adding")
                        PTComboBox.Enabled = True
                        addButton.Enabled = True
                        cancelButton.Enabled = False
                        saveButton.Enabled = False
                        nav.EnableAll()

                    End If

                Case DialogResult.No
            End Select

        Else

            If mode = "editing" Then

                ' RESTORE USER CONTROLS TO NON-EDITING STATE
                editButton.Enabled = True
                addButton.Enabled = True
                cancelButton.Enabled = False
                saveButton.Enabled = False
                nav.EnableAll()
                PTComboBox.Enabled = True
                ' Show/Hide the dataViewingControls and dataEditingControls, respectively
                showHide(getAllControlsWithTag("dataViewingControl", Me), 1)
                showHide(getAllControlsWithTag("dataEditingControl", Me), 0)

            ElseIf mode = "adding" Then

                ' 1.) CLEAR DATA EDITING CONTROLS
                clearControls(getAllControlsWithTag("dataEditingControl", Me))
                'showHide(getAllControlsWithTag("dataEditingControl", Me), 0)

                ' 2.) SET PTComboBox BPTK TO LAST SELECTED ITEM/INDEX
                PTComboBox.SelectedIndex = PTComboBox.Items.IndexOf(lastSelected)
                ' If this is not select one, because it changed from the orig to select one, and now back to orig,
                ' the .textChanged event for the combo box will take care of reinitializing and showing the dataViewingControls

                ' 3.) IF LAST SELECTED WAS "SELECT ONE", Then simulate functionality from combobox text/selectedIndex changed
                If lastSelected = "Select One" Then
                    PTCombobox_SelectedIndexChanged(PTComboBox, New EventArgs())
                End If

                ' 4.) RESTORE USER CONTROLS TO NON-ADDING STATE (only those that are controlled by "adding")
                PTComboBox.Enabled = True
                addButton.Enabled = True
                cancelButton.Enabled = False
                saveButton.Enabled = False
                nav.EnableAll()

            End If



        End If

    End Sub

    Private Sub saveButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click

        Dim decision As DialogResult = MessageBox.Show("Save Changes?", "Confirm Changes", MessageBoxButtons.YesNo)

        Select Case decision
            Case DialogResult.Yes

                If mode = "editing" Then

                    ' 1.) VALIDATE DATAEDITING CONTROLS
                    If Not controlsValid() Then Exit Sub

                    ' 2.) UPDATE DATATABLE(S), THEN UPDATE DATABASE
                    If Not updateAll() Then
                        MessageBox.Show("Update unsuccessful; Changes not saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        MessageBox.Show("Successfully updated Payment Types")
                    End If

                    ' 3.) RELOAD DATATABLES FROM DATABASE
                    If Not loadDataTablesFromDatabase() Then
                        MessageBox.Show("Loading updated information failed; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    ' 4.) REINITIALIZE CONTROLS FROM THIS POINT (still from selection index, however)
                    PTComboBox.Items.Clear()
                    PTComboBox.Items.Add("Select One")
                    For Each row In PTDbController.DbDataTable.Rows
                        PTComboBox.Items.Add(row("PaymentType"))
                    Next
                    PTComboBox.SelectedIndex = PTComboBox.Items.IndexOf(PaymentType_Textbox.Text)
                    'PTComboBox.SelectedIndex = amRow + 1

                    ' dataViewingControl values reinitialized, as well as dataControls hide/show in combobox text/selectedindex change event

                    ' 5.) MOVE UI OUT OF EDITING MODE
                    addButton.Enabled = True
                    cancelButton.Enabled = False
                    saveButton.Enabled = False
                    nav.EnableAll()
                    PTComboBox.Enabled = True

                ElseIf mode = "adding" Then

                    ' 1.) VALIDATE DATAEDITING CONTROLS
                    If Not controlsValid() Then Exit Sub

                    ' 2.) INSERT NEW ROW INTO DATABASE
                    If Not insertAll() Then
                        MessageBox.Show("Insert unsuccessful; Changes not saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        MessageBox.Show("Successfully added " & PaymentType_Textbox.Text & " to Payment Types")
                    End If

                    ' 3.) RELOAD DATATABLES FROM DATABASE
                    If Not loadDataTablesFromDatabase() Then
                        MessageBox.Show("Loading updated information failed; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    ' 4.) REINITIALIZE CONTROLS (based on index of newly inserted value)
                    PTComboBox.Items.Clear()
                    PTComboBox.Items.Add("Select One")
                    For Each row In PTDbController.DbDataTable.Rows
                        PTComboBox.Items.Add(row("PaymentType"))
                    Next

                    ' Changing index of main combobox will also initialize respective dataViewing control values
                    PTComboBox.SelectedIndex = PTComboBox.Items.IndexOf(PaymentType_Textbox.Text)

                    ' 5.) MOVE UI OUT OF Adding MODE
                    addButton.Enabled = True
                    cancelButton.Enabled = False
                    saveButton.Enabled = False
                    nav.EnableAll()
                    PTComboBox.Enabled = True

                End If

            Case DialogResult.No
                ' Continue making changes or cancel editing
        End Select


    End Sub


    Private Sub PaymentType_Textbox_TextChanged(sender As Object, e As EventArgs) Handles PaymentType_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        PaymentType_Textbox.ForeColor = DefaultForeColor

        If InitialPTValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private Sub paymentMaintenance_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        End
    End Sub

End Class