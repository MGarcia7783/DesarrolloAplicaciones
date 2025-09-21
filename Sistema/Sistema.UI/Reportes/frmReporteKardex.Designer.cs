namespace Sistema.UI.Reportes
{
    partial class frmReporteKardex
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dtsConexion = new Sistema.UI.OrigenDatos.DtsConexion();
            this.kardexBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtsConexion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kardexBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DtsKardex";
            reportDataSource1.Value = this.kardexBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Sistema.UI.Reportes.rptKardex.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1134, 711);
            this.reportViewer1.TabIndex = 0;
            // 
            // dtsConexion
            // 
            this.dtsConexion.DataSetName = "DtsConexion";
            this.dtsConexion.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // kardexBindingSource
            // 
            this.kardexBindingSource.DataMember = "Kardex";
            this.kardexBindingSource.DataSource = this.dtsConexion;
            // 
            // frmReporteKardex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 711);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmReporteKardex";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmReporteKardex";
            this.Load += new System.EventHandler(this.frmReporteKardex_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtsConexion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kardexBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource kardexBindingSource;
        private OrigenDatos.DtsConexion dtsConexion;
    }
}