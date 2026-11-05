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
        private static string cadena_de_conexion  =  "server=localhost;" +
    "port=3306;" +
    "database=Trabajo_final;" +
    "uid=root;" +
    "pwd=admin;";

        public static MySqlConnection crear_conexion()
        {
            return new MySqlConnection(cadena_de_conexion);
        }
    }
}
