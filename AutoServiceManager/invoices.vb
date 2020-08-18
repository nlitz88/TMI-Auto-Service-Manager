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
    Private InvId As Integer                    ' InvNbr from same row that ""

    Private CMRow As Integer = 0

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

    ' Sub that initializes all dataViewingControls corresponding to values in Vehicle DataTable (TaxExempt)
    Private Sub InitializeCustomerDataViewingControls()

        initializeControlsFromRow(CustomerDbController.DbDataTable, CustomerRow, "dataViewingControl", "_", Me)

    End Sub
    ' Sub that initializes all dataEditingControls corresponding to values in Vehicle DataTable (TaxExempt)
    Private Sub InitializeCustomerDataEditingControls()

        initializeControlsFromRow(CustomerDbController.DbDataTable, CustomerRow, "dataEditingControl", "_", Me)

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
        InvDbController.ExecQuery("SELECT i.InvNbr, i.CustomerId, i.VehicleId, i.Mileage, i.InvDate, i.Complete, i.NbrTasks, i.WorkDate, i.ApptDate, i.ContactName, i.ContactPhone1, i.ContactPhone2, i.Notes, i.TotalLabor, i.TotalParts, i.Towing, " &
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
            InvoiceNumComboBox.Items.Add(row("InvNbr"))
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

        'TotalLabor_Textbox.Text = String.Format("{0:0.00}", InvLaborSum)

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

        'TotalParts_Textbox.Text = String.Format("{0:0.00}", InvPartsSum)

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

        Dim shopSupplies As Boolean = InvDbController.DbDataTable(InvRow)("ShopSupplies")

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
            SubTotal = InvLaborSum + InvPartsSum + ShopCharges
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
                Tax = Math.Round(TaxRate * SubTotal, 2)
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
        If validCurrency("Gas", True, Gas_Textbox.Text, String.Empty) &
            validCurrency("Towing", True, Towing_Textbox.Text, String.Empty) &
            validCurrency("Tax", True, Tax_Textbox.Text, String.Empty) &
            validCurrency("SubTotal", True, SubTotalTextbox.Text, String.Empty) Then

            Dim GasCost As Decimal = Gas_Textbox.Text
            Dim TowingCost As Decimal = Towing_Textbox.Text

            InvTotalSum = SubTotal + Tax + GasCost + TowingCost
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

        InitializeInvPaymentsValue()
        InitializeNumberTasksValue()

        ' Then, format dataViewingControls
        formatDataViewingControls()

    End Sub

    ' Sub that calls all individual dataEditingControl initialization subs in one (These can be used individually if desired)
    Private Sub InitializeAllDataEditingControls()

        ' Automated initializations
        InitializeInvoiceDataEditingControls()
        InitializeVehicleDataEditingControls()
        InitializeCustomerDataEditingControls()
        ' Then, format dataEditingControls
        'formatDataEditingControls()
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

        ' These three calculation based fields are formatted here after the fact, as otherwise, TotalTask can't parse the decimal values from TaskLabor and TaskParts
        TotalLabor_Value.Text = FormatCurrency(TotalLabor_Value.Text)
        TotalParts_Value.Text = FormatCurrency(TotalParts_Value.Text)

        ShopCharges_Value.Text = FormatCurrency(ShopCharges_Value.Text)
        SubTotalValue.Text = FormatCurrency(SubTotalValue.Text)
        Tax_Value.Text = FormatCurrency(Tax_Value.Text)
        Gas_Value.Text = FormatCurrency(Gas_Value.Text)
        Towing_Value.Text = FormatCurrency(Towing_Value.Text)
        InvTotal_Value.Text = FormatCurrency(InvTotal_Value.Text)

        TotalPaid_Value.Text = FormatCurrency(TotalPaid_Value.Text)

    End Sub

    ' Sub that will add formatting to already initialized dataEditingControls





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

        ' Contact Phone 1
        ' Contact Phone 2

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


        ' This logic checks to see if the value in InvoiceNumComboBox is numeric. If so, then convert it to an int
        ' If not, invNbr will remain as -1, subsequently producing a -1 on lookup from getDataTableRowEquals()
        Dim invNbr As Integer = -1
        If allValidChars(InvoiceNumComboBox.Text, "0123456789") = -1 Then
            Try
                invNbr = Convert.ToInt32(InvoiceNumComboBox.Text)
            Catch ex As Exception

            End Try
        End If


        ' Lookup newly selected row and see if it is valid (valid if it corresponds with a datatable row)
        InvRow = getDataTableRowEquals(InvDbController.DbDataTable, "InvNbr", invNbr)

        ' If this query DOES return a valid row index, then initialize respective controls
        If InvRow <> -1 Then

            'InvId = InvDbController.DbDataTable.Rows(InvRow)("InvId")
            InvId = InvoiceNumComboBox.Text

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





End Class