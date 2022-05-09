using System;
using System.IO;

namespace Interfaz.Clases.IO {
    public class OutputArchivo {
        public static void Guardar(string texto, string ruta) {
            try {
                File.WriteAllText(ruta, texto);
            } catch(Exception ex) {
                throw ex;
            }
        }

        public static string Cargar(string ruta) {
            return File.ReadAllText(ruta);
        }
    }
}
