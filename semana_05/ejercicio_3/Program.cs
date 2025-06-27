// escribir un programa que almacene las matrices, en una tupla y muestre por pantalla su producto.
//Nota: Para representar matrices mediante tuplas usar tuplas anidadas, representando cada vector fila en una tupla.
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // se guarda A y B como tuplas anidadas 
        var A = (
            (1, 2, 3),
            (4, 5, 6)
        );
        var B = (
            (-1, 0),
            ( 0, 1),
            ( 1, 1)
        );

        // 2×2 para el resultado
        int[,] C = new int[2, 2];

        //  para cada fila i y columna j, se usa pilas para el dot product
        for (int i = 0; i < 2; i++)
        {
            // se elige la fila de A
            var row = (i == 0 ? A.Item1 : A.Item2);
            int[] rowArr = { row.Item1, row.Item2, row.Item3 };

            for (int j = 0; j < 2; j++)
            {
                // se extrae la columna j de B
                int[] colArr = j == 0
                    ? new[] { B.Item1.Item1, B.Item2.Item1, B.Item3.Item1 }
                    : new[] { B.Item1.Item2, B.Item2.Item2, B.Item3.Item2 };

                // apila en orden natural (Item1…ItemN)
                var stackA = new Stack<int>(rowArr);
                var stackB = new Stack<int>(colArr);

                int sum = 0;
                // desapila simultáneamente para sumar productos
                while (stackA.Count > 0)
                    sum += stackA.Pop() * stackB.Pop();

                C[i, j] = sum;
            }
        }

        // muestra la matriz resultante
        Console.WriteLine($"[{C[0,0]}  {C[0,1]}]");
        Console.WriteLine($"[{C[1,0]}  {C[1,1]}]");
    }
}