using System;
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

        public string _ruta_carpeta_mbcif = null;

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


        
        
        
        //*****************************************************************************************************************
        //-----------------------------------------------------------------------------------------------------------------
        //                                           EVENTOS
        //-----------------------------------------------------------------------------------------------------------------
        //*****************************************************************************************************************
        private void button_aumentar_Click(object sender, EventArgs e)
        {
            escala_imagen += 10;
            cambiarTamañoImagen(this.imagen_principal, escala_imagen, this.pictureBox_imagen);
        }

        private void button_disminuir_Click(object sender, EventArgs e)
        {
            escala_imagen -= 10;
            cambiarTamañoImagen(this.imagen_principal, escala_imagen, this.pictureBox_imagen);
        }

        private void button_fantasma_Click(object sender, EventArgs e)
        {
            string path_carpeta_matriz = "recursos\\datos_matriz";
            string path_codigo_graphviz = "recursos\\codigo_graphviz.txt";
            string path_imagen_mcbif = "recursos\\mbcif.jpg";
            GestionGraphviz gestion = new GestionGraphviz();
            StringBuilder codigo_graphviz = gestion.generarCodigoMBCIF(path_carpeta_matriz);
            gestion.generarArchivoDeTexto(codigo_graphviz,path_codigo_graphviz);
            gestion.crearImagenGraphViz(path_codigo_graphviz, path_imagen_mcbif);
            imagen_principal = gestion.cargarImagen(path_imagen_mcbif);
        }




    }
}
