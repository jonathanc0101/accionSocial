Imports System.Data.SqlClient
Public Class BD
    Private CnnStr As String

    Public Sub New(direccionMiServer As String, miBD As String, miUsuario As String, miContrasenia As String)
        CnnStr = "Server=" & direccionMiServer & ";" _
            & "Database=" & miBD & ";" _
            & "Uid=" & miUsuario & ";" _
            & "Pwd=" & miContrasenia & ";"

    End Sub

    Public Function EjecutarScalar(query As String)
        Try
            Dim conexion As New SqlConnection(Me.CnnStr)
            Dim comando As New SqlCommand
            conexion.Open()

            comando = New SqlCommand(query)

            comando.Connection = conexion
            comando.CommandTimeout = 300
            Dim resultado As String
            resultado = comando.ExecuteScalar()

            conexion.Close()

            Return resultado
        Catch ex As Exception
            Throw New Exception("Error al ejecutar método EjecutarScalar." & vbCrLf & ex.Message)
        End Try
    End Function
    Public Function obtenerDatos(query As String) As DataTable

        Dim DT As New DataTable

        Try
            Using cnn As New SqlConnection(Me.CnnStr)
                cnn.Open()
                Using dad As New SqlDataAdapter(query, cnn)
                    dad.Fill(DT)
                End Using
                cnn.Close()
            End Using
        Catch ex As Exception
            Throw New Exception("Error al ejecutar método ObtenerDatos." & vbCrLf & ex.Message)
        End Try

        Return DT

    End Function

    Public Sub ejecutarNonQuery(comando As SqlCommand)
        Dim conexion As New SqlConnection(Me.CnnStr)
        comando.Connection = conexion
        Try
            conexion.Open()
            comando.ExecuteNonQuery()
            conexion.Close()
        Catch ex As Exception
            Throw New Exception("Error al ejecutar método ejecutarNonQuery." & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Sub ejecutarNonQuery(query As String)
        Dim conexion As New SqlConnection(Me.CnnStr)
        Dim comando As New SqlCommand
        comando.Connection = conexion
        comando.CommandText = query
        Try
            conexion.Open()
            comando.ExecuteNonQuery()
            conexion.Close()
        Catch ex As Exception
            Throw New Exception("Error al ejecutar método ejecutarNonQuery." & vbCrLf & ex.Message)
        End Try
    End Sub

    Public Function obtenerDatos(comando As SqlCommand) As DataTable
        Dim dt As New DataTable
        Dim conexion As New SqlConnection(Me.CnnStr)
        comando.Connection = conexion
        comando.CommandTimeout = 300
        Dim adapter As New SqlDataAdapter(comando)
        Try
            conexion.Open()
            adapter.Fill(dt)
        Catch ex As Exception
            Throw New Exception("Error al ejecutar método obtenerDatos." & vbCrLf & ex.Message)
        Finally
            conexion.Close()
        End Try
        Return dt
    End Function

    Public Function obtenerUltimoIDInsertado() As Integer
        Return obtenerDatos("SELECT last_insert_id()").Rows(0).Item(0)
    End Function
End Class
