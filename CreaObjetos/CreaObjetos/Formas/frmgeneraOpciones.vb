Imports System.IO
Public Class frmgeneraOpciones

    Private rdbOpciones(3) As RadioButton
    Private opcionSelecta As Integer
    Private _ManejaClases As List(Of ManejaClase)
    Private directorio As String
    Public Property manejaClases() As List(Of ManejaClase)
        Get
            Return Me._ManejaClases
        End Get
        Set(ByVal value As List(Of ManejaClase))
            Me._ManejaClases = value
        End Set
    End Property

    Private Sub btnGeneraClase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGeneraClase.Click
        Dim strCodigo As String
        Dim neimspace As String
        neimspace = ""
        While (neimspace.Equals(""))
            neimspace = InputBox("Que namespace deseas utilizar")
        End While

        'strCodigo = "imports system.data.Sqlclient" & vbCrLf
        'strCodigo &= "namespace " & neimspace & vbCrLf
        strCodigo = Me.procesaClases(neimspace) & vbCrLf
        'strCodigo &= "end namespace "

        Select Case opcionSelecta
            Case 0
                Clipboard.SetDataObject(strCodigo)
            Case 1
                Me.TextBox1.Text = strCodigo
            Case 2
                MessageBox.Show("Los archivos de clases han sido creados")
            Case 3
                Me.SaveTextToFile(strCodigo, Me.buscaDirectorio(), Me.nombraArchivo, "Jodeos")
                MessageBox.Show("El archivo de clases ha sido creado")
        End Select
    End Sub

    Private Sub ctlGeneraOpciones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim i As Integer
        Me.rdbOpciones(0) = Me.rdbClipboard
        Me.rdbOpciones(1) = Me.rdbTexto
        Me.rdbOpciones(2) = Me.rdbVarios
        Me.rdbOpciones(3) = Me.rdbArchivo

        For i = 0 To Me.rdbOpciones.Length - 1
            Me.rdbOpciones(i).Tag = New String("" & i)
            AddHandler Me.rdbOpciones(i).CheckedChanged, AddressOf escogeOpcion
        Next
        Me.rdbOpciones(0).Checked = True

    End Sub

    Private Sub escogeOpcion(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.opcionSelecta = CType(sender.Tag, Int32)
    End Sub

    Public Function procesaClases(ByVal spacename As String) As String
        Dim c As Integer
        Dim sclases As String
        Dim claces As New List(Of Clase)

        sclases = ""

        If Me.rdbVarios.Checked Then
            directorio = Me.buscaDirectorio
        End If

        For c = 0 To Me.manejaClases.Count - 1
            Dim mnjClsTemp As ManejaClase = Me.manejaClases(c)
            'Checa los atributos de las clases y agrega los checados

            If mnjClsTemp.chbIncluir.Checked Then
                Dim clastemp As New Clase

                'Inicializa propiedades de clase
                clastemp.llave = mnjClsTemp.Clase.llave
                clastemp.NombreTabla = mnjClsTemp.Clase.NombreTabla

                'inicializa Lista de campos
                clastemp.Campos = New List(Of Propiedad)
                Dim indexChecked As Integer
                For Each indexChecked In mnjClsTemp.clbCampos.CheckedIndices
                    clastemp.Campos.Add(mnjClsTemp.Clase.Campos(indexChecked))
                Next




                If Me.rdbVarios.Checked Then
                    If Me.rdbWapl.Checked Then
                        sclases &= Me.VariosArchivosAppl(spacename, clastemp)
                    ElseIf Me.rdbASP.Checked Then
                        sclases &= Me.VariosArchivosASP(spacename, clastemp)
                    End If

                End If

            End If

        Next

        Return sclases
    End Function
    Public Function VariosArchivosASP(ByVal spacename As String, ByVal clastemp As Clase) As String
        Dim sclases As String = String.Empty

        If Me.chkClasesASP.Checked Then
            Dim gnrDsn As New generaPagina
            Dim gnrCdPg As New generaCodPagina
            'Dise�o
            gnrDsn.neimespeis = spacename
            gnrDsn.clace = clastemp
            'Pagina
            gnrCdPg.neimespeis = spacename
            gnrCdPg.clace = clastemp
            Me.SaveTextToFile(gnrDsn.generaPagina, directorio & "\Views", clastemp.NombreTabla & "View.aspx", "Jodeos")
            Me.SaveTextToFile(gnrCdPg.generaForma, directorio & "\Views", clastemp.NombreTabla & "View.aspx.vb", "Jodeos")
        End If

        If Me.chkManejador.Checked Then
            Dim gnrCdPg As New generaCodPagina
            'Pagina
            gnrCdPg.neimespeis = spacename
            gnrCdPg.clace = clastemp
            Me.SaveTextToFile(gnrCdPg.generaForma, directorio & "\Views", clastemp.NombreTabla & "View.aspx.vb", "Jodeos")
        End If


        If Me.chkClases.Checked Then
            Dim genera As New GeneraClaseASP

            genera.clase = clastemp
            genera.neimespeis = spacename
            sclases &= genera.GeneraClase()

            Me.SaveTextToFile(genera.GeneraClase(), directorio & "\Models", clastemp.nombre & ".vb", "Jodeos")
        End If
        Return sclases
    End Function
    Public Function VariosArchivosAppl(ByVal spacename As String, ByVal clastemp As Clase) As String
        Dim sclases As String = String.Empty
        If Me.chkInterfaz.Checked Then
            Dim gnrDsn As New generaDiseno
            Dim gnrFrm As New generaForma
            'Dise�o
            gnrDsn.neimespeis = spacename
            gnrDsn.clace = clastemp
            'Forma
            gnrFrm.neimespeis = spacename
            gnrFrm.clace = clastemp
            Me.SaveTextToFile(gnrFrm.generaForma, directorio & "/Views/", "Frm" & clastemp.NombreTabla, "Jodeos")
            Me.SaveTextToFile(gnrDsn.generaDiseno, directorio & "/Views/", "Frm" & clastemp.NombreTabla & ".designer", "Jodeos")
        End If

        If Me.chkManejador.Checked Then
            Dim gnrMnj As New generaManejador
            ''Manejador
            gnrMnj.neimespeis = spacename
            gnrMnj.clace = clastemp
            ''Clase
            Me.SaveTextToFile(gnrMnj.generaManeja, directorio & "/Actions/", "maneja" & clastemp.NombreTabla & ".vb", "Jodeos")
        End If


        If Me.chkClases.Checked Then
            Dim genera As New GeneraClase
            genera.clase = clastemp
            genera.neimespeis = spacename
            sclases &= genera.GeneraClase()
            Me.SaveTextToFile(genera.GeneraClase(), directorio & "/Models/", clastemp.nombre & ".vb", "Jodeos")
        End If
        Return sclases
    End Function

    Public Function SaveTextToFile(ByVal strData As String, _
    ByVal FullPath As String, _
    ByVal nombreArchivo As String, _
 Optional ByVal ErrInfo As String = "") As Boolean

        If Not My.Computer.FileSystem.DirectoryExists(FullPath) Then
            My.Computer.FileSystem.CreateDirectory(FullPath)
        End If
        Dim bAns As Boolean = False

        Dim objReader As StreamWriter
        Try
            objReader = New StreamWriter(FullPath & "\" & nombreArchivo)
            objReader.Write(strData)
            objReader.Close()
            bAns = True
        Catch Ex As Exception
            ErrInfo = Ex.Message
        End Try
        Return bAns
    End Function
    Public Function buscaDirectorio() As String
        Dim fbdCodigo As New FolderBrowserDialog
        fbdCodigo.RootFolder = Environment.SpecialFolder.Desktop
        ' Select the C:\Windows directory on entry.
        fbdCodigo.SelectedPath = "c:\"
        ' Prompt the user with a custom message.
        fbdCodigo.Description = "Select the source directory"
        fbdCodigo.ShowDialog()

        Return fbdCodigo.SelectedPath
    End Function
    Public Function nombraArchivo() As String
        Dim sarchivo As New String("")
        While (sarchivo.Equals(""))
            sarchivo = InputBox("Como quiero que se llame el archivo de Salida")
        End While
        Return sarchivo
    End Function



    Private Sub rdbWapl_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbWapl.CheckedChanged
        Me.ActivaChkCodigo(Me.rdbWapl.Checked)
    End Sub


    Private Sub ActivaChkCodigo(ByVal Activado As Boolean)
        Me.chkPagina.Visible = Not Activado
        Me.chkClasesASP.Visible = Not Activado
        Me.chkMngASP.Visible = Not Activado

        Me.chkClases.Visible = Activado
        Me.chkInterfaz.Visible = Activado
        Me.chkManejador.Visible = Activado

    End Sub
End Class


