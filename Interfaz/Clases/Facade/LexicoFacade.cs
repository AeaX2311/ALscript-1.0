using Interfaz.Connection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Interfaz.Clases.Facade {
    class LexicoFacade {
        #region Componentes primordiales
        private MatrizConnection mc = new MatrizConnection();
        private string compilacion;
        private const char FDC = ' ';
        private const char FDL = '\n';
        private List<Error> errores;
        private Dictionary<string, Identificador> identificadores;
        private int numeroDeLinea;
        #endregion

        #region Banderas y auxiliares
        private string mayusculas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private int contadorLetras;
        private bool agregueIdentificador;
        private bool agregueFDC = false;
        private bool generaError = false;
        private bool ignorarFDC = false;
        private int contadorComentarios = 0;
        private bool estoyEnComentario = false;
        private bool estoyEnCadena = false;
        private bool buscoAsignacion = false;
        private bool buscoValorParaIdentificador = false;
        private string auxTipoDatoIdentificador;
        private string auxNombreIdentificador;
        private List<string> palabrasARemarcarError;
        private bool agregarPuntoYComa;
        private bool identificadorDeclarado = false;
        #endregion

        public LexicoFacade() {
            compilacion = "";
            numeroDeLinea = 1;
            errores = new List<Error>();
            identificadores = new Dictionary<string, Identificador>();
            palabrasARemarcarError = new List<string>();
        }

        private string agregarEspacio(int posicion, string codificacion) {
            return codificacion.Substring(0, posicion) + " " + codificacion.Substring(posicion);
        }

        private string codificacionPosibles = "=+-*/{}()[]><|&!@$^%";
        private string inicializarCodificacion(string codificacion) {
            int recorridos = codificacion.Length;
            for(int pos = 0; pos < recorridos; pos++) {
                if(codificacionPosibles.Contains(codificacion[pos])) {
                    try {
                        if(!codificacion[pos - 1].Equals(' ')) {
                            codificacion = agregarEspacio(pos, codificacion);
                            recorridos++;
                            pos++;
                        }
                        if(!codificacion[pos + 1].Equals(' ')) {
                            codificacion = agregarEspacio(pos + 1, codificacion);
                            recorridos++;
                            pos++;
                        }
                    } catch { }
                }
            }

            return codificacion;
        }

        private string juntarTokens(string codificacion) {
            codificacion = codificacion.Replace("CE14 CE14", "OPL2"); //OR
            codificacion = codificacion.Replace("CE5 CE5", "OPL3"); //AND
            codificacion = codificacion.Replace("OPR1 ASIG", "OPR3"); //<=
            codificacion = codificacion.Replace("OPR2 ASIG", "OPR4"); //>=
            codificacion = codificacion.Replace("OPL1 ASIG", "OPR5"); //!=
            codificacion = codificacion.Replace("ASIG ASIG", "OPR6"); //==
            return codificacion;
        }

        /// <summary>
        /// Metodo principal que ejecuta todos los procesos necesarios para evaluar el lexico de la entrada del usuario.
        /// </summary>
        /// <param name="codificacion">Entrada del usuario en formato de cadena</param>
        /// <returns>Codigo compilado del lexico y sus detalles</returns>
        public Compilado compilarCodigo(string codificacion) {
            codificacion = inicializarCodificacion(codificacion);
            do {
                    ////Inicializacion de banderas y auxiliares
                agregueIdentificador = generaError = ignorarFDC = estoyEnComentario = estoyEnCadena = agregarPuntoYComa = false;
                contadorLetras = contadorComentarios = 0;
                auxTipoDatoIdentificador = null;

                    ////Recorre la siguiente palabra, setea el numero de "letras" leidas en contadorLetras
                recorrerPalabra(codificacion, 0, 1, false);

                    ////Se agrega el nombre del identificador
                if(agregueIdentificador) {
                    SetAuxNombreIdentificador(codificacion.Substring(0, contadorLetras));

                    if(!identificadores.ContainsKey(auxNombreIdentificador)) {
                            //Agrega el nuevo identificador
                        identificadores.Add(auxNombreIdentificador, new Identificador(auxNombreIdentificador, null, identificadores.Count + 1));

                            //Le agrega el secuencial a los identificadores
                        compilacion = compilacion.Remove(compilacion.Length - 1, 1) + "#" + identificadores.Count + compilacion.Last();
                    } else {
                            //Le agrega el secuencial a la copilacion del codigo, realizando la busqueda del identificador existente
                        compilacion = compilacion.Remove(compilacion.Length - 1, 1) + "#" + obtenerTokenIdentificador(auxNombreIdentificador) + compilacion.Last();
                    }
                } else if (generaError) { //Contiene un error, guarda la palabra para poder "pintarla" despues
                    errores.Last().Palabra = codificacion.Substring(0, contadorLetras);
                    palabrasARemarcarError.Add(codificacion.Substring(0, contadorLetras));
                }

                    ////Marcar que el identificador ya ha sido asignado.
                if(identificadorDeclarado) { 
                    identificadorDeclarado = false;
                    identificadores[auxNombreIdentificador].Asignada = true;
                }

                    ////Asigna valor y tipo de dato a identificador, en caso de que se cumplan las condiciones
                if(buscoValorParaIdentificador && auxTipoDatoIdentificador != null) {
                    identificadores[auxNombreIdentificador].TipoDato = auxTipoDatoIdentificador;
                    identificadores[auxNombreIdentificador].Valor = codificacion.Substring(0, contadorLetras);


                    buscoAsignacion = buscoValorParaIdentificador = false;
                }

                    ////Agregacion global de punto y coma a compilacion, se representa con el token CE13
                if(agregarPuntoYComa) compilacion += "CE13";

                    ////Agregado de separacion entre tokens, en caso de necesitarlo
                if(compilacion != "" && compilacion.Last() != ' ' && compilacion.Last() != '\n') compilacion += " ";

                    ////Elimina la parte inicial de la codificacion, parte que ya fue evaluada
                codificacion = codificacion.Substring(contadorLetras + (agregueFDC ? 0 : 1));

            } while(!string.IsNullOrWhiteSpace(codificacion));

            if(string.IsNullOrEmpty(compilacion)) { //Validacion inicial, cadena vacia o con inicio indeterminado
                compilacion += "ERROR10";
                errores.Add(new Error("ERROR10", numeroDeLinea));
            }

            return new Compilado(juntarTokens(compilacion), errores, identificadores.Select(id => id.Value).ToList(), palabrasARemarcarError);
        }

        /// <summary>
        /// Recursivo: Recorre la codificacion y determina si es un identificador, error, o un token normal.
        /// Dentro de su proceso ejecuta las acciones correspondientes segun el caso al que pertenezca la palabra.
        /// </summary>
        /// <param name="codigo">Codigo a evaluar</param>
        /// <param name="contadorLetras">Valor actual del contador de letras</param>
        /// <returns>Cero, indicando que la recursividad se aplico correctamente</returns>
        private int recorrerPalabra(string codigo, int contadorLetras, int estado, bool fueFDC) {
            bool isFDC;
            try {
                isFDC = esFDC(codigo[contadorLetras]);
            } catch { //Se salio del rango, es el final del codigo
                agregueFDC = true;
                return recorrerPalabra(codigo + FDC, contadorLetras, 240, true);
            }

            if(isFDC) {
                if(codigo[contadorLetras] == ';') {
                    agregarPuntoYComa = true;
                } else {
                    isFDC = !ignorarFDC;
                }
            } else if(codigo[contadorLetras] == FDL) {
                numeroDeLinea++;
                compilacion += FDL;
                return recorrerPalabra(codigo, ++contadorLetras, estado, false);
            }
            
            string resultado = buscarColumna(codigo[contadorLetras], estado);

            if(resultado == null) { //Ignora posicion, salta palabra porque es un espacio en blanco
                return contadorLetras;
            }

            if(realizarMovimientoAEstado(resultado, estado)) estado = int.Parse(resultado);

            if(fueFDC) {
                compilacion += FDC;
                this.contadorLetras = contadorLetras;
            }

            return fueFDC 
                ? contadorLetras 
                : (isFDC 
                    ? recorrerPalabra(codigo, contadorLetras, estado, true) 
                    : recorrerPalabra(codigo, ++contadorLetras, estado, false));
        }

        /// <summary>
        /// Realiza una busqueda inteligente de columnas en la matriz de transicion
        /// </summary>
        /// <param name="encabezado">SELECT</param>
        /// <param name="estado">WHERE</param>
        /// <returns>La consulta (campo) que se encontro</returns>
        private string buscarColumna(char encabezado, int estado) {
            string columna = esFDC(encabezado) ? "FDC" : ("C" + encabezado);
            if(estado == 1 && columna.Equals("FDC"))
                return null;
            return mc.obtenerResultado(procesarColumna(columna), estado);
        }

        /// <summary>
        /// Determina en base a un resultado obtenido, si es necesario realizar un "movimiento" a un estado,
        /// o en caso contrario, almacenar el token obtenido.
        /// </summary>
        /// <param name="resultado">Resultado evaluado previamente, seleccion de un estado con encabezado.</param>
        /// <param name="estado">Estado del cual se genero el resultado.</param>
        /// <returns>Verdadero, si el resultado es otro estado. Falso si el resultado es un final.</returns>
        private bool realizarMovimientoAEstado(string resultado, int estado) {
            if(resultado.All(char.IsDigit)) return true;

            string token = mc.obtenerToken(estado);

            if(token == null) return false;                

            if(token.Equals("IDEN")) {
                agregueIdentificador = buscoAsignacion  = true; //Esta bandera activa la funcion de seteo de nombre al final del recorrido
                try { ////Si al momento de encontrar un identificador, antes se encuentra "declarar variable", entonces marcalo como declarado.
                    identificadorDeclarado = compilacion.Substring(compilacion.Length - 10).Equals("PRI6 PRV1 ");
                } catch { identificadorDeclarado = false; }
            } else if(resultado.Equals("ERROR")) {
                if(generaError)  return false;

                errores.Add(new Error(token, numeroDeLinea)); //Guarda el error
                generaError = true; //Realiza las instrucciones necesarias para evitar errores duplicados
            } else if (!resultado.Equals("ACEPTA")) { //Contiene la descripcion del error
                if(generaError)  return false;

                token = mc.obtenerErrorPorDescripcion(resultado);
                errores.Add(new Error(token, numeroDeLinea)); //Guarda el error
                generaError = true; //Realiza las instrucciones necesarias para evitar errores duplicados
            } else if (token.Equals("ASIG") && buscoAsignacion) {
                buscoValorParaIdentificador = true;
            } else if(buscoValorParaIdentificador) {
                if(!token.Equals("CE6")) auxTipoDatoIdentificador = token;
            }

            compilacion += token; //Guarda el token
            return false;
        }

        /// <summary>
        /// Realiza el procesamiento logico de cada columna, para que pueda ser reconocida por SQL.
        /// Adicional, realiza operaciones segun el caracter ingresado.
        /// </summary>
        /// <param name="columna">La columna que se quiere buscar</param>
        /// <returns></returns>
        private string procesarColumna(string columna) {
            char relevante = columna[1];

            if(columna.Equals("FDC") || columna.Equals("CAT")) //Ignora estos casos
                return columna;

            if(mayusculas.Contains(relevante))
                columna += relevante;
            if(relevante != '#')
                contadorComentarios = 0;

            switch(relevante) {
                case '!':
                    columna = "Cnot";
                    break;
                case '.':
                    columna = "Cpunto";
                    break;
                case '[':
                    columna = "Cllar";
                    break;
                case ']':
                    columna = "Cllal";
                    break;
                case '"':
                    if(!estoyEnComentario) ignorarFDC = estoyEnCadena = !ignorarFDC; //Invierte el valor 
                    break;
                case '#':
                    if(!estoyEnCadena) contadorComentarios++;
                    break;
            }

            if(contadorComentarios == 2) {
                ignorarFDC = estoyEnComentario = !ignorarFDC;
                contadorComentarios = 0;
            }

            return columna;
        }

        /// <summary>
        /// Realiza una busqueda de la descripcion de un error
        /// </summary>
        /// <param name="error">Error que se busca</param>
        /// <returns>Descripcion del error</returns>
        public string obtenerDescripcionError(Error error) {
            if(error.isNullOrEmpty()) return null;

            return mc.obtenerErrorPorToken(error.Token);
        }

        /// <summary>
        /// Determina si un caracter es un final de cadena
        /// </summary>
        /// <param name="caracter">Caracter a evaluar</param>
        /// <returns>Verdadero o falso segun el caso</returns>
        private bool esFDC(char caracter) {
            return caracter == FDC || caracter == ';';
        }

        /// <summary>
        /// Seteo de KEY para identificadores. Evita caracteres vacios.
        /// </summary>
        /// <param name="value">El valor que se intenta setear</param>
        private void SetAuxNombreIdentificador(string value) {
            string nombreLimpio = "";

            foreach(char c in value) {
                if(c != '\n' && c != ' ' && c != '\t')
                    nombreLimpio += c;
            }

            auxNombreIdentificador = nombreLimpio;
        }

        /// <summary>
        /// Devuelve el numero secuencial de determinado identificador.
        /// </summary>
        /// <param name="nombreIdentificador">El nombre o KEY del identificador que se esta buscando</param>
        /// <returns>El secuencial del identificador, o -1 en caso de no existir.</returns>
        private int obtenerTokenIdentificador(string nombreIdentificador) {
            return identificadores.ContainsKey(nombreIdentificador) ? identificadores[nombreIdentificador].Secuencial : -1;
        }

        /// <summary>
        /// Cambia el tipo de dato a uno mas amigable visualmente
        /// </summary>
        /// <param name="token">Tipo de dato original</param>
        /// <returns>Tipo de dato renombrado</returns>
        public string determinarTipoDato(string token) {
            string tipoDato;

            switch(token) {
                case "CADENA":
                    tipoDato = "Alfanumerico";
                    break;
                case "CONSTENT":
                    tipoDato = "Entero";
                    break;
                case "CONSTRE":
                    tipoDato = "Decimal";
                    break;
                case "CONSTEX":
                    tipoDato = "Exponencial";
                    break;
                case "PRB1":
                    tipoDato = "Boleano";
                    break;
                case "PRB2":
                    tipoDato = "Boleano";
                    break;
                default:
                    tipoDato = "N/A";
                    break;
            }

            return tipoDato;
        }
    }
}
