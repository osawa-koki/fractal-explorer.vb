Imports System.Drawing
Imports System.IO

Module Julia
  Sub Draw(julia_config As IJulia, items As List(Of String))
    Dim width = julia_config.width
    Dim height = julia_config.height

    Dim x_min = julia_config.x_min
    Dim x_max = julia_config.x_max
    Dim y_min = julia_config.y_min
    Dim y_max = julia_config.y_max
    Dim c_re = julia_config.c_re
    Dim c_im = julia_config.c_im

    Dim threshold = julia_config.threshold
    Dim max_iterations = julia_config.max_iterations

    If True Then
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
      Dim file_name = julia_config.output_file.Replace(".png", ".white.png")
      bmp.Save(Path.Combine(julia_config.output_directory, file_name), Imaging.ImageFormat.Png)
      items.Add(file_name)
    End If

    If True Then
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
          i = 255 - (i * 255 \ max_iterations)
          Dim color As Color = Color.FromArgb(i, i, i)
          bmp.SetPixel(x, y, color)
        Next
      Next
      Dim file_name = julia_config.output_file.Replace(".png", ".black.png")
      bmp.Save(Path.Combine(julia_config.output_directory, file_name), Imaging.ImageFormat.Png)
      items.Add(file_name)
    End If
  End Sub
End Module
