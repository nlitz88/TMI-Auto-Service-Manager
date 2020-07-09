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

            If item.Text <> initialValues(item.Name) Then
                result = True
                Console.WriteLine("Changes Made")
            End If

        Next

        Return result

    End Function


End Module
