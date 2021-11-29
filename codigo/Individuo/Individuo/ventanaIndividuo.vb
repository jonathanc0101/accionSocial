Public Class ventanaIndividuo
    Private individuo As ObjetosDeNegocio.Individuo
    
    Public Sub New(paramIndividuo As ObjetosDeNegocio.Individuo)
        Me.New()

        Me.individuo = paramIndividuo

    End Sub
    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        DeshabilitarCampos()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub ventanaIndividuo_Load(sender As Object, e As EventArgs) Handles Me.Load
        individuo.cargarCompletoPorDni(individuo.Dni)

        mostrarDatosEnPantalla()
        cargarListados()
    End Sub


#Region "metodos"

    Private Sub setearTitulo()
        Me.Text = individuo.ApellidoNombre & " - DNI:" & individuo.Dni
    End Sub


    Private Sub mostrarDatosEnPantalla()
        'titulo
        setearTitulo()

        'metodo que coloca los datos del individuo y grupo familiar en pantalla (textboxes)
        TextBoxApellidoYNombre.Text = individuo.ApellidoNombre
        TextBoxDni.Text = individuo.Dni
        TextBoxTelefono.Text = individuo.Telefono
        TextBoxEmail.Text = individuo.Email
        TextBoxObservaciones.Text = individuo.Descripcion

        If individuo.FDefuncion = Nothing Then
            'se oculta el datetimepicker en caso de que no haya fallecido el individuo
            LabelFechaDeDefuncion.Hide()
            DateTimePickerFechaDefuncion.Hide()

        Else
            'en caso de que si haya fallecido se muestra el dato cargado en el individuo
            LabelFechaDeDefuncion.Show()
            DateTimePickerFechaDefuncion.Show()
            DateTimePickerFechaDefuncion.Value = individuo.FDefuncion
        End If
        DateTimePickerFechaNacimiento.Value = individuo.FNacimiento

        TextBoxEdad.Text = individuo.Edad

        If individuo.Sexo = "F" Then
            ComboBoxSexo.SelectedIndex = ComboBoxSexo.FindStringExact("Femenino")
        ElseIf individuo.Sexo = "M" Then
            ComboBoxSexo.SelectedIndex = ComboBoxSexo.FindStringExact("Masculino")
        Else
            ComboBoxSexo.SelectedIndex = ComboBoxSexo.FindStringExact("Otro")
        End If

        'datos del grupo conviviente
        TextBoxDireccion.Text = individuo.grupoConviviente.Domicilio
        TextBoxIdGrupo.Text = individuo.IdGrupo
        TextBoxBarrio.Text = individuo.grupoConviviente.Barrio
        TextBoxReferencia.Text = individuo.grupoConviviente.Referencia
    End Sub

    Private Sub cargarListados()
        IndividuoBindingSource.DataSource = individuo.grupoConviviente.Individuos
        AccionBindingSource.DataSource = individuo.grupoConviviente.AccionesIndividuos
        InformeBindingSource.DataSource = individuo.grupoConviviente.InformesIndividuos
    End Sub
    Private Sub DeshabilitarCampos()
        TextBoxDni.Enabled = False
        ComboBoxSexo.Enabled = False
        DateTimePickerFechaNacimiento.Enabled = False
        DateTimePickerFechaDefuncion.Enabled = False
        TextBoxEmail.Enabled = False
        TextBoxTelefono.Enabled = False
        TextBoxObservaciones.Enabled = False             ' Se coloco en el formulario como observaciones
        TextBoxApellidoYNombre.Enabled = False
        TextBoxEdad.Enabled = False

        TextBoxDireccion.Enabled = False
        TextBoxBarrio.Enabled = False
        TextBoxReferencia.Enabled = False
        TextBoxIdGrupo.Enabled = False
    End Sub

    Private Sub cargarIndividuo(paramDni As String)
        Me.individuo.cargarCompletoPorDni(paramDni)

        actualizar()
    End Sub

    Private Function obtenerDniFilaSeleccionada() As String
        Return DataGridViewGrupoConviviente.SelectedRows(0).Cells("Dni").Value
    End Function

    Private Sub actualizar()
        mostrarDatosEnPantalla()
        cargarListados()
        Me.Refresh()
    End Sub

    Private Sub cargarIndividuoPorTextBoxDni()
        Try
            If TextBoxDni.Text.Length < 7 Then
                Throw New Exception("La longitud del DNI ingresada es menor a 7 dígitos.")
            End If

            cargarIndividuo(TextBoxDni.Text)
        Catch ex As Exception
            'si no se tiene en foco la ventana entonces no se hace nada.
            If Me.ContainsFocus Then
                MsgBox("El DNI no se encuentra registrado en la Base de Datos.")
                'colocamos el dni actual
                TextBoxDni.Text = individuo.Dni
            End If
        End Try
    End Sub

