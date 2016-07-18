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

    #region InterfaceCalculosSeccionesPostgrado
    //***********************************************************************************************
    //************************    InterfaceCalculosSeccionesPostgrado
    //***********************************************************************************************
    [Serializable()]
    public class InterfaceCalculosSeccionesPostgrado : ICalculosNodo
    {
        string[] salidas_actual = new string[] { "pesimo", "malo", "regular", "bueno", "excelente" };
        string[] entradas_difusas = new string[] { "bajo", "medio", "alto" };
        double[] limite_derecho_rango = new double[] { 1, 3, 4, 6, 8 };
        ArrayList programas = new ArrayList();



        public InterfaceCalculosSeccionesPostgrado(string[] programas)
        {
            for (int i = 0; i < programas.Length; i++)
            {
                this.programas.Add(programas[i]);
            }
            limite_derecho_rango = creaVectorLimiteDerechoRango(programas.Length);
        }


        public double[] creaVectorLimiteDerechoRango(int cantidad_de_programas)
        {
            double[] arreglo_retorno = new double[] { 1, 1, 1, 1, 1 };
            if (cantidad_de_programas == 1)
            {
                arreglo_retorno = new double[] { 0, 666, 1, 666, 2 };
                return arreglo_retorno;
            }
            if (cantidad_de_programas == 2)
                return new double[] { 0, 1, 2, 3, 4 };
            int numeros_restantes_por_repartir = (3 * cantidad_de_programas) - cantidad_de_programas;
            numeros_restantes_por_repartir -= 5;
            int[] orden_de_aumento = new int[] { 0, 4, 1, 3, 2, 2 };
            int pos_actual = 0;
            for (int i = numeros_restantes_por_repartir; i >= 0; i--)
            {
                if (pos_actual >= orden_de_aumento.Length)
                    pos_actual = 0;
                arreglo_retorno[orden_de_aumento[pos_actual]]++;
                pos_actual++;
            }

            double acumulado = 0;
            for (int i = 0; i < arreglo_retorno.Length; i++)
            {
                acumulado += arreglo_retorno[i];
                arreglo_retorno[i] = acumulado - 1;
            }
            return arreglo_retorno;
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
            ArrayList combinaciones = crearCombinaciones(programas.Count, new string[] { "0", "1", "2" });
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
                        antecedentes = fuzzy.Entradas[(string)programas[i]].Es(entradas_difusas[n_estado]);
                    else
                        antecedentes = antecedentes & fuzzy.Entradas[(string)programas[i]].Es(entradas_difusas[n_estado]);
                }

                fuzzy.Si(antecedentes).Entonces(fuzzy.Salidas["estado"], salidas_actual[indice_salida(puntaje_estados)]);
            }
            double salida = (double)fuzzy.Salidas["estado"].Defuzzyficar(FuzzyCore.Metodo.MAXIMO_IZQUIERDO);
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



        public void fuzzificarPeso(double peso, InferenciaDifusa fuzzy)
        {
            fuzzy.Salidas["estado"].Restablecer();
            fuzzy.Salidas["estado"].Fuzzyficar(peso);
        }
    }
    #endregion


}
