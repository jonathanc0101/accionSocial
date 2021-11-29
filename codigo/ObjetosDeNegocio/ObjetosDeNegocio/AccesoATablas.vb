Imports System.Data.SqlClient

Public Class BDAccesoATablas
    Private bd As AccesoBD.BD
    Private Property fechaAux As Date = Nothing
    Private Property direccionMiServer As String
    Private Property miBD As String
    Private Property miUsuario As String
    Private Property miContrasenia As String

    Public Sub New(ParamDireccionMiServer As String, ParamMiBD As String, ParamMiUsuario As String, ParamMiContrasenia As String)
        direccionMiServer = ParamDireccionMiServer
        miBD = ParamMiBD
        miUsuario = ParamMiUsuario
        miContrasenia = ParamMiContrasenia

        bd = New AccesoBD.BD(direccionMiServer, miBD, miUsuario, miContrasenia)
    End Sub

    Public Function retornarNuevoBD() As AccesoBD.BD
        Return New AccesoBD.BD(direccionMiServer, miBD, miUsuario, miContrasenia)
    End Function
#Region "comprobación"
    Public Function ExisteDNI(paramDni As String) As Boolean
        Return obtenerPorDNI(paramDni).Rows.Count > 0
    End Function
#End Region

#Region "obtención de datos"

    Public Function obtenerTodosIndividuos() As DataTable
        Return bd.obtenerDatos(consultaIndividuosListado())
    End Function

    Public Function obtenerPorID(ParamId As Integer) As DataTable
        Dim SqlCommand As New SqlCommand
        SqlCommand.CommandType = CommandType.Text
        SqlCommand.CommandText = consultaIndividuos() & " where [IdIndividuo] = @ParamId"
        SqlCommand.Parameters.AddWithValue("@ParamId", ParamId)

        Return bd.obtenerDatos(SqlCommand)
    End Function

    Public Function obtenerPorDNI(ParamDni As String) As DataTable
        Dim SqlCommand As New SqlCommand
        SqlCommand.CommandType = CommandType.Text
        SqlCommand.CommandText = consultaIndividuos() & " where [Dni] = @Dni "
        SqlCommand.Parameters.AddWithValue("@Dni", ParamDni)


        Return bd.obtenerDatos(SqlCommand)
    End Function

