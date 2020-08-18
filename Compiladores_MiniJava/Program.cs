using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores_MiniJava
{
    class Program
    {
        static void Main(string[] args)
        {
            const int bufferLenght = 5;
            string URL = @"C:";//Direccion archivo de prueba
            decimal Cantidad_Datos;
            foreach (var arg in args)
            {
                using (var File = new FileStream(arg, FileMode.Open))
                {
                    var buffer = new byte[bufferLenght];
                    using (var reader = new BinaryReader(File))
                    {
                        Cantidad_Datos = reader.BaseStream.Length;
                        while (reader.BaseStream.Position != reader.BaseStream.Length)
                        {
                            buffer = reader.ReadBytes(bufferLenght);
                            foreach(var item in buffer)
                            {
                                Console.Write(Convert.ToChar(item));
                            }
                            Console.WriteLine("");
                        }
                        
                    }
                    
                }
                Console.ReadKey();
            }
        }
    }
}
