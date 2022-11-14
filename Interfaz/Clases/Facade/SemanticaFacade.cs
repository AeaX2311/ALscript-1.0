﻿using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Interfaz.Clases.Facade {
    class SemanticaFacade {

        /// <summary>
        /// Determina si faltan llaves, corchetes y parentesis por cerrar.
        /// 
        /// </summary>
        /// <param name="txtLexico">Archivo de tokens</param>
        /// <returns>TRUE - Tiene errores. FALSE - No tiene errores</returns>
        public bool determinarErrorLlaves(RichTextBox txtLexico) {
            int cCorchete = 0, cLlave = 0, cParentesis = 0;
            foreach(string linea in txtLexico.Lines) {
                foreach(string palabra in linea.Split(' ')) {
                    switch(palabra) {
                        case "CE10":
                            cCorchete++;
                            break;
                        case "CE11":
                            cCorchete--;
                            break;
                        case "CE6":
                            cParentesis++;
                            break;
                        case "CE7":
                            cParentesis--;
                            break;
                        case "CE8":
                            cLlave++;
                            break;
                        case "CE9":
                            cLlave--;
                            break;
                        default: break;
                    }
                }
            }

            return cCorchete != 0 || cLlave != 0 || cParentesis != 0;
        }

        public string determinarErrorDeclaracionesRepetidas(RichTextBox txtLexico) {
            List<string> variablesDeclaradas = new List<string>();

            foreach(string linea in txtLexico.Lines) {
                if(linea.Contains("PRI6 PRV1 IDEN")) {
                    string identificadorActual = linea.Substring(15).Split(' ')[0];

                    Console.WriteLine(identificadorActual);
                    if(variablesDeclaradas.Contains(identificadorActual)) { //Error de variable doblemente declarada
                        return identificadorActual;
                    } else { //Guardar temporalmente las variables que ya han sido validadas
                        variablesDeclaradas.Add(identificadorActual);
                    }
                }
            }

            return null;
        }


        public RichTextBox determinarErrorTipoDatos(RichTextBox txtLexico, RichTextBox txtSemantica, Dictionary<string, Identificador> identificadores) {
            List<string> tiposDatos = new List<string>() { "CADENA", "ENTERO", "CONSTENT", "CONSTRE", "CONSTEX", "PRB1", "PRB2" };
            List<string> lineas = new List<string>();

            foreach(string linea in txtLexico.Lines) {
                string lineaActual = "";
                foreach(string palabra in linea.Split(' ')) {
                    if(palabra.Equals("ASIG")) {
                        lineaActual = ""; //Es una asignacion, no me tomes en cuenta el IDEN que ya fue agregado
                    } else if(palabra.Contains("IDEN")) {
                        //Buscar el tipo de dato del identificador y mandarlo                        
                        string tipoDato = identificadores[palabra].TipoDato;
                        
                        if(tipoDato != null) {
                            lineaActual += tipoDato + " ";
                        } else { //Error de variable no asignada
                            txtSemantica.Text = $"ERR --> Variable [{identificadores[palabra].Nombre}] no ha sido asignada aun.\n";
                            return txtSemantica;
                        }
                        if(!identificadores[palabra].Asignada) { //Error de variable no declarada                   
                            txtSemantica.Text = $"ERR --> Variable [{identificadores[palabra].Nombre}] no ha sido declarada aun.\n";
                            return txtSemantica;                           
                        }                        
                    } else if(tiposDatos.Contains(palabra) || palabra.Contains("OPA") || palabra.Contains("OPL") || palabra.Contains("OPR"))
                        lineaActual += palabra +" "; //Agrega la palabra
                }

                if(!lineaActual.Equals("")) lineas.Add(lineaActual);
            }
            
            File.WriteAllLines(@"..\..\Externos\sintaxisTokens.tmpalscript", lineas);
            string go = @System.Configuration.ConfigurationManager.AppSettings["sintax"];
            if(File.Exists(go + "semanticaResult.tmpalscript")) {
                File.Delete(go + "semanticaResult.tmpalscript");
            }

            var semantica = new Process {
                StartInfo = {
                    FileName = "node",
                    WorkingDirectory = go,
                    Arguments = "AnalizadorSemantico.js",
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                }
            };
            semantica.Start();
            string[] resultadoAnalisisSemantica = null;
            do {
                try {
                    resultadoAnalisisSemantica = File.ReadAllLines(@"..\..\Externos\semanticaResult.tmpalscript");
                    txtSemantica.Lines = resultadoAnalisisSemantica;
                } catch(Exception) { Console.WriteLine("[DEBUG] Buscando archivo..."); }
            } while(resultadoAnalisisSemantica == null);

            return txtSemantica;
        }

        /// <summary>
        /// Genera un listado de las instrucciones obtenidas del analizador sintactico.
        /// </summary>
        /// <param name="txtSintaxis">Analisis sintactico</param>
        /// <returns>Instrucciones separadas por espacio en string</returns>
        private string[] obtenerInstrucciones(RichTextBox txtSintaxis) {
            var instrucciones = "PRINI ";
            foreach(string linea in txtSintaxis.Lines) {
                if(linea.Split(' ').Length == 3) {
                    foreach(string palabra in linea.Split(' ')) {
                        if(palabra.Contains("IN_"))
                            instrucciones += palabra + " ";
                    }

                }
            } instrucciones += "PRFIN";

            string[] x = { instrucciones };
            return x;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="txtSemantica"></param>
        /// <param name="txtLexico"></param>
        /// <returns></returns>
        public RichTextBox semanticaGo(RichTextBox txtSemantica, RichTextBox txtSintaxis) {
            string[] lines = obtenerInstrucciones(txtSintaxis);
            for(int i = 0; i < lines.Length; i++) lines[i] = lines[i].TrimEnd();

            File.WriteAllLines(@"..\..\Externos\sintaxisTokens.tmpalscript", lines);
            string go = @System.Configuration.ConfigurationManager.AppSettings["sintax"];
            if(File.Exists(go + "semanticaResult.tmpalscript")) File.Delete(go + "semanticaResult.tmpalscript");

            var semantica = new Process {
                StartInfo = {
                    FileName = "node",
                    WorkingDirectory = go,
                    Arguments = "AnalizadorSemantico.js",
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                }
            }; semantica.Start();

            
            string[] resultadoAnalisisSemantica = null;
            do {
                try {
                    resultadoAnalisisSemantica = File.ReadAllLines(@"..\..\Externos\semanticaResult.tmpalscript");
                    var d = new string[resultadoAnalisisSemantica.Length + txtSemantica.Lines.Length];
                    txtSemantica.Lines.CopyTo(d, 0);
                    resultadoAnalisisSemantica.CopyTo(d, txtSemantica.Lines.Length);
                    txtSemantica.Lines = d;
                } catch(Exception) { Console.WriteLine("[DEBUG] Buscando archivo..."); }
            } while(resultadoAnalisisSemantica == null);

            return txtSemantica;
        }
    }
}
