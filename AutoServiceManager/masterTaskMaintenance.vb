Public Class masterTaskMaintenance

    ' New Database control instances for all preliminary datatables
    Private TaskDbController As New DbControl()
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
        TaskDbController.ExecQuery("SELECT mtl.TaskId, mtl.TaskDescription, mtl.Instructions, mtl.TaskType, mtl.TaskLabor, mtl.TaskParts, mtl.TotalTask " &
                                       "FROM MasterTaskList mtl " &
                                       "WHERE Trim(mtl.TaskDescription) <> '' " &
                                       "ORDER BY mtl.TaskDescription ASC")
        If TaskDbController.HasException() Then Return False

        ' Loads datatable from TaskTypes
        TaskTypesDbController.ExecQuery("SELECT mtl.TaskType, mtl.TaskDescription FROM TaskTypes mtl ORDER BY mtl.TaskType ASC")
        If TaskTypesDbController.HasException() Then Return False

        Return True

    End Function


    ' Sub that initializes Customer ComboBox
    Private Sub InitializeCustomerComboBox()

        TaskComboBox.BeginUpdate()
        TaskComboBox.Items.Clear()
        TaskComboBox.Items.Add("Select One")
        For Each row In TaskDbController.DbDataTable.Rows
            TaskComboBox.Items.Add(row("TaskDescription"))
        Next
        TaskComboBox.EndUpdate()

    End Sub


    Private Sub masterTaskMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class