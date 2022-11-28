using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Interfaz.Clases.Facade {
    class TripletasFacade {

        List<string> operacionesConJerarquia;
        List<string> auxOperacionesRealizadas;       

        public string tripletasGo(List<string> instrucciones) {
            //Encontrar las lineas que vas a evaluar
            operacionesConJerarquia = new List<string>();
            string auxOperaciones = ""; string auxOperacion;

            //Se deben de ordenar jerarquicamente todas las operaciones que se van a realizar            
            //Separar las operaciones de 3 en 3
            for(int x = 0; x < instrucciones.Count(); x++) {
                auxOperacion = "";
                auxOperacionesRealizadas = new List<string>();
                auxOperacionesRealizadas.Add(aplicarJerarquiaInstruccion(instrucciones[x]) + " = " + generarTokenOperacion(true));
                
                foreach(string operacion in auxOperacionesRealizadas) auxOperacion += "\n" + operacion; 
               
                operacionesConJerarquia.Add(auxOperacion);
                auxOperaciones += auxOperacion + "\n";
            }

            return "--------------------------------\nJERARQUIA OPERACIONES APLICADA\n--------------------------------" + auxOperaciones + "\n--------------------------------\n";
        }

        /// <summary>
        /// Genera operaciones a manera jerarquica. Solo aritmeticamente.
        /// </summary>
        /// <param name="instruccion">...</param>
        /// <returns>...</returns>
        private string aplicarJerarquiaInstruccion(string instruccion) {
            List<string> elementos = instruccion.Split(' ').Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
            int longitud = elementos.Count;

            //Si encuentras un parentesis, guardaras en un arreglo todas las operaciones que se ejecutaran en ese parentesis
            //Repetir para todos los parentesis que existan, hasta que todos los parentesis hayan sido evaluados
            if(elementos.Contains("(")) {
                for(int pos = 0; pos < elementos.Count; pos++) {
                    string elemento = elementos[pos];
                    
                    if(elemento.Equals("(")) {
                        //Reemplazar todo lo que este dentro del parentesis por el valor que devuelva el metodo
                        int reemplazos = pos + 1;
                        string operacionEntreParentesis = "", auxElemento;
                        do { //Va concatenando todo lo que esta dentro del parentesis
                            auxElemento = elementos[reemplazos];
                            operacionEntreParentesis += auxElemento + " ";
                            reemplazos++;
                        } while(!auxElemento.Equals(")"));

                        //En este punto ya encontro el cierre del parentesis
                        //Debemos quitar el parentesis agregado de la instruccion a evaluar
                        operacionEntreParentesis = operacionEntreParentesis.Replace(") ", "");

                        //Contamos cuantos elementos hay dentro de los parentesis
                        int elementosDentroDeParentesis = reemplazos - pos - 1;

                        //Reemplazamos el primer elemento por la PK de la OP que haya regresado la evaluacion interna de los parentesis
                        elementos[pos++] = aplicarJerarquiaInstruccion(operacionEntreParentesis);

                        //Removemos (del listado original) el resto de n elementos que estaban dentro del parentesis
                        while(elementosDentroDeParentesis-- > 0) elementos.RemoveAt(pos);
                    }
                }
            }

            //Cuando ya hayan desaparecido todos los parentesis, aplicar jerarquia de operadores
            //Buscar * y /, si la encuentras, aplica esa operacion (guardala en el arreglo)
            if(elementos.Contains("*") || elementos.Contains("/")) {
                for(int pos = 0; pos < elementos.Count; pos++) {
                    string elemento = elementos[pos];

                    if(elemento.Equals("*") || elemento.Equals("/")) {
                        //Guardamos la operacion que se realiza
                        string operacionPK = generarTokenOperacion(false);
                        auxOperacionesRealizadas.Add(operacionPK + " = " + elementos[pos - 1] + " " + elemento + " " + elementos[pos + 1]);

                        //Se reemplaza la operacion por una operacion con su PK
                        elementos[pos - 1] = operacionPK;

                        //Se eliminan los otros dos elementos
                        elementos.RemoveAt(pos); elementos.RemoveAt(pos--);
                    }
                }
            }

            ////Buscar + y -, si la encuentras, aplica esa operacion
            if(elementos.Contains("+") || elementos.Contains("-")) {
                for(int pos = 0; pos < elementos.Count; pos++) {
                    string elemento = elementos[pos];

                    if(elemento.Equals("+") || elemento.Equals("-")) {
                        //Guardamos la operacion que se realiza
                        string operacionPK = generarTokenOperacion(false);
                        auxOperacionesRealizadas.Add(operacionPK + " = " + elementos[pos - 1] + " " + elemento + " " + elementos[pos + 1]);

                        //Se reemplaza la operacion por una operacion con su PK
                        elementos[pos - 1] = operacionPK;

                        //Se eliminan los otros dos elementos
                        elementos.RemoveAt(pos);
                        elementos.RemoveAt(pos--);
                    }
                }
            }

            return elementos[0];
        }

        /// <summary>
        /// En base a un listado de lineas, obtiene y procesa los datos que se encuentren en esa linea para mandarlos al codigo a ejecutar en ensamblador.
        /// </summary>
        /// <param name="numerosLineas">...</param>
        /// <param name="txtCodificacion">...</param>
        /// <returns>...</returns>
        public List<string> buscarValoresInstrucciones(List<int> numerosLineas, RichTextBox txtCodificacion) {
            List<string> lineas = new List<string>();

            //Busca lineas de asignacion
            for(int numeroLinea = 0; numeroLinea < txtCodificacion.Lines.Length; numeroLinea++) {
                bool auxCondicion = false;
                try { auxCondicion = numerosLineas[numeroLinea] == numeroLinea; } catch { }

                if(auxCondicion) { //La linea contiene una instruccion que se va a guardar
                    string linea = txtCodificacion.Lines[numeroLinea];                    
                    
                    //Para poder buscar entre operaciones "pegadas"
                    linea = linea.Replace("+", " + ").Replace("/", " / ").Replace("*", " * ").Replace("-", " - ").Replace("(", " ( ").Replace(")", " ) ").Replace("=", " = ").Replace(";", "").Replace("  ", " ");

                    //Guardar cada una de las asignaciones
                    lineas.Add(linea.Replace("declarar variable ", "declarar"));
                    
                }
            }

            return lineas;
        }

        /// <summary>
        /// Genera un listado de numeros de lineas que deben ser agregadas para procesarse en ensamblador:
        /// 1-Asignaciones/Declararciones
        /// 2-Imprimir
        /// 3-Leer
        /// </summary>
        /// <param name="txtLexico">...</param>
        /// <returns>...</returns>
        public List<int> buscarInstruccionesAEvaluar(RichTextBox txtLexico) {
            List<int> numeroLineas = new List<int>();

            //Busca lineas de asignacion
            for(int numeroLinea = 0; numeroLinea < txtLexico.Lines.Length; numeroLinea++) {
                string linea = txtLexico.Lines[numeroLinea];
                linea = Regex.Replace(linea, @"\bIDEN#[0-9]+", "IDEN");

                if(linea.Contains("IDEN ASIG") || linea.Contains("PRI5") || linea.Contains("PRI4")) { //Si se esta realizando una asignacion, lectura o impresion
                    numeroLineas.Add(numeroLinea);
                } else {
                    numeroLineas.Add(-1);
                }
            }

            return numeroLineas;
        }

        /// <summary>
        /// Devuelve una PK de la operacion actual (de las guardadas).
        /// </summary>
        /// <returns>...</returns>
        private string generarTokenOperacion(bool isFinal) {
            return $"OP{auxOperacionesRealizadas.Count + (isFinal ? 0 : 1)}";
        }
    }
}
