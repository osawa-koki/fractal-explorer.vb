Imports System.Drawing
Imports System.IO

Module BarnsleyFern
  Sub Draw(barnsley_fern_config As IBarnsleyFern, items As List(Of String))
    Dim width = barnsley_fern_config.width
    Dim height = barnsley_fern_config.height

    Dim size_x = barnsley_fern_config.size_x
    Dim size_y = barnsley_fern_config.size_y
    Dim start_x = barnsley_fern_config.start_x
    Dim start_y = barnsley_fern_config.start_y

    Dim zoom = barnsley_fern_config.zoom
    Dim max_iterations = barnsley_fern_config.max_iterations

    If True Then
      Dim bmp As New Bitmap(width, height)
      Dim graphics As Graphics = Graphics.FromImage(bmp)
      graphics.FillRectangle(Brushes.Black, 0, 0, width, height)
      graphics.Dispose()

      Dim x = 0.0
      Dim y = 0.0

      For i = 0 To max_iterations - 1
        Dim px As Integer = zoom * x + start_x * width / 100
        Dim py As Integer = (height - (size_y * height / 1000) * y + (start_y * height / 100))
        Dim _color = Color.FromArgb(255, 255, 255)
        Try
          bmp.SetPixel(px, py, _color)
        Catch ex As Exception

        End Try

        Dim r = Rnd() * 100
        Dim xn = x
        Dim yn = y
        If r < 1 Then
          x = 0
          y = 0.16 * yn
        ElseIf r < 86 Then
          x = 0.85 * xn + 0.04 * yn
          y = -0.04 * xn + 0.85 * yn + 1.6
        ElseIf r < 93 Then
          x = 0.2 * xn - 0.26 * yn
          y = 0.23 * xn + 0.22 * yn + 1.6
        Else
          x = -0.15 * xn + 0.28 * yn
          y = 0.26 * xn + 0.24 * yn + 0.44
        End If
      Next
      Dim file_name = barnsley_fern_config.output_file.Replace(".png", ".white.png")
      bmp.Save(Path.Combine(barnsley_fern_config.output_directory, file_name), Imaging.ImageFormat.Png)
      items.Add(file_name)
    End If

    If True Then
      Dim bmp As New Bitmap(width, height)
      Dim graphics As Graphics = Graphics.FromImage(bmp)
      graphics.FillRectangle(Brushes.White, 0, 0, width, height)
      graphics.Dispose()

      Dim x = 0.0
      Dim y = 0.0

      For i = 0 To max_iterations - 1
        Dim px As Integer = zoom * x + start_x * width / 100
        Dim py As Integer = (height - (size_y * height / 1000) * y + (start_y * height / 100))
        Dim _color = Color.FromArgb(0, 0, 0)
        Try
          bmp.SetPixel(px, py, _color)
        Catch ex As Exception

        End Try

        Dim r = Rnd() * 100
        Dim xn = x
        Dim yn = y
        If r < 1 Then
          x = 0
          y = 0.16 * yn
        ElseIf r < 86 Then
          x = 0.85 * xn + 0.04 * yn
          y = -0.04 * xn + 0.85 * yn + 1.6
        ElseIf r < 93 Then
          x = 0.2 * xn - 0.26 * yn
          y = 0.23 * xn + 0.22 * yn + 1.6
        Else
          x = -0.15 * xn + 0.28 * yn
          y = 0.26 * xn + 0.24 * yn + 0.44
        End If
      Next
      Dim file_name = barnsley_fern_config.output_file.Replace(".png", ".black.png")
      bmp.Save(Path.Combine(barnsley_fern_config.output_directory, file_name), Imaging.ImageFormat.Png)
      items.Add(file_name)
    End If
  End Sub
End Module
