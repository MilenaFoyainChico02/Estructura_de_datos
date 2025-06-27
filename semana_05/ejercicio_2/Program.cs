// Escribir un programa que pida al usuario una palabra y muestre por pantalla el número de veces que contiene cada vocal.
class VowelCounter
{
    // Diccionario para almacenar el conteo de cada vocal
    public System.Collections.Generic.Dictionary<char, int> Counts { get; private set; }

    private string text;

    public VowelCounter(string text)
    {
        this.text = text;
        Counts = new System.Collections.Generic.Dictionary<char, int>
        {
            { 'a', 0 },
            { 'e', 0 },
            { 'i', 0 },
            { 'o', 0 },
            { 'u', 0 }
        };
    }

    // Recorre el texto y aumenta el conteo de cada vocal encontrada
    public void Count()
    {
        foreach (char c in text)
        {
            char lower = char.ToLower(c);
            if (Counts.ContainsKey(lower))
                Counts[lower]++;
        }
    }
}

class Program
{
    static void Main()
    {
        // Pide al usuario una palabra o frase
        System.Console.Write("Introduce una palabra o frase: ");
        string input = System.Console.ReadLine();

        // 2. Contamos las vocales
        var counter = new VowelCounter(input);
        counter.Count();

        // Muestra el resultado
        System.Console.WriteLine("\nNumero de veces que aparece cada vocal:");
        foreach (var kvp in counter.Counts)
        {
            System.Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }
}
