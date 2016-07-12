namespace unCuartoSMART
{
    partial class FormVentanaModificacionInfluencia
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_valor_ajuste = new System.Windows.Forms.TextBox();
            this.label_nombre_influencia = new System.Windows.Forms.Label();
            this.trackBar_valor_ajuste = new System.Windows.Forms.TrackBar();
            this.button_aceptar = new System.Windows.Forms.Button();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.button_limpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_valor_ajuste)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Valor ajuste influencia";
            // 
            // textBox_valor_ajuste
            // 
            this.textBox_valor_ajuste.Location = new System.Drawing.Point(197, 37);
            this.textBox_valor_ajuste.Name = "textBox_valor_ajuste";
            this.textBox_valor_ajuste.ReadOnly = true;
            this.textBox_valor_ajuste.Size = new System.Drawing.Size(100, 20);
            this.textBox_valor_ajuste.TabIndex = 1;
            // 
            // label_nombre_influencia
            // 
            this.label_nombre_influencia.AutoSize = true;
            this.label_nombre_influencia.Location = new System.Drawing.Point(57, 9);
            this.label_nombre_influencia.Name = "label_nombre_influencia";
            this.label_nombre_influencia.Size = new System.Drawing.Size(90, 13);
            this.label_nombre_influencia.TabIndex = 2;
            this.label_nombre_influencia.Text = "nombre influencia";
            // 
            // trackBar_valor_ajuste
            // 
            this.trackBar_valor_ajuste.Location = new System.Drawing.Point(12, 80);
            this.trackBar_valor_ajuste.Maximum = 20000;
            this.trackBar_valor_ajuste.Name = "trackBar_valor_ajuste";
            this.trackBar_valor_ajuste.Size = new System.Drawing.Size(469, 45);
            this.trackBar_valor_ajuste.TabIndex = 3;
            this.trackBar_valor_ajuste.Value = 10000;
            this.trackBar_valor_ajuste.Scroll += new System.EventHandler(this.trackBar_valor_ajuste_Scroll);
            // 
            // button_aceptar
            // 
            this.button_aceptar.Location = new System.Drawing.Point(106, 119);
            this.button_aceptar.Name = "button_aceptar";
            this.button_aceptar.Size = new System.Drawing.Size(117, 23);
            this.button_aceptar.TabIndex = 4;
            this.button_aceptar.Text = "Aceptar";
            this.button_aceptar.UseVisualStyleBackColor = true;
            this.button_aceptar.Click += new System.EventHandler(this.button_aceptar_Click);
            // 
            // button_cancelar
            // 
            this.button_cancelar.Location = new System.Drawing.Point(280, 119);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(117, 23);
            this.button_cancelar.TabIndex = 5;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // button_limpiar
            // 
            this.button_limpiar.Location = new System.Drawing.Point(339, 37);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(111, 20);
            this.button_limpiar.TabIndex = 6;
            this.button_limpiar.Text = "Limpiar ajuste";
            this.button_limpiar.UseVisualStyleBackColor = true;
            this.button_limpiar.Click += new System.EventHandler(this.button_limpiar_Click);
            // 
            // FormVentanaModificacionInfluencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 165);
            this.Controls.Add(this.button_limpiar);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.button_aceptar);
            this.Controls.Add(this.trackBar_valor_ajuste);
            this.Controls.Add(this.label_nombre_influencia);
            this.Controls.Add(this.textBox_valor_ajuste);
            this.Controls.Add(this.label1);
            this.Name = "FormVentanaModificacionInfluencia";
            this.Text = "FormVentanaModificacionInfluencia";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_valor_ajuste)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_valor_ajuste;
        private System.Windows.Forms.Label label_nombre_influencia;
        private System.Windows.Forms.TrackBar trackBar_valor_ajuste;
        private System.Windows.Forms.Button button_aceptar;
        private System.Windows.Forms.Button button_cancelar;
        private System.Windows.Forms.Button button_limpiar;
    }
}