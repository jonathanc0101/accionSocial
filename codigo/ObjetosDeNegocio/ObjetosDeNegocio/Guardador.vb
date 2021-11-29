Imports System.Data.SqlClient

Public Class Guardador

    Property AccesoBD As AccesoBD.BD
    Property SqlCommand As SqlClient.SqlCommand
    Property indiceParametro As Integer

    Sub New(ParamAccesoBD As AccesoBD.BD)

        
        AccesoBD = ParamAccesoBD

        SqlCommand = New SqlClient.SqlCommand
        SqlCommand.CommandType = CommandType.Text
        SqlCommand.CommandText = "BEGIN TRY BEGIN TRANSACTION " & _
            "declare @posicionError varchar(35) " & _
            "declare @mensajeError varchar(300) " & _
            "set @posicionError = 'Error ' "

        indiceParametro = 0
    End Sub

    Public Sub guardar()

        SqlCommand.CommandText &= " COMMIT " & _
                            "END TRY " & _
                            "BEGIN CATCH " & _
                            "select @mensajeError = ERROR_MESSAGE() " & _
                            "IF @@TRANCOUNT > 0 " & _
                            "ROLLBACK " & _
                            "RAISERROR(@mensajeError,16,1) " & _
                            "RAISERROR(@posicionError,16,1) " & _
                            "END CATCH"

        AccesoBD.ejecutarNonQuery(SqlCommand)
    End Sub
End Class
