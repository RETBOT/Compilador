using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arbol
{
    /// <summary>
    /// Clase para generar binario positivo, negativo y con punto flotante
    /// </summary>
    /// <Autores>
    /// Roberto Esquivel Troncoso - 19130519 
    /// Ivan Herrera Garcia - 19130535
    /// Fatima Gorety Garcia Yescas - 19130527
    /// Isaias Gerardo Cordova Palomares - 19130514
    /// Raul Galindo Sanches - 18130553
    /// </Autores>
    /// <Fecha> 03/04/2022 </Fecha>
    //************************************************************************************************************
    // Para mas informacion contactar a robertoesquiveltr16@gmail.com
    //************************************************************************************************************

    public class Binarios
    {
         #region DecimalBinario
        // Decimal a Binario
        public static string DecBin(string valor)
        {
            // Obtenemos el módulo de 2 del dígito
            // Multiplicamos ese número por 10 elevado al índice correspondiente
            // Lo sumamos al total
            // Dividimos el número entre 10
            // Se repite el proceso hasta llegar al 0 
            String numeroS = valor;
            int numero = Convert.ToInt32(numeroS);
            long binario = 0; // RETBOT
            const int DIVISOR = 2;
            long digito = 0;

            for (int i = numero % DIVISOR, j = 0; numero > 0; numero /= DIVISOR, i = numero % DIVISOR, j++)
            {
                digito = i % DIVISOR;
                binario += digito * (long)Math.Pow(10, j);
            }// RETBOT

            // Después de obtener el binario, verificamos que la cantidad de dígitos del binario sea correcto
            // se divide la cantidad de bit por 1 byte
            // se redondea el número 
            // se hace el ciclo para rellenar los 0 que faltan
            // y se retorna el valor dado

            string binarioS = binario.ToString();

            double num = binarioS.Length / 8.0;
            num = Math.Ceiling(num);

            for (int i = binarioS.Length; i < 8 * num; i++)
            {
                binarioS = "0" + binarioS;
            }// RETBOT

            return binarioS;
        }

// RETBOT
        // Decimal a Binario con signo
        public static string DecBinSigno(int numero)
        {
            // Obtenemos el módulo de 2 del dígito
            // Multiplicamos ese número por 10 elevado al índice correspondiente
            // Lo sumamos al total
            // Dividimos el número entre 10
            // Se repite el proceso hasta llegar al 0
            long binario = 0;

            const int DIVISOR = 2;
            long digito = 0;

            for (int i = numero % DIVISOR, j = 0; numero > 0; numero /= DIVISOR, i = numero % DIVISOR, j++)
            {
                digito = i % DIVISOR;
                binario += digito * (long)Math.Pow(10, j);
            }
            // Después de obtener el binario, verificamos que la cantidad de dígitos del binario sea correcto
            // se divide la cantidad de bit por 1 byte
            // se redondea el número 
            // se hace el ciclo para rellenar los 0 que faltan y se pone el primer 1 bit indicando el signo negativo
            // y se retorna el valor dado
// RETBOT
            string binarioS = binario.ToString();

            double num = binarioS.Length / 8.0;
            num = Math.Ceiling(num);

            for (int i = binarioS.Length; i < 8 * num - 1; i++)
            {
                binarioS = "0" + binarioS;
            }
            binarioS = "1" + binarioS;// RETBOT

            return binarioS;
        }

        // Binario a Decimal
        public static int BinDec(string bin)
        {
            char[] array = bin.ToCharArray();
            // Invertido pues los valores van incrementandose de derecha a izquierda: 16-8-4-2-1
            Array.Reverse(array);
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {// RETBOT
                if (array[i] == '1')
                {
                    // Usamos la potencia de 2, según la posición
                    sum += (int)Math.Pow(2, i);
                }
            }// RETBOT
            return sum;
        }
        #endregion

         #region Decimal->Binario
        public static string DecimalBinarioSigno(string bin2)
        { // RETBOT
            string bin = Binarios.DecBinSigno(Convert.ToInt32(bin2));
            char[] array = bin.ToCharArray(); // se usa un arreglo de char para separar los datos 
            string resu = "";
            resu += array[0]; // se concatena el primer valor 
            for (int i = 1; i < array.Length; i++) // se cambian los 1 por 0 y los 0 por 1 
            { // RETBOT
                if (array[i] == '1') // si es 1, se cambia a 0 
                {
                    resu += '0';
                }
                else if (array[i] == '0')// si es 0, se cambia a 1
                {
                    resu += '1';
                } // RETBOT
            }
            return Binarios.DecBin(Convert.ToInt32(Binarios.BinDec(resu) + 1)+"") ; // al resultado se le convierte a decimal, se le suma uno y se vuelve a convertir a binario
        } // RETBOT
        #endregion

        #region Binario->Decimal
        public static string BinarioDecimalSigno(string bin2, TextBox txtBin2)
        {
            string bin = Binarios.DecBin(Convert.ToInt32(Binarios.BinDec(bin2)-1)+"");
            char[] array = bin.ToCharArray(); // se usa un arreglo de char para separar los datos 
            string resu = "", signo = "";
            if (txtBin2.Text[0] == '1')  // si el primer valor del arreglo es un 1, indica que es de signo negativo
            {
                signo = "-";// RETBOT
            }
            else if (txtBin2.Text[0] == '0') // si no, entonces es un 0 e indica que es de signo positivo
            {
                signo = "+";
            }

            // se hace un ciclo para cambiar los 1 por 0 y los 0 por 1 
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == '1') // si es 0, se cambia por 1 
                {
                    resu += '0';
                }
                else if (array[i] == '0') // si es 1, se cambia por 0
                {
                    resu += '1';// RETBOT
                }
            }
            return signo + BinDec(resu) + ""; // se concatena el signo y se convierte de binario a decimal
        }
        #endregion

        #region Flotante->Binario
        public static void flotanteBinario(string flotante, TextBox txtMatriza1, TextBox txtExponente1)
        {
            string resu = "";
            char[] array = flotante.ToCharArray(); // se separan los datos 
            int expo = 0; // exponente del flotante
// RETBOT
            for (int i = 0; i < array.Length; i++)
            { // se hace un ciclo para ver en donde se encuentra el punto decimal 
                if (array[i] == '.') // si encuentra el punto 
                {
                    expo = (array.Length - 1) - i; // Guarda la posición 
                }
                else// RETBOT
                {
                    resu += array[i]; //  lo demás lo va concatenando al resultado 
                }
            }
            txtMatriza1.Text = DecBin(Int32.Parse(resu)+""); // se pone la matiza 

            string bin = DecBinSigno(Convert.ToInt32(expo)); // Convierte de decimal a binario con signo 
            char[] array2 = bin.ToCharArray(); // se separan los datos en un arreglo de char 
            string resu2 = "";// RETBOT
            resu2 += array2[0]; //se concantena el primer valor del arreglo 
            for (int i = 1; i < array2.Length; i++) // se recorre el arrelgo y se cambian los 1 por 0 y los 0 por 1 
            {
                if (array2[i] == '1') // se cambia el 1 por 0 
                {
                    resu2 += '0';
                }
                else if (array2[i] == '0') // y el 0 por 1 
                {
                    resu2 += '1';// RETBOT
                }
            }
            txtExponente1.Text = DecBin(Convert.ToInt32(BinDec(resu2) + 1)+""); // se convierte de binario a decimal y se le suma uno, después se convierte de decimal a binario 
        }
        #endregion

        #region Binario->Flotante
        public static void binarioFlotante(TextBox txtMatriza2, TextBox txtExponente2, TextBox txtFlotante2)
        {
            string matriza = BinDec(txtMatriza2.Text) + ""; // se combierte de binario a decimal y se obtiene la matriza 

            string bin = DecBin(Convert.ToInt32(BinDec(txtExponente2.Text) - 1) + ""); // Se convierte de binario a decimal y se resta 1, después se vuelve a convertir a binario
            char[] array = bin.ToCharArray(); // se separan los datos en un arreglo de char
            string resu = "";

            for (int i = 0; i < array.Length; i++) // se cambian los 1 por 0 y los 0 por 1 
            {
                if (array[i] == '1') // el 1 por 0 
                {
                    resu += '0';// RETBOT
                }
                else if (array[i] == '0') // y el 0 por 1 
                {
                    resu += '1';
                }
            }
            int exponente = BinDec(resu); // se obtiene el exponente 

            char[] array2 = matriza.ToCharArray();// Después separamos la matiza en un arreglo 
            string resultado = "";// RETBOT

            for (int i = array2.Length, j = 0; i >= 0; i--)
            { // Se recorre el arreglo y se pone el punto decimal 
                if (i == exponente) // Cuando encuentre la posición del exponente, pone el punto 
                {
                    resultado += '.';
                }
                else // Si no, concatena en el resultado 
                {// RETBOT
                    resultado += array2[j++];
                }
            }

            txtFlotante2.Text = resultado; // se pone el resultado en el textBox
        }
        #endregion
  }
}
