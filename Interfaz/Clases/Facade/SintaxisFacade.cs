﻿using Interfaz.Clases.Compilacion;
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
            gramaticaAux.Add(new Gramatica("INI", new List<string> { "PRI6", "PRV1", "IDEN", "CE13" }, true));
            gramaticaAux.Add(new Gramatica("INI", new List<string> { "PRI6", "PRV1", "IDEN", "CE13" }, true));
            gramaticaAux.Add(new Gramatica("INI", new List<string> { "PRI6", "PRV1", "IDEN", "CE13" }, true));

            //Operadores logicos
            gramaticaAux.Add(new Gramatica("INI", new List<string> { "PRI6", "PRV1", "IDEN", "CE13" }, true));
            gramaticaAux.Add(new Gramatica("INI", new List<string> { "PRI6", "PRV1", "IDEN", "CE13" }, true));
            gramaticaAux.Add(new Gramatica("INI", new List<string> { "PRI6", "PRV1", "IDEN", "CE13" }, true));
            gramaticaAux.Add(new Gramatica("INI", new List<string> { "PRI6", "PRV1", "IDEN", "CE13" }, true));

            //Operadores relacionales
            gramaticaAux.Add(new Gramatica("INI", new List<string> { "PRI6", "PRV1", "IDEN", "CE13" }, true));
            gramaticaAux.Add(new Gramatica("INI", new List<string> { "PRI6", "PRV1", "IDEN", "CE13" }, true));

            //Condiciones
            gramaticaAux.Add(new Gramatica("INI", new List<string> { "PRI6", "PRV1", "IDEN", "CE13" }, true));
            gramaticaAux.Add(new Gramatica("INI", new List<string> { "PRI6", "PRV1", "IDEN", "CE13" }, true));

            //Entrada y salida
            gramaticaAux.Add(new Gramatica("INI", new List<string> { "PRI6", "PRV1", "IDEN", "CE13" }, true));
            gramaticaAux.Add(new Gramatica("INI", new List<string> { "PRI6", "PRV1", "IDEN", "CE13" }, true));


            gramaticaAux.Add(new Gramatica("INI", new List<string> { "PRI6", "PRV1", "IDEN", "CE13" }, true));

            gramaticaAux.Add(new Gramatica("INI", new List<string>{ "PRI6", "PRV1", "IDEN", "CE13" }, true));
            gramaticaAux.Add(new Gramatica("INI_1", new List<string> { "IDEN", "ASIG", "VAL1", "CE13" }, true));
            gramaticaAux.Add(new Gramatica("INI_2", new List<string> { "PRI6", "PRV1", "INI_1", "CE13" }, true));

            return gramaticaAux;
        }
    }
}
