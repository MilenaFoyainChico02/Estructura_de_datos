using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Inicializa el diccionario con palabras base
        Dictionary<string, string> dictionary = new Dictionary<string, string>
        {
            { "tiempo", "time" },
            { "persona", "person" },
            { "año", "year" },
            { "bueno", "good" },
            { "día", "day" },
            { "cosa", "thing" },
            { "hombre", "man" },
            { "mundo", "world" },
            { "vida", "life" },
            { "mano", "hand" },
            { "parte", "part" },
            { "ojo", "eye" },
            { "mujer", "woman" },
            { "lugar", "place" },
            { "trabajo", "work" },
            { "semana", "week" },
            { "caso", "case" },
            { "dios", "god" },
            { "gobierno", "government" },
            { "posible", "possible" }
        };

        int option;

        do
        {
            // muestra el menú interactivo
            Console.WriteLine("==================== MENÚ ====================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            // Lee y valida la opción del usuario
            while (!int.TryParse(Console.ReadLine(), out option) || (option < 0 || option > 2))
            {
                Console.Write("Opción no válida. Seleccione una opción: ");
            }

            // Ejecuta la opción seleccionada
            switch (option)
            {
                case 1:
                    TranslateSentence(dictionary);
                    break;
                case 2:
                    AddWordsToDictionary(dictionary);
                    break;
                case 0:
                    Console.WriteLine("Saliendo del programa...");
                    break;
            }
        } while (option != 0);
    }

    /// <summary>
    /// Función para traducir una frase utilizando el diccionario proporcionado.
    /// </summary>
    /// <param name="dictionary">Diccionario que contiene las palabras y sus traducciones.</param>
    static void TranslateSentence(Dictionary<string, string> dictionary)
    {
        // Pide al usuario que ingrese una frase
        Console.Write("Ingrese una frase: ");
        string sentence = Console.ReadLine();

        // Divide la frase en palabras, ignorando signos de puntuación
        string[] words = sentence.Split(new char[] { ' ', ',', '.', '?', '!', ';' }, StringSplitOptions.RemoveEmptyEntries);

        // Lista para almacenar las palabras traducidas
        List<string> translatedWords = new List<string>();

        // Itera sobre cada palabra en la frase
        foreach (string word in words)
        {
            // Convierte la palabra a minúsculas para comparar con las claves del diccionario
            string lowerWord = word.ToLower();

            // Verificar si la palabra está en el diccionario
            if (dictionary.ContainsKey(lowerWord))
            {
                // Si está, agregar la traducción a la lista
                translatedWords.Add(dictionary[lowerWord]);
            }
            else
            {
                // Si no está, agregar la palabra original a la lista
                translatedWords.Add(word);
            }
        }

        // Une las palabras traducidas en una sola frase
        string translatedSentence = string.Join(" ", translatedWords);

        // muestra la frase traducida
        Console.WriteLine("Traducción: " + translatedSentence);
    }

    static void AddWordsToDictionary(Dictionary<string, string> dictionary)
    {
        // Pide al usuario que ingrese la palabra en inglés
        Console.Write("Ingrese la palabra en inglés: ");
        string englishWord = Console.ReadLine().ToLower();

        // Verifica si la palabra ya existe en el diccionario
        if (dictionary.ContainsKey(englishWord))
        {
            // Si la palabra ya existe, muestra un mensaje
            Console.WriteLine("La palabra ya existe en el diccionario.");
        }
        else
        {
            // Si la palabra no existe, pedir la traducción en español
            Console.Write("Ingrese la traducción al español: ");
            string spanishWord = Console.ReadLine().ToLower();

            // Agrega la nueva palabra y su traducción al diccionario
            dictionary.Add(englishWord, spanishWord);

            // muestra un mensaje de confirmación
            Console.WriteLine("Palabra agregada al diccionario.");
        }
    }
}