using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tp_final_algoritmos
{
    public partial class Form_modo : Form
    {
        public modelos.Jugador_humano player;
        public Form_modo(modelos.Jugador_humano Player)
        {
            this.player = Player;
            InitializeComponent();
        }

        private void Form_modo_Load(object sender, EventArgs e)
        {

        }
        private void Form_modo_FormClosing(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rb_15p_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn_jugar_Click(object sender, EventArgs e)
        {
            if (player == null)
            {
                MessageBox.Show("No se pudo iniciar la partida porque el jugador no está inicializado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbo_cant_partidas.SelectedIndex == -1)
            {
                err_modo.SetError(cbo_cant_partidas, "Para continuar, debe elegir el modo de juego");
            }
            else
            {
                if (cbo_cant_j.SelectedIndex == -1)
                {
                    err_modo.SetError(cbo_cant_j, "Para continuar, debe elegir la cantidad de jugadores");
                }
                else
                {
                    int c=0;
                    int p;
                    Enums.Modo_partida modo;
                    switch (cbo_cant_j.SelectedIndex)
                    {
                        case 0:
                            c = 2;
                        break;
                        case 1:
                            c = 4;
                        break;
                        case 2:
                            c = 6;
                        break;

                    }
                    if (rb_15p.Checked) { p = 15; }
                    else { p = 30; }
                    if (cbo_cant_partidas.SelectedIndex == 0) {modo = Enums.Modo_partida.simple; }
                    else { modo = Enums.Modo_partida.torneo; }
                    modelos.Partida partida = new modelos.Partida(c, p, modo, player);
                    Form_juego form_juego = new Form_juego(partida);
                    form_juego.Show();
                    this.Hide();
                
                }
            }
        }
    }
}
