using System;
using System.Collections.Generic;

namespace VacunacionCovid19
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crea un conjunto de 500 ciudadanos
            HashSet<string> ciudadanos = new HashSet<string>();
            for (int i = 1; i <= 500; i++)
            {
                ciudadanos.Add($"Ciudadano {i}"); // Agrega ciudadanos al conjunto
            }

            // Crea un conjunto de 75 ciudadanos vacunados con Pfizer
            HashSet<string> vacunadosPfizer = new HashSet<string>();
            for (int i = 1; i <= 75; i++)
            {
                vacunadosPfizer.Add($"Ciudadano {i}"); // Agrega ciudadanos al conjunto de Pfizer
            }

            // Crea un conjunto de 75 ciudadanos vacunados con AstraZeneca
            HashSet<string> vacunadosAstraZeneca = new HashSet<string>();
            for (int i = 76; i <= 150; i++)
            {
                vacunadosAstraZeneca.Add($"Ciudadano {i}"); // Agrega ciudadanos al conjunto de AstraZeneca
            }

            // Ciudadanos que no se han vacunado
            HashSet<string> noVacunados = new HashSet<string>(ciudadanos); // para copiar a todos los ciudadanos
            noVacunados.ExceptWith(vacunadosPfizer); // para eliminar ciudadanos vacunados con Pfizer
            noVacunados.ExceptWith(vacunadosAstraZeneca); //para eliminar ciudadanos vacunados con AstraZeneca

            // Ciudadanos que han recibido ambas dosis
            HashSet<string> vacunadosAmbasDosis = new HashSet<string>(vacunadosPfizer); 
            vacunadosAmbasDosis.IntersectWith(vacunadosAstraZeneca); // Retiene solo a los ciudadanos también vacunados con AstraZeneca

            // Ciudadanos que solo han recibido la vacuna de Pfizer
            HashSet<string> soloPfizer = new HashSet<string>(vacunadosPfizer); 
            soloPfizer.ExceptWith(vacunadosAstraZeneca); // Elimina a los ciudadanos también vacunados con AstraZeneca

            // Ciudadanos que solo han recibido la vacuna de AstraZeneca
            HashSet<string> soloAstraZeneca = new HashSet<string>(vacunadosAstraZeneca); // Copia a los ciudadanos vacunados con AstraZeneca
            soloAstraZeneca.ExceptWith(vacunadosPfizer); // Elimina a los ciudadanos también vacunados con Pfizer

            // Menú para consultar listados
            while (true)
            {
                Console.Clear(); // limpia la consola
                Console.WriteLine("Menú de Consulta de Vacunación");
                Console.WriteLine("1. Ciudadanos que no se han vacunado");
                Console.WriteLine("2. Ciudadanos que han recibido ambas dosis");
                Console.WriteLine("3. Ciudadanos que solo han recibido la vacuna de Pfizer");
                Console.WriteLine("4. Ciudadanos que solo han recibido la vacuna de AstraZeneca");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine(); // Lee la opción seleccionada por el usuario

                switch (opcion)
                {
                    case "1":
                        Console.Clear(); // Limpia la consola
                        Console.WriteLine("Ciudadanos que no se han vacunado:");
                        foreach (var ciudadano in noVacunados)
                        {
                            Console.WriteLine(ciudadano); // Muestra cada ciudadano que no se ha vacunado
                        }
                        Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
                        Console.ReadKey(); // Espera a que el usuario presione una tecla
                        break;

                    case "2":
                        Console.Clear(); 
                        Console.WriteLine("Ciudadanos que han recibido ambas dosis:");
                        foreach (var ciudadano in vacunadosAmbasDosis)
                        {
                            Console.WriteLine(ciudadano); // Muestra a cada ciudadano que ha recibido ambas dosis
                        }
                        Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
                        Console.ReadKey(); 
                        break;

                    case "3":
                        Console.Clear(); 
                        Console.WriteLine("Ciudadanos que solo han recibido la vacuna de Pfizer:");
                        foreach (var ciudadano in soloPfizer)
                        {
                            Console.WriteLine(ciudadano); // muestra a cada ciudadano que solo ha recibido Pfizer
                        }
                        Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
                        Console.ReadKey(); 
                        break;

                    case "4":
                        Console.Clear(); 
                        Console.WriteLine("Ciudadanos que solo han recibido la vacuna de AstraZeneca:");
                        foreach (var ciudadano in soloAstraZeneca)
                        {
                            Console.WriteLine(ciudadano); // Muestra a cada ciudadano que solo ha recibido AstraZeneca
                        }
                        Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
                        Console.ReadKey(); 
                        break;

                    case "5":
                        return; // Sale del programa

                    default:
                        Console.Clear(); 
                        Console.WriteLine("Opción inválida. Presione cualquier tecla para intentar nuevamente...");
                        Console.ReadKey(); 
                        break;
                }
            }
        }
    }
}