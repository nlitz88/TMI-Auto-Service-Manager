Module globals




    ' ************************ CONTROL MANIPULATION ************************


    ' Used to return all items of a certain group (items that have the same identifying tag) as an iterable ArrayList.
    Public Function getAllControlsWithTag(ByVal tag As String) As List(Of Object)

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
                control.SelectedValue = value       ' If this becomes a problem later, revert to just setting the text of the combobox
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


    Public Function getListFromDataTable(ByVal datatable As DataTable, ByVal column As String, Optional ByVal sorted As Boolean = True) As List(Of Object)

        Dim values As New List(Of Object)

        For Each row In datatable.Rows
            values.Add(row(column))
        Next

        If sorted Then values.Sort()

        Return values

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


    ' **************** CORE VALIDATION ****************


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


End Module
