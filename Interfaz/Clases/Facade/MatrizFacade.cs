using Interfaz.Clases;
using Interfaz.Connection;
using System.Collections.Generic;
using System.Linq;

namespace Interfaz.Facade {
    class MatrizFacade {
        private MatrizConnection mc = new MatrizConnection();

        private string compilacion;
        private const char FDC = ' ';
        private const char FDL = '\n';
        private int numeroDeLinea;
        private List<Error> errores;
        private List<Identificador> identificadores;
        private bool agregueIdentificador;
        private int contadorLetras;
        private string mayusculas = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private bool aux = false;

        public MatrizFacade() {
            compilacion = "";
            numeroDeLinea = 1;
            errores = new List<Error>();
            identificadores = new List<Identificador>();
        }       

        public Compilado compilarCodigo(string codificacion) {
            do {
                agregueIdentificador = false;
                contadorLetras = 0;
                    ////Cantidad de "letras" que ya se evaluaron
                recorrerPalabra(codificacion, 0, 1, false);

                    ////Se agrega el nombre del identificador
                if(agregueIdentificador) identificadores.Last().Nombre = codificacion.Substring(0, contadorLetras);

                ////Elimina la parte inicial de la codificacion, parte que ya fue evaluada
                if(aux) contadorLetras--;
                codificacion = codificacion.Substring(contadorLetras + 1);
                //codificacion = null;
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
                aux = true;
                //codificacion += FDC;
                return recorrerPalabra(codigo + FDC, contadorLetras, 241, true);
            }

            if(isFDC) {
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

            return fueFDC ? contadorLetras : (isFDC ? recorrerPalabra(codigo, contadorLetras, estado, true) : recorrerPalabra(codigo, ++contadorLetras, estado, false));
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
                errores.Add(new Error(token, numeroDeLinea)); //Guarda el error
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
            else if(relevante == '!')
                columna = "Cnot";
            else if(relevante == '.')
                columna = "Cpunto";

            return columna;
        }

        public string obtenerDescripcionError(Error error) {
            if(error.isNullOrEmpty()) return null;

            return mc.obtenerError(error.Token);
        }

        private bool esFDC(char caracter) {
            return caracter == FDC ; //|| caracter == ';'; Comentado momentaneamente, prox.. AC. 08-05-22.
        }
    }
}
