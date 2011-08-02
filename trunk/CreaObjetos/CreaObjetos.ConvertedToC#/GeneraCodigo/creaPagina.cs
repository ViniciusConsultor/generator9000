using Microsoft.VisualBasic;

namespace WindowsApplication1
{
  public class creaPagina
  {
    public Clase clace;
    public string neimespeis;
    private int tabIndex;

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string GeneraPagina()
    {
      string codigo = string.Empty;
      codigo += AbrePagina();
      codigo += generaEncabezado();
      codigo += generaCampos();
      codigo += GeneraPie();
      codigo += " </body>" + Constants.vbCrLf;
      codigo += "</html> " + Constants.vbCrLf;

      return codigo;
    }

    public string AbrePagina()
    {
      string codigo = string.Empty;
      codigo += "<%@ Page Language=\"VB\" AutoEventWireup=\"false\" CodeFile=\"" + clace.nombre() +
                "View.aspx.vb\" Inherits=\"" + clace.nombre() + "View\" %>" + Constants.vbCrLf;

      //codigo &= "<%@ Register Assembly=""System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"""
      //codigo &= "Namespace=""System.Web.UI"" TagPrefix=""asp"" %>" & vbCrLf

      codigo +=
        "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">" +
        Constants.vbCrLf;

      codigo += "<html xmlns=\"http://www.w3.org/1999/xhtml\" >" + Constants.vbCrLf;
      codigo += "<head runat=\"server\">" + Constants.vbCrLf;
      codigo += "<title> Control de " + clace.nombre() + "</title>" + Constants.vbCrLf;
      codigo += "</head>" + Constants.vbCrLf;
      codigo += "<body>" + Constants.vbCrLf;
      return codigo;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string generaEncabezado()
    {
      string codigo = string.Empty;
      codigo += " <form id='frm" + clace.nombre() + "' runat='server'>" + Constants.vbCrLf;
      codigo += "\t<table border='1'> " + Constants.vbCrLf;
      codigo += "     \t<tr> " + Constants.vbCrLf;
      codigo += "             <td colspan='2' style='height: 100%'> " + Constants.vbCrLf;
      codigo += "             </td>" + Constants.vbCrLf;
      codigo += "         </tr> " + Constants.vbCrLf;
      return codigo;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string generaCampos()
    {
      string codigo = string.Empty;
      foreach (Propiedad prop in clace.Campos)
      {
        codigo += GeneraCampo(prop);
      }
      return codigo;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="prop"></param>
    /// <returns></returns>
    public string GeneraCampo(Propiedad prop)
    {
      string codigo = string.Empty;
      codigo += "<tr>" + Constants.vbCrLf;
      codigo += "\t<td> " + prop.Nombre + "</td>" + Constants.vbCrLf;
      codigo += "\t<td > " + Constants.vbCrLf;
      codigo += "\t\t<asp:" + prop.nombreControl + " ID=\"" + prop.tipoControl + prop.Nombre +
                "\" runat=\"server\"></asp:" + prop.nombreControl + " > ";
      codigo += "\t</td>";
      codigo += "</tr>";
      return codigo;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string GeneraPie()
    {
      string codigo = string.Empty;

      codigo += "     \t<tr> " + Constants.vbCrLf;
      codigo += "             <td colspan='2' style='height: 100%'> " + Constants.vbCrLf;
      codigo += "             \t\t<asp:Button ID=\"btnGuarda" + clace.nombre() +
                "\" runat=\"server\" Text=\"Guardar\" />";
      codigo += "             \t\t<asp:Button ID=\"btnEdita" + clace.nombre() + "\" runat=\"server\" Text=\"Editar\" />";
      codigo += "             </td> " + Constants.vbCrLf;
      codigo += "     \t</tr> " + Constants.vbCrLf;
      codigo += "             </table>" + Constants.vbCrLf;
      codigo += "         </form> " + Constants.vbCrLf;
      return codigo;
    }
  }
}