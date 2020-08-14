Imports System.ComponentModel

Public Class editMasterTaskLabor

    ' DataTable that will maintain the DataTable passed to it from masterTaskMainentance
    Private TaskLaborDbController As New DbControl()
    Private TaskLaborRow As Integer
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


    ' No need for dataTable loading function here, as we are only going to use the dataTable associate with the controller that we receive


    ' Sub that initializes all dataEditingcontrols corresponding with values from the MasterTaskLabor DataTable
    Private Sub InitializeTaskLaborDataEditingControls()

        initializeControlsFromRow(TaskLaborDbController.DbDataTable, TaskLaborRow, "dataEditingControl", "_", Me)

    End Sub


    ' Sub that will initialize/Calculate Amount Cost based on the product of Rate and Hours
    Private Sub InitializeAmountTextbox()

        ' First, Validate values that calculation is based on before attempting to parse and calculate
        If validCurrency("Rate", True, Rate_Textbox.Text, String.Empty) And validNumber("Hours", True, Hours_Textbox.Text, String.Empty) Then

            Dim Rate As Decimal = Convert.ToDecimal(Rate_Textbox.Text)
            Dim Hours As Decimal = Convert.ToDecimal(Hours_Textbox.Text)
            Dim product As Decimal = Rate * Hours

            ' Then, assign and format calculated product
            Amount_Textbox.Text = String.Format("{0:0.00}", product)

        Else
            Amount_Textbox.Text = String.Empty
        End If

    End Sub


    ' Sub that will call formatting functions to add respective formats to already INITIALIZED DATAEDITINGCONTROLS (i.e. phone numbers, currency, etc.).
    Private Sub formatDataEditingControls()

        Rate_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(Rate_Textbox.Text))

    End Sub


    ' Sub that handles all initialization for dataEditingControls
    Private Sub InitializeAllDataEditingControls()

        ' Automated initializations
        InitializeTaskLaborDataEditingControls()
        ' Then, format dataEditingControls
        formatDataEditingControls()
        ' Then, re-initialize and format any calculation based values
        InitializeAmountTextbox()
        ' Set forecolor if not already initially default
        setForeColor(getAllControlsWithTag("dataEditingControl", Me), DefaultForeColor)

    End Sub




    ' ***************** CRUD SUBS *****************


    ' Function that will update row in MasterTaskParts (using function overload that uses DataTable values as keys)
    Private Function updateMasterTaskLabor() As Boolean

        Dim DT As DataTable = TaskLaborDbController.DbDataTable

        ' Make list of excluded controls here
        Dim excludedControls As New List(Of Control) From {LaborCode_Textbox}

        updateTable(CRUD, DT, TaskLaborRow, New List(Of String), "MasterTaskLabor", "_", "dataEditingControl", Me, excludedControls)

        If CRUD.HasException() Then Return False

        Return True

    End Function




    ' **************** VALIDATION SUBS ****************


    ' Sub that runs validation for all form controls. Also handles error reporting
    Private Function controlsValid() As Boolean

        Dim errorMessage As String = String.Empty

        ' Use "Required" parameter to control whether or not a Null string value will cause an error to be reported


        ' Description
        If Not isValidLength("Description", False, Description_Textbox.Text, 100, errorMessage) Then Description_Textbox.ForeColor = Color.Red

        ' Rate
        If Not validCurrency("Rate", False, Rate_Textbox.Text, errorMessage) Then Rate_Textbox.ForeColor = Color.Red

        ' Hours
        If Not validNumber("Hours", False, Hours_Textbox.Text, errorMessage) Then Hours_Textbox.ForeColor = Color.Red


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

        ' Get TaskLaborDbController here from masterTaskMaintenance
        TaskLaborDbController = masterTaskMaintenance.GetTaskLaborDbController()
        TaskLaborRow = masterTaskMaintenance.GetTaskLaborRow()
        TaskTextbox.Text = masterTaskMaintenance.GetTask()

        ' For the editing forms, we won't be initializing our dataEditingControls from a selection. Instead, we will initialize them just once on load
        valuesInitialized = False
        ' Initialize all DataEditing Controls
        InitializeAllDataEditingControls()
        valuesInitialized = True
        ' Establish initial values here, as we are exclusively editing on this form
        InitialLaborValues.SetInitialValues(getAllControlsWithTag("dataEditingControl", Me))

    End Sub


    Private Sub editMasterTaskLabor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub




    ' **************** CONTROL SUBS ****************


    Private Sub editMasterTaskLabor_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        If Not MeClosed Then

            If InitialLaborValues.CtrlValuesChanged() Then

                Dim decision As DialogResult = MessageBox.Show("Cancel without saving changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If decision = DialogResult.No Then
                    e.Cancel = True
                    Exit Sub
                Else
                    MeClosed = True
                    changeScreen(masterTaskMaintenance, Me)
                End If

            Else

                MeClosed = True
                changeScreen(masterTaskMaintenance, Me)

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
                    changeScreen(masterTaskMaintenance, Me)
                End If

            Else

                MeClosed = True
                changeScreen(masterTaskMaintenance, Me)

            End If

        End If

    End Sub


    Private Sub saveButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click

        ' No confirmation for edits at this time. May implement in the future.

        ' 1.) VALIDATE DATAEDITING CONTROLS
        If Not controlsValid() Then Exit Sub

        ' 2.) WRITE CHANGES TO DATABASE TABLE
        If Not updateMasterTaskLabor() Then
            MessageBox.Show("Update unsuccessful; Changes not saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' 3.) If this is successful, then:
        '       a.) Reinitialize Dependents on masterTaskMaintenance
        '       b.) If that is successful, then change screen
        If Not masterTaskMaintenance.reinitializeDependents() Then
            MessageBox.Show("Reloading of Master Task List Unsuccessful; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            saveButton.Enabled = False
            Exit Sub
        End If

        MeClosed = True
        changeScreen(masterTaskMaintenance, Me)

    End Sub



    Private Sub Description_Textbox_TextChanged(sender As Object, e As EventArgs) Handles Description_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        Description_Textbox.ForeColor = DefaultForeColor

        If InitialLaborValues.CtrlValuesChanged() Then
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

        ' If certain keystroke exceptions allowed through, then skip input validation here
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

        If InitialLaborValues.CtrlValuesChanged() Then
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

        ' If certain keystroke exceptions allowed through, then skip input validation here
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

        If InitialLaborValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


End Class