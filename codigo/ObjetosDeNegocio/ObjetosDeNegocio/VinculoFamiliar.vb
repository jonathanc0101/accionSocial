Imports AccesoBD

Public Class VinculoFamiliar
    Public Property IdVinculo As Integer
    Public Property IdIndividuoA As Integer
    Public Property IdIndividuoB As Integer
    Public Property relacionAB As String
    Public Property relacionBA As String
    Public Property Relacion As String

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

    Protected Friend Sub cargarDesdeVinculoFamiliar(row As DataRow)
        IdIndividuoA = row.Item("IdIndividuoA")
        IdIndividuoB = row.Item("IdIndividuoB")
        relacionAB = row.Item("relacionAB")
        relacionBA = row.Item("relacionBA")

    End Sub

    Public Sub agregar(guardador As Guardador)

        accesoDatos.insertarVinculo(guardador.SqlCommand,
                                     guardador.indiceParametro,
                                     Me.IdIndividuoA,
                                     Me.IdIndividuoB,
                                     Me.relacionAB,
                                     Me.relacionBA)
    End Sub

    Protected Friend Function relacionFamiliarInversa(paramRelacion As String) As String

        Select Case paramRelacion
            Case "Esposo/a"
                Return "Esposo/a"
            Case "Concubino/a"
                Return "Concubino/a"
            Case "Madre/Padre"
                Return "Hijo/a"
            Case "Hijo/a"
                Return "Madre/Padre"
            Case "Abuelo/a"
                Return "Nieto/a"
            Case "Nieto/a"
                Return "Abuelo/a"
            Case "Hermano/a"
                Return "Hermano/a"
            Case "Suegro/a"
                Return "Yerno/Nuera"
            Case "Yerno/Nuera"
                Return "Suegro/a"
            Case "BisAbuelo/a"
                Return "Bisnieto/a"
            Case "Bisnieto/a"
                Return "BisAbuelo/a"
            Case "Tio/a"
                Return "Sobrino/a"
            Case "Sobrino/a"
                Return "Tio/a"
            Case "Primo/a"
                Return "Primo/a"
            Case "Otro"
                Return "Otro"
            Case Else
                Return ""
        End Select
    End Function
    Private Sub resetearAValoresDefault()

        IdVinculo = 0
        IdIndividuoA = 0
        IdIndividuoB = 0
        relacionAB = ""
        relacionBA = ""
        Relacion = ""

    End Sub
End Class
