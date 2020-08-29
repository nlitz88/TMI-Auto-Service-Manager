Imports System.ComponentModel

Public Class inventoryMaintenance

    ' New Database control instances for Parts datatable
    Private IPDbController As New DbControl()
    ' New Database control instance for updating, inserting, and deleting
    Private CRUD As New DbControl()

    ' Initialize instance(s) of initialValues class
    Private InitialIPValues As New InitialValues()

    'Variable to keep track of whether form fully loaded or not
    Private valuesInitialized As Boolean = True

    ' Row index variables used for DataTable lookups
    Private IPRow As Integer
    Private lastSelected As String

    ' Keeps track of whether or not user in "editing" or "adding" mode
    Private mode As String

    ' Variable that allows certain keystrokes through restricted fields
    Private allowedKeystroke As Boolean = False

    ' Boolean to keep track of whether or not this form has been closed
    Private MeClosed As Boolean = False




    ' ***************** INITIALIZATION AND CONFIGURATION SUBS *****************


    ' Sub that will contain calls to all of the instances of the database controller class that loads data from the database into DataTables
    Private Function loadDataTablesFromDatabase() As Boolean

        IPDbController.ExecQuery("SELECT p.PartDescription + ' - ' + p.PartNbr as PDPN, p.PartNbr, p.PartDescription, p.PartPrice, p.ListPrice FROM Parts p ORDER BY p.PartDescription ASC")
        If IPDbController.HasException() Then Return False

        Return True

    End Function


    ' Sub that initializes all dataEditingcontrols corresponding with values from the Parts datatable
    Private Sub InitializeIPDataEditingControls()

        initializeControlsFromRow(IPDbController.DbDataTable, IPRow, "dataEditingControl", "_", Me)

    End Sub

    ' Sub that initializes all dataViewingControls corresponding with values from the Parts datatable
    Private Sub InitializeIPDataViewingControls()


        initializeControlsFromRow(IPDbController.DbDataTable, IPRow, "dataViewingControl", "_", Me)

    End Sub


    ' Sub that calls all individual dataEditingControl initialization subs in one (These can be used individually if desired)
    Private Sub InitializeAllDataEditingControls()

        ' Automated initializations
        InitializeIPDataEditingControls()
        ' Then, format dataEditingControls
        formatDataEditingControls()
        ' Set forecolor if not already initially default
        setForeColor(getAllControlsWithTag("dataEditingControl", Me), DefaultForeColor)

    End Sub

    ' Sub that calls all individual dataEditingControl initialization subs in one (These can be used individually if desired)
    Private Sub InitializeAllDataViewingControls()

        ' Automated initializations
        InitializeIPDataViewingControls()
        ' Format dataviewingcontrols
        formatDataViewingControls()

    End Sub


    ' Sub that will call formatting functions to add respective formats to already INITIALIZED DATAVIEWINGCONTROLS (i.e. phone numbers, currency, etc.).
    Private Sub formatDataViewingControls()

        PartPrice_Value.Text = FormatCurrency(IPDbController.DbDataTable.Rows(IPRow)("PartPrice"))
        ListPrice_Value.Text = FormatCurrency(IPDbController.DbDataTable.Rows(IPRow)("ListPrice"))

    End Sub

    ' Sub that will call formatting functions to add respective formats to already INITIALIZED DATAEDITINGCONTROLS (i.e. phone numbers, currency, etc.).
    Private Sub formatDataEditingControls()

        PartPrice_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(IPDbController.DbDataTable.Rows(IPRow)("PartPrice")))
        ListPrice_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(IPDbController.DbDataTable.Rows(IPRow)("ListPrice")))

    End Sub

    ' Sub that will remove all necessary formatting taht was added (used before updating values)
    Private Sub stripDataEditingControlsFormatting()

    End Sub


    ' Function that makes updateTable calls for all relevant DataTables that need updated based on changes
    Private Function updateAll() As Boolean

        ' First, remove any formatting that was added (specific to the controls on this form)
        ' stripDataEditingControlsFormatting()

        ' Then, update all relevant tables that COUDLD have experienced changes
        Dim initialValueAsKey As String = IPDbController.DbDataTable.Rows(IPRow)("PartNbr")
        updateTable(CRUD, IPDbController.DbDataTable, "Parts", initialValueAsKey, "PartNbr", "_", "dataEditingControl", Me)
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
        insertRow(CRUD, IPDbController.DbDataTable, "Parts", "_", "dataEditingControl", Me)
        ' Then, return exception status of CRUD controller. Do this after each call
        If CRUD.HasException() Then Return False

        ' Otherwise, return true
        Return True

    End Function


    ' Function that makes deleteRow calls for all relevant DataTables
    Private Function deleteAll() As Boolean

        ' Then, make calls to insertRow to all relevant tables
        Dim valueAsKey As String = IPDbController.DbDataTable.Rows(IPRow)("PartNbr")
        deleteRow(CRUD, "Parts", valueAsKey, "PartNbr")
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


        ' Part Number (KEY)(REQUIRED)(MUST BE UNIQUE)
        If Not isValidLength("Part Number", True, PartNbr_Textbox.Text, 30, errorMessage) Then
            PartNbr_Textbox.ForeColor = Color.Red
        Else
            If mode = "editing" Then
                Dim initial As String = IPDbController.DbDataTable.Rows(IPRow)("PartNbr").ToString().ToLower()
                If PartNbr_Textbox.Text.ToLower() <> initial Then
                    If isDuplicate("Part Number", errorMessage, "PartNbr", PartNbr_Textbox.Text, IPDbController.DbDataTable) Then
                        PartNbr_Textbox.ForeColor = Color.Red
                    End If
                End If
            ElseIf mode = "adding" Then
                If isDuplicate("Part Number", errorMessage, "PartNbr", PartNbr_Textbox.Text, IPDbController.DbDataTable) Then
                    PartNbr_Textbox.ForeColor = Color.Red
                End If
            End If
        End If

        ' Part Description (REQUIRED)
        If Not isValidLength("Part Description", True, PartDescription_Textbox.Text, 50, errorMessage) Then
            PartDescription_Textbox.ForeColor = Color.Red
        End If

        ' Part Price (REQUIRED)
        If Not validCurrency("Part Price", True, PartPrice_Textbox.Text, errorMessage) Then PartPrice_Textbox.ForeColor = Color.Red

        ' Part List Price (REQUIRED)
        If Not validCurrency("List Price", True, ListPrice_Textbox.Text, errorMessage) Then ListPrice_Textbox.ForeColor = Color.Red


        ' Check if any invalid input has been found
        If Not String.IsNullOrEmpty(errorMessage) Then

            MessageBox.Show(errorMessage, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False

        End If

        Return True

    End Function


    Private Sub inventoryMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' TEST DATABASE CONNECTION FIRST
        If Not checkDbConn() Then Exit Sub

        ' LOAD DATATABLES FROM DATABASE INITIALLY
        If Not loadDataTablesFromDatabase() Then
            MessageBox.Show("Failed to connect to database; Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If


        ' SETUP CONTROLS HERE
        PartComboBox.Items.Add("Select One")
        For Each row In IPDbController.DbDataTable.Rows
            PartComboBox.Items.Add(row("PDPN"))
        Next
        PartComboBox.SelectedIndex = 0


        ' FIRE ADDBUTTON EVENT IF ARRIVING HERE FROM ADDMASTERTASKPART OR ADDINVTASKPART
        If previousScreen IsNot Nothing Then

            If previousScreen Is addMasterTaskLabor Or previousScreen Is addInvTaskPart Then
                nav.Visible = False
                returnButton.Visible = True
                addButton_Click(addButton, New EventArgs())
            End If

        Else
            returnButton.Visible = False
        End If


    End Sub




    ' **************** CONTROL SUBS ****************


    ' Main eventhandler that handles most of the initialization for all subsequent elements/controls.
    Private Sub PartCombobox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PartComboBox.SelectedIndexChanged, PartComboBox.TextChanged

        ' Ensure that ComboBox is only attempting to initialize values when on proper selected Index
        If PartComboBox.SelectedIndex = -1 Then

            ' Have all labels and corresponding values hidden
            showHide(getAllControlsWithTag("dataViewingControl", Me), 0)
            showHide(getAllControlsWithTag("dataLabel", Me), 0)
            showHide(getAllControlsWithTag("dataEditingControl", Me), 0)
            ' Disable editing button
            editButton.Enabled = False
            deleteButton.Enabled = False
            Exit Sub

        End If

        ' First, Lookup newly changed value in respective dataTable to see if the selected value exists And Is valid
        IPRow = getDataTableRow(IPDbController.DbDataTable, "PDPN", PartComboBox.Text)

        ' If the lookup DOES find the value in the DataTable
        If IPRow <> -1 Then

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
        valuesInitialized = False
        clearControls(getAllControlsWithTag("dataEditingControl", Me))
        valuesInitialized = True
        ' Establish initial values. Doing this here, as unless changes are about to be made, we don't need to set initial values
        InitialIPValues.SetInitialValues(getAllControlsWithTag("dataEditingControl", Me))

        ' First, disable editButton, addButton, enable cancelButton, and disable nav
        editButton.Enabled = False
        addButton.Enabled = False
        cancelButton.Enabled = True
        nav.DisableAll()
        PartComboBox.Enabled = False

        ' Get lastSelected
        If getDataTableRow(IPDbController.DbDataTable, "PDPN", PartComboBox.Text) <> -1 Then
            lastSelected = PartComboBox.Text
        Else
            lastSelected = "Select One"
        End If

        PartComboBox.SelectedIndex = 0

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
                    MessageBox.Show("Successfully deleted " & PartComboBox.Text & " from Parts")
                End If

                ' 2.) RELOAD DATATABLES FROM DATABASE
                If Not loadDataTablesFromDatabase() Then
                    MessageBox.Show("Loading updated information failed; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                ' 3.) REINITIALIZE CONTROLS FROM THIS POINT (still from selection index, however)
                PartComboBox.Items.Clear()
                PartComboBox.Items.Add("Select One")
                For Each row In IPDbController.DbDataTable.Rows
                    PartComboBox.Items.Add(row("PDPN"))
                Next
                PartComboBox.SelectedIndex = 0

                ' 4.) RESTORE USER CONTROLS TO NON-EDITING/SELECTING STATE
                PartComboBox.Enabled = True
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
        InitialIPValues.SetInitialValues(getAllControlsWithTag("dataEditingControl", Me))

        ' Store the last selected item in the ComboBox (in case update fails and it must revert)
        lastSelected = PartComboBox.Text

        ' Disable editButton, disable addButton, enable cancel button, disable navigation, and disable main selection combobox
        editButton.Enabled = False
        addButton.Enabled = False
        cancelButton.Enabled = True
        nav.DisableAll()
        PartComboBox.Enabled = False

        ' Hide/Show the dataViewingControls and dataEditingControls, respectively
        showHide(getAllControlsWithTag("dataViewingControl", Me), 0)
        showHide(getAllControlsWithTag("dataEditingControl", Me), 1)

    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click

        ' Check for changes before cancelling. Don't need function here that calls all, as only working with one datatable's values
        If InitialIPValues.CtrlValuesChanged() Then

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
            PartComboBox.Enabled = True

            ' Show/Hide the dataViewingControls and dataEditingControls, respectively
            showHide(getAllControlsWithTag("dataViewingControl", Me), 1)
            showHide(getAllControlsWithTag("dataEditingControl", Me), 0)

        ElseIf mode = "adding" Then

            ' 1.) SET PartComboBox BACKK TO LAST SELECTED ITEM/INDEX
            PartComboBox.SelectedIndex = PartComboBox.Items.IndexOf(lastSelected)

            ' 2.) IF LAST SELECTED WAS "SELECT ONE", Then simulate functionality from combobox text/selectedIndex changed
            If lastSelected = "Select One" Then
                PartCombobox_SelectedIndexChanged(PartComboBox, New EventArgs())
            End If

            ' 3.) RESTORE USER CONTROLS TO NON-ADDING STATE (only those that are controlled by "adding")
            PartComboBox.Enabled = True
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
                        MessageBox.Show("Successfully updated Parts")
                    End If

                    ' 3.) RELOAD DATATABLES FROM DATABASE
                    If Not loadDataTablesFromDatabase() Then
                        MessageBox.Show("Loading updated information failed; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    ' 4.) REINITIALIZE CONTROLS FROM THIS POINT (still from selection index, however)
                    PartComboBox.Items.Clear()
                    PartComboBox.Items.Add("Select One")
                    For Each row In IPDbController.DbDataTable.Rows
                        PartComboBox.Items.Add(row("PDPN"))
                    Next

                    ' Look up new ComboBox value corresponding to the new value in the datatable and set the selected index of the re-initialized ComboBox accordingly
                    ' If insertion failed, then revert selected back to lastSelected
                    Dim updatedItem As String = getRowValueWithKey(IPDbController.DbDataTable, "PDPN", "PartNbr", PartNbr_Textbox.Text)
                    If updatedItem <> Nothing Then
                        PartComboBox.SelectedIndex = PartComboBox.Items.IndexOf(updatedItem)
                    Else
                        PartComboBox.SelectedIndex = PartComboBox.Items.IndexOf(lastSelected)
                    End If

                    ' dataViewingControl values reinitialized, as well as dataControls hide/show in combobox text/selectedindex change event

                    ' 5.) MOVE UI OUT OF EDITING MODE
                    addButton.Enabled = True
                    cancelButton.Enabled = False
                    saveButton.Enabled = False
                    nav.EnableAll()
                    PartComboBox.Enabled = True

                ElseIf mode = "adding" Then

                    ' 1.) VALIDATE DATAEDITING CONTROLS
                    If Not controlsValid() Then Exit Sub

                    ' 2.) INSERT NEW ROW INTO DATABASE
                    If Not insertAll() Then
                        MessageBox.Show("Insert unsuccessful; Changes not saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    Else
                        MessageBox.Show("Successfully added " & PartNbr_Textbox.Text & " to Parts")
                    End If

                    ' 3.) RELOAD DATATABLES FROM DATABASE
                    If Not loadDataTablesFromDatabase() Then
                        MessageBox.Show("Loading updated information failed; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    ' 4.) REINITIALIZE CONTROLS (based on index of newly inserted value)
                    PartComboBox.Items.Clear()
                    PartComboBox.Items.Add("Select One")
                    For Each row In IPDbController.DbDataTable.Rows
                        PartComboBox.Items.Add(row("PDPN"))
                    Next

                    ' Changing index of main combobox will also initialize respective dataViewing control values
                    ' Lookup and set new selectedIndex based on new value. If insertion failed, then go back to last
                    Dim newItem As Object = getRowValueWithKey(IPDbController.DbDataTable, "PDPN", "PartNbr", PartNbr_Textbox.Text)
                    If newItem <> Nothing Then
                        PartComboBox.SelectedIndex = PartComboBox.Items.IndexOf(newItem)
                    Else
                        PartComboBox.SelectedIndex = PartComboBox.Items.IndexOf(lastSelected)
                    End If


                    ' 5.) MOVE UI OUT OF Adding MODE
                    addButton.Enabled = True
                    cancelButton.Enabled = False
                    saveButton.Enabled = False
                    nav.EnableAll()
                    PartComboBox.Enabled = True

                End If

            Case DialogResult.No
                ' Continue making changes or cancel editing
        End Select


    End Sub


    Private Sub PartNbr_Textbox_TextChanged(sender As Object, e As EventArgs) Handles PartNbr_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        PartNbr_Textbox.ForeColor = DefaultForeColor

        If InitialIPValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private Sub PartDescription_Textbox_TextChanged(sender As Object, e As EventArgs) Handles PartDescription_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        PartDescription_Textbox.ForeColor = DefaultForeColor

        If InitialIPValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private Sub PartPrice_Textbox_KeyDown(sender As Object, e As KeyEventArgs) Handles PartPrice_Textbox.KeyDown

        ' Check to see ctrl+A, ctrl+C, or ctrl+V were used. If so, don't worry about checking which Keys Pressed
        If ((e.KeyCode = Keys.A And e.Control) Or (e.KeyCode = Keys.C And e.Control) Or (e.KeyCode = Keys.V And e.Control)) Then
            allowedKeystroke = True
        End If

    End Sub

    Private Sub PartPrice_Textbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PartPrice_Textbox.KeyPress

        ' If certain keystroke exceptions allowed throuhg, then skip input validation here
        If allowedKeystroke Then
            allowedKeystroke = False
            Exit Sub
        End If

        If Not currencyInputValid(PartPrice_Textbox, e.KeyChar) Then
            e.KeyChar = Chr(0)
            e.Handled = True
        End If

    End Sub

    Private Sub PartPrice_Textbox_TextChanged(sender As Object, e As EventArgs) Handles PartPrice_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        PartPrice_Textbox.ForeColor = DefaultForeColor

        ' Handles pasting in invalid values/strings
        Dim lastValidIndex As Integer = allValidChars(PartPrice_Textbox.Text, "1234567890.")
        If lastValidIndex <> -1 Then
            PartPrice_Textbox.Text = PartPrice_Textbox.Text.Substring(0, lastValidIndex)
            PartPrice_Textbox.SelectionStart = lastValidIndex
        End If

        If InitialIPValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private Sub ListPrice_Textbox_KeyDown(sender As Object, e As KeyEventArgs) Handles ListPrice_Textbox.KeyDown

        ' Check to see ctrl+A, ctrl+C, or ctrl+V were used. If so, don't worry about checking which Keys Pressed
        If ((e.KeyCode = Keys.A And e.Control) Or (e.KeyCode = Keys.C And e.Control) Or (e.KeyCode = Keys.V And e.Control)) Then
            allowedKeystroke = True
        End If

    End Sub

    Private Sub ListPrice_Textbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ListPrice_Textbox.KeyPress

        ' If certain keystroke exceptions allowed throuhg, then skip input validation here
        If allowedKeystroke Then
            allowedKeystroke = False
            Exit Sub
        End If

        If Not currencyInputValid(ListPrice_Textbox, e.KeyChar) Then
            e.KeyChar = Chr(0)
            e.Handled = True
        End If

    End Sub

    Private Sub ListPrice_Textbox_TextChanged(sender As Object, e As EventArgs) Handles ListPrice_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        ListPrice_Textbox.ForeColor = DefaultForeColor

        ' Handles pasting in invalid values/strings
        Dim lastValidIndex As Integer = allValidChars(ListPrice_Textbox.Text, "1234567890.")
        If lastValidIndex <> -1 Then
            ListPrice_Textbox.Text = ListPrice_Textbox.Text.Substring(0, lastValidIndex)
            ListPrice_Textbox.SelectionStart = lastValidIndex
        End If

        If InitialIPValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub



    Private Sub returnButton_Click(sender As Object, e As EventArgs) Handles returnButton.Click

        ' Will need to call reinitialization Function here to reinitialize elements on addMasterTaskPart
        If Not MeClosed Then

            ' Only want to ask them if the ctrl values are currently being edited AND they're values have changed
            If PartNbr_Textbox.Visible And InitialIPValues.CtrlValuesChanged() Then

                Dim decision As DialogResult = MessageBox.Show("Return without saving changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If decision = DialogResult.No Then
                    Exit Sub
                Else

                    If previousScreen Is addMasterTaskPart Then
                        ' Call REINITIALIZATION HERE
                        If Not addMasterTaskPart.reInitializeParts() Then
                            MessageBox.Show("Reloading of Add Task Part unsuccessful; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)                            saveButton.Enabled = False
                            saveButton.Enabled = False
                            Exit Sub
                        End If
                    ElseIf previousScreen Is addInvTaskPart Then
                        ' Call REINITIALIZATION HERE
                        If Not addInvTaskPart.reInitializeParts() Then
                            MessageBox.Show("Reloading of Add Task Part unsuccessful; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            saveButton.Enabled = False
                            Exit Sub
                        End If
                    End If

                    MeClosed = True
                    changeScreen(previousScreen, Me)
                    previousScreen = Nothing

                End If

            Else

                If previousScreen Is addMasterTaskPart Then
                    ' Call REINITIALIZATION HERE
                    If Not addMasterTaskPart.reInitializeParts() Then
                        MessageBox.Show("Reloading of Add Task Part unsuccessful; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)                            saveButton.Enabled = False
                        saveButton.Enabled = False
                        Exit Sub
                    End If
                ElseIf previousScreen Is addInvTaskPart Then
                    ' Call REINITIALIZATION HERE
                    If Not addInvTaskPart.reInitializeParts() Then
                        MessageBox.Show("Reloading of Add Task Part unsuccessful; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)                            saveButton.Enabled = False
                        saveButton.Enabled = False
                        Exit Sub
                    End If
                End If

                MeClosed = True
                changeScreen(previousScreen, Me)
                previousScreen = Nothing

            End If

        End If

    End Sub

    Private Sub inventoryMaintenance_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        If Not MeClosed Then

            If PartNbr_Textbox.Visible And InitialIPValues.CtrlValuesChanged() Then

                Dim decision As DialogResult = MessageBox.Show("Exit without saving changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If decision = DialogResult.No Then
                    e.Cancel = True
                    Exit Sub
                Else
                    ' If coming from another screen, then change back to that screen
                    If previousScreen IsNot Nothing Then
                        If previousScreen Is addMasterTaskPart Then

                            'Call REINITIALIZATION HERE
                            If Not addMasterTaskPart.reInitializeParts() Then
                                MessageBox.Show("Reloading of Add Task Part unsuccessful; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                saveButton.Enabled = False
                                Exit Sub
                            End If

                            MeClosed = True
                            changeScreen(addMasterTaskPart, Me)
                            previousScreen = Nothing

                        End If
                        ' Otherwise, just exit the form
                    Else
                        MeClosed = True
                        Me.Close()
                    End If

                End If

            Else

                ' If coming from another screen, then change back to that screen
                If previousScreen IsNot Nothing Then
                    If previousScreen Is addMasterTaskPart Then

                        'Call REINITIALIZATION HERE
                        If Not addMasterTaskPart.reInitializeParts() Then
                            MessageBox.Show("Reloading of Add Task Part unsuccessful; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            saveButton.Enabled = False
                            Exit Sub
                        End If

                        MeClosed = True
                        changeScreen(addMasterTaskPart, Me)
                        previousScreen = Nothing

                    End If
                    ' Otherwise, just exit the form
                Else
                    MeClosed = True
                    Me.Close()
                End If

            End If

        End If

    End Sub

End Class