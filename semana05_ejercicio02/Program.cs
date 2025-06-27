 // Escribir un programa que pida al usuario una palabra y muestre por pantalla si es un palíndromo.
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // se pide al usuario una palabra
        Console.Write("Introduce una palabra: ");
        string palabra = Console.ReadLine();

        // se apila cada carácter 
        var pila = new Stack<char>();
        foreach (char c in palabra)
            pila.Push(char.ToLower(c));

        // se desapila para construir la palabra inversa
        string inversa = "";
        while (pila.Count > 0)
            inversa += pila.Pop();

        // 4. Compara y muestra el resultado
        if (palabra.ToLower() == inversa)
            Console.WriteLine("Es un palindromo.");
        else
            Console.WriteLine("No es un palindromo.");
    }
}