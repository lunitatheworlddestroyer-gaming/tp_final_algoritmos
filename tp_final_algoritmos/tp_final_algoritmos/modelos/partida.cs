using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final_algoritmos.modelos
{
    public class Partida
    {
        public int cant_jugadores;
        public int nosotros;
        public int ellos;
        public int id_mano;
        //id del jugador que empieza
        public List<Jugador> jugadores;
        public List<Carta> cartas_jugadas { get; set; }
        //cartas en la partida
        public List<Carta> ronda;
        //cartas en la mesa, en cada vuelta se reinicia
        public int vuelta;
        // 1, 2 y 3 como primera, segunda y tercera
        public bool? ganador_primera;
        public bool? ganador_segunda;
        public bool? ganador_tercera;

        public Partida(int c)
        {
            cant_jugadores = c;
            nosotros = 0;
            ellos = 0;
            id_mano = 0;
        }
    }
}
