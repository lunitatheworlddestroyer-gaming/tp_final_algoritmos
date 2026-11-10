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
        public static bool ganador_envido(Partida p)
        {
            Jugador j = p.jugadores[p.id_mano];
            foreach(Jugador j2 in p.jugadores)
            {
                if(Juego.valor_envido(j) < Juego.valor_envido(j2))
                {
                    j = j2;
                }
            }
            return j.equipo;
        }
        public static int ganador_carta(Partida p)
        {
            Carta ganadora = p.ronda[p.id_mano];
            foreach (Carta c in p.ronda)
            {
                if (c.valor_truco > ganadora.valor_truco)
                {
                    ganadora = c;
                }
            }
            return ganadora.id_jugador;
        }
        public static bool? ganador_ronda(Partida p)
        {
            if (p.vuelta == 2)
            {
                //para la segunda
                if (p.ganador_primera == true)
                {
                    if (p.ganador_segunda == true || p.ganador_segunda == null)
                    {
                        // ganamos nosotros
                        return true;
                    }
                    if (p.ganador_segunda == false)
                    {
                        return null;
                    }
                }
                if (p.ganador_primera == false)
                {
                    if (p.ganador_segunda == false || p.ganador_segunda == null)
                    {
                        //ganan ellos
                        return true;
                    }
                    if (p.ganador_segunda == true)
                    {
                        return null;
                    }
                }
                if (p.ganador_primera == null)
                {
                    if (p.ganador_segunda == true)
                    {
                        return true;
                    }
                    if (p.ganador_segunda == false)
                    {
                        return false;
                    }
                }
                return null;
            }
            if (p.vuelta == 3)
            {

                if (p.ganador_tercera != null)
                {
                    return p.ganador_tercera;
                }
                else
                {
                    return p.jugadores[p.id_mano].equipo;
                }
            }
            return null;
        }

    }
}
