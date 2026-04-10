using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    // El Nodo es como el vagón de un tren.
    // Lleva una "carga" (la Persona) y tiene "ganchos" para conectarse
    // con el vagón de adelante y el vagón de atrás.
    internal class Nodo
    {
        public Persona dato;     // La carga del vagón.
        public Nodo siguiente;   // Gancho que apunta al vagón que va después.
        public Nodo anterior;    // Gancho que apunta al vagón que va antes (Clave para listas dobles).

        // Al crear un nuevo nodo (vagón), le metemos la carga,
        // pero sus ganchos aún no están conectados a nada (son null).
        public Nodo(Persona p)
        {
            dato = p;
            siguiente = null;
            anterior = null;
        }
    }
}
