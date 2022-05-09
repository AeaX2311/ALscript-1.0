﻿using Interfaz.Clases;
using Interfaz.Connection;
using System.Collections.Generic;
using System.Linq;

namespace Interfaz.Facade {
    class MatrizFacade {
        #region Componentes primordiales
        private MatrizConnection mc = new MatrizConnection();
        private string compilacion;
        private const char FDC = ' ';
        private const char FDL = '\n';
        private List<Error> errores;
        private List<Identificador> identificadores;
        #endregion

        #region Banderas y auxiliares
        private string mayusculas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private int numeroDeLinea;
        private int contadorLetras;
        private bool agregueIdentificador;
        private bool agregueFDC = false;
        private bool generaError = false;
        private bool ignorarFDC = false;
        private int contadorComentarios = 0;
        #endregion


        public MatrizFacade() {
            compilacion = "";
            numeroDeLinea = 1;
            errores = new List<Error>();
            identificadores = new List<Identificador>();
        }       

        /// <summary>
        /// Metodo principal / Compilacion del codigo ALscript
        /// </summary>
        /// <param name="codificacion">El codigo que se desea compilar</param>
        /// <returns>Codigo compilado y sus detalles</returns>
        public Compilado compilarCodigo(string codificacion) {
            do {
                    ////Inicializacion de banderas y auxiliares
                agregueIdentificador = generaError = ignorarFDC = false;
                contadorLetras = contadorComentarios = 0;

                    ////Recorre la siguiente palabra, setea el numero de "letras" leidas en contadorLetras
                recorrerPalabra(codificacion, 0, 1, false);

                    ////Se agrega el nombre del identificador
                if(agregueIdentificador) identificadores.Last().Nombre = codificacion.Substring(0, contadorLetras);

                    ////Elimina la parte inicial de la codificacion, parte que ya fue evaluada
                codificacion = codificacion.Substring(contadorLetras + (agregueFDC ? 0 : 1));

            } while(!string.IsNullOrWhiteSpace(codificacion));

            if(string.IsNullOrEmpty(compilacion)) {
                compilacion += "ERROR10";
                errores.Add(new Error("ERROR10", numeroDeLinea));
            }

            return new Compilado(compilacion, errores, identificadores);
        }

        /// <summary>
        /// Recursivo: Recorre la codificacion y determina si es un identificador, error, o un token normal.
        /// Dentro de su proceso ejecuta las acciones correspondientes segun el caso al que pertenezca la palabra.
        /// </summary>
        /// <param name="codigo">Codigo a evaluar</param>
        /// <param name="contadorLetras">Valor actual del contador de letras</param>
        /// <returns>La cantidad de letras que han sido evaluadas</returns>
        private int recorrerPalabra(string codigo, int contadorLetras, int estado, bool fueFDC) {
            bool isFDC;
            try {
                isFDC = esFDC(codigo[contadorLetras]);
            } catch { //Se salio del rango, es el final del codigo
                agregueFDC = true;
                return recorrerPalabra(codigo + FDC, contadorLetras, 241, true);
            }

            if(isFDC) { //revisarrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr
                isFDC = !ignorarFDC;
            }
            else
            if(codigo[contadorLetras] == FDL) {
                numeroDeLinea++;
                compilacion += FDL;
                return recorrerPalabra(codigo, ++contadorLetras, estado, false);
            }
            
            string resultado = buscarColumna(codigo[contadorLetras], estado);

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

        private string buscarColumna(char encabezado, int estado) {
            string columna = esFDC(encabezado) ? "FDC" : ("C" + encabezado); 
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
                agregueIdentificador = true; //Esta bandera activa la funcion de seteo de nombre al final del recorrido
                identificadores.Add(new Identificador("", null));

            } else if(resultado.Equals("ERROR")) {
                if(generaError)  return false;

                errores.Add(new Error(token, numeroDeLinea)); //Guarda el error
                generaError = true; //Realiza las instrucciones necesarias para evitar errores duplicados
            }

            compilacion += token; //Guarda el token
            return false;
        }

        private string procesarColumna(string columna) {
            char relevante = columna[1];

            if(columna.Equals("FDC") || columna.Equals("CAT")) //Ignora estos casos
                return columna;

            if(mayusculas.Contains(relevante))
                columna += relevante;

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
                    //TOMAR EN CUENTA SI ESTA DENTRO DE COMENTARIOOOOOOO
                    ignorarFDC = !ignorarFDC; //Invierte el valor 
                    break;
                case '#':
                    contadorComentarios++;
                    break;

                //if(pretendeComentario) {
                //    pretendeComentario = false;
                //    ignorarFDC = !ignorarFDC;
                //} else { 
                //    pretendeComentario = true;
                //}

                //                    return columna;
                default:
                    contadorComentarios = 0;
                    break;
            }

            if(contadorComentarios == 2) {
                ignorarFDC = !ignorarFDC;
                contadorComentarios = 0;
            }

            return columna;
        }

        public string obtenerDescripcionError(Error error) {
            if(error.isNullOrEmpty()) return null;

            return mc.obtenerError(error.Token);
        }

        private bool esFDC(char caracter) {
            return caracter == FDC;//&& !ignorarFDC; //|| caracter == ';'; Comentado momentaneamente, prox.. AC. 08-05-22.
        }
    }
}
