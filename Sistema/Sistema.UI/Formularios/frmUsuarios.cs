using Sistema.UI.FormulariosBase;
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
    public partial class frmUsuarios : frmPlantilla
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void iconAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarUsuario frm = new frmAgregarUsuario();
            mostrarModal.MostrarConCapaTransparente(this, frm);
        }
    }
}
