using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/// <summary>
/// Clase para generar el codigo objeto
/// </summary>
/// <Autores>
/// Roberto Esquivel Troncoso - 19130519 
/// Ivan Herrera Garcia - 19130535
/// Fatima Gorety Garcia Yescas - 19130527 
/// Isaias Gerardo Cordova Palomares - 19130514
/// Raul Galindo Sanches - 18130553
/// </Autores>
/// <Fecha> 30/05/2022 </Fecha>
/// 
//************************************************************************************************************
// Para mas informacion contactar a robertoesquiveltr16@gmail.com
//************************************************************************************************************
namespace Arbol
{
    public class CodObjeto
    {
        #region CAMPOS DE CLASE
        // VARIABLES LOCALES 
        public static string a = ""; // RETBOT
        #endregion

        #region Generar codigo objeto para JAVA
        public static void codigoObjetoJava(ListView listViewEnsamblador, ListView listViewCuadruplos)
        {
            // Variables 
            string ph = "PUSH ";
            string pp = "POP ";
            string ax = "AX";// RETBOT
            string dx = "DX";
            string mov = "MOV";

            // ciclo para recorrer los cuadruplos 
            for (int i = 0; i < listViewCuadruplos.Items.Count; i++)
            {

                // obtenemos los cuadruplos obtenemos, las etiquetas, operadores, A1, A2 y los resultados 
                string etiqueta = listViewCuadruplos.Items[i].SubItems[0].Text;
                string operador = listViewCuadruplos.Items[i].SubItems[1].Text;
                string A1 = listViewCuadruplos.Items[i].SubItems[2].Text;
                string A2 = listViewCuadruplos.Items[i].SubItems[3].Text;
                string Res = listViewCuadruplos.Items[i].SubItems[4].Text;

                if (A2 != "") // Si A2 es diferente de una cadena vacia 
                {
                    if (etiqueta != "")  // si la etiqueta no esta vacia 
                    {
                        listViewEnsamblador.Items.Add(etiqueta); // la agrega al ensamblador 
                    }// RETBOT
                    // verificamos los operadores 
                    if (operador == "+") // si es una suma 
                    {
                        // metemos a la pila AX y DX 
                        listViewEnsamblador.Items.Add(ph + "AX");
                        listViewEnsamblador.Items.Add(ph + "DX");
                        // movemos el valor de A1 a AX 
                        listViewEnsamblador.Items.Add(mov + " " + ax + ", " + A1);
                        // movemos el valor de A2 a DX 
                        listViewEnsamblador.Items.Add(mov + " " + dx + ", " + A2);
                        // verificamos los operadores 
                        // entonces sumamos AX y DX 
                        listViewEnsamblador.Items.Add("ADD AX, DX");
                        listViewEnsamblador.Items.Add("MOV " + Res + ", AX");
                        // y lo sacamos DX y AX de la pila
                        listViewEnsamblador.Items.Add(pp + "DX");
                        listViewEnsamblador.Items.Add(pp + "AX");
                    }
                    else if (operador == "-") // si es una resta 
                    {
                        // metemos a la pila AX y DX 
                        listViewEnsamblador.Items.Add(ph + "AX");
                        listViewEnsamblador.Items.Add(ph + "DX");
                        // movemos el valor de A1 a AX 
                        listViewEnsamblador.Items.Add(mov + " " + ax + ", " + A1);
                        // movemos el valor de A2 a DX 
                        listViewEnsamblador.Items.Add(mov + " " + dx + ", " + A2);
                        // entonces restamos AX y DX 
                        listViewEnsamblador.Items.Add("SUB AX, DX");
                        listViewEnsamblador.Items.Add("MOV " + Res + ", AX");
                        // y lo sacamos DX y AX de la pila
                        listViewEnsamblador.Items.Add(pp + "DX");
                        listViewEnsamblador.Items.Add(pp + "AX");
                    }// RETBOT
                    else if (operador == "*") // si es una multiplicacion 
                    {
                        // metemos a la pila AX y DX 
                        listViewEnsamblador.Items.Add(ph + "AX");
                        listViewEnsamblador.Items.Add(ph + "DX");
                        // movemos el valor de A1 a AX 
                        listViewEnsamblador.Items.Add(mov + " " + ax + ", " + A1);
                        // movemos el valor de A2 a DX 
                        listViewEnsamblador.Items.Add(mov + " " + dx + ", " + A2);
                        // entonces multiplicamos AX y DX 
                        listViewEnsamblador.Items.Add("MUL AX, DX");
                        listViewEnsamblador.Items.Add("MOV " + Res + ", AX");
                        // y lo sacamos DX y AX de la pila
                        listViewEnsamblador.Items.Add(pp + "DX");
                        listViewEnsamblador.Items.Add(pp + "AX");
                    }
                    else if (operador == "/") // si es una division 
                    {
                        // metemos a la pila AX y DX 
                        listViewEnsamblador.Items.Add(ph + "AX");
                        listViewEnsamblador.Items.Add(ph + "DX");
                        // movemos el valor de A1 a AX 
                        listViewEnsamblador.Items.Add(mov + " " + ax + ", " + A1);
                        // movemos el valor de A2 a DX 
                        listViewEnsamblador.Items.Add(mov + " " + dx + ", " + A2);
                        // dividimos AX y DX 
                        listViewEnsamblador.Items.Add("DIV AX, DX");
                        listViewEnsamblador.Items.Add("MOV " + Res + ", AX");
                        // y lo sacamos DX y AX de la pila
                        listViewEnsamblador.Items.Add(pp + "DX");
                        listViewEnsamblador.Items.Add(pp + "AX");
                    }
                    else// RETBOT
                    {
                        // si no es ningun operador, entonces es un tag 
                        listViewEnsamblador.Items.Add(""); // se agrega un salto 
                        listViewEnsamblador.Items.Add(operador); // y se muestra
                    }
                }
                else
                { // si no 
                    if (etiqueta != "") // verifica que la etiqueta contenga información 
                    {
                        listViewEnsamblador.Items.Add(etiqueta); // le agrega la etiquieta
                    }
                    if (operador.Contains("Call")) // si es un call
                    {
                        listViewEnsamblador.Items.Add(operador); // lo agrega
                    }

                    if (A1 != "") // Si A1 contiene informacion, entonces, como no entro en el primer if,
                                  // solo es una asignacion 
                    {// RETBOT
                        // mete en la pila AX
                        listViewEnsamblador.Items.Add(ph + "AX");
                        // mueve el valor a AX 
                        listViewEnsamblador.Items.Add(mov + " " + ax + ", " + A1);
                        // se le asigna el valor de A1 (AX) a el resultado 
                        listViewEnsamblador.Items.Add("MOV " + Res + ", AX");
                        // y saca de la pila AX
                        listViewEnsamblador.Items.Add(pp + "AX");
                    }

                    if (etiqueta.Contains("goto")) // si contiene un goto 
                    {
                        listViewEnsamblador.Items.Add(""); // se agrega un salto 
                        string et = "";
                        int o;
                        for (o = 0; o < etiqueta.Length; o++) // recorre la etiqueta 
                        {
                            if (!etiqueta[o].Equals(' ')) // concatena hasta llegar a un espacio 
                            {
                                et += etiqueta[o];
                            }
                            else if (et.Contains("goto")) // si este contiene un goto, lo elimina, para buscar despues de el mismo 
                            {
                                et = "";
                            }
                        }
                        listViewEnsamblador.Items.Add("JMP " + et); // y se muestra el goto 
                    }// RETBOT
                }
                // Si contiene un Fin_if
                if (operador.Contains("Fin_if"))
                {
                    if (operador.Contains("menor")) // Si contiene la palabra menor
                    {
                        char[] op = operador.ToArray();
                        listViewEnsamblador.Items.Add("-- If CMP Menor"); // anotacion 
                        listViewEnsamblador.Items.Add("CMP AX,0"); // hace la comparacion con AX 
                        listViewEnsamblador.Items.Add("JB Fin_if" + op[op.Length - 5]); // si menor, va al fin 
                        listViewEnsamblador.Items.Add("JA Ini_if" + op[op.Length - 5]); // si no, al Ini
                    }
                    else if (operador.Contains("menor o igual")) // Si contiene la palabra menor o igual
                    {
                        char[] op = operador.ToArray();
                        listViewEnsamblador.Items.Add("-- If CMP Menor o igual");
                        listViewEnsamblador.Items.Add("CMP AX,0"); // hace la comparacion con AX 
                        listViewEnsamblador.Items.Add("JB Fin_if" + op[op.Length - 5]);// si menor o igual, va al fin 
                        listViewEnsamblador.Items.Add("JA Ini_if" + op[op.Length - 5]); // si no, al Ini
                    }// RETBOT
                    else if (operador.Contains("mayor"))// Si contiene la palabra mayor
                    {
                        char[] op = operador.ToArray();
                        listViewEnsamblador.Items.Add("-- If CMP Mayor");
                        listViewEnsamblador.Items.Add("CMP AX,0");// hace la comparacion con AX 
                        listViewEnsamblador.Items.Add("JB Fin_if" + op[op.Length - 5]);// si mayor, va al fin 
                        listViewEnsamblador.Items.Add("JA Ini_if" + op[op.Length - 5]);// si no, al Ini
                    }
                    else if (operador.Contains("mayor o igual"))// Si contiene la palabra mayor o igual
                    {
                        char[] op = operador.ToArray();
                        listViewEnsamblador.Items.Add("-- If CMP Mayor o igual");
                        listViewEnsamblador.Items.Add("CMP AX,0");// hace la comparacion con AX 
                        listViewEnsamblador.Items.Add("JB Fin_if" + op[op.Length - 5]);// si Mayor o igual, va al fin 
                        listViewEnsamblador.Items.Add("JA Ini_if" + op[op.Length - 5]);// si no, al Ini
                    }// RETBOT
                }
                // Si contiene un Fin_else
                else if (operador.Contains("Fin_else"))
                {
                    if (operador.Contains("menor"))
                    {
                        char[] op = operador.ToArray();
                        listViewEnsamblador.Items.Add("-- Else CMP Menor");
                        listViewEnsamblador.Items.Add("CMP AX,0");
                        listViewEnsamblador.Items.Add("JB Fin_else" + op[op.Length - 5]);
                        listViewEnsamblador.Items.Add("JA Ini_else" + op[op.Length - 5]);
                    }
                    else if (operador.Contains("menor o igual"))
                    {
                        char[] op = operador.ToArray();
                        listViewEnsamblador.Items.Add("-- Else CMP Menor o igual");
                        listViewEnsamblador.Items.Add("CMP AX,0");
                        listViewEnsamblador.Items.Add("JB Fin_else" + op[op.Length - 5]);
                        listViewEnsamblador.Items.Add("JA Ini_else" + op[op.Length - 5]);
                    }// RETBOT
                    else if (operador.Contains("mayor"))
                    {
                        char[] op = operador.ToArray();
                        listViewEnsamblador.Items.Add("-- Else CMP Mayor");
                        listViewEnsamblador.Items.Add("CMP AX,0");
                        listViewEnsamblador.Items.Add("JB Fin_else" + op[op.Length - 5]);
                        listViewEnsamblador.Items.Add("JA Ini_else" + op[op.Length - 5]);
                    }
                    else if (operador.Contains("mayor o igual"))
                    {
                        char[] op = operador.ToArray();
                        listViewEnsamblador.Items.Add("-- Else CMP Mayor o igual");
                        listViewEnsamblador.Items.Add("CMP AX,0");
                        listViewEnsamblador.Items.Add("JB Fin_if" + op[op.Length - 5]);
                        listViewEnsamblador.Items.Add("JA Ini_else" + op[op.Length - 5]);
                    }
                }
                // Si contiene un Fin_switch
                else if (operador.Contains("Fin_switch"))
                {
                    if (operador.Contains("menor"))
                    {// RETBOT
                        char[] op = operador.ToArray();
                        listViewEnsamblador.Items.Add("-- Switch CMP Menor");
                        listViewEnsamblador.Items.Add("CMP AX,0");
                        listViewEnsamblador.Items.Add("JB Fin_switch" + op[op.Length - 5]);
                        listViewEnsamblador.Items.Add("JA Ini_switch" + op[op.Length - 5]);
                    }
                    else if (operador.Contains("menor o igual"))
                    {
                        char[] op = operador.ToArray();
                        listViewEnsamblador.Items.Add("-- Switch CMP Menor o igual");
                        listViewEnsamblador.Items.Add("CMP AX,0");
                        listViewEnsamblador.Items.Add("JB Fin_switch" + op[op.Length - 5]);
                        listViewEnsamblador.Items.Add("JA Ini_switch" + op[op.Length - 5]);
                    }
                    else if (operador.Contains("mayor"))
                    {// RETBOT
                        char[] op = operador.ToArray();
                        listViewEnsamblador.Items.Add("-- Switch CMP Mayor");
                        listViewEnsamblador.Items.Add("CMP AX,0");
                        listViewEnsamblador.Items.Add("JB Fin_switch" + op[op.Length - 5]);
                        listViewEnsamblador.Items.Add("JA Ini_switch" + op[op.Length - 5]);
                    }
                    else if (operador.Contains("mayor o igual"))
                    {
                        char[] op = operador.ToArray();
                        listViewEnsamblador.Items.Add("-- Switch CMP Mayor o igual");
                        listViewEnsamblador.Items.Add("CMP AX,0");
                        listViewEnsamblador.Items.Add("JB Fin_switch" + op[op.Length - 5]);
                        listViewEnsamblador.Items.Add("JA Ini_switch" + op[op.Length - 5]);
                    }// RETBOT
                }
                // Si es un Fin_For 
                else if (operador.Contains("Fin_for"))
                {
                    if (operador.Contains("menor"))
                    {
                        char[] op = operador.ToArray();
                        listViewEnsamblador.Items.Add("-- If CMP");
                        listViewEnsamblador.Items.Add("CMP AX,0");
                        listViewEnsamblador.Items.Add("JB Fin_for" + op[op.Length - 5]);
                        listViewEnsamblador.Items.Add("JA Ini_for" + op[op.Length - 5]);
                    }// RETBOT
                    else if (operador.Contains("menor o igual"))
                    {
                        char[] op = operador.ToArray();
                        listViewEnsamblador.Items.Add("-- If CMP");
                        listViewEnsamblador.Items.Add("CMP AX,0");
                        listViewEnsamblador.Items.Add("JB Fin_for" + op[op.Length - 5]);
                        listViewEnsamblador.Items.Add("JA Ini_for" + op[op.Length - 5]);
                    }
                    else if (operador.Contains("mayor"))
                    {
                        char[] op = operador.ToArray();
                        listViewEnsamblador.Items.Add("-- If CMP");
                        listViewEnsamblador.Items.Add("CMP AX,0");
                        listViewEnsamblador.Items.Add("JB Fin_for" + op[op.Length - 5]);
                        listViewEnsamblador.Items.Add("JA Ini_for" + op[op.Length - 5]);
                    }
                    else if (operador.Contains("mayor o igual"))
                    {// RETBOT
                        char[] op = operador.ToArray();
                        listViewEnsamblador.Items.Add("-- If CMP");
                        listViewEnsamblador.Items.Add("CMP AX,0");
                        listViewEnsamblador.Items.Add("JB Fin_for" + op[op.Length - 5]);
                        listViewEnsamblador.Items.Add("JA Ini_for" + op[op.Length - 5]);
                    }
                }
                // Si es un Fin_while 
                else if (operador.Contains("Fin_while"))
                {
                    if (operador.Contains("menor"))
                    {
                        char[] op = operador.ToArray();
                        listViewEnsamblador.Items.Add("-- While CMP");
                        listViewEnsamblador.Items.Add("CMP AX,0");
                        listViewEnsamblador.Items.Add("JB Fin_while" + op[op.Length - 5]);
                        listViewEnsamblador.Items.Add("JA Ini_while" + op[op.Length - 5]);
                    }// RETBOT
                    else if (operador.Contains("menor o igual"))
                    {
                        char[] op = operador.ToArray();
                        listViewEnsamblador.Items.Add("-- While CMP");
                        listViewEnsamblador.Items.Add("CMP AX,0");
                        listViewEnsamblador.Items.Add("JB Fin_while" + op[op.Length - 5]);
                        listViewEnsamblador.Items.Add("JA Ini_while" + op[op.Length - 5]);
                    }
                    else if (operador.Contains("mayor"))
                    {
                        char[] op = operador.ToArray();
                        listViewEnsamblador.Items.Add("-- While CMP");
                        listViewEnsamblador.Items.Add("CMP AX,0");
                        listViewEnsamblador.Items.Add("JB Fin_while" + op[op.Length - 5]);
                        listViewEnsamblador.Items.Add("JA Ini_while" + op[op.Length - 5]);
                    }
                    else if (operador.Contains("mayor o igual"))
                    {
                        char[] op = operador.ToArray();
                        listViewEnsamblador.Items.Add("-- While CMP");
                        listViewEnsamblador.Items.Add("CMP AX,0");
                        listViewEnsamblador.Items.Add("JB Fin_while" + op[op.Length - 5]);
                        listViewEnsamblador.Items.Add("JA Ini_while" + op[op.Length - 5]);
                    }
                }
                // Si es un Fin_dowhile
                else if (operador.Contains("Fin_dowhile"))
                {
                    if (operador.Contains("menor"))
                    {
                        char[] op = operador.ToArray();
                        listViewEnsamblador.Items.Add("-- Do While CMP");
                        listViewEnsamblador.Items.Add("CMP AX,0");
                        listViewEnsamblador.Items.Add("JB Fin_dowhile" + op[op.Length - 5]);
                        listViewEnsamblador.Items.Add("JA Ini_dowhile" + op[op.Length - 5]);
                    }// RETBOT
                    else if (operador.Contains("menor o igual"))
                    {
                        char[] op = operador.ToArray();
                        listViewEnsamblador.Items.Add("-- Do While CMP");
                        listViewEnsamblador.Items.Add("CMP AX,0");
                        listViewEnsamblador.Items.Add("JB Fin_dowhile" + op[op.Length - 5]);
                        listViewEnsamblador.Items.Add("JA Ini_dowhile" + op[op.Length - 5]);
                    }
                    else if (operado// RETBOTr.Contains("mayor"))
                    {
                        char[] op = operador.ToArray();
                        listViewEnsamblador.Items.Add("-- Do While CMP");
                        listViewEnsamblador.Items.Add("CMP AX,0");
                        listViewEnsamblador.Items.Add("JB Fin_dowhile" + op[op.Length - 5]);
                        listViewEnsamblador.Items.Add("JA Ini_dowhile" + op[op.Length - 5]);
                    }
                    else if (operador.Contains("mayor o igual"))
                    {
                        char[] op = operador.ToArray();
                        listViewEnsamblador.Items.Add("-- Do While CMP");
                        listViewEnsamblador.Items.Add("CMP AX,0");
                        listViewEnsamblador.Items.Add("JB Fin_dowhile" + op[op.Length - 5]);
                        listViewEnsamblador.Items.Add("JA Ini_dowhile" + op[op.Length - 5]);
                    }
                }// RETBOT
            }

        }
        #endregion

        #region Generar codigo objeto para FERIR
        public static void codigoObjetoFERIR(ListView listViewEnsamblador, ListView listViewCuadruplos)
        {
            // Variables 
            string ph = "PUSH ";
            string pp = "POP ";
            string ax = "AX";// RETBOT
            string dx = "DX";
            string mov = "MOV";
            // ciclo para recorrer los cuadruplos 
            for (int i = 0; i < listViewCuadruplos.Items.Count; i++)
            {
                // obtenemos los cuadruplos obtenemos, las etiquetas, operadores, A1, A2 y los resultados 
                string etiqueta = listViewCuadruplos.Items[i].SubItems[0].Text;
                string operador = listViewCuadruplos.Items[i].SubItems[1].Text;
                string A1 = listViewCuadruplos.Items[i].SubItems[2].Text;
                string A2 = listViewCuadruplos.Items[i].SubItems[3].Text;
                string Res = listViewCuadruplos.Items[i].SubItems[4].Text;

                if (A2 != "")// Si A2 es diferente de una cadena vacia 
                {
                    if (etiqueta != "")// si la etiqueta no esta vacia 
                    {
                        listViewEnsamblador.Items.Add(etiqueta); // la agrega al ensamblador 
                    }

                    // verificamos los operadores 
                    if (operador == "+")// si es una suma 
                    {
                        // metemos a la pila AX y DX 
                        listViewEnsamblador.Items.Add(ph + "AX");
                        listViewEnsamblador.Items.Add(ph + "DX");
                        // movemos el valor de A1 a AX 
                        listViewEnsamblador.Items.Add(mov + " " + ax + ", " + A1);
                        // movemos el valor de A2 a DX 
                        listViewEnsamblador.Items.Add(mov + " " + dx + ", " + A2);
                        // verificamos los operadores // RETBOT
                        // entonces sumamos AX y DX 
                        listViewEnsamblador.Items.Add("ADD AX, DX");
                        listViewEnsamblador.Items.Add("MOV " + Res + ", AX");
                        // y lo sacamos DX y AX de la pila
                        listViewEnsamblador.Items.Add(pp + "DX");
                        listViewEnsamblador.Items.Add(pp + "AX");
                    }
                    else if (operador == "-")// si es una resta 
                    {
                        // metemos a la pila AX y DX 
                        listViewEnsamblador.Items.Add(ph + "AX");
                        listViewEnsamblador.Items.Add(ph + "DX");
                        // movemos el valor de A1 a AX 
                        listViewEnsamblador.Items.Add(mov + " " + ax + ", " + A1);
                        // movemos el valor de A2 a DX 
                        listViewEnsamblador.Items.Add(mov + " " + dx + ", " + A2);
                        // entonces restamos AX y DX 
                        listViewEnsamblador.Items.Add("SUB AX, DX");
                        listViewEnsamblador.Items.Add("MOV " + Res + ", AX");
                        // y lo sacamos DX y AX de la pila
                        listViewEnsamblador.Items.Add(pp + "DX");
                        listViewEnsamblador.Items.Add(pp + "AX");
                    }
                    else if (operador == "*")// si es una multiplicacion 
                    {
                        // metemos a la pila AX y DX // RETBOT
                        listViewEnsamblador.Items.Add(ph + "AX");
                        listViewEnsamblador.Items.Add(ph + "DX");
                        // movemos el valor de A1 a AX 
                        listViewEnsamblador.Items.Add(mov + " " + ax + ", " + A1);
                        // movemos el valor de A2 a DX 
                        listViewEnsamblador.Items.Add(mov + " " + dx + ", " + A2);
                        // entonces multiplicamos AX y DX
                        listViewEnsamblador.Items.Add("MUL AX, DX");
                        listViewEnsamblador.Items.Add("MOV " + Res + ", AX");
                        // y lo sacamos DX y AX de la pila
                        listViewEnsamblador.Items.Add(pp + "DX");
                        listViewEnsamblador.Items.Add(pp + "AX");
                    }
                    else if (operador == "/")// si es una division 
                    {
                        // metemos a la pila AX y DX 
                        listViewEnsamblador.Items.Add(ph + "AX");
                        listViewEnsamblador.Items.Add(ph + "DX");
                        // movemos el valor de A1 a AX 
                        listViewEnsamblador.Items.Add(mov + " " + ax + ", " + A1);
                        // movemos el valor de A2 a DX 
                        listViewEnsamblador.Items.Add(mov + " " + dx + ", " + A2);
                        // dividimos AX y DX // RETBOT
                        listViewEnsamblador.Items.Add("DIV AX, DX");
                        listViewEnsamblador.Items.Add("MOV " + Res + ", AX");
                        // y lo sacamos DX y AX de la pila
                        listViewEnsamblador.Items.Add(pp + "DX");
                        listViewEnsamblador.Items.Add(pp + "AX");
                    }
                    else
                    {
                        // si no es ningun operador, entonces es un tag 
                        listViewEnsamblador.Items.Add("");// se agrega un salto 
                        listViewEnsamblador.Items.Add(operador);// y se muestra
                    }
                }
                else
                {// si no 
                    if (etiqueta != "")// verifica que la etiqueta contenga información 
                    {
                        listViewEnsamblador.Items.Add(etiqueta); // le agrega la etiquieta
                    }
                    if (operador.Contains("Call")) // si es un call
                    {
                        listViewEnsamblador.Items.Add(operador); // lo agrega
                    }

                    if (A1 != "")// Si A1 contiene informacion, entonces, como no entro en el primer if,
                                 // solo es una asignacion 
                    {// RETBOT
                        // mete en la pila AX
                        listViewEnsamblador.Items.Add(ph + "AX");
                        // mueve el valor a AX 
                        listViewEnsamblador.Items.Add(mov + " " + ax + ", " + A1);
                        // se le asigna el valor de A1 (AX) a el resultado 
                        listViewEnsamblador.Items.Add("MOV " + Res + ", AX");
                        // y saca de la pila AX
                        listViewEnsamblador.Items.Add(pp + "AX");
                    }

                    if (etiqueta.Contains("goto")) // si contiene un goto 
                    {
                        listViewEnsamblador.Items.Add(""); // se agrega un salto 
                        string et = "";
                        int o;
                        for (o = 0; o < etiqueta.Length; o++) // recorre la etiqueta 
                        {
                            if (!etiqueta[o].Equals(' ')) // concatena hasta llegar a un espacio 
                            {
                                et += etiqueta[o];
                            }
                            else if (et.Contains("goto")) // si este contiene un goto, lo elimina, para buscar despues de el mismo 
                            {
                                et = "";
                            }
                        }// RETBOT
                        listViewEnsamblador.Items.Add("JMP " + et); // y se muestra el goto 
                    }
                    // Si contiene un Fin_Si
                    if (operador.Contains("Fin_si"))
                    {
                        if (operador.Contains("menor")) // Si contiene la palabra menor
                        {
                            char[] op = operador.ToArray();
                            listViewEnsamblador.Items.Add("-- Si CMP Menor");
                            listViewEnsamblador.Items.Add("CMP AX,0"); // hace la comparacion con AX 
                            listViewEnsamblador.Items.Add("JB Fin_si" + op[op.Length - 5]);// si menor, va al fin 
                            listViewEnsamblador.Items.Add("JA Ini_si" + op[op.Length - 5]);// si no, al Ini
                        }
                        else if (operador.Contains("menor o igual"))// Si contiene la palabra menor o igual
                        {
                            char[] op = operador.ToArray();
                            listViewEnsamblador.Items.Add("-- Si CMP Menor o igual");
                            listViewEnsamblador.Items.Add("CMP AX,0");// hace la comparacion con AX 
                            listViewEnsamblador.Items.Add("JB Fin_si" + op[op.Length - 5]);// si menor o igual, va al fin 
                            listViewEnsamblador.Items.Add("JA Ini_si" + op[op.Length - 5]);// si no, al Ini
                        }
                        else if (operador.Contains("mayor")) // Si contiene la palabra mayor
                        {
                            char[] op = operador.ToArray();// RETBOT
                            listViewEnsamblador.Items.Add("-- Si CMP Mayor");
                            listViewEnsamblador.Items.Add("CMP AX,0");// hace la comparacion con AX 
                            listViewEnsamblador.Items.Add("JB Fin_si" + op[op.Length - 5]);// si mayor, va al fin 
                            listViewEnsamblador.Items.Add("JA Ini_si" + op[op.Length - 5]);// si no, al Ini
                        }
                        else if (operador.Contains("mayor o igual"))// Si contiene la palabra mayor o igual
                        {
                            char[] op = operador.ToArray();
                            listViewEnsamblador.Items.Add("-- Si CMP Mayor o igual");
                            listViewEnsamblador.Items.Add("CMP AX,0");// hace la comparacion con AX 
                            listViewEnsamblador.Items.Add("JB Fin_si" + op[op.Length - 5]);// si mayor, va al fin 
                            listViewEnsamblador.Items.Add("JA Ini_si" + op[op.Length - 5]);// si no, al Ini
                        }
                    }
                    // Si contiene un Fin_contrario
                    else if (operador.Contains("Fin_contrario"))
                    {
                        if (operador.Contains("menor"))
                        {
                            char[] op = operador.ToArray();
                            listViewEnsamblador.Items.Add("-- Contrario CMP Menor");
                            listViewEnsamblador.Items.Add("CMP AX,0");
                            listViewEnsamblador.Items.Add("JB Fin_contrario" + op[op.Length - 5]);
                            listViewEnsamblador.Items.Add("JA Ini_contrario" + op[op.Length - 5]);
                        }// RETBOT
                        else if (operador.Contains("menor o igual"))
                        {
                            char[] op = operador.ToArray();
                            listViewEnsamblador.Items.Add("-- Contrario CMP Menor o igual");
                            listViewEnsamblador.Items.Add("CMP AX,0");
                            listViewEnsamblador.Items.Add("JB Fin_contrario" + op[op.Length - 5]);
                            listViewEnsamblador.Items.Add("JA Ini_contrario" + op[op.Length - 5]);
                        }
                        else if (operador.Contains("mayor"))
                        {
                            char[] op = operador.ToArray();
                            listViewEnsamblador.Items.Add("-- Contrario CMP Mayor");
                            listViewEnsamblador.Items.Add("CMP AX,0");
                            listViewEnsamblador.Items.Add("JB Fin_contrario" + op[op.Length - 5]);
                            listViewEnsamblador.Items.Add("JA Ini_contrario" + op[op.Length - 5]);
                        }
                        else if (operador.Contains("mayor o igual"))
                        {
                            char[] op = operador.ToArray();// RETBOT
                            listViewEnsamblador.Items.Add("-- Contrario CMP Mayor o igual");
                            listViewEnsamblador.Items.Add("CMP AX,0");
                            listViewEnsamblador.Items.Add("JB Fin_contrario" + op[op.Length - 5]);
                            listViewEnsamblador.Items.Add("JA Ini_contrario" + op[op.Length - 5]);
                        }
                    }
                    // Si contiene un Fin_cambio
                    else if(operador.Contains("Fin_cambio"))
                    {
                        if (operador.Contains("menor"))
                        {
                            char[] op = operador.ToArray();
                            listViewEnsamblador.Items.Add("-- Cambio CMP Menor");
                            listViewEnsamblador.Items.Add("CMP AX,0");
                            listViewEnsamblador.Items.Add("JB Fin_cambio" + op[op.Length - 5]);
                            listViewEnsamblador.Items.Add("JA Ini_cambio" + op[op.Length - 5]);
                        }
                        else if (operador.Contains("menor o igual"))
                        {// RETBOT
                            char[] op = operador.ToArray();
                            listViewEnsamblador.Items.Add("-- Cambio CMP Menor o igual");
                            listViewEnsamblador.Items.Add("CMP AX,0");
                            listViewEnsamblador.Items.Add("JB Fin_cambio" + op[op.Length - 5]);
                            listViewEnsamblador.Items.Add("JA Ini_cambio" + op[op.Length - 5]);
                        }
                        else if (operador.Contains("mayor"))
                        {
                            char[] op = operador.ToArray();
                            listViewEnsamblador.Items.Add("-- Cambio CMP Mayor");
                            listViewEnsamblador.Items.Add("CMP AX,0");
                            listViewEnsamblador.Items.Add("JB Fin_cambio" + op[op.Length - 5]);
                            listViewEnsamblador.Items.Add("JA Ini_cambio" + op[op.Length - 5]);
                        }
                        else if (operador.Contains("mayor o igual"))
                        {
                            char[] op = operador.ToArray();
                            listViewEnsamblador.Items.Add("-- Cambio CMP Mayor o igual");
                            listViewEnsamblador.Items.Add("CMP AX,0");
                            listViewEnsamblador.Items.Add("JB Fin_cambio" + op[op.Length - 5]);
                            listViewEnsamblador.Items.Add("JA Ini_cambio" + op[op.Length - 5]);
                        }// RETBOT
                    }
                    // Si contiene un Fin_por
                    else if(operador.Contains("Fin_por"))
                    {
                        if (operador.Contains("menor"))
                        {
                            char[] op = operador.ToArray();
                            listViewEnsamblador.Items.Add("-- Por CMP");
                            listViewEnsamblador.Items.Add("CMP AX,0");
                            listViewEnsamblador.Items.Add("JB Fin_por" + op[op.Length - 5]);
                            listViewEnsamblador.Items.Add("JA Ini_por" + op[op.Length - 5]);
                        }
                        else if (operador.Contains("menor o igual"))
                        {
                            char[] op = operador.ToArray();
                            listViewEnsamblador.Items.Add("-- Por CMP");
                            listViewEnsamblador.Items.Add("CMP AX,0");
                            listViewEnsamblador.Items.Add("JB Fin_por" + op[op.Length - 5]);
                            listViewEnsamblador.Items.Add("JA Ini_por" + op[op.Length - 5]);
                        }
                        else if (operador.Contains("mayor"))// RETBOT
                        {
                            char[] op = operador.ToArray();
                            listViewEnsamblador.Items.Add("-- Por CMP");
                            listViewEnsamblador.Items.Add("CMP AX,0");
                            listViewEnsamblador.Items.Add("JB Fin_por" + op[op.Length - 5]);
                            listViewEnsamblador.Items.Add("JA Ini_por" + op[op.Length - 5]);
                        }
                        else if (operador.Contains("mayor o igual"))
                        {
                            char[] op = operador.ToArray();
                            listViewEnsamblador.Items.Add("-- Por CMP");
                            listViewEnsamblador.Items.Add("CMP AX,0");
                            listViewEnsamblador.Items.Add("JB Fin_por" + op[op.Length - 5]);
                            listViewEnsamblador.Items.Add("JA Ini_por" + op[op.Length - 5]);
                        }// RETBOT
                    }
                    // Si contiene un Fin_mientras
                    else if(operador.Contains("Fin_mientras"))
                    {
                        if (operador.Contains("menor"))
                        {
                            char[] op = operador.ToArray();
                            listViewEnsamblador.Items.Add("-- Mientras CMP");
                            listViewEnsamblador.Items.Add("CMP AX,0");
                            listViewEnsamblador.Items.Add("JB Fin_mientras" + op[op.Length - 5]);
                            listViewEnsamblador.Items.Add("JA Ini_mientras" + op[op.Length - 5]);
                        }
                        else if (operador.Contains("menor o igual"))
                        {
                            char[] op = operador.ToArray();
                            listViewEnsamblador.Items.Add("-- Mientras CMP");
                            listViewEnsamblador.Items.Add("CMP AX,0");
                            listViewEnsamblador.Items.Add("JB Fin_mientras" + op[op.Length - 5]);
                            listViewEnsamblador.Items.Add("JA Ini_mientras" + op[op.Length - 5]);
                        }
                        else if (operador.Contains("mayor"))
                        {
                            char[] op = operador.ToArray();
                            listViewEnsamblador.Items.Add("-- Mientras CMP");
                            listViewEnsamblador.Items.Add("CMP AX,0");
                            listViewEnsamblador.Items.Add("JB Fin_mientras" + op[op.Length - 5]);
                            listViewEnsamblador.Items.Add("JA Ini_mientras" + op[op.Length - 5]);
                        }
                        else if (operador.Contains("mayor o igual"))
                        {// RETBOT
                            char[] op = operador.ToArray();
                            listViewEnsamblador.Items.Add("-- Mientras CMP");
                            listViewEnsamblador.Items.Add("CMP AX,0");
                            listViewEnsamblador.Items.Add("JB Fin_mientras" + op[op.Length - 5]);
                            listViewEnsamblador.Items.Add("JA Ini_mientras" + op[op.Length - 5]);
                        }
                    }
                    // Si contiene un Fin_hacer
                    else if(operador.Contains("Fin_hacer"))
                    {
                        if (operador.Contains("menor"))
                        {
                            char[] op = operador.ToArray();
                            listViewEnsamblador.Items.Add("-- Hacer CMP");
                            listViewEnsamblador.Items.Add("CMP AX,0");
                            listViewEnsamblador.Items.Add("JB Fin_hacer" + op[op.Length - 5]);
                            listViewEnsamblador.Items.Add("JA Ini_hacer" + op[op.Length - 5]);
                        }
                        else if (operador.Contains("menor o igual"))
                        {
                            char[] op = operador.ToArray();
                            listViewEnsamblador.Items.Add("-- Hacer CMP");
                            listViewEnsamblador.Items.Add("CMP AX,0");
                            listViewEnsamblador.Items.Add("JB Fin_hacer" + op[op.Length - 5]);
                            listViewEnsamblador.Items.Add("JA Ini_hacer" + op[op.Length - 5]);
                        }
                        else if (operador.Contains("mayor"))
                        {// RETBOT
                            char[] op = operador.ToArray();
                            listViewEnsamblador.Items.Add("-- Hacer CMP");
                            listViewEnsamblador.Items.Add("CMP AX,0");
                            listViewEnsamblador.Items.Add("JB Fin_hacer" + op[op.Length - 5]);
                            listViewEnsamblador.Items.Add("JA Ini_hacer" + op[op.Length - 5]);
                        }
                        else if (operador.Contains("mayor o igual"))
                        {
                            char[] op = operador.ToArray();
                            listViewEnsamblador.Items.Add("-- Hacer CMP");
                            listViewEnsamblador.Items.Add("CMP AX,0");
                            listViewEnsamblador.Items.Add("JB Fin_hacer" + op[op.Length - 5]);
                            listViewEnsamblador.Items.Add("JA Ini_hacer" + op[op.Length - 5]);
                        }// RETBOT
                    }
                }

            }
        }
        #endregion
    }
}
