using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final_algoritmos.modelos
{
    public class Jugador
    {
        public string nombre {  get; set; }
        //nombre de usuario, sino "enemigo 1" o "compañero 1", si hay tiempo ponemos nombres reales
        public bool equipo {  get; set; }
        //true si es nosotros, false si es ellos
        public List<Carta> mano { get; set; }
        //como mucho 3
        public bool es_bot {  get; set; }
        //autoexplicativo
        public int id { get; set; }
        //para guardar quien empieza la siguiente vuelta
        Carta bajar_carta(Carta c)
        {
            mano.Remove(c);
            return c;
        }
    }
}
