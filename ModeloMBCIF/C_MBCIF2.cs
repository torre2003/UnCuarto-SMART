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
        // valor ajuste influencia
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-

        /// <summary>
        /// Valor de ajuste de la influencia que va de 0 a 2, siendo 1 el valor por defecto y significando un 100% de la influencia
        /// </summary>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public double valor_ajuste_influencia
        {
            get { return _valor_ajuste_influencia; }
            set 
            {
                if (value < 0)
                    value = 0;
                if (value > 2)
                    value = 2;
                _valor_ajuste_influencia = value; 
            }
        }
        double _valor_ajuste_influencia = 1;

        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        // nombre_influencia
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        /// <summary>
        /// Nombre de la influencia
        /// </summary>
        public string nombre_influencia
        {
            get 
            {
                if (nombre_nodo_destino.Equals("") || nombre_nodo_origen.Equals(""))
                    return "";
                else
                    return "Desde " + nombre_nodo_origen + " a " + nombre_nodo_destino;
            }
        }

        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        // nombre_nodo_origen
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        /// <summary>
        /// nombre nodo origen
        /// </summary>
        public string nombre_nodo_origen
        {
            get { return _nombre_nodo_origen; }
            set { _nombre_nodo_origen = value; }
        }
        string _nombre_nodo_origen = "";

        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        // nombre_nodo_destino
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        /// <summary>
        /// nombre nodo destino
        /// </summary>
        public string nombre_nodo_destino
        {
            get { return _nombre_nodo_destino; }
            set { _nombre_nodo_destino = value; }
        }
        string _nombre_nodo_destino = "";


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

        }


        //*************************************************************************
        // Constructor
        //*************************************************************************
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id_influencia"></param>
        /// <param name="nombre_nodo_origen"></param>
        /// <param name="nombre_nodo_destino"></param>
        public Influencia(string id_influencia, string nombre_nodo_origen, string nombre_nodo_destino)
        {
            this.id_influencia = id_influencia;
            this.nombre_nodo_origen = nombre_nodo_origen;
            this.nombre_nodo_destino = nombre_nodo_destino;
        }

        //*************************************************************************
        // actualizaciónInfluencia
        //*************************************************************************

        /// <summary>
        /// Actualizacion del peso de la influencia en base al peso del nodo
        /// </summary>
        public void actualizacionInfluencia()
        {
            peso_influencia = _calculos.calculoPeso(fuzzy);
            peso_influencia = peso_influencia * valor_ajuste_influencia;
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
        /// <returns>peso de la influencia en base a la inferencia difusa</returns>
        double calculoPeso(InferenciaDifusa fuzzy);
    }

}
