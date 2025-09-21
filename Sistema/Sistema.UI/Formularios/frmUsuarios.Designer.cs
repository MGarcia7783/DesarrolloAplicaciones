namespace Sistema.UI.Formularios
{
    partial class frmUsuarios
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
            ((System.ComponentModel.ISupportInitialize)(this.iconCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconEliminar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconEditar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconAgregar)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Size = new System.Drawing.Size(263, 37);
            this.lblTitulo.Text = "Módulo de Usuarios";
            // 
            // txtBuscar
            // 
            this.txtBuscar.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBuscar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBuscar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscar.DisabledState.Parent = this.txtBuscar;
            this.txtBuscar.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBuscar.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscar.FocusedState.Parent = this.txtBuscar;
            this.txtBuscar.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBuscar.HoverState.Parent = this.txtBuscar;
            this.txtBuscar.ShadowDecoration.Parent = this.txtBuscar;
            // 
            // iconAgregar
            // 
            this.iconAgregar.Click += new System.EventHandler(this.iconAgregar_Click);
            // 
            // frmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 591);
            this.Name = "frmUsuarios";
            this.Text = "frmUsuarios";
            ((System.ComponentModel.ISupportInitialize)(this.iconCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconEliminar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconEditar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconAgregar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}