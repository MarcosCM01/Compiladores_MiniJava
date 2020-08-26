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
        public static Dictionary<string, string> DiccionarioER_Valor = new Dictionary<string, string>() {{ @"^\b(true|false)\b$", "T_es_ConstBool"}, 
        {@"^0(x|X)[a-fA-F0-9]*$", "T_es_ConstHexadecimal"}, {@"^[0-9]+\.(([0-9])*|([0-9]*(E|e)(\+|-)?[0-9]*))?$","T_es_ConstDouble"}, {@"^\b[0-9]+\b$", "T_es_ConstDecimal"}, { @"^[a-zA-Z$]+[a-zA-Z0-9$]*$", "T_es_Id"} };

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
        public static void Analisis_Lex(string URL)
        {
            var bandera_ID_Capacidad = false;
            var Linea_a_Regresar = 0;
            var direccion = URL.Split('.');//ARG
            string Escritura = direccion[0] + ".out";
            var line = string.Empty;
            var inicio_multilinea = 0;
            var num_linea = 1;
            var num_columna = 1;
            var Bandera_String = false;
            var bandera_comentario_simple = false;
            var bandera_comentario_doble = false;
            var tmp_string = string.Empty;
            using (StreamWriter writer = new StreamWriter(Escritura))
            {
                using (StreamReader reader = new StreamReader(URL))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        num_columna = 1;
                        for (int posicion = 0; posicion < line.Length; posicion++)
                        {
                            if (bandera_comentario_doble == true)
                            {
                                if (tmp_string.Length < 10)
                                {
                                    if (line[posicion] > 0)
                                    {
                                        tmp_string += line[posicion];
                                    }
                                    else
                                    {
                                        Console.WriteLine("CHAR INVALIDO ");
                                        writer.WriteLine("CHAR INVALIDO");
                                    }
                                }
                                if (line[posicion] == '*')
                                {
                                    if (posicion + 1 < line.Length)
                                    {
                                        if (line[posicion + 1] == '/')
                                        {
                                            //Console.WriteLine($"COMENTARIO MULTILINEA - inicio:{inicio_multilinea}, fin:{num_linea}");
                                            //writer.WriteLine($"COMENTARIO MULTILINEA - inicio:{inicio_multilinea}, fin:{num_linea}");
                                            tmp_string = string.Empty;
                                            posicion++;
                                            bandera_comentario_doble = false;
                                            Linea_a_Regresar = num_linea;
                                        }
                                    }

                                }
                            }
                            else if (line[posicion] == '"')
                            {
                                if (Bandera_String == true)
                                {
                                    if (tmp_string.Length > 1)
                                    {
                                        if (line[posicion] >= 0)
                                        {
                                            tmp_string += line[posicion];
                                            Bandera_String = false;
                                            var token = CrearToken(tmp_string, num_linea, num_columna + 1, "T_es_String");
                                            tmp_string = "";

                                            Console.WriteLine(ImprimirToken(token));
                                            writer.WriteLine(ImprimirToken(token));
                                        }
                                        else
                                        {
                                            Console.WriteLine("CHAR INVALIDO ");
                                            writer.WriteLine("CHAR INVALIDO ");

                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("STRING VACIO ");
                                        writer.WriteLine("STRING VACIO ");
                                        tmp_string = "";
                                    }
                                }
                                else
                                {
                                    tmp_string += line[posicion];
                                    Bandera_String = true;
                                }
                            }
                            else if (Bandera_String == true)
                            {
                                tmp_string += line[posicion];
                            }
                            else if (bandera_comentario_simple == true)
                            {
                                if (line[posicion] > 0)
                                {
                                    if(tmp_string.Length<10)
                                    tmp_string += line[posicion];
                                }
                                else
                                {
                                    Console.WriteLine("ERROR CHAR INVALIDO : " + line[posicion]);
                                    writer.WriteLine("ERROR CHAR INVALIDO : " + line[posicion]);
                                }
                            }
                            else if (line[posicion] == '/')// PARA COMENTARIOS
                            {

                                if (posicion + 1 < line.Length)
                                {
                                    //COMENTARIO SIMPLE
                                    if (line[posicion + 1] == '/')
                                    {
                                        tmp_string += line[posicion];
                                        bandera_comentario_simple = true;
                                        tmp_string += line[posicion + 1];
                                        posicion++;
                                    }
                                    //COMENTARIO DOBLE
                                    else if (line[posicion + 1] == '*')
                                    {
                                        tmp_string += line[posicion];
                                        bandera_comentario_doble = true;
                                        tmp_string += line[posicion + 1];
                                        posicion++;
                                        inicio_multilinea = num_linea;
                                    }
                                    else
                                    {// Esto funciona solo cuando viene una barra

                                        var token = CrearToken(tmp_string, num_linea, num_columna, Trae_Match(tmp_string));
                                        tmp_string = string.Empty;
                                        Console.WriteLine(ImprimirToken(token));
                                        writer.WriteLine(ImprimirToken(token));
                                        tmp_string += line[posicion];
                                        //   
                                    }
                                }

                            }
                            else if (Posee_Match(tmp_string + line[posicion]) == true)
                            {
                                if(tmp_string.Length<32)
                                    tmp_string += line[posicion];
                                else if(bandera_ID_Capacidad == false)
                                {
                                    bandera_ID_Capacidad = true;
                                    Console.WriteLine("Error ID CON CAPACIDAD MAXIMA");
                                    writer.WriteLine("Error ID CON CAPACIDAD MAXIMA");

                                }

                            }
                            else
                            {
                                if (tmp_string.Length > 0)
                                {
                                    var token = CrearToken(tmp_string, num_linea, num_columna, Trae_Match(tmp_string));
                                    bandera_ID_Capacidad = false;
                                    Console.WriteLine(ImprimirToken(token));
                                    writer.WriteLine(ImprimirToken(token));
                                    tmp_string = "";
                                    var x = line[posicion];
                                    if (Posee_Match(tmp_string + line[posicion]) == true)
                                    {
                                        tmp_string += line[posicion];
                                    }
                                    //else if (line[posicion] == 32 || line[posicion] == 10 || line[posicion] == 9 || line[posicion] == 13)
                                    //{
                                    //    // Me sirve para limpiar chars invalidos
                                    //    //Lo importante es que funciona :)
                                    //}
                                    else if (line[posicion] < 0)
                                    {
                                        Console.WriteLine("ERROR EOF ANTES DEL FINAL DE ARCHIVO");
                                        writer.WriteLine("ERROR EOF ANTES DEL FINAL DE ARCHIVO");
                                    }
                                    else if (line[posicion] != 32 && line[posicion] != 10 && line[posicion] != 9 && line[posicion] != 13)
                                    {
                                        Console.WriteLine("ERROR CHAR INVALIDO : " + line[posicion]);
                                        writer.WriteLine("ERROR CHAR INVALIDO : " + line[posicion]);
                                    }
                            }
                                else
                                {
                                    if (line[posicion] != 32 && line[posicion] != 10 && line[posicion] != 9 && line[posicion] != 13)
                                    {
                                        Console.WriteLine("ERROR CHAR INVALIDO : " + line[posicion]);
                                        writer.WriteLine("ERROR CHAR INVALIDO : " + line[posicion]);
                                    }
                                }
                            }
                            num_columna++;
                        }
                        if (tmp_string.Length > 0 && bandera_comentario_doble == false)
                        {
                            if (Bandera_String == true)
                            {
                                Bandera_String = false;
                                tmp_string = "";
                                Console.WriteLine($"ERROR STRING SIN TERMINAR  :  line:  {num_linea}");
                                writer.WriteLine($"ERROR STRING SIN TERMINAR  :  line:  {num_linea}");

                                //No venia la otra comilla
                            }
                            else if (bandera_comentario_simple == true)
                            {
                                bandera_comentario_simple = false;
                                //Console.WriteLine($"COMENTARIO DE LINEA - {num_linea}");
                                //writer.WriteLine($"COMENTARIO DE LINEA - {num_linea}");
                                tmp_string = string.Empty;
                            }
                            else
                            {
                                var token = CrearToken(tmp_string, num_linea, num_columna, Trae_Match(tmp_string));
                                bandera_ID_Capacidad = false;
                                Console.WriteLine(ImprimirToken(token));
                                writer.WriteLine(ImprimirToken(token));
                                tmp_string = "";
                            }
                        }
                        num_linea++;
                    }
                    if (bandera_comentario_doble == true)
                    {
                        Console.WriteLine($"ERROR COMENTARIO SIN CERRAR");
                        writer.WriteLine($"ERROR COMENTARIO SIN CERRAR");
                    }
                    reader.Close();
                }
                writer.Close();
            }
         
        }
        public static bool Posee_Match(string lexema)
        {
            
           string tmp = "";
            if (MetodosAux_AL.EsReservada(lexema) != false)
            {
                return true;
            }
            else if (MetodosAux_AL.EsConstante(lexema, ref tmp) != false)
            {
                return true;
            }
            else if (Operadores_Dobles.Contains(lexema))
            {
                return true;
            }
            else if (Operadores_Simples.Contains(lexema))
            {
                return true;
            }
            else
            {
                return false;
            }
                
        }
        public static string Trae_Match(string lexema)
        {

            string tmp = "";
            if (MetodosAux_AL.EsReservada(lexema) != false)
            {
                return "T_es_Reservada";
            }
            else if (MetodosAux_AL.EsConstante(lexema, ref tmp) != false)
            {
                return tmp;
            }
            else if (Operadores_Dobles.Contains(lexema))
            {
                return "T_es_Operador";
            }
            else if (Operadores_Simples.Contains(lexema))
            {
                return "T_es_Operador";
            }
            else
            {
                return "";
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
                    valor = DiccionarioER_Valor[item];
                    
                    break;
                }
            }
            return resultado;
        }
        public static void AgregarError(string numero_linea, string def_Error) 
        {
            ArchivoDeSalida.Add($"*** ERROR {numero_linea}. ***     {def_Error}");
        }
        public static string ImprimirToken(Token token)
        {
            return ($"{token.palabra}  :  line:{token.linea}, inicio:{token.columna_i}, fin:{token.columna_f}; {token.valor}");
       
            
        }
        public static void Imprimir_En_Archivo(string comentario,string url)
        {
            using (StreamWriter writer = new StreamWriter(url))
            {
                writer.WriteLine(comentario);
                writer.Close();
            }
        }

        public static Token CrearToken(string palabra, int num_Linea, int num_columna, string valor) 
        {
  
            Token t = new Token();
            t.palabra = palabra;
            t.valor = valor;
            t.linea = num_Linea;
            t.columna_i = num_columna - palabra.Length;
            t.columna_f = num_columna-1;
            return t;


        }
    }
}
