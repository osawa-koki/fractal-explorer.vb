Imports System.IO
Imports System.Drawing

Module Mandelbrot
  Sub Draw(mandelbrot_config As IMandelbrot, items As List(Of String))
    Dim width = mandelbrot_config.width
    Dim height = mandelbrot_config.height

    Dim x_min = mandelbrot_config.x_min
    Dim x_max = mandelbrot_config.x_max
    Dim y_min = mandelbrot_config.y_min
    Dim y_max = mandelbrot_config.y_max

    Dim threshold = mandelbrot_config.threshold
    Dim max_iterations = mandelbrot_config.max_iterations

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
            Dim x2 = x1 * x1 - y1 * y1 + x0
            Dim y2 = 2 * x1 * y1 + y0
            x1 = x2
            y1 = y2
            i += 1
          End While
          i = i * 255 / max_iterations
          Dim _color = Color.FromArgb(i, i, i)
          bmp.SetPixel(x, y, _color)
        Next
      Next
      Dim file_name = mandelbrot_config.output_file.Replace(".png", ".white.png")
      bmp.Save(Path.Combine(mandelbrot_config.output_directory, file_name), Imaging.ImageFormat.Png)
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
            Dim x2 = x1 * x1 - y1 * y1 + x0
            Dim y2 = 2 * x1 * y1 + y0
            x1 = x2
            y1 = y2
            i += 1
          End While
          i = 255 - (i * 255 / max_iterations)
          Dim _color = Color.FromArgb(i, i, i)
          bmp.SetPixel(x, y, _color)
        Next
      Next
      Dim file_name = mandelbrot_config.output_file.Replace(".png", ".black.png")
      bmp.Save(Path.Combine(mandelbrot_config.output_directory, file_name), Imaging.ImageFormat.Png)
      items.Add(file_name)
    End If
  End Sub
End Module
