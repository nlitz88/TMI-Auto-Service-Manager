﻿Public Class vehicleMaintenance

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

    Private VehicleRow As Integer               ' Used to keep track of which Vehicle YMML selected
    Private VehicleId As Integer                ' Maintains corresponding VehicleId to YMML
    Private lastSelectedVehicle As String

    ' Keeps track of whether or not user in "editing" or "adding" mode
    Private mode As String

    ' Variable that allows certain keystrokes through restricted fields
    Private allowedKeystroke As Boolean = False

    ' Boolean to keep track of whether or not this form has been closed (needed, as this form can be accessed by other)
    Private MeClosed As Boolean = False




    ' ***************** INITIALIZATION AND CONFIGURATION SUBS *****************


    ' Function that will load all preliminary datatables
    Private Function loadAllPreliminaryDataTables() As Boolean

        ' Loads datatable from Customer
        CustomerDbController.ExecQuery("SELECT IIF(ISNULL(c.LastName), '', c.LastName) + ', ' + IIF(ISNULL(c.FirstName), '', c.FirstName) + IIF(ISNULL(c.Address) OR c.Address = '', '', ' @ ' + c.Address) as CLFA, c.CustomerId, c.LastName " &
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
        MonthDbController.ExecQuery("SELECT m.Month, m.IntMonth FROM Months m ORDER BY m.IntMonth ASC")
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
        VehicleDbController.ExecQuery("SELECT CSTR(IIF(ISNULL(v.makeYear), 0, v.makeYear)) + ' ' + IIF(ISNULL(v.Make), '', v.Make) + ' ' + IIF(ISNULL(v.Model), '', v.Model) + IIF(ISNULL(v.LicensePlate) OR v.LicensePlate = '', '', '  -  ' + v.LicensePlate) as YMML, " &
                                      "v.CustomerId, v.VehicleId, v.makeYear, v.Make, v.Model, v.Color, v.LicenseState, v.LicensePlate, v.VIN, " &
                                      "v.InspectionStickerNbr, v.InspectionMonth, v.InsuranceCompany, v.PolicyNumber, v.ExpirationDate, v.Notes, " &
                                      "v.Engine, v.ABS, v.AC, v.AirBags, v.Alarm " &
                                      "FROM Vehicle v " &
                                      "WHERE v.CustomerId=@customerId " &
                                      "ORDER BY v.makeYear ASC")

        If VehicleDbController.HasException() Then Return False

        Return True

    End Function


    ' Sub that initializes VehicleComboBox after valid CustomerComboBox selection has been made
    Private Sub InitializeVehicleComboBox()

        VehicleComboBox.BeginUpdate()
        VehicleComboBox.Items.Clear()
        VehicleComboBox.Items.Add("Select One")
        For Each row In VehicleDbController.DbDataTable.Rows
            VehicleComboBox.Items.Add(row("YMML"))
        Next
        VehicleComboBox.EndUpdate()

    End Sub


    ' Sub that Accomodates rows that have month Ints instead of abreviations.
    ' Sets inspection months value to the month abreviation that corresponds to the initialized month int (that is no longer being used)
    Private Sub correctInpectionMonthComboBox()

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

    ' Variant for use with correspondingvalue
    Private Sub correctInpectionMonthValue()

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
        correctInpectionMonthComboBox()
        ' Then, format dataEditingControls
        formatDataEditingControls()
        ' Set forecolor if not already initially default
        setForeColor(getAllControlsWithTag("dataEditingControl", Me), DefaultForeColor)

    End Sub

    ' Sub that calls all individual dataViewingControl initialization subs in one (These can be used individually if desired)
    Private Sub InitializeAllDataViewingControls()

        ' Automated initializations
        InitializeVehicleDataViewingControls()
        correctInpectionMonthValue()
        ' Then, format dataViewingControls
        formatDataViewingControls()

    End Sub



    ' Sub that will add formatting to already initialized dataViewingControls (DateTime in this case)
    Private Sub formatDataViewingControls()

        ' EXPIRATION DATE FORMATTING
        ' First, check to see if ExpirationDate is equal to a new date time (this implies that there is a DBNull in this field in the database)
        Dim ExpirationDate As DateTime = VehicleDbController.DbDataTable.Rows(VehicleRow)("ExpirationDate")
        ' If Expiration is a new date time, then we assume DBNull in database, and therefore don't want to display anything for the ExpirationDate
        If DateTime.Compare(ExpirationDate, New DateTime) = 0 Then
            ExpirationDate_Value.Text = String.Empty
            ' If not, then we assume it's a legitimate Date, and would like to format it accordingly
        Else
            ' Don't need to do any invalid character stripping, so just go straight to formatting
            ExpirationDate_Value.Text = String.Format("{0:MM/dd/yyyy}", ExpirationDate)
        End If

    End Sub

    ' Sub that will add formatting to already initialized dataEditingControls (DateTime in this case)
    Private Sub formatDataEditingControls()

        ' EXPIRATION DATE FORMATTING
        ' First, check to see if ExpirationDate is equal to a new date time (this implies that there is a DBNull in this field in the database)
        Dim ExpirationDate As DateTime = VehicleDbController.DbDataTable.Rows(VehicleRow)("ExpirationDate")
        ' If Expiration is a new date time, then we assume DBNull in database, and therefore don't want to display anything for the ExpirationDate
        If DateTime.Compare(ExpirationDate, New DateTime) = 0 Then
            ExpirationDate_Textbox.Text = String.Empty
            ' If not, then we assume it's a legitimate Date, and would like to format it accordingly
        Else
            ' Don't need to do any invalid character stripping, so just go straight to formatting
            ExpirationDate_Textbox.Text = String.Format("{0:MM/dd/yyyy}", ExpirationDate)
        End If

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

        ' Define additional values to add. In this case, just CustomerId
        Dim additionalValues As New List(Of AdditionalValue) From {New AdditionalValue("CustomerId", GetType(Int32), CustomerId)}

        insertRow(CRUD, VehicleDbController.DbDataTable, "Vehicle", "_", "dataEditingControl", Me, additionalValues)

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

                ' Before looking up anything, must ESCAPE special escape characters from the values to be looked up
                ' eMakeYear doesn't need this, as it's a number only input
                Dim eMake As String = escapeLikeValues(Make_ComboBox.Text)
                Dim eModel As String = escapeLikeValues(Model_ComboBox.Text)
                Dim eLicensePlate As String = escapeLikeValues(LicensePlate_Textbox.Text)

                ' Use query to check if row exists with all of these
                Dim duplicateRows() As DataRow = VehicleDbController.DbDataTable.Select("makeYear='" & Long.Parse(makeYear_Textbox.Text) &
                                                                                            "' AND Make LIKE '" & eMake &
                                                                                            "' AND Model LIKE '" & eModel &
                                                                                            "' AND LicensePlate LIKE '" & eLicensePlate & "'")

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

            ' Before looking up anything, must ESCAPE special escape characters from the values to be looked up
            ' eMakeYear doesn't need this, as it's a number only input
            Dim eMake As String = escapeLikeValues(Make_ComboBox.Text)
            Dim eModel As String = escapeLikeValues(Model_ComboBox.Text)
            Dim eLicensePlate As String = escapeLikeValues(LicensePlate_Textbox.Text)

            ' Use query to check if row exists with all of these
            Dim duplicateRows() As DataRow = VehicleDbController.DbDataTable.Select("makeYear='" & Long.Parse(makeYear_Textbox.Text) &
                                                                                            "' AND Make LIKE '" & eMake &
                                                                                            "' AND Model LIKE '" & eModel &
                                                                                            "' AND LicensePlate LIKE '" & eLicensePlate & "'")

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
        ElseIf Not String.IsNullOrWhiteSpace(Make_ComboBox.Text) And Not valueExists("AutoMake", Make_ComboBox.Text, MakeDbController.DbDataTable) Then
            errorMessage += "ERROR: " & Make_ComboBox.Text & " is not a valid manufacturer" & vbNewLine
            Make_ComboBox.ForeColor = Color.Red
        End If

        ' Model
        If Not isValidLength("Model", False, Model_ComboBox.Text, 20, errorMessage) Then
            Model_ComboBox.ForeColor = Color.Red
        ElseIf Not String.IsNullOrWhiteSpace(Model_ComboBox.Text) And Not valueExists("AutoModel", Model_ComboBox.Text, ModelDbController.DbDataTable) Then
            errorMessage += "ERROR: " & Model_ComboBox.Text & " is not an existing model of " & Make_ComboBox.Text & vbNewLine
            Model_ComboBox.ForeColor = Color.Red
        End If

        ' Year
        If Not validNumber("Year", False, makeYear_Textbox.Text, errorMessage, True) Then makeYear_Textbox.ForeColor = Color.Red

        ' Color
        If Not isValidLength("Color", False, Color_ComboBox.Text, 20, errorMessage) Then
            Color_ComboBox.ForeColor = Color.Red
        ElseIf Not String.IsNullOrWhiteSpace(Color_ComboBox.Text) And Not valueExists("Color", Color_ComboBox.Text, ColorDbController.DbDataTable) Then
            errorMessage += "ERROR: " & Color_ComboBox.Text & " is not a valid color" & vbNewLine
            Color_ComboBox.ForeColor = Color.Red
        End If

        ' License State
        If Not isValidLength("License State", False, LicenseState_ComboBox.Text, 2, errorMessage) Then
            LicenseState_ComboBox.ForeColor = Color.Red
        ElseIf Not String.IsNullOrWhiteSpace(LicenseState_ComboBox.Text) And Not valueExists("State", LicenseState_ComboBox.Text, StateDbController.DbDataTable) Then
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
        ElseIf Not String.IsNullOrWhiteSpace(InspectionMonth_ComboBox.Text) And Not valueExists("Month", InspectionMonth_ComboBox.Text, MonthDbController.DbDataTable) Then
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
        ElseIf Not String.IsNullOrWhiteSpace(InsuranceCompany_ComboBox.Text) And Not valueExists("CompanyName", InsuranceCompany_ComboBox.Text, InsuranceCompanyDbController.DbDataTable) Then
            errorMessage += "ERROR: " & InsuranceCompany_ComboBox.Text & " is not a valid Insurance Company" & vbNewLine
            InsuranceCompany_ComboBox.ForeColor = Color.Red
        End If

        ' Policy Number
        If Not isValidLength("Policy Number", False, PolicyNumber_Textbox.Text, 20, errorMessage) Then
            PolicyNumber_Textbox.ForeColor = Color.Red
        End If

        ' Insurance Expiration Date
        If Not validDateTime("Expiration Date", False, ExpirationDate_Textbox.Text, errorMessage) Then
            ExpirationDate_Textbox.ForeColor = Color.Red
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



    ' Function that can be used to warn user about non-critical errors. These errors can be ignored if the user desires, but should still be reported.
    Private Function nonCriticalErrors() As Boolean

        Dim errorMessage As String = String.Empty


        ' Insurance Expiration Date
        If Not validDateTime("Expiration Date", False, ExpirationDate_Textbox.Text, errorMessage) Then
            ExpirationDate_Textbox.ForeColor = Color.Red
            ' If valid DateTime, then ensure that it is greater than current Date. Don't try to check, however, if the date has been left empty
        ElseIf Not ExpirationDate_Textbox.Text.Replace(" ", "0") = "00/00/0000" Then
            Try
                ' Try implemented here just in case datetime conversion fails unexpectedly
                Dim ExpDate As Date = Convert.ToDateTime(ExpirationDate_Textbox.Text)
                If ExpDate < Date.Now() Then
                    ExpirationDate_Textbox.ForeColor = Color.Red
                    errorMessage += "ERROR: Insurance policy expired." & vbNewLine
                End If
            Catch ex As Exception

            End Try
        End If


        ' Check if any errors has been found
        If Not String.IsNullOrEmpty(errorMessage) Then

            errorMessage += vbNewLine
            errorMessage += "Continue and ignore errors?"

            Dim Decision As DialogResult = MessageBox.Show(errorMessage, "Non-Critical Errors Encountered", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If Decision = DialogResult.No Then
                Return False
            End If

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


        ' IF ARRIVING FROM INVOICES SCREEN, FIRE ADDCUSTOMER EVENT AND SHOW RETURN BUTTON
        If previousScreen IsNot Nothing Then

            ' Just ensure that the previous screen is invoices before acting
            If previousScreen Is invoices Then
                nav.Visible = False
                returnButton.Visible = True

                ' Get Customer Id from invoices here
                CustomerId = invoices.GetCustomerId()
                ' Get corresponding CLFA
                Dim CustomerComboBoxItem As String = getRowValueWithKeyEquals(CustomerDbController.DbDataTable, "CLFA", "CustomerId", CustomerId)
                ' Set ComboBox accordingly after one final check
                If CustomerComboBoxItem <> Nothing Then
                    CustomerComboBox.SelectedIndex = CustomerComboBox.Items.IndexOf(CustomerComboBoxItem)
                Else
                    ' If not successful, throw error and bring them back
                    MessageBox.Show("Could not find customer in customers table. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    MeClosed = True
                    changeScreen(previousScreen, Me)
                    previousScreen = Nothing
                    Exit Sub
                End If

                ' Then, finally add new vehicle if successfully selected customer based on customer id
                addButton_Click(addButton, New EventArgs())
            End If

        Else
            returnButton.Visible = False
        End If

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

            '' Now that valid selection made, put focus on vehicleComboBox
            'CustomerComboBox.SelectionLength = 0
            'VehicleComboBox.Focus()

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

        ' Ensure that VehicleCombobox is only attempting to initialize values when on proper selected Index
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

            VehicleId = VehicleDbController.DbDataTable.Rows(VehicleRow)("VehicleId")

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
        VehicleComboBox.Enabled = False

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

        ' Select first editing control
        Make_ComboBox.Focus()

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
        InitializeAllDataEditingControls()
        ' load car models based on auto make, then initialize
        loadCarModelsDataTable()
        InitializeModelComboBox()

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

        ' Select first editing control
        Make_ComboBox.Focus()

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

                    ' 1.) VALIDATE DATAEDITING CONTROLS AND CHECK FOR NON-CRITICAL ERRORS
                    If Not controlsValid() Then Exit Sub
                    If Not nonCriticalErrors() Then Exit Sub

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
                    Dim updatedItem As String = getRowValueWithKeyEquals(VehicleDbController.DbDataTable, "YMML", "VehicleId", VehicleId)
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

                    ' 1.) VALIDATE DATAEDITING CONTROLS AND CHECK FOR NON-CRITICAL ERRORS
                    If Not controlsValid() Then Exit Sub
                    If Not nonCriticalErrors() Then Exit Sub

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
                        Dim newItem As String = getRowValueWithKeyEquals(VehicleDbController.DbDataTable, "YMML", "VehicleId", newVehicleId)

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

        Make_ComboBox.ForeColor = DefaultForeColor

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

        Model_ComboBox.ForeColor = DefaultForeColor

        If InitialVehicleValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private Sub makeYear_Textbox_KeyDown(sender As Object, e As KeyEventArgs) Handles makeYear_Textbox.KeyDown

        ' Allow certain keystrokes through here. Oftentimes, these will be common shortcuts
        If ((e.KeyCode = Keys.A And e.Control) Or (e.KeyCode = Keys.C And e.Control) Or (e.KeyCode = Keys.V And e.Control)) Then
            allowedKeystroke = True
        End If

    End Sub

    Private Sub makeYear_Textbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles makeYear_Textbox.KeyPress

        ' If certain keystroke exceptions allowed throuhg, then skip input validation here
        If allowedKeystroke Then
            allowedKeystroke = False
            Exit Sub
        End If

        If Not numericInputValid(makeYear_Textbox, e.KeyChar, True) Then
            e.KeyChar = Chr(0)
            e.Handled = True
        End If

    End Sub

    Private Sub makeYear_Textbox_TextChanged(sender As Object, e As EventArgs) Handles makeYear_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        makeYear_Textbox.ForeColor = DefaultForeColor

        ' Handles pasting in invalid values/strings
        Dim lastValidIndex As Integer = allValidChars(makeYear_Textbox.Text, "1234567890")
        If lastValidIndex <> -1 Then
            makeYear_Textbox.Text = makeYear_Textbox.Text.Substring(0, lastValidIndex)
            makeYear_Textbox.SelectionStart = lastValidIndex
        End If

        If InitialVehicleValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private Sub Color_ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Color_ComboBox.SelectedIndexChanged, Color_ComboBox.TextChanged

        If Not valuesInitialized Then Exit Sub

        Color_ComboBox.ForeColor = DefaultForeColor

        If InitialVehicleValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub LicenseState_ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LicenseState_ComboBox.SelectedIndexChanged, LicenseState_ComboBox.TextChanged

        If Not valuesInitialized Then Exit Sub

        LicenseState_ComboBox.ForeColor = DefaultForeColor

        If InitialVehicleValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub LicensePlate_Textbox_TextChanged(sender As Object, e As EventArgs) Handles LicensePlate_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        LicensePlate_Textbox.ForeColor = DefaultForeColor

        If InitialVehicleValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub VIN_Textbox_TextChanged(sender As Object, e As EventArgs) Handles VIN_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        VIN_Textbox.ForeColor = DefaultForeColor

        If InitialVehicleValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub InspectionMonth_ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles InspectionMonth_ComboBox.SelectedIndexChanged, InspectionMonth_ComboBox.TextChanged

        If Not valuesInitialized Then Exit Sub

        InspectionMonth_ComboBox.ForeColor = DefaultForeColor

        If InitialVehicleValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub InspectionStickerNbr_Textbox_TextChanged(sender As Object, e As EventArgs) Handles InspectionStickerNbr_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        InspectionStickerNbr_Textbox.ForeColor = DefaultForeColor

        If InitialVehicleValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub InsuranceCompany_ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles InsuranceCompany_ComboBox.SelectedIndexChanged, InsuranceCompany_ComboBox.TextChanged

        If Not valuesInitialized Then Exit Sub

        InsuranceCompany_ComboBox.ForeColor = DefaultForeColor

        If InitialVehicleValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub PolicyNumber_Textbox_TextChanged(sender As Object, e As EventArgs) Handles PolicyNumber_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        PolicyNumber_Textbox.ForeColor = DefaultForeColor

        If InitialVehicleValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub ExpirationDate_Textbox_TextChanged(sender As Object, e As EventArgs) Handles ExpirationDate_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        ExpirationDate_Textbox.ForeColor = DefaultForeColor

        If InitialVehicleValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub Alarm_CheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles Alarm_CheckBox.CheckedChanged

        If Not valuesInitialized Then Exit Sub

        Alarm_CheckBox.ForeColor = DefaultForeColor

        If InitialVehicleValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub ABS_CheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles ABS_CheckBox.CheckedChanged

        If Not valuesInitialized Then Exit Sub

        ABS_CheckBox.ForeColor = DefaultForeColor

        If InitialVehicleValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub AirBags_CheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles AirBags_CheckBox.CheckedChanged

        If Not valuesInitialized Then Exit Sub

        AirBags_CheckBox.ForeColor = DefaultForeColor

        If InitialVehicleValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub AC_CheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles AC_CheckBox.CheckedChanged

        If Not valuesInitialized Then Exit Sub

        AC_CheckBox.ForeColor = DefaultForeColor

        If InitialVehicleValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub Engine_Textbox_TextChanged(sender As Object, e As EventArgs) Handles Engine_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        Engine_Textbox.ForeColor = DefaultForeColor

        If InitialVehicleValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub Notes_Textbox_TextChanged(sender As Object, e As EventArgs) Handles Notes_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        Notes_Textbox.ForeColor = DefaultForeColor

        If InitialVehicleValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub



    Private Sub returnButton_Click(sender As Object, e As EventArgs) Handles returnButton.Click

        If Not MeClosed Then

            ' Only want to ask them if the ctrl values are currently being edited AND they're values have changed
            If Make_ComboBox.Visible And InitialVehicleValues.CtrlValuesChanged() Then

                Dim decision As DialogResult = MessageBox.Show("Return without saving changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If decision = DialogResult.No Then
                    Exit Sub
                Else

                    If previousScreen Is invoices Then
                        ' Call REINITIALIZATION HERE
                        If Not invoices.reinitializeVehicles() Then
                            MessageBox.Show("Reloading of vehicles unsuccessful; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            saveButton.Enabled = False
                            Exit Sub
                        End If
                    End If

                    MeClosed = True
                    changeScreen(previousScreen, Me)
                    previousScreen = Nothing

                End If

            Else

                If previousScreen Is invoices Then
                    ' Call REINITIALIZATION HERE
                    If Not invoices.reinitializeVehicles() Then
                        MessageBox.Show("Reloading of vehicles unsuccessful; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        saveButton.Enabled = False
                        Exit Sub
                    End If
                End If

                MeClosed = True
                changeScreen(previousScreen, Me)
                previousScreen = Nothing

            End If

        End If

    End Sub


    Private Sub vehicleMaintenance_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If Not MeClosed Then

            ' Only want to ask them if the ctrl values are currently being edited AND they're values have changed
            If Make_ComboBox.Visible And InitialVehicleValues.CtrlValuesChanged() Then

                Dim decision As DialogResult = MessageBox.Show("Return without saving changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If decision = DialogResult.No Then
                    Exit Sub
                Else

                    ' If coming from another screen, then change back to that screen
                    If previousScreen IsNot Nothing Then

                        If previousScreen Is invoices Then
                            ' Call REINITIALIZATION HERE
                            If Not invoices.reinitializeVehicles() Then
                                MessageBox.Show("Reloading of vehicles unsuccessful; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                saveButton.Enabled = False
                                Exit Sub
                            End If
                        End If

                        MeClosed = True
                        changeScreen(previousScreen, Me)
                        previousScreen = Nothing

                        ' If not coming from another form, then exit normally
                    Else
                        MeClosed = True
                        Me.Close()
                    End If

                End If

            Else

                ' If coming from another screen, then change back to that screen
                If previousScreen IsNot Nothing Then

                    If previousScreen Is invoices Then
                        ' Call REINITIALIZATION HERE
                        If Not invoices.reinitializeVehicles() Then
                            MessageBox.Show("Reloading of vehicles unsuccessful; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            saveButton.Enabled = False
                            Exit Sub
                        End If
                    End If

                    MeClosed = True
                    changeScreen(previousScreen, Me)
                    previousScreen = Nothing

                    ' If not coming from another form, then exit normally
                Else
                    MeClosed = True
                    Me.Close()
                End If

            End If

        End If

    End Sub


End Class