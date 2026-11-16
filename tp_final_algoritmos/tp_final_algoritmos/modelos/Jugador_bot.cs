using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final_algoritmos.modelos
{
    public class Jugador_bot : Jugador
    {
        public Jugador_bot(string n, bool e, int i)
        {
            this.nombre = n;
            this.equipo = e;
            this.id = i;
        }
    }
}
