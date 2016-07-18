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

    #region interfaceCalculoNivelesAcademicos
    //***********************************************************************************************
    //************************    InterfaceCalculoNivelesAcademicos
    //***********************************************************************************************
    [Serializable()]
    public class InterfaceCalculoNivelesAcademicos : ICalculosNodo
    {
        string[] salidas_1 = new string[] { "pesimo", "regular", "excelente" };
        string[] salidas_2 = new string[] { "pesimo", "malo", "regular", "bueno", "excelente" };
        string[] salidas_3 = new string[] { "pesimo", "pesimo", "malo", "regular", "bueno", "excelente", "excelente" };
        string[] salidas_4 = new string[] { "pesimo", "pesimo", "malo", "malo", "regular", "bueno", "bueno", "excelente", "excelente" };
        string[] salidas_5 = new string[] { "pesimo", "pesimo", "malo", "malo", "regular", "regular", "regular", "bueno", "bueno", "excelente", "excelente" };
        string[] salidas_6 = new string[] { "pesimo", "pesimo", "pesimo", "malo", "malo", "regular", "regular", "regular", "bueno", "bueno", "excelente", "excelente", "excelente" };

        string[] salidas_actual = null;
        string[] entradas_difusas = new string[] { "calificado", "destacado", "eminente" };
        ArrayList id_profesores = new ArrayList();



        public InterfaceCalculoNivelesAcademicos(string[] profesores)
        {
            for (int i = 0; i < profesores.Length; i++)
            {
                agregarProfesor(profesores[i]);
            }
        }

        public void agregarProfesor(string id_profesor)
        {
            id_profesores.Add(id_profesor);
            switch (id_profesores.Count)
            {
                case 1:
                    salidas_actual = salidas_1;
                    break;
                case 2:
                    salidas_actual = salidas_2;
                    break;
                case 3:
                    salidas_actual = salidas_3;
                    break;
                case 4:
                    salidas_actual = salidas_4;
                    break;
                case 5:
                    salidas_actual = salidas_5;
                    break;
                case 6:

                    salidas_actual = salidas_6;
                    break;
            }
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
            ArrayList combinaciones = crearCombinaciones(id_profesores.Count, new string[] { "0", "1", "2" });
            foreach (string combinacion in combinaciones)
            {
                string[] estado_profesores = combinacion.Split(':');
                int puntaje_estados = 0;
                ExpresionDifusa antecedentes = new ExpresionDifusa(0);
                for (int i = 0; i < estado_profesores.Length; i++)
                {
                    int n_estado = Int32.Parse(estado_profesores[i]);
                    puntaje_estados += n_estado;
                    if (i == 0)
                        antecedentes = fuzzy.Entradas[(string)id_profesores[i]].Es(entradas_difusas[n_estado]);
                    else
                        antecedentes = antecedentes & fuzzy.Entradas[(string)id_profesores[i]].Es(entradas_difusas[n_estado]);
                }
                fuzzy.Si(antecedentes).Entonces(fuzzy.Salidas["estado"], salidas_actual[puntaje_estados]);
            }
            double salida = (double)fuzzy.Salidas["estado"].Defuzzyficar(FuzzyCore.Metodo.MAXIMO_IZQUIERDO);
            return salida;
        }


        public void fuzzificarPeso(double peso, InferenciaDifusa fuzzy)
        {
            fuzzy.Salidas["estado"].Restablecer();
            fuzzy.Salidas["estado"].Fuzzyficar(peso);
        }
    }
    #endregion


}
