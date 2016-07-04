﻿using System;
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
        FormVentanaGraficos ventana_graficos = null;

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
            ventana_configuracion_bdd.button_limpiar_datos_matriz.Click += button_limpiar_datos_matriz_Click;
            ventana_configuracion_bdd.comprobarBdd();
            ventana_configuracion_bdd.button_limpiar_cola_de_analisis.Click += button_limpiar_cola_de_analisis_Click;
            
            ventana_graficos = new FormVentanaGraficos(ventana_mbcif._ruta_carpeta_mbcif);
            ventana_graficos.MdiParent = this;

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
        //            abrirToolStripMenuItem_Click
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ArrayList datos_nodos_matriz = new ArrayList();
                try
                {
                    using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                    {
                        string lectura = "";
                        while ((lectura = sr.ReadLine()) != null)
                        {
                            if (!lectura.Equals(""))
                            {
                                datos_nodos_matriz.Add(lectura);
                            }
                        }
                        sr.Close();
                    }
                    if (ventana_mbcif.establecerEstadoDeLaMatriz(datos_nodos_matriz))
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




        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            ventanaconfiguracion_button_limpiar_datos_matriz_Click
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        void button_limpiar_cola_de_analisis_Click(object sender, EventArgs e)
        {
            if (preguntaSiNo("Limpiar cola de analisis", "Esta usted seguro de limpiar la cola de análisis"))
            {
                ventana_mbcif.limpiarColaDeAnalisis();
                MessageBox.Show("Cola de analisis limpiada", "Información", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
                
        }
       
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            button_limpiar_datos_matriz_Click
        //--------------------------------------------------------------
        //--------------------------------------------------------------

        private void button_limpiar_datos_matriz_Click(object sender, EventArgs e)
        {
            if (preguntaSiNo("Limpiar datos matriz", "Esta usted seguro de limpiar los datos de la matriz"))
            {
                ventana_mbcif.reinicializarArchivosMBCIF();
                ventana_mbcif.iniciarMBCIF();
            }
        }
        
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            GraficosToolStripMenuItemClick
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        
		void GraficosToolStripMenuItemClick(object sender, EventArgs e)
		{
			ventana_graficos.Show();
		}
		
		//--------------------------------------------------------------
        //--------------------------------------------------------------
        //            GenerarReporteMSExcelToolStripMenuItemClick
        //--------------------------------------------------------------
        //--------------------------------------------------------------
		
		void GenerarReporteMSExcelToolStripMenuItemClick(object sender, EventArgs e)
		{
			 if (saveDialogReporte.ShowDialog() == DialogResult.OK)
            {
                var reporte = new Reporte(ventana_mbcif._ruta_carpeta_mbcif);
                if(reporte.generarReporte(saveDialogReporte.FileName))
                	MessageBox.Show("Reporte generado exitosamente","Reporte",MessageBoxButtons.OK,MessageBoxIcon.Information);
                else
                	MessageBox.Show("Ocurrió un error en la generación del reporte, inténtelo nuevamente.","Reporte",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			 }
            
		}


    }
}
