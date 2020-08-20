Public Class InvoiceTasks


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



End Class