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
            for (int i = 0;i<Tokens.Count;i++)
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
                    if (!Entornos[ContadorEntorno].Get(Tokens[i].valor))
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
                    }
                    else
                    {
                        //Error ya se encuentra declarado
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
