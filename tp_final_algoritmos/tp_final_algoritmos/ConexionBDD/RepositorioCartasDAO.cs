using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp_final_algoritmos.Enums;
using tp_final_algoritmos.modelos;

namespace tp_final_algoritmos.ConexionBDD
{

    // ES LA CLASE QUE SE ENCARGAR DE TRAER EL MAZO DE CARTAS DESDE LA BASE DE DATOS 
    public class RepositorioCartasDAO
    {
        public List<Carta> obtener_mazo_de_bdd()
        {
            List<Carta> mazo = new List<Carta>();

            using (MySqlConnection conexion = ConexionDAO.crear_conexion())
            {
                conexion.Open();
                using (MySqlCommand comando = new MySqlCommand("sp_traer_cartas", conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
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
    }
}
