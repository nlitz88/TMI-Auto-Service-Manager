Public Class vehicleMaintenance

    ' New Database control instances for Customers and Vehicles datatables
    Private CustomerDbController As New DbControl()
    Private VehicleDbController As New DbControl()
    ' New Database control instances for all vehicle related dropdowns
    Private MakeDbController As New DbControl()
    Private ModelDbController As New DbControl()
    Private ColorDbController As New DbControl()
    Private StateDbController As New DbControl()
    Private MonthDbController As New DbControl()
    Private InsuranceCompanyDbController As New DbControl()
    ' New Database control instance for updating, inserting, and deleting
    Private CRUD As New DbControl()

    ' Initialize instance(s) of initialValues class
    Private InitialVehicleValues As New InitialValues()

    'Variable to keep track of whether form fully loaded or not
    Private valuesInitialized As Boolean = True

    ' Row index variables used for DataTable lookups
    Private CustomerRow As Integer              ' Used to keep track of which Customer CLFA selected
    Private CustomerId As Integer               ' Maintains corresponding CustomerId to CLFA

    Private VehicleRow As Integer
    Private lastSelectedVehicle As String

    ' Keeps track of whether or not user in "editing" or "adding" mode
    Private mode As String

    ' Variable that allows certain keystrokes through restricted fields
    Private allowedKeystroke As Boolean = False




    ' ***************** INITIALIZATION AND CONFIGURATION SUBS *****************


    ' Function that will load all preliminary datatables
    Private Function loadAllPreliminaryDataTables() As Boolean

        ' Loads datatable from Customer
        CustomerDbController.ExecQuery("SELECT c.LastName + ', ' + IIF(ISNULL(c.FirstName), '', c.FirstName) + ' @ ' + IIF(ISNULL(c.Address), '', c.Address) as CLFA, c.CustomerId, c.LastName " &
                                       "FROM Customer c " &
                                       "WHERE Trim(LastName) <> '' " &
                                       "ORDER BY c.LastName ASC")
        If CustomerDbController.HasException() Then Return False

        ' Loads datatable from AutoManufacturers
        MakeDbController.ExecQuery("SELECT am.AutoMake FROM AutoManufacturers am ORDER BY am.AutoMake ASC")
        If MakeDbController.HasException() Then Return False

        ' Loads datatable from CarModels
        ModelDbController.ExecQuery("SELECT cm.AutoModel FROM CarModels cm ORDER BY cm.AutoModel ASC")
        If ModelDbController.HasException() Then Return False

        ' Loads datatable from Colors
        ColorDbController.ExecQuery("SELECT c.Color FROM Colors c ORDER BY c.Color ASC")
        If ColorDbController.HasException() Then Return False

        ' Loads datatable from States
        StateDbController.ExecQuery("SELECT s.State FROM States s ORDER BY s.State ASC")
        If StateDbController.HasException() Then Return False

        ' Loads datatable from Months
        MonthDbController.ExecQuery("SELECT m.Month FROM Months m ORDER BY m.Month ASC")
        If MonthDbController.HasException() Then Return False

        ' Loads datatable from Insurance
        InsuranceCompanyDbController.ExecQuery("SELECT ic.CompanyName FROM InsuranceCompanies ic ORDER BY ic.CompanyName ASC")
        If InsuranceCompanyDbController.HasException() Then Return False

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

    ' Sub that initializes MakeComboBox
    Private Sub InitializeMakeComboBox()

        Make_ComboBox.Items.Clear()
        Make_ComboBox.BeginUpdate()
        For Each row In MakeDbController.DbDataTable.Rows
            Make_ComboBox.Items.Add(row("AutoMake"))
        Next
        Make_ComboBox.EndUpdate()

    End Sub

    ' Sub that initializes ModelComboBox
    Private Sub InitializeModelComboBox()

        Model_ComboBox.Items.Clear()
        Model_ComboBox.BeginUpdate()
        For Each row In ModelDbController.DbDataTable.Rows
            Model_ComboBox.Items.Add(row("AutoModel"))
        Next
        Model_ComboBox.EndUpdate()

    End Sub

    ' Sub that initializes ColorComboBox
    Private Sub InitializeColorComboBox()

        Color_ComboBox.Items.Clear()
        Color_ComboBox.BeginUpdate()
        For Each row In ColorDbController.DbDataTable.Rows
            Color_ComboBox.Items.Add(row("Color"))
        Next
        Color_ComboBox.EndUpdate()

    End Sub

    ' Sub that initializes StateComboBox
    Private Sub InitializeStateComboBox()

        LicenseState_ComboBox.Items.Clear()
        LicenseState_ComboBox.BeginUpdate()
        For Each row In StateDbController.DbDataTable.Rows
            LicenseState_ComboBox.Items.Add(row("State"))
        Next
        LicenseState_ComboBox.EndUpdate()

    End Sub

    ' Sub that initializes MonthComboBox
    Private Sub InitializeMonthComboBox()

        InspectionMonth_ComboBox.Items.Clear()
        InspectionMonth_ComboBox.BeginUpdate()
        For Each row In MonthDbController.DbDataTable.Rows
            InspectionMonth_ComboBox.Items.Add(row("Month"))
        Next
        InspectionMonth_ComboBox.EndUpdate()

    End Sub

    ' Sub that initializes InsuranceComboBox
    Private Sub InitializeInsuranceComboBox()

        InsuranceCompany_ComboBox.Items.Clear()
        InsuranceCompany_ComboBox.BeginUpdate()
        For Each row In InsuranceCompanyDbController.DbDataTable.Rows
            InsuranceCompany_ComboBox.Items.Add(row("CompanyName"))
        Next
        InsuranceCompany_ComboBox.EndUpdate()

    End Sub

    ' Sub that calls all Initialization Subs for preloaded comboboxes
    Private Sub InitializeAllPreliminaryComboBoxes()

        'InitializeCustomerComboBox() While preloaded, should not be grouped with these, as it serves a different purpose. All of these are vehicle-editing related
        InitializeMakeComboBox()
        InitializeModelComboBox()
        InitializeColorComboBox()
        InitializeStateComboBox()
        InitializeMonthComboBox()
        InitializeInsuranceComboBox()

    End Sub

    ' Sub that sets index of all preliminary/vehicle-editing/adding related comboboxes to -1 on add
    Private Sub SetIndexAllPreliminaryComboBoxes()

        Make_ComboBox.SelectedIndex = -1
        Model_ComboBox.SelectedIndex = -1
        Color_ComboBox.SelectedIndex = -1
        LicenseState_ComboBox.SelectedIndex = -1
        InspectionMonth_ComboBox.SelectedIndex = -1
        InsuranceCompany_ComboBox.SelectedIndex = -1

    End Sub



    ' Loads datatable from CarModels database table
    Private Function loadVehicleDataTable() As Boolean

        VehicleDbController.AddParams("@customerId", CustomerId)
        VehicleDbController.ExecQuery("SELECT CSTR(IIF(ISNULL(v.makeYear), 0, v.makeYear)) + ' ' + v.Make + ' ' + v.Model + '  -  ' + v.LicensePlate as YMML, " &
                                      "v.CustomerId, v.VehicleId, v.makeYear, v.Make, v.Model, v.Color, v.LicenseState, v.LicensePlate, v.VIN, " &
                                      "v.InspectionStickerNbr, v.InspectionMonth, v.InsuranceCompany, v.PolicyNumber, v.ExpirationDate, v.Notes, " &
                                      "v.Engine, v.ABS, v.AC, v.AirBags, v.Alarm " &
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



    ' Sub that initializes all dataEditingcontrols corresponding with values from the Vehicle datatable
    Private Sub InitializeVehicleDataEditingControls()

        initializeControlsFromRow(VehicleDbController.DbDataTable, VehicleRow, "dataEditingControl", "_", Me)

    End Sub

    ' Sub that initializes all dataViewingControls corresponding with values from the Vehicle datatable
    Private Sub InitializeVehicleDataViewingControls()

        initializeControlsFromRow(VehicleDbController.DbDataTable, VehicleRow, "dataViewingControl", "_", Me)

    End Sub



    ' Sub that calls all individual dataEditingControl initialization subs in one (These can be used individually if desired)
    Private Sub InitializeAllDataEditingControls()

        ' Automated initializations
        InitializeVehicleDataEditingControls()
        ' Set forecolor if not already initially default
        setForeColor(getAllControlsWithTag("dataEditingControl", Me), DefaultForeColor)

    End Sub

    ' Sub that calls all individual dataViewingControl initialization subs in one (These can be used individually if desired)
    Private Sub InitializeAllDataViewingControls()

        ' Automated initializations
        InitializeVehicleDataViewingControls()
        ' Then, format dataViewingControls
        'formatDataViewingControls()

    End Sub





    Private Sub vehicleMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' PRE-DRAW PRE-LOADED (Preliminary) COMBOBOXES. 
        ' This way, we don't have to wait for them to draw on first edit/add

        Make_ComboBox.Visible = True
        Make_ComboBox.Visible = False

        Model_ComboBox.Visible = True
        Model_ComboBox.Visible = False

        Color_ComboBox.Visible = True
        Color_ComboBox.Visible = False

        LicenseState_ComboBox.Visible = True
        LicenseState_ComboBox.Visible = False

        InspectionMonth_ComboBox.Visible = True
        InspectionMonth_ComboBox.Visible = False

        InsuranceCompany_ComboBox.Visible = True
        InsuranceCompany_ComboBox.Visible = False

        Make_ComboBox.Visible = True
        Make_ComboBox.Visible = False

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If Not checkDbConn() Then Exit Sub

        ' LOAD CUSTOMER DATATABLE
        If Not loadAllPreliminaryDataTables() Then
            MessageBox.Show("Failed to connect to database; Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' INITIALIZE CUSTOMERCOMBOBOX (And All other preliminaries) FOR FIRST TIME
        InitializeAllPreliminaryComboBoxes()
        InitializeCustomerComboBox()
        CustomerComboBox.SelectedIndex = 0

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

            ' Disable user from adding new vehicle, as no valid Customer has been selected
            addButton.Enabled = False

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

            ' Enable user to Add new model under valid manufacturer
            addButton.Enabled = True

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

            ' Disable user from adding new vehicle, as no valid Customer has been selected
            addButton.Enabled = False

        End If

    End Sub

    Private Sub VehicleComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles VehicleComboBox.SelectedIndexChanged, VehicleComboBox.TextChanged

        ' Ensure that CustomerCombobox is only attempting to initialize values when on proper selected Index
        If VehicleComboBox.SelectedIndex = -1 Then

            ' Have all labels and corresponding values hidden
            showHide(getAllControlsWithTag("dataViewingControl", Me), 0)
            showHide(getAllControlsWithTag("dataLabel", Me), 0)
            showHide(getAllControlsWithTag("dataEditingControl", Me), 0)
            ' Disable editing button
            editButton.Enabled = False
            deleteButton.Enabled = False
            Exit Sub

        End If

        ' Lookup newly selected row and see if it is valid (valid if it corresponds with a datatable row)
        VehicleRow = getDataTableRow(VehicleDbController.DbDataTable, "YMML", VehicleComboBox.Text)

        ' If this query DOES return a valid row index, then initialize respective controls
        If VehicleRow <> -1 Then

            ' Initialize corresponding controls from DataTable values
            valuesInitialized = False
            InitializeAllDataViewingControls()
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


End Class