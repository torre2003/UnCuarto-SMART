using AccesoADatos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloMBCIF
{
    public delegate void DelegadoGuardadoDeDatos(bool en_archivo);

    public delegate void DelegadoAnalisisDeDato();

    public delegate void DelegadoEventoIteracion(string nodo_actual);
    //-----------------------------------------------------------------------------------------------
    // ManejadorMBCIF
    //-----------------------------------------------------------------------------------------------
    /// <summary>
    /// Clase que gestiona las Matrices Base De Conocimiento Intervalo Difuso
    /// </summary>
    public class ManejadorMBCIF
    {
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        // evento_guardado_de_datos
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        /// <summary>
        /// Evento de guardado de datos
        /// </summary>
        public event DelegadoGuardadoDeDatos    evento_guardado_de_datos;
        
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        // evento_analisis_de_datos
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        /// <summary>
        /// Evento de analisis de datos
        /// </summary>
        public event DelegadoAnalisisDeDato     evento_analisis_de_datos;

        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        // evento_iteracion
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        /// <summary>
        /// Evento de iteración del proceso de analisis
        /// </summary>
        public event DelegadoEventoIteracion    evento_iteracion;

        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        // cola de analisis
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        
        /// <summary>
        /// Cola que almacena los nodos a analizar posteriormente
        /// </summary>
        Queue<string> cola_de_analisis = new Queue<string>();

        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        // numero_de_elementos_en_cola_de_analisis
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        
        /// <summary>
        /// Indica la cantidad de elementos en la cola de analisis
        /// </summary>
        public int numero_de_elementos_en_cola_de_analisis
        {
            get
            {
                return cola_de_analisis.Count;
            }
        }
        
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        // ruta archivo MBCIF
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-

        /// <summary>
        /// Ruta de la base de datos a trabajar por el objeto
        /// </summary>
        string ruta_archivo_MBCIF = "";

        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        // manejador de datos archivos
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-

        /// <summary>
        /// Clase que da acceso a los datos en la bdd
        /// </summary>
        ManejadorDeDatosArchivos manejador_de_datos_archivos = null;

        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        // manejador de datos bdd
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-

        /// <summary>
        /// Clase que da acceso a los datos en la bdd
        /// </summary>
        ManejadorDeDatosBaseDeDatos manejador_de_datos_bdd = null;


        //*************************************************************************
        // Constructor
        //*************************************************************************

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public ManejadorMBCIF()
        {
            manejador_de_datos_archivos = new ManejadorDeDatosArchivos();
            manejador_de_datos_bdd = new ManejadorDeDatosBaseDeDatos(manejador_de_datos_archivos);
            evento_guardado_de_datos += new DelegadoGuardadoDeDatos(this.guardarEstadoDeTodosLosNodos);
        }
        
        
        
        //*************************************************************************
        // Constructor
        //*************************************************************************
        
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="ruta_archivo_MBCIF">Ruta del archivo que contiene la base de datos a trabajar</param>
        public ManejadorMBCIF(string ruta_archivo_MBCIF)
        {
            this.ruta_archivo_MBCIF = ruta_archivo_MBCIF;
            manejador_de_datos_archivos = new ManejadorDeDatosArchivos(ruta_archivo_MBCIF);
            manejador_de_datos_bdd = new ManejadorDeDatosBaseDeDatos(manejador_de_datos_archivos);
            evento_guardado_de_datos += new DelegadoGuardadoDeDatos(this.guardarEstadoDeTodosLosNodos);
        }

        //*************************************************************************
        // Constructor
        //*************************************************************************
        
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="ruta_archivo_MBCIF">Ruta del archivo que contiene la base de datos a trabajar</param>
        /// <param name="server">ip del servidor</param>
        /// <param name="user">usuario de la base de datos</param>
        /// <param name="port">puerto de comunicacion de la base de datos</param>
        /// <param name="password">contraseña del usuario de la base de datos</param>
        /// <param name="database">nombre de la base de datos a trabajar</param>
        public ManejadorMBCIF(string server, string user, string port, string password, string database )
        {
            manejador_de_datos_archivos = new ManejadorDeDatosArchivos();
            manejador_de_datos_bdd = new ManejadorDeDatosBaseDeDatos(manejador_de_datos_archivos,server,user,port,password,database);
            evento_guardado_de_datos += new DelegadoGuardadoDeDatos(this.guardarEstadoDeTodosLosNodos);
        }

        //*************************************************************************
        // Constructor
        //*************************************************************************

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="server">ip del servidor</param>
        /// <param name="user">usuario de la base de datos</param>
        /// <param name="port">puerto de comunicacion de la base de datos</param>
        /// <param name="password">contraseña del usuario de la base de datos</param>
        /// <param name="database">nombre de la base de datos a trabajar</param>
        public ManejadorMBCIF(string ruta_archivo_MBCIF, string server, string user, string port, string password, string database)
        {
            manejador_de_datos_archivos = new ManejadorDeDatosArchivos(ruta_archivo_MBCIF);
            manejador_de_datos_bdd = new ManejadorDeDatosBaseDeDatos(manejador_de_datos_archivos, server, user, port, password, database);
            evento_guardado_de_datos += new DelegadoGuardadoDeDatos(this.guardarEstadoDeTodosLosNodos);
        }









        //*************************************************************************
        // ingresar datos internos a nodo
        //*************************************************************************
        /// <summary>
        /// Metodo para actualizar los datos internos de un nodo especifico
        /// </summary>
        /// <param name="datos">ArrayList(Dato) de tipo clave valor con el nombre y valor de las variables a actualizar en el nodo</param>
        /// <param name="id_nodo">id del nodo a actualizar</param>
        /// <param name="influencia_externa_forzada">Valor que debe estar entre -1 y 1, indicando el peso de la influencia externa en el nodo, 0 si no existe influencia</param>
        /// <returns>False, nodo no encontrado o variables incorrectas, True operacion realizada correctamente</returns>
        public bool ingresarDatosIntenosANodo(ArrayList datos, string id_nodo, double influencia_externa_forzada = 0)
        {
            Nodo nodo = manejador_de_datos_archivos.extraerNodo(id_nodo);
            if (nodo != null)
            {
                nodo.influencia_externa_forzada = influencia_externa_forzada;
                foreach (var item in datos)
                {
                    try
                    {
                        Dato dato = (Dato)item;
                        nodo.actualizarVariable(dato.id, dato.valor, Nodo.DATOS_INTERNOS);
                    }
                    catch
                    {
                        return false;
                    }
                    
                }
                manejador_de_datos_archivos.actualizarNodo(nodo);
                cola_de_analisis.Enqueue(id_nodo);
                return true;
            }
            return false;
        }

        //*************************************************************************
        // actualizar datos nodos externos en nodo
        //*************************************************************************

        /// <summary>
        /// Metodo que actualiza los datos de nodos externos necesarios en la inferencia difuza del nodo
        /// </summary>
        /// <param name="id_nodo">id del nodo a actualizar</param>
        /// <returns>Retorna una copia del nodo ingresado en la base de dato, null en caso de error</returns>
        public Nodo actualizarDatosNodoExternosEnNodo(string id_nodo)
        {
            Nodo nodo = manejador_de_datos_archivos.extraerNodo(id_nodo);
            if (nodo != null)
            {
                try
                {
                    string[] id_nodos_externos_necesarios = nodo.listarVariables(Nodo.DATOS_NODOS_EXTERNOS);
                    for (int i = 0; i < id_nodos_externos_necesarios.Length; i++)
                    {
                        Nodo nodo_externo = manejador_de_datos_archivos.extraerNodo(id_nodos_externos_necesarios[i]);
                        nodo.actualizarVariable(nodo_externo.id_nodo, nodo_externo.peso, Nodo.DATOS_NODOS_EXTERNOS);
                    }
                    manejador_de_datos_archivos.actualizarNodo(nodo);
                    return nodo;
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return null;
        }

        //*************************************************************************
        // actualizar influencia en nodo
        //*************************************************************************

        /// <summary>
        /// Metodo que actualiza el valor de una influencia en el nodo
        /// </summary>
        /// <param name="id_nodo">Nodo en que se actualizara la influencia</param>
        /// <param name="id_influencia"> id de la influencia a ingresar</param>
        /// <param name="valor">valor de la influencia a ingresar</param>
        /// <returns>FALSE si nodo o influencia desconocida, TRUE en caso contrario</returns>
        public bool actualizarInfluenciaEnNodo(string id_nodo, string id_influencia, double valor)
        {
            Nodo nodo = manejador_de_datos_archivos.extraerNodo(id_nodo);
            if (nodo != null)
            {
                try
                {
                    nodo.actualizarVariable(id_influencia, valor, Nodo.INFLUENCIAS_EXTERNAS);
                }
                catch (Exception)
                {
                    return false;
                }
                manejador_de_datos_archivos.actualizarNodo(nodo);
                return true;
            }
            return false;
        }

        //*************************************************************************
        // actualizar influencia 
        //*************************************************************************

        /// <summary>
        /// Metodo que ingresa el valor del nodo en la influencia y calcula su peso
        /// </summary>
        /// <param name="id_influencia">Influencia a actualizar</param>
        /// <param name="peso_nodo">Peso del nodo influyente</param>
        /// <returns>FALSE si nodo o influencia desconocida, TRUE en caso contrario</returns>
        public bool actualizarInfluencia(string id_influencia, double peso_nodo)
        {
            Influencia influencia = manejador_de_datos_archivos.extraerInfluencia(id_influencia);
            if (influencia != null)
            {
                try
                {
                    influencia.actualizarPesoNodo(peso_nodo);
                    influencia.actualizacionInfluencia();
                    manejador_de_datos_archivos.actualizarInfluencia(influencia);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        //*************************************************************************
        // calculo previo de peso nodos
        //*************************************************************************

        /// <summary>
        /// Metodo para calcular el peso de los nodos incluidos en la cola de analisis, sin contar su influencia
        /// </summary>
        public void calculoPrevioDePesosNodos()
        {
            Queue<string> cola_de_actualizacion         = new Queue<string>();
            Queue<string> cola_final_de_actualizacion   = new Queue<string>();
            foreach (var elemento in this.cola_de_analisis)
            {
                cola_de_actualizacion.Enqueue(elemento);
            }
            while (cola_de_actualizacion.Count > 0)     // Aqui actualizamos los nodos que no necesitan datos de nodos externos
            {
                string id_nodo = cola_de_actualizacion.Dequeue();

                Nodo nodo = manejador_de_datos_archivos.extraerNodo(id_nodo);
                string[] lista_de_nodos_externos = nodo.listarVariables(Nodo.DATOS_NODOS_EXTERNOS);
                if (lista_de_nodos_externos.Length != 0 && lista_de_nodos_externos != null )
                {
                    cola_final_de_actualizacion.Enqueue(nodo.id_nodo);
                }
                else
                {
                    nodo.actualizacionNodo();
                }
                manejador_de_datos_archivos.actualizarNodo(nodo);
            }

            while (cola_final_de_actualizacion.Count > 0)
            {
                string id_nodo = cola_de_actualizacion.Dequeue();
                Nodo nodo = manejador_de_datos_archivos.extraerNodo(id_nodo);
                nodo = actualizarDatosNodoExternosEnNodo(nodo.id_nodo);
                nodo.actualizacionNodo();
                manejador_de_datos_archivos.actualizarNodo(nodo);
            }
        }

        //*************************************************************************
        // Proceso MBCIF
        //*************************************************************************
        
        /// <summary>
        /// Metodo para procesar y analizar la MBCIF
        /// </summary>
        /// <param name="maximo_de_iteraciones">Numero maximo de iteraciones a realizar por el proceso</param>
        /// <param name="intervalo_guardado_de_datos">Frecuencia con que se guardaran los datos</param>
        /// <param name="intervalo_analisis_de_datos">Frecuencia con que se analizaran los datos con ID... </param>
        public void procesoMBCIF(int maximo_de_iteraciones, int intervalo_guardado_de_datos, int intervalo_analisis_de_datos, bool actualizacion_inmediata_de_nodo_influenciado = false, bool en_archivo = false)
        {
            int contador_de_iteraciones = 0;
            while (contador_de_iteraciones < maximo_de_iteraciones && cola_de_analisis.Count != 0)
            {
                if (contador_de_iteraciones != 0)
                {
                    if ( (intervalo_guardado_de_datos != 0 ) && (contador_de_iteraciones % intervalo_guardado_de_datos == 0) )//Evento guardado
                    {
                        evento_guardado_de_datos(en_archivo);
                    }
                    
                    if ((intervalo_analisis_de_datos != 0) &&(contador_de_iteraciones % intervalo_analisis_de_datos == 0)) //Evento analisis
                    {
                        if (evento_analisis_de_datos != null)
                            evento_analisis_de_datos();
                    }
                }
                //Actualizando Nodo
                string id_nodo_actual = cola_de_analisis.Dequeue();
                if (evento_iteracion != null) // Evento iterancion
                    evento_iteracion(id_nodo_actual);

                Nodo nodo_actual = manejador_de_datos_archivos.extraerNodo(id_nodo_actual);
                string[] lista_nodos_externos = nodo_actual.listarVariables(Nodo.DATOS_NODOS_EXTERNOS);//Lista de nodos, de los cuales se necesitan sus datos para la inferencia difusa del nodo_actual
                if (lista_nodos_externos != null && lista_nodos_externos.Length != 0)
                {
                    nodo_actual = actualizarDatosNodoExternosEnNodo(nodo_actual.id_nodo);
                }
                nodo_actual.actualizacionNodo();
                manejador_de_datos_archivos.actualizarNodo(nodo_actual);

                string[] lista_de_influencias = nodo_actual.listarVariables(Nodo.NODOS_INFLUENCIADOS);
                for (int i = 0; i < lista_de_influencias.Length; i++)
                {
                    //Actualizando influencia
                    string id_influencia_actual = "i_" + nodo_actual.id_nodo + "_" + lista_de_influencias[i];
                    Influencia influencia = manejador_de_datos_archivos.extraerInfluencia(id_influencia_actual);
                    influencia.actualizarPesoNodo(nodo_actual.peso);
                    influencia.actualizacionInfluencia();
                    manejador_de_datos_archivos.actualizarInfluencia( influencia);
                    
                    //Guardando datos en nodo influenciado
                    string id_nodo_influenciado = influencia.id_nodo_influenciado;
                    Nodo nodo_influenciado = manejador_de_datos_archivos.extraerNodo(id_nodo_influenciado);
                    nodo_influenciado.actualizarVariable(influencia.id_influencia, influencia.peso_influencia, Nodo.INFLUENCIAS_EXTERNAS);
                    if (actualizacion_inmediata_de_nodo_influenciado)
                        nodo_influenciado.actualizacionNodo();
                    manejador_de_datos_archivos.actualizarNodo(nodo_influenciado);
                    this.cola_de_analisis.Enqueue(nodo_influenciado.id_nodo);
                }
                contador_de_iteraciones++;
            }
            evento_guardado_de_datos(false);
            if (evento_analisis_de_datos != null)
                evento_analisis_de_datos();
         }

        
        /*
        //*************************************************************************
        // Proceso MBCIF Paso a paso
        //*************************************************************************

        /// <summary>
        /// Metodo para analizar las MBCIF paso a paso
        /// </summary>
        /// <returns> String con cambio realizados</returns>
        public string procesoMBCIFPasoAPaso()
        {
            string texto_de_retorno = "nodo_trabajado : ";
            
            string id_nodo_actual = cola_de_analisis.Dequeue();
            Nodo nodo_actual = manejador_de_datos_archivos.extraerNodo(id_nodo_actual);
            texto_de_retorno += id_nodo_actual + " P " + nodo_actual.peso + " PB " + nodo_actual.peso_bruto;////////////////

            string[] lista_nodos_externos = nodo_actual.listarVariables(Nodo.DATOS_NODOS_EXTERNOS);//Lista de nodos, de los cuales se necesitan sus datos para la inferencia difusa del nodo_actual
            if (lista_nodos_externos != null && lista_nodos_externos.Length != 0)
            {
                nodo_actual = actualizarDatosNodoExternosEnNodo(nodo_actual.id_nodo);
            }
            nodo_actual.actualizacionNodo();
            texto_de_retorno += id_nodo_actual + " P A " + nodo_actual.peso + " PB A " + nodo_actual.peso_bruto;////////////
            string[] lista_de_influencias = nodo_actual.listarVariables(Nodo.INFLUENCIAS_EXTERNAS);
            for (int i = 0; i < lista_de_influencias.Length; i++)
            {
                Influencia influencia = manejador_de_datos_archivos.extraerInfluencia(lista_de_influencias[i]);
                
                influencia.actualizarPesoNodo(nodo_actual.peso);
                
                influencia.actualizacionInfluencia();

                texto_de_retorno += "\n sacando influencia de " + influencia.id_influencia;//////////////////

                manejador_de_datos_archivos.actualizarInfluencia(influencia);
                
                string id_nodo_influenciado = influencia.id_nodo_influenciado;
                
                Nodo nodo_influenciado = manejador_de_datos_archivos.extraerNodo(id_nodo_influenciado);
                
                nodo_influenciado.actualizarVariable(influencia.id_influencia, influencia.peso_influencia, Nodo.INFLUENCIAS_EXTERNAS);
                
                manejador_de_datos_archivos.actualizarNodo(nodo_influenciado);

                this.cola_de_analisis.Enqueue(nodo_influenciado.id_nodo);
                texto_de_retorno += "\n ingresando nodo a cola " + nodo_influenciado.id_nodo;////////////////////////
            }
            return texto_de_retorno;
        }
         * 
         */

        public void limpiarInfluenciasExternasForzadaEnNodos()
        {
            string[] id_nodos = manejador_de_datos_archivos.listarArchivosEnDirectorio(ManejadorDeDatosArchivos.NODOS);
            for (int i = 0; i < id_nodos.Length; i++)
            {
                Nodo nodo_actual = manejador_de_datos_archivos.extraerNodo(id_nodos[i]);
                nodo_actual.limpiarInfluenciaExternaForzada();
                manejador_de_datos_archivos.actualizarNodo(nodo_actual);
            }
        }



        /// <summary>
        /// Método que encola un nodo a la cola de analisis 
        /// </summary>
        /// <param name="id_nodo">Id del nodo a encolar</param>
        /// <returns>True si el nodo es valido, False en caso contrario</returns>
        public bool ingresarNuevoNodoAColaDeAnalisis(string id_nodo)
        {
            bool flag = false;
            Nodo nodo = manejador_de_datos_archivos.extraerNodo(id_nodo);
            if (nodo != null)
            {
                flag = true;
                cola_de_analisis.Enqueue(id_nodo);
            }
            return flag;
        }
        //*************************************************************************
        // guardar estado de todos los nodos
        //*************************************************************************
        /// <summary>
        /// Método que guarda el estado de todos los nodos
        /// </summary>
        /// <param name="en_archivo">True si se quiere guardar los datos en archivo, False para base de datos</param>
        public void guardarEstadoDeTodosLosNodos(bool en_archivo = false)
        {
            if (en_archivo)
                manejador_de_datos_archivos.almacenarEnArchivoDeTextoNuevoEstadoDeLosNodos();
            else
                manejador_de_datos_bdd.almacenarEnBaseDatosNuevoEstadoDeLosNodos();
        }

        //*************************************************************************
        // limpiarColaDeAnalisis
        //*************************************************************************
        /// <summary>
        /// Método que deja la cola de analisis sis elementos
        /// </summary>
        public void limpiarColaDeAnalisis()
        {
            cola_de_analisis.Clear();
        }

    }
}
