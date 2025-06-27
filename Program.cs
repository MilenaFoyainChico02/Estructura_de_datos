namespace FigurasGeometricas
{
    // Clase Circulo representa una figura geométrica circular
    public class Circulo
    {
        // Atributo privado que representa el radio del círculo
        private double radio;

        // Constructor de la clase que inicializa el radio
        public Circulo(double radio)
        {
            this.radio = radio;
        }

        // Método para calcular el área de un círculo
        // Área = PI * radio^2
        public double CalcularArea()
        {
            return Math.PI * radio * radio;
        }

        // Método para calcular el perímetro de un círculo
        // Perímetro = 2 * PI * radio
        public double CalcularPerimetro()
        {
            return 2 * Math.PI * radio;
        }
    }

    // Clase Rectangulo representa una figura geométrica rectangular
    public class Rectangulo
    {
        // Atributos privados que representan el largo y el ancho del rectángulo
        private double largo;
        private double ancho;

        // Constructor de la clase que inicializa el largo y el ancho
        public Rectangulo(double largo, double ancho)
        {
            this.largo = largo;
            this.ancho = ancho;
        }

        // Método para calcular el área de un rectángulo
        // Área = largo * ancho
        public double CalcularArea()
        {
            return largo * ancho;
        }

        // Método para calcular el perímetro de un rectángulo
        // Perímetro = 2 * (largo + ancho)
        public double CalcularPerimetro()
        {
            return 2 * (largo + ancho);
        }
    }

    // Clase principal del programa
    class Program
    {
        //static void Main(string[] args)
        {
            // Crear un objeto Circulo con radio 5
            Circulo miCirculo = new Circulo(5);

            // Mostrar el área y perímetro del círculo
            Console.WriteLine("Círculo:");
            Console.WriteLine("Área: " + miCirculo.CalcularArea());
            Console.WriteLine("Perímetro: " + miCirculo.CalcularPerimetro());

            // Crear un objeto Rectangulo con largo 10 y ancho 4
            Rectangulo miRectangulo = new Rectangulo(10, 4);

            // Mostrar el área y perímetro del rectángulo
            Console.WriteLine("\nRectángulo:");
            Console.WriteLine("Área: " + miRectangulo.CalcularArea());
            Console.WriteLine("Perímetro: " + miRectangulo.CalcularPerimetro());
        }
    }
}
