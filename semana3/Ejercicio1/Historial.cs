using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1
{
    // Esta clase ENCAPSULA la lista doblemente enlazada completa.
    // No guarda los datos directamente: solo guarda referencias a los nodos clave.
    internal class Historial
    {
        // Propiedad pública que apunta al PRIMER nodo de la lista.
        // El truco "{ get; private set; }" significa:
        //   - get público: cualquiera puede LEER historial.Inicio
        //   - set privado: solo el código DENTRO de Historial puede ESCRIBIRLO
        // Así el formulario puede recorrer la lista pero no puede romperla por accidente.
        public Nodo Inicio { get; private set; }

        // Propiedad que apunta al nodo donde el usuario está parado AHORA MISMO.
        // Es el equivalente al "tú estás aquí" de un mapa: indica qué página
        // del historial se está mostrando en pantalla.
        // También { get; private set; } para que solo Historial pueda moverlo.
        public Nodo Actual { get; private set; }

        // Constructor de Historial. Se ejecuta cuando hacemos "new Historial()".
        public Historial()
        {
            // Al crear un historial nuevo, está vacío: no hay primer nodo,
            // ni hay nodo actual. Ambas referencias arrancan en null.
            // Esto es importante para los casos borde de Visitar(), Atras() y Adelante().
            Inicio = null;
            Actual = null;
        }

        // Método que registra una nueva URL visitada.
        // La inserta al FINAL de la lista y mueve el puntero Actual a ella.
        public void Visitar(string url)
        {
            // Creamos un nuevo nodo con la URL recibida.
            // Sus punteros Ant y Sgte ya quedaron en null gracias al constructor de Nodo.
            Nodo nuevo = new Nodo(url);

            // === CASO 1: la lista está vacía ===
            // Si Inicio es null, significa que todavía no hay ningún nodo en la lista.
            if (Inicio == null)
            {
                // El nodo recién creado se convierte en el primero de la lista.
                Inicio = nuevo;

                // También se convierte en el actual, porque es la única página existente.
                Actual = nuevo;

                // 'return' corta la ejecución del método: no hace falta seguir
                // porque ya terminamos de insertar en este caso.
                return;
            }

            // === CASO 2: la lista ya tiene nodos ===
            // Necesitamos llegar al ÚLTIMO nodo para enganchar el nuevo después de él.

            // Creamos un puntero auxiliar 'ultimo' parado en el primer nodo.
            // OJO: usamos un auxiliar para no perder la referencia a Inicio.
            // Nunca, nunca, NUNCA muevas Inicio directamente: la lista se perdería.
            Nodo ultimo = Inicio;

            // Recorremos la lista avanzando con el puntero Sgte.
            // El bucle termina cuando 'ultimo.Sgte' es null,
            // lo cual significa que 'ultimo' está parado en el último nodo.
            while (ultimo.Sgte != null)
                ultimo = ultimo.Sgte;   // movemos el auxiliar un paso adelante

            // Ahora 'ultimo' apunta al último nodo. Hacemos las DOS conexiones:

            // (1) El que era el último ahora apunta hacia adelante al recién creado.
            ultimo.Sgte = nuevo;

            // (2) El recién creado apunta hacia atrás al que era el último.
            // Esta segunda asignación es lo que hace a la lista DOBLE.
            // Si la olvidaras, no podrías retroceder más allá del nodo nuevo.
            nuevo.Ant = ultimo;

            // Movemos el puntero Actual al nodo recién insertado.
            // Es lo que el navegador hace: cuando visitas una página nueva,
            // esa es la que estás viendo.
            Actual = nuevo;
        }

        // Método para retroceder en el historial (botón "← Atrás").
        // Devuelve true si se pudo retroceder, false si ya estamos en el inicio.
        public bool Atras()
        {
            // Validamos DOS condiciones, y ambas son obligatorias:
            //   1) Actual != null  -> evita NullReferenceException si la lista está vacía
            //   2) Actual.Ant != null -> evita retroceder más allá del primer nodo
            if (Actual != null && Actual.Ant != null)
            {
                // Movemos el puntero Actual UN paso hacia atrás.
                // Esto es O(1): instantáneo, sin importar cuán larga sea la lista.
                // Esa es la magia de tener el puntero Ant.
                Actual = Actual.Ant;

                // Le avisamos al formulario que sí se pudo retroceder.
                return true;
            }

            // Si entramos aquí es porque no se pudo retroceder
            // (lista vacía o ya estábamos en la primera página).
            return false;
        }

        // Método para avanzar en el historial (botón "Adelante →").
        // Es la imagen espejo de Atras(), usando Sgte en vez de Ant.
        public bool Adelante()
        {
            // Mismas dos validaciones, pero mirando hacia adelante.
            if (Actual != null && Actual.Sgte != null)
            {
                // Movemos el puntero un paso hacia adelante. También O(1).
                Actual = Actual.Sgte;
                return true;
            }
            return false;
        }
    }
}
