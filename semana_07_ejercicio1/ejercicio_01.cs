using System;
using System.Collections.Generic;

class Program
{
    // Comprueba que cantidad de aperturas
    static bool EstaBalanceada(string expr)
    {
        Stack<bool> pila = new Stack<bool>();

        foreach (char c in expr)
        {
            if (c == '(' || c == '{' || c == '[')
            {
                // Marca una apertura
                pila.Push(true);
            }
            else if (c == ')' || c == '}' || c == ']')
            {
                // Si no hay nada para cerrar, no está balanceada
                if (pila.Count == 0)
                    return false;
                // Quita la última apertura
                pila.Pop();
            }
        }
        // Si al final no quedan aperturas pendientes, está balanceada
        return pila.Count == 0;
    }

    static void Main()
    {
        while (true)
        {
            Console.Write("Ingresa una expresión (vacío para salir): ");
            string expresion = Console.ReadLine();
            if (string.IsNullOrEmpty(expresion))
                break;

            bool resultado = EstaBalanceada(expresion);
            Console.WriteLine(
                resultado 
                ? "Fórmula balanceada." 
                : "Fórmula NO balanceada."
            );
            Console.WriteLine();
        }
    }
}