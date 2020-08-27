using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Compiladores_MiniJava
{
    class Program
    {
        
        static void Main(string[] args)
        {
            string URL = @"C:\Users\Marcos Andrés CM\Desktop\6 Sexto ciclo\Compiladores\PROYECTO\ARCHIVOS DE PRUEBA\Ejemplo5.frag";//Direccion archivo de prueba
            //foreach (var arg in args)
            //{
                if (MetodosAux_AL.VerificarArchivoVacio(URL) != true)
                {
                    MetodosAux_AL.Analisis_Lex(URL);
                    //MetodosAux_AL.ImprimirResultado();
                }
                else
                {
                    Console.WriteLine("ARCHIVO DE ENTRADA VACIO");
                }
                
                Console.ReadKey();
            //}
        }
    }
}
