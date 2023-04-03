Imports System.Drawing

Module Tricorn
  Sub Draw(tricorn_config As ITricorn)
    Dim width = tricorn_config.width
    Dim height = tricorn_config.height

    Dim x_min = tricorn_config.x_min
    Dim x_max = tricorn_config.x_max
    Dim y_min = tricorn_config.y_min
    Dim y_max = tricorn_config.y_max

    Dim color_base = tricorn_config.color_hue
    Dim threshold = tricorn_config.threshold
    Dim max_iterations = tricorn_config.max_iterations

    Dim bmp As New Bitmap(width, height)

    For y = 0 To height - 1
      For x = 0 To width - 1
        Dim x0 = x_min + (x_max - x_min) * x / width
        Dim y0 = y_min + (y_max - y_min) * y / height
        Dim x1 = 0.0
        Dim y1 = 0.0
        Dim i = 0
        While x1 * x1 + y1 * y1 <= 2 * 2 AndAlso i < max_iterations
          Dim x2 = x1 * x1 - y1 * y1 + x0
          Dim y2 = -(2 * x1 * y1 + y0)
          x1 = x2
          y1 = y2
          i += 1
        End While
        i = i * 255 / max_iterations
        Dim _color = Color.FromArgb(i, i, i)
        bmp.SetPixel(x, y, _color)
      Next
    Next

    bmp.Save(tricorn_config.output_file, Imaging.ImageFormat.Png)
  End Sub
End Module