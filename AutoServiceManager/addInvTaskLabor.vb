Public Class addInvTaskLabor

    ' New Database Control instance for InvLabor DataTable
    Private InvLaborDbController As New DbControl()
    Private InvLaborRow As Integer

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

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        InvoiceValue.Text = invoices.GetINID()
        TaskValue.Text = invoiceTasks.GetTask()

    End Sub

    Private Sub addInvTaskLabor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub



    Private Sub addInvTaskLabor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        If Not MeClosed Then

            If validSelection Then

                Dim decision As DialogResult = MessageBox.Show("Cancel without adding labor code?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If decision = DialogResult.No Then
                    e.Cancel = True
                    Exit Sub
                Else
                    MeClosed = True
                    changeScreen(invoiceTasks, Me)
                End If

            Else

                MeClosed = True
                changeScreen(invoiceTasks, Me)

            End If

        End If

    End Sub


    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click

        If Not MeClosed Then

            If validSelection Then

                Dim decision As DialogResult = MessageBox.Show("Cancel without adding labor code?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If decision = DialogResult.No Then
                    Exit Sub
                Else
                    MeClosed = True
                    changeScreen(invoiceTasks, Me)
                End If

            Else

                MeClosed = True
                changeScreen(invoiceTasks, Me)

            End If

        End If

    End Sub


End Class