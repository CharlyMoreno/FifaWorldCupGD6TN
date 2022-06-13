using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mundial.Entidades
{
    class Partido
    {
        public int id_partido { get; set; }
        public DateTime fecha { get; set; }
        public entMundial mundial { get; set; }
        public TipoPartido tp { get; set; }
        public Seleccion seleccion1 { get; set; }
        public Seleccion seleccion2 { get; set; }
        public int golesSeleccion1 { get; set; }
        public int golesSeleccion2 { get; set; }
        public int penalesSeleccion1 { get; set; }
        public int penalesSeleccion2 { get; set; }

    }
}
