using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mundial.Entidades
{
    class JugadorSeleccion
    {
        public entMundial mundial { get; set; }
        public Seleccion seleccion { get; set; }
        public Jugador jugador { get; set; }
        public int dorsal { get; set; }
    }
}
