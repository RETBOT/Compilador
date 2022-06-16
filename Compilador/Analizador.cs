using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arbol
{
    /// <summary>
    /// Clase para el proceso de analizar el código
    /// </summary>
    /// <Autores>
    /// Roberto Esquivel Troncoso - 19130519 
    /// Ivan Herrera Garcia - 19130535
    /// Fatima Gorety Garcia Yescas - 19130527
    /// Isaias Gerardo Cordova Palomares - 19130514
    /// Raul Galindo Sanches - 18130553
    /// </Autores>
    /// <Fecha> 03/04/2022 </Fecha>
    class Analizador
    {

        //************************************************************************************************************
        // Para mas informacion contactar a robertoesquiveltr16@gmail.com
        //************************************************************************************************************

        #region EVENTOS 

        #region MÉTODOS PARA EL ANALIZADOR LÉXICO

        /// <summary>
        /// Método para dividir el texto en líneas
        /// </summary>
        /// <param name="cmboxCodigoFuente">Selección de código línea por línea</param>
        /// <param name="PagCodigo">TextBox para introducir el Código Fuente</param>
        /// <param name="contenido">Almacena el resultado de la división del código fuente</param>
        public static void dividirTextoxLinea(ComboBox cmboxCodigoFuente, TextBoxBase PagCodigo, List<String> contenido)
        {
        }
        #endregion
        /// <summary>
        /// Método para dividir en bloques léxicos
        /// </summary>
        public void bloquesLexico(ListView listViewToken, List<string> palabrasReservadas, bool titulos, RegexLexer csLexer, List<String> contenido, Stack pilaLexico)
        {
        }
        /// <summary>
        /// Método para retornar la precedencia de los operadores 
        /// </summary>
        public static bool precedenciadeoperadores(char top, char p_2)
        {
            return true;
        }
        /// <summary>
        /// Método para pasar de infijo a posfijo
        /// </summary>
        public static string PasarStringPosfijo(string stringeninfijo)
        {
            return ""; // al final regregresa la cadena posfija 
        }

        /// <summary>
        /// //SE PENSABA USAR PARA VERIFICAR LAS EXPRESIONES
        /// </summary>
        public static void verificarExp(int linea)
        {
            
        }
        /// <summary>
        ///  Método para llenar la pila de los operadores 
        /// </summary>
        public static void llenarPilaOperandos(int linea, string texto, Stack pilaOp, Stack pilaOpInv)
        {
        }

        /// <summary>
        /// METODO PARA INSERTAR EN NODO
        /// </summary>
        public static void Insertar(Nodo ar, string cad)
        {
        }

        /// <summary>
        /// METODO PARA VERIFICAR LAS LLAVES Y LOS PARENTESIS 
        /// </summary>
        public static bool analizaLlaves(ListView listViewError, List<String> contenido)
        {
            return true;
        }
        /// <summary>
        /// METODO PARA analizar el codigo 
        /// </summary>
        public static void AnalizeCode(string texto, int indiceT, string tablaPadre, ListView listViewToken, List<string> palabrasReservadas, bool titulos, RegexLexer csLexer)
        {
        }
        /// <summary>
        /// MÉTODO PARA LAS PALABRAS RESERVADAS
        /// </summary>
        public static void llamada(string codigo, RadioButton radioBtnJava, RadioButton radioBtnFERIR, PictureBox pbImagen, List<string> palabrasReservadas, string cadena, Arbol arbol, Nodo raiz, Grafico grafico)
        {
        }
        /// <summary>
        /// FUNCION PARA VISUALIZAR IMAGEN EN EL PROGRAMA EN TIEMPO REAL
        /// SE TIENE QUE CAMBIAR LA UBICACION DE LA RUTA CADA VEZ QUE SE EJECUTE EN EQUIPOS DIFERENTES
        /// EL ARCHIVO IMAGEN.PNG ES UN ARCHIVO VACIO EN EL CUAL SE SOBRE ESCRIBE CADA VEZ QUE SE CLICKLEA EL BOTON EJECUTAR
        /// </summary>
        public static void ShowTree(PictureBox pbImagen)
        {
        }
        /// <summary>
        /// MÉTODO PARA VERIFICAR EL CÓDIGO FUENTE INTRODUCIDO 
        /// </summary>
        private void PagCodigo_TextChanged(object sender, EventArgs e, ListView listViewToken, TextBoxBase PagCodigo, ComboBox cmboxCodigoFuente, bool load, List<string> palabrasReservadas, bool titulos, RegexLexer csLexer, List<String> contenido)
        { 

        }
        #endregion

        //************************************************************************************************************
        // VERIFICACION DE ERRORES 
        //************************************************************************************************************

        #region MÉTODOS PARA VERIFICACIÓN DE ERRORES LÉXICOS Y SINTÁCTICOS

        /// <summary>
        /// MÉTODO PARA ANALIZAR LOS ERRORES SINTÁCTICOS Y LÉXICOS DEL CÓDIGO
        /// </summary>
        public static void comprobarExpresionAlgebraica(List<String> contenido, Stack pilaOp, Stack pilaOpInv)
        {

        }
        /// <summary>
        /// MÉTODO PARA ANALIZAR LOS ERRORES SINTÁCTICOS Y LÉXICOS DEL CÓDIGO
        /// </summary>
        public static void lexico(ListView listViewError, List<String> contenido)
        {
        }
        #endregion
    }
}
