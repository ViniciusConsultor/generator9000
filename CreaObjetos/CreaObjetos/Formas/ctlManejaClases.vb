Public Class ctlManejaClases
    Public manejaClases As New List(Of ManejaClase)
    Public DataGridRelaciones As DataGridView
    Public nombresTabla As New List(Of String)

    Public Sub agregaClases(ByVal clace As Clase)
        Dim n As Integer = Me.manejaClases.Count
        Dim clb As New ManejaClase
        Dim x, y As Double

        clb.Clase = clace
        Me.nombresTabla.Add(clace.NombreTabla)


        x = (n Mod 5) * 120

        y = Math.Floor(n / 5) * 120


        clb.Location = New System.Drawing.Point(x, y)
        clb.Name = "clb" & clace.NombreTabla
        clb.BackColor = Color.LightGreen
        clb.Size = New System.Drawing.Size(100, 95)
        clb.Tag = clace.NombreTabla & " " & n
        clb.TabIndex = 26 + n

        Me.manejaClases.Add(clb)
        Me.pnlClases.Controls.Add(clb)
        AddHandler manejaClases(n).DoubleClick, AddressOf borraManejador
        AddHandler manejaClases(n).Click, AddressOf seleccionaManejador
    End Sub

    Private Sub borraManejador(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.pnlClases.Controls.Remove(sender)
        Me.manejaClases.Remove(sender)
    End Sub

    Private Sub seleccionaManejador(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim index As Integer = Me.manejaClases.IndexOf(sender)
        Dim indRel As Integer
        Dim rela As List(Of Relacion) = Me.manejaClases(index).Clase.Relaciones
        Me.DataGridRelaciones.Rows.Clear()
        For indRel = 0 To rela.Count - 1
            Dim indTablas As Integer
            indTablas = Me.nombresTabla.IndexOf(rela(indRel).Tabla)
            ' Me.DataGridRelaciones.Columns(2)
            Me.DataGridRelaciones.Rows.Add()
            Me.DataGridRelaciones.Item(0, indRel).Value = rela(indRel).campo
            Me.AgregaCombo(indTablas, indRel)
            Me.comboCargaAtomicidad(0, indRel)


        Next
        '        
        'Dim maneja As ManejaClase = Me.manejaClases(Me.manejaClases.FindIndex(sender))
        '       sender.BorderStyle = BorderStyle.FixedSingle

    End Sub

    Private Sub comboCargaAtomicidad(ByVal Valor As Integer, ByVal Indice As Integer)
        Dim DTTablas As New DataTable
        DTTablas.Columns.Add("opcion_id", System.Type.GetType("System.Int32"))
        DTTablas.Columns.Add("nombre", System.Type.GetType("System.String"))

        Dim combo As New DataGridViewComboBoxCell
        DTTablas.Rows.Add(0, "1..N")
        DTTablas.Rows.Add(1, "M..N")

        combo.DataSource = DTTablas
        combo.ValueMember = "opcion_id"
        combo.DisplayMember = "nombre"
        combo.Value = Valor

        ' combo.Value = Me.nombresTabla(Valor)
        Me.DataGridRelaciones.Item(2, Indice) = combo


    End Sub

    Private Sub AgregaCombo(ByVal Valor As Integer, ByVal Indice As Integer)
        Dim DTTablas As New DataTable
        DTTablas.Columns.Add("tabla_id", System.Type.GetType("System.Int32"))
        DTTablas.Columns.Add("nombre", System.Type.GetType("System.String"))

        Dim combo As New DataGridViewComboBoxCell
        Dim i As Integer
        combo = New DataGridViewComboBoxCell

        For i = 0 To Me.nombresTabla.Count - 1
            DTTablas.Rows.Add(i, Me.nombresTabla(i))
            'combo.Items.Add(Me.nombresTabla(i))

        Next

        combo.DataSource = DTTablas
        combo.ValueMember = "tabla_id"
        combo.DisplayMember = "nombre"
        combo.Value = Valor

        ' combo.Value = Me.nombresTabla(Valor)
        Me.DataGridRelaciones.Item(1, Indice) = combo


    End Sub

    Private Sub ctlManejaClases_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.pnlClases.Width = Me.Width
        Me.pnlClases.Height = Me.Height
    End Sub

    Private Sub pnlClases_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlClases.Paint
    End Sub
End Class
