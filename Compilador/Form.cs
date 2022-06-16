using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using ListViewItem = System.Windows.Forms.ListViewItem;
using MessageBox = System.Windows.Forms.MessageBox;
using System.Collections; 
using System.Linq;
using System.Text;

namespace Arbol
{
    /// <summary>
    /// VENTANA PRINCIPAL DE LA APLICACIÓN 
    /// </summary>
    /// <Autores>
    /// Roberto Esquivel Troncoso - 19130519 
    /// Ivan Herrera Garcia - 19130535
    /// Fatima Gorety Garcia Yescas - 19130527
    /// Isaias Gerardo Cordova Palomares - 19130514
    /// Raul Galindo Sanches - 18130553
    /// </Autores>
    /// <Fecha> 11/03/2022</Fecha>
    /// <FechaModificación> 03/04/2022</FechaModificación>
    /// <NOTAModificación>Se movió el código a sus respectivas clases y se documento </NOTAModificación>
    //************************************************************************************************************
    // Para mas informacion contactar a robertoesquiveltr16@gmail.com
    //************************************************************************************************************
    public partial class Form : System.Windows.Forms.Form
    {

        #region VARIABLES LOCALES 
        //VARIABLES USADAS EN EL FROM PRINCIPAL
        #endregion

        #region Inicialización de componentes 
        public Form()
        {
            InitializeComponent();
        }
        #endregion

        #region Analizador Lexico
        private void button1_Click(object sender, EventArgs e)
        {
        }
        #endregion 

        #region Seleccion de lenguaje FERIR 
        private void radioBtnFERIR_CheckedChanged(object sender, EventArgs e)
        {
        }
        #endregion

        #region Seleccion de lenguaje Java 
        private void radioBtnJava_CheckedChanged(object sender, EventArgs e)
        {
        }
        #endregion

        #region Codigo Fuente
        private void PagCodigo_TextChanged_1(object sender, EventArgs e)
        {
        }
        #endregion

        #region ComboBox selección de linea para la creación de árbol
        private void cmboxCodigoFuente_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region Analizador sintáctico
        private void button2_Click(object sender, EventArgs e)
        {
        }
        #endregion

        #region Analisis Semantico (Tabla de errores)
        private void btnAnalisisSemantico_Click(object sender, EventArgs e)
        {
           
        }
        #endregion

        #region Tabla de Errores
        private void button3_Click(object sender, EventArgs e)
        {
        }
        #endregion

        #region Conversor Decimal->Binario
        private void btnConver1_Click(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region Conversor Binario->Decimal signo 
        private void btnConver2_Click(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region Selección de conversión binaria con signo o sin signo
        private void cboxSignoDecimal_CheckedChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region Conversor Flotante->Binario
        private void btnConver3_Click(object sender, EventArgs e)
        {
          
        }
        #endregion

        #region Conversor Binario->Flotante 
        private void btnConver4_Click(object sender, EventArgs e)
        {
           
        }
        #endregion

        #region Cuadruplos 
        private void btnCuadruplo_Click(object sender, EventArgs e)
        {
           
        }
        #endregion

        #region Tres Direcciones 
        private void btnTresDirecciones_Click(object sender, EventArgs e)
        {
           
        }
        #endregion

        #region Generar Arbol
        private void btnGenerar_Click(object sender, EventArgs e)
        {
        }
        #endregion

        #region Codigo Objeto
        private void btnEnsamblador_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Ejemplo Codigos
        private void btnEjemplo_Click(object sender, EventArgs e)
        {
            string ejemplo = "";
            if (radioBtnJava2.Checked) {
                ejemplo += "public class Main {\r\n" +
                           "int val = 0;\r\n" +
                           "public static void main(String[] args){\r\n" +
                            "if(val < 10){\r\n" +
                            "sums();\r\n" +
                            "}\r\n" +
                            "else{\r\n" +
                            "subtractions();\r\n" +
                            "}\r\n" +
                            "}\r\n" +
                            "Int sums(){\r\n" +
                            "for( int i = 0; i < 10;i = i + 1){\r\n" +
                            "val = i + 1;\r\n" +
                            "}\r\n" +
                            "return val;\r\n" +
                            "}\r\n" +
                            "Int subtractions(){\r\n" +
                            "int i = 0;\r\n" +
                            "while(i>10){\r\n" +
                            "val = i - 2;\r\n" +
                            "i = i + 1;\r\n" +
                            "}\r\n" +
                            "return val;\r\n" +
                            "}\r\n" +
                            "}";
                PagCodigo.Text = ejemplo;
            }
            if (radioBtnFERIR2.Checked) 
            {
                ejemplo += "publico clase Principal {\r\n" +
                           "entero val = 0;\r\n" +
                           "publico estatico vacio principal(String[] args){\r\n" +
                           "si(val < 10){\r\n" +
                            "sumas();\r\n" +
                            "}\r\n" +
                            "contrario{\r\n" +
                            "restas();\r\n" +
                            "}\r\n" +
                            "}\r\n" +
                            "Entero sumas(){\r\n" +
                            "por( int i = 0; i < 10;i = i + 1){\r\n" +
                            "val = i + 1;\r\n" +
                            "}\r\n" +
                            "regresa val;\r\n" +
                            "}\r\n" +
                            "Entero restas(){\r\n" +
                            "entero i = 0;\r\n" +
                            "mientras(i>10){\r\n" +
                            "aux = i - 2;\r\n" +
                            "i = i + 1;\r\n" +
                            "}\r\n" +
                            "regresa val;\r\n" +
                            "}\r\n" +
                            "}";
                PagCodigo.Text = ejemplo;
            }
        }
        #endregion

        private void radioBtnJava2_CheckedChanged(object sender, EventArgs e)
        {
            // Color del boton Ejemplo
            btnEjemplo.BackColor = Color.FromArgb(248, 132, 216); // color boton ejemplo
        }

        private void radioBtnFERIR2_CheckedChanged(object sender, EventArgs e)
        {
            // Color del boton Ejemplo
            btnEjemplo.BackColor = Color.FromArgb(132, 229, 248); // Y se agregan al list view
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Boton que despliega una ventana emergente con informacion a cerca del compilador
            MessageBox.Show("Integrantes:\n  Roberto Esquiverl Troncoso" +
               "\n  Fatima Gorety Garcia Yescas" +
               "\n  Ivan Herrera Garcia" +
               "\n  Isaias Gerardo Cordova Palomares" +
               "\n  Raul Galindo Sanchez" +
               "\n" +
               "\nCompilador realizado para la materia:" +
               "\n  Lenguajes y Automatas II" +
               "\n" +
               "\nSemestre:" +
               "\n      Enero - Junio 2022" +
               "\n" +
               "\nDocente:" +
               "\n  Gerardo Alejandro Ornelas Guerrero", "Acerca del compilador");
        }

        private void txtLenguaje_TextChanged(object sender, EventArgs e)
        {

        }

        private void listViewToken_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listViewError_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmBoxSigno_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
