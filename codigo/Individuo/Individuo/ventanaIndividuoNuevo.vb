Public Class ventanaIndividuoNuevo
    Private individuo As ObjetosDeNegocio.Individuo

    Private Property titulo As String
    Private Property cambios As Boolean
    Private Property guardo As Boolean = False

    Public Event cambiosIndividuos()

    Public Sub New(paramIndividuo As ObjetosDeNegocio.Individuo)
        Me.New()

        Me.individuo = paramIndividuo

    End Sub
    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        HabilitarTodosLosCampos(False)
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub ventanaIndividuo_Load(sender As Object, e As EventArgs) Handles Me.Load
        tratarDeMostrarIndividuo()
        setearTitulo()
        sinCambioshechos()
        aniadirHandlersCambiosHechos()
    End Sub


#Region "metodos"
    Private Sub tratarDeMostrarIndividuo()
        If individuo.IdIndividuo <> 0 Then
            individuo.cargarCompletoPorDni(individuo.Dni)
            mostrarDatosEnPantalla()
            cargarListados()
        End If
    End Sub
    Private Sub aniadirHandlersCambiosHechos()
        'cambios del individuo
        If individuo.IdIndividuo <> 0 Then
            AddHandler TextBoxDni.TextChanged, AddressOf cambiosHechos
        End If
        AddHandler TextBoxApellidoYNombre.TextChanged, AddressOf cambiosHechos
        AddHandler TextBoxTelefono.TextChanged, AddressOf cambiosHechos
        AddHandler TextBoxEmail.TextChanged, AddressOf cambiosHechos
        AddHandler TextBoxObservaciones.TextChanged, AddressOf cambiosHechos
        AddHandler DateTimePickerFechaDefuncion.ValueChanged, AddressOf cambiosHechos
        AddHandler DateTimePickerFechaNacimiento.ValueChanged, AddressOf cambiosHechos
        AddHandler ComboBoxSexo.TextChanged, AddressOf cambiosHechos
        'cambios del grupo conviviente
        AddHandler TextBoxDireccion.TextChanged, AddressOf cambiosHechos
        AddHandler TextBoxBarrio.TextChanged, AddressOf cambiosHechos
        AddHandler TextBoxReferencia.TextChanged, AddressOf cambiosHechos
    End Sub
    Private Sub setearTitulo()
        If individuo.IdIndividuo = 0 Then
            titulo = "Nuevo" & " - " & "individuo"
        Else
            titulo = individuo.ApellidoNombre & " - DNI:" & individuo.Dni
        End If
    End Sub
    Private Sub cambiosHechos()
        cambios = True
        Me.Text = titulo & "*"
    End Sub
    Private Sub sinCambioshechos()
        cambios = False
        Me.Text = titulo
    End Sub
    Private Sub mostrarDatosEnPantalla()
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


        If individuo.Sexo = "F" Then
            ComboBoxSexo.SelectedIndex = ComboBoxSexo.FindStringExact("Femenino")
        ElseIf individuo.Sexo = "M" Then
            ComboBoxSexo.SelectedIndex = ComboBoxSexo.FindStringExact("Masculino")
        End If

        'datos del grupo conviviente
        TextBoxDireccion.Text = individuo.grupoConviviente.Domicilio
        TextBoxBarrio.Text = individuo.grupoConviviente.Barrio
        TextBoxReferencia.Text = individuo.grupoConviviente.Referencia
    End Sub
    Private Sub meterDatosEnRegistro()
        'metodo que coloca los datos de pantalla en el registro
        individuo.ApellidoNombre = TextBoxApellidoYNombre.Text
        individuo.Dni = TextBoxDni.Text
        individuo.Telefono = TextBoxTelefono.Text
        individuo.Email = TextBoxEmail.Text
        individuo.Descripcion = TextBoxObservaciones.Text

        If CheckBoxDifunto.Checked Then
            individuo.FDefuncion = DateTimePickerFechaDefuncion.Value
        End If

        individuo.FNacimiento = DateTimePickerFechaNacimiento.Value


        If ComboBoxSexo.SelectedIndex = 0 Then
            individuo.Sexo = "F"
        ElseIf ComboBoxSexo.SelectedIndex = 1 Then
            individuo.Sexo = "M"
        End If

        'los datos del grupo conviviente no se modifican aca
        individuo.grupoConviviente.Barrio = TextBoxBarrio.Text
        individuo.grupoConviviente.Domicilio = TextBoxDireccion.Text
        individuo.grupoConviviente.Referencia = TextBoxReferencia.Text
    End Sub
    Private Sub cargarListados()
        If individuo.IdIndividuo <> 0 Then
            IndividuoBindingSource.DataSource = individuo.grupoConviviente.Individuos
            AccionBindingSource.DataSource = individuo.grupoConviviente.AccionesIndividuos
            InformeBindingSource.DataSource = individuo.grupoConviviente.InformesIndividuos
        End If
    End Sub
    Private Sub HabilitarTodosLosCampos(habilitados As Boolean)
        habilitarCamposIndividuo(habilitados)
        habilitarCamposGrupoFamiliar(habilitados)
    End Sub
    Private Sub habilitarCamposGrupoFamiliar(habilitados As Boolean)
        'datos del grupo familiar
        TextBoxDireccion.Enabled = habilitados
        TextBoxBarrio.Enabled = habilitados
        TextBoxReferencia.Enabled = habilitados
    End Sub
    Private Sub habilitarCamposIndividuo(habilitados As Boolean)
        'datos del individuo
        ComboBoxSexo.Enabled = habilitados
        DateTimePickerFechaNacimiento.Enabled = habilitados

        CheckBoxDifunto.Enabled = habilitados
        cambiarEstadoDefuncion(CheckBoxDifunto.Checked)

        TextBoxEmail.Enabled = habilitados
        TextBoxTelefono.Enabled = habilitados
        TextBoxObservaciones.Enabled = habilitados    ' Se coloco en el formulario como observaciones
        TextBoxApellidoYNombre.Enabled = habilitados
    End Sub
    Private Sub cambiarEstadoDefuncion(habilitar As Boolean)
        If Not habilitar Then
            DateTimePickerFechaDefuncion.Hide()
            LabelFechaDeDefuncion.Hide()
        Else
            DateTimePickerFechaDefuncion.Show()
            LabelFechaDeDefuncion.Show()
        End If
        DateTimePickerFechaDefuncion.Enabled = habilitar
        LabelFechaDeDefuncion.Enabled = habilitar

    End Sub
    Private Sub cargarIndividuo(paramDni As String)
        Me.individuo.cargarCompletoPorDni(paramDni)
        mostrarDatosEnPantalla()

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

    Private Sub verificarTextBoxDNIValido()
        If Me.ContainsFocus = True Then
            If TextBoxDni.Text <> "" Then

                If TextBoxDni.Text.Length < 8 Then
                    MsgBox("La longitud del DNI ingresada debe ser mayor o igual a 8 dígitos.", MsgBoxStyle.Information)
                Else
                    If individuo.existeDNI(TextBoxDni.Text) Then
                        MsgBox("El DNI existe en la base de datos.", MsgBoxStyle.Information)
                    Else
                        TextBoxDni.Enabled = False
                        HabilitarTodosLosCampos(True)
                        TextBoxApellidoYNombre.Select()
                    End If
                End If
            End If
        End If
    End Sub


    Private Function valoresValidos() As Boolean

        If (TextBoxApellidoYNombre.TextLength < 5) Then
            MsgBox("El Apellido y Nombre debe tener al menos  5 caracteres", MsgBoxStyle.Information)
            Return False
        End If

        If Not (ComboBoxSexo.SelectedIndex = 0 Or ComboBoxSexo.SelectedIndex = 1) Then
            MsgBox("Dese seleccionar el campo Sexo", MsgBoxStyle.Information)
            Return False
        End If

        If (DateTimePickerFechaNacimiento.Value = Nothing) Then
            MsgBox("Coloque una fecha de nacimiento", MsgBoxStyle.Information)
            Return False
        End If

        If (DateTimePickerFechaNacimiento.Value > Date.Now) Then     ' verifica que la fecha de nacimniento sea anterior al dia de hoy
            MsgBox("La fecha de nacimiento es incorrecta", MsgBoxStyle.Information)
            Return False
        End If

        If TextBoxEmail.TextLength > 0 Then
            If Not TextBoxEmail.Text.Contains("@") Then
                MsgBox("Escriba correctamente el email", MsgBoxStyle.Information)
                Return False
            End If
        End If


        If (CheckBoxDifunto.Checked) Then
            If (DateTimePickerFechaDefuncion.Value < DateTimePickerFechaNacimiento.Value) Then
                MsgBox("Fecha de defuncion MAYOR a la fecha de NACIMIENTO", MsgBoxStyle.Information)
                Return False
            End If
        End If


        If (TextBoxDireccion.TextLength < 3) Then
            MsgBox("La direccion debe tener como minimo  3 caracteres", MsgBoxStyle.Information)
            Return False
        End If

        If (TextBoxBarrio.TextLength < 3) Then
            MsgBox("El barrio debe tener como minimo 3 caracteres", MsgBoxStyle.Information)
            Return False
        End If


        Return True

    End Function
    Private Sub Guardar()
        If valoresValidos() Then
            If cambios Then
                meterDatosEnRegistro()
                Try
                    Dim ventanaGuardar As New venGuardando(individuo)
                    ventanaGuardar.ShowDialog()
                    guardo = ventanaGuardar.Guardado

                    If guardo Then
                        setearTitulo()
                        sinCambioshechos()

                        tratarDeMostrarIndividuo()
                        Me.Close()

                        RaiseEvent cambiosIndividuos()
                    Else
                        MessageBox.Show("No se puede guardar el Individuo", "Individuo", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        meterDatosEnRegistro()
                    End If

                Catch ex As Exception
                    Throw New Exception(ex.Message & " Individuo")
                End Try
            Else
                Me.Close()
            End If
        End If
    End Sub

#End Region
#Region "eventos"
    Private Sub ButtonGuardar_Click(sender As Object, e As EventArgs) Handles ButtonGuardar.Click
        guardar()
    End Sub

    Private Sub apellidoYNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxApellidoYNombre.KeyPress
        ' Verifica que el Apellido y Nombre sea letras mayusculas y minusculas, espacios, coma, y el apóstrofo para apellidos
        Dim condicion As Boolean
        condicion = ((e.KeyChar >= "A") And (e.KeyChar <= "Z"))
        condicion = condicion Or ((e.KeyChar >= "a") And (e.KeyChar <= "z"))
        condicion = condicion Or (e.KeyChar = " ") Or (e.KeyChar = ",") Or (e.KeyChar = "'") Or (e.KeyChar = "ñ") Or (e.KeyChar = "Ñ")
        condicion = condicion Or Char.IsControl(e.KeyChar)

        'And Not Char.IsControl(e.KeyChar) And Not e.KeyChar.Equals(Asc(13)) And Not e.KeyChar.Equals(Asc(8))

        e.Handled = Not condicion
        If Not condicion Then
            MsgBox("El Apellido y Nombre sólo contiene letras, coma y apóstrofo")
        End If

    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub ventanaIndividuo_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Dim respMsg As MsgBoxResult

        ' Está en modo de edición el individuo, con un DNI ingresado  nuevo
        If e.KeyData = Keys.Escape Then
            If cambios Then
                respMsg = MsgBox("¿Desea salir del formulario? Los cambios sin guardar se perderán", MsgBoxStyle.YesNo)
                If respMsg = MsgBoxResult.Yes Then
                    Me.Close()
                End If
            Else
                Me.Close()
            End If
        End If
    End Sub


    Private Sub TextBoxDni_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxDni.KeyDown
        If e.KeyData = Keys.Enter Then
            'quitamos el handler del evento lostfocus para que no se solapen las interacciones
            RemoveHandler TextBoxDni.LostFocus, AddressOf TextBoxDni_LostFocus

            verificarTextBoxDNIValido()

            'añadimos el handler del evento lostfocus para que se pueda continuar con la ejecucion
            AddHandler TextBoxDni.LostFocus, AddressOf TextBoxDni_LostFocus
        End If
    End Sub

    Private Sub TextBoxDni_LostFocus(sender As Object, e As EventArgs) Handles TextBoxDni.LostFocus
        verificarTextBoxDNIValido()
    End Sub

    Private Sub DNI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBoxDni.KeyPress
        ' Verifica que el DNI sea sólo números. Excluye los puntos. Solo numeros

        'quitamos el handler del evento lostfocus para que no se solapen las interacciones
        RemoveHandler TextBoxDni.LostFocus, AddressOf TextBoxDni_LostFocus

        Dim condicion As Boolean
        condicion = Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar)

        e.Handled = condicion

        'añadimos el handler del evento lostfocus para que se pueda continuar con la ejecucion
        AddHandler TextBoxDni.LostFocus, AddressOf TextBoxDni_LostFocus
    End Sub

    Private Sub CheckBoxDifunto_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxDifunto.CheckedChanged
        cambiarEstadoDefuncion(habilitar:=CheckBoxDifunto.Checked)
    End Sub

    Private Sub ButtonCancelar_Click(sender As Object, e As EventArgs) Handles ButtonCancelar.Click
        Me.Close()
    End Sub

    Private Sub EditarDNIToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarDNIToolStripMenuItem.Click
        If Not TextBoxDni.Enabled Then
            TextBoxDni.Enabled = True
            TextBoxDni.Focus()
            HabilitarTodosLosCampos(False)

        End If
    End Sub


#End Region

End Class










