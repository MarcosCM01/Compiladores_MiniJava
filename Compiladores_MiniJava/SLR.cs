using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores_MiniJava
{
    public static class SLR
    {
        public static Stack<int> PilaEstados = new Stack<int>(); //Se almacenaran los estados
        public static Stack<string> Simbolos = new Stack<string>(); //Se almacenaran los tokens consumidos
        public static bool BanderaReduccion = false; //Cuando haya que hacer reduccion, se activa para que se lea en Simbolo y no en Cadena
        //LAB_ASDR CONTIENE LA LISTA DE TOKENES, QUE VENDRIA SIENDO NUESTRA ENTRADA
        //DICCIONARIO INT, STRING PARA LAS REDUCCIONES
        public static void TABLA_ANALISIS() 
        {
            
        }

        public static void PARSER_PILA() 
        {
            PilaEstados.Push(0); //La pila siempre inicia en estado 0
            Lab_ASDR.TokenList.Add("$"); //Se agrega a la lista de tokens el $ para indicar fin
            var estado_Actual = PilaEstados.Peek();
            var simbolo_actual = Lab_ASDR.TokenList[0];
            for (int i = 0; i < Lab_ASDR.TokenList.Count; i++)
            {
                var accion = ObtenerAccion(estado_Actual, simbolo_actual);
            }

            
        }
        public static string ObtenerAccion(int estado, string simbolo) 
        {
            var accion = string.Empty;
            switch (estado)
            {
                case 0:
                    if (simbolo == "T_es_id")
                    {
                        accion = "d-18";
                    }
                    else if
                    {

                    }
                    break;
            }


        }

    }
}
