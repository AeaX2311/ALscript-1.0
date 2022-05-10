namespace Interfaz {
    class Error {
        private string token;

        public string Token {
            get { return token; }
            set { token = value; }
        }

        private int linea;

        public int Linea {
            get { return linea; }
            set { linea = value; }
        }

        private string palabra;

        public string Palabra {
            get { return palabra; }
            set { palabra = value; }
        }

        public Error(string token, int linea) {
            Token = token;
            Linea = linea;
        }

        public bool isNullOrEmpty() {
            return string.IsNullOrEmpty(Token);
        }
    }
}
