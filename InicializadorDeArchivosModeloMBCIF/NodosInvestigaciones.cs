using AccesoADatos;
using ModeloMBCIF;
using FuzzyCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContenedorImplementacionesInterfacesCalculoModeloMBCIF;

namespace InicializadorDeArchivosModeloMBCIF
{
    class NodosInvestigaciones
    {
        ManejadorDeDatosArchivos manejador_de_archivos = new ManejadorDeDatosArchivos();
		public Nodo Investigacion;
		public Nodo Director;
		public Nodo Secretaria;
		public List<Nodo> Publicaciones = new List<Nodo>();


        public NodosInvestigaciones()
        {
            #region Nodo Investigacion
            //____________________________________________________________________________________________
            //_________________ Nodo Investigacion ___________________________________________________
            //____________________________________________________________________________________________
            //TODO Investigacion
            Nodo nodo_investigacion;

            nodo_investigacion = new Nodo("n.i", "Investigacion");
            nodo_investigacion.fuzzy = new InferenciaDifusa(
                //entradas 
                new Dictionary<string, VariableDifusa> {
                     {"n.pi", new VariableDifusa("n.pi", 0, 1,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                              })},
                    {"n.pisi", new VariableDifusa("n.pisi", 0, 1,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                                })},
                    {"n.pscielo", new VariableDifusa("n.pscielo", 0, 1,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                              })},
                    {"n.pe", new VariableDifusa("n.pe", 0, 1,
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

            nodo_investigacion.agregarVariable("n.pi", Nodo.DATOS_NODOS_EXTERNOS);
            nodo_investigacion.agregarVariable("n.pisi", Nodo.DATOS_NODOS_EXTERNOS);
            nodo_investigacion.agregarVariable("n.pscielo", Nodo.DATOS_NODOS_EXTERNOS);
            nodo_investigacion.agregarVariable("n.pe", Nodo.DATOS_NODOS_EXTERNOS);

            //-- influencias DESDE este nodo -----
            nodo_investigacion.agregarVariable("n.deq", Nodo.NODOS_INFLUENCIADOS);
            nodo_investigacion.agregarVariable("n.deidayb", Nodo.NODOS_INFLUENCIADOS);
            nodo_investigacion.agregarVariable("n.debyea", Nodo.NODOS_INFLUENCIADOS);
            nodo_investigacion.agregarVariable("n.memc", Nodo.NODOS_INFLUENCIADOS);
            nodo_investigacion.agregarVariable("n.mecef", Nodo.NODOS_INFLUENCIADOS);
            nodo_investigacion.agregarVariable("n.mem", Nodo.NODOS_INFLUENCIADOS);
            nodo_investigacion.agregarVariable("n.meldyce", Nodo.NODOS_INFLUENCIADOS);
            nodo_investigacion.agregarVariable("n.mea", Nodo.NODOS_INFLUENCIADOS);
            nodo_investigacion.agregarVariable("n.mecmiea", Nodo.NODOS_INFLUENCIADOS);
            nodo_investigacion.agregarVariable("n.meelmelofol", Nodo.NODOS_INFLUENCIADOS);            
            nodo_investigacion.agregarVariable("n.p", Nodo.NODOS_INFLUENCIADOS);


			//-- influencias HACIA este nodo -----
			nodo_investigacion.agregarVariable("i_n.p_n.i", Nodo.INFLUENCIAS_EXTERNAS);


            nodo_investigacion.calculos = new InterfaceCalculosGenerica(new string[] { "n.pi", "n.pisi", "n.pscielo", "n.pe"});


            //Escribiendo nodos en archivo

            #endregion
            #region Nodo Personal Investigacion
            //____________________________________________________________________________________________
            //_________________ Nodo Personal Investigacion  ___________________________________________________
            //____________________________________________________________________________________________
            //TODO Personal Investigacion
            Nodo nodo_personal_investigacion;
            nodo_personal_investigacion = new Nodo("n.pi", "Personal Investigacion");
            nodo_personal_investigacion.fuzzy = new InferenciaDifusa(
                //entradas 
                new Dictionary<string, VariableDifusa> {
                   {"n.di", new VariableDifusa("n.di", 0, 1,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                                })}, 
                    {"n.si", new VariableDifusa("n.si", 0, 1,
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

            nodo_personal_investigacion.agregarVariable("n.di", Nodo.DATOS_NODOS_EXTERNOS);
            nodo_personal_investigacion.agregarVariable("n.si", Nodo.DATOS_NODOS_EXTERNOS);

            //		   postitulo_en_algo.agregarVariable("i_n.i_n.pea", Nodo.INFLUENCIAS_EXTERNAS);

            //           postitulo_en_algo.agregarVariable("n.pisi", Nodo.NODOS_INFLUENCIADOS);

            //           postitulo_en_algo.agregarVariable("n.pscielo", Nodo.NODOS_INFLUENCIADOS);

            nodo_personal_investigacion.calculos = new InterfaceCalculosPersonas(new string[] { "n.di", "n.si" });
            #endregion

            #region Nodo Secretaria Investigacion
            //____________________________________________________________________________________________
            //_________________ Nodo Secretaria Investigacion  ___________________________________________________
            //____________________________________________________________________________________________
            //TODO Secretaria Investigacion
            Nodo nodo_secretaria_investigacion;

            nodo_secretaria_investigacion = new Nodo("n.si", "Secretaria Investigacion");
            nodo_secretaria_investigacion.fuzzy = new InferenciaDifusa(
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

            nodo_secretaria_investigacion.agregarVariable("compromiso", Nodo.DATOS_INTERNOS);
            nodo_secretaria_investigacion.agregarVariable("empatia", Nodo.DATOS_INTERNOS);
            nodo_secretaria_investigacion.agregarVariable("manejo verbal", Nodo.DATOS_INTERNOS);
            nodo_secretaria_investigacion.agregarVariable("flexibilidad", Nodo.DATOS_INTERNOS);
            nodo_secretaria_investigacion.agregarVariable("trabajo bajo presion", Nodo.DATOS_INTERNOS);
            nodo_secretaria_investigacion.agregarVariable("sistematibilidad", Nodo.DATOS_INTERNOS);
            nodo_secretaria_investigacion.agregarVariable("manejo de tics", Nodo.DATOS_INTERNOS);


			//-- influencias DESDE este nodo -----
			nodo_secretaria_investigacion.agregarVariable("n.sp", Nodo.NODOS_INFLUENCIADOS);


			//-- influencias HACIA este nodo -----
			nodo_secretaria_investigacion.agregarVariable("i_n.sp_n.si", Nodo.INFLUENCIAS_EXTERNAS);


 

            nodo_secretaria_investigacion.calculos = new InterfaceCalculosPersonas(new string[] { "compromiso", "empatia", "manejo verbal", "flexibilidad", "trabajo bajo presion", "sistematibilidad", "manejo de tics" });

            #endregion

            #region Nodo Director Investigacion
            //____________________________________________________________________________________________
            //_________________ Nodo Director Investigacion  ___________________________________________________
            //____________________________________________________________________________________________
            //TODO Director Investigacion
            Nodo nodo_director_investigacion;
            nodo_director_investigacion = new Nodo("n.di", "Director Investigacion");
            nodo_director_investigacion.fuzzy = new InferenciaDifusa(
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

            nodo_director_investigacion.agregarVariable("formacion", Nodo.DATOS_INTERNOS);
            nodo_director_investigacion.agregarVariable("empatia", Nodo.DATOS_INTERNOS);
            nodo_director_investigacion.agregarVariable("poder de resolucion", Nodo.DATOS_INTERNOS);
            nodo_director_investigacion.agregarVariable("compromiso", Nodo.DATOS_INTERNOS);
            nodo_director_investigacion.agregarVariable("gestion externa", Nodo.DATOS_INTERNOS);


			//-- influencias DESDE este nodo -----
            nodo_director_investigacion.agregarVariable("n.dp", Nodo.NODOS_INFLUENCIADOS);


			//-- influencias HACIA este nodo -----
            nodo_director_investigacion.agregarVariable("i_n.dp_n.di", Nodo.INFLUENCIAS_EXTERNAS);

            nodo_director_investigacion.calculos = new InterfaceCalculosPersonas(new string[] { "formacion", "empatia", "poder de resolucion", "compromiso", "gestion externa" });
            #endregion
            #region Nodo Publicaciones ISI
            //____________________________________________________________________________________________
            //_________________ Nodo Publicaciones ISI  ___________________________________________________
            //____________________________________________________________________________________________
            //TODO Nodo Publicaciones ISI 
            Nodo nodo_publicaciones_isi;
            nodo_publicaciones_isi = new Nodo("n.pisi", "Publicaciones ISI");
            nodo_publicaciones_isi.fuzzy = new InferenciaDifusa(
                //entradas 
                new Dictionary<string, VariableDifusa> {
                   {"tasa de publicaciones anuales", new VariableDifusa("tasa de publicaciones anuales", 0, 120,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("limitado", 0, 40, 70),
                                                                new FuncionTrapezoidal("bajo", 40, 70, 80, 90),
                                                                new FuncionTrapezoidal("medio", 80, 90, 100, 110),
                                                                new FuncionSaturacion("alto", 100, 110, 120)
                                                                })},
                    {"promedio de impacto publicaciones", new VariableDifusa("promedio de impacto publicaciones",  0, 1,	
                                                              	new List<FuncionPertenencia>() {
									                                new FuncionHombro("bajo", 0, 0.1, 0.3),
									                                new FuncionTrapezoidal("medio", 0.1,0.3,0.4,0.6),
									                                new FuncionSaturacion("alto", 0.4, 0.6, 1)
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

            nodo_publicaciones_isi.agregarVariable("tasa de publicaciones anuales", Nodo.DATOS_INTERNOS);
            nodo_publicaciones_isi.agregarVariable("promedio de impacto publicaciones", Nodo.DATOS_INTERNOS);
            
			//-- influencias HACIA este nodo -----
			nodo_publicaciones_isi.agregarVariable("i_n.deq_n.pisi", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_isi.agregarVariable("i_n.deidayb_n.pisi", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_isi.agregarVariable("i_n.debyea_n.pisi", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_isi.agregarVariable("i_n.memc_n.pisi", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_isi.agregarVariable("i_n.mecef_n.pisi", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_isi.agregarVariable("i_n.mem_n.pisi", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_isi.agregarVariable("i_n.meldyce_n.pisi", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_isi.agregarVariable("i_n.mea_n.pisi", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_isi.agregarVariable("i_n.mecmiea_n.pisi", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_isi.agregarVariable("i_n.meelmelofol_n.pisi", Nodo.INFLUENCIAS_EXTERNAS);


			nodo_publicaciones_isi.agregarVariable("i_n.agsg_n.pisi", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_isi.agregarVariable("i_n.afs_n.pisi", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_isi.agregarVariable("i_n.apv_n.pisi", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_isi.agregarVariable("i_n.amc_n.pisi", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_isi.agregarVariable("i_n.aja_n.pisi", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_isi.agregarVariable("i_n.aif_n.pisi", Nodo.INFLUENCIAS_EXTERNAS);			
			nodo_publicaciones_isi.agregarVariable("i_n.alr_n.pisi", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_isi.agregarVariable("i_n.aah_n.pisi", Nodo.INFLUENCIAS_EXTERNAS);			
			nodo_publicaciones_isi.agregarVariable("i_n.acnp_n.pisi", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_isi.agregarVariable("i_n.asldm_n.pisi", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_isi.agregarVariable("i_n.amea_n.pisi", Nodo.INFLUENCIAS_EXTERNAS);			
			nodo_publicaciones_isi.agregarVariable("i_n.amgs_n.pisi", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_isi.agregarVariable("i_n.anm_n.pisi", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_isi.agregarVariable("i_n.ahp_n.pisi", Nodo.INFLUENCIAS_EXTERNAS);


            nodo_publicaciones_isi.calculos = new ICalculosPublicaciones();
            #endregion


            #region Nodo Publicaciones SciELO
            //____________________________________________________________________________________________
            //_________________ Nodo Publicaciones SciELO  ___________________________________________________
            //____________________________________________________________________________________________
            //TODO Nodo Publicaciones SciELO 
            Nodo nodo_publicaciones_scielo;
            nodo_publicaciones_scielo = new Nodo("n.pscielo", "Publicaciones SciELO");
            nodo_publicaciones_scielo.fuzzy = new InferenciaDifusa(
                //entradas 
                new Dictionary<string, VariableDifusa> {
                   {"tasa de publicaciones anuales", new VariableDifusa("tasa de publicaciones anuales", 0, 60,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("bajo", 0, 10, 20),
                                                                new FuncionTrapezoidal("medio", 10, 20, 30, 40),
                                                                new FuncionSaturacion("alto", 30, 40, 60)
                                                                })},
                    {"promedio de impacto publicaciones", new VariableDifusa("promedio de impacto publicaciones",  0, 10,	
                                                              new List<FuncionPertenencia>() {
									                                new FuncionHombro("bajo", 0, 0.1, 0.3),
									                                new FuncionTrapezoidal("medio", 0.1,0.3,0.4,0.6),
									                                new FuncionSaturacion("alto", 0.4, 0.6, 1)
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

            nodo_publicaciones_scielo.agregarVariable("tasa de publicaciones anuales", Nodo.DATOS_INTERNOS);
            nodo_publicaciones_scielo.agregarVariable("promedio de impacto publicaciones", Nodo.DATOS_INTERNOS);



			//-- influencias HACIA este nodo -----
			nodo_publicaciones_scielo.agregarVariable("i_n.deq_n.pscielo", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_scielo.agregarVariable("i_n.deidayb_n.pscielo", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_scielo.agregarVariable("i_n.debyea_n.pscielo", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_scielo.agregarVariable("i_n.memc_n.pscielo", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_scielo.agregarVariable("i_n.mecef_n.pscielo", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_scielo.agregarVariable("i_n.mem_n.pscielo", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_scielo.agregarVariable("i_n.meldyce_n.pscielo", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_scielo.agregarVariable("i_n.mea_n.pscielo", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_scielo.agregarVariable("i_n.mecmiea_n.pscielo", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_scielo.agregarVariable("i_n.meelmelofol_n.pscielo", Nodo.INFLUENCIAS_EXTERNAS);


			nodo_publicaciones_scielo.agregarVariable("i_n.agsg_n.pscielo", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_scielo.agregarVariable("i_n.afs_n.pscielo", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_scielo.agregarVariable("i_n.apv_n.pscielo", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_scielo.agregarVariable("i_n.amc_n.pscielo", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_scielo.agregarVariable("i_n.aja_n.pscielo", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_scielo.agregarVariable("i_n.aif_n.pscielo", Nodo.INFLUENCIAS_EXTERNAS);			
			nodo_publicaciones_scielo.agregarVariable("i_n.alr_n.pscielo", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_scielo.agregarVariable("i_n.aah_n.pscielo", Nodo.INFLUENCIAS_EXTERNAS);			
			nodo_publicaciones_scielo.agregarVariable("i_n.acnp_n.pscielo", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_scielo.agregarVariable("i_n.asldm_n.pscielo", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_scielo.agregarVariable("i_n.amea_n.pscielo", Nodo.INFLUENCIAS_EXTERNAS);			
			nodo_publicaciones_scielo.agregarVariable("i_n.amgs_n.pscielo", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_scielo.agregarVariable("i_n.anm_n.pscielo", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_scielo.agregarVariable("i_n.ahp_n.pscielo", Nodo.INFLUENCIAS_EXTERNAS);


            nodo_publicaciones_scielo.calculos = new ICalculosPublicaciones();
            #endregion
            #region Nodo Publicaciones equivalentes
            //____________________________________________________________________________________________
            //_________________ Nodo Publicaciones equivalentes  ___________________________________________________
            //____________________________________________________________________________________________
            //TODO Nodo Publicaciones equivalentes 
            Nodo nodo_publicaciones_equivalentes;
            nodo_publicaciones_equivalentes = new Nodo("n.pe", "Publicaciones equivalentes");
            nodo_publicaciones_equivalentes.fuzzy = new InferenciaDifusa(
                //entradas 
                new Dictionary<string, VariableDifusa> {
                   {"tasa de publicaciones anuales", new VariableDifusa("tasa de publicaciones anuales", 0, 120,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("limitado", 0, 40, 70),
                                                                new FuncionTrapezoidal("bajo", 40, 70, 80, 90),
                                                                new FuncionTrapezoidal("medio", 80, 90, 100, 110),
                                                                new FuncionSaturacion("alto", 100, 110, 120)
                                                                })},
                    {"promedio de impacto publicaciones", new VariableDifusa("promedio de impacto publicaciones",  0, 1,	
                                                              	new List<FuncionPertenencia>() {
									                                new FuncionHombro("bajo", 0, 0.1, 0.3),
									                                new FuncionTrapezoidal("medio", 0.1,0.3,0.4,0.6),
									                                new FuncionSaturacion("alto", 0.4, 0.6, 1)
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

            nodo_publicaciones_equivalentes.agregarVariable("tasa de publicaciones anuales", Nodo.DATOS_INTERNOS);
            nodo_publicaciones_equivalentes.agregarVariable("promedio de impacto publicaciones", Nodo.DATOS_INTERNOS);

			//-- influencias HACIA este nodo -----
			nodo_publicaciones_equivalentes.agregarVariable("i_n.deq_n.pe", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_equivalentes.agregarVariable("i_n.deidayb_n.pe", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_equivalentes.agregarVariable("i_n.debyea_n.pe", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_equivalentes.agregarVariable("i_n.memc_n.pe", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_equivalentes.agregarVariable("i_n.mecef_n.pe", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_equivalentes.agregarVariable("i_n.mem_n.pe", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_equivalentes.agregarVariable("i_n.meldyce_n.pe", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_equivalentes.agregarVariable("i_n.mea_n.pe", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_equivalentes.agregarVariable("i_n.mecmiea_n.pe", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_equivalentes.agregarVariable("i_n.meelmelofol_n.pe", Nodo.INFLUENCIAS_EXTERNAS);


			nodo_publicaciones_equivalentes.agregarVariable("i_n.agsg_n.pe", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_equivalentes.agregarVariable("i_n.afs_n.pe", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_equivalentes.agregarVariable("i_n.apv_n.pe", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_equivalentes.agregarVariable("i_n.amc_n.pe", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_equivalentes.agregarVariable("i_n.aja_n.pe", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_equivalentes.agregarVariable("i_n.aif_n.pe", Nodo.INFLUENCIAS_EXTERNAS);			
			nodo_publicaciones_equivalentes.agregarVariable("i_n.alr_n.pe", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_equivalentes.agregarVariable("i_n.aah_n.pe", Nodo.INFLUENCIAS_EXTERNAS);			
			nodo_publicaciones_equivalentes.agregarVariable("i_n.acnp_n.pe", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_equivalentes.agregarVariable("i_n.asldm_n.pe", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_equivalentes.agregarVariable("i_n.amea_n.pe", Nodo.INFLUENCIAS_EXTERNAS);			
			nodo_publicaciones_equivalentes.agregarVariable("i_n.amgs_n.pe", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_equivalentes.agregarVariable("i_n.anm_n.pe", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_equivalentes.agregarVariable("i_n.ahp_n.pe", Nodo.INFLUENCIAS_EXTERNAS);


            nodo_publicaciones_equivalentes.calculos = new ICalculosPublicaciones();

            #endregion



            Investigacion =  nodo_investigacion ;

            Secretaria = nodo_secretaria_investigacion ;
            Director = nodo_director_investigacion ;

            Publicaciones.Add(nodo_publicaciones_isi);
            Publicaciones.Add(nodo_publicaciones_scielo);
            Publicaciones.Add(nodo_publicaciones_equivalentes);


            // ingreso de nodos

            manejador_de_archivos.ingresarNuevoNodo(nodo_investigacion);
            manejador_de_archivos.ingresarNuevoNodo(nodo_personal_investigacion);
            manejador_de_archivos.ingresarNuevoNodo(nodo_secretaria_investigacion);
            manejador_de_archivos.ingresarNuevoNodo(nodo_director_investigacion);
            manejador_de_archivos.ingresarNuevoNodo(nodo_publicaciones_isi);
            manejador_de_archivos.ingresarNuevoNodo(nodo_publicaciones_scielo);
            manejador_de_archivos.ingresarNuevoNodo(nodo_publicaciones_equivalentes);






            Console.WriteLine("Nodos Investigacion ingresados");
        }




    }
}