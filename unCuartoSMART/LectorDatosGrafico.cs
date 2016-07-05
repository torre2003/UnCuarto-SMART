/*
 * Creado por SharpDevelop.
 * Usuario: usuario
 * Fecha: 02-07-2016
 * Hora: 23:53
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using ManejadorPostgreSQL;

namespace AccesoADatos
{
	/// <summary>
	/// Description of LectorDatosGrafico.
	/// </summary>
	public class LectorDatosGrafico 
	{
		PostgreSQL sql = new PostgreSQL();
		
		public LectorDatosGrafico(){
			sql.conectar();
		}
		
		public List<List<double>> obtenerPesos(string[] nodos, int cantidadRegistros=-1){
		
			string campos = "" ;
			string tablas = "" ;
			string condic = "" ;
			string limit = "";
			for(int i=0 ; i < nodos.Length ; i++){
				campos += nodos[i] +".peso";
				tablas += nodos[i] ;
				if(i >= 2)
						condic += " AND " ;
				if( i >= 1)
					condic += nodos[i-1] + ".id = " + nodos[i] + ".id" ;
				if(i < nodos.Length -1){
					campos += "," ;
					tablas += "," ;
				}	
			}
			if(nodos.Length > 1)
				condic = " WHERE " + condic ;
			
			if( cantidadRegistros > 0)
				limit += " LIMIT " + cantidadRegistros.ToString() ;
			
			string consulta = "SELECT " + campos + " FROM " + tablas + condic + limit +" ;";
			var reader = sql.consultaSelectDataReader(consulta);
		
			var salida = new List<List<double>>();
			if (reader.HasRows){
				for(int i=0 ;i < nodos.Length ; i++)						
					salida.Add(new List<double>());
	            while (reader.Read()){
					for(int i=0 ;i < nodos.Length ; i++)
						salida[i].Add(reader.GetDouble(i));
	            }
	        }
			return salida;
		}
		
	}
}
