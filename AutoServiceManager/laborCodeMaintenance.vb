Imports System.ComponentModel

Public Class laborCodeMaintenance

    ' New Database control instances for insurance companies datatable
    Private LCDbController As New DbControl()
    ' New Database control instance for updating, inserting, and deleting
    Private CRUD As New DbControl()

    ' Initialize new lists to store certain row values of datatables (easily sorted and BINARY SEARCHED FOR SPEED)
    Private LCList As List(Of Object)

    ' Initialize instance(s) of initialValues class
    Private InitialLCValues As New InitialValues()

    'Variable to keep track of whether form fully loaded or not
    Private valuesInitialized As Boolean = True

    ' Row index variables used for DataTable lookups
    Private LCRow As Integer
    Private lastSelected As String

    ' Keeps track of whether or not user in "editing" or "adding" mode
    Private mode As String

    ' Variable that allows certain keystrokes through restricted fields
    Private allowedKeystroke As Boolean = False



    ' ***************** INITIALIZATION AND CONFIGURATION SUBS *****************


    ' Sub that will contain calls to all of the instances of the database controller class that loads data from the database into DataTables
    Private Function loadDataTablesFromDatabase() As Boolean

        LCDbController.ExecQuery("SELECT lc.Description + ' - ' + lc.LaborCode as LDLC, lc.LaborCode, lc.Description, lc.Rate, lc.Hours, lc.Amount FROM LaborCodes lc ORDER BY lc.Description ASC")
        If LCDbController.HasException() Then Return False

        ' Also, populate respective lists with data
        LCList = getListFromDataTable(LCDbController.DbDataTable, "LaborCode")
        For i As Integer = 0 To LCList.Count - 1
            LCList(i) = LCList(i).ToString().ToLower()
        Next

        Return True

    End Function


    ' Sub that initializes all dataEditingcontrols corresponding with values from the Parts datatable
    Private Sub InitializeLCDataEditingControls()

        initializeControlsFromRow(LCDbController.DbDataTable, LCRow, "dataEditingControl", "_", Me)

    End Sub

    ' Sub that initializes all dataViewingControls corresponding with values from the Parts datatable
    Private Sub InitializeLCDataViewingControls()


        initializeControlsFromRow(LCDbController.DbDataTable, LCRow, "dataViewingControl", "_", Me)

    End Sub


    ' Sub that calls all individual dataEditingControl initialization subs in one (These can be used individually if desired)
    Private Sub InitializeAllDataEditingControls()

        ' Automated initializations
        InitializeLCDataEditingControls()
        ' Then, format dataEditingControls
        formatDataEditingControls()
        ' Set forecolor if not already initially default
        setForeColor(getAllControlsWithTag("dataEditingControl", Me), DefaultForeColor)

    End Sub

    ' Sub that calls all individual dataEditingControl initialization subs in one (These can be used individually if desired)
    Private Sub InitializeAllDataViewingControls()

        ' Automated initializations
        InitializeLCDataViewingControls()
        ' Format dataviewingcontrols
        formatDataViewingControls()

    End Sub


    ' Sub that will call formatting functions to add respective formats to already INITIALIZED DATAVIEWINGCONTROLS (i.e. phone numbers, currency, etc.).
    Private Sub formatDataViewingControls()

        'PartPrice_Value.Text = FormatCurrency(LCDbController.DbDataTable.Rows(LCRow)("PartPrice"))
        'ListPrice_Value.Text = FormatCurrency(LCDbController.DbDataTable.Rows(LCRow)("ListPrice"))

    End Sub

    ' Sub that will call formatting functions to add respective formats to already INITIALIZED DATAEDITINGCONTROLS (i.e. phone numbers, currency, etc.).
    Private Sub formatDataEditingControls()

        'PartPrice_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(LCDbController.DbDataTable.Rows(LCRow)("PartPrice")))
        'ListPrice_Textbox.Text = String.Format("{0:0.00}", Convert.ToDecimal(LCDbController.DbDataTable.Rows(LCRow)("ListPrice")))

    End Sub

    ' Sub that will remove all necessary formatting taht was added (used before updating values)
    Private Sub stripDataEditingControlsFormatting()

    End Sub


    ' Function that makes updateTable calls for all relevant DataTables that need updated based on changes
    Private Function updateAll() As Boolean

        ' First, remove any formatting that was added (specific to the controls on this form)
        ' stripDataEditingControlsFormatting()

        ' Then, update all relevant tables that COUDLD have experienced changes
        Dim initialValueAsKey As String = LCDbController.DbDataTable.Rows(LCRow)("LaborCode")
        updateTable(CRUD, LCDbController.DbDataTable, "Parts", initialValueAsKey, "LaborCode", "_", "dataEditingControl", Me)
        ' I could use a simple, standalone sql query here, as it would allow me to freely change the updateTable overloads in globals.vb.
        ' For now, though, I will try to implement these wherever I can for uniformity/consistency

        ' Then, return exception status of CRUD controller. Do this after each call
        If CRUD.HasException() Then Return False

        ' Otherwise, return true
        Return True

    End Function


    ' Function that makes insertRow calls for all relevant DataTables
    Private Function insertAll() As Boolean

        ' First, remove any formatting that was added (specific to the controls on this form)
        ' stripDataEditingControlsFormatting()

        ' Then, make calls to insertRow to all relevant tables
        insertRow(CRUD, LCDbController.DbDataTable, "Parts", "_", "dataEditingControl", Me)
        ' Then, return exception status of CRUD controller. Do this after each call
        If CRUD.HasException() Then Return False

        ' Otherwise, return true
        Return True

    End Function


    ' Function that makes deleteRow calls for all relevant DataTables
    Private Function deleteAll() As Boolean

        ' Then, make calls to insertRow to all relevant tables
        Dim valueAsKey As String = LCDbController.DbDataTable.Rows(LCRow)("LaborCode")
        deleteRow(CRUD, "Parts", valueAsKey, "LaborCode")
        ' Then, return exception status of CRUD controller. Do this after each call
        If CRUD.HasException() Then Return False

        ' Otherwise, return true
        Return True

    End Function


    Private Sub laborCodeMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class