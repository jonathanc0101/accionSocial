Imports AccesoBD

Public Class Informe
    Public Property Idinforme As Integer
    Public Property Idindividuo As Integer
    Public Property Fecha As Date
    Public Property NombreOficina As String
    Public Property NombreAgente As String
    Public Property DNI As String
    Public Property ApellidoNombre As String
    Public Property Relacion As String
    Public Property Descripcion As String

    Private Property accesoDatos As BDAccesoATablas

    Public Sub New(direccionMiServer As String, miBD As String, miUsuario As String, miContrasenia As String)
        accesoDatos = New BDAccesoATablas(direccionMiServer, miBD, miUsuario, miContrasenia)

        Me.resetearAValoresDefault()
    End Sub

    Public Sub New(ParamAccesoADatos As BDAccesoATablas)
        accesoDatos = ParamAccesoADatos

        Me.resetearAValoresDefault()
    End Sub

    Public Sub cargarDesdeGrupoConviviente(row As DataRow)
        Idinforme = row.Item("Idinforme")
        Idindividuo = row.Item("Idindividuo")
        Fecha = row.Item("Fecha")
        'aca iria NombreOficina
        NombreOficina = row.Item("NombreOficina")
        NombreAgente = row.Item("Agente")
        DNI = row.Item("DNI")
        ApellidoNombre = row.Item("Apellido y Nombre")
        Relacion = row.Item("Relación")
        Descripcion = row.Item("Descripcion")
    End Sub

    Public Sub guardar()
        Try
            If Me.Idinforme = 0 Then
                accesoDatos.insertarInforme(Idindividuo, NombreOficina, NombreAgente, Fecha, Descripcion)
            Else
                accesoDatos.modificarInforme(Me.Idinforme, Idindividuo, NombreOficina, NombreAgente, Fecha, Descripcion)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub resetearAValoresDefault()
        Idinforme = 0
        Idindividuo = 0
        Fecha = Now()
        NombreOficina = ""
        NombreAgente = ""
        DNI = ""
        ApellidoNombre = ""
        Relacion = ""
        Descripcion = ""
    End Sub
End Class
