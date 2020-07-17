Module globals

    ' ************************ CONTROL MANIPULATION ************************

    ' Used to return all items of a certain group (items that have the same identifying tag) as an iterable ArrayList.
    Public Function getAllItemsWithTag(ByVal tag As String) As List(Of Object)

        Dim ctrls As New List(Of Object)

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
    Public Function getAllControlsWithName(ByVal name As String, ByVal nameDelimiter As String, ByRef form As Form) As List(Of Object)

        Dim ctrls As New List(Of Object)

        For Each ctrl In form.Controls
            If ctrl.Name.ToString().IndexOf(nameDelimiter) > 0 Then
                If ctrl.Name.ToString().Substring(0, ctrl.Name.ToString().IndexOf(nameDelimiter)) = name Then
                    ctrls.Add(ctrl)
                End If
            End If
        Next

        Return ctrls

    End Function


    ' Sub that shows or hides all items passed in.
    ' First param accepts list of items, second param accepts integer: 0 = hide, 1 = show
    ' Commonly used in conjunction with getAllItemsWithTag or similar function that finds items by attribute or type
    Public Sub showHide(ByVal ctrls As List(Of Object), ByVal showhide As Integer)
        For Each ctrl In ctrls
            If showhide = 0 Then
                ctrl.Hide()
            ElseIf showhide = 1 Then
                ctrl.Show()
            End If
        Next
    End Sub


    ' Function used to check if the text of any textbox on a form has been modified.
    ' Currently utilized to determine if save button present on companyInfo form

    ' UPDATE ACCORDING TO INFO IN TRELLO
    Public Function changesMadeToText(ByVal items As List(Of Object), ByVal initialValues As Dictionary(Of String, String)) As Boolean

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


    ' UPDATED VERSION
    Public Function changesMadeToEditingControlsOfRow(ByRef controls As List(Of Object), ByVal dataTable As DataTable, ByVal dataTableRow As Integer, ByVal nameDelimiter As String) As Boolean

        Dim result As Boolean = False
        Dim columnNameFromCtrl As String
        Dim columnValue As Object

        For Each ctrl As Control In controls                            ' "As Control" may pose issues. Remove in the future if so. Added just for good practice.
            ' Lookup initial value of control in dataTable.
            ' Do this by finding the value at the corresponding (row)(column) that the control's value corresponds to.
            columnNameFromCtrl = ctrl.Name.ToString().Substring(0, ctrl.Name.ToString().IndexOf(nameDelimiter))
            columnValue = dataTable.Rows(dataTableRow)(columnNameFromCtrl)

            ' If the value currently in the control is not equal to the corresponding value in the dataTable
            If Not compareControlValue(ctrl, columnValue) Then
                Console.WriteLine(ctrl.Name & " has a different value than " & columnValue)
                result = True
                Exit For                                                ' Keeps the loop from checking against other controls if it has already found that a change has been made
            End If

        Next

        Return result

    End Function


    ' Function that determines if any controls that correspond with values from a given datatable have had their values changed.
    ' Must be used with each DataTable from which dataEditingControls are initialized
    Public Function editingControlChanged(ByVal dataTable As DataTable, ByVal dataTableRow As Integer, ByVal nameDelimiter As String, ByRef form As Form) As Boolean

        Dim result As Boolean = False
        Dim ctrls As List(Of Object)
        Dim initialValue As Object

        For i As Integer = 0 To dataTable.Columns.Count - 1

            ' Get all of the controls beginning with that column name from the respective dataTable
            ctrls = getAllControlsWithName(dataTable.Columns(i).ColumnName, nameDelimiter, form)

            ' For each ctrl that has that name (that corresponds to that value in the dataTable)
            For Each ctrl In ctrls

                ' We only want to check against the controls with tag "dataEditingControl"
                If ctrl.Tag <> "dataEditingControl" Then Continue For

                ' Get the initial value that these controls should contain 
                initialValue = dataTable.Rows(dataTableRow)(dataTable.Columns(i).ColumnName)

                ' Compare the controls value to the initialValue that is in the dataTable at that row, column
                If Not compareControlValue(ctrl, initialValue) Then

                    result = True
                    Exit For

                End If

            Next

        Next

        Return result

    End Function


    ' ************************ DATABASE DATA INTERACTION/MANIPULATION ************************


    ' Sub used to replace DBNull entries in provided DataTable to default entries respective to their dataType
    ' Receives dataTable as reference, so all changes are made directly on DataTable
    ' Eventually, move this in with the database control class.
    Public Sub setNullsToDefault(ByRef dataTable As DataTable)

        For Each row As DataRow In dataTable.Rows
            For Each column As DataColumn In dataTable.Columns

                Dim dataValue As Object = row(column)

                If IsDBNull(dataValue) Then

                    Dim dataType = column.DataType

                    Select Case dataType
                        Case GetType(System.DateTime)
                            dataValue = New DateTime
                        Case GetType(System.String)
                            dataValue = String.Empty
                            'Console.WriteLine("DataType is " & dataValue.GetType().ToString() & ". Does datavalue = String.Empty?: " & (dataValue = String.Empty))
                        Case GetType(System.Boolean)
                            dataValue = False
                        Case Else
                            dataValue = 0
                    End Select

                End If

            Next
        Next

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
            Case GetType(System.Windows.Forms.ComboBox)
                ' May need debugging
                'Console.WriteLine("Value to write: " & value.ToString() & " " & value.GetType().ToString())
                control.SelectedValue = value
        End Select

    End Sub


    ' Function that dynamically compares a value to a control's respective value type
    Public Function compareControlValue(ByRef control As Object, ByVal value As Object) As Boolean

        Dim result As Boolean = False

        ' Add additional controls here if necessary
        Select Case control.GetType()
            Case GetType(System.Windows.Forms.Label)
                If control.Text = value.ToString() Then     ' For .text, must compare against string value, as .Text is a string property
                    result = True
                End If
            Case GetType(System.Windows.Forms.TextBox)
                If control.Text = value.ToString() Then
                    result = True
                End If
            Case GetType(System.Windows.Forms.CheckBox)
                If control.checked = value Then
                    result = True
                End If
            Case GetType(System.Windows.Forms.ComboBox)     ' Not sure if this one will pan out properly. We'll test and see
                If (control.SelectedValue = value) Or (control.Text = value) Then
                    result = True
                End If
        End Select

        Return result

    End Function

    ' OR just make function that somehow returns control.ATTRIBUTE
    ' This woudld replace both setControlValue and compareControlValue



    ' Function that dynamically dataTable column values (from a provided row) and maps them to their respective fields by name
    '   Controls on form that are to be set to a value from the dataTable should be NAMED as follows:
    '       <columnName from dataTable>_controlType
    '       E.g. CompanyName1_Textbox
    '   The underscore is how this function will differentiate between regular elements and those that are to have their valuesSet/Initialized
    ' CONSIDER: This function and some of its attributes could be transformed into a class for greatere reusability and utility for the future
    Public Sub initializeControlsFromRow(ByVal dataTable As DataTable, ByVal dataTableRow As Integer, ByVal nameDelimiter As String, ByRef form As Form)

        Dim ctrls As List(Of Object)
        Dim dataValue As Object

        ' For each column in the dataTable
        For i As Integer = 0 To dataTable.Columns.Count - 1

            ' Get all of the controls on the form that are to be set/initialized by way of matching the first part of their name to the column name
            ctrls = getAllControlsWithName(dataTable.Columns(i).ColumnName, nameDelimiter, form)

            ' Initialize values of each control that holds the value of this column
            For Each ctrl In ctrls

                dataValue = dataTable.Rows(dataTableRow)(dataTable.Columns(i).ColumnName)
                setControlValue(ctrl, dataValue)

            Next


        Next

    End Sub

End Module
