using ManejadorPostgreSQL;
using ModeloMBCIF;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


namespace AccesoADatos
{
    //-----------------------------------------------------------------------------------------------
    // Manejador de Datos
    //-----------------------------------------------------------------------------------------------
    /// <summary>
    /// Clase encargada de la gestion de datos con archivos
    /// </summary>
    public class ManejadorDeDatosArchivos
    {
        public const int NODOS          = 1;
        public const int INFLUENCIAS    = 2;
        public const int SISTEMAS       = 3;
        
        
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        // ruta carpeta archivos
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        /// <summary>
        /// Contiene la ruta a la carpeta en donde se encuentran los archivos a utilizar en el programa
        /// </summary>
        string ruta_carpeta_archivos = "repositorio de datos\\";

        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        // nombre archivo de analisis
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        /// <summary>
        /// Contiene el nombre del archivo en donde se guardaran las tuplas de datos para analisis
        /// </summary>
        public string nombre_de_datos = "archivo de datos.txt";

        //*************************************************************************
        //Constructor
        //*************************************************************************

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public ManejadorDeDatosArchivos()
        {
            inicializarCarpetaArchivos();
        }

        //*************************************************************************
        //Constructor
        //*************************************************************************

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="ruta_carpeta_archivos"> ruta de la carpeta que contiene los archivos a trabajar</param>
        public ManejadorDeDatosArchivos(string ruta_carpeta_archivos)
        {
            this.ruta_carpeta_archivos = ruta_carpeta_archivos +"\\";
            inicializarCarpetaArchivos();
        }

        //*************************************************************************
        //inicializar Carpeta
        //*************************************************************************
        /// <summary>
        /// Metodo que crea si no existe la carpeta de archivos a trabajar
        /// </summary>                
        public void inicializarCarpetaArchivos()
        {
            if (!System.IO.Directory.Exists(ruta_carpeta_archivos))
                System.IO.Directory.CreateDirectory(ruta_carpeta_archivos);
        }

                
        //*************************************************************************
        // Ingresar nuevo Nodo
        //*************************************************************************
       
        /// <summary>
        ///  Ingresa un nuevo nodo a la carpeta de archivos
        /// </summary>
        /// <param name="nodo">Nodo a ingresar</param>
        public void ingresarNuevoNodo(Nodo nodo)
        {
            string id_nodo = "";
            if (nodo != null)
            {
                id_nodo = nodo.id_nodo;
            }
            
            if (File.Exists(ruta_carpeta_archivos + id_nodo))
                File.Delete(ruta_carpeta_archivos + id_nodo);
            using (Stream stream = File.OpenWrite(ruta_carpeta_archivos + id_nodo))
            {
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(stream, nodo);
                stream.Close();
            }
        }
        
        
        //*************************************************************************
        // Extraer Nodo
        //*************************************************************************
       
        /// <summary>
        /// Extrae un objeto nodo en la carpeta de archivos
        /// </summary>
        /// <param name="id_nodo">Id del nodo a extraer</param>
        /// <returns>>Nodo encontrado</returns>
        public Nodo extraerNodo (string id_nodo)
        {
            Nodo encontrado;
            string path = ruta_carpeta_archivos + id_nodo;
            if (File.Exists(path))
            {
                using (Stream stream = File.OpenRead(ruta_carpeta_archivos + id_nodo))
                {
                    try
                    {
                        BinaryFormatter deserializer = new BinaryFormatter();
                        encontrado = (Nodo)deserializer.Deserialize(stream);
                        stream.Close();
                    }
                    catch (Exception)
                    {
                        stream.Close();
                        return null;
                    }
                }
                return encontrado;
            }
            return null;
        }
        
        //*************************************************************************
        // Actualizar nodo
        //*************************************************************************
        
        /// <summary>
        ///  Actualiza un nodo en la carpeta de archiivos
        /// </summary>
        /// <param name="nodo">Nodo a ingresar</param>
        public void actualizarNodo(Nodo nodo)
        {
            string id_nodo = "";
            if (nodo != null)
            {
                id_nodo = nodo.id_nodo;
            }
            if (File.Exists(ruta_carpeta_archivos + id_nodo))
                using (Stream stream = File.OpenWrite(ruta_carpeta_archivos+id_nodo))
                {
                    BinaryFormatter serializer = new BinaryFormatter();
                    serializer.Serialize(stream, nodo);
                    stream.Close();
                }
        }

        //*************************************************************************
        // Ingresar nueva Influencia
        //*************************************************************************

