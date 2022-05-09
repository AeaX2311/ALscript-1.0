namespace Interfaz.Clases {
    class Identificador {
        private string nombre;

        public string Nombre {
            get { return nombre; }
            set { nombre = value; }
        }

        private string valor;

        public string Valor {
            get { return valor; }
            set { valor = value; }
        }

        public Identificador(string nombre, string valor) {
            Nombre = nombre;
            Valor = valor;
        }
    }
}
