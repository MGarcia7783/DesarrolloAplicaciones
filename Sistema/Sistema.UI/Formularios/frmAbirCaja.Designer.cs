namespace Sistema.UI.Formularios
{
    partial class frmAbirCaja
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
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.errorIcono = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtMontoApertura = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtNumeroCaja = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.iconCancelar = new FontAwesome.Sharp.IconButton();
            this.iconAceptar = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 15;
            this.guna2Elipse1.TargetControl = this;
            // 
            // errorIcono
            // 
            this.errorIcono.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(93)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(328, 66);
            this.label1.TabIndex = 7;
            this.label1.Text = "Abrir Caja";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.txtMontoApertura, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtNumeroCaja, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(20, 91);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(296, 149);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // txtMontoApertura
            // 
            this.txtMontoApertura.BorderRadius = 6;
            this.txtMontoApertura.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMontoApertura.DefaultText = "0.00";
            this.txtMontoApertura.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMontoApertura.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMontoApertura.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMontoApertura.DisabledState.Parent = this.txtMontoApertura;
            this.txtMontoApertura.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMontoApertura.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMontoApertura.FocusedState.Parent = this.txtMontoApertura;
            this.txtMontoApertura.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoApertura.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMontoApertura.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtMontoApertura.HoverState.Parent = this.txtMontoApertura;
            this.txtMontoApertura.Location = new System.Drawing.Point(6, 98);
            this.txtMontoApertura.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.txtMontoApertura.Name = "txtMontoApertura";
            this.txtMontoApertura.PasswordChar = '\0';
            this.txtMontoApertura.PlaceholderText = "";
            this.txtMontoApertura.SelectedText = "";
            this.txtMontoApertura.SelectionStart = 4;
            this.txtMontoApertura.ShadowDecoration.Parent = this.txtMontoApertura;
            this.txtMontoApertura.Size = new System.Drawing.Size(267, 36);
            this.txtMontoApertura.TabIndex = 4;
            this.txtMontoApertura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMontoApertura_KeyPress);
            this.txtMontoApertura.Leave += new System.EventHandler(this.txtMontoApertura_Leave);
            // 
            // txtNumeroCaja
            // 
            this.txtNumeroCaja.BorderRadius = 6;
            this.txtNumeroCaja.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNumeroCaja.DefaultText = "0";
            this.txtNumeroCaja.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNumeroCaja.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNumeroCaja.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNumeroCaja.DisabledState.Parent = this.txtNumeroCaja;
            this.txtNumeroCaja.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNumeroCaja.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNumeroCaja.FocusedState.Parent = this.txtNumeroCaja;
            this.txtNumeroCaja.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumeroCaja.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNumeroCaja.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNumeroCaja.HoverState.Parent = this.txtNumeroCaja;
            this.txtNumeroCaja.Location = new System.Drawing.Point(4, 24);
            this.txtNumeroCaja.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNumeroCaja.Name = "txtNumeroCaja";
            this.txtNumeroCaja.PasswordChar = '\0';
            this.txtNumeroCaja.PlaceholderText = "";
            this.txtNumeroCaja.SelectedText = "";
            this.txtNumeroCaja.SelectionStart = 1;
            this.txtNumeroCaja.ShadowDecoration.Parent = this.txtNumeroCaja;
            this.txtNumeroCaja.Size = new System.Drawing.Size(269, 36);
            this.txtNumeroCaja.TabIndex = 2;
            this.txtNumeroCaja.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroCaja_KeyPress);
            this.txtNumeroCaja.Leave += new System.EventHandler(this.txtNumeroCaja_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(290, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Número de caja";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(3, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(290, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Monto de apertura";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel2.Controls.Add(this.iconCancelar, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.iconAceptar, 1, 0);
            this.tableLayoutPanel2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(34, 246);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(282, 50);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // iconCancelar
            // 
            this.iconCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconCancelar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iconCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iconCancelar.IconChar = FontAwesome.Sharp.IconChar.CircleXmark;
            this.iconCancelar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iconCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconCancelar.IconSize = 30;
            this.iconCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconCancelar.Location = new System.Drawing.Point(141, 3);
            this.iconCancelar.Name = "iconCancelar";
            this.iconCancelar.Padding = new System.Windows.Forms.Padding(5);
            this.iconCancelar.Size = new System.Drawing.Size(118, 44);
            this.iconCancelar.TabIndex = 2;
            this.iconCancelar.Text = "Cancelar";
            this.iconCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.iconCancelar, "Cerrar ventana");
            this.iconCancelar.UseVisualStyleBackColor = true;
            this.iconCancelar.Click += new System.EventHandler(this.iconCancelar_Click);
            // 
            // iconAceptar
            // 
            this.iconAceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconAceptar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iconAceptar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iconAceptar.IconChar = FontAwesome.Sharp.IconChar.CircleCheck;
            this.iconAceptar.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.iconAceptar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconAceptar.IconSize = 30;
            this.iconAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconAceptar.Location = new System.Drawing.Point(17, 3);
            this.iconAceptar.Name = "iconAceptar";
            this.iconAceptar.Padding = new System.Windows.Forms.Padding(5);
            this.iconAceptar.Size = new System.Drawing.Size(118, 44);
            this.iconAceptar.TabIndex = 0;
            this.iconAceptar.Text = "Aceptar";
            this.iconAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.iconAceptar, "Guardar registro");
            this.iconAceptar.UseVisualStyleBackColor = true;
            this.iconAceptar.Click += new System.EventHandler(this.iconAceptar_Click);
            // 
            // frmAbirCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(328, 331);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmAbirCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmAbirCaja";
            this.Load += new System.EventHandler(this.frmAbirCaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ErrorProvider errorIcono;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2TextBox txtMontoApertura;
        private Guna.UI2.WinForms.Guna2TextBox txtNumeroCaja;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private FontAwesome.Sharp.IconButton iconCancelar;
        private FontAwesome.Sharp.IconButton iconAceptar;
    }
}