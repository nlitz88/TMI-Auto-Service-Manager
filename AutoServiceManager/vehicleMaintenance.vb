Public Class vehicleMaintenance

    ' New Database control instances for Customers and Vehicles datatables
    Private CustomerDbController As New DbControl()
    Private VehicleDbController As New DbControl()
    ' New Database control instance for updating, inserting, and deleting
    Private CRUD As New DbControl()

    ' Initialize new lists to store certain row values of datatables (easily sorted and BINARY SEARCHED FOR SPEED)
    Private VehicleList As List(Of Object)

    ' Initialize instance(s) of initialValues class
    Private InitialVehicleValues As New InitialValues()

    'Variable to keep track of whether form fully loaded or not
    Private valuesInitialized As Boolean = True

    ' Row index variables used for DataTable lookups
    Private CustomerRow As Integer
    Private lastSelectedCustomer As String  ' Unecessary
    Private VehicleRow As Integer
    Private lastSelectedVehicle As String

    ' Keeps track of whether or not user in "editing" or "adding" mode
    Private mode As String

    ' Variable that allows certain keystrokes through restricted fields
    Private allowedKeystroke As Boolean = False

    Private Sub vehicleMaintenance_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class