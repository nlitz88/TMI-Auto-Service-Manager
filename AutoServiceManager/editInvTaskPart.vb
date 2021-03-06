﻿Public Class editInvTaskPart

    ' DataTable that will maintain the DataTable passed to it from InvoiceTasks
    Private InvTaskPartsDbController As New DbControl()
    Private InvTaskPartsRow As Integer
    ' New Database control instance for updating, inserting, and deleting
    Private CRUD As New DbControl()

    ' Initialize instance(s) of initialValues class
    Private InitialPartValues As New InitialValues()

    'Variable to keep track of whether form fully loaded or not
    Private valuesInitialized As Boolean = True

    ' Variable that allows certain keystrokes through restricted fields
    Private allowedKeystroke As Boolean = False

    ' Boolean to keep track of whether or not this form has been closed
    Private MeClosed As Boolean = False




    ' ***************** INITIALIZATION AND CONFIGURATION SUBS *****************


    ' No need for dataTable loading function here, as we are only going to use the dataTable associate with the controller that we receive


    ' Sub that initializes all dataEditingcontrols corresponding with values from the InvParts datatable
    Private Sub InitializeInvTaskPartsDataEditingControls()

        initializeControlsFromRow(InvTaskPartsDbController.DbDataTable, InvTaskPartsRow, "dataEditingControl", "_", Me)

    End Sub


    ' Sub that will initialize/Calculate PartAmount Cost based on the product of the Quantity and Unit Price
    Private Sub InitializePartAmountTextbox()

        ' First, Validate values that calculation is based on before attempting to parse and calculate
        If validNumber("Quantity", True, Qty_Textbox.Text, String.Empty, True) And validCurrency("Unit Price", True, PartPrice_Textbox.Text, String.Empty) Then

            Dim Quantity As Decimal = Convert.ToDecimal(Qty_Textbox.Text)
            Dim Price As Decimal = Convert.ToDecimal(PartPrice_Textbox.Text)
            Dim product As Decimal = Quantity * Price

            ' Then, assign and format calculated product
            PartAmount_Textbox.Text = String.Format("{0:0.00}", product)

        Else
            PartAmount_Textbox.Text = String.Empty
        End If

    End Sub


    ' Sub that will call formatting functions to add respective formats to already INITIALIZED DATAEDITINGCONTROLS (i.e. phone numbers, currency, etc.).
    Private Sub formatDataEditingControls()

        PartPrice_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(PartPrice_Textbox.Text))
        ListPrice_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(ListPrice_Textbox.Text))

    End Sub


    ' Sub that handles all initialization for dataEditingControls
    Private Sub InitializeAllDataEditingControls()

        ' Automated initializations
        InitializeInvTaskPartsDataEditingControls()
        ' Then, format dataEditingControls
        formatDataEditingControls()
        ' Then, re-initialize and format any calculation based values
        InitializePartAmountTextbox()
        ' Set forecolor if not already initially default
        setForeColor(getAllControlsWithTag("dataEditingControl", Me), DefaultForeColor)

    End Sub




    ' ***************** CRUD SUBS *****************


    ' Function that will update row in InvParts (using function overload that uses DataTable values as keys)
    Private Function updateInvParts() As Boolean

        Dim DT As DataTable = InvTaskPartsDbController.DbDataTable

        ' Make list of excluded controls here
        Dim excludedControls As New List(Of Control) From {PartNbr_Textbox}

        updateTable(CRUD, DT, InvTaskPartsRow, New List(Of String), "InvParts", "_", "dataEditingControl", Me, excludedControls)

        If CRUD.HasException() Then Return False

        Return True

    End Function




    ' **************** VALIDATION SUBS ****************


    ' Sub that runs validation for all form controls. Also handles error reporting
    Private Function controlsValid() As Boolean

        Dim errorMessage As String = String.Empty

        ' Use "Required" parameter to control whether or not a Null string value will cause an error to be reported


        ' Part Description
        If Not isValidLength("Part Description", False, PartDescription_Textbox.Text, 50, errorMessage) Then PartDescription_Textbox.ForeColor = Color.Red

        ' Quantity
        If Not validNumber("Quantity", False, Qty_Textbox.Text, errorMessage, True) Then Qty_Textbox.ForeColor = Color.Red

        ' Unit Price
        If Not validCurrency("Unit Price", False, PartPrice_Textbox.Text, errorMessage) Then PartPrice_Textbox.ForeColor = Color.Red

        ' List Price
        If Not validCurrency("List Price", False, ListPrice_Textbox.Text, errorMessage) Then ListPrice_Textbox.ForeColor = Color.Red


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
        InvTaskPartsDbController = invoiceTasks.GetInvTaskPartsDbController()
        InvTaskPartsRow = invoiceTasks.GetInvTaskPartsRow()

        InvoiceValue.Text = invoices.GetINID()
        TaskValue.Text = invoiceTasks.GetTask()

        ' For the editing forms, we won't be initializing our dataEditingControls from a selection. Instead, we will initialize them just once on load
        valuesInitialized = False
        ' Initialize all DataEditing Controls
        InitializeAllDataEditingControls()
        valuesInitialized = True
        ' Establish initial values here, as we are exclusively editing on this form
        InitialPartValues.SetInitialValues(getAllControlsWithTag("dataEditingControl", Me))

    End Sub

    Private Sub editInvTaskPart_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Select first editing control
        PartDescription_Textbox.Select()

    End Sub




    ' **************** CONTROL SUBS ****************


    Private Sub editInvTaskPart_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If Not MeClosed Then

            If InitialPartValues.CtrlValuesChanged() Then

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

            If InitialPartValues.CtrlValuesChanged() Then

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
        If Not updateInvParts() Then
            MessageBox.Show("Update unsuccessful; Changes not saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' 3.) If this is successful, then:
        '       a.) Reinitialize Dependents on invoiceTasks
        '       b.) If that is successful, then change screen
        If Not invoiceTasks.reinitializeDependents() Then
            MessageBox.Show("Reloading of invoice tasks Unsuccessful; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            saveButton.Enabled = False
            Exit Sub
        End If

        MeClosed = True
        changeScreen(invoiceTasks, Me)

    End Sub




    Private Sub PartDescription_Textbox_TextChanged(sender As Object, e As EventArgs) Handles PartDescription_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        PartDescription_Textbox.ForeColor = DefaultForeColor

        If InitialPartValues.CtrlValuesChanged() Then
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

        ' If certain keystroke exceptions allowed through, then skip input validation here
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

        If InitialPartValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private Sub Qty_Textbox_KeyDown(sender As Object, e As KeyEventArgs) Handles Qty_Textbox.KeyDown

        ' Check to see ctrl+A, ctrl+C, or ctrl+V were used. If so, don't worry about checking which Keys Pressed
        If ((e.KeyCode = Keys.A And e.Control) Or (e.KeyCode = Keys.C And e.Control) Or (e.KeyCode = Keys.V And e.Control)) Then
            allowedKeystroke = True
        End If

    End Sub

    Private Sub Qty_Textbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Qty_Textbox.KeyPress

        ' If certain keystroke exceptions allowed through, then skip input validation here
        If allowedKeystroke Then
            allowedKeystroke = False
            Exit Sub
        End If

        If Not numericInputValid(Qty_Textbox, e.KeyChar, True) Then
            e.KeyChar = Chr(0)
            e.Handled = True
        End If

    End Sub

    Private Sub Qty_Textbox_TextChanged(sender As Object, e As EventArgs) Handles Qty_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        Qty_Textbox.ForeColor = DefaultForeColor

        ' Handles pasting in invalid values/strings
        Dim lastValidIndex As Integer = allValidChars(Qty_Textbox.Text, "1234567890")
        If lastValidIndex <> -1 Then
            Qty_Textbox.Text = Qty_Textbox.Text.Substring(0, lastValidIndex)
            Qty_Textbox.SelectionStart = lastValidIndex
        End If

        InitializePartAmountTextbox()

        If InitialPartValues.CtrlValuesChanged() Then
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

        ' If certain keystroke exceptions allowed through, then skip input validation here
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

        InitializePartAmountTextbox()

        If InitialPartValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


End Class