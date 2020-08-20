using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Compiladores_MiniJava
{
    public static class MetodosAux_AL
    {
        public static List<String> Reservadas = new List<string> 
        {"void","int","double","boolean","string", "class", "const", "interface", "null", "this", "extends", "implements", "for", "while", "if", "else", "returns", "break", "New", "System", "out", "println" };

        public static Dictionary<string, string> DiccionarioER_Valor = new Dictionary<string, string>() { { @"[a-zA-Z$]+[a-zA-Z0-9$]*$", "T_es_Id"}, {@"true|false", "T_es_ConstBool" }, {@"[0-9]+", "T_es_ConstDecimal"},
        {@"0x[a-fA-F]" , ""} };

        public static bool EsReservada(string palabra) 
        {
            Regex rx = new Regex(@"0x[a-fA-F]|[0-9]+");
            if (Reservadas.Contains(palabra))
            {
                return true;
            }
            return false;
        }
    }
}
