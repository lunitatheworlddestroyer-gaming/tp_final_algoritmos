using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final_algoritmos.modelos
{
    public class Partida
    {
        public int cant_jugadores { get; set; }
        public int nosotros { get; set; }
        public int ellos { get; set; }
        public List<Jugador> jugadores { get; set; }
        public List<Carta> cartas_jugadas { get; set; }
        //cartas en la mesa
    }
}
