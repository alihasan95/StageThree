Public Class Form1

    Private Point1, Point2 As Point



    Private Sub Pc_DrawnArea_MouseDown(sender As Object, e As MouseEventArgs) Handles Pc_DrawnArea.MouseDown
        Point1 = e.Location

        Label1.Text = Point1.ToString()
    End Sub

    Private Sub Pc_DrawnArea_MouseUp(sender As Object, e As MouseEventArgs) Handles Pc_DrawnArea.MouseUp
        Point2 = e.Location

        Label2.Text = Point2.ToString()

        DrawLine(Point1, Point2)

    End Sub


    Private Sub DrawnLineDirect(p1 As Point, p2 As Point)

        Dim graph As Graphics = Pc_DrawnArea.CreateGraphics()



        Dim length, Dy, Dx, Xinc, Yinc As Integer

        Dy = p2.Y - p1.Y
        Dx = p2.X - p1.X

        length = Math.Max(Math.Abs(Dy), Math.Abs(Dx))

        Xinc = Dx / length
        Yinc = Dy / length


        Dim Img As New Bitmap(1, 1)
        Img.SetPixel(0, 0, Color.Green)


        Dim x, y As Integer
        x = p1.X
        y = p1.Y

        For i = 1 To length

            graph.DrawImage(Img, x, y)
            x += Xinc
            y += Yinc

        Next



    End Sub


    Private Sub BresenhumLine(p1 As Point, p2 As Point)

        Dim graph As Graphics = Pc_DrawnArea.CreateGraphics()



        Dim Dy, Dx, P, s1, s2, temp, change

        Dy = Math.Abs(p2.Y - p1.Y)
        Dx = Math.Abs(p2.X - p1.X)

        P = 2 * (Dy - Dx)

        s1 = Math.Sign(p2.X - p1.X)
        s2 = Math.Sign(p2.Y - p2.Y)


        Dim Img As New Bitmap(1, 1)
        Img.SetPixel(0, 0, Color.Green)



        If (Dy > Dx) Then
            temp = Dx
            Dx = Dy
        Dy = temp
            change = 1

        Else
            change = 0
        End If


        Dim x, y As Integer

        For i = 1 To Dx
            If (P > 0) Then
                If (change = 1) Then
                    x = x + s1
                Else
                    y = y + s2
                End If
            Else
                P = P + 2 * Dy
            End If
            If (change = 1) Then
                y = y + s2
            Else
                x = x + s1
            End If

            graph.DrawImage(Img, x, y)
        Next




    End Sub



    Private Sub DrawLineDirect(Point1 As Point, Point2 As Point)

        Dim i, Dx, Dy, B, m, New_Y, New_X As Integer


        Dx = Point2.X - Point1.X
        Dy = Point2.Y - Point1.Y

        If (Dx = 0) Then
            m = 0
        Else
            m = Dy / Dx
        End If



        Dim g As Graphics = Pc_DrawnArea.CreateGraphics()
        Dim Img As New Bitmap(1, 1)
        Img.SetPixel(0, 0, Color.White)


        B = Point1.Y - (m * Point1.X)

        If (Dy > Dx) Then



            For i = Point1.X + 1 To Point2.X

                New_Y = B + m * i
                g.DrawImage(Img, i, Math.Round(New_Y))

            Next

            Console.WriteLine("First Dy>DX")
        Else

            If (m = 0) Then
                m = 1
            End If
            For i = Point1.Y + 1 To Point2.Y

                New_X = (i - B) / m

                g.DrawImage(Img, Math.Round(New_X), i)

            Next


            Console.WriteLine("Second  DX>DY")
        End If





    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Point1 = New Point(0, 0)
        Point2 = New Point(0, 0)

    End Sub


    Private Sub DrawLine(p1 As Point, p2 As Point)

        Dim graph As Graphics = Pc_DrawnArea.CreateGraphics()

        graph.DrawLine(Pens.Green, p1, p2)

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim graph As Graphics = Pc_DrawnArea.CreateGraphics()

        Dim mHeight = Pc_DrawnArea.Height / 2


        Dim startPoint As Point = New Point(300, Pc_DrawnArea.Height - 10)
        Dim p2 As Point = New Point(400, mHeight)

        DrawLine(startPoint, p2)


        p2 = New Point(370, mHeight + 10)
        DrawLine(startPoint, p2)


        p2 = New Point(230, mHeight + 10)
        DrawLine(startPoint, p2)


        p2 = New Point(200, mHeight)
        DrawLine(startPoint, p2)

        'Long line 
        p2 = New Point(350, mHeight - 20)
        DrawLine(startPoint, p2)

        p2 = New Point(250, mHeight - 20)
        DrawLine(startPoint, p2)


        ' level two 
        'line above base line 

        Dim p1 As Point = New Point(200, mHeight)
        p2 = New Point(230, mHeight + 10)
        DrawLine(p1, p2)

        p1 = New Point(230, mHeight + 10)
        p2 = New Point(370, mHeight + 10)
        DrawLine(p1, p2)

        p1 = New Point(370, mHeight + 10)
        p2 = New Point(400, mHeight)
        DrawLine(p1, p2)


        'level there

        p1 = New Point(400, mHeight)
        p2 = New Point(350, mHeight - 20)
        DrawLine(p1, p2)

        p1 = New Point(200, mHeight)
        p2 = New Point(250, mHeight - 20)
        DrawLine(p1, p2)

        p1 = New Point(250, mHeight - 20)
        p2 = New Point(350, mHeight - 20)
        DrawLine(p1, p2)



    End Sub

    Private Sub Pc_DrawnArea_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Pc_DrawnArea.MouseDoubleClick
        Pc_DrawnArea.Image = Nothing
    End Sub
End Class
