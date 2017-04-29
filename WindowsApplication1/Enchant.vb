Public Class Enchant
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox13.Clear()
        For Each Item As Object In ListBox1.SelectedItems
            TextBox13.AppendText(vbNewLine + Item.ToString)
        Next
        If TextBox13.Lines.Count > TextBox14.Lines.Count Then
            Dim newList As List(Of String) = TextBox13.Lines.ToList
            ' Remove the first line.  
            newList.RemoveAt(0)
            TextBox13.Lines = newList.ToArray
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ent = vbNewLine
        Dim tempArray() As String
        Dim ampli() As String
        Dim Enchantment(22) As String
        tempArray = TextBox13.Lines
        ampli = TextBox14.Lines
        For counter = 0 To ampli.GetUpperBound(0)
            Enchantment(counter) = ent + "  - " + tempArray(counter) + ":" + ampli(counter)
        Next
        mm.TextBox2.Text = ent + "  Enchantments: " + Enchantment(0) + Enchantment(1) + Enchantment(2) + Enchantment(3) + Enchantment(4) + Enchantment(5) + Enchantment(6) + Enchantment(7) + Enchantment(8) + Enchantment(9) + Enchantment(10) + Enchantment(11) + Enchantment(12) + Enchantment(13) + Enchantment(14) + Enchantment(15) + Enchantment(16) + Enchantment(17) + Enchantment(18) + Enchantment(19) + Enchantment(20) + Enchantment(21) + Enchantment(22)
        Hide()

    End Sub

    Private Sub Enchant_Load(sender As Object, e As EventArgs) Handles Me.Load
        AcceptButton = Button2
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Close()
    End Sub
End Class