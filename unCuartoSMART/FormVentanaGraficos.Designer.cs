﻿/*
 * Creado por SharpDevelop.
 * Usuario: usuario
 * Fecha: 02-07-2016
 * Hora: 18:38
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace unCuartoSMART
{
	partial class FormVentanaGraficos
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.DataVisualization.Charting.Chart grEstados;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown udIteraciones;
		private System.Windows.Forms.Button btnGenerarGrafico;
		private System.Windows.Forms.Button btnAgregarNodos;
		private System.Windows.Forms.Button btnQuitar;
		private System.Windows.Forms.ListView lvNodos;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVentanaGraficos));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grEstados = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.udIteraciones = new System.Windows.Forms.NumericUpDown();
            this.lvNodos = new System.Windows.Forms.ListView();
            this.btnAgregarNodos = new System.Windows.Forms.Button();
            this.btnGenerarGrafico = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grEstados)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udIteraciones)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Controls.Add(this.grEstados, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(909, 567);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // grEstados
            // 
            this.grEstados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.grEstados.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Unscaled;
            chartArea2.Name = "ChartArea1";
            this.grEstados.ChartAreas.Add(chartArea2);
            this.grEstados.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.DockedToChartArea = "ChartArea1";
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend2.IsDockedInsideChartArea = false;
            legend2.MaximumAutoSize = 5F;
            legend2.Name = "Legend1";
            legend2.TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Wide;
            this.grEstados.Legends.Add(legend2);
            this.grEstados.Location = new System.Drawing.Point(13, 13);
            this.grEstados.Name = "grEstados";
            this.grEstados.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.grEstados.Size = new System.Drawing.Size(883, 376);
            this.grEstados.TabIndex = 0;
            this.grEstados.Text = "Estados";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(13, 395);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(883, 158);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opciones de Gráfico";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 61F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnAgregarNodos, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnGenerarGrafico, 6, 1);
            this.tableLayoutPanel2.Controls.Add(this.label2, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.udIteraciones, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnQuitar, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.lvNodos, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(877, 139);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(53, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nodos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(462, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ultimas Iteraciones";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // udIteraciones
            // 
            this.udIteraciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.udIteraciones.Location = new System.Drawing.Point(548, 67);
            this.udIteraciones.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.udIteraciones.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.udIteraciones.Name = "udIteraciones";
            this.udIteraciones.Size = new System.Drawing.Size(55, 20);
            this.udIteraciones.TabIndex = 2;
            this.udIteraciones.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.udIteraciones.ThousandsSeparator = true;
            this.udIteraciones.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lvNodos
            // 
            this.lvNodos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvNodos.FullRowSelect = true;
            this.lvNodos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvNodos.Location = new System.Drawing.Point(111, 3);
            this.lvNodos.MultiSelect = false;
            this.lvNodos.Name = "lvNodos";
            this.tableLayoutPanel2.SetRowSpan(this.lvNodos, 5);
            this.lvNodos.Size = new System.Drawing.Size(345, 133);
            this.lvNodos.TabIndex = 7;
            this.lvNodos.UseCompatibleStateImageBehavior = false;
            this.lvNodos.View = System.Windows.Forms.View.List;
            // 
            // btnAgregarNodos
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.btnAgregarNodos, 2);
            this.btnAgregarNodos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAgregarNodos.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarNodos.Image")));
            this.btnAgregarNodos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarNodos.Location = new System.Drawing.Point(462, 3);
            this.btnAgregarNodos.Name = "btnAgregarNodos";
            this.btnAgregarNodos.Size = new System.Drawing.Size(141, 26);
            this.btnAgregarNodos.TabIndex = 5;
            this.btnAgregarNodos.Text = "Agregar";
            this.btnAgregarNodos.UseVisualStyleBackColor = true;
            this.btnAgregarNodos.Click += new System.EventHandler(this.BtnAgregarNodosClick);
            // 
            // btnGenerarGrafico
            // 
            this.btnGenerarGrafico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGenerarGrafico.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerarGrafico.Image")));
            this.btnGenerarGrafico.Location = new System.Drawing.Point(644, 35);
            this.btnGenerarGrafico.Name = "btnGenerarGrafico";
            this.tableLayoutPanel2.SetRowSpan(this.btnGenerarGrafico, 2);
            this.btnGenerarGrafico.Size = new System.Drawing.Size(130, 76);
            this.btnGenerarGrafico.TabIndex = 3;
            this.btnGenerarGrafico.Text = "Generar Gráfico";
            this.btnGenerarGrafico.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGenerarGrafico.UseVisualStyleBackColor = true;
            this.btnGenerarGrafico.Click += new System.EventHandler(this.BtnGenerarGraficoClick);
            // 
            // btnQuitar
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.btnQuitar, 2);
            this.btnQuitar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnQuitar.Image = ((System.Drawing.Image)(resources.GetObject("btnQuitar.Image")));
            this.btnQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuitar.Location = new System.Drawing.Point(462, 35);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(141, 26);
            this.btnQuitar.TabIndex = 6;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitarClick);
            // 
            // FormVentanaGraficos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 567);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormVentanaGraficos";
            this.Text = "Gráfico";
            this.Activated += new System.EventHandler(this.FormVentanaGraficosActivated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormVentanaGraficosFormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grEstados)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.udIteraciones)).EndInit();
            this.ResumeLayout(false);

		}
	}
}
