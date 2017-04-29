Imports System.IO

Public Class Phatloot
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Please fill all form's", MsgBoxStyle.Critical, "ERROR")
            Return
        ElseIf TextBox2.Text = "" Then
            MsgBox("Please fill all form's", MsgBoxStyle.Critical, "ERROR")
            Return
        ElseIf TextBox3.Text = "" Then
            MsgBox("Please fill all form's", MsgBoxStyle.Critical, "ERROR")
            Return
        ElseIf TextBox4.Text = "" Then
            MsgBox("Please fill all form's", MsgBoxStyle.Critical, "ERROR")
            Return
        Else
            Dim dir, name, dirc, ent, phatloot, type
            ent = vbNewLine
            dirc = Path.GetDirectoryName(Reflection.Assembly.GetEntryAssembly().Location)
            dir = dirc + "\" + "" + TextBox1.Text + ".yml"
            name = TextBox2.Text
            type = TextBox4.Text.Replace(" ", "_")
            If IsNumeric(TextBox4.Text) = True Then
                MsgBox("item type must in alphabet", MsgBoxStyle.Critical, "Error")
                Return
            End If
            'line separator goes below'
            Dim counter As Integer
            Dim tempArray() As String
            Dim lore(19) As String
            tempArray = TextBox3.Lines
            For counter = 0 To tempArray.GetUpperBound(0)
                lore(counter) = ent + "          - '" + tempArray(counter) + "'"
            Next
            'line separator ended here'

            'phatloot goes here'
            phatloot = ent + "#please makesure that you copy the generated item ingame!" + ent + TextBox1.Text + ":
  ==: PhatLoot
  AutoLoot: false
  BreakAndRespawn: false
  Global: false
  LootList:
  - ==: LootCollection
    LootList:
    - ==: Item
      ItemStack:
        ==: org.bukkit.inventory.ItemStack
        type:" + type + "
        meta:
          ==: ItemMeta
          meta-type: UNSPECIFIC
          display-name:" + name + "
          lore:" + lore(0) + lore(1) + lore(2) + lore(3) + lore(4) + lore(5) + lore(6) + lore(7) + lore(8) + lore(9) + lore(10) + lore(11) + lore(12) + lore(13) + lore(14) + lore(15) + lore(16) + lore(17) + lore(18) + lore(19) + "
      Probability: 100.0
    LowerNumberOfLoots: 1
    Name: '1'
    Probability: 100.0
    UpperNumberOfLoots: 1
  Name: " + TextBox1.Text + "
  Reset:
    Hours: 0
    Days: 0
    Seconds: 0
    Minutes: 0
  RoundDownTime: false
"
            phatloot = phatloot.Replace("&", "§")

            'phatloot done'

            'code writer goes below'
            Dim fileLoc As String = dir
            Dim fs As FileStream = Nothing
            If (Not File.Exists(fileLoc)) Then
                fs = File.Create(fileLoc)
                Using fs
                End Using
            End If

            If File.Exists(fileLoc) Then
                Using sw As StreamWriter = File.AppendText(fileLoc)
                    sw.Write(phatloot)
                End Using
            End If
            MsgBox("successfully generated the phatloot item file!", MsgBoxStyle.OkOnly, "Done!")
            Form1.TextBox11.Visible = True
            Form1.Label6.Visible = True
            Form1.TextBox11.Text = dirc
        End If
    End Sub

    Private Sub Phatloot_Load(sender As Object, e As EventArgs) Handles Me.Load
        AcceptButton = Button1
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()
    End Sub
End Class