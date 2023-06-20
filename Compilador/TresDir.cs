using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
/*R*E*T*B*O*T*/
namespace Arbol
{
    /// <summary>
    /// Clase para generar el código de Tres Direcciones
    /// </summary>
    /// <Autores>
    /// Roberto Esquivel Troncoso - 19130519 
    /// Ivan Herrera Garcia - 19130535
    /// Fatima Gorety Garcia Yescas - 19130527
    /// Isaias Gerardo Cordova Palomares - 19130514
    /// Raul Galindo Sanches - 18130553
    /// </Autores>
    /// <Fecha> 05/04/2022 </Fecha>
    //************************************************************************************************************
    // Para mas informacion contactar a robertoesquiveltr16@gmail.com
    //************************************************************************************************************
    public class TresDir
    {
        // Variables locales usadas en Tres Direcciones
        #region Variables locales 
        // Cola para las expresiones 
        public static Queue colaExpresion = new Queue();
        // matriz con todos los operadores aritmeticos 
        public static char[] operadores = { '+', '-', '*', '/' };
        // verifica clases /*R*E*T*B*O*T*/
        private static Regex _clase = new Regex(@"(([A-Z|a-z])\w+)");
        // verifica metodos 
        private static Regex rgxMet = new Regex(@"(([A-Z|a-z])\w+)\s(([A-Z|a-z])\w+)((\()?((([A-Z|a-z]\w+\s[A-Z|a-z]\w+)?(\,)?\s?([A-Z|a-z]\w+\s[A-Z|a-z]\w+))?(\))))");
        // metodo 2 
        private static Regex rgxMet2 = new Regex(@"(([A-Z|a-z])\w+)((\()?((([A-Z|a-z]\w+)?(\,)?\s?([A-Z|a-z]\w+))?(\))))");
        // id 
        private static Regex rgxid = new Regex(@"(([A-Z|a-z])\w+)\s\=\s([0-9]*)");
        // Id2
        private static Regex rgxid2 = new Regex(@"(([A-Z|a-z])?\w+)\s\=\s(([0-9]|[a-z|A-z])*?\s[\+|\-|\*|\/]?\s([0-9]|[a-z|A-z])*)");
        // guardar metodos
        private static List<String> metodosJava;
        private static List<String> metodosFERIR;
        #endregion

