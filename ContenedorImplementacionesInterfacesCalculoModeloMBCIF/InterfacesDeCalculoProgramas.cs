using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModeloMBCIF;
using FuzzyCore;
using System.Collections;

namespace ContenedorImplementacionesInterfacesCalculoModeloMBCIF
{

    #region ICalculosNodo_programas
    //***********************************************************************************************
    //************************    ICalculosNodo_programas
    //***********************************************************************************************
    [Serializable()]
    public class ICalculosNodo_programas : ICalculosNodo
    {

        string id_nivel_academico = "";
        public ICalculosNodo_programas(string id_nivel_academico)
        {
            this.id_nivel_academico = id_nivel_academico;
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
            VariableDifusa m_alumnos = fuzzy.Entradas["matricula alumnos"];
            VariableDifusa acreditacion = fuzzy.Entradas["acreditacion"];
            VariableDifusa nivel_academico = fuzzy.Entradas[id_nivel_academico];
            VariableDifusa estado = fuzzy.Salidas["estado"];

            fuzzy.Si(m_alumnos.Es("poco") & acreditacion.Es("sin_acreditacion") & nivel_academico.Es("normal")).Entonces(estado, "pesimo");
            fuzzy.Si(m_alumnos.Es("poco") & acreditacion.Es("sin_acreditacion") & nivel_academico.Es("alto")).Entonces(estado, "pesimo");
            fuzzy.Si(m_alumnos.Es("poco") & acreditacion.Es("sin_acreditacion") & nivel_academico.Es("muy_alto")).Entonces(estado, "regular");
            fuzzy.Si(m_alumnos.Es("poco") & acreditacion.Es("periodo_corto") & nivel_academico.Es("normal")).Entonces(estado, "malo");
            fuzzy.Si(m_alumnos.Es("poco") & acreditacion.Es("periodo_corto") & nivel_academico.Es("alto")).Entonces(estado, "malo");
            fuzzy.Si(m_alumnos.Es("poco") & acreditacion.Es("periodo_corto") & nivel_academico.Es("muy_alto")).Entonces(estado, "regular");
            fuzzy.Si(m_alumnos.Es("poco") & acreditacion.Es("periodo_medio") & nivel_academico.Es("normal")).Entonces(estado, "regular");
            fuzzy.Si(m_alumnos.Es("poco") & acreditacion.Es("periodo_medio") & nivel_academico.Es("alto")).Entonces(estado, "bueno");
            fuzzy.Si(m_alumnos.Es("poco") & acreditacion.Es("periodo_medio") & nivel_academico.Es("muy_alto")).Entonces(estado, "bueno");
            fuzzy.Si(m_alumnos.Es("poco") & acreditacion.Es("periodo_prolongado") & nivel_academico.Es("normal")).Entonces(estado, "regular");
            fuzzy.Si(m_alumnos.Es("poco") & acreditacion.Es("periodo_prolongado") & nivel_academico.Es("alto")).Entonces(estado, "bueno");
            fuzzy.Si(m_alumnos.Es("poco") & acreditacion.Es("periodo_prolongado") & nivel_academico.Es("muy_alto")).Entonces(estado, "bueno");
            fuzzy.Si(m_alumnos.Es("optimo") & acreditacion.Es("sin_acreditacion") & nivel_academico.Es("normal")).Entonces(estado, "regular");
            fuzzy.Si(m_alumnos.Es("optimo") & acreditacion.Es("sin_acreditacion") & nivel_academico.Es("alto")).Entonces(estado, "regular");
            fuzzy.Si(m_alumnos.Es("optimo") & acreditacion.Es("sin_acreditacion") & nivel_academico.Es("muy_alto")).Entonces(estado, "bueno");
            fuzzy.Si(m_alumnos.Es("optimo") & acreditacion.Es("periodo_corto") & nivel_academico.Es("normal")).Entonces(estado, "regular");
            fuzzy.Si(m_alumnos.Es("optimo") & acreditacion.Es("periodo_corto") & nivel_academico.Es("alto")).Entonces(estado, "bueno");
            fuzzy.Si(m_alumnos.Es("optimo") & acreditacion.Es("periodo_corto") & nivel_academico.Es("muy_alto")).Entonces(estado, "excelente");
            fuzzy.Si(m_alumnos.Es("optimo") & acreditacion.Es("periodo_medio") & nivel_academico.Es("normal")).Entonces(estado, "regular");
            fuzzy.Si(m_alumnos.Es("optimo") & acreditacion.Es("periodo_medio") & nivel_academico.Es("alto")).Entonces(estado, "regular");
            fuzzy.Si(m_alumnos.Es("optimo") & acreditacion.Es("periodo_medio") & nivel_academico.Es("muy_alto")).Entonces(estado, "excelente");
            fuzzy.Si(m_alumnos.Es("optimo") & acreditacion.Es("periodo_prolongado") & nivel_academico.Es("normal")).Entonces(estado, "bueno");
            fuzzy.Si(m_alumnos.Es("optimo") & acreditacion.Es("periodo_prolongado") & nivel_academico.Es("alto")).Entonces(estado, "excelente");
            fuzzy.Si(m_alumnos.Es("optimo") & acreditacion.Es("periodo_prolongado") & nivel_academico.Es("muy_alto")).Entonces(estado, "excelente");
            fuzzy.Si(m_alumnos.Es("excedido") & acreditacion.Es("sin_acreditacion") & nivel_academico.Es("normal")).Entonces(estado, "malo");
            fuzzy.Si(m_alumnos.Es("excedido") & acreditacion.Es("sin_acreditacion") & nivel_academico.Es("alto")).Entonces(estado, "regular");
            fuzzy.Si(m_alumnos.Es("excedido") & acreditacion.Es("sin_acreditacion") & nivel_academico.Es("muy_alto")).Entonces(estado, "regular");
            fuzzy.Si(m_alumnos.Es("excedido") & acreditacion.Es("periodo_corto") & nivel_academico.Es("normal")).Entonces(estado, "pesimo");
            fuzzy.Si(m_alumnos.Es("excedido") & acreditacion.Es("periodo_corto") & nivel_academico.Es("alto")).Entonces(estado, "malo");
            fuzzy.Si(m_alumnos.Es("excedido") & acreditacion.Es("periodo_corto") & nivel_academico.Es("muy_alto")).Entonces(estado, "regular");
            fuzzy.Si(m_alumnos.Es("excedido") & acreditacion.Es("periodo_medio") & nivel_academico.Es("normal")).Entonces(estado, "pesimo");
            fuzzy.Si(m_alumnos.Es("excedido") & acreditacion.Es("periodo_medio") & nivel_academico.Es("alto")).Entonces(estado, "regular");
            fuzzy.Si(m_alumnos.Es("excedido") & acreditacion.Es("periodo_medio") & nivel_academico.Es("muy_alto")).Entonces(estado, "regular");
            fuzzy.Si(m_alumnos.Es("excedido") & acreditacion.Es("periodo_prolongado") & nivel_academico.Es("normal")).Entonces(estado, "regular");
            fuzzy.Si(m_alumnos.Es("excedido") & acreditacion.Es("periodo_prolongado") & nivel_academico.Es("alto")).Entonces(estado, "bueno");
            fuzzy.Si(m_alumnos.Es("excedido") & acreditacion.Es("periodo_prolongado") & nivel_academico.Es("muy_alto")).Entonces(estado, "bueno");
            
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
