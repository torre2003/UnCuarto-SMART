using FuzzyCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloMBCIF
{
    //-----------------------------------------------------------------------------------------------
    //  Influencia
    //-----------------------------------------------------------------------------------------------

    /// <summary>
    /// Clase para representar la influencia de un nodo origen sobre uno de destino
    /// </summary>
    [Serializable()]
    public class Influencia
    {
        /// <summary>
        /// Constante tipo de influencia
        /// </summary>
        public const int INFLUENCIA_POSITIVA = 1;
        /// <summary>
        /// Constante tipo de influencia
        /// </summary>
        public const int INFLUENCIA_NEGATIVA = -1;
        
        
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        // id influencia
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-

        /// <summary>
        /// Id de la influencia
        /// </summary>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public string id_influencia
        {
            get { return _id_influencia; }
            set { _id_influencia = value; }
        }
        string _id_influencia;

        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        // id nodo origen
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-

        /// <summary>
        /// Id del nodo origende la influencia
        /// </summary>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public string id_nodo_origen
        {
            get { return _id_nodo_origen; }
            set { _id_nodo_origen = value; }
        }
        string _id_nodo_origen;
        
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        // peso nodo
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        
        /// <summary>
        /// Peso del nodo origen de la influencia
        /// </summary>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public double peso_nodo_origen
        {
            get { return _peso_nodo_origen; }
            set { _peso_nodo_origen = value; }
        }
        double _peso_nodo_origen;
        
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        // nodo influenciado
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-

        /// <summary>
        /// Id del nodo a influenciar
        /// </summary>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public string id_nodo_influenciado
        {
            get { return _id_nodo_influenciado; }
            set { _id_nodo_influenciado = value; }
        }
        string _id_nodo_influenciado;

        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        // tipo de influencia 
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-

        /// <summary>
        /// Se completa según constantes si el tipo de influencias es NEGATIVA o POSITIVA
        /// </summary>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public int tipo_de_influencia
        {
            get { return _tipo_de_influencia; }
            set { _tipo_de_influencia = value; }
        }
        int _tipo_de_influencia;


        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        // peso influencia
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-

        /// <summary>
        /// Peso de la influencia en base a la inferencia difusa
        /// </summary>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public double peso_influencia
        {
            get { return _peso_influencia; }
            set { _peso_influencia = value; }
        }
        double _peso_influencia;

        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        // fuzzy
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-

        /// <summary>
        /// Atributo que contiene todo el sistema difuso del nodo
        /// </summary>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public InferenciaDifusa fuzzy
        {
            set { _fuzzy = value; }
            get { return _fuzzy; }
        }
        InferenciaDifusa _fuzzy;

        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        // Calculos
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-

        /// <summary>
        /// Objeto que contiene métodos personalizados para el calculo de peso y peso ajustado del nodo
        /// </summary>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public ICalculosInfluencias calculos
        {
            set { _calculos = value; }
            get { return _calculos; }
        }
        ICalculosInfluencias _calculos;

        //*************************************************************************
        // Constructor
        //*************************************************************************

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id_influencia"></param>
        public Influencia(string id_influencia)
        {
            this.id_influencia = id_influencia;
            this.tipo_de_influencia = Influencia.INFLUENCIA_POSITIVA;
        }

        //*************************************************************************
        // actualizaciónInfluencia
        //*************************************************************************

        /// <summary>
        /// Actualizacion del peso de la influencia en base al peso del nodo
        /// </summary>
        public void actualizacionInfluencia()
        {
            peso_influencia = _calculos.calculoPeso(fuzzy,tipo_de_influencia);
        }

        //*************************************************************************
        // actualizarPesoNodo
        //*************************************************************************

        /// <summary>
        /// Actualizar el valor del peso del nodo origen de la influencia
        /// </summary>
        /// <param name="valor">Valor del peso del nodo origen de la influencia</param>
        /// <returns>valor con el peso de la influencia</returns>
        public void actualizarPesoNodo(double valor)
        {
            peso_nodo_origen = valor;
            fuzzy.Entradas[id_nodo_origen].Fuzzyficar(valor);
        }    

    }

    //-----------------------------------------------------------------------------------------------
    // ICalculosInfluencias
    //-----------------------------------------------------------------------------------------------

    /// <summary>
    /// Interface para implementar los metodos de calculo singulares a cada influencia
    /// </summary>
    public interface ICalculosInfluencias
    {
        /// <summary>
        /// Método para el calculo del peso de la influencia
        /// </summary>
        /// <param name="fuzzy">Sistema de inferencia difusa de la influencia</param>
        /// <param name="tipo_de_influencia">Constante de tipo de influencia, NEGATIVA o POSITIVA</param>
        /// <returns></returns>
        double calculoPeso(InferenciaDifusa fuzzy, int tipo_de_influencia);
    }

}
