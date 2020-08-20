﻿Public Class invoiceTasks

    ' New Database control instances for Invoice Task DataTable
    Private InvTasksDbController As New DbControl()
    ' New Database control instances for all Invoice Task selection-dependent data
    Private InvTaskLaborDbController As New DbControl()
    Private InvTaskPartsDbController As New DbControl()
    ' New Database control instances for Master Task DataTable
    Private MTLDbController As New DbControl()
    ' New Database control instances for all Invoice Task selection-dependent data
    Private TaskLaborDbController As New DbControl()
    Private TaskPartsDbController As New DbControl()

    ' New Database control instance for updating, inserting, and deleting
    Private CRUD As New DbControl()

    ' Initialize instance(s) of initialValues class
    Private InitialInvTasksValues As New InitialValues()

    'Variable to keep track of whether form fully loaded or not
    Private valuesInitialized As Boolean = True

    ' Row index variables used for Invoice related DataTable lookups
    Private InvId As Long

    Private InvTaskRow As Integer
    Private InvTaskNbr As Integer
    Private InvTaskId As Integer

    ' Row indexes for use with InvTaskLabor and InvTaskParts DataGridViews
    Private InvTaskLaborRow As Integer = -1
    Private InvTaskPartsRow As Integer = -1

    ' Row index variables used for Master Task related DataTable lookups
    Private TaskRow As Integer
    Private TaskId As Integer

    Private TaskLaborRow As Integer = -1
    Private TaskPartsRow As Integer = -1

    ' Variables that store calculated values for InvTaskLabor, InvTaskParts, and InvTotalTask Values/Textboxes
    Private InvTaskLaborSum As Decimal = 0
    Private InvTaskPartsSum As Decimal = 0
    Private InvTotalTaskSum As Decimal = 0

    ' Last selected variables for reinitialization of controls from DataTables
    Private lastSelectedInvTask As String
    Private lastSelectedInvTaskLabor As String
    Private lastSelectedInvTaskPart As String

    ' Keeps track of whether or not user in "editing" or "adding" mode for various control groups
    Private mode As String

    ' Variable that allows certain keystrokes through restricted fields
    Private allowedKeystroke As Boolean = False

    ' Boolean to keep track of whether or not this form has been closed
    Private MeClosed As Boolean = False




    ' ***************** GET/SET SUBS FOR EXTERNAL FORMS *****************


    ' Retrieves current task value
    Public Function GetTask() As String
        Return InvTaskComboBox.Text
    End Function

    ' Retrieves current InvTaskId corresponding to TaskValue
    Public Function GetTaskId() As Integer
        Return InvTaskId
    End Function

    ' Retrieves current TaskNbr corresponding to current selected Task
    Public Function GetTaskNbr() As Integer
        Return InvTaskNbr
    End Function

    ' Retrieves InvTaskLaborRow
    Public Function GetTaskLaborRow() As Integer
        Return InvTaskLaborRow
    End Function

    ' Retrieves InvTaskPartsRow
    Public Function GetTaskPartsRow() As Integer
        Return InvTaskPartsRow
    End Function

    ' Retrieves InvTaskLaborDbController Db controller
    Public Function GetTaskLaborDbController() As DbControl
        Return InvTaskLaborDbController
    End Function

    ' Retrieves InvTaskPartsDbController Db controller
    Public Function GetTaskPartsDbController() As DbControl
        Return InvTaskPartsDbController
    End Function




    ' ***************** INITIALIZATION AND CONFIGURATION SUBS *****************


    ' Function that will load Invoice Tasks based on current invoice
    Private Function loadInvTaskDataTable()

        ' Loads rows from InvTask based on current invoice (indicated by InvNbr)
        InvTasksDbController.AddParams("@invid", InvId)
        InvTasksDbController.ExecQuery("SELECT CSTR(IIF(ISNULL(it.TaskNbr), 0, it.TaskNbr)) + ' - ' + IIF(ISNULL(it.TaskDescription), '', it.TaskDescription) as TNTD, " &
                                       "it.InvNbr, it.TaskNbr, it.TaskID, it.TaskDescription, it.Instructions, it.TaskLabor, it.TaskParts " &
                                       "FROM InvTask it " &
                                       "WHERE InvNbr=@invid " &
                                       "ORDER BY it.TaskNbr ASC")

        If InvTasksDbController.HasException() Then Return False

        Return True

    End Function

    ' Sub that initializes InvTaskComboBox
    Private Sub InitializeInvTaskComboBox()

        InvTaskComboBox.BeginUpdate()
        InvTaskComboBox.Items.Clear()
        InvTaskComboBox.Items.Add("Select One")
        For Each row In InvTasksDbController.DbDataTable.Rows
            InvTaskComboBox.Items.Add(row("TNTD"))
        Next
        InvTaskComboBox.EndUpdate()

    End Sub


    ' Sub that initializes all dataEditingcontrols corresponding with values from the InvTask DataTable
    Private Sub InitializeInvTaskDataEditingControls()

        initializeControlsFromRow(InvTasksDbController.DbDataTable, InvTaskRow, "dataEditingControl", "_", Me)

    End Sub

    ' Sub that initializes all dataViewingControls corresponding with values from the InvTask DataTable
    Private Sub InitializeInvTaskDataViewingControls()

        initializeControlsFromRow(InvTasksDbController.DbDataTable, InvTaskRow, "dataViewingControl", "_", Me)

    End Sub



    ' Function that will load all selection-dependent DataTables
    Private Function loadDependentDataTables()

        ' Loads rows from InvTaskLabor based on invNbr and selected TaskNbr
        InvTaskLaborDbController.AddParams("@invId", InvId)
        InvTaskLaborDbController.AddParams("@invTaskNbr", InvTaskNbr)
        InvTaskLaborDbController.ExecQuery("SELECT il.InvNbr, il.TaskNbr, il.TaskID, il.LaborCode, il.LaborDescription, il.LaborRate, il.LaborHours, il.LaborAmount " &
                                        "FROM InvLabor il " &
                                        "WHERE InvNbr=@invId AND TaskNbr=@invTaskNbr")
        If InvTaskLaborDbController.HasException() Then Return False

        ' Loads rows from InvTaskParts based on invNbr and selected TaskNbr
        InvTaskPartsDbController.AddParams("@invId", InvId)
        InvTaskPartsDbController.AddParams("@invTaskNbr", InvTaskNbr)
        InvTaskPartsDbController.ExecQuery("SELECT ip.InvNbr, ip.TaskNbr, ip.TaskID, ip.PartNbr, ip.Qty, ip.PartDescription, ip.PartPrice, ip.PartAmount, ip.ListPrice " &
                                        "FROM InvParts ip " &
                                        "WHERE InvNbr=@invId AND TaskNbr=@invTaskNbr")
        If InvTaskPartsDbController.HasException() Then Return False

        Return True

    End Function

    Private Sub InitializeInvTaskLaborGridView()

        InvTaskLaborGridView.DataSource = InvTaskLaborDbController.DbDataTable

    End Sub

    ' Sub that initializes TaskPartsGridView
    Private Sub InitializeInvTaskPartsGridView()

        InvTaskPartsGridView.DataSource = InvTaskPartsDbController.DbDataTable

    End Sub

    ' Sub that sets up both the InvTaskLaborDataGridView and InvTaskPartsDataGridView
    Private Sub SetupGridViews()

        ' Manually add DataGridView columns corresponding to only desired columns from DataTable

        ' Invoice Task Labor GridView
        InvTaskLaborGridView.AutoGenerateColumns = False
        InvTaskLaborGridView.Columns.Add(New DataGridViewTextBoxColumn() With {.HeaderText = "Description", .DataPropertyName = "LaborDescription"})
        InvTaskLaborGridView.Columns.Add(New DataGridViewTextBoxColumn() With {.HeaderText = "Rate", .DataPropertyName = "LaborRate"})
        InvTaskLaborGridView.Columns.Add(New DataGridViewTextBoxColumn() With {.HeaderText = "Hours", .DataPropertyName = "LaborHours"})
        InvTaskLaborGridView.Columns.Add(New DataGridViewTextBoxColumn() With {.HeaderText = "Amount", .DataPropertyName = "LaborAmount"})
        InvTaskLaborGridView.Columns(1).DefaultCellStyle.Format = "c"      ' Applies currency format to the cells of this column
        InvTaskLaborGridView.Columns(3).DefaultCellStyle.Format = "c"

        ' Invoice Task Parts GridView
        InvTaskPartsGridView.AutoGenerateColumns = False
        InvTaskPartsGridView.Columns.Add(New DataGridViewTextBoxColumn() With {.HeaderText = "Description", .DataPropertyName = "PartDescription"})
        InvTaskPartsGridView.Columns.Add(New DataGridViewTextBoxColumn() With {.HeaderText = "Quantity", .DataPropertyName = "Qty"})
        InvTaskPartsGridView.Columns.Add(New DataGridViewTextBoxColumn() With {.HeaderText = "Part Price", .DataPropertyName = "PartPrice"})
        InvTaskPartsGridView.Columns.Add(New DataGridViewTextBoxColumn() With {.HeaderText = "Amount", .DataPropertyName = "PartAmount"})
        InvTaskPartsGridView.Columns(2).DefaultCellStyle.Format = "c"
        InvTaskPartsGridView.Columns(3).DefaultCellStyle.Format = "c"

    End Sub


    ' Sub that will initialize/Calculate Invoice Task Labor Cost based on the total cost of all the labor codes in InvLabor with current InvNbr and TaskNbr
    Private Sub InitializeInvTaskLaborValue()

        ' All rows in InvLabor that are associated with the currently selected TaskNbr (and InvoiceNbr) will already be loaded into the datatable.
        ' So, to calculate the total, all we have to do is get the sum of the Amount Field in the Dependently loaded InvLabor DataTable
        ' Even if zero rows, shouldn't run into any issues
        For Each row In InvTaskLaborDbController.DbDataTable.Rows
            InvTaskLaborSum += row("LaborAmount")
        Next

        ' Then, assign the calculated sum
        InvTaskLabor_Value.Text = InvTaskLaborSum

    End Sub

    Private Sub InitializeInvTaskLaborTextbox()

        ' Calculate InvTaskLabor sum
        For Each row In InvTaskLaborDbController.DbDataTable.Rows
            InvTaskLaborSum += row("LaborAmount")
        Next

        InvTaskLabor_Textbox.Text = String.Format("{0:0.00}", InvTaskLaborSum)

    End Sub


    ' Sub that will initialize/Calculate Task Part Cost based on the total cost of all the parts in MasterTaskParts with current TaskId
    Private Sub InitializeInvTaskPartsValue()

        ' Calculate InvTaskParts sum
        For Each row In InvTaskPartsDbController.DbDataTable.Rows
            InvTaskPartsSum += row("PartAmount")
        Next

        ' Then, assign the calculated sum
        InvTaskParts_Value.Text = InvTaskPartsSum

    End Sub

    Private Sub InitializeInvTaskPartsTextbox()

        ' Calculate TaskParts sum
        For Each row In InvTaskPartsDbController.DbDataTable.Rows
            InvTaskPartsSum += row("PartAmount")
        Next

        InvTaskParts_Textbox.Text = String.Format("{0:0.00}", InvTaskPartsSum)

    End Sub

    ' Sub that will initialize/Calculate Total Task Cost based on the Sums found in InvTotalLaborCost and InvTotalPartsCost
    ' NOTE: must be called after InitializeInvTaskLaborValue and InitializeInvTaskPartsValue
    Private Sub InitializeInvTotalTaskValue()

        Dim InvTaskLaborCost As Decimal = Convert.ToDecimal(InvTaskLabor_Value.Text)
        Dim InvTaskPartsCost As Decimal = Convert.ToDecimal(InvTaskParts_Value.Text)
        InvTotalTaskSum = InvTaskLaborCost + InvTaskPartsCost

        ' Then, assign the calculated sum
        InvTotalTaskValue.Text = InvTotalTaskSum

    End Sub

    Private Sub InitializeInvTotalTaskTextbox()

        ' In other scenarios, we would have to validate the values that we were finding these calculations from. However, these are calculated, and will always be valid.
        Dim InvTaskLaborCost As Decimal = Convert.ToDecimal(InvTaskLabor_Textbox.Text)
        Dim InvTaskPartsCost As Decimal = Convert.ToDecimal(InvTaskParts_Textbox.Text)
        InvTotalTaskSum = InvTaskLaborCost + InvTaskPartsCost

        ' Then, assign and format calculated sum
        InvTotalTaskTextbox.Text = String.Format("{0:0.00}", InvTotalTaskSum)

    End Sub



    ' Sub that handles all initialization for dataEditingControls
    Private Sub InitializeAllDataEditingControls()

        ' Reset calculated value variables
        InvTaskLaborSum = 0
        InvTaskPartsSum = 0
        InvTotalTaskSum = 0

        ' Automated initializations
        InitializeInvTaskDataEditingControls()
        ' Then, re-initialize and format any calculation based values
        InitializeInvTaskLaborTextbox()
        InitializeInvTaskPartsTextbox()
        InitializeInvTotalTaskTextbox()
        ' Then, format dataEditingControls
        formatDataEditingControls()
        ' Set forecolor if not already initially default
        setForeColor(getAllControlsWithTag("dataEditingControl", Me), DefaultForeColor)

    End Sub

    ' Sub that handles all initialization for dataViewingControls
    Private Sub InitializeAllDataViewingControls()

        ' Reset calculated value variables
        InvTaskLaborSum = 0
        InvTaskPartsSum = 0
        InvTotalTaskSum = 0

        ' Automated initializations
        InitializeInvTaskDataViewingControls()
        ' Then, re-initialize and format any calculation based values
        InitializeInvTaskLaborValue()
        InitializeInvTaskPartsValue()
        InitializeInvTotalTaskValue()
        ' Then, format dataViewingControls
        formatDataViewingControls()

    End Sub


    ' Sub that will add formatting to already initialized dataViewingControls
    ' NOTE: these subs only format controls that don't have their formatting handled by a separate sub
    Private Sub formatDataViewingControls()

        ' These three calculation based fields are formatted here after the fact, as otherwise, TotalTask can't parse the decimal values from TaskLabor and TaskParts
        InvTaskLabor_Value.Text = FormatCurrency(InvTaskLabor_Value.Text)
        InvTaskParts_Value.Text = FormatCurrency(InvTaskParts_Value.Text)
        InvTotalTaskValue.Text = FormatCurrency(InvTotalTaskValue.Text)

    End Sub

    ' Sub that will add formatting to already initialized dataEditingControls
    Private Sub formatDataEditingControls()

        'TaskLabor_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(TaskLabor_Textbox.Text))
        'TaskParts_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(TaskParts_Textbox.Text))
        'TotalTask_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(TotalTask_Textbox.Text))

    End Sub






    ' ***************** INITIALIZATION AND CONFIGURATION SUBS (FOR MASTER TASK LIST IN "ADD MODE" *****************

    ' Will essentially need a copy of every sub that is abot this (that is initialization related)
    ' Implement and use these whenever working with values from Master Task List (I.E. whenever we're adding a new task to our invoice)


    ' Function that will load main TaskComboBox
    Private Function loadMasterTaskListDataTable()

        ' Loads datatable from MasterTaskList table
        MTLDbController.ExecQuery("SELECT mtl.TaskId, mtl.TaskDescription, mtl.Instructions, mtl.TaskLabor, mtl.TaskParts, mtl.TotalTask " &
                                       "FROM MasterTaskList mtl " &
                                       "WHERE Trim(mtl.TaskDescription) <> '' " &
                                       "ORDER BY mtl.TaskDescription ASC")

        If MTLDbController.HasException() Then Return False

        Return True

    End Function

    ' Sub that initializes TaskComboBox
    Private Sub InitializeTaskComboBox()

        TaskComboBox.BeginUpdate()
        TaskComboBox.Items.Clear()
        TaskComboBox.Items.Add("Select One")
        For Each row In MTLDbController.DbDataTable.Rows
            TaskComboBox.Items.Add(row("TaskDescription"))
        Next
        TaskComboBox.EndUpdate()

    End Sub

    ' Sub that initializes all dataEditingcontrols corresponding with values from the MasterTaskList datatable
    Private Sub InitializeMTLDataEditingControls()

        initializeControlsFromRow(MTLDbController.DbDataTable, TaskRow, "dataEditingControl", "_", Me)

    End Sub

    ' Sub that initializes all dataViewingControls corresponding with values from the MasterTaskList datatable
    Private Sub InitializeMTLDataViewingControls()

        initializeControlsFromRow(MTLDbController.DbDataTable, TaskRow, "dataViewingControl", "_", Me)

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


    ' Even though being used with Master Task related Data, we can still reuse the same DataGridViews

    Private Sub InitializeInvTaskLaborGridView()

        InvTaskLaborGridView.DataSource = TaskLaborDbController.DbDataTable

    End Sub

    ' Sub that initializes TaskPartsGridView
    Private Sub InitializeInvTaskPartsGridView()

        InvTaskPartsGridView.DataSource = TaskPartsDbController.DbDataTable

    End Sub


    ' Sub that sets up both the TaskLaborDataGridView and TaskPartsDataGridView
    Private Sub SetupGridViews()

        ' Manually add DataGridView columns corresponding to only desired columns from DataTable

        ' Task Labor GridView
        InvTaskLaborGridView.AutoGenerateColumns = False
        InvTaskLaborGridView.Columns.Add(New DataGridViewTextBoxColumn() With {.HeaderText = "Description", .DataPropertyName = "Description"})
        InvTaskLaborGridView.Columns.Add(New DataGridViewTextBoxColumn() With {.HeaderText = "Rate", .DataPropertyName = "Rate"})
        InvTaskLaborGridView.Columns.Add(New DataGridViewTextBoxColumn() With {.HeaderText = "Hours", .DataPropertyName = "Hours"})
        InvTaskLaborGridView.Columns.Add(New DataGridViewTextBoxColumn() With {.HeaderText = "Amount", .DataPropertyName = "Amount"})
        InvTaskLaborGridView.Columns(1).DefaultCellStyle.Format = "c"      ' Applies currency format to the cells of this column
        InvTaskLaborGridView.Columns(3).DefaultCellStyle.Format = "c"

        ' Task Parts GridView
        InvTaskPartsGridView.AutoGenerateColumns = False
        InvTaskPartsGridView.Columns.Add(New DataGridViewTextBoxColumn() With {.HeaderText = "Description", .DataPropertyName = "PartDescription"})
        InvTaskPartsGridView.Columns.Add(New DataGridViewTextBoxColumn() With {.HeaderText = "Quantity", .DataPropertyName = "Qty"})
        InvTaskPartsGridView.Columns.Add(New DataGridViewTextBoxColumn() With {.HeaderText = "Part Price", .DataPropertyName = "PartPrice"})
        InvTaskPartsGridView.Columns.Add(New DataGridViewTextBoxColumn() With {.HeaderText = "Amount", .DataPropertyName = "PartAmount"})
        InvTaskPartsGridView.Columns(2).DefaultCellStyle.Format = "c"
        InvTaskPartsGridView.Columns(3).DefaultCellStyle.Format = "c"

    End Sub


    ' Sub that will initialize/Calculate Task Labor Cost based on the total cost of all the labor codes in MasterTaskLabor with current TaskId
    Private Sub InitializeTaskLaborValue()

        ' All rows in MasterTaskLabor that are associated with the currently selectedTaskId will already be loaded into the datatable.
        ' So, to calculate the total, all we have to do is get the sum of the Amount Field in the Dependently loaded MasterTaskLabor DataTable
        ' Even if zero rows, shouldn't run into any issues
        For Each row In TaskLaborDbController.DbDataTable.Rows
            InvTaskLaborSum += row("Amount")
        Next

        ' Then, assign the calculated sum
        InvTaskLabor_Value.Text = InvTaskLaborSum

    End Sub

    Private Sub InitializeTaskLaborTextbox()

        ' Calculate TaskLabor sum
        For Each row In TaskLaborDbController.DbDataTable.Rows
            InvTaskLaborSum += row("Amount")
        Next

        InvTaskLabor_Textbox.Text = String.Format("{0:0.00}", InvTaskLaborSum)

    End Sub

    ' Sub that will initialize/Calculate Task Part Cost based on the total cost of all the parts in MasterTaskParts with current TaskId
    Private Sub InitializeTaskPartsValue()

        ' Calculate TaskParts sum
        For Each row In TaskPartsDbController.DbDataTable.Rows
            InvTaskPartsSum += row("PartAmount")
        Next

        ' Then, assign the calculated sum
        InvTaskParts_Value.Text = InvTaskPartsSum

    End Sub

    Private Sub InitializeTaskPartsTextbox()

        ' Calculate TaskParts sum
        For Each row In TaskPartsDbController.DbDataTable.Rows
            InvTaskPartsSum += row("PartAmount")
        Next

        InvTaskParts_Textbox.Text = String.Format("{0:0.00}", InvTaskPartsSum)

    End Sub


    ' Sub that handles all initialization for dataEditingControls
    Private Sub InitializeAllDataEditingControls()

        ' Reset calculated value variables
        InvTaskLaborSum = 0
        InvTaskPartsSum = 0
        InvTotalTaskSum = 0

        ' Automated initializations
        InitializeMTLDataEditingControls()
        ' Then, re-initialize and format any calculation based values
        InitializeTaskLaborTextbox()
        InitializeTaskPartsTextbox()
        InitializeInvTotalTaskTextbox()
        ' Then, format dataEditingControls
        formatDataEditingControls()
        ' Set forecolor if not already initially default
        setForeColor(getAllControlsWithTag("dataEditingControl", Me), DefaultForeColor)

    End Sub

    ' Sub that handles all initialization for dataViewingControls
    Private Sub InitializeAllDataViewingControls()

        ' Reset calculated value variables
        InvTaskLaborSum = 0
        InvTaskPartsSum = 0
        InvTotalTaskSum = 0

        ' Automated initializations
        InitializeMTLDataViewingControls()
        ' Then, re-initialize and format any calculation based values
        InitializeTaskLaborValue()
        InitializeTaskPartsValue()
        InitializeInvTotalTaskValue()
        ' Then, format dataViewingControls
        formatDataViewingControls()

    End Sub





    ' ***************** CRUD SUBS *****************


    ' Function that makes updateTable calls for all relevant DataTables that need updated based on changes
    Private Function updateInvTask() As Boolean

        ' Columns that will not be included in the WHERE clause the UPDATE query
        Dim excludedKeyColumns As New List(Of String) From {"TNTD", "TaskID", "TaskDescription", "Instructions", "TaskLabor", "TaskParts"}

        updateTable(CRUD, InvTasksDbController.DbDataTable, InvTaskRow, excludedKeyColumns, "InvTask", "_", "dataEditingControl", Me, New List(Of Control))
        ' Then, return exception status of CRUD controller. Do this after each call
        If CRUD.HasException() Then Return False

        ' Otherwise, return true
        Return True

    End Function


    ' Function that makes insertRow calls for all relevant DataTables
    Private Function insertInvTask() As Boolean

        '' Lookup corresponding taskType symbol for valid taskType description first.
        '' Exclude task type from updateTable, then add its swapped value as an additional value
        'Dim TaskTypeSymbol As String = getRowValueWithKey(TaskTypesDbController.DbDataTable, "TaskType", "TaskDescription", TaskType_ComboBox.Text)

        'Dim excludedControls As New List(Of Control) From {TaskType_ComboBox}
        'Dim additionalValues As New List(Of AdditionalValue) From {New AdditionalValue("TaskType", GetType(String), TaskTypeSymbol)}

        '' Then, make calls to insertRow to all relevant tables
        'insertRow(CRUD, MTL.DbDataTable, "MasterTaskList", "_", "dataEditingControl", Me, excludedControls, additionalValues)
        '' Then, return exception status of CRUD controller. Do this after each call
        'If CRUD.HasException() Then Return False

        '' Otherwise, return true
        'Return True

    End Function


    ' Function that makes deleteRow calls for all relevant DataTables
    Private Function deleteInvTask() As Boolean

        ' Columns that will not be included in the WHERE clause the query
        Dim excludedKeyColumns As New List(Of String) From {"TNTD", "TaskID", "TaskDescription", "Instructions", "TaskLabor", "TaskParts"}

        deleteRow(CRUD, InvTasksDbController.DbDataTable, InvTaskRow, excludedKeyColumns, "InvTask")
        ' Then, return exception status of CRUD controller. Do this after each call
        If CRUD.HasException() Then Return False

        ' Otherwise, return true
        Return True

    End Function




    ' ***************** CRUD subs for InvLabor and InvParts *****************


    ' Function that handles deleting for InvLabor Table (Add and Edit performed on editInvLabor/addInvLabor forms)
    Public Function deleteInvTaskLabor() As Boolean

        deleteRow(CRUD, InvTaskLaborDbController.DbDataTable, InvTaskLaborRow, New List(Of String), "InvLabor")
        If CRUD.HasException() Then Return False

        Return True

    End Function


    ' Function that handles deleting for InvParts Table (Add and Edit performed on editMInvParts/addInvParts forms)
    Public Function deleteInvTaskPart() As Boolean

        deleteRow(CRUD, InvTaskPartsDbController.DbDataTable, InvTaskPartsRow, New List(Of String), "InvParts")
        If CRUD.HasException() Then Return False

        Return True

    End Function




    ' ***************** VALIDATION SUBS *****************


    ' Sub that runs validation for all form controls. Also handles error reporting
    Private Function controlsValid() As Boolean

        Dim errorMessage As String = String.Empty

        ' Use "Required" parameter to control whether or not a Null string value will cause an error to be reported


        ' Task Description (REQUIRED)
        If Not isValidLength("Description", False, TaskDescription_Textbox.Text, 50, errorMessage) Then
            TaskDescription_Textbox.ForeColor = Color.Red
        End If

        ' Instructions
        If Not isValidLength("Instructions", False, Instructions_Textbox.Text, 255, errorMessage) Then
            Instructions_Textbox.ForeColor = Color.Red
        End If


        ' Check if any invalid input has been found
        If Not String.IsNullOrEmpty(errorMessage) Then

            MessageBox.Show(errorMessage, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False

        End If

        Return True

    End Function




    Private Sub InvoiceTasks_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' Get invoice number and date to display in InvoiceValue
        InvoiceValue.Text = invoices.GetINID()
        InvId = invoices.GetInvId()

        ' Load InvTask DataTable
        If Not loadInvTaskDataTable() Then
            MessageBox.Show("Failed to connect to database; Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Setup GridViews and initialize ComboBoxes for first time
        SetupGridViews()

        InitializeInvTaskComboBox()
        InvTaskComboBox.SelectedIndex = 0


    End Sub


    Private Sub InvTaskComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles InvTaskComboBox.SelectedIndexChanged

        ' Ensure that InvTaskComboBox is only attempting to initialize values when on proper selected Index
        If InvTaskComboBox.SelectedIndex = -1 Then

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
        InvTaskRow = getDataTableRow(InvTasksDbController.DbDataTable, "TNTD", InvTaskComboBox.Text)

        ' If this query DOES return a valid row index, then initialize respective controls
        If InvTaskRow <> -1 Then

            ' Lookup TaskNbr based on selected TaskDescription
            InvTaskNbr = InvTasksDbController.DbDataTable(InvTaskRow)("TaskNbr")

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
            InitializeInvTaskLaborGridView()
            InitializeInvTaskPartsGridView()

            valuesInitialized = True

            ' Disable/Enable tlButtons for taskLaborGridView according to if rows present or not
            If InvTaskLaborGridView.Rows.Count = 0 Then
                InvTaskLaborRow = -1
                tlDeleteButton.Enabled = False
                tlEditButton.Enabled = False
            Else
                tlDeleteButton.Enabled = True
                tlEditButton.Enabled = True
            End If

            ' Disable/Enable tlButtons for taskPartsGridView according to if rows present or not
            If InvTaskPartsGridView.Rows.Count = 0 Then
                InvTaskPartsRow = -1
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

        mode = "adding"

        ' Make TaskComboBox and label visible, and hide the others
        InvTaskComboBox.Visible = False
        InvTaskComboLabel.Visible = False

        TaskComboBox.Visible = True
        TaskComboLabel.Visible = True

        loadMasterTaskListDataTable()


        '' Initialize values for dataEditingControls
        'valuesInitialized = False
        'clearControls(getAllControlsWithTag("dataEditingControl", Me))
        '' Clear DataGridViews (on cancel/save, they will be reinitialized, so no problem)
        'TaskLaborGridView.DataSource = Nothing
        'TaskPartsGridView.DataSource = Nothing
        '' Set TaskType ComboBox selected index = -1
        'TaskType_ComboBox.SelectedIndex = -1
        'valuesInitialized = True
        '' Establish initial values. Doing this here, as unless changes are about to be made, we don't need to set initial values
        'InitialMTLValues.SetInitialValues(getAllControlsWithTag("dataEditingControl", Me))

        '' First, disable editButton, addButton, enable cancelButton, and disable nav
        'editButton.Enabled = False
        'addButton.Enabled = False
        'cancelButton.Enabled = True
        'nav.DisableAll()
        'TaskComboBox.Enabled = False

        '' Disable all task-related buttons and datagridviews
        'For Each ctrl In getAllControlsWithTag("subTaskEditingControl", Me)
        '    ctrl.Enabled = False
        'Next


        '' Get lastSelected
        'If getDataTableRow(MTL.DbDataTable, "TaskDescription", TaskComboBox.Text) <> -1 Then
        '    lastSelectedTask = TaskComboBox.Text
        'Else
        '    lastSelectedTask = "Select One"
        'End If

        'TaskComboBox.SelectedIndex = 0

        '' Hide/Show the dataViewingControls and dataEditingControls, respectively
        'showHide(getAllControlsWithTag("dataViewingControl", Me), 0)
        'showHide(getAllControlsWithTag("dataEditingControl", Me), 1)
        'showHide(getAllControlsWithTag("dataLabel", Me), 1)
        'showHide(getAllControlsWithTag("subTaskEditingControl", Me), 1)

    End Sub


    Private Sub deleteButton_Click(sender As Object, e As EventArgs) Handles deleteButton.Click

        Dim decision As DialogResult = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        Select Case decision
            Case DialogResult.Yes

                ' 1.) Delete value from database
                If Not deleteInvTask() Then
                    MessageBox.Show("Delete unsuccessful; Changes not saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show("Successfully deleted " & TaskDescription_Textbox.Text & " from invoice")
                End If

                ' 2.) RELOAD MASTERTASKLIST DATATABLE FROM DATABASE
                If Not loadInvTaskDataTable() Then
                    MessageBox.Show("Loading updated information failed; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

                ' 3.) REINITIALIZE CONTROLS (Based on the selected index)
                InitializeInvTaskComboBox()
                InvTaskComboBox.SelectedIndex = 0

                ' 4.) RESTORE USER CONTROLS TO NON-EDITING/SELECTING STATE
                InvTaskComboBox.Enabled = True
                addButton.Enabled = True
                cancelButton.Enabled = False
                saveButton.Enabled = False

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
        InitialInvTasksValues.SetInitialValues(getAllControlsWithTag("dataEditingControl", Me))

        ' Store the last selected item in the ComboBox (in case update fails and it must revert)
        lastSelectedInvTask = InvTaskComboBox.Text

        ' Disable editButton, disable addButton, enable cancel button, disable navigation, and disable main selection combobox
        editButton.Enabled = False
        addButton.Enabled = False
        cancelButton.Enabled = True
        InvTaskComboBox.Enabled = False

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
        If InitialInvTasksValues.CtrlValuesChanged() Then

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
            InvTaskComboBox.Enabled = True

            ' Re-enable all task-related buttons and datagridviews
            For Each ctrl In getAllControlsWithTag("subTaskEditingControl", Me)
                ctrl.Enabled = True
            Next

            ' Show/Hide the dataViewingControls and dataEditingControls, respectively
            showHide(getAllControlsWithTag("dataViewingControl", Me), 1)
            showHide(getAllControlsWithTag("dataEditingControl", Me), 0)
            showHide(getAllControlsWithTag("taskEditingButton", Me), 0)

        ElseIf mode = "adding" Then

            ' 1.) SET CustomerComboBox BACKK TO LAST SELECTED ITEM/INDEX
            InvTaskComboBox.SelectedIndex = InvTaskComboBox.Items.IndexOf(lastSelectedInvTask)

            ' 2.) IF LAST SELECTED WAS "SELECT ONE", Then simulate functionality from combobox text/selectedIndex changed
            If lastSelectedInvTask = "Select One" Then
                InvTaskComboBox_SelectedIndexChanged(InvTaskComboBox, New EventArgs())
            End If

            ' 3.) RESTORE USER CONTROLS TO NON-ADDING STATE (only those that are controlled by "adding")
            InvTaskComboBox.Enabled = True
            addButton.Enabled = True
            cancelButton.Enabled = False
            saveButton.Enabled = False

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

                If mode = "editing" Then

                    ' 1.) VALIDATE DATAEDITING CONTROLS
                    If Not controlsValid() Then Exit Sub

                    ' 2.) UPDATE MASTER TASK LIST VALUES
                    If Not updateInvTask() Then
                        MessageBox.Show("Update unsuccessful; Changes not saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    Else
                        MessageBox.Show("Successfully updated invoice task")
                    End If

                    ' 3.) RELOAD DATATABLES FROM DATABASE
                    If Not loadInvTaskDataTable() Then
                        MessageBox.Show("Loading updated information failed; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If

                    ' 4.) REINITIALIZE CONTROLS FROM THIS POINT (still from selection index, however)
                    InitializeInvTaskComboBox()
                    ' Look up new ComboBox value corresponding to the new value in the datatable and set the selected index of the re-initialized ComboBox accordingly
                    ' If update failed, then revert selected back to lastSelected
                    Dim updatedItem As String = getRowValueWithKeyEquals(InvTasksDbController.DbDataTable, "TNTD", "TaskNbr", InvTaskNbr)
                    If updatedItem <> Nothing Then
                        InvTaskComboBox.SelectedIndex = InvTaskComboBox.Items.IndexOf(updatedItem)
                    Else
                        InvTaskComboBox.SelectedIndex = InvTaskComboBox.Items.IndexOf(lastSelectedInvTask)
                    End If

                    ' 5.) MOVE UI OUT OF EDITING MODE
                    addButton.Enabled = True
                    cancelButton.Enabled = False
                    saveButton.Enabled = False
                    InvTaskComboBox.Enabled = True

                    ' Re-enable all task-related buttons and datagridviews
                    For Each ctrl In getAllControlsWithTag("subTaskEditingControl", Me)
                        ctrl.Enabled = True
                    Next

                ElseIf mode = "adding" Then

                    '' 1.) VALIDATE DATAEDITING CONTROLS
                    'If Not controlsValid() Then Exit Sub

                    '' 2.) INSERT NEW ROW INTO MASTER TASK LIST
                    'If Not insertMasterTask() Then
                    '    MessageBox.Show("Insert unsuccessful; Changes not saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '    Exit Sub
                    'Else
                    '    MessageBox.Show("Successfully added " & TaskDescription_Textbox.Text & " to Master Task List")
                    'End If

                    '' 3.) RELOAD DATATABLES FROM DATABASE
                    'If Not loadMasterTaskListDataTable() Then
                    '    MessageBox.Show("Loading updated information failed; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'End If

                    '' 4.) REINITIALIZE CONTROLS (based on index of newly inserted value)
                    'InitializeTaskComboBox()

                    '' Changing index of main combobox will also initialize respective dataViewing control values

                    '' First, lookup most recent CustomerId added to the table
                    'CRUD.ExecQuery("SELECT TaskId FROM MasterTaskList WHERE TaskId=(SELECT max(TaskId) FROM MasterTaskList)")
                    'Dim newTaskId As Integer

                    'If CRUD.DbDataTable.Rows.Count <> 0 And Not CRUD.HasException(True) Then

                    '    ' Get new TaskId if query successful
                    '    newTaskId = CRUD.DbDataTable.Rows(0)("TaskId")
                    '    ' Get new ComboBox item from datatable using newly retrieved ID
                    '    Dim newItem As String = getRowValueWithKeyEquals(MTL.DbDataTable, "TaskDescription", "TaskId", newTaskId)

                    '    ' Set ComboBox accordingly after one final check
                    '    If newItem <> Nothing Then
                    '        TaskComboBox.SelectedIndex = TaskComboBox.Items.IndexOf(newItem)
                    '    Else
                    '        TaskComboBox.SelectedIndex = TaskComboBox.Items.IndexOf(lastSelectedTask)
                    '    End If

                    'Else
                    '    TaskComboBox.SelectedIndex = lastSelectedTask
                    'End If

                    '' 5.) MOVE UI OUT OF Adding MODE
                    'addButton.Enabled = True
                    'cancelButton.Enabled = False
                    'saveButton.Enabled = False
                    'nav.EnableAll()
                    'TaskComboBox.Enabled = True

                    '' Re-enable all task-related buttons and datagridviews
                    'For Each ctrl In getAllControlsWithTag("subTaskEditingControl", Me)
                    '    ctrl.Enabled = True
                    'Next

                End If

            Case DialogResult.No
                ' Continue making changes or cancel editing
        End Select

    End Sub






    Private Sub InvoiceTasks_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If Not MeClosed Then

            ' Check if editing/adding, and if editing/adding, check if control values changed
            If TaskDescription_Textbox.Visible And InitialInvTasksValues.CtrlValuesChanged() Then

                Dim decision As DialogResult = MessageBox.Show("Return to invoice without saving changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If decision = DialogResult.No Then
                    e.Cancel = True
                    Exit Sub
                Else
                    MeClosed = True
                    changeScreen(invoices, Me)
                End If

            Else

                MeClosed = True
                changeScreen(invoices, Me)

            End If

        End If

    End Sub

    Private Sub returnButton_Click(sender As Object, e As EventArgs) Handles returnButton.Click

        If Not MeClosed Then

            ' Check if editing/adding, and if editing/adding, check if control values changed
            If TaskDescription_Textbox.Visible And InitialInvTasksValues.CtrlValuesChanged() Then

                Dim decision As DialogResult = MessageBox.Show("Return to invoice without saving changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If decision = DialogResult.No Then
                    Exit Sub
                Else
                    MeClosed = True
                    changeScreen(invoices, Me)
                End If

            Else

                MeClosed = True
                changeScreen(invoices, Me)

            End If

        End If

    End Sub



    Private Sub TaskDescription_Textbox_TextChanged(sender As Object, e As EventArgs) Handles TaskDescription_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        TaskDescription_Textbox.ForeColor = DefaultForeColor

        If InitialInvTasksValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub

    Private Sub Instructions_Textbox_TextChanged(sender As Object, e As EventArgs) Handles Instructions_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        Instructions_Textbox.ForeColor = DefaultForeColor

        If InitialInvTasksValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub




    ' **************** CONTROL SUBS FOR INVOICE TASK LABOR ****************


    Private Sub InvTaskLaborGridView_ColumnAdded(sender As Object, e As DataGridViewColumnEventArgs) Handles InvTaskLaborGridView.ColumnAdded
        e.Column.SortMode = DataGridViewColumnSortMode.NotSortable
    End Sub

    Private Sub TaskLaborGridView_SelectionChanged(sender As Object, e As EventArgs) Handles InvTaskLaborGridView.SelectionChanged

        InvTaskLaborRow = InvTaskLaborGridView.CurrentRow.Index

    End Sub



    ' **************** CONTROL SUBS FOR INVOICE TASK PARTS ****************


    Private Sub TaskPartsGridView_SelectionChanged(sender As Object, e As EventArgs) Handles InvTaskPartsGridView.SelectionChanged

        InvTaskPartsRow = InvTaskPartsGridView.CurrentRow.Index

    End Sub

    Private Sub InvTaskPartsGridView_ColumnAdded(sender As Object, e As DataGridViewColumnEventArgs) Handles InvTaskPartsGridView.ColumnAdded
        e.Column.SortMode = DataGridViewColumnSortMode.NotSortable
    End Sub


End Class