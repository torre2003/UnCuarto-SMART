/*
 * Creado por SharpDevelop.
 * Usuario: usuario
 * Fecha: 02-07-2016
 * Hora: 18:38
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using AccesoADatos;

namespace unCuartoSMART
{
	/// <summary>
	/// Description of FormVentanaGraficos.
	/// </summary>
	public partial class FormVentanaGraficos : Form
	{

		private string[] listaNodos = null ;
		
		public FormVentanaGraficos(string _ruta_carpeta_mbcif)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			lstNodos.Items.Clear();
			cargarListadoNodos(_ruta_carpeta_mbcif);
		}

		private void cargarListadoNodos(string _ruta_carpeta_mbcif){
			var manejador_de_archivos = new ManejadorDeDatosArchivos(_ruta_carpeta_mbcif);
            listaNodos = manejador_de_archivos.listarArchivosEnDirectorio(ManejadorDeDatosArchivos.NODOS);
		}
		void BtnAgregarNodosClick(object sender, EventArgs e)
		{
			           
            var ventana_buscar = new FormVentanaBuscar("Nodos");

            for (int i = 0; i < listaNodos.Length; i++){
            	if(lstNodos.Items.IndexOf(listaNodos[i]) == -1)
                	ventana_buscar.agregarElemento(listaNodos[i]);
            }
            
            ventana_buscar.ShowDialog(this);
            if (ventana_buscar.seleccion != null){
            	lstNodos.Items.Add(ventana_buscar.seleccion);
            }
            
		}
		void Button1Click(object sender, EventArgs e)
		{
			if(lstNodos.SelectedIndex > -1)
				lstNodos.Items.RemoveAt(lstNodos.SelectedIndex);
		}
		void FormVentanaGraficosFormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
            this.Hide();
		}
		void BtnGenerarGraficoClick(object sender, EventArgs e)
		{
			
			if(lstNodos.Items.Count < 1)
				return;
			
			var data = new LectorDatosGrafico();
			
			var nodos = new string[lstNodos.Items.Count] ;
			for(int i = 0; i < lstNodos.Items.Count ; i++)
				nodos[i] = lstNodos.Items[i].ToString();
			
			var pesos = data.obtenerPesos(nodos,(int)udIteraciones.Value);
			
			//foreach(var series in grEstados.Series) {
            //    series.Points.Clear();
            //}
            grEstados.Series.Clear();
            //grEstados.Titles.Clear();
            
            //grEstados.Titles.Add(var.Nombre);
            var a = grEstados.ChartAreas[0];
            a.AxisX.Minimum = 1;
			a.AxisX.Maximum = (double)udIteraciones.Value;

            a.AxisX.MajorGrid.Enabled = false;
            a.AxisY.MajorGrid.Enabled = false;
            a.BorderDashStyle = ChartDashStyle.Solid;
            
            for(int col=0; col < pesos.Count; col++){          
            	var lines = new Series(nodos[col]);
                lines.ChartType = SeriesChartType.Line; 
                for ( int fil = 0; fil < pesos[col].Count ; fil++ )
                    lines.Points.Add(new DataPoint( fil+1, pesos[col][fil]));
                lines.YAxisType = AxisType.Primary;
                grEstados.Series.Add(lines);
                
            }

		}
	}
}
