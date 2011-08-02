using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using WindowsApplication1.GeneraCodigo;

namespace WindowsApplication1
{
	public partial class frmgeneraOpciones
	{

		private RadioButton[] rdbOpciones = new RadioButton[4];
		private int opcionSelecta;
		private List<ManejaClase> _ManejaClases;
		private string directorio;
		public List<ManejaClase> manejaClases {
			get { return this._ManejaClases; }
			set { this._ManejaClases = value; }
		}

		private void btnGeneraClase_Click(System.Object sender, System.EventArgs e)
		{
			string strCodigo = null;
			string neimspace = null;
			neimspace = "";
			while ((neimspace.Equals(""))) {
				neimspace = Interaction.InputBox("Que namespace deseas utilizar");
			}

			//strCodigo = "imports system.data.Sqlclient" & vbCrLf
			//strCodigo &= "namespace " & neimspace & vbCrLf
			strCodigo = this.procesaClases(neimspace) + Constants.vbCrLf;
			//strCodigo &= "end namespace "

			switch (opcionSelecta) {
				case 0:
					Clipboard.SetDataObject(strCodigo);
					break;
				case 1:
					this.TextBox1.Text = strCodigo;
					break;
				case 2:
					MessageBox.Show("Los archivos de clases han sido creados");
					break;
				case 3:
					this.SaveTextToFile(strCodigo, this.buscaDirectorio(), this.nombraArchivo(), "Jodeos");
					MessageBox.Show("El archivo de clases ha sido creado");
					break;
			}
		}


		private void ctlGeneraOpciones_Load(object sender, System.EventArgs e)
		{
			int i = 0;
			this.rdbOpciones[0] = this.rdbClipboard;
			this.rdbOpciones[1] = this.rdbTexto;
			this.rdbOpciones[2] = this.rdbVarios;
			this.rdbOpciones[3] = this.rdbArchivo;

			for (i = 0; i <= this.rdbOpciones.Length - 1; i++) {
				this.rdbOpciones[i].Tag =i.ToString();
				this.rdbOpciones[i].CheckedChanged += escogeOpcion;
			}
			this.rdbOpciones[0].Checked = true;

		}

		private void escogeOpcion(System.Object sender, System.EventArgs e)
		{
			this.opcionSelecta = (int)((RadioButton)(sender)).Tag;
		}

