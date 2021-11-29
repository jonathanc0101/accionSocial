
Imports ObjetosDeNegocio

Public Class ventanaListado

    Private individuos As ObjetosDeNegocio.Individuos
    Private listaFiltrada As ObjetosDeNegocio.SortableBindingList(Of ObjetosDeNegocio.Individuo)

    Private accesoADatos As BDAccesoATablas

    Sub New()

        If My.Computer.Name = "PSSERVER" Then
            'si estamos en el servidor se carga este objeto individuo
            individuos = New ObjetosDeNegocio.Individuos("PSSERVER\LABORATORIO2021", "SOCIALESQUEL", "sa", "Lab2021")
            accesoADatos = New BDAccesoATablas("PSSERVER\LABORATORIO2021", "SOCIALESQUEL", "sa", "Lab2021")
        ElseIf My.Computer.Name = "ARTURO-PC" Then
            'si estamos en la pc de Arturo se carga este objeto individuo
            individuos = New ObjetosDeNegocio.Individuos("ARTURO-PC", "SOCIALESQUEL", "sa", "123")
            accesoADatos = New BDAccesoATablas("ARTURO-PC", "SOCIALESQUEL", "sa", "123")
        ElseIf My.Computer.Name = "JONATHAN-PC" Then
            'si estamos en la pc de Jonathan se carga este objeto individuo
            individuos = New ObjetosDeNegocio.Individuos("JONATHAN-PC\SQLEXPRESS", "SOCIALESQUEL", "sa", "sa123")
            accesoADatos = New BDAccesoATablas("JONATHAN-PC\SQLEXPRESS", "SOCIALESQUEL", "sa", "sa123")
        End If
        ' Llamada necesaria para el diseñador.


        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub venListado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Individuos/as"

        individuos.cargarListado()
        listaFiltrada = individuos.listado
        ObjetosBindingSource.DataSource = listaFiltrada

    End Sub

#Region "Metodos"

    '
    ' Abre ventana para MUESTRA DEL INDIVIDUO
    '

    Private Sub abrirVentanaNuevoIndividuo()
        Dim individuoAux As ObjetosDeNegocio.Individuo = individuos.nuevoIndividuoVacio()
        Dim ventanaIndividuoNuevo As New ventanaIndividuoNuevo(individuoAux)
        ventanaIndividuoNuevo.Show()

        'para que cuando se cierre el formulario se actualice el listado
        AddHandler ventanaIndividuoNuevo.FormClosed, AddressOf actualizar

    End Sub

    '
    '   Apertura de Nuevo Individuo en  el MISMO GRUPO FAMILIAR
    '
    Private Sub abrirVentanaNuevoIndividuoGrupo()
        If grilla.SelectedRows.Count = 1 Then
            abrirVentanaIndividuoGrupoPorId(grilla.SelectedRows(0).Cells("IdIndividuoDataGridViewTextBoxColumn").Value)
        End If
    End Sub

    Private Sub abrirVentanaIndividuoGrupoPorId(idIndividuo As Integer)
        Dim individuoAux As ObjetosDeNegocio.Individuo

        individuoAux = individuos.listado.Find("idIndividuo", idIndividuo)

        Dim ventanaIndividuoNuevoGrupo As New ventanaIndividuoNuevoGrupo(individuoAux)

        ventanaIndividuoNuevoGrupo.Show()

    End Sub

    '
    '
    '
    Private Sub buscar()

        listaFiltrada = New ObjetosDeNegocio.SortableBindingList(Of ObjetosDeNegocio.Individuo)

        If CustomTextBoxBuscador.Text = "" Then
            listaFiltrada.AddRange(individuos.listado)
        Else
            listaFiltrada.AddRange(individuos.listado.Where(Function(x) x.ApellidoNombre.ToLower Like "*" & CustomTextBoxBuscador.Text.ToLower & "*" Or _
                                                               x.Descripcion.ToLower Like "*" & CustomTextBoxBuscador.Text.ToLower & "*" Or _
                                                               x.Domicilio.ToLower Like "*" & CustomTextBoxBuscador.Text.ToLower & "*" Or _
                                                               x.Dni.ToLower Like "*" & CustomTextBoxBuscador.Text.ToLower & "*" Or _
                                                               x.Edad.ToString.ToLower Like "*" & CustomTextBoxBuscador.Text.ToLower & "*" Or _
                                                               x.FNacimiento.ToLongDateString.ToLower Like "*" & CustomTextBoxBuscador.Text.ToLower & "*" Or _
                                                               x.Sexo.ToLower Like "*" & CustomTextBoxBuscador.Text.ToLower & "*" Or _
                                                               x.Telefono.ToLower Like "*" & CustomTextBoxBuscador.Text.ToLower & "*"
                                                                    ).ToList)
        End If

        ObjetosBindingSource.DataSource = listaFiltrada

    End Sub

    Private Sub abrirRegistro()
        If grilla.SelectedRows.Count = 1 Then
            abrirVentanaIndividuoPorId(grilla.SelectedRows(0).Cells("IdIndividuoDataGridViewTextBoxColumn").Value)
        End If
    End Sub

    Private Sub abrirVentanaIndividuoPorId(idIndividuo As Integer)
        Dim individuoAux As ObjetosDeNegocio.Individuo

        individuoAux = individuos.listado.Find("idIndividuo", idIndividuo)

        Dim ventanaIndividuo As New ventanaIndividuo(individuoAux)

        ventanaIndividuo.Show()

    End Sub

    Private Sub actualizar()

        Me.Cursor = Cursors.WaitCursor

        ObjetosBindingSource.DataSource = Nothing

        individuos.cargarListado()
        listaFiltrada = individuos.listado

        ObjetosBindingSource.DataSource = listaFiltrada

        If CustomTextBoxBuscador.Text <> "" Then
            buscar()
        End If

        Me.Refresh()

        Me.Cursor = Cursors.Default
    End Sub

