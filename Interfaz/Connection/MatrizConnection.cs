using System;
using System.Configuration;
using System.Data.SqlClient;
namespace Interfaz.Connection {
    /// <summary>
    /// Database connection. Singleton 
    /// <author>Alan Pena</author>
    /// </summary>
    public class MatrizConnection {

        /// <summary>
        /// Connection String, since we have three different developers, we gotta change this string
        /// whenever necessary.
        /// </summary>
        private string CONNECTION_STRING_NAME = "Server=localhost;Database=alscript;User Id=alan;Password=alan12345;Trusted_Connection=true";
        
        /// <summary>
        /// SqlConnection object to connect at database
        /// </summary>
        public SqlConnection Connection = null;

        /// <summary>
        /// Connecion singleton attribute
        /// </summary>
        private static MatrizConnection _instance = null;


        private MatrizConnection() {
            try {
                CONNECTION_STRING_NAME =  ConfigurationManager.ConnectionStrings["dev"].ConnectionString;
            } catch(Exception) {
                Console.WriteLine("[Error] A problem was encountred when trying to acces to the app.config file");
            }
            Connection = new SqlConnection(CONNECTION_STRING_NAME);
            Connection.Open();
        }


        /// <summary>
        /// Use this public property in order to get access to database
        /// </summary>
        public static MatrizConnection GetInstance {
            get {
                if (_instance == null) _instance = new MatrizConnection();
                return _instance;
            }
        }

        /// <summary>
        /// Execute a query
        /// </summary>
        /// <param name="command">SQL Query</param>
        public void EjecutarQuery(string command) {
            var cmd = new SqlCommand {
                Connection = Connection,
                CommandText = command
            };
            cmd.ExecuteNonQuery();
        }
    }
}
