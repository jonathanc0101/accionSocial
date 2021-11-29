Imports AccesoBD

Public Class Individuo
    Public Property IdIndividuo As Integer
    Public Property IdGrupo As Integer
    Public Property Dni As String
    Public Property Sexo As String
    Public Property FNacimiento As Date
    Public Property Telefono As String
    Public Property Email As String
    Public Property FDefuncion As Date
    Public Property Descripcion As String
    Public Property ApellidoNombre As String

    'propiedades que solo se tienen en cuenta cuanto se carga un individuo desde el grupo conviviente
    Public Property Edad As Integer
    Public Property Relacion As String
    Public Property Domicilio As String

    Public Property grupoConviviente As GrupoConviviente
    Private Property accesoDatos As BDAccesoATablas

    Public Sub New(direccionMiServer As String, miBD As String, miUsuario As String, miContrasenia As String)
        accesoDatos = New BDAccesoATablas(direccionMiServer, miBD, miUsuario, miContrasenia)

        Me.resetearAValoresDefault()
    End Sub

    Public Sub New(ParamAccesoADatos As BDAccesoATablas)
        accesoDatos = ParamAccesoADatos

        Me.resetearAValoresDefault()
    End Sub

    Public Function existeDNI(paramDni As String) As Boolean
        Return accesoDatos.ExisteDNI(paramDni)
    End Function
#Region "cargar"

    Private Sub cargar(row As DataRow)
        IdIndividuo = row.Item("IdIndividuo")
        IdGrupo = row.Item("IdGrupo")
        Dni = row.Item("Dni")
        Sexo = row.Item("Sexo")
        FNacimiento = row.Item("FNacimiento")
        Telefono = row.Item("Telefono")
        Email = row.Item("Email")

        If IsDBNull(row.Item("FDefuncion")) Then
            FDefuncion = Nothing
        Else
            FDefuncion = row.Item("FDefuncion")
        End If
        Descripcion = row.Item("Descripcion")
        ApellidoNombre = row.Item("ApellidoNombre")

        Edad = row.Item("Edad")
    End Sub

    Protected Friend Sub cargarDesdeGrupoFamiliar(row As DataRow)
        IdIndividuo = row.Item("IdIndividuo")
        Dni = row.Item("DNI")
        ApellidoNombre = row.Item("Apellido y Nombre")
        Sexo = row.Item("Sexo")
        FNacimiento = row.Item("Nacimiento")

        Edad = row.Item("Edad")
        Relacion = row.Item("Relación")
    End Sub

    Protected Friend Sub cargarDesdeIndividuos(row As DataRow)
        IdIndividuo = row.Item("IdIndividuo")
        IdGrupo = row.Item("IdGrupo")
        Dni = row.Item("Dni")
        Sexo = row.Item("Sexo")
        FNacimiento = row.Item("FNacimiento")
        Telefono = row.Item("Telefono")
        Email = row.Item("Email")
        If IsDBNull(row.Item("FDefuncion")) Then
            FDefuncion = Nothing
        Else
            FDefuncion = row.Item("FDefuncion")
        End If
        Descripcion = row.Item("Descripcion")
        ApellidoNombre = row.Item("ApellidoNombre")
        Domicilio = row.Item("Domicilio")
        Edad = row.Item("Edad")

    End Sub
    Public Sub cargarPorID(ParamId As Integer)
        'cargamos solo uno, y como recibimos un datatable accedemos a la primera fila (0)
        Dim tabla As DataTable
        tabla = accesoDatos.obtenerPorID(ParamId)
        If tabla.Rows.Count > 0 Then
            cargar(tabla.Rows(0))
        End If
    End Sub

    Public Sub cargarPorDni(paramDni As String)
        'cargamos solo uno(el unico que debería haber), y como recibimos un datatable accedemos a la primera fila (0)
        Dim tabla As DataTable
        tabla = accesoDatos.obtenerPorDNI(paramDni)
        If tabla.Rows.Count > 0 Then
            cargar(tabla.Rows(0))
        End If
    End Sub

    Public Sub cargarCompletoPorId(ParamId As Integer)
        cargarPorID(ParamId)
        grupoConviviente.cargarCompletoPorIdIndividuo(ParamId)
    End Sub

    Public Sub cargarCompletoPorDni(ParamDni As String)
        cargarPorDni(ParamDni)
        grupoConviviente.cargarCompletoPorIdIndividuo(Me.IdIndividuo)
    End Sub

    Protected Friend Sub cargarGrupoConvivientePorIDGrupo()
        grupoConviviente.cargarCompletoPorId(Me.IdGrupo)
    End Sub

#End Region

#Region "informe"
    Public Sub guardarNuevoInforme(paramNombreAgente As String,
                            paramNombreOficina As String,
                            paramFecha As Date,
                            paramDescripcion As String)

        Dim informe As New Informe(Me.accesoDatos)
        informe.Idindividuo = Me.IdIndividuo
        informe.NombreAgente = paramNombreAgente
        informe.NombreOficina = paramNombreOficina
        informe.Fecha = paramFecha
        informe.Descripcion = paramDescripcion

        informe.guardar()
    End Sub

    Public Sub guardarNuevaAccion(paramNombreAgente As String,
                        paramNombreOficina As String,
                        paramFecha As Date,
                        paramDetalle As String)

        Dim accion As New Accion(Me.accesoDatos)
        accion.IdIndividuo = Me.IdIndividuo
        accion.NombreAgente = paramNombreAgente
        accion.NombreOficina = paramNombreOficina
        accion.Fecha = paramFecha
        accion.Detalle = paramDetalle

        accion.guardar()
    End Sub
