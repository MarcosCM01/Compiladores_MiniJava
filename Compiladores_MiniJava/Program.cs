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
            string URL = @"C:\Users\jalba\OneDrive\Escritorio\Prueba.txt";//Direccion archivo de prueba
            
            //foreach (var arg in args)
            //{
                if (MetodosAux_AL.VerificarArchivoVacio(URL) != true)
                {
                        //INICIO FASE 1: LEXICO
                    MetodosAux_AL.Analisis_Lex(URL);

                    //LAB A
                    //Lab_ASDR.Sintactico_Recursivo();

                            //INICIO FASE 2: SINTACTICO
                    SLR.PARSER_PILA();
                    //2. PARSEO EN LA PILA


                    Console.WriteLine("Fin de analisis sintactico");
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
