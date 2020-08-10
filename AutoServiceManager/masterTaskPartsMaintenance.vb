Imports System.ComponentModel

Public Class masterTaskPartsMaintenance


    Private Sub masterTaskPartsMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Establish label based on "mode" variable in masterTaskMaintenance
        If masterTaskMaintenance.GetMode("tpMode") = "editing" Then
            masterTaskPartsMaintenanceLabel.Text = "Edit Part for Task " & masterTaskMaintenance.GetTask()
        End If

    End Sub

    Private Sub masterTaskPartsMaintenance_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        Dim decision As DialogResult = MessageBox.Show("Cancel without saving changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If decision = DialogResult.No Then Exit Sub

    End Sub

End Class