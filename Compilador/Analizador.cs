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
            // RETBOT
            contenido.Clear();                                          // Se limpiar la lista contenido
            cmboxCodigoFuente.Items.Clear();

            String codigo = PagCodigo.Text;                             // Se poner todo el código en la variable
            String palabra = "";                                        // y se una una variable auxiliar                     
            codigo += '\n';                                             // concatenamos un salto de linea al final                                            

            foreach (Char c in codigo)
            {                                                           // lee todos los caracteres del codigo 
                if (c == '\n')
                {                                                       // Si se encuantra un salto de linea                                                      
                    String p = "";                                      // Variable local 

                    if (palabra.Contains("//"))
                    {
                        p = palabra.Substring(0, palabra.Length - 2);   // se quitan las diagonales de comentarios
                    }
                    else
                    {
                        p += palabra;                                   // p = palabra, palabra contiene los tokens de la linea
                    }
                    contenido.Add(p);                                   // Añadir p a la lista
                    cmboxCodigoFuente.Items.Add(palabra);
                    palabra = "";                                       // Limpiar la palabra  // R3TB0T           
                }
                else if (c == '\r' || c == '\t')                        // Condición para ignorar otros caracteres especiales
                { }
                else
                {
                    if (palabra.Contains("//")) { }                       // Eliminar comentario, pero no //  // R3TB0T  
                    else if (c == ' ' && palabra.Length == 0) { }         // Eliminar espacios iniciales    
                    else
                    {
                        palabra += c;                                   // concatena el caracter en el string para generar el token 
                    }
                }
            }
        }
        #endregion
        /// <summary>
        /// Método para dividir en bloques léxicos
        /// </summary>
        public void bloquesLexico(ListView listViewToken, List<string> palabrasReservadas, bool titulos, RegexLexer csLexer, List<String> contenido, Stack pilaLexico)
        
        {
            int numTablas = 0;

            foreach (String s in contenido)
            {
                if (s.Contains('{'))                                        // R3TB0T
                {
                    pilaLexico.Push("{");
                    numTablas++;
                }
                else if (s.Contains('}'))
                {
                    pilaLexico.Push("}");
                }
                else
                {
                    pilaLexico.Push(s);
                }
            }
            string[] lexico = new string[numTablas];
            int i = 0;
            while (pilaLexico.Count != 0)
            {
                if (pilaLexico.Peek() == "}") // R3TB0T
                {
                    string valAnterior = pilaLexico.Pop().ToString();
                }
                 
                if (pilaLexico.Peek() != "}")
                {
                    lexico[i] += pilaLexico.Pop().ToString() + " ";
                    string valSiguiente = pilaLexico.Peek().ToString();
                    if (valSiguiente == "}")
                    {
                        i++;
                    }
                    if (valSiguiente == "{")
                    {
                        if (i == 0)
                        {
                            i++;
                        }
                        else
                        {
                            i--;
                        }
                    }
                    if (pilaLexico.Peek() == "{")
                    {
                        pilaLexico.Pop();
                        if (pilaLexico.Count != 0)
                        {
                            if (pilaLexico.Peek() == "}")
                                i += 2;
                        }
                    }// R3TB0T
                }
            }
            for (int j = 0; j < lexico.Length; j++)
            {
                AnalizeCode(lexico[j], numTablas + 1, "1", listViewToken, palabrasReservadas, titulos, csLexer); // string texto, int indiceT, string tablaPadre, ListView listViewToken, List<string> palabrasReservadas // R3TB0T
                numTablas--;// R3TB0T
            }
        }
        /// <summary>
        /// Método para retornar la precedencia de los operadores 
        /// </summary>
        public static bool precedenciadeoperadores(char top, char p_2)
        {
             if (top == '+' && p_2 == '*') // + tiene menor precedencia que *           // R3TB0T
                return false; // R3TB0T
            if (top == '*' && p_2 == '-') // * tiene mayor precedencia que -
                return true;
            if (top == '+' && p_2 == '-') // + tiene la misma precedencia que +
                return true;
            return true; // R3TB0T
        }
        /// <summary>
        /// Método para pasar de infijo a posfijo
        /// </summary>
        public static string PasarStringPosfijo(string stringeninfijo)
        
        {
            int tamanio = stringeninfijo.Length; // Tamaño de la cadena infijo
            Stack<char> pila = new Stack<char>(); // Pila para almacenar caracteres infijo 
            StringBuilder stringenposfijo = new StringBuilder(); // Leer caracteres infijo
            for (int i = 0; i < tamanio; i++)
            {
                if ((stringeninfijo[i] >= '0') && (stringeninfijo[i] <= '9')) // Si esta entre el 0 y 9     // R3T B0T
                {
                    stringenposfijo.Append(" "); //  Agrega un espacio y después el char de infijo en la posición i al infijo // R3T B0T
                    stringenposfijo.Append(stringeninfijo[i]);

                }
                else if (stringeninfijo[i] == '(') // si contiene un '('
                {
                    pila.Push(stringeninfijo[i]); // lo agrega a la pila 
                }
                // Si la cadena infija contiene un '* + - /'
                else if ((stringeninfijo[i] == '*') || (stringeninfijo[i] == '+') || (stringeninfijo[i] == '-') || (stringeninfijo[i] == '/'))
                {
                    while ((pila.Count > 0) && (pila.Peek() != '(')) // Entra en el loop hasta que la pila no tenga datos o el último elemento es diferente de '(' // R3T B0T
                    {
                        if (precedenciadeoperadores(pila.Peek(), stringeninfijo[i])) // Verifica la precedencia del operador  R3T B0T
                        {
                            stringenposfijo.Append(pila.Pop()); // y lo agrega a la posfija // R3T B0T
                        }
                        else
                        {
                            break; // Si no, entonces termina el while
                        }
                    }
                    pila.Push(stringeninfijo[i]); // despues agrega la posicion i de la cadena infija a la pila
                }
                else if (stringeninfijo[i] == ')') // Si no, entonces verifica que el caracter sea ')'
                {// R3T B0T
                    while ((pila.Count > 0) && (pila.Peek() != '('))  // Entra en el loop hasta que la pila no tenga datos o el último elemento es diferente de '('
                    {
                        stringenposfijo.Append(pila.Pop()); // y lo agrega a la posfija 
                    }
                    if (pila.Count > 0) // si la pila tiene datos  // R3T B0T
                        pila.Pop(); // saca el ultimo elemento de la pila 
                }
                if (stringeninfijo[i] == ' ') // Si tiene un espacio en blanco 
                {
                    pila.Push(stringeninfijo[i]); // lo agrega a la pila
                }
            }
            while (pila.Count > 0) // si la pila contiene datos // R3T B0T
            {
                stringenposfijo.Append(pila.Pop()); // se agregan a la posfija
            }
            return stringenposfijo.ToString(); // al final regregresa la cadena posfija  // R3T B0T
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
            string valorPila = PasarStringPosfijo(texto); // Ingresamos el string posfijo R3T B0T
            string[] cont = valorPila.Split(' '); // lo ingresamos a un arreglo de string separándolo por espacios  // R3T B0T
            string[] numero = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" }; 
            pilaOp.Clear(); // limpiamos las pilas de operadores
            pilaOpInv.Clear();

            for (int i = 0; i < cont.Length; i++) // loop para recorrer los valores R3T B0T
            {
                pilaOp.Push(cont[i]); // se agrega a la pila de operadores 
                if (pilaOp.Peek() == " ") // Si es una cadena vacia  // R3T B0T
                {
                    pilaOp.Pop(); // se quita 
                }
            }
            while (pilaOp.Count != 0) // Si la pila contiene datos
            {
                pilaOpInv.Push(pilaOp.Pop()); // lo mete a la segunda pila 
            }
            verificarExp(linea); // y verifica la expresion // R3T B0T
        }

        /// <summary>
        /// METODO PARA INSERTAR EN NODO
        /// </summary>
        public static void Insertar(Nodo ar, string cad)
        
        {

            if (ar == null) // si no existe el nodo  // R3T B0T
            {
                Nodo nuevo = new Nodo(cad); // crea uno 
                ar = nuevo; // le inserta los datos // R3T B0T
                new Nodo(null, nuevo, nuevo);
                object sender = null;
                EventArgs e = null;

            }
            else
            { // si ya existe 
                string valorRaiz = ar.Datos.ToString();
                if (cad != valorRaiz) // solo inserta los datos, depndiendo del valor de la raiz R3T B0T
                {
                    Insertar(ar.NodoIzquierdo, cad); // esta puede ser izquierda // R3T B0T
                }
                else
                {
                    Insertar(ar.NodoDerecho, cad); // o derecha  // R3T B0T
                }
            }
        }

        /// <summary>
        /// METODO PARA VERIFICAR LAS LLAVES Y LOS PARENTESIS 
        /// </summary>
        public static bool analizaLlaves(ListView listViewError, List<String> contenido)
        
        {
            int linea = 1;
            int lineaP = 1;
            bool error = true;
            Stack<int> llaves = new Stack<int>();
            Stack<int> parentesis = new Stack<int>();

            foreach (String s in contenido) // ciclo para verificar la cadena de entrada // R3T B0T
            {
                if (s.Contains('{')) // verifica si es llave izquierda
                {
                    foreach (Char c in s)
                    {
                        if (c == '{') // si es 
                        {
                            llaves.Push(linea); // entonces lo pone en una pila 
                        }
                    }
                }
                if (s.Contains('(')) // verifica si es parentesis izquierdo 
                {
                    foreach (Char c in s) // si es 
                    {
                        if (c == '(')
                        {
                            parentesis.Push(lineaP); // entonces lo pone en una pila // R3T B0T
                        }
                    }
                }
                if (s.Contains('}')) // verifica si es llave derecha
                {
                    foreach (Char c in s)
                    {
                        if (llaves.Count > 0) // si es 
                        {
                            if (c == '}')
                            {
                                llaves.Pop(); // saca una llave de la pila // R3T B0T
                            }
                        }
                        else if (c == '}' && llaves.Count == 0) // en caso de tener mas llaves derechas, marca un error  
                        {
                            ListViewItem listaTitulos = new ListViewItem(linea.ToString());
                            listaTitulos.SubItems.Add("Sintácticos");
                            listaTitulos.SubItems.Add("Falta abrir llave.");
                            listViewError.Items.Add(listaTitulos).BackColor = Color.FromArgb(247, 75, 64); //si el contador es <0, mostrar mensaje
                            error = false;
                        }
                    }
                }
                if (s.Contains(')')) // verifica si es parentesis derecho // R3T B0T
                {
                    foreach (Char c in s)
                    {
                        if (parentesis.Count > 0)
                        {
                            if (c == ')')// si es 
                            {
                                parentesis.Pop(); // saca un parentesis de la pila 
                            }
                        }
                        else if (c == ')' && parentesis.Count == 0)  // en caso de tener mas parentesis derechos, marca un error  // R3T B0T
                        {
                            ListViewItem listaTitulos = new ListViewItem(lineaP.ToString());
                            listaTitulos.SubItems.Add("Sintácticos");
                            listaTitulos.SubItems.Add("Falta abrir parentesis.");
                            listViewError.Items.Add(listaTitulos).BackColor = Color.FromArgb(247, 75, 64); //si el contador es <0, mostrar mensaje // R3T B0T
                            error = false;
                        }// R3T B0T
                    }
                }
                linea++;
                lineaP++;
            }
            int i = 0;
            int k = 0;
            while (llaves.Count > 0) // si tiene mas llaves derechas, que izquierdas, marca un error
            {
                i = llaves.Pop();// R3T B0T
                ListViewItem listaTitulos = new ListViewItem(i.ToString());
                listaTitulos.SubItems.Add("Sintácticos");// R3T B0T
                listaTitulos.SubItems.Add("Falta cerrar llave.");
                listViewError.Items.Add(listaTitulos).BackColor = Color.FromArgb(247, 75, 64);  // Si el contador es < 0, mostrar mensaje    
                error = false;
            }
            while (parentesis.Count > 0)// si tiene mas parentesis derechos, que izquierdos, marca un error
            {
                k = parentesis.Pop();
                ListViewItem listaTitulos = new ListViewItem(k.ToString());
                listaTitulos.SubItems.Add("Sintácticos");// R3T B0T
                listaTitulos.SubItems.Add("Falta cerrar parentesis.");
                listViewError.Items.Add(listaTitulos).BackColor = Color.FromArgb(247, 75, 64);  // Si el contador es < 0, mostrar mensaje    
                error = false;
            }
            return error;
        }
        /// <summary>
        /// METODO PARA analizar el codigo 
        /// </summary>
        public static void AnalizeCode(string texto, int indiceT, string tablaPadre, ListView listViewToken, List<string> palabrasReservadas, bool titulos, RegexLexer csLexer)
        
        {

            if (titulos == true) // verifica si la tabla tiene titulos // R3T B0T
            {
                listViewToken.Items.Clear(); // se borran los iutems 
                ListViewItem listaTitulos = new ListViewItem("Token"); // se insertan los nuevos titulos 

                listaTitulos.SubItems.Add("Lexema"); 
                listaTitulos.SubItems.Add("Linea");// R3T B0T
                listaTitulos.SubItems.Add("Columna");
                listaTitulos.SubItems.Add("Indice");
                listaTitulos.SubItems.Add("Tipo de Dato");
                listaTitulos.SubItems.Add("ID Tabla");
                listaTitulos.SubItems.Add("Tabla Padre");

                listViewToken.Items.Add(" ");
                listViewToken.Items.Add(listaTitulos).BackColor = Color.FromArgb(255, 255, 67); //  junto con su respectivo color
            }
            titulos = true;  // cambia la bandera de los titulos 

            int n = 0, e = 0; // variables para el recorrido // R3T B0T

            foreach (var tk in csLexer.GetTokens(texto)) // ciclo para recorrer la cadena 
            {

                if (tk.Name == "ERROR") // cuenta los errores 
                {
                    e++;
                }
                if (tk.Name == "IDENTIFICADOR") // y pone los identificadores y las palabras reservadas 
                {
                    if (palabrasReservadas.Contains(tk.Lexema))
                    {
                        tk.Name = "RESERVADO";
                    }
                }// R3T B0T
                // despues se agregan un listview para el final agregarlo a una tabla 
                ListViewItem listaLexema = new ListViewItem(tk.Name);

                listaLexema.SubItems.Add(tk.Lexema);
                listaLexema.SubItems.Add(tk.Linea.ToString());
                listaLexema.SubItems.Add(tk.Columna.ToString());
                listaLexema.SubItems.Add(tk.Index.ToString());
                listaLexema.SubItems.Add(tk.TipoDato.ToString());
                listaLexema.SubItems.Add(indiceT.ToString());
                listaLexema.SubItems.Add(tablaPadre.ToString());// R3T B0T

                listViewToken.Items.Add(listaLexema).BackColor = Color.FromArgb(105, 255, 239);
                
                n++;

            }

            //AGREGA DATOS EN LA COLUMNA LLAMADA TIPO DE DATOS, SOLO CUANDO ES UN IDENTIFICADOR
            for (int a = 0; a < listViewToken.Items.Count; a++)// R3T B0T
            {
                if (listViewToken.Items[a].SubItems[0].Text == "IDENTIFICADOR" && texto.Contains(" ") && listViewToken.Items[a - 1].SubItems[0].Text == "RESERVADO")
                {
                    string dato = listViewToken.Items[a - 1].SubItems[1].Text;
                    listViewToken.Items[a].SubItems[5].Text = dato;
                }
// R3T B0T

            }

        }
        /// <summary>
        /// MÉTODO PARA LAS PALABRAS RESERVADAS
        /// </summary>// R3T B0T
        public static void llamada(string codigo, RadioButton radioBtnJava, RadioButton radioBtnFERIR, PictureBox pbImagen, List<string> palabrasReservadas, string cadena, Arbol arbol, Nodo raiz, Grafico grafico)
        
        {
            if (codigo != "") // Si la cadena de codigo, no tiene informacion 
            {
                if (radioBtnJava.Checked == true) // verifica que el radio button java este seleccionado 
                {
                    // para despues insertar las palabras reservadas
                    if (palabrasReservadas.Contains(codigo)) // R3T B0T
                    {
                        cadena = Regex.Replace(codigo, "abstract | as |async |await |checked |const |continue |default |delegate |base |break |case |" +
                    "do |else |enum |event |explicit |extern |false |finally |fixed |for |foreach |goto |if |implicit |in |interface |internal |is |lock |new |null |operator |catch |" +
                    "out|override |params |private |protected |public |readonly |ref |return |sealed |izeof |stackalloc |static |switch |this |throw |true |try |typeof |namespace |" +
                    "unchecked |unsafe |virtual |void |while |float |int |long |object |get |set |new |partial |yield |add |remove |value |alias |ascending |" +
                    "descending |from |group |into |orderby |select |where |" +
                    "join|equals |using |bool |byte |char |decimal |double |dynamic |" +
                    "sbyte |short |string |uint |ulong |ushort |var |class |struct", "");
                        //txtLenguaje.Text = cadena;// R3T B0T
                    }
                }
                else if (radioBtnFERIR.Checked == true)// verifica que el radio button FEREIR este seleccionado 
                {
                    // para despues insertar las palabras reservadas
                    if (palabrasReservadas.Contains(codigo)) // R3T B0T
                    {
                        cadena = Regex.Replace(codigo, "abstracto | como |asincrono |esperar |comprobar |constante |seguir |defecto |delegar |base |romper |caso |" +
                    "hacer |sino |enumeracion |evento |explicito |externo|falso |finalmente |reparar |por |porcada |ir |si |implicito |en |interfaz |interno |es |cerar |nuevo |nulo |operador |captura |" +
                    "fuera|anular |parametro |privado |protegido |publico |lectura |arbitraria |regresa |sellado |tamaño |ampilar |estatico |cambio |esto |lanzar |verdadero |tratar |tipo de |nombre |" +
                    "desenfrenado |inseguro |virtual |vacio |mientras |flotante |entero |prolongar |objeto |obtener |asignar |nuevo |parcial |producir |añadir |borrar |valor |alias |asendente |" +
                    "desende |desde |grupo |dentro |ordenar |seleccionar |donde |" +
                    "entrar|igual |utilizar |booleano |byte |caracter |decimal |doble |dinamico |" +
                    "sbyte |corto |cadena |uentero |ulargo |ucorto |var |clase |estructura", "");
                        //txtLenguaje.Text = cadena;
                    }// R3T B0T
                }

                // y despues se inserta en la cola
                arbol.insertarEnCola(cadena);
                // se crea el arbol 
                raiz = arbol.crearArbol();

                //arbol.Limpiar();
                //Se insertan en las etiquetas los recorrimientos (Infijo, Postfijo y Prefijo).
                //pre, in, post
                grafico = new Grafico(arbol.NodoDot);// R3T B0T
                grafico.DrawTree();
                ShowTree(pbImagen);
            }
            else
            {
                MessageBox.Show("Debes ingresar una expresión aritmética. Intentalo de nuevo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }// R3T B0T
        }
        /// <summary>
        /// FUNCION PARA VISUALIZAR IMAGEN EN EL PROGRAMA EN TIEMPO REAL
        /// SE TIENE QUE CAMBIAR LA UBICACION DE LA RUTA CADA VEZ QUE SE EJECUTE EN EQUIPOS DIFERENTES
        /// EL ARCHIVO IMAGEN.PNG ES UN ARCHIVO VACIO EN EL CUAL SE SOBRE ESCRIBE CADA VEZ QUE SE CLICKLEA EL BOTON EJECUTAR
        /// </summary>// R3T B0T
        public static void ShowTree(PictureBox pbImagen)
        {
            if (File.Exists(@"C:\\Users\\user\\Imagen.png")) // modificar con el path de su pc 
            {// R3T B0T
                using (FileStream img = new FileStream(@"C:\\Users\\user\\Imagen.png", FileMode.Open, FileAccess.Read)) // modificar con el path de su pc 
                {
                    pbImagen.Image = Bitmap.FromStream(img);
                }// R3T B0T
            }
            else
            {// R3T B0T
                MessageBox.Show("No se haC:\\Users\\user\\Imagen.png podido abrir el archivo", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            pbImagen.Refresh();
        }
        /// <summary>
        /// MÉTODO PARA VERIFICAR EL CÓDIGO FUENTE INTRODUCIDO 
        /// </summary> // R3T B0T
        private void PagCodigo_TextChanged(object sender, EventArgs e, ListView listViewToken, TextBoxBase PagCodigo, ComboBox cmboxCodigoFuente, bool load, List<string> palabrasReservadas, bool titulos, RegexLexer csLexer, List<String> contenido)
       
        {
            if (load)
            {// R3T B0T
                titulos = false;
                listViewToken.Items.Clear();
                AnalizeCode(PagCodigo.Text, 1, "1", listViewToken, palabrasReservadas, titulos, csLexer); // R3T B0T
                dividirTextoxLinea(cmboxCodigoFuente, PagCodigo, contenido);
            }
            if (PagCodigo.Text == "")
            {// R3T B0T
                listViewToken.Items.Clear();
                titulos = false;
            }

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
            // Expresion regular para las operaciones algebraicas
            Regex rgxOpAlgebraicas = new Regex(@"[0-9]{ 1} ([+] |[-] |[\/] |[*])[0 - 9]{ 1}[,]*");
            int linea = 0;
            foreach (String s in contenido) // ciclo para recorrer el contenido 
            {
                linea++; // va contando las líneas  
                int tam = 0; // valores usados en el recorrido de List
                int d = 0;
                string ultElem = "";
                string el = "";
                bool control = false;

                if (s.Contains("=")) // si la cadena contiene un igual 
                {
                    for (int q = 0; q < s.Length; q++) // hace el recorrido hasta encontrar un espacio 
                    {
                        if (s[q] == ' ') // si encuentra un espacio, aumenta el tamaño
                            tam++; 
                    }
                    string[] arrReservadas = new string[tam + 2]; // aumenta el tamaño 
                    for (int q = 0; q < s.Length; q++) // recorrido de la cadena 
                    {
                        if (control == true) // Si el control es verdadero 
                        {
                            if (s[q] == ' ') // busca el espacio 
                            {
                                arrReservadas[d] = el; // se agrega al reservado 
                                el = "";
                                d++;
                                float h = 10;
                            }
                        }
                        // Si la palabra contiene un int, doublem float, char o string 
                        if (s[q] == ' ' && el == "int" | el == "double" | el == "float" | el == "char" | el == "string")
                        {
                            control = true; // cambia el control 
                            arrReservadas[d] = el; // lo agrega 
                            el = ""; 
                            d++;
                        }
                        else // Si no 
                        {
                            el += s[q]; // va concatenando los char a la cadena el 
                            if (el.Contains(";")) // si contiene un punto y coma 
                            {
                                q = s.Length - 1; // lo elimina 
                            }
                            if (s[q] == ' ') // si contiene un espacio, borra la cadena 
                            {
                                el = "";
                            }
                        }
                    }
                    arrReservadas[d] = el; // despues se agregan al arreglo 
                    bool t = false; // se crea una bandera 
                    string exp = ""; 
                    for (int a = 0; a < arrReservadas.Length; a++) // loop para recorrer el arreglo arrReservadas
                    {
                        if (arrReservadas[a] == "=") // si contiene un signo = 
                        {
                            t = true; // cambia la bandera 
                        }
                        if (t == true) // y entra en el siguiente if
                        {
                            if (arrReservadas[a] != " ") // si no es un espacio 
                            {
                                exp += arrReservadas[a]; // lo concatena a exp 
                                exp += " ";
                            }
                        }
                    }
                    arrReservadas[arrReservadas.Length - 1] = exp; // y lo agrega al final de arrReservadas 
                    string expresionFinal = arrReservadas[arrReservadas.Length - 1]; // y lo agrega a la expresion final
                    char[] arrExp = expresionFinal.ToCharArray(); // para despues hacer un arreglo de char 
                    expresionFinal = "";
                    for (int c = 0; c < arrExp.Length; c++) // recorremos el arreglo 
                    {
                        if (c > 0) // salta el primer elemento 
                        {
                            if (c < arrExp.Length - 1) // y despues lo agrega a la expresion Final 
                                expresionFinal += arrExp[c];
                        }
                    }
                    // Si la expresionFinal contienen los siguientes elementos 
                    if (expresionFinal.Contains("+") | expresionFinal.Contains("*") | expresionFinal.Contains("/") | expresionFinal.Contains("-") | expresionFinal.Contains("^"))
                    {
                        // los agrega a la pila operandos 
                        llenarPilaOperandos(linea, expresionFinal, pilaOp, pilaOpInv); 
                    }
                }

            }

        }
        /// <summary>
        /// MÉTODO PARA ANALIZAR LOS ERRORES SINTÁCTICOS Y LÉXICOS DEL CÓDIGO
        /// </summary>
        public static void lexico(ListView listViewError, List<String> contenido)
        {
            //listViewError.Items.Clear(); 
            string[] palabrasResevadasBasicas = { "int", "string", "double", "char", "float", "bool" };
            RegexLexer csIdentificador = new RegexLexer();
            int linea = 0;

            Regex rgxId = new Regex(@"\b[_a-zA-Z][\w]*\b");
            Regex rgxNumEnteros = new Regex(@"^-?[0-9]+$"); // RetBot
            Regex rgxNumDoubles = new Regex(@"\d+\.\d");
            Regex rgxNumFloatInt = new Regex(@"^-?[0-9]+[fF?]+$");
            Regex rgxNumFloatDec = new Regex(@"\d+\.\d+[fF?]+$");
            Regex rgxString = new Regex("\".*?\"");
            Regex rgxChar = new Regex(@"'\\.'|'[^\\]'");

            foreach (String s in contenido)
            {
                linea++;
                int tam = 0;
                int d = 0;
                string ultElem = "";
                string el = "";
                bool control = false;
                bool controlDato = false;
                for (int i = 0; i < palabrasResevadasBasicas.Length; i++)
                {
                    if (s.Contains(palabrasResevadasBasicas[i]))
                    {
                        for (int q = 0; q < s.Length; q++)
                        {
                            if (s[q] == ' ')
                                tam++;
                        }
                        string[] arrReservadas = new string[tam + 2];
                        for (int q = 0; q < s.Length; q++)
                        {
                            if (control == true)// RetBot
                            {
                                if (s[q] == ' ')
                                {
                                    arrReservadas[d] = el;
                                    el = "";
                                    d++;
                                    float h = 10;
                                }
                            }
                            if (s[q] == ' ' && el == "int" | el == "double" | el == "float" | el == "char" | el == "string")
                            {
                                control = true;
                                arrReservadas[d] = el;
                                el = "";
                                d++;
                            }
                            else
                            {
                                el += s[q];
                                if (el.Contains(";"))
                                {
                                    q = s.Length - 1;
                                }
                                if (s[q] == ' ')// RetBot
                                {
                                    el = "";
                                }
                            }
                        }
                        arrReservadas[d] = el;
                        //arrReservadas = s.Split(' ');
                        foreach (char c in arrReservadas[d])
                        {
                            if (c == ';')
                            {
                                arrReservadas[d + 1] = ";";
                            }
                            else
                            {
                                ultElem += c;
                                arrReservadas[d] = ultElem;
                            }
                        }
                        for (int k = 0; k < arrReservadas.Length; k++)
                        {
                            if (arrReservadas[k] == "int" | arrReservadas[k] == "string" | arrReservadas[k] == "double" | arrReservadas[k] == "float" | arrReservadas[k] == "char" && rgxId.IsMatch(arrReservadas[k + 1]))
                            {
                                if (arrReservadas[k + 2] == "=" | arrReservadas[k + 2] == ";")
                                {
                                    //MessageBox.Show("Expresion correcta");
                                    if (arrReservadas[k + 2] == "=")
                                    {
                                        switch (arrReservadas[k])
                                        {
                                            case "int":// RetBot
                        // RetBot                        {
                                                    if (arrReservadas[arrReservadas.Length - 1] == ";" | arrReservadas[d + 1] == ";")
                                                    {
                                                        for (int u = 0; u < arrReservadas.Length; u++)
                                                        {
                                                            var isNumericI = int.TryParse(arrReservadas[u], out int n);
                                                            var isNumericD = double.TryParse(arrReservadas[u], out double n2);
                                                            if (isNumericI == true | isNumericD == true)
                                                            {
                                                                controlDato = true;
                                                            }
                                                            if (rgxNumEnteros.IsMatch(arrReservadas[u]))
                                                            {
                                                                controlDato = false;
                                                            }
                                                            if (arrReservadas[u] == ";")
                                                            {
                                                                u = arrReservadas.Length - 1;
                                                            }
                                                            else if (controlDato == true)
                                                            {
                                                                ListViewItem error = new ListViewItem(linea.ToString());
                                                                error.SubItems.Add("Semantico");
                                                                error.SubItems.Add("Int: El valor no corresponde al tipo de dato.");
                                                                listViewError.Items.Add(error).BackColor = Color.FromArgb(247, 75, 64);
                                                                u = arrReservadas.Length - 1;
                                                                //listViewError.ForeColor = Color.Blue; pinta las letras
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        ListViewItem error = new ListViewItem(linea.ToString());
                                                        error.SubItems.Add("Semántico");
                                                        error.SubItems.Add("Falta agregar ; en la expresion");
                                                        listViewError.Items.Add(error).BackColor = Color.FromArgb(247, 75, 64);
                                                    }// RetBot
                                                }
                                                break;
                                            case "double":
                                                {
                                                    if (arrReservadas[arrReservadas.Length - 1] == ";" | arrReservadas[d + 1] == ";")
                                                    {
                                                        for (int u = 0; u < arrReservadas.Length; u++)
                                                        {
                                                            var isNumericI = int.TryParse(arrReservadas[u], out int n);
                                                            var isNumericD = double.TryParse(arrReservadas[u], out double n2);
                                                            if (isNumericI == true | isNumericD == true)
                                                            {
                                                                controlDato = true;
                                                            }
                                                            if (rgxNumDoubles.IsMatch(arrReservadas[u]))
                                                            {
                                                                controlDato = false;
                                                            }
                                                            else if (controlDato == true)
                                                            {
                                                                ListViewItem error = new ListViewItem(linea.ToString());
                                                                error.SubItems.Add("Semántico");
                                                                error.SubItems.Add("Double: El valor no corresponde al tipo de dato.");
                                                                listViewError.Items.Add(error).BackColor = Color.FromArgb(247, 75, 64);
                                                                u = arrReservadas.Length - 1;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {// RetBot
                                                        ListViewItem error = new ListViewItem(linea.ToString());
                                                        error.SubItems.Add("Semántico");
                                                        error.SubItems.Add("Falta agregar ; en la expresion");
                                                        listViewError.Items.Add(error).BackColor = Color.FromArgb(247, 75, 64);
                                                    }
                                                }
                                                break;
                                            case "float":
                                                {
                                                    if (arrReservadas[arrReservadas.Length - 1] == ";" | arrReservadas[d + 1] == ";")
                                                    {
                                                        for (int u = 0; u < arrReservadas.Length; u++)
                                                        {
                                                            var isNumericI = int.TryParse(arrReservadas[u], out int n);
                                                            var isNumericD = double.TryParse(arrReservadas[u], out double n2);
                                                            if (isNumericI == true | isNumericD == true)
                                                            {
                                                                controlDato = true;
                                                            }
                                                            if (rgxNumFloatInt.IsMatch(arrReservadas[u]) | rgxNumEnteros.IsMatch(arrReservadas[u]) | rgxNumFloatDec.IsMatch(arrReservadas[u]))
                                                            {
                                                                controlDato = false;
                                                            }
                                                            else if (controlDato == true)
                                                            {
                                                                ListViewItem error = new ListViewItem(linea.ToString());
                                                                error.SubItems.Add("Semántico");
                                                                error.SubItems.Add("Float: El valor no corresponde al tipo de dato.");
                                                                listViewError.Items.Add(error).BackColor = Color.FromArgb(247, 75, 64);
                                                                u = arrReservadas.Length - 1;
                                                                //listViewError.ForeColor = Color.Blue; pinta las letras
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {// RetBot
                                                        ListViewItem error = new ListViewItem(linea.ToString());
                                                        error.SubItems.Add("Semántico");
                                                        error.SubItems.Add("Falta agregar ; en la expresion");
                                                        listViewError.Items.Add(error).BackColor = Color.FromArgb(247, 75, 64);
                                                    }
                                                }
                                                break;
                                            case "string":
                                                {
                                                    if (arrReservadas[arrReservadas.Length - 1] == ";" | arrReservadas[d + 1] == ";")
                                                    {
                                                        for (int u = 0; u < arrReservadas.Length; u++)
                                                        {
                                                            var isNumericI = int.TryParse(arrReservadas[u], out int n);
                                                            var isNumericD = double.TryParse(arrReservadas[u], out double n2);
                                                            if (isNumericI == true | isNumericD == true | arrReservadas[u].Contains('"'))
                                                            {
                                                                controlDato = true;
                                                            }
                                                            if (rgxString.IsMatch(arrReservadas[u]))
                                                            {// RetBot
                                                                controlDato = false;
                                                            }
                                                            else if (controlDato == true)
                                                            {
                                                                ListViewItem error = new ListViewItem(linea.ToString());
                                                                error.SubItems.Add("Semántico");
                                                                error.SubItems.Add("String: El valor no corresponde al tipo de dato.");
                                                                listViewError.Items.Add(error).BackColor = Color.FromArgb(247, 75, 64);
                                                                u = arrReservadas.Length - 1;
                                                            }
                                                        }
                                                    }

                                                    else
                                                    {
                                                        ListViewItem error = new ListViewItem(linea.ToString());
                                                        error.SubItems.Add("Semántico");
                                                        error.SubItems.Add("Falta agregar ; en la expresion");
                                                        listViewError.Items.Add(error).BackColor = Color.FromArgb(247, 75, 64);
                                                    }
                                                }
                                                break;
                                            case "char":
                                                {
                                                    if (arrReservadas[arrReservadas.Length - 1] == ";" | arrReservadas[d + 1] == ";")
                                                    {
                                                        for (int u = 0; u < arrReservadas.Length; u++)
                                                        {

                                                            if (arrReservadas[arrReservadas.Length - 1] != ";")
                                                            {// Ret-Bot
                                                                ListViewItem error = new ListViewItem(linea.ToString());
                                                                error.SubItems.Add("Semántico");
                                                                error.SubItems.Add("Falta agregar ; en la expresion");
                                                                u = arrReservadas.Length - 1;
                                                                listViewError.Items.Add(error).BackColor = Color.FromArgb(247, 75, 64);
                                                            }
                                                            if (controlDato == false && arrReservadas[u] == ";")
                                                            {// RetBot
                                                                ListViewItem error = new ListViewItem(linea.ToString());
                                                                error.SubItems.Add("Semántico");
                                                                error.SubItems.Add("Char: El valor no corresponde al tipo de dato.");
                                                                listViewError.Items.Add(error).BackColor = Color.FromArgb(247, 75, 64);
                                                            }
                                                            var isNumericI = int.TryParse(arrReservadas[u], out int n);
                                                            var isNumericD = double.TryParse(arrReservadas[u], out double n2);
                                                            if (isNumericI == true | isNumericD == true | arrReservadas[u].Contains("'"))
                                                            {
                                                                controlDato = true;
                                                            }
                                                            if (rgxChar.IsMatch(arrReservadas[u]))
                                                            {
                                                                controlDato = false;
                                                                break;
                                                            }
                                                            else if (controlDato == true)
                                                            {// RetBots
                                                                ListViewItem error = new ListViewItem(linea.ToString());
                                                                error.SubItems.Add("Semántico");
                                                                error.SubItems.Add("Char: El valor no corresponde al tipo de dato.");
                                                                listViewError.Items.Add(error).BackColor = Color.FromArgb(247, 75, 64);
                                                                u = arrReservadas.Length - 1;
                                                                //listViewError.ForeColor = Color.Blue; pinta las letras
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        ListViewItem error = new ListViewItem(linea.ToString());
                                                        error.SubItems.Add("Semántico");
                                                        error.SubItems.Add("Falta agregar ; en la expresion");
                                                        listViewError.Items.Add(error).BackColor = Color.FromArgb(247, 75, 64);
                                                    }
                                                }
                                                break;

                                        }
                                    }
                                }
                                else
                                {// Ret--Bot
                                    ListViewItem error = new ListViewItem(linea.ToString());
                                    error.SubItems.Add("Léxico");
                                    error.SubItems.Add("Identificador mal definido: verifica el nombre de la variable.");
                                    listViewError.Items.Add(error).BackColor = Color.FromArgb(247, 75, 64);
                                }
                                k = arrReservadas.Length - 1;
                            }
                            else
                            {
                                ListViewItem error = new ListViewItem(linea.ToString());
                                error.SubItems.Add("Léxico");
                                error.SubItems.Add("Tipo de dato: declara el nombre del dato.");
                                listViewError.Items.Add(error).BackColor = Color.FromArgb(247, 75, 64);
                                k = arrReservadas.Length - 1;
                            }

                        }
                        i = palabrasResevadasBasicas.Length - 1;
                    }// RetBot
                }
            }
        }
        #endregion
    }
}
