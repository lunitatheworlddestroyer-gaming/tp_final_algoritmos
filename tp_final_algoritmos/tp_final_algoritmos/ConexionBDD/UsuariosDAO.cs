using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final_algoritmos.ConexionBDD
{
    public class UsuariosDAO
    {
        public bool inicio_sesion(string u, string p)
        {
            using (MySqlConnection conexion = ConexionDAO.crear_conexion())
            {
                conexion.Open();
                string sql = "SELECT nombre, pass" +
                    "FROM usuarios" +
                    $"WHERE nombre = {u} AND pass = {p}";
                using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                {
                    using (MySqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }
    }
}
