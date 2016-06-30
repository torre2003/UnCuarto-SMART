using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorPostgreSQL
{
    /// <summary>
    /// Clase para realizar la conexion y las consultas a la base de datos
    /// </summary>
    public class PostgreSQL
    {
        /// <summary>
        /// ip del servidor
        /// </summary>
        string server   = "localhost";

        /// <summary>
        /// nombre de usuario de la base de datos
        /// </summary>
        string user     = "mbcif";

        /// <summary>
        /// puerto de conexion con la base de datos
        /// </summary>
        string port     = "5432";

        /// <summary>
        /// contraseña del usuario de la base de datos
        /// </summary>
        string password = "mbcif";

        /// <summary>
        /// nombre de la base de datos a trabajar
        /// </summary>
        string database = "MBCIF";

        NpgsqlConnection conexionBdd = null;
        public bool conectado = false;

        /// <summary>
        ///  Constructor 
        /// </summary>
        public PostgreSQL()
        {

        }
        
        /// <summary>
        ///  Constructor 
        /// </summary>
        /// <param name="server">ip del servidor</param>
        public PostgreSQL(string server)
        {
            this.server = server;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="server">ip del servidor</param>
        /// <param name="user">usuario de la base de datos</param>
        /// <param name="port">puerto de comunicacion de la base de datos</param>
        /// <param name="password">contraseña del usuario de la base de datos</param>
        /// <param name="database">nombre de la base de datos a trabajar</param>
        public PostgreSQL(string server,string user,string port,string password,string database)
        {
            this.server = server;
            this.user = user;
            this.port = port;
            this.password = password;
            this.database = database;
        }

        /// <summary>
        /// Funcion para realizar la conexion a la base de datos
        /// </summary>
        /// <returns>true si es exitosa la conexion false en caso contrario</returns>
        public bool conectar()
        {
            try
            {
                string info_conexion = String.Format("Server={0};Port={1};" +
                    "User Id={2};Password={3};Database={4};",
                    server, port, user,
                    password, database);
                conexionBdd = new NpgsqlConnection(info_conexion);
                conexionBdd.Open();
                conectado = true;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Funcion para realizar consultas de tipo SELECT a la base de datos 
        /// </summary>
        /// <param name="consulta">Consulta realizar</param>
        /// <returns>NpgsqlDataAdapter para leer los resultados de la consulta</returns>
        public NpgsqlDataAdapter consultaSelectDataAdapter(string consulta)
        {
            if (conectado)
            {
                try
                {
                    NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(consulta, conexionBdd);
                    return dataAdapter;
                }
                catch (Exception)
                {
                    conectado = false;
                }
            }
            return null;
        }

        /// <summary>
        /// Funcion para realizar consultas de tipo SELECT a la base de datos 
        /// </summary>
        /// <param name="consulta">Consulta a realizar</param>
        /// <returns>NpgsqlDataReader para leer los resultados de la consulta</returns>
        public NpgsqlDataReader consultaSelectDataReader(string consulta)
        {
            if (conectado)
            {
                try
                {
                    NpgsqlCommand commandos = new NpgsqlCommand(consulta, conexionBdd);
                    return commandos.ExecuteReader();
                }
                catch (Exception)
                {
                    conectado = false;
                }
            }
            return null;
        }

        /// <summary>
        /// Funcion para realizar consultas UPDATE o que no retornen valores a la base de datos 
        /// </summary>
        /// <param name="consulta">Consultas a realizar</param>
        /// <returns>true si la consulta fue exitosa, false en caso contrario</returns>
        public bool consultaUpdate(string consulta)
        {
            if (conectado)
            {
                try
                {
                    NpgsqlCommand commandos = new NpgsqlCommand(consulta, conexionBdd);
                    commandos.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    conectado = false;
                    return false;
                }
            }
            return false;
        }


    }
}





