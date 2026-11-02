using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final_algoritmos.ConexionBDD
{
    public static class ConexionDAO
    {
        private static string cadena_de_conexion; // agregar los datos de la BDD

        public static MySqlConnection crear_conexion()
        {
            return new MySqlConnection(cadena_de_conexion);
        }
    }
}
