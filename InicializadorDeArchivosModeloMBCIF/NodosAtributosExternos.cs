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

        public void crearNodosAtributosExternos()
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

            //			 postitulo_en_algo.agregarVariable("i_n.i_n.pea", Nodo.INFLUENCIAS_EXTERNAS);

            //           postitulo_en_algo.agregarVariable("n.pisi", Nodo.NODOS_INFLUENCIADOS);

            //           postitulo_en_algo.agregarVariable("n.pscielo", Nodo.NODOS_INFLUENCIADOS);

            //           postitulo_en_algo.calculos = new ICalculosNodo_postitulo_en_algo();


            //Escribiendo nodos en archivo



            // ingreso de nodos

            manejador_de_archivos.ingresarNuevoNodo(nodo_financiamiento_y_becas);

            Console.WriteLine("Nodos Atributos Externos ingresados");
            #endregion
        }
        

    }
}
