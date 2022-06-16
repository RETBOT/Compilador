using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbol
{
    /// <summary>
    /// Clase para obtener las propiedades del token.
    /// Contiene métodos que nos permite obtener y asignar las propiedades del token.
    /// </summary>
    /// <remarks>
    /// <para>Con esta clase se puede hacer uso de los métodos para obtener y asignar el nombre, lexema, indice, linea, columna, tipo de dato, ID tabla, tabla padre de un token.</para>
    /// </remarks>
    /// <supuestos>Para que esta clase funcione es necesario declarar un objeto de esta clase Token para hacer uso de los métodos.
    /// </supuestos>
    /// <Autor>
    /// Roberto Esquivel Troncoso 19130519 
    /// Ivan Herrera Garcia 19130535
    /// Fatima Gorety Garcia Yescas 19130527
    /// Isaias Gerardo Cordova Palomares 19130514	
    /// Raul Galindo Sanches - 18130553
    /// </Autor>
    /// <Fecha> 11/03/2022</Fecha>
    //************************************************************************************************************
    // Para mas informacion contactar a robertoesquiveltr16@gmail.com
    //************************************************************************************************************
    class Token
    {
        //************************************************************************************************************
        // Constructores
        //************************************************************************************************************
        #region CONSTRUCTORES

        //CONSTRUCTOR CON EL PARAMETRO DE Name, Lexema, Index, Linea y Columna.
        public Token(string name)
        {
        }
        #endregion

        //************************************************************************************************************
        // Métodos
        //************************************************************************************************************
        #region METODOS
        
        //Metodos para obtener y asignar
        public string Name { get; set; }
        public string Lexema { get; private set; }

        public int Index { get; private set; }
        public int Linea { get; private set; }
        public int Columna { get; private set; }
        public string TipoDato { get; private set; }
        public int IDTabla { get; private set; }
        public int TablaPadre { get; private set; }

        public int Lenght { get { return Lexema.Length; } }

        #endregion
    }
}

