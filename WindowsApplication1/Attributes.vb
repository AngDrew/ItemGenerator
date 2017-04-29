Public Class Attributes
    Private Sub Attributes_Load(sender As Object, e As EventArgs) Handles Me.Load
        TextBox1.Text = vbNewLine + "  Attributes: "
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        mm.TextBox1.Text = TextBox1.Text
        Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ComboBox1.SelectedItem = Nothing Then
            MsgBox("please add slot options!")
            Return
        ElseIf ListBox1.SelectedItem = Nothing Then
            MsgBox("please choose at least 1 attribute!")
            Return
        End If
        'TextBox1.Text = "  Attribute: " + vbNewLine + "    "
        TextBox1.AppendText(vbNewLine + "    " + ComboBox1.SelectedItem + ": ")
        For Each item In ListBox1.SelectedItems
            TextBox1.AppendText(vbNewLine + "      " + item.ToString)
        Next
        ComboBox1.Items.RemoveAt(ComboBox1.SelectedIndex)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        mm.TextBox4.Text = vbNewLine + "  Options: "
        If CheckBox1.CheckState = CheckState.Checked Then
            mm.TextBox4.AppendText(vbNewLine + "    RepairCost: " + TextBox2.Text)
        End If
        If CheckBox2.CheckState = CheckState.Checked Then
            mm.TextBox4.AppendText(vbNewLine + "    Unbreakable: " + "True")
        End If
    End Sub

    Private Sub CheckBox1_CheckStateChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckStateChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            TextBox2.Visible = True
        Else
            TextBox2.Visible = False
        End If
    End Sub
End Class