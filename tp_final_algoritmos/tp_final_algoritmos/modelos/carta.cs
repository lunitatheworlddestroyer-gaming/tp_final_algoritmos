using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final_algoritmos.modelos
{
    public class carta
    {
        public int numero;
        public int palo;
        public int valor;
        public int id_jugador;
        // para guardar quien tiro la carta cuando esten en la mesa
        public carta(int n, int p, int v, int j)
        {
            numero = n;
            palo = p;
            valor = v;
            id_jugador = j;
        }
    }
}
