using System;
using System.Collections.Generic;

// Clase para representar una revista con sus propiedades
public class Revista
{
    public string Titulo { get; set; }
    public string Editorial { get; set; }
    public int Anio { get; set; }

    // constructor de la clase Revista
    public Revista(string titulo, string editorial, int anio)
    {
        Titulo = titulo;
        Editorial = editorial;
        Anio = anio;
    }

    // método para mostrar información de la revista
    public override string ToString()
    {
        return $"{Titulo} - {Editorial} ({Anio})";
    }
}

// clase principal que contiene la lógica de la aplicación
public class CatalogoRevistas
{
    // Lista para almacenar las revistas del catálogo
    private List<Revista> catalogo;
    
    // Constructor que inicializa el catálogo y agrega revistas de ejemplo
    public CatalogoRevistas()
    {
        catalogo = new List<Revista>();
        InicializarCatalogo();
    }

    // Método para inicializar el catálogo con 10 revistas de ejemplo
    private void InicializarCatalogo()
    {
        catalogo.Add(new Revista("National Geographic", "National Geographic Society", 2023));
        catalogo.Add(new Revista("Time Magazine", "Time Inc.", 2023));
        catalogo.Add(new Revista("Scientific American", "Springer Nature", 2023));
        catalogo.Add(new Revista("The Economist", "The Economist Newspaper", 2023));
        catalogo.Add(new Revista("Wired", "Condé Nast", 2023));
        catalogo.Add(new Revista("Forbes", "Forbes Media", 2023));
        catalogo.Add(new Revista("Nature", "Nature Publishing Group", 2023));
        catalogo.Add(new Revista("Science", "American Association for the Advancement of Science", 2023));
        catalogo.Add(new Revista("National Review", "Touchstone", 2023));
        catalogo.Add(new Revista("The Atlantic", "The Atlantic Monthly Group", 2023));
    }

    // Método iterativo para buscar una revista por título
    // Recorre la lista de revistas y compara cada título con el buscado
    public bool BuscarRevistaIterativa(string tituloBuscado)
    {
        // Recorremos cada revista en el catálogo
        foreach (Revista revista in catalogo)
        {
            // Comparamos el título buscado con el título actual (sin distinguir mayúsculas/minúsculas)
            if (revista.Titulo.Equals(tituloBuscado, StringComparison.OrdinalIgnoreCase))
            {
                return true; // Si encontramos coincidencia, retornamos verdadero
            }
        }
        return false; // Si no encontramos coincidencia, retornamos falso
    }

    // Método recursivo para buscar una revista por título
    // Utiliza un índice para recorrer la lista de forma recursiva
    public bool BuscarRevistaRecursiva(string tituloBuscado, int indice = 0)
    {
        // Caso base: si hemos revisado todas las revistas sin encontrar coincidencia
        if (indice >= catalogo.Count)
        {
            return false;
        }

        // Caso recursivo: comparamos el título actual con el buscado
        if (catalogo[indice].Titulo.Equals(tituloBuscado, StringComparison.OrdinalIgnoreCase))
        {
            return true; // Si encontramos coincidencia, retornamos verdadero
        }

        // Llamada recursiva para revisar la siguiente revista
        return BuscarRevistaRecursiva(tituloBuscado, indice + 1);
    }

    // Método para mostrar todas las revistas del catálogo
    public void MostrarCatalogo()
    {
        Console.WriteLine("\n=== CATÁLOGO DE REVISTAS ===");
        for (int i = 0; i < catalogo.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {catalogo[i]}");
        }
        Console.WriteLine("==========================\n");
    }

    // Método para ejecutar la búsqueda y mostrar resultados
    public void RealizarBusqueda()
    {
        Console.Write("Ingrese el título de la revista a buscar: ");
        string tituloBuscado = Console.ReadLine();

        // Verificamos si se ingresó un título válido
        if (string.IsNullOrWhiteSpace(tituloBuscado))
        {
            Console.WriteLine("Por favor ingrese un título válido.");
            return;
        }

        // Opción de tipo de búsqueda (iterativa o recursiva)
        Console.WriteLine("\nSeleccione el tipo de búsqueda:");
        Console.WriteLine("1. Búsqueda Iterativa");
        Console.WriteLine("2. Búsqueda Recursiva");
        Console.Write("Ingrese opción (1 o 2): ");
        
        string opcion = Console.ReadLine();
        
        bool encontrado;
        
        // ejecutamos la búsqueda según la opción seleccionada
        switch (opcion)
        {
            case "1":
                encontrado = BuscarRevistaIterativa(tituloBuscado);
                break;
            case "2":
                encontrado = BuscarRevistaRecursiva(tituloBuscado);
                break;
            default:
                Console.WriteLine("Opción inválida. Se realizará búsqueda iterativa por defecto.");
                encontrado = BuscarRevistaIterativa(tituloBuscado);
                break;
        }

        // Mostramos el resultado de la búsqueda
        if (encontrado)
        {
            Console.WriteLine("\nRESULTADO: Encontrado");
        }
        else
        {
            Console.WriteLine("\nRESULTADO: No encontrado");
        }
    }
}

// Clase principal del programa
class Program
{
    static void Main(string[] args)
    {
        // Creamos una instancia del catálogo de revistas
        CatalogoRevistas catalogo = new CatalogoRevistas();
        
        // Variable para controlar el menú
        bool continuar = true;
        
        // Mensaje de bienvenida
        Console.WriteLine("Bienvenido al Sistema de Catálogo de Revistas");
        Console.WriteLine("=============================================\n");

        // Ciclo principal del menú interactivo
        while (continuar)
        {
            // Mostramos el menú de opciones
            Console.WriteLine("=== MENÚ PRINCIPAL ===");
            Console.WriteLine("1. Buscar revista");
            Console.WriteLine("2. Mostrar catálogo completo");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");
            
            // Leemos la opción del usuario
            string opcion = Console.ReadLine();
            
            // Procesamos la opción seleccionada
            switch (opcion)
            {
                case "1":
                    // Llamamos al método para realizar búsqueda
                    catalogo.RealizarBusqueda();
                    break;
                case "2":
                    // Mostramos el catálogo completo
                    catalogo.MostrarCatalogo();
                    break;
                case "3":
                    // Salimos del programa
                    Console.WriteLine("Gracias por usar el sistema. ¡Hasta luego!");
                    continuar = false;
                    break;
                default:
                    // Manejo de opción inválida
                    Console.WriteLine("Opción inválida. Por favor seleccione una opción válida.");
                    break;
            }
            
            // Si no se selecciona salir, esperamos una tecla antes de continuar
            if (continuar)
            {
                Console.WriteLine("\nPresione cualquier tecla para continuar...");
                Console.ReadKey();
                Console.Clear(); // Limpiamos la pantalla para mejor presentación
            }
        }
    }
}