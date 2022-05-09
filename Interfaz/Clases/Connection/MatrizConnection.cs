using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Interfaz.Connection {
    public class MatrizConnection {
        private string CONNECTION_STRING_NAME = "";
        public SqlConnection conexion = null;
        private static MatrizConnection _instance = null;

        /// <summary>
        /// Genera la conexion a la base de datos
        /// </summary>
        public MatrizConnection() {
            try {
                CONNECTION_STRING_NAME = ConfigurationManager.ConnectionStrings["dev"].ConnectionString;
            } catch(Exception ex) {
                throw new Exception("[Error] No se logró establecer la conexión a la base de datos, revisa el App.config.. Adicional: " + ex.Message);
            }
            conexion = new SqlConnection(CONNECTION_STRING_NAME);
        }

        /// <summary>
        /// Establece una conexion con la base de datos
        /// </summary>
        private void conectar() {
            if(conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();

            conexion.Open();                
        }

        /// <summary>
        /// Cierra la conexion a la base de datos
        /// </summary>
        private void desconectar() {
            conexion.Close();
        }

        /// <summary>
        /// Acceso a la Base de datos.
        /// </summary>
        public static MatrizConnection GetInstance {
            get {
                if (_instance == null) _instance = new MatrizConnection();
                return _instance;
            }
        }

        /// <summary>
        /// Realza una consulta tipo select, que regresa un unico valor.
        /// </summary>
        /// <param name="columna">Columna que se selcciona (SELECT)</param>
        /// <param name="estado">Estado que se busca (WHERE)</param>
        /// <returns>Un unico resultado, que es la interseccion del estado/columna</returns>
        public string obtenerResultado(string columna, int estado) {
            conectar();

                string resultado = null;
                SqlCommand command = new SqlCommand(
                    "SELECT m.[" + columna + "] FROM matriz m WHERE estado = @estado",
                    conexion
                );

                command.Parameters.AddWithValue("@estado", estado);

                using(SqlDataReader reader = command.ExecuteReader()) {
                    if(reader.Read()) {
                        resultado = (string) reader[columna];
                    }
                }

            desconectar();
            return resultado;
        }

        /// <summary>
        /// Realiza una busqueda del token (Columna CAT) para determinado estado.
        /// </summary>
        /// <param name="estado">El estado que se esta buscando</param>
        /// <returns></returns>
        public string obtenerToken(int estado) {
            conectar();
            
                string resultado = null;
                SqlCommand command = new SqlCommand(
                    "SELECT m.CAT FROM matriz m WHERE estado = @estado",
                    conexion
                );

                command.Parameters.AddWithValue("@estado", estado);

                using(SqlDataReader reader = command.ExecuteReader()) {
                    if(reader.Read()) {
                        resultado = (string) reader["CAT"];
                    }
                }

            desconectar();
            return resultado;
        }

        /// <summary>
        /// Obtiene la descripcion para determinado error, en base al token unico del error.
        /// </summary>
        /// <param name="token">Token asignado al error que se busca</param>
        /// <returns></returns>
        public string obtenerError(string token) {
            conectar();

                string resultado = null;
                SqlCommand command = new SqlCommand(
                    "SELECT m2.FDC FROM matriz m INNER JOIN matriz m2 ON m2.Estado = m.Estado + 1 WHERE m.cat = @token",
                    conexion
                );

                command.Parameters.AddWithValue("@token", token);

                using(SqlDataReader reader = command.ExecuteReader()) {
                    if(reader.Read()) {
                        resultado = (string) reader["FDC"];
                    }
                }

            desconectar();
            return resultado;
        }
    }
}
