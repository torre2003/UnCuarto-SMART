using AccesoADatos;
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
    // Sistema
    //-----------------------------------------------------------------------------------------------

    /// <summary>
    /// Clase que representa un sistema formado por nodos u otros sistemas
    /// </summary>
    [Serializable()]
    public class Sistema
    {
        /// <summary>
        /// Constante para tipo de datos
        /// </summary>
        public const int DATOS_NODOS = 1;
        
        /// <summary>
        /// Constante para tipo de datos
        /// </summary>
        public const int DATOS_SISTEMAS = 2;

        /// <summary>
        /// ID del sistema
        /// </summary>
        public string id_sistema
        {
            get { return _id_sistema; }
            set { _id_sistema = value; }
        }
        string _id_sistema;

        /// <summary>
        /// nombre identificatorio del sistema
        /// </summary>
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        string _nombre;

        /// <summary>
        /// Peso del sistema
        /// </summary>
        public double peso
        {
            get { return _peso; }
            set { _peso = value; }
        }
        double _peso = 0;

        /// <summary>
        /// Arreglo de tipo Dato, que contiene los valores de las variables de nodos para el calculo difuso
        /// </summary>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public ArrayList datos_nodos { get; set; }

        /// <summary>
        /// Arreglo de tipo Dato, que contiene los valores de las variables de sistemas para el calculo difuso
        /// </summary>
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public ArrayList datos_sistemas { get; set; }

        /// <summary>
        /// Atributo que contiene todo el sistema difuso del nodo
        /// </summary>
        public InferenciaDifusa fuzzy
        {
            set { _fuzzy = value; }
            get { return _fuzzy; }
        }
        InferenciaDifusa _fuzzy;


        /// <summary>
        /// Objeto que contiene métodos personalizados para el calculo de peso del sistema
        /// </summary>
        public ICalculosSistema calculos
        {
            set { _calculos = value; }
            get { return _calculos; }
        }
        ICalculosSistema _calculos;


        //*************************************************************************
        // Constructor
        //*************************************************************************

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id_sistema">Id del sistema</param>
        /// <param name="nombre">nombre identificatorio del sistema</param>
        public Sistema(string id_sistema, string nombre)
        {
            this._id_sistema = id_sistema;
            this._nombre = nombre;
            datos_nodos = new ArrayList();
            datos_sistemas = new ArrayList();

        }

        //*************************************************************************
        // actualizarVariable
        //*************************************************************************

        /// <summary>
        /// Método para actualizar las distintas variables del nodo
        /// </summary>
        /// <param name="id_variable">Nombre de la variable a actualizar</param>
        /// <param name="valor">Valor a ingresar a la variable</param>
        /// <param name="tipo_de_variable">Constante con el tipo de variable a actualizar DATOS_NODOS, DATOS_SISTEMAS </param>
        /// <returns>true si existe la variable, false en caso contrario</returns>
        public bool actualizarVariable(string id_variable, double valor, int tipo_de_variable)
        {
            switch (tipo_de_variable)
            {
                case DATOS_NODOS:
                    foreach (var item in datos_nodos)
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
                case DATOS_SISTEMAS:
                    foreach (var item in datos_sistemas)
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
        /// <param name="tipo_de_variable">Constante con el tipo de variable a consultar DATOS_NODOS, DATOS_SISTEMAS </param>
        /// <returns>valor de la variable, -666 en caso de no existir la variable</returns>
        public double extraerValorVariable(string id_variable, int tipo_de_variable)
        {
            switch (tipo_de_variable)
            {
                case DATOS_NODOS:
                    foreach (var item in datos_nodos)
                    {
                        Dato variable = (Dato)item;
                        if (variable.id.Equals(id_variable))
                            return variable.valor;
                    }
                    break;
                case DATOS_SISTEMAS:
                    foreach (var item in datos_sistemas)
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
        // listarVariables
        //*************************************************************************

        /// <summary>
        /// Metodo para listar las id de las variables según el tipo
        /// </summary>
        /// <param name="tipo_de_variable">Constante de identificación para el tipo de variables DATOS_NODOS, DATOS_SISTEMAS </param>
        /// <returns>retorna un arreglo con la lista de id, del tipo de variables pedidas.</returns>
        public string[] listarVariables(int tipo_de_variable)
        {
            string[] retorno = null;
            int i = 0;
            switch (tipo_de_variable)
            {
                case DATOS_NODOS:
                    i = 0;
                    retorno = new string[datos_nodos.Count];
                    foreach (var item in datos_nodos)
                    {
                        Dato variable = (Dato)item;
                        retorno[i] = variable.id;
                        i++;
                    }
                    break;
                case DATOS_SISTEMAS:
                    i = 0;
                    retorno = new string[datos_sistemas.Count];
                    foreach (var item in datos_sistemas)
                    {
                        Dato variable = (Dato)item;
                        retorno[i] = variable.id;
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
        /// <param name="tipo_de_variable">Constante de identificación para el tipo de variables DATOS_NODOS, DATOS_SISTEMAS </param>
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
                case DATOS_NODOS:
                    datos_nodos.Add(dato);
                    return true;
                case DATOS_SISTEMAS:
                    datos_sistemas.Add(dato);
                    return true;
                default:
                    break;
            }
            return false;
        }

        //*************************************************************************
        // actualizarPesoSistema
        //*************************************************************************
        /// <summary>
        /// Método recursivo para actualizar el peso del sistema y de los sistemas incluidos en él
        /// </summary>
        /// <param name="ruta_repositorio_de_datos">String con la ruta del repositorio de datos</param>
        /// <param name="guardar_sistemas">TRUE para que la actualizacion del sistema y sus subsistemas sean guardados FALSE si solo se quiere el valor del peso</param>
        /// <returns>Peso del sistema analizado</returns>
        public double actualizarPesoSistema(string ruta_repositorio_de_datos = null, bool guardar_sistemas = true)
        {
            ManejadorDeDatosArchivos manejador_de_archivos;
            if (ruta_repositorio_de_datos == null)
                manejador_de_archivos = new ManejadorDeDatosArchivos();
            else
                manejador_de_archivos = new ManejadorDeDatosArchivos(ruta_repositorio_de_datos);
            
            //actualizando datos de nodos en sistema
            string[] nodos_del_sistema = this.listarVariables(Sistema.DATOS_NODOS);
               // manejador_de_archivos.listarArchivosEnDirectorio(ManejadorDeDatosArchivos.NODOS);
            for (int i = 0; i < nodos_del_sistema.Length; i++)
            {
                Nodo nodo_actual = manejador_de_archivos.extraerNodo(nodos_del_sistema[i]);
                actualizarVariable(nodo_actual.id_nodo, nodo_actual.peso, Sistema.DATOS_NODOS);
            }
            string[] sistemas_de_sistema = this.listarVariables(Sistema.DATOS_SISTEMAS);
                //manejador_de_archivos.listarArchivosEnDirectorio(ManejadorDeDatosArchivos.SISTEMAS);
            
            // actualizando datos de sistemas
            for (int i = 0; i < sistemas_de_sistema.Length; i++)
            {
                Sistema sistema_actual = manejador_de_archivos.extraerSistema(sistemas_de_sistema[i]);
                double peso_sistema = sistema_actual.actualizarPesoSistema (ruta_repositorio_de_datos);
                actualizarVariable(sistema_actual.id_sistema, peso_sistema, Sistema.DATOS_SISTEMAS);
            }
            
            this._peso = _calculos.calculoPeso(this.fuzzy);
            if (guardar_sistemas)
                manejador_de_archivos.actualizarSistema(this);
            return this._peso;

        }

    }


    //-----------------------------------------------------------------------------------------------
    // ICalculosSistema
    //-----------------------------------------------------------------------------------------------

    /// <summary>
    /// Interfaz para calcular los pesos singulares a cada sistema
    /// </summary>
    public interface ICalculosSistema
    {
        /// <summary>
        /// Método para calcular el peso del sistema en base a la inferencia difusa
        /// </summary>
        /// <param name="fuzzy">Objeto con la inferencia difusa</param>
        /// <returns>Peso del sistema</returns>
        double calculoPeso(InferenciaDifusa fuzzy);
    }






}
