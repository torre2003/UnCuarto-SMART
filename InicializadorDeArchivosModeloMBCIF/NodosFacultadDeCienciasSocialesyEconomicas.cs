/*
 * Creado por SharpDevelop.
 * Usuario: usuario
 * Fecha: 15-07-2016
 * Hora: 15:32
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using AccesoADatos;
using FuzzyCore;
using ModeloMBCIF;

namespace InicializadorDeArchivosModeloMBCIF
{
	/// <summary>
	/// Description of NodosFacultadDeCienciasSocialesyEconomicas.
	/// </summary>
	public class NodosFacultadDeCienciasSocialesyEconomicas
	{
		
		ManejadorDeDatosArchivos manejador_de_datos = new ManejadorDeDatosArchivos();
		public List<Nodo> Nodos = new List<Nodo>();
		
		public NodosFacultadDeCienciasSocialesyEconomicas()
		{
			
			#region Nodo Academico Luperfina Rojas
				//TODO nodo Academico luperfina rojas
				//___________________________________________________
				//_________________ Nodo academico_luperfina rojas _________
				//___________________________________________________
				Nodo academico_luperfina_rojas;
				academico_luperfina_rojas = new Nodo("n.alr", "academica Luperfina Rojas");
				academico_luperfina_rojas.fuzzy = new InferenciaDifusa(
					//entradas
					new Dictionary<string, VariableDifusa> { 
						{"publicaciones isi-wos", new VariableDifusa("publicaciones isi-wos", 0, 6,
								new List<FuncionPertenencia>() {
									new FuncionHombro("bajo", 0, 2, 3),
									new FuncionTrapezoidal("medio", 2, 3, 4, 5),
									new FuncionSaturacion("alto", 4, 5, 6)
								})
						},
             			{"publicaciones scielo", new VariableDifusa("publicaciones scielo", 0, 6,
								new List<FuncionPertenencia>() {
									new FuncionHombro("bajo", 0, 2, 3),
									new FuncionTrapezoidal("medio", 2, 3, 4, 5),
									new FuncionSaturacion("alto", 4, 5, 6)
								})
						},
						{"publicaciones equivalentes", new VariableDifusa("publicaciones equivalentes", 0, 6,
								new List<FuncionPertenencia>() {
									new FuncionHombro("bajo", 0, 2, 3),
									new FuncionTrapezoidal("medio", 2, 3, 4, 5),
									new FuncionSaturacion("alto", 4, 5, 6)
								})
						},
						{"impacto", new VariableDifusa("impacto", 0, 1,
								new List<FuncionPertenencia>() {
									new FuncionHombro("bajo", 0, 0.1, 0.3),
									new FuncionTrapezoidal("medio", 0.1,0.3,0.4,0.6),
									new FuncionSaturacion("alto", 0.4, 0.6, 1)
								})
						}                                                             
                                                              
					},

					//salidas
					new Dictionary<string, VariableDifusa> { 
						{"estado", new VariableDifusa("estado", 0, 1,
								new List<FuncionPertenencia>() {
									new FuncionHombro("pesimo", 0, 0.1, 0.3),
									new FuncionTriangular("malo", 0.1, 0.3, 0.5),
									new FuncionTriangular("regular", 0.3, 0.5, 0.7),
									new FuncionTriangular("bueno", 0.5, 0.7, 0.9),
									new FuncionSaturacion("excelente", 0.7, 0.9, 1)
								})
						}
					}
				);
				
        		academico_luperfina_rojas.agregarVariable("publicaciones isi-wos", Nodo.DATOS_INTERNOS);
				academico_luperfina_rojas.agregarVariable("publicaciones scielo", Nodo.DATOS_INTERNOS);
				academico_luperfina_rojas.agregarVariable("publicaciones equivalentes", Nodo.DATOS_INTERNOS);
        		academico_luperfina_rojas.agregarVariable("impacto", Nodo.DATOS_INTERNOS);
				
				academico_luperfina_rojas.agregarVariable("n.pisi", Nodo.NODOS_INFLUENCIADOS);
				academico_luperfina_rojas.agregarVariable("n.pscielo", Nodo.NODOS_INFLUENCIADOS);	

				//postitulo_en_algo.calculos = new ICalculosNodo_postitulo_en_algo();
				
			#endregion	
				
			#region Nodo Academico Alberto Hernandez
				//TODO nodo Academico Alberto Hernandez
				//___________________________________________________
				//_________ Nodo academico Alberto Hernandez _________
				//___________________________________________________
				Nodo academico_alberto_hernandez;
				academico_alberto_hernandez = new Nodo("n.aah", "academico Alberto Hernandez");
				academico_alberto_hernandez.fuzzy = new InferenciaDifusa(
					//entradas
					new Dictionary<string, VariableDifusa> { 
						{"publicaciones isi-wos", new VariableDifusa("publicaciones isi-wos", 0, 6,
								new List<FuncionPertenencia>() {
									new FuncionHombro("bajo", 0, 2, 3),
									new FuncionTrapezoidal("medio", 2, 3, 4, 5),
									new FuncionSaturacion("alto", 4, 5, 6)
								})
						},
             			{"publicaciones scielo", new VariableDifusa("publicaciones scielo", 0, 6,
								new List<FuncionPertenencia>() {
									new FuncionHombro("bajo", 0, 2, 3),
									new FuncionTrapezoidal("medio", 2, 3, 4, 5),
									new FuncionSaturacion("alto", 4, 5, 6)
								})
						},
						{"publicaciones equivalentes", new VariableDifusa("publicaciones equivalentes", 0, 6,
								new List<FuncionPertenencia>() {
									new FuncionHombro("bajo", 0, 2, 3),
									new FuncionTrapezoidal("medio", 2, 3, 4, 5),
									new FuncionSaturacion("alto", 4, 5, 6)
								})
						},
						{"impacto", new VariableDifusa("impacto", 0, 1,
								new List<FuncionPertenencia>() {
									new FuncionHombro("bajo", 0, 0.1, 0.3),
									new FuncionTrapezoidal("medio", 0.1,0.3,0.4,0.6),
									new FuncionSaturacion("alto", 0.4, 0.6, 1)
								})
						}                                                             
                                                              
					},

					//salidas
					new Dictionary<string, VariableDifusa> { 
						{"estado", new VariableDifusa("estado", 0, 1,
								new List<FuncionPertenencia>() {
									new FuncionHombro("pesimo", 0, 0.1, 0.3),
									new FuncionTriangular("malo", 0.1, 0.3, 0.5),
									new FuncionTriangular("regular", 0.3, 0.5, 0.7),
									new FuncionTriangular("bueno", 0.5, 0.7, 0.9),
									new FuncionSaturacion("excelente", 0.7, 0.9, 1)
								})
						}
					}
				);
				
        		academico_alberto_hernandez.agregarVariable("publicaciones isi-wos", Nodo.DATOS_INTERNOS);
				academico_alberto_hernandez.agregarVariable("publicaciones scielo", Nodo.DATOS_INTERNOS);
				academico_alberto_hernandez.agregarVariable("publicaciones equivalentes", Nodo.DATOS_INTERNOS);
        		academico_alberto_hernandez.agregarVariable("impacto", Nodo.DATOS_INTERNOS);
				
				academico_alberto_hernandez.agregarVariable("n.pisi", Nodo.NODOS_INFLUENCIADOS);
				academico_alberto_hernandez.agregarVariable("n.pscielo", Nodo.NODOS_INFLUENCIADOS);	
				academico_alberto_hernandez.agregarVariable("n.pe", Nodo.NODOS_INFLUENCIADOS);

				//postitulo_en_algo.calculos = new ICalculosNodo_postitulo_en_algo();
			#endregion
			
			Nodos.Add(academico_luperfina_rojas);
			Nodos.Add(academico_alberto_hernandez);
				
			//Escribiendo nodos en archivo
			manejador_de_datos.ingresarNuevoNodo(academico_luperfina_rojas);
			manejador_de_datos.ingresarNuevoNodo(academico_alberto_hernandez);
			Console.WriteLine("Nodos Academicos FACSE ingresados");
	
		}
	}
}
