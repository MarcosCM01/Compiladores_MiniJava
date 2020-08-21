using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Compiladores_MiniJava
{
    public static class MetodosAux_AL
    {
        public static List<String> Reservadas = new List<string> 
        {"void","int","double","boolean","string", "class", "const", "interface", "null", "this", "extends", "implements", "for", "while", "if", "else", "returns", "break", "New", "System", "out", "println" };

        public static List<String> Operadores_Simples = new List<string>
        {"+","-","*","/","%","<",">","=","!",";",",",".","[","]","(",")","{","}"};

        public static List<String> Operadores_Dobles = new List<string>
        { "<=", ">=","==","!=","&&","||","[]","()","{}"};
        public static Dictionary<string, string> DiccionarioER_Valor = new Dictionary<string, string>() {{ @"^\b(true|false)\b$", "T_es_ConstBool"}, {@"^\b[0-9]+\b$", "T_es_ConstDecimal"}, 
        { @"^\b0(x|X)[a-fA-F0-9]+\b$", "T_es_ConstHexadecimal"}, {@"^[0-9]+\.([0-9]*|[0-9]*E(\+|-)?[0-9]+)?$","T_es_ConstDouble"}, { @"^[a-zA-Z$]+[a-zA-Z0-9$]*$", "T_es_Id"} };

        public const int bufferLenght = 10;

        public static List<string> ArchivoDeSalida = new List<string>();

        public static List<string> tmp_PRUEBA = new List<string>();

        public static bool VerificarArchivoVacio(string URL)
        {
            using (var File = new FileStream(URL, FileMode.Open))
            {
                using (var reader = new BinaryReader(File))
                {
                    if (reader.BaseStream.Length !=0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static void Analisis_Lexico(string URL) 
        {
            var line = string.Empty;
            var num_linea = 1;
            var num_columna = 1;
            bool Bandera_String = false;
            var tmp_string = string.Empty;
            using (StreamReader reader = new StreamReader(URL))
            {
                while ((line = reader.ReadLine()+'\n') != null)
                {
                    for (int posicion = 0; posicion < line.Length; posicion++)
                    {
                        var item = line[posicion];
                        if (Bandera_String == true)
                        {
                            if (item == '"')
                            {
                                tmp_string += item;
                                if (tmp_string.Length > 2)
                                {
                                    //Analizar el string en una expresion regular
                                }
                                else
                                {
                                    //String vacio
                                }

                            }
                            else if (item == 10 || item == 13)
                            {
                                //Si es un salto de linea entonces mostrar error 
                                Bandera_String = false;
                            }
                            else
                            {
                                //Concateno items hasta encontrar salto de linea o corchete
                                tmp_string += item;
                            }
                        }
                        else if (item == '"')
                        {
                            Bandera_String = true;
                            tmp_string += item;
                            //Activo la bandera del string 
                        }
                        else if (item != 9 && item != 10 && item != 13 && item != 32)//tab, /n, CR, espacio
                        {
                            tmp_string += item; //verificar que su longitud no sea mayor de 31
                        }
                        else //se analiza el tmp_string
                        {
                            if (tmp_string.Length > 0)
                            {
                                if (MetodosAux_AL.EsReservada(tmp_string) != false)
                                {//ES RESERVADA
                                    //tmp_PRUEBA.Add($"{tmp_string},T_es_Reservada");
                                    var token = CrearToken(tmp_string, num_linea, num_columna, "T_es_Reservada");
                                    ImprimirToken(token);
                                }
                                //APLICAR EXPRESIONES REGULARES PARA DETERMINAR LO QUE ES
                                else
                                {//VERIFICAMOS QUE SEA CONSTANTE    

                                    var valor = string.Empty;
                                    if (MetodosAux_AL.EsConstante(tmp_string, ref valor) != false)//NO COINCIDIO CON ALGUN TIPO DE CONSTANTE
                                    {
                                        var token = CrearToken(tmp_string,num_linea, num_columna, valor);
                                        ImprimirToken(token);
                                    }
                                    else if (Operadores_Dobles.Contains(tmp_string))
                                    {
                                        var token = CrearToken(tmp_string,  num_linea, num_columna, "T_es_Operador_Doble");
                                        ImprimirToken(token);
                                    }
                                    else if (Operadores_Simples.Contains(tmp_string))
                                    {
                                        var token = CrearToken(tmp_string, num_linea, num_columna, "T_es_Operador_Simple");
                                        ImprimirToken(token);
                                    }
                                    else
                                    {
                                        //Analizar porque no entra a ninguno de los anteriores 
                                        //Ver string comentario
                                    }
                                }
                                tmp_string = string.Empty;
                            }
                            else if (tmp_string.Length > 0 && posicion + 1 == line.Length)//CUANDO SE LEA LO ULTIMO DEL ARCHIVO
                            {

                            }
                        }
                        num_columna++;
                    }
                    num_columna = 1;
                    num_linea++;
                }
                reader.Close();
            }
           
        }
        public static bool EsReservada(string palabra) 
        {
            if (Reservadas.Contains(palabra))
            {
                return true;
            }
            return false;
        }
        public static bool EsOperador_Doble(string palabra)
        {
            if (Operadores_Dobles.Contains(palabra))
            {
                return true;
            }
            return false;
        }
        public static bool EsConstante(string palabra, ref string valor) 
        {
            var resultado = false;
            foreach (var item in DiccionarioER_Valor.Keys)
            {
                Regex rx = new Regex(item);
                if (rx.IsMatch(palabra))
                {//ES UNA CONSTANTE
                    //tmp_PRUEBA.Add($"{palabra},{DiccionarioER_Valor[item]}");
                    valor = $"{DiccionarioER_Valor[item]} (value = {palabra})";
                    resultado = true;
                    break;
                }
            }
            return resultado;
        }
        public static void AgregarError(string numero_linea, string def_Error) 
        {
            ArchivoDeSalida.Add($"*** ERROR {numero_linea}. ***     {def_Error}");
        }
        public static void ImprimirToken(Token token) 
        {
            Console.WriteLine($"{token.palabra}  :  line:{token.linea}, inicio:{token.columna_i}, fin:{token.columna_f}; {token.valor}");
        }

        public static Token CrearToken(string palabra, int num_Linea, int num_columna, string valor) 
        {
  
            Token t = new Token();
            t.palabra = palabra;
            t.valor = valor;
            t.linea = num_Linea;
            t.columna_i = num_columna - palabra.Length;
            t.columna_f = num_columna;
            return t;


        }
    }
}
