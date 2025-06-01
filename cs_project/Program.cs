using System;
using System.Runtime.InteropServices;

class Program
{
    // Importar las funciones básicas
    [DllImport("libmix.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern int sum(int a, int b);

    [DllImport("libmix.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern int sub(int a, int b);

    [DllImport("libmix.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern int multiply(int a, int b);

    [DllImport("libmix.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern double divide(double a, double b);

    // Importar las funciones científicas
    [DllImport("libmix.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern double sc_sin(double a);

    [DllImport("libmix.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern double sc_cos(double a);

    [DllImport("libmix.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern double sc_tan(double a);

    [DllImport("libmix.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern double sc_log(double a);

    [DllImport("libmix.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern double sc_pow(double a, double b);

    [DllImport("libmix.dylib", CallingConvention = CallingConvention.Cdecl)]
    private static extern double sc_sqrt(double a);

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("---- Calculadora Científica ----");
            Console.WriteLine("1) Sumar (a + b)");
            Console.WriteLine("2) Restar (a - b)");
            Console.WriteLine("3) Multiplicar (a * b)");
            Console.WriteLine("4) Dividir (a / b)");
            Console.WriteLine("5) Seno (sin a)");
            Console.WriteLine("6) Coseno (cos a)");
            Console.WriteLine("7) Tangente (tan a)");
            Console.WriteLine("8) Logaritmo natural (log a)");
            Console.WriteLine("9) Potencia (a^b)");
            Console.WriteLine("10) Raíz cuadrada (sqrt a)");
            Console.WriteLine("0) Salir");
            Console.Write("Selecciona una opción: ");
            string opcion = Console.ReadLine();

            if (opcion == "0")
            {
                break;
            }

            try
            {
                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingresa valor a (entero): ");
                        int a1 = int.Parse(Console.ReadLine());
                        Console.Write("Ingresa valor b (entero): ");
                        int b1 = int.Parse(Console.ReadLine());
                        int resultSum = sum(a1, b1);
                        Console.WriteLine($"Resultado: {a1} + {b1} = {resultSum}");
                        break;

                    case "2":
                        Console.Write("Ingresa valor a (entero): ");
                        int a2 = int.Parse(Console.ReadLine());
                        Console.Write("Ingresa valor b (entero): ");
                        int b2 = int.Parse(Console.ReadLine());
                        int resultSub = sub(a2, b2);
                        Console.WriteLine($"Resultado: {a2} - {b2} = {resultSub}");
                        break;

                    case "3":
                        Console.Write("Ingresa valor a (entero): ");
                        int a3 = int.Parse(Console.ReadLine());
                        Console.Write("Ingresa valor b (entero): ");
                        int b3 = int.Parse(Console.ReadLine());
                        int resultMul = multiply(a3, b3);
                        Console.WriteLine($"Resultado: {a3} * {b3} = {resultMul}");
                        break;

                    case "4":
                        Console.Write("Ingresa valor a (decimal): ");
                        double a4 = double.Parse(Console.ReadLine());
                        Console.Write("Ingresa valor b (decimal): ");
                        double b4 = double.Parse(Console.ReadLine());
                        if (b4 == 0)
                        {
                            Console.WriteLine("Error: División entre cero.");
                        }
                        else
                        {
                            double resultDiv = divide(a4, b4);
                            Console.WriteLine($"Resultado: {a4} / {b4} = {resultDiv}");
                        }
                        break;

                    case "5":
                        Console.Write("Ingresa ángulo en radianes (decimal): ");
                        double a5 = double.Parse(Console.ReadLine());
                        double resultSin = sc_sin(a5);
                        Console.WriteLine($"Resultado: sin({a5}) = {resultSin}");
                        break;

                    case "6":
                        Console.Write("Ingresa ángulo en radianes (decimal): ");
                        double a6 = double.Parse(Console.ReadLine());
                        double resultCos = sc_cos(a6);
                        Console.WriteLine($"Resultado: cos({a6}) = {resultCos}");
                        break;

                    case "7":
                        Console.Write("Ingresa ángulo en radianes (decimal): ");
                        double a7 = double.Parse(Console.ReadLine());
                        double resultTan = sc_tan(a7);
                        Console.WriteLine($"Resultado: tan({a7}) = {resultTan}");
                        break;

                    case "8":
                        Console.Write("Ingresa valor (decimal, >0) para logaritmo: ");
                        double a8 = double.Parse(Console.ReadLine());
                        if (a8 <= 0)
                        {
                            Console.WriteLine("Error: el logaritmo solo está definido para valores mayores que cero.");
                        }
                        else
                        {
                            double resultLog = sc_log(a8);
                            Console.WriteLine($"Resultado: log({a8}) = {resultLog}");
                        }
                        break;

                    case "9":
                        Console.Write("Ingresa valor a (decimal): ");
                        double a9 = double.Parse(Console.ReadLine());
                        Console.Write("Ingresa valor b (decimal, exponente): ");
                        double b9 = double.Parse(Console.ReadLine());
                        double resultPow = sc_pow(a9, b9);
                        Console.WriteLine($"Resultado: {a9} ^ {b9} = {resultPow}");
                        break;

                    case "10":
                        Console.Write("Ingresa valor (decimal, >=0) para raíz cuadrada: ");
                        double a10 = double.Parse(Console.ReadLine());
                        if (a10 < 0)
                        {
                            Console.WriteLine("Error: la raíz cuadrada solo está definida para valores no negativos.");
                        }
                        else
                        {
                            double resultSqrt = sc_sqrt(a10);
                            Console.WriteLine($"Resultado: sqrt({a10}) = {resultSqrt}");
                        }
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Entrada inválida. Asegúrate de ingresar un número válido.");
            }

            Console.WriteLine();
        }

        Console.WriteLine("Programa finalizado.");
    }
}