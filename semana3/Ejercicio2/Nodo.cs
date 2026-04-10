using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    // ============================================================
    // CLASE NODO
    // ============================================================
    // Representa UN agente del call center dentro de la lista circular.
    // Solo necesita UN puntero (sgte) porque la rotación va siempre
    // en un solo sentido: del actual al siguiente.
    internal class Nodo
    {
        // Dato que guarda el nodo: el nombre del agente.
        public string Nombre;

        // Puntero al siguiente nodo de la cola.
        // En una lista circular, el sgte del ÚLTIMO nodo apunta al PRIMERO,
        // nunca a null. Eso es lo que forma el ciclo.
        public Nodo Sgte;

        // Constructor: se ejecuta al hacer "new Nodo("Ana")".
        // Recibe el nombre como parámetro y deja el nodo listo para usar.
        public Nodo(string nombre)
        {
            // 'this.Nombre' es el campo del objeto recién creado.
            // 'nombre' (sin 'this.') es el parámetro del constructor.
            // Como se llaman igual, el 'this.' es OBLIGATORIO aquí
            // para distinguir uno del otro.
            this.Nombre = nombre;

            // Al nacer, el nodo todavía no está enganchado a nadie.
            // Será trabajo de ListaCircular.Agregar() conectarlo al ciclo.
            this.Sgte = null;
        }
    }
}
