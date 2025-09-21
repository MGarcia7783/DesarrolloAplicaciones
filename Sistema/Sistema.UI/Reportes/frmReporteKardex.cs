using Microsoft.Reporting.WinForms;
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

namespace Sistema.UI.Reportes
{
    public partial class frmReporteKardex : Form
    {
        private Mensajes mensaje = new Mensajes();
        private DataTable datos;
        private string codigo;
        private string producto;
        private string periodo;

        public frmReporteKardex(DataTable datos, string codigo, string producto, string periodo)
        {
            InitializeComponent();

            this.datos = datos;
            this.codigo = codigo;
            this.producto = producto;
            this.periodo = periodo;
        }

        private void frmReporteKardex_Load(object sender, EventArgs e)
        {
            try
            {
                reportViewer1.LocalReport.DataSources.Clear();

                ReportDataSource rds = new ReportDataSource("DtsKardex", datos);
                reportViewer1.LocalReport.DataSources.Add(rds);

                // Pasar parámetros
                ReportParameter[] parametros = new ReportParameter[]
                {
                    new ReportParameter("Codigo", codigo),
                    new ReportParameter("Producto", producto),
                    new ReportParameter("Periodo", periodo),
                };

                reportViewer1.LocalReport.SetParameters(parametros);

                this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                this.reportViewer1.RefreshReport();
            }

            catch(Exception)
            {
                mensaje.mensajeError("Ocurrió un error al cargar el reporte.");
            }
        }
    }
}
