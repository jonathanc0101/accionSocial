Imports AccesoBD
Imports System.ComponentModel

Public Class GrupoConviviente
    Public Property IdGrupo As Integer
    Public Property Referencia As String
    Public Property Domicilio As String
    Public Property Barrio As String

    Public Property Individuos As SortableBindingList(Of Individuo)
    Public Property AccionesIndividuos As SortableBindingList(Of Accion)
    Public Property InformesIndividuos As SortableBindingList(Of Informe)

    Private Property accesoDatos As BDAccesoATablas

    Public Sub New(direccionMiServer As String, miBD As String, miUsuario As String, miContrasenia As String)
        accesoDatos = New BDAccesoATablas(direccionMiServer, miBD, miUsuario, miContrasenia)

        Me.resetearAValoresDefault()
    End Sub

    Public Sub New(ParamAccesoADatos As BDAccesoATablas)
        accesoDatos = ParamAccesoADatos

        Me.resetearAValoresDefault()
    End Sub

#Region "cargar"

    Private Sub cargar(row As DataRow)
        IdGrupo = row.Item("IdGrupo")
        Referencia = row.Item("Referencia")
        Domicilio = row.Item("Domicilio")
        Barrio = row.Item("Barrio")
    End Sub

    Protected Friend Sub cargarCompletoPorIdIndividuo(ParamIdIndividuo As Integer)
        Me.resetearAValoresDefault()

        Dim tabla As DataTable = accesoDatos.obtenerDatosGrupoConvivientePorIdIndividuo(ParamIdIndividuo)
        If tabla.Rows.Count > 0 Then
            cargar(tabla.Rows(0))

            'cargamos los individuos
            Dim tablaIndividuosGrupoConviviente As DataTable = accesoDatos.obtenerGrupoConvivientePorIdIndividuo(ParamIdIndividuo)

            For Each row As DataRow In tablaIndividuosGrupoConviviente.Rows
                Dim individuoNuevo As New Individuo(accesoDatos)
                individuoNuevo.cargarDesdeGrupoFamiliar(row)

                Individuos.Add(individuoNuevo)
            Next

            'cargamos las acciones
            Dim tablaAcciones As DataTable = accesoDatos.obtenerAccionesGrupoConviente(ParamIdIndividuo)

            For Each row As DataRow In tablaAcciones.Rows
                Dim accionNueva As New Accion(accesoDatos)
                accionNueva.cargarDesdeGrupoConviviente(row)

                AccionesIndividuos.Add(accionNueva)
            Next

            'cargamos los informes
            Dim tablaInformes As DataTable = accesoDatos.obtenerInformesGrupoConviente(ParamIdIndividuo)

            For Each row As DataRow In tablaInformes.Rows
                Dim informeNuevo As New Informe(accesoDatos)
                informeNuevo.cargarDesdeGrupoConviviente(row)

                InformesIndividuos.Add(informeNuevo)
            Next
        End If
    End Sub

    Protected Friend Sub cargarCompletoPorId(ParamIdGrupo As Integer)
        Me.resetearAValoresDefault()

        Dim tabla As DataTable = accesoDatos.obtenerDatosGrupoConvivientePorIDGrupo(ParamIdGrupo)
        If tabla.Rows.Count > 0 Then
            cargar(tabla.Rows(0))

            'cargamos los individuos
            Dim tablaIndividuosGrupoConviviente As DataTable = accesoDatos.obtenerGrupoConvivientePorIdGrupo(ParamIdGrupo)

            For Each row As DataRow In tablaIndividuosGrupoConviviente.Rows
                Dim individuoNuevo As New Individuo(accesoDatos)
                individuoNuevo.cargarDesdeGrupoFamiliar(row)

                Individuos.Add(individuoNuevo)
            Next

            'cargamos las acciones
            Dim tablaAcciones As DataTable = accesoDatos.obtenerAccionesGrupoConvientePorIDGrupo(ParamIdGrupo)

            For Each row As DataRow In tablaAcciones.Rows
                Dim accionNueva As New Accion(accesoDatos)
                accionNueva.cargarDesdeGrupoConviviente(row)

                AccionesIndividuos.Add(accionNueva)
            Next

            'cargamos los informes
            Dim tablaInformes As DataTable = accesoDatos.obtenerInformesGrupoConvientePorIDGrupo(ParamIdGrupo)

            For Each row As DataRow In tablaInformes.Rows
                Dim informeNuevo As New Informe(accesoDatos)
                informeNuevo.cargarDesdeGrupoConviviente(row)

                InformesIndividuos.Add(informeNuevo)
            Next
        End If
    End Sub

#End Region
#Region "Alta y modificación"

    Public Sub agregar(guardador As Guardador)

        accesoDatos.agregarGrupoConviviente(guardador.SqlCommand,
                                     guardador.indiceParametro,
                                     Me.Referencia,
                                     Me.Domicilio,
                                     Me.Barrio)
    End Sub

    Public Sub actualizar(guardador As Guardador)

        accesoDatos.modificarGrupoConviviente(guardador.SqlCommand,
                                     guardador.indiceParametro,
                                     Me.Referencia,
                                     Me.Domicilio,
                                     Me.Barrio,
                                     Me.IdGrupo)
    End Sub

#Region "guardar"
    Public Sub guardar()


        Dim guardador As New Guardador(accesoDatos.retornarNuevoBD())
        Dim nuevoRegistro As Boolean = False

        If Me.IdGrupo = 0 Then

            nuevoRegistro = True
            agregar(guardador)
        Else
            actualizar(guardador)
        End If

        Try
            guardador.guardar()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub



#End Region

#End Region

    Private Sub resetearAValoresDefault()
        IdGrupo = 0
        Referencia = ""
        Domicilio = ""
        Barrio = ""

        Individuos = New SortableBindingList(Of Individuo)
        AccionesIndividuos = New SortableBindingList(Of Accion)
        InformesIndividuos = New SortableBindingList(Of Informe)
    End Sub

End Class
