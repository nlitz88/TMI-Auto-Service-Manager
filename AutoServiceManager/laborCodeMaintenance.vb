Imports System.ComponentModel

Public Class laborCodeMaintenance

    ' New Database control instances for insurance companies datatable
    Private LCDbController As New DbControl()
    ' New Database control instance for updating, inserting, and deleting
    Private CRUD As New DbControl()

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

    ' Boolean to keep track of whether or not this form has been closed
    Private MeClosed As Boolean = False




    ' ***************** INITIALIZATION AND CONFIGURATION SUBS *****************


    ' Sub that will contain calls to all of the instances of the database controller class that loads data from the database into DataTables
    Private Function loadDataTablesFromDatabase() As Boolean

        LCDbController.ExecQuery("SELECT lc.Description + ' - ' + lc.LaborCode as LDLC, lc.LaborCode, lc.Description, lc.Rate, lc.Hours, lc.Amount FROM LaborCodes lc ORDER BY lc.Description ASC")
        If LCDbController.HasException() Then Return False

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
        ' Then, manually initialize AmountTextbox
        InitializeAmountTextbox()
        ' Then, format dataEditingControls
        formatDataEditingControls()
        ' Set forecolor if not already initially default
        setForeColor(getAllControlsWithTag("dataEditingControl", Me), DefaultForeColor)

    End Sub

    ' Sub that calls all individual dataEditingControl initialization subs in one (These can be used individually if desired)
    Private Sub InitializeAllDataViewingControls()

        ' Automated initializations
        InitializeLCDataViewingControls()
        ' Then, manually initialize AmountValue
        InitializeAmountValue()
        ' Format dataviewingcontrols
        formatDataViewingControls()

    End Sub


    ' Subs that initializes Amount_Textbox/Amount_Value based on the values of
    Private Sub InitializeAmountTextbox()

        If validCurrency("Rate", True, Rate_Textbox.Text, String.Empty) And validNumber("Hours", True, Hours_Textbox.Text, String.Empty) Then
            ' Calculate amount based on valid rate and hours
            Dim rate As Decimal = Convert.ToDecimal(Rate_Textbox.Text)
            Dim hours As Decimal = Convert.ToDecimal(Hours_Textbox.Text)
            Amount_Textbox.Text = rate * hours
            ' THen, manually format newly calculated quantity
            Amount_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(Amount_Textbox.Text))
        Else
            Amount_Textbox.Text = String.Empty
        End If


    End Sub
    Private Sub InitializeAmountValue()

        Dim rate, hours As Decimal
        rate = Convert.ToDecimal(LCDbController.DbDataTable.Rows(LCRow)("Rate"))
        hours = Convert.ToDecimal(LCDbController.DbDataTable.Rows(LCRow)("Hours"))
        Amount_Value.Text = (rate * hours).ToString()

    End Sub


    ' Sub that will call formatting functions to add respective formats to already INITIALIZED DATAVIEWINGCONTROLS (i.e. phone numbers, currency, etc.).
    Private Sub formatDataViewingControls()

        Rate_Value.Text = FormatCurrency(LCDbController.DbDataTable.Rows(LCRow)("Rate"))
        Amount_Value.Text = FormatCurrency(Amount_Value.Text)   ' Need to use valueLabel value so that new calculated value doesn't get overwritten by old value

    End Sub

    ' Sub that will call formatting functions to add respective formats to already INITIALIZED DATAEDITINGCONTROLS (i.e. phone numbers, currency, etc.).
    Private Sub formatDataEditingControls()

        Rate_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(LCDbController.DbDataTable.Rows(LCRow)("Rate")))
        'Amount_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(Amount_Textbox.Text))   ' This formatting will be done manually per each change

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
                    If isDuplicate("Labor Code", errorMessage, "LaborCode", LaborCode_Textbox.Text, LCDbController.DbDataTable) Then
                        LaborCode_Textbox.ForeColor = Color.Red
                    End If
                End If
            ElseIf mode = "adding" Then
                If isDuplicate("Labor Code", errorMessage, "LaborCode", LaborCode_Textbox.Text, LCDbController.DbDataTable) Then
                    LaborCode_Textbox.ForeColor = Color.Red
                End If
            End If
        End If

        ' Description (REQUIRED)
        If Not isValidLength("Description", True, Description_Textbox.Text, 100, errorMessage) Then Description_Textbox.ForeColor = Color.Red

        ' Rate (REQUIRED)
        If Not validCurrency("Rate", True, Rate_Textbox.Text, errorMessage) Then Rate_Textbox.ForeColor = Color.Red

        ' Hours (REQUIRED)
        If Not validNumber("Hours", True, Hours_Textbox.Text, errorMessage) Then Hours_Textbox.ForeColor = Color.Red

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
        If Not checkDbConn() Then Exit Sub

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


        ' FIRE ADDBUTTON EVENT IF ARRIVING HERE FROM ADDMASTERTASKLABOR OR ADDINVOICETASKLABOR
        If previousScreen IsNot Nothing Then


            If previousScreen Is addMasterTaskLabor Or previousScreen Is addInvTaskLabor Then
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
    Private Sub LCCombobox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LCComboBox.SelectedIndexChanged, LCComboBox.TextChanged

        ' Ensure that ComboBox is only attempting to initialize values when on proper selected Index
        If LCComboBox.SelectedIndex = -1 Then

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
        LCRow = getDataTableRow(LCDbController.DbDataTable, "LDLC", LCComboBox.Text)

        ' If the lookup DOES find the value in the DataTable
        If LCRow <> -1 Then

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
        InitialLCValues.SetInitialValues(getAllControlsWithTag("dataEditingControl", Me))

        ' First, disable editButton, addButton, enable cancelButton, and disable nav
        editButton.Enabled = False
        addButton.Enabled = False
        cancelButton.Enabled = True
        nav.DisableAll()
        LCComboBox.Enabled = False

        ' Get lastSelected
        If getDataTableRow(LCDbController.DbDataTable, "LDLC", LCComboBox.Text) <> -1 Then
            lastSelected = LCComboBox.Text
        Else
            lastSelected = "Select One"
        End If

        LCComboBox.SelectedIndex = 0

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
                    MessageBox.Show("Successfully deleted " & LCComboBox.Text & " from Labor Codes")
                End If

                ' 2.) RELOAD DATATABLES FROM DATABASE
                If Not loadDataTablesFromDatabase() Then
                    MessageBox.Show("Loading updated information failed; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                ' 3.) REINITIALIZE CONTROLS FROM THIS POINT (still from selection index, however)
                LCComboBox.Items.Clear()
                LCComboBox.Items.Add("Select One")
                For Each row In LCDbController.DbDataTable.Rows
                    LCComboBox.Items.Add(row("LDLC"))
                Next
                LCComboBox.SelectedIndex = 0

                ' 4.) RESTORE USER CONTROLS TO NON-EDITING/SELECTING STATE
                LCComboBox.Enabled = True
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
        InitialLCValues.SetInitialValues(getAllControlsWithTag("dataEditingControl", Me))

        ' Store the last selected item in the ComboBox (in case update fails and it must revert)
        lastSelected = LCComboBox.Text

        ' Disable editButton, disable addButton, enable cancel button, disable navigation, and disable main selection combobox
        editButton.Enabled = False
        addButton.Enabled = False
        cancelButton.Enabled = True
        nav.DisableAll()
        LCComboBox.Enabled = False

        ' Hide/Show the dataViewingControls and dataEditingControls, respectively
        showHide(getAllControlsWithTag("dataViewingControl", Me), 0)
        showHide(getAllControlsWithTag("dataEditingControl", Me), 1)

    End Sub


    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click

        ' Check for changes before cancelling. Don't need function here that calls all, as only working with one datatable's values
        If InitialLCValues.CtrlValuesChanged() Then

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
            LCComboBox.Enabled = True

            ' Show/Hide the dataViewingControls and dataEditingControls, respectively
            showHide(getAllControlsWithTag("dataViewingControl", Me), 1)
            showHide(getAllControlsWithTag("dataEditingControl", Me), 0)

        ElseIf mode = "adding" Then

            ' 1.) SET PartComboBox BACKK TO LAST SELECTED ITEM/INDEX
            LCComboBox.SelectedIndex = LCComboBox.Items.IndexOf(lastSelected)

            ' 2.) IF LAST SELECTED WAS "SELECT ONE", Then simulate functionality from combobox text/selectedIndex changed
            If lastSelected = "Select One" Then
                LCCombobox_SelectedIndexChanged(LCComboBox, New EventArgs())
            End If

            ' 3.) RESTORE USER CONTROLS TO NON-ADDING STATE (only those that are controlled by "adding")
            LCComboBox.Enabled = True
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
                        MessageBox.Show("Successfully updated Labor Codes")
                    End If

                    ' 3.) RELOAD DATATABLES FROM DATABASE
                    If Not loadDataTablesFromDatabase() Then
                        MessageBox.Show("Loading updated information failed; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    ' 4.) REINITIALIZE CONTROLS FROM THIS POINT (still from selection index, however)
                    LCComboBox.Items.Clear()
                    LCComboBox.Items.Add("Select One")
                    For Each row In LCDbController.DbDataTable.Rows
                        LCComboBox.Items.Add(row("LDLC"))
                    Next

                    ' Look up new ComboBox value corresponding to the new value in the datatable and set the selected index of the re-initialized ComboBox accordingly
                    ' If insertion failed, then revert selected back to lastSelected
                    Dim updatedItem As String = getRowValueWithKey(LCDbController.DbDataTable, "LDLC", "LaborCode", LaborCode_Textbox.Text)
                    If updatedItem <> Nothing Then
                        LCComboBox.SelectedIndex = LCComboBox.Items.IndexOf(updatedItem)
                    Else
                        LCComboBox.SelectedIndex = LCComboBox.Items.IndexOf(lastSelected)
                    End If

                    ' dataViewingControl values reinitialized, as well as dataControls hide/show in combobox text/selectedindex change event

                    ' 5.) MOVE UI OUT OF EDITING MODE
                    addButton.Enabled = True
                    cancelButton.Enabled = False
                    saveButton.Enabled = False
                    nav.EnableAll()
                    LCComboBox.Enabled = True

                ElseIf mode = "adding" Then

                    ' 1.) VALIDATE DATAEDITING CONTROLS
                    If Not controlsValid() Then Exit Sub

                    ' 2.) INSERT NEW ROW INTO DATABASE
                    If Not insertAll() Then
                        MessageBox.Show("Insert unsuccessful; Changes not saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    Else
                        MessageBox.Show("Successfully added " & LaborCode_Textbox.Text & " to Labor Codes")
                    End If

                    ' 3.) RELOAD DATATABLES FROM DATABASE
                    If Not loadDataTablesFromDatabase() Then
                        MessageBox.Show("Loading updated information failed; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    ' 4.) REINITIALIZE CONTROLS (based on index of newly inserted value)
                    LCComboBox.Items.Clear()
                    LCComboBox.Items.Add("Select One")
                    For Each row In LCDbController.DbDataTable.Rows
                        LCComboBox.Items.Add(row("LDLC"))
                    Next

                    ' Changing index of main combobox will also initialize respective dataViewing control values
                    ' Lookup and set new selectedIndex based on new value. If insertion failed, then go back to last
                    Dim newItem As Object = getRowValueWithKey(LCDbController.DbDataTable, "LDLC", "LaborCode", LaborCode_Textbox.Text)
                    If newItem <> Nothing Then
                        LCComboBox.SelectedIndex = LCComboBox.Items.IndexOf(newItem)
                    Else
                        LCComboBox.SelectedIndex = LCComboBox.Items.IndexOf(lastSelected)
                    End If


                    ' 5.) MOVE UI OUT OF Adding MODE
                    addButton.Enabled = True
                    cancelButton.Enabled = False
                    saveButton.Enabled = False
                    nav.EnableAll()
                    LCComboBox.Enabled = True

                End If

            Case DialogResult.No
                ' Continue making changes or cancel editing
        End Select


    End Sub


    Private Sub LaborCode_Textbox_TextChanged(sender As Object, e As EventArgs) Handles LaborCode_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        LaborCode_Textbox.ForeColor = DefaultForeColor

        If InitialLCValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private Sub Description_Textbox_TextChanged(sender As Object, e As EventArgs) Handles Description_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        Description_Textbox.ForeColor = DefaultForeColor

        If InitialLCValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private Sub Rate_Textbox_KeyDown(sender As Object, e As KeyEventArgs) Handles Rate_Textbox.KeyDown

        ' Check to see ctrl+A, ctrl+C, or ctrl+V were used. If so, don't worry about checking which Keys Pressed
        If ((e.KeyCode = Keys.A And e.Control) Or (e.KeyCode = Keys.C And e.Control) Or (e.KeyCode = Keys.V And e.Control)) Then
            allowedKeystroke = True
        End If

    End Sub

    Private Sub Rate_Textbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Rate_Textbox.KeyPress

        ' If certain keystroke exceptions allowed throuhg, then skip input validation here
        If allowedKeystroke Then
            allowedKeystroke = False
            Exit Sub
        End If

        If Not currencyInputValid(Rate_Textbox, e.KeyChar) Then
            e.KeyChar = Chr(0)
            e.Handled = True
        End If

    End Sub

    Private Sub Rate_Textbox_TextChanged(sender As Object, e As EventArgs) Handles Rate_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        Rate_Textbox.ForeColor = DefaultForeColor

        ' Handles pasting in invalid values/strings
        Dim lastValidIndex As Integer = allValidChars(Rate_Textbox.Text, "1234567890.")
        If lastValidIndex <> -1 Then
            Rate_Textbox.Text = Rate_Textbox.Text.Substring(0, lastValidIndex)
            Rate_Textbox.SelectionStart = lastValidIndex
        End If

        InitializeAmountTextbox()

        If InitialLCValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private Sub Hours_Textbox_KeyDown(sender As Object, e As KeyEventArgs) Handles Hours_Textbox.KeyDown

        ' Check to see ctrl+A, ctrl+C, or ctrl+V were used. If so, don't worry about checking which Keys Pressed
        If ((e.KeyCode = Keys.A And e.Control) Or (e.KeyCode = Keys.C And e.Control) Or (e.KeyCode = Keys.V And e.Control)) Then
            allowedKeystroke = True
        End If

    End Sub

    Private Sub Hours_Textbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Hours_Textbox.KeyPress

        ' If certain keystroke exceptions allowed throuhg, then skip input validation here
        If allowedKeystroke Then
            allowedKeystroke = False
            Exit Sub
        End If

        If Not numericInputValid(Hours_Textbox, e.KeyChar) Then
            e.KeyChar = Chr(0)
            e.Handled = True
        End If

    End Sub

    Private Sub Hours_Textbox_TextChanged(sender As Object, e As EventArgs) Handles Hours_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        Hours_Textbox.ForeColor = DefaultForeColor

        ' Handles pasting in invalid values/strings
        Dim lastValidIndex As Integer = allValidChars(Hours_Textbox.Text, "1234567890.")
        If lastValidIndex <> -1 Then
            Hours_Textbox.Text = Hours_Textbox.Text.Substring(0, lastValidIndex)
            Hours_Textbox.SelectionStart = lastValidIndex
        End If

        InitializeAmountTextbox()

        If InitialLCValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub



    Private Sub returnButton_Click(sender As Object, e As EventArgs) Handles returnButton.Click

        ' Will need to call reinitialization Function here to reinitialize elements on addMasterTaskLabor
        If Not MeClosed Then

            ' Only want to ask them if the ctrl values are currently being edited AND they're values have changed
            If LaborCode_Textbox.Visible And InitialLCValues.CtrlValuesChanged() Then

                Dim decision As DialogResult = MessageBox.Show("Return without saving changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If decision = DialogResult.No Then
                    Exit Sub
                Else

                    If previousScreen Is addMasterTaskLabor Then
                        ' Call REINITIALIZATION HERE
                        If Not addMasterTaskLabor.reInitializeLaborCodes() Then
                            MessageBox.Show("Reloading of Add Task Labor unsuccessful; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            saveButton.Enabled = False
                            Exit Sub
                        End If
                    ElseIf previousScreen Is addInvTaskLabor Then
                        ' Call REINITIALIZATION HERE
                        If Not addInvTaskLabor.reInitializeLaborCodes() Then
                            MessageBox.Show("Reloading of Add Task Labor unsuccessful; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            saveButton.Enabled = False
                            Exit Sub
                        End If
                    End If

                    MeClosed = True
                    changeScreen(previousScreen, Me)
                    previousScreen = Nothing

                End If

            Else

                If previousScreen Is addMasterTaskLabor Then
                    'Call REINITIALIZATION HERE
                    If Not addMasterTaskLabor.reInitializeLaborCodes() Then
                        MessageBox.Show("Reloading of Add Task Labor unsuccessful; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        saveButton.Enabled = False
                        Exit Sub
                    End If
                ElseIf previousScreen Is addInvTaskLabor Then
                    ' Call REINITIALIZATION HERE
                    If Not addInvTaskLabor.reInitializeLaborCodes() Then
                        MessageBox.Show("Reloading of Add Task Labor unsuccessful; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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


    Private Sub laborCodeMaintenance_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        If Not MeClosed Then

            If LaborCode_Textbox.Visible And InitialLCValues.CtrlValuesChanged() Then

                Dim decision As DialogResult = MessageBox.Show("Exit without saving changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If decision = DialogResult.No Then
                    e.Cancel = True
                    Exit Sub
                Else
                    ' If coming from another screen, then change back to that screen
                    If previousScreen IsNot Nothing Then

                        If previousScreen Is addMasterTaskLabor Then
                            'Call REINITIALIZATION HERE
                            If Not addMasterTaskLabor.reInitializeLaborCodes() Then
                                MessageBox.Show("Reloading of Add Task Labor unsuccessful; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                saveButton.Enabled = False
                                Exit Sub
                            End If
                        ElseIf previousScreen Is addInvTaskLabor Then
                            'Call REINITIALIZATION HERE
                            'If Not addMasterTaskLabor.reInitializeLaborCodes() Then
                            '    MessageBox.Show("Reloading of Add Task Labor unsuccessful; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            '    saveButton.Enabled = False
                            '    Exit Sub
                            'End If
                        End If

                        MeClosed = True
                        changeScreen(previousScreen, Me)
                        previousScreen = Nothing
                        ' Otherwise, just exit the form
                    Else
                        MeClosed = True
                        Me.Close()
                    End If

                End If

            Else

                ' If coming from another screen, then change back to that screen
                If previousScreen IsNot Nothing Then

                    If previousScreen Is addMasterTaskLabor Then
                        'Call REINITIALIZATION HERE
                        If Not addMasterTaskLabor.reInitializeLaborCodes() Then
                            MessageBox.Show("Reloading of Add Task Labor unsuccessful; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            saveButton.Enabled = False
                            Exit Sub
                        End If
                    ElseIf previousScreen Is addInvTaskLabor Then
                        'Call REINITIALIZATION HERE
                        'If Not addMasterTaskLabor.reInitializeLaborCodes() Then
                        '    MessageBox.Show("Reloading of Add Task Labor unsuccessful; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        '    saveButton.Enabled = False
                        '    Exit Sub
                        'End If
                    End If

                    MeClosed = True
                    changeScreen(previousScreen, Me)
                    previousScreen = Nothing
                    ' Otherwise, just exit the form
                Else
                    MeClosed = True
                    Me.Close()
                End If

            End If

        End If

    End Sub


End Class