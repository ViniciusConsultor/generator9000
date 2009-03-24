Imports System.Data.SqlClient

Public Class Clase

    Private _campos As List(Of Propiedad)
    Private _llave As String
    Private _nombreTabla As String
    Private _sqlCon As SqlConnection
    Private _Relaciones As List(Of Relacion)
    Private _neim As String

    Public Property Campos() As List(Of Propiedad)
        Get
            Return Me._campos
        End Get
        Set(ByVal value As List(Of Propiedad))
            Me._campos = value
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

    Public Property NombreTabla() As String
        Get
            Return Me._nombreTabla
        End Get
        Set(ByVal value As String)
            Me._nombreTabla = value
        End Set
    End Property
    Public Property Neim() As String
        Get
            Return Me._neim
        End Get
        Set(ByVal value As String)
            Me._neim = value
        End Set
    End Property
    Public Property llave() As String
        Get
            Return Me._llave
        End Get
        Set(ByVal value As String)
            Me._llave = value
        End Set
    End Property

    Public Property Relaciones() As List(Of Relacion)
        Get
            Return Me._Relaciones
        End Get
        Set(ByVal value As List(Of Relacion))
            Me._Relaciones = value
        End Set
    End Property

    Public Sub cargaAtributos()
        Me.Campos = New List(Of Propiedad)
        Me.sqlCon.Open()
        Dim sdr As SqlDataReader
        Dim myCommand As New SqlCommand

        myCommand.Connection = Me.sqlCon
        '        myCommand.CommandText = "use " & cmbSQLDatabase.Text & " select * from " & ComboBox2.Text
        myCommand.CommandText = " select * from information_schema.Columns" & _
                               " WHERE table_name =@table_name" & _
                               " ORDER By ORDINAL_POSITION"
        myCommand.Parameters.Add("@table_name", SqlDbType.VarChar)
        myCommand.Parameters("@table_name").Value = Me.NombreTabla

        sdr = myCommand.ExecuteReader
        While (sdr.Read)
            Dim prop As New Propiedad
            prop.Nombre = sdr.Item("COLUMN_NAME")
            prop.Tipo = sdr.Item("DATA_TYPE")
            prop.isNull = sdr.Item("IS_NULLABLE").Equals("YES")
            Me.Campos.Add(prop)
        End While
        If Me.Campos.Count > 0 Then
            Me.llave = ""
            Me.llave = Campos(0).Nombre
        End If
        sdr.Close()
        Me.sqlCon.Close()

    End Sub

    Public Sub CargaRelaciones()
        Me.Relaciones = New List(Of Relacion)
        Me.sqlCon.Open()
        Dim sdr As SqlDataReader
        Dim myCommand As New SqlCommand

        myCommand.Connection = Me.sqlCon
        '        myCommand.CommandText = "use " & cmbSQLDatabase.Text & " select * from " & ComboBox2.Text
        myCommand.CommandText = "SELECT " & _
                                "FK_Table  = FK.TABLE_NAME, " & _
                                "FK_Column = CU.COLUMN_NAME, " & _
                                "PK_Table  = PK.TABLE_NAME,  " & _
                                "PK_Column = PT.COLUMN_NAME,  " & _
                                "Constraint_Name = C.CONSTRAINT_NAME  " & _
                                " FROM  " & _
                                "INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C  " & _
                                "INNER JOIN  " & _
                                "INFORMATION_SCHEMA.TABLE_CONSTRAINTS FK  " & _
                                "ON C.CONSTRAINT_NAME = FK.CONSTRAINT_NAME  " & _
                                "INNER JOIN  " & _
                                "INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK  " & _
                                "ON C.UNIQUE_CONSTRAINT_NAME = PK.CONSTRAINT_NAME  " & _
                                "INNER JOIN  " & _
                                "INFORMATION_SCHEMA.KEY_COLUMN_USAGE CU  " & _
                                "ON C.CONSTRAINT_NAME = CU.CONSTRAINT_NAME  " & _
                                "INNER JOIN  " & _
                                "( " & _
                                "SELECT i1.TABLE_NAME, i2.COLUMN_NAME  " & _
                                "FROM  INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1  " & _
                                "INNER JOIN  " & _
                                "INFORMATION_SCHEMA.KEY_COLUMN_USAGE i2  " & _
                                "ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME  " & _
                                "WHERE i1.CONSTRAINT_TYPE = 'PRIMARY KEY'  " & _
                                ") PT  " & _
                                " ON PT.TABLE_NAME = PK.TABLE_NAME " & _
                                "WHERE FK.TABLE_NAME=@table_name " & _
                                "ORDER BY 1,2,3,4 "

        myCommand.Parameters.Add("@table_name", SqlDbType.VarChar)
        myCommand.Parameters("@table_name").Value = Me.NombreTabla

        sdr = myCommand.ExecuteReader
        While (sdr.Read)
            Dim rlc As New Relacion
            rlc.Tabla = sdr.Item("PK_Table")
            rlc.campo = sdr.Item("FK_Column")
            rlc.tipo = 0
            Me.Relaciones.Add(rlc)

        End While
        sdr.Close()
        Me.sqlCon.Close()

    End Sub


    Public Function nombre() As String
        Return Me.NombreTabla
        Dim temp As String = Me.llave
        If temp.Length < 3 Then

            Return Me.NombreTabla
        Else
            If temp.Substring(temp.Length - 3, 3).Equals("_id") Then
                temp = Me.llave.Substring(0, temp.Length - 3)

            Else
                If CType(temp(temp.Length - 1), Char) = "s" And Not (temp(temp.Length - 2) = "u" Or temp(temp.Length - 2) = "i") Then
                    temp = temp.Substring(0, temp.Length - 1)
                End If

                If temp(temp.Length - 1) = "e" And Not (temp(temp.Length - 2) = "t" Or temp(temp.Length - 2) = "h") Then
                    temp = temp.Substring(0, temp.Length - 1)
                End If
                If temp(temp.Length - 1) = "C" Then
                    temp = temp.Substring(0, temp.Length - 1) & "z"
                End If
            End If
            Return temp
        End If
    End Function

    Public Sub New()
        Me.Campos = New List(Of Propiedad)
    End Sub
End Class
