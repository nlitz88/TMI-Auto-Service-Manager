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


    ' Sub that hides/shows proper dataEditing controls corresponding to each PaymentType
    Private Sub ShowCorrespondingPaymentViewingControls()

        Select Case InvPaymentsDbController.DbDataTable(InvPaymentsRow)("PayType")
            Case "Credit"
                ' Make CreditCardType_Value and label visible, and conversely hide checkNumber controls
                CreditCardType_Value.Visible = True
                CreditCardTypeLabel.Visible = True
                CheckNumber_Value.Visible = False
                CheckNumberLabel.Visible = False
            Case "Check"
                ' Make CheckNumber_Value and label visible, and conversely hide CreditCard controls
                CheckNumber_Value.Visible = True
                CheckNumberLabel.Visible = True
                CreditCardType_Value.Visible = False
                CreditCardTypeLabel.Visible = False
            Case Else
                ' Hide all corresponding controls, as they do not apply
                CreditCardType_Value.Visible = False
                CreditCardTypeLabel.Visible = False
                CheckNumber_Value.Visible = False
                CheckNumberLabel.Visible = False
        End Select

    End Sub


    ' Sub that hides/shows proper dataViewing controls corresponding to each PaymentType
    Private Sub ShowCorrespondingPaymentEditingControls()

        Select Case PayType_ComboBox.Text

            Case "Credit"
                CreditCardType_ComboBox.Visible = True
                CreditCardTypeLabel.Visible = True
                CheckNumber_Textbox.Visible = False
                CheckNumberLabel.Visible = False
            Case "Check"
                CheckNumber_Textbox.Visible = True
                CheckNumberLabel.Visible = True
                CreditCardType_ComboBox.Visible = False
                CreditCardTypeLabel.Visible = False
            Case Else
                CreditCardType_ComboBox.Visible = False
                CreditCardTypeLabel.Visible = False
                CheckNumber_Textbox.Visible = False
                CheckNumberLabel.Visible = False

        End Select

    End Sub



    ' Sub that will call formatting functions to add respective formats to already INITIALIZED DATAVIEWINGCONTROLS (i.e. phone numbers, currency, etc.).
    Private Sub formatDataViewingControls()

        PayAmount_Value.Text = FormatCurrency(PayAmount_Value.Text)

    End Sub

    ' Sub that will call formatting functions to add respective formats to already INITIALIZED DATAEDITINGCONTROLS (i.e. phone numbers, currency, etc.).
    Private Sub formatDataEditingControls()

        PayAmount_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(PayAmount_Textbox.Text))

    End Sub


    Private Sub InitializeAllDataViewingControls()

        ' Automated initializations
        InitializeInvPaymentsDataViewingControls()
        ' Call sub here that hides/shows proper combobox/textbox based on current payment type
        'ShowCorrespondingPaymentViewingControls()
        ' Then, format dataViewingControls
        formatDataViewingControls()

    End Sub


    Private Sub InitializeAllDataEditingControls()

        ' Automated initializations
        InitializeInvPaymentsDataEditingControls()
        ' Then, format dataEditingControls
        formatDataEditingControls()
        ' Set forecolor if not already initially default
        setForeColor(getAllControlsWithTag("dataEditingControl", Me), DefaultForeColor)

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
        CreditCardType_ComboBox.Visible = True
        CreditCardType_ComboBox.Visible = False

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
            InitializeAllDataViewingControls()
            valuesInitialized = True

            ' Show labels and corresponding values
            showHide(getAllControlsWithTag("dataViewingControl", Me), 1)
            showHide(getAllControlsWithTag("dataLabel", Me), 1)
            showHide(getAllControlsWithTag("dataEditingControl", Me), 0)

            ' This must be called after dataViewingControls have been made visible, as some must be hidden again
            ShowCorrespondingPaymentViewingControls()

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

    End Sub

    Private Sub deleteButton_Click(sender As Object, e As EventArgs) Handles deleteButton.Click

    End Sub



    Private Sub editButton_Click(sender As Object, e As EventArgs) Handles editButton.Click

        mode = "editing"

        ' Initialize values for dataEditingControls
        valuesInitialized = False
        InitializeAllDataEditingControls()

        valuesInitialized = True
        ' Establish initial values. Doing this here, as unless changes are about to be made, we don't need to set initial values
        InitialPaymentValues.SetInitialValues(getAllControlsWithTag("dataEditingControl", Me))

        ' Store the last selected item in the ComboBox (in case update fails and it must revert)
        lastSelected = PaymentComboBox.Text

        ' Disable editButton, disable addButton, enable cancel button, disable navigation, and disable main selection combobox
        editButton.Enabled = False
        addButton.Enabled = False
        cancelButton.Enabled = True
        PaymentComboBox.Enabled = False

        ' Hide/Show the dataViewingControls and dataEditingControls, respectively
        showHide(getAllControlsWithTag("dataViewingControl", Me), 0)
        showHide(getAllControlsWithTag("dataEditingControl", Me), 1)

        ' This must be called after dataEditingControls have been made visible, as some must be hidden again
        ShowCorrespondingPaymentEditingControls()

    End Sub


    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click

    End Sub


    Private Sub saveButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click

    End Sub



    Private Sub PayType_ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PayType_ComboBox.SelectedIndexChanged, PayType_ComboBox.TextChanged

        ' Check here for selection type
        ' if selection is valid:
        '   if selection is credit card:
        '       then make credit card comboBox visible
        '   else if selection is check
        '       then make check number textbox visible
        '   else
        '       hide creditcard ComboBox and checkNumber textbox

        If Not valuesInitialized Then Exit Sub

        PayType_ComboBox.ForeColor = DefaultForeColor


        ShowCorrespondingPaymentEditingControls()


    End Sub




    Private Sub invoicePayments_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If Not MeClosed Then

            ' Check if editing/adding, and if editing/adding, check if control values changed
            If PayDate_Textbox.Visible And InitialPaymentValues.CtrlValuesChanged() Then

                Dim decision As DialogResult = MessageBox.Show("Return to invoice without saving changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If decision = DialogResult.No Then
                    e.Cancel = True
                    Exit Sub
                Else
                    MeClosed = True
                    changeScreen(invoices, Me)
                End If

            Else

                MeClosed = True
                changeScreen(invoices, Me)

            End If

        End If

    End Sub


    Private Sub returnButton_Click(sender As Object, e As EventArgs) Handles returnButton.Click

        If Not MeClosed Then

            ' Check if editing/adding, and if editing/adding, check if control values changed
            If PayDate_Textbox.Visible And InitialPaymentValues.CtrlValuesChanged() Then

                Dim decision As DialogResult = MessageBox.Show("Return to invoice without saving changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If decision = DialogResult.No Then
                    Exit Sub
                Else

                    ' Call REINITIALIZATION HERE
                    If Not invoices.reinitializeDependents() Then
                        MessageBox.Show("Reloading of invoice unsuccessful; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                    MeClosed = True
                    changeScreen(invoices, Me)

                End If

            Else

                ' Call REINITIALIZATION HERE
                If Not invoices.reinitializeDependents() Then
                    MessageBox.Show("Reloading of invoice unsuccessful; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                MeClosed = True
                changeScreen(invoices, Me)

            End If

        End If

    End Sub


End Class