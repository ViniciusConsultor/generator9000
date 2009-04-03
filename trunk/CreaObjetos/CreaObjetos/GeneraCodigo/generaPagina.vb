Public Class generaPagina
    Public neimespeis As String
    Public clace As Clase
    Dim tabIndex As Integer
    Public Function generaPagina() As String
        Dim codigo As String = String.Empty
        codigo &= Me.AbrePagina()
        codigo &= Me.generaEncabezado()
        codigo &= Me.generaCampos()
        codigo &= Me.generaPie()
        codigo &= " </body>" & vbCrLf
        codigo &= "</html> " & vbCrLf

        Return codigo
    End Function
    Public Function AbrePagina() As String
        Dim codigo As String = String.Empty
        codigo &= "<%@ Page Language=""VB"" AutoEventWireup=""false"" CodeFile=""Profesores.aspx.vb"" Inherits=""Profesores"" %>"

        codigo &= "<%@ Register Assembly=""System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"""
        codigo &= "Namespace=""System.Web.UI"" TagPrefix=""asp"" %>"

        codigo &= "<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">"

        codigo &= "<html xmlns=""http://www.w3.org/1999/xhtml"" >"
        codigo &= "<head runat=""server"">"
        codigo &= "<title>Untitled Page</title>"
        codigo &= "</head>"
        codigo &= "<body>"
        Return codigo
    End Function
    Public Function generaEncabezado() As String
        Dim codigo As String = String.Empty
        codigo &= " <form id='frm" & Me.clace.nombre & "' runat='server'>" & vbCrLf
        codigo &= "	<table border='1'> " & vbCrLf
        codigo &= "     	<tr> " & vbCrLf
        codigo &= "             <td colspan='2' style='height: 100%'> " & vbCrLf
        codigo &= "             </td>" & vbCrLf
        codigo &= "         </tr> " & vbCrLf
        Return codigo
    End Function

    Public Function generaCampos() As String
        Dim codigo As String = String.Empty
        For Each prop As Propiedad In Me.clace.Campos
            codigo &= Me.GeneraCampo(prop)
        Next
        Return codigo
    End Function

    Public Function GeneraCampo(ByVal prop As Propiedad) As String
        Dim codigo As String = String.Empty
        codigo &= "<tr>" & vbCrLf
        codigo &= "	<td> " & prop.Nombre & "</td>" & vbCrLf
        codigo &= "	<td style=""width: '233px'""> " & vbCrLf
        codigo &= "		<asp:" & prop.nombreControl & "ID=""" & prop.tipoControl & prop.Nombre & """ runat=""server""></asp:" & prop.nombreControl & " > "
        codigo &= "	</td>"
        codigo &= "</tr>"
        Return codigo
    End Function

    Public Function generaPie() As String
        Dim codigo As String = String.Empty

        codigo &= "     	<tr> " & vbCrLf
        codigo &= "             <td colspan='2' style='height: 100%'> " & vbCrLf
        codigo &= "             		<asp:Button ID=""btnGuarda" & Me.clace.nombre & """ runat=""server"" Text=""Guardar"" />"
        codigo &= "             		<asp:Button ID=""btnEdita" & Me.clace.nombre & """ runat=""server"" Text=""Editar"" />"
        codigo &= "             </td> " & vbCrLf
        codigo &= "     	</tr> " & vbCrLf
        codigo &= "             </table>" & vbCrLf
        codigo &= "         </form> " & vbCrLf
        Return codigo
    End Function




End Class
