Imports System.ComponentModel

Public Class companyInfo

    ' Initialize new database control instances
    Private CompanyMasterDbController As New DbControl()
    Private ZipCodesDbController As New DbControl()
    ' New Database control instance for updating various tables
    Private updateController As New DbControl()

    ' Initialize new lists to store certain row values of datatables
    Private zipCodesList As List(Of Object)

    ' Initialize instance(s) of initialValues class
    Private InitialValues As New InitialValues()

    'Variable to keep track of whether form fully loaded or not
    Private valuesInitialized As Boolean = False

    ' Row index variables used for DataTable lookups
    Private cmRow As Integer
    Private zcRow As Integer

    ' Variable that allows certain keystrokes through restricted fields
    Private allowedKeystroke As Boolean = False


    ' ***************** INITIALIZATION AND CONFIGURATION SUBS *****************


    ' Sub that will contain calls to all of the instances of the database controller class that loads data from the database into DataTables
    Private Function loadDataTablesFromDatabase() As Boolean

        CompanyMasterDbController.ExecQuery("SELECT cm.TaxRate, cm.ShopSupplyCharge, cm.CompanyName1, cm.CompanyName2, cm.Address1, cm.Address2, cm.ZipCode, cm.Phone1, cm.Phone2, cm.LaborRate FROM CompanyMaster cm")
        If CompanyMasterDbController.HasException() Then Return False
        ZipCodesDbController.ExecQuery("SELECT * from ZipCodes zc")  ' Too slow for quick access, only load once at beginning (don't reload)
        If ZipCodesDbController.HasException() Then Return False

        ' Also, populate respective lists with data
        zipCodesList = getListFromDataTable(ZipCodesDbController.DbDataTable, "Zipcode")

        Return True

    End Function


    Private Sub InitializeCompanyMasterControls()

        'If CompanyMasterDbController.HasException() Then Exit Sub

        ' If no exceptions with the database controller and query,
        ' initialize all the dataEditingControls that have a value from ComanyMasterDbController.DbDataTable
        cmRow = 0
        initializeControlsFromRow(CompanyMasterDbController.DbDataTable, cmRow, "_", Me)

    End Sub


    Private Sub InitializeZipCodesControls()

        'If ZipCodesDbController.HasException() Then Exit Sub

        Try

            ' Ensures we only lookup base of zipcode (extensions not present in db)
            Dim zipCode As String = ZipCode_ComboBox.Text.Split("-")(0)
            Dim zipRow As DataRow = ZipCodesDbController.DbDataTable.Select("Zipcode = '" & zipCode & "'")(0)
            zcRow = ZipCodesDbController.DbDataTable.Rows.IndexOf(zipRow)

            initializeControlsFromRow(ZipCodesDbController.DbDataTable, zcRow, "_", Me)

        Catch ex As Exception

            Console.WriteLine(ex.Message)

        End Try

    End Sub


    ' Sub that calls all individual initialization subs in one (These can be used individually if desired
    Private Sub InitializeAll()

        ' Automated initializations
        InitializeCompanyMasterControls()
        InitializeZipCodesControls()

        ' Then, add formatting
        addFormatting()
        ' Set forecolor if not already initially default
        setForeColor(getAllControlsWithTag("dataEditingControl", Me), DefaultForeColor)

    End Sub


    ' Function that calls editingControlChanged for each dataTable and returns the result.
    ' Simplifies call from control event handlers
    ' PROBABLY WILL BE REMOVED; NOT NECESSARY
    Private Function editingControlsChanged() As Boolean

        If InitialValues.CtrlValuesChanged() Then Return True
        Return False

    End Function


    ' Sub that will call formatting functions to the add certain formats to initialized controls (i.e. phone numbers, currency, etc.).
    Private Sub addFormatting()

        ' Formatting for labels that contain values from DataTable
        If Not String.IsNullOrEmpty(Phone1_Value.Text) Then Phone1_Value.Text = String.Format("{0:(000) 000-0000}", Long.Parse(CompanyMasterDbController.DbDataTable.Rows(cmRow)("Phone1")))
        If Not String.IsNullOrEmpty(Phone2_Value.Text) Then Phone2_Value.Text = String.Format("{0:(000) 000-0000}", Long.Parse(CompanyMasterDbController.DbDataTable.Rows(cmRow)("Phone2")))

        ' Formatting for DataEditingControls
        LaborRate_Value.Text = FormatCurrency(CompanyMasterDbController.DbDataTable.Rows(cmRow)("LaborRate"))
        TaxRate_Value.Text = FormatPercent(CompanyMasterDbController.DbDataTable.Rows(cmRow)("TaxRate"))
        ShopSupplyCharge_Value.Text = FormatPercent(CompanyMasterDbController.DbDataTable.Rows(cmRow)("ShopSupplyCharge"))

        LaborRate_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(CompanyMasterDbController.DbDataTable.Rows(cmRow)("LaborRate")))
        TaxRate_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(CompanyMasterDbController.DbDataTable.Rows(cmRow)("TaxRate")) * 100)
        ShopSupplyCharge_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(CompanyMasterDbController.DbDataTable.Rows(cmRow)("ShopSupplyCharge")) * 100)
        ' Switched from formatting values based on their .text value, and instead from their raw value from the dataTable

    End Sub


    ' Sub that will remove all necessarry formatting that was added before updating values
    Private Sub stripFormatting()

        TaxRate_Textbox.Text = (Convert.ToDecimal(TaxRate_Textbox.Text) / 100).ToString()
        ShopSupplyCharge_Textbox.Text = (Convert.ToDecimal(ShopSupplyCharge_Textbox.Text) / 100).ToString()

    End Sub


    ' Function that makes updateTable calls for all relevant DataTables that need updated based on changes
    Private Function updateAll() As Boolean


        ' In order to accurately reflect the values in TaxRate and Shop Supply Charge in the database, we must divide their values by 100
        Dim TaxRate As Decimal = Convert.ToDecimal(TaxRate_Textbox.Text) / 100
        Dim ShopSupplyCharge As Decimal = Convert.ToDecimal(ShopSupplyCharge_Textbox.Text) / 100

        ' List TaxRate and ShopSupplyCharge as excluded, and then add their values to the query via AdditionalValue list
        Dim excludedControls As New List(Of Control) From {TaxRate_Textbox, ShopSupplyCharge_Textbox}
        Dim additionalValues As New List(Of AdditionalValue) From {New AdditionalValue("TaxRate", GetType(Double), TaxRate), New AdditionalValue("ShopSupplyCharge", GetType(Double), ShopSupplyCharge)}

        ' Then, update all relevant tables that COUDLD have experienced changes
        updateTable(updateController, CompanyMasterDbController.DbDataTable, "CompanyMaster", 1, 1, "_", "dataEditingControl", Me, excludedControls, additionalValues)
        ' Then, return exception status of updateController. Return false andfrom this function and reformat if there is an exception thrown (do this after each call).
        If updateController.HasException() Then Return False

        ' Otherwise, return true
        Return True

    End Function



    ' **************** VALIDATION SUBS ****************


    ' Sub that runs validation for all form controls. Also handles error reporting
    Private Function controlsValid() As Boolean

        Dim errorMessage As String = String.Empty

        ' ********
        ' Use "Required" parameter to control whether or not a Null string value will cause an error to be reported

        ' Company Name 1 (REQUIRED)
        If Not isValidLength("Company Name 1", True, CompanyName1_Textbox.Text, 50, errorMessage) Then CompanyName1_Textbox.ForeColor = Color.Red
        ' Company Name 2
        If Not isValidLength("Company Name 2", False, CompanyName2_Textbox.Text, 50, errorMessage) Then CompanyName2_Textbox.ForeColor = Color.Red
        ' Address 1 (REQUIRED)
        If Not isValidLength("Address 1", True, Address1_Textbox.Text, 50, errorMessage) Then Address1_Textbox.ForeColor = Color.Red
        ' Address 2
        If Not isValidLength("Address 2", False, Address2_Textbox.Text, 50, errorMessage) Then Address2_Textbox.ForeColor = Color.Red

        ' Phone 1 (REQUIRED)
        If Not validPhone("Phone 1", True, Phone1_Textbox.Text, errorMessage) Then Phone1_Textbox.ForeColor = Color.Red
        ' Phone 2 (OPTIONAL)
        If Not validPhone("Phone 2", False, Phone2_Textbox.Text, errorMessage) Then Phone2_Textbox.ForeColor = Color.Red

        ' ZipCode_Combobox validation
        If Not validZipCode(ZipCode_ComboBox.Text, errorMessage) Then
            ZipCode_ComboBox.ForeColor = Color.Red
        ElseIf zipCodesList.BinarySearch(ZipCode_ComboBox.Text.Split("-")(0)) < 0 Then
            errorMessage += "ERROR: ZIP Code does not exist" & vbNewLine
            ZipCode_ComboBox.ForeColor = Color.Red
        End If

        ' Tax Rate percent
        If Not validPercent("Tax Rate", True, TaxRate_Textbox.Text, errorMessage) Then TaxRate_Textbox.ForeColor = Color.Red
        ' Shop Supply Charge percent
        If Not validPercent("Shop Supply Charge", True, ShopSupplyCharge_Textbox.Text, errorMessage) Then ShopSupplyCharge_Textbox.ForeColor = Color.Red
        ' Labor Rate decimal
        If Not validCurrency("Labor Rate", True, LaborRate_Textbox.Text, errorMessage) Then LaborRate_Textbox.ForeColor = Color.Red



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

        ' TEST DATABASE CONNECTION FIRST
        If Not checkDbConn() Then
            MessageBox.Show("Failed to connect to database; Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Load datatables from database
        If Not loadDataTablesFromDatabase() Then
            MessageBox.Show("Failed to connect to database; Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' SETUP CONTROLS HERE
        ZipCode_ComboBox.DataSource = ZipCodesDbController.DbDataTable      ' ZipCode_ComboBox's datasource is from a separate query, but its initial selectedValue is set from CompanyMasterDataTable
        ZipCode_ComboBox.ValueMember = "Zipcode"
        ZipCode_ComboBox.DisplayMember = "Zipcode"


        ' INITIALIZE + FORMAT CONTROL VALUES
        valuesInitialized = False

        ' Initialize all control values
        InitializeAll()
        ' store initial control values
        InitialValues.SetInitialValues(getAllControlsWithTag("dataEditingControl", Me))

        valuesInitialized = True

    End Sub


    Private Sub companyInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' PRE-DRAW PRE-LOADED (Preliminary) COMBOBOXES. 
        ' This way, we don't have to wait for them to draw on first edit/add

        ZipCode_ComboBox.Visible = True
        ZipCode_ComboBox.Visible = False

    End Sub




    ' **************** CONTROL SUBS ****************


    Private Sub editButton_Click(sender As Object, e As EventArgs) Handles editButton.Click

        ' Enable cancelButton and disable editButton
        cancelButton.Enabled = True
        editButton.Enabled = False
        nav.DisableAll()
        ' disable/enable the dataViewingControls and dataEditingControls, respectively
        showHide(getAllControlsWithTag("dataViewingControl", Me), 0)
        showHide(getAllControlsWithTag("dataEditingControl", Me), 1)

    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click

        ' Ensure that any changes made are saved
        If editingControlsChanged() Then

            Dim decision As DialogResult = MessageBox.Show("Cancel without saving changes?", "Confirm", MessageBoxButtons.YesNo)

            Select Case decision
                Case DialogResult.Yes

                    ' REINITIALIZE ALL CONTROL VALUES
                    valuesInitialized = False
                    InitializeAll()
                    valuesInitialized = True


                    ' Disable all editing controls
                    cancelButton.Enabled = False
                    saveButton.Enabled = False
                    ' re-enable other hidden form controls
                    editButton.Enabled = True
                    ' re-enable navigation controls
                    nav.EnableAll()
                    ' enable/disable the dataViewingControls and dataEditingControls, respectively
                    showHide(getAllControlsWithTag("dataViewingControl", Me), 1)
                    showHide(getAllControlsWithTag("dataEditingControl", Me), 0)

                Case DialogResult.No

            End Select

        Else

            ' Disable all editing controls
            cancelButton.Enabled = False
            saveButton.Enabled = False
            ' re-enable other hidden form controls
            editButton.Enabled = True
            ' re-enable navigation controls
            nav.EnableAll()
            ' enable/disable the dataViewingControls and dataEditingControls, respectively
            showHide(getAllControlsWithTag("dataViewingControl", Me), 1)
            showHide(getAllControlsWithTag("dataEditingControl", Me), 0)

        End If

    End Sub

    Private Sub saveButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click

        Dim decision As DialogResult = MessageBox.Show("Save Changes?", "Confirm Changes", MessageBoxButtons.YesNo)

        Select Case decision
            Case DialogResult.Yes

                ' 1.) VALIDATE CONTROLS. IF NOT VALID, DO NOT CONTINUE (other actions may be taken here if desired)
                If Not controlsValid() Then Exit Sub

                ' 2.) IF VALIDATION PASSED, UPDATE DATATABLE(s) VALUES, THEN UPDATE DATABASE
                If Not updateAll() Then
                    MessageBox.Show("Update unsuccessful; Changes not saved")
                Else
                    MessageBox.Show("Successfully updated Company Information")
                End If

                ' 3.) IF UPDATE SUCCESSFUL, THEN RELOAD DATABASE TABLES INTO RESPECTIVE DATABLES
                If Not loadDataTablesFromDatabase() Then
                    MessageBox.Show("Loading updated information failed; Old values will be reflected. Please restart and try again")
                End If

                ' 4.) IF RELOAD SUCCESSFUL, THEN REINITIALIZE ALL CONTROLS
                valuesInitialized = False
                InitializeAll()
                InitialValues.SetInitialValues(getAllControlsWithTag("dataEditingControl", Me))
                valuesInitialized = True

                ' 5.) Move UI out of editing mode

                ' Disable all editing controls
                cancelButton.Enabled = False
                saveButton.Enabled = False
                ' re-enable other hidden form controls
                editButton.Enabled = True
                ' re-enable navigation controls
                nav.EnableAll()

                ' show updated dataViewingControls and hide dataEditingControls
                showHide(getAllControlsWithTag("dataViewingControl", Me), 1)
                showHide(getAllControlsWithTag("dataEditingControl", Me), 0)

            Case DialogResult.No
                ' Continue making changes or cancel editing

        End Select

    End Sub


    ' ************************ dataEditingControls TEXTBOX EVENT HANDLERS ************************


    Private Sub CompanyName1_Textbox_TextChanged(sender As Object, e As EventArgs) Handles CompanyName1_Textbox.TextChanged

        ' Ensure that all editing control values have been initialized before anything else (so events on form load don't have any effect)
        If Not valuesInitialized Then Exit Sub

        CompanyName1_Textbox.ForeColor = DefaultForeColor

        If editingControlsChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub CompanyName2_Textbox_TextChanged(sender As Object, e As EventArgs) Handles CompanyName2_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        CompanyName2_Textbox.ForeColor = DefaultForeColor

        If editingControlsChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub Address1_Textbox_TextChanged(sender As Object, e As EventArgs) Handles Address1_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        Address1_Textbox.ForeColor = DefaultForeColor

        If editingControlsChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub Address2_Textbox_TextChanged(sender As Object, e As EventArgs) Handles Address2_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        Address2_Textbox.ForeColor = DefaultForeColor

        If editingControlsChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private Sub Phone1_Textbox_TextChanged(sender As Object, e As EventArgs) Handles Phone1_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        Phone1_Textbox.ForeColor = DefaultForeColor

        If editingControlsChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private Sub Phone2_Textbox_TextChanged(sender As Object, e As EventArgs) Handles Phone2_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        Phone2_Textbox.ForeColor = DefaultForeColor

        If editingControlsChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    ' Ensures that shortcuts are still available to user
    Private Sub TaxRate_Textbox_KeyDown(sender As Object, e As KeyEventArgs) Handles TaxRate_Textbox.KeyDown

        ' Check to see ctrl+A, ctrl+C, or ctrl+V were used. If so, don't worry about checking which Keys Pressed
        If ((e.KeyCode = Keys.A And e.Control) Or (e.KeyCode = Keys.C And e.Control) Or (e.KeyCode = Keys.V And e.Control)) Then
            allowedKeystroke = True
        End If

    End Sub

    Private Sub TaxRate_Textbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TaxRate_Textbox.KeyPress

        ' If certain keystroke exceptions allowed throuhg, then skip input validation here
        If allowedKeystroke Then
            allowedKeystroke = False
            Exit Sub
        End If

        If Not percentInputValid(TaxRate_Textbox, e.KeyChar) Then
            e.KeyChar = Chr(0)
            e.Handled = True
        End If

    End Sub

    Private Sub TaxRate_Textbox_TextChanged(sender As Object, e As EventArgs) Handles TaxRate_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        TaxRate_Textbox.ForeColor = DefaultForeColor

        ' TEMPORARY VALIDATION FOR PASTING VALUES. REVIEW WITH TONI
        Dim lastValidIndex As Integer = allValidChars(TaxRate_Textbox.Text, "1234567890.")
        If lastValidIndex <> -1 Then
            TaxRate_Textbox.Text = TaxRate_Textbox.Text.Substring(0, lastValidIndex)
            TaxRate_Textbox.SelectionStart = lastValidIndex
        End If

        If editingControlsChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private Sub ShopSupplyCharge_Textbox_KeyDown(sender As Object, e As KeyEventArgs) Handles ShopSupplyCharge_Textbox.KeyDown

        ' Check to see ctrl+A, ctrl+C, or ctrl+V were used. If so, don't worry about checking which Keys Pressed
        If ((e.KeyCode = Keys.A And e.Control) Or (e.KeyCode = Keys.C And e.Control) Or (e.KeyCode = Keys.V And e.Control)) Then
            allowedKeystroke = True
        End If

    End Sub

    Private Sub ShopSupplyCharge_Textbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ShopSupplyCharge_Textbox.KeyPress

        ' If certain keystroke exceptions allowed throuhg, then skip input validation here
        If allowedKeystroke Then
            allowedKeystroke = False
            Exit Sub
        End If

        If Not percentInputValid(ShopSupplyCharge_Textbox, e.KeyChar) Then
            e.KeyChar = Chr(0)
            e.Handled = True
        End If

    End Sub

    Private Sub ShopSupplyCharge_Textbox_TextChanged(sender As Object, e As EventArgs) Handles ShopSupplyCharge_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        ShopSupplyCharge_Textbox.ForeColor = DefaultForeColor

        ' TEMPORARY VALIDATION FOR PASTING VALUES. REVIEW WITH TONI
        Dim lastValidIndex As Integer = allValidChars(ShopSupplyCharge_Textbox.Text, "1234567890.")
        If lastValidIndex <> -1 Then
            ShopSupplyCharge_Textbox.Text = ShopSupplyCharge_Textbox.Text.Substring(0, lastValidIndex)
            ShopSupplyCharge_Textbox.SelectionStart = lastValidIndex
        End If

        If editingControlsChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private Sub LaborRate_Textbox_KeyDown(sender As Object, e As KeyEventArgs) Handles LaborRate_Textbox.KeyDown

        ' Check to see ctrl+A, ctrl+C, or ctrl+V were used. If so, don't worry about checking which Keys Pressed
        If ((e.KeyCode = Keys.A And e.Control) Or (e.KeyCode = Keys.C And e.Control) Or (e.KeyCode = Keys.V And e.Control)) Then
            allowedKeystroke = True
        End If

    End Sub

    Private Sub LaborRate_Textbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles LaborRate_Textbox.KeyPress

        ' If certain keystroke exceptions allowed throuhg, then skip input validation here
        If allowedKeystroke Then
            allowedKeystroke = False
            Exit Sub
        End If

        If Not currencyInputValid(LaborRate_Textbox, e.KeyChar) Then
            e.KeyChar = Chr(0)
            e.Handled = True
        End If

    End Sub


    Private Sub LaborRate_Textbox_TextChanged(sender As Object, e As EventArgs) Handles LaborRate_Textbox.TextChanged, LaborRate_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        LaborRate_Textbox.ForeColor = DefaultForeColor

        ' Handles pasting in invalid values/strings
        Dim lastValidIndex As Integer = allValidChars(LaborRate_Textbox.Text, "1234567890.")
        If lastValidIndex <> -1 Then
            LaborRate_Textbox.Text = LaborRate_Textbox.Text.Substring(0, lastValidIndex)
            LaborRate_Textbox.SelectionStart = lastValidIndex
        End If

        If editingControlsChanged() Then
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
        End If

    End Sub

    Private Sub ZipCode_ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ZipCode_ComboBox.SelectedIndexChanged, ZipCode_ComboBox.TextChanged

        If Not valuesInitialized Then Exit Sub

        If editingControlsChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

        ' If color was changed due to invalid value, reset now.
        ZipCode_ComboBox.ForeColor = DefaultForeColor

        ' Check if valid and lookup
        If ZipCode_ComboBox.Text.Length >= 5 And ZipCode_ComboBox.Text.Length <= 10 And zipCodesList.BinarySearch(ZipCode_ComboBox.Text.Split("-")(0)) >= 0 Then
            InitializeZipCodesControls()
        Else
            city_Textbox.Text = String.Empty
            State_Textbox.Text = String.Empty
        End If

    End Sub



    Private Sub companyInfo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        ' Check if editing/adding, and if editing/adding, check if control values changed
        If CompanyName1_Textbox.Visible And InitialValues.CtrlValuesChanged() Then

            Dim decision As DialogResult = MessageBox.Show("Exit without saving changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If decision = DialogResult.No Then
                e.Cancel = True
                Exit Sub
            End If

        End If

    End Sub


End Class