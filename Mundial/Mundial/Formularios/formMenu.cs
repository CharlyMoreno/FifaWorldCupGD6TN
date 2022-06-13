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
    public partial class formMenu : Form
    {
        entMundial mundial;
        public formMenu(entMundial m)
        {
            this.mundial = m;
            InitializeComponent();
            txtMundial.Text = $"{mundial.pais} - {mundial.fechaDesde.ToString("yyyy")}";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Grupos formGrupos = new Grupos(mundial);
            formGrupos.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Selecciones formSelecciones = new Selecciones(mundial);
            formSelecciones.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Partidos partidos = new Partidos(mundial);
            partidos.Show();
        }
    }
}
