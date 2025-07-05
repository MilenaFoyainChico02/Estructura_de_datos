//Crear un programa que Crear un programa que permita llevar el registro de permita llevar el registro de los vehículos del est los vehículos 
//del estacionamiento del acionamiento delarea de Ingeniería de Sistemas de la Área de Ingeniería de Sistemas de la Universidad ut Universidad utilizando como estructura de ilizando como estructura de
//almacenamiento listas enlazadas. Los datos solicitados por cada vehículo son: placa,marca, modelo, año y marca, modelo, año y precio
namespace RegistroVehiculos
{
    public class Vehiculo  // Clase para representar un vehículo con sus atributos básicos
    {
        public string placa;
        public string marca;
        public string modelo;
        public int anio;
        public decimal precio;
        // Constructor que inicializa un nuevo Vehiculo con los datos proporcionados
        public Vehiculo(string p, string m, string mo, int a, decimal pr)
        {
            placa = p;
            marca = m;
            modelo = mo;
            anio = a;
            precio = pr;
        }
    }
// Nodo de lista enlazada que almacena un Vehiculo y referencia al siguiente Nodo
    public class Nodo
    {
        public Vehiculo dato;
        public Nodo siguiente;
// Constructor para crear un nodo con el Vehiculo proporcionado
        public Nodo(Vehiculo v)
        {
            dato = v;
        }
    }
// Clase que gestiona la lista enlazada de vehículos y las operaciones asociadas
    public class ListaVehiculos
    {
        private Nodo cabeza; // Referencia al primer nodo de la lista
 // para agregar un nuevo vehiculo 
        public void Agregar(Vehiculo v)
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
 // Busca y retorna el Vehiculo con la placa indicada 
        public Vehiculo BuscarPorPlaca(string placa)
        {
            Nodo actual = cabeza;
            while (actual != null)
            {
                if (actual.dato.placa.Equals(placa, System.StringComparison.OrdinalIgnoreCase))
                    return actual.dato;
                actual = actual.siguiente;
            }
            return null;
        }
 // Muestra todos los vehículos cuyo año coincide con el parámetro
        public void MostrarPorAnio(int anio)
        {
            Nodo actual = cabeza;
            bool encontrado = false;
            while (actual != null)
            {
                if (actual.dato.anio == anio)
                {
                    System.Console.WriteLine($"{actual.dato.placa} {actual.dato.marca} {actual.dato.modelo} {actual.dato.anio} {actual.dato.precio}");
                    encontrado = true;
                }
                actual = actual.siguiente;
            }
            if (!encontrado)
                System.Console.WriteLine($"No hay vehículos del año {anio}.");
        }
 // muestra todos los vehículos registrados en la lista
        public void MostrarTodos()
        {
            if (cabeza == null)
            {
                System.Console.WriteLine("No hay vehículos registrados.");
                return;
            }
            Nodo actual = cabeza;
            while (actual != null)
            {
                System.Console.WriteLine($"{actual.dato.placa} {actual.dato.marca} {actual.dato.modelo} {actual.dato.anio} {actual.dato.precio}");
                actual = actual.siguiente;
            }
        }
// elimina el Vehiculo con la placa ingresada
        public bool EliminarPorPlaca(string placa)
        {
            if (cabeza == null)
                return false;
            if (cabeza.dato.placa.Equals(placa, System.StringComparison.OrdinalIgnoreCase))
            {
                cabeza = cabeza.siguiente;
                return true;
            }
            Nodo actual = cabeza;
            while (actual.siguiente != null)
            {
                if (actual.siguiente.dato.placa.Equals(placa, System.StringComparison.OrdinalIgnoreCase))
                {
                    actual.siguiente = actual.siguiente.siguiente;
                    return true;
                }
                actual = actual.siguiente;
            }
            return false;
        }
    }

    class ProgramaPrincipal
    {
        static void Main(string[] args)
        {
            ListaVehiculos lista = new ListaVehiculos();
            string op = string.Empty;
            while (op != "f")
            {
                System.Console.WriteLine("a: Agregar, b: Buscar placa, c: Ver por año, d: Mostrar todos, e: Eliminar placa, f: Salir");
                System.Console.Write("Seleccione opción: ");
                op = System.Console.ReadLine();
                switch (op)
                {
                    case "a":
                        System.Console.Write("Placa: "); var pla = System.Console.ReadLine();
                        System.Console.Write("Marca: "); var mar = System.Console.ReadLine();
                        System.Console.Write("Modelo: "); var mo = System.Console.ReadLine();
                        System.Console.Write("Año: "); var an = int.Parse(System.Console.ReadLine());
                        System.Console.Write("Precio: "); var pr = decimal.Parse(System.Console.ReadLine());
                        lista.Agregar(new Vehiculo(pla, mar, mo, an, pr));
                        break;
                    case "b":
                        System.Console.Write("Placa: "); var buscar = System.Console.ReadLine();
                        var v = lista.BuscarPorPlaca(buscar);
                        if (v != null)
                            System.Console.WriteLine($"Encontrado: {v.placa} {v.marca} {v.modelo} {v.anio} {v.precio}");
                        else
                            System.Console.WriteLine("No encontrado");
                        break;
                    case "c":
                        System.Console.Write("Año: "); var anio = int.Parse(System.Console.ReadLine());
                        lista.MostrarPorAnio(anio);
                        break;
                    case "d":
                        lista.MostrarTodos();
                        break;
                    case "e":
                        System.Console.Write("Placa: "); var del = System.Console.ReadLine();
                        if (lista.EliminarPorPlaca(del))
                            System.Console.WriteLine("Eliminado");
                        else
                            System.Console.WriteLine("No existe");
                        break;
                    case "f":
                        System.Console.WriteLine("Saliendo...");
                        break;
                    default:
                        System.Console.WriteLine("Opción inválida");
                        break;
                }
                System.Console.WriteLine();
            }
        }
    }
}