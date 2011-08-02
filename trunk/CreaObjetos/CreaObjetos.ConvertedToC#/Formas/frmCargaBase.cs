using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsApplication1
{

	public class frmCargaBase : System.Windows.Forms.Form
	{
		SqlConnection myConnection;
		List<string> Tablas = new List<string>();
		DataTable userTables;
		//Dim frmCreaCodigo As New FrmGeneraCodigo
		#region "Codigo"
		internal System.Windows.Forms.TextBox txtServer;
		private System.Windows.Forms.Button withEventsField_btnCreaClase;
		internal System.Windows.Forms.Button btnCreaClase {
			get { return withEventsField_btnCreaClase; }
			set {
				if (withEventsField_btnCreaClase != null) {
					withEventsField_btnCreaClase.Click -= btnCreaClase_Click;
				}
				withEventsField_btnCreaClase = value;
				if (withEventsField_btnCreaClase != null) {
					withEventsField_btnCreaClase.Click += btnCreaClase_Click;
				}
			}
		}
		private System.Windows.Forms.ComboBox withEventsField_cmbSQLDatabase;
		internal System.Windows.Forms.ComboBox cmbSQLDatabase {
			get { return withEventsField_cmbSQLDatabase; }
			set {
				if (withEventsField_cmbSQLDatabase != null) {
					withEventsField_cmbSQLDatabase.SelectedIndexChanged -= cmbSQLDatabase_SelectedIndexChanged;
				}
				withEventsField_cmbSQLDatabase = value;
				if (withEventsField_cmbSQLDatabase != null) {
					withEventsField_cmbSQLDatabase.SelectedIndexChanged += cmbSQLDatabase_SelectedIndexChanged;
				}
			}
		}
		private System.Windows.Forms.Button withEventsField_btnOpenSQL;
		internal System.Windows.Forms.Button btnOpenSQL {
			get { return withEventsField_btnOpenSQL; }
			set {
				if (withEventsField_btnOpenSQL != null) {
					withEventsField_btnOpenSQL.Click -= btnOpenSQL_Click;
				}
				withEventsField_btnOpenSQL = value;
				if (withEventsField_btnOpenSQL != null) {
					withEventsField_btnOpenSQL.Click += btnOpenSQL_Click;
				}
			}
		}
		internal System.Windows.Forms.TextBox txtUsuario;
		internal System.Windows.Forms.TextBox txtContrasena;
		internal System.Windows.Forms.Label lblUsuario;
		internal System.Windows.Forms.Label lblContrasena;
		internal System.Windows.Forms.Label lblBase;
		private System.Windows.Forms.Button withEventsField_Button1;
		internal System.Windows.Forms.Button Button1 {
			get { return withEventsField_Button1; }
			set {
				if (withEventsField_Button1 != null) {
					withEventsField_Button1.Click -= Button1_Click;
				}
				withEventsField_Button1 = value;
				if (withEventsField_Button1 != null) {
					withEventsField_Button1.Click += Button1_Click;
				}
			}
		}

		internal System.Windows.Forms.Label lblServidor;
		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
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
			this.txtServer = new System.Windows.Forms.TextBox();
			this.btnCreaClase = new System.Windows.Forms.Button();
			this.cmbSQLDatabase = new System.Windows.Forms.ComboBox();
			this.btnOpenSQL = new System.Windows.Forms.Button();
			this.txtUsuario = new System.Windows.Forms.TextBox();
			this.txtContrasena = new System.Windows.Forms.TextBox();
			this.lblUsuario = new System.Windows.Forms.Label();
			this.lblContrasena = new System.Windows.Forms.Label();
			this.lblBase = new System.Windows.Forms.Label();
			this.lblServidor = new System.Windows.Forms.Label();
			this.Button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			//
			//txtServer
			//
			this.txtServer.Location = new System.Drawing.Point(74, 12);
			this.txtServer.Name = "txtServer";
			this.txtServer.Size = new System.Drawing.Size(164, 20);
			this.txtServer.TabIndex = 30;
			this.txtServer.Text = "CSC-ARMANDO\\CSCARMANDO";
			//
			//btnCreaClase
			//
			this.btnCreaClase.Location = new System.Drawing.Point(244, 69);
			this.btnCreaClase.Name = "btnCreaClase";
			this.btnCreaClase.Size = new System.Drawing.Size(75, 43);
			this.btnCreaClase.TabIndex = 29;
			this.btnCreaClase.Text = "CargaClases";
			this.btnCreaClase.UseVisualStyleBackColor = true;
			//
			//cmbSQLDatabase
			//
			this.cmbSQLDatabase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSQLDatabase.FormattingEnabled = true;
			this.cmbSQLDatabase.Location = new System.Drawing.Point(74, 90);
			this.cmbSQLDatabase.Name = "cmbSQLDatabase";
			this.cmbSQLDatabase.Size = new System.Drawing.Size(121, 21);
			this.cmbSQLDatabase.TabIndex = 28;
			//
			//btnOpenSQL
			//
			this.btnOpenSQL.Location = new System.Drawing.Point(243, 11);
			this.btnOpenSQL.Name = "btnOpenSQL";
			this.btnOpenSQL.Size = new System.Drawing.Size(45, 41);
			this.btnOpenSQL.TabIndex = 27;
			this.btnOpenSQL.Text = "OpenSQL";
			this.btnOpenSQL.UseVisualStyleBackColor = true;
			//
			//txtUsuario
			//
			this.txtUsuario.Location = new System.Drawing.Point(74, 38);
			this.txtUsuario.Name = "txtUsuario";
			this.txtUsuario.Size = new System.Drawing.Size(100, 20);
			this.txtUsuario.TabIndex = 31;
			this.txtUsuario.Text = "sa";
			//
			//txtContrasena
			//
			this.txtContrasena.Location = new System.Drawing.Point(74, 61);
			this.txtContrasena.Name = "txtContrasena";
			this.txtContrasena.PasswordChar = Strings.ChrW(42);
			this.txtContrasena.Size = new System.Drawing.Size(100, 20);
			this.txtContrasena.TabIndex = 32;
			this.txtContrasena.Text = "Asteroide23";
			//
			//lblUsuario
			//
			this.lblUsuario.AutoSize = true;
			this.lblUsuario.Location = new System.Drawing.Point(12, 39);
			this.lblUsuario.Name = "lblUsuario";
			this.lblUsuario.Size = new System.Drawing.Size(43, 13);
			this.lblUsuario.TabIndex = 33;
			this.lblUsuario.Text = "Usuario";
			//
			//lblContrasena
			//
			this.lblContrasena.AutoSize = true;
			this.lblContrasena.Location = new System.Drawing.Point(12, 69);
			this.lblContrasena.Name = "lblContrasena";
			this.lblContrasena.Size = new System.Drawing.Size(53, 13);
			this.lblContrasena.TabIndex = 34;
			this.lblContrasena.Text = "Password";
			//
			//lblBase
			//
			this.lblBase.AutoSize = true;
			this.lblBase.Location = new System.Drawing.Point(12, 94);
			this.lblBase.Name = "lblBase";
			this.lblBase.Size = new System.Drawing.Size(31, 13);
			this.lblBase.TabIndex = 35;
			this.lblBase.Text = "Base";
			//
			//lblServidor
			//
			this.lblServidor.AutoSize = true;
			this.lblServidor.Location = new System.Drawing.Point(12, 16);
			this.lblServidor.Name = "lblServidor";
			this.lblServidor.Size = new System.Drawing.Size(46, 13);
			this.lblServidor.TabIndex = 36;
			this.lblServidor.Text = "Servidor";
			//
			//Button1
			//
			this.Button1.Image = global::WindowsApplication1.My.Resources.Resources.open_file_32;
			this.Button1.Location = new System.Drawing.Point(294, 10);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(41, 42);
			this.Button1.TabIndex = 38;
			this.Button1.UseVisualStyleBackColor = true;
			//
			//frmCargaBase
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(338, 124);
			this.Controls.Add(this.Button1);
			this.Controls.Add(this.lblServidor);
			this.Controls.Add(this.lblBase);
			this.Controls.Add(this.lblContrasena);
			this.Controls.Add(this.lblUsuario);
			this.Controls.Add(this.txtContrasena);
			this.Controls.Add(this.txtUsuario);
			this.Controls.Add(this.txtServer);
			this.Controls.Add(this.btnCreaClase);
			this.Controls.Add(this.cmbSQLDatabase);
			this.Controls.Add(this.btnOpenSQL);
			this.Name = "frmCargaBase";
			this.Text = "FormaCargaBase";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private void btnOpenSQL_Click(System.Object sender, System.EventArgs e)
		{
			SqlCommand myCommand = null;
			SqlDataReader sdr = null;

			myConnection = new SqlConnection("Data Source=" + this.txtServer.Text + ";Uid=" + this.txtUsuario.Text + ";Pwd=" + this.txtContrasena.Text);
			myConnection.Open();

			myCommand = new SqlCommand();
			myCommand.Connection = myConnection;

			myCommand.CommandType = CommandType.StoredProcedure;
			myCommand.CommandText = "sp_databases";

			sdr = myCommand.ExecuteReader();

			while ((sdr.Read())) {
				this.cmbSQLDatabase.Items.Add(sdr.GetString(0));
			}
			sdr.Close();
			myConnection.Close();
			if (this.cmbSQLDatabase.Items.Count > 0) {
				this.cmbSQLDatabase.SelectedIndex = 0;
			}

		}

		private void cmbSQLDatabase_SelectedIndexChanged(System.Object sender, System.EventArgs e)
		{
			SqlCommand myCommand = null;

			myConnection.Open();

			myCommand = new SqlCommand();
			myCommand.CommandText = "use " + cmbSQLDatabase.Text;
			myCommand.Connection = myConnection;
			myCommand.ExecuteNonQuery();
			userTables = new DataTable();
			userTables = myConnection.GetSchema("Tables");
			int n = 0;
			n = 0;
			for (n = 0; n <= userTables.Rows.Count - 1; n++) {
				Tablas.Add(userTables.Rows[n][2].ToString());
			}

			myConnection.Close();

		}


		private void btnCreaClase_Click(System.Object sender, System.EventArgs e)
		{
			if (this.cmbSQLDatabase.Items.Count>0) {
				My.MyProject.Forms.FrmPrincipal.Tablas = this.Tablas;
				My.MyProject.Forms.FrmPrincipal.sqlCon = this.myConnection;
				My.MyProject.Forms.FrmPrincipal.baseDatos = this.cmbSQLDatabase.Text;
				My.MyProject.Forms.FrmPrincipal.Show();
				My.MyProject.Forms.FrmPrincipal.crearClases();
				this.Close();
			} else {
				MessageBox.Show("Conectese primero a una base de datos");
			}

		}

		private void Forma_Load(object sender, System.EventArgs e)
		{
			this.InitializeComponent();
		}


		private void Button1_Click(System.Object sender, System.EventArgs e)
		{
			OpenFileDialog ofdBase = new OpenFileDialog();
			SqlCommand myCommand = null;
			Tablas = new List<string>();

			ofdBase.ShowDialog();

			myConnection = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=" + ofdBase.FileName + ";Integrated Security=True;Connect Timeout=30;User Instance=True");
			myConnection.Open();

			myCommand = new SqlCommand();
			myCommand.CommandText = "SELECT * from information_schema.Tables";
			myCommand.Connection = myConnection;
			myCommand.ExecuteNonQuery();
			userTables = new DataTable();
			userTables = myConnection.GetSchema("Tables");
			int n = 0;
			n = 0;

			for (n = 0; n <= userTables.Rows.Count - 1; n++) {
				Tablas.Add(userTables.Rows[n][2].ToString());
			}
			myConnection.Close();

			My.MyProject.Forms.FrmPrincipal.Tablas = this.Tablas;
			My.MyProject.Forms.FrmPrincipal.sqlCon = this.myConnection;
			//FrmPrincipal.baseDatos = Me.cmbSQLDatabase.Text
			My.MyProject.Forms.FrmPrincipal.Show();
			My.MyProject.Forms.FrmPrincipal.crearClases();
			this.Close();


		}
		public frmCargaBase()
		{
			Load += Forma_Load;
		}

	}
}
