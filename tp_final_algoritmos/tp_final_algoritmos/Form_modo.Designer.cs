namespace tp_final_algoritmos
{
    partial class Form_modo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_jugar = new System.Windows.Forms.Button();
            this.cbo_cant_jugadores = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rb_15p = new System.Windows.Forms.RadioButton();
            this.rb_30p = new System.Windows.Forms.RadioButton();
            this.chk_oloroso = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_jugar
            // 
            this.btn_jugar.Location = new System.Drawing.Point(230, 374);
            this.btn_jugar.Name = "btn_jugar";
            this.btn_jugar.Size = new System.Drawing.Size(294, 40);
            this.btn_jugar.TabIndex = 0;
            this.btn_jugar.Text = "Iniciar partida";
            this.btn_jugar.UseVisualStyleBackColor = true;
            this.btn_jugar.Click += new System.EventHandler(this.btn_jugar_Click);
            // 
            // cbo_cant_jugadores
            // 
            this.cbo_cant_jugadores.AutoCompleteCustomSource.AddRange(new string[] {
            "1 vs 1",
            "2 vs 2",
            "3 vs 3"});
            this.cbo_cant_jugadores.FormattingEnabled = true;
            this.cbo_cant_jugadores.Location = new System.Drawing.Point(230, 35);
            this.cbo_cant_jugadores.Name = "cbo_cant_jugadores";
            this.cbo_cant_jugadores.Size = new System.Drawing.Size(294, 24);
            this.cbo_cant_jugadores.TabIndex = 1;
            this.cbo_cant_jugadores.Text = "Modo de juego";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(158, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hasta:";
            // 
            // rb_15p
            // 
            this.rb_15p.AutoSize = true;
            this.rb_15p.Location = new System.Drawing.Point(301, 91);
            this.rb_15p.Name = "rb_15p";
            this.rb_15p.Size = new System.Drawing.Size(85, 20);
            this.rb_15p.TabIndex = 3;
            this.rb_15p.Text = "15 puntos";
            this.rb_15p.UseVisualStyleBackColor = true;
            this.rb_15p.CheckedChanged += new System.EventHandler(this.rb_15p_CheckedChanged);
            // 
            // rb_30p
            // 
            this.rb_30p.AutoSize = true;
            this.rb_30p.Checked = true;
            this.rb_30p.Location = new System.Drawing.Point(472, 91);
            this.rb_30p.Name = "rb_30p";
            this.rb_30p.Size = new System.Drawing.Size(85, 20);
            this.rb_30p.TabIndex = 4;
            this.rb_30p.TabStop = true;
            this.rb_30p.Text = "30 puntos";
            this.rb_30p.UseVisualStyleBackColor = true;
            // 
            // chk_oloroso
            // 
            this.chk_oloroso.AutoSize = true;
            this.chk_oloroso.Enabled = false;
            this.chk_oloroso.Location = new System.Drawing.Point(314, 154);
            this.chk_oloroso.Name = "chk_oloroso";
            this.chk_oloroso.Size = new System.Drawing.Size(52, 20);
            this.chk_oloroso.TabIndex = 5;
            this.chk_oloroso.Text = "Flor";
            this.chk_oloroso.UseVisualStyleBackColor = true;
            // 
            // Form_modo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chk_oloroso);
            this.Controls.Add(this.rb_30p);
            this.Controls.Add(this.rb_15p);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbo_cant_jugadores);
            this.Controls.Add(this.btn_jugar);
            this.Name = "Form_modo";
            this.Text = "Form_modo";
            this.Load += new System.EventHandler(this.Form_modo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_jugar;
        private System.Windows.Forms.ComboBox cbo_cant_jugadores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rb_15p;
        private System.Windows.Forms.RadioButton rb_30p;
        private System.Windows.Forms.CheckBox chk_oloroso;
    }
}