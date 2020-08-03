Public Class InitialValues

    Private InitialCtrlValues As New Dictionary(Of Control, Object)

    Public Sub New()
    End Sub

    Public Sub SetInitialValues(ByRef ctrls As List(Of Object))

        InitialCtrlValues.Clear()

        Dim value As Object

        For Each ctrl As Control In ctrls
            value = GetControlValue(ctrl)
            InitialCtrlValues.Add(ctrl, value)
        Next

    End Sub


    Public Function CtrlValuesChanged() As Boolean

        Dim result As Boolean = False

        For Each ctrlPair In InitialCtrlValues
            If ValueChanged(ctrlPair.Key, ctrlPair.Value) Then
                'Console.WriteLine(ctrlPair.Key.Name.ToString() & " has a different value '" & GetControlValue(ctrlPair.Key).ToString() & "' than initial: '" & InitialCtrlValues(ctrlPair.Key).ToString() & "'")
                result = True
                Exit For
            End If
        Next

        Return result

    End Function

    ' Function that returns value of type respective to the control type
    Private Function GetControlValue(ByRef ctrl As Object) As Object

        Dim result As Object

        Select Case ctrl.GetType()
            Case GetType(System.Windows.Forms.Label), GetType(System.Windows.Forms.TextBox), GetType(System.Windows.Forms.MaskedTextBox)
                result = ctrl.Text
            Case GetType(System.Windows.Forms.CheckBox)
                result = ctrl.Checked
            Case GetType(System.Windows.Forms.ComboBox)
                result = ctrl.Text                          ' Might have to work with selectedValue
            Case Else                                       ' redundant
                result = ctrl.Text
        End Select

        Return result

    End Function


    ' Function that returns whether or not current control value has changed from its initial value in InitialCtrlValues
    Public Function ValueChanged(ByRef control As Object, ByVal value As Object) As Boolean

        Dim result As Boolean = False

        Select Case control.GetType()
            Case GetType(System.Windows.Forms.Label), GetType(System.Windows.Forms.TextBox), GetType(System.Windows.Forms.MaskedTextBox)
                If control.Text <> value.ToString() Then
                    result = True
                End If
            Case GetType(System.Windows.Forms.CheckBox)
                If control.checked <> value Then
                    result = True
                End If
            Case GetType(System.Windows.Forms.ComboBox)
                If control.Text <> value Then
                    'Console.WriteLine("SelectedValue = value? : " & (control.SelectedValue = value).ToString() & " | Text = value? : " & (control.Text = value).ToString())
                    result = True
                End If
        End Select

        Return result

    End Function

End Class
