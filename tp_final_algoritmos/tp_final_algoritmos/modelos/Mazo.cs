using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp_final_algoritmos.ConexionBDD;
using tp_final_algoritmos.Enums;

namespace tp_final_algoritmos.modelos
{
    public class Mazo
    {
        private List<Carta> cartas;

        public List<Carta> obtener_mazo_de_bdd()
        {
            List<Carta> mazo = new List<Carta>();

            using (MySqlConnection conexion = ConexionDAO.crear_conexion())
            {
                using (MySqlCommand comando = new MySqlCommand("sp_traer_cartas", conexion))
                {
                    using (MySqlDataReader lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            Carta carta = new Carta();

                            carta.id = lector.GetInt32("id");
                            carta.numero = lector.GetInt32("numero");
                            carta.palo = (Palo)lector.GetInt32("palo");
                            carta.valor_truco = lector.GetInt32("valor_truco");
                            carta.valor_envido = lector.GetInt32("valor_envido");
                            carta.id_jugador = lector.GetInt32("id_jugador");

                            mazo.Add(carta);
                        }
                    }
                }
            }
            return mazo;
        }
        public void repartir(Partida p)
        {
            // llamar al evento que trae las cartas de la bdd y las pone en p.cartas_jugadas
            foreach (Carta c in p.cartas_jugadas)
            {
                foreach (Jugador j in p.jugadores)
                {
                    if (c.id_jugador == j.id)
                    {
                        j.mano.Add(c);
                    }
                }
            }
        }
        public void nueva_ronda(Partida p)
        {
            p.cartas_jugadas.Clear();
            p.ronda.Clear();
            foreach (Jugador j in p.jugadores)
            {
                j.mano.Clear();
            }
            p.vuelta = 1;
            p.ganador_primera = null;
            p.ganador_segunda = null;
            p.ganador_tercera = null;
        }

    }
}
