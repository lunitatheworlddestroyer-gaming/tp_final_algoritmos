using System;
using System.Windows.Forms;
using tp_final_algoritmos.Enums;

namespace tp_final_algoritmos
{
    public partial class Form_envido : Form
    {
        bool modo;
        Envido envido;
        public modelos.Partida partida;
        public Form_envido(bool Modo, modelos.Partida Partida)
        {
            InitializeComponent();
            this.modo = Modo;
            this.partida = Partida;
            this.envido = partida.envido;

            // modo true si lo cante yo, false si me lo cantaron
            if (modo)
            {
                btn_quiero.Enabled = false;
                btn_no_quiero.Enabled = false;
                lbl_modo.Text = "¿Que tipo de envido vas a cantar?";
            }
            else
            {
                btn_cancelar.Enabled = false;
                switch (this.envido)
                {
                    case Envido.envido_envido:
                        this.Text = "Envido envido";
                        btn_envido.Enabled = false;
                        lbl_modo.Text = "Te respondieron envido envido";
                        break;

                    case Envido.envido_real_envido:
                        this.Text = "Envido real envido";
                        btn_envido.Enabled = false;
                        btn_real_envido.Enabled = false;
                        lbl_modo.Text = "Te respondieron real envido";
                        break;
                    case Envido.envido_envido_real_envido:
                        this.Text = "Envido envido real envido";
                        btn_envido.Enabled = false;
                        btn_real_envido.Enabled = false;
                        lbl_modo.Text = "Te respondieron real envido";
                        break;
                    case Envido.real_envido:
                        this.Text = "Real envido";
                        btn_envido.Enabled = false;
                        btn_real_envido.Enabled = false;
                        lbl_modo.Text = "Te cantaron real envido";
                        break;
                    case Envido.falta_envido:
                        this.Text = "Falta envido";
                        btn_envido.Enabled = false;
                        btn_real_envido.Enabled = false;
                        lbl_modo.Text = "Te cantaron falta envido";
                        break;
                    case Envido.envido_falta_envido:
                        this.Text = "Envido falta envido";
                        btn_envido.Enabled = false;
                        lbl_modo.Text = "Te respondieron falta envido";
                        break;
                    case Envido.envido_envido_falta_envido:
                        this.Text = "Envido envido falta envido";
                        btn_envido.Enabled = false;
                        lbl_modo.Text = "Te respondieron falta envido";
                        break;
                    case Envido.envido_real_envido_falta_envido:
                        this.Text = "Envido falta envido";
                        btn_envido.Enabled = false;
                        btn_real_envido.Enabled = false;
                        lbl_modo.Text = "Te respondieron falta envido";
                        break;
                    case Envido.envido_envido_real_envido_falta_envido:
                        this.Text = "Envido envido real envido falta envido";
                        btn_envido.Enabled = false;
                        btn_real_envido.Enabled = false;
                        lbl_modo.Text = "Te respondieron falta envido";
                        break;
                    case Envido.real_envido_falta_envido:
                        this.Text = "Real envido falta envido";
                        btn_envido.Enabled = false;
                        btn_real_envido.Enabled = false;
                        lbl_modo.Text = "Te respondieron falta envido";
                        break;

                }
            }
        }

        private void btn_envido_Click(object sender, EventArgs e)
        {
            if (modo)
            {
                partida.envido = Envido.envido;
            }
            if (envido == Envido.envido)
            {
                partida.envido = Envido.envido_envido;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_real_envido_Click(object sender, EventArgs e)
        {
            if (modo)
            {
                partida.envido = Envido.real_envido;
            }
            if (envido == Envido.envido)
            {
                partida.envido = Envido.envido_real_envido;
            }
            if (envido == Envido.envido_envido)
            {
                partida.envido = Envido.envido_envido_real_envido;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void lbl_modo_Click(object sender, EventArgs e)
        {

        }

        private void btn_quiero_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btn_no_quiero_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btn_falta_envido_Click(object sender, EventArgs e)
        {
            if (modo)
            {
                partida.envido = Envido.falta_envido;
            }
            if (envido == Envido.envido)
            {
                partida.envido = Envido.envido_falta_envido;
            }
            if (envido == Envido.envido_envido)
            {
                partida.envido = Envido.envido_envido_falta_envido;
            }
            if (envido == Envido.envido_real_envido)
            {
                partida.envido = Envido.envido_real_envido_falta_envido;
            }
            if (envido == Envido.envido_envido_real_envido)
            {
                partida.envido = Envido.envido_envido_real_envido_falta_envido;
            }
            if (envido == Envido.real_envido)
            {
                partida.envido = Envido.real_envido_falta_envido;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
