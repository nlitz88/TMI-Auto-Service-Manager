Public Class masterTaskMaintenance

    ' New Database control instances for all preliminary datatables
    Private MTL As New DbControl()
    Private TaskTypesDbController As New DbControl()
    ' New Database control instances for all selection-dependent data
    Private TaskLaborDbController As New DbControl()
    Private TaskPartsDbController As New DbControl()
    ' New Database control instance for updating, inserting, and deleting
    Private CRUD As New DbControl()

    ' Initialize instance(s) of initialValues class
    Private InitialTaskValues As New InitialValues()

    'Variable to keep track of whether form fully loaded or not
    Private valuesInitialized As Boolean = True

    ' Row index variables used for DataTable lookups
    Private TaskRow As Integer
    Private TaskId As Integer

    Private TaskLaborRow As Integer
    Private TaskPartsRow As Integer
    Private TaskTypeRow As Integer

    ' Last selected variables for reinitialization of controls from DataTables
    Private lastSelectedTask As String
    Private lastSelectedTaskLabor As String
    Private lastSelectedTaskPart As String

    ' Keeps track of whether or not user in "editing" or "adding" mode
    Private mode As String

    ' Variable that allows certain keystrokes through restricted fields
    Private allowedKeystroke As Boolean = False




    ' ***************** INITIALIZATION AND CONFIGURATION SUBS *****************


    ' Function that will load all preliminary datatables
    Private Function loadAllPreliminaryDataTables() As Boolean

        ' Loads datatable from MasterTaskList table
        MTL.ExecQuery("SELECT mtl.TaskId, mtl.TaskDescription, mtl.Instructions, mtl.TaskType, mtl.TaskLabor, mtl.TaskParts, mtl.TotalTask " &
                                       "FROM MasterTaskList mtl " &
                                       "WHERE Trim(mtl.TaskDescription) <> '' " &
                                       "ORDER BY mtl.TaskDescription ASC")
        If MTL.HasException() Then Return False

        ' Loads datatable from TaskTypes
        TaskTypesDbController.ExecQuery("SELECT mtl.TaskType, mtl.TaskDescription FROM TaskTypes mtl ORDER BY mtl.TaskType ASC")
        If TaskTypesDbController.HasException() Then Return False

        Return True

    End Function

    ' Sub that initializes TaskComboBox
    Private Sub InitializeTaskComboBox()

        TaskComboBox.BeginUpdate()
        TaskComboBox.Items.Clear()
        TaskComboBox.Items.Add("Select One")
        For Each row In MTL.DbDataTable.Rows
            TaskComboBox.Items.Add(row("TaskDescription"))
        Next
        TaskComboBox.EndUpdate()

    End Sub

    ' Sub that initializes TaskTypeComboBox
    Private Sub InitializeTaskTypeComboBox()

        TaskType_ComboBox.Items.Clear()
        TaskType_ComboBox.BeginUpdate()
        For Each row In TaskTypesDbController.DbDataTable.Rows
            TaskType_ComboBox.Items.Add(row("TaskDescription"))
        Next
        TaskType_ComboBox.EndUpdate()

    End Sub

    ' Sub that will display TaskType TaskDescription instead of the corresponding symbol stored in the database in TaskTypeComboBox
    Private Sub ReplaceTaskTypeComboBox()

        ' First, check if empty. If empty, we don't need to do anything
        If String.IsNullOrWhiteSpace(TaskType_ComboBox.Text) Then Exit Sub

        ' Then, lookup corresponding TaskTypeDescription based on the TaskTypeSymbol present
        Dim taskDescription As String = getRowValueWithKeyEquals(TaskTypesDbController.DbDataTable, "TaskDescription", "TaskType", TaskType_ComboBox.Text)
        ' As long as the query is successful (finds a corresponding value), then set the corresponding value
        If taskDescription <> Nothing Then
            TaskType_ComboBox.Text = taskDescription
        End If

    End Sub

    ' Sub that will display TaskType TaskDescription instead of the corresponding symbol stored in the database in TaskTypeValue
    Private Sub ReplaceTaskTypeValue()

        ' First, check if empty. If empty, we don't need to do anything
        If String.IsNullOrWhiteSpace(TaskType_Value.Text) Then Exit Sub

        ' Then, lookup corresponding TaskTypeDescription based on the TaskTypeSymbol present
        Dim taskDescription As String = getRowValueWithKeyEquals(TaskTypesDbController.DbDataTable, "TaskDescription", "TaskType", TaskType_Value.Text)
        ' As long as the query is successful (finds a corresponding value), then set the corresponding value
        If taskDescription <> Nothing Then
            TaskType_Value.Text = taskDescription
        End If

    End Sub


    ' Sub that initializes all dataEditingcontrols corresponding with values from the MasterTaskList datatable
    Private Sub InitializeMTLDataEditingControls()

        initializeControlsFromRow(MTL.DbDataTable, TaskRow, "dataEditingControl", "_", Me)

    End Sub

    ' Sub that initializes all dataViewingControls corresponding with values from the MasterTaskList datatable
    Private Sub InitializeMTLDataViewingControls()

        initializeControlsFromRow(MTL.DbDataTable, TaskRow, "dataViewingControl", "_", Me)

    End Sub



    ' Function that will load all selection-dependent DataTables
    Private Function loadDependentDataTables()

        ' Loads rows from MasterTaskLabor based on selected TaskId from MasterTaskList
        TaskLaborDbController.AddParams("@taskId", TaskId)
        TaskLaborDbController.ExecQuery("SELECT tl.LaborCode, tl.Description, tl.Rate, tl.Hours, tl.Amount " &
                                        "WHERE TaskId=@taskId")
        If TaskLaborDbController.HasException() Then Return False

        ' Loads rows from MasterTaskParts based on selected TaskId from MasterTaskList
        TaskPartsDbController.AddParams("@taskId", TaskId)
        TaskPartsDbController.ExecQuery("SELECT tp.PartNbr, tp.Qty, tp.PartDescription, tp.PartPrice, tp.PartAmount, tp.ListPrice" &
                                        "WHERE taskId=@taskId")
        If TaskPartsDbController.HasException() Then Return False

        Return True

    End Function

    ' Sub that initializes TaskLaborGridView
    Private Sub InitializeTaskLaborGridView()

        TaskLaborGridView.DataSource = TaskLaborDbController.DbDataTable

    End Sub

    ' Sub that initializes TaskPartsGridView
    Private Sub InitializeTaskPartsGridView()

        TaskPartsGridView.DataSource = TaskPartsDbController.DbDataTable

    End Sub



    ' Sub that handles all initialization for dataEditingControls
    Private Sub InitializeAllDataEditingControls()

        ' Automated initializations
        InitializeMTLDataEditingControls()
        ReplaceTaskTypeComboBox()
        ' Then, format dataEditingControls
        formatDataEditingControls()
        ' Set forecolor if not already initially default
        setForeColor(getAllControlsWithTag("dataEditingControl", Me), DefaultForeColor)

    End Sub

    ' Sub that handles all initialization for dataViewingControls
    Private Sub InitializeAllDataViewingControls()

        ' Automated initializations
        InitializeMTLDataViewingControls()
        ReplaceTaskTypeValue()
        ' Then, format dataViewingControls
        formatDataViewingControls()

    End Sub



    ' Sub that will add formatting to already initialized dataViewingControls
    Private Sub formatDataViewingControls()

        ' Currency formatting
        TaskLabor_Value.Text = FormatCurrency(TaskLabor_Value.Text)
        TaskParts_Value.Text = FormatCurrency(TaskParts_Value.Text)
        TotalTask_Value.Text = FormatCurrency(TotalTask_Value.Text)

    End Sub

    ' Sub that will add formatting to already initialized dataEditingControls
    Private Sub formatDataEditingControls()

        TaskLabor_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(TaskLabor_Textbox.Text))
        TaskParts_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(TaskParts_Textbox.Text))
        TotalTask_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(TotalTask_Textbox.Text))

    End Sub




    ' ***************** CRUD SUBS *****************




    ' ***************** VALIDATION SUBS *****************




    Private Sub masterTaskMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' PRE-DRAW PRE-LOADED (Preliminary) COMBOBOXES. 
        ' This way, we don't have to wait for them to draw on first edit/add

        TaskType_ComboBox.Visible = True
        TaskType_ComboBox.Visible = False

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If Not checkDbConn() Then Exit Sub

        ' Load preliminary datatables
        If Not loadAllPreliminaryDataTables() Then
            MessageBox.Show("Failed to connect to database; Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Initialize TaskComboBox and all other preliminary ComboBoxes for the first time
        InitializeTaskComboBox()
        TaskComboBox.SelectedIndex = 0
        InitializeTaskTypeComboBox()

    End Sub




    ' **************** CONTROL SUBS ****************


    Private Sub TaskComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TaskComboBox.SelectedIndexChanged, TaskComboBox.TextChanged

        ' Ensure that TaskCombobox is only attempting to initialize values when on proper selected Index
        If TaskComboBox.SelectedIndex = -1 Then

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
        TaskRow = getDataTableRow(MTL.DbDataTable, "TaskDescription", TaskComboBox.Text)

        ' If this query DOES return a valid row index, then initialize respective controls
        If TaskRow <> -1 Then

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