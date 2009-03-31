Imports System.Data.SqlClient
Imports System.IO

Public Class FrmPrincipal
    Inherits System.Windows.Forms.Form
#Region "Campos"
    Public Tablas As New List(Of String)
    Dim clases As List(Of Clase)
    Private _baseDatos As String
    Private _sqlCon As SqlConnection

#End Region

#Region "Propiedades"
    Public Property baseDatos() As String
        Get
            Return Me._baseDatos
        End Get
        Set(ByVal value As String)
            Me._baseDatos = value
        End Set
    End Property
    Public Property sqlCon() As SqlConnection
        Get
            Return Me._sqlCon
        End Get
        Set(ByVal value As SqlConnection)
            Me._sqlCon = value
        End Set
    End Property
#End Region

#Region "codigo"
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblBase As System.Windows.Forms.Label
    Friend WithEvents lblTablaSQL As System.Windows.Forms.Label
    Friend WithEvents cmbTablas As System.Windows.Forms.ComboBox
    Friend WithEvents tbcClase As System.Windows.Forms.TabControl
    Friend WithEvents tbpRelaciones As System.Windows.Forms.TabPage
    Friend WithEvents btnAgrega As System.Windows.Forms.Button
    Friend WithEvents DataGridRelaciones As System.Windows.Forms.DataGridView
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Atomicidad As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents tbpCampos As System.Windows.Forms.TabPage
    Friend WithEvents DataGridCampo As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tbpOpcion As System.Windows.Forms.TabPage
    Friend WithEvents tbpMetodos As System.Windows.Forms.TabPage
    Friend WithEvents tbClases As System.Windows.Forms.TabPage
    Friend WithEvents tvwClases As System.Windows.Forms.TreeView
    Friend WithEvents imlClase As System.Windows.Forms.ImageList
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CrearCodigoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GenerarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CtlManejaClases1 As WindowsApplication1.ctlManejaClases
    Friend WithEvents CtlManejaClases2 As WindowsApplication1.ctlManejaClases
    Friend WithEvents CtlManejaClases3 As WindowsApplication1.ctlManejaClases
    Friend WithEvents CtlManejaClases4 As WindowsApplication1.ctlManejaClases
    Friend WithEvents cmcClases As WindowsApplication1.ctlManejaClases
    Friend WithEvents NuevoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem


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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrincipal))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.lblBase = New System.Windows.Forms.Label
        Me.lblTablaSQL = New System.Windows.Forms.Label
        Me.cmbTablas = New System.Windows.Forms.ComboBox
        Me.tbcClase = New System.Windows.Forms.TabControl
        Me.tbpRelaciones = New System.Windows.Forms.TabPage
        Me.btnAgrega = New System.Windows.Forms.Button
        Me.DataGridRelaciones = New System.Windows.Forms.DataGridView
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Tipo = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.Atomicidad = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.tbpCampos = New System.Windows.Forms.TabPage
        Me.DataGridCampo = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tbpOpcion = New System.Windows.Forms.TabPage
        Me.tbpMetodos = New System.Windows.Forms.TabPage
        Me.tbClases = New System.Windows.Forms.TabPage
        Me.tvwClases = New System.Windows.Forms.TreeView
        Me.imlClase = New System.Windows.Forms.ImageList(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NuevoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CrearCodigoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GenerarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.cmcClases = New WindowsApplication1.ctlManejaClases
        Me.tbcClase.SuspendLayout()
        Me.tbpRelaciones.SuspendLayout()
        CType(Me.DataGridRelaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbpCampos.SuspendLayout()
        CType(Me.DataGridCampo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbClases.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblBase
        '
        Me.lblBase.AutoSize = True
        Me.lblBase.Location = New System.Drawing.Point(132, 45)
        Me.lblBase.Name = "lblBase"
        Me.lblBase.Size = New System.Drawing.Size(0, 13)
        Me.lblBase.TabIndex = 8
        '
        'lblTablaSQL
        '
        Me.lblTablaSQL.AutoSize = True
        Me.lblTablaSQL.Location = New System.Drawing.Point(70, 39)
        Me.lblTablaSQL.Name = "lblTablaSQL"
        Me.lblTablaSQL.Size = New System.Drawing.Size(39, 13)
        Me.lblTablaSQL.TabIndex = 17
        Me.lblTablaSQL.Text = "Tablas"
        '
        'cmbTablas
        '
        Me.cmbTablas.FormattingEnabled = True
        Me.cmbTablas.Location = New System.Drawing.Point(115, 18)
        Me.cmbTablas.Name = "cmbTablas"
        Me.cmbTablas.Size = New System.Drawing.Size(121, 21)
        Me.cmbTablas.TabIndex = 18
        '
        'tbcClase
        '
        Me.tbcClase.Controls.Add(Me.tbpRelaciones)
        Me.tbcClase.Controls.Add(Me.tbpCampos)
        Me.tbcClase.Controls.Add(Me.tbpOpcion)
        Me.tbcClase.Controls.Add(Me.tbpMetodos)
        Me.tbcClase.Controls.Add(Me.tbClases)
        Me.tbcClase.Location = New System.Drawing.Point(412, 556)
        Me.tbcClase.Name = "tbcClase"
        Me.tbcClase.SelectedIndex = 0
        Me.tbcClase.Size = New System.Drawing.Size(498, 175)
        Me.tbcClase.TabIndex = 30
        '
        'tbpRelaciones
        '
        Me.tbpRelaciones.Controls.Add(Me.btnAgrega)
        Me.tbpRelaciones.Controls.Add(Me.DataGridRelaciones)
        Me.tbpRelaciones.Location = New System.Drawing.Point(4, 22)
        Me.tbpRelaciones.Name = "tbpRelaciones"
        Me.tbpRelaciones.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpRelaciones.Size = New System.Drawing.Size(490, 149)
        Me.tbpRelaciones.TabIndex = 0
        Me.tbpRelaciones.Text = "Relaciones"
        Me.tbpRelaciones.UseVisualStyleBackColor = True
        '
        'btnAgrega
        '
        Me.btnAgrega.Location = New System.Drawing.Point(270, 120)
        Me.btnAgrega.Name = "btnAgrega"
        Me.btnAgrega.Size = New System.Drawing.Size(75, 23)
        Me.btnAgrega.TabIndex = 29
        Me.btnAgrega.Text = "Agregar Campo"
        Me.btnAgrega.UseVisualStyleBackColor = True
        '
        'DataGridRelaciones
        '
        Me.DataGridRelaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridRelaciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Nombre, Me.Tipo, Me.Atomicidad})
        Me.DataGridRelaciones.Location = New System.Drawing.Point(73, 3)
        Me.DataGridRelaciones.Name = "DataGridRelaciones"
        Me.DataGridRelaciones.Size = New System.Drawing.Size(344, 115)
        Me.DataGridRelaciones.TabIndex = 28
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
        'tbpCampos
        '
        Me.tbpCampos.Controls.Add(Me.DataGridCampo)
        Me.tbpCampos.Location = New System.Drawing.Point(4, 22)
        Me.tbpCampos.Name = "tbpCampos"
        Me.tbpCampos.Padding = New System.Windows.Forms.Padding(3)
        Me.tbpCampos.Size = New System.Drawing.Size(490, 149)
        Me.tbpCampos.TabIndex = 1
        Me.tbpCampos.Text = "Campos"
        Me.tbpCampos.UseVisualStyleBackColor = True
        '
        'DataGridCampo
        '
        Me.DataGridCampo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridCampo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        Me.DataGridCampo.Location = New System.Drawing.Point(98, 10)
        Me.DataGridCampo.Name = "DataGridCampo"
        Me.DataGridCampo.Size = New System.Drawing.Size(244, 115)
        Me.DataGridCampo.TabIndex = 30
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Campo"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Tipo"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'tbpOpcion
        '
        Me.tbpOpcion.Location = New System.Drawing.Point(4, 22)
        Me.tbpOpcion.Name = "tbpOpcion"
        Me.tbpOpcion.Size = New System.Drawing.Size(490, 149)
        Me.tbpOpcion.TabIndex = 2
        Me.tbpOpcion.Text = "Opciones"
        Me.tbpOpcion.UseVisualStyleBackColor = True
        '
        'tbpMetodos
        '
        Me.tbpMetodos.Location = New System.Drawing.Point(4, 22)
        Me.tbpMetodos.Name = "tbpMetodos"
        Me.tbpMetodos.Size = New System.Drawing.Size(490, 149)
        Me.tbpMetodos.TabIndex = 3
        Me.tbpMetodos.Text = "Metodos"
        Me.tbpMetodos.UseVisualStyleBackColor = True
        '
        'tbClases
        '
        Me.tbClases.Controls.Add(Me.cmbTablas)
        Me.tbClases.Controls.Add(Me.lblTablaSQL)
        Me.tbClases.Location = New System.Drawing.Point(4, 22)
        Me.tbClases.Name = "tbClases"
        Me.tbClases.Padding = New System.Windows.Forms.Padding(3)
        Me.tbClases.Size = New System.Drawing.Size(490, 149)
        Me.tbClases.TabIndex = 4
        Me.tbClases.Text = "Clases"
        Me.tbClases.UseVisualStyleBackColor = True
        '
        'tvwClases
        '
        Me.tvwClases.ImageIndex = 0
        Me.tvwClases.ImageList = Me.imlClase
        Me.tvwClases.ItemHeight = 20
        Me.tvwClases.Location = New System.Drawing.Point(12, 28)
        Me.tvwClases.Name = "tvwClases"
        Me.tvwClases.SelectedImageIndex = 0
        Me.tvwClases.Size = New System.Drawing.Size(171, 522)
        Me.tvwClases.TabIndex = 35
        '
        'imlClase
        '
        Me.imlClase.ImageStream = CType(resources.GetObject("imlClase.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlClase.TransparentColor = System.Drawing.Color.Transparent
        Me.imlClase.Images.SetKeyName(0, "clase.PNG")
        Me.imlClase.Images.SetKeyName(1, "atributo.PNG")
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.CrearCodigoToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(922, 24)
        Me.MenuStrip1.TabIndex = 36
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoToolStripMenuItem})
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.ArchivoToolStripMenuItem.Text = "Archivo"
        '
        'NuevoToolStripMenuItem
        '
        Me.NuevoToolStripMenuItem.Name = "NuevoToolStripMenuItem"
        Me.NuevoToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.NuevoToolStripMenuItem.Text = "Nuevo"
        '
        'CrearCodigoToolStripMenuItem
        '
        Me.CrearCodigoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GenerarToolStripMenuItem})
        Me.CrearCodigoToolStripMenuItem.Name = "CrearCodigoToolStripMenuItem"
        Me.CrearCodigoToolStripMenuItem.Size = New System.Drawing.Size(82, 20)
        Me.CrearCodigoToolStripMenuItem.Text = "Crear Codigo"
        '
        'GenerarToolStripMenuItem
        '
        Me.GenerarToolStripMenuItem.Name = "GenerarToolStripMenuItem"
        Me.GenerarToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.GenerarToolStripMenuItem.Text = "Generar"
        '
        'cmcClases
        '
        Me.cmcClases.Location = New System.Drawing.Point(190, 28)
        Me.cmcClases.Name = "cmcClases"
        Me.cmcClases.Size = New System.Drawing.Size(720, 522)
        Me.cmcClases.TabIndex = 37
        '
        'FrmPrincipal
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(922, 734)
        Me.Controls.Add(Me.cmcClases)
        Me.Controls.Add(Me.tvwClases)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.tbcClase)
        Me.Controls.Add(Me.lblBase)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FrmPrincipal"
        Me.Text = "Class Generator 9000"
        Me.tbcClase.ResumeLayout(False)
        Me.tbpRelaciones.ResumeLayout(False)
        CType(Me.DataGridRelaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbpCampos.ResumeLayout(False)
        CType(Me.DataGridCampo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbClases.ResumeLayout(False)
        Me.tbClases.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Public Sub crearClases()

        Dim i As Integer
        Dim myCommand As SqlCommand
        Dim sdr As SqlDataReader

        Me.sqlCon.Open()
        Me.clases = New List(Of Clase)

        Me.cmcClases.DataGridRelaciones = Me.DataGridRelaciones
        Me.cmcClases.pnlClases.Controls.Clear()


        If Not Me.tvwClases.Nodes Is Nothing Then
            Me.tvwClases.Nodes.Clear()
        End If
        Dim TreeNode2 As New TreeNode
        TreeNode2.Name = "Clases"
        TreeNode2.Text = "Clases"
        Me.tvwClases.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode2})

        myCommand = New SqlCommand()
        myCommand.Connection = Me.sqlCon
        If Not Me.baseDatos Is Nothing Then
            myCommand.CommandText = "use " & Me.baseDatos & " select * from information_schema.Tables"
        Else
            myCommand.CommandText = " select * from information_schema.Tables"
        End If
        sdr = myCommand.ExecuteReader
        While (sdr.Read)
            Dim cls As New Clase
            cls.NombreTabla = sdr.Item("Table_name")
            If Not Me.baseDatos Is Nothing Then
                cls.sqlCon = New SqlConnection(Me.sqlCon.ConnectionString & "Pwd=marquez;Initial Catalog=" & Me.baseDatos)
            Else
                cls.sqlCon = Me.sqlCon
            End If


            Me.clases.Add(cls)

        End While
        sdr.Close()
        Me.sqlCon.Close()
        For i = 0 To clases.Count - 1

            Dim indatr As Integer
            Me.clases(i).cargaAtributos()
            Me.clases(i).CargaRelaciones()

            Dim nodoClase As New TreeNode(clases(i).nombre, 0, 0)
            Me.tvwClases.Nodes.Add(nodoClase)

            For indatr = 0 To Me.clases(i).Campos.Count - 1
                nodoClase.Nodes.Add(New TreeNode(clases(i).Campos(indatr).Nombre, 1, 1))
            Next

            Me.cmcClases.agregaClases(Me.clases(i))
        Next

        If Me.Tipo.Items.Count = 0 Then
            For i = 0 To Me.clases.Count - 1
                Me.Tipo.Items.Add(Me.clases(i).nombre)
            Next
        End If



    End Sub

    'Private Sub cargaTablas(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DataGridRelaciones.CellBeginEdit
    '    Dim i As Integer
    '    If Me.Tipo.Items.Count = 0 Then
    '        For i = 0 To Me.clases.Count - 1
    '            Me.Tipo.Items.Add(Me.clases(i).nombre)
    '        Next
    '    End If
    'End Sub

    Private Sub NuevoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoToolStripMenuItem.Click
        frmCargaBase.Show()
    End Sub


    Private Sub GenerarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenerarToolStripMenuItem.Click

        frmgeneraOpciones.manejaClases = Me.cmcClases.manejaClases
        frmgeneraOpciones.Show()

    End Sub

    Private Sub FrmGeneraCodigo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.InitializeComponent()
    End Sub

    Private Sub DataGridRelaciones_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridRelaciones.CellContentClick

    End Sub

    Private Sub DataGridRelaciones_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridRelaciones.DataError
        MessageBox.Show(e.ToString & "columna defectuosa" & e.ColumnIndex & "Valor =" & Me.DataGridRelaciones.Item(e.ColumnIndex, e.RowIndex).Value)
    End Sub

    



End Class
