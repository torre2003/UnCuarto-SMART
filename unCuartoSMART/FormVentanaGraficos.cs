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

		private ManejadorDeDatosArchivos manejador_archivos ;
		//private ManejadorDeDatosBaseDeDatos data;
		private string[] listaNodos = null;
		private int maxActual = 0;
	//--------------------------------------------------------------------------------------
		public FormVentanaGraficos(string _ruta_carpeta_mbcif)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
            manejador_archivos = new ManejadorDeDatosArchivos(_ruta_carpeta_mbcif);
            var data = new ManejadorDeDatosBaseDeDatos(manejador_archivos);
            
            InitializeComponent();

			lvNodos.Items.Clear();
			cargarListadoNodos(_ruta_carpeta_mbcif);
			
			var a = grEstados.ChartAreas[0];
			a.AxisX.Title = "Iteraciones" ;
			a.AxisY.Maximum = 1.1 ;
			a.AxisY.Title = "Estado" ;
			
			a.AxisX.MajorGrid.Enabled = false;
			a.AxisY.MajorGrid.Enabled = false;
			a.BorderDashStyle = ChartDashStyle.Solid;

            
			// disable once ConvertIfStatementToConditionalTernaryExpression
			if(data.bdd_conectada)
				maxActual = Int32.Parse(data.obtenerUltimaIdCreada());
			else
				maxActual = 10 ;
            //if (maxActual == 0)
              //  maxActual = 1;
            udIteraciones.Maximum = maxActual;
            udIteraciones.Value = maxActual;
			
			
		}
	//--------------------------------------------------------------------------------------
		private void cargarListadoNodos(string _ruta_carpeta_mbcif)
		{
			//var manejador_de_archivos = new ManejadorDeDatosArchivos(_ruta_carpeta_mbcif);
            listaNodos = manejador_archivos.listarArchivosEnDirectorio(ManejadorDeDatosArchivos.NODOS);
		}
	//--------------------------------------------------------------------------------------
		void BtnAgregarNodosClick(object sender, EventArgs e)
		{
			           
			var ventana_buscar = new FormVentanaBuscar("Nodos");

			for (int i = 0; i < listaNodos.Length; i++) {

                if (lvNodos.Items.Find(listaNodos[i],false).Length == 0)
                {
                    ModeloMBCIF.Nodo nodo = manejador_archivos.extraerNodo(listaNodos[i]);
                    ventana_buscar.agregarElemento(listaNodos[i], nodo.nombre);
                }					
			}
            
			ventana_buscar.ShowDialog(this);
			if (ventana_buscar.seleccion != null) {
				var item = new ListViewItem(ventana_buscar.descripcion_seleccion);
				item.Name = ventana_buscar.seleccion ;
				item.SubItems.Add(ventana_buscar.seleccion);
					lvNodos.Items.Add(item);
			}
            
		}
	//--------------------------------------------------------------------------------------
		void btnQuitarClick(object sender, EventArgs e)
		{
			if (lvNodos.SelectedItems.Count > 0)
				lvNodos.Items.Remove(lvNodos.SelectedItems[0]);
		}
	//--------------------------------------------------------------------------------------
		void FormVentanaGraficosFormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = true;
			this.Hide();
		}
	//--------------------------------------------------------------------------------------
		void BtnGenerarGraficoClick(object sender, EventArgs e)
		{
			
			try {
				if (lvNodos.Items.Count < 1)
					return;
				
				var nodos = new string[lvNodos.Items.Count];
				var nombreNodos = new string[lvNodos.Items.Count];
				for (int i = 0; i < lvNodos.Items.Count; i++){
					nodos[i] = lvNodos.Items[i].Name;//.SubItems[0].Text;
					nombreNodos[i] = lvNodos.Items[i].Text;
				}
				
				var data = new ManejadorDeDatosBaseDeDatos(manejador_archivos);
				maxActual = Int32.Parse(data.obtenerUltimaIdCreada());
				var pesos = data.obtenerPesos(nodos, (int)udIteraciones.Value);
				
				
				grEstados.Series.Clear();
				
				for (int col = 0; col < pesos.Count; col++) {          
					var lines = new Series(nombreNodos[col]);
					lines.ChartType = SeriesChartType.Line; 
					for (int fil = 0; fil < pesos[col].Count; fil++)
						lines.Points.Add(new DataPoint((maxActual-pesos[col].Count + fil+1 ), pesos[col][fil]));
					lines.YAxisType = AxisType.Primary;
					grEstados.Series.Add(lines);                         
				}
			} catch (Exception ex) {				
				MessageBox.Show(ex.Message);
			}
		}
		void FormVentanaGraficosActivated(object sender, EventArgs e)
		{
			try {
				var data = new ManejadorDeDatosBaseDeDatos(manejador_archivos);
				maxActual = Int32.Parse(data.obtenerUltimaIdCreada());
				
				udIteraciones.Maximum = maxActual;
				udIteraciones.Value = maxActual;
			} catch (Exception ex) {				
				MessageBox.Show(ex.Message);
			}

		}
	//--------------------------------------------------------------------------------------
	}
}
