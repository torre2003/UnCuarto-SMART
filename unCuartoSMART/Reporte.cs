/*
 * Creado por SharpDevelop.
 * Usuario: usuario
 * Fecha: 03-07-2016
 * Hora: 21:27
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using AccesoADatos;

namespace unCuartoSMART
{
	/// <summary>
	/// Description of Reporte.
	/// </summary>
	public class Reporte
	{
		
		private string[] listaNodos = null;
		public Reporte(string _ruta_carpeta_mbcif)
		{
			cargarListadoNodos(_ruta_carpeta_mbcif);
		}
		//--------------------------------------------------------------------------------------
		private void cargarListadoNodos(string _ruta_carpeta_mbcif)
		{
			var manejador_de_archivos = new ManejadorDeDatosArchivos(_ruta_carpeta_mbcif);
			listaNodos = manejador_de_archivos.listarArchivosEnDirectorio(ManejadorDeDatosArchivos.NODOS);
		}
		//--------------------------------------------------------------------------------------
		public bool generarReporte(string fileName)
		{
			try {
                var manejador_de_archivos = new ManejadorDeDatosArchivos();
                var data = new ManejadorDeDatosBaseDeDatos(manejador_de_archivos);
				var pesos = data.obtenerPesos(listaNodos);
				Microsoft.Office.Interop.Excel.Application aplicacion;
				Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
				Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
				aplicacion = new Microsoft.Office.Interop.Excel.Application();
				libros_trabajo = aplicacion.Workbooks.Add();
				hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);
				for (int i = 0; i < listaNodos.Length; i++)
					hoja_trabajo.Cells[1, i + 1] = listaNodos[i];
				for (int col = 0; col < pesos.Count; col++) {
					for (int fila = 0; fila < pesos[col].Count; fila++) {
						hoja_trabajo.Cells[fila + 2, col + 1] = Math.Round(pesos[col][fila],2);
					}
				}
				libros_trabajo.SaveAs(fileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);
				libros_trabajo.Close(true);
				return true;
			} catch (Exception e) {
				e = null;
				return false;
			}			
		}
	}
	//--------------------------------------------------------------------------------------
}

