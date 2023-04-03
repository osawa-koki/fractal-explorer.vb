Imports System.IO
Imports fractal_explorer.My

Module Program
  Sub Main()
    Dim width = Integer.Parse(Resources.global_width)
    Dim height = Integer.Parse(Resources.global_height)
    Dim output_directory = Resources.global_output_directory

    Dim items = New List(Of String)
    Directory.CreateDirectory(output_directory)

    Dim mandelbrot_config As IMandelbrot = New IMandelbrot With {
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
    Mandelbrot.Draw(mandelbrot_config)
    items.Add(Resources.mandelbrot_output_file)

    Dim julia_config As IJulia = New IJulia With {
      .width = width,
      .height = height,
      .x_min = Double.Parse(Resources.julia_x_min),
      .x_max = Double.Parse(Resources.julia_x_max),
      .y_min = Double.Parse(Resources.julia_y_min),
      .y_max = Double.Parse(Resources.julia_y_max),
      .c_re = Double.Parse(Resources.julia_c_re),
      .c_im = Double.Parse(Resources.julia_c_im),
      .threshold = Integer.Parse(Resources.julia_threshold),
      .max_iterations = Integer.Parse(Resources.julia_max_iterations),
      .output_file = Path.Combine(output_directory, Resources.julia_output_file)
    }
    Julia.Draw(julia_config)
    items.Add(Resources.julia_output_file)

    Dim tricorn_config As ITricorn = New ITricorn With {
      .width = width,
      .height = height,
      .x_min = Double.Parse(Resources.tricorn_x_min),
      .x_max = Double.Parse(Resources.tricorn_x_max),
      .y_min = Double.Parse(Resources.tricorn_y_min),
      .y_max = Double.Parse(Resources.tricorn_y_max),
      .threshold = Integer.Parse(Resources.tricorn_threshold),
      .max_iterations = Integer.Parse(Resources.tricorn_max_iterations),
      .output_file = Path.Combine(output_directory, Resources.tricorn_output_file)
    }
    Tricorn.Draw(tricorn_config)
    items.Add(Resources.tricorn_output_file)

    Using sw As New StreamWriter(Path.Combine(output_directory, Resources.global_artifact_filename), True)
      sw.WriteLine(String.Join(vbCrLf, items.ToArray()))
    End Using

#If DEBUG Then
    Console.ReadKey()
#End If
  End Sub

End Module