#Region "grupo conviviente"
    Public Function obtenerGrupoConvivientePorIdIndividuo(paramIdIndividuo As Integer) As DataTable
        Dim SqlCommand As New SqlCommand
        SqlCommand.CommandType = CommandType.Text

        Dim query As String
        query = "DECLARE @IDGRUPO INTEGER " & _
        "SET @IDGRUPO = (SELECT IdGrupo FROM [INDIVIDUO] WHERE [IdIndividuo] = @IDINDIVIDUO) " & _
        " Select " & _
        "      [IdIndividuo]" & _
        "	  ,[Dni] as 'DNI' " & _
        "	  ,[ApellidoNombre] as 'Apellido y Nombre' " & _
        "	  ,[Sexo]" & _
        "	  ,CONVERT(varchar,[FNacimiento],3) as 'Nacimiento' " & _
        "	  ,CASE WHEN [FDefuncion] is null THEN	/*compara la fecha de muerte*/" & _
        "		(DATEDIFF(YEAR,[FNacimiento],GETDATE()) " & _
        "		-(CASE " & _
        "		WHEN DATEADD(YY,DATEDIFF(YEAR,[FNacimiento],GETDATE()),[FNacimiento])>GETDATE() THEN	/*si no murio imprime la edad*/" & _
        "		1 " & _
        "		ELSE " & _
        "		0 " & _
        "		END)) " & _
        "		ELSE (DATEDIFF(YEAR,[FNacimiento],[FDefuncion])		/*si murio imprime la edad que tenia cuando murio*/" & _
        "		-(CASE" & _
        "		WHEN DATEADD(YY,DATEDIFF(YEAR,[FNacimiento],GETDATE()),[FNacimiento])>GETDATE() THEN" & _
        "		1" & _
        "		ELSE" & _
        "		0 " & _
        "		END))  " & _
        "        End" & _
        "		as 'Edad' " & _
        "	  ,COALESCE((SELECT [RelacionAB] from [VINCULO] " & _
        "			where [VINCULO].[idIndividuoB] = @IDINDIVIDUO " & _
        "				and " & _
        "				[VINCULO].[idIndividuoA] = [IdIndividuo])," & _
        "			   (SELECT [RelacionBA] from [VINCULO] " & _
        "			where [VINCULO].[idIndividuoA] = @IDINDIVIDUO " & _
        "				and " & _
        "				[VINCULO].[idIndividuoB] = [IdIndividuo]), '') as 'Relación' " & _
        "	FROM [SOCIALESQUEL].[dbo].[INDIVIDUO]" & _
        "WHERE ([IdGrupo] = @IDGRUPO and [idIndividuo] != @IDINDIVIDUO)"

        SqlCommand.CommandText = query
        SqlCommand.Parameters.AddWithValue("@IDINDIVIDUO", paramIdIndividuo)

        Return bd.obtenerDatos(SqlCommand)

    End Function

    Public Function obtenerAccionesGrupoConviente(paramIdIndividuo As Integer) As DataTable
        Dim SqlCommand As New SqlCommand
        SqlCommand.CommandType = CommandType.Text

        Dim query As String
        query = " DECLARE @IDGRUPO INTEGER " & _
                " SET @IDGRUPO = (SELECT IdGrupo FROM [INDIVIDUO] WHERE [IdIndividuo] = @IDINDIVIDUO)        " & _
                " SELECT 	 CONVERT(varchar,[FechaAccion],3) as 'Fecha'                                     " & _
                "       ,[INDIVIDUO].[IdIndividuo]                                                                       " & _
                " 		,[IdAccion]                                                                          " & _
                " 		,[NombreAgente] as 'Agente'                                                          " & _
                "       ,[NombreOficina]                                                                     " & _
                " 		,[DNI]                                                                               " & _
                " 		,[ApellidoNombre] AS 'Apellido y Nombre'                                             " & _
                " 		,COALESCE((SELECT [RelacionAB] from [VINCULO]                                        " & _
                " 				where [VINCULO].[idIndividuoB] = @IDINDIVIDUO                                " & _
                " 					and                                                                      " & _
                " 					[VINCULO].[idIndividuoA] = [INDIVIDUO].[IdIndividuo]),                   " & _
                " 				   (SELECT [RelacionBA] from [VINCULO]                                       " & _
                " 				where [VINCULO].[idIndividuoA] = @IDINDIVIDUO                                " & _
                " 					and                                                                      " & _
                " 					[VINCULO].[idIndividuoB] = [INDIVIDUO].[IdIndividuo]), '') as 'Relación' " & _
                " 		,[Detalle]                                                                           " & _
                " FROM [INDIVIDUO]                                                                           " & _
                " JOIN [ACCION]                                                                              " & _
                " ON [INDIVIDUO].[IdIndividuo] = [ACCION].[IdIndividuo]                                      " & _
                " WHERE [idgrupo] = @IDGRUPO "

        SqlCommand.CommandText = query
        SqlCommand.Parameters.AddWithValue("@IDINDIVIDUO", paramIdIndividuo)

        Return bd.obtenerDatos(SqlCommand)
    End Function

    Function obtenerInformesGrupoConviente(paramIdIndividuo As Integer) As DataTable

        Dim SqlCommand As New SqlCommand
        SqlCommand.CommandType = CommandType.Text

        Dim query As String

        query = "DECLARE @IDGRUPO INTEGER " & _
            "SET @IDGRUPO = (SELECT IdGrupo FROM [INDIVIDUO] WHERE [IdIndividuo] = @IDINDIVIDUO) " & _
            " SELECT 	 CONVERT(varchar,[Fecha],3) as 'Fecha' " & _
            ",[Idinforme]" & _
            ",[NombreOficina]                                                                     " & _
            ",[INFORME].[Idindividuo]" & _
            ",[NombreAgente] as 'Agente'" & _
            ",[DNI] " & _
            ",[ApellidoNombre] AS 'Apellido y Nombre'" & _
            ",COALESCE((SELECT [RelacionAB] from [VINCULO] " & _
            "				where [VINCULO].[idIndividuoB] = @IDINDIVIDUO " & _
            "					and " & _
            "					[VINCULO].[idIndividuoA] = [INDIVIDUO].[IdIndividuo])," & _
            "				   (SELECT [RelacionBA] from [VINCULO] " & _
            "				where [VINCULO].[idIndividuoA] = @IDINDIVIDUO " & _
            "					and  " & _
            "					[VINCULO].[idIndividuoB] = [INDIVIDUO].[IdIndividuo]), '') as 'Relación' " & _
            "		,[INFORME].[Descripcion] " & _
            "        FROM [INDIVIDUO] " & _
            "        Join [INFORME] " & _
            "ON [INDIVIDUO].[IdIndividuo] = [INFORME].[Idindividuo] " & _
            "WHERE [idgrupo] = @IDGRUPO "

        SqlCommand.CommandText = query
        SqlCommand.Parameters.AddWithValue("@IDINDIVIDUO", paramIdIndividuo)

        Return bd.obtenerDatos(SqlCommand)
    End Function

    Public Function obtenerDatosGrupoConvivientePorIdIndividuo(ParamIdIndividuo As Integer) As DataTable
        Dim SqlCommand As New SqlCommand
        SqlCommand.CommandType = CommandType.Text

        SqlCommand.CommandText = " DECLARE @IdGrupo INTEGER " & _
                        "SET @IdGrupo = (SELECT IdGrupo FROM [INDIVIDUO] WHERE [IdIndividuo] = @IdIndividuo) " & _
                        consultaGrupoConviviente() & _
                        " WHERE [IdGrupo] = @IdGrupo "

        SqlCommand.Parameters.AddWithValue("@IdIndividuo", ParamIdIndividuo)

        Return bd.obtenerDatos(SqlCommand)
    End Function

    Public Function obtenerGrupoConvivientePorIdGrupo(paramIDGrupo As Integer) As DataTable
        Dim SqlCommand As New SqlCommand
        SqlCommand.CommandType = CommandType.Text

        Dim query As String
        query = " Select " & _
        "      [IdIndividuo]" & _
        "	  ,[Dni] as 'DNI' " & _
        "	  ,[ApellidoNombre] as 'Apellido y Nombre' " & _
        "	  ,[Sexo]" & _
        "	  ,CONVERT(varchar,[FNacimiento],3) as 'Nacimiento' " & _
        "	  ,CASE WHEN [FDefuncion] is null THEN	/*compara la fecha de muerte*/" & _
        "		(DATEDIFF(YEAR,[FNacimiento],GETDATE()) " & _
        "		-(CASE " & _
        "		WHEN DATEADD(YY,DATEDIFF(YEAR,[FNacimiento],GETDATE()),[FNacimiento])>GETDATE() THEN	/*si no murio imprime la edad*/" & _
        "		1 " & _
        "		ELSE " & _
        "		0 " & _
        "		END)) " & _
        "		ELSE (DATEDIFF(YEAR,[FNacimiento],[FDefuncion])		/*si murio imprime la edad que tenia cuando murio*/" & _
        "		-(CASE" & _
        "		WHEN DATEADD(YY,DATEDIFF(YEAR,[FNacimiento],GETDATE()),[FNacimiento])>GETDATE() THEN" & _
        "		1" & _
        "		ELSE" & _
        "		0 " & _
        "		END))  " & _
        "        End" & _
        "		as 'Edad' " & _
        "	  , '' as 'Relación' " & _
        "	FROM [SOCIALESQUEL].[dbo].[INDIVIDUO]" & _
        "WHERE ([IdGrupo] = @IDGRUPO);"

        SqlCommand.CommandText = query
        SqlCommand.Parameters.AddWithValue("@IDGRUPO", paramIDGrupo)

        Return bd.obtenerDatos(SqlCommand)

    End Function
    Public Function obtenerAccionesGrupoConvientePorIDGrupo(paramIdGrupo As Integer) As DataTable
        Dim SqlCommand As New SqlCommand
        SqlCommand.CommandType = CommandType.Text

        Dim query As String
        query = " SELECT 	 CONVERT(varchar,[FechaAccion],3) as 'Fecha'                                     " & _
                "       ,[INDIVIDUO].[IdIndividuo]                                                                       " & _
                " 		,[IdAccion]                                                                          " & _
                " 		,[NombreAgente] as 'Agente'                                                          " & _
                "       ,[NombreOficina]                                                                     " & _
                " 		,[DNI]                                                                               " & _
                " 		,[ApellidoNombre] AS 'Apellido y Nombre'                                             " & _
                " 		,'' as 'Relación' " & _
                " 		,[Detalle]                                                                           " & _
                " FROM [INDIVIDUO]                                                                           " & _
                " JOIN [ACCION]                                                                              " & _
                " ON [INDIVIDUO].[IdIndividuo] = [ACCION].[IdIndividuo]                                      " & _
                " WHERE [idgrupo] = @IDGRUPO "

        SqlCommand.CommandText = query
        SqlCommand.Parameters.AddWithValue("@IDGRUPO", paramIdGrupo)

        Return bd.obtenerDatos(SqlCommand)
    End Function
    Function obtenerInformesGrupoConvientePorIDGrupo(paramIdGrupo As Integer) As DataTable

        Dim SqlCommand As New SqlCommand
        SqlCommand.CommandType = CommandType.Text

        Dim query As String

        query = " SELECT 	 CONVERT(varchar,[Fecha],3) as 'Fecha' " & _
            ",[Idinforme]" & _
            ",[NombreOficina]                                                                     " & _
            ",[INFORME].[Idindividuo]" & _
            ",[NombreAgente] as 'Agente'" & _
            ",[DNI] " & _
            ",[ApellidoNombre] AS 'Apellido y Nombre'" & _
            ",'' as 'Relación' " & _
            "		,[INFORME].[Descripcion] " & _
            "        FROM [INDIVIDUO] " & _
            "        Join [INFORME] " & _
            "ON [INDIVIDUO].[IdIndividuo] = [INFORME].[Idindividuo] " & _
            "WHERE [idgrupo] = @IDGRUPO;"

        SqlCommand.CommandText = query
        SqlCommand.Parameters.AddWithValue("@IDGRUPO", paramIdGrupo)

        Return bd.obtenerDatos(SqlCommand)
    End Function
    Public Function obtenerDatosGrupoConvivientePorIDGrupo(ParamIDGrupo As Integer) As DataTable
        Dim SqlCommand As New SqlCommand
        SqlCommand.CommandType = CommandType.Text

        SqlCommand.CommandText = consultaGrupoConviviente() & _
                        " WHERE [IdGrupo] = @IdGrupo;"

        SqlCommand.Parameters.AddWithValue("@IdGrupo", ParamIDGrupo)

        Return bd.obtenerDatos(SqlCommand)
    End Function


