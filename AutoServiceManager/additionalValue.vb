Public Class AdditionalValue

    Public ColumnName As String
    Public ColumnDataType As Type
    Public Value As Object

    Public Sub New(ByVal colName As String, ByVal colDataType As Type, ByVal additionalValue As Object)

        ColumnName = colName
        ColumnDataType = colDataType
        Value = additionalValue

    End Sub

End Class
