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
    public delegate void DelegadoProcesoIterativoMBCIF (bool procesando);

    public partial class FormVentanaMBCIF : Form
    {
        //*****************************************************************************************************************
        //-----------------------------------------------------------------------------------------------------------------
        //                                           ATRIBUTOS
        //-----------------------------------------------------------------------------------------------------------------
        //*****************************************************************************************************************

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
                string aux_dato = id_datos_internos[i] + " \t " + nodo.extraerValorVariable(id_datos_internos[i], Nodo.DATOS_INTERNOS);
                textBox_informacion_elementos.AppendText(aux_dato + "\r\n");
            }
            textBox_informacion_elementos.AppendText("-------------------------" + "\r\n");
            textBox_informacion_elementos.AppendText("-- Nodos Externos" + "\r\n");
            //Nodo externos
            string[] id_nodo_externos = nodo.listarVariables(Nodo.DATOS_NODOS_EXTERNOS);
            for (int i = 0; i < id_nodo_externos.Length; i++)
            {
                string aux_dato = id_nodo_externos[i] + " \t " + nodo.extraerValorVariable(id_nodo_externos[i], Nodo.DATOS_NODOS_EXTERNOS);
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
            Influencia influencia = new ManejadorDeDatosArchivos(_ruta_carpeta_mbcif).extraerInfluencia(id_influencia);
            if (influencia != null)
                mostrarInformacionInfluencia(influencia);
            else
                MessageBox.Show("Influencia no encontrada", "Error", System.Windows.Forms.MessageBoxButtons.OK, 
                                System.Windows.Forms.MessageBoxIcon.Error);
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
            textBox_informacion_elementos.AppendText("Id nodo influenciado " + "\r\n \t\"" + influencia.id_nodo_influenciado + "\"\r\n" + "\r\n");
            textBox_informacion_elementos.AppendText("Peso nodo origen:\t" + influencia.peso_nodo_origen + "\r\n" + "\r\n");
            textBox_informacion_elementos.AppendText("Peso influencia: \t\t" + influencia.peso_influencia + "\r\n");
            
        }
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            buscarSistema
        //--------------------------------------------------------------
        //--------------------------------------------------------------


        public void buscarSistema(string id_sistema)
        {
             id_ultimo_nodo_consultado = "";
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

        public StringBuilder extraerDatosInternosDeNodos()
        {
            StringBuilder sb = new StringBuilder();
            ManejadorDeDatosArchivos manejador_de_archivos = new ManejadorDeDatosArchivos(_ruta_carpeta_mbcif);
            string[] nodos = manejador_de_archivos.listarArchivosEnDirectorio(ManejadorDeDatosArchivos.NODOS);
            for (int i = 0; i < nodos.Length; i++)
            {
                string info_nodo = "";
                Nodo nodo = manejador_de_archivos.extraerNodo(nodos[i]);
                info_nodo = nodo.id_nodo + ";";
                string[] id_datos_internos = nodo.listarVariables(Nodo.DATOS_INTERNOS);
                for (int j = 0; j < id_datos_internos.Length; j++)
                {
                    if (j != 0)
                        info_nodo += "|";
                    info_nodo += id_datos_internos[j] + ":" + nodo.extraerValorVariable(id_datos_internos[j], Nodo.DATOS_INTERNOS);
                }
                info_nodo += ";influencia_externa_forzada:" + nodo.influencia_externa_forzada;
                sb.AppendLine(info_nodo);
// Cada linea guarda el estado de un nodo con el siguiente formato-->      id_nodo;nombre_dato_interno1:valor|nombre_dato_interno2:valor|nombre_dato_internon:valor;influencia_forzada_externa:valor
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
                foreach (string tupla in lista_info_nodos)
                {
                    ArrayList datos_nodos = new ArrayList();
                    string id_nodo,string_influencia_forzada_externa;
                    string[] conjunto_de_elemento_aux, dato_aux;
                    conjunto_de_elemento_aux = tupla.Split(';');//separamos la id de los elementos 
                    id_nodo = conjunto_de_elemento_aux[0];
                    string_influencia_forzada_externa = conjunto_de_elemento_aux[2].Split(':')[1];//separamos el valor de la influencia forzada externa
                    conjunto_de_elemento_aux = conjunto_de_elemento_aux[1].Split('|');//separamos los distintos elemntos 
                    
                    for (int i = 0; i < conjunto_de_elemento_aux.Length; i++)
                    {
                        dato_aux = conjunto_de_elemento_aux[i].Split(':');//Separamos el valor del elemento
                        Dato dato = new Dato();
                        string id_dato = dato_aux[0];//Separamos la id del elemento
                        double valor_dato = (double)Convert.ToDecimal(dato_aux[1]);
                        dato.id = id_dato;
                        dato.valor = valor_dato;
                        datos_nodos.Add(dato);
                    }
                    double valor_influencia_forzada_externa = (double)Convert.ToDecimal(string_influencia_forzada_externa);
                    manejador_MBCIF.ingresarDatosIntenosANodo(datos_nodos, id_nodo,valor_influencia_forzada_externa);
                }
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
            if (radioButton_nodo.Checked)
            {
                ventana_buscar = new FormVentanaBuscar("Nodos");
                archivos = manejador_de_archivos.listarArchivosEnDirectorio(ManejadorDeDatosArchivos.NODOS);
            }
            else if (radioButton_influencia.Checked)
            {
                ventana_buscar = new FormVentanaBuscar("Influencias");
                archivos = manejador_de_archivos.listarArchivosEnDirectorio(ManejadorDeDatosArchivos.INFLUENCIAS);
                
            }
            else if (radioButton_sistema.Checked)
            {
                ventana_buscar = new FormVentanaBuscar("Sistemas");
                archivos = manejador_de_archivos.listarArchivosEnDirectorio(ManejadorDeDatosArchivos.SISTEMAS);
            }
            for (int i = 0; i < archivos.Length; i++)
            {
                ventana_buscar.agregarElemento(archivos[i]);
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
                ventana_modificacion_de_datos.agregarCampos(id_datos_internos[i], nodo.extraerValorVariable(id_datos_internos[i], Nodo.DATOS_INTERNOS),nodo.extraerRangoVariable(id_datos_internos[i], Nodo.DATOS_INTERNOS));   
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
                    aux.valor = ventana_modificacion_de_datos.ExtraerValorVariablePorNombre(id_datos_internos[i]);
                    if (aux.valor != -666)
                        datos_nodos.Add(aux);
                }
                double influencia_externa_forzada = ventana_modificacion_de_datos.influencia_externa_forzada;
                manejador_MBCIF.ingresarDatosIntenosANodo(datos_nodos, nodo.id_nodo,influencia_externa_forzada);
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


    }
}
