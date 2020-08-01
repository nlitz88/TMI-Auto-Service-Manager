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
            If LaborCode <> Nothing Then
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


    Private Sub addButton_Click(sender As Object, e As EventArgs) Handles addButton.Click

        mode = "adding"

        ' Initialize values for dataEditingControls
        clearControls(getAllControlsWithTag("dataEditingControl", Me))
        ' Establish initial values. Doing this here, as unless changes are about to be made, we don't need to set initial values
        InitialLCValues.SetInitialValues(getAllControlsWithTag("dataEditingControl", Me))

        ' First, disable editButton, addButton, enable cancelButton, and disable nav
        editButton.Enabled = False
        addButton.Enabled = False
        cancelButton.Enabled = True
        nav.DisableAll()
        LCComboBox.Enabled = False


        lastSelected = LCComboBox.Text
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
        InitializeAllDataEditingControls()
        ' Establish initial values. Doing this here, as unless changes are about to be made, we don't need to set initial values
        InitialLCValues.SetInitialValues(getAllControlsWithTag("dataEditingControl", Me))

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

        ' Check for changes before cancelling. Don't need function here that calls all, as only working with one datatable
        If InitialLCValues.CtrlValuesChanged() Then

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
                        LCComboBox.Enabled = True
                        ' Show/Hide the dataViewingControls and dataEditingControls, respectively
                        showHide(getAllControlsWithTag("dataViewingControl", Me), 1)
                        showHide(getAllControlsWithTag("dataEditingControl", Me), 0)

                    ElseIf mode = "adding" Then

                        ' 1.) CLEAR DATA EDITING CONTROLS
                        clearControls(getAllControlsWithTag("dataEditingControl", Me))
                        'showHide(getAllControlsWithTag("dataEditingControl", Me), 0)

                        ' 2.) SET LCComboBox BACKK TO LAST SELECTED ITEM/INDEX
                        LCComboBox.SelectedIndex = LCComboBox.Items.IndexOf(lastSelected)
                        ' If this is not select one, because it changed from the orig to select one, and now back to orig,
                        ' the .textChanged event for the combo box will take care of reinitializing and showing the dataViewingControls

                        ' 3.) IF LAST SELECTED WAS "SELECT ONE", Then simulate functionality from combobox text/selectedIndex changed
                        If lastSelected = "Select One" Then
                            LCCombobox_SelectedIndexChanged(LCComboBox, New EventArgs())
                        End If

                        ' 4.) RESTORE USER CONTROLS TO NON-ADDING STATE (only those that are controlled by "adding")
                        LCComboBox.Enabled = True
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
                LCComboBox.Enabled = True
                ' Show/Hide the dataViewingControls and dataEditingControls, respectively
                showHide(getAllControlsWithTag("dataViewingControl", Me), 1)
                showHide(getAllControlsWithTag("dataEditingControl", Me), 0)

            ElseIf mode = "adding" Then

                ' 1.) CLEAR DATA EDITING CONTROLS
                clearControls(getAllControlsWithTag("dataEditingControl", Me))
                'showHide(getAllControlsWithTag("dataEditingControl", Me), 0)

                ' 2.) SET LCComboBox BACK TO LAST SELECTED ITEM/INDEX
                LCComboBox.SelectedIndex = LCComboBox.Items.IndexOf(lastSelected)
                ' If this is not select one, because it changed from the orig to select one, and now back to orig,
                ' the .textChanged event for the combo box will take care of reinitializing and showing the dataViewingControls

                ' 3.) IF LAST SELECTED WAS "SELECT ONE", Then simulate functionality from combobox text/selectedIndex changed
                If lastSelected = "Select One" Then
                    LCCombobox_SelectedIndexChanged(LCComboBox, New EventArgs())
                End If

                ' 4.) RESTORE USER CONTROLS TO NON-ADDING STATE (only those that are controlled by "adding")
                LCComboBox.Enabled = True
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

    ' Later, add textchanged subs for various textboxes.
    ' For Rate and Hours changed events, if it's a valid Rate and valid hour amount, then calculate amount and initialize it's value
    ' And remember to do this calculation on initialization as well (maybe make own function for this, as that's kind of how it works
    ' for the zipcode combobox on companymaster.


End Class