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
	public class Propiedad
	{
		private string _nombre;
		private string _tipo;
		private bool _isNull;
		public string Nombre {
			get { return this._nombre; }
			set { this._nombre = value; }
		}

		public string Tipo {
			get { return this._tipo; }
			set { this._tipo = value; }
		}
		public bool isNull {
			get { return this._isNull; }
			set { this._isNull = value; }
		}
		public string titulo {
			get { return this.Nombre.Substring(0, 1).ToUpper() + this.Nombre.Substring(1, this.Nombre.Length - 1); }
		}
		public string abreValida {
			get {
				string[] abreValidas = {
					"",
					"ValNulosInt(",
					"ValNulosInt(",
					"ValidaFecha(Ctype(",
					"Ctype(",
					"ValNulosInt(",
					"",
					"Byte()"
				};
				int ind = this.dameTipo();
				if (ind >= 0) {
					return abreValidas[ind];
				}
				return "";
			}
		}

		public string cierraValida {
			get {
				string[] tiposVB = {
					"string",
					"Integer",
					"Decimal",
					"datetime",
					"boolean",
					"double",
					"string",
					"Byte()"
				};
				string[] cierraValidas = {
					".Text.Length > 0",
					") > 0 ",
					"ValNulosInt(",
					"ValidaFecha(Ctype(",
					"Ctype(",
					"ValNulosInt(",
					"",
					"Byte()"
				};
				int ind = this.dameTipo();
				if (ind >= 0) {
					return cierraValidas[ind];
				}
				return "";
			}
		}
		public string tipoControl {
			get {
				string[] tiposCtl = {
					"txt",
					"txt",
					"txt",
					"dtp",
					"chb",
					"txt",
					"txt",
					"fbw",
					"pcb",
					"txt"
				};
				int ind = this.dameTipo();
				if (ind >= 0) {
					return tiposCtl[ind];
				}
				return "";

			}
		}
		public string nombreControl {
			get {
				string[] tiposCtl = {
					"TextBox",
					"TextBox",
					"TextBox",
					"DateTimePicker",
					"CheckBox",
					"TextBox",
					"TextBox",
					"fbw",
					"PictureBox",
					"TextBox"
				};
				int ind = this.dameTipo();
				if (ind >= 0) {
					return tiposCtl[ind];
				}
				return "";

			}
		}
		public int dameTipo()
		{
			List<string> tiposSql = new List<string>();
			tiposSql.Add("varchar");
			tiposSql.Add("int");
			tiposSql.Add("money");
			tiposSql.Add("datetime");
			tiposSql.Add("bit");
			tiposSql.Add("float");
			tiposSql.Add("nvarchar");
			tiposSql.Add("varbinary");
			tiposSql.Add("image");
			tiposSql.Add("text");
			return tiposSql.IndexOf(this.Tipo);
			return -1;
		}
		public string convertipoVB(string tipo)
		{
			int indTipo = this.dameTipo();
			string[] tiposVB = {
				"string",
				"Integer",
				"Decimal",
				"datetime",
				"boolean",
				"double",
				"string",
				"Byte()",
				"Byte()",
				"String"
			};

			if (indTipo >= 0) {
				return tiposVB[indTipo];
			}
			return "";
		}
		public string tipoVB()
		{

			return convertipoVB(this.Tipo);
		}

	}
}
