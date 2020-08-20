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
            const int bufferLenght = 50;
            string URL = @"C:\Users\Marcos Andrés CM\Desktop\PRUEBA COMPI.txt";//Direccion archivo de prueba
            decimal Cantidad_Datos;
            //foreach (var arg in args)
            //{
                using (var File = new FileStream(URL, FileMode.Open))
                {
                    var buffer = new char[bufferLenght];
                    using (var reader = new BinaryReader(File))
                    {
                        Cantidad_Datos = reader.BaseStream.Length;
                        if (Cantidad_Datos > 0)//NO ESTÉ VACÍO EL ARCHIVO
                        {
                            while (reader.BaseStream.Position != reader.BaseStream.Length)
                            {
                                buffer = reader.ReadChars(bufferLenght);
                                var string_tmp = string.Empty;
                                var flag_EspaciosBlancos = false;
                                for (int posicion = 0; posicion < buffer.Length; posicion++)
                                {
                                    var item = buffer[posicion];
                                    if (item != 9 && item != 10 && item != 13 && item != 32)//tab, /n, CR, espacio
                                    {
                                        string_tmp += item; //verificar que su longitud no sea mayor de 31
                                    }
                                    else
                                    {
                                       flag_EspaciosBlancos = true;
                                    }
                                    //ya analizo string_tmp
                                    if (flag_EspaciosBlancos == true)
                                    {
                                        if (MetodosAux_AL.EsReservada(string_tmp) != false)
                                        {//ES RESERVADA
                                            string_tmp = string.Empty;
                                        }
                                        //APLICAR EXPRESIONES REGULARES PARA DETERMINAR LO QUE ES
                                        else
                                        {//VERIFICAMOS QUE SEA UN IDENTIFICADOR
                                            Regex rx = new Regex(@"[a-zA-Z$]+[a-zA-Z0-9$]*$");
                                            if (rx.IsMatch(string_tmp))
                                            {//ES UN IDENTIFICADOR
                                                var x = 0;
                                            }
                                        }
                                        flag_EspaciosBlancos = false;
                                    }
                                }
                                Console.WriteLine("");
                            }
                        }
                        else
                        {
                            Console.WriteLine("ARCHIVO DE ENTRADA VACIO");
                        }
                    }
                    
                }
                Console.ReadKey();
            //}
        }
    }
}
