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
	public class generaCodPagina
	{
		public string neimespeis;

		public Clase clace;
		public string generaForma()
		{
			string code = string.Empty;
			//code &= "Imports Sist" & neimespeis & "." & neimespeis & vbCrLf
			//code &= "Imports Sist" & neimespeis & neimespeis & "Views" & vbCrLf
			code += " Partial Class " + this.clace.NombreTabla + "View" + Constants.vbCrLf;
			code += "Inherits System.Web.UI.Page" + Constants.vbCrLf;
			//code &= "Public " & Me.clace.nombre.Substring(0, 3) & "Ctl as new " & Me.clace.NombreTabla & "ctl" & vbCrLf
			// code &= Me.generaLoad() & vbCrLf
			code += "End Class" + Constants.vbCrLf;
			return code;

		}

		public string generaLoad()
		{
			string code = string.Empty;
			code += "Private Sub Frm" + this.clace.NombreTabla;
			code += "_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) ";
			code += " Handles MyBase.Load" + Constants.vbCrLf;
			code += "Me.mnj" + this.clace.nombre().Substring(0, 3) + ".ctlBusq = Me.CtlbuscaReg" + Constants.vbCrLf;
			code += "Me.mnj" + this.clace.nombre().Substring(0, 3) + ".ctlMaestro = Me.CtlABCMaestro" + Constants.vbCrLf;
			code += "Me.CtlbuscaReg = Me.mnj" + this.clace.nombre().Substring(0, 3) + ".ctlBusq" + Constants.vbCrLf;
			code += "Me.mnj" + this.clace.nombre().Substring(0, 3) + ".cargaControles(Me.pnlDatos.Controls)" + Constants.vbCrLf;
			code += "Me.CtlbuscaReg.mnjObj = Me.mnj" + this.clace.nombre().Substring(0, 3) + Constants.vbCrLf;
			code += "mnj" + this.clace.nombre().Substring(0, 3) + ".iniciar()" + Constants.vbCrLf;
			code += "End Sub " + Constants.vbCrLf;



			return code;

		}






	}
}
