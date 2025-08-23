using System;
using System.Collections.Generic;

class Program
{
    // Imprime el estado actual de las tres torres
    static void ImprimirTorres(Stack<int> A, Stack<int> B, Stack<int> C)
    {
        Console.WriteLine("Estado de torres:");
        Console.WriteLine($"A: [{string.Join(", ", A)}]");
        Console.WriteLine($"B: [{string.Join(", ", B)}]");
        Console.WriteLine($"C: [{string.Join(", ", C)}]");
        Console.WriteLine();
    }

    // Mueve n discos de origen a destino usando auxiliar
    static void MoverDiscos(int n,
                            Stack<int> origen, char nameO,
                            Stack<int> destino, char nameD,
                            Stack<int> auxiliar, char nameAux)
    {
        if (n <= 0) return;

         // mueve n-1 
        MoverDiscos(n - 1, origen, nameO, auxiliar, nameAux, destino, nameD);

        // mueve el disco restante de origen a destino
        int disco = origen.Pop();
        destino.Push(disco);
        Console.WriteLine($"Mover disco {disco} de {nameO} → {nameD}");

       // imprime el estado tras cada movimiento
        ImprimirTorres(origen, auxiliar, destino);

         // mueve los n-1 de auxiliar a destino
        MoverDiscos(n - 1, auxiliar, nameAux, destino, nameD, origen, nameO);
    }

    static void Main()
    {
        Console.Write("Ingrese el número de discos: ");
        if (!int.TryParse(Console.ReadLine(), out int numDiscos) || numDiscos <= 0)
        {
            Console.WriteLine("Debe ingresar un número entero positivo.");
            return;
        }

        // Crea las tres pilas 
        var torreA = new Stack<int>();
        var torreB = new Stack<int>();
        var torreC = new Stack<int>();

        // Inicia la torre A con discos de mayor  a menor 
        for (int i = numDiscos; i >= 1; i--)
            torreA.Push(i);

        Console.WriteLine("\nConfiguración inicial:");
        ImprimirTorres(torreA, torreB, torreC);

        // mueve todos los discos de A a C usando B
        MoverDiscos(
            numDiscos,
            torreA, 'A',
            torreC, 'C',
            torreB, 'B'
        );

        Console.WriteLine("¡Solución completada!");
        Console.WriteLine("Configuración final:");
        ImprimirTorres(torreA, torreB, torreC);
    }
}