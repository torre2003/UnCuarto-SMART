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
            this.button_fantasma = new System.Windows.Forms.Button();
            this.tableLayoutPanel_principal.SuspendLayout();
            this.panel_datos.SuspendLayout();
            this.panel_vizor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_imagen)).BeginInit();
            this.panel_controles.SuspendLayout();
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
            this.tableLayoutPanel_principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel_principal.Size = new System.Drawing.Size(850, 612);
            this.tableLayoutPanel_principal.TabIndex = 0;
            // 
            // panel_datos
            // 
            this.panel_datos.AutoSize = true;
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
            this.panel_datos.Size = new System.Drawing.Size(291, 580);
            this.panel_datos.TabIndex = 0;
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
            this.textBox_id_buscada.Text = "n11";
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
            this.panel_vizor.Controls.Add(this.button_disminuir);
            this.panel_vizor.Controls.Add(this.button_aumentar);
            this.panel_vizor.Controls.Add(this.pictureBox_imagen);
            this.panel_vizor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_vizor.Location = new System.Drawing.Point(300, 3);
            this.panel_vizor.Name = "panel_vizor";
            this.panel_vizor.Size = new System.Drawing.Size(547, 446);
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
            this.panel_controles.BackColor = System.Drawing.Color.Transparent;
            this.panel_controles.Controls.Add(this.button_fantasma);
            this.panel_controles.Location = new System.Drawing.Point(300, 455);
            this.panel_controles.Name = "panel_controles";
            this.panel_controles.Size = new System.Drawing.Size(412, 98);
            this.panel_controles.TabIndex = 2;
            // 
            // button_fantasma
            // 
            this.button_fantasma.Location = new System.Drawing.Point(38, 38);
            this.button_fantasma.Name = "button_fantasma";
            this.button_fantasma.Size = new System.Drawing.Size(175, 23);
            this.button_fantasma.TabIndex = 0;
            this.button_fantasma.Text = "Botton Fantasma";
            this.button_fantasma.UseVisualStyleBackColor = true;
            this.button_fantasma.Click += new System.EventHandler(this.button_fantasma_Click);
            // 
            // FormVentanaMBCIF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 612);
            this.Controls.Add(this.tableLayoutPanel_principal);
            this.Name = "FormVentanaMBCIF";
            this.Text = "Form_ventana_mbcif";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel_principal.ResumeLayout(false);
            this.tableLayoutPanel_principal.PerformLayout();
            this.panel_datos.ResumeLayout(false);
            this.panel_datos.PerformLayout();
            this.panel_vizor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_imagen)).EndInit();
            this.panel_controles.ResumeLayout(false);
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
        private System.Windows.Forms.Button button_fantasma;
        private System.Windows.Forms.Button button_modificar_nodo;
        private System.Windows.Forms.TextBox textBox_informacion_elementos;
        private System.Windows.Forms.Button button_buscar;
        private System.Windows.Forms.TextBox textBox_id_buscada;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton_influencia;
        private System.Windows.Forms.RadioButton radioButton_nodo;
        private System.Windows.Forms.RadioButton radioButton_sistema;
    }
}