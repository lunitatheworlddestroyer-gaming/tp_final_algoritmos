using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace tp_final_algoritmos.ConexionBDD
{
    public static class ConexionDAO
    {
        private static string obtener_cadena_de_conexion()
        {
            // LEO EL ARCHIVO JSON QUE CONTIENE LA CONFIGURACION DE LA BDD
            string json = File.ReadAllText("config.json");

            // LO CONVIERTO A UN OBJETO DE LA CLASE ConfiguracionBDD
            ConfiguracionBDD config =
                JsonSerializer.Deserialize<ConfiguracionBDD>(json);

            // DEVUELVO LA CADENA CON LOS DATOS 
            return $"server={config.servidor}" +
                $";port={config.puerto}" +
                $";database={config.baseDatos}" +
                $";uid={config.usuario}" +
                $";pwd={config.clave};";
        }

        public static MySqlConnection crear_conexion()
        {
            string cadena_de_conexion = obtener_cadena_de_conexion();

            return new MySqlConnection(cadena_de_conexion);
        }
    }
}
