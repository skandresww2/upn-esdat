namespace Ejercicio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Le decimos a la consola que imprima en UTF-8 para que
            // caracteres especiales como ← se muestren correctamente.
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Creamos la lista circular. Al principio está vacía.
            // 'lista' es una instancia de ListaCircular (del otro archivo).
            // Como ambos archivos están en el mismo namespace (Ejercicio2),
            // no hace falta importar nada: C# encuentra la clase solita.
            ListaCircular lista = new ListaCircular();

            int op;

            // Bucle principal del menú. Se repite hasta que el usuario
            // elija la opción 0 (Salir).
            do
            {
                // Mostramos el menú. Separamos el salto de línea en una
                // llamada propia (Console.WriteLine sin argumentos) para
                // evitar problemas con '\n' dentro del string.
                Console.WriteLine();
                Console.WriteLine("=== CALL CENTER – TURNOS ROTATIVOS ===");
                Console.WriteLine("1. Agregar agente");
                Console.WriteLine("2. Atender llamada (avanzar turno)");
                Console.WriteLine("3. Eliminar agente");
                Console.WriteLine("4. Mostrar lista");
                Console.WriteLine("0. Salir");
                Console.Write("Opción: ");

                // Leemos la opción. int.Parse explota si el usuario escribe
                // algo que no sea un número; para un laboratorio didáctico
                // lo dejamos así, pero en producción usaríamos int.TryParse.
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        Console.Write("Nombre del agente: ");
                        lista.Agregar(Console.ReadLine());
                        break;

                    case 2:
                        // Atender() devuelve el nombre del que atendió,
                        // o null si la lista está vacía.
                        string a = lista.Atender();
                        if (a != null)
                            Console.WriteLine($"Atendió: {a}. Siguiente turno listo.");
                        else
                            Console.WriteLine("No hay agentes en la lista.");
                        break;

                    case 3:
                        Console.Write("Nombre a eliminar: ");
                        bool ok = lista.Eliminar(Console.ReadLine());
                        Console.WriteLine(ok ? "Eliminado." : "No encontrado.");
                        break;

                    case 4:
                        lista.Mostrar();
                        break;
                }

            } while (op != 0);

            Console.WriteLine("Programa terminado. Presione una tecla para cerrar...");
            Console.ReadKey();
        }
    }
}
