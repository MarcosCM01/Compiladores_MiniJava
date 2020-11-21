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
           //string URL = @"C:\Users\Marcos Andrés CM\Desktop\6 Sexto ciclo\Compiladores\PROYECTO\ARCHIVOS DE PRUEBA\prueba3.txt";//Direccion archivo de prueba
            
           foreach (var arg in args)
            {
                if (MetodosAux_AL.VerificarArchivoVacio(arg) != true)
                {
                        //INICIO FASE 1: LEXICO
                    MetodosAux_AL.Analisis_Lex(arg);
                    //GenerarTablaSimbolo();
                    TablaSimbolos.CreacionTabla();
                    //ImprimirTabla();
                    TablaSimbolos.Imprimir();
                    //INICIO FASE 2: SINTACTICO
                    SLR.PARSER_PILA();


                    Console.WriteLine("Fin de analisis sintactico");
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
