using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4
{
    // El Nodo representa a un niño en la ronda.
    // Guarda un número y tiene una mano (puntero) para agarrar al siguiente.
    internal class Nodo
    {
        public int dato;         // El número entero que guarda el nodo
        public Nodo siguiente;   // El puntero que enlaza con el próximo nodo

        // Constructor: Cuando nace un nodo, nace con su dato, 
        // pero su mano 'siguiente' aún no agarra a nadie (es null).
        public Nodo(int valor)
        {
            dato = valor;
            siguiente = null;
        }
    }
}
