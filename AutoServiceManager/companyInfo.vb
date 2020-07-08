Public Class companyInfo

    'Temporary variable to keep track of whether form fully loaded or not
    Dim formLoaded As Boolean = False
    ' Dictionary to maintain initial dataLabel/dataField values to compare against when changes are made
    Dim initialDataValues As New Dictionary(Of String, String)

    Private Sub companyInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Dynamically position elements on load.
        companyInfoLabel.Left = (Me.ClientSize.Width / 2) - (companyInfoLabel.Width / 2)

        ' UNTIL DB CONNECTED: initialize textBox with data from corresponding dataValue
        ' Initial Data values for dataFields are temporarily being mapped to corresponding dataValue fields until DB attached

        ' Manual assignment. Consider mapping using a dictionary and more intuitive function as shown above
        companyNameTextbox.Text = companyNameValue.Text
        companyName2Textbox.Text = companyName2Value.Text
        addressLine1Textbox.Text = addressLine1Value.Text
        addressLine2Textbox.Text = addressLine2Value.Text
        zipCodeTextbox.Text = zipCodeValue.Text
        cityTextbox.Text = cityValue.Text
        stateTextbox.Text = stateValue.Text
        phone1Textbox.Text = phone1Value.Text
        phone2Textbox.Text = phone2Value.Text
        taxRateTextbox.Text = taxRateValue.Text
        shopSupplyChargeTextbox.Text = shopSupplyChargeValue.Text
        laborRateTextbox.Text = laborRateValue.Text

        Dim dataFields As ArrayList = getAllItemsWithTag("dataField")
        For Each dataField In dataFields
            initialDataValues.Add(dataField.Name, dataField.Text)
        Next


        formLoaded = True



    End Sub

    Private Sub editButton_Click(sender As Object, e As EventArgs) Handles editButton.Click

        ' Enable cancelButton and disable editButton
        cancelButton.Show()
        editButton.Hide()

        ' Disable all navigation controls while editing
        showHide(getAllItemsWithTag("navigation"), 0)

        ' disable/enable the dataLabels and dataFields, respectively
        showHide(getAllItemsWithTag("dataLabel"), 0)
        showHide(getAllItemsWithTag("dataField"), 1)

    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click

        ' Ensure that any changes made were saved
        If changesMadeToText(getAllItemsWithTag("dataField"), initialDataValues) Then

            Dim decision As DialogResult = MessageBox.Show("Cancel without saving changes?", "Confirm", MessageBoxButtons.YesNo)

            Select Case decision
                Case DialogResult.Yes

                    ' Disable all editing controls
                    cancelButton.Hide()
                    saveButton.Hide()
                    ' re-enable other hidden form controls
                    editButton.Show()
                    ' re-enable navigation controls
                    showHide(getAllItemsWithTag("navigation"), 1)
                    ' enable/disable the dataLabels and dataFields, respectively
                    showHide(getAllItemsWithTag("dataLabel"), 1)
                    showHide(getAllItemsWithTag("dataField"), 0)

                Case DialogResult.No

            End Select

        Else

            ' Disable all editing controls
            cancelButton.Hide()
            saveButton.Hide()
            ' re-enable other hidden form controls
            editButton.Show()
            ' re-enable navigation controls
            showHide(getAllItemsWithTag("navigation"), 1)
            ' enable/disable the dataLabels and dataFields, respectively
            showHide(getAllItemsWithTag("dataLabel"), 1)
            showHide(getAllItemsWithTag("dataField"), 0)

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
                cancelButton.Hide()
                saveButton.Hide()
                ' re-enable other hidden form controls
                editButton.Show()
                ' re-enable navigation controls
                showHide(getAllItemsWithTag("navigation"), 1)

                ' show updated dataLabels and hide dataFields
                showHide(getAllItemsWithTag("dataLabel"), 1)
                showHide(getAllItemsWithTag("dataField"), 0)


            Case DialogResult.No
                ' Continue making changes or cancel editing

        End Select

    End Sub


    ' ************************ DATAFIELD TEXTBOX SUBS ************************


    Private Sub companyNameTextbox_TextChanged(sender As Object, e As EventArgs) Handles companyNameTextbox.TextChanged

        ' For now, just check to see if the entire form has been loaded before checking for text changes
        ' In the future (when database implemented, maybe this should change to until the database has been connected to and data has been loaded?
        ' Worker thread or something of the like?
        ' This applies for this Textbox sub and all dataField tagged Textboxes that follow
        If formLoaded Then
            If changesMadeToText(getAllItemsWithTag("dataField"), initialDataValues) Then
                saveButton.Show()
            Else
                saveButton.Hide()
            End If
        End If

    End Sub

    Private Sub companyName2Textbox_TextChanged(sender As Object, e As EventArgs) Handles companyName2Textbox.TextChanged

        If formLoaded Then
            If changesMadeToText(getAllItemsWithTag("dataField"), initialDataValues) Then
                saveButton.Show()
            Else
                saveButton.Hide()
            End If
        End If

    End Sub

    Private Sub addressLine1Textbox_TextChanged(sender As Object, e As EventArgs) Handles addressLine1Textbox.TextChanged

        If formLoaded Then
            If changesMadeToText(getAllItemsWithTag("dataField"), initialDataValues) Then
                saveButton.Show()
            Else
                saveButton.Hide()
            End If
        End If

    End Sub

    Private Sub addressLine2Textbox_TextChanged(sender As Object, e As EventArgs) Handles addressLine2Textbox.TextChanged

        If formLoaded Then
            If changesMadeToText(getAllItemsWithTag("dataField"), initialDataValues) Then
                saveButton.Show()
            Else
                saveButton.Hide()
            End If
        End If

    End Sub

    Private Sub zipCodeTextbox_TextChanged(sender As Object, e As EventArgs) Handles zipCodeTextbox.TextChanged

        If formLoaded Then
            If changesMadeToText(getAllItemsWithTag("dataField"), initialDataValues) Then
                saveButton.Show()
            Else
                saveButton.Hide()
            End If
        End If

    End Sub

    Private Sub cityTextbox_TextChanged(sender As Object, e As EventArgs) Handles cityTextbox.TextChanged

        If formLoaded Then
            If changesMadeToText(getAllItemsWithTag("dataField"), initialDataValues) Then
                saveButton.Show()
            Else
                saveButton.Hide()
            End If
        End If

    End Sub

    Private Sub stateTextbox_TextChanged(sender As Object, e As EventArgs) Handles stateTextbox.TextChanged

        If formLoaded Then
            If changesMadeToText(getAllItemsWithTag("dataField"), initialDataValues) Then
                saveButton.Show()
            Else
                saveButton.Hide()
            End If
        End If

    End Sub

    Private Sub phone1Textbox_TextChanged(sender As Object, e As EventArgs) Handles phone1Textbox.TextChanged

        If formLoaded Then
            If changesMadeToText(getAllItemsWithTag("dataField"), initialDataValues) Then
                saveButton.Show()
            Else
                saveButton.Hide()
            End If
        End If

    End Sub

    Private Sub phone2Textbox_TextChanged(sender As Object, e As EventArgs) Handles phone2Textbox.TextChanged

        If formLoaded Then
            If changesMadeToText(getAllItemsWithTag("dataField"), initialDataValues) Then
                saveButton.Show()
            Else
                saveButton.Hide()
            End If
        End If

    End Sub

    Private Sub taxRateTextbox_TextChanged(sender As Object, e As EventArgs) Handles taxRateTextbox.TextChanged

        If formLoaded Then
            If changesMadeToText(getAllItemsWithTag("dataField"), initialDataValues) Then
                saveButton.Show()
            Else
                saveButton.Hide()
            End If
        End If

    End Sub

    Private Sub shopSupplyChargeTextbox_TextChanged(sender As Object, e As EventArgs) Handles shopSupplyChargeTextbox.TextChanged

        If formLoaded Then
            If changesMadeToText(getAllItemsWithTag("dataField"), initialDataValues) Then
                saveButton.Show()
            Else
                saveButton.Hide()
            End If
        End If

    End Sub

    Private Sub laborRateTextbox_TextChanged(sender As Object, e As EventArgs) Handles laborRateTextbox.TextChanged

        If formLoaded Then
            If changesMadeToText(getAllItemsWithTag("dataField"), initialDataValues) Then
                saveButton.Show()
            Else
                saveButton.Hide()
            End If
        End If

    End Sub


End Class