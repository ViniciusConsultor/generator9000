using Microsoft.VisualBasic;

namespace WindowsApplication1
{
	public class creaDiseno
	{
		public string neimespeis;
		public Clase clace;
		int tabIndex;
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public string GeneraDiseno()
		{
			string codigo = null;
			codigo = " <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _" + Constants.vbCrLf;
			codigo += " Partial Class frm" + clace.NombreTabla + Constants.vbCrLf;
			codigo += "    Inherits System.Windows.Forms.Form " + Constants.vbCrLf;


			codigo += this.creaDispose();
			codigo += this.CreaInitializeComponent();
			codigo += this.creaFriends();
			codigo += "End Class" + Constants.vbCrLf;

			return codigo;
		}

		public object creaDispose()
		{
			string code = string.Empty;
			code += "'Form overrides dispose to clean up the component list." + Constants.vbCrLf;
			code += "<System.Diagnostics.DebuggerNonUserCode()> _" + Constants.vbCrLf;
			code += "Protected Overrides Sub Dispose(ByVal disposing As Boolean)" + Constants.vbCrLf;
			code += "Try" + Constants.vbCrLf;
			code += "If disposing AndAlso components IsNot Nothing Then" + Constants.vbCrLf;
			code += " components.Dispose()" + Constants.vbCrLf;
			code += "End If" + Constants.vbCrLf;
			code += "Finally" + Constants.vbCrLf;
			code += " MyBase.Dispose(disposing)" + Constants.vbCrLf;
			code += "End Try" + Constants.vbCrLf;
			code += "End Sub" + Constants.vbCrLf;

			return code;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public object CreaInitializeComponent()
		{
			string code = string.Empty;
			code += "   'Required by the Windows Form Designer" + Constants.vbCrLf;
			code += "   Private components As System.ComponentModel.IContainer" + Constants.vbCrLf;

			code += "   'NOTE: The following procedure is required by the Windows Form Designer" + Constants.vbCrLf;
			code += "   'It can be modified using the Windows Form Designer.  " + Constants.vbCrLf;
			code += "   'Do not modify it using the code editor." + Constants.vbCrLf;
			code += "   <System.Diagnostics.DebuggerStepThrough()> _" + Constants.vbCrLf;
			code += "   Private Sub InitializeComponent()" + Constants.vbCrLf;
			code += "       Me.pnlDatos = New System.Windows.Forms.Panel" + Constants.vbCrLf;
			code += "       Me.lblFalta = New System.Windows.Forms.Label" + Constants.vbCrLf;
			code += "       Me.CtlbuscaReg = New Sist" + this.neimespeis + ".ctlbuscaReg" + Constants.vbCrLf;
			code += "       Me.CtlABCMaestro = New Sist" + this.neimespeis + ".ctlABCMaestro" + Constants.vbCrLf;


			foreach (Propiedad atr in this.clace.Campos) {
				string tipoCtl = atr.tipoControl;
				string nonCtl = atr.nombreControl;
				code += "Me.lbl" + atr.Nombre + " =New System.Windows.Forms.Label" + Constants.vbCrLf;

				if (atr.Nombre.Substring(atr.Nombre.Length - 3, 3).Equals("_id") & !this.clace.llave.Equals(atr.Nombre)) {
					tipoCtl = "cmb";
					nonCtl = "ComboBox";
				}


				code += "Me." + tipoCtl + atr.Nombre + "= New System.Windows.Forms." + nonCtl + Constants.vbCrLf;
			}

			code += "       Me.pnlDatos.SuspendLayout()" + Constants.vbCrLf;
			code += "       Me.SuspendLayout()" + Constants.vbCrLf;
			code += this.creaPanelDatos();
			code += this.crealblFalta();
			code += this.creaBusqueda();
			code += this.creaMaestro();
			//Para iniciar los controles

			foreach (Propiedad atr in this.clace.Campos) {
				code += this.creaControles(atr);
			}

			code += this.creaForma() + Constants.vbCrLf;
			code += "End sub" + Constants.vbCrLf;

			return code;
		}


