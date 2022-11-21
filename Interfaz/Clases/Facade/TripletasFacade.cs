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
                string instruccion = instrucciones[x];

                auxOperacionesRealizadas = new List<string>();
                //instrucciones[x] = aplicarJerarquiaInstruccion(instrucciones[x]);
                aplicarJerarquiaInstruccion(instrucciones[x]);


            }

            //Separar las operaciones de 3 en 3

            //Pasarlas a lenguaje ensamblador


            txtTripletas.Lines = instrucciones.ToArray();
            txtTripletas.Text += "\n\n\n";
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
            List<string> elementos = instruccion.Split(' ').ToList();
            int longitud = elementos.Count;

            if(longitud == 3) {
                //if(instruccion.Contains("="))
                    return "OK";//creo que es 4 siempre entonces no hay problema..................
                //else {
                //    return "OP";
                //    //hacer algo con la suma.p.ej.
                //}
            }

            // string instruccionModificada = instruccion;


            //Si encuentras un parentesis, guardaras en un arreglo todas las operaciones que se ejecutaran en ese parentesis
            //Repetir para todos los parentesis que existan, hasta que todos los parentesis hayan sido evaluados
            for(int pos = 0; pos < elementos.Count; pos++) {
                string elemento = elementos[pos];
                if(elemento.Equals("(")) {
                    //Reemplazar todo lo que este dentro del parentesis por el valor que devuelva el metodo
                    int reemplazos = pos + 1; string operacionEntreParentesis = "", auxElemento;
                    do { //Va concatenando todo lo que esta dentro del parentesis
                        auxElemento = elementos[reemplazos];
                        operacionEntreParentesis += auxElemento + " ";
                        reemplazos++;
                    } while(!auxElemento.Equals(")"));

                    //En este punto ya encontro el cierre del parentesis
                    //Debemos quitar el parentesis agregado de la instruccion a evaluar
                    operacionEntreParentesis = operacionEntreParentesis.Replace(") ", "");

                    //Contamos cuantos elementos hay dentro de los parentesis
                    int elementosDentroDeParentesis = reemplazos - pos -1;

                    //Reemplazamos el primer elemento por la PK de la OP que haya regresado la evaluacion interna de los parentesis
                    elementos[pos++] = aplicarJerarquiaInstruccion(operacionEntreParentesis);
                    //fgfg += "DENTRO PAR: " + operacionEntreParentesis+"\n";
                    //Removemos (del listado original) el resto de n elementos que estaban dentro del parentesis
                    while(elementosDentroDeParentesis-- > 0) elementos.RemoveAt(pos);
                }
            }

            //foreach(string e in elementos) {
            //    fgfg += e;
            //}
            //Cuand ya hayan desaparecido todos los parentesis, aplicar jerarquia de operadores
            //Buscar * y /, si la encuentras, aplica esa operacion (guardala en el arreglo)
            //la primera iteracion, guarda el valor de la izquierda
            //mas iteraciones es AX operacion valor derecha

            //Buscar + y -, si la encuentras, aplica esa operacion

            //Ya no deberia haber nada mas que una asignacion


            return "OP";
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
    }
}
