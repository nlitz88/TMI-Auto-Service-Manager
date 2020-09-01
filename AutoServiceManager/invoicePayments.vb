﻿Public Class invoicePayments


    ' New Database control instances for InvPayments, PaymentTypes, and CreditCards
    Private InvPaymentsDbController As New DbControl()
    Private PTDbController As New DbControl()
    Private CCDbController As New DbControl()
    ' New Database control instance for updating, inserting, and deleting
    Private CRUD As New DbControl()

    ' Initialize instance(s) of initialValues class
    Private InitialPaymentValues As New InitialValues()

    ' Variable to keep track of whether form fully loaded or not
    Private valuesInitialized As Boolean = True

    ' Row index variables used for DataTable lookups
    Private InvId As Long

    Private InvPaymentsRow As Integer
    Private InvPayKey As Integer

    Private lastSelected As String

    ' Variables used in the calculation of the invoice balance
    Private balance As Decimal = 0
    Private invTotal As Decimal = 0
    Private paid As Decimal = 0

    ' Keeps track of whether or not user in "editing" or "adding" mode
    Private mode As String

    ' Variable that allows certain keystrokes through restricted fields
    Private allowedKeystroke As Boolean = False

    ' Boolean to keep track of whether or not this form has been closed
    Private MeClosed As Boolean = False




    ' ***************** INITIALIZATION AND CONFIGURATION SUBS *****************


    Private Function loadInvPaymentsDataTable() As Boolean

        ' Loads rows from InvTask based on current invoice (indicated by InvNbr)
        '     
        '   
        InvPaymentsDbController.AddParams("@invid", InvId)
        InvPaymentsDbController.ExecQuery("SELECT CSTR(IIF(ISNULL(ip.InvPayKey), 0, ip.InvPayKey)) + ' - ' + CSTR(IIF(ISNULL(ip.PayDate), '', CSTR(ip.PayDate) + ' - ')) + CSTR(IIF(ISNULL(ip.PayAmount), '', '$' + CSTR(ip.PayAmount))) as PKPD, " &
                                       "ip.InvNbr, ip.InvPayKey, ip.PayDate, ip.PayAmount, ip.PaymentNotes, ip.PayType, ip.CheckNumber, ip.CreditCardType " &
                                       "FROM InvPayments ip " &
                                       "WHERE InvNbr=@invid " &
                                       "ORDER BY ip.PayDate ASC")
        If InvPaymentsDbController.HasException() Then Return False

        Return True

    End Function

    ' Sub that initializes PaymentComboBox
    Private Sub InitializePaymentComboBox()

        PaymentComboBox.BeginUpdate()
        PaymentComboBox.Items.Clear()
        PaymentComboBox.Items.Add("Select One")
        For Each row In InvPaymentsDbController.DbDataTable.Rows
            PaymentComboBox.Items.Add(row("PKPD"))
        Next
        PaymentComboBox.EndUpdate()

    End Sub



    ' Loads datatable from PaymentTypes
    Private Function loadPaymentTypesDataTable()

        PTDbController.ExecQuery("SELECT p.PaymentType FROM PaymentTypes p ORDER BY p.PaymentType ASC")
        If PTDbController.HasException() Then Return False

        Return True

    End Function

    ' Sub to initialize PaymentTypes ComboBox
    Private Sub initializePayTypeComboBox()

        PayType_ComboBox.Items.Clear()
        PayType_ComboBox.BeginUpdate()
        For Each row In PTDbController.DbDataTable.Rows
            PayType_ComboBox.Items.Add(row("PaymentType"))
        Next
        PayType_ComboBox.EndUpdate()

    End Sub


    ' Loads datatable from CreditCardsAccepted
    Private Function loadCreditCardsDataTable()

        PTDbController.ExecQuery("SELECT c.CreditCard FROM CreditCardsAccepted c ORDER BY c.CreditCard ASC")
        If PTDbController.HasException() Then Return False

        Return True

    End Function

    ' Sub to initialize CreditCardType ComboBox
    Private Sub initializeCreditCardTypeComboBox()

        PayType_ComboBox.Items.Clear()
        PayType_ComboBox.BeginUpdate()
        For Each row In PTDbController.DbDataTable.Rows
            PayType_ComboBox.Items.Add(row("CreditCard"))
        Next
        PayType_ComboBox.EndUpdate()

    End Sub

    ' Will need to implement logic in paymentTypes combobox selected change event (like automake in vehicleMaintenance)



    ' Sub that initializes all dataEditingcontrols corresponding with values from the InvTask DataTable
    Private Sub InitializeInvPaymentsDataEditingControls()

        initializeControlsFromRow(InvPaymentsDbController.DbDataTable, InvPaymentsRow, "dataEditingControl", "_", Me)

    End Sub

    ' Sub that initializes all dataViewingControls corresponding with values from the InvTask DataTable
    Private Sub InitializeInvPaymentsDataViewingControls()

        initializeControlsFromRow(InvPaymentsDbController.DbDataTable, InvPaymentsRow, "dataViewingControl", "_", Me)

    End Sub



    ' Sub that calculates balance based on Invoice Total (cost) and current sum of payments for this invoice
    Private Sub InitializeBalance()

        ' First, get invoice total (cost)
        invTotal = invoices.GetInvTotalSum()

        ' Then, find the current sum of payments made on the invoice
        For Each row In InvPaymentsDbController.DbDataTable.Rows
            paid += row("PayAmount")
        Next

        ' Then calculate balance
        balance = invTotal - paid

        ' Finally, set value
        BalanceValue.Text = FormatCurrency(balance)

    End Sub


    ' Sub that will call formatting functions to add respective formats to already INITIALIZED DATAVIEWINGCONTROLS (i.e. phone numbers, currency, etc.).
    Private Sub formatDataViewingControls()

        PayAmount_Value.Text = FormatCurrency(PayAmount_Value.Text)

    End Sub

    ' Sub that will call formatting functions to add respective formats to already INITIALIZED DATAEDITINGCONTROLS (i.e. phone numbers, currency, etc.).
    Private Sub formatDataEditingControls()

        PayAmount_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(PayAmount_Textbox.Text))

    End Sub






    ' ***************** CRUD SUBS *****************





    ' ***************** VALIDATION SUBS *****************






    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' Get invoice specific information
        InvoiceValue.Text = invoices.GetINID()
        InvId = invoices.GetInvId()

        If Not checkDbConn() Then Exit Sub

        If Not loadInvPaymentsDataTable() Then
            MessageBox.Show("Failed to load invoice payments table; Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        InitializePaymentComboBox()
        PaymentComboBox.SelectedIndex = 0


        If Not loadPaymentTypesDataTable() Then
            MessageBox.Show("Failed to load payment types table; Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        initializePayTypeComboBox()

        If Not loadCreditCardsDataTable() Then
            MessageBox.Show("Failed to load credit cards table; Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        initializeCreditCardTypeComboBox()


        InitializeBalance()     ' This function will also be called after saving a payment (as the balance would then need to be recalculated)




    End Sub


    Private Sub invoicePayments_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' PRE-DRAW PRE-LOADED (Preliminary) COMBOBOXES. 
        ' This way, we don't have to wait for them to draw on first edit/add
        CreditCardType_ComboBox.Visible = False
        CreditCardType_ComboBox.Visible = True

    End Sub




    ' **************** CONTROL SUBS ****************


    Private Sub PaymentComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PaymentComboBox.SelectedIndexChanged, PaymentComboBox.TextChanged

        ' Ensure that ComboBox is only attempting to initialize values when on proper selected Index
        If PaymentComboBox.SelectedIndex = -1 Then

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
        InvPaymentsRow = getDataTableRow(InvPaymentsDbController.DbDataTable, "PKPD", PaymentComboBox.Text)

        ' If the lookup DOES find the value in the DataTable
        If InvPaymentsRow <> -1 Then

            ' Initialize corresponding controls from DataTable values
            valuesInitialized = False
            InitializeInvPaymentsDataViewingControls()
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



    Private Sub PayType_ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PayType_ComboBox.SelectedIndexChanged

        ' Check here for selection type
        ' if selection is valid:
        '   if selection is credit card:
        '       then make credit card comboBox visible
        '   else if selection is check
        '       then make check number textbox visible
        '   else
        '       hide creditcard ComboBox and checkNumber textbox

    End Sub


End Class