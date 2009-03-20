<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCargaXML
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lsbClases = New System.Windows.Forms.ListBox
        Me.tbpAtributos = New System.Windows.Forms.TabControl
        Me.tbpAtributo = New System.Windows.Forms.TabPage
        Me.lblTipo = New System.Windows.Forms.Label
        Me.chbNulo = New System.Windows.Forms.CheckBox
        Me.txtTipo = New System.Windows.Forms.TextBox
        Me.lsbAtributos = New System.Windows.Forms.ListBox
        Me.tbpMetodos = New System.Windows.Forms.TabPage
        Me.tbpRelaciones = New System.Windows.Forms.TabPage
        Me.Opciones = New System.Windows.Forms.TabPage
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CargarProyectoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GuardarProyectoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.chbCrear = New System.Windows.Forms.CheckBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.CheckBox3 = New System.Windows.Forms.CheckBox
        Me.CheckBox4 = New System.Windows.Forms.CheckBox
        Me.btnAgrega = New System.Windows.Forms.Button
        Me.DataGridRelaciones = New System.Windows.Forms.DataGridView
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Tipo = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.Atomicidad = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.tbpAtributos.SuspendLayout()
        Me.tbpAtributo.SuspendLayout()
        Me.tbpMetodos.SuspendLayout()
        Me.tbpRelaciones.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DataGridRelaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lsbClases
        '
        Me.lsbClases.FormattingEnabled = True
        Me.lsbClases.Location = New System.Drawing.Point(2, 26)
        Me.lsbClases.Name = "lsbClases"
        Me.lsbClases.Size = New System.Drawing.Size(120, 368)
        Me.lsbClases.TabIndex = 0
        '
        'tbpAtributos
        '
        Me.tbpAtributos.Controls.Add(Me.tbpAtributo)
        Me.tbpAtributos.Controls.Add(Me.tbpMetodos)
        Me.tbpAtributos.Controls.Add(Me.tbpRelaciones)
        Me.tbpAtributos.Controls.Add(Me.Opciones)
        Me.tbpAtributos.Location = New System.Drawing.Point(139, 27)
        Me.tbpAtributos.Name = "tbpAtributos"
        Me.tbpAtributos.SelectedIndex = 0
        Me.tbpAtributos.Size = New System.Drawing.Size(703, 388)
        Me.tbpAtributos.TabIndex = 1
        '
        'tbpAtributo
        '
        Me.tbpAtributo.Controls.Add(Me.lblTipo)
        Me.tbpAtributo.Controls.Add(Me.chbNulo)
        Me.tbpAtributo.Controls.Add(Me.txtTipo)
        Me.tbpAtributo.Controls.Add(Me.lsbAtributos)
        Me.tbpAtributo.Location = New System.Drawing.Point(4, 22)
        Me.tbpAtributo.Name = "tbpAtributo"
        Me.tbpAtributo.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpAtributo.Size = New System.Drawing.Size(695, 362)
        Me.tbpAtributo.TabIndex = 0
        Me.tbpAtributo.Text = "Atributos"
        Me.tbpAtributo.UseVisualStyleBackColor = True
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipo.Location = New System.Drawing.Point(75, 212)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(36, 13)
        Me.lblTipo.TabIndex = 3
        Me.lblTipo.Text = "Tipo:"
        '
        'chbNulo
        '
        Me.chbNulo.AutoSize = True
        Me.chbNulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbNulo.Location = New System.Drawing.Point(102, 182)
        Me.chbNulo.Name = "chbNulo"
        Me.chbNulo.Size = New System.Drawing.Size(59, 17)
        Me.chbNulo.TabIndex = 2
        Me.chbNulo.Text = "Nulo?"
        Me.chbNulo.UseVisualStyleBackColor = True
        '
        'txtTipo
        '
        Me.txtTipo.Location = New System.Drawing.Point(117, 205)
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.Size = New System.Drawing.Size(100, 20)
        Me.txtTipo.TabIndex = 1
        '
        'lsbAtributos
        '
        Me.lsbAtributos.FormattingEnabled = True
        Me.lsbAtributos.Location = New System.Drawing.Point(56, 26)
        Me.lsbAtributos.Name = "lsbAtributos"
        Me.lsbAtributos.Size = New System.Drawing.Size(215, 134)
        Me.lsbAtributos.TabIndex = 0
        '
        'tbpMetodos
        '
        Me.tbpMetodos.Controls.Add(Me.CheckBox4)
        Me.tbpMetodos.Controls.Add(Me.CheckBox3)
        Me.tbpMetodos.Controls.Add(Me.CheckBox2)
        Me.tbpMetodos.Controls.Add(Me.CheckBox1)
        Me.tbpMetodos.Controls.Add(Me.chbCrear)
        Me.tbpMetodos.Location = New System.Drawing.Point(4, 22)
        Me.tbpMetodos.Name = "tbpMetodos"
        Me.tbpMetodos.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpMetodos.Size = New System.Drawing.Size(695, 362)
        Me.tbpMetodos.TabIndex = 1
        Me.tbpMetodos.Text = "Metodos"
        Me.tbpMetodos.UseVisualStyleBackColor = True
        '
        'tbpRelaciones
        '
        Me.tbpRelaciones.Controls.Add(Me.btnAgrega)
        Me.tbpRelaciones.Controls.Add(Me.DataGridRelaciones)
        Me.tbpRelaciones.Location = New System.Drawing.Point(4, 22)
        Me.tbpRelaciones.Name = "tbpRelaciones"
        Me.tbpRelaciones.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpRelaciones.Size = New System.Drawing.Size(695, 362)
        Me.tbpRelaciones.TabIndex = 2
        Me.tbpRelaciones.Text = "Relaciones"
        Me.tbpRelaciones.UseVisualStyleBackColor = True
        '
        'Opciones
        '
        Me.Opciones.Location = New System.Drawing.Point(4, 22)
        Me.Opciones.Name = "Opciones"
        Me.Opciones.Size = New System.Drawing.Size(695, 362)
        Me.Opciones.TabIndex = 3
        Me.Opciones.Text = "Opciones"
        Me.Opciones.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(854, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CargarProyectoToolStripMenuItem, Me.GuardarProyectoToolStripMenuItem})
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.ArchivoToolStripMenuItem.Text = "Archivo"
        '
        'CargarProyectoToolStripMenuItem
        '
        Me.CargarProyectoToolStripMenuItem.Name = "CargarProyectoToolStripMenuItem"
        Me.CargarProyectoToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.CargarProyectoToolStripMenuItem.Text = "Cargar Proyecto"
        '
        'GuardarProyectoToolStripMenuItem
        '
        Me.GuardarProyectoToolStripMenuItem.Name = "GuardarProyectoToolStripMenuItem"
        Me.GuardarProyectoToolStripMenuItem.Size = New System.Drawing.Size(170, 22)
        Me.GuardarProyectoToolStripMenuItem.Text = "Guardar Proyecto"
        '
        'chbCrear
        '
        Me.chbCrear.AutoSize = True
        Me.chbCrear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbCrear.Location = New System.Drawing.Point(32, 28)
        Me.chbCrear.Name = "chbCrear"
        Me.chbCrear.Size = New System.Drawing.Size(56, 17)
        Me.chbCrear.TabIndex = 0
        Me.chbCrear.Text = "Crear"
        Me.chbCrear.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(31, 45)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(71, 17)
        Me.CheckBox1.TabIndex = 1
        Me.CheckBox1.Text = "Guardar"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox2.Location = New System.Drawing.Point(31, 62)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(60, 17)
        Me.CheckBox2.TabIndex = 2
        Me.CheckBox2.Text = "Borrar"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox3.Location = New System.Drawing.Point(31, 79)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(82, 17)
        Me.CheckBox3.TabIndex = 3
        Me.CheckBox3.Text = "Actualizar"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox4.Location = New System.Drawing.Point(31, 96)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(63, 17)
        Me.CheckBox4.TabIndex = 4
        Me.CheckBox4.Text = "Cargar"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'btnAgrega
        '
        Me.btnAgrega.Location = New System.Drawing.Point(275, 127)
        Me.btnAgrega.Name = "btnAgrega"
        Me.btnAgrega.Size = New System.Drawing.Size(75, 23)
        Me.btnAgrega.TabIndex = 31
        Me.btnAgrega.Text = "Agregar Campo"
        Me.btnAgrega.UseVisualStyleBackColor = True
        '
        'DataGridRelaciones
        '
        Me.DataGridRelaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridRelaciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Nombre, Me.Tipo, Me.Atomicidad})
        Me.DataGridRelaciones.Location = New System.Drawing.Point(6, 6)
        Me.DataGridRelaciones.Name = "DataGridRelaciones"
        Me.DataGridRelaciones.Size = New System.Drawing.Size(344, 115)
        Me.DataGridRelaciones.TabIndex = 30
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Campo"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'Tipo
        '
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Tipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Atomicidad
        '
        Me.Atomicidad.HeaderText = "Atomicidad"
        Me.Atomicidad.Items.AddRange(New Object() {"1..N", "N..M"})
        Me.Atomicidad.Name = "Atomicidad"
        Me.Atomicidad.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Atomicidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'frmCargaXML
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(854, 453)
        Me.Controls.Add(Me.tbpAtributos)
        Me.Controls.Add(Me.lsbClases)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmCargaXML"
        Me.Text = "frmCargaXML"
        Me.tbpAtributos.ResumeLayout(False)
        Me.tbpAtributo.ResumeLayout(False)
        Me.tbpAtributo.PerformLayout()
        Me.tbpMetodos.ResumeLayout(False)
        Me.tbpMetodos.PerformLayout()
        Me.tbpRelaciones.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DataGridRelaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lsbClases As System.Windows.Forms.ListBox
    Friend WithEvents tbpAtributos As System.Windows.Forms.TabControl
    Friend WithEvents tbpAtributo As System.Windows.Forms.TabPage
    Friend WithEvents tbpMetodos As System.Windows.Forms.TabPage
    Friend WithEvents tbpRelaciones As System.Windows.Forms.TabPage
    Friend WithEvents Opciones As System.Windows.Forms.TabPage
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CargarProyectoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuardarProyectoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lsbAtributos As System.Windows.Forms.ListBox
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents chbNulo As System.Windows.Forms.CheckBox
    Friend WithEvents txtTipo As System.Windows.Forms.TextBox
    Friend WithEvents chbCrear As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents btnAgrega As System.Windows.Forms.Button
    Friend WithEvents DataGridRelaciones As System.Windows.Forms.DataGridView
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Atomicidad As System.Windows.Forms.DataGridViewComboBoxColumn
End Class
