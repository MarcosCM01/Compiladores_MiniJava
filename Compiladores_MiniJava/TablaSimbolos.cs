using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compiladores_MiniJava
{
    class TablaSimbolos
    {
        public static List<Token> Tokens = new List<Token>();//Tokens ingresados desde el analisis sintactico
        public static List<Entorno> Entornos = new List<Entorno>();
        public static string URL;

        public static void Imprimir()
        {
            var dir = URL.Split('.');
            string Escritura = dir[0] + "TS." + dir[1];
            using (StreamWriter writer = new StreamWriter(Escritura))
            {
                foreach(var item in Entornos)
                {
                    foreach(var simb in item.Simbolos)
                    {
                        if(simb.Value.tipo == "int")
                        {
                            writer.WriteLine($"Token: {simb.Key} Type: int Value:{simb.Value.valorInt} ");
                        }
                        else if (simb.Value.tipo == "double")
                        {
                            writer.WriteLine($"Token: {simb.Key} Type: double Value:{simb.Value.valorDouble} ");
                        }
                        else if (simb.Value.tipo == "string")
                        {
                            writer.WriteLine($"Token: {simb.Key} Type: string Value:{simb.Value.valorString} ");

                        }
                        else if (simb.Value.tipo == "boolean")
                        {
                            writer.WriteLine($"Token: {simb.Key} Type: boolean Value:{simb.Value.valorbool} ");
                        }
                        else if (simb.Value.tipo.Contains("void") )
                        {
                            writer.WriteLine($"Token: {simb.Key} Type: {simb.Value.tipo}  ");
                            writer.Write("Atributos: ");
                            foreach (var arg in simb.Value.argumento)
                            {
                                writer.Write($" {arg.Key} : {arg.Value.tipo} ,");
                            }
                            writer.WriteLine("");
                        }
                        else if (simb.Value.tipo == "class")
                        {
                            writer.WriteLine($"Token: {simb.Key} Type: class  ");
                            writer.Write("Implements:");
                            for (int i = 0;i<simb.Value.Implements.Count;i++)
                            {
                                writer.Write(simb.Value.Implements[i] + ", ");
                            }
                            writer.WriteLine("");
                            writer.Write("Extends:");
                            for (int i = 0; i < simb.Value.Extends.Count; i++)
                            {
                                writer.Write(simb.Value.Extends[i] );
                            }
                            writer.WriteLine("");
                        }
                    }
                }
            }
        }
        public void ImprimirError(Token  token, string error)
        {
            Console.WriteLine($"ERROR: {error}. Token: {token.palabra} Linea: {token.linea} ColumnaI: {token.columna_i} ColumnaF: {token.columna_f}");
        }
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
                                    TablaSimbolos error = new TablaSimbolos();
                                    error.ImprimirError(Tokens[i], "entero ya declarado");
                                    //Error en void, argumento de tipo ya declarado
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
                                    TablaSimbolos error = new TablaSimbolos();
                                    error.ImprimirError(Tokens[i], "double ya declarado");
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
                                    TablaSimbolos error = new TablaSimbolos();
                                    error.ImprimirError(Tokens[i], "boolean ya declarado");
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
                                    TablaSimbolos error = new TablaSimbolos();
                                    error.ImprimirError(Tokens[i], "string ya declarado");
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
                        TablaSimbolos error = new TablaSimbolos();
                        error.ImprimirError(Tokens[i], "identificador ya declarado");
                        //Error ya se encuentra declarado en el entorno
                    }
                }
                else if (Tokens[i].palabra == "class")
                {
                    i++;
                    if (!Entornos[ContadorEntorno].Get(Tokens[i].palabra))
                    {
                        Simbolo temporal = new Simbolo();
                        temporal.tipo = Tokens[i - 1].palabra; //Setear ident.tipo = int
                        string temp = Tokens[i].palabra;
                        if (Tokens[i + 1].palabra == "extends")
                        {
                            i = i + 2;
                            temporal.AddExt(Tokens[i].palabra);
                        }
                        if (Tokens[i + 1].palabra == "implements")
                        {
                            i = i + 2;
                            for (int j = i; j < Tokens.Count; j++)
                            {
                                if (Tokens[j].palabra == "{")
                                {
                                    i--;
                                    break;
                                }
                                else if (Tokens[j].valor == "ident")
                                {
                                    temporal.AddImpl(Tokens[j].palabra);
                                }
                                i++;
                            }
                        }
                        Entornos[ContadorEntorno].Put(temp, temporal);
                    }
                    else
                    {
                        //Error ya se encuentra declarado en el entorno
                        TablaSimbolos error = new TablaSimbolos();
                        error.ImprimirError(Tokens[i], "identificador ya declarado");
                    }
                }
                else if (Tokens[i].palabra == "int") //METODOS TIPO ENTERO
                {
                    i++;
                    if (!Entornos[ContadorEntorno].Get(Tokens[i].palabra))
                    {
                        Simbolo temporal = new Simbolo();
                        temporal.tipo = Tokens[i - 1].palabra; //Setear ident.tipo = int
                        string temp = Tokens[i].palabra;
                        i++; //consumo token del ident
                        if (Tokens[i].palabra == ";")
                        {
                            Entornos[ContadorEntorno].Put(temp, temporal);
                        }
                        else if (Tokens[i].palabra == "=")
                        {
                            //OJO
                            i = i + 2;

                            int valor_temporal = 0;
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
                                        TablaSimbolos error = new TablaSimbolos();
                                        error.ImprimirError(Tokens[i], "Error al operar distintos tipos");
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
                                        TablaSimbolos error = new TablaSimbolos();
                                        error.ImprimirError(Tokens[i], "Error al operar distintos tipos");
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
                                        TablaSimbolos error = new TablaSimbolos();
                                        error.ImprimirError(Tokens[i], "Error al operar distintos tipos");
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
                                        TablaSimbolos error = new TablaSimbolos();
                                        error.ImprimirError(Tokens[i], "Error al operar distintos tipos");
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
                                        TablaSimbolos error = new TablaSimbolos();
                                        error.ImprimirError(Tokens[i], "Error al operar distintos tipos");
                                        //Tipos diferentes para operar
                                    }
                                }
                                else if (Tokens[j].palabra == ";")
                                {
                                    break;
                                }
                                else if (!Entornos[ContadorEntorno].Get(Tokens[i].palabra))
                                {
                                    TablaSimbolos error = new TablaSimbolos();
                                    error.ImprimirError(Tokens[i], "Token no definido");
                                    //Error Token no definido en el entorno 
                                }
                                else
                                {
                                    TablaSimbolos error = new TablaSimbolos();
                                    error.ImprimirError(Tokens[i], "Token sin definir su tipo");
                                    //Error valor no definido
                                }
                                i++;
                            }
                            temporal.valorInt = valor_temporal;
                            Entornos[ContadorEntorno].Put(temp, temporal);
                        }
                        else if (Tokens[i].palabra == "(")
                        {
                            i++;
                            temporal.tipo = "int void";
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
                                        TablaSimbolos error = new TablaSimbolos();
                                        error.ImprimirError(Tokens[i], "Parametro sin tipo definido");
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
                                        TablaSimbolos error = new TablaSimbolos();
                                        error.ImprimirError(Tokens[i], "Parametro sin tipo definido");
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
                                        TablaSimbolos error = new TablaSimbolos();
                                        error.ImprimirError(Tokens[i], "Parametro sin tipo definido");
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
                                        TablaSimbolos error = new TablaSimbolos();
                                        error.ImprimirError(Tokens[i], "Parametro sin tipo definido");
                                        //Error en void argumento ya declarado
                                    }
                                }
                                else if (Tokens[i].palabra == ")")
                                {
                                    i--;
                                    j = Tokens.Count;
                                }
                                i++;
                            }
                            Entornos[ContadorEntorno].Put(temp, temporal);
                        }
                        else if (Tokens[i].palabra == ".")
                        {
                            //FALTA REVISAR COMPROBACION DE METODOS
                            for (int j = i; j < Tokens.Count; j++)
                            {

                            }
                        }

                    }
                    else
                    {
                        TablaSimbolos error = new TablaSimbolos();
                        error.ImprimirError(Tokens[i], "Token ya definido");
                        //Error ya se encuentra declarado
                    }
                }
                else if (Tokens[i].palabra == "double") //METODOS TIPO DOUBLE
                {
                    i++;
                    if (!Entornos[ContadorEntorno].Get(Tokens[i].palabra))
                    {
                        Simbolo temporal = new Simbolo();
                        temporal.tipo = Tokens[i - 1].palabra;
                        string temp = Tokens[i].palabra;
                        i++;
                        if (Tokens[i].palabra == ";")
                        {
                            Entornos[ContadorEntorno].Put(temp, temporal);
                        }
                        else if (Tokens[i].palabra == "=")
                        {
                            //OJO
                            i++;
                            double valor_temporal = 0;
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
                                        TablaSimbolos error = new TablaSimbolos();
                                        error.ImprimirError(Tokens[i], "Distintos tipos de tokens para operar");
                                        //ERROR Tipos diferentes para operar
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
                                        TablaSimbolos error = new TablaSimbolos();
                                        error.ImprimirError(Tokens[i], "Distintos tipos de tokens para operar");
                                        //ERROR Tipos diferentes para operar
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
                                        TablaSimbolos error = new TablaSimbolos();
                                        error.ImprimirError(Tokens[i], "Distintos tipos de tokens para operar");
                                        //ERROR Tipos diferentes para operar
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
                                        TablaSimbolos error = new TablaSimbolos();
                                        error.ImprimirError(Tokens[i], "Distintos tipos de tokens para operar");
                                        //ERROR Tipos diferentes para operar
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
                                        TablaSimbolos error = new TablaSimbolos();
                                        error.ImprimirError(Tokens[i], "Distintos tipos de tokens para operar");
                                        //ERROR Tipos diferentes para operar
                                    }
                                }
                                else if (Tokens[j].palabra == ";")
                                {

                                    break;
                                }
                                else
                                {
                                    TablaSimbolos error = new TablaSimbolos();
                                    error.ImprimirError(Tokens[i], "Se esperaba un operador");
                                    //Error Token no definido en el entorno 
                                }
                                i++;
                            }
                            temporal.valorDouble = valor_temporal;
                            Entornos[ContadorEntorno].Put(temp, temporal);
                        }
                        else if (Tokens[i].palabra == "(")
                        {
                            i++;
                            temporal.tipo = "double void";
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
                                        TablaSimbolos error = new TablaSimbolos();
                                        error.ImprimirError(Tokens[i], "Token ya definido");
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
                                        TablaSimbolos error = new TablaSimbolos();
                                        error.ImprimirError(Tokens[i], "Token ya definido");
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
                                        TablaSimbolos error = new TablaSimbolos();
                                        error.ImprimirError(Tokens[i], "Token ya definido");
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
                                        TablaSimbolos error = new TablaSimbolos();
                                        error.ImprimirError(Tokens[i], "Token ya definido");
                                        //Error en void argumento ya declarado
                                    }
                                }
                                else if (Tokens[i].palabra == ")")
                                {
                                    i--;
                                    j = Tokens.Count;
                                }
                                i++;
                            }
                            Entornos[ContadorEntorno].Put(temp, temporal);
                        }

                    }
                }
                else if (Entornos[ContadorEntorno].Get(Tokens[i].palabra)) //Cuando ya se definen los tokens sin valor, y se actualizan o asignan
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

                            int valor_temporal = 0;
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
                                        TablaSimbolos error = new TablaSimbolos();
                                        error.ImprimirError(Tokens[i], "Tokens de distintos tipos");
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
                                        TablaSimbolos error = new TablaSimbolos();
                                        error.ImprimirError(Tokens[i], "Tokens de distintos tipos");
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
                                        TablaSimbolos error = new TablaSimbolos();
                                        error.ImprimirError(Tokens[i], "Tokens de distintos tipos");
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
                                        TablaSimbolos error = new TablaSimbolos();
                                        error.ImprimirError(Tokens[i], "Tokens de distintos tipos");
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
                                        TablaSimbolos error = new TablaSimbolos();
                                        error.ImprimirError(Tokens[i], "Tokens de distintos tipos");
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
                                    TablaSimbolos error = new TablaSimbolos();
                                    error.ImprimirError(Tokens[i], "Token sin definir");
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
                        i++;
                        if (Tokens[i].palabra == "=")
                        {
                            //OJO
                            i++;

                            double valor_temporal = 0;
                            for (int j = i; j < Tokens.Count; j++)
                            {
                                if (Tokens[j].valor.Contains("intConstant") || Tokens[j].valor.Contains("doubleConstant"))
                                {
                                    valor_temporal = Convert.ToDouble(Tokens[i].palabra);
                                }
                                else if (Entornos[ContadorEntorno].Get(Tokens[j].palabra))
                                {
                                    if (Entornos[ContadorEntorno].GetValue(Tokens[j].palabra) == "int")
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
                                        TablaSimbolos error = new TablaSimbolos();
                                        error.ImprimirError(Tokens[i], "Tokens de distintos tipos");
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
                                        TablaSimbolos error = new TablaSimbolos();
                                        error.ImprimirError(Tokens[i], "Tokens de distintos tipos");
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
                                        TablaSimbolos error = new TablaSimbolos();
                                        error.ImprimirError(Tokens[i], "Tokens de distintos tipos");
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
                                        TablaSimbolos error = new TablaSimbolos();
                                        error.ImprimirError(Tokens[i], "Tokens de distintos tipos");
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
                                        TablaSimbolos error = new TablaSimbolos();
                                        error.ImprimirError(Tokens[i], "Tokens de distintos tipos");
                                    }
                                }
                                else if (Tokens[j].palabra == ";")
                                {
                                    break;
                                }
                                else if (!Entornos[ContadorEntorno].Get(Tokens[i].palabra))
                                {
                                    //Error Token no definido en el entorno
                                    TablaSimbolos error = new TablaSimbolos();
                                    error.ImprimirError(Tokens[i], "Tokens no definido en el entorno");
                                }
                                i++;
                            }
                            temporal.valorDouble = valor_temporal;
                            temporal.tipo = actual.tipo;
                            Entornos[ContadorEntorno].Insert(aux, temporal);
                        }
                    }
                    else if (actual.tipo == "string")
                    {
                        i++;
                        if (Tokens[i].palabra == "=")
                        {
                            i++;
                            actual.valorString = Tokens[i].palabra;
                            
                            Entornos[ContadorEntorno].Insert(aux, actual);
                        }
                    }
                    else if (actual.tipo == "boolean")
                    {
                        i++;
                        if (Tokens[i].palabra == "=")
                        {
                            i++;
                            if (Tokens[i].palabra == "true")
                            {
                                actual.valorbool = "true";
                                Entornos[ContadorEntorno].Insert(aux, actual);
                            }
                            else if (Tokens[i].palabra == "false")
                            {
                                actual.valorbool = "false";
                                Entornos[ContadorEntorno].Insert(aux, actual);
                            }
                            else if (Entornos[ContadorEntorno].Get(Tokens[i].palabra) && Entornos[ContadorEntorno].GetValue(Tokens[i].palabra) == "boolean")
                            {
                                Simbolo declarado = Entornos[ContadorEntorno].GetSimbolo(Tokens[i].palabra);
                                actual.valorbool = declarado.valorbool;
                                Entornos[ContadorEntorno].Insert(aux, actual);
                            }
                            else
                            {
                                TablaSimbolos error = new TablaSimbolos();
                                error.ImprimirError(Tokens[i], "Asignacion incorrecta de tipos");
                                //error
                            }
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
                        i++;
                        if (Tokens[i].palabra == ";")
                        {
                            Entornos[ContadorEntorno].Put(temp, temporal);
                        }
                        else if (Tokens[i].palabra == "=")
                        {
                            i++;
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
                                TablaSimbolos error = new TablaSimbolos();
                                error.ImprimirError(Tokens[i], "Asignacion incorrecta de tipos");
                                //error
                            }
                        }
                        else if (Tokens[i].palabra == "(") //Para metodos BOOLEAN
                        {
                            i++;
                            temporal.tipo = "boolean void";
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
                                        TablaSimbolos error = new TablaSimbolos();
                                        error.ImprimirError(Tokens[i], "Parametro ya declarado");
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
                                        TablaSimbolos error = new TablaSimbolos();
                                        error.ImprimirError(Tokens[i], "Parametro ya definido");
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
                                        TablaSimbolos error = new TablaSimbolos();
                                        error.ImprimirError(Tokens[i], "Parametro ya definido");
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
                                        TablaSimbolos error = new TablaSimbolos();
                                        error.ImprimirError(Tokens[i], "Parametro ya definido");
                                        //Error en void argumento ya declarado
                                    }
                                }
                                else if (Tokens[i].palabra == ")")
                                {
                                    i--;
                                    j = Tokens.Count;
                                }
                                i++;
                            }
                            Entornos[ContadorEntorno].Put(temp, temporal);
                        }

                    }
                    else
                    {
                        TablaSimbolos error = new TablaSimbolos();
                        error.ImprimirError(Tokens[i], "Token ya definido");
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
                        i++;
                        if (Tokens[i].palabra == ";")
                        {
                            Entornos[ContadorEntorno].Put(temp, temporal);
                        }
                        else if (Tokens[i].palabra == "=")
                        {
                            i++;
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
                        else if (Tokens[i].palabra == "(")
                        {
                            i++;
                            temporal.tipo = "string void";
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
                                        TablaSimbolos error = new TablaSimbolos();
                                        error.ImprimirError(Tokens[i], "Parametro ya definido");
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
                                        TablaSimbolos error = new TablaSimbolos();
                                        error.ImprimirError(Tokens[i], "Parametro ya definido");
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
                                        TablaSimbolos error = new TablaSimbolos();
                                        error.ImprimirError(Tokens[i], "Parametro ya definido");
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
                                        TablaSimbolos error = new TablaSimbolos();
                                        error.ImprimirError(Tokens[i], "Parametro ya definido");
                                        //Error en void argumento ya declarado
                                    }
                                }
                                else if (Tokens[i].palabra == ")")
                                {
                                    i--;
                                    j = Tokens.Count;
                                }
                                i++;
                            }
                            Entornos[ContadorEntorno].Put(temp, temporal);
                        }

                    }
                    else
                    {
                        TablaSimbolos error = new TablaSimbolos();
                        error.ImprimirError(Tokens[i], "Token ya definido");
                        //Error ya se encuentra declarado
                    }
                }
                else if (Tokens[i].valor == "ident")
                {
                    TablaSimbolos error = new TablaSimbolos();
                    error.ImprimirError(Tokens[i], "El ident no se encuentra en el entorno actual");
                }
            }

   
        }

    }
}
