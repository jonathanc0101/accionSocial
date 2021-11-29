Imports AccesoBD

Public Class Accion
    Public Property IdIndividuo As Integer
    Public Property Fecha As Date
    Public Property IdAccion As Integer
    Public Property NombreOficina As String
    Public Property NombreAgente As String
    Public Property DNI As String
    Public Property ApellidoNombre As String
    Public Property Relacion As String
    Public Property Detalle As String

    'datos de conexion
    Private Property server As String
    Private Property miBd As String
    Private Property usuario As String
    Private Property contrasenia As String

    Private Property accesoDatos As BDAccesoATablas

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

    Protected Friend Sub cargarDesdeGrupoConviviente(row As DataRow)
        Fecha = row.Item("Fecha")
        IdAccion = row.Item("IdAccion")
        IdIndividuo = row.Item("IdIndividuo")
        'aca iria cargar oficina 
        NombreOficina = row.Item("NombreOficina")
        NombreAgente = row.Item("Agente")
        DNI = row.Item("DNI")
        ApellidoNombre = row.Item("Apellido y Nombre")
        Relacion = row.Item("Relación")
        Detalle = row.Item("Detalle")
    End Sub

    Public Sub guardar()
        Try
            If Me.IdAccion = 0 Then
                accesoDatos.insertarAccion(Me.IdIndividuo, NombreOficina, NombreAgente, Fecha, Detalle)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Private Sub resetearAValoresDefault()
        Fecha = Now()
        IdAccion = 0
        NombreOficina = ""
        NombreAgente = ""
        DNI = ""
        ApellidoNombre = ""
        Relacion = ""
        Detalle = ""
    End Sub
End Class
