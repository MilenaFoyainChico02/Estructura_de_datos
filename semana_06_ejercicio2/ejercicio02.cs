namespace ManejoReales
{
    public class Nodo  // Nodo para lista que almacena un valor real
    {
        public double dato;
        public Nodo siguiente;
        public Nodo(double v)  // Constructor que inicia el nodo con el valor proporcionado
        {
            dato = v;
        }
    }
 // Lista enlazada para almacenar los valores reales y realizar operaciones sobre ellos
    public class Lista
    {
        public Nodo cabeza;

        public void Agregar(double v)
        {
            if (cabeza == null)
                cabeza = new Nodo(v);
            else
            {
                Nodo actual = cabeza;
                while (actual.siguiente != null)
                    actual = actual.siguiente;
                actual.siguiente = new Nodo(v);
            }
        }
// Calcula y retorna el promedio de todos los datos de la lista
        public double CalcularPromedio()
        {
            if (cabeza == null)
                return 0;

            double suma = 0;
            int contador = 0;
            Nodo actual = cabeza;
            while (actual != null)
            {
                suma += actual.dato;
                contador++;
                actual = actual.siguiente;
            }
            return suma / contador;
        }
// Crea y retorna una lista con los valores menores o iguales al promedio
        public Lista MenoresIguales(double prom)
        {
            Lista resultado = new Lista();
            Nodo actual = cabeza;
            while (actual != null)
            {
                if (actual.dato <= prom)
                    resultado.Agregar(actual.dato);
                actual = actual.siguiente;
            }
            return resultado;
        }
// Crea y retorna una lista con los valores mayores al promedio
        public Lista Mayores(double prom)
        {
            Lista resultado = new Lista();
            Nodo actual = cabeza;
            while (actual != null)
            {
                if (actual.dato > prom)
                    resultado.Agregar(actual.dato);
                actual = actual.siguiente;
            }
            return resultado;
        }
 // Muestra todos los valores de la lista en la consola, separados por espacios
        public void Mostrar()
        {
            Nodo actual = cabeza;
            while (actual != null)
            {
                System.Console.Write(actual.dato + " ");
                actual = actual.siguiente;
            }
            System.Console.WriteLine();
        }
    }

    class ProgramaPrincipal
    {
        static void Main(string[] args)
        {
            Lista principal = new Lista();
            System.Console.Write("Cantidad de datos: ");
            int n = int.Parse(System.Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                System.Console.Write("Valor #" + (i + 1) + ": ");
                double v = double.Parse(System.Console.ReadLine());
                principal.Agregar(v);
            }

            double promedio = principal.CalcularPromedio();
            Lista menoresIguales = principal.MenoresIguales(promedio);
            Lista mayores = principal.Mayores(promedio);

            System.Console.WriteLine("\nDatos en la lista principal:");
            principal.Mostrar();
            System.Console.WriteLine("Promedio: " + promedio);
            System.Console.WriteLine("Datos <= promedio:");
            menoresIguales.Mostrar();
            System.Console.WriteLine("Datos > promedio:");
            mayores.Mostrar();
        }
    }
}