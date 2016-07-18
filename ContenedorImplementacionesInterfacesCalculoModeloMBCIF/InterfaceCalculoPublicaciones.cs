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

    #region ICalculosPublicaciones
    //***********************************************************************************************
    //************************    ICalculosPublicaciones
    //***********************************************************************************************
    [Serializable()]
    public class ICalculosPublicaciones : ICalculosNodo
    {

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

            VariableDifusa p_impacto = fuzzy.Entradas["promedio de impacto publicaciones"];
            VariableDifusa t_publicaciones = fuzzy.Entradas["tasa de publicaciones anuales"];

            VariableDifusa estado = fuzzy.Salidas["estado"];


            fuzzy.Si(p_impacto.Es("bajo") & t_publicaciones.Es("limitado")).Entonces(estado, "pesimo");
            fuzzy.Si(p_impacto.Es("bajo") & t_publicaciones.Es("bajo")).Entonces(estado, "malo");
            fuzzy.Si(p_impacto.Es("bajo") & t_publicaciones.Es("medio")).Entonces(estado, "regular");
            fuzzy.Si(p_impacto.Es("bajo") & t_publicaciones.Es("alto")).Entonces(estado, "regular");
            fuzzy.Si(p_impacto.Es("medio") & t_publicaciones.Es("limitado")).Entonces(estado, "malo");
            fuzzy.Si(p_impacto.Es("medio") & t_publicaciones.Es("bajo")).Entonces(estado, "regular");
            fuzzy.Si(p_impacto.Es("medio") & t_publicaciones.Es("medio")).Entonces(estado, "regular");
            fuzzy.Si(p_impacto.Es("medio") & t_publicaciones.Es("alto")).Entonces(estado, "bueno");
            fuzzy.Si(p_impacto.Es("alto") & t_publicaciones.Es("limitado")).Entonces(estado, "regular");
            fuzzy.Si(p_impacto.Es("alto") & t_publicaciones.Es("bajo")).Entonces(estado, "regular");
            fuzzy.Si(p_impacto.Es("alto") & t_publicaciones.Es("medio")).Entonces(estado, "bueno");
            fuzzy.Si(p_impacto.Es("alto") & t_publicaciones.Es("alto")).Entonces(estado, "excelente");



            double salida = (double)estado.Defuzzyficar(FuzzyCore.Metodo.MAXIMO_IZQUIERDO);
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
