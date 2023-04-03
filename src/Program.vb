Imports System.IO
Imports fractal_explorer.My

Module Program
  Sub Main()
    Dim width = Integer.Parse(Resources.global_width)
    Dim height = Integer.Parse(Resources.global_height)
    Dim output_directory = Resources.global_output_directory

    Directory.CreateDirectory(output_directory)

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

#If DEBUG Then
    Console.ReadKey()
#End If
  End Sub

End Module
