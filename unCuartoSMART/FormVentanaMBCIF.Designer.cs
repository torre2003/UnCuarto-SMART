namespace unCuartoSMART
{
    partial class FormVentanaMBCIF
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
            this.tableLayoutPanel_principal = new System.Windows.Forms.TableLayoutPanel();
            this.panel_datos = new System.Windows.Forms.Panel();
            this.button_modificar_ajuste_influencia = new System.Windows.Forms.Button();
            this.radioButton_sistema = new System.Windows.Forms.RadioButton();
            this.radioButton_influencia = new System.Windows.Forms.RadioButton();
            this.radioButton_nodo = new System.Windows.Forms.RadioButton();
            this.button_modificar_nodo = new System.Windows.Forms.Button();
            this.textBox_informacion_elementos = new System.Windows.Forms.TextBox();
            this.button_buscar = new System.Windows.Forms.Button();
            this.textBox_id_buscada = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_vizor = new System.Windows.Forms.Panel();
            this.button_disminuir = new System.Windows.Forms.Button();
            this.button_aumentar = new System.Windows.Forms.Button();
            this.pictureBox_imagen = new System.Windows.Forms.PictureBox();
            this.panel_controles = new System.Windows.Forms.Panel();
            this.progressBar_proceso_iterativo = new System.Windows.Forms.ProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown_intervalo_de_guardado_de_datos = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_actualizacion_inmediata_nodos = new System.Windows.Forms.CheckBox();
            this.numericUpDown_numero_de_iteraciones = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.radioButton_iterar_paso_a_paso = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButton_iterar_todo_a_la_vez = new System.Windows.Forms.RadioButton();
            this.numericUpDown_tiempo_entre_iteracion = new System.Windows.Forms.NumericUpDown();
            this.button_iniciar_iteracion = new System.Windows.Forms.Button();
            this.tableLayoutPanel_principal.SuspendLayout();
            this.panel_datos.SuspendLayout();
            this.panel_vizor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_imagen)).BeginInit();
            this.panel_controles.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_intervalo_de_guardado_de_datos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_numero_de_iteraciones)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_tiempo_entre_iteracion)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_principal
            // 
            this.tableLayoutPanel_principal.ColumnCount = 2;
            this.tableLayoutPanel_principal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_principal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_principal.Controls.Add(this.panel_datos, 0, 0);
            this.tableLayoutPanel_principal.Controls.Add(this.panel_vizor, 1, 0);
            this.tableLayoutPanel_principal.Controls.Add(this.panel_controles, 1, 1);
            this.tableLayoutPanel_principal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_principal.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_principal.Name = "tableLayoutPanel_principal";
            this.tableLayoutPanel_principal.RowCount = 2;
            this.tableLayoutPanel_principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel_principal.Size = new System.Drawing.Size(850, 612);
            this.tableLayoutPanel_principal.TabIndex = 0;
            // 
            // panel_datos
            // 
            this.panel_datos.AutoScroll = true;
            this.panel_datos.AutoSize = true;
            this.panel_datos.Controls.Add(this.button_modificar_ajuste_influencia);
            this.panel_datos.Controls.Add(this.radioButton_sistema);
            this.panel_datos.Controls.Add(this.radioButton_influencia);
            this.panel_datos.Controls.Add(this.radioButton_nodo);
            this.panel_datos.Controls.Add(this.button_modificar_nodo);
            this.panel_datos.Controls.Add(this.textBox_informacion_elementos);
            this.panel_datos.Controls.Add(this.button_buscar);
            this.panel_datos.Controls.Add(this.textBox_id_buscada);
            this.panel_datos.Controls.Add(this.label1);
            this.panel_datos.Location = new System.Drawing.Point(3, 3);
            this.panel_datos.Name = "panel_datos";
            this.tableLayoutPanel_principal.SetRowSpan(this.panel_datos, 2);
            this.panel_datos.Size = new System.Drawing.Size(291, 606);
            this.panel_datos.TabIndex = 0;
            // 
            // button_modificar_ajuste_influencia
            // 
            this.button_modificar_ajuste_influencia.Enabled = false;
            this.button_modificar_ajuste_influencia.Location = new System.Drawing.Point(21, 580);
            this.button_modificar_ajuste_influencia.Name = "button_modificar_ajuste_influencia";
            this.button_modificar_ajuste_influencia.Size = new System.Drawing.Size(267, 23);
            this.button_modificar_ajuste_influencia.TabIndex = 9;
            this.button_modificar_ajuste_influencia.Text = "Modificar Ajuste Influencia";
            this.button_modificar_ajuste_influencia.UseVisualStyleBackColor = true;
            this.button_modificar_ajuste_influencia.Click += new System.EventHandler(this.button_modificar_ajuste_influencia_Click);
            // 
            // radioButton_sistema
            // 
            this.radioButton_sistema.AutoSize = true;
            this.radioButton_sistema.Location = new System.Drawing.Point(200, 56);
            this.radioButton_sistema.Name = "radioButton_sistema";
            this.radioButton_sistema.Size = new System.Drawing.Size(62, 17);
            this.radioButton_sistema.TabIndex = 8;
            this.radioButton_sistema.Text = "Sistema";
            this.radioButton_sistema.UseVisualStyleBackColor = true;
            this.radioButton_sistema.CheckedChanged += new System.EventHandler(this.radioButton_sistema_CheckedChanged);
            // 
            // radioButton_influencia
            // 
            this.radioButton_influencia.AutoSize = true;
            this.radioButton_influencia.Location = new System.Drawing.Point(105, 56);
            this.radioButton_influencia.Name = "radioButton_influencia";
            this.radioButton_influencia.Size = new System.Drawing.Size(71, 17);
            this.radioButton_influencia.TabIndex = 7;
            this.radioButton_influencia.Text = "Influencia";
            this.radioButton_influencia.UseVisualStyleBackColor = true;
            this.radioButton_influencia.CheckedChanged += new System.EventHandler(this.radioButton_influencia_CheckedChanged);
            // 
            // radioButton_nodo
            // 
            this.radioButton_nodo.AutoSize = true;
            this.radioButton_nodo.Checked = true;
            this.radioButton_nodo.Location = new System.Drawing.Point(21, 55);
            this.radioButton_nodo.Name = "radioButton_nodo";
            this.radioButton_nodo.Size = new System.Drawing.Size(51, 17);
            this.radioButton_nodo.TabIndex = 6;
            this.radioButton_nodo.TabStop = true;
            this.radioButton_nodo.Text = "Nodo";
            this.radioButton_nodo.UseVisualStyleBackColor = true;
            this.radioButton_nodo.CheckedChanged += new System.EventHandler(this.radioButton_nodo_CheckedChanged);
            // 
            // button_modificar_nodo
            // 
            this.button_modificar_nodo.Enabled = false;
            this.button_modificar_nodo.Location = new System.Drawing.Point(21, 554);
            this.button_modificar_nodo.Name = "button_modificar_nodo";
            this.button_modificar_nodo.Size = new System.Drawing.Size(267, 23);
            this.button_modificar_nodo.TabIndex = 5;
            this.button_modificar_nodo.Text = "Modificar informacion Nodo";
            this.button_modificar_nodo.UseVisualStyleBackColor = true;
            this.button_modificar_nodo.Click += new System.EventHandler(this.button_modificar_nodo_Click);
            // 
            // textBox_informacion_elementos
            // 
            this.textBox_informacion_elementos.Location = new System.Drawing.Point(21, 79);
            this.textBox_informacion_elementos.Multiline = true;
            this.textBox_informacion_elementos.Name = "textBox_informacion_elementos";
            this.textBox_informacion_elementos.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_informacion_elementos.Size = new System.Drawing.Size(267, 469);
            this.textBox_informacion_elementos.TabIndex = 3;
            // 
            // button_buscar
            // 
            this.button_buscar.Location = new System.Drawing.Point(169, 27);
            this.button_buscar.Name = "button_buscar";
            this.button_buscar.Size = new System.Drawing.Size(93, 23);
            this.button_buscar.TabIndex = 2;
            this.button_buscar.Text = "Buscar";
            this.button_buscar.UseVisualStyleBackColor = true;
            this.button_buscar.Click += new System.EventHandler(this.button_buscar_Click);
            // 
            // textBox_id_buscada
            // 
            this.textBox_id_buscada.Location = new System.Drawing.Point(63, 29);
            this.textBox_id_buscada.Name = "textBox_id_buscada";
            this.textBox_id_buscada.Size = new System.Drawing.Size(100, 20);
            this.textBox_id_buscada.TabIndex = 1;
            this.textBox_id_buscada.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_id_buscada_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id";
            // 
            // panel_vizor
            // 
            this.panel_vizor.AutoScroll = true;
            this.panel_vizor.BackColor = System.Drawing.Color.White;
            this.panel_vizor.Controls.Add(this.button_disminuir);
            this.panel_vizor.Controls.Add(this.button_aumentar);
            this.panel_vizor.Controls.Add(this.pictureBox_imagen);
            this.panel_vizor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_vizor.Location = new System.Drawing.Point(300, 3);
            this.panel_vizor.Name = "panel_vizor";
            this.panel_vizor.Size = new System.Drawing.Size(547, 406);
            this.panel_vizor.TabIndex = 1;
            // 
            // button_disminuir
            // 
            this.button_disminuir.Location = new System.Drawing.Point(17, 70);
            this.button_disminuir.Name = "button_disminuir";
            this.button_disminuir.Size = new System.Drawing.Size(28, 23);
            this.button_disminuir.TabIndex = 2;
            this.button_disminuir.Text = "-";
            this.button_disminuir.UseVisualStyleBackColor = true;
            this.button_disminuir.Click += new System.EventHandler(this.button_disminuir_Click);
            // 
            // button_aumentar
            // 
            this.button_aumentar.Location = new System.Drawing.Point(17, 27);
            this.button_aumentar.Name = "button_aumentar";
            this.button_aumentar.Size = new System.Drawing.Size(28, 23);
            this.button_aumentar.TabIndex = 1;
            this.button_aumentar.Text = "+";
            this.button_aumentar.UseVisualStyleBackColor = true;
            this.button_aumentar.Click += new System.EventHandler(this.button_aumentar_Click);
            // 
            // pictureBox_imagen
            // 
            this.pictureBox_imagen.Location = new System.Drawing.Point(0, 0);
            this.pictureBox_imagen.Name = "pictureBox_imagen";
            this.pictureBox_imagen.Size = new System.Drawing.Size(100, 50);
            this.pictureBox_imagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_imagen.TabIndex = 0;
            this.pictureBox_imagen.TabStop = false;
            // 
            // panel_controles
            // 
            this.panel_controles.AutoScroll = true;
            this.panel_controles.AutoSize = true;
            this.panel_controles.BackColor = System.Drawing.Color.Transparent;
            this.panel_controles.Controls.Add(this.progressBar_proceso_iterativo);
            this.panel_controles.Controls.Add(this.panel2);
            this.panel_controles.Controls.Add(this.panel1);
            this.panel_controles.Controls.Add(this.button_iniciar_iteracion);
            this.panel_controles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_controles.Location = new System.Drawing.Point(300, 415);
            this.panel_controles.Name = "panel_controles";
            this.panel_controles.Size = new System.Drawing.Size(547, 194);
            this.panel_controles.TabIndex = 2;
            // 
            // progressBar_proceso_iterativo
            // 
            this.progressBar_proceso_iterativo.Location = new System.Drawing.Point(17, 168);
            this.progressBar_proceso_iterativo.Name = "progressBar_proceso_iterativo";
            this.progressBar_proceso_iterativo.Size = new System.Drawing.Size(521, 23);
            this.progressBar_proceso_iterativo.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.numericUpDown_intervalo_de_guardado_de_datos);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.checkBox_actualizacion_inmediata_nodos);
            this.panel2.Controls.Add(this.numericUpDown_numero_de_iteraciones);
            this.panel2.Location = new System.Drawing.Point(17, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(521, 88);
            this.panel2.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(254, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(158, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Intervalo de guardado de datos ";
            // 
            // numericUpDown_intervalo_de_guardado_de_datos
            // 
            this.numericUpDown_intervalo_de_guardado_de_datos.Location = new System.Drawing.Point(418, 30);
            this.numericUpDown_intervalo_de_guardado_de_datos.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown_intervalo_de_guardado_de_datos.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_intervalo_de_guardado_de_datos.Name = "numericUpDown_intervalo_de_guardado_de_datos";
            this.numericUpDown_intervalo_de_guardado_de_datos.Size = new System.Drawing.Size(85, 20);
            this.numericUpDown_intervalo_de_guardado_de_datos.TabIndex = 12;
            this.numericUpDown_intervalo_de_guardado_de_datos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_intervalo_de_guardado_de_datos.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_intervalo_de_guardado_de_datos.ValueChanged += new System.EventHandler(this.numericUpDown_intervalo_de_guardado_de_datos_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Opciones de proceso";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Número de iteraciones";
            // 
            // checkBox_actualizacion_inmediata_nodos
            // 
            this.checkBox_actualizacion_inmediata_nodos.AutoSize = true;
            this.checkBox_actualizacion_inmediata_nodos.Location = new System.Drawing.Point(6, 56);
            this.checkBox_actualizacion_inmediata_nodos.Name = "checkBox_actualizacion_inmediata_nodos";
            this.checkBox_actualizacion_inmediata_nodos.Size = new System.Drawing.Size(241, 17);
            this.checkBox_actualizacion_inmediata_nodos.TabIndex = 10;
            this.checkBox_actualizacion_inmediata_nodos.Text = "Actualización inmediata del nodo influenciado";
            this.checkBox_actualizacion_inmediata_nodos.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_numero_de_iteraciones
            // 
            this.numericUpDown_numero_de_iteraciones.Location = new System.Drawing.Point(122, 30);
            this.numericUpDown_numero_de_iteraciones.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown_numero_de_iteraciones.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown_numero_de_iteraciones.Name = "numericUpDown_numero_de_iteraciones";
            this.numericUpDown_numero_de_iteraciones.Size = new System.Drawing.Size(85, 20);
            this.numericUpDown_numero_de_iteraciones.TabIndex = 3;
            this.numericUpDown_numero_de_iteraciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_numero_de_iteraciones.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.radioButton_iterar_paso_a_paso);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.radioButton_iterar_todo_a_la_vez);
            this.panel1.Controls.Add(this.numericUpDown_tiempo_entre_iteracion);
            this.panel1.Location = new System.Drawing.Point(17, 94);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(342, 74);
            this.panel1.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Forma de iterar";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(290, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Seg.";
            // 
            // radioButton_iterar_paso_a_paso
            // 
            this.radioButton_iterar_paso_a_paso.AutoSize = true;
            this.radioButton_iterar_paso_a_paso.Location = new System.Drawing.Point(120, 36);
            this.radioButton_iterar_paso_a_paso.Name = "radioButton_iterar_paso_a_paso";
            this.radioButton_iterar_paso_a_paso.Size = new System.Drawing.Size(85, 17);
            this.radioButton_iterar_paso_a_paso.TabIndex = 0;
            this.radioButton_iterar_paso_a_paso.Text = "Paso a Paso";
            this.radioButton_iterar_paso_a_paso.UseVisualStyleBackColor = true;
            this.radioButton_iterar_paso_a_paso.CheckedChanged += new System.EventHandler(this.radioButton_iterar_paso_a_paso_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(217, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tiempo entre iteración";
            // 
            // radioButton_iterar_todo_a_la_vez
            // 
            this.radioButton_iterar_todo_a_la_vez.AutoSize = true;
            this.radioButton_iterar_todo_a_la_vez.Checked = true;
            this.radioButton_iterar_todo_a_la_vez.Location = new System.Drawing.Point(9, 36);
            this.radioButton_iterar_todo_a_la_vez.Name = "radioButton_iterar_todo_a_la_vez";
            this.radioButton_iterar_todo_a_la_vez.Size = new System.Drawing.Size(90, 17);
            this.radioButton_iterar_todo_a_la_vez.TabIndex = 1;
            this.radioButton_iterar_todo_a_la_vez.TabStop = true;
            this.radioButton_iterar_todo_a_la_vez.Text = "Todo a la vez";
            this.radioButton_iterar_todo_a_la_vez.UseVisualStyleBackColor = true;
            this.radioButton_iterar_todo_a_la_vez.CheckedChanged += new System.EventHandler(this.radioButton_iterar_todo_a_la_vez_CheckedChanged);
            // 
            // numericUpDown_tiempo_entre_iteracion
            // 
            this.numericUpDown_tiempo_entre_iteracion.DecimalPlaces = 2;
            this.numericUpDown_tiempo_entre_iteracion.Enabled = false;
            this.numericUpDown_tiempo_entre_iteracion.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown_tiempo_entre_iteracion.Location = new System.Drawing.Point(220, 33);
            this.numericUpDown_tiempo_entre_iteracion.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown_tiempo_entre_iteracion.Name = "numericUpDown_tiempo_entre_iteracion";
            this.numericUpDown_tiempo_entre_iteracion.Size = new System.Drawing.Size(64, 20);
            this.numericUpDown_tiempo_entre_iteracion.TabIndex = 4;
            this.numericUpDown_tiempo_entre_iteracion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_tiempo_entre_iteracion.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // button_iniciar_iteracion
            // 
            this.button_iniciar_iteracion.BackColor = System.Drawing.Color.YellowGreen;
            this.button_iniciar_iteracion.Location = new System.Drawing.Point(384, 94);
            this.button_iniciar_iteracion.Name = "button_iniciar_iteracion";
            this.button_iniciar_iteracion.Size = new System.Drawing.Size(154, 74);
            this.button_iniciar_iteracion.TabIndex = 2;
            this.button_iniciar_iteracion.Text = "Iniciar iteración";
            this.button_iniciar_iteracion.UseVisualStyleBackColor = false;
            this.button_iniciar_iteracion.Click += new System.EventHandler(this.button_iniciar_iteracion_Click);
            // 
            // FormVentanaMBCIF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 612);
            this.Controls.Add(this.tableLayoutPanel_principal);
            this.Name = "FormVentanaMBCIF";
            this.Text = "Gestión Matriz Base Conocimiento Intervalo Difuso";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormVentanaMBCIF_FormClosing);
            this.tableLayoutPanel_principal.ResumeLayout(false);
            this.tableLayoutPanel_principal.PerformLayout();
            this.panel_datos.ResumeLayout(false);
            this.panel_datos.PerformLayout();
            this.panel_vizor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_imagen)).EndInit();
            this.panel_controles.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_intervalo_de_guardado_de_datos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_numero_de_iteraciones)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_tiempo_entre_iteracion)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_principal;
        private System.Windows.Forms.Panel panel_datos;
        private System.Windows.Forms.Panel panel_vizor;
        private System.Windows.Forms.Panel panel_controles;
        private System.Windows.Forms.PictureBox pictureBox_imagen;
        private System.Windows.Forms.Button button_disminuir;
        private System.Windows.Forms.Button button_aumentar;
        private System.Windows.Forms.Button button_modificar_nodo;
        private System.Windows.Forms.TextBox textBox_informacion_elementos;
        private System.Windows.Forms.Button button_buscar;
        private System.Windows.Forms.TextBox textBox_id_buscada;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton_influencia;
        private System.Windows.Forms.RadioButton radioButton_nodo;
        private System.Windows.Forms.RadioButton radioButton_sistema;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown_tiempo_entre_iteracion;
        private System.Windows.Forms.NumericUpDown numericUpDown_numero_de_iteraciones;
        private System.Windows.Forms.Button button_iniciar_iteracion;
        private System.Windows.Forms.RadioButton radioButton_iterar_todo_a_la_vez;
        private System.Windows.Forms.RadioButton radioButton_iterar_paso_a_paso;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox_actualizacion_inmediata_nodos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDown_intervalo_de_guardado_de_datos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ProgressBar progressBar_proceso_iterativo;
        private System.Windows.Forms.Button button_modificar_ajuste_influencia;
    }
}