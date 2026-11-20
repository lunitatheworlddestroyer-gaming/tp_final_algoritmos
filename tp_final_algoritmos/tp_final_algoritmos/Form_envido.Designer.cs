namespace tp_final_algoritmos
{
    partial class Form_envido
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
            this.components = new System.ComponentModel.Container();
            this.lbl_modo = new System.Windows.Forms.Label();
            this.btn_quiero = new System.Windows.Forms.Button();
            this.btn_no_quiero = new System.Windows.Forms.Button();
            this.btn_envido = new System.Windows.Forms.Button();
            this.btn_real_envido = new System.Windows.Forms.Button();
            this.btn_falta_envido = new System.Windows.Forms.Button();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_flor = new System.Windows.Forms.Button();
            this.ttip_truco = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // lbl_modo
            // 
            this.lbl_modo.AutoSize = true;
            this.lbl_modo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_modo.Location = new System.Drawing.Point(275, 72);
            this.lbl_modo.Name = "lbl_modo";
            this.lbl_modo.Size = new System.Drawing.Size(180, 25);
            this.lbl_modo.TabIndex = 0;
            this.lbl_modo.Text = "Te cantaron envido";
            this.lbl_modo.Click += new System.EventHandler(this.lbl_modo_Click);
            // 
            // btn_quiero
            // 
            this.btn_quiero.Location = new System.Drawing.Point(12, 192);
            this.btn_quiero.Name = "btn_quiero";
            this.btn_quiero.Size = new System.Drawing.Size(85, 45);
            this.btn_quiero.TabIndex = 1;
            this.btn_quiero.Text = "Quiero";
            this.btn_quiero.UseVisualStyleBackColor = true;
            this.btn_quiero.Click += new System.EventHandler(this.btn_quiero_Click);
            // 
            // btn_no_quiero
            // 
            this.btn_no_quiero.Location = new System.Drawing.Point(117, 192);
            this.btn_no_quiero.Name = "btn_no_quiero";
            this.btn_no_quiero.Size = new System.Drawing.Size(85, 45);
            this.btn_no_quiero.TabIndex = 2;
            this.btn_no_quiero.Text = "No quiero";
            this.btn_no_quiero.UseVisualStyleBackColor = true;
            this.btn_no_quiero.Click += new System.EventHandler(this.btn_no_quiero_Click);
            // 
            // btn_envido
            // 
            this.btn_envido.Location = new System.Drawing.Point(319, 192);
            this.btn_envido.Name = "btn_envido";
            this.btn_envido.Size = new System.Drawing.Size(85, 45);
            this.btn_envido.TabIndex = 3;
            this.btn_envido.Text = "Envido";
            this.btn_envido.UseVisualStyleBackColor = true;
            this.btn_envido.Click += new System.EventHandler(this.btn_envido_Click);
            // 
            // btn_real_envido
            // 
            this.btn_real_envido.Location = new System.Drawing.Point(422, 192);
            this.btn_real_envido.Name = "btn_real_envido";
            this.btn_real_envido.Size = new System.Drawing.Size(95, 45);
            this.btn_real_envido.TabIndex = 4;
            this.btn_real_envido.Text = "Real Envido";
            this.btn_real_envido.UseVisualStyleBackColor = true;
            this.btn_real_envido.Click += new System.EventHandler(this.btn_real_envido_Click);
            // 
            // btn_falta_envido
            // 
            this.btn_falta_envido.Location = new System.Drawing.Point(535, 192);
            this.btn_falta_envido.Name = "btn_falta_envido";
            this.btn_falta_envido.Size = new System.Drawing.Size(99, 45);
            this.btn_falta_envido.TabIndex = 5;
            this.btn_falta_envido.Text = "Falta envido";
            this.btn_falta_envido.UseVisualStyleBackColor = true;
            this.btn_falta_envido.Click += new System.EventHandler(this.btn_falta_envido_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.Location = new System.Drawing.Point(219, 192);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(85, 45);
            this.btn_cancelar.TabIndex = 6;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = true;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_flor
            // 
            this.btn_flor.Enabled = false;
            this.btn_flor.Location = new System.Drawing.Point(652, 192);
            this.btn_flor.Name = "btn_flor";
            this.btn_flor.Size = new System.Drawing.Size(85, 45);
            this.btn_flor.TabIndex = 7;
            this.btn_flor.Text = "Cantar Flor";
            this.btn_flor.UseVisualStyleBackColor = true;
            // 
            // ttip_truco
            // 
            this.ttip_truco.Popup += new System.Windows.Forms.PopupEventHandler(this.ttip_truco_Popup);
            // 
            // Form_envido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 253);
            this.Controls.Add(this.btn_flor);
            this.Controls.Add(this.btn_cancelar);
            this.Controls.Add(this.btn_falta_envido);
            this.Controls.Add(this.btn_real_envido);
            this.Controls.Add(this.btn_envido);
            this.Controls.Add(this.btn_no_quiero);
            this.Controls.Add(this.btn_quiero);
            this.Controls.Add(this.lbl_modo);
            this.Name = "Form_envido";
            this.Text = "Envido";
            this.Load += new System.EventHandler(this.Form_envido_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_modo;
        private System.Windows.Forms.Button btn_quiero;
        private System.Windows.Forms.Button btn_no_quiero;
        private System.Windows.Forms.Button btn_envido;
        private System.Windows.Forms.Button btn_real_envido;
        private System.Windows.Forms.Button btn_falta_envido;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Button btn_flor;
        private System.Windows.Forms.ToolTip ttip_truco;
    }
}