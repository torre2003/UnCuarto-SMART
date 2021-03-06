﻿
using System;
using System.Collections.Generic;
using AccesoADatos;
using FuzzyCore;
using ModeloMBCIF;
using ContenedorImplementacionesInterfacesCalculoModeloMBCIF;

namespace InicializadorDeArchivosModeloMBCIF
{
    class NodosFacultadDeCiencias
    {
        ManejadorDeDatosArchivos manejador_de_datos = new ManejadorDeDatosArchivos();
		public List<Nodo> Nodos = new List<Nodo>();

        public NodosFacultadDeCiencias()
        {
			#region Nodo Academico Guillermo Saa Gamboa
				//TODO nodo Academico Guillermo Saa Gamboa
				//___________________________________________________
				//_________________ Nodo academico Guillermo Saa Gamboa _________
				//___________________________________________________
				Nodo academico_guillermo_saa;
				academico_guillermo_saa = new Nodo("nagsg", "Academico Guillermo Saa Gamboa");
				academico_guillermo_saa.fuzzy = new InferenciaDifusa(
                    //entradas
                    new Dictionary<string, VariableDifusa> { 
						{"publicaciones isi-wos", new VariableDifusa("publicaciones isi-wos", 0, 6,
								new List<FuncionPertenencia>() {
									new FuncionHombro("sin publicaciones", 0, 0.1, 0.11),
                                    new FuncionTrapezoidal("bajo", 0.11, 0.12, 2, 3),
									new FuncionTrapezoidal("medio", 2, 3, 4, 5),
									new FuncionSaturacion("alto", 4, 5, 6)
								})
						},
						{"publicaciones scielo", new VariableDifusa("publicaciones scielo", 0, 6,
								new List<FuncionPertenencia>() {
									new FuncionHombro("sin publicaciones", 0, 0.1, 0.11),
                                    new FuncionTrapezoidal("bajo", 0.11, 0.12, 2, 3),
									new FuncionTrapezoidal("medio", 2, 3, 4, 5),
									new FuncionSaturacion("alto", 4, 5, 6)
								})
						},
						{"publicaciones equivalentes", new VariableDifusa("publicaciones equivalentes", 0, 6,
								new List<FuncionPertenencia>() {
									new FuncionHombro("sin publicaciones", 0, 0.1, 0.11),
                                    new FuncionTrapezoidal("bajo", 0.11, 0.12, 2, 3),
									new FuncionTrapezoidal("medio", 2, 3, 4, 5),
									new FuncionSaturacion("alto", 4, 5, 6)
								})
						},
						{"impacto", new VariableDifusa("impacto", 0, 1,
								new List<FuncionPertenencia>() {
									new FuncionHombro("bajo", 0, 0.1, 0.2),
									new FuncionTrapezoidal("medio", 0.1,0.2,0.3,0.5),
									new FuncionSaturacion("alto", 0.3, 0.5, 1)
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
				
				academico_guillermo_saa.agregarVariable("publicaciones isi-wos", Nodo.DATOS_INTERNOS);
				academico_guillermo_saa.agregarVariable("publicaciones scielo", Nodo.DATOS_INTERNOS);
				academico_guillermo_saa.agregarVariable("publicaciones equivalentes", Nodo.DATOS_INTERNOS);
				academico_guillermo_saa.agregarVariable("impacto", Nodo.DATOS_INTERNOS);
				
				academico_guillermo_saa.agregarVariable("npisi", Nodo.NODOS_INFLUENCIADOS);
				academico_guillermo_saa.agregarVariable("npscielo", Nodo.NODOS_INFLUENCIADOS);	
				academico_guillermo_saa.agregarVariable("npe", Nodo.NODOS_INFLUENCIADOS);

				
                academico_guillermo_saa.calculos = new InterfaceCalculoProfesores();
				

					
			#endregion
			
			#region Nodo Academico Francisco Squeo
				//TODO nodo Academico Francisco Squeo
				//___________________________________________________
				//_________ Nodo academico Francisco Squeo _________
				//___________________________________________________
				Nodo academico_francisco_squeo;
				academico_francisco_squeo = new Nodo("nafs", "Academico Francisco Squeo");
				academico_francisco_squeo.fuzzy = new InferenciaDifusa(
                    //entradas
                    new Dictionary<string, VariableDifusa> { 
						{"publicaciones isi-wos", new VariableDifusa("publicaciones isi-wos", 0, 6,
								new List<FuncionPertenencia>() {
									new FuncionHombro("sin publicaciones", 0, 0.1, 0.11),
                                    new FuncionTrapezoidal("bajo", 0.11, 0.12, 2, 3),
									new FuncionTrapezoidal("medio", 2, 3, 4, 5),
									new FuncionSaturacion("alto", 4, 5, 6)
								})
						},
						{"publicaciones scielo", new VariableDifusa("publicaciones scielo", 0, 6,
								new List<FuncionPertenencia>() {
									new FuncionHombro("sin publicaciones", 0, 0.1, 0.11),
                                    new FuncionTrapezoidal("bajo", 0.11, 0.12, 2, 3),
									new FuncionTrapezoidal("medio", 2, 3, 4, 5),
									new FuncionSaturacion("alto", 4, 5, 6)
								})
						},
						{"publicaciones equivalentes", new VariableDifusa("publicaciones equivalentes", 0, 6,
								new List<FuncionPertenencia>() {
									new FuncionHombro("sin publicaciones", 0, 0.1, 0.11),
                                    new FuncionTrapezoidal("bajo", 0.11, 0.12, 2, 3),
									new FuncionTrapezoidal("medio", 2, 3, 4, 5),
									new FuncionSaturacion("alto", 4, 5, 6)
								})
						},
						{"impacto", new VariableDifusa("impacto", 0, 1,
								new List<FuncionPertenencia>() {
									new FuncionHombro("bajo", 0, 0.1, 0.2),
									new FuncionTrapezoidal("medio", 0.1,0.2,0.3,0.5),
									new FuncionSaturacion("alto", 0.3, 0.5, 1)
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
				
				academico_francisco_squeo.agregarVariable("publicaciones isi-wos", Nodo.DATOS_INTERNOS);
				academico_francisco_squeo.agregarVariable("publicaciones scielo", Nodo.DATOS_INTERNOS);
				academico_francisco_squeo.agregarVariable("publicaciones equivalentes", Nodo.DATOS_INTERNOS);
				academico_francisco_squeo.agregarVariable("impacto", Nodo.DATOS_INTERNOS);
				
				academico_francisco_squeo.agregarVariable("npisi", Nodo.NODOS_INFLUENCIADOS);
				academico_francisco_squeo.agregarVariable("npscielo", Nodo.NODOS_INFLUENCIADOS);	
				academico_francisco_squeo.agregarVariable("npe", Nodo.NODOS_INFLUENCIADOS);


                academico_francisco_squeo.calculos = new InterfaceCalculoProfesores();

					
			#endregion
			
			#region Nodo Academico Pedro Vega
				//TODO nodo Academico Pedro Vega
				//___________________________________________________
				//_______________ Nodo academico Pedro Vega _________
				//___________________________________________________
				Nodo academico_pedro_vega;
				academico_pedro_vega = new Nodo("napv", "Academico Pedro Vega");
				academico_pedro_vega.fuzzy = new InferenciaDifusa(
                    //entradas
                    new Dictionary<string, VariableDifusa> { 
						{"publicaciones isi-wos", new VariableDifusa("publicaciones isi-wos", 0, 6,
								new List<FuncionPertenencia>() {
									new FuncionHombro("sin publicaciones", 0, 0.1, 0.11),
                                    new FuncionTrapezoidal("bajo", 0.11, 0.12, 2, 3),
									new FuncionTrapezoidal("medio", 2, 3, 4, 5),
									new FuncionSaturacion("alto", 4, 5, 6)
								})
						},
						{"publicaciones scielo", new VariableDifusa("publicaciones scielo", 0, 6,
								new List<FuncionPertenencia>() {
									new FuncionHombro("sin publicaciones", 0, 0.1, 0.11),
                                    new FuncionTrapezoidal("bajo", 0.11, 0.12, 2, 3),
									new FuncionTrapezoidal("medio", 2, 3, 4, 5),
									new FuncionSaturacion("alto", 4, 5, 6)
								})
						},
						{"publicaciones equivalentes", new VariableDifusa("publicaciones equivalentes", 0, 6,
								new List<FuncionPertenencia>() {
									new FuncionHombro("sin publicaciones", 0, 0.1, 0.11),
                                    new FuncionTrapezoidal("bajo", 0.11, 0.12, 2, 3),
									new FuncionTrapezoidal("medio", 2, 3, 4, 5),
									new FuncionSaturacion("alto", 4, 5, 6)
								})
						},
						{"impacto", new VariableDifusa("impacto", 0, 1,
								new List<FuncionPertenencia>() {
									new FuncionHombro("bajo", 0, 0.1, 0.2),
									new FuncionTrapezoidal("medio", 0.1,0.2,0.3,0.5),
									new FuncionSaturacion("alto", 0.3, 0.5, 1)
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
				
				academico_pedro_vega.agregarVariable("publicaciones isi-wos", Nodo.DATOS_INTERNOS);
				academico_pedro_vega.agregarVariable("publicaciones scielo", Nodo.DATOS_INTERNOS);
				academico_pedro_vega.agregarVariable("publicaciones equivalentes", Nodo.DATOS_INTERNOS);
				academico_pedro_vega.agregarVariable("impacto", Nodo.DATOS_INTERNOS);
				
				academico_pedro_vega.agregarVariable("npisi", Nodo.NODOS_INFLUENCIADOS);
				academico_pedro_vega.agregarVariable("npscielo", Nodo.NODOS_INFLUENCIADOS);	
				academico_pedro_vega.agregarVariable("npe", Nodo.NODOS_INFLUENCIADOS);


                academico_pedro_vega.calculos = new InterfaceCalculoProfesores();
				

			#endregion
			
			#region Nodo Academico Marco Corgini
				//TODO nodo Academico Marco Corgini
				//___________________________________________________
				//_________________ Nodo academico Marco Corgini _________
				//___________________________________________________
				Nodo academico_marco_corgini;
				academico_marco_corgini = new Nodo("namc", "Academico Marco Corgini");
				academico_marco_corgini.fuzzy = new InferenciaDifusa(
                    //entradas
                    new Dictionary<string, VariableDifusa> { 
						{"publicaciones isi-wos", new VariableDifusa("publicaciones isi-wos", 0, 6,
								new List<FuncionPertenencia>() {
									new FuncionHombro("sin publicaciones", 0, 0.1, 0.11),
                                    new FuncionTrapezoidal("bajo", 0.11, 0.12, 2, 3),
									new FuncionTrapezoidal("medio", 2, 3, 4, 5),
									new FuncionSaturacion("alto", 4, 5, 6)
								})
						},
						{"publicaciones scielo", new VariableDifusa("publicaciones scielo", 0, 6,
								new List<FuncionPertenencia>() {
									new FuncionHombro("sin publicaciones", 0, 0.1, 0.11),
                                    new FuncionTrapezoidal("bajo", 0.11, 0.12, 2, 3),
									new FuncionTrapezoidal("medio", 2, 3, 4, 5),
									new FuncionSaturacion("alto", 4, 5, 6)
								})
						},
						{"publicaciones equivalentes", new VariableDifusa("publicaciones equivalentes", 0, 6,
								new List<FuncionPertenencia>() {
									new FuncionHombro("sin publicaciones", 0, 0.1, 0.11),
                                    new FuncionTrapezoidal("bajo", 0.11, 0.12, 2, 3),
									new FuncionTrapezoidal("medio", 2, 3, 4, 5),
									new FuncionSaturacion("alto", 4, 5, 6)
								})
						},
						{"impacto", new VariableDifusa("impacto", 0, 1,
								new List<FuncionPertenencia>() {
									new FuncionHombro("bajo", 0, 0.1, 0.2),
									new FuncionTrapezoidal("medio", 0.1,0.2,0.3,0.5),
									new FuncionSaturacion("alto", 0.3, 0.5, 1)
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
				
				academico_marco_corgini.agregarVariable("publicaciones isi-wos", Nodo.DATOS_INTERNOS);
				academico_marco_corgini.agregarVariable("publicaciones scielo", Nodo.DATOS_INTERNOS);
				academico_marco_corgini.agregarVariable("publicaciones equivalentes", Nodo.DATOS_INTERNOS);
				academico_marco_corgini.agregarVariable("impacto", Nodo.DATOS_INTERNOS);
				
				academico_marco_corgini.agregarVariable("npisi", Nodo.NODOS_INFLUENCIADOS);
				academico_marco_corgini.agregarVariable("npscielo", Nodo.NODOS_INFLUENCIADOS);	
				academico_marco_corgini.agregarVariable("npe", Nodo.NODOS_INFLUENCIADOS);


                academico_marco_corgini.calculos = new InterfaceCalculoProfesores();
				

			#endregion
			
			#region Nodo Academico Julia Arias
				//TODO nodo Academico Julia Arias
				//___________________________________________________
				//_________________ Nodo academico Julia Arias _________
				//___________________________________________________
				Nodo academico_julia_arias;
				academico_julia_arias = new Nodo("naja", "Academica Julia Arias");
				academico_julia_arias.fuzzy = new InferenciaDifusa(
                    //entradas
                    new Dictionary<string, VariableDifusa> { 
						{"publicaciones isi-wos", new VariableDifusa("publicaciones isi-wos", 0, 6,
								new List<FuncionPertenencia>() {
									new FuncionHombro("sin publicaciones", 0, 0.1, 0.11),
                                    new FuncionTrapezoidal("bajo", 0.11, 0.12, 2, 3),
									new FuncionTrapezoidal("medio", 2, 3, 4, 5),
									new FuncionSaturacion("alto", 4, 5, 6)
								})
						},
						{"publicaciones scielo", new VariableDifusa("publicaciones scielo", 0, 6,
								new List<FuncionPertenencia>() {
									new FuncionHombro("sin publicaciones", 0, 0.1, 0.11),
                                    new FuncionTrapezoidal("bajo", 0.11, 0.12, 2, 3),
									new FuncionTrapezoidal("medio", 2, 3, 4, 5),
									new FuncionSaturacion("alto", 4, 5, 6)
								})
						},
						{"publicaciones equivalentes", new VariableDifusa("publicaciones equivalentes", 0, 6,
								new List<FuncionPertenencia>() {
									new FuncionHombro("sin publicaciones", 0, 0.1, 0.11),
                                    new FuncionTrapezoidal("bajo", 0.11, 0.12, 2, 3),
									new FuncionTrapezoidal("medio", 2, 3, 4, 5),
									new FuncionSaturacion("alto", 4, 5, 6)
								})
						},
						{"impacto", new VariableDifusa("impacto", 0, 1,
								new List<FuncionPertenencia>() {
									new FuncionHombro("bajo", 0, 0.1, 0.2),
									new FuncionTrapezoidal("medio", 0.1,0.2,0.3,0.5),
									new FuncionSaturacion("alto", 0.3, 0.5, 1)
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
				
				academico_julia_arias.agregarVariable("publicaciones isi-wos", Nodo.DATOS_INTERNOS);
				academico_julia_arias.agregarVariable("publicaciones scielo", Nodo.DATOS_INTERNOS);
				academico_julia_arias.agregarVariable("publicaciones equivalentes", Nodo.DATOS_INTERNOS);
				academico_julia_arias.agregarVariable("impacto", Nodo.DATOS_INTERNOS);
				
				academico_julia_arias.agregarVariable("npisi", Nodo.NODOS_INFLUENCIADOS);
				academico_julia_arias.agregarVariable("npscielo", Nodo.NODOS_INFLUENCIADOS);	
				academico_julia_arias.agregarVariable("npe", Nodo.NODOS_INFLUENCIADOS);


                academico_julia_arias.calculos = new InterfaceCalculoProfesores();
				

			#endregion
			
			#region Nodo Academico Ivan Fernandez
				//TODO nodo Academico Ivan Fernandez
				//___________________________________________________
				//_________________ Nodo academico Ivan Fernandez _________
				//___________________________________________________
				Nodo academico_ivan_fernandez;
				academico_ivan_fernandez = new Nodo("naif", "Academico Ivan Fernandez");
				academico_ivan_fernandez.fuzzy = new InferenciaDifusa(
                    //entradas
                    new Dictionary<string, VariableDifusa> { 
						{"publicaciones isi-wos", new VariableDifusa("publicaciones isi-wos", 0, 6,
								new List<FuncionPertenencia>() {
									new FuncionHombro("sin publicaciones", 0, 0.1, 0.11),
                                    new FuncionTrapezoidal("bajo", 0.11, 0.12, 2, 3),
									new FuncionTrapezoidal("medio", 2, 3, 4, 5),
									new FuncionSaturacion("alto", 4, 5, 6)
								})
						},
						{"publicaciones scielo", new VariableDifusa("publicaciones scielo", 0, 6,
								new List<FuncionPertenencia>() {
									new FuncionHombro("sin publicaciones", 0, 0.1, 0.11),
                                    new FuncionTrapezoidal("bajo", 0.11, 0.12, 2, 3),
									new FuncionTrapezoidal("medio", 2, 3, 4, 5),
									new FuncionSaturacion("alto", 4, 5, 6)
								})
						},
						{"publicaciones equivalentes", new VariableDifusa("publicaciones equivalentes", 0, 6,
								new List<FuncionPertenencia>() {
									new FuncionHombro("sin publicaciones", 0, 0.1, 0.11),
                                    new FuncionTrapezoidal("bajo", 0.11, 0.12, 2, 3),
									new FuncionTrapezoidal("medio", 2, 3, 4, 5),
									new FuncionSaturacion("alto", 4, 5, 6)
								})
						},
						{"impacto", new VariableDifusa("impacto", 0, 1,
								new List<FuncionPertenencia>() {
									new FuncionHombro("bajo", 0, 0.1, 0.2),
									new FuncionTrapezoidal("medio", 0.1,0.2,0.3,0.5),
									new FuncionSaturacion("alto", 0.3, 0.5, 1)
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
				
				academico_ivan_fernandez.agregarVariable("publicaciones isi-wos", Nodo.DATOS_INTERNOS);
				academico_ivan_fernandez.agregarVariable("publicaciones scielo", Nodo.DATOS_INTERNOS);
				academico_ivan_fernandez.agregarVariable("publicaciones equivalentes", Nodo.DATOS_INTERNOS);
				academico_ivan_fernandez.agregarVariable("impacto", Nodo.DATOS_INTERNOS);
				
				academico_ivan_fernandez.agregarVariable("npisi", Nodo.NODOS_INFLUENCIADOS);
				academico_ivan_fernandez.agregarVariable("npscielo", Nodo.NODOS_INFLUENCIADOS);	
				academico_ivan_fernandez.agregarVariable("npe", Nodo.NODOS_INFLUENCIADOS);

				academico_ivan_fernandez.calculos = new InterfaceCalculoProfesores();
			#endregion
				
			// lista para crear influencias
			Nodos.Add(academico_julia_arias);
			Nodos.Add(academico_marco_corgini);
			Nodos.Add(academico_pedro_vega);
			Nodos.Add(academico_francisco_squeo);
			Nodos.Add(academico_guillermo_saa);
			Nodos.Add(academico_ivan_fernandez);
			
			//Escribiendo nodos en archivo
			manejador_de_datos.ingresarNuevoNodo(academico_julia_arias);
			manejador_de_datos.ingresarNuevoNodo(academico_marco_corgini);
			manejador_de_datos.ingresarNuevoNodo(academico_pedro_vega);
			manejador_de_datos.ingresarNuevoNodo(academico_francisco_squeo);
			manejador_de_datos.ingresarNuevoNodo(academico_guillermo_saa);
			manejador_de_datos.ingresarNuevoNodo(academico_ivan_fernandez);

			Console.WriteLine("Nodos Academicos Facultad Ciencias ingresados");
					
        }
    }
}