#End Region

#Region "Alta y modificación"

    Public Sub agregar(guardador As Guardador)

        accesoDatos.agregarIndividuo(guardador.SqlCommand,
                                     guardador.indiceParametro,
                                     Me.IdGrupo,
                                     Me.Dni,
                                     Me.Sexo,
                                     Me.FNacimiento,
                                     Me.Telefono,
                                     Me.FDefuncion,
                                     Me.Descripcion,
                                     Me.ApellidoNombre,
                                     Me.Email)

    End Sub

    Public Sub actualizar(guardador As Guardador)

        accesoDatos.modificarIndividuo(guardador.SqlCommand,
                                       guardador.indiceParametro,
                                       Me.IdIndividuo,
                                       Me.IdGrupo,
                                       Me.Dni,
                                       Me.Sexo,
                                       Me.FNacimiento,
                                       Me.Telefono,
                                       Me.FDefuncion,
                                       Me.Descripcion,
                                       Me.ApellidoNombre,
                                       Me.Email)

    End Sub

#Region "guardar"
    Public Sub guardar()

        Dim guardador As New Guardador(accesoDatos.retornarNuevoBD())
        Dim nuevoRegistro As Boolean = False

        'grupo conviviente tiene que guardarse primero en el caso de que se cree uno nuevo, para mas info ver el metodo añadir grupo conviviente en acceso tablas
        If Me.grupoConviviente.IdGrupo = 0 Then
            grupoConviviente.agregar(guardador)
        Else
            grupoConviviente.actualizar(guardador)
        End If

        If Me.IdIndividuo = 0 Then

            nuevoRegistro = True
            agregar(guardador)
        Else
            actualizar(guardador)
        End If

        Try
            'se guarda el grupo conviviente primero y luego el individuo, si no se puede se hace rollback
            guardador.guardar()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub guardarConVinculos()

        Dim guardador As New Guardador(accesoDatos.retornarNuevoBD())
        Dim nuevoRegistro As Boolean = False

        'grupo conviviente tiene que guardarse primero en el caso de que se cree uno nuevo, para mas info ver el metodo añadir grupo conviviente en acceso tablas
        If Me.grupoConviviente.IdGrupo = 0 Then
            grupoConviviente.agregar(guardador)
        Else
            grupoConviviente.actualizar(guardador)
        End If

        If Me.IdIndividuo = 0 Then

            nuevoRegistro = True
            agregar(guardador)
        Else
            actualizar(guardador)
        End If

        ' Guarda el grupo familiar 
        '   Crea un VINCULO por cada persona del grupo familiar

        Dim indivAux As ObjetosDeNegocio.Individuo

        For Each indivAux In grupoConviviente.Individuos

            Dim vinculoFamiliarAux As VinculoFamiliar
            vinculoFamiliarAux = New VinculoFamiliar(accesoDatos)

            vinculoFamiliarAux.IdIndividuoA = indivAux.IdIndividuo
            vinculoFamiliarAux.IdIndividuoB = IdIndividuo
            vinculoFamiliarAux.relacionAB = indivAux.Relacion
            vinculoFamiliarAux.relacionBA = vinculoFamiliarAux.relacionFamiliarInversa(indivAux.Relacion)
            vinculoFamiliarAux.agregar(guardador)
        Next

        Try
            'se guarda el grupo conviviente primero y luego el individuo, si no se puede se hace rollback
            guardador.guardar()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region

#End Region
    Private Sub resetearAValoresDefault()
        IdIndividuo = 0
        IdGrupo = 0
        Dni = ""
        ApellidoNombre = ""
        Sexo = ""
        FNacimiento = Now()
        Telefono = ""
        Email = ""
        FDefuncion = Nothing
        Descripcion = ""
        Domicilio = ""
        Edad = 0
        Relacion = ""

        grupoConviviente = New GrupoConviviente(accesoDatos)
    End Sub
    Public Sub resetearValoresPersonales()
        IdIndividuo = 0
        'IdGrupo = 0
        Dni = ""
        ApellidoNombre = ""
        Sexo = ""
        FNacimiento = Now()
        Telefono = ""
        Email = ""
        FDefuncion = Nothing
        Descripcion = ""
        'Domicilio = ""
        Edad = 0
        'Relacion = ""

        'grupoConviviente = New GrupoConviviente(accesoDatos)
    End Sub

    Public Function InstanciarIndividuoNuevoEnGrupoConviviente() As Individuo
        Dim nuevoIndividuo As Individuo = New Individuo(Me.accesoDatos)
        'replicamos el grupo conviviente
        nuevoIndividuo.IdGrupo = Me.IdGrupo
        nuevoIndividuo.grupoConviviente.IdGrupo = Me.IdGrupo
        nuevoIndividuo.cargarGrupoConvivientePorIDGrupo()

        Return nuevoIndividuo
    End Function
End Class
