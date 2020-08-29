﻿Public Class editInvTaskLabor

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
End Class