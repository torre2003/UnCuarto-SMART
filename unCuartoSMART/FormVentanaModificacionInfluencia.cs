using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace unCuartoSMART
{
    public partial class FormVentanaModificacionInfluencia : Form
    {
        public double valor_ajuste_influencia
        {
            get { return _valor_ajuste_influencia; }
            set 
            {
                if (value < 0)
                    value = 0;
                if (value > 2)
                    value = 2;
                _valor_ajuste_influencia = value;
                textBox_valor_ajuste.Text = String.Format("{0:0.000}", value);
                trackBar_valor_ajuste.Value = (int)(value * 10000);
            }
        }
        double _valor_ajuste_influencia = 0;

        public bool se_ingresarion_datos = false;


        //*****************************************************************************************************************
        //-----------------------------------------------------------------------------------------------------------------
        //                                           MÉTODOS
        //-----------------------------------------------------------------------------------------------------------------
        //*****************************************************************************************************************
        public FormVentanaModificacionInfluencia(string id_influencia, string nombre_influencia, double valor_ajuste)
        {
            InitializeComponent();
            this.Text = id_influencia;
            valor_ajuste_influencia = valor_ajuste;
            
            if (!nombre_influencia.Equals(""))
            {
                label_nombre_influencia.Text = nombre_influencia;
                label_nombre_influencia.Visible = true;
            }
            else
            {
                label_nombre_influencia.Visible = false;
            }
        }


        //*****************************************************************************************************************
        //-----------------------------------------------------------------------------------------------------------------
        //                                           EVENTOS
        //-----------------------------------------------------------------------------------------------------------------
        //*****************************************************************************************************************

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            trackBar_valor_ajuste_Scroll
        //--------------------------------------------------------------
        //--------------------------------------------------------------

        private void trackBar_valor_ajuste_Scroll(object sender, EventArgs e)
        {
            valor_ajuste_influencia = ((double)trackBar_valor_ajuste.Value)/10000;
        }
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            button_limpiar_Click
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        private void button_limpiar_Click(object sender, EventArgs e)
        {
            valor_ajuste_influencia = 1;
            se_ingresarion_datos = true;
        }
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            button_cancelar_Click
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            button_aceptar_Click
        //--------------------------------------------------------------
        //--------------------------------------------------------------
        private void button_aceptar_Click(object sender, EventArgs e)
        {
            se_ingresarion_datos = true;
            this.Close();
        }


    }
}
