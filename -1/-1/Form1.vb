Public Class Form1
    Public V0 As Double
    Dim A As Double
    Public H0 As Double
    Public L As Double
    Public Hmax As Double
    Public Time As Double
    Public Const g = 9.81
    Public SinA As Double
    Public CosA As Double
    Dim D As Double
    Dim Gr1 As Graphics
    Dim Gr2 As Graphics
    Dim BM2 As Bitmap
    Dim BM1 As Bitmap
    Dim P1 As Pen = New Pen(Color.Red, 2)
    Dim P2 As Pen = New Pen(Color.Blue, 2)
    Dim B1 As SolidBrush = New SolidBrush(Color.Green)
    Dim t As Double
    Dim dt As Double
    Dim x As Double
    Dim y As Double
    Dim Kx As Double
    Dim Ky As Double
    Dim X1scr As Integer
    Dim Y1scr As Integer
    Dim X2scr As Integer
    Dim Y2scr As Integer

    Dim B2 As SolidBrush = New SolidBrush(Color.Yellow)








    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        V0 = Val(TextBox1.Text)
        A = Val(TextBox2.Text) * Math.PI / 180
        H0 = Val(TextBox3.Text)
        SinA = Math.Sin(A)
        CosA = Math.Cos(A)
        D = V0 * V0 * SinA * SinA + 2 * g * H0
        Time = (V0 * SinA + Math.Sqrt(D)) / g
        L = (V0 * CosA) * Time
        Hmax = H0 + (V0 * V0 * SinA * SinA) / (2 * g)
        TextBox4.Text = Str(L)
        TextBox5.Text = Str(Time)
        TextBox6.Text = Str(Hmax)
        t = 0
        dt = Time / 1000
        Kx = 0.9 * BM1.Width / L
        Ky = 0.9 * BM1.Height / Hmax
        X1scr = 0
        Y1scr = CInt(BM1.Height - Ky * H0)
        Gr1.Clear(PictureBox1.BackColor)

        Timer1.Enabled = True







        'Gr1.DrawLine(P1, 50, 70, 150, 200)
        'Gr1.FillEllipse(B1, 50, 30, 70, 50)
        'PictureBox1.Image = BM1













    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BM1 = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Gr1 = Graphics.FromImage(BM1)
        BM2 = New Bitmap(PictureBox1.Width, PictureBox1.Height)
        Gr2 = Graphics.FromImage(BM2)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        t = t + dt
        x = V0 * CosA * t
        y = H0 + V0 * SinA * t - g * t * t / 2
        X2scr = CInt(Kx * x)
        Y2scr = CInt(BM1.Height - Ky * y)
        Gr1.DrawLine(P1, X1scr, Y1scr, X2scr, Y2scr)
        Gr2.DrawImage(BM1, 0, 0)
        Gr2.DrawEllipse(P2, X2scr - 5, Y2scr - 5, 11, 11)

        PictureBox1.Image = BM2
        X1scr = X2scr
        Y1scr = Y2scr

        If t >= Time Then Timer1.Enabled = False
        If t >= Time Then MessageBox.Show(" Движение закончено ")



    End Sub

    Private Sub ПоказатьToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ПоказатьToolStripMenuItem.Click
        Form2.Visible = True
        Form2.DG1()

        Form2.DG2()


    End Sub

End Class
