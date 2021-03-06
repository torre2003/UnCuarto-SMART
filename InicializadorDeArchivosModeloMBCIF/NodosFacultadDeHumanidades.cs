﻿/*
 * Creado por SharpDevelop.
 * Usuario: usuario
 * Fecha: 15-07-2016
 * Hora: 20:02
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
	/// Description of NodosFacultadDeHumanidades.
	/// </summary>
	public class NodosFacultadDeHumanidades
	{
		
		ManejadorDeDatosArchivos manejador_de_datos = new ManejadorDeDatosArchivos();
		public List<Nodo> Nodos = new List<Nodo>();
		
		public NodosFacultadDeHumanidades()
		{
			#region Nodo Academico Cristian Noemi Padilla
				//TODO nodo Academico Cristian Noemi Padilla
				//___________________________________________________
				//_________________ Nodo academico Cristian Noemi Padilla _________
				//___________________________________________________
				Nodo academico_cristian_noemi;
				academico_cristian_noemi = new Nodo("nacnp", "Academico Cristian Noemi Padilla");
				academico_cristian_noemi.fuzzy = new InferenciaDifusa(
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
				
				academico_cristian_noemi.agregarVariable("publicaciones isi-wos", Nodo.DATOS_INTERNOS);
				academico_cristian_noemi.agregarVariable("publicaciones scielo", Nodo.DATOS_INTERNOS);
				academico_cristian_noemi.agregarVariable("publicaciones equivalentes", Nodo.DATOS_INTERNOS);
				academico_cristian_noemi.agregarVariable("impacto", Nodo.DATOS_INTERNOS);
				
				academico_cristian_noemi.agregarVariable("npisi", Nodo.NODOS_INFLUENCIADOS);
				academico_cristian_noemi.agregarVariable("npscielo", Nodo.NODOS_INFLUENCIADOS);	
				academico_cristian_noemi.agregarVariable("npe", Nodo.NODOS_INFLUENCIADOS);

		

			
                academico_cristian_noemi.calculos = new InterfaceCalculoProfesores();


					
			#endregion
			
			#region Nodo Academico Silvia Lopez de Maturana
				//TODO nodo Academico Silvia Lopez de Maturana
				//___________________________________________________
				//______Nodo academico Silvia Lopez de Maturana _________
				//___________________________________________________

				Nodo academico_silvia_lopez;
				academico_silvia_lopez = new Nodo("nasldm", "Academica Silvia Lopez de Maturana");
				academico_silvia_lopez.fuzzy = new InferenciaDifusa(
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
				

				academico_silvia_lopez.agregarVariable("publicaciones isi-wos", Nodo.DATOS_INTERNOS);
				academico_silvia_lopez.agregarVariable("publicaciones scielo", Nodo.DATOS_INTERNOS);
				academico_silvia_lopez.agregarVariable("publicaciones equivalentes", Nodo.DATOS_INTERNOS);
				academico_silvia_lopez.agregarVariable("impacto", Nodo.DATOS_INTERNOS);
				

				academico_silvia_lopez.agregarVariable("npisi", Nodo.NODOS_INFLUENCIADOS);
				academico_silvia_lopez.agregarVariable("npscielo", Nodo.NODOS_INFLUENCIADOS);	
				academico_silvia_lopez.agregarVariable("npe", Nodo.NODOS_INFLUENCIADOS);

	
				academico_silvia_lopez.calculos = new InterfaceCalculoProfesores();

			#endregion
			
			#region Nodo Academico Maria Ester Alvarez
				//TODO nodo Academico Maria Ester Alvarez
				//___________________________________________________
				//_________________ Nodo academico Maria Ester Alvarez _________
				//___________________________________________________
				Nodo academico_maria_ester_alvarez;
				academico_maria_ester_alvarez = new Nodo("namea", "Academico Maria Ester Alvarez");
				academico_maria_ester_alvarez.fuzzy = new InferenciaDifusa(
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
				
				academico_maria_ester_alvarez.agregarVariable("publicaciones isi-wos", Nodo.DATOS_INTERNOS);
				academico_maria_ester_alvarez.agregarVariable("publicaciones scielo", Nodo.DATOS_INTERNOS);
				academico_maria_ester_alvarez.agregarVariable("publicaciones equivalentes", Nodo.DATOS_INTERNOS);
				academico_maria_ester_alvarez.agregarVariable("impacto", Nodo.DATOS_INTERNOS);
				
				academico_maria_ester_alvarez.agregarVariable("npisi", Nodo.NODOS_INFLUENCIADOS);
				academico_maria_ester_alvarez.agregarVariable("npscielo", Nodo.NODOS_INFLUENCIADOS);	
				academico_maria_ester_alvarez.agregarVariable("npe", Nodo.NODOS_INFLUENCIADOS);

				
                academico_maria_ester_alvarez.calculos = new InterfaceCalculoProfesores();
			#endregion
				
			Nodos.Add(academico_cristian_noemi);
			Nodos.Add(academico_maria_ester_alvarez);
			Nodos.Add(academico_silvia_lopez);
			
				//Escribiendo nodos en archivo
			manejador_de_datos.ingresarNuevoNodo(academico_cristian_noemi);
			manejador_de_datos.ingresarNuevoNodo(academico_maria_ester_alvarez);
			manejador_de_datos.ingresarNuevoNodo(academico_silvia_lopez);
			Console.WriteLine("Nodos Academico Facultad Humanidades ingresados");
					
		}
	}
}
