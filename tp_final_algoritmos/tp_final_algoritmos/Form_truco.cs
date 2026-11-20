using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tp_final_algoritmos.Enums;

namespace tp_final_algoritmos
{
    public partial class Form_truco : Form
    {
        Truco truco;
        public modelos.Partida partida;
        public Form_truco(modelos.Partida Partida)
        {
            InitializeComponent();
            this.partida = Partida;
            this.truco = partida.truco;
            switch (truco)
            {
                case Truco.no:
                    btn_subir.Enabled = false;
                    btn_quiero.Text = "Si";
                    btn_no_quiero.Text = "No";
                    break;
                case Truco.truco:
                    lbl_truco.Text = "Te cantaron truco";
                    break;
                case Truco.retruco:
                    lbl_truco.Text = "Te cantaron retruco";
                    btn_subir.Text = "Quiero vale 4";
                    break;
                case Truco.vale_4:
                    lbl_truco.Text = "Te respondieron quiero vale 4";
                    btn_subir.Text = "Quiero vale 4";
                    btn_subir.Enabled = false;
                    break;
            }   
            if (partida.truco == Truco.truco && partida.vuelta == 1)
            {
                btn_envido.Visible = true;
            }
        }

        private void Form_truco_Load(object sender, EventArgs e)
        {

        }

        private void btn_quiero_Click(object sender, EventArgs e)
        {
            if(partida.truco == Truco.no)
            {
                partida.truco = Truco.truco;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btn_no_quiero_Click(object sender, EventArgs e)
        {
            if (partida.truco == Truco.truco)
            {
                partida.truco = Truco.no;
            }
            if (partida.truco == Truco.retruco)
            {
                partida.truco = Truco.truco;
            }
            if (partida.truco == Truco.vale_4)
            {
                partida.truco = Truco.retruco;
            }
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btn_subir_Click(object sender, EventArgs e)
        {
            if (partida.truco == Truco.truco)
            {
                partida.truco = Truco.retruco;
            }
            if (partida.truco == Truco.retruco)
            {
                partida.truco = Truco.vale_4;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_envido_Click(object sender, EventArgs e)
        {
            using (Form_envido form_envido = new Form_envido(true, partida))
            {
                form_envido.ShowDialog();
            }
            partida.truco = Truco.no;
            this.DialogResult = DialogResult.OK;
        }
    }
}
