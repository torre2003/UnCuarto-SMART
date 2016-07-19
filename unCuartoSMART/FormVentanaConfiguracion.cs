using AccesoADatos;
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
    public delegate void DelegadoConexionBDD (bool base_de_datos_conectada);
    public delegate void DelegadoReinicializacionMBCIF ();

    public partial class FormVentanaConfiguracion : Form
    {
        public event DelegadoConexionBDD evento_conexion_bdd;
        public event DelegadoReinicializacionMBCIF evento_reinicializacion_MBCIF;

        public string _ruta_carpeta_mbcif = "recursos\\datos_matriz";
        public string _ruta_carpeta_mbcif_en_blanco = "recursos\\datos_matriz_en_blanco";



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

        public FormVentanaConfiguracion()
        {
            InitializeComponent();
            pictureBox_estado_conexion_base_de_datos.Image = imageList_estado.Images[0];
            pictureBox_bdd_inicializada.Image = imageList_estado.Images[0];
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            comprobarBdd
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        public void comprobarBdd()
        {
            bool flag = false;
            if (comprobarConexion())
            {
                pictureBox_estado_conexion_base_de_datos.Image = imageList_estado.Images[1];
                if (comprobarBaseDeDatosIniciada())
                {
                    pictureBox_bdd_inicializada.Image = imageList_estado.Images[1];
                    button_iniciar_bdd.Text = "Reinicializar BDD";
                    flag = true;
                }
            }

            if (evento_conexion_bdd != null)
                evento_conexion_bdd(flag);
        }



        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            comprobarConexion
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        public bool comprobarConexion()
        {
            ManejadorDeDatosArchivos manejador_de_archivos = new ManejadorDeDatosArchivos(_ruta_carpeta_mbcif);
            ManejadorDeDatosBaseDeDatos manejador_de_base_de_datos = new ManejadorDeDatosBaseDeDatos(manejador_de_archivos);
            return manejador_de_base_de_datos.bdd_conectada;
        }
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            comprobarBaseDeDatosIniciada
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        private bool comprobarBaseDeDatosIniciada()
        {
            ManejadorDeDatosArchivos manejador_de_archivos = new ManejadorDeDatosArchivos(_ruta_carpeta_mbcif);
            ManejadorDeDatosBaseDeDatos manejador_de_base_de_datos = new ManejadorDeDatosBaseDeDatos(manejador_de_archivos);
            return manejador_de_base_de_datos.comproabrInicializacionBaseDeDatos();
        }




        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            preguntaSiNo
        //--------------------------------------------------------------
        //--------------------------------------------------------------

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
        //            FormVentanaConfiguracionBaseDeDatos_FormClosing
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        private void FormVentanaConfiguracionBaseDeDatos_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            button_conectar_bdd_Click
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        private void button_conectar_bdd_Click(object sender, EventArgs e)
        {
            if (comprobarConexion())
            {
                pictureBox_estado_conexion_base_de_datos.Image = imageList_estado.Images[1];
                if (comprobarBaseDeDatosIniciada() && evento_conexion_bdd != null)
                    evento_conexion_bdd(true);
                MessageBox.Show("Se conexión a la base de datos\n esta funcionando correctamente", "Base de datos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
            else
            {
                pictureBox_estado_conexion_base_de_datos.Image = imageList_estado.Images[0];
                MessageBox.Show("Problemas con la conexión a la base de datos", "Error de conexión", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            button_iniciar_bdd_Click
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        private void button_iniciar_bdd_Click(object sender, EventArgs e)
        {
            if (preguntaSiNo("Reinicializando base de datos", "Esta seguro de reinicializar la base de datos, \nSe borraran todos los datos guardados"))
            {
                pictureBox_bdd_inicializada.Image = imageList_estado.Images[0];
                ManejadorDeDatosArchivos manejador_de_archivos = new ManejadorDeDatosArchivos(_ruta_carpeta_mbcif);
                ManejadorDeDatosBaseDeDatos manejador_de_base_de_datos = new ManejadorDeDatosBaseDeDatos(manejador_de_archivos);
                if (manejador_de_base_de_datos.bdd_conectada)
                {
                    if (!manejador_de_base_de_datos.inicializarBaseDeDatos())
                        MessageBox.Show("Problemas con la inicializacion de la bdd");
                    else
                    {
                        pictureBox_bdd_inicializada.Image = imageList_estado.Images[1];
                        MessageBox.Show("Base de datos iniciada correctamente", "Base de datos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                        button_iniciar_bdd.Text = "Reinicializar BDD";
                        if (comprobarBaseDeDatosIniciada() && evento_conexion_bdd != null)
                            evento_conexion_bdd(true);
                    }

                }
                else
                {
                    MessageBox.Show("Problemas con la conexion de la base de datos");
                }
            }
        }

    }
}
