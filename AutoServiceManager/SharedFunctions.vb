Module SharedFunctions

    ' ************************ ITEM MANIPULATION ************************

    ' Used to return all items of a certain group (items that have the same identifying tag) as an iterable ArrayList.
    Public Function getAllItemsWithTag(ByVal tag As String) As ArrayList

        Dim items As New ArrayList

        For Each ctrl In My.Forms.companyInfo.Controls
            If ctrl.tag = tag Then
                items.Add(ctrl)
            End If
        Next

        Return items

    End Function


    ' Sub that shows or hides all items passed in.
    ' First param accepts list of items, second param accepts integer: 0 = hide, 1 = show
    ' Commonly used in conjunction with getAllItemsWithTag or similar function that finds items by attribute or type
    Public Sub showHide(ByVal items As ArrayList, ByVal showhide As Integer)
        For Each item In items
            If showhide = 0 Then
                item.Hide()
            ElseIf showhide = 1 Then
                item.Show()
            End If
        Next
    End Sub


    ' Function used to check if the text of any textbox on a form has been modified.
    ' Currently utilized to determine if save button present on companyInfo form
    Public Function changesMadeToText(ByVal items As ArrayList, ByVal initialValues As Dictionary(Of String, String)) As Boolean

        Dim result As Boolean = False

        For Each item In items

            Try

                If item.Text <> initialValues(item.Name) Then
                    result = True
                    Console.WriteLine("Changes Made")
                End If

            Catch ex As Exception

                Console.WriteLine(item.Name & " apparently isn't a key. Exception : " & vbNewLine & ex.Message & vbNewLine & vbNewLine)

            End Try


        Next

        Return result

    End Function


    ' ************************ DATABASE DATA INTERACTION/MANIPULATION ************************

    ' Function used to return default value type of empty field from database instead of DBNull
    Public Sub setNullToDefault(ByRef dataValue As Object, dataType As String)

        ' If the value returned from the database is DBNull
        If dataValue Is DBNull.Value Then

            ' Determine what the dataType is and then assign corresponding default value
            Select Case dataType
                ' For all value types
                Case "System.DateTime"
                    dataValue = New DateTime
                Case "System.Boolean"
                    dataValue = False
                Case "System.Decimal"
                    dataValue = 0.0
                Case "System.Double"
                    dataValue = 0.0
                Case "System.Integer"
                    dataValue = 0
                Case "System.Char"
                    dataValue = 0
                    ' For all reference types
                Case "System.String"
                    dataValue = String.Empty
            End Select

        End If

    End Sub


    ' Function that can dynamically set value for control based on what type of control the data is being assigned to.
    Public Sub setControlValue(ByRef control As Object, ByVal value As Object)

        ' Add additional controls here if necessary
        Select Case control.GetType()
            Case GetType(System.Windows.Forms.Label)
                control.Text = value.ToString()
            Case GetType(System.Windows.Forms.TextBox)
                control.Text = value.ToString()
            Case GetType(System.Windows.Forms.CheckBox)
                control.Checked = value
        End Select

    End Sub

End Module
