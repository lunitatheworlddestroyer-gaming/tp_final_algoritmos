using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
                string sql = "SELECT nombre, pass " +
                    "FROM usuarios " +
                    $"WHERE nombre = '{u}' AND pass = '{p}'";
                using (MySqlCommand comando = new MySqlCommand(sql, conexion))
                {
                    using (MySqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.HasRows)
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
        public string registro(string u, string p)
        {
            string resultado;
            using (MySqlConnection conexion = ConexionDAO.crear_conexion())
            {
                conexion.Open();
                using (MySqlCommand comando =
                new MySqlCommand(
                "sp_registrar_usuario",
                conexion))
                {
                    comando.CommandType =
                        CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue(
                        "@p_nombre", u);
                    comando.Parameters.AddWithValue(
                        "@p_pass", p);
                    var r = comando.ExecuteScalar();
                    resultado = r.ToString();
                    return resultado;
                }
            }
        }
    }
}
