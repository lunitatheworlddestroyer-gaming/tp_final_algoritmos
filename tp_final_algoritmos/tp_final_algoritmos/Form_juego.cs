using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tp_final_algoritmos.modelos;

namespace tp_final_algoritmos
{
    public partial class Form_juego : Form
    {
        public modelos.Partida partida;
        public bool input = false;

        private void CargarImagenCarta(PictureBox pictureBox, string nombreCarta)
        {
            string rutaCarta = Path.Combine(Application.StartupPath, "assets", nombreCarta + ".png");
            if (!File.Exists(rutaCarta))
                rutaCarta = Path.Combine(Application.StartupPath, "assets", "carta_error.png");

            if (!File.Exists(rutaCarta))
            {
                pictureBox.Image = null;
                return;
            }

            try
            {
                using (var stream = File.OpenRead(rutaCarta))
                    pictureBox.Image = Image.FromStream(stream);
            }
            catch (IOException)
            {
                pictureBox.Image = null;
            }
            catch (ArgumentException)
            {
                pictureBox.Image = null;
            }
            catch (OutOfMemoryException)
            {
                pictureBox.Image = null;
            }
        }

        public void inicializar_ronda()
        {
            ttip_cartas.SetToolTip(pcb_0, partida.jugadores[0].mano[0].ToString());
            ttip_cartas.SetToolTip(pcb_1, partida.jugadores[0].mano[1].ToString());
            ttip_cartas.SetToolTip(pcb_2, partida.jugadores[0].mano[2].ToString());

            CargarImagenCarta(pcb_0, partida.jugadores[0].mano[0].ToString());
            CargarImagenCarta(pcb_1, partida.jugadores[0].mano[1].ToString());
            CargarImagenCarta(pcb_2, partida.jugadores[0].mano[2].ToString());
        }
        public void loop_juego(Partida p)
        {
            while (p.nosotros < p.puntos || p.ellos < p.puntos)
            {
                p.nueva_ronda();
                this.inicializar_ronda();
                while(p.ganador_ronda() == null)
                {
                    int id_turno = p.id_mano;
                    while(p.cartas_en_mesa.Count() < p.jugadores.Count())
                    {
                        if(id_turno == 0)
                        {
                            if (p.vuelta == 1)
                            {
                                btn_envido.Enabled = true;
                            }
                            else
                            {
                                btn_envido.Enabled = false;
                            }
                            btn_truco.Enabled = true;
                            while (!input)
                            {
                                Application.DoEvents();
                            }
                            if (p.nosotros < p.puntos || p.ellos < p.puntos)
                            {
                                break;
                            }
                            id_turno++;
                        }
                        else
                        {
                            btn_envido.Enabled = false;
                            btn_truco.Enabled = false;
                            //respuesta de bot
                            if (p.nosotros < p.puntos || p.ellos < p.puntos)
                            {
                                break;
                            }
                            if (id_turno < p.jugadores.Count())
                            {
                                id_turno = 0;
                            }
                            else
                            {
                                id_turno++;
                            }
                        }
                    }
                    if (p.nosotros < p.puntos || p.ellos < p.puntos)
                    {
                        break;
                    }
                    id_turno = p.ganador_carta();
                    if (p.vuelta == 1)
                    {
                        p.ganador_primera = p.jugadores[p.ganador_carta()].equipo;
                    }
                    if (p.vuelta == 2)
                    {
                        p.ganador_segunda = p.jugadores[p.ganador_carta()].equipo;
                    }
                    if (p.vuelta == 3)
                    {
                        p.ganador_tercera = p.jugadores[p.ganador_carta()].equipo;
                    }
                    p.cartas_en_mesa.Clear();
                    p.vuelta++;
                }
                if(p.ganador_ronda() == true)
                {
                    p.nosotros = p.nosotros + p.puntos_truco(p.truco);
                }
                else
                {
                    if (p.ganador_ronda() != null)
                    {
                        p.ellos = p.ellos + p.puntos_truco(p.truco);
                    }
                }

            }
        }
        public Form_juego(modelos.Partida Partida)
        {
            InitializeComponent();
            this.partida = Partida;
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
                DialogResult resultado = form_envido.ShowDialog();
                if (resultado == DialogResult.Yes)
                {
                    //quiso

                }
                if (resultado == DialogResult.Cancel)
                {
                    //no quiso

                }
                if (resultado == DialogResult.OK)
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
                DialogResult resultado = form_truco.ShowDialog();
                if (resultado == DialogResult.Cancel)
                {
                    //no quiso

                }
                if (resultado == DialogResult.Yes)
                {
                    //quiso
                }
                if (resultado == DialogResult.OK)
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
