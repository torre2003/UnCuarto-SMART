/*
 * Creado por SharpDevelop.
 * Usuario: usuario
 * Fecha: 14-07-2016
 * Hora: 21:39
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificacion | Editar Encabezados Estandar
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
	/// Description of NodossPostitulos.
	/// </summary>
	public class NodosPostitulos
	{
		
		ManejadorDeDatosArchivos manejador_de_datos = new ManejadorDeDatosArchivos();

		
		public NodosPostitulos()
		{
			
			#region Diplomado Interdisciplinario en innovacion educativa
				#region Nodo Diplomado
				//TODO nodo Diplomado Interdisciplinario en innovacion educativa
				//___________________________________________________
				//_________________ Nodo Diplomado Interdisciplinario en innovacion educativa _________
				//___________________________________________________
				Nodo diplomado_innovacion_educativa;
				diplomado_innovacion_educativa = new Nodo("ndieie", "Diplomado Interdisciplinario en Innovacion Educativa");
				diplomado_innovacion_educativa.fuzzy = new InferenciaDifusa(
					//entradas
					new Dictionary<string, VariableDifusa> { 
						{"matricula alumnos", new VariableDifusa("matricula alumnos", 0, 20,
								new List<FuncionPertenencia>() {
									new FuncionHombro("poco", 0, 4, 8),
									new FuncionTrapezoidal("optimo", 4, 8, 12, 16),
                                    new FuncionSaturacion("excedido", 12, 16, 20)
								})
						}, {"acreditacion", new VariableDifusa("acreditacion", 0, 10,
								new List<FuncionPertenencia>() {
									new FuncionHombro("sin_acreditacion", 0, 0.1, 0.1),
									new FuncionTrapezoidal("periodo_corto", 1, 1, 2, 3),
									new FuncionTrapezoidal("periodo_medio", 2, 3, 5, 6),
									new FuncionSaturacion("periodo_prolongado", 5, 6, 10)
								})
						},
						/* id del nodo Nivel Academico */
						{"nnadieie", new VariableDifusa("nnadieie", 0, 1,
								new List<FuncionPertenencia>() {
									new FuncionHombro("normal", 0, 0.3, 0.4),
									new FuncionTrapezoidal("alto", 0.3, 0.4, 0.5, 0.6),
									new FuncionSaturacion("muy_alto", 0.5, 0.6, 1)
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
				diplomado_innovacion_educativa.agregarVariable("matricula alumnos", Nodo.DATOS_INTERNOS);
				diplomado_innovacion_educativa.agregarVariable("acreditacion", Nodo.DATOS_INTERNOS);
				
				diplomado_innovacion_educativa.agregarVariable("nnadieie", Nodo.DATOS_NODOS_EXTERNOS);


                diplomado_innovacion_educativa.agregarVariable("i_ndp_ndieie", Nodo.INFLUENCIAS_EXTERNAS);


                diplomado_innovacion_educativa.calculos = new ICalculosNodo_programas("nnadieie");
				
				#endregion
			
				#region Nivel Academico
				//______________________________________________________________________________________________________
				//_________________ Nodo Nivel academico Diplomado Interdisciplinario en innovacion educativa _________
				//______________________________________________________________________________________________________
				Nodo nivel_academico_diplomado_innovacion_educativa;
				nivel_academico_diplomado_innovacion_educativa = new Nodo("nnadieie", "Nivel Academicos Diplomado Interdisciplinario en Innovacion Educativa");
				nivel_academico_diplomado_innovacion_educativa.fuzzy = new InferenciaDifusa(
					//entradas
					new Dictionary<string, VariableDifusa> { 
						/* Silvia Lopez de Maturana */
						{"nasldm", new VariableDifusa("nasldm", 0, 1,
								new List<FuncionPertenencia>() {
									new FuncionHombro("calificado", 0, 0.2, 0.4),
									new FuncionTrapezoidal("destacado", 0.2, 0.4, 0.7, 0.9),
									new FuncionSaturacion("eminente", 0.7, 0.9, 1.0)
								})
						}/*, {"docente 2", new VariableDifusa("docente 2", 0, 1,
								new List<FuncionPertenencia>() {
									new FuncionHombro("calificado", 0, 0.2, 0.4),
									new FuncionTrapezoidal("destacado", 0.2, 0.4, 0.7, 0.9),
									new FuncionSaturacion("eminente", 0.7, 0.9, 1.0)
								})
						}*/},
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
						
						
				nivel_academico_diplomado_innovacion_educativa.agregarVariable("nasldm", Nodo.DATOS_NODOS_EXTERNOS);
				//nivel_academico_postitulo_en_algo.agregarVariable("docente 2", Nodo.DATOS_NODOS_EXTERNOS);


                nivel_academico_diplomado_innovacion_educativa.calculos = new InterfaceCalculoNivelesAcademicos(new string[] { "nasldm" });
											

				#endregion	
			#endregion
			
			#region Diplomado Gestion Tributaria
				#region Nodo Diplomado
				//TODO nodo Diplomado Gestion Tributaria
				//___________________________________________________
                //_________________ Nodo diplomado_gestion_tributaria _________
				//___________________________________________________
				Nodo diplomado_gestion_tributaria;
				diplomado_gestion_tributaria = new Nodo("ndegt", "Diplomado en Gestion Tributaria");
				diplomado_gestion_tributaria.fuzzy = new InferenciaDifusa(
					//entradas
					new Dictionary<string, VariableDifusa> { 
						{"matricula alumnos", new VariableDifusa("matricula alumnos", 0, 20,
								new List<FuncionPertenencia>() {
									new FuncionHombro("poco", 0, 4, 8),
									new FuncionTrapezoidal("optimo", 4, 8, 12, 16),
									new FuncionSaturacion("excedido", 12, 16, 20)
								})
						}, {"acreditacion", new VariableDifusa("acreditacion", 0, 10,
								new List<FuncionPertenencia>() {
									new FuncionHombro("sin_acreditacion", 0, 0.1, 0.1),
									new FuncionTrapezoidal("periodo_corto", 1, 1, 2, 3),
									new FuncionTrapezoidal("periodo_medio", 2, 3, 5, 6),
									new FuncionSaturacion("periodo_prolongado", 5, 6, 10)
								})
						},
						/*nodo Nivel Academico */
						{"nnadegt", new VariableDifusa("nnadegt", 0, 1,
								new List<FuncionPertenencia>() {
									new FuncionHombro("normal", 0, 0.3, 0.4),
									new FuncionTrapezoidal("alto", 0.3, 0.4, 0.5, 0.6),
									new FuncionSaturacion("muy_alto", 0.5, 0.6, 1)
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
				diplomado_gestion_tributaria.agregarVariable("matricula alumnos", Nodo.DATOS_INTERNOS);
				diplomado_gestion_tributaria.agregarVariable("acreditacion", Nodo.DATOS_INTERNOS);
				
				diplomado_gestion_tributaria.agregarVariable("nnadegt", Nodo.DATOS_NODOS_EXTERNOS);


                diplomado_gestion_tributaria.agregarVariable("i_ndp_ndegt", Nodo.INFLUENCIAS_EXTERNAS);

                diplomado_gestion_tributaria.calculos = new ICalculosNodo_programas("nnadegt");
				
				#endregion
			
				#region Nivel Academico
				//______________________________________________________________________________________________________
				//_________________ Nodo Nivel academico diplomado en gestion tributaria _________
				//______________________________________________________________________________________________________
				Nodo nivel_academico_diplomado_gestion_tributaria;
				nivel_academico_diplomado_gestion_tributaria = new Nodo("nnadegt", "Nivel Academico Diplomado en Gestion Tributaria");
				nivel_academico_diplomado_gestion_tributaria.fuzzy = new InferenciaDifusa(
					//entradas
					new Dictionary<string, VariableDifusa> { 
						/*Albero Hernandez */
						{"naah", new VariableDifusa("naah", 0, 1,
								new List<FuncionPertenencia>() {
									new FuncionHombro("calificado", 0, 0.2, 0.4),
									new FuncionTrapezoidal("destacado", 0.2, 0.4, 0.7, 0.9),
									new FuncionSaturacion("eminente", 0.7, 0.9, 1.0)
								})
						}/*, {"ndocente 2", new VariableDifusa("ndocente 2", 0, 1,
								new List<FuncionPertenencia>() {
									new FuncionHombro("calificado", 0, 0.2, 0.4),
									new FuncionTrapezoidal("destacado", 0.2, 0.4, 0.7, 0.9),
									new FuncionSaturacion("eminente", 0.7, 0.9, 1.0)
								})
						}*/},
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
						
						
				nivel_academico_diplomado_gestion_tributaria.agregarVariable("naah", Nodo.DATOS_NODOS_EXTERNOS);
				//nivel_academico_postitulo_en_algo.agregarVariable("ndocente 2", Nodo.DATOS_NODOS_EXTERNOS);


                nivel_academico_diplomado_gestion_tributaria.calculos = new InterfaceCalculoNivelesAcademicos(new string[] { "naah" });
						

				#endregion	
			#endregion
			
			#region Postitulo Mencion para Docentes que ejercen en segundo ciclo de Enseñanza basica para Profesores en la Asignatura de Ciencias Naturales
				#region Nodo Postitulo
				//TODO nodo Postitulo mencion docentes bla bla.....
				//___________________________________________________
				//_________________ Nodo Postitulo mencion docentes _________
				//___________________________________________________
				Nodo postitulo_mencion_docentes_s_ciclo;
				postitulo_mencion_docentes_s_ciclo = new Nodo("npmpdqeescdebppelacn", "Postitulo Mencion para Docentes que ejercen en segundo ciclo de Enseñanza basica para Profesores en la Asignatura de Ciencias Naturales");
				postitulo_mencion_docentes_s_ciclo.fuzzy = new InferenciaDifusa(
					//entradas
					new Dictionary<string, VariableDifusa> { 
						{"matricula alumnos", new VariableDifusa("matricula alumnos", 0, 60,
								new List<FuncionPertenencia>() {
									new FuncionHombro("poco", 0, 15, 25),
									new FuncionTrapezoidal("optimo", 15, 25, 35, 45),
                                    new FuncionSaturacion("excedido", 35, 45, 60)
								})
						}, {"acreditacion", new VariableDifusa("acreditacion", 0, 10,
								new List<FuncionPertenencia>() {
									new FuncionHombro("sin_acreditacion", 0, 0.1, 0.1),
									new FuncionTrapezoidal("periodo_corto", 1, 1, 2, 3),
									new FuncionTrapezoidal("periodo_medio", 2, 3, 5, 6),
									new FuncionSaturacion("periodo_prolongado", 5, 6, 10)
								})
						},
						/*nodo Nivel Academico */
						{"nnapmpdqeescdebppelacn", new VariableDifusa("nnapmpdqeescdebppelacn", 0, 1,
								new List<FuncionPertenencia>() {
									new FuncionHombro("normal", 0, 0.3, 0.4),
									new FuncionTrapezoidal("alto", 0.3, 0.4, 0.5, 0.6),
									new FuncionSaturacion("muy_alto", 0.5, 0.6, 1)
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
				postitulo_mencion_docentes_s_ciclo.agregarVariable("matricula alumnos", Nodo.DATOS_INTERNOS);
				postitulo_mencion_docentes_s_ciclo.agregarVariable("acreditacion", Nodo.DATOS_INTERNOS);
				
				postitulo_mencion_docentes_s_ciclo.agregarVariable("nnapmpdqeescdebppelacn", Nodo.DATOS_NODOS_EXTERNOS);

			
                postitulo_mencion_docentes_s_ciclo.agregarVariable("i_ndp_npmpdqeescdebppelacn", Nodo.INFLUENCIAS_EXTERNAS);


                postitulo_mencion_docentes_s_ciclo.calculos = new ICalculosNodo_programas("nnapmpdqeescdebppelacn");
				
				#endregion
			
				#region Nivel Academico
				//______________________________________________________________________________________________________
				//_________________ Nodo Nivel academico postitulo_en_algo _________
				//______________________________________________________________________________________________________
				Nodo nivel_academico_postitulo_mencion_docentes_s_ciclo;
				nivel_academico_postitulo_mencion_docentes_s_ciclo = new Nodo("nnapmpdqeescdebppelacn", "Nivel Academicos Postitulo Mencion para Docentes que ejercen en segundo ciclo de Enseñanza basica para Profesores en la Asignatura de Ciencias Naturales");
				nivel_academico_postitulo_mencion_docentes_s_ciclo.fuzzy = new InferenciaDifusa(
					//entradas
					new Dictionary<string, VariableDifusa> { 
						/* 	Maria Ester Alvarez */
						{"namea", new VariableDifusa("namea", 0, 1,
								new List<FuncionPertenencia>() {
									new FuncionHombro("calificado", 0, 0.2, 0.4),
									new FuncionTrapezoidal("destacado", 0.2, 0.4, 0.7, 0.9),
									new FuncionSaturacion("eminente", 0.7, 0.9, 1.0)
								})
						}/*, {"ndocente 2", new VariableDifusa("ndocente 2", 0, 1,
								new List<FuncionPertenencia>() {
									new FuncionHombro("calificado", 0, 0.2, 0.4),
									new FuncionTrapezoidal("destacado", 0.2, 0.4, 0.7, 0.9),
									new FuncionSaturacion("eminente", 0.7, 0.9, 1.0)
								})
						}*/},
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
						
						
				nivel_academico_postitulo_mencion_docentes_s_ciclo.agregarVariable("namea", Nodo.DATOS_NODOS_EXTERNOS);
				//nivel_academico_postitulo_en_algo.agregarVariable("ndocente 2", Nodo.DATOS_NODOS_EXTERNOS);


                nivel_academico_postitulo_mencion_docentes_s_ciclo.calculos = new InterfaceCalculoNivelesAcademicos(new string[] { "namea" });
						

				#endregion	
			#endregion		
			
			#region Diplomado en Eficiencia Energetica
				#region Nodo Diplomado
				
				//TODO nodo Diplomado en Eficiencia Energetica
				//___________________________________________________
				//______ Nodo Diplomado en Eficiencia Energetica _________
				//___________________________________________________
				Nodo diplomado_en_eficiencia_energetica;
				diplomado_en_eficiencia_energetica = new Nodo("ndeee", "Diplomado en Eficiencia Energetica");
				diplomado_en_eficiencia_energetica.fuzzy = new InferenciaDifusa(
					//entradas
					new Dictionary<string, VariableDifusa> { 
						{"matricula alumnos", new VariableDifusa("matricula alumnos", 0, 60,
								new List<FuncionPertenencia>() {
									new FuncionHombro("poco", 0, 15, 25),
									new FuncionTrapezoidal("optimo", 15, 25, 35, 45),
                                    new FuncionSaturacion("excedido", 35, 45, 60)
								})
						}, {"acreditacion", new VariableDifusa("acreditacion", 0, 10,
								new List<FuncionPertenencia>() {
									new FuncionHombro("sin_acreditacion", 0, 0.1, 0.1),
									new FuncionTrapezoidal("periodo_corto", 1, 1, 2, 3),
									new FuncionTrapezoidal("periodo_medio", 2, 3, 5, 6),
									new FuncionSaturacion("periodo_prolongado", 5, 6, 10)
								})
						},
						/*nodo Nivel Academico */
						{"nnadeee", new VariableDifusa("nnadeee", 0, 1,
								new List<FuncionPertenencia>() {
									new FuncionHombro("normal", 0, 0.3, 0.4),
									new FuncionTrapezoidal("alto", 0.3, 0.4, 0.5, 0.6),
									new FuncionSaturacion("muy_alto", 0.5, 0.6, 1)
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
				diplomado_en_eficiencia_energetica.agregarVariable("matricula alumnos", Nodo.DATOS_INTERNOS);
				diplomado_en_eficiencia_energetica.agregarVariable("acreditacion", Nodo.DATOS_INTERNOS);
				
				diplomado_en_eficiencia_energetica.agregarVariable("nnadeee", Nodo.DATOS_NODOS_EXTERNOS);

			
                diplomado_en_eficiencia_energetica.agregarVariable("i_ndp_ndeee", Nodo.INFLUENCIAS_EXTERNAS);


                diplomado_en_eficiencia_energetica.calculos = new ICalculosNodo_programas("nnadeee");
				
				#endregion
			
				#region Nivel Academico
				//______________________________________________________________________________________________________
				//_________________ Nodo Nivel academico Diplomado en Eficiencia Energetica _________
				//______________________________________________________________________________________________________
				Nodo nivel_academico_diplomado_en_eficiencia_energetica;
				nivel_academico_diplomado_en_eficiencia_energetica = new Nodo("nnadeee", "Nivel Academico Diplomado en Eficiencia Energetica");
				nivel_academico_diplomado_en_eficiencia_energetica.fuzzy = new InferenciaDifusa(
					//entradas
					new Dictionary<string, VariableDifusa> { 
						/* Nelson Moraga */
						{"nanm", new VariableDifusa("nanm", 0, 1,
								new List<FuncionPertenencia>() {
									new FuncionHombro("calificado", 0, 0.2, 0.4),
									new FuncionTrapezoidal("destacado", 0.2, 0.4, 0.7, 0.9),
									new FuncionSaturacion("eminente", 0.7, 0.9, 1.0)
								})
						}/*, {"ndocente 2", new VariableDifusa("ndocente 2", 0, 1,
								new List<FuncionPertenencia>() {
									new FuncionHombro("calificado", 0, 0.2, 0.4),
									new FuncionTrapezoidal("destacado", 0.2, 0.4, 0.7, 0.9),
									new FuncionSaturacion("eminente", 0.7, 0.9, 1.0)
								})
						}*/},
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
						
						
				nivel_academico_diplomado_en_eficiencia_energetica.agregarVariable("nanm", Nodo.DATOS_NODOS_EXTERNOS);
				//nivel_academico_diplomado_en_eficiencia_energetica.agregarVariable("ndocente 2", Nodo.DATOS_NODOS_EXTERNOS);

	
                nivel_academico_diplomado_en_eficiencia_energetica.calculos = new InterfaceCalculoNivelesAcademicos(new string[] { "nanm" });
				#endregion	
			#endregion
						

		
				//Escribiendo nodos en archivo
			manejador_de_datos.ingresarNuevoNodo(diplomado_innovacion_educativa);
			manejador_de_datos.ingresarNuevoNodo(nivel_academico_diplomado_innovacion_educativa);
			manejador_de_datos.ingresarNuevoNodo(diplomado_gestion_tributaria);
			manejador_de_datos.ingresarNuevoNodo(nivel_academico_diplomado_gestion_tributaria);
			manejador_de_datos.ingresarNuevoNodo(postitulo_mencion_docentes_s_ciclo);
			manejador_de_datos.ingresarNuevoNodo(nivel_academico_postitulo_mencion_docentes_s_ciclo);
			manejador_de_datos.ingresarNuevoNodo(diplomado_en_eficiencia_energetica);

			manejador_de_datos.ingresarNuevoNodo(nivel_academico_diplomado_en_eficiencia_energetica);



			Console.WriteLine("Nodos Postitulos ingresado");

		}
	}
}
