﻿Imports System.ComponentModel

Public Class mfgMaintenance

    ' New Database control instances for manufacturer datatable
    Private AutoManufacturersDbController As New DbControl()
    ' New Database control instance for updating various tables
    Private updateController As New DbControl()

    ' Initialize new lists to store certain row values of datatables (easily sorted and BINARY SEARCHED FOR SPEED)
    Private AutoManufacturersList As List(Of Object)

    ' Initialize instance(s) of initialValues class
    Private InitialAutoManufacturersValues As New InitialValues()

    'Variable to keep track of whether form fully loaded or not
    Private valuesInitialized As Boolean = False

    ' Row index variables used for DataTable lookups
    Private amRow As Integer




    ' ***************** INITIALIZATION AND CONFIGURATION SUBS *****************


    ' Sub that will contain calls to all of the instances of the database controller class that loads data from the database into DataTables
    Private Function loadDataTablesFromDatabase() As Boolean

        AutoManufacturersDbController.ExecQuery("SELECT am.AutoMake FROM AutoManufacturers am")
        If AutoManufacturersDbController.HasException() Then Return False

        ' Also, populate respective lists with data
        AutoManufacturersList = getListFromDataTable(AutoManufacturersDbController.DbDataTable, "AutoMake")
        For i As Integer = 0 To AutoManufacturersList.Count - 1
            AutoManufacturersList(i) = AutoManufacturersList(i).ToString().ToLower()
        Next

        Return True

    End Function


    ' Sub that initializes all controls corresponding with values from the automanufacturer datatable
    Private Sub InitializeAutoManufacturersControls()

        ' Lookup and set current amRow index based on selectedIndex of AutoMake ComboBox
        Dim amDataRow As DataRow = AutoManufacturersDbController.DbDataTable.Select("AutoMake = '" & AutoMakeComboBox.Text & "'")(0)
        amRow = AutoManufacturersDbController.DbDataTable.Rows.IndexOf(amDataRow)

        initializeControlsFromRow(AutoManufacturersDbController.DbDataTable, amRow, "_", Me)

    End Sub


    ' Sub that calls all individual initialization subs in one (These can be used individually if desired
    Private Sub InitializeAll()

        ' Automated initializations
        InitializeAutoManufacturersControls()
        ' Then, add formatting
        ' addFormatting()
        ' Set forecolor if not already initially default
        setForeColor(getAllControlsWithTag("dataEditingControl", Me), DefaultForeColor)

    End Sub


    ' Function that makes updateTable calls for all relevant DataTables that need updated based on changes
    Private Function updateAll() As Boolean

        ' First, remove any formatting that was added (specific to the controls on this form)
        'stripFormatting()

        ' Then, update all relevant tables that COUDLD have experienced changes
        Dim initialValueAsKey As String = AutoManufacturersDbController.DbDataTable.Rows(amRow)("AutoMake")
        updateTable(updateController, AutoManufacturersDbController.DbDataTable, "AutoManufacturers", initialValueAsKey, "AutoMake", "_", "dataEditingControl", Me)
        ' I could use a simple, standalone sql query here, as it would allow me to freely change the updateTable overloads in globals.vb.
        ' For now, though, I will try to implement these wherever I can for uniformity/consistency

        ' Then, return exception status of updateController. Return false andfrom this function and reformat if there is an exception thrown (do this after each call).
        If updateController.HasException() Then Return False

        ' Otherwise, return true
        Return True

    End Function


    ' **************** VALIDATION SUBS ****************


    ' Sub that runs validation for all form controls. Also handles error reporting
    Private Function controlsValid() As Boolean

        Dim errorMessage As String = String.Empty

        ' Use "Required" parameter to control whether or not a Null string value will cause an error to be reported


        ' Manufacturer Name (REQUIRED)(MUST BE UNIQUE)
        If isEmpty("Manufacturer Name", True, AutoMake_Textbox.Text, errorMessage) Then
            AutoMake_Textbox.ForeColor = Color.Red
        ElseIf isDuplicate("Manufacturer Name", AutoMake_Textbox.Text.ToLower(), errorMessage, AutoManufacturersList) Then
            AutoMake_Textbox.ForeColor = Color.Red
        End If


        ' Check if any invalid input has been found
        If Not String.IsNullOrEmpty(errorMessage) Then

            MessageBox.Show(errorMessage, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False

        End If

        Return True

    End Function




    Private Sub mfgMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' LOAD DATATABLES FROM DATABASE INITIALLY
        If Not loadDataTablesFromDatabase() Then
            MessageBox.Show("Loading unsuccessful; Please restart and try again")
            Exit Sub
        End If


        ' SETUP CONTROLS HERE
        'AutoMakeComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        AutoMakeComboBox.Items.Add("Select One")
        For Each row In AutoManufacturersDbController.DbDataTable.Rows
            AutoMakeComboBox.Items.Add(row("AutoMake"))
        Next
        AutoMakeComboBox.SelectedIndex = 0

    End Sub




    ' **************** CONTROL SUBS ****************


    ' Main eventhandler that handles most of the initialization for all subsequent elements/controls.
    Private Sub AutoMake_ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AutoMakeComboBox.SelectedIndexChanged, AutoMakeComboBox.TextChanged

        ' If the input in the combobox matches an entry in the table that it represents
        If AutoManufacturersList.BinarySearch(AutoMakeComboBox.Text.ToLower()) >= 0 Then

            ' Initialize corresponding controls from DataTable values
            valuesInitialized = False
            InitializeAll()
            valuesInitialized = True

            ' Show labels and corresponding values
            showHide(getAllControlsWithTag("dataViewingControl", Me), 1)
            showHide(getAllControlsWithTag("dataLabel", Me), 1)
            ' Enable editing button
            editButton.Enabled = True

        Else

            ' Have all labels and corresponding values hidden
            showHide(getAllControlsWithTag("dataViewingControl", Me), 0)
            showHide(getAllControlsWithTag("dataLabel", Me), 0)
            ' Disable editing button
            editButton.Enabled = False

        End If

    End Sub


    Private Sub editButton_Click(sender As Object, e As EventArgs) Handles editButton.Click

        ' Disable editButton, disable addButton, enable cancel button, disable navigation, and disable main selection combobox
        editButton.Enabled = False
        addButton.Enabled = False
        cancelButton.Enabled = True
        nav.DisableAll()
        AutoMakeComboBox.Enabled = False

        ' Hide/Show the dataViewingControls and dataEditingControls, respectively
        showHide(getAllControlsWithTag("dataViewingControl", Me), 0)
        showHide(getAllControlsWithTag("dataEditingControl", Me), 1)

        ' Establish initial values. Doing this here, as unless changes are about to be made, we don't need to set initial values
        InitialAutoManufacturersValues.SetInitialValues(getAllControlsWithTag("dataEditingControl", Me))

    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click

        ' Check for changes before cancelling. Don't need function here that calls all, as only working with one datatable
        If InitialAutoManufacturersValues.CtrlValuesChanged() Then

            Dim decision As DialogResult = MessageBox.Show("Cancel without saving changes?", "Confirm", MessageBoxButtons.YesNo)

            Select Case decision
                Case DialogResult.Yes

                    ' REINITIALIZE ALL CONTROL VALUES (as unwanted changes have been made)
                    valuesInitialized = False
                    InitializeAll()
                    valuesInitialized = True

                    ' RESTORE USER CONTROLS TO NON-EDITING STATE
                    editButton.Enabled = True
                    addButton.Enabled = True
                    cancelButton.Enabled = False
                    saveButton.Enabled = False
                    nav.EnableAll()
                    AutoMakeComboBox.Enabled = True
                    ' Show/Hide the dataViewingControls and dataEditingControls, respectively
                    showHide(getAllControlsWithTag("dataViewingControl", Me), 1)
                    showHide(getAllControlsWithTag("dataEditingControl", Me), 0)

                Case DialogResult.No
            End Select

        Else

            ' RESTORE USER CONTROLS TO NON-EDITING STATE
            editButton.Enabled = True
            addButton.Enabled = True
            cancelButton.Enabled = False
            saveButton.Enabled = False
            nav.EnableAll()
            AutoMakeComboBox.Enabled = True
            ' Show/Hide the dataViewingControls and dataEditingControls, respectively
            showHide(getAllControlsWithTag("dataViewingControl", Me), 1)
            showHide(getAllControlsWithTag("dataEditingControl", Me), 0)

        End If

    End Sub

    Private Sub saveButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click

        Dim decision As DialogResult = MessageBox.Show("Save Changes?", "Confirm Changes", MessageBoxButtons.YesNo)

        Select Case decision
            Case DialogResult.Yes

                ' 1.) VALIDATE DATAEDITING CONTROLS
                If Not controlsValid() Then Exit Sub

                ' 2.) UPDATE DATATABLE(S), THEN UPDATE DATABASE
                If Not updateAll() Then
                    MessageBox.Show("Update unsuccessful; Changes not saved")
                Else
                    MessageBox.Show("Successfully updated Auto Manufacturers")
                End If

                ' 3.) RELOAD DATATABLES FROM DATABASE
                If Not loadDataTablesFromDatabase() Then
                    MessageBox.Show("Loading updated information failed; Old values will be reflected. Please restart and try again")
                End If

                ' 4.) REINITIALIZE CONTROLS FROM THIS POINT (still from selection index, however)
                AutoMakeComboBox.Items.Clear()
                AutoMakeComboBox.Items.Add("Select One")
                For Each row In AutoManufacturersDbController.DbDataTable.Rows
                    AutoMakeComboBox.Items.Add(row("AutoMake"))
                Next
                AutoMakeComboBox.SelectedIndex = amRow + 1

                valuesInitialized = False
                InitializeAll()
                valuesInitialized = True

                ' 5.) MOVE UI OUT OF EDITING MODE
                editButton.Enabled = True
                addButton.Enabled = True
                cancelButton.Enabled = False
                saveButton.Enabled = False
                nav.EnableAll()
                AutoMakeComboBox.Enabled = True
                ' Show/Hide the dataViewingControls and dataEditingControls, respectively
                showHide(getAllControlsWithTag("dataViewingControl", Me), 1)
                showHide(getAllControlsWithTag("dataEditingControl", Me), 0)

            Case DialogResult.No
                ' Continue making changes or cancel editing
        End Select


    End Sub

    Private Sub AutoMake_Textbox_TextChanged(sender As Object, e As EventArgs) Handles AutoMake_Textbox.TextChanged

        If Not valuesInitialized Then Exit Sub

        AutoMake_Textbox.ForeColor = DefaultForeColor

        If InitialAutoManufacturersValues.CtrlValuesChanged() Then
            saveButton.Enabled = True
        Else
            saveButton.Enabled = False
        End If

    End Sub



    Private Sub mfgMaintenance_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        End
    End Sub


End Class