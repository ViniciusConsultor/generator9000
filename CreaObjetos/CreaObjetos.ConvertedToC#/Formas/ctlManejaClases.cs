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
	public partial class ctlManejaClases
	{
		public List<ManejaClase> manejaClases = new List<ManejaClase>();
		public DataGridView DataGridRelaciones;

		public List<string> nombresTabla = new List<string>();
		public void agregaClases(Clase clace)
		{
			int n = this.manejaClases.Count;
			ManejaClase clb = new ManejaClase();
			double x = 0;
			double y = 0;

			clb.Clase = clace;
			this.nombresTabla.Add(clace.NombreTabla);


			x = (n % 5) * 125;

			y =(double)(Math.Floor(n / 5M) * 130);


			clb.Location = new System.Drawing.Point((int)x,(int) y);
			clb.Name = "clb" + clace.NombreTabla;
			clb.BackColor = Color.LightGreen;
			clb.Size = new System.Drawing.Size(100, 95);
			clb.Tag = clace.NombreTabla + " " + n;
			clb.TabIndex = 26 + n;

			this.manejaClases.Add(clb);
			this.pnlClases.Controls.Add(clb);
			manejaClases[n].DoubleClick += BorraManejador;
			manejaClases[n].Click += seleccionaManejador;
		}

		private void BorraManejador(object sender, System.EventArgs e)
		{
			this.pnlClases.Controls.Remove((Control)sender);
      this.manejaClases.Remove((ManejaClase)sender);
		}

		private void seleccionaManejador(object sender, System.EventArgs e)
		{
      int index = this.manejaClases.IndexOf((ManejaClase)sender);
			int indRel = 0;
			List<Relacion> rela = this.manejaClases[index].Clase.Relaciones;
			this.DataGridRelaciones.Rows.Clear();
			for (indRel = 0; indRel <= rela.Count - 1; indRel++) {
				int indTablas = 0;
				indTablas = this.nombresTabla.IndexOf(rela[indRel].Tabla);
				// Me.DataGridRelaciones.Columns(2)
				this.DataGridRelaciones.Rows.Add();
				this.DataGridRelaciones[0, indRel].Value = rela[indRel].campo;
				this.AgregaCombo(indTablas, indRel);
				this.comboCargaAtomicidad(0, indRel);


			}
			//        
			//Dim maneja As ManejaClase = Me.manejaClases(Me.manejaClases.FindIndex(sender))
			//       sender.BorderStyle = BorderStyle.FixedSingle

		}

		private void comboCargaAtomicidad(int Valor, int Indice)
		{
			DataTable DTTablas = new DataTable();
			DTTablas.Columns.Add("opcion_id", System.Type.GetType("System.Int32"));
			DTTablas.Columns.Add("nombre", System.Type.GetType("System.String"));

			DataGridViewComboBoxCell combo = new DataGridViewComboBoxCell();
			DTTablas.Rows.Add(0, "1..N");
			DTTablas.Rows.Add(1, "M..N");

			combo.DataSource = DTTablas;
			combo.ValueMember = "opcion_id";
			combo.DisplayMember = "nombre";
			combo.Value = Valor;

			// combo.Value = Me.nombresTabla(Valor)
			this.DataGridRelaciones[2, Indice] = combo;


		}

		private void AgregaCombo(int Valor, int Indice)
		{
			DataTable DTTablas = new DataTable();
			DTTablas.Columns.Add("tabla_id", System.Type.GetType("System.Int32"));
			DTTablas.Columns.Add("nombre", System.Type.GetType("System.String"));

			DataGridViewComboBoxCell combo = new DataGridViewComboBoxCell();
			int i = 0;
			combo = new DataGridViewComboBoxCell();

			for (i = 0; i <= this.nombresTabla.Count - 1; i++) {
				DTTablas.Rows.Add(i, this.nombresTabla[i]);
				//combo.Items.Add(Me.nombresTabla(i))

			}

			combo.DataSource = DTTablas;
			combo.ValueMember = "tabla_id";
			combo.DisplayMember = "nombre";
			combo.Value = Valor;

			// combo.Value = Me.nombresTabla(Valor)
			this.DataGridRelaciones[1, Indice] = combo;


		}

		private void ctlManejaClases_Resize(object sender, System.EventArgs e)
		{
			this.pnlClases.Width = this.Width;
			this.pnlClases.Height = this.Height;
		}

		private void pnlClases_Paint(System.Object sender, System.Windows.Forms.PaintEventArgs e)
		{
		}
		public ctlManejaClases()
		{
			Resize += ctlManejaClases_Resize;
			InitializeComponent();
		}
	}
}
