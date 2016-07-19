namespace unCuartoSMART
{
    partial class FormVentanaPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVentanaPrincipal));
            this.menuStrip_principal = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem_archivo = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem_salir = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveDialogReporte = new System.Windows.Forms.SaveFileDialog();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modeloToolStripMenuItem_modelo_mbcif = new System.Windows.Forms.ToolStripMenuItem();
            this.graficosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarReporteMSExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_principal.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip_principal
            // 
            this.menuStrip_principal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem_archivo});
            this.menuStrip_principal.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_principal.Name = "menuStrip_principal";
            this.menuStrip_principal.Size = new System.Drawing.Size(919, 24);
            this.menuStrip_principal.TabIndex = 1;
            this.menuStrip_principal.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem_archivo
            // 
            this.archivoToolStripMenuItem_archivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.configuracionToolStripMenuItem,
            this.modeloToolStripMenuItem_modelo_mbcif,
            this.graficosToolStripMenuItem,
            this.generarReporteMSExcelToolStripMenuItem,
            this.salirToolStripMenuItem_salir});
            this.archivoToolStripMenuItem_archivo.Name = "archivoToolStripMenuItem_archivo";
            this.archivoToolStripMenuItem_archivo.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem_archivo.Text = "Archivo";
            // 
            // salirToolStripMenuItem_salir
            // 
            this.salirToolStripMenuItem_salir.Image = global::unCuartoSMART.Properties.Resources.Door_Out;
            this.salirToolStripMenuItem_salir.Name = "salirToolStripMenuItem_salir";
            this.salirToolStripMenuItem_salir.Size = new System.Drawing.Size(208, 22);
            this.salirToolStripMenuItem_salir.Text = "Salir";
            this.salirToolStripMenuItem_salir.Click += new System.EventHandler(this.salirToolStripMenuItem_salir_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "mbcif";
            this.saveFileDialog1.Filter = "Archivos MBCIF|*.mbcif";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "mbcif";
            this.openFileDialog1.Filter = "Modelo MBCIF|*.mbcif";
            // 
            // saveDialogReporte
            // 
            this.saveDialogReporte.Filter = "Hoja de Cálculo MS Excel | *.xls";
            this.saveDialogReporte.Title = "Guardar Reporte MS Excel";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Image = global::unCuartoSMART.Properties.Resources.Folder_Page_White;
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Image = global::unCuartoSMART.Properties.Resources.Disk;
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // configuracionToolStripMenuItem
            // 
            this.configuracionToolStripMenuItem.Image = global::unCuartoSMART.Properties.Resources.Setting_Tools;
            this.configuracionToolStripMenuItem.Name = "configuracionToolStripMenuItem";
            this.configuracionToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.configuracionToolStripMenuItem.Text = "Configuración";
            this.configuracionToolStripMenuItem.Click += new System.EventHandler(this.configuracionToolStripMenuItem_Click);
            // 
            // modeloToolStripMenuItem_modelo_mbcif
            // 
            this.modeloToolStripMenuItem_modelo_mbcif.Image = global::unCuartoSMART.Properties.Resources.mbcif;
            this.modeloToolStripMenuItem_modelo_mbcif.Name = "modeloToolStripMenuItem_modelo_mbcif";
            this.modeloToolStripMenuItem_modelo_mbcif.Size = new System.Drawing.Size(208, 22);
            this.modeloToolStripMenuItem_modelo_mbcif.Text = "Gestión MBCIF";
            this.modeloToolStripMenuItem_modelo_mbcif.Click += new System.EventHandler(this.modeloToolStripMenuItem_modelo_mbcif_Click);
            // 
            // graficosToolStripMenuItem
            // 
            this.graficosToolStripMenuItem.Image = global::unCuartoSMART.Properties.Resources.Chart_Curve;
            this.graficosToolStripMenuItem.Name = "graficosToolStripMenuItem";
            this.graficosToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.graficosToolStripMenuItem.Text = "Gráficos";
            this.graficosToolStripMenuItem.Click += new System.EventHandler(this.GraficosToolStripMenuItemClick);
            // 
            // generarReporteMSExcelToolStripMenuItem
            // 
            this.generarReporteMSExcelToolStripMenuItem.Image = global::unCuartoSMART.Properties.Resources.Export_Excel;
            this.generarReporteMSExcelToolStripMenuItem.Name = "generarReporteMSExcelToolStripMenuItem";
            this.generarReporteMSExcelToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.generarReporteMSExcelToolStripMenuItem.Text = "Generar Reporte MS Excel";
            this.generarReporteMSExcelToolStripMenuItem.Click += new System.EventHandler(this.GenerarReporteMSExcelToolStripMenuItemClick);
            // 
            // FormVentanaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 717);
            this.Controls.Add(this.menuStrip_principal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip_principal;
            this.Name = "FormVentanaPrincipal";
            this.Text = "1/4 S.M.A.R.T.";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
        private System.Windows.Forms.ToolStripMenuItem configuracionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem graficosToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveDialogReporte;
        private System.Windows.Forms.ToolStripMenuItem generarReporteMSExcelToolStripMenuItem;
    }
}