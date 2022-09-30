using Interfaz.Clases.Compilacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaz.Clases.Facade {
    class SintaxisFacade {
        #region Componentes primordiales
        private List<List<string>> tokens; //Contiene el listado global de tokens ordenados segun se mando. NO MODIFICABLE.
        private string resultadoFinal;
        private List<Gramatica> gramaticasSintaxis;
        private int k;
        #endregion

        private void init(string archivoTokens) {
            tokens = dividirStringPorLineas(archivoTokens);
            resultadoFinal = "";
            gramaticasSintaxis = generarGramatica();
        }

        /// <summary>
        /// Metodo publico que ejecuta todos los procesos necesarios para evaluar la sintaxis del lexico.
        /// </summary>
        /// <param name="archivoTokens">Lexico en formato de cadna</param>
        /// <returns>Construccion del resultado de la sintaxis</returns>
        public string evaluarSintaxis(string archivoTokens) {
            init(archivoTokens);

            foreach(List<string> linea in tokens) {
                //se guarda resultado final....
                string pk = recorrerLinea(linea);
                resultadoFinal += "->" + pk;
            }
            //foreach(List<string> linea in tokens) {
            //    foreach(string token in linea) {
            //        resultadoFinal += token;
            //    }
            //}
            //resultadoFinal += "\n";
            //tokens[0].RemoveAt(2);
            //foreach(List<string> linea in tokens) {
            //    foreach(string token in linea) {
            //        resultadoFinal += token;
            //    }
            //}
            //tokens[0].RemoveAt(2);
            //resultadoFinal += "\n";
            //foreach(List<string> linea in tokens) {
            //    foreach(string token in linea) {
            //        resultadoFinal += token;
            //    }
            //}
            //resultadoFinal += "\n";
            //tokens[0][2] = "AHORAESTOJEJE";
            //foreach(List<string> linea in tokens) {
            //    foreach(string token in linea) {
            //        resultadoFinal += token;
            //    }
            //}


            //resultadoFinal = "Aqui va todo el resultado final jeje salu2.";
            return resultadoFinal;
        }

           //regresa el pk (caso correcto S) y se asigna en resultado final, fuera de este metodo
            //se busca para cada linea..
        private string recorrerLinea(List<string> linea) {
            //si la longitud es 1, prob ya vayas a salir... (analizar)
                //si pk es s, regresa s
                //si no
                    //si encuentra un reemplazo mas, invocar metodo otra vez 
                    //si no, va a continuar y no encontrara mas reemplazos n acciones, llega al final y regresa error
            //si la longitud es 0
                //regrrsa error
            //Obtener listado de gramaticas que aplican en base a la longitud de la linea
            //Buscar en el listado 
            
            //si encuentra una coincidencia...
                //reemplazar todos esos elementos por el unico elemento PK
                //guardar en resultado final
                //volver a recorrer la linea con el reemplazo del elemento

            //si llega a este punto que no encontro nada, error de gramatica (no es terminal)
                //regresa error


            //if(linea.Count == 1) {
            //    if(linea[0].Equals("S")) {
            //        return "S";
            //    } else {
                    
            //    }
            //} else if(linea.Count == 0) {
            //    return "Error";
            //}

            int rangoBusqueda = linea.Count, contLinea = 0;
            for(; rangoBusqueda > 0; rangoBusqueda--) {
                
                foreach(Gramatica gramatica in gramaticasSintaxis) {
                    if(!gramatica.entraEnElRangoPosible(rangoBusqueda - 1))
                        continue;

                    int contGram = 0; bool reemplazable = false;
                    for(int rangoInicial = linea.Count - rangoBusqueda, rangoFinal = rangoBusqueda - 1; rangoInicial < rangoFinal; rangoInicial++) {
                        if(gramatica.InstruccionGramatica[contGram] == procesarToken(linea[rangoInicial])) {
                            reemplazable = true;
                        }
                        else {
                            reemplazable = false;
                            break;
                        }

                        contGram++;
                    }

                    if(reemplazable) {
                        //si esterminal, ya salte

                        //reemplazar tokens por palabra
                        int rangoInicial = linea.Count - rangoBusqueda, rangoFinal = rangoBusqueda - 2;
                        linea[rangoInicial] = gramatica.PK;
                        for(int x = rangoInicial; x <= rangoFinal; x++) {
                            
                            linea.RemoveAt(rangoInicial);
                        }

                        if(linea.Count == 1) {
                            if(gramatica.EsTerminal)
                                return "S";
                            else
                                return "Error de sintaxis en la linea " + 1;
                        }

                        //guardar en result
                        foreach(string token in linea) {
                            resultadoFinal += token + " ";
                        }
                        resultadoFinal += "\n";


                        return recorrerLinea(linea);
                    }
                }
            }

            

            return "Error de sintaxis";
        }

        private List<Gramatica> buscarGramaticaPosible(int longitud) {
            return null;
        }

        /// <summary>
        /// Separa una cadena string en una matriz que contiene los elementos linea por linea, y token por token.
        /// Determina un cambio de linea con la secuencia '\n'.
        /// Determina un cambio de token con la secuencia ' '.
        /// Regresa una matriz de strings.
        /// </summary>
        /// <param name="archivoTokens">La cadena que se va a cargar</param>
        private List<List<string>> dividirStringPorLineas(string archivoTokens) {
            /* NOTAS
             - El ultimo elemento lista.last() SIEMPRE sera un ""
             - Tomar en cuenta ultimo elemento cuando se invoque el Count()
             - Iteracion que recorre los tokens:
                    foreach(List<string> linea in tokens) {
                        foreach(string token in linea) {
                            //
                        }
                    }
             */
            List<List<string>> tokensAux = new List<List<string>>();
            foreach(string token in archivoTokens.Split('\n').ToList()) 
                if(!string.IsNullOrWhiteSpace(token)) 
                    tokensAux.Add(token.Split(' ').ToList());
            return tokensAux;
        }

        /// <summary>
        /// Ignora la parte derecha despues del simbolo _
        /// P.Ej. IN1_1, IN1_2.. Las toma como IN1.
        /// </summary>
        /// <param name="token">El token a evaluar</param>
        /// <returns>El token generico</returns>
        private string procesarToken(string token) {
            return token.Contains("_") ? token.Substring(0, token.IndexOf("_")) : token;
        }

        private List<Gramatica> generarGramatica() {
            List<Gramatica> gramaticaAux = new List<Gramatica>();

            //Iniciales
            gramaticaAux.Add(new Gramatica("IN", new List<string> { "ALL" }, true));
            gramaticaAux.Add(new Gramatica("IN_1", new List<string> { "INICIO" }, true));
            gramaticaAux.Add(new Gramatica("IN_2", new List<string> { "FIN" }, true));
            gramaticaAux.Add(new Gramatica("IN_3", new List<string> { "ALLC" }, true));
            gramaticaAux.Add(new Gramatica("IN_4", new List<string> { "ALLS" }, true));
            
            //Identificadores
            gramaticaAux.Add(new Gramatica("INI", new List<string> { "PRI6", "PRV1", "IDEN", "CE13" }, true));
            gramaticaAux.Add(new Gramatica("INI_1", new List<string> { "IDEN", "ASIG", "VAL1", "CE13" }, true));
            gramaticaAux.Add(new Gramatica("INI_2", new List<string> { "PRI6", "PRV1", "INI_1" }, true));

            //Operadores aritmeticos
            gramaticaAux.Add(new Gramatica("INO", new List<string> { "VAL2", "OPAA", "VAL2" }, true));
            gramaticaAux.Add(new Gramatica("INO_1", new List<string> { "CE6", "INO", "CE7", "OPAA", "CE6", "INO", "CE7" }, true));
            gramaticaAux.Add(new Gramatica("INO_2", new List<string> { "VAL2" }, true));

            //Operadores logicos
            gramaticaAux.Add(new Gramatica("INC", new List<string> { "VAL1", "OPLA", "VAL1" }, true));
            gramaticaAux.Add(new Gramatica("INC_1", new List<string> { "OPL1", "VAL4" }, true));
            gramaticaAux.Add(new Gramatica("INC_2", new List<string> { "VAL1" }, true));
            gramaticaAux.Add(new Gramatica("INC_3", new List<string> { "CE6", "INC", "CE7", "OPLA", "CE6", "INC", "CE7" }, true));

            //Operadores relacionales
            gramaticaAux.Add(new Gramatica("INR", new List<string> { "INO", "OPRA", "INO" }, true));
            gramaticaAux.Add(new Gramatica("INR_1", new List<string> { "CE6", "INR", "CE7", "OPRA", "CE6", "INR", "CE7" }, true));

            //Condiciones
            gramaticaAux.Add(new Gramatica("INCOND", new List<string> { "CONDIC" }, false));
            gramaticaAux.Add(new Gramatica("INCOND_1", new List<string> { "CE6", "CONDIC", "CE7", "OPLA", "CE6", "CONDIC", "CE7" }, false));

            //Entrada y salida
            gramaticaAux.Add(new Gramatica("INS", new List<string> { "PRI4", "IDEN" }, true));
            gramaticaAux.Add(new Gramatica("INS_1", new List<string> { "PRI5", "VAL5" }, true));

            //Instrucciones complejas//
            //caso
            gramaticaAux.Add(new Gramatica("INP1", new List<string> { "PRI7", "IDEN" }, true));
            gramaticaAux.Add(new Gramatica("INP1_1", new List<string> { "PRI7", "IDEN", "CE8" }, true));
            gramaticaAux.Add(new Gramatica("INP1_2", new List<string> { "PRI8", "VAL3", "CE13" }, true));
            gramaticaAux.Add(new Gramatica("INP1_1", new List<string> { "PRI9", "CE13" }, true));
            gramaticaAux.Add(new Gramatica("INP1", new List<string> { "PRI12", "VAL3", "OPR2", "CE13" }, true));
            gramaticaAux.Add(new Gramatica("INP1_1", new List<string> { "PRI7", "IDEN", "CE8", "PRI8", "VAL3", "OPR2", "ALLS", "PRI9", "CE13", "PRI12", "VAL3", "OPR2", "ALLS", "PRI9", "CE13", "FINL" }, true));

            //CICLO FOR
            gramaticaAux.Add(new Gramatica("INP2", new List<string> { "PRI1", "CE6","CICLO", "CE13", "INCOND", "CE13", "INI_1", "CE7" }, true));
            gramaticaAux.Add(new Gramatica("INP2_1", new List<string> { "PRI1", "CE6", "CICLO", "CE13", "INCOND", "CE13", "INI_1", "CE7", "CE8" }, true));
            gramaticaAux.Add(new Gramatica("INP2_2", new List<string> { "PRI1", "CE6", "CICLO", "CE13", "INCOND", "CE13", "INI_1", "CE7", "CE8", "ALLC", "FINL" }, true));

            //CICLO WHILE
            gramaticaAux.Add(new Gramatica("INP3", new List<string> { "PRI17", "INCOND" }, true));
            gramaticaAux.Add(new Gramatica("INP1_1", new List<string> { "PRI17", "INCOND", "CE8" }, true));
            gramaticaAux.Add(new Gramatica("INP1", new List<string> { "PRI17", "INCOND", "CE8", "ALLC", "FINL" }, true));

            //CICLO DO WHILE
            gramaticaAux.Add(new Gramatica("INP4", new List<string> { "PRI18" }, true));
            gramaticaAux.Add(new Gramatica("INP4_1", new List<string> { "PRI17", "CE8" }, true));
            gramaticaAux.Add(new Gramatica("INP4_2", new List<string> { "CE9", "PRI17", "INCOND", "CE13" }, true));
            gramaticaAux.Add(new Gramatica("INP4_3", new List<string> { "PRI18", "CE8", "ALLC", "CE9", "PRI17", "INCOND", "CE13" }, true));

            //IF
            gramaticaAux.Add(new Gramatica("INP5", new List<string> { "PRI2", "INCOND" }, true));
            gramaticaAux.Add(new Gramatica("INP1_1", new List<string> { "PRI2", "INCOND", "CE8" }, true));
            gramaticaAux.Add(new Gramatica("INP1", new List<string> { "PRI12", "INCOND", "CE8", "ALL", "FINL" }, true));

            //ELSE
            gramaticaAux.Add(new Gramatica("INP6", new List<string> { "PRI3" }, true));
            gramaticaAux.Add(new Gramatica("INP6_1", new List<string> { "CE9", "PRI3" }, true));
            gramaticaAux.Add(new Gramatica("INP6_2", new List<string> { "PRI3", "CE8" }, true));
            gramaticaAux.Add(new Gramatica("INP6_3", new List<string> { "CE9", "PRI3", "CE8"}, true));
            gramaticaAux.Add(new Gramatica("INP6_4", new List<string> { "PRI3", "CE8", "ALL", "FINL" }, true));
            gramaticaAux.Add(new Gramatica("INP6_5", new List<string> { "CE9", "PRI3", "CE8", "ALL", "FINL" }, true));
            
            //ELSE IF
            gramaticaAux.Add(new Gramatica("INP7", new List<string> { "PRI3", "PRI2", "INCOND" }, true));
            gramaticaAux.Add(new Gramatica("INP7_1", new List<string> { "PRI3", "PRI2", "INCOND", "CE8" }, true));
            gramaticaAux.Add(new Gramatica("INP7_2", new List<string> { "PRI3", "PRI2", "INCOND", "CE8", "ALL", "FINL" }, true));
            gramaticaAux.Add(new Gramatica("INP7_3", new List<string> { "CE9", "PRI3", "PRI2", "INCOND" }, true));
            gramaticaAux.Add(new Gramatica("INP7_4", new List<string> { "CE9", "PRI3", "PRI2", "INCOND", "CE8" }, true));
            gramaticaAux.Add(new Gramatica("INP7_5", new List<string> { "CE9", "PRI3", "PRI2", "INCOND", "CE8", "ALL", "FINL" }, true));

            //COMENTARIOS
            gramaticaAux.Add(new Gramatica("INCO", new List<string> { "COMENTARIO" }, true));

            //AUXILIARES
            gramaticaAux.Add(new Gramatica("INPA1", new List<string> { "PRI9", "CE13" }, true)); //ROMPER
            gramaticaAux.Add(new Gramatica("INPA2", new List<string> { "PRI10", "CE13" }, true)); //CONTINUAR
            gramaticaAux.Add(new Gramatica("FINL", new List<string> { "CE9", "CE13" }, true));
            gramaticaAux.Add(new Gramatica("CE8", new List<string> { "CE8" }, true)); //


            return gramaticaAux;
        }
    }
}