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
        // CLASE QUE CONTIENE EL MAZO Y ES RESPONSABLE DE MEZCLAR Y REPARTIR LAS CARTAS A LOS JUGADORES

            private List<Carta> cartas;
            private RepositorioCartasDAO repositorioCartasDAO;

            public Mazo()
            {
                repositorioCartasDAO = new RepositorioCartasDAO();
                cartas = repositorioCartasDAO.obtener_mazo_de_bdd();
            }

            public void mezclar_mazo()
            {
                Random random = new Random();
                int n = cartas.Count;
                for (int i = n - 1; i > 0; i--)
                {
                    int j = random.Next(0, i + 1);
                    Carta temp = cartas[i];
                    cartas[i] = cartas[j];
                    cartas[j] = temp;
                }
            }

            public void repartir_cartas(List<Jugador> jugadores)
            {
                int cantidad_jugadores = jugadores.Count;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < cantidad_jugadores; j++)
                    {
                        jugadores[j].mano.Add(cartas[0]);
                        cartas.RemoveAt(0);
                    }
                }
            }
        }
    }

