using Interfaz.Clases.Compilacion;
using System.Collections.Generic;
using System.Linq;

namespace Interfaz.Clases.Facade {
    class SintaxisFacade {
        #region Componentes primordiales
        private List<List<string>> tokens; //Contiene el listado global de tokens ordenados segun se mando.
        private string resultadoFinal;
        private List<Gramatica> gramaticasSintaxis;
        private List<Gramatica> gramaticasAuxiliaresVariable;
        private int k;
        #endregion

        private void init(string archivoTokens) {
            tokens = dividirStringPorLineas(archivoTokens);
            resultadoFinal = "";
            gramaticasSintaxis = generarGramatica();
            gramaticasAuxiliaresVariable = generarGramaticaAuxiliarVariable();
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
                guardarResultadoFinal(linea);
                string pk = recorrerLinea(linea, null, -1);
                resultadoFinal += "\n->" + pk;
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
        private string recorrerLinea(List<string> linea, List<Gramatica> gramaticasEspecificas, int posicionInicialEspecifica) {
            if(linea.Count > 0 && linea[0].Equals("S")) return "S";

            bool buscoGramaticaEspecifica = gramaticasEspecificas != null;
            int rangoBusqueda;
            List<Gramatica> gramaticasAceptables;
            if(buscoGramaticaEspecifica) { //Si viene una gramatica como parametro, se busca para esa gramatica/posicion en especifico
                rangoBusqueda = 1; //En este caso solo se repite una vez todo el proceso
                gramaticasAceptables = gramaticasEspecificas;
            } else {  //Si no, se busca para todas las gramaticas/posiciones
                rangoBusqueda = linea.Count;
                gramaticasAceptables = gramaticasSintaxis;
            }

            for(; rangoBusqueda > 0; rangoBusqueda--) {



                foreach(Gramatica gramatica in gramaticasAceptables) {
                    //Si la longitud de la gramatica no coincide con la actual de busqueda, saltatela. Siempre y cuando no estes en una gramatica en especifico
                    if(!buscoGramaticaEspecifica && !gramatica.entraEnElRangoPosible(rangoBusqueda - 1))
                        continue;
                    //Si la linea, es menor a la longitud de la gramatica, salte porque sabes que no cumpliras con esa gramatica. Siempre y cuando es una gramatica en especifico
                    else if(buscoGramaticaEspecifica && linea.Count - 1 - posicionInicialEspecifica < gramatica.Longitud)
                        continue;

                        //El rango inicial equivale a la posicion del apuntador a partir de la cual se validaran los tokens iguales en el listado
                        //Esta posicion debe ir incrementando, buscando segun el rango
                        //Si busco gramatica, es hasta el tamanio de la gramatica
                        //Si no, es hasta el tamanio de la linea
                    int repeticiones = buscoGramaticaEspecifica ? gramatica.Longitud : (linea.Count - rangoBusqueda + 1);
                    for(int rep = 0; rep < repeticiones; rep++) {
                        int contGram = 0; //Indica la posicion de la gramatica en la que se va a buscar
                        bool reemplazable = false; //Bandera que determina si todos los tokens fueron identicos

                        //Este ciclo recorre la linea para ir validando elemento tras elemento si son iguales
                        //Se debe tomar en cuenta que no siempre se buscaran para toda la longitud de la linea, si no que la busqueda puede hacerse con una longitud menor

                        int rangoInicialEnLinea, iteracionesEnLinea;
                        if(buscoGramaticaEspecifica) {
                            rangoInicialEnLinea = posicionInicialEspecifica;
                            iteracionesEnLinea = gramatica.Longitud + rangoInicialEnLinea;
                        } else {
                            rangoInicialEnLinea = 0 + rep;
                            iteracionesEnLinea = rangoBusqueda - 1;
                        }

                        for(; rangoInicialEnLinea < iteracionesEnLinea; rangoInicialEnLinea++) {
                            //Tanto la gramatica como el token deben de ser previamente procesados para su validacion. Se aplican los siguientes casos.

                            //CASO 1: Si el token es identico a la gramatica, adelante, siguiente iteracion
                            if(gramatica.InstruccionGramatica[contGram] == procesarToken(linea[rangoInicialEnLinea])) {
                                reemplazable = true;
                                contGram++;
                                continue;
                            } //CASO 2: Si la gramatica contiene _, entonces busca la gramatica en especifico para el resto de la linea
                            else if(gramatica.InstruccionGramatica[contGram].Contains("_")) {

                                string reemplazo = recorrerLinea(linea, buscarGramatica(gramatica.InstruccionGramatica[contGram], true), rangoInicialEnLinea);

                                if(reemplazo != null) { //Si regresa un token, asignalo y busca con nueva
                                    if(!reemplazo.Equals("S")) { //Si no has terminado, continua..
                                        // ... Reemplazar los tokens de la linea por la PK de la gramatica
                                        int rangoInicialAux = rangoInicialEnLinea, rangoFinal = gramatica.Longitud + rangoInicialEnLinea;
                                        linea[rangoInicialAux++] = reemplazo;
                                        for(int x = rangoInicialAux; x <= rangoFinal; x++) {
                                            linea.RemoveAt(rangoInicialAux);
                                        }// ...

                                        guardarResultadoFinal(linea);
                                        return recorrerLinea(linea, null, -1);
                                    } else { //Si ya es S, salte..
                                        return reemplazo;
                                    }
                                }

                                reemplazable = false; //Si regresa nulo, salte, por aqui no es
                                break;
                            }

                            //CASO 3: Si la gramatica contiene -, entonces busca el token en los auxiliaresVariableGramatica
                            //if(!reemplazable) {
                             else if(gramatica.InstruccionGramatica[contGram].Contains("-")) {
                                List<string> reemplazo = buscarUnicaVariableGramaticaAuxiliar(gramatica.InstruccionGramatica[contGram], linea, rangoInicialEnLinea);
                                if(reemplazo != null) {
                                    if(reemplazo.Count == 1) { //Reemplazar el token actual de la linea por la PK de la gramatica auxiliar variable
                                        if(reemplazo[0].Equals("S")) return "S";
                                        linea[rangoInicialEnLinea] = reemplazo[0];
                                    } else {
                                        linea = reemplazo;// creo que no es necesario!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                                    }
                                        
                                    guardarResultadoFinal(linea);
                                    return recorrerLinea(linea, null, -1);
                                } else { //CASO 4: Salte, no es lo que estamos buscando
                                    reemplazable = false;
                                    break;
                                }
                            } else { //CASO 4: Salte, no es lo que estamos buscando
                                reemplazable = false;
                                break;
                            }
                            // }

                            //  reemplazable = false;
                            //   break; 
                            //contGram++; //Valida el siguiente token de la gramatica actual
                        }

                        if(reemplazable && contGram == gramatica.Longitud) {
                            if(buscoGramaticaEspecifica)
                                return gramatica.PK; //Si busco una gramatica y si fue reemplazable, regresa el pk para que se asigne

                            // ... Reemplazar los tokens de la linea por la PK de la gramatica
                            int rangoInicialAux = linea.Count - rangoBusqueda, rangoFinal = rangoBusqueda - 2;
                            linea[rangoInicialAux++] = gramatica.PK;
                            for(int x = rangoInicialAux; x <= rangoFinal; x++) {
                                linea.RemoveAt(rangoInicialAux);
                            }// ...


                            if(linea.Count == 2) { //1, pero al final siempre se incluye el elemento vacio ""
                                if(gramatica.EsTerminal)
                                    return "S";
                                else
                                    return "Error de sintaxis en la linea " + 1;
                            }

                            guardarResultadoFinal(linea);
                            return recorrerLinea(linea, null, -1);
                        } else if(buscoGramaticaEspecifica) {
                            return null; //Si busco gramatica y no es reemplazable, regresa nulo
                        }
                    }
                }
            }

            return "Error de sintaxis";
        }

        /// <summary>
        /// Inserta el "texto" de la operacion realizada en el resultado final.
        /// </summary>
        /// <param name="linea">La linea que se va a agregar</param>
        private void guardarResultadoFinal(List<string> linea) {
            foreach(string token in linea)
                resultadoFinal += token + " ";

            resultadoFinal += "\n";
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






        private List<string> buscarUnicaVariableGramaticaAuxiliar(string gramaticaPK, List<string> linea, int posicionActual) {
            string token = linea[posicionActual];

            foreach(Gramatica gramatica in gramaticasAuxiliaresVariable) { //Recorre todas las gramaticas auxiliares de tipo variable
                if(gramatica.PK.Equals(gramaticaPK)) {
                    if(gramatica.InstruccionGramatica[0].Equals(token)) { //La encontraste, regresala
                        return new List<string> { gramaticaPK };
                    } else if(gramatica.InstruccionGramatica[0].Contains("%")) { //Significa que es una instruccion, se debe buscar para esa instruccion

                        if(gramatica.InstruccionGramatica[0].Equals(procesarGramatica(token) + "%")) { //La encontraste, regresala
                            return new List<string> { gramaticaPK };
                        }

                        string reemplazo = recorrerLinea(linea, buscarGramatica(procesarGramaticaVariable(gramatica.InstruccionGramatica[0]), false), posicionActual);

                        if(reemplazo != null) { //Si regresa un token, asignalo y regresa la nueva linea
                            if(!reemplazo.Equals("S")) {
                                // ... Reemplazar los tokens de la linea por la PK de la gramatica
                                linea[posicionActual] = reemplazo;
                                if(gramatica.Longitud != 1) { //Si la gramatica tiene mas de un elemento, elimina esos n elementos                  
                                    int rangoInicialAux = posicionActual, rangoFinal = gramatica.Longitud + posicionActual;
                                    for(int x = rangoInicialAux; x < rangoFinal; x++) {
                                        linea.RemoveAt(rangoInicialAux);
                                    }// ...
                                }
                                //guardarResultadoFinal(linea);

                                return linea;
                            } else {
                                return new List<string> { "S" };
                            }
                        } else { //No se logro nada, buscar otra solucion
                            continue;
                        }
                    } else if(gramatica.InstruccionGramatica[0].Contains("-")) { //Significa que es otra variable, busca para esa variable
                        List<string> encontre = buscarUnicaVariableGramaticaAuxiliar(gramatica.InstruccionGramatica[0], linea, posicionActual);

                        //no regresas.. reemplazas y regresas toda la linea..?
                        if(encontre != null) {
                            linea[posicionActual] = encontre[0]; //Reemplazas el valor
                            //guardarResultadoFinal(linea); 

                            return linea;
                            //return encontre;
                        } else { //No se logro nada, buscar otra solucion
                            continue;
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Determina las gramaticas que coinciden con una gramaticaPK dada
        /// </summary>
        /// <param name="gramaticaPK">La que se busca</param>
        /// <returns>Listado de coincidencias</returns>
        private List<Gramatica> buscarGramatica(string gramaticaPK, bool identica) {
            List<Gramatica> gramaticas = new List<Gramatica>();
            foreach(Gramatica current in gramaticasSintaxis) {
                string cpk = identica ? current.PK : procesarGramatica(current.PK);
                if(cpk.Equals(gramaticaPK))
                    gramaticas.Add(current);
            }

            return gramaticas;
        }


        /// <summary>
        /// Ignora la parte derecha despues del simbolo #
        /// P.Ej. IDEN#1, IDEN#2 ... Los toma como IDEN.
        /// </summary>
        /// <param name="token">El token a evaluar</param>
        /// <returns>El token generico</returns>
        private string procesarToken(string token) {
            return token.Contains("#") ? token.Substring(0, token.IndexOf("#")) : token;
        }

        /// <summary>
        /// Devuelve el PK de la gramatica sin el %.
        /// Generado EXCLUSIVAMENTE para el metodo buscarUnicaVariableGramaticaAuxiliar.
        /// </summary>
        /// <param name="gramaticaPK">PK sin modificar</param>
        /// <returns>PK modificada</returns>
        private string procesarGramaticaVariable(string gramaticaPK) {
            return gramaticaPK.Substring(0, gramaticaPK.IndexOf("%"));
        }


        /// <summary>
        /// Devuelve el PK de la gramatica sin el _.
        /// Generado EXCLUSIVAMENTE para el metodo buscarGramatica.
        /// </summary>
        /// <param name="gramaticaPK">PK sin modificar</param>
        /// <returns>PK modificada</returns>
        private string procesarGramatica(string gramaticaPK) {
            return gramaticaPK.Contains("_") ? gramaticaPK.Substring(0, gramaticaPK.IndexOf("_")) : gramaticaPK;
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
            gramaticaAux.Add(new Gramatica("INI_1", new List<string> { "IDEN", "ASIG", "VAL-1", "CE13" }, true));
            gramaticaAux.Add(new Gramatica("INI_2", new List<string> { "PRI6", "PRV1", "INI_1" }, true));

            //Operadores aritmeticos    
            gramaticaAux.Add(new Gramatica("INO", new List<string> { "VAL-2", "OPAA", "VAL-2" }, true));
            gramaticaAux.Add(new Gramatica("INO_1", new List<string> { "CE6", "INO", "CE7", "OPAA", "CE6", "INO", "CE7" }, true));
            gramaticaAux.Add(new Gramatica("INO_2", new List<string> { "VAL-2" }, true));

            //Operadores logicos
            gramaticaAux.Add(new Gramatica("INC", new List<string> { "VAL-1", "OPLA", "VAL-1" }, true));
            gramaticaAux.Add(new Gramatica("INC_1", new List<string> { "OPL1", "VAL-4" }, true));
            gramaticaAux.Add(new Gramatica("INC_2", new List<string> { "VAL-1" }, true));
            gramaticaAux.Add(new Gramatica("INC_3", new List<string> { "CE6", "INC", "CE7", "OPLA", "CE6", "INC", "CE7" }, true));

            //Operadores relacionales
            gramaticaAux.Add(new Gramatica("INR", new List<string> { "INO", "OPRA", "INO" }, true));
            gramaticaAux.Add(new Gramatica("INR_1", new List<string> { "CE6", "INR", "CE7", "OPRA", "CE6", "INR", "CE7" }, true));

            //Condiciones
            gramaticaAux.Add(new Gramatica("INCOND", new List<string> { "CONDIC" }, false));
            gramaticaAux.Add(new Gramatica("INCOND_1", new List<string> { "CE6", "CONDIC", "CE7", "OPLA", "CE6", "CONDIC", "CE7" }, false));

            //Entrada y salida
            gramaticaAux.Add(new Gramatica("INS", new List<string> { "PRI4", "IDEN" }, true));
            gramaticaAux.Add(new Gramatica("INS_1", new List<string> { "PRI5", "VAL-5" }, true));

            //Instrucciones complejas//
            //caso
            gramaticaAux.Add(new Gramatica("INP1", new List<string> { "PRI7", "IDEN" }, true));
            gramaticaAux.Add(new Gramatica("INP1_1", new List<string> { "PRI7", "IDEN", "CE8" }, true));
            gramaticaAux.Add(new Gramatica("INP1_2", new List<string> { "PRI8", "VAL-3", "CE13" }, true));
            gramaticaAux.Add(new Gramatica("INP1_1", new List<string> { "PRI9", "CE13" }, true));
            gramaticaAux.Add(new Gramatica("INP1", new List<string> { "PRI12", "VAL-3", "OPR2", "CE13" }, true));
            gramaticaAux.Add(new Gramatica("INP1_1", new List<string> { "PRI7", "IDEN", "CE8", "PRI8", "VAL-3", "OPR2", "ALLS", "PRI9", "CE13", "PRI12", "VAL-3", "OPR2", "ALLS", "PRI9", "CE13", "FINL" }, true));

            //CICLO FOR
            gramaticaAux.Add(new Gramatica("INP2", new List<string> { "PRI1", "CE6", "CICLO", "CE13", "INCOND", "CE13", "INI_1", "CE7" }, true));
            gramaticaAux.Add(new Gramatica("INP2_1", new List<string> { "PRI1", "CE6", "CICLO", "CE13", "INCOND", "CE13", "INI_1", "CE7", "CE8" }, true));
            gramaticaAux.Add(new Gramatica("INP2_2", new List<string> { "PRI1", "CE6", "CICLO", "CE13", "INCOND", "CE13", "INI_1", "CE7", "CE8", "ALLC", "FINL" }, true));

            //CICLO WHILE
            gramaticaAux.Add(new Gramatica("INP3", new List<string> { "PRI17", "INCOND" }, true));
            gramaticaAux.Add(new Gramatica("INP3_1", new List<string> { "PRI17", "INCOND", "CE8" }, true));
            gramaticaAux.Add(new Gramatica("INP3_2", new List<string> { "PRI17", "INCOND", "CE8", "ALLC", "FINL" }, true));

            //CICLO DO WHILE
            gramaticaAux.Add(new Gramatica("INP4", new List<string> { "PRI18" }, true));
            gramaticaAux.Add(new Gramatica("INP4_1", new List<string> { "PRI17", "CE8" }, true));
            gramaticaAux.Add(new Gramatica("INP4_2", new List<string> { "CE9", "PRI17", "INCOND", "CE13" }, true));
            gramaticaAux.Add(new Gramatica("INP4_3", new List<string> { "PRI18", "CE8", "ALLC", "CE9", "PRI17", "INCOND", "CE13" }, true));

            //IF
            gramaticaAux.Add(new Gramatica("INP5", new List<string> { "PRI2", "INCOND" }, true));
            gramaticaAux.Add(new Gramatica("INP5_1", new List<string> { "PRI2", "INCOND", "CE8" }, true));
            gramaticaAux.Add(new Gramatica("INP5_2", new List<string> { "PRI12", "INCOND", "CE8", "ALL", "FINL" }, true));

            //ELSE
            gramaticaAux.Add(new Gramatica("INP6", new List<string> { "PRI3" }, true));
            gramaticaAux.Add(new Gramatica("INP6_1", new List<string> { "CE9", "PRI3" }, true));
            gramaticaAux.Add(new Gramatica("INP6_2", new List<string> { "PRI3", "CE8" }, true));
            gramaticaAux.Add(new Gramatica("INP6_3", new List<string> { "CE9", "PRI3", "CE8" }, true));
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
            gramaticaAux.Add(new Gramatica("INPA1", new List<string> { "PRI9", "CE13" }, true));
            gramaticaAux.Add(new Gramatica("INPA2", new List<string> { "PRI10", "CE13" }, true));
            gramaticaAux.Add(new Gramatica("FINL", new List<string> { "CE9", "CE13" }, true));
            gramaticaAux.Add(new Gramatica("CE8", new List<string> { "CE8" }, true));


            return gramaticaAux;
        }

        private List<Gramatica> generarGramaticaAuxiliarVariable() {
            List<Gramatica> gramaticaAux = new List<Gramatica>();

            //NADA de aqui es terminal
            //dejar siempre los IN al final
            // a todos los ino ponerle un %
            //a todos los auxiliares ponerles un VAL-
            gramaticaAux.Add(new Gramatica("VAL-1", new List<string> { "CADENA" }, false));
            gramaticaAux.Add(new Gramatica("VAL-1", new List<string> { "INCOND" }, false));
            gramaticaAux.Add(new Gramatica("VAL-1", new List<string> { "INO%" }, false));

            gramaticaAux.Add(new Gramatica("VAL-2", new List<string> { "IDEN" }, false));
            gramaticaAux.Add(new Gramatica("VAL-2", new List<string> { "VAL-CONST" }, false));

            gramaticaAux.Add(new Gramatica("VAL-CONST", new List<string> { "CONSTENT" }, false));
            gramaticaAux.Add(new Gramatica("VAL-CONST", new List<string> { "CONSTRE" }, false));
            gramaticaAux.Add(new Gramatica("VAL-CONST", new List<string> { "CONSTEX" }, false));

            return gramaticaAux;
        }
    }
}