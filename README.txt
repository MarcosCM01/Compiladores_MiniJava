minij

Este es un programa de análisis léxico el cual tiene como finalidad el reconocimiento de caracteres y generar de salida tokens para
un futuro uso en un análisis sintactico.

Funcionamiento: Para la generación del análisis el programa en primer lugar recibe un archivo de cualquier tipo de extensión cargado al
ejecutable, este puede ser arrastrando el archivo sobre el ejetuble o bien mandar el archivo desde comandos en el cmd.
Ya cargado el archivo a analizar hacemos un recorrido caracter a caracter en el cual vamos validando por medio de expresiones regulares
y en este caso al utilizar el lenguaje de programación C# especificamente utilizamos la libreria de regex para el uso y validación 
de dichas expresiones regulares, las cuales verifican que la secuencia de caracteres que se estan concatenando pertenecen a un conjunto
de palabras reservadas, identifadores, constantes (int,double,bool,hexadecimal,string y decimal) así como comentarios de una linea o 3
multilinea, todos estas secuencias de caracteres produciran tokens, especificando el número de linea y número de columna de inicio y
fin en donde se encuentran así como su valor, los tokens son mostrados en pantalla así como impresos en un archivogenerado de extensión
 .out el cual se imprime en la misma dirección en la cual se encuentra el archivo a analizar. 

¿Por qué es robusto?
Consideramos que nuestro analizador léxico es consistente ya que sabe manejar distintos tipos de errores en los cuales cuales podemos destacar:
	Caracteres no validos en la gramática mostrando un mensaje donde se imprime el caracter en cuestion.
	String sin terminar estos se identifican al momento de no encontrar una comilla de cierre en la linea por lo que se reporta como cadena sin terminar.
	Identificadores de una longitud no permitida: Al momento de encontrar una secuencia de caracteres que superen la longitud máxima aceptada
						      se muestra un mensaje de error y a su vez truncando el identificador con los primeros 31 caracteres
	Comentario multilinea abierto en final de archivo: El programa reportara dicho error dado que al realizar el análsis no encuentra */ para su cierre
	Fin de comentario sin emparejar: Al momento de encontrar la secuencia */ sin antes encontrar su inicio se reporta como comentario sin emparejar 
					 y continua el análsis.
Nostros consideramos que al manejar este tipo de errores hemos realizado un analizador bastante robusto el cual al encontrar errores los 
reporta y continua con el análsis 

	Eduardo Albarizaez 1106918
	Marcos Calderon 1060918