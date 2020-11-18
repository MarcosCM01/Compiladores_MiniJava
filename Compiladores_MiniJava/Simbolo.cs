using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores_MiniJava
{
    public class Simbolo
    {
        public string tipo;//Esto será si es int, string... class, interface
        public double valorNumerico;
        public string valorbool;
        public string valorString;
        public List<Simbolo> argumento = new List<Simbolo>();
        //void x (int x , int y)
    }
}

