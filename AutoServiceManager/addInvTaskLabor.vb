Public Class addInvTaskLabor

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        InvoiceValue.Text = invoices.GetINID()
        TaskValue.Text = invoiceTasks.GetTask()

    End Sub

    Private Sub addInvTaskLabor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


End Class