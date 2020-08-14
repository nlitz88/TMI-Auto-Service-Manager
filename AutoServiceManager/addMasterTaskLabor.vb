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





    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.



    End Sub

    Private Sub addMasterTaskLabor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub



End Class