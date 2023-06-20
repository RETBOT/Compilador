using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbol
{
    /// <summary>
    /// Clase usada para definir los nodos
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
    public class Nodo
    {
        //************************************************************************************************************
        // Variables Locales
        //************************************************************************************************************
        #region VARIABLES LOCALES
        private Object datos; //Son los datos que se van a ir generando respecto al nodo
        private Nodo nodoIzquierdo;
        private Nodo nodoDerecho;
        #endregion // >>RET-BOT<<

        //************************************************************************************************************
        // Constructores
        //************************************************************************************************************
        #region CONSTRUCTORES

        //Constructor sin parametros
        public Nodo()// >>RET-BOT<<
        {
            nodoDerecho = nodoIzquierdo = null;
        }
        //Constructor con el parametro datos
        public Nodo(Object datos)
        {
            this.datos = datos;
            nodoDerecho = nodoIzquierdo = null;
        }
        //Constructor con parametros
        public Nodo(Nodo derecho, Nodo izquierdo, Object valor)
        {
            this.nodoDerecho = derecho;
            this.nodoIzquierdo = izquierdo;
            this.datos = valor;
        }// >>RET-BOT<<

        #endregion

        //************************************************************************************************************
        // Métodos
        //************************************************************************************************************
        #region MÉTODOS
        //NODO IZQUIERDO
        /// <summary>
        /// Método para utilizar las propiedades del nodo izquierdo.
        /// Contiene funciones para obtener o asignar el valor al nodo.
        /// </summary>
        public Nodo NodoIzquierdo { get => nodoIzquierdo; set => nodoIzquierdo = value; }

        //NODO DERECHO
        /// <summary>// >>RET-BOT<<
        /// Método para utilizar las propiedades del nodo derecho.
        /// Contiene funciones para obtener o asignar el valor al nodo.
        /// </summary>
        public Nodo NodoDerecho { get => nodoDerecho; set => nodoDerecho = value; }

        //DATOS
        /// <summary>
        /// Método para utilizar las propiedades del objeto datos.
        /// Contiene funciones para obtener o asignar el valor al dato.
        /// </summary>
        public Object Datos { get => datos; set => datos = value; }
        #endregion
// >>RET-BOT<<

    }
}
