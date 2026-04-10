using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    // ============================================================
    // CLASE LISTACIRCULAR
    // ============================================================
    // Encapsula la lista circular completa. NO guarda los agentes
    // en ninguna colección: solo guarda UN puntero ('turno') que apunta
    // al agente que le toca atender la siguiente llamada.
    // Desde ese puntero, siguiendo los 'Sgte', podemos llegar a todos.
    internal class ListaCircular
    {
        // 'turno' = puntero al agente actual. Es el único campo de la clase.
        // Es privado porque nadie de afuera debe tocarlo directamente:
        // solo los métodos de esta clase saben cómo manipularlo sin romper
        // el círculo.
        private Nodo turno;

        // Constructor: al crear una lista nueva, está vacía.
        public ListaCircular()
        {
            turno = null;
        }

        // ---------- AGREGAR ----------
        // Agrega un agente al final de la lista circular.
        public void Agregar(string nombre)
        {
            // Creamos un nodo nuevo con el nombre recibido.
            // Por ahora su Sgte es null (lo dejó así el constructor de Nodo).
            Nodo nuevo = new Nodo(nombre);

            // === CASO 1: la lista está vacía ===
            if (turno == null)
            {
                // El nuevo agente es el único en la lista.
                // IMPORTANTÍSIMO: debe apuntar a SÍ MISMO con Sgte
                // para que el círculo exista desde el primer momento.
                // Si dejáramos nuevo.Sgte = null, esto sería una lista
                // simple, no circular, y todo se rompería después.
                turno = nuevo;
                nuevo.Sgte = nuevo;
                return;   // terminamos, no hace falta seguir
            }

            // === CASO 2: ya hay agentes en la lista ===
            // Necesitamos llegar al ÚLTIMO nodo del círculo.
            // ¿Quién es el último? El nodo cuyo Sgte apunta de vuelta a 'turno'.
            // (En una lista circular, el último siempre apunta al primero.)
            Nodo ultimo = turno;
            while (ultimo.Sgte != turno)
            {
                ultimo = ultimo.Sgte;
            }

            // Ahora 'ultimo' está parado en el último nodo del círculo.
            // Insertamos el nuevo entre 'ultimo' y 'turno', manteniendo el ciclo.
            ultimo.Sgte = nuevo;   // el antes-último apunta al nuevo
            nuevo.Sgte = turno;    // el nuevo cierra el círculo apuntando al primero

            // Nota: NO movemos 'turno'. El que entra lo hace al final;
            // el primero de la lista sigue siendo el mismo de antes.
        }

        // ---------- ATENDER ----------
        // Atender = el agente actual toma la llamada y el turno avanza al siguiente.
        // Devuelve el nombre del agente que acaba de atender (o null si no había).
        public string Atender()
        {
            // Si la lista está vacía, no hay nadie que atienda.
            if (turno == null) return null;

            // Guardamos el nombre del agente actual ANTES de mover el puntero,
            // porque después de moverlo ya no podríamos recuperarlo fácilmente.
            string atendio = turno.Nombre;

            // Avanzamos el puntero 'turno' UN paso en el círculo.
            // Esta es la ROTACIÓN: el siguiente pasa a ser el actual.
            // Como es una lista circular, después del último viene el primero
            // automáticamente, sin ningún 'if' adicional. Esa es la magia
            // de usar esta estructura para un problema de rotación.
            turno = turno.Sgte;

            // Devolvemos el nombre del que acaba de atender.
            return atendio;
        }

        // ---------- ELIMINAR ----------
        // Elimina el primer agente que coincida con el nombre dado.
        // Devuelve true si lo encontró y lo eliminó, false si no.
        // Este método es el más delicado: hay que mantener el ciclo intacto.
        public bool Eliminar(string nombre)
        {
            // Lista vacía: no hay nada que eliminar.
            if (turno == null) return false;

            // === CASO ESPECIAL 1: solo queda UN agente en la lista ===
            // Lo detectamos porque ese nodo se apunta a sí mismo.
            if (turno.Sgte == turno)
            {
                // Si el único agente coincide con el nombre, la lista queda vacía.
                if (turno.Nombre == nombre)
                {
                    turno = null;
                    return true;
                }
                // Si el único agente no coincide, no hay nada que eliminar.
                return false;
            }

            // === CASO ESPECIAL 2: el que hay que eliminar es el que tiene el turno ===
            // Este caso es delicado porque hay que:
            //   (a) encontrar el último nodo (el que apunta a 'turno'),
            //   (b) reconectarlo al NUEVO inicio (turno.Sgte),
            //   (c) mover 'turno' al siguiente.
            // Si no reconectáramos al último, el círculo se rompería y el
            // último quedaría apuntando a memoria desconectada.
            if (turno.Nombre == nombre)
            {
                Nodo ultimo = turno;
                while (ultimo.Sgte != turno)
                {
                    ultimo = ultimo.Sgte;
                }

                // El último ahora salta al siguiente del actual, cerrando el círculo.
                ultimo.Sgte = turno.Sgte;

                // Movemos 'turno' al que era el siguiente, que ahora toma el lugar.
                turno = turno.Sgte;
                return true;
            }

            // === CASO GENERAL: el agente a eliminar está "en el medio" ===
            // Usamos la técnica de DOS PUNTEROS que avanzan en paralelo:
            //   'previo' va un paso atrás de 'actual'.
            // Así, cuando 'actual' encuentra al que hay que eliminar,
            // 'previo' ya está en posición para "saltárselo".
            Nodo previo = turno;
            Nodo actual = turno.Sgte;

            // Recorremos el círculo. La condición de parada es
            // "volver al punto de partida", NO "llegar a null", porque
            // en una lista circular ningún nodo apunta a null.
            while (actual != turno)
            {
                if (actual.Nombre == nombre)
                {
                    // ¡Encontrado! 'previo' se salta al 'actual', efectivamente
                    // desenganchándolo del círculo. El nodo eliminado queda
                    // huérfano y el recolector de basura de .NET lo limpia solo.
                    previo.Sgte = actual.Sgte;
                    return true;
                }
                // Si no coincide, avanzamos ambos punteros un paso.
                previo = actual;
                actual = actual.Sgte;
            }

            // Recorrimos toda la lista y no encontramos el nombre.
            return false;
        }

        // ---------- MOSTRAR ----------
        // Imprime en consola todos los agentes en orden de rotación,
        // partiendo del que tiene el turno actual.
        public void Mostrar()
        {
            if (turno == null)
            {
                Console.WriteLine("(Lista vacía)");
                return;
            }

            Console.WriteLine("Orden de atención:");

            // Puntero auxiliar que arranca en el turno actual.
            // NUNCA movemos 'turno' directamente: perderíamos el estado de la lista.
            Nodo temp = turno;
            int pos = 1;

            // CLAVE: usamos 'do-while', NO 'while'.
            // ¿Por qué? Porque 'temp' arranca siendo igual a 'turno',
            // entonces un 'while (temp != turno)' NO entraría nunca al bucle.
            // El 'do-while' garantiza que el cuerpo se ejecute AL MENOS una vez,
            // y la condición se evalúa al final de cada iteración.
            do
            {
                // Marcamos con flecha el nodo que tiene el turno actual.
                string marca = (temp == turno) ? " ← TURNO" : "";
                Console.WriteLine($"  {pos}. {temp.Nombre}{marca}");

                // Avanzamos al siguiente nodo del círculo.
                temp = temp.Sgte;
                pos++;

                // El bucle termina cuando 'temp' vuelve a apuntar a 'turno',
                // es decir, cuando dimos una vuelta completa al círculo.
            } while (temp != turno);
        }
    }
}
