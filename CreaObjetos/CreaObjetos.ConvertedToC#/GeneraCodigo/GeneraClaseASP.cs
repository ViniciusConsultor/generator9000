using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
namespace WindowsApplication1
{
	public class GeneraClaseASP
	{
		private string claseStr;
		public Clase clase;

		public string neimespeis;
		public string GeneraClase()
		{
			string str = null;


			str = "Imports Microsoft.VisualBasic" + Constants.vbCrLf;
			str += "Imports System.Data.sqlClient" + Constants.vbCrLf;
			str += "Imports System.Data.sqlDbType" + Constants.vbCrLf;
			str += "Namespace " + neimespeis + Constants.vbCrLf;
			str += "Public Class " + clase.nombre() + Constants.vbCrLf;
			if (clase.Campos.Count > 0) {
				str += GeneraCampos();
				str += GeneraPropiedades();
				str += GeneraMetodos();
			}
			str += "End Class" + Constants.vbCrLf + Constants.vbCrLf;
			str += "End namespace";
			return str;
		}
		private string GeneraCampos()
		{
			string str = null;
			int i = 0;
			str = "";
			for (i = 0; i <= clase.Campos.Count - 1; i++) {
				str += "Private _" + clase.Campos[i].Nombre + " As " + clase.Campos[i].tipoVB() + Constants.vbCrLf;
			}
			return str;
		}
		private string GeneraPropiedades()
		{
			string str = null;
			int i = 0;
			str = "";
			for (i = 0; i <= clase.Campos.Count - 1; i++) {
				str += "Public Property " + clase.Campos[i].Nombre + " As " + clase.Campos[i].tipoVB() + Constants.vbCrLf;
				str += " Get " + Constants.vbCrLf;
				str += " Return Me._" + clase.Campos[i].Nombre + Constants.vbCrLf;
				str += "End Get" + Constants.vbCrLf;
				str += "Set(ByVal value As " + clase.Campos[i].tipoVB() + ")" + Constants.vbCrLf;
				str += "Me._" + clase.Campos[i].Nombre + " = value" + Constants.vbCrLf;
				str += "End Set" + Constants.vbCrLf;
				str += "End Property" + Constants.vbCrLf;
			}
			return str;
		}
		private string GeneraMetodos()
		{
			string str = null;
			str = "";
			str = generaInicializa();
			str += generaCargar();
			str += generaActualizar();
			str += generaGuardar();
			str += this.generaBorrar();
			str += this.generaCargaUltimo();
			str += this.generaBuscar();
			return str;
		}
		private string generaInicializa()
		{
			string str = null;
			int i = 0;
			str = "";
			str += "Public Sub Asignar(ByVal sqlRead as SqlDataReader)" + Constants.vbCrLf;
			for (i = 0; i <= clase.Campos.Count - 1; i++) {
				str += "Me." + clase.Campos[i].Nombre + "= SqlRead(\"" + clase.Campos[i].Nombre + "\" )" + Constants.vbCrLf;
			}
			str += "End Sub" + Constants.vbCrLf;
			return str;
		}
		private string generaCargar()
		{
			string str = null;
			int i = 0;
			string query = null;
			string campos = null;
			str = "";
			str += "Public Sub Cargar() " + Constants.vbCrLf;

			str += "Dim mcn As New MiConexion()" + Constants.vbCrLf;
			str += "Dim conn As SqlConnection = mcn.sqlConnection" + Constants.vbCrLf;
			str += "Dim sqlRead As SqlDataReader" + Constants.vbCrLf;
			str += "Dim sqlCommand As New SqlCommand()" + Constants.vbCrLf;
			str += "sqlCommand.Connection = conn" + Constants.vbCrLf;

			campos = "SELECT ";
			for (i = 0; i <= clase.Campos.Count - 1; i++) {
				campos += clase.Campos[i].Nombre;
				if (i != clase.Campos.Count - 1)
					campos += ",";
			}
			query = "";
			query += campos + " FROM " + clase.NombreTabla;
			query += " WHERE " + clase.llave + "=@" + clase.llave;


			str += "Dim sqlString = \"" + query + "\"" + Constants.vbCrLf;
			str += "sqlCommand.Parameters.Add(\"@" + clase.llave + "\", Int)" + Constants.vbCrLf;
			str += "sqlCommand.Parameters(\"@" + clase.llave + "\").Value = Me." + clase.llave + Constants.vbCrLf;
			str += "sqlCommand.CommandText = sqlString" + Constants.vbCrLf;

			str += "conn.Open()" + Constants.vbCrLf;
			str += "sqlRead = sqlCommand.ExecuteReader()" + Constants.vbCrLf;
			str += "If sqlRead.Read() Then" + Constants.vbCrLf;
			str += "Me.Asignar(sqlRead)" + Constants.vbCrLf;
			str += "End If" + Constants.vbCrLf;
			str += "sqlRead.Close()" + Constants.vbCrLf;
			str += "conn.Close()" + Constants.vbCrLf;

			str += "End Sub" + Constants.vbCrLf;
			return str;
		}

