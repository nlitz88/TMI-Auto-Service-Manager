Public Class incompleteInvoicesReport




    ' New Database control instance used for getting number of receipts
    Private CRUD As New DbControl()




    ' **************** VALIDATION SUBS ****************




    Private Function controlsValid() As Boolean

        Dim errorMessage As String = String.Empty


        ' Report Date (REQUIRED)
        If Not validDateTime("Report Date", True, StartDateTextbox.Text, errorMessage) Then
            StartDateTextbox.ForeColor = Color.Red
        End If


        ' Check if any invalid input has been found
        If Not String.IsNullOrEmpty(errorMessage) Then

            MessageBox.Show(errorMessage, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False

        End If

        Return True

    End Function




    Private Sub incompleteInvoicesReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' On load, populate ReportDateTextbox with current date
        StartDateTextbox.Text = formatDate(DateTime.Now())

        If Not checkDbConn() Then Exit Sub

    End Sub


    Private Sub previewReportButton_Click(sender As Object, e As EventArgs) Handles previewReportButton.Click

        ' 1.) Validate date
        If Not controlsValid() Then Exit Sub

        Try

            ' 2.) Check if any invoices after provided date

            ' Use CRUD to see if there are any invoices after the provided date
            CRUD.AddParams("@firstdate", StartDateTextbox.Text)
            CRUD.ExecQuery("SELECT InvNbr, InvDate FROM InvHdr WHERE InvDate >= @firstdate")

            If Not CRUD.HasException(True) Then
                If CRUD.DbDataTable.Rows.Count <> 0 Then

                    ' 3.) Open report preview if entries made on provided date
                    Dim AcccessInstance As New Microsoft.Office.Interop.Access.Application()
                    Dim filepath As String = readINI("AutoServiceManagerParams.ini", "PRIMARY-DATABASE-FILEPATH=")

                    AcccessInstance.Visible = False
                    AcccessInstance.OpenCurrentDatabase(filepath)

                    AcccessInstance.DoCmd.OpenReport(ReportName:="IncompleteInvoices", Microsoft.Office.Interop.Access.AcView.acViewPreview, , WhereCondition:="InvDate>=#" + CStr(StartDateTextbox.Text) + "#")

                Else
                    MessageBox.Show("No invoices found after " & StartDateTextbox.Text & ".", "No Invoices Found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("Unable to load invoices. Please restart and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception

            MessageBox.Show("Viewing preview unsuccessful. Ensure Database has not been moved and retry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub

        End Try

    End Sub


    Private Sub StartDateTextbox_TextChanged(sender As Object, e As EventArgs) Handles StartDateTextbox.TextChanged

        StartDateTextbox.ForeColor = DefaultForeColor

    End Sub


End Class