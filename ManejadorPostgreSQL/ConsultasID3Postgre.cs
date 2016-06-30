using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorPostgreSQL
{
    /// <summary>
    /// Clase que contiene las consultas necesarias para tabajar con ID3 difuso
    /// </summary>
    public class ConsultasID3Postgre
    {
        /// <summary>
        /// Objeto para realizar la gestion de la base de datos
        /// </summary>
        PostgreSQL bdd_sql;

        /// <summary>
        /// atributo para saber si la base de datos esta conectada al servidor
        /// </summary>
        public bool conectado
        {
            get
            {
                return bdd_sql.conectado;
            }
        }
        
        /// <summary>
        /// Constructor
        /// </summary>
        public ConsultasID3Postgre()
        {
            bdd_sql = new PostgreSQL();
        }
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="server">ip del servidor</param>
        public ConsultasID3Postgre(string server)
        {
            bdd_sql = new PostgreSQL(server);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="server">ip del servidor</param>
        /// <param name="user">usuario de la base de datos</param>
        /// <param name="port">puerto de comunicacion de la base de datos</param>
        /// <param name="password">contraseña del usuario de la base de datos</param>
        /// <param name="database">nombre de la base de datos a trabajar</param>
        public ConsultasID3Postgre(string server, string user, string port, string password, string database)
        {
            bdd_sql = new PostgreSQL(server, user, port, password, database);
        }

        /// <summary>
        /// Funcion para realizar la conexion a la base de datos
        /// </summary>
        /// <returns>true si es exitosa la conexion false en caso contrario</returns>
        public bool conectar()
        {
            return bdd_sql.conectar();
        }

        /// <summary>
        /// Función para listar las columnas correspondientes a una tabla, tablas = atributo , columnas = estados del atributo
        /// </summary>
        /// <param name="nombre_tabla"></param>
        /// <returns>Arreglo con los nombres de la columna</returns>
        public string[] listarColumnasTabla(string nombre_tabla)
        {
            string datos = null;
            string[] retorno = null;
            string consulta = "SELECT * FROM detalle_tablas WHERE nombre_tabla = '"+nombre_tabla.ToLower()+"'";
            
            if (!bdd_sql.conectado)
                return null;
            using (NpgsqlDataReader data = bdd_sql.consultaSelectDataReader(consulta))
            {
                if (data != null && data.HasRows)
                {
                    data.Read();
                    datos = "" + data["nombre_columna"];
                    while (data.Read())
                    {
                        datos += ";" + data["nombre_columna"];
                    }
                }
                data.Close();
            }
            if (datos != null)
                retorno = datos.Split(';');
            return retorno;
        }

        /// <summary>
        /// Funcion para obtener la lista de todas las tablas excepto la que corresponde al clasificador
        /// </summary>
        /// <param name="clasificador"></param>
        /// <returns>UN arreglo de string con la lista de tablas</returns>
        public string[] listarTablasSinClasificador(string clasificador)
        {
            string datos = null;
            string[] retorno = null;
            string consulta = "SELECT nombre_tabla FROM detalle_tablas WHERE nombre_tabla <> '"+clasificador+"' GROUP BY detalle_tablas.nombre_tabla";

            if (!bdd_sql.conectado)
                return null;
            using (NpgsqlDataReader data = bdd_sql.consultaSelectDataReader(consulta))
            {
                if (data != null && data.HasRows)
                {
                    data.Read();
                    datos = "" + data["nombre_tabla"];
                    while (data.Read())
                    {
                        datos += ";" + data["nombre_tabla"];
                    }
                }
                data.Close();
            }
            if (datos != null)
                retorno = datos.Split(';');
            return retorno;
        }


        /// <summary>
        /// Funcion para obtener el numerador de la probabilidad pc de la columnas indicada
        /// </summary>
        /// <param name="nombre_columna">nombre de la columna a trabajar (Estado del atributo)</param>
        /// <param name="nombre_tabla">nombre de la tabla a trabajar (Atributo)</param>
        /// <param name="activacion">id de la activacion a trabajar</param>
        /// <returns>valor con el numerador de pc</returns>
        public double obtenerNumeradorPcColumna(string nombre_columna, string nombre_tabla, string activacion)
        {
            double pc = -666;
            string consulta = "SELECT  sum(Minimo(grado_de_activacion,"+nombre_tabla.ToLower()+".\""+nombre_columna.ToLower()+"\")) as suma " +
                              "FROM (select * from activacion where id_activacion = '"+activacion+"') as activadores " +
                              "INNER JOIN " + nombre_tabla.ToLower() + " ON activadores.id_tupla = " + nombre_tabla.ToLower() + ".id;";
            if (!bdd_sql.conectado)
                return -666;
            using (NpgsqlDataReader data = bdd_sql.consultaSelectDataReader(consulta))
            {
                if (data != null && data.HasRows)
                {
                    data.Read();
                    pc = double.Parse(""+data["suma"]);
                    
                }
                data.Close();
            }
            return pc;
        }

        /// <summary>
        /// Funcion para obtener el numerador de la probabilidad pac de la columna indicada
        /// </summary>
        /// <param name="atributo">Atributo a trabajar (nombre tabla)</param>
        /// <param name="estado_atributo">estado del atributo a trabajar (nombre columna)</param>
        /// <param name="clasificador">nombre del atributo clasificador (nombre tabla)</param>
        /// <param name="estado_clasificador">nombre del estado del atributo clasificador (nombre columna)</param>
        /// <param name="activacion">id de la activacion a trabajar</param>
        /// <returns>valor con el numerador pac correspondiente</returns>
        public double obtenerNumeradorPacColumna(string atributo, string estado_atributo, string clasificador, string estado_clasificador, string activacion)
        {
            double pac = -666;
            string consulta =
            " SELECT  " +
            " sum(" +
            " Minimo ("+atributo.ToLower()+".\""+estado_atributo.ToLower()+"\",Minimo(grado_de_activacion,"+clasificador.ToLower()+".\""+estado_clasificador.ToLower()+"\"))" +
            " ) AS suma " +
            " FROM (select * from activacion where id_activacion = '"+activacion+"') as activadores " +
            " INNER JOIN " + clasificador.ToLower() + " ON activadores.id_tupla = " + clasificador.ToLower() + ".id " +
            " INNER JOIN " + atributo.ToLower() + " ON " + atributo.ToLower() + ".id = activadores.id_tupla   ;";
            if (!bdd_sql.conectado)
                return -666;
            using (NpgsqlDataReader data = bdd_sql.consultaSelectDataReader(consulta))
            {
                if (data != null && data.HasRows)
                {
                    data.Read();
                    pac = double.Parse("" + data["suma"]);

                }
                data.Close();
            }
            return pac;
        }

        /// <summary>
        /// Funcion para obtener el numerador de la probabilidad pac de la columna indicada
        /// </summary>
        /// <param name="atributo">Atributo a trabajar (nombre tabla)</param></param>
        /// <param name="estado_atributo">estado del atributo a trabajar (nombre columna)</param>
        /// <param name="activacion">id de la activacion a trabajar</param>
        /// <returns>valor con el numerador pa correspondiente</returns>
        public double obtenerNumeradorPaColumna(string atributo, string estado_atributo, string activacion)
        {
            double pa = -666;
            string consulta =
                "SELECT  sum(Minimo ("+atributo.ToLower()+".\""+estado_atributo.ToLower()+"\",grado_de_activacion)) AS suma " +
                "FROM (select * from activacion where id_activacion = '"+activacion+"') as activadores " +
                "INNER JOIN " + atributo.ToLower() + " ON " + atributo.ToLower() + ".id = activadores.id_tupla   ;";
            if (!bdd_sql.conectado)
                return -666;
            using (NpgsqlDataReader data = bdd_sql.consultaSelectDataReader(consulta))
            {
                if (data != null && data.HasRows)
                {
                    data.Read();
                    pa = double.Parse("" + data["suma"]);

                }
                data.Close();
            }
            return pa;
        }

        /// <summary>
        /// Funcion para crea una nueva columna de activacion a trabajar 
        /// </summary>
        /// <param name="id_activacion_antigua">id la activacion con se esta trabajando</param>
        /// <param name="id_nueva_activacion">id con que quedara la nueva columna de activacion</param>
        /// <param name="estado_de_atributo">estado del atributo con que se compara la antigua activacion para crear la nueva (nombre columna)</param>
        /// <param name="atributo">atributo de del estado a trabajar (nombre tabla)</param>
        /// <param name="umbral">umbral de cotejamiento de la nueva activacion</param>
        /// <returns>true si el procedimiento fue exitoso, false en caso contrario</returns>
        public bool crearNuevaActivacion(string id_activacion_antigua,string id_nueva_activacion, string estado_de_atributo,string atributo, double umbral)
        {
            string s_umbral = "" + umbral;
            s_umbral = s_umbral.Replace(',', '.');
            string consulta = "SELECT  " +
            "insertar_activacion ('"+id_nueva_activacion+"',id_tupla,grado_de_activacion,"+atributo.ToLower()+".\""+estado_de_atributo.ToLower()+"\","+s_umbral+")  " +
            "FROM  " +
            "(SELECT * FROM activacion WHERE id_activacion = '"+id_activacion_antigua+"') AS activadores  " +
            "INNER JOIN  " +
            atributo.ToLower()+" ON activadores.id_tupla = "+atributo.ToLower()+".id;";
            return bdd_sql.consultaUpdate(consulta);
        }

        /// <summary>
        /// Funcion para limpiar la tabla de activacion dejando solo la activacion por defecto (id= 0 , valor = 1)
        /// </summary>
        /// <returns>true si el procedimiento fue exitoso, false en caso contrario</returns>
        public bool limpiarActivacion ()
        {

            string consulta = "SELECT limpiar_activaciones();";
            
            return bdd_sql.consultaUpdate(consulta);
        }

        /// <summary>
        /// Metodo que devuelve si un nodo es hoja a través del analisis de los estados del atributo clasificador
        /// </summary>
        /// <param name="id_activacion">id de la activacion actual</param>
        /// <param name="atributo">nombre del atributo clasificador a analizar (nombre_tabla)</param>
        /// <returns>Funcion retorna 1 si el nodo es hoja, 0 en caso contrario y -666 si hubo problemas en el procedimiento</returns>
        public int esNodoHoja(string id_activacion, string atributo)
        {
            string[] estados_del_atributo = listarColumnasTabla(atributo);
            bool flag = false;
            if (estados_del_atributo == null)
                return -666;
            for (int i = 0; i < estados_del_atributo.Length && !flag; i++)
            {
                if (!bdd_sql.conectado)
                    return -666;
                string consulta = "SELECT posibilidad_hoja ('"+id_activacion+"','"+atributo+"','"+estados_del_atributo[i]+"');";
                using (NpgsqlDataReader data = bdd_sql.consultaSelectDataReader(consulta))
                {
                    if (data != null && data.HasRows)
                    {
                        data.Read();
                        double posibilidad_hoja = double.Parse("" + data[0]);
                        if (posibilidad_hoja > 0.000001 && posibilidad_hoja < 0.999999)
                        {
                            flag = true;
                        }
                    }
                    data.Close();
                }
            }
            if (flag)
                return 0;
            return 1;
        }

        /// <summary>
        /// Metodo para ver la posibilidad de un estado del atributo como hoja
        /// </summary>
        /// <param name="id_activacion">id de la activacion actual</param>
        /// <param name="atributo">nombre del atributo clasificador a analizar (nombre_tabla)</param>
        /// <param name="estado_del_atributo">nombre del estado del atributo a analizar (nombre_columna)</param>
        /// <returns>valor de la posibilidad de la hoja y -666 si hubo problemas en el procedimiento</returns>
        public double posibilidadHoja(string id_activacion, string atributo, string estado_del_atributo)
        {
            double posibilidad_hoja;
            bool flag = false;
            if (estado_del_atributo == null)
                return -666;
            if (!bdd_sql.conectado)
                return -666;
            string consulta = "SELECT posibilidad_hoja ('" + id_activacion + "','" + atributo.ToLower() + "','" + estado_del_atributo.ToLower() + "');";
            using (NpgsqlDataReader data = bdd_sql.consultaSelectDataReader(consulta))
            {
                if (data != null && data.HasRows)
                {
                    data.Read();
                    posibilidad_hoja = double.Parse("" + data[0]);
                    
                }
                else
                {
                   posibilidad_hoja = -666; 
                }
                data.Close();
            }
            return posibilidad_hoja;
            
        }


        public int activacionesEnCero(string id_activacion)
        {
            double activacion = 0;
            bool flag = false;
            if (id_activacion == null)
                return -666;
            if (!bdd_sql.conectado)
                return -666;
            string consulta = "select max(grado_de_activacion) from activacion WHERE id_activacion ='"+id_activacion+"';";
            using (NpgsqlDataReader data = bdd_sql.consultaSelectDataReader(consulta))
            {
                if (data != null && data.HasRows)
                {
                    data.Read();
                    activacion = Double.Parse(data[0]+"");
                }
                data.Close();
            }

            if (activacion > 0.00000001)
                return 1;
            return 0;

        }

    }
}
