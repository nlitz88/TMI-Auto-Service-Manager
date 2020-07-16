﻿Imports System.Data.OleDb
Imports System.Configuration

Public Class DbControl

    ' New connection object. Connection string will be set in BuildConnString
    Private DbConn As New OleDbConnection()

    ' Connection string parameters
    Private DbProvider As String            ' The data provider (that includes the data adapter) that we want the connection to use to interface with the access database (in this case, Jet 4.0 for mDb files)
    Private DbSource As String              ' The location of the actual access database file (will contain the complete composited location that we build with the following variables)

    Private DbDirectory As String           ' The working directory where the database is currently setup/stored
    Private DbFileName As String            ' The address of only the database
    Private DbFullPath As String            ' Full path built from DatabaseDirectory and DatabaseFilename. Will be used in combination with another parameter to set DbSource Variable

    ' Database Command, DataAdapter, and DataTable for instance. Regenerated every query, so reference only.
    Private DbCmd As OleDbCommand
    Public DbDataTable As DataTable
    Public DbAdapter As OleDbDataAdapter

    ' Query parameters
    Public queryParams As New List(Of OleDbParameter)

    ' Query statistics
    Public Exception As String


    ' Default Constructor
    Public Sub New()

        ' Consider making this into class Sub
        Dim AppConfig As Configuration = ConfigurationManager.OpenExeConfiguration(Application.StartupPath & "\AutoServiceManager.exe")
        DbConn.ConnectionString = AppConfig.ConnectionStrings.ConnectionStrings("TMI-ServiceMgr").ConnectionString

    End Sub

    ' Constructor override for custom connection string
    Public Sub New(ByVal connectionString As String)
        DbConn.ConnectionString = connectionString      ' might be replaced
    End Sub


    ' Execute Query
    Public Sub ExecQuery(ByVal query As String)

        ' Reset Query stats
        Exception = String.Empty

        ' Try to open connection and execute query
        Try

            DbConn.Open()


            ' Create new DbCmd from connection and query
            DbCmd = New OleDbCommand(query, DbConn)

            ' Load query parameters into Db command
            For Each param In queryParams
                DbCmd.Parameters.Add(param)
            Next
            ' Clear before next query is run
            queryParams.Clear()


            ' Create new DataTable, execute query, and fill DataTable using adapter
            DbDataTable = New DataTable
            DbAdapter = New OleDbDataAdapter(DbCmd)
            DbAdapter.Fill(DbDataTable)

            ' Setll all null values to defaults in newly filled DataTable
            SetNullsToDefault()

            MessageBox.Show("Successfully queried " & DbFileName)

        Catch ex As Exception

            ' Capture error
            Exception = "ExecQuery Error" & vbNewLine & ex.Message

        Finally

            If DbConn.State = ConnectionState.Open Then DbConn.Close()

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


    ' Sub used to replace DBNull entries in provided DataTable to default entries respective to their dataType
    ' Receives dataTable as reference, so all changes are made directly on DataTable
    ' Eventually, move this in with the database control class.
    Private Sub SetNullsToDefault()

        For Each row As DataRow In DbDataTable.Rows
            For Each column As DataColumn In DbDataTable.Columns

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


End Class
