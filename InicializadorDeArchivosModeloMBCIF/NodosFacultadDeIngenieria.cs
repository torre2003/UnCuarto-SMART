/*
 * Creado por SharpDevelop.
 * Usuario: usuario
 * Fecha: 15-07-2016
 * Hora: 18:11
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using AccesoADatos;
using FuzzyCore;
using ModeloMBCIF;
using ContenedorImplementacionesInterfacesCalculoModeloMBCIF;

namespace InicializadorDeArchivosModeloMBCIF
{
	/// <summary>
	/// Description of NodosFacultadDeIngenieria.
	/// </summary>
	public class NodosFacultadDeIngenieria
	{
		ManejadorDeDatosArchivos manejador_de_datos = new ManejadorDeDatosArchivos();
		public NodosFacultadDeIngenieria()
		{
			#region Nodo Academico Mauricio Godoy Seura
				//TODO nodo Academico Mauricio Godoy
				//___________________________________________________
				//_________________ Nodo academico Mauricio godoy Ceura _________
				//___________________________________________________
				Nodo academico_mauricio_godoy;
				academico_mauricio_godoy = new Nodo("n.amgs", "academico Mauricio Godoy Seura");
				academico_mauricio_godoy.fuzzy = new InferenciaDifusa(
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
				
        		academico_mauricio_godoy.agregarVariable("publicaciones isi-wos", Nodo.DATOS_INTERNOS);
				academico_mauricio_godoy.agregarVariable("publicaciones scielo", Nodo.DATOS_INTERNOS);
				academico_mauricio_godoy.agregarVariable("publicaciones equivalentes", Nodo.DATOS_INTERNOS);
        		academico_mauricio_godoy.agregarVariable("impacto", Nodo.DATOS_INTERNOS);
				
				academico_mauricio_godoy.agregarVariable("n.pisi", Nodo.NODOS_INFLUENCIADOS);
				academico_mauricio_godoy.agregarVariable("n.pscielo", Nodo.NODOS_INFLUENCIADOS);
				academico_mauricio_godoy.agregarVariable("n.pscielo", Nodo.NODOS_INFLUENCIADOS);

                academico_mauricio_godoy.calculos = new InterfaceCalculoProfesores();
				
				//Escribiendo nodos en archivo
				manejador_de_datos.ingresarNuevoNodo(academico_mauricio_godoy);
				Console.WriteLine("Nodo academico Mauricio Godoy Seura ingresado");
				
			#endregion	
				
			#region Nodo Academico Nelson Moraga
				//TODO nodo Academico Nelson Moraga
				//___________________________________________________
				//_________________ Nodo academico Nelson Moraga _________
				//___________________________________________________
				Nodo academico_nelson_moraga;
				academico_nelson_moraga = new Nodo("n.anm", "academico Nelson Moraga");
				academico_nelson_moraga.fuzzy = new InferenciaDifusa(
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
				
				academico_nelson_moraga.agregarVariable("publicaciones isi-wos", Nodo.DATOS_INTERNOS);
				academico_nelson_moraga.agregarVariable("publicaciones scielo", Nodo.DATOS_INTERNOS);
				academico_nelson_moraga.agregarVariable("publicaciones equivalentes", Nodo.DATOS_INTERNOS);
				academico_nelson_moraga.agregarVariable("impacto", Nodo.DATOS_INTERNOS);
				
				academico_nelson_moraga.agregarVariable("n.pisi", Nodo.NODOS_INFLUENCIADOS);
				academico_nelson_moraga.agregarVariable("n.pscielo", Nodo.NODOS_INFLUENCIADOS);	
				academico_nelson_moraga.agregarVariable("n.pe", Nodo.NODOS_INFLUENCIADOS);

                academico_nelson_moraga.calculos = new InterfaceCalculoProfesores();
				
				//Escribiendo nodos en archivo
				manejador_de_datos.ingresarNuevoNodo(academico_nelson_moraga);
				Console.WriteLine("Nodo academico Nelson Moraga ingresado");
					
			#endregion
			
			#region Nodo Academico Hector Paez
				//TODO nodo Academico Hector  Paez
				//___________________________________________________
				//_________________ Nodo academico Hector  Paez _________
				//___________________________________________________
				Nodo academico_hector_paez;
				academico_hector_paez = new Nodo("n.ahp", "academico Hector Paez");
				academico_hector_paez.fuzzy = new InferenciaDifusa(
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
				
				academico_hector_paez.agregarVariable("publicaciones isi-wos", Nodo.DATOS_INTERNOS);
				academico_hector_paez.agregarVariable("publicaciones scielo", Nodo.DATOS_INTERNOS);
				academico_hector_paez.agregarVariable("publicaciones equivalentes", Nodo.DATOS_INTERNOS);
				academico_hector_paez.agregarVariable("impacto", Nodo.DATOS_INTERNOS);
				
				academico_hector_paez.agregarVariable("n.pisi", Nodo.NODOS_INFLUENCIADOS);
				academico_hector_paez.agregarVariable("n.pscielo", Nodo.NODOS_INFLUENCIADOS);	
				academico_hector_paez.agregarVariable("n.pe", Nodo.NODOS_INFLUENCIADOS);

                academico_hector_paez.calculos = new InterfaceCalculoProfesores();
				
				//Escribiendo nodos en archivo
				manejador_de_datos.ingresarNuevoNodo(academico_hector_paez);
				Console.WriteLine("Nodo academico Hector Paez ingresado");
					
			#endregion
		}
	}
}
