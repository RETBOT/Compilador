using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Clase para los Cuádruplos
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
namespace Arbol
{
    public class Cuadruplos
    {
        #region Cuadruplos
        public static void cuadruplos(ListViewItem lista)
        {// RETBOT
            int p = TresDir.colaExpresion.Count; // cantidad de divisiones de la línea 
            string resultado = "", operador = "", P1 = "", P2 = ""; // variables para almacenar los datos de la tabla 
            bool opIgual = false; // si solo contiene el operador de igual 
            bool opOtro = false; // si contiene otro signo además del operador igual se utiliza el segundo operador
            string otro = ""; // almacena lo sobrante para despues usarlo en los argumentos 
            string texto = "";
            for (int i = 0; i < p; i++)
            {
                string token = (string)TresDir.colaExpresion.Dequeue(); // saca el primer token 

                if (token.Contains("=")) // si solo contiene el operador de igual, se agrega 
                {
                    operador = token;
                    opIgual = true;
                    if (resultado.Equals(string.Empty))
                    {
                        resultado = otro;// RETBOT
                        otro = "";
                    }// RETBOT
                }
                else // busca otro operador, en caso de tenerlo, cambia el operador por el usado 
                {
                    for (int a = 0; a < TresDir.operadores.Length; a++)
                    {
                        if (token.Contains(TresDir.operadores[a]))
                        {
                            operador = token;
                            opIgual = false;
                            opOtro = true;
                            break;// RETBOT
                        }
                    }
                    otro += token;
                    texto += token + " ";
                }
            }

            if (opIgual) // operador igual 
            {
                P1 += otro;
            }// RETBOT
            if (opOtro) // operador diferente a igual 
            {
                bool p1 = true; // utiliza banderas para distinguir entre el P1 y el P2 
                bool p2 = false;
                char[] o = otro.ToCharArray(); // mete todo a un arreglo de char 
                for (int i = 0; i < o.Length; i++)
                { // recorre el arreglo 
                    if (o[i] == char.Parse(operador))
                    { // hasta encontrar el operador 
                        p1 = false; // deja de escribir en el P1 y salta al P2 
                        p2 = true;
                        i++; // quita el operador 
                    }
                    if (p1) // escribe en el P1, hasta encontrar el operador 
                        P1 += o[i];
                    if (p2) // escribe en el P2 
                        P2 += o[i];
                }
            }
            if(!opIgual && !opOtro)
            {
                operador = texto;
            }// RETBOT
            lista.SubItems.Add(operador); // agrega el operador  
            lista.SubItems.Add(P1); // el argumento 1 
            lista.SubItems.Add(P2);  // el argumento 2 
            lista.SubItems.Add(resultado); // el resultado en el list 
        }
        #endregion

    }
}
