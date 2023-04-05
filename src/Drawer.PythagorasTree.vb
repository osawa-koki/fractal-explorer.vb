Imports System.Drawing
Imports System.IO

Module PythagorasTree

  Dim width As Integer
  Dim height As Integer
  Dim size As Integer
  Dim degree As Integer
  Dim max_iterations As Integer
  Dim left As Integer
  Dim bottom As Integer

  Function GetLeftPoints(x As Integer, y As Integer, size As Integer, current_degree As Integer) As List(Of Point)
    Dim points As New List(Of Point) From {
      New Point(x, y),
      New Point(x + Math.Cos((current_degree + degree) * Math.PI / 180) * size, y - Math.Sin((current_degree + degree) * Math.PI / 180) * size),
      New Point(x + Math.Cos((current_degree + degree + 45) * Math.PI / 180) * size * Math.Sqrt(2), y - Math.Sin((current_degree + degree + 45) * Math.PI / 180) * size * Math.Sqrt(2)),
      New Point(x + Math.Cos((current_degree + degree + 90) * Math.PI / 180) * size, y - Math.Sin((current_degree + degree + 90) * Math.PI / 180) * size)
    }
    Return points
  End Function

  Function GetRightPoints(x As Integer, y As Integer, size As Integer, current_degree As Integer) As List(Of Point)
    Dim points As New List(Of Point) From {
      New Point(x, y),
      New Point(x + Math.Cos((current_degree + degree) * Math.PI / 180) * size, y - Math.Sin((current_degree + degree) * Math.PI / 180) * size),
      New Point(x + Math.Cos((current_degree + degree + 45) * Math.PI / 180) * size * Math.Sqrt(2), y - Math.Sin((current_degree + degree + 45) * Math.PI / 180) * size * Math.Sqrt(2)),
      New Point(x + Math.Cos((current_degree + degree + 90) * Math.PI / 180) * size, y - Math.Sin((current_degree + degree + 90) * Math.PI / 180) * size)
    }
    Return points
  End Function

  Sub RecursiveDraw(graphics As Graphics, p1 As Point, p2 As Point, size As Integer, current_degree As Integer, n As Integer, i As Integer, is_white As Boolean)
    If n = 0 Then
      Return
    End If

    Dim color_power As Integer
    If is_white Then
      color_power = 255 - 255 / max_iterations * i
    Else
      color_power = 255 / max_iterations * i
    End If
    Dim _color = New SolidBrush(Color.FromArgb(color_power, color_power, color_power))

    ' 左側
    If True Then
      Dim smalled_size = Math.Cos(degree * Math.PI / 180) * size
      Dim points_left = GetLeftPoints(p1.X, p1.Y, smalled_size, current_degree)
      graphics.FillPolygon(_color, points_left.ToArray())
      RecursiveDraw(
        graphics,
        New Point(points_left(3).X, points_left(3).Y),
        New Point(points_left(2).X, points_left(2).Y),
        smalled_size,
        current_degree + degree,
        n - 1,
        i + 1,
        is_white
      )
    End If

    ' 右側
    If True Then
      Dim smalled_size = Math.Sin(degree * Math.PI / 180) * size
      Dim points_right = GetRightPoints(p2.X, p2.Y, smalled_size, current_degree)
      graphics.FillPolygon(_color, points_right.ToArray())
      RecursiveDraw(
        graphics,
        New Point(points_right(2).X, points_right(2).Y),
        New Point(points_right(1).X, points_right(1).Y),
        smalled_size,
        current_degree - (90 - degree),
        n - 1,
        i + 1,
        is_white
      )
    End If
  End Sub

  Sub Draw(pythagoras_tree_config As IPythagorasTree, items As List(Of String))
    width = pythagoras_tree_config.width
    height = pythagoras_tree_config.height

    size = pythagoras_tree_config.size
    degree = pythagoras_tree_config.degree
    max_iterations = pythagoras_tree_config.max_iterations
    left = pythagoras_tree_config.left
    bottom = pythagoras_tree_config.bottom

    Dim box_size = (width + height) / 2 * size / 100
    Dim left_size = width * left / 100
    Dim bottom_size = height * bottom / 100

    If True Then
      Dim bmp As New Bitmap(width, height)
      Dim graphics As Graphics = Graphics.FromImage(bmp)
      graphics.FillRectangle(Brushes.Black, 0, 0, width, height)

      graphics.FillRectangle(Brushes.White, CInt(left_size + box_size / 2), CInt(height - bottom_size - box_size), CInt(box_size), CInt(box_size))

      RecursiveDraw(
        graphics,
        New Point(CInt(left_size + box_size / 2), CInt(height - bottom_size - box_size)),
        New Point(CInt(left_size + box_size / 2 + box_size), CInt(height - bottom_size - box_size)),
        box_size,
        0,
        max_iterations,
        1,
        True
      )
      Dim file_name = pythagoras_tree_config.output_file.Replace(".png", ".white.png")
      bmp.Save(Path.Combine(pythagoras_tree_config.output_directory, file_name), Imaging.ImageFormat.Png)
      items.Add(file_name)
    End If

    If True Then
      Dim bmp As New Bitmap(width, height)
      Dim graphics As Graphics = Graphics.FromImage(bmp)
      graphics.FillRectangle(Brushes.White, 0, 0, width, height)

      graphics.FillRectangle(Brushes.Black, CInt(left_size + box_size / 2), CInt(height - bottom_size - box_size), CInt(box_size), CInt(box_size))

      RecursiveDraw(
        graphics,
        New Point(CInt(left_size + box_size / 2), CInt(height - bottom_size - box_size)),
        New Point(CInt(left_size + box_size / 2 + box_size), CInt(height - bottom_size - box_size)),
        box_size,
        0,
        max_iterations,
        1,
        False
      )
      Dim file_name = pythagoras_tree_config.output_file.Replace(".png", ".black.png")
      bmp.Save(Path.Combine(pythagoras_tree_config.output_directory, file_name), Imaging.ImageFormat.Png)
      items.Add(file_name)
    End If

  End Sub
End Module
