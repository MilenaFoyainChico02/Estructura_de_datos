using System;
using System.Collections.Generic;

namespace StacksExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            // Verifica los paréntesis balanceados
            string expresion = "{7 + (8 * 5) - [(9 - 7) + (4 + 1)]}";
            Console.WriteLine($"Expresión: {expresion}");
            Console.WriteLine(
                ParentesisBalanceados(expresion)
                    ? "Fórmula balanceada."
                    : "Fórmula NO balanceada."
            );

            Console.WriteLine("\n----- Torres de Hanoi -----");
            int numeroDiscos = 3;
            var pilaOrigen   = new Stack<int>();
            var pilaAuxiliar = new Stack<int>();
            var pilaDestino  = new Stack<int>();

            // Apila los discos en la torre A, de el más grande al más bajo
            for (int i = numeroDiscos; i >= 1; i--)
                pilaOrigen.Push(i);

            ResolverHanoi(
                numeroDiscos,
                pilaOrigen, pilaAuxiliar, pilaDestino,
                "A", "B", "C"
            );
        }

        static bool ParentesisBalanceados(string texto)
        {
            var pila = new Stack<char>();
            var pares = new Dictionary<char,char>
            {
                { ')', '(' },
                { '}', '{' },
                { ']', '[' }
            };

            foreach (char c in texto)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    pila.Push(c);
                }
                else if (pares.ContainsKey(c))
                {
                    if (pila.Count == 0 || pila.Pop() != pares[c])
                        return false;
                }
            }

            return pila.Count == 0;
        }

        static void ResolverHanoi(
            int discos,
            Stack<int> origen,
            Stack<int> auxiliar,
            Stack<int> destino,
            string nombreOrigen,
            string nombreAuxiliar,
            string nombreDestino)
        {
            if (discos == 0) return;

            // Mueve discos-1 de origen a auxiliar
            ResolverHanoi(discos - 1, origen, destino, auxiliar,
                         nombreOrigen, nombreDestino, nombreAuxiliar);

            // Mueve el disco actual
            int discoMovido = origen.Pop();
            destino.Push(discoMovido);
            Console.WriteLine($"Mover disco {discoMovido}: {nombreOrigen} → {nombreDestino}");
            ImprimirPilas(origen, auxiliar, destino,
                          nombreOrigen, nombreAuxiliar, nombreDestino);

            // Mueve discos-1 de auxiliar a destino
            ResolverHanoi(discos - 1, auxiliar, origen, destino,
                         nombreAuxiliar, nombreOrigen, nombreDestino);
        }

        static void ImprimirPilas(
            Stack<int> origen,
            Stack<int> auxiliar,
            Stack<int> destino,
            string nombreOrigen,
            string nombreAuxiliar,
            string nombreDestino)
        {
            Console.WriteLine(
                $"[{nombreOrigen}]: {String.Join(",", origen)}   " +
                $"[{nombreAuxiliar}]: {String.Join(",", auxiliar)}   " +
                $"[{nombreDestino}]: {String.Join(",", destino)}"
            );
        }
    }
}