Imports System.IO
Imports System.Drawing

Module SierpinskiTriangle

  Dim max_iterations As Integer

  Sub DrawTriangle(graphics As Graphics, x As Integer, y As Integer, size As Integer, color As SolidBrush)
    Dim p1_x = x + size / 2
    Dim p1_y = y - Math.Sin(-60 * Math.PI / 180) * size
    Dim p2_x = x + size
    Dim p2_y = y

    Dim points = New Point() {
      New Point(x, y),
      New Point(p1_x, p1_y),
      New Point(p2_x, p2_y)
    }
    graphics.FillPolygon(color, points)

  End Sub

  Sub RecursiveDraw(graphics As Graphics, x As Integer, y As Integer, size As Integer, n As Integer, color As SolidBrush)
    If max_iterations < n Then
      Return
    End If

    Dim p1_x = Math.Cos(240 * Math.PI / 180) * 1 / 4 * size + x
    Dim p1_y = y - Math.Sin(240 * Math.PI / 180) * 1 / 4 * size
    Dim p2_x = Math.Cos(240 * Math.PI / 180) * 3 / 4 * size + x
    Dim p2_y = y - Math.Sin(240 * Math.PI / 180) * 3 / 4 * size
    Dim p3_x = p2_x + size / 2
    Dim p3_y = p2_y

    DrawTriangle(graphics, p1_x, p1_y, size / 4, color)
    DrawTriangle(graphics, p2_x, p2_y, size / 4, color)
    DrawTriangle(graphics, p3_x, p3_y, size / 4, color)

    RecursiveDraw(
      graphics,
      x,
      y,
      size / 2,
      n + 1,
      color
    )

    RecursiveDraw(
      graphics,
      Math.Cos(240 * Math.PI / 180) * 1 / 2 * size + x,
      y - Math.Sin(240 * Math.PI / 180) * 1 / 2 * size,
      size / 2,
      n + 1,
      color
    )

    RecursiveDraw(
      graphics,
      Math.Cos(-60 * Math.PI / 180) * 1 / 2 * size + x,
      y - Math.Sin(-60 * Math.PI / 180) * 1 / 2 * size,
      size / 2,
      n + 1,
      color
    )

  End Sub

  Sub Draw(sierpinski_triangle_config As ISierpinskiTriangle, items As List(Of String))
    Dim width = sierpinski_triangle_config.width
    Dim height = sierpinski_triangle_config.height

    Dim triangle_size = sierpinski_triangle_config.triangle_size
    max_iterations = sierpinski_triangle_config.max_iterations

    Dim size = width * triangle_size / 100
    Dim start = (height - (Math.Sqrt(3) * height * triangle_size / 100 / 2)) / 2

    Dim p1_x = Math.Cos(240 * Math.PI / 180) * Size / 2 + width / 2
    Dim p1_y = start - Math.Sin(240 * Math.PI / 180) * Size / 2
    Dim p2_x = Math.Cos(-60 * Math.PI / 180) * Size / 2 + p1_x
    Dim p2_y = p1_y - Math.Sin(-60 * Math.PI / 180) * Size / 2

    Dim _p2_x = Math.Cos(240 * Math.PI / 180) * Size + width / 2
    Dim _p2_y = start - Math.Sin(240 * Math.PI / 180) * size

    Dim first_points = New Point() {
      New Point(width / 2, start),
      New Point(_p2_x, _p2_y),
      New Point(_p2_x + size, _p2_y)
    }
    Dim second_points = New Point() {
      New Point(p1_x, p1_y),
      New Point(p2_x, p2_y),
      New Point(p1_x + size / 2, p1_y)
    }

    If True Then
      Dim bmp As New Bitmap(width, height)
      Dim graphics As Graphics = Graphics.FromImage(bmp)
      graphics.FillRectangle(Brushes.Black, 0, 0, width, height)

      graphics.FillPolygon(Brushes.White, first_points)
      graphics.FillPolygon(Brushes.Black, second_points)

      RecursiveDraw(graphics, width / 2, start, size, 1, Brushes.Black)

      Dim file_name = sierpinski_triangle_config.output_file.Replace(".png", ".white.png")
      bmp.Save(Path.Combine(sierpinski_triangle_config.output_directory, file_name), Imaging.ImageFormat.Png)
      items.Add(file_name)
    End If

    If True Then
      Dim bmp As New Bitmap(width, height)
      Dim graphics As Graphics = Graphics.FromImage(bmp)
      graphics.FillRectangle(Brushes.White, 0, 0, width, height)

      graphics.FillPolygon(Brushes.Black, first_points)
      graphics.FillPolygon(Brushes.White, second_points)

      RecursiveDraw(graphics, width / 2, start, size, 1, Brushes.White)

      Dim file_name = sierpinski_triangle_config.output_file.Replace(".png", ".black.png")
      bmp.Save(Path.Combine(sierpinski_triangle_config.output_directory, file_name), Imaging.ImageFormat.Png)
      items.Add(file_name)
    End If
  End Sub
End Module
