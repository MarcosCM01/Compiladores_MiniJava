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
            Parse_Program();
            //var match_SR = false;
            //Parse_Expr(ref match_SR);
        }
        public static void MatchToken(string esperado, ref bool hizo_match)
        {
            if (P_lookahead < TokenList.Count)
            {
                if (TokenList.ToArray()[P_lookahead] != esperado)
                {
                    hizo_match = false;
                    Console.WriteLine($"Error de sintaxis se esperaba: {esperado}, se encontro: {TokenList.ToArray()[P_lookahead]}.");
                    P_lookahead++; //VER ESTO
                }
                else
                {
                    hizo_match = true;
                    P_lookahead++;
                }
            }
            else
            {
                Console.WriteLine($"Error de sintaxis se esperaba: {esperado}, pero no se finalizo");
                // error falto analizar no venia completo
            }
        }

        public static void Parse_Program()
        {
            var match_D = true;
            Parse_Decl(ref match_D);
            Parse_Decl_PRIMA();
        }
        public static void Parse_Decl(ref bool D)
        {
            //Falta backtracking para saber cual de los 2 ir
            //Posible bool Parse_VariableDecl | Parse_FunctionDecl
            var auxL = P_lookahead;
            var match_D = false;
            Parse_VariableDecl(ref match_D);
            if (match_D == false && P_lookahead < TokenList.Count)
            {
                P_lookahead = auxL;
                Parse_FunctionDecl();
            }
            D = match_D;
        }
        public static void Parse_Decl_PRIMA()
        {
            //Falta bachtracking para ir a Decl Decl' | epsilon
            var match_DP = false;
            var auxL = P_lookahead;
            Parse_Decl(ref match_DP);
            if (match_DP == true)
            {
                Parse_Decl_PRIMA();
            }
            else
            {
                P_lookahead = auxL;
                //EPSILON
            }
        }
        public static void Parse_VariableDecl(ref bool VD)
        {
            //Correcto
            var match_vd = false;
            Parse_Variable(ref match_vd);
            if (match_vd == true)
            {
                MatchToken(";", ref match_vd);
            }
            VD = match_vd;
        }
        public static void Parse_Variable(ref bool V)
        {
            //Correcto
            var match_v = false;
            Parse_Type(ref match_v);
            if (match_v == true)
            {
                MatchToken("T_es_Id", ref match_v);
            }
            V = match_v;
        }
        public static void Parse_Type(ref bool T)
        {
            //Correcto
            var match_type = false;
            if (P_lookahead < TokenList.Count)
            {//                                                                                                     en java es boolean preguntar a ING
                if (TokenList.ToArray()[P_lookahead] == "int" || TokenList.ToArray()[P_lookahead] == "double" || TokenList.ToArray()[P_lookahead] == "bool" || TokenList.ToArray()[P_lookahead] == "string" || TokenList.ToArray()[P_lookahead] == "T_es_Id")
                {
                    P_lookahead++;
                    Parse_Type_PRIMA(ref match_type);
                }
                //else
                //{
                //    Console.WriteLine($"Error de sintaxis. se esperaba una constante");
                //}
            }
            T = match_type;
        }
        public static void Parse_Type_PRIMA(ref bool TP)
        {
            //Correcto
            if (P_lookahead < TokenList.Count)
            {                                                                                                  
                if (TokenList.ToArray()[P_lookahead] == "[]")
                {
                    P_lookahead++;
                    TP = true;
                    Parse_Type_PRIMA(ref TP);
                }
                else
                {
                    TP = true;
                    // epsilon
                }

            }
        }
        public static void Parse_FunctionDecl()
        {
            //Correcto
            if (P_lookahead < TokenList.Count)
            {// Parseando type
                var match_functionD = false;
                var auxL = P_lookahead;
                Parse_Type(ref match_functionD);
                if (match_functionD == true)
                {
                    //P_lookahead++;
                    //Parse_Type_PRIMA();
                    MatchToken("T_es_Id", ref match_functionD);
                    MatchToken("(", ref match_functionD);
                    Parse_Formals();
                    MatchToken(")", ref match_functionD);
                    Parse_FunctionDecl_PRIMA();

                }
                else if (TokenList.ToArray()[auxL] == "void")
                {
                    P_lookahead = auxL;
                    P_lookahead++;
                    MatchToken("T_es_Id",ref match_functionD);
                    MatchToken("(", ref match_functionD);
                    Parse_Formals();
                    MatchToken(")", ref match_functionD);
                    Parse_FunctionDecl_PRIMA();
                }
                else
                {
                    Console.WriteLine($"Error sintactico. Se esperaba un tipo de dato o void");//ERROR DE SINTAXIS
                }

            }
        }
        public static void Parse_FunctionDecl_PRIMA()
        {
            // Falta backtaracking para ir a Stmt FunctionDecl’	| epsilon
            var match_FuncionDP = false;
            var auxL = P_lookahead;
            Parse_Stmt(ref match_FuncionDP);
            if (match_FuncionDP == true)
            {
                Parse_FunctionDecl_PRIMA();
            }
            else if (P_lookahead < TokenList.Count)
            {
                P_lookahead = auxL;
                //epsilon
            }
        }
        public static void Parse_Formals()
        {
            //Correcto
            var match_formals = false;
            if (P_lookahead < TokenList.Count)
            {// Parseando type
                var auxL = P_lookahead;
                Parse_Variable(ref match_formals);
                if (match_formals == true)
                {
                    //P_lookahead++;
                    //Parse_Type_PRIMA();
                    //MatchToken("T_es_Id", ref match_formals);
                    Parse_Variable_PRIMA();
                    MatchToken(",", ref match_formals);
                }
                else
                {
                    P_lookahead = auxL;
                    //epsilon
                }
            }
        }
        public static void Parse_Variable_PRIMA()
        {
            //Correcto
            if (P_lookahead < TokenList.Count)
            {// Parseando type
                var match_variableP = false;
                var auxL = P_lookahead;
                Parse_Variable(ref match_variableP);
                if (match_variableP == true)
                {
                    //P_lookahead++;
                    //Parse_Type_PRIMA();
                    //MatchToken("T_es_Id");
                    Parse_Variable_PRIMA();
                }
                else
                {
                    P_lookahead = auxL;
                    //epsilon
                }
            }
        }
        public static void Parse_Stmt(ref bool S)
        {// este ref S es para la produccion de FUNCTION_DECL'
            var match_S = false;
            if (P_lookahead < TokenList.Count)
            {// Parseando type
                var auxL = P_lookahead;
                if (TokenList.ToArray()[auxL] == "if")
                {
                    Parse_IF_stmt(ref match_S);
                }
                else if (TokenList.ToArray()[auxL] == "return")
                {
                    Parse_Return_Stmt(ref match_S);
                }
                else if (match_S == false) //no entro al if ni al return stmt
                {
                    Parse_Expr(ref match_S);
                    if (match_S == true)
                    {
                        MatchToken(";", ref match_S);
                    }
                }
                //FALTA EXPR ; USAR BACKTRACKING
                else
                {
                    Console.WriteLine($"Error de sintaxis. No venia if, return o expresion");//ERROR SINTAXIS
                }
            }
            S = match_S;
        }
        public static void Parse_IF_stmt(ref bool ifS)
        {
            //Correcto
            var match_ifS = false;
            MatchToken("if", ref match_ifS);
            MatchToken("(", ref match_ifS);
            Parse_Expr(ref match_ifS);
            MatchToken(")", ref match_ifS);
            Parse_Stmt(ref match_ifS);
            Parse_IF_stmt_PRIMA(ref match_ifS);
            ifS = match_ifS;
        }
        public static void Parse_IF_stmt_PRIMA(ref bool ifSP)
        {
            //Corecto
            var match_ifSP = false;
            if (P_lookahead < TokenList.Count)
            {
                if (TokenList.ToArray()[P_lookahead] == "else")
                {
                    P_lookahead++;
                    Parse_Stmt(ref match_ifSP);
                }
                else
                {
                    //epsilon
                }
            }
            ifSP = match_ifSP;
        }
        
        public static void Parse_Return_Stmt(ref bool RS)
        {
            //Correcto
            var match_RS = false;
            MatchToken("return", ref match_RS);
            Parse_Return_Stmt_PRIMA();
            MatchToken(";", ref match_RS);
            RS = match_RS;
        }
        public static void Parse_Return_Stmt_PRIMA()
        {
            //Falta backtraking para Expr | epsilon 
            var match_RSP = false;
            var auxL = P_lookahead;
            Parse_Expr(ref match_RSP);
            if (match_RSP == false && P_lookahead < TokenList.Count)
            {
                P_lookahead = auxL;
                //epsilon
            }
        }
        public static void Parse_Constant(ref bool C) 
        {
            if (TokenList.ToArray()[P_lookahead] == "T_es_ConstDecimal" || TokenList.ToArray()[P_lookahead] == "T_es_ConstDouble" || TokenList.ToArray()[P_lookahead] == "T_es_ConstBool" || TokenList.ToArray()[P_lookahead] == "T_es_ConstBool" || TokenList.ToArray()[P_lookahead] == "T_es_String" || TokenList.ToArray()[P_lookahead] == "null")
            {
                P_lookahead++;
                C = true;//aceptado
            }
        }
        public static void Parse_Expr(ref bool E)
        {
            var match_ex = false;
            Parse_A(ref match_ex);
            if (match_ex == true)
            {
                Parse_Expr_PRIMA(ref match_ex);
            }
            E = match_ex;
        }
        public static void Parse_Expr_PRIMA(ref bool EP)
        {
            if (P_lookahead < TokenList.Count)
            {
                if (TokenList.ToArray()[P_lookahead] == "||" || TokenList.ToArray()[P_lookahead] == "&&")
                {
                    P_lookahead++;
                    Parse_A(ref EP);
                    Parse_Expr_PRIMA(ref EP);
                }
                else
                {
                    EP = true;
                    //Epsilon
                }

            }
        }
        public static void Parse_A(ref bool A)
        {
            var match_A = false;
            Parse_B(ref match_A);
            Parse_A_PRIMA(ref match_A);
            A = match_A;
        }
        public static void Parse_A_PRIMA(ref bool AP)
        {
            var match_AP = false;
            if (P_lookahead < TokenList.Count)
            {
                if (TokenList.ToArray()[P_lookahead] == "==" || TokenList.ToArray()[P_lookahead] == "!=")
                {
                    P_lookahead++;
                    Parse_B(ref match_AP);
                    Parse_A_PRIMA(ref match_AP);
                }
                else
                {
                    match_AP = true;
                    //Epsilon
                }
            }
            AP = match_AP;
        }
        public static void Parse_B(ref bool B)
        {
            Parse_C(ref B);
            Parse_B_PRIMA(ref B);
        }
        public static void Parse_B_PRIMA(ref bool BP)
        {
            if (P_lookahead < TokenList.Count)
            {
                if (TokenList.ToArray()[P_lookahead] == "<" || TokenList.ToArray()[P_lookahead] == "<=" || TokenList.ToArray()[P_lookahead] == ">" || TokenList.ToArray()[P_lookahead] == ">=")
                {
                    P_lookahead++;
                    Parse_C(ref BP);
                    Parse_B_PRIMA(ref BP);
                }
                else
                {
                    BP = true;
                    //Epsilon
                }
            }
        }
        public static void Parse_C(ref bool C)
        {
            Parse_D(ref C);
            Parse_C_PRIMA(ref C);
        }
        public static void Parse_C_PRIMA(ref bool C)
        {
            if (P_lookahead < TokenList.Count)
            {
                if (TokenList.ToArray()[P_lookahead] == "+" || TokenList.ToArray()[P_lookahead] == "-")
                {
                    P_lookahead++;
                    Parse_D(ref C);
                    Parse_C_PRIMA(ref C);
                }
                else
                {
                    C = true;
                    //Epsilon
                }
            }
        }
        public static void Parse_D(ref bool D)
        {
            Parse_E(ref D);
            Parse_D_PRIMA(ref D);
        }
        public static void Parse_D_PRIMA(ref bool DP)
        {
            if (P_lookahead < TokenList.Count)
            {
                if (TokenList.ToArray()[P_lookahead] == "*" || TokenList.ToArray()[P_lookahead] == "/" || TokenList.ToArray()[P_lookahead] == "%")
                {
                    P_lookahead++;
                    Parse_E(ref DP);
                    Parse_D_PRIMA(ref DP);
                }
                else
                {
                    DP = true;
                    //Epsilon
                }
            }
        }
        public static void Parse_E(ref bool E)
        {
            if (P_lookahead < TokenList.Count)
            {
                if (TokenList.ToArray()[P_lookahead] == "-" || TokenList.ToArray()[P_lookahead] == "!")
                {
                    P_lookahead++;
                    Parse_F(ref E);
                }
                else
                {
                    Parse_F(ref E);
                }
            }
        }

        public static void Parse_F(ref bool F)
        {
            if (P_lookahead < TokenList.Count)
            {
                //falta que produzca LVALUE = EXPR
                //Aqui se parsea Constant 
                var match_F = false;
                var auxL = P_lookahead;
                if (TokenList.ToArray()[auxL] == ".")
                {
                    P_lookahead++;
                    //match_F = true;
                    MatchToken("T_es_Id", ref match_F);
                    Parse_X_PRIMA(ref match_F);
                }
                else if (TokenList.ToArray()[auxL] == "[")
                {
                    P_lookahead = auxL;
                    P_lookahead++;
                    Parse_Expr(ref match_F);
                    MatchToken("]", ref match_F);
                    Parse_X_PRIMA(ref match_F);
                }
                else
                {
                    Parse_G(ref match_F);
                }
                F = match_F;
            }
        }
        public static void Parse_G(ref bool G)
        {
            if (P_lookahead < TokenList.Count)
            {
                var match_g = false;
                var aux = P_lookahead;
                Parse_Constant(ref match_g);
                if (match_g == true)
                {
                    
                }
                else if (TokenList.ToArray()[aux] == "New")
                {
                    P_lookahead = aux + 1;
                    MatchToken("(", ref match_g);
                    MatchToken("T_es_Id", ref match_g);
                    MatchToken(")", ref match_g);
                }
                else if (TokenList.ToArray()[aux] == "(")
                {
                    P_lookahead = aux + 1;
                    Parse_Expr(ref match_g);
                    MatchToken(")", ref match_g);
                }
                else if(TokenList.ToArray()[aux] == "this")
                {
                    P_lookahead = aux + 1;
                }
                else if(TokenList.ToArray()[aux] == "T_es_Id")
                {
                    P_lookahead = aux + 1;
                    Parse_X_PRIMA(ref match_g);
                }
                else
                {
                    Console.WriteLine("Error ");
             
                }
                match_g = G;
            }
            
        }
        public static void Parse_X_PRIMA(ref bool FP)
        {
            if (P_lookahead < TokenList.Count)
            {
                
                if (TokenList.ToArray()[P_lookahead] == "=")
                {
                    P_lookahead++;
                    Parse_Expr(ref FP);
                }
                else
                {
                    //Epsilon
                    FP = true;
                }
               
                  
            }
        }

    }
}
