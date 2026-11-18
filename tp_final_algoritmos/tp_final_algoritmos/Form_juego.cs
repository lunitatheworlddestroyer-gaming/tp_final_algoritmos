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
    public partial class Form_juego : Form
    {
        public modelos.Partida partida;
        public Form_juego(modelos.Partida Partida)
        {
            this.partida = Partida;
            InitializeComponent();
            if (partida.cant_jugadores == 2)
            {
                pcb_bot2_0.Visible = false;
                pcb_bot2_1.Visible = false;
                pcb_bot2_2.Visible = false;
                pcb_bot3_0.Visible = false;
                pcb_bot3_1.Visible = false;
                pcb_bot3_2.Visible = false;
                pcb_bot4_0.Visible = false;
                pcb_bot4_1.Visible = false;
                pcb_bot4_2.Visible = false;
                pcb_bot5_0.Visible = false;
                pcb_bot5_1.Visible = false;
                pcb_bot5_2.Visible = false;
                lbl_jugador.Text = partida.jugadores[0].nombre;
                lbl_bot1.Text = partida.jugadores[1].nombre;
                lbl_bot2.Visible = false;
                lbl_bot3.Visible = false;
                lbl_bot4.Visible = false;
                lbl_bot5.Visible = false;
            }
            if (partida.cant_jugadores == 4)
            {
                pcb_bot4_0.Visible = false;
                pcb_bot4_1.Visible = false;
                pcb_bot4_2.Visible = false;
                pcb_bot5_0.Visible = false;
                pcb_bot5_1.Visible = false;
                pcb_bot5_2.Visible = false;
                pcb_bot2_0.Top = 230;
                pcb_bot2_1.Top = 363;
                pcb_bot2_2.Top = 500;
                pcb_bot3_0.Top = 230;
                pcb_bot3_1.Top = 363;
                pcb_bot3_2.Top = 500;
                lbl_bot2.Top = 400;
                lbl_bot3.Top = 400;
                lbl_jugador.Text = partida.jugadores[0].nombre;
                lbl_bot2.Text = partida.jugadores[1].nombre;
                lbl_bot1.Text = partida.jugadores[2].nombre;
                lbl_bot3.Text = partida.jugadores[3].nombre;
                lbl_bot4.Visible = false;
                lbl_bot5.Visible = false;
            }
            if (partida.cant_jugadores == 6)
            {
                lbl_jugador.Text = partida.jugadores[0].nombre;
                lbl_bot4.Text = partida.jugadores[1].nombre;
                lbl_bot2.Text = partida.jugadores[2].nombre;
                lbl_bot1.Text = partida.jugadores[3].nombre;
                lbl_bot3.Text = partida.jugadores[4].nombre;
                lbl_bot5.Text = partida.jugadores[5].nombre;
            }
        }

        private void Form_juego_Load(object sender, EventArgs e)
        {

        }
        private void Form_juego_FormClosing(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_envido_Click(object sender, EventArgs e)
        {
            using (Form_envido form_envido = new Form_envido(true, partida))
            {
                if (form_envido.ShowDialog() == DialogResult.Yes)
                {
                    //quiso

                }
                if (form_envido.ShowDialog() == DialogResult.Cancel)
                {
                    //no quiso

                }
                if (form_envido.ShowDialog() == DialogResult.OK)
                {
                    //otras opciones
                    this.partida = form_envido.partida;
                }
            }
        }

        private void btn_truco_Click(object sender, EventArgs e)
        {
            using (Form_truco form_truco = new Form_truco(partida))
            {
                if (form_truco.ShowDialog() == DialogResult.Cancel)
                {
                    //no quiso

                }
                if (form_truco.ShowDialog() == DialogResult.Yes)
                {
                    //quiso
                }
                if (form_truco.ShowDialog() == DialogResult.OK)
                {
                    //otras opciones
                    this.partida = form_truco.partida;
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void btn_mazo_Click(object sender, EventArgs e)
        {
            DialogResult mazo = MessageBox.Show("¿Seguro que querés ir al mazo?", "Ir al mazo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (mazo == DialogResult.Yes) 
            { 
                this.partida.nueva_ronda(); 
            }
        }
    }
}
