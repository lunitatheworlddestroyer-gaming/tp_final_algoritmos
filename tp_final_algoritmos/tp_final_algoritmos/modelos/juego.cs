using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final_algoritmos.modelos
{

    public static class Juego
    {
        //para poner funciones del juego
        public static int valor_envido(Jugador j)
        {
            //hacer
            if (j.mano[0].palo == j.mano[1].palo && j.mano[0].palo == j.mano[2].palo)
            {
                return 0;
            }
            if (j.mano[0].palo == j.mano[1].palo) { return 0; }
            if (j.mano[0].palo == j.mano[2].palo) { return 0; }
            if (j.mano[1].palo == j.mano[2].palo) { return 0; }
            return 0;
        }
    }
}
