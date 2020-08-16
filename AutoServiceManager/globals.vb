Module globals




    ' ************************ CONTROL MANIPULATION ************************


    ' Used to return all items of a certain group (items that have the same identifying tag) as an iterable ArrayList.
    Public Function getAllControlsWithTag(ByVal tag As String, ByRef form As Form) As List(Of Object)

        Dim ctrls As New List(Of Object)

        For Each ctrl In form.Controls
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


    ' Overload Function used to return list of all items beginning with a certain name prefix delimmited by character
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

    ' overLoad that allows function to filter controls it collects using a tag
    Public Function getAllControlsWithName(ByVal name As String, ByVal tag As String, ByVal nameDelimiter As String, ByRef form As Form) As List(Of Object)

        Dim ctrls As New List(Of Object)

        For Each ctrl In form.Controls
            If ctrl.Name.ToString().IndexOf(nameDelimiter) > 0 Then
                If ctrl.Name.ToString().Substring(0, ctrl.Name.ToString().IndexOf(nameDelimiter)) = name And ctrl.Tag = tag Then
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


    ' Function that dynamically gets value of a control based on type of control
    Public Function getControlValue(ByRef ctrl As Object) As Object

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


    ' Function that can dynamically set value for control based on what type of control the data is being assigned to.
    Public Sub setControlValue(ByRef control As Object, ByVal value As Object)

        ' Add additional controls here if necessary
        Select Case control.GetType()
            Case GetType(System.Windows.Forms.Label)
                control.Text = value.ToString()
            Case GetType(System.Windows.Forms.TextBox), GetType(System.Windows.Forms.MaskedTextBox)
                control.Text = value.ToString()
            Case GetType(System.Windows.Forms.CheckBox)
                control.Checked = value
            Case GetType(System.Windows.Forms.ComboBox)
                ' May need debugging
                'Console.WriteLine("Value to write: " & value.ToString() & " " & value.GetType().ToString())
                'control.SelectedValue = value      ' If this becomes a problem later, revert to just setting the text of the combobox
                control.Text = value
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
            Case GetType(System.Windows.Forms.TextBox), GetType(System.Windows.Forms.MaskedTextBox)
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


    ' Sub that will clear controls values
    Public Sub clearControls(ByRef ctrls As List(Of Object))

        For Each ctrl In ctrls
            Select Case ctrl.GetType()
                Case GetType(System.Windows.Forms.CheckBox)
                    ctrl.checked = False
                Case Else
                    ctrl.Text = String.Empty
            End Select
        Next

    End Sub


    ' Sub that is primarily used to reset forecolor of invalid controls after re-initializing
    Public Sub setForeColor(ByVal ctrls As List(Of Object), ByVal color As Color)

        For Each ctrl In ctrls
            ctrl.ForeColor = color
        Next

    End Sub


    ' Function that returns similar string but with proper escape characters applied (for use with DataTable select)
    Public Function escapeLikeValues(ByVal original As String) As String

        Dim sb As New System.Text.StringBuilder(original.Length)

        For i As Integer = 0 To original.Length - 1

            Dim c As Char = original(i)
            Select Case c
                Case "]", "[", "%", "*"
                    sb.Append("[").Append(c).Append("]")
                Case "'"
                    sb.Append("''")
                Case Else
                    sb.Append(c)
            End Select

        Next

        Return sb.ToString()

    End Function


    ' Function that returns string but only the characters of that string that are valid, per a provided list
    Public Function removeInvalidChars(ByVal original As String, ByVal validChars As String) As String

        Dim sb As New System.Text.StringBuilder(original.Length)
        For i As Integer = 0 To original.Length - 1

            Dim c As Char = original(i)

            If InStr(validChars, c.ToString()) <> 0 Then
                sb.Append(c)
            End If

        Next

        Return sb.ToString()

    End Function


    ' Function that returns an object with the default value of its provided DataType
    Public Function setToDefaultValue(ByVal dataType As Object) As Object

        Dim ctrlValue As Object

        Select Case dataType
            Case GetType(System.DateTime)
                ctrlValue = New DateTime
            Case GetType(System.String)
                ctrlValue = String.Empty
                            'Console.WriteLine("DataType is " & dataValue.GetType().ToString() & ". Does datavalue = String.Empty?: " & (dataValue = String.Empty))
            Case GetType(System.Boolean)
                ctrlValue = False
            Case Else
                ctrlValue = 0
        End Select

        Return ctrlValue

    End Function




    ' ************************ DATABASE DATA INTERACTION/MANIPULATION ************************


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

    ' Overload that allows for specifying a control tag
    Public Sub initializeControlsFromRow(ByVal dataTable As DataTable, ByVal dataTableRow As Integer, ByVal controlTag As String, ByVal nameDelimiter As String, ByRef form As Form)

        Dim ctrls As List(Of Object)
        Dim dataValue As Object

        ' For each column in the dataTable
        For i As Integer = 0 To dataTable.Columns.Count - 1

            ' Get all of the controls on the form that are to be set/initialized by way of matching the first part of their name to the column name
            ctrls = getAllControlsWithName(dataTable.Columns(i).ColumnName, controlTag, nameDelimiter, form)

            ' Initialize values of each control that holds the value of this column
            For Each ctrl In ctrls

                dataValue = dataTable.Rows(dataTableRow)(dataTable.Columns(i).ColumnName)
                setControlValue(ctrl, dataValue)

            Next


        Next

    End Sub


    ' Sub that updates database tables based on their respective values in form
    Public Sub updateTable(ByRef updateController As DbControl, ByVal dataTable As DataTable, ByVal tableName As String,
                           ByVal nameDelimiter As String, ByVal controlTag As String, ByRef form As Form)

        Dim ctrls As List(Of Object)
        Dim ctrlValue As Object
        Dim queryParams As String = String.Empty

        ' Add query parameters for each column value in DataTable
        For i As Integer = 0 To dataTable.Columns.Count - 1

            ctrls = getAllControlsWithName(dataTable.Columns(i).ColumnName, controlTag, nameDelimiter, form)

            If ctrls.Count = 0 Then Continue For

            ' Get the value of only one control of the same name designation (assuming they control/correspond with the same table column value)
            ctrlValue = getControlValue(ctrls(0))

            ' To determine if we're going to insert a null instead of the value, we must consider all different types of values that warrant a DBNull insert
            ' First, check if it's a DateTime field
            If dataTable.Columns(i).DataType = GetType(DateTime) Then
                If ctrlValue.ToString().Replace(" ", "0") = "00/00/0000" Then ctrlValue = DBNull.Value
                ' For all other types of fields
            Else
                If ctrlValue = Nothing Then ctrlValue = DBNull.Value
            End If

            updateController.AddParams("@" & dataTable.Columns(i).ColumnName, ctrlValue)
            queryParams += dataTable.Columns(i).ColumnName & "=@" & dataTable.Columns(i).ColumnName & ","

        Next

        If Not String.IsNullOrEmpty(queryParams) Then
            ' The substring at the end ensures that there isn't an extra comma at the end
            queryParams = queryParams.Substring(0, queryParams.Length - 1)
            updateController.ExecQuery("UPDATE " & tableName & " SET " & queryParams)
        End If

    End Sub


    ' Overload that allows specifying a row to update
    Public Sub updateTable(ByRef updateController As DbControl, ByVal dataTable As DataTable, ByVal tableName As String, ByVal id As Object,
                           ByVal idName As String, ByVal nameDelimiter As String, ByVal controlTag As String, ByRef form As Form)

        Dim ctrls As List(Of Object)
        Dim ctrlValue As Object
        Dim queryParams As String = String.Empty
        Dim whereID As String = String.Empty

        ' Add query parameters for each column value in DataTable
        For i As Integer = 0 To dataTable.Columns.Count - 1

            ctrls = getAllControlsWithName(dataTable.Columns(i).ColumnName, controlTag, nameDelimiter, form)

            If ctrls.Count = 0 Then Continue For

            ' Get the value of only one control of the same name designation (assuming they control/correspond with the same table column value)
            ctrlValue = getControlValue(ctrls(0))

            ' To determine if we're going to insert a null instead of the value, we must consider all different types of values that warrant a DBNull insert
            ' First, check if it's a DateTime field
            If dataTable.Columns(i).DataType = GetType(DateTime) Then
                If ctrlValue.ToString().Replace(" ", "0") = "00/00/0000" Then ctrlValue = DBNull.Value
                ' For all other types of fields
            Else
                If ctrlValue = Nothing Then ctrlValue = DBNull.Value
            End If

            updateController.AddParams("@" & dataTable.Columns(i).ColumnName, ctrlValue)
            queryParams += dataTable.Columns(i).ColumnName & "=@" & dataTable.Columns(i).ColumnName & ","

        Next

        '' Add on id paramater if not already done so from a form control
        'If InStr(queryParams, idName) = 0 Then
        '    updateController.AddParams("@" & idName, id)
        'End If
        updateController.AddParams("@id", id)
        whereID = " WHERE " & idName & "=@id"

        ' If query params isn't empty, then run update query
        If Not String.IsNullOrEmpty(queryParams) Then
            ' The substring at the end ensures that there isn't an extra comma at the end
            queryParams = queryParams.Substring(0, queryParams.Length - 1)
            updateController.ExecQuery("UPDATE " & tableName & " SET " & queryParams & whereID)
        End If

    End Sub

    ' Overload that allows specifying a list of controls to exclude from updating their values in a given row
    Public Sub updateTable(ByRef updateController As DbControl, ByVal dataTable As DataTable, ByVal tableName As String, ByVal id As Object,
                           ByVal idName As String, ByVal nameDelimiter As String, ByVal controlTag As String, ByRef form As Form,
                           ByVal excludedControls As List(Of Control))

        Dim ctrls As List(Of Object)
        Dim ctrlValue As Object
        Dim queryParams As String = String.Empty
        Dim whereID As String = String.Empty

        ' Add query parameters for each column value in DataTable
        For i As Integer = 0 To dataTable.Columns.Count - 1

            ctrls = getAllControlsWithName(dataTable.Columns(i).ColumnName, controlTag, nameDelimiter, form)

            If ctrls.Count = 0 Then Continue For
            If excludedControls.Contains(ctrls(0)) Then Continue For

            ' Get the value of only one control of the same name designation (assuming they control/correspond with the same table column value)
            ctrlValue = getControlValue(ctrls(0))

            ' To determine if we're going to insert a null instead of the value, we must consider all different types of values that warrant a DBNull insert
            ' First, check if it's a DateTime field
            If dataTable.Columns(i).DataType = GetType(DateTime) Then
                If ctrlValue.ToString().Replace(" ", "0") = "00/00/0000" Then ctrlValue = DBNull.Value
                ' For all other types of fields
            Else
                If ctrlValue = Nothing Then ctrlValue = DBNull.Value
            End If

            updateController.AddParams("@" & dataTable.Columns(i).ColumnName, ctrlValue)
            queryParams += dataTable.Columns(i).ColumnName & "=@" & dataTable.Columns(i).ColumnName & ","

        Next

        '' Add on id paramater if not already done so from a form control
        'If InStr(queryParams, idName) = 0 Then
        '    updateController.AddParams("@" & idName, id)
        'End If
        updateController.AddParams("@id", id)
        whereID = " WHERE " & idName & "=@id"

        ' If query params isn't empty, then run update query
        If Not String.IsNullOrEmpty(queryParams) Then
            ' The substring at the end ensures that there isn't an extra comma at the end
            queryParams = queryParams.Substring(0, queryParams.Length - 1)
            updateController.ExecQuery("UPDATE " & tableName & " SET " & queryParams & whereID)
        End If

    End Sub

    ' Overload that accepts a list of additional values to be updated with the rest of the data, AS WELL AS a list of controls whose values should be excluded from updated
    Public Sub updateTable(ByRef updateController As DbControl, ByVal dataTable As DataTable, ByVal tableName As String, ByVal id As Object,
                           ByVal idName As String, ByVal nameDelimiter As String, ByVal controlTag As String, ByRef form As Form,
                           ByVal excludedControls As List(Of Control), ByVal additionalValues As List(Of AdditionalValue))

        Dim ctrls As List(Of Object)
        Dim ctrlValue As Object
        Dim queryParams As String = String.Empty
        Dim whereID As String = String.Empty

        ' Add query parameters for each column value in DataTable
        For i As Integer = 0 To dataTable.Columns.Count - 1

            ctrls = getAllControlsWithName(dataTable.Columns(i).ColumnName, controlTag, nameDelimiter, form)

            If ctrls.Count = 0 Then Continue For
            If excludedControls.Contains(ctrls(0)) Then Continue For

            ' Get the value of only one control of the same name designation (assuming they control/correspond with the same table column value)
            ctrlValue = getControlValue(ctrls(0))

            ' To determine if we're going to insert a null instead of the value, we must consider all different types of values that warrant a DBNull insert
            ' First, check if it's a DateTime field
            If dataTable.Columns(i).DataType = GetType(DateTime) Then
                If ctrlValue.ToString().Replace(" ", "0") = "00/00/0000" Then ctrlValue = DBNull.Value
                ' For all other types of fields
            Else
                If ctrlValue = Nothing Then ctrlValue = DBNull.Value
            End If

            updateController.AddParams("@" & dataTable.Columns(i).ColumnName, ctrlValue)
            queryParams += dataTable.Columns(i).ColumnName & "=@" & dataTable.Columns(i).ColumnName & ","

        Next

        Dim addValue As Object

        ' Add additional query parameters for additionalValues as provided
        For Each additional In additionalValues

            ' Get additional value
            addValue = additional.Value

            ' Then, check if this additional value that is to be inserted should be a DBNull Value
            If additional.ColumnDataType = GetType(DateTime) Then
                If addValue.ToString().Replace(" ", "0") = "00/00/0000" Then addValue = DBNull.Value
                ' For all other types of fields
            Else
                If addValue = Nothing Then addValue = DBNull.Value
            End If

            updateController.AddParams("@" & additional.ColumnName, addValue)
            queryParams += additional.ColumnName & "=@" & additional.ColumnName & ","

        Next


        updateController.AddParams("@id", id)
        whereID = " WHERE " & idName & "=@id"

        ' If query params isn't empty, then run update query
        If Not String.IsNullOrEmpty(queryParams) Then
            ' The substring at the end ensures that there isn't an extra comma at the end
            queryParams = queryParams.Substring(0, queryParams.Length - 1)
            updateController.ExecQuery("UPDATE " & tableName & " SET " & queryParams & whereID)
        End If

    End Sub


    ' Sub that updates Database tables based on their respective control values on form using (initial) datatable values as keys for the update
    Public Sub updateTable(ByRef updateController As DbControl, ByVal dataTable As DataTable, ByVal dataTableRow As Integer,
                           ByVal excludedKeyColumns As List(Of String), ByVal tableName As String,
                           ByVal nameDelimiter As String, ByVal controlTag As String,
                           ByRef form As Form, ByVal excludedControls As List(Of Control))

        Dim query As String = String.Empty

        Dim ctrls As List(Of Object)
        Dim ctrlValue As Object
        Dim valueParams As String = String.Empty    ' Used after SET in query

        ' Add parameters for each value that is to be updated in SET clause of query
        For i As Integer = 0 To dataTable.Columns.Count - 1

            ctrls = getAllControlsWithName(dataTable.Columns(i).ColumnName, controlTag, nameDelimiter, form)

            If ctrls.Count = 0 Then Continue For
            If excludedControls.Contains(ctrls(0)) Then Continue For

            ctrlValue = getControlValue(ctrls(0))

            ' Determine if we're going to insert a null instead of the value
            ' First, check if it's a DateTime field
            If dataTable.Columns(i).DataType = GetType(DateTime) Then
                If ctrlValue.ToString().Replace(" ", "0") = "00/00/0000" Then ctrlValue = DBNull.Value
                ' For all other types of fields
            Else
                If ctrlValue = Nothing Then ctrlValue = DBNull.Value
            End If

            updateController.AddParams("@" & dataTable.Columns(i).ColumnName, ctrlValue)
            valueParams += dataTable.Columns(i).ColumnName & "=@" & dataTable.Columns(i).ColumnName
            If Not i = dataTable.Columns.Count - 1 Then valueParams += ","

        Next

        Dim keyValue As Object
        Dim isKeyDefaultValue As Boolean = False
        Dim keyParams As String = String.Empty      ' Used after WHERE in query

        ' Add parameters for each value used (as key) in WHERE clause of query
        For i As Integer = 0 To dataTable.Columns.Count - 1

            ' Get keyValue from DataTable
            keyValue = dataTable.Rows(dataTableRow)(dataTable.Columns(i).ColumnName)

            updateController.AddParams("@" & dataTable.Columns(i).ColumnName & "Key", keyValue)

            ' Then, determine if this keyValue is a default value.
            Select Case dataTable.Columns(i).DataType
                Case GetType(System.DateTime)
                    If keyValue = "00/00/0000" Then isKeyDefaultValue = True
                Case GetType(System.String)
                    If keyValue = String.Empty Then isKeyDefaultValue = True
                Case GetType(System.Int32), GetType(System.Decimal), GetType(System.Double)
                    If keyValue = 0 Then isKeyDefaultValue = True
                Case Else
                    If keyValue = 0 Then isKeyDefaultValue = True
            End Select

            ' if it is, then we want to append a slightly different keyParam string that checks for EITHER: default value or NULL
            If isKeyDefaultValue Then
                keyParams += "(" & dataTable.Columns(i).ColumnName & "=@" & dataTable.Columns(i).ColumnName & "Key" & " OR IsNull(" & dataTable.Columns(i).ColumnName & "))"
                If Not i = dataTable.Columns.Count - 1 Then keyParams += " AND "

                ' If not, append normal param string for WHERE clause
            Else
                keyParams += dataTable.Columns(i).ColumnName & "=@" & dataTable.Columns(i).ColumnName & "Key"
                If Not i = dataTable.Columns.Count - 1 Then keyParams += " AND "
            End If

        Next

        ' Finally, build query
        query += "UPDATE " & tableName & " SET " & valueParams & " WHERE " & keyParams
        'Console.WriteLine(query)
        updateController.ExecQuery(query)

    End Sub


    ' Sub that inserts new row into specified table
    Public Sub insertRow(ByRef insertController As DbControl, ByVal dataTable As DataTable, ByVal tableName As String,
                         ByVal nameDelimiter As String, ByVal controlTag As String, ByRef form As Form)

        Dim ctrls As List(Of Object)
        Dim ctrlValue As Object
        Dim columnList As String = String.Empty
        Dim valuesParamList As String = String.Empty


        ' Add query parameters for each column value in DataTable
        For i As Integer = 0 To dataTable.Columns.Count - 1

            ctrls = getAllControlsWithName(dataTable.Columns(i).ColumnName, controlTag, nameDelimiter, form)

            If ctrls.Count = 0 Then Continue For

            ' Get the value of only one control of the same name designation (assuming they control/correspond with the same table column value)
            ctrlValue = getControlValue(ctrls(0))

            ' To determine if we're going to insert a null instead of the value, we must consider all different types of values that warrant a DBNull insert
            ' First, check if it's a DateTime field
            If dataTable.Columns(i).DataType = GetType(DateTime) Then
                If ctrlValue.ToString().Replace(" ", "0") = "00/00/0000" Then ctrlValue = DBNull.Value
                ' For all other types of fields
            Else
                If ctrlValue = Nothing Then ctrlValue = DBNull.Value
            End If

            insertController.AddParams("@" & dataTable.Columns(i).ColumnName, ctrlValue)
            columnList += dataTable.Columns(i).ColumnName & ","
            valuesParamList += "@" & dataTable.Columns(i).ColumnName & ","

        Next

        ' If lists aren't empty, then run query
        If Not String.IsNullOrEmpty(columnList) And Not String.IsNullOrEmpty(valuesParamList) Then
            ' The substring at the end ensures that there isn't an extra comma at the end
            columnList = "(" & columnList.Substring(0, columnList.Length - 1) & ")"
            valuesParamList = "(" & valuesParamList.Substring(0, valuesParamList.Length - 1) & ")"
            insertController.ExecQuery("INSERT INTO " & tableName & " " & columnList & " VALUES " & valuesParamList)
        End If

    End Sub

    ' Overload that allows specifying a list of controls to exclude from inserting their values in a given row
    Public Sub insertRow(ByRef insertController As DbControl, ByVal dataTable As DataTable, ByVal tableName As String,
                         ByVal nameDelimiter As String, ByVal controlTag As String, ByRef form As Form,
                         ByVal excludedControls As List(Of Control))

        Dim ctrls As List(Of Object)
        Dim ctrlValue As Object
        Dim columnList As String = String.Empty
        Dim valuesParamList As String = String.Empty


        ' Add query parameters for each column value in DataTable
        For i As Integer = 0 To dataTable.Columns.Count - 1

            ctrls = getAllControlsWithName(dataTable.Columns(i).ColumnName, controlTag, nameDelimiter, form)

            If ctrls.Count = 0 Then Continue For
            If excludedControls.Contains(ctrls(0)) Then Continue For

            ' Get the value of only one control of the same name designation (assuming they control/correspond with the same table column value)
            ctrlValue = getControlValue(ctrls(0))

            ' To determine if we're going to insert a null instead of the value, we must consider all different types of values that warrant a DBNull insert
            ' First, check if it's a DateTime field
            If dataTable.Columns(i).DataType = GetType(DateTime) Then
                If ctrlValue.ToString().Replace(" ", "0") = "00/00/0000" Then ctrlValue = DBNull.Value
                ' For all other types of fields
            Else
                If ctrlValue = Nothing Then ctrlValue = DBNull.Value
            End If

            insertController.AddParams("@" & dataTable.Columns(i).ColumnName, ctrlValue)
            columnList += dataTable.Columns(i).ColumnName & ","
            valuesParamList += "@" & dataTable.Columns(i).ColumnName & ","

        Next

        ' If lists aren't empty, then run query
        If Not String.IsNullOrEmpty(columnList) And Not String.IsNullOrEmpty(valuesParamList) Then
            ' The substring at the end ensures that there isn't an extra comma at the end
            columnList = "(" & columnList.Substring(0, columnList.Length - 1) & ")"
            valuesParamList = "(" & valuesParamList.Substring(0, valuesParamList.Length - 1) & ")"
            insertController.ExecQuery("INSERT INTO " & tableName & " " & columnList & " VALUES " & valuesParamList)
        End If

    End Sub

    ' Overload that accepts a list of additional values to be inserted with the rest of the data
    Public Sub insertRow(ByRef insertController As DbControl, ByVal dataTable As DataTable, ByVal tableName As String,
                     ByVal nameDelimiter As String, ByVal controlTag As String, ByRef form As Form,
                     ByVal additionalValues As List(Of AdditionalValue))

        Dim ctrls As List(Of Object)
        Dim ctrlValue As Object
        Dim columnList As String = String.Empty
        Dim valuesParamList As String = String.Empty


        ' Add query parameters for each column value in DataTable
        For i As Integer = 0 To dataTable.Columns.Count - 1

            ctrls = getAllControlsWithName(dataTable.Columns(i).ColumnName, controlTag, nameDelimiter, form)

            If ctrls.Count = 0 Then Continue For

            ' Get the value of only one control of the same name designation (assuming they control/correspond with the same table column value)
            ctrlValue = getControlValue(ctrls(0))

            ' To determine if we're going to insert a null instead of the value, we must consider all different types of values that warrant a DBNull insert
            ' First, check if it's a DateTime field
            If dataTable.Columns(i).DataType = GetType(DateTime) Then
                If ctrlValue.ToString().Replace(" ", "0") = "00/00/0000" Then ctrlValue = DBNull.Value
                ' For all other types of fields
            Else
                If ctrlValue = Nothing Then ctrlValue = DBNull.Value
            End If

            insertController.AddParams("@" & dataTable.Columns(i).ColumnName, ctrlValue)
            columnList += dataTable.Columns(i).ColumnName & ","
            valuesParamList += "@" & dataTable.Columns(i).ColumnName & ","

        Next


        Dim addValue As Object

        ' Add additional query parameters for additionalValues as provided
        For Each additional In additionalValues

            ' Get additional value
            addValue = additional.Value

            ' Then, check if this additional value that is to be inserted should be a DBNull Value
            If additional.ColumnDataType = GetType(DateTime) Then
                If addValue.ToString().Replace(" ", "0") = "00/00/0000" Then addValue = DBNull.Value
                ' For all other types of fields
            Else
                If addValue = Nothing Then addValue = DBNull.Value
            End If

            insertController.AddParams("@" & additional.ColumnName, addValue)
            columnList += additional.ColumnName & ","
            valuesParamList += "@" & additional.ColumnName & ","

        Next

        ' If lists aren't empty, then run query
        If Not String.IsNullOrEmpty(columnList) And Not String.IsNullOrEmpty(valuesParamList) Then
            ' The substring at the end ensures that there isn't an extra comma at the end
            columnList = "(" & columnList.Substring(0, columnList.Length - 1) & ")"
            valuesParamList = "(" & valuesParamList.Substring(0, valuesParamList.Length - 1) & ")"
            'Console.WriteLine("INSERT INTO " & tableName & " " & columnList & " VALUES " & valuesParamList)
            insertController.ExecQuery("INSERT INTO " & tableName & " " & columnList & " VALUES " & valuesParamList)
        End If

    End Sub

    ' Overload that accepts a list of additional values to be inserted with the rest of the data, AS WELL AS a list of controls whose values should be excluded from insertion
    Public Sub insertRow(ByRef insertController As DbControl, ByVal dataTable As DataTable, ByVal tableName As String,
                     ByVal nameDelimiter As String, ByVal controlTag As String, ByRef form As Form,
                     ByVal excludedControls As List(Of Control), ByVal additionalValues As List(Of AdditionalValue))

        Dim ctrls As List(Of Object)
        Dim ctrlValue As Object
        Dim columnList As String = String.Empty
        Dim valuesParamList As String = String.Empty


        ' Add query parameters for each column value in DataTable
        For i As Integer = 0 To dataTable.Columns.Count - 1

            ctrls = getAllControlsWithName(dataTable.Columns(i).ColumnName, controlTag, nameDelimiter, form)

            If ctrls.Count = 0 Then Continue For
            If excludedControls.Contains(ctrls(0)) Then Continue For

            ' Get the value of only one control of the same name designation (assuming they control/correspond with the same table column value)
            ctrlValue = getControlValue(ctrls(0))

            ' To determine if we're going to insert a null instead of the value, we must consider all different types of values that warrant a DBNull insert
            ' First, check if it's a DateTime field
            If dataTable.Columns(i).DataType = GetType(DateTime) Then
                If ctrlValue.ToString().Replace(" ", "0") = "00/00/0000" Then ctrlValue = DBNull.Value
                ' For all other types of fields
            Else
                If ctrlValue = Nothing Then ctrlValue = DBNull.Value
            End If

            insertController.AddParams("@" & dataTable.Columns(i).ColumnName, ctrlValue)
            columnList += dataTable.Columns(i).ColumnName & ","
            valuesParamList += "@" & dataTable.Columns(i).ColumnName & ","

        Next


        Dim addValue As Object

        ' Add additional query parameters for additionalValues as provided
        For Each additional In additionalValues

            ' Get additional value
            addValue = additional.Value

            ' Then, check if this additional value that is to be inserted should be a DBNull Value
            If additional.ColumnDataType = GetType(DateTime) Then
                If addValue.ToString().Replace(" ", "0") = "00/00/0000" Then addValue = DBNull.Value
                ' For all other types of fields
            Else
                If addValue = Nothing Then addValue = DBNull.Value
            End If

            insertController.AddParams("@" & additional.ColumnName, addValue)
            columnList += additional.ColumnName & ","
            valuesParamList += "@" & additional.ColumnName & ","

        Next

        ' If lists aren't empty, then run query
        If Not String.IsNullOrEmpty(columnList) And Not String.IsNullOrEmpty(valuesParamList) Then
            ' The substring at the end ensures that there isn't an extra comma at the end
            columnList = "(" & columnList.Substring(0, columnList.Length - 1) & ")"
            valuesParamList = "(" & valuesParamList.Substring(0, valuesParamList.Length - 1) & ")"
            'Console.WriteLine("INSERT INTO " & tableName & " " & columnList & " VALUES " & valuesParamList)
            insertController.ExecQuery("INSERT INTO " & tableName & " " & columnList & " VALUES " & valuesParamList)
        End If

    End Sub


    ' Sub that deletes row from specified table
    Public Sub deleteRow(ByRef deleteController As DbControl, ByVal tableName As String, ByVal id As String, ByVal idName As String)

        deleteController.AddParams("@id", id)
        deleteController.ExecQuery("DELETE FROM " & tableName & " WHERE " & idName & "=@id")

    End Sub


    ' Sub that deletes row from specified table based on datatable values as keys
    Public Sub deleteRow(ByRef deleteController As DbControl, ByVal dataTable As DataTable, ByVal dataTableRow As Integer,
                           ByVal excludedKeyColumns As List(Of String), ByVal tableName As String)

        Dim query As String = String.Empty

        Dim keyValue As Object
        Dim isKeyDefaultValue As Boolean = False
        Dim keyParams As String = String.Empty      ' Used after WHERE in query

        ' Add parameters for each value used (as key) in WHERE clause of query
        For i As Integer = 0 To dataTable.Columns.Count - 1

            ' Get keyValue from DataTable
            keyValue = dataTable.Rows(dataTableRow)(dataTable.Columns(i).ColumnName)

            deleteController.AddParams("@" & dataTable.Columns(i).ColumnName & "Key", keyValue)

            ' Then, determine if this keyValue is a default value.
            Select Case dataTable.Columns(i).DataType
                Case GetType(System.DateTime)
                    If keyValue = "00/00/0000" Then isKeyDefaultValue = True
                Case GetType(System.String)
                    If keyValue = String.Empty Then isKeyDefaultValue = True
                Case GetType(System.Int32), GetType(System.Decimal), GetType(System.Double)
                    If keyValue = 0 Then isKeyDefaultValue = True
                Case Else
                    If keyValue = 0 Then isKeyDefaultValue = True
            End Select

            ' if it is, then we want to append a slightly different keyParam string that checks for EITHER: default value or NULL
            If isKeyDefaultValue Then
                keyParams += "(" & dataTable.Columns(i).ColumnName & "=@" & dataTable.Columns(i).ColumnName & "Key" & " OR IsNull(" & dataTable.Columns(i).ColumnName & "))"
                If Not i = dataTable.Columns.Count - 1 Then keyParams += " AND "

                ' If not, append normal param string for WHERE clause
            Else
                keyParams += dataTable.Columns(i).ColumnName & "=@" & dataTable.Columns(i).ColumnName & "Key"
                If Not i = dataTable.Columns.Count - 1 Then keyParams += " AND "
            End If

        Next

        ' Finally, build query
        query += "DELETE FROM " & tableName & " WHERE " & keyParams
        'Console.WriteLine(query)
        deleteController.ExecQuery(query)

    End Sub


    ' Function that checks database connection
    Public Function checkDbConn(Optional Report As Boolean = True) As Boolean

        Dim testConn As New DbControl()

        testConn.ExecQuery("SELECT 1")
        If testConn.HasException() Then
            If Report Then MessageBox.Show("Failed to connect to database; Please restart and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        Return True

    End Function




    ' ************************ DATATABLE DATA INTERACTION/MANIPULATION ************************


    ' Function that dynamically updates dataTable column values (of a provided row) based on corresponding form control values of a specified control tag and name delimiter
    Public Sub updateDataTable(ByVal dataTable As DataTable, ByVal dataTableRow As Integer, ByVal nameDelimiter As String, ByVal controlTag As String, ByRef form As Form)

        Dim ctrls As List(Of Object)
        Dim ctrlValue As Object

        For i As Integer = 0 To dataTable.Columns.Count - 1

            ctrls = getAllControlsWithName(dataTable.Columns(i).ColumnName, controlTag, nameDelimiter, form)

            If ctrls.Count = 0 Then Continue For

            ctrlValue = getControlValue(ctrls(0))

            ' To determine if we're going to insert a default (in place of a nothing value) instead of a value, we must consider all different types of values that warrant defaulting a value
            ' First, check if it's a DateTime field
            If dataTable.Columns(i).DataType = GetType(DateTime) Then
                ' When this dataTable is actually written to a database, this New DataTime() could end up just getting turned into a DBNull
                If ctrlValue.ToString().Replace(" ", "0") = "00/00/0000" Then ctrlValue = New DateTime()

                ' For all other types of fields
            ElseIf ctrlValue = Nothing Then

                ctrlValue = setToDefaultValue(dataTable.Columns(i).DataType)

            End If

            ' Finally, assign ctrlValue to DataTable cell
            dataTable.Rows(dataTableRow)(dataTable.Columns(i).ColumnName) = ctrlValue

        Next

    End Sub


    ' Function that generates sorted lists from datatable columns. Useful if binary search on values used.
    Public Function getListFromDataTable(ByVal datatable As DataTable, ByVal column As String, Optional ByVal sorted As Boolean = True) As List(Of Object)

        Dim values As New List(Of Object)

        For Each row In datatable.Rows
            values.Add(row(column))
        Next

        If sorted Then values.Sort()

        Return values

    End Function


    ' Function that returns the index of a certain DataTable row based on a certain column value/entry provided
    Public Function getDataTableRow(ByVal dataTable As DataTable, ByVal column As String, ByVal keyorvalue As String) As Integer

        Dim escapedText As String = escapeLikeValues(keyorvalue)

        Try
            Dim dataRows() As DataRow = dataTable.Select(column & " LIKE '" & escapedText & "'")
            If dataRows.Count <> 0 Then
                Dim rowIndex As Integer = dataTable.Rows.IndexOf(dataRows(0))
                Return rowIndex
            Else Return -1
            End If
        Catch ex As Exception
            Return -1
        End Try

    End Function

    ' GetDataTableRow but that uses '=' comparison instead of LIKE
    Public Function getDataTableRowEquals(ByVal dataTable As DataTable, ByVal column As String, ByVal keyorvalue As Object) As Integer

        Dim escapedText As String = escapeLikeValues(keyorvalue)

        Try
            Dim dataRows() As DataRow = dataTable.Select(column & " = '" & escapedText & "'")
            If dataRows.Count <> 0 Then
                Dim rowIndex As Integer = dataTable.Rows.IndexOf(dataRows(0))
                Return rowIndex
            Else Return -1
            End If
        Catch ex As Exception
            Return -1
        End Try

    End Function


    ' Function that returns value from specified row and column
    Public Function getRowValue(ByVal dataTable As DataTable, ByVal row As Integer, ByVal valueColumn As String) As Object

        ' This function shuold never throw an exception if used in conjunction with getDataTableRow, but try/catch just in case
        Try
            Dim value As Object = dataTable.Rows(row)(valueColumn)
            Return value
        Catch ex As Exception
            Return Nothing
        End Try


    End Function


    ' Function that returns value from same row but different column provided another column value from that row as the key
    Public Function getRowValueWithKey(ByVal dataTable As DataTable, ByVal desiredColumn As String, ByVal keyColumn As String, ByVal key As String) As Object

        Dim rowIndex As Integer = getDataTableRow(dataTable, keyColumn, key)
        Try
            If rowIndex >= 0 Then
                Dim value As Object = dataTable.Rows(rowIndex)(desiredColumn)
                Return value
            Else Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    ' getRowValueWithKey but that uses getDataTableRowEquals instead of LIKE variant
    Public Function getRowValueWithKeyEquals(ByVal dataTable As DataTable, ByVal desiredColumn As String, ByVal keyColumn As String, ByVal key As Object) As Object

        Dim rowIndex As Integer = getDataTableRowEquals(dataTable, keyColumn, key)
        Try
            If rowIndex >= 0 Then
                Dim value As Object = dataTable.Rows(rowIndex)(desiredColumn)
                Return value
            Else Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try

    End Function





    ' **************** KEYPRESS/INPUT VALIDATION ****************

    Public Function percentInputValid(ByVal ctrl As Object, ByRef keyChar As String) As Boolean

        Dim valid As Boolean = True

        ' First, ignore any input that isn't an number, period, or backspace
        If (InStr("1234567890Oo.", keyChar) = 0 And Asc(keyChar) <> 8) Or (keyChar = "." And InStr(ctrl.Text, ".") > 0) Then
            valid = False
            ' If it's a valid number or period, then check for length on right side of decimal, IF there is a decimal
        ElseIf InStr(ctrl.Text, ".") > 0 Then

            ' If the # of decimal places is already 2, and the cursor is on the right of said decimal place, and the keystroke is not a backspace
            If ctrl.Text.Split(".")(1).Length = 2 And ctrl.SelectionStart >= InStr(ctrl.Text, ".") And Asc(keyChar) <> 8 And Not ctrl.SelectionLength > 0 Then
                valid = False
                ' If the # of digits before decimal is already 3, the cursor is behind the decimal, and it's not a backspace
            ElseIf ctrl.Text.Split(".")(0).Length = 3 And ctrl.SelectionStart < InStr(ctrl.Text, ".") And Asc(keyChar) <> 8 And Not ctrl.SelectionLength > 0 Then
                valid = False
            End If

            ' If there is no decimal place
        ElseIf InStr(ctrl.Text, ".") = 0 Then

            ' If the length is 3 and it's not a backspace or a decimal place
            If ctrl.Text.Length = 3 And Asc(keyChar) <> 8 And Not keyChar = "." And Not ctrl.SelectionLength > 0 Then
                valid = False
            End If

        End If

        If keyChar.ToLower() = "o" Then
            keyChar = Chr(48)
        End If

        Return valid

    End Function


    Public Function currencyInputValid(ByVal ctrl As Object, ByRef keyChar As String) As Boolean

        Dim valid As Boolean = True

        ' First, ignore any input that isn't an number, period, or backspace
        If (InStr("1234567890Oo.", keyChar) = 0 And Asc(keyChar) <> 8) Or (keyChar = "." And InStr(ctrl.Text, ".") > 0) Then
            valid = False
            ' If it's a valid number or period, then check for length on right side of decimal, IF there is a decimal
        ElseIf InStr(ctrl.Text, ".") > 0 Then

            ' If the # of decimal places is already 2, and the cursor is on the right of said decimal place, and the keystroke is not a backspace
            If ctrl.Text.Split(".")(1).Length = 2 And ctrl.SelectionStart >= InStr(ctrl.Text, ".") And Asc(keyChar) <> 8 And Not ctrl.SelectionLength > 0 Then
                valid = False
                ' If the # of digits before decimal is already 3, the cursor is behind the decimal, and it's not a backspace
            ElseIf ctrl.Text.Split(".")(0).Length = 14 And ctrl.SelectionStart < InStr(ctrl.Text, ".") And Asc(keyChar) <> 8 And Not ctrl.SelectionLength > 0 Then
                valid = False
            End If

            ' If there is no decimal place
        ElseIf InStr(ctrl.Text, ".") = 0 Then

            ' If the length is 3 and it's not a backspace or a decimal place
            If ctrl.Text.Length = 14 And Asc(keyChar) <> 8 And Not keyChar = "." And Not ctrl.SelectionLength > 0 Then
                valid = False
            End If

        End If

        If keyChar.ToLower() = "o" Then
            keyChar = Chr(48)
        End If

        Return valid

    End Function


    ' Just a copy of currencyInputValid; both use same logic, but this is just to differentiate when they're used
    Public Function numericInputValid(ByVal ctrl As Object, ByRef keyChar As String, Optional ByVal intValue As Boolean = False) As Boolean

        Dim valid As Boolean = True

        Dim validChars As String
        If intValue Then
            validChars = "1234567890Oo"
        Else
            validChars = "1234567890Oo."
        End If

        ' First, ignore any input that isn't an number, period, or backspace
        If (InStr(validChars, keyChar) = 0 And Asc(keyChar) <> 8) Or (keyChar = "." And InStr(ctrl.Text, ".") > 0) Then
            valid = False
            ' If it's a valid number or period, then check for length on right side of decimal, IF there is a decimal
        ElseIf InStr(ctrl.Text, ".") > 0 Then

            ' If the # of decimal places is already 2, and the cursor is on the right of said decimal place, and the keystroke is not a backspace
            If ctrl.Text.Split(".")(1).Length = 2 And ctrl.SelectionStart >= InStr(ctrl.Text, ".") And Asc(keyChar) <> 8 And Not ctrl.SelectionLength > 0 Then
                valid = False
                ' If the # of digits before decimal is already 3, the cursor is behind the decimal, and it's not a backspace
            ElseIf ctrl.Text.Split(".")(0).Length = 14 And ctrl.SelectionStart < InStr(ctrl.Text, ".") And Asc(keyChar) <> 8 And Not ctrl.SelectionLength > 0 Then
                valid = False
            End If

            ' If there is no decimal place
        ElseIf InStr(ctrl.Text, ".") = 0 Then

            ' If the length is 3 and it's not a backspace or a decimal place
            If ctrl.Text.Length = 14 And Asc(keyChar) <> 8 And Not keyChar = "." And Not ctrl.SelectionLength > 0 Then
                valid = False
            End If

        End If

        If keyChar.ToLower() = "o" Then
            keyChar = Chr(48)
        End If

        Return valid

    End Function


    Public Function zipCodeInputValid(ByVal ctrl As Object, ByRef keyChar As String) As Boolean

        Dim valid As Boolean = True

        If (InStr("1234567890Oo-", keyChar) = 0 And Asc(keyChar) <> 8) Or (keyChar = "-" And InStr(ctrl.Text, "-") > 0) Then
            valid = False
        ElseIf ctrl.Text.Length = 5 And Asc(keyChar) <> 8 And Not ctrl.SelectionLength > 0 Then
            valid = False
        ElseIf keyChar.ToLower() = "o" Then
            keyChar = Chr(48)
            valid = True
        End If

        Return valid

    End Function



    ' **************** VALIDATION FOR SPECIFIC TYPES ****************


    ' Function used to validate phone numbers from masked text box. Thanks to the mask, only checks for not empty and length
    Public Function validPhone(ByVal label As String, ByVal required As Boolean, ByVal phoneValue As String, ByRef errorMessage As String) As Boolean

        If required Then
            ' If it is empty, return false, as this is not valid
            If isEmpty(label, required, phoneValue, errorMessage) Then Return False
        Else
            ' If it's not required, and it's empty, then don't append anything to the error message, and report that the value is valid (as it's blank and doesn't matter).
            If isEmpty(label, required, phoneValue, errorMessage) Then Return True
        End If

        If Not allValidChars(label, phoneValue, "1234567890", errorMessage) Then Return False

        If Not String.IsNullOrEmpty(phoneValue) And phoneValue.Length <> 10 Then
            errorMessage += "ERROR: " & label & " must be a valid 10-digit phone number" & vbNewLine
            Return False
        End If

        Return True

    End Function


    ' Function used to validate percent based values. Required controls whether or not the validation cares about null values (i.e. for use with optional controls, where you only validate IF they're not empty)
    Public Function validPercent(ByVal label As String, ByVal required As Boolean, ByVal percentValue As String, ByRef errorMessage As String) As Boolean

        If required Then
            ' If it is empty, return false, as this is not valid
            If isEmpty(label, required, percentValue, errorMessage) Then Return False
        Else
            ' If it's not required, and it's empty, then don't append anything to the error message, and report that the value is valid (as it's blank and doesn't matter).
            If isEmpty(label, required, percentValue, errorMessage) Then Return True
        End If

        ' Ensure all chars in percentValue are numbers or a decimal place
        If Not allValidChars(label, percentValue, "1234567890.", errorMessage) Then Return False

        ' Check to see if there are duplicate decimal places in percentValue
        Dim dcount As Integer = 0
        For Each c In percentValue.ToCharArray()
            If c = "." Then dcount += 1
            If dcount > 1 Then
                errorMessage += "ERROR: More than one decimal point in " & label & vbNewLine
                Return False
            End If
        Next


        ' Check to see if there is at least one decimal place
        If dcount = 1 Then

            ' If left side is greater than three in length, then it is too large
            If percentValue.Split(".")(0).Length > 3 Then
                errorMessage += "ERROR: Percent exceeds 100.00 in " & label & vbNewLine
                Return False
            End If

            ' If it is not greater than three (meaning that we can most likely PARSE it), ensure that the WHOLE number does not exceed 100.00
            If Convert.ToDecimal(percentValue) > 100 Then
                errorMessage += "ERROR: Percent exceeds 100.00 in " & label & vbNewLine
                Return False
            End If

            ' If number is not too large, then ensure that there are no more than 2 digits after it
            If percentValue.Split(".")(1).Length > 2 Then
                errorMessage += "ERROR: More than 2 digits after decimal place in " & label & vbNewLine
                Return False
            End If

        Else

            ' If number is greater than three in length, then it is too large
            If percentValue.Split(".")(0).Length > 3 Then
                errorMessage += "ERROR: Number too large for " & label & vbNewLine
                Return False
            End If

            ' If it is not greater than three (meaning that we can most likely PARSE it), ensure that the WHOLE number does not exceed 100.00
            If Convert.ToDecimal(percentValue) > 100 Then
                errorMessage += "ERROR: Percent exceeds 100.00 in " & label & vbNewLine
                Return False
            End If

        End If

        Return True

    End Function


    ' Function used to validate decimal based values. Very simlar to validPercent. IsEmpty() should be used outside of this function for optional controls
    Public Function validCurrency(ByVal label As String, ByVal required As Boolean, ByVal currencyValue As String, ByRef errorMessage As String) As Boolean

        If required Then
            ' If it is empty, return false, as this is not valid
            If isEmpty(label, required, currencyValue, errorMessage) Then Return False
        Else
            ' If it's not required, and it's empty, then don't append anything to the error message, and report that the value is valid (as it's blank and doesn't matter).
            If isEmpty(label, required, currencyValue, errorMessage) Then Return True
        End If

        ' Ensure all chars in currencyValue are numbers or a decimal place
        If Not allValidChars(label, currencyValue, "1234567890.", errorMessage) Then Return False

        ' Check to see if there are duplicate decimal places in currencyValue
        Dim dcount As Integer = 0
        For Each c In currencyValue.ToCharArray()
            If c = "." Then dcount += 1
            If dcount > 1 Then
                errorMessage += "ERROR: More than one decimal point in " & label & vbNewLine
                Return False
            End If
        Next

        ' If it contains (at most) one decimal place
        If dcount = 1 Then

            ' Check first that it's not only a decimal place
            If String.IsNullOrWhiteSpace(currencyValue.Split(".")(0)) And String.IsNullOrWhiteSpace(currencyValue.Split(".")(1)) Then
                errorMessage += "ERROR:  " & label & " cannot contain only a decimal place" & vbNewLine
                Return False
            End If

            ' If left side is greater than three in length, then it is too large
            If currencyValue.Split(".")(0).Length > 14 Then
                errorMessage += "ERROR: Amount too large in " & label & vbNewLine
                Return False
            End If

            ' If number is not too large, then ensure that there are no more than 4 points of precision
            If currencyValue.Split(".")(1).Length > 2 Then
                errorMessage += "ERROR: More than 2 digits after decimal place in " & label & vbNewLine
                Return False
            End If

        Else

            ' If number is greater than three in length, then it is too large
            If currencyValue.Split(".")(0).Length > 14 Then
                errorMessage += "ERROR: Amount too large in " & label & vbNewLine
                Return False
            End If

        End If

        Return True

    End Function


    ' Just a copy of validCurrency; both use same logic, but this is just to differentiate when they're used
    Public Function validNumber(ByVal label As String, ByVal required As Boolean, ByVal currencyValue As String, ByRef errorMessage As String,
                                Optional ByVal intValue As Boolean = False) As Boolean

        If required Then
            ' If it is empty, return false, as this is not valid
            If isEmpty(label, required, currencyValue, errorMessage) Then Return False
        Else
            ' If it's not required, and it's empty, then don't append anything to the error message, and report that the value is valid (as it's blank and doesn't matter).
            If isEmpty(label, required, currencyValue, errorMessage) Then Return True
        End If

        Dim validChars As String

        If intValue Then
            validChars = "1234567890"
        Else
            validChars = "1234567890."
        End If

        ' Ensure all chars in currencyValue are numbers or a decimal place
        If Not allValidChars(label, currencyValue, validChars, errorMessage) Then Return False

        ' Check to see if there are duplicate decimal places in currencyValue
        Dim dcount As Integer = 0
        For Each c In currencyValue.ToCharArray()
            If c = "." Then dcount += 1
            If dcount > 1 Then
                errorMessage += "ERROR: More than one decimal point in " & label & vbNewLine
                Return False
            End If
        Next

        ' If it contains (at most) one decimal place
        If dcount = 1 Then

            ' Check first that it's not only a decimal place
            If String.IsNullOrWhiteSpace(currencyValue.Split(".")(0)) And String.IsNullOrWhiteSpace(currencyValue.Split(".")(1)) Then
                errorMessage += "ERROR:  " & label & " cannot contain only a decimal place" & vbNewLine
                Return False
            End If

            ' If left side is greater than three in length, then it is too large
            If currencyValue.Split(".")(0).Length > 14 Then
                errorMessage += "ERROR: Amount too large in " & label & vbNewLine
                Return False
            End If

            ' If number is not too large, then ensure that there are no more than 4 points of precision
            If currencyValue.Split(".")(1).Length > 2 Then
                errorMessage += "ERROR: More than 2 digits after decimal place in " & label & vbNewLine
                Return False
            End If

        Else

            ' If number is greater than three in length, then it is too large
            If currencyValue.Split(".")(0).Length > 14 Then
                errorMessage += "ERROR: Amount too large in " & label & vbNewLine
                Return False
            End If

        End If

        Return True

    End Function


    ' ValidZipCode function. Returns boolean as to whether or not provided zip code is valid.
    ' This receives an errorMessage string that it will append custom erorr messages to with respect to what made the zip invalid
    Public Function validZipCode(ByVal zipCode As String, ByRef errorMessage As String) As Boolean

        Dim zipBase, zipExt As String

        'If zipCode.Length <> 5 And zipCode.Length <> 10 Then
        If zipCode.Length <> 5 And zipCode.Length <> 10 Then
            errorMessage += "ERROR: Must enter a valid ZIP Code before saving" & vbNewLine
            Return False
        End If

        If zipCode.Length = 5 Then
            If allValidChars("ZIP Code", zipCode, "1234567890", errorMessage) <> -1 Then                  ' Checks to see if any non-numeric characters in value
                'errorMessage += "ERROR: Invalid character in ZIP Code" & vbNewLine
                Return False
            End If
        End If

        'If zipCode.Length = 10 Then

        '    If zipCode.Substring(5, 1) <> "-" Then

        '        errorMessage += "ERROR: ZIP Code is not in proper format" & vbNewLine
        '        Return False

        '    Else

        '        zipBase = zipCode.Split("-")(0)
        '        zipExt = zipCode.Split("-")(1)

        '        If allValidChars(zipBase, "1234567890") <> -1 Or allValidChars(zipExt, "1234567890") <> -1 Then

        '            errorMessage += "ERROR: Invalid Character in ZIP Code" & vbNewLine
        '            Return False

        '        End If

        '    End If

        'End If

        Return True

    End Function


    ' Email validation function
    Public Function validEmail(ByVal label As String, ByVal required As Boolean, ByVal email As String, ByRef errorMessage As String) As Boolean

        If required Then
            If isEmpty(label, required, email, errorMessage) Then Return False
        Else
            If isEmpty(label, required, email, errorMessage) Then Return True
        End If

        If Not isValidLength(label, required, email, 50, errorMessage) Then Return False

        If InStr(email, "@") = 0 Then
            errorMessage += "ERROR: " & label & " must contain an @" & vbNewLine
            Return False
        End If

        Return True
        ' This is all of the validation for now. Might have to use a regular expression

    End Function


    ' DateTime validation function
    Public Function validDateTime(ByVal label As String, ByVal required As Boolean, ByVal dateTime As String, ByRef errorMessage As String) As Boolean

        ' First check if "Empty." Empty for datetime means that its value will be equivalent to its mask
        If required Then
            If dateTime.Replace(" ", "0") = "00/00/0000" Then
                errorMessage += "ERROR: Must enter a valid " & label & vbNewLine
                Return False
            End If
        Else
            If dateTime.Replace(" ", "0") = "00/00/0000" Then Return True
        End If

        ' Then, if not empty, then check if it's a valid date
        If Not IsDate(dateTime) Then
            errorMessage += "ERROR: " & dateTime & " is not a valid date" & vbNewLine
            Return False
        End If

        ' Otherwise, it must be valid
        Return True

    End Function



    ' **************** CORE VALIDATION ****************


    ' Function that determines if a given input value is within a given length
    ' Implements isEmpty, so this can be called for every text based input
    Public Function isValidLength(ByVal label As String, ByVal required As Boolean, ByVal value As String, ByVal maxLength As Integer, ByRef errorMessage As String) As Boolean

        If required Then
            If isEmpty(label, required, value, errorMessage) Then Return False
        Else
            If isEmpty(label, required, value, errorMessage) Then Return True
        End If

        If value.Length > maxLength Then
            errorMessage += "ERROR: " & label & " cannot be longer than " & maxLength & " characters" & vbNewLine
            Return False
        End If

        Return True

    End Function


    ' Function that determines if a value/input is empty.
    Public Function isEmpty(ByVal Label As String, ByVal required As Boolean, ByVal value As String, ByRef errorMessage As String) As Boolean

        If String.IsNullOrWhiteSpace(value) Then

            If required Then
                errorMessage += "ERROR: Must enter a valid " & Label & " before saving" & vbNewLine
            End If

            Return True

        End If

        Return False

    End Function


    ' Function that checks to se if a value does exist to prevent a duplicate. Accepts sorted list of values
    Public Function isDuplicate(ByVal label As String, ByVal newValue As String, ByRef errorMessage As String, ByVal existingValues As List(Of Object)) As Boolean

        If existingValues.BinarySearch(newValue) >= 0 Then
            errorMessage += "ERROR: " & newValue & " already exists" & vbNewLine
            Return True
        End If

        Return False

    End Function

    ' Overload that checks for duplicate items/rows using DataTable instead of sorted listed
    Public Function isDuplicate(ByVal label As String, ByRef errorMessage As String, ByVal valueColumn As String, ByVal value As Object, ByVal dataTable As DataTable) As Boolean

        Dim escapedValue As String = escapeLikeValues(value)

        Dim duplicateRows() As DataRow = dataTable.Select(valueColumn & " LIKE '" & escapedValue & "'")

        If duplicateRows.Count <> 0 Then
            errorMessage += "ERROR: " & value & " already exists" & vbNewLine
            Return True
        End If

        Return False

    End Function


    '' Overload that checks for duplicate rows on the basis of multiple columns/values
    'Public Function isDuplicate(ByVal label As String, ByRef errorMessage As String, ByVal columnsAndValues As Dictionary(Of String, Object), ByVal dataTable As DataTable) As Boolean

    '    Dim query As String = String.Empty
    '    For i As Integer = 0 To columnsAndValues.Count - 1
    '        If i <> 0 Then query += " AND "
    '        query += columnsAndValues(i).Key & " LIKE '" & columnsAndValues(i).Value & "'"
    '    Next
    '    If String.IsNullOrEmpty(query) Then Return False

    '    Dim duplicateRows() As DataRow = dataTable.Select(query)

    '    If duplicateRows.Count <> 0 Then
    '        errorMessage += "ERROR: " & label & " already exists" & vbNewLine
    '        Return True
    '    End If

    '    Return False

    'End Function


    ' Function that checks to see if a value DOES exist. Accepts sorted list of values
    Public Function valueExists(ByVal label As String, ByVal value As String, ByRef errorMessage As String, ByVal existingValues As List(Of Object)) As Boolean

        If existingValues.BinarySearch(value) < 0 Then
            errorMessage += "ERROR: " & value & " does not exist" & vbNewLine
            Return False
        End If

        Return True

    End Function

    ' OVERLOAD: uses datatable instead of sorted list
    Public Function valueExists(ByVal label As String, ByRef errorMessage As String, ByVal valueColumn As String, ByVal value As Object, ByVal dataTable As DataTable) As Boolean

        Dim escapedValue As String = escapeLikeValues(value)

        Dim dataRows() As DataRow = dataTable.Select(valueColumn & " LIKE '" & escapedValue & "'")

        If dataRows.Count = 0 Then
            errorMessage += "ERROR: " & label & " " & value & " does not exist" & vbNewLine
            Return False
        End If

        Return True

    End Function

    ' OVERLOAD: does not receive errorMessage
    Public Function valueExists(ByVal valueColumn As String, ByVal value As Object, ByVal dataTable As DataTable) As Boolean

        Dim escapedValue As String = escapeLikeValues(value)

        Dim dataRows() As DataRow = dataTable.Select(valueColumn & " LIKE '" & escapedValue & "'")

        If dataRows.Count = 0 Then
            Return False
        End If

        Return True

    End Function


    ' Function that determines if there are any invalid chars in a given value. The valid chars are provided as a string.
    ' Will return -1 if no invalid chars were found
    ' Will return the index of the first invalid char it encounters
    Public Function allValidChars(ByVal label As String, ByVal value As String, ByVal validChars As String, ByRef errorMessage As String) As Integer

        Dim lastValidIndex As Integer = -1
        Dim chars() As Char = value.ToCharArray()

        For i As Integer = 0 To value.ToCharArray().Count - 1
            If InStr(validChars, chars(i).ToString()) = 0 Then
                lastValidIndex = i
                errorMessage += "ERROR: Invalid character in " & label & vbNewLine
                Return lastValidIndex
            End If
        Next

        Return lastValidIndex

    End Function

    ' Overload that doesn't handle error message
    Public Function allValidChars(ByVal value As String, ByVal validChars As String) As Integer

        Dim lastValidIndex As Integer = -1
        Dim chars() As Char = value.ToCharArray()

        For i As Integer = 0 To value.ToCharArray().Count - 1
            If InStr(validChars, chars(i).ToString()) = 0 Then
                lastValidIndex = i
                Return lastValidIndex
            End If
        Next

        Return lastValidIndex

    End Function


    ' Funcion that checks if given number is a valid number
    Public Function isValidNumber(ByVal label As String, ByVal value As Decimal, ByVal min As Decimal,
                                  ByVal includeMin As Boolean, ByVal max As Decimal, ByVal includeMax As Boolean,
                                  ByRef errorMessage As String) As Boolean

        ' Innocent until proven guilty
        Dim isValid As Boolean = True

        ' Provide unique error messages respective to their error below

        If value = -99999 Then
            errorMessage += label & " invalid - number entered is out of bounds" & vbNewLine
        Else

            If includeMin Then
                If value < min Then
                    errorMessage += label & " invalid - number must be at least " & min.ToString() & vbNewLine
                    isValid = False
                End If
            Else
                If value <= min Then
                    errorMessage += label & " invalid - number must be greater than " & min.ToString() & vbNewLine
                    isValid = False
                End If
            End If

            If max <> 99999 Then

                If includeMax Then
                    If value > max Then
                        errorMessage += label & " invalid - number cannot be greater than " & max.ToString() & vbNewLine
                        isValid = False
                    End If
                Else
                    If value >= max Then
                        errorMessage += label & " invalid - number must be less than " & max.ToString() & vbNewLine
                        isValid = False
                    End If
                End If

            End If

        End If

        Return isValid

    End Function




    ' ****************** FORM CONTROL ******************


    ' Public variable to keep track of the last screen in case a form needs to navigate back to it
    Public previousScreen As Form = Nothing


    ' Function that handles switching screens
    Public Sub changeScreen(ByRef newScreen As Form, ByRef currentScreen As Form)

        Try

            newScreen.Location = New Point(currentScreen.Location.X, currentScreen.Location.Y)

        Catch ex As Exception

        End Try

        newScreen.Show()

        If currentScreen IsNot Nothing Then

            currentScreen.Close()

        End If

    End Sub


    ' Function that handles switching screens, but only hides the previous
    Public Sub changeScreenHide(ByRef newScreen As Form, ByRef currentScreen As Form)

        Try

            newScreen.Location = New Point(currentScreen.Location.X, currentScreen.Location.Y)

        Catch ex As Exception

        End Try

        newScreen.Show()

        If currentScreen IsNot Nothing Then

            currentScreen.Hide()

        End If

    End Sub




    ' ****************** FILE IO / DATABASE BACKUP ******************


    ' Sub that gets data from INI files. Data is retrieved by looking for a line in the INI that contains the provided key,
    ' and then reading in the data that follows until the EndOn string is reached
    Public Function readINI(ByVal iniFileName As String, ByVal key As String, Optional ByVal EndOn As String = "") As String

        Dim line As String = String.Empty
        Dim value As String = String.Empty
        Dim valueStartIndex As Integer
        Dim valueEndIndex As Integer
        Dim INIFile As New System.IO.StreamReader(Application.StartupPath & "\" & iniFileName)

        ' Do loop in case connection string is eventually moved to a different row in the ini configuration file
        Do Until INIFile.EndOfStream
            line = INIFile.ReadLine()
            If line.IndexOf(key) <> -1 Then
                Exit Do
            End If
        Loop

        If Not String.IsNullOrEmpty(line) Then

            ' Get everything after key and store it in value
            valueStartIndex = line.IndexOf(key) + key.Length
            value = line.Substring(valueStartIndex, (line.Length - key.Length))

            If EndOn <> String.Empty Then

                ' Then, get everything after key UP TO the EndOn String
                valueEndIndex = value.IndexOf(EndOn)
                ' As long as the End value is in the value, then set the , set value
                If valueEndIndex <> -1 Then value = line.Substring(0, valueEndIndex)

            End If


        End If

        Return value

    End Function


    ' Sub that creates a backup of the database on close/logout.
    Public Sub backupDb()

        Dim success As Boolean = True

        Dim FileToCopy As String
        Dim FileName As String
        Dim BackupDirectory As String
        Dim NewDate As String
        Dim NewCopy As String = String.Empty

        Try

            FileToCopy = readINI("DatabaseBackupParams.ini", "PRIMARY-DATABASE-FILEPATH=")
            BackupDirectory = readINI("DatabaseBackupParams.ini", "BACKUP-DIRECTORY=")

            ' First, ensure that there was a valid entry in the INI
            If FileToCopy <> String.Empty Then
                ' Then, check to see if the path returned was a file that actually exists
                If System.IO.File.Exists(FileToCopy) And System.IO.Directory.Exists(BackupDirectory) Then

                    FileName = System.IO.Path.GetFileNameWithoutExtension(FileToCopy)
                    NewDate = DateTime.Now.ToString("yyyy-MM-dd")
                    NewCopy = BackupDirectory & FileName & "_" & NewDate & ".mdb"

                    ' Then, check to see if NewCopy file already exists. If so, delete existing and make new copy
                    ' If not, then just create a new copy
                    If System.IO.File.Exists(NewCopy) Then
                        System.IO.File.Delete(NewCopy)
                        System.IO.File.Copy(FileToCopy, NewCopy)
                    Else
                        System.IO.File.Copy(FileToCopy, NewCopy)
                    End If

                Else success = False
                End If

            Else success = False
            End If

        Catch ex As Exception

            success = False

        End Try

        If success Then
            MessageBox.Show("Database backup created successfully at " & vbNewLine & NewCopy)
            pruneBackups()
        Else
            MessageBox.Show("Database backup unsuccessful." & vbNewLine & "Please ensure that the filepath to the primary database is correct and that the backup directory is a valid path", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub


    Public Sub pruneBackups()

        Dim BackupDirectory As String = readINI("DatabaseBackupParams.ini", "BACKUP-DIRECTORY=")
        If Not System.IO.Directory.Exists(BackupDirectory) Then Exit Sub

        Dim files() As String = IO.Directory.GetFiles(BackupDirectory)

        ' Variables used for parsing
        Dim fileName As String = String.Empty
        Dim fileDate As String = String.Empty
        Dim pattern As String = "????-??-??"
        Dim fileSubstr As String

        For Each file In files
            ' parse date here using _
            fileName = IO.Path.GetFileName(file)


            ' 1.) GET DATE FROM FILENAME

            ' For as many positions in fileName that pattern can fit in,
            ' check to see if substring (from i to pattern.length) matches the Date pattern.
            ' If it's a match, then this is the date we're looking for

            For i As Integer = 0 To fileName.Length - pattern.Length

                fileSubstr = fileName.Substring(i, pattern.Length)
                If fileSubstr Like pattern Then
                    fileDate = fileSubstr
                    Exit For
                End If

            Next

            ' If a date was found in the file, then find the year from that date in the same fashion
            ' (really, this could be extremely simplified by just 
            If fileDate <> String.Empty Then

                Dim year As String = String.Empty
                Dim yearPattern As String = "????"
                Dim dateSubstr As String

                For i As Integer = 0 To fileDate.Length - yearPattern.Length

                    dateSubstr = fileDate.Substring(i, yearPattern.Length)
                    If dateSubstr Like yearPattern Then
                        year = dateSubstr
                        Exit For
                    End If

                Next

                ' Once we have a valid year, then we can move on

                ' If (fildDate) LIKE ????-01-01 Then, delete all others except


            Else
                ' If fileDate not found in file, this file will be skipped in pruning
                Continue For
            End If




            ' reset fileDate
            fileDate = String.Empty

        Next


    End Sub


End Module
