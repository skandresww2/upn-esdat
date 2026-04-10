using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio4
{
    internal class ListaCircular
    {
        // En una lista circular, solo necesitamos saber quién es el primero (el punto de partida).
        public Nodo inicio;

        public ListaCircular()
        {
            inicio = null;
        }

        // --- MÉTODO: INSERTAR AL FINAL MANTENIENDO EL CÍRCULO ---
        public void Insertar(int valor)
        {
            Nodo nuevo = new Nodo(valor);

            // CASO A: La ronda está vacía (no hay nadie).
            if (inicio == null)
            {
                inicio = nuevo; // El nuevo nodo es el punto de partida.

                // ¡AQUÍ ESTÁ LA MAGIA CIRCULAR INICIAL!
                // Como está solo, se agarra la mano a sí mismo.
                nuevo.siguiente = inicio;
            }
            // CASO B: Ya hay nodos en la ronda.
            else
            {
                // Necesitamos un puntero auxiliar para recorrer la ronda hasta encontrar al ÚLTIMO.
                Nodo puntero = inicio;

                // ¿Cómo sabemos quién es el último en un círculo? 
                // Es aquel cuya mano 'siguiente' apunta de regreso al 'inicio'.
                // (¡Ojo! Ya no buscamos != null, porque aquí no hay nulls).
                while (puntero.siguiente != inicio)
                {
                    puntero = puntero.siguiente; // Avanzamos de nodo en nodo
                }

                // Una vez que el 'puntero' está parado en el último nodo:
                // 1. El último suelta al 'inicio' y agarra al 'nuevo'.
                puntero.siguiente = nuevo;

                // 2. El 'nuevo' cierra el círculo agarrando al 'inicio'.
                nuevo.siguiente = inicio;
            }
        }

        // --- MÉTODO: RECORRER Y MOSTRAR ---
        public void Mostrar()
        {
            // Validamos que la lista no esté vacía.
            if (inicio == null)
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }

            Nodo puntero = inicio;

            // Usamos un 'do-while' (hacer-mientras) obligatoriamente.
            // Si usáramos un 'while (puntero != inicio)', el ciclo NUNCA empezaría, 
            // porque al arrancar, el puntero ES exactamente igual al inicio.
            do
            {
                Console.Write($"[{puntero.dato}] -> "); // Imprimimos el dato
                puntero = puntero.siguiente;            // Avanzamos al siguiente nodo

            } while (puntero != inicio); // Nos detenemos justo cuando damos la vuelta completa

            Console.WriteLine("(Regresa al inicio)");
        }

        // --- MÉTODO: EVALUAR Y SEPARAR EN DOS LISTAS NUEVAS ---
        // Recibe las dos listas vacías que crearemos en el Programa Principal.
        public void SepararParesImpares(ListaCircular listaPares, ListaCircular listaImpares)
        {
            if (inicio == null) return;

            Nodo puntero = inicio;

            // Damos una vuelta completa al círculo principal
            do
            {
                // Evaluamos: Si el residuo de dividir entre 2 es 0, es PAR.
                if (puntero.dato % 2 == 0)
                {
                    // Lo insertamos en la instancia de listaPares
                    listaPares.Insertar(puntero.dato);
                }
                else
                {
                    // Si no es 0, es IMPAR. Lo insertamos en la instancia de listaImpares
                    listaImpares.Insertar(puntero.dato);
                }

                puntero = puntero.siguiente; // Avanzamos al siguiente número a evaluar

            } while (puntero != inicio); // Terminamos cuando damos la vuelta
        }
    }
}
