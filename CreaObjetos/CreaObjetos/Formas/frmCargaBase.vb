Imports System.Data.sqlClient

Public Class frmCargaBase
    Inherits System.Windows.Forms.Form
    Dim myConnection As SqlConnection
    Dim Tablas As New List(Of String)
    Dim userTables As DataTable
    'Dim frmCreaCodigo As New FrmGeneraCodigo
#Region "Codigo"
    Friend WithEvents txtServer As System.Windows.Forms.TextBox
    Friend WithEvents btnCreaClase As System.Windows.Forms.Button
    Friend WithEvents cmbSQLDatabase As System.Windows.Forms.ComboBox
    Friend WithEvents btnOpenSQL As System.Windows.Forms.Button
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents txtContrasena As System.Windows.Forms.TextBox
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents lblContrasena As System.Windows.Forms.Label
    Friend WithEvents lblBase As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblServidor As System.Windows.Forms.Label

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
        Me.txtServer = New System.Windows.Forms.TextBox
        Me.btnCreaClase = New System.Windows.Forms.Button
        Me.cmbSQLDatabase = New System.Windows.Forms.ComboBox
        Me.btnOpenSQL = New System.Windows.Forms.Button
        Me.txtUsuario = New System.Windows.Forms.TextBox
        Me.txtContrasena = New System.Windows.Forms.TextBox
        Me.lblUsuario = New System.Windows.Forms.Label
        Me.lblContrasena = New System.Windows.Forms.Label
        Me.lblBase = New System.Windows.Forms.Label
        Me.lblServidor = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(74, 12)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(164, 20)
        Me.txtServer.TabIndex = 30
        '
        'btnCreaClase
        '
        Me.btnCreaClase.Location = New System.Drawing.Point(244, 69)
        Me.btnCreaClase.Name = "btnCreaClase"
        Me.btnCreaClase.Size = New System.Drawing.Size(75, 43)
        Me.btnCreaClase.TabIndex = 29
        Me.btnCreaClase.Text = "CargaClases"
        Me.btnCreaClase.UseVisualStyleBackColor = True
        '
        'cmbSQLDatabase
        '
        Me.cmbSQLDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSQLDatabase.FormattingEnabled = True
        Me.cmbSQLDatabase.Location = New System.Drawing.Point(74, 90)
        Me.cmbSQLDatabase.Name = "cmbSQLDatabase"
        Me.cmbSQLDatabase.Size = New System.Drawing.Size(121, 21)
        Me.cmbSQLDatabase.TabIndex = 28
        '
        'btnOpenSQL
        '
        Me.btnOpenSQL.Location = New System.Drawing.Point(243, 11)
        Me.btnOpenSQL.Name = "btnOpenSQL"
        Me.btnOpenSQL.Size = New System.Drawing.Size(45, 41)
        Me.btnOpenSQL.TabIndex = 27
        Me.btnOpenSQL.Text = "OpenSQL"
        Me.btnOpenSQL.UseVisualStyleBackColor = True
        '
        'txtUsuario
        '
        Me.txtUsuario.Location = New System.Drawing.Point(74, 38)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(100, 20)
        Me.txtUsuario.TabIndex = 31
        Me.txtUsuario.Text = "sa"
        '
        'txtContrasena
        '
        Me.txtContrasena.Location = New System.Drawing.Point(74, 61)
        Me.txtContrasena.Name = "txtContrasena"
        Me.txtContrasena.Size = New System.Drawing.Size(100, 20)
        Me.txtContrasena.TabIndex = 32
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Location = New System.Drawing.Point(12, 39)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(43, 13)
        Me.lblUsuario.TabIndex = 33
        Me.lblUsuario.Text = "Usuario"
        '
        'lblContrasena
        '
        Me.lblContrasena.AutoSize = True
        Me.lblContrasena.Location = New System.Drawing.Point(12, 69)
        Me.lblContrasena.Name = "lblContrasena"
        Me.lblContrasena.Size = New System.Drawing.Size(53, 13)
        Me.lblContrasena.TabIndex = 34
        Me.lblContrasena.Text = "Password"
        '
        'lblBase
        '
        Me.lblBase.AutoSize = True
        Me.lblBase.Location = New System.Drawing.Point(12, 94)
        Me.lblBase.Name = "lblBase"
        Me.lblBase.Size = New System.Drawing.Size(31, 13)
        Me.lblBase.TabIndex = 35
        Me.lblBase.Text = "Base"
        '
        'lblServidor
        '
        Me.lblServidor.AutoSize = True
        Me.lblServidor.Location = New System.Drawing.Point(12, 16)
        Me.lblServidor.Name = "lblServidor"
        Me.lblServidor.Size = New System.Drawing.Size(46, 13)
        Me.lblServidor.TabIndex = 36
        Me.lblServidor.Text = "Servidor"
        '
        'Button1
        '
        Me.Button1.Image = Global.WindowsApplication1.My.Resources.Resources.open_file_32
        Me.Button1.Location = New System.Drawing.Point(294, 10)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(41, 42)
        Me.Button1.TabIndex = 38
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmCargaBase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(338, 124)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblServidor)
        Me.Controls.Add(Me.lblBase)
        Me.Controls.Add(Me.lblContrasena)
        Me.Controls.Add(Me.lblUsuario)
        Me.Controls.Add(Me.txtContrasena)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.txtServer)
        Me.Controls.Add(Me.btnCreaClase)
        Me.Controls.Add(Me.cmbSQLDatabase)
        Me.Controls.Add(Me.btnOpenSQL)
        Me.Name = "frmCargaBase"
        Me.Text = "FormaCargaBase"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Private Sub btnOpenSQL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenSQL.Click
        Dim myCommand As SqlCommand
        Dim sdr As SqlDataReader

        myConnection = New SqlConnection("Data Source=" & Me.txtServer.Text & ";Uid=" & Me.txtUsuario.Text & ";Pwd=" & Me.txtContrasena.Text)
        myConnection.Open()

        myCommand = New SqlCommand()
        myCommand.Connection = myConnection

        myCommand.CommandType = CommandType.StoredProcedure
        myCommand.CommandText = "sp_databases"

        sdr = myCommand.ExecuteReader()

        While (sdr.Read())
            Me.cmbSQLDatabase.Items.Add(sdr.GetString(0))
        End While
        sdr.Close()
        myConnection.Close()
        If Me.cmbSQLDatabase.Items.Count > 0 Then
            Me.cmbSQLDatabase.SelectedIndex = 0
        End If

    End Sub

    Private Sub cmbSQLDatabase_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSQLDatabase.SelectedIndexChanged
        Dim myCommand As SqlCommand

        myConnection.Open()

        myCommand = New SqlCommand()
        myCommand.CommandText = "use " & cmbSQLDatabase.Text
        myCommand.Connection = myConnection
        myCommand.ExecuteNonQuery()
        userTables = New DataTable()
        userTables = myConnection.GetSchema("Tables")
        Dim n As Integer
        n = 0
        For n = 0 To userTables.Rows.Count - 1
            Tablas.Add(userTables.Rows(n)(2).ToString())
        Next

        myConnection.Close()

    End Sub

    Private Sub btnCreaClase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreaClase.Click

        If Me.cmbSQLDatabase.Items.Count Then
            FrmPrincipal.Tablas = Me.Tablas
            FrmPrincipal.sqlCon = Me.myConnection
            FrmPrincipal.baseDatos = Me.cmbSQLDatabase.Text
            FrmPrincipal.Show()
            FrmPrincipal.crearClases()
            Me.Close()
        Else
            MessageBox.Show("Conectese primero a una base de datos")
        End If

    End Sub

    Private Sub Forma_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.InitializeComponent()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim ofdBase As New OpenFileDialog
        Dim myCommand As SqlCommand
        Tablas = New List(Of String)

        ofdBase.ShowDialog()

        myConnection = New SqlConnection("Data Source=.\SQLEXPRESS;AttachDbFilename=" & ofdBase.FileName & ";Integrated Security=True;Connect Timeout=30;User Instance=True")
        myConnection.Open()

        myCommand = New SqlCommand()
        myCommand.CommandText = "SELECT * from information_schema.Tables"
        myCommand.Connection = myConnection
        myCommand.ExecuteNonQuery()
        userTables = New DataTable()
        userTables = myConnection.GetSchema("Tables")
        Dim n As Integer
        n = 0

        For n = 0 To userTables.Rows.Count - 1
            Tablas.Add(userTables.Rows(n)(2).ToString())
        Next
        myConnection.Close()

        FrmPrincipal.Tablas = Me.Tablas
        FrmPrincipal.sqlCon = Me.myConnection
        'FrmPrincipal.baseDatos = Me.cmbSQLDatabase.Text
        FrmPrincipal.Show()
        FrmPrincipal.crearClases()
        Me.Close()


    End Sub

End Class