        /// <summary>
        /// Ingresa un nuevo nodo a la carpeta de archivos
        /// </summary>
        /// <param name="influencia">Objecto Influencia a ingresar</param>
        public void ingresarNuevaInfluencia(Influencia influencia)
        {
            string id_influencia = "";
            if (influencia != null)
            {
                id_influencia = influencia.id_influencia;
            }
            if (File.Exists(ruta_carpeta_archivos + id_influencia))
                File.Delete(ruta_carpeta_archivos + id_influencia);
            using (Stream stream = File.OpenWrite(ruta_carpeta_archivos + id_influencia))
            {
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(stream, influencia);
                stream.Close();
            }
        }


        //*************************************************************************
        // Extraer influencia
        //*************************************************************************

        /// <summary>
        /// Extrae una influencia de los archivos
        /// </summary>
        /// <param name="id_influencia">id de la influencia a buscar</param>
        /// <returns>Influencia encontrada en la base de datos, null en caso de no encontrarse</returns>
        public Influencia extraerInfluencia (string id_influencia){
            Influencia encontrado;
            if (File.Exists(ruta_carpeta_archivos + id_influencia))
            {
                using (Stream stream = File.OpenRead(ruta_carpeta_archivos + id_influencia))
                {
                    try
                    {
                        BinaryFormatter deserializer = new BinaryFormatter();
                        encontrado = (Influencia)deserializer.Deserialize(stream);
                        stream.Close();
                    }
                    catch (Exception)
                    {
                        stream.Close();
                        return null;
                    }
                }
                return encontrado;
            }
            return null;
        }

        //*************************************************************************
        // Actualizar influencia
        //*************************************************************************

        /// <summary>
        /// Actualiza una influencia en el sistema de archivos
        /// </summary>
        /// <param name="influencia">Id de la influencia a actualizar</param>
        public void actualizarInfluencia(Influencia influencia)
        {
            string id_influencia = "";
            if (influencia != null)
            {
                id_influencia = influencia.id_influencia;
            }
            if (File.Exists(ruta_carpeta_archivos + id_influencia))
                using (Stream stream = File.OpenWrite(ruta_carpeta_archivos + id_influencia))
                {
                    BinaryFormatter serializer = new BinaryFormatter();
                    serializer.Serialize(stream, influencia);
                    stream.Close();
                }
        }

        //*************************************************************************
        // Ingresar nuevo Sistema
        //*************************************************************************

        /// <summary>
        ///  Ingresa un nuevo sistema a la carpeta de archivos
        /// </summary>
        /// <param name="sistema">Sistema a ingresar</param>
        public void ingresarNuevoSistema(Sistema sistema )
        {
            string id_sistema = "";
            if (sistema != null)
            {
                id_sistema = sistema.id_sistema;
            }

            if (File.Exists(ruta_carpeta_archivos + id_sistema))
                File.Delete(ruta_carpeta_archivos + id_sistema);
            using (Stream stream = File.OpenWrite(ruta_carpeta_archivos + id_sistema))
            {
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(stream, sistema);
                stream.Close();
            }
        }


        //*************************************************************************
        // Extraer Sistema
        //*************************************************************************

        /// <summary>
        /// Extrae un objeto sistema de los archivos
        /// </summary>
        /// <param name="id_sistema">Id del sistema a extraer</param>
        /// <returns>Sistema encontrado</returns>
        public Sistema extraerSistema(string id_sistema)
        {
            Sistema encontrado;
            string path = ruta_carpeta_archivos + id_sistema;
            if (File.Exists(path))
            {
                using (Stream stream = File.OpenRead(ruta_carpeta_archivos + id_sistema))
                {
                    try
                    {
                        BinaryFormatter deserializer = new BinaryFormatter();
                        encontrado = (Sistema)deserializer.Deserialize(stream);
                        stream.Close();
                    }
                    catch (Exception)
                    {
                        stream.Close();
                        return null;
                    }
                    
                }
                return encontrado;
            }
            return null;
        }

        //*************************************************************************
        // Actualizar Sistema
        //*************************************************************************

