using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Interfaz {
    public partial class CodigoEnsamblador : Form {
        public CodigoEnsamblador() {
            InitializeComponent();
        }

        public string CodigoEnsambladorProperty { get; set; }

        public CodigoEnsamblador(string codigo) {
            InitializeComponent();
            CodigoEnsambladorProperty = codigo;

            codigo = codigo.Replace("codigoC.c", "codigo.alscript").Replace(".ident\t\"GCC: (tdm64-1) 5.1.0\"", "");
            codigoEnsambladorTxt.Text = codigo;
        }

        private void btnSeAcaboTodo_Click(object sender, EventArgs e) {
            //Paso 1. Buscar el archivo codigoC.c que se genero en la ruta actual
            var rutaActual = Directory.GetCurrentDirectory();

            //Paso 2. Crear el ejecutable a partir del archivo codigoC.c
            var comando = "gcc codigoC.c -o codigo.exe";
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
            proceso.Close();

            //Paso 3. Ejecutar el archivo codigo.exe
            var procesoEjecutar = new Process();
            procesoEjecutar.StartInfo.FileName = "cmd.exe";
            procesoEjecutar.StartInfo.Arguments = "/C " + "codigo.exe";
            procesoEjecutar.StartInfo.WorkingDirectory = rutaActual;
            procesoEjecutar.StartInfo.UseShellExecute = false;
            procesoEjecutar.StartInfo.RedirectStandardOutput = true;
            procesoEjecutar.StartInfo.RedirectStandardError = true;
            procesoEjecutar.StartInfo.CreateNoWindow = false;
            procesoEjecutar.Start();

            //Paso 4. Mostrar el resultado en la consola
            var resultado = procesoEjecutar.StandardOutput.ReadToEnd();
            var error = procesoEjecutar.StandardError.ReadToEnd();
            txtResultados.Text = "";
            if (error != "") {
                MessageBox.Show(error);
            } else {
                foreach(string linea in resultado.Split('@')) {
                    txtResultados.Text += linea + "\n";
                }
            }
            procesoEjecutar.WaitForExit();

            procesoEjecutar.Close();
        }
    }
}
