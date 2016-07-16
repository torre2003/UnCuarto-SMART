using AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContenedorImplementacionesInterfacesCalculoModeloMBCIF;
using ModeloMBCIF;
using FuzzyCore;

namespace InicializadorDeArchivosModeloMBCIF
{
    class NodosPostgrado
    {
        ManejadorDeDatosArchivos manejador_de_archivos = new ManejadorDeDatosArchivos();

        public void crearNodosPostgrado()
        {
            #region Nodo Postgrado
            //____________________________________________________________________________________________
            //_________________ Nodo Postgrado ___________________________________________________
            //____________________________________________________________________________________________
            //TODO Postgrado
          	Nodo nodo_postrado;
            nodo_postrado = new Nodo("n.p", "Postgrado");
            nodo_postrado.fuzzy = new InferenciaDifusa(
                //entradas 
                new Dictionary<string, VariableDifusa> {
                    {"n.pp", new VariableDifusa("n.pp", 0, 1,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                                })},
                    {"n.psd", new VariableDifusa("n.psd", 0, 1,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                              })},
                    {"n.psm", new VariableDifusa("n.psm", 0, 1,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                              })},
                    {"n.psdyp", new VariableDifusa("n.psdyp", 0, 1,
                                                             new List<FuncionPertenencia>(){
                                                              new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                              new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                              new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                             })}
                   	},

                //salidas 
                new Dictionary<string, VariableDifusa> {
                    {"estado", new VariableDifusa("estado", 0, 1,
                                                           new List<FuncionPertenencia>(){
                                                            new FuncionHombro("pesimo", 0, 0.1, 0.3),
                                                            new FuncionTriangular("malo", 0.1, 0.3, 0.5 ),
                                                            new FuncionTriangular("regular", 0.3, 0.5, 0.7),
                                                            new FuncionTriangular("bueno", 0.5, 0.7, 0.9),
                                                            new FuncionSaturacion("excelente", 0.7, 0.9, 1)
                                                           })}
                   }
              );
            
              nodo_postrado.agregarVariable("n.pp", Nodo.DATOS_NODOS_EXTERNOS);
              nodo_postrado.agregarVariable("n.psd", Nodo.DATOS_NODOS_EXTERNOS);
              nodo_postrado.agregarVariable("n.psm", Nodo.DATOS_NODOS_EXTERNOS);
              nodo_postrado.agregarVariable("n.psdyp", Nodo.DATOS_NODOS_EXTERNOS);
              
//			 postitulo_en_algo.agregarVariable("i_n.i_n.pea", Nodo.INFLUENCIAS_EXTERNAS);
              
//           postitulo_en_algo.agregarVariable("n.pisi", Nodo.NODOS_INFLUENCIADOS);
              