		public string procesaClases(string spacename)
		{
			int c = 0;
			string sclases = null;
			List<Clase> claces = new List<Clase>();

			sclases = "";

			if (this.rdbVarios.Checked) {
				directorio = this.buscaDirectorio();
			}

			for (c = 0; c <= this.manejaClases.Count - 1; c++) {
				ManejaClase mnjClsTemp = this.manejaClases[c];
				//Checa los atributos de las clases y agrega los checados

				if (mnjClsTemp.chbIncluir.Checked) {
					Clase clastemp = new Clase();

					//Inicializa propiedades de clase
					clastemp.llave = mnjClsTemp.Clase.llave;
					clastemp.NombreTabla = mnjClsTemp.Clase.NombreTabla;

					//inicializa Lista de campos
					clastemp.Campos = new List<Propiedad>();
					int indexChecked = 0;
					foreach (int indexChecked_loopVariable in mnjClsTemp.clbCampos.CheckedIndices) {
						indexChecked = indexChecked_loopVariable;
						clastemp.Campos.Add(mnjClsTemp.Clase.Campos[indexChecked]);
					}




					if (this.rdbVarios.Checked) {
						if (this.rdbWapl.Checked) {
							sclases += this.VariosArchivosAppl(spacename, clastemp);
						} else if (this.rdbASP.Checked) {
							sclases += this.VariosArchivosASP(spacename, clastemp);
						}

					}

				}

			}

			return sclases;
		}
		public string VariosArchivosASP(string spacename, Clase clastemp)
		{
			string sclases = string.Empty;

			if (this.chkClasesASP.Checked) {
				var gnrDsn = new creaPagina();
				generaCodPagina gnrCdPg = new generaCodPagina();
				//Diseño
				gnrDsn.neimespeis = spacename;
				gnrDsn.clace = clastemp;
				//Pagina
				gnrCdPg.neimespeis = spacename;
				gnrCdPg.clace = clastemp;
				this.SaveTextToFile(gnrDsn.GeneraPagina(), directorio + "\\Views", clastemp.NombreTabla + "View.aspx", "Jodeos");
				this.SaveTextToFile(gnrCdPg.generaForma(), directorio + "\\Views", clastemp.NombreTabla + "View.aspx.vb", "Jodeos");
			}

			if (this.chkManejador.Checked) {
				generaCodPagina gnrCdPg = new generaCodPagina();
				//Pagina
				gnrCdPg.neimespeis = spacename;
				gnrCdPg.clace = clastemp;
				this.SaveTextToFile(gnrCdPg.generaForma(), directorio + "\\Views", clastemp.NombreTabla + "View.aspx.vb", "Jodeos");
			}


			if (this.chkClases.Checked) {
				GeneraClaseASP genera = new GeneraClaseASP();

				genera.clase = clastemp;
				genera.neimespeis = spacename;
				sclases += genera.GeneraClase();

				this.SaveTextToFile(genera.GeneraClase(), directorio + "\\Models", clastemp.nombre() + ".vb", "Jodeos");
			}
			return sclases;
		}
		public string VariosArchivosAppl(string spacename, Clase clastemp)
		{
			string sclases = string.Empty;
			if (this.chkInterfaz.Checked) {
				var gnrDsn = new creaDiseno();
				var gnrFrm = new generaForma();
				//Diseño
				gnrDsn.neimespeis = spacename;
				gnrDsn.clace = clastemp;
				//Forma
				gnrFrm.neimespeis = spacename;
				gnrFrm.clace = clastemp;
				this.SaveTextToFile(gnrFrm.creaForma(), directorio + "/Views/", "Frm" + clastemp.NombreTabla, "Jodeos");
				this.SaveTextToFile(gnrDsn.GeneraDiseno(), directorio + "/Views/", "Frm" + clastemp.NombreTabla + ".designer", "Jodeos");
			}

			if (this.chkManejador.Checked) {
				generaManejador gnrMnj = new generaManejador();
				//'Manejador
				gnrMnj.neimespeis = spacename;
				gnrMnj.clace = clastemp;
				//'Clase
				this.SaveTextToFile(gnrMnj.generaManeja(), directorio + "/Actions/", "maneja" + clastemp.NombreTabla + ".vb", "Jodeos");
			}


			if (this.chkClases.Checked) {
				GeneraClase genera = new GeneraClase();
				genera.Clase = clastemp;
				genera.Neimespeis = spacename;
				sclases += genera.creaClase();
				this.SaveTextToFile(genera.creaClase(), directorio + "/Models/", clastemp.nombre() + ".vb", "Jodeos");
			}
			return sclases;
		}

		public bool SaveTextToFile(string strData, string FullPath, string nombreArchivo, string ErrInfo = "")
		{

			if (!WindowsApplication1.My.MyProject.Computer.FileSystem.DirectoryExists(FullPath)) {
				WindowsApplication1.My.MyProject.Computer.FileSystem.CreateDirectory(FullPath);
			}
			bool bAns = false;

			StreamWriter objReader = null;
			try {
				objReader = new StreamWriter(FullPath + "\\" + nombreArchivo);
				objReader.Write(strData);
				objReader.Close();
				bAns = true;
			} catch (Exception Ex) {
				ErrInfo = Ex.Message;
			}
			return bAns;
		}
		public string buscaDirectorio()
		{
			FolderBrowserDialog fbdCodigo = new FolderBrowserDialog();
			fbdCodigo.RootFolder = Environment.SpecialFolder.Desktop;
			// Select the C:\Windows directory on entry.
			fbdCodigo.SelectedPath = "c:\\";
			// Prompt the user with a custom message.
			fbdCodigo.Description = "Select the source directory";
			fbdCodigo.ShowDialog();

			return fbdCodigo.SelectedPath;
		}
		public string nombraArchivo()
		{
			string sarchivo = string.Empty;
			while ((sarchivo.Equals(""))) {
				sarchivo = Interaction.InputBox("Como quiero que se llame el archivo de Salida");
			}
			return sarchivo;
		}



		private void rdbWapl_CheckedChanged(System.Object sender, System.EventArgs e)
		{
			this.ActivaChkCodigo(this.rdbWapl.Checked);
		}


		private void ActivaChkCodigo(bool Activado)
		{
			this.chkPagina.Visible = !Activado;
			this.chkClasesASP.Visible = !Activado;
			this.chkMngASP.Visible = !Activado;

			this.chkClases.Visible = Activado;
			this.chkInterfaz.Visible = Activado;
			this.chkManejador.Visible = Activado;

		}
		public frmgeneraOpciones()
		{
			Load += ctlGeneraOpciones_Load;
			InitializeComponent();
		}
	}
}


