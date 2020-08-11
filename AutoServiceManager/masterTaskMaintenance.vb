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
    Private TaskLaborRow As Integer
    Private TaskPartsRow As Integer
    ' Row index for use with TaskType ComboBox
    Private TaskTypeRow As Integer

    ' Last selected variables for reinitialization of controls from DataTables
    Private lastSelectedTask As String
    Private lastSelectedTaskLabor As String
    Private lastSelectedTaskPart As String

    ' Keeps track of whether or not user in "editing" or "adding" mode for various control groups
    Private mtMode As String
    Private tlMode As String
    Private tpMode As String

    ' Variable that allows certain keystrokes through restricted fields
    Private allowedKeystroke As Boolean = False




    ' ***************** GET/SET SUBS FOR EXTERNAL FORMS *****************


    Public Function GetMode(ByVal mode As String) As String
        Select Case mode
            Case "mtMode"
                Return mtMode
            Case "tlMode"
                Return tlMode
            Case "tpMode"
                Return tpMode
            Case Else
                Return String.Empty
        End Select
    End Function

    Public Function GetTask() As String
        Return TaskComboBox.Text
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

    ' Sub that initializes TaskLaborGridView
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
        Dim sum As Decimal = 0
        ' Even if zero rows, shouldn't run into any issues
        For Each row In TaskLaborDbController.DbDataTable.Rows
            sum += row("Amount")
        Next

        ' Then, assign the calculated sum
        TaskLabor_Value.Text = sum

    End Sub

    Private Sub InitializeTaskLaborTextbox()

        ' Calculate TaskLabor sum
        Dim sum As Decimal = 0
        For Each row In TaskLaborDbController.DbDataTable.Rows
            sum += row("Amount")
        Next

        TaskLabor_Textbox.Text = String.Format("{0:0.00}", sum)

    End Sub

    ' Sub that will initialize/Calculate Task Part Cost based on the total cost of all the parts in MasterTaskParts with current TaskId
    Private Sub InitializeTaskPartsValue()

        ' Calculate TaskParts sum
        Dim sum As Decimal = 0
        For Each row In TaskPartsDbController.DbDataTable.Rows
            sum += row("PartAmount")
        Next

        ' Then, assign the calculated sum
        TaskParts_Value.Text = sum

    End Sub

    Private Sub InitializeTaskPartsTextbox()

        ' Calculate TaskParts sum
        Dim sum As Decimal = 0
        For Each row In TaskPartsDbController.DbDataTable.Rows
            sum += row("PartAmount")
        Next

        TaskParts_Textbox.Text = String.Format("{0:0.00}", sum)

    End Sub

    ' Sub that will initialize/Calculate Total Task Cost based on the Sums found in TotalLaborCost and TotalPartsCost
    ' NOTE: must be called after InitializeTaskLaborValue and InitializeTaskPartsValue
    Private Sub InitializeTotalTaskValue()

        Dim TaskLaborCost As Decimal = Convert.ToDecimal(TaskLabor_Value.Text)
        Dim TaskPartsCost As Decimal = Convert.ToDecimal(TaskParts_Value.Text)
        Dim sum As Decimal = TaskLaborCost + TaskPartsCost

        ' Then, assign the calculated sum
        TotalTask_Value.Text = sum

    End Sub

    Private Sub InitializeTotalTaskTextbox()

        ' In other scenarios, we would have to validate the values that we were finding these calculations from. However, becauase these values are calculated.
        Dim TaskLaborCost As Decimal = Convert.ToDecimal(TaskLabor_Textbox.Text)
        Dim TaskPartsCost As Decimal = Convert.ToDecimal(TaskParts_Textbox.Text)
        Dim sum As Decimal = TaskLaborCost + TaskPartsCost

        ' Then, assign and format calculated sum
        TotalTask_Textbox.Text = String.Format("{0:0.00}", sum)

    End Sub



    ' Sub that handles all initialization for dataEditingControls
    Private Sub InitializeAllDataEditingControls()

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

        ' Load MasterTaskList DataTable
        If Not loadMasterTaskListDataTable() Then
            MessageBox.Show("Failed to connect to database; Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Initialize TaskComboBox and all other preliminary ComboBoxes for the first time
        SetupGridViews()
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
            showHide(getAllControlsWithTag("taskEditingButton", Me), 0)
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
            Console.WriteLine(TaskId)

            ' Initialize corresponding controls from DataTable values
            valuesInitialized = False
            ' Load TaskParts and TaskLabor datatables based on selected TaskId, then Initialize corresponding GridViews
            loadDependentDataTables()
            ' Initialize all dataEditingControls (must do this after dependent datatables loaded, however)
            ' This is because controls like TaskLaborCost (for instance) are calculated from those tables
            InitializeAllDataViewingControls()
            ' Initialize corresponding DataGridViews
            InitializeTaskLaborGridView()
            InitializeTaskPartsGridView()

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
            showHide(getAllControlsWithTag("taskEditingButton", Me), 0)
            ' Disable editing button
            editButton.Enabled = False
            deleteButton.Enabled = False

        End If

    End Sub


    Private Sub deleteButton_Click(sender As Object, e As EventArgs) Handles deleteButton.Click

        Dim decision As DialogResult = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        Select Case decision
            Case DialogResult.Yes

                ' 1.) Delete value from database
                'If Not deleteAll() Then
                '    MessageBox.Show("Delete unsuccessful; Changes not saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Else
                '    MessageBox.Show("Successfully deleted " & TaskComboBox.Text & " from Customers")
                'End If

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

        ' Show/Hide various control types accordingly
        showHide(getAllControlsWithTag("dataViewingControl", Me), 0)
        showHide(getAllControlsWithTag("dataEditingControl", Me), 1)
        showHide(getAllControlsWithTag("taskEditingButton", Me), 1)

    End Sub


    Private Sub TaskLaborGridView_SelectionChanged(sender As Object, e As EventArgs) Handles TaskLaborGridView.SelectionChanged

        TaskLaborRow = TaskLaborGridView.CurrentRow.Index

    End Sub

    Private Sub TaskPartsGridView_SelectionChanged(sender As Object, e As EventArgs) Handles TaskPartsGridView.SelectionChanged

        TaskPartsRow = TaskPartsGridView.CurrentRow.Index

    End Sub



    ' **************** CONTROL SUBS FOR MASTER TASK LABOR ****************

    ' Subs that handle disabling sorting on columns that are added to the DataGridViews
    Private Sub TaskLaborGridView_ColumnAdded(sender As Object, e As DataGridViewColumnEventArgs) Handles TaskLaborGridView.ColumnAdded
        e.Column.SortMode = DataGridViewColumnSortMode.NotSortable
    End Sub
    Private Sub TaskPartsGridView_ColumnAdded(sender As Object, e As DataGridViewColumnEventArgs) Handles TaskPartsGridView.ColumnAdded
        e.Column.SortMode = DataGridViewColumnSortMode.NotSortable
    End Sub



    ' **************** CONTROL SUBS FOR MASTER TASK PARTS ****************


    Private Sub tlAddButton_Click(sender As Object, e As EventArgs) Handles tlAddButton.Click

        tlMode = "adding"

        ' Change to masterTaskPartsMaintenance Form, and Hide (but don't close) this one
        previousScreen = Me
        changeScreenHide(masterTaskPartsMaintenance, Me)

    End Sub


    Private Sub tlEditButton_Click(sender As Object, e As EventArgs) Handles tlEditButton.Click

        tlMode = "editing"

    End Sub


End Class