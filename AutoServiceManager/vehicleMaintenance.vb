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
        InitializeColorComboBox()
        InitializeStateComboBox()
        InitializeMonthComboBox()
        InitializeInsuranceComboBox()

    End Sub

    ' Sub that sets index of all preliminary/vehicle-editing/adding related comboboxes to -1 on add
    Private Sub SetIndexAllPreliminaryComboBoxes()

        Make_ComboBox.SelectedIndex = -1
        'Model_ComboBox.SelectedIndex = -1
        Color_ComboBox.SelectedIndex = -1
        LicenseState_ComboBox.SelectedIndex = -1
        InspectionMonth_ComboBox.SelectedIndex = -1
        InsuranceCompany_ComboBox.SelectedIndex = -1

    End Sub



    ' Loads datatable from CarModels database table based on AutoMake
    Private Function loadCarModelsDataTable() As Boolean

        ' Loads datatable from CarModels
        ModelDbController.AddParams("@automake", "%" & Make_ComboBox.Text & "%")
        ModelDbController.ExecQuery("SELECT cm.AutoModel, cm.AutoMake FROM CarModels cm " &
                                    "WHERE cm.AutoMake LIKE @automake " &
                                    "ORDER BY cm.AutoModel ASC")
        If ModelDbController.HasException() Then Return False

        Return True

    End Function

    ' Sub that initializes ModelComboBox
    Private Sub InitializeModelComboBox()

        Model_ComboBox.Items.Clear()
        Model_ComboBox.BeginUpdate()
        For Each row In ModelDbController.DbDataTable.Rows
            Model_ComboBox.Items.Add(row("AutoModel"))
        Next
        Model_ComboBox.EndUpdate()

    End Sub


    ' Loads datatable from Vehicle database table based on CustomerId
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




    ' ***************** CRUD SUBS *****************


    ' Function that makes updateTable calls for all relevant DataTables that need updated based on changes
    Private Function updateAll() As Boolean

        ' Lookup VehicleId (primary key) based on selected YMML in ComboBox
        Dim vehicleId As Integer = VehicleDbController.DbDataTable.Rows(VehicleRow)("VehicleId")

        ' No need for an exclusion list, as VehicleId (Autogen primary key) is not used in any controls

        ' Using vehicleId as key, update customer row
        updateTable(CRUD, VehicleDbController.DbDataTable, "Vehicle", vehicleId, "VehicleId", "_", "dataEditingControl", Me)
        ' Then, return exception status of CRUD controller. Do this after each call
        If CRUD.HasException() Then Return False

        ' Otherwise, return true
        Return True

    End Function


    ' Function that makes insertRow calls for all relevant DataTables
    Private Function insertAll() As Boolean

        ' No need for an exclusion list, as VehicleId (Autogen primary key) is not used in any controls

        ' Then, make calls to insertRow to all relevant tables
        insertRow(CRUD, VehicleDbController.DbDataTable, "Vehicle", "_", "dataEditingControl", Me)
        ' Then, return exception status of CRUD controller. Do this after each call
        If CRUD.HasException() Then Return False

        ' Otherwise, return true
        Return True

    End Function


    ' Function that makes deleteRow calls for all relevant DataTables
    Private Function deleteAll() As Boolean

        ' Lookup VehicleId (primary key) based on selected YMML in ComboBox
        Dim vehicleId As Integer = VehicleDbController.DbDataTable.Rows(VehicleRow)("VehicleId")
        deleteRow(CRUD, "Vehicle", vehicleId, "VehicleId")
        ' Then, return exception status of CRUD controller. Do this after each call
        If CRUD.HasException() Then Return False

        ' Otherwise, return true
        Return True

    End Function




    ' **************** VALIDATION SUBS ****************


    ' Sub that runs validation for all form controls. Also handles error reporting
    Private Function controlsValid() As Boolean

        Dim errorMessage As String = String.Empty

        ' Use "Required" parameter to control whether or not a Null string value will cause an error to be reported


        ' CHECK IF YMML (Year, Make, Model, and LicensePlateNbr) NOT A DUPLICATE
        If mode = "editing" Then

            ' Get initial values (that make up YMML) to see if there changes are the same as initial
            Dim makeYear As String = VehicleDbController.DbDataTable.Rows(VehicleRow)("makeYear").ToString().ToLower()
            Dim Make As String = VehicleDbController.DbDataTable.Rows(VehicleRow)("Make").ToString().ToLower()
            Dim Model As String = VehicleDbController.DbDataTable.Rows(VehicleRow)("Model").ToString().ToLower()
            Dim LicensePlate As String = VehicleDbController.DbDataTable.Rows(VehicleRow)("LicensePlate").ToString().ToLower()

            ' Only if the current values (that make up the YMML) are not equal to their initial values
            If makeYear_Textbox.Text.ToLower() <> makeYear Or Make_ComboBox.Text.ToLower() <> Make Or Model_ComboBox.Text.ToLower() <> Model Or LicensePlate_Textbox.Text.ToLower() <> LicensePlate Then

                ' Use query to check if row exists with all of these
                Dim duplicateRows() As DataRow = VehicleDbController.DbDataTable.Select("makeYear='" & Long.Parse(makeYear_Textbox.Text) &
                                                                                            "' AND Make LIKE '" & Make_ComboBox.Text &
                                                                                            "' AND Model LIKE '" & Model_ComboBox.Text &
                                                                                            "' AND LicensePlate LIKE '" & LicensePlate_Textbox.Text & "'")

                If duplicateRows.Count <> 0 Then
                    errorMessage += "ERROR: " & makeYear_Textbox.Text & " " & Make_ComboBox.Text & " " & Model_ComboBox.Text & "  -  " & LicensePlate_Textbox.Text & " already exists;" & vbNewLine &
                                "Please modify Year, Make, Model, or License Plate" & vbNewLine
                    makeYear_Textbox.ForeColor = Color.Red
                    Make_ComboBox.ForeColor = Color.Red
                    Model_ComboBox.ForeColor = Color.Red
                    LicensePlate_Textbox.ForeColor = Color.Red
                End If

            End If


        ElseIf mode = "adding" Then

            ' Use query to check if row exists with all of these
            Dim duplicateRows() As DataRow = VehicleDbController.DbDataTable.Select("makeYear='" & Long.Parse(makeYear_Textbox.Text) &
                                                                                            "' AND Make LIKE '" & Make_ComboBox.Text &
                                                                                            "' AND Model LIKE '" & Model_ComboBox.Text &
                                                                                            "' AND LicensePlate LIKE '" & LicensePlate_Textbox.Text & "'")

            If duplicateRows.Count <> 0 Then
                errorMessage += "ERROR: " & makeYear_Textbox.Text & " " & Make_ComboBox.Text & " " & Model_ComboBox.Text & "  -  " & LicensePlate_Textbox.Text & " already exists;" & vbNewLine &
                                "Please modify Year, Make, Model, or License Plate" & vbNewLine
                makeYear_Textbox.ForeColor = Color.Red
                Make_ComboBox.ForeColor = Color.Red
                Model_ComboBox.ForeColor = Color.Red
                LicensePlate_Textbox.ForeColor = Color.Red
            End If

        End If

        ' Manufacturer
        If Not isValidLength("Manufacturer", False, Make_ComboBox.Text, 20, errorMessage) Then
            Make_ComboBox.ForeColor = Color.Red
        ElseIf Make_ComboBox.SelectedIndex = -1 Then
            errorMessage += "ERROR: " & Make_ComboBox.Text & " is not a valid manufacturer" & vbNewLine
            Make_ComboBox.ForeColor = Color.Red
        End If

        ' Model
        If Not isValidLength("Model", False, Model_ComboBox.Text, 20, errorMessage) Then
            Model_ComboBox.ForeColor = Color.Red
        ElseIf Model_ComboBox.SelectedIndex = -1 Then
            errorMessage += "ERROR: " & Model_ComboBox.Text & " is not a valid model" & vbNewLine
            Model_ComboBox.ForeColor = Color.Red
        End If

        ' Year
        If Not isValidLength("Year", False, makeYear_Textbox.Text, 14, errorMessage) Then
            makeYear_Textbox.ForeColor = Color.Red
        End If

        ' Color
        If Not isValidLength("Color", False, Color_ComboBox.Text, 20, errorMessage) Then
            Color_ComboBox.ForeColor = Color.Red
        ElseIf Color_ComboBox.SelectedIndex = -1 And Not String.IsNullOrWhiteSpace(Color_ComboBox.Text) Then
            errorMessage += "ERROR: " & Color_ComboBox.Text & " is not a valid color" & vbNewLine
            Color_ComboBox.ForeColor = Color.Red
        End If

        ' License State
        If Not isValidLength("License State", False, LicenseState_ComboBox.Text, 2, errorMessage) Then
            LicenseState_ComboBox.ForeColor = Color.Red
        ElseIf LicenseState_ComboBox.SelectedIndex = -1 Then
            errorMessage += "ERROR: " & LicenseState_ComboBox.Text & " is not a valid State" & vbNewLine
            LicenseState_ComboBox.ForeColor = Color.Red
        End If

        ' License Plate
        If Not isValidLength("License Plate", False, LicensePlate_Textbox.Text, 10, errorMessage) Then
            LicensePlate_Textbox.ForeColor = Color.Red
        End If

        ' VIN
        If Not isValidLength("VIN", False, VIN_Textbox.Text, 20, errorMessage) Then
            VIN_Textbox.ForeColor = Color.Red
        End If

        ' Inspection Month
        If Not isValidLength("Inspection Month", False, InspectionMonth_ComboBox.Text, 3, errorMessage) Then
            InspectionMonth_ComboBox.ForeColor = Color.Red
        ElseIf InspectionMonth_ComboBox.SelectedIndex = -1 Then
            errorMessage += "ERROR: " & InspectionMonth_ComboBox.Text & " is not a valid Month" & vbNewLine
            InspectionMonth_ComboBox.ForeColor = Color.Red
        End If

        ' Inspection Sticker Number
        If Not isValidLength("Inspection Sticker Number", False, InspectionStickerNbr_Textbox.Text, 15, errorMessage) Then
            InspectionStickerNbr_Textbox.ForeColor = Color.Red
        End If

        ' Insurance Company
        If Not isValidLength("Insurance Company", False, InsuranceCompany_ComboBox.Text, 100, errorMessage) Then
            InsuranceCompany_ComboBox.ForeColor = Color.Red
        ElseIf InsuranceCompany_ComboBox.SelectedIndex = -1 Then
            errorMessage += "ERROR: " & InsuranceCompany_ComboBox.Text & " is not a valid Insurance Company" & vbNewLine
            InsuranceCompany_ComboBox.ForeColor = Color.Red
        End If

        ' Policy Number
        If Not isValidLength("Policy Number", False, PolicyNumber_Textbox.Text, 20, errorMessage) Then
            PolicyNumber_Textbox.ForeColor = Color.Red
        End If

        ' Expiration Date
        If isEmpty("Expiration Date", False, ExpirationDate_Textbox.Text, errorMessage) Then
            ExpirationDate_Textbox.ForeColor = Color.Red
        ElseIf ExpirationDate_Textbox.Text.Length < 9 Then
            errorMessage += "ERROR: " & ExpirationDate_Textbox.Text & " is not a valid Date" & vbNewLine
            ExpirationDate_Textbox.ForeColor = Color.Red
        Else
            Console.WriteLine(ExpirationDate_Textbox.Text.Length)
        End If

        ' Engine
        If Not isValidLength("Engine", False, Engine_Textbox.Text, 20, errorMessage) Then
            Engine_Textbox.ForeColor = Color.Red
        End If

        ' Notes
        If Not isValidLength("Notes", False, Notes_Textbox.Text, 255, errorMessage) Then
            Notes_Textbox.ForeColor = Color.Red
        End If


        ' Check if any invalid input has been found
        If Not String.IsNullOrEmpty(errorMessage) Then

            MessageBox.Show(errorMessage, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False

        End If

        Return True

    End Function





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
            ' load car models based on auto make, then initialize
            loadCarModelsDataTable()
            InitializeModelComboBox()
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


    Private Sub addButton_Click(sender As Object, e As EventArgs) Handles addButton.Click

        mode = "adding"

        ' Initialize values for dataEditingControls
        valuesInitialized = False
        clearControls(getAllControlsWithTag("dataEditingControl", Me))
        ' Set all preliminary/vehicle editing/adding comboboxes index to -1 (no value)
        SetIndexAllPreliminaryComboBoxes()
        valuesInitialized = True
        ' Establish initial values. Doing this here, as unless changes are about to be made, we don't need to set initial values
        InitialVehicleValues.SetInitialValues(getAllControlsWithTag("dataEditingControl", Me))

        ' First, disable editButton, addButton, enable cancelButton, and disable nav
        editButton.Enabled = False
        addButton.Enabled = False
        cancelButton.Enabled = True
        nav.DisableAll()
        CustomerComboBox.Enabled = False

        ' Get lastSelectedVehicle
        If getDataTableRow(VehicleDbController.DbDataTable, "YMML", VehicleComboBox.Text) <> -1 Then
            lastSelectedVehicle = VehicleComboBox.Text
        Else
            lastSelectedVehicle = "Select One"
        End If

        VehicleComboBox.SelectedIndex = 0

        ' Hide/Show the dataViewingControls and dataEditingControls, respectively
        showHide(getAllControlsWithTag("dataViewingControl", Me), 0)
        showHide(getAllControlsWithTag("dataEditingControl", Me), 1)
        showHide(getAllControlsWithTag("dataLabel", Me), 1)

    End Sub


    Private Sub deleteButton_Click(sender As Object, e As EventArgs) Handles deleteButton.Click

        Dim decision As DialogResult = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        Select Case decision
            Case DialogResult.Yes

                ' 1.) Delete value from database
                If Not deleteAll() Then
                    MessageBox.Show("Delete unsuccessful; Changes not saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show("Successfully deleted " & VehicleComboBox.Text & " from Vehicles")
                End If

                ' 2.) RELOAD DATATABLES FROM DATABASE
                If Not loadVehicleDataTable() Then
                    MessageBox.Show("Loading updated information failed; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                ' 3.) REINITIALIZE CONTROLS (Based on the selected index)
                InitializeVehicleComboBox()
                VehicleComboBox.SelectedIndex = 0

                ' 4.) RESTORE USER CONTROLS TO NON-EDITING/SELECTING STATE
                CustomerComboBox.Enabled = True
                VehicleComboBox.Enabled = True
                addButton.Enabled = True
                cancelButton.Enabled = False
                saveButton.Enabled = False
                nav.EnableAll()

            Case DialogResult.No

        End Select

    End Sub


    Private Sub editButton_Click(sender As Object, e As EventArgs) Handles editButton.Click

        mode = "editing"

        ' Initialize values for dataEditingControls
        valuesInitialized = False
        InitializeVehicleDataEditingControls()
        valuesInitialized = True
        ' Establish initial values. Doing this here, as unless changes are about to be made, we don't need to set initial values
        InitialVehicleValues.SetInitialValues(getAllControlsWithTag("dataEditingControl", Me))

        ' Store the last selected item in the ComboBox (in case update fails and it must revert)
        lastSelectedVehicle = VehicleComboBox.Text

        ' Disable editButton, disable addButton, enable cancel button, disable navigation, and disable main selection combobox
        editButton.Enabled = False
        addButton.Enabled = False
        cancelButton.Enabled = True
        nav.DisableAll()
        CustomerComboBox.Enabled = False
        VehicleComboBox.Enabled = False

        ' Hide/Show the dataViewingControls and dataEditingControls, respectively
        showHide(getAllControlsWithTag("dataViewingControl", Me), 0)
        showHide(getAllControlsWithTag("dataEditingControl", Me), 1)

    End Sub


    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click

        ' Check for changes before cancelling. Don't need function here that calls all, as only working with one datatable's values
        If InitialVehicleValues.CtrlValuesChanged() Then

            Dim decision As DialogResult = MessageBox.Show("Cancel without saving changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            ' If changes have been made, and the user selected that they don't want to cancel, then exit here.
            If decision = DialogResult.No Then Exit Sub

        End If

        ' Otherwise, continue cancelling
        If mode = "editing" Then

            ' RESTORE USER CONTROLS TO NON-EDITING STATE
            editButton.Enabled = True
            addButton.Enabled = True
            cancelButton.Enabled = False
            saveButton.Enabled = False
            nav.EnableAll()
            CustomerComboBox.Enabled = True
            VehicleComboBox.Enabled = True

            ' Show/Hide the dataViewingControls and dataEditingControls, respectively
            showHide(getAllControlsWithTag("dataViewingControl", Me), 1)
            showHide(getAllControlsWithTag("dataEditingControl", Me), 0)

        ElseIf mode = "adding" Then

            ' 1.) SET VehicleComboBox BACKK TO LAST SELECTED ITEM/INDEX
            VehicleComboBox.SelectedIndex = VehicleComboBox.Items.IndexOf(lastSelectedVehicle)

            ' 2.) IF LAST SELECTED WAS "SELECT ONE", Then simulate functionality from combobox text/selectedIndex changed
            If lastSelectedVehicle = "Select One" Then
                VehicleComboBox_SelectedIndexChanged(VehicleComboBox, New EventArgs())
            End If

            ' 3.) RESTORE USER CONTROLS TO NON-ADDING STATE (only those that are controlled by "adding")
            CustomerComboBox.Enabled = True
            VehicleComboBox.Enabled = True
            addButton.Enabled = True
            cancelButton.Enabled = False
            saveButton.Enabled = False
            nav.EnableAll()

        End If

    End Sub


    Private Sub saveButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click

        Dim decision As DialogResult = MessageBox.Show("Save Changes?", "Confirm Changes", MessageBoxButtons.YesNo)

        Select Case decision
            Case DialogResult.Yes

                If mode = "editing" Then

                    ' 1.) VALIDATE DATAEDITING CONTROLS
                    If Not controlsValid() Then Exit Sub

                    ' 2.) UPDATE DATATABLE(S), THEN UPDATE DATABASE
                    If Not updateAll() Then
                        MessageBox.Show("Update unsuccessful; Changes not saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    Else
                        MessageBox.Show("Successfully updated Vehicles")
                    End If

                    ' 3.) RELOAD DATATABLES FROM DATABASE
                    If Not loadVehicleDataTable() Then
                        MessageBox.Show("Loading updated information failed; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    ' 4.) REINITIALIZE CONTROLS FROM THIS POINT (still from selection index, however)
                    InitializeVehicleComboBox()

                    ' Look up new ComboBox value corresponding to the new value in the datatable and set the selected index of the re-initialized ComboBox accordingly
                    ' If insertion failed, then revert selected back to lastSelected
                    Dim currentVehicleId As Integer = VehicleDbController.DbDataTable.Rows(VehicleRow)("VehicleId")
                    Dim updatedItem As String = getRowValueWithKeyEquals(VehicleDbController.DbDataTable, "YMML", "VehicleId", currentVehicleId)
                    If updatedItem <> Nothing Then
                        VehicleComboBox.SelectedIndex = VehicleComboBox.Items.IndexOf(updatedItem)
                    Else
                        VehicleComboBox.SelectedIndex = VehicleComboBox.Items.IndexOf(lastSelectedVehicle)
                    End If


                    ' dataViewingControl values reinitialized, as well as dataControls hide/show in combobox text/selectedindex change event

                    ' 5.) MOVE UI OUT OF EDITING MODE
                    addButton.Enabled = True
                    cancelButton.Enabled = False
                    saveButton.Enabled = False
                    nav.EnableAll()
                    CustomerComboBox.Enabled = True
                    VehicleComboBox.Enabled = True

                ElseIf mode = "adding" Then

                    ' 1.) VALIDATE DATAEDITING CONTROLS
                    If Not controlsValid() Then Exit Sub

                    ' 2.) INSERT NEW ROW INTO DATABASE
                    If Not insertAll() Then
                        MessageBox.Show("Insert unsuccessful; Changes not saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    Else
                        MessageBox.Show("Successfully added " & makeYear_Textbox.Text & " " & Make_ComboBox.Text & " " & Model_ComboBox.Text & " to Vehicles")
                    End If

                    ' 3.) RELOAD DATATABLES FROM DATABASE
                    If Not loadVehicleDataTable() Then
                        MessageBox.Show("Loading updated information failed; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    ' 4.) REINITIALIZE CONTROLS (based on index of newly inserted value)
                    InitializeVehicleComboBox()

                    ' Changing index of main combobox will also initialize respective dataViewing control values


                    ' First, lookup most recent VehicleId added to the table
                    CRUD.ExecQuery("SELECT VehicleId FROM Vehicle WHERE VehicleId=(SELECT max(VehicleId) FROM Vehicle)")
                    Dim newVehicleId As Integer

                    If CRUD.DbDataTable.Rows.Count <> 0 And Not CRUD.HasException(True) Then

                        ' Get new VehicleId if query successful
                        newVehicleId = CRUD.DbDataTable.Rows(0)("VehicleId")
                        ' Get new ComboBox item from datatable using newly retrieved ID
                        Dim newItem As String = getRowValueWithKeyEquals(CustomerDbController.DbDataTable, "YMML", "VehicleId", newVehicleId)

                        ' Set ComboBox accordingly after one final check
                        If newItem <> Nothing Then
                            VehicleComboBox.SelectedIndex = VehicleComboBox.Items.IndexOf(newItem)
                        Else
                            VehicleComboBox.SelectedIndex = VehicleComboBox.Items.IndexOf(lastSelectedVehicle)
                        End If

                    Else
                        VehicleComboBox.SelectedIndex = lastSelectedVehicle
                    End If


                    ' 5.) MOVE UI OUT OF Adding MODE
                    addButton.Enabled = True
                    cancelButton.Enabled = False
                    saveButton.Enabled = False
                    nav.EnableAll()
                    CustomerComboBox.Enabled = True
                    VehicleComboBox.Enabled = True

                End If

            Case DialogResult.No
                ' Continue making changes or cancel editing
        End Select

    End Sub


    Private Sub Make_ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Make_ComboBox.SelectedIndexChanged, Make_ComboBox.TextChanged

        If Not valuesInitialized Then Exit Sub

        ' If value selected/typed in exists in the combobox (and inherently, in the manufacturers datatable), then the selectedIndex <> -1.
        ' If does automake does exist, then initialize ModelComboBox respectively
        If Make_ComboBox.SelectedIndex <> -1 Then

            loadCarModelsDataTable()
            InitializeModelComboBox()
            Model_ComboBox.SelectedIndex = -1
            Model_ComboBox.Text = String.Empty

            ' If the selected index is -1, then clear out the model combobox
        Else

            ' If not already, clear and empty the VehicleComboBox
            If Model_ComboBox.Text <> String.Empty And Model_ComboBox.Items.Count <> 0 Then
                Model_ComboBox.Items.Clear()
                Model_ComboBox.Text = String.Empty
            End If
            Model_ComboBox.SelectedIndex = -1

        End If

        If InitialVehicleValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub Model_ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Model_ComboBox.SelectedIndexChanged, Model_ComboBox.TextChanged

        If Not valuesInitialized Then Exit Sub

        If InitialVehicleValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub makeYear_Textbox_TextChanged(sender As Object, e As EventArgs) Handles makeYear_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        If InitialVehicleValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub Color_ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Color_ComboBox.SelectedIndexChanged, Color_ComboBox.TextChanged

        If Not valuesInitialized Then Exit Sub

        If InitialVehicleValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub LicenseState_ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LicenseState_ComboBox.SelectedIndexChanged, LicenseState_ComboBox.TextChanged

        If Not valuesInitialized Then Exit Sub

        If InitialVehicleValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub LicensePlate_Textbox_TextChanged(sender As Object, e As EventArgs) Handles LicensePlate_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        If InitialVehicleValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub VIN_Textbox_TextChanged(sender As Object, e As EventArgs) Handles VIN_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        If InitialVehicleValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub InspectionMonth_ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles InspectionMonth_ComboBox.SelectedIndexChanged, InspectionMonth_ComboBox.TextChanged

        If Not valuesInitialized Then Exit Sub

        If InitialVehicleValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub InspectionStickerNbr_Textbox_TextChanged(sender As Object, e As EventArgs) Handles InspectionStickerNbr_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        If InitialVehicleValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub InsuranceCompany_ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles InsuranceCompany_ComboBox.SelectedIndexChanged, InsuranceCompany_ComboBox.TextChanged

        If Not valuesInitialized Then Exit Sub

        If InitialVehicleValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub PolicyNumber_Textbox_TextChanged(sender As Object, e As EventArgs) Handles PolicyNumber_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        If InitialVehicleValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub ExpirationDate_Textbox_TextChanged(sender As Object, e As EventArgs) Handles ExpirationDate_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        If InitialVehicleValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub Alarm_CheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles Alarm_CheckBox.CheckedChanged

        If Not valuesInitialized Then Exit Sub

        If InitialVehicleValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub ABS_CheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles ABS_CheckBox.CheckedChanged

        If Not valuesInitialized Then Exit Sub

        If InitialVehicleValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub AirBags_CheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles AirBags_CheckBox.CheckedChanged

        If Not valuesInitialized Then Exit Sub

        If InitialVehicleValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub AC_CheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles AC_CheckBox.CheckedChanged

        If Not valuesInitialized Then Exit Sub

        If InitialVehicleValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub Engine_Textbox_TextChanged(sender As Object, e As EventArgs) Handles Engine_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        If InitialVehicleValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub Notes_Textbox_TextChanged(sender As Object, e As EventArgs) Handles Notes_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        If InitialVehicleValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


End Class