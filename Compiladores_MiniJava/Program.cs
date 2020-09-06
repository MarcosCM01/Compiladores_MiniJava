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
            string URL = @"C:\Users\jalba\OneDrive\Escritorio\PRUEBA.txt";//Direccion archivo de prueba
            foreach (var arg in args)
            {
                if (MetodosAux_AL.VerificarArchivoVacio(arg) != true)
                {
                    MetodosAux_AL.Analisis_Lex(arg);
                    //MetodosAux_AL.ImprimirResultado();
                }
                else
                {
                    Console.WriteLine("ARCHIVO DE ENTRADA VACIO");
                }
                
                Console.ReadKey();
            }
        }
    }
}
