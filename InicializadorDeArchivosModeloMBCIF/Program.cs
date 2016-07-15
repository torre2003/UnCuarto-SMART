using AccesoADatos;
//using ContenedorImplementacionesInterfacesCalculoModeloMBCIF;
using FuzzyCore;
using ModeloMBCIF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InicializadorDeArchivosModeloMBCIF
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            ManejadorDeDatosArchivos manejador_de_datos = new ManejadorDeDatosArchivos();
            Console.WriteLine("Repositorio limpiado");
            Console.WriteLine(manejador_de_datos.limpiarDirectorioRepositorioDeDatos());


            Program.generarMina();
            Program.generarProduccion();
            Program.generarSistemaReduccion();
            Program.generarSistemaTransporte();

            Console.ReadKey();
            new NodosFacultadDeCiencias().crearNodosFacultadDeCiencias();
            */
        } // END MAIN



        /*
        public static void generarMina()
        {
            //_____________________________________ 
            //_______________ Sistema mina ________ 
            //_____________________________________ 

            Sistema sistema_mina = new Sistema("s_mina", "Sistema mina");
            sistema_mina.fuzzy = new InferenciaDifusa(
                //entradas 
                new Dictionary<string, VariableDifusa> {
					{"s1", new VariableDifusa("s1", 0, 1,
					                                                     new List<FuncionPertenencia>(){
					                                                     	new FuncionHombro("Poco", 0, 0.1, 0.6),
					                                                     	new FuncionSaturacion("Mucho", 0.40, 0.90, 1)
					                                                     })},
                    {"s2", new VariableDifusa("s2", 0, 1,
					                                                     new List<FuncionPertenencia>(){
					                                                     	new FuncionHombro("Poco", 0, 0.1, 0.6),
					                                                     	new FuncionSaturacion("Mucho", 0.40, 0.90, 1)
					                                                     })},
                    {"s3", new VariableDifusa("s3", 0, 1,
					                                                     new List<FuncionPertenencia>(){
					                                                     	new FuncionHombro("Poco", 0, 0.1, 0.6),
					                                                     	new FuncionSaturacion("Mucho", 0.40, 0.90, 1)
					                                                     })}
                },
                //salidas 
                new Dictionary<string, VariableDifusa> {
					{"Sistema mina", new VariableDifusa("Sistema mina", 0, 1,
					                                                     new List<FuncionPertenencia>(){
					                                                     	new FuncionHombro("Poco", 0, 0.1, 0.6),
					                                                     	new FuncionSaturacion("Mucho", 0.40, 0.90, 1)
					                                                     })}
				}
            );


            sistema_mina.agregarVariable("s1", Sistema.DATOS_SISTEMAS);
            sistema_mina.agregarVariable("s2", Sistema.DATOS_SISTEMAS);
            sistema_mina.agregarVariable("s3", Sistema.DATOS_SISTEMAS);

            sistema_mina.calculos = new ICalculosSistema_mina();

            ManejadorDeDatosArchivos manejador_de_datos = new ManejadorDeDatosArchivos();
            //Guardando datos en archivos 
            Console.WriteLine("Ingresando Sistema Mina");

            //N1Produccion

            manejador_de_datos.ingresarNuevoSistema(sistema_mina);
            Console.WriteLine("Sistema Mina ingresado");

        }
        
        public static void generarProduccion()
        {
            Sistema N1Produccion;

            Nodo n11_Operarios;
            Influencia i_n11_n12;
            Influencia i_n11_n13;
            Influencia i_n11_n31;
            Nodo n12_Perforacion;
            Influencia i_n12_n21;
            Nodo n13_Tronadura;
            Influencia i_n13_n11;
            Influencia i_n13_n22;


            //Sistema
            N1Produccion = new Sistema("s1", "Produccion");
            //Nodos
            n11_Operarios = new Nodo("n11", "Numero de operarios presentes");
            n12_Perforacion = new Nodo("n12", "Perforacion, agentes, recursos");
            n13_Tronadura = new Nodo("n13", "Tronaduras, agentes, recursos");
            //Influencias
            i_n11_n12 = new Influencia("i_n11_n12");
            i_n11_n13 = new Influencia("i_n11_n13");
            i_n11_n31 = new Influencia("i_n11_n31");

            i_n12_n21 = new Influencia("i_n12_n21");

            i_n13_n11 = new Influencia("i_n13_n11");
            i_n13_n22 = new Influencia("i_n13_n22");


            //_____________________________________ 
            //_______________ Sistema s1 __________ 
            //_____________________________________ 

            N1Produccion.fuzzy = new InferenciaDifusa(
                //entradas 
                new Dictionary<string, VariableDifusa> {
					{"n11", new VariableDifusa("n11", 0, 1,
					                                                     new List<FuncionPertenencia>(){
					                                                     	new FuncionHombro("Poco", 0, 0.1, 0.6),
					                                                     	new FuncionSaturacion("Mucho", 0.40, 0.90, 1)
					                                                     })},
                    {"n12", new VariableDifusa("n12", 0, 1,
					                                                     new List<FuncionPertenencia>(){
					                                                     	new FuncionHombro("Poco", 0, 0.1, 0.6),
					                                                     	new FuncionSaturacion("Mucho", 0.40, 0.90, 1)
					                                                     })},
                    {"n13", new VariableDifusa("n13", 0, 1,
					                                                     new List<FuncionPertenencia>(){
					                                                     	new FuncionHombro("Poco", 0, 0.1, 0.6),
					                                                     	new FuncionSaturacion("Mucho", 0.40, 0.90, 1)
					                                                     })}
                },
                //salidas 
                new Dictionary<string, VariableDifusa> {
					{"Produccion", new VariableDifusa("Produccion", 0, 1,
					                                                     new List<FuncionPertenencia>(){
					                                                     	new FuncionHombro("Poco", 0, 0.1, 0.6),
					                                                     	new FuncionSaturacion("Mucho", 0.40, 0.90, 1)
					                                                     })}
				}
            );


            N1Produccion.agregarVariable("n11", Sistema.DATOS_NODOS);
            N1Produccion.agregarVariable("n12", Sistema.DATOS_NODOS);
            N1Produccion.agregarVariable("n13", Sistema.DATOS_NODOS);

            N1Produccion.calculos = new ICalculosSistema_s1();

            //___________________________________________________
            //_________________ Nodo n11 ________________________
            //___________________________________________________

            n11_Operarios.fuzzy = new InferenciaDifusa(
                //entradas 
                new Dictionary<string, VariableDifusa> {
					{"Numero de Ingenieros", new VariableDifusa("Numero de Ingenieros", 0, 100,	
					                                            new List<FuncionPertenencia>() {
					                                            	new FuncionHombro("Poco", 0, 10, 60),
					                                            	new FuncionSaturacion("Mucho", 40, 90, 100)
					                                            })},
					{"Numero de Tecnicos", new VariableDifusa("Numero de Tecnicos", 0, 100,
					                                          new List<FuncionPertenencia>(){
					                                          	new FuncionHombro("Poco", 0, 10, 60),
					                                          	new FuncionSaturacion("Mucho", 40, 90, 100)
					                                          })},
					{"Numero de Mineros", new VariableDifusa("Numero de Mineros", 0, 100,
					                                         new List<FuncionPertenencia>(){
					                                         	new FuncionHombro("Poco", 0, 10, 60),
					                                         	new FuncionSaturacion("Mucho", 40, 90, 100)
					                                         })},
                    {"n21", new VariableDifusa("n21", 0, 1,
					                                         new List<FuncionPertenencia>(){
					                                         	new FuncionHombro("Poco", 0, 0.10, 0.60),
					                                         	new FuncionSaturacion("Mucho", 0.40, 0.90, 1.00)
					                                         })},
                    {"n22", new VariableDifusa("n22", 0, 1,
					                                         new List<FuncionPertenencia>(){
					                                         	new FuncionHombro("Poco", 0, 0.10, 0.60),
					                                         	new FuncionSaturacion("Mucho", 0.40, 0.90, 1.00)
					                                         })},
					{"Numero de Operarios LHD", new VariableDifusa("Numero de Operarios LHD", 0, 100,
					                                               new List<FuncionPertenencia>(){
					                                               	new FuncionHombro("Poco", 0, 10, 60),
			                                                      	new FuncionSaturacion("Mucho", 40, 90, 100)
					                                               })}},
                    
                //salidas 
                new Dictionary<string, VariableDifusa> {
					{"Numero de operarios presentes", new VariableDifusa("Numero de operarios presentes", 0, 1,
					                                                     new List<FuncionPertenencia>(){
					                                                     	new FuncionHombro("Poco", 0, 0.1, 0.6),
					                                                     	new FuncionSaturacion("Mucho", 0.40, 0.90, 1)
					                                                     })}
				}
            );
            n11_Operarios.agregarVariable("Numero de Ingenieros", Nodo.DATOS_INTERNOS);
            n11_Operarios.agregarVariable("Numero de Tecnicos", Nodo.DATOS_INTERNOS);
            n11_Operarios.agregarVariable("Numero de Mineros", Nodo.DATOS_INTERNOS);
            n11_Operarios.agregarVariable("Numero de Operarios LHD", Nodo.DATOS_INTERNOS);
            n11_Operarios.agregarVariable("n21", Nodo.DATOS_NODOS_EXTERNOS);
            n11_Operarios.agregarVariable("n22", Nodo.DATOS_NODOS_EXTERNOS);

            n11_Operarios.agregarVariable("i_n31_n11", Nodo.INFLUENCIAS_EXTERNAS);
            n11_Operarios.agregarVariable("i_n22_n11", Nodo.INFLUENCIAS_EXTERNAS);
            n11_Operarios.agregarVariable("i_n13_n11", Nodo.INFLUENCIAS_EXTERNAS);
            n11_Operarios.agregarVariable("n12", Nodo.NODOS_INFLUENCIADOS);
            n11_Operarios.agregarVariable("n13", Nodo.NODOS_INFLUENCIADOS);
            n11_Operarios.agregarVariable("n31", Nodo.NODOS_INFLUENCIADOS);

            n11_Operarios.calculos = new ICalculosNodo_n11();


            //____________________________________________________________________
            //___________________      i_n11_n12    ______________________________
            //____________________________________________________________________

            i_n11_n12.id_nodo_origen = "n11";
            i_n11_n12.id_nodo_influenciado = "n12";
            i_n11_n12.nombre_nodo_origen = "n11";
            i_n11_n12.nombre_nodo_destino = "n12";
            i_n11_n12.calculos = new ICalculosInfluencia_i_n11_n12();
            i_n11_n12.fuzzy = new InferenciaDifusa(
                //entradas
                new Dictionary<string, VariableDifusa> {
					{"n11", new VariableDifusa("n11", 0, 1,
					                                                  new List<FuncionPertenencia>() {
					                                                  	new FuncionSaturacion("Normal", 0, 0.95, 1.00),
					                                                  })},
					},
                //salidas
                new Dictionary<string, VariableDifusa> {
					{"Influencia", new VariableDifusa("Influencia", 0, 1,
					                                                     new List<FuncionPertenencia>(){
					                                                     	new FuncionSaturacion("Normal", 0, 0.95, 1.00),
					                                                    })}
				}
            );



            //____________________________________________________________________
            //___________________      i_n11_n13    ______________________________
            //____________________________________________________________________

            i_n11_n13.id_nodo_origen = "n11";
            i_n11_n13.id_nodo_influenciado = "n13";
            i_n11_n13.nombre_nodo_origen = "n11";
            i_n11_n13.nombre_nodo_destino = "n13";
            i_n11_n13.calculos = new ICalculosInfluencia_i_n11_n13();
            i_n11_n13.fuzzy = new InferenciaDifusa(
                //entradas
                new Dictionary<string, VariableDifusa> {
					{"n11", new VariableDifusa("n11", 0, 1,
					                                                     new List<FuncionPertenencia>(){
					                                                     	new FuncionSaturacion("Normal", 0, 0.95, 1.00),
					                                                    
					                                                     })}
					},
                //salidas
                new Dictionary<string, VariableDifusa> {
					{"Influencia", new VariableDifusa("Influencia", 0, 1,
					                                                     new List<FuncionPertenencia>(){
					                                                     	new FuncionSaturacion("Normal", 0, 0.95, 1.00),
					                                                    
					                                                     })}
				}
            );

            //____________________________________________________________________
            //___________________      i_n11_n31    ______________________________
            //____________________________________________________________________

            i_n11_n31.id_nodo_origen = "n11";
            i_n11_n31.id_nodo_influenciado = "n31";
            i_n11_n31.nombre_nodo_origen = "n11";
            i_n11_n31.nombre_nodo_destino = "n31";
            i_n11_n31.calculos = new ICalculosInfluencia_i_n11_n31();
            i_n11_n31.fuzzy = new InferenciaDifusa(
                //entradas
                new Dictionary<string, VariableDifusa> {
					{"n11", new VariableDifusa("n11", 0, 1,
					                                                     new List<FuncionPertenencia>(){
					                                                     	new FuncionSaturacion("Normal", 0, 0.95, 1.00),
					                                                    
					                                                     })}
					},
                //salidas
                new Dictionary<string, VariableDifusa> {
					{"Influencia", new VariableDifusa("Influencia", 0, 1,
					                                                     new List<FuncionPertenencia>(){
					                                                     	new FuncionSaturacion("Normal", 0, 0.95, 1.00),
					                                                    
					                                                     })}
				}
            );


            //___________________________________________________
            //_________________ Nodo n12 ________________________
            //___________________________________________________
            n12_Perforacion.fuzzy = new InferenciaDifusa(
                //entradas
                new Dictionary<string, VariableDifusa> {
					{"Perforaciones Planificadas", new VariableDifusa("Perforaciones Planificadas", 0, 100,
					                                                  new List<FuncionPertenencia>() {
					                                                  	new FuncionHombro("Poco", 0, 10, 60),
					                                                  	new FuncionSaturacion("Mucho", 40, 90, 100)
					                                                  })},
					{"Agentes Directos Involucrados", new VariableDifusa("Agentes Directos Involucrados", 0, 100,
					                                          new List<FuncionPertenencia>(){
					                                          	new FuncionHombro("Poco", 0, 10, 60),
					                                          	new FuncionSaturacion("Mucho", 40, 90, 100)
					                                          })},
					{"Agentes Indirectos Involucrados", new VariableDifusa("Agentes Indirectos Involucrados", 0, 100,
					                                         new List<FuncionPertenencia>(){
					                                         	new FuncionHombro("Poco", 0, 10, 60),
					                                         	new FuncionSaturacion("Mucho", 40, 90, 100)
					                                         })}},
                //salidas
                new Dictionary<string, VariableDifusa> {
					{"Perforacion, agentes, recursos", new VariableDifusa("Perforacion, agentes, recursos", 0, 1,
					                                                     new List<FuncionPertenencia>(){
					                                                     	new FuncionHombro("Poco", 0, 0.10, 0.60),
					                                                     	new FuncionSaturacion("Mucho", 0.40, 0.90, 1.00)
					                                                     })}
				}
            );
            n12_Perforacion.agregarVariable("Perforaciones Planificadas", Nodo.DATOS_INTERNOS);
            n12_Perforacion.agregarVariable("Agentes Directos Involucrados", Nodo.DATOS_INTERNOS);
            n12_Perforacion.agregarVariable("Agentes Indirectos Involucrados", Nodo.DATOS_INTERNOS);

            n12_Perforacion.agregarVariable("i_n11_n12", Nodo.INFLUENCIAS_EXTERNAS);
            n12_Perforacion.agregarVariable("i_n21_n12", Nodo.INFLUENCIAS_EXTERNAS);
            n12_Perforacion.agregarVariable("n21", Nodo.NODOS_INFLUENCIADOS);

            n12_Perforacion.calculos = new ICalculosNodo_n12();

            //____________________________________________________________________
            //___________________      i_n12_n21    ______________________________
            //____________________________________________________________________

            i_n12_n21.id_nodo_origen = "n12";
            i_n12_n21.id_nodo_influenciado = "n21";
            i_n12_n21.calculos = new ICalculosInfluencia_i_n12_n21();
            i_n12_n21.fuzzy = new InferenciaDifusa(
                //entradas
                new Dictionary<string, VariableDifusa> {
					{"n12", new VariableDifusa("n12", 0, 1,
					                                                     new List<FuncionPertenencia>(){
					                                                     	new FuncionSaturacion("Normal", 0, 0.95, 1.00),
					                                                    
					                                                     })}
					},
                //salidas
                new Dictionary<string, VariableDifusa> {
					{"Influencia", new VariableDifusa("Influencia", 0, 1,
					                                                     new List<FuncionPertenencia>(){
					                                                     	new FuncionSaturacion("Normal", 0, 0.95, 1.00),
					                                                    
					                                                     })}
				}
            );




            //___________________________________________________
            //_________________ Nodo n13 ________________________
            //___________________________________________________


            n13_Tronadura.fuzzy = new InferenciaDifusa(
                //entradas
                new Dictionary<string, VariableDifusa> {
					{"Tronaduras Planificadas", new VariableDifusa("Tronaduras Planificadas", 0, 100,
					                                                  new List<FuncionPertenencia>() {
					                                                  	new FuncionHombro("Poco", 0, 10, 60),
					                                                  	new FuncionSaturacion("Mucho", 40, 90, 100)
					                                                  })},
					{"Agentes Directos Involucrados", new VariableDifusa("Agentes Directos Involucrados", 0, 100,
					                                          new List<FuncionPertenencia>(){
					                                          	new FuncionHombro("Poco", 0, 10, 60),
					                                          	new FuncionSaturacion("Mucho", 40, 90, 100)
					                                          })},
					{"Agentes Indirectos Involucrados", new VariableDifusa("Agentes Indirectos Involucrados", 0, 100,
					                                         new List<FuncionPertenencia>(){
					                                         	new FuncionHombro("Poco", 0, 10, 60),
					                                         	new FuncionSaturacion("Mucho", 40, 90, 100)
					                                         })}},
                //salidas
                new Dictionary<string, VariableDifusa> {
					{"Tronaduras, agentes, recursos", new VariableDifusa("Tronaduras, agentes, recursos", 0, 1,
					                                                     new List<FuncionPertenencia>(){
					                                                     	new FuncionHombro("Poco", 0, 0.10, 0.60),
					                                                     	new FuncionSaturacion("Mucho", 0.40, 0.90, 1.00)
					                                                     })}
				}
            );
            n13_Tronadura.agregarVariable("Tronaduras Planificadas", Nodo.DATOS_INTERNOS);
            n13_Tronadura.agregarVariable("Agentes Directos Involucrados", Nodo.DATOS_INTERNOS);
            n13_Tronadura.agregarVariable("Agentes Indirectos Involucrados", Nodo.DATOS_INTERNOS);

            n13_Tronadura.agregarVariable("i_n11_n13", Nodo.INFLUENCIAS_EXTERNAS);
            n13_Tronadura.agregarVariable("i_n21_n13", Nodo.INFLUENCIAS_EXTERNAS);
            n13_Tronadura.agregarVariable("n11", Nodo.NODOS_INFLUENCIADOS);
            n13_Tronadura.agregarVariable("n22", Nodo.NODOS_INFLUENCIADOS);

            n13_Tronadura.calculos = new ICalculosNodo_n13();
            //____________________________________________________________________
            //___________________      i_n13_n11    ______________________________
            //____________________________________________________________________

            i_n13_n11.id_nodo_origen = "n13";
            i_n13_n11.id_nodo_influenciado = "n11";
            i_n13_n11.calculos = new ICalculosInfluencia_i_n13_n11();
            i_n13_n11.fuzzy = new InferenciaDifusa(
                //entradas
                new Dictionary<string, VariableDifusa> {
					{"n13", new VariableDifusa("n13", 0, 1,
					                                                     new List<FuncionPertenencia>(){
					                                                     	new FuncionSaturacion("Normal", 0, 0.95, 1.00),
					                                                    
					                                                     })}
					},
                //salidas
                new Dictionary<string, VariableDifusa> {
					{"Influencia", new VariableDifusa("Influencia", 0, 1,
					                                                     new List<FuncionPertenencia>(){
					                                                     	new FuncionSaturacion("Normal", 0, 0.95, 1.00),
					                                                    
					                                                     })}
				}
            );

            //____________________________________________________________________
            //___________________      i_n13_n22    ______________________________
            //____________________________________________________________________

            i_n13_n22.id_nodo_origen = "n13";
            i_n13_n22.id_nodo_influenciado = "n22";
            i_n13_n22.calculos = new ICalculosInfluencia_i_n13_n22();
            i_n13_n22.fuzzy = new InferenciaDifusa(
                //entradas
                new Dictionary<string, VariableDifusa> {
					{"n13", new VariableDifusa("n13", 0, 1,
					                                                     new List<FuncionPertenencia>(){
					                                                     	new FuncionSaturacion("Normal", 0, 0.95, 1.00),
					                                                    
					                                                     })}
					},
                //salidas
                new Dictionary<string, VariableDifusa> {
					{"Influencia", new VariableDifusa("Influencia", 0, 1,
					                                                     new List<FuncionPertenencia>(){
					                                                     	new FuncionSaturacion("Normal", 0, 0.95, 1.00),
					                                                    
					                                                     })}
				}
            );

            ManejadorDeDatosArchivos manejador_de_datos = new ManejadorDeDatosArchivos();
            //Guardando datos en archivos 
            Console.WriteLine("Ingresando Sistema Producción");

            //N1Produccion

            manejador_de_datos.ingresarNuevoSistema(N1Produccion);

            manejador_de_datos.ingresarNuevoNodo(n11_Operarios);

            manejador_de_datos.ingresarNuevaInfluencia(i_n11_n12);

            manejador_de_datos.ingresarNuevaInfluencia(i_n11_n13);

            manejador_de_datos.ingresarNuevaInfluencia(i_n11_n31);

            manejador_de_datos.ingresarNuevoNodo(n12_Perforacion);

            manejador_de_datos.ingresarNuevaInfluencia(i_n12_n21);

            manejador_de_datos.ingresarNuevoNodo(n13_Tronadura);

            manejador_de_datos.ingresarNuevaInfluencia(i_n13_n11);

            manejador_de_datos.ingresarNuevaInfluencia(i_n13_n22);
            Console.WriteLine("Sistema Producción ingresado");

        }// END generar produccion
        //--------------------------------------------------------------------------------------------------------------------------
        public static void generarSistemaReduccion()
        {

            Sistema N2Reduccion;
            Nodo n21_Martillos;
            Influencia i_n21_n12;
            Influencia i_n21_n13;
            Influencia i_n21_n22;
            Nodo n22_Agentes;
            Influencia i_n22_n31;
            Influencia i_n22_n11;

            //Sistema
            N2Reduccion = new Sistema("s2", "Reduccion");
            //Nodos
            n21_Martillos = new Nodo("n21", "Numero de martillos");
            n22_Agentes = new Nodo("n22", "Numero de agentes que intervienen");
            //Influencias
            i_n21_n12 = new Influencia("i_n21_n12");
            i_n21_n13 = new Influencia("i_n21_n13");
            i_n21_n22 = new Influencia("i_n21_n22");

            i_n22_n11 = new Influencia("i_n22_n11");
            i_n22_n31 = new Influencia("i_n22_n31");



            //_____________________________________ 
            //_______________ Sistema s2 __________ 
            //_____________________________________ 

            N2Reduccion.fuzzy = new InferenciaDifusa(
                //entradas 
                new Dictionary<string, VariableDifusa> {
					            {"n21", new VariableDifusa("n21", 0, 1,
					                                                                    new List<FuncionPertenencia>(){
					                                                     	            new FuncionHombro("Poco", 0, 0.1, 0.6),
					                                                     	            new FuncionSaturacion("Mucho", 0.40, 0.90, 1)
					                                                                    })},
                                {"n22", new VariableDifusa("n22", 0, 1,
					                                                                    new List<FuncionPertenencia>(){
					                                                     	            new FuncionHombro("Poco", 0, 0.1, 0.6),
					                                                     	            new FuncionSaturacion("Mucho", 0.40, 0.90, 1)
					                                                                    })},
                            },
                //salidas 
                new Dictionary<string, VariableDifusa> {
					            {"Reduccion", new VariableDifusa("Reduccion", 0, 1,
					                                                                    new List<FuncionPertenencia>(){
					                                                     	            new FuncionHombro("Poco", 0, 0.1, 0.6),
					                                                     	            new FuncionSaturacion("Mucho", 0.40, 0.90, 1)
					                                                                    })}
				            }
            );

            N2Reduccion.agregarVariable("n21", Sistema.DATOS_NODOS);
            N2Reduccion.agregarVariable("n22", Sistema.DATOS_NODOS);

            N2Reduccion.calculos = new ICalculosSistema_s2();

            //___________________________________________________
            //_________________ Nodo n21 ________________________
            //___________________________________________________

            n21_Martillos.fuzzy = new InferenciaDifusa(
                //entradas
                new Dictionary<string, VariableDifusa> {
					{"Control Manual", new VariableDifusa("Control Manual", 0, 100,
					                                                  new List<FuncionPertenencia>() {
					                                                  	new FuncionHombro("Poco", 0, 10, 60),
					                                                  	new FuncionSaturacion("Mucho", 40, 90, 100)
					                                                  })},
					{"Control Remoto", new VariableDifusa("Control Remoto", 0, 100,
					                                          new List<FuncionPertenencia>(){
					                                          	new FuncionHombro("Poco", 0, 10, 60),
					                                          	new FuncionSaturacion("Mucho", 40, 90, 100)
					                                          })},
					{"Robotizados", new VariableDifusa("Robotizados", 0, 100,
					                                         new List<FuncionPertenencia>(){
					                                         	new FuncionHombro("Poco", 0, 10, 60),
					                                         	new FuncionSaturacion("Mucho", 40, 90, 100)
					                                         })}},
                //salidas
                new Dictionary<string, VariableDifusa> {
					{"Numero de martillos", new VariableDifusa("Numero de martillos", 0, 1,
					                                                     new List<FuncionPertenencia>(){
					                                                     	new FuncionHombro("Poco", 0, 0.10, 0.60),
					                                                     	new FuncionSaturacion("Mucho", 0.40, 0.90, 1.00)
					                                                     })}
				}
            );

            n21_Martillos.agregarVariable("Control Manual", Nodo.DATOS_INTERNOS);
            n21_Martillos.agregarVariable("Control Remoto", Nodo.DATOS_INTERNOS);
            n21_Martillos.agregarVariable("Robotizados", Nodo.DATOS_INTERNOS);

            n21_Martillos.agregarVariable("i_n12_n21", Nodo.INFLUENCIAS_EXTERNAS);
            n21_Martillos.agregarVariable("n12", Nodo.NODOS_INFLUENCIADOS);
            n21_Martillos.agregarVariable("n13", Nodo.NODOS_INFLUENCIADOS);
            n21_Martillos.agregarVariable("n22", Nodo.NODOS_INFLUENCIADOS);

            n21_Martillos.calculos = new ICalculosNodo_n21();

            //____________________________________________________________________
            //___________________      i_n21_n12    ______________________________
            //____________________________________________________________________

            i_n21_n12.id_nodo_origen = "n21";
            i_n21_n12.id_nodo_influenciado = "n12";
            i_n21_n12.calculos = new ICalculosInfluencia_i_n21_n12();
            i_n21_n12.fuzzy = new InferenciaDifusa(
                //entradas
                new Dictionary<string, VariableDifusa> {
					{"n21", new VariableDifusa("n21", 0, 1,
					                                                     new List<FuncionPertenencia>(){
					                                                     	new FuncionSaturacion("Normal", 0, 0.95, 1.00),
					                                                    
					                                                     })}
					},
                //salidas
                new Dictionary<string, VariableDifusa> {
					{"Influencia", new VariableDifusa("Influencia", 0, 1,
					                                                     new List<FuncionPertenencia>(){
					                                                     	new FuncionSaturacion("Normal", 0, 0.95, 1.00),
					                                                    
					                                                     })}
				}
            );

            //____________________________________________________________________
            //___________________      i_n21_n13    ______________________________
            //____________________________________________________________________

            i_n21_n13.id_nodo_origen = "n21";
            i_n21_n13.id_nodo_influenciado = "n13";
            i_n21_n13.calculos = new ICalculosInfluencia_i_n21_n13();
            i_n21_n13.fuzzy = new InferenciaDifusa(
                //entradas
                new Dictionary<string, VariableDifusa> {
					{"n21", new VariableDifusa("n21", 0, 1,
					                                                     new List<FuncionPertenencia>(){
					                                                     	new FuncionSaturacion("Normal", 0, 0.95, 1.00),
					                                                    
					                                                     })}
					},
                //salidas
                new Dictionary<string, VariableDifusa> {
					{"Influencia", new VariableDifusa("Influencia", 0, 1,
					                                                     new List<FuncionPertenencia>(){
					                                                     	new FuncionSaturacion("Normal", 0, 0.95, 1.00),
					                                                    
					                                                     })}
				}
            );

            //____________________________________________________________________
            //___________________      i_n21_n22    ______________________________
            //____________________________________________________________________

            i_n21_n22.id_nodo_origen = "n21";
            i_n21_n22.id_nodo_influenciado = "n22";
            i_n21_n22.calculos = new ICalculosInfluencia_i_n21_n22();
            i_n21_n22.fuzzy = new InferenciaDifusa(
                //entradas
                new Dictionary<string, VariableDifusa> {
					{"n21", new VariableDifusa("n21", 0, 1,
					                                                     new List<FuncionPertenencia>(){
					                                                     	new FuncionSaturacion("Normal", 0, 0.95, 1.0),
					                                                    
					                                                     })}
					},
                //salidas
                new Dictionary<string, VariableDifusa> {
					{"Influencia", new VariableDifusa("Influencia", 0, 1,
					                                                     new List<FuncionPertenencia>(){
					                                                     	new FuncionSaturacion("Normal", 0, 0.95, 1.00),
					                                                    
					                                                     })}
				}
            );

            //___________________________________________________
            //_________________ Nodo n22 ________________________
            //___________________________________________________



            n22_Agentes.fuzzy = new InferenciaDifusa(
                //entradas
                new Dictionary<string, VariableDifusa> {
					{"Numero de Ricotus", new VariableDifusa("Numero de Ricotus", 0, 100,
					                                                  new List<FuncionPertenencia>() {
					                                                  	new FuncionHombro("Poco", 0, 10, 60),
					                                                  	new FuncionSaturacion("Mucho", 40, 90, 100)
					                                                  })},
					{"Numero de Cachorreros", new VariableDifusa("Numero de Cachorreros", 0, 100,
					                                          new List<FuncionPertenencia>(){
					                                          	new FuncionHombro("Poco", 0, 10, 60),
					                                          	new FuncionSaturacion("Mucho", 40, 90, 100)
					                                             })}},
                //salidas
                new Dictionary<string, VariableDifusa> {
					{"Numero de agentes que intervienen", new VariableDifusa("Numero de agentes que intervienen", 0, 1,
					                                                     new List<FuncionPertenencia>(){
					                                                     	new FuncionHombro("Poco", 0, 0.10, 0.60),
					                                                     	new FuncionSaturacion("Mucho", 0.40, 0.90, 1.00)
					                                                     })}
				}
            );
            n22_Agentes.agregarVariable("Numero de Ricotus", Nodo.DATOS_INTERNOS);
            n22_Agentes.agregarVariable("Numero de Cachorreros", Nodo.DATOS_INTERNOS);

            n22_Agentes.agregarVariable("i_n13_n22", Nodo.INFLUENCIAS_EXTERNAS);
            n22_Agentes.agregarVariable("i_n21_n22", Nodo.INFLUENCIAS_EXTERNAS);
            n22_Agentes.agregarVariable("i_n31_n22", Nodo.INFLUENCIAS_EXTERNAS);
            n22_Agentes.agregarVariable("n31", Nodo.NODOS_INFLUENCIADOS);
            n22_Agentes.agregarVariable("n11", Nodo.NODOS_INFLUENCIADOS);

            n22_Agentes.calculos = new ICalculosNodo_n22();



            //____________________________________________________________________
            //___________________      i_n22_n11    ______________________________
            //____________________________________________________________________

            i_n22_n11.id_nodo_origen = "n22";
            i_n22_n11.id_nodo_influenciado = "n11";
            i_n22_n11.calculos = new ICalculosInfluencia_i_n22_n11();
            i_n22_n11.fuzzy = new InferenciaDifusa(
                //entradas
                new Dictionary<string, VariableDifusa> {
					{"n22", new VariableDifusa("n22", 0, 1,
					                                                     new List<FuncionPertenencia>(){
					                                                     	new FuncionSaturacion("Normal", 0, 0.95, 1.00),
					                                                    
					                                                     })}
					},
                //salidas
                new Dictionary<string, VariableDifusa> {
					{"Influencia", new VariableDifusa("Influencia", 0, 1,
					                                                     new List<FuncionPertenencia>(){
					                                                     	new FuncionSaturacion("Normal", 0, 0.95, 1.00),
					                                                    
					                                                     })}
				}
            );

            //____________________________________________________________________
            //___________________      i_n22_n31    ______________________________
            //____________________________________________________________________

            i_n22_n31.id_nodo_origen = "n22";
            i_n22_n31.id_nodo_influenciado = "n31";
            i_n22_n31.calculos = new ICalculosInfluencia_i_n22_n31();
            i_n22_n31.fuzzy = new InferenciaDifusa(
                //entradas
                new Dictionary<string, VariableDifusa> {
					{"n22", new VariableDifusa("n22", 0, 1,
					                                                     new List<FuncionPertenencia>(){
					                                                     	new FuncionSaturacion("Normal", 0, 0.95, 1.00),
					                                                    
					                                                     })}
					},
                //salidas
                new Dictionary<string, VariableDifusa> {
					{"Influencia", new VariableDifusa("Influencia", 0, 1,
					                                                     new List<FuncionPertenencia>(){
					                                                     	new FuncionSaturacion("Normal", 0, 0.95, 1.00),
					                                                    
					                                                     })}
				}
            );

            ManejadorDeDatosArchivos manejador_de_datos = new ManejadorDeDatosArchivos();


            //Ingresando a archivo
            Console.WriteLine("Ingresando Sistema Reducción");

            //N2Reduccion);

            manejador_de_datos.ingresarNuevoSistema(N2Reduccion);

            manejador_de_datos.ingresarNuevoNodo(n21_Martillos);

            manejador_de_datos.ingresarNuevaInfluencia(i_n21_n12);

            manejador_de_datos.ingresarNuevaInfluencia(i_n21_n13);

            manejador_de_datos.ingresarNuevaInfluencia(i_n21_n22);

            manejador_de_datos.ingresarNuevoNodo(n22_Agentes);

            manejador_de_datos.ingresarNuevaInfluencia(i_n22_n31);

            manejador_de_datos.ingresarNuevaInfluencia(i_n22_n11);

            Console.WriteLine("Sistema Reducción Ingresado");

        }
        //--------------------------------------------------------------------------------------------------------------------------
        public static void generarSistemaTransporte()
        {

            Sistema N3Transporte;
            Nodo n31_Trenes;
            Influencia i_n31_n11;
            Influencia i_n31_n22;

            //Sistema
            N3Transporte = new Sistema("s3", "Transporte");
            //Nodos
            n31_Trenes = new Nodo("n31", "Numero de Trenes Disponibles");
            //Influencias
            i_n31_n11 = new Influencia("i_n31_n11");
            i_n31_n22 = new Influencia("i_n31_n22");


            //_____________________________________ 
            //_______________ Sistema s3 __________ 
            //_____________________________________ 

            N3Transporte.fuzzy = new InferenciaDifusa(
                //entradas 
               new Dictionary<string, VariableDifusa> {
					            {"n31", new VariableDifusa("n31", 0, 1,
					                                                                    new List<FuncionPertenencia>(){
					                                                     	            new FuncionHombro("Poco", 0, 0.1, 0.6),
					                                                     	            new FuncionSaturacion("Mucho", 0.40, 0.90, 1)
					                                                                    })},
                                 },
                //salidas 
               new Dictionary<string, VariableDifusa> {
					            {"Transporte", new VariableDifusa("Transporte", 0, 1,
					                                                                    new List<FuncionPertenencia>(){
					                                                     	            new FuncionHombro("Poco", 0, 0.1, 0.6),
					                                                     	            new FuncionSaturacion("Mucho", 0.40, 0.90, 1)
					                                                                    })}
				            }
           );

            N3Transporte.agregarVariable("n31", Sistema.DATOS_NODOS);

            N3Transporte.calculos = new ICalculosSistema_s3();
            //___________________________________________________
            //_________________ Nodo n31 ________________________
            //___________________________________________________

            n31_Trenes.fuzzy = new InferenciaDifusa(
                //entradas
                new Dictionary<string, VariableDifusa> {
					{"Operativos", new VariableDifusa("Operativos", 0, 100,
					                                                  new List<FuncionPertenencia>() {
					                                                  	new FuncionHombro("Poco", 0, 10, 60),
					                                                  	new FuncionSaturacion("Mucho", 40, 90, 100)
					                                                  })},
					{"Capacidad de los Trenes", new VariableDifusa("Capacidad de los Trenes", 0, 100,
					                                          new List<FuncionPertenencia>(){
					                                          	new FuncionHombro("Poco", 0, 10, 60),
					                                          	new FuncionSaturacion("Mucho", 40, 90, 100)
					                                             })},
					{"Velocidad de los Trenes", new VariableDifusa("Velocidad de los Trenes", 0, 100,
					                                                  new List<FuncionPertenencia>() {
					                                                  	new FuncionHombro("Poco", 0, 10, 60),
					                                                  	new FuncionSaturacion("Mucho", 40, 90, 100)
					                                                  })},
					{"Productividad de los Trenes", new VariableDifusa("Productividad de los Trenes", 0, 100,
					                                                  new List<FuncionPertenencia>() {
					                                                  	new FuncionHombro("Poco", 0, 10, 60),
					                                                  	new FuncionSaturacion("Mucho", 40, 90, 100)
					                                                  })}},
                //salidas
                new Dictionary<string, VariableDifusa> {
					{"Numero de Trenes Disponibles", new VariableDifusa("Numero de Trenes Disponibles", 0, 1,
					                                                     new List<FuncionPertenencia>(){
					                                                     	new FuncionHombro("Poco", 0, 0.10, 0.60),
					                                                     	new FuncionSaturacion("Mucho", 0.40, 0.90, 1.00)
					                                                     })}
				}
            );
            n31_Trenes.agregarVariable("Operativos", Nodo.DATOS_INTERNOS);
            n31_Trenes.agregarVariable("Capacidad de los Trenes", Nodo.DATOS_INTERNOS);
            n31_Trenes.agregarVariable("Velocidad de los Trenes", Nodo.DATOS_INTERNOS);
            n31_Trenes.agregarVariable("Productividad de los Trenes", Nodo.DATOS_INTERNOS);

            n31_Trenes.agregarVariable("i_n11_n31", Nodo.INFLUENCIAS_EXTERNAS);
            n31_Trenes.agregarVariable("i_n22_n31", Nodo.INFLUENCIAS_EXTERNAS);
            n31_Trenes.agregarVariable("n11", Nodo.NODOS_INFLUENCIADOS);
            n31_Trenes.agregarVariable("n22", Nodo.NODOS_INFLUENCIADOS);

            n31_Trenes.calculos = new ICalculosNodo_n31();
            //____________________________________________________________________
            //___________________      i_n31_n11    ______________________________
            //____________________________________________________________________

            i_n31_n11.id_nodo_origen = "n31";
            i_n31_n11.id_nodo_influenciado = "n11";
            i_n31_n11.calculos = new ICalculosInfluencia_i_n31_n11();
            i_n31_n11.fuzzy = new InferenciaDifusa(
                //entradas
                new Dictionary<string, VariableDifusa> {
					{"n31", new VariableDifusa("n31", 0, 1,
					                                                     new List<FuncionPertenencia>(){
					                                                     	new FuncionSaturacion("Normal", 0, 0.95, 1.00),
					                                                    
					                                                     })}
					},
                //salidas
                new Dictionary<string, VariableDifusa> {
					{"Influencia", new VariableDifusa("Influencia", 0, 1,
					                                                     new List<FuncionPertenencia>(){
					                                                     	new FuncionSaturacion("Normal", 0, 0.95, 1.00),
					                                                    
					                                                     })}
				}
            );

            //____________________________________________________________________
            //___________________      i_n31_n22    ______________________________
            //____________________________________________________________________

            i_n31_n22.id_nodo_origen = "n31";
            i_n31_n22.id_nodo_influenciado = "n22";
            i_n31_n22.calculos = new ICalculosInfluencia_i_n31_n22();
            i_n31_n22.fuzzy = new InferenciaDifusa(
                //entradas
                new Dictionary<string, VariableDifusa> {
					{"n31", new VariableDifusa("n31", 0, 1,
					                                                     new List<FuncionPertenencia>(){
					                                                     	new FuncionSaturacion("Normal", 0, 0.95, 1.00),
					                                                    
					                                                     })}
					},
                //salidas
                new Dictionary<string, VariableDifusa> {
					{"Influencia", new VariableDifusa("Influencia", 0, 1,
					                                                     new List<FuncionPertenencia>(){
					                                                     	new FuncionSaturacion("Normal", 0, 0.95, 1.00),
					                                                    
					                                                     })}
				}
            );

            ManejadorDeDatosArchivos manejador_de_datos = new ManejadorDeDatosArchivos();

            Console.WriteLine("Ingresando Sistema transporte");
            //N3Transporte
            manejador_de_datos.ingresarNuevoNodo(n31_Trenes);
            manejador_de_datos.ingresarNuevaInfluencia(i_n31_n11);
            manejador_de_datos.ingresarNuevaInfluencia(i_n31_n22);

            manejador_de_datos.ingresarNuevoSistema(N3Transporte);
            Console.WriteLine("Sistema transporte ingresado");
        }
        //--------------------------------------------------------------------------------------------------------------------------
        */
    } // End Program
}
