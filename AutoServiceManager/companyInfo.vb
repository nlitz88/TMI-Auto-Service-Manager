Public Class companyInfo

    Private Sub companyInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Dynamically position elements on load.
        companyInfoLabel.Left = (Me.ClientSize.Width / 2) - (companyInfoLabel.Width / 2)

    End Sub

    Private Sub editButton_Click(sender As Object, e As EventArgs) Handles editButton.Click

        ' Form modification controls
        editButton.Hide()
        cancelButton.Show()
        saveButton.Show()

        ' Get all of the TextBoxes on the form and .Show() them if editing enabled.
        'Dim textBoxes As New ArrayList
        'Dim textBoxes As New ArrayList = My.Forms.companyInfo.Controls.OfType(Of TextBox)

        'For Each ctrl In My.Forms.companyInfo.Controls
        '    If TypeOf ctrl Is TextBox Then
        '        textBoxes.Add(ctrl)
        '    End If
        'Next

        ' hide/show the dataLabels and dataFields, respectively
        showHide(getAllItemsWithTag("dataLabel"), 0)
        showHide(getAllItemsWithTag("dataField"), 1)

    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click

        cancelButton.Hide()
        saveButton.Hide()
        editButton.Show()

        ' show/hide the dataLabels and dataFields, respectively
        showHide(getAllItemsWithTag("dataLabel"), 1)
        showHide(getAllItemsWithTag("dataField"), 0)

    End Sub

    Private Sub saveButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click

        Dim decision As DialogResult = MessageBox.Show("Save Changes?", "Confirm Changes", MessageBoxButtons.YesNo)

        Select Case decision
            Case DialogResult.Yes

                ' 1.) Write changes to database
                ' 2.) Switch back to labels with updated data from database (reload the form essentially)
                ' 3.) Go back to showing edit button

                cancelButton.Hide()
                saveButton.Hide()
                editButton.Show()

                ' show updated dataLabels and hide dataFields
                showHide(getAllItemsWithTag("dataLabel"), 1)
                showHide(getAllItemsWithTag("dataField"), 0)


            Case DialogResult.No
                ' Continue making changes or cancel editing
        End Select

    End Sub

    Private Function getAllItemsWithTag(ByVal tag As String)

        Dim items As New ArrayList

        For Each ctrl In My.Forms.companyInfo.Controls
            If ctrl.tag = tag Then
                items.Add(ctrl)
            End If
        Next

        Return items

    End Function


    ' Sub that shows or hides all items passed in.
    ' First param accepts list of items, second param accepts integer: 0 = hide, 1 = show
    Private Sub showHide(ByVal items As ArrayList, ByVal showhide As Integer)
        For Each item In items
            If showhide = 0 Then
                item.Hide()
            ElseIf showhide = 1 Then
                item.Show()
            End If
        Next
    End Sub


End Class