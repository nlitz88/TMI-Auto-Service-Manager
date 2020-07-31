Public Class carModelMaintenance

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


    ' Sub that initializes all dataEditingcontrols corresponding with values from the Parts datatable
    Private Sub InitializeCarModelDataEditingControls()

        initializeControlsFromRow(CarModelDbController.DbDataTable, CarModelRow, "dataEditingControl", "_", Me)

    End Sub

    ' Sub that initializes all dataEditingcontrols corresponding with values from the Parts datatable
    Private Sub InitializeCarModelDataViewingControls()

        initializeControlsFromRow(CarModelDbController.DbDataTable, CarModelRow, "dataViewingControl", "_", Me)

    End Sub


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

        ' If the lookup DOES find the value in the datable
        If AutoMakeRow <> -1 Then

            ' Load corresponding car models for that automake into DataTable
            loadCarModelDataTable()
            ' Then initialize CarModelComboBox
            InitializeCarModelComboBox()
            CarModelComboBox.SelectedIndex = 0

            'CarModelComboBox.Enabled = True

            ' Enable user to Add new model under valid manufacturer
            addButton.Enabled = True

            'If it does = -1, that means that value Is either "Select one" Or some other anomoly
        Else

            ' If not already, clear and empty the CarModelComboBox
            If CarModelComboBox.Text <> String.Empty And CarModelComboBox.Items.Count <> 0 Then
                CarModelComboBox.Items.Clear()
                CarModelComboBox.Text = String.Empty
            End If
            'CarModelComboBox.Enabled = False
            addButton.Enabled = False

        End If

    End Sub


    ' Handles changes made to CarModelComboBox
    Private Sub CarModelComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CarModelComboBox.SelectedIndexChanged, CarModelComboBox.TextChanged

        ' Before anything, ensure that AutoMakeComboBox has a valid entry. Otherwise, we can't be entering values into CarModelComboBox
        If AutoMakeRow = -1 Then Exit Sub

        ' First, Lookup newly changed value in respective dataTable to see if the selected value exists And Is valid
        CarModelRow = getDataTableRow(CarModelDbController.DbDataTable, "AutoModel", CarModelComboBox.Text)

        ' If the lookup DOES find the value in the datable
        If CarModelRow <> -1 Then

            ' Initialize corresponding controls from DataTable values
            valuesInitialized = False
            InitializeCarModelDataViewingControls()
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