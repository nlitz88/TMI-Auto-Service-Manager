Public Class monthlyTaxReport

    ' New Database control instance for months table
    Private monthDbController As New DbControl()
    ' New Database control instance used for getting number of receipts
    Private CRUD As New DbControl()

    ' Variable that allows certain keystrokes through restricted fields
    Private allowedKeystroke As Boolean = False




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
        MonthTextbox.Text = DateTime.Now.Month - 1
        YearTextbox.Text = DateTime.Now.Year


    End Sub


    Private Sub previewReportButton_Click(sender As Object, e As EventArgs) Handles previewReportButton.Click

        ' 1.) Validate date
        If Not controlsValid() Then Exit Sub

        'Try

        '    ' 2.) Check if any invoices after provided date

        '    ' Use CRUD to see if there are any invoices after the provided date
        '    CRUD.AddParams("@reportdate", ReportDateTextbox.Text)
        '    CRUD.ExecQuery("select * from InvPayments where PayDate=@reportdate")

        '    If Not CRUD.HasException(True) Then
        '        If CRUD.DbDataTable.Rows.Count <> 0 Then

        '            ' 3.) Open report preview if entries made on provided date
        '            Dim AcccessInstance As New Microsoft.Office.Interop.Access.Application()
        '            Dim filepath As String = readINI("AutoServiceManagerParams.ini", "PRIMARY-DATABASE-FILEPATH=")

        '            AcccessInstance.Visible = False
        '            AcccessInstance.OpenCurrentDatabase(filepath)

        '            AcccessInstance.DoCmd.OpenReport(ReportName:="CompletedInvoices", Microsoft.Office.Interop.Access.AcView.acViewPreview, , WhereCondition:="PayDate=#" & CStr(ReportDateTextbox.Text) & "#")

        '        Else
        '            MessageBox.Show("No invoices found on " & ReportDateTextbox.Text & ".", "No invoices Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '        End If
        '    Else
        '        MessageBox.Show("Unable to load invoices. Please restart and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End If

        'Catch ex As Exception

        '    MessageBox.Show("Viewing preview unsuccessful. Ensure Database has not been moved and retry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Sub

        'End Try

    End Sub





    ' **************** CONTROL SUBS ****************


    Private Sub MonthTextbox_KeyDown(sender As Object, e As KeyEventArgs) Handles MonthTextbox.KeyDown

        ' Allow certain keystrokes through here. Oftentimes, these will be common shortcuts
        If ((e.KeyCode = Keys.A And e.Control) Or (e.KeyCode = Keys.C And e.Control) Or (e.KeyCode = Keys.V And e.Control)) Then
            allowedKeystroke = True
        End If

    End Sub

    Private Sub MonthTextbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MonthTextbox.KeyPress

        ' If certain keystroke exceptions allowed throuhg, then skip input validation here
        If allowedKeystroke Then
            allowedKeystroke = False
            Exit Sub
        End If

        If Not numericInputValid(MonthTextbox, e.KeyChar, True) Then
            e.KeyChar = Chr(0)
            e.Handled = True
        End If

    End Sub

    Private Sub MonthTextbox_TextChanged(sender As Object, e As EventArgs) Handles MonthTextbox.TextChanged

        MonthTextbox.ForeColor = DefaultForeColor

        ' Handles pasting in invalid values/strings
        Dim lastValidIndex As Integer = allValidChars(MonthTextbox.Text, "1234567890")
        If lastValidIndex <> -1 Then
            MonthTextbox.Text = MonthTextbox.Text.Substring(0, lastValidIndex)
            MonthTextbox.SelectionStart = lastValidIndex
        End If

    End Sub



    Private Sub YearTextbox_KeyDown(sender As Object, e As KeyEventArgs) Handles YearTextbox.KeyDown

        ' Allow certain keystrokes through here. Oftentimes, these will be common shortcuts
        If ((e.KeyCode = Keys.A And e.Control) Or (e.KeyCode = Keys.C And e.Control) Or (e.KeyCode = Keys.V And e.Control)) Then
            allowedKeystroke = True
        End If

    End Sub

    Private Sub YearTextbox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles YearTextbox.KeyPress

        ' If certain keystroke exceptions allowed throuhg, then skip input validation here
        If allowedKeystroke Then
            allowedKeystroke = False
            Exit Sub
        End If

        If Not numericInputValid(YearTextbox, e.KeyChar, True) Then
            e.KeyChar = Chr(0)
            e.Handled = True
        End If

    End Sub

    Private Sub YearTextbox_TextChanged(sender As Object, e As EventArgs) Handles YearTextbox.TextChanged

        YearTextbox.ForeColor = DefaultForeColor

        ' Handles pasting in invalid values/strings
        Dim lastValidIndex As Integer = allValidChars(YearTextbox.Text, "1234567890")
        If lastValidIndex <> -1 Then
            YearTextbox.Text = YearTextbox.Text.Substring(0, lastValidIndex)
            YearTextbox.SelectionStart = lastValidIndex
        End If

    End Sub


End Class