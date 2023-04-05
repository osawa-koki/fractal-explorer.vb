Imports System.Drawing
Imports System.IO

Module DragonCurve

  Dim _x As Integer
  Dim _y As Integer

  Sub DrawDragon(graphics As Graphics, i As Integer, dx As Integer, dy As Integer, sign As Integer, color As Pen)
    If i = 0 Then
      graphics.DrawLine(color, _x, _y, _x + dx, _y + dy)
      _x += dx
      _y += dy
    Else
      DrawDragon(graphics, i - 1, (dx - sign * dy) / 2, (dy + sign * dx) / 2, 1, color)
      DrawDragon(graphics, i - 1, (dx + sign * dy) / 2, (dy - sign * dx) / 2, -1, color)
    End If
  End Sub

  Sub Draw(dragon_curve_config As IDragonCurve, items As List(Of String))
    Dim width = dragon_curve_config.width
    Dim height = dragon_curve_config.height

    Dim x = dragon_curve_config.x
    Dim y = dragon_curve_config.y

    Dim delta = dragon_curve_config.delta
    Dim max_iterations = dragon_curve_config.max_iterations

    Dim _delta = delta / 100.0 * width

    If True Then
      Dim bmp As New Bitmap(width, height)
      Dim graphics As Graphics = Graphics.FromImage(bmp)
      graphics.FillRectangle(Brushes.Black, 0, 0, width, height)

      _x = x / 100 * width
      _y = height - (y / 100 * height)

      DrawDragon(graphics, max_iterations, _delta, _delta, 1, Pens.White)

      Dim file_name = dragon_curve_config.output_file.Replace(".png", ".white.png")
      bmp.Save(Path.Combine(dragon_curve_config.output_directory, file_name), Imaging.ImageFormat.Png)
      items.Add(file_name)
    End If

    If True Then
      Dim bmp As New Bitmap(width, height)
      Dim graphics As Graphics = Graphics.FromImage(bmp)
      graphics.FillRectangle(Brushes.White, 0, 0, width, height)

      _x = x / 100 * width
      _y = height - (y / 100 * height)

      DrawDragon(graphics, max_iterations, _delta, _delta, 1, Pens.Black)

      Dim file_name = dragon_curve_config.output_file.Replace(".png", ".black.png")
      bmp.Save(Path.Combine(dragon_curve_config.output_directory, file_name), Imaging.ImageFormat.Png)
      items.Add(file_name)
    End If

  End Sub
End Module
