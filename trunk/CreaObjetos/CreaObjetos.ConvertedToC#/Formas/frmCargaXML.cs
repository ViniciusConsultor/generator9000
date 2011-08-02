using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml;
namespace WindowsApplication1
{
	/// <summary>
	/// 
	/// </summary>
	public partial class FrmCargaXml
	{
		List<Clase> claces = new List<Clase>();
		private void CargarProyectoToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
		{
			string archivo = null;
			OpenFileDialog ofd = new OpenFileDialog();
			XmlDocument m_xmld = null;
			XmlNodeList m_nodelist = null;
			XmlNode m_node = null;
			ofd.ShowDialog();
			archivo = ofd.FileName;

			//Create the XML Reader
			//Try
			m_xmld = new XmlDocument();
			//Disable whitespace so that you don't have to read over whitespaces
			m_xmld.Load(archivo);
			m_nodelist = m_xmld.SelectNodes("/proyecto/clase");

			//Loop through the nodes
			foreach (XmlNode m_node_loopVariable in m_nodelist) {
				m_node = m_node_loopVariable;
				//Get the Gender Attribute Value
				Clase cls = new Clase();
				cls.NombreTabla = m_node.Attributes.GetNamedItem("plural").Value;
				cls.Neim = m_node.Attributes.GetNamedItem("nombre").Value;
				XmlNodeList atr_nodeList = null;
				XmlNode atr_node = null;
				atr_nodeList = m_node.SelectNodes("atributo");

				foreach (XmlNode atr_node_loopVariable in atr_nodeList) {
					atr_node = atr_node_loopVariable;
					Propiedad propie = new Propiedad();
					propie.Nombre = atr_node.InnerText;
					propie.Tipo = atr_node.Attributes.GetNamedItem("tipo").Value;
					if ((atr_node.Attributes.GetNamedItem("Nulo") != null)) {
						propie.isNull = true;
					} else {
						propie.isNull = false;
					}

					cls.Campos.Add(propie);

				}
				this.lsbClases.Items.Add(cls.Neim);
				claces.Add(cls);
			}
			//Catch errorVariable As Exception
			//    'Error trapping
			//    MessageBox.Show(errorVariable.ToString)
			//End Try




		}

		private void ListBox1_SelectedIndexChanged(System.Object sender, System.EventArgs e)
		{
			if (claces.Count > 0 & this.lsbClases.SelectedIndex > -1) {
				this.lsbAtributos.DataSource = claces[this.lsbClases.SelectedIndex].Campos;
				this.lsbAtributos.ValueMember = "nombre";
				this.lsbAtributos.DisplayMember = "nombre";
			}
		}

		private void lsbAtributos_SelectedIndexChanged(System.Object sender, System.EventArgs e)
		{
			if ((this.lsbAtributos.SelectedItem != null)) {
				Propiedad prop = (Propiedad)this.lsbAtributos.SelectedItem;
				this.txtTipo.Text = prop.Tipo;
				this.chbNulo.Checked = prop.isNull;
			}
		}
		public FrmCargaXml()
		{
			InitializeComponent();
		}
	}
}
