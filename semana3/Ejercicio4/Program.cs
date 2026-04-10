using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Creamos la primera instancia (La lista que recibirá todos los números mezclados)
            ListaCircular listaPrincipal = new ListaCircular();

            Console.WriteLine("=== GESTIÓN DE NÚMEROS (LISTAS CIRCULARES) ===");
            Console.Write("¿Cuántos números en total desea registrar?: ");

            int n = int.Parse(Console.ReadLine());

            // 2. Bucle para que el usuario ingrese la cantidad 'n' de números
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Ingrese el número {i + 1}: ");
                int num = int.Parse(Console.ReadLine());

                // Insertamos cada número en la lista general
                listaPrincipal.Insertar(num);
            }

            Console.WriteLine("\n------------------------------------------------");
            Console.WriteLine(" LISTA CIRCULAR ORIGINAL (Todos los números)");
            Console.WriteLine("------------------------------------------------");
            listaPrincipal.Mostrar();

            // 3. Cumpliendo el objetivo: "crear dos NUEVAS instancias"
            ListaCircular listaPares = new ListaCircular();
            ListaCircular listaImpares = new ListaCircular();

            // 4. Llamamos al método que recorre la original y va "repartiendo" los números
            listaPrincipal.SepararParesImpares(listaPares, listaImpares);

            // 5. Mostramos los resultados finales comprobando que se separaron bien
            Console.WriteLine("\n------------------------------------------------");
            Console.WriteLine(" LISTA CIRCULAR DE PARES");
            Console.WriteLine("------------------------------------------------");
            listaPares.Mostrar();

            Console.WriteLine("\n------------------------------------------------");
            Console.WriteLine(" LISTA CIRCULAR DE IMPARES");
            Console.WriteLine("------------------------------------------------");
            listaImpares.Mostrar();

            Console.WriteLine("\nPresione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
