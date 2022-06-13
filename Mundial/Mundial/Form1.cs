using Mundial.Entidades;
using Mundial.Formularios;
using Mundial.Negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mundial
{
    public partial class Form1 : Form
    {
        List<entMundial> mundiales;
        public Form1()
        {
            InitializeComponent();
            TraerMundiales();
        }
        //private void DescargarBanderas(int id_mundial)
        //{
        //    List<Seleccion> selecciones = negocios.Instancia.TraerSelecciones(id_mundial);

        //    foreach(Seleccion s in selecciones)
        //    {
        //        Image img = negocios.GetImageFromPicPath(s.bandera);
        //        banderasSeleccion.Add(s.id_seleccion,img);
        //    }


        //}
        private void TraerMundiales()
        {
            mundiales = Negocio.negocios.Instancia.TraerMundiales();
            foreach (entMundial m in mundiales)
            {
                cBMundiales.Items.Add($"{m.pais} - {m.fechaDesde.ToString("yyyy")}");
                cBMundiales.SelectedIndex = 0;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(cBMundiales.SelectedIndex >= 0)
            {
                
                entMundial m = mundiales[cBMundiales.SelectedIndex];
                this.Hide();
                formMenu menu = new formMenu(m);
                menu.Show();
            }
        }
    }
}
