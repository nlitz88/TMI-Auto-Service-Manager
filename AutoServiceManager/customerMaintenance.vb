Public Class customerMaintenance

    ' New Database control instances for Customers and ZipCodes datatable
    Private CustomerDbController As New DbControl()
    Private ZipCodesDbController As New DbControl()
    ' New Database control instance for updating, inserting, and deleting
    Private CRUD As New DbControl()

    ' Initialize instance(s) of initialValues class
    Private InitialCustomerValues As New InitialValues()

    'Variable to keep track of whether form fully loaded or not
    Private valuesInitialized As Boolean = True

    ' Row index variables used for DataTable lookups
    Private CustomerRow As Integer
    Private zcRow As Integer
    Private lastSelected As String

    ' Keeps track of whether or not user in "editing" or "adding" mode
    Private mode As String

    ' Variable that allows certain keystrokes through restricted fields
    Private allowedKeystroke As Boolean = False




    ' ***************** INITIALIZATION AND CONFIGURATION SUBS *****************


    ' Function that makes calls to all DbControllers for one-time "preliminary" datatable loading
    Private Function loadAllPreliminaryDataTables() As Boolean

        ZipCodesDbController.ExecQuery("Select zc.Zipcode, zc.city as City, zc.State from ZipCodes zc")
        If ZipCodesDbController.HasException() Then Return False

        Return True

    End Function


    ' Sub that will contain calls to all of the instances of the database controller class that loads data from the database into DataTables
    Private Function loadCustomerDataTable() As Boolean

        CustomerDbController.ExecQuery("SELECT c.LastName + ', ' + IIF(ISNULL(c.FirstName), '', c.FirstName) + ' @ ' + IIF(ISNULL(c.Address), '', c.Address) as CLFA, " &
            "c.CustomerId, c.FirstName, c.LastName, c.Address, c.City, c.State, c.ZipCode, c.HomePhone, c.WorkPhone, c.CellPhone1, c.CellPhone2, c.TaxExempt, c.EmailAddress " &
            "FROM Customer c " &
            "WHERE Trim(LastName) <> '' " &
            "ORDER BY c.LastName ASC")

        If CustomerDbController.HasException() Then Return False

        Return True

    End Function


    ' Sub that initializes all dataEditingcontrols corresponding with values from the Customer datatable
    Private Sub InitializeCustomerDataEditingControls()

        initializeControlsFromRow(CustomerDbController.DbDataTable, CustomerRow, "dataEditingControl", "_", Me)

    End Sub

    ' Sub that initializes all dataViewingControls corresponding with values from the Customer datatable
    Private Sub InitializeCustomerDataViewingControls()


        initializeControlsFromRow(CustomerDbController.DbDataTable, CustomerRow, "dataViewingControl", "_", Me)

    End Sub

    ' Sub that initializes Customer ComboBox
    Private Sub InitializeCustomerComboBox()

        'valuesInitialized = False
        CustomerComboBox.BeginUpdate()
        CustomerComboBox.Items.Clear()
        CustomerComboBox.Items.Add("Select One")
        For Each row In CustomerDbController.DbDataTable.Rows
            CustomerComboBox.Items.Add(row("CLFA"))
        Next
        CustomerComboBox.EndUpdate()

        'valuesInitialized = True

    End Sub


    ' Sub that initializes the DataEditingControls corresponding with the values from the ZipCodes datatable
    Private Sub InitializeZipCodeDataEditingControls()

        Try

            Dim ZipCode As String = ZipCode_ComboBox.Text
            Dim ZipCodeRows() As DataRow = ZipCodesDbController.DbDataTable.Select("Zipcode = '" & ZipCode & "'")

            If ZipCodeRows.Count = 0 Then Exit Sub     ' If not found, exit
            ' Otherwise, get row number that corresponds with that value from that row
            zcRow = ZipCodesDbController.DbDataTable.Rows.IndexOf(ZipCodeRows(0))

            initializeControlsFromRow(ZipCodesDbController.DbDataTable, zcRow, "dataEditingControl", "_", Me)

        Catch ex As Exception

        End Try


    End Sub

    ' Sub that initializes the DataEditingControls corresponding with the values from the ZipCodes datatable
    Private Sub InitializeZipCodeDataViewingControls()

        Try

            Dim ZipCode As String = ZipCode_Value.Text
            Dim ZipCodeRows() As DataRow = ZipCodesDbController.DbDataTable.Select("Zipcode = '" & ZipCode & "'")

            If ZipCodeRows.Count = 0 Then Exit Sub     ' If not found, exit
            ' Otherwise, get row number that corresponds with that value from that row
            zcRow = ZipCodesDbController.DbDataTable.Rows.IndexOf(ZipCodeRows(0))

            initializeControlsFromRow(ZipCodesDbController.DbDataTable, zcRow, "dataViewingControl", "_", Me)

        Catch ex As Exception

        End Try


    End Sub

    ' Sub that initializes ZipCode combobox
    Private Sub InitializeZipCodeComboBox()

        ZipCode_ComboBox.Items.Clear()
        ZipCode_ComboBox.BeginUpdate()
        ' If mode = "adding" Then ZipCode_ComboBox.Items.Add("Select One")
        For Each row In ZipCodesDbController.DbDataTable.Rows
            ZipCode_ComboBox.Items.Add(row("Zipcode"))
        Next
        ZipCode_ComboBox.EndUpdate()

    End Sub


    ' Sub that calls all individual dataEditingControl initialization subs in one (These can be used individually if desired)
    Private Sub InitializeAllDataEditingControls()

        '' Initialize ZipCode ComboBox (this way, it's value can be assigned properly)
        'InitializeZipCodeComboBox() ' this should only have to be done once in the beginning?
        ' Automated initializations
        InitializeCustomerDataEditingControls()
        ' Initialization of Editing controls dependent on zip code
        InitializeZipCodeDataEditingControls()
        ' Set forecolor if not already initially default
        setForeColor(getAllControlsWithTag("dataEditingControl", Me), DefaultForeColor)

    End Sub

    ' Sub that calls all individual dataEditingControl initialization subs in one (These can be used individually if desired)
    Private Sub InitializeAllDataViewingControls()

        ' Automated initializations
        InitializeCustomerDataViewingControls()
        ' Then, format dataViewingControls
        formatDataViewingControls()
        ' Initialization of viewing controls dependent on zip code
        InitializeZipCodeDataViewingControls()

    End Sub


    ' Sub that will call formatting functions to add respective formats to already INITIALIZED DATAVIEWINGCONTROLS (i.e. phone numbers, currency, etc.).
    Private Sub formatDataViewingControls()

        ' Formatting for labels that contain values from DataTable

        ' For these phone numbers, first strip them of any invalidCharacters, then format their respective labels (if stripped not null)
        Dim strippedTexted As String
        If Not String.IsNullOrEmpty(HomePhone_Value.Text) Then
            strippedTexted = removeInvalidChars(HomePhone_Value.Text, "1234567890")
            If Not String.IsNullOrEmpty(strippedTexted) Then
                HomePhone_Value.Text = String.Format("{0:(000) 000-0000}", Long.Parse(removeInvalidChars(HomePhone_Value.Text, "1234567890")))
            End If
        End If
        If Not String.IsNullOrEmpty(WorkPhone_Value.Text) Then
            strippedTexted = removeInvalidChars(WorkPhone_Value.Text, "1234567890")
            If Not String.IsNullOrEmpty(strippedTexted) Then
                WorkPhone_Value.Text = String.Format("{0:(000) 000-0000}", Long.Parse(removeInvalidChars(WorkPhone_Value.Text, "1234567890")))
            End If
        End If
        If Not String.IsNullOrEmpty(CellPhone1_Value.Text) Then
            strippedTexted = removeInvalidChars(CellPhone1_Value.Text, "1234567890")
            If Not String.IsNullOrEmpty(strippedTexted) Then
                CellPhone1_Value.Text = String.Format("{0:(000) 000-0000}", Long.Parse(removeInvalidChars(CellPhone1_Value.Text, "1234567890")))
            End If
        End If
        If Not String.IsNullOrEmpty(CellPhone2_Value.Text) Then
            strippedTexted = removeInvalidChars(CellPhone2_Value.Text, "1234567890")
            If Not String.IsNullOrEmpty(strippedTexted) Then
                CellPhone2_Value.Text = String.Format("{0:(000) 000-0000}", Long.Parse(removeInvalidChars(CellPhone2_Value.Text, "1234567890")))
            End If
        End If

    End Sub

    '' ADD FORMAT STRIPPING FUNCTIONS HERE IF NECESSARRY (Don't think so)


    ' Function that makes updateTable calls for all relevant DataTables that need updated based on changes
    Private Function updateAll() As Boolean

        ' Lookup CustomerId (primary key) based on selected CLF in ComboBox
        Dim customerId As Integer = CustomerDbController.DbDataTable.Rows(CustomerRow)("CustomerId")

        ' Because CustomerId is our primary key, we don't want to try and update its value too (not possible in this case)
        ' So, add CustomerId_Textbox to the excluded list. We can still use it as our key, but updateRow won't try and update its value
        Dim excludedList As New List(Of Control) From {CustomerId_Textbox}

        ' Using CustomerID as key, update customer row
        updateTable(CRUD, CustomerDbController.DbDataTable, "Customer", customerId, "CustomerId", "_", "dataEditingControl", Me, excludedList)
        ' Then, return exception status of CRUD controller. Do this after each call
        If CRUD.HasException() Then Return False

        ' Otherwise, return true
        Return True

    End Function


    ' Function that makes insertRow calls for all relevant DataTables
    Private Function insertAll() As Boolean

        ' Because CustomerId is an autoincremented value in the database, we don't want to attempt to insert a value for it here
        ' So, exclude the new value in CustomerId_Textbox from being inserted
        Dim excludedList As New List(Of Control) From {CustomerId_Textbox}

        ' Then, make calls to insertRow to all relevant tables
        insertRow(CRUD, CustomerDbController.DbDataTable, "Customer", "_", "dataEditingControl", Me, excludedList)
        ' Then, return exception status of CRUD controller. Do this after each call
        If CRUD.HasException() Then Return False

        ' Otherwise, return true
        Return True

    End Function


    ' Function that makes deleteRow calls for all relevant DataTables
    Private Function deleteAll() As Boolean

        ' Lookup CustomerId (primary key) based on selected CLF in ComboBox
        Dim customerId As Integer = CustomerDbController.DbDataTable.Rows(CustomerRow)("CustomerId")
        deleteRow(CRUD, "Customer", customerId, "CustomerId")
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


        ' Last Name (REQUIRED)
        'If Not isValidLength("Last Name", True, LastName_Textbox.Text, 20, errorMessage) Then
        '    LastName_Textbox.ForeColor = Color.Red
        'End If

        ' First Name
        If Not isValidLength("First Name", False, FirstName_Textbox.Text, 20, errorMessage) Then
            FirstName_Textbox.ForeColor = Color.Red
        End If

        ' Street Address (REQUIRED)
        If Not isValidLength("Street Address", False, Address_Textbox.Text, 50, errorMessage) Then
            Address_Textbox.ForeColor = Color.Red
        End If


        ' CHECK IF CLFA (Last, First, Address Combination) NOT A DUPLICATE (but only check if Last Name is filled out)
        ' First, ensure that Last Name (REQUIRED)
        If Not isValidLength("Last Name", True, LastName_Textbox.Text, 20, errorMessage) Then
            LastName_Textbox.ForeColor = Color.Red
            ' If Last Name isn't blank, then check to see if CLFA is a duplicate
        Else

            If mode = "editing" Then

                ' Get initial values (that make up CLFA) to see if there changes are the same as initial
                Dim initialLName As String = CustomerDbController.DbDataTable.Rows(CustomerRow)("LastName").ToString().ToLower()
                Dim initialFName As String = CustomerDbController.DbDataTable.Rows(CustomerRow)("FirstName").ToString().ToLower()
                Dim initialAddress As String = CustomerDbController.DbDataTable.Rows(CustomerRow)("Address").ToString().ToLower()

                ' Only if the current values (that make up the CLFA) are not equal to their initial values
                If LastName_Textbox.Text.ToLower() <> initialLName Or FirstName_Textbox.Text.ToLower() <> initialFName Or Address_Textbox.Text.ToLower() <> initialAddress Then

                    ' Use query to check if row exists with all of these
                    Dim duplicateRows() As DataRow = CustomerDbController.DbDataTable.Select("LastName LIKE '" & LastName_Textbox.Text &
                                                                                            "' AND FirstName LIKE '" & FirstName_Textbox.Text &
                                                                                            "' AND Address LIKE '" & Address_Textbox.Text & "'")

                    If duplicateRows.Count <> 0 Then
                        errorMessage += "ERROR: " & LastName_Textbox.Text & ", " & FirstName_Textbox.Text & " @ " & Address_Textbox.Text & " already exists;" & vbNewLine &
                            "Please modify Last Name, First Name, or Address" & vbNewLine
                        LastName_Textbox.ForeColor = Color.Red
                        FirstName_Textbox.ForeColor = Color.Red
                        Address_Textbox.ForeColor = Color.Red
                    End If

                End If


            ElseIf mode = "adding" Then

                ' Use query to check if row exists with all of these
                Dim duplicateRows() As DataRow = CustomerDbController.DbDataTable.Select("LastName LIKE '" & LastName_Textbox.Text &
                                                                                            "' AND FirstName LIKE '" & FirstName_Textbox.Text &
                                                                                            "' AND Address LIKE '" & Address_Textbox.Text & "'")

                If duplicateRows.Count <> 0 Then
                    errorMessage += "ERROR: " & LastName_Textbox.Text & ", " & FirstName_Textbox.Text & " @ " & Address_Textbox.Text & " already exists;" & vbNewLine &
                            "Please modify Last Name, First Name, or Address" & vbNewLine
                    LastName_Textbox.ForeColor = Color.Red
                    FirstName_Textbox.ForeColor = Color.Red
                    Address_Textbox.ForeColor = Color.Red
                End If

            End If

        End If


        ' ZipCode (REQUIRED)
        If Not validZipCode(ZipCode_ComboBox.Text, errorMessage) Then
            ZipCode_ComboBox.ForeColor = Color.Red
        ElseIf Not valueExists("ZIP Code", errorMessage, "Zipcode", ZipCode_ComboBox.Text, ZipCodesDbController.DbDataTable) Then
            ZipCode_ComboBox.ForeColor = Color.Red
        End If

        ' Home Phone
        If Not validPhone("Home Phone", False, HomePhone_Textbox.Text, errorMessage) Then
            HomePhone_Textbox.ForeColor = Color.Red
        End If

        ' Work Phone
        If Not validPhone("Work Phone", False, WorkPhone_Textbox.Text, errorMessage) Then
            WorkPhone_Textbox.ForeColor = Color.Red
        End If

        ' Cell Phone 1
        If Not validPhone("Cell Phone 1", False, CellPhone1_Textbox.Text, errorMessage) Then
            CellPhone1_Textbox.ForeColor = Color.Red
        End If

        ' Cell Phone 2
        If Not validPhone("Cell Phone 2", False, CellPhone2_Textbox.Text, errorMessage) Then
            CellPhone2_Textbox.ForeColor = Color.Red
        End If

        ' Email
        'If Not validEmail("Email", False, EmailAddress_Textbox.Text, errorMessage) Then
        '    EmailAddress_Textbox.ForeColor = Color.Red
        'End If


        ' Check if any invalid input has been found
        If Not String.IsNullOrEmpty(errorMessage) Then

            MessageBox.Show(errorMessage, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False

        End If

        Return True

    End Function


    Private Sub customerMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' PRE-DRAW PRE-LOADED COMBOBOXES. 
        ' This ensures that ZipCode Combobox is predrawn. onLoad, that way, we don't have to wait for it on first edit.
        ' Implement this in companyMaster, Vehicles, and MTL as well
        ZipCode_ComboBox.Visible = True
        ZipCode_ComboBox.Visible = False

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ' TEST DATABASE CONNECTION FIRST
        If Not checkDbConn() Then Exit Sub

        ' LOAD DATATABLES FROM DATABASE INITIALLY
        If Not loadAllPreliminaryDataTables() Then
            MessageBox.Show("Failed to connect to database; Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Not loadCustomerDataTable() Then
            MessageBox.Show("Failed to connect to database; Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Initialize Preloaded ComboBoxes
        InitializeZipCodeComboBox()
        InitializeCustomerComboBox()
        CustomerComboBox.SelectedIndex = 0

    End Sub




    ' **************** CONTROL SUBS ****************


    Private Sub CustomerComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CustomerComboBox.SelectedIndexChanged, CustomerComboBox.TextChanged


        ' Ensure that CustomerCombobox is only attempting to initialize values when on proper selected Index
        If CustomerComboBox.SelectedIndex = -1 Then

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
        CustomerRow = getDataTableRow(CustomerDbController.DbDataTable, "CLFA", CustomerComboBox.Text)

        ' If this query DOES return a valid row index, then initialize respective controls
        If CustomerRow <> -1 Then

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
        ' Set ZipCode ComboBox selected index = -1
        ZipCode_ComboBox.SelectedIndex = -1
        valuesInitialized = True
        ' Establish initial values. Doing this here, as unless changes are about to be made, we don't need to set initial values
        InitialCustomerValues.SetInitialValues(getAllControlsWithTag("dataEditingControl", Me))

        ' First, disable editButton, addButton, enable cancelButton, and disable nav
        editButton.Enabled = False
        addButton.Enabled = False
        cancelButton.Enabled = True
        nav.DisableAll()
        CustomerComboBox.Enabled = False

        ' Get lastSelected
        If getDataTableRow(CustomerDbController.DbDataTable, "CLFA", CustomerComboBox.Text) <> -1 Then
            lastSelected = CustomerComboBox.Text
        Else
            lastSelected = "Select One"
        End If

        CustomerComboBox.SelectedIndex = 0

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
                    MessageBox.Show("Successfully deleted " & CustomerComboBox.Text & " from Customers")
                End If

                ' 2.) RELOAD DATATABLES FROM DATABASE
                If Not loadCustomerDataTable() Then
                    MessageBox.Show("Loading updated information failed; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                ' 3.) REINITIALIZE CONTROLS (Based on the selected index)
                InitializeCustomerComboBox()
                CustomerComboBox.SelectedIndex = 0

                ' 4.) RESTORE USER CONTROLS TO NON-EDITING/SELECTING STATE
                CustomerComboBox.Enabled = True
                addButton.Enabled = True
                cancelButton.Enabled = False
                saveButton.Enabled = False
                nav.EnableAll()
                ' Show/Hide the dataViewingControls and dataEditingControls, respectively
                ' This will be done by changing the selectedIndex to 0. May have to fire event here manually.

            Case DialogResult.No

        End Select

    End Sub


    Private Sub editButton_Click(sender As Object, e As EventArgs) Handles editButton.Click

        mode = "editing"

        ' Initialize values for dataEditingControls
        valuesInitialized = False
        InitializeAllDataEditingControls()
        valuesInitialized = True
        ' Establish initial values. Doing this here, as unless changes are about to be made, we don't need to set initial values
        InitialCustomerValues.SetInitialValues(getAllControlsWithTag("dataEditingControl", Me))

        ' Store the last selected item in the ComboBox (in case update fails and it must revert)
        lastSelected = CustomerComboBox.Text

        ' Disable editButton, disable addButton, enable cancel button, disable navigation, and disable main selection combobox
        editButton.Enabled = False
        addButton.Enabled = False
        cancelButton.Enabled = True
        nav.DisableAll()
        CustomerComboBox.Enabled = False

        ' Hide/Show the dataViewingControls and dataEditingControls, respectively
        showHide(getAllControlsWithTag("dataViewingControl", Me), 0)
        showHide(getAllControlsWithTag("dataEditingControl", Me), 1)

    End Sub


    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click

        ' Check for changes before cancelling. Don't need function here that calls all, as only working with one datatable's values
        If InitialCustomerValues.CtrlValuesChanged() Then

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

            ' Show/Hide the dataViewingControls and dataEditingControls, respectively
            showHide(getAllControlsWithTag("dataViewingControl", Me), 1)
            showHide(getAllControlsWithTag("dataEditingControl", Me), 0)

        ElseIf mode = "adding" Then

            ' 1.) SET PartComboBox BACKK TO LAST SELECTED ITEM/INDEX
            CustomerComboBox.SelectedIndex = CustomerComboBox.Items.IndexOf(lastSelected)

            ' 2.) IF LAST SELECTED WAS "SELECT ONE", Then simulate functionality from combobox text/selectedIndex changed
            If lastSelected = "Select One" Then
                CustomerComboBox_SelectedIndexChanged(CustomerComboBox, New EventArgs())
            End If

            ' 3.) RESTORE USER CONTROLS TO NON-ADDING STATE (only those that are controlled by "adding")
            CustomerComboBox.Enabled = True
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
                        MessageBox.Show("Successfully updated Customers")
                    End If

                    ' 3.) RELOAD DATATABLES FROM DATABASE
                    If Not loadCustomerDataTable() Then
                        MessageBox.Show("Loading updated information failed; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    ' 4.) REINITIALIZE CONTROLS FROM THIS POINT (still from selection index, however)
                    InitializeCustomerComboBox()

                    ' Look up new ComboBox value corresponding to the new value in the datatable and set the selected index of the re-initialized ComboBox accordingly
                    ' If insertion failed, then revert selected back to lastSelected
                    Dim updatedItem As String = getRowValueWithKeyEquals(CustomerDbController.DbDataTable, "CLFA", "CustomerId", Convert.ToInt32(CustomerId_Textbox.Text)) ' Could also use datatable lookup to get CustomerId. Either should work.
                    If updatedItem <> Nothing Then
                        CustomerComboBox.SelectedIndex = CustomerComboBox.Items.IndexOf(updatedItem)
                    Else
                        CustomerComboBox.SelectedIndex = CustomerComboBox.Items.IndexOf(lastSelected)
                    End If


                    ' dataViewingControl values reinitialized, as well as dataControls hide/show in combobox text/selectedindex change event

                    ' 5.) MOVE UI OUT OF EDITING MODE
                    addButton.Enabled = True
                    cancelButton.Enabled = False
                    saveButton.Enabled = False
                    nav.EnableAll()
                    CustomerComboBox.Enabled = True

                ElseIf mode = "adding" Then

                    ' 1.) VALIDATE DATAEDITING CONTROLS
                    If Not controlsValid() Then Exit Sub

                    ' 2.) INSERT NEW ROW INTO DATABASE
                    If Not insertAll() Then
                        MessageBox.Show("Insert unsuccessful; Changes not saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    Else
                        MessageBox.Show("Successfully added " & LastName_Textbox.Text & ", " & FirstName_Textbox.Text & " @ " & Address_Textbox.Text & " to Customers")
                    End If

                    ' 3.) RELOAD DATATABLES FROM DATABASE
                    If Not loadCustomerDataTable() Then
                        MessageBox.Show("Loading updated information failed; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    ' 4.) REINITIALIZE CONTROLS (based on index of newly inserted value)
                    InitializeCustomerComboBox()

                    ' Changing index of main combobox will also initialize respective dataViewing control values


                    ' First, lookup most recent CustomerId added to the table
                    CRUD.ExecQuery("SELECT CustomerId FROM Customer WHERE CustomerId=(SELECT max(CustomerId) FROM Customer)")
                    Dim newCustomerId As Integer

                    If CRUD.DbDataTable.Rows.Count <> 0 And Not CRUD.HasException(True) Then

                        ' Get new CustomerId if query successful
                        newCustomerId = CRUD.DbDataTable.Rows(0)("CustomerId")
                        ' Get new ComboBox item from datatable using newly retrieved ID
                        Dim newItem As String = getRowValueWithKeyEquals(CustomerDbController.DbDataTable, "CLFA", "CustomerId", newCustomerId)

                        ' Set ComboBox accordingly after one final check
                        If newItem <> Nothing Then
                            CustomerComboBox.SelectedIndex = CustomerComboBox.Items.IndexOf(newItem)
                        Else
                            CustomerComboBox.SelectedIndex = CustomerComboBox.Items.IndexOf(lastSelected)
                        End If

                    Else
                        CustomerComboBox.SelectedIndex = lastSelected
                    End If


                    ' 5.) MOVE UI OUT OF Adding MODE
                    addButton.Enabled = True
                    cancelButton.Enabled = False
                    saveButton.Enabled = False
                    nav.EnableAll()
                    CustomerComboBox.Enabled = True

                End If

            Case DialogResult.No
                ' Continue making changes or cancel editing
        End Select


    End Sub

    Private Sub LastName_Textbox_TextChanged(sender As Object, e As EventArgs) Handles LastName_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        LastName_Textbox.ForeColor = DefaultForeColor
        FirstName_Textbox.ForeColor = DefaultForeColor
        Address_Textbox.ForeColor = DefaultForeColor

        If InitialCustomerValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub FirstName_Textbox_TextChanged(sender As Object, e As EventArgs) Handles FirstName_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        LastName_Textbox.ForeColor = DefaultForeColor
        FirstName_Textbox.ForeColor = DefaultForeColor
        Address_Textbox.ForeColor = DefaultForeColor

        If InitialCustomerValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub Address_Textbox_TextChanged(sender As Object, e As EventArgs) Handles Address_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        LastName_Textbox.ForeColor = DefaultForeColor
        FirstName_Textbox.ForeColor = DefaultForeColor
        Address_Textbox.ForeColor = DefaultForeColor

        If InitialCustomerValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private Sub ZipCode_ComboBox_KeyDown(sender As Object, e As KeyEventArgs) Handles ZipCode_ComboBox.KeyDown

        ' Allow certain keystrokes through here. Oftentimes, these will be common shortcuts
        If ((e.KeyCode = Keys.A And e.Control) Or (e.KeyCode = Keys.C And e.Control) Or (e.KeyCode = Keys.V And e.Control)) Then
            allowedKeystroke = True
        End If

    End Sub

    Private Sub ZipCode_ComboBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ZipCode_ComboBox.KeyPress

        ' If certain keystroke exceptions allowed throuhg, then skip input validation here
        If allowedKeystroke Then
            allowedKeystroke = False
            Exit Sub
        End If

        If Not zipCodeInputValid(ZipCode_ComboBox, e.KeyChar) Then
            e.KeyChar = Chr(0)
            e.Handled = True
        Else
            City_Textbox.Text = String.Empty
            State_Textbox.Text = String.Empty
        End If

    End Sub

    Private Sub ZipCode_ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ZipCode_ComboBox.SelectedIndexChanged, ZipCode_ComboBox.TextChanged

        If Not valuesInitialized Then Exit Sub

        ZipCode_ComboBox.ForeColor = DefaultForeColor

        ' If valid ZIP entered, then initialize controls that correspond to ZipCode value
        If validZipCode(ZipCode_ComboBox.Text, String.Empty) And valueExists("Zipcode", ZipCode_ComboBox.Text, ZipCodesDbController.DbDataTable) Then
            InitializeZipCodeDataEditingControls()
        End If

        If InitialCustomerValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private Sub HomePhone_Value_TextChanged(sender As Object, e As EventArgs) Handles HomePhone_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        HomePhone_Textbox.ForeColor = DefaultForeColor

        If InitialCustomerValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub WorkPhone_Textbox_TextChanged(sender As Object, e As EventArgs) Handles WorkPhone_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        WorkPhone_Textbox.ForeColor = DefaultForeColor

        If InitialCustomerValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub CellPhone1_Textbox_TextChanged(sender As Object, e As EventArgs) Handles CellPhone1_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        CellPhone1_Textbox.ForeColor = DefaultForeColor

        If InitialCustomerValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub CellPhone2_Textbox_TextChanged(sender As Object, e As EventArgs) Handles CellPhone2_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        CellPhone2_Textbox.ForeColor = DefaultForeColor

        If InitialCustomerValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    'Private Sub EmailAddress_Textbox_TextChanged(sender As Object, e As EventArgs) Handles EmailAddress_Textbox.TextChanged

    '    If Not valuesInitialized Then Exit Sub

    '    EmailAddress_Textbox.ForeColor = DefaultForeColor

    '    If InitialCustomerValues.CtrlValuesChanged() Then
    '        saveButton.Enabled = True
    '    Else
    '        saveButton.Enabled = False
    '    End If

    'End Sub

    Private Sub TaxExempt_CheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles TaxExempt_CheckBox.CheckedChanged

        If Not valuesInitialized Then Exit Sub

        TaxExempt_CheckBox.ForeColor = DefaultForeColor

        If InitialCustomerValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


End Class