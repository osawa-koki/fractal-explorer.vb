Imports System.IO
Imports fractal_explorer.My

Module Program
  Sub Main()
    Dim width = Integer.Parse(Resources.global_width)
    Dim height = Integer.Parse(Resources.global_height)
    Dim output_directory = Resources.global_output_directory

    Dim items = New List(Of String)

    Dim _mandelbrot As IMandelbrot = New IMandelbrot With {
      .width = width,
      .height = height,
      .x_min = Double.Parse(Resources.mandelbrot_x_min),
      .x_max = Double.Parse(Resources.mandelbrot_x_max),
      .y_min = Double.Parse(Resources.mandelbrot_y_min),
      .y_max = Double.Parse(Resources.mandelbrot_y_max),
      .threshold = Integer.Parse(Resources.mandelbrot_threshold),
      .max_iterations = Integer.Parse(Resources.mandelbrot_max_iterations),
      .output_file = Path.Combine(output_directory, Resources.mandelbrot_output_file)
    }
    Mandelbrot.Draw(_mandelbrot)
    items.Add(Resources.mandelbrot_output_file)

    Directory.CreateDirectory(output_directory)
    Using sw As New StreamWriter(Path.Combine(output_directory, "items.txt"), True)
      sw.WriteLine(String.Join(vbCrLf, items.ToArray()))
    End Using

#If DEBUG Then
    Console.ReadKey()
#End If
  End Sub

End Module
