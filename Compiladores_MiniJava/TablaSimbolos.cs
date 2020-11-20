using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores_MiniJava
{
    class TablaSimbolos
    {
        public static List<Token> Tokens = new List<Token>();//Tokens ingresados desde el analisis sintactico
        public static List<Entorno> Entornos = new List<Entorno>();
        //if { i++
        //if } i--
        public static void CreacionTabla()
        {
            Entorno inicial = new Entorno();
            int ContadorEntorno = 0;
            inicial.PutID(ContadorEntorno);
            Entornos.Add(inicial);
            for (int i = 0; i < Tokens.Count; i++)
            {
                if (Tokens[i].palabra == "{")
                {
                    Entorno nuevo = new Entorno();
                    ContadorEntorno++;
                    nuevo.PutID(ContadorEntorno);
                    Entornos.Add(nuevo);
                }
                else if (Tokens[i].palabra == "}")
                {
                    ContadorEntorno--;
                }
                else if (Tokens[i].palabra == "void")
                {
                    i++;
                    if (!Entornos[ContadorEntorno].Get(Tokens[i].palabra))
                    {
                        Simbolo temporal = new Simbolo();
                        temporal.tipo = Tokens[i - 1].palabra;
                        string temp = Tokens[i].palabra;
                        for (int j = i; j < Tokens.Count; j++)
                        {
                            if (Tokens[j].palabra == "int")
                            {
                                Simbolo arg = new Simbolo();
                                arg.tipo = Tokens[i].palabra;
                                i++;
                                j++;
                                if (!temporal.Get(Tokens[j].palabra))
                                {
                                    temporal.Put(Tokens[j].palabra, arg);
                                }
                                else
                                {
                                    //Error en void argumento ya declarado
                                }
                            }
                            else if (Tokens[j].palabra == "double")
                            {
                                Simbolo arg = new Simbolo();
                                arg.tipo = Tokens[j].palabra;
                                i++;
                                j++;
                                if (!temporal.Get(Tokens[j].palabra))
                                {
                                    temporal.Put(Tokens[j].palabra, arg);
                                }
                                else
                                {
                                    //Error en void argumento ya declarado
                                }
                            }
                            else if (Tokens[j].palabra == "boolean")
                            {
                                Simbolo arg = new Simbolo();
                                arg.tipo = Tokens[j].palabra;
                                i++;
                                j++;
                                if (!temporal.Get(Tokens[j].palabra))
                                {
                                    temporal.Put(Tokens[j].palabra, arg);
                                }
                                else
                                {
                                    //Error en void argumento ya declarado
                                }
                            }
                            else if (Tokens[i].palabra == "string")
                            {
                                Simbolo arg = new Simbolo();
                                arg.tipo = Tokens[j].palabra;
                                i++;
                                j++;
                                if (!temporal.Get(Tokens[j].palabra))
                                {
                                    temporal.Put(Tokens[j].palabra, arg);
                                }
                                else
                                {
                                    //Error en void argumento ya declarado
                                }
                            }
                            else if (Tokens[i].palabra == ")")
                            {
                                Simbolo arg = new Simbolo();
                                arg.tipo = Tokens[j].palabra;
                                i--;
                                j = Tokens.Count;
                            }
                            i++;
                        }
                        Entornos[ContadorEntorno].Put(temp, temporal);
                    }
                    else
                    {
                        //Error ya se encuentra declarado en el entorno
                    }
                }
                else if (Tokens[i].palabra == "class")
                {
                    i++;
                    if (!Entornos[ContadorEntorno].Get(Tokens[i].palabra))
                    {

                    }
                    else
                    {
                        //Error ya se encuentra declarado en el entorno
                    }
                }
                else if (Tokens[i].palabra == "int")
                {
                    i++;
                    if (!Entornos[ContadorEntorno].Get(Tokens[i].palabra))
                    {
                        Simbolo temporal = new Simbolo();
                        temporal.tipo = Tokens[i - 1].palabra;
                        string temp = Tokens[i].palabra;
                        if (Tokens[i + 1].palabra == ";")
                        {
                            Entornos[ContadorEntorno].Put(temp, temporal);
                        }
                        else if (Tokens[i + 1].palabra == "=")
                        {
                            //OJO
                            i = i + 2;

                            char operador;
                            int valor_temporal = 0;
                            bool Operacion = false;
                            for (int j = i; j < Tokens.Count; j++)
                            {
                                if (Tokens[j].valor.Contains("intConstant"))
                                {
                                    valor_temporal = Convert.ToInt32(Tokens[i].palabra);
                                }
                                else if (Tokens[j].palabra == "+")
                                {
                                    i++;
                                    j++;
                                    if (Tokens[j].valor.Contains("intConstant"))
                                    {
                                        valor_temporal = valor_temporal + Convert.ToInt32(Tokens[j].palabra);
                                    }
                                    else if (Entornos[ContadorEntorno].Get(Tokens[j].palabra) && Entornos[ContadorEntorno].GetValue(Tokens[j].palabra) == "int")
                                    {
                                        Simbolo declarado = Entornos[ContadorEntorno].GetSimbolo(Tokens[j].palabra);
                                        valor_temporal = valor_temporal + declarado.valorInt;
                                    }
                                    else
                                    {
                                        //Tipos diferentes para operar
                                    }
                                }
                                else if (Tokens[j].palabra == "-")
                                {
                                    i++;
                                    j++;
                                    if (Tokens[j].valor.Contains("intConstant"))
                                    {
                                        valor_temporal = valor_temporal - Convert.ToInt32(Tokens[j].palabra);
                                    }
                                    else if (Entornos[ContadorEntorno].Get(Tokens[j].palabra) && Entornos[ContadorEntorno].GetValue(Tokens[j].palabra) == "int")
                                    {
                                        Simbolo declarado = Entornos[ContadorEntorno].GetSimbolo(Tokens[j].palabra);
                                        valor_temporal = valor_temporal - declarado.valorInt;
                                    }
                                    else
                                    {
                                        //Tipos diferentes para operar
                                    }
                                }
                                else if (Tokens[i].palabra == "*")
                                {
                                    i++;
                                    j++;
                                    if (Tokens[j].valor.Contains("intConstant"))
                                    {
                                        valor_temporal = valor_temporal * Convert.ToInt32(Tokens[j].palabra);
                                    }
                                    else if (Entornos[ContadorEntorno].Get(Tokens[j].palabra) && Entornos[ContadorEntorno].GetValue(Tokens[j].palabra) == "int")
                                    {
                                        Simbolo declarado = Entornos[ContadorEntorno].GetSimbolo(Tokens[j].palabra);
                                        valor_temporal = valor_temporal * declarado.valorInt;
                                    }
                                    else
                                    {
                                        //Tipos diferentes para operar
                                    }
                                }
                                else if (Tokens[j].palabra == "/")
                                {
                                    i++;
                                    j++;
                                    if (Tokens[j].valor.Contains("intConstant"))
                                    {
                                        valor_temporal = valor_temporal / Convert.ToInt32(Tokens[j].palabra);
                                    }
                                    else if (Entornos[ContadorEntorno].Get(Tokens[j].palabra) && Entornos[ContadorEntorno].GetValue(Tokens[j].palabra) == "int")
                                    {
                                        Simbolo declarado = Entornos[ContadorEntorno].GetSimbolo(Tokens[j].palabra);
                                        valor_temporal = valor_temporal / declarado.valorInt;
                                    }
                                    else
                                    {
                                        //Tipos diferentes para operar
                                    }
                                }
                                else if (Tokens[j].palabra == "%")
                                {
                                    i++;
                                    j++;
                                    if (Tokens[j].valor.Contains("intConstant"))
                                    {
                                        valor_temporal = valor_temporal % Convert.ToInt32(Tokens[j].palabra);
                                    }
                                    else if (Entornos[ContadorEntorno].Get(Tokens[j].palabra) && Entornos[ContadorEntorno].GetValue(Tokens[j].palabra) == "int")
                                    {
                                        Simbolo declarado = Entornos[ContadorEntorno].GetSimbolo(Tokens[j].palabra);
                                        valor_temporal = valor_temporal % declarado.valorInt;
                                    }
                                    else
                                    {
                                        //Tipos diferentes para operar
                                    }
                                }
                                else if (Tokens[j].palabra == ";")
                                {

                                    break;
                                }
                                else if (!Entornos[ContadorEntorno].Get(Tokens[i].palabra))
                                {
                                    //Error Token no definido en el entorno 
                                }
                                else
                                {
                                    //Error valor no definido
                                }
                                i++;

                            }


                            temporal.valorInt = valor_temporal;
                            Entornos[ContadorEntorno].Put(temp, temporal);
                        }
                        else if (Tokens[i + 1].palabra == "(")
                        {
                            //OJO
                            int valor_temporal = 0;
                            for (int j = i; j < Tokens.Count; j++)
                            {

                            }
                        }
                        else if (Tokens[i + 1].palabra == ".")
                        {
                            //OJO
                            int valor_temporal = 0;
                            for (int j = i; j < Tokens.Count; j++)
                            {

                            }
                        }

                    }
                    else
                    {
                        //Error ya se encuentra declarado
                    }
                }
                else if (Tokens[i].palabra == "double")
                {
                    i++;
                    if (!Entornos[ContadorEntorno].Get(Tokens[i].palabra))
                    {
                        Simbolo temporal = new Simbolo();
                        temporal.tipo = Tokens[i - 1].palabra;
                        string temp = Tokens[i].palabra;
                        if (Tokens[i + 1].palabra == ";")
                        {
                            Entornos[ContadorEntorno].Put(temp, temporal);
                        }
                        else if (Tokens[i + 1].palabra == "=")
                        {
                            //OJO
                            i = i + 2;

                            char operador;
                            double valor_temporal = 0;
                            bool Operacion = false;
                            for (int j = i; j < Tokens.Count; j++)
                            {
                                if (Tokens[j].valor.Contains("intConstant") || Tokens[j].valor.Contains("doubleConstant"))
                                {
                                    valor_temporal = Convert.ToDouble(Tokens[i].palabra);
                                }
                                else if (Tokens[j].palabra == "+")
                                {
                                    i++;
                                    j++;
                                    if (Tokens[j].valor.Contains("intConstant") || Tokens[j].valor.Contains("doubleConstant"))
                                    {
                                        valor_temporal = valor_temporal + Convert.ToDouble(Tokens[j].palabra);
                                    }
                                    else if (Entornos[ContadorEntorno].Get(Tokens[j].palabra) && (Entornos[ContadorEntorno].GetValue(Tokens[j].palabra) == "int"))
                                    {
                                        Simbolo declarado = Entornos[ContadorEntorno].GetSimbolo(Tokens[j].palabra);
                                        valor_temporal = valor_temporal * declarado.valorInt;
                                    }
                                    else if (Entornos[ContadorEntorno].Get(Tokens[j].palabra) && (Entornos[ContadorEntorno].GetValue(Tokens[j].palabra) == "double"))
                                    {
                                        Simbolo declarado = Entornos[ContadorEntorno].GetSimbolo(Tokens[j].palabra);
                                        valor_temporal = valor_temporal * declarado.valorDouble;
                                    }
                                    else
                                    {
                                        //Tipos diferentes para operar
                                    }
                                }
                                else if (Tokens[j].palabra == "-")
                                {
                                    i++;
                                    j++;
                                    if (Tokens[j].valor.Contains("intConstant") || Tokens[j].valor.Contains("doubleConstant"))
                                    {
                                        valor_temporal = valor_temporal - Convert.ToDouble(Tokens[j].palabra);
                                    }
                                    else if (Entornos[ContadorEntorno].Get(Tokens[j].palabra) && (Entornos[ContadorEntorno].GetValue(Tokens[j].palabra) == "int"))
                                    {
                                        Simbolo declarado = Entornos[ContadorEntorno].GetSimbolo(Tokens[j].palabra);
                                        valor_temporal = valor_temporal * declarado.valorInt;
                                    }
                                    else if (Entornos[ContadorEntorno].Get(Tokens[j].palabra) && (Entornos[ContadorEntorno].GetValue(Tokens[j].palabra) == "double"))
                                    {
                                        Simbolo declarado = Entornos[ContadorEntorno].GetSimbolo(Tokens[j].palabra);
                                        valor_temporal = valor_temporal * declarado.valorDouble;
                                    }
                                    else
                                    {
                                        //Tipos diferentes para operar
                                    }
                                }
                                else if (Tokens[i].palabra == "*")
                                {
                                    i++;
                                    j++;
                                    if (Tokens[j].valor.Contains("intConstant") || Tokens[j].valor.Contains("doubleConstant"))
                                    {
                                        valor_temporal = valor_temporal * Convert.ToDouble(Tokens[j].palabra);
                                    }
                                    else if (Entornos[ContadorEntorno].Get(Tokens[j].palabra) && (Entornos[ContadorEntorno].GetValue(Tokens[j].palabra) == "int"))
                                    {
                                        Simbolo declarado = Entornos[ContadorEntorno].GetSimbolo(Tokens[j].palabra);
                                        valor_temporal = valor_temporal * declarado.valorInt;
                                    }
                                    else if (Entornos[ContadorEntorno].Get(Tokens[j].palabra) && (Entornos[ContadorEntorno].GetValue(Tokens[j].palabra) == "double"))
                                    {
                                        Simbolo declarado = Entornos[ContadorEntorno].GetSimbolo(Tokens[j].palabra);
                                        valor_temporal = valor_temporal * declarado.valorDouble;
                                    }
                                    else
                                    {
                                        //Tipos diferentes para operar
                                    }
                                }
                                else if (Tokens[j].palabra == "/")
                                {
                                    i++;
                                    j++;
                                    if (Tokens[j].valor.Contains("intConstant") || Tokens[j].valor.Contains("doubleConstant"))
                                    {
                                        valor_temporal = valor_temporal / Convert.ToDouble(Tokens[j].palabra);
                                    }
                                    else if (Entornos[ContadorEntorno].Get(Tokens[j].palabra) && (Entornos[ContadorEntorno].GetValue(Tokens[j].palabra) == "int" || Entornos[ContadorEntorno].GetValue(Tokens[j].palabra) == "double"))
                                    {
                                        Simbolo declarado = Entornos[ContadorEntorno].GetSimbolo(Tokens[j].palabra);
                                        valor_temporal = valor_temporal / declarado.valorDouble;
                                    }
                                    else
                                    {
                                        //Tipos diferentes para operar
                                    }
                                }
                                else if (Tokens[j].palabra == "%")
                                {
                                    i++;
                                    j++;
                                    if (Tokens[j].valor.Contains("intConstant") || Tokens[j].valor.Contains("doubleConstant"))
                                    {
                                        valor_temporal = valor_temporal % Convert.ToDouble(Tokens[j].palabra);
                                    }
                                    else if (Entornos[ContadorEntorno].Get(Tokens[j].palabra) && (Entornos[ContadorEntorno].GetValue(Tokens[j].palabra) == "int"))
                                    {
                                        Simbolo declarado = Entornos[ContadorEntorno].GetSimbolo(Tokens[j].palabra);
                                        valor_temporal = valor_temporal * declarado.valorInt;
                                    }
                                    else if (Entornos[ContadorEntorno].Get(Tokens[j].palabra) && (Entornos[ContadorEntorno].GetValue(Tokens[j].palabra) == "double"))
                                    {
                                        Simbolo declarado = Entornos[ContadorEntorno].GetSimbolo(Tokens[j].palabra);
                                        valor_temporal = valor_temporal * declarado.valorDouble;
                                    }
                                    else
                                    {
                                        //Tipos diferentes para operar
                                    }
                                }
                                else if (Tokens[j].palabra == ";")
                                {

                                    break;
                                }
                                else if (!Entornos[ContadorEntorno].Get(Tokens[i].palabra))
                                {
                                    //Error Token no definido en el entorno 
                                }
                                else
                                {
                                    //Error valor no definido
                                }
                                i++;

                            }


                            temporal.valorDouble = valor_temporal;
                            Entornos[ContadorEntorno].Put(temp, temporal);
                        }
                    }
                }
                else if (Entornos[ContadorEntorno].Get(Tokens[i].palabra))
                {
                    string aux = Tokens[i].palabra;
                    Simbolo actual = Entornos[ContadorEntorno].GetSimbolo(Tokens[i].palabra);
                    Simbolo temporal = new Simbolo();
                    if (actual.tipo == "int")
                    {
                        if (Tokens[i + 1].palabra == "=")
                        {
                            //OJO
                            i = i + 2;

                            char operador;
                            int valor_temporal = 0;
                            bool Operacion = false;
                            for (int j = i; j < Tokens.Count; j++)
                            {
                                if (Tokens[j].valor.Contains("intConstant"))
                                {
                                    valor_temporal = Convert.ToInt32(Tokens[i].palabra);
                                }
                                else if (Entornos[ContadorEntorno].Get(Tokens[j].palabra))
                                {
                                    if (Entornos[ContadorEntorno].GetValue(Tokens[j].palabra) == "int")
                                    {
                                        Simbolo declarado = Entornos[ContadorEntorno].GetSimbolo(Tokens[j].palabra);
                                        valor_temporal = declarado.valorInt;
                                    }
                                }
                                else if (Tokens[j].palabra == "+")
                                {
                                    i++;
                                    j++;
                                    if (Tokens[j].valor.Contains("intConstant"))
                                    {
                                        valor_temporal = valor_temporal + Convert.ToInt32(Tokens[j].palabra);
                                    }
                                    else if (Entornos[ContadorEntorno].Get(Tokens[j].palabra) && Entornos[ContadorEntorno].GetValue(Tokens[j].palabra) == "int")
                                    {
                                        Simbolo declarado = Entornos[ContadorEntorno].GetSimbolo(Tokens[j].palabra);
                                        valor_temporal = valor_temporal + declarado.valorInt;
                                    }
                                    else
                                    {
                                        //Tipos diferentes para operar
                                    }
                                }
                                else if (Tokens[j].palabra == "-")
                                {
                                    i++;
                                    j++;
                                    if (Tokens[j].valor.Contains("intConstant"))
                                    {
                                        valor_temporal = valor_temporal - Convert.ToInt32(Tokens[j].palabra);
                                    }
                                    else if (Entornos[ContadorEntorno].Get(Tokens[j].palabra) && Entornos[ContadorEntorno].GetValue(Tokens[j].palabra) == "int")
                                    {
                                        Simbolo declarado = Entornos[ContadorEntorno].GetSimbolo(Tokens[j].palabra);
                                        valor_temporal = valor_temporal - declarado.valorInt;
                                    }
                                    else
                                    {
                                        //Tipos diferentes para operar
                                    }
                                }
                                else if (Tokens[i].palabra == "*")
                                {
                                    i++;
                                    j++;
                                    if (Tokens[j].valor.Contains("intConstant"))
                                    {
                                        valor_temporal = valor_temporal * Convert.ToInt32(Tokens[j].palabra);
                                    }
                                    else if (Entornos[ContadorEntorno].Get(Tokens[j].palabra) && Entornos[ContadorEntorno].GetValue(Tokens[j].palabra) == "int")
                                    {
                                        Simbolo declarado = Entornos[ContadorEntorno].GetSimbolo(Tokens[j].palabra);
                                        valor_temporal = valor_temporal * declarado.valorInt;
                                    }
                                    else
                                    {
                                        //Tipos diferentes para operar
                                    }
                                }
                                else if (Tokens[j].palabra == "/")
                                {
                                    i++;
                                    j++;
                                    if (Tokens[j].valor.Contains("intConstant"))
                                    {
                                        valor_temporal = valor_temporal / Convert.ToInt32(Tokens[j].palabra);
                                    }
                                    else if (Entornos[ContadorEntorno].Get(Tokens[j].palabra) && Entornos[ContadorEntorno].GetValue(Tokens[j].palabra) == "int")
                                    {
                                        Simbolo declarado = Entornos[ContadorEntorno].GetSimbolo(Tokens[j].palabra);
                                        valor_temporal = valor_temporal / declarado.valorInt;
                                    }
                                    else
                                    {
                                        //Tipos diferentes para operar
                                    }
                                }
                                else if (Tokens[j].palabra == "%")
                                {
                                    i++;
                                    j++;
                                    if (Tokens[j].valor.Contains("intConstant"))
                                    {
                                        valor_temporal = valor_temporal % Convert.ToInt32(Tokens[j].palabra);
                                    }
                                    else if (Entornos[ContadorEntorno].Get(Tokens[j].palabra) && Entornos[ContadorEntorno].GetValue(Tokens[j].palabra) == "int")
                                    {
                                        Simbolo declarado = Entornos[ContadorEntorno].GetSimbolo(Tokens[j].palabra);
                                        valor_temporal = valor_temporal % declarado.valorInt;
                                    }
                                    else
                                    {
                                        //Tipos diferentes para operar
                                    }
                                }
                                else if (Tokens[j].palabra == ";")
                                {

                                    break;
                                }
                                else if (!Entornos[ContadorEntorno].Get(Tokens[i].palabra))
                                {
                                    //Error Token no definido en el entorno 
                                }
                                else
                                {
                                    //Error valor no definido
                                }
                                i++;

                            }


                            temporal.valorInt = valor_temporal;
                            temporal.tipo = actual.tipo;
                            Entornos[ContadorEntorno].Insert(aux, temporal);
                        }
                    }
                    else if (actual.tipo == "double")
                    {
                        
                        if (Tokens[i + 1].palabra == "=")
                        {
                            //OJO
                            i = i + 2;

                            char operador;
                            double valor_temporal = 0;
                            bool Operacion = false;
                            for (int j = i; j < Tokens.Count; j++)
                            {
                                if (Tokens[j].valor.Contains("intConstant") || Tokens[j].valor.Contains("doubleConstant"))
                                {
                                    valor_temporal = Convert.ToDouble(Tokens[i].palabra);
                                }
                                else if (Entornos[ContadorEntorno].Get(Tokens[j].palabra))
                                {
                                    if(Entornos[ContadorEntorno].GetValue(Tokens[j].palabra) == "int")
                                    {
                                        Simbolo declarado = Entornos[ContadorEntorno].GetSimbolo(Tokens[j].palabra);
                                        valor_temporal = declarado.valorInt;
                                    }
                                    else if (Entornos[ContadorEntorno].GetValue(Tokens[j].palabra) == "double")
                                    {
                                        Simbolo declarado = Entornos[ContadorEntorno].GetSimbolo(Tokens[j].palabra);
                                        valor_temporal = declarado.valorDouble;
                                    }
                                }
                                else if (Tokens[j].palabra == "+")
                                {
                                    i++;
                                    j++;
                                    if (Tokens[j].valor.Contains("intConstant") || Tokens[j].valor.Contains("doubleConstant"))
                                    {
                                        valor_temporal = valor_temporal + Convert.ToDouble(Tokens[j].palabra);
                                    }
                                    else if (Entornos[ContadorEntorno].Get(Tokens[j].palabra) && (Entornos[ContadorEntorno].GetValue(Tokens[j].palabra) == "int"))
                                    {
                                        Simbolo declarado = Entornos[ContadorEntorno].GetSimbolo(Tokens[j].palabra);
                                        valor_temporal = valor_temporal * declarado.valorInt;
                                    }
                                    else if (Entornos[ContadorEntorno].Get(Tokens[j].palabra) && (Entornos[ContadorEntorno].GetValue(Tokens[j].palabra) == "double"))
                                    {
                                        Simbolo declarado = Entornos[ContadorEntorno].GetSimbolo(Tokens[j].palabra);
                                        valor_temporal = valor_temporal * declarado.valorDouble;
                                    }
                                    else
                                    {
                                        //Tipos diferentes para operar
                                    }
                                }
                                else if (Tokens[j].palabra == "-")
                                {
                                    i++;
                                    j++;
                                    if (Tokens[j].valor.Contains("intConstant") || Tokens[j].valor.Contains("doubleConstant"))
                                    {
                                        valor_temporal = valor_temporal - Convert.ToDouble(Tokens[j].palabra);
                                    }
                                    else if (Entornos[ContadorEntorno].Get(Tokens[j].palabra) && (Entornos[ContadorEntorno].GetValue(Tokens[j].palabra) == "int"))
                                    {
                                        Simbolo declarado = Entornos[ContadorEntorno].GetSimbolo(Tokens[j].palabra);
                                        valor_temporal = valor_temporal * declarado.valorInt;
                                    }
                                    else if (Entornos[ContadorEntorno].Get(Tokens[j].palabra) && (Entornos[ContadorEntorno].GetValue(Tokens[j].palabra) == "double"))
                                    {
                                        Simbolo declarado = Entornos[ContadorEntorno].GetSimbolo(Tokens[j].palabra);
                                        valor_temporal = valor_temporal * declarado.valorDouble;
                                    }
                                    else
                                    {
                                        //Tipos diferentes para operar
                                    }
                                }
                                else if (Tokens[i].palabra == "*")
                                {
                                    i++;
                                    j++;
                                    if (Tokens[j].valor.Contains("intConstant") || Tokens[j].valor.Contains("doubleConstant"))
                                    {
                                        valor_temporal = valor_temporal * Convert.ToDouble(Tokens[j].palabra);
                                    }
                                    else if (Entornos[ContadorEntorno].Get(Tokens[j].palabra) && (Entornos[ContadorEntorno].GetValue(Tokens[j].palabra) == "int"))
                                    {
                                        Simbolo declarado = Entornos[ContadorEntorno].GetSimbolo(Tokens[j].palabra);
                                        valor_temporal = valor_temporal * declarado.valorInt;
                                    }
                                    else if (Entornos[ContadorEntorno].Get(Tokens[j].palabra) && (Entornos[ContadorEntorno].GetValue(Tokens[j].palabra) == "double"))
                                    {
                                        Simbolo declarado = Entornos[ContadorEntorno].GetSimbolo(Tokens[j].palabra);
                                        valor_temporal = valor_temporal * declarado.valorDouble;
                                    }
                                    else
                                    {
                                        //Tipos diferentes para operar
                                    }
                                }
                                else if (Tokens[j].palabra == "/")
                                {
                                    i++;
                                    j++;
                                    if (Tokens[j].valor.Contains("intConstant") || Tokens[j].valor.Contains("doubleConstant"))
                                    {
                                        valor_temporal = valor_temporal / Convert.ToDouble(Tokens[j].palabra);
                                    }
                                    else if (Entornos[ContadorEntorno].Get(Tokens[j].palabra) && (Entornos[ContadorEntorno].GetValue(Tokens[j].palabra) == "int" || Entornos[ContadorEntorno].GetValue(Tokens[j].palabra) == "double"))
                                    {
                                        Simbolo declarado = Entornos[ContadorEntorno].GetSimbolo(Tokens[j].palabra);
                                        valor_temporal = valor_temporal / declarado.valorDouble;
                                    }
                                    else
                                    {
                                        //Tipos diferentes para operar
                                    }
                                }
                                else if (Tokens[j].palabra == "%")
                                {
                                    i++;
                                    j++;
                                    if (Tokens[j].valor.Contains("intConstant") || Tokens[j].valor.Contains("doubleConstant"))
                                    {
                                        valor_temporal = valor_temporal % Convert.ToDouble(Tokens[j].palabra);
                                    }
                                    else if (Entornos[ContadorEntorno].Get(Tokens[j].palabra) && (Entornos[ContadorEntorno].GetValue(Tokens[j].palabra) == "int"))
                                    {
                                        Simbolo declarado = Entornos[ContadorEntorno].GetSimbolo(Tokens[j].palabra);
                                        valor_temporal = valor_temporal * declarado.valorInt;
                                    }
                                    else if (Entornos[ContadorEntorno].Get(Tokens[j].palabra) && (Entornos[ContadorEntorno].GetValue(Tokens[j].palabra) == "double"))
                                    {
                                        Simbolo declarado = Entornos[ContadorEntorno].GetSimbolo(Tokens[j].palabra);
                                        valor_temporal = valor_temporal * declarado.valorDouble;
                                    }
                                    else
                                    {
                                        //Tipos diferentes para operar
                                    }
                                }
                                else if (Tokens[j].palabra == ";")
                                {

                                    break;
                                }
                                else if (!Entornos[ContadorEntorno].Get(Tokens[i].palabra))
                                {
                                    //Error Token no definido en el entorno 
                                }
                                else
                                {
                                    //Error valor no definido
                                }
                                i++;

                            }


                            temporal.valorDouble = valor_temporal;
                            temporal.tipo = actual.tipo;
                            Entornos[ContadorEntorno].Insert(aux, temporal);
                        }
                    }

                }
                else if (Tokens[i].palabra == "boolean")
                {
                    i++;
                    if (!Entornos[ContadorEntorno].Get(Tokens[i].palabra))
                    {
                        Simbolo temporal = new Simbolo();
                        temporal.tipo = Tokens[i - 1].palabra;
                        string temp = Tokens[i].palabra;
                        if (Tokens[i + 1].palabra == ";")
                        {
                            Entornos[ContadorEntorno].Put(temp, temporal);
                        }
                        else if (Tokens[i + 1].palabra == "=")
                        {
                            i = i + 2;
                            if (Tokens[i].palabra == "true")
                            {
                                temporal.valorbool = "true";
                                Entornos[ContadorEntorno].Put(temp, temporal);
                            }
                            else if (Tokens[i].palabra == "false")
                            {
                                temporal.valorbool = "false";
                                Entornos[ContadorEntorno].Put(temp, temporal);
                            }
                            else if (Entornos[ContadorEntorno].Get(Tokens[i].palabra) && Entornos[ContadorEntorno].GetValue(Tokens[i].palabra) == "boolean")
                            {
                                Simbolo declarado = Entornos[ContadorEntorno].GetSimbolo(Tokens[i].palabra);
                                temporal.valorbool = declarado.valorbool;
                                Entornos[ContadorEntorno].Put(temp, temporal);
                            }
                            else
                            {
                                //error
                            }
                        }
                    }
                    else
                    {
                        //Error ya se encuentra declarado
                    }
                }
                else if (Tokens[i].palabra == "string")
                {
                    i++;
                    if (!Entornos[ContadorEntorno].Get(Tokens[i].palabra))
                    {
                        Simbolo temporal = new Simbolo();
                        temporal.tipo = Tokens[i - 1].palabra;
                        string temp = Tokens[i].palabra;
                        if (Tokens[i + 1].palabra == ";")
                        {
                            Entornos[ContadorEntorno].Put(temp, temporal);
                        }
                        else if (Tokens[i + 1].palabra == "=")
                        {
                            i = i + 2;
                            if (Tokens[i].valor.Contains("stringConstant"))
                            {
                                temporal.valorString = Tokens[i].palabra;
                                Entornos[ContadorEntorno].Put(temp, temporal);
                            }
                            else if (Entornos[ContadorEntorno].Get(Tokens[i].palabra) && Entornos[ContadorEntorno].GetValue(Tokens[i].palabra) == "string")
                            {
                                Simbolo declarado = Entornos[ContadorEntorno].GetSimbolo(Tokens[i].palabra);
                                temporal.valorString = declarado.valorString;
                                Entornos[ContadorEntorno].Put(temp, temporal);
                            }

                        }
                    }
                    else
                    {
                        //Error ya se encuentra declarado
                    }
                }
            }
            Console.ReadKey();
   
        }

    }
}
