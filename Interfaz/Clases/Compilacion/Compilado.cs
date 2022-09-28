using System.Collections.Generic;

namespace Interfaz.Clases {
    class Compilado {
        private string codigoCompilado;

        public string CodigoCompilado {
            get { return codigoCompilado; }
            set { codigoCompilado = value; }
        }

        private List<Error> errores;

        public List<Error> Errores {
            get { return errores; }
            set { errores = value; }
        }

        private List<Identificador> identificadores;

        public List<Identificador> Identificadores {
            get { return identificadores; }
            set { identificadores = value; }
        }

        public List<string> PalabrasARemarcarError { get; set; }

        public Compilado(string codigoCompilado, List<Error> errores, List<Identificador> identificadores, List<string> palabrasARemarcarError) {
            CodigoCompilado = codigoCompilado;
            Errores = errores;
            Identificadores = identificadores;
            PalabrasARemarcarError = palabrasARemarcarError;
        }
    }
}
