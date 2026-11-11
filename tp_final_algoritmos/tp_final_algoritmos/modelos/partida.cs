using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp_final_algoritmos.Enums;

namespace tp_final_algoritmos.modelos
{
    public class Partida
    {
        private Mazo mazo;
        public int puntos; // es hasta 15 o hasta 30
        public bool con_flor = false;
        public Modo_partida modo_partida; // simple o torneo
        public int cant_jugadores;
        public int nosotros;
        public int ellos;
        public int id_mano;
        //id del jugador que empieza
        public List<Jugador> jugadores;
        public List<Carta> cartas_jugadas { get; set; }
        //cartas en la partida
        public List<Carta> cartas_en_mesa;
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
        public void repartir()
        {
            // llamar al evento que trae las cartas de la bdd y las pone en p.cartas_jugadas
            foreach (Carta c in this.cartas_jugadas)
            {
                foreach (Jugador j in this.jugadores)
                {
                    if (c.id_jugador == j.id)
                    {
                        j.mano.Add(c);
                    }
                }
            }
        }
        public void nueva_ronda()
        {
            this.cartas_jugadas.Clear();
            this.cartas_en_mesa.Clear();
            foreach (Jugador j in this.jugadores)
            {
                j.mano.Clear();
            }
            this.vuelta = 1;
            this.ganador_primera = null;
            this.ganador_segunda = null;
            this.ganador_tercera = null;
        }
        public int valor_envido(Jugador j)
        {
            //si hay flor toma los mas grandes y los devuelve
            if (j.mano[0].palo == j.mano[1].palo && j.mano[0].palo == j.mano[2].palo)
            {
                if (j.mano[0].valor_envido > j.mano[2].valor_envido && j.mano[1].valor_envido > j.mano[2].valor_envido)
                {
                    return j.mano[0].valor_envido + j.mano[1].valor_envido;
                }
                if (j.mano[0].valor_envido > j.mano[1].valor_envido && j.mano[2].valor_envido > j.mano[1].valor_envido)
                {
                    return j.mano[0].valor_envido + j.mano[2].valor_envido;
                }
                if (j.mano[1].valor_envido > j.mano[0].valor_envido && j.mano[2].valor_envido > j.mano[0].valor_envido)
                {
                    return j.mano[2].valor_envido + j.mano[1].valor_envido;
                }
            }
            // con 2 cartas
            if (j.mano[0].palo == j.mano[1].palo)
            {
                return j.mano[0].valor_envido + j.mano[1].valor_envido;
            }
            if (j.mano[0].palo == j.mano[2].palo)
            {
                return j.mano[0].valor_envido + j.mano[2].valor_envido;
            }
            if (j.mano[1].palo == j.mano[2].palo)
            {
                return j.mano[2].valor_envido + j.mano[1].valor_envido;
            }
            //si no tiene cartas iguales
            if (j.mano[0].valor_envido >= j.mano[1].valor_envido)
            {
                if (j.mano[0].valor_envido >= j.mano[2].valor_envido)
                {
                    return j.mano[0].valor_envido;
                }
                else
                {
                    return j.mano[2].valor_envido;
                }

            }
            else
            {
                if (j.mano[1].valor_envido >= j.mano[2].valor_envido)
                {
                    return j.mano[1].valor_envido;
                }
                else
                {
                    return j.mano[2].valor_envido;
                }
            }
        }
        public bool ganador_envido()
        {
            Jugador j = this.jugadores[this.id_mano];
            foreach (Jugador j2 in this.jugadores)
            {
                if (this.valor_envido(j) < this.valor_envido(j2))
                {
                    j = j2;
                }
            }
            return j.equipo;
        }
        public int ganador_carta()
        {
            Carta ganadora = this.cartas_en_mesa[this.id_mano];
            foreach (Carta c in this.cartas_en_mesa)
            {
                if (c.valor_truco > ganadora.valor_truco)
                {
                    ganadora = c;
                }
            }
            return ganadora.id_jugador;
        }
        public bool? ganador_ronda()
        {
            if (this.vuelta == 2)
            {
                //para la segunda
                if (this.ganador_primera == true)
                {
                    if (this.ganador_segunda == true || this.ganador_segunda == null)
                    {
                        // ganamos nosotros
                        return true;
                    }
                    if (this.ganador_segunda == false)
                    {
                        return null;
                    }
                }
                if (this.ganador_primera == false)
                {
                    if (this.ganador_segunda == false || this.ganador_segunda == null)
                    {
                        //ganan ellos
                        return true;
                    }
                    if (this.ganador_segunda == true)
                    {
                        return null;
                    }
                }
                if (this.ganador_primera == null)
                {
                    if (this.ganador_segunda == true)
                    {
                        return true;
                    }
                    if (this.ganador_segunda == false)
                    {
                        return false;
                    }
                }
                return null;
            }
            if (this.vuelta == 3)
            {

                if (this.ganador_tercera != null)
                {
                    return this.ganador_tercera;
                }
                else
                {
                    return this.jugadores[this.id_mano].equipo;
                }
            }
            return null;
        }
    }
}
