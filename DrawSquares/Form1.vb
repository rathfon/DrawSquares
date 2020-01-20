Public Class Form1
    Dim myGraphics As Graphics
    Dim formLoaded As Boolean = False


    Sub DrawSquare()
        Console.WriteLine("drawing")
        Dim myPen As New Pen(Color.Black, 2)
        Dim row As Integer = 1
        Dim count As Integer = 1
        Dim x_offset As Integer = 1
        Dim y_offset As Integer = 45
        Dim x_offset_add As Integer = 274.28
        Dim y_offset_add As Integer = ((Me.Height - y_offset) / 5)

        Do Until row = 6
            Console.WriteLine("drawing row: " & row & ", column: " & count)
            myGraphics = Graphics.FromHwnd(ActiveForm().Handle)
            myGraphics.DrawRectangle(pen:=myPen, x:=x_offset, y:=y_offset, width:=x_offset_add, height:=y_offset_add)
            If count = 7 Then
                row += 1
                count = 1
                y_offset += y_offset_add
                x_offset = 1
            Else
                x_offset += x_offset_add
                count += 1
            End If
            DrawParts(x_offset, y_offset)
        Loop
        Me.Update()
    End Sub

    Sub DrawParts(x As Integer, y As Integer)
        Dim myg As Graphics
        Dim myPen As New Pen(Color.Black, 2)
        Dim count As Integer = 1
        Dim x_offset As Integer = x
        Dim y_offset As Integer = y
        Dim x_offset_add As Integer = 274.28
        Dim y_offset_add As Integer = ((Me.Height - y_offset) / 5) / 5

        Do Until count = 6
            myg = Graphics.FromHwnd(ActiveForm().Handle)
            myg.DrawRectangle(pen:=myPen, x:=x_offset, y:=y_offset, width:=x_offset_add, height:=y_offset_add)
            count += 1
            y_offset += y_offset_add

        Loop
    End Sub

    Private Sub Form1_ResizeEnd(sender As Object, e As EventArgs) Handles Me.Resize
        'If formloaded = False Then Exit Sub
        If myGraphics IsNot Nothing Then
            MsgBox("Disposing")
            'myGraphics.Dispose()
        End If
        'DrawSquare()

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'DrawSquare()
        formLoaded = True
        DrawSquare()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DrawSquare()
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyValue = Keys.Alt Then Exit Sub
    End Sub
End Class
