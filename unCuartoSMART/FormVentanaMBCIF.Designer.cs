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
            this.panel_vizor = new System.Windows.Forms.Panel();
            this.pictureBox_imagen = new System.Windows.Forms.PictureBox();
            this.panel_controles = new System.Windows.Forms.Panel();
            this.button_disminuir = new System.Windows.Forms.Button();
            this.button_aumentar = new System.Windows.Forms.Button();
            this.button_fantasma = new System.Windows.Forms.Button();
            this.tableLayoutPanel_principal.SuspendLayout();
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
            this.tableLayoutPanel_principal.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_principal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel_principal.Size = new System.Drawing.Size(1084, 756);
            this.tableLayoutPanel_principal.TabIndex = 0;
            // 
            // panel_datos
            // 
            this.panel_datos.Location = new System.Drawing.Point(3, 3);
            this.panel_datos.Name = "panel_datos";
            this.tableLayoutPanel_principal.SetRowSpan(this.panel_datos, 2);
            this.panel_datos.Size = new System.Drawing.Size(395, 741);
            this.panel_datos.TabIndex = 0;
            // 
            // panel_vizor
            // 
            this.panel_vizor.AutoScroll = true;
            this.panel_vizor.Controls.Add(this.button_disminuir);
            this.panel_vizor.Controls.Add(this.button_aumentar);
            this.panel_vizor.Controls.Add(this.pictureBox_imagen);
            this.panel_vizor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_vizor.Location = new System.Drawing.Point(404, 3);
            this.panel_vizor.Name = "panel_vizor";
            this.panel_vizor.Size = new System.Drawing.Size(677, 581);
            this.panel_vizor.TabIndex = 1;
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
            this.panel_controles.Controls.Add(this.button_fantasma);
            this.panel_controles.Location = new System.Drawing.Point(404, 590);
            this.panel_controles.Name = "panel_controles";
            this.panel_controles.Size = new System.Drawing.Size(677, 163);
            this.panel_controles.TabIndex = 2;
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
            this.ClientSize = new System.Drawing.Size(1084, 756);
            this.Controls.Add(this.tableLayoutPanel_principal);
            this.Name = "FormVentanaMBCIF";
            this.Text = "Form_ventana_mbcif";
            this.tableLayoutPanel_principal.ResumeLayout(false);
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
    }
}