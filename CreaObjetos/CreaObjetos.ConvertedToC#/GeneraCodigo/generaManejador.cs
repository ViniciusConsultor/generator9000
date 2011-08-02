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
	public class generaManejador
	{

		public string neimespeis;

		public Clase clace;
		public string generaManeja()
		{
			string codigo = null;
			codigo = "Imports Sist" + this.neimespeis + "." + this.neimespeis + Constants.vbCrLf;
			codigo += "Namespace maneja" + this.neimespeis + Constants.vbCrLf;
			codigo += "Public Class maneja" + this.clace.NombreTabla + Constants.vbCrLf;
			codigo += "Inherits ManejaObjetos" + Constants.vbCrLf;
			codigo += "Public " + this.clace.NombreTabla + " As New List(Of " + this.clace.nombre() + ")" + Constants.vbCrLf;
			codigo += "Public " + this.clace.nombre().Substring(0, 3) + "Act As New " + this.clace.nombre() + Constants.vbCrLf;


			codigo += this.creaChecaCampos();
			codigo += this.creaActualizaRegistro();
			codigo += this.creaAddHandler();
			codigo += this.creaAgregaBusquedas();
			codigo += this.creaBorraRegistro();
			codigo += this.creaBuscarPor();
			codigo += this.creaCamposCargados();
			codigo += this.creaCargarDatos();
			codigo += this.creaDameRegistro();
			codigo += this.creaDameUltimo();
			codigo += this.creaGuardaRegistro();
			codigo += this.creaIniciar();
			codigo += this.creaValidaCaptura();
			codigo += this.creaValidaClave();
			codigo += this.creaUltimoIndice();
			codigo += "End Class" + Constants.vbCrLf;
			codigo += "End NameSpace";
			return codigo;
		}
		public string creaChecaCampos()
		{
			Propiedad atributo = null;
			string codigo = null;
			codigo = "Public Overrides Sub ChecaCampos()" + Constants.vbCrLf;

			codigo += "Dim campos() As String = {\"";
			foreach (Propiedad atributo_loopVariable in clace.Campos) {
				atributo = atributo_loopVariable;
				if (!atributo.isNull) {
					if (!(clace.Campos.IndexOf(atributo) == 0)) {
						codigo += ", \"";
					}
					codigo += atributo.Nombre + "\"";
				}
			}
			codigo += "}" + Constants.vbCrLf;

			codigo += "Dim CapVal As Integer" + Constants.vbCrLf;
			codigo += "CapVal = Me.ValidaCaptura" + Constants.vbCrLf;
			codigo += "If CapVal = 0 Then" + Constants.vbCrLf;
			codigo += "Me.ctlMaestro.btnAltas.Enabled = True" + Constants.vbCrLf;
			codigo += "Else" + Constants.vbCrLf;
			codigo += "Me.dameControl(\"lblFalta\").Text = \"llenar campo\" & campos(CapVal - 1)" + Constants.vbCrLf;
			codigo += "End If" + Constants.vbCrLf;
			codigo += "End Sub" + Constants.vbCrLf;
			return codigo;
		}
		public string creaValidaCaptura()
		{
			Propiedad atributo = null;
			int index = 0;
			string codigo = null;
			codigo = "Public Overrides Function ValidaCaptura() As Integer" + Constants.vbCrLf;
			string abrevalida = "valNulosInt(";
			string tipoControl = "txt";
			string cierraValida = "\").Text) > 0";
			foreach (Propiedad atributo_loopVariable in clace.Campos) {
				atributo = atributo_loopVariable;
				codigo += "If Not " + abrevalida + "Me.DameControl(\"" + tipoControl;
				codigo += atributo.Nombre + cierraValida + " Then return " + index + Constants.vbCrLf;
			}


			codigo += "Return 0" + Constants.vbCrLf;
			codigo += "End Function" + Constants.vbCrLf;

			return codigo;
		}
		public string creaAgregaBusquedas()
		{
			string codigo = null;
			codigo = "    Public Overrides Sub AgregaBusquedas()" + Constants.vbCrLf;
			codigo += "Dim ibusq As Integer" + Constants.vbCrLf;

			codigo += "Me.ctlBusq.strBusquedas.Add(\"Todos\")" + Constants.vbCrLf;
			codigo += "Me.ctlBusq.strBusquedas.Add(\"clave\")" + Constants.vbCrLf;
			codigo += "Me.ctlBusq.strBusquedas.Add(\"Nombre\")" + Constants.vbCrLf;

			codigo += "For ibusq = 0 To Me.ctlBusq.strBusquedas.Count - 1" + Constants.vbCrLf;
			codigo += "Dim tls As ToolStripItem = Me.ctlBusq.btnBuscar.DropDownItems.Add(Me.ctlBusq.strBusquedas(ibusq))" + Constants.vbCrLf;
			codigo += "tls.Tag = ibusq" + Constants.vbCrLf;
			codigo += "AddHandler tls.Click, AddressOf Me.ctlBusq.defineTipoBusqueda" + Constants.vbCrLf;
			codigo += "Next" + Constants.vbCrLf;
			codigo += "Me.ctlBusq.btnBuscar.Text = \"Todos\"" + Constants.vbCrLf;
			codigo += "Me.ctlBusq.iBusqueda = 0" + Constants.vbCrLf;
			codigo += "End Sub" + Constants.vbCrLf;
			return codigo;
		}
		public string creaAddHandler()
		{
			string codigo = null;
			codigo = "Public Overrides Sub AddHandlers()" + Constants.vbCrLf;
			codigo += " MyBase.AddHandlers()" + Constants.vbCrLf;

			foreach (Propiedad atr in clace.Campos) {
				if (!atr.isNull) {
					codigo += " AddHandler Me.dameControl(\"txt" + atr.Nombre + "\").LostFocus, AddressOf revisaCampos" + Constants.vbCrLf;
				}
			}


			codigo += "End Sub" + Constants.vbCrLf;
			return codigo;
		}
		public string creaCamposCargados()
		{
			string codigo = null;
			codigo = "Public Overrides Function camposCargados() As Integer" + Constants.vbCrLf;
			codigo += "Return Me." + this.clace.NombreTabla + ".Count " + Constants.vbCrLf;
			codigo += "End Function" + Constants.vbCrLf;
			return codigo;
		}
		public string creaActualizaRegistro()
		{
			string codigo = null;
			codigo = "Public Overrides Sub ActualizaRegistro()" + Constants.vbCrLf;
			codigo += "Me.dameRegistro()" + Constants.vbCrLf;
			codigo += "Me." + this.RegAct() + ".Actualizar()" + Constants.vbCrLf;
			codigo += "End Sub" + Constants.vbCrLf;
			return codigo;
		}
		public string creaBorraRegistro()
		{
			string codigo = null;
			codigo = "Public Overrides Sub BorraRegistro()" + Constants.vbCrLf;
			codigo += "Me." + this.RegCol() + ".Remove(" + this.RegAct() + ")" + Constants.vbCrLf;
			codigo += "Me." + this.RegAct() + ".Borrar()" + Constants.vbCrLf;
			codigo += "End Sub" + Constants.vbCrLf;
			return codigo;
		}
		public string creaGuardaRegistro()
		{
			string codigo = null;
			codigo = "Public Overrides Sub guardaRegistro()" + Constants.vbCrLf;
			codigo += "Me.dameRegistro()" + Constants.vbCrLf;
			codigo += "Me." + this.RegAct() + ".Guardar()" + Constants.vbCrLf;
			codigo += "End Sub" + Constants.vbCrLf;

			return codigo;
		}
		public string creaValidaClave()
		{
			string codigo = null;
			codigo = "Public Overrides Function ValidaClave() As Boolean" + Constants.vbCrLf;
			codigo += "Return True" + Constants.vbCrLf;
			codigo += "End Function" + Constants.vbCrLf;
			return codigo;
		}
		public string creaDameRegistro()
		{
			string codigo = null;
			codigo = "Public Overrides Sub dameRegistro()" + Constants.vbCrLf;


			foreach (Propiedad atr in clace.Campos) {

				if (!atr.Nombre.Substring(atr.Nombre.Length - 3, 3).Equals("_id") & !atr.Nombre.Equals(clace.llave)) {
					codigo += "Me." + this.RegAct() + "." + atr.Nombre + " = Me.dameControl(\"" + atr.tipoControl + atr.Nombre + "\").Text" + Constants.vbCrLf;
				} else {
					codigo += "Me." + this.RegAct() + "." + atr.Nombre + " = Me.dameComboBox(\"cmb" + atr.Nombre + "\").SelectedValue" + Constants.vbCrLf;
				}

			}
			codigo += "End Sub" + Constants.vbCrLf;
			return codigo;
		}
		public string creaBuscarPor()
		{
			string codigo = null;
			codigo = "Public Overrides Sub BuscarPor()" + Constants.vbCrLf;
			codigo += "If Len(Trim(Me.ctlBusq.txtbusq.Text)) > 0 Then" + Constants.vbCrLf;
			codigo += "Dim " + this.clace.nombre().Substring(0, 3) + " As New " + this.clace.nombre() + Constants.vbCrLf;
			codigo += "Me." + this.clace.NombreTabla + " = " + this.clace.nombre().Substring(0, 3);
			codigo += ".busca" + this.clace.NombreTabla + "(Me.ctlBusq.iBusqueda, Me.ctlBusq.txtbusq.Text)" + Constants.vbCrLf;
			codigo += "Me.ctlBusq.LlenaDT()" + Constants.vbCrLf;
			codigo += "Else" + Constants.vbCrLf;
			codigo += "MsgBox(\"Se Requieren Datos Para la Busqueda\", MsgBoxStyle.OkOnly)" + Constants.vbCrLf;
			codigo += "End If" + Constants.vbCrLf;
			codigo += "End Sub" + Constants.vbCrLf;

			return codigo;
		}
		public string creaCargarDatos()
		{
			string codigo = null;
			codigo = "Public Overrides Sub CargarDatos(ByVal indice As Integer)" + Constants.vbCrLf;
			codigo += "Me." + this.RegAct() + "= Me." + this.clace.NombreTabla + "(indice)" + Constants.vbCrLf;


			foreach (Propiedad atr in clace.Campos) {
				if (!atr.Nombre.Substring(atr.Nombre.Length - 3, 3).Equals("_id") | this.clace.llave.Equals(atr.Nombre)) {
					codigo += "Me.dameControl(\"" + atr.tipoControl + atr.Nombre + "\").Text =";
					codigo += "Me." + this.RegAct() + "." + atr.Nombre + Constants.vbCrLf;
				} else {
					codigo += " Me.dameComboBox(\"cmb" + atr.Nombre + "\").SelectedValue";
					codigo += "= Me." + this.RegAct() + "." + atr.Nombre + Constants.vbCrLf;
				}

			}
			codigo += "End Sub" + Constants.vbCrLf;
			return codigo;
		}
		public string creaDameUltimo()
		{
			string codigo = null;
			codigo = "Public Overrides Sub DameUltimo()" + Constants.vbCrLf;
			codigo += "Me." + this.RegAct() + ".cargaUltimo()" + Constants.vbCrLf;
			codigo += "If Me." + this.clace.NombreTabla + ".IndexOf(Me." + this.RegAct() + ") = -1 Then" + Constants.vbCrLf;
			codigo += "Me." + this.clace.NombreTabla + ".Add(Me." + this.RegAct() + ")" + Constants.vbCrLf;
			codigo += "End If" + Constants.vbCrLf;
			codigo += "Me.CargarDatos(0)" + Constants.vbCrLf;
			codigo += "End Sub" + Constants.vbCrLf;
			return codigo;
		}
		public string creaUltimoIndice()
		{
			string codigo = null;
			codigo = "Public Overrides Function UltimoIndice() As Integer" + Constants.vbCrLf;
			codigo += "Dim mcn As New MiConexion" + Constants.vbCrLf;
			codigo += "Me.dameControl(\"txt" + this.clace.llave + "\").Text = ";
			codigo += " mcn.DameUltimoID(\"" + this.clace.llave + "\", \"" + this.clace.NombreTabla + " \") + 1" + Constants.vbCrLf;
			codigo += "Return 0" + Constants.vbCrLf;
			codigo += "End Function" + Constants.vbCrLf;
			return codigo;
		}
		public string creaIniciar()
		{
			string codigo = null;
			codigo = "Public Overrides Sub iniciar()" + Constants.vbCrLf;
			codigo += "Me.nombreClase = \"" + this.clace.nombre() + Constants.vbCrLf;
			codigo += "MyBase.iniciar()" + Constants.vbCrLf;
			codigo += "Me.ctlBusq.txtbusq.Text = \"Todos\"" + Constants.vbCrLf;
			codigo += "Me.BuscarPor()" + Constants.vbCrLf;
			codigo += "End Sub" + Constants.vbCrLf;

			return codigo;
		}

		public string RegCol()
		{
			return this.clace.NombreTabla;
		}
		public string RegAct()
		{
			return this.clace.nombre().Substring(0, 3) + "Act";
		}
	}
}
