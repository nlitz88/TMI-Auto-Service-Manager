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


    ' Sub that loads States DataTable
    Private Function loadStatesDataTable() As Boolean

        ' Loads datatable from States
        StateDbController.ExecQuery("SELECT s.State FROM States s ORDER BY s.State ASC")
        If StateDbController.HasException() Then Return False

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


    ' Loads datatable from Vehicle database table based on CustomerId
    Private Function loadVehicleDataTable() As Boolean

        VehicleDbController.AddParams("@customerId", CustomerId)
        VehicleDbController.ExecQuery("SELECT CSTR(IIF(ISNULL(v.makeYear), 0, v.makeYear)) + ' ' + IIF(ISNULL(v.Make), '', v.Make) + ' ' + IIF(ISNULL(v.Model), '', v.Model) + '  -  ' + IIF(ISNULL(v.LicensePlate), '', v.LicensePlate) as YMML, " &
                                      "v.VehicleId, v.InspectionStickerNbr, v.InspectionMonth " &
                                      "FROM Vehicle v " &
                                      "WHERE v.CustomerId=@customerId " &
                                      "ORDER BY v.makeYear ASC")

        If VehicleDbController.HasException() Then Return False

        Return True

    End Function

    ' Sub that initializes CarModelComboBox after valid AutoMakeComboBox selection has been made
    Private Sub InitializeVehicleComboBox()

        VehicleComboBox.BeginUpdate()
        VehicleComboBox.Items.Clear()
        VehicleComboBox.Items.Add("Select One")
        For Each row In VehicleDbController.DbDataTable.Rows
            VehicleComboBox.Items.Add(row("YMML"))
        Next
        VehicleComboBox.EndUpdate()

    End Sub




    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        loadCustomerDataTable()
        InitializeCustomerComboBox()
        CustomerComboBox.SelectedIndex = 0
        loadStatesDataTable()
        InitializeStateComboBox()
        LicenseStateComboBox.SelectedIndex = LicenseStateComboBox.Items.IndexOf("PA")   ' Most cars will have PA licenses

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

        Console.WriteLine("Vehicle ComboBox selected index changed!")

        ' Ensure that VehicleComboBox is only enabling user to select invoiceNum if valid index selected
        If VehicleComboBox.SelectedIndex = -1 Then

            ' If not already, clear and empty the invoiceNumComboBox
            If invoiceNumComboBox.Text <> String.Empty And invoiceNumComboBox.Items.Count <> 0 Then
                invoiceNumComboBox.Items.Clear()
                invoiceNumComboBox.Text = String.Empty
            End If
            invoiceNumComboBox.Visible = False
            invoiceNumLabel.Visible = False

            invoiceNumComboBox.SelectedIndex = -1

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
            'loadVehicleDataTable()
            'InitializeVehicleComboBox()
            invoiceNumComboBox.Visible = True
            invoiceNumLabel.Visible = True
            'invoiceNumComboBox.SelectedIndex = 0

            ' Now that valid vehicle selected, user may add new invoice associated with that vehicle
            newInvButton.Enabled = True

            'If it does = -1, that means that value Is either "Select one" Or some other anomoly
        Else

            ' If not already, clear and empty the invoiceNumComboBox
            If invoiceNumComboBox.Text <> String.Empty And invoiceNumComboBox.Items.Count <> 0 Then
                invoiceNumComboBox.Items.Clear()
                invoiceNumComboBox.Text = String.Empty
            End If
            invoiceNumComboBox.Visible = False
            invoiceNumLabel.Visible = False

            invoiceNumComboBox.SelectedIndex = -1

            ' Disable user from creating new invoice until valid vehicle selected
            newInvButton.Enabled = False

        End If

    End Sub





End Class