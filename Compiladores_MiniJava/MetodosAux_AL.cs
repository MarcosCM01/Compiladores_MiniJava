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

        public static Dictionary<string, string> DiccionarioER_Valor = new Dictionary<string, string>() { { @"^[a-zA-Z$]+[a-zA-Z0-9$]*$", "T_es_Id"}, { @"^\b(true|false)\b$", "T_es_ConstBool"}, {@"^\b[0-9]+\b$", "T_es_ConstDecimal"}, 
        { @"^\b0(x|X)[a-fA-F0-9]+\b$", "T_es_ConstHexadecimal"}, {@"^[0-9]+\.([0-9]*|[0-9]*E(\+|-)?[0-9]+)?$","T_es_ConstDouble"} };

        public const int bufferLenght = 50;

        public static List<string> ArchivoDeSalida = new List<string>();

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
            using (var File = new FileStream(URL, FileMode.Open))
            {
                var buffer = new char[bufferLenght];
                using (var reader = new BinaryReader(File))
                {
                    while (reader.BaseStream.Position != reader.BaseStream.Length)
                    {
                        buffer = reader.ReadChars(bufferLenght);
                        var tmp_string = string.Empty;
                        for (int posicion = 0; posicion < buffer.Length; posicion++)
                        {
                            var item = buffer[posicion];
                            if (item != 9 && item != 10 && item != 13 && item != 32)//tab, /n, CR, espacio
                            {
                                tmp_string += item; //verificar que su longitud no sea mayor de 31
                            }
                            else //se analiza el tmp_string
                            {
                                if (tmp_string.Length > 0)
                                {
                                    if (MetodosAux_AL.EsReservada(tmp_string) != false)
                                    {//ES RESERVADA
                                        AgregarToken(tmp_string, "T_es_Reservada");//DETERMINAR EL NUMERO DE LINEA Y COLUMNA
                                    }
                                    //APLICAR EXPRESIONES REGULARES PARA DETERMINAR LO QUE ES
                                    else
                                    {//VERIFICAMOS QUE SEA CONSTANTE
                                        if (MetodosAux_AL.EsConstante(tmp_string) != true)//NO COINCIDIO CON ALGUN TIPO DE CONSTANTE
                                        {

                                        }
                                    }
                                    tmp_string = string.Empty;
                                }
                                else if (tmp_string.Length > 0 && posicion + 1 == buffer.Length)//CUANDO SE LEA LO ULTIMO DEL ARCHIVO
                                {

                                }
                            }
                            
                        }
                    }
                }

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
        public static bool EsConstante(string palabra) 
        {
            var resultado = false;
            foreach (var item in DiccionarioER_Valor.Keys)
            {
                Regex rx = new Regex(item);
                if (rx.IsMatch(palabra))
                {//ES UNA CONSTANTE
                    AgregarToken(palabra, item);
                    resultado = true;
                }
            }
            return resultado;
        }
        public static void AgregarError(string numero_linea, string def_Error) 
        {
            ArchivoDeSalida.Add($"*** ERROR {numero_linea}. ***     {def_Error}");
        }
        public static void AgregarToken(string palabra, string valor_token) 
        {
            ArchivoDeSalida.Add( $"{palabra}          line cols  is {valor_token}");
        }
        public static void ImprimirResultado() 
        {
            for (int i = 0; i < ArchivoDeSalida.Count; i++)
            {
                Console.WriteLine(ArchivoDeSalida[i]);
            }
        }

    }
}
