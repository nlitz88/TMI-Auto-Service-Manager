﻿Public Class companyInfo

    ' Initialize new database control instances
    Private CompanyMasterDbController As New dbControl()
    Private ZipCodesDbController As New dbControl()

    'Temporary variable to keep track of whether form fully loaded or not
    Dim valuesInitialized As Boolean = False


    ' Sub that will contain calls to all of the instances of the database controller class that loads data from the database into DataTables
    Private Sub loadDataTablesFromDatabase()

        CompanyMasterDbController.ExecQuery("SELECT cm.TaxRate, cm.ShopSupplyCharge, cm.CompanyName1, cm.CompanyName2, cm.Address1, cm.Address2, cm.ZipCode, cm.Phone1, cm.Phone2, cm.LaborRate, zc.city, zc.State FROM CompanyMaster cm left outer join ZipCodes zc on cm.ZipCode = zc.Zipcode")
        ZipCodesDbController.ExecQuery("SELECT * from ZipCodes zc")  ' Too slow for quick access, only load once at beginning (don't reload)

    End Sub


    ' Initialize/Set values of controls on form with values from dataTable.
    ' Use this function to initialize various control groups from various DataTables that may have been loaded from the database.
    ' This function includes all automatic dynamic initialization and any additional initialization
    Private Sub initializeValues()

        If Not CompanyMasterDbController.HasException() Then

            valuesInitialized = False

            ' Initialize additional/unique controls from additional DataTables here
            ZipCode_ComboBox.DataSource = ZipCodesDbController.dbDataTable
            ' ZipCode_ComboBox's datasource is from a separate query, but its initial selectedValue is set from CompanyMasterDataTable
            ZipCode_ComboBox.ValueMember = "Zipcode"
            ZipCode_ComboBox.DisplayMember = "Zipcode"

            ' Initialize Form controls from CompanyMasterDbController.dbDataTable
            initializeControlsFromRow(CompanyMasterDbController.dbDataTable, 0, "_", Me)

            valuesInitialized = True

        End If

    End Sub


    ' Sub that will call formatting functions to the add certain formats to initialized controls (i.e. phone numbers, currency, etc.).
    Private Sub addFormatting()

    End Sub


    Private Sub companyInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Dynamically position elements on load.
        companyInfoLabel.Left = (Me.ClientSize.Width / 2) - (companyInfoLabel.Width / 2)

        loadDataTablesFromDatabase()
        initializeValues()

        ' Testing


    End Sub



    Private Sub editButton_Click(sender As Object, e As EventArgs) Handles editButton.Click

        ' Enable cancelButton and disable editButton
        cancelButton.Enabled = True
        editButton.Enabled = False
        'navigationPlaceholderButton.Enabled = False

        ' Disable all navigation controls while editing
        showHide(getAllItemsWithTag("navigation"), 0)
        ' disable/enable the dataViewingControls and dataEditingControls, respectively
        showHide(getAllItemsWithTag("dataViewingControl"), 0)
        showHide(getAllItemsWithTag("dataEditingControl"), 1)

    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click

        ' Ensure that any changes made are saved
        If changesMadeToEditingControlsOfRow(getAllItemsWithTag("dataEditingControl"), CompanyMasterDbController.dbDataTable, 0, "_") Then

            Dim decision As DialogResult = MessageBox.Show("Cancel without saving changes?", "Confirm", MessageBoxButtons.YesNo)

            Select Case decision
                Case DialogResult.Yes

                    ' ReInitializeData
                    initializeValues()

                    ' Disable all editing controls
                    cancelButton.Enabled = False
                    saveButton.Enabled = False
                    ' re-enable other hidden form controls
                    editButton.Enabled = True
                    ' re-enable navigation controls
                    showHide(getAllItemsWithTag("navigation"), 1)
                    ' enable/disable the dataViewingControls and dataEditingControls, respectively
                    showHide(getAllItemsWithTag("dataViewingControl"), 1)
                    showHide(getAllItemsWithTag("dataEditingControl"), 0)

                Case DialogResult.No

            End Select

        Else

            ' Disable all editing controls
            cancelButton.Enabled = False
            saveButton.Enabled = False
            ' re-enable other hidden form controls
            editButton.Enabled = True
            ' re-enable navigation controls
            showHide(getAllItemsWithTag("navigation"), 1)
            ' enable/disable the dataViewingControls and dataEditingControls, respectively
            showHide(getAllItemsWithTag("dataViewingControl"), 1)
            showHide(getAllItemsWithTag("dataEditingControl"), 0)

        End If

    End Sub

    Private Sub saveButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click

        Dim decision As DialogResult = MessageBox.Show("Save Changes?", "Confirm Changes", MessageBoxButtons.YesNo)

        Select Case decision
            Case DialogResult.Yes

                ' 1.) Write changes to database
                ' 2.) Switch back to labels with updated data from database (reload the form essentially)
                ' 3.) Go back to showing edit button and navigation controls

                ' Disable all editing controls
                cancelButton.Enabled = False
                saveButton.Enabled = False
                ' re-enable other hidden form controls
                editButton.Enabled = True
                ' re-enable navigation controls
                showHide(getAllItemsWithTag("navigation"), 1)

                ' show updated dataViewingControls and hide dataEditingControls
                showHide(getAllItemsWithTag("dataViewingControl"), 1)
                showHide(getAllItemsWithTag("dataEditingControl"), 0)



            Case DialogResult.No
                ' Continue making changes or cancel editing

        End Select

    End Sub



    ' ************************ dataEditingControl TEXTBOX EVENT HANDLERS ************************


    Private Sub CompanyName1_Textbox_TextChanged(sender As Object, e As EventArgs) Handles CompanyName1_Textbox.TextChanged

        ' For now, just check to see if the entire form has been loaded before checking for text changes
        ' In the future (when database implemented, maybe this should change to until the database has been connected to and data has been loaded?
        ' Worker thread or something of the like?
        ' This applies for this Textbox sub and all dataEditingControl tagged Textboxes that follow
        If valuesInitialized Then
            If changesMadeToEditingControlsOfRow(getAllItemsWithTag("dataEditingControl"), CompanyMasterDbController.dbDataTable, 0, "_") Then
                saveButton.Enabled = True
            Else
                saveButton.Enabled = False
            End If
        End If

    End Sub

    Private Sub CompanyName2_Textbox_TextChanged(sender As Object, e As EventArgs) Handles CompanyName2_Textbox.TextChanged

        If valuesInitialized Then
            If changesMadeToEditingControlsOfRow(getAllItemsWithTag("dataEditingControl"), CompanyMasterDbController.dbDataTable, 0, "_") Then
                saveButton.Enabled = True
            Else
                saveButton.Enabled = False
            End If
        End If

    End Sub

    Private Sub Address1_Textbox_TextChanged(sender As Object, e As EventArgs) Handles Address1_Textbox.TextChanged

        If valuesInitialized Then
            If changesMadeToEditingControlsOfRow(getAllItemsWithTag("dataEditingControl"), CompanyMasterDbController.dbDataTable, 0, "_") Then
                saveButton.Enabled = True
            Else
                saveButton.Enabled = False
            End If
        End If

    End Sub

    Private Sub Address2_Textbox_TextChanged(sender As Object, e As EventArgs) Handles Address2_Textbox.TextChanged

        If valuesInitialized Then
            If changesMadeToEditingControlsOfRow(getAllItemsWithTag("dataEditingControl"), CompanyMasterDbController.dbDataTable, 0, "_") Then
                saveButton.Enabled = True
            Else
                saveButton.Enabled = False
            End If
        End If

    End Sub

    Private Sub ZipCode_Textbox_TextChanged(sender As Object, e As EventArgs) Handles ZipCode_Textbox.TextChanged

        If valuesInitialized Then
            If changesMadeToEditingControlsOfRow(getAllItemsWithTag("dataEditingControl"), CompanyMasterDbController.dbDataTable, 0, "_") Then
                saveButton.Enabled = True
            Else
                saveButton.Enabled = False
            End If
        End If

    End Sub



    'Private Sub city_Textbox_TextChanged(sender As Object, e As EventArgs) Handles city_Textbox.TextChanged

    '    If valuesInitialized Then
    '        If changesMadeToEditingControlsOfRow(getAllItemsWithTag("dataEditingControl"), CompanyMasterDbController.dbDataTable, 0, "_") Then
    '            saveButton.Enabled = True
    '        Else
    '            saveButton.Enabled = False
    '        End If
    '    End If

    'End Sub

    'Private Sub State_Textbox_TextChanged(sender As Object, e As EventArgs) Handles State_Textbox.TextChanged

    '    If valuesInitialized Then
    '        If changesMadeToEditingControlsOfRow(getAllItemsWithTag("dataEditingControl"), CompanyMasterDbController.dbDataTable, 0, "_") Then
    '            saveButton.Enabled = True
    '        Else
    '            saveButton.Enabled = False
    '        End If
    '    End If

    'End Sub

    Private Sub Phone1_Textbox_TextChanged(sender As Object, e As EventArgs) Handles Phone1_Textbox.TextChanged

        If valuesInitialized Then
            If changesMadeToEditingControlsOfRow(getAllItemsWithTag("dataEditingControl"), CompanyMasterDbController.dbDataTable, 0, "_") Then
                saveButton.Enabled = True
            Else
                saveButton.Enabled = False
            End If
        End If

    End Sub

    Private Sub Phone2_Textbox_TextChanged(sender As Object, e As EventArgs) Handles Phone2_Textbox.TextChanged

        If valuesInitialized Then
            If changesMadeToEditingControlsOfRow(getAllItemsWithTag("dataEditingControl"), CompanyMasterDbController.dbDataTable, 0, "_") Then
                saveButton.Enabled = True
            Else
                saveButton.Enabled = False
            End If
        End If

    End Sub

    Private Sub TaxRate_Textbox_TextChanged(sender As Object, e As EventArgs) Handles TaxRate_Textbox.TextChanged

        If valuesInitialized Then
            If changesMadeToEditingControlsOfRow(getAllItemsWithTag("dataEditingControl"), CompanyMasterDbController.dbDataTable, 0, "_") Then
                saveButton.Enabled = True
            Else
                saveButton.Enabled = False
            End If
        End If

    End Sub

    Private Sub ShopSupplyCharge_Textbox_TextChanged(sender As Object, e As EventArgs) Handles ShopSupplyCharge_Textbox.TextChanged

        If valuesInitialized Then
            If changesMadeToEditingControlsOfRow(getAllItemsWithTag("dataEditingControl"), CompanyMasterDbController.dbDataTable, 0, "_") Then
                saveButton.Enabled = True
            Else
                saveButton.Enabled = False
            End If
        End If

    End Sub

    Private Sub LaborRate_Textbox_TextChanged(sender As Object, e As EventArgs) Handles LaborRate_Textbox.TextChanged

        If valuesInitialized Then
            If changesMadeToEditingControlsOfRow(getAllItemsWithTag("dataEditingControl"), CompanyMasterDbController.dbDataTable, 0, "_") Then
                saveButton.Enabled = True
            Else
                saveButton.Enabled = False
            End If
        End If

    End Sub


    Private Sub navigationPlaceholderButton_Click(sender As Object, e As EventArgs) Handles navigationPlaceholderButton.Click
        Me.Close()
    End Sub


    Private Sub ZipCode_ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ZipCode_ComboBox.SelectedIndexChanged, ZipCode_ComboBox.TextChanged

        'Console.WriteLine("Selected Index: " & ZipCode_ComboBox.SelectedIndex)
        'Console.WriteLine("Selected Item: " & ZipCode_ComboBox.SelectedItem(0).ToString() & " Type: " & ZipCode_ComboBox.SelectedItem(0).GetType().ToString())

        If valuesInitialized Then
            If changesMadeToEditingControlsOfRow(getAllItemsWithTag("dataEditingControl"), CompanyMasterDbController.dbDataTable, 0, "_") Then
                saveButton.Enabled = True
            Else
                saveButton.Enabled = False
            End If

            ' Basic Validation
            If ZipCode_ComboBox.Text.Length = 5 Then
                For Each row In ZipCodesDbController.dbDataTable.Rows
                    If ZipCode_ComboBox.Text = row("Zipcode") Then

                        ' If in the table, then update city and state accordingly
                        city_Textbox.Text = ZipCodesDbController.dbDataTable.Select("Zipcode = '" & ZipCode_ComboBox.Text.ToString() & "'")(0).Item("city")
                        State_Textbox.Text = ZipCodesDbController.dbDataTable.Select("Zipcode = '" & ZipCode_ComboBox.Text.ToString() & "'")(0).Item("State")
                        Exit For

                    End If
                Next
            End If

        End If

    End Sub


End Class