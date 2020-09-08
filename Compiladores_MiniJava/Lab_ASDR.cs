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
            if (P_lookahead < TokenList.Count)
            {
                if (TokenList.ToArray()[P_lookahead] != esperado)
                {

                    Console.WriteLine("Error de sintaxis se esperaba: " + esperado + " se encontro: " + TokenList.ToArray()[P_lookahead]);
                    P_lookahead++;
                }
                else
                {
                    P_lookahead++;
                }
            }
            else
            {
                Console.WriteLine("Error de sintaxis se esperaba: " + esperado + " pero no se finalizo");
                // error falto analizar no venia completo
            }
        }

        public static void Parse_Program()
        {
            Parse_Decl();
            Parse_Decl_PRIMA();
        }
        public static void Parse_Decl()
        {
            //Falta backtracking para saber cual de los 2 ir
            //Posible bool Parse_VariableDecl | Parse_FunctionDecl
            if (true)
            {
                Parse_VariableDecl();
            }
            else
            {
                Parse_FunctionDecl();
            }
        }
        public static void Parse_Decl_PRIMA()
        {
            //Falta bachtracking para ir a Decl Decl' | epsilon
            if (true)
            {
                Parse_Decl();
                Parse_Decl_PRIMA();
            }
            else
            {
                //EPSILON
            }
        }
        public static void Parse_VariableDecl()
        {
            //Correcto 
            Parse_Variable();
            MatchToken(";");
        }
        public static void Parse_Variable()
        {
            //Correcto
            Parse_Type();
            MatchToken("T_es_Id");
        }
        public static void Parse_Type()
        {
            //Correcto
            if (P_lookahead < TokenList.Count)
            {//                                                                                                     en java es boolean preguntar a ING
                if (TokenList.ToArray()[P_lookahead] == "int" || TokenList.ToArray()[P_lookahead] == "double" || TokenList.ToArray()[P_lookahead] == "bool" || TokenList.ToArray()[P_lookahead] == "string" || TokenList.ToArray()[P_lookahead] == "T_es_Id")
                {
                    P_lookahead++;
                    Parse_Type_PRIMA();
                }

            }
        }
        public static void Parse_Type_PRIMA()
        {
            //Correcto
            if (P_lookahead < TokenList.Count)
            {                                                                                                  
                if (TokenList.ToArray()[P_lookahead] == "[]")
                {
                    P_lookahead++;
                    Parse_Type_PRIMA();
                }
                else
                {
                    // epsilon
                }

            }
        }
        public static void Parse_FunctionDecl()
        {
            //Correcto
            if (P_lookahead < TokenList.Count)
            {// Parseando type
                if (TokenList.ToArray()[P_lookahead] == "int" || TokenList.ToArray()[P_lookahead] == "double" || TokenList.ToArray()[P_lookahead] == "bool" || TokenList.ToArray()[P_lookahead] == "string" || TokenList.ToArray()[P_lookahead] == "T_es_Id")
                {
                    P_lookahead++;
                    Parse_Type_PRIMA();
                    MatchToken("T_es_Id");
                    MatchToken("(");
                    Parse_Formals();
                    MatchToken(")");
                    Parse_FunctionDecl_PRIMA();

                }
                else if(TokenList.ToArray()[P_lookahead] == "void")
                {
                    MatchToken("T_es_Id");
                    MatchToken("(");
                    Parse_Formals();
                    MatchToken(")");
                    Parse_FunctionDecl_PRIMA();
                }
                else
                {
                    //ERROR DE SINTAXIS
                }

            }
        }
        public static void Parse_FunctionDecl_PRIMA()
        {
            // Falta backtaracking para ir a Stmt FunctionDecl’	| epsilon
        }
        public static void Parse_Formals()
        {
            //Correcto
            if (P_lookahead < TokenList.Count)
            {// Parseando type
                if (TokenList.ToArray()[P_lookahead] == "int" || TokenList.ToArray()[P_lookahead] == "double" || TokenList.ToArray()[P_lookahead] == "bool" || TokenList.ToArray()[P_lookahead] == "string" || TokenList.ToArray()[P_lookahead] == "T_es_Id")
                {
                    P_lookahead++;
                    Parse_Type_PRIMA();
                    MatchToken("T_es_Id");
                    Parse_Variable_PRIMA();
                    MatchToken(",");
                }
                else
                {
                    //epsilon
                }
            }
        }

        public static void Parse_Variable_PRIMA()
        {
            //Correcto
            if (P_lookahead < TokenList.Count)
            {// Parseando type
                if (TokenList.ToArray()[P_lookahead] == "int" || TokenList.ToArray()[P_lookahead] == "double" || TokenList.ToArray()[P_lookahead] == "bool" || TokenList.ToArray()[P_lookahead] == "string" || TokenList.ToArray()[P_lookahead] == "T_es_Id")
                {
                    P_lookahead++;
                    Parse_Type_PRIMA();
                    MatchToken("T_es_Id");
                    Parse_Variable_PRIMA();
                }
                else
                {
                    //epsilon
                }
            }
        }
        public static void Parse_IF_stmt()
        {
            //Correcto
            MatchToken("if");
            MatchToken("(");
            Parse_Expr();
            MatchToken(")");
            Parse_Stmt();
            Parse_IF_stmt_PRIMA();
        }
        public static void Parse_IF_stmt_PRIMA()
        {
            //Corecto
            if (P_lookahead < TokenList.Count)
            {
                if (TokenList.ToArray()[P_lookahead] == "else")
                {
                    P_lookahead++;
                    Parse_Stmt();
                }
                else
                {
                    //epsilon
                }
            }
        }
        public static void Parse_Stmt()
         {
            if (P_lookahead < TokenList.Count)
            {// Parseando type
                if (TokenList.ToArray()[P_lookahead] == "if" )
                {
                    Parse_IF_stmt();
                }
                else if(TokenList.ToArray()[P_lookahead] == "return")
                {
                    Parse_Return_Stmt();
                }
                //FALTA EXPR ; USAR BACKTRACKING
                else
                {
                    //ERROR SINTAXIS
                }
            }
        }
        public static void Parse_Return_Stmt()
        {
            //Correcto
            MatchToken("return");
            Parse_Return_Stmt_PRIMA();
            MatchToken(";");
        }
        public static void Parse_Return_Stmt_PRIMA()
        {
            //Falta backtraking para Expr | epsilon 
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
            if (P_lookahead < TokenList.Count)
            {
                //Aqui se parsea Constant 
                if (TokenList.ToArray()[P_lookahead] == "T_es_ConstDecimal" || TokenList.ToArray()[P_lookahead] == "T_es_ConstDouble" || TokenList.ToArray()[P_lookahead] == "T_es_ConstBool" || TokenList.ToArray()[P_lookahead] == "T_es_ConstBool" || TokenList.ToArray()[P_lookahead] == "T_es_String" || TokenList.ToArray()[P_lookahead] == "null")
                {
                    P_lookahead++;
                    //aceptado
                }
                else if (TokenList.ToArray()[P_lookahead] == "New")
                {
                    P_lookahead++;
                    MatchToken("(");
                    MatchToken("T_es_Id");
                    MatchToken(")");


                }
                else if (TokenList.ToArray()[P_lookahead] == "(")
                {
                    P_lookahead++;
                    Parse_Expr();
                    MatchToken(")");
                }
                // Falta LValue y LValue = Expr 
                else
                {
                    // error de sintaxis
                }
            }
        }
        public static void Parse_LValue()
        {
            if (P_lookahead < TokenList.Count)
            {
                if (TokenList.ToArray()[P_lookahead] == "T_es_Id")
                {
                    P_lookahead++;
                    //aceptado
                }
                else if (1 + 1 == 2)//Solo para que no de error
                {
                    //Expr Lvalue_Prima
                }
            }
        }
        public static void Parse_LValue_PRIMA()
        {
            if (P_lookahead < TokenList.Count)
            {
                if (TokenList.ToArray()[P_lookahead] == ".")
                {
                    P_lookahead++;
                    MatchToken("T_es_Id");
                    //aceptado
                }
                else if(TokenList.ToArray()[P_lookahead] == "[")
                {
                    Parse_Expr();
                    MatchToken("]");
                }
                else
                {
                    //Error de sintaxis
                }
            }
        }
    }
}
