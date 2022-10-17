using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Interfaz.Clases.Facade {
    class SintaxisFacade {
        public RichTextBox sintaxisGo(RichTextBox txtSintaxis, RichTextBox txtLexico) {
            string[] lines = RemoverHashtags(txtLexico);
            for(int i = 0; i < lines.Length; i++) {
                lines[i] = lines[i].TrimEnd();
            }

            File.WriteAllLines(@"..\..\Externos\lexicoTokens.tmpalscript", lines);
            string go = @System.Configuration.ConfigurationManager.AppSettings["sintax"];
            if(File.Exists(go + "sintaxisResult.tmpalscript")) {
                File.Delete(go + "sintaxisResult.tmpalscript");
            }

            var sintaxis = new Process {
                StartInfo = {
                    FileName = "node",
                    WorkingDirectory = go,
                    Arguments = "AnalizadorSintactico.js",
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                }
            };
            sintaxis.Start();
            string[] resultadoAnalisisSintaxis = null;
            do {
                try {
                    resultadoAnalisisSintaxis = File.ReadAllLines(@"..\..\Externos\sintaxisResult.tmpalscript");
                    txtSintaxis.Lines = resultadoAnalisisSintaxis;
                } catch(Exception) { Console.WriteLine("[DEBUG] Buscando archivo..."); }
            } while(resultadoAnalisisSintaxis == null);

            return txtSintaxis;
        }

        private string[] RemoverHashtags(RichTextBox txtLexico) {
            var nuevasLineas = new List<string>();
            foreach(string linea in txtLexico.Lines) {
                var temp = Regex.Replace(linea, @"\bIDEN#[0-9]+", "IDEN");
                nuevasLineas.Add(temp);
            }

            return nuevasLineas.ToArray();
        }
    }
}