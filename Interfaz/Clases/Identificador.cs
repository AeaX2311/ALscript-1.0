using System.Collections.Generic;

namespace Interfaz.Clases {
    class Identificador {
        public Identificador(string nombre, string valor, int secuencial) {
            Nombre = nombre;
            Valor = valor;
            Secuencial = secuencial;
        }

        private string nombre;

        public string Nombre {
            get { return nombre; }
            set {
                string nombreLimpio = "";
                
                foreach(char c in value) {
                    if(c != '\n' && c != ' ' && c != '\t') nombreLimpio += c;
                }

                nombre = nombreLimpio; 
            }
        }

        private string valor;

        public string Valor {
            get { return valor; }
            set { valor = value; }
        }

        private string tipoDato;

        public string TipoDato {
            get { return tipoDato; }
            set { tipoDato = value; }
        }

        private int secuencial;

        public int Secuencial {
            get { return secuencial; }
            set { secuencial = value; }
        }

        public override bool Equals(object obj) {
            return obj is Identificador identificador &&
                   Nombre == identificador.Nombre;
        }

        public override int GetHashCode() {
            return 289764928 + EqualityComparer<string>.Default.GetHashCode(Nombre);
        }
    }
}
