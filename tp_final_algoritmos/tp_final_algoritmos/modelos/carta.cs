using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp_final_algoritmos.Enums;

namespace tp_final_algoritmos.modelos
{
    public class Carta
    {
        
        public int numero { get; set; }
        public Palo palo { get; set; }
        public int valor_truco { get; set; } // 13 ancho de espada a 0 los cuatros
        public int valor_envido { get; set; } // 0 para las figuras y el nro para el resto
        public int id_jugador {  get; set; }
        // para guardar quien tiro la carta cuando esten en la mesa

        public Carta() { }
        public Carta(int numero, Palo palo, int valor_truco,int valor_envido, int id_jugador)
        {
            this.numero = numero;
            this.palo = palo;
            this.valor_envido = valor_envido;
            this.valor_truco = valor_truco;
            this.id_jugador = id_jugador;
        }

        public override string ToString() => $"{numero} de {palo}";

    }
}
