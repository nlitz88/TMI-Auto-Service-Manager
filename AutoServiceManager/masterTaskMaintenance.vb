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
    Private InitialMTLValues As New InitialValues()

    'Variable to keep track of whether form fully loaded or not
    Private valuesInitialized As Boolean = True

    ' Row index variables used for DataTable lookups
    Private TaskRow As Integer
    Private TaskId As Integer

    ' Row indexes for use with TaskLabor and TaskParts DataGridViews
    Private TaskLaborRow As Integer = -1
    Private TaskPartsRow As Integer = -1

    ' Variables that store calculated values for TaskLabor, TaskParts, and TotalTask Values/Textboxes
    Private TaskLaborSum As Decimal = 0
    Private TaskPartsSum As Decimal = 0
    Private TotalTaskSum As Decimal = 0

    ' Row index for use with TaskType ComboBox
    Private TaskTypeRow As Integer

    ' Last selected variables for reinitialization of controls from DataTables
    Private lastSelectedTask As String
    Private lastSelectedTaskLabor As String
    Private lastSelectedTaskPart As String

    ' Keeps track of whether or not user in "editing" or "adding" mode for various control groups
    Private mtMode As String

    ' Variable that allows certain keystrokes through restricted fields
    Private allowedKeystroke As Boolean = False




    ' ***************** GET/SET SUBS FOR EXTERNAL FORMS *****************


    ' Retrieves current task value
    Public Function GetTask() As String
        Return TaskComboBox.Text
    End Function

    ' Retrieves current TaskId corresponding to TaskValue
    Public Function GetTaskId() As Integer
        Return TaskId
    End Function

    ' Retrieves TaskLaborRow
    Public Function GetTaskLaborRow() As Integer
        Return TaskLaborRow
    End Function

    ' Retrieves TaskPartsRow
    Public Function GetTaskPartsRow() As Integer
        Return TaskPartsRow
    End Function

    ' Retrieves MasterTaskLabor DataTable
    Public Function GetTaskLaborDbController() As DbControl
        Return TaskLaborDbController
    End Function

    ' Retrieves MasterTaskParts DataTable
    Public Function GetTaskPartsDbController() As DbControl
        Return TaskPartsDbController
    End Function




    ' ***************** INITIALIZATION AND CONFIGURATION SUBS *****************


    ' Function that will load main TaskComboBox
    Private Function loadMasterTaskListDataTable()

        ' Loads datatable from MasterTaskList table
        MTL.ExecQuery("SELECT mtl.TaskId, mtl.TaskDescription, mtl.Instructions, mtl.TaskType, mtl.TaskLabor, mtl.TaskParts, mtl.TotalTask " &
                                       "FROM MasterTaskList mtl " &
                                       "WHERE Trim(mtl.TaskDescription) <> '' " &
                                       "ORDER BY mtl.TaskDescription ASC")

        If MTL.HasException() Then Return False

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


    ' Function that will load all preliminary datatables (in this case, only taskTypes)
    Private Function loadAllPreliminaryDataTables() As Boolean

        ' Loads datatable from TaskTypes
        TaskTypesDbController.ExecQuery("SELECT tt.TaskType, tt.TaskDescription FROM TaskTypes tt ORDER BY tt.TaskType ASC")
        If TaskTypesDbController.HasException() Then Return False

        Return True

    End Function

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
        TaskLaborDbController.ExecQuery("SELECT tl.TaskId, tl.LaborCode, tl.Description, tl.Rate, tl.Hours, tl.Amount " &
                                        "FROM MasterTaskLabor tl " &
                                        "WHERE tl.TaskId=@taskId")
        If TaskLaborDbController.HasException() Then Return False

        ' Loads rows from MasterTaskParts based on selected TaskId from MasterTaskList
        TaskPartsDbController.AddParams("@taskId", TaskId)
        TaskPartsDbController.ExecQuery("SELECT tp.TaskId, tp.PartNbr, tp.Qty, tp.PartDescription, tp.PartPrice, tp.PartAmount, tp.ListPrice " &
                                        "FROM MasterTaskParts tp " &
                                        "WHERE tp.TaskId=@taskId")
        If TaskPartsDbController.HasException() Then Return False

        Return True

    End Function

    Private Sub InitializeTaskLaborGridView()

        TaskLaborGridView.DataSource = TaskLaborDbController.DbDataTable

    End Sub

    ' Sub that initializes TaskPartsGridView
    Private Sub InitializeTaskPartsGridView()

        TaskPartsGridView.DataSource = TaskPartsDbController.DbDataTable

    End Sub

    ' Sub that sets up both the TaskLaborDataGridView and TaskPartsDataGridView
    Private Sub SetupGridViews()

        ' Manually add DataGridView columns corresponding to only desired columns from DataTable

        ' Task Labor GridView
        TaskLaborGridView.AutoGenerateColumns = False
        TaskLaborGridView.Columns.Add(New DataGridViewTextBoxColumn() With {.HeaderText = "Description", .DataPropertyName = "Description"})
        TaskLaborGridView.Columns.Add(New DataGridViewTextBoxColumn() With {.HeaderText = "Rate", .DataPropertyName = "Rate"})
        TaskLaborGridView.Columns.Add(New DataGridViewTextBoxColumn() With {.HeaderText = "Hours", .DataPropertyName = "Hours"})
        TaskLaborGridView.Columns.Add(New DataGridViewTextBoxColumn() With {.HeaderText = "Amount", .DataPropertyName = "Amount"})
        TaskLaborGridView.Columns(1).DefaultCellStyle.Format = "c"      ' Applies currency format to the cells of this column
        TaskLaborGridView.Columns(3).DefaultCellStyle.Format = "c"

        ' Task Parts GridView
        TaskPartsGridView.AutoGenerateColumns = False
        TaskPartsGridView.Columns.Add(New DataGridViewTextBoxColumn() With {.HeaderText = "Description", .DataPropertyName = "PartDescription"})
        TaskPartsGridView.Columns.Add(New DataGridViewTextBoxColumn() With {.HeaderText = "Quantity", .DataPropertyName = "Qty"})
        TaskPartsGridView.Columns.Add(New DataGridViewTextBoxColumn() With {.HeaderText = "Part Price", .DataPropertyName = "PartPrice"})
        TaskPartsGridView.Columns.Add(New DataGridViewTextBoxColumn() With {.HeaderText = "Amount", .DataPropertyName = "PartAmount"})
        TaskPartsGridView.Columns(2).DefaultCellStyle.Format = "c"
        TaskPartsGridView.Columns(3).DefaultCellStyle.Format = "c"

    End Sub


    ' Sub that will initialize/Calculate Task Labor Cost based on the total cost of all the labor codes in MasterTaskLabor with current TaskId
    Private Sub InitializeTaskLaborValue()

        ' All rows in MasterTaskLabor that are associated with the currently selectedTaskId will already be loaded into the datatable.
        ' So, to calculate the total, all we have to do is get the sum of the Amount Field in the Dependently loaded MasterTaskLabor DataTable
        ' Even if zero rows, shouldn't run into any issues
        For Each row In TaskLaborDbController.DbDataTable.Rows
            TaskLaborSum += row("Amount")
        Next

        ' Then, assign the calculated sum
        TaskLabor_Value.Text = TaskLaborSum

    End Sub

    Private Sub InitializeTaskLaborTextbox()

        ' Calculate TaskLabor sum
        For Each row In TaskLaborDbController.DbDataTable.Rows
            TaskLaborSum += row("Amount")
        Next

        TaskLabor_Textbox.Text = String.Format("{0:0.00}", TaskLaborSum)

    End Sub

    ' Sub that will initialize/Calculate Task Part Cost based on the total cost of all the parts in MasterTaskParts with current TaskId
    Private Sub InitializeTaskPartsValue()

        ' Calculate TaskParts sum
        For Each row In TaskPartsDbController.DbDataTable.Rows
            TaskPartsSum += row("PartAmount")
        Next

        ' Then, assign the calculated sum
        TaskParts_Value.Text = TaskPartsSum

    End Sub

    Private Sub InitializeTaskPartsTextbox()

        ' Calculate TaskParts sum
        For Each row In TaskPartsDbController.DbDataTable.Rows
            TaskPartsSum += row("PartAmount")
        Next

        TaskParts_Textbox.Text = String.Format("{0:0.00}", TaskPartsSum)

    End Sub

    ' Sub that will initialize/Calculate Total Task Cost based on the Sums found in TotalLaborCost and TotalPartsCost
    ' NOTE: must be called after InitializeTaskLaborValue and InitializeTaskPartsValue
    Private Sub InitializeTotalTaskValue()

        Dim TaskLaborCost As Decimal = Convert.ToDecimal(TaskLabor_Value.Text)
        Dim TaskPartsCost As Decimal = Convert.ToDecimal(TaskParts_Value.Text)
        TotalTaskSum = TaskLaborCost + TaskPartsCost

        ' Then, assign the calculated sum
        TotalTask_Value.Text = TotalTaskSum

    End Sub

    Private Sub InitializeTotalTaskTextbox()

        ' In other scenarios, we would have to validate the values that we were finding these calculations from. However, becauase these values are calculated.
        Dim TaskLaborCost As Decimal = Convert.ToDecimal(TaskLabor_Textbox.Text)
        Dim TaskPartsCost As Decimal = Convert.ToDecimal(TaskParts_Textbox.Text)
        TotalTaskSum = TaskLaborCost + TaskPartsCost

        ' Then, assign and format calculated sum
        TotalTask_Textbox.Text = String.Format("{0:0.00}", TotalTaskSum)

    End Sub



    ' Sub that handles all initialization for dataEditingControls
    Private Sub InitializeAllDataEditingControls()

        ' Reset calculated value variables
        TaskLaborSum = 0
        TaskPartsSum = 0
        TotalTaskSum = 0

        ' Automated initializations
        InitializeMTLDataEditingControls()
        ReplaceTaskTypeComboBox()
        ' Then, re-initialize and format any calculation based values
        InitializeTaskLaborTextbox()
        InitializeTaskPartsTextbox()
        InitializeTotalTaskTextbox()
        ' Then, format dataEditingControls
        formatDataEditingControls()
        ' Set forecolor if not already initially default
        setForeColor(getAllControlsWithTag("dataEditingControl", Me), DefaultForeColor)

    End Sub

    ' Sub that handles all initialization for dataViewingControls
    Private Sub InitializeAllDataViewingControls()

        ' Reset calculated value variables
        TaskLaborSum = 0
        TaskPartsSum = 0
        TotalTaskSum = 0

        ' Automated initializations
        InitializeMTLDataViewingControls()
        ReplaceTaskTypeValue()
        ' Then, re-initialize and format any calculation based values
        InitializeTaskLaborValue()
        InitializeTaskPartsValue()
        InitializeTotalTaskValue()
        ' Then, format dataViewingControls
        formatDataViewingControls()

    End Sub



    ' Sub that will add formatting to already initialized dataViewingControls
    ' NOTE: these subs only format controls that don't have their formatting handled by a separate sub
    Private Sub formatDataViewingControls()

        ' These three calculation based fields are formatted here after the fact, as otherwise, TotalTask can't parse the decimal values from TaskLabor and TaskParts
        TaskLabor_Value.Text = FormatCurrency(TaskLabor_Value.Text)
        TaskParts_Value.Text = FormatCurrency(TaskParts_Value.Text)
        TotalTask_Value.Text = FormatCurrency(TotalTask_Value.Text)

    End Sub

    ' Sub that will add formatting to already initialized dataEditingControls
    Private Sub formatDataEditingControls()

        'TaskLabor_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(TaskLabor_Textbox.Text))
        'TaskParts_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(TaskParts_Textbox.Text))
        'TotalTask_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(TotalTask_Textbox.Text))

    End Sub



    ' Public Function called after masterTaskLabor or masterTaskParts tables have been changed that reinitializes dependent DataTables, corresponding DataGridViews,
    ' And subTaskEditingControls. Can be called from the edit/adding masterTask forms, or from within this form
    Public Function reinitializeDependents() As Boolean

        valuesInitialized = False

        ' Load TaskParts and TaskLabor datatables based on selected TaskId, then Initialize corresponding GridViews
        If Not loadDependentDataTables() Then
            MessageBox.Show("Failed to connect to database; Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        ' Initialize all dataEditingControls (must do this after dependent datatables loaded, however)
        ' This is because controls like TaskLaborCost (for instance) are calculated from those tables
        InitializeAllDataViewingControls()
        ' Initialize corresponding DataGridViews
        InitializeTaskLaborGridView()
        InitializeTaskPartsGridView()

        valuesInitialized = True

        ' Disable/Enable tlButtons for taskLaborGridView according to if rows present or not
        If TaskLaborGridView.Rows.Count = 0 Then
            TaskLaborRow = -1
            tlDeleteButton.Enabled = False
            tlEditButton.Enabled = False
        Else
            tlDeleteButton.Enabled = True
            tlEditButton.Enabled = True
        End If

        ' Disable/Enable tlButtons for taskPartsGridView according to if rows present or not
        If TaskPartsGridView.Rows.Count = 0 Then
            TaskPartsRow = -1
            tpDeleteButton.Enabled = False
            tpEditButton.Enabled = False
        Else
            tpDeleteButton.Enabled = True
            tpEditButton.Enabled = True
        End If


        ' This sub will only be called if changes were made to database table.
        ' So, as sum of amounts in either datagridview may have changed, the taskLaborCost and taskPartsCost values may have changed
        ' We have decided that it is better to write these new calculated values to the database automatically on change, as the user can't edit/modify them anways.
        ' So, we will write these values to the database table to row based on taskId

        CRUD.AddParams("@TaskLabor", TaskLaborSum)
        CRUD.AddParams("@TaskParts", TaskPartsSum)
        CRUD.AddParams("@TotalTask", TotalTaskSum)
        CRUD.AddParams("@TaskId", TaskId)   ' added last, as used last (thanks OleDB)

        CRUD.ExecQuery("UPDATE MasterTaskList SET TaskLabor=@TaskLabor, TaskParts=@TaskParts, TotalTask=@TotalTask WHERE TaskId=@TaskId")
        If CRUD.HasException() Then Return False

        Return True

    End Function




    ' ***************** CRUD SUBS *****************


    ' Function that makes updateTable calls for all relevant DataTables that need updated based on changes
    Private Function updateMasterTask() As Boolean

        ' Lookup corresponding taskType symbol for valid taskType description first.
        ' Exclude task type from updateTable, then add its swapped value as an additional value
        Dim TaskTypeSymbol As String = getRowValueWithKey(TaskTypesDbController.DbDataTable, "TaskType", "TaskDescription", TaskType_ComboBox.Text)

        Dim excludedControls As New List(Of Control) From {TaskType_ComboBox}
        Dim additionalValues As New List(Of AdditionalValue) From {New AdditionalValue("TaskType", GetType(String), TaskTypeSymbol)}

        updateTable(CRUD, MTL.DbDataTable, "MasterTaskList", TaskId, "TaskId", "_", "dataEditingControl", Me, excludedControls, additionalValues)
        ' Then, return exception status of CRUD controller. Do this after each call
        If CRUD.HasException() Then Return False

        ' Otherwise, return true
        Return True

    End Function


    ' Function that makes insertRow calls for all relevant DataTables
    Private Function insertMasterTask() As Boolean

        ' Lookup corresponding taskType symbol for valid taskType description first.
        ' Exclude task type from updateTable, then add its swapped value as an additional value
        Dim TaskTypeSymbol As String = getRowValueWithKey(TaskTypesDbController.DbDataTable, "TaskType", "TaskDescription", TaskType_ComboBox.Text)

        Dim excludedControls As New List(Of Control) From {TaskType_ComboBox}
        Dim additionalValues As New List(Of AdditionalValue) From {New AdditionalValue("TaskType", GetType(String), TaskTypeSymbol)}

        ' Then, make calls to insertRow to all relevant tables
        insertRow(CRUD, MTL.DbDataTable, "MasterTaskList", "_", "dataEditingControl", Me, excludedControls, additionalValues)
        ' Then, return exception status of CRUD controller. Do this after each call
        If CRUD.HasException() Then Return False

        ' Otherwise, return true
        Return True

    End Function


    ' Function that makes deleteRow calls for all relevant DataTables
    Private Function deleteMasterTask() As Boolean

        deleteRow(CRUD, "MasterTaskList", TaskId, "TaskId")
        ' Then, return exception status of CRUD controller. Do this after each call
        If CRUD.HasException() Then Return False

        ' Otherwise, return true
        Return True

    End Function




    ' ***************** CRUD subs for MasterTaskLabor and MasterTaskParts *****************


    ' Function that handles deleting for MasterTaskParts Table (Add and Edit performed on editMasterTaskPart/addMasterTaskPart forms)
    Public Function deleteMasterTaskLabor() As Boolean

        deleteRow(CRUD, TaskLaborDbController.DbDataTable, TaskLaborRow, New List(Of String), "MasterTaskLabor")
        If CRUD.HasException() Then Return False

        Return True

    End Function


    ' Function that handles deleting for MasterTaskParts Table (Add and Edit performed on editMasterTaskPart/addMasterTaskPart forms)
    Public Function deleteMasterTaskPart() As Boolean

        deleteRow(CRUD, TaskPartsDbController.DbDataTable, TaskPartsRow, New List(Of String), "MasterTaskParts")
        If CRUD.HasException() Then Return False

        Return True

    End Function





    ' ***************** VALIDATION SUBS *****************


    ' Sub that runs validation for all form controls. Also handles error reporting
    Private Function controlsValid() As Boolean

        Dim errorMessage As String = String.Empty

        ' Use "Required" parameter to control whether or not a Null string value will cause an error to be reported


        ' Task Description (REQUIRED)(UNIQUE)
        If Not isValidLength("Description", True, TaskDescription_Textbox.Text, 50, errorMessage) Then
            TaskDescription_Textbox.ForeColor = Color.Red
        Else
            If mtMode = "editing" Then
                Dim initial As String = MTL.DbDataTable.Rows(TaskRow)("TaskDescription").ToString().ToLower()
                If TaskDescription_Textbox.Text.ToLower() <> initial Then
                    If isDuplicate("Description", errorMessage, "TaskDescription", TaskDescription_Textbox.Text, MTL.DbDataTable) Then
                        TaskDescription_Textbox.ForeColor = Color.Red
                    End If
                End If
            ElseIf mtMode = "adding" Then
                If isDuplicate("Description", errorMessage, "TaskDescription", TaskDescription_Textbox.Text, MTL.DbDataTable) Then
                    TaskDescription_Textbox.ForeColor = Color.Red
                End If
            End If
        End If


        ' Instructions
        If Not isValidLength("Instructions", False, Instructions_Textbox.Text, 255, errorMessage) Then
            Instructions_Textbox.ForeColor = Color.Red
        End If

        ' TaskType
        If Not valueExists("Task Type", errorMessage, "TaskDescription", TaskType_ComboBox.Text, TaskTypesDbController.DbDataTable) Then
            TaskType_ComboBox.ForeColor = Color.Red
        End If


        ' Check if any invalid input has been found
        If Not String.IsNullOrEmpty(errorMessage) Then

            MessageBox.Show(errorMessage, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False

        End If

        Return True

    End Function




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

        ' Load MasterTaskList DataTable
        If Not loadMasterTaskListDataTable() Then
            MessageBox.Show("Failed to connect to database; Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Initialize TaskComboBox and all other preliminary ComboBoxes for the first time
        SetupGridViews()
        'setDependentDataTableHandlers()
        InitializeTaskComboBox()
        TaskComboBox.SelectedIndex = 0
        InitializeTaskTypeComboBox()

    End Sub




    ' **************** CONTROL SUBS FOR MASTER TASKS ****************


    Private Sub TaskComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TaskComboBox.SelectedIndexChanged, TaskComboBox.TextChanged

        ' Ensure that TaskCombobox is only attempting to initialize values when on proper selected Index
        If TaskComboBox.SelectedIndex = -1 Then

            ' Have all labels and corresponding values hidden
            showHide(getAllControlsWithTag("dataViewingControl", Me), 0)
            showHide(getAllControlsWithTag("dataLabel", Me), 0)
            showHide(getAllControlsWithTag("dataEditingControl", Me), 0)
            showHide(getAllControlsWithTag("subTaskEditingControl", Me), 0)
            ' Disable editing button
            editButton.Enabled = False
            deleteButton.Enabled = False
            Exit Sub

        End If

        ' First, Lookup newly changed value in respective dataTable to see if the selected value exists And Is valid
        TaskRow = getDataTableRow(MTL.DbDataTable, "TaskDescription", TaskComboBox.Text)

        ' If this query DOES return a valid row index, then initialize respective controls
        If TaskRow <> -1 Then

            ' Lookup TaskId based on selected TaskDescription
            TaskId = MTL.DbDataTable(TaskRow)("TaskId")

            ' Initialize corresponding controls from DataTable values
            valuesInitialized = False

            ' Load TaskParts and TaskLabor datatables based on selected TaskId, then Initialize corresponding GridViews
            If Not loadDependentDataTables() Then
                MessageBox.Show("Failed to connect to database; Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            ' Initialize all dataEditingControls (must do this after dependent datatables loaded, however)
            ' This is because controls like TaskLaborCost (for instance) are calculated from those tables
            InitializeAllDataViewingControls()
            ' Initialize corresponding DataGridViews
            InitializeTaskLaborGridView()
            InitializeTaskPartsGridView()

            valuesInitialized = True

            ' Disable/Enable tlButtons for taskLaborGridView according to if rows present or not
            If TaskLaborGridView.Rows.Count = 0 Then
                TaskLaborRow = -1
                tlDeleteButton.Enabled = False
                tlEditButton.Enabled = False
            Else
                tlDeleteButton.Enabled = True
                tlEditButton.Enabled = True
            End If

            ' Disable/Enable tlButtons for taskPartsGridView according to if rows present or not
            If TaskPartsGridView.Rows.Count = 0 Then
                TaskPartsRow = -1
                tpDeleteButton.Enabled = False
                tpEditButton.Enabled = False
            Else
                tpDeleteButton.Enabled = True
                tpEditButton.Enabled = True
            End If

            ' Show labels and corresponding values
            showHide(getAllControlsWithTag("dataViewingControl", Me), 1)
            showHide(getAllControlsWithTag("dataLabel", Me), 1)
            showHide(getAllControlsWithTag("dataEditingControl", Me), 0)
            showHide(getAllControlsWithTag("subTaskEditingControl", Me), 1)

            ' Enable editing and deleting button
            editButton.Enabled = True
            deleteButton.Enabled = True

            'If it does = -1, that means that value Is either "Select one" Or some other anomoly
        Else

            ' Have all labels and corresponding values hidden
            showHide(getAllControlsWithTag("dataViewingControl", Me), 0)
            showHide(getAllControlsWithTag("dataLabel", Me), 0)
            showHide(getAllControlsWithTag("dataEditingControl", Me), 0)
            showHide(getAllControlsWithTag("subTaskEditingControl", Me), 0)
            ' Disable editing button
            editButton.Enabled = False
            deleteButton.Enabled = False

        End If

    End Sub




    Private Sub addButton_Click(sender As Object, e As EventArgs) Handles addButton.Click

        mtMode = "adding"

        ' Initialize values for dataEditingControls
        valuesInitialized = False
        clearControls(getAllControlsWithTag("dataEditingControl", Me))
        ' Clear DataGridViews (on cancel/save, they will be reinitialized, so no problem)
        TaskLaborGridView.DataSource = Nothing
        TaskPartsGridView.DataSource = Nothing
        ' Set TaskType ComboBox selected index = -1
        TaskType_ComboBox.SelectedIndex = -1
        valuesInitialized = True
        ' Establish initial values. Doing this here, as unless changes are about to be made, we don't need to set initial values
        InitialMTLValues.SetInitialValues(getAllControlsWithTag("dataEditingControl", Me))

        ' First, disable editButton, addButton, enable cancelButton, and disable nav
        editButton.Enabled = False
        addButton.Enabled = False
        cancelButton.Enabled = True
        nav.DisableAll()
        TaskComboBox.Enabled = False

        ' Disable all task-related buttons and datagridviews
        For Each ctrl In getAllControlsWithTag("subTaskEditingControl", Me)
            ctrl.Enabled = False
        Next


        ' Get lastSelected
        If getDataTableRow(MTL.DbDataTable, "TaskDescription", TaskComboBox.Text) <> -1 Then
            lastSelectedTask = TaskComboBox.Text
        Else
            lastSelectedTask = "Select One"
        End If

        TaskComboBox.SelectedIndex = 0

        ' Hide/Show the dataViewingControls and dataEditingControls, respectively
        showHide(getAllControlsWithTag("dataViewingControl", Me), 0)
        showHide(getAllControlsWithTag("dataEditingControl", Me), 1)
        showHide(getAllControlsWithTag("dataLabel", Me), 1)
        showHide(getAllControlsWithTag("subTaskEditingControl", Me), 1)

    End Sub


    Private Sub deleteButton_Click(sender As Object, e As EventArgs) Handles deleteButton.Click

        Dim decision As DialogResult = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        Select Case decision
            Case DialogResult.Yes

                ' 1.) Delete value from database
                If Not deleteMasterTask() Then
                    MessageBox.Show("Delete unsuccessful; Changes not saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show("Successfully deleted " & TaskComboBox.Text & " from Master Task List")
                End If

                ' 2.) RELOAD MASTERTASKLIST DATATABLE FROM DATABASE
                If Not loadMasterTaskListDataTable() Then
                    MessageBox.Show("Loading updated information failed; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                ' 3.) REINITIALIZE CONTROLS (Based on the selected index)
                InitializeTaskComboBox()
                TaskComboBox.SelectedIndex = 0

                ' 4.) RESTORE USER CONTROLS TO NON-EDITING/SELECTING STATE
                TaskComboBox.Enabled = True
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

        mtMode = "editing"

        ' Initialize values for dataEditingControls
        valuesInitialized = False
        InitializeAllDataEditingControls()
        valuesInitialized = True
        ' Establish initial values. Doing this here, as unless changes are about to be made, we don't need to set initial values
        InitialMTLValues.SetInitialValues(getAllControlsWithTag("dataEditingControl", Me))

        ' Store the last selected item in the ComboBox (in case update fails and it must revert)
        lastSelectedTask = TaskComboBox.Text

        ' Disable editButton, disable addButton, enable cancel button, disable navigation, and disable main selection combobox
        editButton.Enabled = False
        addButton.Enabled = False
        cancelButton.Enabled = True
        nav.DisableAll()
        TaskComboBox.Enabled = False

        ' Disable all task-related buttons and datagridviews
        For Each ctrl In getAllControlsWithTag("subTaskEditingControl", Me)
            ctrl.Enabled = False
        Next

        ' Show/Hide various control types accordingly
        showHide(getAllControlsWithTag("dataViewingControl", Me), 0)
        showHide(getAllControlsWithTag("dataEditingControl", Me), 1)

    End Sub


    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click

        ' Check for changes before cancelling. Don't need function here that calls all, as only working with one datatable's values
        If InitialMTLValues.CtrlValuesChanged() Then

            Dim decision As DialogResult = MessageBox.Show("Cancel without saving changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            ' If changes have been made, and the user selected that they don't want to cancel, then exit here.
            If decision = DialogResult.No Then Exit Sub

        End If

        ' Otherwise, continue cancelling
        If mtMode = "editing" Then

            ' RESTORE USER CONTROLS TO NON-EDITING STATE
            editButton.Enabled = True
            addButton.Enabled = True
            cancelButton.Enabled = False
            saveButton.Enabled = False
            nav.EnableAll()
            TaskComboBox.Enabled = True

            ' Re-enable all task-related buttons and datagridviews
            For Each ctrl In getAllControlsWithTag("subTaskEditingControl", Me)
                ctrl.Enabled = True
            Next

            ' Show/Hide the dataViewingControls and dataEditingControls, respectively
            showHide(getAllControlsWithTag("dataViewingControl", Me), 1)
            showHide(getAllControlsWithTag("dataEditingControl", Me), 0)
            showHide(getAllControlsWithTag("taskEditingButton", Me), 0)

        ElseIf mtMode = "adding" Then

            ' 1.) SET CustomerComboBox BACKK TO LAST SELECTED ITEM/INDEX
            TaskComboBox.SelectedIndex = TaskComboBox.Items.IndexOf(lastSelectedTask)

            ' 2.) IF LAST SELECTED WAS "SELECT ONE", Then simulate functionality from combobox text/selectedIndex changed
            If lastSelectedTask = "Select One" Then
                TaskComboBox_SelectedIndexChanged(TaskComboBox, New EventArgs())
            End If

            ' 3.) RESTORE USER CONTROLS TO NON-ADDING STATE (only those that are controlled by "adding")
            TaskComboBox.Enabled = True
            addButton.Enabled = True
            cancelButton.Enabled = False
            saveButton.Enabled = False
            nav.EnableAll()

            ' Re-enable all task-related buttons and datagridviews
            For Each ctrl In getAllControlsWithTag("subTaskEditingControl", Me)
                ctrl.Enabled = True
            Next

        End If

    End Sub


    Private Sub saveButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click

        Dim decision As DialogResult = MessageBox.Show("Save Changes?", "Confirm Changes", MessageBoxButtons.YesNo)

        Select Case decision
            Case DialogResult.Yes

                If mtMode = "editing" Then

                    ' 1.) VALIDATE DATAEDITING CONTROLS
                    If Not controlsValid() Then Exit Sub

                    ' 2.) UPDATE MASTER TASK LIST VALUES
                    If Not updateMasterTask() Then
                        MessageBox.Show("Update unsuccessful; Changes not saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    Else
                        MessageBox.Show("Successfully updated Master Task List")
                    End If

                    ' 3.) RELOAD DATATABLES FROM DATABASE
                    If Not loadMasterTaskListDataTable() Then
                        MessageBox.Show("Loading updated information failed; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    ' 4.) REINITIALIZE CONTROLS FROM THIS POINT (still from selection index, however)
                    InitializeTaskComboBox()
                    ' Look up new ComboBox value corresponding to the new value in the datatable and set the selected index of the re-initialized ComboBox accordingly
                    ' If update failed, then revert selected back to lastSelected
                    Dim updatedItem As String = getRowValueWithKeyEquals(MTL.DbDataTable, "TaskDescription", "TaskDescription", TaskDescription_Textbox.Text)
                    If updatedItem <> Nothing Then
                        TaskComboBox.SelectedIndex = TaskComboBox.Items.IndexOf(updatedItem)
                    Else
                        TaskComboBox.SelectedIndex = TaskComboBox.Items.IndexOf(lastSelectedTask)
                    End If

                    ' 5.) MOVE UI OUT OF EDITING MODE
                    addButton.Enabled = True
                    cancelButton.Enabled = False
                    saveButton.Enabled = False
                    nav.EnableAll()
                    TaskComboBox.Enabled = True

                    ' Re-enable all task-related buttons and datagridviews
                    For Each ctrl In getAllControlsWithTag("subTaskEditingControl", Me)
                        ctrl.Enabled = True
                    Next

                ElseIf mtMode = "adding" Then

                    ' 1.) VALIDATE DATAEDITING CONTROLS
                    If Not controlsValid() Then Exit Sub

                    ' 2.) INSERT NEW ROW INTO MASTER TASK LIST
                    If Not insertMasterTask() Then
                        MessageBox.Show("Insert unsuccessful; Changes not saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    Else
                        MessageBox.Show("Successfully added " & TaskDescription_Textbox.Text & " to Master Task List")
                    End If

                    ' 3.) RELOAD DATATABLES FROM DATABASE
                    If Not loadMasterTaskListDataTable() Then
                        MessageBox.Show("Loading updated information failed; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    ' 4.) REINITIALIZE CONTROLS (based on index of newly inserted value)
                    InitializeTaskComboBox()

                    ' Changing index of main combobox will also initialize respective dataViewing control values

                    ' First, lookup most recent CustomerId added to the table
                    CRUD.ExecQuery("SELECT TaskId FROM MasterTaskList WHERE TaskId=(SELECT max(TaskId) FROM MasterTaskList)")
                    Dim newTaskId As Integer

                    If CRUD.DbDataTable.Rows.Count <> 0 And Not CRUD.HasException(True) Then

                        ' Get new TaskId if query successful
                        newTaskId = CRUD.DbDataTable.Rows(0)("TaskId")
                        ' Get new ComboBox item from datatable using newly retrieved ID
                        Dim newItem As String = getRowValueWithKeyEquals(MTL.DbDataTable, "TaskDescription", "TaskId", newTaskId)

                        ' Set ComboBox accordingly after one final check
                        If newItem <> Nothing Then
                            TaskComboBox.SelectedIndex = TaskComboBox.Items.IndexOf(newItem)
                        Else
                            TaskComboBox.SelectedIndex = TaskComboBox.Items.IndexOf(lastSelectedTask)
                        End If

                    Else
                        TaskComboBox.SelectedIndex = TaskComboBox.Items.IndexOf(lastSelectedTask)
                    End If

                    ' 5.) MOVE UI OUT OF Adding MODE
                    addButton.Enabled = True
                    cancelButton.Enabled = False
                    saveButton.Enabled = False
                    nav.EnableAll()
                    TaskComboBox.Enabled = True

                    ' Re-enable all task-related buttons and datagridviews
                    For Each ctrl In getAllControlsWithTag("subTaskEditingControl", Me)
                        ctrl.Enabled = True
                    Next

                End If

            Case DialogResult.No
                ' Continue making changes or cancel editing
        End Select

    End Sub


    Private Sub TaskDescription_Textbox_TextChanged(sender As Object, e As EventArgs) Handles TaskDescription_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        TaskDescription_Textbox.ForeColor = DefaultForeColor

        If InitialMTLValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private Sub Instructions_Textbox_TextChanged(sender As Object, e As EventArgs) Handles Instructions_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        Instructions_Textbox.ForeColor = DefaultForeColor

        If InitialMTLValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private Sub TaskType_ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TaskType_ComboBox.SelectedIndexChanged, TaskType_ComboBox.TextChanged

        If Not valuesInitialized Then Exit Sub

        TaskType_ComboBox.ForeColor = DefaultForeColor

        If InitialMTLValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub


    Private Sub TaskLabor_Textbox_TextChanged(sender As Object, e As EventArgs) Handles TaskLabor_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        InitializeTotalTaskTextbox()

    End Sub


    Private Sub TaskParts_Textbox_TextChanged(sender As Object, e As EventArgs) Handles TaskParts_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        InitializeTotalTaskTextbox()

    End Sub





    ' **************** CONTROL SUBS FOR MASTER TASK LABOR ****************


    ' Subs that handle disabling sorting on columns that are added to the DataGridViews
    Private Sub TaskLaborGridView_ColumnAdded(sender As Object, e As DataGridViewColumnEventArgs) Handles TaskLaborGridView.ColumnAdded
        e.Column.SortMode = DataGridViewColumnSortMode.NotSortable
    End Sub


    Private Sub TaskLaborGridView_SelectionChanged(sender As Object, e As EventArgs) Handles TaskLaborGridView.SelectionChanged

        TaskLaborRow = TaskLaborGridView.CurrentRow.Index

    End Sub


    Private Sub tlAddButton_Click(sender As Object, e As EventArgs) Handles tlAddButton.Click

        changeScreenHide(addMasterTaskLabor, Me)

    End Sub

    Private Sub tlDeleteButton_Click(sender As Object, e As EventArgs) Handles tlDeleteButton.Click

        If Not deleteMasterTaskLabor() Then
            MessageBox.Show("Delete unsuccessful; Changes not saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Not reinitializeDependents() Then
            MessageBox.Show("Reloading of Master Task List Unsuccessful; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

    End Sub

    Private Sub tlEditButton_Click(sender As Object, e As EventArgs) Handles tlEditButton.Click

        changeScreenHide(editMasterTaskLabor, Me)

    End Sub




    ' **************** CONTROL SUBS FOR MASTER TASK PARTS ****************


    Private Sub TaskPartsGridView_ColumnAdded(sender As Object, e As DataGridViewColumnEventArgs) Handles TaskPartsGridView.ColumnAdded
        e.Column.SortMode = DataGridViewColumnSortMode.NotSortable
    End Sub


    Private Sub TaskPartsGridView_SelectionChanged(sender As Object, e As EventArgs) Handles TaskPartsGridView.SelectionChanged

        TaskPartsRow = TaskPartsGridView.CurrentRow.Index

    End Sub


    Private Sub tpAddButton_Click(sender As Object, e As EventArgs) Handles tpAddButton.Click

        changeScreenHide(addMasterTaskPart, Me)

    End Sub


    Private Sub tpDeleteButton_Click(sender As Object, e As EventArgs) Handles tpDeleteButton.Click

        If Not deleteMasterTaskPart() Then
            MessageBox.Show("Delete unsuccessful; Changes not saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Not reinitializeDependents() Then
            MessageBox.Show("Reloading of Master Task List Unsuccessful; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

    End Sub


    Private Sub tpEditButton_Click(sender As Object, e As EventArgs) Handles tpEditButton.Click

        ' Change to masterTaskPartsMaintenance Form, and Hide (but don't close) this one
        changeScreenHide(editMasterTaskPart, Me)

    End Sub



    Private Sub masterTaskMaintenance_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        ' Check if editing/adding, and if editing/adding, check if control values changed
        If TaskDescription_Textbox.Visible And InitialMTLValues.CtrlValuesChanged() Then

            Dim decision As DialogResult = MessageBox.Show("Exit without saving changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If decision = DialogResult.No Then
                e.Cancel = True
                Exit Sub
            End If

        End If

    End Sub


End Class