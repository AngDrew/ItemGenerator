Imports System.IO
Imports System.Reflection

Public Class mm
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox5.Text = "" Then
            MsgBox("Please fill all form's", MsgBoxStyle.Critical, "ERROR")
            Return
        ElseIf TextBox6.Text = "" Then
            MsgBox("Please fill all form's", MsgBoxStyle.Critical, "ERROR")
            Return
        ElseIf TextBox8.Text = "" Then
            MsgBox("Please fill all form's", MsgBoxStyle.Critical, "ERROR")
            Return
        ElseIf TextBox12.Text = "" Then
            MsgBox("Please fill all form's", MsgBoxStyle.Critical, "ERROR")
            Return
        Else
            Dim dir, name, dirc, ent, mythicmobs, id As String, slot
            Dim type = TextBox8.Text
            Dim amount As String
            Dim data As String
            id = TextBox12.Text.Replace(" ", "")
            'visibility handler
            If CheckBox1.CheckState = CheckState.Unchecked Then
                data = 0
            ElseIf CheckBox1.CheckState = CheckState.Checked Then
                data = TextBox9.Text
                If IsNumeric(data) = False Then
                    MsgBox("item data must in number", MsgBoxStyle.Critical, "Error")
                    Return
                End If
            End If
            If CheckBox2.CheckState = CheckState.Unchecked Then
                amount = 1
            ElseIf CheckBox2.CheckState = CheckState.Checked Then
                amount = TextBox10.Text
                If IsNumeric(amount) = False Then
                    MsgBox("item amount must in number", MsgBoxStyle.Critical, "Error")
                    Return
                End If
            End If
            'directory handler
            ent = vbNewLine
            dirc = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)
            dir = dirc + "\" + "" + TextBox5.Text + ".yml"
            name = "'" + TextBox6.Text + "'"
            If IsNumeric(type) = False Then
                MsgBox("item id must be in numeric", MsgBoxStyle.Critical, "Error")
                Return
            End If
            'line separator goes below'
            Dim counter As Integer
            Dim tempArray() As String
            Dim lore(19) As String
            tempArray = TextBox7.Lines
            For counter = 0 To tempArray.GetUpperBound(0)
                lore(counter) = ent + "  - '" + tempArray(counter) + "'"
            Next
            'mythicmobs goes here'
            mythicmobs = ent + id + ":
  Id: " + type + "
  Data: " + data + "
  Display: " + name + "
  Amount: " + amount
            'code writer goes below'
            Dim fileLoc As String = dir
            Dim fs As FileStream = Nothing
            If (Not File.Exists(fileLoc)) Then
                fs = File.Create(fileLoc)
                Using fs
                End Using
            End If
            Dim lores
            If lore(0) IsNot "" Then
                lores = ent + "  Lore: " + lore(0) + lore(1) + lore(2) + lore(3) + lore(4) + lore(5) + lore(6) + lore(7) + lore(8) + lore(9) + lore(10) + lore(11) + lore(12) + lore(13) + lore(14) + lore(15) + lore(16) + lore(17) + lore(18) + lore(19) + ent
            ElseIf lore(0) Is "" Then
                lores = ""
            End If
            If File.Exists(fileLoc) Then
                Using sw As StreamWriter = File.AppendText(fileLoc)
                    sw.Write(mythicmobs)
                    sw.Write(TextBox1.Text)
                    sw.Write(TextBox2.Text)
                    sw.Write(TextBox4.Text)
                    If lores IsNot "" Then
                        sw.Write(lores)
                    End If
                End Using
            End If
            MsgBox("successfully generated the mythicmobs item file!", MsgBoxStyle.OkOnly, "Done!")
            Form1.TextBox11.Visible = True
            Form1.Label6.Visible = True
            Form1.TextBox11.Text = dir
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Enchant.Show()
        Dim ench
        ench = Enchant.TextBox14.Text
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Attributes.Show()
    End Sub

    Private Sub CheckBox1_CheckStateChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckStateChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            TextBox9.Visible = True
        Else
            TextBox9.Visible = False
        End If
    End Sub

    Private Sub CheckBox2_CheckStateChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckStateChanged
        If CheckBox2.CheckState = CheckState.Checked Then
            TextBox10.Visible = True
        Else
            TextBox10.Visible = False
        End If
    End Sub

    Private Sub mm_Load(sender As Object, e As EventArgs) Handles Me.Load
        AcceptButton = Button1
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        TextBox1.Clear()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Close()
    End Sub
End Class