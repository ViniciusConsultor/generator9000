Public Class generaCodPagina
    Public neimespeis As String
    Public clace As Clase

    Public Function generaForma() As String
        Dim code As New String("")
        'code &= "Imports Sist" & neimespeis & "." & neimespeis & vbCrLf
        'code &= "Imports Sist" & neimespeis & neimespeis & "Views" & vbCrLf
        code &= " Partial Class " & Me.clace.NombreTabla & "View" & vbCrLf
        code &= "Inherits System.Web.UI.Page" & vbCrLf
        'code &= "Public " & Me.clace.nombre.Substring(0, 3) & "Ctl as new " & Me.clace.NombreTabla & "ctl" & vbCrLf
        ' code &= Me.generaLoad() & vbCrLf
        code &= "End Class" & vbCrLf
        Return code

    End Function

Public Function generaLoad() As String
    Dim code As New String("")
    code &= "Private Sub Frm" & Me.clace.NombreTabla
    code &= "_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) "
    code &= " Handles MyBase.Load" & vbCrLf
    code &= "Me.mnj" & Me.clace.nombre.Substring(0, 3) & ".ctlBusq = Me.CtlbuscaReg" & vbCrLf
    code &= "Me.mnj" & Me.clace.nombre.Substring(0, 3) & ".ctlMaestro = Me.CtlABCMaestro" & vbCrLf
    code &= "Me.CtlbuscaReg = Me.mnj" & Me.clace.nombre.Substring(0, 3) & ".ctlBusq" & vbCrLf
    code &= "Me.mnj" & Me.clace.nombre.Substring(0, 3) & ".cargaControles(Me.pnlDatos.Controls)" & vbCrLf
    code &= "Me.CtlbuscaReg.mnjObj = Me.mnj" & Me.clace.nombre.Substring(0, 3) & vbCrLf
    code &= "mnj" & Me.clace.nombre.Substring(0, 3) & ".iniciar()" & vbCrLf
    code &= "End Sub " & vbCrLf



    Return code

End Function






End Class
