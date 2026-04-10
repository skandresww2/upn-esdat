using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    // Esta clase representa UN solo eslabón de la lista enlazada.
    internal class Nodo
    {
        // Propiedad automática que guarda la URL del nodo.
        // { get; set; } le dice a C# que cree internamente un campo privado
        // y dos métodos: uno para leer (get) y uno para escribir (set).
        // Desde fuera se usa como si fuera una variable normal: nodo.Url = "...";
        public string Url { get; set; }

        // Propiedad que apunta al nodo ANTERIOR de la lista.
        // El tipo "Nodo" es la propia clase: una clase puede contener referencias a sí misma.
        // Esto es lo que permite encadenar nodos formando una lista.
        public Nodo Ant { get; set; }

        // Propiedad que apunta al nodo SIGUIENTE de la lista.
        // Junto con Ant, hace que esta sea una lista DOBLEMENTE enlazada.
        public Nodo Sgte { get; set; }

        // Constructor de la clase Nodo.
        // Un constructor es un método especial que se ejecuta al hacer "new Nodo(...)".
        // Recibe la URL como parámetro y deja el nodo listo para usar.
        public Nodo(string url)
        {
            // Asignamos el parámetro 'url' a la propiedad 'Url' del objeto.
            // Usamos 'this.Url' (con mayúscula) para referirnos a la propiedad del objeto,
            // y 'url' (con minúscula) es el parámetro que llegó al constructor.
            // El 'this.' deja claro cuál es el campo del objeto y cuál es el parámetro.
            this.Url = url;

            // Cuando un nodo recién nace, todavía NO está enganchado a ningún vecino.
            // Por eso ponemos sus dos punteros en null (= "no apunta a nada").
            // Será trabajo de la clase Historial engancharlo en el lugar correcto.
            this.Ant = null;
            this.Sgte = null;
        }
    }
}
