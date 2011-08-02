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
	public class ManejaClase : System.Windows.Forms.UserControl
	{


		#region "codigo"
		//UserControl overrides dispose to clean up the component list.
		private System.Windows.Forms.CheckedListBox withEventsField_clbCampos;
		internal System.Windows.Forms.CheckedListBox clbCampos {
			get { return withEventsField_clbCampos; }
			set {
				if (withEventsField_clbCampos != null) {
					withEventsField_clbCampos.KeyDown -= clbCampos_KeyDown;
				}
				withEventsField_clbCampos = value;
				if (withEventsField_clbCampos != null) {
					withEventsField_clbCampos.KeyDown += clbCampos_KeyDown;
				}
			}
		}
		internal System.Windows.Forms.Label lblClase;
		private System.Windows.Forms.CheckBox withEventsField_chbTodos;
		internal System.Windows.Forms.CheckBox chbTodos {
			get { return withEventsField_chbTodos; }
			set {
				if (withEventsField_chbTodos != null) {
					withEventsField_chbTodos.CheckedChanged -= chbTodos_CheckedChanged;
				}
				withEventsField_chbTodos = value;
				if (withEventsField_chbTodos != null) {
					withEventsField_chbTodos.CheckedChanged += chbTodos_CheckedChanged;
				}
			}
		}
		internal System.Windows.Forms.CheckBox chbIncluir;
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
			this.clbCampos = new System.Windows.Forms.CheckedListBox();
			this.lblClase = new System.Windows.Forms.Label();
			this.chbTodos = new System.Windows.Forms.CheckBox();
			this.chbIncluir = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			//
			//clbCampos
			//
			this.clbCampos.FormattingEnabled = true;
			this.clbCampos.Location = new System.Drawing.Point(0, 16);
			this.clbCampos.Name = "clbCampos";
			this.clbCampos.Size = new System.Drawing.Size(120, 94);
			this.clbCampos.TabIndex = 0;
			//
			//lblClase
			//
			this.lblClase.AutoSize = true;
			this.lblClase.Location = new System.Drawing.Point(50, 0);
			this.lblClase.Name = "lblClase";
			this.lblClase.Size = new System.Drawing.Size(39, 13);
			this.lblClase.TabIndex = 1;
			this.lblClase.Text = "Label1";
			//
			//chbTodos
			//
			this.chbTodos.AutoSize = true;
			this.chbTodos.Location = new System.Drawing.Point(0, 113);
			this.chbTodos.Name = "chbTodos";
			this.chbTodos.Size = new System.Drawing.Size(115, 17);
			this.chbTodos.TabIndex = 2;
			this.chbTodos.Text = "Seleccionar Todos";
			this.chbTodos.UseVisualStyleBackColor = true;
			//
			//chbIncluir
			//
			this.chbIncluir.AutoSize = true;
			this.chbIncluir.Location = new System.Drawing.Point(33, 0);
			this.chbIncluir.Name = "chbIncluir";
			this.chbIncluir.Size = new System.Drawing.Size(15, 14);
			this.chbIncluir.TabIndex = 3;
			this.chbIncluir.Checked = true;
			this.chbIncluir.UseVisualStyleBackColor = true;
			//
			//ManejaClase
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.chbIncluir);
			this.Controls.Add(this.chbTodos);
			this.Controls.Add(this.lblClase);
			this.Controls.Add(this.clbCampos);
			this.Name = "ManejaClase";
			this.Size = new System.Drawing.Size(122, 137);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

			//bandera que nos dirá si el user ya presiono el clic dentro del mouse... por lo tanto se iniciará el movimiento
		public bool Moviendose = false;
			//Como el evento MouseMove se repite constantemente cada vez que detecta el movimiento del mouse, esta bandera nos dira si es la primera vez que se detecta el movimiento despues de presionar el mouse
		public bool PrimeraMovida = false;
			//contendrá la posicion del cursor en "X" exactamente despues de que se presiona el mouse y antes de que se comience a mover el mouse
		public  int posicionInicialCursorX = 0;
		public  int posicionInicialCursorY = 0;
		private bool bcel;
		private Clase _Clase;
		private TextBox _txtDetalle;
		private DataGridView _datagridCampos;
		public Clase Clase {
			get { return this._Clase; }
			set { this._Clase = value; }
		}
		public DataGridView DataGridCampos {
			get { return this._datagridCampos; }
			set { this._datagridCampos = value; }
		}
		public TextBox txtDetalle {
			get { return this._txtDetalle; }
			set { this._txtDetalle = value; }
		}



		private void ManejaClase_Load(object sender, System.EventArgs e)
		{
			this.InitializeComponent();
			int f = 0;
			this.clbCampos.BeginUpdate();
			for (f = 0; f <= this.Clase.Campos.Count - 1; f++) {
				this.clbCampos.Items.Add(this.Clase.Campos[f].Nombre);
			}
			this.clbCampos.EndUpdate();

			this.lblClase.Text = this.Clase.NombreTabla;
			this.chbIncluir.Checked = true;
			this.chbTodos.Checked = true;
			this.Width = this.clbCampos.Width;
			this.Height = this.clbCampos.Height + 34;
			if ((txtDetalle != null)) {
				this.clbCampos.MouseHover += dimeClase;
			}

			if ((this.DataGridCampos != null)) {
				this.DoubleClick += CargaGrid;
			}

			this.MouseDown += BotonDown;
			this.MouseUp += BotonUp;
			this.MouseMove += BotonMove;

		}

		private void CargaGrid(object sender, System.EventArgs e)
		{
			int i = 0;
			for (i = 0; i <= this.Clase.Campos.Count - 1; i++) {
				this.DataGridCampos.Rows.Add(this.Clase.Campos[i].Nombre, this.Clase.Campos[i].Tipo);
			}
		}
		private void chbTodos_CheckedChanged(System.Object sender, System.EventArgs e)
		{
			int f = 0;
			for (f = 0; f <= this.clbCampos.Items.Count - 1; f++) {
				this.clbCampos.SetItemChecked(f, ((RadioButton)(sender)).Checked);
				//                clb.Items.Item(f).Checked = True
			}

		}
		private void dimeClase(object sender, System.EventArgs e)
		{
			this.txtDetalle.Text = ((CheckedListBox)(sender)).Tag.ToString();
		}

		public void BotonDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Moviendose = true;
			//como se presiono el mouse, se iniciará el movimiento del boton
		}

		public void BotonUp(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Moviendose = false;
			//como se soltó el mouse, se detendrá el movimiento del boton
			PrimeraMovida = false;
			//reiniciamos la bandera
		}

		public void BotonMove(System.Object sender, System.Windows.Forms.MouseEventArgs e)
		{
			//Sí se esta moviendo el mouse, entonces:
			if ((Moviendose == true)) {
				//Sí es la primera movida despues de presionar el mouse, entonces:
				if ((PrimeraMovida == false)) {
					PrimeraMovida = true;
					//igualamos la bandera a true para que no vuelva a entrar aquí
					posicionInicialCursorX = e.X;
					//obtenemos la posicion del cursor en X al inicarse el movimiento
					posicionInicialCursorY = e.Y;
					//obtenemos la posicion del cursor en Y al inicarse el movimiento
				}
				this.Location = new Point(e.X + this.Location.X - posicionInicialCursorX, e.Y + this.Location.Y - posicionInicialCursorY);
				//reposisionamos el boton en las nuevas coordenadas
			}

		}


		private void clbCampos_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete) {
				if (this.clbCampos.Items.Count > 0) {
					this.clbCampos.Items.Remove(this.clbCampos.SelectedItem);
				}
			}
		}
		public ManejaClase()
		{
			Load += ManejaClase_Load;
		}
	}
}
