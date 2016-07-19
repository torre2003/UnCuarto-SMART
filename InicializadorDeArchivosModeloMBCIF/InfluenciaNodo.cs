/*
 * Creado por SharpDevelop.
 * Usuario: usuario
 * Fecha: 15-07-2016
 * Hora: 22:54
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using AccesoADatos;
using ContenedorImplementacionesInterfacesCalculoModeloMBCIF;
using FuzzyCore;
using ModeloMBCIF;

namespace InicializadorDeArchivosModeloMBCIF
{
	/// <summary>
	/// Description of InfluenciasDoctorados.
	/// </summary>
	public static class InfluenciaNodo
	{
		
		public const int INF_PROGRAMA_PUBLICACIONES = 1;
		public const int INF_ACADEMICO_PUBLICACIONES = 2;
		public const int INF_INVESTIGADOR_PUBLICACIONES = 3;
		public const int INF_BECAS_PROGRAMAS = 4;
		public const int INF_INVESTIGACION_PROGRAMAS = 5;
		public const int INF_DIRPOSTGRADO_PROGRAMAS = 6;
		public const int INF_DIRECTORES = 7;
		public const int INF_SECRETARIAS = 8;
		public const int INF_DIRECTOR_SECRETRIA = 9;
		public const int INF_INVESTIGACION_POSTGRADO = 10;
		
		public static void crearInfluencias(string idOrigen, string nombreOrigen, string[] idDestinos, int tipoInfluecia)
		{
			
			var manejador_de_archivos = new ManejadorDeDatosArchivos();
			//____________________________________________________________________
			//___________________      i_n11_n12    ______________________________
			//____________________________________________________________________
			
			
			foreach (var idNodoInfluenciado in idDestinos) {
				
				var id = "i_" + idOrigen + "_" + idNodoInfluenciado;
				var influencia = new Influencia(id);
				influencia.id_nodo_origen = idOrigen;
				influencia.id_nodo_influenciado = idNodoInfluenciado;
				influencia.nombre_nodo_origen = nombreOrigen;
				
				influencia.calculos = new InterfacesCalculoGlobal(idOrigen);
				
				influencia.fuzzy = new InferenciaDifusa();
				
				//entradas
				influencia.fuzzy.Entradas = new Dictionary<string, VariableDifusa> { {idOrigen, new VariableDifusa(idOrigen, 0, 1,
							new List<FuncionPertenencia>() {
								new FuncionSaturacion("pesimo", 0, 0.1, 0.2),
								new FuncionTriangular("malo", 0.1, 0.2, 0.4),
								new FuncionTriangular("bueno", 0.6, 0.8, 0.9),
								new FuncionSaturacion("excelente", 0.8, 0.9, 1.00),
							})
					},
				};
				
				//salidas
				influencia.fuzzy.Salidas.Add("influencia", new VariableDifusa("influencia"));
				//TODO Ajustar influencias personalizadamente
				
				switch (tipoInfluecia) {
					case INF_PROGRAMA_PUBLICACIONES:
						influencia.fuzzy.Salidas["influencia"].Rango(-0.1, 0.1);
						influencia.fuzzy.Salidas["influencia"].UniversoDiscurso = new List<FuncionPertenencia>() {
							new FuncionSaturacion("altera_negativamente", -0.1, -0.1, -0.04),
							new FuncionTriangular("influye_negativamente", -0.08, -0.04, 0),
							new FuncionTriangular("influye_positivamente", 0, 0.04, 0.08),
							new FuncionSaturacion("altera_positivamente", 0.04, 0.1, 0.1),
						};
						break;
					case INF_ACADEMICO_PUBLICACIONES:
						influencia.fuzzy.Salidas["influencia"].Rango(-0.075, 0.075);
						influencia.fuzzy.Salidas["influencia"].UniversoDiscurso = new List<FuncionPertenencia>() {
							new FuncionSaturacion("altera_negativamente", -0.075, -0.075, -0.03),
							new FuncionTriangular("influye_negativamente", -0.06, -0.03, 0),
							new FuncionTriangular("influye_positivamente", 0, 0.03, 0.06),
							new FuncionSaturacion("altera_positivamente", 0.03, 0.075, 0.075),
						};
						break;
					case INF_BECAS_PROGRAMAS:
						influencia.fuzzy.Salidas["influencia"].Rango(-0.4, 0.4);
						influencia.fuzzy.Salidas["influencia"].UniversoDiscurso = new List<FuncionPertenencia>() {
							new FuncionSaturacion("altera_negativamente", -0.075, -0.075, -0.03),
							new FuncionTriangular("influye_negativamente", -0.06, -0.03, 0),
							new FuncionTriangular("influye_positivamente", 0, 0.03, 0.06),
							new FuncionSaturacion("altera_positivamente", 0.03, 0.075, 0.075),
						};
						break;
					case INF_INVESTIGACION_PROGRAMAS:
						influencia.fuzzy.Salidas["influencia"].Rango(-0.2, 0.2);
						influencia.fuzzy.Salidas["influencia"].UniversoDiscurso = new List<FuncionPertenencia>() {
							new FuncionSaturacion("altera_negativamente", -0.075, -0.075, -0.03),
							new FuncionTriangular("influye_negativamente", -0.06, -0.03, 0),
							new FuncionTriangular("influye_positivamente", 0, 0.03, 0.06),
							new FuncionSaturacion("altera_positivamente", 0.03, 0.075, 0.075),
						};
						break;
					case INF_DIRPOSTGRADO_PROGRAMAS:
						influencia.fuzzy.Salidas["influencia"].Rango(-0.1, 0.1);
						influencia.fuzzy.Salidas["influencia"].UniversoDiscurso = new List<FuncionPertenencia>() {
							new FuncionSaturacion("altera_negativamente", -0.075, -0.075, -0.03),
							new FuncionTriangular("influye_negativamente", -0.06, -0.03, 0),
							new FuncionTriangular("influye_positivamente", 0, 0.03, 0.06),
							new FuncionSaturacion("altera_positivamente", 0.03, 0.075, 0.075),
						};
						break;
					case INF_DIRECTORES:
						influencia.fuzzy.Salidas["influencia"].Rango(-0.1, 0.1);
						influencia.fuzzy.Salidas["influencia"].UniversoDiscurso = new List<FuncionPertenencia>() {
							new FuncionSaturacion("altera_negativamente", -0.075, -0.075, -0.03),
							new FuncionTriangular("influye_negativamente", -0.06, -0.03, 0),
							new FuncionTriangular("influye_positivamente", 0, 0.03, 0.06),
							new FuncionSaturacion("altera_positivamente", 0.03, 0.075, 0.075),
						};
						break;
					case INF_SECRETARIAS:
						influencia.fuzzy.Salidas["influencia"].Rango(-0.2, 0.2);
						influencia.fuzzy.Salidas["influencia"].UniversoDiscurso = new List<FuncionPertenencia>() {
							new FuncionSaturacion("altera_negativamente", -0.075, -0.075, -0.03),
							new FuncionTriangular("influye_negativamente", -0.06, -0.03, 0),
							new FuncionTriangular("influye_positivamente", 0, 0.03, 0.06),
							new FuncionSaturacion("altera_positivamente", 0.03, 0.075, 0.075),
						};
						break;
					case INF_DIRECTOR_SECRETRIA:
						influencia.fuzzy.Salidas["influencia"].Rango(-0.3, 0.3);
						influencia.fuzzy.Salidas["influencia"].UniversoDiscurso = new List<FuncionPertenencia>() {
							new FuncionSaturacion("altera_negativamente", -0.075, -0.075, -0.03),
							new FuncionTriangular("influye_negativamente", -0.06, -0.03, 0),
							new FuncionTriangular("influye_positivamente", 0, 0.03, 0.06),
							new FuncionSaturacion("altera_positivamente", 0.03, 0.075, 0.075),
						};
						break;
					case INF_INVESTIGACION_POSTGRADO:
						influencia.fuzzy.Salidas["influencia"].Rango(-0.1, 0.1);
						influencia.fuzzy.Salidas["influencia"].UniversoDiscurso = new List<FuncionPertenencia>() {
							new FuncionSaturacion("altera_negativamente", -0.075, -0.075, -0.03),
							new FuncionTriangular("influye_negativamente", -0.06, -0.03, 0),
							new FuncionTriangular("influye_positivamente", 0, 0.03, 0.06),
							new FuncionSaturacion("altera_positivamente", 0.03, 0.075, 0.075),
						};
						break;
				}
				manejador_de_archivos.ingresarNuevaInfluencia(influencia);
				                             

			}
			
		}
		
	}
}
