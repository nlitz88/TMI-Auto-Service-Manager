Imports System.ComponentModel

Public Class editMasterTaskPart

    ' DataTable that will maintain the DataTable passed to it from masterTaskMainentance
    Dim TaskPartsDataTable As DataTable
    Dim TaskPartsRow As Integer

    ' Boolean to keep track of whether or not this form has been closed
    Private MeClosed As Boolean = False

    ' Initialize instance(s) of initialValues class
    Private InitialPartValues As New InitialValues()

    'Variable to keep track of whether form fully loaded or not
    Private valuesInitialized As Boolean = True

    ' Variable that allows certain keystrokes through restricted fields
    Private allowedKeystroke As Boolean = False




    ' ***************** INITIALIZATION AND CONFIGURATION SUBS *****************


    ' No need for DataTable loading functions here, as this form is entirely dependent on the DataTable from masterTaskMaintenance


    ' Sub that initializes all dataEditingcontrols corresponding with values from the MasterTaskParts datatable
    Private Sub InitializeTaskPartsDataEditingControls()

        initializeControlsFromRow(TaskPartsDataTable, TaskPartsRow, "dataEditingControl", "_", Me)

    End Sub


    ' Sub that will initialize/Calculate Total Task Cost based on the product of the Quantity and Unit Price
    Private Sub InitializeTotalTaskTextbox()

        ' In other scenarios, we would have to validate the values that we were finding these calculations from. However, becauase these values are calculated.
        Dim Quantity As Decimal = Convert.ToDecimal(Qty_Textbox.Text)
        Dim Price As Decimal = Convert.ToDecimal(PartPrice_Textbox.Text)
        Dim product As Decimal = Quantity * Price

        ' Then, assign and format calculated sum
        PartAmount_Textbox.Text = String.Format("{0:0.00}", product)

    End Sub



    ' Sub that will call formatting functions to add respective formats to already INITIALIZED DATAEDITINGCONTROLS (i.e. phone numbers, currency, etc.).
    Private Sub formatDataEditingControls()

        PartPrice_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(PartPrice_Textbox.Text))
        ListPrice_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(ListPrice_Textbox.Text))

    End Sub


    ' Sub that handles all initialization for dataEditingControls
    Private Sub InitializeAllDataEditingControls()

        ' Automated initializations
        InitializeTaskPartsDataEditingControls()
        'ReplaceTaskTypeComboBox()
        ' Then, re-initialize and format any calculation based values
        InitializeTotalTaskTextbox()
        ' Then, format dataEditingControls
        formatDataEditingControls()
        ' Set forecolor if not already initially default
        setForeColor(getAllControlsWithTag("dataEditingControl", Me), DefaultForeColor)

    End Sub




    ' **************** VALIDATION SUBS ****************


    ' Sub that runs validation for all form controls. Also handles error reporting
    Private Function controlsValid() As Boolean

        Dim errorMessage As String = String.Empty

        ' Use "Required" parameter to control whether or not a Null string value will cause an error to be reported


        ' CONSIDER ADDING VALIDATION HERE THAT PREVENTS USER FROM ENTERING EXACT DUPLICATE PART TO TASK
        '    - however, might not need this really, as duplicate rows will just be treated as the same until one changes. Not a huge deal

        ' Part Description
        If Not isValidLength("Part Description", False, PartDescription_Textbox.Text, 50, errorMessage) Then PartDescription_Textbox.ForeColor = Color.Red

        ' Quantity
        If Not validNumber("Quantity", True, Qty_Textbox.Text, errorMessage) Then Qty_Textbox.ForeColor = Color.Red

        ' Unit Price
        If Not validCurrency("Unit Price", False, PartPrice_Textbox.Text, errorMessage) Then PartPrice_Textbox.ForeColor = Color.Red


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

        ' Get TaskPartsDataTable and respective row from masterTaskMaintenance
        TaskPartsDataTable = masterTaskMaintenance.GetTaskPartsDataTable()
        TaskPartsRow = masterTaskMaintenance.GetTaskPartsRow()


    End Sub

    Private Sub masterTaskPartsMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        TaskTextbox.Text = masterTaskMaintenance.GetTask()

        ' For the editing forms, we won't be initializing our dataEditingControls from a selection. Instead, we will initialize them just once on load
        ' Initialize all DataEditing Controls
        InitializeAllDataEditingControls()


    End Sub





    ' **************** CONTROL SUBS ****************


    Private Sub applyButton_Click(sender As Object, e As EventArgs) Handles applyButton.Click



    End Sub



    Private Sub masterTaskPartsMaintenance_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        If Not MeClosed Then

            Dim decision As DialogResult = MessageBox.Show("Cancel without applying changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If decision = DialogResult.No Then
                e.Cancel = True
                Exit Sub
            Else
                MeClosed = True
                changeScreen(previousScreen, Me)
            End If

        End If

    End Sub

    Private Sub backButton_Click(sender As Object, e As EventArgs) Handles backButton.Click

        If Not MeClosed Then

            Dim decision As DialogResult = MessageBox.Show("Cancel without applying changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If decision = DialogResult.No Then
                Exit Sub
            Else
                MeClosed = True
                changeScreen(previousScreen, Me)
            End If

        End If

    End Sub


End Class