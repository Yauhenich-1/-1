Public Class Form2
    Dim BM1 As Bitmap
    Dim BM2 As Bitmap
    Dim BM3 As Bitmap
    Dim BM4 As Bitmap
    Dim BM5 As Bitmap
    Dim BM6 As Bitmap
    Dim Gr1 As Graphics
    Dim Gr2 As Graphics
    Dim Gr3 As Graphics
    Dim Gr4 As Graphics
    Dim Gr5 As Graphics
    Dim Gr6 As Graphics
    Dim P0 As Pen = New Pen(Color.Gray, 1)
    Dim P1 As Pen = New Pen(Color.Red, 2)
    Dim P2 As Pen = New Pen(Color.Blue, 2)
    Dim P3 As Pen = New Pen(Color.Violet, 2)
    Dim P4 As Pen = New Pen(Color.Black, 2)
    Dim P5 As Pen = New Pen(Color.Yellow, 2)
    Dim P6 As Pen = New Pen(Color.Pink, 2)
    Dim t As Double
    Dim x As Double
    Dim y As Double
    Dim Kh1 As Double
    Dim Kv1 As Double
    Dim Kh2 As Double
    Dim Kv2 As Double
    Dim Kh3 As Double
    Dim Kv3 As Double
    Dim Kh4 As Double
    Dim Kv4 As Double
    Dim Kh5 As Double
    Dim Kv5 As Double
    Dim Kh6 As Double
    Dim Kv6 As Double
    Dim X1scr As Integer
    Dim Y1scr As Integer
    Dim X2scr As Integer
    Dim Y2scr As Integer



    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BM1 = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Gr1 = Graphics.FromImage(BM1)
        BM2 = New Bitmap(PictureBox2.Width, PictureBox2.Height)
        Gr2 = Graphics.FromImage(BM2)
        'BM3 = New Bitmap(PictureBox3.Width, PictureBox3.Height)
        'Gr3 = Graphics.FromImage(BM3)


        'Анологично ещё для 5-ти BM и Gr

    End Sub
    Public Sub DG1()
        Kh1 = (BM1.Width / Form1.Time) * Math.Pow(0.5, TrackBar1.Value)
        Kv1 = (BM1.Height / Form1.L) * Math.Pow(0.5, TrackBar2.Value)
        X1scr = 0
        Y1scr = BM1.Height
        Gr1.Clear(PictureBox1.BackColor)
        For i = 0 To 10

            Gr1.DrawLine(P0, 0, CInt(i * BM1.Height / 10), BM1.Width, CInt(i * BM1.Height / 10))
            Gr1.DrawLine(P0, CInt(i * BM1.Width / 10), 0, CInt(i * BM1.Width / 10), BM1.Height)



        Next
        X1scr = 0
        Y1scr = BM1.Height


        For i = 1 To BM1.Width
            X2scr = i
            t = X2scr / Kh1
            If t <= Form1.Time Then
                x = Form1.V0 * Form1.CosA * t
            Else x = Form1.L
            End If
            Y2scr = CInt(BM1.Height - Kv1 * x)
            Gr1.DrawLine(P1, X1scr, Y1scr, X2scr, Y2scr)
            X1scr = X2scr
            Y1scr = Y2scr

        Next
        PictureBox1.Image = BM1

        'If X2scr >= PictureBox1.Width Then MessageBox.Show("Yeeeeep")


    End Sub


    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        DG1()


    End Sub

    Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs) Handles TrackBar2.Scroll
        DG1()
    End Sub

    Private Sub PictureBox1_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox1.MouseEnter
        Label1.Visible = True

    End Sub

    Private Sub PictureBox1_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox1.MouseLeave
        Label1.Visible = False
    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        Label1.Left = PictureBox1.Left + e.X + 7
        Label1.Top = PictureBox1.Top + e.Y - 1
        Label1.Text = String.Format("( {0:f0}, {1:f0} )", e.X / Kh1, (BM1.Height - e.Y) / Kv1)


        'If e.X = PictureBox1.Height Then MessageBox.Show("Ne Nado")


    End Sub

    Public Sub DG2()
        Kh2 = (BM2.Width / Form1.Time) * Math.Pow(0.5, TrackBar3.Value)
        Kv2 = (BM2.Height / Form1.Hmax) * Math.Pow(0.5, TrackBar4.Value)
        X1scr = 0
        Y1scr = BM2.Height - Kv2 * Form1.H0
        Gr2.Clear(PictureBox2.BackColor)
        For i = 0 To 10

            Gr2.DrawLine(P0, 0, CInt(i * BM2.Height / 10), BM2.Width, CInt(i * BM2.Height / 10))
            Gr2.DrawLine(P0, CInt(i * BM2.Width / 10), 0, CInt(i * BM2.Width / 10), BM2.Height)



        Next
        X1scr = 0
        Y1scr = BM2.Height


        For i = 1 To BM2.Width
            X2scr = i
            t = X2scr / Kh2
            If t <= Form1.Time Then
                y = Form1.H0 + Form1.V0 * Form1.SinA * t - (Form1.g * t * t) / 2

            Else y = 0
            End If
            Y2scr = CInt(BM2.Height - Kv2 * y)
            X2scr = i
            t = X2scr / Kh2

            Gr2.DrawLine(P1, X1scr, Y1scr, X2scr, Y2scr)
            X1scr = X2scr
            Y1scr = Y2scr

        Next
        PictureBox2.Image = BM2
    End Sub

    Private Sub TrackBar4_Scroll(sender As Object, e As EventArgs) Handles TrackBar4.Scroll
        DG2()
    End Sub

    Private Sub TrackBar3_Scroll(sender As Object, e As EventArgs) Handles TrackBar3.Scroll
        DG2()
    End Sub
End Class