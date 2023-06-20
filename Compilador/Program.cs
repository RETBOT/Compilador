using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arbol
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación. 
        /// </summary>
        /// <Autores> 
        /// Roberto Esquivel Troncoso 19130519 
        /// Ivan Herrera Garcia 19130535
        /// Fatima Gorety Garcia Yescas - 19130527
        /// Isaias Gerardo Cordova Palomares 19130514
        /// Raul Galindo Sanches - 18130553
        /// </Autores>
        /// <Fecha> 11/03/2022</Fecha>
        //************************************************************************************************************
        // Para mas informacion contactar a robertoesquiveltr16@gmail.com
        //************************************************************************************************************
        [STAThread]
        static void Main()
        { // RETBOT
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form());
        }
    }
}
