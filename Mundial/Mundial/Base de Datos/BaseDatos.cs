using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Mundial.Entidades;

namespace Mundial.Base_de_Datos
{
    class BaseDatos
    {
        #region Singleton
        private static readonly BaseDatos _instancia = new BaseDatos();
        public static BaseDatos Instancia
        {
            get
            {
                return BaseDatos._instancia;
            }
        }
        #endregion

        //public int CrearProducto(entProducto p)
        //{
        //    MySqlCommand comando = null;
        //    MySqlConnection connection = Conexion.Instancia.ObtenerInstancia();

        //    try
        //    {
        //        connection.Open();
        //        comando = new MySqlCommand($"INSERT INTO `Productos`(`Nombre_Producto`,`Precio`, `PrecioFijo`, `PermiteCantidad`,`RangoMinimo`) VALUES ('{p.Nombre_Producto}','{p.Precio}','{p.PrecioFijo}','{p.PermiteCantidad}','{p.RangoMinimo}')", connection);
        //        var result = comando.ExecuteNonQuery();
        //        return result;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally { connection.Close(); }
        //}
        public List<entMundial> TraerMundiales()
        {
            MySqlCommand comando = null;
            MySqlDataReader reader = null;
            List<entMundial> mundiales = new List<entMundial>();
            MySqlConnection connection = Conexion.Instancia.ObtenerInstancia();
            try
            {
                connection.Open();
                comando = new MySqlCommand($"select * from mundial", connection);
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    entMundial m = new entMundial();
                    m.id_mundial = Convert.ToInt32(reader["id_mundial"].ToString());
                    m.pais = reader["pais"].ToString();
                    m.fechaDesde = DateTime.Parse(reader["fechaInicio"].ToString());
                    m.fechaHasta = DateTime.Parse(reader["fechaFin"].ToString());
                    mundiales.Add(m);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { connection.Close(); }
            return mundiales;
        }

        public List<entGrupo> TraerGrupos()
        {
            MySqlCommand comando = null;
            MySqlDataReader reader = null;
            List<entGrupo> grupos = new List<entGrupo>();
            MySqlConnection connection = Conexion.Instancia.ObtenerInstancia();
            try
            {
                connection.Open();
                comando = new MySqlCommand($"select * from grupo", connection);
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    entGrupo g = new entGrupo();
                    g.id_grupo = Convert.ToInt32(reader["id_grupo"].ToString());
                    g.nombre = reader["nombre"].ToString();
                    grupos.Add(g);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { connection.Close(); }
            return grupos;
        }

        public List<TipoPartido> TraerTipoPartido()
        {
            MySqlCommand comando = null;
            MySqlDataReader reader = null;
            List<TipoPartido> tipoPartidos = new List<TipoPartido>();
            MySqlConnection connection = Conexion.Instancia.ObtenerInstancia();
            try
            {
                connection.Open();
                comando = new MySqlCommand($"select * from tipoPartido", connection);
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    TipoPartido tp = new TipoPartido();
                    tp.id_tipoPartido = Convert.ToInt32(reader["id_tipoPartido"].ToString());
                    tp.nombre = reader["nombre"].ToString();
                    tipoPartidos.Add(tp);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { connection.Close(); }
            return tipoPartidos;
        }

        public List<Partido> TraerPartidosFases(int id_mundial, int id_tipopartido,int id_grupo)
        {
            MySqlCommand comando = null;
            MySqlDataReader reader = null;
            List<Partido> partidos = new List<Partido>();
            MySqlConnection connection = Conexion.Instancia.ObtenerInstancia();
            try
            {
                connection.Open();
                if(id_grupo == -1) comando = new MySqlCommand($"select * from partido p where p.id_mundial = {id_mundial} and id_tipoPartido = {id_tipopartido};", connection);
                else comando = new MySqlCommand($"select p.* from partido p , mundialseleccion ms where p.id_mundial = {id_mundial} and id_tipoPartido = {id_tipopartido} and p.id_seleccion1 = ms.id_seleccion and ms.id_grupo = {id_grupo};", connection);

                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Partido p = new Partido();
                    p.id_partido = Convert.ToInt32(reader["id_partido"].ToString());
                    p.fecha = DateTime.Parse(reader["fecha"].ToString());
                    p.seleccion1 = new Seleccion();
                    p.seleccion1.id_seleccion = Convert.ToInt32(reader["id_seleccion1"].ToString());
                    p.seleccion2 = new Seleccion();
                    p.seleccion2.id_seleccion = Convert.ToInt32(reader["id_seleccion2"].ToString());
                    p.golesSeleccion1 = Convert.ToInt32(reader["golesSeleccion1"].ToString());
                    p.golesSeleccion2 = Convert.ToInt32(reader["golesSeleccion2"].ToString());
                    p.penalesSeleccion1 = Convert.ToInt32(reader["penalesSeleccion1"].ToString());
                    p.penalesSeleccion2 = Convert.ToInt32(reader["penalesSeleccion2"].ToString());
                    partidos.Add(p);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { connection.Close(); }
            return partidos;
        }

        public List<Seleccion> TraerSeleccionesGrupo(int id_grupo, int id_mundial)
        {
            MySqlCommand comando = null;
            MySqlDataReader reader = null;
            List<Seleccion> selecciones = new List<Seleccion>();
            MySqlConnection connection = Conexion.Instancia.ObtenerInstancia();
            try
            {
                connection.Open();
                comando = new MySqlCommand($"select s.* from mundialseleccion ms, seleccion s where s.id_seleccion = ms.id_seleccion and ms.id_mundial = {id_mundial} and ms.id_grupo = {id_grupo};", connection);
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Seleccion s = new Seleccion();
                    s.id_seleccion = Convert.ToInt32(reader["id_seleccion"].ToString());
                    s.nombre = reader["nombre"].ToString();
                    s.bandera = reader["bandera"].ToString();
                    s.abreviatura = reader["abreviatura"].ToString();
                    selecciones.Add(s);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { connection.Close(); }
            return selecciones;
        }

        public List<Seleccion> TraerSelecciones(int id_mundial)
        {
            MySqlCommand comando = null;
            MySqlDataReader reader = null;
            List<Seleccion> selecciones = new List<Seleccion>();
            MySqlConnection connection = Conexion.Instancia.ObtenerInstancia();
            try
            {
                connection.Open();
                comando = new MySqlCommand($"select s.* from mundialseleccion ms, seleccion s where s.id_seleccion = ms.id_seleccion and ms.id_mundial = {id_mundial};", connection);
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Seleccion s = new Seleccion();
                    s.id_seleccion = Convert.ToInt32(reader["id_seleccion"].ToString());
                    s.nombre = reader["nombre"].ToString();
                    s.bandera = reader["bandera"].ToString();
                    s.abreviatura = reader["abreviatura"].ToString();
                    selecciones.Add(s);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { connection.Close(); }
            return selecciones;
        }

        public List<Jugador> TraerJugadores(int id_mundial,int id_seleccion)
        {
            MySqlCommand comando = null;
            MySqlDataReader reader = null;
            List<Jugador> selecciones = new List<Jugador>();
            MySqlConnection connection = Conexion.Instancia.ObtenerInstancia();
            try
            {
                connection.Open();
                comando = new MySqlCommand($"select j.*, js.dorsal from jugadorseleccion js, jugador j where js.id_jugador = j.id_jugador and js.id_mundial = {id_mundial} and js.id_seleccion = {id_seleccion};", connection);
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Jugador j = new Jugador();
                    j.id_jugador = Convert.ToInt32(reader["id_jugador"].ToString());
                    j.nombre = reader["nombre"].ToString();
                    j.fechaNacimiento = DateTime.Parse(reader["fechaNacimiento"].ToString());
                    j.altura = Int32.Parse(reader["altura"].ToString());
                    j.peso = Int32.Parse(reader["peso"].ToString());
                    j.dorsal = Int32.Parse(reader["dorsal"].ToString());
                    selecciones.Add(j);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { connection.Close(); }
            return selecciones;
        }
    }
}