#End Region

#Region "Eventos"

    Private Sub venListado_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyData = Keys.Escape Then
            Me.Close()
        End If
    End Sub
    Private Sub CustomTextBoxBuscador_TextChanged(sender As Object, e As EventArgs) Handles CustomTextBoxBuscador.TextChanged
        TimerBuscador.Stop()
        TimerBuscador.Start()
    End Sub

    Private Sub TimerBuscador_Tick(sender As Object, e As EventArgs) Handles TimerBuscador.Tick
        buscar()
        TimerBuscador.Stop()
    End Sub

   
    '
    '  Menu de contexto en el data grid
    '
    Private Sub AbrirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbrirToolStripMenuItem.Click
        abrirRegistro()
    End Sub

    Private Sub NuevoIndividuoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoIndividuoToolStripMenuItem.Click
        abrirVentanaNuevoIndividuo()
    End Sub

    Private Sub NuevoIndivEnElMismoDomicilioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoIndivEnElMismoDomicilioToolStripMenuItem.Click

        abrirVentanaNuevoIndividuoGrupo()
    End Sub


    Private Function obtenerID() As Integer
        Return Me.grilla.CurrentRow.Cells("idIndividuo").Value
    End Function


    Private Sub CustomDataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles grilla.KeyDown
        If e.KeyData = Keys.Enter Then
            e.SuppressKeyPress = True
            abrirRegistro()
        End If


        If e.KeyData = Keys.Up Or e.KeyData = Keys.Down Then
            Dim rpos As Integer = grilla.SelectedRows(0).Index
            'movimiento por el datagrid con las flechas up y down

            If (e.KeyCode = Keys.Up) Then
                rpos -= 1
                If (rpos >= 0) Then
                    grilla.Rows(rpos).Selected = True
                End If
                e.Handled = True
            ElseIf (e.KeyCode = Keys.Down) Then
                rpos += 1
                If (rpos < grilla.Rows.Count) Then
                    grilla.Rows(rpos).Selected = True
                End If
                e.Handled = True
            End If

            If rpos < grilla.Rows.Count And rpos > 0 Then
                grilla.FirstDisplayedScrollingRowIndex = rpos
            End If
        End If
    End Sub

    Private Sub ActualizarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizarToolStripMenuItem.Click
        actualizar()
    End Sub

    Private Sub grilla_DoubleClick(sender As Object, e As EventArgs) Handles grilla.CellMouseDoubleClick
        abrirRegistro()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub


#End Region



End Class