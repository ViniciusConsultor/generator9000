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

	public class Clase
	{

		private List<Propiedad> _campos;
		private string _llave;
		private string _nombreTabla;
		private SqlConnection _sqlCon;
		private List<Relacion> _Relaciones;

		private string _neim;
		public List<Propiedad> Campos {
			get { return this._campos; }
			set { this._campos = value; }
		}
		public SqlConnection sqlCon {
			get { return this._sqlCon; }
			set { this._sqlCon = value; }
		}

		public string NombreTabla {
			get { return this._nombreTabla; }
			set { this._nombreTabla = value; }
		}
		public string Neim {
			get { return this._neim; }
			set { this._neim = value; }
		}
		public string llave {
			get { return this._llave; }
			set { this._llave = value; }
		}

		public List<Relacion> Relaciones {
			get { return this._Relaciones; }
			set { this._Relaciones = value; }
		}

		public void cargaAtributos()
		{
			this.Campos = new List<Propiedad>();
			this.sqlCon.Open();
			SqlDataReader sdr = null;
			SqlCommand myCommand = new SqlCommand();

			myCommand.Connection = this.sqlCon;
			//        myCommand.CommandText = "use " & cmbSQLDatabase.Text & " select * from " & ComboBox2.Text
			myCommand.CommandText = " select * from information_schema.Columns" + " WHERE table_name =@table_name" + " ORDER By ORDINAL_POSITION";
			myCommand.Parameters.Add("@table_name", SqlDbType.VarChar);
			myCommand.Parameters["@table_name"].Value = this.NombreTabla;

			sdr = myCommand.ExecuteReader();
			while ((sdr.Read())) {
				Propiedad prop = new Propiedad();
				prop.Nombre = sdr["COLUMN_NAME"].ToString();
        prop.Tipo = sdr["DATA_TYPE"].ToString();
				prop.isNull = sdr["IS_NULLABLE"].Equals("YES");
				this.Campos.Add(prop);
			}
			if (this.Campos.Count > 0) {
				this.llave = "";
				this.llave = Campos[0].Nombre;
			}
			sdr.Close();
			this.sqlCon.Close();

		}

		public void CargaRelaciones()
		{
			this.Relaciones = new List<Relacion>();
			this.sqlCon.Open();
			SqlDataReader sdr = null;
			SqlCommand myCommand = new SqlCommand();

			myCommand.Connection = this.sqlCon;
			//        myCommand.CommandText = "use " & cmbSQLDatabase.Text & " select * from " & ComboBox2.Text
			myCommand.CommandText = "SELECT " + "FK_Table  = FK.TABLE_NAME, " + "FK_Column = CU.COLUMN_NAME, " + "PK_Table  = PK.TABLE_NAME,  " + "PK_Column = PT.COLUMN_NAME,  " + "Constraint_Name = C.CONSTRAINT_NAME  " + " FROM  " + "INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C  " + "INNER JOIN  " + "INFORMATION_SCHEMA.TABLE_CONSTRAINTS FK  " + "ON C.CONSTRAINT_NAME = FK.CONSTRAINT_NAME  " + "INNER JOIN  " + "INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK  " + "ON C.UNIQUE_CONSTRAINT_NAME = PK.CONSTRAINT_NAME  " + "INNER JOIN  " + "INFORMATION_SCHEMA.KEY_COLUMN_USAGE CU  " + "ON C.CONSTRAINT_NAME = CU.CONSTRAINT_NAME  " + "INNER JOIN  " + "( " + "SELECT i1.TABLE_NAME, i2.COLUMN_NAME  " + "FROM  INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1  " + "INNER JOIN  " + "INFORMATION_SCHEMA.KEY_COLUMN_USAGE i2  " + "ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME  " + "WHERE i1.CONSTRAINT_TYPE = 'PRIMARY KEY'  " + ") PT  " + " ON PT.TABLE_NAME = PK.TABLE_NAME " + "WHERE FK.TABLE_NAME=@table_name " + "ORDER BY 1,2,3,4 ";

			myCommand.Parameters.Add("@table_name", SqlDbType.VarChar);
			myCommand.Parameters["@table_name"].Value = this.NombreTabla;

			sdr = myCommand.ExecuteReader();
			while ((sdr.Read())) {
				Relacion rlc = new Relacion();
				rlc.Tabla = sdr["PK_Table"].ToString();
				rlc.campo = sdr["FK_Column"].ToString();
				rlc.tipo = 0;
				this.Relaciones.Add(rlc);

			}
			sdr.Close();
			this.sqlCon.Close();

		}


		public string nombre()
		{
			return this.NombreTabla;
			string temp = this.llave;

			if (temp.Length < 3) {
				return this.NombreTabla;
			} else {
				if (temp.Substring(temp.Length - 3, 3).Equals("_id")) {
					temp = this.llave.Substring(0, temp.Length - 3);

				} else {
					if (Convert.ToChar(temp[temp.Length - 1]) == 's' & !(temp[temp.Length - 2] == 'u' | temp[temp.Length - 2] == 'i')) {
						temp = temp.Substring(0, temp.Length - 1);
					}

					if (temp[temp.Length - 1] == 'e' & !(temp[temp.Length - 2] == 't' | temp[temp.Length - 2] == 'h')) {
						temp = temp.Substring(0, temp.Length - 1);
					}
					if (temp[temp.Length - 1] == 'C') {
						temp = temp.Substring(0, temp.Length - 1) + "z";
					}
				}
				return temp;
			}
		}

		public Clase()
		{
			this.Campos = new List<Propiedad>();
		}
	}
}
