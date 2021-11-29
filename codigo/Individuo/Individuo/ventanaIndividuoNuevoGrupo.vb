Public Class ventanaIndividuoNuevoGrupo
    ' El objeto Individuo reaprovecha la información del 

    Private individuo As ObjetosDeNegocio.Individuo

    Private individuoExistente As ObjetosDeNegocio.Individuo

    Private idIndividuoExistente As Integer

    ' Private idIndividuoExistente As Integer


    Private Property titulo As String
    Private Property cambios As Boolean
    Private Property guardo As Boolean = False

    Public Event cambiosIndividuos()

    Public Sub New(paramIndividuoExistente As ObjetosDeNegocio.Individuo)
        Me.New()

        Me.individuo = paramIndividuoExistente.InstanciarIndividuoNuevoEnGrupoConviviente()
        individuoExistente = paramIndividuoExistente    'se carga el individuo existente

        idIndividuoExistente = individuo.IdIndividuo

    End Sub
    Public Sub New()

        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        HabilitarTodosLosCampos(False)

    End Sub

    Private Sub ventanaIndividuo_Load(sender As Object, e As EventArgs) Handles Me.Load
        setearTitulo()

        'prepararNuevoIndividuoFamiliar()              ' Prepara el objeto Individuo para aceptar el nuevo familiar desde quien accedió

        tratarDeMostrarIndividuo()
        sinCambioshechos()
        aniadirHandlersCambiosHechos()
        habilitarComboboxesRelacion(habilitadas:=False)

        'prepararNuevoIndividuoFamiliar()


    End Sub


#Region "metodos"

    Private Sub setearTitulo()
        titulo = "Nuevo Individuo en el grupo familiar de: " & individuoExistente.ApellidoNombre & " - DNI:" & individuoExistente.Dni
    End Sub
    Private Sub tratarDeMostrarIndividuo()
        mostrarDatosEnPantalla()
        cargarListados()
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

        'datos del grupo conviviente
        TextBoxIdGrupo.Text = individuo.IdGrupo
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

    End Sub
    Private Sub cargarListados()
        IndividuoBindingSource.DataSource = individuo.grupoConviviente.Individuos
        AccionBindingSource.DataSource = individuo.grupoConviviente.AccionesIndividuos
        InformeBindingSource.DataSource = individuo.grupoConviviente.InformesIndividuos
    End Sub
    Private Sub HabilitarTodosLosCampos(habilitados As Boolean)

        habilitarCamposIndividuo(habilitados)
        habilitarCamposGrupoFamiliar(habilitados)

    End Sub
    Private Sub habilitarCamposGrupoFamiliar(habilitados As Boolean)
        'datos del grupo familiar
        TextBoxIdGrupo.Enabled = habilitados
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

    Private Sub habilitarComboboxesRelacion(habilitadas As Boolean)
        DataGridViewTextBoxColumnComboboxRelacion.ReadOnly = Not habilitadas
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
                        habilitarCamposIndividuo(True)
                        habilitarComboboxesRelacion(habilitadas:=True)
                        TextBoxApellidoYNombre.Select()
                    End If
                End If
            End If
        End If
    End Sub


    Private Function valoresValidosIndividuo() As Boolean

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


        Return True

    End Function

    Function valoresValidosGrupoFamiliar() As Boolean
        
        Dim indivAux As ObjetosDeNegocio.Individuo

        For Each indivAux In individuo.grupoConviviente.Individuos
            If (indivAux.Relacion = "") Then
                MsgBox("Ingrese la totalidad de los vinculos familiares", MsgBoxStyle.Information)
                Return False
            End If
        Next

        Return True
    End Function
    Function valoresValidos() As Boolean
        If Not valoresValidosIndividuo() Then
            Return False
        End If

        If Not valoresValidosGrupoFamiliar() Then
            Return False
        End If

        Return True

    End Function
    Private Sub GuardarIndividuo()

        If valoresValidos() Then
            If cambios Then
                meterDatosEnRegistro()
                Try
                    Dim ventanaGuardar As New venGuardandoConVinculos(individuo)
                    'guardarvinculos
                    ventanaGuardar.ShowDialog()
                    guardo = ventanaGuardar.Guardado

                    If guardo Then
                        sinCambioshechos()
                        Me.Close()
                    Else
                        MessageBox.Show("No se puede guardar el Individuo", "Individuo", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        meterDatosEnRegistro()
                    End If

                Catch ex As Exception
                    Throw New Exception(ex.Message & " Individuo")
                End Try
            Else
                MsgBox("No hay cambios hechos.")
            End If
      
        End If

    End Sub

#End Region
#Region "eventos"

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
            habilitarComboboxesRelacion(False)
        End If
    End Sub

    ' Guarda los vinculos familiares del individuo ... con la persona recien ingresada
    Private Sub ButtonGuardar_Click(sender As Object, e As EventArgs) Handles ButtonGuardar.Click
        GuardarIndividuo()
    End Sub


#End Region



End Class










