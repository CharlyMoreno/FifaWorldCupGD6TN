using Mundial.Entidades;
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
    public partial class Selecciones : Form
    {
        entMundial mundial;
        List<Seleccion> selecciones;
        public Selecciones(entMundial m)
        {
            this.mundial = m;
            InitializeComponent();
            CargarSelecciones();
            txtMundial.Text = $"{mundial.pais} - {mundial.fechaDesde.ToString("yyyy")}";

        }
        private void CargarSelecciones()
        {
            selecciones = Negocio.negocios.Instancia.TraerSelecciones(mundial.id_mundial);
            selecciones = selecciones.OrderBy(x => x.nombre).ToList();
            foreach (Seleccion s in selecciones)
            {
                cbSelecciones.Items.Add($"{s.nombre}");
                cbSelecciones.SelectedIndex = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Seleccion seleccionElegida = selecciones[cbSelecciones.SelectedIndex];
            bandera.ImageLocation = seleccionElegida.bandera;
            txtSeleccion.Text = seleccionElegida.nombre;

            List<Jugador> jugadores = Negocio.negocios.Instancia.TraerJugadores(mundial.id_mundial,seleccionElegida.id_seleccion);
            jugadores = jugadores.OrderBy(o => o.dorsal).ToList();

            dataGridView1.Rows.Clear();

            foreach (Jugador j in jugadores)
            {
                int ultimaRow = dataGridView1.Rows.Count;
                dataGridView1.Rows.Insert(ultimaRow,j.dorsal,j.nombre,j.fechaNacimiento.ToString("dd-MM-yyyy"),j.altura,j.peso);
            }
            


        }
    }
}
