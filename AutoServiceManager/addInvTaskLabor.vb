Public Class addInvTaskLabor

    ' New Database Control instance for LaborCodes DataTable
    Private LaborCodesDbController As New DbControl()
    Private LaborCodesRow As Integer

    ' Variable to maintain InvNbr, TaskNbr, and TaskID of the labor code that is to be added
    Private InvId As Long
    Private InvTaskNbr As Integer
    Private TaskId As Integer

    ' New Database control instance for updating, inserting, and deleting
    Private CRUD As New DbControl()

    ' Variable to track whether or not current selection is valid.
    ' In this form, this will be used in place of initialvalues to determine whether or not prompt user before cancelling/Closing
    Private validSelection As Boolean

    'Variable to keep track of whether form fully loaded or not
    Private valuesInitialized As Boolean = True

    ' Variable that allows certain keystrokes through restricted fields
    Private allowedKeystroke As Boolean = False

    ' Boolean to keep track of whether or not this form has been closed
    Private MeClosed As Boolean = False




    ' ***************** INITIALIZATION AND CONFIGURATION SUBS *****************


    ' Function that loads LaborCodes DataTable from Database
    Private Function loadLaborCodesDataTable() As Boolean

        LaborCodesDbController.ExecQuery("SELECT lc.Description + ' - ' + lc.LaborCode as LDLC, lc.LaborCode, lc.Description as LaborDescription, lc.Rate as LaborRate, lc.Hours as LaborHours, lc.Amount as LaborAmount " &
                                         "FROM LaborCodes lc ORDER BY lc.Description ASC")
        If LaborCodesDbController.HasException() Then Return False

        Return True

    End Function


    ' Sub that initializes LaborCodesComboBox
    Private Sub InitializeLaborCodesComboBox()

        LaborCodesComboBox.BeginUpdate()
        LaborCodesComboBox.Items.Clear()
        LaborCodesComboBox.Items.Add("Select One")
        For Each row In LaborCodesDbController.DbDataTable.Rows
            LaborCodesComboBox.Items.Add(row("LDLC"))
        Next
        LaborCodesComboBox.EndUpdate()

    End Sub


    ' Sub that initializes all dataEditingControls corresponding with values in LaborCodes DataTable
    Private Sub InitializeLaborCodesDataEditingControls()

        initializeControlsFromRow(LaborCodesDbController.DbDataTable, LaborCodesRow, "dataEditingControl", "_", Me)

    End Sub


    ' Sub that will initialize/Calculate Amount Cost based on the product of Rate and Hours
    Private Sub InitializeAmountTextbox()

        ' First, Validate values that calculation is based on before attempting to parse and calculate
        If validCurrency("Rate", True, LaborRate_Textbox.Text, String.Empty) And validNumber("Hours", True, LaborHours_Textbox.Text, String.Empty) Then

            Dim Rate As Decimal = Convert.ToDecimal(LaborRate_Textbox.Text)
            Dim Hours As Decimal = Convert.ToDecimal(LaborHours_Textbox.Text)
            Dim product As Decimal = Rate * Hours

            ' Then, assign and format calculated product
            LaborAmount_Textbox.Text = String.Format("{0:0.00}", product)

        Else
            LaborAmount_Textbox.Text = String.Empty
        End If

    End Sub


    ' Sub that will call formatting functions to add respective formats to already INITIALIZED DATAEDITINGCONTROLS (i.e. phone numbers, currency, etc.).
    Private Sub formatDataEditingControls()

        LaborRate_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(LaborRate_Textbox.Text))

    End Sub


    ' Sub that handles all initialization for dataEditingControls
    Private Sub InitializeAllDataEditingControls()

        ' Automated initializations
        InitializeLaborCodesDataEditingControls()
        ' Then, format dataEditingControls
        formatDataEditingControls()
        ' Then, re-initialize and format any calculation based values
        InitializeAmountTextbox()
        ' Set forecolor if not already initially default
        setForeColor(getAllControlsWithTag("dataEditingControl", Me), DefaultForeColor)

    End Sub


    ' Public Function called after LaborCodes table has been changed from LaborCodes Maintenance Form. LaborCodes DataTable and dependent controls are re-initialized
    Public Function reInitializeLaborCodes() As Boolean

        ' LOAD DATATABLES FROM DATABASE INITIALLY
        If Not loadLaborCodesDataTable() Then
            MessageBox.Show("Failed to connect to database; Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        ' Then, initialize PartComboBox
        InitializeLaborCodesComboBox()
        LaborCodesComboBox.SelectedIndex = 0

        Return True

    End Function





    ' ***************** CRUD SUBS *****************


    Private Function InsertMasterTaskLabor() As Boolean

        ' Values that will automatically be grabbed from controls and inserted:
        '   LaborCode, LaborDescription, LaborRate, LaborHours, LaborAmount
        ' In adddition to these, we must also insert (into the row) these newly associated values:
        '   InvNbr, TaskNbr, TaskId

        ' No exclusions, just additionalValues
        Dim additionalValues As New List(Of AdditionalValue) From {
            New AdditionalValue("InvNbr", GetType(Long), InvId),
            New AdditionalValue("TaskNbr", GetType(Integer), InvTaskNbr),
            New AdditionalValue("TaskID", GetType(Integer), TaskId)
        }

        insertRow(CRUD, LaborCodesDbController.DbDataTable, "InvLabor", "_", "dataEditingControl", Me, additionalValues)

        Return True

    End Function




    ' **************** VALIDATION SUBS ****************


    ' Sub that runs validation for all form controls. Also handles error reporting
    Private Function controlsValid() As Boolean

        Dim errorMessage As String = String.Empty

        ' Use "Required" parameter to control whether or not a Null string value will cause an error to be reported


        ' Description
        If Not isValidLength("Description", False, LaborDescription_Textbox.Text, 100, errorMessage) Then LaborDescription_Textbox.ForeColor = Color.Red

        ' Rate
        If Not validCurrency("Rate", False, LaborRate_Textbox.Text, errorMessage) Then LaborRate_Textbox.ForeColor = Color.Red

        ' Hours
        If Not validNumber("Hours", False, LaborHours_Textbox.Text, errorMessage) Then LaborHours_Textbox.ForeColor = Color.Red


        ' Check if any invalid input has been found
        If Not String.IsNullOrEmpty(errorMessage) Then

            MessageBox.Show(errorMessage, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False

        End If

        Return True

    End Function





    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        InvId = invoices.GetInvId()
        InvTaskNbr = invoiceTasks.GetInvTaskNbr()

        InvoiceValue.Text = invoices.GetINID()
        TaskValue.Text = invoiceTasks.GetTask()

        ' TEST DATABASE CONNECTION FIRST
        If Not checkDbConn() Then Exit Sub

        ' LOAD DATATABLES FROM DATABASE INITIALLY
        If Not loadLaborCodesDataTable() Then
            MessageBox.Show("Failed to connect to database; Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Then, initialize LaborCodesComboBox
        InitializeLaborCodesComboBox()
        LaborCodesComboBox.SelectedIndex = 0

    End Sub

    Private Sub addInvTaskLabor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub




    ' **************** CONTROL SUBS ****************


    Private Sub LaborCodesComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LaborCodesComboBox.SelectedIndexChanged, LaborCodesComboBox.TextChanged

        ' Ensure that LaborCodesComboBox is only attempting to initialize values when on proper selected Index
        If LaborCodesComboBox.SelectedIndex = -1 Then

            ' Have all labels and corresponding values hidden
            showHide(getAllControlsWithTag("dataLabel", Me), 0)
            showHide(getAllControlsWithTag("dataEditingControl", Me), 0)

            ' If no valid selection has been made, then they have nothing to save
            saveButton.Enabled = False
            validSelection = False

            Exit Sub

        End If

        ' First, Lookup newly changed value in respective dataTable to see if the selected value exists And Is valid
        LaborCodesRow = getDataTableRow(LaborCodesDbController.DbDataTable, "LDLC", LaborCodesComboBox.Text)

        ' If this query DOES return a valid row index, then initialize respective controls
        If LaborCodesRow <> -1 Then

            ' Initialize corresponding controls from DataTable values
            valuesInitialized = False
            InitializeAllDataEditingControls()
            valuesInitialized = True

            ' Show labels and corresponding values
            showHide(getAllControlsWithTag("dataLabel", Me), 1)
            showHide(getAllControlsWithTag("dataEditingControl", Me), 1)

            ' If a valid selection is made, then they can save right away without making any changes.
            saveButton.Enabled = True
            validSelection = True


            'If it does = -1, that means that value Is either "Select one" Or some other anomoly
        Else

            ' Have all labels and corresponding values hidden
            showHide(getAllControlsWithTag("dataLabel", Me), 0)
            showHide(getAllControlsWithTag("dataEditingControl", Me), 0)

            ' If no valid selection has been made, then they have nothing to save
            saveButton.Enabled = False
            validSelection = False


        End If

    End Sub







    Private Sub addInvTaskLabor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If Not MeClosed Then

            If validSelection Then

                Dim decision As DialogResult = MessageBox.Show("Cancel without adding labor code?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If decision = DialogResult.No Then
                    e.Cancel = True
                    Exit Sub
                Else
                    MeClosed = True
                    changeScreen(invoiceTasks, Me)
                End If

            Else

                MeClosed = True
                changeScreen(invoiceTasks, Me)

            End If

        End If

    End Sub


    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click

        If Not MeClosed Then

            If validSelection Then

                Dim decision As DialogResult = MessageBox.Show("Cancel without adding labor code?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If decision = DialogResult.No Then
                    Exit Sub
                Else
                    MeClosed = True
                    changeScreen(invoiceTasks, Me)
                End If

            Else

                MeClosed = True
                changeScreen(invoiceTasks, Me)

            End If

        End If

    End Sub


    Private Sub saveButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click

        ' No confirmation for additions at this time. May implement in the future.

        ' 1.) VALIDATE DATAEDITING CONTROLS
        If Not controlsValid() Then Exit Sub

        ' 2.) WRITE CHANGES TO DATABASE TABLE
        If Not InsertMasterTaskLabor() Then
            MessageBox.Show("Insert unsuccessful; Changes not saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' 3.) If this is successful, then:
        '       a.) Reinitialize Dependents on masterTaskMaintenance
        '       b.) If that is successful, then change screen
        If Not invoiceTasks.reinitializeDependents() Then
            MessageBox.Show("Reloading of invoice tasks Unsuccessful; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            saveButton.Enabled = False
            Exit Sub
        End If

        MeClosed = True
        changeScreen(invoiceTasks, Me)

    End Sub


    Private Sub newLaborButton_Click(sender As Object, e As EventArgs) Handles newLaborButton.Click

        previousScreen = Me
        changeScreenHide(laborCodeMaintenance, previousScreen)

    End Sub


    Private Sub LaborDescription_Textbox_TextChanged(sender As Object, e As EventArgs) Handles LaborDescription_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        LaborDescription_Textbox.ForeColor = DefaultForeColor

    End Sub

    Private Sub LaborRate_Textbox_KeyDown(sender As Object, e As KeyEventArgs) Handles LaborRate_Textbox.KeyDown

        ' Check to see ctrl+A, ctrl+C, or ctrl+V were used. If so, don't worry about checking which Keys Pressed
        If ((e.KeyCode = Keys.A And e.Control) Or (e.KeyCode = Keys.C And e.Control) Or (e.KeyCode = Keys.V And e.Control)) Then
            allowedKeystroke = True
        End If

    End Sub


    Private Sub LaborRate_Textbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles LaborRate_Textbox.KeyPress

        ' If certain keystroke exceptions allowed through, then skip input validation here
        If allowedKeystroke Then
            allowedKeystroke = False
            Exit Sub
        End If

        If Not currencyInputValid(LaborRate_Textbox, e.KeyChar) Then
            e.KeyChar = Chr(0)
            e.Handled = True
        End If

    End Sub

    Private Sub LaborRate_Textbox_TextChanged(sender As Object, e As EventArgs) Handles LaborRate_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        LaborRate_Textbox.ForeColor = DefaultForeColor

        ' Handles pasting in invalid values/strings
        Dim lastValidIndex As Integer = allValidChars(LaborRate_Textbox.Text, "1234567890.")
        If lastValidIndex <> -1 Then
            LaborRate_Textbox.Text = LaborRate_Textbox.Text.Substring(0, lastValidIndex)
            LaborRate_Textbox.SelectionStart = lastValidIndex
        End If

        InitializeAmountTextbox()

    End Sub


    Private Sub LaborHours_Textbox_KeyDown(sender As Object, e As KeyEventArgs) Handles LaborHours_Textbox.KeyDown

        ' Check to see ctrl+A, ctrl+C, or ctrl+V were used. If so, don't worry about checking which Keys Pressed
        If ((e.KeyCode = Keys.A And e.Control) Or (e.KeyCode = Keys.C And e.Control) Or (e.KeyCode = Keys.V And e.Control)) Then
            allowedKeystroke = True
        End If

    End Sub

    Private Sub LaborHours_Textbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles LaborHours_Textbox.KeyPress

        ' If certain keystroke exceptions allowed through, then skip input validation here
        If allowedKeystroke Then
            allowedKeystroke = False
            Exit Sub
        End If

        If Not numericInputValid(LaborHours_Textbox, e.KeyChar) Then
            e.KeyChar = Chr(0)
            e.Handled = True
        End If

    End Sub

    Private Sub LaborHours_Textbox_TextChanged(sender As Object, e As EventArgs) Handles LaborHours_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        LaborHours_Textbox.ForeColor = DefaultForeColor

        ' Handles pasting in invalid values/strings
        Dim lastValidIndex As Integer = allValidChars(LaborHours_Textbox.Text, "1234567890.")
        If lastValidIndex <> -1 Then
            LaborHours_Textbox.Text = LaborHours_Textbox.Text.Substring(0, lastValidIndex)
            LaborHours_Textbox.SelectionStart = lastValidIndex
        End If

        InitializeAmountTextbox()

    End Sub



End Class