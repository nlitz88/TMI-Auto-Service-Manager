Public Class invoiceTasks

    ' New Database control instances for all preliminary datatables
    Private InvTasksDbController As New DbControl()
    ' New Database control instances for all selection-dependent data
    Private InvTaskLaborDbController As New DbControl()
    Private InvTaskPartsDbController As New DbControl()
    ' New Database control instance for updating, inserting, and deleting
    Private CRUD As New DbControl()

    ' Initialize instance(s) of initialValues class
    Private InitialInvTasksValues As New InitialValues()

    'Variable to keep track of whether form fully loaded or not
    Private valuesInitialized As Boolean = True

    ' Row index variables used for DataTable lookups
    Private InvId As Long

    Private InvTaskRow As Integer
    Private InvTaskId As Integer

    ' Row indexes for use with InvTaskLabor and InvTaskParts DataGridViews
    Private InvTaskLaborRow As Integer = -1
    Private InvTaskPartsRow As Integer = -1

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
        InitializeInvTaskComboBox()



    End Sub


    Private Sub InvoiceTasks_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
End Class