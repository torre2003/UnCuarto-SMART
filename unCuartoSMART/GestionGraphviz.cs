using AccesoADatos;
using ModeloMBCIF;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unCuartoSMART
{
    class GestionGraphviz

    {
        //*****************************************************************************************************************
        //-----------------------------------------------------------------------------------------------------------------
        //                                           ATRIBUTOS
        //-----------------------------------------------------------------------------------------------------------------
        //*****************************************************************************************************************

        //*******************************
        //   colores
        //*******************************
        string[] colores = {
                               "aquamarine",
                               "goldenrod3",
                               "bisque",
                               "cadetblue1",
                               "chartreuse2",
                               "antiquewhite",
                               "forestgreen",
                               "gold2",
                               "chartreuse",
                               "powderblue",
                               "yellow1",
                               "palegreen1",
                               "darkslategrey"
                           };

        //*******************************
        //   colores nodos
        //*******************************
        string[] colores_nodos = {
                               "red",
                               "orange",
                               "yellow",
                               "yellowgreen",
                               "green"
                           };

        //*******************************
        //   colores influencias
        //*******************************
        string[] colores_influencias = {
                               "red",
                               "black",
                               "green3"
                           };


        public string nodo_marcado
        {
            get
            {
                return _nodo_marcado;
            }
            set
            {
                _nodo_marcado = value;
            }
        }

        string _nodo_marcado = "";


        //*****************************************************************************************************************
        //-----------------------------------------------------------------------------------------------------------------
        //                                           METODOS
        //-----------------------------------------------------------------------------------------------------------------
        //*****************************************************************************************************************

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //   Constructor
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        public GestionGraphviz() { }
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //   Constructor
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        public GestionGraphviz(string nodo_marcado)
        {
            this.nodo_marcado = nodo_marcado;
        }
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //   limpiarNodoMarcado
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        public void limpiarNodoMarcado()
        {
            nodo_marcado = "";
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //   generar codigo MBCIF
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        
        public StringBuilder generarCodigoMBCIF(string path_carpeta_matrices)
        {
            ManejadorDeDatosArchivos manejador_de_datos = new ManejadorDeDatosArchivos(path_carpeta_matrices);
            string[] sistemas       = manejador_de_datos.listarArchivosEnDirectorio(ManejadorDeDatosArchivos.SISTEMAS);
            string[] nodos          = manejador_de_datos.listarArchivosEnDirectorio(ManejadorDeDatosArchivos.NODOS);
            

            StringBuilder texto_graphviz = new StringBuilder();
            texto_graphviz.AppendLine("digraph G {");//inicio digraph

            //Sistemas creacion de nodo
            texto_graphviz.AppendLine("{");
            texto_graphviz.AppendLine("node [sides=7 margin=0 fontcolor=black fontsize=13  shape=polygon style=\"filled,rounded\"  fillcolor=khaki3 ]");
            for (int i = 0; i < sistemas.Length; i++)
                texto_graphviz.AppendLine(""+sistemas[i]);
            texto_graphviz.AppendLine("}");

            //Nodos creacion de nodo
            texto_graphviz.AppendLine("{");
            texto_graphviz.AppendLine("node [margin=0 fontcolor=black fontsize=13  shape=box style=\"filled,rounded\"  fillcolor=lightskyblue ]");
            for (int i = 0; i < nodos.Length; i++)
                texto_graphviz.AppendLine("" + nodos[i]);
            texto_graphviz.AppendLine("}");


            //Completando nodos
            for (int i = 0; i < nodos.Length; i++)
            {
                bool flag_nodo_marcado = false;
                Nodo nodo_actual = manejador_de_datos.extraerNodo(nodos[i]);
                if (nodo_marcado != "" && nodo_actual.id_nodo.Equals(nodo_marcado))
                    flag_nodo_marcado = true;
                if (flag_nodo_marcado)
                    texto_graphviz.AppendLine(nodo_actual.id_nodo + " [ label=\"" + nodo_actual.id_nodo + "\\n" + nodo_actual.nombre + "\" shape=tripleoctagon  ]");
                else
                    texto_graphviz.AppendLine(nodo_actual.id_nodo + " [ label=\"" + nodo_actual.id_nodo + "\\n" + nodo_actual.nombre + "\" ]");
                texto_graphviz.AppendLine(nodo_actual.id_nodo + "[fillcolor=" + retornarColorNodo(nodo_actual.peso) + "]");

                //Graficando conexiones influencias 
                string[] influencias = nodo_actual.listarVariables(Nodo.NODOS_INFLUENCIADOS);
                for (int j = 0; j < influencias.Length; j++)
                {
                    /*
                    string id_influencia_actual = "i_" + nodo_actual.id_nodo + "_" + influencias[j];
                    Influencia influencia_actual = manejador_de_datos.extraerInfluencia(id_influencia_actual);
                    string color = "green";
                    if (influencia_actual.tipo_de_influencia == Influencia.INFLUENCIA_NEGATIVA)
                        color = "red";
                    texto_graphviz.AppendLine(nodo_actual.id_nodo + " -> " + influencias[j] + "[color=" + color + " ]");
                     */
                    string id_influencia_actual = "i_" + nodo_actual.id_nodo + "_" + influencias[j];
                    Influencia influencia_actual = manejador_de_datos.extraerInfluencia(id_influencia_actual);
                    string color = retornarColorInfluencia(influencia_actual.peso_influencia);
                    if (flag_nodo_marcado)
                        texto_graphviz.AppendLine(nodo_actual.id_nodo + " -> " + influencias[j] + "[color= \"" + color+":"+color + "\" arrowhead=\"box\"]");//Flechas influencias
                    else
                        texto_graphviz.AppendLine(nodo_actual.id_nodo + " -> " + influencias[j] + "[color=" + color + " ]");//Flechas influencias
                }//End for influencias

                //Graficando conexiones nodos externos
                string[] nodos_externos = nodo_actual.listarVariables(Nodo.DATOS_NODOS_EXTERNOS);
                for (int j = 0; j < nodos_externos.Length; j++)
                {

                    texto_graphviz.AppendLine( nodos_externos[j] + " -> " + nodo_actual.id_nodo + "[color= \"" + " hotpink " + "\" arrowhead=\"dot\"]");//Flechas influencias
                }

            }

            //Completando sistemas
            for (int i = 0; i < sistemas.Length; i++)
            {
                string color = retornarColor(i);
                Sistema sistema_actual = manejador_de_datos.extraerSistema(sistemas[i]);
                texto_graphviz.AppendLine(sistema_actual.id_sistema+" [label = \""+sistema_actual.nombre+"\"  fillcolor="+color+" ]");
                string[] nodos_sistema = sistema_actual.listarVariables(Sistema.DATOS_NODOS);
                for (int j = 0; j < nodos_sistema.Length; j++)
                {
                    texto_graphviz.AppendLine(sistema_actual.id_sistema + " -> " + nodos_sistema[j] + " [color= \""+color+":"+color+"\" dir=none size=\"8,5\"]");//lineas sistemas
                 //   texto_graphviz.AppendLine(nodos_sistema[j] + "[fillcolor=" + color + "]");
                }
                    
                string[] sistemas_sistema = sistema_actual.listarVariables(Sistema.DATOS_SISTEMAS);
                for (int j = 0; j < sistemas_sistema.Length; j++)
                    texto_graphviz.AppendLine(sistema_actual.id_sistema + " -> " + sistemas_sistema[j] + " [color= \""+color+":"+color+"\" dir=none]");//Lineas sistemas
            }

            texto_graphviz.AppendLine("}");//fin digraph
            //textBox_graphviz.Text = texto_graphviz.ToString();
            return texto_graphviz;
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //  generarArchivoDeTexto
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        public bool generarArchivoDeTexto(StringBuilder texto_graphviz, string full_path_destino)
        {
            if (File.Exists(full_path_destino))
                File.Delete(full_path_destino);
            using (StreamWriter stream_writer = new StreamWriter (full_path_destino,false))
            {
                stream_writer.Write(texto_graphviz);
                stream_writer.Close();
            }
            if (File.Exists(full_path_destino))
                return true;
            return false;
        }


        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //  retornarColor
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        public string retornarColor(int indice)
        {
            int indice_arreglo = indice % colores.Length;
            return colores[indice_arreglo];
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //  retornarColorNodo
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        public string retornarColorNodo(double peso)
        {
            int indice_arreglo = 0;
            if (peso >= 0.2 && peso < 0.4)
                indice_arreglo = 1;
            else
            if (peso >= 0.4 && peso < 0.6)
                indice_arreglo = 2;
            else
            if (peso >= 0.6 && peso < 0.8)
                indice_arreglo = 3;
            else
            if (peso >= 0.8)
                indice_arreglo = 4;
            
            return colores_nodos[indice_arreglo];
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //  retornarColorinfluencia
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        public string retornarColorInfluencia(double peso)
        {
            
            int indice_arreglo;
            if (peso < 0)
                indice_arreglo = 0;
            else
            if (peso > 0)
                indice_arreglo = 2;
            else
                indice_arreglo = 1;

            return colores_influencias[indice_arreglo];
        }


        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //  avanzarCaracter
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        private char avanzarCaracter(char x)
        {

            if (x >= 48 && x < 57)
            {
                x++;
            }
            else
                if (x == 57)
                {
                    x = (char)65;
                }
                else
                    if (x >= 65 && x < 90)
                    {
                        x++;
                    }
                    else
                        if (x == 90)
                        {
                            x = (char)97;
                        }
                        else
                            if (x >= 97 && x < 122)
                            {
                                x++;
                            }
                            else
                                if (x == 122)
                                {
                                    x = (char)48;

                                }
            return x;
        }


        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            cargarImagen
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        public Image cargarImagen(string path_imagen)
        {
            Image imagen = null;
            try
            {
                using(FileStream fs = new FileStream(path_imagen, FileMode.Open, FileAccess.Read))
                {
                    imagen = Image.FromStream(fs);
                    fs.Close();
                }
                
            }
            catch (Exception e)
            {
                return null;
            }
            return imagen;
        }
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            crearImagenGraphviz
        //--------------------------------------------------------------
        //--------------------------------------------------------------

        public void crearImagenGraphViz(string ruta_archivo_origen, string ruta_archivo_destino)
        {
            System.Diagnostics.Process proceeso_secundario = new System.Diagnostics.Process();
            proceeso_secundario.StartInfo.FileName = "Dot\\dot.exe";
            proceeso_secundario.StartInfo.Arguments = " -Tpng " + ruta_archivo_origen + " -o " + ruta_archivo_destino + "";
            proceeso_secundario.StartInfo.UseShellExecute = false;
            proceeso_secundario.StartInfo.RedirectStandardInput = true;
            proceeso_secundario.StartInfo.RedirectStandardOutput = true;
            proceeso_secundario.StartInfo.RedirectStandardError = true;
            proceeso_secundario.StartInfo.CreateNoWindow = true;
            proceeso_secundario.Start();
            proceeso_secundario.WaitForExit();
            proceeso_secundario.Close();
        }

    }

    



}
