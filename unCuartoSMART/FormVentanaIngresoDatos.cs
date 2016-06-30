using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace unCuartoSMART
{
    public partial class FormVentanaIngresoDatos : Form
    {
        ArrayList labels = new ArrayList();
        ArrayList textboxs = new ArrayList();
        ArrayList rangos = new ArrayList();

        public bool se_ingresaron_datos = false;

        int ultima_posicion_label_y     = -1;
        int ultima_posicion_textbox_y   = -4;

        //*****************************************************************************************************************
        //-----------------------------------------------------------------------------------------------------------------
        //                                           METODOS
        //-----------------------------------------------------------------------------------------------------------------
        //****************************************************************************************************************

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            Constructor
        //--------------------------------------------------------------
        //-------------------------------------------------------------
        public FormVentanaIngresoDatos()
        {
            InitializeComponent();
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            Constructor
        //--------------------------------------------------------------
        //-------------------------------------------------------------
        public FormVentanaIngresoDatos(string nombre_nodo)
        {
            InitializeComponent();
            this.Text = "Modificación de datos Nodo \" "+nombre_nodo+"\"";
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            agregarCampos
        //--------------------------------------------------------------
        //-------------------------------------------------------------
        public void agregarCampos(string nombre_variable, double valor_actual, double[] rango)
        {
            ultima_posicion_label_y += 25;
            ultima_posicion_textbox_y += 25;

            Label label_nombre_variable = new Label();
            label_nombre_variable.AutoSize = true;
            label_nombre_variable.Location = new System.Drawing.Point(30, ultima_posicion_label_y);
            label_nombre_variable.Name = nombre_variable;
            label_nombre_variable.Size = new System.Drawing.Size(35, 13);
            label_nombre_variable.TabIndex = 0;
            label_nombre_variable.Text = nombre_variable;

            TextBox nuevo_textBox = new TextBox();
            nuevo_textBox.Location = new System.Drawing.Point(190, ultima_posicion_textbox_y);
            nuevo_textBox.Name = "";
            nuevo_textBox.Size = new System.Drawing.Size(100, 20);
            nuevo_textBox.TabIndex = 1;
            nuevo_textBox.Text = "" + valor_actual;


            Label label_rango = new Label();
            label_rango.AutoSize = true;
            label_rango.Location = new System.Drawing.Point(300, ultima_posicion_label_y);
            label_rango.Name = "rango";
            label_rango.Size = new System.Drawing.Size(35, 13);
            label_rango.TabIndex = 0;
            label_rango.Text = "( " + rango[0] + "  :   " + rango[1] + " )";

            labels.Add(label_nombre_variable);
            textboxs.Add(nuevo_textBox);
            rangos.Add(rango);

            this.panel_campos.Controls.Add(label_nombre_variable);
            this.panel_campos.Controls.Add(label_rango);
            this.panel_campos.Controls.Add(nuevo_textBox);
            

        }


        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            ComprobarRangos
        //--------------------------------------------------------------
        //-------------------------------------------------------------

        private bool comprobarRangos()
        {
            bool flag = true;
            for (int i = 0; i < textboxs.Count; i++)
            {
                TextBox aux = (TextBox)textboxs[i];
                try
                {

                    double valor = (double)Convert.ToDecimal(aux.Text, CultureInfo.CreateSpecificCulture("en-US"));
                    double[] rango = (double[])rangos[i];

                    if (valor < rango[0] || rango[1] < valor)
                    {
                        flag = false;
                        aux.BackColor = System.Drawing.SystemColors.Info;
                    }
                    else
                    {
                        aux.BackColor = System.Drawing.SystemColors.Window;
                    }
                }
                catch (Exception)
                {
                    flag = false;
                    aux.BackColor = System.Drawing.SystemColors.Info;
                }
            }
            return flag;
            //this.textBox1.BackColor = System.Drawing.SystemColors.Info;
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            ExtraerValorVariablePorNombre
        //--------------------------------------------------------------
        //-------------------------------------------------------------

        public double ExtraerValorVariablePorNombre(string id_variable)
        {
            for (int i = 0; i < textboxs.Count; i++)
            {
                Label aux_label = (Label)labels[i];
                TextBox aux_textbox = (TextBox)textboxs[i];
                if (aux_label.Text.Equals(id_variable))
                {
                    try
                    {
                        double valor = (double)Convert.ToDecimal(aux_textbox.Text, CultureInfo.CreateSpecificCulture("en-US"));
                        return valor;
                    }
                    catch (Exception)
                    {
                        return -666;
                    }
                }
            }
            return -666;
        }




        //*****************************************************************************************************************
        //-----------------------------------------------------------------------------------------------------------------
        //                                           EVENTOS
        //-----------------------------------------------------------------------------------------------------------------
        //*****************************************************************************************************************


        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            button_aceptar_Click
        //--------------------------------------------------------------
        //-------------------------------------------------------------
        private void button_aceptar_Click(object sender, EventArgs e)
        {
            if (comprobarRangos())
            {
                this.se_ingresaron_datos = true;
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Se han ingresado valores incorrectamente", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            button_cancelar_Click
        //--------------------------------------------------------------
        //-------------------------------------------------------------
        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }



    }
}
