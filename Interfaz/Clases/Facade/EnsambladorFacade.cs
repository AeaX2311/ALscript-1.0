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

            //Paso 2. Compilar el archivo .C
            var procesoCompilacion = new Process();
            procesoCompilacion.StartInfo.FileName = "gcc";
            procesoCompilacion.StartInfo.Arguments = "-o codigoC.exe codigoC.c";
            procesoCompilacion.StartInfo.UseShellExecute = false;
            procesoCompilacion.StartInfo.RedirectStandardOutput = true;
            procesoCompilacion.Start();
            procesoCompilacion.WaitForExit();

            //Paso 3. Ejecutar el archivo .exe
            var procesoEjecucion = new Process();
            procesoEjecucion.StartInfo.FileName = "codigoC.exe";
            procesoEjecucion.StartInfo.UseShellExecute = false;
            procesoEjecucion.StartInfo.RedirectStandardOutput = true;
            procesoEjecucion.Start();
            procesoEjecucion.WaitForExit();

            //Paso 4. Mostrar el resultado en pantalla
            var resultado = procesoEjecucion.StandardOutput.ReadToEnd();
            MessageBox.Show(resultado);
            
            


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
            }

            lineas += "\nreturn 0; }";



            return lineas;
        }
    }
}
