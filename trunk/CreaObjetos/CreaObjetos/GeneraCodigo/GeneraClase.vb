Public Class GeneraClase
    Private claseStr As String
    Public clase As Clase
    Public neimespeis As String
    
    Public Function GeneraClase() As String
        Dim str As String
		str = "Microsoft.VisualBasic" & vbCrLf
        str &= "Imports system.data.sqlClient" & vbCrLf
        str &= "Namespace " & neimespeis & vbCrLf
        str &= "Public Class " & clase.nombre & vbCrLf
        If clase.Campos.Count > 0 Then
            str &= GeneraCampos()
            str &= GeneraPropiedades()
            str &= GeneraMetodos()
        End If
        str &= "End Class" & vbCrLf & vbCrLf
        str &= "End namespace"
        Return str
    End Function
    Private Function GeneraCampos() As String
        Dim str As String
        Dim i As Integer
        str = ""
        For i = 0 To clase.Campos.Count - 1
            str &= "Private _" & clase.Campos(i).Nombre & " As " & clase.Campos(i).tipoVB() & vbCrLf
        Next
        Return str
    End Function
    Private Function GeneraPropiedades() As String
        Dim str As String
        Dim i As Integer
        str = ""
        For i = 0 To clase.Campos.Count - 1
            str &= "Public Property " & clase.Campos(i).Nombre & " As " & clase.Campos(i).tipoVB() & vbCrLf
            str &= " Get " & vbCrLf
            str &= " Return Me._" & clase.Campos(i).Nombre & vbCrLf
            str &= "End Get" & vbCrLf
            str &= "Set(ByVal value As " & clase.Campos(i).tipoVB() & ")" & vbCrLf
            str &= "Me._" & clase.Campos(i).Nombre & " = value" & vbCrLf
            str &= "End Set" & vbCrLf
            str &= "End Property" & vbCrLf
        Next
        Return str
    End Function
    Private Function GeneraMetodos() As String
        Dim str As String
        str = ""
        str = GeneraInicializa()
        str &= generaCargar()
        str &= generaActualizar()
        str &= generaGuardar()
        str &= Me.generaBorrar()
        str &= Me.generaCargaUltimo()
        str &= Me.generaBuscar()
        Return str
    End Function
    Private Function generaInicializa() As String
        Dim str As String
        Dim i As Integer
        str = ""
        Str &= "Public Sub Asignar(ByVal sqlRead as SqlDataReader)" & vbCrLf
        For i = 0 To Clase.Campos.Count - 1
            str &= "Me." & clase.Campos(i).Nombre & "= SqlRead(""" & clase.Campos(i).Nombre & """ )" & vbCrLf
        Next
        Str &= "End Sub" & vbCrLf
        Return str
    End Function
    Private Function generaCargar() As String
        Dim str As String
        Dim i As Integer
        Dim query As String
        Dim campos As String
        str = ""
        str &= "Public Sub Cargar() " & vbCrLf

        str &= "Dim mcn As New MiConexion()" & vbCrLf
        str &= "Dim conn As SqlConnection = mcn.sqlConnection" & vbCrLf
        str &= "Dim sqlRead As SqlDataReader" & vbCrLf
        str &= "Dim sqlCommand As New SqlCommand()" & vbCrLf
        str &= "sqlCommand.Connection = conn" & vbCrLf

        campos = "SELECT "
        For i = 0 To clase.Campos.Count - 1
            campos &= clase.Campos(i).Nombre
            If i <> clase.Campos.Count - 1 Then campos &= ","
        Next
        query = ""
        query &= campos & " FROM " & clase.NombreTabla
        query &= " WHERE " & clase.llave & "=@" & clase.llave


        str &= "Dim sqlString = """ & query & """" & vbCrLf
        str &= "sqlCommand.Parameters.Add(""@" & clase.llave & """, Data.SqlDbType.Int)" & vbCrLf
        str &= "sqlCommand.Parameters(""@" & clase.llave & """).Value = Me." & clase.llave & vbCrLf
        str &= "sqlCommand.CommandText = sqlString" & vbCrLf

        str &= "conn.Open()" & vbCrLf
        str &= "sqlRead = sqlCommand.ExecuteReader()" & vbCrLf
        str &= "If sqlRead.Read() Then" & vbCrLf
        str &= "Me.Asignar(sqlRead)" & vbCrLf
        str &= "End If" & vbCrLf
        str &= "sqlRead.Close()" & vbCrLf
        str &= "conn.Close()" & vbCrLf

        str &= "End Sub" & vbCrLf
        Return str
    End Function

    Private Function generaBuscar() As String
        Dim str As String
        Dim i As Integer
        Dim query As String
        Dim campos As String
        str = ""
        str &= "Public Function Busca" & Me.clase.NombreTabla & "(byval tipo as integer, byval busq as string) as List(of " & Me.clase.nombre & ")" & vbCrLf
        str &= "Dim " & Me.clase.NombreTabla & " As new List(of " & Me.clase.nombre & ")" & vbCrLf
        str &= "Dim mcn As New MiConexion()" & vbCrLf
        str &= "Dim conn As SqlConnection = mcn.sqlConnection" & vbCrLf
        str &= "Dim sqlRead As SqlDataReader" & vbCrLf
        str &= "Dim sqlCommand As New SqlCommand()" & vbCrLf
        str &= "sqlCommand.Connection = conn" & vbCrLf

        campos = "SELECT "
        For i = 0 To clase.Campos.Count - 1
            campos &= clase.Campos(i).Nombre
            If i <> clase.Campos.Count - 1 Then campos &= ","
        Next
        query = ""
        query &= campos & " FROM " & clase.NombreTabla
        


        str &= "Dim sqlString = """ & query & """" & vbCrLf
		str & = "SELECT tipo "& vbCrLf
		str & = "case 0  'Todos" & vbCrLf
		str & = "case 1 'Por id" & vbCrLf
		str & "sqlString &= "" WHERE " & clase.llave & "=@" & clase.llave & """" & vbCrLf
		str &= "sqlCommand.Parameters.Add(""@" & clase.llave & """, Data.SqlDbType.Int)" & vbCrLf
        str &= "sqlCommand.Parameters(""@" & clase.llave & """).Value = Me." & clase.llave & vbCrLf
		str & = "END SELECT  "& vbCrLf
		
		
        str &= "sqlCommand.CommandText = sqlString" & vbCrLf

        str &= "conn.Open()" & vbCrLf
        str &= "sqlRead = sqlCommand.ExecuteReader()" & vbCrLf
        str &= "While sqlRead.Read() " & vbCrLf
        str &= "Dim " & Me.clase.nombre.Substring(0, 3) & " As New " & Me.clase.nombre & vbCrLf
        str &= Me.clase.nombre.Substring(0, 3) & ".Asignar(sqlRead)" & vbCrLf
        str &= Me.clase.NombreTabla & ".Add(" & Me.clase.nombre.Substring(0, 3) & ")" & vbCrLf
        str &= "End While" & vbCrLf
        str &= "sqlRead.Close()" & vbCrLf
        str &= "conn.Close()" & vbCrLf
        str &= "Return " & Me.clase.NombreTabla & vbCrLf
        str &= "End Function" & vbCrLf
        Return str
    End Function
    Public Function generaActualizar() As String


        Dim str As String
        Dim i As Integer
        Dim query As String
        Dim campos As String
        str = ""
        str &= "Public Sub Actualizar() " & vbCrLf
        str &= "Dim mcn As New MiConexion()" & vbCrLf
        str &= "Dim conn As SqlConnection = mcn.sqlConnection" & vbCrLf


        query = ""
        campos = ""


        For i = 1 To clase.Campos.Count - 1
            campos &= clase.Campos(i).Nombre & "= @" & clase.Campos(i).Nombre
            If i <> clase.Campos.Count - 1 Then
                campos &= ","
            End If

        Next


        query &= "UPDATE " & Me.clase.NombreTabla & " SET " & campos

        query &= " WHERE " & clase.llave & "=@" & clase.llave

        str &= "Dim sqlString As String =""" & query & """" & vbCrLf
        str &= "Dim sqlCommand As New SqlCommand(sqlString, conn)" & vbCrLf
        str &= "conn.Open()" & vbCrLf

        For i = 0 To clase.Campos.Count - 1
            str &= "sqlCommand.Parameters.Add(""@" & clase.Campos(i).Nombre & """, Data.SqlDbType." & clase.Campos(i).Tipo & ")" & vbCrLf
        Next

        For i = 0 To clase.Campos.Count - 1
            str &= "  sqlCommand.Parameters(""@" & clase.Campos(i).Nombre & """).Value = Me." & clase.Campos(i).Nombre & vbCrLf
        Next

        str &= "sqlCommand.ExecuteNonQuery()" & vbCrLf
        str &= "conn.Close()" & vbCrLf
        str &= "End Sub" & vbCrLf

        Return str

    End Function
    Public Function generaGuardar() As String


        Dim str As String
        Dim i As Integer
        Dim query As String
        Dim campos, params As String
        str = ""
        str &= "Public Sub Guardar() " & vbCrLf
        str &= "Dim mcn As New MiConexion()" & vbCrLf
        str &= "Me. " & Me.clase.llave & " = mcn.DameUltimoID(""" & Me.clase.llave & """, """ & Me.clase.NombreTabla & """) + 1" & vbCrLf
        str &= "Dim conn As SqlConnection = mcn.sqlConnection" & vbCrLf


        query = ""
        campos = ""
        params = ""

        For i = 0 To clase.Campos.Count - 1
            campos &= clase.Campos(i).Nombre
            params &= "@" & clase.Campos(i).Nombre
            If i <> clase.Campos.Count - 1 Then
                campos &= ","
                params &= ","
            End If

        Next


        query &= "INSERT INTO " & Me.clase.NombreTabla & " (" & campos & ") VALUES (" & params & ")"

        str &= "Dim sqlString As String =""" & query & """" & vbCrLf
        str &= "Dim sqlCommand As New SqlCommand(sqlString, conn)" & vbCrLf
        str &= "conn.Open()" & vbCrLf

        For i = 0 To clase.Campos.Count - 1
            str &= "sqlCommand.Parameters.Add(""@" & clase.Campos(i).Nombre & """, Data.SqlDbType." & clase.Campos(i).Tipo & ")" & vbCrLf
        Next

        For i = 0 To clase.Campos.Count - 1
            str &= "  sqlCommand.Parameters(""@" & clase.Campos(i).Nombre & """).Value = Me." & clase.Campos(i).Nombre & vbCrLf
        Next

        str &= "sqlCommand.ExecuteNonQuery()" & vbCrLf
        str &= "conn.Close()" & vbCrLf
        str &= "End Sub" & vbCrLf

        Return str

    End Function
    Private Function generaBorrar() As String
        Dim str As String

        Dim query As String

        str = ""
        str &= "Public Sub Borrar() " & vbCrLf

        str &= "Dim mcn As New MiConexion()" & vbCrLf
        str &= "Dim conn As SqlConnection = mcn.sqlConnection" & vbCrLf

        str &= "Dim sqlCommand As New SqlCommand()" & vbCrLf
        str &= "sqlCommand.Connection = conn" & vbCrLf

        query = "DELETE FROM " & clase.NombreTabla
        query &= " WHERE " & clase.llave & "=@" & clase.llave


        str &= "Dim sqlString = """ & query & """" & vbCrLf
        str &= "sqlCommand.Parameters.Add(""@" & clase.llave & """, Data.SqlDbType.Int)" & vbCrLf
        str &= "sqlCommand.Parameters(""@" & clase.llave & """).Value = Me." & clase.llave & vbCrLf
        str &= "sqlCommand.CommandText = sqlString" & vbCrLf

        str &= "conn.Open()" & vbCrLf
        str &= " sqlCommand.ExecuteNonQuery()" & vbCrLf
        str &= "conn.Close()" & vbCrLf

        str &= "End Sub" & vbCrLf
        Return str
    End Function
    Public Function generaCargaUltimo() As String
        Dim str As String
        str = ""
        str &= "Public Sub CargaUltimo " & vbCrLf
        str &= "Dim mcn As New MiConexion()" & vbCrLf
        str &= "Me. " & Me.clase.llave & " = mcn.DameUltimoID(""" & Me.clase.llave & """, """ & Me.clase.NombreTabla & """)" & vbCrLf
        str &= "Me.cargar()" & vbCrLf
        str &= "End sub " & vbCrLf


        Return str

    End Function
End Class
