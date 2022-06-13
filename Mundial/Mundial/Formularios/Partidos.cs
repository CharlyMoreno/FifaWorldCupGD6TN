using Mundial.Entidades;
using Mundial.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mundial.Formularios
{
    public partial class Partidos : Form
    {
        List<TipoPartido> fases;
        List<entGrupo> grupos;
        entMundial mundial;
        List<Partido> partidos;
        public Partidos(entMundial m)
        {
            this.mundial = m;
            InitializeComponent();
            CargarFases();
            CargarGrupos();
            txtMundial.Text = $"{mundial.pais} - {mundial.fechaDesde.ToString("yyyy")}";

        }
        private void CargarGrupos()
        {
            grupos = negocios.Instancia.TraerGrupos();
            foreach (entGrupo g in grupos)
            {
                cbGrupos.Items.Add($"{g.nombre}");
                cbGrupos.SelectedIndex = 0;
            }
        }
        private void CargarFases()
        {
            fases = negocios.Instancia.TraerTipoPartido();
            foreach (TipoPartido tp in fases)
            {
                cbFases.Items.Add($"{tp.nombre}");
                cbFases.SelectedIndex = 0;
            }
        }

        private void cbFases_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFases.SelectedIndex == 0)
            {
                cbGrupos.Enabled = true;
            }
            else
            {
                cbGrupos.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(cbFases.SelectedIndex != 0)
            {
                TipoPartido tp = fases[cbFases.SelectedIndex];
                partidos = negocios.Instancia.TraerPartidosFases(mundial.id_mundial, tp.id_tipoPartido,-1);
            }
            else
            {
                TipoPartido tp = fases[cbFases.SelectedIndex];
                int id_grupo = cbGrupos.SelectedIndex + 1;
                partidos = negocios.Instancia.TraerPartidosFases(mundial.id_mundial, tp.id_tipoPartido,id_grupo);
            }

            dataGridView1.Rows.Clear();
            foreach (Partido p in partidos)
            {
                int ultimaRow = dataGridView1.Rows.Count;

                Image img = negocios.GetImageFromPicPath(p.seleccion1.bandera);
                Image img2 = negocios.GetImageFromPicPath(p.seleccion2.bandera);

                if(p.penalesSeleccion1 == 0 || p.penalesSeleccion2 == 0)
                {
                    dataGridView1.Rows.Insert(ultimaRow, p.fecha.ToString("dd-MM-yyyy"), img, $"{p.seleccion1.abreviatura}", $"{p.golesSeleccion1} - {p.golesSeleccion2}", $"{p.seleccion2.abreviatura}", img2);
                }
                else
                {
                    dataGridView1.Rows.Insert(ultimaRow, p.fecha.ToString("dd-MM-yyyy"), img, $"{p.seleccion1.abreviatura}", $"{p.golesSeleccion1} ({p.penalesSeleccion1}) - ({p.penalesSeleccion2}) {p.golesSeleccion2}", $"{p.seleccion2.abreviatura}", img2);
                }
                
            }


        }

    }
}
