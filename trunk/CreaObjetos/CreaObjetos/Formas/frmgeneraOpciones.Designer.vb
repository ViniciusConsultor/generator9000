<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmgeneraOpciones
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.rdbClipboard = New System.Windows.Forms.RadioButton
        Me.rdbVarios = New System.Windows.Forms.RadioButton
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.btnGeneraClase = New System.Windows.Forms.Button
        Me.rdbArchivo = New System.Windows.Forms.RadioButton
        Me.rdbTexto = New System.Windows.Forms.RadioButton
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.rdbASP = New System.Windows.Forms.RadioButton
        Me.rdbWapl = New System.Windows.Forms.RadioButton
        Me.chkClases = New System.Windows.Forms.CheckBox
        Me.chkInterfaz = New System.Windows.Forms.CheckBox
        Me.chkClasesASP = New System.Windows.Forms.CheckBox
        Me.chkManejador = New System.Windows.Forms.CheckBox
        Me.chkPagina = New System.Windows.Forms.CheckBox
        Me.chkMngASP = New System.Windows.Forms.CheckBox
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.rdbClipboard)
        Me.Panel1.Controls.Add(Me.rdbVarios)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.btnGeneraClase)
        Me.Panel1.Controls.Add(Me.rdbArchivo)
        Me.Panel1.Controls.Add(Me.rdbTexto)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(446, 421)
        Me.Panel1.TabIndex = 42
        '
        'rdbClipboard
        '
        Me.rdbClipboard.AutoSize = True
        Me.rdbClipboard.Checked = True
        Me.rdbClipboard.Location = New System.Drawing.Point(14, 12)
        Me.rdbClipboard.Name = "rdbClipboard"
        Me.rdbClipboard.Size = New System.Drawing.Size(129, 17)
        Me.rdbClipboard.TabIndex = 37
        Me.rdbClipboard.TabStop = True
        Me.rdbClipboard.Text = "Copiar a Portapapeles"
        Me.rdbClipboard.UseVisualStyleBackColor = True
        '
        'rdbVarios
        '
        Me.rdbVarios.AutoSize = True
        Me.rdbVarios.Location = New System.Drawing.Point(14, 78)
        Me.rdbVarios.Name = "rdbVarios"
        Me.rdbVarios.Size = New System.Drawing.Size(118, 17)
        Me.rdbVarios.TabIndex = 40
        Me.rdbVarios.TabStop = True
        Me.rdbVarios.Text = "Archivos separados"
        Me.rdbVarios.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(14, 134)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(224, 48)
        Me.TextBox1.TabIndex = 34
        '
        'btnGeneraClase
        '
        Me.btnGeneraClase.Location = New System.Drawing.Point(182, 19)
        Me.btnGeneraClase.Name = "btnGeneraClase"
        Me.btnGeneraClase.Size = New System.Drawing.Size(75, 48)
        Me.btnGeneraClase.TabIndex = 35
        Me.btnGeneraClase.Text = "Genera"
        Me.btnGeneraClase.UseVisualStyleBackColor = True
        '
        'rdbArchivo
        '
        Me.rdbArchivo.AutoSize = True
        Me.rdbArchivo.Location = New System.Drawing.Point(14, 59)
        Me.rdbArchivo.Name = "rdbArchivo"
        Me.rdbArchivo.Size = New System.Drawing.Size(92, 17)
        Me.rdbArchivo.TabIndex = 39
        Me.rdbArchivo.TabStop = True
        Me.rdbArchivo.Text = "Archivo Unico"
        Me.rdbArchivo.UseVisualStyleBackColor = True
        '
        'rdbTexto
        '
        Me.rdbTexto.AutoSize = True
        Me.rdbTexto.Location = New System.Drawing.Point(14, 35)
        Me.rdbTexto.Name = "rdbTexto"
        Me.rdbTexto.Size = New System.Drawing.Size(106, 17)
        Me.rdbTexto.TabIndex = 38
        Me.rdbTexto.TabStop = True
        Me.rdbTexto.Text = "Pegar en textBox"
        Me.rdbTexto.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel2.Controls.Add(Me.rdbASP)
        Me.Panel2.Controls.Add(Me.rdbWapl)
        Me.Panel2.Controls.Add(Me.chkClases)
        Me.Panel2.Controls.Add(Me.chkInterfaz)
        Me.Panel2.Controls.Add(Me.chkClasesASP)
        Me.Panel2.Controls.Add(Me.chkManejador)
        Me.Panel2.Controls.Add(Me.chkPagina)
        Me.Panel2.Controls.Add(Me.chkMngASP)
        Me.Panel2.Location = New System.Drawing.Point(14, 242)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(273, 138)
        Me.Panel2.TabIndex = 43
        '
        'rdbASP
        '
        Me.rdbASP.AutoSize = True
        Me.rdbASP.Location = New System.Drawing.Point(153, 7)
        Me.rdbASP.Name = "rdbASP"
        Me.rdbASP.Size = New System.Drawing.Size(101, 17)
        Me.rdbASP.TabIndex = 50
        Me.rdbASP.Text = "ASP Application"
        Me.rdbASP.UseVisualStyleBackColor = True
        '
        'rdbWapl
        '
        Me.rdbWapl.AutoSize = True
        Me.rdbWapl.Checked = True
        Me.rdbWapl.Location = New System.Drawing.Point(5, 7)
        Me.rdbWapl.Name = "rdbWapl"
        Me.rdbWapl.Size = New System.Drawing.Size(124, 17)
        Me.rdbWapl.TabIndex = 49
        Me.rdbWapl.TabStop = True
        Me.rdbWapl.Text = "Windows Application"
        Me.rdbWapl.UseVisualStyleBackColor = True
        '
        'chkClases
        '
        Me.chkClases.AutoSize = True
        Me.chkClases.Checked = True
        Me.chkClases.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkClases.Location = New System.Drawing.Point(3, 49)
        Me.chkClases.Name = "chkClases"
        Me.chkClases.Size = New System.Drawing.Size(57, 17)
        Me.chkClases.TabIndex = 43
        Me.chkClases.Text = "Clases"
        Me.chkClases.UseVisualStyleBackColor = True
        '
        'chkInterfaz
        '
        Me.chkInterfaz.AutoSize = True
        Me.chkInterfaz.Checked = True
        Me.chkInterfaz.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkInterfaz.Location = New System.Drawing.Point(3, 95)
        Me.chkInterfaz.Name = "chkInterfaz"
        Me.chkInterfaz.Size = New System.Drawing.Size(61, 17)
        Me.chkInterfaz.TabIndex = 45
        Me.chkInterfaz.Text = "Interfaz"
        Me.chkInterfaz.UseVisualStyleBackColor = True
        '
        'chkClasesASP
        '
        Me.chkClasesASP.AutoSize = True
        Me.chkClasesASP.Checked = True
        Me.chkClasesASP.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkClasesASP.Location = New System.Drawing.Point(128, 49)
        Me.chkClasesASP.Name = "chkClasesASP"
        Me.chkClasesASP.Size = New System.Drawing.Size(57, 17)
        Me.chkClasesASP.TabIndex = 46
        Me.chkClasesASP.Text = "Clases"
        Me.chkClasesASP.UseVisualStyleBackColor = True
        '
        'chkManejador
        '
        Me.chkManejador.AutoSize = True
        Me.chkManejador.Checked = True
        Me.chkManejador.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkManejador.Location = New System.Drawing.Point(3, 72)
        Me.chkManejador.Name = "chkManejador"
        Me.chkManejador.Size = New System.Drawing.Size(87, 17)
        Me.chkManejador.TabIndex = 44
        Me.chkManejador.Text = "Manejadores"
        Me.chkManejador.UseVisualStyleBackColor = True
        '
        'chkPagina
        '
        Me.chkPagina.AutoSize = True
        Me.chkPagina.Checked = True
        Me.chkPagina.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPagina.Location = New System.Drawing.Point(128, 95)
        Me.chkPagina.Name = "chkPagina"
        Me.chkPagina.Size = New System.Drawing.Size(56, 17)
        Me.chkPagina.TabIndex = 48
        Me.chkPagina.Text = "HTML"
        Me.chkPagina.UseVisualStyleBackColor = True
        '
        'chkMngASP
        '
        Me.chkMngASP.AutoSize = True
        Me.chkMngASP.Checked = True
        Me.chkMngASP.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMngASP.Location = New System.Drawing.Point(128, 72)
        Me.chkMngASP.Name = "chkMngASP"
        Me.chkMngASP.Size = New System.Drawing.Size(63, 17)
        Me.chkMngASP.TabIndex = 47
        Me.chkMngASP.Text = "mnjASP"
        Me.chkMngASP.UseVisualStyleBackColor = True
        '
        'frmgeneraOpciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(444, 420)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmgeneraOpciones"
        Me.Text = "frmgeneraOpciones"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rdbClipboard As System.Windows.Forms.RadioButton
    Friend WithEvents rdbVarios As System.Windows.Forms.RadioButton
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents btnGeneraClase As System.Windows.Forms.Button
    Friend WithEvents rdbArchivo As System.Windows.Forms.RadioButton
    Friend WithEvents rdbTexto As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rdbASP As System.Windows.Forms.RadioButton
    Friend WithEvents rdbWapl As System.Windows.Forms.RadioButton
    Friend WithEvents chkClases As System.Windows.Forms.CheckBox
    Friend WithEvents chkInterfaz As System.Windows.Forms.CheckBox
    Friend WithEvents chkClasesASP As System.Windows.Forms.CheckBox
    Friend WithEvents chkManejador As System.Windows.Forms.CheckBox
    Friend WithEvents chkPagina As System.Windows.Forms.CheckBox
    Friend WithEvents chkMngASP As System.Windows.Forms.CheckBox
End Class
