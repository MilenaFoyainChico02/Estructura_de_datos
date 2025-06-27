// Escribir un programa que pregunte por una muestra de números, separados por comas, los guarde en una tupla y muestre por pantalla su media y desviación típica.
using System;

class Program
{
    static void Main()
    {
        //  se pide al usuario la muestra de números separados por comas
        System.Console.Write("Introduce numeros separados por comas: ");
        string input = System.Console.ReadLine();

        //  entrada a un array de doubles
        string[] partes = input.Split(',');
        double[] numeros = new double[partes.Length];
        for (int i = 0; i < partes.Length; i++)
            numeros[i] = double.Parse(partes[i].Trim());

        // guarda el array en una tupla
        var muestra = Tuple.Create(numeros);

        // calcula la media
        double suma = 0;
        foreach (double x in muestra.Item1)
            suma += x;
        double media = suma / muestra.Item1.Length;

        // calcula la desviación típica 
        double sumaCuadrados = 0;
        foreach (double x in muestra.Item1)
            sumaCuadrados += (x - media) * (x - media);
        double desviacion = Math.Sqrt(sumaCuadrados / muestra.Item1.Length);

        // muestra el resultado
        System.Console.WriteLine($"\nMedia: {media}");
        System.Console.WriteLine($"Desviacion tipica: {desviacion}");
    }
}
