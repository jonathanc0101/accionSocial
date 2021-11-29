
Imports ObjetosDeNegocio

Public Class venGuardandoConVinculos

    Private registro As ObjetosDeNegocio.Individuo
    Property Guardado As Boolean = False

    Public Sub New(ByRef ParamRegistro As ObjetosDeNegocio.Individuo)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        registro = ParamRegistro

    End Sub

    Private Sub VenGuardar_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Me.Refresh()

        Try
            registro.guardarConVinculos()

            Guardado = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Individuo", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Finally
            Me.Close()
        End Try
    End Sub


End Class
