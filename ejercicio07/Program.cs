using System;
using System.Collections.Generic;

class Estudiante
{
    public string Codigo { get; set; }
    public string Nombre { get; set; }
    public string Correo { get; set; }
    public string Edad { get; set; }
    public string Direccion { get; set; }
    public double NotaQuices { get; set; }
    public double NotaTrabajos { get; set; }
    public double NotaParciales { get; set; }

    public Estudiante(string codigo, string nombre, string correo, string edad, string direccion)
    {
        Codigo = codigo;
        Nombre = nombre;
        Correo = correo;
        Edad = edad;
        Direccion = direccion;
        NotaQuices = 0;
        NotaTrabajos = 0;
        NotaParciales = 0;
    }

    public double CalcularNotaFinal()
    {
        // Calcular la nota final según el porcentaje dado.
        return (NotaQuices * 0.25) + (NotaTrabajos * 0.15) + (NotaParciales * 0.6);
    }
}

class Program
{
    static List<Estudiante> estudiantes = new List<Estudiante>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Menú:");
            Console.WriteLine("1. Registrar estudiante");
            Console.WriteLine("2. Ingresar notas");
            Console.WriteLine("3. Generar listado general de notas");
            Console.WriteLine("4. Generar paginado de 10 estudiantes");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    RegistrarEstudiante();
                    break;
                case "2":
                    IngresarNotas();
                    break;
                case "3":
                    GenerarListadoGeneral();
                    break;
                case "4":
                    GenerarPaginado();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intente nuevamente.");
                    break;
            }
        }
    }

    static void RegistrarEstudiante()
    {
        Console.WriteLine("Ingrese los datos del estudiante:");
        Console.Write("Código: ");
        string codigo = Console.ReadLine();
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Correo: ");
        string correo = Console.ReadLine();
        Console.Write("Edad: ");
        string edad = Console.ReadLine();
        Console.Write("Dirección: ");
        string direccion = Console.ReadLine();

        Estudiante estudiante = new Estudiante(codigo, nombre, correo, edad, direccion);
        estudiantes.Add(estudiante);

        Console.WriteLine("Estudiante registrado exitosamente.");
    }

    static void IngresarNotas()
    {
        Console.Write("Ingrese el código del estudiante: ");
        string codigo = Console.ReadLine();

        Estudiante estudiante = estudiantes.Find(e => e.Codigo == codigo);

        if (estudiante != null)
        {
            Console.Write("Nota de quices: ");
            estudiante.NotaQuices = Convert.ToDouble(Console.ReadLine());
            Console.Write("Nota de trabajos: ");
            estudiante.NotaTrabajos = Convert.ToDouble(Console.ReadLine());
            Console.Write("Nota de parciales: ");
            estudiante.NotaParciales = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Notas ingresadas exitosamente.");
        }
        else
        {
            Console.WriteLine("Estudiante no encontrado.");
        }
    }

    static void GenerarListadoGeneral()
    {
        Console.WriteLine("Listado General de Notas:");
        foreach (Estudiante estudiante in estudiantes)
        {
            Console.WriteLine($"Código: {estudiante.Codigo}");
            Console.WriteLine($"Nombre: {estudiante.Nombre}");
            Console.WriteLine($"Correo: {estudiante.Correo}");
            Console.WriteLine($"Edad: {estudiante.Edad}");
            Console.WriteLine($"Dirección: {estudiante.Direccion}");
            Console.WriteLine($"Nota Final: {estudiante.CalcularNotaFinal():F2}");
            Console.WriteLine();
        }
    }

    static void GenerarPaginado()
    {
        Console.WriteLine("Generar Paginado de 10 Estudiantes:");

        for (int i = 0; i < estudiantes.Count; i += 10)
        {
            Console.WriteLine("Página " + (i / 10 + 1));
            for (int j = i; j < Math.Min(i + 10, estudiantes.Count); j++)
            {
                Console.WriteLine($"Código: {estudiantes[j].Codigo}");
                Console.WriteLine($"Nombre: {estudiantes[j].Nombre}");
                Console.WriteLine($"Nota Final: {estudiantes[j].CalcularNotaFinal():F2}");
                Console.WriteLine();
            }

            Console.WriteLine("Presione Enter para continuar...");
            Console.ReadLine();
        }
    }
}