        #region Metodos implementados en JAVA
        #region Temporales Java
        // metodo para generar los temporales de JAVA // Ingresando los temporales y salen los resultados 
        public static void genTemporalesJava(List<String> temporal, List<String> resultado)
        {/*R*E*T*B*O*T*/
            int tmp = 1; // Inicio de los temporales 
            bool bandAsignacion = false; // banda opara la asignacion 
            string temAsignacion = "";
            // bandera para cada metodo 
            bool bandIF = false, bandElse = false, bandSwitch = false, bandWhile = false, bandDoWhile = false, bandFor = false, bandCambioFor = false;
            bool bandFor2 = false;
            // Junto con la cantidad de veces que se acceden a ellas 
            int _if = 0, _else = 0, _switch = 0, _while = 0, _doWhile = 0, _for = 0, canFor = 0;
            // verifica el metodo que es 
            string es = "";
            // por para hacer recorrido por la linea 
            for (int i = 0; i < temporal.Count; i++)
            {
                bool band = false; // Bandera para los temporales que solo tengan '='
                bool bandTem = false; // Bandera para temporales que tengan signo 
                bool band2 = false;// Bandera para los temporales que solo tengan '>'
                bool band3 = false;// Bandera para los temporales que solo tengan '>='
                bool band4 = false; // Bandera para los temporales que solo tengan '<'
                bool band5 = false; // Bandera para los temporales que solo tengan '<='
                bool band6 = false; // Bandera para los temporales que solo tengan ':'
/*R*E*T*B*O*T*/
                // El resultado de los temporales se va a ir escribiendo sobre este string
                String res = "";  // y se reinicia con cada salto de linea
                char[] pal = temporal[i].ToArray();// Se crea un arreglo de char con el String del temporal entrante 

                // verifica si 
                string sino = temporal[i];
                if (sino.Contains("else")) // es else, 
                {
                    bandElse = true;
                }
                else if (sino.Contains("if")) // if, 
                {
                    bandIF = true;
                }
                else if (sino.Contains("}")) // el fin, 
                {/*R*E*T*B*O*T*/
                    resultado.Add("");
                    if (bandFor2) {
                        resultado.Add("");
                        bandFor2 = false;
                    }
                }
                else if (sino.Contains("switch")) // switch, 
                {
                    bandSwitch = true;
                }
                else if (sino.Contains("while"))// while, 
                {
                    bandWhile = true;
                }
                else if (sino.Contains("do"))// dowhile 
                {
                    bandDoWhile = true;
                }
                else if (sino.Contains("for")) // o for y activa su respectiva bandera 
                {
                    bandFor = true;
                }
                else if (sino.Contains("return")) // si contiene un return 
                {/*R*E*T*B*O*T*/
                    string metod = metodosJava.First(); // obtiene el dato ingresado (desde donde lo llamaron) en los metodos JAVA 
                    metodosJava.RemoveAt(0); // remueve el ultimo elemento del metodo
                    string go = "goto call_" + metod; // lo agrega en un string, para hacer el goto 

                    metod = metodosJava.First(); // y despues obtiene el nombre del metodo 
                    metodosJava.RemoveAt(0); // remueve el ultimo elemento del metodo
                    go += "_"+metod; // le agrega un _ 
                    resultado.Add(go); // y se agrega al resultado 
      
                }
                else if (rgxid.IsMatch(sino)) // si es un ID no hace nad 
                {
                    // no hace nada
                }
                else if (rgxMet2.IsMatch(sino)) // si es un metodo 
                {
                    res += "Call "; // le agrega la llamada 
                    int c = 0;
                    while (!pal[c].Equals('(')) // se hace un ciclo para obtener el nomrbe 
                    {/*R*E*T*B*O*T*/
                        res += pal[c]; // lo va concatenando hasta encontrar un ( 
                        c++;
                    }
                    res += ": "; // y despues lo agrega al resultado 
                    resultado.Add(res);
                    res = "";
                }
                else if (_clase.IsMatch(sino)) // si es una clase, solo agrega el espacio en donde aparece 
                {/*R*E*T*B*O*T*/
                    resultado.Add(" ");
                }
                // se guarda la posicion del signo para despues usarlo 
                int posSigno = 0;
                // se recorre todo el arreglo // toda la linea de codigo 
                for (int j = 0; j < pal.Length; j++)
                {
                    if (pal[j].Equals('=')) // Lo primero que se busca es encontrar un = 
                    {// Si lo encuentra se escribe el temporal (T) más el número de temporales y se activa la bandera 
                     // para escribir el contenido restante del arreglo de char
                        bool bandAsAux = false; // bandera para agregar la variable 
                        for (int b = j; b < pal.Length; b++) // se recorre la palabra 
                        {
                            if (pal[b].Equals('+') || pal[b].Equals('-')
                                      || pal[b].Equals('*') || pal[b].Equals('/')) // busca operadores 
                            {
                                res = "T" + (tmp++) + " "; // Si es >= se escribe el temporal (T) más el número de temporales y se activa la bandera 
                                bandTem = true; // temporal con signo 
                                bandAsignacion = true; // asignacion 
                                bandAsAux = true; // activa la bandera para guardar el nombre 
                                posSigno = j; // guarda la pos del signo 
                                // encuentra el operador y termina el for 
                                break; 
                            }/*R*E*T*B*O*T*/
                        }

                        // Variable para asignacion (nombre de la variable )
                        if (bandAsAux)
                        {
                            for (int c = 0; c < j; c++) // guarda el nombre de la variable 
                            {
                                temAsignacion += pal[c];
                            }
                            bandAsAux = false; // cambia el estado de la bariable 
                        }
                        // se activa la primera bandera 
                        band = true;
                        //termina el for
                        break; 
                    }/*R*E*T*B*O*T*/
                    else if (pal[j].Equals('>'))
                    { // Si no es un =, entonces buscara el siguiente signo que es el > 
                        if (pal[j + 1].Equals('='))
                        { // busca en el siguiente valor del arreglo para verificar que no sea un >= 
                            res = "T" + (tmp++) + " = "; // Si es >= se escribe el temporal (T) más el número de temporales y se activa la bandera 
                            if (!bandFor) // si no es un for, aumenta en uno a j, si es un for, no lo aumenta 
                                j++; // Se suma uno a la j, para saltar el signo = 
                            // pone la bandera 3 en verdadera 
                            band3 = true; 
                            posSigno = j;// guarda la pos del signo 
                            break; // termina el for 
                        }
                        else
                        { // Si no, entonces solose escribe el temporal (T) más el número de temporales y se activa la bandera y se aumenta uno a la j
                            res = "T" + (tmp++) + " = ";
                            // despues activa la badera 
                            band2 = true;
                            posSigno = j;// guarda la pos del signo 
                            if (!bandFor) // si no es un for, aumenta en uno a j, si es un for, no lo aumenta 
                                j++;

                            break;// termina el for 
                        }/*R*E*T*B*O*T*/
                    }
                    else if (pal[j].Equals('<'))  // Si no son los signos anteriores, entonces buscara el siguiente signo que es el <
                    {
                        if (pal[j + 1].Equals('=')) // busca en el siguiente valor del arreglo para verificar que no sea un <= 
                        {
                            res = "T" + (tmp++) + " = "; // Si es >= se escribe el temporal (T) más el número de temporales y se activa la bandera 
                            if (!bandFor) // si no es un for, aumenta en uno a j, si es un for, no lo aumenta 
                                j++; // Se suma uno a la j, para saltar el signo = 
                            // activa la bandera 5 
                            band5 = true;
                            posSigno = j;// guarda la pos del signo 
                            break;// termina el for 
                        }/*R*E*T*B*O*T*/
                        else
                        { // Si no, entonces solose escribe el temporal (T) más el número de temporales y se activa la bandera y se aumenta uno a la j
                            res = "T" + (tmp++) + " = ";
                            if (!bandFor) // si no es un for, aumenta en uno a j, si es un for, no lo aumenta 
                                j++;
                            // avtiva la bandera 4 
                            band4 = true;
                            posSigno = j;// guarda la pos del signo 
                            break;// termina el for 
                        }
                    } // Si no, entonces busca el ; y si es el de cierre no entra, pero si no es el ultimo, entonces es un for 
                    else if (pal[j].Equals(';') && (j + 2) < pal.Length)
                    {/*R*E*T*B*O*T*/
                        // activa la badnera para empezar a escribir 
                        band6 = true;
                        // aumenta el for 
                        _for++;
                        break;// termina el for 
                    }
                }

                // Las banderas estan creadas para seguir escribiendo despues de encontrar el singo a buscar 
                if (band) // bandera uno 
                {/*R*E*T*B*O*T*/
                    if (bandTem) // entra si es un operador 
                    {
                        for (int j = posSigno; j < pal.Length; j++)
                            res += pal[j];
                    }
                    else // si no contiene operador 
                    {
                        for (int j = 0; j < pal.Length; j++)
                            res += pal[j];
                    }
                }/*R*E*T*B*O*T*/
                // para el signo mayor // para el signo mayor o igual 
                // para el signo menor // para el signo menor o igual 
                if (band2 || band3 || band4 || band5)
                {
                    int j = 0;
                    while (!pal[j].Equals('('))
                    {
                        j++;
                    }
                    j++;
                    while (!pal[j].Equals(')'))
                    {
                        res += pal[j++];
                    }
                }
                if (band6) // para el for 
                {/*R*E*T*B*O*T*/
                    for (int j = 0; j < pal.Length; j++)
                    {
                        if (_for == 1) // si es igual a uno, entra en la primera sección del for
                        {
                            res = "";
                            string res2 = "";
                            for (int n = j + 4; n >= 0; n--) // recorre la primer seccion 
                            {
                                if (pal[n] != ';')// si es un ;  lo quita
                                {
                                    res += pal[n]; // almacena la primera seccion 
                                }
                                j++;
                            }
                            while (pal[j] != ' ')  // recorre la palabra hasta encontrar un espacio en blanco 
                            {
                                res2 += pal[j]; // lo va concatenando al res2 
                                j++;
                            }
                            j--;
                            while (pal[j] != ' ')
                            {
                                j--;
                            }
                            res2 += res;
                            band6 = false; // se cambia el estado de la bancera 6 
                            resultado.Add(res2); // el resultado se agrega al List tmpResultado    
                            res = ""; // se quita el resultado, para seguir con la siguiente seccion 
                            bandFor = false; // se activa la bandera del for 
                            bandFor2 = true;
                            canFor++; // aumenta la cantidad de for 
                            _for++;
                        }
                        else if (_for == 2)
                        { // entra en la segunda seccion del for 
                            if (pal[j].Equals(';')) // si encuentra el ;, entonces encontro el fin de la segunda seccion 
                            {
                                string result = "T" + (tmp++) + " = " + res;
                                _for++;
                                string ir = "si T" + (tmp - 1) + " ";
                                // verifica el signo, si es <, <=, >, >= y ke agrega el goto 
                                if (result.Contains("<"))
                                {
                                    result = Regex.Replace(result, @"<", "-");// se cambia el mayor, por el signo de menos
                                    ir += " menor a 0 goto Fin_for" + canFor; // y se agrega el goto 
                                }
                                else if (result.Contains("<="))
                                {
                                    result = Regex.Replace(result, @"<=", "-");// se cambia el mayor o igual, por el signo de menos 
                                    ir += " menor o igual a 0 goto Fin_for" + canFor; // y se agrega el goto 
                                }
                                else if (result.Contains(">"))
                                {
                                    result = Regex.Replace(result, @">", "-");// se cambia el mayor o igual, por el signo de menos 
                                    ir += "mayor a 0 goto Fin_for" + canFor; // y se agrega el goto 
                                }
                                else if (result.Contains(">="))
                                {
                                    result = Regex.Replace(result, @">=", "-");// se cambia el mayor o igual, por el signo de menos 
                                    ir += " mayor o igual a 0 goto Fin_for" + canFor;  // y se agrega el goto 
                                }/*R*E*T*B*O*T*/
                                resultado.Add(result); // se agrega el resultado 
                                resultado.Add(ir); // junto con el goto 
                                res = ""; // se quita el resultado 
                                bandFor = false; //  se aciva la vandera par el for 
                                band6 = false; // se desactiva la bandera 6 y 4 
                                band4 = false;
                                // y se aumenta en dos la j 
                                j = j + 2;
                                // se activa la bandera del cambio for 
                                bandCambioFor = true;
                            }
                            else
                            { //  mientras no encuentre el ;, concatena en res
                                // agrega los datos
                                res += pal[j];
                            }
                        }
                        else
                        { // entra en la tercera seccion del for 
                            int posIni = j+1;
                            bool bandAsAux = false;
                            res = "T" + (tmp++) + " "; // Si es >= se escribe el temporal (T) más el número de temporales y se activa la bandera 
                            for (int b = j; b < pal.Length; b++) // recorre la palabra 
                            {/*R*E*T*B*O*T*/
                                if (pal[b].Equals('=')) // si encuentra un = 
                                {
                                    while (!pal[b].Equals(')')) // recorre la palabra y va concatenando, hasta encontrar un )
                                    {
                                        res += pal[b]; 
                                        b++;
                                    }
                                    resultado.Add(res); // lo agrega a los resultados 
                                    bandAsignacion = true; // asignacion 
                                    bandAsAux = true; // activa la bandera para obtener el nombre de la variable 
                                    break;
                                }
                            }

                            // Variable para asignacion 
                            if (bandAsAux)
                            {/*R*E*T*B*O*T*/
                                int c = posIni;
                                while (!pal[c].Equals(';')) // recorre la palabra hasta encotrar el ; anterior 
                                {
                                    c--;
                                }
                                c++;
                                while (!pal[c].Equals('='))  // despues recorre de regreso hasta encontrar un = 
                                {
                                    temAsignacion += pal[c]; // va concatenando a la asignacion 
                                    c++;
                                }
                                bandAsAux = false; // se cambia la bandera 
                                break; // termina el ciclo 
                            }
                        }
                    }
                }
        
              // entra si encuenta alguna de las banderas activas 
              if (band || bandIF || bandSwitch || bandWhile || bandDoWhile)
                {/*R*E*T*B*O*T*/
                    if (band)
                    { // en el resultado para la bandera 1, se queda almacenado el ; 
                        res = Regex.Replace(res, @";", ""); // Con el regex se cambia el punto y coma, por un espacio en blanco
                    }
                    if (band2)
                    { // en el resultado para la bandera 2
                        res = Regex.Replace(res, @">", " - ");// se cambia el mayor, por el signo de menos 
                        es = "mayor";
                    }/*R*E*T*B*O*T*/
                    if (band3)
                    {// en el resultado para la bandera 3 
                        res = Regex.Replace(res, @">=", " - ");// se cambia el mayor o igual, por el signo de menos 
                        es = "mayor o igual";
                    }
                    if (band4)
                    {// en el resultado para la bandera 4
                        res = Regex.Replace(res, @"<", " - ");// se cambia el menor, por el signo de menos 
                        es = "menor";
                    }
                    if (band5)
                    {// en el resultado para la bandera 5
                        res = Regex.Replace(res, @"<=", " - ");// se cambia el menor o igual, por el signo de menos 
                        es = "menor o igual";
                    }

                    // el resultado se agrega al List tmpResultado 
                    resultado.Add(res); 
/*R*E*T*B*O*T*/
                    // Si la bandera del if se encuentra activa 
                    if (bandIF)
                    {
                        // agrega el goto del fin para el if 
                        int tmpante = tmp - 1;
                        resultado.Add("Si T" + tmpante + " " + es + " a 0 \n goto Fin_if" + (++_if) + " : ");
                        bandIF = false;
                    }
                    /*else if (bandElse)
                    {
                        int tmpante = tmp - 1;
                        resultado.Add("Si false T" + tmpante + " " + es + "  a 0 \n goto fin_else" + (_else++) + " : ");
                        bandElse = false;
                    }*/
                    // Si no, busca que la bandera del switch se encuentre activa 
                    else if (bandSwitch)
                    {
                        // agrega el goto del fin para el switch
                        int tmpante = tmp - 1;
                        resultado.Add("Si T" + tmpante + " " + es + " a 0 \n goto Fin_switch" + (++_switch) + " : ");
                        bandSwitch = false;
                    }/*R*E*T*B*O*T*/
                    // Si no, busca que la bandera del while se encuentre activa 
                    else if (bandWhile)
                    {
                        // Si es un do while 
                        if (bandDoWhile)
                        {
                            // agrega el goto del Inicio para el dowhile 
                            int tmpante = tmp - 1;
                            resultado.Add("Si T" + tmpante + " " + es + " a 0 \n goto Ini_dowhile" + (++_doWhile) + " : ");
                            bandDoWhile = false;
                            bandWhile = false;
                        }
                        else
                        { // o es un while
                            // agrega el goto del fin para el while
                            int tmpante = tmp - 1;
                            resultado.Add("Si T" + tmpante + " " + es + " a 0 \n goto Fin_while" + (++_while) + " : ");
                            bandWhile = false;
                        }
                    }
                }

                // Si se activa la asignacion 
                if (bandAsignacion)
                {/*R*E*T*B*O*T*/
                    // se agrega el resultado 
                    char[] v = res.ToCharArray();
                    // se crea una variable para la asignacion 
                    string temporalAsinacion = "";
                    // y una variable para el recorrido de la asignacion 
                    int h = 0;
                    for (h = 0; !v[h].Equals('='); h++)
                    {
                        temporalAsinacion += v[h];
                    }

                    // se agrega el temporal 
                    temAsignacion += "= " + temporalAsinacion;
                    // despues se agrega a los resultados 
                    resultado.Add(temAsignacion);
                    // se cambia la bandera para la asignacion 
                    bandAsignacion = false;
                    // y se quita la variable 
                    temAsignacion = ""; // variable
                    res = "";
                }
            }
        }
        #endregion

