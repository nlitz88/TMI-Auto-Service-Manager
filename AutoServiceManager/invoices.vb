Imports System.ComponentModel

Public Class invoices

    ' New Database control instances for Customers, Vehicles, and InvHdr datatables
    Private CustomerDbController As New DbControl()
    Private VehicleDbController As New DbControl()
    Private InvDbController As New DbControl()
    ' New Database control instances for License Plate Search controls (just license State)
    Private StateDbController As New DbControl()
    ' New Database control instances for Tasks and Payments (for calculating values locally)
    Private InvLaborDbController As New DbControl()
    Private InvPartsDbController As New DbControl()
    Private InvTaskDbController As New DbControl()
    Private InvPaymentsDbController As New DbControl()
    Private CMDbController As New DbControl()
    Private MonthDbController As New DbControl()
    ' New Database control instance for updating, inserting, and deleting
    Private CRUD As New DbControl()

    ' Initialize instance(s) of initialValues class
    Private InitialInvValues As New InitialValues()

    'Variable to keep track of whether form fully loaded or not
    Private valuesInitialized As Boolean = True

    ' Row index variables used for further queries/lookups
    Private CustomerRow As Integer              ' Maintains row in DataTable that corresponds to currently selected CLFA
    Private CustomerId As Integer               ' CustomerId from same row that ""

    Private VehicleRow As Integer               ' Maintains row in DataTable that corresponds to the currently selected YMML
    Private VehicleId As Integer                ' VehicleId from same row that ""

    Private InvRow As Integer                   ' Maintains row in DataTable that corresponds to the currently selected InvoiceNbr
    Private InvId As Long                       ' InvNbr from same row that ""

    Private CMRow As Integer = 0

    ' Values from Customer that are used for validation and selection
    Private CustomerPhoneList As New List(Of String)
    Private PhonesMatching As Boolean

    ' Variable that Maintains the last selected Invoice
    Private lastSelected As String

    ' Variables that store calculated values for various controls
    Private InvLaborSum As Decimal = 0
    Private InvPartsSum As Decimal = 0
    Private ShopCharges As Decimal = 0
    Private SubTotal As Decimal = 0
    Private Tax As Decimal = 0
    Private Gas As Decimal = 0
    Private Towing As Decimal = 0
    Private InvTotalSum As Decimal = 0
    Private Taxable As Decimal = 0
    Private NonTaxable As Decimal = 0
    Private InvPaymentsSum As Decimal = 0
    Private Balance As Decimal = 0
    Private NbrTasks As Decimal = 0

    ' Keeps track of whether or not user in "editing" or "adding" mode
    Private mode As String

    ' Variable that allows certain keystrokes through restricted fields
    Private allowedKeystroke As Boolean = False




    ' ***************** GET/SET SUBS FOR EXTERNAL FORMS *****************


    ' Retrieves current invoice+date INID selected
    Public Function GetINID() As String
        Return InvoiceComboBox.Text
    End Function

    Public Function GetInvId() As Long
        Return InvId
    End Function

    ' Retrieves current Invoice Sum/Total to be used for balance calculations in InvPayments
    Public Function GetInvTotalSum() As Decimal
        Return InvTotalSum
    End Function




    ' ***************** INITIALIZATION AND CONFIGURATION SUBS *****************


    ' Sub that loads Customer DataTable
    Private Function loadCustomerDataTable() As Boolean

        CustomerDbController.ExecQuery("SELECT IIF(ISNULL(c.LastName), '', c.LastName) + ', ' + IIF(ISNULL(c.FirstName), '', c.FirstName) + IIF(ISNULL(c.Address) OR c.Address = '', '', ' @ ' + c.Address) as CLFA, c.CustomerId, c.LastName, c.FirstName, c.HomePhone, c.WorkPhone, c.CellPhone1, c.CellPhone2, c.TaxExempt " &
                                       "FROM Customer c " &
                                       "WHERE Trim(LastName) <> '' " &
                                       "ORDER BY c.LastName ASC")
        If CustomerDbController.HasException() Then Return False

        Return True

    End Function

    ' Sub that initializes CustomerPhoneList (used later in initialization of ContactPhone ComboBoxes) (Should be called after each time new valid Customer Selected)
    Private Sub InitializeCustomerPhoneList()

        CustomerPhoneList.Clear()
        Dim HomePhone As String = CustomerDbController.DbDataTable(CustomerRow)("HomePhone")
        If Not String.IsNullOrEmpty(HomePhone) Then
            HomePhone = removeInvalidChars(HomePhone, "0123456789")
            If Not String.IsNullOrEmpty(HomePhone) Then
                CustomerPhoneList.Add(HomePhone)
            End If
        End If
        Dim WorkPhone As String = CustomerDbController.DbDataTable(CustomerRow)("WorkPhone")
        If Not String.IsNullOrEmpty(WorkPhone) Then
            WorkPhone = removeInvalidChars(WorkPhone, "0123456789")
            If Not String.IsNullOrEmpty(WorkPhone) Then
                CustomerPhoneList.Add(WorkPhone)
            End If
        End If
        Dim CellPhone1 As String = CustomerDbController.DbDataTable(CustomerRow)("CellPhone1")
        If Not String.IsNullOrEmpty(CellPhone1) Then
            CellPhone1 = removeInvalidChars(CellPhone1, "0123456789")
            If Not String.IsNullOrEmpty(CellPhone1) Then
                CustomerPhoneList.Add(CellPhone1)
            End If
        End If
        Dim CellPhone2 As String = CustomerDbController.DbDataTable(CustomerRow)("CellPhone2")
        If Not String.IsNullOrEmpty(CellPhone2) Then
            CellPhone2 = removeInvalidChars(CellPhone2, "0123456789")
            If Not String.IsNullOrEmpty(CellPhone2) Then
                CustomerPhoneList.Add(CellPhone2)
            End If
        End If

    End Sub

    ' Sub that initializes Customer ComboBox
    Private Sub InitializeCustomerComboBox()

        CustomerComboBox.BeginUpdate()
        CustomerComboBox.Items.Clear()
        CustomerComboBox.Items.Add("Select One")
        For Each row In CustomerDbController.DbDataTable.Rows
            CustomerComboBox.Items.Add(row("CLFA"))
        Next
        CustomerComboBox.EndUpdate()

    End Sub

    ' Sub that intializes ContactPhone1 ComboBox (Called after valid Customer has been selected)
    Private Sub InitializeContactPhone1ComboBox()

        ContactPhone1_ComboBox.BeginUpdate()
        ContactPhone1_ComboBox.Items.Clear()
        ' Add the four different phone numbers from Customer to the ComboBox here
        For Each phoneNum In CustomerPhoneList
            ContactPhone1_ComboBox.Items.Add(formatPhoneNumber(phoneNum))
        Next
        ContactPhone1_ComboBox.EndUpdate()

    End Sub

    ' Sub that intializes ContactPhone2 ComboBox (Called after valid Customer has been selected)
    Private Sub InitializeContactPhone2ComboBox()

        ContactPhone2_ComboBox.BeginUpdate()
        ContactPhone2_ComboBox.Items.Clear()
        ' Add the four different phone numbers from Customer to the ComboBox here
        For Each phoneNum In CustomerPhoneList
            ContactPhone2_ComboBox.Items.Add(formatPhoneNumber(phoneNum))
        Next
        ContactPhone2_ComboBox.EndUpdate()

    End Sub


    ' Sub that initializes all dataEditingControls corresponding to values in Customer DataTable (TaxExempt)(Contact)(CellPhone1)
    ' Only used to initialize textbox when ADDING a NEW INVOICE
    Private Sub InitializeFromCustomer()

        'initializeControlsFromRow(CustomerDbController.DbDataTable, CustomerRow, "dataEditingControl", "_", Me)
        ' We are only initializing TaxExempt, Contact, and CellPhone1 from Customer DataTable, so do this small operation here manually.
        Dim TaxExemptStatus As Boolean = CustomerDbController.DbDataTable(CustomerRow)("TaxExempt")
        TaxExempt_CheckBox.Checked = TaxExemptStatus
        Dim Contact As String = CustomerDbController.DbDataTable(CustomerRow)("FirstName")
        ContactName_Textbox.Text = Contact

    End Sub


    ' Sub that loads States DataTable
    Private Function loadStatesDataTable() As Boolean

        ' Loads datatable from States
        StateDbController.ExecQuery("SELECT s.State FROM States s ORDER BY s.State ASC")
        If StateDbController.HasException() Then Return False

        Return True

    End Function

    ' Sub that initializes StateComboBox
    Private Sub InitializeStateComboBox()

        LicenseStateComboBox.Items.Clear()
        LicenseStateComboBox.BeginUpdate()
        For Each row In StateDbController.DbDataTable.Rows
            LicenseStateComboBox.Items.Add(row("State"))
        Next
        LicenseStateComboBox.EndUpdate()

    End Sub


    ' Sub that loads Company Master DataTable
    Private Function loadCMDataTable() As Boolean

        CMDbController.ExecQuery("SELECT cm.TaxRate, cm.ShopSupplyCharge, cm.LaborRate FROM CompanyMaster cm")
        If CMDbController.HasException() Then Return False

        Return True

    End Function


    ' Sub that loads Months DataTable
    Private Function loadMonthDataTable() As Boolean

        MonthDbController.ExecQuery("SELECT m.Month, m.IntMonth FROM Months m ORDER BY m.IntMonth ASC")
        If MonthDbController.HasException() Then Return False

        Return True

    End Function

    ' Sub that initializes InspectionMonth ComboBox
    Private Sub InitializeInspectionMonthComboBox()

        InspectionMonth_ComboBox.Items.Clear()
        InspectionMonth_ComboBox.BeginUpdate()
        For Each row In MonthDbController.DbDataTable.Rows
            InspectionMonth_ComboBox.Items.Add(row("Month"))
        Next
        InspectionMonth_ComboBox.EndUpdate()

    End Sub


    ' Sub that loads Vehicle DataTable based on CustomerId
    Private Function loadVehicleDataTable() As Boolean

        VehicleDbController.AddParams("@customerId", CustomerId)
        VehicleDbController.ExecQuery("SELECT CSTR(IIF(ISNULL(v.makeYear), 0, v.makeYear)) + ' ' + IIF(ISNULL(v.Make), '', v.Make) + ' ' + IIF(ISNULL(v.Model), '', v.Model) + IIF(ISNULL(v.LicensePlate) OR v.LicensePlate = '', '', '  -  ' + v.LicensePlate) as YMML, " &
                                      "v.VehicleId, v.InspectionStickerNbr as InspectionSticker, v.InspectionMonth " &
                                      "FROM Vehicle v " &
                                      "WHERE v.CustomerId=@customerId " &
                                      "ORDER BY v.makeYear ASC")

        If VehicleDbController.HasException() Then Return False

        Return True

    End Function

    ' Sub that initializes VehicleComboBox after valid Customer selection has been made
    Private Sub InitializeVehicleComboBox()

        VehicleComboBox.BeginUpdate()
        VehicleComboBox.Items.Clear()
        VehicleComboBox.Items.Add("Select One")
        For Each row In VehicleDbController.DbDataTable.Rows
            VehicleComboBox.Items.Add(row("YMML"))
        Next
        VehicleComboBox.EndUpdate()

    End Sub

    ' Sub that Sets inspection months value to the month abreviation that corresponds to the initialized month int (that is no longer being used)
    Private Sub correctInspectionMonthComboBox()

        ' First, check if empty. If empty, we don't need to do anything
        If String.IsNullOrWhiteSpace(InspectionMonth_ComboBox.Text) Then Exit Sub

        ' Then, check to see if it is an intMonth using allValidChars. If it's not, then exit sub. No change necessary
        If allValidChars(InspectionMonth_ComboBox.Text.ToLower(), "abcdefghijklmnopqrstuvwxyz") = -1 Then Exit Sub

        ' If not an abreviation, then use the intMonth to find the Month abreviation
        Dim month As String = getRowValueWithKeyEquals(MonthDbController.DbDataTable, "Month", "IntMonth", Convert.ToInt32(InspectionMonth_ComboBox.Text))
        ' If the query comes back with an abreviation, we can assign it.
        If month <> Nothing Then
            InspectionMonth_ComboBox.Text = month
        End If

    End Sub

    ' Variant for use with corresponding value
    Private Sub correctInspectionMonthValue()

        ' First, check if empty. If empty, we don't need to do anything
        If String.IsNullOrWhiteSpace(InspectionMonth_Value.Text) Then Exit Sub

        ' Then, check to see if it is an intMonth using allValidChars. If it's not, then exit sub. No change necessary
        If allValidChars(InspectionMonth_Value.Text.ToLower(), "abcdefghijklmnopqrstuvwxyz") = -1 Then Exit Sub

        ' If not an abreviation, then use the intMonth to find the Month abreviation
        Dim month As String = getRowValueWithKeyEquals(MonthDbController.DbDataTable, "Month", "IntMonth", Convert.ToInt32(InspectionMonth_Value.Text))
        ' If the query comes back with an abreviation, we can assign it.
        If month <> Nothing Then
            InspectionMonth_Value.Text = month
        End If

    End Sub


    ' Sub that initializes all dataEditingControls corresponding to values in Vehicle DataTable (inspection month, inspection sticker number)
    Private Sub InitializeVehicleDataEditingControls()

        initializeControlsFromRow(VehicleDbController.DbDataTable, VehicleRow, "dataEditingControl", "_", Me)

    End Sub


    ' Sub that loads InvoiceHdr DataTable based on VehicleId
    Private Function loadInvoiceDataTable() As Boolean

        InvDbController.AddParams("@vehicleId", VehicleId)
        InvDbController.ExecQuery("SELECT CSTR(IIF(ISNULL(i.InvNbr), 0, i.InvNbr)) + ' - ' + CSTR(IIF(ISNULL(i.InvDate), '', i.InvDate)) as INID, " &
                                  "i.InvNbr, i.CustomerId, i.VehicleId, i.Mileage, i.InvDate, i.Complete, i.NbrTasks, i.WorkDate, i.ApptDate, i.ContactName, i.ContactPhone1, i.ContactPhone2, i.Notes, i.TotalLabor, i.TotalParts, i.Towing, " &
                                  "i.Gas, i.ShopCharges, i.Tax, i.InvTotal, i.TotalPaid, i.PayDate, i.TaxExempt, i.ShopSupplies, i.InspectionSticker, i.InspectionMonth, i.Taxable, i.NonTaxable " &
                                  "FROM InvHdr i " &
                                  "WHERE i.VehicleId=@vehicleId " &
                                  "ORDER BY i.InvDate DESC")

        If InvDbController.HasException() Then Return False

        Return True

    End Function

    ' Sub that initializes invoiceNumComboBox after valid Vehicle selection has been made
    Private Sub InitializeInvoiceNumComboBox()

        InvoiceComboBox.BeginUpdate()
        InvoiceComboBox.Items.Clear()
        InvoiceComboBox.Items.Add("Select One")
        For Each row In InvDbController.DbDataTable.Rows
            InvoiceComboBox.Items.Add(row("INID").ToString())
        Next
        InvoiceComboBox.EndUpdate()

    End Sub

    ' Sub that initializes all dataViewingControls corresponding to values in invoice DataTable
    Private Sub InitializeInvoiceDataViewingControls()

        'initializeControlsFromRow(InvDbController.DbDataTable, InvRow, "dataViewingControl", "_", Me)
        initializeNestedControlsFromRow(InvDbController.DbDataTable, InvRow, "dataViewingControl", "_", Me)

    End Sub
    ' Sub that initializes all dataEditingControls corresponding to values in invoice DataTable
    Private Sub InitializeInvoiceDataEditingControls()

        initializeNestedControlsFromRow(InvDbController.DbDataTable, InvRow, "dataEditingControl", "_", Me)

    End Sub


    ' Function that will load all invoice selection-dependent DataTables (InvLabor, InvParts, and InvPayments)
    Private Function loadDependentDataTables() As Boolean

        ' Loads rows from InvLabor based on selected InvNbr from InvHdr
        InvLaborDbController.AddParams("@invId", InvId)
        InvLaborDbController.ExecQuery("SELECT il.LaborAmount " &
                                        "FROM InvLabor il " &
                                        "WHERE il.InvNbr=@invId")
        If InvLaborDbController.HasException() Then Return False

        ' Loads rows from InvParts based on selected InvNbr from InvHdr
        InvPartsDbController.AddParams("@invId", InvId)
        InvPartsDbController.ExecQuery("SELECT ip.PartAmount " &
                                        "FROM InvParts ip " &
                                        "WHERE ip.InvNbr=@invId")
        If InvPartsDbController.HasException() Then Return False

        ' Loads only InvNbr from InvTask
        InvTaskDbController.AddParams("@invId", InvId)
        InvTaskDbController.ExecQuery("SELECT it.InvNbr " &
                                       "FROM InvTask it " &
                                       "WHERE it.InvNbr=@invId")
        If InvTaskDbController.HasException() Then Return False

        ' Loads rows from InvPayments based on seleceted InvNbr from InvHdr
        InvPaymentsDbController.AddParams("@invId", InvId)
        InvPaymentsDbController.ExecQuery("SELECT ip.PayAmount, ip.PayDate " &
                                        "FROM InvPayments ip " &
                                        "WHERE ip.InvNbr=@invId")
        If InvPaymentsDbController.HasException() Then Return False

        Return True

    End Function




    ' THESE FOUR AREN'T NECESSARRY, AS THEY WILL NEVER BE CALLED. THEIR VALUES ARE INSERTED INTO THE INVHDR ROW, AND ARE INITIALIZED FROM THERE UPON REINITIALIZING

    '' Sub that initializes Total Labor sum
    'Private Sub InitializeTotalLaborTextbox()

    '    calcInvLaborSum()
    '    TotalLabor_Textbox.Text = String.Format("{0:0.00}", InvLaborSum)

    'End Sub


    '' Sub that initializes Total Parts sum
    'Private Sub InitializeTotalPartsTextbox()

    '    calcInvPartsSum()
    '    TotalParts_Textbox.Text = String.Format("{0:0.00}", InvPartsSum)

    'End Sub

    ' Sub that initializes Number of Tasks
    'Private Sub InitializeNumberTasksTextbox()

    '    Dim NbrTasks As Integer = InvTaskDbController.DbDataTable.Rows.Count
    '    NbrTasks_Textbox.Text = NbrTasks

    'End Sub

    ' Sub that intializes Invoice Total Paid amount based on the total of all of the payments in InvPayments with current InvId
    'Private Sub InitializeInvPaymentsTextbox()

    '    calcInvPaymentsSum()
    '    TotalPaid_Textbox.Text = String.Format("{0:0.00}", InvPaymentsSum)

    'End Sub



    ' Sub that initializes Shop Charges based TotalLabor, TotalParts. Initializes to zero if Shop Supplies not checked
    Private Sub InitializeShopChargesTextbox()

        calcShopCharges()
        ShopCharges_Textbox.Text = String.Format("{0:0.00}", ShopCharges)

    End Sub


    ' Sub that initializes (and subsequently caclulates) SubTotal textbox based on valid shop charges
    Private Sub InitializeSubTotalTextbox()

        If validCurrency("Shop Charges", True, ShopCharges_Textbox.Text, String.Empty) Then

            ' Because Shop Charges can be edited by user OR be automatically calculated by ShopSupplyCharge Rate, we will capture its value again here.
            ' This will allow us to get the value whether the user checked the Shop Supplies Checkbox and automatically calculated it, OR if they simply typed in
            ' a new valid dollar amount that they would like to use instead.
            ' Then, this captured value will be the one used in the calculation of subtotal
            ShopCharges = Convert.ToDecimal(ShopCharges_Textbox.Text)

            calcSubTotal()
            SubTotalTextbox.Text = String.Format("{0:0.00}", SubTotal)
        Else
            SubTotalTextbox.Text = String.Empty
        End If


    End Sub




    ' Sub that initializes Tax Textbox
    Private Sub InitializeTaxTextbox()

        If validCurrency("SubTotal", True, SubTotalTextbox.Text, String.Empty) Then
            calcTax()
            Tax_Textbox.Text = String.Format("{0:0.00}", Tax)
        Else
            Tax_Textbox.Text = String.Empty
        End If

    End Sub


    ' Sub that initializes InvTotalTextbox only if SubTotal, Tax, Gas, and Towing are all in a valid currency form.
    ' If so, this will calculate InvTotalSum using Subtotal, Tax, and Gas and Towing using their respective functions to get their values.
    ' Will also call for the calculation of Taxable and NonTaxable, as if this is being calculated, all of the values that they depend on are valid, and can also be calculated.
    Private Sub InitializeTotalTextbox()

        ' Add validation checking for Gas and Towing Cost Inputs
        If validCurrency("Gas", True, Gas_Textbox.Text, String.Empty) And
            validCurrency("Towing", True, Towing_Textbox.Text, String.Empty) And
            validCurrency("Tax", True, Tax_Textbox.Text, String.Empty) And
            validCurrency("SubTotal", True, SubTotalTextbox.Text, String.Empty) Then

            getGas()
            getTowing()
            calcInvTotalSum()
            InvTotal_Textbox.Text = String.Format("{0:0.00}", InvTotalSum)

            calcTaxableNonTaxable()

        Else
            InvTotal_Textbox.Text = String.Empty
        End If

    End Sub


    ' Sub that initializes Balance based on InvPaymentsSum and InvTotalSum. Will only initialize if InvTotal is in a valid currency form.
    Private Sub InitializeBalanceTextbox()

        If validCurrency("InvTotal", True, InvTotal_Textbox.Text, String.Empty) And
            validCurrency("Total Paid", True, TotalPaid_Textbox.Text, String.Empty) Then

            calcBalance()
            BalanceTextbox.Text = String.Format("{0:0.00}", Balance)

        Else
            BalanceTextbox.Text = String.Empty
        End If

    End Sub








    ' Sub that calls all individual dataViewingControl initialization subs in one
    ' Used only for viewing invoices (not when addign/editing)
    Private Sub InitializeAllDataViewingControls()

        ' Reset calculated values
        ' I SHOULD BE ABLE TO REMOVE THIS; AS NO CALCULATIONS SHOULD BE OCCURRING WHILE VIEWING

        ' Automated initializations
        InitializeInvoiceDataViewingControls()
        correctInspectionMonthValue()       ' Correction for value initialized from Vehicle DataTable

        ' Then, re-initialize and format any calculation based values that ARE NOT FROM invHdr table
        resetCalculatedValues()

        ' Calculate SubTotal and Balance based on values of invoice (from InvHdr) instead of calculating them live
        ' INSTEAD of calculating these values, these values will START as their initial values from the InvHdr DataTable row
        InvLaborSum = InvDbController.DbDataTable(InvRow)("TotalLabor")
        InvPartsSum = InvDbController.DbDataTable(InvRow)("TotalParts")
        ShopCharges = InvDbController.DbDataTable(InvRow)("ShopCharges")
        SubTotal = InvLaborSum + InvPartsSum + ShopCharges
        Tax = InvDbController.DbDataTable(InvRow)("Tax")
        Gas = InvDbController.DbDataTable(InvRow)("Gas")
        Towing = InvDbController.DbDataTable(InvRow)("Towing")
        InvTotalSum = InvDbController.DbDataTable(InvRow)("InvTotal")
        InvPaymentsSum = InvDbController.DbDataTable(InvRow)("TotalPaid")
        Balance = InvTotalSum - InvPaymentsSum

        SubTotalValue.Text = SubTotal
        BalanceValue.Text = Balance

        ' Then, format dataViewingControls
        formatDataViewingControls()

    End Sub


    ' Sub that calls all individual dataEditingControl initialization subs in one
    ' This is used ONLY for when EDITING an invoice. When adding, editing controls are initialized with DIFFERENT sub
    Private Sub InitializeAllDataEditingControls()

        ' Automated initializations
        InitializeInvoiceDataEditingControls()
        correctInspectionMonthComboBox()    ' Correction for value initialized from Vehicle DataTable

        ' Then, re-initialize and format any calculation based values that ARE NOT IN invHdr table
        resetCalculatedValues()

        ' **** INITIALLY (now), subtotal and balance will be calculated from the values in the invHdr row, NOT using their respective calculation/initialization subs.
        '       This is because we want to ensure that we are displaying the data in the invoice, not what the data should be.
        '       So, manually calculate and initialize SubTotal and Balance here based on InvHdr row values.

        ' Calculate SubTotal and Balance based on values of invoice (from InvHdr) instead of calculating them live.
        ' INSTEAD of calculating these values, these values will START as their initial values from the InvHdr DataTable row.
        ' Then, on a textchange event, for instance, some of these values will be recalculated.
        InvLaborSum = InvDbController.DbDataTable(InvRow)("TotalLabor")
        InvPartsSum = InvDbController.DbDataTable(InvRow)("TotalParts")
        ShopCharges = InvDbController.DbDataTable(InvRow)("ShopCharges")
        SubTotal = InvLaborSum + InvPartsSum + ShopCharges
        Tax = InvDbController.DbDataTable(InvRow)("Tax")
        Gas = InvDbController.DbDataTable(InvRow)("Gas")
        Towing = InvDbController.DbDataTable(InvRow)("Towing")
        InvTotalSum = InvDbController.DbDataTable(InvRow)("InvTotal")
        InvPaymentsSum = InvDbController.DbDataTable(InvRow)("TotalPaid")
        Balance = InvTotalSum - InvPaymentsSum

        SubTotalTextbox.Text = SubTotal
        BalanceTextbox.Text = Balance

        formatDataEditingControls()

        ' Set forecolor if not already initially default
        setForeColor(getAllControlsWithTag("dataEditingControl", Me), DefaultForeColor)

    End Sub


    ' NOTE: these subs only format controls that don't have their FORMATTING handled by a separate sub
    ' Sub that will add formatting to already initialized dataViewingControls
    Private Sub formatDataViewingControls()

        ' Can usually get value from DataTable or value text, some values are just safer to get from DataTable

        ' Formatting for Dates. Use globals function to do New DateTime checking and set value accordingly
        InvDate_Value.Text = formatDate(InvDbController.DbDataTable(InvRow)("InvDate"))
        ApptDate_Value.Text = formatDate(InvDbController.DbDataTable(InvRow)("ApptDate"))
        WorkDate_Value.Text = formatDate(InvDbController.DbDataTable(InvRow)("WorkDate"))
        PayDate_Value.Text = formatDate(InvDbController.DbDataTable(InvRow)("PayDate"))

        ' Formatting for Phone Numbers
        ContactPhone1_Value.Text = formatPhoneNumber(ContactPhone1_Value.Text)
        ContactPhone2_Value.Text = formatPhoneNumber(ContactPhone2_Value.Text)

        ' Calculation based fields are formatted here
        TotalLabor_Value.Text = FormatCurrency(TotalLabor_Value.Text)
        TotalParts_Value.Text = FormatCurrency(TotalParts_Value.Text)
        ShopCharges_Value.Text = FormatCurrency(ShopCharges_Value.Text)
        SubTotalValue.Text = FormatCurrency(SubTotalValue.Text)
        Tax_Value.Text = FormatCurrency(Tax_Value.Text)
        Gas_Value.Text = FormatCurrency(Gas_Value.Text)
        Towing_Value.Text = FormatCurrency(Towing_Value.Text)
        InvTotal_Value.Text = FormatCurrency(InvTotal_Value.Text)
        TotalPaid_Value.Text = FormatCurrency(TotalPaid_Value.Text)
        BalanceValue.Text = FormatCurrency(BalanceValue.Text)

    End Sub


    ' Sub that will add formatting to already initialized dataEditingControls
    Private Sub formatDataEditingControls()

        ' Formatting for Dates. Use globals function to do New DateTime checking and set value accordingly
        InvDate_Textbox.Text = formatDate(InvDbController.DbDataTable(InvRow)("InvDate"))
        ApptDate_Textbox.Text = formatDate(InvDbController.DbDataTable(InvRow)("ApptDate"))
        WorkDate_Textbox.Text = formatDate(InvDbController.DbDataTable(InvRow)("WorkDate"))
        PayDate_Textbox.Text = formatDate(InvDbController.DbDataTable(InvRow)("PayDate"))

        ' Format phone number for ContactPhone1 and ContactPhone 2
        ContactPhone1_ComboBox.Text = formatPhoneNumber(ContactPhone1_ComboBox.Text)
        ContactPhone2_ComboBox.Text = formatPhoneNumber(ContactPhone2_ComboBox.Text)

        ' Initial formatting for currency values initialized from invHdr
        TotalLabor_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(TotalLabor_Textbox.Text))
        TotalParts_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(TotalParts_Textbox.Text))
        ShopCharges_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(ShopCharges_Textbox.Text))
        SubTotalTextbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(SubTotalTextbox.Text))
        Tax_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(Tax_Textbox.Text))
        Gas_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(Gas_Textbox.Text))
        Towing_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(Towing_Textbox.Text))
        InvTotal_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(InvTotal_Textbox.Text))
        TotalPaid_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(TotalPaid_Textbox.Text))
        BalanceTextbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(BalanceTextbox.Text))

    End Sub





    ' Sub that resets variables that maintain each calculated value.
    Private Sub resetCalculatedValues()

        InvLaborSum = 0
        InvPartsSum = 0
        ShopCharges = 0
        SubTotal = 0
        Tax = 0
        Gas = 0
        Towing = 0
        InvTotalSum = 0
        Taxable = 0
        NonTaxable = 0
        InvPaymentsSum = 0
        Balance = 0

    End Sub

    ' Sub that is used to assign 0 to all calculation based controls upon adding a new invoice
    Private Sub InitializeCalculatedOnAdd()

        TotalLabor_Textbox.Text = String.Format("{0:0.00}", InvLaborSum)
        TotalParts_Textbox.Text = String.Format("{0:0.00}", InvPartsSum)
        ShopCharges_Textbox.Text = String.Format("{0:0.00}", ShopCharges)
        SubTotalTextbox.Text = String.Format("{0:0.00}", SubTotal)
        Tax_Textbox.Text = String.Format("{0:0.00}", Tax)
        Gas_Textbox.Text = String.Format("{0:0.00}", Gas)
        Towing_Textbox.Text = String.Format("{0:0.00}", Towing)
        InvTotal_Textbox.Text = String.Format("{0:0.00}", InvTotalSum)
        TotalPaid_Textbox.Text = String.Format("{0:0.00}", InvPaymentsSum)
        BalanceTextbox.Text = String.Format("{0:0.00}", Balance)

    End Sub




    ' Sub that calculates Invoice Labor Cost based on the total cost of all of the labor codes in InvLabor with current InvId
    Private Sub calcInvLaborSum()

        InvLaborSum = 0      ' Must zero this here, as this value is being re-calculated
        For Each row In InvLaborDbController.DbDataTable.Rows
            InvLaborSum += row("LaborAmount")
        Next

    End Sub


    ' Sub that calculates Invoice Parts Cost based on the total cost of all of the Parts in InvParts with current InvId
    Private Sub calcInvPartsSum()

        InvPartsSum = 0      ' Must zero this here, as this value is being re-calculated
        For Each row In InvPartsDbController.DbDataTable.Rows
            InvPartsSum += row("PartAmount")
        Next

    End Sub


    ' Sub that calculates Shop charges based on whether or not shop supplies checked, and if so, then on the ShopSupplyCharge rate from Company Master
    Private Sub calcShopCharges()

        Dim shopSupplies As Boolean
        ' If in editing, then get shopSupplies value from ShopSupplies_CheckBox
        If Not modifyInvButton.Enabled Then
            shopSupplies = ShopSupplies_CheckBox.Checked
            ' Otherwise, get it from ShopSupplies_Value
        Else
            shopSupplies = ShopSupplies_Value.Checked
        End If

        If shopSupplies Then
            Dim shopSupplyCharge As Decimal = CMDbController.DbDataTable.Rows(CMRow)("ShopSupplyCharge")
            Dim laborPartsTotal As Decimal = InvLaborSum + InvPartsSum
            ShopCharges = Math.Round((shopSupplyCharge * laborPartsTotal), 2)
        Else
            ShopCharges = 0
        End If

    End Sub


    ' Sub that calculates SubTotal based on InvLaborSum, InvPartsSum, and Shop Charges
    Private Sub calcSubTotal()

        SubTotal = InvLaborSum + InvPartsSum + ShopCharges

    End Sub


    ' Sub that calculates Tax based on whether or not Tax Exempt is checked, and if so, then the TaxRate from Company Master * SubTotal.
    Private Sub calcTax()

        Dim taxExempt As Boolean = TaxExempt_CheckBox.Checked

        If taxExempt Then

            ' If marked as tax exempt, and changes made to shop charges or similar, then Tax will remain unaffected at 0.00
            ' As a result, InvTotal will not be calculated, as taxEventTextChanged never fires and InvTotal is never initialized
            ' So, if we find that TaxExempt is true, we will manually fire the TaxTextBox_TextChanged event
            Tax_Textbox_TextChanged(Tax_Textbox, New EventArgs())

            Tax = 0
        Else
            Dim taxRate As Decimal = CMDbController.DbDataTable.Rows(CMRow)("TaxRate")
            Tax = Math.Round((taxRate * SubTotal), 2)
        End If

    End Sub


    ' Sub that GETS Gas value.
    ' This will be called only in the InitializeInvTotal Sub (after checking that the value in Gas_Textbox is valid currency) alongside getTowing()
    Private Sub getGas()

        Gas = Convert.ToDecimal(Gas_Textbox.Text)

    End Sub

    Private Sub getTowing()

        Towing = Convert.ToDecimal(Towing_Textbox.Text)

    End Sub


    ' Sub that calculates InvTotalSum based on Subtotal, Tax, Gas, and Towing
    '   Reminder that this sub will only be called if the values it depends on are valid (validation done in InitializeInvTotal()
    Private Sub calcInvTotalSum()

        InvTotalSum = SubTotal + Tax + Gas + Towing

    End Sub


    ' Sub that calculates InvPaymentsSum based on the sum of the PayAmounts in each row of InvPayments corresponding to current invoice InvId
    Private Sub calcInvPaymentsSum()

        InvPaymentsSum = 0      ' Must zero this here, as this value is being re-calculated
        For Each row In InvPaymentsDbController.DbDataTable.Rows
            InvPaymentsSum += row("PayAmount")
        Next

    End Sub


    ' Sub that calculates Balance based on InvTotalSum and InvPaymentsSum
    Private Sub calcBalance()

        Balance = InvTotalSum - InvPaymentsSum

    End Sub


    ' Sub that calculates Taxable and NonTaxable. This will be called InitializeInvTotal()
    Private Sub calcTaxableNonTaxable()

        Dim taxExempt As Boolean = TaxExempt_CheckBox.Checked

        ' Calculate Taxable and NonTaxable
        If taxExempt Then
            Taxable = 0
            NonTaxable = InvTotalSum
        Else
            Taxable = SubTotal
            NonTaxable = Gas + Towing
        End If

    End Sub


    ' Sub that gets the number of tasks associated with the invoice
    Private Sub getNbrTasks()

        NbrTasks = InvTaskDbController.DbDataTable.Rows.Count

    End Sub





    ' Public Function called after invoice task tables have been changed that reinitializes dependent DataTables, corresponding DataGridViews,
    ' And subTaskEditingControls.
    Public Function reinitializeDependents() As Boolean


        ' 1.) Determine how shopCharges will be inserted
        ' Alternate option: Don't recalc shopcharges if custom value already entered
        Dim calculateShopCharges As Boolean = True
        Dim properShopCharge As Decimal
        Dim shopChargeRate As Decimal = CMDbController.DbDataTable.Rows(CMRow)("ShopSupplyCharge")
        Dim laborPartsTotal As Decimal = InvLaborSum + InvPartsSum
        properShopCharge = Math.Round((shopChargeRate * laborPartsTotal), 2)

        ' Use shopSupplies_value here, as no changes being made while editing
        If ShopSupplies_Value.Checked And ShopCharges <> 0 And ShopCharges <> properShopCharge Then
            ' This must mean there is a custom value, so do not recalculate shop charges
            calculateShopCharges = False
            ' In order that we don't overwrite the custom value, ensure that ShopCharges is set to the current custom Shop Charges value from invoice row.
            ShopCharges = InvDbController.DbDataTable.Rows(InvRow)("ShopCharges")
        End If

        ' 2.) Reload dependent datatables (InvTask and InvPayments). Must do this before recalculating InvTask and InvPayment values
        If Not loadDependentDataTables() Then
            MessageBox.Show("Failed to connect to database; Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        ' 3.) Recalculate values that may have changed from forms outside of this one. I.e. InvLaborSum, InvPartsSum, InvPaymentsSum, and NbrTasks.
        calcInvLaborSum()
        calcInvPartsSum()
        calcInvPaymentsSum()
        getNbrTasks()

        ' 4.) As these values contribute to the InvTotal cost and other calculations like subtotal, tax, balance, etc., we must recalculate all of those values.
        '       Because these forms can only be accessed while not editing other invoice data values, we can use the values currently in the table for our calculations
        '       Because all of these values are already stored in variables, we can use our calculation subs to recalculate the values that are dependendent on
        '       a.) InvLaborSum     b.) InvPartsSum     c.) InvPaymentsSum

        If calculateShopCharges Then calcShopCharges()
        'calcShopCharges()
        calcSubTotal()
        calcTax()
        calcInvTotalSum()

        ' 5.) Also, determine date of the most recent payment in InvPayments
        Dim mostRecentDate As Object
        mostRecentDate = InvPaymentsDbController.DbDataTable.Compute("Max(PayDate)", "")

        ' 6.) Add these newly calculated values as parameters
        CRUD.AddParams("@nbrtasks", NbrTasks)
        CRUD.AddParams("@totallabor", InvLaborSum)
        CRUD.AddParams("@totalparts", InvPartsSum)
        CRUD.AddParams("@shopcharges", ShopCharges)
        CRUD.AddParams("@tax", Tax)
        CRUD.AddParams("@invtotal", InvTotalSum)
        CRUD.AddParams("@totalpaid", InvPaymentsSum)
        CRUD.AddParams("@paydate", mostRecentDate)
        CRUD.AddParams("@taxable", Taxable)
        CRUD.AddParams("@nontaxable", NonTaxable)
        CRUD.AddParams("@invid", InvId)

        ' 7.) Then insert these new values into the InvHdr row
        CRUD.ExecQuery("UPDATE InvHdr SET NbrTasks=@nbrtasks, TotalLabor=@totallabor, TotalParts=@totalparts, ShopCharges=@shopcharges, Tax=@tax, InvTotal=@invtotal, TotalPaid=@totalpaid, " &
                       "PayDate=@paydate, Taxable=@taxable, NonTaxable=@nontaxable " &
                       "WHERE InvNbr=@invid")
        If CRUD.HasException() Then Return False

        ' 8.) Then, controls can be initialized again as if we were just opening up the invoice for the first time, and all of the values will be up to date.

        valuesInitialized = False

        ' Reload InvHdr rows
        If Not loadInvoiceDataTable() Then
            MessageBox.Show("Failed to connect to database; Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        ' Initialize all dataEditingControls
        InitializeAllDataViewingControls()

        valuesInitialized = True


        Return True

    End Function







    ' ***************** CRUD SUBS *****************


    ' UPDATING CRUD SUBS
    Private Function updateInvoice() As Boolean

        ' Excluded Value List
        '   ContactPhone1, ContactPhone2, and InvNbr (InvNbr primary auto-increment key, can't be updated)

        ' Additional Values:
        '   Taxable, NonTaxable, ContactPhone1, ContactPhone2

        ' 1. ) THIS IS DONE SEPARATELY HERE, so as to avoid getting 0.00 being ignored and entered as a DBNull in the updateTable function.
        CRUD.AddParams("@taxable", Taxable)
        CRUD.AddParams("@nontaxable", NonTaxable)
        CRUD.AddParams("@invId", InvId)
        CRUD.ExecQuery("UPDATE InvHdr SET Taxable=@taxable, NonTaxable=@nontaxable WHERE InvNbr=@invId")
        If CRUD.HasException() Then Return False

        ' 2.) THEN UPDATE INVOICE AS USUAL
        ' Get stripped versions of Contact Phone Numbers
        Dim ContactPhone1 As String = removeInvalidChars(ContactPhone1_ComboBox.Text, "0123456789")
        Dim ContactPhone2 As String = removeInvalidChars(ContactPhone2_ComboBox.Text, "0123456789")

        Dim excludedControls As New List(Of Control) From {ContactPhone1_ComboBox, ContactPhone2_ComboBox, InvNbr_Textbox}
        Dim additionalValues As New List(Of AdditionalValue) From {
            New AdditionalValue("ContactPhone1", GetType(String), ContactPhone1),
            New AdditionalValue("ContactPhone2", GetType(String), ContactPhone2)}

        updateTable(CRUD, InvDbController.DbDataTable, "InvHdr", InvId, "InvNbr", "_", "dataEditingControl", Me, excludedControls, additionalValues)
        If CRUD.HasException() Then Return False

        Return True

    End Function


    ' INSERTING CRUD SUB
    Private Function insertInvoice() As Boolean

        ' Other additional values that were not included in update that are needed here:
        '   VehicleId

        ' Get stripped versions of Contact Phone Numbers
        Dim ContactPhone1 As String = removeInvalidChars(ContactPhone1_ComboBox.Text, "0123456789")
        Dim ContactPhone2 As String = removeInvalidChars(ContactPhone2_ComboBox.Text, "0123456789")

        Dim excludedControls As New List(Of Control) From {ContactPhone1_ComboBox, ContactPhone2_ComboBox, InvNbr_Textbox}
        Dim additionalValues As New List(Of AdditionalValue) From {
            New AdditionalValue("CustomerId", GetType(Integer), CustomerId),
            New AdditionalValue("VehicleId", GetType(Integer), VehicleId),
            New AdditionalValue("ContactPhone1", GetType(String), ContactPhone1),
            New AdditionalValue("ContactPhone2", GetType(String), ContactPhone2)}

        insertRow(CRUD, InvDbController.DbDataTable, "InvHdr", "_", "dataEditingControl", Me, excludedControls, additionalValues)
        If CRUD.HasException() Then Return False

        ' Then, in new row, manually insert Taxable and NonTaxable
        CRUD.ExecQuery("SELECT InvNbr FROM InvHdr WHERE InvNbr=(SELECT max(InvNbr) FROM InvHdr)")
        Dim newInvNbr As Long
        If CRUD.DbDataTable.Rows.Count <> 0 And Not CRUD.HasException(True) Then
            ' Get new InvNbr if query successful
            newInvNbr = CRUD.DbDataTable.Rows(0)("InvNbr")
        Else
            Return False
        End If

        ' THIS IS DONE SEPARATELY DOWN HERE, so as to avoid getting 0.00 being ignored and entered as a DBNull in the insertRowFunction.
        CRUD.AddParams("@taxable", Taxable)
        CRUD.AddParams("@nontaxable", NonTaxable)
        CRUD.AddParams("@invId", newInvNbr)
        CRUD.ExecQuery("UPDATE InvHdr SET Taxable=@taxable, NonTaxable=@nontaxable WHERE InvNbr=@invId")
        If CRUD.HasException() Then Return False

        Return True

    End Function


    ' Update CRUD function used for updating Inspection Month and Sticker Number of vehicle ONLY when adding a NEW INVOICE
    Private Function updateVehicle() As Boolean

        ' Because inspectionSticker is queried with a different column name, we must exclude it and add it as an additional value where we can customize its column name
        ' Inspection month should be fine, so we can leave this as it is for the function to pick up
        Dim excludedControls As New List(Of Control) From {InspectionSticker_Textbox}
        Dim additionalValues As New List(Of AdditionalValue) From {New AdditionalValue("InspectionStickerNbr", GetType(String), InspectionSticker_Textbox.Text)}

        updateTable(CRUD, VehicleDbController.DbDataTable, "Vehicle", VehicleId, "VehicleId", "_", "dataEditingControl", Me, excludedControls, additionalValues)
        If CRUD.HasException() Then Return False

        Return True

    End Function


    ' DELETE CRUD SUB
    Private Function deleteInvoice() As Boolean

        deleteRow(CRUD, "InvHdr", InvId, "InvNbr")
        If CRUD.HasException() Then Return False

        ' Otherwise, return true
        Return True

    End Function



    ' Function used to query vehicles table based on LicenseState and LicensePlate
    Private Function searchVehicles() As Boolean

        CRUD.AddParams("@licensestate", LicenseStateComboBox.Text)
        CRUD.AddParams("@licenseplate", LicensePlateTextbox.Text)
        CRUD.ExecQuery("SELECT v.CustomerId, v.VehicleId, v.LicenseState, v.LicensePlate " &
                                       "FROM Vehicle v " &
                                       "WHERE LicenseState=@licensestate AND LicensePlate=@licenseplate " &
                                       "ORDER BY v.VehicleId ASC")
        If CRUD.HasException() Then Return False

        Return True

    End Function




    ' **************** VALIDATION SUBS ****************


    ' Make sure to ensure that ContactPhone1 does not have the same value as Contact Phone 2, and also make sure that the values in both exist in the CustomerPhoneList
    ' Maybe write custom validation function for mileage if we allow them to use numbers with commas (instead of writing global function)
    Private Function controlsValid() As Boolean

        Dim errorMessage As String = String.Empty

        ' Use "Required" parameter to control whether or not a Null string value will cause an error to be reported


        ' Invoice Date (REQUIRED)
        If Not validDateTime("Invoice Date", True, InvDate_Textbox.Text, errorMessage) Then
            InvDate_Textbox.ForeColor = Color.Red
        End If

        ' Contact
        If Not isValidLength("Contact", False, ContactName_Textbox.Text, 25, errorMessage) Then
            ContactName_Textbox.ForeColor = Color.Red
        End If

        ' Contact Phone Validation
        PhonesMatching = False
        Dim p1 As String = removeInvalidChars(ContactPhone1_ComboBox.Text, "0123456789")
        Dim p2 As String = removeInvalidChars(ContactPhone2_ComboBox.Text, "0123456789")

        ' Contact Phone 1 (Must exist in CustomerPhoneList, and cannot equal the value in Contact Phone 2)
        If Not String.IsNullOrWhiteSpace(ContactPhone1_ComboBox.Text) And Not CustomerPhoneList.Contains(p1) Then
            errorMessage += "ERROR: " & ContactPhone1_ComboBox.Text & " does not exist" & vbNewLine
            ContactPhone1_ComboBox.ForeColor = Color.Red
        End If

        ' Contact Phone 2 (Must exist in CustomerPhoneList, and cannot equal the value in Contact Phone 1)
        If Not String.IsNullOrWhiteSpace(ContactPhone2_ComboBox.Text) And Not CustomerPhoneList.Contains(p2) Then
            errorMessage += "ERROR: " & ContactPhone2_ComboBox.Text & " does not exist" & vbNewLine
            ContactPhone2_ComboBox.ForeColor = Color.Red
        End If

        ' Checking if both ContactPhones are equivalent
        If Not String.IsNullOrEmpty(p1) And Not String.IsNullOrEmpty(p2) And p1 = p2 Then
            errorMessage += "ERROR: Contact Phone 1 and Contact Phone 2 cannot have the same phone number" & vbNewLine
            PhonesMatching = True
            ContactPhone1_ComboBox.ForeColor = Color.Red
            ContactPhone2_ComboBox.ForeColor = Color.Red
        End If

        ' Inspection Month
        If Not isValidLength("Inspection Month", False, InspectionMonth_ComboBox.Text, 3, errorMessage) Then
            InspectionMonth_ComboBox.ForeColor = Color.Red
        ElseIf Not String.IsNullOrWhiteSpace(InspectionMonth_ComboBox.Text) And Not valueExists("Month", InspectionMonth_ComboBox.Text, MonthDbController.DbDataTable) Then
            errorMessage += "ERROR: " & InspectionMonth_ComboBox.Text & " is not a valid Month" & vbNewLine
            InspectionMonth_ComboBox.ForeColor = Color.Red
        End If

        ' Inspection Sticker
        If Not isValidLength("Inspection Sticker Number", False, InspectionSticker_Textbox.Text, 15, errorMessage) Then
            InspectionSticker_Textbox.ForeColor = Color.Red
        End If

        ' Mileage
        If Not validNumber("Mileage", False, Mileage_Textbox.Text, errorMessage, True) Then Mileage_Textbox.ForeColor = Color.Red

        ' Appointment Date
        If Not validDateTime("Appointment Date", True, ApptDate_Textbox.Text, errorMessage) Then
            ApptDate_Textbox.ForeColor = Color.Red
        End If

        ' Work Date
        If Not validDateTime("Work Date", True, WorkDate_Textbox.Text, errorMessage) Then
            WorkDate_Textbox.ForeColor = Color.Red
        End If

        ' Notes
        If Not isValidLength("Notes", False, Notes_Textbox.Text, 255, errorMessage) Then
            Notes_Textbox.ForeColor = Color.Red
        End If

        ' Shop Charges
        If Not validCurrency("Shop Charges", False, ShopCharges_Textbox.Text, errorMessage) Then
            ShopCharges_Textbox.ForeColor = Color.Red
        End If

        ' Gas
        If Not validCurrency("Gas", False, Gas_Textbox.Text, errorMessage) Then
            Gas_Textbox.ForeColor = Color.Red
        End If

        ' Towing
        If Not validCurrency("Towing", False, Towing_Textbox.Text, errorMessage) Then
            Towing_Textbox.ForeColor = Color.Red
        End If


        ' Check if any invalid input has been found
        If Not String.IsNullOrEmpty(errorMessage) Then

            MessageBox.Show(errorMessage, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False

        End If

        Return True

    End Function



    Private Function LicenseSearchControlsValid() As Boolean

        Dim errorMessage As String = String.Empty

        ' Use "Required" parameter to control whether or not a Null string value will cause an error to be reported


        ' License State
        If Not isValidLength("License State", True, LicenseStateComboBox.Text, 2, errorMessage) Then
            LicenseStateComboBox.ForeColor = Color.Red
        ElseIf Not String.IsNullOrWhiteSpace(LicenseStateComboBox.Text) And Not valueExists("State", LicenseStateComboBox.Text, StateDbController.DbDataTable) Then
            errorMessage += "ERROR: " & LicenseStateComboBox.Text & " is not a valid State" & vbNewLine
            LicenseStateComboBox.ForeColor = Color.Red
        End If

        ' License Plate
        If Not isValidLength("License Plate", True, LicensePlateTextbox.Text, 10, errorMessage) Then
            LicensePlateTextbox.ForeColor = Color.Red
        End If


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




        ' INVOICES IS THE HOME SCREEN --> THIS SECTION WILL CONTAIN HOME-RELATED PROCESSES

        ' Add event handler for when the application exits.
        ' However, must first check if this event has already been handled using global flag.
        If Not ApplicationExitHandled Then
            AddHandler Application.ApplicationExit, AddressOf OnApplicationExit
            ApplicationExitHandled = True
        End If




        ' NORMAL INVOICES OPERATIONS HERE
        If Not checkDbConn() Then Exit Sub

        If Not loadCustomerDataTable() Then
            MessageBox.Show("Failed to load Customer table; Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        InitializeCustomerComboBox()
        CustomerComboBox.SelectedIndex = 0

        If Not loadStatesDataTable() Then
            MessageBox.Show("Failed to load States table; Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        InitializeStateComboBox()
        LicenseStateComboBox.SelectedIndex = LicenseStateComboBox.Items.IndexOf("PA")   ' Most cars will have PA licenses

        If Not loadCMDataTable() Then
            MessageBox.Show("Failed to load Company Master table; Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Not loadMonthDataTable() Then
            MessageBox.Show("Failed to load Months table; Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        InitializeInspectionMonthComboBox()

    End Sub

    Private Sub invoices_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' PRE-DRAW PRE-LOADED (Preliminary) COMBOBOXES. 
        ' This way, we don't have to wait for them to draw on first edit/add

        InspectionMonth_ComboBox.Visible = True
        InspectionMonth_ComboBox.Visible = False

    End Sub


    ' EVENT HANDLER FOR APPLICATION EXIT EVENT
    Private Sub OnApplicationExit(ByVal sender As Object, ByVal e As EventArgs)

        ' Before the application closes, backup current database and prune existing backups
        backupDb()

    End Sub





    ' **************** LICENSE PLATE SEARCH CONTROL SUBS ****************

    ' Must lookup vehicle based on License State and LicensePlate
    ' Will have to use Database CRUD call for this
    Private Sub licensePlateSearchButton_Click(sender As Object, e As EventArgs) Handles licensePlateSearchButton.Click

        ' 1.) Validate that both LicenseState and LicensePlate fields are populated
        If Not LicenseSearchControlsValid() Then Exit Sub

        ' 2.) If valid, then attempt to lookup License Plate in vehicles table
        If Not searchVehicles() Then
            MessageBox.Show("Failed to search database; Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' 3.) If query was successful, analyze the resulting rows

        ' If vehicle not found, 0 rows will be returned. Report this to user.
        If CRUD.DbDataTable.Rows.Count = 0 Then
            MessageBox.Show("No vehicle found with license plate " & LicensePlateTextbox.Text & " in " & LicenseStateComboBox.Text, "Vehicle Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        ElseIf CRUD.DbDataTable.Rows.Count > 0 Then

            ' Get data from the first row that it returns. Should only return one row, but just in case multiple are, only get the first.
            CustomerId = CRUD.DbDataTable.Rows(0)("CustomerId")
            VehicleId = CRUD.DbDataTable.Rows(0)("VehicleId")

            ' First, use CustomerId to get associated Customer
            Dim CLFA As String = getRowValueWithKeyEquals(CustomerDbController.DbDataTable, "CLFA", "CustomerId", CustomerId)
            ' If associated CLFA found, then select that CLFA in the CustomerComboBox
            If CLFA <> Nothing Then
                CustomerComboBox.SelectedIndex = CustomerComboBox.Items.IndexOf(CLFA)

                ' Then, as CLFA selected, we can select the vehicle that corresponds with the VehicleId we have
                Dim YMML As String = getRowValueWithKeyEquals(VehicleDbController.DbDataTable, "YMML", "VehicleId", VehicleId)
                ' If associated YMML found, then select that YMML in the VehicleComboBox
                If YMML <> Nothing Then
                    VehicleComboBox.SelectedIndex = VehicleComboBox.Items.IndexOf(YMML)
                    ' Done
                Else
                    MessageBox.Show("Vehicle found, but unable to select it", "Can't Select Vehicle", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

            Else
                MessageBox.Show("Vehicle found, but unable to find owner", "Owner Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

        End If


        ' If vehicle found, then will need to select Customer and Vehicle in respective ComboBoxes


    End Sub





    ' **************** CONTROL SUBS ****************


    Private Sub CustomerComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CustomerComboBox.SelectedIndexChanged, CustomerComboBox.TextChanged

        ' Ensure that CustomerCombobox is only enabling user to select vehicle if valid index selected
        If CustomerComboBox.SelectedIndex = -1 Then

            ' If not already, clear and empty the VehicleComboBox
            If VehicleComboBox.Text <> String.Empty And VehicleComboBox.Items.Count <> 0 Then
                VehicleComboBox.Items.Clear()
                VehicleComboBox.Text = String.Empty
            End If
            VehicleComboBox.Visible = False
            VehicleLabel.Visible = False

            VehicleComboBox.SelectedIndex = -1
            VehicleComboBox_SelectedIndexChanged(VehicleComboBox, New EventArgs())
            ' This is the important part: when vehicle combo gets -1 as selectedIndex, it will subsequently set the selectedindex
            ' of the invCombobox to -1, which will THEN hide all of the controls in a CASCADING FASHION

            ' Disable user from creating new invoice until valid vehicle selected
            newInvButton.Enabled = False

            Exit Sub

        End If

        ' Lookup newly selected row and see if it is valid (valid if it corresponds with a datatable row)
        CustomerRow = getDataTableRow(CustomerDbController.DbDataTable, "CLFA", CustomerComboBox.Text)

        If CustomerRow <> -1 Then

            ' CustomerRow doesn't mean anything to vehicleComboBox. VehicleComboBox query only concerned about the CustomerId
            ' So, if the customer entered in CustomerComboBox exists (valid CLFA), then lookup the corresponding ID
            CustomerId = CustomerDbController.DbDataTable(CustomerRow)("CustomerId")

            ' Initialize Customer Phone List after valid Customer has been selected
            InitializeCustomerPhoneList()
            InitializeContactPhone1ComboBox()
            InitializeContactPhone2ComboBox()

            ' Then, load the vehicleDataTable and initialize vehicleComboBox based on this newfound CustomerId
            If Not loadVehicleDataTable() Then
                MessageBox.Show("Failed to connect to database; Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            InitializeVehicleComboBox()
            VehicleComboBox.Visible = True
            VehicleLabel.Visible = True
            VehicleComboBox.SelectedIndex = 0

            ' Now that valid Customer selected, move user to vehicleCombobox
            CustomerComboBox.SelectionLength = 0
            VehicleComboBox.Focus()

            'If it does = -1, that means that value Is either "Select one" Or some other anomoly
        Else

            ' If not already, clear and empty the VehicleComboBox
            If VehicleComboBox.Text <> String.Empty And VehicleComboBox.Items.Count <> 0 Then
                VehicleComboBox.Items.Clear()
                VehicleComboBox.Text = String.Empty
            End If
            VehicleComboBox.Visible = False
            VehicleLabel.Visible = False

            VehicleComboBox.SelectedIndex = -1
            VehicleComboBox_SelectedIndexChanged(VehicleComboBox, New EventArgs())

            ' Disable user from creating new invoice until valid vehicle selected
            newInvButton.Enabled = False

        End If

    End Sub


    Private Sub VehicleComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles VehicleComboBox.SelectedIndexChanged, VehicleComboBox.TextChanged

        ' Ensure that VehicleComboBox is only enabling user to select invoiceNum if valid index selected
        If VehicleComboBox.SelectedIndex = -1 Then

            ' If not already, clear and empty the invoiceNumComboBox
            If InvoiceComboBox.Text <> String.Empty And InvoiceComboBox.Items.Count <> 0 Then
                InvoiceComboBox.Items.Clear()
                InvoiceComboBox.Text = String.Empty
            End If
            InvoiceComboBox.Visible = False
            invoiceLabel.Visible = False

            InvoiceComboBox.SelectedIndex = -1
            InvoiceNumComboBox_SelectedIndexChanged(InvoiceComboBox, New EventArgs())

            ' Disable user from creating new invoice until valid vehicle selected
            newInvButton.Enabled = False
            ' User may not view vehicle history when no valid vehicle selected
            vehicleHistoryButton.Visible = False

            Exit Sub

        End If

        ' Lookup newly selected row and see if it is valid (valid if it corresponds with a datatable row)
        VehicleRow = getDataTableRow(VehicleDbController.DbDataTable, "YMML", VehicleComboBox.Text)

        If VehicleRow <> -1 Then

            ' VehicleRow doesn't mean anything to InvComboBox. InvComboBox query only concerned about the VehicleId
            ' So, if the vehicle entered in VehicleComboBox exists (valid YMML), then lookup the corresponding ID
            VehicleId = VehicleDbController.DbDataTable(VehicleRow)("VehicleId")

            ' Then, load the Invoice DataTable and initialize InvComboBox based on this newfound VehicleId
            If Not loadInvoiceDataTable() Then
                MessageBox.Show("Failed to connect to database; Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            InitializeInvoiceNumComboBox()
            InvoiceComboBox.Visible = True
            invoiceLabel.Visible = True
            InvoiceComboBox.SelectedIndex = 0

            ' Now that valid vehicle selected, user may add new invoice associated with that vehicle
            newInvButton.Enabled = True
            ' User may now also view vehicle history of the selected vehicle
            vehicleHistoryButton.Visible = True

            ' Now that valid vehicle selected, move user to invoice combobox
            VehicleComboBox.SelectionLength = 0
            InvoiceComboBox.Focus()

            'If it does = -1, that means that value Is either "Select one" Or some other anomoly
        Else

            ' If not already, clear and empty the invoiceNumComboBox
            If InvoiceComboBox.Text <> String.Empty And InvoiceComboBox.Items.Count <> 0 Then
                InvoiceComboBox.Items.Clear()
                InvoiceComboBox.Text = String.Empty
            End If
            InvoiceComboBox.Visible = False
            invoiceLabel.Visible = False

            InvoiceComboBox.SelectedIndex = -1
            InvoiceNumComboBox_SelectedIndexChanged(InvoiceComboBox, New EventArgs())

            ' Disable user from creating new invoice until valid vehicle selected
            newInvButton.Enabled = False
            ' User may not view vehicle history when no valid vehicle selected
            vehicleHistoryButton.Visible = False

        End If

    End Sub


    Private Sub InvoiceNumComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles InvoiceComboBox.SelectedIndexChanged, InvoiceComboBox.TextChanged

        ' Ensure that invoiceNumComboBox is only attempting to initialize values when on proper selected Index
        If InvoiceComboBox.SelectedIndex = -1 Then

            ' Have all labels and corresponding values hidden
            showHide(getAllNestedControlsWithTag("dataViewingControl", Me), 0)
            showHide(getAllNestedControlsWithTag("dataLabel", Me), 0)
            showHide(getAllNestedControlsWithTag("dataEditingControl", Me), 0)
            ' Disable editing button
            modifyInvButton.Enabled = False
            deleteInvButton.Enabled = False
            previewInvButton.Enabled = False

            Exit Sub

        End If

        ' Lookup newly selected row and see if it is valid (valid if it corresponds with a datatable row)
        InvRow = getDataTableRowEquals(InvDbController.DbDataTable, "INID", InvoiceComboBox.Text)

        ' If this query DOES return a valid row index, then initialize respective controls
        If InvRow <> -1 Then

            InvId = InvDbController.DbDataTable.Rows(InvRow)("InvNbr")

            ' Initialize corresponding controls from DataTable values
            valuesInitialized = False

            ' Load ALl depedent DataTables based on InvId selected, then reinitialize corresponding depedent calculated control-values
            If Not loadDependentDataTables() Then
                MessageBox.Show("Failed to connect to database; Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            ' Reinitialize all dataViewingControls
            InitializeAllDataViewingControls()

            valuesInitialized = True

            ' Show labels and corresponding values
            showHide(getAllNestedControlsWithTag("dataViewingControl", Me), 1)
            showHide(getAllNestedControlsWithTag("dataLabel", Me), 1)
            showHide(getAllNestedControlsWithTag("dataEditingControl", Me), 0)

            ' Enable editing and deleting button
            modifyInvButton.Enabled = True
            deleteInvButton.Enabled = True
            previewInvButton.Enabled = True

            'If it does = -1, that means that value Is either "Select one" Or some other anomoly
        Else

            ' Have all labels and corresponding values hidden
            showHide(getAllNestedControlsWithTag("dataViewingControl", Me), 0)
            showHide(getAllNestedControlsWithTag("dataLabel", Me), 0)
            showHide(getAllNestedControlsWithTag("dataEditingControl", Me), 0)
            ' Disable editing button
            modifyInvButton.Enabled = False
            deleteInvButton.Enabled = False
            previewInvButton.Enabled = False

        End If

    End Sub



    Private Sub newInvButton_Click(sender As Object, e As EventArgs) Handles newInvButton.Click

        mode = "adding"


        ' Initialize values for dataEditingControls
        valuesInitialized = False

        clearControls(getAllNestedControlsWithTag("dataEditingControl", Me))

        ' Initialize values from Customer and Vehicle
        InitializeVehicleDataEditingControls()
        correctInspectionMonthComboBox()
        InitializeFromCustomer()
        ' setup ComboBoxes
        If ContactPhone1_ComboBox.Items.Count > 0 Then
            ContactPhone1_ComboBox.SelectedIndex = 0
        Else
            ContactPhone1_ComboBox.SelectedIndex = -1
        End If
        ContactPhone2_ComboBox.SelectedIndex = -1
        ' Initialize Invoice Date, AppointDate, and WorkDates as today's date
        InvDate_Textbox.Text = formatDate(DateTime.Now)
        ApptDate_Textbox.Text = formatDate(DateTime.Now)
        WorkDate_Textbox.Text = formatDate(DateTime.Now)

        ' RESET CALCULATED VALUES AND INITIALIZE ALL CALCULATION BASED DATAEDITING CONTROLS
        resetCalculatedValues()
        InitializeCalculatedOnAdd() ' Initializes controls of all calculated values to ZERO

        InvRow = -1
        InvId = -1

        valuesInitialized = True


        ' Establish initial values. Doing this here, as unless changes are about to be made, we don't need to set initial values
        InitialInvValues.SetInitialValues(getAllNestedControlsWithTag("dataEditingControl", Me))

        ' First, disable editButton, addButton, enable cancelButton, and disable nav
        CustomerComboBox.Enabled = False
        VehicleComboBox.Enabled = False
        InvoiceComboBox.Enabled = False
        modifyInvButton.Enabled = False
        previewInvButton.Enabled = False
        newInvButton.Enabled = False
        cancelButton.Enabled = True
        nav.DisableAll()

        ' Disable Task and Payment Buttons
        tasksButton.Enabled = False
        paymentsButton.Enabled = False

        ' Disable all licensePlate searching controls
        For Each ctrl In getAllNestedControlsWithTag("licensePlateSearchControl", Me)
            ctrl.Enabled = False
        Next

        ' Get lastSelected
        If getDataTableRowEquals(InvDbController.DbDataTable, "INID", InvoiceComboBox.Text) <> -1 Then
            lastSelected = InvoiceComboBox.Text
        Else
            lastSelected = "Select One"
        End If

        InvoiceComboBox.SelectedIndex = 0

        ' Hide/Show the dataViewingControls and dataEditingControls, respectively
        showHide(getAllNestedControlsWithTag("dataViewingControl", Me), 0)
        showHide(getAllNestedControlsWithTag("dataEditingControl", Me), 1)
        showHide(getAllNestedControlsWithTag("dataLabel", Me), 1)

        ' Select first editing control
        ContactName_Textbox.Focus()

    End Sub


    Private Sub deleteInvButton_Click(sender As Object, e As EventArgs) Handles deleteInvButton.Click

        Dim decision As DialogResult = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        Select Case decision
            Case DialogResult.Yes

                ' 1.) Delete value from database
                If Not deleteInvoice() Then
                    MessageBox.Show("Delete unsuccessful; Changes not saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show("Successfully deleted invoice")
                End If

                ' 2.) RELOAD DATATABLES FROM DATABASE
                If Not loadInvoiceDataTable() Then
                    MessageBox.Show("Loading updated information failed; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                ' 3.) REINITIALIZE CONTROLS (Based on the selected index)
                InitializeInvoiceNumComboBox()
                InvoiceComboBox.SelectedIndex = 0

                ' 4.) RESTORE USER CONTROLS TO NON-EDITING/SELECTING STATE
                CustomerComboBox.Enabled = True
                VehicleComboBox.Enabled = True
                InvoiceComboBox.Enabled = True
                newInvButton.Enabled = True
                cancelButton.Enabled = False
                saveButton.Enabled = False
                previewInvButton.Enabled = False
                nav.EnableAll()

                ' Re-Enable Task and Payment Buttons
                tasksButton.Enabled = True
                paymentsButton.Enabled = True

                ' Re-Enable all licensePlate searching controls
                For Each ctrl In getAllNestedControlsWithTag("licensePlateSearchControl", Me)
                    ctrl.Enabled = True
                Next

            Case DialogResult.No

        End Select

    End Sub


    Private Sub modifyInvButton_Click(sender As Object, e As EventArgs) Handles modifyInvButton.Click

        mode = "editing"

        ' Initialize values for dataEditingControls
        valuesInitialized = False
        InitializeAllDataEditingControls()
        valuesInitialized = True
        ' Establish initial values. Doing this here, as unless changes are about to be made, we don't need to set initial values
        InitialInvValues.SetInitialValues(getAllNestedControlsWithTag("dataEditingControl", Me))

        ' Store the last selected item in the ComboBox (in case update fails and it must revert)
        lastSelected = InvoiceComboBox.Text

        ' Disable editButton, disable addButton, enable cancel button, disable navigation, and disable main selection combobox
        modifyInvButton.Enabled = False
        newInvButton.Enabled = False
        previewInvButton.Enabled = False
        cancelButton.Enabled = True
        nav.DisableAll()
        CustomerComboBox.Enabled = False
        VehicleComboBox.Enabled = False
        InvoiceComboBox.Enabled = False

        ' Disable Task and Payment Buttons
        tasksButton.Enabled = False
        paymentsButton.Enabled = False

        ' Disable all licensePlate searching controls
        For Each ctrl In getAllNestedControlsWithTag("licensePlateSearchControl", Me)
            ctrl.Enabled = False
        Next

        ' Hide/Show the dataViewingControls and dataEditingControls, respectively
        showHide(getAllNestedControlsWithTag("dataViewingControl", Me), 0)
        showHide(getAllNestedControlsWithTag("dataEditingControl", Me), 1)

        ' Select first editing control
        ContactName_Textbox.Focus()

    End Sub


    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click

        ' Check for changes before cancelling. Don't need function here that calls all, as only working with one datatable's values
        If InitialInvValues.CtrlValuesChanged() Then

            Dim decision As DialogResult = MessageBox.Show("Cancel without saving changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            ' If changes have been made, and the user selected that they don't want to cancel, then exit here.
            If decision = DialogResult.No Then Exit Sub

        End If

        ' Otherwise, continue cancelling
        If mode = "editing" Then

            ' RESTORE USER CONTROLS TO NON-EDITING STATE
            CustomerComboBox.Enabled = True
            VehicleComboBox.Enabled = True
            InvoiceComboBox.Enabled = True
            modifyInvButton.Enabled = True
            previewInvButton.Enabled = True
            newInvButton.Enabled = True
            cancelButton.Enabled = False
            saveButton.Enabled = False
            nav.EnableAll()

            ' Re-Enable Task and Payment Buttons
            tasksButton.Enabled = True
            paymentsButton.Enabled = True

            ' Re-Enable all licensePlate searching controls
            For Each ctrl In getAllNestedControlsWithTag("licensePlateSearchControl", Me)
                ctrl.Enabled = True
            Next

            ' Show/Hide the dataViewingControls and dataEditingControls, respectively
            showHide(getAllNestedControlsWithTag("dataViewingControl", Me), 1)
            showHide(getAllNestedControlsWithTag("dataEditingControl", Me), 0)

        ElseIf mode = "adding" Then

            ' 1.) SET VehicleComboBox BACKK TO LAST SELECTED ITEM/INDEX
            InvoiceComboBox.SelectedIndex = InvoiceComboBox.Items.IndexOf(lastSelected)

            ' 2.) IF LAST SELECTED WAS "SELECT ONE", Then simulate functionality from combobox text/selectedIndex changed
            If lastSelected = "Select One" Then
                InvoiceNumComboBox_SelectedIndexChanged(InvoiceComboBox, New EventArgs())
            End If

            ' 3.) RESTORE USER CONTROLS TO NON-ADDING STATE (only those that are controlled by "adding")
            CustomerComboBox.Enabled = True
            VehicleComboBox.Enabled = True
            InvoiceComboBox.Enabled = True
            newInvButton.Enabled = True
            previewInvButton.Enabled = True
            cancelButton.Enabled = False
            saveButton.Enabled = False
            nav.EnableAll()

            ' Re-Enable Task and Payment Buttons
            tasksButton.Enabled = True
            paymentsButton.Enabled = True

            ' Re-Enable all licensePlate searching controls
            For Each ctrl In getAllNestedControlsWithTag("licensePlateSearchControl", Me)
                ctrl.Enabled = True
            Next

        End If

    End Sub


    Private Sub saveButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click

        Dim decision As DialogResult = MessageBox.Show("Save Changes?", "Confirm Changes", MessageBoxButtons.YesNo)

        Select Case decision
            Case DialogResult.Yes

                If mode = "editing" Then

                    ' 1.) VALIDATE DATAEDITING CONTROLS
                    If Not controlsValid() Then Exit Sub

                    ' 2.) UPDATE MASTER TASK LIST VALUES
                    If Not updateInvoice() Then
                        MessageBox.Show("Update unsuccessful; Changes not saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    Else
                        MessageBox.Show("Successfully updated invoice")
                    End If

                    ' 3.) RELOAD DATATABLE FROM DATABASE
                    If Not loadInvoiceDataTable() Then
                        MessageBox.Show("Loading updated information failed; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    ' 4.) REINITIALIZE CONTROLS FROM THIS POINT (still from selection index, however)
                    InitializeInvoiceNumComboBox()

                    ' Look up new ComboBox value corresponding to the new value in the datatable and set the selected index of the re-initialized ComboBox accordingly
                    ' If update failed, then revert selected back to lastSelected
                    Dim updatedItem As String = getRowValueWithKeyEquals(InvDbController.DbDataTable, "INID", "InvNbr", InvId)
                    If updatedItem <> Nothing Then
                        InvoiceComboBox.SelectedIndex = InvoiceComboBox.Items.IndexOf(updatedItem)
                    Else
                        InvoiceComboBox.SelectedIndex = InvoiceComboBox.Items.IndexOf(lastSelected)
                    End If

                    ' 5.) MOVE UI OUT OF EDITING MODE
                    newInvButton.Enabled = True
                    cancelButton.Enabled = False
                    saveButton.Enabled = False
                    previewInvButton.Enabled = True
                    nav.EnableAll()
                    CustomerComboBox.Enabled = True
                    VehicleComboBox.Enabled = True
                    InvoiceComboBox.Enabled = True

                    ' Re-Enable Task and Payment Buttons
                    tasksButton.Enabled = True
                    paymentsButton.Enabled = True

                    ' Re-Enable all licensePlate searching controls
                    For Each ctrl In getAllNestedControlsWithTag("licensePlateSearchControl", Me)
                        ctrl.Enabled = True
                    Next


                ElseIf mode = "adding" Then

                    ' 1.) VALIDATE DATAEDITING CONTROLS
                    If Not controlsValid() Then Exit Sub

                    ' 2.) INSERT NEW ROW INTO MASTER TASK LIST
                    ' We use update vehicle here, as we're not inserting a new vehicle, but we may be updating vehicle values when inserting a new invoice
                    If Not insertInvoice() Or Not updateVehicle() Then
                        MessageBox.Show("Insert unsuccessful; Changes not saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    Else
                        MessageBox.Show("Successfully added new invoice")
                    End If

                    ' 3.) RELOAD DATATABLES FROM DATABASE
                    If Not loadInvoiceDataTable() Or Not loadVehicleDataTable() Then
                        MessageBox.Show("Loading updated information failed; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    ' 4.) REINITIALIZE CONTROLS (based on index of newly inserted value)
                    InitializeInvoiceNumComboBox()

                    ' Changing index of main combobox will also initialize respective dataViewing control values

                    ' First, lookup most recent CustomerId added to the table
                    CRUD.ExecQuery("SELECT InvNbr FROM InvHdr WHERE InvNbr=(SELECT max(InvNbr) FROM InvHdr)")
                    Dim newInvNbr As Long

                    If CRUD.DbDataTable.Rows.Count <> 0 And Not CRUD.HasException(True) Then

                        ' Get new InvNbr if query successful
                        newInvNbr = CRUD.DbDataTable.Rows(0)("InvNbr")
                        ' Get new ComboBox item from datatable using newly retrieved ID
                        Dim newItem As String = getRowValueWithKeyEquals(InvDbController.DbDataTable, "INID", "InvNbr", newInvNbr)

                        ' Set ComboBox accordingly after one final check
                        If newItem <> Nothing Then
                            InvoiceComboBox.SelectedIndex = InvoiceComboBox.Items.IndexOf(newItem)
                        Else
                            InvoiceComboBox.SelectedIndex = InvoiceComboBox.Items.IndexOf(lastSelected)
                        End If

                    Else
                        InvoiceComboBox.SelectedIndex = lastSelected
                    End If

                    ' 5.) MOVE UI OUT OF Adding MODE
                    newInvButton.Enabled = True
                    cancelButton.Enabled = False
                    saveButton.Enabled = False
                    previewInvButton.Enabled = True
                    nav.EnableAll()
                    CustomerComboBox.Enabled = True
                    VehicleComboBox.Enabled = True
                    InvoiceComboBox.Enabled = True

                    ' Re-Enable Task and Payment Buttons
                    tasksButton.Enabled = True
                    paymentsButton.Enabled = True

                    ' Re-Enable all licensePlate searching controls
                    For Each ctrl In getAllNestedControlsWithTag("licensePlateSearchControl", Me)
                        ctrl.Enabled = True
                    Next

                End If

            Case DialogResult.No
                ' Continue making changes or cancel editing
        End Select

    End Sub


    Private Sub previewInvButton_Click(sender As Object, e As EventArgs) Handles previewInvButton.Click

        Dim AcccessInstance As New Microsoft.Office.Interop.Access.Application()
        Dim filepath As String = readINI("AutoServiceManagerParams.ini", "PRIMARY-DATABASE-FILEPATH=")

        Try

            AcccessInstance.Visible = False
            AcccessInstance.OpenCurrentDatabase(filepath)
            AcccessInstance.DoCmd.OpenReport(ReportName:="Invoice", Microsoft.Office.Interop.Access.AcView.acViewPreview, , WhereCondition:="InvNbr=" & CStr(InvId))

        Catch ex As Exception

            MessageBox.Show("Viewing print preview unsuccessful. Ensure Database has not been moved and retry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End Try

    End Sub


    Private Sub vehicleHistoryButton_Click(sender As Object, e As EventArgs) Handles vehicleHistoryButton.Click

        Dim AcccessInstance As New Microsoft.Office.Interop.Access.Application()
        Dim filepath As String = readINI("AutoServiceManagerParams.ini", "PRIMARY-DATABASE-FILEPATH=")

        Try

            AcccessInstance.Visible = False
            AcccessInstance.OpenCurrentDatabase(filepath)
            AcccessInstance.DoCmd.OpenReport(ReportName:="CustomerHistory", Microsoft.Office.Interop.Access.AcView.acViewPreview, , WhereCondition:="CustomerID=" & CStr(CustomerId) & " and VehicleId=" & CStr(VehicleId))

        Catch ex As Exception

            MessageBox.Show("Viewing print preview unsuccessful. Ensure Database has not been moved and retry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End Try

    End Sub





    Private Sub ShopSupplies_CheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles ShopSupplies_CheckBox.CheckedChanged

        If Not valuesInitialized Then Exit Sub

        ' Initialize ShopCharges Textbox no matter what. It will determine whether or include or not based on CheckStatus
        '   (might have to set DataTable value here if reading the CheckState doesn't work)
        InitializeShopChargesTextbox()

        If InitialInvValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private Sub ShopCharges_Textbox_KeyDown(sender As Object, e As KeyEventArgs) Handles ShopCharges_Textbox.KeyDown

        ' Check to see ctrl+A, ctrl+C, or ctrl+V were used. If so, don't worry about checking which Keys Pressed
        If ((e.KeyCode = Keys.A And e.Control) Or (e.KeyCode = Keys.C And e.Control) Or (e.KeyCode = Keys.V And e.Control)) Then
            allowedKeystroke = True
        End If

    End Sub

    Private Sub ShopCharges_Textbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ShopCharges_Textbox.KeyPress

        ' If certain keystroke exceptions allowed through, then skip input validation here
        If allowedKeystroke Then
            allowedKeystroke = False
            Exit Sub
        End If

        If Not currencyInputValid(ShopCharges_Textbox, e.KeyChar) Then
            e.KeyChar = Chr(0)
            e.Handled = True
        End If

    End Sub

    Private Sub ShopCharges_Textbox_TextChanged(sender As Object, e As EventArgs) Handles ShopCharges_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        ShopCharges_Textbox.ForeColor = DefaultForeColor

        ' Handles pasting in invalid values/strings
        Dim lastValidIndex As Integer = allValidChars(ShopCharges_Textbox.Text, "1234567890.")
        If lastValidIndex <> -1 Then
            ShopCharges_Textbox.Text = ShopCharges_Textbox.Text.Substring(0, lastValidIndex)
            ShopCharges_Textbox.SelectionStart = lastValidIndex
        End If

        InitializeSubTotalTextbox()

        If InitialInvValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private Sub SubTotalTextbox_TextChanged(sender As Object, e As EventArgs) Handles SubTotalTextbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        InitializeTaxTextbox()

        If InitialInvValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private Sub TaxExempt_CheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles TaxExempt_CheckBox.CheckedChanged

        If Not valuesInitialized Then Exit Sub

        InitializeTaxTextbox()

        If InitialInvValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private Sub Tax_Textbox_TextChanged(sender As Object, e As EventArgs) Handles Tax_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        InitializeTotalTextbox()

        If InitialInvValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private Sub Gas_Textbox_KeyDown(sender As Object, e As KeyEventArgs) Handles Gas_Textbox.KeyDown

        ' Check to see ctrl+A, ctrl+C, or ctrl+V were used. If so, don't worry about checking which Keys Pressed
        If ((e.KeyCode = Keys.A And e.Control) Or (e.KeyCode = Keys.C And e.Control) Or (e.KeyCode = Keys.V And e.Control)) Then
            allowedKeystroke = True
        End If

    End Sub

    Private Sub Gas_Textbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Gas_Textbox.KeyPress

        ' If certain keystroke exceptions allowed through, then skip input validation here
        If allowedKeystroke Then
            allowedKeystroke = False
            Exit Sub
        End If

        If Not currencyInputValid(Gas_Textbox, e.KeyChar) Then
            e.KeyChar = Chr(0)
            e.Handled = True
        End If

    End Sub

    Private Sub Gas_Textbox_TextChanged(sender As Object, e As EventArgs) Handles Gas_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        Gas_Textbox.ForeColor = DefaultForeColor

        ' Handles pasting in invalid values/strings
        Dim lastValidIndex As Integer = allValidChars(Gas_Textbox.Text, "1234567890.")
        If lastValidIndex <> -1 Then
            Gas_Textbox.Text = Gas_Textbox.Text.Substring(0, lastValidIndex)
            Gas_Textbox.SelectionStart = lastValidIndex
        End If

        InitializeTotalTextbox()

        If InitialInvValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private Sub Towing_Textbox_KeyDown(sender As Object, e As KeyEventArgs) Handles Towing_Textbox.KeyDown

        ' Check to see ctrl+A, ctrl+C, or ctrl+V were used. If so, don't worry about checking which Keys Pressed
        If ((e.KeyCode = Keys.A And e.Control) Or (e.KeyCode = Keys.C And e.Control) Or (e.KeyCode = Keys.V And e.Control)) Then
            allowedKeystroke = True
        End If

    End Sub

    Private Sub Towing_Textbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Towing_Textbox.KeyPress

        ' If certain keystroke exceptions allowed through, then skip input validation here
        If allowedKeystroke Then
            allowedKeystroke = False
            Exit Sub
        End If

        If Not currencyInputValid(Towing_Textbox, e.KeyChar) Then
            e.KeyChar = Chr(0)
            e.Handled = True
        End If

    End Sub

    Private Sub Towing_Textbox_TextChanged(sender As Object, e As EventArgs) Handles Towing_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        Towing_Textbox.ForeColor = DefaultForeColor

        ' Handles pasting in invalid values/strings
        Dim lastValidIndex As Integer = allValidChars(Towing_Textbox.Text, "1234567890.")
        If lastValidIndex <> -1 Then
            Towing_Textbox.Text = Towing_Textbox.Text.Substring(0, lastValidIndex)
            Towing_Textbox.SelectionStart = lastValidIndex
        End If

        InitializeTotalTextbox()

        If InitialInvValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private Sub InvTotal_Textbox_TextChanged(sender As Object, e As EventArgs) Handles InvTotal_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        InitializeBalanceTextbox()

        If InitialInvValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private Sub BalanceTextbox_TextChanged(sender As Object, e As EventArgs) Handles BalanceTextbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        If InitialInvValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub






    Private Sub InvDate_Textbox_TextChanged(sender As Object, e As EventArgs) Handles InvDate_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        InvDate_Textbox.ForeColor = DefaultForeColor

        If InitialInvValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private Sub Complete_CheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles Complete_CheckBox.CheckedChanged

        If Not valuesInitialized Then Exit Sub

        Complete_CheckBox.ForeColor = DefaultForeColor

        If InitialInvValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private Sub ContactName_Textbox_TextChanged(sender As Object, e As EventArgs) Handles ContactName_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        ContactName_Textbox.ForeColor = DefaultForeColor

        If InitialInvValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private Sub ContactPhone1_ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ContactPhone1_ComboBox.SelectedIndexChanged, ContactPhone1_ComboBox.TextChanged

        If Not valuesInitialized Then Exit Sub

        If PhonesMatching Then
            ContactPhone1_ComboBox.ForeColor = DefaultForeColor
            ContactPhone2_ComboBox.ForeColor = DefaultForeColor
            PhonesMatching = False
        Else
            ContactPhone1_ComboBox.ForeColor = DefaultForeColor
        End If

        If InitialInvValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private Sub ContactPhone2_ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ContactPhone2_ComboBox.SelectedIndexChanged, ContactPhone2_ComboBox.TextChanged

        If Not valuesInitialized Then Exit Sub

        If PhonesMatching Then
            ContactPhone2_ComboBox.ForeColor = DefaultForeColor
            ContactPhone1_ComboBox.ForeColor = DefaultForeColor
            PhonesMatching = False
        Else
            ContactPhone2_ComboBox.ForeColor = DefaultForeColor
        End If

        If InitialInvValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private Sub InspectionMonth_ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles InspectionMonth_ComboBox.SelectedIndexChanged, InspectionMonth_ComboBox.TextChanged

        If Not valuesInitialized Then Exit Sub

        If InitialInvValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private Sub InspectionSticker_Textbox_TextChanged(sender As Object, e As EventArgs) Handles InspectionSticker_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        InspectionSticker_Textbox.ForeColor = DefaultForeColor

        If InitialInvValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private Sub Mileage_Textbox_KeyDown(sender As Object, e As KeyEventArgs) Handles Mileage_Textbox.KeyDown

        ' Allow certain keystrokes through here. Oftentimes, these will be common shortcuts
        If ((e.KeyCode = Keys.A And e.Control) Or (e.KeyCode = Keys.C And e.Control) Or (e.KeyCode = Keys.V And e.Control)) Then
            allowedKeystroke = True
        End If

    End Sub

    Private Sub Mileage_Textbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Mileage_Textbox.KeyPress

        ' If certain keystroke exceptions allowed throuhg, then skip input validation here
        If allowedKeystroke Then
            allowedKeystroke = False
            Exit Sub
        End If

        If Not numericInputValid(Mileage_Textbox, e.KeyChar, True) Then
            e.KeyChar = Chr(0)
            e.Handled = True
        End If

    End Sub


    Private Sub Mileage_Textbox_TextChanged(sender As Object, e As EventArgs) Handles Mileage_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        Mileage_Textbox.ForeColor = DefaultForeColor

        ' Handles pasting in invalid values/strings
        Dim lastValidIndex As Integer = allValidChars(Mileage_Textbox.Text, "1234567890")
        If lastValidIndex <> -1 Then
            Mileage_Textbox.Text = Mileage_Textbox.Text.Substring(0, lastValidIndex)
            Mileage_Textbox.SelectionStart = lastValidIndex
        End If

        If InitialInvValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private Sub ApptDate_Textbox_TextChanged(sender As Object, e As EventArgs) Handles ApptDate_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        ApptDate_Textbox.ForeColor = DefaultForeColor

        If InitialInvValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private Sub WorkDate_Textbox_TextChanged(sender As Object, e As EventArgs) Handles WorkDate_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        WorkDate_Textbox.ForeColor = DefaultForeColor

        If InitialInvValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private Sub Notes_Textbox_TextChanged(sender As Object, e As EventArgs) Handles Notes_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        Notes_Textbox.ForeColor = DefaultForeColor

        If InitialInvValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub



    Private Sub invoices_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        ' First, check if editing/adding, and if editing/adding, check if control values changed
        If InvNbr_Textbox.Visible And InitialInvValues.CtrlValuesChanged() Then

            Dim decision As DialogResult = MessageBox.Show("Exit without saving changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If decision = DialogResult.No Then
                e.Cancel = True
                Exit Sub
            End If

        End If

        ' Otherwise, just let the form close

        'If e.CloseReason = CloseReason.UserClosing Then

    End Sub



    Private Sub tasksButton_Click(sender As Object, e As EventArgs) Handles tasksButton.Click

        previousScreen = Me
        changeScreenHide(invoiceTasks, previousScreen)

    End Sub

    Private Sub paymentsButton_Click(sender As Object, e As EventArgs) Handles paymentsButton.Click

        previousScreen = Me
        changeScreenHide(invoicePayments, previousScreen)

    End Sub




    Private Sub LicenseStateComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LicenseStateComboBox.SelectedIndexChanged

        LicenseStateComboBox.ForeColor = DefaultForeColor

    End Sub

    Private Sub LicensePlateTextbox_TextChanged(sender As Object, e As EventArgs) Handles LicensePlateTextbox.TextChanged

        LicensePlateTextbox.ForeColor = DefaultForeColor

    End Sub


End Class