#End Region





#End Region

#Region "strings de consultas"
    Private Function consultaGrupoConviviente() As String
        Dim query As String
        query = "SELECT [IdGrupo] " & _
                  ",[Referencia] " & _
                  ",[Domicilio] " & _
                  ",[Barrio]" & _
                  "  FROM [GRUPO]"

        Return query
    End Function
    Private Function consultaIndividuosListado() As String
        Dim query As String
        query = "Select [IdIndividuo]" & _
                ",[IdGrupo]" & _
                ",[Dni]" & _
                ",[Sexo]" & _
                ",CASE WHEN [FDefuncion] is null THEN	/*compara la fecha de muerte*/" & _
                " (DATEDIFF(YEAR,[FNacimiento],GETDATE()) " & _
                " -(CASE " & _
                " WHEN DATEADD(YY,DATEDIFF(YEAR,[FNacimiento],GETDATE()),[FNacimiento])>GETDATE() THEN	/*si no murio imprime la edad*/" & _
                " 1 " & _
                " ELSE " & _
                " 0 " & _
                " END)) " & _
                " ELSE (DATEDIFF(YEAR,[FNacimiento],[FDefuncion])		/*si murio imprime la edad que tenia cuando murio*/" & _
                " -(CASE" & _
                " WHEN DATEADD(YY,DATEDIFF(YEAR,[FNacimiento],GETDATE()),[FNacimiento])>GETDATE() THEN" & _
                " 1" & _
                " ELSE" & _
                " 0 " & _
                " END))  " & _
                "  End" & _
                " as 'Edad' " & _
                ",[FNacimiento]" & _
                ",[Telefono]" & _
                ",[Email]" & _
                ",[FDefuncion]" & _
                ",[Descripcion]" & _
                ",[ApellidoNombre]" & _
                ",(select [Domicilio] from GRUPO where GRUPO.[IdGrupo] = [INDIVIDUO].[IdGrupo] ) as Domicilio" & _
                " FROM [INDIVIDUO] "
        Return query
    End Function
    Private Function consultaIndividuos() As String
        Dim query As String
        query = "Select [IdIndividuo]" & _
                ",[IdGrupo]" & _
                ",[Dni]" & _
                ",[Sexo]" & _
                ",CASE WHEN [FDefuncion] is null THEN	/*compara la fecha de muerte*/" & _
                " (DATEDIFF(YEAR,[FNacimiento],GETDATE()) " & _
                " -(CASE " & _
                " WHEN DATEADD(YY,DATEDIFF(YEAR,[FNacimiento],GETDATE()),[FNacimiento])>GETDATE() THEN	/*si no murio imprime la edad*/" & _
                " 1 " & _
                " ELSE " & _
                " 0 " & _
                " END)) " & _
                " ELSE (DATEDIFF(YEAR,[FNacimiento],[FDefuncion])		/*si murio imprime la edad que tenia cuando murio*/" & _
                " -(CASE" & _
                " WHEN DATEADD(YY,DATEDIFF(YEAR,[FNacimiento],GETDATE()),[FNacimiento])>GETDATE() THEN" & _
                " 1" & _
                " ELSE" & _
                " 0 " & _
                " END))  " & _
                "  End" & _
                " as 'Edad' " & _
                ",[FNacimiento]" & _
                ",[Telefono]" & _
                ",[Email]" & _
                ",[FDefuncion]" & _
                ",[Descripcion]" & _
                ",[ApellidoNombre]" & _
                " FROM [INDIVIDUO] "
        Return query
    End Function

