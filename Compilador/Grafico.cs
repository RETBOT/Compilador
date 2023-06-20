using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Reflection;


namespace Arbol
{
    /// <summary>
    /// Clase usada para graficar
    /// </summary>
    /// <Autores>
    /// Roberto Esquivel Troncoso 19130519 
    /// Ivan Herrera Garcia 19130535
    /// Fatima Gorety Garcia Yescas 19130527
    /// Isaias Gerardo Cordova Palomares 19130514
    /// Raul Galindo Sanches - 18130553
    /// </Autores>
    /// <Fecha> 11/03/2022</Fecha>
    //************************************************************************************************************
    // Para mas informacion contactar a robertoesquiveltr16@gmail.com
    //************************************************************************************************************
    public class Grafico
    {
        #region CAMPOS DE CLASE
        //VARIABLES USADAS EN LA CLASE GRAFICO
        private Nodo arbol; // --RET--BOT--
        private string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

        private string command = @"/c Batch.bat";
        private int i, j;
        #endregion// --RET--BOT--

        #region CONSTRUCTORES
        //CONSTRUCTOR QUE RECIBE UN PARAMETRO DEL TIPO NODO
        public Grafico(Nodo arbol) {
            this.arbol = arbol;
        }
        #endregion

        #region FUNCIONES PARA GRAFICO
        /// <summary>
        /// Método que nos permite dibujar el arbol.
        /// </summary>

        public void DrawTree() {
            // DIBUJA EL ARBOL
            CreateFileDot();// --RET--BOT--
            ExecuteDot();
        }

        /// <summary>
        ///  Método para crear el archivo donde se genera el árbol.
        /// </summary>
        /// <return> Regresa el valor de la cadena</return>
        private string CreateFileDot() {
            //FUNCION UTILIZADA PARA LA ESCRITURA EN EL ARCHIVO IMAGEN.PNG
            string cadenaDot = "";
            StartFileDot(arbol, ref cadenaDot);
            using (StreamWriter archivo = new StreamWriter(path + @"\Arbol.dot")) {
                archivo.WriteLine(cadenaDot);
                archivo.Close();
            }// --RET--BOT--
            return cadenaDot;
        }

        /// <summary>
        /// Método que nos permite iniciar con el archivo donde se esta generando el gráfico.
        /// </summary>
        /// <param name="arbol">Es el nodo del árbol.</param>
        /// <param name="cadenaDot">Es la referencia donde se esta creando el gráfico segun sus propiedades.</param>
        private void StartFileDot(Nodo arbol, ref string cadenaDot) {
            //FUNCION PARA DEFINIR EL ESTILO Y COLOR DEL DIBUJO
            if (arbol != null) {
                cadenaDot += "digraph Grafico {\nnode [style=blod, fillcolor=gray];\n";
                Recorrido(arbol, ref cadenaDot);
                cadenaDot += "\n}";
            }
        }
// --RET--BOT--
        /// <summary>
        /// Método que nos permite realizar el recorrido del árbol. 
        /// </summary>
        /// <param name="arbol">Es el nodo del árbol.</param>
        /// <param name="cadenaDot">Es la referencia donde se esta creando el gráfico segun sus propiedades.</param>
        private void Recorrido(Nodo arbol, ref string cadenaDot) { 
            // FUNCION QUE DIBUJA LOS TRAZOS QUE VA TENIENDO EL ARBOL
            if (arbol != null) {
                cadenaDot += $"{arbol.Datos}\n";
                if (arbol.NodoIzquierdo != null) {
                    i = arbol.Datos.ToString().IndexOf("[");
                    j = arbol.NodoIzquierdo.Datos.ToString().IndexOf("[");
                    cadenaDot += $"{arbol.Datos.ToString().Remove(i)}->{arbol.NodoIzquierdo.Datos.ToString().Remove(j)};\n";
                }// --RET--BOT--
                if (arbol.NodoDerecho != null)
                {
                    i = arbol.Datos.ToString().IndexOf("[");
                    j = arbol.NodoDerecho.Datos.ToString().IndexOf("[");
                    cadenaDot += $"{arbol.Datos.ToString().Remove(i)}->{arbol.NodoDerecho.Datos.ToString().Remove(j)};\n";
                }
                Recorrido(arbol.NodoIzquierdo, ref cadenaDot);
                Recorrido(arbol.NodoDerecho, ref cadenaDot);
            }
        }

        /// <summary>
        /// Método que nos permite ejecutar el proceso para que el cmd nos genere el archivo imagen. 
        /// </summary>
        private void ExecuteDot() {
            // EJECUTA UN TERMINAL CMD EN LO QUE REALIZA LOS PROCESOS INDICADOS EN EL METODOS
            Directory.SetCurrentDirectory(path);// --RET--BOT--
            using (Process proceso = new Process()) {
                ProcessStartInfo Info = new ProcessStartInfo("cmd",command);
                Info.CreateNoWindow = true;
                proceso.StartInfo = Info;
                proceso.Start();
                proceso.WaitForExit();
                proceso.Close();
            }
        }// --RET--BOT--
        #endregion 
    }
}