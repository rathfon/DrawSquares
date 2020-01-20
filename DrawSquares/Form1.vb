Public Class Form1

    Dim myGraphics As Graphics
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        DrawSquare()
    End Sub

    Sub DrawSquare()
        Dim myPen As New Pen(Color.Black, 2)
        Dim row As Integer = 1
        Dim count As Integer = 1
        Dim x_offset As Integer = 1
        Dim y_offset As Integer = 45
        Dim x_offset_add As Integer = 274.28
        Dim y_offset_add As Integer = ((Me.Height - y_offset) / 5)


        Do Until row = 6

            myGraphics = Graphics.FromHwnd(ActiveForm().Handle)
            myGraphics.DrawRectangle(pen:=myPen, x:=x_offset, y:=y_offset, width:=x_offset_add, height:=y_offset_add)
            If count = 7 Then
                row += 1
                count = 1
                y_offset += y_offset_add
                x_offset = 0
            Else
                x_offset += x_offset_add
                count += 1
            End If
        Loop
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        DrawSquare()
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize

    End Sub

    Private Sub Form1_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
        myGraphics.Dispose()
        DrawSquare()
    End Sub
End Class
