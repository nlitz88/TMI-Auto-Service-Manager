Public Class monthlyTaxReport

    ' New Database control instance for months table
    Private monthDbController As New DbControl()
    ' New Database control instance used for getting number of receipts
    Private CRUD As New DbControl()




    ' ***************** INITIALIZATION AND CONFIGURATION SUBS *****************


    ' Sub that loads Months DataTable
    Private Function loadMonthDataTable() As Boolean

        monthDbController.ExecQuery("SELECT m.IntMonth FROM Months m")
        If monthDbController.HasException() Then Return False

        Return True

    End Function





    ' **************** VALIDATION SUBS ****************


    Private Function controlsValid() As Boolean

        Dim errorMessage As String = String.Empty


        ' Month (REQUIRED)
        If Not validNumber("Month", True, MonthTextbox.Text, errorMessage, True) Then
            MonthTextbox.ForeColor = Color.Red
        ElseIf Not valueExistsEquals("IntMonth", Convert.ToInt32(MonthTextbox.Text), monthDbController.DbDataTable) Then
            errorMessage += "ERROR: " & MonthTextbox.Text & " is not a valid month" & vbNewLine
            MonthTextbox.ForeColor = Color.Red
        End If

        ' Year (REQUIRED)
        If Not validNumber("Year", True, YearTextbox.Text, errorMessage, True) Then
            YearTextbox.ForeColor = Color.Red
        End If


        ' Check if any invalid input has been found
        If Not String.IsNullOrEmpty(errorMessage) Then

            MessageBox.Show(errorMessage, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False

        End If

        Return True

    End Function





    Private Sub monthlyTaxReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If Not checkDbConn() Then Exit Sub

        ' 1.) Load Month Datatable
        If Not loadMonthDataTable() Then
            MessageBox.Show("Failed to load Months table; Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' 2.) Initialize MonthTextbox and Year with current month and year
        MonthTextbox.Text = DateTime.Now.Month
        YearTextbox.Text = DateTime.Now.Year


    End Sub


    Private Sub previewReportButton_Click(sender As Object, e As EventArgs) Handles previewReportButton.Click

        ' 1.) Validate date
        If Not controlsValid() Then Exit Sub

        ' 2.)

    End Sub





    ' **************** CONTROL SUBS ****************


    Private Sub MonthTextbox_KeyDown(sender As Object, e As KeyEventArgs) Handles MonthTextbox.KeyDown

    End Sub

    Private Sub MonthTextbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MonthTextbox.KeyPress

    End Sub

    Private Sub MonthTextbox_TextChanged(sender As Object, e As EventArgs) Handles MonthTextbox.TextChanged

    End Sub



    Private Sub YearTextbox_KeyDown(sender As Object, e As KeyEventArgs) Handles YearTextbox.KeyDown

    End Sub

    Private Sub YearTextbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles YearTextbox.KeyPress

    End Sub

    Private Sub YearTextbox_TextChanged(sender As Object, e As EventArgs) Handles YearTextbox.TextChanged

    End Sub


End Class