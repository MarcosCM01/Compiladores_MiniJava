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
        private static int P_lookahead = 0;
        public static void Sintactico_Recursivo()
        {

            //EMPEZAMOS LA GRAMATICA
            //1. PROGRAM
            Parse_Expr();
            //1. STMT
            //2. IF STMT

        }
        public static void MatchToken(string esperado)
        {
            if (TokenList.ToArray()[P_lookahead] != esperado)
            {
                Console.WriteLine("Error de sintaxis se esperaba: " + esperado + " se encontro: " + TokenList.ToArray()[P_lookahead]);
            }
            else
            {
                P_lookahead++;
            }
        }

        //public static void Parse_Program() {
        //    Parse_Decl();
        //    Parse_Decl_PRIMA();
        //}
        //public static void Parse_Decl() {
        //    if (true)
        //    {
        //        Parse_VariableDecl();
        //    }
        //    else
        //    {
        //        Parse_FunctionDecl();
        //    }
        //}
        //public static void Parse_Decl_PRIMA() {
        //    if (true)
        //    {
        //        Parse_Decl();
        //        Parse_Decl_PRIMA();
        //    }
        //    else
        //    {
        //        //EPSILON
        //    }
        //}
        //public static void Parse_VariableDecl() {
        //    Parse_Variable();
        //    Match_Token(';');
        //}
        //public static void Parse_Variable() {
        //    Parse_Type();
        //    if (Token == "T_es_id")
        //    {

        //    }
        //}
        //public static void Parse_Type() {
        //    if (Token == "T_es_ConstDecimal")
        //    {
        //        Parse_Type_PRIMA();
        //    }
        //    else if (Token == "T_es_ConstDouble")
        //    {
        //        Parse_Type_PRIMA();
        //    }
        //    else if (Token == "T_es_ConstBool")
        //    {
        //        Parse_Type_PRIMA();
        //    }
        //    else if (Token == "T_es_String")
        //    {
        //        Parse_Type_PRIMA();
        //    }
        //    else if (Token == "T_es_Id")
        //    {
        //        Parse_Type_PRIMA();
        //    }
        //}
        //public static void Parse_Type_PRIMA() {
        //    if (Match_Token(';'))
        //    {
        //        Parse_Type_PRIMA();
        //    }
        //    else
        //    {
        //        //EPSILON
        //    }
        //}
        //public static void Parse_FunctionDecl() {
        //    Parse_Type();
        //}



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

        public static void Parse_Expr()
        {
            Parse_A();
            Parse_Expr_PRIMA();
        }
        public static void Parse_Expr_PRIMA()
        {
            if (P_lookahead < TokenList.Count)
            {
                if (TokenList.ToArray()[P_lookahead] == "||" || TokenList.ToArray()[P_lookahead] == "&&")
                {
                    P_lookahead++;
                    Parse_A();
                    Parse_Expr_PRIMA();
                }
                else
                {
                    //Epsilon
                }

            }
        }
        public static void Parse_A()
        {
            Parse_B();
            Parse_A_PRIMA();
        }
        public static void Parse_A_PRIMA()
        {
            if (P_lookahead < TokenList.Count)
            {
                if (TokenList.ToArray()[P_lookahead] == "==" || TokenList.ToArray()[P_lookahead] == "!=")
                {
                    P_lookahead++;
                    Parse_B();
                    Parse_A_PRIMA();
                }
                else
                {
                    //Epsilon
                }
            }
        }
        public static void Parse_B()
        {
            Parse_C();
            Parse_B_PRIMA();
        }
        public static void Parse_B_PRIMA()
        {
            if (P_lookahead < TokenList.Count)
            {
                if (TokenList.ToArray()[P_lookahead] == "<" || TokenList.ToArray()[P_lookahead] == "<=" || TokenList.ToArray()[P_lookahead] == ">" || TokenList.ToArray()[P_lookahead] == ">=")
                {
                    P_lookahead++;
                    Parse_C();
                    Parse_B_PRIMA();
                }
                else
                {
                    //Epsilon
                }
            }
        }
        public static void Parse_C()
        {
            Parse_D();
            Parse_C_PRIMA();

        }
        public static void Parse_C_PRIMA()
        {
            if (P_lookahead < TokenList.Count)
            {
                if (TokenList.ToArray()[P_lookahead] == "+" || TokenList.ToArray()[P_lookahead] == "-")
                {
                    P_lookahead++;
                    Parse_D();
                    Parse_C_PRIMA();
                }
                else
                {
                    //Epsilon
                }
            }
        }
        public static void Parse_D()
        {
            Parse_E();
            Parse_D_PRIMA();
        }
        public static void Parse_D_PRIMA()
        {
            if (P_lookahead < TokenList.Count)
            {
                if (TokenList.ToArray()[P_lookahead] == "*" || TokenList.ToArray()[P_lookahead] == "/" || TokenList.ToArray()[P_lookahead] == "%")
                {
                    P_lookahead++;
                    Parse_E();
                    Parse_D_PRIMA();
                }
                else
                {
                    //Epsilon
                }
            }
        }
        public static void Parse_E()
        {
            if (P_lookahead < TokenList.Count)
            {
                if (TokenList.ToArray()[P_lookahead] == "-" || TokenList.ToArray()[P_lookahead] == "!")
                {
                    P_lookahead++;
                    Parse_F();
                }
                else
                {
                    Parse_F();
                }
            }
        }

        public static void Parse_F()
        {
            Parse_Constant();
        }
        public static void Parse_Constant()
        {
            if (P_lookahead < TokenList.Count)
            {
                if (TokenList.ToArray()[P_lookahead] == "T_es_ConstDecimal" || TokenList.ToArray()[P_lookahead] == "T_es_ConstDouble" || TokenList.ToArray()[P_lookahead] == "T_es_ConstBool" || TokenList.ToArray()[P_lookahead] == "T_es_ConstBool" || TokenList.ToArray()[P_lookahead] == "T_es_String")
                {
                    P_lookahead++;
                    //aceptado
                }
                else
                {
                    //error sintaxis
                }
            }
        }
    }
}
