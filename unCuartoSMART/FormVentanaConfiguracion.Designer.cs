namespace unCuartoSMART
{
    partial class FormVentanaConfiguracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVentanaConfiguracion));
            this.imageList_estado = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox_estado_conexion_base_de_datos = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_conectar_bdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox_bdd_inicializada = new System.Windows.Forms.PictureBox();
            this.button_iniciar_bdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_limpiar_cola_de_analisis = new System.Windows.Forms.Button();
            this.button_limpiar_datos_matriz = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button_limpiar_influencias_forzadas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_estado_conexion_base_de_datos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_bdd_inicializada)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList_estado
            // 
            this.imageList_estado.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_estado.ImageStream")));
            this.imageList_estado.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_estado.Images.SetKeyName(0, "Cancel.png");
            this.imageList_estado.Images.SetKeyName(1, "Accept.png");
            // 
            // pictureBox_estado_conexion_base_de_datos
            // 
            this.pictureBox_estado_conexion_base_de_datos.Location = new System.Drawing.Point(186, 38);
            this.pictureBox_estado_conexion_base_de_datos.Name = "pictureBox_estado_conexion_base_de_datos";
            this.pictureBox_estado_conexion_base_de_datos.Size = new System.Drawing.Size(36, 36);
            this.pictureBox_estado_conexion_base_de_datos.TabIndex = 0;
            this.pictureBox_estado_conexion_base_de_datos.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Conexión base de datos :";
            // 
            // button_conectar_bdd
            // 
            this.button_conectar_bdd.Location = new System.Drawing.Point(260, 43);
            this.button_conectar_bdd.Name = "button_conectar_bdd";
            this.button_conectar_bdd.Size = new System.Drawing.Size(121, 23);
            this.button_conectar_bdd.TabIndex = 2;
            this.button_conectar_bdd.Text = "Comprobar conexión";
            this.button_conectar_bdd.UseVisualStyleBackColor = false;
            this.button_conectar_bdd.Click += new System.EventHandler(this.button_conectar_bdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Base de datos iniciada :";
            // 
            // pictureBox_bdd_inicializada
            // 
            this.pictureBox_bdd_inicializada.Location = new System.Drawing.Point(186, 85);
            this.pictureBox_bdd_inicializada.Name = "pictureBox_bdd_inicializada";
            this.pictureBox_bdd_inicializada.Size = new System.Drawing.Size(36, 36);
            this.pictureBox_bdd_inicializada.TabIndex = 5;
            this.pictureBox_bdd_inicializada.TabStop = false;
            // 
            // button_iniciar_bdd
            // 
            this.button_iniciar_bdd.Location = new System.Drawing.Point(260, 94);
            this.button_iniciar_bdd.Name = "button_iniciar_bdd";
            this.button_iniciar_bdd.Size = new System.Drawing.Size(121, 23);
            this.button_iniciar_bdd.TabIndex = 6;
            this.button_iniciar_bdd.Text = "Iniciar BDD";
            this.button_iniciar_bdd.UseVisualStyleBackColor = false;
            this.button_iniciar_bdd.Click += new System.EventHandler(this.button_iniciar_bdd_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button_iniciar_bdd);
            this.panel1.Controls.Add(this.pictureBox_estado_conexion_base_de_datos);
            this.panel1.Controls.Add(this.pictureBox_bdd_inicializada);
            this.panel1.Controls.Add(this.button_conectar_bdd);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(30, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(454, 163);
            this.panel1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Base de datos";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button_limpiar_influencias_forzadas);
            this.panel2.Controls.Add(this.button_limpiar_cola_de_analisis);
            this.panel2.Controls.Add(this.button_limpiar_datos_matriz);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(30, 206);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(454, 100);
            this.panel2.TabIndex = 8;
            // 
            // button_limpiar_cola_de_analisis
            // 
            this.button_limpiar_cola_de_analisis.Location = new System.Drawing.Point(131, 67);
            this.button_limpiar_cola_de_analisis.Name = "button_limpiar_cola_de_analisis";
            this.button_limpiar_cola_de_analisis.Size = new System.Drawing.Size(196, 23);
            this.button_limpiar_cola_de_analisis.TabIndex = 10;
            this.button_limpiar_cola_de_analisis.Text = "Limpiar cola de análisis";
            this.button_limpiar_cola_de_analisis.UseVisualStyleBackColor = false;
            // 
            // button_limpiar_datos_matriz
            // 
            this.button_limpiar_datos_matriz.Location = new System.Drawing.Point(34, 38);
            this.button_limpiar_datos_matriz.Name = "button_limpiar_datos_matriz";
            this.button_limpiar_datos_matriz.Size = new System.Drawing.Size(196, 23);
            this.button_limpiar_datos_matriz.TabIndex = 9;
            this.button_limpiar_datos_matriz.Text = "Limpiar datos matriz";
            this.button_limpiar_datos_matriz.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Modelo MBCIF";
            // 
            // button_limpiar_influencias_forzadas
            // 
            this.button_limpiar_influencias_forzadas.Location = new System.Drawing.Point(236, 38);
            this.button_limpiar_influencias_forzadas.Name = "button_limpiar_influencias_forzadas";
            this.button_limpiar_influencias_forzadas.Size = new System.Drawing.Size(196, 23);
            this.button_limpiar_influencias_forzadas.TabIndex = 11;
            this.button_limpiar_influencias_forzadas.Text = "Limpiar influencias forzadas Nodos";
            this.button_limpiar_influencias_forzadas.UseVisualStyleBackColor = false;
            // 
            // FormVentanaConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 347);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormVentanaConfiguracion";
            this.Text = "Configuración";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormVentanaConfiguracionBaseDeDatos_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_estado_conexion_base_de_datos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_bdd_inicializada)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList_estado;
        private System.Windows.Forms.PictureBox pictureBox_estado_conexion_base_de_datos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_conectar_bdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox_bdd_inicializada;
        private System.Windows.Forms.Button button_iniciar_bdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Button button_limpiar_cola_de_analisis;
        public System.Windows.Forms.Button button_limpiar_datos_matriz;
        public System.Windows.Forms.Button button_limpiar_influencias_forzadas;
    }
}