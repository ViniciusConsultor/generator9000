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
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel1.Controls.Add(Me.rdbClipboard)
        Me.Panel1.Controls.Add(Me.rdbVarios)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.btnGeneraClase)
        Me.Panel1.Controls.Add(Me.rdbArchivo)
        Me.Panel1.Controls.Add(Me.rdbTexto)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(272, 185)
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
        'frmgeneraOpciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(269, 186)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmgeneraOpciones"
        Me.Text = "frmgeneraOpciones"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rdbClipboard As System.Windows.Forms.RadioButton
    Friend WithEvents rdbVarios As System.Windows.Forms.RadioButton
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents btnGeneraClase As System.Windows.Forms.Button
    Friend WithEvents rdbArchivo As System.Windows.Forms.RadioButton
    Friend WithEvents rdbTexto As System.Windows.Forms.RadioButton
End Class