#End Region

#Region "insercion y modificacion"

#Region "informe y accion"
    Public Sub insertarInforme(ByRef sqlcommand As SqlCommand,
                               ByRef indiceparametro As Integer,
                               ParamIdindividuo As Integer,
                               ParamNombreOficina As String,
                               ParamNombreAgente As String,
                               ParamFecha As Date,
                               ParamDescripcion As String)

        sqlcommand.CommandType = CommandType.Text

        Dim query = "INSERT INTO [INFORME] " & _
           "([Idindividuo]    " & _
           ",[NombreOficina]  " & _
           ",[NombreAgente]   " & _
           ",[Fecha]          " & _
           ",[Descripcion])   " & _
           " VALUES          " & _
           "(@Idindividuo" & indiceparametro & _
            ",@NombreOficina" & indiceparametro & _
            ",@NombreAgente" & indiceparametro & _
            ",@Fecha " & indiceparametro & _
            ",@Descripcion" & indiceparametro & ") ;"

        sqlcommand.CommandText &= query

        sqlcommand.Parameters.AddWithValue("@Idindividuo" & indiceparametro, ParamIdindividuo)
        sqlcommand.Parameters.AddWithValue("@NombreOficina" & indiceparametro, ParamNombreOficina)
        sqlcommand.Parameters.AddWithValue("@NombreAgente" & indiceparametro, ParamNombreAgente)
        sqlcommand.Parameters.AddWithValue("@Fecha" & indiceparametro, ParamFecha)
        sqlcommand.Parameters.AddWithValue("@Descripcion" & indiceparametro, ParamDescripcion)

        indiceparametro += 1
    End Sub

    Public Sub insertarInforme(ParamIdindividuo As Integer,
                           ParamNombreOficina As String,
                           ParamNombreAgente As String,
                           ParamFecha As Date,
                           ParamDescripcion As String)

        Dim sqlCommand As New SqlCommand
        SqlCommand.CommandType = CommandType.Text

        Dim query As String = "INSERT INTO [INFORME] " & _
           "([Idindividuo]    " & _
           ",[NombreOficina]  " & _
           ",[NombreAgente]   " & _
           ",[Fecha]          " & _
           ",[Descripcion])   " & _
           " VALUES          " & _
           "(@Idindividuo    " & _
           ",@NombreOficina  " & _
           ",@NombreAgente   " & _
           ",@Fecha          " & _
           ",@Descripcion );"

        SqlCommand.CommandText &= query

        SqlCommand.Parameters.AddWithValue("@Idindividuo", ParamIdindividuo)
        SqlCommand.Parameters.AddWithValue("@NombreOficina", ParamNombreOficina)
        SqlCommand.Parameters.AddWithValue("@NombreAgente", ParamNombreAgente)
        SqlCommand.Parameters.AddWithValue("@Fecha", ParamFecha)
        SqlCommand.Parameters.AddWithValue("@Descripcion", ParamDescripcion)

        bd.ejecutarNonQuery(sqlCommand)

    End Sub


    Public Sub modificarInforme(ParamIdInforme As Integer,
                                ParamIdindividuo As Integer,
                                ParamNombreOficina As String,
                                ParamNombreAgente As String,
                                ParamFecha As Date,
                                ParamDescripcion As String)

        Dim sqlCommand As New SqlCommand
        sqlCommand.CommandType = CommandType.Text

        Dim query = "UPDATE [INFORME]" & _
                    "  SET [Idindividuo] = @Idindividuo " & _
                    "     ,[NombreOficina] = @NombreOficina " & _
                    "     ,[NombreAgente] = @NombreAgente " & _
                    "     ,[Fecha] = @Fecha " & _
                    "     ,[Descripcion] = @Descripcion " & _
                    "WHERE [Idinforme] = @IdInforme;"

        sqlCommand.CommandText = query

        sqlCommand.Parameters.AddWithValue("@IdInforme", ParamIdInforme)

        sqlCommand.Parameters.AddWithValue("@Idindividuo", ParamIdindividuo)
        sqlCommand.Parameters.AddWithValue("@NombreOficina", ParamNombreOficina)
        sqlCommand.Parameters.AddWithValue("@NombreAgente", ParamNombreAgente)
        sqlCommand.Parameters.AddWithValue("@Fecha", ParamFecha)
        sqlCommand.Parameters.AddWithValue("@Descripcion", ParamDescripcion)

        bd.ejecutarNonQuery(sqlCommand)

    End Sub

    Public Sub insertarAccion(ParamIdIndividuo As Integer,
                            ParamNombreOficina As String,
                            ParamNombreAgente As String,
                            ParamFechaAccion As Date,
                            ParamDetalle As String)

        Dim sqlCommand As New SqlCommand
        sqlCommand.CommandType = CommandType.Text

        Dim query = "INSERT INTO [ACCION]" & _
        "   ([IdIndividuo]    " & _
        "   ,[NombreOficina]  " & _
        "   ,[NombreAgente]   " & _
        "   ,[FechaAccion]    " & _
        "   ,[Detalle])       " & _
        " VALUES " & _
        "   (@IdIndividuo      " & _
        "   ,@NombreOficina    " & _
        "   ,@NombreAgente     " & _
        "   ,@FechaAccion      " & _
        "   ,@Detalle       );"

        sqlCommand.CommandText = query

        sqlCommand.Parameters.AddWithValue("@IdIndividuo", ParamIdIndividuo)
        sqlCommand.Parameters.AddWithValue("@NombreOficina", ParamNombreOficina)
        sqlCommand.Parameters.AddWithValue("@NombreAgente", ParamNombreAgente)
        sqlCommand.Parameters.AddWithValue("@FechaAccion", ParamFechaAccion)
        sqlCommand.Parameters.AddWithValue("@Detalle", ParamDetalle)


        bd.ejecutarNonQuery(sqlCommand)
    End Sub