		public string creaPanelDatos()
		{
			string code = string.Empty;
			code += "'" + Constants.vbCrLf;
			code += "'pnlDatos" + Constants.vbCrLf;
			code += "'" + Constants.vbCrLf;
			code += "Me.pnlDatos.BackColor = System.Drawing.Color.FromArgb(";
			code += "CType(CType(192, Byte), Integer), ";
			code += "CType(CType(255, Byte), Integer), ";
			code += "CType(CType(255, Byte), Integer))" + Constants.vbCrLf;
			code += "Me.pnlDatos.Controls.Add(Me.lblFalta)" + Constants.vbCrLf;

			foreach (Propiedad atr in this.clace.Campos) {
				string tipoCtl = atr.tipoControl;

				if (atr.Nombre.Substring(atr.Nombre.Length - 3, 3).Equals("_id") & !this.clace.llave.Equals(atr.Nombre)) {
					tipoCtl = "cmb";
				}
				code += "Me.pnlDatos.Controls.Add(Me.lbl" + atr.Nombre + ")" + Constants.vbCrLf;
				code += "Me.pnlDatos.Controls.Add(Me." + tipoCtl + atr.Nombre + ")" + Constants.vbCrLf;
			}
			code += "Me.pnlDatos.Location = New System.Drawing.Point(0, 50)" + Constants.vbCrLf;
			code += "Me.pnlDatos.Name = \"pnlDatos\"" + Constants.vbCrLf;
			code += "Me.pnlDatos.Size = New System.Drawing.Size(300, " + (this.clace.Campos.Count * 30) + 50 + ")" + Constants.vbCrLf;
			code += "Me.pnlDatos.TabIndex = 0" + Constants.vbCrLf;
			return code;
		}

		public string crealblFalta()
		{
			string code = string.Empty;

			code += "'lblFalta" + Constants.vbCrLf;
			code += "'" + Constants.vbCrLf;
			code += "Me.lblFalta.AutoSize = True" + Constants.vbCrLf;
			code += "Me.lblFalta.Font = New System.Drawing.Font(\"Microsoft Sans Serif\", 9.75!, ";
			code += "System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))" + Constants.vbCrLf;
			code += "Me.lblFalta.ForeColor = System.Drawing.Color.Red" + Constants.vbCrLf;
			code += "Me.lblFalta.Location = New System.Drawing.Point(100," + (this.clace.Campos.Count - 1) * 30 + ")" + Constants.vbCrLf;
			code += "Me.lblFalta.Name = \"lblFalta\" " + Constants.vbCrLf;
			code += "Me.lblFalta.Size = New System.Drawing.Size(0, 16)" + Constants.vbCrLf;
			code += "Me.lblFalta.TabIndex = 5" + Constants.vbCrLf;
			return code;

		}
		public object creaFriends()
		{
			string code = string.Empty;
			code += "Friend WithEvents CtlABCMaestro As Sist" + this.neimespeis + ".ctlABCMaestro" + Constants.vbCrLf;
			code += "Friend WithEvents CtlbuscaReg As Sist" + this.neimespeis + ".ctlbuscaReg" + Constants.vbCrLf;
			code += "Friend WithEvents pnlDatos As System.Windows.Forms.Panel" + Constants.vbCrLf;
			code += "Friend WithEvents lblFalta As System.Windows.Forms.Label" + Constants.vbCrLf;
			foreach (Propiedad atr in this.clace.Campos) {
				string tipoCtl = atr.tipoControl;
				string nonCtl = atr.nombreControl;
				code += "Friend WithEvents lbl" + atr.Nombre + " As System.Windows.Forms.Label" + Constants.vbCrLf;

				if (atr.Nombre.Substring(atr.Nombre.Length - 3, 3).Equals("_id") & !this.clace.llave.Equals(atr.Nombre)) {
					tipoCtl = "cmb";
					nonCtl = "ComboBox";
				}
				code += "Friend WithEvents " + tipoCtl + atr.Nombre + " As System.Windows.Forms." + nonCtl + Constants.vbCrLf;
			}

			return code;
		}
		public string creaControles(Propiedad atr)
		{
			string code = string.Empty;
			code += this.creaEtiqueta(atr);
			code += this.creaCapturador(atr);
			return code;
		}

