namespace unCuartoSMART
{
    partial class FormVentanaIngresoDatos
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
            this.button_aceptar = new System.Windows.Forms.Button();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_campos = new System.Windows.Forms.Panel();
            this.panel_influencia_externa_forzada = new System.Windows.Forms.Panel();
            this.button_limpiar_influencia_externa = new System.Windows.Forms.Button();
            this.textBox_influencia_externa_forzada = new System.Windows.Forms.TextBox();
            this.trackBar_influencia_externa_forzada = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel_campos.SuspendLayout();
            this.panel_influencia_externa_forzada.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_influencia_externa_forzada)).BeginInit();
            this.SuspendLayout();
            // 
            // button_aceptar
            // 
            this.button_aceptar.Location = new System.Drawing.Point(107, 14);
            this.button_aceptar.Name = "button_aceptar";
            this.button_aceptar.Size = new System.Drawing.Size(111, 23);
            this.button_aceptar.TabIndex = 2;
            this.button_aceptar.Text = "Aceptar";
            this.button_aceptar.UseVisualStyleBackColor = true;
            this.button_aceptar.Click += new System.EventHandler(this.button_aceptar_Click);
            // 
            // button_cancelar
            // 
            this.button_cancelar.Location = new System.Drawing.Point(267, 14);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(127, 23);
            this.button_cancelar.TabIndex = 3;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel_campos, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(530, 356);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_cancelar);
            this.panel1.Controls.Add(this.button_aceptar);
            this.panel1.Location = new System.Drawing.Point(3, 289);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(524, 64);
            this.panel1.TabIndex = 0;
            // 
            // panel_campos
            // 
            this.panel_campos.AutoScroll = true;
            this.panel_campos.Controls.Add(this.panel_influencia_externa_forzada);
            this.panel_campos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_campos.Location = new System.Drawing.Point(3, 3);
            this.panel_campos.Name = "panel_campos";
            this.panel_campos.Size = new System.Drawing.Size(524, 280);
            this.panel_campos.TabIndex = 1;
            // 
            // panel_influencia_externa_forzada
            // 
            this.panel_influencia_externa_forzada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_influencia_externa_forzada.Controls.Add(this.button_limpiar_influencia_externa);
            this.panel_influencia_externa_forzada.Controls.Add(this.textBox_influencia_externa_forzada);
            this.panel_influencia_externa_forzada.Controls.Add(this.trackBar_influencia_externa_forzada);
            this.panel_influencia_externa_forzada.Controls.Add(this.label1);
            this.panel_influencia_externa_forzada.Location = new System.Drawing.Point(3, 184);
            this.panel_influencia_externa_forzada.Name = "panel_influencia_externa_forzada";
            this.panel_influencia_externa_forzada.Size = new System.Drawing.Size(512, 93);
            this.panel_influencia_externa_forzada.TabIndex = 0;
            // 
            // button_limpiar_influencia_externa
            // 
            this.button_limpiar_influencia_externa.Location = new System.Drawing.Point(340, 15);
            this.button_limpiar_influencia_externa.Name = "button_limpiar_influencia_externa";
            this.button_limpiar_influencia_externa.Size = new System.Drawing.Size(145, 23);
            this.button_limpiar_influencia_externa.TabIndex = 3;
            this.button_limpiar_influencia_externa.Text = "Limpiar influencia";
            this.button_limpiar_influencia_externa.UseVisualStyleBackColor = true;
            this.button_limpiar_influencia_externa.Click += new System.EventHandler(this.button_limpiar_influencia_externa_Click);
            // 
            // textBox_influencia_externa_forzada
            // 
            this.textBox_influencia_externa_forzada.Enabled = false;
            this.textBox_influencia_externa_forzada.Location = new System.Drawing.Point(187, 15);
            this.textBox_influencia_externa_forzada.Name = "textBox_influencia_externa_forzada";
            this.textBox_influencia_externa_forzada.Size = new System.Drawing.Size(90, 20);
            this.textBox_influencia_externa_forzada.TabIndex = 2;
            this.textBox_influencia_externa_forzada.Text = "0";
            this.textBox_influencia_externa_forzada.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // trackBar_influencia_externa_forzada
            // 
            this.trackBar_influencia_externa_forzada.LargeChange = 50;
            this.trackBar_influencia_externa_forzada.Location = new System.Drawing.Point(25, 41);
            this.trackBar_influencia_externa_forzada.Maximum = 1000;
            this.trackBar_influencia_externa_forzada.Minimum = -1000;
            this.trackBar_influencia_externa_forzada.Name = "trackBar_influencia_externa_forzada";
            this.trackBar_influencia_externa_forzada.Size = new System.Drawing.Size(474, 45);
            this.trackBar_influencia_externa_forzada.TabIndex = 1;
            this.trackBar_influencia_externa_forzada.ValueChanged += new System.EventHandler(this.trackBar_influencia_externa_forzada_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Influencia externa forzada";
            // 
            // FormVentanaIngresoDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 356);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormVentanaIngresoDatos";
            this.Text = "Modificación de datos Nodo \"XXXX\"";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel_campos.ResumeLayout(false);
            this.panel_influencia_externa_forzada.ResumeLayout(false);
            this.panel_influencia_externa_forzada.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_influencia_externa_forzada)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_aceptar;
        private System.Windows.Forms.Button button_cancelar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel_campos;
        private System.Windows.Forms.Panel panel_influencia_externa_forzada;
        private System.Windows.Forms.Button button_limpiar_influencia_externa;
        private System.Windows.Forms.TextBox textBox_influencia_externa_forzada;
        private System.Windows.Forms.TrackBar trackBar_influencia_externa_forzada;
        private System.Windows.Forms.Label label1;
    }
}