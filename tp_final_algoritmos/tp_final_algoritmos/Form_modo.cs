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
        public Form_modo()
        {
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
            Form_juego form_juego = new Form_juego();
            form_juego.Show();
            this.Hide();
        }
    }
}
