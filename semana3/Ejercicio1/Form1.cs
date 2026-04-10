using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio1
{
    // ===== Código del formulario (Form1.cs) =====
    public partial class Form1 : Form
    {
        // Creamos UNA sola instancia del historial cuando nace el formulario.
        private Historial historial = new Historial();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        //La Ejecución(El llamado): C# lee la instrucción y ve historial.Atras(). Al ver los paréntesis (), dice: "¡Ajá! Esto es una orden". En ese mismo milisegundo, el programa "pausa" el formulario, salta a la clase Historial y ejecuta todo el código que está dentro del método Atras() (es decir, mueve el puntero Actual hacia atrás).

        //El Retorno(El resultado) : Una vez que el método termina su trabajo de mover el puntero, regresa al if trayendo consigo un valor(true si logró moverse, o false si estaba en el tope).

        //La Evaluación(El if y el !): Ahora el if dice: "Bueno, el método ya hizo su trabajo y me trajo un false". Luego, el signo de exclamación(!) invierte ese false a true, y recién ahí entra a mostrar el MessageBox.

        // Manejador del botón "← Atrás".
        private void btnAtras_Click(object sender, EventArgs e)
        {
            // Llamamos a Atras() y, si devuelve false (no se pudo retroceder),
            // mostramos un mensaje. El '!' significa "negación": "si NO se pudo".
            if (!historial.Atras())
                MessageBox.Show("No hay páginas anteriores.");

            // Refrescamos la pantalla SIEMPRE, haya retrocedido o no,
            // por consistencia visual.
            ActualizarPantalla();
        }

        // Manejador del botón "Adelante →". Imagen espejo del de Atrás.

        private void btnAdelante_Click(object sender, EventArgs e)
        {
            if (!historial.Adelante())
                MessageBox.Show("No hay páginas siguientes.");

            ActualizarPantalla();
        }

        // Manejador del botón "Visitar".
        // Se ejecuta automáticamente cuando el usuario hace clic en btnVisitar.
        // 'sender' es quién disparó el evento, 'e' trae info adicional. No los usamos.
        private void btnVisitar_Click(object sender, EventArgs e)
        {
            // Validamos que el TextBox no esté vacío ni tenga solo espacios.
            // 'IsNullOrWhiteSpace' devuelve true si la cadena es null, "" o "   ".
            if (string.IsNullOrWhiteSpace(txtUrl.Text))
            {
                // Mostramos una ventana emergente avisando del error.
                MessageBox.Show("Ingrese una URL válida.");

                // 'return' sale del método sin hacer nada más.
                // Así evitamos insertar una URL inválida en el historial.
                return;
            }

            // Llamamos al método Visitar() del historial pasándole el texto del TextBox.
            // '.Trim()' elimina espacios al principio y al final por si el usuario
            // tipeó "  google.com  " sin querer.
            historial.Visitar(txtUrl.Text.Trim());

            // Vaciamos el TextBox para que esté listo para la próxima URL.
            txtUrl.Clear();

            // Devolvemos el cursor al TextBox para que el usuario pueda seguir tipeando
            // sin tener que volver a hacer clic dentro de él.
            txtUrl.Focus();

            // Refrescamos la pantalla (ListBox y Label) para mostrar el nuevo estado.
            ActualizarPantalla();
        }

        // Método privado que vuelve a dibujar el ListBox y la etiqueta
        // para reflejar el estado actual del historial.
        // Este método es la parte más educativa: muestra cómo recorrer
        // una lista enlazada manualmente, usando solo punteros.
        private void ActualizarPantalla()
        {
            // Vaciamos el ListBox antes de volver a llenarlo.
            // Si no lo hiciéramos, las URLs se acumularían encima de las viejas
            // y veríamos duplicados creciendo sin parar con cada clic.
            lstHistorial.Items.Clear();

            // Creamos un puntero auxiliar 'temp' parado en el PRIMER nodo de la lista.
            // Accedemos a 'historial.Inicio' (la propiedad pública solo-lectura).
            // Otra vez la regla: nunca movemos el Inicio directamente,
            // siempre usamos un auxiliar para recorrer.
            Nodo temp = historial.Inicio;

            // Mientras el puntero apunte a un nodo válido, hay trabajo por hacer.
            // Cuando 'temp' valga null significará que pasamos el último nodo
            // y el bucle termina automáticamente.
            while (temp != null)
            {
                // Operador ternario: una forma compacta de escribir un if/else.
                // Lectura: "si temp ES exactamente el mismo objeto que historial.Actual,
                //           usa la flecha; si no, usa tres espacios para alinear."
                // El '==' aquí compara REFERENCIAS (mismo objeto en memoria),
                // no compara contenido. Es justo lo que queremos: marcar la
                // posición del puntero, no buscar URLs iguales.
                string marca = (temp == historial.Actual) ? "→ " : "   ";

                // Agregamos una línea al ListBox concatenando la marca con la URL.
                // Ejemplo de salida: "→ google.com" o "   youtube.com"
                lstHistorial.Items.Add(marca + temp.Url);

                // ¡PASO CRUCIAL! Avanzamos el puntero al siguiente nodo.
                // Si olvidaras esta línea, 'temp' se quedaría en el primer nodo
                // para siempre y tendrías un bucle infinito que cuelga el programa.
                // Es el error más frecuente al recorrer listas enlazadas.
                temp = temp.Sgte;
            }

            // Actualizamos la etiqueta superior con la página actual.
            // Otra vez usamos un operador ternario para manejar el caso "lista vacía":
            //   - Si Actual no es null, mostramos "Página actual: <url>"
            //   - Si Actual es null, mostramos "Sin página actual"
            // Esto evita que historial.Actual.Url truene con NullReferenceException
            // cuando todavía no se ha visitado ninguna página.
            lblActual.Text = (historial.Actual != null)
                ? "Página actual: " + historial.Actual.Url
                : "Sin página actual";
        }

        private void txtUrl_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
