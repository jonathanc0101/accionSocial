<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ventanaListado
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ventanaListado))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActualizarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.grilla = New System.Windows.Forms.DataGridView()
        Me.DNI = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ApellidoyNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sexo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fnacimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Edad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Domicilio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdIndividuoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IdGrupoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ObjetosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmsFila = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AbrirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoIndividuoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoIndivEnElMismoDomicilioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomTextBoxBuscador = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TimerBuscador = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ObjetosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsFila.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(794, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActualizarToolStripMenuItem, Me.ToolStripSeparator1, Me.SalirToolStripMenuItem})
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.ArchivoToolStripMenuItem.Text = "Archivo"
        '
        'ActualizarToolStripMenuItem
        '
        Me.ActualizarToolStripMenuItem.Name = "ActualizarToolStripMenuItem"
        Me.ActualizarToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.ActualizarToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.ActualizarToolStripMenuItem.Text = "Actualizar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(142, 6)
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.ShortcutKeyDisplayString = "Esc"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 31.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.grilla, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CustomTextBoxBuscador, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.PictureBox1, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 24)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(794, 548)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'grilla
        '
        Me.grilla.AllowUserToAddRows = False
        Me.grilla.AllowUserToDeleteRows = False
        Me.grilla.AllowUserToResizeColumns = False
        Me.grilla.AllowUserToResizeRows = False
        Me.grilla.AutoGenerateColumns = False
        Me.grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grilla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DNI, Me.ApellidoyNombre, Me.Sexo, Me.Fnacimiento, Me.Edad, Me.Domicilio, Me.IdIndividuoDataGridViewTextBoxColumn, Me.IdGrupoDataGridViewTextBoxColumn, Me.Column1})
        Me.TableLayoutPanel1.SetColumnSpan(Me.grilla, 2)
        Me.grilla.DataSource = Me.ObjetosBindingSource
        Me.grilla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grilla.Location = New System.Drawing.Point(3, 32)
        Me.grilla.MultiSelect = False
        Me.grilla.Name = "grilla"
        Me.grilla.ReadOnly = True
        Me.grilla.RowHeadersVisible = False
        Me.grilla.RowTemplate.ContextMenuStrip = Me.cmsFila
        Me.grilla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grilla.Size = New System.Drawing.Size(788, 493)
        Me.grilla.TabIndex = 4
        '
        'DNI
        '
        Me.DNI.DataPropertyName = "DNI"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.DNI.DefaultCellStyle = DataGridViewCellStyle1
        Me.DNI.HeaderText = "DNI"
        Me.DNI.Name = "DNI"
        Me.DNI.ReadOnly = True
        Me.DNI.Width = 70
        '
        'ApellidoyNombre
        '
        Me.ApellidoyNombre.DataPropertyName = "ApellidoNombre"
        Me.ApellidoyNombre.HeaderText = "Apellido y Nombre"
        Me.ApellidoyNombre.Name = "ApellidoyNombre"
        Me.ApellidoyNombre.ReadOnly = True
        Me.ApellidoyNombre.Width = 200
        '
        'Sexo
        '
        Me.Sexo.DataPropertyName = "Sexo"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.Sexo.DefaultCellStyle = DataGridViewCellStyle2
        Me.Sexo.HeaderText = "Sexo"
        Me.Sexo.Name = "Sexo"
        Me.Sexo.ReadOnly = True
        Me.Sexo.Width = 35
        '
        'Fnacimiento
        '
        Me.Fnacimiento.DataPropertyName = "FNacimiento"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle3.Format = "d"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Fnacimiento.DefaultCellStyle = DataGridViewCellStyle3
        Me.Fnacimiento.HeaderText = "F.Nacimiento"
        Me.Fnacimiento.Name = "Fnacimiento"
        Me.Fnacimiento.ReadOnly = True
        '
        'Edad
        '
        Me.Edad.DataPropertyName = "Edad"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Edad.DefaultCellStyle = DataGridViewCellStyle4
        Me.Edad.HeaderText = "Edad"
        Me.Edad.Name = "Edad"
        Me.Edad.ReadOnly = True
        Me.Edad.Width = 35
        '
        'Domicilio
        '
        Me.Domicilio.DataPropertyName = "Domicilio"
        Me.Domicilio.HeaderText = "Domicilio"
        Me.Domicilio.Name = "Domicilio"
        Me.Domicilio.ReadOnly = True
        Me.Domicilio.Width = 200
        '
        'IdIndividuoDataGridViewTextBoxColumn
        '
        Me.IdIndividuoDataGridViewTextBoxColumn.DataPropertyName = "IdIndividuo"
        Me.IdIndividuoDataGridViewTextBoxColumn.HeaderText = "IdIndividuo"
        Me.IdIndividuoDataGridViewTextBoxColumn.Name = "IdIndividuoDataGridViewTextBoxColumn"
        Me.IdIndividuoDataGridViewTextBoxColumn.ReadOnly = True
        Me.IdIndividuoDataGridViewTextBoxColumn.Visible = False
        '
        'IdGrupoDataGridViewTextBoxColumn
        '
        Me.IdGrupoDataGridViewTextBoxColumn.DataPropertyName = "IdGrupo"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        Me.IdGrupoDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.IdGrupoDataGridViewTextBoxColumn.HeaderText = "Código Grupo"
        Me.IdGrupoDataGridViewTextBoxColumn.Name = "IdGrupoDataGridViewTextBoxColumn"
        Me.IdGrupoDataGridViewTextBoxColumn.ReadOnly = True
        Me.IdGrupoDataGridViewTextBoxColumn.Width = 80
        '
        'Column1
        '
        Me.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column1.HeaderText = ""
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'ObjetosBindingSource
        '
        Me.ObjetosBindingSource.DataSource = GetType(ObjetosDeNegocio.Individuo)
        '
        'cmsFila
        '
        Me.cmsFila.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AbrirToolStripMenuItem, Me.NuevoIndividuoToolStripMenuItem, Me.NuevoIndivEnElMismoDomicilioToolStripMenuItem})
        Me.cmsFila.Name = "ContextMenuStrip1"
        Me.cmsFila.Size = New System.Drawing.Size(312, 70)
        '
        'AbrirToolStripMenuItem
        '
        Me.AbrirToolStripMenuItem.Name = "AbrirToolStripMenuItem"
        Me.AbrirToolStripMenuItem.Size = New System.Drawing.Size(311, 22)
        Me.AbrirToolStripMenuItem.Text = "Abrir"
        '
        'NuevoIndividuoToolStripMenuItem
        '
        Me.NuevoIndividuoToolStripMenuItem.Name = "NuevoIndividuoToolStripMenuItem"
        Me.NuevoIndividuoToolStripMenuItem.Size = New System.Drawing.Size(311, 22)
        Me.NuevoIndividuoToolStripMenuItem.Text = "Nuevo Individuo"
        '
        'NuevoIndivEnElMismoDomicilioToolStripMenuItem
        '
        Me.NuevoIndivEnElMismoDomicilioToolStripMenuItem.Name = "NuevoIndivEnElMismoDomicilioToolStripMenuItem"
        Me.NuevoIndivEnElMismoDomicilioToolStripMenuItem.Size = New System.Drawing.Size(311, 22)
        Me.NuevoIndivEnElMismoDomicilioToolStripMenuItem.Text = "Nuevo Individuo en el mismo Grupo Familiar"
        '
        'CustomTextBoxBuscador
        '
        Me.CustomTextBoxBuscador.AccessibleDescription = ""
        Me.CustomTextBoxBuscador.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.CustomTextBoxBuscador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CustomTextBoxBuscador.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.CustomTextBoxBuscador.Dock = System.Windows.Forms.DockStyle.Right
        Me.CustomTextBoxBuscador.Location = New System.Drawing.Point(315, 3)
        Me.CustomTextBoxBuscador.Name = "CustomTextBoxBuscador"
        Me.CustomTextBoxBuscador.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CustomTextBoxBuscador.Size = New System.Drawing.Size(445, 20)
        Me.CustomTextBoxBuscador.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(766, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(25, 23)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'TimerBuscador
        '
        Me.TimerBuscador.Interval = 400
        '
        'ventanaListado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(794, 572)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "ventanaListado"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.grilla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ObjetosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsFila.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ActualizarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TimerBuscador As System.Windows.Forms.Timer
    Friend WithEvents ObjetosBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EstadoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodigoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReferenciaDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValorDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomTextBoxBuscador As System.Windows.Forms.TextBox
    Friend WithEvents NombreSucursalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdSucursalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdEmpleadoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NombreDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VentasDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn

    Friend WithEvents AbrirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

    Friend WithEvents cmsFila As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents grilla As System.Windows.Forms.DataGridView
    Friend WithEvents IdIndividuo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NuevoIndividuoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoIndivEnElMismoDomicilioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DNI As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ApellidoyNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sexo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fnacimiento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Edad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Domicilio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdIndividuoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IdGrupoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
