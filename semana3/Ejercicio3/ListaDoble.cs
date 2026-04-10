using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    // Esta clase controla todos los nodos. Solo necesita saber
    // dónde empieza y dónde termina la lista para no perderse en la memoria.
    internal class ListaDoble
    {
        public Nodo inicio; // Apunta al primer nodo de la lista.
        public Nodo ultimo; // Apunta al último nodo de la lista.

        // Al crear la lista por primera vez, está completamente vacía.
        public ListaDoble()
        {
            inicio = null;
            ultimo = null;
        }

        // --- MÉTODO: INSERTAR AL FINAL ---
        public void InsertarFinal(Persona p)
        {
            // 1. Creamos el nuevo vagón con su carga.
            Nodo nuevo = new Nodo(p);

            // 2. CASO A: ¿La lista está vacía?
            if (inicio == null)
            {
                // Si no hay nadie, el nuevo es tanto el primero como el último.
                inicio = nuevo;
                ultimo = nuevo;
            }
            // 3. CASO B: Ya hay vagones en la lista.
            else
            {
                // El vagón que actualmente es el 'ultimo' lanza su gancho
                // 'siguiente' para agarrar al 'nuevo' vagón.
                ultimo.siguiente = nuevo;

                // El 'nuevo' vagón lanza su gancho 'anterior' para 
                // agarrarse del que hasta ahora era el 'ultimo'.
                // ¡AQUÍ SE FORMA EL ENLACE DOBLE!
                nuevo.anterior = ultimo;

                // Ahora, oficialmente, el 'nuevo' vagón se convierte en el 'ultimo'.
                ultimo = nuevo;
            }
        }

        // --- MÉTODO: MOSTRAR DE ATRÁS HACIA ADELANTE ---
        public void MostrarAtrasHaciaAdelante()
        {
            // Validamos que haya algo que mostrar.
            if (ultimo == null)
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }

            // Para recorrer al revés, nuestro puntero auxiliar
            // debe empezar parado en el ÚLTIMO nodo.
            Nodo puntero = ultimo;

            // Mientras el puntero esté en un nodo válido...
            while (puntero != null)
            {
                // Imprimimos la carga (Persona) de ese nodo.
                Console.WriteLine($"Nombre: {puntero.dato.Nombre} | Edad: {puntero.dato.Edad} | Estatura: {puntero.dato.Estatura}m");

                // ¡PASO CRUCIAL!: En lugar de avanzar (puntero.siguiente),
                // retrocedemos viajando por el gancho 'anterior'.
                // Cuando pasemos el primer nodo, 'anterior' será null y el bucle terminará.
                puntero = puntero.anterior;
            }
        }
    }
}
