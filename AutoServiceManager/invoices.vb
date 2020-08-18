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
    Private InvPaymentsDbController As New DbControl()
    Private CMDbController As New DbControl()
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

    ' Variables that store calculated values for InvoiceLabor, InvoiceParts, and InvoiceTotal Values/Textboxes
    Private InvLaborSum As Decimal
    Private InvPartsSum As Decimal
    Private InvTotalSum As Decimal

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

    End Sub

    Private Sub InitializeInvLaborTextbox()

    End Sub



    ' Sub that calls all individual dataViewingControl initialization subs in one (These can be used individually if desired)
    Private Sub InitializeAllDataViewingControls()

        ' Automated initializations
        InitializeInvoiceDataViewingControls()
        InitializeVehicleDataViewingControls()
        InitializeCustomerDataViewingControls()
        ' Then, format dataViewingControls
        'formatDataViewingControls()

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

    End Sub

    Private Sub invoices_Load(sender As Object, e As EventArgs) Handles MyBase.Load



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