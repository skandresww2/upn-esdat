using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    // Esta clase actúa como nuestro "molde" o "paquete".
    // En lugar de guardar un simple número o texto en el nodo, 
    // guardaremos un objeto completo con múltiples datos.
    internal class Persona
    {
        public string Nombre;
        public int Edad;
        public double Estatura;

        // El constructor nos obliga a dar estos 3 datos 
        // cada vez que "nazca" una nueva Persona.
        public Persona(string nombre, int edad, double estatura)
        {
            this.Nombre = nombre;
            this.Edad = edad;
            this.Estatura = estatura;
        }
    }
}
