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
        

        public string descripcion_seleccion
        {
            get { return _descripcion_seleccion; }
        }
        string _descripcion_seleccion = null;
        public FormVentanaBuscar()
        {
            InitializeComponent();
        }

        public FormVentanaBuscar(string titulo)
        {
            InitializeComponent();
            label_lista.Text = "Lista de " + titulo + " :";
        }


        public void agregarElemento(string elemento, string descripcion_elemento = null)
        {
            ElementosCheckBox elementoCheck = new ElementosCheckBox(elemento, descripcion_elemento);
            listBox_elementos.Items.Add(elementoCheck);
        }


        private void button_aceptar_Click(object sender, EventArgs e)
        {
            if (listBox_elementos.SelectedItem != null )
            {
                ElementosCheckBox elemento_seleccionado = (ElementosCheckBox)listBox_elementos.SelectedItem;
                _seleccion = ""+elemento_seleccionado.id_elemento;
                if (elemento_seleccionado.descripcion_elemento != null)
                    _descripcion_seleccion = elemento_seleccionado.descripcion_elemento;
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
                ElementosCheckBox elemento_seleccionado = (ElementosCheckBox)listBox_elementos.SelectedItem;
                _seleccion = "" + elemento_seleccionado.id_elemento;
                if (elemento_seleccionado.descripcion_elemento != null)
                    _descripcion_seleccion = elemento_seleccionado.descripcion_elemento;
                this.Hide();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningún elemento", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
            }
        }


        private struct ElementosCheckBox
        {
            public string id_elemento;
            public string descripcion_elemento;
    
            public ElementosCheckBox(string id_elemento, string descripcion_elemento)
            {
                this.id_elemento = id_elemento;
                this.descripcion_elemento = descripcion_elemento;
            }


            public override string ToString() 
            { 
                string retorno = id_elemento;
                if (descripcion_elemento != null)
                    retorno += "  " + descripcion_elemento;
                return retorno;
            }
        }

    }
}


//tareas


// Extras
//TODO nombre de archivo en el titulo
//TODO iconos en ventanass
//TODO actualizacion de graficos interactivos
//TODO la imagen debe respetar el tamaño al actualizarse Paso a Paso
//TODO ventana de busqueda nodos con nombre 

