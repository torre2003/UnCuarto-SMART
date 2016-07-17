using AccesoADatos;
using ContenedorImplementacionesInterfacesCalculoModeloMBCIF;
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
        public List<Nodo> Nodos = new List<Nodo>();
        
        public NodosProgramasMagister()
        {
            #region Nodo Magister en Mecanica Computacional
            //ingresar nodos X
            //TODO Magister en Mecanica Computacional 
            //___________________________________________________________________________________
            //_________________ Nodo Magister en Mecanica Computacional _________
            //___________________________________________________________________________________
            Nodo nodo_mag_en_mecanica_computacional;
            nodo_mag_en_mecanica_computacional = new Nodo("nmemc", "Magister en Mecanica Computacional");
            nodo_mag_en_mecanica_computacional.fuzzy = new InferenciaDifusa(
                //entradas 
                new Dictionary<string, VariableDifusa> {
                    {"matricula alumnos", new VariableDifusa("matricula alumnos", 0, 10,	
                                                                new List<FuncionPertenencia>() {
                                                                  new FuncionHombro("poco", 0, 1, 3),
                                                                  new FuncionTrapezoidal("optimo", 1, 3, 4, 6),
                                                                  new FuncionSaturacion("excedido", 4, 6, 10)
                                                                })},
                    {"acreditacion", new VariableDifusa("acreditacion", 0, 10,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("sin_acreditacion", 0, 0.1 , 0.1),
                                                                new FuncionTrapezoidal("periodo_corto", 1, 1, 2, 3),
                                                                new FuncionTrapezoidal("periodo_medio", 2, 3, 5, 6),
                                                                new FuncionSaturacion("periodo_prolongado", 5, 6, 10)
                                                              })},
                    //napea: id del nodo Nivel Academico postitulo en algo :-)
                    {"nnamemc", new VariableDifusa("nnamemc", 0, 1,
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

            nodo_mag_en_mecanica_computacional.agregarVariable("nnamemc", Nodo.DATOS_NODOS_EXTERNOS);


            //-- influencias DESDE este nodo -----
			nodo_mag_en_mecanica_computacional.agregarVariable("npisi", Nodo.NODOS_INFLUENCIADOS);
			nodo_mag_en_mecanica_computacional.agregarVariable("npscielo", Nodo.NODOS_INFLUENCIADOS);
			nodo_mag_en_mecanica_computacional.agregarVariable("npe", Nodo.NODOS_INFLUENCIADOS);


			//-- influencias HACIA este nodo -----
			nodo_mag_en_mecanica_computacional.agregarVariable("i_ndp_nmemc", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_mag_en_mecanica_computacional.agregarVariable("i_ni_nmemc", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_mag_en_mecanica_computacional.agregarVariable("i_nfyb_nmemc", Nodo.INFLUENCIAS_EXTERNAS);


            nodo_mag_en_mecanica_computacional.calculos = new ICalculosNodo_programas("nnamemc");
            
            #endregion

            #region Nodo Nivel academico Magister en Mecanica Computacional
            //______________________________________________________________________________________________________
            //_________________ Nodo Nivel academico Magister en Mecanica Computacional _________
            //______________________________________________________________________________________________________
            //TODO nivel academico magister en emcanica computacional
            Nodo nivel_academico_nodo_mag_en_mecanica_computacional;
            nivel_academico_nodo_mag_en_mecanica_computacional = new Nodo("nnamemc", "nivel academico Magister en Mecanica Computacional");
            nivel_academico_nodo_mag_en_mecanica_computacional.fuzzy = new InferenciaDifusa(
                //entradas 
                new Dictionary<string, VariableDifusa> {
                    {"namgs", new VariableDifusa("namgs", 0, 1,	
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


            nivel_academico_nodo_mag_en_mecanica_computacional.agregarVariable("namgs", Nodo.DATOS_NODOS_EXTERNOS);

            

            nivel_academico_nodo_mag_en_mecanica_computacional.calculos = new InterfaceCalculoNivelesAcademicos(new string[] { "namgs" });
            
            #endregion






            #region  Nodo Magister en Ciencias en Fisica
            //____________________________________________________________________________________________
            //_________________ Nodo Magister en Ciencias en Fisica_______________________________________
            //____________________________________________________________________________________________
            //TODO Magister en Ciencias en Fisica
            Nodo nodo_magister_en_ciencias_fiscas;
            nodo_magister_en_ciencias_fiscas = new Nodo("nmecef", "Magister en Ciencias en Fisica");
            nodo_magister_en_ciencias_fiscas.fuzzy = new InferenciaDifusa(
                //entradas 
                new Dictionary<string, VariableDifusa> {
                    {"matricula alumnos", new VariableDifusa("matricula alumnos", 0, 10,	
                                                                new List<FuncionPertenencia>() {
                                                                  new FuncionHombro("poco", 0, 1, 3),
                                                                  new FuncionTrapezoidal("optimo", 1, 3, 4, 6),
                                                                  new FuncionSaturacion("excedido", 4, 6, 10)
                                                                })},
                    {"acreditacion", new VariableDifusa("acreditacion", 0, 10,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("sin_acreditacion", 0, 0.1 , 0.1),
                                                                new FuncionTrapezoidal("periodo_corto", 1, 1, 2, 3),
                                                                new FuncionTrapezoidal("periodo_medio", 2, 3, 5, 6),
                                                                new FuncionSaturacion("periodo_prolongado", 5, 6, 10)
                                                              })},
                    //napea: id del nodo Nivel Academico postitulo en algo :-)
                    {"nnamecef", new VariableDifusa("nnamecef", 0, 1,
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

            nodo_magister_en_ciencias_fiscas.agregarVariable("nnamecef", Nodo.DATOS_NODOS_EXTERNOS);


            //-- influencias DESDE este nodo -----
			nodo_magister_en_ciencias_fiscas.agregarVariable("npisi", Nodo.NODOS_INFLUENCIADOS);
			nodo_magister_en_ciencias_fiscas.agregarVariable("npscielo", Nodo.NODOS_INFLUENCIADOS);
			nodo_magister_en_ciencias_fiscas.agregarVariable("npe", Nodo.NODOS_INFLUENCIADOS);


			//-- influencias HACIA este nodo -----
			nodo_magister_en_ciencias_fiscas.agregarVariable("i_ndp_nmecef", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_magister_en_ciencias_fiscas.agregarVariable("i_ni_nmecef", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_magister_en_ciencias_fiscas.agregarVariable("i_nfyb_nmecef", Nodo.INFLUENCIAS_EXTERNAS);


            nodo_magister_en_ciencias_fiscas.calculos = new ICalculosNodo_programas("nnamecef");
            #endregion






            #region Nodo Nivel academico Magister en Ciencias en Fisica
            //______________________________________________________________________________________________________
            //_________________ Nodo Nivel academico Magister en Ciencias en Fisica _____________________________________________
            //______________________________________________________________________________________________________
            //TODO Nivel academico Magister en Ciencias en Fisica
            Nodo nivel_academico_magister_en_ciencias_fisicas;
            nivel_academico_magister_en_ciencias_fisicas = new Nodo("nnamecef", "nivel academico Magister en Ciencias en Fisica");
            nivel_academico_magister_en_ciencias_fisicas.fuzzy = new InferenciaDifusa(
                //entradas 
                new Dictionary<string, VariableDifusa> {
                    {"napv", new VariableDifusa("napv", 0, 1,	
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


            nivel_academico_magister_en_ciencias_fisicas.agregarVariable("napv", Nodo.DATOS_NODOS_EXTERNOS);



            nivel_academico_magister_en_ciencias_fisicas.calculos = new InterfaceCalculoNivelesAcademicos(new string[] { "napv" });


            
            #endregion



            #region  Nodo Magister en Matematicas"
            //____________________________________________________________________________________________
            //_________________ Nodo Magister en Matematicas" ___________________________________________________
            //____________________________________________________________________________________________
            //TODO Nodo Magister en Matematicas"

            Nodo nodo_magister_en_matematica;
            nodo_magister_en_matematica = new Nodo("nmem", "Magister en Matematicas");
            nodo_magister_en_matematica.fuzzy = new InferenciaDifusa(
                //entradas 
                new Dictionary<string, VariableDifusa> {
                    {"matricula alumnos", new VariableDifusa("matricula alumnos", 0, 10,	
                                                                new List<FuncionPertenencia>() {
                                                                  new FuncionHombro("poco", 0, 1, 3),
                                                                  new FuncionTrapezoidal("optimo", 1, 3, 4, 6),                                                                 
                                                                  new FuncionSaturacion("excedido", 4, 6, 10)
                                                                })},
                    {"acreditacion", new VariableDifusa("acreditacion", 0, 10,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("sin_acreditacion", 0, 0.1 , 0.1),
                                                                new FuncionTrapezoidal("periodo_corto", 1, 1, 2, 3),
                                                                new FuncionTrapezoidal("periodo_medio", 2, 3, 5, 6),
                                                                new FuncionSaturacion("periodo_prolongado", 5, 6, 10)
                                                              })},
                    //napea: id del nodo Nivel Academico postitulo en algo :-)
                    {"nnamem", new VariableDifusa("nnamem", 0, 1,
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

            nodo_magister_en_matematica.agregarVariable("matricula alumnos", Nodo.DATOS_INTERNOS);
            nodo_magister_en_matematica.agregarVariable("acreditacion", Nodo.DATOS_INTERNOS);


            nodo_magister_en_matematica.agregarVariable("nnamem", Nodo.DATOS_NODOS_EXTERNOS);


            //-- influencias DESDE este nodo -----
			nodo_magister_en_matematica.agregarVariable("npisi", Nodo.NODOS_INFLUENCIADOS);
			nodo_magister_en_matematica.agregarVariable("npscielo", Nodo.NODOS_INFLUENCIADOS);
			nodo_magister_en_matematica.agregarVariable("npe", Nodo.NODOS_INFLUENCIADOS);


			//-- influencias HACIA este nodo -----
			nodo_magister_en_matematica.agregarVariable("i_ndp_nmem", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_magister_en_matematica.agregarVariable("i_ni_nmem", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_magister_en_matematica.agregarVariable("i_nfyb_nmem", Nodo.INFLUENCIAS_EXTERNAS);


            nodo_magister_en_matematica.calculos = new ICalculosNodo_programas("nnamem");
            #endregion

            #region  Nodo Nivel academico Magister en Matematicas
            //______________________________________________________________________________________________________
            //_________________ Nodo Nivel academico Magister en Matematicas _____________________________________________
            //______________________________________________________________________________________________________
            //TODO Nodo Nivel academico Magister en Matematicas
            Nodo nivel_academico_magister_en_matematica;
            nivel_academico_magister_en_matematica = new Nodo("nnamem", "nivel academico Magister en Matematicas");
            nivel_academico_magister_en_matematica.fuzzy = new InferenciaDifusa(
                //entradas 
                new Dictionary<string, VariableDifusa> {
                    {"namc", new VariableDifusa("namc", 0, 1,	
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


            nivel_academico_magister_en_matematica.agregarVariable("namc", Nodo.DATOS_NODOS_EXTERNOS);



            nivel_academico_magister_en_matematica.calculos = new InterfaceCalculoNivelesAcademicos(new string[] { "namc" });

            #endregion

            #region Nodo Magister en Liderazgo, Direccion y comunicacion Estrategica
            //____________________________________________________________________________________________
            //_________________ Nodo Magister en Liderazgo, Direccion y comunicacion Estrategica ___________________________________________________
            //____________________________________________________________________________________________
          	Nodo nodo_mag_en_lid_dir_y_com_est;
            nodo_mag_en_lid_dir_y_com_est = new Nodo("nmeldyce", "Magister en Liderazgo, Direccion y comunicacion Estrategica");
            nodo_mag_en_lid_dir_y_com_est.fuzzy = new InferenciaDifusa(
                //entradas 
                new Dictionary<string, VariableDifusa> {
                    {"matricula alumnos", new VariableDifusa("matricula alumnos", 0, 10,	
                                                                new List<FuncionPertenencia>() {
                                                                  new FuncionHombro("poco", 0, 1, 3),
                                                                  new FuncionTrapezoidal("optimo", 1, 3, 4, 6),

                                                                  new FuncionSaturacion("excedido", 4, 6, 10)
                                                                })},
                    {"acreditacion", new VariableDifusa("acreditacion", 0, 10,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("sin_acreditacion", 0, 0.1 , 0.1),
                                                                new FuncionTrapezoidal("periodo_corto", 1, 1, 2, 3),
                                                                new FuncionTrapezoidal("periodo_medio", 2, 3, 5, 6),
                                                                new FuncionSaturacion("periodo_prolongado", 5, 6, 10)
                                                              })},
                    //napea: id del nodo --->Nivel Academico<---- postitulo en algo :-)
                    {"nnameldyce", new VariableDifusa("nnameldyce", 0, 1,
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

              nodo_mag_en_lid_dir_y_com_est.agregarVariable("nnameldyce", Nodo.DATOS_NODOS_EXTERNOS);
              

            //-- influencias DESDE este nodo -----
			nodo_mag_en_lid_dir_y_com_est.agregarVariable("npisi", Nodo.NODOS_INFLUENCIADOS);
			nodo_mag_en_lid_dir_y_com_est.agregarVariable("npscielo", Nodo.NODOS_INFLUENCIADOS);
			nodo_mag_en_lid_dir_y_com_est.agregarVariable("npe", Nodo.NODOS_INFLUENCIADOS);
              

			//-- influencias HACIA este nodo -----
			nodo_mag_en_lid_dir_y_com_est.agregarVariable("i_ndp_nmeldyce", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_mag_en_lid_dir_y_com_est.agregarVariable("i_ni_nmeldyce", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_mag_en_lid_dir_y_com_est.agregarVariable("i_nfyb_nmeldyce", Nodo.INFLUENCIAS_EXTERNAS);
              

              nodo_mag_en_lid_dir_y_com_est.calculos = new ICalculosNodo_programas("nnameldyce"); ;
            #endregion
            
              #region Nodo Nivel academico Magister en Liderazgo, Direccion y comunicacion Estrategica
              //______________________________________________________________________________________________________
            //_________________ Nodo Nivel academico Magister en Liderazgo, Direccion y comunicacion Estrategica _____________________________________________
            //______________________________________________________________________________________________________
          	Nodo nivel_academico_mag_en_lid_dir_y_com_est;
            nivel_academico_mag_en_lid_dir_y_com_est = new Nodo("nnameldyce", "nivel academico Magister en Liderazgo, Direccion y comunicacion Estrategica");
            nivel_academico_mag_en_lid_dir_y_com_est.fuzzy = new InferenciaDifusa(
                //entradas 
                new Dictionary<string, VariableDifusa> {
                    {"nalr", new VariableDifusa("nalr", 0, 1,	
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
  
          
              nivel_academico_mag_en_lid_dir_y_com_est.agregarVariable("nalr", Nodo.DATOS_NODOS_EXTERNOS);


              nivel_academico_mag_en_lid_dir_y_com_est.calculos = new InterfaceCalculoNivelesAcademicos(new string[] { "nalr" });
              #endregion







              #region Nodo Magister en Astronomia
              //____________________________________________________________________________________________
              //_________________ Nodo Magister en Astronomia ___________________________________________________
              //____________________________________________________________________________________________
              //TODO Magister en Astronomia
              Nodo nodo_mag_en_astronomia;
              nodo_mag_en_astronomia = new Nodo("nmea", "Magister en Astronomia");
              nodo_mag_en_astronomia.fuzzy = new InferenciaDifusa(
                  //entradas 
                  new Dictionary<string, VariableDifusa> {
                    {"matricula alumnos", new VariableDifusa("matricula alumnos", 0, 10,	
                                                                new List<FuncionPertenencia>() {
                                                                  new FuncionHombro("poco", 0, 1, 3),
                                                                  new FuncionTrapezoidal("optimo", 1, 3, 4, 6),
                                                                  new FuncionSaturacion("excedido", 4, 6, 10)
                                                                })},
                    {"acreditacion", new VariableDifusa("acreditacion", 0, 10,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("sin_acreditacion", 0, 0.1 , 0.1),
                                                                new FuncionTrapezoidal("periodo_corto", 1, 1, 2, 3),
                                                                new FuncionTrapezoidal("periodo_medio", 2, 3, 5, 6),
                                                                new FuncionSaturacion("periodo_prolongado", 5, 6, 10)
                                                              })},
                    //napea: id del nodo --->Nivel Academico<---- postitulo en algo :-)
                    {"nnamea", new VariableDifusa("nnamea", 0, 1,
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

              nodo_mag_en_astronomia.agregarVariable("nnamea", Nodo.DATOS_NODOS_EXTERNOS);


            //-- influencias DESDE este nodo -----
			nodo_mag_en_astronomia.agregarVariable("npisi", Nodo.NODOS_INFLUENCIADOS);
			nodo_mag_en_astronomia.agregarVariable("npscielo", Nodo.NODOS_INFLUENCIADOS);
			nodo_mag_en_astronomia.agregarVariable("npe", Nodo.NODOS_INFLUENCIADOS);


			//-- influencias HACIA este nodo -----
			nodo_mag_en_astronomia.agregarVariable("i_ndp_nmea", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_mag_en_astronomia.agregarVariable("i_ni_nmea", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_mag_en_astronomia.agregarVariable("i_nfyb_nmea", Nodo.INFLUENCIAS_EXTERNAS);


              nodo_mag_en_astronomia.calculos = new ICalculosNodo_programas("nnamea");
              #endregion

              #region Nodo Nivel academico Magister en Astronomia
              //______________________________________________________________________________________________________
              //_________________ Nodo Nivel academico Magister en Astronomia _____________________________________________
              //______________________________________________________________________________________________________
              //TODO Nivel Academico Magister en Astronomia
              Nodo nivel_academico_mag_en_astronomia;
              nivel_academico_mag_en_astronomia = new Nodo("nnamea", "nivel academico " + "Magister en Astronomia");
              nivel_academico_mag_en_astronomia.fuzzy = new InferenciaDifusa(
                  //entradas 
                  new Dictionary<string, VariableDifusa> {
                    {"naja", new VariableDifusa("naja", 0, 1,	
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


              nivel_academico_mag_en_astronomia.agregarVariable("naja", Nodo.DATOS_NODOS_EXTERNOS);


              nivel_academico_mag_en_astronomia.calculos = new InterfaceCalculoNivelesAcademicos(new string[] { "naja" });
              #endregion





              #region Nodo Magister en Ciencias mencion Ingenieria en Alimentos
              //____________________________________________________________________________________________
              //_________________ Nodo Magister en Ciencias mencion Ingenieria en Alimentos ___________________________________________________
              //____________________________________________________________________________________________
              //TODO Magister en Ciencias mencion Ingenieria en Alimentos
              Nodo nodo_mag_en_ciencias_mencion_ing_en_alimentos;
              nodo_mag_en_ciencias_mencion_ing_en_alimentos = new Nodo("nmecmiea", "Magister en Ciencias mencion Ingenieria en Alimentos");
              nodo_mag_en_ciencias_mencion_ing_en_alimentos.fuzzy = new InferenciaDifusa(
                  //entradas 
                  new Dictionary<string, VariableDifusa> {
                    {"matricula alumnos", new VariableDifusa("matricula alumnos", 0, 10,	
                                                                new List<FuncionPertenencia>() {
                                                                  new FuncionHombro("poco", 0, 1, 3),
                                                                  new FuncionTrapezoidal("optimo", 1, 3, 4, 6),

                                                                  new FuncionSaturacion("excedido", 4, 6, 10)
                                                                })},
                    {"acreditacion", new VariableDifusa("acreditacion", 0, 10,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("sin_acreditacion", 0, 0.1 , 0.1),
                                                                new FuncionTrapezoidal("periodo_corto", 1, 1, 2, 3),
                                                                new FuncionTrapezoidal("periodo_medio", 2, 3, 5, 6),
                                                                new FuncionSaturacion("periodo_prolongado", 5, 6, 10)
                                                              })},
                    //napea: id del nodo --->Nivel Academico<---- postitulo en algo :-)
                    {"nnamecmiea", new VariableDifusa("nnamecmiea", 0, 1,
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

              nodo_mag_en_ciencias_mencion_ing_en_alimentos.agregarVariable("nnamecmiea", Nodo.DATOS_NODOS_EXTERNOS);


            //-- influencias DESDE este nodo -----
			nodo_mag_en_ciencias_mencion_ing_en_alimentos.agregarVariable("npisi", Nodo.NODOS_INFLUENCIADOS);
			nodo_mag_en_ciencias_mencion_ing_en_alimentos.agregarVariable("npscielo", Nodo.NODOS_INFLUENCIADOS);
			nodo_mag_en_ciencias_mencion_ing_en_alimentos.agregarVariable("npe", Nodo.NODOS_INFLUENCIADOS);


			//-- influencias HACIA este nodo -----
			nodo_mag_en_ciencias_mencion_ing_en_alimentos.agregarVariable("i_ndp_nmecmiea", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_mag_en_ciencias_mencion_ing_en_alimentos.agregarVariable("i_ni_nmecmiea", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_mag_en_ciencias_mencion_ing_en_alimentos.agregarVariable("i_nfyb_nmecmiea", Nodo.INFLUENCIAS_EXTERNAS);


              nodo_mag_en_ciencias_mencion_ing_en_alimentos.calculos = new ICalculosNodo_programas("nnamecmiea");
              #endregion

              #region Nodo Nivel academico Magister en Ciencias mencion Ingenieria en Alimentos
              //______________________________________________________________________________________________________
              //_________________ Nodo Nivel academico Magister en Ciencias mencion Ingenieria en Alimentos _____________________________________________
              //______________________________________________________________________________________________________
              //TODO Nivel Academico Magister en Ciencias mencion Ingenieria en Alimentos
              Nodo nivel_academico_mag_en_ciencias_mencion_ing_en_alimentos;
              nivel_academico_mag_en_ciencias_mencion_ing_en_alimentos = new Nodo("nnamecmiea", "nivel academico " + "Magister en Ciencias mencion Ingenieria en Alimentos");
              nivel_academico_mag_en_ciencias_mencion_ing_en_alimentos.fuzzy = new InferenciaDifusa(
                  //entradas 
                  new Dictionary<string, VariableDifusa> {
                    {"nahp", new VariableDifusa("nahp", 0, 1,	
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


              nivel_academico_mag_en_ciencias_mencion_ing_en_alimentos.agregarVariable("nahp", Nodo.DATOS_NODOS_EXTERNOS);




              nivel_academico_mag_en_astronomia.calculos = new InterfaceCalculoNivelesAcademicos(new string[] { "nahp" });
              #endregion





              #region Nodo Magister en Estudios Latinoamericanos mencion en Lingüistica o Filosofia o Literatura
              //____________________________________________________________________________________________
              //_________________ Nodo Magister en Estudios Latinoamericanos mencion en Lingüistica o Filosofia o Literatura ___________________________________________________
              //____________________________________________________________________________________________
              //TODO Magister en Estudios Latinoamericanos mencion en Lingüistica o Filosofia o Literatura
              Nodo nodo_mag_es_std_lat;
              nodo_mag_es_std_lat = new Nodo("nmeelmelofol", "Magister en Estudios Latinoamericanos mencion en Lingüistica o Filosofia o Literatura");
              nodo_mag_es_std_lat.fuzzy = new InferenciaDifusa(
                  //entradas 
                  new Dictionary<string, VariableDifusa> {
                    {"matricula alumnos", new VariableDifusa("matricula alumnos", 0, 10,	
                                                                new List<FuncionPertenencia>() {
                                                                  new FuncionHombro("poco", 0, 1, 3),
                                                                  new FuncionTrapezoidal("optimo", 1, 3, 4, 6),

                                                                  new FuncionSaturacion("excedido", 4, 6, 10)
                                                                })},
                    {"acreditacion", new VariableDifusa("acreditacion", 0, 10,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("sin_acreditacion", 0, 0.1 , 0.1),
                                                                new FuncionTrapezoidal("periodo_corto", 1, 1, 2, 3),
                                                                new FuncionTrapezoidal("periodo_medio", 2, 3, 5, 6),
                                                                new FuncionSaturacion("periodo_prolongado", 5, 6, 10)
                                                              })},
                    //napea: id del nodo --->Nivel Academico<---- postitulo en algo :-)
                    {"nnameelmelofol", new VariableDifusa("nnameelmelofol", 0, 1,
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

              nodo_mag_es_std_lat.agregarVariable("nnameelmelofol", Nodo.DATOS_NODOS_EXTERNOS);


            //-- influencias DESDE este nodo -----
			nodo_mag_es_std_lat.agregarVariable("npisi", Nodo.NODOS_INFLUENCIADOS);
			nodo_mag_es_std_lat.agregarVariable("npscielo", Nodo.NODOS_INFLUENCIADOS);
			nodo_mag_es_std_lat.agregarVariable("npe", Nodo.NODOS_INFLUENCIADOS);


			//-- influencias HACIA este nodo -----
			nodo_mag_es_std_lat.agregarVariable("i_ndp_nmeelmelofol", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_mag_es_std_lat.agregarVariable("i_ni_nmeelmelofol", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_mag_es_std_lat.agregarVariable("i_nfyb_nmeelmelofol", Nodo.INFLUENCIAS_EXTERNAS);


              #endregion

              #region Nodo Nivel academico Magister en Estudios Latinoamericanos mencion en Lingüistica o Filosofia o Literatura
              //______________________________________________________________________________________________________
              //_________________ Nodo Nivel academico Magister en Estudios Latinoamericanos mencion en Lingüistica o Filosofia o Literatura _____________________________________________
              //______________________________________________________________________________________________________
              //TODO Nivel Academico Estudios Latinoamericanos mencion en Lingüistica o Filosofia o Literatura
              Nodo nivel_academico_mag_es_std_lat;
              nivel_academico_mag_es_std_lat = new Nodo("nnameelmelofol", "nivel academico " + "Magister en Estudios Latinoamericanos mencion en Lingüistica o Filosofia o Literatura");
              nivel_academico_mag_es_std_lat.fuzzy = new InferenciaDifusa(
                  //entradas 
                  new Dictionary<string, VariableDifusa> {
                    {"nacnp", new VariableDifusa("nacnp", 0, 1,	
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


              nivel_academico_mag_es_std_lat.agregarVariable("nacnp", Nodo.DATOS_NODOS_EXTERNOS);




              nivel_academico_mag_es_std_lat.calculos = new InterfaceCalculoNivelesAcademicos(new string[] { "nacnp" });

              #endregion









              //*******************************************************************************************************
            //*****************************           Ingresando Nodos
            //*******************************************************************************************************

            // lista para crear influencias
            Nodos.Add(nodo_mag_en_mecanica_computacional);
            Nodos.Add(nodo_magister_en_ciencias_fiscas);
            Nodos.Add(nodo_magister_en_matematica);
            Nodos.Add(nodo_mag_en_lid_dir_y_com_est);
            Nodos.Add(nodo_mag_en_astronomia);
            Nodos.Add(nodo_mag_en_ciencias_mencion_ing_en_alimentos);
            Nodos.Add(nodo_mag_es_std_lat);

            //Escribiendo nodos en archivo
            manejador_de_archivos.ingresarNuevoNodo(nodo_mag_en_mecanica_computacional);
            manejador_de_archivos.ingresarNuevoNodo(nivel_academico_nodo_mag_en_mecanica_computacional);

            manejador_de_archivos.ingresarNuevoNodo(nodo_magister_en_ciencias_fiscas);
            manejador_de_archivos.ingresarNuevoNodo(nivel_academico_magister_en_ciencias_fisicas);


            manejador_de_archivos.ingresarNuevoNodo(nodo_magister_en_matematica);
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