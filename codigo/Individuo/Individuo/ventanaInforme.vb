Public Class ventanaInforme
    Private individuo As ObjetosDeNegocio.Individuo

    Public Sub New(ByRef ParamIndividuo As ObjetosDeNegocio.Individuo)

        ' Llamada necesaria para el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Me.individuo = ParamIndividuo
    End Sub

    Private Sub guardar()
        If valoresValidos() Then
            individuo.guardarNuevoInforme(TextBoxAgente.Text,
                                          TextBoxOficina.Text,
                                          DateTimePickerFecha.Value,
                                          TextBoxDescripcion.Text)
        Else
            MessageBox.Show("Por favor vuelva a comprobar los campos: agente, oficina, y descripción.")
        End If

        Me.Close()
    End Sub

    Private Function valoresValidos() As Boolean
        Return TextBoxAgente.Text.Length > 0 And TextBoxOficina.Text.Length > 0 And TextBoxDescripcion.Text.Length > 0
    End Function

#Region "eventos"
    Private Sub ButtonGuardar_Click(sender As Object, e As EventArgs) Handles ButtonGuardar.Click
        guardar()
    End Sub

    Private Sub ButtonCancelar_Click(sender As Object, e As EventArgs) Handles ButtonCancelar.Click
        Me.Close()
    End Sub

#End Region

End Class