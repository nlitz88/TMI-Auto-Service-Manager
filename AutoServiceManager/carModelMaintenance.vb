﻿Public Class carModelMaintenance

    ' New Database control instances for manufacturers and car models datatables
    Private AutoMakeDbController As New DbControl()
    Private CarModelDbController As New DbControl()
    ' New Database control instance for updating, inserting, and deleting
    Private CRUD As New DbControl()

    ' Initialize new lists to store certain row values of datatables (easily sorted and BINARY SEARCHED FOR SPEED)
    Private CarModelList As List(Of Object)

    ' Initialize instance(s) of initialValues class
    Private InitialCarModelValues As New InitialValues()

    'Variable to keep track of whether form fully loaded or not
    Private valuesInitialized As Boolean = True

    ' Row index variables used for DataTable lookups
    Private AutoMakeRow As Integer
    Private lastSelectedAutoMake As String
    Private CarModelRow As Integer
    Private lastSelectedCarModel As String

    ' Keeps track of whether or not user in "editing" or "adding" mode
    Private mode As String

    ' Variable that allows certain keystrokes through restricted fields
    Private allowedKeystroke As Boolean = False




    ' ***************** INITIALIZATION AND CONFIGURATION SUBS *****************


    ' Loads datatable from AutoManufacturers database table
    Private Function loadAutoMakeDatatable() As Boolean

        AutoMakeDbController.ExecQuery("SELECT am.AutoMake FROM AutoManufacturers am ORDER BY am.AutoMake ASC")
        If AutoMakeDbController.HasException() Then Return False

        Return True

    End Function

    ' Sub that initializes AutoMakeComboBox
    Private Sub InitializeAutoMakeComboBox()

        ' SETUP/INITIALIZE CARMODEL COMBOBOX
        AutoMakeComboBox.Items.Clear()
        AutoMakeComboBox.Items.Add("Select One")
        For Each Row In AutoMakeDbController.DbDataTable.Rows
            AutoMakeComboBox.Items.Add(Row("AutoMake"))
        Next

    End Sub


    ' Loads datatable from CarModels database table
    Private Function loadCarModelDataTable() As Boolean

        CarModelDbController.AddParams("@automake", "%" & AutoMakeComboBox.Text & "%")
        CarModelDbController.ExecQuery("SELECT cm.AutoMake, cm.AutoModel FROM CarModels cm WHERE cm.AutoMake LIKE @automake ORDER BY cm.AutoModel ASC")
        If CarModelDbController.HasException() Then Return False

        ' Also, populate respective list with data
        CarModelList = getListFromDataTable(CarModelDbController.DbDataTable, "AutoModel")
        For i As Integer = 0 To CarModelList.Count - 1
            CarModelList(i) = CarModelList(i).ToString().ToLower()
        Next

        Return True

    End Function


    ' Sub that initializes CarModelComboBox after valid AutoMakeComboBox selection has been made
    Private Sub InitializeCarModelComboBox()

        ' SETUP/INITIALIZE CARMODEL COMBOBOX
        CarModelComboBox.Items.Clear()
        CarModelComboBox.Items.Add("Select One")
        For Each row In CarModelDbController.DbDataTable.Rows
            CarModelComboBox.Items.Add(row("AutoModel"))
        Next

    End Sub


    ' Sub that initializes all dataEditingcontrols corresponding with values from CarModels datatable
    Private Sub InitializeCarModelDataEditingControls()

        initializeControlsFromRow(CarModelDbController.DbDataTable, CarModelRow, "dataEditingControl", "_", Me)
        ' Set forecolor if not already initially default
        setForeColor(getAllControlsWithTag("dataEditingControl", Me), DefaultForeColor)

    End Sub

    ' Sub that initializes all dataEditingcontrols corresponding with values from the CarModels datatable
    Private Sub InitializeCarModelDataViewingControls()

        initializeControlsFromRow(CarModelDbController.DbDataTable, CarModelRow, "dataViewingControl", "_", Me)

    End Sub


    ' Function that makes custom updates to database tables
    Private Function updateAll() As Boolean

        ' First, remove any formatting that was added (specific to the controls on this form)
        ' stripDataEditingControlsFormatting()

        CRUD.AddParams("@newAutoModel", AutoModel_Textbox.Text)
        ' The initial AutoModel value (in combination with the AutoMake) acts as our key for the query in this case
        CRUD.AddParams("@autoMake", AutoMakeComboBox.Text)
        CRUD.AddParams("@initialAutoModel", CarModelDbController.DbDataTable.Rows(CarModelRow)("AutoModel"))
        CRUD.ExecQuery("UPDATE CarModels SET AutoModel=@newAutoModel WHERE AutoMake=@autoMake AND AutoModel=@initialAutoModel")

        ' Then, return exception status of CRUD controller. Do this after each call
        If CRUD.HasException() Then Return False

        ' Otherwise, return true
        Return True

    End Function


    ' Function that makes insertRow calls for all relevant DataTables
    Private Function insertAll() As Boolean

        ' First, remove any formatting that was added (specific to the controls on this form)
        ' stripDataEditingControlsFormatting()

        CRUD.AddParams("@autoMake", AutoMakeComboBox.Text)
        CRUD.AddParams("@autoModel", AutoModel_Textbox.Text)
        CRUD.ExecQuery("INSERT INTO CarModels (AutoMake, AutoModel) VALUES (@autoMake, @autoModel)")

        ' Then, return exception status of CRUD controller. Do this after each call
        If CRUD.HasException() Then Return False

        ' Otherwise, return true
        Return True

    End Function


    ' Function that makes deleteRow calls for all relevant DataTables
    Private Function deleteAll() As Boolean

        ' The initial AutoModel value (in combination with the AutoMake) acts as our key for the query in this case
        CRUD.AddParams("@autoMake", AutoMakeComboBox.Text)
        CRUD.AddParams("@initialAutoModel", CarModelDbController.DbDataTable.Rows(CarModelRow)("AutoModel"))
        CRUD.ExecQuery("DELETE FROM CarModels WHERE AutoMake=@autoMake AND AutoModel=@initialAutoModel")

        ' Then, return exception status of CRUD controller. Do this after each call
        If CRUD.HasException() Then Return False

        ' Otherwise, return true
        Return True

    End Function



    Private Sub carModelMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' TEST DATABASE CONNECTION FIRST
        If Not checkDbConn() Then
            MessageBox.Show("Failed to connect to database; Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' LOAD AUTOMAKE DATATABLE
        If Not loadAutoMakeDatatable() Then
            MessageBox.Show("Failed to connect to database; Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' INITIALIZE AUTOMAKECOMBOBOX FOR FIRST TIME
        InitializeAutoMakeComboBox()
        AutoMakeComboBox.SelectedIndex = 0

    End Sub




    ' **************** CONTROL SUBS ****************


    ' Handles changes made to AutoMakeComboBox
    Private Sub AutoMakeComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AutoMakeComboBox.SelectedIndexChanged, AutoMakeComboBox.TextChanged

        ' First, lookup newly changed value in respective dataTable to see if the selected value exists and is valid
        AutoMakeRow = getDataTableRow(AutoMakeDbController.DbDataTable, "AutoMake", AutoMakeComboBox.Text)

        ' If the lookup DOES find the value in the DataTable
        If AutoMakeRow <> -1 Then

            ' Load corresponding car models for that automake into DataTable
            loadCarModelDataTable()
            ' Then initialize CarModelComboBox
            InitializeCarModelComboBox()
            CarModelComboBox.SelectedIndex = 0

            ' Enable user to Add new model under valid manufacturer
            addButton.Enabled = True

            'If it does = -1, that means that value Is either "Select one" Or some other anomoly
        Else

            ' If not already, clear and empty the CarModelComboBox
            If CarModelComboBox.Text <> String.Empty And CarModelComboBox.Items.Count <> 0 Then
                CarModelComboBox.Items.Clear()
                CarModelComboBox.Text = String.Empty
            End If
            addButton.Enabled = False

        End If

    End Sub


    ' Handles changes made to CarModelComboBox
    Private Sub CarModelComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CarModelComboBox.SelectedIndexChanged, CarModelComboBox.TextChanged

        ' Before anything, ensure that AutoMakeComboBox has a valid entry. Otherwise, we can't be entering values into CarModelComboBox
        If AutoMakeRow = -1 Then Exit Sub

        ' First, Lookup newly changed value in respective dataTable to see if the selected value exists And Is valid
        CarModelRow = getDataTableRow(CarModelDbController.DbDataTable, "AutoModel", CarModelComboBox.Text)

        ' If the lookup DOES find the value in the DataTable
        If CarModelRow <> -1 Then

            ' Initialize corresponding controls from DataTable values
            valuesInitialized = False
            InitializeCarModelDataViewingControls()     ' in customer vehicles, this will need to be a call to initializeAll (maybe?)
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
        clearControls(getAllControlsWithTag("dataEditingControl", Me))
        ' Establish initial values. Doing this here, as unless changes are about to be made, we don't need to set initial values
        InitialCarModelValues.SetInitialValues(getAllControlsWithTag("dataEditingControl", Me))

        ' First, disable editButton, addButton, enable cancelButton, and disable nav
        editButton.Enabled = False
        addButton.Enabled = False
        cancelButton.Enabled = True
        nav.DisableAll()
        AutoMakeComboBox.Enabled = False
        CarModelComboBox.Enabled = False

        ' Store the last selected item in the ComboBox, then set its selected index to "Select One" (0)
        lastSelectedCarModel = CarModelComboBox.Text
        CarModelComboBox.SelectedIndex = 0

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
                    MessageBox.Show("Successfully deleted " & CarModelComboBox.Text & " from CarModels")
                End If

                ' 2.) RELOAD DATATABLES FROM DATABASE
                If Not loadCarModelDataTable() Then
                    MessageBox.Show("Loading updated information failed; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                ' 3.) REINITIALIZE CONTROLS FROM THIS POINT (still from selection index, however)
                InitializeCarModelComboBox()
                CarModelComboBox.SelectedIndex = 0

                ' 4.) RESTORE USER CONTROLS TO NON-EDITING/SELECTING STATE
                AutoMakeComboBox.Enabled = True
                CarModelComboBox.Enabled = True
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
        InitializeCarModelDataEditingControls()
        ' Establish initial values. Doing this here, as unless changes are about to be made, we don't need to set initial values
        InitialCarModelValues.SetInitialValues(getAllControlsWithTag("dataEditingControl", Me))

        ' Store the last selected item in the ComboBox (in case update fails and it must revert)
        lastSelectedCarModel = CarModelComboBox.Text

        ' Disable editButton, disable addButton, enable cancel button, disable navigation, and disable main selection combobox
        editButton.Enabled = False
        addButton.Enabled = False
        cancelButton.Enabled = True
        nav.DisableAll()
        AutoMakeComboBox.Enabled = False
        CarModelComboBox.Enabled = False

        ' Hide/Show the dataViewingControls and dataEditingControls, respectively
        showHide(getAllControlsWithTag("dataViewingControl", Me), 0)
        showHide(getAllControlsWithTag("dataEditingControl", Me), 1)

    End Sub


    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click

        ' Check for changes before cancelling. Don't need function here that calls all, as only working with one datatable's values
        If InitialCarModelValues.CtrlValuesChanged() Then

            Dim decision As DialogResult = MessageBox.Show("Cancel without saving changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            Select Case decision
                Case DialogResult.Yes

                    If mode = "editing" Then

                        ' RESTORE USER CONTROLS TO NON-EDITING STATE
                        editButton.Enabled = True
                        addButton.Enabled = True
                        cancelButton.Enabled = False
                        saveButton.Enabled = False
                        nav.EnableAll()
                        AutoMakeComboBox.Enabled = True
                        CarModelComboBox.Enabled = True

                        ' Show/Hide the dataViewingControls and dataEditingControls, respectively
                        showHide(getAllControlsWithTag("dataViewingControl", Me), 1)
                        showHide(getAllControlsWithTag("dataEditingControl", Me), 0)

                    ElseIf mode = "adding" Then

                        ' 1.) SET CarModelComboBox BACKK TO LAST SELECTED ITEM/INDEX
                        CarModelComboBox.SelectedIndex = CarModelComboBox.Items.IndexOf(lastSelectedCarModel)

                        ' 2.) IF LAST SELECTED WAS "SELECT ONE", Then simulate functionality from combobox text/selectedIndex changed
                        If lastSelectedCarModel = "Select One" Then
                            CarModelComboBox_SelectedIndexChanged(CarModelComboBox, New EventArgs())
                        End If

                        ' 3.) RESTORE USER CONTROLS TO NON-ADDING STATE (only those that are controlled by "adding")
                        AutoMakeComboBox.Enabled = True
                        CarModelComboBox.Enabled = True
                        addButton.Enabled = True
                        cancelButton.Enabled = False
                        saveButton.Enabled = False
                        nav.EnableAll()

                    End If

                Case DialogResult.No
            End Select

        Else

            If mode = "editing" Then

                ' RESTORE USER CONTROLS TO NON-EDITING STATE
                editButton.Enabled = True
                addButton.Enabled = True
                cancelButton.Enabled = False
                saveButton.Enabled = False
                nav.EnableAll()
                AutoMakeComboBox.Enabled = True
                CarModelComboBox.Enabled = True

                ' Show/Hide the dataViewingControls and dataEditingControls, respectively
                showHide(getAllControlsWithTag("dataViewingControl", Me), 1)
                showHide(getAllControlsWithTag("dataEditingControl", Me), 0)

            ElseIf mode = "adding" Then

                ' 1.) SET PartComboBox BACK TO LAST SELECTED ITEM/INDEX
                CarModelComboBox.SelectedIndex = CarModelComboBox.Items.IndexOf(lastSelectedCarModel)

                ' 2.) IF LAST SELECTED WAS "SELECT ONE", Then simulate functionality from combobox text/selectedIndex changed
                If lastSelectedCarModel = "Select One" Then
                    CarModelComboBox_SelectedIndexChanged(CarModelComboBox, New EventArgs())
                End If

                ' 3.) RESTORE USER CONTROLS TO NON-ADDING STATE (only those that are controlled by "adding")
                AutoMakeComboBox.Enabled = True
                CarModelComboBox.Enabled = True
                addButton.Enabled = True
                cancelButton.Enabled = False
                saveButton.Enabled = False
                nav.EnableAll()

            End If

        End If

    End Sub


    Private Sub saveButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click

        Dim decision As DialogResult = MessageBox.Show("Save Changes?", "Confirm Changes", MessageBoxButtons.YesNo)

        Select Case decision
            Case DialogResult.Yes

                If mode = "editing" Then

                    ' 1.) VALIDATE DATAEDITING CONTROLS
                    'If Not controlsValid() Then Exit Sub

                    ' 2.) UPDATE DATATABLE(S), THEN UPDATE DATABASE
                    If Not updateAll() Then
                        MessageBox.Show("Update unsuccessful; Changes not saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        MessageBox.Show("Successfully updated Car Models")
                    End If

                    ' 3.) RELOAD DATATABLES FROM DATABASE
                    If Not loadCarModelDataTable() Then
                        MessageBox.Show("Loading updated information failed; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    ' 4.) REINITIALIZE CONTROLS FROM THIS POINT (still from selection index, however)
                    InitializeCarModelComboBox()

                    ' Look up new ComboBox value corresponding to the new value in the datatable and set the selected index of the re-initialized ComboBox accordingly
                    ' If insertion failed, then revert selected back to lastSelected
                    Dim updatedItem As String = getRowValueWithKey(CarModelDbController.DbDataTable, "AutoModel", "AutoModel", AutoModel_Textbox.Text)
                    If updatedItem <> Nothing Then
                        CarModelComboBox.SelectedIndex = CarModelComboBox.Items.IndexOf(updatedItem)
                    Else
                        CarModelComboBox.SelectedIndex = CarModelComboBox.Items.IndexOf(lastSelectedCarModel)
                    End If


                    ' 5.) MOVE UI OUT OF EDITING MODE
                    addButton.Enabled = True
                    cancelButton.Enabled = False
                    saveButton.Enabled = False
                    nav.EnableAll()
                    AutoMakeComboBox.Enabled = True
                    CarModelComboBox.Enabled = True

                ElseIf mode = "adding" Then

                    ' 1.) VALIDATE DATAEDITING CONTROLS
                    'If Not controlsValid() Then Exit Sub

                    ' 2.) INSERT NEW ROW INTO DATABASE
                    If Not insertAll() Then
                        MessageBox.Show("Insert unsuccessful; Changes not saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        MessageBox.Show("Successfully added " & AutoModel_Textbox.Text & " to Car Models")
                    End If

                    ' 3.) RELOAD DATATABLES FROM DATABASE
                    If Not loadCarModelDataTable() Then
                        MessageBox.Show("Loading updated information failed; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    ' 4.) REINITIALIZE CONTROLS (based on index of newly inserted value)
                    InitializeCarModelComboBox()

                    ' Changing index of CarModelComboBox  will also initialize respective dataViewing control values
                    ' Lookup and set new selectedIndex based on new value. If insertion failed, then go back to last
                    Dim newItem As Object = getRowValueWithKey(CarModelDbController.DbDataTable, "AutoModel", "AutoModel", AutoModel_Textbox.Text)
                    If newItem <> Nothing Then
                        CarModelComboBox.SelectedIndex = CarModelComboBox.Items.IndexOf(newItem)
                    Else
                        CarModelComboBox.SelectedIndex = CarModelComboBox.Items.IndexOf(lastSelectedCarModel)
                    End If


                    ' 5.) MOVE UI OUT OF Adding MODE
                    addButton.Enabled = True
                    cancelButton.Enabled = False
                    saveButton.Enabled = False
                    nav.EnableAll()
                    AutoMakeComboBox.Enabled = True
                    CarModelComboBox.Enabled = True

                End If

            Case DialogResult.No
                ' Continue making changes or cancel editing
        End Select


    End Sub


    Private Sub AutoModel_Textbox_TextChanged(sender As Object, e As EventArgs) Handles AutoModel_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        AutoModel_Textbox.ForeColor = DefaultForeColor

        If InitialCarModelValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


End Class