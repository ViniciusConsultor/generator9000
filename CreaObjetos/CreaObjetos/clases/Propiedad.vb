Public Class Propiedad
    Private _nombre As String
    Private _tipo As String
    Private _isNull As Boolean
    Public Property Nombre() As String
        Get
            Return Me._nombre
        End Get
        Set(ByVal value As String)
            Me._nombre = value
        End Set
    End Property

    Public Property Tipo() As String
        Get
            Return Me._tipo
        End Get
        Set(ByVal value As String)
            Me._tipo = value
        End Set
    End Property
    Public Property isNull() As Boolean
        Get
            Return Me._isNull
        End Get
        Set(ByVal value As Boolean)
            Me._isNull = value
        End Set
    End Property
    Public ReadOnly Property titulo() As String
        Get
            Return Me.Nombre.Substring(0, 1).ToUpper() & Me.Nombre.Substring(1, Me.Nombre.Length - 1)
        End Get
    End Property
    Public ReadOnly Property abreValida() As String
        Get
            Dim abreValidas() As String = {"", "ValNulosInt(", "ValNulosInt(", "ValidaFecha(Ctype(", "Ctype(", "ValNulosInt(", "", "Byte()"}
            Dim ind As Integer = Me.dameTipo()
            If ind >= 0 Then
                Return abreValidas(ind)
            End If
            Return ""
        End Get
    End Property

    Public ReadOnly Property cierraValida() As String
        Get
            Dim tiposVB() As String = {"string", "Integer", "Decimal", "datetime", "boolean", "double", "string", "Byte()"}
            Dim cierraValidas() As String = {".Text.Length > 0", ") > 0 ", "ValNulosInt(", "ValidaFecha(Ctype(", "Ctype(", "ValNulosInt(", "", "Byte()"}
            Dim ind As Integer = Me.dameTipo()
            If ind >= 0 Then
                Return cierraValidas(ind)
            End If
            Return ""
        End Get
    End Property
    Public ReadOnly Property tipoControl() As String
        Get
            Dim tiposCtl() As String = {"txt", "txt", "txt", "dtp", "chb", "txt", "txt", "fbw", "pcb", "txt"}
            Dim ind As Integer = Me.dameTipo()
            If ind >= 0 Then
                Return tiposCtl(ind)
            End If
            Return ""

        End Get
    End Property
    Public ReadOnly Property nombreControl() As String
        Get
            Dim tiposCtl() As String = {"TextBox", "TextBox", "TextBox", "DateTimePicker", _
            "CheckBox", "TextBox", "TextBox", "fbw", "PictureBox", "TextBox"}
            Dim ind As Integer = Me.dameTipo()
            If ind >= 0 Then
                Return tiposCtl(ind)
            End If
            Return ""

        End Get
    End Property
    Public Function dameTipo() As Integer
        Dim tiposSql As New List(Of String)
        tiposSql.add("varchar")
        tiposSql.Add("int")
        tiposSql.Add("money")
        tiposSql.Add("datetime")
        tiposSql.Add("bit")
        tiposSql.Add("float")
        tiposSql.Add("nvarchar")
        tiposSql.Add("varbinary")
        tiposSql.Add("image")
        tiposSql.Add("text")
        Return tiposSql.IndexOf(Me.Tipo)
        Return -1
    End Function
    Public Function convertipoVB(ByVal tipo As String) As String
        Dim indTipo As Integer = Me.dameTipo()
        Dim tiposVB() As String = {"string", "Integer", "Decimal", "datetime", "boolean", "double", "string", "Byte()", "Byte()", "String"}

        If indTipo >= 0 Then
            Return tiposVB(indTipo)
        End If
        Return ""
    End Function
    Public Function tipoVB() As String
        
        Return convertipoVB(Me.Tipo)
    End Function

End Class
