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
	public class generaForma
	{
		public string neimespeis;

		public Clase clace;
		public string creaForma()
		{
			string code = string.Empty;
			code += "Imports Sist" + neimespeis + "." + neimespeis + Constants.vbCrLf;
			code += "Imports Sist" + neimespeis + ".Maneja" + neimespeis + Constants.vbCrLf;
			code += " Public Class frm" + this.clace.NombreTabla + Constants.vbCrLf;
			code += "Public mnj" + this.clace.nombre().Substring(0, 3) + " as new maneja" + this.clace.NombreTabla + Constants.vbCrLf;
			code += this.generaLoad() + Constants.vbCrLf;
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
