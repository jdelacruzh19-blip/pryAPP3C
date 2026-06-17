using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using pryAPP3C.holamundo;//esto es para agregar una formulario o cosas de otro 
//carpeta en un solo proyecto
using pryAPP3C.cafeteria;
using pryAPP3C.Expendedora;

namespace pryAPP3C
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormPrincipal());
        }
    }
}
