// Escribir un programa que almacene el abecedario en una lista, elimine de la lista las letras que ocupen posiciones múltiplos de 3, y muestre por pantalla la lista resultante.
class Program
{
    static void Main()
    {
        // Creación de el abecedario en un arreglo 
        char[] listaLetras = {
            'a','b','c','d','e','f','g',
            'h','i','j','k','l','m','n',
            'ñ','o','p','q','r','s','t',
            'u','v','w','x','y','z'
        };

        // Se apila en orden inverso para que al desapilar vayamos de 'a' a 'z'
        var pilaEntrada = new System.Collections.Generic.Stack<char>();
        for (int i = listaLetras.Length - 1; i >= 0; i--)
            pilaEntrada.Push(listaLetras[i]);

        // Se desapila y se filtra posiciones múltiplos de 3, guardando en otra pila
        var pilaResultado = new System.Collections.Generic.Stack<char>();
        int posicion = 1;
        while (pilaEntrada.Count > 0)
        {
            char letra = pilaEntrada.Pop();
            if (posicion % 3 != 0)
                pilaResultado.Push(letra);
            posicion++;
        }

        // Se desapila la pila de resultado para imprimirlo en un orden correcto
        while (pilaResultado.Count > 0)
            System.Console.Write(pilaResultado.Pop() + " ");

        
        System.Console.WriteLine();
    }
}