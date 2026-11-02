using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final_algoritmos.modelos
{
    public class jugador
    {
        public string nombre;
        //nombre de usuario, sino "ellos 1" o "nosotros 1", si hay tiempo ponemos nombres reales
        public List<carta> mano;
        //como mucho 3
        public bool equipo;
        //1 si es nosotros, 0 si es ellos
        public int id;
        //para guardar quien empieza la siguiente vuelta
        public jugador(string n, bool e, int i)
        {
            nombre = n;
            equipo = e;
            id = i;
        }
        public carta bajar_carta(carta c)
        {
            mano.Remove(c);
            return c;
        }
    }
}
