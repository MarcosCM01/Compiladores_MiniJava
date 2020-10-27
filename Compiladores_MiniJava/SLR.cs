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
            //var estado_Actual = PilaEstados.Peek();
            var simbolo_actual = Lab_ASDR.TokenList[0];
            for (int i = 0; i < Lab_ASDR.TokenList.Count; i++)
            {
                switch(PilaEstados.Peek())
                {
                    case 0:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s18
                            PilaEstados.Push(18);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //s11
                            PilaEstados.Push(11);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //s14
                            PilaEstados.Push(14);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //s15
                            PilaEstados.Push(15);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //s17
                            PilaEstados.Push(17);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //s16
                            PilaEstados.Push(16);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //s10
                            PilaEstados.Push(10);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //s12
                            PilaEstados.Push(12);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //s13
                            PilaEstados.Push(13);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if(BanderaReduccion == true)
                        {
                            BanderaReduccion = false;
                            if(Simbolos.Peek() == "Program")
                            {
                                PilaEstados.Push(1);
                                i--;
                                //Preguntar al inicio del for si la bandera esta activa 
                                //Analizar otro switch
                            }
                            else if (Simbolos.Peek() == "Decl")
                            {
                                PilaEstados.Push(2);
                                i--;
                               
                            }
                            else if (Simbolos.Peek() == "VariableDecl")
                            {
                                PilaEstados.Push(3);
                                i--;

                            }
                            else if (Simbolos.Peek() == "Variable")
                            {
                                PilaEstados.Push(8);
                                i--;

                            }
                            else if (Simbolos.Peek() == "ConstDecl")
                            {
                                PilaEstados.Push(5);
                                i--;

                            }
                            else if (Simbolos.Peek() == "Type")
                            {
                                PilaEstados.Push(9);
                                i--;

                            }
                            else if (Simbolos.Peek() == "FunctionDecl")
                            {
                                PilaEstados.Push(4);
                                i--;

                            }
                            else if (Simbolos.Peek() == "ClassDecl")
                            {
                                PilaEstados.Push(6);
                                i--;

                            }
                            else if (Simbolos.Peek() == "InterfaceDecl")
                            {
                                PilaEstados.Push(7);
                                i--;

                            }

                        }
                        //Revisar los no terminales para Ir_A
                        //
                        //
                            break;
                    case 1:
                        if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //aceeptar
                        }
                        break;
                    case 2:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s18
                            PilaEstados.Push(18);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //s11
                            PilaEstados.Push(11);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //s14
                            PilaEstados.Push(14);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //s15
                            PilaEstados.Push(15);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //s17
                            PilaEstados.Push(17);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //s16
                            PilaEstados.Push(16);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //s10
                            PilaEstados.Push(10);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //s12
                            PilaEstados.Push(12);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //s13
                            PilaEstados.Push(13);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r8
                            //revisar
                            //
                            ///
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;
                            if (Simbolos.Peek() == "Decl'")
                            {
                                PilaEstados.Push(19);
                                i--;
                                //Preguntar al inicio del for si la bandera esta activa 
                                //Analizar otro switch
                            }
                            else if (Simbolos.Peek() == "Decl")
                            {
                                PilaEstados.Push(20);
                                i--;

                            }
                            else if (Simbolos.Peek() == "VariableDecl")
                            {
                                PilaEstados.Push(3);
                                i--;

                            }
                            else if (Simbolos.Peek() == "Variable")
                            {
                                PilaEstados.Push(8);
                                i--;

                            }
                            else if (Simbolos.Peek() == "ConstDecl")
                            {
                                PilaEstados.Push(5);
                                i--;

                            }
                            else if (Simbolos.Peek() == "Type")
                            {
                                PilaEstados.Push(9);
                                i--;

                            }
                            else if (Simbolos.Peek() == "FunctionDecl")
                            {
                                PilaEstados.Push(4);
                                i--;

                            }
                            else if (Simbolos.Peek() == "ClassDecl")
                            {
                                PilaEstados.Push(6);
                                i--;

                            }
                            else if (Simbolos.Peek() == "InterfaceDecl")
                            {
                                PilaEstados.Push(7);
                                i--;

                            }

                        }
                        break;
                    case 3:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r2

                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r2

                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r2
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r2
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r2
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r2
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r2
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r2
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r2
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r2
                            //revisar
                            //
                            ///
                        }
                        break;
                    case 4:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r3

                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r3

                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r3
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r3
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r3
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r3
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r3
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r3
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r3
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r3
                            //revisar
                            //
                            ///
                        }
                        break;
                    case 5:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r4

                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r4

                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r4
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r4
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r4
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r4
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r4
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r4
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r4
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r4
                            //revisar
                            //
                            ///
                        }
                        break;
                    case 6:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r5

                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r5

                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r5
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r5
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r5
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r5
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r5
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r5
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r5
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r5
                            //revisar
                        }
                        break;
                    case 7:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r6

                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r6

                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r6
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r6
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r6
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r6
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r6
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r6
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r6
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r6
                        }
                        break;
                    case 8:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //s21
                            PilaEstados.Push(21);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 9:
                        if (Lab_ASDR.TokenList[i] == "T_es_id")
                        {
                            //s22
                            PilaEstados.Push(22);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 10:
                        if (Lab_ASDR.TokenList[i] == "T_es_id")
                        {
                            //s23
                            PilaEstados.Push(23);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 11:
                        if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //s25
                            PilaEstados.Push(25);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //s26
                            PilaEstados.Push(26);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //s27
                            PilaEstados.Push(27);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //s28
                            PilaEstados.Push(28);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;
                            if (Simbolos.Peek() == "ConstType")
                            {
                                PilaEstados.Push(24);
                                i--;
                                //Preguntar al inicio del for si la bandera esta activa 
                                //Analizar otro switch
                            }

                        }
                            break;
                    case 12:
                        if (Lab_ASDR.TokenList[i] == "T_es_id")
                        {
                            //s29
                            PilaEstados.Push(29);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 13:
                        if (Lab_ASDR.TokenList[i] == "T_es_id")
                        {
                            //s30
                            PilaEstados.Push(30);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 14:
                        if (Lab_ASDR.TokenList[i] == "[")
                        {
                            //s32
                            PilaEstados.Push(32);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_id")
                        {
                            //r22
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;
                            if (Simbolos.Peek() == "Type'")
                            {
                                PilaEstados.Push(31);
                                i--;
                                //Preguntar al inicio del for si la bandera esta activa 
                                //Analizar otro switch
                            }
                        }
                        break;
                    case 15:
                        if (Lab_ASDR.TokenList[i] == "T_es_id")
                        {
                            //r22
                        }
                        else if (Lab_ASDR.TokenList[i] == "[")
                        {
                            //s32
                            PilaEstados.Push(32);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;
                            if (Simbolos.Peek() == "Type'")
                            {
                                PilaEstados.Push(33);
                                i--;
                                //Preguntar al inicio del for si la bandera esta activa 
                                //Analizar otro switch
                            }
                        }
                        break;
                    case 16:
                        if (Lab_ASDR.TokenList[i] == "T_es_id")
                        {
                            //r22
                        }
                        else if (Lab_ASDR.TokenList[i] == "[")
                        {
                            //s32
                            PilaEstados.Push(32);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;
                            if (Simbolos.Peek() == "Type'")
                            {
                                PilaEstados.Push(34);
                                i--;
                                //Preguntar al inicio del for si la bandera esta activa 
                                //Analizar otro switch
                            }
                        }
                        break;
                    case 17:
                        if (Lab_ASDR.TokenList[i] == "T_es_id")
                        {
                            //r22
                        }
                        else if (Lab_ASDR.TokenList[i] == "[")
                        {
                            //s32
                            PilaEstados.Push(32);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;
                            if (Simbolos.Peek() == "Type'")
                            {
                                PilaEstados.Push(35);
                                i--;
                                //Preguntar al inicio del for si la bandera esta activa 
                                //Analizar otro switch
                            }
                        }
                        break;
                    case 18:
                        if (Lab_ASDR.TokenList[i] == "T_es_id")
                        {
                            //r22
                        }
                        else if (Lab_ASDR.TokenList[i] == "[")
                        {
                            //s32
                            PilaEstados.Push(32);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;
                            if (Simbolos.Peek() == "Type'")
                            {
                                PilaEstados.Push(36);
                                i--;
                                //Preguntar al inicio del for si la bandera esta activa 
                                //Analizar otro switch
                            }
                        }
                        break;
                    case 19:
                        if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r1
                        }
                        break;
                    case 20:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s18
                            PilaEstados.Push(18);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //s11
                            PilaEstados.Push(11);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //s14
                            PilaEstados.Push(14);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //s15
                            PilaEstados.Push(15);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //s17
                            PilaEstados.Push(17);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //s16
                            PilaEstados.Push(16);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //s10
                            PilaEstados.Push(10);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //s12
                            PilaEstados.Push(12);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //s13
                            PilaEstados.Push(13);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r8

                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;
                            if (Simbolos.Peek() == "Decl'")
                            {
                                PilaEstados.Push(37);
                                i--;
                                //Preguntar al inicio del for si la bandera esta activa 
                                //Analizar otro switch
                            }
                            else if (Simbolos.Peek() == "Decl")
                            {
                                PilaEstados.Push(20);
                                i--;

                            }
                            else if (Simbolos.Peek() == "VariableDecl")
                            {
                                PilaEstados.Push(3);
                                i--;

                            }
                            else if (Simbolos.Peek() == "Variable")
                            {
                                PilaEstados.Push(8);
                                i--;

                            }
                            else if (Simbolos.Peek() == "ConstDecl")
                            {
                                PilaEstados.Push(5);
                                i--;

                            }
                            else if (Simbolos.Peek() == "Type")
                            {
                                PilaEstados.Push(9);
                                i--;

                            }
                            else if (Simbolos.Peek() == "FunctionDecl")
                            {
                                PilaEstados.Push(4);
                                i--;

                            }
                            else if (Simbolos.Peek() == "ClassDecl")
                            {
                                PilaEstados.Push(6);
                                i--;

                            }
                            else if (Simbolos.Peek() == "InterfaceDecl")
                            {
                                PilaEstados.Push(7);
                                i--;

                            }
                        }
                            break;
                    case 21:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r9
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r9

                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r9

                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r9
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r9
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r9
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r9
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r9
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r9
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r9
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r9
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r9
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r9
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r9
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r9
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r9
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r9
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r9
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r9
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r9
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r9
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r9
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r9
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r9
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r9
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r9
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r9
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r11
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r9
                            //revisar
                        }
                        break;
                    case 22:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r10
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s38
                            PilaEstados.Push(38);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if(Lab_ASDR.TokenList[i] == ")")
                        {
                            //r10
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r10
                        }
                        break;
                    case 23:
                        if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s39
                            PilaEstados.Push(39);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 24:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s40
                            PilaEstados.Push(40);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 25:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r12

                        }
                        break;
                    case 26:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r13

                        }
                        break;
                    case 27:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r14

                        }
                        break;
                    case 28:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r15

                        }
                        break;
                    case 29:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r30

                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r30

                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r30
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r30
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r30
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r30
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r30
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r30
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r30
                        }
                        else if (Lab_ASDR.TokenList[i] == "extends")
                        {
                            //s42
                            PilaEstados.Push(42);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "implements")
                        {
                            //r30
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r30
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r30
                            //revisar
                            //
                            ///
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;
                            if (Simbolos.Peek() == "EXTENDS")
                            {
                                PilaEstados.Push(41);
                                i--;
                                //Preguntar al inicio del for si la bandera esta activa 
                                //Analizar otro switch
                            }
                        }
                        break;
                    case 30:

                        if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //s43
                            PilaEstados.Push(43);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 31:

                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r16

                        }
                        break;
                    case 32:

                        if (Lab_ASDR.TokenList[i] == "]")
                        {
                            //s44
                            PilaEstados.Push(44);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);

                        }
                        break;
                    case 33:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r17

                        }
                        break;
                    case 34:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r18

                        }
                        break;
                    case 35:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r19

                        }
                        break;
                    case 36:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r20

                        }
                        break;
                    case 37:
                        if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r7

                        }
                        break;
                    case 38:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s18
                            PilaEstados.Push(18);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //s14
                            PilaEstados.Push(14);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //s15
                            PilaEstados.Push(15);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //s17
                            PilaEstados.Push(17);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //s16
                            PilaEstados.Push(16);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;
                          
                            if (Simbolos.Peek() == "Variable")
                            {
                                PilaEstados.Push(46);
                                i--;

                            }
                            else if (Simbolos.Peek() == "Type")
                            {
                                PilaEstados.Push(47);
                                i--;

                            }
                            else if (Simbolos.Peek() == "Formals")
                            {
                                PilaEstados.Push(45);
                                i--;

                            }
                            
                        }
                        break;
                    case 39:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s18
                            PilaEstados.Push(18);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //s14
                            PilaEstados.Push(14);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //s15
                            PilaEstados.Push(15);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //s16
                            PilaEstados.Push(16);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //s17
                            PilaEstados.Push(17);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Variable")
                            {
                                PilaEstados.Push(46);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Type")
                            {
                                PilaEstados.Push(47);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Formals")
                            {
                                PilaEstados.Push(48);
                                i--;
                            }
                        }
                        break;
                    case 40:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //s49
                            PilaEstados.Push(49);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                            break;
                    case 41:
                        if (Lab_ASDR.TokenList[i] == "implements")
                        {
                            //s51
                            PilaEstados.Push(51);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r32
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "IMPLEMENTS")
                            {
                                PilaEstados.Push(50);
                                i--;
                            }
                        }
                        break;
                    case 42:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s52
                            PilaEstados.Push(52);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 43:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s18
                            PilaEstados.Push(18);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //s14
                            PilaEstados.Push(14);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //s15
                            PilaEstados.Push(15);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //s16
                            PilaEstados.Push(16);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //s17
                            PilaEstados.Push(17);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //s56
                            PilaEstados.Push(56);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r39
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Type")
                            {
                                PilaEstados.Push(55);
                                i--;
                            }
                            else if (Simbolos.Peek() == "InterfaceDecl'")
                            {
                                PilaEstados.Push(53);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Prototype'")
                            {
                                PilaEstados.Push(54);
                                i--;
                            }
                        }
                        break;
                    case 44:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r22

                        }
                        else if (Lab_ASDR.TokenList[i] == "[")
                        {
                            //s32
                            PilaEstados.Push(32);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Type'")
                            {
                                PilaEstados.Push(57);
                                i--;

                            }
                        }
                            break;
                    case 45:
                        if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //s58
                            PilaEstados.Push(58);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 46:
                        if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r27

                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //s60
                            PilaEstados.Push(60);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Formals'")
                            {
                                PilaEstados.Push(59);
                                i--;

                            }
                        }
                        break;
                    case 47:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s61
                            PilaEstados.Push(61);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 48:
                        if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //s62
                            PilaEstados.Push(62);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 49:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r11
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r11

                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r11

                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r11
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r11
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r11
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r11
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r11
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r11
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r11
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r11
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r11
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r11
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r11
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r11
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r11
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r11
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r11
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r11
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r11
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r11
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r11
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r11
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r11
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r11
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r11
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r11
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r11
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r11
                            //revisar
                        }
                        break;
                    case 50:
                        if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //s63
                            PilaEstados.Push(63);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 51:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s64
                            PilaEstados.Push(64);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 52:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r29

                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r29

                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r29
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r29
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r29
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r29
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r11
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r11
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r11
                        }
                        else if (Lab_ASDR.TokenList[i] == "implements")
                        {
                            //r29
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r29
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r29
                            //revisar
                        }
                        break;
                    case 53:
                        if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //s32
                            PilaEstados.Push(32);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 54:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s18
                            PilaEstados.Push(18);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //s14
                            PilaEstados.Push(14);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //s15
                            PilaEstados.Push(15);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //s16
                            PilaEstados.Push(16);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //s17
                            PilaEstados.Push(17);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //s56
                            PilaEstados.Push(56);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r42
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Type")
                            {
                                PilaEstados.Push(55);
                                i--;
                            }
                            else if (Simbolos.Peek() == "InterfaceDecl'")
                            {
                                PilaEstados.Push(66);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Prototype'")
                            {
                                PilaEstados.Push(54);
                                i--;
                            }
                        }
                        break;
                    case 55:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s67
                            PilaEstados.Push(67);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 56:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s68
                            PilaEstados.Push(68);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 57:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r21
                        }
                        break;
                    case 58:
                        if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //s70
                            PilaEstados.Push(70);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "StmtBlock")
                            {
                                PilaEstados.Push(69);
                                i--;
                            }
                        }
                        break;
                    case 59:
                        if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r25
                        }
                        break;
                    case 60:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s18
                            PilaEstados.Push(18);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //s14
                            PilaEstados.Push(14);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //s15
                            PilaEstados.Push(15);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //s16
                            PilaEstados.Push(16);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //s17
                            PilaEstados.Push(17);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Variable")
                            {
                                PilaEstados.Push(46);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Type")
                            {
                                PilaEstados.Push(47);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Formals")
                            {
                                PilaEstados.Push(71);
                                i--;
                            }
                        }
                        break;
                    case 61:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r10
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r10
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r10
                        }
                        break;
                    case 62:
                        if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //s70
                            PilaEstados.Push(70);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "StmtBlock")
                            {
                                PilaEstados.Push(72);
                                i--;
                            }
                        }
                        break;
                    case 63:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s18
                            PilaEstados.Push(18);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //s11
                            PilaEstados.Push(11);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //s14
                            PilaEstados.Push(14);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //s15
                            PilaEstados.Push(15);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //s16
                            PilaEstados.Push(16);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //s17
                            PilaEstados.Push(17);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //s10
                            PilaEstados.Push(10);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r39
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "VariableDecl")
                            {
                                PilaEstados.Push(75);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Variable")
                            {
                                PilaEstados.Push(8);
                                i--;
                            }
                            else if (Simbolos.Peek() == "ConstDecl")
                            {
                                PilaEstados.Push(77);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Type")
                            {
                                PilaEstados.Push(9);
                                i--;
                            }
                            else if (Simbolos.Peek() == "FunctionDecl")
                            {
                                PilaEstados.Push(76);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Field")
                            {
                                PilaEstados.Push(74);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Field'")
                            {
                                PilaEstados.Push(73);
                                i--;
                            }
                        }
                        break;
                    case 64:
                        if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //s79
                            PilaEstados.Push(79);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r34
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "IMPLEMENTS'")
                            {
                                PilaEstados.Push(78);
                                i--;
                            }
                        }
                        break;
                    case 65:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r40

                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r40

                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r40
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r40
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r40
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r40
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r40
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r40
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r40
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r40
                            //revisar
                        }
                        break;
                    case 66:
                        if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r41
                            //revisar
                        }
                        break;
                    case 67:
                        if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s80
                            PilaEstados.Push(80);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 68:
                        if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s81
                            PilaEstados.Push(81);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 69:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r23
                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r23
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r23
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r23
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r23
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r23
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r23
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r23
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r23
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r23
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r23
                            //revisar
                        }
                        break;
                    case 70:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r47
                        }
                        /*CONFLICTO #1
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s18
                            PilaEstados.Push(18);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r47
                        }*/
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r47
                        }
                        /*CONFLICTO #2
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //s14
                            PilaEstados.Push(14);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r47
                        }*/
                        /*CONFLICTO #3
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //s15
                            PilaEstados.Push(15);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r47
                        }*/
                        /*CONFLICTO #4
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //s16
                            PilaEstados.Push(16);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r47
                        }*/
                        /*CONFLICTO #5
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //s17
                            PilaEstados.Push(17);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r47
                        }*/
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r47
                            //revisar
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "VariableDecl")
                            {
                                PilaEstados.Push(83);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Variable")
                            {
                                PilaEstados.Push(8);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Type")
                            {
                                PilaEstados.Push(47);
                                i--;
                            }
                            else if (Simbolos.Peek() == "LlamarVar")
                            {
                                PilaEstados.Push(82);
                                i--;
                            }
                        }
                        break;
                    case 71:
                        if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r26
                        }
                        break;
                    case 72:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r24
                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r24
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r24
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r24
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r24
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r24
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r24
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r24
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r24
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r24
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r24
                            //revisar
                        }
                        break;
                    case 73:
                        if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //s84
                            PilaEstados.Push(84);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 74:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s18
                            PilaEstados.Push(18);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //s11
                            PilaEstados.Push(11);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //s14
                            PilaEstados.Push(14);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //s15
                            PilaEstados.Push(15);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //s16
                            PilaEstados.Push(16);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //s17
                            PilaEstados.Push(17);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //s10
                            PilaEstados.Push(10);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r39
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "VariableDecl")
                            {
                                PilaEstados.Push(75);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Variable")
                            {
                                PilaEstados.Push(8);
                                i--;
                            }
                            else if (Simbolos.Peek() == "ConstDecl")
                            {
                                PilaEstados.Push(77);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Type")
                            {
                                PilaEstados.Push(9);
                                i--;
                            }
                            else if (Simbolos.Peek() == "FunctionDecl")
                            {
                                PilaEstados.Push(76);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Field")
                            {
                                PilaEstados.Push(74);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Field'")
                            {
                                PilaEstados.Push(85);
                                i--;
                            }
                        }
                        break;
                    case 75:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r35
                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r35
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r35
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r35
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r35
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r35
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r35
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r35
                        }
                        break;
                    case 76:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r36
                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r36
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r36
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r36
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r36
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r36
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r36
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r36
                        }
                        break;
                    case 77:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r37
                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r37
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r37
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r37
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r37
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r37
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r37
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r37
                        }
                        break;
                    case 78:
                        if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r31
                        }
                        break;
                    case 79:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s86
                            PilaEstados.Push(86);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 80:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s18
                            PilaEstados.Push(18);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //s14
                            PilaEstados.Push(14);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //s15
                            PilaEstados.Push(15);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //s16
                            PilaEstados.Push(16);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //s17
                            PilaEstados.Push(17);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Variables")
                            {
                                PilaEstados.Push(46);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Type")
                            {
                                PilaEstados.Push(47);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Formals")
                            {
                                PilaEstados.Push(87);
                                i--;
                            }
                        }
                        break;
                    case 81:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s18
                            PilaEstados.Push(18);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //s14
                            PilaEstados.Push(14);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //s15
                            PilaEstados.Push(15);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //s16
                            PilaEstados.Push(16);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //s17
                            PilaEstados.Push(17);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Variables")
                            {
                                PilaEstados.Push(46);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Type")
                            {
                                PilaEstados.Push(47);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Formals")
                            {
                                PilaEstados.Push(88);
                                i--;
                            }
                        }
                        break;
                    case 82:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r49
                        }
                        /*CONFLICTO
                        else if (Lab_ASDR.TokenList[i] == "stacic")
                        {
                            //s11
                            PilaEstados.Push(11);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r49
                        }*/
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r49
                        }
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "ConstDecl")
                            {
                                PilaEstados.Push(90);
                                i--;
                            }
                            else if (Simbolos.Peek() == "LlamarConst")
                            {
                                PilaEstados.Push(89);
                                i--;
                            }
                        }
                        break;
                    case 83:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r47
                        }
                        /*CONFLICTO
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s18
                            PilaEstados.Push(18);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r47
                        }*/
                        /*CONFLICTO
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //s14
                            PilaEstados.Push(14);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r47
                        }*/
                        /*CONFLICTO
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //s15
                            PilaEstados.Push(15);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r47
                        }*/
                        /*CONFLICTO
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //s16
                            PilaEstados.Push(16);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r47
                        }*/
                        /*CONFLICTO
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //s17
                            PilaEstados.Push(47);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r47
                        }*/
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r47
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r47
                        }
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "VariableDecl")
                            {
                                PilaEstados.Push(83);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Variable")
                            {
                                PilaEstados.Push(8);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Type")
                            {
                                PilaEstados.Push(47);
                                i--;
                            }
                            else if (Simbolos.Peek() == "LlamarVar")
                            {
                                PilaEstados.Push(91);
                                i--;
                            }
                        }
                        break;
                    case 84:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r28

                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r28

                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r28
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r28
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r28
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r28
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r28
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r28
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r28
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r28
                        }
                        break;
                    case 85:
                        if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r38
                        }
                        break;
                    case 86:
                        if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //s79
                            PilaEstados.Push(79);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r34
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "IMPLEMENTS'")
                            {
                                PilaEstados.Push(92);
                                i--;
                            }
                        }
                        break;
                    case 87:
                        if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //s93
                            PilaEstados.Push(93);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 88:
                        if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //s94
                            PilaEstados.Push(94);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 89:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r61
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s120
                            PilaEstados.Push(120);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //s70
                            PilaEstados.Push(70);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r51
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //s106
                            PilaEstados.Push(106);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //s107
                            PilaEstados.Push(107);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //s108
                            PilaEstados.Push(108);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //s110
                            PilaEstados.Push(110);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //s109
                            PilaEstados.Push(109);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //s111
                            PilaEstados.Push(111);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s118
                            PilaEstados.Push(118);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //s128
                            PilaEstados.Push(128);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //s129
                            PilaEstados.Push(129);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //s122
                            PilaEstados.Push(122);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "StmtBlock")
                            {
                                PilaEstados.Push(104);
                                i--;
                            }
                            else if (Simbolos.Peek() == "LlamarStmt")
                            {
                                PilaEstados.Push(95);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Stmt")
                            {
                                PilaEstados.Push(96);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Stmt'")
                            {
                                PilaEstados.Push(97);
                                i--;
                            }
                            else if (Simbolos.Peek() == "ifStmt")
                            {
                                PilaEstados.Push(98);
                                i--;
                            }
                            else if (Simbolos.Peek() == "WhileStmt")
                            {
                                PilaEstados.Push(99);
                                i--;
                            }
                            else if (Simbolos.Peek() == "ForStmt")
                            {
                                PilaEstados.Push(100);
                                i--;
                            }
                            else if (Simbolos.Peek() == "ReturnStmt")
                            {
                                PilaEstados.Push(102);
                                i--;
                            }
                            else if (Simbolos.Peek() == "BreakStmt")
                            {
                                PilaEstados.Push(101);
                                i--;
                            }
                            else if (Simbolos.Peek() == "PrintStmt")
                            {
                                PilaEstados.Push(103);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(121);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Expr")
                            {
                                PilaEstados.Push(105);
                                i--;
                            }
                            else if (Simbolos.Peek() == "A")
                            {
                                PilaEstados.Push(112);
                                i--;
                            }
                            else if (Simbolos.Peek() == "B")
                            {
                                PilaEstados.Push(113);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(114);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(119);
                                i--;
                            }
                        }
                        break;
                    case 90:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r49
                        }
                        /*CONFLICTO
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //s11
                            PilaEstados.Push(11);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r49
                        }*/
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r49
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r49
                            //revisar
                        }
                        break;
                    case 91:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r46
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r46
                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r46
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r46
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r46
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r46
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r46
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r46
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r46
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r46
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r46
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r46
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r46
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r46
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r46
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r46
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r46
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r46
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r46
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r46
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r46
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r46
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r46
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r46
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r46
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r46
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r46
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r46
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r46
                            //revisar
                        }
                        break;
                    case 92:
                        if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r33
                        }
                        break;
                    case 93:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //s131
                            PilaEstados.Push(131);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 94:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //s132
                            PilaEstados.Push(132);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 95:
                        if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //s133
                            PilaEstados.Push(133);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 96:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r61
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s120
                            PilaEstados.Push(120);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //s70
                            PilaEstados.Push(70);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r51
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //s106
                            PilaEstados.Push(106);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //s107
                            PilaEstados.Push(107);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //s108
                            PilaEstados.Push(108);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //s110
                            PilaEstados.Push(110);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //s109
                            PilaEstados.Push(109);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //s111
                            PilaEstados.Push(111);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s118
                            PilaEstados.Push(118);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //s128
                            PilaEstados.Push(128);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //s129
                            PilaEstados.Push(129);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //s122
                            PilaEstados.Push(122);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "StmtBlock")
                            {
                                PilaEstados.Push(104);
                                i--;
                            }
                            else if (Simbolos.Peek() == "LlamarStmt")
                            {
                                PilaEstados.Push(134);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Stmt")
                            {
                                PilaEstados.Push(96);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Stmt'")
                            {
                                PilaEstados.Push(97);
                                i--;
                            }
                            else if (Simbolos.Peek() == "ifStmt")
                            {
                                PilaEstados.Push(98);
                                i--;
                            }
                            else if (Simbolos.Peek() == "WhileStmt")
                            {
                                PilaEstados.Push(99);
                                i--;
                            }
                            else if (Simbolos.Peek() == "ForStmt")
                            {
                                PilaEstados.Push(100);
                                i--;
                            }
                            else if (Simbolos.Peek() == "ReturnStmt")
                            {
                                PilaEstados.Push(102);
                                i--;
                            }
                            else if (Simbolos.Peek() == "BreakStmt")
                            {
                                PilaEstados.Push(101);
                                i--;
                            }
                            else if (Simbolos.Peek() == "PrintStmt")
                            {
                                PilaEstados.Push(103);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(121);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Expr")
                            {
                                PilaEstados.Push(105);
                                i--;
                            }
                            else if (Simbolos.Peek() == "A")
                            {
                                PilaEstados.Push(112);
                                i--;
                            }
                            else if (Simbolos.Peek() == "B")
                            {
                                PilaEstados.Push(113);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(114);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(119);
                                i--;
                            }
                        }

                        break;
                    case 97:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //s135
                            PilaEstados.Push(135);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 98:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r53
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_id")
                        {
                            //r53
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r53
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r53
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r53
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r53
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r53
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r53
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r53
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r53
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r53
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r53
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r53
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r53
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r53
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r53
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r53
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r53
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r53
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r53
                        }
                        break;
                    case 99:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r54
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_id")
                        {
                            //r54
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r54
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r54
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r54
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r54
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r54
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r54
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r54
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r54
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r54
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r54
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r54
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r54
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r54
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r54
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r54
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r54
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r54
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r54
                        }
                        break;
                    case 100:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r55
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_id")
                        {
                            //r55
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r55
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r55
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r55
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r55
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r55
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r55
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r55
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r55
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r55
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r55
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r55
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r55
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r55
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r55
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r55
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r55
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r55
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r55
                        }
                        break;
                    case 101:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r56
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_id")
                        {
                            //r56
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r56
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r56
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r56
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r56
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r56
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r56
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r56
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r56
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r56
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r56
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r56
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r56
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r56
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r56
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r56
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r56
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r56
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r56
                        }
                        break;
                    case 102:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r57
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_id")
                        {
                            //r57
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r57
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r57
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r57
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r57
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r57
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r57
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r57
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r57
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r57
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r57
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r57
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r57
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r57
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r57
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r57
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r57
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r57
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r57
                        }
                        break;
                    case 103:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r58
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_id")
                        {
                            //r58
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r58
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r58
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r58
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r58
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r58
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r58
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r58
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r58
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r58
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r58
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r58
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r58
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r58
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r58
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r58
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r58
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r58
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r58
                        }
                        break;
                    case 104:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r59
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_id")
                        {
                            //r59
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r59
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r59
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r59
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r59
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r59
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r59
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r59
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r59
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r59
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r59
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r59
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r59
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r59
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r59
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r59
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r59
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r59
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r59
                        }
                        break;
                    case 105:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r60
                        }
                        break;
                    case 106:
                        if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s136
                            PilaEstados.Push(136);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        
                        break;
                    case 107:
                        if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s137
                            PilaEstados.Push(137);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 108:
                        if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s138
                            PilaEstados.Push(138);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 109:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //s139
                            PilaEstados.Push(139);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 110:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s120
                            PilaEstados.Push(120);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s118
                            PilaEstados.Push(118);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //s128
                            PilaEstados.Push(128);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //s129
                            PilaEstados.Push(129);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //s122
                            PilaEstados.Push(122);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(121);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Expr")
                            {
                                PilaEstados.Push(140);
                                i--;
                            }
                            else if (Simbolos.Peek() == "A")
                            {
                                PilaEstados.Push(112);
                                i--;
                            }
                            else if (Simbolos.Peek() == "B")
                            {
                                PilaEstados.Push(113);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(114);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(119);
                                i--;
                            }
                        }
                        break;
                    case 111:
                        if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s141
                            PilaEstados.Push(141);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 112:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r79
                        }
                        /*CONFLICTO
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //s143
                            PilaEstados.Push(143);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r79
                        }*/
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r79

                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r79
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Expr'")
                            {
                                PilaEstados.Push(142);
                                i--;
                            }
                        }
                        break;
                    case 113:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r82

                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r82
                        }
                        /*CONFLICTO
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //s145
                            PilaEstados.Push(145);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r82
                        }*/
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r82

                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r82
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "A'")
                            {
                                PilaEstados.Push(144);
                                i--;
                            }
                        }
                        break;
                    case 114:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r86
                        }
                        /*CONFLICTO
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //s147
                            PilaEstados.Push(147);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r86
                        }*/
                        /*CONFLICTO
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //s148
                            PilaEstados.Push(148);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r86
                        }*/
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r86

                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r86
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "B'")
                            {
                                PilaEstados.Push(146);
                                i--;
                            }
                        }
                        break;
                    case 115:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r89
                        }
                        /*CONFLICTO
                         else if (Lab_ASDR.TokenList[i] == "-")
                         {
                             //s150
                             PilaEstados.Push(150);
                             Simbolos.Push(Lab_ASDR.TokenList[i]);
                         }
                         else if (Lab_ASDR.TokenList[i] == "-")
                         {
                             // r89
                         }*/
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r89

                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r89
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "C'")
                            {
                                PilaEstados.Push(149);
                                i--;
                            }
                        }
                        break;
                    case 116:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r93
                        }
                        /*CONFLICTO
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //s152
                            PilaEstados.Push(152);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r93
                        }*/
                        /*CONFLICTO
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //s153
                            PilaEstados.Push(153);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r93
                        }*/
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r93

                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r93
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "D'")
                            {
                                PilaEstados.Push(151);
                                i--;
                            }
                        }
                        break;

                    case 117:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r97
                        }
                      
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                           //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r97
                        }
                        /*CONFLICTO
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //s155
                            PilaEstados.Push(155);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r97
                        }*/
                        /*CONFLICTO
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //s156
                            PilaEstados.Push(156);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r97
                        }*/
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r97

                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r97
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "E'")
                            {
                                PilaEstados.Push(154);
                                i--;
                            }
                        }
                        break;
                    case 118:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s157
                            PilaEstados.Push(157);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }

                        break;
                    case 119:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r99
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r99
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r99
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r99
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r99
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r99
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r99
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r99
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r99
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r99
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r99
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r99
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r99
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r99
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r99
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r99
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r99
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r99
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r99
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r99
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r99
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r99
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r99
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r99
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r99
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r99
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r99
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r99

                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r99
                        }

                        break;
                    case 120:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s120
                            PilaEstados.Push(120);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s118
                            PilaEstados.Push(118);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //s128
                            PilaEstados.Push(128);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //s129
                            PilaEstados.Push(129);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //s122
                            PilaEstados.Push(122);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(121);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Expr")
                            {
                                PilaEstados.Push(158);
                                i--;
                            }
                            else if (Simbolos.Peek() == "A")
                            {
                                PilaEstados.Push(112);
                                i--;
                            }
                            else if (Simbolos.Peek() == "B")
                            {
                                PilaEstados.Push(113);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(114);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(119);
                                i--;
                            }
                        }
                        break;
                    case 121:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r101
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r101
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r101
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r101
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r101
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r101
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r101
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r101
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r101
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r101
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r101
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r101
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r101
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r101
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r101
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r101
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r101
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r101
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r101
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r101
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r101
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r101
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r101
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r101
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r101
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r101
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r101
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r101

                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r101
                        }
                        break;
                    case 122:
                        if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s159
                            PilaEstados.Push(159);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 123:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r103
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r103
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r103
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r103
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r103
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r103
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r103
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r103
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r103
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r103
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r103
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r103
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r103
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r103
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r103
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r103
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r103
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r103
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r103
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r103
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r103
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r103
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r103
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r103
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r103
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r103
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r103
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r103

                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r103
                        }
                        break;
                    case 124:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r106

                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "=")
                        {
                            //s161
                            PilaEstados.Push(161);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "X'")
                            {
                                PilaEstados.Push(160);
                                i--;
                            }
                        }
                        break;
                    case 125:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r72
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r72
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r72
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r72
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r72
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r72
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r72
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r72
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r72
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r72
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r72
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r72
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r72
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r72
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r72
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r72
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r72
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r72
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r72
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r72
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r72
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r72
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r72
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r72
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r72
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r72
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r72
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r72

                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r72
                        }
                        break;
                    case 126:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r73
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r73
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r73
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r73
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r73
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r73
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r73
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r73
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r73
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r73
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r73
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r73
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r73
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r73
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r73
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r73
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r73
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r73
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r73
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r73
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r73
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r73
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r73
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r73
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r73
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r73
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r73
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r73
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r73
                        }
                        break;
                    case 127:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r74
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r74
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r74
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r74
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r74
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r74
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r74
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r74
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r74
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r74
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r74
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r74
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r74
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r74
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r74
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r74
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r74
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r74
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r74
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r74
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r74
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r74
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r74
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r74
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r74
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r74
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r74
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r74
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r74
                        }
                        break;
                    case 128:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r75
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r75
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r75
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r75
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r75
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r75
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r75
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r75
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r75
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r75
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r75
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r75
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r75
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r75
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r75
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r75
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r75
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r75
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r75
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r75
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r75
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r75
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r75
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r75
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r75
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r75
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r75
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r75
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r75
                        }
                        break;
                    case 129:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r76
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r76
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r76
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r76
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r76
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r76
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r76
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r76
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r76
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r76
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r76
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r76
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r76
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r76
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r76
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r76
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r76
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r76
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r76
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r76
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r76
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r76
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r76
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r76
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r76
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r76
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r76
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r76
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r76
                        }
                        break;
                    case 130:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r48
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r48
                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r48
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r48
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r48
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r48
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r48
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r48
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r48
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r48
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r48
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r48
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r48
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r48
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r48
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r48
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r48
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r48
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r48
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r48
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r48
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r48
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r48
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r48
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r48
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r48
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r48
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r48
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r48
                        }
                        break;
                    case 131:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r43
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r43
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r43
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r43
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r43
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r43
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r43
                        }
                        break;
                    case 132:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r44
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r44
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r44
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r44
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r44
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r44
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r44
                        }
                        break;
                    case 133:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r45
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r45
                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r45
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r45
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r45
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r45
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r45
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r45
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r45
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r45
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r45
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r45
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r45
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r45
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r45
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r45
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r45
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r45
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r45
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r45
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r45
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r45
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r45
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r45
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r45
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r4
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r45
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r45
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r45
                        }
                        break;
                    case 134:
                        if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r50
                        }
                        break;
                    case 135:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r52
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r52
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r52
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r52
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r52
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r52
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r52
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r52
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r52
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r52
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r52
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r52
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r52
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r52
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r52
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r52
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r52
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r52
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r52
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r52
                        }
                        break;
                    case 136:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s120
                            PilaEstados.Push(120);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s118
                            PilaEstados.Push(118);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //s128
                            PilaEstados.Push(128);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //s129
                            PilaEstados.Push(129);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //s122
                            PilaEstados.Push(122);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(21);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Expr")
                            {
                                PilaEstados.Push(162);
                                i--;
                            }
                            else if (Simbolos.Peek() == "A")
                            {
                                PilaEstados.Push(112);
                                i--;
                            }
                            else if (Simbolos.Peek() == "B")
                            {
                                PilaEstados.Push(113);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(114);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(119);
                                i--;
                            }
                        }
                        break;
                    case 137:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s120
                            PilaEstados.Push(120);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s118
                            PilaEstados.Push(118);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //s128
                            PilaEstados.Push(128);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //s129
                            PilaEstados.Push(129);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //s122
                            PilaEstados.Push(122);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(21);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Expr")
                            {
                                PilaEstados.Push(163);
                                i--;
                            }
                            else if (Simbolos.Peek() == "A")
                            {
                                PilaEstados.Push(112);
                                i--;
                            }
                            else if (Simbolos.Peek() == "B")
                            {
                                PilaEstados.Push(113);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(114);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(119);
                                i--;
                            }
                        }
                        break;
                    case 138:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s120
                            PilaEstados.Push(120);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s118
                            PilaEstados.Push(118);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //s128
                            PilaEstados.Push(128);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //s129
                            PilaEstados.Push(129);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //s122
                            PilaEstados.Push(122);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(21);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Expr")
                            {
                                PilaEstados.Push(164);
                                i--;
                            }
                            else if (Simbolos.Peek() == "A")
                            {
                                PilaEstados.Push(112);
                                i--;
                            }
                            else if (Simbolos.Peek() == "B")
                            {
                                PilaEstados.Push(113);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(114);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(119);
                                i--;
                            }
                        }
                        break;
                    case 139:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r68
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r68
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r68
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r68
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r68
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r68
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r68
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r68
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r68
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r68
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r68
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r68
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r68
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r68
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r68
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r68
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r68
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r68
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r68
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r68
                        }
                        break;
                    case 140:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //s165
                            PilaEstados.Push(165);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 141:
                        if (Lab_ASDR.TokenList[i] == "out")
                        {
                            //s166
                            PilaEstados.Push(166);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 142:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r77
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r77
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r77
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r77
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r77
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r77
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r77
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r77
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r77
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r77
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r77
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r77
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r77
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r77
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r77
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r77
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r77
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r77
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r77
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r77
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r77
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r77
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r77
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r77
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r77
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r77
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r77
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r77
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r77
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r77
                        }
                        break;
                    case 143:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s120
                            PilaEstados.Push(120);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s118
                            PilaEstados.Push(118);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //s128
                            PilaEstados.Push(128);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //s129
                            PilaEstados.Push(129);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //s122
                            PilaEstados.Push(122);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(21);
                                i--;
                            }
                            else if (Simbolos.Peek() == "A")
                            {
                                PilaEstados.Push(167);
                                i--;
                            }
                            else if (Simbolos.Peek() == "B")
                            {
                                PilaEstados.Push(113);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(114);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(119);
                                i--;
                            }
                        }
                        break;
                    case 144:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r80
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r80
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r80
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r80
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r80
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r80
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r80
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r80
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r80
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r80
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r80
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r80
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r80
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r80
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r80
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r80
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r80
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r80
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r80
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r80
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r80
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r80
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r80
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r80
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r80
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r80
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r80
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r80
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r80
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r80
                        }
                        break;
                    case 145:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s120
                            PilaEstados.Push(120);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s118
                            PilaEstados.Push(118);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //s128
                            PilaEstados.Push(128);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //s129
                            PilaEstados.Push(129);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //s122
                            PilaEstados.Push(122);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(21);
                                i--;
                            }
                            else if (Simbolos.Peek() == "A")
                            {
                                PilaEstados.Push(167);
                                i--;
                            }
                            else if (Simbolos.Peek() == "B")
                            {
                                PilaEstados.Push(113);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(114);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(119);
                                i--;
                            }
                        }
                        break;
                    case 146:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r83
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r83
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r83
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r83
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r83
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r83
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r83
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r83
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r83
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r83
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r83
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r83
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r83
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r83
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r83
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r83
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r83
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r83
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r83
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r83
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r83
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r83
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r83
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r83
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r83
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r83
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r83
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r83
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r83
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r83
                        }
                        break;
                    case 147:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s120
                            PilaEstados.Push(120);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s118
                            PilaEstados.Push(118);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //s128
                            PilaEstados.Push(128);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //s129
                            PilaEstados.Push(129);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //s122
                            PilaEstados.Push(122);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(21);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(169);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(119);
                                i--;
                            }
                        }
                        break;
                    case 148:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s120
                            PilaEstados.Push(120);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s118
                            PilaEstados.Push(118);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //s128
                            PilaEstados.Push(128);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //s129
                            PilaEstados.Push(129);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //s122
                            PilaEstados.Push(122);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(21);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(170);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(119);
                                i--;
                            }
                        }
                        break;
                    case 149:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r87
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r87
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r87
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r87
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r87
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r87
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r87
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r87
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r87
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r87
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r87
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r87
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r87
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r87
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r87
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r87
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r87
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r87
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r87
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r87
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r87
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r87
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r87
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r87
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r87
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r87
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r87
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r87
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r87
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r87
                        }
                        break;
                    case 150:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s120
                            PilaEstados.Push(120);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s118
                            PilaEstados.Push(118);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //s128
                            PilaEstados.Push(128);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //s129
                            PilaEstados.Push(129);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //s122
                            PilaEstados.Push(122);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(21);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(171);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(119);
                                i--;
                            }
                        }
                        break;
                    case 151:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r90
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r90
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r90
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r90
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r90
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r90
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r90
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r90
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r90
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r90
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r90
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r90
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r90
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r90
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r90
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r90
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r90
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r90
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r90
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r90
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r90
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r87
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r90
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r90
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r90
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r90
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r90
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r90
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r90
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r90
                        }
                        break;
                    case 152:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s120
                            PilaEstados.Push(120);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s118
                            PilaEstados.Push(118);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //s128
                            PilaEstados.Push(128);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //s129
                            PilaEstados.Push(129);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //s122
                            PilaEstados.Push(122);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(21);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(172);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(119);
                                i--;
                            }
                        }
                        break;
                    case 153:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s120
                            PilaEstados.Push(120);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s118
                            PilaEstados.Push(118);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //s128
                            PilaEstados.Push(128);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //s129
                            PilaEstados.Push(129);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //s122
                            PilaEstados.Push(122);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(21);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(173);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(119);
                                i--;
                            }
                        }
                        break;
                    case 154:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r94
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r94
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r94
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r94
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r94
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r94
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r94
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r94
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r94
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r94
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r94
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r94
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r94
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r94
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r94
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r94
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r94
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r94
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r94
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r94
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r94
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r94
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r94
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r94
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r94
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r94
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r94
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r94
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r94
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r94
                        }
                        break;
                    case 155:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s120
                            PilaEstados.Push(120);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s118
                            PilaEstados.Push(118);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //s128
                            PilaEstados.Push(128);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //s129
                            PilaEstados.Push(129);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //s122
                            PilaEstados.Push(122);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(21);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(174);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(119);
                                i--;
                            }
                        }
                        break;
                    case 156:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s120
                            PilaEstados.Push(120);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s118
                            PilaEstados.Push(118);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //s128
                            PilaEstados.Push(128);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //s129
                            PilaEstados.Push(129);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //s122
                            PilaEstados.Push(122);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(21);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(175);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(119);
                                i--;
                            }
                        }
                        break;
                    case 157:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r106
                        }
                        else if (Lab_ASDR.TokenList[i] == "=")
                        {
                            //s161
                            PilaEstados.Push(161);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "X'")
                            {
                                PilaEstados.Push(176);
                                i--;
                            }
                        }
                        break;
                    case 158:
                        if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //s177
                            PilaEstados.Push(177);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 159:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s178
                            PilaEstados.Push(178);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 160:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r104
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r104
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r104
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r104
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r104
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r104
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r104
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r104
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r104
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r104
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r104
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r104
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r104
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r104
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r104
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r104
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r104
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r104
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r104
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r104
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r104
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r104
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r104
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r104
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r104
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r104
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r104
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r104
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r104
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r104
                        }
                        break;
                    case 161:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s120
                            PilaEstados.Push(120);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s118
                            PilaEstados.Push(118);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //s128
                            PilaEstados.Push(128);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //s129
                            PilaEstados.Push(129);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //s122
                            PilaEstados.Push(122);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(21);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Expr")
                            {
                                PilaEstados.Push(179);
                                i--;
                            }
                            else if (Simbolos.Peek() == "A")
                            {
                                PilaEstados.Push(112);
                                i--;
                            }
                            else if (Simbolos.Peek() == "B")
                            {
                                PilaEstados.Push(113);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(114);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(119);
                                i--;
                            }
                        }
                        break;
                    case 162:
                        if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //s180
                            PilaEstados.Push(180);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 163:
                        if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //s181
                            PilaEstados.Push(181);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 164:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //s182
                            PilaEstados.Push(182);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 165:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r67
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r67
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r67
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r67
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r67
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r67
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r67
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r67
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r67
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r67
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r67
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r67
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r67
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r67
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r67
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r67
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r67
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r67
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r67
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r67
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r67
                        }
                        break;
                    case 166:
                        if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s183
                            PilaEstados.Push(183);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 167:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r79
                        }
                        /*CONFLICTO
                         else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //s143
                            PilaEstados.Push(143);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r79
                        }*/
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r79
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r79
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Expr'")
                            {
                                PilaEstados.Push(184);
                                i--;
                            }
                        }
                        break;
                    case 168:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r67
                        }
                        /*CONFLICTO
                         else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //s145
                            PilaEstados.Push(145);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r82
                        }*/
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r82
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "A'")
                            {
                                PilaEstados.Push(185);
                                i--;
                            }
                        }
                        break;
                    case 169:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r86
                        }
                        /*CONFLICTO
                         else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //s147
                            PilaEstados.Push(147);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r86
                        }*/
                        /*CONFLICTO
                         else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //s148
                            PilaEstados.Push(148);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r86
                        }*/
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r86
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "B'")
                            {
                                PilaEstados.Push(186);
                                i--;
                            }
                        }
                        break;
                    case 170:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r86
                        }
                        /*CONFLICTO
                         else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //s147
                            PilaEstados.Push(147);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r86
                        }*/
                        /*CONFLICTO
                         else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //s148
                            PilaEstados.Push(148);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r86
                        }*/
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r86
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "B'")
                            {
                                PilaEstados.Push(187);
                                i--;
                            }
                        }
                        break;
                    case 171:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r89
                        }
                        /*CONFLICTO
                         else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //s150
                            PilaEstados.Push(150);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r89
                        }*/
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r89
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "C'")
                            {
                                PilaEstados.Push(188);
                                i--;
                            }
                        }
                        break;
                    case 172:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r93
                        }
                        /*CONFLICTO
                         else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //s152
                            PilaEstados.Push(152);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r93
                        }*/
                        /*CONFLICTO
                         else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //s153
                            PilaEstados.Push(153);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r93
                        }*/
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r93
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "D'")
                            {
                                PilaEstados.Push(189);
                                i--;
                            }
                        }
                        break;
                    case 173:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r93
                        }
                        /*CONFLICTO
                         else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //s152
                            PilaEstados.Push(152);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r93
                        }*/
                        /*CONFLICTO
                         else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //s153
                            PilaEstados.Push(153);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r93
                        }*/
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r93
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "D'")
                            {
                                PilaEstados.Push(190);
                                i--;
                            }
                        }
                        break;
                    case 174:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r97
                        }
                        /*CONFLICTO
                         else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //s155
                            PilaEstados.Push(155);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r97
                        }*/
                        /*CONFLICTO
                         else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //s156
                            PilaEstados.Push(156);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r97
                        }*/
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r97
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "E'")
                            {
                                PilaEstados.Push(191);
                                i--;
                            }
                        }
                        break;
                    case 175:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r97
                        }
                        /*CONFLICTO
                         else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //s155
                            PilaEstados.Push(155);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r97
                        }*/
                        /*CONFLICTO
                         else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //s156
                            PilaEstados.Push(156);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r97
                        }*/
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r97
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "E'")
                            {
                                PilaEstados.Push(192);
                                i--;
                            }
                        }
                        break;
                    case 176:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r98
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r98
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r98
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r98
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r98
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r98
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r98
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r98
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r98
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r98
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r98
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r98
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r98
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r98
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r98
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r98
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r98
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r98
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r98
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r98
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r98
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r98
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r98
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r98
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r98
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r98
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r98
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r98
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r98
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r98
                        }
                        break;
                    case 177:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r100
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r100
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r100
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r100
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r100
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r100
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r100
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r100
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r100
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r100
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r100
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r100
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r100
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r100
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r100
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r100
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r100
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r100
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r100
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r100
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r100
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r100
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r100
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r100
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r100
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r100
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r100
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r100
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r100
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r100
                        }
                        break;
                    case 178:
                        if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //s193
                            PilaEstados.Push(193);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 179:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r105
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r105
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r105
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r105
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r105
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r105
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r105
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r105
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r105
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r105
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r105
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r105
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r105
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r105
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r105
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r105
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r105
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r105
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r105
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r105
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r105
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r105
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r105
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r105
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r105
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r105
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r105
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r105
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r105
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r105
                        }
                        break;
                    case 180:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r61
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s120
                            PilaEstados.Push(120);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //s70
                            PilaEstados.Push(70);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //s106
                            PilaEstados.Push(106);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //s107
                            PilaEstados.Push(107);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //s108
                            PilaEstados.Push(108);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //s110
                            PilaEstados.Push(110);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //s109
                            PilaEstados.Push(109);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //s111
                            PilaEstados.Push(111);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s118
                            PilaEstados.Push(118);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //s128
                            PilaEstados.Push(128);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //s129
                            PilaEstados.Push(129);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //s122
                            PilaEstados.Push(122);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "StmtBlock")
                            {
                                PilaEstados.Push(104);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Stmt")
                            {
                                PilaEstados.Push(194);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Stmt'")
                            {
                                PilaEstados.Push(97);
                                i--;
                            }
                            else if (Simbolos.Peek() == "ifStmt")
                            {
                                PilaEstados.Push(98);
                                i--;
                            }
                            else if (Simbolos.Peek() == "whileStmt")
                            {
                                PilaEstados.Push(99);
                                i--;
                            }
                            else if (Simbolos.Peek() == "ForStmt")
                            {
                                PilaEstados.Push(100);
                                i--;
                            }
                            else if (Simbolos.Peek() == "ReturnStmt")
                            {
                                PilaEstados.Push(102);
                                i--;
                            }
                            else if (Simbolos.Peek() == "BreakStmt")
                            {
                                PilaEstados.Push(101);
                                i--;
                            }
                            else if (Simbolos.Peek() == "PrintStmt")
                            {
                                PilaEstados.Push(103);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(121);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Expr")
                            {
                                PilaEstados.Push(105);
                                i--;
                            }
                            else if (Simbolos.Peek() == "A")
                            {
                                PilaEstados.Push(112);
                                i--;
                            }
                            else if (Simbolos.Peek() == "B")
                            {
                                PilaEstados.Push(113);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(114);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(119);
                                i--;
                            }
                        }
                        break;
                    case 181:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r61
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s120
                            PilaEstados.Push(120);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //s70
                            PilaEstados.Push(70);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //s106
                            PilaEstados.Push(106);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //s107
                            PilaEstados.Push(107);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //s108
                            PilaEstados.Push(108);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //s110
                            PilaEstados.Push(110);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //s109
                            PilaEstados.Push(109);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //s111
                            PilaEstados.Push(111);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s118
                            PilaEstados.Push(118);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //s128
                            PilaEstados.Push(128);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //s129
                            PilaEstados.Push(129);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //s122
                            PilaEstados.Push(122);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "StmtBlock")
                            {
                                PilaEstados.Push(104);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Stmt")
                            {
                                PilaEstados.Push(195);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Stmt'")
                            {
                                PilaEstados.Push(97);
                                i--;
                            }
                            else if (Simbolos.Peek() == "ifStmt")
                            {
                                PilaEstados.Push(98);
                                i--;
                            }
                            else if (Simbolos.Peek() == "whileStmt")
                            {
                                PilaEstados.Push(99);
                                i--;
                            }
                            else if (Simbolos.Peek() == "ForStmt")
                            {
                                PilaEstados.Push(100);
                                i--;
                            }
                            else if (Simbolos.Peek() == "ReturnStmt")
                            {
                                PilaEstados.Push(102);
                                i--;
                            }
                            else if (Simbolos.Peek() == "BreakStmt")
                            {
                                PilaEstados.Push(101);
                                i--;
                            }
                            else if (Simbolos.Peek() == "PrintStmt")
                            {
                                PilaEstados.Push(103);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(121);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Expr")
                            {
                                PilaEstados.Push(105);
                                i--;
                            }
                            else if (Simbolos.Peek() == "A")
                            {
                                PilaEstados.Push(112);
                                i--;
                            }
                            else if (Simbolos.Peek() == "B")
                            {
                                PilaEstados.Push(113);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(114);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(119);
                                i--;
                            }
                        }
                        break;
                    case 182:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s120
                            PilaEstados.Push(120);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s118
                            PilaEstados.Push(118);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //s128
                            PilaEstados.Push(128);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //s129
                            PilaEstados.Push(129);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //s122
                            PilaEstados.Push(122);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(121);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Expr")
                            {
                                PilaEstados.Push(196);
                                i--;
                            }
                            else if (Simbolos.Peek() == "A")
                            {
                                PilaEstados.Push(112);
                                i--;
                            }
                            else if (Simbolos.Peek() == "B")
                            {
                                PilaEstados.Push(113);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(114);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(119);
                                i--;
                            }
                        }
                        break;
                    case 183:
                        if (Lab_ASDR.TokenList[i] == "println")
                        {
                            //s197
                            PilaEstados.Push(197);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 184:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r78
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r78
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r78
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r78
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r78
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r78
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r78
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r78
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r78
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r78
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r78
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r78
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r78
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r78
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r78
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r78
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r78
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r78
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r78
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r78
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r78
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r78
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r78
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r78
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r78
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r78
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r78
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r78
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r78
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r78
                        }
                        break;
                    case 185:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r81
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r81
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r81
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r81
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r81
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r81
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r81
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r81
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r81
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r81
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r81
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r81
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r81
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r81
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r81
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r81
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r81
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r81
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r81
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r81
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r81
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r81
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r81
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r81
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r81
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r81
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r81
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r81
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r81
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r81
                        }
                        break;
                    case 186:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r84
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r84
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r84
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r84
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r84
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r84
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r84
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r84
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r84
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r84
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r84
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r84
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r84
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r84
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r84
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r84
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r84
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r84
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r84
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r84
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r84
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r84
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r84
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r84
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r84
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r84
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r84
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r84
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r84
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r84
                        }
                        break;
                    case 187:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r85
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r85
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r85
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r85
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r85
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r85
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r85
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r85
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r85
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r85
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r85
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r85
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r85
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r85
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r85
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r85
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r85
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r85
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r85
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r85
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r85
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r85
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r85
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r85
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r85
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r85
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r85
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r85
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r85
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r85
                        }
                        break;
                    case 188:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r88
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r88
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r88
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r88
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r88
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r88
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r88
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r88
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r88
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r88
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r88
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r88
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r88
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r88
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r88
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r88
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r88
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r88
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r88
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r88
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r88
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r88
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r88
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r88
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r88
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r88
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r88
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r88
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r88
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r88
                        }
                        break;
                    case 189:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r91
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r91
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r91
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r91
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r91
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r91
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r91
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r91
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r91
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r91
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r91
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r91
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r91
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r91
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r91
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r91
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r91
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r91
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r91
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r91
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r91
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r91
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r91
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r91
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r91
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r91
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r91
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r91
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r91
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r91
                        }
                        break;
                    case 190:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r92
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r92
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r92
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r92
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r92
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r92
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r92
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r92
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r92
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r92
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r92
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r92
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r92
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r92
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r92
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r92
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r92
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r92
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r92
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r92
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r92
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r92
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r92
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r92
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r92
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r92
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r92
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r92
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r92
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r92
                        }
                        break;
                    case 191:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r95
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r95
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r95
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r95
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r95
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r95
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r95
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r95
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r95
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r95
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r95
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r95
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r95
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r95
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r95
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r95
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r95
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r95
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r95
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r95
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r95
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r95
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r95
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r95
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r95
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r95
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r95
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r95
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r95
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r95
                        }
                        break;
                    case 192:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r96
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r96
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r96
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r96
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r96
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r96
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r96
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r96
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r96
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r96
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r96
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r96
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r96
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r96
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r96
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r96
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r96
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r96
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r96
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r96
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r96
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r96
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r96
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r96
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r96
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r96
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r96
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r96
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r96
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r96
                        }
                        break;
                    case 193:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r102
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r102
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r102
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r102
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r102
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r102
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r102
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r102
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r102
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r102
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r102
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r102
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r102
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r102
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r102
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r102
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r102
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r102
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r102
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r102
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r102
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r102
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r102
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r102
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r102
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r102
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r102
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r102
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r102
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r102
                        }
                        break;
                    case 194:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r64
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r64
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r64
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r64
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r64
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r64
                        }
                        /*if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //s199
                            PilaEstados.Push(199);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r64
                        }*/
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r64
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r64
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r64
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r64
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r64
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r64
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r64
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r64
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r64
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r64
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r64
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r64
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r64
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "ifStmt'")
                            {
                                PilaEstados.Push(198);
                                i--;
                            }
                        }
                        break;
                    case 195:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r65
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r65
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r65
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r65
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r65
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r65
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r65
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r65
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r65
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r65
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r65
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r65
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r65
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r65
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r65
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r65
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r65
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r65
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r65
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r65
                        }
                        break;
                    case 196:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //s200
                            PilaEstados.Push(200);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 197:
                        if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s201
                            PilaEstados.Push(201);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 198:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r62
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r62
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r62
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r62
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r62
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r62
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r62
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r62
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r62
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r62
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r62
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r62
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r62
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r62
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r62
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r62
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r62
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r62
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r62
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r62
                        }
                        break;
                    case 199:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r61
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s120
                            PilaEstados.Push(120);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //s70
                            PilaEstados.Push(70);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //s106
                            PilaEstados.Push(106);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //s107
                            PilaEstados.Push(107);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //s108
                            PilaEstados.Push(108);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //s110
                            PilaEstados.Push(110);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //s109
                            PilaEstados.Push(109);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //s111
                            PilaEstados.Push(111);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s118
                            PilaEstados.Push(118);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //s128
                            PilaEstados.Push(70);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //s129
                            PilaEstados.Push(129);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //s122
                            PilaEstados.Push(122);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "StmtBlock")
                            {
                                PilaEstados.Push(104);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Stmt")
                            {
                                PilaEstados.Push(202);
                                i--;
                            }
                            else if(Simbolos.Peek() == "Stmt'")
                            {
                                PilaEstados.Push(97);
                                i--;
                            }
                            else if(Simbolos.Peek() == "ifStmt")
                            {
                                PilaEstados.Push(98);
                                i--;
                            }
                            else if(Simbolos.Peek() == "WhileStmt")
                            {
                                PilaEstados.Push(99);
                                i--;
                            }
                            else if (Simbolos.Peek() == "ForStmt")
                            {
                                PilaEstados.Push(100);
                                i--;
                            }
                            else if (Simbolos.Peek() == "ReturnStmt")
                            {
                                PilaEstados.Push(102);
                                i--;
                            }
                            else if (Simbolos.Peek() == "BreakStmt")
                            {
                                PilaEstados.Push(101);
                                i--;
                            }
                            else if (Simbolos.Peek() == "PrintStmt")
                            {
                                PilaEstados.Push(103);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(121);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Expr")
                            {
                                PilaEstados.Push(105);
                                i--;
                            }
                            else if (Simbolos.Peek() == "A")
                            {
                                PilaEstados.Push(112);
                                i--;
                            }
                            else if (Simbolos.Peek() == "B")
                            {
                                PilaEstados.Push(113);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(114);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(119);
                                i--;
                            }
                        }
                        break;
                    case 200:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s120
                            PilaEstados.Push(120);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s118
                            PilaEstados.Push(118);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //s128
                            PilaEstados.Push(70);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //s129
                            PilaEstados.Push(129);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //s122
                            PilaEstados.Push(122);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(121);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Expr")
                            {
                                PilaEstados.Push(203);
                                i--;
                            }
                            else if (Simbolos.Peek() == "A")
                            {
                                PilaEstados.Push(112);
                                i--;
                            }
                            else if (Simbolos.Peek() == "B")
                            {
                                PilaEstados.Push(113);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(114);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(119);
                                i--;
                            }
                        }
                        break;
                    case 201:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s120
                            PilaEstados.Push(120);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s118
                            PilaEstados.Push(118);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //s128
                            PilaEstados.Push(70);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //s129
                            PilaEstados.Push(129);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //s122
                            PilaEstados.Push(122);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(121);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Expr")
                            {
                                PilaEstados.Push(204);
                                i--;
                            }
                            else if (Simbolos.Peek() == "A")
                            {
                                PilaEstados.Push(112);
                                i--;
                            }
                            else if (Simbolos.Peek() == "B")
                            {
                                PilaEstados.Push(113);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(114);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(119);
                                i--;
                            }
                        }
                        break;
                    case 202:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r63
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r63
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r63
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r63
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r63
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r63
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r63
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r63
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r63
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r63
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r63
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r63
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r63
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r63
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r63
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r63
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r63
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r63
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r63
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r63
                        }
                        break;
                    case 203:
                        if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //s205
                            PilaEstados.Push(205);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 204:
                        if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r71
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //s207
                            PilaEstados.Push(207);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "PrintStmt'")
                            {
                                PilaEstados.Push(206);
                                i--;
                            }
                        }
                        break;
                    case 205:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r61
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s120
                            PilaEstados.Push(120);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //s70
                            PilaEstados.Push(70);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //s106
                            PilaEstados.Push(106);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //s107
                            PilaEstados.Push(107);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //s108
                            PilaEstados.Push(108);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //s110
                            PilaEstados.Push(110);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //s109
                            PilaEstados.Push(109);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //s111
                            PilaEstados.Push(111);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s118
                            PilaEstados.Push(118);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //s128
                            PilaEstados.Push(70);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //s129
                            PilaEstados.Push(129);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //s122
                            PilaEstados.Push(122);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "StmtBlock")
                            {
                                PilaEstados.Push(104);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Stmt")
                            {
                                PilaEstados.Push(208);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Stmt'")
                            {
                                PilaEstados.Push(97);
                                i--;
                            }
                            else if (Simbolos.Peek() == "ifStmt")
                            {
                                PilaEstados.Push(98);
                                i--;
                            }
                            else if (Simbolos.Peek() == "WhileStmt")
                            {
                                PilaEstados.Push(99);
                                i--;
                            }
                            else if (Simbolos.Peek() == "ForStmt")
                            {
                                PilaEstados.Push(100);
                                i--;
                            }
                            else if (Simbolos.Peek() == "ReturnStmt")
                            {
                                PilaEstados.Push(102);
                                i--;
                            }
                            else if (Simbolos.Peek() == "BreakStmt")
                            {
                                PilaEstados.Push(101);
                                i--;
                            }
                            else if (Simbolos.Peek() == "PrintStmt")
                            {
                                PilaEstados.Push(103);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(121);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Expr")
                            {
                                PilaEstados.Push(105);
                                i--;
                            }
                            else if (Simbolos.Peek() == "A")
                            {
                                PilaEstados.Push(112);
                                i--;
                            }
                            else if (Simbolos.Peek() == "B")
                            {
                                PilaEstados.Push(113);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(114);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(119);
                                i--;
                            }
                        }
                        break;
                    case 206:
                        if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //s209
                            PilaEstados.Push(209);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 207:
                        if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s120
                            PilaEstados.Push(120);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s118
                            PilaEstados.Push(118);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //s128
                            PilaEstados.Push(70);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //s129
                            PilaEstados.Push(129);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //s122
                            PilaEstados.Push(122);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(121);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Expr")
                            {
                                PilaEstados.Push(210);
                                i--;
                            }
                            else if (Simbolos.Peek() == "A")
                            {
                                PilaEstados.Push(112);
                                i--;
                            }
                            else if (Simbolos.Peek() == "B")
                            {
                                PilaEstados.Push(113);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(114);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(119);
                                i--;
                            }
                        }
                        break;
                    case 208:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r66
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r66
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r66
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r66
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r66
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r66
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r66
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r66
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r66
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r66
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r66
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r66
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r66
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r66
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r66
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r66
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r66
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r66
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r66
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r66
                        }
                        break;
                    case 209:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //s211
                            PilaEstados.Push(211);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 210:
                        if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r71
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //s207
                            PilaEstados.Push(207);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "PrintStmt'")
                            {
                                PilaEstados.Push(212);
                                i--;
                            }
                        }
                        break;
                    case 211:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r69
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_Id")
                        {
                            //r69
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r69
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r69
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r69
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r69
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r69
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r69
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r69
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r69
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r69
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r69
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r69
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDecimal")
                        {
                            //r69
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstDouble")
                        {
                            //r69
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_ConstBool")
                        {
                            //r69
                        }
                        else if (Lab_ASDR.TokenList[i] == "T_es_String")
                        {
                            //r69
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r69
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r69
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r69
                        }
                        break;
                    case 212:
                        if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r70
                        }
                        break;

                }
            }            
        }
    }
}
