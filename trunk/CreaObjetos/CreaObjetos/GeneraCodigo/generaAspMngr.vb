Public Class generaAspMngr
    Public neimespeis As String

    Public clace As Clase

    Public Function generaManeja() As String
        Dim codigo As String
        codigo = "Imports System.Data" & vbCrLf
        codigo &= "Imports " & Me.neimespeis & "." & Me.neimespeis & vbCrLf
        codigo &= "Namespace " & Me.neimespeis & vbCrLf
        codigo &= "Public Class maneja" & Me.clace.NombreTabla & vbCrLf
        codigo &= "Public " & Me.clace.NombreTabla & " As New List(Of " & Me.clace.nombre & ")" & vbCrLf
        codigo &= "Public " & Me.clace.nombre.Substring(0, 3) & "Act As New " & Me.clace.nombre & vbCrLf



        codigo &= "Partial Class " & Me.clace.NombreTabla & vbCrLf
        codigo &= "Inherits System.Web.UI.Page" & vbCrLf
        codigo &= "#Region "" Web Form Designer Generated Code """ & vbCrLf
        codigo &= "'This call is required by the Web Form Designer." & vbCrLf
        codigo &= "<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()" & vbCrLf

        codigo &= "End Function" & vbCrLf

        codigo &= "Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init" & vbCrLf
        codigo &= "'CODEGEN: This method call is required by the Web Form Designer" & vbCrLf
        codigo &= "'Do not modify it using the code editor." & vbCrLf
        codigo &= "InitializeComponent()" & vbCrLf
        codigo &= "End Function" & vbCrLf

        codigo &= Me.creaChecaCampos()
        codigo &= Me.creaActualizaRegistro()
        codigo &= Me.creaAddHandler()
        codigo &= Me.creaAgregaBusquedas()
        codigo &= Me.creaBorraRegistro()
        codigo &= Me.creaBuscarPor()
        codigo &= Me.creaCamposCargados()
        codigo &= Me.creaCargarDatos()
        codigo &= Me.creaDameRegistro()
        codigo &= Me.creaDameUltimo()
        codigo &= Me.creaGuardaRegistro()
        codigo &= Me.creaIniciar()
        codigo &= Me.creaValidaCaptura()
        codigo &= Me.creaValidaClave()
        codigo &= Me.creaUltimoIndice()
        codigo &= "End Class" & vbCrLf
        codigo &= "End NameSpace"
        Return codigo
    End Function
    Public Function creaChecaCampos() As String
        Dim atributo As Propiedad
        Dim codigo As String
        codigo = "Public Overrides Sub ChecaCampos()" & vbCrLf

        codigo &= "Dim campos() As String = {"""
        For Each atributo In clace.Campos
            If Not atributo.isNull Then
                If Not clace.Campos.IndexOf(atributo) = 0 Then
                    codigo &= ", """
                End If
                codigo &= atributo.Nombre & """"
            End If
        Next
        codigo &= "}" & vbCrLf

        codigo &= "Dim CapVal As Integer" & vbCrLf
        codigo &= "CapVal = Me.ValidaCaptura" & vbCrLf
        codigo &= "If CapVal = 0 Then" & vbCrLf
        codigo &= "Me.ctlMaestro.btnAltas.Enabled = True" & vbCrLf
        codigo &= "Else" & vbCrLf
        codigo &= "Me.dameControl(""lblFalta"").Text = ""llenar campo"" & campos(CapVal - 1)" & vbCrLf
        codigo &= "End If" & vbCrLf
        codigo &= "End Sub" & vbCrLf
        Return codigo
    End Function
    Public Function creaValidaCaptura() As String
        Dim atributo As Propiedad
        Dim index As Integer
        Dim codigo As String
        codigo = "Public Overrides Function ValidaCaptura() As Integer" & vbCrLf
        Dim abrevalida As String = "valNulosInt("
        Dim tipoControl As String = "txt"
        Dim cierraValida As String = """).Text) > 0"
        For Each atributo In clace.Campos
            codigo &= "If Not " & abrevalida & "Me.DameControl(""" & tipoControl
            codigo &= atributo.Nombre & cierraValida & " Then return " & index & vbCrLf
        Next


        codigo &= "Return 0" & vbCrLf
        codigo &= "End Function" & vbCrLf

        Return codigo
    End Function
    Public Function creaAgregaBusquedas() As String
        Dim codigo As String
        codigo = "    Public Overrides Sub AgregaBusquedas()" & vbCrLf
        codigo &= "Dim ibusq As Integer" & vbCrLf

        codigo &= "Me.ctlBusq.strBusquedas.Add(""Todos"")" & vbCrLf
        codigo &= "Me.ctlBusq.strBusquedas.Add(""clave"")" & vbCrLf
        codigo &= "Me.ctlBusq.strBusquedas.Add(""Nombre"")" & vbCrLf

        codigo &= "For ibusq = 0 To Me.ctlBusq.strBusquedas.Count - 1" & vbCrLf
        codigo &= "Dim tls As ToolStripItem = Me.ctlBusq.btnBuscar.DropDownItems.Add(Me.ctlBusq.strBusquedas(ibusq))" & vbCrLf
        codigo &= "tls.Tag = ibusq" & vbCrLf
        codigo &= "AddHandler tls.Click, AddressOf Me.ctlBusq.defineTipoBusqueda" & vbCrLf
        codigo &= "Next" & vbCrLf
        codigo &= "Me.ctlBusq.btnBuscar.Text = ""Todos""" & vbCrLf
        codigo &= "Me.ctlBusq.iBusqueda = 0" & vbCrLf
        codigo &= "End Sub" & vbCrLf
        Return codigo
    End Function
    Public Function creaAddHandler() As String
        Dim codigo As String
        codigo = "Public Overrides Sub AddHandlers()" & vbCrLf
        codigo &= " MyBase.AddHandlers()" & vbCrLf

        For Each atr As Propiedad In clace.Campos
            If Not atr.isNull Then
                codigo &= " AddHandler Me.dameControl(""txt" & atr.Nombre & """).LostFocus, AddressOf revisaCampos" & vbCrLf
            End If
        Next


        codigo &= "End Sub" & vbCrLf
        Return codigo
    End Function
    Public Function creaCamposCargados() As String
        Dim codigo As String
        codigo = "Public Overrides Function camposCargados() As Integer" & vbCrLf
        codigo &= "Return Me." & Me.clace.NombreTabla & ".Count " & vbCrLf
        codigo &= "End Function" & vbCrLf
        Return codigo
    End Function
    Public Function creaActualizaRegistro() As String
        Dim codigo As String
        codigo = "Public Overrides Sub ActualizaRegistro()" & vbCrLf
        codigo &= "Me.dameRegistro()" & vbCrLf
        codigo &= "Me." & Me.RegAct & ".Actualizar()" & vbCrLf
        codigo &= "End Sub" & vbCrLf
        Return codigo
    End Function
    Public Function creaBorraRegistro() As String
        Dim codigo As String
        codigo = "Public Overrides Sub BorraRegistro()" & vbCrLf
        codigo &= "Me." & Me.RegCol & ".Remove(" & Me.RegAct & ")" & vbCrLf
        codigo &= "Me." & Me.RegAct & ".Borrar()" & vbCrLf
        codigo &= "End Sub" & vbCrLf
        Return codigo
    End Function
    Public Function creaGuardaRegistro() As String
        Dim codigo As String
        codigo = "Public Overrides Sub guardaRegistro()" & vbCrLf
        codigo &= "Me.dameRegistro()" & vbCrLf
        codigo &= "Me." & Me.RegAct & ".Guardar()" & vbCrLf
        codigo &= "End Sub" & vbCrLf

        Return codigo
    End Function
    Public Function creaValidaClave() As String
        Dim codigo As String
        codigo = "Public Overrides Function ValidaClave() As Boolean" & vbCrLf
        codigo &= "Return True" & vbCrLf
        codigo &= "End Function" & vbCrLf
        Return codigo
    End Function
    Public Function creaDameRegistro() As String
        Dim codigo As String
        codigo = "Public Overrides Sub dameRegistro()" & vbCrLf

        For Each atr As Propiedad In clace.Campos

            If Not atr.Nombre.Substring(atr.Nombre.Length - 3, 3).Equals("_id") And _
             Not atr.Nombre.Equals(clace.llave) Then

                codigo &= "Me." & Me.RegAct & "." & atr.Nombre & _
                                " = Me.dameControl(""" & atr.tipoControl() & atr.Nombre & """).Text" & vbCrLf
            Else
                codigo &= "Me." & Me.RegAct & "." & atr.Nombre & _
                          " = Me.dameComboBox(""cmb" & atr.Nombre & """).SelectedValue" & vbCrLf
            End If

        Next
        codigo &= "End Sub" & vbCrLf
        Return codigo
    End Function

    Public Function creaBuscarPor() As String
        Dim codigo As String
        codigo = "Public Overrides Sub BuscarPor()" & vbCrLf
        codigo &= "If Len(Trim(Me.ctlBusq.txtbusq.Text)) > 0 Then" & vbCrLf
        codigo &= "Dim " & Me.clace.nombre.Substring(0, 3) & " As New " & Me.clace.nombre & vbCrLf
        codigo &= "Me." & Me.clace.NombreTabla & " = " & Me.clace.nombre.Substring(0, 3)
        codigo &= ".busca" & Me.clace.NombreTabla & "(Me.ctlBusq.iBusqueda, Me.ctlBusq.txtbusq.Text)" & vbCrLf
        codigo &= "Me.ctlBusq.LlenaDT()" & vbCrLf
        codigo &= "Else" & vbCrLf
        codigo &= "MsgBox(""Se Requieren Datos Para la Busqueda"", MsgBoxStyle.OkOnly)" & vbCrLf
        codigo &= "End If" & vbCrLf
        codigo &= "End Sub" & vbCrLf

        Return codigo
    End Function
    Public Function creaCargarDatos() As String
        Dim codigo As String
        codigo = "Public Overrides Sub CargarDatos(ByVal indice As Integer)" & vbCrLf
        codigo &= "Me." & Me.RegAct & "= Me." & Me.clace.NombreTabla & "(indice)" & vbCrLf

        For Each atr As Propiedad In clace.Campos

            If Not atr.Nombre.Substring(atr.Nombre.Length - 3, 3).Equals("_id") _
            Or Me.clace.llave.Equals(atr.Nombre) Then
                codigo &= "Me.dameControl(""" & atr.tipoControl() & atr.Nombre & """).Text ="
                codigo &= "Me." & Me.RegAct & "." & atr.Nombre & vbCrLf
            Else
                codigo &= " Me.dameComboBox(""cmb" & atr.Nombre & """).SelectedValue"
                codigo &= "= Me." & Me.RegAct & "." & atr.Nombre & vbCrLf
            End If

        Next
        codigo &= "End Sub" & vbCrLf
        Return codigo
    End Function
    Public Function creaDameUltimo() As String
        Dim codigo As String
        codigo = "Public Overrides Sub DameUltimo()" & vbCrLf
        codigo &= "Me." & Me.RegAct & ".cargaUltimo()" & vbCrLf
        codigo &= "If Me." & Me.clace.NombreTabla & ".IndexOf(Me." & Me.RegAct & ") = -1 Then" & vbCrLf
        codigo &= "Me." & Me.clace.NombreTabla & ".Add(Me." & Me.RegAct & ")" & vbCrLf
        codigo &= "End If" & vbCrLf
        codigo &= "Me.CargarDatos(0)" & vbCrLf
        codigo &= "End Sub" & vbCrLf
        Return codigo
    End Function
    Public Function creaUltimoIndice() As String
        Dim codigo As String
        codigo = "Public Overrides Function UltimoIndice() As Integer" & vbCrLf
        codigo &= "Dim mcn As New MiConexion" & vbCrLf
        codigo &= "Me.dameControl(""txt" & Me.clace.llave & """).Text = "
        codigo &= " mcn.DameUltimoID(""" & Me.clace.llave & """, """ & Me.clace.NombreTabla & " "") + 1" & vbCrLf
        codigo &= "Return 0" & vbCrLf
        codigo &= "End Function" & vbCrLf
        Return codigo
    End Function
    Public Function creaIniciar() As String
        Dim codigo As String
        codigo = "Public Overrides Sub iniciar()" & vbCrLf
        codigo &= "Me.nombreClase = """ & Me.clace.nombre & vbCrLf
        codigo &= "MyBase.iniciar()" & vbCrLf
        codigo &= "Me.ctlBusq.txtbusq.Text = ""Todos""" & vbCrLf
        codigo &= "Me.BuscarPor()" & vbCrLf
        codigo &= "End Sub" & vbCrLf

        Return codigo
    End Function

    Public Function RegCol() As String
        Return Me.clace.NombreTabla
    End Function
    Public Function RegAct() As String
        Return Me.clace.nombre.Substring(0, 3) & "Act"
    End Function
End Class
