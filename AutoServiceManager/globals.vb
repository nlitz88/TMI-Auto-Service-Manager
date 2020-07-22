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

    Public Function percentInputValid(ByVal ctrl As Object, ByVal keyChar As String) As Boolean

        Dim valid As Boolean = True

        ' First, ignore any input that isn't an number, period, or backspace
        If (InStr("1234567890.", keyChar) = 0 And Asc(keyChar) <> 8) Or (keyChar = "." And InStr(ctrl.Text, ".") > 0) Then
            valid = False
            Console.WriteLine("Invalid character")
            ' If it's a valid number or period, then check for length on right side of decimal, IF there is a decimal
        ElseIf InStr(ctrl.Text, ".") > 0 Then

            ' If the # of decimal places is already 2, and the cursor is on the right of said decimal place, and the keystroke is not a backspace
            If ctrl.Text.Split(".")(1).Length = 2 And ctrl.SelectionStart >= InStr(ctrl.Text, ".") And Asc(keyChar) <> 8 Then
                valid = False
            End If

        End If

        Return valid

    End Function




    ' **************** VALIDATION FOR SPECIFIC TYPES ****************


    Public Function validPercent() As Boolean

        ' Use isNumeric and other CORE validation functions to validate the percentage based textboxes

    End Function


    ' ValidZipCode function. Returns boolean as to whether or not provided zip code is valid.
    ' This receives an errorMessage string that it will append custom erorr messages to with respect to what made the zip invalid
    Public Function validZipCode(ByVal zipCode As String, ByRef errorMessage As String) As Boolean

        Dim zipBase, zipExt As String

        If zipCode.Length <> 5 And zipCode.Length <> 10 Then
            errorMessage += "Must enter a valid ZIP Code before saving" & vbNewLine
            Return False
        End If

        If zipCode.Length = 5 Then
            If allValidChars(zipCode, "1234567890") <> -1 Then                  ' Checks to see if any non-numeric characters in value
                errorMessage += "Invalid character in ZIP Code" & vbNewLine
                Return False
            End If
        End If

        If zipCode.Length = 10 Then

            If zipCode.Substring(5, 1) <> "-" Then

                errorMessage += "ZIP Code is not in proper format" & vbNewLine
                Return False

            Else

                zipBase = zipCode.Split("-")(0)
                zipExt = zipCode.Split("-")(1)

                If allValidChars(zipBase, "1234567890") <> -1 Or allValidChars(zipExt, "1234567890") <> -1 Then

                    Console.WriteLine(zipBase & " | " & zipExt)
                    errorMessage += "Invalid Character in ZIP Code" & vbNewLine
                    Return False

                End If

            End If

        End If

        Return True

    End Function


    ' **************** CORE VALIDATION ****************


    ' Function that determines if there are any invalid chars in a given value. The valid chars are provided as a string.
    ' Will return -1 if no invalid chars were found
    ' Will return the index of the first invalid char it encounters
    Public Function allValidChars(ByVal value As String, ByVal validChars As String) As Integer

        Dim lastValidIndex As Integer = -1
        Dim chars() As Char = value.ToCharArray()

        For i As Integer = 0 To value.ToCharArray().Count - 1
            If InStr(validChars, chars(i).ToString()) = 0 Then
                lastValidIndex = i
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
