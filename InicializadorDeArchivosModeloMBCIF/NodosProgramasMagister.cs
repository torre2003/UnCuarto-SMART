﻿using AccesoADatos;
using FuzzyCore;
using ModeloMBCIF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InicializadorDeArchivosModeloMBCIF
{
    class NodosProgramasMagister
    {
        ManejadorDeDatosArchivos manejador_de_archivos = new ManejadorDeDatosArchivos();
        public void crearNodosProgramasMagister()
        {
            //ingresar nodos X
            //TODO Magister en Mecánica Computacional 
            //___________________________________________________________________________________
            //_________________ Nodo Magister en Mecánica Computacional _________
            //___________________________________________________________________________________
            Nodo nodo_mag_en_mecanica_computacional;
            nodo_mag_en_mecanica_computacional = new Nodo("n.memc", "Magister en Mecánica Computacional");
            nodo_mag_en_mecanica_computacional.fuzzy = new InferenciaDifusa(
                //entradas 
                new Dictionary<string, VariableDifusa> {
                    {"matricula alumnos", new VariableDifusa("matricula alumnos", 0, 10,	
                                                                new List<FuncionPertenencia>() {
                                                                  new FuncionHombro("poco", 0, 1, 3),
                                                                  new FuncionTrapezoidal("optimo", 1, 3, 4, 6),
                                                                  new FuncionSaturacion("exedido", 4, 6, 10)
                                                                })},
                    {"acreditacion", new VariableDifusa("acreditacion", 0, 10,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("sin_acreditacion", 0, 0.1 , 0.1),
                                                                new FuncionTrapezoidal("periodo_corto", 1, 1, 2, 3),
                                                                new FuncionTrapezoidal("periodo_medio", 2, 3, 5, 6),
                                                                new FuncionSaturacion("periodo_prolongado", 5, 6, 10)
                                                              })},
                    //napea: id del nodo Nivel Academico postitulo en algo :-)
                    {"n.namemc", new VariableDifusa("n.namemc", 0, 1,
                                                             new List<FuncionPertenencia>(){
                                                              new FuncionHombro("normal", 0, 0.3, 0.4),
                                                              new FuncionTrapezoidal("alto", 0.3, 0.4, 0.5, 0.6),
                                                              new FuncionSaturacion("muy_alto", 0.5, 0.6, 1)
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
            nodo_mag_en_mecanica_computacional.agregarVariable("matricula alumnos", Nodo.DATOS_INTERNOS);
            nodo_mag_en_mecanica_computacional.agregarVariable("acreditacion", Nodo.DATOS_INTERNOS);

            nodo_mag_en_mecanica_computacional.agregarVariable("n.namemc", Nodo.DATOS_NODOS_EXTERNOS);

            //  nodo_mag_en_mecanica_computacional.agregarVariable("i_ni_npea", Nodo.INFLUENCIAS_EXTERNAS);

            //  nodo_mag_en_mecanica_computacional.agregarVariable("npisi", Nodo.NODOS_INFLUENCIADOS);

            //  nodo_mag_en_mecanica_computacional.agregarVariable("npscielo", Nodo.NODOS_INFLUENCIADOS);

            //  nodo_mag_en_mecanica_computacional.calculos = new ICalculosNodo_postitulo_en_algo();


            //______________________________________________________________________________________________________
            //_________________ Nodo Nivel academico Magister en Mecánica Computacional _________
            //______________________________________________________________________________________________________
            //TODO nivel academico magister en emcanica computacional
            Nodo nivel_academico_nodo_mag_en_mecanica_computacional;
            nivel_academico_nodo_mag_en_mecanica_computacional = new Nodo("n.namemc", "nivel academico Magister en Mecánica Computacional");
            nivel_academico_nodo_mag_en_mecanica_computacional.fuzzy = new InferenciaDifusa(
                //entradas 
                new Dictionary<string, VariableDifusa> {
                    {"n.amgs", new VariableDifusa("docente 1", 0, 1,	
                                                                new List<FuncionPertenencia>() {
                                                                  new FuncionHombro("calificado", 0, 0.2, 0.4),
                                                                  new FuncionTrapezoidal("destacado", 0.2, 0.4, 0.7, 0.9),
                                                                  new FuncionSaturacion("eminente", 0.7, 0.9, 1.0)
                                                                })},
                    {"docente 2", new VariableDifusa("docente 2", 0, 1,	
                                            new List<FuncionPertenencia>() {
                                              new FuncionHombro("calificado", 0, 0.2, 0.4),
                                              new FuncionTrapezoidal("destacado", 0.2, 0.4, 0.7, 0.9),
                                              new FuncionSaturacion("eminente", 0.7, 0.9, 1.0)
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


            nivel_academico_nodo_mag_en_mecanica_computacional.agregarVariable("n.amgs", Nodo.DATOS_NODOS_EXTERNOS);
            nivel_academico_nodo_mag_en_mecanica_computacional.agregarVariable("docente 2", Nodo.DATOS_NODOS_EXTERNOS);

            //nivel_academico_nodo_mag_en_mecanica_computacional.calculos = new ICalculosNodo_nivel_academico_postitulo_en_algo();


            //____________________________________________________________________________________________
            //_________________ Nodo Magister en Ciencias en Física_______________________________________
            //____________________________________________________________________________________________
            //TODO Magister en Ciencias en Física
            Nodo nodo_magister_en_ciencias_fiscas;
            nodo_magister_en_ciencias_fiscas = new Nodo("n.mecef", "Magister en Ciencias en Física");
            nodo_magister_en_ciencias_fiscas.fuzzy = new InferenciaDifusa(
                //entradas 
                new Dictionary<string, VariableDifusa> {
                    {"matricula alumnos", new VariableDifusa("matricula alumnos", 0, 10,	
                                                                new List<FuncionPertenencia>() {
                                                                  new FuncionHombro("poco", 0, 1, 3),
                                                                  new FuncionTrapezoidal("optimo", 1, 3, 4, 6),
                                                                  new FuncionSaturacion("exedido", 4, 6, 10)
                                                                })},
                    {"acreditacion", new VariableDifusa("acreditacion", 0, 10,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("sin_acreditacion", 0, 0.1 , 0.1),
                                                                new FuncionTrapezoidal("periodo_corto", 1, 1, 2, 3),
                                                                new FuncionTrapezoidal("periodo_medio", 2, 3, 5, 6),
                                                                new FuncionSaturacion("periodo_prolongado", 5, 6, 10)
                                                              })},
                    //napea: id del nodo Nivel Academico postitulo en algo :-)
                    {"n.namecef", new VariableDifusa("n.namecef", 0, 1,
                                                             new List<FuncionPertenencia>(){
                                                              new FuncionHombro("normal", 0, 0.3, 0.4),
                                                              new FuncionTrapezoidal("alto", 0.3, 0.4, 0.5, 0.6),
                                                              new FuncionSaturacion("muy_alto", 0.5, 0.6, 1)
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
            nodo_magister_en_ciencias_fiscas.agregarVariable("matricula alumnos", Nodo.DATOS_INTERNOS);
            nodo_magister_en_ciencias_fiscas.agregarVariable("acreditacion", Nodo.DATOS_INTERNOS);

            nodo_magister_en_ciencias_fiscas.agregarVariable("n.namecef", Nodo.DATOS_NODOS_EXTERNOS);

            //nodo_magister_en_ciencias_fiscas.agregarVariable("i_n.i_n.pea", Nodo.INFLUENCIAS_EXTERNAS);

            //nodo_magister_en_ciencias_fiscas.agregarVariable("n.pisi", Nodo.NODOS_INFLUENCIADOS);

            //nodo_magister_en_ciencias_fiscas.agregarVariable("n.pscielo", Nodo.NODOS_INFLUENCIADOS);

            //nodo_magister_en_ciencias_fiscas.calculos = new ICalculosNodo_postitulo_en_algo();

            //______________________________________________________________________________________________________
            //_________________ Nodo Nivel academico Magister en Ciencias en Física _____________________________________________
            //______________________________________________________________________________________________________
            //TODO Nivel academico Magister en Ciencias en Física
            Nodo nivel_academico_magister_en_ciencias_fisicas;
            nivel_academico_magister_en_ciencias_fisicas = new Nodo("n.namecef", "nivel academico Magister en Ciencias en Física");
            nivel_academico_magister_en_ciencias_fisicas.fuzzy = new InferenciaDifusa(
                //entradas 
                new Dictionary<string, VariableDifusa> {
                    {"n.apv", new VariableDifusa("n.apv", 0, 1,	
                                                                new List<FuncionPertenencia>() {
                                                                  new FuncionHombro("calificado", 0, 0.2, 0.4),
                                                                  new FuncionTrapezoidal("destacado", 0.2, 0.4, 0.7, 0.9),
                                                                  new FuncionSaturacion("eminente", 0.7, 0.9, 1.0)
                                                                })},
                    {"docente 2", new VariableDifusa("docente 2", 0, 1,	
                                            new List<FuncionPertenencia>() {
                                              new FuncionHombro("calificado", 0, 0.2, 0.4),
                                              new FuncionTrapezoidal("destacado", 0.2, 0.4, 0.7, 0.9),
                                              new FuncionSaturacion("eminente", 0.7, 0.9, 1.0)
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


            nivel_academico_magister_en_ciencias_fisicas.agregarVariable("n.apv", Nodo.DATOS_NODOS_EXTERNOS);
            nivel_academico_magister_en_ciencias_fisicas.agregarVariable("docente 2", Nodo.DATOS_NODOS_EXTERNOS);

            //nivel_academico_magister_en_ciencias_fisicas.calculos = new ICalculosNodo_nivel_academico_postitulo_en_algo();




            
            //____________________________________________________________________________________________
            //_________________ Nodo Magister en Matemáticas" ___________________________________________________
            //____________________________________________________________________________________________
            //TODO Nodo Magister en Matemáticas"
            Nodo nodo_magister_en_matemacica;
            nodo_magister_en_matemacica = new Nodo("n.mem", "Magister en Matemáticas");
            nodo_magister_en_matemacica.fuzzy = new InferenciaDifusa(
                //entradas 
                new Dictionary<string, VariableDifusa> {
                    {"matricula alumnos", new VariableDifusa("matricula alumnos", 0, 10,	
                                                                new List<FuncionPertenencia>() {
                                                                  new FuncionHombro("poco", 0, 1, 3),
                                                                  new FuncionTrapezoidal("optimo", 1, 3, 4, 6),
                                                                  new FuncionSaturacion("exedido", 4, 6, 10)
                                                                })},
                    {"acreditacion", new VariableDifusa("acreditacion", 0, 10,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("sin_acreditacion", 0, 0.1 , 0.1),
                                                                new FuncionTrapezoidal("periodo_corto", 1, 1, 2, 3),
                                                                new FuncionTrapezoidal("periodo_medio", 2, 3, 5, 6),
                                                                new FuncionSaturacion("periodo_prolongado", 5, 6, 10)
                                                              })},
                    //napea: id del nodo Nivel Academico postitulo en algo :-)
                    {"n.namem", new VariableDifusa("n.namem", 0, 1,
                                                             new List<FuncionPertenencia>(){
                                                              new FuncionHombro("normal", 0, 0.3, 0.4),
                                                              new FuncionTrapezoidal("alto", 0.3, 0.4, 0.5, 0.6),
                                                              new FuncionSaturacion("muy_alto", 0.5, 0.6, 1)
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
            nodo_magister_en_matemacica.agregarVariable("matricula alumnos", Nodo.DATOS_INTERNOS);
            nodo_magister_en_matemacica.agregarVariable("acreditacion", Nodo.DATOS_INTERNOS);

            nodo_magister_en_matemacica.agregarVariable("n.namem", Nodo.DATOS_NODOS_EXTERNOS);

//            postitulo_en_algo.agregarVariable("i_n.i_n.pea", Nodo.INFLUENCIAS_EXTERNAS);

//            postitulo_en_algo.agregarVariable("n.pisi", Nodo.NODOS_INFLUENCIADOS);

            //postitulo_en_algo.agregarVariable("n.pscielo", Nodo.NODOS_INFLUENCIADOS);

            //postitulo_en_algo.calculos = new ICalculosNodo_postitulo_en_algo();

            //______________________________________________________________________________________________________
            //_________________ Nodo Nivel academico Magister en Matemáticas _____________________________________________
            //______________________________________________________________________________________________________
            //TODO Nodo Nivel academico Magister en Matemáticas
            Nodo nivel_academico_magister_en_matematica;
            nivel_academico_magister_en_matematica = new Nodo("n.namem", "nivel academico Magister en Matemáticas");
            nivel_academico_magister_en_matematica.fuzzy = new InferenciaDifusa(
                //entradas 
                new Dictionary<string, VariableDifusa> {
                    {"n.amg", new VariableDifusa("n.amg", 0, 1,	
                                                                new List<FuncionPertenencia>() {
                                                                  new FuncionHombro("calificado", 0, 0.2, 0.4),
                                                                  new FuncionTrapezoidal("destacado", 0.2, 0.4, 0.7, 0.9),
                                                                  new FuncionSaturacion("eminente", 0.7, 0.9, 1.0)
                                                                })},
                    {"docente 2", new VariableDifusa("docente 2", 0, 1,	
                                            new List<FuncionPertenencia>() {
                                              new FuncionHombro("calificado", 0, 0.2, 0.4),
                                              new FuncionTrapezoidal("destacado", 0.2, 0.4, 0.7, 0.9),
                                              new FuncionSaturacion("eminente", 0.7, 0.9, 1.0)
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


            nivel_academico_magister_en_matematica.agregarVariable("n.amg", Nodo.DATOS_NODOS_EXTERNOS);
            nivel_academico_magister_en_matematica.agregarVariable("docente 2", Nodo.DATOS_NODOS_EXTERNOS);

            //nivel_academico_magister_en_matematica.calculos = new ICalculosNodo_nivel_academico_postitulo_en_algo();
          

            

             //____________________________________________________________________________________________
            //_________________ Nodo Magister en Liderazgo, Dirección y comunicación Estratégica ___________________________________________________
            //____________________________________________________________________________________________
          	Nodo nodo_mag_en_lid_dir_y_com_est;
            nodo_mag_en_lid_dir_y_com_est = new Nodo("n.meldyce", "Magister en Liderazgo, Dirección y comunicación Estratégica");
            nodo_mag_en_lid_dir_y_com_est.fuzzy = new InferenciaDifusa(
                //entradas 
                new Dictionary<string, VariableDifusa> {
                    {"matricula alumnos", new VariableDifusa("matricula alumnos", 0, 10,	
                                                                new List<FuncionPertenencia>() {
                                                                  new FuncionHombro("poco", 0, 1, 3),
                                                                  new FuncionTrapezoidal("optimo", 1, 3, 4, 6),
                                                                  new FuncionSaturacion("exedido", 4, 6, 10)
                                                                })},
                    {"acreditacion", new VariableDifusa("acreditacion", 0, 10,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("sin_acreditacion", 0, 0.1 , 0.1),
                                                                new FuncionTrapezoidal("periodo_corto", 1, 1, 2, 3),
                                                                new FuncionTrapezoidal("periodo_medio", 2, 3, 5, 6),
                                                                new FuncionSaturacion("periodo_prolongado", 5, 6, 10)
                                                              })},
                    //napea: id del nodo --->Nivel Academico<---- postitulo en algo :-)
                    {"n.nameldyce", new VariableDifusa("n.nameldyce", 0, 1,
                                                             new List<FuncionPertenencia>(){
                                                              new FuncionHombro("normal", 0, 0.3, 0.4),
                                                              new FuncionTrapezoidal("alto", 0.3, 0.4, 0.5, 0.6),
                                                              new FuncionSaturacion("muy_alto", 0.5, 0.6, 1)
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
              nodo_mag_en_lid_dir_y_com_est.agregarVariable("matricula alumnos", Nodo.DATOS_INTERNOS);
              nodo_mag_en_lid_dir_y_com_est.agregarVariable("acreditacion", Nodo.DATOS_INTERNOS);

              nodo_mag_en_lid_dir_y_com_est.agregarVariable("n.nameldyce", Nodo.DATOS_NODOS_EXTERNOS);
              
//				postitulo_en_algo.agregarVariable("i_n.i_n.pea", Nodo.INFLUENCIAS_EXTERNAS);
              
//              postitulo_en_algo.agregarVariable("n.pisi", Nodo.NODOS_INFLUENCIADOS);
              
//        		postitulo_en_algo.agregarVariable("n.pscielo", Nodo.NODOS_INFLUENCIADOS);

//              postitulo_en_algo.calculos = new ICalculosNodo_postitulo_en_algo();

			//______________________________________________________________________________________________________
            //_________________ Nodo Nivel academico Magister en Liderazgo, Dirección y comunicación Estratégica _____________________________________________
            //______________________________________________________________________________________________________
          	Nodo nivel_academico_mag_en_lid_dir_y_com_est;
            nivel_academico_mag_en_lid_dir_y_com_est = new Nodo("n.nameldyce", "nivel academico Magister en Liderazgo, Dirección y comunicación Estratégica");
            nivel_academico_mag_en_lid_dir_y_com_est.fuzzy = new InferenciaDifusa(
                //entradas 
                new Dictionary<string, VariableDifusa> {
                    {"n.alr", new VariableDifusa("n.alr", 0, 1,	
                                                                new List<FuncionPertenencia>() {
                                                                  new FuncionHombro("calificado", 0, 0.2, 0.4),
                                                                  new FuncionTrapezoidal("destacado", 0.2, 0.4, 0.7, 0.9),
                                                                  new FuncionSaturacion("eminente", 0.7, 0.9, 1.0)
                                                                })},
                    {"docente 2", new VariableDifusa("docente 2", 0, 1,	
                                            new List<FuncionPertenencia>() {
                                              new FuncionHombro("calificado", 0, 0.2, 0.4),
                                              new FuncionTrapezoidal("destacado", 0.2, 0.4, 0.7, 0.9),
                                              new FuncionSaturacion("eminente", 0.7, 0.9, 1.0)
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
  
          
              nivel_academico_mag_en_lid_dir_y_com_est.agregarVariable("n.alr", Nodo.DATOS_NODOS_EXTERNOS);
              nivel_academico_mag_en_lid_dir_y_com_est.agregarVariable("docente 2", Nodo.DATOS_NODOS_EXTERNOS);
              
//              nivel_academico_postitulo_en_algo.calculos = new ICalculosNodo_nivel_academico_postitulo_en_algo();


              //____________________________________________________________________________________________
              //_________________ Nodo Magister en Astronomía ___________________________________________________
              //____________________________________________________________________________________________
              //TODO Magister en Astronomía
              Nodo nodo_mag_en_astronomia;
              nodo_mag_en_astronomia = new Nodo("n.mea", "Magister en Astronomía");
              nodo_mag_en_astronomia.fuzzy = new InferenciaDifusa(
                  //entradas 
                  new Dictionary<string, VariableDifusa> {
                    {"matricula alumnos", new VariableDifusa("matricula alumnos", 0, 10,	
                                                                new List<FuncionPertenencia>() {
                                                                  new FuncionHombro("poco", 0, 1, 3),
                                                                  new FuncionTrapezoidal("optimo", 1, 3, 4, 6),
                                                                  new FuncionSaturacion("exedido", 4, 6, 10)
                                                                })},
                    {"acreditacion", new VariableDifusa("acreditacion", 0, 10,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("sin_acreditacion", 0, 0.1 , 0.1),
                                                                new FuncionTrapezoidal("periodo_corto", 1, 1, 2, 3),
                                                                new FuncionTrapezoidal("periodo_medio", 2, 3, 5, 6),
                                                                new FuncionSaturacion("periodo_prolongado", 5, 6, 10)
                                                              })},
                    //napea: id del nodo --->Nivel Academico<---- postitulo en algo :-)
                    {"n.namea", new VariableDifusa("n.namea", 0, 1,
                                                             new List<FuncionPertenencia>(){
                                                              new FuncionHombro("normal", 0, 0.3, 0.4),
                                                              new FuncionTrapezoidal("alto", 0.3, 0.4, 0.5, 0.6),
                                                              new FuncionSaturacion("muy_alto", 0.5, 0.6, 1)
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
              nodo_mag_en_astronomia.agregarVariable("matricula alumnos", Nodo.DATOS_INTERNOS);
              nodo_mag_en_astronomia.agregarVariable("acreditacion", Nodo.DATOS_INTERNOS);

              nodo_mag_en_astronomia.agregarVariable("n.namea", Nodo.DATOS_NODOS_EXTERNOS);

              //							postitulo_en_algo.agregarVariable("i_n.i_n.pea", Nodo.INFLUENCIAS_EXTERNAS);

              //              postitulo_en_algo.agregarVariable("n.pisi", Nodo.NODOS_INFLUENCIADOS);

              //          		postitulo_en_algo.agregarVariable("n.pscielo", Nodo.NODOS_INFLUENCIADOS);

              //              postitulo_en_algo.calculos = new ICalculosNodo_postitulo_en_algo();

              //______________________________________________________________________________________________________
              //_________________ Nodo Nivel academico Magister en Astronomía _____________________________________________
              //______________________________________________________________________________________________________
              //TODO Nivel Academico Magister en Astronomía
              Nodo nivel_academico_mag_en_astronomia;
              nivel_academico_mag_en_astronomia = new Nodo("n.namea", "nivel academico " + "Magister en Astronomía");
              nivel_academico_mag_en_astronomia.fuzzy = new InferenciaDifusa(
                  //entradas 
                  new Dictionary<string, VariableDifusa> {
                    {"n.aja", new VariableDifusa("n.aja", 0, 1,	
                                                                new List<FuncionPertenencia>() {
                                                                  new FuncionHombro("calificado", 0, 0.2, 0.4),
                                                                  new FuncionTrapezoidal("destacado", 0.2, 0.4, 0.7, 0.9),
                                                                  new FuncionSaturacion("eminente", 0.7, 0.9, 1.0)
                                                                })},
                    {"docente 2", new VariableDifusa("docente 2", 0, 1,	
                                            new List<FuncionPertenencia>() {
                                              new FuncionHombro("calificado", 0, 0.2, 0.4),
                                              new FuncionTrapezoidal("destacado", 0.2, 0.4, 0.7, 0.9),
                                              new FuncionSaturacion("eminente", 0.7, 0.9, 1.0)
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


              nivel_academico_mag_en_astronomia.agregarVariable("n.aja", Nodo.DATOS_NODOS_EXTERNOS);
              nivel_academico_mag_en_astronomia.agregarVariable("docente 2", Nodo.DATOS_NODOS_EXTERNOS);

              //              nivel_academico_postitulo_en_algo.calculos = new ICalculosNodo_nivel_academico_postitulo_en_algo();

              //____________________________________________________________________________________________
              //_________________ Nodo Magister en Ciencias mención Ingeniería en Alimentos ___________________________________________________
              //____________________________________________________________________________________________
              //TODO Magister en Ciencias mención Ingeniería en Alimentos
              Nodo nodo_mag_en_ciencias_mencion_ing_en_alimentos;
              nodo_mag_en_ciencias_mencion_ing_en_alimentos = new Nodo("n.mecmiea", "Magister en Ciencias mención Ingeniería en Alimentos");
              nodo_mag_en_ciencias_mencion_ing_en_alimentos.fuzzy = new InferenciaDifusa(
                  //entradas 
                  new Dictionary<string, VariableDifusa> {
                    {"matricula alumnos", new VariableDifusa("matricula alumnos", 0, 10,	
                                                                new List<FuncionPertenencia>() {
                                                                  new FuncionHombro("poco", 0, 1, 3),
                                                                  new FuncionTrapezoidal("optimo", 1, 3, 4, 6),
                                                                  new FuncionSaturacion("exedido", 4, 6, 10)
                                                                })},
                    {"acreditacion", new VariableDifusa("acreditacion", 0, 10,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("sin_acreditacion", 0, 0.1 , 0.1),
                                                                new FuncionTrapezoidal("periodo_corto", 1, 1, 2, 3),
                                                                new FuncionTrapezoidal("periodo_medio", 2, 3, 5, 6),
                                                                new FuncionSaturacion("periodo_prolongado", 5, 6, 10)
                                                              })},
                    //napea: id del nodo --->Nivel Academico<---- postitulo en algo :-)
                    {"n.namecmiea", new VariableDifusa("n.namecmiea", 0, 1,
                                                             new List<FuncionPertenencia>(){
                                                              new FuncionHombro("normal", 0, 0.3, 0.4),
                                                              new FuncionTrapezoidal("alto", 0.3, 0.4, 0.5, 0.6),
                                                              new FuncionSaturacion("muy_alto", 0.5, 0.6, 1)
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
              nodo_mag_en_ciencias_mencion_ing_en_alimentos.agregarVariable("matricula alumnos", Nodo.DATOS_INTERNOS);
              nodo_mag_en_ciencias_mencion_ing_en_alimentos.agregarVariable("acreditacion", Nodo.DATOS_INTERNOS);

              nodo_mag_en_ciencias_mencion_ing_en_alimentos.agregarVariable("n.namecmiea", Nodo.DATOS_NODOS_EXTERNOS);

              //			postitulo_en_algo.agregarVariable("i_n.i_n.pea", Nodo.INFLUENCIAS_EXTERNAS);

              //            postitulo_en_algo.agregarVariable("n.pisi", Nodo.NODOS_INFLUENCIADOS);

              //      		postitulo_en_algo.agregarVariable("n.pscielo", Nodo.NODOS_INFLUENCIADOS);

              //            postitulo_en_algo.calculos = new ICalculosNodo_postitulo_en_algo();

              //______________________________________________________________________________________________________
              //_________________ Nodo Nivel academico Magister en Ciencias mención Ingeniería en Alimentos _____________________________________________
              //______________________________________________________________________________________________________
              //TODO Nivel Academico Magister en Ciencias mención Ingeniería en Alimentos
              Nodo nivel_academico_mag_en_ciencias_mencion_ing_en_alimentos;
              nivel_academico_mag_en_ciencias_mencion_ing_en_alimentos = new Nodo("n.namecmiea", "nivel academico " + "Magister en Ciencias mención Ingeniería en Alimentos");
              nivel_academico_mag_en_ciencias_mencion_ing_en_alimentos.fuzzy = new InferenciaDifusa(
                  //entradas 
                  new Dictionary<string, VariableDifusa> {
                    {"n.ahp", new VariableDifusa("n.ahp", 0, 1,	
                                                                new List<FuncionPertenencia>() {
                                                                  new FuncionHombro("calificado", 0, 0.2, 0.4),
                                                                  new FuncionTrapezoidal("destacado", 0.2, 0.4, 0.7, 0.9),
                                                                  new FuncionSaturacion("eminente", 0.7, 0.9, 1.0)
                                                                })},
                    {"docente 2", new VariableDifusa("docente 2", 0, 1,	
                                            new List<FuncionPertenencia>() {
                                              new FuncionHombro("calificado", 0, 0.2, 0.4),
                                              new FuncionTrapezoidal("destacado", 0.2, 0.4, 0.7, 0.9),
                                              new FuncionSaturacion("eminente", 0.7, 0.9, 1.0)
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


              nivel_academico_mag_en_ciencias_mencion_ing_en_alimentos.agregarVariable("n.ahp", Nodo.DATOS_NODOS_EXTERNOS);
              nivel_academico_mag_en_ciencias_mencion_ing_en_alimentos.agregarVariable("docente 2", Nodo.DATOS_NODOS_EXTERNOS);

              //              nivel_academico_postitulo_en_algo.calculos = new ICalculosNodo_nivel_academico_postitulo_en_algo();




              //____________________________________________________________________________________________
              //_________________ Nodo Magister en Estudios Latinoamericanos mención en Lingüística o Filosofía o Literatura ___________________________________________________
              //____________________________________________________________________________________________
              //TODO Magister en Estudios Latinoamericanos mención en Lingüística o Filosofía o Literatura
              Nodo nodo_mag_es_std_lat;
              nodo_mag_es_std_lat = new Nodo("n.meelmelofol", "Magister en Estudios Latinoamericanos mención en Lingüística o Filosofía o Literatura");
              nodo_mag_es_std_lat.fuzzy = new InferenciaDifusa(
                  //entradas 
                  new Dictionary<string, VariableDifusa> {
                    {"matricula alumnos", new VariableDifusa("matricula alumnos", 0, 10,	
                                                                new List<FuncionPertenencia>() {
                                                                  new FuncionHombro("poco", 0, 1, 3),
                                                                  new FuncionTrapezoidal("optimo", 1, 3, 4, 6),
                                                                  new FuncionSaturacion("exedido", 4, 6, 10)
                                                                })},
                    {"acreditacion", new VariableDifusa("acreditacion", 0, 10,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("sin_acreditacion", 0, 0.1 , 0.1),
                                                                new FuncionTrapezoidal("periodo_corto", 1, 1, 2, 3),
                                                                new FuncionTrapezoidal("periodo_medio", 2, 3, 5, 6),
                                                                new FuncionSaturacion("periodo_prolongado", 5, 6, 10)
                                                              })},
                    //napea: id del nodo --->Nivel Academico<---- postitulo en algo :-)
                    {"n.nameelmelofol", new VariableDifusa("n.nameelmelofol", 0, 1,
                                                             new List<FuncionPertenencia>(){
                                                              new FuncionHombro("normal", 0, 0.3, 0.4),
                                                              new FuncionTrapezoidal("alto", 0.3, 0.4, 0.5, 0.6),
                                                              new FuncionSaturacion("muy_alto", 0.5, 0.6, 1)
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
              nodo_mag_es_std_lat.agregarVariable("matricula alumnos", Nodo.DATOS_INTERNOS);
              nodo_mag_es_std_lat.agregarVariable("acreditacion", Nodo.DATOS_INTERNOS);

              nodo_mag_es_std_lat.agregarVariable("n.nameelmelofol", Nodo.DATOS_NODOS_EXTERNOS);

              //			postitulo_en_algo.agregarVariable("i_n.i_n.pea", Nodo.INFLUENCIAS_EXTERNAS);

              //            postitulo_en_algo.agregarVariable("n.pisi", Nodo.NODOS_INFLUENCIADOS);

              //      		postitulo_en_algo.agregarVariable("n.pscielo", Nodo.NODOS_INFLUENCIADOS);

              //            postitulo_en_algo.calculos = new ICalculosNodo_postitulo_en_algo();

              //______________________________________________________________________________________________________
              //_________________ Nodo Nivel academico Magister en Estudios Latinoamericanos mención en Lingüística o Filosofía o Literatura _____________________________________________
              //______________________________________________________________________________________________________
              //TODO Nivel Academico Estudios Latinoamericanos mención en Lingüística o Filosofía o Literatura
              Nodo nivel_academico_mag_es_std_lat;
              nivel_academico_mag_es_std_lat = new Nodo("n.nameelmelofol", "nivel academico " + "Magister en Estudios Latinoamericanos mención en Lingüística o Filosofía o Literatura");
              nivel_academico_mag_es_std_lat.fuzzy = new InferenciaDifusa(
                  //entradas 
                  new Dictionary<string, VariableDifusa> {
                    {"n.acnp", new VariableDifusa("n.acnp", 0, 1,	
                                                                new List<FuncionPertenencia>() {
                                                                  new FuncionHombro("calificado", 0, 0.2, 0.4),
                                                                  new FuncionTrapezoidal("destacado", 0.2, 0.4, 0.7, 0.9),
                                                                  new FuncionSaturacion("eminente", 0.7, 0.9, 1.0)
                                                                })},
                    {"docente 2", new VariableDifusa("docente 2", 0, 1,	
                                            new List<FuncionPertenencia>() {
                                              new FuncionHombro("calificado", 0, 0.2, 0.4),
                                              new FuncionTrapezoidal("destacado", 0.2, 0.4, 0.7, 0.9),
                                              new FuncionSaturacion("eminente", 0.7, 0.9, 1.0)
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


              nivel_academico_mag_es_std_lat.agregarVariable("n.acnp", Nodo.DATOS_NODOS_EXTERNOS);
              nivel_academico_mag_es_std_lat.agregarVariable("docente 2", Nodo.DATOS_NODOS_EXTERNOS);

              //              nivel_academico_postitulo_en_algo.calculos = new ICalculosNodo_nivel_academico_postitulo_en_algo();

































            //*******************************************************************************************************
            //*****************************           Ingresando Nodos
            //*******************************************************************************************************


            //Escribiendo nodos en archivo
            manejador_de_archivos.ingresarNuevoNodo(nodo_mag_en_mecanica_computacional);
            manejador_de_archivos.ingresarNuevoNodo(nivel_academico_nodo_mag_en_mecanica_computacional);

            manejador_de_archivos.ingresarNuevoNodo(nodo_magister_en_ciencias_fiscas);
            manejador_de_archivos.ingresarNuevoNodo(nivel_academico_magister_en_ciencias_fisicas);

            manejador_de_archivos.ingresarNuevoNodo(nodo_magister_en_matemacica);
            manejador_de_archivos.ingresarNuevoNodo(nivel_academico_magister_en_matematica);

            manejador_de_archivos.ingresarNuevoNodo(nodo_mag_en_lid_dir_y_com_est);
            manejador_de_archivos.ingresarNuevoNodo(nivel_academico_mag_en_lid_dir_y_com_est);

            manejador_de_archivos.ingresarNuevoNodo(nodo_mag_en_astronomia);
            manejador_de_archivos.ingresarNuevoNodo(nivel_academico_mag_en_astronomia);


            manejador_de_archivos.ingresarNuevoNodo(nodo_mag_en_ciencias_mencion_ing_en_alimentos);
            manejador_de_archivos.ingresarNuevoNodo(nivel_academico_mag_en_ciencias_mencion_ing_en_alimentos);

            manejador_de_archivos.ingresarNuevoNodo(nodo_mag_es_std_lat);
            manejador_de_archivos.ingresarNuevoNodo(nivel_academico_mag_es_std_lat);

            Console.WriteLine("Nodos Magister ingresados ingresado");
            // escribir nodos X



            ///*-------


        }
    }
}