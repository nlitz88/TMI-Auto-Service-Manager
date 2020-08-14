Imports System.ComponentModel

Public Class addMasterTaskLabor

    ' New Database Control instance for LaborCodes DataTable
    Private LaborCodesDbController As New DbControl()
    Private LaborCodesRow As Integer

    ' Variable to maintain the TaskId of the current task we're adding to
    Private TaskId As Integer

    ' New Database control instance for updating, inserting, and deleting
    Private CRUD As New DbControl()

    ' Variable to track whether or not current selection is valid.
    ' In this form, this will be used in place of initialvalues to determine whether or not prompt user before cancelling/Closing
    Private validSelection As Boolean

    'Variable to keep track of whether form fully loaded or not
    Private valuesInitialized As Boolean = True

    ' Variable that allows certain keystrokes through restricted fields
    Private allowedKeystroke As Boolean = False

    ' Boolean to keep track of whether or not this form has been closed
    Private MeClosed As Boolean = False




    ' ***************** INITIALIZATION AND CONFIGURATION SUBS *****************


    ' Function that loads LaborCodes DataTable from Database
    Private Function loadLaborCodesDataTable() As Boolean

        LaborCodesDbController.ExecQuery("SELECT lc.Description + ' - ' + lc.LaborCode as LDLC, lc.LaborCode, lc.Description, lc.Rate, lc.Hours, lc.Amount FROM LaborCodes lc ORDER BY lc.Description ASC")
        If LaborCodesDbController.HasException() Then Return False

        Return True

    End Function


    ' Sub that initializes LaborCodesCom
    Private Sub InitializeLaborCodesComboBox()

        LaborCodesComboBox.BeginUpdate()
        LaborCodesComboBox.Items.Clear()
        LaborCodesComboBox.Items.Add("Select One")
        For Each row In LaborCodesDbController.DbDataTable.Rows
            LaborCodesComboBox.Items.Add(row("LDLC"))
        Next
        LaborCodesComboBox.EndUpdate()

    End Sub


    ' Sub that initializes all dataEditingControls corresponding with values in LaborCodes DataTable
    Private Sub InitializeLaborCodesDataEditingControls()

        initializeControlsFromRow(LaborCodesDbController.DbDataTable, LaborCodesRow, "dataEditingControl", "_", Me)

    End Sub


    ' Sub that will initialize/Calculate Amount Cost based on the product of Rate and Hours
    Private Sub InitializeAmountTextbox()

        ' First, Validate values that calculation is based on before attempting to parse and calculate
        If validCurrency("Rate", True, Rate_Textbox.Text, String.Empty) And validNumber("Hours", True, Hours_Textbox.Text, String.Empty) Then

            Dim Rate As Decimal = Convert.ToDecimal(Rate_Textbox.Text)
            Dim Hours As Decimal = Convert.ToDecimal(Hours_Textbox.Text)
            Dim product As Decimal = Rate * Hours

            ' Then, assign and format calculated product
            Amount_Textbox.Text = String.Format("{0:0.00}", product)

        Else
            Amount_Textbox.Text = String.Empty
        End If

    End Sub


    ' Sub that will call formatting functions to add respective formats to already INITIALIZED DATAEDITINGCONTROLS (i.e. phone numbers, currency, etc.).
    Private Sub formatDataEditingControls()

        Rate_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(Rate_Textbox.Text))

    End Sub


    ' Sub that handles all initialization for dataEditingControls
    Private Sub InitializeAllDataEditingControls()

        ' Automated initializations
        InitializeLaborCodesDataEditingControls()
        ' Then, format dataEditingControls
        formatDataEditingControls()
        ' Then, re-initialize and format any calculation based values
        InitializeAmountTextbox()
        ' Set forecolor if not already initially default
        setForeColor(getAllControlsWithTag("dataEditingControl", Me), DefaultForeColor)

    End Sub


    ' Public Function called after LaborCodes table has been changed from LaborCodes Maintenance Form. LaborCodes DataTable and dependent controls are re-initialized
    Public Function reInitializeLaborCodes() As Boolean

        ' LOAD DATATABLES FROM DATABASE INITIALLY
        If Not loadLaborCodesDataTable() Then
            MessageBox.Show("Failed to connect to database; Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        ' Then, initialize PartComboBox
        InitializeLaborCodesComboBox()
        LaborCodesComboBox.SelectedIndex = 0

        Return True

    End Function




    ' ***************** CRUD SUBS *****************


    Private Function InsertMasterTaskLabor() As Boolean

        ' Values that will automatically be grabbed from controls and inserted:
        '   LaborCode, Description, Rate, Hours, Amount
        ' In adddition to these, we must also insert (into the row) these newly associated values:
        '   TaskId

        ' No exclusions, just additionalValues
        Dim additionalValues As New Dictionary(Of String, Object) From {{"TaskId", TaskId}}

        insertRow(CRUD, LaborCodesDbController.DbDataTable, "MasterTaskLabor", "_", "dataEditingControl", Me, additionalValues)

        Return True

    End Function




    ' **************** VALIDATION SUBS ****************


    ' Sub that runs validation for all form controls. Also handles error reporting
    Private Function controlsValid() As Boolean

        Dim errorMessage As String = String.Empty

        ' Use "Required" parameter to control whether or not a Null string value will cause an error to be reported


        ' Description
        If Not isValidLength("Description", False, Description_Textbox.Text, 100, errorMessage) Then Description_Textbox.ForeColor = Color.Red

        ' Rate
        If Not validCurrency("Rate", False, Rate_Textbox.Text, errorMessage) Then Rate_Textbox.ForeColor = Color.Red

        ' Hours
        If Not validNumber("Hours", False, Hours_Textbox.Text, errorMessage) Then Hours_Textbox.ForeColor = Color.Red


        ' Check if any invalid input has been found
        If Not String.IsNullOrEmpty(errorMessage) Then

            MessageBox.Show(errorMessage, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False

        End If

        Return True

    End Function




    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        TaskTextbox.Text = masterTaskMaintenance.GetTask()
        TaskId = masterTaskMaintenance.GetTaskId()

        ' TEST DATABASE CONNECTION FIRST
        If Not checkDbConn() Then Exit Sub

        ' LOAD DATATABLES FROM DATABASE INITIALLY
        If Not loadLaborCodesDataTable() Then
            MessageBox.Show("Failed to connect to database; Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Then, initialize LaborCodesComboBox
        InitializeLaborCodesComboBox()
        LaborCodesComboBox.SelectedIndex = 0


    End Sub

    Private Sub addMasterTaskLabor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub




    ' **************** CONTROL SUBS ****************


    Private Sub LaborCodesComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LaborCodesComboBox.SelectedIndexChanged, LaborCodesComboBox.TextChanged

        ' Ensure that LaborCodesComboBox is only attempting to initialize values when on proper selected Index
        If LaborCodesComboBox.SelectedIndex = -1 Then

            ' Have all labels and corresponding values hidden
            showHide(getAllControlsWithTag("dataLabel", Me), 0)
            showHide(getAllControlsWithTag("dataEditingControl", Me), 0)

            ' If no valid selection has been made, then they have nothing to save
            saveButton.Enabled = False
            validSelection = False

            Exit Sub

        End If

        ' First, Lookup newly changed value in respective dataTable to see if the selected value exists And Is valid
        LaborCodesRow = getDataTableRow(LaborCodesDbController.DbDataTable, "LDLC", LaborCodesComboBox.Text)

        ' If this query DOES return a valid row index, then initialize respective controls
        If LaborCodesRow <> -1 Then

            ' Initialize corresponding controls from DataTable values
            valuesInitialized = False
            InitializeAllDataEditingControls()
            valuesInitialized = True

            ' Show labels and corresponding values
            showHide(getAllControlsWithTag("dataLabel", Me), 1)
            showHide(getAllControlsWithTag("dataEditingControl", Me), 1)

            ' If a valid selection is made, then they can save right away without making any changes.
            saveButton.Enabled = True
            validSelection = True


            'If it does = -1, that means that value Is either "Select one" Or some other anomoly
        Else

            ' Have all labels and corresponding values hidden
            showHide(getAllControlsWithTag("dataLabel", Me), 0)
            showHide(getAllControlsWithTag("dataEditingControl", Me), 0)

            ' If no valid selection has been made, then they have nothing to save
            saveButton.Enabled = False
            validSelection = False


        End If

    End Sub

    Private Sub addMasterTaskLabor_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click

    End Sub

    Private Sub saveButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click

    End Sub
End Class