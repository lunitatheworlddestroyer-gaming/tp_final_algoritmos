using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final_algoritmos.ConexionBDD
{
    // LA CLASE QUE RECIBE LA CONFIGURACION DE LA BASE DE DATOS DESDE EL ARCHIVO JSON
    public class ConfiguracionBDD
    {
        public string servidor { get; set; }
        public string puerto { get; set; }
        public string baseDatos { get; set; }
        public string usuario { get; set; }
        public string clave { get; set; }

    }

}
