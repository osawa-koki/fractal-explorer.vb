Imports System.Drawing
Imports System.IO

Public Class Type_RecursiveTree_temp_object
  Public X As Integer
  Public Y As Integer
  Public Degree As Integer
End Class

Module RecursiveTree

  Dim width As Integer
  Dim height As Integer
  Dim shrink As Double
  Dim length As Double
  Dim degree As Integer
  Dim max_iterations As Integer

  Sub RecDraw(bmp As Bitmap, x As Integer, y As Integer, current_degree As Integer, n As Integer, pen As Pen)
    If max_iterations < n Then
      Return
    End If

    Dim current_length As Double = shrink ^ n * (width + height) / 2 * length
    Dim moved As New List(Of Type_RecursiveTree_temp_object)

    ' 右側
    If True Then
      Dim current_degree_right As Integer = (360 + current_degree - degree) Mod 360
      Dim moved_x As Integer = x + Math.Cos(current_degree_right * Math.PI / 180) * current_length
      Dim moved_y As Integer
      If current_degree_right = 90 Then
        moved_y = y - current_length
      ElseIf current_degree_right = 270 Then
        moved_y = y + current_length
      Else
        moved_y = y + Math.Tan(current_degree_right * Math.PI / 180) * (x - moved_x)
      End If
      Dim obj As New Type_RecursiveTree_temp_object With {
        .X = moved_x,
        .Y = moved_y,
        .Degree = current_degree_right
      }
      moved.Add(obj)
    End If

    ' 左側
    If True Then
      Dim current_degree_left As Integer = (360 + current_degree + degree) Mod 360
      Dim moved_x As Integer = x + Math.Cos(current_degree_left * Math.PI / 180) * current_length
      Dim moved_y As Integer
      If current_degree_left = 90 Then
        moved_y = y - current_length
      ElseIf current_degree_left = 270 Then
        moved_y = y + current_length
      Else
        moved_y = y + Math.Tan(current_degree_left * Math.PI / 180) * (x - moved_x)
      End If
      Dim obj As New Type_RecursiveTree_temp_object With {
        .X = moved_x,
        .Y = moved_y,
        .Degree = current_degree_left
      }
      moved.Add(obj)
    End If

    For Each m As Object In moved
      Dim g As Graphics = Graphics.FromImage(bmp)
      g.DrawLine(pen, x, y, m.X, m.Y)
      g.Dispose()
      RecDraw(bmp, m.X, m.Y, m.Degree, n + 1, pen)
    Next
  End Sub

  Sub Draw(recursive_tree_config As IRecursiveTree, items As List(Of String))
    width = recursive_tree_config.width
    height = recursive_tree_config.height

    shrink = recursive_tree_config.shrink / 100.0
    length = recursive_tree_config.length / 100.0
    degree = recursive_tree_config.degree
    max_iterations = recursive_tree_config.max_iterations

    If True Then
      Dim bmp As New Bitmap(width, height)
      Dim graphics As Graphics = Graphics.FromImage(bmp)
      graphics.FillRectangle(Brushes.Black, 0, 0, width, height)

      graphics.DrawLine(Pens.White, CInt(width / 2), CInt(height), CInt(width / 2), CInt(height - height * length))

      RecDraw(bmp, CInt(width / 2), CInt(height - height * length), 90, 0, Pens.White)

      Dim file_name = recursive_tree_config.output_file.Replace(".png", ".white.png")
      bmp.Save(Path.Combine(recursive_tree_config.output_directory, file_name), Imaging.ImageFormat.Png)
      items.Add(file_name)
    End If

    If True Then
      Dim bmp As New Bitmap(width, height)
      Dim graphics As Graphics = Graphics.FromImage(bmp)
      graphics.FillRectangle(Brushes.White, 0, 0, width, height)

      graphics.DrawLine(Pens.Black, CInt(width / 2), CInt(height), CInt(width / 2), CInt(height - height * length))

      RecDraw(bmp, CInt(width / 2), CInt(height - height * length), 90, 0, Pens.Black)

      Dim file_name = recursive_tree_config.output_file.Replace(".png", ".black.png")
      bmp.Save(Path.Combine(recursive_tree_config.output_directory, file_name), Imaging.ImageFormat.Png)
      items.Add(file_name)
    End If
  End Sub
End Module
