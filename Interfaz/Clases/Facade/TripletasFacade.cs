using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz.Clases.Facade {
    class TripletasFacade {

        string fgfg = "";
        List<string> auxOperacionesRealizadas;

        public RichTextBox tripletasGo(RichTextBox txtCodificacion, RichTextBox txtLexico, RichTextBox txtTripletas) {
            //Encontrar las lineas que vas a evaluar
            List<string> instrucciones = buscarValoresInstrucciones(buscarInstruccionesAEvaluar(txtLexico), txtCodificacion);

            //Se deben de ordenar jerarquicamente todas las operaciones que se van a realizar
            
            for(int x = 0; x < instrucciones.Count(); x++) {
                auxOperacionesRealizadas = new List<string>();
                auxOperacionesRealizadas.Add(aplicarJerarquiaInstruccion(instrucciones[x]) + " = " + generarTokenOperacion(true));

                foreach(string a in auxOperacionesRealizadas) {
                    fgfg += "\n" + a;
                }
                fgfg += "\n";

            }

            //Separar las operaciones de 3 en 3

            //Pasarlas a lenguaje ensamblador


            txtTripletas.Lines = instrucciones.ToArray();
            txtTripletas.Text += "\n----\n";
            txtTripletas.Text += fgfg;

            return txtTripletas;
        }


        /*                  
            val1 = 15
            val2 = 77 + 22 * 5 - 33 / 5 + 3 - 2 + 3
            val3 = 3 + val1
               0 1 2 3 4 5 6 7 8 99 1 1 2 3 4 5 6 7 8
            val6 = 4 + 7 * 5 - ( 33 + 3 * 3 ) / 3 + 3
            val4 = 2 * val2
            val5 = 1 / val4                 
         */

        private string aplicarJerarquiaInstruccion(string instruccion) {
            List<string> elementos = instruccion.Split(' ').Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
            int longitud = elementos.Count;

            //if(longitud == 3 && elementos.Contains("=")) //Se trata del final de todas las operaciones
            //    return "ERR";

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
                        auxOperacionesRealizadas.Add(operacionPK + " = " + elementos[pos - 1] + elemento + elementos[pos + 1]);

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
                        auxOperacionesRealizadas.Add(operacionPK + " = " + elementos[pos - 1] + elemento + elementos[pos + 1]);

                        //Se reemplaza la operacion por una operacion con su PK
                        elementos[pos - 1] = operacionPK;

                        //Se eliminan los otros dos elementos
                        elementos.RemoveAt(pos);
                        elementos.RemoveAt(pos--);
                    }
                }
            }

            //Ya no deberia haber nada mas que una asignacion

            //fgfg += "----------->";
            //foreach(string e in elementos) {
            //    fgfg += e;
            //}
            //fgfg += "---------->";
            return elementos[0];
        }

        private List<string> buscarValoresInstrucciones(List<int> numerosLineas, RichTextBox txtCodificacion) {
            List<string> lineas = new List<string>();

            //Busca lineas de asignacion
            for(int numeroLinea = 0; numeroLinea < txtCodificacion.Lines.Length; numeroLinea++) {
                bool auxCondicion = false;
                try { auxCondicion = numerosLineas[numeroLinea] == numeroLinea; } catch { }

                if(auxCondicion) { //La linea contiene una asignacion
                    string linea = txtCodificacion.Lines[numeroLinea];                    
                    
                    //Para poder buscar entre operaciones "pegadas"
                    linea = linea.Replace("+", " + ").Replace("/", " / ").Replace("*", " * ").Replace("-", " - ").Replace("(", " ( ").Replace(")", " ) ").Replace("=", " = ").Replace(";", "").Replace("  ", " ");

                    //Guardar cada una de las asignaciones
                    lineas.Add(linea.Replace("declarar variable ", ""));                    
                }
            }

            return lineas;
        }

        private List<int> buscarInstruccionesAEvaluar(RichTextBox txtLexico) {
            List<int> numeroLineas = new List<int>();

            //Busca lineas de asignacion
            for(int numeroLinea = 0; numeroLinea < txtLexico.Lines.Length; numeroLinea++) {
                string linea = txtLexico.Lines[numeroLinea];
                linea = Regex.Replace(linea, @"\bIDEN#[0-9]+", "IDEN");
                
                if(linea.Contains("IDEN ASIG")) { //Si se esta realizando una asignacion
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
