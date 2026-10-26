using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final_algoritmos.modelos
{
    public class jugador
    {
        string nombre;
        //nombre de usuario, sino "enemigo 1" o "compañero 1", si hay tiempo ponemos nombres reales
        bool equipo;
        //true si es nosotros, false si es ellos
        List<carta> mano;
        //como mucho 3
        bool bot;
        //autoexplicativo
        int id;
        //para guardar quien empieza la siguiente vuelta
        carta bajar_carta(carta c)
        {
            mano.Remove(c);
            return c;
        }
    }
}
