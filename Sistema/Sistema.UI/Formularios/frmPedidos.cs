using Sistema.UI.Modulos;
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
    public partial class frmPedidos : Form
    {
        public frmPedidos()
        {
            InitializeComponent();
        }

        private void iconCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void iconGuardar_Click(object sender, EventArgs e)
        {
            frmTerminarPedido frm = new frmTerminarPedido();
            mostrarModal.MostrarConCapaTransparente(this, frm);
        }

        private void iconImprimir_Click(object sender, EventArgs e)
        {
            frmBuscarProductos frm = new frmBuscarProductos();
            mostrarModal.MostrarConCapaTransparente(this, frm);
        }
    }
}
