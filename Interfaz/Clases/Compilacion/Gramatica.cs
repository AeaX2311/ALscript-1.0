using System.Collections.Generic;
using System.Linq;

namespace Interfaz.Clases.Compilacion {
    class Gramatica {
        public Gramatica() { }
        public Gramatica(string pK, List<string> instruccionGramatica, bool esTerminal) {
            PK = pK;
            InstruccionGramatica = instruccionGramatica;
            EsTerminal = esTerminal;
        }

        private string pk;

        public string PK {
            get { return pk; }
            set { pk = value; }
        }

        public int Longitud {
            get { return InstruccionGramatica.Count(); }
        }

        private List<string> instruccionGramatica;

        public List<string> InstruccionGramatica {
            get {
                if(instruccionGramatica == null)
                    instruccionGramatica = new List<string>();

                return instruccionGramatica; 
            }
            set { instruccionGramatica = value; }
        }

        private bool terminal;

        public bool EsTerminal {
            get { return terminal; }
            set { terminal = value; }
        }

        public bool entraEnElRangoPosible(int maximo) {
            return Longitud == maximo;
        }
    }
}
