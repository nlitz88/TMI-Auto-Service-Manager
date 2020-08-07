Imports System.Data.OleDb
Imports System.IO

Public Class DbControl

    ' New connection object. Connection string will be set in BuildConnString
    Private DbConn As New OleDbConnection()

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
        DbConn.ConnectionString = GetConnStringFromINI()
    End Sub

    ' Constructor override for custom connection string
    Public Sub New(ByVal connectionString As String)
        DbConn.ConnectionString = connectionString
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

            'MessageBox.Show("Successfully queried database" & vbNewLine & query)

        Catch ex As Exception

            ' Capture error
            Exception = "Database Query Error" & vbNewLine & ex.Message
            MessageBox.Show(Exception, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)

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


    ' Eventually, this will be the function that uses .config file to import these connection parameters
    ' Move this functionality to globals.vb? Or keep here...?
    Private Function GetConnStringFromINI() As String

        Dim line As String = String.Empty
        Dim connString = String.Empty
        Dim key As String = "CONNECTION-STRING="
        Dim INIFile As New StreamReader(Application.StartupPath & "\connection.ini")

        ' Do loop in case connection string is eventually moved to a different row in the ini configuration file
        Do Until INIFile.EndOfStream
            line = INIFile.ReadLine()
            If line.IndexOf(key) <> -1 Then
                Exit Do
            End If
        Loop

        If Not String.IsNullOrEmpty(line) Then
            connString = line.Substring((line.IndexOf(key) + key.Length), (line.Length - key.Length))
        End If

        Return connString

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

                    Console.WriteLine("Captured DBNull for row: " & DbDataTable.Rows.IndexOf(row) & " column: " & column.ColumnName & " | Supposed to be " & dataType.ToString())

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

                    row(column) = dataValue

                End If

            Next
        Next

    End Sub


End Class
