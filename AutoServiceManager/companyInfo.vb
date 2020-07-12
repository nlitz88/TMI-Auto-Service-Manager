Public Class companyInfo

    'Temporary variable to keep track of whether form fully loaded or not
    Dim valuesInitialized As Boolean = False

    ' Dictionary to maintain initial dataLabel/dataField values to compare against when changes are made
    Dim initialDataValues As Dictionary(Of String, String)

    ' Datatable for dataAdapter to load data into. This really should be moved to a class
    Dim CompanyMasterDataTable As DataTable
    ' Another Connection variable. Describes whether or not connection attempt throws exception
    Dim connHasException As Boolean


    ' Sub to load load initial data from database
    Private Sub loadInitialData()

        ' ******** CONNECTION PARAMETERS ********
        Dim accessConn As New OleDb.OleDbConnection

        ' Variables to build (and paramaterize) our connection string
        Dim dbProvider As String            ' The data provider (that includes the data adapter) that we want the connection to use to interface with the access database (in this case, Jet 4.0 for mdb files)
        Dim dbSource As String              ' The location of the actual access database file (will contain the complete composited location that we build with the following variables)
        Dim DatabaseDirectory As String     ' The working directory where the database is currently setup/stored
        Dim TheDatabaseFilename As String   ' The address of only the database
        Dim FullDatabasePath As String      ' Full path built from DatabaseDirectory and DatabaseFilename. Will be used in combination with another parameter to set dbSource Variable

        ' Local variables that should be *PULLED FROM AN INI FILE* for deployment
        DatabaseDirectory = "C:\Users\nlitz\Development\TMI Consulting\Auto Service Manager\AutoServiceManager\AutoServiceManager\Database"  ' Change from PC to PC until I make INI
        TheDatabaseFilename = "TMI-ServiceMgr.mdb"
        FullDatabasePath = DatabaseDirectory & "\" & TheDatabaseFilename
        dbSource = "Data Source = " & FullDatabasePath      ' Finally, define the dbSource by combinding everywith the appropriate parameter "Data Source"
        dbProvider = "PROVIDER=Microsoft.Jet.OLEDB.4.0;"     ' Utilizing the Jet OLEDB data provider, as we are using an older access database .mdb (2003)
        ' Then, add the completed/built connectionstring to the access connection
        accessConn.ConnectionString = dbProvider & dbSource


        ' ******** DEFINE COMMAND ********
        Dim SQLQuery As String
        Dim accessCmd As OleDb.OleDbCommand     ' Define command (containing conn and query) the dataAdapter will use to fill our dataTable


        ' ******** DEFINE DATAADAPTER AND DATATABLE ********
        'Dim CompanyMasterDataTable As DataTable              ' Define dataTable that dataAdapter will fill (into internal dataset?)
        Dim accessAdapter As OleDb.OleDbDataAdapter     ' Define OleDB dataAdapter that will interface with the access database
        ' Somewhere to automate adding parameters for more advanced queries?


        ' ******** TRY TO OPEN CONNECTION ********
        Try

            ' Attemp connection
            accessConn.Open()

            ' Initialize command
            SQLQuery = "SELECT cm.TaxRate, cm.ShopSupplyCharge, cm.CompanyName1, cm.CompanyName2, cm.Address1, cm.Address2, cm.ZipCode, cm.Phone1, cm.Phone2, cm.LaborRate, zc.city, zc.State FROM CompanyMaster cm left outer join ZipCodes zc on cm.ZipCode = zc.Zipcode"
            accessCmd = New OleDb.OleDbCommand
            accessCmd.Connection = accessConn
            accessCmd.CommandText = SQLQuery

            ' Initialize dataTable and dataAdapter that will fill it
            CompanyMasterDataTable = New DataTable
            accessAdapter = New OleDb.OleDbDataAdapter(accessCmd)       ' Initialize dataAdapter for access database that will use the accessCmd (containing the connection and query we provided)

            ' Use the acesssAdapter to fill the dataTable
            accessAdapter.Fill(CompanyMasterDataTable)

            connHasException = False

            MessageBox.Show("Successful connection to " & TheDatabaseFilename)

        Catch ex As Exception

            MessageBox.Show("An erorr has occurred: " & vbNewLine & vbNewLine & ex.Message.ToString(), "Exception Thrown", MessageBoxButtons.OK, MessageBoxIcon.Error)
            connHasException = True

        Finally

            If accessConn.State = ConnectionState.Open Then accessConn.Close()

        End Try


    End Sub


    Private Sub initializeValues() ' Consider renaming to "initializeDataFields/Values", as other functions might handle setting other values

        If Not connHasException Then ' MOVE THIS ABOVE TO TOP OF FUNCTION

            valuesInitialized = False

            initialDataValues = New Dictionary(Of String, String)

            ' ArrayLists that initializeValues will use to map data from dataTable to these items
            ' CAUTION: THESE MUST BE DEFINED IN ORDER KNOWN FROM DATABASE
            ' CAUTION: THESE MUST BE DEFINED AFTER THEY'VE BEEN INITIALIZED IN THE FORM
            ' ********* IF EXCESSIVE/NEEDLESSLY COMPLEX, MOVE TO EXPLICIT DEFINITION IN INITIALIZEVALUES INSTEAD ************
            Dim dataLabelList As New List(Of Object) From {taxRateValue, shopSupplyChargeValue, companyNameValue, companyName2Value, addressLine1Value, addressLine2Value, zipCodeValue, phone1Value, phone2Value, laborRateValue, cityValue, stateValue}
            Dim dataFieldList As New List(Of Object) From {taxRateTextbox, shopSupplyChargeTextbox, companyNameTextbox, companyName2Textbox, addressLine1Textbox, addressLine2Textbox, zipCodeTextbox, phone1Textbox, phone2Textbox, laborRateTextbox, cityTextbox, stateTextbox}

            Dim dataValue As Object

            For i As Integer = 0 To CompanyMasterDataTable.Columns.Count - 1

                ' First, get the actual data from the table and see if it exists
                dataValue = CompanyMasterDataTable.Rows(0)(CompanyMasterDataTable.Columns(i))

                ' Then, set any DBNull dataValues to their default values (this way we don't try to use DBNull Values)
                setNullToDefault(dataValue, CompanyMasterDataTable.Columns(i).DataType.ToString())

                ' If not DBNull, then assign the value to the respective form item
                setControlValue(dataLabelList(i), dataValue)
                setControlValue(dataFieldList(i), dataValue)
                'dataLabelList(i).Text = dataValue
                'dataFieldList(i).Text = dataValue

                ' After this completed, record the initialValues of the 
                initialDataValues.Add(dataFieldList(i).Name, dataFieldList(i).Text)

            Next

            ' For now, these will be here until CITY and STATE are joined on the ZIP CODE
            'initialDataValues.Add(stateTextbox.Name, stateTextbox.Text)
            'initialDataValues.Add(cityTextbox.Name, cityTextbox.Text)

            valuesInitialized = True


            ' Debug
            Console.WriteLine("InitializingValues complete")

        End If

    End Sub

    Private Sub companyInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Dynamically position elements on load.
        companyInfoLabel.Left = (Me.ClientSize.Width / 2) - (companyInfoLabel.Width / 2)

        loadInitialData()
        initializeValues()

    End Sub

    Private Sub editButton_Click(sender As Object, e As EventArgs) Handles editButton.Click

        ' Enable cancelButton and disable editButton
        cancelButton.Enabled = True
        editButton.Enabled = False
        'navigationPlaceholderButton.Enabled = False

        ' Disable all navigation controls while editing
        showHide(getAllItemsWithTag("navigation"), 0)
        ' disable/enable the dataLabels and dataFields, respectively
        showHide(getAllItemsWithTag("dataLabel"), 0)
        showHide(getAllItemsWithTag("dataField"), 1)

    End Sub

    Private Sub cancelButton_Click(sender As Object, e As EventArgs) Handles cancelButton.Click

        ' Ensure that any changes made are saved
        If changesMadeToText(getAllItemsWithTag("dataField"), initialDataValues) Then

            Dim decision As DialogResult = MessageBox.Show("Cancel without saving changes?", "Confirm", MessageBoxButtons.YesNo)

            Select Case decision
                Case DialogResult.Yes

                    ' ReInitializeData
                    initializeValues()

                    ' Disable all editing controls
                    cancelButton.Enabled = False
                    saveButton.Enabled = False
                    ' re-enable other hidden form controls
                    editButton.Enabled = True
                    ' re-enable navigation controls
                    showHide(getAllItemsWithTag("navigation"), 1)
                    ' enable/disable the dataLabels and dataFields, respectively
                    showHide(getAllItemsWithTag("dataLabel"), 1)
                    showHide(getAllItemsWithTag("dataField"), 0)

                Case DialogResult.No

            End Select

        Else

            ' Disable all editing controls
            cancelButton.Enabled = False
            saveButton.Enabled = False
            ' re-enable other hidden form controls
            editButton.Enabled = True
            ' re-enable navigation controls
            showHide(getAllItemsWithTag("navigation"), 1)
            ' enable/disable the dataLabels and dataFields, respectively
            showHide(getAllItemsWithTag("dataLabel"), 1)
            showHide(getAllItemsWithTag("dataField"), 0)

        End If

    End Sub

    Private Sub saveButton_Click(sender As Object, e As EventArgs) Handles saveButton.Click

        Dim decision As DialogResult = MessageBox.Show("Save Changes?", "Confirm Changes", MessageBoxButtons.YesNo)

        Select Case decision
            Case DialogResult.Yes

                ' 1.) Write changes to database
                ' 2.) Switch back to labels with updated data from database (reload the form essentially)
                ' 3.) Go back to showing edit button and navigation controls

                ' Disable all editing controls
                cancelButton.Enabled = False
                saveButton.Enabled = False
                ' re-enable other hidden form controls
                editButton.Enabled = True
                ' re-enable navigation controls
                showHide(getAllItemsWithTag("navigation"), 1)

                ' show updated dataLabels and hide dataFields
                showHide(getAllItemsWithTag("dataLabel"), 1)
                showHide(getAllItemsWithTag("dataField"), 0)



            Case DialogResult.No
                ' Continue making changes or cancel editing

        End Select

    End Sub


    ' ************************ DATAFIELD TEXTBOX SUBS ************************


    Private Sub companyNameTextbox_TextChanged(sender As Object, e As EventArgs) Handles companyNameTextbox.TextChanged

        ' For now, just check to see if the entire form has been loaded before checking for text changes
        ' In the future (when database implemented, maybe this should change to until the database has been connected to and data has been loaded?
        ' Worker thread or something of the like?
        ' This applies for this Textbox sub and all dataField tagged Textboxes that follow
        If valuesInitialized Then
            If changesMadeToText(getAllItemsWithTag("dataField"), initialDataValues) Then
                saveButton.Enabled = True
            Else
                saveButton.Enabled = False
            End If
        End If

    End Sub

    Private Sub companyName2Textbox_TextChanged(sender As Object, e As EventArgs) Handles companyName2Textbox.TextChanged

        If valuesInitialized Then
            If changesMadeToText(getAllItemsWithTag("dataField"), initialDataValues) Then
                saveButton.Enabled = True
            Else
                saveButton.Enabled = False
            End If
        End If

    End Sub

    Private Sub addressLine1Textbox_TextChanged(sender As Object, e As EventArgs) Handles addressLine1Textbox.TextChanged

        If valuesInitialized Then
            If changesMadeToText(getAllItemsWithTag("dataField"), initialDataValues) Then
                saveButton.Enabled = True
            Else
                saveButton.Enabled = False
            End If
        End If

    End Sub

    Private Sub addressLine2Textbox_TextChanged(sender As Object, e As EventArgs) Handles addressLine2Textbox.TextChanged

        If valuesInitialized Then
            If changesMadeToText(getAllItemsWithTag("dataField"), initialDataValues) Then
                saveButton.Enabled = True
            Else
                saveButton.Enabled = False
            End If
        End If

    End Sub

    Private Sub zipCodeTextbox_TextChanged(sender As Object, e As EventArgs) Handles zipCodeTextbox.TextChanged

        If valuesInitialized Then
            If changesMadeToText(getAllItemsWithTag("dataField"), initialDataValues) Then
                saveButton.Enabled = True
            Else
                saveButton.Enabled = False
            End If
        End If

    End Sub

    Private Sub cityTextbox_TextChanged(sender As Object, e As EventArgs) Handles cityTextbox.TextChanged

        If valuesInitialized Then
            If changesMadeToText(getAllItemsWithTag("dataField"), initialDataValues) Then
                saveButton.Enabled = True
            Else
                saveButton.Enabled = False
            End If
        End If

    End Sub

    Private Sub stateTextbox_TextChanged(sender As Object, e As EventArgs) Handles stateTextbox.TextChanged

        If valuesInitialized Then
            If changesMadeToText(getAllItemsWithTag("dataField"), initialDataValues) Then
                saveButton.Enabled = True
            Else
                saveButton.Enabled = False
            End If
        End If

    End Sub

    Private Sub phone1Textbox_TextChanged(sender As Object, e As EventArgs) Handles phone1Textbox.TextChanged

        If valuesInitialized Then
            If changesMadeToText(getAllItemsWithTag("dataField"), initialDataValues) Then
                saveButton.Enabled = True
            Else
                saveButton.Enabled = False
            End If
        End If

    End Sub

    Private Sub phone2Textbox_TextChanged(sender As Object, e As EventArgs) Handles phone2Textbox.TextChanged

        If valuesInitialized Then
            If changesMadeToText(getAllItemsWithTag("dataField"), initialDataValues) Then
                saveButton.Enabled = True
            Else
                saveButton.Enabled = False
            End If
        End If

    End Sub

    Private Sub taxRateTextbox_TextChanged(sender As Object, e As EventArgs) Handles taxRateTextbox.TextChanged

        If valuesInitialized Then
            If changesMadeToText(getAllItemsWithTag("dataField"), initialDataValues) Then
                saveButton.Enabled = True
            Else
                saveButton.Enabled = False
            End If
        End If

    End Sub

    Private Sub shopSupplyChargeTextbox_TextChanged(sender As Object, e As EventArgs) Handles shopSupplyChargeTextbox.TextChanged

        If valuesInitialized Then
            If changesMadeToText(getAllItemsWithTag("dataField"), initialDataValues) Then
                saveButton.Enabled = True
            Else
                saveButton.Enabled = False
            End If
        End If

    End Sub

    Private Sub laborRateTextbox_TextChanged(sender As Object, e As EventArgs) Handles laborRateTextbox.TextChanged

        If valuesInitialized Then
            If changesMadeToText(getAllItemsWithTag("dataField"), initialDataValues) Then
                saveButton.Enabled = True
            Else
                saveButton.Enabled = False
            End If
        End If

    End Sub

    Private Sub navigationPlaceholderButton_Click(sender As Object, e As EventArgs) Handles navigationPlaceholderButton.Click
        Me.Close()
    End Sub

End Class