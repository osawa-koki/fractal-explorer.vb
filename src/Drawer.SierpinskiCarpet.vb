Imports System.IO
Imports System.Drawing

Module SierpinskiCarpet

  Dim max_iterations As Integer

  ' def cross_join(arg)
  '   answer = []
  '   arg.each do |x|
  '     arg.each do |y|
  '       answer.push({x: x, y: y})
  '     end
  '   end
  '   return answer
  ' end

  Function CrossJoin(arg As Integer()) As Point()
    Dim answer = New List(Of Point)
    For Each x In arg
      For Each y In arg
        answer.Add(New Point(x, y))
      Next
    Next
    Return answer.ToArray
  End Function

  Sub RecursiveDraw(graphics As Graphics, x As Integer, y As Integer, size As Integer, n As Integer, color As SolidBrush)
    If max_iterations < n Then
      Return
    End If

    Dim xys = New Integer() {1 / 9.0 * size, 4 / 9.0 * size, 7 / 9.0 * size}
    For Each xy In CrossJoin(xys)
      graphics.FillRectangle(color, CInt(x + xy.X), CInt(y + xy.Y), CInt(size / 9.0), CInt(size / 9.0))
      RecursiveDraw(graphics, x + xy.X - size / 9.0, y + xy.Y - size / 9.0, size / 3.0, n + 1, color)
    Next

  End Sub

  Sub Draw(sierpinski_triangle_config As ISierpinskiCarpet, items As List(Of String))
    Dim width = sierpinski_triangle_config.width
    Dim height = sierpinski_triangle_config.height

    Dim carpet_size = sierpinski_triangle_config.carpet_size
    max_iterations = sierpinski_triangle_config.max_iterations

    Dim size = width * carpet_size / 100
    Dim start = (height - size) / 2
    Dim size_inside = size / 3
    Dim start_inside = start + size_inside

    If True Then
      Dim bmp = New Bitmap(width, height)
      Dim graphics As Graphics = Graphics.FromImage(bmp)
      graphics.FillRectangle(Brushes.Black, 0, 0, width, height)

      graphics.FillRectangle(Brushes.White, CInt(start), CInt(start), CInt(size), CInt(size))
      graphics.FillRectangle(Brushes.Black, CInt(start_inside), CInt(start_inside), CInt(size_inside), CInt(size_inside))
      RecursiveDraw(graphics, start, start, size, 1, Brushes.Black)

      Dim file_name = sierpinski_triangle_config.output_file.Replace(".png", ".white.png")
      bmp.Save(Path.Combine(sierpinski_triangle_config.output_directory, file_name), Imaging.ImageFormat.Png)
      items.Add(file_name)
    End If

    If True Then
      Dim bmp = New Bitmap(width, height)
      Dim graphics As Graphics = Graphics.FromImage(bmp)
      graphics.FillRectangle(Brushes.White, 0, 0, width, height)

      graphics.FillRectangle(Brushes.Black, CInt(start), CInt(start), CInt(size), CInt(size))
      graphics.FillRectangle(Brushes.White, CInt(start_inside), CInt(start_inside), CInt(size_inside), CInt(size_inside))
      RecursiveDraw(graphics, start, start, size, 1, Brushes.White)

      Dim file_name = sierpinski_triangle_config.output_file.Replace(".png", ".black.png")
      bmp.Save(Path.Combine(sierpinski_triangle_config.output_directory, file_name), Imaging.ImageFormat.Png)
      items.Add(file_name)
    End If

  End Sub
End Module
