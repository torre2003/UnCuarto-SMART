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
        public Nodo Postgrado ;
        public Nodo Director ;
        public Nodo Secretaria ;


        public NodosPostgrado()
        {
            #region Nodo Postgrado
            //____________________________________________________________________________________________
            //_________________ Nodo Postgrado ___________________________________________________
            //____________________________________________________________________________________________

          	Nodo nodo_postgrado;
            nodo_postgrado = new Nodo("np", "Postgrado");
            nodo_postgrado.fuzzy = new InferenciaDifusa(
                //entradas 
                new Dictionary<string, VariableDifusa> {
                    {"npp", new VariableDifusa("npp", 0, 1,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                                })},
                    {"npsd", new VariableDifusa("npsd", 0, 1,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                              })},
                    {"npsm", new VariableDifusa("npsm", 0, 1,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                              })},
                    {"npsdyp", new VariableDifusa("npsdyp", 0, 1,
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
            

              nodo_postgrado.agregarVariable("npp", Nodo.DATOS_NODOS_EXTERNOS);
              nodo_postgrado.agregarVariable("npsd", Nodo.DATOS_NODOS_EXTERNOS);
              nodo_postgrado.agregarVariable("npsm", Nodo.DATOS_NODOS_EXTERNOS);
              nodo_postgrado.agregarVariable("npsdyp", Nodo.DATOS_NODOS_EXTERNOS);

              nodo_postgrado.agregarVariable("i_ni_np", Nodo.INFLUENCIAS_EXTERNAS);


              nodo_postgrado.agregarVariable("ni", Nodo.NODOS_INFLUENCIADOS);
              nodo_postgrado.calculos = new InterfaceCalculosGenerica(new string[] { "npp", "npsd", "npsm", "npsdyp"});
            #endregion


              #region Nodo Postgrado Seccion Doctorados
              //____________________________________________________________________________________________
              //_________________ Nodo Postgrado Seccion Doctorados ___________________________________________________
              //_________________________________________________________________________________________

              Nodo nodo_postgrado_seccion_doctorados;
              nodo_postgrado_seccion_doctorados = new Nodo("npsd", "Postgrado Seccion Doctorados");
              nodo_postgrado_seccion_doctorados.fuzzy = new InferenciaDifusa(
                  //entradas 
                  new Dictionary<string, VariableDifusa> {
                    {"ndeq", new VariableDifusa("ndeq", 0, 1,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                                })},
                    {"ndeidayb", new VariableDifusa("ndeidayb", 0, 1,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                              })},
                    {"ndebyea", new VariableDifusa("ndebyea", 0, 1,
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


              nodo_postgrado_seccion_doctorados.agregarVariable("ndeq", Nodo.DATOS_NODOS_EXTERNOS);
              nodo_postgrado_seccion_doctorados.agregarVariable("ndeidayb", Nodo.DATOS_NODOS_EXTERNOS);
              nodo_postgrado_seccion_doctorados.agregarVariable("ndebyea", Nodo.DATOS_NODOS_EXTERNOS);
        


              nodo_postgrado_seccion_doctorados.calculos = new InterfaceCalculosSeccionesPostgrado(new string[] { "ndebyea", "ndeidayb", "ndeq" });
              #endregion

              #region Nodo Postgrado Seccion Magister
              //____________________________________________________________________________________________
              //_________________ Nodo Postgrado Seccion Magister ___________________________________________________
              //____________________________________________________________________________________________

              Nodo nodo_postgrado_seccion_magister;
              nodo_postgrado_seccion_magister = new Nodo("npsm", "Postgrado Seccion Magister");
              nodo_postgrado_seccion_magister.fuzzy = new InferenciaDifusa(
                  //entradas 
                  new Dictionary<string, VariableDifusa> {
                   {"nmemc", new VariableDifusa("nmemc", 0, 1,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                                })}, 
                   {"nmecef", new VariableDifusa("nmecef", 0, 1,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                                })},
                    {"nmem", new VariableDifusa("nmem", 0, 1,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                              })},
                    {"nmeldyce", new VariableDifusa("nmeldyce", 0, 1,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                              })},
                    {"nmea", new VariableDifusa("nmea", 0, 1,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                                })},
                    {"nmecmiea", new VariableDifusa("nmecmiea", 0, 1,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                              })},
                    {"nmeelmelofol", new VariableDifusa("nmeelmelofol", 0, 1,
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


              nodo_postgrado_seccion_magister.agregarVariable("nmemc", Nodo.DATOS_NODOS_EXTERNOS);
              nodo_postgrado_seccion_magister.agregarVariable("nmecef", Nodo.DATOS_NODOS_EXTERNOS);
              nodo_postgrado_seccion_magister.agregarVariable("nmem", Nodo.DATOS_NODOS_EXTERNOS);
              nodo_postgrado_seccion_magister.agregarVariable("nmeldyce", Nodo.DATOS_NODOS_EXTERNOS);
              nodo_postgrado_seccion_magister.agregarVariable("nmea", Nodo.DATOS_NODOS_EXTERNOS);
              nodo_postgrado_seccion_magister.agregarVariable("nmecmiea", Nodo.DATOS_NODOS_EXTERNOS);
              nodo_postgrado_seccion_magister.agregarVariable("nmeelmelofol", Nodo.DATOS_NODOS_EXTERNOS);


              nodo_postgrado_seccion_doctorados.calculos = new InterfaceCalculosSeccionesPostgrado(new string[] { "nmemc", "nmecef", "nmem", "nmeldyce", "nmea", "nmecmiea", "nmeelmelofol" });
              #endregion

              #region Nodo Postgrado Seccion diplomados y postitulos
              //____________________________________________________________________________________________
              //_________________ Nodo Postgrado Seccion diplomados y postitulos ___________________________________________________
              //____________________________________________________________________________________________
              //TODO Postgrado Seccion diplomados y postitulos

              Nodo nodo_postgrado_seccion_diplomados_y_postitulos;
              nodo_postgrado_seccion_diplomados_y_postitulos = new Nodo("npsdyp", "Postgrado Seccion diplomados y postitulos");
              nodo_postgrado_seccion_diplomados_y_postitulos.fuzzy = new InferenciaDifusa(
                  //entradas 
                  new Dictionary<string, VariableDifusa> {
                   {"ndieie", new VariableDifusa("ndgt", 0, 1,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                                })}, 
                   {"ndegt", new VariableDifusa("ndieie", 0, 1,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                                })},
                    {"npmpdqeescdebppelacn", new VariableDifusa("npmpdqeescdebppelacn", 0, 1,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                              })},
                    {"ndeee", new VariableDifusa("ndee", 0, 1,
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


              nodo_postgrado_seccion_diplomados_y_postitulos.agregarVariable("ndieie", Nodo.DATOS_NODOS_EXTERNOS);
              nodo_postgrado_seccion_diplomados_y_postitulos.agregarVariable("ndegt", Nodo.DATOS_NODOS_EXTERNOS);
              nodo_postgrado_seccion_diplomados_y_postitulos.agregarVariable("npmpdqeescdebppelacn", Nodo.DATOS_NODOS_EXTERNOS);
              nodo_postgrado_seccion_diplomados_y_postitulos.agregarVariable("ndeee", Nodo.DATOS_NODOS_EXTERNOS);


              nodo_postgrado_seccion_doctorados.calculos = new InterfaceCalculosSeccionesPostgrado(new string[] { "ndieie", "ndegt", "npmpdqeescdebppelacn", "ndeee" });
              #endregion

              #region nodo Personal Postgrado
              //____________________________________________________________________________________________
              //_________________ Nodo Personal Postgrado  ___________________________________________________
              //____________________________________________________________________________________________
              //TODO Personal Postgrado
              Nodo nodo_personal_postgrado;
              nodo_personal_postgrado = new Nodo("npp", "Personal Postgrado");
              nodo_personal_postgrado.fuzzy = new InferenciaDifusa(
                  //entradas 
                  new Dictionary<string, VariableDifusa> {
                   {"ndp", new VariableDifusa("ndp", 0, 1,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                                })}, 
                    {"nsp", new VariableDifusa("nsp", 0, 1,
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

              nodo_personal_postgrado.agregarVariable("ndp", Nodo.DATOS_NODOS_EXTERNOS);
              nodo_personal_postgrado.agregarVariable("nsp", Nodo.DATOS_NODOS_EXTERNOS);
              

              nodo_personal_postgrado.calculos = new InterfaceCalculosPersonas(new string[] { "ndp", "nsp" });
              #endregion

              #region Nodo Secretaria Postgrado
              //____________________________________________________________________________________________
              //_________________ Nodo Secretaria Postgrado  ___________________________________________________
              //____________________________________________________________________________________________
              //TODO Secretaria Postgrado
              Nodo nodo_secretaria_postgrado;
              nodo_secretaria_postgrado = new Nodo("nsp", "Secretaria Postgrado");
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


              nodo_secretaria_postgrado.agregarVariable("i_nsi_nsp", Nodo.INFLUENCIAS_EXTERNAS);
              nodo_secretaria_postgrado.agregarVariable("nsi", Nodo.NODOS_INFLUENCIADOS);


              nodo_secretaria_postgrado.calculos = new InterfaceCalculosPersonas(new string[] { "compromiso", "empatia", "manejo verbal", "flexibilidad", "trabajo bajo presion", "sistematibilidad", "manejo de tics" });
              #endregion

              #region nodo Director Postgrado
              //____________________________________________________________________________________________
              //_________________ Nodo Director Postgrado  ___________________________________________________
              //____________________________________________________________________________________________
              //TODO Director Postgrado
              Nodo nodo_director_postgrado;
              nodo_director_postgrado = new Nodo("ndp", "Director Postgrado");
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

    
              nodo_director_postgrado.agregarVariable("i_ndi_ndp", Nodo.INFLUENCIAS_EXTERNAS);
              nodo_director_postgrado.agregarVariable("ndi", Nodo.NODOS_INFLUENCIADOS);

            // doctorados
              nodo_director_postgrado.agregarVariable("ndeq", Nodo.NODOS_INFLUENCIADOS);
              nodo_director_postgrado.agregarVariable("ndeidayb", Nodo.NODOS_INFLUENCIADOS);
              nodo_director_postgrado.agregarVariable("ndebyea", Nodo.NODOS_INFLUENCIADOS);
            //magister
              nodo_director_postgrado.agregarVariable("nmemc", Nodo.NODOS_INFLUENCIADOS);
              nodo_director_postgrado.agregarVariable("nmecef", Nodo.NODOS_INFLUENCIADOS);
              nodo_director_postgrado.agregarVariable("nmem", Nodo.NODOS_INFLUENCIADOS);
              nodo_director_postgrado.agregarVariable("nmeldyce", Nodo.NODOS_INFLUENCIADOS);
              nodo_director_postgrado.agregarVariable("nmea", Nodo.NODOS_INFLUENCIADOS);
              nodo_director_postgrado.agregarVariable("nmecmiea", Nodo.NODOS_INFLUENCIADOS);
              nodo_director_postgrado.agregarVariable("nmeelmelofol", Nodo.NODOS_INFLUENCIADOS);  
            //postitulos 
              nodo_director_postgrado.agregarVariable("ndieie", Nodo.NODOS_INFLUENCIADOS);
              nodo_director_postgrado.agregarVariable("ndegt", Nodo.NODOS_INFLUENCIADOS);
              nodo_director_postgrado.agregarVariable("npmpdqeescdebppelacn", Nodo.NODOS_INFLUENCIADOS);
              nodo_director_postgrado.agregarVariable("ndeee", Nodo.NODOS_INFLUENCIADOS);
            
              nodo_director_postgrado.calculos = new InterfaceCalculosPersonas(new string[] { "formacion", "empatia", "poder de resolucion", "compromiso", "gestion externa" });


              #endregion


              Postgrado = nodo_postgrado;

              Secretaria = nodo_secretaria_postgrado;
              Director = nodo_director_postgrado;

              //Escribiendo nodos en archivo


              manejador_de_archivos.ingresarNuevoNodo(nodo_postgrado);
              manejador_de_archivos.ingresarNuevoNodo(nodo_postgrado_seccion_doctorados);
              manejador_de_archivos.ingresarNuevoNodo(nodo_postgrado_seccion_magister);
              manejador_de_archivos.ingresarNuevoNodo(nodo_postgrado_seccion_diplomados_y_postitulos);
              manejador_de_archivos.ingresarNuevoNodo(nodo_personal_postgrado);
              manejador_de_archivos.ingresarNuevoNodo(nodo_secretaria_postgrado);
              manejador_de_archivos.ingresarNuevoNodo(nodo_director_postgrado);


              Console.WriteLine("Nodos Postgrado ingresados");
        
        }




    }
}
