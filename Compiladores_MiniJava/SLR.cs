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
                            //
                            ///
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
                            //revisar
                            //
                            ///
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
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r9
                            //revisar
                            //
                            ///
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
                }

            }

            
        }

    }
}
