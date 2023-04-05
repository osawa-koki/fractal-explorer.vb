Imports System.Drawing
Imports System.IO

Module BurningShip
  Sub Draw(burning_ship_config As IBurningShip, items As List(Of String))
    Dim width = burning_ship_config.width
    Dim height = burning_ship_config.height

    Dim x_min = burning_ship_config.x_min
    Dim x_max = burning_ship_config.x_max
    Dim y_min = burning_ship_config.y_min
    Dim y_max = burning_ship_config.y_max

    Dim threshold = burning_ship_config.threshold
    Dim max_iterations = burning_ship_config.max_iterations

    If True Then
      Dim bmp As New Bitmap(width, height)
      For y = 0 To height - 1
        For x = 0 To width - 1
          Dim x0 = x_min + (x_max - x_min) * x / width
          Dim y0 = y_min + (y_max - y_min) * y / height
          Dim x1 = 0.0
          Dim y1 = 0.0
          Dim i = 0
          While x1 * x1 + y1 * y1 <= 2 * 2 AndAlso i < max_iterations
            Dim x2 = Math.Abs(x1 * x1 - y1 * y1 + x0)
            Dim y2 = Math.Abs(2 * x1 * y1 + y0)
            x1 = x2
            y1 = y2
            i += 1
          End While
          i = i * 255 / max_iterations
          Dim _color = Color.FromArgb(i, i, i)
          bmp.SetPixel(x, y, _color)
        Next
      Next
      Dim file_name = burning_ship_config.output_file.Replace(".png", ".white.png")
      bmp.Save(Path.Combine(burning_ship_config.output_directory, file_name), Imaging.ImageFormat.Png)
      items.Add(file_name)
    End If

    If True Then
      Dim bmp As New Bitmap(width, height)
      For y = 0 To height - 1
        For x = 0 To width - 1
          Dim x0 = x_min + (x_max - x_min) * x / width
          Dim y0 = y_min + (y_max - y_min) * y / height
          Dim x1 = 0.0
          Dim y1 = 0.0
          Dim i = 0
          While x1 * x1 + y1 * y1 <= 2 * 2 AndAlso i < max_iterations
            Dim x2 = Math.Abs(x1 * x1 - y1 * y1 + x0)
            Dim y2 = Math.Abs(2 * x1 * y1 + y0)
            x1 = x2
            y1 = y2
            i += 1
          End While
          i = 255 - (i * 255 / max_iterations)
          Dim _color = Color.FromArgb(i, i, i)
          bmp.SetPixel(x, y, _color)
        Next
      Next
      Dim file_name = burning_ship_config.output_file.Replace(".png", ".black.png")
      bmp.Save(Path.Combine(burning_ship_config.output_directory, file_name), Imaging.ImageFormat.Png)
      items.Add(file_name)
    End If
  End Sub
End Module