		private string generaBuscar()
		{
			string str = null;
			int i = 0;
			string query = null;
			string campos = null;
			str = "";
			str += "Public Function Busca" + this.clase.NombreTabla + "(byval tipo as integer, byval busq as string) as System.Collections.Generic.List(of " + this.clase.nombre() + ")" + Constants.vbCrLf;
			str += "Dim " + this.clase.NombreTabla + " As new System.Collections.Generic.List(of " + this.clase.nombre() + ")" + Constants.vbCrLf;
			str += "Dim mcn As New MiConexion()" + Constants.vbCrLf;
			str += "Dim conn As SqlConnection = mcn.sqlConnection" + Constants.vbCrLf;
			str += "Dim sqlRead As SqlDataReader" + Constants.vbCrLf;
			str += "Dim sqlCommand As New SqlCommand()" + Constants.vbCrLf;
			str += "sqlCommand.Connection = conn" + Constants.vbCrLf;

			campos = "SELECT ";
			for (i = 0; i <= clase.Campos.Count - 1; i++) {
				campos += clase.Campos[i].Nombre;
				if (i != clase.Campos.Count - 1)
					campos += ",";
			}
			query = "";
			query += campos + " FROM " + clase.NombreTabla;



			str += "Dim sqlString = \"" + query + "\"" + Constants.vbCrLf;
			str += "SELECT tipo " + Constants.vbCrLf;
			str += "case 0  'Todos" + Constants.vbCrLf;
			str += "case 1 'Por id" + Constants.vbCrLf;
			str += "sqlString &= \" WHERE " + clase.llave + "=@" + clase.llave + "\"" + Constants.vbCrLf;
			str += "sqlCommand.Parameters.Add(\"@" + clase.llave + "\", Int)" + Constants.vbCrLf;

			str += "sqlCommand.Parameters(\"@" + clase.llave + "\").Value = Me." + clase.llave + Constants.vbCrLf;
			str += "END SELECT  " + Constants.vbCrLf;


			str += "sqlCommand.CommandText = sqlString" + Constants.vbCrLf;

			str += "conn.Open()" + Constants.vbCrLf;
			str += "sqlRead = sqlCommand.ExecuteReader()" + Constants.vbCrLf;
			str += "While sqlRead.Read() " + Constants.vbCrLf;
			str += "Dim " + this.clase.nombre().Substring(0, 3) + " As New " + this.clase.nombre() + Constants.vbCrLf;
			str += this.clase.nombre().Substring(0, 3) + ".Asignar(sqlRead)" + Constants.vbCrLf;
			str += this.clase.NombreTabla + ".Add(" + this.clase.nombre().Substring(0, 3) + ")" + Constants.vbCrLf;
			str += "End While" + Constants.vbCrLf;
			str += "sqlRead.Close()" + Constants.vbCrLf;
			str += "conn.Close()" + Constants.vbCrLf;
			str += "Return " + this.clase.NombreTabla + Constants.vbCrLf;
			str += "End Function" + Constants.vbCrLf;
			return str;
		}
		public string generaActualizar()
		{


			string str = null;
			int i = 0;
			string query = null;
			string campos = null;
			str = "";
			str += "Public Sub Actualizar() " + Constants.vbCrLf;
			str += "Dim mcn As New MiConexion()" + Constants.vbCrLf;
			str += "Dim conn As SqlConnection = mcn.sqlConnection" + Constants.vbCrLf;


			query = "";
			campos = "";


			for (i = 1; i <= clase.Campos.Count - 1; i++) {
				campos += clase.Campos[i].Nombre + "= @" + clase.Campos[i].Nombre;
				if (i != clase.Campos.Count - 1) {
					campos += ",";
				}

			}


			query += "UPDATE " + this.clase.NombreTabla + " SET " + campos;

			query += " WHERE " + clase.llave + "=@" + clase.llave;

			str += "Dim sqlString As String =\"" + query + "\"" + Constants.vbCrLf;
			str += "Dim sqlCommand As New SqlCommand(sqlString, conn)" + Constants.vbCrLf;
			str += "conn.Open()" + Constants.vbCrLf;

			for (i = 0; i <= clase.Campos.Count - 1; i++) {
				str += "sqlCommand.Parameters.Add(\"@" + clase.Campos[i].Nombre + "\", " + clase.Campos[i].Tipo + ")" + Constants.vbCrLf;
			}

			for (i = 0; i <= clase.Campos.Count - 1; i++) {
				str += "  sqlCommand.Parameters(\"@" + clase.Campos[i].Nombre + "\").Value = Me." + clase.Campos[i].Nombre + Constants.vbCrLf;
			}

			str += "sqlCommand.ExecuteNonQuery()" + Constants.vbCrLf;
			str += "conn.Close()" + Constants.vbCrLf;
			str += "End Sub" + Constants.vbCrLf;

			return str;

		}
		public string generaGuardar()
		{


			string str = null;
			int i = 0;
			string query = null;
			string campos = null;
			string @params = null;
			str = "";
			str += "Public Sub Guardar() " + Constants.vbCrLf;
			str += "Dim mcn As New MiConexion()" + Constants.vbCrLf;
			str += "Me. " + this.clase.llave + " = mcn.DameUltimoID(\"" + this.clase.llave + "\", \"" + this.clase.NombreTabla + "\") + 1" + Constants.vbCrLf;
			str += "Dim conn As SqlConnection = mcn.sqlConnection" + Constants.vbCrLf;


			query = "";
			campos = "";
			@params = "";

			for (i = 0; i <= clase.Campos.Count - 1; i++) {
				campos += clase.Campos[i].Nombre;
				@params += "@" + clase.Campos[i].Nombre;
				if (i != clase.Campos.Count - 1) {
					campos += ",";
					@params += ",";
				}

			}


			query += "INSERT INTO " + this.clase.NombreTabla + " (" + campos + ") VALUES (" + @params + ")";

			str += "Dim sqlString As String =\"" + query + "\"" + Constants.vbCrLf;
			str += "Dim sqlCommand As New SqlCommand(sqlString, conn)" + Constants.vbCrLf;
			str += "conn.Open()" + Constants.vbCrLf;

			for (i = 0; i <= clase.Campos.Count - 1; i++) {
				str += "sqlCommand.Parameters.Add(\"@" + clase.Campos[i].Nombre + "\", " + clase.Campos[i].Tipo + ")" + Constants.vbCrLf;
			}

			for (i = 0; i <= clase.Campos.Count - 1; i++) {
				str += "  sqlCommand.Parameters(\"@" + clase.Campos[i].Nombre + "\").Value = Me." + clase.Campos[i].Nombre + Constants.vbCrLf;
			}

			str += "sqlCommand.ExecuteNonQuery()" + Constants.vbCrLf;
			str += "conn.Close()" + Constants.vbCrLf;
			str += "End Sub" + Constants.vbCrLf;

			return str;

		}
		private string generaBorrar()
		{
			string str = null;

			string query = null;

			str = "";
			str += "Public Sub Borrar() " + Constants.vbCrLf;

			str += "Dim mcn As New MiConexion()" + Constants.vbCrLf;
			str += "Dim conn As SqlConnection = mcn.sqlConnection" + Constants.vbCrLf;

			str += "Dim sqlCommand As New SqlCommand()" + Constants.vbCrLf;
			str += "sqlCommand.Connection = conn" + Constants.vbCrLf;

			query = "DELETE FROM " + clase.NombreTabla;
			query += " WHERE " + clase.llave + "=@" + clase.llave;


			str += "Dim sqlString = \"" + query + "\"" + Constants.vbCrLf;
			str += "sqlCommand.Parameters.Add(\"@" + clase.llave + "\", Int)" + Constants.vbCrLf;
			str += "sqlCommand.Parameters(\"@" + clase.llave + "\").Value = Me." + clase.llave + Constants.vbCrLf;
			str += "sqlCommand.CommandText = sqlString" + Constants.vbCrLf;

			str += "conn.Open()" + Constants.vbCrLf;
			str += " sqlCommand.ExecuteNonQuery()" + Constants.vbCrLf;
			str += "conn.Close()" + Constants.vbCrLf;

			str += "End Sub" + Constants.vbCrLf;
			return str;
		}
		public string generaCargaUltimo()
		{
			string str = null;
			str = "";
			str += "Public Sub CargaUltimo " + Constants.vbCrLf;
			str += "Dim mcn As New MiConexion()" + Constants.vbCrLf;
			str += "Me. " + this.clase.llave + " = mcn.DameUltimoID(\"" + this.clase.llave + "\", \"" + this.clase.NombreTabla + "\")" + Constants.vbCrLf;
			str += "Me.cargar()" + Constants.vbCrLf;
			str += "End sub " + Constants.vbCrLf;


			return str;

		}
	}
}
