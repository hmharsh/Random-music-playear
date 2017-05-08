Public Class Form1
    Dim af As Boolean
    Dim derat, cp As Integer
    Dim rnda As New Random
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            af = 0
            Timer1.Start()
            'in portable version these lines below become comments
            Dim di As New IO.DirectoryInfo(TextBox3.Text)
            Dim diar1 As IO.FileInfo() = di.GetFiles("*.mp3")
            Dim dra As IO.FileInfo
            For Each dra In diar1
                ListBox1.Items.Add(dra.ToString())
            Next
            'up to here
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If (OpenFileDialog1.ShowDialog = DialogResult.OK) Then
                AxWindowsMediaPlayer1.URL = OpenFileDialog1.FileName
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Timer1.Start()
            ' Button9.Enabled = True
            ' Button1.Enabled = True
            ' Button3.Enabled = True

            Dim di As New IO.DirectoryInfo(TextBox3.Text)
            Dim diar1 As IO.FileInfo() = di.GetFiles("*.mp3")
            Dim dra As IO.FileInfo
            For Each dra In diar1
                ListBox1.Items.Add(dra.ToString().ToLower())
            Next
            Dim rnd As New Random
            Dim randomIndex As Integer = rnd.Next(0, ListBox1.Items.Count - 1)
            TextBox2.Text = TextBox3.Text + "\" + ListBox1.Items(randomIndex)
            AxWindowsMediaPlayer1.URL = TextBox2.Text
            AxWindowsMediaPlayer1.Ctlcontrols.currentPosition = rnd.Next(1, 30)
            AxWindowsMediaPlayer1.Ctlcontrols.play()
            derat = rnda.Next(cp + TextBox4.Text - 1, cp + TextBox5.Text)
            AxWindowsMediaPlayer1.Ctlcontrols.play()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If (Button3.Text = "Pause") Then
            AxWindowsMediaPlayer1.Ctlcontrols.pause()
            Timer1.Stop()
            Button3.Text = "Play"
        Else
            Button3.Text = "Pause"
            AxWindowsMediaPlayer1.Ctlcontrols.play()
            Timer1.Start()
        End If
        AxWindowsMediaPlayer1.Ctlcontrols.pause()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AxWindowsMediaPlayer1.Ctlcontrols.next()

    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim rnd As New Random
            Dim randomIndex As Integer = rnd.Next(0, ListBox1.Items.Count - 1)

            TextBox2.Text = TextBox3.Text + "\" + ListBox1.Items(randomIndex)
            AxWindowsMediaPlayer1.URL = TextBox2.Text
            AxWindowsMediaPlayer1.Ctlcontrols.currentPosition = rnd.Next(1, 30)
            AxWindowsMediaPlayer1.Ctlcontrols.play()
            cp = AxWindowsMediaPlayer1.Ctlcontrols.currentPosition
            derat = rnda.Next(cp + TextBox4.Text, cp + TextBox5.Text)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Try
            FolderBrowserDialog1.ShowDialog()
            TextBox3.Text = FolderBrowserDialog1.SelectedPath()
            ListBox1.Items.Clear()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '  Me.Text = AxWindowsMediaPlayer1.Ctlcontrols.currentPosition
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ' Me.Text = Me.Text + "+1+"
        Try
            cp = AxWindowsMediaPlayer1.Ctlcontrols.currentPosition
            Me.Text = "Seconds:" + cp.ToString() + "_+Change At:" + derat.ToString() + TextBox2.Text
            If (cp = 0) Then
                Dim rnd As New Random
                Dim randomIndex As Integer = rnd.Next(0, ListBox1.Items.Count - 1)
                TextBox6.Text = TextBox2.Text
                TextBox2.Text = TextBox3.Text + "\" + ListBox1.Items(randomIndex)
                AxWindowsMediaPlayer1.URL = TextBox2.Text
                AxWindowsMediaPlayer1.Ctlcontrols.currentPosition = rnd.Next(1, 30)
                AxWindowsMediaPlayer1.Ctlcontrols.play()
                derat = rnda.Next(cp + TextBox4.Text, cp + TextBox5.Text)
            End If
            If (af = 0) Then


                If (cp > derat) Then
                    Dim rnd As New Random
                    Dim randomIndex As Integer = rnd.Next(0, ListBox1.Items.Count - 1)
                    TextBox6.Text = TextBox2.Text
                    TextBox2.Text = TextBox3.Text + "\" + ListBox1.Items(randomIndex)
                    AxWindowsMediaPlayer1.URL = TextBox2.Text
                    AxWindowsMediaPlayer1.Ctlcontrols.currentPosition = rnd.Next(1, 30)
                    AxWindowsMediaPlayer1.Ctlcontrols.play()
                    derat = rnda.Next(cp + TextBox4.Text, cp + TextBox5.Text)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Try
            Dim rnd As New Random
            Dim randomIndex As Integer = rnd.Next(0, ListBox1.Items.Count - 1)
            TextBox2.Text = TextBox3.Text + "\" + ListBox1.Items(randomIndex)
            AxWindowsMediaPlayer1.URL = TextBox2.Text
            AxWindowsMediaPlayer1.Ctlcontrols.currentPosition = rnd.Next(1, 30)
            AxWindowsMediaPlayer1.Ctlcontrols.play()
            derat = rnda.Next(cp + TextBox4.Text, cp + TextBox5.Text)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AxWindowsMediaPlayer1.Ctlcontrols.play()
    End Sub


    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        derat = 10000
    End Sub

    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If (Button6.Text = "All Full") Then
            Button6.Text = "None Full"
            af = 1
        Else
            Button6.Text = "All Full"
            af = 0
        End If

    End Sub

    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If (Button5.Text = "Longer Time") Then
            Button5.Text = "Short time"
            TextBox4.Text = 10
            TextBox5.Text = 50
        Else
            Button5.Text = "Longer Time"
            TextBox4.Text = 2
            TextBox5.Text = 8
        End If
    End Sub
    Private Sub Button8_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim n, count As Integer
        ' n = 0
        ' count = ListBox2.Items.Count()
        ' n = count - 1 - n
        AxWindowsMediaPlayer1.URL = TextBox6.Text
        AxWindowsMediaPlayer1.Ctlcontrols.currentPosition = 1
        AxWindowsMediaPlayer1.Ctlcontrols.play()
        derat = 10000
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        End
    End Sub
End Class
