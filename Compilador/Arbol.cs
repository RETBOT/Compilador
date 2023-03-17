using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Arbol
{
    /// <summary>
    /// Clase para crear el arbol
    /// </summary>
    /// <Autores>
    /// Roberto Esquivel Troncoso 19130519 
    /// Ivan Herrera Garcia 19130535
    /// Fatima Gorety Garcia Yescas 19130527
    /// Isaias Gerardo Cordova Palomares 19130514	
    /// Isaias Gerardo Cordova Palomares 19130514
    /// Raul Galindo Sanches - 18130553
    /// </Autores>
    /// <Fecha> 22/02/2022</Fecha>
    /// 
    //************************************************************************************************************
    // Para mas informacion contactar a robertoesquiveltr16@gmail.com
    //************************************************************************************************************
    public class Arbol
    {
        // VARIABLES LOCALES 
         // VARIABLES LOCALES 
        bool band = false;
        int a = 0;
        string cad = "";
        // INSERSION EN COLA// R3TB0T
        private string[] operandosArray; //Arreglo para los operandos (variables)
        private string[] operadoresArray;
        //CREACIÓN DE ÁRBOL
        private int i = 0; //Define el control de un ciclo
        private Stack pilaDot;  //Variable de tipo Pila para almacenar los nodos del arbol
       

        // PROPIEDADES PARA RECORRIDOS

        #region CONSTRUCTORES
        public Arbol()
        {
            pilaOperadores = new Stack();// R3TB0T
            pilaOperandos = new Stack();
            pilaDot = new Stack();
            colaExpresion = new Queue();
        }
        #endregion

        #region INSERCION EN COLA
        public void InsertarEnCola (string expresion)
        {
            string[] palabra = expresion.Split(' ');

            for (int i = 0; i < palabra.Length; i++)// R3TB0T
            {
                colaExpresion.Enqueue(palabra[i].ToString());
            }
        }
        #endregion

        #region OTRA INSERCION EN COLA
        public Nodo crearArbol()
        
        {
            while (colaExpresion.Count != 0)
            {
                token = (string)colaExpresion.Dequeue();
                if (blanco.IndexOf(token) >= 0)
                    ;               // Es un espacio en blanco, se ignora
                else if (precedencia.IndexOf(token) < 0)
                {
                    for (int i = 0; i <= 26; i++)
                    {   //ciclo para recorrer los identificadores
                        if (b != 26)// R3TB0T
                        {
                            if (token.Contains(id[b]) | token.Contains(id2[b]))
                            {
                                band = true;

                            }
                            b++;
                        }
                    }
                    for (int j = 0; j <= 20; j++) //ciclo para recorrer los numeros
                    {
                        if (a != 10)
                        {
                            if (token.Contains(num[a]))
                            {
                                band2 = true;
                            }
                            a++;// R3TB0T
                        }
                    }
                    for (int k = 0; k <= 20; k++) //ciclo para recorrer las cadenas
                    {
                        if (c != 10)
                        {
                            if (token.Contains(cade[c].ToString()))
                            {
                                band3 = true;
                            }
                            a++;
                        }
                    }


                    //Condiciones para establecer si es un Id, Numero o Cadena:
                    if (band == true)
                    {// R3TB0T
                        cad = token;
                        token = "Id";

                    }

                    if (band2 == true)
                    {
                        cad = token;
                        token = "Numero";

                    }
                    if (band3 == true)
                    {
                        token = "Cadena";

                    }

                    a = 0;// R3TB0T
                    b = 0;
                    band = false;
                    band2 = false;
                    band3 = false;
                    // Es operando y lo guarda como nodo del arbol
                    pilaOperandos.Push(new Nodo(token));
                    pilaDot.Push(new Nodo($"nodo{++i}[label = \"{token}\"]")); //Inserta el numero del nodo y el token a la pila
                }
                else if (token.Equals(")"))
                { // Saca elementos hasta encontrar (
                    while (pilaOperadores.Count != 0 && pilaOperadores.Peek().Equals("("))
                    {
                        GuardaSubArbol();
                    }
                    GuardaSubArbol();// R3TB0T
                    pilaOperadores.Pop();  // Saca el parentesis izquierdo
                }
                else
                {
                    if (!token.Equals("(") && pilaOperadores.Count != 0)
                    {
                        //operador diferente de cualquier parentesis
                        operadorTemp = (string)pilaOperadores.Peek();
                        while (!operadorTemp.Equals("(") && pilaOperadores.Count != 0 && precedencia.IndexOf(operadorTemp) >= precedencia.IndexOf(token))
                        {
                            GuardaSubArbol();
                            if (pilaOperadores.Count != 0)
                                operadorTemp = (string)pilaOperadores.Peek();
                        }
                    }
                    pilaOperadores.Push(token);  //Guarda el operador
                }
            }
            //Sacar todo lo que queda
            raiz = (Nodo)pilaOperandos.Peek();
            NodoDot = (Nodo)pilaDot.Peek();
            while (pilaOperadores.Count != 0)
            {// R3TB0T
                if (pilaOperadores.Peek().Equals("("))
                {
                    pilaOperadores.Pop();
                }
                else
                {
                    GuardaSubArbol();
                    raiz = (Nodo)pilaOperandos.Peek();
                    NodoDot = (Nodo)pilaDot.Peek();
                }
            }
            return raiz;
        }
        public void insertarEnCola(string expresion)
        {
            string[] palabra = expresion.Split(' ');
            for (int i = 0; i < palabra.Length; i++)// R3TB0T
            {
                colaExpresion.Enqueue(palabra[i].ToString());
            }
        }

        #endregion

        #region ARBOL 
        public Nodo CrearArbol() {
            Nodo raiz = null;
            return raiz;// R3TB0T
        }

        private void Insertar(Nodo ar, string cad)
        {
        }// R3TB0T

        private void GuardarSubArbol() {
        }// R3TB0T

        private void GuardaSubArbol()
        {// R3TB0T
        }
        #endregion

        #region RECORRIDOS
        //PREORDEN
        if (tree != null) {
                cadenaPreorden += tree.Datos + " ";
                InsertaPre(tree.NodoIzquierdo);
                InsertaPre(tree.NodoDerecho);
            }

            return cadenaPreorden;

        //INORDEN   
        public string InsertaIn(Nodo tree)
        {
            if (tree != null) {
                InsertaIn(tree.NodoIzquierdo);// R3TB0T
                cadenaInorden += tree.Datos + " ";
                InsertaIn(tree.NodoDerecho);
            }
            return cadenaInorden;
        }

        //POSTORDEN   
        public string InsertaPost(Nodo tree)
        {
             if (tree != null)
            {// R3TB0T
                InsertaPost(tree.NodoIzquierdo);
                InsertaPost(tree.NodoDerecho);
                cadenaPostorden += tree.Datos + " ";
            }
            return cadenaPostorden;
        }
        #endregion

        #region LIMPIAR 
         public void Limpiar() {
            cadenaPreorden = "";
            cadenaInorden = "";// R3TB0T
            cadenaPostorden = "";
        }
        #endregion

        #region Crear Arbol para Codigo de 3 direcciones
        public Nodo CrearArbol2()// R3TB0T
        {

            while (colaExpresion.Count != 0)
            {
                token = (string)colaExpresion.Dequeue();
                if (blanco.IndexOf(token) >= 0)
                    ;               // Es un espacio en blanco, se ignora
                else if (precedencia.IndexOf(token) < 0)
                {
                    for (int i = 0; i <= 26; i++)
                    {   //ciclo para recorrer los identificadores
                        if (b != 26)
                        {// R3TB0T
                            if (token.Contains(id[b]) | token.Contains(id2[b]))
                            {
                                band = true;
                            }
                            b++;
                        }
                    }
                    for (int j = 0; j <= 20; j++) //ciclo para recorrer los numeros
                    {
                        if (a != 10)
                        {
                            if (token.Contains(num[a]))
                            {
                                band2 = true;
                            }
                            a++;
                        }// R3TB0T
                    }
                    for (int k = 0; k <= 20; k++) //ciclo para recorrer las cadenas
                    {
                        if (c != 10)
                        {
                            if (token.Contains(cade[c].ToString()))
                            {
                                band3 = true;
                            }
                            a++;
                        }
                    }


                    //Condiciones para establecer si es un Id, Numero o Cadena:
                    if (band == true)
                    {
                        cad = token;
                        token = cad;// R3TB0T
                    }

                    if (band2 == true)
                    {
                        cad = token;
                        token = cad;

                    }
                    if (band3 == true)
                    {
                        cad = token;
                        token = cad;

                    }

                    a = 0;// R3TB0T
                    b = 0;
                    band = false;
                    band2 = false;
                    band3 = false;
                    // Es operando y lo guarda como nodo del arbol
                    pilaOperandos.Push(new Nodo(token));
                    pilaDot.Push(new Nodo($"nodo{++i}[label = \"{token}\"]")); //Inserta el numero del nodo y el token a la pila
                }
                else if (token.Equals(")"))
                { // Saca elementos hasta encontrar (
                    while (pilaOperadores.Count != 0 && pilaOperadores.Peek().Equals("("))
                    {
                        GuardarSubArbol();
                    }
                    GuardarSubArbol();
                    pilaOperadores.Pop();  // Saca el parentesis izquierdo
                }// R3TB0T
                else
                {
                    if (!token.Equals("(") && pilaOperadores.Count != 0)
                    {
                        //operador diferente de cualquier parentesis
                        operadorTemp = (string)pilaOperadores.Peek();
                        while (!operadorTemp.Equals("(") && pilaOperadores.Count != 0 && precedencia.IndexOf(operadorTemp) >= precedencia.IndexOf(token))
                        {
                            GuardarSubArbol();
                            if (pilaOperadores.Count != 0)
                                operadorTemp = (string)pilaOperadores.Peek();
                        }
                    }
                    pilaOperadores.Push(token);  //Guarda el operador
                }
            }// R3TB0T
            //Sacar todo lo que queda
            raiz = (Nodo)pilaOperandos.Peek();
            nodoDot = (Nodo)pilaDot.Peek();
            while (pilaOperadores.Count != 0)
            {
                if (pilaOperadores.Peek().Equals("("))
                {
                    pilaOperadores.Pop();
                }
                else
                {
                    GuardarSubArbol();
                    raiz = (Nodo)pilaOperandos.Peek();
                    nodoDot = (Nodo)pilaDot.Peek();
                }
            }
            return raiz;
        }// R3TB0T
        #endregion
    }
}
