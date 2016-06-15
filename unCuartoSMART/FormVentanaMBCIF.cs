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


        public void buscarSistema(string id_sistema)
        {
             id_ultimo_nodo_consultado = "";
             Sistema sistema = new ManejadorDeDatosArchivos(_ruta_carpeta_mbcif).extraerSistema(id_sistema);
                if (sistema != null)
                    mostrarInformacionSistema(sistema);
                else
                    MessageBox.Show("Sistema no encontrado", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    
        }


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
        //            button_fantasma_Click
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        
        private void button_fantasma_Click(object sender, EventArgs e)
        {
            string path_carpeta_matriz = _ruta_carpeta_mbcif;
            string path_codigo_graphviz = "recursos\\codigo_graphviz.txt";
            string path_imagen_mcbif = "recursos\\mbcif.jpg";
            GestionGraphviz gestion = new GestionGraphviz();
            StringBuilder codigo_graphviz = gestion.generarCodigoMBCIF(path_carpeta_matriz);
            gestion.generarArchivoDeTexto(codigo_graphviz,path_codigo_graphviz);
            gestion.crearImagenGraphViz(path_codigo_graphviz, path_imagen_mcbif);
            imagen_principal = gestion.cargarImagen(path_imagen_mcbif);
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            button_buscar_Click
        //--------------------------------------------------------------
        //--------------------------------------------------------------

        private void button_buscar_Click(object sender, EventArgs e)
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
            }
            

            /*
            
            //Datos internos
            string[] id_datos_internos = nodo.listarVariables(Nodo.DATOS_INTERNOS);
            for (int i = 0; i < id_datos_internos.Length; i++)
            {
                string aux_dato = id_datos_internos[i] + " \t " + nodo.extraerValorVariable(id_datos_internos[i], Nodo.DATOS_INTERNOS);
                textBox_informacion_elementos.AppendText(aux_dato + "\r\n");
            }
            Nodo nodo = new ManejadorDeDatosArchivos(_ruta_carpeta_mbcif).extraerNodo(textBox_id_buscada.Text);
            if (nodo != null)
                Console.WriteLine("");//todo arreglar
            else
                MessageBox.Show("Nodo no encontrado", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
             */
        }



        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            radioButton_sistema_CheckedChanged
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        private void radioButton_influencia_CheckedChanged(object sender, EventArgs e)
        {
            button_modificar_nodo.Enabled = false;
        }



        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            radioButton_sistema_CheckedChanged
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        private void radioButton_sistema_CheckedChanged(object sender, EventArgs e)
        {
            button_modificar_nodo.Enabled = false;
        }


        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            radioButton_sistema_CheckedChanged
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        private void radioButton_nodo_CheckedChanged(object sender, EventArgs e)
        {
            button_modificar_nodo.Enabled = false;
        }




    }
}
