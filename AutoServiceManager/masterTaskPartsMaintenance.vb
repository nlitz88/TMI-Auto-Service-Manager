Imports System.ComponentModel

Public Class masterTaskPartsMaintenance


    Private Sub masterTaskPartsMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Establish label based on "mode" variable in masterTaskMaintenance
        If masterTaskMaintenance.GetMode("tpMode") = "adding" Then
            masterTaskPartsMaintenanceLabel.Text = "Adding Part For Task " & masterTaskMaintenance.GetTask()
        ElseIf masterTaskMaintenance.GetMode("tpMode") = "editing" Then
            masterTaskPartsMaintenanceLabel.Text = "Edit Part For Task " & masterTaskMaintenance.GetTask()
        End If

    End Sub


    Private closed As Boolean = False

    Private Sub masterTaskPartsMaintenance_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        If Not closed Then

            Dim decision As DialogResult = MessageBox.Show("Cancel without saving changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If decision = DialogResult.No Then
                e.Cancel = True
                Exit Sub
            Else
                closed = True
                changeScreen(previousScreen, Me)
            End If

        End If

    End Sub


End Class