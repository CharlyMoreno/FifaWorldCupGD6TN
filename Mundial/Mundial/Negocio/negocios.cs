using Mundial.Base_de_Datos;
using Mundial.Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Mundial.Negocio
{
    class negocios
    {
        #region Singleton
        private static readonly negocios _instancia = new negocios();
        public static negocios Instancia
        {
            get
            {
                return negocios._instancia;
            }
        }
        #endregion
        public List<entMundial> TraerMundiales()
        {
            try
            {
                List<entMundial> result = BaseDatos.Instancia.TraerMundiales();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<entGrupo> TraerGrupos()
        {
            try
            {
                List<entGrupo> result = BaseDatos.Instancia.TraerGrupos();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<TipoPartido> TraerTipoPartido()
        {
            try
            {
                List<TipoPartido> result = BaseDatos.Instancia.TraerTipoPartido();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Partido> TraerPartidosFases(int id_mundial , int id_tipoPartido,int id_grupo)
        {
            try
            {
                List<Partido> result = BaseDatos.Instancia.TraerPartidosFases(id_mundial, id_tipoPartido,id_grupo);
                List<Seleccion> selecciones = BaseDatos.Instancia.TraerSelecciones(id_mundial);

                foreach (Partido p in result)
                {
                    p.seleccion1 = selecciones.Find(x => x.id_seleccion == p.seleccion1.id_seleccion);
                    p.seleccion2 = selecciones.Find(x => x.id_seleccion == p.seleccion2.id_seleccion);
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Seleccion> TraerSeleccionesGrupo(int id_grupo, int id_mundial)
        {
            try
            {
                List<Seleccion> result = BaseDatos.Instancia.TraerSeleccionesGrupo(id_grupo, id_mundial);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Seleccion> TraerSelecciones(int id_mundial)
        {
            try
            {
                List<Seleccion> result = BaseDatos.Instancia.TraerSelecciones(id_mundial);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Jugador> TraerJugadores(int id_mundial,int id_seleccion)
        {
            try
            {
                List<Jugador> result = BaseDatos.Instancia.TraerJugadores(id_mundial,id_seleccion);
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Image GetImageFromPicPath(string strUrl)
        {
            Image img = null;
            try
            {
                using (WebResponse wrFileResponse = WebRequest.Create(strUrl).GetResponse())
                using (Stream objWebStream = wrFileResponse.GetResponseStream())
                {
                    MemoryStream ms = new MemoryStream();
                    objWebStream.CopyTo(ms, 8192);
                    img = Image.FromStream(ms);
                }
            }
            catch (Exception e)
            {

            }
            return img;

        }
    }
}