        /// <summary>
        ///  Actualiza un objeto sistema en los archivos
        /// </summary>
        /// <param name="sistema">Objeto sistema a ingresar</param>
        public void actualizarSistema(Sistema sistema)
        {
            string id_sistema = "";
            if (sistema != null)
            {
                id_sistema = sistema.id_sistema;
            }
            if (File.Exists(ruta_carpeta_archivos + id_sistema))
                using (Stream stream = File.OpenWrite(ruta_carpeta_archivos + id_sistema))
                {
                    BinaryFormatter serializer = new BinaryFormatter();
                    serializer.Serialize(stream, sistema);
                    stream.Close();
                }
        }

        
        //*************************************************************************
        // listarArchivosEnDirectorio
        //*************************************************************************
        /// <summary>
        /// Lista los archivos en la carpeta de repositorio según el tipo especificado
        /// </summary>
        /// <param name="tipo_de_archivos">Constante NODO,INFLUENCIA,SISTEMA</param>
        /// <returns>Arreglo con la lista  de archivos</returns>
        public string[] listarArchivosEnDirectorio (int tipo_de_archivos){

            string tipo = "";
            switch (tipo_de_archivos)
            {
                case NODOS:
                    tipo = "n*";
                    break;
                case SISTEMAS:
                    tipo = "s*";
                    break;
                case INFLUENCIAS:
                    tipo = "i*";
                    break;
                default:
                    break;
            }


            DirectoryInfo directorios_de_datos = new DirectoryInfo(this.ruta_carpeta_archivos);
            FileInfo[] archivos_directorios =  directorios_de_datos.GetFiles(tipo);
            string[] lista_de_archivos = new string [ archivos_directorios.Length];
            for (int i = 0; i < lista_de_archivos.Length; i++)
            {
                lista_de_archivos[i] = archivos_directorios[i].Name;
            }

            return lista_de_archivos;
        }


        //*************************************************************************
        // almacenarEnArchivoDeTextoNuevoEstadoDeLosNodos
        //*************************************************************************

