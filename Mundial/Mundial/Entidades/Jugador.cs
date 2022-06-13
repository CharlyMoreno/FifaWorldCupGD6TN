using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mundial.Entidades
{
    class Jugador
    {
        public int id_jugador { get; set; }
        public string nombre { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public int altura { get; set; }
        public int peso { get; set; }
        public int dorsal { get; set; }
    }
}
