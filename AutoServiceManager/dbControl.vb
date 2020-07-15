' Import OleDb namespace
Imports System.Data.OleDb

Public Class dbControl

    ' New connection object. Connection string will be set in BuildConnString
    Private dbConn As New OleDbConnection()

    ' Connection string parameters
    Private dbProvider As String            ' The data provider (that includes the data adapter) that we want the connection to use to interface with the access database (in this case, Jet 4.0 for mdb files)
    Private dbSource As String              ' The location of the actual access database file (will contain the complete composited location that we build with the following variables)
    Private dbDirectory As String           ' The working directory where the database is currently setup/stored
    Private dbFileName As String            ' The address of only the database
    Private dbFullPath As String            ' Full path built from DatabaseDirectory and DatabaseFilename. Will be used in combination with another parameter to set dbSource Variable

    ' Database Command, DataAdapter, and DataTable for instance. Regenerated every query, so reference only.
    Private dbCmd As OleDbCommand
    Public dbDataTable As DataTable
    Public dbAdapter As OleDbDataAdapter

    ' Query parameters
    Public queryParams As New List(Of OleDbParameter)

    ' Query statistics
    Public Exception As String


    ' Default Constructor
    Public Sub New()
        BuildConnString()                               ' might be replaced
    End Sub

    ' Constructor override for custom connection string
    Public Sub New(ByVal connectionString As String)
        dbConn.ConnectionString = connectionString      ' might be replaced
    End Sub


    ' Execute Query
    Public Sub ExecQuery(ByVal query As String)

        ' Reset Query stats
        Exception = String.Empty

        ' Try to open connection and execute query
        Try

            dbConn.Open()


            ' Create new dbCmd from connection and query
            dbCmd = New OleDbCommand(query, dbConn)

            ' Load query parameters into db command
            For Each param In queryParams
                dbCmd.Parameters.Add(param)
            Next
            ' Clear before next query is run
            queryParams.Clear()


            ' Create new DataTable, execute query, and fill DataTable using adapter
            dbDataTable = New DataTable
            dbAdapter = New OleDbDataAdapter(dbCmd)
            dbAdapter.Fill(dbDataTable)

            MessageBox.Show("Successfully queried " & dbFileName)

        Catch ex As Exception

            ' Capture error
            Exception = "ExecQuery Error" & vbNewLine & ex.Message

        Finally

            If dbConn.State = ConnectionState.Open Then dbConn.Close()

        End Try

    End Sub


    ' Add parameters to parameter list
    Public Sub AddParams(ByVal name As String, ByVal value As Object)

        Dim newParam As New OleDbParameter(name, value)
        queryParams.Add(newParam)

    End Sub


    ' Error checking
    Public Function HasException(ByVal Optional report As Boolean = False) As Boolean

        If String.IsNullOrEmpty(Exception) Then Return False
        ' or if exception was thrown
        If report Then MessageBox.Show(Exception, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Return True

    End Function


    ' Eventually, this will be the function that uses .config file to import these connection parameters
    ' Move this functionality to globals.vb? Or keep here...?
    Private Sub BuildConnString()

        dbDirectory = "C:\Users\nlitz\Development\TMI Consulting\Auto Service Manager\AutoServiceManager\AutoServiceManager\Database"
        dbFileName = "TMI-ServiceMgr.mdb"
        dbFullPath = dbDirectory & "\" & dbFileName
        dbSource = "Data Source = " & dbFullPath                ' Finally, define the dbSource by combinding everywith the appropriate parameter "Data Source"
        dbProvider = "PROVIDER=Microsoft.Jet.OLEDB.4.0;"        ' Utilizing the Jet OLEDB data provider, as we are using an older access database .mdb (2003)

        dbConn.ConnectionString = dbProvider & dbSource

    End Sub



End Class
