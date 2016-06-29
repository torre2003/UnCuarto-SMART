namespace unCuartoSMART
{
    partial class FormVentanaBuscar
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
            this.listBox_elementos = new System.Windows.Forms.ListBox();
            this.label_lista = new System.Windows.Forms.Label();
            this.button_aceptar = new System.Windows.Forms.Button();
            this.button_cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox_elementos
            // 
            this.listBox_elementos.FormattingEnabled = true;
            this.listBox_elementos.Location = new System.Drawing.Point(34, 64);
            this.listBox_elementos.Name = "listBox_elementos";
            this.listBox_elementos.Size = new System.Drawing.Size(328, 225);
            this.listBox_elementos.TabIndex = 0;
            // 
            // label_lista
            // 
            this.label_lista.AutoSize = true;
            this.label_lista.Location = new System.Drawing.Point(31, 33);
            this.label_lista.Name = "label_lista";
            this.label_lista.Size = new System.Drawing.Size(88, 13);
            this.label_lista.TabIndex = 1;
            this.label_lista.Text = "Lista de XXXXX :";
            // 
            // button_aceptar
            // 
            this.button_aceptar.Location = new System.Drawing.Point(34, 323);
            this.button_aceptar.Name = "button_aceptar";
            this.button_aceptar.Size = new System.Drawing.Size(132, 23);
            this.button_aceptar.TabIndex = 2;
            this.button_aceptar.Text = "Aceptar";
            this.button_aceptar.UseVisualStyleBackColor = true;
            this.button_aceptar.Click += new System.EventHandler(this.button_aceptar_Click);
            // 
            // button_cancelar
            // 
            this.button_cancelar.Location = new System.Drawing.Point(218, 323);
            this.button_cancelar.Name = "button_cancelar";
            this.button_cancelar.Size = new System.Drawing.Size(144, 23);
            this.button_cancelar.TabIndex = 3;
            this.button_cancelar.Text = "Cancelar";
            this.button_cancelar.UseVisualStyleBackColor = true;
            this.button_cancelar.Click += new System.EventHandler(this.button_cancelar_Click);
            // 
            // FormVentanaBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 385);
            this.Controls.Add(this.button_cancelar);
            this.Controls.Add(this.button_aceptar);
            this.Controls.Add(this.label_lista);
            this.Controls.Add(this.listBox_elementos);
            this.Name = "FormVentanaBuscar";
            this.Text = "Buscar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_elementos;
        private System.Windows.Forms.Label label_lista;
        private System.Windows.Forms.Button button_aceptar;
        private System.Windows.Forms.Button button_cancelar;
    }
}