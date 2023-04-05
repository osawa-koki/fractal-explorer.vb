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
      .output_directory = Resources.global_output_directory,
      .output_file = Resources.mandelbrot_output_file
    }
    Mandelbrot.Draw(mandelbrot_config, items)

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
      .output_directory = Resources.global_output_directory,
      .output_file = Resources.julia_output_file
    }
    Julia.Draw(julia_config, items)

    Dim tricorn_config As ITricorn = New ITricorn With {
      .width = width,
      .height = height,
      .x_min = Double.Parse(Resources.tricorn_x_min),
      .x_max = Double.Parse(Resources.tricorn_x_max),
      .y_min = Double.Parse(Resources.tricorn_y_min),
      .y_max = Double.Parse(Resources.tricorn_y_max),
      .threshold = Integer.Parse(Resources.tricorn_threshold),
      .max_iterations = Integer.Parse(Resources.tricorn_max_iterations),
      .output_directory = Resources.global_output_directory,
      .output_file = Resources.tricorn_output_file
    }
    Tricorn.Draw(tricorn_config, items)

    Dim burning_ship_config As IBurningShip = New IBurningShip With {
      .width = width,
      .height = height,
      .x_min = Double.Parse(Resources.burning_ship_x_min),
      .x_max = Double.Parse(Resources.burning_ship_x_max),
      .y_min = Double.Parse(Resources.burning_ship_y_min),
      .y_max = Double.Parse(Resources.burning_ship_y_max),
      .threshold = Integer.Parse(Resources.burning_ship_threshold),
      .max_iterations = Integer.Parse(Resources.burning_ship_max_iterations),
      .output_directory = Resources.global_output_directory,
      .output_file = Resources.burning_ship_output_file
    }
    BurningShip.Draw(burning_ship_config, items)

    Dim barnsley_fern_config As IBarnsleyFern = New IBarnsleyFern With {
      .width = width,
      .height = height,
      .size_x = Double.Parse(Resources.barnsley_fern_size_x),
      .size_y = Double.Parse(Resources.barnsley_fern_size_y),
      .start_x = Double.Parse(Resources.barnsley_fern_start_x),
      .start_y = Double.Parse(Resources.barnsley_fern_start_y),
      .zoom = Integer.Parse(Resources.barnsley_fern_zoom),
      .max_iterations = Integer.Parse(Resources.barnsley_fern_max_iterations),
      .output_directory = Resources.global_output_directory,
      .output_file = Resources.barnsley_fern_output_file
    }
    BarnsleyFern.Draw(barnsley_fern_config, items)

    Dim recursive_tree_config As IRecursiveTree = New IRecursiveTree With {
      .width = width,
      .height = height,
      .shrink = Integer.Parse(Resources.recursive_tree_shrink),
      .length = Integer.Parse(Resources.recursive_tree_length),
      .degree = Integer.Parse(Resources.recursive_tree_degree),
      .max_iterations = Integer.Parse(Resources.recursive_tree_max_iterations),
      .output_directory = Resources.global_output_directory,
      .output_file = Resources.recursive_tree_output_file
    }
    RecursiveTree.Draw(recursive_tree_config, items)

    Dim pythagoras_tree_config As IPythagorasTree = New IPythagorasTree With {
      .width = width,
      .height = height,
      .size = Integer.Parse(Resources.pythagoras_tree_size),
      .degree = Integer.Parse(Resources.pythagoras_tree_degree),
      .max_iterations = Integer.Parse(Resources.pythagoras_tree_max_iterations),
      .Left = Integer.Parse(Resources.pythagoras_tree_left),
      .bottom = Integer.Parse(Resources.pythagoras_tree_bottom),
      .output_directory = Resources.global_output_directory,
      .output_file = Resources.pythagoras_tree_output_file
    }
    PythagorasTree.Draw(pythagoras_tree_config, items)

    Using sw As New StreamWriter(Path.Combine(output_directory, Resources.global_artifact_filename), True)
      sw.WriteLine(String.Join(vbCrLf, items.ToArray()))
    End Using

#If DEBUG Then
    Console.ReadKey()
#End If
  End Sub

End Module
