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
    Private InvTotalSum As Decimal = 0
    Private InvPaymentsSum As Decimal = 0

    ' Keeps track of whether or not user in "editing" or "adding" mode
    Private mode As String

    ' Variable that allows certain keystrokes through restricted fields
    Private allowedKeystroke As Boolean = False




    ' ***************** INITIALIZATION AND CONFIGURATION SUBS *****************


    ' Sub that loads Customer DataTable
    Private Function loadCustomerDataTable() As Boolean

        CustomerDbController.ExecQuery("SELECT IIF(ISNULL(c.LastName), '', c.LastName) + ', ' + IIF(ISNULL(c.FirstName), '', c.FirstName) + ' @ ' + IIF(ISNULL(c.Address), '', c.Address) as CLFA, c.CustomerId, c.LastName, c.HomePhone, c.WorkPhone, c.CellPhone1, c.CellPhone2, c.TaxExempt " &
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


    ' Sub that initializes all dataViewingControls corresponding to values in Vehicle DataTable (TaxExempt)
    Private Sub InitializeCustomerDataViewingControls()

        'initializeControlsFromRow(CustomerDbController.DbDataTable, CustomerRow, "dataViewingControl", "_", Me)

        ' We are only initializing TaxExempt from Customer DataTable, so do this here manually to set value to textual alternative
        Dim TaxExemptStatus As Boolean = CustomerDbController.DbDataTable(CustomerRow)("TaxExempt")
        Select Case TaxExemptStatus
            Case True
                TaxExempt_Value.Text = "Tax Exempt"
            Case False
                TaxExempt_Value.Text = "Not Tax Exempt"
        End Select

    End Sub
    ' Sub that initializes all dataEditingControls corresponding to values in Vehicle DataTable (TaxExempt)
    Private Sub InitializeCustomerDataEditingControls()

        'initializeControlsFromRow(CustomerDbController.DbDataTable, CustomerRow, "dataEditingControl", "_", Me)
        ' We are only initializing TaxExempt from Customer DataTable, so do this here manually to set value to textual alternative
        Dim TaxExemptStatus As Boolean = CustomerDbController.DbDataTable(CustomerRow)("TaxExempt")
        Select Case TaxExemptStatus
            Case True
                TaxExempt_Textbox.Text = "Tax Exempt"
            Case False
                TaxExempt_Textbox.Text = "Not Tax Exempt"
        End Select

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
        VehicleDbController.ExecQuery("SELECT CSTR(IIF(ISNULL(v.makeYear), 0, v.makeYear)) + ' ' + IIF(ISNULL(v.Make), '', v.Make) + ' ' + IIF(ISNULL(v.Model), '', v.Model) + '  -  ' + IIF(ISNULL(v.LicensePlate), '', v.LicensePlate) as YMML, " &
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


    ' Sub that initializes all dataViewingControls corresponding to values in Vehicle DataTable (inspection month, inspection sticker number)
    Private Sub InitializeVehicleDataViewingControls()

        initializeControlsFromRow(VehicleDbController.DbDataTable, VehicleRow, "dataViewingControl", "_", Me)

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
                                  "i.Gas, i.ShopCharges, i.Tax, i.InvTotal, i.TotalPaid, i.PayDate, i.ShopSupplies " &
                                  "FROM InvHdr i " &
                                  "WHERE i.VehicleId=@vehicleId " &
                                  "ORDER BY i.InvNbr ASC")

        If InvDbController.HasException() Then Return False

        Return True

    End Function

    ' Sub that initializes invoiceNumComboBox after valid Vehicle selection has been made
    Private Sub InitializeInvoiceNumComboBox()

        InvoiceNumComboBox.BeginUpdate()
        InvoiceNumComboBox.Items.Clear()
        InvoiceNumComboBox.Items.Add("Select One")
        For Each row In InvDbController.DbDataTable.Rows
            InvoiceNumComboBox.Items.Add(row("INID").ToString())
        Next
        InvoiceNumComboBox.EndUpdate()

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
        InvPaymentsDbController.ExecQuery("SELECT ip.PayAmount " &
                                        "FROM InvPayments ip " &
                                        "WHERE ip.InvNbr=@invId")
        If InvPaymentsDbController.HasException() Then Return False

        Return True

    End Function


    ' Sub that initializes and calculates Invoice Labor Cost based on the total cost of all of the labor codes in InvLabor with current InvId
    Private Sub InitializeInvLaborValue()

        For Each row In InvLaborDbController.DbDataTable.Rows
            InvLaborSum += row("LaborAmount")
        Next

        TotalLabor_Value.Text = InvLaborSum

    End Sub

    Private Sub InitializeInvLaborTextbox()

        For Each row In InvLaborDbController.DbDataTable.Rows
            InvLaborSum += row("LaborAmount")
        Next

        TotalLabor_Textbox.Text = String.Format("{0:0.00}", InvLaborSum)

    End Sub

    ' Sub that initializes and calculates Invoice Parts Cost based on the total cost of all of the Parts in InvParts with current InvId
    Private Sub InitializeInvPartsValue()

        For Each row In InvPartsDbController.DbDataTable.Rows
            InvPartsSum += row("PartAmount")
        Next

        TotalParts_Value.Text = InvPartsSum

    End Sub

    Private Sub InitializeInvPartsTextbox()

        For Each row In InvPartsDbController.DbDataTable.Rows
            InvPartsSum += row("PartAmount")
        Next

        TotalParts_Textbox.Text = String.Format("{0:0.00}", InvPartsSum)

    End Sub


    ' Sub that initializes and calculates Shop Charges based TotalLabor, TotalParts IF Shop Supplies checked
    Private Sub InitializeShopChargesValue()

        Dim shopSupplies As Boolean = InvDbController.DbDataTable(InvRow)("ShopSupplies")

        If shopSupplies Then
            Dim shopSupplyCharge As Decimal = CMDbController.DbDataTable.Rows(CMRow)("ShopSupplyCharge")
            Dim laborPartsTotal As Decimal = InvLaborSum + InvPartsSum
            ShopCharges = Math.Round((shopSupplyCharge * laborPartsTotal), 2)
        Else
            ShopCharges = 0
        End If

        ShopCharges_Value.Text = ShopCharges

    End Sub

    Private Sub InitializeShopChargesTextbox()

        Dim shopSupplies As Boolean = ShopSupplies_CheckBox.Checked

        If shopSupplies Then
            Dim shopSupplyCharge As Decimal = CMDbController.DbDataTable.Rows(CMRow)("ShopSupplyCharge")
            Dim laborPartsTotal As Decimal = InvLaborSum + InvPartsSum
            ShopCharges = Math.Round((shopSupplyCharge * laborPartsTotal), 2)
        Else
            ShopCharges = 0
        End If

        ShopCharges_Textbox.Text = String.Format("{0:0.00}", ShopCharges)

    End Sub


    ' Sub that initializes and calculates SubTotal TotalLabor and TotalParts
    Private Sub InitializeSubTotalValue()

        SubTotal = InvLaborSum + InvPartsSum + ShopCharges
        SubTotalValue.Text = SubTotal

    End Sub

    Private Sub InitializeSubTotalTextbox()

        If validCurrency("Shop Charges", True, ShopCharges_Textbox.Text, String.Empty) Then
            SubTotal = InvLaborSum + InvPartsSum + Convert.ToDecimal(ShopCharges_Textbox.Text)
            SubTotalTextbox.Text = String.Format("{0:0.00}", SubTotal)
        Else
            SubTotalTextbox.Text = String.Empty
        End If


    End Sub


    ' Sub that initializes and calculates Tax from SubTotal and TaxRate
    Private Sub InitializeTaxValue()

        ' Check if tax exempt first
        Dim TaxExempt As Boolean = CustomerDbController.DbDataTable(CustomerRow)("TaxExempt")

        If Not TaxExempt Then
            Dim TaxRate As Decimal = CMDbController.DbDataTable(CMRow)("TaxRate")
            Tax = Math.Round(TaxRate * SubTotal, 2)
        Else
            Tax = 0
        End If

        Tax_Value.Text = Tax

    End Sub

    Private Sub InitializeTaxTextbox()

        ' Check if tax exempt first
        Dim TaxExempt As Boolean = CustomerDbController.DbDataTable(CustomerRow)("TaxExempt")

        If validCurrency("SubTotal", True, SubTotalTextbox.Text, String.Empty) Then

            If Not TaxExempt Then
                Dim TaxRate As Decimal = CMDbController.DbDataTable(CMRow)("TaxRate")
                Tax = Math.Round(TaxRate * Convert.ToDecimal(SubTotalTextbox.Text), 2)
            Else
                Tax = 0
            End If

            Tax_Textbox.Text = String.Format("{0:0.00}", Tax)

        Else
            Tax_Textbox.Text = String.Empty
        End If


    End Sub


    ' Sub that initializes and calculates InvTotal from SubTotal and Tax
    Private Sub InitializeTotalValue()

        ' No need for currency validation here, as the values for Gas and Towing should/will always be valid from the DataTable
        Dim GasCost As Decimal = InvDbController.DbDataTable(InvRow)("Gas")
        Dim TowingCost As Decimal = InvDbController.DbDataTable(InvRow)("Towing")

        InvTotalSum = SubTotal + Tax + GasCost + TowingCost
        InvTotal_Value.Text = InvTotalSum

    End Sub

    Private Sub InitializeTotalTextbox()

        ' Add validation checking for Gas and Towing Cost Inputs
        If validCurrency("Gas", True, Gas_Textbox.Text, String.Empty) And
            validCurrency("Towing", True, Towing_Textbox.Text, String.Empty) And
            validCurrency("Tax", True, Tax_Textbox.Text, String.Empty) And
            validCurrency("SubTotal", True, SubTotalTextbox.Text, String.Empty) Then

            Dim GasCost As Decimal = Convert.ToDecimal(Gas_Textbox.Text)
            Dim TowingCost As Decimal = Convert.ToDecimal(Towing_Textbox.Text)
            Dim SubTotalFromTextbox As Decimal = Convert.ToDecimal(SubTotalTextbox.Text)
            Dim TaxFromTextbox As Decimal = Convert.ToDecimal(Tax)

            InvTotalSum = SubTotalFromTextbox + TaxFromTextbox + GasCost + TowingCost
            InvTotal_Textbox.Text = String.Format("{0:0.00}", InvTotalSum)

        Else
            InvTotal_Textbox.Text = String.Empty
        End If

    End Sub


    ' Sub that intializes and calculates Invoice Total Paid amount based on the total of all of the payments in InvPayments with current InvId
    Private Sub InitializeInvPaymentsValue()

        For Each row In InvPaymentsDbController.DbDataTable.Rows
            InvPaymentsSum += row("PayAmount")
        Next

        TotalPaid_Value.Text = InvPaymentsSum

    End Sub

    Private Sub InitializeInvPaymentsTextbox()

        For Each row In InvPaymentsDbController.DbDataTable.Rows
            InvPaymentsSum += row("PayAmount")
        Next

        TotalPaid_Textbox.Text = String.Format("{0:0.00}", InvPaymentsSum)

    End Sub


    ' Sub that initializes Balance based on Total Paid (Total of Payments made) and the total
    Private Sub InitializeBalanceValue()

        Dim balance As Decimal = InvTotalSum - InvPaymentsSum
        BalanceValue.Text = balance

    End Sub

    Private Sub InitializeBalanceTextbox()

        Dim balance As Decimal

        ' Will need to validate Total as a currency
        If validCurrency("InvTotal", True, InvTotal_Textbox.Text, String.Empty) And
            validCurrency("Total Paid", True, TotalPaid_Textbox.Text, String.Empty) Then

            Dim TotalFromTextbox As Decimal = Convert.ToDecimal(InvTotal_Textbox.Text)
            Dim PaymentsSumFromTextbox As Decimal = Convert.ToDecimal(TotalPaid_Textbox.Text)

            balance = TotalFromTextbox - PaymentsSumFromTextbox
            BalanceTextbox.Text = String.Format("{0:0.00}", balance)

        Else
            BalanceTextbox.Text = String.Empty
        End If

    End Sub


    ' Sub that initializes Number of Tasks
    Private Sub InitializeNumberTasksValue()

        Dim NbrTasks As Integer = InvTaskDbController.DbDataTable.Rows.Count
        NbrTasks_Value.Text = NbrTasks

    End Sub

    Private Sub InitializeNumberTasksTextbox()

        Dim NbrTasks As Integer = InvTaskDbController.DbDataTable.Rows.Count
        NbrTasks_Textbox.Text = NbrTasks

    End Sub

    ' Calculation based initialization subs here for:
    '   (DONE) Shop Charges        Make sure to call this whenever Shop Supplies CheckBox checked
    '   (DONE) SubTotal
    '   (DONE) Tax
    '   (DONE) Total
    '   (DONE) Number of Tasks




    ' Sub that calls all individual dataViewingControl initialization subs in one (These can be used individually if desired)
    Private Sub InitializeAllDataViewingControls()

        ' Reset calculated values
        InvLaborSum = 0
        InvPartsSum = 0
        ShopCharges = 0
        SubTotal = 0
        Tax = 0
        InvTotalSum = 0
        InvPaymentsSum = 0

        ' Automated initializations
        InitializeInvoiceDataViewingControls()
        InitializeVehicleDataViewingControls()
        correctInspectionMonthValue()    ' Correction for value initialized from Vehicle DataTable
        InitializeCustomerDataViewingControls()
        ' Then, re-initialize and format any calculation based values
        InitializeInvLaborValue()
        InitializeInvPartsValue()
        InitializeShopChargesValue()
        InitializeSubTotalValue()
        InitializeTaxValue()
        InitializeTotalValue()
        ' Additional Values that require initialization
        InitializeInvPaymentsValue()
        InitializeBalanceValue()
        InitializeNumberTasksValue()

        ' Then, format dataViewingControls
        formatDataViewingControls()

    End Sub

    ' Sub that calls all individual dataEditingControl initialization subs in one (These can be used individually if desired)
    Private Sub InitializeAllDataEditingControls()

        ' Reset calculated values
        InvLaborSum = 0
        InvPartsSum = 0
        ShopCharges = 0
        SubTotal = 0
        Tax = 0
        InvTotalSum = 0
        InvPaymentsSum = 0

        ' Automated initializations
        InitializeInvoiceDataEditingControls()
        InitializeVehicleDataEditingControls()
        correctInspectionMonthComboBox()    ' Correction for value initialized from Vehicle DataTable
        InitializeCustomerDataEditingControls()
        ' Then, re-initialize and format any calculation based values
        InitializeInvLaborTextbox()
        InitializeInvPartsTextbox()
        InitializeShopChargesTextbox()
        InitializeSubTotalTextbox()
        InitializeTaxTextbox()
        ' Additional Values that require initialization
        InitializeInvPaymentsTextbox()
        InitializeNumberTasksTextbox()
        'InitializeContactPhone1ComboBox()
        'InitializeContactPhone2ComboBox()
        ' Then, format dataEditingControls
        formatDataEditingControls()
        ' This must be initialized after all currency based cost values are initialized and formatted properly
        InitializeTotalTextbox()
        InitializeBalanceTextbox()

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

        ' Initial formatting for currency values that may be modified
        Gas_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(Gas_Textbox.Text))
        Towing_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(Towing_Textbox.Text))

    End Sub




    ' ***************** CRUD SUBS *****************
    ' Remember to calculate and add non-taxable as a field to insert/update in the DataBase (Sum of towing, gas, and ONLY subtotal if Tax-Exempt)
    ' Add Taxable as a field as well (this is the SubTotal)

    ' Update InspectionNbr and Inspection month for vehicle to Vehicle Table
    ' IF we decide they can change this here (For whatever justification that may be), then update TaxExempt in Customer Table as well




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




    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
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
            loadVehicleDataTable()
            InitializeVehicleComboBox()
            VehicleComboBox.Visible = True
            VehicleLabel.Visible = True
            VehicleComboBox.SelectedIndex = 0

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
            If InvoiceNumComboBox.Text <> String.Empty And InvoiceNumComboBox.Items.Count <> 0 Then
                InvoiceNumComboBox.Items.Clear()
                InvoiceNumComboBox.Text = String.Empty
            End If
            InvoiceNumComboBox.Visible = False
            invoiceNumLabel.Visible = False

            InvoiceNumComboBox.SelectedIndex = -1
            InvoiceNumComboBox_SelectedIndexChanged(InvoiceNumComboBox, New EventArgs())

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
            loadInvoiceDataTable()
            InitializeInvoiceNumComboBox()
            InvoiceNumComboBox.Visible = True
            invoiceNumLabel.Visible = True
            InvoiceNumComboBox.SelectedIndex = 0

            ' Now that valid vehicle selected, user may add new invoice associated with that vehicle
            newInvButton.Enabled = True
            ' User may now also view vehicle history of the selected vehicle
            vehicleHistoryButton.Visible = True

            'If it does = -1, that means that value Is either "Select one" Or some other anomoly
        Else

            ' If not already, clear and empty the invoiceNumComboBox
            If InvoiceNumComboBox.Text <> String.Empty And InvoiceNumComboBox.Items.Count <> 0 Then
                InvoiceNumComboBox.Items.Clear()
                InvoiceNumComboBox.Text = String.Empty
            End If
            InvoiceNumComboBox.Visible = False
            invoiceNumLabel.Visible = False

            InvoiceNumComboBox.SelectedIndex = -1
            InvoiceNumComboBox_SelectedIndexChanged(InvoiceNumComboBox, New EventArgs())

            ' Disable user from creating new invoice until valid vehicle selected
            newInvButton.Enabled = False
            ' User may not view vehicle history when no valid vehicle selected
            vehicleHistoryButton.Visible = False

        End If

    End Sub


    Private Sub InvoiceNumComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles InvoiceNumComboBox.SelectedIndexChanged, InvoiceNumComboBox.TextChanged

        ' Ensure that invoiceNumComboBox is only attempting to initialize values when on proper selected Index
        If InvoiceNumComboBox.SelectedIndex = -1 Then

            ' Have all labels and corresponding values hidden
            showHide(getAllNestedControlsWithTag("dataViewingControl", Me), 0)
            showHide(getAllNestedControlsWithTag("dataLabel", Me), 0)
            showHide(getAllNestedControlsWithTag("dataEditingControl", Me), 0)
            ' Disable editing button
            modifyInvButton.Enabled = False
            deleteInvButton.Enabled = False

            Exit Sub

        End If

        ' Lookup newly selected row and see if it is valid (valid if it corresponds with a datatable row)
        InvRow = getDataTableRowEquals(InvDbController.DbDataTable, "INID", InvoiceNumComboBox.Text)

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

            ' Recalculate and Reinitialize dependent controls
            InitializeAllDataViewingControls()

            valuesInitialized = True

            ' Show labels and corresponding values
            showHide(getAllNestedControlsWithTag("dataViewingControl", Me), 1)
            showHide(getAllNestedControlsWithTag("dataLabel", Me), 1)
            showHide(getAllNestedControlsWithTag("dataEditingControl", Me), 0)

            ' Enable editing and deleting button
            modifyInvButton.Enabled = True
            deleteInvButton.Enabled = True

            'If it does = -1, that means that value Is either "Select one" Or some other anomoly
        Else

            ' Have all labels and corresponding values hidden
            showHide(getAllNestedControlsWithTag("dataViewingControl", Me), 0)
            showHide(getAllNestedControlsWithTag("dataLabel", Me), 0)
            showHide(getAllNestedControlsWithTag("dataEditingControl", Me), 0)
            ' Disable editing button
            modifyInvButton.Enabled = False
            deleteInvButton.Enabled = False

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
        InitializeCustomerDataEditingControls()
        ' setup ComboBoxes
        ContactPhone1_ComboBox.SelectedIndex = -1
        ContactPhone2_ComboBox.SelectedIndex = -1
        ' Initialize Invoice Date, AppointDate, and WorkDates as today's date
        InvDate_Textbox.Text = formatDate(DateTime.Now)
        ApptDate_Textbox.Text = formatDate(DateTime.Now)
        WorkDate_Textbox.Text = formatDate(DateTime.Now)
        ' Reset calculated values
        InvLaborSum = 0
        InvPartsSum = 0
        ShopCharges = 0
        SubTotal = 0
        Tax = 0
        InvTotalSum = 0
        InvPaymentsSum = 0

        InvRow = -1
        InvId = -1

        ' Load any dependent DataTables that might be used for initial calculations (should all return 0)
        loadDependentDataTables()
        ' Make Initialization Calls. Should all amount to zero initially.
        InitializeInvLaborTextbox()
        InitializeInvPartsTextbox()
        InitializeShopChargesTextbox()
        InitializeSubTotalTextbox()
        InitializeTaxTextbox()
        InitializeInvPaymentsTextbox()
        InitializeNumberTasksTextbox()
        Gas_Textbox.Text = String.Format("{0:0.00}", 0)
        Towing_Textbox.Text = String.Format("{0:0.00}", 0)
        InitializeTotalTextbox()
        InitializeBalanceTextbox()


        valuesInitialized = True

        ' Establish initial values. Doing this here, as unless changes are about to be made, we don't need to set initial values
        InitialInvValues.SetInitialValues(getAllNestedControlsWithTag("dataEditingControl", Me))

        ' First, disable editButton, addButton, enable cancelButton, and disable nav
        CustomerComboBox.Enabled = False
        VehicleComboBox.Enabled = False
        InvoiceNumComboBox.Enabled = False
        modifyInvButton.Enabled = False
        newInvButton.Enabled = False
        cancelButton.Enabled = True
        nav.DisableAll()

        ' Disable all licensePlate searching controls
        For Each ctrl In getAllNestedControlsWithTag("licensePlateSearchControl", Me)
            ctrl.Enabled = False
        Next

        ' Get lastSelected
        If getDataTableRowEquals(InvDbController.DbDataTable, "INID", InvoiceNumComboBox.Text) <> -1 Then
            lastSelected = InvoiceNumComboBox.Text
        Else
            lastSelected = "Select One"
        End If

        InvoiceNumComboBox.SelectedIndex = 0

        ' Hide/Show the dataViewingControls and dataEditingControls, respectively
        showHide(getAllNestedControlsWithTag("dataViewingControl", Me), 0)
        showHide(getAllNestedControlsWithTag("dataEditingControl", Me), 1)
        showHide(getAllNestedControlsWithTag("dataLabel", Me), 1)

    End Sub


    Private Sub deleteInvButton_Click(sender As Object, e As EventArgs) Handles deleteInvButton.Click

        Dim decision As DialogResult = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        Select Case decision
            Case DialogResult.Yes

                ' 1.) Delete value from database
                'If Not deleteAll() Then
                '    MessageBox.Show("Delete unsuccessful; Changes not saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Else
                '    MessageBox.Show("Successfully deleted " & VehicleComboBox.Text & " from Vehicles")
                'End If

                ' 2.) RELOAD DATATABLES FROM DATABASE
                If Not loadInvoiceDataTable() Then
                    MessageBox.Show("Loading updated information failed; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                ' 3.) REINITIALIZE CONTROLS (Based on the selected index)
                InitializeInvoiceNumComboBox()
                InvoiceNumComboBox.SelectedIndex = 0

                ' 4.) RESTORE USER CONTROLS TO NON-EDITING/SELECTING STATE
                CustomerComboBox.Enabled = True
                VehicleComboBox.Enabled = True
                InvoiceNumComboBox.Enabled = True
                newInvButton.Enabled = True
                cancelButton.Enabled = False
                saveButton.Enabled = False
                nav.EnableAll()

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
        lastSelected = InvoiceNumComboBox.Text

        ' Disable editButton, disable addButton, enable cancel button, disable navigation, and disable main selection combobox
        modifyInvButton.Enabled = False
        newInvButton.Enabled = False
        cancelButton.Enabled = True
        nav.DisableAll()
        CustomerComboBox.Enabled = False
        VehicleComboBox.Enabled = False
        InvoiceNumComboBox.Enabled = False

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
            InvoiceNumComboBox.Enabled = True
            modifyInvButton.Enabled = True
            newInvButton.Enabled = True
            cancelButton.Enabled = False
            saveButton.Enabled = False
            nav.EnableAll()

            ' Re-Enable all licensePlate searching controls
            For Each ctrl In getAllNestedControlsWithTag("licensePlateSearchControl", Me)
                ctrl.Enabled = True
            Next

            ' Show/Hide the dataViewingControls and dataEditingControls, respectively
            showHide(getAllNestedControlsWithTag("dataViewingControl", Me), 1)
            showHide(getAllNestedControlsWithTag("dataEditingControl", Me), 0)

        ElseIf mode = "adding" Then

            ' 1.) SET VehicleComboBox BACKK TO LAST SELECTED ITEM/INDEX
            InvoiceNumComboBox.SelectedIndex = InvoiceNumComboBox.Items.IndexOf(lastSelected)

            ' 2.) IF LAST SELECTED WAS "SELECT ONE", Then simulate functionality from combobox text/selectedIndex changed
            If lastSelected = "Select One" Then
                InvoiceNumComboBox_SelectedIndexChanged(InvoiceNumComboBox, New EventArgs())
            End If

            ' 3.) RESTORE USER CONTROLS TO NON-ADDING STATE (only those that are controlled by "adding")
            CustomerComboBox.Enabled = True
            VehicleComboBox.Enabled = True
            InvoiceNumComboBox.Enabled = True
            newInvButton.Enabled = True
            cancelButton.Enabled = False
            saveButton.Enabled = False
            nav.EnableAll()

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
                    'If Not updateMasterTask() Then
                    '    MessageBox.Show("Update unsuccessful; Changes not saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '    Exit Sub
                    'Else
                    '    MessageBox.Show("Successfully updated Master Task List")
                    'End If

                    ' 3.) RELOAD DATATABLES FROM DATABASE
                    If Not loadInvoiceDataTable() Then 'And Not loadVehicleDataTable And Not loadCustomerDataTable
                        MessageBox.Show("Loading updated information failed; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                    ' Going to also have to reload vehicleDataTable
                    ' ALso going to have to reload CustomerDataTable (if TaxExempt Editable)

                    ' 4.) REINITIALIZE CONTROLS FROM THIS POINT (still from selection index, however)
                    InitializeInvoiceNumComboBox()

                    ' Look up new ComboBox value corresponding to the new value in the datatable and set the selected index of the re-initialized ComboBox accordingly
                    ' If update failed, then revert selected back to lastSelected
                    Dim updatedItem As String = getRowValueWithKeyEquals(InvDbController.DbDataTable, "INID", "InvNbr", InvId)
                    If updatedItem <> Nothing Then
                        InvoiceNumComboBox.SelectedIndex = InvoiceNumComboBox.Items.IndexOf(updatedItem)
                    Else
                        InvoiceNumComboBox.SelectedIndex = InvoiceNumComboBox.Items.IndexOf(lastSelected)
                    End If

                    ' 5.) MOVE UI OUT OF EDITING MODE
                    newInvButton.Enabled = True
                    cancelButton.Enabled = False
                    saveButton.Enabled = False
                    nav.EnableAll()
                    CustomerComboBox.Enabled = True
                    VehicleComboBox.Enabled = True
                    InvoiceNumComboBox.Enabled = True

                    ' Re-Enable Task and Payment Buttons
                    tasksButton.Enabled = True
                    paymentsButton.Enabled = True


                ElseIf mode = "adding" Then

                    ' 1.) VALIDATE DATAEDITING CONTROLS
                    If Not controlsValid() Then Exit Sub

                    ' 2.) INSERT NEW ROW INTO MASTER TASK LIST
                    'If Not insertMasterTask() Then
                    '    MessageBox.Show("Insert unsuccessful; Changes not saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '    Exit Sub
                    'Else
                    '    MessageBox.Show("Successfully added " & TaskDescription_Textbox.Text & " to Master Task List")
                    'End If

                    ' 3.) RELOAD DATATABLES FROM DATABASE
                    If Not loadInvoiceDataTable() Then  'And Not loadVehicleDataTable And Not loadCustomerDataTable
                        MessageBox.Show("Loading updated information failed; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    ' 4.) REINITIALIZE CONTROLS (based on index of newly inserted value)
                    InitializeInvoiceNumComboBox()

                    ' Changing index of main combobox will also initialize respective dataViewing control values

                    ' First, lookup most recent CustomerId added to the table
                    CRUD.ExecQuery("SELECT InvNbr FROM InvHdr WHERE InvNbr=(SELECT max(InvNbr) FROM InvHdr)")
                    Dim newInvNbr As Long

                    If CRUD.DbDataTable.Rows.Count <> 0 And Not CRUD.HasException(True) Then

                        ' Get new TaskId if query successful
                        newInvNbr = CRUD.DbDataTable.Rows(0)("InvNbr")
                        ' Get new ComboBox item from datatable using newly retrieved ID
                        Dim newItem As String = getRowValueWithKeyEquals(InvDbController.DbDataTable, "INID", "InvNbr", newInvNbr)

                        ' Set ComboBox accordingly after one final check
                        If newItem <> Nothing Then
                            InvoiceNumComboBox.SelectedIndex = InvoiceNumComboBox.Items.IndexOf(newItem)
                        Else
                            InvoiceNumComboBox.SelectedIndex = InvoiceNumComboBox.Items.IndexOf(lastSelected)
                        End If

                    Else
                        InvoiceNumComboBox.SelectedIndex = lastSelected
                    End If

                    ' 5.) MOVE UI OUT OF Adding MODE
                    newInvButton.Enabled = True
                    cancelButton.Enabled = False
                    saveButton.Enabled = False
                    nav.EnableAll()
                    CustomerComboBox.Enabled = True
                    VehicleComboBox.Enabled = True
                    InvoiceNumComboBox.Enabled = True

                    ' Re-Enable Task and Payment Buttons
                    tasksButton.Enabled = True
                    paymentsButton.Enabled = True

                End If

            Case DialogResult.No
                ' Continue making changes or cancel editing
        End Select

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


    Private Sub TaxExempt_CheckBox_CheckedChanged(sender As Object, e As EventArgs)

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


End Class