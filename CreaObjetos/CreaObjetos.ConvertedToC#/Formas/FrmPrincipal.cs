using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace WindowsApplication1
{

	public class FrmPrincipal : System.Windows.Forms.Form
	{
		#region "Campos"
		public List<string> Tablas = new List<string>();
		List<Clase> clases;
		private string _baseDatos;

		private SqlConnection _sqlCon;
		#endregion

		#region "Propiedades"
		public string baseDatos {
			get { return this._baseDatos; }
			set { this._baseDatos = value; }
		}
		public SqlConnection sqlCon {
			get { return this._sqlCon; }
			set { this._sqlCon = value; }
		}
		#endregion

		#region "codigo"
		internal System.Windows.Forms.OpenFileDialog OpenFileDialog1;
		internal System.Windows.Forms.Label lblBase;
		internal System.Windows.Forms.Label lblTablaSQL;
		internal System.Windows.Forms.ComboBox cmbTablas;
		internal System.Windows.Forms.TabControl tbcClase;
		internal System.Windows.Forms.TabPage tbpRelaciones;
		internal System.Windows.Forms.Button btnAgrega;
		private System.Windows.Forms.DataGridView withEventsField_DataGridRelaciones;
		internal System.Windows.Forms.DataGridView DataGridRelaciones {
			get { return withEventsField_DataGridRelaciones; }
			set {
				if (withEventsField_DataGridRelaciones != null) {
					withEventsField_DataGridRelaciones.CellContentClick -= DataGridRelaciones_CellContentClick;
					withEventsField_DataGridRelaciones.DataError -= DataGridRelaciones_DataError;
				}
				withEventsField_DataGridRelaciones = value;
				if (withEventsField_DataGridRelaciones != null) {
					withEventsField_DataGridRelaciones.CellContentClick += DataGridRelaciones_CellContentClick;
					withEventsField_DataGridRelaciones.DataError += DataGridRelaciones_DataError;
				}
			}
		}
		internal System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
		internal System.Windows.Forms.DataGridViewComboBoxColumn Tipo;
		internal System.Windows.Forms.DataGridViewComboBoxColumn Atomicidad;
		internal System.Windows.Forms.TabPage tbpCampos;
		internal System.Windows.Forms.DataGridView DataGridCampo;
		internal System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn1;
		internal System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumn2;
		internal System.Windows.Forms.TabPage tbpOpcion;
		internal System.Windows.Forms.TabPage tbpMetodos;
		internal System.Windows.Forms.TabPage tbClases;
		internal System.Windows.Forms.TreeView tvwClases;
		internal System.Windows.Forms.ImageList imlClase;
		internal System.Windows.Forms.MenuStrip MenuStrip1;
		internal System.Windows.Forms.ToolStripMenuItem ArchivoToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem CrearCodigoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem withEventsField_GenerarToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem GenerarToolStripMenuItem {
			get { return withEventsField_GenerarToolStripMenuItem; }
			set {
				if (withEventsField_GenerarToolStripMenuItem != null) {
					withEventsField_GenerarToolStripMenuItem.Click -= GenerarToolStripMenuItem_Click;
				}
				withEventsField_GenerarToolStripMenuItem = value;
				if (withEventsField_GenerarToolStripMenuItem != null) {
					withEventsField_GenerarToolStripMenuItem.Click += GenerarToolStripMenuItem_Click;
				}
			}
		}
		internal WindowsApplication1.ctlManejaClases cmcClases;
		private System.Windows.Forms.ToolStripMenuItem withEventsField_NuevoToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem NuevoToolStripMenuItem {
			get { return withEventsField_NuevoToolStripMenuItem; }
			set {
				if (withEventsField_NuevoToolStripMenuItem != null) {
					withEventsField_NuevoToolStripMenuItem.Click -= NuevoToolStripMenuItem_Click;
				}
				withEventsField_NuevoToolStripMenuItem = value;
				if (withEventsField_NuevoToolStripMenuItem != null) {
					withEventsField_NuevoToolStripMenuItem.Click += NuevoToolStripMenuItem_Click;
				}
			}

		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		//Required by the Windows Form Designer

		private System.ComponentModel.IContainer components;
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.  
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
			this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.lblBase = new System.Windows.Forms.Label();
			this.lblTablaSQL = new System.Windows.Forms.Label();
			this.cmbTablas = new System.Windows.Forms.ComboBox();
			this.tbcClase = new System.Windows.Forms.TabControl();
			this.tbpRelaciones = new System.Windows.Forms.TabPage();
			this.btnAgrega = new System.Windows.Forms.Button();
			this.DataGridRelaciones = new System.Windows.Forms.DataGridView();
			this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Tipo = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.Atomicidad = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.tbpCampos = new System.Windows.Forms.TabPage();
			this.DataGridCampo = new System.Windows.Forms.DataGridView();
			this.DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.DataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tbpOpcion = new System.Windows.Forms.TabPage();
			this.tbpMetodos = new System.Windows.Forms.TabPage();
			this.tbClases = new System.Windows.Forms.TabPage();
			this.tvwClases = new System.Windows.Forms.TreeView();
			this.imlClase = new System.Windows.Forms.ImageList(this.components);
			this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
			this.ArchivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.NuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.CrearCodigoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.GenerarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cmcClases = new WindowsApplication1.ctlManejaClases();
			this.tbcClase.SuspendLayout();
			this.tbpRelaciones.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.DataGridRelaciones).BeginInit();
			this.tbpCampos.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.DataGridCampo).BeginInit();
			this.tbClases.SuspendLayout();
			this.MenuStrip1.SuspendLayout();
			this.SuspendLayout();
			//
			//lblBase
			//
			this.lblBase.AutoSize = true;
			this.lblBase.Location = new System.Drawing.Point(132, 45);
			this.lblBase.Name = "lblBase";
			this.lblBase.Size = new System.Drawing.Size(0, 13);
			this.lblBase.TabIndex = 8;
			//
			//lblTablaSQL
			//
			this.lblTablaSQL.AutoSize = true;
			this.lblTablaSQL.Location = new System.Drawing.Point(70, 39);
			this.lblTablaSQL.Name = "lblTablaSQL";
			this.lblTablaSQL.Size = new System.Drawing.Size(39, 13);
			this.lblTablaSQL.TabIndex = 17;
			this.lblTablaSQL.Text = "Tablas";
			//
			//cmbTablas
			//
			this.cmbTablas.FormattingEnabled = true;
			this.cmbTablas.Location = new System.Drawing.Point(115, 18);
			this.cmbTablas.Name = "cmbTablas";
			this.cmbTablas.Size = new System.Drawing.Size(121, 21);
			this.cmbTablas.TabIndex = 18;
			//
			//tbcClase
			//
			this.tbcClase.Controls.Add(this.tbpRelaciones);
			this.tbcClase.Controls.Add(this.tbpCampos);
			this.tbcClase.Controls.Add(this.tbpOpcion);
			this.tbcClase.Controls.Add(this.tbpMetodos);
			this.tbcClase.Controls.Add(this.tbClases);
			this.tbcClase.Location = new System.Drawing.Point(209, 556);
			this.tbcClase.Name = "tbcClase";
			this.tbcClase.SelectedIndex = 0;
			this.tbcClase.Size = new System.Drawing.Size(498, 175);
			this.tbcClase.TabIndex = 30;
			//
			//tbpRelaciones
			//
			this.tbpRelaciones.Controls.Add(this.btnAgrega);
			this.tbpRelaciones.Controls.Add(this.DataGridRelaciones);
			this.tbpRelaciones.Location = new System.Drawing.Point(4, 22);
			this.tbpRelaciones.Name = "tbpRelaciones";
			this.tbpRelaciones.Padding = new System.Windows.Forms.Padding(3);
			this.tbpRelaciones.Size = new System.Drawing.Size(490, 149);
			this.tbpRelaciones.TabIndex = 0;
			this.tbpRelaciones.Text = "Relaciones";
			this.tbpRelaciones.UseVisualStyleBackColor = true;
			//
			//btnAgrega
			//
			this.btnAgrega.Location = new System.Drawing.Point(270, 120);
			this.btnAgrega.Name = "btnAgrega";
			this.btnAgrega.Size = new System.Drawing.Size(75, 23);
			this.btnAgrega.TabIndex = 29;
			this.btnAgrega.Text = "Agregar Campo";
			this.btnAgrega.UseVisualStyleBackColor = true;
			//
			//DataGridRelaciones
			//
			this.DataGridRelaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DataGridRelaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
				this.Nombre,
				this.Tipo,
				this.Atomicidad
			});
			this.DataGridRelaciones.Location = new System.Drawing.Point(73, 3);
			this.DataGridRelaciones.Name = "DataGridRelaciones";
			this.DataGridRelaciones.Size = new System.Drawing.Size(344, 115);
			this.DataGridRelaciones.TabIndex = 28;
			//
			//Nombre
			//
			this.Nombre.HeaderText = "Campo";
			this.Nombre.Name = "Nombre";
			this.Nombre.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			//
			//Tipo
			//
			this.Tipo.HeaderText = "Tipo";
			this.Tipo.Name = "Tipo";
			this.Tipo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Tipo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			//
			//Atomicidad
			//
			this.Atomicidad.HeaderText = "Atomicidad";
			this.Atomicidad.Items.AddRange(new object[] {
				"1..N",
				"N..M"
			});
			this.Atomicidad.Name = "Atomicidad";
			this.Atomicidad.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Atomicidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			//
			//tbpCampos
			//
			this.tbpCampos.Controls.Add(this.DataGridCampo);
			this.tbpCampos.Location = new System.Drawing.Point(4, 22);
			this.tbpCampos.Name = "tbpCampos";
			this.tbpCampos.Padding = new System.Windows.Forms.Padding(3);
			this.tbpCampos.Size = new System.Drawing.Size(490, 149);
			this.tbpCampos.TabIndex = 1;
			this.tbpCampos.Text = "Campos";
			this.tbpCampos.UseVisualStyleBackColor = true;
			//
			//DataGridCampo
			//
			this.DataGridCampo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DataGridCampo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
				this.DataGridViewTextBoxColumn1,
				this.DataGridViewTextBoxColumn2
			});
			this.DataGridCampo.Location = new System.Drawing.Point(98, 10);
			this.DataGridCampo.Name = "DataGridCampo";
			this.DataGridCampo.Size = new System.Drawing.Size(244, 115);
			this.DataGridCampo.TabIndex = 30;
			//
			//DataGridViewTextBoxColumn1
			//
			this.DataGridViewTextBoxColumn1.HeaderText = "Campo";
			this.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1";
			//
			//DataGridViewTextBoxColumn2
			//
			this.DataGridViewTextBoxColumn2.HeaderText = "Tipo";
			this.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2";
			//
			//tbpOpcion
			//
			this.tbpOpcion.Location = new System.Drawing.Point(4, 22);
			this.tbpOpcion.Name = "tbpOpcion";
			this.tbpOpcion.Size = new System.Drawing.Size(490, 149);
			this.tbpOpcion.TabIndex = 2;
			this.tbpOpcion.Text = "Opciones";
			this.tbpOpcion.UseVisualStyleBackColor = true;
			//
			//tbpMetodos
			//
			this.tbpMetodos.Location = new System.Drawing.Point(4, 22);
			this.tbpMetodos.Name = "tbpMetodos";
			this.tbpMetodos.Size = new System.Drawing.Size(490, 149);
			this.tbpMetodos.TabIndex = 3;
			this.tbpMetodos.Text = "Metodos";
			this.tbpMetodos.UseVisualStyleBackColor = true;
			//
			//tbClases
			//
			this.tbClases.Controls.Add(this.cmbTablas);
			this.tbClases.Controls.Add(this.lblTablaSQL);
			this.tbClases.Location = new System.Drawing.Point(4, 22);
			this.tbClases.Name = "tbClases";
			this.tbClases.Padding = new System.Windows.Forms.Padding(3);
			this.tbClases.Size = new System.Drawing.Size(490, 149);
			this.tbClases.TabIndex = 4;
			this.tbClases.Text = "Clases";
			this.tbClases.UseVisualStyleBackColor = true;
			//
			//tvwClases
			//
			this.tvwClases.ImageIndex = 0;
			this.tvwClases.ImageList = this.imlClase;
			this.tvwClases.ItemHeight = 20;
			this.tvwClases.Location = new System.Drawing.Point(12, 28);
			this.tvwClases.Name = "tvwClases";
			this.tvwClases.SelectedImageIndex = 0;
			this.tvwClases.Size = new System.Drawing.Size(171, 522);
			this.tvwClases.TabIndex = 35;
			//
			//imlClase
			//
			this.imlClase.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imlClase.ImageStream");
			this.imlClase.TransparentColor = System.Drawing.Color.Transparent;
			this.imlClase.Images.SetKeyName(0, "clase.PNG");
			this.imlClase.Images.SetKeyName(1, "atributo.PNG");
			//
			//MenuStrip1
			//
			this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
				this.ArchivoToolStripMenuItem,
				this.CrearCodigoToolStripMenuItem
			});
			this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
			this.MenuStrip1.Name = "MenuStrip1";
			this.MenuStrip1.Size = new System.Drawing.Size(922, 24);
			this.MenuStrip1.TabIndex = 36;
			this.MenuStrip1.Text = "MenuStrip1";
			//
			//ArchivoToolStripMenuItem
			//
			this.ArchivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.NuevoToolStripMenuItem });
			this.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem";
			this.ArchivoToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
			this.ArchivoToolStripMenuItem.Text = "Archivo";
			//
			//NuevoToolStripMenuItem
			//
			this.NuevoToolStripMenuItem.Name = "NuevoToolStripMenuItem";
			this.NuevoToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
			this.NuevoToolStripMenuItem.Text = "Nuevo";
			//
			//CrearCodigoToolStripMenuItem
			//
			this.CrearCodigoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.GenerarToolStripMenuItem });
			this.CrearCodigoToolStripMenuItem.Name = "CrearCodigoToolStripMenuItem";
			this.CrearCodigoToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
			this.CrearCodigoToolStripMenuItem.Text = "Crear Codigo";
			//
			//GenerarToolStripMenuItem
			//
			this.GenerarToolStripMenuItem.Name = "GenerarToolStripMenuItem";
			this.GenerarToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
			this.GenerarToolStripMenuItem.Text = "Generar";
			//
			//cmcClases
			//
			this.cmcClases.Location = new System.Drawing.Point(190, 28);
			this.cmcClases.Name = "cmcClases";
			this.cmcClases.Size = new System.Drawing.Size(720, 522);
			this.cmcClases.TabIndex = 37;
			//
			//FrmPrincipal
			//
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlLight;
			this.ClientSize = new System.Drawing.Size(922, 734);
			this.Controls.Add(this.cmcClases);
			this.Controls.Add(this.tvwClases);
			this.Controls.Add(this.MenuStrip1);
			this.Controls.Add(this.tbcClase);
			this.Controls.Add(this.lblBase);
			this.MainMenuStrip = this.MenuStrip1;
			this.Name = "FrmPrincipal";
			this.Text = "Class Generator 9000";
			this.tbcClase.ResumeLayout(false);
			this.tbpRelaciones.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.DataGridRelaciones).EndInit();
			this.tbpCampos.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.DataGridCampo).EndInit();
			this.tbClases.ResumeLayout(false);
			this.tbClases.PerformLayout();
			this.MenuStrip1.ResumeLayout(false);
			this.MenuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion


		public void crearClases()
		{
			int i = 0;
			SqlCommand myCommand = null;
			SqlDataReader sdr = null;

			this.sqlCon.Open();
			this.clases = new List<Clase>();

			this.cmcClases.DataGridRelaciones = this.DataGridRelaciones;
			this.cmcClases.pnlClases.Controls.Clear();


			if ((this.tvwClases.Nodes != null)) {
				this.tvwClases.Nodes.Clear();
			}
			TreeNode TreeNode2 = new TreeNode();
			TreeNode2.Name = "Clases";
			TreeNode2.Text = "Clases";
			this.tvwClases.Nodes.AddRange(new System.Windows.Forms.TreeNode[] { TreeNode2 });

			myCommand = new SqlCommand();
			myCommand.Connection = this.sqlCon;
			if ((this.baseDatos != null)) {
				myCommand.CommandText = "use " + this.baseDatos + " select * from information_schema.Tables";
			} else {
				myCommand.CommandText = " select * from information_schema.Tables";
			}
			sdr = myCommand.ExecuteReader();
			while ((sdr.Read())) {
				Clase cls = new Clase();
				cls.NombreTabla = sdr["Table_name"].ToString();
				if ((this.baseDatos != null)) {
					cls.sqlCon = new SqlConnection(this.sqlCon.ConnectionString + "Pwd=Asteroide23;Initial Catalog=" + this.baseDatos);
				//                cls.sqlCon = New SqlConnection(Me.sqlCon.ConnectionString & "Pwd=marquez;Initial Catalog=" & Me.baseDatos)
				} else {
					cls.sqlCon = this.sqlCon;
				}


				this.clases.Add(cls);

			}
			sdr.Close();
			this.sqlCon.Close();

			for (i = 0; i <= clases.Count - 1; i++) {
				int indatr = 0;
				this.clases[i].cargaAtributos();
				this.clases[i].CargaRelaciones();

				TreeNode nodoClase = new TreeNode(clases[i].nombre(), 0, 0);
				this.tvwClases.Nodes.Add(nodoClase);

				for (indatr = 0; indatr <= this.clases[i].Campos.Count - 1; indatr++) {
					nodoClase.Nodes.Add(new TreeNode(clases[i].Campos[indatr].Nombre, 1, 1));
				}

				this.cmcClases.agregaClases(this.clases[i]);
			}

			if (this.Tipo.Items.Count == 0) {
				for (i = 0; i <= this.clases.Count - 1; i++) {
					this.Tipo.Items.Add(this.clases[i].nombre());
				}
			}



		}

		//Private Sub cargaTablas(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DataGridRelaciones.CellBeginEdit
		//    Dim i As Integer
		//    If Me.Tipo.Items.Count = 0 Then
		//        For i = 0 To Me.clases.Count - 1
		//            Me.Tipo.Items.Add(Me.clases(i).nombre)
		//        Next
		//    End If
		//End Sub

		private void NuevoToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			My.MyProject.Forms.frmCargaBase.Show();
		}



		private void GenerarToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			My.MyProject.Forms.frmgeneraOpciones.manejaClases = this.cmcClases.manejaClases;
			My.MyProject.Forms.frmgeneraOpciones.Show();

		}

		private void FrmGeneraCodigo_Load(object sender, System.EventArgs e)
		{
			this.InitializeComponent();
		}


		private void DataGridRelaciones_CellContentClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
		{
		}

		private void DataGridRelaciones_DataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
		{
			MessageBox.Show(e.ToString() + "columna defectuosa" + e.ColumnIndex + "Valor =" + this.DataGridRelaciones[e.ColumnIndex, e.RowIndex].Value);
		}





		private void FrmPrincipal_Resize(object sender, System.EventArgs e)
		{
			this.cmcClases.Width =(int)( this.Width * 0.8);
      this.cmcClases.Height = (int)(this.Height * 0.8);
			this.tbcClase.Location = new Point(this.tbcClase.Location.X, this.cmcClases.Location.Y + this.cmcClases.Height + 10);
		}
		public FrmPrincipal()
		{
			Resize += FrmPrincipal_Resize;
			Load += FrmGeneraCodigo_Load;
		}
	}
}
