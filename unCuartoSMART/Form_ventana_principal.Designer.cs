namespace unCuartoSMART
{
    partial class Form_ventana_principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ventana_principal));
            this.menuStrip_principal = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem_archivo = new System.Windows.Forms.ToolStripMenuItem();
            this.modeloToolStripMenuItem_modelo_mbcif = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem_salir = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_principal.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip_principal
            // 
            this.menuStrip_principal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem_archivo});
            this.menuStrip_principal.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_principal.Name = "menuStrip_principal";
            this.menuStrip_principal.Size = new System.Drawing.Size(785, 24);
            this.menuStrip_principal.TabIndex = 1;
            this.menuStrip_principal.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem_archivo
            // 
            this.archivoToolStripMenuItem_archivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modeloToolStripMenuItem_modelo_mbcif,
            this.salirToolStripMenuItem_salir});
            this.archivoToolStripMenuItem_archivo.Name = "archivoToolStripMenuItem_archivo";
            this.archivoToolStripMenuItem_archivo.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem_archivo.Text = "Archivo";
            // 
            // modeloToolStripMenuItem_modelo_mbcif
            // 
            this.modeloToolStripMenuItem_modelo_mbcif.Name = "modeloToolStripMenuItem_modelo_mbcif";
            this.modeloToolStripMenuItem_modelo_mbcif.Size = new System.Drawing.Size(152, 22);
            this.modeloToolStripMenuItem_modelo_mbcif.Text = "Modelo";
            // 
            // salirToolStripMenuItem_salir
            // 
            this.salirToolStripMenuItem_salir.Name = "salirToolStripMenuItem_salir";
            this.salirToolStripMenuItem_salir.Size = new System.Drawing.Size(152, 22);
            this.salirToolStripMenuItem_salir.Text = "Salir";
            // 
            // Form_ventana_principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 587);
            this.Controls.Add(this.menuStrip_principal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip_principal;
            this.Name = "Form_ventana_principal";
            this.Text = "1/4 S.M.A.R.T.";
            this.menuStrip_principal.ResumeLayout(false);
            this.menuStrip_principal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip_principal;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem_archivo;
        private System.Windows.Forms.ToolStripMenuItem modeloToolStripMenuItem_modelo_mbcif;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem_salir;
    }
}