Module SharedFunctions

    ' ************************ ITEM MANIPULATION ************************

    ' Used to return all items of a certain group (items that have the same identifying tag) as an iterable ArrayList.
    Public Function getAllItemsWithTag(ByVal tag As String) As ArrayList

        Dim ctrls As New ArrayList

        For Each ctrl In My.Forms.companyInfo.Controls
            If ctrl.tag = tag Then
                ctrls.Add(ctrl)
            End If
        Next

        Return ctrls

    End Function


    ' Function used to return list of all items with a certain name
    Public Function getAllControlsWithName(ByVal name As String, ByRef form As Form) As List(Of Object)

        Dim ctrls As New List(Of Object)

        For Each ctrl In form.Controls
            If ctrl.Name = name Then
                ctrls.Add(ctrl)
            End If
        Next

        Return ctrls

    End Function


    ' Function used to return list of all items beginning with a certain name prefix delimmited by character
    '   Note: Different delimiters in names can be used to find different elements with nearly similar names
    Public Function getAllControlsWithName(ByVal name As String, ByVal delimiter As String, ByRef form As Form) As List(Of Object)

        Dim ctrls As New List(Of Object)

        For Each ctrl In form.Controls
            If ctrl.Name.ToString().IndexOf(delimiter) > 0 Then
                If ctrl.Name.ToString().Substring(0, ctrl.Name.ToString().IndexOf(delimiter)) = name Then
                    ctrls.Add(ctrl)
                End If
            End If
        Next

        Return ctrls

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

    ' UPDATE ACCORDING TO INFO IN TRELLO
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
    Public Function setNullToDefault(ByRef dataValue As Object, Byval dataType As String)

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

        Return dataValue

    End Function


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
            Case GetType(System.Windows.Forms.ComboBox)     ' Not sure if this one will pan out properly. We'll test and see
                control.SelectedItem = value
        End Select

    End Sub



    ' Function that dynamically dataTable column values (from a provided row) and maps them to their respective fields by name
    '   Controls on form that are to be set to a value from the dataTable should be NAMED as follows:
    '       <columnName from dataTable>_controlType
    '       E.g. CompanyName1_Textbox
    '   The underscore is how this function will differentiate between regular elements and those that are to have their valuesSet/Initialized
    ' CONSIDER: This function and some of its attributes could be transformed into a class for greatere reusability and utility for the future
    Public Sub initializeControlsFromRow(ByVal dataTable As DataTable, ByVal row As Integer, ByVal nameDelimeter As String, ByRef form As Form)

        Dim ctrls As List(Of Object)
        Dim dataValue As Object

        ' For each column in the dataTable
        For i As Integer = 0 To dataTable.Columns.Count - 1

            ' Get all of the controls on the form that are to be set/initialized by way of matching the first part of their name to the column name
            ctrls = getAllControlsWithName(dataTable.Columns(i).ColumnName, nameDelimeter, form)

            ' Initialize values of each control that holds the value of this column
            For Each ctrl In ctrls

                dataValue = dataTable.Rows(row)(dataTable.Columns(i).ColumnName)
                dataValue = setNullToDefault(dataValue, dataTable.Rows(row)(dataTable.Columns(i).ColumnName).GetType().ToString())
                setControlValue(ctrl, dataValue)


                Console.WriteLine(ctrl.Name & " set to " & dataValue.ToString())
            Next


        Next

    End Sub

End Module
