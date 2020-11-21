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
        public double valorDouble;
        public int valorInt;
        public string valorbool;
        public string valorString;
        public Dictionary<string,Simbolo> argumento = new Dictionary<string, Simbolo>();
        public List<string> Extends = new List<string>();
        public List<string> Implements = new List<string>();

        public void AddExt(string ident) 
        {
            Extends.Add(ident);
        }
        public void AddImpl(string ident)
        {
            Implements.Add(ident);
        }
        public bool Get(string ident)
        {
            if (argumento.ContainsKey(ident))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Put(string ident, Simbolo sim)
        {
            argumento.Add(ident, sim);
        }
        //void x (int x , int y)
        
    }
}

