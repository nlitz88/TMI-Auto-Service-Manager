Imports System.ComponentModel

Public Class editMasterTaskPart

    ' DataTable that will maintain the DataTable passed to it from masterTaskMainentance
    Dim TaskPartsDataTable As DataTable
    Dim TaskPartsRow As Integer

    ' Boolean to keep track of whether or not this form has been closed
    Private MeClosed As Boolean = False

    ' Initialize instance(s) of initialValues class
    Private InitialPartValues As New InitialValues()

    'Variable to keep track of whether form fully loaded or not
    Private valuesInitialized As Boolean = True

    ' Variable that allows certain keystrokes through restricted fields
    Private allowedKeystroke As Boolean = False



    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' Get TaskPartsDataTable and respective row from masterTaskMaintenance
        TaskPartsDataTable = masterTaskMaintenance.GetTaskPartsDataTable()
        TaskPartsRow = masterTaskMaintenance.GetTaskPartsRow()


    End Sub

    Private Sub masterTaskPartsMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        TaskTextbox.Text = masterTaskMaintenance.GetTask()


    End Sub







    Private Sub masterTaskPartsMaintenance_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        If Not MeClosed Then

            Dim decision As DialogResult = MessageBox.Show("Cancel without applying changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If decision = DialogResult.No Then
                e.Cancel = True
                Exit Sub
            Else
                MeClosed = True
                changeScreen(previousScreen, Me)
            End If

        End If

    End Sub

    Private Sub backButton_Click(sender As Object, e As EventArgs) Handles backButton.Click

        If Not MeClosed Then

            Dim decision As DialogResult = MessageBox.Show("Cancel without applying changes?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If decision = DialogResult.No Then
                Exit Sub
            Else
                MeClosed = True
                changeScreen(previousScreen, Me)
            End If

        End If

    End Sub


End Class