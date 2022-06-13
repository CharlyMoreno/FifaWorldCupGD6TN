using Mundial.Entidades;
using Mundial.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mundial.Formularios
{
    public partial class Grupos : Form
    {
        entMundial mundial;
        List<entGrupo> grupos;
        public Grupos(entMundial m)
        {
            this.mundial = m;
            InitializeComponent();
            TraerGrupos();
            txtMundial.Text = $"{mundial.pais} - {mundial.fechaDesde.ToString("yyyy")}";
        }
        private void TraerGrupos()
        {
            grupos = negocios.Instancia.TraerGrupos();
            foreach (entGrupo g in grupos)
            {
                cbGrupos.Items.Add($"{g.nombre}");
                cbGrupos.SelectedIndex = 0;
            }
        }

        private void cbGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            entGrupo grupoSeleccionado = grupos[cbGrupos.SelectedIndex];
            List<Seleccion> selecciones = negocios.Instancia.TraerSeleccionesGrupo(grupoSeleccionado.id_grupo,mundial.id_mundial);

            banEquipo1.Image = negocios.GetImageFromPicPath(selecciones[0].bandera);
            banEquipo2.Image = negocios.GetImageFromPicPath(selecciones[1].bandera);
            banEquipo3.Image = negocios.GetImageFromPicPath(selecciones[2].bandera);
            banEquipo4.Image = negocios.GetImageFromPicPath(selecciones[3].bandera);

            txtEquipo1.Text = selecciones[0].nombre;
            txtEquipo2.Text = selecciones[1].nombre;
            txtEquipo3.Text = selecciones[2].nombre;
            txtEquipo4.Text = selecciones[3].nombre;

            txtGrupo.Text = grupoSeleccionado.nombre;

        }
    }
}
