using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final_algoritmos.Enums
{
    public enum Tipo_canto
    {
        // ACCIONES DE JUEGO
        jugar_carta,
        irse_al_maso,

        // ACCIONES DE CANTO
        cantar_truco,
        cantar_re_truco,
        cantar_vale_cuatro,
        cantar_envido,
        cantar_real_envido,
        cantar_falta_envido,
        cantar_flor,
        cantar_contra_flor,

        // RESPUESTAS 

        quiero,
        no_quiero,
        

        // ACCIONES QUE PODRIA TOMAR EL BOT HACIA EL COMPAÑERO
        orden_jugar_carta_alta,
        orden_jugar_carta_baja,
        orden_cantar_truco,
        orden_cantar_tanto, // aca se puede tomar como referencia el valor envido y ver si conviene cantar envido,real o la falta
        orden_irse_al_maso,
        orden_juga_libre
        

    }
}
