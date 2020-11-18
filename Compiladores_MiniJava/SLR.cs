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
        public static List<Reduccion> EstadosReduccion = new List<Reduccion>();
        public static int contador_Errores = 0;
        public static Dictionary<int, int> PrecedenciaProducciones = new Dictionary<int, int>();
        public static Dictionary<string, int> PrecedenciaTerminales = new Dictionary<string, int>();
        public static List<Token> ErroresExplicitos = new List<Token>();
        //LAB_ASDR CONTIENE LA LISTA DE TOKENES, QUE VENDRIA SIENDO NUESTRA ENTRADA

        public static void LlenarEstadosReduccion() 
        {
            EstadosReduccion.Add(new Reduccion() { NumEstado = 0, ProduccionAReducir = "Z", CantidadElementos = 1});
            EstadosReduccion.Add(new Reduccion() { NumEstado = 1, ProduccionAReducir = "Program", CantidadElementos = 2 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 2, ProduccionAReducir = "Decl", CantidadElementos = 1 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 3, ProduccionAReducir = "Decl", CantidadElementos = 1 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 4, ProduccionAReducir = "Decl", CantidadElementos = 1 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 5, ProduccionAReducir = "Decl", CantidadElementos = 1 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 6, ProduccionAReducir = "Decl", CantidadElementos = 1 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 7, ProduccionAReducir = "Decl'", CantidadElementos = 2 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 8, ProduccionAReducir = "Decl'", CantidadElementos = 0 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 9, ProduccionAReducir = "VariableDecl", CantidadElementos = 2 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 10, ProduccionAReducir = "Variable", CantidadElementos = 2 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 11, ProduccionAReducir = "ConstDecl", CantidadElementos = 4 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 12, ProduccionAReducir = "ConstType", CantidadElementos = 1 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 13, ProduccionAReducir = "ConstType", CantidadElementos = 1 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 14, ProduccionAReducir = "ConstType", CantidadElementos = 1 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 15, ProduccionAReducir = "ConstType", CantidadElementos = 1 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 16, ProduccionAReducir = "Type", CantidadElementos = 2 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 17, ProduccionAReducir = "Type", CantidadElementos = 2 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 18, ProduccionAReducir = "Type", CantidadElementos = 2 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 19, ProduccionAReducir = "Type", CantidadElementos = 2 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 20, ProduccionAReducir = "Type", CantidadElementos = 2 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 21, ProduccionAReducir = "Type'", CantidadElementos = 3 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 22, ProduccionAReducir = "Type'", CantidadElementos = 0 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 23, ProduccionAReducir = "FunctionDecl", CantidadElementos = 6 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 24, ProduccionAReducir = "FunctionDecl", CantidadElementos = 6 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 25, ProduccionAReducir = "Formals", CantidadElementos = 2 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 26, ProduccionAReducir = "Formals'", CantidadElementos = 2 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 27, ProduccionAReducir = "Formals'", CantidadElementos = 0 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 28, ProduccionAReducir = "ClassDecl", CantidadElementos = 7 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 29, ProduccionAReducir = "EXTENDS", CantidadElementos = 2 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 30, ProduccionAReducir = "EXTENDS", CantidadElementos = 0 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 31, ProduccionAReducir = "IMPLEMENTS", CantidadElementos = 3 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 32, ProduccionAReducir = "IMPLEMENTS", CantidadElementos = 0 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 33, ProduccionAReducir = "IMPLEMENTS'", CantidadElementos = 3 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 34, ProduccionAReducir = "IMPLEMENTS'", CantidadElementos = 0 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 35, ProduccionAReducir = "Field", CantidadElementos = 1 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 36, ProduccionAReducir = "Field", CantidadElementos = 1 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 37, ProduccionAReducir = "Field", CantidadElementos = 1 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 38, ProduccionAReducir = "Field'", CantidadElementos = 2 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 39, ProduccionAReducir = "Field'", CantidadElementos = 0 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 40, ProduccionAReducir = "InterfaceDecl", CantidadElementos = 5 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 41, ProduccionAReducir = "InterfaceDecl'", CantidadElementos = 2 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 42, ProduccionAReducir = "InterfaceDecl'", CantidadElementos = 0 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 43, ProduccionAReducir = "Prototype", CantidadElementos = 6 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 44, ProduccionAReducir = "Prototype", CantidadElementos = 6 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 45, ProduccionAReducir = "StmtBlock", CantidadElementos = 5 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 46, ProduccionAReducir = "LlamarVar", CantidadElementos = 2 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 47, ProduccionAReducir = "LlamarVar", CantidadElementos = 0 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 48, ProduccionAReducir = "LlamarConst", CantidadElementos = 2 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 49, ProduccionAReducir = "LlamarConst", CantidadElementos = 0 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 50, ProduccionAReducir = "LlamarStmt", CantidadElementos = 2 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 51, ProduccionAReducir = "LlamarStmt", CantidadElementos = 0 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 52, ProduccionAReducir = "Stmt", CantidadElementos = 2 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 53, ProduccionAReducir = "Stmt", CantidadElementos = 1 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 54, ProduccionAReducir = "Stmt", CantidadElementos = 1 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 55, ProduccionAReducir = "Stmt", CantidadElementos = 1 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 56, ProduccionAReducir = "Stmt", CantidadElementos = 1 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 57, ProduccionAReducir = "Stmt", CantidadElementos = 1 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 58, ProduccionAReducir = "Stmt", CantidadElementos = 1 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 59, ProduccionAReducir = "Stmt", CantidadElementos = 1 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 60, ProduccionAReducir = "Stmt", CantidadElementos = 1 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 61, ProduccionAReducir = "Stmt'", CantidadElementos = 1 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 62, ProduccionAReducir = "Stmt'", CantidadElementos = 0 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 63, ProduccionAReducir = "ifStmt", CantidadElementos = 6 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 64, ProduccionAReducir = "ifStmt'", CantidadElementos = 2 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 65, ProduccionAReducir = "ifStmt'", CantidadElementos = 0 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 66, ProduccionAReducir = "WhileStmt", CantidadElementos = 5 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 67, ProduccionAReducir = "ForStmt", CantidadElementos = 9 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 68, ProduccionAReducir = "ReturnStmt", CantidadElementos = 3 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 69, ProduccionAReducir = "BreakStmt", CantidadElementos = 2 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 70, ProduccionAReducir = "PrintStmt", CantidadElementos = 10 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 71, ProduccionAReducir = "PrintStmt'", CantidadElementos = 3 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 72, ProduccionAReducir = "PrintStmt'", CantidadElementos = 0 });

            EstadosReduccion.Add(new Reduccion() { NumEstado = 73, ProduccionAReducir = "CallStmt", CantidadElementos = 4 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 74, ProduccionAReducir = "CallStmt", CantidadElementos = 6 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 75, ProduccionAReducir = "Actuals", CantidadElementos = 3 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 76, ProduccionAReducir = "PrintStmt'", CantidadElementos = 1 });

            EstadosReduccion.Add(new Reduccion() { NumEstado = 77, ProduccionAReducir = "Constant", CantidadElementos = 1 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 78, ProduccionAReducir = "Constant", CantidadElementos = 1 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 79, ProduccionAReducir = "Constant", CantidadElementos = 1 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 80, ProduccionAReducir = "Constant", CantidadElementos = 1 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 81, ProduccionAReducir = "Constant", CantidadElementos = 1 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 82, ProduccionAReducir = "Expr", CantidadElementos = 2 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 83, ProduccionAReducir = "Expr'", CantidadElementos = 3 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 84, ProduccionAReducir = "Expr'", CantidadElementos = 0 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 85, ProduccionAReducir = "A", CantidadElementos = 2 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 86, ProduccionAReducir = "A'", CantidadElementos = 3 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 87, ProduccionAReducir = "A'", CantidadElementos = 0 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 88, ProduccionAReducir = "B", CantidadElementos = 2 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 89, ProduccionAReducir = "B'", CantidadElementos = 3 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 90, ProduccionAReducir = "B'", CantidadElementos = 3 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 91, ProduccionAReducir = "B'", CantidadElementos = 0 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 92, ProduccionAReducir = "C", CantidadElementos = 2 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 93, ProduccionAReducir = "C'", CantidadElementos = 3 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 94, ProduccionAReducir = "C'", CantidadElementos = 0 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 95, ProduccionAReducir = "D", CantidadElementos = 2 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 96, ProduccionAReducir = "D'", CantidadElementos = 3 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 97, ProduccionAReducir = "D'", CantidadElementos = 3 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 98, ProduccionAReducir = "D'", CantidadElementos = 0 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 99, ProduccionAReducir = "E", CantidadElementos = 2 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 100, ProduccionAReducir = "E'", CantidadElementos = 3 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 101, ProduccionAReducir = "E'", CantidadElementos = 3 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 102, ProduccionAReducir = "E'", CantidadElementos = 0 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 103, ProduccionAReducir = "F", CantidadElementos = 3 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 104, ProduccionAReducir = "F", CantidadElementos = 1 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 105, ProduccionAReducir = "G", CantidadElementos = 3 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 106, ProduccionAReducir = "G", CantidadElementos = 1 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 107, ProduccionAReducir = "G", CantidadElementos = 4 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 108, ProduccionAReducir = "G", CantidadElementos = 1 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 109, ProduccionAReducir = "G", CantidadElementos = 2 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 110, ProduccionAReducir = "X'", CantidadElementos = 2 });
            EstadosReduccion.Add(new Reduccion() { NumEstado = 111, ProduccionAReducir = "X'", CantidadElementos = 0 });
        }
        public static void LlenarPrecedenciaTerminales() 
        {
            PrecedenciaTerminales.Add(";", 102);
            PrecedenciaTerminales.Add("ident", 101);
            PrecedenciaTerminales.Add("static", 100);
            PrecedenciaTerminales.Add("int", 99);
            PrecedenciaTerminales.Add("double", 98);
            PrecedenciaTerminales.Add("boolean", 97);
            PrecedenciaTerminales.Add("string", 96);
            PrecedenciaTerminales.Add("[]", 90);
            PrecedenciaTerminales.Add("(", 87);
            PrecedenciaTerminales.Add(")", 87);
            PrecedenciaTerminales.Add("void", 87);
            PrecedenciaTerminales.Add(",", 85);
            PrecedenciaTerminales.Add("class", 83);
            PrecedenciaTerminales.Add("{", 83);
            PrecedenciaTerminales.Add("}", 83);
            PrecedenciaTerminales.Add("extends", 82);
            PrecedenciaTerminales.Add("implements", 80);
            PrecedenciaTerminales.Add("if", 48);
            PrecedenciaTerminales.Add("else", 47);
            PrecedenciaTerminales.Add("while", 45);
            PrecedenciaTerminales.Add("for", 44);
            PrecedenciaTerminales.Add("return", 43);
            PrecedenciaTerminales.Add("break", 42);
            PrecedenciaTerminales.Add("System", 41);
            PrecedenciaTerminales.Add(".", 41);
            PrecedenciaTerminales.Add("out", 41);
            PrecedenciaTerminales.Add("println", 41);
            PrecedenciaTerminales.Add("intConstant", 34);
            PrecedenciaTerminales.Add("doubleConstant", 33);
            PrecedenciaTerminales.Add("boolConstant", 32);
            PrecedenciaTerminales.Add("stringConstant", 31);
            PrecedenciaTerminales.Add("null", 30);
            PrecedenciaTerminales.Add("||", 28);
            PrecedenciaTerminales.Add("!=", 25);
            PrecedenciaTerminales.Add(">", 22);
            PrecedenciaTerminales.Add(">=", 21);
            PrecedenciaTerminales.Add("-", 18);
            PrecedenciaTerminales.Add("/", 15);
            PrecedenciaTerminales.Add("%", 14);
            PrecedenciaTerminales.Add("!", 10);
            PrecedenciaTerminales.Add("this", 3);
            PrecedenciaTerminales.Add("=", 1);
        }
        public static void LlenarPrecedenciaProducciones()
        {
            PrecedenciaProducciones.Add(111, 0); //t = 0
            PrecedenciaProducciones.Add(110, 0); //t = 0
            PrecedenciaProducciones.Add(109, 0); //t = 0
            PrecedenciaProducciones.Add(108, 0); //t = 0
            PrecedenciaProducciones.Add(107, 0); //t = 0
            PrecedenciaProducciones.Add(106, 0); //t = 0
            PrecedenciaProducciones.Add(105, 0); //t = 0
            PrecedenciaProducciones.Add(104, 0); //t = 0
            PrecedenciaProducciones.Add(103, 0); //t = 0
            PrecedenciaProducciones.Add(102, 101); //t = ident
            PrecedenciaProducciones.Add(101, 101); //t = ident
            PrecedenciaProducciones.Add(100, 102); //t = ;
            PrecedenciaProducciones.Add(99, 99); //t = int
            PrecedenciaProducciones.Add(98, 98); //t = double
            PrecedenciaProducciones.Add(97, 97); //t = boolean
            PrecedenciaProducciones.Add(96, 96); //t = string
            PrecedenciaProducciones.Add(95, 99); //t = int
            PrecedenciaProducciones.Add(94, 98); //t = double
            PrecedenciaProducciones.Add(93, 97); //t = boolean
            PrecedenciaProducciones.Add(92, 96); //t = string
            PrecedenciaProducciones.Add(91, 101); //t = ident
            PrecedenciaProducciones.Add(90, 90); //t = []
            PrecedenciaProducciones.Add(89, 0); //t = 0
            PrecedenciaProducciones.Add(88, 87); //t = )
            PrecedenciaProducciones.Add(87, 87); //t = )
            PrecedenciaProducciones.Add(86, 0); //t = 0
            PrecedenciaProducciones.Add(85, 85); //t = ,
            PrecedenciaProducciones.Add(84, 0); //t = 0
            PrecedenciaProducciones.Add(83, 83); //t = }
            PrecedenciaProducciones.Add(82, 101); //t = ident
            PrecedenciaProducciones.Add(81, 0); //t = 0
            PrecedenciaProducciones.Add(80, 101); //t = ident
            PrecedenciaProducciones.Add(79, 0); //t = 0
            PrecedenciaProducciones.Add(78, 85); //t = ,
            PrecedenciaProducciones.Add(77, 0); //t = 0
            PrecedenciaProducciones.Add(76, 0); //t = 0
            PrecedenciaProducciones.Add(75, 0); //t = 0
            PrecedenciaProducciones.Add(74, 0); //t = 0
            PrecedenciaProducciones.Add(73, 0); //t = 0
            PrecedenciaProducciones.Add(72, 0); //t = 0
            PrecedenciaProducciones.Add(71, 0); //t = 0
            PrecedenciaProducciones.Add(70, 0); //t = 0
            PrecedenciaProducciones.Add(69, 0); //t = 0
            PrecedenciaProducciones.Add(68, 102); //t = ;
            PrecedenciaProducciones.Add(67, 102); //t = ;
            PrecedenciaProducciones.Add(66, 83); //t = }
            PrecedenciaProducciones.Add(65, 0); //t = 0
            PrecedenciaProducciones.Add(64, 0); //t = 0
            PrecedenciaProducciones.Add(63, 0); //t = 0
            PrecedenciaProducciones.Add(62, 0); //t = 0
            PrecedenciaProducciones.Add(61, 0); //t = 0
            PrecedenciaProducciones.Add(60, 0); //t = 0
            PrecedenciaProducciones.Add(59, 102); //t = ;
            PrecedenciaProducciones.Add(58, 0); //t = 0
            PrecedenciaProducciones.Add(57, 0); //t = 0
            PrecedenciaProducciones.Add(56, 0); //t = 0
            PrecedenciaProducciones.Add(55, 0); //t = 0
            PrecedenciaProducciones.Add(54, 0); //t = 0
            PrecedenciaProducciones.Add(53, 0); //t = 0
            PrecedenciaProducciones.Add(52, 0); //t = 0
            PrecedenciaProducciones.Add(51, 0); //t = 0
            PrecedenciaProducciones.Add(50, 0); //t = 0
            PrecedenciaProducciones.Add(49, 0); //t = 0
            PrecedenciaProducciones.Add(48, 87); //t = )
            PrecedenciaProducciones.Add(47, 47); //t = else
            PrecedenciaProducciones.Add(46, 0); //t = 0
            PrecedenciaProducciones.Add(45, 87); //t = )
            PrecedenciaProducciones.Add(44, 87); //t = )
            PrecedenciaProducciones.Add(43, 102); //t = ;
            PrecedenciaProducciones.Add(42, 102); //t = 
            PrecedenciaProducciones.Add(41, 102); //t = ;
            PrecedenciaProducciones.Add(40, 85); //t = ,
            PrecedenciaProducciones.Add(39, 0); //t = 0
            PrecedenciaProducciones.Add(38, 87); //t = )
            PrecedenciaProducciones.Add(37, 87); //t = )
            PrecedenciaProducciones.Add(36, 85); //t = ,
            PrecedenciaProducciones.Add(35, 0); //t = 0
            PrecedenciaProducciones.Add(34, 34); //t = intConstant
            PrecedenciaProducciones.Add(33, 33); //t = doubleConstant
            PrecedenciaProducciones.Add(32, 32); //t = boolConstant
            PrecedenciaProducciones.Add(31, 31); //t = stringConstant
            PrecedenciaProducciones.Add(30, 30); //t = null
            PrecedenciaProducciones.Add(29, 0); //t = 0
            PrecedenciaProducciones.Add(28, 28); //t = ||
            PrecedenciaProducciones.Add(27, 0); //t = 0
            PrecedenciaProducciones.Add(26, 0); //t = 0
            PrecedenciaProducciones.Add(25, 25); //t = !=
            PrecedenciaProducciones.Add(24, 0); //t = 0
            PrecedenciaProducciones.Add(23, 0); //t = 0
            PrecedenciaProducciones.Add(22, 22); //t = >
            PrecedenciaProducciones.Add(21, 21); //t = >=
            PrecedenciaProducciones.Add(20, 0); //t = 0
            PrecedenciaProducciones.Add(19, 0); //t = 0
            PrecedenciaProducciones.Add(18, 18); //t = -
            PrecedenciaProducciones.Add(17, 0); //t = 0
            PrecedenciaProducciones.Add(16, 0); //t = 0
            PrecedenciaProducciones.Add(15, 15); //t = /
            PrecedenciaProducciones.Add(14, 14); //t = %
            PrecedenciaProducciones.Add(13, 0); //t = 0
            PrecedenciaProducciones.Add(12, 0); //t = 0
            PrecedenciaProducciones.Add(11, 18); //t = -
            PrecedenciaProducciones.Add(10, 10); //t= !
            PrecedenciaProducciones.Add(9, 0); //t = 0
            PrecedenciaProducciones.Add(8, 102); //t = ident
            PrecedenciaProducciones.Add(7, 0); //t = 0
            PrecedenciaProducciones.Add(6, 87); //t = )
            PrecedenciaProducciones.Add(5, 0);//t = 0
            PrecedenciaProducciones.Add(4, 87);//t = )
            PrecedenciaProducciones.Add(3, 3);//t = this
            PrecedenciaProducciones.Add(2, 102);//t = ident
            PrecedenciaProducciones.Add(1, 1); //t = =
            PrecedenciaProducciones.Add(0, 0);
            //Si no hay ningun terminal, su precedencia es 0
        }
        public static void AccionReduccion(int estado)
        {
            var produccion = EstadosReduccion.Find(x => x.NumEstado == estado);
            for(int i = 0; i< produccion.CantidadElementos;i++)
            {
                Simbolos.Pop();
                PilaEstados.Pop();
            }
            Simbolos.Push(produccion.ProduccionAReducir);
            BanderaReduccion = true;
        }
        public static void ManejoError(int index)
        {
            //CORREGIR ESTA PARTE
            contador_Errores++;
            Console.WriteLine($"Error sintactico #{contador_Errores}: {ErroresExplicitos[index].valor} (value = {ErroresExplicitos[index].palabra}) Linea: {ErroresExplicitos[index].linea} ColumnaI: {ErroresExplicitos[index].columna_i} ColumnaF: {ErroresExplicitos[index].columna_f}");
            Lab_ASDR.TokenList.RemoveAt(index);
            Simbolos.Clear();
            PilaEstados.Clear();
            PilaEstados.Push(0);
        }
        public static void PARSER_PILA() 
        {
            PilaEstados.Push(0); //La pila siempre inicia en estado 0
            Lab_ASDR.TokenList.Add("$"); //Se agrega a la lista de tokens el $ para indicar fin
            LlenarEstadosReduccion();
            LlenarPrecedenciaProducciones();
            LlenarPrecedenciaTerminales();
            var simbolo_actual = Lab_ASDR.TokenList[0];
            for (int i = 0; i < Lab_ASDR.TokenList.Count; i++)
            {
                switch(PilaEstados.Peek())
                {
                    case 0:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;
                            if (Simbolos.Peek() == "Program")
                            {
                                PilaEstados.Push(1);
                                i--;
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
                        else if (Lab_ASDR.TokenList[i] == "ident")
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
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                            break;
                    case 1:
                        if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //aceptar
                            Console.WriteLine("Archivo sintacticamente correcto");
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 2:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;
                            if (Simbolos.Peek() == "Decl'")
                            {
                                PilaEstados.Push(19);
                                i--;
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
                        else if (Lab_ASDR.TokenList[i] == "ident")
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
                            AccionReduccion(8);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 3:
                        if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r2
                            AccionReduccion(2);
                            i--;

                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r2
                            AccionReduccion(2);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r2
                            AccionReduccion(2);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r2
                            AccionReduccion(2);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r2
                            AccionReduccion(2);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r2
                            AccionReduccion(2);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r2
                            AccionReduccion(2);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r2
                            AccionReduccion(2);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r2
                            AccionReduccion(2);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r2
                            AccionReduccion(2);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 4:
                        if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r3
                            AccionReduccion(3);
                            i--;

                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r3
                            AccionReduccion(3);
                            i--;

                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r3
                            AccionReduccion(3);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r3
                            AccionReduccion(3);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r3
                            AccionReduccion(3);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r3
                            AccionReduccion(3);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r3
                            AccionReduccion(3);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r3
                            AccionReduccion(3);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r3
                            AccionReduccion(3);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r3
                            AccionReduccion(3);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 5:
                        if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r4
                            AccionReduccion(4);
                            i--;

                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r4
                            AccionReduccion(4);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r4
                            AccionReduccion(4);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r4.
                            AccionReduccion(4);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r4
                            AccionReduccion(4);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r4
                            AccionReduccion(4);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r4
                            AccionReduccion(4);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r4
                            AccionReduccion(4);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r4
                            AccionReduccion(4);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r4
                            AccionReduccion(4);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 6:
                        if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r5
                            AccionReduccion(5);
                            i--;

                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r5
                            AccionReduccion(5);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r5
                            AccionReduccion(5);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r5
                            AccionReduccion(5);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r5
                            AccionReduccion(5);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r5
                            AccionReduccion(5);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r5
                            AccionReduccion(5);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r5
                            AccionReduccion(5);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r5
                            AccionReduccion(5);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r5
                            AccionReduccion(5);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 7:
                        if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r6
                            AccionReduccion(6);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r6
                            AccionReduccion(6);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r6
                            AccionReduccion(6);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r6
                            AccionReduccion(6);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r6
                            AccionReduccion(6);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r6
                            AccionReduccion(6);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r6
                            AccionReduccion(6);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r6
                            AccionReduccion(6);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r6
                            AccionReduccion(6);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r6
                            AccionReduccion(6);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 8:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //s21
                            PilaEstados.Push(21);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 9:
                        if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s22
                            PilaEstados.Push(22);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 10:
                        if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s23
                            PilaEstados.Push(23);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 11:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;
                            if (Simbolos.Peek() == "ConstType")
                            {
                                PilaEstados.Push(24);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
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
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 12:
                        if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s29
                            PilaEstados.Push(29);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 13:
                        if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s30
                            PilaEstados.Push(30);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 14:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;
                            if (Simbolos.Peek() == "Type'")
                            {
                                PilaEstados.Push(31);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "[]")
                        {
                            //s32
                            PilaEstados.Push(32);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r22
                            AccionReduccion(22);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 15:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;
                            if (Simbolos.Peek() == "Type'")
                            {
                                PilaEstados.Push(33);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r22
                            AccionReduccion(22);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "[]")
                        {
                            //s32
                            PilaEstados.Push(32);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 16:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;
                            if (Simbolos.Peek() == "Type'")
                            {
                                PilaEstados.Push(34);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r22
                            AccionReduccion(22);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "[]")
                        {
                            //s32
                            PilaEstados.Push(32);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 17:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;
                            if (Simbolos.Peek() == "Type'")
                            {
                                PilaEstados.Push(35);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r22
                            AccionReduccion(22);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "[]")
                        {
                            //s32
                            PilaEstados.Push(32);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 18:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;
                            if (Simbolos.Peek() == "Type'")
                            {
                                PilaEstados.Push(36);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r22
                            AccionReduccion(22);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "[]")
                        {
                            //s32
                            PilaEstados.Push(32);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 19:
                        if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r1
                            AccionReduccion(1);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 20:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;
                            if (Simbolos.Peek() == "Decl'")
                            {
                                PilaEstados.Push(37);
                                i--;
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
                        else if (Lab_ASDR.TokenList[i] == "ident")
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
                            AccionReduccion(8);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 21:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r9
                            AccionReduccion(9);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r9
                            AccionReduccion(9);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r9
                            AccionReduccion(9);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r9
                            AccionReduccion(9);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r9
                            AccionReduccion(9);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r9
                            AccionReduccion(9);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r9
                            AccionReduccion(9);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r9
                            AccionReduccion(9);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r9
                            AccionReduccion(9);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r9
                            AccionReduccion(9);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r9
                            AccionReduccion(9);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r9
                            AccionReduccion(9);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r9
                            AccionReduccion(9);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r9
                            AccionReduccion(9);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r9
                            AccionReduccion(9);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r9
                            AccionReduccion(9);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r9
                            AccionReduccion(9);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r9
                            AccionReduccion(9);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r9
                            AccionReduccion(9);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r9
                            AccionReduccion(9);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r9
                            AccionReduccion(9);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r9
                            AccionReduccion(9);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r9
                            AccionReduccion(9);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r9
                            AccionReduccion(9);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r9
                            AccionReduccion(9);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r9
                            AccionReduccion(9);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r9
                            AccionReduccion(9);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r9
                            AccionReduccion(9);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r9
                            AccionReduccion(9);
                            i--;
                            //revisar
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 22:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r10
                            AccionReduccion(10);
                            i--;
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
                            AccionReduccion(10);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r10
                            AccionReduccion(10);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 23:
                        if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s39
                            PilaEstados.Push(39);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 24:
                        if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s40
                            PilaEstados.Push(40);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 25:
                        if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r12
                            AccionReduccion(12);
                            i--;

                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 26:
                        if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r13
                            AccionReduccion(13);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 27:
                        if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r14
                            AccionReduccion(14);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 28:
                        if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r15
                            AccionReduccion(15);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 29:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;
                            if (Simbolos.Peek() == "EXTENDS")
                            {
                                PilaEstados.Push(41);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r30
                            AccionReduccion(30);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r30
                            AccionReduccion(30);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r30
                            AccionReduccion(30);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r30
                            AccionReduccion(30);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r30
                            AccionReduccion(30);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r30
                            AccionReduccion(30);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r30
                            AccionReduccion(30);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r30
                            AccionReduccion(30);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r30
                            AccionReduccion(30);
                            i--;
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
                            AccionReduccion(30);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r30
                            AccionReduccion(30);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r30
                            AccionReduccion(30);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 30:
                        if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //s43
                            PilaEstados.Push(43);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 31:
                        if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r16
                            AccionReduccion(16);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 32:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;
                            if (Simbolos.Peek() == "Type'")
                            {
                                PilaEstados.Push(44);
                                i--;
                            }
                        }
                        else if(Lab_ASDR.TokenList[i] == "[]")
                        {
                            //s32
                            PilaEstados.Push(32);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r22
                            AccionReduccion(22);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 33:
                        if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r17
                            AccionReduccion(17);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 34:
                        if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r18
                            AccionReduccion(18);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 35:
                        if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r19
                            AccionReduccion(19);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 36:
                        if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r20
                            AccionReduccion(20);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 37:
                        if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r7
                            AccionReduccion(7);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 38:
                        if (BanderaReduccion == true)
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
                        else if (Lab_ASDR.TokenList[i] == "ident")
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
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 39:
                        if (BanderaReduccion == true)
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
                        else if (Lab_ASDR.TokenList[i] == "ident")
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
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 40:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //s49
                            PilaEstados.Push(49);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 41:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "IMPLEMENTS")
                            {
                                PilaEstados.Push(50);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "implements")
                        {
                            //s51
                            PilaEstados.Push(51);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r32
                            AccionReduccion(32);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 42:
                        if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s52
                            PilaEstados.Push(52);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 43:
                        if (BanderaReduccion == true)
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
                            else if (Simbolos.Peek() == "Prototype")
                            {
                                PilaEstados.Push(54);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
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
                            AccionReduccion(42);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 44:
                        if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r21
                            AccionReduccion(21);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 45:
                        if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //s57
                            PilaEstados.Push(57);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 46:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Formals'")
                            {
                                PilaEstados.Push(58);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r27
                            AccionReduccion(27);
                            i--;
                        }

                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //s59
                            PilaEstados.Push(59);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 47:
                        if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s60
                            PilaEstados.Push(60);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 48:
                        if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //s61
                            PilaEstados.Push(61);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 49:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r11
                            AccionReduccion(11);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r11
                            AccionReduccion(11);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r11
                            AccionReduccion(11);
                            i--;

                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r11
                            AccionReduccion(11);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r11
                            AccionReduccion(11);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r11
                            AccionReduccion(11);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r11
                            AccionReduccion(11);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r11
                            AccionReduccion(11);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r11
                            AccionReduccion(11);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r11
                            AccionReduccion(11);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r11
                            AccionReduccion(11);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r11
                            AccionReduccion(11);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r11
                            AccionReduccion(11);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r11
                            AccionReduccion(11);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r11
                            AccionReduccion(11);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r11
                            AccionReduccion(11);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r11
                            AccionReduccion(11);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r11
                            AccionReduccion(11);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r11
                            AccionReduccion(11);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r11
                            AccionReduccion(11);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r11
                            AccionReduccion(11);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r11
                            AccionReduccion(11);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r11
                            AccionReduccion(11);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r11
                            AccionReduccion(11);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r11
                            AccionReduccion(11);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r11
                            AccionReduccion(11);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r11
                            AccionReduccion(11);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r11
                            AccionReduccion(11);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r11
                            AccionReduccion(11);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 50:
                        if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //s62
                            PilaEstados.Push(62);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 51:
                        if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s63
                            PilaEstados.Push(63);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 52:
                        if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r29
                            AccionReduccion(29);
                            i--;

                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r29
                            AccionReduccion(29);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r29
                            AccionReduccion(29);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r29
                            AccionReduccion(29);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r29
                            AccionReduccion(29);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r29
                            AccionReduccion(29);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r29
                            AccionReduccion(29);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r29
                            AccionReduccion(29);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r29
                            AccionReduccion(29);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "implements")
                        {
                            //r29
                            AccionReduccion(29);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r29
                            AccionReduccion(29);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r29
                            AccionReduccion(29);
                            i--;
                            //revisar
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 53:
                        if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //s64
                            PilaEstados.Push(64);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 54:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Type")
                            {
                                PilaEstados.Push(55);
                                i--;
                            }
                            else if (Simbolos.Peek() == "InterfaceDecl'")
                            {
                                PilaEstados.Push(65);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Prototype")
                            {
                                PilaEstados.Push(54);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
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
                            AccionReduccion(42);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 55:
                        if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s66
                            PilaEstados.Push(66);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 56:
                        if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s67
                            PilaEstados.Push(67);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 57:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "StmtBlock")
                            {
                                PilaEstados.Push(68);
                                i--;
                            }
                         
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //s69
                            PilaEstados.Push(69);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 58:
                       if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r25
                            AccionReduccion(25);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 59:
                        if (BanderaReduccion == true)
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
                                PilaEstados.Push(70);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
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
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 60:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r10
                            AccionReduccion(10);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r10
                            AccionReduccion(10);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r10
                            AccionReduccion(10);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 61:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "StmtBlock")
                            {
                                PilaEstados.Push(71);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //s69
                            PilaEstados.Push(69);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 62:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "VariableDecl")
                            {
                                PilaEstados.Push(74);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Variable")
                            {
                                PilaEstados.Push(8);
                                i--;
                            }
                            else if (Simbolos.Peek() == "ConstDecl")
                            {
                                PilaEstados.Push(76);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Type")
                            {
                                PilaEstados.Push(9);
                                i--;
                            }
                            else if (Simbolos.Peek() == "FunctionDecl")
                            {
                                PilaEstados.Push(75);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Field")
                            {
                                PilaEstados.Push(73);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Field'")
                            {
                                PilaEstados.Push(72);
                                i--;
                            }
                        }                        
                        else if (Lab_ASDR.TokenList[i] == "ident")
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
                            AccionReduccion(39);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 63:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "IMPLEMENTS'")
                            {
                                PilaEstados.Push(77);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //s78
                            PilaEstados.Push(78);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r34
                            AccionReduccion(34);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 64:
                        if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r40
                            AccionReduccion(40);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r40
                            AccionReduccion(40);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r40
                            AccionReduccion(40);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r40
                            AccionReduccion(40);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r40
                            AccionReduccion(40);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r40
                            AccionReduccion(40);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r40
                            AccionReduccion(40);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r40
                            AccionReduccion(40);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r40
                            AccionReduccion(40);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r40
                            AccionReduccion(40);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 65:
                        if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r41
                            AccionReduccion(41);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 66:
                        if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s79
                            PilaEstados.Push(79);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 67:
                        if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s80
                            PilaEstados.Push(80);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 68:
                        if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r23
                            AccionReduccion(23);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r23
                            AccionReduccion(23);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r23
                            AccionReduccion(23);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r23
                            AccionReduccion(23);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r23
                            AccionReduccion(23);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r23
                            AccionReduccion(23);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r23
                            AccionReduccion(23);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r23
                            AccionReduccion(23);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r23
                            AccionReduccion(23);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r23
                            AccionReduccion(23);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r23
                            AccionReduccion(23);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 69:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "VariableDecl")
                            {
                                PilaEstados.Push(82);
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
                                PilaEstados.Push(81);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        //CONFLICTO #1 
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //PRECEDENCIA DEL TERMINAL
                            var terPrec = PrecedenciaTerminales[Lab_ASDR.TokenList[i]];
                            //PRECEDENCIA DE LA PRODUCCION
                            var proPrec = 26;
                            if (proPrec > terPrec)
                            {
                                //r47
                                AccionReduccion(47);
                                i--;
                            }
                            else
                            {
                                //s18
                                PilaEstados.Push(18);
                                Simbolos.Push(Lab_ASDR.TokenList[i]);
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        //CONFLICTO #2 ******PARCIALMENTE BUENO****
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //PRECEDENCIA DEL TERMINAL
                            var terPrec = PrecedenciaTerminales[Lab_ASDR.TokenList[i]];
                            //PRECEDENCIA DE LA PRODUCCION
                            var proPrec = 26;
                            if (proPrec > terPrec)
                            {
                                //r47
                                AccionReduccion(47);
                                i--;
                            }
                            else
                            {
                                //s14
                                PilaEstados.Push(14);
                                Simbolos.Push(Lab_ASDR.TokenList[i]);
                            }
                        }
                        //CONFLICTO #3
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //PRECEDENCIA DEL TERMINAL
                            var terPrec = PrecedenciaTerminales[Lab_ASDR.TokenList[i]];
                            //PRECEDENCIA DE LA PRODUCCION
                            var proPrec = 26;
                            if (proPrec > terPrec)
                            {
                                //r47
                                AccionReduccion(47);
                                i--;
                            }
                            else
                            {
                                //s15
                                PilaEstados.Push(15);
                                Simbolos.Push(Lab_ASDR.TokenList[i]);
                            }
                        }
                        //CONFLICTO #4
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //PRECEDENCIA DEL TERMINAL
                            var terPrec = PrecedenciaTerminales[Lab_ASDR.TokenList[i]];
                            //PRECEDENCIA DE LA PRODUCCION
                            var proPrec = 26;
                            if (proPrec > terPrec)
                            {
                                //r47
                                AccionReduccion(47);
                                i--;
                            }
                            else
                            {
                                //s16
                                PilaEstados.Push(16);
                                Simbolos.Push(Lab_ASDR.TokenList[i]);
                            }
                        }
                        //CONFLICTO #5
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //PRECEDENCIA DEL TERMINAL
                            var terPrec = PrecedenciaTerminales[Lab_ASDR.TokenList[i]];
                            //PRECEDENCIA DE LA PRODUCCION
                            var proPrec = 26;
                            if (proPrec > terPrec)
                            {
                                //r47
                                AccionReduccion(47);
                                i--;
                            }
                            else
                            {
                                //s17
                                PilaEstados.Push(17);
                                Simbolos.Push(Lab_ASDR.TokenList[i]);
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 70:
                        if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r26
                            AccionReduccion(26);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 71:
                        if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r24
                            AccionReduccion(24);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r24
                            AccionReduccion(24);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r24
                            AccionReduccion(24);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r24
                            AccionReduccion(24);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r24
                            AccionReduccion(24);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r24
                            AccionReduccion(24);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r24
                            AccionReduccion(24);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r24
                            AccionReduccion(24);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r24
                            AccionReduccion(24);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r24
                            AccionReduccion(24);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r24
                            //revisar
                            AccionReduccion(24);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 72:
                        if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //s83
                            PilaEstados.Push(83);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 73:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "VariableDecl")
                            {
                                PilaEstados.Push(74);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Variable")
                            {
                                PilaEstados.Push(8);
                                i--;
                            }
                            else if (Simbolos.Peek() == "ConstDecl")
                            {
                                PilaEstados.Push(76);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Type")
                            {
                                PilaEstados.Push(9);
                                i--;
                            }
                            else if (Simbolos.Peek() == "FunctionDecl")
                            {
                                PilaEstados.Push(75);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Field")
                            {
                                PilaEstados.Push(73);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Field'")
                            {
                                PilaEstados.Push(84);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
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
                            AccionReduccion(39);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 74:
                        if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r35
                            AccionReduccion(35);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r35
                            AccionReduccion(35);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r35
                            AccionReduccion(35);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r35
                            AccionReduccion(35);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r35
                            AccionReduccion(35);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r35
                            AccionReduccion(35);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r35
                            AccionReduccion(35);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r35
                            AccionReduccion(35);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 75:
                        if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r36
                            AccionReduccion(36);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r36
                            AccionReduccion(36);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r36
                            AccionReduccion(36);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r36
                            AccionReduccion(36);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r36
                            AccionReduccion(36);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r36
                            AccionReduccion(36);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r36
                            AccionReduccion(36);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r36
                            AccionReduccion(36);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 76:
                        if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r37
                            AccionReduccion(37);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r37
                            AccionReduccion(37);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r37
                            AccionReduccion(37);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r37
                            AccionReduccion(37);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r37
                            AccionReduccion(37);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r37
                            AccionReduccion(37);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r37
                            AccionReduccion(37);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r37
                            AccionReduccion(37);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 77:
                        if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r31
                            AccionReduccion(31);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 78:
                        if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s85
                            PilaEstados.Push(85);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 79:
                        if (BanderaReduccion == true)
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
                                PilaEstados.Push(86);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
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
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 80:
                        if (BanderaReduccion == true)
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
                                PilaEstados.Push(87);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
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
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 81:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "ConstDecl")
                            {
                                PilaEstados.Push(89);
                                i--;
                            }
                            else if (Simbolos.Peek() == "LlamarConst")
                            {
                                PilaEstados.Push(88);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        //CONFLICTO 6
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //PRECEDENCIA DEL TERMINAL
                            var terPrec = PrecedenciaTerminales[Lab_ASDR.TokenList[i]];
                            //PRECEDENCIA DE LA PRODUCCION
                            var proPrec = 25;
                            if (proPrec > terPrec)
                            {
                                //r49
                                AccionReduccion(49);
                                i--;
                            }
                            else
                            {
                                //s11
                                PilaEstados.Push(11);
                                Simbolos.Push(Lab_ASDR.TokenList[i]);
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 82:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "VariableDecl")
                            {
                                PilaEstados.Push(82);
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
                                PilaEstados.Push(90);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        //CONFLICTO 7
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //PRECEDENCIA DEL TERMINAL
                            var terPrec = PrecedenciaTerminales[Lab_ASDR.TokenList[i]];
                            //PRECEDENCIA DE LA PRODUCCION
                            var proPrec = 26;
                            if (proPrec > terPrec)
                            {
                                //r47
                                AccionReduccion(47);
                                i--;
                            }
                            else
                            {
                                //s18
                                PilaEstados.Push(18);
                                Simbolos.Push(Lab_ASDR.TokenList[i]);
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        //CONFLICTO 8
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //PRECEDENCIA DEL TERMINAL
                            var terPrec = PrecedenciaTerminales[Lab_ASDR.TokenList[i]];
                            //PRECEDENCIA DE LA PRODUCCION
                            var proPrec = 26;
                            if (proPrec > terPrec)
                            {
                                //r47
                                AccionReduccion(47);
                                i--;
                            }
                            else
                            {
                                //s14
                                PilaEstados.Push(14);
                                Simbolos.Push(Lab_ASDR.TokenList[i]);
                            }
                        }
                        //CONFLICTO 9
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //PRECEDENCIA DEL TERMINAL
                            var terPrec = PrecedenciaTerminales[Lab_ASDR.TokenList[i]];
                            //PRECEDENCIA DE LA PRODUCCION
                            var proPrec = 26;
                            if (proPrec > terPrec)
                            {
                                //r47
                                AccionReduccion(47);
                                i--;
                            }
                            else
                            {
                                //s15
                                PilaEstados.Push(15);
                                Simbolos.Push(Lab_ASDR.TokenList[i]);
                            }
                        }
                        //CONFLICTO 10
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //PRECEDENCIA DEL TERMINAL
                            var terPrec = PrecedenciaTerminales[Lab_ASDR.TokenList[i]];
                            //PRECEDENCIA DE LA PRODUCCION
                            var proPrec = 26;
                            if (proPrec > terPrec)
                            {
                                //r47
                                AccionReduccion(47);
                                i--;
                            }
                            else
                            {
                                //s16
                                PilaEstados.Push(16);
                                Simbolos.Push(Lab_ASDR.TokenList[i]);
                            }
                        }
                        //CONFLICTO 11
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //PRECEDENCIA DEL TERMINAL
                            var terPrec = PrecedenciaTerminales[Lab_ASDR.TokenList[i]];
                            //PRECEDENCIA DE LA PRODUCCION
                            var proPrec = 26;
                            if (proPrec > terPrec)
                            {
                                //r47
                                AccionReduccion(47);
                                i--;
                            }
                            else
                            {
                                //s17
                                PilaEstados.Push(17);
                                Simbolos.Push(Lab_ASDR.TokenList[i]);
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r47
                            AccionReduccion(47);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 83:
                        if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r28
                            AccionReduccion(28);
                            i--;

                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r28
                            AccionReduccion(28);
                            i--;

                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r28
                            AccionReduccion(28);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r28
                            AccionReduccion(28);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r28
                            AccionReduccion(28);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r28
                            AccionReduccion(28);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r28
                            AccionReduccion(28);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r28
                            AccionReduccion(28);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r28
                            AccionReduccion(28);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r28
                            AccionReduccion(28);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 84:
                        if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r38
                            AccionReduccion(38);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 85:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "IMPLEMENTS'")
                            {
                                PilaEstados.Push(91);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //s78
                            PilaEstados.Push(78);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r34
                            AccionReduccion(34);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 86:
                        if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //s92
                            PilaEstados.Push(92);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 87:
                        if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //s93
                            PilaEstados.Push(93);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 88:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "StmtBlock")
                            {
                                PilaEstados.Push(103);
                                i--;
                            }
                            else if (Simbolos.Peek() == "LlamarStmt")
                            {
                                PilaEstados.Push(94);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Stmt")
                            {
                                PilaEstados.Push(95);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Stmt'")
                            {
                                PilaEstados.Push(96);
                                i--;
                            }
                            else if (Simbolos.Peek() == "ifStmt")
                            {
                                PilaEstados.Push(97);
                                i--;
                            }
                            else if (Simbolos.Peek() == "WhileStmt")
                            {
                                PilaEstados.Push(98);
                                i--;
                            }
                            else if (Simbolos.Peek() == "ForStmt")
                            {
                                PilaEstados.Push(99);
                                i--;
                            }
                            else if (Simbolos.Peek() == "ReturnStmt")
                            {
                                PilaEstados.Push(101);
                                i--;
                            }
                            else if (Simbolos.Peek() == "BreakStmt")
                            {
                                PilaEstados.Push(100);
                                i--;
                            }
                            else if (Simbolos.Peek() == "PrintStmt")
                            {
                                PilaEstados.Push(102);
                                i--;
                            }
                            else if (Simbolos.Peek() == "CallStmt")
                            {
                                PilaEstados.Push(104);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(122);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Expr")
                            {
                                PilaEstados.Push(105);
                                i--;
                            }
                            else if (Simbolos.Peek() == "A")
                            {
                                PilaEstados.Push(113);
                                i--;
                            }
                            else if (Simbolos.Peek() == "B")
                            {
                                PilaEstados.Push(114);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(118);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(120);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r62
                            AccionReduccion(62);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s112
                            PilaEstados.Push(112);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s121
                            PilaEstados.Push(121);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //s69
                            PilaEstados.Push(69);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r51
                            AccionReduccion(51);
                            i--;
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
                            //s119
                            PilaEstados.Push(119);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
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
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 89:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "LlamarConst")
                            {
                                PilaEstados.Push(130);
                                i--;
                            }
                            else if (Simbolos.Peek() == "ConstDecl")
                            {
                                PilaEstados.Push(89);
                                i--;
                            }
                        }
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        //CONFLICTO 12
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //PRECEDENCIA DEL TERMINAL
                            var terPrec = PrecedenciaTerminales[Lab_ASDR.TokenList[i]];
                            //PRECEDENCIA DE LA PRODUCCION
                            var proPrec = 25;
                            if (proPrec > terPrec)
                            {
                                //r49
                                AccionReduccion(49);
                                i--;
                            }
                            else
                            {
                                //s11
                                PilaEstados.Push(11);
                                Simbolos.Push(Lab_ASDR.TokenList[i]);
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r49
                            AccionReduccion(49);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 90:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r46
                            AccionReduccion(46);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r46
                            AccionReduccion(46);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r46
                            AccionReduccion(46);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r46
                            AccionReduccion(46);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r46
                            AccionReduccion(46);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r46
                            AccionReduccion(46);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r46
                            AccionReduccion(46);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r46
                            AccionReduccion(46);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r46
                            AccionReduccion(46);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r46
                            AccionReduccion(46);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r46
                            AccionReduccion(46);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r46
                            AccionReduccion(46);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r46
                            AccionReduccion(46);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r46
                            AccionReduccion(46);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r46
                            AccionReduccion(46);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r46
                            AccionReduccion(46);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r46
                            AccionReduccion(46);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r46
                            AccionReduccion(46);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r46
                            AccionReduccion(46);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r46
                            AccionReduccion(46);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r46
                            AccionReduccion(46);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r46
                            AccionReduccion(46);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r46
                            AccionReduccion(46);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r46
                            AccionReduccion(46);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r46
                            AccionReduccion(46);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r46
                            AccionReduccion(46);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r46
                            AccionReduccion(46);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r46
                            AccionReduccion(46);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r46
                            AccionReduccion(46);
                            i--;
                            //revisar
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 91:
                        if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r33
                            AccionReduccion(33);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 92:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //s131
                            PilaEstados.Push(131);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 93:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //s132
                            PilaEstados.Push(132);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 94:
                        if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //s133
                            PilaEstados.Push(133);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 95:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "StmtBlock")
                            {
                                PilaEstados.Push(103);
                                i--;
                            }
                            else if (Simbolos.Peek() == "LlamarStmt")
                            {
                                PilaEstados.Push(134);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Stmt")
                            {
                                PilaEstados.Push(95);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Stmt'")
                            {
                                PilaEstados.Push(96);
                                i--;
                            }
                            else if (Simbolos.Peek() == "ifStmt")
                            {
                                PilaEstados.Push(97);
                                i--;
                            }
                            else if (Simbolos.Peek() == "WhileStmt")
                            {
                                PilaEstados.Push(98);
                                i--;
                            }
                            else if (Simbolos.Peek() == "ForStmt")
                            {
                                PilaEstados.Push(99);
                                i--;
                            }
                            else if (Simbolos.Peek() == "ReturnStmt")
                            {
                                PilaEstados.Push(101);
                                i--;
                            }
                            else if (Simbolos.Peek() == "BreakStmt")
                            {
                                PilaEstados.Push(100);
                                i--;
                            }
                            else if (Simbolos.Peek() == "PrintStmt")
                            {
                                PilaEstados.Push(102);
                                i--;
                            }
                            else if (Simbolos.Peek() == "CallStmt")
                            {
                                PilaEstados.Push(104);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(122);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Expr")
                            {
                                PilaEstados.Push(105);
                                i--;
                            }
                            else if (Simbolos.Peek() == "A")
                            {
                                PilaEstados.Push(113);
                                i--;
                            }
                            else if (Simbolos.Peek() == "B")
                            {
                                PilaEstados.Push(114);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(118);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(120);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r62
                            AccionReduccion(62);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s112
                            PilaEstados.Push(112);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s121
                            PilaEstados.Push(121);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //s69
                            PilaEstados.Push(69);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r51
                            AccionReduccion(51);
                            i--;
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
                            //s119
                            PilaEstados.Push(119);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
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
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 96:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //s135
                            PilaEstados.Push(135);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 97:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r53
                            AccionReduccion(53);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r53
                            AccionReduccion(53);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r53
                            AccionReduccion(53);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r53
                            AccionReduccion(53);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r53
                            AccionReduccion(53);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r53
                            AccionReduccion(53);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r53
                            AccionReduccion(53);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r53
                            AccionReduccion(53);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r53
                            AccionReduccion(53);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r53
                            AccionReduccion(53);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r53
                            AccionReduccion(53);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r53
                            AccionReduccion(53);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r53
                            AccionReduccion(53);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r53
                            AccionReduccion(53);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r53
                            AccionReduccion(53);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r53
                            AccionReduccion(53);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r53
                            AccionReduccion(53);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r53
                            AccionReduccion(53);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r53
                            AccionReduccion(53);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r53
                            AccionReduccion(53);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 98:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r54
                            AccionReduccion(54);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r54
                            AccionReduccion(54);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r54
                            AccionReduccion(54);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r54
                            AccionReduccion(54);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r54
                            AccionReduccion(54);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r54
                            AccionReduccion(54);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r54
                            AccionReduccion(54);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r54
                            AccionReduccion(54);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r54
                            AccionReduccion(54);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r54
                            AccionReduccion(54);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r54
                            AccionReduccion(54);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r54
                            AccionReduccion(54);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r54
                            AccionReduccion(54);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r54
                            AccionReduccion(54);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r54
                            AccionReduccion(54);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r54
                            AccionReduccion(54);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r54
                            AccionReduccion(54);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r54
                            AccionReduccion(54);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r54
                            AccionReduccion(54);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r54
                            AccionReduccion(54);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 99:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r55
                            AccionReduccion(55);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r55
                            AccionReduccion(55);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r55
                            AccionReduccion(55);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r55
                            AccionReduccion(55);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r55
                            AccionReduccion(55);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r55
                            AccionReduccion(55);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r55
                            AccionReduccion(55);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r55
                            AccionReduccion(55);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r55
                            AccionReduccion(55);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r55
                            AccionReduccion(55);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r55
                            AccionReduccion(55);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r55
                            AccionReduccion(55);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r55
                            AccionReduccion(55);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r55
                            AccionReduccion(55);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r55
                            AccionReduccion(55);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r55
                            AccionReduccion(55);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r55
                            AccionReduccion(55);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r55
                            AccionReduccion(55);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r55
                            AccionReduccion(55);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r55
                            AccionReduccion(55);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 100:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r56
                            AccionReduccion(56);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r56
                            AccionReduccion(56);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r56
                            AccionReduccion(56);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r56
                            AccionReduccion(56);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r56
                            AccionReduccion(56);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r56
                            AccionReduccion(56);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r56
                            AccionReduccion(56);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r56
                            AccionReduccion(56);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r56
                            AccionReduccion(56);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r56
                            AccionReduccion(56);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r56
                            AccionReduccion(56);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r56
                            AccionReduccion(56);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r56
                            AccionReduccion(56);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r56
                            AccionReduccion(56);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r56
                            AccionReduccion(56);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r56
                            AccionReduccion(56);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r56
                            AccionReduccion(56);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r56
                            AccionReduccion(56);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r56
                            AccionReduccion(56);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r56
                            AccionReduccion(56);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 101:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r57
                            AccionReduccion(57);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r57
                            AccionReduccion(57);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r57
                            AccionReduccion(57);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r57
                            AccionReduccion(57);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r57
                            AccionReduccion(57);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r57
                            AccionReduccion(57);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r57
                            AccionReduccion(57);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r57
                            AccionReduccion(57);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r57
                            AccionReduccion(57);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r57
                            AccionReduccion(57);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r57
                            AccionReduccion(57);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r57
                            AccionReduccion(57);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r57
                            AccionReduccion(57);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r57
                            AccionReduccion(57);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r57
                            AccionReduccion(57);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r57
                            AccionReduccion(57);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r57
                            AccionReduccion(57);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r57
                            AccionReduccion(57);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r57
                            AccionReduccion(57);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r57
                            AccionReduccion(57);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 102:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r58
                            AccionReduccion(58);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r58
                            AccionReduccion(58);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r58
                            AccionReduccion(58);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r58
                            AccionReduccion(58);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r58
                            AccionReduccion(58);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r58
                            AccionReduccion(58);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r58
                            AccionReduccion(58);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r58
                            AccionReduccion(58);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r58
                            AccionReduccion(58);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r58
                            AccionReduccion(58);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r58
                            AccionReduccion(58);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r58
                            AccionReduccion(58);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r58
                            AccionReduccion(58);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r58
                            AccionReduccion(58);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r58
                            AccionReduccion(58);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r58
                            AccionReduccion(58);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r58
                            AccionReduccion(58);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r58
                            AccionReduccion(58);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r58
                            AccionReduccion(58);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r58
                            AccionReduccion(58);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 103:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r59
                            AccionReduccion(59);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r59
                            AccionReduccion(59);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r59
                            AccionReduccion(59);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r59
                            AccionReduccion(59);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r59
                            AccionReduccion(59);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r59
                            AccionReduccion(59);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r59
                            AccionReduccion(59);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r59
                            AccionReduccion(59);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r59
                            AccionReduccion(59);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r59
                            AccionReduccion(59);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r59
                            AccionReduccion(59);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r59
                            AccionReduccion(59);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r59
                            AccionReduccion(59);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r59
                            AccionReduccion(59);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r59
                            AccionReduccion(59);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r59
                            AccionReduccion(59);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r59
                            AccionReduccion(59);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r59
                            AccionReduccion(59);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r59
                            AccionReduccion(59);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r59
                            AccionReduccion(59);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 104:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r60
                            AccionReduccion(60);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 105:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r61
                            AccionReduccion(61);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 106:
                        if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s136
                            PilaEstados.Push(136);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 107:
                        if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s137
                            PilaEstados.Push(137);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 108:
                        if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s138
                            PilaEstados.Push(138);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 109:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //s139
                            PilaEstados.Push(139);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 110:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(122);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Expr")
                            {
                                PilaEstados.Push(140);
                                i--;
                            }
                            else if (Simbolos.Peek() == "A")
                            {
                                PilaEstados.Push(113);
                                i--;
                            }
                            else if (Simbolos.Peek() == "B")
                            {
                                PilaEstados.Push(114);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(118);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(120);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s141
                            PilaEstados.Push(141);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s121
                            PilaEstados.Push(121);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s119
                            PilaEstados.Push(119);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
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
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 111:
                        if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s142
                            PilaEstados.Push(142);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 112:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "X'")
                            {
                                PilaEstados.Push(145);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //PRECEDENCIA DEL TERMINAL
                            var terPrec = PrecedenciaTerminales[Lab_ASDR.TokenList[i]];
                            //PRECEDENCIA DE LA PRODUCCION
                            var proPrec = 11;
                            if (proPrec > terPrec)
                            {
                                //r111
                                AccionReduccion(111);
                                i--;
                            }
                            else
                            {
                                //s143
                                PilaEstados.Push(143);
                                Simbolos.Push(Lab_ASDR.TokenList[i]);
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //PRECEDENCIA DEL TERMINAL
                            var terPrec = PrecedenciaTerminales[Lab_ASDR.TokenList[i]];
                            //PRECEDENCIA DE LA PRODUCCION
                            var proPrec = 11;
                            if (proPrec > terPrec)
                            {
                                //r111
                                AccionReduccion(111);
                                i--;
                            }
                            else
                            {
                                //s144
                                PilaEstados.Push(144);
                                Simbolos.Push(Lab_ASDR.TokenList[i]);
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;                     }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        //CONFLICTO 13
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {

                            //r111
                            AccionReduccion(111);
                            i--;

                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "=")
                        {
                            //s146
                            PilaEstados.Push(146);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 113:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Expr'")
                            {
                                PilaEstados.Push(147);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;

                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        //CONFLICTO 14
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //PRECEDENCIA DEL TERMINAL
                            var terPrec = PrecedenciaTerminales[Lab_ASDR.TokenList[i]];
                            //PRECEDENCIA DE LA PRODUCCION
                            var proPrec = 9;
                            if (proPrec > terPrec)
                            {
                                //r84
                                AccionReduccion(84);
                                i--;
                            }
                            else
                            {
                                //s148
                                PilaEstados.Push(148);
                                Simbolos.Push(Lab_ASDR.TokenList[i]);
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;

                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 114:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "A'")
                            {
                                PilaEstados.Push(149);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //PRECEDENCIA DEL TERMINAL
                            var terPrec = PrecedenciaTerminales[Lab_ASDR.TokenList[i]];
                            //PRECEDENCIA DE LA PRODUCCION
                            var proPrec = 7;
                            if (proPrec > terPrec)
                            {
                                //r87
                                AccionReduccion(87);
                                i--;
                            }
                            else
                            {
                                //s150
                                PilaEstados.Push(150);
                                Simbolos.Push(Lab_ASDR.TokenList[i]);
                            }
                        }
                        //CONFLICTO 15
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            
                             //r87
                            AccionReduccion(87);
                            i--;
                        }
                        //CONFLICTO 16
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
         
                                //r87
                                AccionReduccion(87);
                                i--;
           
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;

                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 115:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "B'")
                            {
                                PilaEstados.Push(151);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {

                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r91
                            AccionReduccion(89);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r91
                            AccionReduccion(89);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //PRECEDENCIA DEL TERMINAL
                            var terPrec = PrecedenciaTerminales[Lab_ASDR.TokenList[i]];
                            //PRECEDENCIA DE LA PRODUCCION
                            var proPrec = 7;
                            if (proPrec > terPrec)
                            {
                                //r91
                                AccionReduccion(91);
                                i--;
                            }
                            else
                            {
                                //s152
                                PilaEstados.Push(152);
                                Simbolos.Push(Lab_ASDR.TokenList[i]);
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //PRECEDENCIA DEL TERMINAL
                            var terPrec = PrecedenciaTerminales[Lab_ASDR.TokenList[i]];
                            //PRECEDENCIA DE LA PRODUCCION
                            var proPrec = 7;
                            if (proPrec > terPrec)
                            {
                                //r91
                                AccionReduccion(91);
                                i--;
                            }
                            else
                            {
                                //s153
                                PilaEstados.Push(153);
                                Simbolos.Push(Lab_ASDR.TokenList[i]);
                            }
                        }
                        //CONFLICTO 17
                        else if (Lab_ASDR.TokenList[i] == "-")
                         {

                                //r91
                                AccionReduccion(91);
                                i--;

                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;

                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 116:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "C'")
                            {
                                PilaEstados.Push(154);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //PRECEDENCIA DEL TERMINAL
                            var terPrec = PrecedenciaTerminales[Lab_ASDR.TokenList[i]];
                            //PRECEDENCIA DE LA PRODUCCION
                            var proPrec = 3;
                            if (proPrec > terPrec)
                            {
                                //r94
                                AccionReduccion(94);
                                i--;
                            }
                            else
                            {
                                //s155
                                PilaEstados.Push(155);
                                Simbolos.Push(Lab_ASDR.TokenList[i]);
                            }
                        }
                        //CONFLICTO 18
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {

                                //r94
                                AccionReduccion(94);
                                i--;
           
                        }
                        //CONFLICTO 19
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
        
                                //r94
                                AccionReduccion(94);
                                i--;
                
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;

                    case 117:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "D'")
                            {
                                PilaEstados.Push(156);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }

                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                      
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        //CONFLICTO 20
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {

                                //r98
                                AccionReduccion(98);
                                i--;
    
                        }
                        //CONFLICTO 21
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //PRECEDENCIA DEL TERMINAL
                            var terPrec = PrecedenciaTerminales[Lab_ASDR.TokenList[i]];
                            //PRECEDENCIA DE LA PRODUCCION
                            var proPrec = 1;
                            if (proPrec > terPrec)
                            {
                                //r98
                                AccionReduccion(98);
                                i--;
                            }
                            else
                            {
                                //s157
                                PilaEstados.Push(157);
                                Simbolos.Push(Lab_ASDR.TokenList[i]);
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //PRECEDENCIA DEL TERMINAL
                            var terPrec = PrecedenciaTerminales[Lab_ASDR.TokenList[i]];
                            //PRECEDENCIA DE LA PRODUCCION
                            var proPrec = 1;
                            if (proPrec > terPrec)
                            {
                                //r98
                                AccionReduccion(98);
                                i--;
                            }
                            else
                            {
                                //s158
                                PilaEstados.Push(158);
                                Simbolos.Push(Lab_ASDR.TokenList[i]);
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;

                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 118:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "E'")
                            {
                                PilaEstados.Push(159);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }

                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }

                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        //CONFLICTO 20
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {

                            //r102
                            AccionReduccion(102);
                            i--;

                        }
                        //CONFLICTO 21
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //PRECEDENCIA DEL TERMINAL
                            var terPrec = PrecedenciaTerminales[Lab_ASDR.TokenList[i]];
                            //PRECEDENCIA DE LA PRODUCCION
                            var proPrec = 1;
                            if (proPrec > terPrec)
                            {
                                //r102
                                AccionReduccion(102);
                                i--;
                            }
                            else
                            {
                                //s160
                                PilaEstados.Push(160);
                                Simbolos.Push(Lab_ASDR.TokenList[i]);
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //PRECEDENCIA DEL TERMINAL
                            var terPrec = PrecedenciaTerminales[Lab_ASDR.TokenList[i]];
                            //PRECEDENCIA DE LA PRODUCCION
                            var proPrec = 1;
                            if (proPrec > terPrec)
                            {
                                //r102
                                AccionReduccion(102);
                                i--;
                            }
                            else
                            {
                                //s161
                                PilaEstados.Push(161);
                                Simbolos.Push(Lab_ASDR.TokenList[i]);
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;

                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 119:
                        if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s162
                            PilaEstados.Push(162);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 120:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r104
                            AccionReduccion(104);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r104
                            AccionReduccion(104);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r104
                            AccionReduccion(104);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r104
                            AccionReduccion(104);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r104
                            AccionReduccion(104);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r104
                            AccionReduccion(104);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r104
                            AccionReduccion(104);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r104
                            AccionReduccion(104);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r104
                            AccionReduccion(104);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r104
                            AccionReduccion(104);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r104
                            AccionReduccion(104);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r104
                            AccionReduccion(104);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r104
                            AccionReduccion(104);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r104
                            AccionReduccion(104);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r104
                            AccionReduccion(104);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r104
                            AccionReduccion(104);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r104
                            AccionReduccion(104);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r104
                            AccionReduccion(104);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r104
                            AccionReduccion(104);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r104
                            AccionReduccion(104);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r104
                            AccionReduccion(104);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r104
                            AccionReduccion(104);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r104
                            AccionReduccion(104);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r104
                            AccionReduccion(104);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r104
                            AccionReduccion(104);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r104
                            AccionReduccion(104);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r104
                            AccionReduccion(104);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r104
                            AccionReduccion(104);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r104
                            AccionReduccion(104);
                            i--;

                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r104
                            AccionReduccion(104);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 121:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(122);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Expr")
                            {
                                PilaEstados.Push(163);
                                i--;
                            }
                            else if (Simbolos.Peek() == "A")
                            {
                                PilaEstados.Push(113);
                                i--;
                            }
                            else if (Simbolos.Peek() == "B")
                            {
                                PilaEstados.Push(114);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(118);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(120);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s141
                            PilaEstados.Push(141);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s121
                            PilaEstados.Push(121);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s119
                            PilaEstados.Push(119);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //s128
                            PilaEstados.Push(128);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
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
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 122:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r106
                            AccionReduccion(106);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r106
                            AccionReduccion(106);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r106
                            AccionReduccion(106);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r106
                            AccionReduccion(106);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r106
                            AccionReduccion(106);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r106
                            AccionReduccion(106);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r106
                            AccionReduccion(106);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r106
                            AccionReduccion(106);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r106
                            AccionReduccion(106);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r106
                            AccionReduccion(106);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r106
                            AccionReduccion(106);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r106
                            AccionReduccion(106);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r106
                            AccionReduccion(106);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r106
                            AccionReduccion(106);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r106
                            AccionReduccion(106);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r106
                            AccionReduccion(106);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r106
                            AccionReduccion(106);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r106
                            AccionReduccion(106);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r106
                            AccionReduccion(106);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r106
                            AccionReduccion(106);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r106
                            AccionReduccion(106);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r106
                            AccionReduccion(106);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r106
                            AccionReduccion(106);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r106
                            AccionReduccion(106);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r106
                            AccionReduccion(106);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r106
                            AccionReduccion(106);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r106
                            AccionReduccion(106);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r106
                            AccionReduccion(106);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r106
                            AccionReduccion(106);
                            i--;

                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r106
                            AccionReduccion(106);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 123:
                        if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s164
                            PilaEstados.Push(164);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 124:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r108
                            AccionReduccion(108);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r108
                            AccionReduccion(108);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r108
                            AccionReduccion(108);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r108
                            AccionReduccion(108);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r108
                            AccionReduccion(108);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r108
                            AccionReduccion(108);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r108
                            AccionReduccion(108);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r108
                            AccionReduccion(108);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r108
                            AccionReduccion(108);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r108
                            AccionReduccion(108);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r108
                            AccionReduccion(108);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r108
                            AccionReduccion(108);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r108
                            AccionReduccion(108);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r108
                            AccionReduccion(108);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r108
                            AccionReduccion(108);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r108
                            AccionReduccion(108);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r108
                            AccionReduccion(108);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r108
                            AccionReduccion(108);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r108
                            AccionReduccion(108);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r108
                            AccionReduccion(108);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r108
                            AccionReduccion(108);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r108
                            AccionReduccion(108);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r108
                            AccionReduccion(108);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r108
                            AccionReduccion(108);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r108
                            AccionReduccion(108);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r108
                            AccionReduccion(108);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r108
                            AccionReduccion(108);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r108
                            AccionReduccion(108);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r108
                            AccionReduccion(108);
                            i--;

                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r108
                            AccionReduccion(108);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 125:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r77
                            AccionReduccion(77);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r77
                            AccionReduccion(77);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r77
                            AccionReduccion(77);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r77
                            AccionReduccion(77);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r77
                            AccionReduccion(77);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r77
                            AccionReduccion(77);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r77
                            AccionReduccion(77);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r77
                            AccionReduccion(77);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r77
                            AccionReduccion(77);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r77
                            AccionReduccion(77);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r77
                            AccionReduccion(77);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r77
                            AccionReduccion(77);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r77
                            AccionReduccion(77);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r77
                            AccionReduccion(77);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r77
                            AccionReduccion(77);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r77
                            AccionReduccion(77);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r77
                            AccionReduccion(77);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r77
                            AccionReduccion(77);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r77
                            AccionReduccion(77);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r77
                            AccionReduccion(77);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r77
                            AccionReduccion(77);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r77
                            AccionReduccion(77);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r77
                            AccionReduccion(77);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r77
                            AccionReduccion(77);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r77
                            AccionReduccion(77);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r77
                            AccionReduccion(77);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r77
                            AccionReduccion(77);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r77
                            AccionReduccion(77);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r77
                            AccionReduccion(77);
                            i--;

                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r77
                            AccionReduccion(77);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 126:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r78
                            AccionReduccion(78);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r78
                            AccionReduccion(78);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r78
                            AccionReduccion(78);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r78
                            AccionReduccion(78);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r78
                            AccionReduccion(78);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r78
                            AccionReduccion(78);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r78
                            AccionReduccion(78);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r78
                            AccionReduccion(78);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r78
                            AccionReduccion(78);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r78
                            AccionReduccion(78);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r78
                            AccionReduccion(78);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r78
                            AccionReduccion(78);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r78
                            AccionReduccion(78);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r78
                            AccionReduccion(78);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r78
                            AccionReduccion(78);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r78
                            AccionReduccion(78);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r78
                            AccionReduccion(78);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r78
                            AccionReduccion(78);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r78
                            AccionReduccion(78);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r78
                            AccionReduccion(78);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r78
                            AccionReduccion(78);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r78
                            AccionReduccion(78);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r78
                            AccionReduccion(78);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r78
                            AccionReduccion(78);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r78
                            AccionReduccion(78);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r78
                            AccionReduccion(78);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r78
                            AccionReduccion(78);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r78
                            AccionReduccion(78);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r78
                            AccionReduccion(78);
                            i--;

                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r78
                            AccionReduccion(78);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 127:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r79
                            AccionReduccion(79);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r79
                            AccionReduccion(79);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r79
                            AccionReduccion(79);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r79
                            AccionReduccion(79);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r79
                            AccionReduccion(79);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r79
                            AccionReduccion(79);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r79
                            AccionReduccion(79);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r79
                            AccionReduccion(79);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r79
                            AccionReduccion(79);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r79
                            AccionReduccion(79);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r79
                            AccionReduccion(79);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r79
                            AccionReduccion(79);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r79
                            AccionReduccion(79);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r79
                            AccionReduccion(79);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r79
                            AccionReduccion(79);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r79
                            AccionReduccion(79);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r79
                            AccionReduccion(79);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r79
                            AccionReduccion(79);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r79
                            AccionReduccion(79);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r79
                            AccionReduccion(79);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r79
                            AccionReduccion(79);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r79
                            AccionReduccion(79);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r79
                            AccionReduccion(79);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r79
                            AccionReduccion(79);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r79
                            AccionReduccion(79);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r79
                            AccionReduccion(79);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r79
                            AccionReduccion(79);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r79
                            AccionReduccion(79);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r79
                            AccionReduccion(79);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r79
                            AccionReduccion(79);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 128:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r80
                            AccionReduccion(80);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r80
                            AccionReduccion(80);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r80
                            AccionReduccion(80);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r80
                            AccionReduccion(80);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r80
                            AccionReduccion(80);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r80
                            AccionReduccion(80);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r80
                            AccionReduccion(80);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r80
                            AccionReduccion(80);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r80
                            AccionReduccion(80);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r80
                            AccionReduccion(80);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r80
                            AccionReduccion(80);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r80
                            AccionReduccion(80);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r80
                            AccionReduccion(80);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r80
                            AccionReduccion(80);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r80
                            AccionReduccion(80);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r80
                            AccionReduccion(80);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r80
                            AccionReduccion(80);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r80
                            AccionReduccion(80);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r80
                            AccionReduccion(80);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r80
                            AccionReduccion(80);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r80
                            AccionReduccion(80);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r80
                            AccionReduccion(80);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r80
                            AccionReduccion(80);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r80
                            AccionReduccion(80);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r80
                            AccionReduccion(80);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r80
                            AccionReduccion(80);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r80
                            AccionReduccion(80);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r80
                            AccionReduccion(80);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r80
                            AccionReduccion(80);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r80
                            AccionReduccion(80);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 129:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r81
                            AccionReduccion(81);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r81
                            AccionReduccion(81);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r81
                            AccionReduccion(81);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r81
                            AccionReduccion(81);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r81
                            AccionReduccion(81);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r81
                            AccionReduccion(81);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r81
                            AccionReduccion(81);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r81
                            AccionReduccion(81);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r81
                            AccionReduccion(81);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r81
                            AccionReduccion(81);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r81
                            AccionReduccion(81);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r81
                            AccionReduccion(81);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r81
                            AccionReduccion(81);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r81
                            AccionReduccion(81);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r81
                            AccionReduccion(81);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r81
                            AccionReduccion(81);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r81
                            AccionReduccion(81);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r81
                            AccionReduccion(81);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r81
                            AccionReduccion(81);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r81
                            AccionReduccion(81);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r81
                            AccionReduccion(81);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r81
                            AccionReduccion(81);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r81
                            AccionReduccion(81);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r81
                            AccionReduccion(81);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r81
                            AccionReduccion(81);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r81
                            AccionReduccion(81);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r81
                            AccionReduccion(81);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r81
                            AccionReduccion(81);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r81
                            AccionReduccion(81);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r81
                            AccionReduccion(81);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 130:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r48
                            AccionReduccion(48);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r48
                            AccionReduccion(48);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r48
                            AccionReduccion(48);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r48
                            AccionReduccion(48);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r48
                            AccionReduccion(48);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r48
                            AccionReduccion(48);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r48
                            AccionReduccion(48);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r48
                            AccionReduccion(48);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r48
                            AccionReduccion(48);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r48
                            AccionReduccion(48);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r48
                            AccionReduccion(48);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r48
                            AccionReduccion(48);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r48
                            AccionReduccion(48);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r48
                            AccionReduccion(48);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r48
                            AccionReduccion(48);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r48
                            AccionReduccion(48);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r48
                            AccionReduccion(48);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r48
                            AccionReduccion(48);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r48
                            AccionReduccion(48);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r48
                            AccionReduccion(48);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r48
                            AccionReduccion(48);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r48
                            AccionReduccion(48);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r48
                            AccionReduccion(48);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r48
                            AccionReduccion(48);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r48
                            AccionReduccion(48);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {

                            //r48
                            AccionReduccion(48);
                            i--;
                        }
                        
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r48
                            AccionReduccion(48);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r48
                            AccionReduccion(48);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r48
                            AccionReduccion(48);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 131:
                        if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r43
                            AccionReduccion(43);
                            i--;
                        }

                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r43
                            AccionReduccion(43);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r43
                            AccionReduccion(43);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r43
                            AccionReduccion(43);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r43
                            AccionReduccion(43);
                            i--;
                        }

                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r43
                            AccionReduccion(43);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r43
                            AccionReduccion(43);
                            i--;
                        }
                        
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 132:
                        if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r44
                            AccionReduccion(44);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r44
                            AccionReduccion(44);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r44
                            AccionReduccion(44);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r44
                            AccionReduccion(44);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r44
                            AccionReduccion(44);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r44
                            AccionReduccion(44);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r44
                            AccionReduccion(44);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 133:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r45
                            AccionReduccion(45);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r45
                            AccionReduccion(45);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "static")
                        {
                            //r45
                            AccionReduccion(45);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "int")
                        {
                            //r45
                            AccionReduccion(45);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "double")
                        {
                            //r45
                            AccionReduccion(45);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "string")
                        {
                            //r45
                            AccionReduccion(45);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolean")
                        {
                            //r45
                            AccionReduccion(45);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r45
                            AccionReduccion(45);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "void")
                        {
                            //r45
                            AccionReduccion(45);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "class")
                        {
                            //r45
                            AccionReduccion(45);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r45
                            AccionReduccion(45);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r45
                            AccionReduccion(45);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "interface")
                        {
                            //r45
                            AccionReduccion(45);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r45
                            AccionReduccion(45);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r45
                            AccionReduccion(45);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r45
                            AccionReduccion(45);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r45
                            AccionReduccion(45);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r45
                            AccionReduccion(45);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r45
                            AccionReduccion(45);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r45
                            AccionReduccion(45);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r45
                            AccionReduccion(45);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r45
                            AccionReduccion(45);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r45
                            AccionReduccion(45);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r45
                            AccionReduccion(45);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r45
                            AccionReduccion(45);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {

                            //r45
                            AccionReduccion(45);
                            i--;
                        }

                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r45
                            AccionReduccion(45);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r45
                            AccionReduccion(45);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "$")
                        {
                            //r45
                            AccionReduccion(45);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 134:
                        if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r50
                            AccionReduccion(50);
                            i--;
                        }
                        
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 135:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r52
                            AccionReduccion(52);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r52
                            AccionReduccion(52);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r52
                            AccionReduccion(52);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r52
                            AccionReduccion(52);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r52
                            AccionReduccion(52);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r52
                            AccionReduccion(52);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r52
                            AccionReduccion(52);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r52
                            AccionReduccion(52);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r52
                            AccionReduccion(52);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r52
                            AccionReduccion(52);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r52
                            AccionReduccion(52);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r52
                            AccionReduccion(52);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r52
                            AccionReduccion(52);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r52
                            AccionReduccion(52);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r52
                            AccionReduccion(52);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r52
                            AccionReduccion(52);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r52
                            AccionReduccion(52);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r52
                            AccionReduccion(52);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r52
                            AccionReduccion(52);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r52
                            AccionReduccion(52);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 136:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(122);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Expr")
                            {
                                PilaEstados.Push(165);
                                i--;
                            }
                            else if (Simbolos.Peek() == "A")
                            {
                                PilaEstados.Push(113);
                                i--;
                            }
                            else if (Simbolos.Peek() == "B")
                            {
                                PilaEstados.Push(114);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(118);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(120);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s141

                            PilaEstados.Push(141);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s121
                            PilaEstados.Push(121);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s119
                            PilaEstados.Push(119);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
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
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 137:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(122);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Expr")
                            {
                                PilaEstados.Push(166);
                                i--;
                            }
                            else if (Simbolos.Peek() == "A")
                            {
                                PilaEstados.Push(113);
                                i--;
                            }
                            else if (Simbolos.Peek() == "B")
                            {
                                PilaEstados.Push(114);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(118);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(120);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s141
                            PilaEstados.Push(141);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s121
                            PilaEstados.Push(121);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s119
                            PilaEstados.Push(119);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
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
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s124
                            PilaEstados.Push(143);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 138:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(122);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Expr")
                            {
                                PilaEstados.Push(167);
                                i--;
                            }
                            else if (Simbolos.Peek() == "A")
                            {
                                PilaEstados.Push(113);
                                i--;
                            }
                            else if (Simbolos.Peek() == "B")
                            {
                                PilaEstados.Push(114);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(118);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(120);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s141
                            PilaEstados.Push(141);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s121
                            PilaEstados.Push(121);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s119
                            PilaEstados.Push(119);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
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
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 139:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r69
                            AccionReduccion(69);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r69
                            AccionReduccion(69);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r69
                            AccionReduccion(69);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r69
                            AccionReduccion(69);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r69
                            AccionReduccion(69);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r69
                            AccionReduccion(69);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r69
                            AccionReduccion(69);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r69
                            AccionReduccion(69);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r69
                            AccionReduccion(69);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r69
                            AccionReduccion(69);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r69
                            AccionReduccion(69);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r69
                            AccionReduccion(69);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r69
                            AccionReduccion(69);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r69
                            AccionReduccion(69);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r69
                            AccionReduccion(69);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r69
                            AccionReduccion(69);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r69
                            AccionReduccion(69);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r69
                            AccionReduccion(69);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r69
                            AccionReduccion(69);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r69
                            AccionReduccion(69);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 140:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //s168
                            PilaEstados.Push(168);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 141:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            AccionReduccion(111);
                            i--;
                            //r111
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "=")
                        {
                            //s146
                            PilaEstados.Push(146);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 143:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Actuals")
                            {
                                PilaEstados.Push(170);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(122);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Expr")
                            {
                                PilaEstados.Push(171);
                                i--;
                            }
                            else if (Simbolos.Peek() == "A")
                            {
                                PilaEstados.Push(113);
                                i--;
                            }
                            else if (Simbolos.Peek() == "B")
                            {
                                PilaEstados.Push(114);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(118);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(120);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s143
                            PilaEstados.Push(143);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s121
                            PilaEstados.Push(121);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s119
                            PilaEstados.Push(119);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
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
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 144:
                        if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s172
                            PilaEstados.Push(172);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 145:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r109
                            AccionReduccion(109);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r109
                            AccionReduccion(109);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r109
                            AccionReduccion(109);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r109
                            AccionReduccion(109);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r109
                            AccionReduccion(109);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r109
                            AccionReduccion(109);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r109
                            AccionReduccion(109);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r109
                            AccionReduccion(109);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r109
                            AccionReduccion(109);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r109
                            AccionReduccion(109);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r109
                            AccionReduccion(109);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r109
                            AccionReduccion(109);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r109
                            AccionReduccion(109);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r109
                            AccionReduccion(109);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r109
                            AccionReduccion(109);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r109
                            AccionReduccion(109);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r109
                            AccionReduccion(109);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r109
                            AccionReduccion(109);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r109
                            AccionReduccion(109);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r109
                            AccionReduccion(109);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r109
                            AccionReduccion(109);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r109
                            AccionReduccion(109);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r109
                            AccionReduccion(109);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r109
                            AccionReduccion(109);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r109
                            AccionReduccion(109);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r109
                            AccionReduccion(109);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r109
                            AccionReduccion(109);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r109
                            AccionReduccion(109);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r109
                            AccionReduccion(109);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {

                            //r109
                            AccionReduccion(109);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 146:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(122);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Expr")
                            {
                                PilaEstados.Push(173);
                                i--;
                            }
                            else if (Simbolos.Peek() == "A")
                            {
                                PilaEstados.Push(113);
                                i--;
                            }
                            else if (Simbolos.Peek() == "B")
                            {
                                PilaEstados.Push(114);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(118);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(120);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s141
                            PilaEstados.Push(141);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s121
                            PilaEstados.Push(121);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s119
                            PilaEstados.Push(119);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
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
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 147:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r82
                            AccionReduccion(82);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            AccionReduccion(82);
                            i--;
                            //r82
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r82
                            AccionReduccion(82);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r82
                            AccionReduccion(82);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r82
                            AccionReduccion(82);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r82
                            AccionReduccion(82);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r82
                            AccionReduccion(82);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r82
                            AccionReduccion(82);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r82
                            AccionReduccion(82);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r82
                            AccionReduccion(82);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r82
                            AccionReduccion(82);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r82
                            AccionReduccion(82);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r82
                            AccionReduccion(82);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r82
                            AccionReduccion(82);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r82
                            AccionReduccion(82);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r82
                            AccionReduccion(82);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r82
                            AccionReduccion(82);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r82
                            AccionReduccion(82);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r82
                            AccionReduccion(82);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r82
                            AccionReduccion(82);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r82
                            AccionReduccion(82);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r82
                            AccionReduccion(82);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r82
                            AccionReduccion(82);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r82
                            AccionReduccion(82);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r82
                            AccionReduccion(82);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r82
                            AccionReduccion(82);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r82
                            AccionReduccion(82);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r82
                            AccionReduccion(82);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r82
                            AccionReduccion(82);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r82
                            AccionReduccion(82);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 148:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(122);
                                i--;
                            }
                            else if (Simbolos.Peek() == "A")
                            {
                                PilaEstados.Push(174);
                                i--;
                            }
                            else if (Simbolos.Peek() == "B")
                            {
                                PilaEstados.Push(114);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(118);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(120);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s141
                            PilaEstados.Push(141);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s121
                            PilaEstados.Push(121);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s119
                            PilaEstados.Push(119);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
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
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 149:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r85
                            AccionReduccion(85);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r85
                            AccionReduccion(85);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r85
                            AccionReduccion(85);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r85
                            AccionReduccion(85);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r85
                            AccionReduccion(85);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r85
                            AccionReduccion(85);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r85
                            AccionReduccion(85);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r85
                            AccionReduccion(85);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r85
                            AccionReduccion(85);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r85
                            AccionReduccion(85);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r85
                            AccionReduccion(85);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r85
                            AccionReduccion(85);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r85
                            AccionReduccion(85);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r85
                            AccionReduccion(85);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {

                            //r85
                            AccionReduccion(85);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r85
                            AccionReduccion(85);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r85
                            AccionReduccion(85);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r85
                            AccionReduccion(85);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r85
                            AccionReduccion(85);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r85
                            AccionReduccion(85);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r85
                            AccionReduccion(85);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r85
                            AccionReduccion(85);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r85
                            AccionReduccion(85);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r85
                            AccionReduccion(85);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r85
                            AccionReduccion(85);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r85
                            AccionReduccion(85);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r85
                            AccionReduccion(85);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r85
                            AccionReduccion(85);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r85
                            AccionReduccion(85);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r85
                            AccionReduccion(85);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 150:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(122);
                                i--;
                            }
                            else if (Simbolos.Peek() == "B")
                            {
                                PilaEstados.Push(175);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(118);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(120);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s141
                            PilaEstados.Push(141);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s121
                            PilaEstados.Push(121);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s119
                            PilaEstados.Push(119);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
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
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 151:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r88
                            AccionReduccion(88);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r88
                            AccionReduccion(88);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r88
                            AccionReduccion(88);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r88
                            AccionReduccion(88);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r88
                            AccionReduccion(88);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r88
                            AccionReduccion(88);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r88
                            AccionReduccion(88);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r88
                            AccionReduccion(88);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r88
                            AccionReduccion(88);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r88
                            AccionReduccion(88);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r88
                            AccionReduccion(88);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r88
                            AccionReduccion(88);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r88
                            AccionReduccion(88);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r88
                            AccionReduccion(88);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r88
                            AccionReduccion(88);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r88
                            AccionReduccion(88);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r88
                            AccionReduccion(88);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r88
                            AccionReduccion(88);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {

                            //r88
                            AccionReduccion(88);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r88
                            AccionReduccion(88);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r88
                            AccionReduccion(88);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r87
                            AccionReduccion(88);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r88
                            AccionReduccion(88);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r88
                            AccionReduccion(88);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r88
                            AccionReduccion(88);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r88
                            AccionReduccion(88);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r88
                            AccionReduccion(88);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r88
                            AccionReduccion(88);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r88
                            AccionReduccion(88);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r88
                            AccionReduccion(88);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 152:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(122);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(176);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(118);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(120);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s141
                            PilaEstados.Push(141);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s121
                            PilaEstados.Push(121);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s119
                            PilaEstados.Push(119);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
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
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 153:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(122);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(177);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(118);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(120);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s141
                            PilaEstados.Push(141);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s121
                            PilaEstados.Push(121);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s119
                            PilaEstados.Push(119);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
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
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 154:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r92
                            AccionReduccion(92);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r92
                            AccionReduccion(92);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r92
                            AccionReduccion(92);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r92
                            AccionReduccion(92);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r92
                            AccionReduccion(92);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r92
                            AccionReduccion(92);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r92
                            AccionReduccion(92);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r92
                            AccionReduccion(92);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r92
                            AccionReduccion(92);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r92
                            AccionReduccion(92);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r92
                            AccionReduccion(92);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r92
                            AccionReduccion(92);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            AccionReduccion(92);
                            i--;
                            //r92
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r92
                            AccionReduccion(92);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r92
                            AccionReduccion(92);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r92
                            AccionReduccion(92);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r92
                            AccionReduccion(92);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r92
                            AccionReduccion(92);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r92
                            AccionReduccion(92);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r92
                            AccionReduccion(92);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r92
                            AccionReduccion(92);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r92
                            AccionReduccion(92);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r92
                            AccionReduccion(92);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r92
                            AccionReduccion(92);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r92
                            AccionReduccion(92);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r92
                            AccionReduccion(92);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r92
                            AccionReduccion(92);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r92
                            AccionReduccion(92);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r92
                            AccionReduccion(92);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r92
                            AccionReduccion(92);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 155:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(122);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(178);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(118);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(120);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s141
                            PilaEstados.Push(141);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s121
                            PilaEstados.Push(121);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s119
                            PilaEstados.Push(119);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
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
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 156:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r95
                            AccionReduccion(95);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r95
                            AccionReduccion(95);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r95
                            AccionReduccion(95);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r95
                            AccionReduccion(95);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r95
                            AccionReduccion(95);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r95
                            AccionReduccion(95);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r95
                            AccionReduccion(95);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r95
                            AccionReduccion(95);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r95
                            AccionReduccion(95);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r95
                            AccionReduccion(95);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r95
                            AccionReduccion(95);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r95
                            AccionReduccion(95);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            AccionReduccion(95);
                            i--;
                            //r95
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r95
                            AccionReduccion(95);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r95
                            AccionReduccion(95);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r95
                            AccionReduccion(95);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r95
                            AccionReduccion(95);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r95
                            AccionReduccion(95);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r95
                            AccionReduccion(95);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r95
                            AccionReduccion(95);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r95
                            AccionReduccion(95);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r95
                            AccionReduccion(95);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r95
                            AccionReduccion(95);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r95
                            AccionReduccion(95);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r95
                            AccionReduccion(95);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r95
                            AccionReduccion(95);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r95
                            AccionReduccion(95);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r95
                            AccionReduccion(95);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r95
                            AccionReduccion(95);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r95
                            AccionReduccion(95);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 157:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(122);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(179);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(118);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(120);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s141
                            PilaEstados.Push(141);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s121
                            PilaEstados.Push(121);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s119
                            PilaEstados.Push(119);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
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
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 158:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(122);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(180);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(118);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(120);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s141
                            PilaEstados.Push(141);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s121
                            PilaEstados.Push(121);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s119
                            PilaEstados.Push(119);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
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
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 159:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r99
                            AccionReduccion(99);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r99
                            AccionReduccion(99);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r99
                            AccionReduccion(99);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            AccionReduccion(99);
                            i--;
                            //r99
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r99
                            AccionReduccion(99);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r99
                            AccionReduccion(99);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r99
                            AccionReduccion(99);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r99
                            AccionReduccion(99);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r99
                            AccionReduccion(99);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r99
                            AccionReduccion(99);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r99
                            AccionReduccion(99);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r99
                            AccionReduccion(99);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r99
                            AccionReduccion(99);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r99
                            AccionReduccion(99);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r99
                            AccionReduccion(99);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r99
                            AccionReduccion(99);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r99
                            AccionReduccion(99);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r99
                            AccionReduccion(99);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r99
                            AccionReduccion(99);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r99
                            AccionReduccion(99);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r99
                            AccionReduccion(99);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r99
                            AccionReduccion(99);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r99
                            AccionReduccion(99);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r99
                            AccionReduccion(99);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r99
                            AccionReduccion(99);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r99
                            AccionReduccion(99);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r99
                            AccionReduccion(99);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r99
                            AccionReduccion(99);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r99
                            AccionReduccion(99);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r99
                            AccionReduccion(99);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 160:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(122);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(181);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(120);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s141
                            PilaEstados.Push(141);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s121
                            PilaEstados.Push(121);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s119
                            PilaEstados.Push(119);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
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
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                        
                    case 161:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(122);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(182);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(120);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s141
                            PilaEstados.Push(141);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s121
                            PilaEstados.Push(121);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s119
                            PilaEstados.Push(119);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
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
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 162:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "X'")
                            {
                                PilaEstados.Push(183);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            AccionReduccion(111);
                            i--;
                            //r111
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r111
                            AccionReduccion(111);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "=")
                        {
                            //s146
                            PilaEstados.Push(146);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 163:
                        if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //s184
                            PilaEstados.Push(184);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 164:
                        if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s185
                            PilaEstados.Push(185);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 165:
                        if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //s186
                            PilaEstados.Push(186);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 166:
                        if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //s187
                            PilaEstados.Push(187);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 167:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //s188
                            PilaEstados.Push(188);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 168:
                         if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r68
                            AccionReduccion(68);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r68
                            AccionReduccion(68);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r68
                            AccionReduccion(68);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r68
                            AccionReduccion(68);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r68
                            AccionReduccion(68);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r68
                            AccionReduccion(68);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r68
                            AccionReduccion(68);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            AccionReduccion(68);
                            i--;
                            //r68
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r68
                            AccionReduccion(68);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r68
                            AccionReduccion(68);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r68
                            AccionReduccion(68);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r68
                            AccionReduccion(68);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r68
                            AccionReduccion(68);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r68
                            AccionReduccion(68);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            AccionReduccion(68);
                            i--;
                            //r68
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r68
                            AccionReduccion(68);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r68
                            AccionReduccion(68);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r68
                            AccionReduccion(68);
                            i--;
                        }
                  
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r68
                            AccionReduccion(68);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r68
                            AccionReduccion(68);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                   
                    case 169:
                        if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s189
                            PilaEstados.Push(189);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 170:
                        if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //s190
                            PilaEstados.Push(190);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }

                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 171:

                        if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r76
                            AccionReduccion(76);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //s191
                            PilaEstados.Push(191);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else 
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 172:
                        if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s192
                            PilaEstados.Push(192);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 173:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r110
                            AccionReduccion(110);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r110
                            AccionReduccion(110);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r110
                            AccionReduccion(110);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r110
                            AccionReduccion(110);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r110
                            AccionReduccion(110);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r110
                            AccionReduccion(110);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r110
                            AccionReduccion(110);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r110
                            AccionReduccion(110);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r110
                            AccionReduccion(110);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r110
                            AccionReduccion(110);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r110
                            AccionReduccion(110);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r110
                            AccionReduccion(110);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r110
                            AccionReduccion(110);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r110
                            AccionReduccion(110);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r110
                            AccionReduccion(110);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r110
                            AccionReduccion(110);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r110
                            AccionReduccion(110);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r110
                            AccionReduccion(110);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r110
                            AccionReduccion(110);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r110
                            AccionReduccion(110);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r110
                            AccionReduccion(110);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r110
                            AccionReduccion(110);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r110
                            AccionReduccion(110);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r110
                            AccionReduccion(110);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r110
                            AccionReduccion(110);
                            i--;
                        }
                        //CONFLICTO 31
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
   
                                //r110
                                AccionReduccion(110);
                                i--;
                           
                        }
                        //CONFLICTO 32
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                                //r110
                                AccionReduccion(110);
                                i--;
                            
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r110
                            AccionReduccion(110);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r110
                            AccionReduccion(110);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r110
                            AccionReduccion(110);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 174:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Expr'")
                            {
                                PilaEstados.Push(193);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }

                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //PRECEDENCIA DEL TERMINAL
                            var terPrec = PrecedenciaTerminales[Lab_ASDR.TokenList[i]];
                            //PRECEDENCIA DE LA PRODUCCION
                            var proPrec = 1;
                            if (proPrec > terPrec)
                            {
                                //r84
                                AccionReduccion(84);
                                i--;
                            }
                            else
                            {
                                //s148
                                PilaEstados.Push(148);
                                Simbolos.Push(Lab_ASDR.TokenList[i]);
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        //CONFLICTO 33
                         else if (Lab_ASDR.TokenList[i] == "-")
                        {
     
                                //r84
                                AccionReduccion(84);
                                i--;
                          
                        }
                        //CONFLICTO 34
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
  
                                //r84
                                AccionReduccion(84);
                                i--;
                          
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r84
                            AccionReduccion(84);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 175:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "A'")
                            {
                                PilaEstados.Push(194);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            AccionReduccion(87);
                            i--;
                            //r87
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            AccionReduccion(87);
                            i--;
                            //r87
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //PRECEDENCIA DEL TERMINAL
                            var terPrec = PrecedenciaTerminales[Lab_ASDR.TokenList[i]];
                            //PRECEDENCIA DE LA PRODUCCION
                            var proPrec = 1;
                            if (proPrec > terPrec)
                            {
                                //r87
                                AccionReduccion(87);
                                i--;
                            }
                            else
                            {
                                //s150
                                PilaEstados.Push(150);
                                Simbolos.Push(Lab_ASDR.TokenList[i]);
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        //CONFLICTO 35
                         else if (Lab_ASDR.TokenList[i] == "-")
                        {
    
                                //r87
                                AccionReduccion(87);
                                i--;
        
                        }
                        //CONFLICTO 36
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                                //r87
                                AccionReduccion(87);
                                i--;
                            

                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r87
                            AccionReduccion(87);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 176:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "B'")
                            {
                                PilaEstados.Push(195);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }

                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //PRECEDENCIA DEL TERMINAL
                            var terPrec = PrecedenciaTerminales[Lab_ASDR.TokenList[i]];
                            //PRECEDENCIA DE LA PRODUCCION
                            var proPrec = 1;
                            if (proPrec > terPrec)
                            {
                                //r91
                                AccionReduccion(91);
                                i--;
                            }
                            else
                            {
                                //s152
                                PilaEstados.Push(152);
                                Simbolos.Push(Lab_ASDR.TokenList[i]);
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //PRECEDENCIA DEL TERMINAL
                            var terPrec = PrecedenciaTerminales[Lab_ASDR.TokenList[i]];
                            //PRECEDENCIA DE LA PRODUCCION
                            var proPrec = 1;
                            if (proPrec > terPrec)
                            {
                                //r91
                                AccionReduccion(91);
                                i--;
                            }
                            else
                            {
                                //s153
                                PilaEstados.Push(153);
                                Simbolos.Push(Lab_ASDR.TokenList[i]);
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 177:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "B'")
                            {
                                PilaEstados.Push(196);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            AccionReduccion(91);
                            i--;
                            //r91
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            AccionReduccion(91);
                            i--;
                            //r91
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //PRECEDENCIA DEL TERMINAL
                            var terPrec = PrecedenciaTerminales[Lab_ASDR.TokenList[i]];
                            //PRECEDENCIA DE LA PRODUCCION
                            var proPrec = 1;
                            if (proPrec > terPrec)
                            {
                                //r91
                                AccionReduccion(91);
                                i--;
                            }
                            else
                            {
                                //s152
                                PilaEstados.Push(152);
                                Simbolos.Push(Lab_ASDR.TokenList[i]);
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //PRECEDENCIA DEL TERMINAL
                            var terPrec = PrecedenciaTerminales[Lab_ASDR.TokenList[i]];
                            //PRECEDENCIA DE LA PRODUCCION
                            var proPrec = 1;
                            if (proPrec > terPrec)
                            {
                                //r91
                                AccionReduccion(91);
                                i--;
                            }
                            else
                            {
                                //s153
                                PilaEstados.Push(153);
                                Simbolos.Push(Lab_ASDR.TokenList[i]);
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r91
                            AccionReduccion(91);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 178:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "C'")
                            {
                                PilaEstados.Push(197);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            AccionReduccion(94);
                            i--;
                            //r94
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            AccionReduccion(94);
                            i--;
                            //r94
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
 
                                //r94
                                AccionReduccion(94);
                                i--;
                            
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
      
                                //r94
                                AccionReduccion(94);
                                i--;

                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //PRECEDENCIA DEL TERMINAL
                            var terPrec = PrecedenciaTerminales[Lab_ASDR.TokenList[i]];
                            //PRECEDENCIA DE LA PRODUCCION
                            var proPrec = 1;
                            if (proPrec > terPrec)
                            {
                                //r94
                                AccionReduccion(94);
                                i--;
                            }
                            else
                            {
                                //s155
                                PilaEstados.Push(155);
                                Simbolos.Push(Lab_ASDR.TokenList[i]);
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r94
                            AccionReduccion(94);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 179:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "D'")
                            {
                                PilaEstados.Push(198);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            AccionReduccion(98);
                            i--;
                            //r98
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            AccionReduccion(98);
                            i--;
                            //r98
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {

                            //r98
                            AccionReduccion(98);
                            i--;

                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {

                            //r98
                            AccionReduccion(98);
                            i--;

                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                                 //r98
                                AccionReduccion(98);
                                i--;
                         
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //PRECEDENCIA DEL TERMINAL
                            var terPrec = PrecedenciaTerminales[Lab_ASDR.TokenList[i]];
                            //PRECEDENCIA DE LA PRODUCCION
                            var proPrec = 1;
                            if (proPrec > terPrec)
                            {
                                //r98
                                AccionReduccion(98);
                                i--;
                            }
                            else
                            {
                                //s157
                                PilaEstados.Push(157);
                                Simbolos.Push(Lab_ASDR.TokenList[i]);
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //PRECEDENCIA DEL TERMINAL
                            var terPrec = PrecedenciaTerminales[Lab_ASDR.TokenList[i]];
                            //PRECEDENCIA DE LA PRODUCCION
                            var proPrec = 1;
                            if (proPrec > terPrec)
                            {
                                //r98
                                AccionReduccion(98);
                                i--;
                            }
                            else
                            {
                                //s158
                                PilaEstados.Push(158);
                                Simbolos.Push(Lab_ASDR.TokenList[i]);
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 180:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "D'")
                            {
                                PilaEstados.Push(199);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            AccionReduccion(98);
                            i--;
                            //r98
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            AccionReduccion(98);
                            i--;
                            //r98
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {

                            //r98
                            AccionReduccion(98);
                            i--;

                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {

                            //r98
                            AccionReduccion(98);
                            i--;

                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;

                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //PRECEDENCIA DEL TERMINAL
                            var terPrec = PrecedenciaTerminales[Lab_ASDR.TokenList[i]];
                            //PRECEDENCIA DE LA PRODUCCION
                            var proPrec = 1;
                            if (proPrec > terPrec)
                            {
                                //r98
                                AccionReduccion(98);
                                i--;
                            }
                            else
                            {
                                //s157
                                PilaEstados.Push(157);
                                Simbolos.Push(Lab_ASDR.TokenList[i]);
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //PRECEDENCIA DEL TERMINAL
                            var terPrec = PrecedenciaTerminales[Lab_ASDR.TokenList[i]];
                            //PRECEDENCIA DE LA PRODUCCION
                            var proPrec = 1;
                            if (proPrec > terPrec)
                            {
                                //r98
                                AccionReduccion(98);
                                i--;
                            }
                            else
                            {
                                //s158
                                PilaEstados.Push(158);
                                Simbolos.Push(Lab_ASDR.TokenList[i]);
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r98
                            AccionReduccion(98);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 181:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "E'")
                            {
                                PilaEstados.Push(200);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            AccionReduccion(102);
                            i--;
                            //r102
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            AccionReduccion(102);
                            i--;
                            //r102
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {

                            //r102
                            AccionReduccion(102);
                            i--;

                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {

                            //r102
                            AccionReduccion(102);
                            i--;

                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //PRECEDENCIA DEL TERMINAL
                            var terPrec = PrecedenciaTerminales[Lab_ASDR.TokenList[i]];
                            //PRECEDENCIA DE LA PRODUCCION
                            var proPrec = 1;
                            if (proPrec > terPrec)
                            {
                                //r102
                                AccionReduccion(102);
                                i--;
                            }
                            else
                            {
                                //s160
                                PilaEstados.Push(160);
                                Simbolos.Push(Lab_ASDR.TokenList[i]);
                            }

                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //PRECEDENCIA DEL TERMINAL
                            var terPrec = PrecedenciaTerminales[Lab_ASDR.TokenList[i]];
                            //PRECEDENCIA DE LA PRODUCCION
                            var proPrec = 1;
                            if (proPrec > terPrec)
                            {
                                //r102
                                AccionReduccion(102);
                                i--;
                            }
                            else
                            {
                                //s161
                                PilaEstados.Push(161);
                                Simbolos.Push(Lab_ASDR.TokenList[i]);
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 182:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "E'")
                            {
                                PilaEstados.Push(201);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            AccionReduccion(102);
                            i--;
                            //r102
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            AccionReduccion(102);
                            i--;
                            //r102
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {

                            //r102
                            AccionReduccion(102);
                            i--;

                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {

                            //r102
                            AccionReduccion(102);
                            i--;

                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //PRECEDENCIA DEL TERMINAL
                            var terPrec = PrecedenciaTerminales[Lab_ASDR.TokenList[i]];
                            //PRECEDENCIA DE LA PRODUCCION
                            var proPrec = 1;
                            if (proPrec > terPrec)
                            {
                                //r102
                                AccionReduccion(102);
                                i--;
                            }
                            else
                            {
                                //s160
                                PilaEstados.Push(160);
                                Simbolos.Push(Lab_ASDR.TokenList[i]);
                            }

                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //PRECEDENCIA DEL TERMINAL
                            var terPrec = PrecedenciaTerminales[Lab_ASDR.TokenList[i]];
                            //PRECEDENCIA DE LA PRODUCCION
                            var proPrec = 1;
                            if (proPrec > terPrec)
                            {
                                //r102
                                AccionReduccion(102);
                                i--;
                            }
                            else
                            {
                                //s161
                                PilaEstados.Push(161);
                                Simbolos.Push(Lab_ASDR.TokenList[i]);
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r102
                            AccionReduccion(102);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;    
                    case 183:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r103
                            AccionReduccion(103);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r103
                            AccionReduccion(103);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r103
                            AccionReduccion(103);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r103
                            AccionReduccion(103);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r103
                            AccionReduccion(103);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r103
                            AccionReduccion(103);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r103
                            AccionReduccion(103);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r103
                            AccionReduccion(103);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r103
                            AccionReduccion(103);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r103
                            AccionReduccion(103);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r103
                            AccionReduccion(103);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r103
                            AccionReduccion(103);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r103
                            AccionReduccion(103);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r103
                            AccionReduccion(103);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r103
                            AccionReduccion(103);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r103
                            AccionReduccion(103);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r103
                            AccionReduccion(103);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r103
                            AccionReduccion(103);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r103
                            AccionReduccion(103);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r103
                            AccionReduccion(103);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r103
                            AccionReduccion(103);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r103
                            AccionReduccion(103);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r103
                            AccionReduccion(103);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {

                            //r103
                            AccionReduccion(103);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r103
                            AccionReduccion(103);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r103
                            AccionReduccion(103);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r103
                            AccionReduccion(103);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r103
                            AccionReduccion(103);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            AccionReduccion(103);
                            i--;
                            //r103
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r103
                            AccionReduccion(103);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 184:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r105
                            AccionReduccion(105);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r105
                            AccionReduccion(105);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r105
                            AccionReduccion(105);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r105
                            AccionReduccion(105);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r105
                            AccionReduccion(105);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r105
                            AccionReduccion(105);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r105
                            AccionReduccion(105);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r105
                            AccionReduccion(105);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r105
                            AccionReduccion(105);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r105
                            AccionReduccion(105);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r105
                            AccionReduccion(105);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r105
                            AccionReduccion(105);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r105
                            AccionReduccion(105);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r105
                            AccionReduccion(105);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //r105
                            AccionReduccion(105);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r105
                            AccionReduccion(105);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r105
                            AccionReduccion(105);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r105
                            AccionReduccion(105);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r105
                            AccionReduccion(105);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r105
                            AccionReduccion(105);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r105
                            AccionReduccion(105);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r105
                            AccionReduccion(105);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r105
                            AccionReduccion(105);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {

                            //r105
                            AccionReduccion(105);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r105
                            AccionReduccion(105);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r105
                            AccionReduccion(105);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r105
                            AccionReduccion(105);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r105
                            AccionReduccion(105);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            AccionReduccion(105);
                            i--;
                            //r105
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r105
                            AccionReduccion(105);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 185:
                        if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //s202
                            PilaEstados.Push(202);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 186:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "StmtBlock")
                            {
                                PilaEstados.Push(103);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Stmt")
                            {
                                PilaEstados.Push(203);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Stmt'")
                            {
                                PilaEstados.Push(96);
                                i--;
                            }
                            else if (Simbolos.Peek() == "ifStmt")
                            {
                                PilaEstados.Push(97);
                                i--;
                            }
                            else if (Simbolos.Peek() == "whileStmt")
                            {
                                PilaEstados.Push(98);
                                i--;
                            }
                            else if (Simbolos.Peek() == "ForStmt")
                            {
                                PilaEstados.Push(99);
                                i--;
                            }
                            else if (Simbolos.Peek() == "ReturnStmt")
                            {
                                PilaEstados.Push(101);
                                i--;
                            }
                            else if (Simbolos.Peek() == "BreakStmt")
                            {
                                PilaEstados.Push(100);
                                i--;
                            }
                            else if (Simbolos.Peek() == "PrintStmt")
                            {
                                PilaEstados.Push(102);
                                i--;
                            }
                            else if (Simbolos.Peek() == "CallStmt")
                            {
                                PilaEstados.Push(104);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(122);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Expr")
                            {
                                PilaEstados.Push(105);
                                i--;
                            }
                            else if (Simbolos.Peek() == "A")
                            {
                                PilaEstados.Push(113);
                                i--;
                            }
                            else if (Simbolos.Peek() == "B")
                            {
                                PilaEstados.Push(114);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(118);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(120);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r62
                            AccionReduccion(62);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s112
                            PilaEstados.Push(112);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s121
                            PilaEstados.Push(121);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //s69
                            PilaEstados.Push(69);
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
                            //s119
                            PilaEstados.Push(119);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
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
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 187:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "StmtBlock")
                            {
                                PilaEstados.Push(103);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Stmt")
                            {
                                PilaEstados.Push(204);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Stmt'")
                            {
                                PilaEstados.Push(96);
                                i--;
                            }
                            else if (Simbolos.Peek() == "ifStmt")
                            {
                                PilaEstados.Push(97);
                                i--;
                            }
                            else if (Simbolos.Peek() == "whileStmt")
                            {
                                PilaEstados.Push(98);
                                i--;
                            }
                            else if (Simbolos.Peek() == "ForStmt")
                            {
                                PilaEstados.Push(99);
                                i--;
                            }
                            else if (Simbolos.Peek() == "ReturnStmt")
                            {
                                PilaEstados.Push(101);
                                i--;
                            }
                            else if (Simbolos.Peek() == "BreakStmt")
                            {
                                PilaEstados.Push(100);
                                i--;
                            }
                            else if (Simbolos.Peek() == "PrintStmt")
                            {
                                PilaEstados.Push(102);
                                i--;
                            }
                            else if (Simbolos.Peek() == "CallStmt")
                            {
                                PilaEstados.Push(104);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(122);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Expr")
                            {
                                PilaEstados.Push(105);
                                i--;
                            }
                            else if (Simbolos.Peek() == "A")
                            {
                                PilaEstados.Push(113);
                                i--;
                            }
                            else if (Simbolos.Peek() == "B")
                            {
                                PilaEstados.Push(114);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(118);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(120);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r62
                            AccionReduccion(62);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s112
                            PilaEstados.Push(112);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s121
                            PilaEstados.Push(121);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //s69
                            PilaEstados.Push(69);
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
                            //s119
                            PilaEstados.Push(119);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
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
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 188:
                        if (BanderaReduccion == true)
                         {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(122);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Expr")
                            {
                                PilaEstados.Push(205);
                                i--;
                            }
                            else if (Simbolos.Peek() == "A")
                            {
                                PilaEstados.Push(113);
                                i--;
                            }
                            else if (Simbolos.Peek() == "B")
                            {
                                PilaEstados.Push(114);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(118);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(120);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s141
                            PilaEstados.Push(141);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s121
                            PilaEstados.Push(121);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s119
                            PilaEstados.Push(119);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
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
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 189:
                        if (Lab_ASDR.TokenList[i] == "println")
                        {
                            //s206
                            PilaEstados.Push(206);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 190:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r73
                            AccionReduccion(73);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r73
                            AccionReduccion(73);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r73
                            AccionReduccion(73);
                            i--;
                        }

                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r73
                            AccionReduccion(73);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r73
                            AccionReduccion(73);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r73
                            AccionReduccion(73);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r73
                            AccionReduccion(73);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r73
                            AccionReduccion(73);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r73
                            AccionReduccion(73);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r73
                            AccionReduccion(73);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r73
                            AccionReduccion(73);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r73
                            AccionReduccion(73);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            AccionReduccion(73);
                            i--;
                            //r73
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r73
                            AccionReduccion(73);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r73
                            AccionReduccion(73);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r73
                            AccionReduccion(73);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            //r73
                            AccionReduccion(73);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r73
                            AccionReduccion(73);
                            i--;
                        }
                     
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            AccionReduccion(73);
                            i--;
                            //r73
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r73
                            AccionReduccion(73);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 191:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Actuals")
                            {
                                PilaEstados.Push(207);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(122);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Expr")
                            {
                                PilaEstados.Push(171);
                                i--;
                            }
                            else if (Simbolos.Peek() == "A")
                            {
                                PilaEstados.Push(113);
                                i--;
                            }
                            else if (Simbolos.Peek() == "B")
                            {
                                PilaEstados.Push(114);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(118);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(120);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s141
                            PilaEstados.Push(141);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s121
                            PilaEstados.Push(121);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s119
                            PilaEstados.Push(119);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
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
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 192:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Actuals")
                            {
                                PilaEstados.Push(208);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(122);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Expr")
                            {
                                PilaEstados.Push(171);
                                i--;
                            }
                            else if (Simbolos.Peek() == "A")
                            {
                                PilaEstados.Push(113);
                                i--;
                            }
                            else if (Simbolos.Peek() == "B")
                            {
                                PilaEstados.Push(114);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(118);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(120);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s141
                            PilaEstados.Push(141);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s121
                            PilaEstados.Push(121);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s119
                            PilaEstados.Push(119);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
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
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 193:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r83
                            AccionReduccion(83);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r83
                            AccionReduccion(83);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r83
                            AccionReduccion(83);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r83
                            AccionReduccion(83);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r83
                            AccionReduccion(83);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r83
                            AccionReduccion(83);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r83
                            AccionReduccion(83);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r83
                            AccionReduccion(83);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r83
                            AccionReduccion(83);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r83
                            AccionReduccion(83);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r83
                            AccionReduccion(83);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r83
                            AccionReduccion(83);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r83
                            AccionReduccion(83);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r83
                            AccionReduccion(83);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            AccionReduccion(83);
                            i--;
                            //r83
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r83
                            AccionReduccion(83);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r83
                            AccionReduccion(83);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r83
                            AccionReduccion(83);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            AccionReduccion(83);
                            i--;
                            //r83
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r83
                            AccionReduccion(83);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r83
                            AccionReduccion(83);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r83
                            AccionReduccion(83);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r83
                            AccionReduccion(83);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r83
                            AccionReduccion(83);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r83
                            AccionReduccion(83);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r83
                            AccionReduccion(83);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r83
                            AccionReduccion(83);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r83
                            AccionReduccion(83);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r83
                            AccionReduccion(83);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r83
                            AccionReduccion(83);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 194:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r83
                            AccionReduccion(83);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r86
                            AccionReduccion(86);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r86
                            AccionReduccion(86);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r86
                            AccionReduccion(86);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r86
                            AccionReduccion(86);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r86
                            AccionReduccion(86);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r86
                            AccionReduccion(86);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r86
                            AccionReduccion(86);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r86
                            AccionReduccion(86);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r86
                            AccionReduccion(86);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r86
                            AccionReduccion(86);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r86
                            AccionReduccion(86);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r86
                            AccionReduccion(86);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r86
                            AccionReduccion(86);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            AccionReduccion(86);
                            i--;
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r86
                            AccionReduccion(86);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r86
                            AccionReduccion(86);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r86
                            AccionReduccion(86);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            AccionReduccion(86);
                            i--;
                            //r86
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r86
                            AccionReduccion(86);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r86
                            AccionReduccion(86);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r86
                            AccionReduccion(86);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r86
                            AccionReduccion(86);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r86
                            AccionReduccion(86);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r86
                            AccionReduccion(86);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r86
                            AccionReduccion(86);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r86
                            AccionReduccion(86);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r86
                            AccionReduccion(86);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r86
                            AccionReduccion(86);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r86
                            AccionReduccion(86);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 195:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r89
                            AccionReduccion(89);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r89
                            AccionReduccion(89);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r89
                            AccionReduccion(89);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r89
                            AccionReduccion(89);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r89
                            AccionReduccion(89);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r89
                            AccionReduccion(89);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r89
                            AccionReduccion(89);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r89
                            AccionReduccion(89);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r89
                            AccionReduccion(89);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r89
                            AccionReduccion(89);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r89
                            AccionReduccion(89);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r89
                            AccionReduccion(89);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r89
                            AccionReduccion(89);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r89
                            AccionReduccion(89);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            AccionReduccion(89);
                            i--;
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r89
                            AccionReduccion(89);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r89
                            AccionReduccion(89);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r89
                            AccionReduccion(89);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            AccionReduccion(89);
                            i--;
                            //r89
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r89
                            AccionReduccion(89);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r89
                            AccionReduccion(89);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r89
                            AccionReduccion(89);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r89
                            AccionReduccion(89);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r89
                            AccionReduccion(89);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r89
                            AccionReduccion(89);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r89
                            AccionReduccion(89);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r89
                            AccionReduccion(89);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r89
                            AccionReduccion(89);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r89
                            AccionReduccion(89);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r89
                            AccionReduccion(89);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 196:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r90
                            AccionReduccion(90);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r90
                            AccionReduccion(90);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r90
                            AccionReduccion(90);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r90
                            AccionReduccion(90);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r90
                            AccionReduccion(90);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r90
                            AccionReduccion(90);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r90
                            AccionReduccion(90);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r90
                            AccionReduccion(90);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r90
                            AccionReduccion(90);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r90
                            AccionReduccion(90);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r90
                            AccionReduccion(90);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r90
                            AccionReduccion(90);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r90
                            AccionReduccion(90);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r90
                            AccionReduccion(90);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            AccionReduccion(90);
                            i--;
                            //r90
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r90
                            AccionReduccion(90);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r90
                            AccionReduccion(90);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r90
                            AccionReduccion(90);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            AccionReduccion(90);
                            i--;
                            //r90
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r90
                            AccionReduccion(90);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r90
                            AccionReduccion(90);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r90
                            AccionReduccion(90);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r90
                            AccionReduccion(90);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r90
                            AccionReduccion(90);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r90
                            AccionReduccion(90);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r90
                            AccionReduccion(90);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r90
                            AccionReduccion(90);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r90
                            AccionReduccion(90);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r90
                            AccionReduccion(90);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r90
                            AccionReduccion(90);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 197:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r93
                            AccionReduccion(93);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r93
                            AccionReduccion(93);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r93
                            AccionReduccion(93);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r93
                            AccionReduccion(93);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r93
                            AccionReduccion(93);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r93
                            AccionReduccion(93);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r93
                            AccionReduccion(93);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r93
                            AccionReduccion(93);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r93
                            AccionReduccion(93);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r93
                            AccionReduccion(93);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r93
                            AccionReduccion(93);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r93
                            AccionReduccion(93);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r93
                            AccionReduccion(93);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r93
                            AccionReduccion(93);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            AccionReduccion(93);
                            i--;
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r93
                            AccionReduccion(93);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r93
                            AccionReduccion(93);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r93
                            AccionReduccion(93);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            AccionReduccion(93);
                            i--;
                            //r93
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r93
                            AccionReduccion(93);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r93
                            AccionReduccion(93);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r93
                            AccionReduccion(93);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r93
                            AccionReduccion(93);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r93
                            AccionReduccion(93);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r93
                            AccionReduccion(93);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r93
                            AccionReduccion(93);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r93
                            AccionReduccion(93);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r93
                            AccionReduccion(93);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r93
                            AccionReduccion(93);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r93
                            AccionReduccion(93);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 198:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r96
                            AccionReduccion(96);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r96
                            AccionReduccion(96);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r96
                            AccionReduccion(96);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r96
                            AccionReduccion(96);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r96
                            AccionReduccion(96);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r96
                            AccionReduccion(96);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r96
                            AccionReduccion(96);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r96
                            AccionReduccion(96);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r96
                            AccionReduccion(96);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r96
                            AccionReduccion(96);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r96
                            AccionReduccion(96);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r96
                            AccionReduccion(96);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r96
                            AccionReduccion(96);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r96
                            AccionReduccion(96);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            AccionReduccion(96);
                            i--;
                            //r96
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r96
                            AccionReduccion(96);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r96
                            AccionReduccion(96);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r96
                            AccionReduccion(96);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            AccionReduccion(96);
                            i--;
                            //r96
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r96
                            AccionReduccion(96);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r96
                            AccionReduccion(96);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r96
                            AccionReduccion(96);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r96
                            AccionReduccion(96);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r96
                            AccionReduccion(96);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r96
                            AccionReduccion(96);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r96
                            AccionReduccion(96);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r96
                            AccionReduccion(96);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r96
                            AccionReduccion(96);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r96
                            AccionReduccion(96);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r96
                            AccionReduccion(96);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 199:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r97
                            AccionReduccion(97);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r97
                            AccionReduccion(97);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r97
                            AccionReduccion(97);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r97
                            AccionReduccion(97);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r97
                            AccionReduccion(97);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r97
                            AccionReduccion(97);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r97
                            AccionReduccion(97);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r97
                            AccionReduccion(97);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r97
                            AccionReduccion(97);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r97
                            AccionReduccion(97);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r97
                            AccionReduccion(97);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r97
                            AccionReduccion(97);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r97
                            AccionReduccion(97);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r97
                            AccionReduccion(97);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            AccionReduccion(97);
                            i--;
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r97
                            AccionReduccion(97);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r97
                            AccionReduccion(97);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r97
                            AccionReduccion(97);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            AccionReduccion(97);
                            i--;
                            //r97
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r97
                            AccionReduccion(97);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r97
                            AccionReduccion(97);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r97
                            AccionReduccion(97);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r97
                            AccionReduccion(97);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r97
                            AccionReduccion(97);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r97
                            AccionReduccion(97);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r97
                            AccionReduccion(97);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r97
                            AccionReduccion(97);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r97
                            AccionReduccion(97);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r97
                            AccionReduccion(97);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r97
                            AccionReduccion(97);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 200:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r100
                            AccionReduccion(100);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r100
                            AccionReduccion(100);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r100
                            AccionReduccion(100);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r100
                            AccionReduccion(100);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r100
                            AccionReduccion(100);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r100
                            AccionReduccion(100);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r100
                            AccionReduccion(100);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r100
                            AccionReduccion(100);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r100
                            AccionReduccion(100);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r100
                            AccionReduccion(100);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r100
                            AccionReduccion(100);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r100
                            AccionReduccion(100);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r100
                            AccionReduccion(100);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r100
                            AccionReduccion(100);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            AccionReduccion(100);
                            i--;
                            //r100
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r100
                            AccionReduccion(100);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r100
                            AccionReduccion(100);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r100
                            AccionReduccion(100);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            AccionReduccion(100);
                            i--;
                            //r100
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r100
                            AccionReduccion(100);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r100
                            AccionReduccion(100);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r100
                            AccionReduccion(100);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r100
                            AccionReduccion(100);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r100
                            AccionReduccion(100);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r100
                            AccionReduccion(100);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r100
                            AccionReduccion(100);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r100
                            AccionReduccion(100);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r100
                            AccionReduccion(100);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r100
                            AccionReduccion(100);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r100
                            AccionReduccion(100);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 201:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r101
                            AccionReduccion(101);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r101
                            AccionReduccion(101);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r101
                            AccionReduccion(101);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r101
                            AccionReduccion(101);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r101
                            AccionReduccion(101);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r101
                            AccionReduccion(101);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r101
                            AccionReduccion(101);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r101
                            AccionReduccion(101);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r101
                            AccionReduccion(101);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r101
                            AccionReduccion(101);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r101
                            AccionReduccion(101);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r101
                            AccionReduccion(101);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r101
                            AccionReduccion(101);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r101
                            AccionReduccion(101);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            AccionReduccion(101);
                            i--;
                            //r101
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r101
                            AccionReduccion(101);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r101
                            AccionReduccion(101);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r101
                            AccionReduccion(101);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            AccionReduccion(101);
                            i--;
                            //r101
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r101
                            AccionReduccion(101);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r101
                            AccionReduccion(101);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r101
                            AccionReduccion(101);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r101
                            AccionReduccion(101);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r101
                            AccionReduccion(101);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r101
                            AccionReduccion(101);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r101
                            AccionReduccion(101);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r101
                            AccionReduccion(101);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r101
                            AccionReduccion(101);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r101
                            AccionReduccion(101);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r101
                            AccionReduccion(101);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 202:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r107
                            AccionReduccion(107);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r107
                            AccionReduccion(107);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r107
                            AccionReduccion(107);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r107
                            AccionReduccion(107);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //r107
                            AccionReduccion(107);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r107
                            AccionReduccion(107);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r107
                            AccionReduccion(107);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r107
                            AccionReduccion(107);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //r107
                            AccionReduccion(107);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r107
                            AccionReduccion(107);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r107
                            AccionReduccion(107);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r107
                            AccionReduccion(107);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r107
                            AccionReduccion(107);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r107
                            AccionReduccion(107);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            AccionReduccion(107);
                            i--;
                            //r107
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r107
                            AccionReduccion(107);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r107
                            AccionReduccion(107);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r107
                            AccionReduccion(107);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            AccionReduccion(107);
                            i--;
                            //r107
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r107
                            AccionReduccion(107);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "||")
                        {
                            //r107
                            AccionReduccion(107);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!=")
                        {
                            //r107
                            AccionReduccion(107);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">")
                        {
                            //r107
                            AccionReduccion(107);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ">=")
                        {
                            //r107
                            AccionReduccion(107);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "-")
                        {
                            //r107
                            AccionReduccion(107);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "/")
                        {
                            //r107
                            AccionReduccion(107);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "%")
                        {
                            //r107
                            AccionReduccion(107);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "!")
                        {
                            //r107
                            AccionReduccion(107);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r107
                            AccionReduccion(107);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r107
                            AccionReduccion(107);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 203:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;
                            if (Simbolos.Peek() == "ifStmt'")
                            {
                                PilaEstados.Push(209);
                                i--;
                            }
                        }
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r65
                            AccionReduccion(65);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r65
                            AccionReduccion(65);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r65
                            AccionReduccion(65);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r65
                            AccionReduccion(65);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r65
                            AccionReduccion(65);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r65
                            AccionReduccion(65);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
                            //PRECEDENCIA DEL TERMINAL
                            var terPrec = PrecedenciaTerminales[Lab_ASDR.TokenList[i]];
                            //PRECEDENCIA DE LA PRODUCCION
                            var proPrec = 26;
                            if (proPrec > terPrec)
                            {
                                //r65
                                AccionReduccion(65);
                                i--;
                            }
                            else
                            {
                                //s110
                                PilaEstados.Push(110);
                                Simbolos.Push(Lab_ASDR.TokenList[i]);
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r65
                            AccionReduccion(65);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r65
                            AccionReduccion(65);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r65
                            AccionReduccion(65);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r65
                            AccionReduccion(65);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r65
                            AccionReduccion(65);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            AccionReduccion(65);
                            i--;
                            //r65
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r65
                            AccionReduccion(65);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r65
                            AccionReduccion(65);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r65
                            AccionReduccion(65);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            AccionReduccion(65);
                            i--;
                            //r65
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r65
                            AccionReduccion(65);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r65
                            AccionReduccion(65);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r65
                            AccionReduccion(65);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 204:

                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r66
                            AccionReduccion(66);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r66
                            AccionReduccion(66);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r66
                            AccionReduccion(66);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r66
                            AccionReduccion(66);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r66
                            AccionReduccion(66);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r66
                            AccionReduccion(66);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {
    
                                //r66
                                AccionReduccion(66);
                                i--;
                            
   
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r66
                            AccionReduccion(66);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r66
                            AccionReduccion(66);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r66
                            AccionReduccion(66);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r66
                            AccionReduccion(66);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r66
                            AccionReduccion(66);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            AccionReduccion(66);
                            i--;
                            //r66
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r66
                            AccionReduccion(66);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r66
                            AccionReduccion(66);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r66
                            AccionReduccion(66);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            AccionReduccion(66);
                            i--;
                            //r66
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r66
                            AccionReduccion(66);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r66
                            AccionReduccion(66);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r66
                            AccionReduccion(66);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 205:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //s211
                            PilaEstados.Push(211);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 206:
                        if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s212
                            PilaEstados.Push(212);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 207:
                        if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r75
                            AccionReduccion(75);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 208:
                        if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //s213
                            PilaEstados.Push(213);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 209:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r63
                            AccionReduccion(63);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r63
                            AccionReduccion(63);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r63
                            AccionReduccion(63);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r63
                            AccionReduccion(63);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r63
                            AccionReduccion(63);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r63
                            AccionReduccion(63);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {

                            //r63
                            AccionReduccion(63);
                            i--;


                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r63
                            AccionReduccion(63);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r63
                            AccionReduccion(63);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r63
                            AccionReduccion(63);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r63
                            AccionReduccion(63);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r63
                            AccionReduccion(63);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            AccionReduccion(63);
                            i--;
                            //r63
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r63
                            AccionReduccion(63);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r63
                            AccionReduccion(63);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r63
                            AccionReduccion(63);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            AccionReduccion(63);
                            i--;
                            //r63
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r63
                            AccionReduccion(63);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r63
                            AccionReduccion(63);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r63
                            AccionReduccion(63);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 210:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "StmtBlock")
                            {
                                PilaEstados.Push(103);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Stmt")
                            {
                                PilaEstados.Push(214);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Stmt'")
                            {
                                PilaEstados.Push(96);
                                i--;
                            }
                            else if (Simbolos.Peek() == "IfStmt")
                            {
                                PilaEstados.Push(97);
                                i--;
                            }
                            else if (Simbolos.Peek() == "WhileStmt")
                            {
                                PilaEstados.Push(98);
                                i--;
                            }
                            else if (Simbolos.Peek() == "ForStmt")
                            {
                                PilaEstados.Push(99);
                                i--;
                            }
                            else if (Simbolos.Peek() == "ReturnStmt")
                            {
                                PilaEstados.Push(101);
                                i--;
                            }
                            else if (Simbolos.Peek() == "BreakStmt")
                            {
                                PilaEstados.Push(100);
                                i--;
                            }
                            else if (Simbolos.Peek() == "PrintStmt")
                            {
                                PilaEstados.Push(102);
                                i--;
                            }
                            else if (Simbolos.Peek() == "CallStmt")
                            {
                                PilaEstados.Push(104);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(122);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Expr")
                            {
                                PilaEstados.Push(105);
                                i--;
                            }
                            else if (Simbolos.Peek() == "A")
                            {
                                PilaEstados.Push(113);
                                i--;
                            }
                            else if (Simbolos.Peek() == "B")
                            {
                                PilaEstados.Push(114);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(118);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(120);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r62
                            AccionReduccion(62);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s112
                            PilaEstados.Push(112);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s121
                            PilaEstados.Push(121);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //s69
                            PilaEstados.Push(69);
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
                            //s119
                            PilaEstados.Push(119);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
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
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 211:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(122);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Expr")
                            {
                                PilaEstados.Push(215);
                                i--;
                            }
                            else if (Simbolos.Peek() == "A")
                            {
                                PilaEstados.Push(113);
                                i--;
                            }
                            else if (Simbolos.Peek() == "B")
                            {
                                PilaEstados.Push(114);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(118);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(120);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s141
                            PilaEstados.Push(141);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s121
                            PilaEstados.Push(121);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        } 
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s119
                            PilaEstados.Push(119);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
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
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 212:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(122);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Expr")
                            {
                                PilaEstados.Push(216);
                                i--;
                            }
                            else if (Simbolos.Peek() == "A")
                            {
                                PilaEstados.Push(113);
                                i--;
                            }
                            else if (Simbolos.Peek() == "B")
                            {
                                PilaEstados.Push(114);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(118);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(120);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r62
                            AccionReduccion(62);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s141
                            PilaEstados.Push(141);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s121
                            PilaEstados.Push(121);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s119
                            PilaEstados.Push(119);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
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
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 213:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r74
                            AccionReduccion(74);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r74
                            AccionReduccion(74);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r74
                            AccionReduccion(74);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r74
                            AccionReduccion(74);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r74
                            AccionReduccion(74);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r74
                            AccionReduccion(74);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {

                            //r74
                            AccionReduccion(74);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r74
                            AccionReduccion(74);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r74
                            AccionReduccion(74);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r74
                            AccionReduccion(74);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r74
                            AccionReduccion(74);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r74
                            AccionReduccion(74);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            AccionReduccion(74);
                            i--;
                            //r74
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r74
                            AccionReduccion(74);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r74
                            AccionReduccion(74);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r74
                            AccionReduccion(74);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            AccionReduccion(74);
                            i--;
                            //r74
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r74
                            AccionReduccion(74);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r74
                            AccionReduccion(74);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r74
                            AccionReduccion(74);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 214:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r64
                            AccionReduccion(64);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r64
                            AccionReduccion(64);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r64
                            AccionReduccion(64);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r64
                            AccionReduccion(64);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r64
                            AccionReduccion(64);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r64
                            AccionReduccion(64);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {

                            //r64
                            AccionReduccion(64);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r64
                            AccionReduccion(64);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r64
                            AccionReduccion(64);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r64
                            AccionReduccion(64);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r64
                            AccionReduccion(64);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r64
                            AccionReduccion(64);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            AccionReduccion(64);
                            i--;
                            //r64
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r64
                            AccionReduccion(64);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r64
                            AccionReduccion(64);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r64
                            AccionReduccion(64);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            AccionReduccion(64);
                            i--;
                            //r64
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r64
                            AccionReduccion(64);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r64
                            AccionReduccion(64);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r64
                            AccionReduccion(64);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 215:
                        if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //s217
                            PilaEstados.Push(217);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 216:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "PrintStmt'")
                            {
                                PilaEstados.Push(218);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r72
                            AccionReduccion(72);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //s219
                            PilaEstados.Push(219);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 217:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "StmtBlock")
                            {
                                PilaEstados.Push(103);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Stmt")
                            {
                                PilaEstados.Push(220);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Stmt'")
                            {
                                PilaEstados.Push(96);
                                i--;
                            }
                            else if (Simbolos.Peek() == "IfStmt")
                            {
                                PilaEstados.Push(97);
                                i--;
                            }
                            else if (Simbolos.Peek() == "WhileStmt")
                            {
                                PilaEstados.Push(98);
                                i--;
                            }
                            else if (Simbolos.Peek() == "ForStmt")
                            {
                                PilaEstados.Push(99);
                                i--;
                            }
                            else if (Simbolos.Peek() == "ReturnStmt")
                            {
                                PilaEstados.Push(101);
                                i--;
                            }
                            else if (Simbolos.Peek() == "BreakStmt")
                            {
                                PilaEstados.Push(100);
                                i--;
                            }
                            else if (Simbolos.Peek() == "PrintStmt")
                            {
                                PilaEstados.Push(102);
                                i--;
                            }
                            else if (Simbolos.Peek() == "CallStmt")
                            {
                                PilaEstados.Push(104);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(122);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Expr")
                            {
                                PilaEstados.Push(105);
                                i--;
                            }
                            else if (Simbolos.Peek() == "A")
                            {
                                PilaEstados.Push(113);
                                i--;
                            }
                            else if (Simbolos.Peek() == "B")
                            {
                                PilaEstados.Push(114);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(118);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(120);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r62
                            AccionReduccion(62);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s112
                            PilaEstados.Push(112);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s121
                            PilaEstados.Push(121);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //s69
                            PilaEstados.Push(69);
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
                            //s119
                            PilaEstados.Push(119);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
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
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 218:
                        if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //s221
                            PilaEstados.Push(221);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        break;
                    case 219:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "Constant")
                            {
                                PilaEstados.Push(122);
                                i--;
                            }
                            else if (Simbolos.Peek() == "Expr")
                            {
                                PilaEstados.Push(222);
                                i--;
                            }
                            else if (Simbolos.Peek() == "A")
                            {
                                PilaEstados.Push(113);
                                i--;
                            }
                            else if (Simbolos.Peek() == "B")
                            {
                                PilaEstados.Push(114);
                                i--;
                            }
                            else if (Simbolos.Peek() == "C")
                            {
                                PilaEstados.Push(115);
                                i--;
                            }
                            else if (Simbolos.Peek() == "D")
                            {
                                PilaEstados.Push(116);
                                i--;
                            }
                            else if (Simbolos.Peek() == "E")
                            {
                                PilaEstados.Push(117);
                                i--;
                            }
                            else if (Simbolos.Peek() == "F")
                            {
                                PilaEstados.Push(118);
                                i--;
                            }
                            else if (Simbolos.Peek() == "G")
                            {
                                PilaEstados.Push(120);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //s141
                            PilaEstados.Push(141);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //s121
                            PilaEstados.Push(121);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            //s119
                            PilaEstados.Push(119);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //s125
                            PilaEstados.Push(125);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //s126
                            PilaEstados.Push(126);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //s127
                            PilaEstados.Push(127);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
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
                            //s123
                            PilaEstados.Push(123);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //s124
                            PilaEstados.Push(124);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 220:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r67
                            AccionReduccion(67);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r67
                            AccionReduccion(67);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r67
                            AccionReduccion(67);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r67
                            AccionReduccion(67);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r67
                            AccionReduccion(67);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r67
                            AccionReduccion(67);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {

                            //r67
                            AccionReduccion(67);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r67
                            AccionReduccion(67);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r67
                            AccionReduccion(67);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r67
                            AccionReduccion(67);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r67
                            AccionReduccion(67);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r67
                            AccionReduccion(67);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            AccionReduccion(67);
                            i--;
                            //r67
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r67
                            AccionReduccion(67);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r67
                            AccionReduccion(67);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r67
                            AccionReduccion(67);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            AccionReduccion(67);
                            i--;
                            //r67
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r64
                            AccionReduccion(64);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r74
                            AccionReduccion(74);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r74
                            AccionReduccion(74);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 221:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //s223
                            PilaEstados.Push(223);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 222:
                        if (BanderaReduccion == true)
                        {
                            BanderaReduccion = false;

                            if (Simbolos.Peek() == "PrintStmt'")
                            {
                                PilaEstados.Push(224);
                                i--;
                            }
                        }
                        else if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r72
                            AccionReduccion(72);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ",")
                        {
                            //s219
                            PilaEstados.Push(219);
                            Simbolos.Push(Lab_ASDR.TokenList[i]);
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 223:
                        if (Lab_ASDR.TokenList[i] == ";")
                        {
                            //r70
                            AccionReduccion(70);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "ident")
                        {
                            //r70
                            AccionReduccion(70);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "(")
                        {
                            //r70
                            AccionReduccion(70);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "{")
                        {
                            //r70
                            AccionReduccion(70);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "}")
                        {
                            //r70
                            AccionReduccion(70);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "if")
                        {
                            //r70
                            AccionReduccion(70);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "else")
                        {

                            //r70
                            AccionReduccion(70);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "while")
                        {
                            //r70
                            AccionReduccion(70);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "for")
                        {
                            //r70
                            AccionReduccion(70);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "return")
                        {
                            //r70
                            AccionReduccion(70);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "break")
                        {
                            //r70
                            AccionReduccion(70);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "System")
                        {
                            //r70
                            AccionReduccion(70);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == ".")
                        {
                            AccionReduccion(70);
                            i--;
                            //r70
                        }
                        else if (Lab_ASDR.TokenList[i] == "intConstant")
                        {
                            //r70
                            AccionReduccion(70);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "doubleConstant")
                        {
                            //r70
                            AccionReduccion(70);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "boolConstant")
                        {
                            //r70
                            AccionReduccion(70);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "stringConstant")
                        {
                            AccionReduccion(70);
                            i--;
                            //r70
                        }
                        else if (Lab_ASDR.TokenList[i] == "null")
                        {
                            //r70
                            AccionReduccion(70);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "New")
                        {
                            //r70
                            AccionReduccion(70);
                            i--;
                        }
                        else if (Lab_ASDR.TokenList[i] == "this")
                        {
                            //r70
                            AccionReduccion(70);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;
                    case 224:
                        if (Lab_ASDR.TokenList[i] == ")")
                        {
                            //r71
                            AccionReduccion(71);
                            i--;
                        }
                        else
                        {
                            ManejoError(i);
                            i = -1;
                        }
                        break;

                }
            }            
        }
    }
}
