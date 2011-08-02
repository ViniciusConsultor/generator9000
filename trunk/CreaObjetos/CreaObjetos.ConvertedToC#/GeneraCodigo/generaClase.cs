using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsApplication1.GeneraCodigo
{
  using Microsoft.VisualBasic;
  using System;
  using System.Collections;
  using System.Collections.Generic;
  using System.Data;
  using System.Diagnostics;
  using System.Drawing;
  using System.Windows.Forms;


  public class GeneraClase
  {
    /// <summary>
    /// 
    /// </summary>
    public string ClaseStr { get; set; }
    public Clase Clase { get; set; }
    public string Neimespeis { get; set; }

    public string creaClase()
    {
      string str = null;
      str = "Imports Microsoft.VisualBasic" + Environment.NewLine;
      str += "Imports system.Data.SqlClient" + Environment.NewLine;
      str += "Imports System.Data" + Environment.NewLine;
      str = "Imports Microsoft.VisualBasic" + Environment.NewLine;
      str += "Imports system.data.sqlClient" + Environment.NewLine;
      str += "Namespace " + Neimespeis + Environment.NewLine;
      str += "Public Class " + Clase.nombre() + Environment.NewLine;
      if (Clase.Campos.Count > 0)
      {
        str += GeneraCampos();
        str += GeneraPropiedades();
        str += GeneraMetodos();
      }
      str += "End Class" + Environment.NewLine + Environment.NewLine;
      str += "End namespace";
      return str;
    }
    private string GeneraCampos()
    {
      string str = null;
      int i = 0;
      str = "";
      for (i = 0; i <= Clase.Campos.Count - 1; i++)
      {
        str += "Private _" + Clase.Campos[i].Nombre + " As " + Clase.Campos[i].tipoVB() + Environment.NewLine;
      }
      return str;
    }
    private string GeneraPropiedades()
    {
      string str = null;
      int i = 0;
      str = "";
      for (i = 0; i <= Clase.Campos.Count - 1; i++)
      {
        str += "Public Property " + Clase.Campos[i].Nombre + " As " + Clase.Campos[i].tipoVB() + Environment.NewLine;
        str += " Get " + Environment.NewLine;
        str += " Return Me._" + Clase.Campos[i].Nombre + Environment.NewLine;
        str += "End Get" + Environment.NewLine;
        str += "Set(ByVal value As " + Clase.Campos[i].tipoVB() + ")" + Environment.NewLine;
        str += "Me._" + Clase.Campos[i].Nombre + " = value" + Environment.NewLine;
        str += "End Set" + Environment.NewLine;
        str += "End Property" + Environment.NewLine;
      }
      return str;
    }
    private string GeneraMetodos()
    {
      string str = null;
      str = "";
      str = GeneraInicializa();
      str += GeneraCargar();
      str += GeneraActualizar();
      str += GeneraGuardar();
      str += this.GeneraBorrar();
      str += this.GeneraCargaUltimo();
      str += this.GeneraBuscar();
      return str;
    }
    private string GeneraInicializa()
    {
      string str = null;
      int i = 0;
      str = "";
      str += "Public Sub Asignar(ByVal sqlRead as SqlDataReader)" + Environment.NewLine;
      for (i = 0; i <= Clase.Campos.Count - 1; i++)
      {
        str += "Me." + Clase.Campos[i].Nombre + "= SqlRead(\"" + Clase.Campos[i].Nombre + "\" )" + Environment.NewLine;
      }
      str += "End Sub" + Environment.NewLine;
      return str;
    }
    private string GeneraCargar()
    {
      string str = null;
      int i = 0;
      string query = null;
      string campos = null;
      str = "";
      str += "Public Sub Cargar() " + Environment.NewLine;

      str += "Dim mcn As New MiConexion()" + Environment.NewLine;
      str += "Dim conn As SqlConnection = mcn.sqlConnection" + Environment.NewLine;
      str += "Dim sqlRead As SqlDataReader" + Environment.NewLine;
      str += "Dim sqlCommand As New SqlCommand()" + Environment.NewLine;
      str += "sqlCommand.Connection = conn" + Environment.NewLine;

      campos = "SELECT ";
      for (i = 0; i <= Clase.Campos.Count - 1; i++)
      {
        campos += Clase.Campos[i].Nombre;
        if (i != Clase.Campos.Count - 1)
          campos += ",";
      }
      query = "";
      query += campos + " FROM " + Clase.NombreTabla;
      query += " WHERE " + Clase.llave + "=@" + Clase.llave;


      str += "Dim sqlString = \"" + query + "\"" + Environment.NewLine;
      str += "sqlCommand.Parameters.Add(\"@" + Clase.llave + "\", SqlDbType.Int)" + Environment.NewLine;
      str += "sqlCommand.Parameters(\"@" + Clase.llave + "\").Value = Me." + Clase.llave + Environment.NewLine;
      str += "sqlCommand.CommandText = sqlString" + Environment.NewLine;

      str += "conn.Open()" + Environment.NewLine;
      str += "sqlRead = sqlCommand.ExecuteReader()" + Environment.NewLine;
      str += "If sqlRead.Read() Then" + Environment.NewLine;
      str += "Me.Asignar(sqlRead)" + Environment.NewLine;
      str += "End If" + Environment.NewLine;
      str += "sqlRead.Close()" + Environment.NewLine;
      str += "conn.Close()" + Environment.NewLine;

      str += "End Sub" + Environment.NewLine;
      return str;
    }
    private string GeneraBuscar()
    {
      string str = null;
      int i = 0;
      string query = null;
      string campos = null;
      str = "";
      str += "Public Function Busca" + this.Clase.NombreTabla + "(byval tipo as integer, byval busq as string) as System.Collections.Generic.List(of " + this.Clase.nombre() + ")" + Environment.NewLine;
      str += "Dim " + this.Clase.NombreTabla + " As new System.Collections.Generic.List(of " + this.Clase.nombre() + ")" + Environment.NewLine;
      str += "Dim mcn As New MiConexion()" + Environment.NewLine;
      str += "Dim conn As SqlConnection = mcn.sqlConnection" + Environment.NewLine;
      str += "Dim sqlRead As SqlDataReader" + Environment.NewLine;
      str += "Dim sqlCommand As New SqlCommand()" + Environment.NewLine;
      str += "sqlCommand.Connection = conn" + Environment.NewLine;

      campos = "SELECT ";
      for (i = 0; i <= Clase.Campos.Count - 1; i++)
      {
        campos += Clase.Campos[i].Nombre;
        if (i != Clase.Campos.Count - 1)
          campos += ",";
      }
      query = "";
      query += campos + " FROM " + Clase.NombreTabla;



      str += "Dim sqlString = \"" + query + "\"" + Environment.NewLine;
      str += "SELECT tipo " + Environment.NewLine;
      str += "case 0  'Todos" + Environment.NewLine;
      str += "case 1 'Por id" + Environment.NewLine;
      str += "sqlString &= \" WHERE " + Clase.llave + "=@" + Clase.llave + "\"" + Environment.NewLine;
      str += "sqlCommand.Parameters.Add(\"@" + Clase.llave + "\", SqlDbType.Int)" + Environment.NewLine;

      str += "sqlCommand.Parameters(\"@" + Clase.llave + "\").Value = Me." + Clase.llave + Environment.NewLine;
      str += "END SELECT  " + Environment.NewLine;


      str += "sqlCommand.CommandText = sqlString" + Environment.NewLine;

      str += "conn.Open()" + Environment.NewLine;
      str += "sqlRead = sqlCommand.ExecuteReader()" + Environment.NewLine;
      str += "While sqlRead.Read() " + Environment.NewLine;
      str += "Dim " + this.Clase.nombre().Substring(0, 3) + " As New " + this.Clase.nombre() + Environment.NewLine;
      str += this.Clase.nombre().Substring(0, 3) + ".Asignar(sqlRead)" + Environment.NewLine;
      str += this.Clase.NombreTabla + ".Add(" + this.Clase.nombre().Substring(0, 3) + ")" + Environment.NewLine;
      str += "End While" + Environment.NewLine;
      str += "sqlRead.Close()" + Environment.NewLine;
      str += "conn.Close()" + Environment.NewLine;
      str += "Return " + this.Clase.NombreTabla + Environment.NewLine;
      str += "End Function" + Environment.NewLine;
      return str;
    }
    public string GeneraActualizar()
    {


      string str = null;
      int i = 0;
      string query = null;
      string campos = null;
      str = "";
      str += "Public Sub Actualizar() " + Environment.NewLine;
      str += "Dim mcn As New MiConexion()" + Environment.NewLine;
      str += "Dim conn As SqlConnection = mcn.sqlConnection" + Environment.NewLine;


      query = "";
      campos = "";


      for (i = 1; i <= Clase.Campos.Count - 1; i++)
      {
        campos += Clase.Campos[i].Nombre + "= @" + Clase.Campos[i].Nombre;
        if (i != Clase.Campos.Count - 1)
        {
          campos += ",";
        }

      }


      query += "UPDATE " + this.Clase.NombreTabla + " SET " + campos;

      query += " WHERE " + Clase.llave + "=@" + Clase.llave;

      str += "Dim sqlString As String =\"" + query + "\"" + Environment.NewLine;
      str += "Dim sqlCommand As New SqlCommand(sqlString, conn)" + Environment.NewLine;
      str += "conn.Open()" + Environment.NewLine;

      for (i = 0; i <= Clase.Campos.Count - 1; i++)
      {
        str += "sqlCommand.Parameters.Add(\"@" + Clase.Campos[i].Nombre + "\", SqlDbType." + Clase.Campos[i].Tipo + ")" + Environment.NewLine;
      }

      for (i = 0; i <= Clase.Campos.Count - 1; i++)
      {
        str += "  sqlCommand.Parameters(\"@" + Clase.Campos[i].Nombre + "\").Value = Me." + Clase.Campos[i].Nombre + Environment.NewLine;
      }

      str += "sqlCommand.ExecuteNonQuery()" + Environment.NewLine;
      str += "conn.Close()" + Environment.NewLine;
      str += "End Sub" + Environment.NewLine;

      return str;

    }
    public string GeneraGuardar()
    {


      string str = null;
      int i = 0;
      string query = null;
      string campos = null;
      string @params = null;
      str = "";
      str += "Public Sub Guardar() " + Environment.NewLine;
      str += "Dim mcn As New MiConexion()" + Environment.NewLine;
      str += "Me. " + this.Clase.llave + " = mcn.DameUltimoID(\"" + this.Clase.llave + "\", \"" + this.Clase.NombreTabla + "\") + 1" + Environment.NewLine;
      str += "Dim conn As SqlConnection = mcn.sqlConnection" + Environment.NewLine;


      query = "";
      campos = "";
      @params = "";

      for (i = 0; i <= Clase.Campos.Count - 1; i++)
      {
        campos += Clase.Campos[i].Nombre;
        @params += "@" + Clase.Campos[i].Nombre;
        if (i != Clase.Campos.Count - 1)
        {
          campos += ",";
          @params += ",";
        }

      }


      query += "INSERT INTO " + this.Clase.NombreTabla + " (" + campos + ") VALUES (" + @params + ")";

      str += "Dim sqlString As String =\"" + query + "\"" + Environment.NewLine;
      str += "Dim sqlCommand As New SqlCommand(sqlString, conn)" + Environment.NewLine;
      str += "conn.Open()" + Environment.NewLine;

      for (i = 0; i <= Clase.Campos.Count - 1; i++)
      {
        str += "sqlCommand.Parameters.Add(\"@" + Clase.Campos[i].Nombre + "\", SqlDbType." + Clase.Campos[i].Tipo + ")" + Environment.NewLine;
      }

      for (i = 0; i <= Clase.Campos.Count - 1; i++)
      {
        str += "  sqlCommand.Parameters(\"@" + Clase.Campos[i].Nombre + "\").Value = Me." + Clase.Campos[i].Nombre + Environment.NewLine;
      }

      str += "sqlCommand.ExecuteNonQuery()" + Environment.NewLine;
      str += "conn.Close()" + Environment.NewLine;
      str += "End Sub" + Environment.NewLine;

      return str;

    }
    private string GeneraBorrar()
    {
      string str = null;

      string query = null;

      str = "";
      str += "Public Sub Borrar() " + Environment.NewLine;

      str += "Dim mcn As New MiConexion()" + Environment.NewLine;
      str += "Dim conn As SqlConnection = mcn.sqlConnection" + Environment.NewLine;

      str += "Dim sqlCommand As New SqlCommand()" + Environment.NewLine;
      str += "sqlCommand.Connection = conn" + Environment.NewLine;

      query = "DELETE FROM " + Clase.NombreTabla;
      query += " WHERE " + Clase.llave + "=@" + Clase.llave;


      str += "Dim sqlString = \"" + query + "\"" + Environment.NewLine;
      str += "sqlCommand.Parameters.Add(\"@" + Clase.llave + "\", SqlDbType.Int)" + Environment.NewLine;
      str += "sqlCommand.Parameters(\"@" + Clase.llave + "\").Value = Me." + Clase.llave + Environment.NewLine;
      str += "sqlCommand.CommandText = sqlString" + Environment.NewLine;

      str += "conn.Open()" + Environment.NewLine;
      str += " sqlCommand.ExecuteNonQuery()" + Environment.NewLine;
      str += "conn.Close()" + Environment.NewLine;

      str += "End Sub" + Environment.NewLine;
      return str;
    }
    public string GeneraCargaUltimo()
    {
      string str = null;
      str = "";
      str += "Public Sub CargaUltimo " + Environment.NewLine;
      str += "Dim mcn As New MiConexion()" + Environment.NewLine;
      str += "Me. " + this.Clase.llave + " = mcn.DameUltimoID(\"" + this.Clase.llave + "\", \"" + this.Clase.NombreTabla + "\")" + Environment.NewLine;
      str += "Me.cargar()" + Environment.NewLine;
      str += "End sub " + Environment.NewLine;


      return str;

    }
  }

}
