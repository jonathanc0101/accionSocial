Imports AccesoBD

Public Class Individuos
    Property listado As SortableBindingList(Of Individuo)

    'datos de conexion
    Private Property server As String
    Private Property miBd As String
    Private Property usuario As String
    Private Property contrasenia As String

    Public Property accesoDatos As BDAccesoATablas

    Public Sub New(direccionMiServer As String, miBD As String, miUsuario As String, miContrasenia As String)
        accesoDatos = New BDAccesoATablas(direccionMiServer, miBD, miUsuario, miContrasenia)

        server = direccionMiServer
        miBD = miBD
        usuario = miUsuario
        contrasenia = miContrasenia

        Me.resetearAValoresDefault()
    End Sub

    Public Sub New(ParamAccesoADatos As BDAccesoATablas)
        accesoDatos = ParamAccesoADatos

        Me.resetearAValoresDefault()
    End Sub

    Public Sub cargarListado()
        Dim tabla As New DataTable
        'obtenemos todos los individuos
        tabla = accesoDatos.obtenerTodosIndividuos()

        'vaciamos la lista
        listado = New SortableBindingList(Of Individuo)

        'los añadimos a la lista
        For Each fila As DataRow In tabla.Rows
            Dim individuoAux As New Individuo(accesoDatos)

            individuoAux.cargarDesdeIndividuos(fila)
            Me.listado.Add(individuoAux)

        Next
    End Sub

    Public Function nuevoIndividuoVacio() As Individuo
        Return New Individuo(Me.accesoDatos)
    End Function

    Private Sub resetearAValoresDefault()
        Me.listado = New SortableBindingList(Of Individuo)
    End Sub
End Class
