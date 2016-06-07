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
    public partial class FormVentanaPrincipal : Form
    {

        FormVentanaMBCIF ventana_mbcif = null;





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
            ventana_mbcif.Show();
        }

        



    }
}
