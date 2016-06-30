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
    public partial class FormVentanaBuscar : Form
    {
        public string seleccion
        {
            get { return _seleccion; }
        }
        string _seleccion = null;
        
        public FormVentanaBuscar()
        {
            InitializeComponent();
        }

        public FormVentanaBuscar(string titulo)
        {
            InitializeComponent();
            label_lista.Text = "Lista de " + titulo + " :";
        }


        public void agregarElemento(string elemento)
        {
            listBox_elementos.Items.Add(elemento);
        }


        private void button_aceptar_Click(object sender, EventArgs e)
        {
            if (listBox_elementos.SelectedItem != null && listBox_elementos.SelectedItem != "")
            {
                _seleccion = ""+listBox_elementos.SelectedItem;
                this.Hide();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún elemento", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
            }
        }

        private void button_cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
        }

        private void listBox_elementos_DoubleClick(object sender, EventArgs e)
        {
            if (listBox_elementos.SelectedItem != null && listBox_elementos.SelectedItem != "")
            {
                _seleccion = "" + listBox_elementos.SelectedItem;
                this.Hide();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún elemento", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
            }
        }


    }
}

//Tareas
//Respecto a modelo
//TODO implementacion influencia externa 
//TODO cambiar implementacion de influencia negativa o positiva

//respecto a GUI
//todo Colores de lo nods en graphvis en funcion del peso 
//todo sistemas deben conectarse por lineas no por flechas
//todo Flechas de influencias de color negro cambiante según el peso de la influencia 
//todo cambiar en el tiempo la imagen de la matriz
//todo graficos interactivos



