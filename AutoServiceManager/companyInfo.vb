Public Class companyInfo

    ' Initialize new database control instances
    Private CompanyMasterDbController As New DbControl()
    Private ZipCodesDbController As New DbControl()

    ' Initialize instance(s) of initialValues class
    Private InitialValues As New InitialValues()

    'Temporary variable to keep track of whether form fully loaded or not
    Dim valuesInitialized As Boolean = False

    ' Row index variables used for DataTable lookups
    Dim cmRow As Integer
    Dim zcRow As Integer



    ' ***************** INITIALIZATION AND CONFIGURATION SUBS *****************


    ' Sub that will contain calls to all of the instances of the database controller class that loads data from the database into DataTables
    Private Sub loadDataTablesFromDatabase()

        CompanyMasterDbController.ExecQuery("SELECT cm.TaxRate, cm.ShopSupplyCharge, cm.CompanyName1, cm.CompanyName2, cm.Address1, cm.Address2, cm.ZipCode, cm.Phone1, cm.Phone2, cm.LaborRate FROM CompanyMaster cm")
        ZipCodesDbController.ExecQuery("SELECT * from ZipCodes zc")  ' Too slow for quick access, only load once at beginning (don't reload)

    End Sub


    Private Sub InitializeCompanyMasterControls()

        If CompanyMasterDbController.HasException(True) Then Exit Sub

        ' If no exceptions with the database controller and query,
        ' initialize all the dataEditingControls that have a value from ComanyMasterDbController.DbDataTable
        cmRow = 0
        initializeControlsFromRow(CompanyMasterDbController.DbDataTable, cmRow, "_", Me)

    End Sub


    Private Sub InitializeZipCodesControls()

        If ZipCodesDbController.HasException(True) Then Exit Sub

        Try

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

        LaborRate_Value.Text = FormatCurrency(LaborRate_Value.Text)
        TaxRate_Value.Text = FormatPercent(TaxRate_Value.Text)
        ShopSupplyCharge_Value.Text = FormatPercent(ShopSupplyCharge_Value.Text)

        LaborRate_Textbox.Text = String.Format("{0:0.00}", Convert.ToDouble(LaborRate_Textbox.Text))
        TaxRate_Textbox.Text = String.Format("{0:0.00}", Convert.ToDouble(TaxRate_Textbox.Text) * 100)
        ShopSupplyCharge_Textbox.Text = String.Format("{0:0.00}", Convert.ToDouble(ShopSupplyCharge_Textbox.Text) * 100)

    End Sub




    ' **************** VALIDATION SUBS ****************


    ' Function that
    Private Function controlsValid() As Boolean

        Dim errorMessage As String = String.Empty
        ' Call a function to validate input value in every control that must be validated
        ' If one of the validation functions encounters an error, it will append a particular error message tothe errorMessage string
        '       additionally, each function will set its respective control's background color to misty-red if error there
        '       IDEA: set text of tooltip to error message until valid
        ' Once reach end of function, if errorMessage isn't empty, this means error(s) were encountered, and inputs must be fixed

        ' ZipCode_Combo box validation
        ' Call zip code validation function on ZipCode_Combobox here


    End Function




    Private Sub companyInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Dynamically position elements on load.
        companyInfoLabel.Left = (Me.ClientSize.Width / 2) - (companyInfoLabel.Width / 2)

        ' Load datatables from database
        loadDataTablesFromDatabase()

        ' SETUP CONTROLS HERE
        ZipCode_ComboBox.DataSource = ZipCodesDbController.DbDataTable      ' ZipCode_ComboBox's datasource is from a separate query, but its initial selectedValue is set from CompanyMasterDataTable
        ZipCode_ComboBox.ValueMember = "Zipcode"
        ZipCode_ComboBox.DisplayMember = "Zipcode"


        ' INITIALIZE + FORMAT CONTROL VALUES
        valuesInitialized = False

        ' Initialize all control values
        InitializeAll()
        ' Formatting + additional configuration here
        addFormatting()
        ' store initial control values
        InitialValues.SetInitialValues(getAllControlsWithTag("dataEditingControl"))

        valuesInitialized = True


    End Sub




    ' **************** CONTROL SUBS ****************


    Private Sub editButton_Click(sender As Object, e As EventArgs) Handles editButton.Click

        ' Enable cancelButton and disable editButton
        cancelButton.Enabled = True
        editButton.Enabled = False
        'navigationPlaceholderButton.Enabled = False

        ' Disable all navigation controls while editing
        showHide(getAllControlsWithTag("navigation"), 0)
        ' disable/enable the dataViewingControls and dataEditingControls, respectively
        showHide(getAllControlsWithTag("dataViewingControl"), 0)
        showHide(getAllControlsWithTag("dataEditingControl"), 1)

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
                    addFormatting()
                    valuesInitialized = True


                    ' Disable all editing controls
                    cancelButton.Enabled = False
                    saveButton.Enabled = False
                    ' re-enable other hidden form controls
                    editButton.Enabled = True
                    ' re-enable navigation controls
                    showHide(getAllControlsWithTag("navigation"), 1)
                    ' enable/disable the dataViewingControls and dataEditingControls, respectively
                    showHide(getAllControlsWithTag("dataViewingControl"), 1)
                    showHide(getAllControlsWithTag("dataEditingControl"), 0)

                Case DialogResult.No

            End Select

        Else

            ' Disable all editing controls
            cancelButton.Enabled = False
            saveButton.Enabled = False
            ' re-enable other hidden form controls
            editButton.Enabled = True
            ' re-enable navigation controls
            showHide(getAllControlsWithTag("navigation"), 1)
            ' enable/disable the dataViewingControls and dataEditingControls, respectively
            showHide(getAllControlsWithTag("dataViewingControl"), 1)
            showHide(getAllControlsWithTag("dataEditingControl"), 0)

        End If

    End Sub

    Private Sub saveButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click

        Dim decision As DialogResult = MessageBox.Show("Save Changes?", "Confirm Changes", MessageBoxButtons.YesNo)

        Select Case decision
            Case DialogResult.Yes

                ' 1.) Write changes to database
                ' 2.) Switch back to labels with updated data from database (reload the form essentially)
                ' 3.) Go back to showing edit button and navigation controls


                ' INITIALIZE + FORMAT CONTROL VALUES
                valuesInitialized = False
                InitializeAll()
                addFormatting()
                ' store new initial control values
                InitialValues.SetInitialValues(getAllControlsWithTag("dataEditingControl"))
                valuesInitialized = True


                ' Disable all editing controls
                cancelButton.Enabled = False
                saveButton.Enabled = False
                ' re-enable other hidden form controls
                editButton.Enabled = True
                ' re-enable navigation controls
                showHide(getAllControlsWithTag("navigation"), 1)

                ' show updated dataViewingControls and hide dataEditingControls
                showHide(getAllControlsWithTag("dataViewingControl"), 1)
                showHide(getAllControlsWithTag("dataEditingControl"), 0)

            Case DialogResult.No
                ' Continue making changes or cancel editing

        End Select

    End Sub


    ' ************************ dataEditingControls TEXTBOX EVENT HANDLERS ************************


    Private Sub CompanyName1_Textbox_TextChanged(sender As Object, e As EventArgs) Handles CompanyName1_Textbox.TextChanged

        ' Ensure that all editing control values have been initialized before anything else (so events on form load don't have any effect)
        If Not valuesInitialized Then Exit Sub

        If editingControlsChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub CompanyName2_Textbox_TextChanged(sender As Object, e As EventArgs) Handles CompanyName2_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        If editingControlsChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub Address1_Textbox_TextChanged(sender As Object, e As EventArgs) Handles Address1_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        If editingControlsChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub Address2_Textbox_TextChanged(sender As Object, e As EventArgs) Handles Address2_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        If editingControlsChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub ZipCode_Textbox_TextChanged(sender As Object, e As EventArgs)

        If Not valuesInitialized Then Exit Sub

        If editingControlsChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private Sub Phone1_Textbox_TextChanged(sender As Object, e As EventArgs) Handles Phone1_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        If editingControlsChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private Sub Phone2_Textbox_TextChanged(sender As Object, e As EventArgs) Handles Phone2_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        If editingControlsChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private validTaxRate As Boolean = False
    ' Ensures that shortcuts are still available to user
    Private Sub TaxRate_Textbox_KeyDown(sender As Object, e As KeyEventArgs) Handles TaxRate_Textbox.KeyDown

        ' Check to see ctrl+A, ctrl+C, or ctrl+V were used. If so, don't worry about checking which Keys Pressed
        If ((e.KeyCode = Keys.A And e.Control) Or (e.KeyCode = Keys.C And e.Control) Or (e.KeyCode = Keys.V And e.Control)) Then
            validTaxRate = True
        End If

    End Sub

    Private Sub TaxRate_Textbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TaxRate_Textbox.KeyPress

        ' INPUT HANDLING
        If validTaxRate Then
            validTaxRate = False
            Exit Sub
        End If

        If Not percentInputValid(TaxRate_Textbox, e.KeyChar) Then
            e.KeyChar = Chr(0)
            e.Handled = True
        End If

    End Sub

    Private Sub TaxRate_Textbox_TextChanged(sender As Object, e As EventArgs) Handles TaxRate_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

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


    Dim validShopSupplyCharge As Boolean = False
    Private Sub ShopSupplyCharge_Textbox_KeyDown(sender As Object, e As KeyEventArgs) Handles ShopSupplyCharge_Textbox.KeyDown

        ' Check to see ctrl+A, ctrl+C, or ctrl+V were used. If so, don't worry about checking which Keys Pressed
        If ((e.KeyCode = Keys.A And e.Control) Or (e.KeyCode = Keys.C And e.Control) Or (e.KeyCode = Keys.V And e.Control)) Then
            validShopSupplyCharge = True
        End If

    End Sub

    Private Sub ShopSupplyCharge_Textbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ShopSupplyCharge_Textbox.KeyPress

        ' INPUT HANDLING
        If validShopSupplyCharge Then
            validShopSupplyCharge = False
            Exit Sub
        End If

        If Not percentInputValid(ShopSupplyCharge_Textbox, e.KeyChar) Then
            e.KeyChar = Chr(0)
            e.Handled = True
        End If

    End Sub

    Private Sub ShopSupplyCharge_Textbox_TextChanged(sender As Object, e As EventArgs) Handles ShopSupplyCharge_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

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


    Private validLaborRate As Boolean = False
    Private Sub LaborRate_Textbox_KeyDown(sender As Object, e As KeyEventArgs) Handles LaborRate_Textbox.KeyDown

        ' Check to see ctrl+A, ctrl+C, or ctrl+V were used. If so, don't worry about checking which Keys Pressed
        If ((e.KeyCode = Keys.A And e.Control) Or (e.KeyCode = Keys.C And e.Control) Or (e.KeyCode = Keys.V And e.Control)) Then
            validLaborRate = True
        End If

    End Sub

    Private Sub LaborRate_Textbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles LaborRate_Textbox.KeyPress

        ' INPUT HANDLING
        If validLaborRate Then
            validLaborRate = False
            Exit Sub
        End If

        If Not percentInputValid(LaborRate_Textbox, e.KeyChar) Then
            e.KeyChar = Chr(0)
            e.Handled = True
        End If

    End Sub


    Private Sub LaborRate_Textbox_TextChanged(sender As Object, e As EventArgs) Handles LaborRate_Textbox.TextChanged, LaborRate_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

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


    Private Sub navigationPlaceholderButton_Click(sender As Object, e As EventArgs) Handles navigationPlaceholderButton.Click
        Me.Close()
    End Sub


    Private Sub ZipCode_ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ZipCode_ComboBox.SelectedIndexChanged, ZipCode_ComboBox.TextChanged

        If Not valuesInitialized Then Exit Sub

        If editingControlsChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

        If ZipCode_ComboBox.Text.Length = 5 Then    ' Basic Validation  (replace with function that handles ZipCode validation)
            For Each row In ZipCodesDbController.DbDataTable.Rows
                If ZipCode_ComboBox.Text = row("Zipcode") Then

                    ' If in the table, then update city and state accordingly
                    InitializeZipCodesControls()
                    Exit For

                End If
            Next
        ElseIf InStr(ZipCode_ComboBox.Text, "-") <> 0 And ZipCode_ComboBox.Text.Length <= 10 Then
            For Each row In ZipCodesDbController.DbDataTable.Rows
                If ZipCode_ComboBox.Text.Split("-")(0) = row("Zipcode") Then

                    ' If in the table, then update city and state accordingly
                    InitializeZipCodesControls()
                    Exit For

                End If
            Next
        Else
            city_Textbox.Text = String.Empty
            State_Textbox.Text = String.Empty
        End If

    End Sub


End Class