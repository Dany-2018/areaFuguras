using System;

namespace CalculadoraAreas
{
    abstract class FiguraGeometrica
    {
        public abstract string ObtenerNombre();
        public abstract double CalcularArea();
    }

    class Circulo : FiguraGeometrica
    {
        public double Radio { get; set; }

        public Circulo(double radio)
        {
            Radio = radio;
        }

        public override string ObtenerNombre()
        {
            return "Círculo";
        }

        public override double CalcularArea()
        {
            return Math.PI * Math.Pow(Radio, 2);
        }
    }

    class Rectangulo : FiguraGeometrica
    {
        public double Base { get; set; }
        public double Altura { get; set; }

        public Rectangulo(double @base, double altura)
        {
            Base = @base;
            Altura = altura;
        }

        public override string ObtenerNombre()
        {
            return "Rectángulo";
        }

        public override double CalcularArea()
        {
            return Base * Altura;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Calculador de áreas de figuras geometricas");
                Console.WriteLine("1. Calcular área de un círculo");
                Console.WriteLine("2. Calcular área de un rectángulo");
                Console.WriteLine("3. Salir");
                Console.Write("Elija una opción (1/2/3): ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        CalcularAreaFigura(new Circulo(ObtenerDouble("Ingrese el radio del círculo: ")));
                        break;
                    case "2":
                        CalcularAreaFigura(new Rectangulo(ObtenerDouble("Ingrese la base del rectángulo: "), ObtenerDouble("Ingrese la altura del rectángulo: ")));
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, elija 1, 2 o 3.");
                        break;
                }
            }
        }

        static void CalcularAreaFigura(FiguraGeometrica figura)
        {
            double area = figura.CalcularArea();
            Console.WriteLine($"El área de {figura.ObtenerNombre()} es: {area}");
        }

        static double ObtenerDouble(string mensaje)
        {
            double valor;
            while (true)
            {
                Console.Write(mensaje);
                if (double.TryParse(Console.ReadLine(), out valor))
                    return valor;
                Console.WriteLine("Entrada no válida. Asegúrese de ingresar un número válido.");
            }
        }
    }
}
