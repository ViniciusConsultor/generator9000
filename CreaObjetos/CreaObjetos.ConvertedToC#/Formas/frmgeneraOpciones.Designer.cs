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
	partial class frmgeneraOpciones : System.Windows.Forms.Form
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
			this.Panel1 = new System.Windows.Forms.Panel();
			this.rdbClipboard = new System.Windows.Forms.RadioButton();
			this.rdbVarios = new System.Windows.Forms.RadioButton();
			this.TextBox1 = new System.Windows.Forms.TextBox();
			this.btnGeneraClase = new System.Windows.Forms.Button();
			this.rdbArchivo = new System.Windows.Forms.RadioButton();
			this.rdbTexto = new System.Windows.Forms.RadioButton();
			this.Panel2 = new System.Windows.Forms.Panel();
			this.rdbASP = new System.Windows.Forms.RadioButton();
			this.rdbWapl = new System.Windows.Forms.RadioButton();
			this.chkClases = new System.Windows.Forms.CheckBox();
			this.chkInterfaz = new System.Windows.Forms.CheckBox();
			this.chkClasesASP = new System.Windows.Forms.CheckBox();
			this.chkManejador = new System.Windows.Forms.CheckBox();
			this.chkPagina = new System.Windows.Forms.CheckBox();
			this.chkMngASP = new System.Windows.Forms.CheckBox();
			this.Panel1.SuspendLayout();
			this.Panel2.SuspendLayout();
			this.SuspendLayout();
			//
			//Panel1
			//
			this.Panel1.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(255)), Convert.ToInt32(Convert.ToByte(224)), Convert.ToInt32(Convert.ToByte(192)));
			this.Panel1.Controls.Add(this.Panel2);
			this.Panel1.Controls.Add(this.rdbClipboard);
			this.Panel1.Controls.Add(this.rdbVarios);
			this.Panel1.Controls.Add(this.TextBox1);
			this.Panel1.Controls.Add(this.btnGeneraClase);
			this.Panel1.Controls.Add(this.rdbArchivo);
			this.Panel1.Controls.Add(this.rdbTexto);
			this.Panel1.Location = new System.Drawing.Point(0, 0);
			this.Panel1.Name = "Panel1";
			this.Panel1.Size = new System.Drawing.Size(446, 421);
			this.Panel1.TabIndex = 42;
			//
			//rdbClipboard
			//
			this.rdbClipboard.AutoSize = true;
			this.rdbClipboard.Checked = true;
			this.rdbClipboard.Location = new System.Drawing.Point(14, 12);
			this.rdbClipboard.Name = "rdbClipboard";
			this.rdbClipboard.Size = new System.Drawing.Size(129, 17);
			this.rdbClipboard.TabIndex = 37;
			this.rdbClipboard.TabStop = true;
			this.rdbClipboard.Text = "Copiar a Portapapeles";
			this.rdbClipboard.UseVisualStyleBackColor = true;
			//
			//rdbVarios
			//
			this.rdbVarios.AutoSize = true;
			this.rdbVarios.Location = new System.Drawing.Point(14, 78);
			this.rdbVarios.Name = "rdbVarios";
			this.rdbVarios.Size = new System.Drawing.Size(118, 17);
			this.rdbVarios.TabIndex = 40;
			this.rdbVarios.TabStop = true;
			this.rdbVarios.Text = "Archivos separados";
			this.rdbVarios.UseVisualStyleBackColor = true;
			//
			//TextBox1
			//
			this.TextBox1.Location = new System.Drawing.Point(14, 134);
			this.TextBox1.Multiline = true;
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.Size = new System.Drawing.Size(224, 48);
			this.TextBox1.TabIndex = 34;
			//
			//btnGeneraClase
			//
			this.btnGeneraClase.Location = new System.Drawing.Point(182, 19);
			this.btnGeneraClase.Name = "btnGeneraClase";
			this.btnGeneraClase.Size = new System.Drawing.Size(75, 48);
			this.btnGeneraClase.TabIndex = 35;
			this.btnGeneraClase.Text = "Genera";
			this.btnGeneraClase.UseVisualStyleBackColor = true;
			//
			//rdbArchivo
			//
			this.rdbArchivo.AutoSize = true;
			this.rdbArchivo.Location = new System.Drawing.Point(14, 59);
			this.rdbArchivo.Name = "rdbArchivo";
			this.rdbArchivo.Size = new System.Drawing.Size(92, 17);
			this.rdbArchivo.TabIndex = 39;
			this.rdbArchivo.TabStop = true;
			this.rdbArchivo.Text = "Archivo Unico";
			this.rdbArchivo.UseVisualStyleBackColor = true;
			//
			//rdbTexto
			//
			this.rdbTexto.AutoSize = true;
			this.rdbTexto.Location = new System.Drawing.Point(14, 35);
			this.rdbTexto.Name = "rdbTexto";
			this.rdbTexto.Size = new System.Drawing.Size(106, 17);
			this.rdbTexto.TabIndex = 38;
			this.rdbTexto.TabStop = true;
			this.rdbTexto.Text = "Pegar en textBox";
			this.rdbTexto.UseVisualStyleBackColor = true;
			//
			//Panel2
			//
			this.Panel2.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)), Convert.ToInt32(Convert.ToByte(192)));
			this.Panel2.Controls.Add(this.rdbASP);
			this.Panel2.Controls.Add(this.rdbWapl);
			this.Panel2.Controls.Add(this.chkClases);
			this.Panel2.Controls.Add(this.chkInterfaz);
			this.Panel2.Controls.Add(this.chkClasesASP);
			this.Panel2.Controls.Add(this.chkManejador);
			this.Panel2.Controls.Add(this.chkPagina);
			this.Panel2.Controls.Add(this.chkMngASP);
			this.Panel2.Location = new System.Drawing.Point(14, 242);
			this.Panel2.Name = "Panel2";
			this.Panel2.Size = new System.Drawing.Size(273, 138);
			this.Panel2.TabIndex = 43;
			//
			//rdbASP
			//
			this.rdbASP.AutoSize = true;
			this.rdbASP.Location = new System.Drawing.Point(153, 7);
			this.rdbASP.Name = "rdbASP";
			this.rdbASP.Size = new System.Drawing.Size(101, 17);
			this.rdbASP.TabIndex = 50;
			this.rdbASP.Text = "ASP Application";
			this.rdbASP.UseVisualStyleBackColor = true;
			//
			//rdbWapl
			//
			this.rdbWapl.AutoSize = true;
			this.rdbWapl.Checked = true;
			this.rdbWapl.Location = new System.Drawing.Point(5, 7);
			this.rdbWapl.Name = "rdbWapl";
			this.rdbWapl.Size = new System.Drawing.Size(124, 17);
			this.rdbWapl.TabIndex = 49;
			this.rdbWapl.TabStop = true;
			this.rdbWapl.Text = "Windows Application";
			this.rdbWapl.UseVisualStyleBackColor = true;
			//
			//chkClases
			//
			this.chkClases.AutoSize = true;
			this.chkClases.Checked = true;
			this.chkClases.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkClases.Location = new System.Drawing.Point(3, 49);
			this.chkClases.Name = "chkClases";
			this.chkClases.Size = new System.Drawing.Size(57, 17);
			this.chkClases.TabIndex = 43;
			this.chkClases.Text = "Clases";
			this.chkClases.UseVisualStyleBackColor = true;
			//
			//chkInterfaz
			//
			this.chkInterfaz.AutoSize = true;
			this.chkInterfaz.Checked = true;
			this.chkInterfaz.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkInterfaz.Location = new System.Drawing.Point(3, 95);
			this.chkInterfaz.Name = "chkInterfaz";
			this.chkInterfaz.Size = new System.Drawing.Size(61, 17);
			this.chkInterfaz.TabIndex = 45;
			this.chkInterfaz.Text = "Interfaz";
			this.chkInterfaz.UseVisualStyleBackColor = true;
			//
			//chkClasesASP
			//
			this.chkClasesASP.AutoSize = true;
			this.chkClasesASP.Checked = true;
			this.chkClasesASP.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkClasesASP.Location = new System.Drawing.Point(128, 49);
			this.chkClasesASP.Name = "chkClasesASP";
			this.chkClasesASP.Size = new System.Drawing.Size(57, 17);
			this.chkClasesASP.TabIndex = 46;
			this.chkClasesASP.Text = "Clases";
			this.chkClasesASP.UseVisualStyleBackColor = true;
			//
			//chkManejador
			//
			this.chkManejador.AutoSize = true;
			this.chkManejador.Checked = true;
			this.chkManejador.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkManejador.Location = new System.Drawing.Point(3, 72);
			this.chkManejador.Name = "chkManejador";
			this.chkManejador.Size = new System.Drawing.Size(87, 17);
			this.chkManejador.TabIndex = 44;
			this.chkManejador.Text = "Manejadores";
			this.chkManejador.UseVisualStyleBackColor = true;
			//
			//chkPagina
			//
			this.chkPagina.AutoSize = true;
			this.chkPagina.Checked = true;
			this.chkPagina.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkPagina.Location = new System.Drawing.Point(128, 95);
			this.chkPagina.Name = "chkPagina";
			this.chkPagina.Size = new System.Drawing.Size(56, 17);
			this.chkPagina.TabIndex = 48;
			this.chkPagina.Text = "HTML";
			this.chkPagina.UseVisualStyleBackColor = true;
			//
			//chkMngASP
			//
			this.chkMngASP.AutoSize = true;
			this.chkMngASP.Checked = true;
			this.chkMngASP.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkMngASP.Location = new System.Drawing.Point(128, 72);
			this.chkMngASP.Name = "chkMngASP";
			this.chkMngASP.Size = new System.Drawing.Size(63, 17);
			this.chkMngASP.TabIndex = 47;
			this.chkMngASP.Text = "mnjASP";
			this.chkMngASP.UseVisualStyleBackColor = true;
			//
			//frmgeneraOpciones
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(444, 420);
			this.Controls.Add(this.Panel1);
			this.Name = "frmgeneraOpciones";
			this.Text = "frmgeneraOpciones";
			this.Panel1.ResumeLayout(false);
			this.Panel1.PerformLayout();
			this.Panel2.ResumeLayout(false);
			this.Panel2.PerformLayout();
			this.ResumeLayout(false);

		}
		internal System.Windows.Forms.Panel Panel1;
		internal System.Windows.Forms.RadioButton rdbClipboard;
		internal System.Windows.Forms.RadioButton rdbVarios;
		internal System.Windows.Forms.TextBox TextBox1;
		private System.Windows.Forms.Button withEventsField_btnGeneraClase;
		internal System.Windows.Forms.Button btnGeneraClase {
			get { return withEventsField_btnGeneraClase; }
			set {
				if (withEventsField_btnGeneraClase != null) {
					withEventsField_btnGeneraClase.Click -= btnGeneraClase_Click;
				}
				withEventsField_btnGeneraClase = value;
				if (withEventsField_btnGeneraClase != null) {
					withEventsField_btnGeneraClase.Click += btnGeneraClase_Click;
				}
			}
		}
		internal System.Windows.Forms.RadioButton rdbArchivo;
		internal System.Windows.Forms.RadioButton rdbTexto;
		internal System.Windows.Forms.Panel Panel2;
		internal System.Windows.Forms.RadioButton rdbASP;
		private System.Windows.Forms.RadioButton withEventsField_rdbWapl;
		internal System.Windows.Forms.RadioButton rdbWapl {
			get { return withEventsField_rdbWapl; }
			set {
				if (withEventsField_rdbWapl != null) {
					withEventsField_rdbWapl.CheckedChanged -= rdbWapl_CheckedChanged;
				}
				withEventsField_rdbWapl = value;
				if (withEventsField_rdbWapl != null) {
					withEventsField_rdbWapl.CheckedChanged += rdbWapl_CheckedChanged;
				}
			}
		}
		internal System.Windows.Forms.CheckBox chkClases;
		internal System.Windows.Forms.CheckBox chkInterfaz;
		internal System.Windows.Forms.CheckBox chkClasesASP;
		internal System.Windows.Forms.CheckBox chkManejador;
		internal System.Windows.Forms.CheckBox chkPagina;
		internal System.Windows.Forms.CheckBox chkMngASP;
	}
}
