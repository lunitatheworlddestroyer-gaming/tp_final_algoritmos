using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tp_final_algoritmos.ConexionBDD;

namespace tp_final_algoritmos
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_usuario.Text))
            {
                err_login.SetError(txt_usuario, "Para iniciar sesión ingrese su nombre de usuario, sino presione \"Jugar sin registrarse\"");
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txt_pass.Text))
                {
                    err_login.SetError(txt_pass, "Para iniciar sesión ingrese su contraseña");
                }
                else
                {
                    UsuariosDAO sesion = new UsuariosDAO();
                    if (sesion.inicio_sesion(txt_usuario.Text.Trim(), txt_pass.Text.Trim()))
                    {
                        modelos.Jugador_humano player = new modelos.Jugador_humano(txt_usuario.Text.Trim(), true);
                        Form_modo form_Modo = new Form_modo(player);
                        form_Modo.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("El nombre de usuario o la contraseña son incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_jugar_anonimo_Click(object sender, EventArgs e)
        {
            modelos.Jugador_humano player = new modelos.Jugador_humano("Anónimo", true);
            Form_modo form_Modo = new Form_modo(player);
            form_Modo.Show();
            this.Hide();
        }
    }
}
