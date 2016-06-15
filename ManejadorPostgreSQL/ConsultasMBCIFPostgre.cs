using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejadorPostgreSQL
{
    /// <summary>
    /// Clase que contiene las consultas necesarias para tabajar con MBCIF
    /// </summary>
    public class ConsultasMBCIFPostgre
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
        public ConsultasMBCIFPostgre()
        {
            bdd_sql = new PostgreSQL();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="server">ip del servidor</param>
        public ConsultasMBCIFPostgre(string server)
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
        public ConsultasMBCIFPostgre(string server, string user, string port, string password, string database)
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
        /// Método para ingresar un nuevo estado los nodos a la base de datos
        /// </summary>
        /// <param name="id_tuplas"> Id de las tuplas con ques e ingresara la información </param>
        /// <param name="info_nodos"> ArrayList de ArrayList con la información de la id nodo en el primer elemento ("id") y los campos de esos nodos ("nombre:valor") </param>
        /// <returns>True si el procedimiento fue ejecutado correctamente </returns>
        public bool ingresarEstadoNodosALaBaseDeDatos(string id_tuplas, ArrayList info_nodos)
        {
            StringBuilder repositorio_consultas = new StringBuilder();
            repositorio_consultas.AppendLine("BEGIN; ");

            repositorio_consultas.AppendLine("INSERT INTO activacion (id_tupla ,  grado_de_activacion , id_activacion )VALUES ('" + id_tuplas + "' , 1 , '0' );");

            foreach (var item_nodo in info_nodos)
	        {
                ArrayList info_nodo = (ArrayList) item_nodo;
                string consulta_actual ="";
                string nombres = "( id ";
                string valores = "( " + id_tuplas;
                int i = 0;
                foreach (var info in info_nodo)
	            {
		            if (i == 0)
                        consulta_actual = "INSERT INTO "+info ;
                    else
                    {
                        string dato_campo = (string)info;
                        nombres += " , ";
                        valores += " , ";
                        nombres += dato_campo.Split(':')[0];
                        valores += dato_campo.Split(':')[1].Replace(',','.');
                    }
                    i++;
	            }
                nombres += ") ";
                valores += ") ";

                consulta_actual += nombres + " VALUES " + valores + ";";
                repositorio_consultas.AppendLine(consulta_actual);
	        }
            
            repositorio_consultas.AppendLine("COMMIT;");
            
            return bdd_sql.consultaUpdate(repositorio_consultas.ToString());
        }








        /// <summary>
        /// Funcion para encontrar una nueva id para las tuplas
        /// </summary>
        /// <returns>String con la nueva id para las tuplas </returns>
        public string nuevaIdTuplasDatos()
        {
            string consulta = "select max(id_tupla)+1 as nueva_id from activacion;";
            string nueva_id = null;
            if (!bdd_sql.conectado)
                return null;
            using (NpgsqlDataReader data = bdd_sql.consultaSelectDataReader(consulta))
            {
                if (data != null && data.HasRows)
                {
                    data.Read();
                    nueva_id =  "" + data["nueva_id"];
                    if (nueva_id.Equals(""))
                        nueva_id = "1";
                }
                data.Close();
            }
            return nueva_id;
        }

        /// <summary>
        /// Método qe incializa la base de datos 
        /// Elimina todo posible información anterior
        /// crea las tablas fundamentales de la base de datos (activacion, detalle_tablas), además de las funciones necesarias para trabajar en ella (insertar_activación, limpiar_activaciones, minimo)
        /// </summary>
        /// <returns></returns>
        public bool inicializarBaseDeDatos()
        {
            string consulta =
                // Eliminación de esquema (lo que conlleva eliminación de datos, tablas y funciones)
                " DROP SCHEMA IF EXISTS public CASCADE;" +
                
                // Creacion del nuevo esquema para la base de  datos
                " CREATE SCHEMA public;" +
                
                //Tabla detalle_tablas
                " CREATE TABLE public.detalle_tablas" +
                " (" +
                " nombre_tabla text," +
                " nombre_columna text" +
                " );" +
                
                //Tabla activacion
                " CREATE TABLE public.activacion" +
                " (" +
                " id_tupla bigint," +
                " grado_de_activacion double precision," +
                " id_activacion text" +
                " ); "+

                //Función insertar_activacion
                " CREATE OR REPLACE FUNCTION public.insertar_activacion("+
                " text,"+
                " bigint,"+
                " double precision,"+
                " double precision,"+
                " numeric)"+
                " RETURNS void AS"+
                " $BODY$"+			
                " DECLARE"+ 						
						
                " id_nueva_activacion ALIAS FOR $1;"+
                " id_tupla_actual ALIAS FOR $2;" +
                " grado_de_activacion ALIAS FOR $3;"+			
                " pertenencia_estado_atributo ALIAS FOR $4;"+		
                " umbral ALIAS FOR $5;"	+
                " nuevo_grado_de_activacion double precision;"	+				
						
                " BEGIN"	+
						
                " nuevo_grado_de_activacion := minimo(pertenencia_estado_atributo,grado_de_activacion );"+
						
						
                " IF nuevo_grado_de_activacion < umbral  THEN"+
                " nuevo_grado_de_activacion :=  0;"+
                " END IF;"+
 					
	            "insert into activacion (id_activacion , id_tupla, grado_de_activacion )values (id_nueva_activacion , id_tupla_actual , nuevo_grado_de_activacion);"+								
                
						
                " END;"+
                " $BODY$"+
                " LANGUAGE plpgsql VOLATILE" +
                " COST 100;"+

                //Función limpiar_activaciones

                " CREATE OR REPLACE FUNCTION public.limpiar_activaciones()"+
                " RETURNS void AS"+
                " $BODY$"	+
                " DECLARE" 	+			
                " BEGIN"	+	
                " DELETE FROM activacion WHERE id_activacion <> '0';"+
				
                " END;"+
                " $BODY$"+
                " LANGUAGE plpgsql VOLATILE"+
                " COST 100;"+

                //Función minimo

                " CREATE OR REPLACE FUNCTION public.minimo("+
                " double precision,"+
                " double precision)"+
                " RETURNS double precision AS"+
                " $BODY$"+		
                " DECLARE"+					
                " valor1 ALIAS FOR $1;"+
                " valor2 ALIAS FOR $2;"+				
					
                " BEGIN "+
                " RETURN CASE WHEN valor1<=valor2 THEN valor1"+
                " ELSE valor2 END; "+
                " END;"+	
                " $BODY$"+
                " LANGUAGE plpgsql VOLATILE"+
                " COST 100;"+

                " CREATE OR REPLACE FUNCTION public.posibilidad_hoja("+
                "   text,"+
                "    text,"+
                "    text)"+
                "  RETURNS double precision AS"+
                " $BODY$"+
                " DECLARE "+

                " id_activacion_actual  ALIAS FOR $1;   "+
                " atributo ALIAS FOR $2;  "+
                " estado_del_atributo  ALIAS FOR $3;   "+

                " consulta TEXT; "+
                " query text; "+
                " resultado_consulta RECORD;" +
                " total_tuplas double precision;"+
                " tuplas_estado_atributo double precision;"+

                " BEGIN "+
                " total_tuplas :=0; "+
                " tuplas_estado_atributo :=0; "+

                " query := 'SELECT ' || atributo || '.' || estado_del_atributo || ' as estado, grado_de_activacion from ' || atributo || ' INNER JOIN activacion on ' || atributo || '.id = activacion.id_tupla WHERE activacion.id_activacion = ''' || id_activacion_actual || '''';"+

                " FOR resultado_consulta IN EXECUTE(query) "+
                " LOOP "+
                "  IF resultado_consulta.grado_de_activacion > 0  THEN "+
                "     total_tuplas := total_tuplas +1; "+
                "     IF resultado_consulta.estado > 0  THEN "+
                " tuplas_estado_atributo := tuplas_estado_atributo +1; "+
                "     END IF; "+
                " END IF; "+
                " END LOOP; "+

                " IF total_tuplas = 0  THEN " +
                "     RETURN 0; " +
                "     END IF; "+
                " RETURN tuplas_estado_atributo/total_tuplas; "+
                " END; " +
                " $BODY$ " +
                "  LANGUAGE  plpgsql VOLATILE " +
                "  COST 100; " +
                " ALTER FUNCTION public.posibilidad_hoja(text, text, text) " +
                "  OWNER TO mbcif; ";
                ;

            return bdd_sql.consultaUpdate(consulta);

        }


        /// <summary>
        /// Método para ingresar un nuevo nodo a la base de datos
        /// </summary>
        /// <param name="id_nodo">id del nodo a ingresar</param>
        /// <param name="campos_de_salida_nodo">arreglo con los nombres de los campos de salida de los nodos</param>
        /// <returns>true si la ejecución fue exitosa, false en caso contrario</returns>
        public bool ingresarNuevoNodoALaBaseDeDatos(string id_nodo, string[] campos_de_salida_nodo)
        {
            string consulta_creacion_tabla = "CREATE TABLE public." + id_nodo +
                              "( id bigint NOT NULL";
            for (int i = 0; i < campos_de_salida_nodo.Length; i++)
            {
                //if (i != 0)
                consulta_creacion_tabla += ",";
                consulta_creacion_tabla += campos_de_salida_nodo[i] + " double precision ";
            }
            consulta_creacion_tabla += ", peso double precision";
            consulta_creacion_tabla += " ) " +
                       " WITH ( " +
                       " OIDS=FALSE " +
                       " ); ";
            
            string consulta_insercion_detalle_tabla = "       ";
            
            for (int i = 0; i < campos_de_salida_nodo.Length; i++)
                consulta_insercion_detalle_tabla += "INSERT INTO detalle_tablas ( nombre_tabla , nombre_columna ) VALUES ( '"+id_nodo+"' , '"+campos_de_salida_nodo[i]+"' );";

            if (bdd_sql.consultaUpdate(consulta_creacion_tabla))
            {
                return bdd_sql.consultaUpdate(consulta_insercion_detalle_tabla);
            }
            else
            {
                return false;
            }
        }


    }// Fin consultaMBCIFPostgre

}
