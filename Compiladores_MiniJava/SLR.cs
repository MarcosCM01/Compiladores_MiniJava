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
                                PilaEstados.Push(114);
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
                            PilaEstados.Push(133);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 97:
                        break;
                    case 98:
                        break;
                    case 99:
                        break;
                    case 100:
                        break;
                }

            }

            
        }

    }
}