#End Region

#Region "individuo"
    Public Sub modificarIndividuo(ByRef sqlcommand As SqlCommand,
                                  ByRef indiceparametro As Integer,
                                    IdIndividuo As Integer,
                                    IdGrupo As Integer,
                                    Dni As String,
                                    Sexo As Char,
                                    FNacimiento As Date,
                                    Telefono As String,
                                    FDefuncion As Date,
                                    Descripcion As String,
                                    ApellidoNombre As String,
                                    Email As String)


        Dim query = "UPDATE [INDIVIDUO]   "
        If IdGrupo <> 0 Then
            query &= "  SET [IdGrupo]=@IdGrupo" & indiceparametro
        Else
            query &= "  SET [IdGrupo]=@IdGrupo"
        End If
        query &= "     ,[Dni]=@Dni" & indiceparametro & _
          "     ,[Sexo]=@Sexo" & indiceparametro & _
          "     ,[FNacimiento]=@FNacimiento" & indiceparametro & _
          "     ,[Telefono]=@Telefono" & indiceparametro & _
          "     ,[FDefuncion]=@FDefuncion" & indiceparametro & _
          "     ,[Descripcion]=@Descripcion" & indiceparametro & _
          "     ,[ApellidoNombre]=@ApellidoNombre" & _
          "     ,[Email]=@Email" & indiceparametro & _
          " WHERE[IdIndividuo]=@IdIndividuo;" & indiceparametro

            sqlcommand.CommandText &= query

        If IdGrupo <> 0 Then
            'si el grupo no es nuevo entonces no se añade de manera implicita en el metodo agregarGrupoConviviente
            sqlcommand.Parameters.AddWithValue("@IdGrupo" & indiceparametro, IdGrupo)
        End If

            sqlcommand.Parameters.AddWithValue("@Dni" & indiceparametro, Dni)
            sqlcommand.Parameters.AddWithValue("@Sexo" & indiceparametro, Sexo)
            sqlcommand.Parameters.AddWithValue("@FNacimiento" & indiceparametro, FNacimiento)
            sqlcommand.Parameters.AddWithValue("@Telefono" & indiceparametro, Telefono)

            If IsNothing(FDefuncion) Or FDefuncion = fechaAux Then
                sqlcommand.Parameters.AddWithValue("@FDefuncion" & indiceparametro, DBNull.Value)
            Else
                sqlcommand.Parameters.AddWithValue("@FDefuncion" & indiceparametro, FDefuncion)
            End If

            sqlcommand.Parameters.AddWithValue("@Descripcion" & indiceparametro, Descripcion)
            sqlcommand.Parameters.AddWithValue("@ApellidoNombre" & indiceparametro, ApellidoNombre)
            sqlcommand.Parameters.AddWithValue("@Email" & indiceparametro, Email)
            sqlcommand.Parameters.AddWithValue("@IdIndividuo" & indiceparametro, IdIndividuo)

            indiceparametro += 1
    End Sub

    Public Sub agregarIndividuo(ByRef sqlcommand As SqlCommand,
                                ByRef indiceparametro As Integer,
                                IdGrupo As Integer,
                                Dni As String,
                                Sexo As Char,
                                FNacimiento As Date,
                                Telefono As String,
                                FDefuncion As Date,
                                Descripcion As String,
                                ApellidoNombre As String,
                                Email As String)

        Dim query As String
        query = " INSERT INTO [INDIVIDUO]   " & _
        "   ([IdGrupo]                     " & _
        "   ,[Dni]                         " & _
        "   ,[Sexo]                        " & _
        "   ,[FNacimiento]                 " & _
        "   ,[Telefono]                    " & _
        "   ,[FDefuncion]                  " & _
        "   ,[Descripcion]                 " & _
        "   ,[ApellidoNombre]              " & _
        "   ,[Email])                      " & _
        " VALUES(                           "
        If IdGrupo <> 0 Then
            query &= "   @IdGrupo" & indiceparametro
        Else
            query &= "   @IdGrupo"
        End If
        query &= "   ,@Dni" & indiceparametro & _
        "   ,@Sexo" & indiceparametro & _
        "   ,@FNacimiento" & indiceparametro & _
        "   ,@Telefono" & indiceparametro & _
        "   ,@FDefuncion" & indiceparametro & _
        "   ,@Descripcion" & indiceparametro & _
        "   ,@ApellidoNombre" & indiceparametro & _
        "   ,@Email" & indiceparametro & ");"

            'esto es por si cargamos un individuo desde cero, en conjunto con sus vinculos de grupo conviviente
        query &= "DECLARE @IdIndividuoB AS INTEGER;" & _
            "SET @IdIndividuoB = (SELECT SCOPE_IDENTITY());"


            sqlcommand.CommandText &= query

            If IdGrupo <> 0 Then
                sqlcommand.Parameters.AddWithValue("@IdGrupo" & indiceparametro, IdGrupo)
            End If

            sqlcommand.Parameters.AddWithValue("@Dni" & indiceparametro, Dni)
            sqlcommand.Parameters.AddWithValue("@Sexo" & indiceparametro, Sexo)
            sqlcommand.Parameters.AddWithValue("@FNacimiento" & indiceparametro, FNacimiento)
            sqlcommand.Parameters.AddWithValue("@Telefono" & indiceparametro, Telefono)

            If IsNothing(FDefuncion) Or FDefuncion = fechaAux Then
                sqlcommand.Parameters.AddWithValue("@FDefuncion" & indiceparametro, DBNull.Value)
            Else
                sqlcommand.Parameters.AddWithValue("@FDefuncion" & indiceparametro, FDefuncion)
            End If

            sqlcommand.Parameters.AddWithValue("@Descripcion" & indiceparametro, Descripcion)
            sqlcommand.Parameters.AddWithValue("@ApellidoNombre" & indiceparametro, ApellidoNombre)
            sqlcommand.Parameters.AddWithValue("@Email" & indiceparametro, Email)

            indiceparametro += 1

    End Sub
