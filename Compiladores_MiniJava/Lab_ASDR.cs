using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores_MiniJava
{
    public static class Lab_ASDR
    {
        public static List<string> TokenList = new List<string>();

        public static void Sintactico_Recursivo() 
        {
            //EMPEZAMOS LA GRAMATICA
            //1. STMT
            //2. IF STMT
            
        }
        public static void Parse_IF_stmt() 
        {
            //ifSTMT --> if ( EXPR ) STMT IF_STMT'
            //MatchToken(if)
            //MatchToken ('(')
            //Parse(EXPR)
            //MatchToken (')')
            //Parse()


        }
        public static void Parse_Stmt() 
        {
            //stmt --> ifStmt | ReturnStmt | Expr ;
            //if (Parse_IF_stmt)
            //else if(Parse_RETURN_stmt)
            //else if(Parse_EXPR)
            //{matchToken(';')}
        }

    }
}
