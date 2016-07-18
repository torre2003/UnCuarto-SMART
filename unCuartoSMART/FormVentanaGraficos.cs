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
			lstNodos.Items.Clear();
			cargarListadoNodos(_ruta_carpeta_mbcif);
			
			var a = grEstados.ChartAreas[0];
			a.AxisX.Title = "Iteraciones" ;
			a.AxisY.Maximum = 1.1 ;
			a.AxisY.Title = "Estado" ;
			
			a.AxisX.MajorGrid.Enabled = false;
			a.AxisY.MajorGrid.Enabled = false;
			a.BorderDashStyle = ChartDashStyle.Solid;

            
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
                if (lstNodos.Items.IndexOf(listaNodos[i]) == -1)
                {
                    ModeloMBCIF.Nodo nodo = manejador_archivos.extraerNodo(listaNodos[i]);
                    ventana_buscar.agregarElemento(listaNodos[i],nodo.nombre);
                }

					
			}
            
			ventana_buscar.ShowDialog(this);
			if (ventana_buscar.seleccion != null) {
				lstNodos.Items.Add(ventana_buscar.seleccion);
			}
            
		}
	//--------------------------------------------------------------------------------------
		void btnQuitarClick(object sender, EventArgs e)
		{
			if (lstNodos.SelectedIndex > -1)
				lstNodos.Items.RemoveAt(lstNodos.SelectedIndex);
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
			
			if (lstNodos.Items.Count < 1)
				return;
			
			var nodos = new string[lstNodos.Items.Count];
			for (int i = 0; i < lstNodos.Items.Count; i++)
				nodos[i] = lstNodos.Items[i].ToString();
			
			var data = new ManejadorDeDatosBaseDeDatos(manejador_archivos);
			var pesos = data.obtenerPesos(nodos, (int)udIteraciones.Value);
			
			grEstados.Series.Clear();
			
            
			for (int col = 0; col < pesos.Count; col++) {          
				var lines = new Series(nodos[col]);
				lines.ChartType = SeriesChartType.Line; 
				for (int fil = 0; fil < pesos[col].Count; fil++)
					lines.Points.Add(new DataPoint((maxActual-pesos[col].Count + fil+1 ), pesos[col][fil]));
				lines.YAxisType = AxisType.Primary;
				grEstados.Series.Add(lines);
                
			}

		}
		void FormVentanaGraficosActivated(object sender, EventArgs e)
		{/*
		    var data = new ManejadorDeDatosBaseDeDatos(manejador_archivos);
			var maxNuevo = Int32.Parse(data.obtenerUltimaIdCreada());
			var dif = maxNuevo - maxActual ;
			udIteraciones.Maximum = maxNuevo;
			udIteraciones.Value += dif ;
			maxActual = maxNuevo;
			
			if(dif > 0)
				BtnGenerarGraficoClick(null,null);
		*/}
	//--------------------------------------------------------------------------------------
	}
}
