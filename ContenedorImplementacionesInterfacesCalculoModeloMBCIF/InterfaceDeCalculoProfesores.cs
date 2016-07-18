using FuzzyCore;
using ModeloMBCIF;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContenedorImplementacionesInterfacesCalculoModeloMBCIF
{

    #region interfaceCalculoProfesores
    //***********************************************************************************************
    //************************    InterfaceCalculoProfesores
    //***********************************************************************************************
    [Serializable()]
    public class InterfaceCalculoProfesores : ICalculosNodo
    {
        string[] salidas_actual = new string[] { "pesimo", "malo", "regular", "bueno", "excelente" };
        string[] entradas_difusas = new string[] { "sin publicaciones", "bajo", "medio", "alto" };
        //double[] limite_derecho_rango = new double[] {1,3,4,6,8};
        double[] limite_derecho_rango = new double[] { 1, 2, 3, 5, 8};//<--- Cambiar

        double[] limite_derecho_rango_combinacion_intermedio = new double[] { 1, 2, 3, 5, 8 };//<--- Cambiar

        ArrayList caracteristicas = new ArrayList();



        public InterfaceCalculoProfesores()
        {
            caracteristicas.Add("publicaciones isi-wos");
            caracteristicas.Add("publicaciones scielo");
            caracteristicas.Add("publicaciones equivalentes");
            //caracteristicas.Add("impacto");
        }


        public ArrayList crearCombinaciones(int longitud, string[] posibilidades)
        {
            if (longitud == 1)
            {
                ArrayList array = new ArrayList();
                for (int i = 0; i < posibilidades.Length; i++)
                    array.Add(posibilidades[i]);
                return array;
            }
            else
            {
                ArrayList retorno = new ArrayList();
                for (int i = 0; i < posibilidades.Length; i++)
                {
                    ArrayList aux = crearCombinaciones(longitud - 1, posibilidades);
                    foreach (string item in aux)
                    {
                        retorno.Add(posibilidades[i] + ":" + item);
                    }
                }
                return retorno;
            }
        }


        public double calculoPeso(double peso_bruto_nodo, System.Collections.ArrayList influencias)
        {
            double suma_de_influencias = 0;
            foreach (var item in influencias)
            {
                Dato aux = (Dato)item;
                suma_de_influencias += aux.valor;
            }

            double peso = (double)peso_bruto_nodo + suma_de_influencias;

            if (peso < 0)
                peso = 0;
            if (peso > 1)
                peso = 1;

            return peso;
        }

        public double calculoPesoBruto(InferenciaDifusa fuzzy)
        {
            string[] salidas_intermedia = new string[] { "sin publicaciones", "bajo", "medio", "alto" };
            
            InferenciaDifusa fuzzy_publicaciones = new InferenciaDifusa();
            fuzzy_publicaciones.AgregarEntrada(fuzzy.Entradas["publicaciones isi-wos"]);
            fuzzy_publicaciones.AgregarEntrada(fuzzy.Entradas["publicaciones scielo"]);
            fuzzy_publicaciones.AgregarEntrada(fuzzy.Entradas["publicaciones equivalentes"]);

            fuzzy_publicaciones.AgregarSalida(new VariableDifusa("publicaciones", 0, 6,
                                new List<FuncionPertenencia>() {
									new FuncionHombro("sin publicaciones", 0, 0.1, 0.11),
                                    new FuncionTrapezoidal("bajo", 0.11, 0.12, 2, 3),
									new FuncionTrapezoidal("medio", 2, 3, 4, 5),
									new FuncionSaturacion("alto", 4, 5, 6)
								}));



           
            ArrayList combinaciones = crearCombinaciones(caracteristicas.Count, new string[] { "0", "1", "2","3" });
            foreach (string combinacion in combinaciones)
            {
                string[] combinacion_estado = combinacion.Split(':');
                int puntaje_estados = 0;
                ExpresionDifusa antecedentes = new ExpresionDifusa(0);
                for (int i = 0; i < combinacion_estado.Length; i++)
                {
                    int n_estado = Int32.Parse(combinacion_estado[i]);
                    puntaje_estados += n_estado;
                    if (i == 0)
                        antecedentes = fuzzy.Entradas[(string)caracteristicas[i]].Es(entradas_difusas[n_estado]);
                    else
                        antecedentes = antecedentes & fuzzy.Entradas[(string)caracteristicas[i]].Es(entradas_difusas[n_estado]);
                }

                ///------------------
                fuzzy_publicaciones.Si(antecedentes).Entonces(fuzzy_publicaciones.Salidas["publicaciones"], salidas_intermedia[indice_salida(new double[] { 0, 3, 6, 9 }, puntaje_estados)]);
                
                //arreglar

                ///------------------------------
            
            }




            var publicaciones = fuzzy_publicaciones.Salidas["publicaciones"];
            double valor_publicaciones = (double)publicaciones.Defuzzyficar(FuzzyCore.Metodo.MAXIMO_DERECHO);
            valor_publicaciones += (double)publicaciones.Defuzzyficar(FuzzyCore.Metodo.MAXIMO_IZQUIERDO);
            valor_publicaciones /= 2;
            publicaciones.Restablecer();
            publicaciones.Fuzzyficar(valor_publicaciones);

            InferenciaDifusa fuzzy_combinacion = new InferenciaDifusa();
            fuzzy_combinacion.AgregarEntrada(publicaciones);
            fuzzy_combinacion.AgregarEntrada(fuzzy.Entradas["impacto"]);
            fuzzy_combinacion.AgregarSalida(fuzzy.Salidas["estado"]);



            VariableDifusa var_publicaciones = fuzzy_combinacion.Entradas["publicaciones"];
            VariableDifusa var_impacto = fuzzy_combinacion.Entradas["impacto"];
            VariableDifusa var_estado = fuzzy_combinacion.Salidas["estado"];


            fuzzy.Si(var_publicaciones.Es("sin publicaciones") & var_impacto.Es("bajo")).Entonces(var_estado, "pesimo");
            fuzzy.Si(var_publicaciones.Es("sin publicaciones") & var_impacto.Es("medio")).Entonces(var_estado, "pesimo");
            fuzzy.Si(var_publicaciones.Es("sin publicaciones") & var_impacto.Es("alto")).Entonces(var_estado, "pesimo");
            fuzzy.Si(var_publicaciones.Es("bajo") & var_impacto.Es("bajo")).Entonces(var_estado, "malo");
            fuzzy.Si(var_publicaciones.Es("bajo") & var_impacto.Es("medio")).Entonces(var_estado, "regular");
            fuzzy.Si(var_publicaciones.Es("bajo") & var_impacto.Es("alto")).Entonces(var_estado, "bueno");
            
            fuzzy.Si(var_publicaciones.Es("medio") & var_impacto.Es("bajo")).Entonces(var_estado, "regular");
            fuzzy.Si(var_publicaciones.Es("medio") & var_impacto.Es("medio")).Entonces(var_estado, "regular");
            fuzzy.Si(var_publicaciones.Es("medio") & var_impacto.Es("alto")).Entonces(var_estado, "excelente");

            fuzzy.Si(var_publicaciones.Es("alto") & var_impacto.Es("bajo")).Entonces(var_estado, "regular");
            fuzzy.Si(var_publicaciones.Es("alto") & var_impacto.Es("medio")).Entonces(var_estado, "bueno");
            fuzzy.Si(var_publicaciones.Es("alto") & var_impacto.Es("alto")).Entonces(var_estado, "excelente");								




            //evaluar reglas----

            double salida = (double)fuzzy_combinacion.Salidas["estado"].Defuzzyficar(FuzzyCore.Metodo.MAXIMO_DERECHO);
            salida += (double)fuzzy_combinacion.Salidas["estado"].Defuzzyficar(FuzzyCore.Metodo.MAXIMO_IZQUIERDO);
            salida /= 2;

            return salida;
        }


        public int indice_salida(int puntaje_estados)
        {
            for (int i = 0; i < limite_derecho_rango.Length; i++)
            {
                if (puntaje_estados <= limite_derecho_rango[i])
                    return i;
            }
            return -666;
        }

        public int indice_salida(double[] opciones , int puntaje_estados)
        {
            for (int i = 0; i < opciones.Length; i++)
            {
                if (puntaje_estados <= opciones[i])
                    return i;
            }
            return -666;
        }


        public void fuzzificarPeso(double peso, InferenciaDifusa fuzzy)
        {
            fuzzy.Salidas["estado"].Restablecer();
            fuzzy.Salidas["estado"].Fuzzyficar(peso);
        }
    }
    #endregion

}
