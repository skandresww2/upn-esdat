using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Instanciamos nuestra lista vacía
            ListaDoble lista = new ListaDoble();

            Console.WriteLine("=== REGISTRO DE PERSONAS (LISTA DOBLE) ===");
            Console.Write("¿Cuántas personas desea registrar?: ");

            // Leemos la cantidad. (Asumimos que el usuario escribe un número válido para no complicar el lab)
            int n = int.Parse(Console.ReadLine());

            // Un bucle for que se repite 'n' veces para pedir los datos
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- Persona {i + 1} ---");

                Console.Write("Nombre: ");
                string nombre = Console.ReadLine();

                Console.Write("Edad: ");
                int edad = int.Parse(Console.ReadLine());

                Console.Write("Estatura (Ej. 1.75): ");
                double estatura = double.Parse(Console.ReadLine());

                // 1. Empaquetamos los datos en un objeto Persona
                Persona nuevaPersona = new Persona(nombre, edad, estatura);

                // 2. Metemos ese objeto a nuestra lista doble
                lista.InsertarFinal(nuevaPersona);
            }

            Console.WriteLine("\n==================================================");
            Console.WriteLine(" DATOS REGISTRADOS (DE ATRÁS HACIA ADELANTE)");
            Console.WriteLine("==================================================");

            // Llamamos al método que demuestra que los punteros "anterior" funcionan
            lista.MostrarAtrasHaciaAdelante();

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
