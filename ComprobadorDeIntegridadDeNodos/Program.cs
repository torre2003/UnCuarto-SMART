using AccesoADatos;
using ModeloMBCIF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace ComprobadorDeIntegridadDeNodos
{
    class Program
    {
        static void Main(string[] args)
        {
            ManejadorDeDatosArchivos manejador_de_archivos = new ManejadorDeDatosArchivos();
            //Listar nodos 
            
            string[] lista_de_influencias = manejador_de_archivos.listarArchivosEnDirectorio(ManejadorDeDatosArchivos.INFLUENCIAS);
            string[] lista_de_sistemas = manejador_de_archivos.listarArchivosEnDirectorio(ManejadorDeDatosArchivos.SISTEMAS);


            //-------------------------------------
           /*
            Console.WriteLine("Desea comprobar paso a paso (y/n)");
            char opcion = Console.ReadKey().KeyChar;
            bool paso = false;
            if (opcion.Equals('y'))
                paso = true;
            */ 
            //--------------------------------------


            Program comprobador = new Program();
            comprobador.comprobarNodos(manejador_de_archivos, false);
            comprobador.comprobarTodasLasInfluencias(manejador_de_archivos);
        }


        public void comprobarNodos(ManejadorDeDatosArchivos manejador_de_archivos, bool paso)
        {
            Console.WriteLine("**************************************************");
            Console.WriteLine("**************************************************");
            Console.WriteLine("Iniciando comprobacion de nodos");
            Console.WriteLine("**************************************************");
            Console.WriteLine("**************************************************");
            Console.ReadKey();
            Console.Clear();
            
            string[] lista_de_nodos = manejador_de_archivos.listarArchivosEnDirectorio(ManejadorDeDatosArchivos.NODOS);
            
            for (int i = 0; i < lista_de_nodos.Length ; i++)
            {
                bool flag = true;
                Nodo nodo_actual = manejador_de_archivos.extraerNodo(lista_de_nodos[i]);
                Console.WriteLine("Nodo");
                Console.WriteLine("ID: "+nodo_actual.id_nodo);
                Console.WriteLine("Nombre: "+nodo_actual.nombre);
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine("Datos nodos externos");
                string[] datos_nodos_externos = nodo_actual.listarVariables(Nodo.DATOS_NODOS_EXTERNOS);
                for (int j = 0; j < datos_nodos_externos.Length; j++)
			    {
                    string ruta_archivo = manejador_de_archivos.ruta_carpeta_archivos + datos_nodos_externos[j];
                    bool existe = File.Exists(ruta_archivo);
                    if (!existe)
                        flag = false;
                    Console.WriteLine(datos_nodos_externos[j]+" : "+existe);
			    }

                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine("nodos influenciados");
                string[] nodos_influenciados = nodo_actual.listarVariables(Nodo.NODOS_INFLUENCIADOS);
                for (int j = 0; j < nodos_influenciados.Length; j++)
                {
                    string ruta_archivo = manejador_de_archivos.ruta_carpeta_archivos + nodos_influenciados[j];
                    bool existe = File.Exists(ruta_archivo);
                    if (!existe)
                        flag = false;
                    Console.WriteLine(nodos_influenciados[j] + " : " + existe);
                }

                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine("Influencias externas");
                string[] influencias_externas = nodo_actual.listarVariables(Nodo.INFLUENCIAS_EXTERNAS);
                for (int j = 0; j < influencias_externas.Length; j++)
                {
                    
                    string ruta_archivo = manejador_de_archivos.ruta_carpeta_archivos + influencias_externas[j];
                    bool existe = File.Exists(ruta_archivo);
                    if (!existe)
                        flag = false;

                    string nodo_influenciante = influencias_externas[j].Split('_')[2];
                    ruta_archivo = manejador_de_archivos.ruta_carpeta_archivos + nodo_influenciante;
                    bool existe2 = File.Exists(ruta_archivo);
                    if (!existe2)
                        flag = false;

                    Console.WriteLine(influencias_externas[j] +" : "+existe+ "  ->  " + nodo_influenciante +" : " +existe2);
                }

                Console.WriteLine("");
                Console.WriteLine("**************************************************");
                if(flag)
                    Console.WriteLine("Nodo correcto");
                else
                    Console.WriteLine("ERROR en nodo");
                Console.WriteLine("**************************************************");
                Console.ReadKey();
                Console.Clear();

                for (int j = 0; j < influencias_externas.Length; j++)
                {
                    comprobarInfluencia(manejador_de_archivos, influencias_externas[j], nodo_actual.id_nodo);
                    Console.ReadKey();
                    Console.Clear();

                }

            }
        }


        public void comprobarInfluencia(ManejadorDeDatosArchivos manejador_de_archivos, string id_influencia, string en_nodo = null)
        {
            bool flag = true;
            
            Influencia influencia = manejador_de_archivos.extraerInfluencia(id_influencia);
            if (influencia == null)
            {
                Console.WriteLine("**************************************************");
                Console.WriteLine("ERROR Influencia NO EXISTE");
                Console.WriteLine("**************************************************");
                return;
            }
            bool existe_influencia, existe_nodo_origen, existe_nodo_destino;
            bool concuerda_nodo_origen, concuerda_nodo_destino;
            
            string ruta_archivo = manejador_de_archivos.ruta_carpeta_archivos + id_influencia;
            existe_influencia = File.Exists(ruta_archivo);

            if (influencia.id_nodo_origen.Equals(""+id_influencia.Split('_')[1]))
                concuerda_nodo_origen = true;
            else
                concuerda_nodo_origen = false;

            if (influencia.id_nodo_influenciado.Equals(""+id_influencia.Split('_')[2]))
                concuerda_nodo_destino = true;
            else
                concuerda_nodo_destino = false;

            ruta_archivo = manejador_de_archivos.ruta_carpeta_archivos + influencia.id_nodo_origen;
            existe_nodo_origen = File.Exists(ruta_archivo);

            ruta_archivo = manejador_de_archivos.ruta_carpeta_archivos + influencia.id_nodo_influenciado;
            existe_nodo_destino = File.Exists(ruta_archivo);
            
            if (en_nodo != null)
                Console.WriteLine("Nodo     " + en_nodo);
            Console.WriteLine(id_influencia+" ");
            Console.WriteLine("Existe influencia : "+existe_influencia);
            Console.WriteLine("Concuerda nodo origen : "+concuerda_nodo_origen);
            Console.WriteLine("Concuerda nodo destino : "+concuerda_nodo_destino);
            Console.WriteLine("Existe nodo origen : "+existe_nodo_origen);
            Console.WriteLine("Existe nodo destino : "+existe_nodo_destino);

            if (!existe_influencia || !existe_nodo_origen || !existe_nodo_destino || !concuerda_nodo_origen || !concuerda_nodo_destino)
                flag = false;


            Console.WriteLine("**************************************************");
            if (flag)
                Console.WriteLine("influencia correcto");
            else
                Console.WriteLine("ERROR en influencia");
            Console.WriteLine("**************************************************");
            
        }

        public void comprobarTodasLasInfluencias(ManejadorDeDatosArchivos manejador_de_archivos)
        {
            Console.WriteLine("**************************************************");
            Console.WriteLine("**************************************************");
            Console.WriteLine("Comprobando Influencias independientemente");
            Console.WriteLine("**************************************************");
            Console.WriteLine("**************************************************");
            Console.ReadKey();
            Console.Clear();
            string[] lista_de_influencias = manejador_de_archivos.listarArchivosEnDirectorio(ManejadorDeDatosArchivos.INFLUENCIAS);
            for (int i = 0; i < lista_de_influencias.Length; i++)
            {
                comprobarInfluencia(manejador_de_archivos, lista_de_influencias[i]);
                Console.ReadKey();
                Console.Clear();
            }
        }

    }
}
