Imports System.Drawing

Module Julia
  Sub Draw(mandelbrot_config As IJulia)
    Dim width = mandelbrot_config.width
    Dim height = mandelbrot_config.height

    Dim x_min = mandelbrot_config.x_min
    Dim x_max = mandelbrot_config.x_max
    Dim y_min = mandelbrot_config.y_min
    Dim y_max = mandelbrot_config.y_max
    Dim c_re = mandelbrot_config.c_re
    Dim c_im = mandelbrot_config.c_im

    Dim color_base = mandelbrot_config.color_hue
    Dim threshold = mandelbrot_config.threshold
    Dim max_iterations = mandelbrot_config.max_iterations

    Dim bmp As New Bitmap(width, height)

    For y As Integer = 0 To height - 1
      For x As Integer = 0 To width - 1
        Dim x0 As Double = x_min + (x_max - x_min) * x / width
        Dim y0 As Double = y_min + (y_max - y_min) * y / height
        Dim x1 As Double = x0
        Dim y1 As Double = y0
        Dim i As Integer = 0
        While x1 * x1 + y1 * y1 <= 2 * 2 AndAlso i < max_iterations
          Dim x2 As Double = x1 * x1 - y1 * y1 + c_re
          Dim y2 As Double = 2 * x1 * y1 + c_im
          x1 = x2
          y1 = y2
          i += 1
        End While
        i = i * 255 \ max_iterations
        Dim color As Color = Color.FromArgb(i, i, i)
        bmp.SetPixel(x, y, color)
      Next
    Next

    bmp.Save(mandelbrot_config.output_file, Imaging.ImageFormat.Png)
  End Sub
End Module
