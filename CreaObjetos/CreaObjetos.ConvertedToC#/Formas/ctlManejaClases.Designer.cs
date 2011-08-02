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
	partial class ctlManejaClases : System.Windows.Forms.UserControl
	{

		//UserControl overrides dispose to clean up the component list.
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
			this.pnlClases = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			//
			//pnlClases
			//
			this.pnlClases.AutoScroll = true;
			this.pnlClases.BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(Convert.ToByte(192)), Convert.ToInt32(Convert.ToByte(255)), Convert.ToInt32(Convert.ToByte(255)));
			this.pnlClases.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlClases.Location = new System.Drawing.Point(0, 4);
			this.pnlClases.Name = "pnlClases";
			this.pnlClases.Size = new System.Drawing.Size(256, 159);
			this.pnlClases.TabIndex = 0;
			//
			//ctlManejaClases
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.pnlClases);
			this.Name = "ctlManejaClases";
			this.Size = new System.Drawing.Size(256, 163);
			this.ResumeLayout(false);

		}
		private System.Windows.Forms.Panel withEventsField_pnlClases;
		internal System.Windows.Forms.Panel pnlClases {
			get { return withEventsField_pnlClases; }
			set {
				if (withEventsField_pnlClases != null) {
					withEventsField_pnlClases.Paint -= pnlClases_Paint;
				}
				withEventsField_pnlClases = value;
				if (withEventsField_pnlClases != null) {
					withEventsField_pnlClases.Paint += pnlClases_Paint;
				}
			}

		}
	}
}
