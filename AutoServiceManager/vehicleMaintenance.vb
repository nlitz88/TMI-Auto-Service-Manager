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

    ' Initialize new lists to store certain row values of datatables (easily sorted and BINARY SEARCHED FOR SPEED)

    ' Initialize instance(s) of initialValues class
    Private InitialVehicleValues As New InitialValues()

    'Variable to keep track of whether form fully loaded or not
    Private valuesInitialized As Boolean = True

    ' Row index variables used for DataTable lookups
    Private CustomerRow As Integer
    Private CustomerId As Integer
    Private lastSelectedCustomer As String  ' Unecessary
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
        CustomerDbController.ExecQuery("SELECT c.LastName + ', ' + IIF(ISNULL(c.FirstName), '', c.FirstName) as CLF, c.CustomerId, c.LastName " &
                                       "FROM Customer c " &
                                       "WHERE Trim(LastName) <> '' " &
                                       "ORDER BY c.LastName ASC")
        If CustomerDbController.HasException() Then Return False

        ' Loads datatable from AutoManufacturers
        MakeDbController.ExecQuery("SELECT am.AutoMake FROM AutoManufacturers am ORDER BY am.AutoMake ASC")
        If MakeDbController.HasException() Then Return False

        Return True

    End Function


    ' Sub that initializes Customer ComboBox
    Private Sub InitializeCustomerComboBox()

        valuesInitialized = False

        CustomerComboBox.BeginUpdate()
        CustomerComboBox.DisplayMember = "CLF"
        CustomerComboBox.ValueMember = "CustomerId"
        CustomerComboBox.DataSource = CustomerDbController.DbDataTable
        CustomerComboBox.EndUpdate()

        valuesInitialized = True

    End Sub

    ' Sub that initializes MakeComboBox
    Private Sub InitializeMakeComboBox()

        valuesInitialized = False

        Make_ComboBox.BeginUpdate()
        Make_ComboBox.DisplayMember = "Make"
        Make_ComboBox.ValueMember = "Make"
        Make_ComboBox.DataSource = MakeDbController.DbDataTable
        Make_ComboBox.EndUpdate()

        valuesInitialized = True

    End Sub

    ' Sub that initializes ModelComboBox
    Private Sub InitializeModelComboBox()

        valuesInitialized = False

        Model_ComboBox.BeginUpdate()
        Model_ComboBox.DisplayMember = "Model"
        Model_ComboBox.ValueMember = "Model"
        Model_ComboBox.DataSource = ModelDbController.DbDataTable
        Model_ComboBox.EndUpdate()

        valuesInitialized = True

    End Sub

    ' Sub that initializes ColorComboBox
    Private Sub InitializeColorComboBox()

        valuesInitialized = False

        Color_ComboBox.BeginUpdate()
        Color_ComboBox.DisplayMember = "Color"
        Color_ComboBox.ValueMember = "Color"
        Color_ComboBox.DataSource = ColorDbController.DbDataTable
        Color_ComboBox.EndUpdate()

        valuesInitialized = True

    End Sub

    ' Sub that initializes StateComboBox
    Private Sub InitializeStateComboBox()

        valuesInitialized = False

        LicenseState_ComboBox.BeginUpdate()
        LicenseState_ComboBox.DisplayMember = "LicenseState"
        LicenseState_ComboBox.ValueMember = "LicenseState"
        LicenseState_ComboBox.DataSource = StateDbController.DbDataTable
        LicenseState_ComboBox.EndUpdate()

        valuesInitialized = True

    End Sub

    ' Sub that initializes MonthComboBox
    Private Sub InitializeMonthComboBox()

        valuesInitialized = False

        InspectionMonth_ComboBox.BeginUpdate()
        InspectionMonth_ComboBox.DisplayMember = "InspectionMonth"
        InspectionMonth_ComboBox.ValueMember = "InspectionMonth"
        InspectionMonth_ComboBox.DataSource = MonthDbController.DbDataTable
        InspectionMonth_ComboBox.EndUpdate()

        valuesInitialized = True

    End Sub

    ' Sub that initializes InsuranceComboBox
    Private Sub InitializeInsuranceComboBox()

        valuesInitialized = False

        InsuranceCompany_ComboBox.BeginUpdate()
        InsuranceCompany_ComboBox.DisplayMember = "InsuranceCompany"
        InsuranceCompany_ComboBox.ValueMember = "InsuranceCompany"
        InsuranceCompany_ComboBox.DataSource = InsuranceCompanyDbController.DbDataTable
        InsuranceCompany_ComboBox.EndUpdate()

        valuesInitialized = True

    End Sub

    ' Sub that calls all Initialization Subs for preloaded comboboxes
    Private Sub InitializeAllPreliminaryComboBoxes()

        InitializeCustomerComboBox()

        InitializeMakeComboBox()
        InitializeModelComboBox()
        InitializeColorComboBox()
        InitializeStateComboBox()
        InitializeMonthComboBox()
        InitializeInsuranceComboBox()

    End Sub


    ' Loads datatable from CarModels database table
    Private Function loadVehicleDataTable() As Boolean

        VehicleDbController.AddParams("@customerId", CustomerId)
        VehicleDbController.ExecQuery("SELECT STR(IIF(ISNULL(v.makeYear), 0, v.makeYear)) + ' ' + v.Make + ' ' + v.Model as YMM, " &
                                      "v.CustomerId, v.VehicleId, IIF(ISNULL(v.makeYear), 0, v.makeYear), v.Make, v.Model, v.Color, v.LicenseState, v.LicensePlate, v.VIN, " &
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

        valuesInitialized = False

        'CustomerComboBox.FormattingEnabled = True
        VehicleComboBox.BeginUpdate()
        VehicleComboBox.DisplayMember = "YMM"
        VehicleComboBox.ValueMember = "VehicleId"
        VehicleComboBox.DataSource = VehicleDbController.DbDataTable
        VehicleComboBox.EndUpdate()

        valuesInitialized = True

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

    ' Sub that calls all individual dataEditingControl initialization subs in one (These can be used individually if desired)
    Private Sub InitializeAllDataViewingControls()

        ' Automated initializations
        InitializeVehicleDataViewingControls()
        ' Then, format dataViewingControls
        'formatDataViewingControls()

    End Sub



    Private Sub vehicleMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not checkDbConn() Then Exit Sub

        ' LOAD CUSTOMER DATATABLE
        If Not loadAllPreliminaryDataTables() Then
            MessageBox.Show("Failed to connect to database; Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' INITIALIZE CUSTOMERCOMBOBOX (And All other preliminaries) FOR FIRST TIME
        InitializeAllPreliminaryComboBoxes()
        CustomerComboBox.SelectedIndex = -1

    End Sub




    ' **************** CONTROL SUBS ****************


    ' Used to prevent combobox from changing index on leave/lose focus. Still needs restricted, however, when Enter used
    Dim CustomerComboBoxleave As Boolean = False
    Dim selectedIndex As Integer = -1

    Private Sub CustomerComboBox_Leave(sender As Object, e As EventArgs) Handles CustomerComboBox.Leave
        CustomerComboBoxleave = True
        selectedIndex = CustomerComboBox.SelectedIndex
    End Sub

    Private Sub CustomerComboBox_Enter(sender As Object, e As EventArgs) Handles CustomerComboBox.Enter
        CustomerComboBoxleave = False
    End Sub

    Private Sub CustomerComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CustomerComboBox.SelectedIndexChanged

        If CustomerComboBoxleave Then
            CustomerComboBox.SelectedIndex = selectedIndex
            CustomerComboBoxleave = False
        End If

        ' Ensure that CustomerCombobox is not being initialized and not on invalid selectedIndex
        If Not valuesInitialized Or CustomerComboBox.SelectedIndex = -1 Then

            ' If not already, clear and empty the VehicleComboBox
            If VehicleComboBox.Text <> String.Empty And VehicleComboBox.Items.Count <> 0 Then
                'VehicleComboBox.Items.Clear()
                VehicleComboBox.Text = String.Empty
            End If
            VehicleComboBox.Visible = False
            VehicleLabel.Visible = False
            VehicleComboBox.SelectedIndex = -1

            ' Disable user from adding new vehicle, as no valid Customer has been selected
            addButton.Enabled = False

        End If

        CustomerRow = -1    ' guilty until proven innocent

        Dim escapedText As String = escapeLikeValues(CustomerComboBox.Text)
        Dim rows() As DataRow = CustomerDbController.DbDataTable.Select("CLF LIKE '" & escapedText & "' AND CustomerId = '" & CustomerComboBox.SelectedValue & "'")
        If rows.Count <> 0 Then
            CustomerRow = CustomerDbController.DbDataTable.Rows.IndexOf(rows(0))
        End If

        If CustomerRow <> -1 Then

            ' CustomerRow doesn't mean anything to vehicleComboBox. VehicleComboBox query only concerned about the selectedValue (Customer Id)
            'CustomerId = CustomerComboBox.SelectedValue
            CustomerId = CustomerComboBox.SelectedValue
            loadVehicleDataTable()
            InitializeVehicleComboBox()
            initializeControlsFromRow(VehicleDbController.DbDataTable, 0, "dataViewingControl", "_", Me)

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


End Class