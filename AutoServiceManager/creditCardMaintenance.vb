﻿Imports System.ComponentModel

Public Class creditCardMaintenance

    ' New Database control instances for insurance companies datatable
    Private CCDbController As New DbControl()
    ' New Database control instance for updating, inserting, and deleting
    Private CRUD As New DbControl()

    ' Initialize instance(s) of initialValues class
    Private InitialCCValues As New InitialValues()

    'Variable to keep track of whether form fully loaded or not
    Private valuesInitialized As Boolean = True

    ' Row index variables used for DataTable lookups
    Private CCRow As Integer
    Private lastSelected As String

    ' Keeps track of whether or not user in "editing" or "adding" mode
    Private mode As String




    ' ***************** INITIALIZATION AND CONFIGURATION SUBS *****************


    ' Sub that will contain calls to all of the instances of the database controller class that loads data from the database into DataTables
    Private Function loadDataTablesFromDatabase() As Boolean

        CCDbController.ExecQuery("SELECT cca.CreditCard FROM CreditCardsAccepted cca ORDER BY cca.CreditCard ASC")
        If CCDbController.HasException() Then Return False

        Return True

    End Function


    ' Sub that initializes all dataEditingcontrols corresponding with values from the CreditCardsAccepted datatable
    Private Sub InitializeCCDataEditingControls()

        ' Lookup and set current CCRow index based on selectedIndex of CreditCard ComboBox
        Dim escapedText As String = escapeLikeValues(CCComboBox.Text)
        Dim CCDataRow As DataRow = CCDbController.DbDataTable.Select("CreditCard LIKE '" & escapedText & "'")(0)
        CCRow = CCDbController.DbDataTable.Rows.IndexOf(CCDataRow)

        initializeControlsFromRow(CCDbController.DbDataTable, CCRow, "dataEditingControl", "_", Me)

    End Sub

    ' Sub that initializes all dataViewingControls corresponding with values from the CreditCardsAccepted datatable
    Private Sub InitializeCCDataViewingControls()

        ' Lookup and set current CCRow index based on selectedIndex of CreditCard ComboBox
        Dim escapedText As String = escapeLikeValues(CCComboBox.Text)   ' removes/handles escape characters that cause errors
        Dim CCDataRow As DataRow = CCDbController.DbDataTable.Select("CreditCard LIKE '" & escapedText & "'")(0)
        CCRow = CCDbController.DbDataTable.Rows.IndexOf(CCDataRow)

        initializeControlsFromRow(CCDbController.DbDataTable, CCRow, "dataViewingControl", "_", Me)

    End Sub


    ' Sub that calls all individual dataEditingControl initialization subs in one (These can be used individually if desired)
    Private Sub InitializeAllDataEditingControls()

        ' Automated initializations
        InitializeCCDataEditingControls()
        ' Then, add formatting
        ' addFormatting()
        ' Set forecolor if not already initially default
        setForeColor(getAllControlsWithTag("dataEditingControl", Me), DefaultForeColor)

    End Sub

    ' Sub that calls all individual dataEditingControl initialization subs in one (These can be used individually if desired)
    Private Sub InitializeAllDataViewingControls()

        ' Automated initializations
        InitializeCCDataViewingControls()

    End Sub


    ' Function that makes updateTable calls for all relevant DataTables that need updated based on changes
    Private Function updateAll() As Boolean

        ' First, remove any formatting that was added (specific to the controls on this form)
        'stripFormatting()

        ' Then, update all relevant tables that COUDLD have experienced changes
        Dim initialValueAsKey As String = CCDbController.DbDataTable.Rows(CCRow)("CreditCard")
        updateTable(CRUD, CCDbController.DbDataTable, "CreditCardsAccepted", initialValueAsKey, "CreditCard", "_", "dataEditingControl", Me)
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
        insertRow(CRUD, CCDbController.DbDataTable, "CreditCardsAccepted", "_", "dataEditingControl", Me)
        ' Then, return exception status of CRUD controller. Do this after each call
        If CRUD.HasException() Then Return False

        ' Otherwise, return true
        Return True

    End Function


    ' Function that makes deleteRow calls for all relevant DataTables
    Private Function deleteAll() As Boolean

        ' Then, make calls to insertRow to all relevant tables
        Dim valueAsKey As String = CCDbController.DbDataTable.Rows(CCRow)("CreditCard")
        deleteRow(CRUD, "CreditCardsAccepted", valueAsKey, "CreditCard")
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


        ' Credit Card Name (KEY)(REQUIRED)(MUST BE UNIQUE)
        If Not isValidLength("Credit Card Name", True, CreditCard_Textbox.Text, 50, errorMessage) Then
            CreditCard_Textbox.ForeColor = Color.Red
        Else
            If mode = "editing" Then
                Dim initial As String = CCDbController.DbDataTable.Rows(CCRow)("CreditCard").ToString()
                If CreditCard_Textbox.Text.ToLower() <> initial.ToLower() Then
                    If isDuplicate("Credit Card Company", errorMessage, "CreditCard", CreditCard_Textbox.Text, CCDbController.DbDataTable) Then
                        CreditCard_Textbox.ForeColor = Color.Red
                    End If
                End If
            ElseIf mode = "adding" Then
                If isDuplicate("Credit Card Company", errorMessage, "CreditCard", CreditCard_Textbox.Text, CCDbController.DbDataTable) Then
                    CreditCard_Textbox.ForeColor = Color.Red
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




    Private Sub creditCardMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' TEST DATABASE CONNECTION FIRST
        If Not checkDbConn() Then Exit Sub

        ' LOAD DATATABLES FROM DATABASE INITIALLY
        If Not loadDataTablesFromDatabase() Then
            MessageBox.Show("Failed to connect to database; Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If


        ' SETUP CONTROLS HERE
        CCComboBox.Items.Add("Select One")
        For Each row In CCDbController.DbDataTable.Rows
            CCComboBox.Items.Add(row("CreditCard"))
        Next
        CCComboBox.SelectedIndex = 0

    End Sub




    ' **************** CONTROL SUBS ****************


    ' Main eventhandler that handles most of the initialization for all subsequent elements/controls.
    Private Sub CCCombobox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CCComboBox.SelectedIndexChanged, CCComboBox.TextChanged

        ' Ensure that ComboBox is only attempting to initialize values when on proper selected Index
        If CCComboBox.SelectedIndex = -1 Then

            ' Have all labels and corresponding values hidden
            showHide(getAllControlsWithTag("dataViewingControl", Me), 0)
            showHide(getAllControlsWithTag("dataLabel", Me), 0)
            showHide(getAllControlsWithTag("dataEditingControl", Me), 0)
            ' Disable editing button
            editButton.Enabled = False
            deleteButton.Enabled = False
            Exit Sub

        End If

        ' If the input in the combobox matches an entry in the table that it represents
        If getDataTableRow(CCDbController.DbDataTable, "CreditCard", CCComboBox.Text) <> -1 Then

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
        valuesInitialized = False
        clearControls(getAllControlsWithTag("dataEditingControl", Me))
        valuesInitialized = True
        ' Establish initial values. Doing this here, as unless changes are about to be made, we don't need to set initial values
        InitialCCValues.SetInitialValues(getAllControlsWithTag("dataEditingControl", Me))

        ' First, disable editButton, addButton, enable cancelButton, and disable nav
        editButton.Enabled = False
        addButton.Enabled = False
        cancelButton.Enabled = True
        nav.DisableAll()
        CCComboBox.Enabled = False

        ' Get lastSelected
        If getDataTableRow(CCDbController.DbDataTable, "CreditCard", CCComboBox.Text) <> -1 Then
            lastSelected = CCComboBox.Text
        Else
            lastSelected = "Select One"
        End If

        CCComboBox.SelectedIndex = 0

        ' Hide/Show the dataViewingControls and dataEditingControls, respectively
        showHide(getAllControlsWithTag("dataViewingControl", Me), 0)
        showHide(getAllControlsWithTag("dataEditingControl", Me), 1)
        showHide(getAllControlsWithTag("dataLabel", Me), 1)

        ' Select first editing control
        CreditCard_Textbox.Focus()

    End Sub


    Private Sub deleteButton_Click(sender As Object, e As EventArgs) Handles deleteButton.Click

        Dim decision As DialogResult = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        Select Case decision
            Case DialogResult.Yes

                ' 1.) Delete value from database
                If Not deleteAll() Then
                    MessageBox.Show("Delete unsuccessful; Changes not saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show("Successfully deleted " & CCComboBox.Text & " from Credit Cards Accepted")
                End If

                ' 2.) RELOAD DATATABLES FROM DATABASE
                If Not loadDataTablesFromDatabase() Then
                    MessageBox.Show("Loading updated information failed; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                ' 3.) REINITIALIZE CONTROLS FROM THIS POINT (still from selection index, however)
                CCComboBox.Items.Clear()
                CCComboBox.Items.Add("Select One")
                For Each row In CCDbController.DbDataTable.Rows
                    CCComboBox.Items.Add(row("CreditCard"))
                Next
                CCComboBox.SelectedIndex = 0

                ' 4.) RESTORE USER CONTROLS TO NON-EDITING/SELECTING STATE
                CCComboBox.Enabled = True
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
        valuesInitialized = False
        InitializeAllDataEditingControls()
        valuesInitialized = True
        ' Establish initial values. Doing this here, as unless changes are about to be made, we don't need to set initial values
        InitialCCValues.SetInitialValues(getAllControlsWithTag("dataEditingControl", Me))

        lastSelected = CCComboBox.Text

        ' Disable editButton, disable addButton, enable cancel button, disable navigation, and disable main selection combobox
        editButton.Enabled = False
        addButton.Enabled = False
        cancelButton.Enabled = True
        nav.DisableAll()
        CCComboBox.Enabled = False

        ' Hide/Show the dataViewingControls and dataEditingControls, respectively
        showHide(getAllControlsWithTag("dataViewingControl", Me), 0)
        showHide(getAllControlsWithTag("dataEditingControl", Me), 1)

        ' Select first editing control
        CreditCard_Textbox.Focus()

    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click

        ' Check for changes before cancelling. Don't need function here that calls all, as only working with one datatable's values
        If InitialCCValues.CtrlValuesChanged() Then

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
            CCComboBox.Enabled = True

            ' Show/Hide the dataViewingControls and dataEditingControls, respectively
            showHide(getAllControlsWithTag("dataViewingControl", Me), 1)
            showHide(getAllControlsWithTag("dataEditingControl", Me), 0)

        ElseIf mode = "adding" Then

            ' 1.) SET PartComboBox BACKK TO LAST SELECTED ITEM/INDEX
            CCComboBox.SelectedIndex = CCComboBox.Items.IndexOf(lastSelected)

            ' 2.) IF LAST SELECTED WAS "SELECT ONE", Then simulate functionality from combobox text/selectedIndex changed
            If lastSelected = "Select One" Then
                CCCombobox_SelectedIndexChanged(CCComboBox, New EventArgs())
            End If

            ' 3.) RESTORE USER CONTROLS TO NON-ADDING STATE (only those that are controlled by "adding")
            CCComboBox.Enabled = True
            addButton.Enabled = True
            cancelButton.Enabled = False
            saveButton.Enabled = False
            nav.EnableAll()

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
                        Exit Sub
                    Else
                        MessageBox.Show("Successfully updated Credit Cards Accepted")
                    End If

                    ' 3.) RELOAD DATATABLES FROM DATABASE
                    If Not loadDataTablesFromDatabase() Then
                        MessageBox.Show("Loading updated information failed; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    ' 4.) REINITIALIZE CONTROLS FROM THIS POINT (still from selection index, however)
                    CCComboBox.Items.Clear()
                    CCComboBox.Items.Add("Select One")
                    For Each row In CCDbController.DbDataTable.Rows
                        CCComboBox.Items.Add(row("CreditCard"))
                    Next

                    ' Check to see if the edited item is in the newly loaded DataTable.
                    ' If it is, set the combobox to this new item. If not, set it to the last Selected
                    If getDataTableRow(CCDbController.DbDataTable, "CreditCard", CreditCard_Textbox.Text) <> -1 Then
                        CCComboBox.SelectedIndex = CCComboBox.Items.IndexOf(CreditCard_Textbox.Text)
                    Else
                        CCComboBox.SelectedIndex = CCComboBox.Items.IndexOf(lastSelected)
                    End If

                    ' dataViewingControl values reinitialized, as well as dataControls hide/show in combobox text/selectedindex change event

                    ' 5.) MOVE UI OUT OF EDITING MODE
                    addButton.Enabled = True
                    cancelButton.Enabled = False
                    saveButton.Enabled = False
                    nav.EnableAll()
                    CCComboBox.Enabled = True

                ElseIf mode = "adding" Then

                    ' 1.) VALIDATE DATAEDITING CONTROLS
                    If Not controlsValid() Then Exit Sub

                    ' 2.) INSERT NEW ROW INTO DATABASE
                    If Not insertAll() Then
                        MessageBox.Show("Insert unsuccessful; Changes not saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    Else
                        MessageBox.Show("Successfully added " & CreditCard_Textbox.Text & " to Credit Cards Accepted")
                    End If

                    ' 3.) RELOAD DATATABLES FROM DATABASE
                    If Not loadDataTablesFromDatabase() Then
                        MessageBox.Show("Loading updated information failed; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    ' 4.) REINITIALIZE CONTROLS (based on index of newly inserted value)
                    CCComboBox.Items.Clear()
                    CCComboBox.Items.Add("Select One")
                    For Each row In CCDbController.DbDataTable.Rows
                        CCComboBox.Items.Add(row("CreditCard"))
                    Next

                    ' Check to see if the edited item is in the newly loaded DataTable.
                    ' If it is, set the combobox to this new item. If not, set it to the last Selected
                    If getDataTableRow(CCDbController.DbDataTable, "CreditCard", CreditCard_Textbox.Text) <> -1 Then
                        CCComboBox.SelectedIndex = CCComboBox.Items.IndexOf(CreditCard_Textbox.Text)
                    Else
                        CCComboBox.SelectedIndex = CCComboBox.Items.IndexOf(lastSelected)
                    End If
                    ' Changing index of main combobox will also initialize respective dataViewing control values

                    ' 5.) MOVE UI OUT OF Adding MODE
                    addButton.Enabled = True
                    cancelButton.Enabled = False
                    saveButton.Enabled = False
                    nav.EnableAll()
                    CCComboBox.Enabled = True

                End If

            Case DialogResult.No
                ' Continue making changes or cancel editing
        End Select


    End Sub


    Private Sub CreditCard_Textbox_TextChanged(sender As Object, e As EventArgs) Handles CreditCard_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        CreditCard_Textbox.ForeColor = DefaultForeColor

        If InitialCCValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub



    Private Sub creditCardMaintenance_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        ' Check if editing/adding, and if editing/adding, check if control values changed
        If CreditCard_Textbox.Visible And InitialCCValues.CtrlValuesChanged() Then

            Dim decision As DialogResult = MessageBox.Show("Exit without saving changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If decision = DialogResult.No Then
                e.Cancel = True
                Exit Sub
            End If

        End If

    End Sub


End Class