        #region TAG Java
        public static void genTagJava(List<String> contenido, List<String> tag)
        {/*R*E*T*B*O*T*/
            // Arreglo para almacenar la posicion de los tag de inicio, para el cierre  
            List<String> tagIni = new List<string>();
            string tagFin = "";
            // inicializa los metodos para JAVA 
            metodosJava = new List<string>();

            // contadores de tag (inicio y cierre)
            int _if = 1;
            int _else = 1;
            int _switch = 1;
            int _caso = 1;
            int _for = 1;
            int _doWhile = 1;
            int _while = 1;
            int _main = 1;

            // banderas para controlar e inicio y fin 
            bool bandIF = false;
            bool bandElse = false;
            bool bandSW = false;
            bool bandFor = false;
            bool bandDoWhile = false;
            bool bandWhile = false;
            bool bandMain = false;
            bool bandMetodo = false;/*R*E*T*B*O*T*/

            int cantLineas = contenido.Count;
            for (int i = 0; i < cantLineas; i++) // Ciclo para obtener línea por línea el código fuente
            {
                string token = contenido[i];  // Se obtiene el token (en este caso es la toda la línea de 0 hasta n)
                string tagg = ""; // variable para almacenar el tag 
                string cf = "";

                // si el token contiene un signo }
                if (token.Contains("}"))
                {
                    if (tagIni.Count > 0) // verifica que el tac inicial sea mayor a 0 
                    {
                        tagFin = tagIni.Last(); // agrega el ultimo elemento al tagFin 
                        tagIni.RemoveAt(tagIni.Count - 1); // remueve el ultimo elemento del tag Inicial 
                    }
                }
                if (token.Contains("void main"))
                {/*R*E*T*B*O*T*/
                    // identificar el doWhile
                    tagIni.Add("main" + _main + ":");
                    // se agrega el tag 
                    tagg += "Ini_main" + (_main++) + ":";
                }
                else if (rgxMet.IsMatch(token)) { // si es un metodo 
                    char[] cfC = token.ToCharArray(); // entonces crea un arreglo de char 
                    for (int c = 0; c < cfC.Length; c++) // para recorrerlo 
                    {
                        int pos = c;
                        if (cfC[c].Equals('(')) // hasta encontrar un ( 
                        {
                            while (!cfC[c].Equals(' ')) // se regresa en el arreglo, hasta encontrar un espacio en blanco
                            {
                                c--;
                            }
                            c++;
                            while (c < pos) // y escribe el nombre del metodo 
                            {
                                cf += cfC[c++];
                            }
                            break; // termina el ciclo 
                        }
                    }
                    // identificar el tag 
                    tagIni.Add(cf + ":");
                    // se agrega el tag 
                    tagg = cf + ":";
                    // despues lo agrega a los metodos 
                    metodosJava.Add(cf);
                    // y se cambia la bandera 
                    bandMetodo = true;
                }
                else if (rgxMet2.IsMatch(token)) // si no, entonces es una llamada 
                {
                    char[] cfC = token.ToCharArray(); // crea un arreglo de char 
                    for (int c = 0; c < cfC.Length; c++) // recorre el arreglo 
                    {
                        while (!cfC[c].Equals('(')) // lo recorre hasta encontrar un signo ( 
                        {
                            cf += cfC[c++]; // y va concatenando 
                        }
                        break; // termina el ciclo 
                    }
                    // identificar el metodo y los agrega a los metodos JAVA
                    metodosJava.Add(tagIni.Last());
                    metodosJava.Add(cf);
                }
/*R*E*T*B*O*T*/
                // Para generar los tags del if //
                if (token.Contains("if")) // Busca la palabra if en la línea de código 
                { // Si la encuentra se pone una etiqueta sobre la línea y aumenta el contador de if
                    // identificar el if
                    tagIni.Add("if" + _if + ":");
                    // se agrega el tag 
                    tagg += "Ini_if" + (_if++) + ":";
                    tag.Add(tagg);
                    tagg = ""; // goto
                    // bandera para activar el if
                    bandIF = true;
                }
                else if (token.Contains("} else { ") || token.Contains("}else{") || token.Contains("else{") || token.Contains("else {")) // si no, entonces busca un } else 
                { // Si la encuentra se pone una etiqueta sobre la línea y aumenta el contador de el fin if y el inicio del else

                    if (tagFin.Contains("if")) // bandera para cerrar el if 
                    {
                        tag.Add("");
                        tagg += "Fin_" + tagFin;
                        bandIF = false;
                        tag.Add(tagg);
                        tagg = "";
                        tagFin = "";
                    }/*R*E*T*B*O*T*/
                    // identificar el else
                    tagIni.Add("else" + _else + ":");
                    // se agrega el tag
                    tagg += "Ini_else" + (_else++) + ":";
                    bandElse = true;
                }
                /*else if (token.Contains("else")) // si no, entonces busca un else 
                { // Si la encuentra se pone una etiqueta sobre la línea y aumenta el contador de else
                    tagg += "Ini_else" + (_else++);
                    bandElse = true;
                }*//*R/*R*E*T*B*O*T*/*E*T*B*O*T*/
                // Para generar los tags del switch //
                if (token.Contains("switch"))// Busca la palabra switch en la línea de código 
                {// Si la encuentra se pone una etiqueta sobre la línea y aumenta el contador de switch
                    // identificar el switch
                    tagIni.Add("switch" + _switch + ":");
                    // se agrega el tag 
                    tagg += "Ini_switch" + (_switch++) + ":";
                    tag.Add(tagg);
                    tagg = "";
                    bandSW = true;
                }
                else if (token.Contains("case"))//Si no, entonces busca la palabra case en la línea de código 
                {// Si la encuentra se pone una etiqueta sobre la línea y aumenta el contador de caso
                    tagg += "caso" + (_caso++) + ":";
                }
                else if (token.Contains("break")) // al final busca el break, y pone el go to del switch 
                {
                    int swAnte = _switch - 1;// switch anterior
                    tagg += "goto Fin_switch" + swAnte + ":"; // switch anterior
                }

                if (token.Contains("for"))
                {
                    // identificar el For
                    tagIni.Add("for" + _for + ":");
                    // se agrega el tag 
                    tagg += "Ini_for" + (_for++) + ":";
                    tag.Add(tagg);
                    tag.Add("");
                    // y el cuerpo del for 
                    tagg = "Cuerpo_for" + (_for - 1) + ": ";
                    tag.Add(tagg);
                    tagg = "";
                    tag.Add(tagg);/*R*E*T*B*O*T*/
                    bandFor = true;

                }
                if (token.Contains("while")) // Si contiene un while 
                {

                    if (bandDoWhile || tagFin.Contains("while")) // verifica que sea un do while o while 
                    {
                        tagg += "Fin_" + tagFin + ":"; // se agrega el ultimo taf 
                        bandDoWhile = false; // se cambia la bandera 
                        tagFin = "";
                        tag.Add("");
                        tag.Add("");
                        tag.Add("");

                    }
                    else
                    {
                        // identificar el While
                        tagIni.Add("while" + _while + ":"); 
                        // y se agrega el tag 
                        tagg += "Ini_while" + (_while++) + ":";
                        // se activa la bandera del while 
                        bandWhile = true;
                    }
                } // si es un do while 
                else if (token.Contains("do"))
                {
                    // identificar el doWhile
                    tagIni.Add("dowhile" + _doWhile + ":");
                    // se agrega el tag 
                    tagg += "Ini_dowhile" + (_doWhile++) + ":";
                    // activa la bandera del do while 
                    bandDoWhile = true;
                }
               
                if (token.Contains("}")) // al final busca la llave de cierre 
                {/*R*E*T*B*O*T*/
                    if (bandIF && tagFin.Contains("if")) // bandera para cerrar el if 
                    {
                        tagg += "Fin_" + tagFin; // Se agrega el tag final 
                        bandIF = false;
                        tagFin = "";
                    }
                    else if (bandElse && tagFin.Contains("else"))
                    {  // bandera para cerrar el else
                        tagg += "Fin_" + tagFin;// Se agrega el tag final 
                        bandElse = false;
                        tagFin = "";
                    }
                    else if (bandSW && tagFin.Contains("switch")) // si es un switch 
                    {
                        tagg += "Fin_" + tagFin;// Se agrega el tag final 
                        bandSW = false;
                        tagFin = "";
                    }
                    else if (bandFor && tagFin.Contains("for")) // si es un for 
                    {
                        tag.Add("goto Ini_" + tagFin); // se agrega el goto para regresar al inicio 
                        tagg += "Fin_" + tagFin; // Se agrega el tag final 
                        bandFor = false; // se cambia la bandera del for 
                        tagFin = "";
                        
                    }
                    else if (bandWhile && tagFin.Contains("while")) // se busca el while 
                    {
                        tag.Add("");
                        tagg += "Fin_" + tagFin;// Se agrega el tag final 
                        bandWhile = false; // se cambia la bandera del while 
                        tagFin = "";
                        tag.Add("");
                    }
                    else if (!bandMain && tagFin.Contains("main")) // se busca el while 
                    {
                        tagg += "Fin_" + tagFin;// Se agrega el tag final 
                    }
                    else if (tagFin.Contains(metodosJava.Last()))
                    {
                        tagg = "Fin_" + tagFin;// Se agrega el tag final 
                        bandMetodo = false;
                    }
                }/*R*E*T*B*O*T*/
                if (bandMain) { // si es el man, cambia la bandera 
                    bandMain = false;
                }

                if (token.Contains("class Main")) // Si encuentra un class Main 
                {
                    bandMain = true; // cambia la bandera para no agregarlo 
                    cantLineas--; // y quita el ultimo elemento 
                }
                
                if(!bandMain) // mientras sea diferente de un Class Main 
                tag.Add(tagg);// Por ultimo agrega los tagg en el List de tag
                  
            }
        }
        #endregion
        #endregion

