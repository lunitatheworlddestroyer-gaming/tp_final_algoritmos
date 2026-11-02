using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final_algoritmos.modelos
{
    public class partida
    {
        public int cant_jugadores;
        public int nosotros;
        public int ellos;
        public List<jugador> jugadores;
        public List<carta> primera;
        public List<carta> segunda;
        public List<carta> ultima;
        //cartas en la mesa, separadas por vuelta
        bool ganador_primera;
        bool ganador_segunda;
        bool ganador_tercera;

        public partida(int c, int n, int e)
        {
            cant_jugadores = c;
            nosotros = n;
            ellos = e;
        }
    }
}
