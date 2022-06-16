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
        #endregion

        #region CONSTRUCTORES
        //CONSTRUCTOR QUE RECIBE UN PARAMETRO DEL TIPO NODO
        public Grafico(Nodo arbol) {
        }
        #endregion

        #region FUNCIONES PARA GRAFICO
        /// <summary>
        /// Método que nos permite dibujar el arbol.
        /// </summary>

        public void DrawTree() {
            // DIBUJA EL ARBOL
        }

        /// <summary>
        ///  Método para crear el archivo donde se genera el árbol.
        /// </summary>
        /// <return> Regresa el valor de la cadena</return>
        private string CreateFileDot() {
            return "";
        }

        /// <summary>
        /// Método que nos permite iniciar con el archivo donde se esta generando el gráfico.
        /// </summary>
        /// <param name="arbol">Es el nodo del árbol.</param>
        /// <param name="cadenaDot">Es la referencia donde se esta creando el gráfico segun sus propiedades.</param>
        private void StartFileDot(Nodo arbol, ref string cadenaDot) {
        }

        /// <summary>
        /// Método que nos permite realizar el recorrido del árbol. 
        /// </summary>
        /// <param name="arbol">Es el nodo del árbol.</param>
        /// <param name="cadenaDot">Es la referencia donde se esta creando el gráfico segun sus propiedades.</param>
        private void Recorrido(Nodo arbol, ref string cadenaDot) { 
        }

        /// <summary>
        /// Método que nos permite ejecutar el proceso para que el cmd nos genere el archivo imagen. 
        /// </summary>
        private void ExecuteDot() {
        }
        #endregion 
    }
}