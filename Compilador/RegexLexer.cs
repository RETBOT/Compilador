using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Arbol
{
    /// <summary>
    /// Clase para analizar las expresiones regulares
    /// Contiene métodos que nos permite saber el tipo de token que tiene una expresión.
    /// </summary>
    /// <remarks>
    /// <para>Con esta clase se puede agrega una nueva regla para reconocer token, reinicia el Lexer,  
    /// Analiza una entrada en busca de tokens validos y errores, crea el AFN con los patrones establecidos y
    /// cuenta la cantidad de lineas presentes en un token, establece el inicio de linea.</para>
    /// </remarks>
    /// <supuestos>Para que esta clase funcione es necesario tener un objeto de la clase Regex para analizar las expresiones regulares.
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
    class RegexLexer
    {
        //************************************************************************************************************
        // Variables Locales
        //************************************************************************************************************
        #region VARIABLES LOCALES 
        #endregion

        //************************************************************************************************************
        // Constructores
        //************************************************************************************************************
        #region CONSTRUCTORES
        //Constructor sin parametros:
        public RegexLexer()
        {
        }
        #endregion

        //************************************************************************************************************
        // Métodos
        //************************************************************************************************************
        #region METODOS

        /// <summary>
        /// Agrega una nueva regla para reconocer token
        /// </summary>
        /// <param name="pattern">patrón en el que debe encajar</param>
        /// <param name="token_name">id único para este patrón</param>
        /// <param name="ignore">true para no devolver este token</param>
        public void AddTokenRule(string pattern, string token_name, bool ignore = false)
        {
            
        }

        /// <summary>
        /// Reinicia el Lexer
        /// </summary>
        public void Reset()
        {
        }

        /// <summary>
        /// Analiza una entrada en busca de tokens validos y errores
        /// </summary>
        /// <param name="text">entrada a analizar</param>
        public IEnumerable<Token> GetTokens(string text)
        {
            yield return new Token("ERROR");
        }

        /// <summary>
        /// Crea el AFN con los patrones establecidos 
        /// </summary>
        /// <param name="options">opciones del compilador</param>
        public void Compile(RegexOptions options)
        {
        }

       
        /// <summary>
        /// Cuenta la cantidad de lineas presentes en un token, establece el inicio de linea.
        /// </summary>
        /// <param name="token">entrada del token</param>
        /// <param name="index">entrada del índice</param>
        /// <param name="line_start">entrada del inicio de la linea</param>
        /// <returns>Retorna la línea del token.</returns>
        private int CountNewLines(string token, int index, ref int line_start)
        {
            return 0;
        }

        #endregion
    }
}