#End Region


#Region "vinculo"

    Public Sub insertarVinculo(ByRef sqlcommand As SqlCommand,
                               ByRef indiceparametro As Integer,
                               ParamIdIndividuoA As Integer,
                               ParamIdIndividuoB As Integer,
                               ParamRelacionAB As String,
                               ParamRelacionBA As String)

        Dim query = "INSERT INTO [VINCULO]" & _
        "   ([IdIndividuoA]    " & _
        "   ,[IdIndividuoB]  " & _
        "   ,[RelacionAB]   " & _
        "   ,[RelacionBA])    " & _
        " VALUES " & _
        "   (@IdIndividuoA" & indiceparametro

        If ParamIdIndividuoB <> 0 Then
            query &= "   ,@IdIndividuoB" & indiceparametro
        Else
            query &= "   ,@IdIndividuoB"

        End If

        query &= "   ,@RelacionAB" & indiceparametro & _
        "   ,@RelacionBA" & indiceparametro & ");"


        sqlcommand.CommandText &= query
        sqlcommand.Parameters.AddWithValue("@IdIndividuoA" & indiceparametro, ParamIdIndividuoA)
        If ParamIdIndividuoB <> 0 Then
            sqlcommand.Parameters.AddWithValue("@IdIndividuoB" & indiceparametro, ParamIdIndividuoA)
        End If
        sqlcommand.Parameters.AddWithValue("@RelacionAB" & indiceparametro, ParamRelacionAB)
        sqlcommand.Parameters.AddWithValue("@RelacionBA" & indiceparametro, ParamRelacionBA)

        indiceparametro += 1
    End Sub

