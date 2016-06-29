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
    public partial class FormVentanaPrincipal : Form
    {

        FormVentanaMBCIF ventana_mbcif = null;
        FormVentanaConfiguracion ventana_configuracion_bdd = null;

        bool bdd_funcionando = true;



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
        
        public FormVentanaPrincipal()
        {
            InitializeComponent();
            ventana_mbcif = new FormVentanaMBCIF();
            ventana_mbcif.MdiParent = this;
           

            ventana_configuracion_bdd = new FormVentanaConfiguracion();
            ventana_configuracion_bdd.MdiParent = this;
            ventana_configuracion_bdd.evento_conexion_bdd += new DelegadoConexionBDD(eventoBaseDeDatosFuncionando);
            ventana_configuracion_bdd.evento_reinicializacion_MBCIF += new DelegadoReinicializacionMBCIF(eventoReinicializacionMBCIF);
            ventana_configuracion_bdd.comprobarBdd();

        }



        //*****************************************************************************************************************
        //-----------------------------------------------------------------------------------------------------------------
        //                                           EVENTOS
        //-----------------------------------------------------------------------------------------------------------------
        //*****************************************************************************************************************

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            baseDeDatosToolStripMenuItem_Click
        //--------------------------------------------------------------
        //--------------------------------------------------------------

        private void configuracionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ventana_configuracion_bdd.Show();
        }


        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            modeloToolStripMenuItem_modelo_mbcif_Click
        //--------------------------------------------------------------
        //--------------------------------------------------------------

        private void modeloToolStripMenuItem_modelo_mbcif_Click(object sender, EventArgs e)
        {
            if (bdd_funcionando)
                ventana_mbcif.Show();
            else
            {
                ventana_configuracion_bdd.Show();
                MessageBox.Show("Problemas con la base de datos", "Base de datos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            eventoBaseDeDatosFuncionando
        //--------------------------------------------------------------
        //--------------------------------------------------------------

        private void eventoBaseDeDatosFuncionando(bool base_de_datos_funcionando)
        {
            if (base_de_datos_funcionando)
            {
                bdd_funcionando = true;
            }
            else
            {
                MessageBox.Show("Problemas con la base de datos", "Base de datos", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                bdd_funcionando = false;
                ventana_configuracion_bdd.Show();
            }
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            eventoReinicializacionBaseDeDatos
        //--------------------------------------------------------------
        //--------------------------------------------------------------

        private void eventoReinicializacionMBCIF()
        {
            ventana_mbcif.iniciarMBCIF();
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            abrirToolStripMenuItem_Click
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ArrayList datos_matrices = new ArrayList();
                try
                {
                    using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                    {
                        string lectura = "";
                        while ((lectura = sr.ReadLine()) != null)
                        {
                            if (!lectura.Equals(""))
                            {
                                datos_matrices.Add(lectura);
                            }
                        }
                        sr.Close();
                    }
                    if (ventana_mbcif.ingresarDatosInternosANodos(datos_matrices))
                            MessageBox.Show("Datos cargados correctamente", "Información", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    else 
                            MessageBox.Show("Error en la carga de datos", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Problemas con la lectura de archivos", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
        }
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            guardarToolStripMenuItem_Click
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path_archivo = saveFileDialog1.FileName;

                StringBuilder sb = ventana_mbcif.extraerDatosInternosDeNodos();
                using (StreamWriter outfile = new StreamWriter(path_archivo, false))
                {
                    outfile.Write(sb.ToString());
                }
            }
        }
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            salirToolStripMenuItem_salir_Click
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        private void salirToolStripMenuItem_salir_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