        #region Metodos implementados en FERIR  
        #region Temporales FERIR
        public static void genTemporalesFERIR(List<String> temporal, List<String> resultado)
        {
            int tmp = 1; // Inicio de los temporales 
            bool bandAsignacion = false;// banda opara la asignacion 
            string temAsignacion = "";/*R*E*T*B*O*T*/
            // bandera para cada metodo 
            bool bandSI = false, bandContrario = false, bandCambio = false, bandMientras = false, bandHacer = false, bandPor = false, bandCambioPor = false;
            bool bandPor2 = false;
            // Junto con la cantidad de veces que se acceden a ellas 
            int _si = 0, _contrario = 0, _cambio = 0, _mientras = 0, _hacer = 0, _por = 0,canPor = 0;
            // verifica el metodo que es 
            string es = "";
            // por para hacer recorrido por la linea 
            for (int i = 0; i < temporal.Count; i++)
            {
                bool band = false; // Bandera para los temporales que solo tengan '='
                bool bandTem = false; // Bandera para temporales que tengan signo 
                bool band2 = false;// Bandera para los temporales que solo tengan '>'
                bool band3 = false;// Bandera para los temporales que solo tengan '>='
                bool band4 = false; // Bandera para los temporales que solo tengan '<'
                bool band5 = false; // Bandera para los temporales que solo tengan '<='
                bool band6 = false; // Bandera para los temporales que solo tengan ':'

                // El resultado de los temporales se va a ir escribiendo sobre este string
                String res = "";  // y se reinicia con cada salto de linea
                char[] pal = temporal[i].ToArray();// Se crea un arreglo de char con el String del temporal entrante 

                // verifica si es 
                string sino = temporal[i];
                if (sino.Contains("contrario")) // contrario 
                {/*R*E*T*B*O*T*/
                    bandContrario = true;
                    resultado.Add(" ");
                }
                else if (sino.Contains("si")) // Si 
                {
                    bandSI = true;
                }
                else if (sino.Contains("}")) // una llave de cierre 
                {
                    resultado.Add(""); // agega su espacio 
                    if (bandPor2) // si es un for, agrega dos espacios 
                    {
                        resultado.Add("");
                        bandPor2 = false;
                    }
                }
                else if (sino.Contains("cambio")) // si es un cambio 
                {
                    bandCambio = true;
                }
                else if (sino.Contains("mientras")) // si es el mientras 
                {
                    bandMientras = true;/*R*E*T*B*O*T*/
                }
                else if (sino.Contains("hacer")) // si es hacer 
                {
                    bandHacer = true;
                }
                else if (sino.Contains("por")) // o un por 
                {
                    bandPor = true;
                }
                else if (sino.Contains("regresa")) // si encunetra un regresar 
                {
                    string metod = metodosFERIR.First();// obtiene el primer elemento de los metodos
                    metodosFERIR.RemoveAt(0); // remueve el ultimo elemento del metodo (de donde se encontro )
                    string go = "goto call_" + metod; // lo agrega para llamarlo 

                    metod = metodosFERIR.First(); // se obtiene el nombre del metodo llamado 
                    metodosFERIR.RemoveAt(0); // remueve el ultimo elemento del metodo
                    go += "_" + metod; // y lo agrega todo a un stringn 
                    resultado.Add(go); // por ultimo lo agrega a los resultados 

                }
                else if (rgxid.IsMatch(sino)) // si es un identificador 
                {/*R*E*T*B*O*T*/
                    // no hace nada
                }
                else if (rgxMet2.IsMatch(sino)) // o una metodo
                {
                    res += "Call "; // se le llama 
                    int c = 0;
                    while (!pal[c].Equals('(')) // recorre la palabra y va concatenando, hasta encontrar el signo ( 
                    {
                        res += pal[c];
                        c++;
                    }
                    res += ": "; // y lo agrega a los resultados
                    resultado.Add(res);
                    res = "";
                }
                else if (_clase.IsMatch(sino)) // si es una clase agrega su espacio en blanco 
                {
                    resultado.Add(" ");
                }/*R*E*T*B*O*T*/
                // variable para guardar la posicion del signo 
                int posSigno = 0;
                // se recorre todo el arreglo // toda la linea de codigo 
                for (int j = 0; j < pal.Length; j++)
                {
                    if (pal[j].Equals('=')) // Lo primero que se busca es encontrar un = 
                    {// Si lo encuentra se escribe el temporal (T) más el número de temporales y se activa la bandera 
                     // para escribir el contenido restante del arreglo de char 
                        bool bandAsAux = false;
                        for (int b = j; b < pal.Length; b++)
                        {
                            for (int c = 0; c < operadores.Length; c++)
                            {
                                if (pal[b].Equals("")) { break; } // palabra en blanco 

                                else if (pal[b].Equals(operadores[c])) // busca operadores 
                                {
                                    res = "T" + (tmp++) + " "; // Si es >= se escribe el temporal (T) más el número de temporales y se activa la bandera 
                                    bandTem = true; // temporal con signo 
                                    bandAsignacion = true; // asignacion 
                                    bandAsAux = true; // aignacion 2
                                    posSigno = j;
                                    break; // encuentra el operador y se sale 
                                }
                            }/*R*E*T*B*O*T*/
                        }
                        if (bandAsAux) // para obtener el nombre de la variable 
                        {
                            for (int c = 0; c < j; c++)
                            {
                                temAsignacion += pal[c];
                            }
                            bandAsAux = false;
                        }
                        // se activa la primera bandera 
                        band = true;
                    }
                    else if (pal[j].Equals('>'))
                    { // Si no es un =, entonces buscara el siguiente signo que es el > 
                        if (pal[j + 1].Equals('='))
                        { // busca en el siguiente valor del arreglo para verificar que no sea un >= 
                            res = "T" + (tmp++) + " = "; // Si es >= se escribe el temporal (T) más el número de temporales y se activa la bandera 
                            if (!bandPor)  // si no es un por, aumenta en uno a j, si es un por, no lo aumenta 
                                j++; // Se suma uno a la j, para saltar el signo = 
                            band3 = true; // pone la bandera 3 en verdadera
                            posSigno = j;
                            break;
                        }/*R*E*T*B*O*T*/
                        else
                        { // Si no, entonces solose escribe el temporal (T) más el número de temporales y se activa la bandera y se aumenta uno a la j
                            res = "T" + (tmp++) + " = ";
                            band2 = true; // despues activa la badera 
                            posSigno = j;
                            if (!bandPor)// si no es un for, aumenta en uno a j, si es un for, no lo aumenta 
                                j++;
                            break;
                        }
                    }/*R*E*T*B*O*T*/
                    else if (pal[j].Equals('<'))  // Si no son los signos anteriores, entonces buscara el siguiente signo que es el <
                    {
                        if (pal[j + 1].Equals('=')) // busca en el siguiente valor del arreglo para verificar que no sea un <= 
                        {
                            res = "T" + (tmp++) + " = "; // Si es >= se escribe el temporal (T) más el número de temporales y se activa la bandera 
                            if (!bandPor)// si no es un por, aumenta en uno a j, si es un por, no lo aumenta 
                                j++; // Se suma uno a la j, para saltar el signo = 
                            band5 = true;// activa la bandera 5 
                            posSigno = j;
                            break;
                        }
                        else
                        { // Si no, entonces solose escribe el temporal (T) más el número de temporales y se activa la bandera y se aumenta uno a la j
                            res = "T" + (tmp++) + " = ";
                            if (!bandPor)// si no es un for, aumenta en uno a j, si es un for, no lo aumenta 
                                j++;
                            band4 = true;// avtiva la bandera 4 
                            posSigno = j;
                            break;
                        }
                    }// Si no, entonces busca el ; y si es el de cierre no entra, pero si no es el ultimo, entonces es un por
                    else if (pal[j].Equals(';') && (j + 2) < pal.Length)
                    {
                        band6 = true;// activa la badnera para empezar a escribir 
                        _por++; // aumenta el por
                        break;
                    }
/*R*E*T*B*O*T*/
                }
                // Las banderas estan creadas para seguir escribiendo despues de encontrar el singo a buscar 
                if (band)// bandera uno 
                {
                    if (bandTem)
                    {// entra si es un operador 
                        for (int j = posSigno; j < pal.Length; j++)
                            res += pal[j];
                    }
                    else
                    {// si no contiene operador 
                        for (int j = 0; j < pal.Length; j++)
                            res += pal[j];
                    }
                }
                // para el signo mayor // para el signo mayor o igual 
                // para el signo menor // para el signo menor o igual 
                if (band2 || band3 || band4 || band5)
                {
                    int j = 0;
                    while (!pal[j].Equals('('))
                    {
                        j++;
                    }
                    j++;
                    while (!pal[j].Equals(')'))
                    {
                        res += pal[j++];
                    }/*R*E*T*B*O*T*/
                }
                if (band6) // para el por 
                {
                    for (int j = 0; j < pal.Length; j++)
                    {
                        if (_por == 1) // para la primer seccion del por 
                        {
                            res = "";
                            string res2 = "";
                            for (int /*R*E*T*B*O*T*/ n = j + 4; n >= 0; n--) // recorre la primer seccion 
                            {
                                if (pal[n] != ';')// si es un ;  lo quita
                                {
                                    res += pal[n]; // almacena la primera seccion 
                                }
                                j++;
                            }
                            while (pal[j] != ' ')
                            {
                                res2 += pal[j];
                                j++;
                            }
                            j--;
                            while (pal[j] != ' ')
                            {
                                j--;
                            }
                            res2 += res;
                            band6 = false; // se cambia el estado de la bancera 6 
                            resultado.Add(res2); // el resultado se agrega al List tmpResultado    
                            res = ""; // se quita el resultado, para seguir con la siguiente seccion 
                            bandPor = false; // se activa la bandera del for 
                            bandPor2 = true;
                            canPor++; // aumenta la cantidad de for 
                            _por++;/*R*E*T*B*O*T*/
                        }
                        else if (_por == 2)
                        { // si no entra en la segunda seccion del por
                            if (pal[j].Equals(';')) // recorre el arreglo hasta encontrar el ; limite de la segunda seccion 
                            {
                            string result = "T" + (tmp++) + " = " + res;
                            _por++;
                            string ir = /*R*E*T*B*O*T*/ "si T" + (tmp - 1) + " ";
                            // verifica el signo, si es <, <=, >, >= y ke agrega el goto 
                            if (result.Contains("<"))
                            {
                                result = Regex.Replace(result, @"<", "-");// se cambia el mayor, por el signo de menos
                                ir += " menor a 0 goto Fin_por" + canPor; // se agrega el goto 
                            }
                            else if (result.Contains("<="))
                            {
                                result = Regex.Replace(result, @"<=", "-");// se cambia el mayor o igual, por el signo de menos 
                                ir += " menor o igual a 0 goto Fin_por" + canPor;// se agrega el goto 
                            }
                            else if (result.Contains(">"))
                            {
                                result = Regex.Replace(result, @">", "-");// se cambia el mayor o igual, por el signo de menos 
                                ir += "mayor a 0 goto Fin_por" + canPor;// se agrega el goto 
                            }
                            else if (result.Contains(">="))
                            {
                                result = Regex.Replace(res, @">=", "-");// se cambia el mayor o igual, por el signo de menos 
                                ir += " mayor o igual a 0 goto Fin_por" + result;// se agrega el goto 
                            }
                            // se agrega el resultado y el goto 
                            resultado.Add(result); // se agrega el resultado 
                            resultado.Add(ir); // junto con el goto 
                            res = "";/*R*E*T*B*O*T*/
                            // se cambian las banceras 
                            bandPor = true;
                            band6 = false;
                            band4 = false;
                            // se aumenta la j en 2 
                            j = j + 2;
                            // y se activa la bandera del Por 
                            bandCambioPor = true;
                            }
                            else
                            { // mientras no sea ; va concatenando 
                                // agrega los datos
                                res += pal[j];
                            }
                        }
                        else // para la tercera seccion del por 
                        {
                            int posIni /*R*E*T*B*O*T*/ = j + 1;
                            bool bandAsAux = false;
                            res = "T" + (tmp++) + " "; // Si es >= se escribe el temporal (T) más el número de temporales y se activa la bandera 
                            for (int b = j; b < pal.Length; b++)
                            {
                                if (pal[b].Equals('='))
                                {
                                    while (!pal[b].Equals(')'))
                                    {
                                        res += pal[b];
                                        b++;
                                    }
                                    resultado.Add(res);
                                    bandAsignacion = true; // asignacion 
                                    bandAsAux = true;
                                    break;
                                }
                            }

                            // Variable para guardar el nombre de la variable 
                            if (bandAsAux)
                            {
                                int c = posIni;
                                while (!pal[c].Equals(';'))
                                {
                                    c--;/*R*E*T*B*O*T*/
                                }
                                c++;
                                while (!pal[c].Equals('='))
                                {
                                    temAsignacion += pal[c];
                                    c++;
                                }
                                bandAsAux = false;
                                break;
                            }
                        }
                    }
                }
            

                // entra si encuentra activa alguna bandera 
                if (band || bandSI || bandCambio || bandMientras || bandHacer)
                {
                    if (band)
                    { // en el resultado para la bandera 1, se queda almacenado el ; 
                        res = Regex.Replace(res, @";", ""); // Con el regex se cambia el punto y coma, por un espacio en blanco
                    }
                    if (band2)
                    { // en el resultado para la bandera 2
                        res = Regex.Replace(res, @">", " - ");// se cambia el mayor, por el signo de menos 
                        es = "mayor";
                    }
                    if (band3)
                    {// en el resultado para la bandera 3 
                        res = Regex.Replace(res, @">=", " - ");// se cambia el mayor o igual, por el signo de menos 
                        es = "mayor o igual";
                    }/*R*E*T*B*O*T*/
                    if (band4)
                    {// en el resultado para la bandera 4
                        res = Regex.Replace(res, @"<", " - ");// se cambia el menor, por el signo de menos 
                        es = "menor";
                    }
                    if (band5)
                    {// en el resultado para la bandera 5
                        res = Regex.Replace(res, @"<=", " - ");// se cambia el menor o igual, por el signo de menos 
                        es = "menor o igual";
                    }

                    resultado.Add(res); // el resultado se agrega al List tmpResultado 

                    if (bandSI) // Si encientra el SI, se le agrega el goto
                    {
                        int tmpante = tmp - 1;
                        resultado.Add("Si false T" + tmpante + " " + es + "  a 0 goto Fin_si" + (++_si) + " : ");
                        bandSI = false;
                    }
                    /*else if (bandElse)
                    {
                        int tmpante = tmp - 1;
                        resultado.Add("Si false T" + tmpante + " " + es + "  a 0 \n goto fin_else" + (_else++) + " : ");
                        bandElse = false;
                    }*/
                    else if/*R*E*T*B*O*T*/ (bandCambio)// Si encientra el CAMBIO, se le agrega el goto
                    {
                        int tmpante = tmp - 1;
                        resultado.Add("Si false T" + tmpante + " " + es + "  a 0 goto Fin_cambio" + (++_cambio) + " : ");
                        bandCambio = false;
                    }
                    else if (bandMientras)// Si encientra el MIENTRAS, se le agrega el goto
                    {
                        if (bandHacer) // Si encientra el HACER, se le agrega el goto
                        {
                           /*R*E*T*B*O*T*/ int tmpante = tmp - 1;
                            resultado.Add("Si false T" + tmpante + " " + es + "  a 0 goto Ini_hacer" + (++_hacer) + " : ");
                            bandHacer = false;
                            bandMientras = false;
                        }
                        else
                        { // Si no encuentra el hacer, entra en el mientras y se agrega el goto
                            int tmpante = tmp - 1;
                            resultado.Add("Si false T" + tmpante + " " + es + "  a 0 goto Fin_mientras" + (++_mientras) + " : ");
                            bandMientras = false;
                        }

                    }

                }
                
                // Si la asignacion se encuentra activa entra 
                if (bandAsignacion)
                {/*R*E*T*B*O*T*/
                    char[] v = res.ToCharArray(); // se crea un arreglo de char 
                    string temporalAsinacion = ""; // se crea una variable de asignacion  
                    int h = 0;
                    for (h = 0; h < 2; h++) // se recorre el resultado 
                    {
                        temporalAsinacion += v[h]; // se agrega el temporal 
                    }

                    // se agrega el temporal 
                    temAsignacion += "= " + temporalAsinacion;
                    resultado.Add(temAsignacion);
                    bandAsignacion = false;
                    temAsignacion = ""; // variable 
                    res = "";
                }
            }
        }
        #endregion

