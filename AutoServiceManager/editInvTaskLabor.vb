Public Class editInvTaskLabor

    ' DataTable that will maintain the DataTable passed to it from masterTaskMainentance
    Private InvTaskLaborDbController As New DbControl()
    Private InvTaskLaborRow As Integer
    ' New Database control instance for updating, inserting, and deleting
    Private CRUD As New DbControl()

    ' Initialize instance(s) of initialValues class
    Private InitialLaborValues As New InitialValues()

    'Variable to keep track of whether form fully loaded or not
    Private valuesInitialized As Boolean = True

    ' Variable that allows certain keystrokes through restricted fields
    Private allowedKeystroke As Boolean = False

    ' Boolean to keep track of whether or not this form has been closed
    Private MeClosed As Boolean = False




    ' ***************** INITIALIZATION AND CONFIGURATION SUBS *****************


    ' No need for dataTable loading function here, as we are only going to use the dataTable associated with the controller that we receive from invoiceTasks


    ' Sub that initializes all dataEditingcontrols corresponding with values from the MasterTaskLabor DataTable
    Private Sub InitializeInvTaskLaborDataEditingControls()

        initializeControlsFromRow(InvTaskLaborDbController.DbDataTable, InvTaskLaborRow, "dataEditingControl", "_", Me)

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
        InitializeInvTaskLaborDataEditingControls()
        ' Then, format dataEditingControls
        formatDataEditingControls()
        ' Then, re-initialize and format any calculation based values
        InitializeAmountTextbox()
        ' Set forecolor if not already initially default
        setForeColor(getAllControlsWithTag("dataEditingControl", Me), DefaultForeColor)

    End Sub




    ' ***************** CRUD SUBS *****************


    ' Function that will update row in InvParts (using function overload that uses DataTable values as keys)
    Private Function updateInvTaskLabor() As Boolean

        Dim DT As DataTable = InvTaskLaborDbController.DbDataTable

        ' Make list of excluded controls here
        Dim excludedControls As New List(Of Control) From {LaborCode_Textbox}

        updateTable(CRUD, DT, InvTaskLaborRow, New List(Of String), "MasterTaskLabor", "_", "dataEditingControl", Me, excludedControls)

        If CRUD.HasException() Then Return False

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

        ' Get TaskLaborDbController here from invoiceTasks
        InvTaskLaborDbController = invoiceTasks.GetInvTaskLaborDbController()
        InvTaskLaborRow = invoiceTasks.GetInvTaskLaborRow()

        InvoiceValue.Text = invoices.GetINID
        TaskValue.Text = invoiceTasks.GetTask()

        ' For the editing forms, we won't be initializing our dataEditingControls from a selection. Instead, we will initialize them just once on load
        valuesInitialized = False
        ' Initialize all DataEditing Controls
        InitializeAllDataEditingControls()
        valuesInitialized = True
        ' Establish initial values here, as we are exclusively editing on this form
        InitialLaborValues.SetInitialValues(getAllControlsWithTag("dataEditingControl", Me))

    End Sub



    Private Sub editInvTaskLabor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub




    ' **************** CONTROL SUBS ****************


    Private Sub editInvTaskLabor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If Not MeClosed Then

            If InitialLaborValues.CtrlValuesChanged() Then

                Dim decision As DialogResult = MessageBox.Show("Cancel without saving changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

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

            If InitialLaborValues.CtrlValuesChanged() Then

                Dim decision As DialogResult = MessageBox.Show("Cancel without saving changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

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

        ' No confirmation for edits at this time. May implement in the future.

        ' 1.) VALIDATE DATAEDITING CONTROLS
        If Not controlsValid() Then Exit Sub

        ' 2.) WRITE CHANGES TO DATABASE TABLE
        If Not updateInvTaskLabor() Then
            MessageBox.Show("Update unsuccessful; Changes not saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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




    Private Sub LaborDescription_Textbox_TextChanged(sender As Object, e As EventArgs) Handles LaborDescription_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        LaborDescription_Textbox.ForeColor = DefaultForeColor

        If InitialLaborValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

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

        If InitialLaborValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

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

        If InitialLaborValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


End Class