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

            nodo_investigacion = new Nodo("ni", "Investigacion");
            nodo_investigacion.fuzzy = new InferenciaDifusa(
                //entradas 
                new Dictionary<string, VariableDifusa> {
                     {"npi", new VariableDifusa("npi", 0, 1,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("bajo", 0, 0.2, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.2, 0.4, 0.6, 0.8),
                                                                new FuncionSaturacion("alto", 0.6, 0.8, 1)
                                                              })},
                    {"npisi", new VariableDifusa("npisi", 0, 1,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("bajo", 0, 0.2, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.2, 0.4, 0.6, 0.8),
                                                                new FuncionSaturacion("alto", 0.6, 0.8, 1)
                                                                })},
                    {"npscielo", new VariableDifusa("npscielo", 0, 1,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("bajo", 0, 0.2, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.2, 0.4, 0.6, 0.8),
                                                                new FuncionSaturacion("alto", 0.6, 0.8, 1)
                                                              })},
                    {"npe", new VariableDifusa("npe", 0, 1,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("bajo", 0, 0.2, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.2, 0.4, 0.6, 0.8),
                                                                new FuncionSaturacion("alto", 0.6, 0.8, 1)
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

            nodo_investigacion.agregarVariable("npi", Nodo.DATOS_NODOS_EXTERNOS);
            nodo_investigacion.agregarVariable("npisi", Nodo.DATOS_NODOS_EXTERNOS);
            nodo_investigacion.agregarVariable("npscielo", Nodo.DATOS_NODOS_EXTERNOS);
            nodo_investigacion.agregarVariable("npe", Nodo.DATOS_NODOS_EXTERNOS);

            //-- influencias DESDE este nodo -----
            nodo_investigacion.agregarVariable("ndeq", Nodo.NODOS_INFLUENCIADOS);
            nodo_investigacion.agregarVariable("ndeidayb", Nodo.NODOS_INFLUENCIADOS);
            nodo_investigacion.agregarVariable("ndebyea", Nodo.NODOS_INFLUENCIADOS);
            nodo_investigacion.agregarVariable("nmemc", Nodo.NODOS_INFLUENCIADOS);
            nodo_investigacion.agregarVariable("nmecef", Nodo.NODOS_INFLUENCIADOS);
            nodo_investigacion.agregarVariable("nmem", Nodo.NODOS_INFLUENCIADOS);
            nodo_investigacion.agregarVariable("nmeldyce", Nodo.NODOS_INFLUENCIADOS);
            nodo_investigacion.agregarVariable("nmea", Nodo.NODOS_INFLUENCIADOS);
            nodo_investigacion.agregarVariable("nmecmiea", Nodo.NODOS_INFLUENCIADOS);
            nodo_investigacion.agregarVariable("nmeelmelofol", Nodo.NODOS_INFLUENCIADOS);            
            nodo_investigacion.agregarVariable("np", Nodo.NODOS_INFLUENCIADOS);


			//-- influencias HACIA este nodo -----
			nodo_investigacion.agregarVariable("i_np_ni", Nodo.INFLUENCIAS_EXTERNAS);


            nodo_investigacion.calculos = new InterfaceCalculosGenerica(new string[] { "npi", "npisi", "npscielo", "npe"});


            //Escribiendo nodos en archivo

            #endregion
            #region Nodo Personal Investigacion
            //____________________________________________________________________________________________
            //_________________ Nodo Personal Investigacion  ___________________________________________________
            //____________________________________________________________________________________________
            //TODO Personal Investigacion
            Nodo nodo_personal_investigacion;
            nodo_personal_investigacion = new Nodo("npi", "Personal Investigacion");
            nodo_personal_investigacion.fuzzy = new InferenciaDifusa(
                //entradas 
                new Dictionary<string, VariableDifusa> {
                   {"ndi", new VariableDifusa("ndi", 0, 1,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("bajo", 0, 0.2, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.2, 0.4, 0.6, 0.8),
                                                                new FuncionSaturacion("alto", 0.6, 0.8, 1)
                                                                })}, 
                    {"nsi", new VariableDifusa("nsi", 0, 1,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("bajo", 0, 0.2, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.2, 0.4, 0.6, 0.8),
                                                                new FuncionSaturacion("alto", 0.6, 0.8, 1)
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

            nodo_personal_investigacion.agregarVariable("ndi", Nodo.DATOS_NODOS_EXTERNOS);
            nodo_personal_investigacion.agregarVariable("nsi", Nodo.DATOS_NODOS_EXTERNOS);

            //		   postitulo_en_algo.agregarVariable("i_n.i_n.pea", Nodo.INFLUENCIAS_EXTERNAS);

            //           postitulo_en_algo.agregarVariable("n.pisi", Nodo.NODOS_INFLUENCIADOS);

            //           postitulo_en_algo.agregarVariable("n.pscielo", Nodo.NODOS_INFLUENCIADOS);

            nodo_personal_investigacion.calculos = new InterfaceCalculosPersonas(new string[] { "ndi", "nsi" });
            #endregion

            #region Nodo Secretaria Investigacion
            //____________________________________________________________________________________________
            //_________________ Nodo Secretaria Investigacion  ___________________________________________________
            //____________________________________________________________________________________________
            //TODO Secretaria Investigacion
            Nodo nodo_secretaria_investigacion;

            nodo_secretaria_investigacion = new Nodo("nsi", "Secretaria Investigacion");
            nodo_secretaria_investigacion.fuzzy = new InferenciaDifusa(
                //entradas 
                new Dictionary<string, VariableDifusa> {
                   {"compromiso", new VariableDifusa("compromiso", 0, 10,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("bajo", 0, 2, 4),
                                                                new FuncionTrapezoidal("medio", 2, 4, 6, 8),
                                                                new FuncionSaturacion("alto", 6, 8, 10)
                                                                })},
                    {"empatia", new VariableDifusa("empatia",  0, 10,	
                                                              new List<FuncionPertenencia>() {
                                                               new FuncionHombro("bajo", 0, 2, 4),
                                                                new FuncionTrapezoidal("medio", 2, 4, 6, 8),
                                                                new FuncionSaturacion("alto", 6, 8, 10)
                                                                })}, 
                    {"manejo verbal", new VariableDifusa("manejo verbal",  0, 10,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("bajo", 0, 2, 4),
                                                                new FuncionTrapezoidal("medio", 2, 4, 6, 8),
                                                                new FuncionSaturacion("alto", 6, 8, 10)
                                                                })}, 
                    {"flexibilidad", new VariableDifusa("flexibilidad",  0, 10,	
                                                              new List<FuncionPertenencia>() {
                                                              new FuncionHombro("bajo", 0, 2, 4),
                                                                new FuncionTrapezoidal("medio", 2, 4, 6, 8),
                                                                new FuncionSaturacion("alto", 6, 8, 10)
                                                                })}, 
                    {"trabajo bajo presion", new VariableDifusa("trabajo bajo presion",  0, 10,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("bajo", 0, 2, 4),
                                                                new FuncionTrapezoidal("medio", 2, 4, 6, 8),
                                                                new FuncionSaturacion("alto", 6, 8, 10)
                                                                })}, 
                    {"sistematibilidad", new VariableDifusa("sistematibilidad",  0, 10,	
                                                              new List<FuncionPertenencia>() {
                                                               new FuncionHombro("bajo", 0, 2, 4),
                                                                new FuncionTrapezoidal("medio", 2, 4, 6, 8),
                                                                new FuncionSaturacion("alto", 6, 8, 10)
                                                                })}, 
                    {"manejo de tics", new VariableDifusa("manejo de tics",  0, 10,	
                                                              new List<FuncionPertenencia>() {
                                                               new FuncionHombro("bajo", 0, 2, 4),
                                                                new FuncionTrapezoidal("medio", 2, 4, 6, 8),
                                                                new FuncionSaturacion("alto", 6, 8, 10)
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
			nodo_secretaria_investigacion.agregarVariable("nsp", Nodo.NODOS_INFLUENCIADOS);
            nodo_secretaria_investigacion.agregarVariable("ndi", Nodo.NODOS_INFLUENCIADOS);

			//-- influencias HACIA este nodo -----
			nodo_secretaria_investigacion.agregarVariable("i_nsp_nsi", Nodo.INFLUENCIAS_EXTERNAS);
            nodo_secretaria_investigacion.agregarVariable("i_ndi_nsi", Nodo.INFLUENCIAS_EXTERNAS);

 

            nodo_secretaria_investigacion.calculos = new InterfaceCalculosPersonas(new string[] { "compromiso", "empatia", "manejo verbal", "flexibilidad", "trabajo bajo presion", "sistematibilidad", "manejo de tics" });

            #endregion

            #region Nodo Director Investigacion
            //____________________________________________________________________________________________
            //_________________ Nodo Director Investigacion  ___________________________________________________
            //____________________________________________________________________________________________
            //TODO Director Investigacion
            Nodo nodo_director_investigacion;
            nodo_director_investigacion = new Nodo("ndi", "Director Investigacion");
            nodo_director_investigacion.fuzzy = new InferenciaDifusa(
                //entradas 
                new Dictionary<string, VariableDifusa> {
                   {"formacion", new VariableDifusa("formacion", 0, 10,	
                                                              new List<FuncionPertenencia>() {
                                                               new FuncionHombro("bajo", 0, 2, 4),
                                                                new FuncionTrapezoidal("medio", 2, 4, 6, 8),
                                                                new FuncionSaturacion("alto", 6, 8, 10)
                                                                })},
                    {"empatia", new VariableDifusa("empatia",  0, 10,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("bajo", 0, 2, 4),
                                                                new FuncionTrapezoidal("medio", 2, 4, 6, 8),
                                                                new FuncionSaturacion("alto", 6, 8, 10)
                                                                })}, 
                    {"poder de resolucion", new VariableDifusa("poder de resolucion",  0, 10,	
                                                              new List<FuncionPertenencia>() {
                                                               new FuncionHombro("bajo", 0, 2, 4),
                                                                new FuncionTrapezoidal("medio", 2, 4, 6, 8),
                                                                new FuncionSaturacion("alto", 6, 8, 10)
                                                                })}, 
                    {"compromiso", new VariableDifusa("compromiso",  0, 10,	
                                                              new List<FuncionPertenencia>() {
                                                               new FuncionHombro("bajo", 0, 2, 4),
                                                                new FuncionTrapezoidal("medio", 2, 4, 6, 8),
                                                                new FuncionSaturacion("alto", 6, 8, 10)
                                                                })}, 
                    {"gestion externa", new VariableDifusa("gestion externa",  0, 10,	
                                                              new List<FuncionPertenencia>() {
                                                               new FuncionHombro("bajo", 0, 2, 4),
                                                                new FuncionTrapezoidal("medio", 2, 4, 6, 8),
                                                                new FuncionSaturacion("alto", 6, 8, 10)
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
            nodo_director_investigacion.agregarVariable("ndp", Nodo.NODOS_INFLUENCIADOS);
            nodo_director_investigacion.agregarVariable("nsi", Nodo.NODOS_INFLUENCIADOS);

			//-- influencias HACIA este nodo -----
            nodo_director_investigacion.agregarVariable("i_ndp_ndi", Nodo.INFLUENCIAS_EXTERNAS);
            nodo_director_investigacion.agregarVariable("i_nsi_ndi", Nodo.INFLUENCIAS_EXTERNAS);

            nodo_director_investigacion.calculos = new InterfaceCalculosPersonas(new string[] { "formacion", "empatia", "poder de resolucion", "compromiso", "gestion externa" });
            #endregion
            #region Nodo Publicaciones ISI
            //____________________________________________________________________________________________
            //_________________ Nodo Publicaciones ISI  ___________________________________________________
            //____________________________________________________________________________________________
            //TODO Nodo Publicaciones ISI 
            Nodo nodo_publicaciones_isi;
            nodo_publicaciones_isi = new Nodo("npisi", "Publicaciones ISI");
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
			nodo_publicaciones_isi.agregarVariable("i_ndeq_npisi", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_isi.agregarVariable("i_ndeidayb_npisi", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_isi.agregarVariable("i_ndebyea_npisi", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_isi.agregarVariable("i_nmemc_npisi", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_isi.agregarVariable("i_nmecef_npisi", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_isi.agregarVariable("i_nmem_npisi", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_isi.agregarVariable("i_nmeldyce_npisi", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_isi.agregarVariable("i_nmea_npisi", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_isi.agregarVariable("i_nmecmiea_npisi", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_isi.agregarVariable("i_nmeelmelofol_npisi", Nodo.INFLUENCIAS_EXTERNAS);


			nodo_publicaciones_isi.agregarVariable("i_nagsg_npisi", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_isi.agregarVariable("i_nafs_npisi", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_isi.agregarVariable("i_napv_npisi", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_isi.agregarVariable("i_namc_npisi", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_isi.agregarVariable("i_naja_npisi", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_isi.agregarVariable("i_naif_npisi", Nodo.INFLUENCIAS_EXTERNAS);			
			nodo_publicaciones_isi.agregarVariable("i_nalr_npisi", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_isi.agregarVariable("i_naah_npisi", Nodo.INFLUENCIAS_EXTERNAS);			
			nodo_publicaciones_isi.agregarVariable("i_nacnp_npisi", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_isi.agregarVariable("i_nasldm_npisi", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_isi.agregarVariable("i_namea_npisi", Nodo.INFLUENCIAS_EXTERNAS);			
			nodo_publicaciones_isi.agregarVariable("i_namgs_npisi", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_isi.agregarVariable("i_nanm_npisi", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_isi.agregarVariable("i_nahp_npisi", Nodo.INFLUENCIAS_EXTERNAS);


            nodo_publicaciones_isi.calculos = new ICalculosPublicaciones();
            #endregion


            #region Nodo Publicaciones SciELO
            //____________________________________________________________________________________________
            //_________________ Nodo Publicaciones SciELO  ___________________________________________________
            //____________________________________________________________________________________________
            //TODO Nodo Publicaciones SciELO 
            Nodo nodo_publicaciones_scielo;
            nodo_publicaciones_scielo = new Nodo("npscielo", "Publicaciones SciELO");
            nodo_publicaciones_scielo.fuzzy = new InferenciaDifusa(
                //entradas 
                new Dictionary<string, VariableDifusa> {
                   {"tasa de publicaciones anuales", new VariableDifusa("tasa de publicaciones anuales", 0, 60,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("bajo", 0, 10, 20),
                                                                new FuncionTrapezoidal("medio", 10, 20, 30, 40),
                                                                new FuncionSaturacion("alto", 30, 40, 60)
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

            nodo_publicaciones_scielo.agregarVariable("tasa de publicaciones anuales", Nodo.DATOS_INTERNOS);
            nodo_publicaciones_scielo.agregarVariable("promedio de impacto publicaciones", Nodo.DATOS_INTERNOS);



			//-- influencias HACIA este nodo -----
			nodo_publicaciones_scielo.agregarVariable("i_ndeq_npscielo", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_scielo.agregarVariable("i_ndeidayb_npscielo", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_scielo.agregarVariable("i_ndebyea_npscielo", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_scielo.agregarVariable("i_nmemc_npscielo", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_scielo.agregarVariable("i_nmecef_npscielo", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_scielo.agregarVariable("i_nmem_npscielo", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_scielo.agregarVariable("i_nmeldyce_npscielo", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_scielo.agregarVariable("i_nmea_npscielo", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_scielo.agregarVariable("i_nmecmiea_npscielo", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_scielo.agregarVariable("i_nmeelmelofol_npscielo", Nodo.INFLUENCIAS_EXTERNAS);


			nodo_publicaciones_scielo.agregarVariable("i_nagsg_npscielo", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_scielo.agregarVariable("i_nafs_npscielo", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_scielo.agregarVariable("i_napv_npscielo", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_scielo.agregarVariable("i_namc_npscielo", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_scielo.agregarVariable("i_naja_npscielo", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_scielo.agregarVariable("i_naif_npscielo", Nodo.INFLUENCIAS_EXTERNAS);			
			nodo_publicaciones_scielo.agregarVariable("i_nalr_npscielo", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_scielo.agregarVariable("i_naah_npscielo", Nodo.INFLUENCIAS_EXTERNAS);			
			nodo_publicaciones_scielo.agregarVariable("i_nacnp_npscielo", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_scielo.agregarVariable("i_nasldm_npscielo", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_scielo.agregarVariable("i_namea_npscielo", Nodo.INFLUENCIAS_EXTERNAS);			
			nodo_publicaciones_scielo.agregarVariable("i_namgs_npscielo", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_scielo.agregarVariable("i_nanm_npscielo", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_scielo.agregarVariable("i_nahp_npscielo", Nodo.INFLUENCIAS_EXTERNAS);


            nodo_publicaciones_scielo.calculos = new ICalculosPublicaciones();
            #endregion
            #region Nodo Publicaciones equivalentes
            //____________________________________________________________________________________________
            //_________________ Nodo Publicaciones equivalentes  ___________________________________________________
            //____________________________________________________________________________________________
            //TODO Nodo Publicaciones equivalentes 
            Nodo nodo_publicaciones_equivalentes;
            nodo_publicaciones_equivalentes = new Nodo("npe", "Publicaciones Equivalentes");
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
			nodo_publicaciones_equivalentes.agregarVariable("i_ndeq_npe", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_equivalentes.agregarVariable("i_ndeidayb_npe", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_equivalentes.agregarVariable("i_ndebyea_npe", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_equivalentes.agregarVariable("i_nmemc_npe", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_equivalentes.agregarVariable("i_nmecef_npe", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_equivalentes.agregarVariable("i_nmem_npe", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_equivalentes.agregarVariable("i_nmeldyce_npe", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_equivalentes.agregarVariable("i_nmea_npe", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_equivalentes.agregarVariable("i_nmecmiea_npe", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_equivalentes.agregarVariable("i_nmeelmelofol_npe", Nodo.INFLUENCIAS_EXTERNAS);


			nodo_publicaciones_equivalentes.agregarVariable("i_nagsg_npe", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_equivalentes.agregarVariable("i_nafs_npe", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_equivalentes.agregarVariable("i_napv_npe", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_equivalentes.agregarVariable("i_namc_npe", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_equivalentes.agregarVariable("i_naja_npe", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_equivalentes.agregarVariable("i_naif_npe", Nodo.INFLUENCIAS_EXTERNAS);			
			nodo_publicaciones_equivalentes.agregarVariable("i_nalr_npe", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_equivalentes.agregarVariable("i_naah_npe", Nodo.INFLUENCIAS_EXTERNAS);			
			nodo_publicaciones_equivalentes.agregarVariable("i_nacnp_npe", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_equivalentes.agregarVariable("i_nasldm_npe", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_equivalentes.agregarVariable("i_namea_npe", Nodo.INFLUENCIAS_EXTERNAS);			
			nodo_publicaciones_equivalentes.agregarVariable("i_namgs_npe", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_equivalentes.agregarVariable("i_nanm_npe", Nodo.INFLUENCIAS_EXTERNAS);
			nodo_publicaciones_equivalentes.agregarVariable("i_nahp_npe", Nodo.INFLUENCIAS_EXTERNAS);


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