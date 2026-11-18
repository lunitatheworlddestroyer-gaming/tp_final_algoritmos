using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final_algoritmos.modelos
{
    public abstract class Jugador
    {
        public string nombre;
        //nombre de usuario, sino "ellos 1" o "nosotros 1", si hay tiempo ponemos nombres reales
        public List<Carta> mano;
        //como mucho 3
        public bool equipo;
        //1 si es nosotros, 0 si es ellos
        public int id;
        //para guardar quien empieza la siguiente vuelta, 0 si es el usuario
        public Carta bajar_carta(Carta c)
        {
            mano.Remove(c);
            return c;
        }
    }
}