//           postitulo_en_algo.agregarVariable("n.pscielo", Nodo.NODOS_INFLUENCIADOS);

              //           postitulo_en_algo.calculos = new ICalculosNodo_postitulo_en_algo();
            #endregion


              #region Nodo Postgrado Sección Doctorados
              //____________________________________________________________________________________________
              //_________________ Nodo Postgrado Sección Doctorados ___________________________________________________
              //____________________________________________________________________________________________
              //TODO Postgrado Sección Doctorados
              Nodo nodo_postrado_seccion_doctorados;
              nodo_postrado_seccion_doctorados = new Nodo("n.psd", "Postgrado Sección Doctorados");
              nodo_postrado_seccion_doctorados.fuzzy = new InferenciaDifusa(
                  //entradas 
                  new Dictionary<string, VariableDifusa> {
                    {"n.deq", new VariableDifusa("n.deq", 0, 1,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                                })},
                    {"n.deidayb", new VariableDifusa("n.deidayb", 0, 1,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                              })},
                    {"n.debyea", new VariableDifusa("n.debyea", 0, 1,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                              })}
                   	},

                  //salidas 
                  new Dictionary<string, VariableDifusa> {
                    {"estado", new VariableDifusa("estado", 0, 1,
                                                           new List<FuncionPertenencia>(){
                                                            new FuncionHombro("pesimo", 0, 0.1, 0.3),
                                                            new FuncionTriangular("malo", 0.1, 0.3, 0.5 ),
                                                            new FuncionTriangular("regular", 0.3, 0.5, 0.7),
                                                            new FuncionTriangular("bueno", 0.5, 0.7, 0.9),
                                                            new FuncionSaturacion("excelente", 0.7, 0.9, 1)
                                                           })}
                   }
                );

              nodo_postrado_seccion_doctorados.agregarVariable("n.deq", Nodo.DATOS_NODOS_EXTERNOS);
              nodo_postrado_seccion_doctorados.agregarVariable("n.deidayb", Nodo.DATOS_NODOS_EXTERNOS);
              nodo_postrado_seccion_doctorados.agregarVariable("n.debyea", Nodo.DATOS_NODOS_EXTERNOS);
            
              //			 postitulo_en_algo.agregarVariable("i_n.i_n.pea", Nodo.INFLUENCIAS_EXTERNAS);

              //           postitulo_en_algo.agregarVariable("n.pisi", Nodo.NODOS_INFLUENCIADOS);

              //           postitulo_en_algo.agregarVariable("n.pscielo", Nodo.NODOS_INFLUENCIADOS);

              //           postitulo_en_algo.calculos = new ICalculosNodo_postitulo_en_algo();
              #endregion

              #region Nodo Postgrado Sección Magister
              //____________________________________________________________________________________________
              //_________________ Nodo Postgrado Sección Magister ___________________________________________________
              //____________________________________________________________________________________________
              //TODO Postgrado Sección Magister
              Nodo nodo_postrado_seccion_magister;
              nodo_postrado_seccion_magister = new Nodo("n.psm", "Postgrado Sección Magister");
              nodo_postrado_seccion_magister.fuzzy = new InferenciaDifusa(
                  //entradas 
                  new Dictionary<string, VariableDifusa> {
                   {"n.memc", new VariableDifusa("n.memc", 0, 1,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                                })}, 
                   {"n.mecef", new VariableDifusa("n.mecef", 0, 1,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                                })},
                    {"n.mem", new VariableDifusa("n.mem", 0, 1,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                              })},
                    {"n.meldyce", new VariableDifusa("n.meldyce", 0, 1,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                              })},
                    {"n.mea", new VariableDifusa("n.mea", 0, 1,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                                })},
                    {"n.mecmiea", new VariableDifusa("n.mecmiea", 0, 1,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                              })},
                    {"n.meelmelofol", new VariableDifusa("n.meelmelofol", 0, 1,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                              })}

                   	},

                  //salidas 
                  new Dictionary<string, VariableDifusa> {
                    {"estado", new VariableDifusa("estado", 0, 1,
                                                           new List<FuncionPertenencia>(){
                                                            new FuncionHombro("pesimo", 0, 0.1, 0.3),
                                                            new FuncionTriangular("malo", 0.1, 0.3, 0.5 ),
                                                            new FuncionTriangular("regular", 0.3, 0.5, 0.7),
                                                            new FuncionTriangular("bueno", 0.5, 0.7, 0.9),
                                                            new FuncionSaturacion("excelente", 0.7, 0.9, 1)
                                                           })}
                   }
                );

              nodo_postrado_seccion_magister.agregarVariable("n.memc", Nodo.DATOS_NODOS_EXTERNOS);
              nodo_postrado_seccion_magister.agregarVariable("n.mecef", Nodo.DATOS_NODOS_EXTERNOS);
              nodo_postrado_seccion_magister.agregarVariable("n.mem", Nodo.DATOS_NODOS_EXTERNOS);
              nodo_postrado_seccion_magister.agregarVariable("n.meldyce", Nodo.DATOS_NODOS_EXTERNOS);
              nodo_postrado_seccion_magister.agregarVariable("n.mea", Nodo.DATOS_NODOS_EXTERNOS);
              nodo_postrado_seccion_magister.agregarVariable("n.mecmiea", Nodo.DATOS_NODOS_EXTERNOS);
              nodo_postrado_seccion_magister.agregarVariable("n.meelmelofol", Nodo.DATOS_NODOS_EXTERNOS);


              //			 postitulo_en_algo.agregarVariable("i_n.i_n.pea", Nodo.INFLUENCIAS_EXTERNAS);

              //           postitulo_en_algo.agregarVariable("n.pisi", Nodo.NODOS_INFLUENCIADOS);

              //           postitulo_en_algo.agregarVariable("n.pscielo", Nodo.NODOS_INFLUENCIADOS);

              //           postitulo_en_algo.calculos = new ICalculosNodo_postitulo_en_algo();
              #endregion

              #region Nodo Postgrado Sección diplomados y postitulos
              //____________________________________________________________________________________________
              //_________________ Nodo Postgrado Sección diplomados y postitulos ___________________________________________________
              //____________________________________________________________________________________________
              //TODO Postgrado Sección diplomados y postitulos
              Nodo nodo_postrado_seccion_diplomados_y_postitulos;
              nodo_postrado_seccion_diplomados_y_postitulos = new Nodo("n.psdyp", "Postgrado Sección diplomados y postitulos");
              nodo_postrado_seccion_diplomados_y_postitulos.fuzzy = new InferenciaDifusa(
                  //entradas 
                  new Dictionary<string, VariableDifusa> {
                   {"n.dgt", new VariableDifusa("n.dgt", 0, 1,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                                })}, 
                   {"n.dieie", new VariableDifusa("n.dieie", 0, 1,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                                })},
                    {"n.pmpdqeescdebppelacn", new VariableDifusa("n.pmpdqeescdebppelacn", 0, 1,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                              })},
                    {"n.dee", new VariableDifusa("n.dee", 0, 1,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                              })}
                    },

                  //salidas 
                  new Dictionary<string, VariableDifusa> {
                    {"estado", new VariableDifusa("estado", 0, 1,
                                                           new List<FuncionPertenencia>(){
                                                            new FuncionHombro("pesimo", 0, 0.1, 0.3),
                                                            new FuncionTriangular("malo", 0.1, 0.3, 0.5 ),
                                                            new FuncionTriangular("regular", 0.3, 0.5, 0.7),
                                                            new FuncionTriangular("bueno", 0.5, 0.7, 0.9),
                                                            new FuncionSaturacion("excelente", 0.7, 0.9, 1)
                                                           })}
                   }
                );

              nodo_postrado_seccion_diplomados_y_postitulos.agregarVariable("n.dgt", Nodo.DATOS_NODOS_EXTERNOS);
              nodo_postrado_seccion_diplomados_y_postitulos.agregarVariable("n.dieie", Nodo.DATOS_NODOS_EXTERNOS);
              nodo_postrado_seccion_diplomados_y_postitulos.agregarVariable("n.pmpdqeescdebppelacn", Nodo.DATOS_NODOS_EXTERNOS);
              nodo_postrado_seccion_diplomados_y_postitulos.agregarVariable("n.dee", Nodo.DATOS_NODOS_EXTERNOS);


              //			 postitulo_en_algo.agregarVariable("i_n.i_n.pea", Nodo.INFLUENCIAS_EXTERNAS);

              //           postitulo_en_algo.agregarVariable("n.pisi", Nodo.NODOS_INFLUENCIADOS);

              //           postitulo_en_algo.agregarVariable("n.pscielo", Nodo.NODOS_INFLUENCIADOS);

              //           postitulo_en_algo.calculos = new ICalculosNodo_postitulo_en_algo();
              #endregion


              #region nodo Personal Postgrado
              //____________________________________________________________________________________________
              //_________________ Nodo Personal Postgrado  ___________________________________________________
              //____________________________________________________________________________________________
              //TODO Personal Postgrado
              Nodo nodo_personal_postgrado;
              nodo_personal_postgrado = new Nodo("n.pp", "Personal Postgrado");
              nodo_personal_postgrado.fuzzy = new InferenciaDifusa(
                  //entradas 
                  new Dictionary<string, VariableDifusa> {
                   {"n.dp", new VariableDifusa("n.dp", 0, 1,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                                })}, 
                    {"n.sp", new VariableDifusa("n.sp", 0, 1,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                              })}
                    },

                  //salidas 
                  new Dictionary<string, VariableDifusa> {
                    {"estado", new VariableDifusa("estado", 0, 1,
                                                           new List<FuncionPertenencia>(){
                                                            new FuncionHombro("pesimo", 0, 0.1, 0.3),
                                                            new FuncionTriangular("malo", 0.1, 0.3, 0.5 ),
                                                            new FuncionTriangular("regular", 0.3, 0.5, 0.7),
                                                            new FuncionTriangular("bueno", 0.5, 0.7, 0.9),
                                                            new FuncionSaturacion("excelente", 0.7, 0.9, 1)
                                                           })}
                   }
                );

              nodo_personal_postgrado.agregarVariable("n.dp", Nodo.DATOS_NODOS_EXTERNOS);
              nodo_personal_postgrado.agregarVariable("n.sp", Nodo.DATOS_NODOS_EXTERNOS);
              
              //		   postitulo_en_algo.agregarVariable("i_n.i_n.pea", Nodo.INFLUENCIAS_EXTERNAS);

              //           postitulo_en_algo.agregarVariable("n.pisi", Nodo.NODOS_INFLUENCIADOS);

              //           postitulo_en_algo.agregarVariable("n.pscielo", Nodo.NODOS_INFLUENCIADOS);

              //           postitulo_en_algo.calculos = new ICalculosNodo_postitulo_en_algo();
              #endregion

              #region Nodo Secretaria Postgrado
              //____________________________________________________________________________________________
              //_________________ Nodo Secretaria Postgrado  ___________________________________________________
              //____________________________________________________________________________________________
              //TODO Secretaria Postgrado
              Nodo nodo_secretaria_postgrado;
              nodo_secretaria_postgrado = new Nodo("n.sp", "Secretaria Postgrado");
              nodo_secretaria_postgrado.fuzzy = new InferenciaDifusa(
                  //entradas 
                  new Dictionary<string, VariableDifusa> {
                   {"compromiso", new VariableDifusa("compromiso", 0, 10,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("bajo", 0, 3, 4),
                                                                new FuncionTrapezoidal("medio", 3, 4, 5, 6),
                                                                new FuncionSaturacion("alto", 5, 6, 10)
                                                                })},
                    {"empatia", new VariableDifusa("empatia",  0, 10,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("bajo", 0, 3, 4),
                                                                new FuncionTrapezoidal("medio", 3, 4, 5, 6),
                                                                new FuncionSaturacion("alto", 5, 6, 10)
                                                                })}, 
                    {"manejo verbal", new VariableDifusa("manejo verbal",  0, 10,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("bajo", 0, 3, 4),
                                                                new FuncionTrapezoidal("medio", 3, 4, 5, 6),
                                                                new FuncionSaturacion("alto", 5, 6, 10)
                                                                })}, 
                    {"flexibilidad", new VariableDifusa("flexibilidad",  0, 10,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("bajo", 0, 3, 4),
                                                                new FuncionTrapezoidal("medio", 3, 4, 5, 6),
                                                                new FuncionSaturacion("alto", 5, 6, 10)
                                                                })}, 
                    {"trabajo bajo presion", new VariableDifusa("trabajo bajo presion",  0, 10,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("bajo", 0, 3, 4),
                                                                new FuncionTrapezoidal("medio", 3, 4, 5, 6),
                                                                new FuncionSaturacion("alto", 5, 6, 10)
                                                                })}, 
                    {"sistematibilidad", new VariableDifusa("sistematibilidad",  0, 10,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("bajo", 0, 3, 4),
                                                                new FuncionTrapezoidal("medio", 3, 4, 5, 6),
                                                                new FuncionSaturacion("alto", 5, 6, 10)
                                                                })}, 
                    {"manejo de tics", new VariableDifusa("manejo de tics",  0, 10,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("bajo", 0, 3, 4),
                                                                new FuncionTrapezoidal("medio", 3, 4, 5, 6),
                                                                new FuncionSaturacion("alto", 5, 6, 10)
                                                              })}
                    },

                  //salidas 
                  new Dictionary<string, VariableDifusa> {
                    {"estado", new VariableDifusa("estado", 0, 1,
                                                           new List<FuncionPertenencia>(){
                                                            new FuncionHombro("pesimo", 0, 0.1, 0.3),
                                                            new FuncionTriangular("malo", 0.1, 0.3, 0.5 ),
                                                            new FuncionTriangular("regular", 0.3, 0.5, 0.7),
                                                            new FuncionTriangular("bueno", 0.5, 0.7, 0.9),
                                                            new FuncionSaturacion("excelente", 0.7, 0.9, 1)
                                                           })}
                   }
                );

              nodo_secretaria_postgrado.agregarVariable("compromiso", Nodo.DATOS_INTERNOS);
              nodo_secretaria_postgrado.agregarVariable("empatia", Nodo.DATOS_INTERNOS);
              nodo_secretaria_postgrado.agregarVariable("manejo verbal", Nodo.DATOS_INTERNOS);
              nodo_secretaria_postgrado.agregarVariable("flexibilidad", Nodo.DATOS_INTERNOS);
              nodo_secretaria_postgrado.agregarVariable("trabajo bajo presion", Nodo.DATOS_INTERNOS);
              nodo_secretaria_postgrado.agregarVariable("sistematibilidad", Nodo.DATOS_INTERNOS);
              nodo_secretaria_postgrado.agregarVariable("manejo de tics", Nodo.DATOS_INTERNOS);

              //		   postitulo_en_algo.agregarVariable("i_n.i_n.pea", Nodo.INFLUENCIAS_EXTERNAS);

              //           postitulo_en_algo.agregarVariable("n.pisi", Nodo.NODOS_INFLUENCIADOS);

              //           postitulo_en_algo.agregarVariable("n.pscielo", Nodo.NODOS_INFLUENCIADOS);

              //           postitulo_en_algo.calculos = new ICalculosNodo_postitulo_en_algo();
              #endregion

              #region nodo Director Postgrado
              //____________________________________________________________________________________________
              //_________________ Nodo Director Postgrado  ___________________________________________________
              //____________________________________________________________________________________________
              //TODO Director Postgrado
              Nodo nodo_director_postgrado;
              nodo_director_postgrado = new Nodo("n.dp", "Director Postgrado");
              nodo_director_postgrado.fuzzy = new InferenciaDifusa(
                  //entradas 
                  new Dictionary<string, VariableDifusa> {
                   {"formacion", new VariableDifusa("formacion", 0, 10,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("bajo", 0, 3, 4),
                                                                new FuncionTrapezoidal("medio", 3, 4, 5, 6),
                                                                new FuncionSaturacion("alto", 5, 6, 10)
                                                                })},
                    {"empatia", new VariableDifusa("empatia",  0, 10,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("bajo", 0, 3, 4),
                                                                new FuncionTrapezoidal("medio", 3, 4, 5, 6),
                                                                new FuncionSaturacion("alto", 5, 6, 10)
                                                                })}, 
                    {"poder de resolucion", new VariableDifusa("poder de resolucion",  0, 10,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("bajo", 0, 3, 4),
                                                                new FuncionTrapezoidal("medio", 3, 4, 5, 6),
                                                                new FuncionSaturacion("alto", 5, 6, 10)
                                                                })}, 
                    {"compromiso", new VariableDifusa("compromiso",  0, 10,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("bajo", 0, 3, 4),
                                                                new FuncionTrapezoidal("medio", 3, 4, 5, 6),
                                                                new FuncionSaturacion("alto", 5, 6, 10)
                                                                })}, 
                    {"gestion externa", new VariableDifusa("gestion externa",  0, 10,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("bajo", 0, 3, 4),
                                                                new FuncionTrapezoidal("medio", 3, 4, 5, 6),
                                                                new FuncionSaturacion("alto", 5, 6, 10)
                                                                })}
                    },

                  //salidas 
                  new Dictionary<string, VariableDifusa> {
                    {"estado", new VariableDifusa("estado", 0, 1,
                                                           new List<FuncionPertenencia>(){
                                                            new FuncionHombro("pesimo", 0, 0.1, 0.3),
                                                            new FuncionTriangular("malo", 0.1, 0.3, 0.5 ),
                                                            new FuncionTriangular("regular", 0.3, 0.5, 0.7),
                                                            new FuncionTriangular("bueno", 0.5, 0.7, 0.9),
                                                            new FuncionSaturacion("excelente", 0.7, 0.9, 1)
                                                           })}
                   }
                );

              nodo_director_postgrado.agregarVariable("formacion", Nodo.DATOS_INTERNOS);
              nodo_director_postgrado.agregarVariable("empatia", Nodo.DATOS_INTERNOS);
              nodo_director_postgrado.agregarVariable("poder de resolucion", Nodo.DATOS_INTERNOS);
              nodo_director_postgrado.agregarVariable("compromiso", Nodo.DATOS_INTERNOS);
              nodo_director_postgrado.agregarVariable("gestion externa", Nodo.DATOS_INTERNOS);
            
              //		   postitulo_en_algo.agregarVariable("i_n.i_n.pea", Nodo.INFLUENCIAS_EXTERNAS);

              //           postitulo_en_algo.agregarVariable("n.pisi", Nodo.NODOS_INFLUENCIADOS);

              //           postitulo_en_algo.agregarVariable("n.pscielo", Nodo.NODOS_INFLUENCIADOS);

              //           postitulo_en_algo.calculos = new ICalculosNodo_postitulo_en_algo();


              #endregion












              //Escribiendo nodos en archivo


              manejador_de_archivos.ingresarNuevoNodo(nodo_postrado);
              manejador_de_archivos.ingresarNuevoNodo(nodo_postrado_seccion_doctorados);
              manejador_de_archivos.ingresarNuevoNodo(nodo_postrado_seccion_magister);
              manejador_de_archivos.ingresarNuevoNodo(nodo_postrado_seccion_diplomados_y_postitulos);
              manejador_de_archivos.ingresarNuevoNodo(nodo_personal_postgrado);
              manejador_de_archivos.ingresarNuevoNodo(nodo_secretaria_postgrado);
              manejador_de_archivos.ingresarNuevoNodo(nodo_director_postgrado);


              Console.WriteLine("Nodos Postgrado ingresados");
        
        }




    }
}