		public string creaEtiqueta(Propiedad atr)
		{
			string code = string.Empty;
			code += "'" + Constants.vbCrLf;
			code += "'lbl" + atr.titulo + Constants.vbCrLf;
			code += "'" + Constants.vbCrLf;
			code += "Me.lbl" + atr.titulo + ".AutoSize = True" + Constants.vbCrLf;
			code += "Me.lbl" + atr.titulo + ".Font = ";
			code += "New System.Drawing.Font(\"Microsoft Sans Serif\", 9.75!, ";
			code += "System.Drawing.FontStyle.Bold, ";
			code += "System.Drawing.GraphicsUnit.Point, CType(0, Byte))" + Constants.vbCrLf;
			code += "Me.lbl" + atr.titulo + ".Location = New System.Drawing.Point(20, " + (25 * this.tabIndex) + 5 + ")" + Constants.vbCrLf;
			code += "Me.lbl" + atr.titulo + ".Name = \"lbl" + atr.titulo + "\"" + Constants.vbCrLf;
			code += "Me.lbl" + atr.titulo + ".Size = New System.Drawing.Size(" + atr.Nombre.Length * 10 + ", 16)" + Constants.vbCrLf;
			code += "Me.lbl" + atr.titulo + ".TabIndex = 0" + Constants.vbCrLf;
			code += "Me.lbl" + atr.titulo + ".Text = \"" + atr.titulo + "\"" + Constants.vbCrLf;
			return code;
		}
		public string creaCapturador(Propiedad atr)
		{
			string code = string.Empty;
			string tipoCtl = atr.tipoControl;

			if (atr.Nombre.Substring(atr.Nombre.Length - 3, 3).Equals("_id") & !this.clace.llave.Equals(atr.Nombre)) {
				tipoCtl = "cmb";

			}
			code += "'" + Constants.vbCrLf;
			code += "'" + tipoCtl + atr.titulo + Constants.vbCrLf;
			code += "'" + Constants.vbCrLf;
			code += "Me." + tipoCtl + atr.titulo + ".Enabled = False" + Constants.vbCrLf;
			code += "Me." + tipoCtl + atr.titulo + ".Location =  New System.Drawing.Point(150, " + (25 * this.tabIndex) + 5 + ")" + Constants.vbCrLf;
			code += "Me." + tipoCtl + atr.titulo + ".Name = \"" + tipoCtl + atr.titulo + "\"" + Constants.vbCrLf;
			if (atr.Nombre.Equals(this.clace.llave)) {
				code += "Me." + tipoCtl + atr.titulo + ".ReadOnly = True" + Constants.vbCrLf;
			}
			code += "Me." + tipoCtl + atr.titulo + ".Size = New System.Drawing.Size(100, 20)" + Constants.vbCrLf;
			code += "Me." + tipoCtl + atr.titulo + ".TabIndex = " + this.tabIndex + Constants.vbCrLf;
			this.tabIndex += 1;
			return code;
		}
		public string creaForma()
		{
			string code = string.Empty;
			code += "'" + Constants.vbCrLf;
			code += "'frm" + this.clace.NombreTabla + Constants.vbCrLf;
			code += "'" + Constants.vbCrLf;
			code += "Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)" + Constants.vbCrLf;
			code += "Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font" + Constants.vbCrLf;
			code += "Me.ClientSize = New System.Drawing.Size(300," + (this.clace.Campos.Count * 30) + 100 + ")" + Constants.vbCrLf;
			code += "Me.Controls.Add(Me.pnlDatos)" + Constants.vbCrLf;
			code += "Me.Controls.Add(Me.CtlbuscaReg)" + Constants.vbCrLf;
			code += "Me.Controls.Add(Me.CtlABCMaestro)" + Constants.vbCrLf;
			code += "Me.Name = \"frm" + this.clace.NombreTabla + "\"" + Constants.vbCrLf;
			code += "Me.Text = \"" + this.clace.NombreTabla + "\"" + Constants.vbCrLf;
			code += "Me.pnlDatos.ResumeLayout(False)" + Constants.vbCrLf;
			code += "Me.pnlDatos.PerformLayout()" + Constants.vbCrLf;
			code += "Me.ResumeLayout(False)" + Constants.vbCrLf;
			return code;
		}
		public string creaBusqueda()
		{
			string code = string.Empty;
			code += "'" + Constants.vbCrLf;
			code += "'CtlbuscaReg" + Constants.vbCrLf;
			code += "'" + Constants.vbCrLf;
			code += "Me.CtlbuscaReg.Location = New System.Drawing.Point(0, 0)" + Constants.vbCrLf;
			code += "Me.CtlbuscaReg.Name = \"CtlbuscaReg\"" + Constants.vbCrLf;
			code += "Me.CtlbuscaReg.Size = New System.Drawing.Size(516, 25)" + Constants.vbCrLf;
			code += "Me.CtlbuscaReg.TabIndex = 1" + Constants.vbCrLf;
			return code;
		}
		public string creaMaestro()
		{
			string code = string.Empty;
			code += "'" + Constants.vbCrLf;
			code += "'CtlABCMaestro" + Constants.vbCrLf;
			code += "'" + Constants.vbCrLf;
			code += "Me.CtlABCMaestro.Estado = 0" + Constants.vbCrLf;
			code += "Me.CtlABCMaestro.Location = New System.Drawing.Point(0, 27)" + Constants.vbCrLf;
			code += "Me.CtlABCMaestro.Name = \"CtlABCMaestro\"" + Constants.vbCrLf;
			code += "Me.CtlABCMaestro.Size = New System.Drawing.Size(516, 25)" + Constants.vbCrLf;
			code += "Me.CtlABCMaestro.TabIndex = 0" + Constants.vbCrLf;
			return code;
		}






	}
}
