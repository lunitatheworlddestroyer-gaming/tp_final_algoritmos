namespace tp_final_algoritmos
{
    partial class Form_truco
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
            this.lbl_truco = new System.Windows.Forms.Label();
            this.btn_quiero = new System.Windows.Forms.Button();
            this.btn_no_quiero = new System.Windows.Forms.Button();
            this.btn_subir = new System.Windows.Forms.Button();
            this.btn_envido = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_truco
            // 
            this.lbl_truco.AutoSize = true;
            this.lbl_truco.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_truco.Location = new System.Drawing.Point(218, 83);
            this.lbl_truco.Name = "lbl_truco";
            this.lbl_truco.Size = new System.Drawing.Size(142, 25);
            this.lbl_truco.TabIndex = 0;
            this.lbl_truco.Text = "¿Cantar truco?";
            // 
            // btn_quiero
            // 
            this.btn_quiero.Location = new System.Drawing.Point(24, 245);
            this.btn_quiero.Name = "btn_quiero";
            this.btn_quiero.Size = new System.Drawing.Size(160, 47);
            this.btn_quiero.TabIndex = 1;
            this.btn_quiero.Text = "Quiero";
            this.btn_quiero.UseVisualStyleBackColor = true;
            this.btn_quiero.Click += new System.EventHandler(this.btn_quiero_Click);
            // 
            // btn_no_quiero
            // 
            this.btn_no_quiero.Location = new System.Drawing.Point(210, 245);
            this.btn_no_quiero.Name = "btn_no_quiero";
            this.btn_no_quiero.Size = new System.Drawing.Size(160, 47);
            this.btn_no_quiero.TabIndex = 2;
            this.btn_no_quiero.Text = "No quiero";
            this.btn_no_quiero.UseVisualStyleBackColor = true;
            this.btn_no_quiero.Click += new System.EventHandler(this.btn_no_quiero_Click);
            // 
            // btn_subir
            // 
            this.btn_subir.Location = new System.Drawing.Point(390, 245);
            this.btn_subir.Name = "btn_subir";
            this.btn_subir.Size = new System.Drawing.Size(160, 47);
            this.btn_subir.TabIndex = 3;
            this.btn_subir.Text = "Retruco";
            this.btn_subir.UseVisualStyleBackColor = true;
            this.btn_subir.Click += new System.EventHandler(this.btn_subir_Click);
            // 
            // btn_envido
            // 
            this.btn_envido.Location = new System.Drawing.Point(24, 181);
            this.btn_envido.Name = "btn_envido";
            this.btn_envido.Size = new System.Drawing.Size(525, 42);
            this.btn_envido.TabIndex = 4;
            this.btn_envido.Text = "Primero se dice envido";
            this.btn_envido.UseVisualStyleBackColor = true;
            this.btn_envido.Visible = false;
            this.btn_envido.Click += new System.EventHandler(this.btn_envido_Click);
            // 
            // Form_truco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 312);
            this.Controls.Add(this.btn_envido);
            this.Controls.Add(this.btn_subir);
            this.Controls.Add(this.btn_no_quiero);
            this.Controls.Add(this.btn_quiero);
            this.Controls.Add(this.lbl_truco);
            this.Name = "Form_truco";
            this.Text = "Truco";
            this.Load += new System.EventHandler(this.Form_truco_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_truco;
        private System.Windows.Forms.Button btn_quiero;
        private System.Windows.Forms.Button btn_no_quiero;
        private System.Windows.Forms.Button btn_subir;
        private System.Windows.Forms.Button btn_envido;
    }
}