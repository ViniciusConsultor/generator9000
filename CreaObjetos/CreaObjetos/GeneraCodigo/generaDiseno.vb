Public Class generaDiseno
    Public neimespeis As String
    Public clace As Clase
    Dim tabIndex As Integer
    Public Function generaDiseno() As String
        Dim codigo As String
        codigo = " <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _" & vbCrLf
        codigo &= " Partial Class frm" & clace.NombreTabla & vbCrLf
        codigo &= "    Inherits System.Windows.Forms.Form " & vbCrLf


        codigo &= Me.creaDispose()
        codigo &= Me.creaInitializeComponent()
        codigo &= Me.creaFriends()
        codigo &= "End Class" & vbCrLf

        Return codigo
    End Function

    Public Function creaDispose()
        Dim code As New String("")
        code &= "'Form overrides dispose to clean up the component list." & vbCrLf
        code &= "<System.Diagnostics.DebuggerNonUserCode()> _" & vbCrLf
        code &= "Protected Overrides Sub Dispose(ByVal disposing As Boolean)" & vbCrLf
        code &= "Try" & vbCrLf
        code &= "If disposing AndAlso components IsNot Nothing Then" & vbCrLf
        code &= " components.Dispose()" & vbCrLf
        code &= "End If" & vbCrLf
        code &= "Finally" & vbCrLf
        code &= " MyBase.Dispose(disposing)" & vbCrLf
        code &= "End Try" & vbCrLf
        code &= "End Sub" & vbCrLf

        Return code

    End Function

    Public Function creaInitializeComponent()
        Dim code As New String("")
        code &= "   'Required by the Windows Form Designer" & vbCrLf
        code &= "   Private components As System.ComponentModel.IContainer" & vbCrLf

        code &= "   'NOTE: The following procedure is required by the Windows Form Designer" & vbCrLf
        code &= "   'It can be modified using the Windows Form Designer.  " & vbCrLf
        code &= "   'Do not modify it using the code editor." & vbCrLf
        code &= "   <System.Diagnostics.DebuggerStepThrough()> _" & vbCrLf
        code &= "   Private Sub InitializeComponent()" & vbCrLf
        code &= "       Me.pnlDatos = New System.Windows.Forms.Panel" & vbCrLf
        code &= "       Me.lblFalta = New System.Windows.Forms.Label" & vbCrLf
        code &= "       Me.CtlbuscaReg = New Sist" & Me.neimespeis & ".ctlbuscaReg" & vbCrLf
        code &= "       Me.CtlABCMaestro = New Sist" & Me.neimespeis & ".ctlABCMaestro" & vbCrLf

        For Each atr As Propiedad In Me.clace.Campos

            Dim tipoCtl As String = atr.tipoControl
            Dim nonCtl As String = atr.nombreControl
            code &= "Me.lbl" & atr.Nombre & " =New System.Windows.Forms.Label" & vbCrLf

            If atr.Nombre.Substring(atr.Nombre.Length - 3, 3).Equals("_id") _
                And Not Me.clace.llave.Equals(atr.Nombre) Then
                tipoCtl = "cmb"
                nonCtl = "ComboBox"
            End If


            code &= "Me." & tipoCtl & atr.Nombre & "= New System.Windows.Forms." & nonCtl & vbCrLf
        Next

        code &= "       Me.pnlDatos.SuspendLayout()" & vbCrLf
        code &= "       Me.SuspendLayout()" & vbCrLf
        code &= Me.creaPanelDatos()
        code &= Me.crealblFalta()
        code &= Me.creaBusqueda()
        code &= Me.creaMaestro()
        'Para iniciar los controles

        For Each atr As Propiedad In Me.clace.Campos
            code &= Me.creaControles(atr)
        Next

        code &= Me.creaForma() & vbCrLf
        code &= "End sub" & vbCrLf

        Return code
    End Function


    Public Function creaPanelDatos() As String
        Dim code As New String("")
        code &= "'" & vbCrLf
        code &= "'pnlDatos" & vbCrLf
        code &= "'" & vbCrLf
        code &= "Me.pnlDatos.BackColor = System.Drawing.Color.FromArgb("
        code &= "CType(CType(192, Byte), Integer), "
        code &= "CType(CType(255, Byte), Integer), "
        code &= "CType(CType(255, Byte), Integer))" & vbCrLf
        code &= "Me.pnlDatos.Controls.Add(Me.lblFalta)" & vbCrLf

        For Each atr As Propiedad In Me.clace.Campos
            Dim tipoCtl As String = atr.tipoControl
            
            If atr.Nombre.Substring(atr.Nombre.Length - 3, 3).Equals("_id") _
                And Not Me.clace.llave.Equals(atr.Nombre) Then
                tipoCtl = "cmb"
            End If
            code &= "Me.pnlDatos.Controls.Add(Me.lbl" & atr.Nombre & ")" & vbCrLf
            code &= "Me.pnlDatos.Controls.Add(Me." & tipoCtl & atr.Nombre & ")" & vbCrLf
        Next
        code &= "Me.pnlDatos.Location = New System.Drawing.Point(0, 50)" & vbCrLf
        code &= "Me.pnlDatos.Name = ""pnlDatos""" & vbCrLf
        code &= "Me.pnlDatos.Size = New System.Drawing.Size(300, " & (Me.clace.Campos.Count * 30) + 50 & ")" & vbCrLf
        code &= "Me.pnlDatos.TabIndex = 0" & vbCrLf
        Return code
    End Function

    Public Function crealblFalta() As String
        Dim code As New String("")

        code &= "'lblFalta" & vbCrLf
        code &= "'" & vbCrLf
        code &= "Me.lblFalta.AutoSize = True" & vbCrLf
        code &= "Me.lblFalta.Font = New System.Drawing.Font(""Microsoft Sans Serif"", 9.75!, "
        code &= "System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))" & vbCrLf
        code &= "Me.lblFalta.ForeColor = System.Drawing.Color.Red" & vbCrLf
        code &= "Me.lblFalta.Location = New System.Drawing.Point(100," & (Me.clace.Campos.Count - 1) * 30 & ")" & vbCrLf
        code &= "Me.lblFalta.Name = ""lblFalta"" " & vbCrLf
        code &= "Me.lblFalta.Size = New System.Drawing.Size(0, 16)" & vbCrLf
        code &= "Me.lblFalta.TabIndex = 5" & vbCrLf
        Return code

    End Function
    Public Function creaFriends()
        Dim code As New String("")
        code &= "Friend WithEvents CtlABCMaestro As Sist" & Me.neimespeis & ".ctlABCMaestro" & vbCrLf
        code &= "Friend WithEvents CtlbuscaReg As Sist" & Me.neimespeis & ".ctlbuscaReg" & vbCrLf
        code &= "Friend WithEvents pnlDatos As System.Windows.Forms.Panel" & vbCrLf
        code &= "Friend WithEvents lblFalta As System.Windows.Forms.Label" & vbCrLf
        For Each atr As Propiedad In Me.clace.Campos
            Dim tipoCtl As String = atr.tipoControl
            Dim nonCtl As String = atr.nombreControl
            code &= "Friend WithEvents lbl" & atr.Nombre & " As System.Windows.Forms.Label" & vbCrLf

            If atr.Nombre.Substring(atr.Nombre.Length - 3, 3).Equals("_id") _
                And Not Me.clace.llave.Equals(atr.Nombre) Then
                tipoCtl = "cmb"
                nonCtl = "ComboBox"
            End If
            code &= "Friend WithEvents " & tipoCtl & atr.Nombre & " As System.Windows.Forms." & nonCtl & vbCrLf
        Next

        Return code
    End Function
    Public Function creaControles(ByVal atr As Propiedad) As String
        Dim code As New String("")
        code &= Me.creaEtiqueta(atr)
        code &= Me.creaCapturador(atr)
        Return code
    End Function

    Public Function creaEtiqueta(ByVal atr As Propiedad) As String
        Dim code As New String("")
        code &= "'" & vbCrLf
        code &= "'lbl" & atr.titulo & vbCrLf
        code &= "'" & vbCrLf
        code &= "Me.lbl" & atr.titulo & ".AutoSize = True" & vbCrLf
        code &= "Me.lbl" & atr.titulo & ".Font = "
        code &= "New System.Drawing.Font(""Microsoft Sans Serif"", 9.75!, "
        code &= "System.Drawing.FontStyle.Bold, "
        code &= "System.Drawing.GraphicsUnit.Point, CType(0, Byte))" & vbCrLf
        code &= "Me.lbl" & atr.titulo & ".Location = New System.Drawing.Point(20, " & (25 * Me.tabIndex) + 5 & ")" & vbCrLf
        code &= "Me.lbl" & atr.titulo & ".Name = ""lbl" & atr.titulo & """" & vbCrLf
        code &= "Me.lbl" & atr.titulo & ".Size = New System.Drawing.Size(" & atr.Nombre.Length * 10 & ", 16)" & vbCrLf
        code &= "Me.lbl" & atr.titulo & ".TabIndex = 0" & vbCrLf
        code &= "Me.lbl" & atr.titulo & ".Text = """ & atr.titulo & """" & vbCrLf
        Return code
    End Function
    Public Function creaCapturador(ByVal atr As Propiedad) As String
        Dim code As New String("")
        Dim tipoCtl As String = atr.tipoControl

        If atr.Nombre.Substring(atr.Nombre.Length - 3, 3).Equals("_id") _
            And Not Me.clace.llave.Equals(atr.Nombre) Then
            tipoCtl = "cmb"

        End If
        code &= "'" & vbCrLf
        code &= "'" & tipoCtl & atr.titulo & vbCrLf
        code &= "'" & vbCrLf
        code &= "Me." & tipoCtl & atr.titulo & ".Enabled = False" & vbCrLf
        code &= "Me." & tipoCtl & atr.titulo & ".Location =  New System.Drawing.Point(150, " & (25 * Me.tabIndex) + 5 & ")" & vbCrLf
        code &= "Me." & tipoCtl & atr.titulo & ".Name = """ & tipoCtl & atr.titulo & """" & vbCrLf
        If atr.Nombre.Equals(Me.clace.llave) Then
            code &= "Me." & tipoCtl & atr.titulo & ".ReadOnly = True" & vbCrLf
        End If
        code &= "Me." & tipoCtl & atr.titulo & ".Size = New System.Drawing.Size(100, 20)" & vbCrLf
        code &= "Me." & tipoCtl & atr.titulo & ".TabIndex = " & Me.tabIndex & vbCrLf
        Me.tabIndex += 1
        Return code
    End Function
    Public Function creaForma() As String
        Dim code As New String("")
        code &= "'" & vbCrLf
        code &= "'frm" & Me.clace.NombreTabla & vbCrLf
        code &= "'" & vbCrLf
        code &= "Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)" & vbCrLf
        code &= "Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font" & vbCrLf
        code &= "Me.ClientSize = New System.Drawing.Size(300," & (Me.clace.Campos.Count * 30) + 100 & ")" & vbCrLf
        code &= "Me.Controls.Add(Me.pnlDatos)" & vbCrLf
        code &= "Me.Controls.Add(Me.CtlbuscaReg)" & vbCrLf
        code &= "Me.Controls.Add(Me.CtlABCMaestro)" & vbCrLf
        code &= "Me.Name = ""frm" & Me.clace.NombreTabla & """" & vbCrLf
        code &= "Me.Text = """ & Me.clace.NombreTabla & """" & vbCrLf
        code &= "Me.pnlDatos.ResumeLayout(False)" & vbCrLf
        code &= "Me.pnlDatos.PerformLayout()" & vbCrLf
        code &= "Me.ResumeLayout(False)" & vbCrLf
        Return code
    End Function
    Public Function creaBusqueda() As String
        Dim code As New String("")
        code &= "'" & vbCrLf
        code &= "'CtlbuscaReg" & vbCrLf
        code &= "'" & vbCrLf
        code &= "Me.CtlbuscaReg.Location = New System.Drawing.Point(0, 0)" & vbCrLf
        code &= "Me.CtlbuscaReg.Name = ""CtlbuscaReg""" & vbCrLf
        code &= "Me.CtlbuscaReg.Size = New System.Drawing.Size(516, 25)" & vbCrLf
        code &= "Me.CtlbuscaReg.TabIndex = 1" & vbCrLf
        Return code
    End Function
    Public Function creaMaestro() As String
        Dim code As New String("")
        code &= "'" & vbCrLf
        code &= "'CtlABCMaestro" & vbCrLf
        code &= "'" & vbCrLf
        code &= "Me.CtlABCMaestro.Estado = 0" & vbCrLf
        code &= "Me.CtlABCMaestro.Location = New System.Drawing.Point(0, 27)" & vbCrLf
        code &= "Me.CtlABCMaestro.Name = ""CtlABCMaestro""" & vbCrLf
        code &= "Me.CtlABCMaestro.Size = New System.Drawing.Size(516, 25)" & vbCrLf
        code &= "Me.CtlABCMaestro.TabIndex = 0" & vbCrLf
        Return code
    End Function






End Class
