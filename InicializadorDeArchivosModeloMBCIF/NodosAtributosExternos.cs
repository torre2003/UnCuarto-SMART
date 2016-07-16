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
    class NodosAtributosExternos
    {
        ManejadorDeDatosArchivos manejador_de_archivos = new ManejadorDeDatosArchivos();
        public Nodo Becas;

        public NodosAtributosExternos()
        {
            #region Nodo Financiamiento y Becas
            //____________________________________________________________________________________________
            //_________________ Nodo Financiamiento y Becas ___________________________________________________
            //____________________________________________________________________________________________
            //TODO Financiamiento y Becas
            Nodo nodo_financiamiento_y_becas;
            nodo_financiamiento_y_becas = new Nodo("n.fyb", "Financiamiento y Becas");
            nodo_financiamiento_y_becas.fuzzy = new InferenciaDifusa(
                //entradas 
                new Dictionary<string, VariableDifusa> {
                     {"conicyt", new VariableDifusa("conicyt", 0, 1,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                              })},
                    {"financiamiento interno", new VariableDifusa("financiamiento interno", 0, 1,	
                                                              new List<FuncionPertenencia>() {
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                                })},
                    {"otros financiamientos", new VariableDifusa("otros financiamientos", 0, 1,
                                                              new List<FuncionPertenencia>(){
                                                                new FuncionHombro("bajo", 0, 0.3, 0.4),
                                                                new FuncionTrapezoidal("medio", 0.3, 0.4, 0.5, 0.6),
                                                                new FuncionSaturacion("alto", 0.5, 0.6, 1)
                                                              })},
                    {"cyted", new VariableDifusa("cyted", 0, 1,
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

            nodo_financiamiento_y_becas.agregarVariable("conicyt", Nodo.DATOS_INTERNOS);
            nodo_financiamiento_y_becas.agregarVariable("financiamiento interno", Nodo.DATOS_INTERNOS);
            nodo_financiamiento_y_becas.agregarVariable("otros financiamientos", Nodo.DATOS_INTERNOS);
            nodo_financiamiento_y_becas.agregarVariable("cyted", Nodo.DATOS_INTERNOS);
            
            //-- influencias DESDE este nodo -----
            nodo_financiamiento_y_becas.agregarVariable("n.deq", Nodo.NODOS_INFLUENCIADOS);
            nodo_financiamiento_y_becas.agregarVariable("n.deidayb", Nodo.NODOS_INFLUENCIADOS);
            nodo_financiamiento_y_becas.agregarVariable("n.debyea", Nodo.NODOS_INFLUENCIADOS);
            nodo_financiamiento_y_becas.agregarVariable("n.memc", Nodo.NODOS_INFLUENCIADOS);
            nodo_financiamiento_y_becas.agregarVariable("n.mecef", Nodo.NODOS_INFLUENCIADOS);
            nodo_financiamiento_y_becas.agregarVariable("n.mem", Nodo.NODOS_INFLUENCIADOS);
            nodo_financiamiento_y_becas.agregarVariable("n.meldyce", Nodo.NODOS_INFLUENCIADOS);
            nodo_financiamiento_y_becas.agregarVariable("n.mea", Nodo.NODOS_INFLUENCIADOS);
            nodo_financiamiento_y_becas.agregarVariable("n.mecmiea", Nodo.NODOS_INFLUENCIADOS);
            nodo_financiamiento_y_becas.agregarVariable("n.meelmelofol", Nodo.NODOS_INFLUENCIADOS);


            //           postitulo_en_algo.agregarVariable("n.pscielo", Nodo.NODOS_INFLUENCIADOS);

            //           postitulo_en_algo.calculos = new ICalculosNodo_postitulo_en_algo();


            //Escribiendo nodos en archivo

            Becas = nodo_financiamiento_y_becas;

            // ingreso de nodos

            manejador_de_archivos.ingresarNuevoNodo(nodo_financiamiento_y_becas);

            Console.WriteLine("Nodos Atributos Externos ingresados");
            #endregion
        }
        

    }
}
