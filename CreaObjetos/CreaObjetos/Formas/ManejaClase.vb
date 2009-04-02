Public Class ManejaClase
    Inherits System.Windows.Forms.UserControl

    
#Region "codigo"
    'UserControl overrides dispose to clean up the component list.
    Friend WithEvents clbCampos As System.Windows.Forms.CheckedListBox
    Friend WithEvents lblClase As System.Windows.Forms.Label
    Friend WithEvents chbTodos As System.Windows.Forms.CheckBox
    Friend WithEvents chbIncluir As System.Windows.Forms.CheckBox
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
        Me.clbCampos = New System.Windows.Forms.CheckedListBox
        Me.lblClase = New System.Windows.Forms.Label
        Me.chbTodos = New System.Windows.Forms.CheckBox
        Me.chbIncluir = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'clbCampos
        '
        Me.clbCampos.FormattingEnabled = True
        Me.clbCampos.Location = New System.Drawing.Point(0, 16)
        Me.clbCampos.Name = "clbCampos"
        Me.clbCampos.Size = New System.Drawing.Size(120, 94)
        Me.clbCampos.TabIndex = 0
        '
        'lblClase
        '
        Me.lblClase.AutoSize = True
        Me.lblClase.Location = New System.Drawing.Point(50, 0)
        Me.lblClase.Name = "lblClase"
        Me.lblClase.Size = New System.Drawing.Size(39, 13)
        Me.lblClase.TabIndex = 1
        Me.lblClase.Text = "Label1"
        '
        'chbTodos
        '
        Me.chbTodos.AutoSize = True
        Me.chbTodos.Location = New System.Drawing.Point(0, 113)
        Me.chbTodos.Name = "chbTodos"
        Me.chbTodos.Size = New System.Drawing.Size(115, 17)
        Me.chbTodos.TabIndex = 2
        Me.chbTodos.Text = "Seleccionar Todos"
        Me.chbTodos.UseVisualStyleBackColor = True
        '
        'chbIncluir
        '
        Me.chbIncluir.AutoSize = True
        Me.chbIncluir.Location = New System.Drawing.Point(33, 0)
        Me.chbIncluir.Name = "chbIncluir"
        Me.chbIncluir.Size = New System.Drawing.Size(15, 14)
        Me.chbIncluir.TabIndex = 3
        Me.chbIncluir.Checked = True
        Me.chbIncluir.UseVisualStyleBackColor = True
        '
        'ManejaClase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.chbIncluir)
        Me.Controls.Add(Me.chbTodos)
        Me.Controls.Add(Me.lblClase)
        Me.Controls.Add(Me.clbCampos)
        Me.Name = "ManejaClase"
        Me.Size = New System.Drawing.Size(122, 137)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Public Moviendose As Boolean = False        'bandera que nos dirá si el user ya presiono el clic dentro del mouse... por lo tanto se iniciará el movimiento
    Public PrimeraMovida As Boolean = False     'Como el evento MouseMove se repite constantemente cada vez que detecta el movimiento del mouse, esta bandera nos dira si es la primera vez que se detecta el movimiento despues de presionar el mouse
    Public posicionInicialCursorX = 0           'contendrá la posicion del cursor en "X" exactamente despues de que se presiona el mouse y antes de que se comience a mover el mouse
    Public posicionInicialCursorY = 0
    Private bcel As Boolean
    Private _Clase As Clase
    Private _txtDetalle As TextBox
    Private _datagridCampos As DataGridView
    Public Property Clase() As Clase
        Get
            Return Me._Clase
        End Get
        Set(ByVal value As Clase)
            Me._Clase = value
        End Set
    End Property
    Public Property DataGridCampos() As DataGridView
        Get
            Return Me._datagridCampos
        End Get
        Set(ByVal value As DataGridView)
            Me._datagridCampos = value
        End Set
    End Property
    Public Property txtDetalle() As TextBox
        Get
            Return Me._txtDetalle
        End Get
        Set(ByVal value As TextBox)
            Me._txtDetalle = value
        End Set
    End Property



    Private Sub ManejaClase_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.InitializeComponent()
        Dim f As Integer
        Me.clbCampos.BeginUpdate()
        For f = 0 To Me.Clase.Campos.Count - 1
            Me.clbCampos.Items.Add(Me.Clase.Campos(f).Nombre)
        Next
        Me.clbCampos.EndUpdate()

        Me.lblClase.Text = Me.Clase.NombreTabla
        Me.chbIncluir.Checked = True
        Me.chbTodos.Checked = True
        Me.Width = Me.clbCampos.Width
        Me.Height = Me.clbCampos.Height + 34
        If Not txtDetalle Is Nothing Then
            AddHandler Me.clbCampos.MouseHover, AddressOf dimeClase
        End If

        If Not Me.DataGridCampos Is Nothing Then
            AddHandler Me.DoubleClick, AddressOf CargaGrid
        End If

        AddHandler Me.MouseDown, AddressOf BotonDown
        AddHandler Me.MouseUp, AddressOf BotonUp
        AddHandler Me.MouseMove, AddressOf BotonMove

    End Sub

    Private Sub CargaGrid(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim i As Integer
        For i = 0 To Me.Clase.Campos.Count - 1
            Me.DataGridCampos.Rows.Add(Me.Clase.Campos(i).Nombre, Me.Clase.Campos(i).Tipo)
        Next
    End Sub
    Private Sub chbTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbTodos.CheckedChanged
        Dim f As Integer
        For f = 0 To Me.clbCampos.Items.Count - 1
            Me.clbCampos.SetItemChecked(f, sender.Checked)
            '                clb.Items.Item(f).Checked = True
        Next

    End Sub
    Private Sub dimeClase(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.txtDetalle.Text = sender.Tag
    End Sub

    Public Sub BotonDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Moviendose = True                    'como se presiono el mouse, se iniciará el movimiento del boton
    End Sub

    Public Sub BotonUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Moviendose = False                   'como se soltó el mouse, se detendrá el movimiento del boton
        PrimeraMovida = False                'reiniciamos la bandera
    End Sub

    Public Sub BotonMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If (Moviendose = True) Then          'Sí se esta moviendo el mouse, entonces:
            If (PrimeraMovida = False) Then  'Sí es la primera movida despues de presionar el mouse, entonces:
                PrimeraMovida = True         'igualamos la bandera a true para que no vuelva a entrar aquí
                posicionInicialCursorX = e.X 'obtenemos la posicion del cursor en X al inicarse el movimiento
                posicionInicialCursorY = e.Y 'obtenemos la posicion del cursor en Y al inicarse el movimiento
            End If
            Me.Location = New Point(e.X + Me.Location.X - posicionInicialCursorX, e.Y + Me.Location.Y - posicionInicialCursorY) 'reposisionamos el boton en las nuevas coordenadas
        End If

    End Sub


    Private Sub clbCampos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles clbCampos.KeyDown
        If e.KeyCode = Keys.Delete Then
            If Me.clbCampos.Items.Count > 0 Then
                Me.clbCampos.Items.Remove(Me.clbCampos.SelectedItem)
            End If
        End If
    End Sub
End Class
