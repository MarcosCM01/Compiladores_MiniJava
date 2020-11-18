using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores_MiniJava
{
    class TablaSimbolos
    {
        List<Entorno> Entornos = new List<Entorno>();
        //if { i++
        //if } i--
        public void CreacionToken(string linea)
        {
            var palabras = linea.Split(' ');

            if(palabras.Contains("double"))
            {

            }
            else if(palabras.Contains("string"))
            {

            }
            else if (palabras.Contains("int"))
            {

            }
            else if (palabras.Contains("boolean"))
            {

            }
            else if (palabras.Contains("void"))
            {
                //Ambito
            }
            else if (palabras.Contains("class"))
            {
                //Ambito
            }
            else if (palabras.Contains("="))
            {

            }
        }

    }
}
