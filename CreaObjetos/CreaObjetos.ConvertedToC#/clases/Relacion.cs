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
	public class Relacion
	{

		private string _campo;
		private string _Tabla;

		private int _tipo;
		public string Tabla {
			get { return this._Tabla; }
			set { this._Tabla = value; }
		}

		public string campo {
			get { return this._campo; }
			set { this._campo = value; }
		}

		public int tipo {
			get { return this._tipo; }
			set { this._tipo = value; }
		}
	}
}
