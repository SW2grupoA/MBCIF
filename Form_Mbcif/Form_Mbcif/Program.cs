using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace Form_Mbcif
{
    static class Program
    {        

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 ventanaPrincipal = new Form1();
            Application.Run(ventanaPrincipal);
        }
    }
}
