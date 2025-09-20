using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.UI.Formularios
{
    public partial class frmBuscarProductos : Form
    {
        public frmBuscarProductos()
        {
            InitializeComponent();
        }

        private void iconSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
