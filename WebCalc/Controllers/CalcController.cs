using System;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;

namespace MultiLangCalcWeb.Controllers
{
    public class CalcController : Controller
    {
        // Funciones básicas
        [DllImport("libmix.dylib", CallingConvention = CallingConvention.Cdecl)]
        private static extern int sum(int a, int b);

        [DllImport("libmix.dylib", CallingConvention = CallingConvention.Cdecl)]
        private static extern int sub(int a, int b);

        [DllImport("libmix.dylib", CallingConvention = CallingConvention.Cdecl)]
        private static extern int multiply(int a, int b);

        [DllImport("libmix.dylib", CallingConvention = CallingConvention.Cdecl)]
        private static extern double divide(double a, double b);

        // Funciones científicas
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

        // Acción que muestra el formulario vacío
        public IActionResult Index()
        {
            return View();
        }

        // Acción que procesa los valores enviados desde el formulario
        [HttpPost]
        public IActionResult Calculate(string operation, string inputA, string inputB)
        {
            double resultado = 0;
            string mensajeError = null;

            try
            {
                // Intentamos parsear los parámetros. Usamos TryParse para evitar excepciones no controladas.
                switch (operation)
                {
                    case "sum":
                        if (int.TryParse(inputA, out int sa) && int.TryParse(inputB, out int sb))
                        {
                            resultado = sum(sa, sb);
                        }
                        else
                        {
                            mensajeError = "Los valores para suma deben ser enteros.";
                        }
                        break;

                    case "sub":
                        if (int.TryParse(inputA, out int s1) && int.TryParse(inputB, out int s2))
                        {
                            resultado = sub(s1, s2);
                        }
                        else
                        {
                            mensajeError = "Los valores para resta deben ser enteros.";
                        }
                        break;

                    case "mul":
                        if (int.TryParse(inputA, out int ma) && int.TryParse(inputB, out int mb))
                        {
                            resultado = multiply(ma, mb);
                        }
                        else
                        {
                            mensajeError = "Los valores para multiplicación deben ser enteros.";
                        }
                        break;

                    case "div":
                        if (double.TryParse(inputA, out double da) && double.TryParse(inputB, out double db))
                        {
                            if (db == 0)
                            {
                                mensajeError = "No se puede dividir entre cero.";
                            }
                            else
                            {
                                resultado = divide(da, db);
                            }
                        }
                        else
                        {
                            mensajeError = "Los valores para división deben ser numéricos.";
                        }
                        break;

                    case "sin":
                        if (double.TryParse(inputA, out double angleSin))
                        {
                            resultado = sc_sin(angleSin);
                        }
                        else
                        {
                            mensajeError = "El valor para seno debe ser numérico.";
                        }
                        break;

                    case "cos":
                        if (double.TryParse(inputA, out double angleCos))
                        {
                            resultado = sc_cos(angleCos);
                        }
                        else
                        {
                            mensajeError = "El valor para coseno debe ser numérico.";
                        }
                        break;

                    case "tan":
                        if (double.TryParse(inputA, out double angleTan))
                        {
                            resultado = sc_tan(angleTan);
                        }
                        else
                        {
                            mensajeError = "El valor para tangente debe ser numérico.";
                        }
                        break;

                    case "log":
                        if (double.TryParse(inputA, out double valLog) && valLog > 0)
                        {
                            resultado = sc_log(valLog);
                        }
                        else
                        {
                            mensajeError = "El logaritmo solo se define para valores mayores a cero.";
                        }
                        break;

                    case "pow":
                        if (double.TryParse(inputA, out double basePow) && double.TryParse(inputB, out double expPow))
                        {
                            resultado = sc_pow(basePow, expPow);
                        }
                        else
                        {
                            mensajeError = "Los valores para potencia deben ser numéricos.";
                        }
                        break;

                    case "sqrt":
                        if (double.TryParse(inputA, out double valSqrt) && valSqrt >= 0)
                        {
                            resultado = sc_sqrt(valSqrt);
                        }
                        else
                        {
                            mensajeError = "La raíz solo está definida para valores no negativos.";
                        }
                        break;

                    default:
                        mensajeError = "Operación no reconocida.";
                        break;
                }
            }
            catch (Exception ex)
            {
                mensajeError = "Ocurrió un error al invocar la librería nativa: " + ex.Message;
            }

            // Pasamos al ViewBag el resultado o el mensaje de error
            ViewBag.Resultado = resultado;
            ViewBag.MensajeError = mensajeError;
            ViewBag.InputA = inputA;
            ViewBag.InputB = inputB;
            ViewBag.Operation = operation;

            return View("Index");
        }
    }
}