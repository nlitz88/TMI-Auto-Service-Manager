Public Class InvoiceTasks

    Private InitialITValues As New InitialValues()

    ' Boolean to keep track of whether or not this form has been closed
    Private MeClosed As Boolean = False


    ' Initialize InvTaskComboBox with InvTaskNbr and InvTaskDescription

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' Get invoice number and date to display in InvoiceValue
        InvoiceValue.Text = invoices.GetINID()


    End Sub


    Private Sub InvoiceTasks_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Private Sub InvoiceTasks_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If Not MeClosed Then

            ' Check if editing/adding, and if editing/adding, check if control values changed
            If TaskDescription_Textbox.Visible And InitialITValues.CtrlValuesChanged() Then

                Dim decision As DialogResult = MessageBox.Show("Return to invoice without saving changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If decision = DialogResult.No Then
                    e.Cancel = True
                    Exit Sub
                Else
                    MeClosed = True
                    changeScreen(invoices, Me)
                End If

            Else

                MeClosed = True
                changeScreen(invoices, Me)

            End If

        End If

    End Sub

    Private Sub returnButton_Click(sender As Object, e As EventArgs) Handles returnButton.Click

        If Not MeClosed Then

            ' Check if editing/adding, and if editing/adding, check if control values changed
            If TaskDescription_Textbox.Visible And InitialITValues.CtrlValuesChanged() Then

                Dim decision As DialogResult = MessageBox.Show("Return to invoice without saving changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If decision = DialogResult.No Then
                    Exit Sub
                Else
                    MeClosed = True
                    changeScreen(invoices, Me)
                End If

            Else

                MeClosed = True
                changeScreen(invoices, Me)

            End If

        End If

    End Sub
End Class