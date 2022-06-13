using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Mundial.Base_de_Datos
{
    class Conexion
    {
        #region singleton
        private static readonly Conexion _instancia = new Conexion();
        public static Conexion Instancia
        {
            get
            {
                return Conexion._instancia;
            }
        }
        #endregion singleton

        private readonly string conexionString = ConfigurationManager.AppSettings["ConnectionString"].ToString();
        //private const string conexionString = "server=localhost;database=fifaworldcup;userid=root;password=root";
        public MySqlConnection ObtenerInstancia()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(conexionString);
                return connection;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