        /// <summary>
        /// Método que ingresa la información de todos los nodos del sistema, a un archivo de texto para su posterior analisis
        /// </summary>
        public void almacenarEnArchivoDeTextoNuevoEstadoDeLosNodos()
        {
            string[] lista_de_archivos = listarArchivosEnDirectorio(ManejadorDeDatosArchivos.NODOS);

            string texto_de_ingreso = "";
            for (int i = 0; i < lista_de_archivos.Length; i++)
            {
                Nodo nodo_actual = extraerNodo(lista_de_archivos[i]);
                if (i != 0)
                    texto_de_ingreso += ";||;";

                texto_de_ingreso += nodo_actual.id_nodo + ";Peso;" + nodo_actual.peso;
                /*
                Dato[] datos_salida_nodo = nodo_actual.extraerVariablesDeSalidaNodo();
                for (int j = 0; j < datos_salida_nodo.Length; j++)
                {
                    texto_de_ingreso += ";" + datos_salida_nodo[j].id + ";" + datos_salida_nodo[j].valor;
                }
            */
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(texto_de_ingreso);
            using (StreamWriter outfile = new StreamWriter(nombre_de_datos,true))
            {
                outfile.Write(sb.ToString());
            }
        }

        //*************************************************************************
        // limpiarArchivoDeDatos
        //*************************************************************************
        
        /// <summary>
        /// Funcion para limpiar el archivo repositorio de los datos 
        /// </summary>
        /// <returns>True si fue eliminado correctamente, False en caso contrario</returns>
        public bool limpiarArchivoDeDatos()
        {
            try
            {
                File.Delete(nombre_de_datos);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //*************************************************************************
        // limpiarDirectorioDeDatos
        //*************************************************************************

        /// <summary>
        /// Funcion para limpiar el archivo repositorio de los datos 
        /// </summary>
        /// <returns>True si fue eliminado correctamente, False en caso contrario</returns>
        public bool limpiarDirectorioRepositorioDeDatos()
        {
            try
            {
                DirectoryInfo directorios_de_datos = new DirectoryInfo(this.ruta_carpeta_archivos);
                FileInfo[] archivos_en_directorio = directorios_de_datos.GetFiles("*");
                for (int i = 0; i < archivos_en_directorio.Length; i++)
                {
                    File.Delete(this.ruta_carpeta_archivos+"\\"+archivos_en_directorio[i]+"");    
                }
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }// Fin Manejador de datos


    //-----------------------------------------------------------------------------------------------
    // ManejadorDeDatosBaseDeDatos
    //-----------------------------------------------------------------------------------------------
    /// <summary>
    /// Clase encargada de la gestion de datos con la base de datos
    /// </summary>
    public class ManejadorDeDatosBaseDeDatos
    {

        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        // sql
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        /// <summary>
        /// objeto que gestiona las consultas a la base de datos
        /// </summary>
        public ConsultasMBCIFPostgre sql = new ConsultasMBCIFPostgre();

        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        // bdd_conectada
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        /// <summary>
        /// La base de datos esta conectada
        /// </summary>
        public bool bdd_conectada
        {
            get
            {
                return sql.conectado;
            }
        }

        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        // manejador_de_archivos
        //-*-*-*-*-*-*-*-*-*-*-*-*-*-
        /// <summary>
        /// objeto manejador de los achivos correspondientes a la MBCIF
        /// </summary>
        public ManejadorDeDatosArchivos manejador_de_archivos = null;
        

        //*************************************************************************
        //Constructor
        //*************************************************************************

        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public ManejadorDeDatosBaseDeDatos( ManejadorDeDatosArchivos manejador_de_archivos )
        {
            this.manejador_de_archivos = manejador_de_archivos;
            sql.conectar();
        }

        //*************************************************************************
        //Constructor
        //*************************************************************************

        /// <summary>
        /// Función para iniciar y conectar la base de datos
        /// </summary>
        /// <param name="server">ip del servidor</param>
        /// <param name="user">usuario de la base de datos</param>
        /// <param name="port">puerto de comunicacion de la base de datos</param>
        /// <param name="password">contraseña del usuario de la base de datos</param>
        /// <param name="database">nombre de la base de datos a trabajar</param>
        public ManejadorDeDatosBaseDeDatos(ManejadorDeDatosArchivos manejador_de_archivos, string server, string user, string port, string password, string database)
        {
            this.manejador_de_archivos = manejador_de_archivos;
            sql = new ConsultasMBCIFPostgre(server, user, port, password, database);
            sql.conectar();
        }

        //*************************************************************************
        // almacenarEnArchivoDeTextoNuevoEstadoDeLosNodos
        //*************************************************************************
        /// <summary>
        /// Método para ingresar un nuevo estado de todos los nodos a la base de datos
        /// </summary>
        /// <returns>True si el procedimiento es exitoso, false en caso contrario</returns>
        public bool almacenarEnBaseDatosNuevoEstadoDeLosNodos()
        {
            string[] lista_de_archivos = manejador_de_archivos.listarArchivosEnDirectorio(ManejadorDeDatosArchivos.NODOS);

            string nueva_id_tuplas = sql.nuevaIdTuplasDatos();

            ArrayList info_nodos = new ArrayList();

            for (int i = 0; i < lista_de_archivos.Length; i++)
            {
                ArrayList info_nodo_actual = new ArrayList();
                Nodo nodo_actual = manejador_de_archivos.extraerNodo(lista_de_archivos[i]);

                info_nodo_actual.Add("" + nodo_actual.id_nodo);

                Dato[] datos_salida_nodo = nodo_actual.extraerVariablesDeSalidaNodo();

                for (int j = 0; j < datos_salida_nodo.Length; j++)
                    info_nodo_actual.Add(datos_salida_nodo[j].id + ":" + datos_salida_nodo[j].valor);
                info_nodo_actual.Add("peso:" + nodo_actual.peso);
                info_nodos.Add(info_nodo_actual);
            }

            return sql.ingresarEstadoNodosALaBaseDeDatos(nueva_id_tuplas, info_nodos);
        }



        //*************************************************************************
        // inicializarBaseDeDatos
        //*************************************************************************

        /// <summary>
        /// Método para inicializar la base de datos desde cero
        /// </summary>
        /// <returns>True si el procedimiento es exitoso, False en caso contrario</returns>
        public bool inicializarBaseDeDatos()
        {
            if (!sql.inicializarBaseDeDatos())
                return false;
            string[] lista_de_archivos = manejador_de_archivos.listarArchivosEnDirectorio(ManejadorDeDatosArchivos.NODOS);
            for (int i = 0; i < lista_de_archivos.Length; i++)
            {
                Nodo nodo_actual = manejador_de_archivos.extraerNodo(lista_de_archivos[i]);
                Dato[] datos_salida_nodo = nodo_actual.extraerVariablesDeSalidaNodo();
                string[] nombre_salidas = new string[datos_salida_nodo.Length];
                for (int j = 0; j < datos_salida_nodo.Length; j++)
                {
                    nombre_salidas[j] = datos_salida_nodo[j].id;
                }
                   
                if (!sql.ingresarNuevoNodoALaBaseDeDatos(nodo_actual.id_nodo, nombre_salidas))
                    return false;
            }
            return true;
        }



    }// Fin Manejador de datos bdd
}
