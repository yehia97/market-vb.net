Imports System.Data.SqlClient
Public Class Form1
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim connectionString As String = "Data Source=DESKTOP-KKEHK70;Initial Catalog=db_market;Integrated Security=True"
        Dim query As String = "INSERT INTO items (Name, Price, Quantity, TotalPrice, Tax, FinalPrice) VALUES (@Name, @Price, @Quantity, @TotalPrice, @Tax, @FinalPrice)"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@name", ComboBox1.Text)
                command.Parameters.AddWithValue("@price", Val(TextBox2.Text))
                command.Parameters.AddWithValue("@quantity", Val(TextBox1.Text))
                command.Parameters.AddWithValue("@totalPrice", Val(TextBox5.Text))
                command.Parameters.AddWithValue("@tax", Val(TextBox3.Text))
                command.Parameters.AddWithValue("@finalPrice", Val(TextBox4.Text))

                connection.Open()
                command.ExecuteNonQuery()
                connection.Close()
            End Using
        End Using

        MessageBox.Show("تمت الإضافة بنجاح")
    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label2.Text = DateAndTime.Now
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Select()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text = "ماوس" Then
            TextBox1.Text = 30
        ElseIf ComboBox1.Text = "احبار" Then
            TextBox1.Text = 50
        ElseIf ComboBox1.Text = "لوحه مفاتيح" Then
            TextBox1.Text = 20
        ElseIf ComboBox1.Text = "طابعه" Then
            TextBox1.Text = 35
        ElseIf ComboBox1.Text = "شاشه" Then
            TextBox1.Text = 60
        Else
            MessageBox.Show("تأكد من الصنف")
            ComboBox1.Text = ""
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub ComboBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.Focus()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim iexit As DialogResult
        Try
            iexit = MessageBox.Show("هل انت متأكد من الخروج من البرنامج", "رسالة تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If iexit = DialogResult.Yes Then
                Application.Exit()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private ReadOnly Property MsgBox(v1 As String, v2 As String, yesNo As MessageBoxButtons, question As MessageBoxIcon) As DialogResult
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        TextBox5.Text = TextBox1.Text * TextBox2.Text
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Val(TextBox2.Text) >= 50 Then
            TextBox3.Text = TextBox5.Text * 0.1
        Else
            TextBox3.Text = TextBox5.Text * 0.05
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        TextBox4.Text = Val(TextBox3.Text) + Val(TextBox5.Text)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
    End Sub
End Class
