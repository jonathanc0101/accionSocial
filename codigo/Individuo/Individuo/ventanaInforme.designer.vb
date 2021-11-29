<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ventanaInforme
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBoxInforme = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBoxAgente = New System.Windows.Forms.TextBox()
        Me.TextBoxDescripcion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBoxOficina = New System.Windows.Forms.TextBox()
        Me.DateTimePickerFecha = New System.Windows.Forms.DateTimePicker()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.ButtonCancelar = New System.Windows.Forms.Button()
        Me.ButtonGuardar = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.GroupBoxInforme.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.GroupBoxInforme, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel4, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 203.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(597, 250)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'GroupBoxInforme
        '
        Me.GroupBoxInforme.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupBoxInforme.Controls.Add(Me.TableLayoutPanel3)
        Me.GroupBoxInforme.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxInforme.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxInforme.Location = New System.Drawing.Point(3, 3)
        Me.GroupBoxInforme.Name = "GroupBoxInforme"
        Me.GroupBoxInforme.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBoxInforme.Size = New System.Drawing.Size(591, 197)
        Me.GroupBoxInforme.TabIndex = 3
        Me.GroupBoxInforme.TabStop = False
        Me.GroupBoxInforme.Text = "Informe"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 192.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 192.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Label4, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBoxAgente, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBoxDescripcion, 0, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.Label1, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label3, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBoxOficina, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.DateTimePickerFecha, 2, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 14)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 6
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(591, 183)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(192, 0)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 23)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Agente"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBoxAgente
        '
        Me.TextBoxAgente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxAgente.Location = New System.Drawing.Point(192, 23)
        Me.TextBoxAgente.Margin = New System.Windows.Forms.Padding(0)
        Me.TextBoxAgente.MaxLength = 50
        Me.TextBoxAgente.Name = "TextBoxAgente"
        Me.TextBoxAgente.Size = New System.Drawing.Size(189, 21)
        Me.TextBoxAgente.TabIndex = 2
        '
        'TextBoxDescripcion
        '
        Me.TableLayoutPanel3.SetColumnSpan(Me.TextBoxDescripcion, 3)
        Me.TextBoxDescripcion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxDescripcion.Location = New System.Drawing.Point(0, 69)
        Me.TextBoxDescripcion.Margin = New System.Windows.Forms.Padding(0)
        Me.TextBoxDescripcion.MaxLength = 3000
        Me.TextBoxDescripcion.Multiline = True
        Me.TextBoxDescripcion.Name = "TextBoxDescripcion"
        Me.TableLayoutPanel3.SetRowSpan(Me.TextBoxDescripcion, 3)
        Me.TextBoxDescripcion.Size = New System.Drawing.Size(591, 114)
        Me.TextBoxDescripcion.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 46)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Descripción"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 23)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Oficina"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(384, 0)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 23)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Fecha"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBoxOficina
        '
        Me.TextBoxOficina.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxOficina.Location = New System.Drawing.Point(0, 23)
        Me.TextBoxOficina.Margin = New System.Windows.Forms.Padding(0)
        Me.TextBoxOficina.MaxLength = 50
        Me.TextBoxOficina.Name = "TextBoxOficina"
        Me.TextBoxOficina.Size = New System.Drawing.Size(189, 21)
        Me.TextBoxOficina.TabIndex = 1
        '
        'DateTimePickerFecha
        '
        Me.DateTimePickerFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerFecha.Location = New System.Drawing.Point(384, 23)
        Me.DateTimePickerFecha.Margin = New System.Windows.Forms.Padding(0)
        Me.DateTimePickerFecha.Name = "DateTimePickerFecha"
        Me.DateTimePickerFecha.Size = New System.Drawing.Size(197, 21)
        Me.DateTimePickerFecha.TabIndex = 3
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 73.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 9.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.ButtonCancelar, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.ButtonGuardar, 0, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(446, 218)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(148, 29)
        Me.TableLayoutPanel4.TabIndex = 4
        '
        'ButtonCancelar
        '
        Me.ButtonCancelar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonCancelar.Location = New System.Drawing.Point(76, 3)
        Me.ButtonCancelar.Name = "ButtonCancelar"
        Me.ButtonCancelar.Size = New System.Drawing.Size(69, 23)
        Me.ButtonCancelar.TabIndex = 1
        Me.ButtonCancelar.Text = "Cancelar"
        Me.ButtonCancelar.UseVisualStyleBackColor = True
        '
        'ButtonGuardar
        '
        Me.ButtonGuardar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ButtonGuardar.Location = New System.Drawing.Point(3, 3)
        Me.ButtonGuardar.Name = "ButtonGuardar"
        Me.ButtonGuardar.Size = New System.Drawing.Size(67, 23)
        Me.ButtonGuardar.TabIndex = 0
        Me.ButtonGuardar.Text = "Guardar"
        Me.ButtonGuardar.UseVisualStyleBackColor = True
        '
        'ventanaInforme
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(597, 250)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "ventanaInforme"
        Me.Text = "Informe"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.GroupBoxInforme.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents GroupBoxInforme As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TextBoxDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBoxOficina As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonCancelar As System.Windows.Forms.Button
    Friend WithEvents ButtonGuardar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBoxAgente As System.Windows.Forms.TextBox
End Class
