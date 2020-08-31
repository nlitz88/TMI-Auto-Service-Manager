Public Class invoicePayments


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
        InvPaymentsDbController.ExecQuery("SELECT CSTR(IIF(ISNULL(ip.InvPayKey), 0, ip.InvPayKey)) + ' - ' + CSTR(IIF(ISNULL(ip.PayDate), '', ip.PayDate)) + ' - ' + CSTR(IIF(ISNULL(ip.PayAmount), '', '$' + CSTR(ip.PayAmount))) as PKPD, " &
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


    ' Sub that initializes all dataEditingcontrols corresponding with values from the InvTask DataTable
    Private Sub InitializeInvPaymentsDataEditingControls()

        initializeControlsFromRow(InvPaymentsDbController.DbDataTable, InvPaymentsRow, "dataEditingControl", "_", Me)

    End Sub

    ' Sub that initializes all dataViewingControls corresponding with values from the InvTask DataTable
    Private Sub InitializeInvPaymentsDataViewingControls()

        initializeControlsFromRow(InvPaymentsDbController.DbDataTable, InvPaymentsRow, "dataViewingControl", "_", Me)

    End Sub



    ' Make subs here that initialize (and make visible) credit card/check number controls
    ' based on what is selected in paymentType


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


        InitializeBalance()     ' This function will also be called after saving a payment (as the balance would then need to be recalculated)


        ' loadCreditCardsDataTable() or something like this
        ' InitializeCreditCardTypeComboBox()

    End Sub


    Private Sub invoicePayments_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' PRE-DRAW PRE-LOADED (Preliminary) COMBOBOXES. 
        ' This way, we don't have to wait for them to draw on first edit/add
        CreditCardType_ComboBox.Visible = False
        CreditCardType_ComboBox.Visible = True

    End Sub





End Class