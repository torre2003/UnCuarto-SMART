/*
 * Creado por SharpDevelop.
 * Usuario: usuario
 * Fecha: 14-07-2016
 * Hora: 21:39
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
				diplomado_innovacion_educativa = new Nodo("n.dieie", "Diplomado Interdisciplinario en innovacion educativa");
				diplomado_innovacion_educativa.fuzzy = new InferenciaDifusa(
					//entradas
					new Dictionary<string, VariableDifusa> { 
						{"matricula alumnos", new VariableDifusa("matricula alumnos", 0, 10,
								new List<FuncionPertenencia>() {
									new FuncionHombro("poco", 0, 1, 3),
									new FuncionTrapezoidal("optimo", 1, 3, 4, 6),

									new FuncionSaturacion("excedido", 4, 6, 10)
								})
						}, {"acreditación", new VariableDifusa("acreditación", 0, 10,
								new List<FuncionPertenencia>() {
									new FuncionHombro("sin_acreditacion", 0, 0.1, 0.1),
									new FuncionTrapezoidal("periodo_corto", 1, 1, 2, 3),
									new FuncionTrapezoidal("periodo_medio", 2, 3, 5, 6),
									new FuncionSaturacion("periodo_prolongado", 5, 6, 10)
								})
						},
						/* id del nodo Nivel Academico */
						{"n.nadieie", new VariableDifusa("n.nadieie", 0, 1,
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
				diplomado_innovacion_educativa.agregarVariable("acreditación", Nodo.DATOS_INTERNOS);
				
				diplomado_innovacion_educativa.agregarVariable("n.nadieie", Nodo.DATOS_NODOS_EXTERNOS);


                diplomado_innovacion_educativa.agregarVariable("i_n.dp_n.dieie", Nodo.INFLUENCIAS_EXTERNAS);


                diplomado_innovacion_educativa.calculos = new ICalculosNodo_programas("n.nadieie");
				
				#endregion
			
				#region Nivel Academico
				//______________________________________________________________________________________________________
				//_________________ Nodo Nivel academico Diplomado Interdisciplinario en innovacion educativa _________
				//______________________________________________________________________________________________________
				Nodo nivel_academico_diplomado_innovacion_educativa;
				nivel_academico_diplomado_innovacion_educativa = new Nodo("n.nadieie", "nivel academico Diplomado Interdisciplinario en innovacion educativa");
				nivel_academico_diplomado_innovacion_educativa.fuzzy = new InferenciaDifusa(
					//entradas
					new Dictionary<string, VariableDifusa> { 
						/* Silvia Lopez de Maturana */
						{"n.asldm", new VariableDifusa("n.asldm", 0, 1,
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
						
						
				nivel_academico_diplomado_innovacion_educativa.agregarVariable("n.asldm", Nodo.DATOS_NODOS_EXTERNOS);
				//nivel_academico_postitulo_en_algo.agregarVariable("docente 2", Nodo.DATOS_NODOS_EXTERNOS);



                nivel_academico_diplomado_innovacion_educativa.calculos = new InterfaceCalculoNivelesAcademicos(new string[] { "n.asldm" });

				#endregion	
			#endregion
			
			#region Diplomado Gestion Tributaria
				#region Nodo Diplomado
				//TODO nodo Diplomado Gestion Tributaria
				//___________________________________________________
				//_________________ Nodo postitulo_en_algo _________
				//___________________________________________________
				Nodo diplomado_gestion_tributaria;
				diplomado_gestion_tributaria = new Nodo("n.degt", "Diplomado en Gestion Tributaria");
				diplomado_gestion_tributaria.fuzzy = new InferenciaDifusa(
					//entradas
					new Dictionary<string, VariableDifusa> { 
						{"matricula alumnos", new VariableDifusa("matricula alumnos", 0, 10,
								new List<FuncionPertenencia>() {
									new FuncionHombro("poco", 0, 1, 3),
									new FuncionTrapezoidal("optimo", 1, 3, 4, 6),
									new FuncionSaturacion("excedido", 4, 6, 10)
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
						{"n.nadegt", new VariableDifusa("n.nadegt", 0, 1,
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
				
				diplomado_gestion_tributaria.agregarVariable("n.nadegt", Nodo.DATOS_NODOS_EXTERNOS);


                diplomado_gestion_tributaria.agregarVariable("i_n.dp_n.degt", Nodo.INFLUENCIAS_EXTERNAS);

                diplomado_gestion_tributaria.calculos = new ICalculosNodo_programas("n.nadegt");
				
				#endregion
			
				#region Nivel Academico
				//______________________________________________________________________________________________________
				//_________________ Nodo Nivel academico diplomado en gestion tributaria _________
				//______________________________________________________________________________________________________
				Nodo nivel_academico_diplomado_gestion_tributaria;
				nivel_academico_diplomado_gestion_tributaria = new Nodo("n.nadegt", "nivel academico diplomado en gestion tributaria");
				nivel_academico_diplomado_gestion_tributaria.fuzzy = new InferenciaDifusa(
					//entradas
					new Dictionary<string, VariableDifusa> { 
						/*Albero Hernandez */
						{"n.aah", new VariableDifusa("n.aah", 0, 1,
								new List<FuncionPertenencia>() {
									new FuncionHombro("calificado", 0, 0.2, 0.4),
									new FuncionTrapezoidal("destacado", 0.2, 0.4, 0.7, 0.9),
									new FuncionSaturacion("eminente", 0.7, 0.9, 1.0)
								})
						}/*, {"n.docente 2", new VariableDifusa("n.docente 2", 0, 1,
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
						
						
				nivel_academico_diplomado_gestion_tributaria.agregarVariable("n.aah", Nodo.DATOS_NODOS_EXTERNOS);
				//nivel_academico_postitulo_en_algo.agregarVariable("n.docente 2", Nodo.DATOS_NODOS_EXTERNOS);



                nivel_academico_diplomado_gestion_tributaria.calculos = new InterfaceCalculoNivelesAcademicos(new string[] { "n.aah" });

				#endregion	
			#endregion
			
			#region Postítulo Mención para Docentes que ejercen en segundo ciclo de Enseñanza básica para Profesores en la Asignatura de Ciencias Naturales
				#region Nodo Postitulo
				//TODO nodo Postitulo mencion docentes bla bla.....
				//___________________________________________________
				//_________________ Nodo Postitulo mencion docentes _________
				//___________________________________________________
				Nodo postitulo_mencion_docentes_s_ciclo;
				postitulo_mencion_docentes_s_ciclo = new Nodo("n.pmpdqeescdebppelacn", "Postítulo Mención para Docentes que ejercen en segundo ciclo de Enseñanza básica para Profesores en la Asignatura de Ciencias Naturales");
				postitulo_mencion_docentes_s_ciclo.fuzzy = new InferenciaDifusa(
					//entradas
					new Dictionary<string, VariableDifusa> { 
						{"matricula alumnos", new VariableDifusa("matricula alumnos", 0, 10,
								new List<FuncionPertenencia>() {
									new FuncionHombro("poco", 0, 1, 3),
									new FuncionTrapezoidal("optimo", 1, 3, 4, 6),

									new FuncionSaturacion("excedido", 4, 6, 10)
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
						{"n.napmpdqeescdebppelacn", new VariableDifusa("n.napmpdqeescdebppelacn", 0, 1,
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
				
				postitulo_mencion_docentes_s_ciclo.agregarVariable("n.napmpdqeescdebppelacn", Nodo.DATOS_NODOS_EXTERNOS);

			
                postitulo_mencion_docentes_s_ciclo.agregarVariable("i_n.dp_n.pmpdqeescdebppelacn", Nodo.INFLUENCIAS_EXTERNAS);


                postitulo_mencion_docentes_s_ciclo.calculos = new ICalculosNodo_programas("n.napmpdqeescdebppelacn");
				
				#endregion
			
				#region Nivel Academico
				//______________________________________________________________________________________________________
				//_________________ Nodo Nivel academico postitulo_en_algo _________
				//______________________________________________________________________________________________________
				Nodo nivel_academico_postitulo_mencion_docentes_s_ciclo;
				nivel_academico_postitulo_mencion_docentes_s_ciclo = new Nodo("n.napmpdqeescdebppelacn", "nivel academico Postítulo Mención para Docentes que ejercen en segundo ciclo de Enseñanza básica para Profesores en la Asignatura de Ciencias Naturales");
				nivel_academico_postitulo_mencion_docentes_s_ciclo.fuzzy = new InferenciaDifusa(
					//entradas
					new Dictionary<string, VariableDifusa> { 
						/* 	Maria Ester Alvarez */
						{"n.amea", new VariableDifusa("n.amea", 0, 1,
								new List<FuncionPertenencia>() {
									new FuncionHombro("calificado", 0, 0.2, 0.4),
									new FuncionTrapezoidal("destacado", 0.2, 0.4, 0.7, 0.9),
									new FuncionSaturacion("eminente", 0.7, 0.9, 1.0)
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
						
						
				nivel_academico_postitulo_mencion_docentes_s_ciclo.agregarVariable("n.amea", Nodo.DATOS_NODOS_EXTERNOS);



                nivel_academico_postitulo_mencion_docentes_s_ciclo.calculos = new InterfaceCalculoNivelesAcademicos(new string[] { "n.amea" });

				#endregion	
			#endregion		
			
			#region Diplomado en Eficiencia Energética
				#region Nodo Diplomado
				
				//TODO nodo Diplomado en Eficiencia Energética
				//___________________________________________________
				//______ Nodo Diplomado en Eficiencia Energética _________
				//___________________________________________________
				Nodo diplomado_en_eficiencia_energética;
				diplomado_en_eficiencia_energética = new Nodo("n.deee", "Diplomado en Eficiencia Energética");
				diplomado_en_eficiencia_energética.fuzzy = new InferenciaDifusa(
					//entradas
					new Dictionary<string, VariableDifusa> { 
						{"matricula alumnos", new VariableDifusa("matricula alumnos", 0, 10,
								new List<FuncionPertenencia>() {
									new FuncionHombro("poco", 0, 1, 3),
									new FuncionTrapezoidal("optimo", 1, 3, 4, 6),

									new FuncionSaturacion("excedido", 4, 6, 10)
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
						{"n.nadeee", new VariableDifusa("n.nadeee", 0, 1,
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
				diplomado_en_eficiencia_energética.agregarVariable("matricula alumnos", Nodo.DATOS_INTERNOS);
				diplomado_en_eficiencia_energética.agregarVariable("acreditacion", Nodo.DATOS_INTERNOS);
				
				diplomado_en_eficiencia_energética.agregarVariable("n.nadeee", Nodo.DATOS_NODOS_EXTERNOS);

			
                diplomado_en_eficiencia_energética.agregarVariable("i_n.dp_n.deee", Nodo.INFLUENCIAS_EXTERNAS);


                diplomado_en_eficiencia_energética.calculos = new ICalculosNodo_programas("n.nadeee");
				
				#endregion
			
				#region Nivel Academico
				//______________________________________________________________________________________________________
				//_________________ Nodo Nivel academico Diplomado en Eficiencia Energética _________
				//______________________________________________________________________________________________________
				Nodo nivel_academico_diplomado_en_eficiencia_energética;
				nivel_academico_diplomado_en_eficiencia_energética = new Nodo("n.nadeee", "nivel academico Diplomado en Eficiencia Energética");
				nivel_academico_diplomado_en_eficiencia_energética.fuzzy = new InferenciaDifusa(
					//entradas
					new Dictionary<string, VariableDifusa> { 
						/* Nelson Moraga */
						{"n.anm", new VariableDifusa("n.anm", 0, 1,
								new List<FuncionPertenencia>() {
									new FuncionHombro("calificado", 0, 0.2, 0.4),
									new FuncionTrapezoidal("destacado", 0.2, 0.4, 0.7, 0.9),
									new FuncionSaturacion("eminente", 0.7, 0.9, 1.0)
								})
						}/*, {"n.docente 2", new VariableDifusa("n.docente 2", 0, 1,
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
						
						
				nivel_academico_diplomado_en_eficiencia_energética.agregarVariable("n.anm", Nodo.DATOS_NODOS_EXTERNOS);
				//nivel_academico_diplomado_en_eficiencia_energética.agregarVariable("n.docente 2", Nodo.DATOS_NODOS_EXTERNOS);

	
                nivel_academico_diplomado_en_eficiencia_energética.calculos = new InterfaceCalculoNivelesAcademicos(new string[] { "n.anm" });

				#endregion	
			#endregion
						

		
				//Escribiendo nodos en archivo
			manejador_de_datos.ingresarNuevoNodo(diplomado_innovacion_educativa);
			manejador_de_datos.ingresarNuevoNodo(nivel_academico_diplomado_innovacion_educativa);
			manejador_de_datos.ingresarNuevoNodo(diplomado_gestion_tributaria);
			manejador_de_datos.ingresarNuevoNodo(nivel_academico_diplomado_gestion_tributaria);
			manejador_de_datos.ingresarNuevoNodo(postitulo_mencion_docentes_s_ciclo);
			manejador_de_datos.ingresarNuevoNodo(nivel_academico_postitulo_mencion_docentes_s_ciclo);
				manejador_de_datos.ingresarNuevoNodo(diplomado_en_eficiencia_energética);

				manejador_de_datos.ingresarNuevoNodo(nivel_academico_diplomado_en_eficiencia_energética);



			Console.WriteLine("Nodos Postitulos ingresado");


		}
	}
}
