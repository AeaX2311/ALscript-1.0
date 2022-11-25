using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz.Clases.Facade {
    class EnsambladorFacade {

        public void ensambladorGo(List<string> instruccionesTripletasEnsamblador) {
            var codigoConvertidoEnC = convertirVariablesACodigoC(instruccionesTripletasEnsamblador);

            //Cuando tengo el codigo convertido en C, lo que voy a
            //hacer es, guardar un archivo con extension .C,
            //y hacer que se ejecute directamente en el ordenador

            //Paso 1. Generar un archivo con extension .C en la carpeta donde nos encontramos actualmente
            var rutaActual = Directory.GetCurrentDirectory();
            var rutaArchivoC = rutaActual + "\\codigoC.c";
            File.WriteAllText(rutaArchivoC, codigoConvertidoEnC);

            //Paso 2. Generar un archivo con el codigo ensamblador utilizando la sintaxis MASM
            var rutaArchivoEnsamblador = rutaActual + "\\codigoEnsamblador.asm";
            var comando = "gcc -S codigoC.c -o output.asm -masm=intel";

            var proceso = new Process();
            proceso.StartInfo.FileName = "cmd.exe";
            proceso.StartInfo.Arguments = "/C " + comando;
            proceso.StartInfo.WorkingDirectory = rutaActual;
            proceso.StartInfo.UseShellExecute = false;
            proceso.StartInfo.RedirectStandardOutput = true;
            proceso.StartInfo.RedirectStandardError = true;
            proceso.StartInfo.CreateNoWindow = true;
            proceso.Start();
            proceso.WaitForExit();


            //Paso 3. Leer el archivo de codigo ensamblador y colocarlo en la forma CodigoEnsamblador
            rutaArchivoEnsamblador =  rutaArchivoEnsamblador.Replace("codigoEnsamblador", "output");
            var codigoEnsamblador = File.ReadAllText(rutaArchivoEnsamblador);
            var codigoEnsambladorForma = new CodigoEnsamblador(codigoEnsamblador);
            codigoEnsambladorForma.Show();
            


        }

        /// <summary>
        /// Genera un archivo extension C, en el que guarda la codificacion convertida.
        /// </summary>
        /// <param name="codigo">Las instrucciones que va a convertir</param>
        /// <returns>La ruta del archivo creado</returns>
        private string convertirVariablesACodigoC(List<string> codigo) {
            string lineas = "";

            lineas += "#include <stdio.h>\nint main() {\n";
            
            foreach(string linea in codigo) {
                if(linea.Contains("=")) {
                    lineas += $"\nint {linea};";
                }
                if (linea.Contains("leer")) {
                    var segundaPalabra = linea.Split(' ')[1];
                    lineas += $"\nscanf(\"%i\", &{segundaPalabra});";
                }
                if (linea.Contains("imprimir")) {
                    var segundaPalabra = linea.Split(' ')[1];
                    lineas += $"\nprintf(\"%i\", {segundaPalabra});";
                }
            }

            lineas += "\nreturn 0; }";
            return lineas;
        }
    }
}
