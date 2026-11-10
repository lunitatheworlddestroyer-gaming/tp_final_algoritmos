using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final_algoritmos.modelos
{
    public class Jugador_humano : Jugador
    {
        public Jugador_humano(string n, bool e, int i)
        {
            nombre = n;
            equipo = e;
            id = i;
        }
    }
}
