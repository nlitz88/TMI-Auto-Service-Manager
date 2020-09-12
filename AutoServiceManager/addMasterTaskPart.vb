Imports System.ComponentModel

Public Class addMasterTaskPart

    ' New Database Control instance for inventory (Parts) DataTable
    Private PartsDbController As New DbControl()
    Private PartRow As Integer

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


    ' Sub that will initialize/Calculate PartAmount Cost based on the product of the Quantity and Unit Price
    Private Sub InitializePartAmountTextbox()

        ' First, Validate values that calculation is based on before attempting to parse and calculate
        If validNumber("Quantity", True, Qty_Textbox.Text, String.Empty, True) And validCurrency("Unit Price", True, PartPrice_Textbox.Text, String.Empty) Then

            Dim Quantity As Decimal = Convert.ToDecimal(Qty_Textbox.Text)
            Dim Price As Decimal = Convert.ToDecimal(PartPrice_Textbox.Text)
            Dim product As Decimal = Quantity * Price

            ' Then, assign and format calculated sum
            PartAmount_Textbox.Text = String.Format("{0:0.00}", product)

        Else
            PartAmount_Textbox.Text = String.Empty
        End If

    End Sub


    ' Sub that will call formatting functions to add respective formats to already INITIALIZED DATAEDITINGCONTROLS (i.e. phone numbers, currency, etc.).
    Private Sub formatDataEditingControls()

        PartPrice_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(PartPrice_Textbox.Text))
        ListPrice_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(ListPrice_Textbox.Text))

    End Sub


    ' Sub that calls all individual dataEditingControl initialization subs in one (These can be used individually if desired)
    Private Sub InitializeAllDataEditingControls()

        ' Automated initializations
        InitializePartsDataEditingControls()
        ' Then, format dataEditingControls
        formatDataEditingControls()
        ' Then, re-initialize and format any calculation based values
        InitializePartAmountTextbox()
        ' Set forecolor if not already initially default
        setForeColor(getAllControlsWithTag("dataEditingControl", Me), DefaultForeColor)

    End Sub



    ' Public Function called after Parts table has been changed from Inventory Maintenance Form. Parts DataTable and dependent controls are re-initialized
    Public Function reInitializeParts() As Boolean

        ' LOAD DATATABLES FROM DATABASE INITIALLY
        If Not loadPartsDataTable() Then
            MessageBox.Show("Failed to connect to database; Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        ' Then, initialize PartComboBox
        InitializePartComboBox()
        PartComboBox.SelectedIndex = 0

        Return True

    End Function




    ' ***************** CRUD SUBS *****************


    Private Function InsertMasterTaskParts() As Boolean

        ' Values that will automatically be grabbed from controls and inserted:
        '   PartNumber, PartDescription, PartPrice, and ListPrice
        ' In adddition to these, we must also insert (into the row) these newly associated values:
        '   TaskId, Qty, PartAmount

        ' No exclusions, just additionalValues
        Dim additionalValues As New List(Of AdditionalValue) From {New AdditionalValue("TaskId", GetType(Int32), TaskId), New AdditionalValue("Qty", GetType(Double), Qty_Textbox.Text), New AdditionalValue("PartAmount", GetType(Decimal), PartAmount_Textbox.Text)}
        insertRow(CRUD, PartsDbController.DbDataTable, "MasterTaskParts", "_", "dataEditingControl", Me, additionalValues)

        Return True

    End Function





    ' **************** VALIDATION SUBS ****************


    ' Sub that runs validation for all form controls. Also handles error reporting
    Private Function controlsValid() As Boolean

        Dim errorMessage As String = String.Empty

        ' Use "Required" parameter to control whether or not a Null string value will cause an error to be reported


        ' Part Description
        If Not isValidLength("Part Description", False, PartDescription_Textbox.Text, 50, errorMessage) Then PartDescription_Textbox.ForeColor = Color.Red

        ' Quantity
        If Not validNumber("Quantity", False, Qty_Textbox.Text, errorMessage, True) Then Qty_Textbox.ForeColor = Color.Red

        ' Unit Price
        If Not validCurrency("Unit Price", False, PartPrice_Textbox.Text, errorMessage) Then PartPrice_Textbox.ForeColor = Color.Red

        ' List Price
        If Not validCurrency("List Price", False, ListPrice_Textbox.Text, errorMessage) Then ListPrice_Textbox.ForeColor = Color.Red


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
            validSelection = False

            Exit Sub

        End If

        ' First, Lookup newly changed value in respective dataTable to see if the selected value exists And Is valid
        PartRow = getDataTableRow(PartsDbController.DbDataTable, "PDPN", PartComboBox.Text)

        ' If this query DOES return a valid row index, then initialize respective controls
        If PartRow <> -1 Then

            ' Initialize corresponding controls from DataTable values
            valuesInitialized = False
            ' Qty is a new value introduced here that is by default 0, so set this accordingly here
            Qty_Textbox.Text = 0
            InitializeAllDataEditingControls()
            valuesInitialized = True

            ' Show labels and corresponding values
            showHide(getAllControlsWithTag("dataLabel", Me), 1)
            showHide(getAllControlsWithTag("dataEditingControl", Me), 1)

            ' If a valid selection is made, then they can save right away without making any changes.
            saveButton.Enabled = True
            validSelection = True

            ' Now that valid selection made, select next control
            PartComboBox.SelectionLength = 0
            PartDescription_Textbox.Focus()


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


    Private Sub addMasterTaskPart_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        If Not MeClosed Then

            If validSelection Then

                Dim decision As DialogResult = MessageBox.Show("Cancel without adding part?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

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

            If validSelection Then

                Dim decision As DialogResult = MessageBox.Show("Cancel without adding part?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

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
        If Not controlsValid() Then Exit Sub

        ' 2.) WRITE CHANGES TO DATABASE TABLE
        If Not InsertMasterTaskParts() Then
            MessageBox.Show("Insert unsuccessful; Changes not saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

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




    Private Sub PartDescription_Textbox_TextChanged(sender As Object, e As EventArgs) Handles PartDescription_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        PartDescription_Textbox.ForeColor = DefaultForeColor

    End Sub


    Private Sub ListPrice_Textbox_KeyDown(sender As Object, e As KeyEventArgs) Handles ListPrice_Textbox.KeyDown

        ' Check to see ctrl+A, ctrl+C, or ctrl+V were used. If so, don't worry about checking which Keys Pressed
        If ((e.KeyCode = Keys.A And e.Control) Or (e.KeyCode = Keys.C And e.Control) Or (e.KeyCode = Keys.V And e.Control)) Then
            allowedKeystroke = True
        End If

    End Sub

    Private Sub ListPrice_Textbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ListPrice_Textbox.KeyPress

        ' If certain keystroke exceptions allowed through, then skip input validation here
        If allowedKeystroke Then
            allowedKeystroke = False
            Exit Sub
        End If

        If Not currencyInputValid(ListPrice_Textbox, e.KeyChar) Then
            e.KeyChar = Chr(0)
            e.Handled = True
        End If

    End Sub

    Private Sub ListPrice_Textbox_TextChanged(sender As Object, e As EventArgs) Handles ListPrice_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        ListPrice_Textbox.ForeColor = DefaultForeColor

        ' Handles pasting in invalid values/strings
        Dim lastValidIndex As Integer = allValidChars(ListPrice_Textbox.Text, "1234567890.")
        If lastValidIndex <> -1 Then
            ListPrice_Textbox.Text = ListPrice_Textbox.Text.Substring(0, lastValidIndex)
            ListPrice_Textbox.SelectionStart = lastValidIndex
        End If

    End Sub


    Private Sub Qty_Textbox_KeyDown(sender As Object, e As KeyEventArgs) Handles Qty_Textbox.KeyDown

        ' Check to see ctrl+A, ctrl+C, or ctrl+V were used. If so, don't worry about checking which Keys Pressed
        If ((e.KeyCode = Keys.A And e.Control) Or (e.KeyCode = Keys.C And e.Control) Or (e.KeyCode = Keys.V And e.Control)) Then
            allowedKeystroke = True
        End If

    End Sub

    Private Sub Qty_Textbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Qty_Textbox.KeyPress

        ' If certain keystroke exceptions allowed through, then skip input validation here
        If allowedKeystroke Then
            allowedKeystroke = False
            Exit Sub
        End If

        If Not numericInputValid(Qty_Textbox, e.KeyChar, True) Then
            e.KeyChar = Chr(0)
            e.Handled = True
        End If

    End Sub

    Private Sub Qty_Textbox_TextChanged(sender As Object, e As EventArgs) Handles Qty_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        Qty_Textbox.ForeColor = DefaultForeColor

        ' Handles pasting in invalid values/strings
        Dim lastValidIndex As Integer = allValidChars(Qty_Textbox.Text, "1234567890")
        If lastValidIndex <> -1 Then
            Qty_Textbox.Text = Qty_Textbox.Text.Substring(0, lastValidIndex)
            Qty_Textbox.SelectionStart = lastValidIndex
        End If

        InitializePartAmountTextbox()

    End Sub


    Private Sub PartPrice_Textbox_KeyDown(sender As Object, e As KeyEventArgs) Handles PartPrice_Textbox.KeyDown

        ' Check to see ctrl+A, ctrl+C, or ctrl+V were used. If so, don't worry about checking which Keys Pressed
        If ((e.KeyCode = Keys.A And e.Control) Or (e.KeyCode = Keys.C And e.Control) Or (e.KeyCode = Keys.V And e.Control)) Then
            allowedKeystroke = True
        End If

    End Sub

    Private Sub PartPrice_Textbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PartPrice_Textbox.KeyPress

        ' If certain keystroke exceptions allowed through, then skip input validation here
        If allowedKeystroke Then
            allowedKeystroke = False
            Exit Sub
        End If

        If Not currencyInputValid(PartPrice_Textbox, e.KeyChar) Then
            e.KeyChar = Chr(0)
            e.Handled = True
        End If

    End Sub

    Private Sub PartPrice_Textbox_TextChanged(sender As Object, e As EventArgs) Handles PartPrice_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        PartPrice_Textbox.ForeColor = DefaultForeColor

        ' Handles pasting in invalid values/strings
        Dim lastValidIndex As Integer = allValidChars(PartPrice_Textbox.Text, "1234567890.")
        If lastValidIndex <> -1 Then
            PartPrice_Textbox.Text = PartPrice_Textbox.Text.Substring(0, lastValidIndex)
            PartPrice_Textbox.SelectionStart = lastValidIndex
        End If

        InitializePartAmountTextbox()

    End Sub


End Class