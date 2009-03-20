Imports System.Xml
Public Class frmCargaXML
    Dim claces As New List(Of Clase)
    Private Sub CargarProyectoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargarProyectoToolStripMenuItem.Click
        Dim archivo As String
        Dim ofd As New OpenFileDialog
        Dim m_xmld As XmlDocument
        Dim m_nodelist As XmlNodeList
        Dim m_node As XmlNode
        ofd.ShowDialog()
        archivo = ofd.FileName()

        'Create the XML Reader
        'Try
        m_xmld = New XmlDocument()
        'Disable whitespace so that you don't have to read over whitespaces
        m_xmld.Load(archivo)
        m_nodelist = m_xmld.SelectNodes("/proyecto/clase")

        'Loop through the nodes
        For Each m_node In m_nodelist
            'Get the Gender Attribute Value
            Dim cls As New Clase
            cls.NombreTabla = m_node.Attributes.GetNamedItem("plural").Value
            cls.Neim = m_node.Attributes.GetNamedItem("nombre").Value
            Dim atr_nodeList As XmlNodeList
            Dim atr_node As XmlNode
            atr_nodeList = m_node.SelectNodes("atributo")

            For Each atr_node In atr_nodeList
                Dim propie As New Propiedad
                propie.Nombre = atr_node.InnerText
                propie.Tipo = atr_node.Attributes.GetNamedItem("tipo").Value
                If Not atr_node.Attributes.GetNamedItem("Nulo") Is Nothing Then
                    propie.isNull = True
                Else
                    propie.isNull = False
                End If

                cls.Campos.Add(propie)

            Next
            Me.lsbClases.Items.Add(cls.Neim)
            claces.Add(cls)
        Next
        'Catch errorVariable As Exception
        '    'Error trapping
        '    MessageBox.Show(errorVariable.ToString)
        'End Try




    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lsbClases.SelectedIndexChanged
        If claces.Count > 0 And Me.lsbClases.SelectedIndex > -1 Then
            Me.lsbAtributos.DataSource = claces(Me.lsbClases.SelectedIndex).Campos
            Me.lsbAtributos.ValueMember = "nombre"
            Me.lsbAtributos.DisplayMember = "nombre"
        End If
    End Sub

    Private Sub lsbAtributos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lsbAtributos.SelectedIndexChanged
        If Not Me.lsbAtributos.SelectedItem Is Nothing Then
            Dim prop As Propiedad = CType(Me.lsbAtributos.SelectedItem, Propiedad)
            Me.txtTipo.Text = prop.Tipo
            Me.chbNulo.Checked = prop.isNull
        End If
    End Sub
End Class