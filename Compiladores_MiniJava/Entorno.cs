using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores_MiniJava
{
    public class Entorno
    {
        public  int ID;
        public  Dictionary<string,Simbolo> Simbolos = new Dictionary<string, Simbolo>();

        public bool Get(string ident)
        {
            if(Simbolos.ContainsKey(ident))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Put(string ident,Simbolo sim)
        {
            Simbolos.Add(ident, sim);
        }
        public void PutID(int id)
        {
            ID = id;
        }
    }
}
