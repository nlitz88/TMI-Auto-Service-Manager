Imports System.ComponentModel

Public Class addMasterTaskPart

    ' New Database Control instance for inventory (Parts) DataTable
    Private PartsDbController As New DbControl()
    Private PartRow As Integer

    ' Variable to maintain the TaskId of the current task we're adding to
    Private TaskId As Integer

    ' New Database control instance for updating, inserting, and deleting
    Private CRUD As New DbControl()

    ' Initialize instance(s) of initialValues class
    Private InitialPartValues As New InitialValues()

    'Variable to keep track of whether form fully loaded or not
    Private valuesInitialized As Boolean = True

    ' Variable that allows certain keystrokes through restricted fields
    Private allowedKeystroke As Boolean = False

    ' Boolean to keep track of whether or not this form has been closed
    Private MeClosed As Boolean = False




    ' ***************** INITIALIZATION AND CONFIGURATION SUBS *****************


    ' Function that loads Parts DataTable from Database
    Private Function loadPartsDataTable() As Boolean

        PartsDbController.ExecQuery("SELECT p.PartDescription + ' - ' + p.PartNbr as PDPN, p.PartNbr, p.PartDescription, p.PartPrice, p.ListPrice FROM Parts p ORDER BY p.PartDescription ASC")
        If PartsDbController.HasException() Then Return False

        Return True

    End Function

    ' Sub that initializes PartComboBox
    Private Sub InitializePartComboBox()

        PartComboBox.BeginUpdate()
        PartComboBox.Items.Clear()
        PartComboBox.Items.Add("Select One")
        For Each row In PartsDbController.DbDataTable.Rows
            PartComboBox.Items.Add(row("PDPN"))
        Next
        PartComboBox.EndUpdate()

    End Sub

    ' Sub that initializes all dataEditingControls corresponding with values in Parts DataTable
    Private Sub InitializePartsDataEditingControls()

        initializeControlsFromRow(PartsDbController.DbDataTable, PartRow, "dataEditingControl", "_", Me)

    End Sub



    ' Sub that calls all individual dataEditingControl initialization subs in one (These can be used individually if desired)
    Private Sub InitializeAllDataEditingControls()

        ' Automated initializations
        InitializePartsDataEditingControls()
        ' Set forecolor if not already initially default
        setForeColor(getAllControlsWithTag("dataEditingControl", Me), DefaultForeColor)

    End Sub



    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        TaskTextbox.Text = masterTaskMaintenance.GetTask()
        TaskId = masterTaskMaintenance.GetTaskId()

        ' TEST DATABASE CONNECTION FIRST
        If Not checkDbConn() Then Exit Sub

        ' LOAD DATATABLES FROM DATABASE INITIALLY
        If Not loadPartsDataTable() Then
            MessageBox.Show("Failed to connect to database; Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Then, initialize PartComboBox
        InitializePartComboBox()
        PartComboBox.SelectedIndex = 0

    End Sub

    Public Sub addMasterTaskPart_Load(sender As Object, e As EventArgs) Handles MyBase.Load



    End Sub






    ' **************** CONTROL SUBS ****************


    Private Sub PartComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles PartComboBox.SelectedIndexChanged, PartComboBox.TextChanged

        ' Ensure that PartComboBox is only attempting to initialize values when on proper selected Index
        If PartComboBox.SelectedIndex = -1 Then

            ' Have all labels and corresponding values hidden
            showHide(getAllControlsWithTag("dataLabel", Me), 0)
            showHide(getAllControlsWithTag("dataEditingControl", Me), 0)

            ' If no valid selection has been made, then they have nothing to save
            saveButton.Enabled = False

            Exit Sub

        End If

        ' First, Lookup newly changed value in respective dataTable to see if the selected value exists And Is valid
        PartRow = getDataTableRow(PartsDbController.DbDataTable, "PDPN", PartComboBox.Text)

        ' If this query DOES return a valid row index, then initialize respective controls
        If PartRow <> -1 Then

            ' Initialize corresponding controls from DataTable values
            valuesInitialized = False
            InitializeAllDataEditingControls()
            ' This form is exclusively editing only, so just after we initialize, set the initial values
            InitialPartValues.SetInitialValues(getAllControlsWithTag("dataEditingControl", Me))
            valuesInitialized = True

            ' Show labels and corresponding values
            showHide(getAllControlsWithTag("dataLabel", Me), 1)
            showHide(getAllControlsWithTag("dataEditingControl", Me), 1)

            ' If a valid selection is made, then they can save right away without making any changes.
            saveButton.Enabled = True


            'If it does = -1, that means that value Is either "Select one" Or some other anomoly
        Else

            ' Have all labels and corresponding values hidden
            showHide(getAllControlsWithTag("dataLabel", Me), 0)
            showHide(getAllControlsWithTag("dataEditingControl", Me), 0)

            ' If no valid selection has been made, then they have nothing to save
            saveButton.Enabled = False


        End If


    End Sub


    Private Sub addMasterTaskPart_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        If Not MeClosed Then

            If InitialPartValues.CtrlValuesChanged() Then

                Dim decision As DialogResult = MessageBox.Show("Cancel without saving changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If decision = DialogResult.No Then
                    e.Cancel = True
                    Exit Sub
                Else
                    MeClosed = True
                    changeScreen(masterTaskMaintenance, Me)
                End If

            Else

                MeClosed = True
                changeScreen(masterTaskMaintenance, Me)

            End If

        End If

    End Sub


    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click

        If Not MeClosed Then

            If InitialPartValues.CtrlValuesChanged() Then

                Dim decision As DialogResult = MessageBox.Show("Cancel without saving changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If decision = DialogResult.No Then
                    Exit Sub
                Else
                    MeClosed = True
                    changeScreen(masterTaskMaintenance, Me)
                End If

            Else

                MeClosed = True
                changeScreen(masterTaskMaintenance, Me)

            End If

        End If

    End Sub


    Private Sub saveButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click

        ' No confirmation for additions at this time. May implement in the future.

        ' 1.) VALIDATE DATAEDITING CONTROLS
        'If Not controlsValid() Then Exit Sub

        ' 2.) WRITE CHANGES TO DATABASE TABLE
        'If Not updateMasterTaskParts() Then
        '    MessageBox.Show("Update unsuccessful; Changes not saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub
        'End If

        ' 3.) If this is successful, then:
        '       a.) Reinitialize Dependents on masterTaskMaintenance
        '       b.) If that is successful, then change screen
        If Not masterTaskMaintenance.reinitializeDependents() Then
            MessageBox.Show("Reloading of Master Task List Unsuccessful; Old values will be reflected. Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            saveButton.Enabled = False
            Exit Sub
        End If

        MeClosed = True
        changeScreen(masterTaskMaintenance, Me)

    End Sub






    Private Sub newPartButton_Click(sender As Object, e As EventArgs) Handles newPartButton.Click

        previousScreen = Me
        changeScreenHide(inventoryMaintenance, previousScreen)

    End Sub


End Class