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
        ArrayList ponderaciones = new ArrayList();
        ArrayList labels_pondearaciones_normalizadas = new ArrayList();
        public bool se_ingresaron_datos = false;
        public bool se_modificaron_ponderaciones = false;

        int ultima_posicion_label_y     = -1;
        int ultima_posicion_textbox_y   = -4;

        public double influencia_externa_forzada
        {
            get
            {
                return _influencia_externa_forzada;
            }
            set
            {
                trackBar_influencia_externa_forzada.Value = (int)(value*1000);
                textBox_influencia_externa_forzada.Text = "" + value;
                _influencia_externa_forzada = value;
            }
        }

        double _influencia_externa_forzada = 0;
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
            
            
            Label label0 = new Label();
            label0.AutoSize = true;
            label0.Location = new System.Drawing.Point(365, 5);
            label0.Name = "Ponderacion 0 - 1";
            label0.Size = new System.Drawing.Size(35, 13);
            label0.TabIndex = 0;
            label0.Text = "   Ponderacion    Normalizada";


            this.panel_campos.Controls.Add(label0);

            Label label1 = new Label();
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(310, 5);
            label1.Name = "Rango";
            label1.Size = new System.Drawing.Size(35, 13);
            label1.TabIndex = 0;
            label1.Text = "Rango";


            this.panel_campos.Controls.Add(label1);

        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            agregarCampos
        //--------------------------------------------------------------
        //-------------------------------------------------------------
        public void agregarCampos(string nombre_variable, double valor_actual, double[] rango, double ponderacion, bool textBox_editable = true)
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
            nuevo_textBox.Enabled = textBox_editable;

            Label label_rango = new Label();
            label_rango.AutoSize = true;
            label_rango.Location = new System.Drawing.Point(300, ultima_posicion_label_y);
            label_rango.Name = "rango";
            label_rango.Size = new System.Drawing.Size(35, 13);
            label_rango.TabIndex = 0;
            label_rango.Text = "( " + rango[0] + "  :   " + rango[1] + " )";


            NumericUpDown numericUpDown_ponderacion = new NumericUpDown();
            numericUpDown_ponderacion.DecimalPlaces = 2;
            numericUpDown_ponderacion.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            numericUpDown_ponderacion.Location = new System.Drawing.Point(380, ultima_posicion_label_y-3);
            numericUpDown_ponderacion.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            numericUpDown_ponderacion.Name = "Ponderacion";
            numericUpDown_ponderacion.Size = new System.Drawing.Size(60, 20);
            numericUpDown_ponderacion.TabIndex = 1;
            numericUpDown_ponderacion.Value = (decimal)ponderacion;
            numericUpDown_ponderacion.ValueChanged += new System.EventHandler(numericUpDownPonderaciones_ValueChanged);

            Label label_ponderacion_normalizada = new Label();
            label_ponderacion_normalizada.AutoSize = true;
            label_ponderacion_normalizada.Location = new System.Drawing.Point(460, ultima_posicion_label_y);
            label_ponderacion_normalizada.Name = "ponderacion normalizada";
            label_ponderacion_normalizada.Size = new System.Drawing.Size(35, 13);
            label_ponderacion_normalizada.TabIndex = 0;
            label_ponderacion_normalizada.Text = "1";



            labels.Add(label_nombre_variable);
            textboxs.Add(nuevo_textBox);
            rangos.Add(rango);
            ponderaciones.Add(numericUpDown_ponderacion);
            labels_pondearaciones_normalizadas.Add(label_ponderacion_normalizada);


            this.panel_campos.Controls.Add(label_nombre_variable);
            this.panel_campos.Controls.Add(label_rango);
            this.panel_campos.Controls.Add(nuevo_textBox);
            this.panel_campos.Controls.Add(numericUpDown_ponderacion);
            this.panel_campos.Controls.Add(label_ponderacion_normalizada);


            this.panel_influencia_externa_forzada.Location = new System.Drawing.Point(this.panel_influencia_externa_forzada.Location.X, ultima_posicion_textbox_y + 25);
            actualizarPonderacionesNormalizadas();
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

        public double extraerValorVariablePorNombre(string id_variable)
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


        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            ExtraerValorPonderacionVariablePorNombre
        //--------------------------------------------------------------
        //-------------------------------------------------------------

        public double extraerValorPonderacionVariablePorNombre(string id_variable)
        {
            for (int i = 0; i < textboxs.Count; i++)
            {
                Label aux_label = (Label)labels[i];
                NumericUpDown aux_numericUpDown = (NumericUpDown)ponderaciones[i];
                if (aux_label.Text.Equals(id_variable))
                {
                    try
                    {
                        double valor = (double)aux_numericUpDown.Value;
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

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            actualizarPonderacionesNormalizadas
        //--------------------------------------------------------------
        //-------------------------------------------------------------
        public void actualizarPonderacionesNormalizadas()
        {
            double total_ponderaciones = sumarTodasLasPonderaciones();
            for (int i = 0; i < ponderaciones.Count; i++)
            {
                NumericUpDown numeric = (NumericUpDown)ponderaciones[i];
                double valor_ponderacion = (double)numeric.Value;
                double valor_ponderacion_normalizada = valor_ponderacion / total_ponderaciones;
                string ponderacion = String.Format("{0:0.00}", valor_ponderacion_normalizada);
                Label ponderacion_normalizada = (Label)labels_pondearaciones_normalizadas[i];
                ponderacion_normalizada.Text = "(" + ponderacion + ")";
            }
        }



        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            sumarTodasLasPonderaciones
        //--------------------------------------------------------------
        //-------------------------------------------------------------
        public double sumarTodasLasPonderaciones()
        {
            double total = 0;
            foreach  (NumericUpDown item in ponderaciones)
            {
                total += (double)item.Value;
            }
            return total;
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

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            trackBar_influencia_externa_forzada_ValueChanged
        //--------------------------------------------------------------
        //-------------------------------------------------------------
        private void trackBar_influencia_externa_forzada_ValueChanged(object sender, EventArgs e)
        {
            influencia_externa_forzada = ((double)trackBar_influencia_externa_forzada.Value) / 1000;
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            button_limpiar_influencia_externa_Click
        //--------------------------------------------------------------
        //-------------------------------------------------------------
        private void button_limpiar_influencia_externa_Click(object sender, EventArgs e)
        {
            influencia_externa_forzada = 0;
            trackBar_influencia_externa_forzada.Value = 0;
            textBox_influencia_externa_forzada.Text = ""+0;
        }

        //--------------------------------------------------------------
        //--------------------------------------------------------------
        //            numericUpDownPonderaciones_ValueChanged
        //--------------------------------------------------------------
        //-------------------------------------------------------------
        private void numericUpDownPonderaciones_ValueChanged(object sender, EventArgs e)
        {
            se_modificaron_ponderaciones = true;
            actualizarPonderacionesNormalizadas();
        }

    }
}
