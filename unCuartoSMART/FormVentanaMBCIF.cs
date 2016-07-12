using AccesoADatos;
using ModeloMBCIF;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace unCuartoSMART
{

    
    
    public partial class FormVentanaMBCIF : Form
    {
        //*****************************************************************************************************************
        //-----------------------------------------------------------------------------------------------------------------
        //                                           ATRIBUTOS
        //-----------------------------------------------------------------------------------------------------------------
        //*****************************************************************************************************************
        public delegate void DelegadoProcesoIterativoMBCIF(bool procesando);

        public event DelegadoProcesoIterativoMBCIF evento_proceso_iterativo_mbcif;

        
        //*******************************
        //   manejador_MBCIF
        //*******************************
        private ManejadorMBCIF manejador_MBCIF = null;
               
        
        //*******************************
        //   ruta carpeta matrices
        //*******************************
        public string ruta_carpeta_mbcif
        {
            get
            {
                return _ruta_carpeta_mbcif;
            }
            set
            {
                _ruta_carpeta_mbcif = ruta_carpeta_mbcif;
            }
        }

        public string _ruta_carpeta_mbcif = "recursos\\datos_matriz";
        public string _ruta_carpeta_mbcif_en_blanco = "recursos\\datos_matriz_en_blanco";
        //*******************************
        //   Imagen Principal
        //*******************************

        public Image imagen_principal
        {
            get
            {
                return _imagen_principal;
            }
            set
            {
                _imagen_principal = value;
                cambiarTamañoImagen(_imagen_principal, 100,pictureBox_imagen);
                pictureBox_imagen.Image = value;
                pictureBox_imagen.Refresh();
            }
        }

        private Image _imagen_principal;

        //*******************************
        //   escala imagen
        //*******************************
        private int escala_imagen = 100;

        
        //*******************************
        //   ultimo nodo consultado
        //*******************************
        
        private string id_ultimo_nodo_consultado = "";


        //*******************************
        //   id_ultima_influencia_consultado
        //*******************************

        private string id_ultima_influencia_consultado = "";

        //*****************************************************************************************************************
        //-----------------------------------------------------------------------------------------------------------------
        //                                           METODOS
        //-----------------------------------------------------------------------------------------------------------------
        //*****************************************************************************************************************

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            Constructor
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        
        public FormVentanaMBCIF()
        {
            InitializeComponent();
            iniciarMBCIF();
            mostrarDiagramaMatriz();
            
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            iniciarMBCIF
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        public void iniciarMBCIF()
        {
            manejador_MBCIF = null;
            manejador_MBCIF = new ManejadorMBCIF(_ruta_carpeta_mbcif);
            manejador_MBCIF.evento_guardado_de_datos += new DelegadoGuardadoDeDatos(marcarGuardadoDeDatos);
            manejador_MBCIF.evento_iteracion += manejador_MBCIF_evento_iteracion;
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            cambiarTamañoImagen
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        public void cambiarTamañoImagen(Image imagen, int porcentaje_escala, PictureBox pictureBox_contenedor)
        {
            Size tamaño_imagen = imagen.Size;

            double h = ((double)tamaño_imagen.Height * (double)((double)porcentaje_escala / 100));
            double w = ((double)tamaño_imagen.Width * (double)((double)porcentaje_escala / 100));
            pictureBox_contenedor.Height = (int)h;
            pictureBox_contenedor.Width = (int)w;

        }




        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            buscarNodo
        //--------------------------------------------------------------
        //--------------------------------------------------------------


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id_nodo"></param>
        /// <returns></returns>
        public void buscarNodo(string id_nodo)
        {
            id_ultima_influencia_consultado = "";
            Nodo nodo = new ManejadorDeDatosArchivos(_ruta_carpeta_mbcif).extraerNodo(id_nodo);
            if (nodo != null)
            {
                id_ultimo_nodo_consultado = id_nodo;
                mostrarInformacionNodo(nodo);
                button_modificar_nodo.Enabled = true;
            }
            else
            {
                MessageBox.Show("Nodo no encontrado", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                id_ultimo_nodo_consultado = "";
                button_modificar_nodo.Enabled = false;
            }
                
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //           mostrarInformacionNodo
        //--------------------------------------------------------------
        //--------------------------------------------------------------


        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodo"></param>
        public void mostrarInformacionNodo(Nodo nodo)
        {
            
            textBox_informacion_elementos.Text = "";
            textBox_informacion_elementos.AppendText("Id nodo " + "\r\n \t \"" + nodo.id_nodo + "\" \r\n" );
            textBox_informacion_elementos.AppendText("Nombre nodo " + "\r\n \t \"" + nodo.nombre + "\"\r\n" + "\r\n");
            textBox_informacion_elementos.AppendText("-------------------------" + "\r\n");
            textBox_informacion_elementos.AppendText("Peso: \t\t" + nodo.peso + "\r\n");
            textBox_informacion_elementos.AppendText("Peso bruto:\t" + nodo.peso_bruto + "\r\n" + "\r\n");

            //InferenciaDifusa fuzzy = nodo.fuzzy;
            textBox_informacion_elementos.AppendText("-------------------------" + "\r\n");
            textBox_informacion_elementos.AppendText("-- Datos Internos" + "\r\n");
            //Datos internos
            string[] id_datos_internos = nodo.listarVariables(Nodo.DATOS_INTERNOS);
            for (int i = 0; i < id_datos_internos.Length; i++)
            {
                string ponderacion = String.Format("{0:0.00}", nodo.extraerPonderacionVariable(id_datos_internos[i], Nodo.DATOS_INTERNOS, true));
                string aux_dato = "(" + ponderacion + ")  " + id_datos_internos[i] + " \t " + nodo.extraerValorVariable(id_datos_internos[i], Nodo.DATOS_INTERNOS);
                textBox_informacion_elementos.AppendText(aux_dato + "\r\n");
            }
            textBox_informacion_elementos.AppendText("-------------------------" + "\r\n");
            textBox_informacion_elementos.AppendText("-- Nodos Externos" + "\r\n");
            //Nodo externos
            string[] id_nodo_externos = nodo.listarVariables(Nodo.DATOS_NODOS_EXTERNOS);
            for (int i = 0; i < id_nodo_externos.Length; i++)
            {
                string ponderacion = String.Format("{0:0.00}", nodo.extraerPonderacionVariable(id_nodo_externos[i], Nodo.DATOS_NODOS_EXTERNOS, true));
                string aux_dato = "(" + ponderacion + ")  " + id_nodo_externos[i] + " \t " + nodo.extraerValorVariable(id_nodo_externos[i], Nodo.DATOS_NODOS_EXTERNOS);
                textBox_informacion_elementos.AppendText(aux_dato + "\r\n");
            }
            textBox_informacion_elementos.AppendText("-------------------------" + "\r\n");
            textBox_informacion_elementos.AppendText("-- Influencias externas" + "\r\n");
            //Influencia
            string[] id_influencia = nodo.listarVariables(Nodo.INFLUENCIAS_EXTERNAS);
            for (int i = 0; i < id_influencia.Length; i++)
            {
                string aux_dato = id_influencia[i] + "\t " + nodo.extraerValorVariable(id_influencia[i], Nodo.INFLUENCIAS_EXTERNAS);
                textBox_informacion_elementos.AppendText(aux_dato + "\r\n");
            }
            textBox_informacion_elementos.AppendText("-------------------------" + "\r\n");
            textBox_informacion_elementos.AppendText("-- Nodos influenciados" + "\r\n");
            //Nodos influenciados
            string[] nodos_influenciados = nodo.listarVariables(Nodo.NODOS_INFLUENCIADOS);
            for (int i = 0; i < nodos_influenciados.Length; i++)
            {
                textBox_informacion_elementos.AppendText(nodos_influenciados[i] + "\r\n");
            }
            textBox_informacion_elementos.AppendText("-------------------------" + "\r\n");
            textBox_informacion_elementos.AppendText("-- Influencias Externas Forzadas" + "\r\n");
            textBox_informacion_elementos.AppendText("\t"+nodo.influencia_externa_forzada + "\r\n");
            // propertyGrid_inferencia_difusa.SelectedObject = nodo.fuzzy;
            // propertyGrid_inferencia_difusa.SelectedObject = nodo;

        }


        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            buscarInfluencia
        //--------------------------------------------------------------
        //--------------------------------------------------------------


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id_influencia"></param>
        /// <returns></returns>
        public void buscarInfluencia(string id_influencia)
        {
            id_ultimo_nodo_consultado = "";
            id_ultima_influencia_consultado = "";
            Influencia influencia = new ManejadorDeDatosArchivos(_ruta_carpeta_mbcif).extraerInfluencia(id_influencia);
            if (influencia != null)
            {
                mostrarInformacionInfluencia(influencia);
                id_ultima_influencia_consultado = influencia.id_influencia;
                button_modificar_ajuste_influencia.Enabled = true;
            }
            else
            {
                button_modificar_ajuste_influencia.Enabled = false;
                id_ultima_influencia_consultado = "";
                MessageBox.Show("Influencia no encontrada", "Error", System.Windows.Forms.MessageBoxButtons.OK,
                                System.Windows.Forms.MessageBoxIcon.Error);
            }
                
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            mostrarInfluencia
        //--------------------------------------------------------------
        //--------------------------------------------------------------


        /// <summary>
        /// 
        /// </summary>
        /// <param name="influencia"></param>
        public void mostrarInformacionInfluencia(Influencia influencia)
        {

            textBox_informacion_elementos.Text = "";
            textBox_informacion_elementos.AppendText("Id influencia " + "\r\n \t\"" + influencia.id_influencia + "\"\r\n");
            textBox_informacion_elementos.AppendText("Id nodo origen " + "\r\n \t\"" + influencia.id_nodo_origen + "\"\r\n" + "\r\n");
            if (!influencia.nombre_nodo_origen.Equals(""))
                textBox_informacion_elementos.AppendText("Nombre nodo origen " + "\r\n \t\"" + influencia.nombre_nodo_origen + "\"\r\n" + "\r\n");
            textBox_informacion_elementos.AppendText("Id nodo influenciado " + "\r\n \t\"" + influencia.id_nodo_influenciado + "\"\r\n" + "\r\n");
            if (!influencia.nombre_nodo_destino.Equals(""))
                textBox_informacion_elementos.AppendText("Nombre nodo influenciado " + "\r\n \t\"" + influencia.nombre_nodo_destino + "\"\r\n" + "\r\n");
            textBox_informacion_elementos.AppendText("Peso nodo origen:\t" + influencia.peso_nodo_origen + "\r\n" + "\r\n");
            textBox_informacion_elementos.AppendText("Peso influencia: \t\t" + influencia.peso_influencia + "\r\n");
            textBox_informacion_elementos.AppendText("Valor ajuste influencia: \t\t" + influencia.valor_ajuste_influencia + "\r\n");
            
        }
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            buscarSistema
        //--------------------------------------------------------------
        //--------------------------------------------------------------


        public void buscarSistema(string id_sistema)
        {
             id_ultimo_nodo_consultado = "";
             id_ultima_influencia_consultado = "";
             Sistema sistema = new ManejadorDeDatosArchivos(_ruta_carpeta_mbcif).extraerSistema(id_sistema);
                if (sistema != null)
                    mostrarInformacionSistema(sistema);
                else
                    MessageBox.Show("Sistema no encontrado", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            mostrarInformacionSistema0
        //--------------------------------------------------------------
        //--------------------------------------------------------------


        public void mostrarInformacionSistema(Sistema sistema)
        {
            textBox_informacion_elementos.Text = "";
            textBox_informacion_elementos.AppendText("Id Sistema " + "\r\n \t\"" + sistema.id_sistema + "\"\r\n");
            textBox_informacion_elementos.AppendText("Nombre Sistema " + "\r\n \t\"" + sistema.nombre + "\"\r\n");
            textBox_informacion_elementos.AppendText("Peso:\t" + "" + sistema.peso + "\r\n");


            textBox_informacion_elementos.AppendText("-------------------------" + "\r\n");
            textBox_informacion_elementos.AppendText("-- Datos Sistema " + "\r\n");
            //Datos sistemas
            string[] id_datos_sistemas = sistema.listarVariables(Sistema.DATOS_SISTEMAS);
            for (int i = 0; i < id_datos_sistemas.Length; i++)
            {
                string aux_dato = id_datos_sistemas[i] + ":\t" + sistema.extraerValorVariable(id_datos_sistemas[i], Sistema.DATOS_SISTEMAS) + "\r\n";
                textBox_informacion_elementos.AppendText(aux_dato);
            }

            textBox_informacion_elementos.AppendText("-------------------------" + "\r\n");
            textBox_informacion_elementos.AppendText("-- Datos nodos " + "\r\n");
            //Datos nodos
            string[] id_datos_nodos = sistema.listarVariables(Sistema.DATOS_NODOS);
            for (int i = 0; i < id_datos_nodos.Length; i++)
            {
                string aux_dato = id_datos_nodos[i] + ":\t" + sistema.extraerValorVariable(id_datos_nodos[i], Sistema.DATOS_NODOS) + "\r\n";
                textBox_informacion_elementos.AppendText(aux_dato);
            }
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            extraerDatosInternosDeNodos
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        // Cada linea guarda el estado de nodos e influencias con el siguiente formato   
        //(NO nodo,IN influencia, ID id,DI dato interno,  NE nodo externo, IF infleuncia forzada externa, VA valor ajuste influencia)-->
        //NO!ID:id_influencia|DI:nombre_dato_interno_1:valor|DI:nombre_dato_interno_2:valor:ponderacion|NE:nombre_nodod_externo:valor:ponderacion|IF:valor
        //IN!ID:id_influencia|VA:valor
        public StringBuilder extraerDatosInternosDeNodos()
        {
            StringBuilder sb = new StringBuilder();
            ManejadorDeDatosArchivos manejador_de_archivos = new ManejadorDeDatosArchivos(_ruta_carpeta_mbcif);
            
            //Ingresando Nodos
            string[] nodos = manejador_de_archivos.listarArchivosEnDirectorio(ManejadorDeDatosArchivos.NODOS);
            for (int i = 0; i < nodos.Length; i++)
            {
                string info_nodo = "NO!";
                Nodo nodo = manejador_de_archivos.extraerNodo(nodos[i]);
                info_nodo += "ID:"+nodo.id_nodo;
                //Datos internos
                string[] id_datos_internos = nodo.listarVariables(Nodo.DATOS_INTERNOS);
                for (int j = 0; j < id_datos_internos.Length; j++)
                {
                    info_nodo += "|DI:";
                    info_nodo += id_datos_internos[j] + ":" + nodo.extraerValorVariable(id_datos_internos[j], Nodo.DATOS_INTERNOS) + ":" + nodo.extraerPonderacionVariable(id_datos_internos[j], Nodo.DATOS_INTERNOS);
                }
                //Nodos externos
                string[] id_nodos_externos = nodo.listarVariables(Nodo.DATOS_NODOS_EXTERNOS);
                for (int j = 0; j < id_nodos_externos.Length; j++)
                {
                    info_nodo += "|NE:";
                    info_nodo += id_nodos_externos[j] + ":" + nodo.extraerPonderacionVariable(id_nodos_externos[j], Nodo.DATOS_NODOS_EXTERNOS);
                }
                info_nodo += "|IF:" + nodo.influencia_externa_forzada;
                sb.AppendLine(info_nodo);
            }
            //Ingresando influencias
            string[] influencias = manejador_de_archivos.listarArchivosEnDirectorio(ManejadorDeDatosArchivos.INFLUENCIAS);
            for (int i = 0; i < influencias.Length; i++)
            {
                
                string info_influencia = "IN!";
                Influencia influencia_actual = manejador_de_archivos.extraerInfluencia(influencias[i]);
                info_influencia += "ID:" + influencia_actual.id_influencia;
                info_influencia += "|VA:"+influencia_actual.valor_ajuste_influencia;
                sb.AppendLine(info_influencia);
            }
            return sb;
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            establecerEstadoDeLaMatriz
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        
        public bool establecerEstadoDeLaMatriz(ArrayList lista_info_nodos )
        {
            try
            {
                iniciarMBCIF();
                ManejadorDeDatosArchivos manejador_de_datos = new ManejadorDeDatosArchivos(_ruta_carpeta_mbcif);
                foreach (string tupla in lista_info_nodos)
                {
                    string tipo_tupla = tupla.Split('!')[0];
                    string contenido_tupla = tupla.Split('!')[1];
                    string[] datos = contenido_tupla.Split('|');
                    switch (tipo_tupla)
                    {
                        case "NO"://caso nodo
                            string id_nodo = "";
                            ArrayList array_datos_internos_nodo = new ArrayList();
                            ArrayList array_ponderacion_datos_internos_nodo = new ArrayList();
                            ArrayList array_ponderacion_nodos_externos_nodo = new ArrayList();
                            double valor_influencia_forzada_externa = 0;
                            for (int i = 0; i < datos.Length; i++)
                            {
                                string[] aux = datos[i].Split(':');
                                switch (aux[0])
                                {
                                    case "ID":
                                        id_nodo = aux[1];
                                        break;
                                    case "DI":
                                        Dato dato_interno = new Dato(aux[1], (double)Convert.ToDecimal(aux[2]));
                                        Dato dato_ponderacion = new Dato(aux[1], (double)Convert.ToDecimal(aux[3]));
                                        array_datos_internos_nodo.Add(dato_interno);
                                        array_ponderacion_datos_internos_nodo.Add(dato_ponderacion);
                                        break;
                                    case "NE":
                                        Dato dato_externo = new Dato(aux[1], (double)Convert.ToDecimal(aux[2]));
                                        array_ponderacion_nodos_externos_nodo.Add(dato_externo);
                                        break;
                                    case "IF":
                                        valor_influencia_forzada_externa = (double)Convert.ToDecimal(aux[1]);
                                        break;
                                }
                            }
                            manejador_MBCIF.ingresarDatosIntenosANodo(array_datos_internos_nodo, id_nodo, valor_influencia_forzada_externa);
                            manejador_MBCIF.ingresarPonderacionesANodo(id_nodo, array_ponderacion_datos_internos_nodo, array_ponderacion_nodos_externos_nodo);
                            break;//fin caso nodo
                        case "IN"://caso influencia
                            string id_influencia = "";
                            double valor_de_ajuste = 1;
                            for (int i = 0; i < datos.Length; i++)
                            {
                                string[] aux = datos[i].Split(':');
                                switch (aux[0])
	                            {
		                            case "ID":
                                        id_influencia = aux[1];
                                        break;
                                    case "VA":
                                        valor_de_ajuste = (double)Convert.ToDecimal(aux[1]);
                                        break;
	                            }
                            }
                            Influencia influencia = manejador_de_datos.extraerInfluencia(id_influencia);
                            influencia.valor_ajuste_influencia = valor_de_ajuste;
                            manejador_de_datos.actualizarInfluencia(influencia);
                            break;//fin caso influencia
                  
                    }//End sw
                }//End foreach
                manejador_MBCIF.calculoPrevioDePesosNodos();
                mostrarDiagramaMatriz();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            mostrarDiagramaMatriz
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        public void mostrarDiagramaMatriz(string id_nodo_marcado = "")
        {
            string path_carpeta_matriz = _ruta_carpeta_mbcif;
            string path_codigo_graphviz = "recursos\\codigo_graphviz.txt";
            string path_imagen_mcbif = "recursos\\mbcif.jpg";
            GestionGraphviz gestion = new GestionGraphviz(id_nodo_marcado);
            StringBuilder codigo_graphviz = gestion.generarCodigoMBCIF(path_carpeta_matriz);
            gestion.generarArchivoDeTexto(codigo_graphviz, path_codigo_graphviz);
            gestion.crearImagenGraphViz(path_codigo_graphviz, path_imagen_mcbif);
            imagen_principal = gestion.cargarImagen(path_imagen_mcbif);
       }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            procesoMBCIF
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        public void procesoMBCIF()
        {
            if (evento_proceso_iterativo_mbcif != null)
                evento_proceso_iterativo_mbcif(true);
            //---------------------------------------------- inicio proceso
            int maximo_de_iteraciones = (int)numericUpDown_numero_de_iteraciones.Value;
            int intervalo_guardado_de_datos = (int)numericUpDown_intervalo_de_guardado_de_datos.Value;
            int intervalo_analisis_de_datos = 0;

            progressBar_proceso_iterativo.Maximum = maximo_de_iteraciones;
            progressBar_proceso_iterativo.Value = 0;

           
            manejador_MBCIF.procesoMBCIF(maximo_de_iteraciones, intervalo_guardado_de_datos, intervalo_analisis_de_datos, checkBox_actualizacion_inmediata_nodos.Checked, false);




            progressBar_proceso_iterativo.Value = maximo_de_iteraciones;
            //---------------------------------------------- fin proceso
            if (evento_proceso_iterativo_mbcif != null)
                evento_proceso_iterativo_mbcif(false);
            mostrarDiagramaMatriz();
            MessageBox.Show("Se han concluido las iteraciones", "Proceso MBCIF", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            guardadoDeDatos
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        public void marcarGuardadoDeDatos(bool en_archivo)
        {
            progressBar_proceso_iterativo.Value += (int)numericUpDown_intervalo_de_guardado_de_datos.Value;
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            limpiarColaDeAnalisis
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        public void limpiarColaDeAnalisis()
        {
            manejador_MBCIF.limpiarColaDeAnalisis();
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            limpiarInfluenciasExternasForzadasEnNodos
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        public void limpiarInfluenciasExternasForzadasEnNodos()
        {
            manejador_MBCIF.limpiarInfluenciasExternasForzadaEnNodos();
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            limpiarBoxInfo
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        public void limpiarBoxInfo()
        {
            textBox_id_buscada.Text = "";
            textBox_informacion_elementos.Text = "";
            id_ultimo_nodo_consultado = "";
            id_ultima_influencia_consultado = "";
        }


        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            reinicializarArchivosMBCIF
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        public void reinicializarArchivosMBCIF()
        {
             try
                {
                    DirectoryInfo directorio_mbcif = new DirectoryInfo(_ruta_carpeta_mbcif);
                    FileInfo[] archivos_mbcif = directorio_mbcif.GetFiles();
                    for (int i = 0; i < archivos_mbcif.Length; i++)
                    {
                        archivos_mbcif[i].Delete();
                    }

                    DirectoryInfo directorio_mbcif_en_blanco = new DirectoryInfo(_ruta_carpeta_mbcif_en_blanco);
                    FileInfo[] archivos_mbcif_en_blanco = directorio_mbcif_en_blanco.GetFiles();
                    for (int i = 0; i < archivos_mbcif_en_blanco.Length; i++)
                    {
                        File.Copy(_ruta_carpeta_mbcif_en_blanco + "\\" + archivos_mbcif_en_blanco[i].Name, _ruta_carpeta_mbcif + "\\" + archivos_mbcif_en_blanco[i].Name, true);
                    }
                    MessageBox.Show("Se ha reinicializado correctamente el modelo MBCIF", "Modelo MBCIF", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error en la reinicializacion de archivos,\n Ejecute aplicación como administrador", "Error MBCIF", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
            


        }
        
        public bool preguntaSiNo(string titulo, string mensaje)
        {
            if (DialogResult.Yes == MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1))
                return true;
            return false;
        }

        //*****************************************************************************************************************
        //-----------------------------------------------------------------------------------------------------------------
        //                                           EVENTOS
        //-----------------------------------------------------------------------------------------------------------------
        //*****************************************************************************************************************

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            button_aumentar_click
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        private void button_aumentar_Click(object sender, EventArgs e)
        {
            escala_imagen += 10;
            cambiarTamañoImagen(this.imagen_principal, escala_imagen, this.pictureBox_imagen);
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            button_disminuir_Click
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        private void button_disminuir_Click(object sender, EventArgs e)
        {
            escala_imagen -= 10;
            cambiarTamañoImagen(this.imagen_principal, escala_imagen, this.pictureBox_imagen);
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            button_buscar_Click
        //--------------------------------------------------------------
        //--------------------------------------------------------------

        private void button_buscar_Click(object sender, EventArgs e)
        {
            textBox_id_buscada.Text = "";
            FormVentanaBuscar ventana_buscar =  null;
            ManejadorDeDatosArchivos manejador_de_archivos = new ManejadorDeDatosArchivos(_ruta_carpeta_mbcif);
            string[] archivos = null;
            string[] descripcion = null;
            if (radioButton_nodo.Checked)
            {
                ventana_buscar = new FormVentanaBuscar("Nodos");
                archivos = manejador_de_archivos.listarArchivosEnDirectorio(ManejadorDeDatosArchivos.NODOS);
                descripcion = new string[archivos.Length];
                for (int i = 0; i < archivos.Length; i++)
                {
                    Nodo nodo = manejador_de_archivos.extraerNodo(archivos[i]);
                    descripcion[i] = nodo.nombre;
                }
            }
            else if (radioButton_influencia.Checked)
            {
                ventana_buscar = new FormVentanaBuscar("Influencias");
                archivos = manejador_de_archivos.listarArchivosEnDirectorio(ManejadorDeDatosArchivos.INFLUENCIAS);
                descripcion = new string[archivos.Length];
                for (int i = 0; i < archivos.Length; i++)
                {
                    Influencia influencia = manejador_de_archivos.extraerInfluencia(archivos[i]);
                    descripcion[i] = influencia.nombre_influencia;
                }
            }
            else if (radioButton_sistema.Checked)
            {
                ventana_buscar = new FormVentanaBuscar("Sistemas");
                archivos = manejador_de_archivos.listarArchivosEnDirectorio(ManejadorDeDatosArchivos.SISTEMAS);
                descripcion = new string[archivos.Length];
                for (int i = 0; i < archivos.Length; i++)
                {
                    Sistema sistema = manejador_de_archivos.extraerSistema(archivos[i]);
                    descripcion[i] = sistema.nombre;
                }
            }
            for (int i = 0; i < archivos.Length; i++)
            {
                if (descripcion == null)
                    ventana_buscar.agregarElemento(archivos[i]);
                else
                    ventana_buscar.agregarElemento(archivos[i] , descripcion[i]);
            }
            ventana_buscar.ShowDialog(this);
            if (ventana_buscar.seleccion != null)
            {
                if (radioButton_nodo.Checked)
                {
                    buscarNodo(ventana_buscar.seleccion);
                }
                else if (radioButton_influencia.Checked)
                {
                    buscarInfluencia(ventana_buscar.seleccion);
                }
                else if (radioButton_sistema.Checked)
                {
                    buscarSistema(ventana_buscar.seleccion);
                }
            }
        }




        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            button_modificar_nodo_Click
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        private void button_modificar_nodo_Click(object sender, EventArgs e)
        {
            Nodo nodo = new ManejadorDeDatosArchivos(_ruta_carpeta_mbcif).extraerNodo(this.id_ultimo_nodo_consultado);
            
            
            FormVentanaIngresoDatos ventana_modificacion_de_datos  = new  FormVentanaIngresoDatos(nodo.nombre);
            string[] id_datos_internos = nodo.listarVariables(Nodo.DATOS_INTERNOS);
            for (int i = 0; i < id_datos_internos.Length; i++)
            {
                ventana_modificacion_de_datos.agregarCampos(id_datos_internos[i], nodo.extraerValorVariable(id_datos_internos[i], Nodo.DATOS_INTERNOS),nodo.extraerRangoVariable(id_datos_internos[i], Nodo.DATOS_INTERNOS),nodo.extraerPonderacionVariable(id_datos_internos[i],Nodo.DATOS_INTERNOS));   
            }
            string[] id_nodos_externos = nodo.listarVariables(Nodo.DATOS_NODOS_EXTERNOS);
            for (int i = 0; i < id_nodos_externos.Length; i++)
            {
                ventana_modificacion_de_datos.agregarCampos(id_nodos_externos[i], nodo.extraerValorVariable(id_nodos_externos[i], Nodo.DATOS_NODOS_EXTERNOS), new double[] { 0,1},nodo.extraerPonderacionVariable(id_nodos_externos[i],Nodo.DATOS_NODOS_EXTERNOS),false);
            }

            ventana_modificacion_de_datos.influencia_externa_forzada = nodo.influencia_externa_forzada;
            ventana_modificacion_de_datos.ShowDialog(this);
            if (ventana_modificacion_de_datos.se_ingresaron_datos)
            {
                ArrayList datos_nodos = new ArrayList();
                for (int i = 0; i < id_datos_internos.Length; i++)
                {
                    Dato aux = new Dato();
                    aux.id = id_datos_internos[i];
                    aux.valor = ventana_modificacion_de_datos.extraerValorVariablePorNombre(id_datos_internos[i]);
                    if (aux.valor != -666)
                        datos_nodos.Add(aux);
                }
                double influencia_externa_forzada = ventana_modificacion_de_datos.influencia_externa_forzada;
                manejador_MBCIF.ingresarDatosIntenosANodo(datos_nodos, nodo.id_nodo,influencia_externa_forzada);
                
                if (ventana_modificacion_de_datos.se_modificaron_ponderaciones)
                {
                    ArrayList ponderaciones_datos_internos = new ArrayList();
                    ArrayList ponderaciones_nodos_externos = new ArrayList();
                    for (int i = 0; i < id_datos_internos.Length; i++)
                    {
                        Dato dato = new Dato(id_datos_internos[i], ventana_modificacion_de_datos.extraerValorPonderacionVariablePorNombre(id_datos_internos[i]));
                        ponderaciones_datos_internos.Add(dato);
                    }
                    
                    for (int i = 0; i < id_nodos_externos.Length; i++)
                    {
                        Dato dato = new Dato(id_nodos_externos[i], ventana_modificacion_de_datos.extraerValorPonderacionVariablePorNombre(id_nodos_externos[i]));
                        ponderaciones_nodos_externos.Add(dato);
                    }

                    manejador_MBCIF.ingresarPonderacionesANodo(this.id_ultimo_nodo_consultado, ponderaciones_datos_internos, ponderaciones_nodos_externos);
                }




                buscarNodo(nodo.id_nodo);
            }

        }



        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            radioButton_sistema_CheckedChanged
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        private void radioButton_influencia_CheckedChanged(object sender, EventArgs e)
        {
            limpiarBoxInfo();
            button_modificar_nodo.Enabled = false;
            button_modificar_ajuste_influencia.Enabled = false;
        }



        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            radioButton_sistema_CheckedChanged
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        private void radioButton_sistema_CheckedChanged(object sender, EventArgs e)
        {
            limpiarBoxInfo();
            button_modificar_nodo.Enabled = false;
            button_modificar_ajuste_influencia.Enabled = false;
        }


        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            radioButton_sistema_CheckedChanged
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        private void radioButton_nodo_CheckedChanged(object sender, EventArgs e)
        {
            limpiarBoxInfo();
            button_modificar_nodo.Enabled = false;
            button_modificar_ajuste_influencia.Enabled = false;
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            FormVentanaMBCIF_FormClosing
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        private void FormVentanaMBCIF_FormClosing(object sender, FormClosingEventArgs e)
        {
            limpiarBoxInfo();
            e.Cancel = true;
            this.Hide();
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            textBox_id_buscada_KeyPress
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        private void textBox_id_buscada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                if (!textBox_id_buscada.Text.Equals(""))
                {
                    if (radioButton_nodo.Checked)
                    {
                        buscarNodo(textBox_id_buscada.Text);
                    }
                    else if (radioButton_influencia.Checked)
                    {
                        buscarInfluencia(textBox_id_buscada.Text);
                    }
                    else if (radioButton_sistema.Checked)
                    {
                        buscarSistema(textBox_id_buscada.Text);
                    }
                }
                else
                {
                    MessageBox.Show("No se ha completado el campo ID", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
                }
            }
            
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            radioButton_iterar_paso_a_paso_CheckedChanged
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        private void radioButton_iterar_paso_a_paso_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_iterar_todo_a_la_vez.Checked)
                numericUpDown_tiempo_entre_iteracion.Enabled = false;
            else
                numericUpDown_tiempo_entre_iteracion.Enabled = true;
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            radioButton_iterar_todo_a_la_vez_CheckedChanged
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        private void radioButton_iterar_todo_a_la_vez_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton_iterar_todo_a_la_vez.Checked)
                numericUpDown_tiempo_entre_iteracion.Enabled = false;
            else
                numericUpDown_tiempo_entre_iteracion.Enabled = true;
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            numericUpDown_intervalo_de_guardado_de_datos_ValueChanged
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        private void numericUpDown_intervalo_de_guardado_de_datos_ValueChanged(object sender, EventArgs e)
        {
            
            if (numericUpDown_numero_de_iteraciones.Value <= numericUpDown_intervalo_de_guardado_de_datos.Value)
            {
                MessageBox.Show("El intervalo de guardado debe ser menor al número de iteraciones", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                numericUpDown_intervalo_de_guardado_de_datos.Value = 1;
            }
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            button_iniciar_iteracion_Click
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        private void button_iniciar_iteracion_Click(object sender, EventArgs e)
        {
            limpiarBoxInfo();
            if (manejador_MBCIF.numero_de_elementos_en_cola_de_analisis != 0)
            {
                procesoMBCIF();
            }
            else
            {
                string mensaje = "La cola de analisis esta vacia.\n" +
                                  "¿Desea ingresar todos los nodos a la cola?.\n" +
                                  "En caso contrario modifique algunos nodos";
                if (DialogResult.Yes == MessageBox.Show(mensaje, "Cola de analisis Vacia", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    string[] lista_de_nodos = new ManejadorDeDatosArchivos(_ruta_carpeta_mbcif).listarArchivosEnDirectorio(ManejadorDeDatosArchivos.NODOS);
                    bool flag = true;
                    for (int i = 0; i < lista_de_nodos.Length && flag; i++)
                    {
                        if (!manejador_MBCIF.ingresarNuevoNodoAColaDeAnalisis(lista_de_nodos[i]))
                        {
                            flag = false;
                            MessageBox.Show("Problemas con el encolamiento de los nodos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    procesoMBCIF();

                }
                else
                {
                    MessageBox.Show("No se ha iniciado el proceso iterativo", "Proceso iterativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            manejador_MBCIF_evento_iteracion
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        void manejador_MBCIF_evento_iteracion(string nodo_actual)
        {
            if (radioButton_iterar_paso_a_paso.Checked)
            {
                mostrarDiagramaMatriz(nodo_actual);
                int tiempo_en_milisegundos = (int)(numericUpDown_tiempo_entre_iteracion.Value * 1000);
                System.Threading.Thread.Sleep(tiempo_en_milisegundos);
            }
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            button_modificar_ajuste_influencia_Click
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        private void button_modificar_ajuste_influencia_Click(object sender, EventArgs e)
        {
            ManejadorDeDatosArchivos manejador_de_archivos = new ManejadorDeDatosArchivos(_ruta_carpeta_mbcif);
            Influencia influencia = manejador_de_archivos.extraerInfluencia(id_ultima_influencia_consultado);
            
            FormVentanaModificacionInfluencia ventana_modificacion_de_influencia = new FormVentanaModificacionInfluencia(id_ultima_influencia_consultado,influencia.nombre_influencia,influencia.valor_ajuste_influencia);
            ventana_modificacion_de_influencia.ShowDialog();
            if (ventana_modificacion_de_influencia.se_ingresarion_datos)
            {
                influencia.valor_ajuste_influencia = ventana_modificacion_de_influencia.valor_ajuste_influencia;
                manejador_de_archivos.actualizarInfluencia(influencia);
                mostrarInformacionInfluencia(influencia);
            }
        }



    }
}