#End Region
#Region "grupo conviviente"
    Public Sub modificarGrupoConviviente(ByRef sqlcommand As SqlCommand,
                              ByRef indiceparametro As Integer,
                                Referencia As String,
                                Domicilio As String,
                                Barrio As String,
                                IdGrupo As Integer)

        Dim query As String = "UPDATE [GRUPO]" & _
         "  SET  [Referencia]= @Referencia" & indiceparametro & _
         "     , [Domicilio]=  @Domicilio" & indiceparametro & _
         "     , [Barrio] =    @Barrio" & indiceparametro & _
         " WHERE [IdGrupo] =  @IdGrupo" & indiceparametro & ";"

        sqlcommand.CommandText &= query

        sqlcommand.Parameters.AddWithValue("@Referencia" & indiceparametro, Referencia)
        sqlcommand.Parameters.AddWithValue("@Domicilio" & indiceparametro, Domicilio)
        sqlcommand.Parameters.AddWithValue("@Barrio" & indiceparametro, Barrio)
        sqlcommand.Parameters.AddWithValue("@IdGrupo" & indiceparametro, IdGrupo)

        indiceparametro += 1
    End Sub

    Public Sub agregarGrupoConviviente(ByRef sqlcommand As SqlCommand,
                                ByRef indiceparametro As Integer,
                                Referencia As String,
                                Domicilio As String,
                                Barrio As String)

        Dim query As String
        query = "INSERT INTO [SOCIALESQUEL].[dbo].[GRUPO]" & _
                "    ([Referencia]                                " & _
                "    ,[Domicilio]                                 " & _
                "    ,[Barrio])                                   " & _
                " VALUES(                                  " & _
                "    @Referencia" & indiceparametro & _
                "    ,@Domicilio" & indiceparametro & _
                "    ,@Barrio" & indiceparametro & ");"

        'esto es por si cargamos un individuo desde cero, en conjunto con su grupo conviviente
        query &= "DECLARE @IdGrupo AS INTEGER;" & _
        "SET @IdGrupo = (SELECT SCOPE_IDENTITY());"

        sqlcommand.CommandText &= query

        sqlcommand.Parameters.AddWithValue("@Referencia" & indiceparametro, Referencia)
        sqlcommand.Parameters.AddWithValue("@Domicilio" & indiceparametro, Domicilio)
        sqlcommand.Parameters.AddWithValue("@Barrio" & indiceparametro, Barrio)

        indiceparametro += 1
    End Sub
#End Region

#End Region

End Class
