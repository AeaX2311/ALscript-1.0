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

            //Paso 1. Creamos el archivo con extension .C
            string path = @"C:\Users\alanc.DESKTOP-35RSJH4\Desktop\codigo.c";
            if(!File.Exists(path)) {
                // Create a file to write to.
                using(StreamWriter sw = File.CreateText(path)) {
                    sw.WriteLine(codigoConvertidoEnC);
                }
            }


            //Paso 2. Ejecutar en la consola el comando para compilar el codigo
            //y generar el ejecutable
            string comando = "gcc -o C:\\Users\\alanc.DESKTOP-35RSJH4\\Desktop\\codigo.exe C:\\alanc.DESKTOP-35RSJH4\\Usuario\\Desktop\\codigo.c";
            var proceso = new Process();
            proceso.StartInfo.FileName = "cmd.exe";
            proceso.StartInfo.Arguments = "/C " + comando;
            proceso.StartInfo.UseShellExecute = false;
            proceso.StartInfo.RedirectStandardOutput = true;
            proceso.StartInfo.RedirectStandardError = true;
            proceso.StartInfo.CreateNoWindow = true;
            proceso.Start();
            /*  proceso.WaitForExit();
              string salida = proceso.StandardOutput.ReadToEnd();
              string error = proceso.StandardError.ReadToEnd();
              proceso.Close();

              //Paso 3. Ejecutar el ejecutable
              string comando2 = "C:\\Users\\alanc.DESKTOP-35RSJH4\\Desktop\\codigo.exe";
              var proceso2 = new Process();
              proceso2.StartInfo.FileName = "cmd.exe";
              proceso2.StartInfo.Arguments = "/C " + comando2;
              proceso2.StartInfo.UseShellExecute = false;
              proceso2.StartInfo.RedirectStandardOutput = true;
              proceso2.StartInfo.RedirectStandardError = true;
              proceso2.StartInfo.CreateNoWindow = true;
              proceso2.Start();

              //Paso 4. Mostrar el resultado en el txtCompilacion
              string salida2 = proceso2.StandardOutput.ReadToEnd();
              string error2 = proceso2.StandardError.ReadToEnd();
              proceso2.Close();
              txtTripletas.Text = salida2;

              //Paso 5. Eliminar el archivo .C y el ejecutable
              File.Delete(path);
              File.Delete(@"C:\Users\alanc.DESKTOP-35RSJH4\Desktop\codigo.exe");*/
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
