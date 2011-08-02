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
	[Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	partial class FrmCargaXml : System.Windows.Forms.Form
	{

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
			this.lsbClases = new System.Windows.Forms.ListBox();
			this.tbpAtributos = new System.Windows.Forms.TabControl();
			this.tbpAtributo = new System.Windows.Forms.TabPage();
			this.lblTipo = new System.Windows.Forms.Label();
			this.chbNulo = new System.Windows.Forms.CheckBox();
			this.txtTipo = new System.Windows.Forms.TextBox();
			this.lsbAtributos = new System.Windows.Forms.ListBox();
			this.tbpMetodos = new System.Windows.Forms.TabPage();
			this.tbpRelaciones = new System.Windows.Forms.TabPage();
			this.Opciones = new System.Windows.Forms.TabPage();
			this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
			this.ArchivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.CargarProyectoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.GuardarProyectoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.chbCrear = new System.Windows.Forms.CheckBox();
			this.CheckBox1 = new System.Windows.Forms.CheckBox();
			this.CheckBox2 = new System.Windows.Forms.CheckBox();
			this.CheckBox3 = new System.Windows.Forms.CheckBox();
			this.CheckBox4 = new System.Windows.Forms.CheckBox();
			this.btnAgrega = new System.Windows.Forms.Button();
			this.DataGridRelaciones = new System.Windows.Forms.DataGridView();
			this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Tipo = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.Atomicidad = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.tbpAtributos.SuspendLayout();
			this.tbpAtributo.SuspendLayout();
			this.tbpMetodos.SuspendLayout();
			this.tbpRelaciones.SuspendLayout();
			this.MenuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.DataGridRelaciones).BeginInit();
			this.SuspendLayout();
			//
			//lsbClases
			//
			this.lsbClases.FormattingEnabled = true;
			this.lsbClases.Location = new System.Drawing.Point(2, 26);
			this.lsbClases.Name = "lsbClases";
			this.lsbClases.Size = new System.Drawing.Size(120, 368);
			this.lsbClases.TabIndex = 0;
			//
			//tbpAtributos
			//
			this.tbpAtributos.Controls.Add(this.tbpAtributo);
			this.tbpAtributos.Controls.Add(this.tbpMetodos);
			this.tbpAtributos.Controls.Add(this.tbpRelaciones);
			this.tbpAtributos.Controls.Add(this.Opciones);
			this.tbpAtributos.Location = new System.Drawing.Point(139, 27);
			this.tbpAtributos.Name = "tbpAtributos";
			this.tbpAtributos.SelectedIndex = 0;
			this.tbpAtributos.Size = new System.Drawing.Size(703, 388);
			this.tbpAtributos.TabIndex = 1;
			//
			//tbpAtributo
			//
			this.tbpAtributo.Controls.Add(this.lblTipo);
			this.tbpAtributo.Controls.Add(this.chbNulo);
			this.tbpAtributo.Controls.Add(this.txtTipo);
			this.tbpAtributo.Controls.Add(this.lsbAtributos);
			this.tbpAtributo.Location = new System.Drawing.Point(4, 22);
			this.tbpAtributo.Name = "tbpAtributo";
			this.tbpAtributo.Padding = new System.Windows.Forms.Padding(3);
			this.tbpAtributo.Size = new System.Drawing.Size(695, 362);
			this.tbpAtributo.TabIndex = 0;
			this.tbpAtributo.Text = "Atributos";
			this.tbpAtributo.UseVisualStyleBackColor = true;
			//
			//lblTipo
			//
			this.lblTipo.AutoSize = true;
			this.lblTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.lblTipo.Location = new System.Drawing.Point(75, 212);
			this.lblTipo.Name = "lblTipo";
			this.lblTipo.Size = new System.Drawing.Size(36, 13);
			this.lblTipo.TabIndex = 3;
			this.lblTipo.Text = "Tipo:";
			//
			//chbNulo
			//
			this.chbNulo.AutoSize = true;
			this.chbNulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.chbNulo.Location = new System.Drawing.Point(102, 182);
			this.chbNulo.Name = "chbNulo";
			this.chbNulo.Size = new System.Drawing.Size(59, 17);
			this.chbNulo.TabIndex = 2;
			this.chbNulo.Text = "Nulo?";
			this.chbNulo.UseVisualStyleBackColor = true;
			//
			//txtTipo
			//
			this.txtTipo.Location = new System.Drawing.Point(117, 205);
			this.txtTipo.Name = "txtTipo";
			this.txtTipo.Size = new System.Drawing.Size(100, 20);
			this.txtTipo.TabIndex = 1;
			//
			//lsbAtributos
			//
			this.lsbAtributos.FormattingEnabled = true;
			this.lsbAtributos.Location = new System.Drawing.Point(56, 26);
			this.lsbAtributos.Name = "lsbAtributos";
			this.lsbAtributos.Size = new System.Drawing.Size(215, 134);
			this.lsbAtributos.TabIndex = 0;
			//
			//tbpMetodos
			//
			this.tbpMetodos.Controls.Add(this.CheckBox4);
			this.tbpMetodos.Controls.Add(this.CheckBox3);
			this.tbpMetodos.Controls.Add(this.CheckBox2);
			this.tbpMetodos.Controls.Add(this.CheckBox1);
			this.tbpMetodos.Controls.Add(this.chbCrear);
			this.tbpMetodos.Location = new System.Drawing.Point(4, 22);
			this.tbpMetodos.Name = "tbpMetodos";
			this.tbpMetodos.Padding = new System.Windows.Forms.Padding(3);
			this.tbpMetodos.Size = new System.Drawing.Size(695, 362);
			this.tbpMetodos.TabIndex = 1;
			this.tbpMetodos.Text = "Metodos";
			this.tbpMetodos.UseVisualStyleBackColor = true;
			//
			//tbpRelaciones
			//
			this.tbpRelaciones.Controls.Add(this.btnAgrega);
			this.tbpRelaciones.Controls.Add(this.DataGridRelaciones);
			this.tbpRelaciones.Location = new System.Drawing.Point(4, 22);
			this.tbpRelaciones.Name = "tbpRelaciones";
			this.tbpRelaciones.Padding = new System.Windows.Forms.Padding(3);
			this.tbpRelaciones.Size = new System.Drawing.Size(695, 362);
			this.tbpRelaciones.TabIndex = 2;
			this.tbpRelaciones.Text = "Relaciones";
			this.tbpRelaciones.UseVisualStyleBackColor = true;
			//
			//Opciones
			//
			this.Opciones.Location = new System.Drawing.Point(4, 22);
			this.Opciones.Name = "Opciones";
			this.Opciones.Size = new System.Drawing.Size(695, 362);
			this.Opciones.TabIndex = 3;
			this.Opciones.Text = "Opciones";
			this.Opciones.UseVisualStyleBackColor = true;
			//
			//MenuStrip1
			//
			this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.ArchivoToolStripMenuItem });
			this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
			this.MenuStrip1.Name = "MenuStrip1";
			this.MenuStrip1.Size = new System.Drawing.Size(854, 24);
			this.MenuStrip1.TabIndex = 2;
			this.MenuStrip1.Text = "MenuStrip1";
			//
			//ArchivoToolStripMenuItem
			//
			this.ArchivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
				this.CargarProyectoToolStripMenuItem,
				this.GuardarProyectoToolStripMenuItem
			});
			this.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem";
			this.ArchivoToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
			this.ArchivoToolStripMenuItem.Text = "Archivo";
			//
			//CargarProyectoToolStripMenuItem
			//
			this.CargarProyectoToolStripMenuItem.Name = "CargarProyectoToolStripMenuItem";
			this.CargarProyectoToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			this.CargarProyectoToolStripMenuItem.Text = "Cargar Proyecto";
			//
			//GuardarProyectoToolStripMenuItem
			//
			this.GuardarProyectoToolStripMenuItem.Name = "GuardarProyectoToolStripMenuItem";
			this.GuardarProyectoToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			this.GuardarProyectoToolStripMenuItem.Text = "Guardar Proyecto";
			//
			//chbCrear
			//
			this.chbCrear.AutoSize = true;
			this.chbCrear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.chbCrear.Location = new System.Drawing.Point(32, 28);
			this.chbCrear.Name = "chbCrear";
			this.chbCrear.Size = new System.Drawing.Size(56, 17);
			this.chbCrear.TabIndex = 0;
			this.chbCrear.Text = "Crear";
			this.chbCrear.UseVisualStyleBackColor = true;
			//
			//CheckBox1
			//
			this.CheckBox1.AutoSize = true;
			this.CheckBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.CheckBox1.Location = new System.Drawing.Point(31, 45);
			this.CheckBox1.Name = "CheckBox1";
			this.CheckBox1.Size = new System.Drawing.Size(71, 17);
			this.CheckBox1.TabIndex = 1;
			this.CheckBox1.Text = "Guardar";
			this.CheckBox1.UseVisualStyleBackColor = true;
			//
			//CheckBox2
			//
			this.CheckBox2.AutoSize = true;
			this.CheckBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.CheckBox2.Location = new System.Drawing.Point(31, 62);
			this.CheckBox2.Name = "CheckBox2";
			this.CheckBox2.Size = new System.Drawing.Size(60, 17);
			this.CheckBox2.TabIndex = 2;
			this.CheckBox2.Text = "Borrar";
			this.CheckBox2.UseVisualStyleBackColor = true;
			//
			//CheckBox3
			//
			this.CheckBox3.AutoSize = true;
			this.CheckBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.CheckBox3.Location = new System.Drawing.Point(31, 79);
			this.CheckBox3.Name = "CheckBox3";
			this.CheckBox3.Size = new System.Drawing.Size(82, 17);
			this.CheckBox3.TabIndex = 3;
			this.CheckBox3.Text = "Actualizar";
			this.CheckBox3.UseVisualStyleBackColor = true;
			//
			//CheckBox4
			//
			this.CheckBox4.AutoSize = true;
			this.CheckBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, Convert.ToByte(0));
			this.CheckBox4.Location = new System.Drawing.Point(31, 96);
			this.CheckBox4.Name = "CheckBox4";
			this.CheckBox4.Size = new System.Drawing.Size(63, 17);
			this.CheckBox4.TabIndex = 4;
			this.CheckBox4.Text = "Cargar";
			this.CheckBox4.UseVisualStyleBackColor = true;
			//
			//btnAgrega
			//
			this.btnAgrega.Location = new System.Drawing.Point(275, 127);
			this.btnAgrega.Name = "btnAgrega";
			this.btnAgrega.Size = new System.Drawing.Size(75, 23);
			this.btnAgrega.TabIndex = 31;
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
			this.DataGridRelaciones.Location = new System.Drawing.Point(6, 6);
			this.DataGridRelaciones.Name = "DataGridRelaciones";
			this.DataGridRelaciones.Size = new System.Drawing.Size(344, 115);
			this.DataGridRelaciones.TabIndex = 30;
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
			//frmCargaXML
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(854, 453);
			this.Controls.Add(this.tbpAtributos);
			this.Controls.Add(this.lsbClases);
			this.Controls.Add(this.MenuStrip1);
			this.MainMenuStrip = this.MenuStrip1;
			this.Name = "FrmCargaXml";
			this.Text = "frmCargaXML";
			this.tbpAtributos.ResumeLayout(false);
			this.tbpAtributo.ResumeLayout(false);
			this.tbpAtributo.PerformLayout();
			this.tbpMetodos.ResumeLayout(false);
			this.tbpMetodos.PerformLayout();
			this.tbpRelaciones.ResumeLayout(false);
			this.MenuStrip1.ResumeLayout(false);
			this.MenuStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.DataGridRelaciones).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		private System.Windows.Forms.ListBox withEventsField_lsbClases;
		internal System.Windows.Forms.ListBox lsbClases {
			get { return withEventsField_lsbClases; }
			set {
				if (withEventsField_lsbClases != null) {
					withEventsField_lsbClases.SelectedIndexChanged -= ListBox1_SelectedIndexChanged;
				}
				withEventsField_lsbClases = value;
				if (withEventsField_lsbClases != null) {
					withEventsField_lsbClases.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
				}
			}
		}
		internal System.Windows.Forms.TabControl tbpAtributos;
		internal System.Windows.Forms.TabPage tbpAtributo;
		internal System.Windows.Forms.TabPage tbpMetodos;
		internal System.Windows.Forms.TabPage tbpRelaciones;
		internal System.Windows.Forms.TabPage Opciones;
		internal System.Windows.Forms.MenuStrip MenuStrip1;
		internal System.Windows.Forms.ToolStripMenuItem ArchivoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem withEventsField_CargarProyectoToolStripMenuItem;
		internal System.Windows.Forms.ToolStripMenuItem CargarProyectoToolStripMenuItem {
			get { return withEventsField_CargarProyectoToolStripMenuItem; }
			set {
				if (withEventsField_CargarProyectoToolStripMenuItem != null) {
					withEventsField_CargarProyectoToolStripMenuItem.Click -= CargarProyectoToolStripMenuItem_Click;
				}
				withEventsField_CargarProyectoToolStripMenuItem = value;
				if (withEventsField_CargarProyectoToolStripMenuItem != null) {
					withEventsField_CargarProyectoToolStripMenuItem.Click += CargarProyectoToolStripMenuItem_Click;
				}
			}
		}
		internal System.Windows.Forms.ToolStripMenuItem GuardarProyectoToolStripMenuItem;
		private System.Windows.Forms.ListBox withEventsField_lsbAtributos;
		internal System.Windows.Forms.ListBox lsbAtributos {
			get { return withEventsField_lsbAtributos; }
			set {
				if (withEventsField_lsbAtributos != null) {
					withEventsField_lsbAtributos.SelectedIndexChanged -= lsbAtributos_SelectedIndexChanged;
				}
				withEventsField_lsbAtributos = value;
				if (withEventsField_lsbAtributos != null) {
					withEventsField_lsbAtributos.SelectedIndexChanged += lsbAtributos_SelectedIndexChanged;
				}
			}
		}
		internal System.Windows.Forms.Label lblTipo;
		internal System.Windows.Forms.CheckBox chbNulo;
		internal System.Windows.Forms.TextBox txtTipo;
		internal System.Windows.Forms.CheckBox chbCrear;
		internal System.Windows.Forms.CheckBox CheckBox4;
		internal System.Windows.Forms.CheckBox CheckBox3;
		internal System.Windows.Forms.CheckBox CheckBox2;
		internal System.Windows.Forms.CheckBox CheckBox1;
		internal System.Windows.Forms.Button btnAgrega;
		internal System.Windows.Forms.DataGridView DataGridRelaciones;
		internal System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
		internal System.Windows.Forms.DataGridViewComboBoxColumn Tipo;
		internal System.Windows.Forms.DataGridViewComboBoxColumn Atomicidad;
	}
}