        #region TAG FERIR
        public static void genTagFERIR(List<String> contenido, List<String> tag)
        {
            // Arreglo para almacenar la posicion de los tag de inicio, para el cierre  
            List<String> tagIni = new List<string>();
            string tagFin = "";
            // list para guardar los metodos FERIR 
            metodosFERIR = new List<string>();

            // contadores de tag (inicio y cierre)
            int _si = 1;
            int _contrario = 1;
            int _cambio = 1;
            int _caso = 1;/*R*E*T*B*O*T*/
            int _por = 1;
            int _hacer = 1;
            int _mientras = 1;
            int _main = 1;

            // banderas para controlar e inicio y fin 
            bool bandSI = false;
            bool bandContrario = false;
            bool bandCambio = false;
            bool bandPor = false;
            bool bandhacer = false;
            bool bandmientras = false;
            bool bandMain = false;
            bool bandMetodo = false;

            int cantLineas = contenido.Count;
            for (int i = 0; i < cantLineas; i++) // Ciclo para obtener línea por línea el código fuente
            {
                string token = contenido[i];  // Se obtiene el token (en este caso es la toda la línea de 0 hasta n)
                string tagg = ""; // variable para almacenar el tag 
                string cf = "";

                if (token.Contains("}")) // si encuentra una llave de cierre 
                {
                    if (tagIni.Count > 0) // verifica que los tag contengan infromacion 
                    {
                        tagFin = tagIni.Last(); // se obtiene el ultimo, para despues usarlo 
                        tagIni.RemoveAt(tagIni.Count - 1); // lo elimina 
                    }
                }
                else if (token.Contains("vacio principal")) // si encuentra el vacio princial 
                {
                    // lo agrega a los tag 
                    tagIni.Add("prrincipal" + _main + ":");
                    // se agrega el tag 
                    tagg += "Ini_principal" + (_main++) + ":";
                }
                else if (rgxMet.IsMatch(token)) // si es un metodo 
                {
                    char[] cfC = token.ToCharArray(); // crea un arreglo de char 
                    for (int c = 0; c < cfC.Length; c++) // recorre el arreglo 
                    {
                        int pos = c;/*R*E*T*B*O*T*/
                        if (cfC[c].Equals('(')) // hasta encontrar el ( 
                        {
                            while (!cfC[c].Equals(' ')) // regresa en el arreglo, hasta encontrar un caracter vacio 
                            {
                                c--;
                            }
                            c++;
                            while (c < pos) // para despues ir concatenando el nombre de ese mentodo en cf
                            {
                                cf += cfC[c++];
                            }
                            break;
                        }
                    }
                    // identificar el metodo en el tag ini 
                    tagIni.Add(cf + ":");
                    // se agrega el tag 
                    tagg = cf + ":";
                    metodosFERIR.Add(cf); // lo agrega a los metodos identificados 
                    bandMetodo = true;
                }
                else if (rgxMet2.IsMatch(token)) // pero si es una llamada del metodo 
                {
                    char[] cfC = token.ToCharArray();
                    for (int c = 0; c < cfC.Length; c++) // lo recorre hasta encontrar un (, y guardamos el nombre en cf 
                    {
                        while (!cfC[c].Equals('('))
                        {
                            cf += cfC[c++];
                        }
                        break;/*R*E*T*B*O*T*/
                    }
                    // lo agregamos a los metodos, junto con quien lo llamo 
                    metodosFERIR.Add(tagIni.Last()); 
                    metodosFERIR.Add(cf);
                }
               
                // Para generar los tags del si //
                if (token.Contains("si")) // Busca la palabra si en la línea de código 
                { // Si la encuentra se pone una etiqueta sobre la línea y aumenta el contador de si
                    // identificar el si
                    tagIni.Add("si" + _si);
                    // se agrega el tag 
                    tagg += "Ini_si" + (_si++);
                    tag.Add(tagg);
                    tagg = ""; // goto
                    // bandera para activar el si
                    bandSI = true;
                }
                else if (token.Contains("} contrario { ") || token.Contains("}contrario{") || token.Contains("contrario{") || token.Contains("contrario {")) // si no, entonces busca un } contrario 
                { // Si la encuentra se pone una etiqueta sobre la línea y aumenta el contador de el fin si y el inicio del contrario

                    if (tagFin.Contains("si")) // bandera para cerrar el si 
                    {
                        tag.Add("");
                        tagg += "Fin_" + tagFin;
                        bandSI = false;
                        tag.Add(tagg);
                        tagg = "";
                        tagFin = "";
                    }
                    // identificar el contrario
                    tagIni.Add("contrario" + _contrario);
                    // se agrega el tag
                    tagg += "Ini_contrario" + (_contrario++);
                    bandContrario = true;
/*R*E*T*B*O*T*/
                }
                /*else if (token.Contains("contrario")) // si no, entonces busca un contrario 
                { // Si la encuentra se pone una etiqueta sobre la línea y aumenta el contador de contrario
                    tagg += "Ini_contrario" + (_contrario++);
                    bandContrario = true;
                }*/
                // Para generar los tags del cambio //
                if (token.Contains("cambio"))// Busca la palabra cambio en la línea de código 
                {// Si la encuentra se pone una etiqueta sobre la línea y aumenta el contador de cambio
                    // identificar el cambio
                    tagIni.Add("cambio" + _cambio);
                    // se agrega el tag 
                    tagg += "Ini_cambio" + (_cambio++) + ":";
                    tag.Add(tagg);
                    tagg = "";
                    bandCambio = true;
                }
                else if (token.Contains("caso"))//Si no, entonces busca la palabra caso en la línea de código 
                {// Si la encuentra se pone una etiqueta sobre la línea y aumenta el contador de caso
                    tagg += "caso" + (_caso++) + ":";
                }
                else if (token.Contains("romper")) // al final busca el romper, y pone el go to del cambio 
                {
                    int swAnte = _cambio - 1;// cambio anterior
                    tagg += "goto Fin_cambio" + swAnte + ":"; // cambio anterior
                }
                
                // si encuentra el por 
                if (token.Contains("por"))
                {
                    // identificar el por
                    tagIni.Add("por" + _por + ":");
                    // se agrega el tag 
                    tagg += "Ini_por" + (_por++) + ":";
                    tag.Add(tagg);
                    tag.Add("");
                    tagg = "Cuerpo_por" + (_por - 1) + ": ";
                    tag.Add(tagg);
                    tagg = "";
                    tag.Add(tagg);
                    bandPor = true;
/*R*E*T*B*O*T*/
                }
                // Si encuentra el mientras 
                if (token.Contains("mientras"))
                {
                    // si tiene la bandera hacer y contiene el mientras 
                    if (bandhacer || tagFin.Contains("mientras"))
                    {
                        tagg += "Fin_" + tagFin; // se agrega el tag 
                        bandhacer = false; // se cambia la bandera 
                        tagFin = "";
                        tag.Add("");
                        tag.Add("");
                        tag.Add("");

                    }
                    else
                    {
                        // identificar el mientras y se agrega el tag inicial 
                        tagIni.Add("mientras" + _mientras);
                        tagg += "Ini_mientras" + (_mientras++);
                        bandmientras = true;
                    }
                }
                // si no, busca el hacer 
                else if (token.Contains("hacer"))
                {
                    // identificar el hacer
                    tagIni.Add("hacer" + _hacer);
                    // se agrega el tag de inicio 
                    tagg += "Ini_hacer" + (_hacer++);
                    bandhacer = true;
                }
                // busca la llave de cierre 
                if (token.Contains("}"))
                {
                    if (bandSI && tagFin.Contains("si")) // bandera para cerrar el si 
                    {
                        tagg += "Fin_" + tagFin; // se agrega el tag final 
                        bandSI = false;
                        tagFin = "";
                    }
                    else if(bandContrario && tagFin.Contains("contrario"))  // bandera para cerrar el contrario 
                    {
                        tagg += "Fin_" + tagFin; // se agrega el tag final 
                        bandContrario = false;
                        tagFin = "";
                    }
                    else if(bandCambio && tagFin.Contains("cambio"))  // bandera para cerrar el cambio
                    {
                        tagg += "Fin_" + tagFin;// se agrega el tag final 
                        bandCambio = false;
                        tagFin = "";
                    }
                    else if(bandPor && tagFin.Contains("por")) // bandera para cerrar el por
                    {
                        tag.Add("goto Ini_" + tagFin); //se agrega el goto y el tag final 
                        tagg += "Fin_" + tagFin; 
                        tagFin = "";
                        bandPor = false;
                    }
                    else if(bandmientras && tagFin.Contains("mientras")) // bandera para cerrar el mientras
                    {
                        tag.Add("");
                        tagg += "Fin_" + tagFin; //se agrega el tag final 
                        bandmientras = false;
                        tagFin = "";
                        tag.Add("");
                    }
                    else if (!bandMain && tagFin.Contains("main")) // se busca el while 
                    {
                        tagg += "Fin_" + tagFin;// Se agrega el tag final 
                    }
                    else if (tagFin.Contains(metodosFERIR.Last()))
                    {
                        tagg = "Fin_" + tagFin;// Se agrega el tag final 
                        bandMetodo = false;
                    }
                }
                if (bandMain)
                {
                    bandMain = false;
                }

                if (token.Contains("clase Principal"))
                {
                    bandMain = true;
                    cantLineas--;
                }
                // Por ultimo agrega los tagg en el List de tag
                if (!bandMain)
                    tag.Add(tagg);

            }
        }
        #endregion
        #endregion/*R*E*T*B*O*T*/

        #region INSERCION EN COLA 
        public void InsertarEnCola(string expresion) // línea de código 
        {
            string[] palabra = expresion.Split(' '); // se divide por los espacios vacíos 

            for (int i = 0; i < palabra.Length; i++)
            {
                colaExpresion.Enqueue(palabra[i].ToString());// se agrega a la cola 
            }
        }
        #endregion
    }
}
