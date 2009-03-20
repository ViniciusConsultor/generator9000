Public Class Relacion

    Private _campo As String
    Private _Tabla As String
    Private _tipo As Integer

    Public Property Tabla() As String
        Get
            Return Me._Tabla
        End Get
        Set(ByVal value As String)
            Me._Tabla = value
        End Set
    End Property

    Public Property campo() As String
        Get
            Return Me._campo
        End Get
        Set(ByVal value As String)
            Me._campo = value
        End Set
    End Property

    Public Property tipo() As Integer
        Get
            Return Me._tipo
        End Get
        Set(ByVal value As Integer)
            Me._tipo = value
        End Set
    End Property
End Class
