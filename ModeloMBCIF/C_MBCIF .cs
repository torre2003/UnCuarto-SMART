﻿using FuzzyCore;
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
    // Nodo
    //-----------------------------------------------------------------------------------------------

    /// <summary>
    /// Clase que representa los nodos externos de los sistemas en las matrices MBCIF
    /// </summary>
    [Serializable()]
    public class Nodo
    {
        public const int DATOS_INTERNOS             = 1;
        public const int DATOS_NODOS_EXTERNOS       = 2;
        public const int INFLUENCIAS_EXTERNAS       = 3;
        public const int NODOS_INFLUENCIADOS        = 4;
        public const int DATOS_DE_SALIDA            = 5;

        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        // id nodo
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-

        /// <summary>
        /// ID del nodo 
        /// </summary>
        public string id_nodo
        {
            get { return _id_nodo; }
            set { _id_nodo = value; }
        }
        string  _id_nodo;

        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        // nombre
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-

        /// <summary>
        /// Nombre identificatorio del nodo
        /// </summary>
        public string nombre
        {
            get{return _nombre;}
            set{_nombre = value;}
        }
        string _nombre;

        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        // peso
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-

        /// <summary>
        /// Peso real del nodo sacado en base al peso bruto
        /// ajustado por las influencias del mismo
        /// </summary>
        public double peso
        {
            get {return _peso;}
        }
        double   _peso = 0;

        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        // peso bruto
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-

        /// <summary>
        /// Valor difuso que corresponde al peso del nodo sacado en base 
        /// a la inferencia difusa, SIN ajustar con las influencias
        /// </summary>
        public double peso_bruto
        {
            get{return _peso_bruto;}
        }
        double   _peso_bruto = 0;

        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        // datos_internos
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-

        /// <summary>
        /// Arreglo de tipo Dato, que contiene los valores de las variables internas para el calculo difuso del nodo
        /// </summary>
         [TypeConverter(typeof(ExpandableObjectConverter))]
        public ArrayList datos_internos { get; set; }//= new ArrayList();

        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        //  nodo externos
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
    
        /// <summary>
        /// Arreglo de tipo Dato, que contiene los valores de nodos externos para el calculo difuso del nodo
        /// </summary>
        [TypeConverter(typeof(ExpandableObjectConverter))]
         public ArrayList nodos_externos { get; set; }//= new ArrayList();

        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        // influencias
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-

        /// <summary>
        /// Arreglo de tipo Dato, que contiene los valores de las influencias del nodo
        /// </summary>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public ArrayList influencias { get; set; }//= new ArrayList();

        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        // nodos_influenciados
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-

        /// <summary>
        /// Arreglo de string que contiene la lista de nodos influenciados por el nodo
        /// </summary>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public ArrayList nodos_influenciados { get; set; }//= new ArrayList();

        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        // fuzzy
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-

        /// <summary>
        /// Atributo que contiene todo el sistema difuso del nodo
        /// </summary>
        public InferenciaDifusa fuzzy
        {
            set{ _fuzzy = value;}
            get{ return _fuzzy; }
        }
        InferenciaDifusa _fuzzy;

        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        // calculos
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-

        /// <summary>
        /// Objeto que contiene métodos personalizados para el calculo de peso y peso ajustado del nodo
        /// </summary>
        public ICalculosNodo calculos
        {
            set { _calculos = value; }
            get { return _calculos; }
        }
        ICalculosNodo _calculos;
        
        //*************************************************************************
        //Constructor
        //*************************************************************************

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="id_nodo">id del nodo a crear</param>
        public Nodo(string id_nodo)
        {
            this.id_nodo    = id_nodo;
            datos_internos = new ArrayList();
            nodos_externos = new ArrayList();
            influencias = new ArrayList();
            nodos_influenciados = new ArrayList();


        }
        
        //*************************************************************************
        // Constructor
        //*************************************************************************
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id_nodo">id del nodo a crear</param>
        /// <param name="nombre">nombre del nodo</param>
        public Nodo(string id_nodo, string nombre)
        {
            this.id_nodo    = id_nodo;
            this.nombre     = nombre;

            datos_internos = new ArrayList();
            nodos_externos = new ArrayList();
            influencias = new ArrayList();
            nodos_influenciados = new ArrayList();
        }

        //*************************************************************************
        // Actualización nodo
        //*************************************************************************

        /// <summary>
        /// Metodo para actualizar el peso bruto y el peso_ajustado del nodo
        /// </summary>
        public void actualizacionNodo()
        {
            _peso_bruto     = _calculos.calculoPesoBruto(this.fuzzy);
            _peso           = _calculos.calculoPeso(this._peso_bruto, influencias);
            _calculos.fuzzificarPeso(this.peso, this.fuzzy);
        }

        //*************************************************************************
        // actualizarVariable
        //*************************************************************************

        /// <summary>
        /// Método para actualizar las distintas variables del nodo
        /// </summary>
        /// <param name="id_variable">Nombre de la variable a actualizar</param>
        /// <param name="valor">Valor a ingresar a la variable</param>
        /// <param name="tipo_de_variable">Constante con el tipo de variable a actualizar DATO_INTERNO,NODO_EXTERNO,INFLUENCIA;</param>
        /// <returns>true si existe la variable, false en caso contrario</returns>
        public bool actualizarVariable(string id_variable, double valor, int tipo_de_variable)
        {
            switch (tipo_de_variable)
            {
                case DATOS_INTERNOS:
                    foreach (var item in datos_internos)
                    {
                        Dato variable = (Dato)item;
                        if (variable.id.Equals(id_variable))
                        {
                            variable.valor = valor;
                            fuzzy.Entradas[id_variable].Fuzzyficar(valor);
                            return true;
                        }
                    }
                    break;
                case DATOS_NODOS_EXTERNOS:
                    foreach (var item in nodos_externos)
                    {
                        Dato variable = (Dato)item;
                        if (variable.id.Equals(id_variable))
                        {
                            variable.valor = valor;
                            fuzzy.Entradas[id_variable].Fuzzyficar(valor);
                            return true;
                        }
                    }
                    break;
                case INFLUENCIAS_EXTERNAS:
                    foreach (var item in influencias)
                    {
                        Dato variable = (Dato)item;
                        if (variable.id.Equals(id_variable))
                        {
                            variable.valor = valor;
                            return true;
                        }
                    }
                    //agregarVariable(id_variable, tipo_de_variable, valor);
                    //return true;
                    break;
                default:
                    break;
            }
            return false;
        }
        
        //*************************************************************************
        // extraerValorVariable 
        //*************************************************************************

        /// <summary>
        /// Método para extraer el valor de la variable en el nodo
        /// </summary>
        /// <param name="id_variable">Id de la variable</param>
        /// <param name="tipo_de_variable">Constante con el tipo de variable a consultar DATO_INTERNO,NODO_EXTERNO,INFLUENCIA; </param>
        /// <returns>valor de la variable, -666 en caso de no existir la variable</returns>
        public double extraerValorVariable(string id_variable, int tipo_de_variable)
        {
            switch (tipo_de_variable)
            {
                case DATOS_INTERNOS:
                    foreach (var item in datos_internos)
                    {
                        Dato variable = (Dato)item;
                        if (variable.id.Equals(id_variable))
                            return variable.valor;
                    }
                    break;
                case DATOS_NODOS_EXTERNOS:
                    foreach (var item in nodos_externos)
                    {
                        Dato variable = (Dato)item;
                        if (variable.id.Equals(id_variable))
                            return variable.valor;
                    }
                    break;
                case INFLUENCIAS_EXTERNAS:
                    foreach (var item in influencias)
                    {
                        Dato variable = (Dato)item;
                        if (variable.id.Equals(id_variable))
                            return variable.valor;
                    }
                    break;
            }
            return -666;
        }

        //*************************************************************************
        // extraerRangoVariable
        //*************************************************************************

        /// <summary>
        /// Método para extraer el rango de valores permitidos para la Variable de Datos
        /// </summary>
        /// <param name="id_variable">Id de la variable</param>
        /// <param name="tipo_de_variable">Constante con el tipo de variable a consultar DATO_INTERNO,DATOS_NODOS_EXTERNOS; </param>
        /// <returns>valor de la variable, -666 en caso de no existir la variable</returns>
        public double[] extraerRangoVariable(string id_variable, int tipo_de_variable)
        {
            double[] aux = new double[2];
            switch (tipo_de_variable)
            {
                case DATOS_INTERNOS:
                    foreach (var item in datos_internos)
                    {
                        Dato variable = (Dato)item;
                        if (variable.id.Equals(id_variable))
                        {
                            aux[0] = fuzzy.Entradas[id_variable].Min;
                            aux[1] = fuzzy.Entradas[id_variable].Max;
                            return aux;
                        }
                    }
                    break;
                case DATOS_NODOS_EXTERNOS:
                    foreach (var item in nodos_externos)
                    {
                        Dato variable = (Dato)item;
                        if (variable.id.Equals(id_variable))
                        {
                            aux[0] = fuzzy.Entradas[id_variable].Min;
                            aux[1] = fuzzy.Entradas[id_variable].Max;
                            return aux;
                        }
                    }
                    break;
            }
            return null;
        }

        //*************************************************************************
        // listarVariables
        //*************************************************************************

        /// <summary>
        /// Metodo para listar las id de las variables según el tipo
        /// </summary>
        /// <param name="tipo_de_variable">Constante de identificación para el tipo de variables DATO_INTERNO,NODO_EXTERNO,INFLUENCIA,NODO_INFLUENCIADO; </param>
        /// <returns>retorna un arreglo con la lista de id, del tipo de variables pedidas.</returns>
        public string[] listarVariables(int tipo_de_variable)
        {
            string[] retorno = null;
            int i = 0;
            switch (tipo_de_variable)
            {
                case DATOS_INTERNOS:
                    i = 0;
                    retorno = new string[datos_internos.Count];
                    foreach (var item in datos_internos)
                    {
                        Dato variable = (Dato)item;
                        retorno[i] = variable.id;
                        i++;
                    }
                    break;
                case DATOS_NODOS_EXTERNOS:
                    i = 0;
                    retorno = new string[nodos_externos.Count];
                    foreach (var item in nodos_externos)
                    {
                        Dato variable = (Dato)item;
                        retorno[i] = variable.id;
                        i++;
                    }
                    break;
                case INFLUENCIAS_EXTERNAS:
                    i = 0;
                    retorno = new string[influencias.Count];
                    foreach (var item in influencias)
                    {
                        Dato variable = (Dato)item;
                        retorno[i] = variable.id;
                        i++;
                    }
                    break;
                case NODOS_INFLUENCIADOS:
                    i = 0;
                    retorno = new string[nodos_influenciados.Count];
                    foreach (var item in nodos_influenciados)
                    {
                        
                        retorno[i] = (string)item;
                        i++;
                    }
                    break;
                default:
                    break;
            }
            return retorno;
        }

        //*************************************************************************
        // agregarVariable
        //*************************************************************************

        /// <summary>
        /// Metodo para agregar variables según el tipo
        /// </summary>
        /// <param name="id_variable">id de la nueva variable a ingresar</param>
        /// <param name="tipo_de_variable">Constante de identificación para el tipo de variables DATO_INTERNO,NODO_EXTERNO,INFLUENCIA,NODO_INFLUENCIADO; </param>
        /// <param name="valor">Parametro opcional con el valor de la variable</param>
        /// <returns>true si se ingresa la variable correctamente, false si es repetida, null o vacia</returns>
        public bool agregarVariable(string id_variable, int tipo_de_variable, double valor = 0)
        {
            string[] lista_de_variables = listarVariables(tipo_de_variable);
            if (id_variable == null || id_variable.Equals(""))
                return false;
            for (int i = 0; i < lista_de_variables.Length; i++)
            {
                if (lista_de_variables[i].Equals(id_variable))
                    return false;
            }
            Dato dato = new Dato();
            dato.id = id_variable;
            dato.valor = valor;
            switch (tipo_de_variable)
            {
                case DATOS_INTERNOS:
                    datos_internos.Add(dato);
                    return true;
                    break;
                case DATOS_NODOS_EXTERNOS:
                    nodos_externos.Add(dato);
                    return true;
                case INFLUENCIAS_EXTERNAS:
                    influencias.Add(dato);
                    return true;
                case NODOS_INFLUENCIADOS:
                    nodos_influenciados.Add(id_variable);
                    return true;
                default:
                    break;
            }
            return false;
        }

        //*************************************************************************
        // extraerVariablesDeSalidaNodo
        //*************************************************************************
        /// <summary>
        /// Método para extraer las variables de salida del nodo
        /// </summary>
        /// <returns>Arreglo de Tipo Dato con las variables y sus valores </returns>
        public Dato[] extraerVariablesDeSalidaNodo()
        {
            ArrayList datos = new ArrayList();
            foreach (var item in fuzzy.Salidas[this.nombre].UniversoDiscurso)
	        {
                Dato dato = new Dato();
                dato.id = item.Nombre;
                dato.valor = item.GradoPertenencia.Valor;
                datos.Add(dato);
            }
            Dato[] datos_de_retorno = new Dato[datos.Count];
            int i = 0;
            foreach (var item in datos)
            {
                datos_de_retorno[i] = (Dato)item;
                i++;
            }
            return datos_de_retorno;
        }


    } // fin Clase Nodo

    

    //-----------------------------------------------------------------------------------------------
    // ICalculosNodo
    //-----------------------------------------------------------------------------------------------

    /// <summary>
    /// Interface para implementar los metodos de calculo singulares a cada nodo
    /// </summary>
    public interface ICalculosNodo
    {
        /// <summary>
        /// Metodo que calcula el peso del nodo en base al peso bruto y sus influencias
        /// </summary>
        /// <param name="peso_bruto_nodo">Peso del nodo sin influencias</param>
        /// <param name="influencias">Arreglo de influencias del nodo</param>
        /// <returns>Peso del nodo</returns>
        double calculoPeso(double peso_bruto_nodo, ArrayList influencias);
        
        /// <summary>
        /// Metodo que calcula el peso bruto del nodo en base a la inferencia difusa
        /// </summary>
        /// <param name="fuzzy">Objeto con el sistema difuso del nodo</param>
        /// <returns>Peso bruto del nodo</returns>
        double calculoPesoBruto(InferenciaDifusa fuzzy);

        /// <summary>
        /// Metodo para fuzzificar un peso del nodo en el sistema difuso saltandose la inferencia difusa
        /// </summary>
        /// <param name="peso">valor a fusificar</param>
        /// <param name="fuzzy">Objeto con el sistema difuso del nodo</param>
        void fuzzificarPeso(double peso, InferenciaDifusa fuzzy);
    }

    //-----------------------------------------------------------------------------------------------
    //  Dato
    //-----------------------------------------------------------------------------------------------

    /// <summary>
    /// Estructura para almacenar los datos de las variables en los nodos
    /// </summary>
    [Serializable()]
    public class Dato
    {   
        /// <summary>
        /// texto identificadorio
        /// </summary>
        public string id;
        
        /// <summary>
        /// valor a almacenar
        /// </summary>
        public double valor;
        
        /// <summary>
        /// Constructor
        /// </summary>
        public Dato(){}
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">Id del dato</param>
        /// <param name="valor">valor del dato</param>
        public Dato(string id, double valor)
        {
            this.id = id;
            this.valor = valor;
        }
        public override string ToString()
        {
            return string.Format("{0} [{1}]", id, valor);
        }
    }

}