#End Region

#Region "eventos"


    Private Sub apellidoYNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxApellidoYNombre.KeyPress
        ' Verifica que el Apellido y Nombre sea letras mayusculas y minusculas, espacios, coma, y el apóstrofo para apellidos
        Dim condicion As Boolean
        condicion = (((e.KeyChar >= "A") And (e.KeyChar <= "z")) Or (e.KeyChar = " ") Or (e.KeyChar = ",") Or (e.KeyChar = "'")) And Not Char.IsControl(e.KeyChar) And Not (e.KeyChar.Equals(Asc(13)))

        e.Handled = Not condicion
        If Not condicion Then
            MsgBox("El Apellido y Nombre sólo contiene letras, coma y apóstrofo")
        End If

    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub ventanaIndividuo_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        'salir
        If e.KeyData = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewGrupoConviviente.CellDoubleClick
        'carga individuo
        If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
            cargarIndividuo(obtenerDniFilaSeleccionada())
        End If
    End Sub

    Private Sub TextBoxDni_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxDni.KeyDown
        If e.KeyData = Keys.Enter Then
            'quitamos el handler del evento lostfocus para que no se solapen las interacciones
            RemoveHandler TextBoxDni.LostFocus, AddressOf TextBoxDni_LostFocus

            cargarIndividuoPorTextBoxDni()

            'añadimos el handler del evento lostfocus para que se pueda continuar con la ejecucion
            AddHandler TextBoxDni.LostFocus, AddressOf TextBoxDni_LostFocus
        End If
    End Sub

    Private Sub TextBoxDni_LostFocus(sender As Object, e As EventArgs) Handles TextBoxDni.LostFocus
        cargarIndividuoPorTextBoxDni()
    End Sub
    Private Sub DNI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxDni.KeyPress
        ' Verifica que el DNI sea sólo números. Excluye los puntos. Solo numeros

        'quitamos el handler del evento lostfocus para que no se solapen las interacciones
        RemoveHandler TextBoxDni.LostFocus, AddressOf TextBoxDni_LostFocus

        Dim condicion As Boolean
        condicion = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)

        e.Handled = condicion
        If condicion Then
            MsgBox("El DNI sólo tiene números")
        End If

        'añadimos el handler del evento lostfocus para que se pueda continuar con la ejecucion
        AddHandler TextBoxDni.LostFocus, AddressOf TextBoxDni_LostFocus
    End Sub

    Private Sub NuevoInformeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoInformeToolStripMenuItem.Click
        Dim ventanaInforme As New ventanaInforme(Me.individuo)

        ventanaInforme.ShowDialog()

        'en caso de que haya cambios se carga de vuelta el individuo y se actualiza todo
        cargarIndividuo(Me.individuo.Dni)
        actualizar()
    End Sub

    Private Sub NuevaAccionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevaAccionToolStripMenuItem.Click
        Dim venAccion As ventanaAccion
        venAccion = New ventanaAccion(Me.individuo)

        venAccion.ShowDialog()

        'en caso de que haya cambios se carga de vuelta el individuo y se actualiza todo
        cargarIndividuo(Me.individuo.Dni)
        actualizar()

    End Sub
#End Region






End Class










