/*
 * Creado por SharpDevelop.
 * Usuario: usuario
 * Fecha: 12-07-2016
 * Hora: 17:36
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
	/// Description of NodosDoctorado.
	/// </summary>
	public class NodosDoctorado
	{
		ManejadorDeDatosArchivos manejador_de_datos = new ManejadorDeDatosArchivos();
		public List<Nodo> Nodos = new List<Nodo>();
		
		public NodosDoctorado()
		{
			
			
			#region Doctorado en Quimica
				#region Nodo Doctorado
				//TODO nodo Doctorado en quimica
				//___________________________________________________
				//_________________ Nodo Doctorado en Quimica _________
				//___________________________________________________
				Nodo doctorado_en_quimica;
				doctorado_en_quimica = new Nodo("ndeq", "Doctorado en Quimica");
				doctorado_en_quimica.fuzzy = new InferenciaDifusa(
					//entradas
							new Dictionary<string, VariableDifusa> { {"matricula alumnos", new VariableDifusa("matricula alumnos", 0, 10,
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
						/*nodo externo Nivel Academico */
						{"nnadeq", new VariableDifusa("nnadeq", 0, 1,
								new List<FuncionPertenencia>() {
									new FuncionHombro("normal", 0, 0.3, 0.4),
									new FuncionTrapezoidal("alto", 0.3, 0.4, 0.5, 0.6),
									new FuncionSaturacion("muy_alto", 0.5, 0.6, 1)
								})
						}
					},
	
					//salidas
				new Dictionary<string, VariableDifusa> { {"estado", new VariableDifusa("estado", 0, 1,
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
				doctorado_en_quimica.agregarVariable("matricula alumnos", Nodo.DATOS_INTERNOS);
				doctorado_en_quimica.agregarVariable("acreditacion", Nodo.DATOS_INTERNOS);
				
				doctorado_en_quimica.agregarVariable("nnadeq", Nodo.DATOS_NODOS_EXTERNOS);
				
				//doctorado_en_quimica.agregarVariable("i_ni_npea", Nodo.INFLUENCIAS_EXTERNAS);
				
			//-- influencias DESDE este nodo -----
			doctorado_en_quimica.agregarVariable("npisi", Nodo.NODOS_INFLUENCIADOS);	
			doctorado_en_quimica.agregarVariable("npscielo", Nodo.NODOS_INFLUENCIADOS);
			doctorado_en_quimica.agregarVariable("npe", Nodo.NODOS_INFLUENCIADOS);
			
				
			//-- influencias HACIA este nodo -----
			doctorado_en_quimica.agregarVariable("i_ndp_ndeq", Nodo.INFLUENCIAS_EXTERNAS);
			doctorado_en_quimica.agregarVariable("i_ni_ndeq", Nodo.INFLUENCIAS_EXTERNAS);
			doctorado_en_quimica.agregarVariable("i_nfyb_ndeq", Nodo.INFLUENCIAS_EXTERNAS);
			
			
            doctorado_en_quimica.calculos = new ICalculosNodo_programas("nnadeq");
				
				#endregion
				
				#region Nivel Academico
				//______________________________________________________________________________________________________
				//_________________ Nodo Nivel academico doctorado en quimica  _________
				//______________________________________________________________________________________________________
				Nodo nivel_academico_doctorado_en_quimica;
				nivel_academico_doctorado_en_quimica = new Nodo("nnadeq", "Nivel Academicos Doctorado en Quimica");
				nivel_academico_doctorado_en_quimica.fuzzy = new InferenciaDifusa(
					//entradas
					new Dictionary<string, VariableDifusa> { 
						{"nagsg", new VariableDifusa("nagsg", 0, 1,
								new List<FuncionPertenencia>() {
									new FuncionHombro("calificado", 0, 0.2, 0.4),
									new FuncionTrapezoidal("destacado", 0.2, 0.4, 0.7, 0.9),
									new FuncionSaturacion("eminente", 0.7, 0.9, 1.0)
								})
						}
				},
						//salidas
				new Dictionary<string, VariableDifusa> { {"estado", new VariableDifusa("estado", 0, 1,
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
						
						
				nivel_academico_doctorado_en_quimica.agregarVariable("nagsg", Nodo.DATOS_NODOS_EXTERNOS);
			
            nivel_academico_doctorado_en_quimica.calculos = new InterfaceCalculoNivelesAcademicos(new string[] { "nagsg" });
						
						
				#endregion	
			#endregion			
			
			#region Doctorado en Ingeniería de Alimentos y Bioprocesos
				#region Nodo Doctorado
				//TODO nodo Doctorado en ingeniería de alimentos y Bioprocesos
				//___________________________________________________________________________
				//_________ Nodo Doctorado en Ingeniería de Alimentos y Bioprocesos _________
				//___________________________________________________________________________
				Nodo doctorado_en_ingeniería_de_alimentos_y_bioprocesos;
				doctorado_en_ingeniería_de_alimentos_y_bioprocesos = new Nodo("ndeidayb", "Doctorado en Ingenieria de Alimentos y Bioprocesos");
				doctorado_en_ingeniería_de_alimentos_y_bioprocesos.fuzzy = new InferenciaDifusa(
					//entradas
				new Dictionary<string, VariableDifusa> { {"matricula alumnos", new VariableDifusa("matricula alumnos", 0, 10,
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
 {					/*id del nodo Nivel Academico */"nnadeidayb", new VariableDifusa("nnadeidayb", 0, 1,
								new List<FuncionPertenencia>() {
									new FuncionHombro("normal", 0, 0.3, 0.4),
									new FuncionTrapezoidal("alto", 0.3, 0.4, 0.5, 0.6),
									new FuncionSaturacion("muy_alto", 0.5, 0.6, 1)
								})
						}
					},
	
					//salidas
				new Dictionary<string, VariableDifusa> { {"estado", new VariableDifusa("estado", 0, 1,
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
				doctorado_en_ingeniería_de_alimentos_y_bioprocesos.agregarVariable("matricula alumnos", Nodo.DATOS_INTERNOS);
				doctorado_en_ingeniería_de_alimentos_y_bioprocesos.agregarVariable("acreditacion", Nodo.DATOS_INTERNOS);
				
				doctorado_en_ingeniería_de_alimentos_y_bioprocesos.agregarVariable("nnadeidayb", Nodo.DATOS_NODOS_EXTERNOS);
				
			//-- influencias DESDE este nodo -----
				doctorado_en_ingeniería_de_alimentos_y_bioprocesos.agregarVariable("npisi", Nodo.NODOS_INFLUENCIADOS);
				doctorado_en_ingeniería_de_alimentos_y_bioprocesos.agregarVariable("npscielo", Nodo.NODOS_INFLUENCIADOS);	
				doctorado_en_ingeniería_de_alimentos_y_bioprocesos.agregarVariable("npe", Nodo.NODOS_INFLUENCIADOS);
			

			//-- influencias HACIA este nodo -----
			doctorado_en_ingeniería_de_alimentos_y_bioprocesos.agregarVariable("i_ndp_ndeidayb", Nodo.INFLUENCIAS_EXTERNAS);
			doctorado_en_ingeniería_de_alimentos_y_bioprocesos.agregarVariable("i_ni_ndeidayb", Nodo.INFLUENCIAS_EXTERNAS);
			doctorado_en_ingeniería_de_alimentos_y_bioprocesos.agregarVariable("i_nfyb_ndeidayb", Nodo.INFLUENCIAS_EXTERNAS);
			

                doctorado_en_ingeniería_de_alimentos_y_bioprocesos.calculos = new ICalculosNodo_programas("nnadeidayb");
				
				#endregion
				
				#region Nivel Academico
				//______________________________________________________________________________________________________
				//_________________ Nodo Nivel academico postitulo_en_algo _________
				//______________________________________________________________________________________________________
				Nodo nivel_academico_ingenieria_en_alimentos_y_bioprocesos;
				nivel_academico_ingenieria_en_alimentos_y_bioprocesos = new Nodo("nnadeidayb", "Nivel Academicos Doctorado en Ingenieria de Alimentos y Bioprocesos");
				nivel_academico_ingenieria_en_alimentos_y_bioprocesos.fuzzy = new InferenciaDifusa(
					//entradas
					new Dictionary<string, VariableDifusa> { 
 {					/* Nelson Moraga */"nanm", new VariableDifusa("nanm", 0, 1,
								new List<FuncionPertenencia>() {
									new FuncionHombro("calificado", 0, 0.2, 0.4),
									new FuncionTrapezoidal("destacado", 0.2, 0.4, 0.7, 0.9),
									new FuncionSaturacion("eminente", 0.7, 0.9, 1.0)
								})
						}
					},
						//salidas
						new Dictionary<string, VariableDifusa> { {"estado", new VariableDifusa("estado", 0, 1,
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
						
						
				nivel_academico_ingenieria_en_alimentos_y_bioprocesos.agregarVariable("nanm", Nodo.DATOS_NODOS_EXTERNOS);
			
			
                nivel_academico_ingenieria_en_alimentos_y_bioprocesos.calculos = new InterfaceCalculoNivelesAcademicos(new string[] { "nanm" });		
						
				#endregion	
			#endregion
			
			#region Doctorado en Biología y Ecología Aplicada
				#region Nodo Doctorado
				//TODO nodo Doctorado en Biología y Ecología Aplicada
				//__________________________________________________________________________
				//_________________ Nodo Doctorado en Biología y Ecología Aplicada _________
				//__________________________________________________________________________
				Nodo doctorado_en_biologia;
				doctorado_en_biologia = new Nodo("ndebyea", "Doctorado en Biologia y Ecologia Aplicada");
				doctorado_en_biologia.fuzzy = new InferenciaDifusa(
					//entradas
				new Dictionary<string, VariableDifusa> { {"matricula alumnos", new VariableDifusa("matricula alumnos", 0, 10,
								new List<FuncionPertenencia>() {
									new FuncionHombro("poco", 0, 1, 3),
									new FuncionTrapezoidal("optimo", 1, 3, 4, 6),
									new FuncionSaturacion("excedido", 4, 6, 10)
								})
						}, {"acreditacion", new VariableDifusa("Acreditacion", 0, 10,
								new List<FuncionPertenencia>() {
									new FuncionHombro("sin_acreditacion", 0, 0.1, 0.1),
									new FuncionTrapezoidal("periodo_corto", 1, 1, 2, 3),
									new FuncionTrapezoidal("periodo_medio", 2, 3, 5, 6),
									new FuncionSaturacion("periodo_prolongado", 5, 6, 10)
								})
						},
 {					/*id del nodo Nivel Academico */"nnadebyea", new VariableDifusa("nnadebyea", 0, 1,
								new List<FuncionPertenencia>() {
									new FuncionHombro("normal", 0, 0.3, 0.4),
									new FuncionTrapezoidal("alto", 0.3, 0.4, 0.5, 0.6),
									new FuncionSaturacion("muy_alto", 0.5, 0.6, 1)
								})
						}
					},

					//salidas
				new Dictionary<string, VariableDifusa> { {"estado", new VariableDifusa("estado", 0, 1,
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
				doctorado_en_biologia.agregarVariable("matricula alumnos", Nodo.DATOS_INTERNOS);
				doctorado_en_biologia.agregarVariable("acreditacion", Nodo.DATOS_INTERNOS);
				
				doctorado_en_biologia.agregarVariable("nnadebyea", Nodo.DATOS_NODOS_EXTERNOS);
				
			//-- influencias DESDE este nodo -----
			doctorado_en_biologia.agregarVariable("npisi", Nodo.NODOS_INFLUENCIADOS);
			doctorado_en_biologia.agregarVariable("npscielo", Nodo.NODOS_INFLUENCIADOS);	
			doctorado_en_biologia.agregarVariable("npe", Nodo.NODOS_INFLUENCIADOS);


			//-- influencias HACIA este nodo -----
			doctorado_en_biologia.agregarVariable("i_ndp_ndebyea", Nodo.INFLUENCIAS_EXTERNAS);
			doctorado_en_biologia.agregarVariable("i_ni_ndebyea", Nodo.INFLUENCIAS_EXTERNAS);
			doctorado_en_biologia.agregarVariable("i_nfyb_ndebyea", Nodo.INFLUENCIAS_EXTERNAS);


                doctorado_en_biologia.calculos = new ICalculosNodo_programas("nnadebyea");
				
				#endregion
			
				#region Nivel Academico
				//______________________________________________________________________________________________________
				//_________________ Nodo Nivel academico doctorado en biologia _________
				//______________________________________________________________________________________________________
				Nodo nivel_academico_doctorado_en_biologia;
				nivel_academico_doctorado_en_biologia = new Nodo("nnadebyea", "Nivel Academico Doctorado en Biolegia y Ecologia Aplicada");
				nivel_academico_doctorado_en_biologia.fuzzy = new InferenciaDifusa(
					//entradas
					new Dictionary<string, VariableDifusa> { 
 {					/* Francisco Squeo */"n.afs", new VariableDifusa("nafs", 0, 1,
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
						}*/
				},
						//salidas
				new Dictionary<string, VariableDifusa> { {"estado", new VariableDifusa("estado", 0, 1,
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
						
						
				nivel_academico_doctorado_en_biologia.agregarVariable("nafs", Nodo.DATOS_NODOS_EXTERNOS);
				//nivel_academico_doctorado_en_biologia.agregarVariable("docente 2", Nodo.DATOS_NODOS_EXTERNOS);
			
                nivel_academico_doctorado_en_biologia.calculos = new InterfaceCalculoNivelesAcademicos(new string[] { "nafs" });	
			#endregion
			#endregion
						
			// lista para crear influencias
			Nodos.Add(doctorado_en_biologia);
			Nodos.Add(doctorado_en_quimica);
			Nodos.Add(doctorado_en_ingeniería_de_alimentos_y_bioprocesos);
						
				//Escribiendo nodos en archivo
			manejador_de_datos.ingresarNuevoNodo(doctorado_en_ingeniería_de_alimentos_y_bioprocesos);
			manejador_de_datos.ingresarNuevoNodo(nivel_academico_ingenieria_en_alimentos_y_bioprocesos);
			manejador_de_datos.ingresarNuevoNodo(doctorado_en_quimica);
			manejador_de_datos.ingresarNuevoNodo(nivel_academico_doctorado_en_quimica);
			manejador_de_datos.ingresarNuevoNodo(doctorado_en_biologia);
			manejador_de_datos.ingresarNuevoNodo(nivel_academico_doctorado_en_biologia);
			Console.WriteLine("Nodos Doctorados ingresados");
		

			
		}
			
	}
}

